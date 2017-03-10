using System;

namespace Interfaces
{
  /// <summary>
  /// Contains static methods to convert data types in special ways.
  /// </summary>
  public static class Conversion
  {
    /// <summary>
    /// Converts an unsigned integer to its signed equivilent by reference.
    /// </summary>
    public unsafe static int ToInt(uint value)
    {
      return *(int*)&value;
    }

    /// <summary>
    /// Converts a signed integer to its unsigned equivilent by reference.
    /// </summary>
    public unsafe static uint ToUInt(int value)
    {
      return *(uint*)&value;
    }
  }
}
