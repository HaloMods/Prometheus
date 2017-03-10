// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'ai_mission_dialogue'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class ai_mission_dialogue : Interfaces.Pool.Tag {
    private AiMissionDialogueBlockBlock aiMissionDialogueValues = new AiMissionDialogueBlockBlock();
    public virtual AiMissionDialogueBlockBlock AiMissionDialogueValues {
      get {
        return aiMissionDialogueValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(AiMissionDialogueValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "ai_mission_dialogue";
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
aiMissionDialogueValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
aiMissionDialogueValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
aiMissionDialogueValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
aiMissionDialogueValues.WriteChildData(writer);
    }
    #endregion
    public class AiMissionDialogueBlockBlock : IBlock {
      private Block _lines = new Block();
      public BlockCollection<MissionDialogueLinesBlockBlock> _linesList = new BlockCollection<MissionDialogueLinesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiMissionDialogueBlockBlock() {
      }
      public BlockCollection<MissionDialogueLinesBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
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
        _lines.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new MissionDialogueLinesBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_lines.Count = Lines.Count;
        _lines.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
      }
    }
    public class MissionDialogueLinesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _variants = new Block();
      private StringId _defaultSoundEffect = new StringId();
      public BlockCollection<MissionDialogueVariantsBlockBlock> _variantsList = new BlockCollection<MissionDialogueVariantsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MissionDialogueLinesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<MissionDialogueVariantsBlockBlock> Variants {
        get {
          return this._variantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Variants.BlockCount; x++)
{
  IBlock block = Variants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public StringId DefaultSoundEffect {
        get {
          return this._defaultSoundEffect;
        }
        set {
          this._defaultSoundEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _variants.Read(reader);
        _defaultSoundEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants.Add(new MissionDialogueVariantsBlockBlock());
          Variants[x].Read(reader);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].ReadChildData(reader);
        }
        _defaultSoundEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_variants.Count = Variants.Count;
        _variants.Write(bw);
        _defaultSoundEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].Write(writer);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].WriteChildData(writer);
        }
        _defaultSoundEffect.WriteString(writer);
      }
    }
    public class MissionDialogueVariantsBlockBlock : IBlock {
      private StringId _variantDesignation = new StringId();
      private TagReference _sound = new TagReference();
      private StringId _soundEffect = new StringId();
public event System.EventHandler BlockNameChanged;
      public MissionDialogueVariantsBlockBlock() {
if (this._variantDesignation is System.ComponentModel.INotifyPropertyChanged)
  (this._variantDesignation as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
return _variantDesignation.ToString();
        }
      }
      public StringId VariantDesignation {
        get {
          return this._variantDesignation;
        }
        set {
          this._variantDesignation = value;
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
      public StringId SoundEffect {
        get {
          return this._soundEffect;
        }
        set {
          this._soundEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _variantDesignation.Read(reader);
        _sound.Read(reader);
        _soundEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantDesignation.ReadString(reader);
        _sound.ReadString(reader);
        _soundEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _variantDesignation.Write(bw);
        _sound.Write(bw);
        _soundEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantDesignation.WriteString(writer);
        _sound.WriteString(writer);
        _soundEffect.WriteString(writer);
      }
    }
  }
}
