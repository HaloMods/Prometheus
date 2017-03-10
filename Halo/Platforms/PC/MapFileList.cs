using Interfaces.Games;

namespace Games.Halo.Platforms.PC
{
  public partial class HaloPCGameDefinition
  {
    private static MapFileDefinition[] maps = new MapFileDefinition[] {
      new MapFileDefinition("a10.map", 0xfbac00d0e3f0a78, 0x84636f155a3eefdc, 96204544),
      new MapFileDefinition("a30.map", 0xc2096f1ba1c8c0a2, 0xebd4fe48518f471d, 37983992),
      new MapFileDefinition("a50.map", 0x8e8e2864757ecf7d, 0xd646b01bbaec7f92, 54161584),
      new MapFileDefinition("b30.map", 0x4e2cdb8bfe53e9e7, 0xd9f18732a7377e3, 35867568),
      new MapFileDefinition("b40.map", 0x185c3c1b1ff3f0a7, 0x107f8741447b7a2b, 78518512),
      new MapFileDefinition("beavercreek.map", 0x61d2b0bd9140bd4b, 0x52c44606127925b, 13523732),
      new MapFileDefinition("bloodgulch.map", 0x4ae9d9c3c98d6423, 0xcd11668cff154678, 14366196),
      new MapFileDefinition("boardingaction.map", 0x6ed2cfa92746df9a, 0x9b150590fcb5b4eb, 14391176),
      new MapFileDefinition("c10.map", 0xc1b294522141eed3, 0x627781d0e73763ac, 62692332),
      new MapFileDefinition("c20.map", 0xe66ed72529c9afca, 0x4f2069251dbdeb25, 54887340),
      new MapFileDefinition("c40.map", 0x9d7101093715d533, 0x782dceedf7885253, 78695184),
      new MapFileDefinition("carousel.map", 0xc55cb79920c3de27, 0x33209e8f8401ddd0, 13067272),
      new MapFileDefinition("chillout.map", 0x6e4eacb1ad53b759, 0x124c2be709116c2f, 13143548),
      new MapFileDefinition("d20.map", 0x83133266ae6b0e7e, 0xba5010c0424e4166, 60737400),
      new MapFileDefinition("d40.map", 0x46f6e55ec605f963, 0x6038e1191db09403, 93673248),
      new MapFileDefinition("damnation.map", 0x187c25fbeafcc77e, 0xea1d45593f6ab470, 14443048),
      new MapFileDefinition("dangercanyon.map", 0x6d9140b7811503a7, 0x4193f11f5ab98e02, 15603496),
      new MapFileDefinition("deathisland.map", 0x75a79b657690488d, 0xe3512d0e219a141f, 18600388),
      new MapFileDefinition("gephyrophobia.map", 0x8e701f1a783f3caf, 0x168c46b461d7ce46, 16016056),
      new MapFileDefinition("hangemhigh.map", 0x7a9887f2262ba7ef, 0x29c946490d4aa5ec, 13148752),
      new MapFileDefinition("icefields.map", 0xc329f65beb19bac0, 0xf420593ef45190ac, 16288564),
      new MapFileDefinition("infinity.map", 0x4ac448e752985822, 0x67a9c9eb4ddaec19, 18766652),
      new MapFileDefinition("longest.map", 0x3d494a873d52e5fd, 0x3cad643b7907e7d9, 12954884),
      new MapFileDefinition("prisoner.map", 0xf1a9b6e8779929d4, 0xc8977b81bc6148d1, 13592184),
      new MapFileDefinition("putput.map", 0x51ec22cf748c06f, 0xb5d0e93e53c021d6, 14591056),
      new MapFileDefinition("ratrace.map", 0x978f4f0ad481c328, 0x8f0925091aab58fc, 13192776),
      new MapFileDefinition("sidewinder.map", 0x746bc69b205593ca, 0xd1af2717401d1249, 15274608),
      new MapFileDefinition("timberland.map", 0x577cc6e73e4c0445, 0xc3574ea5ff9cab50, 15122900),
      new MapFileDefinition("ui.map", 0xea6211f89c2b45d9, 0xde159c63d5c13a01, 2556428),
      new MapFileDefinition("wizard.map", 0xed591c8bee5fe25b, 0x494d550dd006c71e, 13152136) };
      
    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public override MapFileDefinition[] Maps
    {
      get { return maps; }
    }
  }
}