// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'lens_flare'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class lens_flare : Interfaces.Pool.Tag {
    private LensFlareBlock lensFlareValues = new LensFlareBlock();
    public virtual LensFlareBlock LensFlareValues {
      get {
        return lensFlareValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LensFlareValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "lens_flare";
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
lensFlareValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lensFlareValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lensFlareValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lensFlareValues.WriteChildData(writer);
    }
    #endregion
    public class LensFlareBlock : IBlock {
      private Angle _falloffAngle = new Angle();
      private Angle _cutoffAngle = new Angle();
      private Pad _unnamed;
      private Real _occlusionRadius = new Real();
      private Enum _occlusionOffsetDirection = new Enum();
      private Pad _unnamed2;
      private Real _nearFadeDistance = new Real();
      private Real _farFadeDistance = new Real();
      private TagReference _bitmap = new TagReference();
      private Flags _flags;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Enum _rotationFunction = new Enum();
      private Pad _unnamed5;
      private Angle _rotationFunctionScale = new Angle();
      private Pad _unnamed6;
      private Real _horizontalScale = new Real();
      private Real _verticalScale = new Real();
      private Pad _unnamed7;
      private Block _reflections = new Block();
      private Pad _unnamed8;
      public BlockCollection<LensFlareReflectionBlock> _reflectionsList = new BlockCollection<LensFlareReflectionBlock>();
public event System.EventHandler BlockNameChanged;
      public LensFlareBlock() {
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(2);
        this._flags = new Flags(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(76);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(24);
        this._unnamed7 = new Pad(28);
        this._unnamed8 = new Pad(32);
      }
      public BlockCollection<LensFlareReflectionBlock> Reflections {
        get {
          return this._reflectionsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
for (int x=0; x<Reflections.BlockCount; x++)
{
  IBlock block = Reflections.GetBlock(x);
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
      public Real OcclusionRadius {
        get {
          return this._occlusionRadius;
        }
        set {
          this._occlusionRadius = value;
        }
      }
      public Enum OcclusionOffsetDirection {
        get {
          return this._occlusionOffsetDirection;
        }
        set {
          this._occlusionOffsetDirection = value;
        }
      }
      public Real NearFadeDistance {
        get {
          return this._nearFadeDistance;
        }
        set {
          this._nearFadeDistance = value;
        }
      }
      public Real FarFadeDistance {
        get {
          return this._farFadeDistance;
        }
        set {
          this._farFadeDistance = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum RotationFunction {
        get {
          return this._rotationFunction;
        }
        set {
          this._rotationFunction = value;
        }
      }
      public Angle RotationFunctionScale {
        get {
          return this._rotationFunctionScale;
        }
        set {
          this._rotationFunctionScale = value;
        }
      }
      public Real HorizontalScale {
        get {
          return this._horizontalScale;
        }
        set {
          this._horizontalScale = value;
        }
      }
      public Real VerticalScale {
        get {
          return this._verticalScale;
        }
        set {
          this._verticalScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _falloffAngle.Read(reader);
        _cutoffAngle.Read(reader);
        _unnamed.Read(reader);
        _occlusionRadius.Read(reader);
        _occlusionOffsetDirection.Read(reader);
        _unnamed2.Read(reader);
        _nearFadeDistance.Read(reader);
        _farFadeDistance.Read(reader);
        _bitmap.Read(reader);
        _flags.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _rotationFunction.Read(reader);
        _unnamed5.Read(reader);
        _rotationFunctionScale.Read(reader);
        _unnamed6.Read(reader);
        _horizontalScale.Read(reader);
        _verticalScale.Read(reader);
        _unnamed7.Read(reader);
        _reflections.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmap.ReadString(reader);
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections.Add(new LensFlareReflectionBlock());
          Reflections[x].Read(reader);
        }
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _falloffAngle.Write(bw);
        _cutoffAngle.Write(bw);
        _unnamed.Write(bw);
        _occlusionRadius.Write(bw);
        _occlusionOffsetDirection.Write(bw);
        _unnamed2.Write(bw);
        _nearFadeDistance.Write(bw);
        _farFadeDistance.Write(bw);
        _bitmap.Write(bw);
        _flags.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _rotationFunction.Write(bw);
        _unnamed5.Write(bw);
        _rotationFunctionScale.Write(bw);
        _unnamed6.Write(bw);
        _horizontalScale.Write(bw);
        _verticalScale.Write(bw);
        _unnamed7.Write(bw);
_reflections.Count = Reflections.Count;
        _reflections.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bitmap.WriteString(writer);
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections[x].Write(writer);
        }
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections[x].WriteChildData(writer);
        }
      }
    }
    public class LensFlareReflectionBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Real _position = new Real();
      private Real _rotationOffset = new Real();
      private Pad _unnamed4;
      private RealBounds _radius = new RealBounds();
      private Enum _radiusScaledBy = new Enum();
      private Pad _unnamed5;
      private RealFractionBounds _brightness = new RealFractionBounds();
      private Enum _brightnessScaledBy = new Enum();
      private Pad _unnamed6;
      private RealARGBColor _tintColor = new RealARGBColor();
      private RealARGBColor _colorLowerBound = new RealARGBColor();
      private RealARGBColor _colorUpperBound = new RealARGBColor();
      private Flags _flags2;
      private Enum _animationFunction = new Enum();
      private Real _animationPeriod = new Real();
      private Real _animationPhase = new Real();
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public LensFlareReflectionBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(20);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(2);
        this._flags2 = new Flags(2);
        this._unnamed7 = new Pad(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public Real Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Real RotationOffset {
        get {
          return this._rotationOffset;
        }
        set {
          this._rotationOffset = value;
        }
      }
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public Enum RadiusScaledBy {
        get {
          return this._radiusScaledBy;
        }
        set {
          this._radiusScaledBy = value;
        }
      }
      public RealFractionBounds Brightness {
        get {
          return this._brightness;
        }
        set {
          this._brightness = value;
        }
      }
      public Enum BrightnessScaledBy {
        get {
          return this._brightnessScaledBy;
        }
        set {
          this._brightnessScaledBy = value;
        }
      }
      public RealARGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public Enum AnimationFunction {
        get {
          return this._animationFunction;
        }
        set {
          this._animationFunction = value;
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
      public Real AnimationPhase {
        get {
          return this._animationPhase;
        }
        set {
          this._animationPhase = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _bitmapIndex.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _position.Read(reader);
        _rotationOffset.Read(reader);
        _unnamed4.Read(reader);
        _radius.Read(reader);
        _radiusScaledBy.Read(reader);
        _unnamed5.Read(reader);
        _brightness.Read(reader);
        _brightnessScaledBy.Read(reader);
        _unnamed6.Read(reader);
        _tintColor.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _flags2.Read(reader);
        _animationFunction.Read(reader);
        _animationPeriod.Read(reader);
        _animationPhase.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _bitmapIndex.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _position.Write(bw);
        _rotationOffset.Write(bw);
        _unnamed4.Write(bw);
        _radius.Write(bw);
        _radiusScaledBy.Write(bw);
        _unnamed5.Write(bw);
        _brightness.Write(bw);
        _brightnessScaledBy.Write(bw);
        _unnamed6.Write(bw);
        _tintColor.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _flags2.Write(bw);
        _animationFunction.Write(bw);
        _animationPeriod.Write(bw);
        _animationPhase.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
