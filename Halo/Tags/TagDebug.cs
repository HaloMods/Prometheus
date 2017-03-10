using System;
using System.Diagnostics;
using Games.Halo.Tags.Fields;

namespace Games.Halo.Tags
{
  public class TagDebug
  {
    public static bool EnableReadDebug = false;

    public static void CheckOffset(long actualPos, Block block, string collectionName)
    {
      /*Trace.WriteLine(string.Format("\r\nLoading {0} blocks: {1}", block.Count, collectionName));
      if (block.Count != 0)
      {
        if (actualPos != block.Offset)
        {
          Trace.WriteLine(string.Format("{0} Out of Sync.  Desired Offset: {1:X} Actual Offset: {2:X}", collectionName, block.Offset + 0x40, (int)actualPos));
          throw new HaloException("{0} Out of Sync.  Desired Offset: {1:X} Actual Offset: {2:X}", collectionName, block.Offset + 0x40, (int)actualPos);
        }
      }*/
    }
  }
}
