using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Primitives
{
  /// <summary>
  /// A simple vertex that supports lightmap coordinates and animating. (u2 and v2 can be used as node weights.)
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Vertex
  {
    public Vector3 position;
    public Vector3 normal;
    public float u1;
    public float v1;
    public float u2;
    public float v2;
    public int nodeIndex1;
    public int nodeIndex2;

    public static readonly VertexFormats Format = VertexFormats.Position | VertexFormats.Normal | VertexFormats.Texture3;

    /// <summary>
    /// Creates a new Vertex with the given values.
    /// </summary>
    public Vertex(float x, float y, float z, float nx, float ny, float nz, float iu1, float iv1, float iu2, float iv2)
    {
      position = new Vector3(x, y, z);
      normal = new Vector3(nx, ny, nz);
      u1 = iu1;
      v1 = iv1;
      u2 = iu2;
      v2 = iv2;
      nodeIndex1 = nodeIndex2 = -1;
    }

    /// <summary>
    /// Creates a new Vertex with the given values.
    /// </summary>
    public Vertex(float x, float y, float z, float nx, float ny, float nz, float iu1, float iv1, float iu2, float iv2, int node1, int node2)
    {
      position = new Vector3(x, y, z);
      normal = new Vector3(nx, ny, nz);
      u1 = iu1;
      v1 = iv1;
      u2 = iu2;
      v2 = iv2;
      nodeIndex1 = node1;
      nodeIndex2 = node2;
    }

    /// <summary>
    /// Gets the array of VertexElement structures that represent the architecture of this vertex.
    /// </summary>
    public static VertexElement[] Elements
    {
      get
      {
        return new VertexElement[]
        {
            new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Position, 0),
            new VertexElement(0, 12, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.Normal, 0),
            new VertexElement(0, 24, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 0),
            new VertexElement(0, 32, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 1),
            new VertexElement(0, 40, DeclarationType.Float2, DeclarationMethod.Default, DeclarationUsage.TextureCoordinate, 2),
            VertexElement.VertexDeclarationEnd
        };
      }
    }

    /// <summary>
    /// Computes a centroid based on the locations of the vertices in the given array.
    /// </summary>
    public static Vector3 ComputeCentroid(Vertex[] vertices)
    {
      Vector3 centroidSum = Vector3.Empty;
      for (int i = 0; i < vertices.Length; i++)
        centroidSum += vertices[i].position;
      centroidSum.Scale(1.0f / (float)vertices.Length);
      return centroidSum;
    }
  }

  /*/// <summary>
  /// A complex vertex that allows for animation.
  /// </summary>
  public class ModelVertex
  {
      public float[] it_pos = new float[3];
      public float[] it_norm = new float[3];
      public CustomVertex.PositionNormalTextured dxv = new CustomVertex.PositionNormalTextured();
      public short node1_index;
      public short node2_index;
      public float node1_weight;
      public float node2_weight;

      /// <summary>
      /// Loads the vertex from its PC Halo stream.
      /// </summary>
      /// <param name="br">input stream</param>
      /// <param name="UScale">u scaling coeffecient</param>
      /// <param name="VScale">v scaling coeffecient</param>
      public void Load(BinaryReader br, float UScale, float VScale)
      {
          dxv.X = br.ReadSingle();
          dxv.Y = br.ReadSingle();
          dxv.Z = br.ReadSingle();
          it_pos[0] = dxv.X;
          it_pos[1] = dxv.Y;
          it_pos[2] = dxv.Z;

          dxv.Nx = br.ReadSingle();
          dxv.Ny = br.ReadSingle();
          dxv.Nz = br.ReadSingle();
          it_norm[0] = dxv.Nx;
          it_norm[1] = dxv.Ny;
          it_norm[2] = dxv.Nz;

          //skip past binormal and tan, we probably won't use them
          br.BaseStream.Seek(24, SeekOrigin.Current);

          dxv.Tu = br.ReadSingle() * UScale;
          dxv.Tv = br.ReadSingle() * VScale;

          node1_index = br.ReadInt16();
          node2_index = br.ReadInt16();
          node1_weight = br.ReadSingle();
          node2_weight = br.ReadSingle();
      }

      /// <summary>
      /// Loads the vertex from its Xbox Halo stream.
      /// </summary>
      /// <param name="br">input stream</param>
      /// <param name="UScale">u scaling coeffecient</param>
      /// <param name="VScale">v scaling coeffecient</param>
      public void LoadCompressed(BinaryReader br, float UScale, float VScale)
      {
            
          {
              float coord[3];
              UINT  CompNormal;
              UINT  CompBinormal;
              UINT  CompTangent;
              SHORT u;
              SHORT v;
              SHORT unk1;
              SHORT node0_weight;
          }MODEL_COMPRESSED_VERT;
            

          dxv.X = br.ReadSingle();
          dxv.Y = br.ReadSingle();
          dxv.Z = br.ReadSingle();
          it_pos[0] = dxv.X;
          it_pos[1] = dxv.Y;
          it_pos[2] = dxv.Z;

          //read and decompress normal
          uint compressed_norm = br.ReadUInt32();
          float[] tmp = new float[3];
          PMath.DecompressIntToVector(compressed_norm, ref tmp);
          dxv.Nx = tmp[0];
          dxv.Ny = tmp[1];
          dxv.Nz = tmp[2];
          it_norm[0] = dxv.Nx;
          it_norm[1] = dxv.Ny;
          it_norm[2] = dxv.Nz;

          uint compressed_binormal = br.ReadUInt32();
          uint compressed_tangent = br.ReadUInt32();

          //read and decompress texture coords
          short u = br.ReadInt16();
          short v = br.ReadInt16();
          dxv.Tu = (u / 32767f) * UScale;
          dxv.Tv = (v / 32767f) * VScale;

          node1_index = br.ReadInt16();
          node1_weight = br.ReadInt16() / 65535f;
      }
  }*/
}
