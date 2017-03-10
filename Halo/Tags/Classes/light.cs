// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'light'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class light : Interfaces.Pool.Tag {
    private LightBlock lightValues = new LightBlock();
    public virtual LightBlock LightValues {
      get {
        return lightValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LightValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "light";
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
lightValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lightValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lightValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lightValues.WriteChildData(writer);
    }
    #endregion
    public class LightBlock : IBlock {
      private Flags _flags;
      private Real _radius = new Real();
      private RealBounds _radiusModifer = new RealBounds();
      private Angle _falloffAngle = new Angle();
      private Angle _cutoffAngle = new Angle();
      private Real _lensFlareOnlyRadius = new Real();
      private Pad _unnamed;
      private Flags _interpolationFlags;
      private RealARGBColor _colorLowerBound = new RealARGBColor();
      private RealARGBColor _colorUpperBound = new RealARGBColor();
      private Pad _unnamed2;
      private TagReference _primaryCubeMap = new TagReference();
      private Pad _unnamed3;
      private Enum _textureAnimationFunction = new Enum();
      private Real _textureAnimationPeriod = new Real();
      private TagReference _secondaryCubeMap = new TagReference();
      private Pad _unnamed4;
      private Enum _yawFunction = new Enum();
      private Real _yawPeriod = new Real();
      private Pad _unnamed5;
      private Enum _rollFunction = new Enum();
      private Real _rollPeriod = new Real();
      private Pad _unnamed6;
      private Enum _pitchFunction = new Enum();
      private Real _pitchPeriod = new Real();
      private Pad _unnamed7;
      private TagReference _lensFlare = new TagReference();
      private Pad _unnamed8;
      private Real _intensity = new Real();
      private RealRGBColor _color = new RealRGBColor();
      private Pad _unnamed9;
      private Real _duration = new Real();
      private Pad _unnamed10;
      private Enum _falloffFunction = new Enum();
      private Pad _unnamed11;
      private Pad _unnamed12;
public event System.EventHandler BlockNameChanged;
      public LightBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(24);
        this._interpolationFlags = new Flags(4);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(24);
        this._unnamed9 = new Pad(16);
        this._unnamed10 = new Pad(2);
        this._unnamed11 = new Pad(8);
        this._unnamed12 = new Pad(92);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_primaryCubeMap.Value);
references.Add(_secondaryCubeMap.Value);
references.Add(_lensFlare.Value);
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
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealBounds RadiusModifer {
        get {
          return this._radiusModifer;
        }
        set {
          this._radiusModifer = value;
        }
      }
      public Angle FalloffAngle {
        get {
          return this._falloffAngle;
        }
        set {
          this._falloffAngle = value;
        }
      }
      public Angle CutoffAngle {
        get {
          return this._cutoffAngle;
        }
        set {
          this._cutoffAngle = value;
        }
      }
      public Real LensFlareOnlyRadius {
        get {
          return this._lensFlareOnlyRadius;
        }
        set {
          this._lensFlareOnlyRadius = value;
        }
      }
      public Flags InterpolationFlags {
        get {
          return this._interpolationFlags;
        }
        set {
          this._interpolationFlags = value;
        }
      }
      public RealARGBColor ColorLowerBound {
        get {
          return this._colorLowerBound;
        }
        set {
          this._colorLowerBound = value;
        }
      }
      public RealARGBColor ColorUpperBound {
        get {
          return this._colorUpperBound;
        }
        set {
          this._colorUpperBound = value;
        }
      }
      public TagReference PrimaryCubeMap {
        get {
          return this._primaryCubeMap;
        }
        set {
          this._primaryCubeMap = value;
        }
      }
      public Enum TextureAnimationFunction {
        get {
          return this._textureAnimationFunction;
        }
        set {
          this._textureAnimationFunction = value;
        }
      }
      public Real TextureAnimationPeriod {
        get {
          return this._textureAnimationPeriod;
        }
        set {
          this._textureAnimationPeriod = value;
        }
      }
      public TagReference SecondaryCubeMap {
        get {
          return this._secondaryCubeMap;
        }
        set {
          this._secondaryCubeMap = value;
        }
      }
      public Enum YawFunction {
        get {
          return this._yawFunction;
        }
        set {
          this._yawFunction = value;
        }
      }
      public Real YawPeriod {
        get {
          return this._yawPeriod;
        }
        set {
          this._yawPeriod = value;
        }
      }
      public Enum RollFunction {
        get {
          return this._rollFunction;
        }
        set {
          this._rollFunction = value;
        }
      }
      public Real RollPeriod {
        get {
          return this._rollPeriod;
        }
        set {
          this._rollPeriod = value;
        }
      }
      public Enum PitchFunction {
        get {
          return this._pitchFunction;
        }
        set {
          this._pitchFunction = value;
        }
      }
      public Real PitchPeriod {
        get {
          return this._pitchPeriod;
        }
        set {
          this._pitchPeriod = value;
        }
      }
      public TagReference LensFlare {
        get {
          return this._lensFlare;
        }
        set {
          this._lensFlare = value;
        }
      }
      public Real Intensity {
        get {
          return this._intensity;
        }
        set {
          this._intensity = value;
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
      public Real Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public Enum FalloffFunction {
        get {
          return this._falloffFunction;
        }
        set {
          this._falloffFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _radius.Read(reader);
        _radiusModifer.Read(reader);
        _falloffAngle.Read(reader);
        _cutoffAngle.Read(reader);
        _lensFlareOnlyRadius.Read(reader);
        _unnamed.Read(reader);
        _interpolationFlags.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _unnamed2.Read(reader);
        _primaryCubeMap.Read(reader);
        _unnamed3.Read(reader);
        _textureAnimationFunction.Read(reader);
        _textureAnimationPeriod.Read(reader);
        _secondaryCubeMap.Read(reader);
        _unnamed4.Read(reader);
        _yawFunction.Read(reader);
        _yawPeriod.Read(reader);
        _unnamed5.Read(reader);
        _rollFunction.Read(reader);
        _rollPeriod.Read(reader);
        _unnamed6.Read(reader);
        _pitchFunction.Read(reader);
        _pitchPeriod.Read(reader);
        _unnamed7.Read(reader);
        _lensFlare.Read(reader);
        _unnamed8.Read(reader);
        _intensity.Read(reader);
        _color.Read(reader);
        _unnamed9.Read(reader);
        _duration.Read(reader);
        _unnamed10.Read(reader);
        _falloffFunction.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _primaryCubeMap.ReadString(reader);
        _secondaryCubeMap.ReadString(reader);
        _lensFlare.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _radius.Write(bw);
        _radiusModifer.Write(bw);
        _falloffAngle.Write(bw);
        _cutoffAngle.Write(bw);
        _lensFlareOnlyRadius.Write(bw);
        _unnamed.Write(bw);
        _interpolationFlags.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _unnamed2.Write(bw);
        _primaryCubeMap.Write(bw);
        _unnamed3.Write(bw);
        _textureAnimationFunction.Write(bw);
        _textureAnimationPeriod.Write(bw);
        _secondaryCubeMap.Write(bw);
        _unnamed4.Write(bw);
        _yawFunction.Write(bw);
        _yawPeriod.Write(bw);
        _unnamed5.Write(bw);
        _rollFunction.Write(bw);
        _rollPeriod.Write(bw);
        _unnamed6.Write(bw);
        _pitchFunction.Write(bw);
        _pitchPeriod.Write(bw);
        _unnamed7.Write(bw);
        _lensFlare.Write(bw);
        _unnamed8.Write(bw);
        _intensity.Write(bw);
        _color.Write(bw);
        _unnamed9.Write(bw);
        _duration.Write(bw);
        _unnamed10.Write(bw);
        _falloffFunction.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _primaryCubeMap.WriteString(writer);
        _secondaryCubeMap.WriteString(writer);
        _lensFlare.WriteString(writer);
      }
    }
  }
}
