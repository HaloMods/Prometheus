// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'light_volume'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class light_volume : Interfaces.Pool.Tag {
    private LightVolumeBlockBlock lightVolumeValues = new LightVolumeBlockBlock();
    public virtual LightVolumeBlockBlock LightVolumeValues {
      get {
        return lightVolumeValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LightVolumeValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "light_volume";
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
lightVolumeValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lightVolumeValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lightVolumeValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lightVolumeValues.WriteChildData(writer);
    }
    #endregion
    public class LightVolumeBlockBlock : IBlock {
      private Real _falloffDistanceFromCamera = new Real();
      private Real _cutoffDistanceFromCamera = new Real();
      private Block _volumes = new Block();
      public BlockCollection<LightVolumeVolumeBlockBlock> _volumesList = new BlockCollection<LightVolumeVolumeBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightVolumeBlockBlock() {
      }
      public BlockCollection<LightVolumeVolumeBlockBlock> Volumes {
        get {
          return this._volumesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Volumes.BlockCount; x++)
{
  IBlock block = Volumes.GetBlock(x);
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
        _falloffDistanceFromCamera.Read(reader);
        _cutoffDistanceFromCamera.Read(reader);
        _volumes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _volumes.Count); x = (x + 1)) {
          Volumes.Add(new LightVolumeVolumeBlockBlock());
          Volumes[x].Read(reader);
        }
        for (x = 0; (x < _volumes.Count); x = (x + 1)) {
          Volumes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _falloffDistanceFromCamera.Write(bw);
        _cutoffDistanceFromCamera.Write(bw);
_volumes.Count = Volumes.Count;
        _volumes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _volumes.Count); x = (x + 1)) {
          Volumes[x].Write(writer);
        }
        for (x = 0; (x < _volumes.Count); x = (x + 1)) {
          Volumes[x].WriteChildData(writer);
        }
      }
    }
    public class LightVolumeVolumeBlockBlock : IBlock {
      private Flags _flags;
      private TagReference _bitmap = new TagReference();
      private LongInteger _spriteCount = new LongInteger();
      private Block _data = new Block();
      private Block _data2 = new Block();
      private Block _data3 = new Block();
      private Block _data4 = new Block();
      private Block _data5 = new Block();
      private Block _aspect = new Block();
      private RealFraction _radiusFracMin = new RealFraction();
      private RealFraction _dEPRECATEDX_MinusstepExponent = new RealFraction();
      private LongInteger _dEPRECATEDX_MinusbufferLength = new LongInteger();
      private LongInteger _x_MinusbufferSpacing = new LongInteger();
      private LongInteger _x_MinusbufferMinIterations = new LongInteger();
      private LongInteger _x_MinusbufferMaxIterations = new LongInteger();
      private RealFraction _x_MinusdeltaMaxError = new RealFraction();
      private Skip _unnamed0;
      private Block _emptyname = new Block();
      private Skip _unnamed1;
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<LightVolumeAspectBlockBlock> _aspectList = new BlockCollection<LightVolumeAspectBlockBlock>();
      public BlockCollection<LightVolumeRuntimeOffsetBlockBlock> _emptynameList = new BlockCollection<LightVolumeRuntimeOffsetBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightVolumeVolumeBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(48);
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
      public BlockCollection<LightVolumeAspectBlockBlock> Aspect {
        get {
          return this._aspectList;
        }
      }
      public BlockCollection<LightVolumeRuntimeOffsetBlockBlock> Emptyname {
        get {
          return this._emptynameList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
for (int x=0; x<Aspect.BlockCount; x++)
{
  IBlock block = Aspect.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Emptyname.BlockCount; x++)
{
  IBlock block = Emptyname.GetBlock(x);
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
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public LongInteger SpriteCount {
        get {
          return this._spriteCount;
        }
        set {
          this._spriteCount = value;
        }
      }
      public RealFraction RadiusFracMin {
        get {
          return this._radiusFracMin;
        }
        set {
          this._radiusFracMin = value;
        }
      }
      public RealFraction DEPRECATEDX_MinusstepExponent {
        get {
          return this._dEPRECATEDX_MinusstepExponent;
        }
        set {
          this._dEPRECATEDX_MinusstepExponent = value;
        }
      }
      public LongInteger DEPRECATEDX_MinusbufferLength {
        get {
          return this._dEPRECATEDX_MinusbufferLength;
        }
        set {
          this._dEPRECATEDX_MinusbufferLength = value;
        }
      }
      public LongInteger X_MinusbufferSpacing {
        get {
          return this._x_MinusbufferSpacing;
        }
        set {
          this._x_MinusbufferSpacing = value;
        }
      }
      public LongInteger X_MinusbufferMinIterations {
        get {
          return this._x_MinusbufferMinIterations;
        }
        set {
          this._x_MinusbufferMinIterations = value;
        }
      }
      public LongInteger X_MinusbufferMaxIterations {
        get {
          return this._x_MinusbufferMaxIterations;
        }
        set {
          this._x_MinusbufferMaxIterations = value;
        }
      }
      public RealFraction X_MinusdeltaMaxError {
        get {
          return this._x_MinusdeltaMaxError;
        }
        set {
          this._x_MinusdeltaMaxError = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bitmap.Read(reader);
        _spriteCount.Read(reader);
        _data.Read(reader);
        _data2.Read(reader);
        _data3.Read(reader);
        _data4.Read(reader);
        _data5.Read(reader);
        _aspect.Read(reader);
        _radiusFracMin.Read(reader);
        _dEPRECATEDX_MinusstepExponent.Read(reader);
        _dEPRECATEDX_MinusbufferLength.Read(reader);
        _x_MinusbufferSpacing.Read(reader);
        _x_MinusbufferMinIterations.Read(reader);
        _x_MinusbufferMaxIterations.Read(reader);
        _x_MinusdeltaMaxError.Read(reader);
        _unnamed0.Read(reader);
        _emptyname.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
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
        for (x = 0; (x < _aspect.Count); x = (x + 1)) {
          Aspect.Add(new LightVolumeAspectBlockBlock());
          Aspect[x].Read(reader);
        }
        for (x = 0; (x < _aspect.Count); x = (x + 1)) {
          Aspect[x].ReadChildData(reader);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname.Add(new LightVolumeRuntimeOffsetBlockBlock());
          Emptyname[x].Read(reader);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bitmap.Write(bw);
        _spriteCount.Write(bw);
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
_aspect.Count = Aspect.Count;
        _aspect.Write(bw);
        _radiusFracMin.Write(bw);
        _dEPRECATEDX_MinusstepExponent.Write(bw);
        _dEPRECATEDX_MinusbufferLength.Write(bw);
        _x_MinusbufferSpacing.Write(bw);
        _x_MinusbufferMinIterations.Write(bw);
        _x_MinusbufferMaxIterations.Write(bw);
        _x_MinusdeltaMaxError.Write(bw);
        _unnamed0.Write(bw);
_emptyname.Count = Emptyname.Count;
        _emptyname.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
        for (x = 0; (x < _aspect.Count); x = (x + 1)) {
          Aspect[x].Write(writer);
        }
        for (x = 0; (x < _aspect.Count); x = (x + 1)) {
          Aspect[x].WriteChildData(writer);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].Write(writer);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].WriteChildData(writer);
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
    public class LightVolumeAspectBlockBlock : IBlock {
      private Block _data = new Block();
      private Block _data2 = new Block();
      private Real _parallelScale = new Real();
      private Angle _parallelThresholdAngle = new Angle();
      private Real _parallelExponent = new Real();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightVolumeAspectBlockBlock() {
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Real ParallelScale {
        get {
          return this._parallelScale;
        }
        set {
          this._parallelScale = value;
        }
      }
      public Angle ParallelThresholdAngle {
        get {
          return this._parallelThresholdAngle;
        }
        set {
          this._parallelThresholdAngle = value;
        }
      }
      public Real ParallelExponent {
        get {
          return this._parallelExponent;
        }
        set {
          this._parallelExponent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
        _data2.Read(reader);
        _parallelScale.Read(reader);
        _parallelThresholdAngle.Read(reader);
        _parallelExponent.Read(reader);
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
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _parallelScale.Write(bw);
        _parallelThresholdAngle.Write(bw);
        _parallelExponent.Write(bw);
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
      }
    }
    public class LightVolumeRuntimeOffsetBlockBlock : IBlock {
      private RealVector2D _unnamed0 = new RealVector2D();
public event System.EventHandler BlockNameChanged;
      public LightVolumeRuntimeOffsetBlockBlock() {
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
      public RealVector2D unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
