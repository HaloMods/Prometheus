// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'globals'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class globals : Interfaces.Pool.Tag {
    private GlobalsBlock globalsValues = new GlobalsBlock();
    public virtual GlobalsBlock GlobalsValues {
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
    public class GlobalsBlock : IBlock {
      private Pad _unnamed;
      private Block _sounds = new Block();
      private Block _camera = new Block();
      private Block _playerControl = new Block();
      private Block _difficulty = new Block();
      private Block _grenades = new Block();
      private Block _rasterizerData = new Block();
      private Block _interfaceBitmaps = new Block();
      private Block _weaponListUpdateweaponlistEnumInGameglobals_Pth = new Block();
      private Block _cheatPowerups = new Block();
      private Block _multiplayerInformation = new Block();
      private Block _playerInformation = new Block();
      private Block _firstPersonInterface = new Block();
      private Block _fallingDamage = new Block();
      private Block _materials = new Block();
      private Block _playlistMembers = new Block();
      public BlockCollection<SoundBlock> _soundsList = new BlockCollection<SoundBlock>();
      public BlockCollection<CameraBlock> _cameraList = new BlockCollection<CameraBlock>();
      public BlockCollection<PlayerControlBlock> _playerControlList = new BlockCollection<PlayerControlBlock>();
      public BlockCollection<DifficultyBlock> _difficultyList = new BlockCollection<DifficultyBlock>();
      public BlockCollection<GrenadesBlock> _grenadesList = new BlockCollection<GrenadesBlock>();
      public BlockCollection<RasterizerDataBlock> _rasterizerDataList = new BlockCollection<RasterizerDataBlock>();
      public BlockCollection<InterfaceTagReferencesBlock> _interfaceBitmapsList = new BlockCollection<InterfaceTagReferencesBlock>();
      public BlockCollection<CheatWeaponsBlock> _weaponListUpdateweaponlistEnumInGameglobals_PthList = new BlockCollection<CheatWeaponsBlock>();
      public BlockCollection<CheatPowerupsBlock> _cheatPowerupsList = new BlockCollection<CheatPowerupsBlock>();
      public BlockCollection<MultiplayerInformationBlock> _multiplayerInformationList = new BlockCollection<MultiplayerInformationBlock>();
      public BlockCollection<PlayerInformationBlock> _playerInformationList = new BlockCollection<PlayerInformationBlock>();
      public BlockCollection<FirstPersonInterfaceBlock> _firstPersonInterfaceList = new BlockCollection<FirstPersonInterfaceBlock>();
      public BlockCollection<FallingDamageBlock> _fallingDamageList = new BlockCollection<FallingDamageBlock>();
      public BlockCollection<MaterialsBlock> _materialsList = new BlockCollection<MaterialsBlock>();
      public BlockCollection<PlaylistAutogenerateChoiceBlock> _playlistMembersList = new BlockCollection<PlaylistAutogenerateChoiceBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalsBlock() {
        this._unnamed = new Pad(248);
      }
      public BlockCollection<SoundBlock> Sounds {
        get {
          return this._soundsList;
        }
      }
      public BlockCollection<CameraBlock> Camera {
        get {
          return this._cameraList;
        }
      }
      public BlockCollection<PlayerControlBlock> PlayerControl {
        get {
          return this._playerControlList;
        }
      }
      public BlockCollection<DifficultyBlock> Difficulty {
        get {
          return this._difficultyList;
        }
      }
      public BlockCollection<GrenadesBlock> Grenades {
        get {
          return this._grenadesList;
        }
      }
      public BlockCollection<RasterizerDataBlock> RasterizerData {
        get {
          return this._rasterizerDataList;
        }
      }
      public BlockCollection<InterfaceTagReferencesBlock> InterfaceBitmaps {
        get {
          return this._interfaceBitmapsList;
        }
      }
      public BlockCollection<CheatWeaponsBlock> WeaponListUpdateweaponlistEnumInGameglobals_Pth {
        get {
          return this._weaponListUpdateweaponlistEnumInGameglobals_PthList;
        }
      }
      public BlockCollection<CheatPowerupsBlock> CheatPowerups {
        get {
          return this._cheatPowerupsList;
        }
      }
      public BlockCollection<MultiplayerInformationBlock> MultiplayerInformation {
        get {
          return this._multiplayerInformationList;
        }
      }
      public BlockCollection<PlayerInformationBlock> PlayerInformation {
        get {
          return this._playerInformationList;
        }
      }
      public BlockCollection<FirstPersonInterfaceBlock> FirstPersonInterface {
        get {
          return this._firstPersonInterfaceList;
        }
      }
      public BlockCollection<FallingDamageBlock> FallingDamage {
        get {
          return this._fallingDamageList;
        }
      }
      public BlockCollection<MaterialsBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<PlaylistAutogenerateChoiceBlock> PlaylistMembers {
        get {
          return this._playlistMembersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
for (int x=0; x<InterfaceBitmaps.BlockCount; x++)
{
  IBlock block = InterfaceBitmaps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponListUpdateweaponlistEnumInGameglobals_Pth.BlockCount; x++)
{
  IBlock block = WeaponListUpdateweaponlistEnumInGameglobals_Pth.GetBlock(x);
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
for (int x=0; x<FirstPersonInterface.BlockCount; x++)
{
  IBlock block = FirstPersonInterface.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FallingDamage.BlockCount; x++)
{
  IBlock block = FallingDamage.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlaylistMembers.BlockCount; x++)
{
  IBlock block = PlaylistMembers.GetBlock(x);
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
        _unnamed.Read(reader);
        _sounds.Read(reader);
        _camera.Read(reader);
        _playerControl.Read(reader);
        _difficulty.Read(reader);
        _grenades.Read(reader);
        _rasterizerData.Read(reader);
        _interfaceBitmaps.Read(reader);
        _weaponListUpdateweaponlistEnumInGameglobals_Pth.Read(reader);
        _cheatPowerups.Read(reader);
        _multiplayerInformation.Read(reader);
        _playerInformation.Read(reader);
        _firstPersonInterface.Read(reader);
        _fallingDamage.Read(reader);
        _materials.Read(reader);
        _playlistMembers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new SoundBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera.Add(new CameraBlock());
          Camera[x].Read(reader);
        }
        for (x = 0; (x < _camera.Count); x = (x + 1)) {
          Camera[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl.Add(new PlayerControlBlock());
          PlayerControl[x].Read(reader);
        }
        for (x = 0; (x < _playerControl.Count); x = (x + 1)) {
          PlayerControl[x].ReadChildData(reader);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty.Add(new DifficultyBlock());
          Difficulty[x].Read(reader);
        }
        for (x = 0; (x < _difficulty.Count); x = (x + 1)) {
          Difficulty[x].ReadChildData(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades.Add(new GrenadesBlock());
          Grenades[x].Read(reader);
        }
        for (x = 0; (x < _grenades.Count); x = (x + 1)) {
          Grenades[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData.Add(new RasterizerDataBlock());
          RasterizerData[x].Read(reader);
        }
        for (x = 0; (x < _rasterizerData.Count); x = (x + 1)) {
          RasterizerData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _interfaceBitmaps.Count); x = (x + 1)) {
          InterfaceBitmaps.Add(new InterfaceTagReferencesBlock());
          InterfaceBitmaps[x].Read(reader);
        }
        for (x = 0; (x < _interfaceBitmaps.Count); x = (x + 1)) {
          InterfaceBitmaps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobals_Pth.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobals_Pth.Add(new CheatWeaponsBlock());
          WeaponListUpdateweaponlistEnumInGameglobals_Pth[x].Read(reader);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobals_Pth.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobals_Pth[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups.Add(new CheatPowerupsBlock());
          CheatPowerups[x].Read(reader);
        }
        for (x = 0; (x < _cheatPowerups.Count); x = (x + 1)) {
          CheatPowerups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation.Add(new MultiplayerInformationBlock());
          MultiplayerInformation[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerInformation.Count); x = (x + 1)) {
          MultiplayerInformation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation.Add(new PlayerInformationBlock());
          PlayerInformation[x].Read(reader);
        }
        for (x = 0; (x < _playerInformation.Count); x = (x + 1)) {
          PlayerInformation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _firstPersonInterface.Count); x = (x + 1)) {
          FirstPersonInterface.Add(new FirstPersonInterfaceBlock());
          FirstPersonInterface[x].Read(reader);
        }
        for (x = 0; (x < _firstPersonInterface.Count); x = (x + 1)) {
          FirstPersonInterface[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage.Add(new FallingDamageBlock());
          FallingDamage[x].Read(reader);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new MaterialsBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playlistMembers.Count); x = (x + 1)) {
          PlaylistMembers.Add(new PlaylistAutogenerateChoiceBlock());
          PlaylistMembers[x].Read(reader);
        }
        for (x = 0; (x < _playlistMembers.Count); x = (x + 1)) {
          PlaylistMembers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
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
_interfaceBitmaps.Count = InterfaceBitmaps.Count;
        _interfaceBitmaps.Write(bw);
_weaponListUpdateweaponlistEnumInGameglobals_Pth.Count = WeaponListUpdateweaponlistEnumInGameglobals_Pth.Count;
        _weaponListUpdateweaponlistEnumInGameglobals_Pth.Write(bw);
_cheatPowerups.Count = CheatPowerups.Count;
        _cheatPowerups.Write(bw);
_multiplayerInformation.Count = MultiplayerInformation.Count;
        _multiplayerInformation.Write(bw);
_playerInformation.Count = PlayerInformation.Count;
        _playerInformation.Write(bw);
_firstPersonInterface.Count = FirstPersonInterface.Count;
        _firstPersonInterface.Write(bw);
_fallingDamage.Count = FallingDamage.Count;
        _fallingDamage.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_playlistMembers.Count = PlaylistMembers.Count;
        _playlistMembers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
        for (x = 0; (x < _interfaceBitmaps.Count); x = (x + 1)) {
          InterfaceBitmaps[x].Write(writer);
        }
        for (x = 0; (x < _interfaceBitmaps.Count); x = (x + 1)) {
          InterfaceBitmaps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobals_Pth.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobals_Pth[x].Write(writer);
        }
        for (x = 0; (x < _weaponListUpdateweaponlistEnumInGameglobals_Pth.Count); x = (x + 1)) {
          WeaponListUpdateweaponlistEnumInGameglobals_Pth[x].WriteChildData(writer);
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
        for (x = 0; (x < _firstPersonInterface.Count); x = (x + 1)) {
          FirstPersonInterface[x].Write(writer);
        }
        for (x = 0; (x < _firstPersonInterface.Count); x = (x + 1)) {
          FirstPersonInterface[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].Write(writer);
        }
        for (x = 0; (x < _fallingDamage.Count); x = (x + 1)) {
          FallingDamage[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playlistMembers.Count); x = (x + 1)) {
          PlaylistMembers[x].Write(writer);
        }
        for (x = 0; (x < _playlistMembers.Count); x = (x + 1)) {
          PlaylistMembers[x].WriteChildData(writer);
        }
      }
    }
    public class SoundBlock : IBlock {
      private TagReference _sound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SoundBlock() {
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
return "";
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
    public class CameraBlock : IBlock {
      private TagReference _defaultUnitCameraTrack = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CameraBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _defaultUnitCameraTrack.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _defaultUnitCameraTrack.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _defaultUnitCameraTrack.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _defaultUnitCameraTrack.WriteString(writer);
      }
    }
    public class PlayerControlBlock : IBlock {
      private RealFraction _magnetismFriction = new RealFraction();
      private RealFraction _magnetismAdhesion = new RealFraction();
      private RealFraction _inconsequentialTargetScale = new RealFraction();
      private Pad _unnamed;
      private Real _lookAccelerationTime = new Real();
      private Real _lookAccelerationScale = new Real();
      private RealFraction _lookPegThreshold = new RealFraction();
      private Real _lookDefaultPitchRate = new Real();
      private Real _lookDefaultYawRate = new Real();
      private Real _lookAutolevellingScale = new Real();
      private Pad _unnamed2;
      private ShortInteger _minimumWeaponSwapTicks = new ShortInteger();
      private ShortInteger _minimumAutolevellingTicks = new ShortInteger();
      private Angle _minimumAngleForVehicleFlipping = new Angle();
      private Block _lookFunction = new Block();
      public BlockCollection<LookFunctionBlock> _lookFunctionList = new BlockCollection<LookFunctionBlock>();
public event System.EventHandler BlockNameChanged;
      public PlayerControlBlock() {
        this._unnamed = new Pad(52);
        this._unnamed2 = new Pad(20);
      }
      public BlockCollection<LookFunctionBlock> LookFunction {
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
      public Real LookAccelerationTime {
        get {
          return this._lookAccelerationTime;
        }
        set {
          this._lookAccelerationTime = value;
        }
      }
      public Real LookAccelerationScale {
        get {
          return this._lookAccelerationScale;
        }
        set {
          this._lookAccelerationScale = value;
        }
      }
      public RealFraction LookPegThreshold {
        get {
          return this._lookPegThreshold;
        }
        set {
          this._lookPegThreshold = value;
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
      public Real LookAutolevellingScale {
        get {
          return this._lookAutolevellingScale;
        }
        set {
          this._lookAutolevellingScale = value;
        }
      }
      public ShortInteger MinimumWeaponSwapTicks {
        get {
          return this._minimumWeaponSwapTicks;
        }
        set {
          this._minimumWeaponSwapTicks = value;
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
      public virtual void Read(BinaryReader reader) {
        _magnetismFriction.Read(reader);
        _magnetismAdhesion.Read(reader);
        _inconsequentialTargetScale.Read(reader);
        _unnamed.Read(reader);
        _lookAccelerationTime.Read(reader);
        _lookAccelerationScale.Read(reader);
        _lookPegThreshold.Read(reader);
        _lookDefaultPitchRate.Read(reader);
        _lookDefaultYawRate.Read(reader);
        _lookAutolevellingScale.Read(reader);
        _unnamed2.Read(reader);
        _minimumWeaponSwapTicks.Read(reader);
        _minimumAutolevellingTicks.Read(reader);
        _minimumAngleForVehicleFlipping.Read(reader);
        _lookFunction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lookFunction.Count); x = (x + 1)) {
          LookFunction.Add(new LookFunctionBlock());
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
        _unnamed.Write(bw);
        _lookAccelerationTime.Write(bw);
        _lookAccelerationScale.Write(bw);
        _lookPegThreshold.Write(bw);
        _lookDefaultPitchRate.Write(bw);
        _lookDefaultYawRate.Write(bw);
        _lookAutolevellingScale.Write(bw);
        _unnamed2.Write(bw);
        _minimumWeaponSwapTicks.Write(bw);
        _minimumAutolevellingTicks.Write(bw);
        _minimumAngleForVehicleFlipping.Write(bw);
_lookFunction.Count = LookFunction.Count;
        _lookFunction.Write(bw);
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
    public class LookFunctionBlock : IBlock {
      private Real _scale = new Real();
public event System.EventHandler BlockNameChanged;
      public LookFunctionBlock() {
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
    public class DifficultyBlock : IBlock {
      private Real _easyEnemyDamage = new Real();
      private Real _normalEnemyDamage = new Real();
      private Real _hardEnemyDamage = new Real();
      private Real _imposs_PtEnemyDamage = new Real();
      private Real _easyEnemyVitality = new Real();
      private Real _normalEnemyVitality = new Real();
      private Real _hardEnemyVitality = new Real();
      private Real _imposs_PtEnemyVitality = new Real();
      private Real _easyEnemyShield = new Real();
      private Real _normalEnemyShield = new Real();
      private Real _hardEnemyShield = new Real();
      private Real _imposs_PtEnemyShield = new Real();
      private Real _easyEnemyRecharge = new Real();
      private Real _normalEnemyRecharge = new Real();
      private Real _hardEnemyRecharge = new Real();
      private Real _imposs_PtEnemyRecharge = new Real();
      private Real _easyFriendDamage = new Real();
      private Real _normalFriendDamage = new Real();
      private Real _hardFriendDamage = new Real();
      private Real _imposs_PtFriendDamage = new Real();
      private Real _easyFriendVitality = new Real();
      private Real _normalFriendVitality = new Real();
      private Real _hardFriendVitality = new Real();
      private Real _imposs_PtFriendVitality = new Real();
      private Real _easyFriendShield = new Real();
      private Real _normalFriendShield = new Real();
      private Real _hardFriendShield = new Real();
      private Real _imposs_PtFriendShield = new Real();
      private Real _easyFriendRecharge = new Real();
      private Real _normalFriendRecharge = new Real();
      private Real _hardFriendRecharge = new Real();
      private Real _imposs_PtFriendRecharge = new Real();
      private Real _easyInfectionForms = new Real();
      private Real _normalInfectionForms = new Real();
      private Real _hardInfectionForms = new Real();
      private Real _imposs_PtInfectionForms = new Real();
      private Pad _unnamed;
      private Real _easyRateOfFire = new Real();
      private Real _normalRateOfFire = new Real();
      private Real _hardRateOfFire = new Real();
      private Real _imposs_PtRateOfFire = new Real();
      private Real _easyProjectileError = new Real();
      private Real _normalProjectileError = new Real();
      private Real _hardProjectileError = new Real();
      private Real _imposs_PtProjectileError = new Real();
      private Real _easyBurstError = new Real();
      private Real _normalBurstError = new Real();
      private Real _hardBurstError = new Real();
      private Real _imposs_PtBurstError = new Real();
      private Real _easyNewTargetDelay = new Real();
      private Real _normalNewTargetDelay = new Real();
      private Real _hardNewTargetDelay = new Real();
      private Real _imposs_PtNewTargetDelay = new Real();
      private Real _easyBurstSeparation = new Real();
      private Real _normalBurstSeparation = new Real();
      private Real _hardBurstSeparation = new Real();
      private Real _imposs_PtBurstSeparation = new Real();
      private Real _easyTargetTracking = new Real();
      private Real _normalTargetTracking = new Real();
      private Real _hardTargetTracking = new Real();
      private Real _imposs_PtTargetTracking = new Real();
      private Real _easyTargetLeading = new Real();
      private Real _normalTargetLeading = new Real();
      private Real _hardTargetLeading = new Real();
      private Real _imposs_PtTargetLeading = new Real();
      private Real _easyOverchargeChance = new Real();
      private Real _normalOverchargeChance = new Real();
      private Real _hardOverchargeChance = new Real();
      private Real _imposs_PtOverchargeChance = new Real();
      private Real _easySpecialFireDelay = new Real();
      private Real _normalSpecialFireDelay = new Real();
      private Real _hardSpecialFireDelay = new Real();
      private Real _imposs_PtSpecialFireDelay = new Real();
      private Real _easyGuidanceVsPlayer = new Real();
      private Real _normalGuidanceVsPlayer = new Real();
      private Real _hardGuidanceVsPlayer = new Real();
      private Real _imposs_PtGuidanceVsPlayer = new Real();
      private Real _easyMeleeDelayBase = new Real();
      private Real _normalMeleeDelayBase = new Real();
      private Real _hardMeleeDelayBase = new Real();
      private Real _imposs_PtMeleeDelayBase = new Real();
      private Real _easyMeleeDelayScale = new Real();
      private Real _normalMeleeDelayScale = new Real();
      private Real _hardMeleeDelayScale = new Real();
      private Real _imposs_PtMeleeDelayScale = new Real();
      private Pad _unnamed2;
      private Real _easyGrenadeChanceScale = new Real();
      private Real _normalGrenadeChanceScale = new Real();
      private Real _hardGrenadeChanceScale = new Real();
      private Real _imposs_PtGrenadeChanceScale = new Real();
      private Real _easyGrenadeTimerScale = new Real();
      private Real _normalGrenadeTimerScale = new Real();
      private Real _hardGrenadeTimerScale = new Real();
      private Real _imposs_PtGrenadeTimerScale = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Real _easyMajorUpgradeNormal = new Real();
      private Real _normalMajorUpgradeNormal = new Real();
      private Real _hardMajorUpgradeNormal = new Real();
      private Real _imposs_PtMajorUpgradeNormal = new Real();
      private Real _easyMajorUpgradeFew = new Real();
      private Real _normalMajorUpgradeFew = new Real();
      private Real _hardMajorUpgradeFew = new Real();
      private Real _imposs_PtMajorUpgradeFew = new Real();
      private Real _easyMajorUpgradeMany = new Real();
      private Real _normalMajorUpgradeMany = new Real();
      private Real _hardMajorUpgradeMany = new Real();
      private Real _imposs_PtMajorUpgradeMany = new Real();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Pad _unnamed9;
      private Pad _unnamed10;
public event System.EventHandler BlockNameChanged;
      public DifficultyBlock() {
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(16);
        this._unnamed7 = new Pad(16);
        this._unnamed8 = new Pad(16);
        this._unnamed9 = new Pad(16);
        this._unnamed10 = new Pad(84);
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
      public Real Imposs_PtEnemyDamage {
        get {
          return this._imposs_PtEnemyDamage;
        }
        set {
          this._imposs_PtEnemyDamage = value;
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
      public Real Imposs_PtEnemyVitality {
        get {
          return this._imposs_PtEnemyVitality;
        }
        set {
          this._imposs_PtEnemyVitality = value;
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
      public Real Imposs_PtEnemyShield {
        get {
          return this._imposs_PtEnemyShield;
        }
        set {
          this._imposs_PtEnemyShield = value;
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
      public Real Imposs_PtEnemyRecharge {
        get {
          return this._imposs_PtEnemyRecharge;
        }
        set {
          this._imposs_PtEnemyRecharge = value;
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
      public Real Imposs_PtFriendDamage {
        get {
          return this._imposs_PtFriendDamage;
        }
        set {
          this._imposs_PtFriendDamage = value;
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
      public Real Imposs_PtFriendVitality {
        get {
          return this._imposs_PtFriendVitality;
        }
        set {
          this._imposs_PtFriendVitality = value;
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
      public Real Imposs_PtFriendShield {
        get {
          return this._imposs_PtFriendShield;
        }
        set {
          this._imposs_PtFriendShield = value;
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
      public Real Imposs_PtFriendRecharge {
        get {
          return this._imposs_PtFriendRecharge;
        }
        set {
          this._imposs_PtFriendRecharge = value;
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
      public Real Imposs_PtInfectionForms {
        get {
          return this._imposs_PtInfectionForms;
        }
        set {
          this._imposs_PtInfectionForms = value;
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
      public Real Imposs_PtRateOfFire {
        get {
          return this._imposs_PtRateOfFire;
        }
        set {
          this._imposs_PtRateOfFire = value;
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
      public Real Imposs_PtProjectileError {
        get {
          return this._imposs_PtProjectileError;
        }
        set {
          this._imposs_PtProjectileError = value;
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
      public Real Imposs_PtBurstError {
        get {
          return this._imposs_PtBurstError;
        }
        set {
          this._imposs_PtBurstError = value;
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
      public Real Imposs_PtNewTargetDelay {
        get {
          return this._imposs_PtNewTargetDelay;
        }
        set {
          this._imposs_PtNewTargetDelay = value;
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
      public Real Imposs_PtBurstSeparation {
        get {
          return this._imposs_PtBurstSeparation;
        }
        set {
          this._imposs_PtBurstSeparation = value;
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
      public Real Imposs_PtTargetTracking {
        get {
          return this._imposs_PtTargetTracking;
        }
        set {
          this._imposs_PtTargetTracking = value;
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
      public Real Imposs_PtTargetLeading {
        get {
          return this._imposs_PtTargetLeading;
        }
        set {
          this._imposs_PtTargetLeading = value;
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
      public Real Imposs_PtOverchargeChance {
        get {
          return this._imposs_PtOverchargeChance;
        }
        set {
          this._imposs_PtOverchargeChance = value;
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
      public Real Imposs_PtSpecialFireDelay {
        get {
          return this._imposs_PtSpecialFireDelay;
        }
        set {
          this._imposs_PtSpecialFireDelay = value;
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
      public Real Imposs_PtGuidanceVsPlayer {
        get {
          return this._imposs_PtGuidanceVsPlayer;
        }
        set {
          this._imposs_PtGuidanceVsPlayer = value;
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
      public Real Imposs_PtMeleeDelayBase {
        get {
          return this._imposs_PtMeleeDelayBase;
        }
        set {
          this._imposs_PtMeleeDelayBase = value;
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
      public Real Imposs_PtMeleeDelayScale {
        get {
          return this._imposs_PtMeleeDelayScale;
        }
        set {
          this._imposs_PtMeleeDelayScale = value;
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
      public Real Imposs_PtGrenadeChanceScale {
        get {
          return this._imposs_PtGrenadeChanceScale;
        }
        set {
          this._imposs_PtGrenadeChanceScale = value;
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
      public Real Imposs_PtGrenadeTimerScale {
        get {
          return this._imposs_PtGrenadeTimerScale;
        }
        set {
          this._imposs_PtGrenadeTimerScale = value;
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
      public Real Imposs_PtMajorUpgradeNormal {
        get {
          return this._imposs_PtMajorUpgradeNormal;
        }
        set {
          this._imposs_PtMajorUpgradeNormal = value;
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
      public Real Imposs_PtMajorUpgradeFew {
        get {
          return this._imposs_PtMajorUpgradeFew;
        }
        set {
          this._imposs_PtMajorUpgradeFew = value;
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
      public Real Imposs_PtMajorUpgradeMany {
        get {
          return this._imposs_PtMajorUpgradeMany;
        }
        set {
          this._imposs_PtMajorUpgradeMany = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _easyEnemyDamage.Read(reader);
        _normalEnemyDamage.Read(reader);
        _hardEnemyDamage.Read(reader);
        _imposs_PtEnemyDamage.Read(reader);
        _easyEnemyVitality.Read(reader);
        _normalEnemyVitality.Read(reader);
        _hardEnemyVitality.Read(reader);
        _imposs_PtEnemyVitality.Read(reader);
        _easyEnemyShield.Read(reader);
        _normalEnemyShield.Read(reader);
        _hardEnemyShield.Read(reader);
        _imposs_PtEnemyShield.Read(reader);
        _easyEnemyRecharge.Read(reader);
        _normalEnemyRecharge.Read(reader);
        _hardEnemyRecharge.Read(reader);
        _imposs_PtEnemyRecharge.Read(reader);
        _easyFriendDamage.Read(reader);
        _normalFriendDamage.Read(reader);
        _hardFriendDamage.Read(reader);
        _imposs_PtFriendDamage.Read(reader);
        _easyFriendVitality.Read(reader);
        _normalFriendVitality.Read(reader);
        _hardFriendVitality.Read(reader);
        _imposs_PtFriendVitality.Read(reader);
        _easyFriendShield.Read(reader);
        _normalFriendShield.Read(reader);
        _hardFriendShield.Read(reader);
        _imposs_PtFriendShield.Read(reader);
        _easyFriendRecharge.Read(reader);
        _normalFriendRecharge.Read(reader);
        _hardFriendRecharge.Read(reader);
        _imposs_PtFriendRecharge.Read(reader);
        _easyInfectionForms.Read(reader);
        _normalInfectionForms.Read(reader);
        _hardInfectionForms.Read(reader);
        _imposs_PtInfectionForms.Read(reader);
        _unnamed.Read(reader);
        _easyRateOfFire.Read(reader);
        _normalRateOfFire.Read(reader);
        _hardRateOfFire.Read(reader);
        _imposs_PtRateOfFire.Read(reader);
        _easyProjectileError.Read(reader);
        _normalProjectileError.Read(reader);
        _hardProjectileError.Read(reader);
        _imposs_PtProjectileError.Read(reader);
        _easyBurstError.Read(reader);
        _normalBurstError.Read(reader);
        _hardBurstError.Read(reader);
        _imposs_PtBurstError.Read(reader);
        _easyNewTargetDelay.Read(reader);
        _normalNewTargetDelay.Read(reader);
        _hardNewTargetDelay.Read(reader);
        _imposs_PtNewTargetDelay.Read(reader);
        _easyBurstSeparation.Read(reader);
        _normalBurstSeparation.Read(reader);
        _hardBurstSeparation.Read(reader);
        _imposs_PtBurstSeparation.Read(reader);
        _easyTargetTracking.Read(reader);
        _normalTargetTracking.Read(reader);
        _hardTargetTracking.Read(reader);
        _imposs_PtTargetTracking.Read(reader);
        _easyTargetLeading.Read(reader);
        _normalTargetLeading.Read(reader);
        _hardTargetLeading.Read(reader);
        _imposs_PtTargetLeading.Read(reader);
        _easyOverchargeChance.Read(reader);
        _normalOverchargeChance.Read(reader);
        _hardOverchargeChance.Read(reader);
        _imposs_PtOverchargeChance.Read(reader);
        _easySpecialFireDelay.Read(reader);
        _normalSpecialFireDelay.Read(reader);
        _hardSpecialFireDelay.Read(reader);
        _imposs_PtSpecialFireDelay.Read(reader);
        _easyGuidanceVsPlayer.Read(reader);
        _normalGuidanceVsPlayer.Read(reader);
        _hardGuidanceVsPlayer.Read(reader);
        _imposs_PtGuidanceVsPlayer.Read(reader);
        _easyMeleeDelayBase.Read(reader);
        _normalMeleeDelayBase.Read(reader);
        _hardMeleeDelayBase.Read(reader);
        _imposs_PtMeleeDelayBase.Read(reader);
        _easyMeleeDelayScale.Read(reader);
        _normalMeleeDelayScale.Read(reader);
        _hardMeleeDelayScale.Read(reader);
        _imposs_PtMeleeDelayScale.Read(reader);
        _unnamed2.Read(reader);
        _easyGrenadeChanceScale.Read(reader);
        _normalGrenadeChanceScale.Read(reader);
        _hardGrenadeChanceScale.Read(reader);
        _imposs_PtGrenadeChanceScale.Read(reader);
        _easyGrenadeTimerScale.Read(reader);
        _normalGrenadeTimerScale.Read(reader);
        _hardGrenadeTimerScale.Read(reader);
        _imposs_PtGrenadeTimerScale.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _easyMajorUpgradeNormal.Read(reader);
        _normalMajorUpgradeNormal.Read(reader);
        _hardMajorUpgradeNormal.Read(reader);
        _imposs_PtMajorUpgradeNormal.Read(reader);
        _easyMajorUpgradeFew.Read(reader);
        _normalMajorUpgradeFew.Read(reader);
        _hardMajorUpgradeFew.Read(reader);
        _imposs_PtMajorUpgradeFew.Read(reader);
        _easyMajorUpgradeMany.Read(reader);
        _normalMajorUpgradeMany.Read(reader);
        _hardMajorUpgradeMany.Read(reader);
        _imposs_PtMajorUpgradeMany.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _easyEnemyDamage.Write(bw);
        _normalEnemyDamage.Write(bw);
        _hardEnemyDamage.Write(bw);
        _imposs_PtEnemyDamage.Write(bw);
        _easyEnemyVitality.Write(bw);
        _normalEnemyVitality.Write(bw);
        _hardEnemyVitality.Write(bw);
        _imposs_PtEnemyVitality.Write(bw);
        _easyEnemyShield.Write(bw);
        _normalEnemyShield.Write(bw);
        _hardEnemyShield.Write(bw);
        _imposs_PtEnemyShield.Write(bw);
        _easyEnemyRecharge.Write(bw);
        _normalEnemyRecharge.Write(bw);
        _hardEnemyRecharge.Write(bw);
        _imposs_PtEnemyRecharge.Write(bw);
        _easyFriendDamage.Write(bw);
        _normalFriendDamage.Write(bw);
        _hardFriendDamage.Write(bw);
        _imposs_PtFriendDamage.Write(bw);
        _easyFriendVitality.Write(bw);
        _normalFriendVitality.Write(bw);
        _hardFriendVitality.Write(bw);
        _imposs_PtFriendVitality.Write(bw);
        _easyFriendShield.Write(bw);
        _normalFriendShield.Write(bw);
        _hardFriendShield.Write(bw);
        _imposs_PtFriendShield.Write(bw);
        _easyFriendRecharge.Write(bw);
        _normalFriendRecharge.Write(bw);
        _hardFriendRecharge.Write(bw);
        _imposs_PtFriendRecharge.Write(bw);
        _easyInfectionForms.Write(bw);
        _normalInfectionForms.Write(bw);
        _hardInfectionForms.Write(bw);
        _imposs_PtInfectionForms.Write(bw);
        _unnamed.Write(bw);
        _easyRateOfFire.Write(bw);
        _normalRateOfFire.Write(bw);
        _hardRateOfFire.Write(bw);
        _imposs_PtRateOfFire.Write(bw);
        _easyProjectileError.Write(bw);
        _normalProjectileError.Write(bw);
        _hardProjectileError.Write(bw);
        _imposs_PtProjectileError.Write(bw);
        _easyBurstError.Write(bw);
        _normalBurstError.Write(bw);
        _hardBurstError.Write(bw);
        _imposs_PtBurstError.Write(bw);
        _easyNewTargetDelay.Write(bw);
        _normalNewTargetDelay.Write(bw);
        _hardNewTargetDelay.Write(bw);
        _imposs_PtNewTargetDelay.Write(bw);
        _easyBurstSeparation.Write(bw);
        _normalBurstSeparation.Write(bw);
        _hardBurstSeparation.Write(bw);
        _imposs_PtBurstSeparation.Write(bw);
        _easyTargetTracking.Write(bw);
        _normalTargetTracking.Write(bw);
        _hardTargetTracking.Write(bw);
        _imposs_PtTargetTracking.Write(bw);
        _easyTargetLeading.Write(bw);
        _normalTargetLeading.Write(bw);
        _hardTargetLeading.Write(bw);
        _imposs_PtTargetLeading.Write(bw);
        _easyOverchargeChance.Write(bw);
        _normalOverchargeChance.Write(bw);
        _hardOverchargeChance.Write(bw);
        _imposs_PtOverchargeChance.Write(bw);
        _easySpecialFireDelay.Write(bw);
        _normalSpecialFireDelay.Write(bw);
        _hardSpecialFireDelay.Write(bw);
        _imposs_PtSpecialFireDelay.Write(bw);
        _easyGuidanceVsPlayer.Write(bw);
        _normalGuidanceVsPlayer.Write(bw);
        _hardGuidanceVsPlayer.Write(bw);
        _imposs_PtGuidanceVsPlayer.Write(bw);
        _easyMeleeDelayBase.Write(bw);
        _normalMeleeDelayBase.Write(bw);
        _hardMeleeDelayBase.Write(bw);
        _imposs_PtMeleeDelayBase.Write(bw);
        _easyMeleeDelayScale.Write(bw);
        _normalMeleeDelayScale.Write(bw);
        _hardMeleeDelayScale.Write(bw);
        _imposs_PtMeleeDelayScale.Write(bw);
        _unnamed2.Write(bw);
        _easyGrenadeChanceScale.Write(bw);
        _normalGrenadeChanceScale.Write(bw);
        _hardGrenadeChanceScale.Write(bw);
        _imposs_PtGrenadeChanceScale.Write(bw);
        _easyGrenadeTimerScale.Write(bw);
        _normalGrenadeTimerScale.Write(bw);
        _hardGrenadeTimerScale.Write(bw);
        _imposs_PtGrenadeTimerScale.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _easyMajorUpgradeNormal.Write(bw);
        _normalMajorUpgradeNormal.Write(bw);
        _hardMajorUpgradeNormal.Write(bw);
        _imposs_PtMajorUpgradeNormal.Write(bw);
        _easyMajorUpgradeFew.Write(bw);
        _normalMajorUpgradeFew.Write(bw);
        _hardMajorUpgradeFew.Write(bw);
        _imposs_PtMajorUpgradeFew.Write(bw);
        _easyMajorUpgradeMany.Write(bw);
        _normalMajorUpgradeMany.Write(bw);
        _hardMajorUpgradeMany.Write(bw);
        _imposs_PtMajorUpgradeMany.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GrenadesBlock : IBlock {
      private ShortInteger _maximumCount = new ShortInteger();
      private ShortInteger _mpSpawnDefault = new ShortInteger();
      private TagReference _throwingEffect = new TagReference();
      private TagReference _hudInterface = new TagReference();
      private TagReference _equipment = new TagReference();
      private TagReference _projectile = new TagReference();
public event System.EventHandler BlockNameChanged;
      public GrenadesBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_throwingEffect.Value);
references.Add(_hudInterface.Value);
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
      public ShortInteger MpSpawnDefault {
        get {
          return this._mpSpawnDefault;
        }
        set {
          this._mpSpawnDefault = value;
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
      public TagReference HudInterface {
        get {
          return this._hudInterface;
        }
        set {
          this._hudInterface = value;
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
        _mpSpawnDefault.Read(reader);
        _throwingEffect.Read(reader);
        _hudInterface.Read(reader);
        _equipment.Read(reader);
        _projectile.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _throwingEffect.ReadString(reader);
        _hudInterface.ReadString(reader);
        _equipment.ReadString(reader);
        _projectile.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _maximumCount.Write(bw);
        _mpSpawnDefault.Write(bw);
        _throwingEffect.Write(bw);
        _hudInterface.Write(bw);
        _equipment.Write(bw);
        _projectile.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _throwingEffect.WriteString(writer);
        _hudInterface.WriteString(writer);
        _equipment.WriteString(writer);
        _projectile.WriteString(writer);
      }
    }
    public class RasterizerDataBlock : IBlock {
      private TagReference _distanceAttenuation = new TagReference();
      private TagReference _vectorNormalization = new TagReference();
      private TagReference _atmosphericFogDensity = new TagReference();
      private TagReference _planarFogDensity = new TagReference();
      private TagReference _linearCornerFade = new TagReference();
      private TagReference _activeCamouflageDistortion = new TagReference();
      private TagReference _glow = new TagReference();
      private Pad _unnamed;
      private TagReference _default2D = new TagReference();
      private TagReference _default3D = new TagReference();
      private TagReference _defaultCubeMap = new TagReference();
      private TagReference _test0 = new TagReference();
      private TagReference _test1 = new TagReference();
      private TagReference _test2 = new TagReference();
      private TagReference _test3 = new TagReference();
      private TagReference _videoScanlineMap = new TagReference();
      private TagReference _videoNoiseMap = new TagReference();
      private Pad _unnamed2;
      private Flags _flags;
      private Pad _unnamed3;
      private Real _refractionAmount = new Real();
      private Real _distanceFalloff = new Real();
      private RealRGBColor _tintColor = new RealRGBColor();
      private Real _hype = new Real();
      private Real _hype2 = new Real();
      private RealRGBColor _hype3 = new RealRGBColor();
      private TagReference _distanceAttenuation2D = new TagReference();
public event System.EventHandler BlockNameChanged;
      public RasterizerDataBlock() {
        this._unnamed = new Pad(60);
        this._unnamed2 = new Pad(52);
        this._flags = new Flags(2);
        this._unnamed3 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_distanceAttenuation.Value);
references.Add(_vectorNormalization.Value);
references.Add(_atmosphericFogDensity.Value);
references.Add(_planarFogDensity.Value);
references.Add(_linearCornerFade.Value);
references.Add(_activeCamouflageDistortion.Value);
references.Add(_glow.Value);
references.Add(_default2D.Value);
references.Add(_default3D.Value);
references.Add(_defaultCubeMap.Value);
references.Add(_test0.Value);
references.Add(_test1.Value);
references.Add(_test2.Value);
references.Add(_test3.Value);
references.Add(_videoScanlineMap.Value);
references.Add(_videoNoiseMap.Value);
references.Add(_distanceAttenuation2D.Value);
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
      public TagReference AtmosphericFogDensity {
        get {
          return this._atmosphericFogDensity;
        }
        set {
          this._atmosphericFogDensity = value;
        }
      }
      public TagReference PlanarFogDensity {
        get {
          return this._planarFogDensity;
        }
        set {
          this._planarFogDensity = value;
        }
      }
      public TagReference LinearCornerFade {
        get {
          return this._linearCornerFade;
        }
        set {
          this._linearCornerFade = value;
        }
      }
      public TagReference ActiveCamouflageDistortion {
        get {
          return this._activeCamouflageDistortion;
        }
        set {
          this._activeCamouflageDistortion = value;
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
      public TagReference Test0 {
        get {
          return this._test0;
        }
        set {
          this._test0 = value;
        }
      }
      public TagReference Test1 {
        get {
          return this._test1;
        }
        set {
          this._test1 = value;
        }
      }
      public TagReference Test2 {
        get {
          return this._test2;
        }
        set {
          this._test2 = value;
        }
      }
      public TagReference Test3 {
        get {
          return this._test3;
        }
        set {
          this._test3 = value;
        }
      }
      public TagReference VideoScanlineMap {
        get {
          return this._videoScanlineMap;
        }
        set {
          this._videoScanlineMap = value;
        }
      }
      public TagReference VideoNoiseMap {
        get {
          return this._videoNoiseMap;
        }
        set {
          this._videoNoiseMap = value;
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
      public Real Hype {
        get {
          return this._hype;
        }
        set {
          this._hype = value;
        }
      }
      public Real Hype2 {
        get {
          return this._hype2;
        }
        set {
          this._hype2 = value;
        }
      }
      public RealRGBColor Hype3 {
        get {
          return this._hype3;
        }
        set {
          this._hype3 = value;
        }
      }
      public TagReference DistanceAttenuation2D {
        get {
          return this._distanceAttenuation2D;
        }
        set {
          this._distanceAttenuation2D = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _distanceAttenuation.Read(reader);
        _vectorNormalization.Read(reader);
        _atmosphericFogDensity.Read(reader);
        _planarFogDensity.Read(reader);
        _linearCornerFade.Read(reader);
        _activeCamouflageDistortion.Read(reader);
        _glow.Read(reader);
        _unnamed.Read(reader);
        _default2D.Read(reader);
        _default3D.Read(reader);
        _defaultCubeMap.Read(reader);
        _test0.Read(reader);
        _test1.Read(reader);
        _test2.Read(reader);
        _test3.Read(reader);
        _videoScanlineMap.Read(reader);
        _videoNoiseMap.Read(reader);
        _unnamed2.Read(reader);
        _flags.Read(reader);
        _unnamed3.Read(reader);
        _refractionAmount.Read(reader);
        _distanceFalloff.Read(reader);
        _tintColor.Read(reader);
        _hype.Read(reader);
        _hype2.Read(reader);
        _hype3.Read(reader);
        _distanceAttenuation2D.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _distanceAttenuation.ReadString(reader);
        _vectorNormalization.ReadString(reader);
        _atmosphericFogDensity.ReadString(reader);
        _planarFogDensity.ReadString(reader);
        _linearCornerFade.ReadString(reader);
        _activeCamouflageDistortion.ReadString(reader);
        _glow.ReadString(reader);
        _default2D.ReadString(reader);
        _default3D.ReadString(reader);
        _defaultCubeMap.ReadString(reader);
        _test0.ReadString(reader);
        _test1.ReadString(reader);
        _test2.ReadString(reader);
        _test3.ReadString(reader);
        _videoScanlineMap.ReadString(reader);
        _videoNoiseMap.ReadString(reader);
        _distanceAttenuation2D.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _distanceAttenuation.Write(bw);
        _vectorNormalization.Write(bw);
        _atmosphericFogDensity.Write(bw);
        _planarFogDensity.Write(bw);
        _linearCornerFade.Write(bw);
        _activeCamouflageDistortion.Write(bw);
        _glow.Write(bw);
        _unnamed.Write(bw);
        _default2D.Write(bw);
        _default3D.Write(bw);
        _defaultCubeMap.Write(bw);
        _test0.Write(bw);
        _test1.Write(bw);
        _test2.Write(bw);
        _test3.Write(bw);
        _videoScanlineMap.Write(bw);
        _videoNoiseMap.Write(bw);
        _unnamed2.Write(bw);
        _flags.Write(bw);
        _unnamed3.Write(bw);
        _refractionAmount.Write(bw);
        _distanceFalloff.Write(bw);
        _tintColor.Write(bw);
        _hype.Write(bw);
        _hype2.Write(bw);
        _hype3.Write(bw);
        _distanceAttenuation2D.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _distanceAttenuation.WriteString(writer);
        _vectorNormalization.WriteString(writer);
        _atmosphericFogDensity.WriteString(writer);
        _planarFogDensity.WriteString(writer);
        _linearCornerFade.WriteString(writer);
        _activeCamouflageDistortion.WriteString(writer);
        _glow.WriteString(writer);
        _default2D.WriteString(writer);
        _default3D.WriteString(writer);
        _defaultCubeMap.WriteString(writer);
        _test0.WriteString(writer);
        _test1.WriteString(writer);
        _test2.WriteString(writer);
        _test3.WriteString(writer);
        _videoScanlineMap.WriteString(writer);
        _videoNoiseMap.WriteString(writer);
        _distanceAttenuation2D.WriteString(writer);
      }
    }
    public class InterfaceTagReferencesBlock : IBlock {
      private TagReference _fontSystem = new TagReference();
      private TagReference _fontTerminal = new TagReference();
      private TagReference _screenColorTable = new TagReference();
      private TagReference _hudColorTable = new TagReference();
      private TagReference _editorColorTable = new TagReference();
      private TagReference _dialogColorTable = new TagReference();
      private TagReference _hudGlobals = new TagReference();
      private TagReference _motionSensorSweepBitmap = new TagReference();
      private TagReference _motionSensorSweepBitmapMask = new TagReference();
      private TagReference _multiplayerHudBitmap = new TagReference();
      private TagReference _localization = new TagReference();
      private TagReference _hudDigitsDefinition = new TagReference();
      private TagReference _motionSensorBlipBitmap = new TagReference();
      private TagReference _interfaceGooMap1 = new TagReference();
      private TagReference _interfaceGooMap2 = new TagReference();
      private TagReference _interfaceGooMap3 = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public InterfaceTagReferencesBlock() {
        this._unnamed = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_fontSystem.Value);
references.Add(_fontTerminal.Value);
references.Add(_screenColorTable.Value);
references.Add(_hudColorTable.Value);
references.Add(_editorColorTable.Value);
references.Add(_dialogColorTable.Value);
references.Add(_hudGlobals.Value);
references.Add(_motionSensorSweepBitmap.Value);
references.Add(_motionSensorSweepBitmapMask.Value);
references.Add(_multiplayerHudBitmap.Value);
references.Add(_localization.Value);
references.Add(_hudDigitsDefinition.Value);
references.Add(_motionSensorBlipBitmap.Value);
references.Add(_interfaceGooMap1.Value);
references.Add(_interfaceGooMap2.Value);
references.Add(_interfaceGooMap3.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference FontSystem {
        get {
          return this._fontSystem;
        }
        set {
          this._fontSystem = value;
        }
      }
      public TagReference FontTerminal {
        get {
          return this._fontTerminal;
        }
        set {
          this._fontTerminal = value;
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
      public TagReference Localization {
        get {
          return this._localization;
        }
        set {
          this._localization = value;
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
      public virtual void Read(BinaryReader reader) {
        _fontSystem.Read(reader);
        _fontTerminal.Read(reader);
        _screenColorTable.Read(reader);
        _hudColorTable.Read(reader);
        _editorColorTable.Read(reader);
        _dialogColorTable.Read(reader);
        _hudGlobals.Read(reader);
        _motionSensorSweepBitmap.Read(reader);
        _motionSensorSweepBitmapMask.Read(reader);
        _multiplayerHudBitmap.Read(reader);
        _localization.Read(reader);
        _hudDigitsDefinition.Read(reader);
        _motionSensorBlipBitmap.Read(reader);
        _interfaceGooMap1.Read(reader);
        _interfaceGooMap2.Read(reader);
        _interfaceGooMap3.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _fontSystem.ReadString(reader);
        _fontTerminal.ReadString(reader);
        _screenColorTable.ReadString(reader);
        _hudColorTable.ReadString(reader);
        _editorColorTable.ReadString(reader);
        _dialogColorTable.ReadString(reader);
        _hudGlobals.ReadString(reader);
        _motionSensorSweepBitmap.ReadString(reader);
        _motionSensorSweepBitmapMask.ReadString(reader);
        _multiplayerHudBitmap.ReadString(reader);
        _localization.ReadString(reader);
        _hudDigitsDefinition.ReadString(reader);
        _motionSensorBlipBitmap.ReadString(reader);
        _interfaceGooMap1.ReadString(reader);
        _interfaceGooMap2.ReadString(reader);
        _interfaceGooMap3.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _fontSystem.Write(bw);
        _fontTerminal.Write(bw);
        _screenColorTable.Write(bw);
        _hudColorTable.Write(bw);
        _editorColorTable.Write(bw);
        _dialogColorTable.Write(bw);
        _hudGlobals.Write(bw);
        _motionSensorSweepBitmap.Write(bw);
        _motionSensorSweepBitmapMask.Write(bw);
        _multiplayerHudBitmap.Write(bw);
        _localization.Write(bw);
        _hudDigitsDefinition.Write(bw);
        _motionSensorBlipBitmap.Write(bw);
        _interfaceGooMap1.Write(bw);
        _interfaceGooMap2.Write(bw);
        _interfaceGooMap3.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _fontSystem.WriteString(writer);
        _fontTerminal.WriteString(writer);
        _screenColorTable.WriteString(writer);
        _hudColorTable.WriteString(writer);
        _editorColorTable.WriteString(writer);
        _dialogColorTable.WriteString(writer);
        _hudGlobals.WriteString(writer);
        _motionSensorSweepBitmap.WriteString(writer);
        _motionSensorSweepBitmapMask.WriteString(writer);
        _multiplayerHudBitmap.WriteString(writer);
        _localization.WriteString(writer);
        _hudDigitsDefinition.WriteString(writer);
        _motionSensorBlipBitmap.WriteString(writer);
        _interfaceGooMap1.WriteString(writer);
        _interfaceGooMap2.WriteString(writer);
        _interfaceGooMap3.WriteString(writer);
      }
    }
    public class CheatWeaponsBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CheatWeaponsBlock() {
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
    public class CheatPowerupsBlock : IBlock {
      private TagReference _powerup = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CheatPowerupsBlock() {
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
    public class MultiplayerInformationBlock : IBlock {
      private TagReference _flag = new TagReference();
      private TagReference _unit = new TagReference();
      private Block _vehicles = new Block();
      private TagReference _hillShader = new TagReference();
      private TagReference _flagShader = new TagReference();
      private TagReference _ball = new TagReference();
      private Block _sounds = new Block();
      private Pad _unnamed;
      public BlockCollection<VehiclesBlock> _vehiclesList = new BlockCollection<VehiclesBlock>();
      public BlockCollection<SoundsBlock> _soundsList = new BlockCollection<SoundsBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerInformationBlock() {
        this._unnamed = new Pad(56);
      }
      public BlockCollection<VehiclesBlock> Vehicles {
        get {
          return this._vehiclesList;
        }
      }
      public BlockCollection<SoundsBlock> Sounds {
        get {
          return this._soundsList;
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
      public virtual void Read(BinaryReader reader) {
        _flag.Read(reader);
        _unit.Read(reader);
        _vehicles.Read(reader);
        _hillShader.Read(reader);
        _flagShader.Read(reader);
        _ball.Read(reader);
        _sounds.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _flag.ReadString(reader);
        _unit.ReadString(reader);
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles.Add(new VehiclesBlock());
          Vehicles[x].Read(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].ReadChildData(reader);
        }
        _hillShader.ReadString(reader);
        _flagShader.ReadString(reader);
        _ball.ReadString(reader);
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new SoundsBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
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
        _unnamed.Write(bw);
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
      }
    }
    public class VehiclesBlock : IBlock {
      private TagReference _vehicle = new TagReference();
public event System.EventHandler BlockNameChanged;
      public VehiclesBlock() {
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
    public class SoundsBlock : IBlock {
      private TagReference _sound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SoundsBlock() {
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
    public class PlayerInformationBlock : IBlock {
      private TagReference _unit = new TagReference();
      private Pad _unnamed;
      private Real _walkingSpeed = new Real();
      private Real _doubleSpeedMultiplier = new Real();
      private Real _runForward = new Real();
      private Real _runBackward = new Real();
      private Real _runSideways = new Real();
      private Real _runAcceleration = new Real();
      private Real _sneakForward = new Real();
      private Real _sneakBackward = new Real();
      private Real _sneakSideways = new Real();
      private Real _sneakAcceleration = new Real();
      private Real _airborneAcceleration = new Real();
      private Real _speedMultiplier = new Real();
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
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public PlayerInformationBlock() {
        this._unnamed = new Pad(28);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(44);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unit.Value);
references.Add(_coopRespawnEffect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
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
      public Real WalkingSpeed {
        get {
          return this._walkingSpeed;
        }
        set {
          this._walkingSpeed = value;
        }
      }
      public Real doubleSpeedMultiplier {
        get {
          return this._doubleSpeedMultiplier;
        }
        set {
          this._doubleSpeedMultiplier = value;
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
      public Real SpeedMultiplier {
        get {
          return this._speedMultiplier;
        }
        set {
          this._speedMultiplier = value;
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
      public virtual void Read(BinaryReader reader) {
        _unit.Read(reader);
        _unnamed.Read(reader);
        _walkingSpeed.Read(reader);
        _doubleSpeedMultiplier.Read(reader);
        _runForward.Read(reader);
        _runBackward.Read(reader);
        _runSideways.Read(reader);
        _runAcceleration.Read(reader);
        _sneakForward.Read(reader);
        _sneakBackward.Read(reader);
        _sneakSideways.Read(reader);
        _sneakAcceleration.Read(reader);
        _airborneAcceleration.Read(reader);
        _speedMultiplier.Read(reader);
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
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unit.ReadString(reader);
        _coopRespawnEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unit.Write(bw);
        _unnamed.Write(bw);
        _walkingSpeed.Write(bw);
        _doubleSpeedMultiplier.Write(bw);
        _runForward.Write(bw);
        _runBackward.Write(bw);
        _runSideways.Write(bw);
        _runAcceleration.Write(bw);
        _sneakForward.Write(bw);
        _sneakBackward.Write(bw);
        _sneakSideways.Write(bw);
        _sneakAcceleration.Write(bw);
        _airborneAcceleration.Write(bw);
        _speedMultiplier.Write(bw);
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
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unit.WriteString(writer);
        _coopRespawnEffect.WriteString(writer);
      }
    }
    public class FirstPersonInterfaceBlock : IBlock {
      private TagReference _firstPersonHands = new TagReference();
      private TagReference _baseBitmap = new TagReference();
      private TagReference _shieldMeter = new TagReference();
      private Point2D _shieldMeterOrigin = new Point2D();
      private TagReference _bodyMeter = new TagReference();
      private Point2D _bodyMeterOrigin = new Point2D();
      private TagReference _nigh = new TagReference();
      private TagReference _nigh2 = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public FirstPersonInterfaceBlock() {
        this._unnamed = new Pad(88);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_firstPersonHands.Value);
references.Add(_baseBitmap.Value);
references.Add(_shieldMeter.Value);
references.Add(_bodyMeter.Value);
references.Add(_nigh.Value);
references.Add(_nigh2.Value);
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
      public TagReference BaseBitmap {
        get {
          return this._baseBitmap;
        }
        set {
          this._baseBitmap = value;
        }
      }
      public TagReference ShieldMeter {
        get {
          return this._shieldMeter;
        }
        set {
          this._shieldMeter = value;
        }
      }
      public Point2D ShieldMeterOrigin {
        get {
          return this._shieldMeterOrigin;
        }
        set {
          this._shieldMeterOrigin = value;
        }
      }
      public TagReference BodyMeter {
        get {
          return this._bodyMeter;
        }
        set {
          this._bodyMeter = value;
        }
      }
      public Point2D BodyMeterOrigin {
        get {
          return this._bodyMeterOrigin;
        }
        set {
          this._bodyMeterOrigin = value;
        }
      }
      public TagReference Nigh {
        get {
          return this._nigh;
        }
        set {
          this._nigh = value;
        }
      }
      public TagReference Nigh2 {
        get {
          return this._nigh2;
        }
        set {
          this._nigh2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _firstPersonHands.Read(reader);
        _baseBitmap.Read(reader);
        _shieldMeter.Read(reader);
        _shieldMeterOrigin.Read(reader);
        _bodyMeter.Read(reader);
        _bodyMeterOrigin.Read(reader);
        _nigh.Read(reader);
        _nigh2.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _firstPersonHands.ReadString(reader);
        _baseBitmap.ReadString(reader);
        _shieldMeter.ReadString(reader);
        _bodyMeter.ReadString(reader);
        _nigh.ReadString(reader);
        _nigh2.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _firstPersonHands.Write(bw);
        _baseBitmap.Write(bw);
        _shieldMeter.Write(bw);
        _shieldMeterOrigin.Write(bw);
        _bodyMeter.Write(bw);
        _bodyMeterOrigin.Write(bw);
        _nigh.Write(bw);
        _nigh2.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _firstPersonHands.WriteString(writer);
        _baseBitmap.WriteString(writer);
        _shieldMeter.WriteString(writer);
        _bodyMeter.WriteString(writer);
        _nigh.WriteString(writer);
        _nigh2.WriteString(writer);
      }
    }
    public class FallingDamageBlock : IBlock {
      private Pad _unnamed;
      private RealBounds _harmfulFallingDistance = new RealBounds();
      private TagReference _fallingDamage = new TagReference();
      private Pad _unnamed2;
      private Real _maximumFallingDistance = new Real();
      private TagReference _distanceDamage = new TagReference();
      private TagReference _vehicleEnvironemtnCollisionDamageEffect = new TagReference();
      private TagReference _vehicleKilledUnitDamageEffect = new TagReference();
      private TagReference _vehicleCollisionDamage = new TagReference();
      private TagReference _flamingDeathDamage = new TagReference();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public FallingDamageBlock() {
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(28);
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
        _unnamed.Read(reader);
        _harmfulFallingDistance.Read(reader);
        _fallingDamage.Read(reader);
        _unnamed2.Read(reader);
        _maximumFallingDistance.Read(reader);
        _distanceDamage.Read(reader);
        _vehicleEnvironemtnCollisionDamageEffect.Read(reader);
        _vehicleKilledUnitDamageEffect.Read(reader);
        _vehicleCollisionDamage.Read(reader);
        _flamingDeathDamage.Read(reader);
        _unnamed3.Read(reader);
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
        _unnamed.Write(bw);
        _harmfulFallingDistance.Write(bw);
        _fallingDamage.Write(bw);
        _unnamed2.Write(bw);
        _maximumFallingDistance.Write(bw);
        _distanceDamage.Write(bw);
        _vehicleEnvironemtnCollisionDamageEffect.Write(bw);
        _vehicleKilledUnitDamageEffect.Write(bw);
        _vehicleCollisionDamage.Write(bw);
        _flamingDeathDamage.Write(bw);
        _unnamed3.Write(bw);
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
    public class MaterialsBlock : IBlock {
      private Pad _unnamed;
      private Pad _unnamed2;
      private Real _groundFrictionScale = new Real();
      private Real _groundFrictionNormalK1Scale = new Real();
      private Real _groundFrictionNormalK0Scale = new Real();
      private Real _groundDepthScale = new Real();
      private Real _groundDampFractionScale = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Real _maximumVitality = new Real();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private TagReference _effect = new TagReference();
      private TagReference _sound = new TagReference();
      private Pad _unnamed7;
      private Block _particleEffects = new Block();
      private Pad _unnamed8;
      private TagReference _meleeHitSound = new TagReference();
      public BlockCollection<BreakableSurfaceParticleEffectBlock> _particleEffectsList = new BlockCollection<BreakableSurfaceParticleEffectBlock>();
public event System.EventHandler BlockNameChanged;
      public MaterialsBlock() {
        this._unnamed = new Pad(100);
        this._unnamed2 = new Pad(48);
        this._unnamed3 = new Pad(76);
        this._unnamed4 = new Pad(480);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(24);
        this._unnamed8 = new Pad(60);
      }
      public BlockCollection<BreakableSurfaceParticleEffectBlock> ParticleEffects {
        get {
          return this._particleEffectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_effect.Value);
references.Add(_sound.Value);
references.Add(_meleeHitSound.Value);
for (int x=0; x<ParticleEffects.BlockCount; x++)
{
  IBlock block = ParticleEffects.GetBlock(x);
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
      public Real MaximumVitality {
        get {
          return this._maximumVitality;
        }
        set {
          this._maximumVitality = value;
        }
      }
      public TagReference Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
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
      public TagReference MeleeHitSound {
        get {
          return this._meleeHitSound;
        }
        set {
          this._meleeHitSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _groundFrictionScale.Read(reader);
        _groundFrictionNormalK1Scale.Read(reader);
        _groundFrictionNormalK0Scale.Read(reader);
        _groundDepthScale.Read(reader);
        _groundDampFractionScale.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _maximumVitality.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _effect.Read(reader);
        _sound.Read(reader);
        _unnamed7.Read(reader);
        _particleEffects.Read(reader);
        _unnamed8.Read(reader);
        _meleeHitSound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _effect.ReadString(reader);
        _sound.ReadString(reader);
        for (x = 0; (x < _particleEffects.Count); x = (x + 1)) {
          ParticleEffects.Add(new BreakableSurfaceParticleEffectBlock());
          ParticleEffects[x].Read(reader);
        }
        for (x = 0; (x < _particleEffects.Count); x = (x + 1)) {
          ParticleEffects[x].ReadChildData(reader);
        }
        _meleeHitSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _groundFrictionScale.Write(bw);
        _groundFrictionNormalK1Scale.Write(bw);
        _groundFrictionNormalK0Scale.Write(bw);
        _groundDepthScale.Write(bw);
        _groundDampFractionScale.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _maximumVitality.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _effect.Write(bw);
        _sound.Write(bw);
        _unnamed7.Write(bw);
_particleEffects.Count = ParticleEffects.Count;
        _particleEffects.Write(bw);
        _unnamed8.Write(bw);
        _meleeHitSound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _effect.WriteString(writer);
        _sound.WriteString(writer);
        for (x = 0; (x < _particleEffects.Count); x = (x + 1)) {
          ParticleEffects[x].Write(writer);
        }
        for (x = 0; (x < _particleEffects.Count); x = (x + 1)) {
          ParticleEffects[x].WriteChildData(writer);
        }
        _meleeHitSound.WriteString(writer);
      }
    }
    public class BreakableSurfaceParticleEffectBlock : IBlock {
      private TagReference _particleType = new TagReference();
      private Flags _flags;
      private Real _density = new Real();
      private RealBounds _velocityScale = new RealBounds();
      private Pad _unnamed;
      private AngleBounds _angularVelocity = new AngleBounds();
      private Pad _unnamed2;
      private RealBounds _radius = new RealBounds();
      private Pad _unnamed3;
      private RealARGBColor _tintLowerBound = new RealARGBColor();
      private RealARGBColor _tintUpperBound = new RealARGBColor();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public BreakableSurfaceParticleEffectBlock() {
if (this._particleType is System.ComponentModel.INotifyPropertyChanged)
  (this._particleType as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_particleType.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _particleType.ToString();
        }
      }
      public TagReference ParticleType {
        get {
          return this._particleType;
        }
        set {
          this._particleType = value;
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
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public RealBounds VelocityScale {
        get {
          return this._velocityScale;
        }
        set {
          this._velocityScale = value;
        }
      }
      public AngleBounds AngularVelocity {
        get {
          return this._angularVelocity;
        }
        set {
          this._angularVelocity = value;
        }
      }
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealARGBColor TintLowerBound {
        get {
          return this._tintLowerBound;
        }
        set {
          this._tintLowerBound = value;
        }
      }
      public RealARGBColor TintUpperBound {
        get {
          return this._tintUpperBound;
        }
        set {
          this._tintUpperBound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _particleType.Read(reader);
        _flags.Read(reader);
        _density.Read(reader);
        _velocityScale.Read(reader);
        _unnamed.Read(reader);
        _angularVelocity.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _unnamed3.Read(reader);
        _tintLowerBound.Read(reader);
        _tintUpperBound.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _particleType.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _particleType.Write(bw);
        _flags.Write(bw);
        _density.Write(bw);
        _velocityScale.Write(bw);
        _unnamed.Write(bw);
        _angularVelocity.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _unnamed3.Write(bw);
        _tintLowerBound.Write(bw);
        _tintUpperBound.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _particleType.WriteString(writer);
      }
    }
    public class PlaylistAutogenerateChoiceBlock : IBlock {
      private FixedLengthString _mapName = new FixedLengthString();
      private FixedLengthString _gameVariant = new FixedLengthString();
      private LongInteger _minimumExperience = new LongInteger();
      private LongInteger _maximumExperience = new LongInteger();
      private LongInteger _minimumPlayerCount = new LongInteger();
      private LongInteger _maximumPlayerCount = new LongInteger();
      private LongInteger _rating = new LongInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public PlaylistAutogenerateChoiceBlock() {
        this._unnamed = new Pad(64);
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
      public FixedLengthString MapName {
        get {
          return this._mapName;
        }
        set {
          this._mapName = value;
        }
      }
      public FixedLengthString GameVariant {
        get {
          return this._gameVariant;
        }
        set {
          this._gameVariant = value;
        }
      }
      public LongInteger MinimumExperience {
        get {
          return this._minimumExperience;
        }
        set {
          this._minimumExperience = value;
        }
      }
      public LongInteger MaximumExperience {
        get {
          return this._maximumExperience;
        }
        set {
          this._maximumExperience = value;
        }
      }
      public LongInteger MinimumPlayerCount {
        get {
          return this._minimumPlayerCount;
        }
        set {
          this._minimumPlayerCount = value;
        }
      }
      public LongInteger MaximumPlayerCount {
        get {
          return this._maximumPlayerCount;
        }
        set {
          this._maximumPlayerCount = value;
        }
      }
      public LongInteger Rating {
        get {
          return this._rating;
        }
        set {
          this._rating = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mapName.Read(reader);
        _gameVariant.Read(reader);
        _minimumExperience.Read(reader);
        _maximumExperience.Read(reader);
        _minimumPlayerCount.Read(reader);
        _maximumPlayerCount.Read(reader);
        _rating.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _mapName.Write(bw);
        _gameVariant.Write(bw);
        _minimumExperience.Write(bw);
        _maximumExperience.Write(bw);
        _minimumPlayerCount.Write(bw);
        _maximumPlayerCount.Write(bw);
        _rating.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
