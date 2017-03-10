using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Wrappers;
using Interfaces.Rendering.Radiosity;
using Wrappers = Interfaces.Rendering.Wrappers;

namespace Games.Halo.Tags.Classes
{
  public partial class gbxmodel : IModel, IInstanceable
  {
    private shader[] shaders = null;
    private EnhancedMesh[/* geometries */][/* parts */] meshes = null;
    private BoundingBox bounds = new BoundingBox();
    private InstanceCollection instances;
    private LevelOfDetail lod = LevelOfDetail.SuperHigh;
    private int pixelFillCount;
    private int[] currentPermutation = null;
    private InstanceCollection[][] superLow, low, medium, high, superHigh;

    public override void DoPostProcess()
    {
      base.DoPostProcess();

      shaders = new shader[gbxmodelValues.Shaders.Count];
      for (int i = 0; i < shaders.Length; i++)
        shaders[i] = OpenShader(gbxmodelValues.Shaders[i].Shader.Value, gbxmodelValues.Shaders[i].Shader.TagGroup);

      meshes = new EnhancedMesh[gbxmodelValues.Geometries.Count][];
      for (int i = 0; i < meshes.Length; i++)
      {
        meshes[i] = new EnhancedMesh[gbxmodelValues.Geometries[i].Parts.Count];
        for (int j = 0; j < meshes[i].Length; j++)
        {
          ushort[] strip = new ushort[gbxmodelValues.Geometries[i].Parts[j].Triangles.Count * 3];
          Vertex[] vertices = new Vertex[gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices.Count];

          for (int k = 0; k < vertices.Length; k++)
          {
            vertices[k].position.X = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.X;
            vertices[k].position.Y = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.Y;
            vertices[k].position.Z = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Position.Z;
            vertices[k].normal.X = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.I;
            vertices[k].normal.Y = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.J;
            vertices[k].normal.Z = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Normal.K;
            vertices[k].u1 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].TextureCoords.X * ((gbxmodelValues.BaseMap.Value == 0.0f) ? 1.0f : gbxmodelValues.BaseMap.Value);
            vertices[k].v1 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].TextureCoords.Y * ((gbxmodelValues.BaseMap2.Value == 0.0f) ? 1.0f : gbxmodelValues.BaseMap2.Value);
            vertices[k].u2 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node0Weight.Value;
            vertices[k].v2 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node1Weight.Value;
            vertices[k].nodeIndex1 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node0Index.Value;
            vertices[k].nodeIndex2 = gbxmodelValues.Geometries[i].Parts[j].UncompressedVertices[k].Node1Index.Value;
            bounds.Update(vertices[k].position.X, vertices[k].position.Y, vertices[k].position.Z);
          }
          for (int k = 0; k < gbxmodelValues.Geometries[i].Parts[j].Triangles.Count; k++)
          {
            strip[k * 3] = (ushort)gbxmodelValues.Geometries[i].Parts[j].Triangles[k].Vertex0Index.Value;
            strip[k * 3 + 1] = (ushort)gbxmodelValues.Geometries[i].Parts[j].Triangles[k].Vertex1Index.Value;
            strip[k * 3 + 2] = (ushort)gbxmodelValues.Geometries[i].Parts[j].Triangles[k].Vertex2Index.Value;
          }

          try
          {
            SubMesh[] sub = new SubMesh[1];
            sub[0] = new SubMesh(0, (ushort)(strip.Length - 2), 0);
            meshes[i][j] = new EnhancedMesh(vertices, strip, sub, true, false, true);
            meshes[i][j].DefaultShader = shaders[gbxmodelValues.Geometries[i].Parts[j].ShaderIndex.Value];
          }
          catch (Exception ex)
          {
            LogError("Model tag {0}.{1} failed to create Mesh: {2}", Name, "gbxmodel", ex.Message);
          }

          //instances.Add(new ObjectInstance(meshes[i][j], new Vector3(gbxmodelValues.Geometries[i].Parts[j].Centroid.X, gbxmodelValues.Geometries[i].Parts[j].Centroid.Y, gbxmodelValues.Geometries[i].Parts[j].Centroid.Z)));
          //instances.Add(new PartInstance(meshes[i][j], new Vector3(gbxmodelValues.Geometries[i].Parts[j].Centroid.X, gbxmodelValues.Geometries[i].Parts[j].Centroid.Y, gbxmodelValues.Geometries[i].Parts[j].Centroid.Z)));
        }
      }

      int[] regionPermutationCounts = new int[gbxmodelValues.Regions.Count];
      for (int i = 0; i < gbxmodelValues.Regions.Count; i++)
        regionPermutationCounts[i] = gbxmodelValues.Regions[i].Permutations.Count;

      superLow = new InstanceCollection[regionPermutationCounts.Length][];
      low = new InstanceCollection[regionPermutationCounts.Length][];
      medium = new InstanceCollection[regionPermutationCounts.Length][];
      high = new InstanceCollection[regionPermutationCounts.Length][];
      superHigh = new InstanceCollection[regionPermutationCounts.Length][];

      for (int i = 0; i < regionPermutationCounts.Length; i++)
      {
        superLow[i] = new InstanceCollection[regionPermutationCounts[i]];
        low[i] = new InstanceCollection[regionPermutationCounts[i]];
        medium[i] = new InstanceCollection[regionPermutationCounts[i]];
        high[i] = new InstanceCollection[regionPermutationCounts[i]];
        superHigh[i] = new InstanceCollection[regionPermutationCounts[i]];
      }

      int geometry;
      for (int i = 0; i < regionPermutationCounts.Length; i++)
      {
        for (int j = 0; j < regionPermutationCounts[i]; j++)
        {
          geometry = gbxmodelValues.Regions[i].Permutations[j].SuperLow.Value;
          superLow[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            superLow[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(gbxmodelValues.Geometries[geometry].Parts[k].Centroid.X,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = gbxmodelValues.Regions[i].Permutations[j].Low.Value;
          low[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            low[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(gbxmodelValues.Geometries[geometry].Parts[k].Centroid.X,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = gbxmodelValues.Regions[i].Permutations[j].Medium.Value;
          medium[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            medium[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(gbxmodelValues.Geometries[geometry].Parts[k].Centroid.X,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = gbxmodelValues.Regions[i].Permutations[j].High.Value;
          high[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            high[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(gbxmodelValues.Geometries[geometry].Parts[k].Centroid.X,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }

          geometry = gbxmodelValues.Regions[i].Permutations[j].SuperHigh.Value;
          superHigh[i][j] = new InstanceCollection();
          for (int k = 0; k < meshes[geometry].Length; k++)
          {
            superHigh[i][j].Add(new PartInstance(meshes[geometry][k],
                  meshes[geometry][k].DefaultShader,
                  new Vector3(gbxmodelValues.Geometries[geometry].Parts[k].Centroid.X,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Y,
                    gbxmodelValues.Geometries[geometry].Parts[k].Centroid.Z),
                  meshes[geometry][k].BoundingBox));
          }
        }
      }
    }

    public override void Dispose()
    {
      base.Dispose();
      if (shaders != null)
        for (int i = 0; i < shaders.Length; i++)
          Release(shaders[i]);
    }

    public void Render()
    {
      for (int i = 0; i < meshes[gbxmodelValues.Regions[0].Permutations[0].SuperHigh.Value].Length; i++)
        meshes[(int)lod][i].Render();
    }

    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      if (bounds.RayAABBIntersect(origin, direction))
      {
        EnhancedMesh[] mesh = meshes[(int)LevelOfDetail.SuperHigh];
        if (mesh == null)
          for (int x = (int)LevelOfDetail.SuperHigh; x >= 0; x--)
            if (meshes[x] != null)
            {
              mesh = meshes[x];
              break;
            }

        Intersection closest = Wrappers.Intersection.None;
        float distSq = float.MaxValue;
        for (int x = 0; x < mesh.Length; x++)
        {
          Intersection regularIntersect = mesh[x].IntersectRay(origin, direction);
          if (!regularIntersect.NoIntersection)
          {
            float dist2 = (regularIntersect.Position - origin).LengthSq();
            if (dist2 < distSq)
            {
              closest = regularIntersect;
              distSq = dist2;
            }
          }
        }
        return closest;
      }
      return Wrappers.Intersection.None;
    }

    public Instance Instance
    {
      get
      {
        currentPermutation = new int[gbxmodelValues.Regions.Count];

        for (int i = 0; i < gbxmodelValues.Regions.Count; i++)
        {
          int permutation = -1/*, geometry = -1*/;
          bool acceptable = false;

          for (int j = 0; j < gbxmodelValues.Regions[i].Permutations.Count; j++)
          {
            if (!gbxmodelValues.Regions[i].Permutations[j].Flags.GetFlag(1))
            {
              acceptable = true;
              break;
            }
          }

          if (!acceptable)
          {
            LogError("Could not find an acceptable permutation; all available permutations were marked not to be chosen.");
            permutation = 0;
          }
          else
          {
            do
            {
              permutation = Random.Next(gbxmodelValues.Regions[i].Permutations.Count - 1);
            } while (gbxmodelValues.Regions[i].Permutations[permutation].Flags.GetFlag(1) /* cannot be chosen randomly */);
          }

          currentPermutation[i] = permutation;
        }

        //return instances;
        return GetPermutation(currentPermutation);
      }
    }

    public int[] CurrentPermutations
    {
      get
      { return currentPermutation; }
    }

    public Instance GetPermutation(int[] permutations)
    {
      if (instances == null)
        instances = new InstanceCollection();
      else
        instances.Clear();

      for (int i = 0; i < gbxmodelValues.Regions.Count; i++)
      {
        switch (lod)
        {
          case LevelOfDetail.SuperLow:
            for (int j = 0; j < superLow[i][permutations[i]].Count; j++)
              instances.Add(superLow[i][permutations[i]][j]);
            break;
          case LevelOfDetail.Low:
            for (int j = 0; j < low[i][permutations[i]].Count; j++)
              instances.Add(low[i][permutations[i]][j]);
            break;
          case LevelOfDetail.Medium:
            for (int j = 0; j < medium[i][permutations[i]].Count; j++)
              instances.Add(medium[i][permutations[i]][j]);
            break;
          case LevelOfDetail.High:
            for (int j = 0; j < high[i][permutations[i]].Count; j++)
              instances.Add(high[i][permutations[i]][j]);
            break;
          case LevelOfDetail.SuperHigh:
            for (int j = 0; j < superHigh[i][permutations[i]].Count; j++)
              instances.Add(superHigh[i][permutations[i]][j]);
            break;
        }
      }

      return instances;
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
    /// Gets/Sets level of detail.
    /// </summary>
    public int PixelFillCount
    {
      get { return pixelFillCount; }
      set
      {
        pixelFillCount = value;

        //update Level of Detail setting based on pixel fill
        if (pixelFillCount > gbxmodelValues.SuperHighDetailCutoff.Value)
          lod = LevelOfDetail.SuperHigh;
        else if (pixelFillCount > gbxmodelValues.HighDetailCutoff.Value)
          lod = LevelOfDetail.High;
        else if (pixelFillCount > gbxmodelValues.MediumDetailCutoff.Value)
          lod = LevelOfDetail.Medium;
        else if (pixelFillCount > gbxmodelValues.LowDetailCutoff.Value)
          lod = LevelOfDetail.Low;
        else if (pixelFillCount > gbxmodelValues.SuperLowDetailCutoff.Value)
          lod = LevelOfDetail.SuperLow;
        else
          lod = LevelOfDetail.SuperLow;
      }
    }

    #region IModel Members

    public ModelType GetModelType
    {
      get { throw new Exception("The method or operation is not implemented."); }
    }

    public Interfaces.Rendering.Radiosity.RadiosityIntersection Intersection(Vector3 direction, Vector3 origin)
    {
      if (bounds.RayAABBIntersect(origin, direction))
      {
        EnhancedMesh[] mesh;
        if (meshes.Length > (int)LevelOfDetail.SuperHigh)
          mesh = meshes[(int)LevelOfDetail.SuperHigh];
        else mesh = null;
        if (mesh == null)
          for (int x = (int)LevelOfDetail.SuperHigh; x >= 0; x--)
            if ((meshes.Length > x) && (meshes[x] != null))
            {
              mesh = meshes[x];
              break;
            }

        Intersection closest = Wrappers.Intersection.None;
        float distSq = float.MaxValue;
        int meshIndex = -1;
        for (int x = 0; x < mesh.Length; x++)
        {
          Intersection regularIntersect = mesh[x].IntersectRay(origin, direction);
          if (!regularIntersect.NoIntersection)
          {
            float dist2 = (regularIntersect.Position - origin).LengthSq();
            if (dist2 < distSq)
            {
              closest = regularIntersect;
              distSq = dist2;
              meshIndex = x;
            }
          }
        }
        if (!closest.NoIntersection)
        {
          int f = closest.FaceIndex * 3;
          Vertex a = mesh[meshIndex].Vertices[mesh[meshIndex].Indices[f]];
          Vertex b = mesh[meshIndex].Vertices[mesh[meshIndex].Indices[f + 1]];
          Vertex c = mesh[meshIndex].Vertices[mesh[meshIndex].Indices[f + 2]];

          RadiosityIntersection radIntersect = RadiosityHelper.ProcessIntersection(direction, a, b, c, closest, null, false);

          return radIntersect;
        }
      }
      return RadiosityIntersection.None;
    }

    #endregion

    #region IRenderable Members


    public bool IntersectCamera(ICamera Camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane Plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    public List<ILight> RadiosityLights
    {
      get
      {
        int r1 = 0, r2 = 0;
        var query = from geometry in gbxmodelValues.Geometries
                   let g = gbxmodelValues.Geometries.IndexOf(geometry)
                   from part in geometry.Parts
                   where part.ShaderIndex >= 0
                   let shader = shaders[part.ShaderIndex].ShaderValues
                   where shader.Power > 0f
                   let p = geometry.Parts.IndexOf(part)
                   let mesh = meshes[g][p].Vertices
                   from tri in part.Triangles
                   let shaderColor = shader.ColorOfEmittedLight
                   where tri.Vertex0Index >= 0 && tri.Vertex1Index >= 0 && tri.Vertex2Index >= 0
                   where tri.Vertex0Index < mesh.Length && tri.Vertex1Index < mesh.Length && tri.Vertex2Index < mesh.Length
                   select new { 
                     Power = shader.Power,
                     Triangle = new Vertex[] { mesh[tri.Vertex0Index], mesh[tri.Vertex1Index], mesh[tri.Vertex2Index]}, 
                     Color = new RealColor(shader.ColorOfEmittedLight)
                   };
        List<ILight> lights = new List<ILight>(query.Count());
        foreach (var light in query)
          lights.Add(new DiffuseLight(light.Triangle, light.Color, light.Power));
        return lights;
      }
    }


  }
}
