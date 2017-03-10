using System;
using System.Collections;

namespace Games.Halo.Platforms.Shared
{
  public struct PointerList
  {
    public int Count;
    public ArrayList Locations;
    public ArrayList Destinations;

    public PointerList(ArrayList locs, ArrayList dests)
    {
      int lCount = locs.Count;
      int dCount = dests.Count;
      if (lCount != dCount)
        throw new Exception("PointerList location count and destination count did not match.");
      Count = lCount;
      Locations = locs;
      Destinations = dests;
    }
  }
}
