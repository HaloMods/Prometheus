using System;
using System.Runtime.InteropServices;

namespace Games.Halo2.Compiler.Data
{
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct UnicodeStringList
  {
    private fixed byte a[16];
    public UnicodeStringReference Language0;
    public UnicodeStringReference Language1;
    public UnicodeStringReference Language2;
    public UnicodeStringReference Language3;
    public UnicodeStringReference Language4;
    public UnicodeStringReference Language5;
    public UnicodeStringReference Language6;
    public UnicodeStringReference Language7;
    public UnicodeStringReference Language8;

    [StructLayout(LayoutKind.Sequential)]
    public struct UnicodeStringReference
    {
      public short Index;
      public short Count;
    }
  }
}
