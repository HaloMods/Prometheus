// --------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'vehicle' (derived from 'unit')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// --------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class vehicle : unit {
    private VehicleBlock vehicleValues = new VehicleBlock();
    public virtual VehicleBlock VehicleValues {
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
    public class VehicleBlock : IBlock {
      private Flags _flags;
      private Enum _type = new Enum();
      private Pad _unnamed;
      private Real _maximumForwardSpeed = new Real();
      private Real _maximumReverseSpeed = new Real();
      private Real _speedAcceleration = new Real();
      private Real _speedDeceleration = new Real();
      private Real _maximumLeftTurn = new Real();
      private Real _maximumRightTurnNegative = new Real();
      private Real _wheelCircumference = new Real();
      private Real _turnRate = new Real();
      private Real _blurSpeed = new Real();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private Pad _unnamed2;
      private Real _maximumLeftSlide = new Real();
      private Real _maximumRightSlide = new Real();
      private Real _slideAcceleration = new Real();
      private Real _slideDeceleration = new Real();
      private Real _minimumFlippingAngularVelocity = new Real();
      private Real _maximumFlippingAngularVelocity = new Real();
      private Pad _unnamed3;
      private Real _fixedGunYaw = new Real();
      private Real _fixedGunPitch = new Real();
      private Pad _unnamed4;
      private Real _aiSideslipDistance = new Real();
      private Real _aiDestinationRadius = new Real();
      private Real _aiAvoidanceDistance = new Real();
      private Real _aiPathfindingRadius = new Real();
      private Real _aiChargeRepeatTimeout = new Real();
      private Real _aiStrafingAbortRange = new Real();
      private AngleBounds _aiOversteeringBounds = new AngleBounds();
      private Angle _aiSteeringMaximum = new Angle();
      private Real _aiThrottleMaximum = new Real();
      private Real _aiMov = new Real();
      private Pad _unnamed5;
      private TagReference _suspensionSound = new TagReference();
      private TagReference _crashSound = new TagReference();
      private TagReference _materialEffects = new TagReference();
      private TagReference _effect = new TagReference();
public event System.EventHandler BlockNameChanged;
      public VehicleBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(24);
        this._unnamed4 = new Pad(24);
        this._unnamed5 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_suspensionSound.Value);
references.Add(_crashSound.Value);
references.Add(_materialEffects.Value);
references.Add(_effect.Value);
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
      public Real AiSideslipDistance {
        get {
          return this._aiSideslipDistance;
        }
        set {
          this._aiSideslipDistance = value;
        }
      }
      public Real AiDestinationRadius {
        get {
          return this._aiDestinationRadius;
        }
        set {
          this._aiDestinationRadius = value;
        }
      }
      public Real AiAvoidanceDistance {
        get {
          return this._aiAvoidanceDistance;
        }
        set {
          this._aiAvoidanceDistance = value;
        }
      }
      public Real AiPathfindingRadius {
        get {
          return this._aiPathfindingRadius;
        }
        set {
          this._aiPathfindingRadius = value;
        }
      }
      public Real AiChargeRepeatTimeout {
        get {
          return this._aiChargeRepeatTimeout;
        }
        set {
          this._aiChargeRepeatTimeout = value;
        }
      }
      public Real AiStrafingAbortRange {
        get {
          return this._aiStrafingAbortRange;
        }
        set {
          this._aiStrafingAbortRange = value;
        }
      }
      public AngleBounds AiOversteeringBounds {
        get {
          return this._aiOversteeringBounds;
        }
        set {
          this._aiOversteeringBounds = value;
        }
      }
      public Angle AiSteeringMaximum {
        get {
          return this._aiSteeringMaximum;
        }
        set {
          this._aiSteeringMaximum = value;
        }
      }
      public Real AiThrottleMaximum {
        get {
          return this._aiThrottleMaximum;
        }
        set {
          this._aiThrottleMaximum = value;
        }
      }
      public Real AiMov {
        get {
          return this._aiMov;
        }
        set {
          this._aiMov = value;
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
      public TagReference MaterialEffects {
        get {
          return this._materialEffects;
        }
        set {
          this._materialEffects = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type.Read(reader);
        _unnamed.Read(reader);
        _maximumForwardSpeed.Read(reader);
        _maximumReverseSpeed.Read(reader);
        _speedAcceleration.Read(reader);
        _speedDeceleration.Read(reader);
        _maximumLeftTurn.Read(reader);
        _maximumRightTurnNegative.Read(reader);
        _wheelCircumference.Read(reader);
        _turnRate.Read(reader);
        _blurSpeed.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _unnamed2.Read(reader);
        _maximumLeftSlide.Read(reader);
        _maximumRightSlide.Read(reader);
        _slideAcceleration.Read(reader);
        _slideDeceleration.Read(reader);
        _minimumFlippingAngularVelocity.Read(reader);
        _maximumFlippingAngularVelocity.Read(reader);
        _unnamed3.Read(reader);
        _fixedGunYaw.Read(reader);
        _fixedGunPitch.Read(reader);
        _unnamed4.Read(reader);
        _aiSideslipDistance.Read(reader);
        _aiDestinationRadius.Read(reader);
        _aiAvoidanceDistance.Read(reader);
        _aiPathfindingRadius.Read(reader);
        _aiChargeRepeatTimeout.Read(reader);
        _aiStrafingAbortRange.Read(reader);
        _aiOversteeringBounds.Read(reader);
        _aiSteeringMaximum.Read(reader);
        _aiThrottleMaximum.Read(reader);
        _aiMov.Read(reader);
        _unnamed5.Read(reader);
        _suspensionSound.Read(reader);
        _crashSound.Read(reader);
        _materialEffects.Read(reader);
        _effect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _suspensionSound.ReadString(reader);
        _crashSound.ReadString(reader);
        _materialEffects.ReadString(reader);
        _effect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _unnamed.Write(bw);
        _maximumForwardSpeed.Write(bw);
        _maximumReverseSpeed.Write(bw);
        _speedAcceleration.Write(bw);
        _speedDeceleration.Write(bw);
        _maximumLeftTurn.Write(bw);
        _maximumRightTurnNegative.Write(bw);
        _wheelCircumference.Write(bw);
        _turnRate.Write(bw);
        _blurSpeed.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _unnamed2.Write(bw);
        _maximumLeftSlide.Write(bw);
        _maximumRightSlide.Write(bw);
        _slideAcceleration.Write(bw);
        _slideDeceleration.Write(bw);
        _minimumFlippingAngularVelocity.Write(bw);
        _maximumFlippingAngularVelocity.Write(bw);
        _unnamed3.Write(bw);
        _fixedGunYaw.Write(bw);
        _fixedGunPitch.Write(bw);
        _unnamed4.Write(bw);
        _aiSideslipDistance.Write(bw);
        _aiDestinationRadius.Write(bw);
        _aiAvoidanceDistance.Write(bw);
        _aiPathfindingRadius.Write(bw);
        _aiChargeRepeatTimeout.Write(bw);
        _aiStrafingAbortRange.Write(bw);
        _aiOversteeringBounds.Write(bw);
        _aiSteeringMaximum.Write(bw);
        _aiThrottleMaximum.Write(bw);
        _aiMov.Write(bw);
        _unnamed5.Write(bw);
        _suspensionSound.Write(bw);
        _crashSound.Write(bw);
        _materialEffects.Write(bw);
        _effect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _suspensionSound.WriteString(writer);
        _crashSound.WriteString(writer);
        _materialEffects.WriteString(writer);
        _effect.WriteString(writer);
      }
    }
  }
}
