using System;
using System.IO;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the DDS_HEADER Microsoft DirectDraw structure.
  /// </summary>
  public struct DirectDrawSurfaceHeader
  {
    private string id;
    private DirectDrawSurfaceDescription ddsDescription;

    /// <summary>
    /// Writes this dds header to a given output stream.
    /// </summary>
    public void Write(BinaryWriter bw)
    {
      bw.Write(Convert.ToByte(id[0]));
      bw.Write(Convert.ToByte(id[1]));
      bw.Write(Convert.ToByte(id[2]));
      bw.Write(Convert.ToByte(id[3]));
      ddsDescription.Write(bw);
    }

    /// <summary>
    /// Generates a dds header.
    /// </summary>
    public void Generate(Format pixelFormat, int nWidth, int nHeight, int nDepth, int nMipMapCount, bool isCubemap)
    {
      id = "DDS ";
      ddsDescription.Generate(pixelFormat, nWidth, nHeight, nDepth, nMipMapCount, isCubemap);
    }

    /// <summary>
    /// Creates a BinaryWriter wrapped around a MemoryStream, generates a header, writes it, and returns the BinaryWriter.
    /// </summary>
    public BinaryWriter CreateMemoryStream(Format pixelFormat, int nWidth, int nHeight, int nDepth, int nMipMapCount, bool isCubemap)
    {
      Generate(pixelFormat, nWidth, nHeight, nDepth, nMipMapCount, isCubemap);
      BinaryWriter bw = new BinaryWriter(new MemoryStream());
      Write(bw);
      return bw;
    }

    /// <summary>
    /// Creates a BinaryWriter wrapped around a FileStream, generates a header, writes it, and returns the BinaryWriter.
    /// </summary>
    public BinaryWriter CreateFileStream(string filename, Format pixelFormat, int nWidth, int nHeight, int nDepth, int nMipMapCount, bool isCubemap)
    {
      Generate(pixelFormat, nWidth, nHeight, nDepth, nMipMapCount, isCubemap);
      BinaryWriter bw = new BinaryWriter(new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None));
      Write(bw);
      return bw;
    }

    /// <summary>
    /// Gets the number of bits per pixel in this dds.
    /// </summary>
    public int BitCount
    {
      get
      { return ddsDescription.BitCount; }
    }
  }
}
