// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'globals'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class globals : Interfaces.Pool.Tag {
    private GlobalsBlockBlock globalsValues = new GlobalsBlockBlock();
    public virtual GlobalsBlockBlock GlobalsValues {
      get {
        return globalsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(GlobalsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "globals";
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
globalsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
globalsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
globalsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
globalsValues.WriteChildData(writer);
    }
    #endregion
    public class GlobalsBlockBlock : IBlock {
      private Pad _unnamed0;
      private Enum _language;
      private Block _havokCleanupResources = new Block();
      private Block _collisionDamage = new Block();
      private Block _soundGlobals = new Block();
      private Block _aiGlobals = new Block();
      private Block _damageTable = new Block();
      private Block _unnamed1 = new Block();
      private Block _sounds = new Block();
      private Block _camera = new Block();
      private Block _playerControl = new Block();
      private Block _difficulty = new Block();
      private Block _grenades = new Block();
      private Block _rasterizerData = new Block();
      private Block _interfaceTags = new Block();
      private Block _weaponListUpdateweaponlistEnumInGameglobalsh = new Block();
      private Block _cheatPowerups = new Block();
      private Block _multiplayerInformation = new Block();
      private Block _playerInformation = new Block();
      private Block _playerRepresentation = new Block();
      private Block _fallingDamage = new Block();
      private Block _oldMaterials = new Block();
      private Block _materials = new Block();
      private Block _multiplayerUI = new Block();
      private Block _profileColors = new Block();
      private TagReference _multiplayerGlobals = new TagReference();
      private Block _runtimeLevelData = new Block();
      private Block _uiLevelData = new Block();
      private TagReference _defaultGlobalLighting = new TagReference();
      private Pad _unnamed2;
      public BlockCollection<HavokCleanupResourcesBlockBlock> _havokCleanupResourcesList = new BlockCollection<HavokCleanupResourcesBlockBlock>();
      public BlockCollection<CollisionDamageBlockBlock> _collisionDamageList = new BlockCollection<CollisionDamageBlockBlock>();
      public BlockCollection<SoundGlobalsBlockBlock> _soundGlobalsList = new BlockCollection<SoundGlobalsBlockBlock>();
      public BlockCollection<AiGlobalsBlockBlock> _aiGlobalsList = new BlockCollection<AiGlobalsBlockBlock>();
      public BlockCollection<GameGlobalsDamageBlockBlock> _damageTableList = new BlockCollection<GameGlobalsDamageBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed1List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<SoundBlockBlock> _soundsList = new BlockCollection<SoundBlockBlock>();
      public BlockCollection<CameraBlockBlock> _cameraList = new BlockCollection<CameraBlockBlock>();
      public BlockCollection<PlayerControlBlockBlock> _playerControlList = new BlockCollection<PlayerControlBlockBlock>();
      public BlockCollection<DifficultyBlockBlock> _difficultyList = new BlockCollection<DifficultyBlockBlock>();
      public BlockCollection<GrenadesBlockBlock> _grenadesList = new BlockCollection<GrenadesBlockBlock>();
      public BlockCollection<RasterizerDataBlockBlock> _rasterizerDataList = new BlockCollection<RasterizerDataBlockBlock>();
      public BlockCollection<InterfaceTagReferencesBlock> _interfaceTagsList = new BlockCollection<InterfaceTagReferencesBlock>();
      public BlockCollection<CheatWeaponsBlockBlock> _weaponListUpdateweaponlistEnumInGameglobalshList = new BlockCollection<CheatWeaponsBlockBlock>();
      public BlockCollection<CheatPowerupsBlockBlock> _cheatPowerupsList = new BlockCollection<CheatPowerupsBlockBlock>();
      public BlockCollection<MultiplayerInformationBlockBlock> _multiplayerInformationList = new BlockCollection<MultiplayerInformationBlockBlock>();
      public BlockCollection<PlayerInformationBlockBlock> _playerInformationList = new BlockCollection<PlayerInformationBlockBlock>();
      public BlockCollection<PlayerRepresentationBlockBlock> _playerRepresentationList = new BlockCollection<PlayerRepresentationBlockBlock>();
      public BlockCollection<FallingDamageBlockBlock> _fallingDamageList = new BlockCollection<FallingDamageBlockBlock>();
      public BlockCollection<OldMaterialsBlockBlock> _oldMaterialsList = new BlockCollection<OldMaterialsBlockBlock>();
      public BlockCollection<MaterialsBlockBlock> _materialsList = new BlockCollection<MaterialsBlockBlock>();
      public BlockCollection<MultiplayerUiBlockBlock> _multiplayerUIList = new BlockCollection<MultiplayerUiBlockBlock>();
      public BlockCollection<MultiplayerColorBlockBlock> _profileColorsList = new BlockCollection<MultiplayerColorBlockBlock>();
      public BlockCollection<RuntimeLevelsDefinitionBlockBlock> _runtimeLevelDataList = new BlockCollection<RuntimeLevelsDefinitionBlockBlock>();
      public BlockCollection<UiLevelsDefinitionBlockBlock> _uiLevelDataList = new BlockCollection<UiLevelsDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalsBlockBlock() {
        this._unnamed0 = new Pad(172);
        this._language = new Enum(4);
        this._unnamed2 = new Pad(252);
      }
      public BlockCollection<HavokCleanupResourcesBlockBlock> HavokCleanupResources {
        get {
          return this._havokCleanupResourcesList;
        }
      }
      public BlockCollection<CollisionDamageBlockBlock> CollisionDamage {
        get {
          return this._collisionDamageList;
        }
      }
      public BlockCollection<SoundGlobalsBlockBlock> SoundGlobals {
        get {
          return this._soundGlobalsList;
        }
      }
      public BlockCollection<AiGlobalsBlockBlock> AiGlobals {
        get {
          return this._aiGlobalsList;
        }
      }
      public BlockCollection<GameGlobalsDamageBlockBlock> DamageTable {
        get {
          return this._damageTableList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public BlockCollection<SoundBlockBlock> Sounds {
        get {
          return this._soundsList;
        }
      }
      public BlockCollection<CameraBlockBlock> Camera {
        get {
          return this._cameraList;
        }
      }
      public BlockCollection<PlayerControlBlockBlock> PlayerControl {
        get {
          return this._playerControlList;
        }
      }
      public BlockCollection<DifficultyBlockBlock> Difficulty {
        get {
          return this._difficultyList;
        }
      }
      public BlockCollection<GrenadesBlockBlock> Grenades {
        get {
          return this._grenadesList;
        }
      }
      public BlockCollection<RasterizerDataBlockBlock> RasterizerData {
        get {
          return this._rasterizerDataList;
        }
      }
      public BlockCollection<InterfaceTagReferencesBlock> InterfaceTags {
        get {
          return this._interfaceTagsList;
        }
      }
      public BlockCollection<CheatWeaponsBlockBlock> WeaponListUpdateweaponlistEnumInGameglobalsh {
        get {
          return this._weaponListUpdateweaponlistEnumInGameglobalshList;
        }
      }
      public BlockCollection<CheatPowerupsBlockBlock> CheatPowerups {
        get {
          return this._cheatPowerupsList;
        }
      }
      public BlockCollection<MultiplayerInformationBlockBlock> MultiplayerInformation {
        get {
          return this._multiplayerInformationList;
        }
      }
      public BlockCollection<PlayerInformationBlockBlock> PlayerInformation {
        get {
          return this._playerInformationList;
        }
      }
      public BlockCollection<PlayerRepresentationBlockBlock> PlayerRepresentation {
        get {
          return this._playerRepresentationList;
        }
      }
      public BlockCollection<FallingDamageBlockBlock> FallingDamage {
        get {
          return this._fallingDamageList;
        }
      }
      public BlockCollection<OldMaterialsBlockBlock> OldMaterials {
        get {
          return this._oldMaterialsList;
        }
      }
      public BlockCollection<MaterialsBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<MultiplayerUiBlockBlock> MultiplayerUI {
        get {
          return this._multiplayerUIList;
        }
      }
      public BlockCollection<MultiplayerColorBlockBlock> ProfileColors {
        get {
          return this._profileColorsList;
        }
      }
      public BlockCollection<RuntimeLevelsDefinitionBlockBlock> RuntimeLevelData {
        get {
          return this._runtimeLevelDataList;
        }
      }
      public BlockCollection<UiLevelsDefinitionBlockBlock> UiLevelData {
        get {
          return this._uiLevelDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_multiplayerGlobals.Value);
references.Add(_defaultGlobalLighting.Value);
for (int x=0; x<HavokCleanupResources.BlockCount; x++)
{
  IBlock block = HavokCleanupResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CollisionDamage.BlockCount; x++)
{
  IBlock block = CollisionDamage.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundGlobals.BlockCount; x++)
{
  IBlock block = SoundGlobals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiGlobals.BlockCount; x++)
{
  IBlock block = AiGlobals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DamageTable.BlockCount; x++)
{
  IBlock block = DamageTable.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sounds.BlockCount; x++)
{
  IBlock block = Sounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Camera.BlockCount; x++)
{
  IBlock block = Camera.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerControl.BlockCount; x++)
{
  IBlock block = PlayerControl.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Difficulty.BlockCount; x++)
{
  IBlock block = Difficulty.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Grenades.BlockCount; x++)
{
  IBlock block = Grenades.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RasterizerData.BlockCount; x++)
{
  IBlock block = RasterizerData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InterfaceTags.BlockCount; x++)
{
  IBlock block = InterfaceTags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponListUpdateweaponlistEnumInGameglobalsh.BlockCount; x++)
{
  IBlock block = WeaponListUpdateweaponlistEnumInGameglobalsh.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CheatPowerups.BlockCount; x++)
{
  IBlock block = CheatPowerups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultiplayerInformation.BlockCount; x++)
{
  IBlock block = MultiplayerInformation.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerInformation.BlockCount; x++)
{
  IBlock block = PlayerInformation.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerRepresentation.BlockCount; x++)
{
  IBlock block = PlayerRepresentation.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FallingDamage.BlockCount; x++)
{
  IBlock block = FallingDamage.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OldMaterials.BlockCount; x++)
{
  IBlock block = OldMaterials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultiplayerUI.BlockCount; x++)
{
  IBlock block = MultiplayerUI.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ProfileColors.BlockCount; x++)
{
  IBlock block = ProfileColors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RuntimeLevelData.BlockCount; x++)
{
  IBlock block = RuntimeLevelData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<UiLevelData.BlockCount; x++)
{
  IBlock block = UiLevelData.GetBlock(x);
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
      public Enum Language {
        get {
          return this._language;
        }
        set {
          this._language = value;
        }
      }
      public TagReference MultiplayerGlobals {
        get {
          return this._multiplayerGlobals;
        }
        set {
          this._multiplayerGlobals = value;
        }
      }
      public TagReference DefaultGlobalLighting {
        get {
          return this._defaultGlobalLighting;
        }
        set {
          this._defaultGlobalLighting = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _language.Read(reader);
        _havokCleanupResources.Read(reader);
        _collisionDamage.Read(reader);
        _soundGlobals.Read(reader);
        _aiGlobals.Read(reader);
        _damageTable.Read(reader);
        _unnamed1.Read(reader);
        _sounds.Read(reader);
        _camera.Read(reader);
        _playerControl.Read(reader);
        _difficulty.Read(reader);
        _grenades.Read(reader);
        _rasterizerData.Read(reader);
        _interfaceTags.Read(reader);
        _weaponListUpdateweaponlistEnumInGameglobalsh.Read(reader);
        _cheatPowerups.Read(reader);
        _multiplayerInformation.Read(reader);
        _playerInformation.Read(reader);
        _playerRepresentation.Read(reader);
        _fallingDamage.Read(reader);
        _oldMaterials.Read(reader);
        _materials.Read(reader);
        _multiplayerUI.Read(reader);
        _profileColors.Read(reader);
        _multiplayerGlobals.Read(reader);
        _runtimeLevelData.Read(reader);
        _uiLevelData.Read(reader);
        _defaultGlobalLighting.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _havokCleanupResources.Count); x = (x + 1)) {
          HavokCleanupResources.Add(new HavokCleanupResourcesBlockBlock());
          HavokCleanupResources[x].Read(reader);
        }
        for (x = 0; (x < _havokCleanupResources.Count); x = (x + 1)) {
          HavokCleanupResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _collisionDamage.Count); x = (x + 1)) {
          CollisionDamage.Add(new CollisionDamageBlockBlock());
          CollisionDamage[x].Read(reader);
        }
        for (x = 0; (x < _collisionDamage.Count); x = (x + 1)) {
          CollisionDamage[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundGlobals.Count); x = (x + 1)) {
          SoundGlobals.Add(new SoundGlobalsBlockBlock());
          SoundGlobals[x].Read(reader);
        }
        for (x = 0; (x < _soundGlobals.Count); x = (x + 1)) {
          SoundGlobals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiGlobals.Count); x = (x + 1)) {
          AiGlobals.Add(new AiGlobalsBlockBlock());
          AiGlobals[x].Read(reader);
        }
        for (x = 0; (x < _aiGlobals.Count); x = (x + 1)) {
          AiGlobals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _damageTable.Count); x = (x + 1)) {
          DamageTable.Add(new GameGlobalsDamageBlockBlock());
          DamageTable[x].Read(reader);
        }
        for (x = 0; (x < _damageTable.Count); x = (x + 1)) {
          DamageTable[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new GNullBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new SoundBlockBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera.Add(new CameraBlockBlock());
          Camera[x].Read(reader);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl.Add(new PlayerControlBlockBlock());
          PlayerControl[x].Read(reader);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl[x].ReadChildData(reader);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty.Add(new DifficultyBlockBlock());
          Difficulty[x].Read(reader);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty[x].ReadChildData(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades.Add(new GrenadesBlockBlock());
          Grenades[x].Read(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData.Add(new RasterizerDataBlockBlock());
          RasterizerData[x].Read(reader);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _interfaceTags.Count); x = (x + 1)) {
          InterfaceTags.Add(new InterfaceTagReferencesBlock());
          InterfaceTags[x].Read(reader);
        }
        for (x = 0; (x < _interfaceTags.Count); x = (x + 1)) {
          InterfaceTags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobalsh.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobalsh.Add(new CheatWeaponsBlockBlock());
          WeaponListUpdateweaponlistEnumInGameglobalsh[x].Read(reader);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobalsh.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobalsh[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups.Add(new CheatPowerupsBlockBlock());
          CheatPowerups[x].Read(reader);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation.Add(new MultiplayerInformationBlockBlock());
          MultiplayerInformation[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation.Add(new PlayerInformationBlockBlock());
          PlayerInformation[x].Read(reader);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerRepresentation.Count); x = (x + 1)) {
          PlayerRepresentation.Add(new PlayerRepresentationBlockBlock());
          PlayerRepresentation[x].Read(reader);
        }
        for (x = 0; (x < _playerRepresentation.Count); x = (x + 1)) {
          PlayerRepresentation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage.Add(new FallingDamageBlockBlock());
          FallingDamage[x].Read(reader);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].ReadChildData(reader);
        }
        for (x = 0; (x < _oldMaterials.Count); x = (x + 1)) {
          OldMaterials.Add(new OldMaterialsBlockBlock());
          OldMaterials[x].Read(reader);
        }
        for (x = 0; (x < _oldMaterials.Count); x = (x + 1)) {
          OldMaterials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new MaterialsBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiplayerUI.Count); x = (x + 1)) {
          MultiplayerUI.Add(new MultiplayerUiBlockBlock());
          MultiplayerUI[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerUI.Count); x = (x + 1)) {
          MultiplayerUI[x].ReadChildData(reader);
        }
        for (x = 0; (x < _profileColors.Count); x = (x + 1)) {
          ProfileColors.Add(new MultiplayerColorBlockBlock());
          ProfileColors[x].Read(reader);
        }
        for (x = 0; (x < _profileColors.Count); x = (x + 1)) {
          ProfileColors[x].ReadChildData(reader);
        }
        _multiplayerGlobals.ReadString(reader);
        for (x = 0; (x < _runtimeLevelData.Count); x = (x + 1)) {
          RuntimeLevelData.Add(new RuntimeLevelsDefinitionBlockBlock());
          RuntimeLevelData[x].Read(reader);
        }
        for (x = 0; (x < _runtimeLevelData.Count); x = (x + 1)) {
          RuntimeLevelData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _uiLevelData.Count); x = (x + 1)) {
          UiLevelData.Add(new UiLevelsDefinitionBlockBlock());
          UiLevelData[x].Read(reader);
        }
        for (x = 0; (x < _uiLevelData.Count); x = (x + 1)) {
          UiLevelData[x].ReadChildData(reader);
        }
        _defaultGlobalLighting.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _language.Write(bw);
_havokCleanupResources.Count = HavokCleanupResources.Count;
        _havokCleanupResources.Write(bw);
_collisionDamage.Count = CollisionDamage.Count;
        _collisionDamage.Write(bw);
_soundGlobals.Count = SoundGlobals.Count;
        _soundGlobals.Write(bw);
_aiGlobals.Count = AiGlobals.Count;
        _aiGlobals.Write(bw);
_damageTable.Count = DamageTable.Count;
        _damageTable.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
_sounds.Count = Sounds.Count;
        _sounds.Write(bw);
_camera.Count = Camera.Count;
        _camera.Write(bw);
_playerControl.Count = PlayerControl.Count;
        _playerControl.Write(bw);
_difficulty.Count = Difficulty.Count;
        _difficulty.Write(bw);
_grenades.Count = Grenades.Count;
        _grenades.Write(bw);
_rasterizerData.Count = RasterizerData.Count;
        _rasterizerData.Write(bw);
_interfaceTags.Count = InterfaceTags.Count;
        _interfaceTags.Write(bw);
_weaponListUpdateweaponlistEnumInGameglobalsh.Count = WeaponListUpdateweaponlistEnumInGameglobalsh.Count;
        _weaponListUpdateweaponlistEnumInGameglobalsh.Write(bw);
_cheatPowerups.Count = CheatPowerups.Count;
        _cheatPowerups.Write(bw);
_multiplayerInformation.Count = MultiplayerInformation.Count;
        _multiplayerInformation.Write(bw);
_playerInformation.Count = PlayerInformation.Count;
        _playerInformation.Write(bw);
_playerRepresentation.Count = PlayerRepresentation.Count;
        _playerRepresentation.Write(bw);
_fallingDamage.Count = FallingDamage.Count;
        _fallingDamage.Write(bw);
_oldMaterials.Count = OldMaterials.Count;
        _oldMaterials.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_multiplayerUI.Count = MultiplayerUI.Count;
        _multiplayerUI.Write(bw);
_profileColors.Count = ProfileColors.Count;
        _profileColors.Write(bw);
        _multiplayerGlobals.Write(bw);
_runtimeLevelData.Count = RuntimeLevelData.Count;
        _runtimeLevelData.Write(bw);
_uiLevelData.Count = UiLevelData.Count;
        _uiLevelData.Write(bw);
        _defaultGlobalLighting.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _havokCleanupResources.Count); x = (x + 1)) {
          HavokCleanupResources[x].Write(writer);
        }
        for (x = 0; (x < _havokCleanupResources.Count); x = (x + 1)) {
          HavokCleanupResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _collisionDamage.Count); x = (x + 1)) {
          CollisionDamage[x].Write(writer);
        }
        for (x = 0; (x < _collisionDamage.Count); x = (x + 1)) {
          CollisionDamage[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundGlobals.Count); x = (x + 1)) {
          SoundGlobals[x].Write(writer);
        }
        for (x = 0; (x < _soundGlobals.Count); x = (x + 1)) {
          SoundGlobals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiGlobals.Count); x = (x + 1)) {
          AiGlobals[x].Write(writer);
        }
        for (x = 0; (x < _aiGlobals.Count); x = (x + 1)) {
          AiGlobals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _damageTable.Count); x = (x + 1)) {
          DamageTable[x].Write(writer);
        }
        for (x = 0; (x < _damageTable.Count); x = (x + 1)) {
          DamageTable[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].Write(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera[x].Write(writer);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl[x].Write(writer);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl[x].WriteChildData(writer);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty[x].Write(writer);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty[x].WriteChildData(writer);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].Write(writer);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData[x].Write(writer);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _interfaceTags.Count); x = (x + 1)) {
          InterfaceTags[x].Write(writer);
        }
        for (x = 0; (x < _interfaceTags.Count); x = (x + 1)) {
          InterfaceTags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobalsh.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobalsh[x].Write(writer);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobalsh.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobalsh[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups[x].Write(writer);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation[x].Write(writer);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation[x].Write(writer);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerRepresentation.Count); x = (x + 1)) {
          PlayerRepresentation[x].Write(writer);
        }
        for (x = 0; (x < _playerRepresentation.Count); x = (x + 1)) {
          PlayerRepresentation[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].Write(writer);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].WriteChildData(writer);
        }
        for (x = 0; (x < _oldMaterials.Count); x = (x + 1)) {
          OldMaterials[x].Write(writer);
        }
        for (x = 0; (x < _oldMaterials.Count); x = (x + 1)) {
          OldMaterials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _multiplayerUI.Count); x = (x + 1)) {
          MultiplayerUI[x].Write(writer);
        }
        for (x = 0; (x < _multiplayerUI.Count); x = (x + 1)) {
          MultiplayerUI[x].WriteChildData(writer);
        }
        for (x = 0; (x < _profileColors.Count); x = (x + 1)) {
          ProfileColors[x].Write(writer);
        }
        for (x = 0; (x < _profileColors.Count); x = (x + 1)) {
          ProfileColors[x].WriteChildData(writer);
        }
        _multiplayerGlobals.WriteString(writer);
        for (x = 0; (x < _runtimeLevelData.Count); x = (x + 1)) {
          RuntimeLevelData[x].Write(writer);
        }
        for (x = 0; (x < _runtimeLevelData.Count); x = (x + 1)) {
          RuntimeLevelData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _uiLevelData.Count); x = (x + 1)) {
          UiLevelData[x].Write(writer);
        }
        for (x = 0; (x < _uiLevelData.Count); x = (x + 1)) {
          UiLevelData[x].WriteChildData(writer);
        }
        _defaultGlobalLighting.WriteString(writer);
      }
    }
    public class HavokCleanupResourcesBlockBlock : IBlock {
      private TagReference _objectCleanupEffect = new TagReference();
public event System.EventHandler BlockNameChanged;
      public HavokCleanupResourcesBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_objectCleanupEffect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference ObjectCleanupEffect {
        get {
          return this._objectCleanupEffect;
        }
        set {
          this._objectCleanupEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _objectCleanupEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _objectCleanupEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _objectCleanupEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _objectCleanupEffect.WriteString(writer);
      }
    }
    public class CollisionDamageBlockBlock : IBlock {
      private TagReference _collisionDamage = new TagReference();
      private Real _minGameAccDefault = new Real();
      private Real _maxGameAccDefault = new Real();
      private Real _minGameScaleDefault = new Real();
      private Real _maxGameScaleDefault = new Real();
      private Real _minAbsAccDefault = new Real();
      private Real _maxAbsAccDefault = new Real();
      private Real _minAbsScaleDefault = new Real();
      private Real _maxAbsScaleDefault = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public CollisionDamageBlockBlock() {
        this._unnamed0 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_collisionDamage.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference CollisionDamage {
        get {
          return this._collisionDamage;
        }
        set {
          this._collisionDamage = value;
        }
      }
      public Real MinGameAccDefault {
        get {
          return this._minGameAccDefault;
        }
        set {
          this._minGameAccDefault = value;
        }
      }
      public Real MaxGameAccDefault {
        get {
          return this._maxGameAccDefault;
        }
        set {
          this._maxGameAccDefault = value;
        }
      }
      public Real MinGameScaleDefault {
        get {
          return this._minGameScaleDefault;
        }
        set {
          this._minGameScaleDefault = value;
        }
      }
      public Real MaxGameScaleDefault {
        get {
          return this._maxGameScaleDefault;
        }
        set {
          this._maxGameScaleDefault = value;
        }
      }
      public Real MinAbsAccDefault {
        get {
          return this._minAbsAccDefault;
        }
        set {
          this._minAbsAccDefault = value;
        }
      }
      public Real MaxAbsAccDefault {
        get {
          return this._maxAbsAccDefault;
        }
        set {
          this._maxAbsAccDefault = value;
        }
      }
      public Real MinAbsScaleDefault {
        get {
          return this._minAbsScaleDefault;
        }
        set {
          this._minAbsScaleDefault = value;
        }
      }
      public Real MaxAbsScaleDefault {
        get {
          return this._maxAbsScaleDefault;
        }
        set {
          this._maxAbsScaleDefault = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _collisionDamage.Read(reader);
        _minGameAccDefault.Read(reader);
        _maxGameAccDefault.Read(reader);
        _minGameScaleDefault.Read(reader);
        _maxGameScaleDefault.Read(reader);
        _minAbsAccDefault.Read(reader);
        _maxAbsAccDefault.Read(reader);
        _minAbsScaleDefault.Read(reader);
        _maxAbsScaleDefault.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _collisionDamage.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _collisionDamage.Write(bw);
        _minGameAccDefault.Write(bw);
        _maxGameAccDefault.Write(bw);
        _minGameScaleDefault.Write(bw);
        _maxGameScaleDefault.Write(bw);
        _minAbsAccDefault.Write(bw);
        _maxAbsAccDefault.Write(bw);
        _minAbsScaleDefault.Write(bw);
        _maxAbsScaleDefault.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _collisionDamage.WriteString(writer);
      }
    }
    public class SoundGlobalsBlockBlock : IBlock {
      private TagReference _soundClasses = new TagReference();
      private TagReference _soundEffects = new TagReference();
      private TagReference _soundMix = new TagReference();
      private TagReference _soundCombatDialogueConstants = new TagReference();
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SoundGlobalsBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_soundClasses.Value);
references.Add(_soundEffects.Value);
references.Add(_soundMix.Value);
references.Add(_soundCombatDialogueConstants.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference SoundClasses {
        get {
          return this._soundClasses;
        }
        set {
          this._soundClasses = value;
        }
      }
      public TagReference SoundEffects {
        get {
          return this._soundEffects;
        }
        set {
          this._soundEffects = value;
        }
      }
      public TagReference SoundMix {
        get {
          return this._soundMix;
        }
        set {
          this._soundMix = value;
        }
      }
      public TagReference SoundCombatDialogueConstants {
        get {
          return this._soundCombatDialogueConstants;
        }
        set {
          this._soundCombatDialogueConstants = value;
        }
      }
      public LongInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundClasses.Read(reader);
        _soundEffects.Read(reader);
        _soundMix.Read(reader);
        _soundCombatDialogueConstants.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _soundClasses.ReadString(reader);
        _soundEffects.ReadString(reader);
        _soundMix.ReadString(reader);
        _soundCombatDialogueConstants.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _soundClasses.Write(bw);
        _soundEffects.Write(bw);
        _soundMix.Write(bw);
        _soundCombatDialogueConstants.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _soundClasses.WriteString(writer);
        _soundEffects.WriteString(writer);
        _soundMix.WriteString(writer);
        _soundCombatDialogueConstants.WriteString(writer);
      }
    }
    public class AiGlobalsBlockBlock : IBlock {
      private Real _dangerBroadlyFacing = new Real();
      private Pad _unnamed0;
      private Real _dangerShootingNear = new Real();
      private Pad _unnamed1;
      private Real _dangerShootingAt = new Real();
      private Pad _unnamed2;
      private Real _dangerExtremelyClose = new Real();
      private Pad _unnamed3;
      private Real _dangerShieldDamage = new Real();
      private Real _dangerExetendedShieldDamage = new Real();
      private Real _dangerBodyDamage = new Real();
      private Real _dangerExtendedBodyDamage = new Real();
      private Pad _unnamed4;
      private TagReference _globalDialogueTag = new TagReference();
      private StringId _defaultMissionDialogueSoundEffect = new StringId();
      private Pad _unnamed5;
      private Real _jumpDown = new Real();
      private Real _jumpStep = new Real();
      private Real _jumpCrouch = new Real();
      private Real _jumpStand = new Real();
      private Real _jumpStorey = new Real();
      private Real _jumpTower = new Real();
      private Real _maxJumpDownHeightDown = new Real();
      private Real _maxJumpDownHeightStep = new Real();
      private Real _maxJumpDownHeightCrouch = new Real();
      private Real _maxJumpDownHeightStand = new Real();
      private Real _maxJumpDownHeightStorey = new Real();
      private Real _maxJumpDownHeightTower = new Real();
      private RealBounds _hoistStep = new RealBounds();
      private RealBounds _hoistCrouch = new RealBounds();
      private RealBounds _hoistStand = new RealBounds();
      private Pad _unnamed6;
      private RealBounds _vaultStep = new RealBounds();
      private RealBounds _vaultCrouch = new RealBounds();
      private Pad _unnamed7;
      private Block _gravemindProperties = new Block();
      private Pad _unnamed8;
      private Real _scaryTargetThrehold = new Real();
      private Real _scaryWeaponThrehold = new Real();
      private Real _playerScariness = new Real();
      private Real _berserkingActorScariness = new Real();
      public BlockCollection<AiGlobalsGravemindBlockBlock> _gravemindPropertiesList = new BlockCollection<AiGlobalsGravemindBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiGlobalsBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(48);
        this._unnamed5 = new Pad(20);
        this._unnamed6 = new Pad(24);
        this._unnamed7 = new Pad(48);
        this._unnamed8 = new Pad(48);
      }
      public BlockCollection<AiGlobalsGravemindBlockBlock> GravemindProperties {
        get {
          return this._gravemindPropertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_globalDialogueTag.Value);
for (int x=0; x<GravemindProperties.BlockCount; x++)
{
  IBlock block = GravemindProperties.GetBlock(x);
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
      public Real DangerBroadlyFacing {
        get {
          return this._dangerBroadlyFacing;
        }
        set {
          this._dangerBroadlyFacing = value;
        }
      }
      public Real DangerShootingNear {
        get {
          return this._dangerShootingNear;
        }
        set {
          this._dangerShootingNear = value;
        }
      }
      public Real DangerShootingAt {
        get {
          return this._dangerShootingAt;
        }
        set {
          this._dangerShootingAt = value;
        }
      }
      public Real DangerExtremelyClose {
        get {
          return this._dangerExtremelyClose;
        }
        set {
          this._dangerExtremelyClose = value;
        }
      }
      public Real DangerShieldDamage {
        get {
          return this._dangerShieldDamage;
        }
        set {
          this._dangerShieldDamage = value;
        }
      }
      public Real DangerExetendedShieldDamage {
        get {
          return this._dangerExetendedShieldDamage;
        }
        set {
          this._dangerExetendedShieldDamage = value;
        }
      }
      public Real DangerBodyDamage {
        get {
          return this._dangerBodyDamage;
        }
        set {
          this._dangerBodyDamage = value;
        }
      }
      public Real DangerExtendedBodyDamage {
        get {
          return this._dangerExtendedBodyDamage;
        }
        set {
          this._dangerExtendedBodyDamage = value;
        }
      }
      public TagReference GlobalDialogueTag {
        get {
          return this._globalDialogueTag;
        }
        set {
          this._globalDialogueTag = value;
        }
      }
      public StringId DefaultMissionDialogueSoundEffect {
        get {
          return this._defaultMissionDialogueSoundEffect;
        }
        set {
          this._defaultMissionDialogueSoundEffect = value;
        }
      }
      public Real JumpDown {
        get {
          return this._jumpDown;
        }
        set {
          this._jumpDown = value;
        }
      }
      public Real JumpStep {
        get {
          return this._jumpStep;
        }
        set {
          this._jumpStep = value;
        }
      }
      public Real JumpCrouch {
        get {
          return this._jumpCrouch;
        }
        set {
          this._jumpCrouch = value;
        }
      }
      public Real JumpStand {
        get {
          return this._jumpStand;
        }
        set {
          this._jumpStand = value;
        }
      }
      public Real JumpStorey {
        get {
          return this._jumpStorey;
        }
        set {
          this._jumpStorey = value;
        }
      }
      public Real JumpTower {
        get {
          return this._jumpTower;
        }
        set {
          this._jumpTower = value;
        }
      }
      public Real MaxJumpDownHeightDown {
        get {
          return this._maxJumpDownHeightDown;
        }
        set {
          this._maxJumpDownHeightDown = value;
        }
      }
      public Real MaxJumpDownHeightStep {
        get {
          return this._maxJumpDownHeightStep;
        }
        set {
          this._maxJumpDownHeightStep = value;
        }
      }
      public Real MaxJumpDownHeightCrouch {
        get {
          return this._maxJumpDownHeightCrouch;
        }
        set {
          this._maxJumpDownHeightCrouch = value;
        }
      }
      public Real MaxJumpDownHeightStand {
        get {
          return this._maxJumpDownHeightStand;
        }
        set {
          this._maxJumpDownHeightStand = value;
        }
      }
      public Real MaxJumpDownHeightStorey {
        get {
          return this._maxJumpDownHeightStorey;
        }
        set {
          this._maxJumpDownHeightStorey = value;
        }
      }
      public Real MaxJumpDownHeightTower {
        get {
          return this._maxJumpDownHeightTower;
        }
        set {
          this._maxJumpDownHeightTower = value;
        }
      }
      public RealBounds HoistStep {
        get {
          return this._hoistStep;
        }
        set {
          this._hoistStep = value;
        }
      }
      public RealBounds HoistCrouch {
        get {
          return this._hoistCrouch;
        }
        set {
          this._hoistCrouch = value;
        }
      }
      public RealBounds HoistStand {
        get {
          return this._hoistStand;
        }
        set {
          this._hoistStand = value;
        }
      }
      public RealBounds VaultStep {
        get {
          return this._vaultStep;
        }
        set {
          this._vaultStep = value;
        }
      }
      public RealBounds VaultCrouch {
        get {
          return this._vaultCrouch;
        }
        set {
          this._vaultCrouch = value;
        }
      }
      public Real ScaryTargetThrehold {
        get {
          return this._scaryTargetThrehold;
        }
        set {
          this._scaryTargetThrehold = value;
        }
      }
      public Real ScaryWeaponThrehold {
        get {
          return this._scaryWeaponThrehold;
        }
        set {
          this._scaryWeaponThrehold = value;
        }
      }
      public Real PlayerScariness {
        get {
          return this._playerScariness;
        }
        set {
          this._playerScariness = value;
        }
      }
      public Real BerserkingActorScariness {
        get {
          return this._berserkingActorScariness;
        }
        set {
          this._berserkingActorScariness = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dangerBroadlyFacing.Read(reader);
        _unnamed0.Read(reader);
        _dangerShootingNear.Read(reader);
        _unnamed1.Read(reader);
        _dangerShootingAt.Read(reader);
        _unnamed2.Read(reader);
        _dangerExtremelyClose.Read(reader);
        _unnamed3.Read(reader);
        _dangerShieldDamage.Read(reader);
        _dangerExetendedShieldDamage.Read(reader);
        _dangerBodyDamage.Read(reader);
        _dangerExtendedBodyDamage.Read(reader);
        _unnamed4.Read(reader);
        _globalDialogueTag.Read(reader);
        _defaultMissionDialogueSoundEffect.Read(reader);
        _unnamed5.Read(reader);
        _jumpDown.Read(reader);
        _jumpStep.Read(reader);
        _jumpCrouch.Read(reader);
        _jumpStand.Read(reader);
        _jumpStorey.Read(reader);
        _jumpTower.Read(reader);
        _maxJumpDownHeightDown.Read(reader);
        _maxJumpDownHeightStep.Read(reader);
        _maxJumpDownHeightCrouch.Read(reader);
        _maxJumpDownHeightStand.Read(reader);
        _maxJumpDownHeightStorey.Read(reader);
        _maxJumpDownHeightTower.Read(reader);
        _hoistStep.Read(reader);
        _hoistCrouch.Read(reader);
        _hoistStand.Read(reader);
        _unnamed6.Read(reader);
        _vaultStep.Read(reader);
        _vaultCrouch.Read(reader);
        _unnamed7.Read(reader);
        _gravemindProperties.Read(reader);
        _unnamed8.Read(reader);
        _scaryTargetThrehold.Read(reader);
        _scaryWeaponThrehold.Read(reader);
        _playerScariness.Read(reader);
        _berserkingActorScariness.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _globalDialogueTag.ReadString(reader);
        _defaultMissionDialogueSoundEffect.ReadString(reader);
        for (x = 0; (x < _gravemindProperties.Count); x = (x + 1)) {
          GravemindProperties.Add(new AiGlobalsGravemindBlockBlock());
          GravemindProperties[x].Read(reader);
        }
        for (x = 0; (x < _gravemindProperties.Count); x = (x + 1)) {
          GravemindProperties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dangerBroadlyFacing.Write(bw);
        _unnamed0.Write(bw);
        _dangerShootingNear.Write(bw);
        _unnamed1.Write(bw);
        _dangerShootingAt.Write(bw);
        _unnamed2.Write(bw);
        _dangerExtremelyClose.Write(bw);
        _unnamed3.Write(bw);
        _dangerShieldDamage.Write(bw);
        _dangerExetendedShieldDamage.Write(bw);
        _dangerBodyDamage.Write(bw);
        _dangerExtendedBodyDamage.Write(bw);
        _unnamed4.Write(bw);
        _globalDialogueTag.Write(bw);
        _defaultMissionDialogueSoundEffect.Write(bw);
        _unnamed5.Write(bw);
        _jumpDown.Write(bw);
        _jumpStep.Write(bw);
        _jumpCrouch.Write(bw);
        _jumpStand.Write(bw);
        _jumpStorey.Write(bw);
        _jumpTower.Write(bw);
        _maxJumpDownHeightDown.Write(bw);
        _maxJumpDownHeightStep.Write(bw);
        _maxJumpDownHeightCrouch.Write(bw);
        _maxJumpDownHeightStand.Write(bw);
        _maxJumpDownHeightStorey.Write(bw);
        _maxJumpDownHeightTower.Write(bw);
        _hoistStep.Write(bw);
        _hoistCrouch.Write(bw);
        _hoistStand.Write(bw);
        _unnamed6.Write(bw);
        _vaultStep.Write(bw);
        _vaultCrouch.Write(bw);
        _unnamed7.Write(bw);
_gravemindProperties.Count = GravemindProperties.Count;
        _gravemindProperties.Write(bw);
        _unnamed8.Write(bw);
        _scaryTargetThrehold.Write(bw);
        _scaryWeaponThrehold.Write(bw);
        _playerScariness.Write(bw);
        _berserkingActorScariness.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _globalDialogueTag.WriteString(writer);
        _defaultMissionDialogueSoundEffect.WriteString(writer);
        for (x = 0; (x < _gravemindProperties.Count); x = (x + 1)) {
          GravemindProperties[x].Write(writer);
        }
        for (x = 0; (x < _gravemindProperties.Count); x = (x + 1)) {
          GravemindProperties[x].WriteChildData(writer);
        }
      }
    }
    public class AiGlobalsGravemindBlockBlock : IBlock {
      private Real _minRetreatTime = new Real();
      private Real _idealRetreatTime = new Real();
      private Real _maxRetreatTime = new Real();
public event System.EventHandler BlockNameChanged;
      public AiGlobalsGravemindBlockBlock() {
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
      public Real MinRetreatTime {
        get {
          return this._minRetreatTime;
        }
        set {
          this._minRetreatTime = value;
        }
      }
      public Real IdealRetreatTime {
        get {
          return this._idealRetreatTime;
        }
        set {
          this._idealRetreatTime = value;
        }
      }
      public Real MaxRetreatTime {
        get {
          return this._maxRetreatTime;
        }
        set {
          this._maxRetreatTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _minRetreatTime.Read(reader);
        _idealRetreatTime.Read(reader);
        _maxRetreatTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _minRetreatTime.Write(bw);
        _idealRetreatTime.Write(bw);
        _maxRetreatTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GameGlobalsDamageBlockBlock : IBlock {
      private Block _damageGroups = new Block();
      public BlockCollection<DamageGroupBlockBlock> _damageGroupsList = new BlockCollection<DamageGroupBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GameGlobalsDamageBlockBlock() {
      }
      public BlockCollection<DamageGroupBlockBlock> DamageGroups {
        get {
          return this._damageGroupsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<DamageGroups.BlockCount; x++)
{
  IBlock block = DamageGroups.GetBlock(x);
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
        _damageGroups.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _damageGroups.Count); x = (x + 1)) {
          DamageGroups.Add(new DamageGroupBlockBlock());
          DamageGroups[x].Read(reader);
        }
        for (x = 0; (x < _damageGroups.Count); x = (x + 1)) {
          DamageGroups[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_damageGroups.Count = DamageGroups.Count;
        _damageGroups.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _damageGroups.Count); x = (x + 1)) {
          DamageGroups[x].Write(writer);
        }
        for (x = 0; (x < _damageGroups.Count); x = (x + 1)) {
          DamageGroups[x].WriteChildData(writer);
        }
      }
    }
    public class DamageGroupBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _armorModifiers = new Block();
      public BlockCollection<ArmorModifierBlockBlock> _armorModifiersList = new BlockCollection<ArmorModifierBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageGroupBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<ArmorModifierBlockBlock> ArmorModifiers {
        get {
          return this._armorModifiersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ArmorModifiers.BlockCount; x++)
{
  IBlock block = ArmorModifiers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _armorModifiers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _armorModifiers.Count); x = (x + 1)) {
          ArmorModifiers.Add(new ArmorModifierBlockBlock());
          ArmorModifiers[x].Read(reader);
        }
        for (x = 0; (x < _armorModifiers.Count); x = (x + 1)) {
          ArmorModifiers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_armorModifiers.Count = ArmorModifiers.Count;
        _armorModifiers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _armorModifiers.Count); x = (x + 1)) {
          ArmorModifiers[x].Write(writer);
        }
        for (x = 0; (x < _armorModifiers.Count); x = (x + 1)) {
          ArmorModifiers[x].WriteChildData(writer);
        }
      }
    }
    public class ArmorModifierBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Real _damageMultiplier = new Real();
public event System.EventHandler BlockNameChanged;
      public ArmorModifierBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Real DamageMultiplier {
        get {
          return this._damageMultiplier;
        }
        set {
          this._damageMultiplier = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _damageMultiplier.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _damageMultiplier.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
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
    public class SoundBlockBlock : IBlock {
      private TagReference _soundOBSOLETE = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SoundBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_soundOBSOLETE.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference SoundOBSOLETE {
        get {
          return this._soundOBSOLETE;
        }
        set {
          this._soundOBSOLETE = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundOBSOLETE.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _soundOBSOLETE.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _soundOBSOLETE.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _soundOBSOLETE.WriteString(writer);
      }
    }
    public class CameraBlockBlock : IBlock {
      private TagReference _defaultUnitCameraTrack = new TagReference();
      private Real _defaultChangePause = new Real();
      private Real _firstPersonChangePause = new Real();
      private Real _followingCameraChangePause = new Real();
public event System.EventHandler BlockNameChanged;
      public CameraBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_defaultUnitCameraTrack.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference DefaultUnitCameraTrack {
        get {
          return this._defaultUnitCameraTrack;
        }
        set {
          this._defaultUnitCameraTrack = value;
        }
      }
      public Real DefaultChangePause {
        get {
          return this._defaultChangePause;
        }
        set {
          this._defaultChangePause = value;
        }
      }
      public Real FirstPersonChangePause {
        get {
          return this._firstPersonChangePause;
        }
        set {
          this._firstPersonChangePause = value;
        }
      }
      public Real FollowingCameraChangePause {
        get {
          return this._followingCameraChangePause;
        }
        set {
          this._followingCameraChangePause = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _defaultUnitCameraTrack.Read(reader);
        _defaultChangePause.Read(reader);
        _firstPersonChangePause.Read(reader);
        _followingCameraChangePause.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _defaultUnitCameraTrack.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _defaultUnitCameraTrack.Write(bw);
        _defaultChangePause.Write(bw);
        _firstPersonChangePause.Write(bw);
        _followingCameraChangePause.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _defaultUnitCameraTrack.WriteString(writer);
      }
    }
    public class PlayerControlBlockBlock : IBlock {
      private RealFraction _magnetismFriction = new RealFraction();
      private RealFraction _magnetismAdhesion = new RealFraction();
      private RealFraction _inconsequentialTargetScale = new RealFraction();
      private Pad _unnamed0;
      private RealPoint2D _crosshairLocation = new RealPoint2D();
      private Real _secondsToStart = new Real();
      private Real _secondsToFullSpeed = new Real();
      private Real _decayRate = new Real();
      private Real _fullSpeedMultiplier = new Real();
      private Real _peggedMagnitude = new Real();
      private Real _peggedAngularThreshold = new Real();
      private Pad _unnamed1;
      private Real _lookDefaultPitchRate = new Real();
      private Real _lookDefaultYawRate = new Real();
      private RealFraction _lookPegThreshold01 = new RealFraction();
      private Real _lookYawAccelerationTime = new Real();
      private Real _lookYawAccelerationScale = new Real();
      private Real _lookPitchAccelerationTime = new Real();
      private Real _lookPitchAccelerationScale = new Real();
      private Real _lookAutolevellingScale = new Real();
      private Pad _unnamed2;
      private Real _gravityscale = new Real();
      private Pad _unnamed3;
      private ShortInteger _minimumAutolevellingTicks = new ShortInteger();
      private Angle _minimumAngleForVehicleFlipping = new Angle();
      private Block _lookFunction = new Block();
      private Real _minimumActionHoldTime = new Real();
      public BlockCollection<LookFunctionBlockBlock> _lookFunctionList = new BlockCollection<LookFunctionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlayerControlBlockBlock() {
        this._unnamed0 = new Pad(12);
        this._unnamed1 = new Pad(8);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<LookFunctionBlockBlock> LookFunction {
        get {
          return this._lookFunctionList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<LookFunction.BlockCount; x++)
{
  IBlock block = LookFunction.GetBlock(x);
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
      public RealFraction MagnetismFriction {
        get {
          return this._magnetismFriction;
        }
        set {
          this._magnetismFriction = value;
        }
      }
      public RealFraction MagnetismAdhesion {
        get {
          return this._magnetismAdhesion;
        }
        set {
          this._magnetismAdhesion = value;
        }
      }
      public RealFraction InconsequentialTargetScale {
        get {
          return this._inconsequentialTargetScale;
        }
        set {
          this._inconsequentialTargetScale = value;
        }
      }
      public RealPoint2D CrosshairLocation {
        get {
          return this._crosshairLocation;
        }
        set {
          this._crosshairLocation = value;
        }
      }
      public Real SecondsToStart {
        get {
          return this._secondsToStart;
        }
        set {
          this._secondsToStart = value;
        }
      }
      public Real SecondsToFullSpeed {
        get {
          return this._secondsToFullSpeed;
        }
        set {
          this._secondsToFullSpeed = value;
        }
      }
      public Real DecayRate {
        get {
          return this._decayRate;
        }
        set {
          this._decayRate = value;
        }
      }
      public Real FullSpeedMultiplier {
        get {
          return this._fullSpeedMultiplier;
        }
        set {
          this._fullSpeedMultiplier = value;
        }
      }
      public Real PeggedMagnitude {
        get {
          return this._peggedMagnitude;
        }
        set {
          this._peggedMagnitude = value;
        }
      }
      public Real PeggedAngularThreshold {
        get {
          return this._peggedAngularThreshold;
        }
        set {
          this._peggedAngularThreshold = value;
        }
      }
      public Real LookDefaultPitchRate {
        get {
          return this._lookDefaultPitchRate;
        }
        set {
          this._lookDefaultPitchRate = value;
        }
      }
      public Real LookDefaultYawRate {
        get {
          return this._lookDefaultYawRate;
        }
        set {
          this._lookDefaultYawRate = value;
        }
      }
      public RealFraction LookPegThreshold01 {
        get {
          return this._lookPegThreshold01;
        }
        set {
          this._lookPegThreshold01 = value;
        }
      }
      public Real LookYawAccelerationTime {
        get {
          return this._lookYawAccelerationTime;
        }
        set {
          this._lookYawAccelerationTime = value;
        }
      }
      public Real LookYawAccelerationScale {
        get {
          return this._lookYawAccelerationScale;
        }
        set {
          this._lookYawAccelerationScale = value;
        }
      }
      public Real LookPitchAccelerationTime {
        get {
          return this._lookPitchAccelerationTime;
        }
        set {
          this._lookPitchAccelerationTime = value;
        }
      }
      public Real LookPitchAccelerationScale {
        get {
          return this._lookPitchAccelerationScale;
        }
        set {
          this._lookPitchAccelerationScale = value;
        }
      }
      public Real LookAutolevellingScale {
        get {
          return this._lookAutolevellingScale;
        }
        set {
          this._lookAutolevellingScale = value;
        }
      }
      public Real Gravityscale {
        get {
          return this._gravityscale;
        }
        set {
          this._gravityscale = value;
        }
      }
      public ShortInteger MinimumAutolevellingTicks {
        get {
          return this._minimumAutolevellingTicks;
        }
        set {
          this._minimumAutolevellingTicks = value;
        }
      }
      public Angle MinimumAngleForVehicleFlipping {
        get {
          return this._minimumAngleForVehicleFlipping;
        }
        set {
          this._minimumAngleForVehicleFlipping = value;
        }
      }
      public Real MinimumActionHoldTime {
        get {
          return this._minimumActionHoldTime;
        }
        set {
          this._minimumActionHoldTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _magnetismFriction.Read(reader);
        _magnetismAdhesion.Read(reader);
        _inconsequentialTargetScale.Read(reader);
        _unnamed0.Read(reader);
        _crosshairLocation.Read(reader);
        _secondsToStart.Read(reader);
        _secondsToFullSpeed.Read(reader);
        _decayRate.Read(reader);
        _fullSpeedMultiplier.Read(reader);
        _peggedMagnitude.Read(reader);
        _peggedAngularThreshold.Read(reader);
        _unnamed1.Read(reader);
        _lookDefaultPitchRate.Read(reader);
        _lookDefaultYawRate.Read(reader);
        _lookPegThreshold01.Read(reader);
        _lookYawAccelerationTime.Read(reader);
        _lookYawAccelerationScale.Read(reader);
        _lookPitchAccelerationTime.Read(reader);
        _lookPitchAccelerationScale.Read(reader);
        _lookAutolevellingScale.Read(reader);
        _unnamed2.Read(reader);
        _gravityscale.Read(reader);
        _unnamed3.Read(reader);
        _minimumAutolevellingTicks.Read(reader);
        _minimumAngleForVehicleFlipping.Read(reader);
        _lookFunction.Read(reader);
        _minimumActionHoldTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lookFunction.Count); x = (x + 1)) {
          LookFunction.Add(new LookFunctionBlockBlock());
          LookFunction[x].Read(reader);
        }
        for (x = 0; (x < _lookFunction.Count); x = (x + 1)) {
          LookFunction[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _magnetismFriction.Write(bw);
        _magnetismAdhesion.Write(bw);
        _inconsequentialTargetScale.Write(bw);
        _unnamed0.Write(bw);
        _crosshairLocation.Write(bw);
        _secondsToStart.Write(bw);
        _secondsToFullSpeed.Write(bw);
        _decayRate.Write(bw);
        _fullSpeedMultiplier.Write(bw);
        _peggedMagnitude.Write(bw);
        _peggedAngularThreshold.Write(bw);
        _unnamed1.Write(bw);
        _lookDefaultPitchRate.Write(bw);
        _lookDefaultYawRate.Write(bw);
        _lookPegThreshold01.Write(bw);
        _lookYawAccelerationTime.Write(bw);
        _lookYawAccelerationScale.Write(bw);
        _lookPitchAccelerationTime.Write(bw);
        _lookPitchAccelerationScale.Write(bw);
        _lookAutolevellingScale.Write(bw);
        _unnamed2.Write(bw);
        _gravityscale.Write(bw);
        _unnamed3.Write(bw);
        _minimumAutolevellingTicks.Write(bw);
        _minimumAngleForVehicleFlipping.Write(bw);
_lookFunction.Count = LookFunction.Count;
        _lookFunction.Write(bw);
        _minimumActionHoldTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lookFunction.Count); x = (x + 1)) {
          LookFunction[x].Write(writer);
        }
        for (x = 0; (x < _lookFunction.Count); x = (x + 1)) {
          LookFunction[x].WriteChildData(writer);
        }
      }
    }
    public class LookFunctionBlockBlock : IBlock {
      private Real _scale = new Real();
public event System.EventHandler BlockNameChanged;
      public LookFunctionBlockBlock() {
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DifficultyBlockBlock : IBlock {
      private Real _easyEnemyDamage = new Real();
      private Real _normalEnemyDamage = new Real();
      private Real _hardEnemyDamage = new Real();
      private Real _impossEnemyDamage = new Real();
      private Real _easyEnemyVitality = new Real();
      private Real _normalEnemyVitality = new Real();
      private Real _hardEnemyVitality = new Real();
      private Real _impossEnemyVitality = new Real();
      private Real _easyEnemyShield = new Real();
      private Real _normalEnemyShield = new Real();
      private Real _hardEnemyShield = new Real();
      private Real _impossEnemyShield = new Real();
      private Real _easyEnemyRecharge = new Real();
      private Real _normalEnemyRecharge = new Real();
      private Real _hardEnemyRecharge = new Real();
      private Real _impossEnemyRecharge = new Real();
      private Real _easyFriendDamage = new Real();
      private Real _normalFriendDamage = new Real();
      private Real _hardFriendDamage = new Real();
      private Real _impossFriendDamage = new Real();
      private Real _easyFriendVitality = new Real();
      private Real _normalFriendVitality = new Real();
      private Real _hardFriendVitality = new Real();
      private Real _impossFriendVitality = new Real();
      private Real _easyFriendShield = new Real();
      private Real _normalFriendShield = new Real();
      private Real _hardFriendShield = new Real();
      private Real _impossFriendShield = new Real();
      private Real _easyFriendRecharge = new Real();
      private Real _normalFriendRecharge = new Real();
      private Real _hardFriendRecharge = new Real();
      private Real _impossFriendRecharge = new Real();
      private Real _easyInfectionForms = new Real();
      private Real _normalInfectionForms = new Real();
      private Real _hardInfectionForms = new Real();
      private Real _impossInfectionForms = new Real();
      private Pad _unnamed0;
      private Real _easyRateOfFire = new Real();
      private Real _normalRateOfFire = new Real();
      private Real _hardRateOfFire = new Real();
      private Real _impossRateOfFire = new Real();
      private Real _easyProjectileError = new Real();
      private Real _normalProjectileError = new Real();
      private Real _hardProjectileError = new Real();
      private Real _impossProjectileError = new Real();
      private Real _easyBurstError = new Real();
      private Real _normalBurstError = new Real();
      private Real _hardBurstError = new Real();
      private Real _impossBurstError = new Real();
      private Real _easyNewTargetDelay = new Real();
      private Real _normalNewTargetDelay = new Real();
      private Real _hardNewTargetDelay = new Real();
      private Real _impossNewTargetDelay = new Real();
      private Real _easyBurstSeparation = new Real();
      private Real _normalBurstSeparation = new Real();
      private Real _hardBurstSeparation = new Real();
      private Real _impossBurstSeparation = new Real();
      private Real _easyTargetTracking = new Real();
      private Real _normalTargetTracking = new Real();
      private Real _hardTargetTracking = new Real();
      private Real _impossTargetTracking = new Real();
      private Real _easyTargetLeading = new Real();
      private Real _normalTargetLeading = new Real();
      private Real _hardTargetLeading = new Real();
      private Real _impossTargetLeading = new Real();
      private Real _easyOverchargeChance = new Real();
      private Real _normalOverchargeChance = new Real();
      private Real _hardOverchargeChance = new Real();
      private Real _impossOverchargeChance = new Real();
      private Real _easySpecialFireDelay = new Real();
      private Real _normalSpecialFireDelay = new Real();
      private Real _hardSpecialFireDelay = new Real();
      private Real _impossSpecialFireDelay = new Real();
      private Real _easyGuidanceVsPlayer = new Real();
      private Real _normalGuidanceVsPlayer = new Real();
      private Real _hardGuidanceVsPlayer = new Real();
      private Real _impossGuidanceVsPlayer = new Real();
      private Real _easyMeleeDelayBase = new Real();
      private Real _normalMeleeDelayBase = new Real();
      private Real _hardMeleeDelayBase = new Real();
      private Real _impossMeleeDelayBase = new Real();
      private Real _easyMeleeDelayScale = new Real();
      private Real _normalMeleeDelayScale = new Real();
      private Real _hardMeleeDelayScale = new Real();
      private Real _impossMeleeDelayScale = new Real();
      private Pad _unnamed1;
      private Real _easyGrenadeChanceScale = new Real();
      private Real _normalGrenadeChanceScale = new Real();
      private Real _hardGrenadeChanceScale = new Real();
      private Real _impossGrenadeChanceScale = new Real();
      private Real _easyGrenadeTimerScale = new Real();
      private Real _normalGrenadeTimerScale = new Real();
      private Real _hardGrenadeTimerScale = new Real();
      private Real _impossGrenadeTimerScale = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Real _easyMajorUpgradeNormal = new Real();
      private Real _normalMajorUpgradeNormal = new Real();
      private Real _hardMajorUpgradeNormal = new Real();
      private Real _impossMajorUpgradeNormal = new Real();
      private Real _easyMajorUpgradeFew = new Real();
      private Real _normalMajorUpgradeFew = new Real();
      private Real _hardMajorUpgradeFew = new Real();
      private Real _impossMajorUpgradeFew = new Real();
      private Real _easyMajorUpgradeMany = new Real();
      private Real _normalMajorUpgradeMany = new Real();
      private Real _hardMajorUpgradeMany = new Real();
      private Real _impossMajorUpgradeMany = new Real();
      private Real _easyPlayerVehicleRamChance = new Real();
      private Real _normalPlayerVehicleRamChance = new Real();
      private Real _hardPlayerVehicleRamChance = new Real();
      private Real _impossPlayerVehicleRamChance = new Real();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
public event System.EventHandler BlockNameChanged;
      public DifficultyBlockBlock() {
        this._unnamed0 = new Pad(16);
        this._unnamed1 = new Pad(16);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(16);
        this._unnamed7 = new Pad(16);
        this._unnamed8 = new Pad(84);
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
      public Real EasyEnemyDamage {
        get {
          return this._easyEnemyDamage;
        }
        set {
          this._easyEnemyDamage = value;
        }
      }
      public Real NormalEnemyDamage {
        get {
          return this._normalEnemyDamage;
        }
        set {
          this._normalEnemyDamage = value;
        }
      }
      public Real HardEnemyDamage {
        get {
          return this._hardEnemyDamage;
        }
        set {
          this._hardEnemyDamage = value;
        }
      }
      public Real ImpossEnemyDamage {
        get {
          return this._impossEnemyDamage;
        }
        set {
          this._impossEnemyDamage = value;
        }
      }
      public Real EasyEnemyVitality {
        get {
          return this._easyEnemyVitality;
        }
        set {
          this._easyEnemyVitality = value;
        }
      }
      public Real NormalEnemyVitality {
        get {
          return this._normalEnemyVitality;
        }
        set {
          this._normalEnemyVitality = value;
        }
      }
      public Real HardEnemyVitality {
        get {
          return this._hardEnemyVitality;
        }
        set {
          this._hardEnemyVitality = value;
        }
      }
      public Real ImpossEnemyVitality {
        get {
          return this._impossEnemyVitality;
        }
        set {
          this._impossEnemyVitality = value;
        }
      }
      public Real EasyEnemyShield {
        get {
          return this._easyEnemyShield;
        }
        set {
          this._easyEnemyShield = value;
        }
      }
      public Real NormalEnemyShield {
        get {
          return this._normalEnemyShield;
        }
        set {
          this._normalEnemyShield = value;
        }
      }
      public Real HardEnemyShield {
        get {
          return this._hardEnemyShield;
        }
        set {
          this._hardEnemyShield = value;
        }
      }
      public Real ImpossEnemyShield {
        get {
          return this._impossEnemyShield;
        }
        set {
          this._impossEnemyShield = value;
        }
      }
      public Real EasyEnemyRecharge {
        get {
          return this._easyEnemyRecharge;
        }
        set {
          this._easyEnemyRecharge = value;
        }
      }
      public Real NormalEnemyRecharge {
        get {
          return this._normalEnemyRecharge;
        }
        set {
          this._normalEnemyRecharge = value;
        }
      }
      public Real HardEnemyRecharge {
        get {
          return this._hardEnemyRecharge;
        }
        set {
          this._hardEnemyRecharge = value;
        }
      }
      public Real ImpossEnemyRecharge {
        get {
          return this._impossEnemyRecharge;
        }
        set {
          this._impossEnemyRecharge = value;
        }
      }
      public Real EasyFriendDamage {
        get {
          return this._easyFriendDamage;
        }
        set {
          this._easyFriendDamage = value;
        }
      }
      public Real NormalFriendDamage {
        get {
          return this._normalFriendDamage;
        }
        set {
          this._normalFriendDamage = value;
        }
      }
      public Real HardFriendDamage {
        get {
          return this._hardFriendDamage;
        }
        set {
          this._hardFriendDamage = value;
        }
      }
      public Real ImpossFriendDamage {
        get {
          return this._impossFriendDamage;
        }
        set {
          this._impossFriendDamage = value;
        }
      }
      public Real EasyFriendVitality {
        get {
          return this._easyFriendVitality;
        }
        set {
          this._easyFriendVitality = value;
        }
      }
      public Real NormalFriendVitality {
        get {
          return this._normalFriendVitality;
        }
        set {
          this._normalFriendVitality = value;
        }
      }
      public Real HardFriendVitality {
        get {
          return this._hardFriendVitality;
        }
        set {
          this._hardFriendVitality = value;
        }
      }
      public Real ImpossFriendVitality {
        get {
          return this._impossFriendVitality;
        }
        set {
          this._impossFriendVitality = value;
        }
      }
      public Real EasyFriendShield {
        get {
          return this._easyFriendShield;
        }
        set {
          this._easyFriendShield = value;
        }
      }
      public Real NormalFriendShield {
        get {
          return this._normalFriendShield;
        }
        set {
          this._normalFriendShield = value;
        }
      }
      public Real HardFriendShield {
        get {
          return this._hardFriendShield;
        }
        set {
          this._hardFriendShield = value;
        }
      }
      public Real ImpossFriendShield {
        get {
          return this._impossFriendShield;
        }
        set {
          this._impossFriendShield = value;
        }
      }
      public Real EasyFriendRecharge {
        get {
          return this._easyFriendRecharge;
        }
        set {
          this._easyFriendRecharge = value;
        }
      }
      public Real NormalFriendRecharge {
        get {
          return this._normalFriendRecharge;
        }
        set {
          this._normalFriendRecharge = value;
        }
      }
      public Real HardFriendRecharge {
        get {
          return this._hardFriendRecharge;
        }
        set {
          this._hardFriendRecharge = value;
        }
      }
      public Real ImpossFriendRecharge {
        get {
          return this._impossFriendRecharge;
        }
        set {
          this._impossFriendRecharge = value;
        }
      }
      public Real EasyInfectionForms {
        get {
          return this._easyInfectionForms;
        }
        set {
          this._easyInfectionForms = value;
        }
      }
      public Real NormalInfectionForms {
        get {
          return this._normalInfectionForms;
        }
        set {
          this._normalInfectionForms = value;
        }
      }
      public Real HardInfectionForms {
        get {
          return this._hardInfectionForms;
        }
        set {
          this._hardInfectionForms = value;
        }
      }
      public Real ImpossInfectionForms {
        get {
          return this._impossInfectionForms;
        }
        set {
          this._impossInfectionForms = value;
        }
      }
      public Real EasyRateOfFire {
        get {
          return this._easyRateOfFire;
        }
        set {
          this._easyRateOfFire = value;
        }
      }
      public Real NormalRateOfFire {
        get {
          return this._normalRateOfFire;
        }
        set {
          this._normalRateOfFire = value;
        }
      }
      public Real HardRateOfFire {
        get {
          return this._hardRateOfFire;
        }
        set {
          this._hardRateOfFire = value;
        }
      }
      public Real ImpossRateOfFire {
        get {
          return this._impossRateOfFire;
        }
        set {
          this._impossRateOfFire = value;
        }
      }
      public Real EasyProjectileError {
        get {
          return this._easyProjectileError;
        }
        set {
          this._easyProjectileError = value;
        }
      }
      public Real NormalProjectileError {
        get {
          return this._normalProjectileError;
        }
        set {
          this._normalProjectileError = value;
        }
      }
      public Real HardProjectileError {
        get {
          return this._hardProjectileError;
        }
        set {
          this._hardProjectileError = value;
        }
      }
      public Real ImpossProjectileError {
        get {
          return this._impossProjectileError;
        }
        set {
          this._impossProjectileError = value;
        }
      }
      public Real EasyBurstError {
        get {
          return this._easyBurstError;
        }
        set {
          this._easyBurstError = value;
        }
      }
      public Real NormalBurstError {
        get {
          return this._normalBurstError;
        }
        set {
          this._normalBurstError = value;
        }
      }
      public Real HardBurstError {
        get {
          return this._hardBurstError;
        }
        set {
          this._hardBurstError = value;
        }
      }
      public Real ImpossBurstError {
        get {
          return this._impossBurstError;
        }
        set {
          this._impossBurstError = value;
        }
      }
      public Real EasyNewTargetDelay {
        get {
          return this._easyNewTargetDelay;
        }
        set {
          this._easyNewTargetDelay = value;
        }
      }
      public Real NormalNewTargetDelay {
        get {
          return this._normalNewTargetDelay;
        }
        set {
          this._normalNewTargetDelay = value;
        }
      }
      public Real HardNewTargetDelay {
        get {
          return this._hardNewTargetDelay;
        }
        set {
          this._hardNewTargetDelay = value;
        }
      }
      public Real ImpossNewTargetDelay {
        get {
          return this._impossNewTargetDelay;
        }
        set {
          this._impossNewTargetDelay = value;
        }
      }
      public Real EasyBurstSeparation {
        get {
          return this._easyBurstSeparation;
        }
        set {
          this._easyBurstSeparation = value;
        }
      }
      public Real NormalBurstSeparation {
        get {
          return this._normalBurstSeparation;
        }
        set {
          this._normalBurstSeparation = value;
        }
      }
      public Real HardBurstSeparation {
        get {
          return this._hardBurstSeparation;
        }
        set {
          this._hardBurstSeparation = value;
        }
      }
      public Real ImpossBurstSeparation {
        get {
          return this._impossBurstSeparation;
        }
        set {
          this._impossBurstSeparation = value;
        }
      }
      public Real EasyTargetTracking {
        get {
          return this._easyTargetTracking;
        }
        set {
          this._easyTargetTracking = value;
        }
      }
      public Real NormalTargetTracking {
        get {
          return this._normalTargetTracking;
        }
        set {
          this._normalTargetTracking = value;
        }
      }
      public Real HardTargetTracking {
        get {
          return this._hardTargetTracking;
        }
        set {
          this._hardTargetTracking = value;
        }
      }
      public Real ImpossTargetTracking {
        get {
          return this._impossTargetTracking;
        }
        set {
          this._impossTargetTracking = value;
        }
      }
      public Real EasyTargetLeading {
        get {
          return this._easyTargetLeading;
        }
        set {
          this._easyTargetLeading = value;
        }
      }
      public Real NormalTargetLeading {
        get {
          return this._normalTargetLeading;
        }
        set {
          this._normalTargetLeading = value;
        }
      }
      public Real HardTargetLeading {
        get {
          return this._hardTargetLeading;
        }
        set {
          this._hardTargetLeading = value;
        }
      }
      public Real ImpossTargetLeading {
        get {
          return this._impossTargetLeading;
        }
        set {
          this._impossTargetLeading = value;
        }
      }
      public Real EasyOverchargeChance {
        get {
          return this._easyOverchargeChance;
        }
        set {
          this._easyOverchargeChance = value;
        }
      }
      public Real NormalOverchargeChance {
        get {
          return this._normalOverchargeChance;
        }
        set {
          this._normalOverchargeChance = value;
        }
      }
      public Real HardOverchargeChance {
        get {
          return this._hardOverchargeChance;
        }
        set {
          this._hardOverchargeChance = value;
        }
      }
      public Real ImpossOverchargeChance {
        get {
          return this._impossOverchargeChance;
        }
        set {
          this._impossOverchargeChance = value;
        }
      }
      public Real EasySpecialFireDelay {
        get {
          return this._easySpecialFireDelay;
        }
        set {
          this._easySpecialFireDelay = value;
        }
      }
      public Real NormalSpecialFireDelay {
        get {
          return this._normalSpecialFireDelay;
        }
        set {
          this._normalSpecialFireDelay = value;
        }
      }
      public Real HardSpecialFireDelay {
        get {
          return this._hardSpecialFireDelay;
        }
        set {
          this._hardSpecialFireDelay = value;
        }
      }
      public Real ImpossSpecialFireDelay {
        get {
          return this._impossSpecialFireDelay;
        }
        set {
          this._impossSpecialFireDelay = value;
        }
      }
      public Real EasyGuidanceVsPlayer {
        get {
          return this._easyGuidanceVsPlayer;
        }
        set {
          this._easyGuidanceVsPlayer = value;
        }
      }
      public Real NormalGuidanceVsPlayer {
        get {
          return this._normalGuidanceVsPlayer;
        }
        set {
          this._normalGuidanceVsPlayer = value;
        }
      }
      public Real HardGuidanceVsPlayer {
        get {
          return this._hardGuidanceVsPlayer;
        }
        set {
          this._hardGuidanceVsPlayer = value;
        }
      }
      public Real ImpossGuidanceVsPlayer {
        get {
          return this._impossGuidanceVsPlayer;
        }
        set {
          this._impossGuidanceVsPlayer = value;
        }
      }
      public Real EasyMeleeDelayBase {
        get {
          return this._easyMeleeDelayBase;
        }
        set {
          this._easyMeleeDelayBase = value;
        }
      }
      public Real NormalMeleeDelayBase {
        get {
          return this._normalMeleeDelayBase;
        }
        set {
          this._normalMeleeDelayBase = value;
        }
      }
      public Real HardMeleeDelayBase {
        get {
          return this._hardMeleeDelayBase;
        }
        set {
          this._hardMeleeDelayBase = value;
        }
      }
      public Real ImpossMeleeDelayBase {
        get {
          return this._impossMeleeDelayBase;
        }
        set {
          this._impossMeleeDelayBase = value;
        }
      }
      public Real EasyMeleeDelayScale {
        get {
          return this._easyMeleeDelayScale;
        }
        set {
          this._easyMeleeDelayScale = value;
        }
      }
      public Real NormalMeleeDelayScale {
        get {
          return this._normalMeleeDelayScale;
        }
        set {
          this._normalMeleeDelayScale = value;
        }
      }
      public Real HardMeleeDelayScale {
        get {
          return this._hardMeleeDelayScale;
        }
        set {
          this._hardMeleeDelayScale = value;
        }
      }
      public Real ImpossMeleeDelayScale {
        get {
          return this._impossMeleeDelayScale;
        }
        set {
          this._impossMeleeDelayScale = value;
        }
      }
      public Real EasyGrenadeChanceScale {
        get {
          return this._easyGrenadeChanceScale;
        }
        set {
          this._easyGrenadeChanceScale = value;
        }
      }
      public Real NormalGrenadeChanceScale {
        get {
          return this._normalGrenadeChanceScale;
        }
        set {
          this._normalGrenadeChanceScale = value;
        }
      }
      public Real HardGrenadeChanceScale {
        get {
          return this._hardGrenadeChanceScale;
        }
        set {
          this._hardGrenadeChanceScale = value;
        }
      }
      public Real ImpossGrenadeChanceScale {
        get {
          return this._impossGrenadeChanceScale;
        }
        set {
          this._impossGrenadeChanceScale = value;
        }
      }
      public Real EasyGrenadeTimerScale {
        get {
          return this._easyGrenadeTimerScale;
        }
        set {
          this._easyGrenadeTimerScale = value;
        }
      }
      public Real NormalGrenadeTimerScale {
        get {
          return this._normalGrenadeTimerScale;
        }
        set {
          this._normalGrenadeTimerScale = value;
        }
      }
      public Real HardGrenadeTimerScale {
        get {
          return this._hardGrenadeTimerScale;
        }
        set {
          this._hardGrenadeTimerScale = value;
        }
      }
      public Real ImpossGrenadeTimerScale {
        get {
          return this._impossGrenadeTimerScale;
        }
        set {
          this._impossGrenadeTimerScale = value;
        }
      }
      public Real EasyMajorUpgradeNormal {
        get {
          return this._easyMajorUpgradeNormal;
        }
        set {
          this._easyMajorUpgradeNormal = value;
        }
      }
      public Real NormalMajorUpgradeNormal {
        get {
          return this._normalMajorUpgradeNormal;
        }
        set {
          this._normalMajorUpgradeNormal = value;
        }
      }
      public Real HardMajorUpgradeNormal {
        get {
          return this._hardMajorUpgradeNormal;
        }
        set {
          this._hardMajorUpgradeNormal = value;
        }
      }
      public Real ImpossMajorUpgradeNormal {
        get {
          return this._impossMajorUpgradeNormal;
        }
        set {
          this._impossMajorUpgradeNormal = value;
        }
      }
      public Real EasyMajorUpgradeFew {
        get {
          return this._easyMajorUpgradeFew;
        }
        set {
          this._easyMajorUpgradeFew = value;
        }
      }
      public Real NormalMajorUpgradeFew {
        get {
          return this._normalMajorUpgradeFew;
        }
        set {
          this._normalMajorUpgradeFew = value;
        }
      }
      public Real HardMajorUpgradeFew {
        get {
          return this._hardMajorUpgradeFew;
        }
        set {
          this._hardMajorUpgradeFew = value;
        }
      }
      public Real ImpossMajorUpgradeFew {
        get {
          return this._impossMajorUpgradeFew;
        }
        set {
          this._impossMajorUpgradeFew = value;
        }
      }
      public Real EasyMajorUpgradeMany {
        get {
          return this._easyMajorUpgradeMany;
        }
        set {
          this._easyMajorUpgradeMany = value;
        }
      }
      public Real NormalMajorUpgradeMany {
        get {
          return this._normalMajorUpgradeMany;
        }
        set {
          this._normalMajorUpgradeMany = value;
        }
      }
      public Real HardMajorUpgradeMany {
        get {
          return this._hardMajorUpgradeMany;
        }
        set {
          this._hardMajorUpgradeMany = value;
        }
      }
      public Real ImpossMajorUpgradeMany {
        get {
          return this._impossMajorUpgradeMany;
        }
        set {
          this._impossMajorUpgradeMany = value;
        }
      }
      public Real EasyPlayerVehicleRamChance {
        get {
          return this._easyPlayerVehicleRamChance;
        }
        set {
          this._easyPlayerVehicleRamChance = value;
        }
      }
      public Real NormalPlayerVehicleRamChance {
        get {
          return this._normalPlayerVehicleRamChance;
        }
        set {
          this._normalPlayerVehicleRamChance = value;
        }
      }
      public Real HardPlayerVehicleRamChance {
        get {
          return this._hardPlayerVehicleRamChance;
        }
        set {
          this._hardPlayerVehicleRamChance = value;
        }
      }
      public Real ImpossPlayerVehicleRamChance {
        get {
          return this._impossPlayerVehicleRamChance;
        }
        set {
          this._impossPlayerVehicleRamChance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _easyEnemyDamage.Read(reader);
        _normalEnemyDamage.Read(reader);
        _hardEnemyDamage.Read(reader);
        _impossEnemyDamage.Read(reader);
        _easyEnemyVitality.Read(reader);
        _normalEnemyVitality.Read(reader);
        _hardEnemyVitality.Read(reader);
        _impossEnemyVitality.Read(reader);
        _easyEnemyShield.Read(reader);
        _normalEnemyShield.Read(reader);
        _hardEnemyShield.Read(reader);
        _impossEnemyShield.Read(reader);
        _easyEnemyRecharge.Read(reader);
        _normalEnemyRecharge.Read(reader);
        _hardEnemyRecharge.Read(reader);
        _impossEnemyRecharge.Read(reader);
        _easyFriendDamage.Read(reader);
        _normalFriendDamage.Read(reader);
        _hardFriendDamage.Read(reader);
        _impossFriendDamage.Read(reader);
        _easyFriendVitality.Read(reader);
        _normalFriendVitality.Read(reader);
        _hardFriendVitality.Read(reader);
        _impossFriendVitality.Read(reader);
        _easyFriendShield.Read(reader);
        _normalFriendShield.Read(reader);
        _hardFriendShield.Read(reader);
        _impossFriendShield.Read(reader);
        _easyFriendRecharge.Read(reader);
        _normalFriendRecharge.Read(reader);
        _hardFriendRecharge.Read(reader);
        _impossFriendRecharge.Read(reader);
        _easyInfectionForms.Read(reader);
        _normalInfectionForms.Read(reader);
        _hardInfectionForms.Read(reader);
        _impossInfectionForms.Read(reader);
        _unnamed0.Read(reader);
        _easyRateOfFire.Read(reader);
        _normalRateOfFire.Read(reader);
        _hardRateOfFire.Read(reader);
        _impossRateOfFire.Read(reader);
        _easyProjectileError.Read(reader);
        _normalProjectileError.Read(reader);
        _hardProjectileError.Read(reader);
        _impossProjectileError.Read(reader);
        _easyBurstError.Read(reader);
        _normalBurstError.Read(reader);
        _hardBurstError.Read(reader);
        _impossBurstError.Read(reader);
        _easyNewTargetDelay.Read(reader);
        _normalNewTargetDelay.Read(reader);
        _hardNewTargetDelay.Read(reader);
        _impossNewTargetDelay.Read(reader);
        _easyBurstSeparation.Read(reader);
        _normalBurstSeparation.Read(reader);
        _hardBurstSeparation.Read(reader);
        _impossBurstSeparation.Read(reader);
        _easyTargetTracking.Read(reader);
        _normalTargetTracking.Read(reader);
        _hardTargetTracking.Read(reader);
        _impossTargetTracking.Read(reader);
        _easyTargetLeading.Read(reader);
        _normalTargetLeading.Read(reader);
        _hardTargetLeading.Read(reader);
        _impossTargetLeading.Read(reader);
        _easyOverchargeChance.Read(reader);
        _normalOverchargeChance.Read(reader);
        _hardOverchargeChance.Read(reader);
        _impossOverchargeChance.Read(reader);
        _easySpecialFireDelay.Read(reader);
        _normalSpecialFireDelay.Read(reader);
        _hardSpecialFireDelay.Read(reader);
        _impossSpecialFireDelay.Read(reader);
        _easyGuidanceVsPlayer.Read(reader);
        _normalGuidanceVsPlayer.Read(reader);
        _hardGuidanceVsPlayer.Read(reader);
        _impossGuidanceVsPlayer.Read(reader);
        _easyMeleeDelayBase.Read(reader);
        _normalMeleeDelayBase.Read(reader);
        _hardMeleeDelayBase.Read(reader);
        _impossMeleeDelayBase.Read(reader);
        _easyMeleeDelayScale.Read(reader);
        _normalMeleeDelayScale.Read(reader);
        _hardMeleeDelayScale.Read(reader);
        _impossMeleeDelayScale.Read(reader);
        _unnamed1.Read(reader);
        _easyGrenadeChanceScale.Read(reader);
        _normalGrenadeChanceScale.Read(reader);
        _hardGrenadeChanceScale.Read(reader);
        _impossGrenadeChanceScale.Read(reader);
        _easyGrenadeTimerScale.Read(reader);
        _normalGrenadeTimerScale.Read(reader);
        _hardGrenadeTimerScale.Read(reader);
        _impossGrenadeTimerScale.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _easyMajorUpgradeNormal.Read(reader);
        _normalMajorUpgradeNormal.Read(reader);
        _hardMajorUpgradeNormal.Read(reader);
        _impossMajorUpgradeNormal.Read(reader);
        _easyMajorUpgradeFew.Read(reader);
        _normalMajorUpgradeFew.Read(reader);
        _hardMajorUpgradeFew.Read(reader);
        _impossMajorUpgradeFew.Read(reader);
        _easyMajorUpgradeMany.Read(reader);
        _normalMajorUpgradeMany.Read(reader);
        _hardMajorUpgradeMany.Read(reader);
        _impossMajorUpgradeMany.Read(reader);
        _easyPlayerVehicleRamChance.Read(reader);
        _normalPlayerVehicleRamChance.Read(reader);
        _hardPlayerVehicleRamChance.Read(reader);
        _impossPlayerVehicleRamChance.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _easyEnemyDamage.Write(bw);
        _normalEnemyDamage.Write(bw);
        _hardEnemyDamage.Write(bw);
        _impossEnemyDamage.Write(bw);
        _easyEnemyVitality.Write(bw);
        _normalEnemyVitality.Write(bw);
        _hardEnemyVitality.Write(bw);
        _impossEnemyVitality.Write(bw);
        _easyEnemyShield.Write(bw);
        _normalEnemyShield.Write(bw);
        _hardEnemyShield.Write(bw);
        _impossEnemyShield.Write(bw);
        _easyEnemyRecharge.Write(bw);
        _normalEnemyRecharge.Write(bw);
        _hardEnemyRecharge.Write(bw);
        _impossEnemyRecharge.Write(bw);
        _easyFriendDamage.Write(bw);
        _normalFriendDamage.Write(bw);
        _hardFriendDamage.Write(bw);
        _impossFriendDamage.Write(bw);
        _easyFriendVitality.Write(bw);
        _normalFriendVitality.Write(bw);
        _hardFriendVitality.Write(bw);
        _impossFriendVitality.Write(bw);
        _easyFriendShield.Write(bw);
        _normalFriendShield.Write(bw);
        _hardFriendShield.Write(bw);
        _impossFriendShield.Write(bw);
        _easyFriendRecharge.Write(bw);
        _normalFriendRecharge.Write(bw);
        _hardFriendRecharge.Write(bw);
        _impossFriendRecharge.Write(bw);
        _easyInfectionForms.Write(bw);
        _normalInfectionForms.Write(bw);
        _hardInfectionForms.Write(bw);
        _impossInfectionForms.Write(bw);
        _unnamed0.Write(bw);
        _easyRateOfFire.Write(bw);
        _normalRateOfFire.Write(bw);
        _hardRateOfFire.Write(bw);
        _impossRateOfFire.Write(bw);
        _easyProjectileError.Write(bw);
        _normalProjectileError.Write(bw);
        _hardProjectileError.Write(bw);
        _impossProjectileError.Write(bw);
        _easyBurstError.Write(bw);
        _normalBurstError.Write(bw);
        _hardBurstError.Write(bw);
        _impossBurstError.Write(bw);
        _easyNewTargetDelay.Write(bw);
        _normalNewTargetDelay.Write(bw);
        _hardNewTargetDelay.Write(bw);
        _impossNewTargetDelay.Write(bw);
        _easyBurstSeparation.Write(bw);
        _normalBurstSeparation.Write(bw);
        _hardBurstSeparation.Write(bw);
        _impossBurstSeparation.Write(bw);
        _easyTargetTracking.Write(bw);
        _normalTargetTracking.Write(bw);
        _hardTargetTracking.Write(bw);
        _impossTargetTracking.Write(bw);
        _easyTargetLeading.Write(bw);
        _normalTargetLeading.Write(bw);
        _hardTargetLeading.Write(bw);
        _impossTargetLeading.Write(bw);
        _easyOverchargeChance.Write(bw);
        _normalOverchargeChance.Write(bw);
        _hardOverchargeChance.Write(bw);
        _impossOverchargeChance.Write(bw);
        _easySpecialFireDelay.Write(bw);
        _normalSpecialFireDelay.Write(bw);
        _hardSpecialFireDelay.Write(bw);
        _impossSpecialFireDelay.Write(bw);
        _easyGuidanceVsPlayer.Write(bw);
        _normalGuidanceVsPlayer.Write(bw);
        _hardGuidanceVsPlayer.Write(bw);
        _impossGuidanceVsPlayer.Write(bw);
        _easyMeleeDelayBase.Write(bw);
        _normalMeleeDelayBase.Write(bw);
        _hardMeleeDelayBase.Write(bw);
        _impossMeleeDelayBase.Write(bw);
        _easyMeleeDelayScale.Write(bw);
        _normalMeleeDelayScale.Write(bw);
        _hardMeleeDelayScale.Write(bw);
        _impossMeleeDelayScale.Write(bw);
        _unnamed1.Write(bw);
        _easyGrenadeChanceScale.Write(bw);
        _normalGrenadeChanceScale.Write(bw);
        _hardGrenadeChanceScale.Write(bw);
        _impossGrenadeChanceScale.Write(bw);
        _easyGrenadeTimerScale.Write(bw);
        _normalGrenadeTimerScale.Write(bw);
        _hardGrenadeTimerScale.Write(bw);
        _impossGrenadeTimerScale.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _easyMajorUpgradeNormal.Write(bw);
        _normalMajorUpgradeNormal.Write(bw);
        _hardMajorUpgradeNormal.Write(bw);
        _impossMajorUpgradeNormal.Write(bw);
        _easyMajorUpgradeFew.Write(bw);
        _normalMajorUpgradeFew.Write(bw);
        _hardMajorUpgradeFew.Write(bw);
        _impossMajorUpgradeFew.Write(bw);
        _easyMajorUpgradeMany.Write(bw);
        _normalMajorUpgradeMany.Write(bw);
        _hardMajorUpgradeMany.Write(bw);
        _impossMajorUpgradeMany.Write(bw);
        _easyPlayerVehicleRamChance.Write(bw);
        _normalPlayerVehicleRamChance.Write(bw);
        _hardPlayerVehicleRamChance.Write(bw);
        _impossPlayerVehicleRamChance.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GrenadesBlockBlock : IBlock {
      private ShortInteger _maximumCount = new ShortInteger();
      private Pad _unnamed0;
      private TagReference _throwingEffect = new TagReference();
      private Pad _unnamed1;
      private TagReference _equipment = new TagReference();
      private TagReference _projectile = new TagReference();
public event System.EventHandler BlockNameChanged;
      public GrenadesBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_throwingEffect.Value);
references.Add(_equipment.Value);
references.Add(_projectile.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortInteger MaximumCount {
        get {
          return this._maximumCount;
        }
        set {
          this._maximumCount = value;
        }
      }
      public TagReference ThrowingEffect {
        get {
          return this._throwingEffect;
        }
        set {
          this._throwingEffect = value;
        }
      }
      public TagReference Equipment {
        get {
          return this._equipment;
        }
        set {
          this._equipment = value;
        }
      }
      public TagReference Projectile {
        get {
          return this._projectile;
        }
        set {
          this._projectile = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _maximumCount.Read(reader);
        _unnamed0.Read(reader);
        _throwingEffect.Read(reader);
        _unnamed1.Read(reader);
        _equipment.Read(reader);
        _projectile.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _throwingEffect.ReadString(reader);
        _equipment.ReadString(reader);
        _projectile.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _maximumCount.Write(bw);
        _unnamed0.Write(bw);
        _throwingEffect.Write(bw);
        _unnamed1.Write(bw);
        _equipment.Write(bw);
        _projectile.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _throwingEffect.WriteString(writer);
        _equipment.WriteString(writer);
        _projectile.WriteString(writer);
      }
    }
    public class RasterizerDataBlockBlock : IBlock {
      private TagReference _distanceAttenuation = new TagReference();
      private TagReference _vectorNormalization = new TagReference();
      private TagReference _gradients = new TagReference();
      private TagReference _uNUSED = new TagReference();
      private TagReference _uNUSED2 = new TagReference();
      private TagReference _uNUSED3 = new TagReference();
      private TagReference _glow = new TagReference();
      private TagReference _uNUSED4 = new TagReference();
      private TagReference _uNUSED5 = new TagReference();
      private Pad _unnamed0;
      private Block _globalVertexShaders = new Block();
      private TagReference _default2D = new TagReference();
      private TagReference _default3D = new TagReference();
      private TagReference _defaultCubeMap = new TagReference();
      private TagReference _uNUSED6 = new TagReference();
      private TagReference _uNUSED7 = new TagReference();
      private TagReference _uNUSED8 = new TagReference();
      private TagReference _uNUSED9 = new TagReference();
      private TagReference _uNUSED10 = new TagReference();
      private TagReference _uNUSED11 = new TagReference();
      private Pad _unnamed1;
      private TagReference _globalShader = new TagReference();
      private Flags _flags;
      private Pad _unnamed2;
      private Real _refractionAmount = new Real();
      private Real _distanceFalloff = new Real();
      private RealRGBColor _tintColor = new RealRGBColor();
      private Real _hyper_MinusstealthRefraction = new Real();
      private Real _hyper_MinusstealthDistanceFalloff = new Real();
      private RealRGBColor _hyper_MinusstealthTintColor = new RealRGBColor();
      private TagReference _uNUSED12 = new TagReference();
      public BlockCollection<VertexShaderReferenceBlockBlock> _globalVertexShadersList = new BlockCollection<VertexShaderReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RasterizerDataBlockBlock() {
        this._unnamed0 = new Pad(16);
        this._unnamed1 = new Pad(36);
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<VertexShaderReferenceBlockBlock> GlobalVertexShaders {
        get {
          return this._globalVertexShadersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_distanceAttenuation.Value);
references.Add(_vectorNormalization.Value);
references.Add(_gradients.Value);
references.Add(_uNUSED.Value);
references.Add(_uNUSED2.Value);
references.Add(_uNUSED3.Value);
references.Add(_glow.Value);
references.Add(_uNUSED4.Value);
references.Add(_uNUSED5.Value);
references.Add(_default2D.Value);
references.Add(_default3D.Value);
references.Add(_defaultCubeMap.Value);
references.Add(_uNUSED6.Value);
references.Add(_uNUSED7.Value);
references.Add(_uNUSED8.Value);
references.Add(_uNUSED9.Value);
references.Add(_uNUSED10.Value);
references.Add(_uNUSED11.Value);
references.Add(_globalShader.Value);
references.Add(_uNUSED12.Value);
for (int x=0; x<GlobalVertexShaders.BlockCount; x++)
{
  IBlock block = GlobalVertexShaders.GetBlock(x);
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
      public TagReference DistanceAttenuation {
        get {
          return this._distanceAttenuation;
        }
        set {
          this._distanceAttenuation = value;
        }
      }
      public TagReference VectorNormalization {
        get {
          return this._vectorNormalization;
        }
        set {
          this._vectorNormalization = value;
        }
      }
      public TagReference Gradients {
        get {
          return this._gradients;
        }
        set {
          this._gradients = value;
        }
      }
      public TagReference UNUSED {
        get {
          return this._uNUSED;
        }
        set {
          this._uNUSED = value;
        }
      }
      public TagReference UNUSED2 {
        get {
          return this._uNUSED2;
        }
        set {
          this._uNUSED2 = value;
        }
      }
      public TagReference UNUSED3 {
        get {
          return this._uNUSED3;
        }
        set {
          this._uNUSED3 = value;
        }
      }
      public TagReference Glow {
        get {
          return this._glow;
        }
        set {
          this._glow = value;
        }
      }
      public TagReference UNUSED4 {
        get {
          return this._uNUSED4;
        }
        set {
          this._uNUSED4 = value;
        }
      }
      public TagReference UNUSED5 {
        get {
          return this._uNUSED5;
        }
        set {
          this._uNUSED5 = value;
        }
      }
      public TagReference Default2D {
        get {
          return this._default2D;
        }
        set {
          this._default2D = value;
        }
      }
      public TagReference Default3D {
        get {
          return this._default3D;
        }
        set {
          this._default3D = value;
        }
      }
      public TagReference DefaultCubeMap {
        get {
          return this._defaultCubeMap;
        }
        set {
          this._defaultCubeMap = value;
        }
      }
      public TagReference UNUSED6 {
        get {
          return this._uNUSED6;
        }
        set {
          this._uNUSED6 = value;
        }
      }
      public TagReference UNUSED7 {
        get {
          return this._uNUSED7;
        }
        set {
          this._uNUSED7 = value;
        }
      }
      public TagReference UNUSED8 {
        get {
          return this._uNUSED8;
        }
        set {
          this._uNUSED8 = value;
        }
      }
      public TagReference UNUSED9 {
        get {
          return this._uNUSED9;
        }
        set {
          this._uNUSED9 = value;
        }
      }
      public TagReference UNUSED10 {
        get {
          return this._uNUSED10;
        }
        set {
          this._uNUSED10 = value;
        }
      }
      public TagReference UNUSED11 {
        get {
          return this._uNUSED11;
        }
        set {
          this._uNUSED11 = value;
        }
      }
      public TagReference GlobalShader {
        get {
          return this._globalShader;
        }
        set {
          this._globalShader = value;
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
      public Real RefractionAmount {
        get {
          return this._refractionAmount;
        }
        set {
          this._refractionAmount = value;
        }
      }
      public Real DistanceFalloff {
        get {
          return this._distanceFalloff;
        }
        set {
          this._distanceFalloff = value;
        }
      }
      public RealRGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
        }
      }
      public Real Hyper_MinusstealthRefraction {
        get {
          return this._hyper_MinusstealthRefraction;
        }
        set {
          this._hyper_MinusstealthRefraction = value;
        }
      }
      public Real Hyper_MinusstealthDistanceFalloff {
        get {
          return this._hyper_MinusstealthDistanceFalloff;
        }
        set {
          this._hyper_MinusstealthDistanceFalloff = value;
        }
      }
      public RealRGBColor Hyper_MinusstealthTintColor {
        get {
          return this._hyper_MinusstealthTintColor;
        }
        set {
          this._hyper_MinusstealthTintColor = value;
        }
      }
      public TagReference UNUSED12 {
        get {
          return this._uNUSED12;
        }
        set {
          this._uNUSED12 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _distanceAttenuation.Read(reader);
        _vectorNormalization.Read(reader);
        _gradients.Read(reader);
        _uNUSED.Read(reader);
        _uNUSED2.Read(reader);
        _uNUSED3.Read(reader);
        _glow.Read(reader);
        _uNUSED4.Read(reader);
        _uNUSED5.Read(reader);
        _unnamed0.Read(reader);
        _globalVertexShaders.Read(reader);
        _default2D.Read(reader);
        _default3D.Read(reader);
        _defaultCubeMap.Read(reader);
        _uNUSED6.Read(reader);
        _uNUSED7.Read(reader);
        _uNUSED8.Read(reader);
        _uNUSED9.Read(reader);
        _uNUSED10.Read(reader);
        _uNUSED11.Read(reader);
        _unnamed1.Read(reader);
        _globalShader.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _refractionAmount.Read(reader);
        _distanceFalloff.Read(reader);
        _tintColor.Read(reader);
        _hyper_MinusstealthRefraction.Read(reader);
        _hyper_MinusstealthDistanceFalloff.Read(reader);
        _hyper_MinusstealthTintColor.Read(reader);
        _uNUSED12.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _distanceAttenuation.ReadString(reader);
        _vectorNormalization.ReadString(reader);
        _gradients.ReadString(reader);
        _uNUSED.ReadString(reader);
        _uNUSED2.ReadString(reader);
        _uNUSED3.ReadString(reader);
        _glow.ReadString(reader);
        _uNUSED4.ReadString(reader);
        _uNUSED5.ReadString(reader);
        for (x = 0; (x < _globalVertexShaders.Count); x = (x + 1)) {
          GlobalVertexShaders.Add(new VertexShaderReferenceBlockBlock());
          GlobalVertexShaders[x].Read(reader);
        }
        for (x = 0; (x < _globalVertexShaders.Count); x = (x + 1)) {
          GlobalVertexShaders[x].ReadChildData(reader);
        }
        _default2D.ReadString(reader);
        _default3D.ReadString(reader);
        _defaultCubeMap.ReadString(reader);
        _uNUSED6.ReadString(reader);
        _uNUSED7.ReadString(reader);
        _uNUSED8.ReadString(reader);
        _uNUSED9.ReadString(reader);
        _uNUSED10.ReadString(reader);
        _uNUSED11.ReadString(reader);
        _globalShader.ReadString(reader);
        _uNUSED12.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _distanceAttenuation.Write(bw);
        _vectorNormalization.Write(bw);
        _gradients.Write(bw);
        _uNUSED.Write(bw);
        _uNUSED2.Write(bw);
        _uNUSED3.Write(bw);
        _glow.Write(bw);
        _uNUSED4.Write(bw);
        _uNUSED5.Write(bw);
        _unnamed0.Write(bw);
_globalVertexShaders.Count = GlobalVertexShaders.Count;
        _globalVertexShaders.Write(bw);
        _default2D.Write(bw);
        _default3D.Write(bw);
        _defaultCubeMap.Write(bw);
        _uNUSED6.Write(bw);
        _uNUSED7.Write(bw);
        _uNUSED8.Write(bw);
        _uNUSED9.Write(bw);
        _uNUSED10.Write(bw);
        _uNUSED11.Write(bw);
        _unnamed1.Write(bw);
        _globalShader.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _refractionAmount.Write(bw);
        _distanceFalloff.Write(bw);
        _tintColor.Write(bw);
        _hyper_MinusstealthRefraction.Write(bw);
        _hyper_MinusstealthDistanceFalloff.Write(bw);
        _hyper_MinusstealthTintColor.Write(bw);
        _uNUSED12.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _distanceAttenuation.WriteString(writer);
        _vectorNormalization.WriteString(writer);
        _gradients.WriteString(writer);
        _uNUSED.WriteString(writer);
        _uNUSED2.WriteString(writer);
        _uNUSED3.WriteString(writer);
        _glow.WriteString(writer);
        _uNUSED4.WriteString(writer);
        _uNUSED5.WriteString(writer);
        for (x = 0; (x < _globalVertexShaders.Count); x = (x + 1)) {
          GlobalVertexShaders[x].Write(writer);
        }
        for (x = 0; (x < _globalVertexShaders.Count); x = (x + 1)) {
          GlobalVertexShaders[x].WriteChildData(writer);
        }
        _default2D.WriteString(writer);
        _default3D.WriteString(writer);
        _defaultCubeMap.WriteString(writer);
        _uNUSED6.WriteString(writer);
        _uNUSED7.WriteString(writer);
        _uNUSED8.WriteString(writer);
        _uNUSED9.WriteString(writer);
        _uNUSED10.WriteString(writer);
        _uNUSED11.WriteString(writer);
        _globalShader.WriteString(writer);
        _uNUSED12.WriteString(writer);
      }
    }
    public class VertexShaderReferenceBlockBlock : IBlock {
      private TagReference _vertexShader = new TagReference();
public event System.EventHandler BlockNameChanged;
      public VertexShaderReferenceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vertexShader.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference VertexShader {
        get {
          return this._vertexShader;
        }
        set {
          this._vertexShader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertexShader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vertexShader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _vertexShader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vertexShader.WriteString(writer);
      }
    }
    public class InterfaceTagReferencesBlock : IBlock {
      private TagReference _obsolete1 = new TagReference();
      private TagReference _obsolete2 = new TagReference();
      private TagReference _screenColorTable = new TagReference();
      private TagReference _hudColorTable = new TagReference();
      private TagReference _editorColorTable = new TagReference();
      private TagReference _dialogColorTable = new TagReference();
      private TagReference _hudGlobals = new TagReference();
      private TagReference _motionSensorSweepBitmap = new TagReference();
      private TagReference _motionSensorSweepBitmapMask = new TagReference();
      private TagReference _multiplayerHudBitmap = new TagReference();
      private TagReference _unnamed0 = new TagReference();
      private TagReference _hudDigitsDefinition = new TagReference();
      private TagReference _motionSensorBlipBitmap = new TagReference();
      private TagReference _interfaceGooMap1 = new TagReference();
      private TagReference _interfaceGooMap2 = new TagReference();
      private TagReference _interfaceGooMap3 = new TagReference();
      private TagReference _mainmenuUiGlobals = new TagReference();
      private TagReference _singleplayerUiGlobals = new TagReference();
      private TagReference _multiplayerUiGlobals = new TagReference();
public event System.EventHandler BlockNameChanged;
      public InterfaceTagReferencesBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_obsolete1.Value);
references.Add(_obsolete2.Value);
references.Add(_screenColorTable.Value);
references.Add(_hudColorTable.Value);
references.Add(_editorColorTable.Value);
references.Add(_dialogColorTable.Value);
references.Add(_hudGlobals.Value);
references.Add(_motionSensorSweepBitmap.Value);
references.Add(_motionSensorSweepBitmapMask.Value);
references.Add(_multiplayerHudBitmap.Value);
references.Add(_unnamed0.Value);
references.Add(_hudDigitsDefinition.Value);
references.Add(_motionSensorBlipBitmap.Value);
references.Add(_interfaceGooMap1.Value);
references.Add(_interfaceGooMap2.Value);
references.Add(_interfaceGooMap3.Value);
references.Add(_mainmenuUiGlobals.Value);
references.Add(_singleplayerUiGlobals.Value);
references.Add(_multiplayerUiGlobals.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Obsolete1 {
        get {
          return this._obsolete1;
        }
        set {
          this._obsolete1 = value;
        }
      }
      public TagReference Obsolete2 {
        get {
          return this._obsolete2;
        }
        set {
          this._obsolete2 = value;
        }
      }
      public TagReference ScreenColorTable {
        get {
          return this._screenColorTable;
        }
        set {
          this._screenColorTable = value;
        }
      }
      public TagReference HudColorTable {
        get {
          return this._hudColorTable;
        }
        set {
          this._hudColorTable = value;
        }
      }
      public TagReference EditorColorTable {
        get {
          return this._editorColorTable;
        }
        set {
          this._editorColorTable = value;
        }
      }
      public TagReference DialogColorTable {
        get {
          return this._dialogColorTable;
        }
        set {
          this._dialogColorTable = value;
        }
      }
      public TagReference HudGlobals {
        get {
          return this._hudGlobals;
        }
        set {
          this._hudGlobals = value;
        }
      }
      public TagReference MotionSensorSweepBitmap {
        get {
          return this._motionSensorSweepBitmap;
        }
        set {
          this._motionSensorSweepBitmap = value;
        }
      }
      public TagReference MotionSensorSweepBitmapMask {
        get {
          return this._motionSensorSweepBitmapMask;
        }
        set {
          this._motionSensorSweepBitmapMask = value;
        }
      }
      public TagReference MultiplayerHudBitmap {
        get {
          return this._multiplayerHudBitmap;
        }
        set {
          this._multiplayerHudBitmap = value;
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
      public TagReference HudDigitsDefinition {
        get {
          return this._hudDigitsDefinition;
        }
        set {
          this._hudDigitsDefinition = value;
        }
      }
      public TagReference MotionSensorBlipBitmap {
        get {
          return this._motionSensorBlipBitmap;
        }
        set {
          this._motionSensorBlipBitmap = value;
        }
      }
      public TagReference InterfaceGooMap1 {
        get {
          return this._interfaceGooMap1;
        }
        set {
          this._interfaceGooMap1 = value;
        }
      }
      public TagReference InterfaceGooMap2 {
        get {
          return this._interfaceGooMap2;
        }
        set {
          this._interfaceGooMap2 = value;
        }
      }
      public TagReference InterfaceGooMap3 {
        get {
          return this._interfaceGooMap3;
        }
        set {
          this._interfaceGooMap3 = value;
        }
      }
      public TagReference MainmenuUiGlobals {
        get {
          return this._mainmenuUiGlobals;
        }
        set {
          this._mainmenuUiGlobals = value;
        }
      }
      public TagReference SingleplayerUiGlobals {
        get {
          return this._singleplayerUiGlobals;
        }
        set {
          this._singleplayerUiGlobals = value;
        }
      }
      public TagReference MultiplayerUiGlobals {
        get {
          return this._multiplayerUiGlobals;
        }
        set {
          this._multiplayerUiGlobals = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _obsolete1.Read(reader);
        _obsolete2.Read(reader);
        _screenColorTable.Read(reader);
        _hudColorTable.Read(reader);
        _editorColorTable.Read(reader);
        _dialogColorTable.Read(reader);
        _hudGlobals.Read(reader);
        _motionSensorSweepBitmap.Read(reader);
        _motionSensorSweepBitmapMask.Read(reader);
        _multiplayerHudBitmap.Read(reader);
        _unnamed0.Read(reader);
        _hudDigitsDefinition.Read(reader);
        _motionSensorBlipBitmap.Read(reader);
        _interfaceGooMap1.Read(reader);
        _interfaceGooMap2.Read(reader);
        _interfaceGooMap3.Read(reader);
        _mainmenuUiGlobals.Read(reader);
        _singleplayerUiGlobals.Read(reader);
        _multiplayerUiGlobals.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _obsolete1.ReadString(reader);
        _obsolete2.ReadString(reader);
        _screenColorTable.ReadString(reader);
        _hudColorTable.ReadString(reader);
        _editorColorTable.ReadString(reader);
        _dialogColorTable.ReadString(reader);
        _hudGlobals.ReadString(reader);
        _motionSensorSweepBitmap.ReadString(reader);
        _motionSensorSweepBitmapMask.ReadString(reader);
        _multiplayerHudBitmap.ReadString(reader);
        _unnamed0.ReadString(reader);
        _hudDigitsDefinition.ReadString(reader);
        _motionSensorBlipBitmap.ReadString(reader);
        _interfaceGooMap1.ReadString(reader);
        _interfaceGooMap2.ReadString(reader);
        _interfaceGooMap3.ReadString(reader);
        _mainmenuUiGlobals.ReadString(reader);
        _singleplayerUiGlobals.ReadString(reader);
        _multiplayerUiGlobals.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _obsolete1.Write(bw);
        _obsolete2.Write(bw);
        _screenColorTable.Write(bw);
        _hudColorTable.Write(bw);
        _editorColorTable.Write(bw);
        _dialogColorTable.Write(bw);
        _hudGlobals.Write(bw);
        _motionSensorSweepBitmap.Write(bw);
        _motionSensorSweepBitmapMask.Write(bw);
        _multiplayerHudBitmap.Write(bw);
        _unnamed0.Write(bw);
        _hudDigitsDefinition.Write(bw);
        _motionSensorBlipBitmap.Write(bw);
        _interfaceGooMap1.Write(bw);
        _interfaceGooMap2.Write(bw);
        _interfaceGooMap3.Write(bw);
        _mainmenuUiGlobals.Write(bw);
        _singleplayerUiGlobals.Write(bw);
        _multiplayerUiGlobals.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _obsolete1.WriteString(writer);
        _obsolete2.WriteString(writer);
        _screenColorTable.WriteString(writer);
        _hudColorTable.WriteString(writer);
        _editorColorTable.WriteString(writer);
        _dialogColorTable.WriteString(writer);
        _hudGlobals.WriteString(writer);
        _motionSensorSweepBitmap.WriteString(writer);
        _motionSensorSweepBitmapMask.WriteString(writer);
        _multiplayerHudBitmap.WriteString(writer);
        _unnamed0.WriteString(writer);
        _hudDigitsDefinition.WriteString(writer);
        _motionSensorBlipBitmap.WriteString(writer);
        _interfaceGooMap1.WriteString(writer);
        _interfaceGooMap2.WriteString(writer);
        _interfaceGooMap3.WriteString(writer);
        _mainmenuUiGlobals.WriteString(writer);
        _singleplayerUiGlobals.WriteString(writer);
        _multiplayerUiGlobals.WriteString(writer);
      }
    }
    public class CheatWeaponsBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CheatWeaponsBlockBlock() {
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
    public class CheatPowerupsBlockBlock : IBlock {
      private TagReference _powerup = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CheatPowerupsBlockBlock() {
if (this._powerup is System.ComponentModel.INotifyPropertyChanged)
  (this._powerup as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_powerup.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _powerup.ToString();
        }
      }
      public TagReference Powerup {
        get {
          return this._powerup;
        }
        set {
          this._powerup = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _powerup.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _powerup.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _powerup.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _powerup.WriteString(writer);
      }
    }
    public class MultiplayerInformationBlockBlock : IBlock {
      private TagReference _flag = new TagReference();
      private TagReference _unit = new TagReference();
      private Block _vehicles = new Block();
      private TagReference _hillShader = new TagReference();
      private TagReference _flagShader = new TagReference();
      private TagReference _ball = new TagReference();
      private Block _sounds = new Block();
      private TagReference _inGameText = new TagReference();
      private Pad _unnamed0;
      private Block _generalEvents = new Block();
      private Block _slayerEvents = new Block();
      private Block _ctfEvents = new Block();
      private Block _oddballEvents = new Block();
      private Block _unnamed1 = new Block();
      private Block _kingEvents = new Block();
      public BlockCollection<VehiclesBlockBlock> _vehiclesList = new BlockCollection<VehiclesBlockBlock>();
      public BlockCollection<SoundsBlockBlock> _soundsList = new BlockCollection<SoundsBlockBlock>();
      public BlockCollection<GameEngineGeneralEventBlockBlock> _generalEventsList = new BlockCollection<GameEngineGeneralEventBlockBlock>();
      public BlockCollection<GameEngineSlayerEventBlockBlock> _slayerEventsList = new BlockCollection<GameEngineSlayerEventBlockBlock>();
      public BlockCollection<GameEngineCtfEventBlockBlock> _ctfEventsList = new BlockCollection<GameEngineCtfEventBlockBlock>();
      public BlockCollection<GameEngineOddballEventBlockBlock> _oddballEventsList = new BlockCollection<GameEngineOddballEventBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed1List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GameEngineKingEventBlockBlock> _kingEventsList = new BlockCollection<GameEngineKingEventBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerInformationBlockBlock() {
        this._unnamed0 = new Pad(40);
      }
      public BlockCollection<VehiclesBlockBlock> Vehicles {
        get {
          return this._vehiclesList;
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
      public BlockCollection<GNullBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public BlockCollection<GameEngineKingEventBlockBlock> KingEvents {
        get {
          return this._kingEventsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_flag.Value);
references.Add(_unit.Value);
references.Add(_hillShader.Value);
references.Add(_flagShader.Value);
references.Add(_ball.Value);
references.Add(_inGameText.Value);
for (int x=0; x<Vehicles.BlockCount; x++)
{
  IBlock block = Vehicles.GetBlock(x);
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
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<KingEvents.BlockCount; x++)
{
  IBlock block = KingEvents.GetBlock(x);
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
      public TagReference Unit {
        get {
          return this._unit;
        }
        set {
          this._unit = value;
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
      public TagReference FlagShader {
        get {
          return this._flagShader;
        }
        set {
          this._flagShader = value;
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
      public TagReference InGameText {
        get {
          return this._inGameText;
        }
        set {
          this._inGameText = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flag.Read(reader);
        _unit.Read(reader);
        _vehicles.Read(reader);
        _hillShader.Read(reader);
        _flagShader.Read(reader);
        _ball.Read(reader);
        _sounds.Read(reader);
        _inGameText.Read(reader);
        _unnamed0.Read(reader);
        _generalEvents.Read(reader);
        _slayerEvents.Read(reader);
        _ctfEvents.Read(reader);
        _oddballEvents.Read(reader);
        _unnamed1.Read(reader);
        _kingEvents.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _flag.ReadString(reader);
        _unit.ReadString(reader);
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles.Add(new VehiclesBlockBlock());
          Vehicles[x].Read(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].ReadChildData(reader);
        }
        _hillShader.ReadString(reader);
        _flagShader.ReadString(reader);
        _ball.ReadString(reader);
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new SoundsBlockBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        _inGameText.ReadString(reader);
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents.Add(new GameEngineGeneralEventBlockBlock());
          GeneralEvents[x].Read(reader);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].ReadChildData(reader);
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
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new GNullBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents.Add(new GameEngineKingEventBlockBlock());
          KingEvents[x].Read(reader);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flag.Write(bw);
        _unit.Write(bw);
_vehicles.Count = Vehicles.Count;
        _vehicles.Write(bw);
        _hillShader.Write(bw);
        _flagShader.Write(bw);
        _ball.Write(bw);
_sounds.Count = Sounds.Count;
        _sounds.Write(bw);
        _inGameText.Write(bw);
        _unnamed0.Write(bw);
_generalEvents.Count = GeneralEvents.Count;
        _generalEvents.Write(bw);
_slayerEvents.Count = SlayerEvents.Count;
        _slayerEvents.Write(bw);
_ctfEvents.Count = CtfEvents.Count;
        _ctfEvents.Write(bw);
_oddballEvents.Count = OddballEvents.Count;
        _oddballEvents.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
_kingEvents.Count = KingEvents.Count;
        _kingEvents.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _flag.WriteString(writer);
        _unit.WriteString(writer);
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].Write(writer);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].WriteChildData(writer);
        }
        _hillShader.WriteString(writer);
        _flagShader.WriteString(writer);
        _ball.WriteString(writer);
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].Write(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].WriteChildData(writer);
        }
        _inGameText.WriteString(writer);
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].Write(writer);
        }
        for (x = 0; (x < _generalEvents.Count); x = (x + 1)) {
          GeneralEvents[x].WriteChildData(writer);
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
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].Write(writer);
        }
        for (x = 0; (x < _kingEvents.Count); x = (x + 1)) {
          KingEvents[x].WriteChildData(writer);
        }
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
    public class PlayerInformationBlockBlock : IBlock {
      private TagReference _unused = new TagReference();
      private Pad _unnamed0;
      private Real _walkingSpeed = new Real();
      private Pad _unnamed1;
      private Real _runForward = new Real();
      private Real _runBackward = new Real();
      private Real _runSideways = new Real();
      private Real _runAcceleration = new Real();
      private Real _sneakForward = new Real();
      private Real _sneakBackward = new Real();
      private Real _sneakSideways = new Real();
      private Real _sneakAcceleration = new Real();
      private Real _airborneAcceleration = new Real();
      private Pad _unnamed2;
      private RealPoint3D _grenadeOrigin = new RealPoint3D();
      private Pad _unnamed3;
      private Real _stunMovementPenalty = new Real();
      private Real _stunTurningPenalty = new Real();
      private Real _stunJumpingPenalty = new Real();
      private Real _minimumStunTime = new Real();
      private Real _maximumStunTime = new Real();
      private Pad _unnamed4;
      private RealBounds _firstPersonIdleTime = new RealBounds();
      private RealFraction _firstPersonSkipFraction = new RealFraction();
      private Pad _unnamed5;
      private TagReference _coopRespawnEffect = new TagReference();
      private LongInteger _binocularsZoomCount = new LongInteger();
      private RealBounds _binocularsZoomRange = new RealBounds();
      private TagReference _binocularsZoomInSound = new TagReference();
      private TagReference _binocularsZoomOutSound = new TagReference();
      private Pad _unnamed6;
      private TagReference _activeCamouflageOn = new TagReference();
      private TagReference _activeCamouflageOff = new TagReference();
      private TagReference _activeCamouflageError = new TagReference();
      private TagReference _activeCamouflageReady = new TagReference();
      private TagReference _flashlightOn = new TagReference();
      private TagReference _flashlightOff = new TagReference();
      private TagReference _iceCream = new TagReference();
public event System.EventHandler BlockNameChanged;
      public PlayerInformationBlockBlock() {
        this._unnamed0 = new Pad(28);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unused.Value);
references.Add(_coopRespawnEffect.Value);
references.Add(_binocularsZoomInSound.Value);
references.Add(_binocularsZoomOutSound.Value);
references.Add(_activeCamouflageOn.Value);
references.Add(_activeCamouflageOff.Value);
references.Add(_activeCamouflageError.Value);
references.Add(_activeCamouflageReady.Value);
references.Add(_flashlightOn.Value);
references.Add(_flashlightOff.Value);
references.Add(_iceCream.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Unused {
        get {
          return this._unused;
        }
        set {
          this._unused = value;
        }
      }
      public Real WalkingSpeed {
        get {
          return this._walkingSpeed;
        }
        set {
          this._walkingSpeed = value;
        }
      }
      public Real RunForward {
        get {
          return this._runForward;
        }
        set {
          this._runForward = value;
        }
      }
      public Real RunBackward {
        get {
          return this._runBackward;
        }
        set {
          this._runBackward = value;
        }
      }
      public Real RunSideways {
        get {
          return this._runSideways;
        }
        set {
          this._runSideways = value;
        }
      }
      public Real RunAcceleration {
        get {
          return this._runAcceleration;
        }
        set {
          this._runAcceleration = value;
        }
      }
      public Real SneakForward {
        get {
          return this._sneakForward;
        }
        set {
          this._sneakForward = value;
        }
      }
      public Real SneakBackward {
        get {
          return this._sneakBackward;
        }
        set {
          this._sneakBackward = value;
        }
      }
      public Real SneakSideways {
        get {
          return this._sneakSideways;
        }
        set {
          this._sneakSideways = value;
        }
      }
      public Real SneakAcceleration {
        get {
          return this._sneakAcceleration;
        }
        set {
          this._sneakAcceleration = value;
        }
      }
      public Real AirborneAcceleration {
        get {
          return this._airborneAcceleration;
        }
        set {
          this._airborneAcceleration = value;
        }
      }
      public RealPoint3D GrenadeOrigin {
        get {
          return this._grenadeOrigin;
        }
        set {
          this._grenadeOrigin = value;
        }
      }
      public Real StunMovementPenalty {
        get {
          return this._stunMovementPenalty;
        }
        set {
          this._stunMovementPenalty = value;
        }
      }
      public Real StunTurningPenalty {
        get {
          return this._stunTurningPenalty;
        }
        set {
          this._stunTurningPenalty = value;
        }
      }
      public Real StunJumpingPenalty {
        get {
          return this._stunJumpingPenalty;
        }
        set {
          this._stunJumpingPenalty = value;
        }
      }
      public Real MinimumStunTime {
        get {
          return this._minimumStunTime;
        }
        set {
          this._minimumStunTime = value;
        }
      }
      public Real MaximumStunTime {
        get {
          return this._maximumStunTime;
        }
        set {
          this._maximumStunTime = value;
        }
      }
      public RealBounds FirstPersonIdleTime {
        get {
          return this._firstPersonIdleTime;
        }
        set {
          this._firstPersonIdleTime = value;
        }
      }
      public RealFraction FirstPersonSkipFraction {
        get {
          return this._firstPersonSkipFraction;
        }
        set {
          this._firstPersonSkipFraction = value;
        }
      }
      public TagReference CoopRespawnEffect {
        get {
          return this._coopRespawnEffect;
        }
        set {
          this._coopRespawnEffect = value;
        }
      }
      public LongInteger BinocularsZoomCount {
        get {
          return this._binocularsZoomCount;
        }
        set {
          this._binocularsZoomCount = value;
        }
      }
      public RealBounds BinocularsZoomRange {
        get {
          return this._binocularsZoomRange;
        }
        set {
          this._binocularsZoomRange = value;
        }
      }
      public TagReference BinocularsZoomInSound {
        get {
          return this._binocularsZoomInSound;
        }
        set {
          this._binocularsZoomInSound = value;
        }
      }
      public TagReference BinocularsZoomOutSound {
        get {
          return this._binocularsZoomOutSound;
        }
        set {
          this._binocularsZoomOutSound = value;
        }
      }
      public TagReference ActiveCamouflageOn {
        get {
          return this._activeCamouflageOn;
        }
        set {
          this._activeCamouflageOn = value;
        }
      }
      public TagReference ActiveCamouflageOff {
        get {
          return this._activeCamouflageOff;
        }
        set {
          this._activeCamouflageOff = value;
        }
      }
      public TagReference ActiveCamouflageError {
        get {
          return this._activeCamouflageError;
        }
        set {
          this._activeCamouflageError = value;
        }
      }
      public TagReference ActiveCamouflageReady {
        get {
          return this._activeCamouflageReady;
        }
        set {
          this._activeCamouflageReady = value;
        }
      }
      public TagReference FlashlightOn {
        get {
          return this._flashlightOn;
        }
        set {
          this._flashlightOn = value;
        }
      }
      public TagReference FlashlightOff {
        get {
          return this._flashlightOff;
        }
        set {
          this._flashlightOff = value;
        }
      }
      public TagReference IceCream {
        get {
          return this._iceCream;
        }
        set {
          this._iceCream = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unused.Read(reader);
        _unnamed0.Read(reader);
        _walkingSpeed.Read(reader);
        _unnamed1.Read(reader);
        _runForward.Read(reader);
        _runBackward.Read(reader);
        _runSideways.Read(reader);
        _runAcceleration.Read(reader);
        _sneakForward.Read(reader);
        _sneakBackward.Read(reader);
        _sneakSideways.Read(reader);
        _sneakAcceleration.Read(reader);
        _airborneAcceleration.Read(reader);
        _unnamed2.Read(reader);
        _grenadeOrigin.Read(reader);
        _unnamed3.Read(reader);
        _stunMovementPenalty.Read(reader);
        _stunTurningPenalty.Read(reader);
        _stunJumpingPenalty.Read(reader);
        _minimumStunTime.Read(reader);
        _maximumStunTime.Read(reader);
        _unnamed4.Read(reader);
        _firstPersonIdleTime.Read(reader);
        _firstPersonSkipFraction.Read(reader);
        _unnamed5.Read(reader);
        _coopRespawnEffect.Read(reader);
        _binocularsZoomCount.Read(reader);
        _binocularsZoomRange.Read(reader);
        _binocularsZoomInSound.Read(reader);
        _binocularsZoomOutSound.Read(reader);
        _unnamed6.Read(reader);
        _activeCamouflageOn.Read(reader);
        _activeCamouflageOff.Read(reader);
        _activeCamouflageError.Read(reader);
        _activeCamouflageReady.Read(reader);
        _flashlightOn.Read(reader);
        _flashlightOff.Read(reader);
        _iceCream.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unused.ReadString(reader);
        _coopRespawnEffect.ReadString(reader);
        _binocularsZoomInSound.ReadString(reader);
        _binocularsZoomOutSound.ReadString(reader);
        _activeCamouflageOn.ReadString(reader);
        _activeCamouflageOff.ReadString(reader);
        _activeCamouflageError.ReadString(reader);
        _activeCamouflageReady.ReadString(reader);
        _flashlightOn.ReadString(reader);
        _flashlightOff.ReadString(reader);
        _iceCream.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unused.Write(bw);
        _unnamed0.Write(bw);
        _walkingSpeed.Write(bw);
        _unnamed1.Write(bw);
        _runForward.Write(bw);
        _runBackward.Write(bw);
        _runSideways.Write(bw);
        _runAcceleration.Write(bw);
        _sneakForward.Write(bw);
        _sneakBackward.Write(bw);
        _sneakSideways.Write(bw);
        _sneakAcceleration.Write(bw);
        _airborneAcceleration.Write(bw);
        _unnamed2.Write(bw);
        _grenadeOrigin.Write(bw);
        _unnamed3.Write(bw);
        _stunMovementPenalty.Write(bw);
        _stunTurningPenalty.Write(bw);
        _stunJumpingPenalty.Write(bw);
        _minimumStunTime.Write(bw);
        _maximumStunTime.Write(bw);
        _unnamed4.Write(bw);
        _firstPersonIdleTime.Write(bw);
        _firstPersonSkipFraction.Write(bw);
        _unnamed5.Write(bw);
        _coopRespawnEffect.Write(bw);
        _binocularsZoomCount.Write(bw);
        _binocularsZoomRange.Write(bw);
        _binocularsZoomInSound.Write(bw);
        _binocularsZoomOutSound.Write(bw);
        _unnamed6.Write(bw);
        _activeCamouflageOn.Write(bw);
        _activeCamouflageOff.Write(bw);
        _activeCamouflageError.Write(bw);
        _activeCamouflageReady.Write(bw);
        _flashlightOn.Write(bw);
        _flashlightOff.Write(bw);
        _iceCream.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unused.WriteString(writer);
        _coopRespawnEffect.WriteString(writer);
        _binocularsZoomInSound.WriteString(writer);
        _binocularsZoomOutSound.WriteString(writer);
        _activeCamouflageOn.WriteString(writer);
        _activeCamouflageOff.WriteString(writer);
        _activeCamouflageError.WriteString(writer);
        _activeCamouflageReady.WriteString(writer);
        _flashlightOn.WriteString(writer);
        _flashlightOff.WriteString(writer);
        _iceCream.WriteString(writer);
      }
    }
    public class PlayerRepresentationBlockBlock : IBlock {
      private TagReference _firstPersonHands = new TagReference();
      private TagReference _firstPersonBody = new TagReference();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private TagReference _thirdPersonUnit = new TagReference();
      private StringId _thirdPersonVariant = new StringId();
public event System.EventHandler BlockNameChanged;
      public PlayerRepresentationBlockBlock() {
        this._unnamed0 = new Pad(40);
        this._unnamed1 = new Pad(120);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_firstPersonHands.Value);
references.Add(_firstPersonBody.Value);
references.Add(_thirdPersonUnit.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference FirstPersonHands {
        get {
          return this._firstPersonHands;
        }
        set {
          this._firstPersonHands = value;
        }
      }
      public TagReference FirstPersonBody {
        get {
          return this._firstPersonBody;
        }
        set {
          this._firstPersonBody = value;
        }
      }
      public TagReference ThirdPersonUnit {
        get {
          return this._thirdPersonUnit;
        }
        set {
          this._thirdPersonUnit = value;
        }
      }
      public StringId ThirdPersonVariant {
        get {
          return this._thirdPersonVariant;
        }
        set {
          this._thirdPersonVariant = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _firstPersonHands.Read(reader);
        _firstPersonBody.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _thirdPersonUnit.Read(reader);
        _thirdPersonVariant.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _firstPersonHands.ReadString(reader);
        _firstPersonBody.ReadString(reader);
        _thirdPersonUnit.ReadString(reader);
        _thirdPersonVariant.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _firstPersonHands.Write(bw);
        _firstPersonBody.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _thirdPersonUnit.Write(bw);
        _thirdPersonVariant.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _firstPersonHands.WriteString(writer);
        _firstPersonBody.WriteString(writer);
        _thirdPersonUnit.WriteString(writer);
        _thirdPersonVariant.WriteString(writer);
      }
    }
    public class FallingDamageBlockBlock : IBlock {
      private Pad _unnamed0;
      private RealBounds _harmfulFallingDistance = new RealBounds();
      private TagReference _fallingDamage = new TagReference();
      private Pad _unnamed1;
      private Real _maximumFallingDistance = new Real();
      private TagReference _distanceDamage = new TagReference();
      private TagReference _vehicleEnvironemtnCollisionDamageEffect = new TagReference();
      private TagReference _vehicleKilledUnitDamageEffect = new TagReference();
      private TagReference _vehicleCollisionDamage = new TagReference();
      private TagReference _flamingDeathDamage = new TagReference();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public FallingDamageBlockBlock() {
        this._unnamed0 = new Pad(8);
        this._unnamed1 = new Pad(8);
        this._unnamed2 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_fallingDamage.Value);
references.Add(_distanceDamage.Value);
references.Add(_vehicleEnvironemtnCollisionDamageEffect.Value);
references.Add(_vehicleKilledUnitDamageEffect.Value);
references.Add(_vehicleCollisionDamage.Value);
references.Add(_flamingDeathDamage.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealBounds HarmfulFallingDistance {
        get {
          return this._harmfulFallingDistance;
        }
        set {
          this._harmfulFallingDistance = value;
        }
      }
      public TagReference FallingDamage {
        get {
          return this._fallingDamage;
        }
        set {
          this._fallingDamage = value;
        }
      }
      public Real MaximumFallingDistance {
        get {
          return this._maximumFallingDistance;
        }
        set {
          this._maximumFallingDistance = value;
        }
      }
      public TagReference DistanceDamage {
        get {
          return this._distanceDamage;
        }
        set {
          this._distanceDamage = value;
        }
      }
      public TagReference VehicleEnvironemtnCollisionDamageEffect {
        get {
          return this._vehicleEnvironemtnCollisionDamageEffect;
        }
        set {
          this._vehicleEnvironemtnCollisionDamageEffect = value;
        }
      }
      public TagReference VehicleKilledUnitDamageEffect {
        get {
          return this._vehicleKilledUnitDamageEffect;
        }
        set {
          this._vehicleKilledUnitDamageEffect = value;
        }
      }
      public TagReference VehicleCollisionDamage {
        get {
          return this._vehicleCollisionDamage;
        }
        set {
          this._vehicleCollisionDamage = value;
        }
      }
      public TagReference FlamingDeathDamage {
        get {
          return this._flamingDeathDamage;
        }
        set {
          this._flamingDeathDamage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _harmfulFallingDistance.Read(reader);
        _fallingDamage.Read(reader);
        _unnamed1.Read(reader);
        _maximumFallingDistance.Read(reader);
        _distanceDamage.Read(reader);
        _vehicleEnvironemtnCollisionDamageEffect.Read(reader);
        _vehicleKilledUnitDamageEffect.Read(reader);
        _vehicleCollisionDamage.Read(reader);
        _flamingDeathDamage.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _fallingDamage.ReadString(reader);
        _distanceDamage.ReadString(reader);
        _vehicleEnvironemtnCollisionDamageEffect.ReadString(reader);
        _vehicleKilledUnitDamageEffect.ReadString(reader);
        _vehicleCollisionDamage.ReadString(reader);
        _flamingDeathDamage.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _harmfulFallingDistance.Write(bw);
        _fallingDamage.Write(bw);
        _unnamed1.Write(bw);
        _maximumFallingDistance.Write(bw);
        _distanceDamage.Write(bw);
        _vehicleEnvironemtnCollisionDamageEffect.Write(bw);
        _vehicleKilledUnitDamageEffect.Write(bw);
        _vehicleCollisionDamage.Write(bw);
        _flamingDeathDamage.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _fallingDamage.WriteString(writer);
        _distanceDamage.WriteString(writer);
        _vehicleEnvironemtnCollisionDamageEffect.WriteString(writer);
        _vehicleKilledUnitDamageEffect.WriteString(writer);
        _vehicleCollisionDamage.WriteString(writer);
        _flamingDeathDamage.WriteString(writer);
      }
    }
    public class OldMaterialsBlockBlock : IBlock {
      private StringId _newMaterialName = new StringId();
      private StringId _newGeneralMaterialName = new StringId();
      private Real _groundFrictionScale = new Real();
      private Real _groundFrictionNormalK1Scale = new Real();
      private Real _groundFrictionNormalK0Scale = new Real();
      private Real _groundDepthScale = new Real();
      private Real _groundDampFractionScale = new Real();
      private TagReference _meleeHitSound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public OldMaterialsBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_meleeHitSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public StringId NewMaterialName {
        get {
          return this._newMaterialName;
        }
        set {
          this._newMaterialName = value;
        }
      }
      public StringId NewGeneralMaterialName {
        get {
          return this._newGeneralMaterialName;
        }
        set {
          this._newGeneralMaterialName = value;
        }
      }
      public Real GroundFrictionScale {
        get {
          return this._groundFrictionScale;
        }
        set {
          this._groundFrictionScale = value;
        }
      }
      public Real GroundFrictionNormalK1Scale {
        get {
          return this._groundFrictionNormalK1Scale;
        }
        set {
          this._groundFrictionNormalK1Scale = value;
        }
      }
      public Real GroundFrictionNormalK0Scale {
        get {
          return this._groundFrictionNormalK0Scale;
        }
        set {
          this._groundFrictionNormalK0Scale = value;
        }
      }
      public Real GroundDepthScale {
        get {
          return this._groundDepthScale;
        }
        set {
          this._groundDepthScale = value;
        }
      }
      public Real GroundDampFractionScale {
        get {
          return this._groundDampFractionScale;
        }
        set {
          this._groundDampFractionScale = value;
        }
      }
      public TagReference MeleeHitSound {
        get {
          return this._meleeHitSound;
        }
        set {
          this._meleeHitSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _newMaterialName.Read(reader);
        _newGeneralMaterialName.Read(reader);
        _groundFrictionScale.Read(reader);
        _groundFrictionNormalK1Scale.Read(reader);
        _groundFrictionNormalK0Scale.Read(reader);
        _groundDepthScale.Read(reader);
        _groundDampFractionScale.Read(reader);
        _meleeHitSound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _newMaterialName.ReadString(reader);
        _newGeneralMaterialName.ReadString(reader);
        _meleeHitSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _newMaterialName.Write(bw);
        _newGeneralMaterialName.Write(bw);
        _groundFrictionScale.Write(bw);
        _groundFrictionNormalK1Scale.Write(bw);
        _groundFrictionNormalK0Scale.Write(bw);
        _groundDepthScale.Write(bw);
        _groundDampFractionScale.Write(bw);
        _meleeHitSound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _newMaterialName.WriteString(writer);
        _newGeneralMaterialName.WriteString(writer);
        _meleeHitSound.WriteString(writer);
      }
    }
    public class MaterialsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private StringId _parentName = new StringId();
      private Pad _unnamed0;
      private Flags _flags;
      private Enum _oldMaterialType;
      private Pad _unnamed1;
      private StringId _generalArmor = new StringId();
      private StringId _specificArmor = new StringId();
      private Pad _unnamed2;
      private Real _friction = new Real();
      private RealFraction _restitution = new RealFraction();
      private Real _density = new Real();
      private TagReference _oldMaterialPhysics = new TagReference();
      private TagReference _breakableSurface = new TagReference();
      private TagReference _soundSweetenerSmall = new TagReference();
      private TagReference _soundSweetenerMedium = new TagReference();
      private TagReference _soundSweetenerLarge = new TagReference();
      private TagReference _soundSweetenerRolling = new TagReference();
      private TagReference _soundSweetenerGrinding = new TagReference();
      private TagReference _soundSweetenerMelee = new TagReference();
      private TagReference _unnamed3 = new TagReference();
      private TagReference _effectSweetenerSmall = new TagReference();
      private TagReference _effectSweetenerMedium = new TagReference();
      private TagReference _effectSweetenerLarge = new TagReference();
      private TagReference _effectSweetenerRolling = new TagReference();
      private TagReference _effectSweetenerGrinding = new TagReference();
      private TagReference _effectSweetenerMelee = new TagReference();
      private TagReference _unnamed4 = new TagReference();
      private Flags _sweetenerInheritanceFlags;
      private TagReference _materialEffects = new TagReference();
public event System.EventHandler BlockNameChanged;
      public MaterialsBlockBlock() {
if (this._density is System.ComponentModel.INotifyPropertyChanged)
  (this._density as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
        this._oldMaterialType = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._sweetenerInheritanceFlags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_oldMaterialPhysics.Value);
references.Add(_breakableSurface.Value);
references.Add(_soundSweetenerSmall.Value);
references.Add(_soundSweetenerMedium.Value);
references.Add(_soundSweetenerLarge.Value);
references.Add(_soundSweetenerRolling.Value);
references.Add(_soundSweetenerGrinding.Value);
references.Add(_soundSweetenerMelee.Value);
references.Add(_unnamed3.Value);
references.Add(_effectSweetenerSmall.Value);
references.Add(_effectSweetenerMedium.Value);
references.Add(_effectSweetenerLarge.Value);
references.Add(_effectSweetenerRolling.Value);
references.Add(_effectSweetenerGrinding.Value);
references.Add(_effectSweetenerMelee.Value);
references.Add(_unnamed4.Value);
references.Add(_materialEffects.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _density.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public StringId ParentName {
        get {
          return this._parentName;
        }
        set {
          this._parentName = value;
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
      public Enum OldMaterialType {
        get {
          return this._oldMaterialType;
        }
        set {
          this._oldMaterialType = value;
        }
      }
      public StringId GeneralArmor {
        get {
          return this._generalArmor;
        }
        set {
          this._generalArmor = value;
        }
      }
      public StringId SpecificArmor {
        get {
          return this._specificArmor;
        }
        set {
          this._specificArmor = value;
        }
      }
      public Real Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public TagReference OldMaterialPhysics {
        get {
          return this._oldMaterialPhysics;
        }
        set {
          this._oldMaterialPhysics = value;
        }
      }
      public TagReference BreakableSurface {
        get {
          return this._breakableSurface;
        }
        set {
          this._breakableSurface = value;
        }
      }
      public TagReference SoundSweetenerSmall {
        get {
          return this._soundSweetenerSmall;
        }
        set {
          this._soundSweetenerSmall = value;
        }
      }
      public TagReference SoundSweetenerMedium {
        get {
          return this._soundSweetenerMedium;
        }
        set {
          this._soundSweetenerMedium = value;
        }
      }
      public TagReference SoundSweetenerLarge {
        get {
          return this._soundSweetenerLarge;
        }
        set {
          this._soundSweetenerLarge = value;
        }
      }
      public TagReference SoundSweetenerRolling {
        get {
          return this._soundSweetenerRolling;
        }
        set {
          this._soundSweetenerRolling = value;
        }
      }
      public TagReference SoundSweetenerGrinding {
        get {
          return this._soundSweetenerGrinding;
        }
        set {
          this._soundSweetenerGrinding = value;
        }
      }
      public TagReference SoundSweetenerMelee {
        get {
          return this._soundSweetenerMelee;
        }
        set {
          this._soundSweetenerMelee = value;
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
      public TagReference EffectSweetenerSmall {
        get {
          return this._effectSweetenerSmall;
        }
        set {
          this._effectSweetenerSmall = value;
        }
      }
      public TagReference EffectSweetenerMedium {
        get {
          return this._effectSweetenerMedium;
        }
        set {
          this._effectSweetenerMedium = value;
        }
      }
      public TagReference EffectSweetenerLarge {
        get {
          return this._effectSweetenerLarge;
        }
        set {
          this._effectSweetenerLarge = value;
        }
      }
      public TagReference EffectSweetenerRolling {
        get {
          return this._effectSweetenerRolling;
        }
        set {
          this._effectSweetenerRolling = value;
        }
      }
      public TagReference EffectSweetenerGrinding {
        get {
          return this._effectSweetenerGrinding;
        }
        set {
          this._effectSweetenerGrinding = value;
        }
      }
      public TagReference EffectSweetenerMelee {
        get {
          return this._effectSweetenerMelee;
        }
        set {
          this._effectSweetenerMelee = value;
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
      public Flags SweetenerInheritanceFlags {
        get {
          return this._sweetenerInheritanceFlags;
        }
        set {
          this._sweetenerInheritanceFlags = value;
        }
      }
      public TagReference MaterialEffects {
        get {
          return this._materialEffects;
        }
        set {
          this._materialEffects = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parentName.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _oldMaterialType.Read(reader);
        _unnamed1.Read(reader);
        _generalArmor.Read(reader);
        _specificArmor.Read(reader);
        _unnamed2.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _density.Read(reader);
        _oldMaterialPhysics.Read(reader);
        _breakableSurface.Read(reader);
        _soundSweetenerSmall.Read(reader);
        _soundSweetenerMedium.Read(reader);
        _soundSweetenerLarge.Read(reader);
        _soundSweetenerRolling.Read(reader);
        _soundSweetenerGrinding.Read(reader);
        _soundSweetenerMelee.Read(reader);
        _unnamed3.Read(reader);
        _effectSweetenerSmall.Read(reader);
        _effectSweetenerMedium.Read(reader);
        _effectSweetenerLarge.Read(reader);
        _effectSweetenerRolling.Read(reader);
        _effectSweetenerGrinding.Read(reader);
        _effectSweetenerMelee.Read(reader);
        _unnamed4.Read(reader);
        _sweetenerInheritanceFlags.Read(reader);
        _materialEffects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _parentName.ReadString(reader);
        _generalArmor.ReadString(reader);
        _specificArmor.ReadString(reader);
        _oldMaterialPhysics.ReadString(reader);
        _breakableSurface.ReadString(reader);
        _soundSweetenerSmall.ReadString(reader);
        _soundSweetenerMedium.ReadString(reader);
        _soundSweetenerLarge.ReadString(reader);
        _soundSweetenerRolling.ReadString(reader);
        _soundSweetenerGrinding.ReadString(reader);
        _soundSweetenerMelee.ReadString(reader);
        _unnamed3.ReadString(reader);
        _effectSweetenerSmall.ReadString(reader);
        _effectSweetenerMedium.ReadString(reader);
        _effectSweetenerLarge.ReadString(reader);
        _effectSweetenerRolling.ReadString(reader);
        _effectSweetenerGrinding.ReadString(reader);
        _effectSweetenerMelee.ReadString(reader);
        _unnamed4.ReadString(reader);
        _materialEffects.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _parentName.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _oldMaterialType.Write(bw);
        _unnamed1.Write(bw);
        _generalArmor.Write(bw);
        _specificArmor.Write(bw);
        _unnamed2.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _density.Write(bw);
        _oldMaterialPhysics.Write(bw);
        _breakableSurface.Write(bw);
        _soundSweetenerSmall.Write(bw);
        _soundSweetenerMedium.Write(bw);
        _soundSweetenerLarge.Write(bw);
        _soundSweetenerRolling.Write(bw);
        _soundSweetenerGrinding.Write(bw);
        _soundSweetenerMelee.Write(bw);
        _unnamed3.Write(bw);
        _effectSweetenerSmall.Write(bw);
        _effectSweetenerMedium.Write(bw);
        _effectSweetenerLarge.Write(bw);
        _effectSweetenerRolling.Write(bw);
        _effectSweetenerGrinding.Write(bw);
        _effectSweetenerMelee.Write(bw);
        _unnamed4.Write(bw);
        _sweetenerInheritanceFlags.Write(bw);
        _materialEffects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _parentName.WriteString(writer);
        _generalArmor.WriteString(writer);
        _specificArmor.WriteString(writer);
        _oldMaterialPhysics.WriteString(writer);
        _breakableSurface.WriteString(writer);
        _soundSweetenerSmall.WriteString(writer);
        _soundSweetenerMedium.WriteString(writer);
        _soundSweetenerLarge.WriteString(writer);
        _soundSweetenerRolling.WriteString(writer);
        _soundSweetenerGrinding.WriteString(writer);
        _soundSweetenerMelee.WriteString(writer);
        _unnamed3.WriteString(writer);
        _effectSweetenerSmall.WriteString(writer);
        _effectSweetenerMedium.WriteString(writer);
        _effectSweetenerLarge.WriteString(writer);
        _effectSweetenerRolling.WriteString(writer);
        _effectSweetenerGrinding.WriteString(writer);
        _effectSweetenerMelee.WriteString(writer);
        _unnamed4.WriteString(writer);
        _materialEffects.WriteString(writer);
      }
    }
    public class MultiplayerUiBlockBlock : IBlock {
      private TagReference _randomPlayerNames = new TagReference();
      private Block _obsoleteProfileColors = new Block();
      private Block _teamColors = new Block();
      private TagReference _teamNames = new TagReference();
      public BlockCollection<MultiplayerColorBlockBlock> _obsoleteProfileColorsList = new BlockCollection<MultiplayerColorBlockBlock>();
      public BlockCollection<MultiplayerColorBlockBlock> _teamColorsList = new BlockCollection<MultiplayerColorBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerUiBlockBlock() {
      }
      public BlockCollection<MultiplayerColorBlockBlock> ObsoleteProfileColors {
        get {
          return this._obsoleteProfileColorsList;
        }
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
for (int x=0; x<ObsoleteProfileColors.BlockCount; x++)
{
  IBlock block = ObsoleteProfileColors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public virtual void Read(BinaryReader reader) {
        _randomPlayerNames.Read(reader);
        _obsoleteProfileColors.Read(reader);
        _teamColors.Read(reader);
        _teamNames.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _randomPlayerNames.ReadString(reader);
        for (x = 0; (x < _obsoleteProfileColors.Count); x = (x + 1)) {
          ObsoleteProfileColors.Add(new MultiplayerColorBlockBlock());
          ObsoleteProfileColors[x].Read(reader);
        }
        for (x = 0; (x < _obsoleteProfileColors.Count); x = (x + 1)) {
          ObsoleteProfileColors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors.Add(new MultiplayerColorBlockBlock());
          TeamColors[x].Read(reader);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].ReadChildData(reader);
        }
        _teamNames.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _randomPlayerNames.Write(bw);
_obsoleteProfileColors.Count = ObsoleteProfileColors.Count;
        _obsoleteProfileColors.Write(bw);
_teamColors.Count = TeamColors.Count;
        _teamColors.Write(bw);
        _teamNames.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _randomPlayerNames.WriteString(writer);
        for (x = 0; (x < _obsoleteProfileColors.Count); x = (x + 1)) {
          ObsoleteProfileColors[x].Write(writer);
        }
        for (x = 0; (x < _obsoleteProfileColors.Count); x = (x + 1)) {
          ObsoleteProfileColors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].Write(writer);
        }
        for (x = 0; (x < _teamColors.Count); x = (x + 1)) {
          TeamColors[x].WriteChildData(writer);
        }
        _teamNames.WriteString(writer);
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
    public class RuntimeLevelsDefinitionBlockBlock : IBlock {
      private Block _campaignLevels = new Block();
      public BlockCollection<RuntimeCampaignLevelBlockBlock> _campaignLevelsList = new BlockCollection<RuntimeCampaignLevelBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RuntimeLevelsDefinitionBlockBlock() {
      }
      public BlockCollection<RuntimeCampaignLevelBlockBlock> CampaignLevels {
        get {
          return this._campaignLevelsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CampaignLevels.BlockCount; x++)
{
  IBlock block = CampaignLevels.GetBlock(x);
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
        _campaignLevels.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels.Add(new RuntimeCampaignLevelBlockBlock());
          CampaignLevels[x].Read(reader);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_campaignLevels.Count = CampaignLevels.Count;
        _campaignLevels.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].Write(writer);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].WriteChildData(writer);
        }
      }
    }
    public class RuntimeCampaignLevelBlockBlock : IBlock {
      private LongInteger _campaignID = new LongInteger();
      private LongInteger _mapID = new LongInteger();
      private LongerFixedLengthString _path = new LongerFixedLengthString();
public event System.EventHandler BlockNameChanged;
      public RuntimeCampaignLevelBlockBlock() {
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
      public LongInteger CampaignID {
        get {
          return this._campaignID;
        }
        set {
          this._campaignID = value;
        }
      }
      public LongInteger MapID {
        get {
          return this._mapID;
        }
        set {
          this._mapID = value;
        }
      }
      public LongerFixedLengthString Path {
        get {
          return this._path;
        }
        set {
          this._path = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _campaignID.Read(reader);
        _mapID.Read(reader);
        _path.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _campaignID.Write(bw);
        _mapID.Write(bw);
        _path.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UiLevelsDefinitionBlockBlock : IBlock {
      private Block _campaigns = new Block();
      private Block _campaignLevels = new Block();
      private Block _multiplayerLevels = new Block();
      public BlockCollection<UiCampaignBlockBlock> _campaignsList = new BlockCollection<UiCampaignBlockBlock>();
      public BlockCollection<GlobalUiCampaignLevelBlockBlock> _campaignLevelsList = new BlockCollection<GlobalUiCampaignLevelBlockBlock>();
      public BlockCollection<GlobalUiMultiplayerLevelBlockBlock> _multiplayerLevelsList = new BlockCollection<GlobalUiMultiplayerLevelBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UiLevelsDefinitionBlockBlock() {
      }
      public BlockCollection<UiCampaignBlockBlock> Campaigns {
        get {
          return this._campaignsList;
        }
      }
      public BlockCollection<GlobalUiCampaignLevelBlockBlock> CampaignLevels {
        get {
          return this._campaignLevelsList;
        }
      }
      public BlockCollection<GlobalUiMultiplayerLevelBlockBlock> MultiplayerLevels {
        get {
          return this._multiplayerLevelsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Campaigns.BlockCount; x++)
{
  IBlock block = Campaigns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CampaignLevels.BlockCount; x++)
{
  IBlock block = CampaignLevels.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultiplayerLevels.BlockCount; x++)
{
  IBlock block = MultiplayerLevels.GetBlock(x);
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
        _campaigns.Read(reader);
        _campaignLevels.Read(reader);
        _multiplayerLevels.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _campaigns.Count); x = (x + 1)) {
          Campaigns.Add(new UiCampaignBlockBlock());
          Campaigns[x].Read(reader);
        }
        for (x = 0; (x < _campaigns.Count); x = (x + 1)) {
          Campaigns[x].ReadChildData(reader);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels.Add(new GlobalUiCampaignLevelBlockBlock());
          CampaignLevels[x].Read(reader);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiplayerLevels.Count); x = (x + 1)) {
          MultiplayerLevels.Add(new GlobalUiMultiplayerLevelBlockBlock());
          MultiplayerLevels[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerLevels.Count); x = (x + 1)) {
          MultiplayerLevels[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_campaigns.Count = Campaigns.Count;
        _campaigns.Write(bw);
_campaignLevels.Count = CampaignLevels.Count;
        _campaignLevels.Write(bw);
_multiplayerLevels.Count = MultiplayerLevels.Count;
        _multiplayerLevels.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _campaigns.Count); x = (x + 1)) {
          Campaigns[x].Write(writer);
        }
        for (x = 0; (x < _campaigns.Count); x = (x + 1)) {
          Campaigns[x].WriteChildData(writer);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].Write(writer);
        }
        for (x = 0; (x < _campaignLevels.Count); x = (x + 1)) {
          CampaignLevels[x].WriteChildData(writer);
        }
        for (x = 0; (x < _multiplayerLevels.Count); x = (x + 1)) {
          MultiplayerLevels[x].Write(writer);
        }
        for (x = 0; (x < _multiplayerLevels.Count); x = (x + 1)) {
          MultiplayerLevels[x].WriteChildData(writer);
        }
      }
    }
    public class UiCampaignBlockBlock : IBlock {
      private LongInteger _campaignID = new LongInteger();
      private Skip _unnamed0;
      private Skip _unnamed1;
public event System.EventHandler BlockNameChanged;
      public UiCampaignBlockBlock() {
        this._unnamed0 = new Skip(576);
        this._unnamed1 = new Skip(2304);
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
      public LongInteger CampaignID {
        get {
          return this._campaignID;
        }
        set {
          this._campaignID = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _campaignID.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _campaignID.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalUiCampaignLevelBlockBlock : IBlock {
      private LongInteger _campaignID = new LongInteger();
      private LongInteger _mapID = new LongInteger();
      private TagReference _bitmap = new TagReference();
      private Skip _unnamed0;
      private Skip _unnamed1;
public event System.EventHandler BlockNameChanged;
      public GlobalUiCampaignLevelBlockBlock() {
        this._unnamed0 = new Skip(576);
        this._unnamed1 = new Skip(2304);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public LongInteger CampaignID {
        get {
          return this._campaignID;
        }
        set {
          this._campaignID = value;
        }
      }
      public LongInteger MapID {
        get {
          return this._mapID;
        }
        set {
          this._mapID = value;
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _campaignID.Read(reader);
        _mapID.Read(reader);
        _bitmap.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _campaignID.Write(bw);
        _mapID.Write(bw);
        _bitmap.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
      }
    }
    public class GlobalUiMultiplayerLevelBlockBlock : IBlock {
      private LongInteger _mapID = new LongInteger();
      private TagReference _bitmap = new TagReference();
      private Skip _unnamed0;
      private Skip _unnamed1;
      private LongerFixedLengthString _path = new LongerFixedLengthString();
      private LongInteger _sortOrder = new LongInteger();
      private Flags _flags;
      private Pad _unnamed2;
      private CharInteger _maxTeamsNone = new CharInteger();
      private CharInteger _maxTeamsCTF = new CharInteger();
      private CharInteger _maxTeamsSlayer = new CharInteger();
      private CharInteger _maxTeamsOddball = new CharInteger();
      private CharInteger _maxTeamsKOTH = new CharInteger();
      private CharInteger _maxTeamsRace = new CharInteger();
      private CharInteger _maxTeamsHeadhunter = new CharInteger();
      private CharInteger _maxTeamsJuggernaut = new CharInteger();
      private CharInteger _maxTeamsTerritories = new CharInteger();
      private CharInteger _maxTeamsAssault = new CharInteger();
      private CharInteger _maxTeamsStub10 = new CharInteger();
      private CharInteger _maxTeamsStub11 = new CharInteger();
      private CharInteger _maxTeamsStub12 = new CharInteger();
      private CharInteger _maxTeamsStub13 = new CharInteger();
      private CharInteger _maxTeamsStub14 = new CharInteger();
      private CharInteger _maxTeamsStub15 = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalUiMultiplayerLevelBlockBlock() {
        this._unnamed0 = new Skip(576);
        this._unnamed1 = new Skip(2304);
        this._flags = new Flags(1);
        this._unnamed2 = new Pad(3);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public LongInteger MapID {
        get {
          return this._mapID;
        }
        set {
          this._mapID = value;
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public LongerFixedLengthString Path {
        get {
          return this._path;
        }
        set {
          this._path = value;
        }
      }
      public LongInteger SortOrder {
        get {
          return this._sortOrder;
        }
        set {
          this._sortOrder = value;
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
      public CharInteger MaxTeamsNone {
        get {
          return this._maxTeamsNone;
        }
        set {
          this._maxTeamsNone = value;
        }
      }
      public CharInteger MaxTeamsCTF {
        get {
          return this._maxTeamsCTF;
        }
        set {
          this._maxTeamsCTF = value;
        }
      }
      public CharInteger MaxTeamsSlayer {
        get {
          return this._maxTeamsSlayer;
        }
        set {
          this._maxTeamsSlayer = value;
        }
      }
      public CharInteger MaxTeamsOddball {
        get {
          return this._maxTeamsOddball;
        }
        set {
          this._maxTeamsOddball = value;
        }
      }
      public CharInteger MaxTeamsKOTH {
        get {
          return this._maxTeamsKOTH;
        }
        set {
          this._maxTeamsKOTH = value;
        }
      }
      public CharInteger MaxTeamsRace {
        get {
          return this._maxTeamsRace;
        }
        set {
          this._maxTeamsRace = value;
        }
      }
      public CharInteger MaxTeamsHeadhunter {
        get {
          return this._maxTeamsHeadhunter;
        }
        set {
          this._maxTeamsHeadhunter = value;
        }
      }
      public CharInteger MaxTeamsJuggernaut {
        get {
          return this._maxTeamsJuggernaut;
        }
        set {
          this._maxTeamsJuggernaut = value;
        }
      }
      public CharInteger MaxTeamsTerritories {
        get {
          return this._maxTeamsTerritories;
        }
        set {
          this._maxTeamsTerritories = value;
        }
      }
      public CharInteger MaxTeamsAssault {
        get {
          return this._maxTeamsAssault;
        }
        set {
          this._maxTeamsAssault = value;
        }
      }
      public CharInteger MaxTeamsStub10 {
        get {
          return this._maxTeamsStub10;
        }
        set {
          this._maxTeamsStub10 = value;
        }
      }
      public CharInteger MaxTeamsStub11 {
        get {
          return this._maxTeamsStub11;
        }
        set {
          this._maxTeamsStub11 = value;
        }
      }
      public CharInteger MaxTeamsStub12 {
        get {
          return this._maxTeamsStub12;
        }
        set {
          this._maxTeamsStub12 = value;
        }
      }
      public CharInteger MaxTeamsStub13 {
        get {
          return this._maxTeamsStub13;
        }
        set {
          this._maxTeamsStub13 = value;
        }
      }
      public CharInteger MaxTeamsStub14 {
        get {
          return this._maxTeamsStub14;
        }
        set {
          this._maxTeamsStub14 = value;
        }
      }
      public CharInteger MaxTeamsStub15 {
        get {
          return this._maxTeamsStub15;
        }
        set {
          this._maxTeamsStub15 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mapID.Read(reader);
        _bitmap.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _path.Read(reader);
        _sortOrder.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _maxTeamsNone.Read(reader);
        _maxTeamsCTF.Read(reader);
        _maxTeamsSlayer.Read(reader);
        _maxTeamsOddball.Read(reader);
        _maxTeamsKOTH.Read(reader);
        _maxTeamsRace.Read(reader);
        _maxTeamsHeadhunter.Read(reader);
        _maxTeamsJuggernaut.Read(reader);
        _maxTeamsTerritories.Read(reader);
        _maxTeamsAssault.Read(reader);
        _maxTeamsStub10.Read(reader);
        _maxTeamsStub11.Read(reader);
        _maxTeamsStub12.Read(reader);
        _maxTeamsStub13.Read(reader);
        _maxTeamsStub14.Read(reader);
        _maxTeamsStub15.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _mapID.Write(bw);
        _bitmap.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _path.Write(bw);
        _sortOrder.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _maxTeamsNone.Write(bw);
        _maxTeamsCTF.Write(bw);
        _maxTeamsSlayer.Write(bw);
        _maxTeamsOddball.Write(bw);
        _maxTeamsKOTH.Write(bw);
        _maxTeamsRace.Write(bw);
        _maxTeamsHeadhunter.Write(bw);
        _maxTeamsJuggernaut.Write(bw);
        _maxTeamsTerritories.Write(bw);
        _maxTeamsAssault.Write(bw);
        _maxTeamsStub10.Write(bw);
        _maxTeamsStub11.Write(bw);
        _maxTeamsStub12.Write(bw);
        _maxTeamsStub13.Write(bw);
        _maxTeamsStub14.Write(bw);
        _maxTeamsStub15.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
      }
    }
  }
}
