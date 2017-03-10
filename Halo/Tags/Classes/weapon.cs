// -------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'weapon' (derived from 'item')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class weapon : item {
    private WeaponBlock weaponValues = new WeaponBlock();
    public virtual WeaponBlock WeaponValues {
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
    public class WeaponBlock : IBlock {
      private Flags _flags;
      private FixedLengthString _label = new FixedLengthString();
      private Enum _secondaryTriggerMode = new Enum();
      private ShortInteger _maximumAlternateShotsLoaded = new ShortInteger();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private Real _readyTime = new Real();
      private TagReference _readyEffect = new TagReference();
      private RealFraction _heatRecoveryThreshold = new RealFraction();
      private RealFraction _overheatedThreshold = new RealFraction();
      private RealFraction _heatDetonationThreshold = new RealFraction();
      private RealFraction _heatDetonationFraction = new RealFraction();
      private RealFraction _heatLossPerSecond = new RealFraction();
      private RealFraction _heatIllumination = new RealFraction();
      private Pad _unnamed;
      private TagReference _overheated = new TagReference();
      private TagReference _detonation = new TagReference();
      private TagReference _playerMeleeDamage = new TagReference();
      private TagReference _playerMeleeResponse = new TagReference();
      private Pad _unnamed2;
      private TagReference _actorFiringParameters = new TagReference();
      private Real _nearReticleRange = new Real();
      private Real _farReticleRange = new Real();
      private Real _intersectionReticleRange = new Real();
      private Pad _unnamed3;
      private ShortInteger _magnificationLevels = new ShortInteger();
      private RealBounds _magnificationRange = new RealBounds();
      private Angle _autoaimAngle = new Angle();
      private Real _autoaimRange = new Real();
      private Angle _magnetismAngle = new Angle();
      private Real _magnetismRange = new Real();
      private Angle _deviationAngle = new Angle();
      private Pad _unnamed4;
      private Enum _movementPenalized = new Enum();
      private Pad _unnamed5;
      private RealFraction _forwardMovementPenalty = new RealFraction();
      private RealFraction _sidewaysMovementPenalty = new RealFraction();
      private Pad _unnamed6;
      private Real _minimumTargetRange = new Real();
      private Real _lookingTimeModifier = new Real();
      private Pad _unnamed7;
      private Real _lightPowe = new Real();
      private Real _lightPowe2 = new Real();
      private TagReference _lightPowe3 = new TagReference();
      private TagReference _lightPowe4 = new TagReference();
      private Real _ageHeatRecoveryPenalty = new Real();
      private Real _ageRateOfFirePenalty = new Real();
      private RealFraction _ageMisfireStart = new RealFraction();
      private RealFraction _ageMisfireChance = new RealFraction();
      private Pad _unnamed8;
      private TagReference _firstPersonModel = new TagReference();
      private TagReference _firstPersonAnimations = new TagReference();
      private Pad _unnamed9;
      private TagReference _hudInterface = new TagReference();
      private TagReference _pickupSound = new TagReference();
      private TagReference _zoo = new TagReference();
      private TagReference _zoo2 = new TagReference();
      private Pad _unnamed10;
      private Real _activeCamoDing = new Real();
      private Real _activeCamoRegrowthRate = new Real();
      private Pad _unnamed11;
      private Pad _unnamed12;
      private Enum _weaponType = new Enum();
      private Block _predictedResources = new Block();
      private Block _magazines = new Block();
      private Block _triggers = new Block();
      public BlockCollection<PredictedResourceBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlock>();
      public BlockCollection<MagazinesBlock> _magazinesList = new BlockCollection<MagazinesBlock>();
      public BlockCollection<TriggersBlock> _triggersList = new BlockCollection<TriggersBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(4);
        this._unnamed8 = new Pad(12);
        this._unnamed9 = new Pad(4);
        this._unnamed10 = new Pad(12);
        this._unnamed11 = new Pad(12);
        this._unnamed12 = new Pad(2);
      }
      public BlockCollection<PredictedResourceBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<MagazinesBlock> Magazines {
        get {
          return this._magazinesList;
        }
      }
      public BlockCollection<TriggersBlock> Triggers {
        get {
          return this._triggersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_readyEffect.Value);
references.Add(_overheated.Value);
references.Add(_detonation.Value);
references.Add(_playerMeleeDamage.Value);
references.Add(_playerMeleeResponse.Value);
references.Add(_actorFiringParameters.Value);
references.Add(_lightPowe3.Value);
references.Add(_lightPowe4.Value);
references.Add(_firstPersonModel.Value);
references.Add(_firstPersonAnimations.Value);
references.Add(_hudInterface.Value);
references.Add(_pickupSound.Value);
references.Add(_zoo.Value);
references.Add(_zoo2.Value);
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
for (int x=0; x<Triggers.BlockCount; x++)
{
  IBlock block = Triggers.GetBlock(x);
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
      public FixedLengthString Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
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
      public Enum AIn {
        get {
          return this._aIn;
        }
        set {
          this._aIn = value;
        }
      }
      public Enum BIn {
        get {
          return this._bIn;
        }
        set {
          this._bIn = value;
        }
      }
      public Enum CIn {
        get {
          return this._cIn;
        }
        set {
          this._cIn = value;
        }
      }
      public Enum DIn {
        get {
          return this._dIn;
        }
        set {
          this._dIn = value;
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
      public TagReference Overheated {
        get {
          return this._overheated;
        }
        set {
          this._overheated = value;
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
      public TagReference ActorFiringParameters {
        get {
          return this._actorFiringParameters;
        }
        set {
          this._actorFiringParameters = value;
        }
      }
      public Real NearReticleRange {
        get {
          return this._nearReticleRange;
        }
        set {
          this._nearReticleRange = value;
        }
      }
      public Real FarReticleRange {
        get {
          return this._farReticleRange;
        }
        set {
          this._farReticleRange = value;
        }
      }
      public Real IntersectionReticleRange {
        get {
          return this._intersectionReticleRange;
        }
        set {
          this._intersectionReticleRange = value;
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
      public Real MinimumTargetRange {
        get {
          return this._minimumTargetRange;
        }
        set {
          this._minimumTargetRange = value;
        }
      }
      public Real LookingTimeModifier {
        get {
          return this._lookingTimeModifier;
        }
        set {
          this._lookingTimeModifier = value;
        }
      }
      public Real LightPowe {
        get {
          return this._lightPowe;
        }
        set {
          this._lightPowe = value;
        }
      }
      public Real LightPowe2 {
        get {
          return this._lightPowe2;
        }
        set {
          this._lightPowe2 = value;
        }
      }
      public TagReference LightPowe3 {
        get {
          return this._lightPowe3;
        }
        set {
          this._lightPowe3 = value;
        }
      }
      public TagReference LightPowe4 {
        get {
          return this._lightPowe4;
        }
        set {
          this._lightPowe4 = value;
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
      public TagReference HudInterface {
        get {
          return this._hudInterface;
        }
        set {
          this._hudInterface = value;
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
      public TagReference Zoo {
        get {
          return this._zoo;
        }
        set {
          this._zoo = value;
        }
      }
      public TagReference Zoo2 {
        get {
          return this._zoo2;
        }
        set {
          this._zoo2 = value;
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
      public Enum WeaponType {
        get {
          return this._weaponType;
        }
        set {
          this._weaponType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _label.Read(reader);
        _secondaryTriggerMode.Read(reader);
        _maximumAlternateShotsLoaded.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _readyTime.Read(reader);
        _readyEffect.Read(reader);
        _heatRecoveryThreshold.Read(reader);
        _overheatedThreshold.Read(reader);
        _heatDetonationThreshold.Read(reader);
        _heatDetonationFraction.Read(reader);
        _heatLossPerSecond.Read(reader);
        _heatIllumination.Read(reader);
        _unnamed.Read(reader);
        _overheated.Read(reader);
        _detonation.Read(reader);
        _playerMeleeDamage.Read(reader);
        _playerMeleeResponse.Read(reader);
        _unnamed2.Read(reader);
        _actorFiringParameters.Read(reader);
        _nearReticleRange.Read(reader);
        _farReticleRange.Read(reader);
        _intersectionReticleRange.Read(reader);
        _unnamed3.Read(reader);
        _magnificationLevels.Read(reader);
        _magnificationRange.Read(reader);
        _autoaimAngle.Read(reader);
        _autoaimRange.Read(reader);
        _magnetismAngle.Read(reader);
        _magnetismRange.Read(reader);
        _deviationAngle.Read(reader);
        _unnamed4.Read(reader);
        _movementPenalized.Read(reader);
        _unnamed5.Read(reader);
        _forwardMovementPenalty.Read(reader);
        _sidewaysMovementPenalty.Read(reader);
        _unnamed6.Read(reader);
        _minimumTargetRange.Read(reader);
        _lookingTimeModifier.Read(reader);
        _unnamed7.Read(reader);
        _lightPowe.Read(reader);
        _lightPowe2.Read(reader);
        _lightPowe3.Read(reader);
        _lightPowe4.Read(reader);
        _ageHeatRecoveryPenalty.Read(reader);
        _ageRateOfFirePenalty.Read(reader);
        _ageMisfireStart.Read(reader);
        _ageMisfireChance.Read(reader);
        _unnamed8.Read(reader);
        _firstPersonModel.Read(reader);
        _firstPersonAnimations.Read(reader);
        _unnamed9.Read(reader);
        _hudInterface.Read(reader);
        _pickupSound.Read(reader);
        _zoo.Read(reader);
        _zoo2.Read(reader);
        _unnamed10.Read(reader);
        _activeCamoDing.Read(reader);
        _activeCamoRegrowthRate.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _weaponType.Read(reader);
        _predictedResources.Read(reader);
        _magazines.Read(reader);
        _triggers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _readyEffect.ReadString(reader);
        _overheated.ReadString(reader);
        _detonation.ReadString(reader);
        _playerMeleeDamage.ReadString(reader);
        _playerMeleeResponse.ReadString(reader);
        _actorFiringParameters.ReadString(reader);
        _lightPowe3.ReadString(reader);
        _lightPowe4.ReadString(reader);
        _firstPersonModel.ReadString(reader);
        _firstPersonAnimations.ReadString(reader);
        _hudInterface.ReadString(reader);
        _pickupSound.ReadString(reader);
        _zoo.ReadString(reader);
        _zoo2.ReadString(reader);
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlock());
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
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers.Add(new TriggersBlock());
          Triggers[x].Read(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _label.Write(bw);
        _secondaryTriggerMode.Write(bw);
        _maximumAlternateShotsLoaded.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _readyTime.Write(bw);
        _readyEffect.Write(bw);
        _heatRecoveryThreshold.Write(bw);
        _overheatedThreshold.Write(bw);
        _heatDetonationThreshold.Write(bw);
        _heatDetonationFraction.Write(bw);
        _heatLossPerSecond.Write(bw);
        _heatIllumination.Write(bw);
        _unnamed.Write(bw);
        _overheated.Write(bw);
        _detonation.Write(bw);
        _playerMeleeDamage.Write(bw);
        _playerMeleeResponse.Write(bw);
        _unnamed2.Write(bw);
        _actorFiringParameters.Write(bw);
        _nearReticleRange.Write(bw);
        _farReticleRange.Write(bw);
        _intersectionReticleRange.Write(bw);
        _unnamed3.Write(bw);
        _magnificationLevels.Write(bw);
        _magnificationRange.Write(bw);
        _autoaimAngle.Write(bw);
        _autoaimRange.Write(bw);
        _magnetismAngle.Write(bw);
        _magnetismRange.Write(bw);
        _deviationAngle.Write(bw);
        _unnamed4.Write(bw);
        _movementPenalized.Write(bw);
        _unnamed5.Write(bw);
        _forwardMovementPenalty.Write(bw);
        _sidewaysMovementPenalty.Write(bw);
        _unnamed6.Write(bw);
        _minimumTargetRange.Write(bw);
        _lookingTimeModifier.Write(bw);
        _unnamed7.Write(bw);
        _lightPowe.Write(bw);
        _lightPowe2.Write(bw);
        _lightPowe3.Write(bw);
        _lightPowe4.Write(bw);
        _ageHeatRecoveryPenalty.Write(bw);
        _ageRateOfFirePenalty.Write(bw);
        _ageMisfireStart.Write(bw);
        _ageMisfireChance.Write(bw);
        _unnamed8.Write(bw);
        _firstPersonModel.Write(bw);
        _firstPersonAnimations.Write(bw);
        _unnamed9.Write(bw);
        _hudInterface.Write(bw);
        _pickupSound.Write(bw);
        _zoo.Write(bw);
        _zoo2.Write(bw);
        _unnamed10.Write(bw);
        _activeCamoDing.Write(bw);
        _activeCamoRegrowthRate.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _weaponType.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_magazines.Count = Magazines.Count;
        _magazines.Write(bw);
_triggers.Count = Triggers.Count;
        _triggers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _readyEffect.WriteString(writer);
        _overheated.WriteString(writer);
        _detonation.WriteString(writer);
        _playerMeleeDamage.WriteString(writer);
        _playerMeleeResponse.WriteString(writer);
        _actorFiringParameters.WriteString(writer);
        _lightPowe3.WriteString(writer);
        _lightPowe4.WriteString(writer);
        _firstPersonModel.WriteString(writer);
        _firstPersonAnimations.WriteString(writer);
        _hudInterface.WriteString(writer);
        _pickupSound.WriteString(writer);
        _zoo.WriteString(writer);
        _zoo2.WriteString(writer);
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
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].Write(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].WriteChildData(writer);
        }
      }
    }
    public class PredictedResourceBlock : IBlock {
      private Enum _type = new Enum();
      private ShortInteger _resourceIndex = new ShortInteger();
      private LongInteger _tagIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlock() {
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
      private Pad _unnamed;
      private Real _reloadTime = new Real();
      private ShortInteger _roundsReloaded = new ShortInteger();
      private Pad _unnamed2;
      private Real _chamberTime = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private TagReference _reloadingEffect = new TagReference();
      private TagReference _chamberingEffect = new TagReference();
      private Pad _unnamed5;
      private Block _magazines = new Block();
      public BlockCollection<MagazineObjectsBlock> _magazinesList = new BlockCollection<MagazineObjectsBlock>();
public event System.EventHandler BlockNameChanged;
      public MagazinesBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(12);
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
references.Add(_chamberingEffect.Value);
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
      public TagReference ChamberingEffect {
        get {
          return this._chamberingEffect;
        }
        set {
          this._chamberingEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _roundsRecharged.Read(reader);
        _roundsTotalInitial.Read(reader);
        _roundsTotalMaximum.Read(reader);
        _roundsLoadedMaximum.Read(reader);
        _unnamed.Read(reader);
        _reloadTime.Read(reader);
        _roundsReloaded.Read(reader);
        _unnamed2.Read(reader);
        _chamberTime.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _reloadingEffect.Read(reader);
        _chamberingEffect.Read(reader);
        _unnamed5.Read(reader);
        _magazines.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _reloadingEffect.ReadString(reader);
        _chamberingEffect.ReadString(reader);
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
        _unnamed.Write(bw);
        _reloadTime.Write(bw);
        _roundsReloaded.Write(bw);
        _unnamed2.Write(bw);
        _chamberTime.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _reloadingEffect.Write(bw);
        _chamberingEffect.Write(bw);
        _unnamed5.Write(bw);
_magazines.Count = Magazines.Count;
        _magazines.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _reloadingEffect.WriteString(writer);
        _chamberingEffect.WriteString(writer);
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
      private Pad _unnamed;
      private TagReference _equipment = new TagReference();
public event System.EventHandler BlockNameChanged;
      public MagazineObjectsBlock() {
        this._unnamed = new Pad(10);
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
return "";
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
        _unnamed.Read(reader);
        _equipment.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _equipment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _rounds.Write(bw);
        _unnamed.Write(bw);
        _equipment.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _equipment.WriteString(writer);
      }
    }
    public class TriggersBlock : IBlock {
      private Flags _flags;
      private RealBounds _roundsPerSecond = new RealBounds();
      private Real _accelerationTime = new Real();
      private Real _decelerationTime = new Real();
      private RealFraction _blurredRateOfFire = new RealFraction();
      private Pad _unnamed;
      private ShortBlockIndex _magazine = new ShortBlockIndex();
      private ShortInteger _roundsPerShot = new ShortInteger();
      private ShortInteger _minimumRoundsLoaded = new ShortInteger();
      private ShortInteger _roundsBetweenTracers = new ShortInteger();
      private Pad _unnamed2;
      private Enum _firingNoise = new Enum();
      private RealBounds _error = new RealBounds();
      private Real _accelerationTime2 = new Real();
      private Real _decelerationTime2 = new Real();
      private Pad _unnamed3;
      private Real _chargingTime = new Real();
      private Real _chargedTime = new Real();
      private Enum _overchargedAction = new Enum();
      private Pad _unnamed4;
      private Real _chargedIllumination = new Real();
      private Real _spewTime = new Real();
      private TagReference _chargingEffect = new TagReference();
      private Enum _distributionFunction = new Enum();
      private ShortInteger _projectilesPerShot = new ShortInteger();
      private Real _distributionAngle = new Real();
      private Pad _unnamed5;
      private Angle _minimumError = new Angle();
      private AngleBounds _errorAngle = new AngleBounds();
      private RealPoint3D _firstPersonOffset = new RealPoint3D();
      private Pad _unnamed6;
      private TagReference _projectile = new TagReference();
      private Real _ejectionPortRecoveryTime = new Real();
      private Real _illuminationRecoveryTime = new Real();
      private Pad _unnamed7;
      private RealFraction _heatGeneratedPerRound = new RealFraction();
      private RealFraction _ageGeneratedPerRound = new RealFraction();
      private Pad _unnamed8;
      private Real _overloadTime = new Real();
      private Pad _unnamed9;
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Block _firingEffects = new Block();
      public BlockCollection<TriggerFiringEffectBlock> _firingEffectsList = new BlockCollection<TriggerFiringEffectBlock>();
public event System.EventHandler BlockNameChanged;
      public TriggersBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(6);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(12);
        this._unnamed8 = new Pad(4);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(32);
        this._unnamed11 = new Pad(24);
      }
      public BlockCollection<TriggerFiringEffectBlock> FiringEffects {
        get {
          return this._firingEffectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_chargingEffect.Value);
references.Add(_projectile.Value);
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
      public RealFraction BlurredRateOfFire {
        get {
          return this._blurredRateOfFire;
        }
        set {
          this._blurredRateOfFire = value;
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
      public Enum FiringNoise {
        get {
          return this._firingNoise;
        }
        set {
          this._firingNoise = value;
        }
      }
      public RealBounds Error {
        get {
          return this._error;
        }
        set {
          this._error = value;
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
      public RealPoint3D FirstPersonOffset {
        get {
          return this._firstPersonOffset;
        }
        set {
          this._firstPersonOffset = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _roundsPerSecond.Read(reader);
        _accelerationTime.Read(reader);
        _decelerationTime.Read(reader);
        _blurredRateOfFire.Read(reader);
        _unnamed.Read(reader);
        _magazine.Read(reader);
        _roundsPerShot.Read(reader);
        _minimumRoundsLoaded.Read(reader);
        _roundsBetweenTracers.Read(reader);
        _unnamed2.Read(reader);
        _firingNoise.Read(reader);
        _error.Read(reader);
        _accelerationTime2.Read(reader);
        _decelerationTime2.Read(reader);
        _unnamed3.Read(reader);
        _chargingTime.Read(reader);
        _chargedTime.Read(reader);
        _overchargedAction.Read(reader);
        _unnamed4.Read(reader);
        _chargedIllumination.Read(reader);
        _spewTime.Read(reader);
        _chargingEffect.Read(reader);
        _distributionFunction.Read(reader);
        _projectilesPerShot.Read(reader);
        _distributionAngle.Read(reader);
        _unnamed5.Read(reader);
        _minimumError.Read(reader);
        _errorAngle.Read(reader);
        _firstPersonOffset.Read(reader);
        _unnamed6.Read(reader);
        _projectile.Read(reader);
        _ejectionPortRecoveryTime.Read(reader);
        _illuminationRecoveryTime.Read(reader);
        _unnamed7.Read(reader);
        _heatGeneratedPerRound.Read(reader);
        _ageGeneratedPerRound.Read(reader);
        _unnamed8.Read(reader);
        _overloadTime.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _firingEffects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _chargingEffect.ReadString(reader);
        _projectile.ReadString(reader);
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects.Add(new TriggerFiringEffectBlock());
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
        _blurredRateOfFire.Write(bw);
        _unnamed.Write(bw);
        _magazine.Write(bw);
        _roundsPerShot.Write(bw);
        _minimumRoundsLoaded.Write(bw);
        _roundsBetweenTracers.Write(bw);
        _unnamed2.Write(bw);
        _firingNoise.Write(bw);
        _error.Write(bw);
        _accelerationTime2.Write(bw);
        _decelerationTime2.Write(bw);
        _unnamed3.Write(bw);
        _chargingTime.Write(bw);
        _chargedTime.Write(bw);
        _overchargedAction.Write(bw);
        _unnamed4.Write(bw);
        _chargedIllumination.Write(bw);
        _spewTime.Write(bw);
        _chargingEffect.Write(bw);
        _distributionFunction.Write(bw);
        _projectilesPerShot.Write(bw);
        _distributionAngle.Write(bw);
        _unnamed5.Write(bw);
        _minimumError.Write(bw);
        _errorAngle.Write(bw);
        _firstPersonOffset.Write(bw);
        _unnamed6.Write(bw);
        _projectile.Write(bw);
        _ejectionPortRecoveryTime.Write(bw);
        _illuminationRecoveryTime.Write(bw);
        _unnamed7.Write(bw);
        _heatGeneratedPerRound.Write(bw);
        _ageGeneratedPerRound.Write(bw);
        _unnamed8.Write(bw);
        _overloadTime.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
_firingEffects.Count = FiringEffects.Count;
        _firingEffects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _chargingEffect.WriteString(writer);
        _projectile.WriteString(writer);
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects[x].Write(writer);
        }
        for (x = 0; (x < _firingEffects.Count); x = (x + 1)) {
          FiringEffects[x].WriteChildData(writer);
        }
      }
    }
    public class TriggerFiringEffectBlock : IBlock {
      private ShortInteger _shotCountLowerBound = new ShortInteger();
      private ShortInteger _shotCountUpperBound = new ShortInteger();
      private Pad _unnamed;
      private TagReference _firingEffect = new TagReference();
      private TagReference _misfireEffect = new TagReference();
      private TagReference _emptyEffect = new TagReference();
      private TagReference _firingDamage = new TagReference();
      private TagReference _misfireDamage = new TagReference();
      private TagReference _emptyDamage = new TagReference();
public event System.EventHandler BlockNameChanged;
      public TriggerFiringEffectBlock() {
if (this._firingEffect is System.ComponentModel.INotifyPropertyChanged)
  (this._firingEffect as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
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
        _unnamed.Read(reader);
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
        _unnamed.Write(bw);
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
