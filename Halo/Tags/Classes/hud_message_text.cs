// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'hud_message_text'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class hud_message_text : Interfaces.Pool.Tag {
    private HudMessageTextBlock hudMessageTextValues = new HudMessageTextBlock();
    public virtual HudMessageTextBlock HudMessageTextValues {
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
    public class HudMessageTextBlock : IBlock {
      private Data _textData = new Data();
      private Block _messageElements = new Block();
      private Block _messages = new Block();
      private Pad _unnamed;
      public BlockCollection<HudMessageElementsBlock> _messageElementsList = new BlockCollection<HudMessageElementsBlock>();
      public BlockCollection<HudMessagesBlock> _messagesList = new BlockCollection<HudMessagesBlock>();
public event System.EventHandler BlockNameChanged;
      public HudMessageTextBlock() {
        this._unnamed = new Pad(84);
      }
      public BlockCollection<HudMessageElementsBlock> MessageElements {
        get {
          return this._messageElementsList;
        }
      }
      public BlockCollection<HudMessagesBlock> Messages {
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _textData.ReadBinary(reader);
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements.Add(new HudMessageElementsBlock());
          MessageElements[x].Read(reader);
        }
        for (x = 0; (x < _messageElements.Count); x = (x + 1)) {
          MessageElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _messages.Count); x = (x + 1)) {
          Messages.Add(new HudMessagesBlock());
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
        _unnamed.Write(bw);
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
    public class HudMessageElementsBlock : IBlock {
      private CharInteger _type = new CharInteger();
      private CharInteger _data = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public HudMessageElementsBlock() {
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
    public class HudMessagesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortInteger _startIndexIntoTextBlob = new ShortInteger();
      private ShortInteger _startIndexOfMessageBlock = new ShortInteger();
      private CharInteger _panelCount = new CharInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public HudMessagesBlock() {
        this._unnamed = new Pad(3);
        this._unnamed2 = new Pad(24);
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
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _startIndexIntoTextBlob.Write(bw);
        _startIndexOfMessageBlock.Write(bw);
        _panelCount.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
