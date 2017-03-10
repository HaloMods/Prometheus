using System;

namespace Interfaces.IO
{
  /// <summary>
  /// Specifies a binary byte order to use when reading or writing values.
  /// </summary>
  public enum ByteOrder : sbyte
  {
    LittleEndian = 0,
    BigEndian
  }
}
