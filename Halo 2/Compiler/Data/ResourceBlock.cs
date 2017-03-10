using System;
using System.Runtime.InteropServices;

namespace Games.Halo2.Compiler.Data
{
  [StructLayout(LayoutKind.Sequential)]
  public unsafe struct ResourceBlock
  {
    public int RawOffset;
    public int RawSize;
    public int SectionDataSize;
    public int ResourceDataSize;
    public int ResourceCount;
    public int ResourceOffset;
    public int SelfReferenceIdentifier;
    public short OwnerTagSectionOffset;
    private fixed byte a[6];

    [StructLayout(LayoutKind.Sequential)]
    public struct Resource
    {
      public byte DataType;
      private fixed byte a[3];
      public short PrimaryLocator;
      public short SecondaryLocator;
      public int ResourceDataSize;
      public int ResourceDataOffset;
    }
  }
}
