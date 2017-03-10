// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'unicode_string_list'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class unicode_string_list : Interfaces.Pool.Tag {
    private UnicodeStringListBlock unicodeStringListValues = new UnicodeStringListBlock();
    public virtual UnicodeStringListBlock UnicodeStringListValues {
      get {
        return unicodeStringListValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UnicodeStringListValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "unicode_string_list";
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
unicodeStringListValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
unicodeStringListValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
unicodeStringListValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
unicodeStringListValues.WriteChildData(writer);
    }
    #endregion
    public class UnicodeStringListBlock : IBlock {
      private Block _stringReferences = new Block();
      public BlockCollection<StringreferenceBlock> _stringReferencesList = new BlockCollection<StringreferenceBlock>();
public event System.EventHandler BlockNameChanged;
      public UnicodeStringListBlock() {
      }
      public BlockCollection<StringreferenceBlock> StringReferences {
        get {
          return this._stringReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<StringReferences.BlockCount; x++)
{
  IBlock block = StringReferences.GetBlock(x);
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
        _stringReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences.Add(new StringreferenceBlock());
          StringReferences[x].Read(reader);
        }
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_stringReferences.Count = StringReferences.Count;
        _stringReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].Write(writer);
        }
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].WriteChildData(writer);
        }
      }
    }
    public class StringreferenceBlock : IBlock {
      private Data _string = new Data();
public event System.EventHandler BlockNameChanged;
      public StringreferenceBlock() {
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
      public Data String {
        get {
          return this._string;
        }
        set {
          this._string = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _string.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _string.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _string.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _string.WriteBinary(writer);
      }
    }
  }
}
