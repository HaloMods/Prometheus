using Interfaces.Games;

namespace Games.Halo.Platforms.CE
{
  public partial class HaloCEGameDefinition
  {
    private static MapFileDefinition[] maps = new MapFileDefinition[] {
      new MapFileDefinition("beavercreek.map", 0, 0, 0),
      new MapFileDefinition("bloodgulch.map", 0, 0, 0),
      new MapFileDefinition("boardingaction.map", 0, 0, 0),
      new MapFileDefinition("carousel.map", 0, 0, 0),
      new MapFileDefinition("chillout.map", 0, 0, 0),
      new MapFileDefinition("damnation.map", 0, 0, 0),
      new MapFileDefinition("dangercanyon.map", 0, 0, 0),
      new MapFileDefinition("deathisland.map", 0, 0, 0),
      new MapFileDefinition("gephyrophobia.map", 0, 0, 0),
      new MapFileDefinition("hangemhigh.map", 0, 0, 0),
      new MapFileDefinition("icefields.map", 0, 0, 0),
      new MapFileDefinition("infinity.map", 0, 0, 0),
      new MapFileDefinition("longest.map", 0, 0, 0),
      new MapFileDefinition("prisoner.map", 0, 0, 0),
      new MapFileDefinition("putput.map", 0, 0, 0),
      new MapFileDefinition("ratrace.map", 0, 0, 0),
      new MapFileDefinition("sidewinder.map", 0, 0, 0),
      new MapFileDefinition("timberland.map", 0, 0, 0),
      new MapFileDefinition("ui.map", 0, 0, 0),
      new MapFileDefinition("wizard.map", 0, 0, 0) };
      
    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public override MapFileDefinition[] Maps
    {
      get { return maps; }
    }
  }
}