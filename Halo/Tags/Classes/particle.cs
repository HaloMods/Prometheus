// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'particle'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class particle : Interfaces.Pool.Tag {
    private ParticleBlock particleValues = new ParticleBlock();
    public virtual ParticleBlock ParticleValues {
      get {
        return particleValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ParticleValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "particle";
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
particleValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
particleValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
particleValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
particleValues.WriteChildData(writer);
    }
    #endregion
    public class ParticleBlock : IBlock {
      private Flags _flags;
      private TagReference _bitmap = new TagReference();
      private TagReference _physics = new TagReference();
      private TagReference _martyTradedHisKidsForThis = new TagReference();
      private Pad _unnamed;
      private RealBounds _lifespan = new RealBounds();
      private Real _fadeInTime = new Real();
      private Real _fadeOutTime = new Real();
      private TagReference _collisionEffect = new TagReference();
      private TagReference _deathEffect = new TagReference();
      private Real _minimumSize = new Real();
      private Pad _unnamed2;
      private RealBounds _radiusAnimation = new RealBounds();
      private Pad _unnamed3;
      private RealBounds _animationRate = new RealBounds();
      private Real _contactDeterioration = new Real();
      private Real _fadeStartSize = new Real();
      private Real _fadeEndSize = new Real();
      private Pad _unnamed4;
      private ShortInteger _firstSequenceIndex = new ShortInteger();
      private ShortInteger _initialSequenceCount = new ShortInteger();
      private ShortInteger _loopingSequenceCount = new ShortInteger();
      private ShortInteger _finalSequenceCount = new ShortInteger();
      private Pad _unnamed5;
      private Enum _orientation = new Enum();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Flags _mapFlags;
      private Pad _unnamed8;
      private TagReference _bitmap2 = new TagReference();
      private Enum _anchor = new Enum();
      private Flags _flags2;
      private Enum _unnamed9 = new Enum();
      private Enum _unnamed10 = new Enum();
      private Real _unnamed11 = new Real();
      private Real _unnamed12 = new Real();
      private Real _unnamed13 = new Real();
      private Enum _unnamed14 = new Enum();
      private Enum _unnamed15 = new Enum();
      private Real _unnamed16 = new Real();
      private Real _unnamed17 = new Real();
      private Real _unnamed18 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
      private Pad _unnamed19;
      private Real _zspriteRadiusScale = new Real();
      private Pad _unnamed20;
public event System.EventHandler BlockNameChanged;
      public ParticleBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(12);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._mapFlags = new Flags(2);
        this._unnamed8 = new Pad(28);
        this._flags2 = new Flags(2);
        this._unnamed19 = new Pad(4);
        this._unnamed20 = new Pad(20);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_physics.Value);
references.Add(_martyTradedHisKidsForThis.Value);
references.Add(_collisionEffect.Value);
references.Add(_deathEffect.Value);
references.Add(_bitmap2.Value);
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
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public TagReference Physics {
        get {
          return this._physics;
        }
        set {
          this._physics = value;
        }
      }
      public TagReference MartyTradedHisKidsForThis {
        get {
          return this._martyTradedHisKidsForThis;
        }
        set {
          this._martyTradedHisKidsForThis = value;
        }
      }
      public RealBounds Lifespan {
        get {
          return this._lifespan;
        }
        set {
          this._lifespan = value;
        }
      }
      public Real FadeInTime {
        get {
          return this._fadeInTime;
        }
        set {
          this._fadeInTime = value;
        }
      }
      public Real FadeOutTime {
        get {
          return this._fadeOutTime;
        }
        set {
          this._fadeOutTime = value;
        }
      }
      public TagReference CollisionEffect {
        get {
          return this._collisionEffect;
        }
        set {
          this._collisionEffect = value;
        }
      }
      public TagReference DeathEffect {
        get {
          return this._deathEffect;
        }
        set {
          this._deathEffect = value;
        }
      }
      public Real MinimumSize {
        get {
          return this._minimumSize;
        }
        set {
          this._minimumSize = value;
        }
      }
      public RealBounds RadiusAnimation {
        get {
          return this._radiusAnimation;
        }
        set {
          this._radiusAnimation = value;
        }
      }
      public RealBounds AnimationRate {
        get {
          return this._animationRate;
        }
        set {
          this._animationRate = value;
        }
      }
      public Real ContactDeterioration {
        get {
          return this._contactDeterioration;
        }
        set {
          this._contactDeterioration = value;
        }
      }
      public Real FadeStartSize {
        get {
          return this._fadeStartSize;
        }
        set {
          this._fadeStartSize = value;
        }
      }
      public Real FadeEndSize {
        get {
          return this._fadeEndSize;
        }
        set {
          this._fadeEndSize = value;
        }
      }
      public ShortInteger FirstSequenceIndex {
        get {
          return this._firstSequenceIndex;
        }
        set {
          this._firstSequenceIndex = value;
        }
      }
      public ShortInteger InitialSequenceCount {
        get {
          return this._initialSequenceCount;
        }
        set {
          this._initialSequenceCount = value;
        }
      }
      public ShortInteger LoopingSequenceCount {
        get {
          return this._loopingSequenceCount;
        }
        set {
          this._loopingSequenceCount = value;
        }
      }
      public ShortInteger FinalSequenceCount {
        get {
          return this._finalSequenceCount;
        }
        set {
          this._finalSequenceCount = value;
        }
      }
      public Enum Orientation {
        get {
          return this._orientation;
        }
        set {
          this._orientation = value;
        }
      }
      public Flags ShaderFlags {
        get {
          return this._shaderFlags;
        }
        set {
          this._shaderFlags = value;
        }
      }
      public Enum FramebufferBlendFunction {
        get {
          return this._framebufferBlendFunction;
        }
        set {
          this._framebufferBlendFunction = value;
        }
      }
      public Enum FramebufferFadeMode {
        get {
          return this._framebufferFadeMode;
        }
        set {
          this._framebufferFadeMode = value;
        }
      }
      public Flags MapFlags {
        get {
          return this._mapFlags;
        }
        set {
          this._mapFlags = value;
        }
      }
      public TagReference Bitmap2 {
        get {
          return this._bitmap2;
        }
        set {
          this._bitmap2 = value;
        }
      }
      public Enum Anchor {
        get {
          return this._anchor;
        }
        set {
          this._anchor = value;
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
      public Enum unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public Enum unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public Real unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Real unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public Real unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public Enum unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
        }
      }
      public Enum unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public Real unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
        }
      }
      public Real unnamed17 {
        get {
          return this._unnamed17;
        }
        set {
          this._unnamed17 = value;
        }
      }
      public Real unnamed18 {
        get {
          return this._unnamed18;
        }
        set {
          this._unnamed18 = value;
        }
      }
      public Enum Rotatio {
        get {
          return this._rotatio;
        }
        set {
          this._rotatio = value;
        }
      }
      public Enum Rotatio2 {
        get {
          return this._rotatio2;
        }
        set {
          this._rotatio2 = value;
        }
      }
      public Real Rotatio3 {
        get {
          return this._rotatio3;
        }
        set {
          this._rotatio3 = value;
        }
      }
      public Real Rotatio4 {
        get {
          return this._rotatio4;
        }
        set {
          this._rotatio4 = value;
        }
      }
      public Real Rotatio5 {
        get {
          return this._rotatio5;
        }
        set {
          this._rotatio5 = value;
        }
      }
      public RealPoint2D Rotatio6 {
        get {
          return this._rotatio6;
        }
        set {
          this._rotatio6 = value;
        }
      }
      public Real ZspriteRadiusScale {
        get {
          return this._zspriteRadiusScale;
        }
        set {
          this._zspriteRadiusScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bitmap.Read(reader);
        _physics.Read(reader);
        _martyTradedHisKidsForThis.Read(reader);
        _unnamed.Read(reader);
        _lifespan.Read(reader);
        _fadeInTime.Read(reader);
        _fadeOutTime.Read(reader);
        _collisionEffect.Read(reader);
        _deathEffect.Read(reader);
        _minimumSize.Read(reader);
        _unnamed2.Read(reader);
        _radiusAnimation.Read(reader);
        _unnamed3.Read(reader);
        _animationRate.Read(reader);
        _contactDeterioration.Read(reader);
        _fadeStartSize.Read(reader);
        _fadeEndSize.Read(reader);
        _unnamed4.Read(reader);
        _firstSequenceIndex.Read(reader);
        _initialSequenceCount.Read(reader);
        _loopingSequenceCount.Read(reader);
        _finalSequenceCount.Read(reader);
        _unnamed5.Read(reader);
        _orientation.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed8.Read(reader);
        _bitmap2.Read(reader);
        _anchor.Read(reader);
        _flags2.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
        _unnamed19.Read(reader);
        _zspriteRadiusScale.Read(reader);
        _unnamed20.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
        _physics.ReadString(reader);
        _martyTradedHisKidsForThis.ReadString(reader);
        _collisionEffect.ReadString(reader);
        _deathEffect.ReadString(reader);
        _bitmap2.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bitmap.Write(bw);
        _physics.Write(bw);
        _martyTradedHisKidsForThis.Write(bw);
        _unnamed.Write(bw);
        _lifespan.Write(bw);
        _fadeInTime.Write(bw);
        _fadeOutTime.Write(bw);
        _collisionEffect.Write(bw);
        _deathEffect.Write(bw);
        _minimumSize.Write(bw);
        _unnamed2.Write(bw);
        _radiusAnimation.Write(bw);
        _unnamed3.Write(bw);
        _animationRate.Write(bw);
        _contactDeterioration.Write(bw);
        _fadeStartSize.Write(bw);
        _fadeEndSize.Write(bw);
        _unnamed4.Write(bw);
        _firstSequenceIndex.Write(bw);
        _initialSequenceCount.Write(bw);
        _loopingSequenceCount.Write(bw);
        _finalSequenceCount.Write(bw);
        _unnamed5.Write(bw);
        _orientation.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed8.Write(bw);
        _bitmap2.Write(bw);
        _anchor.Write(bw);
        _flags2.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
        _unnamed19.Write(bw);
        _zspriteRadiusScale.Write(bw);
        _unnamed20.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
        _physics.WriteString(writer);
        _martyTradedHisKidsForThis.WriteString(writer);
        _collisionEffect.WriteString(writer);
        _deathEffect.WriteString(writer);
        _bitmap2.WriteString(writer);
      }
    }
  }
}
