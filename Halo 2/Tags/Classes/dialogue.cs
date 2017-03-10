// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'dialogue'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class dialogue : Interfaces.Pool.Tag {
    private DialogueBlockBlock dialogueValues = new DialogueBlockBlock();
    public virtual DialogueBlockBlock DialogueValues {
      get {
        return dialogueValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DialogueValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "dialogue";
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
dialogueValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
dialogueValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
dialogueValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
dialogueValues.WriteChildData(writer);
    }
    #endregion
    public class DialogueBlockBlock : IBlock {
      private TagReference _globalDialogueInfo = new TagReference();
      private Flags _flags;
      private Block _vocalizations = new Block();
      private StringId _missionDialogueDesignator = new StringId();
      public BlockCollection<SoundReferencesBlockBlock> _vocalizationsList = new BlockCollection<SoundReferencesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DialogueBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<SoundReferencesBlockBlock> Vocalizations {
        get {
          return this._vocalizationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_globalDialogueInfo.Value);
for (int x=0; x<Vocalizations.BlockCount; x++)
{
  IBlock block = Vocalizations.GetBlock(x);
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
      public TagReference GlobalDialogueInfo {
        get {
          return this._globalDialogueInfo;
        }
        set {
          this._globalDialogueInfo = value;
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
      public StringId MissionDialogueDesignator {
        get {
          return this._missionDialogueDesignator;
        }
        set {
          this._missionDialogueDesignator = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _globalDialogueInfo.Read(reader);
        _flags.Read(reader);
        _vocalizations.Read(reader);
        _missionDialogueDesignator.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _globalDialogueInfo.ReadString(reader);
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations.Add(new SoundReferencesBlockBlock());
          Vocalizations[x].Read(reader);
        }
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].ReadChildData(reader);
        }
        _missionDialogueDesignator.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _globalDialogueInfo.Write(bw);
        _flags.Write(bw);
_vocalizations.Count = Vocalizations.Count;
        _vocalizations.Write(bw);
        _missionDialogueDesignator.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _globalDialogueInfo.WriteString(writer);
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].Write(writer);
        }
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].WriteChildData(writer);
        }
        _missionDialogueDesignator.WriteString(writer);
      }
    }
    public class SoundReferencesBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private StringId _vocalization = new StringId();
      private TagReference _sound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SoundReferencesBlockBlock() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
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
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _vocalization.Read(reader);
        _sound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vocalization.ReadString(reader);
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _vocalization.Write(bw);
        _sound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vocalization.WriteString(writer);
        _sound.WriteString(writer);
      }
    }
  }
}
