// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'contrail'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class contrail : Interfaces.Pool.Tag {
    private ContrailBlockBlock contrailValues = new ContrailBlockBlock();
    public virtual ContrailBlockBlock ContrailValues {
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
    public class ContrailBlockBlock : IBlock {
      private Flags _flags;
      private Flags _scaleFlags;
      private Real _pointGenerationRate = new Real();
      private RealBounds _pointVelocity = new RealBounds();
      private Angle _pointVelocityConeAngle = new Angle();
      private RealFraction _inheritedVelocityFraction = new RealFraction();
      private Enum _renderType;
      private Pad _unnamed0;
      private Real _textureRepeatsU = new Real();
      private Real _textureRepeatsV = new Real();
      private Real _textureAnimationU = new Real();
      private Real _textureAnimationV = new Real();
      private Real _animationRate = new Real();
      private TagReference _bitmap = new TagReference();
      private ShortInteger _firstSequenceIndex = new ShortInteger();
      private ShortInteger _sequenceCount = new ShortInteger();
      private Pad _unnamed1;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction;
      private Enum _framebufferFadeMode;
      private Flags _mapFlags;
      private Pad _unnamed2;
      private TagReference _bitmap2 = new TagReference();
      private Enum _anchor;
      private Flags _flags2;
      private Pad _unnamed3;
      private Enum _u_MinusanimationFunction;
      private Real _u_MinusanimationPeriod = new Real();
      private Real _u_MinusanimationPhase = new Real();
      private Real _u_MinusanimationScale = new Real();
      private Pad _unnamed4;
      private Enum _v_MinusanimationFunction;
      private Real _v_MinusanimationPeriod = new Real();
      private Real _v_MinusanimationPhase = new Real();
      private Real _v_MinusanimationScale = new Real();
      private Pad _unnamed5;
      private Enum _rotation_MinusanimationFunction;
      private Real _rotation_MinusanimationPeriod = new Real();
      private Real _rotation_MinusanimationPhase = new Real();
      private Real _rotation_MinusanimationScale = new Real();
      private RealPoint2D _rotation_MinusanimationCenter = new RealPoint2D();
      private Pad _unnamed6;
      private Real _zspriteRadiusScale = new Real();
      private Pad _unnamed7;
      private Block _pointStates = new Block();
      public BlockCollection<ContrailPointStatesBlockBlock> _pointStatesList = new BlockCollection<ContrailPointStatesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ContrailBlockBlock() {
        this._flags = new Flags(2);
        this._scaleFlags = new Flags(2);
        this._renderType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._framebufferBlendFunction = new Enum(2);
        this._framebufferFadeMode = new Enum(2);
        this._mapFlags = new Flags(2);
        this._unnamed2 = new Pad(28);
        this._anchor = new Enum(2);
        this._flags2 = new Flags(2);
        this._unnamed3 = new Pad(2);
        this._u_MinusanimationFunction = new Enum(2);
        this._unnamed4 = new Pad(2);
        this._v_MinusanimationFunction = new Enum(2);
        this._unnamed5 = new Pad(2);
        this._rotation_MinusanimationFunction = new Enum(2);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(20);
      }
      public BlockCollection<ContrailPointStatesBlockBlock> PointStates {
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
      public Enum U_MinusanimationFunction {
        get {
          return this._u_MinusanimationFunction;
        }
        set {
          this._u_MinusanimationFunction = value;
        }
      }
      public Real U_MinusanimationPeriod {
        get {
          return this._u_MinusanimationPeriod;
        }
        set {
          this._u_MinusanimationPeriod = value;
        }
      }
      public Real U_MinusanimationPhase {
        get {
          return this._u_MinusanimationPhase;
        }
        set {
          this._u_MinusanimationPhase = value;
        }
      }
      public Real U_MinusanimationScale {
        get {
          return this._u_MinusanimationScale;
        }
        set {
          this._u_MinusanimationScale = value;
        }
      }
      public Enum V_MinusanimationFunction {
        get {
          return this._v_MinusanimationFunction;
        }
        set {
          this._v_MinusanimationFunction = value;
        }
      }
      public Real V_MinusanimationPeriod {
        get {
          return this._v_MinusanimationPeriod;
        }
        set {
          this._v_MinusanimationPeriod = value;
        }
      }
      public Real V_MinusanimationPhase {
        get {
          return this._v_MinusanimationPhase;
        }
        set {
          this._v_MinusanimationPhase = value;
        }
      }
      public Real V_MinusanimationScale {
        get {
          return this._v_MinusanimationScale;
        }
        set {
          this._v_MinusanimationScale = value;
        }
      }
      public Enum Rotation_MinusanimationFunction {
        get {
          return this._rotation_MinusanimationFunction;
        }
        set {
          this._rotation_MinusanimationFunction = value;
        }
      }
      public Real Rotation_MinusanimationPeriod {
        get {
          return this._rotation_MinusanimationPeriod;
        }
        set {
          this._rotation_MinusanimationPeriod = value;
        }
      }
      public Real Rotation_MinusanimationPhase {
        get {
          return this._rotation_MinusanimationPhase;
        }
        set {
          this._rotation_MinusanimationPhase = value;
        }
      }
      public Real Rotation_MinusanimationScale {
        get {
          return this._rotation_MinusanimationScale;
        }
        set {
          this._rotation_MinusanimationScale = value;
        }
      }
      public RealPoint2D Rotation_MinusanimationCenter {
        get {
          return this._rotation_MinusanimationCenter;
        }
        set {
          this._rotation_MinusanimationCenter = value;
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
        _unnamed0.Read(reader);
        _textureRepeatsU.Read(reader);
        _textureRepeatsV.Read(reader);
        _textureAnimationU.Read(reader);
        _textureAnimationV.Read(reader);
        _animationRate.Read(reader);
        _bitmap.Read(reader);
        _firstSequenceIndex.Read(reader);
        _sequenceCount.Read(reader);
        _unnamed1.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed2.Read(reader);
        _bitmap2.Read(reader);
        _anchor.Read(reader);
        _flags2.Read(reader);
        _unnamed3.Read(reader);
        _u_MinusanimationFunction.Read(reader);
        _u_MinusanimationPeriod.Read(reader);
        _u_MinusanimationPhase.Read(reader);
        _u_MinusanimationScale.Read(reader);
        _unnamed4.Read(reader);
        _v_MinusanimationFunction.Read(reader);
        _v_MinusanimationPeriod.Read(reader);
        _v_MinusanimationPhase.Read(reader);
        _v_MinusanimationScale.Read(reader);
        _unnamed5.Read(reader);
        _rotation_MinusanimationFunction.Read(reader);
        _rotation_MinusanimationPeriod.Read(reader);
        _rotation_MinusanimationPhase.Read(reader);
        _rotation_MinusanimationScale.Read(reader);
        _rotation_MinusanimationCenter.Read(reader);
        _unnamed6.Read(reader);
        _zspriteRadiusScale.Read(reader);
        _unnamed7.Read(reader);
        _pointStates.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmap.ReadString(reader);
        _bitmap2.ReadString(reader);
        for (x = 0; (x < _pointStates.Count); x = (x + 1)) {
          PointStates.Add(new ContrailPointStatesBlockBlock());
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
        _unnamed0.Write(bw);
        _textureRepeatsU.Write(bw);
        _textureRepeatsV.Write(bw);
        _textureAnimationU.Write(bw);
        _textureAnimationV.Write(bw);
        _animationRate.Write(bw);
        _bitmap.Write(bw);
        _firstSequenceIndex.Write(bw);
        _sequenceCount.Write(bw);
        _unnamed1.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed2.Write(bw);
        _bitmap2.Write(bw);
        _anchor.Write(bw);
        _flags2.Write(bw);
        _unnamed3.Write(bw);
        _u_MinusanimationFunction.Write(bw);
        _u_MinusanimationPeriod.Write(bw);
        _u_MinusanimationPhase.Write(bw);
        _u_MinusanimationScale.Write(bw);
        _unnamed4.Write(bw);
        _v_MinusanimationFunction.Write(bw);
        _v_MinusanimationPeriod.Write(bw);
        _v_MinusanimationPhase.Write(bw);
        _v_MinusanimationScale.Write(bw);
        _unnamed5.Write(bw);
        _rotation_MinusanimationFunction.Write(bw);
        _rotation_MinusanimationPeriod.Write(bw);
        _rotation_MinusanimationPhase.Write(bw);
        _rotation_MinusanimationScale.Write(bw);
        _rotation_MinusanimationCenter.Write(bw);
        _unnamed6.Write(bw);
        _zspriteRadiusScale.Write(bw);
        _unnamed7.Write(bw);
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
    public class ContrailPointStatesBlockBlock : IBlock {
      private RealBounds _duration = new RealBounds();
      private RealBounds _transitionDuration = new RealBounds();
      private TagReference _physics = new TagReference();
      private Real _width = new Real();
      private RealARGBColor _colorLowerBound = new RealARGBColor();
      private RealARGBColor _colorUpperBound = new RealARGBColor();
      private Flags _scaleFlags;
public event System.EventHandler BlockNameChanged;
      public ContrailPointStatesBlockBlock() {
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
