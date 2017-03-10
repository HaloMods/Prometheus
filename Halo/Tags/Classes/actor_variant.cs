// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'actor_variant'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class actor_variant : Interfaces.Pool.Tag {
    private ActorVariantBlock actorVariantValues = new ActorVariantBlock();
    public virtual ActorVariantBlock ActorVariantValues {
      get {
        return actorVariantValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ActorVariantValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "actor_variant";
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
actorVariantValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
actorVariantValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
actorVariantValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
actorVariantValues.WriteChildData(writer);
    }
    #endregion
    public class ActorVariantBlock : IBlock {
      private Flags _flags;
      private TagReference _actorDefinition = new TagReference();
      private TagReference _unit = new TagReference();
      private TagReference _majorVariant = new TagReference();
      private Pad _unnamed;
      private Enum _movementType = new Enum();
      private Pad _unnamed2;
      private Real _initialCrouchChance = new Real();
      private RealBounds _crouchTime = new RealBounds();
      private RealBounds _runTime = new RealBounds();
      private TagReference _weapon = new TagReference();
      private Real _maximumFiringDistance = new Real();
      private Real _rateOfFire = new Real();
      private Angle _projectileError = new Angle();
      private RealBounds _firstBurstDelayTime = new RealBounds();
      private Real _ne = new Real();
      private Real _surpriseDelayTime = new Real();
      private Real _surpriseFir = new Real();
      private Real _deathFir = new Real();
      private Real _deathFir2 = new Real();
      private RealBounds _desiredCombatRange = new RealBounds();
      private RealVector3D _customStandGunOffset = new RealVector3D();
      private RealVector3D _customCrouchGunOffset = new RealVector3D();
      private Real _targetTracking = new Real();
      private Real _targetLeading = new Real();
      private Real _weaponDamageModifier = new Real();
      private Real _damagePerSecond = new Real();
      private Real _burstOriginRadius = new Real();
      private Angle _burstOriginAngle = new Angle();
      private RealBounds _burstReturnLength = new RealBounds();
      private Angle _burstReturnAngle = new Angle();
      private RealBounds _burstDuration = new RealBounds();
      private RealBounds _burstSeparation = new RealBounds();
      private Angle _burstAngularVelocity = new Angle();
      private Pad _unnamed3;
      private Real _specialDamageModifier = new Real();
      private Angle _specialProjectileError = new Angle();
      private Real _ne2 = new Real();
      private Real _ne3 = new Real();
      private Real _ne4 = new Real();
      private Real _ne5 = new Real();
      private Pad _unnamed4;
      private Real _movingBurstDuration = new Real();
      private Real _movingBurstSeparation = new Real();
      private Real _movingRateOfFire = new Real();
      private Real _movingProjectileError = new Real();
      private Pad _unnamed5;
      private Real _berserkBurstDuration = new Real();
      private Real _berserkBurstSeparation = new Real();
      private Real _berserkRateOfFire = new Real();
      private Real _berserkProjectileError = new Real();
      private Pad _unnamed6;
      private Real _supe = new Real();
      private Real _bombardmentRange = new Real();
      private Real _modifiedVisionRange = new Real();
      private Enum _specia = new Enum();
      private Enum _specia2 = new Enum();
      private Real _specia3 = new Real();
      private Real _specia4 = new Real();
      private Real _meleeRange = new Real();
      private Real _meleeAbortRange = new Real();
      private RealBounds _berserkFiringRanges = new RealBounds();
      private Real _berserkMeleeRange = new Real();
      private Real _berserkMeleeAbortRange = new Real();
      private Pad _unnamed7;
      private Enum _grenadeType = new Enum();
      private Enum _trajectoryType = new Enum();
      private Enum _grenadeStimulus = new Enum();
      private ShortInteger _minimumEnemyCount = new ShortInteger();
      private Real _enemyRadius = new Real();
      private Pad _unnamed8;
      private Real _grenadeVelocity = new Real();
      private RealBounds _grenadeRanges = new RealBounds();
      private Real _collateralDamageRadius = new Real();
      private RealFraction _grenadeChance = new RealFraction();
      private Real _grenadeCheckTime = new Real();
      private Real _encounterGrenadeTimeout = new Real();
      private Pad _unnamed9;
      private TagReference _equipment = new TagReference();
      private ShortBounds _grenadeCount = new ShortBounds();
      private Real _dontDropGrenadesChance = new Real();
      private RealBounds _dropWeaponLoaded = new RealBounds();
      private ShortBounds _dropWeaponAmmo = new ShortBounds();
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Real _bodyVitality = new Real();
      private Real _shieldVitality = new Real();
      private Real _shieldSappingRadius = new Real();
      private ShortInteger _forcedShaderPermutation = new ShortInteger();
      private Pad _unnamed12;
      private Pad _unnamed13;
      private Pad _unnamed14;
      private Block _changeColors = new Block();
      public BlockCollection<ActorVariantChangeColorsBlock> _changeColorsList = new BlockCollection<ActorVariantChangeColorsBlock>();
public event System.EventHandler BlockNameChanged;
      public ActorVariantBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(24);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(8);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(4);
        this._unnamed9 = new Pad(20);
        this._unnamed10 = new Pad(12);
        this._unnamed11 = new Pad(16);
        this._unnamed12 = new Pad(2);
        this._unnamed13 = new Pad(16);
        this._unnamed14 = new Pad(12);
      }
      public BlockCollection<ActorVariantChangeColorsBlock> ChangeColors {
        get {
          return this._changeColorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_actorDefinition.Value);
references.Add(_unit.Value);
references.Add(_majorVariant.Value);
references.Add(_weapon.Value);
references.Add(_equipment.Value);
for (int x=0; x<ChangeColors.BlockCount; x++)
{
  IBlock block = ChangeColors.GetBlock(x);
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
      public TagReference ActorDefinition {
        get {
          return this._actorDefinition;
        }
        set {
          this._actorDefinition = value;
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
      public TagReference MajorVariant {
        get {
          return this._majorVariant;
        }
        set {
          this._majorVariant = value;
        }
      }
      public Enum MovementType {
        get {
          return this._movementType;
        }
        set {
          this._movementType = value;
        }
      }
      public Real InitialCrouchChance {
        get {
          return this._initialCrouchChance;
        }
        set {
          this._initialCrouchChance = value;
        }
      }
      public RealBounds CrouchTime {
        get {
          return this._crouchTime;
        }
        set {
          this._crouchTime = value;
        }
      }
      public RealBounds RunTime {
        get {
          return this._runTime;
        }
        set {
          this._runTime = value;
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
      public Real MaximumFiringDistance {
        get {
          return this._maximumFiringDistance;
        }
        set {
          this._maximumFiringDistance = value;
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
      public Angle ProjectileError {
        get {
          return this._projectileError;
        }
        set {
          this._projectileError = value;
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
      public Real Ne {
        get {
          return this._ne;
        }
        set {
          this._ne = value;
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
      public Real SurpriseFir {
        get {
          return this._surpriseFir;
        }
        set {
          this._surpriseFir = value;
        }
      }
      public Real DeathFir {
        get {
          return this._deathFir;
        }
        set {
          this._deathFir = value;
        }
      }
      public Real DeathFir2 {
        get {
          return this._deathFir2;
        }
        set {
          this._deathFir2 = value;
        }
      }
      public RealBounds DesiredCombatRange {
        get {
          return this._desiredCombatRange;
        }
        set {
          this._desiredCombatRange = value;
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
      public Real WeaponDamageModifier {
        get {
          return this._weaponDamageModifier;
        }
        set {
          this._weaponDamageModifier = value;
        }
      }
      public Real DamagePerSecond {
        get {
          return this._damagePerSecond;
        }
        set {
          this._damagePerSecond = value;
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
      public Angle BurstAngularVelocity {
        get {
          return this._burstAngularVelocity;
        }
        set {
          this._burstAngularVelocity = value;
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
      public Real Ne2 {
        get {
          return this._ne2;
        }
        set {
          this._ne2 = value;
        }
      }
      public Real Ne3 {
        get {
          return this._ne3;
        }
        set {
          this._ne3 = value;
        }
      }
      public Real Ne4 {
        get {
          return this._ne4;
        }
        set {
          this._ne4 = value;
        }
      }
      public Real Ne5 {
        get {
          return this._ne5;
        }
        set {
          this._ne5 = value;
        }
      }
      public Real MovingBurstDuration {
        get {
          return this._movingBurstDuration;
        }
        set {
          this._movingBurstDuration = value;
        }
      }
      public Real MovingBurstSeparation {
        get {
          return this._movingBurstSeparation;
        }
        set {
          this._movingBurstSeparation = value;
        }
      }
      public Real MovingRateOfFire {
        get {
          return this._movingRateOfFire;
        }
        set {
          this._movingRateOfFire = value;
        }
      }
      public Real MovingProjectileError {
        get {
          return this._movingProjectileError;
        }
        set {
          this._movingProjectileError = value;
        }
      }
      public Real BerserkBurstDuration {
        get {
          return this._berserkBurstDuration;
        }
        set {
          this._berserkBurstDuration = value;
        }
      }
      public Real BerserkBurstSeparation {
        get {
          return this._berserkBurstSeparation;
        }
        set {
          this._berserkBurstSeparation = value;
        }
      }
      public Real BerserkRateOfFire {
        get {
          return this._berserkRateOfFire;
        }
        set {
          this._berserkRateOfFire = value;
        }
      }
      public Real BerserkProjectileError {
        get {
          return this._berserkProjectileError;
        }
        set {
          this._berserkProjectileError = value;
        }
      }
      public Real Supe {
        get {
          return this._supe;
        }
        set {
          this._supe = value;
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
      public Real ModifiedVisionRange {
        get {
          return this._modifiedVisionRange;
        }
        set {
          this._modifiedVisionRange = value;
        }
      }
      public Enum Specia {
        get {
          return this._specia;
        }
        set {
          this._specia = value;
        }
      }
      public Enum Specia2 {
        get {
          return this._specia2;
        }
        set {
          this._specia2 = value;
        }
      }
      public Real Specia3 {
        get {
          return this._specia3;
        }
        set {
          this._specia3 = value;
        }
      }
      public Real Specia4 {
        get {
          return this._specia4;
        }
        set {
          this._specia4 = value;
        }
      }
      public Real MeleeRange {
        get {
          return this._meleeRange;
        }
        set {
          this._meleeRange = value;
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
      public RealBounds BerserkFiringRanges {
        get {
          return this._berserkFiringRanges;
        }
        set {
          this._berserkFiringRanges = value;
        }
      }
      public Real BerserkMeleeRange {
        get {
          return this._berserkMeleeRange;
        }
        set {
          this._berserkMeleeRange = value;
        }
      }
      public Real BerserkMeleeAbortRange {
        get {
          return this._berserkMeleeAbortRange;
        }
        set {
          this._berserkMeleeAbortRange = value;
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
      public Enum GrenadeStimulus {
        get {
          return this._grenadeStimulus;
        }
        set {
          this._grenadeStimulus = value;
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
      public Real GrenadeCheckTime {
        get {
          return this._grenadeCheckTime;
        }
        set {
          this._grenadeCheckTime = value;
        }
      }
      public Real EncounterGrenadeTimeout {
        get {
          return this._encounterGrenadeTimeout;
        }
        set {
          this._encounterGrenadeTimeout = value;
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
      public ShortBounds GrenadeCount {
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
      public RealBounds DropWeaponLoaded {
        get {
          return this._dropWeaponLoaded;
        }
        set {
          this._dropWeaponLoaded = value;
        }
      }
      public ShortBounds DropWeaponAmmo {
        get {
          return this._dropWeaponAmmo;
        }
        set {
          this._dropWeaponAmmo = value;
        }
      }
      public Real BodyVitality {
        get {
          return this._bodyVitality;
        }
        set {
          this._bodyVitality = value;
        }
      }
      public Real ShieldVitality {
        get {
          return this._shieldVitality;
        }
        set {
          this._shieldVitality = value;
        }
      }
      public Real ShieldSappingRadius {
        get {
          return this._shieldSappingRadius;
        }
        set {
          this._shieldSappingRadius = value;
        }
      }
      public ShortInteger ForcedShaderPermutation {
        get {
          return this._forcedShaderPermutation;
        }
        set {
          this._forcedShaderPermutation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _actorDefinition.Read(reader);
        _unit.Read(reader);
        _majorVariant.Read(reader);
        _unnamed.Read(reader);
        _movementType.Read(reader);
        _unnamed2.Read(reader);
        _initialCrouchChance.Read(reader);
        _crouchTime.Read(reader);
        _runTime.Read(reader);
        _weapon.Read(reader);
        _maximumFiringDistance.Read(reader);
        _rateOfFire.Read(reader);
        _projectileError.Read(reader);
        _firstBurstDelayTime.Read(reader);
        _ne.Read(reader);
        _surpriseDelayTime.Read(reader);
        _surpriseFir.Read(reader);
        _deathFir.Read(reader);
        _deathFir2.Read(reader);
        _desiredCombatRange.Read(reader);
        _customStandGunOffset.Read(reader);
        _customCrouchGunOffset.Read(reader);
        _targetTracking.Read(reader);
        _targetLeading.Read(reader);
        _weaponDamageModifier.Read(reader);
        _damagePerSecond.Read(reader);
        _burstOriginRadius.Read(reader);
        _burstOriginAngle.Read(reader);
        _burstReturnLength.Read(reader);
        _burstReturnAngle.Read(reader);
        _burstDuration.Read(reader);
        _burstSeparation.Read(reader);
        _burstAngularVelocity.Read(reader);
        _unnamed3.Read(reader);
        _specialDamageModifier.Read(reader);
        _specialProjectileError.Read(reader);
        _ne2.Read(reader);
        _ne3.Read(reader);
        _ne4.Read(reader);
        _ne5.Read(reader);
        _unnamed4.Read(reader);
        _movingBurstDuration.Read(reader);
        _movingBurstSeparation.Read(reader);
        _movingRateOfFire.Read(reader);
        _movingProjectileError.Read(reader);
        _unnamed5.Read(reader);
        _berserkBurstDuration.Read(reader);
        _berserkBurstSeparation.Read(reader);
        _berserkRateOfFire.Read(reader);
        _berserkProjectileError.Read(reader);
        _unnamed6.Read(reader);
        _supe.Read(reader);
        _bombardmentRange.Read(reader);
        _modifiedVisionRange.Read(reader);
        _specia.Read(reader);
        _specia2.Read(reader);
        _specia3.Read(reader);
        _specia4.Read(reader);
        _meleeRange.Read(reader);
        _meleeAbortRange.Read(reader);
        _berserkFiringRanges.Read(reader);
        _berserkMeleeRange.Read(reader);
        _berserkMeleeAbortRange.Read(reader);
        _unnamed7.Read(reader);
        _grenadeType.Read(reader);
        _trajectoryType.Read(reader);
        _grenadeStimulus.Read(reader);
        _minimumEnemyCount.Read(reader);
        _enemyRadius.Read(reader);
        _unnamed8.Read(reader);
        _grenadeVelocity.Read(reader);
        _grenadeRanges.Read(reader);
        _collateralDamageRadius.Read(reader);
        _grenadeChance.Read(reader);
        _grenadeCheckTime.Read(reader);
        _encounterGrenadeTimeout.Read(reader);
        _unnamed9.Read(reader);
        _equipment.Read(reader);
        _grenadeCount.Read(reader);
        _dontDropGrenadesChance.Read(reader);
        _dropWeaponLoaded.Read(reader);
        _dropWeaponAmmo.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _bodyVitality.Read(reader);
        _shieldVitality.Read(reader);
        _shieldSappingRadius.Read(reader);
        _forcedShaderPermutation.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _changeColors.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _actorDefinition.ReadString(reader);
        _unit.ReadString(reader);
        _majorVariant.ReadString(reader);
        _weapon.ReadString(reader);
        _equipment.ReadString(reader);
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors.Add(new ActorVariantChangeColorsBlock());
          ChangeColors[x].Read(reader);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _actorDefinition.Write(bw);
        _unit.Write(bw);
        _majorVariant.Write(bw);
        _unnamed.Write(bw);
        _movementType.Write(bw);
        _unnamed2.Write(bw);
        _initialCrouchChance.Write(bw);
        _crouchTime.Write(bw);
        _runTime.Write(bw);
        _weapon.Write(bw);
        _maximumFiringDistance.Write(bw);
        _rateOfFire.Write(bw);
        _projectileError.Write(bw);
        _firstBurstDelayTime.Write(bw);
        _ne.Write(bw);
        _surpriseDelayTime.Write(bw);
        _surpriseFir.Write(bw);
        _deathFir.Write(bw);
        _deathFir2.Write(bw);
        _desiredCombatRange.Write(bw);
        _customStandGunOffset.Write(bw);
        _customCrouchGunOffset.Write(bw);
        _targetTracking.Write(bw);
        _targetLeading.Write(bw);
        _weaponDamageModifier.Write(bw);
        _damagePerSecond.Write(bw);
        _burstOriginRadius.Write(bw);
        _burstOriginAngle.Write(bw);
        _burstReturnLength.Write(bw);
        _burstReturnAngle.Write(bw);
        _burstDuration.Write(bw);
        _burstSeparation.Write(bw);
        _burstAngularVelocity.Write(bw);
        _unnamed3.Write(bw);
        _specialDamageModifier.Write(bw);
        _specialProjectileError.Write(bw);
        _ne2.Write(bw);
        _ne3.Write(bw);
        _ne4.Write(bw);
        _ne5.Write(bw);
        _unnamed4.Write(bw);
        _movingBurstDuration.Write(bw);
        _movingBurstSeparation.Write(bw);
        _movingRateOfFire.Write(bw);
        _movingProjectileError.Write(bw);
        _unnamed5.Write(bw);
        _berserkBurstDuration.Write(bw);
        _berserkBurstSeparation.Write(bw);
        _berserkRateOfFire.Write(bw);
        _berserkProjectileError.Write(bw);
        _unnamed6.Write(bw);
        _supe.Write(bw);
        _bombardmentRange.Write(bw);
        _modifiedVisionRange.Write(bw);
        _specia.Write(bw);
        _specia2.Write(bw);
        _specia3.Write(bw);
        _specia4.Write(bw);
        _meleeRange.Write(bw);
        _meleeAbortRange.Write(bw);
        _berserkFiringRanges.Write(bw);
        _berserkMeleeRange.Write(bw);
        _berserkMeleeAbortRange.Write(bw);
        _unnamed7.Write(bw);
        _grenadeType.Write(bw);
        _trajectoryType.Write(bw);
        _grenadeStimulus.Write(bw);
        _minimumEnemyCount.Write(bw);
        _enemyRadius.Write(bw);
        _unnamed8.Write(bw);
        _grenadeVelocity.Write(bw);
        _grenadeRanges.Write(bw);
        _collateralDamageRadius.Write(bw);
        _grenadeChance.Write(bw);
        _grenadeCheckTime.Write(bw);
        _encounterGrenadeTimeout.Write(bw);
        _unnamed9.Write(bw);
        _equipment.Write(bw);
        _grenadeCount.Write(bw);
        _dontDropGrenadesChance.Write(bw);
        _dropWeaponLoaded.Write(bw);
        _dropWeaponAmmo.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _bodyVitality.Write(bw);
        _shieldVitality.Write(bw);
        _shieldSappingRadius.Write(bw);
        _forcedShaderPermutation.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
_changeColors.Count = ChangeColors.Count;
        _changeColors.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _actorDefinition.WriteString(writer);
        _unit.WriteString(writer);
        _majorVariant.WriteString(writer);
        _weapon.WriteString(writer);
        _equipment.WriteString(writer);
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].Write(writer);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].WriteChildData(writer);
        }
      }
    }
    public class ActorVariantChangeColorsBlock : IBlock {
      private RealRGBColor _colorLowerBound = new RealRGBColor();
      private RealRGBColor _colorUpperBound = new RealRGBColor();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ActorVariantChangeColorsBlock() {
        this._unnamed = new Pad(8);
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
      public RealRGBColor ColorLowerBound {
        get {
          return this._colorLowerBound;
        }
        set {
          this._colorLowerBound = value;
        }
      }
      public RealRGBColor ColorUpperBound {
        get {
          return this._colorUpperBound;
        }
        set {
          this._colorUpperBound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
