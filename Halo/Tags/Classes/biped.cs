// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'biped' (derived from 'unit')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class biped : unit {
    private BipedBlock bipedValues = new BipedBlock();
    public virtual BipedBlock BipedValues {
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
    public class BipedBlock : IBlock {
      private Angle _movingTurningSpeed = new Angle();
      private Flags _flags;
      private Angle _stationaryTurningThreshold = new Angle();
      private Pad _unnamed;
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private TagReference _dONTUSE = new TagReference();
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
      private Pad _unnamed2;
      private Angle _maximumSlopeAngle = new Angle();
      private Angle _downhillFalloffAngle = new Angle();
      private Angle _downhillCutoffAngle = new Angle();
      private Real _downhillVelocityScale = new Real();
      private Angle _uphillFalloffAngle = new Angle();
      private Angle _uphillCutoffAngle = new Angle();
      private Real _uphillVelocityScale = new Real();
      private Pad _unnamed3;
      private TagReference _footsteps = new TagReference();
      private Pad _unnamed4;
      private Real _jumpVelocity = new Real();
      private Pad _unnamed5;
      private Real _maximumSoftLandingTime = new Real();
      private Real _maximumHardLandingTime = new Real();
      private Real _minimumSoftLandingVelocity = new Real();
      private Real _minimumHardLandingVelocity = new Real();
      private Real _maximumHardLandingVelocity = new Real();
      private Real _deathHardLandingVelocity = new Real();
      private Pad _unnamed6;
      private Real _standingCameraHeight = new Real();
      private Real _crouchingCameraHeight = new Real();
      private Real _crouchTransitionTime = new Real();
      private Pad _unnamed7;
      private Real _standingCollisionHeight = new Real();
      private Real _crouchingCollisionHeight = new Real();
      private Real _collisionRadius = new Real();
      private Pad _unnamed8;
      private Real _autoaimWidth = new Real();
      private Pad _unnamed9;
      private Block _contactPoints = new Block();
      public BlockCollection<ContactPointBlock> _contactPointsList = new BlockCollection<ContactPointBlock>();
public event System.EventHandler BlockNameChanged;
      public BipedBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(24);
        this._unnamed4 = new Pad(24);
        this._unnamed5 = new Pad(28);
        this._unnamed6 = new Pad(20);
        this._unnamed7 = new Pad(24);
        this._unnamed8 = new Pad(40);
        this._unnamed9 = new Pad(140);
      }
      public BlockCollection<ContactPointBlock> ContactPoints {
        get {
          return this._contactPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dONTUSE.Value);
references.Add(_footsteps.Value);
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
      public TagReference DONTUSE {
        get {
          return this._dONTUSE;
        }
        set {
          this._dONTUSE = value;
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
      public Real DownhillVelocityScale {
        get {
          return this._downhillVelocityScale;
        }
        set {
          this._downhillVelocityScale = value;
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
      public Real UphillVelocityScale {
        get {
          return this._uphillVelocityScale;
        }
        set {
          this._uphillVelocityScale = value;
        }
      }
      public TagReference Footsteps {
        get {
          return this._footsteps;
        }
        set {
          this._footsteps = value;
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
      public Real StandingCollisionHeight {
        get {
          return this._standingCollisionHeight;
        }
        set {
          this._standingCollisionHeight = value;
        }
      }
      public Real CrouchingCollisionHeight {
        get {
          return this._crouchingCollisionHeight;
        }
        set {
          this._crouchingCollisionHeight = value;
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
      public Real AutoaimWidth {
        get {
          return this._autoaimWidth;
        }
        set {
          this._autoaimWidth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _movingTurningSpeed.Read(reader);
        _flags.Read(reader);
        _stationaryTurningThreshold.Read(reader);
        _unnamed.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _dONTUSE.Read(reader);
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
        _unnamed2.Read(reader);
        _maximumSlopeAngle.Read(reader);
        _downhillFalloffAngle.Read(reader);
        _downhillCutoffAngle.Read(reader);
        _downhillVelocityScale.Read(reader);
        _uphillFalloffAngle.Read(reader);
        _uphillCutoffAngle.Read(reader);
        _uphillVelocityScale.Read(reader);
        _unnamed3.Read(reader);
        _footsteps.Read(reader);
        _unnamed4.Read(reader);
        _jumpVelocity.Read(reader);
        _unnamed5.Read(reader);
        _maximumSoftLandingTime.Read(reader);
        _maximumHardLandingTime.Read(reader);
        _minimumSoftLandingVelocity.Read(reader);
        _minimumHardLandingVelocity.Read(reader);
        _maximumHardLandingVelocity.Read(reader);
        _deathHardLandingVelocity.Read(reader);
        _unnamed6.Read(reader);
        _standingCameraHeight.Read(reader);
        _crouchingCameraHeight.Read(reader);
        _crouchTransitionTime.Read(reader);
        _unnamed7.Read(reader);
        _standingCollisionHeight.Read(reader);
        _crouchingCollisionHeight.Read(reader);
        _collisionRadius.Read(reader);
        _unnamed8.Read(reader);
        _autoaimWidth.Read(reader);
        _unnamed9.Read(reader);
        _contactPoints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _dONTUSE.ReadString(reader);
        _footsteps.ReadString(reader);
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints.Add(new ContactPointBlock());
          ContactPoints[x].Read(reader);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _movingTurningSpeed.Write(bw);
        _flags.Write(bw);
        _stationaryTurningThreshold.Write(bw);
        _unnamed.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _dONTUSE.Write(bw);
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
        _unnamed2.Write(bw);
        _maximumSlopeAngle.Write(bw);
        _downhillFalloffAngle.Write(bw);
        _downhillCutoffAngle.Write(bw);
        _downhillVelocityScale.Write(bw);
        _uphillFalloffAngle.Write(bw);
        _uphillCutoffAngle.Write(bw);
        _uphillVelocityScale.Write(bw);
        _unnamed3.Write(bw);
        _footsteps.Write(bw);
        _unnamed4.Write(bw);
        _jumpVelocity.Write(bw);
        _unnamed5.Write(bw);
        _maximumSoftLandingTime.Write(bw);
        _maximumHardLandingTime.Write(bw);
        _minimumSoftLandingVelocity.Write(bw);
        _minimumHardLandingVelocity.Write(bw);
        _maximumHardLandingVelocity.Write(bw);
        _deathHardLandingVelocity.Write(bw);
        _unnamed6.Write(bw);
        _standingCameraHeight.Write(bw);
        _crouchingCameraHeight.Write(bw);
        _crouchTransitionTime.Write(bw);
        _unnamed7.Write(bw);
        _standingCollisionHeight.Write(bw);
        _crouchingCollisionHeight.Write(bw);
        _collisionRadius.Write(bw);
        _unnamed8.Write(bw);
        _autoaimWidth.Write(bw);
        _unnamed9.Write(bw);
_contactPoints.Count = ContactPoints.Count;
        _contactPoints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _dONTUSE.WriteString(writer);
        _footsteps.WriteString(writer);
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].Write(writer);
        }
        for (x = 0; (x < _contactPoints.Count); x = (x + 1)) {
          ContactPoints[x].WriteChildData(writer);
        }
      }
    }
    public class ContactPointBlock : IBlock {
      private Pad _unnamed;
      private FixedLengthString _markerName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public ContactPointBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
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
      public FixedLengthString MarkerName {
        get {
          return this._markerName;
        }
        set {
          this._markerName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _markerName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
