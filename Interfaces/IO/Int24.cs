using System;

namespace Interfaces.IO
{
  /// <summary>
  /// A dword comprised of one 24 bit integer and an 8 bit integer.
  /// </summary>
  public struct Int24
  {
    int iPart;
    byte bPart;

    public Int24(int dword)
    {
      iPart = dword & 0x00ffffff;
      bPart = (byte)((dword & 0xff000000) >> 24);
    }
    public Int24(int longInt, byte charInt)
    {
      iPart = longInt & 0x00ffffff;
      bPart = charInt;
    }

    public byte Byte
    {
      get { return bPart; }
      set { bPart = value; }
    }
    public int Integer
    {
      get { return iPart; }
      set { iPart = value & 0x00ffffff; }
    }
    public int DWord
    {
      get { return iPart | (bPart << 24); }
      set
      {
        iPart = value & 0x00ffffff;
        bPart = (byte)((value & 0xff000000) >> 24);
      }
    }
  }
}
