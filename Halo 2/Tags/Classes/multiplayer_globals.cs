// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'multiplayer_globals'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class multiplayer_globals : Interfaces.Pool.Tag {
    private MultiplayerGlobalsBlockBlock multiplayerGlobalsValues = new MultiplayerGlobalsBlockBlock();
    public virtual MultiplayerGlobalsBlockBlock MultiplayerGlobalsValues {
      get {
        return multiplayerGlobalsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MultiplayerGlobalsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "multiplayer_globals";
      }
    }
    #region Read/Write Methods
    public override int Load(byte[] metadata) {
      System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.MemoryStream(metadata));
Read(reader);
int position = (int)reader.BaseStream.Position;
ReadChildData(reader);
reader.Close();
      return position;
    }
    public override void Read(BinaryReader reader) {
multiplayerGlobalsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
multiplayerGlobalsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
multiplayerGlobalsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
multiplayerGlobalsValues.WriteChildData(writer);
    }
    #endregion
    public class MultiplayerGlobalsBlockBlock : IBlock {
      private Block _universal = new Block();
      private Block _runtime = new Block();
      public BlockCollection<MultiplayerUniversalBlockBlock> _universalList = new BlockCollection<MultiplayerUniversalBlockBlock>();
      public BlockCollection<MultiplayerRuntimeBlockBlock> _runtimeList = new BlockCollection<MultiplayerRuntimeBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerGlobalsBlockBlock() {
      }
      public BlockCollection<MultiplayerUniversalBlockBlock> Universal {
        get {
          return this._universalList;
        }
      }
      public BlockCollection<MultiplayerRuntimeBlockBlock> Runtime {
        get {
          return this._runtimeList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Universal.BlockCount; x++)
{
  IBlock block = Universal.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Runtime.BlockCount; x++)
{
  IBlock block = Runtime.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
        _universal.Read(reader);
        _runtime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _universal.Count); x = (x + 1)) {
          Universal.Add(new MultiplayerUniversalBlockBlock());
          Universal[x].Read(reader);
        }
        for (x = 0; (x < _universal.Count); x = (x + 1)) {
          Universal[x].ReadChildData(reader);
        }
        for (x = 0; (x < _runtime.Count); x = (x + 1)) {
          Runtime.Add(new MultiplayerRuntimeBlockBlock());
          Runtime[x].Read(reader);
        }
        for (x = 0; (x < _runtime.Count); x = (x + 1)) {
          Runtime[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_universal.Count = Universal.Count;
        _universal.Write(bw);
_runtime.Count = Runtime.Count;
        _runtime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _universal.Count); x = (x + 1)) {
          Universal[x].Write(writer);
        }
        for (x = 0; (x < _universal.Count); x = (x + 1)) {
          Universal[x].WriteChildData(writer);
        }
        for (x = 0; (x < _runtime.Count); x = (x + 1)) {
          Runtime[x].Write(writer);
        }
        for (x = 0; (x < _runtime.Count); x = (x + 1)) {
          Runtime[x].WriteChildData(writer);
        }
      }
    }
    public class MultiplayerUniversalBlockBlock : IBlock {
      private TagReference _randomPlayerNames = new TagReference();
      private TagReference _teamNames = new TagReference();
      private Block _teamColors = new Block();
      private TagReference _multiplayerText = new TagReference();
      public BlockCollection<MultiplayerColorBlockBlock> _teamColorsList = new BlockCollection<MultiplayerColorBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerUniversalBlockBlock() {
      }
      public BlockCollection<MultiplayerColorBlockBlock> TeamColors {
        get {
          return this._teamColorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_randomPlayerNames.Value);
references.Add(_teamNames.Value);
references.Add(_multiplayerText.Value);
for (int x=0; x<TeamColors.BlockCount; x++)
{
  IBlock block = TeamColors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference RandomPlayerNames {
        get {
          return this._randomPlayerNames;
        }
        set {
          this._randomPlayerNames = value;
        }
      }
      public TagReference TeamNames {
        get {
          return this._teamNames;
        }
        set {
          this._teamNames = value;
        }
      }
      public TagReference MultiplayerText {
        get {
          return this._multiplayerText;
        }
        set {
          this._multiplayerText = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _randomPlayerNames.Read(reader);
        _teamNames.Read(reader);
        _teamColors.Read(reader);
        _multiplayerText.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _randomPlayerNames.ReadString(reader);
        _teamNames.ReadString(reader);
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors.Add(new MultiplayerColorBlockBlock());
          TeamColors[x].Read(reader);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].ReadChildData(reader);
        }
        _multiplayerText.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _randomPlayerNames.Write(bw);
        _teamNames.Write(bw);
_teamColors.Count = TeamColors.Count;
        _teamColors.Write(bw);
        _multiplayerText.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _randomPlayerNames.WriteString(writer);
        _teamNames.WriteString(writer);
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].Write(writer);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].WriteChildData(writer);
        }
        _multiplayerText.WriteString(writer);
      }
    }
    public class MultiplayerColorBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public MultiplayerColorBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MultiplayerRuntimeBlockBlock : IBlock {
      private TagReference _flag = new TagReference();
      private TagReference _ball = new TagReference();
      private TagReference _unit = new TagReference();
      private TagReference _flagShader = new TagReference();
      private TagReference _hillShader = new TagReference();
      private TagReference _head = new TagReference();
      private TagReference _juggernautPowerup = new TagReference();
      private TagReference _daBomb = new TagReference();
      private TagReference _unnamed0 = new TagReference();
      private TagReference _unnamed1 = new TagReference();
      private TagReference _unnamed2 = new TagReference();
      private TagReference _unnamed3 = new TagReference();
      private TagReference _unnamed4 = new TagReference();
      private Block _weapons = new Block();
      private Block _vehicles = new Block();
      private Block _grenades = new Block();
      private Block _powerups = new Block();
      private TagReference _inGameText = new TagReference();
      private Block _sounds = new Block();
      private Block _generalEvents = new Block();
      private Block _flavorEvents = new Block();
      private Block _slayerEvents = new Block();
      private Block _ctfEvents = new Block();
      private Block _oddballEvents = new Block();
      private Block _unnamed5 = new Block();
      private Block _kingEvents = new Block();
      private Block _unnamed6 = new Block();
      private Block _juggernautEvents = new Block();
      private Block _territoriesEvents = new Block();
      private Block _invasionEvents = new Block();
      private Block _unnamed7 = new Block();
      private Block _unnamed8 = new Block();
      private Block _unnamed9 = new Block();
      private Block _unnamed10 = new Block();
      private TagReference _defaultItemCollection1 = new TagReference();
      private TagReference _defaultItemCollection2 = new TagReference();
      private LongInteger _defaultFragGrenadeCount = new LongInteger();
      private LongInteger _defaultPlasmaGrenadeCount = new LongInteger();
      private Pad _unnamed11;
      private Real _dynamicZoneUpperHeight = new Real();
      private Real _dynamicZoneLowerHeight = new Real();
      private Pad _unnamed12;
      private Real _enemyInnerRadius = new Real();
      private Real _enemyOuterRadius = new Real();
      private Real _enemyWeight = new Real();
      private Pad _unnamed13;
      private Real _friendInnerRadius = new Real();
      private Real _friendOuterRadius = new Real();
      private Real _friendWeight = new Real();
      private Pad _unnamed14;
      private Real _enemyVehicleInnerRadius = new Real();
      private Real _enemyVehicleOuterRadius = new Real();
      private Real _enemyVehicleWeight = new Real();
      private Pad _unnamed15;
      private Real _friendlyVehicleInnerRadius = new Real();
      private Real _friendlyVehicleOuterRadius = new Real();
      private Real _friendlyVehicleWeight = new Real();
      private Pad _unnamed16;
      private Real _emptyVehicleInnerRadius = new Real();
      private Real _emptyVehicleOuterRadius = new Real();
      private Real _emptyVehicleWeight = new Real();
      private Pad _unnamed17;
      private Real _oddballInclusionInnerRadius = new Real();
      private Real _oddballInclusionOuterRadius = new Real();
      private Real _oddballInclusionWeight = new Real();
      private Pad _unnamed18;
      private Real _oddballExclusionInnerRadius = new Real();
      private Real _oddballExclusionOuterRadius = new Real();
      private Real _oddballExclusionWeight = new Real();
      private Pad _unnamed19;
      private Real _hillInclusionInnerRadius = new Real();
      private Real _hillInclusionOuterRadius = new Real();
      private Real _hillInclusionWeight = new Real();
      private Pad _unnamed20;
      private Real _hillExclusionInnerRadius = new Real();
      private Real _hillExclusionOuterRadius = new Real();
      private Real _hillExclusionWeight = new Real();
      private Pad _unnamed21;
      private Real _lastRaceFlagInnerRadius = new Real();
      private Real _lastRaceFlagOuterRadius = new Real();
      private Real _lastRaceFlagWeight = new Real();
      private Pad _unnamed22;
      private Real _deadAllyInnerRadius = new Real();
      private Real _deadAllyOuterRadius = new Real();
      private Real _deadAllyWeight = new Real();
      private Pad _unnamed23;
      private Real _controlledTerritoryInnerRadius = new Real();
      private Real _controlledTerritoryOuterRadius = new Real();
      private Real _controlledTerritoryWeight = new Real();
      private Pad _unnamed24;
      private Pad _unnamed25;
      private Pad _unnamed26;
      private Block _multiplayerConstants = new Block();
      private Block _stateResponses = new Block();
      private TagReference _scoreboardHudDefinition = new TagReference();
      private TagReference _scoreboardEmblemShader = new TagReference();
      private TagReference _scoreboardEmblemBitmap = new TagReference();
      private TagReference _scoreboardDeadEmblemShader = new TagReference();
      private TagReference _scoreboardDeadEmblemBitmap = new TagReference();
      public BlockCollection<WeaponsBlockBlock> _weaponsList = new BlockCollection<WeaponsBlockBlock>();
      public BlockCollection<VehiclesBlockBlock> _vehiclesList = new BlockCollection<VehiclesBlockBlock>();
      public BlockCollection<GrenadeBlockBlock> _grenadesList = new BlockCollection<GrenadeBlockBlock>();
      public BlockCollection<PowerupBlockBlock> _powerupsList = new BlockCollection<PowerupBlockBlock>();
      public BlockCollection<SoundsBlockBlock> _soundsList = new BlockCollection<SoundsBlockBlock>();
      public BlockCollection<GameEngineGeneralEventBlockBlock> _generalEventsList = new BlockCollection<GameEngineGeneralEventBlockBlock>();
      public BlockCollection<GameEngineFlavorEventBlockBlock> _flavorEventsList = new BlockCollection<GameEngineFlavorEventBlockBlock>();
      public BlockCollection<GameEngineSlayerEventBlockBlock> _slayerEventsList = new BlockCollection<GameEngineSlayerEventBlockBlock>();
      public BlockCollection<GameEngineCtfEventBlockBlock> _ctfEventsList = new BlockCollection<GameEngineCtfEventBlockBlock>();
      public BlockCollection<GameEngineOddballEventBlockBlock> _oddballEventsList = new BlockCollection<GameEngineOddballEventBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed5List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GameEngineKingEventBlockBlock> _kingEventsList = new BlockCollection<GameEngineKingEventBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed6List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GameEngineJuggernautEventBlockBlock> _juggernautEventsList = new BlockCollection<GameEngineJuggernautEventBlockBlock>();
      public BlockCollection<GameEngineTerritoriesEventBlockBlock> _territoriesEventsList = new BlockCollection<GameEngineTerritoriesEventBlockBlock>();
      public BlockCollection<GameEngineAssaultEventBlockBlock> _invasionEventsList = new BlockCollection<GameEngineAssaultEventBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed7List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed8List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed9List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed10List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<MultiplayerConstantsBlockBlock> _multiplayerConstantsList = new BlockCollection<MultiplayerConstantsBlockBlock>();
      public BlockCollection<GameEngineStatusResponseBlockBlock> _stateResponsesList = new BlockCollection<GameEngineStatusResponseBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerRuntimeBlockBlock() {
        this._unnamed11 = new Pad(40);
        this._unnamed12 = new Pad(40);
        this._unnamed13 = new Pad(16);
        this._unnamed14 = new Pad(16);
        this._unnamed15 = new Pad(16);
        this._unnamed16 = new Pad(16);
        this._unnamed17 = new Pad(16);
        this._unnamed18 = new Pad(16);
        this._unnamed19 = new Pad(16);
        this._unnamed20 = new Pad(16);
        this._unnamed21 = new Pad(16);
        this._unnamed22 = new Pad(16);
        this._unnamed23 = new Pad(16);
        this._unnamed24 = new Pad(16);
        this._unnamed25 = new Pad(560);
        this._unnamed26 = new Pad(48);
      }
      public BlockCollection<WeaponsBlockBlock> Weapons {
        get {
          return this._weaponsList;
        }
      }
      public BlockCollection<VehiclesBlockBlock> Vehicles {
        get {
          return this._vehiclesList;
        }
      }
      public BlockCollection<GrenadeBlockBlock> Grenades {
        get {
          return this._grenadesList;
        }
      }
      public BlockCollection<PowerupBlockBlock> Powerups {
        get {
          return this._powerupsList;
        }
      }
      public BlockCollection<SoundsBlockBlock> Sounds {
        get {
          return this._soundsList;
        }
      }
      public BlockCollection<GameEngineGeneralEventBlockBlock> GeneralEvents {
        get {
          return this._generalEventsList;
        }
      }
      public BlockCollection<GameEngineFlavorEventBlockBlock> FlavorEvents {
        get {
          return this._flavorEventsList;
        }
      }
      public BlockCollection<GameEngineSlayerEventBlockBlock> SlayerEvents {
        get {
          return this._slayerEventsList;
        }
      }
      public BlockCollection<GameEngineCtfEventBlockBlock> CtfEvents {
        get {
          return this._ctfEventsList;
        }
      }
      public BlockCollection<GameEngineOddballEventBlockBlock> OddballEvents {
        get {
          return this._oddballEventsList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed5 {
        get {
          return this._unnamed5List;
        }
      }
      public BlockCollection<GameEngineKingEventBlockBlock> KingEvents {
        get {
          return this._kingEventsList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed6 {
        get {
          return this._unnamed6List;
        }
      }
      public BlockCollection<GameEngineJuggernautEventBlockBlock> JuggernautEvents {
        get {
          return this._juggernautEventsList;
        }
      }
      public BlockCollection<GameEngineTerritoriesEventBlockBlock> TerritoriesEvents {
        get {
          return this._territoriesEventsList;
        }
      }
      public BlockCollection<GameEngineAssaultEventBlockBlock> InvasionEvents {
        get {
          return this._invasionEventsList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed7 {
        get {
          return this._unnamed7List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed8 {
        get {
          return this._unnamed8List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed9 {
        get {
          return this._unnamed9List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed10 {
        get {
          return this._unnamed10List;
        }
      }
      public BlockCollection<MultiplayerConstantsBlockBlock> MultiplayerConstants {
        get {
          return this._multiplayerConstantsList;
        }
      }
      public BlockCollection<GameEngineStatusResponseBlockBlock> StateResponses {
        get {
          return this._stateResponsesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_flag.Value);
references.Add(_ball.Value);
references.Add(_unit.Value);
references.Add(_flagShader.Value);
references.Add(_hillShader.Value);
references.Add(_head.Value);
references.Add(_juggernautPowerup.Value);
references.Add(_daBomb.Value);
references.Add(_unnamed0.Value);
references.Add(_unnamed1.Value);
references.Add(_unnamed2.Value);
references.Add(_unnamed3.Value);
references.Add(_unnamed4.Value);
references.Add(_inGameText.Value);
references.Add(_defaultItemCollection1.Value);
references.Add(_defaultItemCollection2.Value);
references.Add(_scoreboardHudDefinition.Value);
references.Add(_scoreboardEmblemShader.Value);
references.Add(_scoreboardEmblemBitmap.Value);
references.Add(_scoreboardDeadEmblemShader.Value);
references.Add(_scoreboardDeadEmblemBitmap.Value);
for (int x=0; x<Weapons.BlockCount; x++)
{
  IBlock block = Weapons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vehicles.BlockCount; x++)
{
  IBlock block = Vehicles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Grenades.BlockCount; x++)
{
  IBlock block = Grenades.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Powerups.BlockCount; x++)
{
  IBlock block = Powerups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sounds.BlockCount; x++)
{
  IBlock block = Sounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GeneralEvents.BlockCount; x++)
{
  IBlock block = GeneralEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FlavorEvents.BlockCount; x++)
{
  IBlock block = FlavorEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SlayerEvents.BlockCount; x++)
{
  IBlock block = SlayerEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CtfEvents.BlockCount; x++)
{
  IBlock block = CtfEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OddballEvents.BlockCount; x++)
{
  IBlock block = OddballEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed5.BlockCount; x++)
{
  IBlock block = Unnamed5.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<KingEvents.BlockCount; x++)
{
  IBlock block = KingEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed6.BlockCount; x++)
{
  IBlock block = Unnamed6.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<JuggernautEvents.BlockCount; x++)
{
  IBlock block = JuggernautEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TerritoriesEvents.BlockCount; x++)
{
  IBlock block = TerritoriesEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InvasionEvents.BlockCount; x++)
{
  IBlock block = InvasionEvents.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed7.BlockCount; x++)
{
  IBlock block = Unnamed7.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed8.BlockCount; x++)
{
  IBlock block = Unnamed8.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed9.BlockCount; x++)
{
  IBlock block = Unnamed9.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed10.BlockCount; x++)
{
  IBlock block = Unnamed10.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultiplayerConstants.BlockCount; x++)
{
  IBlock block = MultiplayerConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StateResponses.BlockCount; x++)
{
  IBlock block = StateResponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Flag {
        get {
          return this._flag;
        }
        set {
          this._flag = value;
        }
      }
      public TagReference Ball {
        get {
          return this._ball;
        }
        set {
          this._ball = value;
        }
      }
      public TagReference Unit {
        get {
          return this._unit;
        }
        set {
          this._unit = value;
        }
      }
      public TagReference FlagShader {
        get {
          return this._flagShader;
        }
        set {
          this._flagShader = value;
        }
      }
      public TagReference HillShader {
        get {
          return this._hillShader;
        }
        set {
          this._hillShader = value;
        }
      }
      public TagReference Head {
        get {
          return this._head;
        }
        set {
          this._head = value;
        }
      }
      public TagReference JuggernautPowerup {
        get {
          return this._juggernautPowerup;
        }
        set {
          this._juggernautPowerup = value;
        }
      }
      public TagReference DaBomb {
        get {
          return this._daBomb;
        }
        set {
          this._daBomb = value;
        }
      }
      public TagReference unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public TagReference unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public TagReference unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public TagReference unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public TagReference unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public TagReference InGameText {
        get {
          return this._inGameText;
        }
        set {
          this._inGameText = value;
        }
      }
      public TagReference DefaultItemCollection1 {
        get {
          return this._defaultItemCollection1;
        }
        set {
          this._defaultItemCollection1 = value;
        }
      }
      public TagReference DefaultItemCollection2 {
        get {
          return this._defaultItemCollection2;
        }
        set {
          this._defaultItemCollection2 = value;
        }
      }
      public LongInteger DefaultFragGrenadeCount {
        get {
          return this._defaultFragGrenadeCount;
        }
        set {
          this._defaultFragGrenadeCount = value;
        }
      }
      public LongInteger DefaultPlasmaGrenadeCount {
        get {
          return this._defaultPlasmaGrenadeCount;
        }
        set {
          this._defaultPlasmaGrenadeCount = value;
        }
      }
      public Real DynamicZoneUpperHeight {
        get {
          return this._dynamicZoneUpperHeight;
        }
        set {
          this._dynamicZoneUpperHeight = value;
        }
      }
      public Real DynamicZoneLowerHeight {
        get {
          return this._dynamicZoneLowerHeight;
        }
        set {
          this._dynamicZoneLowerHeight = value;
        }
      }
      public Real EnemyInnerRadius {
        get {
          return this._enemyInnerRadius;
        }
        set {
          this._enemyInnerRadius = value;
        }
      }
      public Real EnemyOuterRadius {
        get {
          return this._enemyOuterRadius;
        }
        set {
          this._enemyOuterRadius = value;
        }
      }
      public Real EnemyWeight {
        get {
          return this._enemyWeight;
        }
        set {
          this._enemyWeight = value;
        }
      }
      public Real FriendInnerRadius {
        get {
          return this._friendInnerRadius;
        }
        set {
          this._friendInnerRadius = value;
        }
      }
      public Real FriendOuterRadius {
        get {
          return this._friendOuterRadius;
        }
        set {
          this._friendOuterRadius = value;
        }
      }
      public Real FriendWeight {
        get {
          return this._friendWeight;
        }
        set {
          this._friendWeight = value;
        }
      }
      public Real EnemyVehicleInnerRadius {
        get {
          return this._enemyVehicleInnerRadius;
        }
        set {
          this._enemyVehicleInnerRadius = value;
        }
      }
      public Real EnemyVehicleOuterRadius {
        get {
          return this._enemyVehicleOuterRadius;
        }
        set {
          this._enemyVehicleOuterRadius = value;
        }
      }
      public Real EnemyVehicleWeight {
        get {
          return this._enemyVehicleWeight;
        }
        set {
          this._enemyVehicleWeight = value;
        }
      }
      public Real FriendlyVehicleInnerRadius {
        get {
          return this._friendlyVehicleInnerRadius;
        }
        set {
          this._friendlyVehicleInnerRadius = value;
        }
      }
      public Real FriendlyVehicleOuterRadius {
        get {
          return this._friendlyVehicleOuterRadius;
        }
        set {
          this._friendlyVehicleOuterRadius = value;
        }
      }
      public Real FriendlyVehicleWeight {
        get {
          return this._friendlyVehicleWeight;
        }
        set {
          this._friendlyVehicleWeight = value;
        }
      }
      public Real EmptyVehicleInnerRadius {
        get {
          return this._emptyVehicleInnerRadius;
        }
        set {
          this._emptyVehicleInnerRadius = value;
        }
      }
      public Real EmptyVehicleOuterRadius {
        get {
          return this._emptyVehicleOuterRadius;
        }
        set {
          this._emptyVehicleOuterRadius = value;
        }
      }
      public Real EmptyVehicleWeight {
        get {
          return this._emptyVehicleWeight;
        }
        set {
          this._emptyVehicleWeight = value;
        }
      }
      public Real OddballInclusionInnerRadius {
        get {
          return this._oddballInclusionInnerRadius;
        }
        set {
          this._oddballInclusionInnerRadius = value;
        }
      }
      public Real OddballInclusionOuterRadius {
        get {
          return this._oddballInclusionOuterRadius;
        }
        set {
          this._oddballInclusionOuterRadius = value;
        }
      }
      public Real OddballInclusionWeight {
        get {
          return this._oddballInclusionWeight;
        }
        set {
          this._oddballInclusionWeight = value;
        }
      }
      public Real OddballExclusionInnerRadius {
        get {
          return this._oddballExclusionInnerRadius;
        }
        set {
          this._oddballExclusionInnerRadius = value;
        }
      }
      public Real OddballExclusionOuterRadius {
        get {
          return this._oddballExclusionOuterRadius;
        }
        set {
          this._oddballExclusionOuterRadius = value;
        }
      }
      public Real OddballExclusionWeight {
        get {
          return this._oddballExclusionWeight;
        }
        set {
          this._oddballExclusionWeight = value;
        }
      }
      public Real HillInclusionInnerRadius {
        get {
          return this._hillInclusionInnerRadius;
        }
        set {
          this._hillInclusionInnerRadius = value;
        }
      }
      public Real HillInclusionOuterRadius {
        get {
          return this._hillInclusionOuterRadius;
        }
        set {
          this._hillInclusionOuterRadius = value;
        }
      }
      public Real HillInclusionWeight {
        get {
          return this._hillInclusionWeight;
        }
        set {
          this._hillInclusionWeight = value;
        }
      }
      public Real HillExclusionInnerRadius {
        get {
          return this._hillExclusionInnerRadius;
        }
        set {
          this._hillExclusionInnerRadius = value;
        }
      }
      public Real HillExclusionOuterRadius {
        get {
          return this._hillExclusionOuterRadius;
        }
        set {
          this._hillExclusionOuterRadius = value;
        }
      }
      public Real HillExclusionWeight {
        get {
          return this._hillExclusionWeight;
        }
        set {
          this._hillExclusionWeight = value;
        }
      }
      public Real LastRaceFlagInnerRadius {
        get {
          return this._lastRaceFlagInnerRadius;
        }
        set {
          this._lastRaceFlagInnerRadius = value;
        }
      }
      public Real LastRaceFlagOuterRadius {
        get {
          return this._lastRaceFlagOuterRadius;
        }
        set {
          this._lastRaceFlagOuterRadius = value;
        }
      }
      public Real LastRaceFlagWeight {
        get {
          return this._lastRaceFlagWeight;
        }
        set {
          this._lastRaceFlagWeight = value;
        }
      }
      public Real DeadAllyInnerRadius {
        get {
          return this._deadAllyInnerRadius;
        }
        set {
          this._deadAllyInnerRadius = value;
        }
      }
      public Real DeadAllyOuterRadius {
        get {
          return this._deadAllyOuterRadius;
        }
        set {
          this._deadAllyOuterRadius = value;
        }
      }
      public Real DeadAllyWeight {
        get {
          return this._deadAllyWeight;
        }
        set {
          this._deadAllyWeight = value;
        }
      }
      public Real ControlledTerritoryInnerRadius {
        get {
          return this._controlledTerritoryInnerRadius;
        }
        set {
          this._controlledTerritoryInnerRadius = value;
        }
      }
      public Real ControlledTerritoryOuterRadius {
        get {
          return this._controlledTerritoryOuterRadius;
        }
        set {
          this._controlledTerritoryOuterRadius = value;
        }
      }
      public Real ControlledTerritoryWeight {
        get {
          return this._controlledTerritoryWeight;
        }
        set {
          this._controlledTerritoryWeight = value;
        }
      }
      public TagReference ScoreboardHudDefinition {
        get {
          return this._scoreboardHudDefinition;
        }
        set {
          this._scoreboardHudDefinition = value;
        }
      }
      public TagReference ScoreboardEmblemShader {
        get {
          return this._scoreboardEmblemShader;
        }
        set {
          this._scoreboardEmblemShader = value;
        }
      }
      public TagReference ScoreboardEmblemBitmap {
        get {
          return this._scoreboardEmblemBitmap;
        }
        set {
          this._scoreboardEmblemBitmap = value;
        }
      }
      public TagReference ScoreboardDeadEmblemShader {
        get {
          return this._scoreboardDeadEmblemShader;
        }
        set {
          this._scoreboardDeadEmblemShader = value;
        }
      }
      public TagReference ScoreboardDeadEmblemBitmap {
        get {
          return this._scoreboardDeadEmblemBitmap;
        }
        set {
          this._scoreboardDeadEmblemBitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flag.Read(reader);
        _ball.Read(reader);
        _unit.Read(reader);
        _flagShader.Read(reader);
        _hillShader.Read(reader);
        _head.Read(reader);
        _juggernautPowerup.Read(reader);
        _daBomb.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _weapons.Read(reader);
        _vehicles.Read(reader);
        _grenades.Read(reader);
        _powerups.Read(reader);
        _inGameText.Read(reader);
        _sounds.Read(reader);
        _generalEvents.Read(reader);
        _flavorEvents.Read(reader);
        _slayerEvents.Read(reader);
        _ctfEvents.Read(reader);
        _oddballEvents.Read(reader);
        _unnamed5.Read(reader);
        _kingEvents.Read(reader);
        _unnamed6.Read(reader);
        _juggernautEvents.Read(reader);
        _territoriesEvents.Read(reader);
        _invasionEvents.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _defaultItemCollection1.Read(reader);
        _defaultItemCollection2.Read(reader);
        _defaultFragGrenadeCount.Read(reader);
        _defaultPlasmaGrenadeCount.Read(reader);
        _unnamed11.Read(reader);
        _dynamicZoneUpperHeight.Read(reader);
        _dynamicZoneLowerHeight.Read(reader);
        _unnamed12.Read(reader);
        _enemyInnerRadius.Read(reader);
        _enemyOuterRadius.Read(reader);
        _enemyWeight.Read(reader);
        _unnamed13.Read(reader);
        _friendInnerRadius.Read(reader);
        _friendOuterRadius.Read(reader);
        _friendWeight.Read(reader);
        _unnamed14.Read(reader);
        _enemyVehicleInnerRadius.Read(reader);
        _enemyVehicleOuterRadius.Read(reader);
        _enemyVehicleWeight.Read(reader);
        _unnamed15.Read(reader);
        _friendlyVehicleInnerRadius.Read(reader);
        _friendlyVehicleOuterRadius.Read(reader);
        _friendlyVehicleWeight.Read(reader);
        _unnamed16.Read(reader);
        _emptyVehicleInnerRadius.Read(reader);
        _emptyVehicleOuterRadius.Read(reader);
        _emptyVehicleWeight.Read(reader);
        _unnamed17.Read(reader);
        _oddballInclusionInnerRadius.Read(reader);
        _oddballInclusionOuterRadius.Read(reader);
        _oddballInclusionWeight.Read(reader);
        _unnamed18.Read(reader);
        _oddballExclusionInnerRadius.Read(reader);
        _oddballExclusionOuterRadius.Read(reader);
        _oddballExclusionWeight.Read(reader);
        _unnamed19.Read(reader);
        _hillInclusionInnerRadius.Read(reader);
        _hillInclusionOuterRadius.Read(reader);
        _hillInclusionWeight.Read(reader);
        _unnamed20.Read(reader);
        _hillExclusionInnerRadius.Read(reader);
        _hillExclusionOuterRadius.Read(reader);
        _hillExclusionWeight.Read(reader);
        _unnamed21.Read(reader);
        _lastRaceFlagInnerRadius.Read(reader);
        _lastRaceFlagOuterRadius.Read(reader);
        _lastRaceFlagWeight.Read(reader);
        _unnamed22.Read(reader);
        _deadAllyInnerRadius.Read(reader);
        _deadAllyOuterRadius.Read(reader);
        _deadAllyWeight.Read(reader);
        _unnamed23.Read(reader);
        _controlledTerritoryInnerRadius.Read(reader);
        _controlledTerritoryOuterRadius.Read(reader);
        _controlledTerritoryWeight.Read(reader);
        _unnamed24.Read(reader);
        _unnamed25.Read(reader);
        _unnamed26.Read(reader);
        _multiplayerConstants.Read(reader);
        _stateResponses.Read(reader);
        _scoreboardHudDefinition.Read(reader);
        _scoreboardEmblemShader.Read(reader);
        _scoreboardEmblemBitmap.Read(reader);
        _scoreboardDeadEmblemShader.Read(reader);
        _scoreboardDeadEmblemBitmap.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _flag.ReadString(reader);
        _ball.ReadString(reader);
        _unit.ReadString(reader);
        _flagShader.ReadString(reader);
        _hillShader.ReadString(reader);
        _head.ReadString(reader);
        _juggernautPowerup.ReadString(reader);
        _daBomb.ReadString(reader);
        _unnamed0.ReadString(reader);
        _unnamed1.ReadString(reader);
        _unnamed2.ReadString(reader);
        _unnamed3.ReadString(reader);
        _unnamed4.ReadString(reader);
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons.Add(new WeaponsBlockBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles.Add(new VehiclesBlockBlock());
          Vehicles[x].Read(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades.Add(new GrenadeBlockBlock());
          Grenades[x].Read(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].ReadChildData(reader);
        }
        for (x = 0; (x < _powerups.Count); x = (x + 1)) {
          Powerups.Add(new PowerupBlockBlock());
          Powerups[x].Read(reader);
        }
        for (x = 0; (x < _powerups.Count); x = (x + 1)) {
          Powerups[x].ReadChildData(reader);
        }
        _inGameText.ReadString(reader);
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new SoundsBlockBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents.Add(new GameEngineGeneralEventBlockBlock());
          GeneralEvents[x].Read(reader);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _flavorEvents.Count); x = (x + 1)) {
          FlavorEvents.Add(new GameEngineFlavorEventBlockBlock());
          FlavorEvents[x].Read(reader);
        }
        for (x = 0; (x < _flavorEvents.Count); x = (x + 1)) {
          FlavorEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _slayerEvents.Count); x = (x + 1)) {
          SlayerEvents.Add(new GameEngineSlayerEventBlockBlock());
          SlayerEvents[x].Read(reader);
        }
        for (x = 0; (x < _slayerEvents.Count); x = (x + 1)) {
          SlayerEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ctfEvents.Count); x = (x + 1)) {
          CtfEvents.Add(new GameEngineCtfEventBlockBlock());
          CtfEvents[x].Read(reader);
        }
        for (x = 0; (x < _ctfEvents.Count); x = (x + 1)) {
          CtfEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _oddballEvents.Count); x = (x + 1)) {
          OddballEvents.Add(new GameEngineOddballEventBlockBlock());
          OddballEvents[x].Read(reader);
        }
        for (x = 0; (x < _oddballEvents.Count); x = (x + 1)) {
          OddballEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed5.Count); x = (x + 1)) {
          Unnamed5.Add(new GNullBlockBlock());
          Unnamed5[x].Read(reader);
        }
        for (x = 0; (x < _unnamed5.Count); x = (x + 1)) {
          Unnamed5[x].ReadChildData(reader);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents.Add(new GameEngineKingEventBlockBlock());
          KingEvents[x].Read(reader);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed6.Count); x = (x + 1)) {
          Unnamed6.Add(new GNullBlockBlock());
          Unnamed6[x].Read(reader);
        }
        for (x = 0; (x < _unnamed6.Count); x = (x + 1)) {
          Unnamed6[x].ReadChildData(reader);
        }
        for (x = 0; (x < _juggernautEvents.Count); x = (x + 1)) {
          JuggernautEvents.Add(new GameEngineJuggernautEventBlockBlock());
          JuggernautEvents[x].Read(reader);
        }
        for (x = 0; (x < _juggernautEvents.Count); x = (x + 1)) {
          JuggernautEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _territoriesEvents.Count); x = (x + 1)) {
          TerritoriesEvents.Add(new GameEngineTerritoriesEventBlockBlock());
          TerritoriesEvents[x].Read(reader);
        }
        for (x = 0; (x < _territoriesEvents.Count); x = (x + 1)) {
          TerritoriesEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _invasionEvents.Count); x = (x + 1)) {
          InvasionEvents.Add(new GameEngineAssaultEventBlockBlock());
          InvasionEvents[x].Read(reader);
        }
        for (x = 0; (x < _invasionEvents.Count); x = (x + 1)) {
          InvasionEvents[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed7.Count); x = (x + 1)) {
          Unnamed7.Add(new GNullBlockBlock());
          Unnamed7[x].Read(reader);
        }
        for (x = 0; (x < _unnamed7.Count); x = (x + 1)) {
          Unnamed7[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed8.Count); x = (x + 1)) {
          Unnamed8.Add(new GNullBlockBlock());
          Unnamed8[x].Read(reader);
        }
        for (x = 0; (x < _unnamed8.Count); x = (x + 1)) {
          Unnamed8[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed9.Count); x = (x + 1)) {
          Unnamed9.Add(new GNullBlockBlock());
          Unnamed9[x].Read(reader);
        }
        for (x = 0; (x < _unnamed9.Count); x = (x + 1)) {
          Unnamed9[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed10.Count); x = (x + 1)) {
          Unnamed10.Add(new GNullBlockBlock());
          Unnamed10[x].Read(reader);
        }
        for (x = 0; (x < _unnamed10.Count); x = (x + 1)) {
          Unnamed10[x].ReadChildData(reader);
        }
        _defaultItemCollection1.ReadString(reader);
        _defaultItemCollection2.ReadString(reader);
        for (x = 0; (x < _multiplayerConstants.Count); x = (x + 1)) {
          MultiplayerConstants.Add(new MultiplayerConstantsBlockBlock());
          MultiplayerConstants[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerConstants.Count); x = (x + 1)) {
          MultiplayerConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stateResponses.Count); x = (x + 1)) {
          StateResponses.Add(new GameEngineStatusResponseBlockBlock());
          StateResponses[x].Read(reader);
        }
        for (x = 0; (x < _stateResponses.Count); x = (x + 1)) {
          StateResponses[x].ReadChildData(reader);
        }
        _scoreboardHudDefinition.ReadString(reader);
        _scoreboardEmblemShader.ReadString(reader);
        _scoreboardEmblemBitmap.ReadString(reader);
        _scoreboardDeadEmblemShader.ReadString(reader);
        _scoreboardDeadEmblemBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flag.Write(bw);
        _ball.Write(bw);
        _unit.Write(bw);
        _flagShader.Write(bw);
        _hillShader.Write(bw);
        _head.Write(bw);
        _juggernautPowerup.Write(bw);
        _daBomb.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
_weapons.Count = Weapons.Count;
        _weapons.Write(bw);
_vehicles.Count = Vehicles.Count;
        _vehicles.Write(bw);
_grenades.Count = Grenades.Count;
        _grenades.Write(bw);
_powerups.Count = Powerups.Count;
        _powerups.Write(bw);
        _inGameText.Write(bw);
_sounds.Count = Sounds.Count;
        _sounds.Write(bw);
_generalEvents.Count = GeneralEvents.Count;
        _generalEvents.Write(bw);
_flavorEvents.Count = FlavorEvents.Count;
        _flavorEvents.Write(bw);
_slayerEvents.Count = SlayerEvents.Count;
        _slayerEvents.Write(bw);
_ctfEvents.Count = CtfEvents.Count;
        _ctfEvents.Write(bw);
_oddballEvents.Count = OddballEvents.Count;
        _oddballEvents.Write(bw);
_unnamed5.Count = Unnamed5.Count;
        _unnamed5.Write(bw);
_kingEvents.Count = KingEvents.Count;
        _kingEvents.Write(bw);
_unnamed6.Count = Unnamed6.Count;
        _unnamed6.Write(bw);
_juggernautEvents.Count = JuggernautEvents.Count;
        _juggernautEvents.Write(bw);
_territoriesEvents.Count = TerritoriesEvents.Count;
        _territoriesEvents.Write(bw);
_invasionEvents.Count = InvasionEvents.Count;
        _invasionEvents.Write(bw);
_unnamed7.Count = Unnamed7.Count;
        _unnamed7.Write(bw);
_unnamed8.Count = Unnamed8.Count;
        _unnamed8.Write(bw);
_unnamed9.Count = Unnamed9.Count;
        _unnamed9.Write(bw);
_unnamed10.Count = Unnamed10.Count;
        _unnamed10.Write(bw);
        _defaultItemCollection1.Write(bw);
        _defaultItemCollection2.Write(bw);
        _defaultFragGrenadeCount.Write(bw);
        _defaultPlasmaGrenadeCount.Write(bw);
        _unnamed11.Write(bw);
        _dynamicZoneUpperHeight.Write(bw);
        _dynamicZoneLowerHeight.Write(bw);
        _unnamed12.Write(bw);
        _enemyInnerRadius.Write(bw);
        _enemyOuterRadius.Write(bw);
        _enemyWeight.Write(bw);
        _unnamed13.Write(bw);
        _friendInnerRadius.Write(bw);
        _friendOuterRadius.Write(bw);
        _friendWeight.Write(bw);
        _unnamed14.Write(bw);
        _enemyVehicleInnerRadius.Write(bw);
        _enemyVehicleOuterRadius.Write(bw);
        _enemyVehicleWeight.Write(bw);
        _unnamed15.Write(bw);
        _friendlyVehicleInnerRadius.Write(bw);
        _friendlyVehicleOuterRadius.Write(bw);
        _friendlyVehicleWeight.Write(bw);
        _unnamed16.Write(bw);
        _emptyVehicleInnerRadius.Write(bw);
        _emptyVehicleOuterRadius.Write(bw);
        _emptyVehicleWeight.Write(bw);
        _unnamed17.Write(bw);
        _oddballInclusionInnerRadius.Write(bw);
        _oddballInclusionOuterRadius.Write(bw);
        _oddballInclusionWeight.Write(bw);
        _unnamed18.Write(bw);
        _oddballExclusionInnerRadius.Write(bw);
        _oddballExclusionOuterRadius.Write(bw);
        _oddballExclusionWeight.Write(bw);
        _unnamed19.Write(bw);
        _hillInclusionInnerRadius.Write(bw);
        _hillInclusionOuterRadius.Write(bw);
        _hillInclusionWeight.Write(bw);
        _unnamed20.Write(bw);
        _hillExclusionInnerRadius.Write(bw);
        _hillExclusionOuterRadius.Write(bw);
        _hillExclusionWeight.Write(bw);
        _unnamed21.Write(bw);
        _lastRaceFlagInnerRadius.Write(bw);
        _lastRaceFlagOuterRadius.Write(bw);
        _lastRaceFlagWeight.Write(bw);
        _unnamed22.Write(bw);
        _deadAllyInnerRadius.Write(bw);
        _deadAllyOuterRadius.Write(bw);
        _deadAllyWeight.Write(bw);
        _unnamed23.Write(bw);
        _controlledTerritoryInnerRadius.Write(bw);
        _controlledTerritoryOuterRadius.Write(bw);
        _controlledTerritoryWeight.Write(bw);
        _unnamed24.Write(bw);
        _unnamed25.Write(bw);
        _unnamed26.Write(bw);
_multiplayerConstants.Count = MultiplayerConstants.Count;
        _multiplayerConstants.Write(bw);
_stateResponses.Count = StateResponses.Count;
        _stateResponses.Write(bw);
        _scoreboardHudDefinition.Write(bw);
        _scoreboardEmblemShader.Write(bw);
        _scoreboardEmblemBitmap.Write(bw);
        _scoreboardDeadEmblemShader.Write(bw);
        _scoreboardDeadEmblemBitmap.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _flag.WriteString(writer);
        _ball.WriteString(writer);
        _unit.WriteString(writer);
        _flagShader.WriteString(writer);
        _hillShader.WriteString(writer);
        _head.WriteString(writer);
        _juggernautPowerup.WriteString(writer);
        _daBomb.WriteString(writer);
        _unnamed0.WriteString(writer);
        _unnamed1.WriteString(writer);
        _unnamed2.WriteString(writer);
        _unnamed3.WriteString(writer);
        _unnamed4.WriteString(writer);
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].Write(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].Write(writer);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].Write(writer);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].WriteChildData(writer);
        }
        for (x = 0; (x < _powerups.Count); x = (x + 1)) {
          Powerups[x].Write(writer);
        }
        for (x = 0; (x < _powerups.Count); x = (x + 1)) {
          Powerups[x].WriteChildData(writer);
        }
        _inGameText.WriteString(writer);
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].Write(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].Write(writer);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _flavorEvents.Count); x = (x + 1)) {
          FlavorEvents[x].Write(writer);
        }
        for (x = 0; (x < _flavorEvents.Count); x = (x + 1)) {
          FlavorEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _slayerEvents.Count); x = (x + 1)) {
          SlayerEvents[x].Write(writer);
        }
        for (x = 0; (x < _slayerEvents.Count); x = (x + 1)) {
          SlayerEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ctfEvents.Count); x = (x + 1)) {
          CtfEvents[x].Write(writer);
        }
        for (x = 0; (x < _ctfEvents.Count); x = (x + 1)) {
          CtfEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _oddballEvents.Count); x = (x + 1)) {
          OddballEvents[x].Write(writer);
        }
        for (x = 0; (x < _oddballEvents.Count); x = (x + 1)) {
          OddballEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed5.Count); x = (x + 1)) {
          Unnamed5[x].Write(writer);
        }
        for (x = 0; (x < _unnamed5.Count); x = (x + 1)) {
          Unnamed5[x].WriteChildData(writer);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].Write(writer);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed6.Count); x = (x + 1)) {
          Unnamed6[x].Write(writer);
        }
        for (x = 0; (x < _unnamed6.Count); x = (x + 1)) {
          Unnamed6[x].WriteChildData(writer);
        }
        for (x = 0; (x < _juggernautEvents.Count); x = (x + 1)) {
          JuggernautEvents[x].Write(writer);
        }
        for (x = 0; (x < _juggernautEvents.Count); x = (x + 1)) {
          JuggernautEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _territoriesEvents.Count); x = (x + 1)) {
          TerritoriesEvents[x].Write(writer);
        }
        for (x = 0; (x < _territoriesEvents.Count); x = (x + 1)) {
          TerritoriesEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _invasionEvents.Count); x = (x + 1)) {
          InvasionEvents[x].Write(writer);
        }
        for (x = 0; (x < _invasionEvents.Count); x = (x + 1)) {
          InvasionEvents[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed7.Count); x = (x + 1)) {
          Unnamed7[x].Write(writer);
        }
        for (x = 0; (x < _unnamed7.Count); x = (x + 1)) {
          Unnamed7[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed8.Count); x = (x + 1)) {
          Unnamed8[x].Write(writer);
        }
        for (x = 0; (x < _unnamed8.Count); x = (x + 1)) {
          Unnamed8[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed9.Count); x = (x + 1)) {
          Unnamed9[x].Write(writer);
        }
        for (x = 0; (x < _unnamed9.Count); x = (x + 1)) {
          Unnamed9[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed10.Count); x = (x + 1)) {
          Unnamed10[x].Write(writer);
        }
        for (x = 0; (x < _unnamed10.Count); x = (x + 1)) {
          Unnamed10[x].WriteChildData(writer);
        }
        _defaultItemCollection1.WriteString(writer);
        _defaultItemCollection2.WriteString(writer);
        for (x = 0; (x < _multiplayerConstants.Count); x = (x + 1)) {
          MultiplayerConstants[x].Write(writer);
        }
        for (x = 0; (x < _multiplayerConstants.Count); x = (x + 1)) {
          MultiplayerConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stateResponses.Count); x = (x + 1)) {
          StateResponses[x].Write(writer);
        }
        for (x = 0; (x < _stateResponses.Count); x = (x + 1)) {
          StateResponses[x].WriteChildData(writer);
        }
        _scoreboardHudDefinition.WriteString(writer);
        _scoreboardEmblemShader.WriteString(writer);
        _scoreboardEmblemBitmap.WriteString(writer);
        _scoreboardDeadEmblemShader.WriteString(writer);
        _scoreboardDeadEmblemBitmap.WriteString(writer);
      }
    }
    public class WeaponsBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public WeaponsBlockBlock() {
if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
  (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weapon.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _weapon.ToString();
        }
      }
      public TagReference Weapon {
        get {
          return this._weapon;
        }
        set {
          this._weapon = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weapon.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weapon.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weapon.WriteString(writer);
      }
    }
    public class VehiclesBlockBlock : IBlock {
      private TagReference _vehicle = new TagReference();
public event System.EventHandler BlockNameChanged;
      public VehiclesBlockBlock() {
if (this._vehicle is System.ComponentModel.INotifyPropertyChanged)
  (this._vehicle as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vehicle.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vehicle.ToString();
        }
      }
      public TagReference Vehicle {
        get {
          return this._vehicle;
        }
        set {
          this._vehicle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vehicle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vehicle.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _vehicle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vehicle.WriteString(writer);
      }
    }
    public class GrenadeBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public GrenadeBlockBlock() {
if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
  (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weapon.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _weapon.ToString();
        }
      }
      public TagReference Weapon {
        get {
          return this._weapon;
        }
        set {
          this._weapon = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weapon.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weapon.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weapon.WriteString(writer);
      }
    }
    public class PowerupBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public PowerupBlockBlock() {
if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
  (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weapon.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _weapon.ToString();
        }
      }
      public TagReference Weapon {
        get {
          return this._weapon;
        }
        set {
          this._weapon = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weapon.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weapon.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weapon.WriteString(writer);
      }
    }
    public class SoundsBlockBlock : IBlock {
      private TagReference _sound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SoundsBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
    public class GameEngineGeneralEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineGeneralEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class SoundResponseDefinitionBlockBlock : IBlock {
      private Flags _soundFlags;
      private Pad _unnamed0;
      private TagReference _englishSound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Real _probability = new Real();
public event System.EventHandler BlockNameChanged;
      public SoundResponseDefinitionBlockBlock() {
if (this._englishSound is System.ComponentModel.INotifyPropertyChanged)
  (this._englishSound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._soundFlags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_englishSound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _englishSound.ToString();
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference EnglishSound {
        get {
          return this._englishSound;
        }
        set {
          this._englishSound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public Real Probability {
        get {
          return this._probability;
        }
        set {
          this._probability = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundFlags.Read(reader);
        _unnamed0.Read(reader);
        _englishSound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _probability.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _englishSound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _soundFlags.Write(bw);
        _unnamed0.Write(bw);
        _englishSound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _probability.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _englishSound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
      }
    }
    public class GameEngineFlavorEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineFlavorEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineSlayerEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineSlayerEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineCtfEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineCtfEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineOddballEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineOddballEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GNullBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public GNullBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GameEngineKingEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineKingEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineJuggernautEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineJuggernautEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineTerritoriesEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineTerritoriesEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class GameEngineAssaultEventBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _event;
      private Enum _audience;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _displayString = new StringId();
      private Enum _requiredField;
      private Enum _excludedAudience;
      private StringId _primaryString = new StringId();
      private LongInteger _primaryStringDuration = new LongInteger();
      private StringId _pluralDisplayString = new StringId();
      private Pad _unnamed3;
      private Real _soundDelayAnnouncerOnly = new Real();
      private Flags _soundFlags;
      private Pad _unnamed4;
      private TagReference _sound = new TagReference();
      private TagReference _japaneseSound = new TagReference();
      private TagReference _germanSound = new TagReference();
      private TagReference _frenchSound = new TagReference();
      private TagReference _spanishSound = new TagReference();
      private TagReference _italianSound = new TagReference();
      private TagReference _koreanSound = new TagReference();
      private TagReference _chineseSound = new TagReference();
      private TagReference _portugueseSound = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _soundPermutations = new Block();
      public BlockCollection<SoundResponseDefinitionBlockBlock> _soundPermutationsList = new BlockCollection<SoundResponseDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameEngineAssaultEventBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._event = new Enum(2);
        this._audience = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._requiredField = new Enum(2);
        this._excludedAudience = new Enum(2);
        this._unnamed3 = new Pad(28);
        this._soundFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
      }
      public BlockCollection<SoundResponseDefinitionBlockBlock> SoundPermutations {
        get {
          return this._soundPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
references.Add(_japaneseSound.Value);
references.Add(_germanSound.Value);
references.Add(_frenchSound.Value);
references.Add(_spanishSound.Value);
references.Add(_italianSound.Value);
references.Add(_koreanSound.Value);
references.Add(_chineseSound.Value);
references.Add(_portugueseSound.Value);
for (int x=0; x<SoundPermutations.BlockCount; x++)
{
  IBlock block = SoundPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum Event {
        get {
          return this._event;
        }
        set {
          this._event = value;
        }
      }
      public Enum Audience {
        get {
          return this._audience;
        }
        set {
          this._audience = value;
        }
      }
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public Enum RequiredField {
        get {
          return this._requiredField;
        }
        set {
          this._requiredField = value;
        }
      }
      public Enum ExcludedAudience {
        get {
          return this._excludedAudience;
        }
        set {
          this._excludedAudience = value;
        }
      }
      public StringId PrimaryString {
        get {
          return this._primaryString;
        }
        set {
          this._primaryString = value;
        }
      }
      public LongInteger PrimaryStringDuration {
        get {
          return this._primaryStringDuration;
        }
        set {
          this._primaryStringDuration = value;
        }
      }
      public StringId PluralDisplayString {
        get {
          return this._pluralDisplayString;
        }
        set {
          this._pluralDisplayString = value;
        }
      }
      public Real SoundDelayAnnouncerOnly {
        get {
          return this._soundDelayAnnouncerOnly;
        }
        set {
          this._soundDelayAnnouncerOnly = value;
        }
      }
      public Flags SoundFlags {
        get {
          return this._soundFlags;
        }
        set {
          this._soundFlags = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public TagReference JapaneseSound {
        get {
          return this._japaneseSound;
        }
        set {
          this._japaneseSound = value;
        }
      }
      public TagReference GermanSound {
        get {
          return this._germanSound;
        }
        set {
          this._germanSound = value;
        }
      }
      public TagReference FrenchSound {
        get {
          return this._frenchSound;
        }
        set {
          this._frenchSound = value;
        }
      }
      public TagReference SpanishSound {
        get {
          return this._spanishSound;
        }
        set {
          this._spanishSound = value;
        }
      }
      public TagReference ItalianSound {
        get {
          return this._italianSound;
        }
        set {
          this._italianSound = value;
        }
      }
      public TagReference KoreanSound {
        get {
          return this._koreanSound;
        }
        set {
          this._koreanSound = value;
        }
      }
      public TagReference ChineseSound {
        get {
          return this._chineseSound;
        }
        set {
          this._chineseSound = value;
        }
      }
      public TagReference PortugueseSound {
        get {
          return this._portugueseSound;
        }
        set {
          this._portugueseSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _event.Read(reader);
        _audience.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _displayString.Read(reader);
        _requiredField.Read(reader);
        _excludedAudience.Read(reader);
        _primaryString.Read(reader);
        _primaryStringDuration.Read(reader);
        _pluralDisplayString.Read(reader);
        _unnamed3.Read(reader);
        _soundDelayAnnouncerOnly.Read(reader);
        _soundFlags.Read(reader);
        _unnamed4.Read(reader);
        _sound.Read(reader);
        _japaneseSound.Read(reader);
        _germanSound.Read(reader);
        _frenchSound.Read(reader);
        _spanishSound.Read(reader);
        _italianSound.Read(reader);
        _koreanSound.Read(reader);
        _chineseSound.Read(reader);
        _portugueseSound.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _soundPermutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayString.ReadString(reader);
        _primaryString.ReadString(reader);
        _pluralDisplayString.ReadString(reader);
        _sound.ReadString(reader);
        _japaneseSound.ReadString(reader);
        _germanSound.ReadString(reader);
        _frenchSound.ReadString(reader);
        _spanishSound.ReadString(reader);
        _italianSound.ReadString(reader);
        _koreanSound.ReadString(reader);
        _chineseSound.ReadString(reader);
        _portugueseSound.ReadString(reader);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations.Add(new SoundResponseDefinitionBlockBlock());
          SoundPermutations[x].Read(reader);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _event.Write(bw);
        _audience.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _displayString.Write(bw);
        _requiredField.Write(bw);
        _excludedAudience.Write(bw);
        _primaryString.Write(bw);
        _primaryStringDuration.Write(bw);
        _pluralDisplayString.Write(bw);
        _unnamed3.Write(bw);
        _soundDelayAnnouncerOnly.Write(bw);
        _soundFlags.Write(bw);
        _unnamed4.Write(bw);
        _sound.Write(bw);
        _japaneseSound.Write(bw);
        _germanSound.Write(bw);
        _frenchSound.Write(bw);
        _spanishSound.Write(bw);
        _italianSound.Write(bw);
        _koreanSound.Write(bw);
        _chineseSound.Write(bw);
        _portugueseSound.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_soundPermutations.Count = SoundPermutations.Count;
        _soundPermutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayString.WriteString(writer);
        _primaryString.WriteString(writer);
        _pluralDisplayString.WriteString(writer);
        _sound.WriteString(writer);
        _japaneseSound.WriteString(writer);
        _germanSound.WriteString(writer);
        _frenchSound.WriteString(writer);
        _spanishSound.WriteString(writer);
        _italianSound.WriteString(writer);
        _koreanSound.WriteString(writer);
        _chineseSound.WriteString(writer);
        _portugueseSound.WriteString(writer);
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].Write(writer);
        }
        for (x = 0; (x < _soundPermutations.Count); x = (x + 1)) {
          SoundPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class MultiplayerConstantsBlockBlock : IBlock {
      private Real _maximumRandomSpawnBias = new Real();
      private Real _teleporterRechargeTime = new Real();
      private Real _grenadeDangerWeight = new Real();
      private Real _grenadeDangerInnerRadius = new Real();
      private Real _grenadeDangerOuterRadius = new Real();
      private Real _grenadeDangerLeadTime = new Real();
      private Real _vehicleDangerMinSpeed = new Real();
      private Real _vehicleDangerWeight = new Real();
      private Real _vehicleDangerRadius = new Real();
      private Real _vehicleDangerLeadTime = new Real();
      private Real _vehicleNearbyPlayerDist = new Real();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private TagReference _hillShader = new TagReference();
      private Pad _unnamed3;
      private Real _flagResetStopDistance = new Real();
      private TagReference _bombExplodeEffect = new TagReference();
      private TagReference _bombExplodeDmgEffect = new TagReference();
      private TagReference _bombDefuseEffect = new TagReference();
      private StringId _bombDefusalString = new StringId();
      private StringId _blockedTeleporterString = new StringId();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public MultiplayerConstantsBlockBlock() {
        this._unnamed0 = new Pad(84);
        this._unnamed1 = new Pad(32);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(32);
        this._unnamed7 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_hillShader.Value);
references.Add(_bombExplodeEffect.Value);
references.Add(_bombExplodeDmgEffect.Value);
references.Add(_bombDefuseEffect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Real MaximumRandomSpawnBias {
        get {
          return this._maximumRandomSpawnBias;
        }
        set {
          this._maximumRandomSpawnBias = value;
        }
      }
      public Real TeleporterRechargeTime {
        get {
          return this._teleporterRechargeTime;
        }
        set {
          this._teleporterRechargeTime = value;
        }
      }
      public Real GrenadeDangerWeight {
        get {
          return this._grenadeDangerWeight;
        }
        set {
          this._grenadeDangerWeight = value;
        }
      }
      public Real GrenadeDangerInnerRadius {
        get {
          return this._grenadeDangerInnerRadius;
        }
        set {
          this._grenadeDangerInnerRadius = value;
        }
      }
      public Real GrenadeDangerOuterRadius {
        get {
          return this._grenadeDangerOuterRadius;
        }
        set {
          this._grenadeDangerOuterRadius = value;
        }
      }
      public Real GrenadeDangerLeadTime {
        get {
          return this._grenadeDangerLeadTime;
        }
        set {
          this._grenadeDangerLeadTime = value;
        }
      }
      public Real VehicleDangerMinSpeed {
        get {
          return this._vehicleDangerMinSpeed;
        }
        set {
          this._vehicleDangerMinSpeed = value;
        }
      }
      public Real VehicleDangerWeight {
        get {
          return this._vehicleDangerWeight;
        }
        set {
          this._vehicleDangerWeight = value;
        }
      }
      public Real VehicleDangerRadius {
        get {
          return this._vehicleDangerRadius;
        }
        set {
          this._vehicleDangerRadius = value;
        }
      }
      public Real VehicleDangerLeadTime {
        get {
          return this._vehicleDangerLeadTime;
        }
        set {
          this._vehicleDangerLeadTime = value;
        }
      }
      public Real VehicleNearbyPlayerDist {
        get {
          return this._vehicleNearbyPlayerDist;
        }
        set {
          this._vehicleNearbyPlayerDist = value;
        }
      }
      public TagReference HillShader {
        get {
          return this._hillShader;
        }
        set {
          this._hillShader = value;
        }
      }
      public Real FlagResetStopDistance {
        get {
          return this._flagResetStopDistance;
        }
        set {
          this._flagResetStopDistance = value;
        }
      }
      public TagReference BombExplodeEffect {
        get {
          return this._bombExplodeEffect;
        }
        set {
          this._bombExplodeEffect = value;
        }
      }
      public TagReference BombExplodeDmgEffect {
        get {
          return this._bombExplodeDmgEffect;
        }
        set {
          this._bombExplodeDmgEffect = value;
        }
      }
      public TagReference BombDefuseEffect {
        get {
          return this._bombDefuseEffect;
        }
        set {
          this._bombDefuseEffect = value;
        }
      }
      public StringId BombDefusalString {
        get {
          return this._bombDefusalString;
        }
        set {
          this._bombDefusalString = value;
        }
      }
      public StringId BlockedTeleporterString {
        get {
          return this._blockedTeleporterString;
        }
        set {
          this._blockedTeleporterString = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _maximumRandomSpawnBias.Read(reader);
        _teleporterRechargeTime.Read(reader);
        _grenadeDangerWeight.Read(reader);
        _grenadeDangerInnerRadius.Read(reader);
        _grenadeDangerOuterRadius.Read(reader);
        _grenadeDangerLeadTime.Read(reader);
        _vehicleDangerMinSpeed.Read(reader);
        _vehicleDangerWeight.Read(reader);
        _vehicleDangerRadius.Read(reader);
        _vehicleDangerLeadTime.Read(reader);
        _vehicleNearbyPlayerDist.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _hillShader.Read(reader);
        _unnamed3.Read(reader);
        _flagResetStopDistance.Read(reader);
        _bombExplodeEffect.Read(reader);
        _bombExplodeDmgEffect.Read(reader);
        _bombDefuseEffect.Read(reader);
        _bombDefusalString.Read(reader);
        _blockedTeleporterString.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _hillShader.ReadString(reader);
        _bombExplodeEffect.ReadString(reader);
        _bombExplodeDmgEffect.ReadString(reader);
        _bombDefuseEffect.ReadString(reader);
        _bombDefusalString.ReadString(reader);
        _blockedTeleporterString.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _maximumRandomSpawnBias.Write(bw);
        _teleporterRechargeTime.Write(bw);
        _grenadeDangerWeight.Write(bw);
        _grenadeDangerInnerRadius.Write(bw);
        _grenadeDangerOuterRadius.Write(bw);
        _grenadeDangerLeadTime.Write(bw);
        _vehicleDangerMinSpeed.Write(bw);
        _vehicleDangerWeight.Write(bw);
        _vehicleDangerRadius.Write(bw);
        _vehicleDangerLeadTime.Write(bw);
        _vehicleNearbyPlayerDist.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _hillShader.Write(bw);
        _unnamed3.Write(bw);
        _flagResetStopDistance.Write(bw);
        _bombExplodeEffect.Write(bw);
        _bombExplodeDmgEffect.Write(bw);
        _bombDefuseEffect.Write(bw);
        _bombDefusalString.Write(bw);
        _blockedTeleporterString.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _hillShader.WriteString(writer);
        _bombExplodeEffect.WriteString(writer);
        _bombExplodeDmgEffect.WriteString(writer);
        _bombDefuseEffect.WriteString(writer);
        _bombDefusalString.WriteString(writer);
        _blockedTeleporterString.WriteString(writer);
      }
    }
    public class GameEngineStatusResponseBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _state;
      private Pad _unnamed1;
      private StringId _ffaMessage = new StringId();
      private StringId _teamMessage = new StringId();
      private TagReference _unnamed2 = new TagReference();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public GameEngineStatusResponseBlockBlock() {
if (this._state is System.ComponentModel.INotifyPropertyChanged)
  (this._state as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._state = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed3 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unnamed2.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _state.ToString();
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum State {
        get {
          return this._state;
        }
        set {
          this._state = value;
        }
      }
      public StringId FfaMessage {
        get {
          return this._ffaMessage;
        }
        set {
          this._ffaMessage = value;
        }
      }
      public StringId TeamMessage {
        get {
          return this._teamMessage;
        }
        set {
          this._teamMessage = value;
        }
      }
      public TagReference unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _state.Read(reader);
        _unnamed1.Read(reader);
        _ffaMessage.Read(reader);
        _teamMessage.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _ffaMessage.ReadString(reader);
        _teamMessage.ReadString(reader);
        _unnamed2.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _state.Write(bw);
        _unnamed1.Write(bw);
        _ffaMessage.Write(bw);
        _teamMessage.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _ffaMessage.WriteString(writer);
        _teamMessage.WriteString(writer);
        _unnamed2.WriteString(writer);
      }
    }
  }
}
