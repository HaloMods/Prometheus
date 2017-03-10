using System;

namespace Games.Halo.Compiler
{
  internal static class BitmapPixel
  {
    internal static byte BitmapBpp(short format)
    {
      switch (format)
      {
        case 0:
        case 1:
        case 2:
          return 8;
        case 3:
          return 16;
        case 4:
        case 5:
          throw new HaloException("Invalid bitmap format.");
        case 6:
          return 16;
        case 7:
          throw new HaloException("Invalid bitmap format.");
        case 8:
        case 9:
          return 16;
        case 10:
        case 11:
          return 32;
        case 12:
        case 13:
          throw new HaloException("Invalid bitmap format.");
        case 14:
          return 4;
        case 15:
        case 16:
        case 17:
          return 8;
        default:
          throw new HaloException("Unknown bitmap format.");
      }
    }
  }
}
