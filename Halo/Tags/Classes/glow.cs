// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'glow'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class glow : Interfaces.Pool.Tag {
    private GlowBlock glowValues = new GlowBlock();
    public virtual GlowBlock GlowValues {
      get {
        return glowValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(GlowValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "glow";
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
glowValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
glowValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
glowValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
glowValues.WriteChildData(writer);
    }
    #endregion
    public class GlowBlock : IBlock {
      private FixedLengthString _attachmentMarker = new FixedLengthString();
      private ShortInteger _numberOfParticles = new ShortInteger();
      private Enum _boundaryEffect = new Enum();
      private Enum _normalParticleDistribution = new Enum();
      private Enum _trailingParticleDistribution = new Enum();
      private Flags _glowFlags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Enum _attachment = new Enum();
      private Pad _unnamed5;
      private Real _particleRotationalVelocity = new Real();
      private Real _particleRotVelMulLow = new Real();
      private Real _particleRotVelMulHigh = new Real();
      private Enum _attachment2 = new Enum();
      private Pad _unnamed6;
      private Real _effectRotationalVelocity = new Real();
      private Real _effectRotVelMulLow = new Real();
      private Real _effectRotVelMulHigh = new Real();
      private Enum _attachment3 = new Enum();
      private Pad _unnamed7;
      private Real _effectTranslationalVelocity = new Real();
      private Real _effectTransVelMulLow = new Real();
      private Real _effectTransVelMulHigh = new Real();
      private Enum _attachment4 = new Enum();
      private Pad _unnamed8;
      private Real _minDistanceParticleToObject = new Real();
      private Real _maxDistanceParticleToObject = new Real();
      private Real _distanceToObjectMulLow = new Real();
      private Real _distanceToObjectMulHigh = new Real();
      private Pad _unnamed9;
      private Enum _attachment5 = new Enum();
      private Pad _unnamed10;
      private RealBounds _particleSizeBounds = new RealBounds();
      private RealBounds _sizeAttachmentMultiplier = new RealBounds();
      private Enum _attachment6 = new Enum();
      private Pad _unnamed11;
      private RealARGBColor _colorbound0 = new RealARGBColor();
      private RealARGBColor _colorbound1 = new RealARGBColor();
      private RealARGBColor _scaleColor0 = new RealARGBColor();
      private RealARGBColor _scaleColor1 = new RealARGBColor();
      private Real _colorRateOfChange = new Real();
      private Real _fadingPercentageOfGlow = new Real();
      private Real _particleGenerationFreq = new Real();
      private Real _lifetimeOfTrailingParticles = new Real();
      private Real _velocityOfTrailingParticles = new Real();
      private Real _trailingParticleMinimumT = new Real();
      private Real _trailingParticleMaximumT = new Real();
      private Pad _unnamed12;
      private TagReference _texture = new TagReference();
public event System.EventHandler BlockNameChanged;
      public GlowBlock() {
        this._glowFlags = new Flags(4);
        this._unnamed = new Pad(28);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(2);
        this._unnamed11 = new Pad(2);
        this._unnamed12 = new Pad(52);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_texture.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public FixedLengthString AttachmentMarker {
        get {
          return this._attachmentMarker;
        }
        set {
          this._attachmentMarker = value;
        }
      }
      public ShortInteger NumberOfParticles {
        get {
          return this._numberOfParticles;
        }
        set {
          this._numberOfParticles = value;
        }
      }
      public Enum BoundaryEffect {
        get {
          return this._boundaryEffect;
        }
        set {
          this._boundaryEffect = value;
        }
      }
      public Enum NormalParticleDistribution {
        get {
          return this._normalParticleDistribution;
        }
        set {
          this._normalParticleDistribution = value;
        }
      }
      public Enum TrailingParticleDistribution {
        get {
          return this._trailingParticleDistribution;
        }
        set {
          this._trailingParticleDistribution = value;
        }
      }
      public Flags GlowFlags {
        get {
          return this._glowFlags;
        }
        set {
          this._glowFlags = value;
        }
      }
      public Enum Attachment {
        get {
          return this._attachment;
        }
        set {
          this._attachment = value;
        }
      }
      public Real ParticleRotationalVelocity {
        get {
          return this._particleRotationalVelocity;
        }
        set {
          this._particleRotationalVelocity = value;
        }
      }
      public Real ParticleRotVelMulLow {
        get {
          return this._particleRotVelMulLow;
        }
        set {
          this._particleRotVelMulLow = value;
        }
      }
      public Real ParticleRotVelMulHigh {
        get {
          return this._particleRotVelMulHigh;
        }
        set {
          this._particleRotVelMulHigh = value;
        }
      }
      public Enum Attachment2 {
        get {
          return this._attachment2;
        }
        set {
          this._attachment2 = value;
        }
      }
      public Real EffectRotationalVelocity {
        get {
          return this._effectRotationalVelocity;
        }
        set {
          this._effectRotationalVelocity = value;
        }
      }
      public Real EffectRotVelMulLow {
        get {
          return this._effectRotVelMulLow;
        }
        set {
          this._effectRotVelMulLow = value;
        }
      }
      public Real EffectRotVelMulHigh {
        get {
          return this._effectRotVelMulHigh;
        }
        set {
          this._effectRotVelMulHigh = value;
        }
      }
      public Enum Attachment3 {
        get {
          return this._attachment3;
        }
        set {
          this._attachment3 = value;
        }
      }
      public Real EffectTranslationalVelocity {
        get {
          return this._effectTranslationalVelocity;
        }
        set {
          this._effectTranslationalVelocity = value;
        }
      }
      public Real EffectTransVelMulLow {
        get {
          return this._effectTransVelMulLow;
        }
        set {
          this._effectTransVelMulLow = value;
        }
      }
      public Real EffectTransVelMulHigh {
        get {
          return this._effectTransVelMulHigh;
        }
        set {
          this._effectTransVelMulHigh = value;
        }
      }
      public Enum Attachment4 {
        get {
          return this._attachment4;
        }
        set {
          this._attachment4 = value;
        }
      }
      public Real MinDistanceParticleToObject {
        get {
          return this._minDistanceParticleToObject;
        }
        set {
          this._minDistanceParticleToObject = value;
        }
      }
      public Real MaxDistanceParticleToObject {
        get {
          return this._maxDistanceParticleToObject;
        }
        set {
          this._maxDistanceParticleToObject = value;
        }
      }
      public Real DistanceToObjectMulLow {
        get {
          return this._distanceToObjectMulLow;
        }
        set {
          this._distanceToObjectMulLow = value;
        }
      }
      public Real DistanceToObjectMulHigh {
        get {
          return this._distanceToObjectMulHigh;
        }
        set {
          this._distanceToObjectMulHigh = value;
        }
      }
      public Enum Attachment5 {
        get {
          return this._attachment5;
        }
        set {
          this._attachment5 = value;
        }
      }
      public RealBounds ParticleSizeBounds {
        get {
          return this._particleSizeBounds;
        }
        set {
          this._particleSizeBounds = value;
        }
      }
      public RealBounds SizeAttachmentMultiplier {
        get {
          return this._sizeAttachmentMultiplier;
        }
        set {
          this._sizeAttachmentMultiplier = value;
        }
      }
      public Enum Attachment6 {
        get {
          return this._attachment6;
        }
        set {
          this._attachment6 = value;
        }
      }
      public RealARGBColor Colorbound0 {
        get {
          return this._colorbound0;
        }
        set {
          this._colorbound0 = value;
        }
      }
      public RealARGBColor Colorbound1 {
        get {
          return this._colorbound1;
        }
        set {
          this._colorbound1 = value;
        }
      }
      public RealARGBColor ScaleColor0 {
        get {
          return this._scaleColor0;
        }
        set {
          this._scaleColor0 = value;
        }
      }
      public RealARGBColor ScaleColor1 {
        get {
          return this._scaleColor1;
        }
        set {
          this._scaleColor1 = value;
        }
      }
      public Real ColorRateOfChange {
        get {
          return this._colorRateOfChange;
        }
        set {
          this._colorRateOfChange = value;
        }
      }
      public Real FadingPercentageOfGlow {
        get {
          return this._fadingPercentageOfGlow;
        }
        set {
          this._fadingPercentageOfGlow = value;
        }
      }
      public Real ParticleGenerationFreq {
        get {
          return this._particleGenerationFreq;
        }
        set {
          this._particleGenerationFreq = value;
        }
      }
      public Real LifetimeOfTrailingParticles {
        get {
          return this._lifetimeOfTrailingParticles;
        }
        set {
          this._lifetimeOfTrailingParticles = value;
        }
      }
      public Real VelocityOfTrailingParticles {
        get {
          return this._velocityOfTrailingParticles;
        }
        set {
          this._velocityOfTrailingParticles = value;
        }
      }
      public Real TrailingParticleMinimumT {
        get {
          return this._trailingParticleMinimumT;
        }
        set {
          this._trailingParticleMinimumT = value;
        }
      }
      public Real TrailingParticleMaximumT {
        get {
          return this._trailingParticleMaximumT;
        }
        set {
          this._trailingParticleMaximumT = value;
        }
      }
      public TagReference Texture {
        get {
          return this._texture;
        }
        set {
          this._texture = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _attachmentMarker.Read(reader);
        _numberOfParticles.Read(reader);
        _boundaryEffect.Read(reader);
        _normalParticleDistribution.Read(reader);
        _trailingParticleDistribution.Read(reader);
        _glowFlags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _attachment.Read(reader);
        _unnamed5.Read(reader);
        _particleRotationalVelocity.Read(reader);
        _particleRotVelMulLow.Read(reader);
        _particleRotVelMulHigh.Read(reader);
        _attachment2.Read(reader);
        _unnamed6.Read(reader);
        _effectRotationalVelocity.Read(reader);
        _effectRotVelMulLow.Read(reader);
        _effectRotVelMulHigh.Read(reader);
        _attachment3.Read(reader);
        _unnamed7.Read(reader);
        _effectTranslationalVelocity.Read(reader);
        _effectTransVelMulLow.Read(reader);
        _effectTransVelMulHigh.Read(reader);
        _attachment4.Read(reader);
        _unnamed8.Read(reader);
        _minDistanceParticleToObject.Read(reader);
        _maxDistanceParticleToObject.Read(reader);
        _distanceToObjectMulLow.Read(reader);
        _distanceToObjectMulHigh.Read(reader);
        _unnamed9.Read(reader);
        _attachment5.Read(reader);
        _unnamed10.Read(reader);
        _particleSizeBounds.Read(reader);
        _sizeAttachmentMultiplier.Read(reader);
        _attachment6.Read(reader);
        _unnamed11.Read(reader);
        _colorbound0.Read(reader);
        _colorbound1.Read(reader);
        _scaleColor0.Read(reader);
        _scaleColor1.Read(reader);
        _colorRateOfChange.Read(reader);
        _fadingPercentageOfGlow.Read(reader);
        _particleGenerationFreq.Read(reader);
        _lifetimeOfTrailingParticles.Read(reader);
        _velocityOfTrailingParticles.Read(reader);
        _trailingParticleMinimumT.Read(reader);
        _trailingParticleMaximumT.Read(reader);
        _unnamed12.Read(reader);
        _texture.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _texture.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _attachmentMarker.Write(bw);
        _numberOfParticles.Write(bw);
        _boundaryEffect.Write(bw);
        _normalParticleDistribution.Write(bw);
        _trailingParticleDistribution.Write(bw);
        _glowFlags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _attachment.Write(bw);
        _unnamed5.Write(bw);
        _particleRotationalVelocity.Write(bw);
        _particleRotVelMulLow.Write(bw);
        _particleRotVelMulHigh.Write(bw);
        _attachment2.Write(bw);
        _unnamed6.Write(bw);
        _effectRotationalVelocity.Write(bw);
        _effectRotVelMulLow.Write(bw);
        _effectRotVelMulHigh.Write(bw);
        _attachment3.Write(bw);
        _unnamed7.Write(bw);
        _effectTranslationalVelocity.Write(bw);
        _effectTransVelMulLow.Write(bw);
        _effectTransVelMulHigh.Write(bw);
        _attachment4.Write(bw);
        _unnamed8.Write(bw);
        _minDistanceParticleToObject.Write(bw);
        _maxDistanceParticleToObject.Write(bw);
        _distanceToObjectMulLow.Write(bw);
        _distanceToObjectMulHigh.Write(bw);
        _unnamed9.Write(bw);
        _attachment5.Write(bw);
        _unnamed10.Write(bw);
        _particleSizeBounds.Write(bw);
        _sizeAttachmentMultiplier.Write(bw);
        _attachment6.Write(bw);
        _unnamed11.Write(bw);
        _colorbound0.Write(bw);
        _colorbound1.Write(bw);
        _scaleColor0.Write(bw);
        _scaleColor1.Write(bw);
        _colorRateOfChange.Write(bw);
        _fadingPercentageOfGlow.Write(bw);
        _particleGenerationFreq.Write(bw);
        _lifetimeOfTrailingParticles.Write(bw);
        _velocityOfTrailingParticles.Write(bw);
        _trailingParticleMinimumT.Write(bw);
        _trailingParticleMaximumT.Write(bw);
        _unnamed12.Write(bw);
        _texture.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _texture.WriteString(writer);
      }
    }
  }
}
