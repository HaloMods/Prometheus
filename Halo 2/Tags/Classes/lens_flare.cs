// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'lens_flare'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class lens_flare : Interfaces.Pool.Tag {
    private LensFlareBlockBlock lensFlareValues = new LensFlareBlockBlock();
    public virtual LensFlareBlockBlock LensFlareValues {
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
    public class LensFlareBlockBlock : IBlock {
      private Angle _falloffAngle = new Angle();
      private Angle _cutoffAngle = new Angle();
      private Skip _unnamed0;
      private Skip _unnamed1;
      private Real _occlusionRadius = new Real();
      private Enum _occlusionOffsetDirection;
      private Enum _occlusionInnerRadiusScale;
      private Real _nearFadeDistance = new Real();
      private Real _farFadeDistance = new Real();
      private TagReference _bitmap = new TagReference();
      private Flags _flags;
      private Skip _unnamed2;
      private Enum _rotationFunction;
      private Pad _unnamed3;
      private Angle _rotationFunctionScale = new Angle();
      private RealVector2D _coronaScale = new RealVector2D();
      private Enum _falloffFunction;
      private Pad _unnamed4;
      private Block _reflections = new Block();
      private Flags _flags2;
      private Pad _unnamed5;
      private Block _brightness = new Block();
      private Block _color = new Block();
      private Block _rotation = new Block();
      public BlockCollection<LensFlareReflectionBlockBlock> _reflectionsList = new BlockCollection<LensFlareReflectionBlockBlock>();
      public BlockCollection<LensFlareScalarAnimationBlockBlock> _brightnessList = new BlockCollection<LensFlareScalarAnimationBlockBlock>();
      public BlockCollection<LensFlareColorAnimationBlockBlock> _colorList = new BlockCollection<LensFlareColorAnimationBlockBlock>();
      public BlockCollection<LensFlareScalarAnimationBlockBlock> _rotationList = new BlockCollection<LensFlareScalarAnimationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LensFlareBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._occlusionOffsetDirection = new Enum(2);
        this._occlusionInnerRadiusScale = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed2 = new Skip(2);
        this._rotationFunction = new Enum(2);
        this._unnamed3 = new Pad(2);
        this._falloffFunction = new Enum(2);
        this._unnamed4 = new Pad(2);
        this._flags2 = new Flags(2);
        this._unnamed5 = new Pad(2);
      }
      public BlockCollection<LensFlareReflectionBlockBlock> Reflections {
        get {
          return this._reflectionsList;
        }
      }
      public BlockCollection<LensFlareScalarAnimationBlockBlock> Brightness {
        get {
          return this._brightnessList;
        }
      }
      public BlockCollection<LensFlareColorAnimationBlockBlock> Color {
        get {
          return this._colorList;
        }
      }
      public BlockCollection<LensFlareScalarAnimationBlockBlock> Rotation {
        get {
          return this._rotationList;
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
for (int x=0; x<Brightness.BlockCount; x++)
{
  IBlock block = Brightness.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Color.BlockCount; x++)
{
  IBlock block = Color.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Rotation.BlockCount; x++)
{
  IBlock block = Rotation.GetBlock(x);
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
      public Enum OcclusionInnerRadiusScale {
        get {
          return this._occlusionInnerRadiusScale;
        }
        set {
          this._occlusionInnerRadiusScale = value;
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
      public RealVector2D CoronaScale {
        get {
          return this._coronaScale;
        }
        set {
          this._coronaScale = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _falloffAngle.Read(reader);
        _cutoffAngle.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _occlusionRadius.Read(reader);
        _occlusionOffsetDirection.Read(reader);
        _occlusionInnerRadiusScale.Read(reader);
        _nearFadeDistance.Read(reader);
        _farFadeDistance.Read(reader);
        _bitmap.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _rotationFunction.Read(reader);
        _unnamed3.Read(reader);
        _rotationFunctionScale.Read(reader);
        _coronaScale.Read(reader);
        _falloffFunction.Read(reader);
        _unnamed4.Read(reader);
        _reflections.Read(reader);
        _flags2.Read(reader);
        _unnamed5.Read(reader);
        _brightness.Read(reader);
        _color.Read(reader);
        _rotation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmap.ReadString(reader);
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections.Add(new LensFlareReflectionBlockBlock());
          Reflections[x].Read(reader);
        }
        for (x = 0; (x < _reflections.Count); x = (x + 1)) {
          Reflections[x].ReadChildData(reader);
        }
        for (x = 0; (x < _brightness.Count); x = (x + 1)) {
          Brightness.Add(new LensFlareScalarAnimationBlockBlock());
          Brightness[x].Read(reader);
        }
        for (x = 0; (x < _brightness.Count); x = (x + 1)) {
          Brightness[x].ReadChildData(reader);
        }
        for (x = 0; (x < _color.Count); x = (x + 1)) {
          Color.Add(new LensFlareColorAnimationBlockBlock());
          Color[x].Read(reader);
        }
        for (x = 0; (x < _color.Count); x = (x + 1)) {
          Color[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rotation.Count); x = (x + 1)) {
          Rotation.Add(new LensFlareScalarAnimationBlockBlock());
          Rotation[x].Read(reader);
        }
        for (x = 0; (x < _rotation.Count); x = (x + 1)) {
          Rotation[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _falloffAngle.Write(bw);
        _cutoffAngle.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _occlusionRadius.Write(bw);
        _occlusionOffsetDirection.Write(bw);
        _occlusionInnerRadiusScale.Write(bw);
        _nearFadeDistance.Write(bw);
        _farFadeDistance.Write(bw);
        _bitmap.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _rotationFunction.Write(bw);
        _unnamed3.Write(bw);
        _rotationFunctionScale.Write(bw);
        _coronaScale.Write(bw);
        _falloffFunction.Write(bw);
        _unnamed4.Write(bw);
_reflections.Count = Reflections.Count;
        _reflections.Write(bw);
        _flags2.Write(bw);
        _unnamed5.Write(bw);
_brightness.Count = Brightness.Count;
        _brightness.Write(bw);
_color.Count = Color.Count;
        _color.Write(bw);
_rotation.Count = Rotation.Count;
        _rotation.Write(bw);
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
        for (x = 0; (x < _brightness.Count); x = (x + 1)) {
          Brightness[x].Write(writer);
        }
        for (x = 0; (x < _brightness.Count); x = (x + 1)) {
          Brightness[x].WriteChildData(writer);
        }
        for (x = 0; (x < _color.Count); x = (x + 1)) {
          Color[x].Write(writer);
        }
        for (x = 0; (x < _color.Count); x = (x + 1)) {
          Color[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rotation.Count); x = (x + 1)) {
          Rotation[x].Write(writer);
        }
        for (x = 0; (x < _rotation.Count); x = (x + 1)) {
          Rotation[x].WriteChildData(writer);
        }
      }
    }
    public class LensFlareReflectionBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed1;
      private Real _position = new Real();
      private Real _rotationOffset = new Real();
      private RealBounds _radius = new RealBounds();
      private FractionBounds _brightness = new FractionBounds();
      private RealFraction _modulationFactor = new RealFraction();
      private RealRGBColor _color = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public LensFlareReflectionBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
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
      public FractionBounds Brightness {
        get {
          return this._brightness;
        }
        set {
          this._brightness = value;
        }
      }
      public RealFraction ModulationFactor {
        get {
          return this._modulationFactor;
        }
        set {
          this._modulationFactor = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _bitmapIndex.Read(reader);
        _unnamed1.Read(reader);
        _position.Read(reader);
        _rotationOffset.Read(reader);
        _radius.Read(reader);
        _brightness.Read(reader);
        _modulationFactor.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _bitmapIndex.Write(bw);
        _unnamed1.Write(bw);
        _position.Write(bw);
        _rotationOffset.Write(bw);
        _radius.Write(bw);
        _brightness.Write(bw);
        _modulationFactor.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LensFlareScalarAnimationBlockBlock : IBlock {
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LensFlareScalarAnimationBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ByteBlockBlock : IBlock {
      private CharInteger _value = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockBlock() {
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
      public CharInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LensFlareColorAnimationBlockBlock : IBlock {
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LensFlareColorAnimationBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
  }
}
