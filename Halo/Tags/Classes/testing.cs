// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'testing'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class testing : Interfaces.Pool.Tag {
    private TestingBlock testingValues = new TestingBlock();
    public virtual TestingBlock TestingValues {
      get {
        return testingValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(TestingValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "testing";
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
testingValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
testingValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
testingValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
testingValues.WriteChildData(writer);
    }
    #endregion
    public class TestingBlock : IBlock {
      private Angle _angle = new Angle();
      private AngleBounds _angleBounds = new AngleBounds();
      private ARGBColor _argbColor = new ARGBColor();
      private Block _block = new Block();
      private CharInteger _charInteger = new CharInteger();
      private Data _data = new Data();
      private Enum _enum = new Enum();
      private FixedLengthString _fixedLengthString = new FixedLengthString();
      private Flags _flags;
      private LongBlockIndex _longBlockIndex = new LongBlockIndex();
      private LongInteger _longInteger = new LongInteger();
      private Point2D _point2D = new Point2D();
      private Real _real = new Real();
      private RealARGBColor _realArgbColor = new RealARGBColor();
      private RealBounds _realBounds = new RealBounds();
      private RealEulerAngles2D _realEulerAngles2D = new RealEulerAngles2D();
      private RealEulerAngles3D _realEulerAngles3D = new RealEulerAngles3D();
      private RealFraction _realFraction = new RealFraction();
      private RealFractionBounds _realFractionBounds = new RealFractionBounds();
      private RealPlane2D _realPlane2D = new RealPlane2D();
      private RealPlane3D _realPlane3D = new RealPlane3D();
      private RealPoint2D _realPoint2D = new RealPoint2D();
      private RealPoint3D _realPoint3D = new RealPoint3D();
      private RealQuaternion _realQuaternion = new RealQuaternion();
      private RealRGBColor _realRgbColor = new RealRGBColor();
      private RealVector2D _realVector2D = new RealVector2D();
      private RealVector3D _realVector3D = new RealVector3D();
      private Rectangle2D _rectangle2D = new Rectangle2D();
      private RGBColor _rgbColor = new RGBColor();
      private ShortBlockIndex _shortBlockIndex = new ShortBlockIndex();
      private ShortBounds _shortBounds = new ShortBounds();
      private ShortInteger _shortInteger = new ShortInteger();
      private TagReference _tagReference = new TagReference();
      private TagSignature _tagSignature = new TagSignature();
      private VariableLengthString _variableLengthString = new VariableLengthString();
      private Block _fiveEntryBlock = new Block();
      public BlockCollection<EmptyStructureBlock> _blockList = new BlockCollection<EmptyStructureBlock>();
      public BlockCollection<FiveEntryStructureBlock> _fiveEntryBlockList = new BlockCollection<FiveEntryStructureBlock>();
public event System.EventHandler BlockNameChanged;
      public TestingBlock() {
        this._flags = new Flags(2);
      }
      public BlockCollection<EmptyStructureBlock> Block {
        get {
          return this._blockList;
        }
      }
      public BlockCollection<FiveEntryStructureBlock> FiveEntryBlock {
        get {
          return this._fiveEntryBlockList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_tagReference.Value);
for (int x=0; x<Block.BlockCount; x++)
{
  IBlock block = Block.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FiveEntryBlock.BlockCount; x++)
{
  IBlock block = FiveEntryBlock.GetBlock(x);
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
      public Angle Angle {
        get {
          return this._angle;
        }
        set {
          this._angle = value;
        }
      }
      public AngleBounds AngleBounds {
        get {
          return this._angleBounds;
        }
        set {
          this._angleBounds = value;
        }
      }
      public ARGBColor ArgbColor {
        get {
          return this._argbColor;
        }
        set {
          this._argbColor = value;
        }
      }
      public CharInteger CharInteger {
        get {
          return this._charInteger;
        }
        set {
          this._charInteger = value;
        }
      }
      public Data Data {
        get {
          return this._data;
        }
        set {
          this._data = value;
        }
      }
      public Enum Enum {
        get {
          return this._enum;
        }
        set {
          this._enum = value;
        }
      }
      public FixedLengthString FixedLengthString {
        get {
          return this._fixedLengthString;
        }
        set {
          this._fixedLengthString = value;
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
      public LongBlockIndex LongBlockIndex {
        get {
          return this._longBlockIndex;
        }
        set {
          this._longBlockIndex = value;
        }
      }
      public LongInteger LongInteger {
        get {
          return this._longInteger;
        }
        set {
          this._longInteger = value;
        }
      }
      public Point2D Point2D {
        get {
          return this._point2D;
        }
        set {
          this._point2D = value;
        }
      }
      public Real Real {
        get {
          return this._real;
        }
        set {
          this._real = value;
        }
      }
      public RealARGBColor RealArgbColor {
        get {
          return this._realArgbColor;
        }
        set {
          this._realArgbColor = value;
        }
      }
      public RealBounds RealBounds {
        get {
          return this._realBounds;
        }
        set {
          this._realBounds = value;
        }
      }
      public RealEulerAngles2D RealEulerAngles2D {
        get {
          return this._realEulerAngles2D;
        }
        set {
          this._realEulerAngles2D = value;
        }
      }
      public RealEulerAngles3D RealEulerAngles3D {
        get {
          return this._realEulerAngles3D;
        }
        set {
          this._realEulerAngles3D = value;
        }
      }
      public RealFraction RealFraction {
        get {
          return this._realFraction;
        }
        set {
          this._realFraction = value;
        }
      }
      public RealFractionBounds RealFractionBounds {
        get {
          return this._realFractionBounds;
        }
        set {
          this._realFractionBounds = value;
        }
      }
      public RealPlane2D RealPlane2D {
        get {
          return this._realPlane2D;
        }
        set {
          this._realPlane2D = value;
        }
      }
      public RealPlane3D RealPlane3D {
        get {
          return this._realPlane3D;
        }
        set {
          this._realPlane3D = value;
        }
      }
      public RealPoint2D RealPoint2D {
        get {
          return this._realPoint2D;
        }
        set {
          this._realPoint2D = value;
        }
      }
      public RealPoint3D RealPoint3D {
        get {
          return this._realPoint3D;
        }
        set {
          this._realPoint3D = value;
        }
      }
      public RealQuaternion RealQuaternion {
        get {
          return this._realQuaternion;
        }
        set {
          this._realQuaternion = value;
        }
      }
      public RealRGBColor RealRgbColor {
        get {
          return this._realRgbColor;
        }
        set {
          this._realRgbColor = value;
        }
      }
      public RealVector2D RealVector2D {
        get {
          return this._realVector2D;
        }
        set {
          this._realVector2D = value;
        }
      }
      public RealVector3D RealVector3D {
        get {
          return this._realVector3D;
        }
        set {
          this._realVector3D = value;
        }
      }
      public Rectangle2D Rectangle2D {
        get {
          return this._rectangle2D;
        }
        set {
          this._rectangle2D = value;
        }
      }
      public RGBColor RgbColor {
        get {
          return this._rgbColor;
        }
        set {
          this._rgbColor = value;
        }
      }
      public ShortBlockIndex ShortBlockIndex {
        get {
          return this._shortBlockIndex;
        }
        set {
          this._shortBlockIndex = value;
        }
      }
      public ShortBounds ShortBounds {
        get {
          return this._shortBounds;
        }
        set {
          this._shortBounds = value;
        }
      }
      public ShortInteger ShortInteger {
        get {
          return this._shortInteger;
        }
        set {
          this._shortInteger = value;
        }
      }
      public TagReference TagReference {
        get {
          return this._tagReference;
        }
        set {
          this._tagReference = value;
        }
      }
      public TagSignature TagSignature {
        get {
          return this._tagSignature;
        }
        set {
          this._tagSignature = value;
        }
      }
      public VariableLengthString VariableLengthString {
        get {
          return this._variableLengthString;
        }
        set {
          this._variableLengthString = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _angle.Read(reader);
        _angleBounds.Read(reader);
        _argbColor.Read(reader);
        _block.Read(reader);
        _charInteger.Read(reader);
        _data.Read(reader);
        _enum.Read(reader);
        _fixedLengthString.Read(reader);
        _flags.Read(reader);
        _longBlockIndex.Read(reader);
        _longInteger.Read(reader);
        _point2D.Read(reader);
        _real.Read(reader);
        _realArgbColor.Read(reader);
        _realBounds.Read(reader);
        _realEulerAngles2D.Read(reader);
        _realEulerAngles3D.Read(reader);
        _realFraction.Read(reader);
        _realFractionBounds.Read(reader);
        _realPlane2D.Read(reader);
        _realPlane3D.Read(reader);
        _realPoint2D.Read(reader);
        _realPoint3D.Read(reader);
        _realQuaternion.Read(reader);
        _realRgbColor.Read(reader);
        _realVector2D.Read(reader);
        _realVector3D.Read(reader);
        _rectangle2D.Read(reader);
        _rgbColor.Read(reader);
        _shortBlockIndex.Read(reader);
        _shortBounds.Read(reader);
        _shortInteger.Read(reader);
        _tagReference.Read(reader);
        _tagSignature.Read(reader);
        _variableLengthString.Read(reader);
        _fiveEntryBlock.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _block.Count); x = (x + 1)) {
          Block.Add(new EmptyStructureBlock());
          Block[x].Read(reader);
        }
        for (x = 0; (x < _block.Count); x = (x + 1)) {
          Block[x].ReadChildData(reader);
        }
        _data.ReadBinary(reader);
        _tagReference.ReadString(reader);
        for (x = 0; (x < _fiveEntryBlock.Count); x = (x + 1)) {
          FiveEntryBlock.Add(new FiveEntryStructureBlock());
          FiveEntryBlock[x].Read(reader);
        }
        for (x = 0; (x < _fiveEntryBlock.Count); x = (x + 1)) {
          FiveEntryBlock[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _angle.Write(bw);
        _angleBounds.Write(bw);
        _argbColor.Write(bw);
_block.Count = Block.Count;
        _block.Write(bw);
        _charInteger.Write(bw);
        _data.Write(bw);
        _enum.Write(bw);
        _fixedLengthString.Write(bw);
        _flags.Write(bw);
        _longBlockIndex.Write(bw);
        _longInteger.Write(bw);
        _point2D.Write(bw);
        _real.Write(bw);
        _realArgbColor.Write(bw);
        _realBounds.Write(bw);
        _realEulerAngles2D.Write(bw);
        _realEulerAngles3D.Write(bw);
        _realFraction.Write(bw);
        _realFractionBounds.Write(bw);
        _realPlane2D.Write(bw);
        _realPlane3D.Write(bw);
        _realPoint2D.Write(bw);
        _realPoint3D.Write(bw);
        _realQuaternion.Write(bw);
        _realRgbColor.Write(bw);
        _realVector2D.Write(bw);
        _realVector3D.Write(bw);
        _rectangle2D.Write(bw);
        _rgbColor.Write(bw);
        _shortBlockIndex.Write(bw);
        _shortBounds.Write(bw);
        _shortInteger.Write(bw);
        _tagReference.Write(bw);
        _tagSignature.Write(bw);
        _variableLengthString.Write(bw);
_fiveEntryBlock.Count = FiveEntryBlock.Count;
        _fiveEntryBlock.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _block.Count); x = (x + 1)) {
          Block[x].Write(writer);
        }
        for (x = 0; (x < _block.Count); x = (x + 1)) {
          Block[x].WriteChildData(writer);
        }
        _data.WriteBinary(writer);
        _tagReference.WriteString(writer);
        for (x = 0; (x < _fiveEntryBlock.Count); x = (x + 1)) {
          FiveEntryBlock[x].Write(writer);
        }
        for (x = 0; (x < _fiveEntryBlock.Count); x = (x + 1)) {
          FiveEntryBlock[x].WriteChildData(writer);
        }
      }
    }
    public class EmptyStructureBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public EmptyStructureBlock() {
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
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class FiveEntryStructureBlock : IBlock {
      private Real _real = new Real();
      private RealARGBColor _realArgbColor = new RealARGBColor();
      private RealBounds _realBounds = new RealBounds();
      private RealEulerAngles2D _realEulerAngles2D = new RealEulerAngles2D();
      private RealRGBColor _realRgbColor = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public FiveEntryStructureBlock() {
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
      public Real Real {
        get {
          return this._real;
        }
        set {
          this._real = value;
        }
      }
      public RealARGBColor RealArgbColor {
        get {
          return this._realArgbColor;
        }
        set {
          this._realArgbColor = value;
        }
      }
      public RealBounds RealBounds {
        get {
          return this._realBounds;
        }
        set {
          this._realBounds = value;
        }
      }
      public RealEulerAngles2D RealEulerAngles2D {
        get {
          return this._realEulerAngles2D;
        }
        set {
          this._realEulerAngles2D = value;
        }
      }
      public RealRGBColor RealRgbColor {
        get {
          return this._realRgbColor;
        }
        set {
          this._realRgbColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _real.Read(reader);
        _realArgbColor.Read(reader);
        _realBounds.Read(reader);
        _realEulerAngles2D.Read(reader);
        _realRgbColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _real.Write(bw);
        _realArgbColor.Write(bw);
        _realBounds.Write(bw);
        _realEulerAngles2D.Write(bw);
        _realRgbColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
