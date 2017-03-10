using System;
using System.IO;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the DDSCAPS2 Microsoft DirectDraw structure.
  /// </summary>
  public struct DirectDrawSurfaceCaps
  {
    private int caps1;
    private int caps2;
    private int caps3;
    private int caps4;

    public void Write(BinaryWriter bw)
    {
      bw.Write(caps1);
      bw.Write(caps2);
      bw.Write(caps3);
      bw.Write(caps4);
    }

    public void Generate(int mipMapCount, bool isCubemap, bool isVolume)
    {
      caps1 = (int)DirectDrawSurfaceCapsAFlags.Texture;
      if (mipMapCount > 0)
      {
        caps1 |= (int)DirectDrawSurfaceCapsAFlags.Complex;
        caps1 |= (int)DirectDrawSurfaceCapsAFlags.MipMap;
      }

      caps2 = 0;
      if (isCubemap)
      {
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeMap;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFacePositiveX;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFacePositiveY;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFacePositiveZ;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFaceNegativeX;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFaceNegativeY;
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.CubeFaceNegativeZ;
        caps1 |= (int)DirectDrawSurfaceCapsAFlags.Complex;
      }
      if (isVolume)
      {
        caps2 |= (int)DirectDrawSurfaceCapsBFlags.Volume;
        caps1 |= (int)DirectDrawSurfaceCapsAFlags.Complex;
      }

      caps3 = 0;
      caps4 = 0;
    }
  }
}
