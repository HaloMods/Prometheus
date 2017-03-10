using System;

namespace Interfaces.IO
{
  /// <summary>
  /// Contains static methods to swap values in byte order.
  /// </summary>
  internal static class EndianSwap
  {
    public static void ByteSwap8(byte[] bytes)
    {
      byte b = bytes[7];
      bytes[7] = bytes[0];
      bytes[0] = b;
      b = bytes[6];
      bytes[6] = bytes[1];
      bytes[1] = b;
      b = bytes[5];
      bytes[5] = bytes[2];
      bytes[2] = b;
      b = bytes[4];
      bytes[4] = bytes[3];
      bytes[3] = b;
    }
    public static void ByteSwap4(byte[] bytes)
    {
      byte b = bytes[3];
      bytes[3] = bytes[0];
      bytes[0] = b;
      b = bytes[2];
      bytes[2] = bytes[1];
      bytes[1] = b;
    }
    public static void ByteSwap2(byte[] bytes)
    {
      byte b = bytes[1];
      bytes[1] = bytes[0];
      bytes[0] = b;
    }
    public static string ReverseString(string str)
    {
      char[] characters = new char[str.Length];
      for (int x = 0; x < str.Length; x++)
        characters[str.Length - x - 1] = str[x];
      return new string(characters);
    }
  }
}
