// -----------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'multilingual_unicode_string_list'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -----------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class multilingual_unicode_string_list : Interfaces.Pool.Tag {
    private MultilingualUnicodeStringListBlockBlock multilingualUnicodeStringListValues = new MultilingualUnicodeStringListBlockBlock();
    public virtual MultilingualUnicodeStringListBlockBlock MultilingualUnicodeStringListValues {
      get {
        return multilingualUnicodeStringListValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MultilingualUnicodeStringListValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "multilingual_unicode_string_list";
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
multilingualUnicodeStringListValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
multilingualUnicodeStringListValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
multilingualUnicodeStringListValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
multilingualUnicodeStringListValues.WriteChildData(writer);
    }
    #endregion
    public class MultilingualUnicodeStringListBlockBlock : IBlock {
      private Block _stringReferences = new Block();
      private Data _stringDataUtf8 = new Data();
      private Pad _unnamed0;
      public BlockCollection<MultilingualUnicodeStringReferenceBlockBlock> _stringReferencesList = new BlockCollection<MultilingualUnicodeStringReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultilingualUnicodeStringListBlockBlock() {
        this._unnamed0 = new Pad(36);
      }
      public BlockCollection<MultilingualUnicodeStringReferenceBlockBlock> StringReferences {
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
      public Data StringDataUtf8 {
        get {
          return this._stringDataUtf8;
        }
        set {
          this._stringDataUtf8 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stringReferences.Read(reader);
        _stringDataUtf8.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences.Add(new MultilingualUnicodeStringReferenceBlockBlock());
          StringReferences[x].Read(reader);
        }
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].ReadChildData(reader);
        }
        _stringDataUtf8.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
_stringReferences.Count = StringReferences.Count;
        _stringReferences.Write(bw);
        _stringDataUtf8.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].Write(writer);
        }
        for (x = 0; (x < _stringReferences.Count); x = (x + 1)) {
          StringReferences[x].WriteChildData(writer);
        }
        _stringDataUtf8.WriteBinary(writer);
      }
    }
    public class MultilingualUnicodeStringReferenceBlockBlock : IBlock {
      private StringId _stringId = new StringId();
      private LongInteger _englishOffset = new LongInteger();
      private LongInteger _japaneseOffset = new LongInteger();
      private LongInteger _germanOffset = new LongInteger();
      private LongInteger _frenchOffset = new LongInteger();
      private LongInteger _spanishOffset = new LongInteger();
      private LongInteger _italianOffset = new LongInteger();
      private LongInteger _koreanOffset = new LongInteger();
      private LongInteger _chineseOffset = new LongInteger();
      private LongInteger _portugueseOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public MultilingualUnicodeStringReferenceBlockBlock() {
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
      public StringId StringId {
        get {
          return this._stringId;
        }
        set {
          this._stringId = value;
        }
      }
      public LongInteger EnglishOffset {
        get {
          return this._englishOffset;
        }
        set {
          this._englishOffset = value;
        }
      }
      public LongInteger JapaneseOffset {
        get {
          return this._japaneseOffset;
        }
        set {
          this._japaneseOffset = value;
        }
      }
      public LongInteger GermanOffset {
        get {
          return this._germanOffset;
        }
        set {
          this._germanOffset = value;
        }
      }
      public LongInteger FrenchOffset {
        get {
          return this._frenchOffset;
        }
        set {
          this._frenchOffset = value;
        }
      }
      public LongInteger SpanishOffset {
        get {
          return this._spanishOffset;
        }
        set {
          this._spanishOffset = value;
        }
      }
      public LongInteger ItalianOffset {
        get {
          return this._italianOffset;
        }
        set {
          this._italianOffset = value;
        }
      }
      public LongInteger KoreanOffset {
        get {
          return this._koreanOffset;
        }
        set {
          this._koreanOffset = value;
        }
      }
      public LongInteger ChineseOffset {
        get {
          return this._chineseOffset;
        }
        set {
          this._chineseOffset = value;
        }
      }
      public LongInteger PortugueseOffset {
        get {
          return this._portugueseOffset;
        }
        set {
          this._portugueseOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stringId.Read(reader);
        _englishOffset.Read(reader);
        _japaneseOffset.Read(reader);
        _germanOffset.Read(reader);
        _frenchOffset.Read(reader);
        _spanishOffset.Read(reader);
        _italianOffset.Read(reader);
        _koreanOffset.Read(reader);
        _chineseOffset.Read(reader);
        _portugueseOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _stringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _stringId.Write(bw);
        _englishOffset.Write(bw);
        _japaneseOffset.Write(bw);
        _germanOffset.Write(bw);
        _frenchOffset.Write(bw);
        _spanishOffset.Write(bw);
        _italianOffset.Write(bw);
        _koreanOffset.Write(bw);
        _chineseOffset.Write(bw);
        _portugueseOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _stringId.WriteString(writer);
      }
    }
  }
}
