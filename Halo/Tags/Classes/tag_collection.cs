// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'tag_collection'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class tag_collection : Interfaces.Pool.Tag {
    private TagCollectionBlock tagCollectionValues = new TagCollectionBlock();
    public virtual TagCollectionBlock TagCollectionValues {
      get {
        return tagCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(TagCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "tag_collection";
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
tagCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
tagCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
tagCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
tagCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class TagCollectionBlock : IBlock {
      private Block _tagReferences = new Block();
      public BlockCollection<TagreferenceBlock> _tagReferencesList = new BlockCollection<TagreferenceBlock>();
public event System.EventHandler BlockNameChanged;
      public TagCollectionBlock() {
      }
      public BlockCollection<TagreferenceBlock> TagReferences {
        get {
          return this._tagReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<TagReferences.BlockCount; x++)
{
  IBlock block = TagReferences.GetBlock(x);
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
        _tagReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _tagReferences.Count); x = (x + 1)) {
          TagReferences.Add(new TagreferenceBlock());
          TagReferences[x].Read(reader);
        }
        for (x = 0; (x < _tagReferences.Count); x = (x + 1)) {
          TagReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_tagReferences.Count = TagReferences.Count;
        _tagReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _tagReferences.Count); x = (x + 1)) {
          TagReferences[x].Write(writer);
        }
        for (x = 0; (x < _tagReferences.Count); x = (x + 1)) {
          TagReferences[x].WriteChildData(writer);
        }
      }
    }
    public class TagreferenceBlock : IBlock {
      private TagReference _tag = new TagReference();
public event System.EventHandler BlockNameChanged;
      public TagreferenceBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_tag.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Tag {
        get {
          return this._tag;
        }
        set {
          this._tag = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _tag.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _tag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _tag.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _tag.WriteString(writer);
      }
    }
  }
}
