// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'bitmap'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class bitmap : Interfaces.Pool.Tag {
    private BitmapBlock bitmapValues = new BitmapBlock();
    public virtual BitmapBlock BitmapValues {
      get {
        return bitmapValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(BitmapValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "bitmap";
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
bitmapValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
bitmapValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
bitmapValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
bitmapValues.WriteChildData(writer);
    }
    #endregion
    public class BitmapBlock : IBlock {
      private Enum _type = new Enum();
      private Enum _format = new Enum();
      private Enum _usage = new Enum();
      private Flags _flags;
      private RealFraction _detailFadeFactor = new RealFraction();
      private RealFraction _sharpenAmount = new RealFraction();
      private RealFraction _bumpHeight = new RealFraction();
      private Enum _spriteBudgetSize = new Enum();
      private ShortInteger _spriteBudgetCount = new ShortInteger();
      private ShortInteger _colorPlateWidth = new ShortInteger();
      private ShortInteger _colorPlateHeight = new ShortInteger();
      private Data _compressedColorPlateData = new Data();
      private Data _processedPixelData = new Data();
      private Real _blurFilterSize = new Real();
      private Real _alphaBias = new Real();
      private ShortInteger _mipmapCount = new ShortInteger();
      private Enum _spriteUsage = new Enum();
      private ShortInteger _spriteSpacing = new ShortInteger();
      private Pad _unnamed2;
      private Block _sequences = new Block();
      private Block _bitmaps = new Block();
      public BlockCollection<BitmapGroupSequenceBlock> _sequencesList = new BlockCollection<BitmapGroupSequenceBlock>();
      public BlockCollection<BitmapDataBlock> _bitmapsList = new BlockCollection<BitmapDataBlock>();
public event System.EventHandler BlockNameChanged;
      public BitmapBlock() {
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<BitmapGroupSequenceBlock> Sequences {
        get {
          return this._sequencesList;
        }
      }
      public BlockCollection<BitmapDataBlock> Bitmaps {
        get {
          return this._bitmapsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Sequences.BlockCount; x++)
{
  IBlock block = Sequences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bitmaps.BlockCount; x++)
{
  IBlock block = Bitmaps.GetBlock(x);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Enum Format {
        get {
          return this._format;
        }
        set {
          this._format = value;
        }
      }
      public Enum Usage {
        get {
          return this._usage;
        }
        set {
          this._usage = value;
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
      public RealFraction DetailFadeFactor {
        get {
          return this._detailFadeFactor;
        }
        set {
          this._detailFadeFactor = value;
        }
      }
      public RealFraction SharpenAmount {
        get {
          return this._sharpenAmount;
        }
        set {
          this._sharpenAmount = value;
        }
      }
      public RealFraction BumpHeight {
        get {
          return this._bumpHeight;
        }
        set {
          this._bumpHeight = value;
        }
      }
      public Enum SpriteBudgetSize {
        get {
          return this._spriteBudgetSize;
        }
        set {
          this._spriteBudgetSize = value;
        }
      }
      public ShortInteger SpriteBudgetCount {
        get {
          return this._spriteBudgetCount;
        }
        set {
          this._spriteBudgetCount = value;
        }
      }
      public ShortInteger ColorPlateWidth {
        get {
          return this._colorPlateWidth;
        }
        set {
          this._colorPlateWidth = value;
        }
      }
      public ShortInteger ColorPlateHeight {
        get {
          return this._colorPlateHeight;
        }
        set {
          this._colorPlateHeight = value;
        }
      }
      public Data CompressedColorPlateData {
        get {
          return this._compressedColorPlateData;
        }
        set {
          this._compressedColorPlateData = value;
        }
      }
      public Data ProcessedPixelData {
        get {
          return this._processedPixelData;
        }
        set {
          this._processedPixelData = value;
        }
      }
      public Real BlurFilterSize {
        get {
          return this._blurFilterSize;
        }
        set {
          this._blurFilterSize = value;
        }
      }
      public Real AlphaBias {
        get {
          return this._alphaBias;
        }
        set {
          this._alphaBias = value;
        }
      }
      public ShortInteger MipmapCount {
        get {
          return this._mipmapCount;
        }
        set {
          this._mipmapCount = value;
        }
      }
      public Enum SpriteUsage {
        get {
          return this._spriteUsage;
        }
        set {
          this._spriteUsage = value;
        }
      }
      public ShortInteger SpriteSpacing {
        get {
          return this._spriteSpacing;
        }
        set {
          this._spriteSpacing = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _format.Read(reader);
        _usage.Read(reader);
        _flags.Read(reader);
        _detailFadeFactor.Read(reader);
        _sharpenAmount.Read(reader);
        _bumpHeight.Read(reader);
        _spriteBudgetSize.Read(reader);
        _spriteBudgetCount.Read(reader);
        _colorPlateWidth.Read(reader);
        _colorPlateHeight.Read(reader);
        _compressedColorPlateData.Read(reader);
        _processedPixelData.Read(reader);
        _blurFilterSize.Read(reader);
        _alphaBias.Read(reader);
        _mipmapCount.Read(reader);
        _spriteUsage.Read(reader);
        _spriteSpacing.Read(reader);
        _unnamed2.Read(reader);
        _sequences.Read(reader);
        _bitmaps.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _compressedColorPlateData.ReadBinary(reader);
        _processedPixelData.ReadBinary(reader);
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences.Add(new BitmapGroupSequenceBlock());
          Sequences[x].Read(reader);
        }
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps.Add(new BitmapDataBlock());
          Bitmaps[x].Read(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _format.Write(bw);
        _usage.Write(bw);
        _flags.Write(bw);
        _detailFadeFactor.Write(bw);
        _sharpenAmount.Write(bw);
        _bumpHeight.Write(bw);
        _spriteBudgetSize.Write(bw);
        _spriteBudgetCount.Write(bw);
        _colorPlateWidth.Write(bw);
        _colorPlateHeight.Write(bw);
        _compressedColorPlateData.Write(bw);
        _processedPixelData.Write(bw);
        _blurFilterSize.Write(bw);
        _alphaBias.Write(bw);
        _mipmapCount.Write(bw);
        _spriteUsage.Write(bw);
        _spriteSpacing.Write(bw);
        _unnamed2.Write(bw);
_sequences.Count = Sequences.Count;
        _sequences.Write(bw);
_bitmaps.Count = Bitmaps.Count;
        _bitmaps.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _compressedColorPlateData.WriteBinary(writer);
        _processedPixelData.WriteBinary(writer);
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences[x].Write(writer);
        }
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].Write(writer);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].WriteChildData(writer);
        }
      }
    }
    public class BitmapGroupSequenceBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortInteger _firstBitmapIndex = new ShortInteger();
      private ShortInteger _bitmapCount = new ShortInteger();
      private Pad _unnamed;
      private Block _sprites = new Block();
      public BlockCollection<BitmapGroupSpriteBlock> _spritesList = new BlockCollection<BitmapGroupSpriteBlock>();
public event System.EventHandler BlockNameChanged;
      public BitmapGroupSequenceBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(16);
      }
      public BlockCollection<BitmapGroupSpriteBlock> Sprites {
        get {
          return this._spritesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Sprites.BlockCount; x++)
{
  IBlock block = Sprites.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger FirstBitmapIndex {
        get {
          return this._firstBitmapIndex;
        }
        set {
          this._firstBitmapIndex = value;
        }
      }
      public ShortInteger BitmapCount {
        get {
          return this._bitmapCount;
        }
        set {
          this._bitmapCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _firstBitmapIndex.Read(reader);
        _bitmapCount.Read(reader);
        _unnamed.Read(reader);
        _sprites.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sprites.Count); x = (x + 1)) {
          Sprites.Add(new BitmapGroupSpriteBlock());
          Sprites[x].Read(reader);
        }
        for (x = 0; (x < _sprites.Count); x = (x + 1)) {
          Sprites[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _firstBitmapIndex.Write(bw);
        _bitmapCount.Write(bw);
        _unnamed.Write(bw);
_sprites.Count = Sprites.Count;
        _sprites.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sprites.Count); x = (x + 1)) {
          Sprites[x].Write(writer);
        }
        for (x = 0; (x < _sprites.Count); x = (x + 1)) {
          Sprites[x].WriteChildData(writer);
        }
      }
    }
    public class BitmapGroupSpriteBlock : IBlock {
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Real _left = new Real();
      private Real _right = new Real();
      private Real _top = new Real();
      private Real _bottom = new Real();
      private RealPoint2D _registrationPoint = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public BitmapGroupSpriteBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
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
      public ShortInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public Real Left {
        get {
          return this._left;
        }
        set {
          this._left = value;
        }
      }
      public Real Right {
        get {
          return this._right;
        }
        set {
          this._right = value;
        }
      }
      public Real Top {
        get {
          return this._top;
        }
        set {
          this._top = value;
        }
      }
      public Real Bottom {
        get {
          return this._bottom;
        }
        set {
          this._bottom = value;
        }
      }
      public RealPoint2D RegistrationPoint {
        get {
          return this._registrationPoint;
        }
        set {
          this._registrationPoint = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmapIndex.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _left.Read(reader);
        _right.Read(reader);
        _top.Read(reader);
        _bottom.Read(reader);
        _registrationPoint.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapIndex.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _left.Write(bw);
        _right.Write(bw);
        _top.Write(bw);
        _bottom.Write(bw);
        _registrationPoint.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class BitmapDataBlock : IBlock {
      private TagSignature _signature = new TagSignature();
      private ShortInteger _width = new ShortInteger();
      private ShortInteger _height = new ShortInteger();
      private ShortInteger _depth = new ShortInteger();
      private Enum _type = new Enum();
      private Enum _format = new Enum();
      private Flags _flags;
      private Point2D _registrationPoint = new Point2D();
      private ShortInteger _mipmapCount = new ShortInteger();
      private Pad _unnamed;
      private LongInteger _pixelsOffset = new LongInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private LongInteger _baseAddress = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public BitmapDataBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(4);
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
      public TagSignature Signature {
        get {
          return this._signature;
        }
        set {
          this._signature = value;
        }
      }
      public ShortInteger Width {
        get {
          return this._width;
        }
        set {
          this._width = value;
        }
      }
      public ShortInteger Height {
        get {
          return this._height;
        }
        set {
          this._height = value;
        }
      }
      public ShortInteger Depth {
        get {
          return this._depth;
        }
        set {
          this._depth = value;
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
      public Enum Format {
        get {
          return this._format;
        }
        set {
          this._format = value;
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
      public Point2D RegistrationPoint {
        get {
          return this._registrationPoint;
        }
        set {
          this._registrationPoint = value;
        }
      }
      public ShortInteger MipmapCount {
        get {
          return this._mipmapCount;
        }
        set {
          this._mipmapCount = value;
        }
      }
      public LongInteger PixelsOffset {
        get {
          return this._pixelsOffset;
        }
        set {
          this._pixelsOffset = value;
        }
      }
      public LongInteger BaseAddress {
        get {
          return this._baseAddress;
        }
        set {
          this._baseAddress = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _signature.Read(reader);
        _width.Read(reader);
        _height.Read(reader);
        _depth.Read(reader);
        _type.Read(reader);
        _format.Read(reader);
        _flags.Read(reader);
        _registrationPoint.Read(reader);
        _mipmapCount.Read(reader);
        _unnamed.Read(reader);
        _pixelsOffset.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _baseAddress.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _signature.Write(bw);
        _width.Write(bw);
        _height.Write(bw);
        _depth.Write(bw);
        _type.Write(bw);
        _format.Write(bw);
        _flags.Write(bw);
        _registrationPoint.Write(bw);
        _mipmapCount.Write(bw);
        _unnamed.Write(bw);
        _pixelsOffset.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _baseAddress.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
