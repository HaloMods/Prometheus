// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'text_value_pair_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class text_value_pair_definition : Interfaces.Pool.Tag {
    private TextValuePairDefinitionBlockBlock textValuePairDefinitionValues = new TextValuePairDefinitionBlockBlock();
    public virtual TextValuePairDefinitionBlockBlock TextValuePairDefinitionValues {
      get {
        return textValuePairDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(TextValuePairDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "text_value_pair_definition";
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
textValuePairDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
textValuePairDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
textValuePairDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
textValuePairDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class TextValuePairDefinitionBlockBlock : IBlock {
      private Enum _parameter;
      private Pad _unnamed0;
      private TagReference _stringList = new TagReference();
      private StringId _titleText = new StringId();
      private StringId _headerText = new StringId();
      private StringId _descriptionText = new StringId();
      private Block _textValuePairs = new Block();
      public BlockCollection<TextValuePairReferenceBlockBlock> _textValuePairsList = new BlockCollection<TextValuePairReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public TextValuePairDefinitionBlockBlock() {
        this._parameter = new Enum(4);
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<TextValuePairReferenceBlockBlock> TextValuePairs {
        get {
          return this._textValuePairsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_stringList.Value);
for (int x=0; x<TextValuePairs.BlockCount; x++)
{
  IBlock block = TextValuePairs.GetBlock(x);
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
      public Enum Parameter {
        get {
          return this._parameter;
        }
        set {
          this._parameter = value;
        }
      }
      public TagReference StringList {
        get {
          return this._stringList;
        }
        set {
          this._stringList = value;
        }
      }
      public StringId TitleText {
        get {
          return this._titleText;
        }
        set {
          this._titleText = value;
        }
      }
      public StringId HeaderText {
        get {
          return this._headerText;
        }
        set {
          this._headerText = value;
        }
      }
      public StringId DescriptionText {
        get {
          return this._descriptionText;
        }
        set {
          this._descriptionText = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameter.Read(reader);
        _unnamed0.Read(reader);
        _stringList.Read(reader);
        _titleText.Read(reader);
        _headerText.Read(reader);
        _descriptionText.Read(reader);
        _textValuePairs.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _stringList.ReadString(reader);
        _titleText.ReadString(reader);
        _headerText.ReadString(reader);
        _descriptionText.ReadString(reader);
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs.Add(new TextValuePairReferenceBlockBlock());
          TextValuePairs[x].Read(reader);
        }
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _parameter.Write(bw);
        _unnamed0.Write(bw);
        _stringList.Write(bw);
        _titleText.Write(bw);
        _headerText.Write(bw);
        _descriptionText.Write(bw);
_textValuePairs.Count = TextValuePairs.Count;
        _textValuePairs.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _stringList.WriteString(writer);
        _titleText.WriteString(writer);
        _headerText.WriteString(writer);
        _descriptionText.WriteString(writer);
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].Write(writer);
        }
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].WriteChildData(writer);
        }
      }
    }
    public class TextValuePairReferenceBlockBlock : IBlock {
      private Flags _flags;
      private LongInteger _value = new LongInteger();
      private StringId _labelStringId = new StringId();
public event System.EventHandler BlockNameChanged;
      public TextValuePairReferenceBlockBlock() {
        this._flags = new Flags(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public LongInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public StringId LabelStringId {
        get {
          return this._labelStringId;
        }
        set {
          this._labelStringId = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _value.Read(reader);
        _labelStringId.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _labelStringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _value.Write(bw);
        _labelStringId.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _labelStringId.WriteString(writer);
      }
    }
  }
}
