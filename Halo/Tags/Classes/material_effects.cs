// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'material_effects'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class material_effects : Interfaces.Pool.Tag {
    private MaterialEffectsBlock materialEffectsValues = new MaterialEffectsBlock();
    public virtual MaterialEffectsBlock MaterialEffectsValues {
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
    public class MaterialEffectsBlock : IBlock {
      private Block _effects = new Block();
      private Pad _unnamed;
      public BlockCollection<MaterialEffectBlock> _effectsList = new BlockCollection<MaterialEffectBlock>();
public event System.EventHandler BlockNameChanged;
      public MaterialEffectsBlock() {
        this._unnamed = new Pad(128);
      }
      public BlockCollection<MaterialEffectBlock> Effects {
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects.Add(new MaterialEffectBlock());
          Effects[x].Read(reader);
        }
        for (x = 0; (x < _effects.Count); x = (x + 1)) {
          Effects[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_effects.Count = Effects.Count;
        _effects.Write(bw);
        _unnamed.Write(bw);
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
    public class MaterialEffectBlock : IBlock {
      private Block _materials = new Block();
      private Pad _unnamed;
      public BlockCollection<MaterialEffectMaterialBlock> _materialsList = new BlockCollection<MaterialEffectMaterialBlock>();
public event System.EventHandler BlockNameChanged;
      public MaterialEffectBlock() {
        this._unnamed = new Pad(16);
      }
      public BlockCollection<MaterialEffectMaterialBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
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
        _materials.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new MaterialEffectMaterialBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_materials.Count = Materials.Count;
        _materials.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
      }
    }
    public class MaterialEffectMaterialBlock : IBlock {
      private TagReference _effect = new TagReference();
      private TagReference _sound = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public MaterialEffectMaterialBlock() {
        this._unnamed = new Pad(16);
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
return "";
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
      public virtual void Read(BinaryReader reader) {
        _effect.Read(reader);
        _sound.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _effect.ReadString(reader);
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _effect.Write(bw);
        _sound.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _effect.WriteString(writer);
        _sound.WriteString(writer);
      }
    }
  }
}
