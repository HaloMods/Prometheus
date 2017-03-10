using System;
using System.IO;

namespace Games.Halo2.Platforms.Shared
{
  /// <summary>
  /// Acts as a container for the three shared maps that Halo 2 uses.
  /// </summary>
  public class SharedMaps : IDisposable
  {
    private BinaryReader mainMenu;
    private BinaryReader shared;
    private BinaryReader singlePlayerShared;

    public SharedMaps(Stream mainMenu, Stream shared, Stream singlePlayerShared)
    {
      this.mainMenu = new BinaryReader(mainMenu);
      this.shared = new BinaryReader(shared);
      this.singlePlayerShared = new BinaryReader(singlePlayerShared);
    }

    public BinaryReader MainMenu
    {
      get
      { return mainMenu; }
    }

    public BinaryReader Shared
    {
      get
      { return shared; }
    }

    public BinaryReader SinglePlayerShared
    {
      get
      { return singlePlayerShared; }
    }

    public BinaryReader GetMap(int offset, BinaryReader internalMap)
    {
      if (offset == 0 || offset == -1)
        return null;

      if ((offset & 0xc0000000) == 0xc0000000)
      {
        singlePlayerShared.BaseStream.Position = offset & ~0xc0000000;
        return singlePlayerShared;
      }
      else if ((offset & 0x80000000) == 0x80000000)
      {
        shared.BaseStream.Position = offset & ~0x80000000;
        return shared;
      }
      else if ((offset & 0x40000000) == 0x40000000)
      {
        mainMenu.BaseStream.Position = offset & ~0x40000000;
        return mainMenu;
      }
      else
      {
        internalMap.BaseStream.Position = offset;
        return internalMap;
      }
    }

    public void Dispose()
    {
      if (mainMenu != null)
        mainMenu.Close();
      if (shared != null)
        shared.Close();
      if (singlePlayerShared != null)
        singlePlayerShared.Close();
    }
  }
}
