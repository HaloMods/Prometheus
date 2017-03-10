// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'shader_light_response'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class shader_light_response : Interfaces.Pool.Tag {
    private ShaderLightResponseBlockBlock shaderLightResponseValues = new ShaderLightResponseBlockBlock();
    public virtual ShaderLightResponseBlockBlock ShaderLightResponseValues {
      get {
        return shaderLightResponseValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ShaderLightResponseValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_light_response";
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
shaderLightResponseValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
shaderLightResponseValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
shaderLightResponseValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
shaderLightResponseValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderLightResponseBlockBlock : IBlock {
      private Block _categories = new Block();
      private Block _shaderLODs = new Block();
      private Pad _unnamed0;
      private Pad _unnamed1;
      public BlockCollection<ShaderTemplateCategoryBlockBlock> _categoriesList = new BlockCollection<ShaderTemplateCategoryBlockBlock>();
      public BlockCollection<ShaderTemplateLevelOfDetailBlockBlock> _shaderLODsList = new BlockCollection<ShaderTemplateLevelOfDetailBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderLightResponseBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<ShaderTemplateCategoryBlockBlock> Categories {
        get {
          return this._categoriesList;
        }
      }
      public BlockCollection<ShaderTemplateLevelOfDetailBlockBlock> ShaderLODs {
        get {
          return this._shaderLODsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Categories.BlockCount; x++)
{
  IBlock block = Categories.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ShaderLODs.BlockCount; x++)
{
  IBlock block = ShaderLODs.GetBlock(x);
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
        _categories.Read(reader);
        _shaderLODs.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories.Add(new ShaderTemplateCategoryBlockBlock());
          Categories[x].Read(reader);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shaderLODs.Count); x = (x + 1)) {
          ShaderLODs.Add(new ShaderTemplateLevelOfDetailBlockBlock());
          ShaderLODs[x].Read(reader);
        }
        for (x = 0; (x < _shaderLODs.Count); x = (x + 1)) {
          ShaderLODs[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_categories.Count = Categories.Count;
        _categories.Write(bw);
_shaderLODs.Count = ShaderLODs.Count;
        _shaderLODs.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].Write(writer);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shaderLODs.Count); x = (x + 1)) {
          ShaderLODs[x].Write(writer);
        }
        for (x = 0; (x < _shaderLODs.Count); x = (x + 1)) {
          ShaderLODs[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTemplateCategoryBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _parameters = new Block();
      public BlockCollection<ShaderTemplateParameterBlockBlock> _parametersList = new BlockCollection<ShaderTemplateParameterBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplateCategoryBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<ShaderTemplateParameterBlockBlock> Parameters {
        get {
          return this._parametersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Parameters.BlockCount; x++)
{
  IBlock block = Parameters.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parameters.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters.Add(new ShaderTemplateParameterBlockBlock());
          Parameters[x].Read(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_parameters.Count = Parameters.Count;
        _parameters.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].Write(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTemplateParameterBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Data _explanation = new Data();
      private Enum _type;
      private Flags _flags;
      private TagReference _defaultBitmap = new TagReference();
      private Real _defaultConstValue = new Real();
      private RealRGBColor _defaultConstColor = new RealRGBColor();
      private Enum _bitmapType;
      private Pad _unnamed0;
      private Flags _bitmapAnimationFlags;
      private Pad _unnamed1;
      private Real _bitmapScale = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplateParameterBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._bitmapType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._bitmapAnimationFlags = new Flags(2);
        this._unnamed1 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_defaultBitmap.Value);
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
      public Data Explanation {
        get {
          return this._explanation;
        }
        set {
          this._explanation = value;
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public TagReference DefaultBitmap {
        get {
          return this._defaultBitmap;
        }
        set {
          this._defaultBitmap = value;
        }
      }
      public Real DefaultConstValue {
        get {
          return this._defaultConstValue;
        }
        set {
          this._defaultConstValue = value;
        }
      }
      public RealRGBColor DefaultConstColor {
        get {
          return this._defaultConstColor;
        }
        set {
          this._defaultConstColor = value;
        }
      }
      public Enum BitmapType {
        get {
          return this._bitmapType;
        }
        set {
          this._bitmapType = value;
        }
      }
      public Flags BitmapAnimationFlags {
        get {
          return this._bitmapAnimationFlags;
        }
        set {
          this._bitmapAnimationFlags = value;
        }
      }
      public Real BitmapScale {
        get {
          return this._bitmapScale;
        }
        set {
          this._bitmapScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _explanation.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _defaultBitmap.Read(reader);
        _defaultConstValue.Read(reader);
        _defaultConstColor.Read(reader);
        _bitmapType.Read(reader);
        _unnamed0.Read(reader);
        _bitmapAnimationFlags.Read(reader);
        _unnamed1.Read(reader);
        _bitmapScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _explanation.ReadBinary(reader);
        _defaultBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _explanation.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _defaultBitmap.Write(bw);
        _defaultConstValue.Write(bw);
        _defaultConstColor.Write(bw);
        _bitmapType.Write(bw);
        _unnamed0.Write(bw);
        _bitmapAnimationFlags.Write(bw);
        _unnamed1.Write(bw);
        _bitmapScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _explanation.WriteBinary(writer);
        _defaultBitmap.WriteString(writer);
      }
    }
    public class ShaderTemplateLevelOfDetailBlockBlock : IBlock {
      private Real _projectedDiameter = new Real();
      private Block _pass = new Block();
      public BlockCollection<ShaderTemplatePassReferenceBlockBlock> _passList = new BlockCollection<ShaderTemplatePassReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplateLevelOfDetailBlockBlock() {
      }
      public BlockCollection<ShaderTemplatePassReferenceBlockBlock> Pass {
        get {
          return this._passList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Pass.BlockCount; x++)
{
  IBlock block = Pass.GetBlock(x);
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
      public Real ProjectedDiameter {
        get {
          return this._projectedDiameter;
        }
        set {
          this._projectedDiameter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _projectedDiameter.Read(reader);
        _pass.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _pass.Count); x = (x + 1)) {
          Pass.Add(new ShaderTemplatePassReferenceBlockBlock());
          Pass[x].Read(reader);
        }
        for (x = 0; (x < _pass.Count); x = (x + 1)) {
          Pass[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _projectedDiameter.Write(bw);
_pass.Count = Pass.Count;
        _pass.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _pass.Count); x = (x + 1)) {
          Pass[x].Write(writer);
        }
        for (x = 0; (x < _pass.Count); x = (x + 1)) {
          Pass[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTemplatePassReferenceBlockBlock : IBlock {
      private Enum _layer;
      private Pad _unnamed0;
      private TagReference _pass = new TagReference();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePassReferenceBlockBlock() {
if (this._pass is System.ComponentModel.INotifyPropertyChanged)
  (this._pass as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._layer = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_pass.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _pass.ToString();
        }
      }
      public Enum Layer {
        get {
          return this._layer;
        }
        set {
          this._layer = value;
        }
      }
      public TagReference Pass {
        get {
          return this._pass;
        }
        set {
          this._pass = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _layer.Read(reader);
        _unnamed0.Read(reader);
        _pass.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _pass.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _layer.Write(bw);
        _unnamed0.Write(bw);
        _pass.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _pass.WriteString(writer);
      }
    }
  }
}
