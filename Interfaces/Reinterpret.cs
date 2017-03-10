using System;
using System.Runtime.InteropServices;
using System.Text;
using Interfaces.IO;

namespace Interfaces
{
  /// <summary>
  /// Provides methods to reinterpret memory, structures, and archaic file-embedded resources.
  /// </summary>
  public static class Reinterpret
  {
    /// <summary>
    /// Reinterprets an array of bytes as a structure of type T.
    /// </summary>
    /// <typeparam name="T">the structure type to create</typeparam>
    /// <param name="memory">the memory which should comprise the structure</param>
    /// <returns>a new structure comprised of memory</returns>
    public static T Memory<T>(byte[] memory) where T : struct
    {
      int dataSize = memory.Length;
      IntPtr unmanaged = Marshal.AllocHGlobal(dataSize);
      Marshal.Copy(memory, 0, unmanaged, dataSize);
      T managed = (T)Marshal.PtrToStructure(unmanaged, typeof(T));
      Marshal.FreeHGlobal(unmanaged);
      return managed;
    }

    /// <summary>
    /// Reinterprets a structure as the memory which comprises it.
    /// </summary>
    /// <typeparam name="T">the type of structure to decompose</typeparam>
    /// <param name="object">a structure of type T to decompose</param>
    /// <returns>the memory that comprises object</returns>
    public static byte[] Object<T>(T @object) where T : struct
    {
      int dataSize = Marshal.SizeOf(@object);
      byte[] memory = new byte[dataSize];
      GCHandle gch = GCHandle.Alloc(@object, GCHandleType.Pinned);
      Marshal.Copy(gch.AddrOfPinnedObject(), memory, 0, dataSize);
      gch.Free();
      return memory;
    }

    /// <summary>
    /// Reinterprets a string (with a length of four characters) as an unsigned integer fourcc.
    /// </summary>
    /// <param name="fourcc">the string to convert</param>
    /// <param name="endian">byte order in which the fourcc is interpreted</param>
    /// <returns>a 4-byte integer fourcc</returns>
    public static uint FourCC(string fourcc, ByteOrder endian)
    {
      if (fourcc.Length != 4)
        throw new ArgumentException("A four character code must contain four characters.", "fourcc");

      byte[] buffer = Encoding.ASCII.GetBytes(fourcc);
      if (endian == ByteOrder.LittleEndian)
        EndianSwap.ByteSwap4(buffer);
      return BitConverter.ToUInt32(buffer, 0);
    }

    /// <summary>
    /// Reinterprets a 4-byte integer fourcc as a string containing the human-readable characters it contains.
    /// </summary>
    /// <param name="fourcc">4-byte unsigned integer fourcc</param>
    /// <param name="endian">byte order in which the fourcc is interpreted</param>
    /// <returns>human-readable fourcc string</returns>
    public static string FourCC(uint fourcc, ByteOrder endian)
    {
      byte[] buffer = BitConverter.GetBytes(fourcc);
      if (endian == ByteOrder.LittleEndian)
        EndianSwap.ByteSwap4(buffer);
      return Encoding.ASCII.GetString(buffer);
    }
  }
}
