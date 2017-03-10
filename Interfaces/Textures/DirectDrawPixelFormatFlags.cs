using System;

namespace Interfaces.Textures
{
  /// <summary>
  /// Represents the available set of direct draw pixel format descriptors.
  /// </summary>
  [Flags]
  public enum DirectDrawPixelFormatFlags
  {
    AlphaPixels = 0x1,
    AlphaPremultiplied = 0x8000,
    FourCC = 0x4,
    RGB = 0x40,
    AlphaOnly = 0x2,
    LuminosityOnly = 0x20000
  }
}
