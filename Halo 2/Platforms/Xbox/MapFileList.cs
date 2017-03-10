using Interfaces.Games;

namespace Games.Halo2.Platforms.Xbox
{
  public partial class Halo2XboxGameDefinition
  {
    private static MapFileDefinition[] maps = new MapFileDefinition[] {
      new MapFileDefinition("00a_introduction.map", 0x5eac2a21197cebb7, 0x1d2f9fe0f52bcfa7, 113031168),
      new MapFileDefinition("01a_tutorial.map", 0x417a09e3655d4598, 0x75b8e344076ca499, 69169664),
      new MapFileDefinition("01b_spacestation.map", 0x1ae92d4881aa37c7, 0x56ddf4c672325805, 248586240),
      new MapFileDefinition("03a_oldmombasa.map", 0xd566bc62f420beba, 0x41dc80a9e20f2b30, 203507712),
      new MapFileDefinition("03b_newmombasa.map", 0x5b96858db9d42b33, 0x502994a66faa4015, 234307584),
      new MapFileDefinition("04a_gasgiant.map", 0x72c2ee3f43fc6202, 0xbd75bdc72853c9c0, 194758656),
      new MapFileDefinition("04b_floodlab.map", 0x951a0686a97cd839, 0x4461bcc910b003b4, 199387136),
      new MapFileDefinition("05a_deltaapproach.map", 0x62c22916f1655c76, 0xf0793f1a4033126c, 195034112),
      new MapFileDefinition("05b_deltatowers.map", 0xdb2327d1aee9cdd3, 0xb56afb11e426cf49, 213932032),
      new MapFileDefinition("06a_sentinelwalls.map", 0xbf96cf6fbca5ccce, 0xf7f62e5f41097f, 213370880),
      new MapFileDefinition("06b_floodzone.map", 0xcc58116baf1fa07e, 0xb5a58ebc4dce916e, 221074432),
      new MapFileDefinition("07a_highcharity.map", 0x2f9167ba224f35d, 0xa6b6b26f6cf8f8bf, 272911872),
      new MapFileDefinition("07b_forerunnership.map", 0xb8f1bd096ddf5fa7, 0x58430de1c3f48801, 180540928),
      new MapFileDefinition("08a_deltacliffs.map", 0x9338f42e084bd608, 0xabd92f636fdea634, 143452160),
      new MapFileDefinition("08b_deltacontrol.map", 0xfcbacf9f10dc64a4, 0x5c4ca8b6e05f1d0e, 262776832),
      new MapFileDefinition("ascension.map", 0x90addbe22eb599fb, 0x31ad0f4bb88b7a7d, 29735936),
      new MapFileDefinition("backwash.map", 0x6c029ce12b8d66dd, 0x8ba344396056b30b, 39166976),
      new MapFileDefinition("beavercreek.map", 0x1893fca83cf8dba, 0x570d7ddb1d1cdb34, 28942336),
      new MapFileDefinition("burial_mounds.map", 0xc3342e36e9acbcde, 0x7135538a4ce7de67, 32114688),
      new MapFileDefinition("coagulation.map", 0x40800d3b59a6d6c, 0x11023828e59cafd0, 41397248),
      new MapFileDefinition("colossus.map", 0x848160de58c4f35d, 0xf78f5f38126d499b, 31132160),
      new MapFileDefinition("containment.map", 0x24858e02a20fd986, 0x13b5a8d91d1dc018, 49906688),
      new MapFileDefinition("cyclotron.map", 0x1f602d4d078bd2eb, 0xe3d378759baec698, 46205952),
      new MapFileDefinition("deltatap.map", 0x2d2c2ca4453cbe32, 0xdfb93d04e8f12308, 45100032),
      new MapFileDefinition("derelict.map", 0x3953141c59cc7241, 0x21578e88b0a46f78, 71289856), // Paid Content
      new MapFileDefinition("dune.map", 0xfe8a1a3801361de, 0x5b857472597b8ace, 43298816),
      new MapFileDefinition("elongation.map", 0x2d8a177a3216b638, 0x47b421b9463415d8, 42241024),
      new MapFileDefinition("foundation.map", 0xc70b68861c99f2, 0xeb6badb6b2c9edeb, 37599232),
      new MapFileDefinition("gemini.map", 0x9630e808f1aeec95, 0xc63d8d6c2fc29061, 49779712),
      new MapFileDefinition("headlong.map", 0x8e23d79d4cc64ac3, 0xb510e66bdbae9ea3, 56096256),
      new MapFileDefinition("highplains.map", 0x80c24b7b4de00873, 0x13af63b7e19947c3, 77358080), // Paid Content
      new MapFileDefinition("lockout.map", 0xe73ba305cdff2076, 0xa26f1489b275632e, 34523136),
      new MapFileDefinition("mainmenu.map", 0xe3478a159628fcd8, 0xd69b6884ede32e75, 59670016),
      new MapFileDefinition("midship.map", 0x7a1ab86219d26309, 0xe026e7fcead4ce8, 30519808),
      new MapFileDefinition("triplicate.map", 0xc2370141db9c7520, 0x7fc2537746b265d1, 57669120),
      new MapFileDefinition("turf.map", 0xd339d3b9f29def19, 0x26fc7dbba0ad183d, 57911296),
      new MapFileDefinition("warlock.map", 0x9f8b202d781a3a04, 0x6cee228ed96e5288, 44257280),
      new MapFileDefinition("waterworks.map", 0x19d5cf427d366829, 0x5038edcb16d4ad7e, 41352704),
      new MapFileDefinition("zanzibar.map", 0xddcb3f9145bf48a7, 0x5fbb2babfbfdb103, 53547008) };

    /// <summary>
    /// Returns a list of the map files that are included with this game.
    /// </summary>
    public override MapFileDefinition[] Maps
    {
      get { return maps; }
    }
  }
}