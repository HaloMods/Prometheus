// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'bitmap'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class bitmap : Interfaces.Pool.Tag {
    private BitmapBlockBlock bitmapValues = new BitmapBlockBlock();
    public virtual BitmapBlockBlock BitmapValues {
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
    public class BitmapBlockBlock : IBlock {
      private Enum _type;
      private Enum _format;
      private Enum _usage;
      private Flags _flags;
      private RealFraction _detailFadeFactor = new RealFraction();
      private RealFraction _sharpenAmount = new RealFraction();
      private Real _bumpHeight = new Real();
      private Enum _unnamed0;
      private ShortInteger _unnamed1 = new ShortInteger();
      private ShortInteger _colorPlateWidth = new ShortInteger();
      private ShortInteger _colorPlateHeight = new ShortInteger();
      private Skip _unnamed2;
      private Data _processedPixelData = new Data();
      private Real _blurFilterSize = new Real();
      private Real _alphaBias = new Real();
      private ShortInteger _mipmapCount = new ShortInteger();
      private Enum _spriteUsage;
      private ShortInteger _spriteSpacing = new ShortInteger();
      private Enum _forceFormat;
      private Block _sequences = new Block();
      private Block _bitmaps = new Block();
      public BlockCollection<BitmapGroupSequenceBlockBlock> _sequencesList = new BlockCollection<BitmapGroupSequenceBlockBlock>();
      public BlockCollection<BitmapDataBlockBlock> _bitmapsList = new BlockCollection<BitmapDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public BitmapBlockBlock() {
        this._type = new Enum(2);
        this._format = new Enum(2);
        this._usage = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Enum(2);
        this._unnamed2 = new Skip(8);
        this._spriteUsage = new Enum(2);
        this._forceFormat = new Enum(2);
      }
      public BlockCollection<BitmapGroupSequenceBlockBlock> Sequences {
        get {
          return this._sequencesList;
        }
      }
      public BlockCollection<BitmapDataBlockBlock> Bitmaps {
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
      public Real BumpHeight {
        get {
          return this._bumpHeight;
        }
        set {
          this._bumpHeight = value;
        }
      }
      public Enum unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public ShortInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
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
      public Enum ForceFormat {
        get {
          return this._forceFormat;
        }
        set {
          this._forceFormat = value;
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
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _colorPlateWidth.Read(reader);
        _colorPlateHeight.Read(reader);
        _unnamed2.Read(reader);
        _processedPixelData.Read(reader);
        _blurFilterSize.Read(reader);
        _alphaBias.Read(reader);
        _mipmapCount.Read(reader);
        _spriteUsage.Read(reader);
        _spriteSpacing.Read(reader);
        _forceFormat.Read(reader);
        _sequences.Read(reader);
        _bitmaps.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _processedPixelData.ReadBinary(reader);
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences.Add(new BitmapGroupSequenceBlockBlock());
          Sequences[x].Read(reader);
        }
        for (x = 0; (x < _sequences.Count); x = (x + 1)) {
          Sequences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps.Add(new BitmapDataBlockBlock());
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
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _colorPlateWidth.Write(bw);
        _colorPlateHeight.Write(bw);
        _unnamed2.Write(bw);
        _processedPixelData.Write(bw);
        _blurFilterSize.Write(bw);
        _alphaBias.Write(bw);
        _mipmapCount.Write(bw);
        _spriteUsage.Write(bw);
        _spriteSpacing.Write(bw);
        _forceFormat.Write(bw);
_sequences.Count = Sequences.Count;
        _sequences.Write(bw);
_bitmaps.Count = Bitmaps.Count;
        _bitmaps.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
    public class BitmapGroupSequenceBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortInteger _firstBitmapIndex = new ShortInteger();
      private ShortInteger _bitmapCount = new ShortInteger();
      private Pad _unnamed0;
      private Block _sprites = new Block();
      public BlockCollection<BitmapGroupSpriteBlockBlock> _spritesList = new BlockCollection<BitmapGroupSpriteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public BitmapGroupSequenceBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(16);
      }
      public BlockCollection<BitmapGroupSpriteBlockBlock> Sprites {
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
        _unnamed0.Read(reader);
        _sprites.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sprites.Count); x = (x + 1)) {
          Sprites.Add(new BitmapGroupSpriteBlockBlock());
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
        _unnamed0.Write(bw);
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
    public class BitmapGroupSpriteBlockBlock : IBlock {
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _left = new Real();
      private Real _right = new Real();
      private Real _top = new Real();
      private Real _bottom = new Real();
      private RealPoint2D _registrationPoint = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public BitmapGroupSpriteBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
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
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _left.Write(bw);
        _right.Write(bw);
        _top.Write(bw);
        _bottom.Write(bw);
        _registrationPoint.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class BitmapDataBlockBlock : IBlock {
      private TagSignature _signature = new TagSignature();
      private ShortInteger _width = new ShortInteger();
      private ShortInteger _height = new ShortInteger();
      private CharInteger _depth = new CharInteger();
      private Flags _moreFlags;
      private Enum _type;
      private Enum _format;
      private Flags _flags;
      private Point2D _registrationPoint = new Point2D();
      private ShortInteger _mipmapCount = new ShortInteger();
      private ShortInteger _low_MinusDetailMipmapCount = new ShortInteger();
      private LongInteger _pixelsOffset = new LongInteger();
      private BitmapData _bitmapData = new BitmapData();
      private Skip _bitmapSelfReference;
      private Skip _unnamed0;
      private Skip _unnamed1;
      private Skip _unnamed2;
      private Skip _unnamed3;
      private Skip _unnamed4;
public event System.EventHandler BlockNameChanged;
      public BitmapDataBlockBlock() {
        this._moreFlags = new Flags(1);
        this._type = new Enum(2);
        this._format = new Enum(2);
        this._flags = new Flags(2);
        this._bitmapSelfReference = new Skip(4);
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(20);
        this._unnamed4 = new Skip(4);
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
      public CharInteger Depth {
        get {
          return this._depth;
        }
        set {
          this._depth = value;
        }
      }
      public Flags MoreFlags {
        get {
          return this._moreFlags;
        }
        set {
          this._moreFlags = value;
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
      public ShortInteger Low_MinusDetailMipmapCount {
        get {
          return this._low_MinusDetailMipmapCount;
        }
        set {
          this._low_MinusDetailMipmapCount = value;
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
      public BitmapData BitmapData {
        get {
          return this._bitmapData;
        }
        set {
          this._bitmapData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _signature.Read(reader);
        _width.Read(reader);
        _height.Read(reader);
        _depth.Read(reader);
        _moreFlags.Read(reader);
        _type.Read(reader);
        _format.Read(reader);
        _flags.Read(reader);
        _registrationPoint.Read(reader);
        _mipmapCount.Read(reader);
        _low_MinusDetailMipmapCount.Read(reader);
        _pixelsOffset.Read(reader);
        _bitmapData.Read(reader);
        _bitmapSelfReference.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmapData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _signature.Write(bw);
        _width.Write(bw);
        _height.Write(bw);
        _depth.Write(bw);
        _moreFlags.Write(bw);
        _type.Write(bw);
        _format.Write(bw);
        _flags.Write(bw);
        _registrationPoint.Write(bw);
        _mipmapCount.Write(bw);
        _low_MinusDetailMipmapCount.Write(bw);
        _pixelsOffset.Write(bw);
        _bitmapData.Write(bw);
        _bitmapSelfReference.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmapData.WriteBinary(writer);
      }
    }
  }
}
