using System;
using System.IO;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the DDSURFACEDESC2 Microsoft DirectDraw structure.
  /// </summary>
  public struct DirectDrawSurfaceDescription
  {
    private int size;
    private int flags;
    private int height;
    private int width;
    private int pitchOrLinearSize;
    private int depth;
    private int mipMapCount;
    private int[] reserved1;
    private DirectDrawPixelFormat ddfPixelFormat;
    private DirectDrawSurfaceCaps ddsCaps;
    private int reserved2;

    public void Write(BinaryWriter bw)
    {
      bw.Write(size);
      bw.Write(flags);
      bw.Write(height);
      bw.Write(width);
      bw.Write(pitchOrLinearSize);
      bw.Write(depth);
      bw.Write(mipMapCount);
      for (int x = 0; x < 11; x++)
        bw.Write(reserved1[x]);
      ddfPixelFormat.Write(bw);
      ddsCaps.Write(bw);
      bw.Write(reserved2);
    }

    public void Generate(Format pixelFormat, int nWidth, int nHeight, int nDepth, int nMipMapCount, bool isCubemap)
    {
      size = 124;
      flags = 0;
      flags |= (int)DirectDrawSurfaceDescriptionFlags.Caps;
      flags |= (int)DirectDrawSurfaceDescriptionFlags.PixelFormat;
      flags |= (int)DirectDrawSurfaceDescriptionFlags.Width;
      flags |= (int)DirectDrawSurfaceDescriptionFlags.Height;

      if (pixelFormat == Format.Dxt1 || pixelFormat == Format.Dxt3 || pixelFormat == Format.Dxt4)
        flags |= (int)DirectDrawSurfaceDescriptionFlags.LinearSize;
      else
        flags |= (int)DirectDrawSurfaceDescriptionFlags.Pitch;

      height = nHeight;
      width = nWidth;
      depth = nDepth;

      // disable mips for cubemaps and volume textures, for now anyway # why?
      /*if (isCubemap || depth > 1)
        mipMapCount = 0;
      else*/
        mipMapCount = nMipMapCount;

      if (mipMapCount > 0)
        flags |= (int)DirectDrawSurfaceDescriptionFlags.MipMapCount;

      reserved1 = new int[11];
      for (int i = 0; i < 11; i++)
        reserved1[i] = 0;

      ddfPixelFormat.Generate(pixelFormat);
      ddsCaps.Generate(mipMapCount, isCubemap, depth > 1);

      if ((flags & (int)DirectDrawSurfaceDescriptionFlags.Pitch) != 0)
        pitchOrLinearSize = (width * ddfPixelFormat.BitCount) / 8;

      if ((flags & (int)DirectDrawSurfaceDescriptionFlags.LinearSize) != 0)
        pitchOrLinearSize = (width * height * (depth > 1 ? depth : 1) * ddfPixelFormat.BitCount) / 8;

      reserved2 = 0;
    }

    public int BitCount
    {
      get
      { return ddfPixelFormat.BitCount; }
    }
  }
}
