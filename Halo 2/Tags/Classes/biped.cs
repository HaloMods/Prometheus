// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'biped' (derived from 'unit')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class biped : unit {
    private CharacterPhysicsSentinelStructBlockBlock bipedValues = new CharacterPhysicsSentinelStructBlockBlock();
    public virtual CharacterPhysicsSentinelStructBlockBlock BipedValues {
      get {
        return bipedValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(BipedValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "biped";
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
bipedValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
bipedValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
bipedValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
bipedValues.WriteChildData(writer);
    }
    #endregion
    public class CharacterPhysicsSentinelStructBlockBlock : IBlock {
      private Angle _movingTurningSpeed = new Angle();
      private Flags _flags;
      private Angle _stationaryTurningThreshold = new Angle();
      private Real _jumpVelocity = new Real();
      private Real _maximumSoftLandingTime = new Real();
      private Real _maximumHardLandingTime = new Real();
      private Real _minimumSoftLandingVelocity = new Real();
      private Real _minimumHardLandingVelocity = new Real();
      private Real _maximumHardLandingVelocity = new Real();
      private Real _deathHardLandingVelocity = new Real();
      private Real _stunDuration = new Real();
      private Real _standingCameraHeight = new Real();
      private Real _crouchingCameraHeight = new Real();
      private Real _crouchTransitionTime = new Real();
      private Angle _cameraInterpolationStart = new Angle();
      private Angle _cameraInterpolationEnd = new Angle();
      private Real _cameraForwardMovementScale = new Real();
      private Real _cameraSideMovementScale = new Real();
      private Real _cameraVerticalMovementScale = new Real();
      private Real _cameraExclusionDistance = new Real();
      private Real _autoaimWidth = new Real();
      private Flags _flags2;
      private Real _lockOnDistance = new Real();
      private Pad _unnamed0;
      private Real _headShotAccScale = new Real();
      private TagReference _areaDamageEffect = new TagReference();
      private Flags _flags3;
      private Real _heightStanding = new Real();
      private Real _heightCrouching = new Real();
      private Real _radius = new Real();
      private Real _mass = new Real();
      private StringId _livingMaterialName = new StringId();
      private StringId _deadMaterialName = new StringId();
      private Pad _unnamed1;
      private Block _deadSphereShapes = new Block();
      private Block _pillShapes = new Block();
      private Block _sphereShapes = new Block();
      private Angle _maximumSlopeAngle = new Angle();
      private Angle _downhillFalloffAngle = new Angle();
      private Angle _downhillCutoffAngle = new Angle();
      private Angle _uphillFalloffAngle = new Angle();
      private Angle _uphillCutoffAngle = new Angle();
      private Real _downhillVelocityScale = new Real();
      private Real _uphillVelocityScale = new Real();
      private Pad _unnamed2;
      private Angle _bankAngle = new Angle();
      private Real _bankApplyTime = new Real();
      private Real _bankDecayTime = new Real();
      private Real _pitchRatio = new Real();
      private Real _maxVelocity = new Real();
      private Real _maxSidestepVelocity = new Real();
      private Real _acceleration = new Real();
      private Real _deceleration = new Real();
      private Angle _angularVelocityMaximum = new Angle();
      private Angle _angularAccelerationMaximum = new Angle();
      private Real _crouchVelocityModifier = new Real();
      private Block _contactPoints = new Block();
      private TagReference _reanimationCharacter = new TagReference();
      private TagReference _deathSpawnCharacter = new TagReference();
      private ShortInteger _deathSpawnCount = new ShortInteger();
      private Pad _unnamed3;
      public BlockCollection<SpheresBlockBlock> _deadSphereShapesList = new BlockCollection<SpheresBlockBlock>();
      public BlockCollection<PillsBlockBlock> _pillShapesList = new BlockCollection<PillsBlockBlock>();
      public BlockCollection<SpheresBlockBlock> _sphereShapesList = new BlockCollection<SpheresBlockBlock>();
      public BlockCollection<ContactPointBlockBlock> _contactPointsList = new BlockCollection<ContactPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CharacterPhysicsSentinelStructBlockBlock() {
        this._flags = new Flags(4);
        this._flags2 = new Flags(4);
        this._unnamed0 = new Pad(16);
        this._flags3 = new Flags(4);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(20);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<SpheresBlockBlock> DeadSphereShapes {
        get {
          return this._deadSphereShapesList;
        }
      }
      public BlockCollection<PillsBlockBlock> PillShapes {
        get {
          return this._pillShapesList;
        }
      }
      public BlockCollection<SpheresBlockBlock> SphereShapes {
        get {
          return this._sphereShapesList;
        }
      }
      public BlockCollection<ContactPointBlockBlock> ContactPoints {
        get {
          return this._contactPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_areaDamageEffect.Value);
references.Add(_reanimationCharacter.Value);
references.Add(_deathSpawnCharacter.Value);
for (int x=0; x<DeadSphereShapes.BlockCount; x++)
{
  IBlock block = DeadSphereShapes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PillShapes.BlockCount; x++)
{
  IBlock block = PillShapes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SphereShapes.BlockCount; x++)
{
  IBlock block = SphereShapes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ContactPoints.BlockCount; x++)
{
  IBlock block = ContactPoints.GetBlock(x);
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
      public Angle MovingTurningSpeed {
        get {
          return this._movingTurningSpeed;
        }
        set {
          this._movingTurningSpeed = value;
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
      public Angle StationaryTurningThreshold {
        get {
          return this._stationaryTurningThreshold;
        }
        set {
          this._stationaryTurningThreshold = value;
        }
      }
      public Real JumpVelocity {
        get {
          return this._jumpVelocity;
        }
        set {
          this._jumpVelocity = value;
        }
      }
      public Real MaximumSoftLandingTime {
        get {
          return this._maximumSoftLandingTime;
        }
        set {
          this._maximumSoftLandingTime = value;
        }
      }
      public Real MaximumHardLandingTime {
        get {
          return this._maximumHardLandingTime;
        }
        set {
          this._maximumHardLandingTime = value;
        }
      }
      public Real MinimumSoftLandingVelocity {
        get {
          return this._minimumSoftLandingVelocity;
        }
        set {
          this._minimumSoftLandingVelocity = value;
        }
      }
      public Real MinimumHardLandingVelocity {
        get {
          return this._minimumHardLandingVelocity;
        }
        set {
          this._minimumHardLandingVelocity = value;
        }
      }
      public Real MaximumHardLandingVelocity {
        get {
          return this._maximumHardLandingVelocity;
        }
        set {
          this._maximumHardLandingVelocity = value;
        }
      }
      public Real DeathHardLandingVelocity {
        get {
          return this._deathHardLandingVelocity;
        }
        set {
          this._deathHardLandingVelocity = value;
        }
      }
      public Real StunDuration {
        get {
          return this._stunDuration;
        }
        set {
          this._stunDuration = value;
        }
      }
      public Real StandingCameraHeight {
        get {
          return this._standingCameraHeight;
        }
        set {
          this._standingCameraHeight = value;
        }
      }
      public Real CrouchingCameraHeight {
        get {
          return this._crouchingCameraHeight;
        }
        set {
          this._crouchingCameraHeight = value;
        }
      }
      public Real CrouchTransitionTime {
        get {
          return this._crouchTransitionTime;
        }
        set {
          this._crouchTransitionTime = value;
        }
      }
      public Angle CameraInterpolationStart {
        get {
          return this._cameraInterpolationStart;
        }
        set {
          this._cameraInterpolationStart = value;
        }
      }
      public Angle CameraInterpolationEnd {
        get {
          return this._cameraInterpolationEnd;
        }
        set {
          this._cameraInterpolationEnd = value;
        }
      }
      public Real CameraForwardMovementScale {
        get {
          return this._cameraForwardMovementScale;
        }
        set {
          this._cameraForwardMovementScale = value;
        }
      }
      public Real CameraSideMovementScale {
        get {
          return this._cameraSideMovementScale;
        }
        set {
          this._cameraSideMovementScale = value;
        }
      }
      public Real CameraVerticalMovementScale {
        get {
          return this._cameraVerticalMovementScale;
        }
        set {
          this._cameraVerticalMovementScale = value;
        }
      }
      public Real CameraExclusionDistance {
        get {
          return this._cameraExclusionDistance;
        }
        set {
          this._cameraExclusionDistance = value;
        }
      }
      public Real AutoaimWidth {
        get {
          return this._autoaimWidth;
        }
        set {
          this._autoaimWidth = value;
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
      public Real LockOnDistance {
        get {
          return this._lockOnDistance;
        }
        set {
          this._lockOnDistance = value;
        }
      }
      public Real HeadShotAccScale {
        get {
          return this._headShotAccScale;
        }
        set {
          this._headShotAccScale = value;
        }
      }
      public TagReference AreaDamageEffect {
        get {
          return this._areaDamageEffect;
        }
        set {
          this._areaDamageEffect = value;
        }
      }
      public Flags Flags3 {
        get {
          return this._flags3;
        }
        set {
          this._flags3 = value;
        }
      }
      public Real HeightStanding {
        get {
          return this._heightStanding;
        }
        set {
          this._heightStanding = value;
        }
      }
      public Real HeightCrouching {
        get {
          return this._heightCrouching;
        }
        set {
          this._heightCrouching = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public StringId LivingMaterialName {
        get {
          return this._livingMaterialName;
        }
        set {
          this._livingMaterialName = value;
        }
      }
      public StringId DeadMaterialName {
        get {
          return this._deadMaterialName;
        }
        set {
          this._deadMaterialName = value;
        }
      }
      public Angle MaximumSlopeAngle {
        get {
          return this._maximumSlopeAngle;
        }
        set {
          this._maximumSlopeAngle = value;
        }
      }
      public Angle DownhillFalloffAngle {
        get {
          return this._downhillFalloffAngle;
        }
        set {
          this._downhillFalloffAngle = value;
        }
      }
      public Angle DownhillCutoffAngle {
        get {
          return this._downhillCutoffAngle;
        }
        set {
          this._downhillCutoffAngle = value;
        }
      }
      public Angle UphillFalloffAngle {
        get {
          return this._uphillFalloffAngle;
        }
        set {
          this._uphillFalloffAngle = value;
        }
      }
      public Angle UphillCutoffAngle {
        get {
          return this._uphillCutoffAngle;
        }
        set {
          this._uphillCutoffAngle = value;
        }
      }
      public Real DownhillVelocityScale {
        get {
          return this._downhillVelocityScale;
        }
        set {
          this._downhillVelocityScale = value;
        }
      }
      public Real UphillVelocityScale {
        get {
          return this._uphillVelocityScale;
        }
        set {
          this._uphillVelocityScale = value;
        }
      }
      public Angle BankAngle {
        get {
          return this._bankAngle;
        }
        set {
          this._bankAngle = value;
        }
      }
      public Real BankApplyTime {
        get {
          return this._bankApplyTime;
        }
        set {
          this._bankApplyTime = value;
        }
      }
      public Real BankDecayTime {
        get {
          return this._bankDecayTime;
        }
        set {
          this._bankDecayTime = value;
        }
      }
      public Real PitchRatio {
        get {
          return this._pitchRatio;
        }
        set {
          this._pitchRatio = value;
        }
      }
      public Real MaxVelocity {
        get {
          return this._maxVelocity;
        }
        set {
          this._maxVelocity = value;
        }
      }
      public Real MaxSidestepVelocity {
        get {
          return this._maxSidestepVelocity;
        }
        set {
          this._maxSidestepVelocity = value;
        }
      }
      public Real Acceleration {
        get {
          return this._acceleration;
        }
        set {
          this._acceleration = value;
        }
      }
      public Real Deceleration {
        get {
          return this._deceleration;
        }
        set {
          this._deceleration = value;
        }
      }
      public Angle AngularVelocityMaximum {
        get {
          return this._angularVelocityMaximum;
        }
        set {
          this._angularVelocityMaximum = value;
        }
      }
      public Angle AngularAccelerationMaximum {
        get {
          return this._angularAccelerationMaximum;
        }
        set {
          this._angularAccelerationMaximum = value;
        }
      }
      public Real CrouchVelocityModifier {
        get {
          return this._crouchVelocityModifier;
        }
        set {
          this._crouchVelocityModifier = value;
        }
      }
      public TagReference ReanimationCharacter {
        get {
          return this._reanimationCharacter;
        }
        set {
          this._reanimationCharacter = value;
        }
      }
      public TagReference DeathSpawnCharacter {
        get {
          return this._deathSpawnCharacter;
        }
        set {
          this._deathSpawnCharacter = value;
        }
      }
      public ShortInteger DeathSpawnCount {
        get {
          return this._deathSpawnCount;
        }
        set {
          this._deathSpawnCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _movingTurningSpeed.Read(reader);
        _flags.Read(reader);
        _stationaryTurningThreshold.Read(reader);
        _jumpVelocity.Read(reader);
        _maximumSoftLandingTime.Read(reader);
        _maximumHardLandingTime.Read(reader);
        _minimumSoftLandingVelocity.Read(reader);
        _minimumHardLandingVelocity.Read(reader);
        _maximumHardLandingVelocity.Read(reader);
        _deathHardLandingVelocity.Read(reader);
        _stunDuration.Read(reader);
        _standingCameraHeight.Read(reader);
        _crouchingCameraHeight.Read(reader);
        _crouchTransitionTime.Read(reader);
        _cameraInterpolationStart.Read(reader);
        _cameraInterpolationEnd.Read(reader);
        _cameraForwardMovementScale.Read(reader);
        _cameraSideMovementScale.Read(reader);
        _cameraVerticalMovementScale.Read(reader);
        _cameraExclusionDistance.Read(reader);
        _autoaimWidth.Read(reader);
        _flags2.Read(reader);
        _lockOnDistance.Read(reader);
        _unnamed0.Read(reader);
        _headShotAccScale.Read(reader);
        _areaDamageEffect.Read(reader);
        _flags3.Read(reader);
        _heightStanding.Read(reader);
        _heightCrouching.Read(reader);
        _radius.Read(reader);
        _mass.Read(reader);
        _livingMaterialName.Read(reader);
        _deadMaterialName.Read(reader);
        _unnamed1.Read(reader);
        _deadSphereShapes.Read(reader);
        _pillShapes.Read(reader);
        _sphereShapes.Read(reader);
        _maximumSlopeAngle.Read(reader);
        _downhillFalloffAngle.Read(reader);
        _downhillCutoffAngle.Read(reader);
        _uphillFalloffAngle.Read(reader);
        _uphillCutoffAngle.Read(reader);
        _downhillVelocityScale.Read(reader);
        _uphillVelocityScale.Read(reader);
        _unnamed2.Read(reader);
        _bankAngle.Read(reader);
        _bankApplyTime.Read(reader);
        _bankDecayTime.Read(reader);
        _pitchRatio.Read(reader);
        _maxVelocity.Read(reader);
        _maxSidestepVelocity.Read(reader);
        _acceleration.Read(reader);
        _deceleration.Read(reader);
        _angularVelocityMaximum.Read(reader);
        _angularAccelerationMaximum.Read(reader);
        _crouchVelocityModifier.Read(reader);
        _contactPoints.Read(reader);
        _reanimationCharacter.Read(reader);
        _deathSpawnCharacter.Read(reader);
        _deathSpawnCount.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _areaDamageEffect.ReadString(reader);
        _livingMaterialName.ReadString(reader);
        _deadMaterialName.ReadString(reader);
        for (x = 0; (x < _deadSphereShapes.Count); x = (x + 1)) {
          DeadSphereShapes.Add(new SpheresBlockBlock());
          DeadSphereShapes[x].Read(reader);
        }
        for (x = 0; (x < _deadSphereShapes.Count); x = (x + 1)) {
          DeadSphereShapes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pillShapes.Count); x = (x + 1)) {
          PillShapes.Add(new PillsBlockBlock());
          PillShapes[x].Read(reader);
        }
        for (x = 0; (x < _pillShapes.Count); x = (x + 1)) {
          PillShapes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sphereShapes.Count); x = (x + 1)) {
          SphereShapes.Add(new SpheresBlockBlock());
          SphereShapes[x].Read(reader);
        }
        for (x = 0; (x < _sphereShapes.Count); x = (x + 1)) {
          SphereShapes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints.Add(new ContactPointBlockBlock());
          ContactPoints[x].Read(reader);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].ReadChildData(reader);
        }
        _reanimationCharacter.ReadString(reader);
        _deathSpawnCharacter.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _movingTurningSpeed.Write(bw);
        _flags.Write(bw);
        _stationaryTurningThreshold.Write(bw);
        _jumpVelocity.Write(bw);
        _maximumSoftLandingTime.Write(bw);
        _maximumHardLandingTime.Write(bw);
        _minimumSoftLandingVelocity.Write(bw);
        _minimumHardLandingVelocity.Write(bw);
        _maximumHardLandingVelocity.Write(bw);
        _deathHardLandingVelocity.Write(bw);
        _stunDuration.Write(bw);
        _standingCameraHeight.Write(bw);
        _crouchingCameraHeight.Write(bw);
        _crouchTransitionTime.Write(bw);
        _cameraInterpolationStart.Write(bw);
        _cameraInterpolationEnd.Write(bw);
        _cameraForwardMovementScale.Write(bw);
        _cameraSideMovementScale.Write(bw);
        _cameraVerticalMovementScale.Write(bw);
        _cameraExclusionDistance.Write(bw);
        _autoaimWidth.Write(bw);
        _flags2.Write(bw);
        _lockOnDistance.Write(bw);
        _unnamed0.Write(bw);
        _headShotAccScale.Write(bw);
        _areaDamageEffect.Write(bw);
        _flags3.Write(bw);
        _heightStanding.Write(bw);
        _heightCrouching.Write(bw);
        _radius.Write(bw);
        _mass.Write(bw);
        _livingMaterialName.Write(bw);
        _deadMaterialName.Write(bw);
        _unnamed1.Write(bw);
_deadSphereShapes.Count = DeadSphereShapes.Count;
        _deadSphereShapes.Write(bw);
_pillShapes.Count = PillShapes.Count;
        _pillShapes.Write(bw);
_sphereShapes.Count = SphereShapes.Count;
        _sphereShapes.Write(bw);
        _maximumSlopeAngle.Write(bw);
        _downhillFalloffAngle.Write(bw);
        _downhillCutoffAngle.Write(bw);
        _uphillFalloffAngle.Write(bw);
        _uphillCutoffAngle.Write(bw);
        _downhillVelocityScale.Write(bw);
        _uphillVelocityScale.Write(bw);
        _unnamed2.Write(bw);
        _bankAngle.Write(bw);
        _bankApplyTime.Write(bw);
        _bankDecayTime.Write(bw);
        _pitchRatio.Write(bw);
        _maxVelocity.Write(bw);
        _maxSidestepVelocity.Write(bw);
        _acceleration.Write(bw);
        _deceleration.Write(bw);
        _angularVelocityMaximum.Write(bw);
        _angularAccelerationMaximum.Write(bw);
        _crouchVelocityModifier.Write(bw);
_contactPoints.Count = ContactPoints.Count;
        _contactPoints.Write(bw);
        _reanimationCharacter.Write(bw);
        _deathSpawnCharacter.Write(bw);
        _deathSpawnCount.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _areaDamageEffect.WriteString(writer);
        _livingMaterialName.WriteString(writer);
        _deadMaterialName.WriteString(writer);
        for (x = 0; (x < _deadSphereShapes.Count); x = (x + 1)) {
          DeadSphereShapes[x].Write(writer);
        }
        for (x = 0; (x < _deadSphereShapes.Count); x = (x + 1)) {
          DeadSphereShapes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pillShapes.Count); x = (x + 1)) {
          PillShapes[x].Write(writer);
        }
        for (x = 0; (x < _pillShapes.Count); x = (x + 1)) {
          PillShapes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sphereShapes.Count); x = (x + 1)) {
          SphereShapes[x].Write(writer);
        }
        for (x = 0; (x < _sphereShapes.Count); x = (x + 1)) {
          SphereShapes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].Write(writer);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].WriteChildData(writer);
        }
        _reanimationCharacter.WriteString(writer);
        _deathSpawnCharacter.WriteString(writer);
      }
    }
    public class SpheresBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private Skip _unnamed3;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed4;
      private Skip _unnamed5;
      private RealVector3D _rotationI = new RealVector3D();
      private Skip _unnamed6;
      private RealVector3D _rotationJ = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _rotationK = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _translation = new RealVector3D();
      private Skip _unnamed9;
public event System.EventHandler BlockNameChanged;
      public SpheresBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
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
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
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
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public ShortInteger Size2 {
        get {
          return this._size2;
        }
        set {
          this._size2 = value;
        }
      }
      public ShortInteger Count2 {
        get {
          return this._count2;
        }
        set {
          this._count2 = value;
        }
      }
      public RealVector3D RotationI {
        get {
          return this._rotationI;
        }
        set {
          this._rotationI = value;
        }
      }
      public RealVector3D RotationJ {
        get {
          return this._rotationJ;
        }
        set {
          this._rotationJ = value;
        }
      }
      public RealVector3D RotationK {
        get {
          return this._rotationK;
        }
        set {
          this._rotationK = value;
        }
      }
      public RealVector3D Translation {
        get {
          return this._translation;
        }
        set {
          this._translation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _unnamed3.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _rotationI.Read(reader);
        _unnamed6.Read(reader);
        _rotationJ.Read(reader);
        _unnamed7.Read(reader);
        _rotationK.Read(reader);
        _unnamed8.Read(reader);
        _translation.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _unnamed3.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _rotationI.Write(bw);
        _unnamed6.Write(bw);
        _rotationJ.Write(bw);
        _unnamed7.Write(bw);
        _rotationK.Write(bw);
        _unnamed8.Write(bw);
        _translation.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PillsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private RealVector3D _bottom = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _top = new RealVector3D();
      private Skip _unnamed4;
public event System.EventHandler BlockNameChanged;
      public PillsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
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
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
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
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealVector3D Bottom {
        get {
          return this._bottom;
        }
        set {
          this._bottom = value;
        }
      }
      public RealVector3D Top {
        get {
          return this._top;
        }
        set {
          this._top = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _bottom.Read(reader);
        _unnamed3.Read(reader);
        _top.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _bottom.Write(bw);
        _unnamed3.Write(bw);
        _top.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ContactPointBlockBlock : IBlock {
      private StringId _markerName = new StringId();
public event System.EventHandler BlockNameChanged;
      public ContactPointBlockBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _markerName.ToString();
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
      public virtual void Read(BinaryReader reader) {
        _markerName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
      }
    }
  }
}
