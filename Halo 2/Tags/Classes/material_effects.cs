// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'material_effects'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class material_effects : Interfaces.Pool.Tag {
    private MaterialEffectsBlockBlock materialEffectsValues = new MaterialEffectsBlockBlock();
    public virtual MaterialEffectsBlockBlock MaterialEffectsValues {
      get {
        return materialEffectsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MaterialEffectsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "material_effects";
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
materialEffectsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
materialEffectsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
materialEffectsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
materialEffectsValues.WriteChildData(writer);
    }
    #endregion
    public class MaterialEffectsBlockBlock : IBlock {
      private Block _effects = new Block();
      public BlockCollection<MaterialEffectBlockV2Block> _effectsList = new BlockCollection<MaterialEffectBlockV2Block>();
public event System.EventHandler BlockNameChanged;
      public MaterialEffectsBlockBlock() {
      }
      public BlockCollection<MaterialEffectBlockV2Block> Effects {
        get {
          return this._effectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Effects.BlockCount; x++)
{
  IBlock block = Effects.GetBlock(x);
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
        _effects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects.Add(new MaterialEffectBlockV2Block());
          Effects[x].Read(reader);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_effects.Count = Effects.Count;
        _effects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].Write(writer);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].WriteChildData(writer);
        }
      }
    }
    public class MaterialEffectBlockV2Block : IBlock {
      private Block _oldMaterialsDONOTUSE = new Block();
      private Block _sounds = new Block();
      private Block _effects = new Block();
      public BlockCollection<OldMaterialEffectMaterialBlockBlock> _oldMaterialsDONOTUSEList = new BlockCollection<OldMaterialEffectMaterialBlockBlock>();
      public BlockCollection<MaterialEffectMaterialBlockBlock> _soundsList = new BlockCollection<MaterialEffectMaterialBlockBlock>();
      public BlockCollection<MaterialEffectMaterialBlockBlock> _effectsList = new BlockCollection<MaterialEffectMaterialBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MaterialEffectBlockV2Block() {
      }
      public BlockCollection<OldMaterialEffectMaterialBlockBlock> OldMaterialsDONOTUSE {
        get {
          return this._oldMaterialsDONOTUSEList;
        }
      }
      public BlockCollection<MaterialEffectMaterialBlockBlock> Sounds {
        get {
          return this._soundsList;
        }
      }
      public BlockCollection<MaterialEffectMaterialBlockBlock> Effects {
        get {
          return this._effectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<OldMaterialsDONOTUSE.BlockCount; x++)
{
  IBlock block = OldMaterialsDONOTUSE.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sounds.BlockCount; x++)
{
  IBlock block = Sounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Effects.BlockCount; x++)
{
  IBlock block = Effects.GetBlock(x);
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
        _oldMaterialsDONOTUSE.Read(reader);
        _sounds.Read(reader);
        _effects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _oldMaterialsDONOTUSE.Count); x = (x + 1)) {
          OldMaterialsDONOTUSE.Add(new OldMaterialEffectMaterialBlockBlock());
          OldMaterialsDONOTUSE[x].Read(reader);
        }
        for (x = 0; (x < _oldMaterialsDONOTUSE.Count); x = (x + 1)) {
          OldMaterialsDONOTUSE[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new MaterialEffectMaterialBlockBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects.Add(new MaterialEffectMaterialBlockBlock());
          Effects[x].Read(reader);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_oldMaterialsDONOTUSE.Count = OldMaterialsDONOTUSE.Count;
        _oldMaterialsDONOTUSE.Write(bw);
_sounds.Count = Sounds.Count;
        _sounds.Write(bw);
_effects.Count = Effects.Count;
        _effects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _oldMaterialsDONOTUSE.Count); x = (x + 1)) {
          OldMaterialsDONOTUSE[x].Write(writer);
        }
        for (x = 0; (x < _oldMaterialsDONOTUSE.Count); x = (x + 1)) {
          OldMaterialsDONOTUSE[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].Write(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].Write(writer);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].WriteChildData(writer);
        }
      }
    }
    public class OldMaterialEffectMaterialBlockBlock : IBlock {
      private TagReference _effect = new TagReference();
      private TagReference _sound = new TagReference();
      private StringId _materialName = new StringId();
      private Skip _unnamed0;
      private Enum _sweetenerMode;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public OldMaterialEffectMaterialBlockBlock() {
if (this._materialName is System.ComponentModel.INotifyPropertyChanged)
  (this._materialName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Skip(4);
        this._sweetenerMode = new Enum(1);
        this._unnamed1 = new Pad(3);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_effect.Value);
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _materialName.ToString();
        }
      }
      public TagReference Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
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
      public StringId MaterialName {
        get {
          return this._materialName;
        }
        set {
          this._materialName = value;
        }
      }
      public Enum SweetenerMode {
        get {
          return this._sweetenerMode;
        }
        set {
          this._sweetenerMode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _effect.Read(reader);
        _sound.Read(reader);
        _materialName.Read(reader);
        _unnamed0.Read(reader);
        _sweetenerMode.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _effect.ReadString(reader);
        _sound.ReadString(reader);
        _materialName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _effect.Write(bw);
        _sound.Write(bw);
        _materialName.Write(bw);
        _unnamed0.Write(bw);
        _sweetenerMode.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _effect.WriteString(writer);
        _sound.WriteString(writer);
        _materialName.WriteString(writer);
      }
    }
    public class MaterialEffectMaterialBlockBlock : IBlock {
      private TagReference _tagEffectOrSound = new TagReference();
      private TagReference _secondaryTagEffectOrSound = new TagReference();
      private StringId _materialName = new StringId();
      private Skip _unnamed0;
      private Enum _sweetenerMode;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public MaterialEffectMaterialBlockBlock() {
if (this._materialName is System.ComponentModel.INotifyPropertyChanged)
  (this._materialName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Skip(2);
        this._sweetenerMode = new Enum(1);
        this._unnamed1 = new Pad(1);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_tagEffectOrSound.Value);
references.Add(_secondaryTagEffectOrSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _materialName.ToString();
        }
      }
      public TagReference TagEffectOrSound {
        get {
          return this._tagEffectOrSound;
        }
        set {
          this._tagEffectOrSound = value;
        }
      }
      public TagReference SecondaryTagEffectOrSound {
        get {
          return this._secondaryTagEffectOrSound;
        }
        set {
          this._secondaryTagEffectOrSound = value;
        }
      }
      public StringId MaterialName {
        get {
          return this._materialName;
        }
        set {
          this._materialName = value;
        }
      }
      public Enum SweetenerMode {
        get {
          return this._sweetenerMode;
        }
        set {
          this._sweetenerMode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _tagEffectOrSound.Read(reader);
        _secondaryTagEffectOrSound.Read(reader);
        _materialName.Read(reader);
        _unnamed0.Read(reader);
        _sweetenerMode.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _tagEffectOrSound.ReadString(reader);
        _secondaryTagEffectOrSound.ReadString(reader);
        _materialName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _tagEffectOrSound.Write(bw);
        _secondaryTagEffectOrSound.Write(bw);
        _materialName.Write(bw);
        _unnamed0.Write(bw);
        _sweetenerMode.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _tagEffectOrSound.WriteString(writer);
        _secondaryTagEffectOrSound.WriteString(writer);
        _materialName.WriteString(writer);
      }
    }
  }
}
