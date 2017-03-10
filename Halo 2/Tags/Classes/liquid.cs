// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'liquid'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class liquid : Interfaces.Pool.Tag {
    private LiquidBlockBlock liquidValues = new LiquidBlockBlock();
    public virtual LiquidBlockBlock LiquidValues {
      get {
        return liquidValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LiquidValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "liquid";
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
liquidValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
liquidValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
liquidValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
liquidValues.WriteChildData(writer);
    }
    #endregion
    public class LiquidBlockBlock : IBlock {
      private Pad _unnamed0;
      private Enum _type;
      private StringId _attachmentMarkerName = new StringId();
      private Pad _unnamed1;
      private Real _falloffDistanceFromCamera = new Real();
      private Real _cutoffDistanceFromCamera = new Real();
      private Pad _unnamed2;
      private Block _arcs = new Block();
      public BlockCollection<LiquidArcBlockBlock> _arcsList = new BlockCollection<LiquidArcBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LiquidBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._type = new Enum(2);
        this._unnamed1 = new Pad(56);
        this._unnamed2 = new Pad(32);
      }
      public BlockCollection<LiquidArcBlockBlock> Arcs {
        get {
          return this._arcsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Arcs.BlockCount; x++)
{
  IBlock block = Arcs.GetBlock(x);
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
      public StringId AttachmentMarkerName {
        get {
          return this._attachmentMarkerName;
        }
        set {
          this._attachmentMarkerName = value;
        }
      }
      public Real FalloffDistanceFromCamera {
        get {
          return this._falloffDistanceFromCamera;
        }
        set {
          this._falloffDistanceFromCamera = value;
        }
      }
      public Real CutoffDistanceFromCamera {
        get {
          return this._cutoffDistanceFromCamera;
        }
        set {
          this._cutoffDistanceFromCamera = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _type.Read(reader);
        _attachmentMarkerName.Read(reader);
        _unnamed1.Read(reader);
        _falloffDistanceFromCamera.Read(reader);
        _cutoffDistanceFromCamera.Read(reader);
        _unnamed2.Read(reader);
        _arcs.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _attachmentMarkerName.ReadString(reader);
        for (x = 0; (x < _arcs.Count); x = (x + 1)) {
          Arcs.Add(new LiquidArcBlockBlock());
          Arcs[x].Read(reader);
        }
        for (x = 0; (x < _arcs.Count); x = (x + 1)) {
          Arcs[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _type.Write(bw);
        _attachmentMarkerName.Write(bw);
        _unnamed1.Write(bw);
        _falloffDistanceFromCamera.Write(bw);
        _cutoffDistanceFromCamera.Write(bw);
        _unnamed2.Write(bw);
_arcs.Count = Arcs.Count;
        _arcs.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _attachmentMarkerName.WriteString(writer);
        for (x = 0; (x < _arcs.Count); x = (x + 1)) {
          Arcs[x].Write(writer);
        }
        for (x = 0; (x < _arcs.Count); x = (x + 1)) {
          Arcs[x].WriteChildData(writer);
        }
      }
    }
    public class LiquidArcBlockBlock : IBlock {
      private Flags _flags;
      private Enum _spriteCount;
      private Real _naturalLength = new Real();
      private ShortInteger _instances = new ShortInteger();
      private Pad _unnamed0;
      private Angle _instanceSpreadAngle = new Angle();
      private Real _instanceRotationPeriod = new Real();
      private Pad _unnamed1;
      private TagReference _materialEffects = new TagReference();
      private TagReference _bitmap = new TagReference();
      private Pad _unnamed2;
      private Block _data = new Block();
      private Block _data2 = new Block();
      private RealFraction _verticalNegativeScale = new RealFraction();
      private Block _data3 = new Block();
      private Pad _unnamed3;
      private Real _octave1Frequency = new Real();
      private Real _octave2Frequency = new Real();
      private Real _octave3Frequency = new Real();
      private Real _octave4Frequency = new Real();
      private Real _octave5Frequency = new Real();
      private Real _octave6Frequency = new Real();
      private Real _octave7Frequency = new Real();
      private Real _octave8Frequency = new Real();
      private Real _octave9Frequency = new Real();
      private Pad _unnamed4;
      private Flags _octaveFlags;
      private Pad _unnamed5;
      private Block _cores = new Block();
      private Block _data4 = new Block();
      private Block _data5 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<LiquidCoreBlockBlock> _coresList = new BlockCollection<LiquidCoreBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LiquidArcBlockBlock() {
        this._flags = new Flags(2);
        this._spriteCount = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(8);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(64);
        this._unnamed4 = new Pad(28);
        this._octaveFlags = new Flags(2);
        this._unnamed5 = new Pad(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data3 {
        get {
          return this._data3List;
        }
      }
      public BlockCollection<LiquidCoreBlockBlock> Cores {
        get {
          return this._coresList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data4 {
        get {
          return this._data4List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data5 {
        get {
          return this._data5List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_materialEffects.Value);
references.Add(_bitmap.Value);
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data3.BlockCount; x++)
{
  IBlock block = Data3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Cores.BlockCount; x++)
{
  IBlock block = Cores.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data4.BlockCount; x++)
{
  IBlock block = Data4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data5.BlockCount; x++)
{
  IBlock block = Data5.GetBlock(x);
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
      public Enum SpriteCount {
        get {
          return this._spriteCount;
        }
        set {
          this._spriteCount = value;
        }
      }
      public Real NaturalLength {
        get {
          return this._naturalLength;
        }
        set {
          this._naturalLength = value;
        }
      }
      public ShortInteger Instances {
        get {
          return this._instances;
        }
        set {
          this._instances = value;
        }
      }
      public Angle InstanceSpreadAngle {
        get {
          return this._instanceSpreadAngle;
        }
        set {
          this._instanceSpreadAngle = value;
        }
      }
      public Real InstanceRotationPeriod {
        get {
          return this._instanceRotationPeriod;
        }
        set {
          this._instanceRotationPeriod = value;
        }
      }
      public TagReference MaterialEffects {
        get {
          return this._materialEffects;
        }
        set {
          this._materialEffects = value;
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
      public RealFraction VerticalNegativeScale {
        get {
          return this._verticalNegativeScale;
        }
        set {
          this._verticalNegativeScale = value;
        }
      }
      public Real Octave1Frequency {
        get {
          return this._octave1Frequency;
        }
        set {
          this._octave1Frequency = value;
        }
      }
      public Real Octave2Frequency {
        get {
          return this._octave2Frequency;
        }
        set {
          this._octave2Frequency = value;
        }
      }
      public Real Octave3Frequency {
        get {
          return this._octave3Frequency;
        }
        set {
          this._octave3Frequency = value;
        }
      }
      public Real Octave4Frequency {
        get {
          return this._octave4Frequency;
        }
        set {
          this._octave4Frequency = value;
        }
      }
      public Real Octave5Frequency {
        get {
          return this._octave5Frequency;
        }
        set {
          this._octave5Frequency = value;
        }
      }
      public Real Octave6Frequency {
        get {
          return this._octave6Frequency;
        }
        set {
          this._octave6Frequency = value;
        }
      }
      public Real Octave7Frequency {
        get {
          return this._octave7Frequency;
        }
        set {
          this._octave7Frequency = value;
        }
      }
      public Real Octave8Frequency {
        get {
          return this._octave8Frequency;
        }
        set {
          this._octave8Frequency = value;
        }
      }
      public Real Octave9Frequency {
        get {
          return this._octave9Frequency;
        }
        set {
          this._octave9Frequency = value;
        }
      }
      public Flags OctaveFlags {
        get {
          return this._octaveFlags;
        }
        set {
          this._octaveFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _spriteCount.Read(reader);
        _naturalLength.Read(reader);
        _instances.Read(reader);
        _unnamed0.Read(reader);
        _instanceSpreadAngle.Read(reader);
        _instanceRotationPeriod.Read(reader);
        _unnamed1.Read(reader);
        _materialEffects.Read(reader);
        _bitmap.Read(reader);
        _unnamed2.Read(reader);
        _data.Read(reader);
        _data2.Read(reader);
        _verticalNegativeScale.Read(reader);
        _data3.Read(reader);
        _unnamed3.Read(reader);
        _octave1Frequency.Read(reader);
        _octave2Frequency.Read(reader);
        _octave3Frequency.Read(reader);
        _octave4Frequency.Read(reader);
        _octave5Frequency.Read(reader);
        _octave6Frequency.Read(reader);
        _octave7Frequency.Read(reader);
        _octave8Frequency.Read(reader);
        _octave9Frequency.Read(reader);
        _unnamed4.Read(reader);
        _octaveFlags.Read(reader);
        _unnamed5.Read(reader);
        _cores.Read(reader);
        _data4.Read(reader);
        _data5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _materialEffects.ReadString(reader);
        _bitmap.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cores.Count); x = (x + 1)) {
          Cores.Add(new LiquidCoreBlockBlock());
          Cores[x].Read(reader);
        }
        for (x = 0; (x < _cores.Count); x = (x + 1)) {
          Cores[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4.Add(new ByteBlockBlock());
          Data4[x].Read(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5.Add(new ByteBlockBlock());
          Data5[x].Read(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _spriteCount.Write(bw);
        _naturalLength.Write(bw);
        _instances.Write(bw);
        _unnamed0.Write(bw);
        _instanceSpreadAngle.Write(bw);
        _instanceRotationPeriod.Write(bw);
        _unnamed1.Write(bw);
        _materialEffects.Write(bw);
        _bitmap.Write(bw);
        _unnamed2.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _verticalNegativeScale.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
        _unnamed3.Write(bw);
        _octave1Frequency.Write(bw);
        _octave2Frequency.Write(bw);
        _octave3Frequency.Write(bw);
        _octave4Frequency.Write(bw);
        _octave5Frequency.Write(bw);
        _octave6Frequency.Write(bw);
        _octave7Frequency.Write(bw);
        _octave8Frequency.Write(bw);
        _octave9Frequency.Write(bw);
        _unnamed4.Write(bw);
        _octaveFlags.Write(bw);
        _unnamed5.Write(bw);
_cores.Count = Cores.Count;
        _cores.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
_data5.Count = Data5.Count;
        _data5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _materialEffects.WriteString(writer);
        _bitmap.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cores.Count); x = (x + 1)) {
          Cores[x].Write(writer);
        }
        for (x = 0; (x < _cores.Count); x = (x + 1)) {
          Cores[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].Write(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].Write(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].WriteChildData(writer);
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
    public class LiquidCoreBlockBlock : IBlock {
      private Pad _unnamed0;
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed1;
      private Block _data = new Block();
      private Block _data2 = new Block();
      private Block _data3 = new Block();
      private Block _data4 = new Block();
      private Block _data5 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LiquidCoreBlockBlock() {
        this._unnamed0 = new Pad(12);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data3 {
        get {
          return this._data3List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data4 {
        get {
          return this._data4List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data5 {
        get {
          return this._data5List;
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
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data3.BlockCount; x++)
{
  IBlock block = Data3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data4.BlockCount; x++)
{
  IBlock block = Data4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data5.BlockCount; x++)
{
  IBlock block = Data5.GetBlock(x);
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
      public ShortInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _bitmapIndex.Read(reader);
        _unnamed1.Read(reader);
        _data.Read(reader);
        _data2.Read(reader);
        _data3.Read(reader);
        _data4.Read(reader);
        _data5.Read(reader);
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
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4.Add(new ByteBlockBlock());
          Data4[x].Read(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5.Add(new ByteBlockBlock());
          Data5[x].Read(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _bitmapIndex.Write(bw);
        _unnamed1.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
_data5.Count = Data5.Count;
        _data5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].Write(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].Write(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].WriteChildData(writer);
        }
      }
    }
  }
}
