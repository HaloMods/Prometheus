using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX;

using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Radiosity;
using Interfaces.Rendering.Wrappers;
using Interfaces.Textures;
using global::Interfaces.DebugConsole;

namespace Interfaces.Rendering.Radiosity
{
  public static class RadiosityHelper
  {
    #region Types
    /// <summary>
    /// Stores one reference to a material and face.
    /// </summary>
    public class UVConversionCacheItem
    {
      public int materialIndex;
      public int faceIndex;

      public bool InTriangle;
      public Vector2 collisionPoint;
      public UVConversionCacheItem(int materialIndex, int faceIndex)
      {
        this.materialIndex = materialIndex;
        this.faceIndex = faceIndex;
        InTriangle = true;
        collisionPoint = Vector2.Empty;
      }
      public UVConversionCacheItem(int materialIndex, int faceIndex, bool InTriangle, Vector2 collisionPoint)
        : this(materialIndex, faceIndex)
      {
        this.InTriangle = InTriangle;
        this.collisionPoint = collisionPoint;
      }
      public override string ToString()
      {
        return string.Format("Material: {0} Face: {1}", materialIndex, faceIndex);
      }
    }
    
    /// <summary>
    /// Stores a list of references to faces which affect a certain pixel.
    /// </summary>
    public class UVConversionCache
    {
      public List<UVConversionCacheItem> Items = new List<UVConversionCacheItem>();
      public Vertex ClosestVertex = new Vertex(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
      public List<ClosestFaceStruct> Closests = new List<ClosestFaceStruct>();

      public void TryAdd(UVConversionCacheItem item, float distance)
      {
        for (int x = 0; x < Closests.Count; x++)
        {
          var b = Closests[x];
          if (b.Material == item.materialIndex)
            if (b.Distance > distance)
            {
              Closests[x] = new ClosestFaceStruct();
              Closests[x].Distance = distance;
              Closests[x].Face = item.faceIndex;
              Closests[x].Material = item.materialIndex;
            }
        }
          
      }
      public ClosestFaceStruct FindClosestFace(int material)
      {
        foreach (var b in Closests)
          if (b.Material == material)
            return b;
        return null;
      }
    }
    public class ClosestFaceStruct
    {
      public int Face;
      public float Distance;
      public int Material;
    }
    public class UVConversionMap
    {
      UVConversionCache[,] conversionMap;
      //int width, int height;

      public int Width { get; set; }
      public int Height { get; set; }

      public UVConversionCache this[int x, int y]
      {
        get 
        {
          if (x >= Width)
            throw new IndexOutOfRangeException();
          if (y >= Height)
            throw new IndexOutOfRangeException();

          return conversionMap[x, y]; 
        }
        set 
        {
          if (x >= Width)
            throw new IndexOutOfRangeException();
          if (y >= Height)
            throw new IndexOutOfRangeException();

          conversionMap[x, y] = value; 
        }
      }

      public UVConversionMap(int width, int height)
      {
        conversionMap = new UVConversionCache[width, height];
        Width = width;
        Height = height;
        for (int x = 0; x < width; x++)
          for (int y = 0; y < height; y++)
            conversionMap[x, y] = new UVConversionCache();
      }
    }
    public class UVConversionTable
    {
      UVConversionMap[] table;

      public int MapCount { get; set; }

      public UVConversionMap this[int map]
      {
        get { return this.table[map]; }
        set { this.table[map] = value; }
      }
      public UVConversionCache this[int map, int x, int y]
      {
        get 
        {
          if (this.table[map] == null)
            throw new NullReferenceException("The requested map does not exist.");

          return this.table[map][x, y]; 
        }
        set 
        {
          if (this.table[map] == null)
            throw new NullReferenceException("The requested map does not exist.");

          this.table[map][x, y] = value; 
        }
      }

      public UVConversionTable(int count)
      {
        table = new UVConversionMap[count];
        MapCount = count;
      }
    }
    #endregion

    public const float Epsilon = 0.00001f;
    public static Random Random;
    [Console("raddiffuse")]
    public static double RadiosityDiffuseConstant = 0.3;
    [Console("radk", "The radiosity brightness constant.")]
    public static float BrightnessConstant = 0.015f;
    [Console("raddist", "The radiosity gathering distance.")]
    public static float GatherDistance = 1.0f;
    [Console("radscale", "The factor with which to scale a photon's power after every bounce.")]
    public static float PhotonPowerScale = 0.6f;
    [Console("mapscale", "The factor by which the lightmaps are scaled when their lighting estimates are computed.")]
    public static float LightmapScale = 4f;
    [Console("lightmax", "The highest value a light can be.")]
    public static float LightMax = 1800f;
    [Console("distantlights")]
    public static bool DoDistantLights = true;

    [Console("gathercount", "The most photons that can be gathered at any point.")]
    public static int GatherCount = 20;

    public static bool[,] ImportanceMap { get; set; }
    /// <summary>
    /// The number of pixels on the importance map which are set "on", or in other words, are emitting photons.
    /// </summary>
    public static int ImportanceMapOnPixels { get; set; }

    public static double RandomDouble
    {
      get
      {
        double a = Random.NextDouble();
        if (a == 0.0)
        {
          Random = new Random();
          //a = Random.NextDouble();
        }
        return a;
      }
    }

    /// <summary>
    /// Returns a random double within the specified range.
    /// </summary>
    /// <param name="range">Range is the total width of the range. It can be found with the formula: range = max-min</param>
    /// <param name="min">The lowest value in the range.</param>
    /// <returns>((random double between 0.0 and 1.0) * range) - min</returns>
    public static double RandomDoubleRange(double range, double min)
    {
      return (RandomDouble * range) - min;
    }

    static RadiosityHelper()
    {
      Random = new Random(System.Environment.TickCount);
    }
    /// <summary>
    /// Using the three vertices of the triangle, computes the normal.
    /// </summary>
    /// <param name="a">Triangle vertex</param>
    /// <param name="b">Triangle vertex</param>
    /// <param name="c">Triangle vertex</param>
    /// <returns>Triangle vertex</returns>
    public static Vector3 ComputeTriangleNormal(Vertex a, Vertex b, Vertex c)
    {
      Vector3 u = c.position - b.position;
      Vector3 v = c.position - a.position;
      Vector3 normal = Vector3.Cross(u, v);
      normal.Normalize();
      return normal;
    }
    /// <summary>
    /// Checks to see if a collision is on the correct side of a face using it's normal.
    /// </summary>
    /// <param name="direction">The direction of the ray when it struck the surface.</param>
    /// <param name="normal">The normal of the surface intersected.</param>
    /// <returns>True if the direction is pointing in the opposite direction of the normal.</returns>
    public static bool CheckCollisionSide(Vector3 direction, Vector3 normal)
    {
      return Vector3.Dot(direction, normal) > 0;
    }
    /// <summary>
    /// Performs a specular reflection and returns the new direction of the ray.
    /// </summary>
    /// <param name="direction">The direction of the ray when it struck the surface.</param>
    /// <param name="normal">The surface's normal.</param>
    /// <returns></returns>
    public static Vector3 SpecularReflect(Vector3 direction, Vector3 normal)
    {
      Vector3 dir = direction + (2 * normal * (-Vector3.Dot(normal, direction))); ;
      dir.Normalize();
      return dir;
    }
    /// <summary>
    /// Given the normal of the reflecting surface, determines the resulting ray if the surface is diffuse.
    /// </summary>
    /// <param name="normal"></param>
    /// <returns>A randomly generated ray.</returns>
    public static Vector3 DiffuseReflect(Vector3 normal)
    {
      float x = ((float)Random.NextDouble() * 2f) - 1f;
      float y = ((float)Random.NextDouble() * 2f) - 1f;
      float z = ((float)Random.NextDouble() * 2f) - 1f;
      Vector3 newDir = new Vector3(x, y, z);
      newDir.Normalize();
      if (!CheckCollisionSide(newDir, normal))
        newDir *= -1f;
      return newDir;
    }
    /// <summary>
    /// Converts the barycentric coordinates in the Intersection class to texture UV coordinates.
    /// </summary>
    /// <param name="a">Triangle vertex</param>
    /// <param name="b">Triangle vertex</param>
    /// <param name="c">Triangle vertex</param>
    /// <param name="intersection">The intersection returned by EnhancedMesh.Intersect</param>
    /// <returns></returns>
    public static Vector2 ConvertBaryToTextureCoords(Vertex a, Vertex b, Vertex c, global::Interfaces.Rendering.Wrappers.Intersection intersection)
    {
      return Vector2.BaryCentric(new Vector2(a.u2, a.v2), new Vector2(b.u2, b.v2), new Vector2(c.u2, c.v2), intersection.U, intersection.V);
    }

    public static UVConversionMap CacheUVConversionData(EnhancedMesh[] meshes, int width, int height)
    {
      if (meshes == null)
        throw new InvalidOperationException("Cannot cache UV conversion data when there are no meshes loaded.");
      if ((width <= 0) || (height <= 0))
        throw new ArgumentOutOfRangeException("The size of the UV conversion cache was below zero.");

      Vector2 pixelSize = new Vector2(1f / (float)width, 1f / (float)height);
      float widthF = (float)width, heightF = (float)height;

      UVConversionMap map = new UVConversionMap(width, height);
      
      // iterate through the meshes
      for (int materialIndex = 0; materialIndex < meshes.Length; materialIndex++)
      {
        EnhancedMesh mesh = meshes[materialIndex];

        // iterate through the faces
        int faceCount = mesh.Indices.Length / 3;
        for (int f = 0; f < faceCount; f++)
        {
          RadiosityHelper.UVConversionCacheItem it = new RadiosityHelper.UVConversionCacheItem(materialIndex, f);
          Vertex[] verts = { mesh.Vertices[mesh.Indices[f * 3]], mesh.Vertices[mesh.Indices[f * 3 + 1]], mesh.Vertices[mesh.Indices[f * 3 + 2]] };
          Vector2 a = new Vector2(verts[0].u2, verts[0].v2), b = new Vector2(verts[1].u2, verts[1].v2), c = new Vector2(verts[2].u2, verts[2].v2);

          #region Step 1: Create pixel bounding box.
          // Step 1: Get a basic idea of nearby pixels to test against the face by
          // creating a rectangle
          int left = int.MaxValue, right = int.MinValue, top = int.MaxValue, bottom = int.MinValue;
          for (int x = 0; x < verts.Length; x++)
          {
            float tempF = verts[x].u2 * widthF;
            int temp = (int)Math.Floor(tempF);
            if (temp < left)
              left = temp;
            temp = (int)Math.Ceiling(tempF);
            if (temp > right)
              right = temp;
            tempF = verts[x].v2 * heightF;
            temp = (int)Math.Floor(tempF);
            if (temp < top)
              top = temp;
            temp = (int)Math.Ceiling(tempF);
            if (temp > bottom)
              bottom = temp;
          }
          #endregion

          #region Step 2: Test all pixels against the current face.
          for (int x = left; x <= right; x++)
            for (int y = top; y <= bottom; y++)
            {
              if (map[x,y].Items.Contains(it))
                continue; // these x,y coordinates are already on the table-- no need to recheck.

              if ((left == right) && (left == x))
                if ((bottom == top) && (top == y))
                  map[x,y].Items.Add(it);

              Vector2 pointUV = new Vector2((float)x / widthF, (float)y / heightF);
              if (PointInTriangle(pointUV, a, b, c) == Vector2.Empty) // if this point is not inside the triangle
              {
                #region  Test to see if this face's vertices are the closest ones to the point
                float dist = float.MaxValue;
                dist = (pointUV - a).LengthSq();
                map[x, y].TryAdd(it, dist);

                dist = (pointUV - b).LengthSq();
                map[x, y].TryAdd(it, dist);
                
                dist = (pointUV - c).LengthSq();
                map[x, y].TryAdd(it, dist);
                
                #endregion
                continue;
                #region Unused
                // This point's 100% UV is not on this triangle. Check for partial collision by
                //  1) creating a bounding box for the current pixel
                //  2) colliding every line in the box with the three lines of the triangle.
                Vector2 pointUV10 = new Vector2(pointUV.X + pixelSize.X, pointUV.Y); // top right
                Vector2 pointUV01 = new Vector2(pointUV.X, pointUV.Y + pixelSize.Y); // bottom left
                Vector2 pointUV11 = new Vector2(pointUV10.X, pointUV01.Y); // bottom right

                float ua, ub; int A, B;
                Vector2[] linesA = new Vector2[] {
                    pointUV, pointUV10, // top
                    pointUV10, pointUV11, // right
                    pointUV11, pointUV01, // bottom
                    pointUV01, pointUV };
                Vector2[] linesB = new Vector2[] {
                      a, b,
                      b, c,
                      c, a };
                bool collided = LineIntersection(linesA, /* left */ linesB, out ua, out ub, out A, out B);

                if (collided)
                {
                  float collX = linesA[A * 2].X + (ua * (linesA[A * 2 + 1].X - linesA[A * 2].X));
                  float collY = linesA[A * 2].Y + (ua * (linesA[A * 2 + 1].Y - linesA[A * 2].Y));
                  RadiosityHelper.UVConversionCacheItem newIT = new RadiosityHelper.UVConversionCacheItem(materialIndex, f, false, new Vector2(collX, collY));
                  
                  // Anything inside the bounding box will affect the current pixel, the pixel to the right, and the pixel below.
                  map[x, y].Items.Add(newIT);
                  if (x + 1 < width)
                    map[x + 1, y].Items.Add(newIT);
                  if (y + 1 < height)
                  {
                    map[x, y + 1].Items.Add(newIT);
                  }
                  if ((x + 1 < width) && (y + 1 < height))
                    map[x + 1, y + 1].Items.Add(newIT);
                }

                continue;
                #endregion
              }
              else
                map[x, y].Items.Add(it); // The point is on this face, so add this face to the map
              
            }
          #endregion

        }
      }
      return map;
    }
    
    public static double Expose(double light, double k) { return Expose(light, k, 255.0); }
    public static double Expose(double light, double k, double range)
    {
      return (1.0 - Math.Exp(-(light * k))) * range;
    }

    public static float PointPlaneDistance(Vector3 planeNormal, float d, Vector3 point)
    {
      float numer = Vector3.Dot(planeNormal, point) + d;
      float denom = (float)Math.Sqrt((planeNormal.X * planeNormal.X) + (planeNormal.Y * planeNormal.Y) + (planeNormal.Z * planeNormal.Z));
      //float result = numer / denom;
      return numer / denom;//result;
    }

    public static RealColor ComputeLightingEstimate(CompressedPhoton[] photons, RadiosityMaterial material, Vector3 surfaceNormal)
    {
      RealColor estimate = RealColor.Black.Copy();

      for (int p = 0; p < photons.Length; p++)
      {
        float dotP = (surfaceNormal != Vector3.Empty) ? Vector3.Dot(surfaceNormal, photons[p].Direction) : 0.5f;
        if (dotP < 0)
          continue;
        estimate.Add(photons[p].Power.Copy().Multiply(dotP));
      }
      estimate.Multiply((float)RadiosityHelper.RadiosityDiffuseConstant);
      estimate.Multiply(material.AmbientLight);

      return estimate;
    }

    public static Vector3 IntersectRayTriangleAlgebraic(Vertex a, Vertex b, Vertex c, Vector3 origin, Vector3 direction)
    {
      Vector3 normal = ComputeTriangleNormal(a, b, c);

      #region Algebraic
      float denom = Vector3.Dot(direction, normal);
      if ((denom < Epsilon) && (denom > -Epsilon))
        return Vector3.Empty; // parallel
      float d = -Vector3.Dot(normal, a.position);

      float t = -(Vector3.Dot(origin, normal) + d) / denom;

      Vector3 P = origin + (t * direction);

      Vector3 t1 = a.position - P;
      Vector3 t2 = b.position - P;
      Vector3 t3 = c.position - P;

      Vector3 n = Vector3.Cross(t1, t2); n.Normalize();
      float d1 = -(Vector3.Dot(origin, n));
      if (Vector3.Dot(P, n) + d1 < 0)
        return Vector3.Empty;

      n = Vector3.Cross(t2, t3); n.Normalize();
      d1 = -(Vector3.Dot(origin, n));
      if (Vector3.Dot(P, n) + d1 < 0)
        return Vector3.Empty;

      n = Vector3.Cross(t3, t1); n.Normalize();
      d1 = -(Vector3.Dot(origin, n));
      if (Vector3.Dot(P, n) + d1 < 0)
        return Vector3.Empty;
      return P;
      #endregion
    }
    public static Vector3 IntersectRayTriangleParametric(Vertex a, Vertex b, Vertex c, Vector3 origin, Vector3 direction)
    {
      Vector3 normal = ComputeTriangleNormal(a, b, c);

      float denom = Vector3.Dot(direction, normal);
      if ((denom < Epsilon) && (denom > -Epsilon))
        return Vector3.Empty; // parallel
      float d = -Vector3.Dot(normal, a.position);

      float t = -(Vector3.Dot(origin, normal) + d) / denom;

      Vector3 P = origin + (t * direction);

      float u, v;

      Vector3 m = b.position - a.position;
      Vector3 n = c.position - a.position;

      // figured algebraicly by ZF; could be wrong.
      denom = (m.X * n.X) - (n.X * m.Y);
      if (denom == 0) return Vector3.Empty; // Divide by zero.
      float numer = (P.Y * m.X) - (P.X * m.Y); 
      v = numer / denom; 
      if ((v < 0) || (v > 1)) return Vector3.Empty;
      if (m.Y == 0) return Vector3.Empty;
      u = (P.Y - (v * n.Y)) / m.Y;
      if ((u >= 0) && (u <= 1))
        return Vector3.Empty;
      return P;
    }
    public static Vector3 IntersectRayTriangleFast(Vector3 a, Vector3 b, Vector3 c, Vector3 origin, Vector3 direction)
    {
      Vector3 edge1 = b - a;
      Vector3 edge2 = c - a;

      Vector3 pVec = Vector3.Cross(direction, edge2);
      float det = Vector3.Dot(edge1, pVec);

      /*if (det < Epsilon)
        return 0;

      Vector3 tVec = origin - a;

      float u = Vector3.Dot(tVec, pVec);
      if ((u < 0f) || (u > det))
        return Vector3.Empty;

      Vector3 qVec = Vector3.Cross(tVec, edge1);
      float v = Vector3.Dot(direction, qVec);

      if ((v < 0f) || (u + v > det))
        return Vector3.Empty;

      float t = Vector3.Dot(edge2, qVec);
      float inv_det = 1f / det;

      t *= inv_det;
      u *= inv_det;
      v *= inv_det;*/
      // if culling is desired

      if ((det > -Epsilon) && (det < Epsilon))
        return Vector3.Empty;

      float inv_det = 1f / det;

      Vector3 tVec = origin - a;
      float u = Vector3.Dot(tVec, pVec);
      if ((u < 0f) || (u > 1f))
        return Vector3.Empty;

      Vector3 qVec = Vector3.Cross(tVec, edge1);

      float v = Vector3.Dot(direction, qVec);
      if ((v < 0f) || (u + v > 1f))
        return Vector3.Empty ;

      float t = Vector3.Dot(edge2, qVec) * inv_det;
      return origin + (t * direction);
    }


    /// <summary>
    /// Computes 1) a boolean specifying whether the intersection was on the right side 2) the lightmap UVs 3) the texture sample color 4) the new ray direction.
    /// </summary>
    /// <param name="direction">The direction the photon was traveling when it struck the surface.</param>
    /// <param name="a">Triangle vertex.</param>
    /// <param name="b">Triangle vertex.</param>
    /// <param name="c">Triangle vertex.</param>
    /// <param name="intersection">Intersection data returned by EnhancedMesh.Intersect</param>
    /// <param name="textureSampler">A sampler to sample the BSPs basemap texture.</param>
    /// <returns></returns>
    public static RadiosityIntersection ProcessIntersection(Vector3 direction, Vertex a, Vertex b, Vertex c, Intersection intersection, Sampler textureSampler, bool specular)
    {
      if (intersection == Intersection.None)
        return RadiosityIntersection.None;

      RadiosityIntersection radIntersect = new RadiosityIntersection(intersection);
      Vector3 normal = ComputeTriangleNormal(a, b, c);

      radIntersect.WrongSide = CheckCollisionSide(direction, normal);
      if (Random.NextDouble() > RadiosityDiffuseConstant)
        radIntersect.Absorbed = true;
      if (specular)
        radIntersect.NewDirection = SpecularReflect(direction, normal);
      else
        radIntersect.NewDirection = DiffuseReflect(normal);
      radIntersect.Scale = 1f; // TODO: Is this even necessary?

      Vector2 lightmapUV = ConvertBaryToTextureCoords(a, b, c, intersection);
      Vector2 textureUV = ConvertBaryToTextureCoords(a, b, c, intersection);
      radIntersect.U = lightmapUV.X;
      radIntersect.V = lightmapUV.Y;

      if (textureSampler != null)
        radIntersect.TextureSampleColor = textureSampler.Sample(textureUV);
      return radIntersect;
    }

    private static float ComputeTriangleArea(float a, float b, float c)
    {
      float s = a + b + c; s /= 2;
      return (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    public static float LengthOfLine(float x0, float y0, float x1, float y1)
    {
      x0 = x1 - x0;
      y0 = y1 - y0;
      float dist2d = (float)Math.Sqrt((x0 * x0) + (y0 * y0));
      return (float)Math.Sqrt((x0 * x0) + (y0 * y0));
    }
    /// <summary>
    /// Magic method which inputs three vertex's UV coordinates and another UV coordinate and outputs factors which can compute the point on a triangle.
    /// </summary>
    /// <param name="vx">U coordinate</param>
    /// <param name="vy">V coordinate</param>
    /// <returns>Three factors, one for each vertex. To determine the output coordinates, multiply every vertex by its corresponding factor and add it up for every dimension.</returns>
    private static Vector3 BaryCentric(float x0, float y0, float x1, float y1, float x2, float y2,
                                       float vx, float vy)
    {
      float a, b, c, totalArea, length0, length1, length2;
      a = LengthOfLine(x0, y0, x1, y1);
      b = LengthOfLine(x1, y1, x2, y2);
      c = LengthOfLine(x2, y2, x0, y0);
      totalArea = ComputeTriangleArea(a, b, c);
      length0 = LengthOfLine(x0, y0, vx, vy);
      length1 = LengthOfLine(x1, y1, vx, vy);
      length2 = LengthOfLine(x2, y2, vx, vy);

      float u = ComputeTriangleArea(b, length1, length2) / totalArea;
      float v = ComputeTriangleArea(c, length0, length2) / totalArea;
      float w = ComputeTriangleArea(a, length0, length1) / totalArea;
      return new Vector3(u, v, w);
    }
    public static Vector3 ComputeLocationOnTriangle(Vertex v1, Vertex v2, Vertex v3, Vector2 UV)
    {
      Vector3 f = BaryCentric(v1.u2, v1.v2, v2.u2, v2.v2, v3.u2, v3.v2, UV.X, UV.Y);
      Vector3 result = new Vector3(
        (v1.position.X * f.X) + (v2.position.X * f.Y) + (v3.position.X * f.Z),
        (v1.position.Y * f.X) + (v2.position.Y * f.Y) + (v3.position.Y * f.Z),
        (v1.position.Z * f.X) + (v2.position.Z * f.Y) + (v3.position.Z * f.Z));
      return result;
    }
    public static Vector2 PointInTriangle(Vector2 i, Vector2 p0, Vector2 p1, Vector2 p2)
    {
      float u, v;

      Vector2 e0 = i - p0; //e0 = new Vector2(Math.Abs(e0.X), Math.Abs(e0.Y));
      Vector2 e1 = p1 - p0; //e1 = new Vector2(Math.Abs(e1.X), Math.Abs(e1.Y));
      Vector2 e2 = p2 - p0; //e2 = new Vector2(Math.Abs(e2.X), Math.Abs(e2.Y));
      if ((e1.X > -Epsilon) &&(e1.X < Epsilon))
      {
        if ((e2.X < Epsilon) && (e2.X > -Epsilon))
          e2.X = 0;
        if (e2.X == 0)
          return Vector2.Empty;
        u = e0.X / e2.X;
        if ((u < Epsilon) || (u > 1)) return Vector2.Empty;
        if (e1.Y ==0) return Vector2.Empty;
        v = (e0.Y - (e2.Y * u)) / e1.Y;
        if (v < Epsilon) return Vector2.Empty;
      }
      else
      {
        float d = (e2.Y * e1.X) - (e2.X * e1.Y);
        if (d == 0) return Vector2.Empty;
        u = ((e0.Y * e1.X) - (e0.X * e1.Y)) / d;
        if ((u < 0) || (u > 1)) return Vector2.Empty;
        v = ((e0.X - (e2.X * u)) / e1.X);
        if (v < Epsilon) return Vector2.Empty;
      }
      if (u + v > 1) return Vector2.Empty;
      return new Vector2(u, v);
    }
    public static bool PointInTriangle2(Vector3 p, Vector3 a, Vector3 b, Vector3 c)
    {
      return SameSide(p, a, b, c) && SameSide(p, b, a, c) && SameSide(p, c, a, b);
    }
    public static bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
    {
      Vector3 op1 = Vector3.Cross(b - a, p1 - a);
      Vector3 op2 = Vector3.Cross(b - a, p2 - a);
      float dot = Vector3.Dot(op1, op2);
      return dot >= 0;
    }
    public static bool LineIntersectionPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
      float denominator = ((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y));
      float ua = ((d.X - c.X) * (a.Y - c.Y)) - ((d.Y - c.Y) * (a.X - c.X)),
            ub = ((b.X - a.X) * (a.Y - c.Y)) - ((b.Y - c.Y) * (a.X - c.X));
      ua /= denominator; ub /= denominator;
      float x = a.X + (ua * (b.X - a.X)),
            y = a.Y + (ua * (b.Y - a.Y));
      return (ua > 0f) && (ua < 1) && (ub > 0) && (ub < 1);
    }
    public static bool LineIntersectionPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d, out float ua, out float ub)
    {
      float denominator = ((d.Y - c.Y) * (b.X - a.X)) - ((d.X - c.X) * (b.Y - a.Y));
      ua = ((d.X - c.X) * (a.Y - c.Y)) - ((d.Y - c.Y) * (a.X - c.X));
      ub = ((b.X - a.X) * (a.Y - c.Y)) - ((b.Y - c.Y) * (a.X - c.X));
      ua /= denominator; ub /= denominator;
      float x = a.X + (ua * (b.X - a.X)),
            y = a.Y + (ua * (b.Y - a.Y));
      return (ua > 0f) && (ua < 1) && (ub > 0) && (ub < 1);
    }
    public static bool LineIntersection(Vector2[] linesA, Vector2[] linesB)
    {
      for (int x = 0; x < linesA.Length / 2; x++)
        for (int y = 0; y < linesB.Length / 2; y++)
        {
          if (LineIntersectionPoint(linesA[x * 2], linesA[x * 2 + 1], linesB[y * 2], linesB[y * 2 + 1]))
            return true;
        }
      return false;
    }
    public static bool LineIntersection(Vector2[] linesA, Vector2[] linesB, out float ua, out float ub, out int A, out int B)
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

    public static Vector2 ClosestPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
    {
      Vector2 result = a;
      float dist = (p - a).LengthSq();

      float newDist = (p - b).LengthSq();
      if (newDist < dist)
      {
        result = b;
        dist = newDist;
      }

      newDist = (p - c).LengthSq();
      if (newDist < dist)
      {
        result = c;
        dist = newDist;
      }

      return result;
    }
  }
}
