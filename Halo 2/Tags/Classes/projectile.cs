// -------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'projectile' (derived from 'object')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class projectile : @object {
    private AngularVelocityLowerBoundStructBlockBlock projectileValues = new AngularVelocityLowerBoundStructBlockBlock();
    public virtual AngularVelocityLowerBoundStructBlockBlock ProjectileValues {
      get {
        return projectileValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ProjectileValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "projectile";
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
projectileValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
projectileValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
projectileValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
projectileValues.WriteChildData(writer);
    }
    #endregion
    public class AngularVelocityLowerBoundStructBlockBlock : IBlock {
      private Flags _flags;
      private Enum _detonationTimerStarts;
      private Enum _impactNoise;
      private Real _aIPerceptionRadius = new Real();
      private Real _collisionRadius = new Real();
      private Real _armingTime = new Real();
      private Real _dangerRadius = new Real();
      private RealBounds _timer = new RealBounds();
      private Real _minimumVelocity = new Real();
      private Real _maximumRange = new Real();
      private Enum _detonationNoise;
      private ShortInteger _superDetProjectileCount = new ShortInteger();
      private TagReference _detonationStarted = new TagReference();
      private TagReference _detonationEffectAirborne = new TagReference();
      private TagReference _detonationEffectGround = new TagReference();
      private TagReference _detonationDamage = new TagReference();
      private TagReference _attachedDetonationDamage = new TagReference();
      private TagReference _superDetonation = new TagReference();
      private TagReference _superDetonationDamage = new TagReference();
      private TagReference _detonationSound = new TagReference();
      private Enum _damageReportingType;
      private Pad _unnamed0;
      private TagReference _superAttachedDetonationDamage = new TagReference();
      private Real _materialEffectRadius = new Real();
      private TagReference _flybySound = new TagReference();
      private TagReference _impactEffect = new TagReference();
      private TagReference _impactDamage = new TagReference();
      private Real _boardingDetonationTime = new Real();
      private TagReference _boardingDetonationDamage = new TagReference();
      private TagReference _boardingAttachedDetonationDamage = new TagReference();
      private Real _airGravityScale = new Real();
      private RealBounds _airDamageRange = new RealBounds();
      private Real _waterGravityScale = new Real();
      private RealBounds _waterDamageRange = new RealBounds();
      private Real _initialVelocity = new Real();
      private Real _finalVelocity = new Real();
      private Angle _guidedAngularVelocityLower = new Angle();
      private Angle _guidedAngularVelocityUpper = new Angle();
      private RealBounds _accelerationRange = new RealBounds();
      private Pad _unnamed1;
      private RealFraction _targetedLeadingFraction = new RealFraction();
      private Block _materialResponses = new Block();
      public BlockCollection<ProjectileMaterialResponseBlockBlock> _materialResponsesList = new BlockCollection<ProjectileMaterialResponseBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AngularVelocityLowerBoundStructBlockBlock() {
        this._flags = new Flags(4);
        this._detonationTimerStarts = new Enum(2);
        this._impactNoise = new Enum(2);
        this._detonationNoise = new Enum(2);
        this._damageReportingType = new Enum(1);
        this._unnamed0 = new Pad(3);
        this._unnamed1 = new Pad(4);
      }
      public BlockCollection<ProjectileMaterialResponseBlockBlock> MaterialResponses {
        get {
          return this._materialResponsesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_detonationStarted.Value);
references.Add(_detonationEffectAirborne.Value);
references.Add(_detonationEffectGround.Value);
references.Add(_detonationDamage.Value);
references.Add(_attachedDetonationDamage.Value);
references.Add(_superDetonation.Value);
references.Add(_superDetonationDamage.Value);
references.Add(_detonationSound.Value);
references.Add(_superAttachedDetonationDamage.Value);
references.Add(_flybySound.Value);
references.Add(_impactEffect.Value);
references.Add(_impactDamage.Value);
references.Add(_boardingDetonationDamage.Value);
references.Add(_boardingAttachedDetonationDamage.Value);
for (int x=0; x<MaterialResponses.BlockCount; x++)
{
  IBlock block = MaterialResponses.GetBlock(x);
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
      public Enum DetonationTimerStarts {
        get {
          return this._detonationTimerStarts;
        }
        set {
          this._detonationTimerStarts = value;
        }
      }
      public Enum ImpactNoise {
        get {
          return this._impactNoise;
        }
        set {
          this._impactNoise = value;
        }
      }
      public Real AIPerceptionRadius {
        get {
          return this._aIPerceptionRadius;
        }
        set {
          this._aIPerceptionRadius = value;
        }
      }
      public Real CollisionRadius {
        get {
          return this._collisionRadius;
        }
        set {
          this._collisionRadius = value;
        }
      }
      public Real ArmingTime {
        get {
          return this._armingTime;
        }
        set {
          this._armingTime = value;
        }
      }
      public Real DangerRadius {
        get {
          return this._dangerRadius;
        }
        set {
          this._dangerRadius = value;
        }
      }
      public RealBounds Timer {
        get {
          return this._timer;
        }
        set {
          this._timer = value;
        }
      }
      public Real MinimumVelocity {
        get {
          return this._minimumVelocity;
        }
        set {
          this._minimumVelocity = value;
        }
      }
      public Real MaximumRange {
        get {
          return this._maximumRange;
        }
        set {
          this._maximumRange = value;
        }
      }
      public Enum DetonationNoise {
        get {
          return this._detonationNoise;
        }
        set {
          this._detonationNoise = value;
        }
      }
      public ShortInteger SuperDetProjectileCount {
        get {
          return this._superDetProjectileCount;
        }
        set {
          this._superDetProjectileCount = value;
        }
      }
      public TagReference DetonationStarted {
        get {
          return this._detonationStarted;
        }
        set {
          this._detonationStarted = value;
        }
      }
      public TagReference DetonationEffectAirborne {
        get {
          return this._detonationEffectAirborne;
        }
        set {
          this._detonationEffectAirborne = value;
        }
      }
      public TagReference DetonationEffectGround {
        get {
          return this._detonationEffectGround;
        }
        set {
          this._detonationEffectGround = value;
        }
      }
      public TagReference DetonationDamage {
        get {
          return this._detonationDamage;
        }
        set {
          this._detonationDamage = value;
        }
      }
      public TagReference AttachedDetonationDamage {
        get {
          return this._attachedDetonationDamage;
        }
        set {
          this._attachedDetonationDamage = value;
        }
      }
      public TagReference SuperDetonation {
        get {
          return this._superDetonation;
        }
        set {
          this._superDetonation = value;
        }
      }
      public TagReference SuperDetonationDamage {
        get {
          return this._superDetonationDamage;
        }
        set {
          this._superDetonationDamage = value;
        }
      }
      public TagReference DetonationSound {
        get {
          return this._detonationSound;
        }
        set {
          this._detonationSound = value;
        }
      }
      public Enum DamageReportingType {
        get {
          return this._damageReportingType;
        }
        set {
          this._damageReportingType = value;
        }
      }
      public TagReference SuperAttachedDetonationDamage {
        get {
          return this._superAttachedDetonationDamage;
        }
        set {
          this._superAttachedDetonationDamage = value;
        }
      }
      public Real MaterialEffectRadius {
        get {
          return this._materialEffectRadius;
        }
        set {
          this._materialEffectRadius = value;
        }
      }
      public TagReference FlybySound {
        get {
          return this._flybySound;
        }
        set {
          this._flybySound = value;
        }
      }
      public TagReference ImpactEffect {
        get {
          return this._impactEffect;
        }
        set {
          this._impactEffect = value;
        }
      }
      public TagReference ImpactDamage {
        get {
          return this._impactDamage;
        }
        set {
          this._impactDamage = value;
        }
      }
      public Real BoardingDetonationTime {
        get {
          return this._boardingDetonationTime;
        }
        set {
          this._boardingDetonationTime = value;
        }
      }
      public TagReference BoardingDetonationDamage {
        get {
          return this._boardingDetonationDamage;
        }
        set {
          this._boardingDetonationDamage = value;
        }
      }
      public TagReference BoardingAttachedDetonationDamage {
        get {
          return this._boardingAttachedDetonationDamage;
        }
        set {
          this._boardingAttachedDetonationDamage = value;
        }
      }
      public Real AirGravityScale {
        get {
          return this._airGravityScale;
        }
        set {
          this._airGravityScale = value;
        }
      }
      public RealBounds AirDamageRange {
        get {
          return this._airDamageRange;
        }
        set {
          this._airDamageRange = value;
        }
      }
      public Real WaterGravityScale {
        get {
          return this._waterGravityScale;
        }
        set {
          this._waterGravityScale = value;
        }
      }
      public RealBounds WaterDamageRange {
        get {
          return this._waterDamageRange;
        }
        set {
          this._waterDamageRange = value;
        }
      }
      public Real InitialVelocity {
        get {
          return this._initialVelocity;
        }
        set {
          this._initialVelocity = value;
        }
      }
      public Real FinalVelocity {
        get {
          return this._finalVelocity;
        }
        set {
          this._finalVelocity = value;
        }
      }
      public Angle GuidedAngularVelocityLower {
        get {
          return this._guidedAngularVelocityLower;
        }
        set {
          this._guidedAngularVelocityLower = value;
        }
      }
      public Angle GuidedAngularVelocityUpper {
        get {
          return this._guidedAngularVelocityUpper;
        }
        set {
          this._guidedAngularVelocityUpper = value;
        }
      }
      public RealBounds AccelerationRange {
        get {
          return this._accelerationRange;
        }
        set {
          this._accelerationRange = value;
        }
      }
      public RealFraction TargetedLeadingFraction {
        get {
          return this._targetedLeadingFraction;
        }
        set {
          this._targetedLeadingFraction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _detonationTimerStarts.Read(reader);
        _impactNoise.Read(reader);
        _aIPerceptionRadius.Read(reader);
        _collisionRadius.Read(reader);
        _armingTime.Read(reader);
        _dangerRadius.Read(reader);
        _timer.Read(reader);
        _minimumVelocity.Read(reader);
        _maximumRange.Read(reader);
        _detonationNoise.Read(reader);
        _superDetProjectileCount.Read(reader);
        _detonationStarted.Read(reader);
        _detonationEffectAirborne.Read(reader);
        _detonationEffectGround.Read(reader);
        _detonationDamage.Read(reader);
        _attachedDetonationDamage.Read(reader);
        _superDetonation.Read(reader);
        _superDetonationDamage.Read(reader);
        _detonationSound.Read(reader);
        _damageReportingType.Read(reader);
        _unnamed0.Read(reader);
        _superAttachedDetonationDamage.Read(reader);
        _materialEffectRadius.Read(reader);
        _flybySound.Read(reader);
        _impactEffect.Read(reader);
        _impactDamage.Read(reader);
        _boardingDetonationTime.Read(reader);
        _boardingDetonationDamage.Read(reader);
        _boardingAttachedDetonationDamage.Read(reader);
        _airGravityScale.Read(reader);
        _airDamageRange.Read(reader);
        _waterGravityScale.Read(reader);
        _waterDamageRange.Read(reader);
        _initialVelocity.Read(reader);
        _finalVelocity.Read(reader);
        _guidedAngularVelocityLower.Read(reader);
        _guidedAngularVelocityUpper.Read(reader);
        _accelerationRange.Read(reader);
        _unnamed1.Read(reader);
        _targetedLeadingFraction.Read(reader);
        _materialResponses.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _detonationStarted.ReadString(reader);
        _detonationEffectAirborne.ReadString(reader);
        _detonationEffectGround.ReadString(reader);
        _detonationDamage.ReadString(reader);
        _attachedDetonationDamage.ReadString(reader);
        _superDetonation.ReadString(reader);
        _superDetonationDamage.ReadString(reader);
        _detonationSound.ReadString(reader);
        _superAttachedDetonationDamage.ReadString(reader);
        _flybySound.ReadString(reader);
        _impactEffect.ReadString(reader);
        _impactDamage.ReadString(reader);
        _boardingDetonationDamage.ReadString(reader);
        _boardingAttachedDetonationDamage.ReadString(reader);
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses.Add(new ProjectileMaterialResponseBlockBlock());
          MaterialResponses[x].Read(reader);
        }
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _detonationTimerStarts.Write(bw);
        _impactNoise.Write(bw);
        _aIPerceptionRadius.Write(bw);
        _collisionRadius.Write(bw);
        _armingTime.Write(bw);
        _dangerRadius.Write(bw);
        _timer.Write(bw);
        _minimumVelocity.Write(bw);
        _maximumRange.Write(bw);
        _detonationNoise.Write(bw);
        _superDetProjectileCount.Write(bw);
        _detonationStarted.Write(bw);
        _detonationEffectAirborne.Write(bw);
        _detonationEffectGround.Write(bw);
        _detonationDamage.Write(bw);
        _attachedDetonationDamage.Write(bw);
        _superDetonation.Write(bw);
        _superDetonationDamage.Write(bw);
        _detonationSound.Write(bw);
        _damageReportingType.Write(bw);
        _unnamed0.Write(bw);
        _superAttachedDetonationDamage.Write(bw);
        _materialEffectRadius.Write(bw);
        _flybySound.Write(bw);
        _impactEffect.Write(bw);
        _impactDamage.Write(bw);
        _boardingDetonationTime.Write(bw);
        _boardingDetonationDamage.Write(bw);
        _boardingAttachedDetonationDamage.Write(bw);
        _airGravityScale.Write(bw);
        _airDamageRange.Write(bw);
        _waterGravityScale.Write(bw);
        _waterDamageRange.Write(bw);
        _initialVelocity.Write(bw);
        _finalVelocity.Write(bw);
        _guidedAngularVelocityLower.Write(bw);
        _guidedAngularVelocityUpper.Write(bw);
        _accelerationRange.Write(bw);
        _unnamed1.Write(bw);
        _targetedLeadingFraction.Write(bw);
_materialResponses.Count = MaterialResponses.Count;
        _materialResponses.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _detonationStarted.WriteString(writer);
        _detonationEffectAirborne.WriteString(writer);
        _detonationEffectGround.WriteString(writer);
        _detonationDamage.WriteString(writer);
        _attachedDetonationDamage.WriteString(writer);
        _superDetonation.WriteString(writer);
        _superDetonationDamage.WriteString(writer);
        _detonationSound.WriteString(writer);
        _superAttachedDetonationDamage.WriteString(writer);
        _flybySound.WriteString(writer);
        _impactEffect.WriteString(writer);
        _impactDamage.WriteString(writer);
        _boardingDetonationDamage.WriteString(writer);
        _boardingAttachedDetonationDamage.WriteString(writer);
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses[x].Write(writer);
        }
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses[x].WriteChildData(writer);
        }
      }
    }
    public class ProjectileMaterialResponseBlockBlock : IBlock {
      private Flags _flags;
      private Enum _response;
      private TagReference _dONOTUSEOLDEffect = new TagReference();
      private StringId _materialName = new StringId();
      private Skip _unnamed0;
      private Enum _response2;
      private Flags _flags2;
      private RealFraction _chanceFraction = new RealFraction();
      private AngleBounds _between = new AngleBounds();
      private RealBounds _and = new RealBounds();
      private TagReference _dONOTUSEOLDEffect2 = new TagReference();
      private Enum _scaleEffectsBy;
      private Pad _unnamed1;
      private Angle _angularNoise = new Angle();
      private Real _velocityNoise = new Real();
      private TagReference _dONOTUSEOLDDetonationEffect = new TagReference();
      private Real _initialFriction = new Real();
      private Real _maximumDistance = new Real();
      private Real _parallelFriction = new Real();
      private Real _perpendicularFriction = new Real();
public event System.EventHandler BlockNameChanged;
      public ProjectileMaterialResponseBlockBlock() {
        this._flags = new Flags(2);
        this._response = new Enum(2);
        this._unnamed0 = new Skip(4);
        this._response2 = new Enum(2);
        this._flags2 = new Flags(2);
        this._scaleEffectsBy = new Enum(2);
        this._unnamed1 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dONOTUSEOLDEffect.Value);
references.Add(_dONOTUSEOLDEffect2.Value);
references.Add(_dONOTUSEOLDDetonationEffect.Value);
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
      public Enum Response {
        get {
          return this._response;
        }
        set {
          this._response = value;
        }
      }
      public TagReference DONOTUSEOLDEffect {
        get {
          return this._dONOTUSEOLDEffect;
        }
        set {
          this._dONOTUSEOLDEffect = value;
        }
      }
      public StringId MaterialName {
        get {
          return this._materialName;
        }
        set {
          this._materialName = value;
        }
      }
      public Enum Response2 {
        get {
          return this._response2;
        }
        set {
          this._response2 = value;
        }
      }
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public RealFraction ChanceFraction {
        get {
          return this._chanceFraction;
        }
        set {
          this._chanceFraction = value;
        }
      }
      public AngleBounds Between {
        get {
          return this._between;
        }
        set {
          this._between = value;
        }
      }
      public RealBounds And {
        get {
          return this._and;
        }
        set {
          this._and = value;
        }
      }
      public TagReference DONOTUSEOLDEffect2 {
        get {
          return this._dONOTUSEOLDEffect2;
        }
        set {
          this._dONOTUSEOLDEffect2 = value;
        }
      }
      public Enum ScaleEffectsBy {
        get {
          return this._scaleEffectsBy;
        }
        set {
          this._scaleEffectsBy = value;
        }
      }
      public Angle AngularNoise {
        get {
          return this._angularNoise;
        }
        set {
          this._angularNoise = value;
        }
      }
      public Real VelocityNoise {
        get {
          return this._velocityNoise;
        }
        set {
          this._velocityNoise = value;
        }
      }
      public TagReference DONOTUSEOLDDetonationEffect {
        get {
          return this._dONOTUSEOLDDetonationEffect;
        }
        set {
          this._dONOTUSEOLDDetonationEffect = value;
        }
      }
      public Real InitialFriction {
        get {
          return this._initialFriction;
        }
        set {
          this._initialFriction = value;
        }
      }
      public Real MaximumDistance {
        get {
          return this._maximumDistance;
        }
        set {
          this._maximumDistance = value;
        }
      }
      public Real ParallelFriction {
        get {
          return this._parallelFriction;
        }
        set {
          this._parallelFriction = value;
        }
      }
      public Real PerpendicularFriction {
        get {
          return this._perpendicularFriction;
        }
        set {
          this._perpendicularFriction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _response.Read(reader);
        _dONOTUSEOLDEffect.Read(reader);
        _materialName.Read(reader);
        _unnamed0.Read(reader);
        _response2.Read(reader);
        _flags2.Read(reader);
        _chanceFraction.Read(reader);
        _between.Read(reader);
        _and.Read(reader);
        _dONOTUSEOLDEffect2.Read(reader);
        _scaleEffectsBy.Read(reader);
        _unnamed1.Read(reader);
        _angularNoise.Read(reader);
        _velocityNoise.Read(reader);
        _dONOTUSEOLDDetonationEffect.Read(reader);
        _initialFriction.Read(reader);
        _maximumDistance.Read(reader);
        _parallelFriction.Read(reader);
        _perpendicularFriction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _dONOTUSEOLDEffect.ReadString(reader);
        _materialName.ReadString(reader);
        _dONOTUSEOLDEffect2.ReadString(reader);
        _dONOTUSEOLDDetonationEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _response.Write(bw);
        _dONOTUSEOLDEffect.Write(bw);
        _materialName.Write(bw);
        _unnamed0.Write(bw);
        _response2.Write(bw);
        _flags2.Write(bw);
        _chanceFraction.Write(bw);
        _between.Write(bw);
        _and.Write(bw);
        _dONOTUSEOLDEffect2.Write(bw);
        _scaleEffectsBy.Write(bw);
        _unnamed1.Write(bw);
        _angularNoise.Write(bw);
        _velocityNoise.Write(bw);
        _dONOTUSEOLDDetonationEffect.Write(bw);
        _initialFriction.Write(bw);
        _maximumDistance.Write(bw);
        _parallelFriction.Write(bw);
        _perpendicularFriction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _dONOTUSEOLDEffect.WriteString(writer);
        _materialName.WriteString(writer);
        _dONOTUSEOLDEffect2.WriteString(writer);
        _dONOTUSEOLDDetonationEffect.WriteString(writer);
      }
    }
  }
}
