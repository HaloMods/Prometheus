// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'vertex_shader'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class vertex_shader : Interfaces.Pool.Tag {
    private VertexShaderBlockBlock vertexShaderValues = new VertexShaderBlockBlock();
    public virtual VertexShaderBlockBlock VertexShaderValues {
      get {
        return vertexShaderValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(VertexShaderValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "vertex_shader";
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
vertexShaderValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
vertexShaderValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
vertexShaderValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
vertexShaderValues.WriteChildData(writer);
    }
    #endregion
    public class VertexShaderBlockBlock : IBlock {
      private Enum _platform;
      private Pad _unnamed0;
      private Block _geometryClassifications = new Block();
      public BlockCollection<VertexShaderClassificationBlockBlock> _geometryClassificationsList = new BlockCollection<VertexShaderClassificationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public VertexShaderBlockBlock() {
        this._platform = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<VertexShaderClassificationBlockBlock> GeometryClassifications {
        get {
          return this._geometryClassificationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<GeometryClassifications.BlockCount; x++)
{
  IBlock block = GeometryClassifications.GetBlock(x);
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
      public Enum Platform {
        get {
          return this._platform;
        }
        set {
          this._platform = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _platform.Read(reader);
        _unnamed0.Read(reader);
        _geometryClassifications.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _geometryClassifications.Count); x = (x + 1)) {
          GeometryClassifications.Add(new VertexShaderClassificationBlockBlock());
          GeometryClassifications[x].Read(reader);
        }
        for (x = 0; (x < _geometryClassifications.Count); x = (x + 1)) {
          GeometryClassifications[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _platform.Write(bw);
        _unnamed0.Write(bw);
_geometryClassifications.Count = GeometryClassifications.Count;
        _geometryClassifications.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _geometryClassifications.Count); x = (x + 1)) {
          GeometryClassifications[x].Write(writer);
        }
        for (x = 0; (x < _geometryClassifications.Count); x = (x + 1)) {
          GeometryClassifications[x].WriteChildData(writer);
        }
      }
    }
    public class VertexShaderClassificationBlockBlock : IBlock {
      private Pad _unnamed0;
      private Block _indexBlock = new Block();
      private Block _byteBlock = new Block();
      private Skip _unnamed1;
      public BlockCollection<IndexBlockHandcodedBlock> _indexBlockList = new BlockCollection<IndexBlockHandcodedBlock>();
      public BlockCollection<ByteBlockHandcodedBlock> _byteBlockList = new BlockCollection<ByteBlockHandcodedBlock>();
public event System.EventHandler BlockNameChanged;
      public VertexShaderClassificationBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Skip(8);
      }
      public BlockCollection<IndexBlockHandcodedBlock> IndexBlock {
        get {
          return this._indexBlockList;
        }
      }
      public BlockCollection<ByteBlockHandcodedBlock> ByteBlock {
        get {
          return this._byteBlockList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<IndexBlock.BlockCount; x++)
{
  IBlock block = IndexBlock.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ByteBlock.BlockCount; x++)
{
  IBlock block = ByteBlock.GetBlock(x);
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
        _unnamed0.Read(reader);
        _indexBlock.Read(reader);
        _byteBlock.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _indexBlock.Count); x = (x + 1)) {
          IndexBlock.Add(new IndexBlockHandcodedBlock());
          IndexBlock[x].Read(reader);
        }
        for (x = 0; (x < _indexBlock.Count); x = (x + 1)) {
          IndexBlock[x].ReadChildData(reader);
        }
        for (x = 0; (x < _byteBlock.Count); x = (x + 1)) {
          ByteBlock.Add(new ByteBlockHandcodedBlock());
          ByteBlock[x].Read(reader);
        }
        for (x = 0; (x < _byteBlock.Count); x = (x + 1)) {
          ByteBlock[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
_indexBlock.Count = IndexBlock.Count;
        _indexBlock.Write(bw);
_byteBlock.Count = ByteBlock.Count;
        _byteBlock.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _indexBlock.Count); x = (x + 1)) {
          IndexBlock[x].Write(writer);
        }
        for (x = 0; (x < _indexBlock.Count); x = (x + 1)) {
          IndexBlock[x].WriteChildData(writer);
        }
        for (x = 0; (x < _byteBlock.Count); x = (x + 1)) {
          ByteBlock[x].Write(writer);
        }
        for (x = 0; (x < _byteBlock.Count); x = (x + 1)) {
          ByteBlock[x].WriteChildData(writer);
        }
      }
    }
    public class IndexBlockHandcodedBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public IndexBlockHandcodedBlock() {
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
      public ShortInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _index.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _index.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ByteBlockHandcodedBlock : IBlock {
      private CharInteger _index = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockHandcodedBlock() {
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
      public CharInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _index.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _index.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
