// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'character'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class character : Interfaces.Pool.Tag {
    private CharacterBlockBlock characterValues = new CharacterBlockBlock();
    public virtual CharacterBlockBlock CharacterValues {
      get {
        return characterValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(CharacterValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "character";
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
characterValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
characterValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
characterValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
characterValues.WriteChildData(writer);
    }
    #endregion
    public class CharacterBlockBlock : IBlock {
      private Flags _characterFlags;
      private TagReference _parentCharacter = new TagReference();
      private TagReference _unit = new TagReference();
      private TagReference _creature = new TagReference();
      private TagReference _style = new TagReference();
      private TagReference _majorCharacter = new TagReference();
      private Block _variants = new Block();
      private Block _generalProperties = new Block();
      private Block _vitalityProperties = new Block();
      private Block _placementProperties = new Block();
      private Block _perceptionProperties = new Block();
      private Block _lookProperties = new Block();
      private Block _movementProperties = new Block();
      private Block _swarmProperties = new Block();
      private Block _readyProperties = new Block();
      private Block _engageProperties = new Block();
      private Block _chargeProperties = new Block();
      private Block _evasionProperties = new Block();
      private Block _coverProperties = new Block();
      private Block _retreatProperties = new Block();
      private Block _searchProperties = new Block();
      private Block _pre_MinussearchProperties = new Block();
      private Block _idleProperties = new Block();
      private Block _vocalizationProperties = new Block();
      private Block _boardingProperties = new Block();
      private Block _bossProperties = new Block();
      private Block _weaponsProperties = new Block();
      private Block _firingPatternProperties = new Block();
      private Block _grenadesProperties = new Block();
      private Block _vehicleProperties = new Block();
      public BlockCollection<CharacterVariantsBlockBlock> _variantsList = new BlockCollection<CharacterVariantsBlockBlock>();
      public BlockCollection<CharacterGeneralBlockBlock> _generalPropertiesList = new BlockCollection<CharacterGeneralBlockBlock>();
      public BlockCollection<CharacterVitalityBlockBlock> _vitalityPropertiesList = new BlockCollection<CharacterVitalityBlockBlock>();
      public BlockCollection<CharacterPlacementBlockBlock> _placementPropertiesList = new BlockCollection<CharacterPlacementBlockBlock>();
      public BlockCollection<CharacterPerceptionBlockBlock> _perceptionPropertiesList = new BlockCollection<CharacterPerceptionBlockBlock>();
      public BlockCollection<CharacterLookBlockBlock> _lookPropertiesList = new BlockCollection<CharacterLookBlockBlock>();
      public BlockCollection<CharacterMovementBlockBlock> _movementPropertiesList = new BlockCollection<CharacterMovementBlockBlock>();
      public BlockCollection<CharacterSwarmBlockBlock> _swarmPropertiesList = new BlockCollection<CharacterSwarmBlockBlock>();
      public BlockCollection<CharacterReadyBlockBlock> _readyPropertiesList = new BlockCollection<CharacterReadyBlockBlock>();
      public BlockCollection<CharacterEngageBlockBlock> _engagePropertiesList = new BlockCollection<CharacterEngageBlockBlock>();
      public BlockCollection<CharacterChargeBlockBlock> _chargePropertiesList = new BlockCollection<CharacterChargeBlockBlock>();
      public BlockCollection<CharacterEvasionBlockBlock> _evasionPropertiesList = new BlockCollection<CharacterEvasionBlockBlock>();
      public BlockCollection<CharacterCoverBlockBlock> _coverPropertiesList = new BlockCollection<CharacterCoverBlockBlock>();
      public BlockCollection<CharacterRetreatBlockBlock> _retreatPropertiesList = new BlockCollection<CharacterRetreatBlockBlock>();
      public BlockCollection<CharacterSearchBlockBlock> _searchPropertiesList = new BlockCollection<CharacterSearchBlockBlock>();
      public BlockCollection<CharacterPresearchBlockBlock> _pre_MinussearchPropertiesList = new BlockCollection<CharacterPresearchBlockBlock>();
      public BlockCollection<CharacterIdleBlockBlock> _idlePropertiesList = new BlockCollection<CharacterIdleBlockBlock>();
      public BlockCollection<CharacterVocalizationBlockBlock> _vocalizationPropertiesList = new BlockCollection<CharacterVocalizationBlockBlock>();
      public BlockCollection<CharacterBoardingBlockBlock> _boardingPropertiesList = new BlockCollection<CharacterBoardingBlockBlock>();
      public BlockCollection<CharacterBossBlockBlock> _bossPropertiesList = new BlockCollection<CharacterBossBlockBlock>();
      public BlockCollection<CharacterWeaponsBlockBlock> _weaponsPropertiesList = new BlockCollection<CharacterWeaponsBlockBlock>();
      public BlockCollection<CharacterFiringPatternPropertiesBlockBlock> _firingPatternPropertiesList = new BlockCollection<CharacterFiringPatternPropertiesBlockBlock>();
      public BlockCollection<CharacterGrenadesBlockBlock> _grenadesPropertiesList = new BlockCollection<CharacterGrenadesBlockBlock>();
      public BlockCollection<CharacterVehicleBlockBlock> _vehiclePropertiesList = new BlockCollection<CharacterVehicleBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CharacterBlockBlock() {
        this._characterFlags = new Flags(4);
      }
      public BlockCollection<CharacterVariantsBlockBlock> Variants {
        get {
          return this._variantsList;
        }
      }
      public BlockCollection<CharacterGeneralBlockBlock> GeneralProperties {
        get {
          return this._generalPropertiesList;
        }
      }
      public BlockCollection<CharacterVitalityBlockBlock> VitalityProperties {
        get {
          return this._vitalityPropertiesList;
        }
      }
      public BlockCollection<CharacterPlacementBlockBlock> PlacementProperties {
        get {
          return this._placementPropertiesList;
        }
      }
      public BlockCollection<CharacterPerceptionBlockBlock> PerceptionProperties {
        get {
          return this._perceptionPropertiesList;
        }
      }
      public BlockCollection<CharacterLookBlockBlock> LookProperties {
        get {
          return this._lookPropertiesList;
        }
      }
      public BlockCollection<CharacterMovementBlockBlock> MovementProperties {
        get {
          return this._movementPropertiesList;
        }
      }
      public BlockCollection<CharacterSwarmBlockBlock> SwarmProperties {
        get {
          return this._swarmPropertiesList;
        }
      }
      public BlockCollection<CharacterReadyBlockBlock> ReadyProperties {
        get {
          return this._readyPropertiesList;
        }
      }
      public BlockCollection<CharacterEngageBlockBlock> EngageProperties {
        get {
          return this._engagePropertiesList;
        }
      }
      public BlockCollection<CharacterChargeBlockBlock> ChargeProperties {
        get {
          return this._chargePropertiesList;
        }
      }
      public BlockCollection<CharacterEvasionBlockBlock> EvasionProperties {
        get {
          return this._evasionPropertiesList;
        }
      }
      public BlockCollection<CharacterCoverBlockBlock> CoverProperties {
        get {
          return this._coverPropertiesList;
        }
      }
      public BlockCollection<CharacterRetreatBlockBlock> RetreatProperties {
        get {
          return this._retreatPropertiesList;
        }
      }
      public BlockCollection<CharacterSearchBlockBlock> SearchProperties {
        get {
          return this._searchPropertiesList;
        }
      }
      public BlockCollection<CharacterPresearchBlockBlock> Pre_MinussearchProperties {
        get {
          return this._pre_MinussearchPropertiesList;
        }
      }
      public BlockCollection<CharacterIdleBlockBlock> IdleProperties {
        get {
          return this._idlePropertiesList;
        }
      }
      public BlockCollection<CharacterVocalizationBlockBlock> VocalizationProperties {
        get {
          return this._vocalizationPropertiesList;
        }
      }
      public BlockCollection<CharacterBoardingBlockBlock> BoardingProperties {
        get {
          return this._boardingPropertiesList;
        }
      }
      public BlockCollection<CharacterBossBlockBlock> BossProperties {
        get {
          return this._bossPropertiesList;
        }
      }
      public BlockCollection<CharacterWeaponsBlockBlock> WeaponsProperties {
        get {
          return this._weaponsPropertiesList;
        }
      }
      public BlockCollection<CharacterFiringPatternPropertiesBlockBlock> FiringPatternProperties {
        get {
          return this._firingPatternPropertiesList;
        }
      }
      public BlockCollection<CharacterGrenadesBlockBlock> GrenadesProperties {
        get {
          return this._grenadesPropertiesList;
        }
      }
      public BlockCollection<CharacterVehicleBlockBlock> VehicleProperties {
        get {
          return this._vehiclePropertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_parentCharacter.Value);
references.Add(_unit.Value);
references.Add(_creature.Value);
references.Add(_style.Value);
references.Add(_majorCharacter.Value);
for (int x=0; x<Variants.BlockCount; x++)
{
  IBlock block = Variants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GeneralProperties.BlockCount; x++)
{
  IBlock block = GeneralProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VitalityProperties.BlockCount; x++)
{
  IBlock block = VitalityProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlacementProperties.BlockCount; x++)
{
  IBlock block = PlacementProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PerceptionProperties.BlockCount; x++)
{
  IBlock block = PerceptionProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LookProperties.BlockCount; x++)
{
  IBlock block = LookProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MovementProperties.BlockCount; x++)
{
  IBlock block = MovementProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SwarmProperties.BlockCount; x++)
{
  IBlock block = SwarmProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ReadyProperties.BlockCount; x++)
{
  IBlock block = ReadyProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EngageProperties.BlockCount; x++)
{
  IBlock block = EngageProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ChargeProperties.BlockCount; x++)
{
  IBlock block = ChargeProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EvasionProperties.BlockCount; x++)
{
  IBlock block = EvasionProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CoverProperties.BlockCount; x++)
{
  IBlock block = CoverProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RetreatProperties.BlockCount; x++)
{
  IBlock block = RetreatProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SearchProperties.BlockCount; x++)
{
  IBlock block = SearchProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Pre_MinussearchProperties.BlockCount; x++)
{
  IBlock block = Pre_MinussearchProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IdleProperties.BlockCount; x++)
{
  IBlock block = IdleProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VocalizationProperties.BlockCount; x++)
{
  IBlock block = VocalizationProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BoardingProperties.BlockCount; x++)
{
  IBlock block = BoardingProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BossProperties.BlockCount; x++)
{
  IBlock block = BossProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponsProperties.BlockCount; x++)
{
  IBlock block = WeaponsProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FiringPatternProperties.BlockCount; x++)
{
  IBlock block = FiringPatternProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GrenadesProperties.BlockCount; x++)
{
  IBlock block = GrenadesProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VehicleProperties.BlockCount; x++)
{
  IBlock block = VehicleProperties.GetBlock(x);
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
      public Flags CharacterFlags {
        get {
          return this._characterFlags;
        }
        set {
          this._characterFlags = value;
        }
      }
      public TagReference ParentCharacter {
        get {
          return this._parentCharacter;
        }
        set {
          this._parentCharacter = value;
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
      public TagReference Creature {
        get {
          return this._creature;
        }
        set {
          this._creature = value;
        }
      }
      public TagReference Style {
        get {
          return this._style;
        }
        set {
          this._style = value;
        }
      }
      public TagReference MajorCharacter {
        get {
          return this._majorCharacter;
        }
        set {
          this._majorCharacter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _characterFlags.Read(reader);
        _parentCharacter.Read(reader);
        _unit.Read(reader);
        _creature.Read(reader);
        _style.Read(reader);
        _majorCharacter.Read(reader);
        _variants.Read(reader);
        _generalProperties.Read(reader);
        _vitalityProperties.Read(reader);
        _placementProperties.Read(reader);
        _perceptionProperties.Read(reader);
        _lookProperties.Read(reader);
        _movementProperties.Read(reader);
        _swarmProperties.Read(reader);
        _readyProperties.Read(reader);
        _engageProperties.Read(reader);
        _chargeProperties.Read(reader);
        _evasionProperties.Read(reader);
        _coverProperties.Read(reader);
        _retreatProperties.Read(reader);
        _searchProperties.Read(reader);
        _pre_MinussearchProperties.Read(reader);
        _idleProperties.Read(reader);
        _vocalizationProperties.Read(reader);
        _boardingProperties.Read(reader);
        _bossProperties.Read(reader);
        _weaponsProperties.Read(reader);
        _firingPatternProperties.Read(reader);
        _grenadesProperties.Read(reader);
        _vehicleProperties.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _parentCharacter.ReadString(reader);
        _unit.ReadString(reader);
        _creature.ReadString(reader);
        _style.ReadString(reader);
        _majorCharacter.ReadString(reader);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants.Add(new CharacterVariantsBlockBlock());
          Variants[x].Read(reader);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _generalProperties.Count); x = (x + 1)) {
          GeneralProperties.Add(new CharacterGeneralBlockBlock());
          GeneralProperties[x].Read(reader);
        }
        for (x = 0; (x < _generalProperties.Count); x = (x + 1)) {
          GeneralProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vitalityProperties.Count); x = (x + 1)) {
          VitalityProperties.Add(new CharacterVitalityBlockBlock());
          VitalityProperties[x].Read(reader);
        }
        for (x = 0; (x < _vitalityProperties.Count); x = (x + 1)) {
          VitalityProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _placementProperties.Count); x = (x + 1)) {
          PlacementProperties.Add(new CharacterPlacementBlockBlock());
          PlacementProperties[x].Read(reader);
        }
        for (x = 0; (x < _placementProperties.Count); x = (x + 1)) {
          PlacementProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _perceptionProperties.Count); x = (x + 1)) {
          PerceptionProperties.Add(new CharacterPerceptionBlockBlock());
          PerceptionProperties[x].Read(reader);
        }
        for (x = 0; (x < _perceptionProperties.Count); x = (x + 1)) {
          PerceptionProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lookProperties.Count); x = (x + 1)) {
          LookProperties.Add(new CharacterLookBlockBlock());
          LookProperties[x].Read(reader);
        }
        for (x = 0; (x < _lookProperties.Count); x = (x + 1)) {
          LookProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _movementProperties.Count); x = (x + 1)) {
          MovementProperties.Add(new CharacterMovementBlockBlock());
          MovementProperties[x].Read(reader);
        }
        for (x = 0; (x < _movementProperties.Count); x = (x + 1)) {
          MovementProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _swarmProperties.Count); x = (x + 1)) {
          SwarmProperties.Add(new CharacterSwarmBlockBlock());
          SwarmProperties[x].Read(reader);
        }
        for (x = 0; (x < _swarmProperties.Count); x = (x + 1)) {
          SwarmProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _readyProperties.Count); x = (x + 1)) {
          ReadyProperties.Add(new CharacterReadyBlockBlock());
          ReadyProperties[x].Read(reader);
        }
        for (x = 0; (x < _readyProperties.Count); x = (x + 1)) {
          ReadyProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _engageProperties.Count); x = (x + 1)) {
          EngageProperties.Add(new CharacterEngageBlockBlock());
          EngageProperties[x].Read(reader);
        }
        for (x = 0; (x < _engageProperties.Count); x = (x + 1)) {
          EngageProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _chargeProperties.Count); x = (x + 1)) {
          ChargeProperties.Add(new CharacterChargeBlockBlock());
          ChargeProperties[x].Read(reader);
        }
        for (x = 0; (x < _chargeProperties.Count); x = (x + 1)) {
          ChargeProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _evasionProperties.Count); x = (x + 1)) {
          EvasionProperties.Add(new CharacterEvasionBlockBlock());
          EvasionProperties[x].Read(reader);
        }
        for (x = 0; (x < _evasionProperties.Count); x = (x + 1)) {
          EvasionProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _coverProperties.Count); x = (x + 1)) {
          CoverProperties.Add(new CharacterCoverBlockBlock());
          CoverProperties[x].Read(reader);
        }
        for (x = 0; (x < _coverProperties.Count); x = (x + 1)) {
          CoverProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _retreatProperties.Count); x = (x + 1)) {
          RetreatProperties.Add(new CharacterRetreatBlockBlock());
          RetreatProperties[x].Read(reader);
        }
        for (x = 0; (x < _retreatProperties.Count); x = (x + 1)) {
          RetreatProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _searchProperties.Count); x = (x + 1)) {
          SearchProperties.Add(new CharacterSearchBlockBlock());
          SearchProperties[x].Read(reader);
        }
        for (x = 0; (x < _searchProperties.Count); x = (x + 1)) {
          SearchProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pre_MinussearchProperties.Count); x = (x + 1)) {
          Pre_MinussearchProperties.Add(new CharacterPresearchBlockBlock());
          Pre_MinussearchProperties[x].Read(reader);
        }
        for (x = 0; (x < _pre_MinussearchProperties.Count); x = (x + 1)) {
          Pre_MinussearchProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _idleProperties.Count); x = (x + 1)) {
          IdleProperties.Add(new CharacterIdleBlockBlock());
          IdleProperties[x].Read(reader);
        }
        for (x = 0; (x < _idleProperties.Count); x = (x + 1)) {
          IdleProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vocalizationProperties.Count); x = (x + 1)) {
          VocalizationProperties.Add(new CharacterVocalizationBlockBlock());
          VocalizationProperties[x].Read(reader);
        }
        for (x = 0; (x < _vocalizationProperties.Count); x = (x + 1)) {
          VocalizationProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _boardingProperties.Count); x = (x + 1)) {
          BoardingProperties.Add(new CharacterBoardingBlockBlock());
          BoardingProperties[x].Read(reader);
        }
        for (x = 0; (x < _boardingProperties.Count); x = (x + 1)) {
          BoardingProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bossProperties.Count); x = (x + 1)) {
          BossProperties.Add(new CharacterBossBlockBlock());
          BossProperties[x].Read(reader);
        }
        for (x = 0; (x < _bossProperties.Count); x = (x + 1)) {
          BossProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponsProperties.Count); x = (x + 1)) {
          WeaponsProperties.Add(new CharacterWeaponsBlockBlock());
          WeaponsProperties[x].Read(reader);
        }
        for (x = 0; (x < _weaponsProperties.Count); x = (x + 1)) {
          WeaponsProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _firingPatternProperties.Count); x = (x + 1)) {
          FiringPatternProperties.Add(new CharacterFiringPatternPropertiesBlockBlock());
          FiringPatternProperties[x].Read(reader);
        }
        for (x = 0; (x < _firingPatternProperties.Count); x = (x + 1)) {
          FiringPatternProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _grenadesProperties.Count); x = (x + 1)) {
          GrenadesProperties.Add(new CharacterGrenadesBlockBlock());
          GrenadesProperties[x].Read(reader);
        }
        for (x = 0; (x < _grenadesProperties.Count); x = (x + 1)) {
          GrenadesProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehicleProperties.Count); x = (x + 1)) {
          VehicleProperties.Add(new CharacterVehicleBlockBlock());
          VehicleProperties[x].Read(reader);
        }
        for (x = 0; (x < _vehicleProperties.Count); x = (x + 1)) {
          VehicleProperties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _characterFlags.Write(bw);
        _parentCharacter.Write(bw);
        _unit.Write(bw);
        _creature.Write(bw);
        _style.Write(bw);
        _majorCharacter.Write(bw);
_variants.Count = Variants.Count;
        _variants.Write(bw);
_generalProperties.Count = GeneralProperties.Count;
        _generalProperties.Write(bw);
_vitalityProperties.Count = VitalityProperties.Count;
        _vitalityProperties.Write(bw);
_placementProperties.Count = PlacementProperties.Count;
        _placementProperties.Write(bw);
_perceptionProperties.Count = PerceptionProperties.Count;
        _perceptionProperties.Write(bw);
_lookProperties.Count = LookProperties.Count;
        _lookProperties.Write(bw);
_movementProperties.Count = MovementProperties.Count;
        _movementProperties.Write(bw);
_swarmProperties.Count = SwarmProperties.Count;
        _swarmProperties.Write(bw);
_readyProperties.Count = ReadyProperties.Count;
        _readyProperties.Write(bw);
_engageProperties.Count = EngageProperties.Count;
        _engageProperties.Write(bw);
_chargeProperties.Count = ChargeProperties.Count;
        _chargeProperties.Write(bw);
_evasionProperties.Count = EvasionProperties.Count;
        _evasionProperties.Write(bw);
_coverProperties.Count = CoverProperties.Count;
        _coverProperties.Write(bw);
_retreatProperties.Count = RetreatProperties.Count;
        _retreatProperties.Write(bw);
_searchProperties.Count = SearchProperties.Count;
        _searchProperties.Write(bw);
_pre_MinussearchProperties.Count = Pre_MinussearchProperties.Count;
        _pre_MinussearchProperties.Write(bw);
_idleProperties.Count = IdleProperties.Count;
        _idleProperties.Write(bw);
_vocalizationProperties.Count = VocalizationProperties.Count;
        _vocalizationProperties.Write(bw);
_boardingProperties.Count = BoardingProperties.Count;
        _boardingProperties.Write(bw);
_bossProperties.Count = BossProperties.Count;
        _bossProperties.Write(bw);
_weaponsProperties.Count = WeaponsProperties.Count;
        _weaponsProperties.Write(bw);
_firingPatternProperties.Count = FiringPatternProperties.Count;
        _firingPatternProperties.Write(bw);
_grenadesProperties.Count = GrenadesProperties.Count;
        _grenadesProperties.Write(bw);
_vehicleProperties.Count = VehicleProperties.Count;
        _vehicleProperties.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _parentCharacter.WriteString(writer);
        _unit.WriteString(writer);
        _creature.WriteString(writer);
        _style.WriteString(writer);
        _majorCharacter.WriteString(writer);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].Write(writer);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _generalProperties.Count); x = (x + 1)) {
          GeneralProperties[x].Write(writer);
        }
        for (x = 0; (x < _generalProperties.Count); x = (x + 1)) {
          GeneralProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vitalityProperties.Count); x = (x + 1)) {
          VitalityProperties[x].Write(writer);
        }
        for (x = 0; (x < _vitalityProperties.Count); x = (x + 1)) {
          VitalityProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _placementProperties.Count); x = (x + 1)) {
          PlacementProperties[x].Write(writer);
        }
        for (x = 0; (x < _placementProperties.Count); x = (x + 1)) {
          PlacementProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _perceptionProperties.Count); x = (x + 1)) {
          PerceptionProperties[x].Write(writer);
        }
        for (x = 0; (x < _perceptionProperties.Count); x = (x + 1)) {
          PerceptionProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lookProperties.Count); x = (x + 1)) {
          LookProperties[x].Write(writer);
        }
        for (x = 0; (x < _lookProperties.Count); x = (x + 1)) {
          LookProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _movementProperties.Count); x = (x + 1)) {
          MovementProperties[x].Write(writer);
        }
        for (x = 0; (x < _movementProperties.Count); x = (x + 1)) {
          MovementProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _swarmProperties.Count); x = (x + 1)) {
          SwarmProperties[x].Write(writer);
        }
        for (x = 0; (x < _swarmProperties.Count); x = (x + 1)) {
          SwarmProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _readyProperties.Count); x = (x + 1)) {
          ReadyProperties[x].Write(writer);
        }
        for (x = 0; (x < _readyProperties.Count); x = (x + 1)) {
          ReadyProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _engageProperties.Count); x = (x + 1)) {
          EngageProperties[x].Write(writer);
        }
        for (x = 0; (x < _engageProperties.Count); x = (x + 1)) {
          EngageProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _chargeProperties.Count); x = (x + 1)) {
          ChargeProperties[x].Write(writer);
        }
        for (x = 0; (x < _chargeProperties.Count); x = (x + 1)) {
          ChargeProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _evasionProperties.Count); x = (x + 1)) {
          EvasionProperties[x].Write(writer);
        }
        for (x = 0; (x < _evasionProperties.Count); x = (x + 1)) {
          EvasionProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _coverProperties.Count); x = (x + 1)) {
          CoverProperties[x].Write(writer);
        }
        for (x = 0; (x < _coverProperties.Count); x = (x + 1)) {
          CoverProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _retreatProperties.Count); x = (x + 1)) {
          RetreatProperties[x].Write(writer);
        }
        for (x = 0; (x < _retreatProperties.Count); x = (x + 1)) {
          RetreatProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _searchProperties.Count); x = (x + 1)) {
          SearchProperties[x].Write(writer);
        }
        for (x = 0; (x < _searchProperties.Count); x = (x + 1)) {
          SearchProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pre_MinussearchProperties.Count); x = (x + 1)) {
          Pre_MinussearchProperties[x].Write(writer);
        }
        for (x = 0; (x < _pre_MinussearchProperties.Count); x = (x + 1)) {
          Pre_MinussearchProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _idleProperties.Count); x = (x + 1)) {
          IdleProperties[x].Write(writer);
        }
        for (x = 0; (x < _idleProperties.Count); x = (x + 1)) {
          IdleProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vocalizationProperties.Count); x = (x + 1)) {
          VocalizationProperties[x].Write(writer);
        }
        for (x = 0; (x < _vocalizationProperties.Count); x = (x + 1)) {
          VocalizationProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _boardingProperties.Count); x = (x + 1)) {
          BoardingProperties[x].Write(writer);
        }
        for (x = 0; (x < _boardingProperties.Count); x = (x + 1)) {
          BoardingProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bossProperties.Count); x = (x + 1)) {
          BossProperties[x].Write(writer);
        }
        for (x = 0; (x < _bossProperties.Count); x = (x + 1)) {
          BossProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponsProperties.Count); x = (x + 1)) {
          WeaponsProperties[x].Write(writer);
        }
        for (x = 0; (x < _weaponsProperties.Count); x = (x + 1)) {
          WeaponsProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _firingPatternProperties.Count); x = (x + 1)) {
          FiringPatternProperties[x].Write(writer);
        }
        for (x = 0; (x < _firingPatternProperties.Count); x = (x + 1)) {
          FiringPatternProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _grenadesProperties.Count); x = (x + 1)) {
          GrenadesProperties[x].Write(writer);
        }
        for (x = 0; (x < _grenadesProperties.Count); x = (x + 1)) {
          GrenadesProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vehicleProperties.Count); x = (x + 1)) {
          VehicleProperties[x].Write(writer);
        }
        for (x = 0; (x < _vehicleProperties.Count); x = (x + 1)) {
          VehicleProperties[x].WriteChildData(writer);
        }
      }
    }
    public class CharacterVariantsBlockBlock : IBlock {
      private StringId _variantName = new StringId();
      private ShortInteger _variantIndex = new ShortInteger();
      private Pad _unnamed0;
      private StringId _variantDesignator = new StringId();
public event System.EventHandler BlockNameChanged;
      public CharacterVariantsBlockBlock() {
if (this._variantName is System.ComponentModel.INotifyPropertyChanged)
  (this._variantName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _variantName.ToString();
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public ShortInteger VariantIndex {
        get {
          return this._variantIndex;
        }
        set {
          this._variantIndex = value;
        }
      }
      public StringId VariantDesignator {
        get {
          return this._variantDesignator;
        }
        set {
          this._variantDesignator = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _variantName.Read(reader);
        _variantIndex.Read(reader);
        _unnamed0.Read(reader);
        _variantDesignator.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
        _variantDesignator.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _variantName.Write(bw);
        _variantIndex.Write(bw);
        _unnamed0.Write(bw);
        _variantDesignator.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
        _variantDesignator.WriteString(writer);
      }
    }
    public class CharacterGeneralBlockBlock : IBlock {
      private Flags _generalFlags;
      private Enum _type;
      private Pad _unnamed0;
      private Real _scariness = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterGeneralBlockBlock() {
        this._generalFlags = new Flags(4);
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Flags GeneralFlags {
        get {
          return this._generalFlags;
        }
        set {
          this._generalFlags = value;
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Real Scariness {
        get {
          return this._scariness;
        }
        set {
          this._scariness = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _generalFlags.Read(reader);
        _type.Read(reader);
        _unnamed0.Read(reader);
        _scariness.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _generalFlags.Write(bw);
        _type.Write(bw);
        _unnamed0.Write(bw);
        _scariness.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterVitalityBlockBlock : IBlock {
      private Flags _vitalityFlags;
      private Real _normalBodyVitality = new Real();
      private Real _normalShieldVitality = new Real();
      private Real _legendaryBodyVitality = new Real();
      private Real _legendaryShieldVitality = new Real();
      private Real _bodyRechargeFraction = new Real();
      private Real _softPingThresholdWithShields = new Real();
      private Real _softPingThresholdNoShields = new Real();
      private Real _softPingMinInterruptTime = new Real();
      private Real _hardPingThresholdWithShields = new Real();
      private Real _hardPingThresholdNoShields = new Real();
      private Real _hardPingMinInterruptTime = new Real();
      private Real _currentDamageDecayDelay = new Real();
      private Real _currentDamageDecayTime = new Real();
      private Real _recentDamageDecayDelay = new Real();
      private Real _recentDamageDecayTime = new Real();
      private Real _bodyRechargeDelayTime = new Real();
      private Real _bodyRechargeTime = new Real();
      private Real _shieldRechargeDelayTime = new Real();
      private Real _shieldRechargeTime = new Real();
      private Real _stunThreshold = new Real();
      private RealBounds _stunTimeBounds = new RealBounds();
      private Real _extendedShieldDamageThreshold = new Real();
      private Real _extendedBodyDamageThreshold = new Real();
      private Real _suicideRadius = new Real();
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public CharacterVitalityBlockBlock() {
        this._vitalityFlags = new Flags(4);
        this._unnamed0 = new Skip(8);
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
      public Flags VitalityFlags {
        get {
          return this._vitalityFlags;
        }
        set {
          this._vitalityFlags = value;
        }
      }
      public Real NormalBodyVitality {
        get {
          return this._normalBodyVitality;
        }
        set {
          this._normalBodyVitality = value;
        }
      }
      public Real NormalShieldVitality {
        get {
          return this._normalShieldVitality;
        }
        set {
          this._normalShieldVitality = value;
        }
      }
      public Real LegendaryBodyVitality {
        get {
          return this._legendaryBodyVitality;
        }
        set {
          this._legendaryBodyVitality = value;
        }
      }
      public Real LegendaryShieldVitality {
        get {
          return this._legendaryShieldVitality;
        }
        set {
          this._legendaryShieldVitality = value;
        }
      }
      public Real BodyRechargeFraction {
        get {
          return this._bodyRechargeFraction;
        }
        set {
          this._bodyRechargeFraction = value;
        }
      }
      public Real SoftPingThresholdWithShields {
        get {
          return this._softPingThresholdWithShields;
        }
        set {
          this._softPingThresholdWithShields = value;
        }
      }
      public Real SoftPingThresholdNoShields {
        get {
          return this._softPingThresholdNoShields;
        }
        set {
          this._softPingThresholdNoShields = value;
        }
      }
      public Real SoftPingMinInterruptTime {
        get {
          return this._softPingMinInterruptTime;
        }
        set {
          this._softPingMinInterruptTime = value;
        }
      }
      public Real HardPingThresholdWithShields {
        get {
          return this._hardPingThresholdWithShields;
        }
        set {
          this._hardPingThresholdWithShields = value;
        }
      }
      public Real HardPingThresholdNoShields {
        get {
          return this._hardPingThresholdNoShields;
        }
        set {
          this._hardPingThresholdNoShields = value;
        }
      }
      public Real HardPingMinInterruptTime {
        get {
          return this._hardPingMinInterruptTime;
        }
        set {
          this._hardPingMinInterruptTime = value;
        }
      }
      public Real CurrentDamageDecayDelay {
        get {
          return this._currentDamageDecayDelay;
        }
        set {
          this._currentDamageDecayDelay = value;
        }
      }
      public Real CurrentDamageDecayTime {
        get {
          return this._currentDamageDecayTime;
        }
        set {
          this._currentDamageDecayTime = value;
        }
      }
      public Real RecentDamageDecayDelay {
        get {
          return this._recentDamageDecayDelay;
        }
        set {
          this._recentDamageDecayDelay = value;
        }
      }
      public Real RecentDamageDecayTime {
        get {
          return this._recentDamageDecayTime;
        }
        set {
          this._recentDamageDecayTime = value;
        }
      }
      public Real BodyRechargeDelayTime {
        get {
          return this._bodyRechargeDelayTime;
        }
        set {
          this._bodyRechargeDelayTime = value;
        }
      }
      public Real BodyRechargeTime {
        get {
          return this._bodyRechargeTime;
        }
        set {
          this._bodyRechargeTime = value;
        }
      }
      public Real ShieldRechargeDelayTime {
        get {
          return this._shieldRechargeDelayTime;
        }
        set {
          this._shieldRechargeDelayTime = value;
        }
      }
      public Real ShieldRechargeTime {
        get {
          return this._shieldRechargeTime;
        }
        set {
          this._shieldRechargeTime = value;
        }
      }
      public Real StunThreshold {
        get {
          return this._stunThreshold;
        }
        set {
          this._stunThreshold = value;
        }
      }
      public RealBounds StunTimeBounds {
        get {
          return this._stunTimeBounds;
        }
        set {
          this._stunTimeBounds = value;
        }
      }
      public Real ExtendedShieldDamageThreshold {
        get {
          return this._extendedShieldDamageThreshold;
        }
        set {
          this._extendedShieldDamageThreshold = value;
        }
      }
      public Real ExtendedBodyDamageThreshold {
        get {
          return this._extendedBodyDamageThreshold;
        }
        set {
          this._extendedBodyDamageThreshold = value;
        }
      }
      public Real SuicideRadius {
        get {
          return this._suicideRadius;
        }
        set {
          this._suicideRadius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vitalityFlags.Read(reader);
        _normalBodyVitality.Read(reader);
        _normalShieldVitality.Read(reader);
        _legendaryBodyVitality.Read(reader);
        _legendaryShieldVitality.Read(reader);
        _bodyRechargeFraction.Read(reader);
        _softPingThresholdWithShields.Read(reader);
        _softPingThresholdNoShields.Read(reader);
        _softPingMinInterruptTime.Read(reader);
        _hardPingThresholdWithShields.Read(reader);
        _hardPingThresholdNoShields.Read(reader);
        _hardPingMinInterruptTime.Read(reader);
        _currentDamageDecayDelay.Read(reader);
        _currentDamageDecayTime.Read(reader);
        _recentDamageDecayDelay.Read(reader);
        _recentDamageDecayTime.Read(reader);
        _bodyRechargeDelayTime.Read(reader);
        _bodyRechargeTime.Read(reader);
        _shieldRechargeDelayTime.Read(reader);
        _shieldRechargeTime.Read(reader);
        _stunThreshold.Read(reader);
        _stunTimeBounds.Read(reader);
        _extendedShieldDamageThreshold.Read(reader);
        _extendedBodyDamageThreshold.Read(reader);
        _suicideRadius.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vitalityFlags.Write(bw);
        _normalBodyVitality.Write(bw);
        _normalShieldVitality.Write(bw);
        _legendaryBodyVitality.Write(bw);
        _legendaryShieldVitality.Write(bw);
        _bodyRechargeFraction.Write(bw);
        _softPingThresholdWithShields.Write(bw);
        _softPingThresholdNoShields.Write(bw);
        _softPingMinInterruptTime.Write(bw);
        _hardPingThresholdWithShields.Write(bw);
        _hardPingThresholdNoShields.Write(bw);
        _hardPingMinInterruptTime.Write(bw);
        _currentDamageDecayDelay.Write(bw);
        _currentDamageDecayTime.Write(bw);
        _recentDamageDecayDelay.Write(bw);
        _recentDamageDecayTime.Write(bw);
        _bodyRechargeDelayTime.Write(bw);
        _bodyRechargeTime.Write(bw);
        _shieldRechargeDelayTime.Write(bw);
        _shieldRechargeTime.Write(bw);
        _stunThreshold.Write(bw);
        _stunTimeBounds.Write(bw);
        _extendedShieldDamageThreshold.Write(bw);
        _extendedBodyDamageThreshold.Write(bw);
        _suicideRadius.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterPlacementBlockBlock : IBlock {
      private Pad _unnamed0;
      private Real _fewUpgradeChanceEasy = new Real();
      private Real _fewUpgradeChanceNormal = new Real();
      private Real _fewUpgradeChanceHeroic = new Real();
      private Real _fewUpgradeChanceLegendary = new Real();
      private Real _normalUpgradeChanceEasy = new Real();
      private Real _normalUpgradeChanceNormal = new Real();
      private Real _normalUpgradeChanceHeroic = new Real();
      private Real _normalUpgradeChanceLegendary = new Real();
      private Real _manyUpgradeChanceEasy = new Real();
      private Real _manyUpgradeChanceNormal = new Real();
      private Real _manyUpgradeChanceHeroic = new Real();
      private Real _manyUpgradeChanceLegendary = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterPlacementBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public Real FewUpgradeChanceEasy {
        get {
          return this._fewUpgradeChanceEasy;
        }
        set {
          this._fewUpgradeChanceEasy = value;
        }
      }
      public Real FewUpgradeChanceNormal {
        get {
          return this._fewUpgradeChanceNormal;
        }
        set {
          this._fewUpgradeChanceNormal = value;
        }
      }
      public Real FewUpgradeChanceHeroic {
        get {
          return this._fewUpgradeChanceHeroic;
        }
        set {
          this._fewUpgradeChanceHeroic = value;
        }
      }
      public Real FewUpgradeChanceLegendary {
        get {
          return this._fewUpgradeChanceLegendary;
        }
        set {
          this._fewUpgradeChanceLegendary = value;
        }
      }
      public Real NormalUpgradeChanceEasy {
        get {
          return this._normalUpgradeChanceEasy;
        }
        set {
          this._normalUpgradeChanceEasy = value;
        }
      }
      public Real NormalUpgradeChanceNormal {
        get {
          return this._normalUpgradeChanceNormal;
        }
        set {
          this._normalUpgradeChanceNormal = value;
        }
      }
      public Real NormalUpgradeChanceHeroic {
        get {
          return this._normalUpgradeChanceHeroic;
        }
        set {
          this._normalUpgradeChanceHeroic = value;
        }
      }
      public Real NormalUpgradeChanceLegendary {
        get {
          return this._normalUpgradeChanceLegendary;
        }
        set {
          this._normalUpgradeChanceLegendary = value;
        }
      }
      public Real ManyUpgradeChanceEasy {
        get {
          return this._manyUpgradeChanceEasy;
        }
        set {
          this._manyUpgradeChanceEasy = value;
        }
      }
      public Real ManyUpgradeChanceNormal {
        get {
          return this._manyUpgradeChanceNormal;
        }
        set {
          this._manyUpgradeChanceNormal = value;
        }
      }
      public Real ManyUpgradeChanceHeroic {
        get {
          return this._manyUpgradeChanceHeroic;
        }
        set {
          this._manyUpgradeChanceHeroic = value;
        }
      }
      public Real ManyUpgradeChanceLegendary {
        get {
          return this._manyUpgradeChanceLegendary;
        }
        set {
          this._manyUpgradeChanceLegendary = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _fewUpgradeChanceEasy.Read(reader);
        _fewUpgradeChanceNormal.Read(reader);
        _fewUpgradeChanceHeroic.Read(reader);
        _fewUpgradeChanceLegendary.Read(reader);
        _normalUpgradeChanceEasy.Read(reader);
        _normalUpgradeChanceNormal.Read(reader);
        _normalUpgradeChanceHeroic.Read(reader);
        _normalUpgradeChanceLegendary.Read(reader);
        _manyUpgradeChanceEasy.Read(reader);
        _manyUpgradeChanceNormal.Read(reader);
        _manyUpgradeChanceHeroic.Read(reader);
        _manyUpgradeChanceLegendary.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _fewUpgradeChanceEasy.Write(bw);
        _fewUpgradeChanceNormal.Write(bw);
        _fewUpgradeChanceHeroic.Write(bw);
        _fewUpgradeChanceLegendary.Write(bw);
        _normalUpgradeChanceEasy.Write(bw);
        _normalUpgradeChanceNormal.Write(bw);
        _normalUpgradeChanceHeroic.Write(bw);
        _normalUpgradeChanceLegendary.Write(bw);
        _manyUpgradeChanceEasy.Write(bw);
        _manyUpgradeChanceNormal.Write(bw);
        _manyUpgradeChanceHeroic.Write(bw);
        _manyUpgradeChanceLegendary.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterPerceptionBlockBlock : IBlock {
      private Flags _perceptionFlags;
      private Real _maxVisionDistance = new Real();
      private Angle _centralVisionAngle = new Angle();
      private Angle _maxVisionAngle = new Angle();
      private Angle _peripheralVisionAngle = new Angle();
      private Real _peripheralDistance = new Real();
      private Real _hearingDistance = new Real();
      private Real _noticeProjectileChance = new Real();
      private Real _noticeVehicleChance = new Real();
      private Real _combatPerceptionTime = new Real();
      private Real _guardPerceptionTime = new Real();
      private Real _non_MinuscombatPerceptionTime = new Real();
      private Real _firstAckSurpriseDistance = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterPerceptionBlockBlock() {
        this._perceptionFlags = new Flags(4);
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
      public Flags PerceptionFlags {
        get {
          return this._perceptionFlags;
        }
        set {
          this._perceptionFlags = value;
        }
      }
      public Real MaxVisionDistance {
        get {
          return this._maxVisionDistance;
        }
        set {
          this._maxVisionDistance = value;
        }
      }
      public Angle CentralVisionAngle {
        get {
          return this._centralVisionAngle;
        }
        set {
          this._centralVisionAngle = value;
        }
      }
      public Angle MaxVisionAngle {
        get {
          return this._maxVisionAngle;
        }
        set {
          this._maxVisionAngle = value;
        }
      }
      public Angle PeripheralVisionAngle {
        get {
          return this._peripheralVisionAngle;
        }
        set {
          this._peripheralVisionAngle = value;
        }
      }
      public Real PeripheralDistance {
        get {
          return this._peripheralDistance;
        }
        set {
          this._peripheralDistance = value;
        }
      }
      public Real HearingDistance {
        get {
          return this._hearingDistance;
        }
        set {
          this._hearingDistance = value;
        }
      }
      public Real NoticeProjectileChance {
        get {
          return this._noticeProjectileChance;
        }
        set {
          this._noticeProjectileChance = value;
        }
      }
      public Real NoticeVehicleChance {
        get {
          return this._noticeVehicleChance;
        }
        set {
          this._noticeVehicleChance = value;
        }
      }
      public Real CombatPerceptionTime {
        get {
          return this._combatPerceptionTime;
        }
        set {
          this._combatPerceptionTime = value;
        }
      }
      public Real GuardPerceptionTime {
        get {
          return this._guardPerceptionTime;
        }
        set {
          this._guardPerceptionTime = value;
        }
      }
      public Real Non_MinuscombatPerceptionTime {
        get {
          return this._non_MinuscombatPerceptionTime;
        }
        set {
          this._non_MinuscombatPerceptionTime = value;
        }
      }
      public Real FirstAckSurpriseDistance {
        get {
          return this._firstAckSurpriseDistance;
        }
        set {
          this._firstAckSurpriseDistance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _perceptionFlags.Read(reader);
        _maxVisionDistance.Read(reader);
        _centralVisionAngle.Read(reader);
        _maxVisionAngle.Read(reader);
        _peripheralVisionAngle.Read(reader);
        _peripheralDistance.Read(reader);
        _hearingDistance.Read(reader);
        _noticeProjectileChance.Read(reader);
        _noticeVehicleChance.Read(reader);
        _combatPerceptionTime.Read(reader);
        _guardPerceptionTime.Read(reader);
        _non_MinuscombatPerceptionTime.Read(reader);
        _firstAckSurpriseDistance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _perceptionFlags.Write(bw);
        _maxVisionDistance.Write(bw);
        _centralVisionAngle.Write(bw);
        _maxVisionAngle.Write(bw);
        _peripheralVisionAngle.Write(bw);
        _peripheralDistance.Write(bw);
        _hearingDistance.Write(bw);
        _noticeProjectileChance.Write(bw);
        _noticeVehicleChance.Write(bw);
        _combatPerceptionTime.Write(bw);
        _guardPerceptionTime.Write(bw);
        _non_MinuscombatPerceptionTime.Write(bw);
        _firstAckSurpriseDistance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterLookBlockBlock : IBlock {
      private RealEulerAngles2D _maximumAimingDeviation = new RealEulerAngles2D();
      private RealEulerAngles2D _maximumLookingDeviation = new RealEulerAngles2D();
      private Pad _unnamed0;
      private Angle _noncombatLookDeltaL = new Angle();
      private Angle _noncombatLookDeltaR = new Angle();
      private Angle _combatLookDeltaL = new Angle();
      private Angle _combatLookDeltaR = new Angle();
      private RealBounds _noncombatIdleLooking = new RealBounds();
      private RealBounds _noncombatIdleAiming = new RealBounds();
      private RealBounds _combatIdleLooking = new RealBounds();
      private RealBounds _combatIdleAiming = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public CharacterLookBlockBlock() {
        this._unnamed0 = new Pad(16);
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
      public RealEulerAngles2D MaximumAimingDeviation {
        get {
          return this._maximumAimingDeviation;
        }
        set {
          this._maximumAimingDeviation = value;
        }
      }
      public RealEulerAngles2D MaximumLookingDeviation {
        get {
          return this._maximumLookingDeviation;
        }
        set {
          this._maximumLookingDeviation = value;
        }
      }
      public Angle NoncombatLookDeltaL {
        get {
          return this._noncombatLookDeltaL;
        }
        set {
          this._noncombatLookDeltaL = value;
        }
      }
      public Angle NoncombatLookDeltaR {
        get {
          return this._noncombatLookDeltaR;
        }
        set {
          this._noncombatLookDeltaR = value;
        }
      }
      public Angle CombatLookDeltaL {
        get {
          return this._combatLookDeltaL;
        }
        set {
          this._combatLookDeltaL = value;
        }
      }
      public Angle CombatLookDeltaR {
        get {
          return this._combatLookDeltaR;
        }
        set {
          this._combatLookDeltaR = value;
        }
      }
      public RealBounds NoncombatIdleLooking {
        get {
          return this._noncombatIdleLooking;
        }
        set {
          this._noncombatIdleLooking = value;
        }
      }
      public RealBounds NoncombatIdleAiming {
        get {
          return this._noncombatIdleAiming;
        }
        set {
          this._noncombatIdleAiming = value;
        }
      }
      public RealBounds CombatIdleLooking {
        get {
          return this._combatIdleLooking;
        }
        set {
          this._combatIdleLooking = value;
        }
      }
      public RealBounds CombatIdleAiming {
        get {
          return this._combatIdleAiming;
        }
        set {
          this._combatIdleAiming = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _maximumAimingDeviation.Read(reader);
        _maximumLookingDeviation.Read(reader);
        _unnamed0.Read(reader);
        _noncombatLookDeltaL.Read(reader);
        _noncombatLookDeltaR.Read(reader);
        _combatLookDeltaL.Read(reader);
        _combatLookDeltaR.Read(reader);
        _noncombatIdleLooking.Read(reader);
        _noncombatIdleAiming.Read(reader);
        _combatIdleLooking.Read(reader);
        _combatIdleAiming.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _maximumAimingDeviation.Write(bw);
        _maximumLookingDeviation.Write(bw);
        _unnamed0.Write(bw);
        _noncombatLookDeltaL.Write(bw);
        _noncombatLookDeltaR.Write(bw);
        _combatLookDeltaL.Write(bw);
        _combatLookDeltaR.Write(bw);
        _noncombatIdleLooking.Write(bw);
        _noncombatIdleAiming.Write(bw);
        _combatIdleLooking.Write(bw);
        _combatIdleAiming.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterMovementBlockBlock : IBlock {
      private Flags _movementFlags;
      private Real _pathfindingRadius = new Real();
      private Real _destinationRadius = new Real();
      private Real _diveGrenadeChance = new Real();
      private Enum _obstacleLeapMinSize;
      private Enum _obstacleLeapMaxSize;
      private Enum _obstacleIgnoreSize;
      private Enum _obstacleSmashableSize;
      private Pad _unnamed0;
      private Enum _jumpHeight;
      private Flags _movementHints;
      private Real _throttleScale = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterMovementBlockBlock() {
        this._movementFlags = new Flags(4);
        this._obstacleLeapMinSize = new Enum(2);
        this._obstacleLeapMaxSize = new Enum(2);
        this._obstacleIgnoreSize = new Enum(2);
        this._obstacleSmashableSize = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._jumpHeight = new Enum(2);
        this._movementHints = new Flags(4);
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
      public Flags MovementFlags {
        get {
          return this._movementFlags;
        }
        set {
          this._movementFlags = value;
        }
      }
      public Real PathfindingRadius {
        get {
          return this._pathfindingRadius;
        }
        set {
          this._pathfindingRadius = value;
        }
      }
      public Real DestinationRadius {
        get {
          return this._destinationRadius;
        }
        set {
          this._destinationRadius = value;
        }
      }
      public Real DiveGrenadeChance {
        get {
          return this._diveGrenadeChance;
        }
        set {
          this._diveGrenadeChance = value;
        }
      }
      public Enum ObstacleLeapMinSize {
        get {
          return this._obstacleLeapMinSize;
        }
        set {
          this._obstacleLeapMinSize = value;
        }
      }
      public Enum ObstacleLeapMaxSize {
        get {
          return this._obstacleLeapMaxSize;
        }
        set {
          this._obstacleLeapMaxSize = value;
        }
      }
      public Enum ObstacleIgnoreSize {
        get {
          return this._obstacleIgnoreSize;
        }
        set {
          this._obstacleIgnoreSize = value;
        }
      }
      public Enum ObstacleSmashableSize {
        get {
          return this._obstacleSmashableSize;
        }
        set {
          this._obstacleSmashableSize = value;
        }
      }
      public Enum JumpHeight {
        get {
          return this._jumpHeight;
        }
        set {
          this._jumpHeight = value;
        }
      }
      public Flags MovementHints {
        get {
          return this._movementHints;
        }
        set {
          this._movementHints = value;
        }
      }
      public Real ThrottleScale {
        get {
          return this._throttleScale;
        }
        set {
          this._throttleScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _movementFlags.Read(reader);
        _pathfindingRadius.Read(reader);
        _destinationRadius.Read(reader);
        _diveGrenadeChance.Read(reader);
        _obstacleLeapMinSize.Read(reader);
        _obstacleLeapMaxSize.Read(reader);
        _obstacleIgnoreSize.Read(reader);
        _obstacleSmashableSize.Read(reader);
        _unnamed0.Read(reader);
        _jumpHeight.Read(reader);
        _movementHints.Read(reader);
        _throttleScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _movementFlags.Write(bw);
        _pathfindingRadius.Write(bw);
        _destinationRadius.Write(bw);
        _diveGrenadeChance.Write(bw);
        _obstacleLeapMinSize.Write(bw);
        _obstacleLeapMaxSize.Write(bw);
        _obstacleIgnoreSize.Write(bw);
        _obstacleSmashableSize.Write(bw);
        _unnamed0.Write(bw);
        _jumpHeight.Write(bw);
        _movementHints.Write(bw);
        _throttleScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterSwarmBlockBlock : IBlock {
      private ShortInteger _scatterKilledCount = new ShortInteger();
      private Pad _unnamed0;
      private Real _scatterRadius = new Real();
      private Real _scatterTime = new Real();
      private Real _houndMinDistance = new Real();
      private Real _houndMaxDistance = new Real();
      private Real _perlinOffsetScale = new Real();
      private RealBounds _offsetPeriod = new RealBounds();
      private Real _perlinIdleMovementThreshold = new Real();
      private Real _perlinCombatMovementThreshold = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterSwarmBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger ScatterKilledCount {
        get {
          return this._scatterKilledCount;
        }
        set {
          this._scatterKilledCount = value;
        }
      }
      public Real ScatterRadius {
        get {
          return this._scatterRadius;
        }
        set {
          this._scatterRadius = value;
        }
      }
      public Real ScatterTime {
        get {
          return this._scatterTime;
        }
        set {
          this._scatterTime = value;
        }
      }
      public Real HoundMinDistance {
        get {
          return this._houndMinDistance;
        }
        set {
          this._houndMinDistance = value;
        }
      }
      public Real HoundMaxDistance {
        get {
          return this._houndMaxDistance;
        }
        set {
          this._houndMaxDistance = value;
        }
      }
      public Real PerlinOffsetScale {
        get {
          return this._perlinOffsetScale;
        }
        set {
          this._perlinOffsetScale = value;
        }
      }
      public RealBounds OffsetPeriod {
        get {
          return this._offsetPeriod;
        }
        set {
          this._offsetPeriod = value;
        }
      }
      public Real PerlinIdleMovementThreshold {
        get {
          return this._perlinIdleMovementThreshold;
        }
        set {
          this._perlinIdleMovementThreshold = value;
        }
      }
      public Real PerlinCombatMovementThreshold {
        get {
          return this._perlinCombatMovementThreshold;
        }
        set {
          this._perlinCombatMovementThreshold = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scatterKilledCount.Read(reader);
        _unnamed0.Read(reader);
        _scatterRadius.Read(reader);
        _scatterTime.Read(reader);
        _houndMinDistance.Read(reader);
        _houndMaxDistance.Read(reader);
        _perlinOffsetScale.Read(reader);
        _offsetPeriod.Read(reader);
        _perlinIdleMovementThreshold.Read(reader);
        _perlinCombatMovementThreshold.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scatterKilledCount.Write(bw);
        _unnamed0.Write(bw);
        _scatterRadius.Write(bw);
        _scatterTime.Write(bw);
        _houndMinDistance.Write(bw);
        _houndMaxDistance.Write(bw);
        _perlinOffsetScale.Write(bw);
        _offsetPeriod.Write(bw);
        _perlinIdleMovementThreshold.Write(bw);
        _perlinCombatMovementThreshold.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterReadyBlockBlock : IBlock {
      private RealBounds _readyTimeBounds = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public CharacterReadyBlockBlock() {
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
      public RealBounds ReadyTimeBounds {
        get {
          return this._readyTimeBounds;
        }
        set {
          this._readyTimeBounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _readyTimeBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _readyTimeBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterEngageBlockBlock : IBlock {
      private Flags _flags;
      private Real _crouchDangerThreshold = new Real();
      private Real _standDangerThreshold = new Real();
      private Real _fightDangerMoveThreshold = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterEngageBlockBlock() {
        this._flags = new Flags(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real CrouchDangerThreshold {
        get {
          return this._crouchDangerThreshold;
        }
        set {
          this._crouchDangerThreshold = value;
        }
      }
      public Real StandDangerThreshold {
        get {
          return this._standDangerThreshold;
        }
        set {
          this._standDangerThreshold = value;
        }
      }
      public Real FightDangerMoveThreshold {
        get {
          return this._fightDangerMoveThreshold;
        }
        set {
          this._fightDangerMoveThreshold = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _crouchDangerThreshold.Read(reader);
        _standDangerThreshold.Read(reader);
        _fightDangerMoveThreshold.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _crouchDangerThreshold.Write(bw);
        _standDangerThreshold.Write(bw);
        _fightDangerMoveThreshold.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterChargeBlockBlock : IBlock {
      private Flags _chargeFlags;
      private Real _meleeConsiderRange = new Real();
      private Real _meleeChance = new Real();
      private Real _meleeAttackRange = new Real();
      private Real _meleeAbortRange = new Real();
      private Real _meleeAttackTimeout = new Real();
      private Real _meleeAttackDelayTimer = new Real();
      private RealBounds _meleeLeapRange = new RealBounds();
      private Real _meleeLeapChance = new Real();
      private Real _idealLeapVelocity = new Real();
      private Real _maxLeapVelocity = new Real();
      private Real _meleeLeapBallistic = new Real();
      private Real _meleeDelayTimer = new Real();
      private TagReference _berserkWeapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CharacterChargeBlockBlock() {
        this._chargeFlags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_berserkWeapon.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Flags ChargeFlags {
        get {
          return this._chargeFlags;
        }
        set {
          this._chargeFlags = value;
        }
      }
      public Real MeleeConsiderRange {
        get {
          return this._meleeConsiderRange;
        }
        set {
          this._meleeConsiderRange = value;
        }
      }
      public Real MeleeChance {
        get {
          return this._meleeChance;
        }
        set {
          this._meleeChance = value;
        }
      }
      public Real MeleeAttackRange {
        get {
          return this._meleeAttackRange;
        }
        set {
          this._meleeAttackRange = value;
        }
      }
      public Real MeleeAbortRange {
        get {
          return this._meleeAbortRange;
        }
        set {
          this._meleeAbortRange = value;
        }
      }
      public Real MeleeAttackTimeout {
        get {
          return this._meleeAttackTimeout;
        }
        set {
          this._meleeAttackTimeout = value;
        }
      }
      public Real MeleeAttackDelayTimer {
        get {
          return this._meleeAttackDelayTimer;
        }
        set {
          this._meleeAttackDelayTimer = value;
        }
      }
      public RealBounds MeleeLeapRange {
        get {
          return this._meleeLeapRange;
        }
        set {
          this._meleeLeapRange = value;
        }
      }
      public Real MeleeLeapChance {
        get {
          return this._meleeLeapChance;
        }
        set {
          this._meleeLeapChance = value;
        }
      }
      public Real IdealLeapVelocity {
        get {
          return this._idealLeapVelocity;
        }
        set {
          this._idealLeapVelocity = value;
        }
      }
      public Real MaxLeapVelocity {
        get {
          return this._maxLeapVelocity;
        }
        set {
          this._maxLeapVelocity = value;
        }
      }
      public Real MeleeLeapBallistic {
        get {
          return this._meleeLeapBallistic;
        }
        set {
          this._meleeLeapBallistic = value;
        }
      }
      public Real MeleeDelayTimer {
        get {
          return this._meleeDelayTimer;
        }
        set {
          this._meleeDelayTimer = value;
        }
      }
      public TagReference BerserkWeapon {
        get {
          return this._berserkWeapon;
        }
        set {
          this._berserkWeapon = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _chargeFlags.Read(reader);
        _meleeConsiderRange.Read(reader);
        _meleeChance.Read(reader);
        _meleeAttackRange.Read(reader);
        _meleeAbortRange.Read(reader);
        _meleeAttackTimeout.Read(reader);
        _meleeAttackDelayTimer.Read(reader);
        _meleeLeapRange.Read(reader);
        _meleeLeapChance.Read(reader);
        _idealLeapVelocity.Read(reader);
        _maxLeapVelocity.Read(reader);
        _meleeLeapBallistic.Read(reader);
        _meleeDelayTimer.Read(reader);
        _berserkWeapon.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _berserkWeapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _chargeFlags.Write(bw);
        _meleeConsiderRange.Write(bw);
        _meleeChance.Write(bw);
        _meleeAttackRange.Write(bw);
        _meleeAbortRange.Write(bw);
        _meleeAttackTimeout.Write(bw);
        _meleeAttackDelayTimer.Write(bw);
        _meleeLeapRange.Write(bw);
        _meleeLeapChance.Write(bw);
        _idealLeapVelocity.Write(bw);
        _maxLeapVelocity.Write(bw);
        _meleeLeapBallistic.Write(bw);
        _meleeDelayTimer.Write(bw);
        _berserkWeapon.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _berserkWeapon.WriteString(writer);
      }
    }
    public class CharacterEvasionBlockBlock : IBlock {
      private Real _evasionDangerThreshold = new Real();
      private Real _evasionDelayTimer = new Real();
      private Real _evasionChance = new Real();
      private Real _evasionProximityThreshold = new Real();
      private Real _diveRetreatChance = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterEvasionBlockBlock() {
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
      public Real EvasionDangerThreshold {
        get {
          return this._evasionDangerThreshold;
        }
        set {
          this._evasionDangerThreshold = value;
        }
      }
      public Real EvasionDelayTimer {
        get {
          return this._evasionDelayTimer;
        }
        set {
          this._evasionDelayTimer = value;
        }
      }
      public Real EvasionChance {
        get {
          return this._evasionChance;
        }
        set {
          this._evasionChance = value;
        }
      }
      public Real EvasionProximityThreshold {
        get {
          return this._evasionProximityThreshold;
        }
        set {
          this._evasionProximityThreshold = value;
        }
      }
      public Real DiveRetreatChance {
        get {
          return this._diveRetreatChance;
        }
        set {
          this._diveRetreatChance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _evasionDangerThreshold.Read(reader);
        _evasionDelayTimer.Read(reader);
        _evasionChance.Read(reader);
        _evasionProximityThreshold.Read(reader);
        _diveRetreatChance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _evasionDangerThreshold.Write(bw);
        _evasionDelayTimer.Write(bw);
        _evasionChance.Write(bw);
        _evasionProximityThreshold.Write(bw);
        _diveRetreatChance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterCoverBlockBlock : IBlock {
      private Flags _coverFlags;
      private RealBounds _hideBehindCoverTime = new RealBounds();
      private Real _coverVitalityThreshold = new Real();
      private Real _coverShieldFraction = new Real();
      private Real _coverCheckDelay = new Real();
      private Real _emergeFromCoverWhenShieldFractionReachesThreshold = new Real();
      private Real _coverDangerThreshold = new Real();
      private Real _dangerUpperThreshold = new Real();
      private RealBounds _coverChance = new RealBounds();
      private Real _proximitySelf_Minuspreserve = new Real();
      private Real _disallowCoverDistance = new Real();
      private Real _proximityMeleeDistance = new Real();
      private Real _unreachableEnemyDangerThreshold = new Real();
      private Real _scaryTargetThreshold = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterCoverBlockBlock() {
        this._coverFlags = new Flags(4);
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
      public Flags CoverFlags {
        get {
          return this._coverFlags;
        }
        set {
          this._coverFlags = value;
        }
      }
      public RealBounds HideBehindCoverTime {
        get {
          return this._hideBehindCoverTime;
        }
        set {
          this._hideBehindCoverTime = value;
        }
      }
      public Real CoverVitalityThreshold {
        get {
          return this._coverVitalityThreshold;
        }
        set {
          this._coverVitalityThreshold = value;
        }
      }
      public Real CoverShieldFraction {
        get {
          return this._coverShieldFraction;
        }
        set {
          this._coverShieldFraction = value;
        }
      }
      public Real CoverCheckDelay {
        get {
          return this._coverCheckDelay;
        }
        set {
          this._coverCheckDelay = value;
        }
      }
      public Real EmergeFromCoverWhenShieldFractionReachesThreshold {
        get {
          return this._emergeFromCoverWhenShieldFractionReachesThreshold;
        }
        set {
          this._emergeFromCoverWhenShieldFractionReachesThreshold = value;
        }
      }
      public Real CoverDangerThreshold {
        get {
          return this._coverDangerThreshold;
        }
        set {
          this._coverDangerThreshold = value;
        }
      }
      public Real DangerUpperThreshold {
        get {
          return this._dangerUpperThreshold;
        }
        set {
          this._dangerUpperThreshold = value;
        }
      }
      public RealBounds CoverChance {
        get {
          return this._coverChance;
        }
        set {
          this._coverChance = value;
        }
      }
      public Real ProximitySelf_Minuspreserve {
        get {
          return this._proximitySelf_Minuspreserve;
        }
        set {
          this._proximitySelf_Minuspreserve = value;
        }
      }
      public Real DisallowCoverDistance {
        get {
          return this._disallowCoverDistance;
        }
        set {
          this._disallowCoverDistance = value;
        }
      }
      public Real ProximityMeleeDistance {
        get {
          return this._proximityMeleeDistance;
        }
        set {
          this._proximityMeleeDistance = value;
        }
      }
      public Real UnreachableEnemyDangerThreshold {
        get {
          return this._unreachableEnemyDangerThreshold;
        }
        set {
          this._unreachableEnemyDangerThreshold = value;
        }
      }
      public Real ScaryTargetThreshold {
        get {
          return this._scaryTargetThreshold;
        }
        set {
          this._scaryTargetThreshold = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _coverFlags.Read(reader);
        _hideBehindCoverTime.Read(reader);
        _coverVitalityThreshold.Read(reader);
        _coverShieldFraction.Read(reader);
        _coverCheckDelay.Read(reader);
        _emergeFromCoverWhenShieldFractionReachesThreshold.Read(reader);
        _coverDangerThreshold.Read(reader);
        _dangerUpperThreshold.Read(reader);
        _coverChance.Read(reader);
        _proximitySelf_Minuspreserve.Read(reader);
        _disallowCoverDistance.Read(reader);
        _proximityMeleeDistance.Read(reader);
        _unreachableEnemyDangerThreshold.Read(reader);
        _scaryTargetThreshold.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _coverFlags.Write(bw);
        _hideBehindCoverTime.Write(bw);
        _coverVitalityThreshold.Write(bw);
        _coverShieldFraction.Write(bw);
        _coverCheckDelay.Write(bw);
        _emergeFromCoverWhenShieldFractionReachesThreshold.Write(bw);
        _coverDangerThreshold.Write(bw);
        _dangerUpperThreshold.Write(bw);
        _coverChance.Write(bw);
        _proximitySelf_Minuspreserve.Write(bw);
        _disallowCoverDistance.Write(bw);
        _proximityMeleeDistance.Write(bw);
        _unreachableEnemyDangerThreshold.Write(bw);
        _scaryTargetThreshold.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterRetreatBlockBlock : IBlock {
      private Flags _retreatFlags;
      private Real _shieldThreshold = new Real();
      private Real _scaryTargetThreshold = new Real();
      private Real _dangerThreshold = new Real();
      private Real _proximityThreshold = new Real();
      private RealBounds _minmaxForcedCowerTimeBounds = new RealBounds();
      private RealBounds _minmaxCowerTimeoutBounds = new RealBounds();
      private Real _proximityAmbushThreshold = new Real();
      private Real _awarenessAmbushThreshold = new Real();
      private Real _leaderDeadRetreatChance = new Real();
      private Real _peerDeadRetreatChance = new Real();
      private Real _secondPeerDeadRetreatChance = new Real();
      private Angle _zig_MinuszagAngle = new Angle();
      private Real _zig_MinuszagPeriod = new Real();
      private Real _retreatGrenadeChance = new Real();
      private TagReference _backupWeapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CharacterRetreatBlockBlock() {
        this._retreatFlags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backupWeapon.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Flags RetreatFlags {
        get {
          return this._retreatFlags;
        }
        set {
          this._retreatFlags = value;
        }
      }
      public Real ShieldThreshold {
        get {
          return this._shieldThreshold;
        }
        set {
          this._shieldThreshold = value;
        }
      }
      public Real ScaryTargetThreshold {
        get {
          return this._scaryTargetThreshold;
        }
        set {
          this._scaryTargetThreshold = value;
        }
      }
      public Real DangerThreshold {
        get {
          return this._dangerThreshold;
        }
        set {
          this._dangerThreshold = value;
        }
      }
      public Real ProximityThreshold {
        get {
          return this._proximityThreshold;
        }
        set {
          this._proximityThreshold = value;
        }
      }
      public RealBounds MinmaxForcedCowerTimeBounds {
        get {
          return this._minmaxForcedCowerTimeBounds;
        }
        set {
          this._minmaxForcedCowerTimeBounds = value;
        }
      }
      public RealBounds MinmaxCowerTimeoutBounds {
        get {
          return this._minmaxCowerTimeoutBounds;
        }
        set {
          this._minmaxCowerTimeoutBounds = value;
        }
      }
      public Real ProximityAmbushThreshold {
        get {
          return this._proximityAmbushThreshold;
        }
        set {
          this._proximityAmbushThreshold = value;
        }
      }
      public Real AwarenessAmbushThreshold {
        get {
          return this._awarenessAmbushThreshold;
        }
        set {
          this._awarenessAmbushThreshold = value;
        }
      }
      public Real LeaderDeadRetreatChance {
        get {
          return this._leaderDeadRetreatChance;
        }
        set {
          this._leaderDeadRetreatChance = value;
        }
      }
      public Real PeerDeadRetreatChance {
        get {
          return this._peerDeadRetreatChance;
        }
        set {
          this._peerDeadRetreatChance = value;
        }
      }
      public Real SecondPeerDeadRetreatChance {
        get {
          return this._secondPeerDeadRetreatChance;
        }
        set {
          this._secondPeerDeadRetreatChance = value;
        }
      }
      public Angle Zig_MinuszagAngle {
        get {
          return this._zig_MinuszagAngle;
        }
        set {
          this._zig_MinuszagAngle = value;
        }
      }
      public Real Zig_MinuszagPeriod {
        get {
          return this._zig_MinuszagPeriod;
        }
        set {
          this._zig_MinuszagPeriod = value;
        }
      }
      public Real RetreatGrenadeChance {
        get {
          return this._retreatGrenadeChance;
        }
        set {
          this._retreatGrenadeChance = value;
        }
      }
      public TagReference BackupWeapon {
        get {
          return this._backupWeapon;
        }
        set {
          this._backupWeapon = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _retreatFlags.Read(reader);
        _shieldThreshold.Read(reader);
        _scaryTargetThreshold.Read(reader);
        _dangerThreshold.Read(reader);
        _proximityThreshold.Read(reader);
        _minmaxForcedCowerTimeBounds.Read(reader);
        _minmaxCowerTimeoutBounds.Read(reader);
        _proximityAmbushThreshold.Read(reader);
        _awarenessAmbushThreshold.Read(reader);
        _leaderDeadRetreatChance.Read(reader);
        _peerDeadRetreatChance.Read(reader);
        _secondPeerDeadRetreatChance.Read(reader);
        _zig_MinuszagAngle.Read(reader);
        _zig_MinuszagPeriod.Read(reader);
        _retreatGrenadeChance.Read(reader);
        _backupWeapon.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _backupWeapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _retreatFlags.Write(bw);
        _shieldThreshold.Write(bw);
        _scaryTargetThreshold.Write(bw);
        _dangerThreshold.Write(bw);
        _proximityThreshold.Write(bw);
        _minmaxForcedCowerTimeBounds.Write(bw);
        _minmaxCowerTimeoutBounds.Write(bw);
        _proximityAmbushThreshold.Write(bw);
        _awarenessAmbushThreshold.Write(bw);
        _leaderDeadRetreatChance.Write(bw);
        _peerDeadRetreatChance.Write(bw);
        _secondPeerDeadRetreatChance.Write(bw);
        _zig_MinuszagAngle.Write(bw);
        _zig_MinuszagPeriod.Write(bw);
        _retreatGrenadeChance.Write(bw);
        _backupWeapon.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _backupWeapon.WriteString(writer);
      }
    }
    public class CharacterSearchBlockBlock : IBlock {
      private Flags _searchFlags;
      private RealBounds _searchTime = new RealBounds();
      private RealBounds _uncoverDistanceBounds = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public CharacterSearchBlockBlock() {
        this._searchFlags = new Flags(4);
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
      public Flags SearchFlags {
        get {
          return this._searchFlags;
        }
        set {
          this._searchFlags = value;
        }
      }
      public RealBounds SearchTime {
        get {
          return this._searchTime;
        }
        set {
          this._searchTime = value;
        }
      }
      public RealBounds UncoverDistanceBounds {
        get {
          return this._uncoverDistanceBounds;
        }
        set {
          this._uncoverDistanceBounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _searchFlags.Read(reader);
        _searchTime.Read(reader);
        _uncoverDistanceBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _searchFlags.Write(bw);
        _searchTime.Write(bw);
        _uncoverDistanceBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterPresearchBlockBlock : IBlock {
      private Flags _pre_MinussearchFlags;
      private RealBounds _minPresearchTime = new RealBounds();
      private RealBounds _maxPresearchTime = new RealBounds();
      private Real _minCertaintyRadius = new Real();
      private Real _dEPRECATED = new Real();
      private RealBounds _minSuppressingTime = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public CharacterPresearchBlockBlock() {
        this._pre_MinussearchFlags = new Flags(4);
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
      public Flags Pre_MinussearchFlags {
        get {
          return this._pre_MinussearchFlags;
        }
        set {
          this._pre_MinussearchFlags = value;
        }
      }
      public RealBounds MinPresearchTime {
        get {
          return this._minPresearchTime;
        }
        set {
          this._minPresearchTime = value;
        }
      }
      public RealBounds MaxPresearchTime {
        get {
          return this._maxPresearchTime;
        }
        set {
          this._maxPresearchTime = value;
        }
      }
      public Real MinCertaintyRadius {
        get {
          return this._minCertaintyRadius;
        }
        set {
          this._minCertaintyRadius = value;
        }
      }
      public Real DEPRECATED {
        get {
          return this._dEPRECATED;
        }
        set {
          this._dEPRECATED = value;
        }
      }
      public RealBounds MinSuppressingTime {
        get {
          return this._minSuppressingTime;
        }
        set {
          this._minSuppressingTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pre_MinussearchFlags.Read(reader);
        _minPresearchTime.Read(reader);
        _maxPresearchTime.Read(reader);
        _minCertaintyRadius.Read(reader);
        _dEPRECATED.Read(reader);
        _minSuppressingTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _pre_MinussearchFlags.Write(bw);
        _minPresearchTime.Write(bw);
        _maxPresearchTime.Write(bw);
        _minCertaintyRadius.Write(bw);
        _dEPRECATED.Write(bw);
        _minSuppressingTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterIdleBlockBlock : IBlock {
      private Pad _unnamed0;
      private RealBounds _idlePoseDelayTime = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public CharacterIdleBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public RealBounds IdlePoseDelayTime {
        get {
          return this._idlePoseDelayTime;
        }
        set {
          this._idlePoseDelayTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _idlePoseDelayTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _idlePoseDelayTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterVocalizationBlockBlock : IBlock {
      private Real _lookCommentTime = new Real();
      private Real _lookLongCommentTime = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterVocalizationBlockBlock() {
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
      public Real LookCommentTime {
        get {
          return this._lookCommentTime;
        }
        set {
          this._lookCommentTime = value;
        }
      }
      public Real LookLongCommentTime {
        get {
          return this._lookLongCommentTime;
        }
        set {
          this._lookLongCommentTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _lookCommentTime.Read(reader);
        _lookLongCommentTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _lookCommentTime.Write(bw);
        _lookLongCommentTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterBoardingBlockBlock : IBlock {
      private Flags _flags;
      private Real _maxDistance = new Real();
      private Real _abortDistance = new Real();
      private Real _maxSpeed = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterBoardingBlockBlock() {
        this._flags = new Flags(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real MaxDistance {
        get {
          return this._maxDistance;
        }
        set {
          this._maxDistance = value;
        }
      }
      public Real AbortDistance {
        get {
          return this._abortDistance;
        }
        set {
          this._abortDistance = value;
        }
      }
      public Real MaxSpeed {
        get {
          return this._maxSpeed;
        }
        set {
          this._maxSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _maxDistance.Read(reader);
        _abortDistance.Read(reader);
        _maxSpeed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _maxDistance.Write(bw);
        _abortDistance.Write(bw);
        _maxSpeed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterBossBlockBlock : IBlock {
      private Pad _unnamed0;
      private Real _flurryDamageThreshold = new Real();
      private Real _flurryTime = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterBossBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public Real FlurryDamageThreshold {
        get {
          return this._flurryDamageThreshold;
        }
        set {
          this._flurryDamageThreshold = value;
        }
      }
      public Real FlurryTime {
        get {
          return this._flurryTime;
        }
        set {
          this._flurryTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _flurryDamageThreshold.Read(reader);
        _flurryTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _flurryDamageThreshold.Write(bw);
        _flurryTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterWeaponsBlockBlock : IBlock {
      private Flags _weaponsFlags;
      private TagReference _weapon = new TagReference();
      private Real _maximumFiringRange = new Real();
      private Real _minimumFiringRange = new Real();
      private RealBounds _normalCombatRange = new RealBounds();
      private Real _bombardmentRange = new Real();
      private Real _maxSpecialTargetDistance = new Real();
      private RealBounds _timidCombatRange = new RealBounds();
      private RealBounds _aggressiveCombatRange = new RealBounds();
      private Real _super_MinusballisticRange = new Real();
      private RealBounds _ballisticFiringBounds = new RealBounds();
      private RealBounds _ballisticFractionBounds = new RealBounds();
      private RealBounds _firstBurstDelayTime = new RealBounds();
      private Real _surpriseDelayTime = new Real();
      private Real _surpriseFire_MinuswildlyTime = new Real();
      private Real _deathFire_MinuswildlyChance = new Real();
      private Real _deathFire_MinuswildlyTime = new Real();
      private RealVector3D _customStandGunOffset = new RealVector3D();
      private RealVector3D _customCrouchGunOffset = new RealVector3D();
      private Enum _special_MinusfireMode;
      private Enum _special_MinusfireSituation;
      private Real _special_MinusfireChance = new Real();
      private Real _special_MinusfireDelay = new Real();
      private Real _specialDamageModifier = new Real();
      private Angle _specialProjectileError = new Angle();
      private RealBounds _dropWeaponLoaded = new RealBounds();
      private ShortIntegerBounds _dropWeaponAmmo = new ShortIntegerBounds();
      private RealBounds _normalAccuracyBounds = new RealBounds();
      private Real _normalAccuracyTime = new Real();
      private RealBounds _heroicAccuracyBounds = new RealBounds();
      private Real _heroicAccuracyTime = new Real();
      private RealBounds _legendaryAccuracyBounds = new RealBounds();
      private Real _legendaryAccuracyTime = new Real();
      private Block _firingPatterns = new Block();
      private TagReference _weaponMeleeDamage = new TagReference();
      public BlockCollection<CharacterFiringPatternBlockBlock> _firingPatternsList = new BlockCollection<CharacterFiringPatternBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CharacterWeaponsBlockBlock() {
if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
  (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._weaponsFlags = new Flags(4);
        this._special_MinusfireMode = new Enum(2);
        this._special_MinusfireSituation = new Enum(2);
      }
      public BlockCollection<CharacterFiringPatternBlockBlock> FiringPatterns {
        get {
          return this._firingPatternsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weapon.Value);
references.Add(_weaponMeleeDamage.Value);
for (int x=0; x<FiringPatterns.BlockCount; x++)
{
  IBlock block = FiringPatterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _weapon.ToString();
        }
      }
      public Flags WeaponsFlags {
        get {
          return this._weaponsFlags;
        }
        set {
          this._weaponsFlags = value;
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
      public Real MaximumFiringRange {
        get {
          return this._maximumFiringRange;
        }
        set {
          this._maximumFiringRange = value;
        }
      }
      public Real MinimumFiringRange {
        get {
          return this._minimumFiringRange;
        }
        set {
          this._minimumFiringRange = value;
        }
      }
      public RealBounds NormalCombatRange {
        get {
          return this._normalCombatRange;
        }
        set {
          this._normalCombatRange = value;
        }
      }
      public Real BombardmentRange {
        get {
          return this._bombardmentRange;
        }
        set {
          this._bombardmentRange = value;
        }
      }
      public Real MaxSpecialTargetDistance {
        get {
          return this._maxSpecialTargetDistance;
        }
        set {
          this._maxSpecialTargetDistance = value;
        }
      }
      public RealBounds TimidCombatRange {
        get {
          return this._timidCombatRange;
        }
        set {
          this._timidCombatRange = value;
        }
      }
      public RealBounds AggressiveCombatRange {
        get {
          return this._aggressiveCombatRange;
        }
        set {
          this._aggressiveCombatRange = value;
        }
      }
      public Real Super_MinusballisticRange {
        get {
          return this._super_MinusballisticRange;
        }
        set {
          this._super_MinusballisticRange = value;
        }
      }
      public RealBounds BallisticFiringBounds {
        get {
          return this._ballisticFiringBounds;
        }
        set {
          this._ballisticFiringBounds = value;
        }
      }
      public RealBounds BallisticFractionBounds {
        get {
          return this._ballisticFractionBounds;
        }
        set {
          this._ballisticFractionBounds = value;
        }
      }
      public RealBounds FirstBurstDelayTime {
        get {
          return this._firstBurstDelayTime;
        }
        set {
          this._firstBurstDelayTime = value;
        }
      }
      public Real SurpriseDelayTime {
        get {
          return this._surpriseDelayTime;
        }
        set {
          this._surpriseDelayTime = value;
        }
      }
      public Real SurpriseFire_MinuswildlyTime {
        get {
          return this._surpriseFire_MinuswildlyTime;
        }
        set {
          this._surpriseFire_MinuswildlyTime = value;
        }
      }
      public Real DeathFire_MinuswildlyChance {
        get {
          return this._deathFire_MinuswildlyChance;
        }
        set {
          this._deathFire_MinuswildlyChance = value;
        }
      }
      public Real DeathFire_MinuswildlyTime {
        get {
          return this._deathFire_MinuswildlyTime;
        }
        set {
          this._deathFire_MinuswildlyTime = value;
        }
      }
      public RealVector3D CustomStandGunOffset {
        get {
          return this._customStandGunOffset;
        }
        set {
          this._customStandGunOffset = value;
        }
      }
      public RealVector3D CustomCrouchGunOffset {
        get {
          return this._customCrouchGunOffset;
        }
        set {
          this._customCrouchGunOffset = value;
        }
      }
      public Enum Special_MinusfireMode {
        get {
          return this._special_MinusfireMode;
        }
        set {
          this._special_MinusfireMode = value;
        }
      }
      public Enum Special_MinusfireSituation {
        get {
          return this._special_MinusfireSituation;
        }
        set {
          this._special_MinusfireSituation = value;
        }
      }
      public Real Special_MinusfireChance {
        get {
          return this._special_MinusfireChance;
        }
        set {
          this._special_MinusfireChance = value;
        }
      }
      public Real Special_MinusfireDelay {
        get {
          return this._special_MinusfireDelay;
        }
        set {
          this._special_MinusfireDelay = value;
        }
      }
      public Real SpecialDamageModifier {
        get {
          return this._specialDamageModifier;
        }
        set {
          this._specialDamageModifier = value;
        }
      }
      public Angle SpecialProjectileError {
        get {
          return this._specialProjectileError;
        }
        set {
          this._specialProjectileError = value;
        }
      }
      public RealBounds DropWeaponLoaded {
        get {
          return this._dropWeaponLoaded;
        }
        set {
          this._dropWeaponLoaded = value;
        }
      }
      public ShortIntegerBounds DropWeaponAmmo {
        get {
          return this._dropWeaponAmmo;
        }
        set {
          this._dropWeaponAmmo = value;
        }
      }
      public RealBounds NormalAccuracyBounds {
        get {
          return this._normalAccuracyBounds;
        }
        set {
          this._normalAccuracyBounds = value;
        }
      }
      public Real NormalAccuracyTime {
        get {
          return this._normalAccuracyTime;
        }
        set {
          this._normalAccuracyTime = value;
        }
      }
      public RealBounds HeroicAccuracyBounds {
        get {
          return this._heroicAccuracyBounds;
        }
        set {
          this._heroicAccuracyBounds = value;
        }
      }
      public Real HeroicAccuracyTime {
        get {
          return this._heroicAccuracyTime;
        }
        set {
          this._heroicAccuracyTime = value;
        }
      }
      public RealBounds LegendaryAccuracyBounds {
        get {
          return this._legendaryAccuracyBounds;
        }
        set {
          this._legendaryAccuracyBounds = value;
        }
      }
      public Real LegendaryAccuracyTime {
        get {
          return this._legendaryAccuracyTime;
        }
        set {
          this._legendaryAccuracyTime = value;
        }
      }
      public TagReference WeaponMeleeDamage {
        get {
          return this._weaponMeleeDamage;
        }
        set {
          this._weaponMeleeDamage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weaponsFlags.Read(reader);
        _weapon.Read(reader);
        _maximumFiringRange.Read(reader);
        _minimumFiringRange.Read(reader);
        _normalCombatRange.Read(reader);
        _bombardmentRange.Read(reader);
        _maxSpecialTargetDistance.Read(reader);
        _timidCombatRange.Read(reader);
        _aggressiveCombatRange.Read(reader);
        _super_MinusballisticRange.Read(reader);
        _ballisticFiringBounds.Read(reader);
        _ballisticFractionBounds.Read(reader);
        _firstBurstDelayTime.Read(reader);
        _surpriseDelayTime.Read(reader);
        _surpriseFire_MinuswildlyTime.Read(reader);
        _deathFire_MinuswildlyChance.Read(reader);
        _deathFire_MinuswildlyTime.Read(reader);
        _customStandGunOffset.Read(reader);
        _customCrouchGunOffset.Read(reader);
        _special_MinusfireMode.Read(reader);
        _special_MinusfireSituation.Read(reader);
        _special_MinusfireChance.Read(reader);
        _special_MinusfireDelay.Read(reader);
        _specialDamageModifier.Read(reader);
        _specialProjectileError.Read(reader);
        _dropWeaponLoaded.Read(reader);
        _dropWeaponAmmo.Read(reader);
        _normalAccuracyBounds.Read(reader);
        _normalAccuracyTime.Read(reader);
        _heroicAccuracyBounds.Read(reader);
        _heroicAccuracyTime.Read(reader);
        _legendaryAccuracyBounds.Read(reader);
        _legendaryAccuracyTime.Read(reader);
        _firingPatterns.Read(reader);
        _weaponMeleeDamage.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _weapon.ReadString(reader);
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns.Add(new CharacterFiringPatternBlockBlock());
          FiringPatterns[x].Read(reader);
        }
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].ReadChildData(reader);
        }
        _weaponMeleeDamage.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weaponsFlags.Write(bw);
        _weapon.Write(bw);
        _maximumFiringRange.Write(bw);
        _minimumFiringRange.Write(bw);
        _normalCombatRange.Write(bw);
        _bombardmentRange.Write(bw);
        _maxSpecialTargetDistance.Write(bw);
        _timidCombatRange.Write(bw);
        _aggressiveCombatRange.Write(bw);
        _super_MinusballisticRange.Write(bw);
        _ballisticFiringBounds.Write(bw);
        _ballisticFractionBounds.Write(bw);
        _firstBurstDelayTime.Write(bw);
        _surpriseDelayTime.Write(bw);
        _surpriseFire_MinuswildlyTime.Write(bw);
        _deathFire_MinuswildlyChance.Write(bw);
        _deathFire_MinuswildlyTime.Write(bw);
        _customStandGunOffset.Write(bw);
        _customCrouchGunOffset.Write(bw);
        _special_MinusfireMode.Write(bw);
        _special_MinusfireSituation.Write(bw);
        _special_MinusfireChance.Write(bw);
        _special_MinusfireDelay.Write(bw);
        _specialDamageModifier.Write(bw);
        _specialProjectileError.Write(bw);
        _dropWeaponLoaded.Write(bw);
        _dropWeaponAmmo.Write(bw);
        _normalAccuracyBounds.Write(bw);
        _normalAccuracyTime.Write(bw);
        _heroicAccuracyBounds.Write(bw);
        _heroicAccuracyTime.Write(bw);
        _legendaryAccuracyBounds.Write(bw);
        _legendaryAccuracyTime.Write(bw);
_firingPatterns.Count = FiringPatterns.Count;
        _firingPatterns.Write(bw);
        _weaponMeleeDamage.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _weapon.WriteString(writer);
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].Write(writer);
        }
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].WriteChildData(writer);
        }
        _weaponMeleeDamage.WriteString(writer);
      }
    }
    public class CharacterFiringPatternBlockBlock : IBlock {
      private Real _rateOfFire = new Real();
      private Real _targetTracking = new Real();
      private Real _targetLeading = new Real();
      private Real _burstOriginRadius = new Real();
      private Angle _burstOriginAngle = new Angle();
      private RealBounds _burstReturnLength = new RealBounds();
      private Angle _burstReturnAngle = new Angle();
      private RealBounds _burstDuration = new RealBounds();
      private RealBounds _burstSeparation = new RealBounds();
      private Real _weaponDamageModifier = new Real();
      private Angle _projectileError = new Angle();
      private Angle _burstAngularVelocity = new Angle();
      private Angle _maximumErrorAngle = new Angle();
public event System.EventHandler BlockNameChanged;
      public CharacterFiringPatternBlockBlock() {
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
      public Real RateOfFire {
        get {
          return this._rateOfFire;
        }
        set {
          this._rateOfFire = value;
        }
      }
      public Real TargetTracking {
        get {
          return this._targetTracking;
        }
        set {
          this._targetTracking = value;
        }
      }
      public Real TargetLeading {
        get {
          return this._targetLeading;
        }
        set {
          this._targetLeading = value;
        }
      }
      public Real BurstOriginRadius {
        get {
          return this._burstOriginRadius;
        }
        set {
          this._burstOriginRadius = value;
        }
      }
      public Angle BurstOriginAngle {
        get {
          return this._burstOriginAngle;
        }
        set {
          this._burstOriginAngle = value;
        }
      }
      public RealBounds BurstReturnLength {
        get {
          return this._burstReturnLength;
        }
        set {
          this._burstReturnLength = value;
        }
      }
      public Angle BurstReturnAngle {
        get {
          return this._burstReturnAngle;
        }
        set {
          this._burstReturnAngle = value;
        }
      }
      public RealBounds BurstDuration {
        get {
          return this._burstDuration;
        }
        set {
          this._burstDuration = value;
        }
      }
      public RealBounds BurstSeparation {
        get {
          return this._burstSeparation;
        }
        set {
          this._burstSeparation = value;
        }
      }
      public Real WeaponDamageModifier {
        get {
          return this._weaponDamageModifier;
        }
        set {
          this._weaponDamageModifier = value;
        }
      }
      public Angle ProjectileError {
        get {
          return this._projectileError;
        }
        set {
          this._projectileError = value;
        }
      }
      public Angle BurstAngularVelocity {
        get {
          return this._burstAngularVelocity;
        }
        set {
          this._burstAngularVelocity = value;
        }
      }
      public Angle MaximumErrorAngle {
        get {
          return this._maximumErrorAngle;
        }
        set {
          this._maximumErrorAngle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _rateOfFire.Read(reader);
        _targetTracking.Read(reader);
        _targetLeading.Read(reader);
        _burstOriginRadius.Read(reader);
        _burstOriginAngle.Read(reader);
        _burstReturnLength.Read(reader);
        _burstReturnAngle.Read(reader);
        _burstDuration.Read(reader);
        _burstSeparation.Read(reader);
        _weaponDamageModifier.Read(reader);
        _projectileError.Read(reader);
        _burstAngularVelocity.Read(reader);
        _maximumErrorAngle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _rateOfFire.Write(bw);
        _targetTracking.Write(bw);
        _targetLeading.Write(bw);
        _burstOriginRadius.Write(bw);
        _burstOriginAngle.Write(bw);
        _burstReturnLength.Write(bw);
        _burstReturnAngle.Write(bw);
        _burstDuration.Write(bw);
        _burstSeparation.Write(bw);
        _weaponDamageModifier.Write(bw);
        _projectileError.Write(bw);
        _burstAngularVelocity.Write(bw);
        _maximumErrorAngle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterFiringPatternPropertiesBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
      private Block _firingPatterns = new Block();
      public BlockCollection<CharacterFiringPatternBlockBlock> _firingPatternsList = new BlockCollection<CharacterFiringPatternBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CharacterFiringPatternPropertiesBlockBlock() {
if (this._weapon is System.ComponentModel.INotifyPropertyChanged)
  (this._weapon as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<CharacterFiringPatternBlockBlock> FiringPatterns {
        get {
          return this._firingPatternsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weapon.Value);
for (int x=0; x<FiringPatterns.BlockCount; x++)
{
  IBlock block = FiringPatterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
        _firingPatterns.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _weapon.ReadString(reader);
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns.Add(new CharacterFiringPatternBlockBlock());
          FiringPatterns[x].Read(reader);
        }
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _weapon.Write(bw);
_firingPatterns.Count = FiringPatterns.Count;
        _firingPatterns.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _weapon.WriteString(writer);
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].Write(writer);
        }
        for (x = 0; (x < _firingPatterns.Count); x = (x + 1)) {
          FiringPatterns[x].WriteChildData(writer);
        }
      }
    }
    public class CharacterGrenadesBlockBlock : IBlock {
      private Flags _grenadesFlags;
      private Enum _grenadeType;
      private Enum _trajectoryType;
      private Pad _unnamed0;
      private ShortInteger _minimumEnemyCount = new ShortInteger();
      private Real _enemyRadius = new Real();
      private Real _grenadeIdealVelocity = new Real();
      private Real _grenadeVelocity = new Real();
      private RealBounds _grenadeRanges = new RealBounds();
      private Real _collateralDamageRadius = new Real();
      private RealFraction _grenadeChance = new RealFraction();
      private Real _grenadeThrowDelay = new Real();
      private RealFraction _grenadeUncoverChance = new RealFraction();
      private RealFraction _anti_MinusvehicleGrenadeChance = new RealFraction();
      private ShortIntegerBounds _grenadeCount = new ShortIntegerBounds();
      private Real _dontDropGrenadesChance = new Real();
public event System.EventHandler BlockNameChanged;
      public CharacterGrenadesBlockBlock() {
if (this._grenadeType is System.ComponentModel.INotifyPropertyChanged)
  (this._grenadeType as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._grenadesFlags = new Flags(4);
        this._grenadeType = new Enum(2);
        this._trajectoryType = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _grenadeType.ToString();
        }
      }
      public Flags GrenadesFlags {
        get {
          return this._grenadesFlags;
        }
        set {
          this._grenadesFlags = value;
        }
      }
      public Enum GrenadeType {
        get {
          return this._grenadeType;
        }
        set {
          this._grenadeType = value;
        }
      }
      public Enum TrajectoryType {
        get {
          return this._trajectoryType;
        }
        set {
          this._trajectoryType = value;
        }
      }
      public ShortInteger MinimumEnemyCount {
        get {
          return this._minimumEnemyCount;
        }
        set {
          this._minimumEnemyCount = value;
        }
      }
      public Real EnemyRadius {
        get {
          return this._enemyRadius;
        }
        set {
          this._enemyRadius = value;
        }
      }
      public Real GrenadeIdealVelocity {
        get {
          return this._grenadeIdealVelocity;
        }
        set {
          this._grenadeIdealVelocity = value;
        }
      }
      public Real GrenadeVelocity {
        get {
          return this._grenadeVelocity;
        }
        set {
          this._grenadeVelocity = value;
        }
      }
      public RealBounds GrenadeRanges {
        get {
          return this._grenadeRanges;
        }
        set {
          this._grenadeRanges = value;
        }
      }
      public Real CollateralDamageRadius {
        get {
          return this._collateralDamageRadius;
        }
        set {
          this._collateralDamageRadius = value;
        }
      }
      public RealFraction GrenadeChance {
        get {
          return this._grenadeChance;
        }
        set {
          this._grenadeChance = value;
        }
      }
      public Real GrenadeThrowDelay {
        get {
          return this._grenadeThrowDelay;
        }
        set {
          this._grenadeThrowDelay = value;
        }
      }
      public RealFraction GrenadeUncoverChance {
        get {
          return this._grenadeUncoverChance;
        }
        set {
          this._grenadeUncoverChance = value;
        }
      }
      public RealFraction Anti_MinusvehicleGrenadeChance {
        get {
          return this._anti_MinusvehicleGrenadeChance;
        }
        set {
          this._anti_MinusvehicleGrenadeChance = value;
        }
      }
      public ShortIntegerBounds GrenadeCount {
        get {
          return this._grenadeCount;
        }
        set {
          this._grenadeCount = value;
        }
      }
      public Real DontDropGrenadesChance {
        get {
          return this._dontDropGrenadesChance;
        }
        set {
          this._dontDropGrenadesChance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _grenadesFlags.Read(reader);
        _grenadeType.Read(reader);
        _trajectoryType.Read(reader);
        _unnamed0.Read(reader);
        _minimumEnemyCount.Read(reader);
        _enemyRadius.Read(reader);
        _grenadeIdealVelocity.Read(reader);
        _grenadeVelocity.Read(reader);
        _grenadeRanges.Read(reader);
        _collateralDamageRadius.Read(reader);
        _grenadeChance.Read(reader);
        _grenadeThrowDelay.Read(reader);
        _grenadeUncoverChance.Read(reader);
        _anti_MinusvehicleGrenadeChance.Read(reader);
        _grenadeCount.Read(reader);
        _dontDropGrenadesChance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _grenadesFlags.Write(bw);
        _grenadeType.Write(bw);
        _trajectoryType.Write(bw);
        _unnamed0.Write(bw);
        _minimumEnemyCount.Write(bw);
        _enemyRadius.Write(bw);
        _grenadeIdealVelocity.Write(bw);
        _grenadeVelocity.Write(bw);
        _grenadeRanges.Write(bw);
        _collateralDamageRadius.Write(bw);
        _grenadeChance.Write(bw);
        _grenadeThrowDelay.Write(bw);
        _grenadeUncoverChance.Write(bw);
        _anti_MinusvehicleGrenadeChance.Write(bw);
        _grenadeCount.Write(bw);
        _dontDropGrenadesChance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterVehicleBlockBlock : IBlock {
      private TagReference _unit = new TagReference();
      private TagReference _style = new TagReference();
      private Flags _vehicleFlags;
      private Real _aiPathfindingRadius = new Real();
      private Real _aiDestinationRadius = new Real();
      private Real _aiDecelerationDistanceworldUnits = new Real();
      private Real _aiTurningRadius = new Real();
      private Real _aiInnerTurningRadiusTr = new Real();
      private Real _aiIdealTurningRadiusTr = new Real();
      private Angle _aiBansheeSteeringMaximum = new Angle();
      private Real _aiMaxSteeringAngle = new Real();
      private Real _aiMaxSteeringDelta = new Real();
      private Real _aiOversteeringScale = new Real();
      private AngleBounds _aiOversteeringBounds = new AngleBounds();
      private Real _aiSideslipDistance = new Real();
      private Real _aiAvoidanceDistance = new Real();
      private Real _aiMinUrgency = new Real();
      private Real _aiThrottleMaximum = new Real();
      private Real _aiGoalMinThrottleScale = new Real();
      private Real _aiTurnMinThrottleScale = new Real();
      private Real _aiDirectionMinThrottleScale = new Real();
      private Real _aiAccelerationScale = new Real();
      private Real _aiThrottleBlend = new Real();
      private Real _theoreticalMaxSpeed = new Real();
      private Real _errorScale = new Real();
      private Angle _aiAllowableAimDeviationAngle = new Angle();
      private Real _aiChargeTightAngleDistance = new Real();
      private Real _aiChargeTightAngle = new Real();
      private Real _aiChargeRepeatTimeout = new Real();
      private Real _aiChargeLook_MinusaheadTime = new Real();
      private Real _aiChargeConsiderDistance = new Real();
      private Real _aiChargeAbortDistance = new Real();
      private Real _vehicleRamTimeout = new Real();
      private Real _ramParalysisTime = new Real();
      private Real _aiCoverDamageThreshold = new Real();
      private Real _aiCoverMinDistance = new Real();
      private Real _aiCoverTime = new Real();
      private Real _aiCoverMinBoostDistance = new Real();
      private Real _turtlingRecentDamageThreshold = new Real();
      private Real _turtlingMinTime = new Real();
      private Real _turtlingTimeout = new Real();
      private Enum _obstacleIgnoreSize;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public CharacterVehicleBlockBlock() {
if (this._style is System.ComponentModel.INotifyPropertyChanged)
  (this._style as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._vehicleFlags = new Flags(4);
        this._obstacleIgnoreSize = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unit.Value);
references.Add(_style.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _style.ToString();
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
      public TagReference Style {
        get {
          return this._style;
        }
        set {
          this._style = value;
        }
      }
      public Flags VehicleFlags {
        get {
          return this._vehicleFlags;
        }
        set {
          this._vehicleFlags = value;
        }
      }
      public Real AiPathfindingRadius {
        get {
          return this._aiPathfindingRadius;
        }
        set {
          this._aiPathfindingRadius = value;
        }
      }
      public Real AiDestinationRadius {
        get {
          return this._aiDestinationRadius;
        }
        set {
          this._aiDestinationRadius = value;
        }
      }
      public Real AiDecelerationDistanceworldUnits {
        get {
          return this._aiDecelerationDistanceworldUnits;
        }
        set {
          this._aiDecelerationDistanceworldUnits = value;
        }
      }
      public Real AiTurningRadius {
        get {
          return this._aiTurningRadius;
        }
        set {
          this._aiTurningRadius = value;
        }
      }
      public Real AiInnerTurningRadiusTr {
        get {
          return this._aiInnerTurningRadiusTr;
        }
        set {
          this._aiInnerTurningRadiusTr = value;
        }
      }
      public Real AiIdealTurningRadiusTr {
        get {
          return this._aiIdealTurningRadiusTr;
        }
        set {
          this._aiIdealTurningRadiusTr = value;
        }
      }
      public Angle AiBansheeSteeringMaximum {
        get {
          return this._aiBansheeSteeringMaximum;
        }
        set {
          this._aiBansheeSteeringMaximum = value;
        }
      }
      public Real AiMaxSteeringAngle {
        get {
          return this._aiMaxSteeringAngle;
        }
        set {
          this._aiMaxSteeringAngle = value;
        }
      }
      public Real AiMaxSteeringDelta {
        get {
          return this._aiMaxSteeringDelta;
        }
        set {
          this._aiMaxSteeringDelta = value;
        }
      }
      public Real AiOversteeringScale {
        get {
          return this._aiOversteeringScale;
        }
        set {
          this._aiOversteeringScale = value;
        }
      }
      public AngleBounds AiOversteeringBounds {
        get {
          return this._aiOversteeringBounds;
        }
        set {
          this._aiOversteeringBounds = value;
        }
      }
      public Real AiSideslipDistance {
        get {
          return this._aiSideslipDistance;
        }
        set {
          this._aiSideslipDistance = value;
        }
      }
      public Real AiAvoidanceDistance {
        get {
          return this._aiAvoidanceDistance;
        }
        set {
          this._aiAvoidanceDistance = value;
        }
      }
      public Real AiMinUrgency {
        get {
          return this._aiMinUrgency;
        }
        set {
          this._aiMinUrgency = value;
        }
      }
      public Real AiThrottleMaximum {
        get {
          return this._aiThrottleMaximum;
        }
        set {
          this._aiThrottleMaximum = value;
        }
      }
      public Real AiGoalMinThrottleScale {
        get {
          return this._aiGoalMinThrottleScale;
        }
        set {
          this._aiGoalMinThrottleScale = value;
        }
      }
      public Real AiTurnMinThrottleScale {
        get {
          return this._aiTurnMinThrottleScale;
        }
        set {
          this._aiTurnMinThrottleScale = value;
        }
      }
      public Real AiDirectionMinThrottleScale {
        get {
          return this._aiDirectionMinThrottleScale;
        }
        set {
          this._aiDirectionMinThrottleScale = value;
        }
      }
      public Real AiAccelerationScale {
        get {
          return this._aiAccelerationScale;
        }
        set {
          this._aiAccelerationScale = value;
        }
      }
      public Real AiThrottleBlend {
        get {
          return this._aiThrottleBlend;
        }
        set {
          this._aiThrottleBlend = value;
        }
      }
      public Real TheoreticalMaxSpeed {
        get {
          return this._theoreticalMaxSpeed;
        }
        set {
          this._theoreticalMaxSpeed = value;
        }
      }
      public Real ErrorScale {
        get {
          return this._errorScale;
        }
        set {
          this._errorScale = value;
        }
      }
      public Angle AiAllowableAimDeviationAngle {
        get {
          return this._aiAllowableAimDeviationAngle;
        }
        set {
          this._aiAllowableAimDeviationAngle = value;
        }
      }
      public Real AiChargeTightAngleDistance {
        get {
          return this._aiChargeTightAngleDistance;
        }
        set {
          this._aiChargeTightAngleDistance = value;
        }
      }
      public Real AiChargeTightAngle {
        get {
          return this._aiChargeTightAngle;
        }
        set {
          this._aiChargeTightAngle = value;
        }
      }
      public Real AiChargeRepeatTimeout {
        get {
          return this._aiChargeRepeatTimeout;
        }
        set {
          this._aiChargeRepeatTimeout = value;
        }
      }
      public Real AiChargeLook_MinusaheadTime {
        get {
          return this._aiChargeLook_MinusaheadTime;
        }
        set {
          this._aiChargeLook_MinusaheadTime = value;
        }
      }
      public Real AiChargeConsiderDistance {
        get {
          return this._aiChargeConsiderDistance;
        }
        set {
          this._aiChargeConsiderDistance = value;
        }
      }
      public Real AiChargeAbortDistance {
        get {
          return this._aiChargeAbortDistance;
        }
        set {
          this._aiChargeAbortDistance = value;
        }
      }
      public Real VehicleRamTimeout {
        get {
          return this._vehicleRamTimeout;
        }
        set {
          this._vehicleRamTimeout = value;
        }
      }
      public Real RamParalysisTime {
        get {
          return this._ramParalysisTime;
        }
        set {
          this._ramParalysisTime = value;
        }
      }
      public Real AiCoverDamageThreshold {
        get {
          return this._aiCoverDamageThreshold;
        }
        set {
          this._aiCoverDamageThreshold = value;
        }
      }
      public Real AiCoverMinDistance {
        get {
          return this._aiCoverMinDistance;
        }
        set {
          this._aiCoverMinDistance = value;
        }
      }
      public Real AiCoverTime {
        get {
          return this._aiCoverTime;
        }
        set {
          this._aiCoverTime = value;
        }
      }
      public Real AiCoverMinBoostDistance {
        get {
          return this._aiCoverMinBoostDistance;
        }
        set {
          this._aiCoverMinBoostDistance = value;
        }
      }
      public Real TurtlingRecentDamageThreshold {
        get {
          return this._turtlingRecentDamageThreshold;
        }
        set {
          this._turtlingRecentDamageThreshold = value;
        }
      }
      public Real TurtlingMinTime {
        get {
          return this._turtlingMinTime;
        }
        set {
          this._turtlingMinTime = value;
        }
      }
      public Real TurtlingTimeout {
        get {
          return this._turtlingTimeout;
        }
        set {
          this._turtlingTimeout = value;
        }
      }
      public Enum ObstacleIgnoreSize {
        get {
          return this._obstacleIgnoreSize;
        }
        set {
          this._obstacleIgnoreSize = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unit.Read(reader);
        _style.Read(reader);
        _vehicleFlags.Read(reader);
        _aiPathfindingRadius.Read(reader);
        _aiDestinationRadius.Read(reader);
        _aiDecelerationDistanceworldUnits.Read(reader);
        _aiTurningRadius.Read(reader);
        _aiInnerTurningRadiusTr.Read(reader);
        _aiIdealTurningRadiusTr.Read(reader);
        _aiBansheeSteeringMaximum.Read(reader);
        _aiMaxSteeringAngle.Read(reader);
        _aiMaxSteeringDelta.Read(reader);
        _aiOversteeringScale.Read(reader);
        _aiOversteeringBounds.Read(reader);
        _aiSideslipDistance.Read(reader);
        _aiAvoidanceDistance.Read(reader);
        _aiMinUrgency.Read(reader);
        _aiThrottleMaximum.Read(reader);
        _aiGoalMinThrottleScale.Read(reader);
        _aiTurnMinThrottleScale.Read(reader);
        _aiDirectionMinThrottleScale.Read(reader);
        _aiAccelerationScale.Read(reader);
        _aiThrottleBlend.Read(reader);
        _theoreticalMaxSpeed.Read(reader);
        _errorScale.Read(reader);
        _aiAllowableAimDeviationAngle.Read(reader);
        _aiChargeTightAngleDistance.Read(reader);
        _aiChargeTightAngle.Read(reader);
        _aiChargeRepeatTimeout.Read(reader);
        _aiChargeLook_MinusaheadTime.Read(reader);
        _aiChargeConsiderDistance.Read(reader);
        _aiChargeAbortDistance.Read(reader);
        _vehicleRamTimeout.Read(reader);
        _ramParalysisTime.Read(reader);
        _aiCoverDamageThreshold.Read(reader);
        _aiCoverMinDistance.Read(reader);
        _aiCoverTime.Read(reader);
        _aiCoverMinBoostDistance.Read(reader);
        _turtlingRecentDamageThreshold.Read(reader);
        _turtlingMinTime.Read(reader);
        _turtlingTimeout.Read(reader);
        _obstacleIgnoreSize.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unit.ReadString(reader);
        _style.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unit.Write(bw);
        _style.Write(bw);
        _vehicleFlags.Write(bw);
        _aiPathfindingRadius.Write(bw);
        _aiDestinationRadius.Write(bw);
        _aiDecelerationDistanceworldUnits.Write(bw);
        _aiTurningRadius.Write(bw);
        _aiInnerTurningRadiusTr.Write(bw);
        _aiIdealTurningRadiusTr.Write(bw);
        _aiBansheeSteeringMaximum.Write(bw);
        _aiMaxSteeringAngle.Write(bw);
        _aiMaxSteeringDelta.Write(bw);
        _aiOversteeringScale.Write(bw);
        _aiOversteeringBounds.Write(bw);
        _aiSideslipDistance.Write(bw);
        _aiAvoidanceDistance.Write(bw);
        _aiMinUrgency.Write(bw);
        _aiThrottleMaximum.Write(bw);
        _aiGoalMinThrottleScale.Write(bw);
        _aiTurnMinThrottleScale.Write(bw);
        _aiDirectionMinThrottleScale.Write(bw);
        _aiAccelerationScale.Write(bw);
        _aiThrottleBlend.Write(bw);
        _theoreticalMaxSpeed.Write(bw);
        _errorScale.Write(bw);
        _aiAllowableAimDeviationAngle.Write(bw);
        _aiChargeTightAngleDistance.Write(bw);
        _aiChargeTightAngle.Write(bw);
        _aiChargeRepeatTimeout.Write(bw);
        _aiChargeLook_MinusaheadTime.Write(bw);
        _aiChargeConsiderDistance.Write(bw);
        _aiChargeAbortDistance.Write(bw);
        _vehicleRamTimeout.Write(bw);
        _ramParalysisTime.Write(bw);
        _aiCoverDamageThreshold.Write(bw);
        _aiCoverMinDistance.Write(bw);
        _aiCoverTime.Write(bw);
        _aiCoverMinBoostDistance.Write(bw);
        _turtlingRecentDamageThreshold.Write(bw);
        _turtlingMinTime.Write(bw);
        _turtlingTimeout.Write(bw);
        _obstacleIgnoreSize.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unit.WriteString(writer);
        _style.WriteString(writer);
      }
    }
  }
}
