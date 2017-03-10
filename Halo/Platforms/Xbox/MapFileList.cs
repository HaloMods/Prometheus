using Interfaces.Games;

namespace Games.Halo.Platforms.Xbox
{
  public partial class HaloXboxGameDefinition
  {
    private static MapFileDefinition[] maps = new MapFileDefinition[] {
      new MapFileDefinition("a10.map", 0x3c1a06adfdd1dca9, 0xd5c91c78d8fbb7a8, 274734080),
      new MapFileDefinition("a30.map", 0x8f779d86406d0594, 0xa448e05c6975b705, 213065216),
      new MapFileDefinition("a50.map", 0x7e23322c2bb4b3d3, 0xc3b8883e1ef5aeef, 250138624),
      new MapFileDefinition("b30.map", 0x8b3039b3bf86732d, 0xadc355378abd6135, 224887296),
      new MapFileDefinition("b40.map", 0xe81a2c5155fd20cf, 0xf2f3c2dc0af31deb, 279763456),
      new MapFileDefinition("beavercreek.map", 0x32457feaed64093f, 0x637f25d3335c0ae6, 43565056),
      new MapFileDefinition("bloodgulch.map", 0x8619a403e4c420d5, 0x93bfd6c69430ac2f, 44328960),
      new MapFileDefinition("boardingaction.map", 0x983b16bd6ddc8a42, 0x88d3a0c36f9ad2d, 45346304),
      new MapFileDefinition("c10.map", 0x7aef593f63f4c382, 0xbae0bde02ffeaa4d, 252559360),
      new MapFileDefinition("c20.map", 0xe78dc3ab1062ca0, 0xc914f335f62ec3dc, 142009856),
      new MapFileDefinition("c40.map", 0x2dce87781e042927, 0x6a44c1f316dded64, 255975936),
      new MapFileDefinition("carousel.map", 0x1fade9aa1acdfdb9, 0x2f39c35495dff9b7, 42367488),
      new MapFileDefinition("chillout.map", 0xba9545c283b7d7be, 0x39788d02e02acf7d, 41967104),
      new MapFileDefinition("d20.map", 0x2c4a376f184a80e4, 0x4344da6b25c3c443, 205501952),
      new MapFileDefinition("d40.map", 0xd78a74a36304933e, 0xe353f4f6231e7242, 274594816),
      new MapFileDefinition("damnation.map", 0xd9ccff8736d6099b, 0x88aafdb33f9a908e, 47968768),
      new MapFileDefinition("hangemhigh.map", 0xd72d20dc4a9a02d7, 0xd0fb492f7a74e28d, 43700224),
      new MapFileDefinition("longest.map", 0x921a67130665f564, 0x7c2c4a32f09cbd6d, 42141696),
      new MapFileDefinition("prisoner.map", 0x85c997e15b92c495, 0xb2bd93a578e795d4, 43974656),
      new MapFileDefinition("putput.map", 0x12ef08253f27e0a6, 0xda368bda988070d9, 40668672),
      new MapFileDefinition("ratrace.map", 0x2c729a0783645666, 0x1285f3221c5f84e2, 47403008),
      new MapFileDefinition("sidewinder.map", 0x8b94264feaace4df, 0x6e9c78e9c4437da1, 48048128),
      new MapFileDefinition("ui.map", 0x4fbbe8ad2160b161, 0xe58bcd40ddc423ce, 33582080),
      new MapFileDefinition("wizard.map", 0xbc3590395de320a7, 0x9911311520be8861, 40681984) };
      
    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public override MapFileDefinition[] Maps
    {
      get { return maps; }
    }
  }
}