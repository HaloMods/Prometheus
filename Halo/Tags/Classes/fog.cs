// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'fog'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class fog : Interfaces.Pool.Tag {
    private FogBlock fogValues = new FogBlock();
    public virtual FogBlock FogValues {
      get {
        return fogValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(FogValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "fog";
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
fogValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
fogValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
fogValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
fogValues.WriteChildData(writer);
    }
    #endregion
    public class FogBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private RealFraction _maximumDensity = new RealFraction();
      private Pad _unnamed4;
      private Real _opaqueDistance = new Real();
      private Pad _unnamed5;
      private Real _opaqueDepth = new Real();
      private Pad _unnamed6;
      private Real _distanceToWaterPlane = new Real();
      private RealRGBColor _color = new RealRGBColor();
      private Flags _flags2;
      private ShortInteger _layerCount = new ShortInteger();
      private RealBounds _distanceGradient = new RealBounds();
      private RealFractionBounds _densityGradient = new RealFractionBounds();
      private Real _startDistanceFromFogPlane = new Real();
      private Pad _unnamed7;
      private RGBColor _color2 = new RGBColor();
      private RealFraction _rotationMultiplier = new RealFraction();
      private RealFraction _strafingMultiplier = new RealFraction();
      private RealFraction _zoomMultiplier = new RealFraction();
      private Pad _unnamed8;
      private Real _mapScale = new Real();
      private TagReference _map = new TagReference();
      private Real _animationPeriod = new Real();
      private Pad _unnamed9;
      private RealBounds _windVelocity = new RealBounds();
      private RealBounds _windPeriod = new RealBounds();
      private RealFraction _windAccelerationWeight = new RealFraction();
      private RealFraction _windPerpendicularWeight = new RealFraction();
      private Pad _unnamed10;
      private TagReference _backgroundSound = new TagReference();
      private TagReference _soundEnvironment = new TagReference();
      private Pad _unnamed11;
public event System.EventHandler BlockNameChanged;
      public FogBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(76);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(8);
        this._flags2 = new Flags(2);
        this._unnamed7 = new Pad(4);
        this._unnamed8 = new Pad(8);
        this._unnamed9 = new Pad(4);
        this._unnamed10 = new Pad(8);
        this._unnamed11 = new Pad(120);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_map.Value);
references.Add(_backgroundSound.Value);
references.Add(_soundEnvironment.Value);
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
      public RealFraction MaximumDensity {
        get {
          return this._maximumDensity;
        }
        set {
          this._maximumDensity = value;
        }
      }
      public Real OpaqueDistance {
        get {
          return this._opaqueDistance;
        }
        set {
          this._opaqueDistance = value;
        }
      }
      public Real OpaqueDepth {
        get {
          return this._opaqueDepth;
        }
        set {
          this._opaqueDepth = value;
        }
      }
      public Real DistanceToWaterPlane {
        get {
          return this._distanceToWaterPlane;
        }
        set {
          this._distanceToWaterPlane = value;
        }
      }
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
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
      public ShortInteger LayerCount {
        get {
          return this._layerCount;
        }
        set {
          this._layerCount = value;
        }
      }
      public RealBounds DistanceGradient {
        get {
          return this._distanceGradient;
        }
        set {
          this._distanceGradient = value;
        }
      }
      public RealFractionBounds DensityGradient {
        get {
          return this._densityGradient;
        }
        set {
          this._densityGradient = value;
        }
      }
      public Real StartDistanceFromFogPlane {
        get {
          return this._startDistanceFromFogPlane;
        }
        set {
          this._startDistanceFromFogPlane = value;
        }
      }
      public RGBColor Color2 {
        get {
          return this._color2;
        }
        set {
          this._color2 = value;
        }
      }
      public RealFraction RotationMultiplier {
        get {
          return this._rotationMultiplier;
        }
        set {
          this._rotationMultiplier = value;
        }
      }
      public RealFraction StrafingMultiplier {
        get {
          return this._strafingMultiplier;
        }
        set {
          this._strafingMultiplier = value;
        }
      }
      public RealFraction ZoomMultiplier {
        get {
          return this._zoomMultiplier;
        }
        set {
          this._zoomMultiplier = value;
        }
      }
      public Real MapScale {
        get {
          return this._mapScale;
        }
        set {
          this._mapScale = value;
        }
      }
      public TagReference Map {
        get {
          return this._map;
        }
        set {
          this._map = value;
        }
      }
      public Real AnimationPeriod {
        get {
          return this._animationPeriod;
        }
        set {
          this._animationPeriod = value;
        }
      }
      public RealBounds WindVelocity {
        get {
          return this._windVelocity;
        }
        set {
          this._windVelocity = value;
        }
      }
      public RealBounds WindPeriod {
        get {
          return this._windPeriod;
        }
        set {
          this._windPeriod = value;
        }
      }
      public RealFraction WindAccelerationWeight {
        get {
          return this._windAccelerationWeight;
        }
        set {
          this._windAccelerationWeight = value;
        }
      }
      public RealFraction WindPerpendicularWeight {
        get {
          return this._windPerpendicularWeight;
        }
        set {
          this._windPerpendicularWeight = value;
        }
      }
      public TagReference BackgroundSound {
        get {
          return this._backgroundSound;
        }
        set {
          this._backgroundSound = value;
        }
      }
      public TagReference SoundEnvironment {
        get {
          return this._soundEnvironment;
        }
        set {
          this._soundEnvironment = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _maximumDensity.Read(reader);
        _unnamed4.Read(reader);
        _opaqueDistance.Read(reader);
        _unnamed5.Read(reader);
        _opaqueDepth.Read(reader);
        _unnamed6.Read(reader);
        _distanceToWaterPlane.Read(reader);
        _color.Read(reader);
        _flags2.Read(reader);
        _layerCount.Read(reader);
        _distanceGradient.Read(reader);
        _densityGradient.Read(reader);
        _startDistanceFromFogPlane.Read(reader);
        _unnamed7.Read(reader);
        _color2.Read(reader);
        _rotationMultiplier.Read(reader);
        _strafingMultiplier.Read(reader);
        _zoomMultiplier.Read(reader);
        _unnamed8.Read(reader);
        _mapScale.Read(reader);
        _map.Read(reader);
        _animationPeriod.Read(reader);
        _unnamed9.Read(reader);
        _windVelocity.Read(reader);
        _windPeriod.Read(reader);
        _windAccelerationWeight.Read(reader);
        _windPerpendicularWeight.Read(reader);
        _unnamed10.Read(reader);
        _backgroundSound.Read(reader);
        _soundEnvironment.Read(reader);
        _unnamed11.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _map.ReadString(reader);
        _backgroundSound.ReadString(reader);
        _soundEnvironment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _maximumDensity.Write(bw);
        _unnamed4.Write(bw);
        _opaqueDistance.Write(bw);
        _unnamed5.Write(bw);
        _opaqueDepth.Write(bw);
        _unnamed6.Write(bw);
        _distanceToWaterPlane.Write(bw);
        _color.Write(bw);
        _flags2.Write(bw);
        _layerCount.Write(bw);
        _distanceGradient.Write(bw);
        _densityGradient.Write(bw);
        _startDistanceFromFogPlane.Write(bw);
        _unnamed7.Write(bw);
        _color2.Write(bw);
        _rotationMultiplier.Write(bw);
        _strafingMultiplier.Write(bw);
        _zoomMultiplier.Write(bw);
        _unnamed8.Write(bw);
        _mapScale.Write(bw);
        _map.Write(bw);
        _animationPeriod.Write(bw);
        _unnamed9.Write(bw);
        _windVelocity.Write(bw);
        _windPeriod.Write(bw);
        _windAccelerationWeight.Write(bw);
        _windPerpendicularWeight.Write(bw);
        _unnamed10.Write(bw);
        _backgroundSound.Write(bw);
        _soundEnvironment.Write(bw);
        _unnamed11.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _map.WriteString(writer);
        _backgroundSound.WriteString(writer);
        _soundEnvironment.WriteString(writer);
      }
    }
  }
}
