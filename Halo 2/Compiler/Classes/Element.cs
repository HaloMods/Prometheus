using System;
using System.Runtime.InteropServices;

namespace Games.Halo2.Compiler.Classes
{
  /// <summary>
  /// Represents a node element in a tag definition tree.
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Element
  {
    public ElementType Type;
    public short Offset;
    public short Size;
    public byte Alignment;
    public short FirstChild;
    public short NextSibling;
    private uint hash;

    /// <summary>
    /// Returns true if this Element's hash evaluates to the given string.
    /// </summary>
    public bool HashCheck(string name)
    {
      return Djb2Hash(name) == hash;
    }

    private static uint Djb2Hash(string input)
    {
      uint hash = 5381;

      unchecked
      {
        foreach (char c in input)
          hash = ((hash << 5) + hash) ^ Convert.ToByte(c);
      }

      return hash;
    }
  }
}
