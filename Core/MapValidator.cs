using System;
using Interfaces.Games;

namespace Core
{
  public class MapValidator
  {
    public bool Validate(IMapFile map, MapFileDefinition definition)
    {
      byte[] checksum = map.CalculateChecksum();
      ulong low = BitConverter.ToUInt64(checksum, 0);
      ulong high = BitConverter.ToUInt64(checksum, 8);
      
      // NOTE: We can also check the file size here as well, if we add
      // a property for it to the IMapFile interface.
      return (low == definition.LowChecksum && high == definition.HighChecksum);
    }
  }
}
