using System;

namespace Interfaces.Rendering.Selection
{
  public enum TargetType
  {
    None = 0,

    LevelMesh,
    Object,
    PlayerSpawn,
    NetgameFlag,
    NetgameEquipment,

    Custom = -1
  }
}
