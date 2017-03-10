using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interfaces.Rendering.Wrappers
{
  public class EnhancedMesh : IRenderable, IDisposable
  {
    protected static int count = 0;

    protected int faceCount = 0;
    protected int vertexCount = 0;
    protected int shaderCount = 0;
    protected Mesh mesh = null;
    protected Vertex[] vertexData = null;
    protected ushort[] indexData = null;
    protected int[] attributeData = null;
    protected int[] attributeFaceCount = null;
    protected IShader defaultShader = null;
    protected Texture defaultLightmap = null;
    protected bool bDrawMesh = true;
    protected BoundingBox boundingBox = null;
    /// <summary>
    /// Gets/Sets Pixel Fill Count.  Does not currently affect mesh.
    /// </summary>
    public int PixelFillCount
    {
      get { return -1; }
      set { }
    }

    /// <summary>
    /// Creates a new instance of the EnhancedMesh class.
    /// </summary>
    /// <param name="vertexBuffer">an array of Vertex instances</param>
    /// <param name="indexBuffer">an array of UInt16 instances</param>
    /// <param name="meshes">an array of SubMesh instances</param>
    /// <param name="isStrip">true if the model is a triangle strip; false if the model is a triangle list</param>
    /// <param name="flipFlop">true if the model submeshes are flip-flopped, for instance in Halo 2. Halo, however, does not use flip-flopped submeshes. ignored if not a triangle strip</param>
    /// <param name="hasNormals">true if the model has normals; false if normals are to be generated</param>
    public EnhancedMesh(Vertex[] vertexBuffer, ushort[] indexBuffer, SubMesh[] meshes, bool isStrip, bool flipFlop, bool hasNormals)
    {
      // Make sure the indices are a valid triangle list; if they are not, make them so.
      ushort[] index = null;
      if (isStrip)
        index = ConvertStripToList(indexBuffer, ref meshes, flipFlop);
      else
        index = indexBuffer;

      // Create the Mesh object.
      shaderCount = meshes.Length;
      faceCount = index.Length / 3;
      vertexCount = vertexBuffer.Length;
      mesh = new Mesh(faceCount, vertexCount, MeshFlags.Managed, Vertex.Elements, MdxRender.Device);

      // Set the vertex buffer data.
      mesh.SetVertexBufferData(vertexBuffer, LockFlags.None);

      // Set the index buffer data.
      mesh.SetIndexBufferData(index, LockFlags.None);

      // Set the attribute buffer data.
      int maxShader = 0;
      int[] magicIntegerArray = mesh.LockAttributeBufferArray(LockFlags.None);
      for (int x = 0; x < meshes.Length; x++)
      {
        for (int y = meshes[x].Index / 3; y < meshes[x].Count / 3 + meshes[x].Index / 3; y++)
          magicIntegerArray[y] = meshes[x].ShaderIndex;
        if (meshes[x].ShaderIndex > maxShader)
          maxShader = meshes[x].ShaderIndex;
      }
      mesh.UnlockAttributeBuffer(magicIntegerArray);

      // Optimize the mesh.
      magicIntegerArray = new int[faceCount * 3];
      mesh.GenerateAdjacency(Single.Epsilon, magicIntegerArray);
      //mesh.OptimizeInPlace(MeshFlags.OptimizeCompact | MeshFlags.OptimizeAttributeSort | MeshFlags.OptimizeVertexCache, magicIntegerArray);
      faceCount = mesh.NumberFaces;
      vertexCount = mesh.NumberVertices;
      shaderCount = maxShader + 1;

      // Compute normals, if necessary.
      if (!hasNormals)
      {
        try
        {
          magicIntegerArray = new int[faceCount * 3];
          mesh.GenerateAdjacency(Single.Epsilon, magicIntegerArray);
          mesh.ComputeNormals(magicIntegerArray);
        }
        catch (Exception ex)
        {
          throw new RenderException(ex, "Failed to compute normals for a mesh.");
        }
      }

      // Save data for sampling and rehashing.
      vertexData = mesh.LockVertexBuffer(typeof(Vertex), LockFlags.ReadOnly, vertexCount) as Vertex[];
      mesh.UnlockVertexBuffer();
      indexData = mesh.LockIndexBuffer(typeof(ushort), LockFlags.ReadOnly, faceCount * 3) as ushort[];
      mesh.UnlockIndexBuffer();
      attributeData = mesh.LockAttributeBufferArray(LockFlags.ReadOnly);
      mesh.UnlockAttributeBuffer();

      // Create an array that holds the face count for each shader in this mesh.
      attributeFaceCount = new int[shaderCount];
      for (int x = 0; x < faceCount; x++)
        attributeFaceCount[attributeData[x]]++;

      // Update count.
      count++;
    }

    /// <summary>
    /// Creates a mesh based on transformed verts (for texture previewing).
    /// </summary>
    /// <param name="vertexBuffer">an array of TransformedTextured verts</param>
    /// <param name="indexBuffer">an index buffer for the verts</param>
    public EnhancedMesh(CustomVertex.TransformedTextured[] vertexBuffer, ushort[] indexBuffer)
    {
      mesh = new Mesh(indexBuffer.Length / 3, vertexBuffer.Length, MeshFlags.Managed,
        CustomVertex.TransformedTextured.Format, MdxRender.Device);

      // Set the vertex buffer data.
      mesh.SetVertexBufferData(vertexBuffer, LockFlags.None);

      // Set the index buffer data.
      mesh.SetIndexBufferData(indexBuffer, LockFlags.None);
    }

    /// <summary>
    /// Draws a single shader's worth of triangles to the device.
    /// </summary>
    /// <param name="shader">Shader index.</param>
    public virtual void Render(int shader)
    {
      //MdxRender.Device.RenderState.FillMode = FillMode.Solid;
      mesh.DrawSubset(shader);
    }

    /// <summary>
    /// Renders the whole model.
    /// </summary>
    public void Render()
    {
      if (bDrawMesh)
      {
        try
        {
          if (defaultShader == null)
          {
            for (int i = 0; i < shaderCount; i++)
              Render(i);
          }
          else
          {
            defaultShader.Lightmap = this.DefaultLightmap;
            int count = defaultShader.BeginApply();
            if (count > 0)
            {
              //for (int i = 0; i < count - 1; i++)
              //{
              //    for (int j = 0; j < shaderCount; j++)
              //        Render(i);
              //    defaultShader.SetPass(i + 1);
              //}
              for (int i = 0; i < count; i++)
              {
                defaultShader.SetPass(i);
                for (int j = 0; j < shaderCount; j++)
                  Render(j);
              }
              //for (int i = 0; i < shaderCount; i++)
              //    Render(i);
              defaultShader.EndApply();
            }
          }
        }
        catch (Exception e)
        {
          Trace.WriteLine("Error rendering EnhancedMesh: " + e.Message);
        }
      }
    }

    /// <summary>
    /// Updates the DirectX buffers with the streams currently in memory.
    /// </summary>
    protected virtual void Rehash()
    {
      // Set the vertex buffer data.
      mesh.SetVertexBufferData(vertexData, LockFlags.Discard);

      // Set the index buffer data.
      mesh.SetIndexBufferData(indexData, LockFlags.Discard);

      // Set the attribute buffer data.
      int[] attributeBufferData = mesh.LockAttributeBufferArray(LockFlags.Discard);
      for (int x = 0; x < attributeData.Length; x++)
        attributeBufferData[x] = attributeData[x];
      mesh.UnlockAttributeBuffer(attributeBufferData);
    }

    /// <summary>
    /// Performs a node-based animation transform on the model data.
    /// </summary>
    /// <param name="nodes">node array to use</param>
    public virtual void NodeTransform(NodeTransform[] nodes)
    {
      int node = -1;
      Matrix transform = Matrix.Identity;

      for (int i = 0; i < vertexCount; i++)
      {
        if ((node = vertexData[i].nodeIndex1) >= 0)
        {
          transform = nodes[node].Absolute;
          vertexData[i].position.TransformCoordinate(transform);
          vertexData[i].normal.TransformCoordinate(transform);
        }
      }

      Rehash();
    }

    /// <summary>
    /// Performs an inverse node-based animation transform on the model data.
    /// </summary>
    /// <param name="nodes">node array to use</param>
    public virtual void InverseNodeTransform(NodeTransform[] nodes)
    {
      int node = -1;
      Matrix transform = Matrix.Identity;

      for (int i = 0; i < vertexCount; i++)
      {
        if ((node = vertexData[i].nodeIndex1) >= 0)
        {
          transform = nodes[node].Absolute;
          Quaternion inverseRotation = Quaternion.Invert(Quaternion.RotationMatrix(transform));
          transform = Matrix.Translation(transform.M41, transform.M42, transform.M43) * Matrix.RotationQuaternion(inverseRotation);
          vertexData[i].position.TransformCoordinate(transform);
          vertexData[i].normal.TransformCoordinate(transform);
        }
      }
    }

    /// <summary>
    /// Gets the three vertices that make up the given face.
    /// </summary>
    /// <param name="face">face to lookup</param>
    /// <param name="a">first vertex</param>
    /// <param name="b">second vertex</param>
    /// <param name="c">third vertex</param>
    public void GetFace(int face, out Vertex a, out Vertex b, out Vertex c)
    {
      face *= 3;
      a = vertexData[indexData[face]];
      b = vertexData[indexData[face + 1]];
      c = vertexData[indexData[face + 2]];
    }

    /// <summary>
    /// Converts a triangle strip to a triangle list, removing degenerate and hanging triangles along the way.
    /// </summary>
    protected ushort[] ConvertStripToList(ushort[] strip, ref SubMesh[] subs, bool doFlipFlop)
    {
      int listIndexCount = 0, declination = 0, sub = 0, lastSub = 0;
      ushort[] list = new ushort[(strip.Length - 2) * 3];
      bool flipflop = false;

      for (int x = 2; x < strip.Length; x++)
      {
        sub = GetSub(x - declination - 2, subs);
        if (sub != lastSub && doFlipFlop)
        {
          flipflop = !flipflop;
          lastSub = sub;
        }

        if (sub < 0)
          listIndexCount += 3;
        else if (strip[x] == 0xffff || AnyEquality<ushort>(strip[x], strip[x - 1], strip[x - 2]))
        {
          subs[sub].Count--;
          for (int y = sub + 1; y < subs.Length; y++)
            subs[y].Index--;
          declination++;
        }
        else if (x % 2 == 0 ^ flipflop)
        {
          list[listIndexCount++] = strip[x - 2];
          list[listIndexCount++] = strip[x - 1];
          list[listIndexCount++] = strip[x];
        }
        else
        {
          list[listIndexCount++] = strip[x];
          list[listIndexCount++] = strip[x - 1];
          list[listIndexCount++] = strip[x - 2];
        }
      }

      if (declination > 0)
        Array.Resize<ushort>(ref list, listIndexCount);

      for (int x = 0; x < subs.Length; x++)
      {
        subs[x].Index *= 3;
        subs[x].Count = (ushort)((subs[x].Count - 2) * 3);
      }

      return list;
    }

    /// <summary>
    /// Returns the submesh index associated with the given face.
    /// </summary>
    private int GetSub(int face, SubMesh[] subs)
    {
      for (int x = 0; x < subs.Length; x++)
        if (face >= subs[x].Index)
          if (face < subs[x].Index + subs[x].Count)
            return x;
      return -1;
    }

    static bool meshIntersectFailed = false;

    /// <summary>
    /// Intersects a ray with the mesh.
    /// </summary>
    /// <param name="origin">position ray originates from</param>
    /// <param name="direction">direction ray is traveling</param>
    /// <returns>null if no hit, IntersectInformation if hit</returns>
    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      const float nudge = 0.01f;

      if (!meshIntersectFailed)
      {
        try
        {
          IntersectInformation ii;
          bool hit = mesh.Intersect(origin, direction, out ii);

          if (hit)
          {
            Vertex[] vertices = Vertices;
            ushort[] indices = Indices;
            Vertex a = vertices[indices[ii.FaceIndex * 3]];
            Vertex b = vertices[indices[ii.FaceIndex * 3 + 1]];
            Vertex c = vertices[indices[ii.FaceIndex * 3 + 2]];
            
            return new Intersection(ii, Vector3.Add(Vector3.BaryCentric(a.position, b.position, c.position, ii.U, ii.V), Vector3.Scale(Vector3.BaryCentric(a.normal, b.normal, c.normal, ii.U, ii.V), nudge)));
          }
          else
            return Intersection.None;
        }
        catch
        {
          meshIntersectFailed = true;
        }
      }

      if (meshIntersectFailed)
      {
        // First test bounding box
        if (boundingBox.RayAABBIntersect(origin, direction))
        {
          float dist2 = float.MaxValue;
          int faceIndex = -1;
          Vector3 closest = Vector3.Empty;
          
          int indexCount = faceCount * 3;
          for (int f = 0; f < indexCount; f+=3)
          {
            Vector3 point = global::Interfaces.Rendering.Radiosity.RadiosityHelper.IntersectRayTriangleParametric(vertexData[indexData[f]],
              vertexData[indexData[f + 1]],
              vertexData[indexData[f + 2]], origin, direction);
            if (point != Vector3.Empty)
            {
              // got a hit!
              float dist = (point - origin).LengthSq();
              if (dist < dist2)
              {
                faceIndex = f / 3;
                dist2 = dist;
                closest = point;
              }
            }
          }
          if (closest == Vector3.Empty)
            return Intersection.None;

          return new Intersection(closest, dist2, faceIndex, Vector2.Empty);
        }
        else
          return Intersection.None;
      }
      return Intersection.None;
    }

    /// <summary>
    /// Returns true if the given ray intersects the bounding box of this model, and false if it does not.
    /// </summary>
    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      return this.BoundingBox.RayAABBIntersect(origin, direction);
    }

    /// <summary>
    /// Generates a bounding box with the current vertex array.
    /// </summary>
    public BoundingBox BoundingBox
    {
      get
      {
        if (boundingBox == null)
        {
          boundingBox = new BoundingBox();
          for (int i = 0; i < vertexCount; i++)
            boundingBox.Update(vertexData[i].position.X, vertexData[i].position.Y, vertexData[i].position.Z);
        }

        return boundingBox;
      }
    }

    /// <summary>
    /// Gets the shader count.
    /// </summary>
    public int ShaderCount
    {
      get
      { return shaderCount; }
    }

    /// <summary>
    /// Gets the vertex count.
    /// </summary>
    public int VertexCount
    {
      get
      { return vertexCount; }
    }

    /// <summary>
    /// Gets the vertex array that the mesh is comprised of.
    /// </summary>
    public Vertex[] Vertices
    {
      get
      { return vertexData; }
    }

    /// <summary>
    /// Gets the indices that comprise the mesh.
    /// </summary>
    public ushort[] Indices
    {
      get
      { return indexData; }
    }

    /// <summary>
    /// Gets the attribute array marking triangles for submeshes.
    /// </summary>
    public int[] Attributes
    {
      get
      { return attributeData; }
    }

    /// <summary>
    /// Gets an array exposing the face count per shader.
    /// </summary>
    public int[] ShaderFaceCountSet
    {
      get
      { return attributeFaceCount; }
    }

    /// <summary>
    /// Disposes the underlying mesh and decrements the count of EnhancedMeshes in existance.
    /// </summary>
    public void Dispose()
    {
      count--;
      if (mesh != null)
        mesh.Dispose();
      mesh = null;
    }

    /// <summary>
    /// Gets or sets the default shader. This shader, if not null, will be used for all faces when Render() is called with no parameters.
    /// </summary>
    public IShader DefaultShader
    {
      get
      { return defaultShader; }
      set
      { defaultShader = value; }
    }

    /// <summary>
    /// Gets or sets the default lightmap. This lightmap, if not null, will be used for all faces when Render() is called with no parameters.
    /// </summary>
    public Texture DefaultLightmap
    {
      get
      { return defaultLightmap; }
      set
      { defaultLightmap = value; }
    }

    private bool AnyEquality<T>(T a, T b, T c)
    {
      if (a.Equals(b))
        return true;
      if (b.Equals(c))
        return true;
      if (a.Equals(c))
        return true;
      return false;
    }

    protected virtual void OnDeviceCreated(object sender, EventArgs e)
    {
      if (mesh != null)
        mesh.Dispose();
      mesh = new Mesh(faceCount, vertexCount, MeshFlags.Managed, Vertex.Elements, MdxRender.Device);
      mesh.SetIndexBufferData(indexData, LockFlags.Discard);
      mesh.SetVertexBufferData(vertexData, LockFlags.Discard);
      int[] attributeDestination = mesh.LockAttributeBufferArray(LockFlags.Discard);
      for (int x = 0; x < attributeDestination.Length; x++)
        attributeDestination[x] = attributeData[x];
      mesh.UnlockAttributeBuffer(attributeDestination);
    }

    public bool IntersectCamera(ICamera Camera)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public bool IntersectPlaneAABB(IPlane Plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public void UpdateAttributeBuffer(int[] attr, int startIndex, int length)
    {
      // Set the attribute buffer data.
      int[] attributeBufferData = mesh.LockAttributeBufferArray(LockFlags.Discard);
      Array.Copy(attr, startIndex, attributeBufferData, 0, length);
      mesh.UnlockAttributeBuffer(attributeBufferData);
    }
  }
}
