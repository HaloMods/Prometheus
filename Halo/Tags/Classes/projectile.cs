// -------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'projectile' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class projectile : @object {
    private ProjectileBlock projectileValues = new ProjectileBlock();
    public virtual ProjectileBlock ProjectileValues {
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
    public class ProjectileBlock : IBlock {
      private Flags _flags;
      private Enum _detonationTimerStarts = new Enum();
      private Enum _impactNoise = new Enum();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private TagReference _superDetonation = new TagReference();
      private Real _aIPerceptionRadius = new Real();
      private Real _collisionRadius = new Real();
      private Real _armingTime = new Real();
      private Real _dangerRadius = new Real();
      private TagReference _effect = new TagReference();
      private RealBounds _timer = new RealBounds();
      private Real _minimumVelocity = new Real();
      private Real _maximumRange = new Real();
      private Real _airGravityScale = new Real();
      private RealBounds _airDamageRange = new RealBounds();
      private Real _waterGravityScale = new Real();
      private RealBounds _waterDamageRange = new RealBounds();
      private Real _initialVelocity = new Real();
      private Real _finalVelocity = new Real();
      private Angle _guidedAngularVelocity = new Angle();
      private Enum _detonationNoise = new Enum();
      private Pad _unnamed;
      private TagReference _detonationStarted = new TagReference();
      private TagReference _flybySound = new TagReference();
      private TagReference _attachedDetonationDamage = new TagReference();
      private TagReference _impactDamage = new TagReference();
      private Pad _unnamed2;
      private Block _materialResponses = new Block();
      public BlockCollection<ProjectileMaterialResponseBlock> _materialResponsesList = new BlockCollection<ProjectileMaterialResponseBlock>();
public event System.EventHandler BlockNameChanged;
      public ProjectileBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
      }
      public BlockCollection<ProjectileMaterialResponseBlock> MaterialResponses {
        get {
          return this._materialResponsesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_superDetonation.Value);
references.Add(_effect.Value);
references.Add(_detonationStarted.Value);
references.Add(_flybySound.Value);
references.Add(_attachedDetonationDamage.Value);
references.Add(_impactDamage.Value);
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
      public TagReference SuperDetonation {
        get {
          return this._superDetonation;
        }
        set {
          this._superDetonation = value;
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
      public TagReference Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
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
      public Angle GuidedAngularVelocity {
        get {
          return this._guidedAngularVelocity;
        }
        set {
          this._guidedAngularVelocity = value;
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
      public TagReference DetonationStarted {
        get {
          return this._detonationStarted;
        }
        set {
          this._detonationStarted = value;
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
      public TagReference AttachedDetonationDamage {
        get {
          return this._attachedDetonationDamage;
        }
        set {
          this._attachedDetonationDamage = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _detonationTimerStarts.Read(reader);
        _impactNoise.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _superDetonation.Read(reader);
        _aIPerceptionRadius.Read(reader);
        _collisionRadius.Read(reader);
        _armingTime.Read(reader);
        _dangerRadius.Read(reader);
        _effect.Read(reader);
        _timer.Read(reader);
        _minimumVelocity.Read(reader);
        _maximumRange.Read(reader);
        _airGravityScale.Read(reader);
        _airDamageRange.Read(reader);
        _waterGravityScale.Read(reader);
        _waterDamageRange.Read(reader);
        _initialVelocity.Read(reader);
        _finalVelocity.Read(reader);
        _guidedAngularVelocity.Read(reader);
        _detonationNoise.Read(reader);
        _unnamed.Read(reader);
        _detonationStarted.Read(reader);
        _flybySound.Read(reader);
        _attachedDetonationDamage.Read(reader);
        _impactDamage.Read(reader);
        _unnamed2.Read(reader);
        _materialResponses.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _superDetonation.ReadString(reader);
        _effect.ReadString(reader);
        _detonationStarted.ReadString(reader);
        _flybySound.ReadString(reader);
        _attachedDetonationDamage.ReadString(reader);
        _impactDamage.ReadString(reader);
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses.Add(new ProjectileMaterialResponseBlock());
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
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _superDetonation.Write(bw);
        _aIPerceptionRadius.Write(bw);
        _collisionRadius.Write(bw);
        _armingTime.Write(bw);
        _dangerRadius.Write(bw);
        _effect.Write(bw);
        _timer.Write(bw);
        _minimumVelocity.Write(bw);
        _maximumRange.Write(bw);
        _airGravityScale.Write(bw);
        _airDamageRange.Write(bw);
        _waterGravityScale.Write(bw);
        _waterDamageRange.Write(bw);
        _initialVelocity.Write(bw);
        _finalVelocity.Write(bw);
        _guidedAngularVelocity.Write(bw);
        _detonationNoise.Write(bw);
        _unnamed.Write(bw);
        _detonationStarted.Write(bw);
        _flybySound.Write(bw);
        _attachedDetonationDamage.Write(bw);
        _impactDamage.Write(bw);
        _unnamed2.Write(bw);
_materialResponses.Count = MaterialResponses.Count;
        _materialResponses.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _superDetonation.WriteString(writer);
        _effect.WriteString(writer);
        _detonationStarted.WriteString(writer);
        _flybySound.WriteString(writer);
        _attachedDetonationDamage.WriteString(writer);
        _impactDamage.WriteString(writer);
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses[x].Write(writer);
        }
        for (x = 0; (x < _materialResponses.Count); x = (x + 1)) {
          MaterialResponses[x].WriteChildData(writer);
        }
      }
    }
    public class ProjectileMaterialResponseBlock : IBlock {
      private Flags _flags;
      private Enum _response = new Enum();
      private TagReference _effect = new TagReference();
      private Pad _unnamed;
      private Enum _response2 = new Enum();
      private Flags _flags2;
      private RealFraction _skipFraction = new RealFraction();
      private AngleBounds _between = new AngleBounds();
      private RealBounds _and = new RealBounds();
      private TagReference _effect2 = new TagReference();
      private Pad _unnamed2;
      private Enum _scaleEffectsBy = new Enum();
      private Pad _unnamed3;
      private Angle _angularNoise = new Angle();
      private Real _velocityNoise = new Real();
      private TagReference _detonationEffect = new TagReference();
      private Pad _unnamed4;
      private Real _initialFriction = new Real();
      private Real _maximumDistance = new Real();
      private Real _parallelFriction = new Real();
      private Real _perpendicularFriction = new Real();
public event System.EventHandler BlockNameChanged;
      public ProjectileMaterialResponseBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(16);
        this._flags2 = new Flags(2);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_effect.Value);
references.Add(_effect2.Value);
references.Add(_detonationEffect.Value);
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
      public TagReference Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
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
      public RealFraction SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
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
      public TagReference Effect2 {
        get {
          return this._effect2;
        }
        set {
          this._effect2 = value;
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
      public TagReference DetonationEffect {
        get {
          return this._detonationEffect;
        }
        set {
          this._detonationEffect = value;
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
        _effect.Read(reader);
        _unnamed.Read(reader);
        _response2.Read(reader);
        _flags2.Read(reader);
        _skipFraction.Read(reader);
        _between.Read(reader);
        _and.Read(reader);
        _effect2.Read(reader);
        _unnamed2.Read(reader);
        _scaleEffectsBy.Read(reader);
        _unnamed3.Read(reader);
        _angularNoise.Read(reader);
        _velocityNoise.Read(reader);
        _detonationEffect.Read(reader);
        _unnamed4.Read(reader);
        _initialFriction.Read(reader);
        _maximumDistance.Read(reader);
        _parallelFriction.Read(reader);
        _perpendicularFriction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _effect.ReadString(reader);
        _effect2.ReadString(reader);
        _detonationEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _response.Write(bw);
        _effect.Write(bw);
        _unnamed.Write(bw);
        _response2.Write(bw);
        _flags2.Write(bw);
        _skipFraction.Write(bw);
        _between.Write(bw);
        _and.Write(bw);
        _effect2.Write(bw);
        _unnamed2.Write(bw);
        _scaleEffectsBy.Write(bw);
        _unnamed3.Write(bw);
        _angularNoise.Write(bw);
        _velocityNoise.Write(bw);
        _detonationEffect.Write(bw);
        _unnamed4.Write(bw);
        _initialFriction.Write(bw);
        _maximumDistance.Write(bw);
        _parallelFriction.Write(bw);
        _perpendicularFriction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _effect.WriteString(writer);
        _effect2.WriteString(writer);
        _detonationEffect.WriteString(writer);
      }
    }
  }
}
