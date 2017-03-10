using System;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the available set of direct draw surface caps 1 flags.
  /// </summary>
  [Flags]
  public enum DirectDrawSurfaceCapsAFlags
  {
    Complex = 0x8,
    Texture = 0x1000,
    MipMap = 0x400000
  }
}
