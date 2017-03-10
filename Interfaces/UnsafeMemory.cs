using System;

namespace Interfaces
{
  /// <summary>
  /// Manages unsafe memory operations.
  /// </summary>
  public unsafe static class UnsafeMemory
  {
    /// <summary>
    /// Copies the given string into a character array buffer, with a maximum transference of 'max' characters.
    /// </summary>
    public static void CopyStringToBuffer(string str, byte* buffer, int max)
    {
      int min = Math.Min(str.Length, max);
      for (int i = 0; i < min; i++)
        buffer[i] = Convert.ToByte(str[i]);
    }

    /// <summary>
    /// Returns a String that is made up of the characters in 'buffer'.
    /// </summary>
    public static string CopyBufferToString(byte* buffer, int max)
    {
      string ret = String.Empty;
      for (int i = 0; i < max; i++)
        ret += Convert.ToChar(buffer[i]);
      return ret.Trim('\0');
    }

    /// <summary>
    /// Returns true if two buffers are determined to be equal.
    /// </summary>
    public static bool BufferCompare(byte* bufferA, byte* bufferB, int start, int count)
    {
      for (int i = start; i < count; i++)
      {
        if (bufferA[i] != bufferB[i])
          return false;
      }
      return true;
    }

    /// <summary>
    /// Copies length bytes from source to destination.
    /// </summary>
    public static void CopyBufferToBuffer(byte* source, byte* destination, int lengthA, int lengthB)
    {
      int length = Math.Min(lengthA, lengthB);
      for (int i = 0; i < length; i++)
        destination[i] = source[i];
    }
  }
}
