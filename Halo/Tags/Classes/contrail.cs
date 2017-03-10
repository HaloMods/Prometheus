// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'contrail'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class contrail : Interfaces.Pool.Tag {
    private ContrailBlock contrailValues = new ContrailBlock();
    public virtual ContrailBlock ContrailValues {
      get {
        return contrailValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ContrailValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "contrail";
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
contrailValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
contrailValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
contrailValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
contrailValues.WriteChildData(writer);
    }
    #endregion
    public class ContrailBlock : IBlock {
      private Flags _flags;
      private Flags _scaleFlags;
      private Real _pointGenerationRate = new Real();
      private RealBounds _pointVelocity = new RealBounds();
      private Angle _pointVelocityConeAngle = new Angle();
      private RealFraction _inheritedVelocityFraction = new RealFraction();
      private Enum _renderType = new Enum();
      private Pad _unnamed;
      private Real _textureRepeatsU = new Real();
      private Real _textureRepeatsV = new Real();
      private Real _textureAnimationU = new Real();
      private Real _textureAnimationV = new Real();
      private Real _animationRate = new Real();
      private TagReference _bitmap = new TagReference();
      private ShortInteger _firstSequenceIndex = new ShortInteger();
      private ShortInteger _sequenceCount = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Flags _mapFlags;
      private Pad _unnamed4;
      private TagReference _bitmap2 = new TagReference();
      private Enum _anchor = new Enum();
      private Flags _flags2;
      private Enum _unnamed5 = new Enum();
      private Enum _unnamed6 = new Enum();
      private Real _unnamed7 = new Real();
      private Real _unnamed8 = new Real();
      private Real _unnamed9 = new Real();
      private Enum _unnamed10 = new Enum();
      private Enum _unnamed11 = new Enum();
      private Real _unnamed12 = new Real();
      private Real _unnamed13 = new Real();
      private Real _unnamed14 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
      private Pad _unnamed15;
      private Real _zspriteRadiusScale = new Real();
      private Pad _unnamed16;
      private Block _pointStates = new Block();
      public BlockCollection<ContrailPointStatesBlock> _pointStatesList = new BlockCollection<ContrailPointStatesBlock>();
public event System.EventHandler BlockNameChanged;
      public ContrailBlock() {
        this._flags = new Flags(2);
        this._scaleFlags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(64);
        this._unnamed3 = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._mapFlags = new Flags(2);
        this._unnamed4 = new Pad(28);
        this._flags2 = new Flags(2);
        this._unnamed15 = new Pad(4);
        this._unnamed16 = new Pad(20);
      }
      public BlockCollection<ContrailPointStatesBlock> PointStates {
        get {
          return this._pointStatesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_bitmap2.Value);
for (int x=0; x<PointStates.BlockCount; x++)
{
  IBlock block = PointStates.GetBlock(x);
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
      public Flags ScaleFlags {
        get {
          return this._scaleFlags;
        }
        set {
          this._scaleFlags = value;
        }
      }
      public Real PointGenerationRate {
        get {
          return this._pointGenerationRate;
        }
        set {
          this._pointGenerationRate = value;
        }
      }
      public RealBounds PointVelocity {
        get {
          return this._pointVelocity;
        }
        set {
          this._pointVelocity = value;
        }
      }
      public Angle PointVelocityConeAngle {
        get {
          return this._pointVelocityConeAngle;
        }
        set {
          this._pointVelocityConeAngle = value;
        }
      }
      public RealFraction InheritedVelocityFraction {
        get {
          return this._inheritedVelocityFraction;
        }
        set {
          this._inheritedVelocityFraction = value;
        }
      }
      public Enum RenderType {
        get {
          return this._renderType;
        }
        set {
          this._renderType = value;
        }
      }
      public Real TextureRepeatsU {
        get {
          return this._textureRepeatsU;
        }
        set {
          this._textureRepeatsU = value;
        }
      }
      public Real TextureRepeatsV {
        get {
          return this._textureRepeatsV;
        }
        set {
          this._textureRepeatsV = value;
        }
      }
      public Real TextureAnimationU {
        get {
          return this._textureAnimationU;
        }
        set {
          this._textureAnimationU = value;
        }
      }
      public Real TextureAnimationV {
        get {
          return this._textureAnimationV;
        }
        set {
          this._textureAnimationV = value;
        }
      }
      public Real AnimationRate {
        get {
          return this._animationRate;
        }
        set {
          this._animationRate = value;
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
      public ShortInteger FirstSequenceIndex {
        get {
          return this._firstSequenceIndex;
        }
        set {
          this._firstSequenceIndex = value;
        }
      }
      public ShortInteger SequenceCount {
        get {
          return this._sequenceCount;
        }
        set {
          this._sequenceCount = value;
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
      public Enum unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public Enum unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public Real unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public Real unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public Real unnamed9 {
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
      public Enum unnamed11 {
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
      public Real unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
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
        _scaleFlags.Read(reader);
        _pointGenerationRate.Read(reader);
        _pointVelocity.Read(reader);
        _pointVelocityConeAngle.Read(reader);
        _inheritedVelocityFraction.Read(reader);
        _renderType.Read(reader);
        _unnamed.Read(reader);
        _textureRepeatsU.Read(reader);
        _textureRepeatsV.Read(reader);
        _textureAnimationU.Read(reader);
        _textureAnimationV.Read(reader);
        _animationRate.Read(reader);
        _bitmap.Read(reader);
        _firstSequenceIndex.Read(reader);
        _sequenceCount.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed4.Read(reader);
        _bitmap2.Read(reader);
        _anchor.Read(reader);
        _flags2.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
        _unnamed15.Read(reader);
        _zspriteRadiusScale.Read(reader);
        _unnamed16.Read(reader);
        _pointStates.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmap.ReadString(reader);
        _bitmap2.ReadString(reader);
        for (x = 0; (x < _pointStates.Count); x = (x + 1)) {
          PointStates.Add(new ContrailPointStatesBlock());
          PointStates[x].Read(reader);
        }
        for (x = 0; (x < _pointStates.Count); x = (x + 1)) {
          PointStates[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _scaleFlags.Write(bw);
        _pointGenerationRate.Write(bw);
        _pointVelocity.Write(bw);
        _pointVelocityConeAngle.Write(bw);
        _inheritedVelocityFraction.Write(bw);
        _renderType.Write(bw);
        _unnamed.Write(bw);
        _textureRepeatsU.Write(bw);
        _textureRepeatsV.Write(bw);
        _textureAnimationU.Write(bw);
        _textureAnimationV.Write(bw);
        _animationRate.Write(bw);
        _bitmap.Write(bw);
        _firstSequenceIndex.Write(bw);
        _sequenceCount.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed4.Write(bw);
        _bitmap2.Write(bw);
        _anchor.Write(bw);
        _flags2.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
        _unnamed15.Write(bw);
        _zspriteRadiusScale.Write(bw);
        _unnamed16.Write(bw);
_pointStates.Count = PointStates.Count;
        _pointStates.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bitmap.WriteString(writer);
        _bitmap2.WriteString(writer);
        for (x = 0; (x < _pointStates.Count); x = (x + 1)) {
          PointStates[x].Write(writer);
        }
        for (x = 0; (x < _pointStates.Count); x = (x + 1)) {
          PointStates[x].WriteChildData(writer);
        }
      }
    }
    public class ContrailPointStatesBlock : IBlock {
      private RealBounds _duration = new RealBounds();
      private RealBounds _transitionDuration = new RealBounds();
      private TagReference _physics = new TagReference();
      private Pad _unnamed;
      private Real _width = new Real();
      private RealARGBColor _colorLowerBound = new RealARGBColor();
      private RealARGBColor _colorUpperBound = new RealARGBColor();
      private Flags _scaleFlags;
public event System.EventHandler BlockNameChanged;
      public ContrailPointStatesBlock() {
        this._unnamed = new Pad(32);
        this._scaleFlags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_physics.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealBounds Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public RealBounds TransitionDuration {
        get {
          return this._transitionDuration;
        }
        set {
          this._transitionDuration = value;
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
      public Real Width {
        get {
          return this._width;
        }
        set {
          this._width = value;
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
      public Flags ScaleFlags {
        get {
          return this._scaleFlags;
        }
        set {
          this._scaleFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _duration.Read(reader);
        _transitionDuration.Read(reader);
        _physics.Read(reader);
        _unnamed.Read(reader);
        _width.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _scaleFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _physics.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _duration.Write(bw);
        _transitionDuration.Write(bw);
        _physics.Write(bw);
        _unnamed.Write(bw);
        _width.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _scaleFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _physics.WriteString(writer);
      }
    }
  }
}
