using System;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the available set of direct draw surface caps 2 flags.
  /// </summary>
  [Flags]
  public enum DirectDrawSurfaceCapsBFlags
  {
    CubeMap = 0x200,
    CubeFacePositiveX = 0x400,
    CubeFaceNegativeX = 0x800,
    CubeFacePositiveY = 0x1000,
    CubeFaceNegativeY = 0x2000,
    CubeFacePositiveZ = 0x4000,
    CubeFaceNegativeZ = 0x8000,
    Volume = 0x200000
  }
}
