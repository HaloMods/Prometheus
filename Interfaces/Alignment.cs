using System;

namespace Interfaces
{
  /// <summary>
  /// Provides methods to align data.
  /// </summary>
  public static class Alignment
  {
    public static int Align(int value, int alignment)
    {
      int padding = alignment - Math.Abs(value % alignment);
      if (padding == alignment)
        return value;
      else
        return value + padding;
    }
  }
}
