// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'unit' (derived from 'object')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class unit : @object {
    private UnitLipsyncScalesStructBlockBlock unitValues = new UnitLipsyncScalesStructBlockBlock();
    public virtual UnitLipsyncScalesStructBlockBlock UnitValues {
      get {
        return unitValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(UnitValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "unit";
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
base.Read(reader);
unitValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
unitValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
unitValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
unitValues.WriteChildData(writer);
    }
    #endregion
    public class UnitLipsyncScalesStructBlockBlock : IBlock {
      private Flags _flags;
      private Enum _defaultTeam;
      private Enum _constantSoundVolume;
      private TagReference _integratedLightToggle = new TagReference();
      private Angle _cameraFieldOfView = new Angle();
      private Real _cameraStiffness = new Real();
      private StringId _cameraMarkerName = new StringId();
      private StringId _cameraSubmergedMarkerName = new StringId();
      private Angle _pitchAuto_Minuslevel = new Angle();
      private AngleBounds _pitchRange = new AngleBounds();
      private Block _cameraTracks = new Block();
      private RealVector3D _accelerationRange = new RealVector3D();
      private Real _accelActionScale = new Real();
      private Real _accelAttachScale = new Real();
      private Real _softPingThreshold = new Real();
      private Real _softPingInterruptTime = new Real();
      private Real _hardPingThreshold = new Real();
      private Real _hardPingInterruptTime = new Real();
      private Real _hardDeathThreshold = new Real();
      private Real _feignDeathThreshold = new Real();
      private Real _feignDeathTime = new Real();
      private Real _distanceOfEvadeAnim = new Real();
      private Real _distanceOfDiveAnim = new Real();
      private Real _stunnedMovementThreshold = new Real();
      private Real _feignDeathChance = new Real();
      private Real _feignRepeatChance = new Real();
      private TagReference _spawnedTurretCharacter = new TagReference();
      private ShortIntegerBounds _spawnedActorCount = new ShortIntegerBounds();
      private Real _spawnedVelocity = new Real();
      private Angle _aimingVelocityMaximum = new Angle();
      private Angle _aimingAccelerationMaximum = new Angle();
      private RealFraction _casualAimingModifier = new RealFraction();
      private Angle _lookingVelocityMaximum = new Angle();
      private Angle _lookingAccelerationMaximum = new Angle();
      private StringId _righthandnode = new StringId();
      private StringId _lefthandnode = new StringId();
      private StringId _preferredgunnode = new StringId();
      private TagReference _meleeDamage = new TagReference();
      private TagReference _boardingMeleeDamage = new TagReference();
      private TagReference _boardingMeleeResponse = new TagReference();
      private TagReference _landingMeleeDamage = new TagReference();
      private TagReference _flurryMeleeDamage = new TagReference();
      private TagReference _obstacleSmashDamage = new TagReference();
      private Enum _motionSensorBlipSize;
      private Pad _unnamed0;
      private Block _postures = new Block();
      private Block _nEWHUDINTERFACES = new Block();
      private Block _dialogueVariants = new Block();
      private Real _grenadeVelocity = new Real();
      private Enum _grenadeType;
      private ShortInteger _grenadeCount = new ShortInteger();
      private Block _poweredSeats = new Block();
      private Block _weapons = new Block();
      private Block _seats = new Block();
      private Real _boostPeakPower = new Real();
      private Real _boostRisePower = new Real();
      private Real _boostPeakTime = new Real();
      private Real _boostFallPower = new Real();
      private Real _deadTime = new Real();
      private RealFraction _attackWeight = new RealFraction();
      private RealFraction _decayWeight = new RealFraction();
      public BlockCollection<UnitCameraTrackBlockBlock> _cameraTracksList = new BlockCollection<UnitCameraTrackBlockBlock>();
      public BlockCollection<UnitPosturesBlockBlock> _posturesList = new BlockCollection<UnitPosturesBlockBlock>();
      public BlockCollection<UnitHudReferenceBlockBlock> _nEWHUDINTERFACESList = new BlockCollection<UnitHudReferenceBlockBlock>();
      public BlockCollection<DialogueVariantBlockBlock> _dialogueVariantsList = new BlockCollection<DialogueVariantBlockBlock>();
      public BlockCollection<PoweredSeatBlockBlock> _poweredSeatsList = new BlockCollection<PoweredSeatBlockBlock>();
      public BlockCollection<UnitWeaponBlockBlock> _weaponsList = new BlockCollection<UnitWeaponBlockBlock>();
      public BlockCollection<UnitSeatBlockBlock> _seatsList = new BlockCollection<UnitSeatBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UnitLipsyncScalesStructBlockBlock() {
        this._flags = new Flags(4);
        this._defaultTeam = new Enum(2);
        this._constantSoundVolume = new Enum(2);
        this._motionSensorBlipSize = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._grenadeType = new Enum(2);
      }
      public BlockCollection<UnitCameraTrackBlockBlock> CameraTracks {
        get {
          return this._cameraTracksList;
        }
      }
      public BlockCollection<UnitPosturesBlockBlock> Postures {
        get {
          return this._posturesList;
        }
      }
      public BlockCollection<UnitHudReferenceBlockBlock> NEWHUDINTERFACES {
        get {
          return this._nEWHUDINTERFACESList;
        }
      }
      public BlockCollection<DialogueVariantBlockBlock> DialogueVariants {
        get {
          return this._dialogueVariantsList;
        }
      }
      public BlockCollection<PoweredSeatBlockBlock> PoweredSeats {
        get {
          return this._poweredSeatsList;
        }
      }
      public BlockCollection<UnitWeaponBlockBlock> Weapons {
        get {
          return this._weaponsList;
        }
      }
      public BlockCollection<UnitSeatBlockBlock> Seats {
        get {
          return this._seatsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_integratedLightToggle.Value);
references.Add(_spawnedTurretCharacter.Value);
references.Add(_meleeDamage.Value);
references.Add(_boardingMeleeDamage.Value);
references.Add(_boardingMeleeResponse.Value);
references.Add(_landingMeleeDamage.Value);
references.Add(_flurryMeleeDamage.Value);
references.Add(_obstacleSmashDamage.Value);
for (int x=0; x<CameraTracks.BlockCount; x++)
{
  IBlock block = CameraTracks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Postures.BlockCount; x++)
{
  IBlock block = Postures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NEWHUDINTERFACES.BlockCount; x++)
{
  IBlock block = NEWHUDINTERFACES.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DialogueVariants.BlockCount; x++)
{
  IBlock block = DialogueVariants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PoweredSeats.BlockCount; x++)
{
  IBlock block = PoweredSeats.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Weapons.BlockCount; x++)
{
  IBlock block = Weapons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Seats.BlockCount; x++)
{
  IBlock block = Seats.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum DefaultTeam {
        get {
          return this._defaultTeam;
        }
        set {
          this._defaultTeam = value;
        }
      }
      public Enum ConstantSoundVolume {
        get {
          return this._constantSoundVolume;
        }
        set {
          this._constantSoundVolume = value;
        }
      }
      public TagReference IntegratedLightToggle {
        get {
          return this._integratedLightToggle;
        }
        set {
          this._integratedLightToggle = value;
        }
      }
      public Angle CameraFieldOfView {
        get {
          return this._cameraFieldOfView;
        }
        set {
          this._cameraFieldOfView = value;
        }
      }
      public Real CameraStiffness {
        get {
          return this._cameraStiffness;
        }
        set {
          this._cameraStiffness = value;
        }
      }
      public StringId CameraMarkerName {
        get {
          return this._cameraMarkerName;
        }
        set {
          this._cameraMarkerName = value;
        }
      }
      public StringId CameraSubmergedMarkerName {
        get {
          return this._cameraSubmergedMarkerName;
        }
        set {
          this._cameraSubmergedMarkerName = value;
        }
      }
      public Angle PitchAuto_Minuslevel {
        get {
          return this._pitchAuto_Minuslevel;
        }
        set {
          this._pitchAuto_Minuslevel = value;
        }
      }
      public AngleBounds PitchRange {
        get {
          return this._pitchRange;
        }
        set {
          this._pitchRange = value;
        }
      }
      public RealVector3D AccelerationRange {
        get {
          return this._accelerationRange;
        }
        set {
          this._accelerationRange = value;
        }
      }
      public Real AccelActionScale {
        get {
          return this._accelActionScale;
        }
        set {
          this._accelActionScale = value;
        }
      }
      public Real AccelAttachScale {
        get {
          return this._accelAttachScale;
        }
        set {
          this._accelAttachScale = value;
        }
      }
      public Real SoftPingThreshold {
        get {
          return this._softPingThreshold;
        }
        set {
          this._softPingThreshold = value;
        }
      }
      public Real SoftPingInterruptTime {
        get {
          return this._softPingInterruptTime;
        }
        set {
          this._softPingInterruptTime = value;
        }
      }
      public Real HardPingThreshold {
        get {
          return this._hardPingThreshold;
        }
        set {
          this._hardPingThreshold = value;
        }
      }
      public Real HardPingInterruptTime {
        get {
          return this._hardPingInterruptTime;
        }
        set {
          this._hardPingInterruptTime = value;
        }
      }
      public Real HardDeathThreshold {
        get {
          return this._hardDeathThreshold;
        }
        set {
          this._hardDeathThreshold = value;
        }
      }
      public Real FeignDeathThreshold {
        get {
          return this._feignDeathThreshold;
        }
        set {
          this._feignDeathThreshold = value;
        }
      }
      public Real FeignDeathTime {
        get {
          return this._feignDeathTime;
        }
        set {
          this._feignDeathTime = value;
        }
      }
      public Real DistanceOfEvadeAnim {
        get {
          return this._distanceOfEvadeAnim;
        }
        set {
          this._distanceOfEvadeAnim = value;
        }
      }
      public Real DistanceOfDiveAnim {
        get {
          return this._distanceOfDiveAnim;
        }
        set {
          this._distanceOfDiveAnim = value;
        }
      }
      public Real StunnedMovementThreshold {
        get {
          return this._stunnedMovementThreshold;
        }
        set {
          this._stunnedMovementThreshold = value;
        }
      }
      public Real FeignDeathChance {
        get {
          return this._feignDeathChance;
        }
        set {
          this._feignDeathChance = value;
        }
      }
      public Real FeignRepeatChance {
        get {
          return this._feignRepeatChance;
        }
        set {
          this._feignRepeatChance = value;
        }
      }
      public TagReference SpawnedTurretCharacter {
        get {
          return this._spawnedTurretCharacter;
        }
        set {
          this._spawnedTurretCharacter = value;
        }
      }
      public ShortIntegerBounds SpawnedActorCount {
        get {
          return this._spawnedActorCount;
        }
        set {
          this._spawnedActorCount = value;
        }
      }
      public Real SpawnedVelocity {
        get {
          return this._spawnedVelocity;
        }
        set {
          this._spawnedVelocity = value;
        }
      }
      public Angle AimingVelocityMaximum {
        get {
          return this._aimingVelocityMaximum;
        }
        set {
          this._aimingVelocityMaximum = value;
        }
      }
      public Angle AimingAccelerationMaximum {
        get {
          return this._aimingAccelerationMaximum;
        }
        set {
          this._aimingAccelerationMaximum = value;
        }
      }
      public RealFraction CasualAimingModifier {
        get {
          return this._casualAimingModifier;
        }
        set {
          this._casualAimingModifier = value;
        }
      }
      public Angle LookingVelocityMaximum {
        get {
          return this._lookingVelocityMaximum;
        }
        set {
          this._lookingVelocityMaximum = value;
        }
      }
      public Angle LookingAccelerationMaximum {
        get {
          return this._lookingAccelerationMaximum;
        }
        set {
          this._lookingAccelerationMaximum = value;
        }
      }
      public StringId Righthandnode {
        get {
          return this._righthandnode;
        }
        set {
          this._righthandnode = value;
        }
      }
      public StringId Lefthandnode {
        get {
          return this._lefthandnode;
        }
        set {
          this._lefthandnode = value;
        }
      }
      public StringId Preferredgunnode {
        get {
          return this._preferredgunnode;
        }
        set {
          this._preferredgunnode = value;
        }
      }
      public TagReference MeleeDamage {
        get {
          return this._meleeDamage;
        }
        set {
          this._meleeDamage = value;
        }
      }
      public TagReference BoardingMeleeDamage {
        get {
          return this._boardingMeleeDamage;
        }
        set {
          this._boardingMeleeDamage = value;
        }
      }
      public TagReference BoardingMeleeResponse {
        get {
          return this._boardingMeleeResponse;
        }
        set {
          this._boardingMeleeResponse = value;
        }
      }
      public TagReference LandingMeleeDamage {
        get {
          return this._landingMeleeDamage;
        }
        set {
          this._landingMeleeDamage = value;
        }
      }
      public TagReference FlurryMeleeDamage {
        get {
          return this._flurryMeleeDamage;
        }
        set {
          this._flurryMeleeDamage = value;
        }
      }
      public TagReference ObstacleSmashDamage {
        get {
          return this._obstacleSmashDamage;
        }
        set {
          this._obstacleSmashDamage = value;
        }
      }
      public Enum MotionSensorBlipSize {
        get {
          return this._motionSensorBlipSize;
        }
        set {
          this._motionSensorBlipSize = value;
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
      public Enum GrenadeType {
        get {
          return this._grenadeType;
        }
        set {
          this._grenadeType = value;
        }
      }
      public ShortInteger GrenadeCount {
        get {
          return this._grenadeCount;
        }
        set {
          this._grenadeCount = value;
        }
      }
      public Real BoostPeakPower {
        get {
          return this._boostPeakPower;
        }
        set {
          this._boostPeakPower = value;
        }
      }
      public Real BoostRisePower {
        get {
          return this._boostRisePower;
        }
        set {
          this._boostRisePower = value;
        }
      }
      public Real BoostPeakTime {
        get {
          return this._boostPeakTime;
        }
        set {
          this._boostPeakTime = value;
        }
      }
      public Real BoostFallPower {
        get {
          return this._boostFallPower;
        }
        set {
          this._boostFallPower = value;
        }
      }
      public Real DeadTime {
        get {
          return this._deadTime;
        }
        set {
          this._deadTime = value;
        }
      }
      public RealFraction AttackWeight {
        get {
          return this._attackWeight;
        }
        set {
          this._attackWeight = value;
        }
      }
      public RealFraction DecayWeight {
        get {
          return this._decayWeight;
        }
        set {
          this._decayWeight = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _defaultTeam.Read(reader);
        _constantSoundVolume.Read(reader);
        _integratedLightToggle.Read(reader);
        _cameraFieldOfView.Read(reader);
        _cameraStiffness.Read(reader);
        _cameraMarkerName.Read(reader);
        _cameraSubmergedMarkerName.Read(reader);
        _pitchAuto_Minuslevel.Read(reader);
        _pitchRange.Read(reader);
        _cameraTracks.Read(reader);
        _accelerationRange.Read(reader);
        _accelActionScale.Read(reader);
        _accelAttachScale.Read(reader);
        _softPingThreshold.Read(reader);
        _softPingInterruptTime.Read(reader);
        _hardPingThreshold.Read(reader);
        _hardPingInterruptTime.Read(reader);
        _hardDeathThreshold.Read(reader);
        _feignDeathThreshold.Read(reader);
        _feignDeathTime.Read(reader);
        _distanceOfEvadeAnim.Read(reader);
        _distanceOfDiveAnim.Read(reader);
        _stunnedMovementThreshold.Read(reader);
        _feignDeathChance.Read(reader);
        _feignRepeatChance.Read(reader);
        _spawnedTurretCharacter.Read(reader);
        _spawnedActorCount.Read(reader);
        _spawnedVelocity.Read(reader);
        _aimingVelocityMaximum.Read(reader);
        _aimingAccelerationMaximum.Read(reader);
        _casualAimingModifier.Read(reader);
        _lookingVelocityMaximum.Read(reader);
        _lookingAccelerationMaximum.Read(reader);
        _righthandnode.Read(reader);
        _lefthandnode.Read(reader);
        _preferredgunnode.Read(reader);
        _meleeDamage.Read(reader);
        _boardingMeleeDamage.Read(reader);
        _boardingMeleeResponse.Read(reader);
        _landingMeleeDamage.Read(reader);
        _flurryMeleeDamage.Read(reader);
        _obstacleSmashDamage.Read(reader);
        _motionSensorBlipSize.Read(reader);
        _unnamed0.Read(reader);
        _postures.Read(reader);
        _nEWHUDINTERFACES.Read(reader);
        _dialogueVariants.Read(reader);
        _grenadeVelocity.Read(reader);
        _grenadeType.Read(reader);
        _grenadeCount.Read(reader);
        _poweredSeats.Read(reader);
        _weapons.Read(reader);
        _seats.Read(reader);
        _boostPeakPower.Read(reader);
        _boostRisePower.Read(reader);
        _boostPeakTime.Read(reader);
        _boostFallPower.Read(reader);
        _deadTime.Read(reader);
        _attackWeight.Read(reader);
        _decayWeight.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _integratedLightToggle.ReadString(reader);
        _cameraMarkerName.ReadString(reader);
        _cameraSubmergedMarkerName.ReadString(reader);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks.Add(new UnitCameraTrackBlockBlock());
          CameraTracks[x].Read(reader);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].ReadChildData(reader);
        }
        _spawnedTurretCharacter.ReadString(reader);
        _righthandnode.ReadString(reader);
        _lefthandnode.ReadString(reader);
        _preferredgunnode.ReadString(reader);
        _meleeDamage.ReadString(reader);
        _boardingMeleeDamage.ReadString(reader);
        _boardingMeleeResponse.ReadString(reader);
        _landingMeleeDamage.ReadString(reader);
        _flurryMeleeDamage.ReadString(reader);
        _obstacleSmashDamage.ReadString(reader);
        for (x = 0; (x < _postures.Count); x = (x + 1)) {
          Postures.Add(new UnitPosturesBlockBlock());
          Postures[x].Read(reader);
        }
        for (x = 0; (x < _postures.Count); x = (x + 1)) {
          Postures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1)) {
          NEWHUDINTERFACES.Add(new UnitHudReferenceBlockBlock());
          NEWHUDINTERFACES[x].Read(reader);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1)) {
          NEWHUDINTERFACES[x].ReadChildData(reader);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1)) {
          DialogueVariants.Add(new DialogueVariantBlockBlock());
          DialogueVariants[x].Read(reader);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1)) {
          DialogueVariants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1)) {
          PoweredSeats.Add(new PoweredSeatBlockBlock());
          PoweredSeats[x].Read(reader);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1)) {
          PoweredSeats[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons.Add(new UnitWeaponBlockBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1)) {
          Seats.Add(new UnitSeatBlockBlock());
          Seats[x].Read(reader);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1)) {
          Seats[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _defaultTeam.Write(bw);
        _constantSoundVolume.Write(bw);
        _integratedLightToggle.Write(bw);
        _cameraFieldOfView.Write(bw);
        _cameraStiffness.Write(bw);
        _cameraMarkerName.Write(bw);
        _cameraSubmergedMarkerName.Write(bw);
        _pitchAuto_Minuslevel.Write(bw);
        _pitchRange.Write(bw);
_cameraTracks.Count = CameraTracks.Count;
        _cameraTracks.Write(bw);
        _accelerationRange.Write(bw);
        _accelActionScale.Write(bw);
        _accelAttachScale.Write(bw);
        _softPingThreshold.Write(bw);
        _softPingInterruptTime.Write(bw);
        _hardPingThreshold.Write(bw);
        _hardPingInterruptTime.Write(bw);
        _hardDeathThreshold.Write(bw);
        _feignDeathThreshold.Write(bw);
        _feignDeathTime.Write(bw);
        _distanceOfEvadeAnim.Write(bw);
        _distanceOfDiveAnim.Write(bw);
        _stunnedMovementThreshold.Write(bw);
        _feignDeathChance.Write(bw);
        _feignRepeatChance.Write(bw);
        _spawnedTurretCharacter.Write(bw);
        _spawnedActorCount.Write(bw);
        _spawnedVelocity.Write(bw);
        _aimingVelocityMaximum.Write(bw);
        _aimingAccelerationMaximum.Write(bw);
        _casualAimingModifier.Write(bw);
        _lookingVelocityMaximum.Write(bw);
        _lookingAccelerationMaximum.Write(bw);
        _righthandnode.Write(bw);
        _lefthandnode.Write(bw);
        _preferredgunnode.Write(bw);
        _meleeDamage.Write(bw);
        _boardingMeleeDamage.Write(bw);
        _boardingMeleeResponse.Write(bw);
        _landingMeleeDamage.Write(bw);
        _flurryMeleeDamage.Write(bw);
        _obstacleSmashDamage.Write(bw);
        _motionSensorBlipSize.Write(bw);
        _unnamed0.Write(bw);
_postures.Count = Postures.Count;
        _postures.Write(bw);
_nEWHUDINTERFACES.Count = NEWHUDINTERFACES.Count;
        _nEWHUDINTERFACES.Write(bw);
_dialogueVariants.Count = DialogueVariants.Count;
        _dialogueVariants.Write(bw);
        _grenadeVelocity.Write(bw);
        _grenadeType.Write(bw);
        _grenadeCount.Write(bw);
_poweredSeats.Count = PoweredSeats.Count;
        _poweredSeats.Write(bw);
_weapons.Count = Weapons.Count;
        _weapons.Write(bw);
_seats.Count = Seats.Count;
        _seats.Write(bw);
        _boostPeakPower.Write(bw);
        _boostRisePower.Write(bw);
        _boostPeakTime.Write(bw);
        _boostFallPower.Write(bw);
        _deadTime.Write(bw);
        _attackWeight.Write(bw);
        _decayWeight.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _integratedLightToggle.WriteString(writer);
        _cameraMarkerName.WriteString(writer);
        _cameraSubmergedMarkerName.WriteString(writer);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].Write(writer);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].WriteChildData(writer);
        }
        _spawnedTurretCharacter.WriteString(writer);
        _righthandnode.WriteString(writer);
        _lefthandnode.WriteString(writer);
        _preferredgunnode.WriteString(writer);
        _meleeDamage.WriteString(writer);
        _boardingMeleeDamage.WriteString(writer);
        _boardingMeleeResponse.WriteString(writer);
        _landingMeleeDamage.WriteString(writer);
        _flurryMeleeDamage.WriteString(writer);
        _obstacleSmashDamage.WriteString(writer);
        for (x = 0; (x < _postures.Count); x = (x + 1)) {
          Postures[x].Write(writer);
        }
        for (x = 0; (x < _postures.Count); x = (x + 1)) {
          Postures[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1)) {
          NEWHUDINTERFACES[x].Write(writer);
        }
        for (x = 0; (x < _nEWHUDINTERFACES.Count); x = (x + 1)) {
          NEWHUDINTERFACES[x].WriteChildData(writer);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1)) {
          DialogueVariants[x].Write(writer);
        }
        for (x = 0; (x < _dialogueVariants.Count); x = (x + 1)) {
          DialogueVariants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1)) {
          PoweredSeats[x].Write(writer);
        }
        for (x = 0; (x < _poweredSeats.Count); x = (x + 1)) {
          PoweredSeats[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].Write(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1)) {
          Seats[x].Write(writer);
        }
        for (x = 0; (x < _seats.Count); x = (x + 1)) {
          Seats[x].WriteChildData(writer);
        }
      }
    }
    public class UnitCameraTrackBlockBlock : IBlock {
      private TagReference _track = new TagReference();
public event System.EventHandler BlockNameChanged;
      public UnitCameraTrackBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_track.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Track {
        get {
          return this._track;
        }
        set {
          this._track = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _track.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _track.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _track.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _track.WriteString(writer);
      }
    }
    public class UnitPosturesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private RealVector3D _pillOffset = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public UnitPosturesBlockBlock() {
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
      public RealVector3D PillOffset {
        get {
          return this._pillOffset;
        }
        set {
          this._pillOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _pillOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _pillOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class UnitHudReferenceBlockBlock : IBlock {
      private TagReference _newUnitHudInterface = new TagReference();
public event System.EventHandler BlockNameChanged;
      public UnitHudReferenceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_newUnitHudInterface.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference NewUnitHudInterface {
        get {
          return this._newUnitHudInterface;
        }
        set {
          this._newUnitHudInterface = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _newUnitHudInterface.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _newUnitHudInterface.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _newUnitHudInterface.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _newUnitHudInterface.WriteString(writer);
      }
    }
    public class DialogueVariantBlockBlock : IBlock {
      private ShortInteger _variantNumber = new ShortInteger();
      private Pad _unnamed0;
      private TagReference _dialogue = new TagReference();
public event System.EventHandler BlockNameChanged;
      public DialogueVariantBlockBlock() {
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dialogue.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortInteger VariantNumber {
        get {
          return this._variantNumber;
        }
        set {
          this._variantNumber = value;
        }
      }
      public TagReference Dialogue {
        get {
          return this._dialogue;
        }
        set {
          this._dialogue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _variantNumber.Read(reader);
        _unnamed0.Read(reader);
        _dialogue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _dialogue.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _variantNumber.Write(bw);
        _unnamed0.Write(bw);
        _dialogue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _dialogue.WriteString(writer);
      }
    }
    public class PoweredSeatBlockBlock : IBlock {
      private Real _driverPowerupTime = new Real();
      private Real _driverPowerdownTime = new Real();
public event System.EventHandler BlockNameChanged;
      public PoweredSeatBlockBlock() {
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
      public Real DriverPowerupTime {
        get {
          return this._driverPowerupTime;
        }
        set {
          this._driverPowerupTime = value;
        }
      }
      public Real DriverPowerdownTime {
        get {
          return this._driverPowerdownTime;
        }
        set {
          this._driverPowerdownTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _driverPowerupTime.Read(reader);
        _driverPowerdownTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _driverPowerupTime.Write(bw);
        _driverPowerdownTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UnitWeaponBlockBlock : IBlock {
      private TagReference _weapon = new TagReference();
public event System.EventHandler BlockNameChanged;
      public UnitWeaponBlockBlock() {
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
    public class UnitSeatBlockBlock : IBlock {
      private Flags _flags;
      private StringId _label = new StringId();
      private StringId _markerName = new StringId();
      private StringId _entryMarkersName = new StringId();
      private StringId _boardingGrenadeMarker = new StringId();
      private StringId _boardingGrenadeString = new StringId();
      private StringId _boardingMeleeString = new StringId();
      private RealFraction _pingScale = new RealFraction();
      private Real _turnoverTime = new Real();
      private RealVector3D _accelerationRange = new RealVector3D();
      private Real _accelActionScale = new Real();
      private Real _accelAttachScale = new Real();
      private Real _aIScariness = new Real();
      private Enum _aiSeatType;
      private ShortBlockIndex _boardingSeat = new ShortBlockIndex();
      private RealFraction _listenerInterpolationFactor = new RealFraction();
      private RealBounds _yawRateBounds = new RealBounds();
      private RealBounds _pitchRateBounds = new RealBounds();
      private Real _minSpeedReference = new Real();
      private Real _maxSpeedReference = new Real();
      private Real _speedExponent = new Real();
      private StringId _cameraMarkerName = new StringId();
      private StringId _cameraSubmergedMarkerName = new StringId();
      private Angle _pitchAuto_Minuslevel = new Angle();
      private AngleBounds _pitchRange = new AngleBounds();
      private Block _cameraTracks = new Block();
      private Block _unitHudInterface = new Block();
      private StringId _enterSeatString = new StringId();
      private Angle _yawMinimum = new Angle();
      private Angle _yawMaximum = new Angle();
      private TagReference _built_MinusinGunner = new TagReference();
      private Real _entryRadius = new Real();
      private Angle _entryMarkerConeAngle = new Angle();
      private Angle _entryMarkerFacingAngle = new Angle();
      private Real _maximumRelativeVelocity = new Real();
      private StringId _invisibleSeatRegion = new StringId();
      private LongInteger _runtimeInvisibleSeatRegionIndex = new LongInteger();
      public BlockCollection<UnitCameraTrackBlockBlock> _cameraTracksList = new BlockCollection<UnitCameraTrackBlockBlock>();
      public BlockCollection<UnitHudReferenceBlockBlock> _unitHudInterfaceList = new BlockCollection<UnitHudReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UnitSeatBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._aiSeatType = new Enum(2);
      }
      public BlockCollection<UnitCameraTrackBlockBlock> CameraTracks {
        get {
          return this._cameraTracksList;
        }
      }
      public BlockCollection<UnitHudReferenceBlockBlock> UnitHudInterface {
        get {
          return this._unitHudInterfaceList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_built_MinusinGunner.Value);
for (int x=0; x<CameraTracks.BlockCount; x++)
{
  IBlock block = CameraTracks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<UnitHudInterface.BlockCount; x++)
{
  IBlock block = UnitHudInterface.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _label.ToString();
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
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public StringId MarkerName {
        get {
          return this._markerName;
        }
        set {
          this._markerName = value;
        }
      }
      public StringId EntryMarkersName {
        get {
          return this._entryMarkersName;
        }
        set {
          this._entryMarkersName = value;
        }
      }
      public StringId BoardingGrenadeMarker {
        get {
          return this._boardingGrenadeMarker;
        }
        set {
          this._boardingGrenadeMarker = value;
        }
      }
      public StringId BoardingGrenadeString {
        get {
          return this._boardingGrenadeString;
        }
        set {
          this._boardingGrenadeString = value;
        }
      }
      public StringId BoardingMeleeString {
        get {
          return this._boardingMeleeString;
        }
        set {
          this._boardingMeleeString = value;
        }
      }
      public RealFraction PingScale {
        get {
          return this._pingScale;
        }
        set {
          this._pingScale = value;
        }
      }
      public Real TurnoverTime {
        get {
          return this._turnoverTime;
        }
        set {
          this._turnoverTime = value;
        }
      }
      public RealVector3D AccelerationRange {
        get {
          return this._accelerationRange;
        }
        set {
          this._accelerationRange = value;
        }
      }
      public Real AccelActionScale {
        get {
          return this._accelActionScale;
        }
        set {
          this._accelActionScale = value;
        }
      }
      public Real AccelAttachScale {
        get {
          return this._accelAttachScale;
        }
        set {
          this._accelAttachScale = value;
        }
      }
      public Real AIScariness {
        get {
          return this._aIScariness;
        }
        set {
          this._aIScariness = value;
        }
      }
      public Enum AiSeatType {
        get {
          return this._aiSeatType;
        }
        set {
          this._aiSeatType = value;
        }
      }
      public ShortBlockIndex BoardingSeat {
        get {
          return this._boardingSeat;
        }
        set {
          this._boardingSeat = value;
        }
      }
      public RealFraction ListenerInterpolationFactor {
        get {
          return this._listenerInterpolationFactor;
        }
        set {
          this._listenerInterpolationFactor = value;
        }
      }
      public RealBounds YawRateBounds {
        get {
          return this._yawRateBounds;
        }
        set {
          this._yawRateBounds = value;
        }
      }
      public RealBounds PitchRateBounds {
        get {
          return this._pitchRateBounds;
        }
        set {
          this._pitchRateBounds = value;
        }
      }
      public Real MinSpeedReference {
        get {
          return this._minSpeedReference;
        }
        set {
          this._minSpeedReference = value;
        }
      }
      public Real MaxSpeedReference {
        get {
          return this._maxSpeedReference;
        }
        set {
          this._maxSpeedReference = value;
        }
      }
      public Real SpeedExponent {
        get {
          return this._speedExponent;
        }
        set {
          this._speedExponent = value;
        }
      }
      public StringId CameraMarkerName {
        get {
          return this._cameraMarkerName;
        }
        set {
          this._cameraMarkerName = value;
        }
      }
      public StringId CameraSubmergedMarkerName {
        get {
          return this._cameraSubmergedMarkerName;
        }
        set {
          this._cameraSubmergedMarkerName = value;
        }
      }
      public Angle PitchAuto_Minuslevel {
        get {
          return this._pitchAuto_Minuslevel;
        }
        set {
          this._pitchAuto_Minuslevel = value;
        }
      }
      public AngleBounds PitchRange {
        get {
          return this._pitchRange;
        }
        set {
          this._pitchRange = value;
        }
      }
      public StringId EnterSeatString {
        get {
          return this._enterSeatString;
        }
        set {
          this._enterSeatString = value;
        }
      }
      public Angle YawMinimum {
        get {
          return this._yawMinimum;
        }
        set {
          this._yawMinimum = value;
        }
      }
      public Angle YawMaximum {
        get {
          return this._yawMaximum;
        }
        set {
          this._yawMaximum = value;
        }
      }
      public TagReference Built_MinusinGunner {
        get {
          return this._built_MinusinGunner;
        }
        set {
          this._built_MinusinGunner = value;
        }
      }
      public Real EntryRadius {
        get {
          return this._entryRadius;
        }
        set {
          this._entryRadius = value;
        }
      }
      public Angle EntryMarkerConeAngle {
        get {
          return this._entryMarkerConeAngle;
        }
        set {
          this._entryMarkerConeAngle = value;
        }
      }
      public Angle EntryMarkerFacingAngle {
        get {
          return this._entryMarkerFacingAngle;
        }
        set {
          this._entryMarkerFacingAngle = value;
        }
      }
      public Real MaximumRelativeVelocity {
        get {
          return this._maximumRelativeVelocity;
        }
        set {
          this._maximumRelativeVelocity = value;
        }
      }
      public StringId InvisibleSeatRegion {
        get {
          return this._invisibleSeatRegion;
        }
        set {
          this._invisibleSeatRegion = value;
        }
      }
      public LongInteger RuntimeInvisibleSeatRegionIndex {
        get {
          return this._runtimeInvisibleSeatRegionIndex;
        }
        set {
          this._runtimeInvisibleSeatRegionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _label.Read(reader);
        _markerName.Read(reader);
        _entryMarkersName.Read(reader);
        _boardingGrenadeMarker.Read(reader);
        _boardingGrenadeString.Read(reader);
        _boardingMeleeString.Read(reader);
        _pingScale.Read(reader);
        _turnoverTime.Read(reader);
        _accelerationRange.Read(reader);
        _accelActionScale.Read(reader);
        _accelAttachScale.Read(reader);
        _aIScariness.Read(reader);
        _aiSeatType.Read(reader);
        _boardingSeat.Read(reader);
        _listenerInterpolationFactor.Read(reader);
        _yawRateBounds.Read(reader);
        _pitchRateBounds.Read(reader);
        _minSpeedReference.Read(reader);
        _maxSpeedReference.Read(reader);
        _speedExponent.Read(reader);
        _cameraMarkerName.Read(reader);
        _cameraSubmergedMarkerName.Read(reader);
        _pitchAuto_Minuslevel.Read(reader);
        _pitchRange.Read(reader);
        _cameraTracks.Read(reader);
        _unitHudInterface.Read(reader);
        _enterSeatString.Read(reader);
        _yawMinimum.Read(reader);
        _yawMaximum.Read(reader);
        _built_MinusinGunner.Read(reader);
        _entryRadius.Read(reader);
        _entryMarkerConeAngle.Read(reader);
        _entryMarkerFacingAngle.Read(reader);
        _maximumRelativeVelocity.Read(reader);
        _invisibleSeatRegion.Read(reader);
        _runtimeInvisibleSeatRegionIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _label.ReadString(reader);
        _markerName.ReadString(reader);
        _entryMarkersName.ReadString(reader);
        _boardingGrenadeMarker.ReadString(reader);
        _boardingGrenadeString.ReadString(reader);
        _boardingMeleeString.ReadString(reader);
        _cameraMarkerName.ReadString(reader);
        _cameraSubmergedMarkerName.ReadString(reader);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks.Add(new UnitCameraTrackBlockBlock());
          CameraTracks[x].Read(reader);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1)) {
          UnitHudInterface.Add(new UnitHudReferenceBlockBlock());
          UnitHudInterface[x].Read(reader);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1)) {
          UnitHudInterface[x].ReadChildData(reader);
        }
        _enterSeatString.ReadString(reader);
        _built_MinusinGunner.ReadString(reader);
        _invisibleSeatRegion.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _label.Write(bw);
        _markerName.Write(bw);
        _entryMarkersName.Write(bw);
        _boardingGrenadeMarker.Write(bw);
        _boardingGrenadeString.Write(bw);
        _boardingMeleeString.Write(bw);
        _pingScale.Write(bw);
        _turnoverTime.Write(bw);
        _accelerationRange.Write(bw);
        _accelActionScale.Write(bw);
        _accelAttachScale.Write(bw);
        _aIScariness.Write(bw);
        _aiSeatType.Write(bw);
        _boardingSeat.Write(bw);
        _listenerInterpolationFactor.Write(bw);
        _yawRateBounds.Write(bw);
        _pitchRateBounds.Write(bw);
        _minSpeedReference.Write(bw);
        _maxSpeedReference.Write(bw);
        _speedExponent.Write(bw);
        _cameraMarkerName.Write(bw);
        _cameraSubmergedMarkerName.Write(bw);
        _pitchAuto_Minuslevel.Write(bw);
        _pitchRange.Write(bw);
_cameraTracks.Count = CameraTracks.Count;
        _cameraTracks.Write(bw);
_unitHudInterface.Count = UnitHudInterface.Count;
        _unitHudInterface.Write(bw);
        _enterSeatString.Write(bw);
        _yawMinimum.Write(bw);
        _yawMaximum.Write(bw);
        _built_MinusinGunner.Write(bw);
        _entryRadius.Write(bw);
        _entryMarkerConeAngle.Write(bw);
        _entryMarkerFacingAngle.Write(bw);
        _maximumRelativeVelocity.Write(bw);
        _invisibleSeatRegion.Write(bw);
        _runtimeInvisibleSeatRegionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _label.WriteString(writer);
        _markerName.WriteString(writer);
        _entryMarkersName.WriteString(writer);
        _boardingGrenadeMarker.WriteString(writer);
        _boardingGrenadeString.WriteString(writer);
        _boardingMeleeString.WriteString(writer);
        _cameraMarkerName.WriteString(writer);
        _cameraSubmergedMarkerName.WriteString(writer);
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].Write(writer);
        }
        for (x = 0; (x < _cameraTracks.Count); x = (x + 1)) {
          CameraTracks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1)) {
          UnitHudInterface[x].Write(writer);
        }
        for (x = 0; (x < _unitHudInterface.Count); x = (x + 1)) {
          UnitHudInterface[x].WriteChildData(writer);
        }
        _enterSeatString.WriteString(writer);
        _built_MinusinGunner.WriteString(writer);
        _invisibleSeatRegion.WriteString(writer);
      }
    }
  }
}
