// --------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'vehicle' (derived from 'unit')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// --------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class vehicle : unit {
    private HavokVehiclePhysicsStructBlockBlock vehicleValues = new HavokVehiclePhysicsStructBlockBlock();
    public virtual HavokVehiclePhysicsStructBlockBlock VehicleValues {
      get {
        return vehicleValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(VehicleValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "vehicle";
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
vehicleValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
vehicleValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
vehicleValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
vehicleValues.WriteChildData(writer);
    }
    #endregion
    public class HavokVehiclePhysicsStructBlockBlock : IBlock {
      private Flags _flags;
      private Enum _type;
      private Enum _control;
      private Real _maximumForwardSpeed = new Real();
      private Real _maximumReverseSpeed = new Real();
      private Real _speedAcceleration = new Real();
      private Real _speedDeceleration = new Real();
      private Real _maximumLeftTurn = new Real();
      private Real _maximumRightTurnNegative = new Real();
      private Real _wheelCircumference = new Real();
      private Real _turnRate = new Real();
      private Real _blurSpeed = new Real();
      private Enum _specificType;
      private Enum _playerTrainingVehicleType;
      private StringId _flipMessage = new StringId();
      private Real _turnScale = new Real();
      private Real _speedTurnPenaltyPower052 = new Real();
      private Real _speedTurnPenalty0None1CantTurnAtTopSpeed = new Real();
      private Real _maximumLeftSlide = new Real();
      private Real _maximumRightSlide = new Real();
      private Real _slideAcceleration = new Real();
      private Real _slideDeceleration = new Real();
      private Real _minimumFlippingAngularVelocity = new Real();
      private Real _maximumFlippingAngularVelocity = new Real();
      private Enum _vehicleSize;
      private Pad _unnamed0;
      private Real _fixedGunYaw = new Real();
      private Real _fixedGunPitch = new Real();
      private Real _overdampenCuspAngle = new Real();
      private Real _overdampenExponent = new Real();
      private Real _crouchTransitionTime = new Real();
      private Pad _unnamed1;
      private Real _engineMoment = new Real();
      private Real _engineMaxAngularVelocity = new Real();
      private Block _gears = new Block();
      private Real _flyingTorqueScale = new Real();
      private Real _seatEnteranceAccelerationScale = new Real();
      private Real _seatExitAccelersationScale = new Real();
      private Real _airFrictionDeceleration = new Real();
      private Real _thrustScale = new Real();
      private TagReference _suspensionSound = new TagReference();
      private TagReference _crashSound = new TagReference();
      private TagReference _uNUSED = new TagReference();
      private TagReference _specialEffect = new TagReference();
      private TagReference _unusedEffect = new TagReference();
      private Flags _flags2;
      private Real _groundFriction = new Real();
      private Real _groundDepth = new Real();
      private Real _groundDampFactor = new Real();
      private Real _groundMovingFriction = new Real();
      private Real _groundMaximumSlope0 = new Real();
      private Real _groundMaximumSlope1 = new Real();
      private Pad _unnamed2;
      private Real _antigravitybanklift = new Real();
      private Real _steeringbankreactionscale = new Real();
      private Real _gravityScale = new Real();
      private Real _radius = new Real();
      private Block _antiGravityPoints = new Block();
      private Block _frictionPoints = new Block();
      private Block _shapePhantomShape = new Block();
      public BlockCollection<GearBlockBlock> _gearsList = new BlockCollection<GearBlockBlock>();
      public BlockCollection<AntiGravityPointDefinitionBlockBlock> _antiGravityPointsList = new BlockCollection<AntiGravityPointDefinitionBlockBlock>();
      public BlockCollection<FrictionPointDefinitionBlockBlock> _frictionPointsList = new BlockCollection<FrictionPointDefinitionBlockBlock>();
      public BlockCollection<VehiclePhantomShapeBlockBlock> _shapePhantomShapeList = new BlockCollection<VehiclePhantomShapeBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public HavokVehiclePhysicsStructBlockBlock() {
        this._flags = new Flags(4);
        this._type = new Enum(2);
        this._control = new Enum(2);
        this._specificType = new Enum(2);
        this._playerTrainingVehicleType = new Enum(2);
        this._vehicleSize = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._flags2 = new Flags(4);
        this._unnamed2 = new Pad(16);
      }
      public BlockCollection<GearBlockBlock> Gears {
        get {
          return this._gearsList;
        }
      }
      public BlockCollection<AntiGravityPointDefinitionBlockBlock> AntiGravityPoints {
        get {
          return this._antiGravityPointsList;
        }
      }
      public BlockCollection<FrictionPointDefinitionBlockBlock> FrictionPoints {
        get {
          return this._frictionPointsList;
        }
      }
      public BlockCollection<VehiclePhantomShapeBlockBlock> ShapePhantomShape {
        get {
          return this._shapePhantomShapeList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_suspensionSound.Value);
references.Add(_crashSound.Value);
references.Add(_uNUSED.Value);
references.Add(_specialEffect.Value);
references.Add(_unusedEffect.Value);
for (int x=0; x<Gears.BlockCount; x++)
{
  IBlock block = Gears.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AntiGravityPoints.BlockCount; x++)
{
  IBlock block = AntiGravityPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FrictionPoints.BlockCount; x++)
{
  IBlock block = FrictionPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ShapePhantomShape.BlockCount; x++)
{
  IBlock block = ShapePhantomShape.GetBlock(x);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Enum Control {
        get {
          return this._control;
        }
        set {
          this._control = value;
        }
      }
      public Real MaximumForwardSpeed {
        get {
          return this._maximumForwardSpeed;
        }
        set {
          this._maximumForwardSpeed = value;
        }
      }
      public Real MaximumReverseSpeed {
        get {
          return this._maximumReverseSpeed;
        }
        set {
          this._maximumReverseSpeed = value;
        }
      }
      public Real SpeedAcceleration {
        get {
          return this._speedAcceleration;
        }
        set {
          this._speedAcceleration = value;
        }
      }
      public Real SpeedDeceleration {
        get {
          return this._speedDeceleration;
        }
        set {
          this._speedDeceleration = value;
        }
      }
      public Real MaximumLeftTurn {
        get {
          return this._maximumLeftTurn;
        }
        set {
          this._maximumLeftTurn = value;
        }
      }
      public Real MaximumRightTurnNegative {
        get {
          return this._maximumRightTurnNegative;
        }
        set {
          this._maximumRightTurnNegative = value;
        }
      }
      public Real WheelCircumference {
        get {
          return this._wheelCircumference;
        }
        set {
          this._wheelCircumference = value;
        }
      }
      public Real TurnRate {
        get {
          return this._turnRate;
        }
        set {
          this._turnRate = value;
        }
      }
      public Real BlurSpeed {
        get {
          return this._blurSpeed;
        }
        set {
          this._blurSpeed = value;
        }
      }
      public Enum SpecificType {
        get {
          return this._specificType;
        }
        set {
          this._specificType = value;
        }
      }
      public Enum PlayerTrainingVehicleType {
        get {
          return this._playerTrainingVehicleType;
        }
        set {
          this._playerTrainingVehicleType = value;
        }
      }
      public StringId FlipMessage {
        get {
          return this._flipMessage;
        }
        set {
          this._flipMessage = value;
        }
      }
      public Real TurnScale {
        get {
          return this._turnScale;
        }
        set {
          this._turnScale = value;
        }
      }
      public Real SpeedTurnPenaltyPower052 {
        get {
          return this._speedTurnPenaltyPower052;
        }
        set {
          this._speedTurnPenaltyPower052 = value;
        }
      }
      public Real SpeedTurnPenalty0None1CantTurnAtTopSpeed {
        get {
          return this._speedTurnPenalty0None1CantTurnAtTopSpeed;
        }
        set {
          this._speedTurnPenalty0None1CantTurnAtTopSpeed = value;
        }
      }
      public Real MaximumLeftSlide {
        get {
          return this._maximumLeftSlide;
        }
        set {
          this._maximumLeftSlide = value;
        }
      }
      public Real MaximumRightSlide {
        get {
          return this._maximumRightSlide;
        }
        set {
          this._maximumRightSlide = value;
        }
      }
      public Real SlideAcceleration {
        get {
          return this._slideAcceleration;
        }
        set {
          this._slideAcceleration = value;
        }
      }
      public Real SlideDeceleration {
        get {
          return this._slideDeceleration;
        }
        set {
          this._slideDeceleration = value;
        }
      }
      public Real MinimumFlippingAngularVelocity {
        get {
          return this._minimumFlippingAngularVelocity;
        }
        set {
          this._minimumFlippingAngularVelocity = value;
        }
      }
      public Real MaximumFlippingAngularVelocity {
        get {
          return this._maximumFlippingAngularVelocity;
        }
        set {
          this._maximumFlippingAngularVelocity = value;
        }
      }
      public Enum VehicleSize {
        get {
          return this._vehicleSize;
        }
        set {
          this._vehicleSize = value;
        }
      }
      public Real FixedGunYaw {
        get {
          return this._fixedGunYaw;
        }
        set {
          this._fixedGunYaw = value;
        }
      }
      public Real FixedGunPitch {
        get {
          return this._fixedGunPitch;
        }
        set {
          this._fixedGunPitch = value;
        }
      }
      public Real OverdampenCuspAngle {
        get {
          return this._overdampenCuspAngle;
        }
        set {
          this._overdampenCuspAngle = value;
        }
      }
      public Real OverdampenExponent {
        get {
          return this._overdampenExponent;
        }
        set {
          this._overdampenExponent = value;
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
      public Real EngineMoment {
        get {
          return this._engineMoment;
        }
        set {
          this._engineMoment = value;
        }
      }
      public Real EngineMaxAngularVelocity {
        get {
          return this._engineMaxAngularVelocity;
        }
        set {
          this._engineMaxAngularVelocity = value;
        }
      }
      public Real FlyingTorqueScale {
        get {
          return this._flyingTorqueScale;
        }
        set {
          this._flyingTorqueScale = value;
        }
      }
      public Real SeatEnteranceAccelerationScale {
        get {
          return this._seatEnteranceAccelerationScale;
        }
        set {
          this._seatEnteranceAccelerationScale = value;
        }
      }
      public Real SeatExitAccelersationScale {
        get {
          return this._seatExitAccelersationScale;
        }
        set {
          this._seatExitAccelersationScale = value;
        }
      }
      public Real AirFrictionDeceleration {
        get {
          return this._airFrictionDeceleration;
        }
        set {
          this._airFrictionDeceleration = value;
        }
      }
      public Real ThrustScale {
        get {
          return this._thrustScale;
        }
        set {
          this._thrustScale = value;
        }
      }
      public TagReference SuspensionSound {
        get {
          return this._suspensionSound;
        }
        set {
          this._suspensionSound = value;
        }
      }
      public TagReference CrashSound {
        get {
          return this._crashSound;
        }
        set {
          this._crashSound = value;
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
      public TagReference SpecialEffect {
        get {
          return this._specialEffect;
        }
        set {
          this._specialEffect = value;
        }
      }
      public TagReference UnusedEffect {
        get {
          return this._unusedEffect;
        }
        set {
          this._unusedEffect = value;
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
      public Real GroundFriction {
        get {
          return this._groundFriction;
        }
        set {
          this._groundFriction = value;
        }
      }
      public Real GroundDepth {
        get {
          return this._groundDepth;
        }
        set {
          this._groundDepth = value;
        }
      }
      public Real GroundDampFactor {
        get {
          return this._groundDampFactor;
        }
        set {
          this._groundDampFactor = value;
        }
      }
      public Real GroundMovingFriction {
        get {
          return this._groundMovingFriction;
        }
        set {
          this._groundMovingFriction = value;
        }
      }
      public Real GroundMaximumSlope0 {
        get {
          return this._groundMaximumSlope0;
        }
        set {
          this._groundMaximumSlope0 = value;
        }
      }
      public Real GroundMaximumSlope1 {
        get {
          return this._groundMaximumSlope1;
        }
        set {
          this._groundMaximumSlope1 = value;
        }
      }
      public Real Antigravitybanklift {
        get {
          return this._antigravitybanklift;
        }
        set {
          this._antigravitybanklift = value;
        }
      }
      public Real Steeringbankreactionscale {
        get {
          return this._steeringbankreactionscale;
        }
        set {
          this._steeringbankreactionscale = value;
        }
      }
      public Real GravityScale {
        get {
          return this._gravityScale;
        }
        set {
          this._gravityScale = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type.Read(reader);
        _control.Read(reader);
        _maximumForwardSpeed.Read(reader);
        _maximumReverseSpeed.Read(reader);
        _speedAcceleration.Read(reader);
        _speedDeceleration.Read(reader);
        _maximumLeftTurn.Read(reader);
        _maximumRightTurnNegative.Read(reader);
        _wheelCircumference.Read(reader);
        _turnRate.Read(reader);
        _blurSpeed.Read(reader);
        _specificType.Read(reader);
        _playerTrainingVehicleType.Read(reader);
        _flipMessage.Read(reader);
        _turnScale.Read(reader);
        _speedTurnPenaltyPower052.Read(reader);
        _speedTurnPenalty0None1CantTurnAtTopSpeed.Read(reader);
        _maximumLeftSlide.Read(reader);
        _maximumRightSlide.Read(reader);
        _slideAcceleration.Read(reader);
        _slideDeceleration.Read(reader);
        _minimumFlippingAngularVelocity.Read(reader);
        _maximumFlippingAngularVelocity.Read(reader);
        _vehicleSize.Read(reader);
        _unnamed0.Read(reader);
        _fixedGunYaw.Read(reader);
        _fixedGunPitch.Read(reader);
        _overdampenCuspAngle.Read(reader);
        _overdampenExponent.Read(reader);
        _crouchTransitionTime.Read(reader);
        _unnamed1.Read(reader);
        _engineMoment.Read(reader);
        _engineMaxAngularVelocity.Read(reader);
        _gears.Read(reader);
        _flyingTorqueScale.Read(reader);
        _seatEnteranceAccelerationScale.Read(reader);
        _seatExitAccelersationScale.Read(reader);
        _airFrictionDeceleration.Read(reader);
        _thrustScale.Read(reader);
        _suspensionSound.Read(reader);
        _crashSound.Read(reader);
        _uNUSED.Read(reader);
        _specialEffect.Read(reader);
        _unusedEffect.Read(reader);
        _flags2.Read(reader);
        _groundFriction.Read(reader);
        _groundDepth.Read(reader);
        _groundDampFactor.Read(reader);
        _groundMovingFriction.Read(reader);
        _groundMaximumSlope0.Read(reader);
        _groundMaximumSlope1.Read(reader);
        _unnamed2.Read(reader);
        _antigravitybanklift.Read(reader);
        _steeringbankreactionscale.Read(reader);
        _gravityScale.Read(reader);
        _radius.Read(reader);
        _antiGravityPoints.Read(reader);
        _frictionPoints.Read(reader);
        _shapePhantomShape.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _flipMessage.ReadString(reader);
        for (x = 0; (x < _gears.Count); x = (x + 1)) {
          Gears.Add(new GearBlockBlock());
          Gears[x].Read(reader);
        }
        for (x = 0; (x < _gears.Count); x = (x + 1)) {
          Gears[x].ReadChildData(reader);
        }
        _suspensionSound.ReadString(reader);
        _crashSound.ReadString(reader);
        _uNUSED.ReadString(reader);
        _specialEffect.ReadString(reader);
        _unusedEffect.ReadString(reader);
        for (x = 0; (x < _antiGravityPoints.Count); x = (x + 1)) {
          AntiGravityPoints.Add(new AntiGravityPointDefinitionBlockBlock());
          AntiGravityPoints[x].Read(reader);
        }
        for (x = 0; (x < _antiGravityPoints.Count); x = (x + 1)) {
          AntiGravityPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _frictionPoints.Count); x = (x + 1)) {
          FrictionPoints.Add(new FrictionPointDefinitionBlockBlock());
          FrictionPoints[x].Read(reader);
        }
        for (x = 0; (x < _frictionPoints.Count); x = (x + 1)) {
          FrictionPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shapePhantomShape.Count); x = (x + 1)) {
          ShapePhantomShape.Add(new VehiclePhantomShapeBlockBlock());
          ShapePhantomShape[x].Read(reader);
        }
        for (x = 0; (x < _shapePhantomShape.Count); x = (x + 1)) {
          ShapePhantomShape[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _control.Write(bw);
        _maximumForwardSpeed.Write(bw);
        _maximumReverseSpeed.Write(bw);
        _speedAcceleration.Write(bw);
        _speedDeceleration.Write(bw);
        _maximumLeftTurn.Write(bw);
        _maximumRightTurnNegative.Write(bw);
        _wheelCircumference.Write(bw);
        _turnRate.Write(bw);
        _blurSpeed.Write(bw);
        _specificType.Write(bw);
        _playerTrainingVehicleType.Write(bw);
        _flipMessage.Write(bw);
        _turnScale.Write(bw);
        _speedTurnPenaltyPower052.Write(bw);
        _speedTurnPenalty0None1CantTurnAtTopSpeed.Write(bw);
        _maximumLeftSlide.Write(bw);
        _maximumRightSlide.Write(bw);
        _slideAcceleration.Write(bw);
        _slideDeceleration.Write(bw);
        _minimumFlippingAngularVelocity.Write(bw);
        _maximumFlippingAngularVelocity.Write(bw);
        _vehicleSize.Write(bw);
        _unnamed0.Write(bw);
        _fixedGunYaw.Write(bw);
        _fixedGunPitch.Write(bw);
        _overdampenCuspAngle.Write(bw);
        _overdampenExponent.Write(bw);
        _crouchTransitionTime.Write(bw);
        _unnamed1.Write(bw);
        _engineMoment.Write(bw);
        _engineMaxAngularVelocity.Write(bw);
_gears.Count = Gears.Count;
        _gears.Write(bw);
        _flyingTorqueScale.Write(bw);
        _seatEnteranceAccelerationScale.Write(bw);
        _seatExitAccelersationScale.Write(bw);
        _airFrictionDeceleration.Write(bw);
        _thrustScale.Write(bw);
        _suspensionSound.Write(bw);
        _crashSound.Write(bw);
        _uNUSED.Write(bw);
        _specialEffect.Write(bw);
        _unusedEffect.Write(bw);
        _flags2.Write(bw);
        _groundFriction.Write(bw);
        _groundDepth.Write(bw);
        _groundDampFactor.Write(bw);
        _groundMovingFriction.Write(bw);
        _groundMaximumSlope0.Write(bw);
        _groundMaximumSlope1.Write(bw);
        _unnamed2.Write(bw);
        _antigravitybanklift.Write(bw);
        _steeringbankreactionscale.Write(bw);
        _gravityScale.Write(bw);
        _radius.Write(bw);
_antiGravityPoints.Count = AntiGravityPoints.Count;
        _antiGravityPoints.Write(bw);
_frictionPoints.Count = FrictionPoints.Count;
        _frictionPoints.Write(bw);
_shapePhantomShape.Count = ShapePhantomShape.Count;
        _shapePhantomShape.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _flipMessage.WriteString(writer);
        for (x = 0; (x < _gears.Count); x = (x + 1)) {
          Gears[x].Write(writer);
        }
        for (x = 0; (x < _gears.Count); x = (x + 1)) {
          Gears[x].WriteChildData(writer);
        }
        _suspensionSound.WriteString(writer);
        _crashSound.WriteString(writer);
        _uNUSED.WriteString(writer);
        _specialEffect.WriteString(writer);
        _unusedEffect.WriteString(writer);
        for (x = 0; (x < _antiGravityPoints.Count); x = (x + 1)) {
          AntiGravityPoints[x].Write(writer);
        }
        for (x = 0; (x < _antiGravityPoints.Count); x = (x + 1)) {
          AntiGravityPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _frictionPoints.Count); x = (x + 1)) {
          FrictionPoints[x].Write(writer);
        }
        for (x = 0; (x < _frictionPoints.Count); x = (x + 1)) {
          FrictionPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shapePhantomShape.Count); x = (x + 1)) {
          ShapePhantomShape[x].Write(writer);
        }
        for (x = 0; (x < _shapePhantomShape.Count); x = (x + 1)) {
          ShapePhantomShape[x].WriteChildData(writer);
        }
      }
    }
    public class GearBlockBlock : IBlock {
      private Real _minTorque = new Real();
      private Real _maxTorque = new Real();
      private Real _peakTorqueScale = new Real();
      private Real _pastPeakTorqueExponent = new Real();
      private Real _torqueAtMaxAngularVelocity = new Real();
      private Real _torqueAt2xMaxAngularVelocity = new Real();
      private Real _minTorque2 = new Real();
      private Real _maxTorque2 = new Real();
      private Real _peakTorqueScale2 = new Real();
      private Real _pastPeakTorqueExponent2 = new Real();
      private Real _torqueAtMaxAngularVelocity2 = new Real();
      private Real _torqueAt2xMaxAngularVelocity2 = new Real();
      private Real _minTimeToUpshift = new Real();
      private Real _engineUp_MinusshiftScale = new Real();
      private Real _gearRatio = new Real();
      private Real _minTimeToDownshift = new Real();
      private Real _engineDown_MinusshiftScale = new Real();
public event System.EventHandler BlockNameChanged;
      public GearBlockBlock() {
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
      public Real MinTorque {
        get {
          return this._minTorque;
        }
        set {
          this._minTorque = value;
        }
      }
      public Real MaxTorque {
        get {
          return this._maxTorque;
        }
        set {
          this._maxTorque = value;
        }
      }
      public Real PeakTorqueScale {
        get {
          return this._peakTorqueScale;
        }
        set {
          this._peakTorqueScale = value;
        }
      }
      public Real PastPeakTorqueExponent {
        get {
          return this._pastPeakTorqueExponent;
        }
        set {
          this._pastPeakTorqueExponent = value;
        }
      }
      public Real TorqueAtMaxAngularVelocity {
        get {
          return this._torqueAtMaxAngularVelocity;
        }
        set {
          this._torqueAtMaxAngularVelocity = value;
        }
      }
      public Real TorqueAt2xMaxAngularVelocity {
        get {
          return this._torqueAt2xMaxAngularVelocity;
        }
        set {
          this._torqueAt2xMaxAngularVelocity = value;
        }
      }
      public Real MinTorque2 {
        get {
          return this._minTorque2;
        }
        set {
          this._minTorque2 = value;
        }
      }
      public Real MaxTorque2 {
        get {
          return this._maxTorque2;
        }
        set {
          this._maxTorque2 = value;
        }
      }
      public Real PeakTorqueScale2 {
        get {
          return this._peakTorqueScale2;
        }
        set {
          this._peakTorqueScale2 = value;
        }
      }
      public Real PastPeakTorqueExponent2 {
        get {
          return this._pastPeakTorqueExponent2;
        }
        set {
          this._pastPeakTorqueExponent2 = value;
        }
      }
      public Real TorqueAtMaxAngularVelocity2 {
        get {
          return this._torqueAtMaxAngularVelocity2;
        }
        set {
          this._torqueAtMaxAngularVelocity2 = value;
        }
      }
      public Real TorqueAt2xMaxAngularVelocity2 {
        get {
          return this._torqueAt2xMaxAngularVelocity2;
        }
        set {
          this._torqueAt2xMaxAngularVelocity2 = value;
        }
      }
      public Real MinTimeToUpshift {
        get {
          return this._minTimeToUpshift;
        }
        set {
          this._minTimeToUpshift = value;
        }
      }
      public Real EngineUp_MinusshiftScale {
        get {
          return this._engineUp_MinusshiftScale;
        }
        set {
          this._engineUp_MinusshiftScale = value;
        }
      }
      public Real GearRatio {
        get {
          return this._gearRatio;
        }
        set {
          this._gearRatio = value;
        }
      }
      public Real MinTimeToDownshift {
        get {
          return this._minTimeToDownshift;
        }
        set {
          this._minTimeToDownshift = value;
        }
      }
      public Real EngineDown_MinusshiftScale {
        get {
          return this._engineDown_MinusshiftScale;
        }
        set {
          this._engineDown_MinusshiftScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _minTorque.Read(reader);
        _maxTorque.Read(reader);
        _peakTorqueScale.Read(reader);
        _pastPeakTorqueExponent.Read(reader);
        _torqueAtMaxAngularVelocity.Read(reader);
        _torqueAt2xMaxAngularVelocity.Read(reader);
        _minTorque2.Read(reader);
        _maxTorque2.Read(reader);
        _peakTorqueScale2.Read(reader);
        _pastPeakTorqueExponent2.Read(reader);
        _torqueAtMaxAngularVelocity2.Read(reader);
        _torqueAt2xMaxAngularVelocity2.Read(reader);
        _minTimeToUpshift.Read(reader);
        _engineUp_MinusshiftScale.Read(reader);
        _gearRatio.Read(reader);
        _minTimeToDownshift.Read(reader);
        _engineDown_MinusshiftScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _minTorque.Write(bw);
        _maxTorque.Write(bw);
        _peakTorqueScale.Write(bw);
        _pastPeakTorqueExponent.Write(bw);
        _torqueAtMaxAngularVelocity.Write(bw);
        _torqueAt2xMaxAngularVelocity.Write(bw);
        _minTorque2.Write(bw);
        _maxTorque2.Write(bw);
        _peakTorqueScale2.Write(bw);
        _pastPeakTorqueExponent2.Write(bw);
        _torqueAtMaxAngularVelocity2.Write(bw);
        _torqueAt2xMaxAngularVelocity2.Write(bw);
        _minTimeToUpshift.Write(bw);
        _engineUp_MinusshiftScale.Write(bw);
        _gearRatio.Write(bw);
        _minTimeToDownshift.Write(bw);
        _engineDown_MinusshiftScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AntiGravityPointDefinitionBlockBlock : IBlock {
      private StringId _markerName = new StringId();
      private Flags _flags;
      private Real _antigravStrength = new Real();
      private Real _antigravOffset = new Real();
      private Real _antigravHeight = new Real();
      private Real _antigravDampFactor = new Real();
      private Real _antigravNormalK1 = new Real();
      private Real _antigravNormalK0 = new Real();
      private Real _radius = new Real();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private StringId _damageSourceRegionName = new StringId();
      private Real _defaultStateError = new Real();
      private Real _minorDamageError = new Real();
      private Real _mediumDamageError = new Real();
      private Real _majorDamageError = new Real();
      private Real _destroyedStateError = new Real();
public event System.EventHandler BlockNameChanged;
      public AntiGravityPointDefinitionBlockBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(12);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real AntigravStrength {
        get {
          return this._antigravStrength;
        }
        set {
          this._antigravStrength = value;
        }
      }
      public Real AntigravOffset {
        get {
          return this._antigravOffset;
        }
        set {
          this._antigravOffset = value;
        }
      }
      public Real AntigravHeight {
        get {
          return this._antigravHeight;
        }
        set {
          this._antigravHeight = value;
        }
      }
      public Real AntigravDampFactor {
        get {
          return this._antigravDampFactor;
        }
        set {
          this._antigravDampFactor = value;
        }
      }
      public Real AntigravNormalK1 {
        get {
          return this._antigravNormalK1;
        }
        set {
          this._antigravNormalK1 = value;
        }
      }
      public Real AntigravNormalK0 {
        get {
          return this._antigravNormalK0;
        }
        set {
          this._antigravNormalK0 = value;
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
      public StringId DamageSourceRegionName {
        get {
          return this._damageSourceRegionName;
        }
        set {
          this._damageSourceRegionName = value;
        }
      }
      public Real DefaultStateError {
        get {
          return this._defaultStateError;
        }
        set {
          this._defaultStateError = value;
        }
      }
      public Real MinorDamageError {
        get {
          return this._minorDamageError;
        }
        set {
          this._minorDamageError = value;
        }
      }
      public Real MediumDamageError {
        get {
          return this._mediumDamageError;
        }
        set {
          this._mediumDamageError = value;
        }
      }
      public Real MajorDamageError {
        get {
          return this._majorDamageError;
        }
        set {
          this._majorDamageError = value;
        }
      }
      public Real DestroyedStateError {
        get {
          return this._destroyedStateError;
        }
        set {
          this._destroyedStateError = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _markerName.Read(reader);
        _flags.Read(reader);
        _antigravStrength.Read(reader);
        _antigravOffset.Read(reader);
        _antigravHeight.Read(reader);
        _antigravDampFactor.Read(reader);
        _antigravNormalK1.Read(reader);
        _antigravNormalK0.Read(reader);
        _radius.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _damageSourceRegionName.Read(reader);
        _defaultStateError.Read(reader);
        _minorDamageError.Read(reader);
        _mediumDamageError.Read(reader);
        _majorDamageError.Read(reader);
        _destroyedStateError.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
        _damageSourceRegionName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
        _flags.Write(bw);
        _antigravStrength.Write(bw);
        _antigravOffset.Write(bw);
        _antigravHeight.Write(bw);
        _antigravDampFactor.Write(bw);
        _antigravNormalK1.Write(bw);
        _antigravNormalK0.Write(bw);
        _radius.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _damageSourceRegionName.Write(bw);
        _defaultStateError.Write(bw);
        _minorDamageError.Write(bw);
        _mediumDamageError.Write(bw);
        _majorDamageError.Write(bw);
        _destroyedStateError.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
        _damageSourceRegionName.WriteString(writer);
      }
    }
    public class FrictionPointDefinitionBlockBlock : IBlock {
      private StringId _markerName = new StringId();
      private Flags _flags;
      private Real _fractionOfTotalMass = new Real();
      private Real _radius = new Real();
      private Real _damagedRadius = new Real();
      private Enum _frictionType;
      private Pad _unnamed0;
      private Real _movingFrictionVelocityDiff = new Real();
      private Real _e_MinusbrakeMovingFriction = new Real();
      private Real _e_MinusbrakeFriction = new Real();
      private Real _e_MinusbrakeMovingFrictionVelDiff = new Real();
      private Pad _unnamed1;
      private StringId _collisionGlobalMaterialName = new StringId();
      private Pad _unnamed2;
      private Enum _modelStateDestroyed;
      private StringId _regionName = new StringId();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public FrictionPointDefinitionBlockBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._frictionType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(20);
        this._unnamed2 = new Pad(2);
        this._modelStateDestroyed = new Enum(2);
        this._unnamed3 = new Pad(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real FractionOfTotalMass {
        get {
          return this._fractionOfTotalMass;
        }
        set {
          this._fractionOfTotalMass = value;
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
      public Real DamagedRadius {
        get {
          return this._damagedRadius;
        }
        set {
          this._damagedRadius = value;
        }
      }
      public Enum FrictionType {
        get {
          return this._frictionType;
        }
        set {
          this._frictionType = value;
        }
      }
      public Real MovingFrictionVelocityDiff {
        get {
          return this._movingFrictionVelocityDiff;
        }
        set {
          this._movingFrictionVelocityDiff = value;
        }
      }
      public Real E_MinusbrakeMovingFriction {
        get {
          return this._e_MinusbrakeMovingFriction;
        }
        set {
          this._e_MinusbrakeMovingFriction = value;
        }
      }
      public Real E_MinusbrakeFriction {
        get {
          return this._e_MinusbrakeFriction;
        }
        set {
          this._e_MinusbrakeFriction = value;
        }
      }
      public Real E_MinusbrakeMovingFrictionVelDiff {
        get {
          return this._e_MinusbrakeMovingFrictionVelDiff;
        }
        set {
          this._e_MinusbrakeMovingFrictionVelDiff = value;
        }
      }
      public StringId CollisionGlobalMaterialName {
        get {
          return this._collisionGlobalMaterialName;
        }
        set {
          this._collisionGlobalMaterialName = value;
        }
      }
      public Enum ModelStateDestroyed {
        get {
          return this._modelStateDestroyed;
        }
        set {
          this._modelStateDestroyed = value;
        }
      }
      public StringId RegionName {
        get {
          return this._regionName;
        }
        set {
          this._regionName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _markerName.Read(reader);
        _flags.Read(reader);
        _fractionOfTotalMass.Read(reader);
        _radius.Read(reader);
        _damagedRadius.Read(reader);
        _frictionType.Read(reader);
        _unnamed0.Read(reader);
        _movingFrictionVelocityDiff.Read(reader);
        _e_MinusbrakeMovingFriction.Read(reader);
        _e_MinusbrakeFriction.Read(reader);
        _e_MinusbrakeMovingFrictionVelDiff.Read(reader);
        _unnamed1.Read(reader);
        _collisionGlobalMaterialName.Read(reader);
        _unnamed2.Read(reader);
        _modelStateDestroyed.Read(reader);
        _regionName.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
        _collisionGlobalMaterialName.ReadString(reader);
        _regionName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
        _flags.Write(bw);
        _fractionOfTotalMass.Write(bw);
        _radius.Write(bw);
        _damagedRadius.Write(bw);
        _frictionType.Write(bw);
        _unnamed0.Write(bw);
        _movingFrictionVelocityDiff.Write(bw);
        _e_MinusbrakeMovingFriction.Write(bw);
        _e_MinusbrakeFriction.Write(bw);
        _e_MinusbrakeMovingFrictionVelDiff.Write(bw);
        _unnamed1.Write(bw);
        _collisionGlobalMaterialName.Write(bw);
        _unnamed2.Write(bw);
        _modelStateDestroyed.Write(bw);
        _regionName.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
        _collisionGlobalMaterialName.WriteString(writer);
        _regionName.WriteString(writer);
      }
    }
    public class VehiclePhantomShapeBlockBlock : IBlock {
      private Skip _unnamed0;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed1;
      private Skip _unnamed2;
      private LongInteger _childShapesSize = new LongInteger();
      private LongInteger _childShapesCapacity = new LongInteger();
      private Enum _shapeType;
      private ShortInteger _shape = new ShortInteger();
      private LongInteger _collisionFilter = new LongInteger();
      private Enum _shapeType2;
      private ShortInteger _shape2 = new ShortInteger();
      private LongInteger _collisionFilter2 = new LongInteger();
      private Enum _shapeType3;
      private ShortInteger _shape3 = new ShortInteger();
      private LongInteger _collisionFilter3 = new LongInteger();
      private Enum _shapeType4;
      private ShortInteger _shape4 = new ShortInteger();
      private LongInteger _collisionFilter4 = new LongInteger();
      private LongInteger _multisphereCount = new LongInteger();
      private Flags _flags;
      private Pad _unnamed3;
      private Real _x0 = new Real();
      private Real _x1 = new Real();
      private Real _y0 = new Real();
      private Real _y1 = new Real();
      private Real _z0 = new Real();
      private Real _z1 = new Real();
      private Skip _unnamed4;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed5;
      private LongInteger _numSpheres = new LongInteger();
      private RealVector3D _sphere = new RealVector3D();
      private Skip _unnamed6;
      private RealVector3D _sphere2 = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _sphere3 = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _sphere4 = new RealVector3D();
      private Skip _unnamed9;
      private RealVector3D _sphere5 = new RealVector3D();
      private Skip _unnamed10;
      private RealVector3D _sphere6 = new RealVector3D();
      private Skip _unnamed11;
      private RealVector3D _sphere7 = new RealVector3D();
      private Skip _unnamed12;
      private RealVector3D _sphere8 = new RealVector3D();
      private Skip _unnamed13;
      private Skip _unnamed14;
      private ShortInteger _size3 = new ShortInteger();
      private ShortInteger _count3 = new ShortInteger();
      private Skip _unnamed15;
      private LongInteger _numSpheres2 = new LongInteger();
      private RealVector3D _sphere9 = new RealVector3D();
      private Skip _unnamed16;
      private RealVector3D _sphere10 = new RealVector3D();
      private Skip _unnamed17;
      private RealVector3D _sphere11 = new RealVector3D();
      private Skip _unnamed18;
      private RealVector3D _sphere12 = new RealVector3D();
      private Skip _unnamed19;
      private RealVector3D _sphere13 = new RealVector3D();
      private Skip _unnamed20;
      private RealVector3D _sphere14 = new RealVector3D();
      private Skip _unnamed21;
      private RealVector3D _sphere15 = new RealVector3D();
      private Skip _unnamed22;
      private RealVector3D _sphere16 = new RealVector3D();
      private Skip _unnamed23;
      private Skip _unnamed24;
      private ShortInteger _size4 = new ShortInteger();
      private ShortInteger _count4 = new ShortInteger();
      private Skip _unnamed25;
      private LongInteger _numSpheres3 = new LongInteger();
      private RealVector3D _sphere17 = new RealVector3D();
      private Skip _unnamed26;
      private RealVector3D _sphere18 = new RealVector3D();
      private Skip _unnamed27;
      private RealVector3D _sphere19 = new RealVector3D();
      private Skip _unnamed28;
      private RealVector3D _sphere20 = new RealVector3D();
      private Skip _unnamed29;
      private RealVector3D _sphere21 = new RealVector3D();
      private Skip _unnamed30;
      private RealVector3D _sphere22 = new RealVector3D();
      private Skip _unnamed31;
      private RealVector3D _sphere23 = new RealVector3D();
      private Skip _unnamed32;
      private RealVector3D _sphere24 = new RealVector3D();
      private Skip _unnamed33;
      private Skip _unnamed34;
      private ShortInteger _size5 = new ShortInteger();
      private ShortInteger _count5 = new ShortInteger();
      private Skip _unnamed35;
      private LongInteger _numSpheres4 = new LongInteger();
      private RealVector3D _sphere25 = new RealVector3D();
      private Skip _unnamed36;
      private RealVector3D _sphere26 = new RealVector3D();
      private Skip _unnamed37;
      private RealVector3D _sphere27 = new RealVector3D();
      private Skip _unnamed38;
      private RealVector3D _sphere28 = new RealVector3D();
      private Skip _unnamed39;
      private RealVector3D _sphere29 = new RealVector3D();
      private Skip _unnamed40;
      private RealVector3D _sphere30 = new RealVector3D();
      private Skip _unnamed41;
      private RealVector3D _sphere31 = new RealVector3D();
      private Skip _unnamed42;
      private RealVector3D _sphere32 = new RealVector3D();
      private Skip _unnamed43;
public event System.EventHandler BlockNameChanged;
      public VehiclePhantomShapeBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._shapeType = new Enum(2);
        this._shapeType2 = new Enum(2);
        this._shapeType3 = new Enum(2);
        this._shapeType4 = new Enum(2);
        this._flags = new Flags(4);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
        this._unnamed10 = new Skip(4);
        this._unnamed11 = new Skip(4);
        this._unnamed12 = new Skip(4);
        this._unnamed13 = new Skip(4);
        this._unnamed14 = new Skip(4);
        this._unnamed15 = new Skip(4);
        this._unnamed16 = new Skip(4);
        this._unnamed17 = new Skip(4);
        this._unnamed18 = new Skip(4);
        this._unnamed19 = new Skip(4);
        this._unnamed20 = new Skip(4);
        this._unnamed21 = new Skip(4);
        this._unnamed22 = new Skip(4);
        this._unnamed23 = new Skip(4);
        this._unnamed24 = new Skip(4);
        this._unnamed25 = new Skip(4);
        this._unnamed26 = new Skip(4);
        this._unnamed27 = new Skip(4);
        this._unnamed28 = new Skip(4);
        this._unnamed29 = new Skip(4);
        this._unnamed30 = new Skip(4);
        this._unnamed31 = new Skip(4);
        this._unnamed32 = new Skip(4);
        this._unnamed33 = new Skip(4);
        this._unnamed34 = new Skip(4);
        this._unnamed35 = new Skip(4);
        this._unnamed36 = new Skip(4);
        this._unnamed37 = new Skip(4);
        this._unnamed38 = new Skip(4);
        this._unnamed39 = new Skip(4);
        this._unnamed40 = new Skip(4);
        this._unnamed41 = new Skip(4);
        this._unnamed42 = new Skip(4);
        this._unnamed43 = new Skip(4);
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
      public LongInteger ChildShapesSize {
        get {
          return this._childShapesSize;
        }
        set {
          this._childShapesSize = value;
        }
      }
      public LongInteger ChildShapesCapacity {
        get {
          return this._childShapesCapacity;
        }
        set {
          this._childShapesCapacity = value;
        }
      }
      public Enum ShapeType {
        get {
          return this._shapeType;
        }
        set {
          this._shapeType = value;
        }
      }
      public ShortInteger Shape {
        get {
          return this._shape;
        }
        set {
          this._shape = value;
        }
      }
      public LongInteger CollisionFilter {
        get {
          return this._collisionFilter;
        }
        set {
          this._collisionFilter = value;
        }
      }
      public Enum ShapeType2 {
        get {
          return this._shapeType2;
        }
        set {
          this._shapeType2 = value;
        }
      }
      public ShortInteger Shape2 {
        get {
          return this._shape2;
        }
        set {
          this._shape2 = value;
        }
      }
      public LongInteger CollisionFilter2 {
        get {
          return this._collisionFilter2;
        }
        set {
          this._collisionFilter2 = value;
        }
      }
      public Enum ShapeType3 {
        get {
          return this._shapeType3;
        }
        set {
          this._shapeType3 = value;
        }
      }
      public ShortInteger Shape3 {
        get {
          return this._shape3;
        }
        set {
          this._shape3 = value;
        }
      }
      public LongInteger CollisionFilter3 {
        get {
          return this._collisionFilter3;
        }
        set {
          this._collisionFilter3 = value;
        }
      }
      public Enum ShapeType4 {
        get {
          return this._shapeType4;
        }
        set {
          this._shapeType4 = value;
        }
      }
      public ShortInteger Shape4 {
        get {
          return this._shape4;
        }
        set {
          this._shape4 = value;
        }
      }
      public LongInteger CollisionFilter4 {
        get {
          return this._collisionFilter4;
        }
        set {
          this._collisionFilter4 = value;
        }
      }
      public LongInteger MultisphereCount {
        get {
          return this._multisphereCount;
        }
        set {
          this._multisphereCount = value;
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
      public Real X0 {
        get {
          return this._x0;
        }
        set {
          this._x0 = value;
        }
      }
      public Real X1 {
        get {
          return this._x1;
        }
        set {
          this._x1 = value;
        }
      }
      public Real Y0 {
        get {
          return this._y0;
        }
        set {
          this._y0 = value;
        }
      }
      public Real Y1 {
        get {
          return this._y1;
        }
        set {
          this._y1 = value;
        }
      }
      public Real Z0 {
        get {
          return this._z0;
        }
        set {
          this._z0 = value;
        }
      }
      public Real Z1 {
        get {
          return this._z1;
        }
        set {
          this._z1 = value;
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
      public LongInteger NumSpheres {
        get {
          return this._numSpheres;
        }
        set {
          this._numSpheres = value;
        }
      }
      public RealVector3D Sphere {
        get {
          return this._sphere;
        }
        set {
          this._sphere = value;
        }
      }
      public RealVector3D Sphere2 {
        get {
          return this._sphere2;
        }
        set {
          this._sphere2 = value;
        }
      }
      public RealVector3D Sphere3 {
        get {
          return this._sphere3;
        }
        set {
          this._sphere3 = value;
        }
      }
      public RealVector3D Sphere4 {
        get {
          return this._sphere4;
        }
        set {
          this._sphere4 = value;
        }
      }
      public RealVector3D Sphere5 {
        get {
          return this._sphere5;
        }
        set {
          this._sphere5 = value;
        }
      }
      public RealVector3D Sphere6 {
        get {
          return this._sphere6;
        }
        set {
          this._sphere6 = value;
        }
      }
      public RealVector3D Sphere7 {
        get {
          return this._sphere7;
        }
        set {
          this._sphere7 = value;
        }
      }
      public RealVector3D Sphere8 {
        get {
          return this._sphere8;
        }
        set {
          this._sphere8 = value;
        }
      }
      public ShortInteger Size3 {
        get {
          return this._size3;
        }
        set {
          this._size3 = value;
        }
      }
      public ShortInteger Count3 {
        get {
          return this._count3;
        }
        set {
          this._count3 = value;
        }
      }
      public LongInteger NumSpheres2 {
        get {
          return this._numSpheres2;
        }
        set {
          this._numSpheres2 = value;
        }
      }
      public RealVector3D Sphere9 {
        get {
          return this._sphere9;
        }
        set {
          this._sphere9 = value;
        }
      }
      public RealVector3D Sphere10 {
        get {
          return this._sphere10;
        }
        set {
          this._sphere10 = value;
        }
      }
      public RealVector3D Sphere11 {
        get {
          return this._sphere11;
        }
        set {
          this._sphere11 = value;
        }
      }
      public RealVector3D Sphere12 {
        get {
          return this._sphere12;
        }
        set {
          this._sphere12 = value;
        }
      }
      public RealVector3D Sphere13 {
        get {
          return this._sphere13;
        }
        set {
          this._sphere13 = value;
        }
      }
      public RealVector3D Sphere14 {
        get {
          return this._sphere14;
        }
        set {
          this._sphere14 = value;
        }
      }
      public RealVector3D Sphere15 {
        get {
          return this._sphere15;
        }
        set {
          this._sphere15 = value;
        }
      }
      public RealVector3D Sphere16 {
        get {
          return this._sphere16;
        }
        set {
          this._sphere16 = value;
        }
      }
      public ShortInteger Size4 {
        get {
          return this._size4;
        }
        set {
          this._size4 = value;
        }
      }
      public ShortInteger Count4 {
        get {
          return this._count4;
        }
        set {
          this._count4 = value;
        }
      }
      public LongInteger NumSpheres3 {
        get {
          return this._numSpheres3;
        }
        set {
          this._numSpheres3 = value;
        }
      }
      public RealVector3D Sphere17 {
        get {
          return this._sphere17;
        }
        set {
          this._sphere17 = value;
        }
      }
      public RealVector3D Sphere18 {
        get {
          return this._sphere18;
        }
        set {
          this._sphere18 = value;
        }
      }
      public RealVector3D Sphere19 {
        get {
          return this._sphere19;
        }
        set {
          this._sphere19 = value;
        }
      }
      public RealVector3D Sphere20 {
        get {
          return this._sphere20;
        }
        set {
          this._sphere20 = value;
        }
      }
      public RealVector3D Sphere21 {
        get {
          return this._sphere21;
        }
        set {
          this._sphere21 = value;
        }
      }
      public RealVector3D Sphere22 {
        get {
          return this._sphere22;
        }
        set {
          this._sphere22 = value;
        }
      }
      public RealVector3D Sphere23 {
        get {
          return this._sphere23;
        }
        set {
          this._sphere23 = value;
        }
      }
      public RealVector3D Sphere24 {
        get {
          return this._sphere24;
        }
        set {
          this._sphere24 = value;
        }
      }
      public ShortInteger Size5 {
        get {
          return this._size5;
        }
        set {
          this._size5 = value;
        }
      }
      public ShortInteger Count5 {
        get {
          return this._count5;
        }
        set {
          this._count5 = value;
        }
      }
      public LongInteger NumSpheres4 {
        get {
          return this._numSpheres4;
        }
        set {
          this._numSpheres4 = value;
        }
      }
      public RealVector3D Sphere25 {
        get {
          return this._sphere25;
        }
        set {
          this._sphere25 = value;
        }
      }
      public RealVector3D Sphere26 {
        get {
          return this._sphere26;
        }
        set {
          this._sphere26 = value;
        }
      }
      public RealVector3D Sphere27 {
        get {
          return this._sphere27;
        }
        set {
          this._sphere27 = value;
        }
      }
      public RealVector3D Sphere28 {
        get {
          return this._sphere28;
        }
        set {
          this._sphere28 = value;
        }
      }
      public RealVector3D Sphere29 {
        get {
          return this._sphere29;
        }
        set {
          this._sphere29 = value;
        }
      }
      public RealVector3D Sphere30 {
        get {
          return this._sphere30;
        }
        set {
          this._sphere30 = value;
        }
      }
      public RealVector3D Sphere31 {
        get {
          return this._sphere31;
        }
        set {
          this._sphere31 = value;
        }
      }
      public RealVector3D Sphere32 {
        get {
          return this._sphere32;
        }
        set {
          this._sphere32 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _childShapesSize.Read(reader);
        _childShapesCapacity.Read(reader);
        _shapeType.Read(reader);
        _shape.Read(reader);
        _collisionFilter.Read(reader);
        _shapeType2.Read(reader);
        _shape2.Read(reader);
        _collisionFilter2.Read(reader);
        _shapeType3.Read(reader);
        _shape3.Read(reader);
        _collisionFilter3.Read(reader);
        _shapeType4.Read(reader);
        _shape4.Read(reader);
        _collisionFilter4.Read(reader);
        _multisphereCount.Read(reader);
        _flags.Read(reader);
        _unnamed3.Read(reader);
        _x0.Read(reader);
        _x1.Read(reader);
        _y0.Read(reader);
        _y1.Read(reader);
        _z0.Read(reader);
        _z1.Read(reader);
        _unnamed4.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed5.Read(reader);
        _numSpheres.Read(reader);
        _sphere.Read(reader);
        _unnamed6.Read(reader);
        _sphere2.Read(reader);
        _unnamed7.Read(reader);
        _sphere3.Read(reader);
        _unnamed8.Read(reader);
        _sphere4.Read(reader);
        _unnamed9.Read(reader);
        _sphere5.Read(reader);
        _unnamed10.Read(reader);
        _sphere6.Read(reader);
        _unnamed11.Read(reader);
        _sphere7.Read(reader);
        _unnamed12.Read(reader);
        _sphere8.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _size3.Read(reader);
        _count3.Read(reader);
        _unnamed15.Read(reader);
        _numSpheres2.Read(reader);
        _sphere9.Read(reader);
        _unnamed16.Read(reader);
        _sphere10.Read(reader);
        _unnamed17.Read(reader);
        _sphere11.Read(reader);
        _unnamed18.Read(reader);
        _sphere12.Read(reader);
        _unnamed19.Read(reader);
        _sphere13.Read(reader);
        _unnamed20.Read(reader);
        _sphere14.Read(reader);
        _unnamed21.Read(reader);
        _sphere15.Read(reader);
        _unnamed22.Read(reader);
        _sphere16.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _size4.Read(reader);
        _count4.Read(reader);
        _unnamed25.Read(reader);
        _numSpheres3.Read(reader);
        _sphere17.Read(reader);
        _unnamed26.Read(reader);
        _sphere18.Read(reader);
        _unnamed27.Read(reader);
        _sphere19.Read(reader);
        _unnamed28.Read(reader);
        _sphere20.Read(reader);
        _unnamed29.Read(reader);
        _sphere21.Read(reader);
        _unnamed30.Read(reader);
        _sphere22.Read(reader);
        _unnamed31.Read(reader);
        _sphere23.Read(reader);
        _unnamed32.Read(reader);
        _sphere24.Read(reader);
        _unnamed33.Read(reader);
        _unnamed34.Read(reader);
        _size5.Read(reader);
        _count5.Read(reader);
        _unnamed35.Read(reader);
        _numSpheres4.Read(reader);
        _sphere25.Read(reader);
        _unnamed36.Read(reader);
        _sphere26.Read(reader);
        _unnamed37.Read(reader);
        _sphere27.Read(reader);
        _unnamed38.Read(reader);
        _sphere28.Read(reader);
        _unnamed39.Read(reader);
        _sphere29.Read(reader);
        _unnamed40.Read(reader);
        _sphere30.Read(reader);
        _unnamed41.Read(reader);
        _sphere31.Read(reader);
        _unnamed42.Read(reader);
        _sphere32.Read(reader);
        _unnamed43.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _childShapesSize.Write(bw);
        _childShapesCapacity.Write(bw);
        _shapeType.Write(bw);
        _shape.Write(bw);
        _collisionFilter.Write(bw);
        _shapeType2.Write(bw);
        _shape2.Write(bw);
        _collisionFilter2.Write(bw);
        _shapeType3.Write(bw);
        _shape3.Write(bw);
        _collisionFilter3.Write(bw);
        _shapeType4.Write(bw);
        _shape4.Write(bw);
        _collisionFilter4.Write(bw);
        _multisphereCount.Write(bw);
        _flags.Write(bw);
        _unnamed3.Write(bw);
        _x0.Write(bw);
        _x1.Write(bw);
        _y0.Write(bw);
        _y1.Write(bw);
        _z0.Write(bw);
        _z1.Write(bw);
        _unnamed4.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed5.Write(bw);
        _numSpheres.Write(bw);
        _sphere.Write(bw);
        _unnamed6.Write(bw);
        _sphere2.Write(bw);
        _unnamed7.Write(bw);
        _sphere3.Write(bw);
        _unnamed8.Write(bw);
        _sphere4.Write(bw);
        _unnamed9.Write(bw);
        _sphere5.Write(bw);
        _unnamed10.Write(bw);
        _sphere6.Write(bw);
        _unnamed11.Write(bw);
        _sphere7.Write(bw);
        _unnamed12.Write(bw);
        _sphere8.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _size3.Write(bw);
        _count3.Write(bw);
        _unnamed15.Write(bw);
        _numSpheres2.Write(bw);
        _sphere9.Write(bw);
        _unnamed16.Write(bw);
        _sphere10.Write(bw);
        _unnamed17.Write(bw);
        _sphere11.Write(bw);
        _unnamed18.Write(bw);
        _sphere12.Write(bw);
        _unnamed19.Write(bw);
        _sphere13.Write(bw);
        _unnamed20.Write(bw);
        _sphere14.Write(bw);
        _unnamed21.Write(bw);
        _sphere15.Write(bw);
        _unnamed22.Write(bw);
        _sphere16.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _size4.Write(bw);
        _count4.Write(bw);
        _unnamed25.Write(bw);
        _numSpheres3.Write(bw);
        _sphere17.Write(bw);
        _unnamed26.Write(bw);
        _sphere18.Write(bw);
        _unnamed27.Write(bw);
        _sphere19.Write(bw);
        _unnamed28.Write(bw);
        _sphere20.Write(bw);
        _unnamed29.Write(bw);
        _sphere21.Write(bw);
        _unnamed30.Write(bw);
        _sphere22.Write(bw);
        _unnamed31.Write(bw);
        _sphere23.Write(bw);
        _unnamed32.Write(bw);
        _sphere24.Write(bw);
        _unnamed33.Write(bw);
        _unnamed34.Write(bw);
        _size5.Write(bw);
        _count5.Write(bw);
        _unnamed35.Write(bw);
        _numSpheres4.Write(bw);
        _sphere25.Write(bw);
        _unnamed36.Write(bw);
        _sphere26.Write(bw);
        _unnamed37.Write(bw);
        _sphere27.Write(bw);
        _unnamed38.Write(bw);
        _sphere28.Write(bw);
        _unnamed39.Write(bw);
        _sphere29.Write(bw);
        _unnamed40.Write(bw);
        _sphere30.Write(bw);
        _unnamed41.Write(bw);
        _sphere31.Write(bw);
        _unnamed42.Write(bw);
        _sphere32.Write(bw);
        _unnamed43.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
