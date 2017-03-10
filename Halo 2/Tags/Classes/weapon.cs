// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'weapon' (derived from 'item')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class weapon : item {
    private WeaponSharedInterfaceStructBlockBlock weaponValues = new WeaponSharedInterfaceStructBlockBlock();
    public virtual WeaponSharedInterfaceStructBlockBlock WeaponValues {
      get {
        return weaponValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(WeaponValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "weapon";
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
weaponValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
weaponValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
weaponValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
weaponValues.WriteChildData(writer);
    }
    #endregion
    public class WeaponSharedInterfaceStructBlockBlock : IBlock {
      private Flags _flags;
      private StringId _unnamed0 = new StringId();
      private Enum _secondaryTriggerMode;
      private ShortInteger _maximumAlternateShotsLoaded = new ShortInteger();
      private Real _turnOnTime = new Real();
      private Real _readyTime = new Real();
      private TagReference _readyEffect = new TagReference();
      private TagReference _readyDamageEffect = new TagReference();
      private RealFraction _heatRecoveryThreshold = new RealFraction();
      private RealFraction _overheatedThreshold = new RealFraction();
      private RealFraction _heatDetonationThreshold = new RealFraction();
      private RealFraction _heatDetonationFraction = new RealFraction();
      private RealFraction _heatLossPerSecond = new RealFraction();
      private RealFraction _heatIllumination = new RealFraction();
      private RealFraction _overheatedHeatLossPerSecond = new RealFraction();
      private TagReference _overheated = new TagReference();
      private TagReference _overheatedDamageEffect = new TagReference();
      private TagReference _detonation = new TagReference();
      private TagReference _detonationDamageEffect = new TagReference();
      private TagReference _playerMeleeDamage = new TagReference();
      private TagReference _playerMeleeResponse = new TagReference();
      private Angle _magnetismAngle = new Angle();
      private Real _magnetismRange = new Real();
      private Real _throttleMagnitude = new Real();
      private Real _throttleMinimumDistance = new Real();
      private Angle _throttleMaximumAdjustmentAngle = new Angle();
      private RealEulerAngles2D _damagePyramidAngles = new RealEulerAngles2D();
      private Real _damagePyramidDepth = new Real();
      private TagReference @__1stHitMeleeDamage = new TagReference();
      private TagReference @__1stHitMeleeResponse = new TagReference();
      private TagReference @__2ndHitMeleeDamage = new TagReference();
      private TagReference @__2ndHitMeleeResponse = new TagReference();
      private TagReference @__3rdHitMeleeDamage = new TagReference();
      private TagReference @__3rdHitMeleeResponse = new TagReference();
      private TagReference _lungeMeleeDamage = new TagReference();
      private TagReference _lungeMeleeResponse = new TagReference();
      private Enum _meleeDamageReportingType;
      private Pad _unnamed1;
      private ShortInteger _magnificationLevels = new ShortInteger();
      private RealBounds _magnificationRange = new RealBounds();
      private Angle _autoaimAngle = new Angle();
      private Real _autoaimRange = new Real();
      private Angle _magnetismAngle2 = new Angle();
      private Real _magnetismRange2 = new Real();
      private Angle _deviationAngle = new Angle();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Enum _movementPenalized;
      private Pad _unnamed4;
      private RealFraction _forwardMovementPenalty = new RealFraction();
      private RealFraction _sidewaysMovementPenalty = new RealFraction();
      private Real _aIScariness = new Real();
      private Real _weaponPower_MinusonTime = new Real();
      private Real _weaponPower_MinusoffTime = new Real();
      private TagReference _weaponPower_MinusonEffect = new TagReference();
      private TagReference _weaponPower_MinusoffEffect = new TagReference();
      private Real _ageHeatRecoveryPenalty = new Real();
      private Real _ageRateOfFirePenalty = new Real();
      private RealFraction _ageMisfireStart = new RealFraction();
      private RealFraction _ageMisfireChance = new RealFraction();
      private TagReference _pickupSound = new TagReference();
      private TagReference _zoom_MinusinSound = new TagReference();
      private TagReference _zoom_MinusoutSound = new TagReference();
      private Real _activeCamoDing = new Real();
      private Real _activeCamoRegrowthRate = new Real();
      private StringId _handleNode = new StringId();
      private StringId _weaponClass = new StringId();
      private StringId _weaponName = new StringId();
      private Enum _multiplayerWeaponType;
      private Enum _weaponType;
      private Enum _trackingType;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _firstPerson = new Block();
      private TagReference _newHudInterface = new TagReference();
      private Block _predictedResources = new Block();
      private Block _magazines = new Block();
      private Block _newTriggers = new Block();
      private Block _barrels = new Block();
      private Pad _unnamed7;
      private Real _maxMovementAcceleration = new Real();
      private Real _maxMovementVelocity = new Real();
      private Real _maxTurningAcceleration = new Real();
      private Real _maxTurningVelocity = new Real();
      private TagReference _deployedVehicle = new TagReference();
      private TagReference _ageEffect = new TagReference();
      private TagReference _agedWeapon = new TagReference();
      private RealVector3D _firstPersonWeaponOffset = new RealVector3D();
      private RealVector2D _firstPersonScopeSize = new RealVector2D();
      public BlockCollection<WeaponFirstPersonInterfaceBlockBlock> _firstPersonList = new BlockCollection<WeaponFirstPersonInterfaceBlockBlock>();
      public BlockCollection<PredictedResourceBlockBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlockBlock>();
      public BlockCollection<MagazinesBlock> _magazinesList = new BlockCollection<MagazinesBlock>();
      public BlockCollection<WeaponTriggersBlock> _newTriggersList = new BlockCollection<WeaponTriggersBlock>();
      public BlockCollection<WeaponBarrelsBlock> _barrelsList = new BlockCollection<WeaponBarrelsBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponSharedInterfaceStructBlockBlock() {
        this._flags = new Flags(4);
        this._secondaryTriggerMode = new Enum(2);
        this._meleeDamageReportingType = new Enum(1);
        this._unnamed1 = new Pad(1);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(12);
        this._movementPenalized = new Enum(2);
        this._unnamed4 = new Pad(2);
        this._multiplayerWeaponType = new Enum(2);
        this._weaponType = new Enum(2);
        this._trackingType = new Enum(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(16);
        this._unnamed7 = new Pad(8);
      }
      public BlockCollection<WeaponFirstPersonInterfaceBlockBlock> FirstPerson {
        get {
          return this._firstPersonList;
        }
      }
      public BlockCollection<PredictedResourceBlockBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<MagazinesBlock> Magazines {
        get {
          return this._magazinesList;
        }
      }
      public BlockCollection<WeaponTriggersBlock> NewTriggers {
        get {
          return this._newTriggersList;
        }
      }
      public BlockCollection<WeaponBarrelsBlock> Barrels {
        get {
          return this._barrelsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_readyEffect.Value);
references.Add(_readyDamageEffect.Value);
references.Add(_overheated.Value);
references.Add(_overheatedDamageEffect.Value);
references.Add(_detonation.Value);
references.Add(_detonationDamageEffect.Value);
references.Add(_playerMeleeDamage.Value);
references.Add(_playerMeleeResponse.Value);
references.Add(__1stHitMeleeDamage.Value);
references.Add(__1stHitMeleeResponse.Value);
references.Add(__2ndHitMeleeDamage.Value);
references.Add(__2ndHitMeleeResponse.Value);
references.Add(__3rdHitMeleeDamage.Value);
references.Add(__3rdHitMeleeResponse.Value);
references.Add(_lungeMeleeDamage.Value);
references.Add(_lungeMeleeResponse.Value);
references.Add(_weaponPower_MinusonEffect.Value);
references.Add(_weaponPower_MinusoffEffect.Value);
references.Add(_pickupSound.Value);
references.Add(_zoom_MinusinSound.Value);
references.Add(_zoom_MinusoutSound.Value);
references.Add(_newHudInterface.Value);
references.Add(_deployedVehicle.Value);
references.Add(_ageEffect.Value);
references.Add(_agedWeapon.Value);
for (int x=0; x<FirstPerson.BlockCount; x++)
{
  IBlock block = FirstPerson.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Magazines.BlockCount; x++)
{
  IBlock block = Magazines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NewTriggers.BlockCount; x++)
{
  IBlock block = NewTriggers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Barrels.BlockCount; x++)
{
  IBlock block = Barrels.GetBlock(x);
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
      public StringId unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public Enum SecondaryTriggerMode {
        get {
          return this._secondaryTriggerMode;
        }
        set {
          this._secondaryTriggerMode = value;
        }
      }
      public ShortInteger MaximumAlternateShotsLoaded {
        get {
          return this._maximumAlternateShotsLoaded;
        }
        set {
          this._maximumAlternateShotsLoaded = value;
        }
      }
      public Real TurnOnTime {
        get {
          return this._turnOnTime;
        }
        set {
          this._turnOnTime = value;
        }
      }
      public Real ReadyTime {
        get {
          return this._readyTime;
        }
        set {
          this._readyTime = value;
        }
      }
      public TagReference ReadyEffect {
        get {
          return this._readyEffect;
        }
        set {
          this._readyEffect = value;
        }
      }
      public TagReference ReadyDamageEffect {
        get {
          return this._readyDamageEffect;
        }
        set {
          this._readyDamageEffect = value;
        }
      }
      public RealFraction HeatRecoveryThreshold {
        get {
          return this._heatRecoveryThreshold;
        }
        set {
          this._heatRecoveryThreshold = value;
        }
      }
      public RealFraction OverheatedThreshold {
        get {
          return this._overheatedThreshold;
        }
        set {
          this._overheatedThreshold = value;
        }
      }
      public RealFraction HeatDetonationThreshold {
        get {
          return this._heatDetonationThreshold;
        }
        set {
          this._heatDetonationThreshold = value;
        }
      }
      public RealFraction HeatDetonationFraction {
        get {
          return this._heatDetonationFraction;
        }
        set {
          this._heatDetonationFraction = value;
        }
      }
      public RealFraction HeatLossPerSecond {
        get {
          return this._heatLossPerSecond;
        }
        set {
          this._heatLossPerSecond = value;
        }
      }
      public RealFraction HeatIllumination {
        get {
          return this._heatIllumination;
        }
        set {
          this._heatIllumination = value;
        }
      }
      public RealFraction OverheatedHeatLossPerSecond {
        get {
          return this._overheatedHeatLossPerSecond;
        }
        set {
          this._overheatedHeatLossPerSecond = value;
        }
      }
      public TagReference Overheated {
        get {
          return this._overheated;
        }
        set {
          this._overheated = value;
        }
      }
      public TagReference OverheatedDamageEffect {
        get {
          return this._overheatedDamageEffect;
        }
        set {
          this._overheatedDamageEffect = value;
        }
      }
      public TagReference Detonation {
        get {
          return this._detonation;
        }
        set {
          this._detonation = value;
        }
      }
      public TagReference DetonationDamageEffect {
        get {
          return this._detonationDamageEffect;
        }
        set {
          this._detonationDamageEffect = value;
        }
      }
      public TagReference PlayerMeleeDamage {
        get {
          return this._playerMeleeDamage;
        }
        set {
          this._playerMeleeDamage = value;
        }
      }
      public TagReference PlayerMeleeResponse {
        get {
          return this._playerMeleeResponse;
        }
        set {
          this._playerMeleeResponse = value;
        }
      }
      public Angle MagnetismAngle {
        get {
          return this._magnetismAngle;
        }
        set {
          this._magnetismAngle = value;
        }
      }
      public Real MagnetismRange {
        get {
          return this._magnetismRange;
        }
        set {
          this._magnetismRange = value;
        }
      }
      public Real ThrottleMagnitude {
        get {
          return this._throttleMagnitude;
        }
        set {
          this._throttleMagnitude = value;
        }
      }
      public Real ThrottleMinimumDistance {
        get {
          return this._throttleMinimumDistance;
        }
        set {
          this._throttleMinimumDistance = value;
        }
      }
      public Angle ThrottleMaximumAdjustmentAngle {
        get {
          return this._throttleMaximumAdjustmentAngle;
        }
        set {
          this._throttleMaximumAdjustmentAngle = value;
        }
      }
      public RealEulerAngles2D DamagePyramidAngles {
        get {
          return this._damagePyramidAngles;
        }
        set {
          this._damagePyramidAngles = value;
        }
      }
      public Real DamagePyramidDepth {
        get {
          return this._damagePyramidDepth;
        }
        set {
          this._damagePyramidDepth = value;
        }
      }
      public TagReference _1stHitMeleeDamage {
        get {
          return this.@__1stHitMeleeDamage;
        }
        set {
          this.@__1stHitMeleeDamage = value;
        }
      }
      public TagReference _1stHitMeleeResponse {
        get {
          return this.@__1stHitMeleeResponse;
        }
        set {
          this.@__1stHitMeleeResponse = value;
        }
      }
      public TagReference _2ndHitMeleeDamage {
        get {
          return this.@__2ndHitMeleeDamage;
        }
        set {
          this.@__2ndHitMeleeDamage = value;
        }
      }
      public TagReference _2ndHitMeleeResponse {
        get {
          return this.@__2ndHitMeleeResponse;
        }
        set {
          this.@__2ndHitMeleeResponse = value;
        }
      }
      public TagReference _3rdHitMeleeDamage {
        get {
          return this.@__3rdHitMeleeDamage;
        }
        set {
          this.@__3rdHitMeleeDamage = value;
        }
      }
      public TagReference _3rdHitMeleeResponse {
        get {
          return this.@__3rdHitMeleeResponse;
        }
        set {
          this.@__3rdHitMeleeResponse = value;
        }
      }
      public TagReference LungeMeleeDamage {
        get {
          return this._lungeMeleeDamage;
        }
        set {
          this._lungeMeleeDamage = value;
        }
      }
      public TagReference LungeMeleeResponse {
        get {
          return this._lungeMeleeResponse;
        }
        set {
          this._lungeMeleeResponse = value;
        }
      }
      public Enum MeleeDamageReportingType {
        get {
          return this._meleeDamageReportingType;
        }
        set {
          this._meleeDamageReportingType = value;
        }
      }
      public ShortInteger MagnificationLevels {
        get {
          return this._magnificationLevels;
        }
        set {
          this._magnificationLevels = value;
        }
      }
      public RealBounds MagnificationRange {
        get {
          return this._magnificationRange;
        }
        set {
          this._magnificationRange = value;
        }
      }
      public Angle AutoaimAngle {
        get {
          return this._autoaimAngle;
        }
        set {
          this._autoaimAngle = value;
        }
      }
      public Real AutoaimRange {
        get {
          return this._autoaimRange;
        }
        set {
          this._autoaimRange = value;
        }
      }
      public Angle MagnetismAngle2 {
        get {
          return this._magnetismAngle2;
        }
        set {
          this._magnetismAngle2 = value;
        }
      }
      public Real MagnetismRange2 {
        get {
          return this._magnetismRange2;
        }
        set {
          this._magnetismRange2 = value;
        }
      }
      public Angle DeviationAngle {
        get {
          return this._deviationAngle;
        }
        set {
          this._deviationAngle = value;
        }
      }
      public Enum MovementPenalized {
        get {
          return this._movementPenalized;
        }
        set {
          this._movementPenalized = value;
        }
      }
      public RealFraction ForwardMovementPenalty {
        get {
          return this._forwardMovementPenalty;
        }
        set {
          this._forwardMovementPenalty = value;
        }
      }
      public RealFraction SidewaysMovementPenalty {
        get {
          return this._sidewaysMovementPenalty;
        }
        set {
          this._sidewaysMovementPenalty = value;
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
      public Real WeaponPower_MinusonTime {
        get {
          return this._weaponPower_MinusonTime;
        }
        set {
          this._weaponPower_MinusonTime = value;
        }
      }
      public Real WeaponPower_MinusoffTime {
        get {
          return this._weaponPower_MinusoffTime;
        }
        set {
          this._weaponPower_MinusoffTime = value;
        }
      }
      public TagReference WeaponPower_MinusonEffect {
        get {
          return this._weaponPower_MinusonEffect;
        }
        set {
          this._weaponPower_MinusonEffect = value;
        }
      }
      public TagReference WeaponPower_MinusoffEffect {
        get {
          return this._weaponPower_MinusoffEffect;
        }
        set {
          this._weaponPower_MinusoffEffect = value;
        }
      }
      public Real AgeHeatRecoveryPenalty {
        get {
          return this._ageHeatRecoveryPenalty;
        }
        set {
          this._ageHeatRecoveryPenalty = value;
        }
      }
      public Real AgeRateOfFirePenalty {
        get {
          return this._ageRateOfFirePenalty;
        }
        set {
          this._ageRateOfFirePenalty = value;
        }
      }
      public RealFraction AgeMisfireStart {
        get {
          return this._ageMisfireStart;
        }
        set {
          this._ageMisfireStart = value;
        }
      }
      public RealFraction AgeMisfireChance {
        get {
          return this._ageMisfireChance;
        }
        set {
          this._ageMisfireChance = value;
        }
      }
      public TagReference PickupSound {
        get {
          return this._pickupSound;
        }
        set {
          this._pickupSound = value;
        }
      }
      public TagReference Zoom_MinusinSound {
        get {
          return this._zoom_MinusinSound;
        }
        set {
          this._zoom_MinusinSound = value;
        }
      }
      public TagReference Zoom_MinusoutSound {
        get {
          return this._zoom_MinusoutSound;
        }
        set {
          this._zoom_MinusoutSound = value;
        }
      }
      public Real ActiveCamoDing {
        get {
          return this._activeCamoDing;
        }
        set {
          this._activeCamoDing = value;
        }
      }
      public Real ActiveCamoRegrowthRate {
        get {
          return this._activeCamoRegrowthRate;
        }
        set {
          this._activeCamoRegrowthRate = value;
        }
      }
      public StringId HandleNode {
        get {
          return this._handleNode;
        }
        set {
          this._handleNode = value;
        }
      }
      public StringId WeaponClass {
        get {
          return this._weaponClass;
        }
        set {
          this._weaponClass = value;
        }
      }
      public StringId WeaponName {
        get {
          return this._weaponName;
        }
        set {
          this._weaponName = value;
        }
      }
      public Enum MultiplayerWeaponType {
        get {
          return this._multiplayerWeaponType;
        }
        set {
          this._multiplayerWeaponType = value;
        }
      }
      public Enum WeaponType {
        get {
          return this._weaponType;
        }
        set {
          this._weaponType = value;
        }
      }
      public Enum TrackingType {
        get {
          return this._trackingType;
        }
        set {
          this._trackingType = value;
        }
      }
      public TagReference NewHudInterface {
        get {
          return this._newHudInterface;
        }
        set {
          this._newHudInterface = value;
        }
      }
      public Real MaxMovementAcceleration {
        get {
          return this._maxMovementAcceleration;
        }
        set {
          this._maxMovementAcceleration = value;
        }
      }
      public Real MaxMovementVelocity {
        get {
          return this._maxMovementVelocity;
        }
        set {
          this._maxMovementVelocity = value;
        }
      }
      public Real MaxTurningAcceleration {
        get {
          return this._maxTurningAcceleration;
        }
        set {
          this._maxTurningAcceleration = value;
        }
      }
      public Real MaxTurningVelocity {
        get {
          return this._maxTurningVelocity;
        }
        set {
          this._maxTurningVelocity = value;
        }
      }
      public TagReference DeployedVehicle {
        get {
          return this._deployedVehicle;
        }
        set {
          this._deployedVehicle = value;
        }
      }
      public TagReference AgeEffect {
        get {
          return this._ageEffect;
        }
        set {
          this._ageEffect = value;
        }
      }
      public TagReference AgedWeapon {
        get {
          return this._agedWeapon;
        }
        set {
          this._agedWeapon = value;
        }
      }
      public RealVector3D FirstPersonWeaponOffset {
        get {
          return this._firstPersonWeaponOffset;
        }
        set {
          this._firstPersonWeaponOffset = value;
        }
      }
      public RealVector2D FirstPersonScopeSize {
        get {
          return this._firstPersonScopeSize;
        }
        set {
          this._firstPersonScopeSize = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _secondaryTriggerMode.Read(reader);
        _maximumAlternateShotsLoaded.Read(reader);
        _turnOnTime.Read(reader);
        _readyTime.Read(reader);
        _readyEffect.Read(reader);
        _readyDamageEffect.Read(reader);
        _heatRecoveryThreshold.Read(reader);
        _overheatedThreshold.Read(reader);
        _heatDetonationThreshold.Read(reader);
        _heatDetonationFraction.Read(reader);
        _heatLossPerSecond.Read(reader);
        _heatIllumination.Read(reader);
        _overheatedHeatLossPerSecond.Read(reader);
        _overheated.Read(reader);
        _overheatedDamageEffect.Read(reader);
        _detonation.Read(reader);
        _detonationDamageEffect.Read(reader);
        _playerMeleeDamage.Read(reader);
        _playerMeleeResponse.Read(reader);
        _magnetismAngle.Read(reader);
        _magnetismRange.Read(reader);
        _throttleMagnitude.Read(reader);
        _throttleMinimumDistance.Read(reader);
        _throttleMaximumAdjustmentAngle.Read(reader);
        _damagePyramidAngles.Read(reader);
        _damagePyramidDepth.Read(reader);
        @__1stHitMeleeDamage.Read(reader);
        @__1stHitMeleeResponse.Read(reader);
        @__2ndHitMeleeDamage.Read(reader);
        @__2ndHitMeleeResponse.Read(reader);
        @__3rdHitMeleeDamage.Read(reader);
        @__3rdHitMeleeResponse.Read(reader);
        _lungeMeleeDamage.Read(reader);
        _lungeMeleeResponse.Read(reader);
        _meleeDamageReportingType.Read(reader);
        _unnamed1.Read(reader);
        _magnificationLevels.Read(reader);
        _magnificationRange.Read(reader);
        _autoaimAngle.Read(reader);
        _autoaimRange.Read(reader);
        _magnetismAngle2.Read(reader);
        _magnetismRange2.Read(reader);
        _deviationAngle.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _movementPenalized.Read(reader);
        _unnamed4.Read(reader);
        _forwardMovementPenalty.Read(reader);
        _sidewaysMovementPenalty.Read(reader);
        _aIScariness.Read(reader);
        _weaponPower_MinusonTime.Read(reader);
        _weaponPower_MinusoffTime.Read(reader);
        _weaponPower_MinusonEffect.Read(reader);
        _weaponPower_MinusoffEffect.Read(reader);
        _ageHeatRecoveryPenalty.Read(reader);
        _ageRateOfFirePenalty.Read(reader);
        _ageMisfireStart.Read(reader);
        _ageMisfireChance.Read(reader);
        _pickupSound.Read(reader);
        _zoom_MinusinSound.Read(reader);
        _zoom_MinusoutSound.Read(reader);
        _activeCamoDing.Read(reader);
        _activeCamoRegrowthRate.Read(reader);
        _handleNode.Read(reader);
        _weaponClass.Read(reader);
        _weaponName.Read(reader);
        _multiplayerWeaponType.Read(reader);
        _weaponType.Read(reader);
        _trackingType.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _firstPerson.Read(reader);
        _newHudInterface.Read(reader);
        _predictedResources.Read(reader);
        _magazines.Read(reader);
        _newTriggers.Read(reader);
        _barrels.Read(reader);
        _unnamed7.Read(reader);
        _maxMovementAcceleration.Read(reader);
        _maxMovementVelocity.Read(reader);
        _maxTurningAcceleration.Read(reader);
        _maxTurningVelocity.Read(reader);
        _deployedVehicle.Read(reader);
        _ageEffect.Read(reader);
        _agedWeapon.Read(reader);
        _firstPersonWeaponOffset.Read(reader);
        _firstPersonScopeSize.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _unnamed0.ReadString(reader);
        _readyEffect.ReadString(reader);
        _readyDamageEffect.ReadString(reader);
        _overheated.ReadString(reader);
        _overheatedDamageEffect.ReadString(reader);
        _detonation.ReadString(reader);
        _detonationDamageEffect.ReadString(reader);
        _playerMeleeDamage.ReadString(reader);
        _playerMeleeResponse.ReadString(reader);
        @__1stHitMeleeDamage.ReadString(reader);
        @__1stHitMeleeResponse.ReadString(reader);
        @__2ndHitMeleeDamage.ReadString(reader);
        @__2ndHitMeleeResponse.ReadString(reader);
        @__3rdHitMeleeDamage.ReadString(reader);
        @__3rdHitMeleeResponse.ReadString(reader);
        _lungeMeleeDamage.ReadString(reader);
        _lungeMeleeResponse.ReadString(reader);
        _weaponPower_MinusonEffect.ReadString(reader);
        _weaponPower_MinusoffEffect.ReadString(reader);
        _pickupSound.ReadString(reader);
        _zoom_MinusinSound.ReadString(reader);
        _zoom_MinusoutSound.ReadString(reader);
        _handleNode.ReadString(reader);
        _weaponClass.ReadString(reader);
        _weaponName.ReadString(reader);
        for (x = 0; (x < _firstPerson.Count); x = (x + 1)) {
          FirstPerson.Add(new WeaponFirstPersonInterfaceBlockBlock());
          FirstPerson[x].Read(reader);
        }
        for (x = 0; (x < _firstPerson.Count); x = (x + 1)) {
          FirstPerson[x].ReadChildData(reader);
        }
        _newHudInterface.ReadString(reader);
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlockBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines.Add(new MagazinesBlock());
          Magazines[x].Read(reader);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _newTriggers.Count); x = (x + 1)) {
          NewTriggers.Add(new WeaponTriggersBlock());
          NewTriggers[x].Read(reader);
        }
        for (x = 0; (x < _newTriggers.Count); x = (x + 1)) {
          NewTriggers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _barrels.Count); x = (x + 1)) {
          Barrels.Add(new WeaponBarrelsBlock());
          Barrels[x].Read(reader);
        }
        for (x = 0; (x < _barrels.Count); x = (x + 1)) {
          Barrels[x].ReadChildData(reader);
        }
        _deployedVehicle.ReadString(reader);
        _ageEffect.ReadString(reader);
        _agedWeapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _secondaryTriggerMode.Write(bw);
        _maximumAlternateShotsLoaded.Write(bw);
        _turnOnTime.Write(bw);
        _readyTime.Write(bw);
        _readyEffect.Write(bw);
        _readyDamageEffect.Write(bw);
        _heatRecoveryThreshold.Write(bw);
        _overheatedThreshold.Write(bw);
        _heatDetonationThreshold.Write(bw);
        _heatDetonationFraction.Write(bw);
        _heatLossPerSecond.Write(bw);
        _heatIllumination.Write(bw);
        _overheatedHeatLossPerSecond.Write(bw);
        _overheated.Write(bw);
        _overheatedDamageEffect.Write(bw);
        _detonation.Write(bw);
        _detonationDamageEffect.Write(bw);
        _playerMeleeDamage.Write(bw);
        _playerMeleeResponse.Write(bw);
        _magnetismAngle.Write(bw);
        _magnetismRange.Write(bw);
        _throttleMagnitude.Write(bw);
        _throttleMinimumDistance.Write(bw);
        _throttleMaximumAdjustmentAngle.Write(bw);
        _damagePyramidAngles.Write(bw);
        _damagePyramidDepth.Write(bw);
        @__1stHitMeleeDamage.Write(bw);
        @__1stHitMeleeResponse.Write(bw);
        @__2ndHitMeleeDamage.Write(bw);
        @__2ndHitMeleeResponse.Write(bw);
        @__3rdHitMeleeDamage.Write(bw);
        @__3rdHitMeleeResponse.Write(bw);
        _lungeMeleeDamage.Write(bw);
        _lungeMeleeResponse.Write(bw);
        _meleeDamageReportingType.Write(bw);
        _unnamed1.Write(bw);
        _magnificationLevels.Write(bw);
        _magnificationRange.Write(bw);
        _autoaimAngle.Write(bw);
        _autoaimRange.Write(bw);
        _magnetismAngle2.Write(bw);
        _magnetismRange2.Write(bw);
        _deviationAngle.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _movementPenalized.Write(bw);
        _unnamed4.Write(bw);
        _forwardMovementPenalty.Write(bw);
        _sidewaysMovementPenalty.Write(bw);
        _aIScariness.Write(bw);
        _weaponPower_MinusonTime.Write(bw);
        _weaponPower_MinusoffTime.Write(bw);
        _weaponPower_MinusonEffect.Write(bw);
        _weaponPower_MinusoffEffect.Write(bw);
        _ageHeatRecoveryPenalty.Write(bw);
        _ageRateOfFirePenalty.Write(bw);
        _ageMisfireStart.Write(bw);
        _ageMisfireChance.Write(bw);
        _pickupSound.Write(bw);
        _zoom_MinusinSound.Write(bw);
        _zoom_MinusoutSound.Write(bw);
        _activeCamoDing.Write(bw);
        _activeCamoRegrowthRate.Write(bw);
        _handleNode.Write(bw);
        _weaponClass.Write(bw);
        _weaponName.Write(bw);
        _multiplayerWeaponType.Write(bw);
        _weaponType.Write(bw);
        _trackingType.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_firstPerson.Count = FirstPerson.Count;
        _firstPerson.Write(bw);
        _newHudInterface.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_magazines.Count = Magazines.Count;
        _magazines.Write(bw);
_newTriggers.Count = NewTriggers.Count;
        _newTriggers.Write(bw);
_barrels.Count = Barrels.Count;
        _barrels.Write(bw);
        _unnamed7.Write(bw);
        _maxMovementAcceleration.Write(bw);
        _maxMovementVelocity.Write(bw);
        _maxTurningAcceleration.Write(bw);
        _maxTurningVelocity.Write(bw);
        _deployedVehicle.Write(bw);
        _ageEffect.Write(bw);
        _agedWeapon.Write(bw);
        _firstPersonWeaponOffset.Write(bw);
        _firstPersonScopeSize.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _unnamed0.WriteString(writer);
        _readyEffect.WriteString(writer);
        _readyDamageEffect.WriteString(writer);
        _overheated.WriteString(writer);
        _overheatedDamageEffect.WriteString(writer);
        _detonation.WriteString(writer);
        _detonationDamageEffect.WriteString(writer);
        _playerMeleeDamage.WriteString(writer);
        _playerMeleeResponse.WriteString(writer);
        @__1stHitMeleeDamage.WriteString(writer);
        @__1stHitMeleeResponse.WriteString(writer);
        @__2ndHitMeleeDamage.WriteString(writer);
        @__2ndHitMeleeResponse.WriteString(writer);
        @__3rdHitMeleeDamage.WriteString(writer);
        @__3rdHitMeleeResponse.WriteString(writer);
        _lungeMeleeDamage.WriteString(writer);
        _lungeMeleeResponse.WriteString(writer);
        _weaponPower_MinusonEffect.WriteString(writer);
        _weaponPower_MinusoffEffect.WriteString(writer);
        _pickupSound.WriteString(writer);
        _zoom_MinusinSound.WriteString(writer);
        _zoom_MinusoutSound.WriteString(writer);
        _handleNode.WriteString(writer);
        _weaponClass.WriteString(writer);
        _weaponName.WriteString(writer);
        for (x = 0; (x < _firstPerson.Count); x = (x + 1)) {
          FirstPerson[x].Write(writer);
        }
        for (x = 0; (x < _firstPerson.Count); x = (x + 1)) {
          FirstPerson[x].WriteChildData(writer);
        }
        _newHudInterface.WriteString(writer);
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].Write(writer);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _newTriggers.Count); x = (x + 1)) {
          NewTriggers[x].Write(writer);
        }
        for (x = 0; (x < _newTriggers.Count); x = (x + 1)) {
          NewTriggers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _barrels.Count); x = (x + 1)) {
          Barrels[x].Write(writer);
        }
        for (x = 0; (x < _barrels.Count); x = (x + 1)) {
          Barrels[x].WriteChildData(writer);
        }
        _deployedVehicle.WriteString(writer);
        _ageEffect.WriteString(writer);
        _agedWeapon.WriteString(writer);
      }
    }
    public class WeaponFirstPersonInterfaceBlockBlock : IBlock {
      private TagReference _firstPersonModel = new TagReference();
      private TagReference _firstPersonAnimations = new TagReference();
public event System.EventHandler BlockNameChanged;
      public WeaponFirstPersonInterfaceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_firstPersonModel.Value);
references.Add(_firstPersonAnimations.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference FirstPersonModel {
        get {
          return this._firstPersonModel;
        }
        set {
          this._firstPersonModel = value;
        }
      }
      public TagReference FirstPersonAnimations {
        get {
          return this._firstPersonAnimations;
        }
        set {
          this._firstPersonAnimations = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _firstPersonModel.Read(reader);
        _firstPersonAnimations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _firstPersonModel.ReadString(reader);
        _firstPersonAnimations.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _firstPersonModel.Write(bw);
        _firstPersonAnimations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _firstPersonModel.WriteString(writer);
        _firstPersonAnimations.WriteString(writer);
      }
    }
    public class PredictedResourceBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _resourceIndex = new ShortInteger();
      private LongInteger _tagIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlockBlock() {
        this._type = new Enum(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger ResourceIndex {
        get {
          return this._resourceIndex;
        }
        set {
          this._resourceIndex = value;
        }
      }
      public LongInteger TagIndex {
        get {
          return this._tagIndex;
        }
        set {
          this._tagIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _tagIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _tagIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MagazinesBlock : IBlock {
      private Flags _flags;
      private ShortInteger _roundsRecharged = new ShortInteger();
      private ShortInteger _roundsTotalInitial = new ShortInteger();
      private ShortInteger _roundsTotalMaximum = new ShortInteger();
      private ShortInteger _roundsLoadedMaximum = new ShortInteger();
      private Pad _unnamed0;
      private Real _reloadTime = new Real();
      private ShortInteger _roundsReloaded = new ShortInteger();
      private Pad _unnamed1;
      private Real _chamberTime = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _reloadingEffect = new TagReference();
      private TagReference _reloadingDamageEffect = new TagReference();
      private TagReference _chamberingEffect = new TagReference();
      private TagReference _chamberingDamageEffect = new TagReference();
      private Block _magazines = new Block();
      public BlockCollection<MagazineObjectsBlock> _magazinesList = new BlockCollection<MagazineObjectsBlock>();
public event System.EventHandler BlockNameChanged;
      public MagazinesBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(16);
      }
      public BlockCollection<MagazineObjectsBlock> Magazines {
        get {
          return this._magazinesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_reloadingEffect.Value);
references.Add(_reloadingDamageEffect.Value);
references.Add(_chamberingEffect.Value);
references.Add(_chamberingDamageEffect.Value);
for (int x=0; x<Magazines.BlockCount; x++)
{
  IBlock block = Magazines.GetBlock(x);
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
      public ShortInteger RoundsRecharged {
        get {
          return this._roundsRecharged;
        }
        set {
          this._roundsRecharged = value;
        }
      }
      public ShortInteger RoundsTotalInitial {
        get {
          return this._roundsTotalInitial;
        }
        set {
          this._roundsTotalInitial = value;
        }
      }
      public ShortInteger RoundsTotalMaximum {
        get {
          return this._roundsTotalMaximum;
        }
        set {
          this._roundsTotalMaximum = value;
        }
      }
      public ShortInteger RoundsLoadedMaximum {
        get {
          return this._roundsLoadedMaximum;
        }
        set {
          this._roundsLoadedMaximum = value;
        }
      }
      public Real ReloadTime {
        get {
          return this._reloadTime;
        }
        set {
          this._reloadTime = value;
        }
      }
      public ShortInteger RoundsReloaded {
        get {
          return this._roundsReloaded;
        }
        set {
          this._roundsReloaded = value;
        }
      }
      public Real ChamberTime {
        get {
          return this._chamberTime;
        }
        set {
          this._chamberTime = value;
        }
      }
      public TagReference ReloadingEffect {
        get {
          return this._reloadingEffect;
        }
        set {
          this._reloadingEffect = value;
        }
      }
      public TagReference ReloadingDamageEffect {
        get {
          return this._reloadingDamageEffect;
        }
        set {
          this._reloadingDamageEffect = value;
        }
      }
      public TagReference ChamberingEffect {
        get {
          return this._chamberingEffect;
        }
        set {
          this._chamberingEffect = value;
        }
      }
      public TagReference ChamberingDamageEffect {
        get {
          return this._chamberingDamageEffect;
        }
        set {
          this._chamberingDamageEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _roundsRecharged.Read(reader);
        _roundsTotalInitial.Read(reader);
        _roundsTotalMaximum.Read(reader);
        _roundsLoadedMaximum.Read(reader);
        _unnamed0.Read(reader);
        _reloadTime.Read(reader);
        _roundsReloaded.Read(reader);
        _unnamed1.Read(reader);
        _chamberTime.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _reloadingEffect.Read(reader);
        _reloadingDamageEffect.Read(reader);
        _chamberingEffect.Read(reader);
        _chamberingDamageEffect.Read(reader);
        _magazines.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _reloadingEffect.ReadString(reader);
        _reloadingDamageEffect.ReadString(reader);
        _chamberingEffect.ReadString(reader);
        _chamberingDamageEffect.ReadString(reader);
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines.Add(new MagazineObjectsBlock());
          Magazines[x].Read(reader);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _roundsRecharged.Write(bw);
        _roundsTotalInitial.Write(bw);
        _roundsTotalMaximum.Write(bw);
        _roundsLoadedMaximum.Write(bw);
        _unnamed0.Write(bw);
        _reloadTime.Write(bw);
        _roundsReloaded.Write(bw);
        _unnamed1.Write(bw);
        _chamberTime.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _reloadingEffect.Write(bw);
        _reloadingDamageEffect.Write(bw);
        _chamberingEffect.Write(bw);
        _chamberingDamageEffect.Write(bw);
_magazines.Count = Magazines.Count;
        _magazines.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _reloadingEffect.WriteString(writer);
        _reloadingDamageEffect.WriteString(writer);
        _chamberingEffect.WriteString(writer);
        _chamberingDamageEffect.WriteString(writer);
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].Write(writer);
        }
        for (x = 0; (x < _magazines.Count); x = (x + 1)) {
          Magazines[x].WriteChildData(writer);
        }
      }
    }
    public class MagazineObjectsBlock : IBlock {
      private ShortInteger _rounds = new ShortInteger();
      private Pad _unnamed0;
      private TagReference _equipment = new TagReference();
public event System.EventHandler BlockNameChanged;
      public MagazineObjectsBlock() {
if (this._equipment is System.ComponentModel.INotifyPropertyChanged)
  (this._equipment as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_equipment.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _equipment.ToString();
        }
      }
      public ShortInteger Rounds {
        get {
          return this._rounds;
        }
        set {
          this._rounds = value;
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
      public virtual void Read(BinaryReader reader) {
        _rounds.Read(reader);
        _unnamed0.Read(reader);
        _equipment.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _equipment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _rounds.Write(bw);
        _unnamed0.Write(bw);
        _equipment.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _equipment.WriteString(writer);
      }
    }
    public class WeaponTriggersBlock : IBlock {
      private Flags _flags;
      private Enum _input;
      private Enum _behavior;
      private ShortBlockIndex _primaryBarrel = new ShortBlockIndex();
      private ShortBlockIndex _secondaryBarrel = new ShortBlockIndex();
      private Enum _prediction;
      private Pad _unnamed0;
      private Real _autofireTime = new Real();
      private Real _autofireThrow = new Real();
      private Enum _secondaryAction;
      private Enum _primaryAction;
      private Real _chargingTime = new Real();
      private Real _chargedTime = new Real();
      private Enum _overchargedAction;
      private Pad _unnamed1;
      private Real _chargedIllumination = new Real();
      private Real _spewTime = new Real();
      private TagReference _chargingEffect = new TagReference();
      private TagReference _chargingDamageEffect = new TagReference();
public event System.EventHandler BlockNameChanged;
      public WeaponTriggersBlock() {
        this._flags = new Flags(4);
        this._input = new Enum(2);
        this._behavior = new Enum(2);
        this._prediction = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._secondaryAction = new Enum(2);
        this._primaryAction = new Enum(2);
        this._overchargedAction = new Enum(2);
        this._unnamed1 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_chargingEffect.Value);
references.Add(_chargingDamageEffect.Value);
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
      public Enum Input {
        get {
          return this._input;
        }
        set {
          this._input = value;
        }
      }
      public Enum Behavior {
        get {
          return this._behavior;
        }
        set {
          this._behavior = value;
        }
      }
      public ShortBlockIndex PrimaryBarrel {
        get {
          return this._primaryBarrel;
        }
        set {
          this._primaryBarrel = value;
        }
      }
      public ShortBlockIndex SecondaryBarrel {
        get {
          return this._secondaryBarrel;
        }
        set {
          this._secondaryBarrel = value;
        }
      }
      public Enum Prediction {
        get {
          return this._prediction;
        }
        set {
          this._prediction = value;
        }
      }
      public Real AutofireTime {
        get {
          return this._autofireTime;
        }
        set {
          this._autofireTime = value;
        }
      }
      public Real AutofireThrow {
        get {
          return this._autofireThrow;
        }
        set {
          this._autofireThrow = value;
        }
      }
      public Enum SecondaryAction {
        get {
          return this._secondaryAction;
        }
        set {
          this._secondaryAction = value;
        }
      }
      public Enum PrimaryAction {
        get {
          return this._primaryAction;
        }
        set {
          this._primaryAction = value;
        }
      }
      public Real ChargingTime {
        get {
          return this._chargingTime;
        }
        set {
          this._chargingTime = value;
        }
      }
      public Real ChargedTime {
        get {
          return this._chargedTime;
        }
        set {
          this._chargedTime = value;
        }
      }
      public Enum OverchargedAction {
        get {
          return this._overchargedAction;
        }
        set {
          this._overchargedAction = value;
        }
      }
      public Real ChargedIllumination {
        get {
          return this._chargedIllumination;
        }
        set {
          this._chargedIllumination = value;
        }
      }
      public Real SpewTime {
        get {
          return this._spewTime;
        }
        set {
          this._spewTime = value;
        }
      }
      public TagReference ChargingEffect {
        get {
          return this._chargingEffect;
        }
        set {
          this._chargingEffect = value;
        }
      }
      public TagReference ChargingDamageEffect {
        get {
          return this._chargingDamageEffect;
        }
        set {
          this._chargingDamageEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _input.Read(reader);
        _behavior.Read(reader);
        _primaryBarrel.Read(reader);
        _secondaryBarrel.Read(reader);
        _prediction.Read(reader);
        _unnamed0.Read(reader);
        _autofireTime.Read(reader);
        _autofireThrow.Read(reader);
        _secondaryAction.Read(reader);
        _primaryAction.Read(reader);
        _chargingTime.Read(reader);
        _chargedTime.Read(reader);
        _overchargedAction.Read(reader);
        _unnamed1.Read(reader);
        _chargedIllumination.Read(reader);
        _spewTime.Read(reader);
        _chargingEffect.Read(reader);
        _chargingDamageEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _chargingEffect.ReadString(reader);
        _chargingDamageEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _input.Write(bw);
        _behavior.Write(bw);
        _primaryBarrel.Write(bw);
        _secondaryBarrel.Write(bw);
        _prediction.Write(bw);
        _unnamed0.Write(bw);
        _autofireTime.Write(bw);
        _autofireThrow.Write(bw);
        _secondaryAction.Write(bw);
        _primaryAction.Write(bw);
        _chargingTime.Write(bw);
        _chargedTime.Write(bw);
        _overchargedAction.Write(bw);
        _unnamed1.Write(bw);
        _chargedIllumination.Write(bw);
        _spewTime.Write(bw);
        _chargingEffect.Write(bw);
        _chargingDamageEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _chargingEffect.WriteString(writer);
        _chargingDamageEffect.WriteString(writer);
      }
    }
    public class WeaponBarrelsBlock : IBlock {
      private Flags _flags;
      private RealBounds _roundsPerSecond = new RealBounds();
      private Real _accelerationTime = new Real();
      private Real _decelerationTime = new Real();
      private RealFraction _barrelSpinScale = new RealFraction();
      private RealFraction _blurredRateOfFire = new RealFraction();
      private ShortIntegerBounds _shotsPerFire = new ShortIntegerBounds();
      private Real _fireRecoveryTime = new Real();
      private RealFraction _softRecoveryFraction = new RealFraction();
      private ShortBlockIndex _magazine = new ShortBlockIndex();
      private ShortInteger _roundsPerShot = new ShortInteger();
      private ShortInteger _minimumRoundsLoaded = new ShortInteger();
      private ShortInteger _roundsBetweenTracers = new ShortInteger();
      private StringId _optionalBarrelMarkerName = new StringId();
      private Enum _predictionType;
      private Enum _firingNoise;
      private Real _accelerationTime2 = new Real();
      private Real _decelerationTime2 = new Real();
      private RealBounds _damageError = new RealBounds();
      private Real _accelerationTime3 = new Real();
      private Real _decelerationTime3 = new Real();
      private Pad _unnamed0;
      private Angle _minimumError = new Angle();
      private AngleBounds _errorAngle = new AngleBounds();
      private RealFraction _dualWieldDamageScale = new RealFraction();
      private Enum _distributionFunction;
      private ShortInteger _projectilesPerShot = new ShortInteger();
      private Real _distributionAngle = new Real();
      private Angle _minimumError2 = new Angle();
      private AngleBounds _errorAngle2 = new AngleBounds();
      private RealPoint3D _firstPersonOffset = new RealPoint3D();
      private Enum _damageEffectReportingType;
      private Pad _unnamed1;
      private TagReference _projectile = new TagReference();
      private TagReference _damageEffect = new TagReference();
      private Real _ejectionPortRecoveryTime = new Real();
      private Real _illuminationRecoveryTime = new Real();
      private RealFraction _heatGeneratedPerRound = new RealFraction();
      private RealFraction _ageGeneratedPerRound = new RealFraction();
      private Real _overloadTime = new Real();
      private AngleBounds _angleChangePerShot = new AngleBounds();
      private Real _accelerationTime4 = new Real();
      private Real _decelerationTime4 = new Real();
      private Enum _angleChangeFunction;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Block _firingEffects = new Block();
      public BlockCollection<BarrelFiringEffectBlockBlock> _firingEffectsList = new BlockCollection<BarrelFiringEffectBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponBarrelsBlock() {
        this._flags = new Flags(4);
        this._predictionType = new Enum(2);
        this._firingNoise = new Enum(2);
        this._unnamed0 = new Pad(8);
        this._distributionFunction = new Enum(2);
        this._damageEffectReportingType = new Enum(1);
        this._unnamed1 = new Pad(3);
        this._angleChangeFunction = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(24);
      }
      public BlockCollection<BarrelFiringEffectBlockBlock> FiringEffects {
        get {
          return this._firingEffectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_projectile.Value);
references.Add(_damageEffect.Value);
for (int x=0; x<FiringEffects.BlockCount; x++)
{
  IBlock block = FiringEffects.GetBlock(x);
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
      public RealBounds RoundsPerSecond {
        get {
          return this._roundsPerSecond;
        }
        set {
          this._roundsPerSecond = value;
        }
      }
      public Real AccelerationTime {
        get {
          return this._accelerationTime;
        }
        set {
          this._accelerationTime = value;
        }
      }
      public Real DecelerationTime {
        get {
          return this._decelerationTime;
        }
        set {
          this._decelerationTime = value;
        }
      }
      public RealFraction BarrelSpinScale {
        get {
          return this._barrelSpinScale;
        }
        set {
          this._barrelSpinScale = value;
        }
      }
      public RealFraction BlurredRateOfFire {
        get {
          return this._blurredRateOfFire;
        }
        set {
          this._blurredRateOfFire = value;
        }
      }
      public ShortIntegerBounds ShotsPerFire {
        get {
          return this._shotsPerFire;
        }
        set {
          this._shotsPerFire = value;
        }
      }
      public Real FireRecoveryTime {
        get {
          return this._fireRecoveryTime;
        }
        set {
          this._fireRecoveryTime = value;
        }
      }
      public RealFraction SoftRecoveryFraction {
        get {
          return this._softRecoveryFraction;
        }
        set {
          this._softRecoveryFraction = value;
        }
      }
      public ShortBlockIndex Magazine {
        get {
          return this._magazine;
        }
        set {
          this._magazine = value;
        }
      }
      public ShortInteger RoundsPerShot {
        get {
          return this._roundsPerShot;
        }
        set {
          this._roundsPerShot = value;
        }
      }
      public ShortInteger MinimumRoundsLoaded {
        get {
          return this._minimumRoundsLoaded;
        }
        set {
          this._minimumRoundsLoaded = value;
        }
      }
      public ShortInteger RoundsBetweenTracers {
        get {
          return this._roundsBetweenTracers;
        }
        set {
          this._roundsBetweenTracers = value;
        }
      }
      public StringId OptionalBarrelMarkerName {
        get {
          return this._optionalBarrelMarkerName;
        }
        set {
          this._optionalBarrelMarkerName = value;
        }
      }
      public Enum PredictionType {
        get {
          return this._predictionType;
        }
        set {
          this._predictionType = value;
        }
      }
      public Enum FiringNoise {
        get {
          return this._firingNoise;
        }
        set {
          this._firingNoise = value;
        }
      }
      public Real AccelerationTime2 {
        get {
          return this._accelerationTime2;
        }
        set {
          this._accelerationTime2 = value;
        }
      }
      public Real DecelerationTime2 {
        get {
          return this._decelerationTime2;
        }
        set {
          this._decelerationTime2 = value;
        }
      }
      public RealBounds DamageError {
        get {
          return this._damageError;
        }
        set {
          this._damageError = value;
        }
      }
      public Real AccelerationTime3 {
        get {
          return this._accelerationTime3;
        }
        set {
          this._accelerationTime3 = value;
        }
      }
      public Real DecelerationTime3 {
        get {
          return this._decelerationTime3;
        }
        set {
          this._decelerationTime3 = value;
        }
      }
      public Angle MinimumError {
        get {
          return this._minimumError;
        }
        set {
          this._minimumError = value;
        }
      }
      public AngleBounds ErrorAngle {
        get {
          return this._errorAngle;
        }
        set {
          this._errorAngle = value;
        }
      }
      public RealFraction DualWieldDamageScale {
        get {
          return this._dualWieldDamageScale;
        }
        set {
          this._dualWieldDamageScale = value;
        }
      }
      public Enum DistributionFunction {
        get {
          return this._distributionFunction;
        }
        set {
          this._distributionFunction = value;
        }
      }
      public ShortInteger ProjectilesPerShot {
        get {
          return this._projectilesPerShot;
        }
        set {
          this._projectilesPerShot = value;
        }
      }
      public Real DistributionAngle {
        get {
          return this._distributionAngle;
        }
        set {
          this._distributionAngle = value;
        }
      }
      public Angle MinimumError2 {
        get {
          return this._minimumError2;
        }
        set {
          this._minimumError2 = value;
        }
      }
      public AngleBounds ErrorAngle2 {
        get {
          return this._errorAngle2;
        }
        set {
          this._errorAngle2 = value;
        }
      }
      public RealPoint3D FirstPersonOffset {
        get {
          return this._firstPersonOffset;
        }
        set {
          this._firstPersonOffset = value;
        }
      }
      public Enum DamageEffectReportingType {
        get {
          return this._damageEffectReportingType;
        }
        set {
          this._damageEffectReportingType = value;
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
      public TagReference DamageEffect {
        get {
          return this._damageEffect;
        }
        set {
          this._damageEffect = value;
        }
      }
      public Real EjectionPortRecoveryTime {
        get {
          return this._ejectionPortRecoveryTime;
        }
        set {
          this._ejectionPortRecoveryTime = value;
        }
      }
      public Real IlluminationRecoveryTime {
        get {
          return this._illuminationRecoveryTime;
        }
        set {
          this._illuminationRecoveryTime = value;
        }
      }
      public RealFraction HeatGeneratedPerRound {
        get {
          return this._heatGeneratedPerRound;
        }
        set {
          this._heatGeneratedPerRound = value;
        }
      }
      public RealFraction AgeGeneratedPerRound {
        get {
          return this._ageGeneratedPerRound;
        }
        set {
          this._ageGeneratedPerRound = value;
        }
      }
      public Real OverloadTime {
        get {
          return this._overloadTime;
        }
        set {
          this._overloadTime = value;
        }
      }
      public AngleBounds AngleChangePerShot {
        get {
          return this._angleChangePerShot;
        }
        set {
          this._angleChangePerShot = value;
        }
      }
      public Real AccelerationTime4 {
        get {
          return this._accelerationTime4;
        }
        set {
          this._accelerationTime4 = value;
        }
      }
      public Real DecelerationTime4 {
        get {
          return this._decelerationTime4;
        }
        set {
          this._decelerationTime4 = value;
        }
      }
      public Enum AngleChangeFunction {
        get {
          return this._angleChangeFunction;
        }
        set {
          this._angleChangeFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _roundsPerSecond.Read(reader);
        _accelerationTime.Read(reader);
        _decelerationTime.Read(reader);
        _barrelSpinScale.Read(reader);
        _blurredRateOfFire.Read(reader);
        _shotsPerFire.Read(reader);
        _fireRecoveryTime.Read(reader);
        _softRecoveryFraction.Read(reader);
        _magazine.Read(reader);
        _roundsPerShot.Read(reader);
        _minimumRoundsLoaded.Read(reader);
        _roundsBetweenTracers.Read(reader);
        _optionalBarrelMarkerName.Read(reader);
        _predictionType.Read(reader);
        _firingNoise.Read(reader);
        _accelerationTime2.Read(reader);
        _decelerationTime2.Read(reader);
        _damageError.Read(reader);
        _accelerationTime3.Read(reader);
        _decelerationTime3.Read(reader);
        _unnamed0.Read(reader);
        _minimumError.Read(reader);
        _errorAngle.Read(reader);
        _dualWieldDamageScale.Read(reader);
        _distributionFunction.Read(reader);
        _projectilesPerShot.Read(reader);
        _distributionAngle.Read(reader);
        _minimumError2.Read(reader);
        _errorAngle2.Read(reader);
        _firstPersonOffset.Read(reader);
        _damageEffectReportingType.Read(reader);
        _unnamed1.Read(reader);
        _projectile.Read(reader);
        _damageEffect.Read(reader);
        _ejectionPortRecoveryTime.Read(reader);
        _illuminationRecoveryTime.Read(reader);
        _heatGeneratedPerRound.Read(reader);
        _ageGeneratedPerRound.Read(reader);
        _overloadTime.Read(reader);
        _angleChangePerShot.Read(reader);
        _accelerationTime4.Read(reader);
        _decelerationTime4.Read(reader);
        _angleChangeFunction.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _firingEffects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _optionalBarrelMarkerName.ReadString(reader);
        _projectile.ReadString(reader);
        _damageEffect.ReadString(reader);
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects.Add(new BarrelFiringEffectBlockBlock());
          FiringEffects[x].Read(reader);
        }
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _roundsPerSecond.Write(bw);
        _accelerationTime.Write(bw);
        _decelerationTime.Write(bw);
        _barrelSpinScale.Write(bw);
        _blurredRateOfFire.Write(bw);
        _shotsPerFire.Write(bw);
        _fireRecoveryTime.Write(bw);
        _softRecoveryFraction.Write(bw);
        _magazine.Write(bw);
        _roundsPerShot.Write(bw);
        _minimumRoundsLoaded.Write(bw);
        _roundsBetweenTracers.Write(bw);
        _optionalBarrelMarkerName.Write(bw);
        _predictionType.Write(bw);
        _firingNoise.Write(bw);
        _accelerationTime2.Write(bw);
        _decelerationTime2.Write(bw);
        _damageError.Write(bw);
        _accelerationTime3.Write(bw);
        _decelerationTime3.Write(bw);
        _unnamed0.Write(bw);
        _minimumError.Write(bw);
        _errorAngle.Write(bw);
        _dualWieldDamageScale.Write(bw);
        _distributionFunction.Write(bw);
        _projectilesPerShot.Write(bw);
        _distributionAngle.Write(bw);
        _minimumError2.Write(bw);
        _errorAngle2.Write(bw);
        _firstPersonOffset.Write(bw);
        _damageEffectReportingType.Write(bw);
        _unnamed1.Write(bw);
        _projectile.Write(bw);
        _damageEffect.Write(bw);
        _ejectionPortRecoveryTime.Write(bw);
        _illuminationRecoveryTime.Write(bw);
        _heatGeneratedPerRound.Write(bw);
        _ageGeneratedPerRound.Write(bw);
        _overloadTime.Write(bw);
        _angleChangePerShot.Write(bw);
        _accelerationTime4.Write(bw);
        _decelerationTime4.Write(bw);
        _angleChangeFunction.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
_firingEffects.Count = FiringEffects.Count;
        _firingEffects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _optionalBarrelMarkerName.WriteString(writer);
        _projectile.WriteString(writer);
        _damageEffect.WriteString(writer);
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects[x].Write(writer);
        }
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects[x].WriteChildData(writer);
        }
      }
    }
    public class BarrelFiringEffectBlockBlock : IBlock {
      private ShortInteger _shotCountLowerBound = new ShortInteger();
      private ShortInteger _shotCountUpperBound = new ShortInteger();
      private TagReference _firingEffect = new TagReference();
      private TagReference _misfireEffect = new TagReference();
      private TagReference _emptyEffect = new TagReference();
      private TagReference _firingDamage = new TagReference();
      private TagReference _misfireDamage = new TagReference();
      private TagReference _emptyDamage = new TagReference();
public event System.EventHandler BlockNameChanged;
      public BarrelFiringEffectBlockBlock() {
if (this._firingEffect is System.ComponentModel.INotifyPropertyChanged)
  (this._firingEffect as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_firingEffect.Value);
references.Add(_misfireEffect.Value);
references.Add(_emptyEffect.Value);
references.Add(_firingDamage.Value);
references.Add(_misfireDamage.Value);
references.Add(_emptyDamage.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _firingEffect.ToString();
        }
      }
      public ShortInteger ShotCountLowerBound {
        get {
          return this._shotCountLowerBound;
        }
        set {
          this._shotCountLowerBound = value;
        }
      }
      public ShortInteger ShotCountUpperBound {
        get {
          return this._shotCountUpperBound;
        }
        set {
          this._shotCountUpperBound = value;
        }
      }
      public TagReference FiringEffect {
        get {
          return this._firingEffect;
        }
        set {
          this._firingEffect = value;
        }
      }
      public TagReference MisfireEffect {
        get {
          return this._misfireEffect;
        }
        set {
          this._misfireEffect = value;
        }
      }
      public TagReference EmptyEffect {
        get {
          return this._emptyEffect;
        }
        set {
          this._emptyEffect = value;
        }
      }
      public TagReference FiringDamage {
        get {
          return this._firingDamage;
        }
        set {
          this._firingDamage = value;
        }
      }
      public TagReference MisfireDamage {
        get {
          return this._misfireDamage;
        }
        set {
          this._misfireDamage = value;
        }
      }
      public TagReference EmptyDamage {
        get {
          return this._emptyDamage;
        }
        set {
          this._emptyDamage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shotCountLowerBound.Read(reader);
        _shotCountUpperBound.Read(reader);
        _firingEffect.Read(reader);
        _misfireEffect.Read(reader);
        _emptyEffect.Read(reader);
        _firingDamage.Read(reader);
        _misfireDamage.Read(reader);
        _emptyDamage.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _firingEffect.ReadString(reader);
        _misfireEffect.ReadString(reader);
        _emptyEffect.ReadString(reader);
        _firingDamage.ReadString(reader);
        _misfireDamage.ReadString(reader);
        _emptyDamage.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shotCountLowerBound.Write(bw);
        _shotCountUpperBound.Write(bw);
        _firingEffect.Write(bw);
        _misfireEffect.Write(bw);
        _emptyEffect.Write(bw);
        _firingDamage.Write(bw);
        _misfireDamage.Write(bw);
        _emptyDamage.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _firingEffect.WriteString(writer);
        _misfireEffect.WriteString(writer);
        _emptyEffect.WriteString(writer);
        _firingDamage.WriteString(writer);
        _misfireDamage.WriteString(writer);
        _emptyDamage.WriteString(writer);
      }
    }
  }
}
