// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'hud_message_text'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class hud_message_text : Interfaces.Pool.Tag {
    private HudMessageTextBlockBlock hudMessageTextValues = new HudMessageTextBlockBlock();
    public virtual HudMessageTextBlockBlock HudMessageTextValues {
      get {
        return hudMessageTextValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(HudMessageTextValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "hud_message_text";
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
hudMessageTextValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
hudMessageTextValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
hudMessageTextValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
hudMessageTextValues.WriteChildData(writer);
    }
    #endregion
    public class HudMessageTextBlockBlock : IBlock {
      private Data _textData = new Data();
      private Block _messageElements = new Block();
      private Block _messages = new Block();
      private Pad _unnamed0;
      public BlockCollection<HudMessageElementsBlockBlock> _messageElementsList = new BlockCollection<HudMessageElementsBlockBlock>();
      public BlockCollection<HudMessagesBlockBlock> _messagesList = new BlockCollection<HudMessagesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public HudMessageTextBlockBlock() {
        this._unnamed0 = new Pad(84);
      }
      public BlockCollection<HudMessageElementsBlockBlock> MessageElements {
        get {
          return this._messageElementsList;
        }
      }
      public BlockCollection<HudMessagesBlockBlock> Messages {
        get {
          return this._messagesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<MessageElements.BlockCount; x++)
{
  IBlock block = MessageElements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Messages.BlockCount; x++)
{
  IBlock block = Messages.GetBlock(x);
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
      public Data TextData {
        get {
          return this._textData;
        }
        set {
          this._textData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _textData.Read(reader);
        _messageElements.Read(reader);
        _messages.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _textData.ReadBinary(reader);
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements.Add(new HudMessageElementsBlockBlock());
          MessageElements[x].Read(reader);
        }
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _messages.Count); x = (x + 1)) {
          Messages.Add(new HudMessagesBlockBlock());
          Messages[x].Read(reader);
        }
        for (x = 0; (x < _messages.Count); x = (x + 1)) {
          Messages[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _textData.Write(bw);
_messageElements.Count = MessageElements.Count;
        _messageElements.Write(bw);
_messages.Count = Messages.Count;
        _messages.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _textData.WriteBinary(writer);
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements[x].Write(writer);
        }
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _messages.Count); x = (x + 1)) {
          Messages[x].Write(writer);
        }
        for (x = 0; (x < _messages.Count); x = (x + 1)) {
          Messages[x].WriteChildData(writer);
        }
      }
    }
    public class HudMessageElementsBlockBlock : IBlock {
      private CharInteger _type = new CharInteger();
      private CharInteger _data = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public HudMessageElementsBlockBlock() {
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
      public CharInteger Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public CharInteger Data {
        get {
          return this._data;
        }
        set {
          this._data = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HudMessagesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortInteger _startIndexIntoTextBlob = new ShortInteger();
      private ShortInteger _startIndexOfMessageBlock = new ShortInteger();
      private CharInteger _panelCount = new CharInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public HudMessagesBlockBlock() {
        this._unnamed0 = new Pad(3);
        this._unnamed1 = new Pad(24);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger StartIndexIntoTextBlob {
        get {
          return this._startIndexIntoTextBlob;
        }
        set {
          this._startIndexIntoTextBlob = value;
        }
      }
      public ShortInteger StartIndexOfMessageBlock {
        get {
          return this._startIndexOfMessageBlock;
        }
        set {
          this._startIndexOfMessageBlock = value;
        }
      }
      public CharInteger PanelCount {
        get {
          return this._panelCount;
        }
        set {
          this._panelCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _startIndexIntoTextBlob.Read(reader);
        _startIndexOfMessageBlock.Read(reader);
        _panelCount.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _startIndexIntoTextBlob.Write(bw);
        _startIndexOfMessageBlock.Write(bw);
        _panelCount.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
