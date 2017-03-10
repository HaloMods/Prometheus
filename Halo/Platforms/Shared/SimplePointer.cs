using System;
using System.Collections;

namespace Games.Halo.Platforms.Shared
{
  public struct SimplePointer
  {
    public int Location;
    public uint Offset;

    public SimplePointer(int location, uint offset)
    {
      Location = location;
      Offset = offset;
    }
  }
}
