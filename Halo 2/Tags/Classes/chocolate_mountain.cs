// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'chocolate_mountain'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class chocolate_mountain : Interfaces.Pool.Tag {
    private ChocolateMountainBlockBlock chocolateMountainValues = new ChocolateMountainBlockBlock();
    public virtual ChocolateMountainBlockBlock ChocolateMountainValues {
      get {
        return chocolateMountainValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ChocolateMountainValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "chocolate_mountain";
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
chocolateMountainValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
chocolateMountainValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
chocolateMountainValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
chocolateMountainValues.WriteChildData(writer);
    }
    #endregion
    public class ChocolateMountainBlockBlock : IBlock {
      private Block _lightingVariables = new Block();
      public BlockCollection<LightingVariablesBlockBlock> _lightingVariablesList = new BlockCollection<LightingVariablesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ChocolateMountainBlockBlock() {
      }
      public BlockCollection<LightingVariablesBlockBlock> LightingVariables {
        get {
          return this._lightingVariablesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<LightingVariables.BlockCount; x++)
{
  IBlock block = LightingVariables.GetBlock(x);
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
        _lightingVariables.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lightingVariables.Count); x = (x + 1)) {
          LightingVariables.Add(new LightingVariablesBlockBlock());
          LightingVariables[x].Read(reader);
        }
        for (x = 0; (x < _lightingVariables.Count); x = (x + 1)) {
          LightingVariables[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_lightingVariables.Count = LightingVariables.Count;
        _lightingVariables.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lightingVariables.Count); x = (x + 1)) {
          LightingVariables[x].Write(writer);
        }
        for (x = 0; (x < _lightingVariables.Count); x = (x + 1)) {
          LightingVariables[x].WriteChildData(writer);
        }
      }
    }
    public class LightingVariablesBlockBlock : IBlock {
      private Flags _objectAffected;
      private Real _lightmapBrightnessOffset = new Real();
      private RealRGBColor _minLightmapColor = new RealRGBColor();
      private RealRGBColor _maxLightmapColor = new RealRGBColor();
      private Real _exclusionAngleFromUp = new Real();
      private Block _data = new Block();
      private RealRGBColor _minLightmapColor2 = new RealRGBColor();
      private RealRGBColor _maxLightmapColor2 = new RealRGBColor();
      private RealRGBColor _minDiffuseSample = new RealRGBColor();
      private RealRGBColor _maxDiffuseSample = new RealRGBColor();
      private Real _zAxisRotation = new Real();
      private Block _data2 = new Block();
      private RealRGBColor _minLightmapSample = new RealRGBColor();
      private RealRGBColor _maxLightmapSample = new RealRGBColor();
      private Block _data3 = new Block();
      private Block _data4 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightingVariablesBlockBlock() {
        this._objectAffected = new Flags(4);
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Flags ObjectAffected {
        get {
          return this._objectAffected;
        }
        set {
          this._objectAffected = value;
        }
      }
      public Real LightmapBrightnessOffset {
        get {
          return this._lightmapBrightnessOffset;
        }
        set {
          this._lightmapBrightnessOffset = value;
        }
      }
      public RealRGBColor MinLightmapColor {
        get {
          return this._minLightmapColor;
        }
        set {
          this._minLightmapColor = value;
        }
      }
      public RealRGBColor MaxLightmapColor {
        get {
          return this._maxLightmapColor;
        }
        set {
          this._maxLightmapColor = value;
        }
      }
      public Real ExclusionAngleFromUp {
        get {
          return this._exclusionAngleFromUp;
        }
        set {
          this._exclusionAngleFromUp = value;
        }
      }
      public RealRGBColor MinLightmapColor2 {
        get {
          return this._minLightmapColor2;
        }
        set {
          this._minLightmapColor2 = value;
        }
      }
      public RealRGBColor MaxLightmapColor2 {
        get {
          return this._maxLightmapColor2;
        }
        set {
          this._maxLightmapColor2 = value;
        }
      }
      public RealRGBColor MinDiffuseSample {
        get {
          return this._minDiffuseSample;
        }
        set {
          this._minDiffuseSample = value;
        }
      }
      public RealRGBColor MaxDiffuseSample {
        get {
          return this._maxDiffuseSample;
        }
        set {
          this._maxDiffuseSample = value;
        }
      }
      public Real ZAxisRotation {
        get {
          return this._zAxisRotation;
        }
        set {
          this._zAxisRotation = value;
        }
      }
      public RealRGBColor MinLightmapSample {
        get {
          return this._minLightmapSample;
        }
        set {
          this._minLightmapSample = value;
        }
      }
      public RealRGBColor MaxLightmapSample {
        get {
          return this._maxLightmapSample;
        }
        set {
          this._maxLightmapSample = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _objectAffected.Read(reader);
        _lightmapBrightnessOffset.Read(reader);
        _minLightmapColor.Read(reader);
        _maxLightmapColor.Read(reader);
        _exclusionAngleFromUp.Read(reader);
        _data.Read(reader);
        _minLightmapColor2.Read(reader);
        _maxLightmapColor2.Read(reader);
        _minDiffuseSample.Read(reader);
        _maxDiffuseSample.Read(reader);
        _zAxisRotation.Read(reader);
        _data2.Read(reader);
        _minLightmapSample.Read(reader);
        _maxLightmapSample.Read(reader);
        _data3.Read(reader);
        _data4.Read(reader);
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
      }
      public virtual void Write(BinaryWriter bw) {
        _objectAffected.Write(bw);
        _lightmapBrightnessOffset.Write(bw);
        _minLightmapColor.Write(bw);
        _maxLightmapColor.Write(bw);
        _exclusionAngleFromUp.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _minLightmapColor2.Write(bw);
        _maxLightmapColor2.Write(bw);
        _minDiffuseSample.Write(bw);
        _maxDiffuseSample.Write(bw);
        _zAxisRotation.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _minLightmapSample.Write(bw);
        _maxLightmapSample.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
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
  }
}
