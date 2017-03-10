using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Interfaces.Rendering;
using Interfaces.Rendering.Radiosity;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Instancing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Textures;
using Games.Halo.Tags.Fields;
using System.Diagnostics;
using Interfaces.DebugConsole;
using Interfaces.Rendering.Selection;
using System.Threading;
using Interfaces.Rendering.Radiosity;
using Radiosity = Interfaces.Rendering.Radiosity;

namespace Games.Halo.Tags.Classes
{
  public partial class scenario_structure_bsp : IBsp, IInstanceable, IEnvironment
  {
    private int pixelCount = 0;
    private bitmap lightmaps = null;
    public shader[/* lightmaps */][/* materials */] shaders = null;
    private EnhancedMesh[/* lightmaps */][/* materials */] meshes = null;
    private Sampler[/* lightmaps */][/* materials */] bspSamplers = null;
    private InstanceCollection instances = new InstanceCollection();
    private Sampler[] samplers = null;
    private sound_looping[] ambiences = null;
    private RadiosityMaterial[][] materials;

    private const int UncompressedVertexSize = 56; // size of the vertex position, texture coordinates, and tangent frame
    private const int UncompressedLightmapSize = 20; // size of the vertex lightmap coordinates and normal data
    private const float Epsilon = 0.005f;
    protected int activeLeafIndex = -1;
    protected int activeClusterIndex = -1;
    protected byte[] vis;
    protected int[] visibleSurfaces;
    private BoundingBox[][] subClusters;
    private bool renderOnlyLightmap = false;

    //[Console("halo_lightmap_sample_distance", "this is the distance away from the origin that lightmap multisampling will occur")]
    //private static float LightmapSamplingDistance = 1.0f;

    /// <summary>
    /// Readies the bsp to be rendered; handles any data conversion and post-load errands.
    /// </summary>
    public override void DoPostProcess()
    {
      base.DoPostProcess();

      bspBounds = new WorldBounds(new Bounds(scenarioStructureBspValues.WorldBoundsX.Lower, scenarioStructureBspValues.WorldBoundsX.Upper), new Bounds(scenarioStructureBspValues.WorldBoundsY.Lower, scenarioStructureBspValues.WorldBoundsY.Upper), new Bounds(scenarioStructureBspValues.WorldBoundsZ.Lower, scenarioStructureBspValues.WorldBoundsZ.Upper));

      lightmaps = Open<bitmap>(scenarioStructureBspValues.Lightmaps.Value);

      if (lightmaps != null)
      {
        samplers = new Sampler[lightmaps.BitmapValues.Bitmaps.Count];
        for (int bitmap = 0; bitmap < lightmaps.BitmapValues.Bitmaps.Count; bitmap++)
          samplers[bitmap] = new Sampler(lightmaps[bitmap] as Texture, lightmaps.GetFormat(bitmap), lightmaps.BitmapValues.Bitmaps[bitmap].Width.Value, lightmaps.BitmapValues.Bitmaps[bitmap].Height.Value);
      }

      int i = 0;
      meshes = new EnhancedMesh[scenarioStructureBspValues.Lightmaps2.Count][];
      shaders = new shader[scenarioStructureBspValues.Lightmaps2.Count][];
      bspSamplers = new Sampler[scenarioStructureBspValues.Lightmaps2.Count][];
      materials = new RadiosityMaterial[scenarioStructureBspValues.Lightmaps2.Count][];
      foreach (StructureBspLightmapBlock lightmap in scenarioStructureBspValues.Lightmaps2)
      {
        int j = 0;
        meshes[i] = new EnhancedMesh[lightmap.Materials.Count];
        shaders[i] = new shader[lightmap.Materials.Count];
        bspSamplers[i] = new Sampler[lightmap.Materials.Count];
        materials[i] = new RadiosityMaterial[lightmap.Materials.Count];
        foreach (StructureBspMaterialBlock material in lightmap.Materials)
        {
          /*
           * Vector3 position;
           * Vector3 normal;
           * Vector3 binormal;
           * Vector3 tangent;
           * Vector2 textureCoordinates;
           * 
           * Vector3 lightmapNormal;
           * Vector2 lightmapCoordinates;
           */

          Vertex[] vertices = new Vertex[material.VertexCount.Value];
          ushort[] indices = new ushort[material.SurfaceCount.Value * 3];

          for (int k = 0; k < material.SurfaceCount.Value; k++)
          {
            indices[k * 3] = (ushort)scenarioStructureBspValues.Surfaces[k + material.Surfaces.Value].Tria.Value;
            indices[k * 3 + 1] = (ushort)scenarioStructureBspValues.Surfaces[k + material.Surfaces.Value].Trib.Value;
            indices[k * 3 + 2] = (ushort)scenarioStructureBspValues.Surfaces[k + material.Surfaces.Value].Tric.Value;
          }

          BinaryReader buffer = new BinaryReader(new MemoryStream(material.UncompressedVertices.Binary, false));
          for (int k = 0; k < material.VertexCount.Value; k++)
          {
            vertices[k].position.X = buffer.ReadSingle();
            vertices[k].position.Y = buffer.ReadSingle();
            vertices[k].position.Z = buffer.ReadSingle();
            vertices[k].normal.X = buffer.ReadSingle();
            vertices[k].normal.Y = buffer.ReadSingle();
            vertices[k].normal.Z = buffer.ReadSingle();
            buffer.BaseStream.Position += 24;
            vertices[k].u1 = buffer.ReadSingle();
            vertices[k].v1 = buffer.ReadSingle();
          }
          for (int k = 0; k < material.LightmapCount.Value; k++)
          {
            buffer.BaseStream.Position += 12;
            vertices[k].u2 = buffer.ReadSingle();
            vertices[k].v2 = buffer.ReadSingle();
          }
          buffer.Close();

          SubMesh[] sub = new SubMesh[1];
          sub[0] = new SubMesh(0, (ushort)material.SurfaceCount.Value, 0);
          meshes[i][j] = new EnhancedMesh(vertices, indices, sub, false, false, true);
          shaders[i][j] = OpenShader(material.Shader.Value, material.Shader.TagGroup);
          meshes[i][j].DefaultShader = shaders[i][j];
          if (shaders[i][j] is shader_environment)
          {
            shader_environment s_e = shaders[i][j] as shader_environment;
            bitmap bitmap = Open<bitmap>(s_e.ShaderEnvironmentValues.BaseMap.Value);
            bspSamplers[i][j] =
              new Sampler(bitmap[0] as Texture, ParseFormat(bitmap.BitmapValues.Bitmaps[0].Format.Value),
                          bitmap.BitmapValues.Bitmaps[0].Width.Value, bitmap.BitmapValues.Bitmaps[0].Height.Value);
            Release(bitmap);
          }
          if (lightmap.Bitmap.Value >= 0)
            if (lightmaps != null)
              meshes[i][j].DefaultLightmap = lightmaps[lightmap.Bitmap.Value] as Texture;
          materials[i][j] = material.ToMaterial();
          Instance instance = new PartInstance(meshes[i][j], meshes[i][j].DefaultShader, Vertex.ComputeCentroid(meshes[i][j].Vertices), meshes[i][j].BoundingBox);
          instance.Transparent = meshes[i][j].DefaultShader.Transparent;
          instances.Add(instance);

          j++;
        }
        i++;
      }

      vis = this.scenarioStructureBspValues.ClusterData.Binary;
      visibleSurfaces = new int[scenarioStructureBspValues.Surfaces.Count];

      ambiences = new sound_looping[scenarioStructureBspValues.BackgroundSoundPalette.Count];
      for (int x = 0; x < ambiences.Length; x++)
        ambiences[x] = Open<sound_looping>(scenarioStructureBspValues.BackgroundSoundPalette[x].BackgroundSound.Value);

      subClusters = new BoundingBox[scenarioStructureBspValues.Clusters.Count][];
      for (int c = 0; c < scenarioStructureBspValues.Clusters.Count; c++)
      {
        subClusters[c] = new BoundingBox[scenarioStructureBspValues.Clusters[c].Subclusters.Count];
        for (int s = 0; s < scenarioStructureBspValues.Clusters[c].Subclusters.Count; s++)
        {
          subClusters[c][s] = new BoundingBox();
          subClusters[c][s].min[0] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsX.Lower;
          subClusters[c][s].min[1] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsY.Lower;
          subClusters[c][s].min[2] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsZ.Lower;
          subClusters[c][s].max[0] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsX.Upper;
          subClusters[c][s].max[1] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsY.Upper;
          subClusters[c][s].max[2] = scenarioStructureBspValues.Clusters[c].Subclusters[s].WorldBoundsZ.Upper;
        }
      }

      CacheUVConversionData();
    }

    bool[,] importanceMap = null;
    public bool[,] ImportanceMap { get { return importanceMap; } }
    int importanceMapIntersectCount;
    public WorldBounds CalculateRadiosityBounds(Vector3 lightDirection)
    {
      importanceMapIntersectCount = 0;
      int photonCount = 20000000;

      lightDirection *= -1f; // Reverse light direction;
      
      float upperZ = float.MinValue;
      foreach (EnhancedMesh[] lightmap in meshes)
        foreach (EnhancedMesh material in lightmap)
          for (int v = 0; v < material.VertexCount; v++)
            if (material.Vertices[v].position.Z > upperZ)
              upperZ = material.Vertices[v].position.Z;

      BoundingBox bb = new BoundingBox();
      Vector3 planeNormal = new Vector3(0, 0, -1);
      float d = -Vector3.Dot(planeNormal, new Vector3(1, 1, upperZ));

      Plane plane = new Plane(planeNormal.X, planeNormal.Y, planeNormal.Z, d);

      foreach (EnhancedMesh[] lightmap in meshes)      
        foreach (EnhancedMesh material in lightmap)
          foreach (Vertex vert in material.Vertices)
          {
            RadiosityIntersection intersect = Ray.IntersectRayOnPlane(new Ray(vert.position, lightDirection), plane);
            bb.Update(intersect.Position.X, intersect.Position.Y, intersect.Position.Z);
          }

      WorldBounds bounds = new WorldBounds(bb.Minimum, bb.Maximum);

      CreateImportanceMap( lightDirection, photonCount,  bounds);

      return bounds;
    }

    public bool[,] CreateImportanceMap( Vector3 lightDirection, int photonCount,  WorldBounds bounds)
    {
      bool[,] hiresMap;

      float width = bounds.X.Difference;
      float height = bounds.Y.Difference;
      float countRoot = (float)Math.Sqrt(photonCount);
      int countX = (int)Math.Ceiling((countRoot * height) / width);
      int countY = (int)Math.Ceiling((countRoot * width) / height);
      float distanceX = width / (float)countX;
      float distanceY = height / (float)countY;

      hiresMap = new bool[countX, countY];

      lightDirection *= -1; // back to original;
      float xPos, yPos;
      yPos = bounds.Y.Lower;
      for (int y = 0; y < countY; y++)
      {
        xPos = bounds.X.Lower;
        for (int x = 0; x < countX; x++)
        {
          RadiosityIntersection intersect = this.RadiosityIntersect(new Vector3(xPos, yPos, bounds.Z.Upper), lightDirection);
          // DeMorgan's Theorem FTW!
          hiresMap[x, y] = !(intersect.NoIntersection || intersect.WrongSide);
          if (hiresMap[x, y])
            importanceMapIntersectCount++;
          xPos += distanceX;
        }
        yPos += distanceY;
      }
      //importanceMap = hiresMap;
      return hiresMap;
    }

    public BaseTexture[] Lightmaps
    {
      get
      {
        if (lightmaps == null)
          return null;

        BaseTexture[] array = new BaseTexture[lightmaps.BitmapValues.Bitmaps.Count];
        for (int i = 0; i < array.Length; i++)
          array[i] = lightmaps[i];
        return array;
      }
    }
    public Sampler[] LightmapSamplers
    {
      get { return samplers; }
    }

    public void UpdateLightmap(int index, Texture lightmap)
    {
      if (index >= meshes.Length)
        return;
      for (int i = 0; i < meshes[index].Length; i++)
        meshes[index][i].DefaultLightmap = lightmap;
      for (int l = 0; l < shaders.Length; l++)
        for (int m = 0; m < shaders[l].Length; m++)
        {
          if (shaders[l][m] is shader_environment)
            (shaders[l][m] as shader_environment).Lightmap = lightmaps[scenarioStructureBspValues.Lightmaps2[l].Bitmap.Value] as Texture;
        }
    }

    /// <summary>
    /// Opens a shader generically.
    /// </summary>
    private shader OpenShader(string name, string type)
    {
      switch (type)
      {
        case "senv":
          return Open<shader_environment>(name);
        case "soso":
          return Open<shader_model>(name);
        case "sgla":
          return Open<shader_transparent_glass>(name);
        case "swat":
          return Open<shader_transparent_water>(name);
        case "schi":
          return Open<shader_transparent_chicago>(name);
        case "scex":
          return Open<shader_transparent_chicago_extended>(name);
        case "sotr":
          return Open<shader_transparent_generic>(name);
        case "smet":
          return Open<shader_transparent_meter>(name);
        case "spla":
          return Open<shader_transparent_plasma>(name);
        default:
          return null;
      }
    }

    /// <summary>
    /// Frees up any resources used by the bsp.
    /// </summary>
    public override void Dispose()
    {
      base.Dispose();
      Release(lightmaps);
      if (shaders != null)
        for (int i = 0; i < shaders.Length; i++)
          for (int j = 0; j < shaders[i].Length; j++)
            Release(shaders[i][j]);
      if (ambiences != null)
        for (int i = 0; i < ambiences.Length; i++)
          Release(ambiences[i]);
    }

    public bool RenderOnlyLightmap
    {
      get { return renderOnlyLightmap; }
      set
      {
        if (renderOnlyLightmap != value)
          for (int l = 0; l < shaders.Length; l++)
            for (int m = 0; m < shaders[l].Length; m++)
              if (shaders[l][m] is shader_environment)
                ;// (shaders[l][m] as shader_environment).DrawBaseMap = !value;
        renderOnlyLightmap = value;
      }
    }

    [Console("remder_lightmaps_only", "Renders only the lightmaps.")]
    void RenderOnlyLightmaps()
    {
      RenderOnlyLightmap = true;
    }
    [Console("render_everything", "Opposite of render_lightmaps_only. Renders everything.")]
    void RenderEverything()
    {
      RenderOnlyLightmap = false;
    }
    #region UVCaching
    
    /// <summary>
    /// This is the UV conversion cache.
    /// </summary>
    RadiosityHelper.UVConversionTable uvConversionCache;
    private void CacheUVConversionData()
    {
      /*uvConversionCache = new RadiosityHelper.UVConversionTable(lightmaps.BitmapValues.Bitmaps.Count);

      for (int l = 0; l < uvConversionCache.MapCount; l++)
        uvConversionCache[l] = RadiosityHelper.CacheUVConversionData(meshes[l], (int)(lightmaps.BitmapValues.Bitmaps[l].Width.Value * RadiosityHelper.LightmapScale), (int)(lightmaps.BitmapValues.Bitmaps[l].Height.Value * RadiosityHelper.LightmapScale));
     */
      uvConversionCache = CacheUVConversionDataPerMaterial();

      for (int l = 0; l < lightmaps.BitmapValues.Bitmaps.Count; l++)
      {
        Bitmap bmp = new Bitmap(uvConversionCache[l].Width, uvConversionCache[l].Height);

        for (int x = 0; x < uvConversionCache[l].Width; x++)
          for (int y = 0; y < uvConversionCache[l].Height; y++)
            if (uvConversionCache[l, x, y].Items.Count > 0)
              bmp.SetPixel(x, y, Color.White);
        //bmp.Save("k:\\convertcache_" + l + ".bmp");
      }
    }
    public bool LineIntersectionPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
      float denominator = ((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y));
      float ua = ((d.X - c.X) * (a.Y - c.Y)) - ((d.Y - c.Y) * (a.X - c.X)),
            ub = ((b.X - a.X) * (a.Y - c.Y)) - ((b.Y - c.Y) * (a.X - c.X));
      ua /= denominator; ub /= denominator;
      float x = a.X + (ua * (b.X - a.X)),
            y = a.Y + (ua * (b.Y - a.Y));
      return (ua > 0f) && (ua < 1) && (ub > 0) && (ub < 1);
    }
    public bool LineIntersectionPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out float ua, out float ub)
    {
      float denominator = ((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y));
      ua = ((d.X - c.X) * (a.Y - c.Y)) - ((d.Y - c.Y) * (a.X - c.X));
      ub = ((b.X - a.X) * (a.Y - c.Y)) - ((b.Y - c.Y) * (a.X - c.X));
      ua /= denominator; ub /= denominator;
      float x = a.X + (ua * (b.X - a.X)),
            y = a.Y + (ua * (b.Y - a.Y));
      return (ua > 0f) && (ua < 1) && (ub > 0) && (ub < 1);
    }
    public bool LineIntersection(Vector2[] linesA, Vector2[] linesB)
    {
      for (int x = 0; x < linesA.Length / 2; x++)
        for (int y = 0; y < linesB.Length / 2; y++)
        {
          if (LineIntersectionPoint(linesA[x * 2], linesA[x * 2 + 1], linesB[y * 2], linesB[y * 2 + 1]))
            return true;
        }
      return false;
    }
    public bool LineIntersection(Vector2[] linesA, Vector2[] linesB, out float ua, out float ub, out int A, out int B)
    {
      ua = float.MaxValue;
      ub = float.MinValue;
      B = 0;
      for (A = 0; A < linesA.Length / 2; A++)
        for (B = 0; B < linesB.Length / 2; B++)
        {
          if (LineIntersectionPoint(linesA[A * 2], linesA[A * 2 + 1], linesB[B * 2], linesB[B * 2 + 1], out ua, out ub))
            return true;
        }
      return false;
    }
    public Vector2 PointInTriangle(Vector2 i, Vector2 p0, Vector2 p1, Vector2 p2)
    {
      float u, v;
      Vector2 e0 = i - p0; //e0 = new Vector2(Math.Abs(e0.X), Math.Abs(e0.Y));
      Vector2 e1 = p1 - p0; //e1 = new Vector2(Math.Abs(e1.X), Math.Abs(e1.Y));
      Vector2 e2 = p2 - p0; //e2 = new Vector2(Math.Abs(e2.X), Math.Abs(e2.Y));
      if (e1.X == 0)
      {
        if (e2.X == 0)
          return Vector2.Empty;
        u = e0.X / e2.X;
        if ((u < 0) || (u > 1)) return Vector2.Empty;
        if (e1.Y == 0) return Vector2.Empty;
        v = (e0.Y - (e2.Y * u)) / e1.Y;
        if (v < 0) return Vector2.Empty;
      }
      else
      {
        float d = (e2.Y * e1.X) - (e2.X * e1.Y);
        if (d == 0) return Vector2.Empty;
        u = ((e0.Y * e1.X) - (e0.X * e1.Y)) / d;
        if ((u < 0) || (u > 1)) return Vector2.Empty;
        v = ((e0.X - (e2.X * u)) / e1.X);
        if (v < 0) return Vector2.Empty;
      }
      if (u + v > 1) return Vector2.Empty;
      return new Vector2(u, v);
    }
    #endregion

    public RadiosityIntersection RadiosityIntersect(Vector3 Origin, Vector3 Direction)
    {
      int lightmapElement, materialElement;
      Intersection _intersection = IntersectRay(Origin, Direction, true, out lightmapElement, out materialElement);
      if (_intersection == Intersection.None)
        return RadiosityIntersection.None; // there is no collision.

      // Get the vertices of the intersected triangle.
      Vertex[] vertices = meshes[lightmapElement][materialElement].Vertices;
      ushort[] indices = meshes[lightmapElement][materialElement].Indices;
      Vertex a = vertices[indices[_intersection.FaceIndex * 3]];
      Vertex b = vertices[indices[(_intersection.FaceIndex * 3) + 1]];
      Vertex c = vertices[indices[(_intersection.FaceIndex * 3) + 2]];

      StructureBspMaterialBlock material = scenarioStructureBspValues.Lightmaps2[lightmapElement].Materials[materialElement];

      // Use the helper class to process the intersection.
      RadiosityIntersection intersection = RadiosityHelper.ProcessIntersection(Direction, a, b, c, _intersection, bspSamplers[lightmapElement][materialElement], false);      

      intersection.Material = materials[lightmapElement][materialElement];
      intersection.MaterialIndex = materialElement;
      intersection.LightmapIndex = scenarioStructureBspValues.Lightmaps2[lightmapElement].Bitmap.Value;
      
      #region debug
      if (MdxRender.RenderDebug)
      {
        //debugPhotonCollisions.Add(new Vector3[] { Origin, intersection.Position });
        if (collisionPointsLocation >= collisionPoints.Length)
          collisionPointsLocation = 0;
        if (intersection.LightmapIndex >= 0)
          collisionPoints[collisionPointsLocation++] = new CustomVertex.PositionColored(intersection.Position.X, intersection.Position.Y, intersection.Position.Z, Color.CornflowerBlue.ToArgb());
      }
      #endregion

      return intersection;
    }

    #region compute point on triangle from UVs
    private static float ComputeTriangleArea(float a, float b, float c)
    {
      float s = a + b + c; s /= 2;
      return (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    private static Vector3 BaryCentric(float x0, float y0, float x1, float y1, float x2, float y2,
                                       float vx, float vy)
    {
      float a, b, c, totalArea, length0, length1, length2;
      a = Dist2D(x0, y0, x1, y1);
      b = Dist2D(x1, y1, x2, y2);
      c = Dist2D(x2, y2, x0, y0);
      totalArea = ComputeTriangleArea(a, b, c);
      length0 = Dist2D(x0, y0, vx, vy);
      length1 = Dist2D(x1, y1, vx, vy);
      length2 = Dist2D(x2, y2, vx, vy);

      float u = ComputeTriangleArea(b, length1, length2) / totalArea;
      float v = ComputeTriangleArea(c, length0, length2) / totalArea;
      float w = ComputeTriangleArea(a, length0, length1) / totalArea;
      return new Vector3(u, v, w);
    }
    private static float Dist2D(float x0, float y0, float x1, float y1)
    {
      x0 = x1 - x0;
      y0 = y1 - y0;
      float dist2d = (float)Math.Sqrt((x0*x0) + (y0 * y0));
      return (float)Math.Sqrt((x0 * x0) + (y0 * y0));
    }
    #endregion

    public Instance Instance
    {
      get
      {
        InstanceCollection newInstance = new InstanceCollection();

        /*foreach (Instance current in instances)
          newInstance.Add(current);*/

        ObjectInstance oi = new ObjectInstance(this, instances.Centroid, instances.BoundingBox);
        newInstance.Add(oi);
        newInstance.TargetType = TargetType.LevelMesh;

        return newInstance;
      }
    }

    #region IBsp Members

    public int LoadHeader(ref byte[] metadata)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

#if DEBUG
    public
#endif
 List<Vector3[]> debugPhotonCollisions = new List<Vector3[]>();
#if DEBUG
    public
#endif
 CustomVertex.PositionColored[] collisionPoints = new CustomVertex.PositionColored[200000];

    public int collisionPointsLocation = 0;

    #region IRenderable Members

    public void Render()
    {
      Microsoft.DirectX.Direct3D.Material material = new Microsoft.DirectX.Direct3D.Material();
      material.Ambient = Color.White;
      material.Diffuse = Color.White;
      MdxRender.Device.Material = material;

      //Update VIS and culling
      LocateActiveLeaf(MdxRender.Camera.Position, out activeLeafIndex, out activeClusterIndex);

      // For the time being this method is so insanely slow, it results in a 400% performance cut rendering bsps alone. Not worth the loss in my opinion. - Swamp
      //if (!MdxRender.bLockVis)
      //  BuildVisibleSurfaceList();

      #region Debug Radiosity stuff
#if DEBUG
      //for (int rayIndex = 0; rayIndex < debugPhotonCollisions.Count; rayIndex++)
      //  MdxRender.DrawDebugLine(debugPhotonCollisions[rayIndex][0], debugPhotonCollisions[rayIndex][1], Color.Pink);
      //MdxRender.DrawDebugLine(debugPhotonCollisions, Color.Pink);
      //if (collisionPointsLocation > 0)
      //  MdxRender.DrawPoints(collisionPoints, collisionPointsLocation);
#endif
      #endregion

      instances.Render();
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      int lightmapElement, materialElement;
      return IntersectRay(origin, direction, out lightmapElement, out materialElement);
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction, out int lightmapElement, out int materialElement)
    {
      lightmapElement = materialElement = -1;
      Intersection current = Intersection.None;
      Intersection closest = Intersection.None;

      for (int i = 0; i < meshes.Length; i++)
      {
        for (int j = 0; j < meshes[i].Length; j++)
        {
          if (meshes[i][j] != null)
          {

            current = meshes[i][j].IntersectRay(origin, direction);
            if (current != Intersection.None)
            {
              if (closest == Intersection.None)
              {
                closest = current;
                lightmapElement = i;
                materialElement = j;
              }
              else
              {
                if (current.Distance < closest.Distance)
                {
                  closest = current;
                  lightmapElement = i;
                  materialElement = j;
                }
              }
            }
          }
        }
      }

      return closest;
    }
    public Intersection IntersectRay(Vector3 origin, Vector3 direction, bool useTransparentSurfaces, out int lightmapElement, out int materialElement)
    {
      bool dontUseTS = !useTransparentSurfaces;
      lightmapElement = materialElement = -1;
      Intersection current = Intersection.None;
      Intersection closest = Intersection.None;

      for (int i = 0; i < meshes.Length; i++)
      {
        for (int j = 0; j < meshes[i].Length; j++)
        {
          if (meshes[i][j] != null)
          {
            if (shaders[i][j].Transparent && dontUseTS)
              continue;

            current = meshes[i][j].IntersectRay(origin, direction);
            if (current != Intersection.None)
            {
              if (closest == Intersection.None)
              {
                if (scenarioStructureBspValues.Lightmaps2[i].Bitmap.Value == -1)
                  continue;
                closest = current;
                lightmapElement = i;
                materialElement = j;
              }
              else
              {
                if (current.Distance < closest.Distance)
                {
                  if (scenarioStructureBspValues.Lightmaps2[i].Bitmap.Value == -1)
                    continue;
                  closest = current;
                  lightmapElement = i;
                  materialElement = j;
                }
              }
            }
          }
        }
      }

      return closest;
    }

    public Intersection IntersectRayOnCollisionBsp(Vector3 origin, Vector3 direction, out int bspIndex, out int surfaceIndex, out Vector3 new_dir)
    {
      Intersection closest = null;
      bspIndex = surfaceIndex = -1;
      new_dir = Vector3.Empty;
      direction.Normalize();
      foreach (BspBlock bsp in scenarioStructureBspValues.CollisionBsp)
      {
        foreach (SurfaceBlock surface in bsp.Surfaces)
        {
          // Self-explanatory
          Vector3 planeNormal = new Vector3(bsp.Planes[surface.Plane.Value].Plane.I, bsp.Planes[surface.Plane.Value].Plane.J, bsp.Planes[surface.Plane.Value].Plane.K);
          planeNormal.Normalize();

          float cosAlphaDirection = Vector3.Dot(planeNormal, direction);
          if (cosAlphaDirection > 0)
            continue; // the normal is facing the same direction as the ray-- these kind of collisions will probably be eliminated later.
          if (cosAlphaDirection == 0)
            continue; // the ray and plane are parallel.
          float vectorOrigin = -(Vector3.Dot(planeNormal, origin) + bsp.Planes[surface.Plane.Value].Plane.D);

          // Ray function: R(t) = R0 + Rd*t : t > 0
          float t = vectorOrigin / cosAlphaDirection;
          if (t < 0)
            continue; // wrong side of ray

          // Pi = [Xi Yi Zi] = [X0 + Xd * t, Y0 + Yd * t, Z0 + Zd * t]
          Vector3 intersectionPoint = Vector3.Add(origin, Vector3.Multiply(direction, t));

          // I don't understand the math behind this... but it works...
          new_dir = direction + (2 * planeNormal * -cosAlphaDirection);
          new_dir.Normalize();

          if (closest != null)
            if (closest.Distance < t)
              continue;

          IntersectInformation ii = new IntersectInformation();
          ii.Dist = t;
          ii.FaceIndex = surfaceIndex;
          // TODO: Find UV coordinates
          closest = new Intersection(ii, intersectionPoint);
        }
      }
      return closest;
    }

    public int PixelFillCount
    {
      get
      { return pixelCount; }
      set
      { pixelCount = value; }
    }

    public bool IntersectCamera(ICamera Camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane Plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    public Color GetAmbientLighting(float x, float y, float z, float radius, bool down)
    {
      if (lightmaps == null)
        return Color.White;

      short bitmapIndex, sampleIndex = 0;
      Vector2 lightingCoordinates;
      Color[] samples = new Color[5];

      lightingCoordinates = GetLightingCoordinates(x, y, z, down, out bitmapIndex);
      if (bitmapIndex >= 0)
        samples[sampleIndex++] = samplers[bitmapIndex].Sample(lightingCoordinates);
      lightingCoordinates = GetLightingCoordinates(x + radius, y, z, down, out bitmapIndex);
      if (bitmapIndex >= 0)
        samples[sampleIndex++] = samplers[bitmapIndex].Sample(lightingCoordinates);
      lightingCoordinates = GetLightingCoordinates(x - radius, y, z, down, out bitmapIndex);
      if (bitmapIndex >= 0)
        samples[sampleIndex++] = samplers[bitmapIndex].Sample(lightingCoordinates);
      lightingCoordinates = GetLightingCoordinates(x, y + radius, z, down, out bitmapIndex);
      if (bitmapIndex >= 0)
        samples[sampleIndex++] = samplers[bitmapIndex].Sample(lightingCoordinates);
      lightingCoordinates = GetLightingCoordinates(x, y - radius, z, down, out bitmapIndex);
      if (bitmapIndex >= 0)
        samples[sampleIndex++] = samplers[bitmapIndex].Sample(lightingCoordinates);

      if (sampleIndex == 0)
        return Color.White;

      Array.Resize<Color>(ref samples, sampleIndex);
      Color avg = AverageColor(samples);

      return avg;
    }

    private int ColorClamp(int value)
    {
      if (value > 255)
        value = 255;
      else if (value < 0)
        value = 0;
      return value;
    }

    private Vector2 GetLightingCoordinates(float x, float y, float z, bool down, out short bitmapIndex)
    {
      int lightmapElement, materialElement;
      Intersection intersection = IntersectRay(new Vector3(x, y, z), down ? new Vector3(0.0f, 0.0f, -1.0f) : new Vector3(1.0f, 0.0f, 0.0f), out lightmapElement, out materialElement);

      bitmapIndex = -1;
      if (intersection == Intersection.None)
        return Vector2.Empty;
      if ((bitmapIndex = scenarioStructureBspValues.Lightmaps2[lightmapElement].Bitmap.Value) < 0)
        return Vector2.Empty;

      Vertex[] vertices = meshes[lightmapElement][materialElement].Vertices;
      ushort[] indices = meshes[lightmapElement][materialElement].Indices;
      Vertex a = vertices[indices[intersection.FaceIndex * 3]];
      Vertex b = vertices[indices[intersection.FaceIndex * 3 + 1]];
      Vertex c = vertices[indices[intersection.FaceIndex * 3 + 2]];
      if (collisionPointsLocation >= collisionPoints.Length)
        collisionPointsLocation = 0;
      collisionPoints[collisionPointsLocation++] = new CustomVertex.PositionColored(intersection.Position.X, intersection.Position.Y, intersection.Position.Z, Color.White.ToArgb());
      if (collisionPointsLocation >= collisionPoints.Length)
        collisionPointsLocation = 0;
      Vector2 uvs = Vector2.BaryCentric(new Vector2(a.u2, a.v2), new Vector2(b.u2, b.v2), new Vector2(c.u2, c.v2), intersection.U, intersection.V);
      //  samplers[bitmapIndex].Write(Color.Pink, uvs.X, uvs.Y);
      return uvs;
    }

    private Color AverageColor(params Color[] colors)
    {
      int r = 0, g = 0, b = 0, a = 0;

      for (int i = 0; i < colors.Length; i++)
      {
        r += colors[i].R;
        g += colors[i].G;
        b += colors[i].B;
        a += colors[i].A;
      }

      r /= colors.Length;
      g /= colors.Length;
      b /= colors.Length;
      a /= colors.Length;

      return Color.FromArgb(a, r, g, b);
    }

    #region VIS
    protected void BuildVisibleSurfaceList()
    {
      if (activeClusterIndex == -1)
      {
        for (int s_index = 0; s_index < this.scenarioStructureBspValues.Surfaces.Count; s_index++)
        {
          //0 = draw, any other value = don't draw
          visibleSurfaces[s_index] = 0;
        }
      }
      else
      {
        //Build Visible Surface List
        // Do not comment this out!.. The way you have 'doDraw' set up does not allow you to do so! - Swamp
        for (int vs = 0; vs < visibleSurfaces.Length; vs++)
        {
          //0 = draw, any other value = don't draw
          visibleSurfaces[vs] = 1;
        }

        List<StructureBspClusterBlock> clusters = scenarioStructureBspValues.Clusters;
        for (int c = 0; c < clusters.Count; c++)
        {
          if (IsClusterVisible(activeClusterIndex, c))
          {
            int skippedCount = 0;
            //perform frustum culling
            for (int s = 0; s < clusters[c].Subclusters.Count; s++)
            {
              int doDraw = 1;
              if (MdxRender.Camera.VisibleBoundingBox(subClusters[c][s]))
                doDraw = 0;

              List<StructureBspSubclusterSurfaceIndexBlock> si = clusters[c].Subclusters[s].SurfaceIndices;
              for (int x = 0; x < si.Count; x++)
              {
                //0 = draw, any other value = don't draw
                visibleSurfaces[si[x].Index.Value] = doDraw;
              }
            }
          }
        }
      }

      //update draw list for lightmap/materials
      for (int l = 0; l < scenarioStructureBspValues.Lightmaps2.Count; l++)
      {
        StructureBspLightmapBlock lightmap = scenarioStructureBspValues.Lightmaps2[l];
        for (int m = 0; m < lightmap.Materials.Count; m++)
        {
          StructureBspMaterialBlock material = lightmap.Materials[m];

          meshes[l][m].UpdateAttributeBuffer(visibleSurfaces,
            material.Surfaces.Value, material.SurfaceCount.Value);
        }
      }
    }

    /// <summary>
    /// Access the correct bit in the VIS data and determine if that cluster is visible or not.
    /// </summary>
    /// <param name="activeCluster">cluster the camera is currently located in</param>
    /// <param name="testCluster">cluster to test</param>
    /// <returns>true if the cluster is visible</returns>
    protected bool IsClusterVisible(int activeCluster, int testCluster)
    {
      int blockSize = (int)Math.Ceiling((float)scenarioStructureBspValues.Clusters.Count / 32.0f) * 4;
      int offset = testCluster / 8;
      int bit = testCluster % 8;
      byte testByte = scenarioStructureBspValues.ClusterData.Binary[blockSize * activeCluster + offset];
      //      int offset = activeCluster / 8;
      //      int bit = activeCluster % 8;
      //      byte testByte = scenarioStructureBspValues.ClusterData.Binary[blockSize * testCluster + offset];
      testByte >>= bit;
      testByte &= 0x1;

      return (testByte == 0x1);
    }

    protected void LocateActiveCluster(Vector3 cameraLocation)
    {
      StructureBspClusterBlock cb;
      StructureBspSubclusterBlock scb;
      bool bXInside, bYInside, bZInside;
      bool bExit = false;

      activeClusterIndex = -1;
      if (true)//activeClusterIndex == -1)
      {
        //are we inside bsp bounding box
        bXInside = this.scenarioStructureBspValues.WorldBoundsX.Inbounds(cameraLocation.X);
        bYInside = this.scenarioStructureBspValues.WorldBoundsY.Inbounds(cameraLocation.Y);
        bZInside = this.scenarioStructureBspValues.WorldBoundsZ.Inbounds(cameraLocation.Z);

        if (bXInside && bYInside && bZInside)
        {
          //do cluster bounding box search
          int clusterCount = this.scenarioStructureBspValues.Clusters.Count;
          for (int c = 0; ((c < clusterCount) && (bExit == false)); c++)
          {
            cb = scenarioStructureBspValues.Clusters[c];
            for (int s = 0; ((s < cb.Subclusters.BlockCount) && (bExit == false)); s++)
            {
              scb = cb.Subclusters[s];
              bXInside = scb.WorldBoundsX.Inbounds(cameraLocation.X);
              bYInside = scb.WorldBoundsY.Inbounds(cameraLocation.Y);
              bZInside = scb.WorldBoundsZ.Inbounds(cameraLocation.Z);

              if (bXInside && bYInside && bZInside)
              {
                //Trace.WriteLine("actual active cluster = " + c.ToString());
                activeClusterIndex = c;
                //activeSubClusterIndex = s;
                //bExit = true;
              }
            }
          }
        }
      }
      if (activeClusterIndex != -1)
      //else
      {
        int portalIndex;
        int debugClusterIndex;
        StructureBspClusterBlock activeCluster = this.scenarioStructureBspValues.Clusters[activeClusterIndex];
        //do portal test to see if we've moved into a new cluster
        for (int p = 0; p < activeCluster.Portals.BlockCount; p++)
        {
          portalIndex = activeCluster.Portals[p].Portal.Value;
          StructureBspClusterPortalBlock portal = this.scenarioStructureBspValues.ClusterPortals[portalIndex];

          if (InFrontOfPlane(cameraLocation, portal.PlaneIndex.Value) == true)
          {
            //we left the cluster
            if (portal.FrontCluster.Value == this.activeClusterIndex)
              debugClusterIndex = portal.BackCluster.Value;
            else
              debugClusterIndex = portal.FrontCluster.Value;
            //            Trace.WriteLine("changed!  predicted cluster index = " + debugClusterIndex.ToString());
          }
        }
      }
    }

    protected void LocateActiveLeaf(Vector3 pt, out int activeLeaf, out int activeCluster)
    {
      //StructureBspNodeBlock currentNode = scenarioStructureBspValues.Nodes[0];
      List<Bsp3dnodeBlock> Nodes = this.scenarioStructureBspValues.CollisionBsp[0].Bsp3dNodes;
      List<PlaneBlock> Planes = this.scenarioStructureBspValues.CollisionBsp[0].Planes;
      List<LeafBlock> Leaves = this.scenarioStructureBspValues.CollisionBsp[0].Leaves;

      //currentNode
      int activeNode = 0;
      RealPlane3D activePlane = null;
      float loc = 0;
      bool isLeaf = false;
      bool isNull = false;

      do
      {
        activePlane = Planes[Nodes[activeNode].Plane.Value].Plane;
        loc = activePlane.I * pt.X + activePlane.J * pt.Y + activePlane.K * pt.Z - activePlane.D;

        if (loc > 0)
        {
          activeNode = Nodes[activeNode].FrontChild.Value;
        }
        else
        {
          activeNode = Nodes[activeNode].BackChild.Value;
        }

        isLeaf = (0xFF000000 & activeNode) == 0x80000000;
        isNull = activeNode == -1;
        activeNode &= 0x00ffffff;

      } while ((isLeaf == false) && (isNull == false));

      activeLeaf = activeNode;

      if (activeLeaf != 0xFFFFFF)
        activeCluster = this.scenarioStructureBspValues.Leaves[activeLeaf].Cluster.Value;
      else
        activeCluster = -1;
    }

    protected void RenderCluster(int index)
    {
      StructureBspClusterBlock cb;
      StructureBspSubclusterBlock scb;
      Vector3 v1 = new Vector3();
      Vector3 v2 = new Vector3();

      if ((index != -1) && (index < scenarioStructureBspValues.Clusters.Count))
      {
        cb = scenarioStructureBspValues.Clusters[index];
        //draw sub-cluster bounding boxes
        for (int s = 0; s < cb.Subclusters.BlockCount; s++)
        {
          scb = cb.Subclusters[s];
          v1.X = scb.WorldBoundsX.Lower;
          v2.X = scb.WorldBoundsX.Upper;
          v1.Y = scb.WorldBoundsY.Lower;
          v2.Y = scb.WorldBoundsY.Upper;
          v1.Z = scb.WorldBoundsZ.Lower;
          v2.Z = scb.WorldBoundsZ.Upper;
          BoundingBox bb = new BoundingBox();
          bb.SetBounds(v1, v2);
          bb.RenderBoundingBox();
        }
      }
    }

    protected void RenderPortal(int index)
    {
      MdxRender.Device.RenderState.CullMode = Cull.None;
      StructureBspClusterPortalBlock portal;

      if ((index > -1) && (index < scenarioStructureBspValues.ClusterPortals.Count))
      {
        portal = scenarioStructureBspValues.ClusterPortals[index];

        CustomVertex.PositionColored[] verts = new CustomVertex.PositionColored[portal.Vertices.Count + 1];
        for (int v = 0; v < portal.Vertices.Count; v++)
        {
          verts[v].X = portal.Vertices[v].Point.X;
          verts[v].Y = portal.Vertices[v].Point.Y;
          verts[v].Z = portal.Vertices[v].Point.Z;
          verts[v].Color = Color.Green.ToArgb();
        }
        verts[portal.Vertices.Count] = verts[0];
        MdxRender.Device.DrawUserPrimitives(PrimitiveType.TriangleFan, verts.Length - 2, verts);
        //GrenDebugger.ClusterBB.BoxColor = Color.Blue;
        RenderCluster(portal.FrontCluster.Value);
        //GrenDebugger.ClusterBB.BoxColor = Color.Red;
        RenderCluster(portal.BackCluster.Value);
        //GrenDebugger.ClusterBB.BoxColor = Color.White;
      }
      MdxRender.Device.RenderState.CullMode = Cull.CounterClockwise;
    }

    protected bool InFrontOfPlane(Vector3 point, int planeIndex)
    {
      RealPlane3D plane = this.scenarioStructureBspValues.CollisionBsp[0].Planes[planeIndex].Plane;

      float val = plane.I * point.X + plane.J * point.Y + plane.K * point.Z;

      return (val > plane.D);
    }
    #endregion

    public int GetVisibilityID(float x, float y, float z)
    {
      int leaf, cluster;
      LocateActiveLeaf(new Vector3(x, y, z), out leaf, out cluster);
      return cluster;
    }

    public bool PointIsVisibleFrom(int id, float x, float y, float z)
    {
      if (id < 0)
        return true;
      int newID = GetVisibilityID(x, y, z);
      if (newID < 0)
        return true;
      return IsClusterVisible(id, newID);
    }

    public bool IDIsVisibleFrom(int idA, int idB)
    {
      if (idA < 0 || idB < 0)
        return true;
      else
        return IsClusterVisible(idA, idB);
    }

    public int CameraID
    {
      get
      { return activeClusterIndex; }
    }

    public int ActiveSkyIndex
    {
      get
      {
        if (activeClusterIndex < 0)
          return -1;
        return scenarioStructureBspValues.Clusters[activeClusterIndex].Sky.Value;
      }
    }

    /// <summary>
    /// Parses the format field in a Halo bitmap.
    /// </summary>
    /// <param name="haloType">halo format</param>
    /// <returns>DirectX format for generic texture loader</returns>
    protected static Format ParseFormat(short haloType)
    {
      switch (haloType)
      {
        case 0x0:
          return Format.A8;
        case 0x1:
          return Format.L8;
        case 0x2:
          return Format.A4L4;
        case 0x3:
          return Format.A8L8;
        case 0x6:
          return Format.R5G6B5;
        case 0x8:
          return Format.A1R5G5B5;
        case 0x9:
          return Format.A4R4G4B4;
        case 0xA:
          return Format.X8R8G8B8;
        case 0xB:
          return Format.A8R8G8B8;
        case 0xE:
          return Format.Dxt1;
        case 0xF:
          return Format.Dxt3;
        case 0x10:
          return Format.Dxt4;
        case 0x11:
          return Format.P8;
        default:
          throw new ArgumentException("Tried to parse an invalid bitmap format of 0x" + Convert.ToString(haloType, 16) + '.', "haloType");
      }
    }

    #region IBsp Members

    // World Bounds
    WorldBounds worldBounds = WorldBounds.None;
    WorldBounds bspBounds;
    public WorldBounds WorldBounds
    {
      get
      {
        if (worldBounds != WorldBounds.None) return worldBounds;
        else return bspBounds;
      }
      set { worldBounds = value; }
    }
    public WorldBounds CalculateWorldBounds(Vector3 lightDirection)
    {
      Vector3 planeNormal = new Vector3(0, 0, -1);
      float d = Vector3.Dot(planeNormal, new Vector3(scenarioStructureBspValues.WorldBoundsX.Lower + 1, scenarioStructureBspValues.WorldBoundsY.Lower + 1, scenarioStructureBspValues.WorldBoundsZ.Upper)), t, cosAlpha;

      WorldBounds world = new WorldBounds(new Vector3(0, 0, 0), new Vector3(0, 0, 0));

      foreach (EnhancedMesh[] lightmap in meshes)
        foreach (EnhancedMesh mesh in lightmap)
        {
          Vertex[] v = mesh.Vertices;
          for (int x = 0; x < v.Length; x++)
          {
            world &= Ray.ComputeIntersectionPoint(v[x].position, lightDirection, planeNormal, d, out t, out cosAlpha);
          }
        }
      world &= bspBounds;
      //CreateImportanceMap(lightDirection, 20000000, world);
      return world;
    }

    #endregion

    
    #region IBsp Members
    public RadiosityHelper.UVConversionTable CacheUVConversionDataPerMaterial()
    {
      RadiosityHelper.UVConversionTable table = new RadiosityHelper.UVConversionTable(scenarioStructureBspValues.Lightmaps2.Count);
      int l = 0;
      #region Per lightmap
      foreach (var lightmap in this.scenarioStructureBspValues.Lightmaps2)
      {
        if (l >= lightmaps.BitmapValues.Bitmaps.Count)
          break;
        var surfaceData = (lightmaps[l] as Texture).GetLevelDescription(0);
        int width = (int)(surfaceData.Width * RadiosityHelper.LightmapScale); width--;
        float widthF = (float)width;
        int height = (int)(surfaceData.Height * RadiosityHelper.LightmapScale); height--;
        float heightF = (float)height;
        RadiosityHelper.UVConversionMap map = new RadiosityHelper.UVConversionMap(width+1, height+1);

        #region Per Material
        int m = 0;
        foreach (var material in lightmap._materialsList)
        {
          float left = float.MaxValue, right = float.MinValue, top = float.MaxValue, bottom = float.MinValue;
          int end = material.Surfaces.Value + material.SurfaceCount.Value;
          Vertex[] verts;

          #region we're going to compile all the vertices in the same structure for now. While we're at it, we're going to find the left, right, top, bottom stuff.
          verts = new Vertex[material.SurfaceCount * 3];
          for (int s = 0; s < material.SurfaceCount.Value; s++)
          {
            var surface = scenarioStructureBspValues.Surfaces[s + material.Surfaces.Value];
            verts[s * 3] = meshes[l][m].Vertices[surface.Tria];
            verts[s * 3 + 1] = meshes[l][m].Vertices[surface.Trib];
            verts[s * 3 + 2] = meshes[l][m].Vertices[surface.Tric];
          }
          for (int x = 0; x < verts.Length; x++)
          {
            if (verts[x].u2 < left)
              left = verts[x].u2;
            if (verts[x].u2 > right)
              right = verts[x].u2;
            if (verts[x].v2 < top)
              top = verts[x].v2;
            if (verts[x].v2 > bottom)
              bottom = verts[x].v2;
          }
          #endregion

          for (int s = 0; s < material.SurfaceCount; s++)
          {
            RadiosityHelper.UVConversionCacheItem cacheItem = new RadiosityHelper.UVConversionCacheItem(m, s);

            int index = s * 3;
            float faceLeft = float.MaxValue, faceRight = float.MinValue,
              faceTop = float.MaxValue, faceBottom = float.MinValue;

            #region compute the face rectangle
            for (int q = 0; q < 3; q++)
            {
              int t = index + q;
              if (verts[t].u2 < faceLeft)
                faceLeft = verts[t].u2;
              if (verts[t].u2 > faceRight)
                faceRight = verts[t].u2;
              if (verts[t].v2 < faceTop)
                faceTop = verts[t].v2;
              if (verts[t].v2 > faceBottom)
                faceBottom = verts[t].v2;
            }
            #endregion

            int pLeft = (int)Math.Floor(faceLeft * widthF),
                pRight = (int)Math.Ceiling(faceRight * widthF),
                pTop = (int)Math.Floor(faceTop * heightF),
                pBottom = (int)Math.Ceiling(faceBottom * heightF);
            int oLeft = pLeft;
            int oRight = pRight;
            int oTop = pTop;
            int oBottom = pBottom;
            //pLeft = 0;
            //pRight = width;
            //pTop = 0;
            //pBottom = height;

            if (pLeft == pRight)
              if (pTop == pBottom)
              {
                map[pLeft, pTop].Items.Add(cacheItem);
              }

            Vector2 a = new Vector2(verts[index].u2, verts[index].v2);
            Vector2 b = new Vector2(verts[index + 1].u2, verts[index + 1].v2);
            Vector2 c = new Vector2(verts[index + 2].u2, verts[index + 2].v2);

            for (int y = pTop; y <= pBottom; y++)
              for (int x = pLeft; x <= pRight; x++)
              {
                if (RadiosityHelper.PointInTriangle(new Vector2((float)x / widthF, (float)y / heightF), a, b, c) != Vector2.Empty)
                {
                  if ((x < oLeft) || (x > oRight) || (y < oTop) || (y > oBottom))
                    if (System.Diagnostics.Debugger.IsAttached)
                      System.Diagnostics.Debugger.Break();
                  map[x, y].Items.Add(cacheItem);
                }
                else
                {
                  float dist = PointToTriangle2(a, b, c, new Vector2((float)x / widthF, (float)y / heightF));
                  map[x, y].TryAdd(cacheItem, dist);
                }
              }
          }

          m++;
        }
        table[l] = map;
        #endregion
        l++;
      }
      #endregion
      return table;
    }

    public Vector3 GetFaceNormal(int lightmapIndex, int materialIndex, int face)
    {
      if ((lightmapIndex < 0) || (materialIndex < 0))
        return Vector3.Empty;
      if (lightmapIndex >= meshes.Length)
        return Vector3.Empty;
      if (materialIndex >= meshes[lightmapIndex].Length)
        return Vector3.Empty;
      EnhancedMesh mesh = meshes[lightmapIndex][materialIndex];
      int f = face * 3;
      Vector3 normal =  RadiosityHelper.ComputeTriangleNormal(mesh.Vertices[mesh.Indices[f]],
          mesh.Vertices[mesh.Indices[f + 1]], 
          mesh.Vertices[mesh.Indices[f + 2]]);
      if (shaders[lightmapIndex][materialIndex] != null)
        if (shaders[lightmapIndex][materialIndex].Transparent)
          normal *= -1f;
      return normal;
    }
    public Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, float threshold2, out Vector3 normal)
    {
      normal = Vector3.Empty;
      if (lightmapIndex >= uvConversionCache.MapCount)
        return Vector3.Empty;
      if (lightmapIndex < 0)
        return Vector3.Empty;

      SurfaceDescription desc = (lightmaps[lightmapIndex] as Texture).GetLevelDescription(0);

      float fx = UV.X * (float)desc.Width * 4f;
      float fy = UV.Y * (float)desc.Height * 4f;
      int x = (int)Math.Round(fx), y = (int)Math.Round(fy);
      if (lightmapIndex == 8)
        if (x == 42)
          if (y == 53)
            //System.Diagnostics.Debugger.Break();
            x = x;
      UV = new Vector2((float)x / ((float)desc.Width * 4f), (float)y / ((float)desc.Height * 4f));

    label:
      RadiosityHelper.UVConversionCacheItem reference;
      Vector3 result;
      while (true)
      {
        reference = ClosestMatch(uvConversionCache[lightmapIndex, x, y].Items, new Vector2((float)x / ((float)desc.Width * 4f), (float)y / ((float)desc.Height * 4f)), lightmapIndex, desc);

        if (reference == null)
        {
          normal = Vector3.Empty; // use a sphere
          return uvConversionCache[lightmapIndex, x, y].ClosestVertex.position;
        }
        materialIndex = reference.materialIndex;
        int v1 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3];
        int v2 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 1];
        int v3 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 2];

        Vertex a = meshes[lightmapIndex][materialIndex].Vertices[v1];
        Vertex b = meshes[lightmapIndex][materialIndex].Vertices[v2];
        Vertex c = meshes[lightmapIndex][materialIndex].Vertices[v3];

        normal = RadiosityHelper.ComputeTriangleNormal(a, b, c);
        normal.Normalize();

        if (reference.InTriangle)
          result = ComputeLocationOnTriangle(a, b, c, UV);
        else
          result = ComputeLocationOnTriangle(a, b, c, reference.collisionPoint);
        return result;
      }
      return Vector3.Empty;
    }
    public Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, out RadiosityMaterial material, out Vector3 normal)
    {
      SurfaceDescription desc = (lightmaps[lightmapIndex] as Texture).GetLevelDescription(0);
      float widthF = (float)(desc.Width) * RadiosityHelper.LightmapScale; widthF -= 1f;
      float heightF = (float)(desc.Height) * RadiosityHelper.LightmapScale; heightF -= 1f;
      float fx = UV.X * widthF;
      float fy = UV.Y * heightF;

      int x = (int)Math.Round(fx), y = (int)Math.Round(fy);

      return ConvertUVTo3D(x, y, lightmapIndex, materialIndex, out material, out normal);

      UV = new Vector2((float)x / widthF, (float)y / heightF);

      if (uvConversionCache[lightmapIndex, x, y].Items.Count > 0)
      {
        List<RadiosityHelper.UVConversionCacheItem> items = new List<RadiosityHelper.UVConversionCacheItem>();
        foreach (var item in uvConversionCache[lightmapIndex, x, y].Items)
          if (item.materialIndex == materialIndex)
            items.Add(item);
        RadiosityHelper.UVConversionCacheItem result = null;
        if (items.Count == 1)
          result = items[0];
        else if (items.Count == 0)
        {
          var closest = uvConversionCache[lightmapIndex, x, y].FindClosestFace(materialIndex);
          if (closest != null)
            result = new RadiosityHelper.UVConversionCacheItem(closest.Material, closest.Face);
          else
          {
            normal = Vector3.Empty;
            material = null;
            return Vector3.Empty;
          }
          Vertex v = meshes[lightmapIndex][materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tria];
          UV = new Vector2(v.u2, v.v2);
        }
        else
        {
          // There should never be more than one potential result.
          if (System.Diagnostics.Debugger.IsAttached)
            System.Diagnostics.Debugger.Break();
        }

        Vertex v1 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tria];
        Vertex v2 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Trib];
        Vertex v3 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tric];

        normal = GetFaceNormal(lightmapIndex, result.materialIndex, result.faceIndex);
        material = materials[lightmapIndex][result.materialIndex];

        return RadiosityHelper.ComputeLocationOnTriangle(v1, v2, v3, UV);
      }
      else
      {
        var closest = uvConversionCache[lightmapIndex, x, y].FindClosestFace(materialIndex);
        RadiosityHelper.UVConversionCacheItem result;
        if (closest != null)
          result = new RadiosityHelper.UVConversionCacheItem(closest.Material, closest.Face);
        else
        {
          normal = Vector3.Empty;
          material = null;
          return Vector3.Empty;
        }
        Vertex v = meshes[lightmapIndex][materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tria];
        UV = new Vector2(v.u2, v.v2);

        Vertex v1 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tria];
        Vertex v2 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Trib];
        Vertex v3 = meshes[lightmapIndex][result.materialIndex].Vertices[scenarioStructureBspValues.Surfaces[result.faceIndex].Tric];

        normal = GetFaceNormal(lightmapIndex, result.materialIndex, result.faceIndex);
        material = materials[lightmapIndex][result.materialIndex];

        return RadiosityHelper.ComputeLocationOnTriangle(v1, v2, v3, UV);
      }
    }
    public Vector3 ConvertUVTo3D(int x, int y, int lightmapIndex, int materialIndex, out RadiosityMaterial material, out Vector3 normal)
    {
      SurfaceDescription desc = (lightmaps[lightmapIndex] as Texture).GetLevelDescription(0);
      float widthF = (float)(desc.Width) * RadiosityHelper.LightmapScale; widthF -= 1f;
      float heightF = (float)(desc.Height) * RadiosityHelper.LightmapScale; heightF -= 1f;

      Vector2 UV = new Vector2((float)x / widthF, (float)y / heightF);

      if (uvConversionCache[lightmapIndex, x, y].Items.Count > 0)
      {
        List<RadiosityHelper.UVConversionCacheItem> items = new List<RadiosityHelper.UVConversionCacheItem>();
        foreach (var item in uvConversionCache[lightmapIndex, x, y].Items)
          if (item.materialIndex == materialIndex)
            items.Add(item);
        RadiosityHelper.UVConversionCacheItem result = null;
        if (items.Count == 1)
          result = items[0];
        else if (items.Count == 0)
        {
          var closest = uvConversionCache[lightmapIndex, x, y].FindClosestFace(materialIndex);
          if (closest != null)
            result = new RadiosityHelper.UVConversionCacheItem(closest.Material, closest.Face);//result = new RadiosityHelper.UVConversionCacheItem(uvConversionCache[lightmapIndex, x, y].ClosestMaterial, uvConversionCache[lightmapIndex, x, y].ClosestFace);
          else
          {
            normal = Vector3.Empty;
            material = null;
            return Vector3.Empty;
          }
          Vertex v = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex*3]];
          UV = new Vector2(v.u2, v.v2);
        }
        else
        {
          // There should never be more than one potential result.
          //if (System.Diagnostics.Debugger.IsAttached)
          //  System.Diagnostics.Debugger.Break();
          result = items[0];
        }

        Vertex v1 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex * 3]];
        Vertex v2 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex * 3+1]];
        Vertex v3 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex * 3+2]];

        normal = GetFaceNormal(lightmapIndex, result.materialIndex, result.faceIndex);
        material = materials[lightmapIndex][result.materialIndex];

        return RadiosityHelper.ComputeLocationOnTriangle(v1, v2, v3, UV);
      }
      else
      {
        var closest = uvConversionCache[lightmapIndex, x, y].FindClosestFace(materialIndex);
        RadiosityHelper.UVConversionCacheItem result;
        if (closest != null)
          result = new RadiosityHelper.UVConversionCacheItem(closest.Material, closest.Face);
        else
        {
          normal = Vector3.Empty;
          material = null;
          return Vector3.Empty;
        }
        Vertex v = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex*3]];
        UV = new Vector2(v.u2, v.v2);

        Vertex v1 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex*3]];
        Vertex v2 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex*3+1]];
        Vertex v3 = meshes[lightmapIndex][result.materialIndex].Vertices[meshes[lightmapIndex][result.materialIndex].Indices[result.faceIndex*3+2]];

        normal = GetFaceNormal(lightmapIndex, result.materialIndex, result.faceIndex);
        material = materials[lightmapIndex][result.materialIndex];

        return RadiosityHelper.ComputeLocationOnTriangle(v1, v2, v3, UV);
      }
    }
    /*public Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, out RadiosityMaterial material, out Vector3 normal)
    {
      material = materials[lightmapIndex][0];
      material.Index = 0;
      normal = Vector3.Empty;
      if (lightmapIndex >= uvConversionCache.MapCount)
        return Vector3.Empty;
      if (lightmapIndex < 0)
        return Vector3.Empty;

      SurfaceDescription desc = (lightmaps[lightmapIndex] as Texture).GetLevelDescription(0);

      float fx = UV.X * (float)desc.Width * RadiosityHelper.LightmapScale;
      float fy = UV.Y * (float)desc.Height * RadiosityHelper.LightmapScale;
      int x = (int)Math.Round(fx), y = (int)Math.Round(fy);
      if (lightmapIndex == 8)
        if (x == 42)
          if (y == 53)
            //System.Diagnostics.Debugger.Break();
            x = x;
      UV = new Vector2((float)x / ((float)desc.Width * RadiosityHelper.LightmapScale), (float)y / ((float)desc.Height * RadiosityHelper.LightmapScale));

      RadiosityHelper.UVConversionCacheItem reference;
      Vector3 result;
      while (true)
      {
        reference = ClosestMatch(uvConversionCache[lightmapIndex, x, y].Items, new Vector2((float)x / ((float)desc.Width * RadiosityHelper.LightmapScale), (float)y / ((float)desc.Height * RadiosityHelper.LightmapScale)), lightmapIndex, desc);

        if (reference == null)
        {
          normal = Vector3.Empty; // use a sphere
          material = materials[lightmapIndex][0];
          return uvConversionCache[lightmapIndex, x, y].ClosestVertex.position;
        }
        materialIndex = reference.materialIndex;
        int v1 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3];
        int v2 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 1];
        int v3 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 2];

        Vertex a = meshes[lightmapIndex][materialIndex].Vertices[v1];
        Vertex b = meshes[lightmapIndex][materialIndex].Vertices[v2];
        Vertex c = meshes[lightmapIndex][materialIndex].Vertices[v3];

        normal = RadiosityHelper.ComputeTriangleNormal(a, b, c);
        normal.Normalize();

        if (reference.InTriangle)
          result = ComputeLocationOnTriangle(a, b, c, UV);
        else
          result = ComputeLocationOnTriangle(a, b, c, reference.collisionPoint);
        material = materials[lightmapIndex][materialIndex];
        material.Index = materialIndex;
        return result;
      }
      return Vector3.Empty;
    }*/
    public Vector3 ConvertUVTo3D(Vector2 UV, int lightmapIndex, int materialIndex, float threshold2, Vector2 allowableRadius)
    {
      if (lightmapIndex >= uvConversionCache.MapCount)
        return Vector3.Empty;
      if (lightmapIndex < 0)
        return Vector3.Empty;

      SurfaceDescription desc = (lightmaps[lightmapIndex] as Texture).GetLevelDescription(0);

      float fx = UV.X * (float)desc.Width * RadiosityHelper.LightmapScale;
      float fy = UV.Y * (float)desc.Height * RadiosityHelper.LightmapScale;
      int x = (int)Math.Round(fx), y = (int)Math.Round(fy);
      if (lightmapIndex == 8)
        if (x == 42)
          if (y == 53)
            //System.Diagnostics.Debugger.Break();
            x = x;
      UV = new Vector2((float)x / ((float)desc.Width * RadiosityHelper.LightmapScale), (float)y / ((float)desc.Height * RadiosityHelper.LightmapScale));

    label:
      RadiosityHelper.UVConversionCacheItem reference;
      Vector3 result;
      while (true)
      {
        reference = ClosestMatch(uvConversionCache[lightmapIndex, x, y].Items, new Vector2((float)x / ((float)desc.Width * RadiosityHelper.LightmapScale), (float)y / ((float)desc.Height * RadiosityHelper.LightmapScale)), lightmapIndex, desc);

        if (reference == null)
        {
          return uvConversionCache[lightmapIndex, x, y].ClosestVertex.position;
        }
        materialIndex = reference.materialIndex;
        int v1 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3];
        int v2 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 1];
        int v3 = meshes[lightmapIndex][materialIndex].Indices[reference.faceIndex * 3 + 2];

        Vertex a = meshes[lightmapIndex][materialIndex].Vertices[v1];
        Vertex b = meshes[lightmapIndex][materialIndex].Vertices[v2];
        Vertex c = meshes[lightmapIndex][materialIndex].Vertices[v3];

        if (reference.InTriangle)
          result = ComputeLocationOnTriangle(a, b, c, UV);
        else
          result = ComputeLocationOnTriangle(a, b, c, reference.collisionPoint);
        //if (PointInTriangle2(result, a.position, b.position, c.position))
        return result;
        //else uvConversionCache[lightmapIndex][x][y].Items.Remove(reference);
      }
      return Vector3.Empty;
    }
    public EnhancedMesh[] GetMeshes(int lightmapIndex)
    {
      return meshes[lightmapIndex];
    }
    Vector3 ComputeLocationOnTriangle(Vertex v1, Vertex v2, Vertex v3, Vector2 UV)
    {
      Vector2 a = new Vector2(v1.u2, v1.v2);
      Vector2 b = new Vector2(v2.u2, v2.v2);
      Vector2 c = new Vector2(v3.u2, v3.v2);

      Vector3 t = v1.position;
      Vector3 u = v2.position;
      Vector3 v = v3.position;

      Vector3 f = BaryCentric(a.X, a.Y, b.X, b.Y, c.X, c.Y, UV.X, UV.Y);

      //result[0] := v1[0] * f1 +   v2[0] * f2 +   v3[0] * f3;
      //    result[1] := v1[1] * f1 +   v2[1] * f2 +   v3[1] * f3;
      //    result[2] := v1[2] * f1 +   v2[2] * f2 +   v3[2] * f3;
      Vector3 result = new Vector3(
        (t.X * f.X) + (u.X * f.Y) + (v.X * f.Z),
        (t.Y * f.X) + (u.Y * f.Y) + (v.Y * f.Z),
        (t.Z * f.X) + (u.Z * f.Y) + (v.Z * f.Z));
      return result;
    }
    RadiosityHelper.UVConversionCacheItem ClosestMatch(List<RadiosityHelper.UVConversionCacheItem> items, Vector2 UV, int lightmapIndex, SurfaceDescription desc)
    {
      float pixelWidth = 1f/((float)desc.Width * 4f);
      float pixelHeight = 1f/((float)desc.Height*4f);

      if (items.Count == 0)
        return null;
      if (items.Count == 1)
        return items[0];
      var closest = new { Dist2 = float.MaxValue, Item = items[0] };
      for (int i = 0; i < items.Count; i++)
      {
        EnhancedMesh mesh = meshes[lightmapIndex][items[i].materialIndex];
        int f = items[i].faceIndex;

        Vertex v1 = mesh.Vertices[mesh.Indices[f * 3]];
        Vertex v2 = mesh.Vertices[mesh.Indices[f * 3 + 1]];
        Vertex v3 = mesh.Vertices[mesh.Indices[f * 3 + 2]];

        Vector2 p1 = new Vector2(v1.u2, v1.v2);
        Vector2 p2 = new Vector2(v2.u2, v2.v2);
        Vector2 p3 = new Vector2(v3.u2, v3.v2);

        if (items[i].InTriangle)
          return items[i];
        //else if (PointInTriangle(new Vector2(UV.X + (pixelWidth / 2), UV.Y + (pixelHeight / 2)), p1, p2, p3) != Vector2.Empty)
       //   return items[i];
        Vector2 bary = PointInTriangleDist(UV, p1, p2, p3);

        float dist2 = Math.Abs(bary.X) + Math.Abs(bary.Y);
        float otherDist2 = PointToTriangle2(p1, p2, p3, UV);
        float cacheDist = (UV - items[i].collisionPoint).LengthSq();
        if ((cacheDist < closest.Dist2) && (dist2 < 1f))
          closest = new {Dist2 = cacheDist, Item = items[i]};
      }
      return null;
    }
    public bool PointInTriangle2(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
      return SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b);
    }
    public bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
    {
      Vector3 op1 = Vector3.Cross(b - a, p1 - a);
      Vector3 op2 = Vector3.Cross(b - a, p2 - a);
      float dot = Vector3.Dot(op1, op2);
      return dot >= 0;
    }
    public Vector2 PointInTriangleDist(Vector2 i, Vector2 p0, Vector2 p1, Vector2 p2)
    {
      float u, v;
      Vector2 e0 = i - p0; //e0 = new Vector2(Math.Abs(e0.X), Math.Abs(e0.Y));
      Vector2 e1 = p1 - p0; //e1 = new Vector2(Math.Abs(e1.X), Math.Abs(e1.Y));
      Vector2 e2 = p2 - p0; //e2 = new Vector2(Math.Abs(e2.X), Math.Abs(e2.Y));
      if (e1.X == 0)
      {
        if (e2.X == 0) return Vector2.Empty;
        u = e0.X / e2.X;
        //if ((u < 0) || (u > 1)) return Vector2.Empty;
        if (e1.Y == 0) return Vector2.Empty;
        v = (e0.Y - (e2.Y * u)) / e1.Y;
        //if (v < 0) return Vector2.Empty;
      }
      else
      {
        float d = (e2.Y * e1.X) - (e2.X * e1.Y);
        if (d == 0) return Vector2.Empty;
        u = ((e0.Y * e1.X) - (e0.X * e1.Y)) / d;
        //if ((u < 0) || (u > 1)) return Vector2.Empty;
        v = ((e0.X - (e2.X * u)) / e1.X);
        //if (v < 0) return Vector2.Empty;
      }
      //if (u + v > 1) return Vector2.Empty;
      return new Vector2(u, v);
    }
    public float PointToTriangle2(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
    {
      float closest = PointToLine2(a, b, p);

      float temp = PointToLine2(b, c, p);
      if (temp < closest)
        closest = temp;

      temp = PointToLine2(c, a, p);
      if (temp < closest)
        closest = temp;
      return closest;
    }
    public float PointToLine2(Vector2 a, Vector2 b, Vector2 p)
    {
      /*float u = ((p.X - a.X) * (b.X - a.X) + (p.Y - a.Y) * (b.Y - a.Y)) / (b - a).LengthSq();
      if ((u < 0.0f) || (u > 1.0f))
        return float.MaxValue;
      return new Vector2(a.X + (u * (b.X - a.X)), a.Y + (u * (b.Y - a.Y))).LengthSq();*/
      float numerator = Math.Abs(((b.X - a.X) * (a.Y - p.Y)) - ((a.X - p.X) * (b.Y - a.Y)));
      numerator *= numerator;
      float term1 = (b.X - a.X); term1 *= term1;
      float term2 = (b.Y - a.Y); term2 *= term2;
      return numerator / (term1 + term2);
    }
    #endregion
  }
}
