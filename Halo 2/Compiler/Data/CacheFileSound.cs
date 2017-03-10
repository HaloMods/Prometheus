using System;
using System.Runtime.InteropServices;

namespace Games.Halo2.Compiler.Data
{
  [StructLayout(LayoutKind.Sequential)]
  public struct CacheFileSound
  {
    public short Flags;
    public byte Class;
    public byte SampleRate;
    public byte Channels;
    public byte Compression;
    public short PlaybackIndex;
    public short PitchRangeIndex;
    public byte PitchRangeCount;
    public sbyte ScaleIndex;
    public sbyte PromotionIndex;
    public sbyte CustomPlaybackIndex;
    public short ExtraInfoIndex;
    public int MaximumPlaybackTime;
  }
}
