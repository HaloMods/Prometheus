using System;

namespace Interfaces.DynamicInterface.SceneInstanceMenu
{
  [Flags]
  public enum PaletteTarget
  {
    Campaign = 0x1,
    Multiplayer = 0x2,
    UI = 0x4,
  }
}
