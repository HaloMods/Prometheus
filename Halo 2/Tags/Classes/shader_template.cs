// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'shader_template'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class shader_template : Interfaces.Pool.Tag {
    private ShaderTemplateBlockBlock shaderTemplateValues = new ShaderTemplateBlockBlock();
    public virtual ShaderTemplateBlockBlock ShaderTemplateValues {
      get {
        return shaderTemplateValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ShaderTemplateValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_template";
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
shaderTemplateValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
shaderTemplateValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
shaderTemplateValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
shaderTemplateValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTemplateBlockBlock : IBlock {
      private Data _documentation = new Data();
      private StringId _defaultMaterialName = new StringId();
      private Pad _unnamed0;
      private Flags _flags;
      private Block _properties = new Block();
      private Block _categories = new Block();
      private TagReference _lightResponse = new TagReference();
      private Block _lODs = new Block();
      private Block _unnamed1 = new Block();
      private Block _unnamed2 = new Block();
      private TagReference _aux1Shader = new TagReference();
      private Enum _aux1Layer;
      private Pad _unnamed3;
      private TagReference _aux2Shader = new TagReference();
      private Enum _aux2Layer;
      private Pad _unnamed4;
      private Block _postprocessDefinition = new Block();
      public BlockCollection<ShaderTemplatePropertyBlockBlock> _propertiesList = new BlockCollection<ShaderTemplatePropertyBlockBlock>();
      public BlockCollection<ShaderTemplateCategoryBlockBlock> _categoriesList = new BlockCollection<ShaderTemplateCategoryBlockBlock>();
      public BlockCollection<ShaderTemplateLevelOfDetailBlockBlock> _lODsList = new BlockCollection<ShaderTemplateLevelOfDetailBlockBlock>();
      public BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock> _unnamed1List = new BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock>();
      public BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock> _unnamed2List = new BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock>();
      public BlockCollection<ShaderTemplatePostprocessDefinitionNewBlockBlock> _postprocessDefinitionList = new BlockCollection<ShaderTemplatePostprocessDefinitionNewBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplateBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
        this._aux1Layer = new Enum(2);
        this._unnamed3 = new Pad(2);
        this._aux2Layer = new Enum(2);
        this._unnamed4 = new Pad(2);
      }
      public BlockCollection<ShaderTemplatePropertyBlockBlock> Properties {
        get {
          return this._propertiesList;
        }
      }
      public BlockCollection<ShaderTemplateCategoryBlockBlock> Categories {
        get {
          return this._categoriesList;
        }
      }
      public BlockCollection<ShaderTemplateLevelOfDetailBlockBlock> LODs {
        get {
          return this._lODsList;
        }
      }
      public BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public BlockCollection<ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock> Unnamed2 {
        get {
          return this._unnamed2List;
        }
      }
      public BlockCollection<ShaderTemplatePostprocessDefinitionNewBlockBlock> PostprocessDefinition {
        get {
          return this._postprocessDefinitionList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lightResponse.Value);
references.Add(_aux1Shader.Value);
references.Add(_aux2Shader.Value);
for (int x=0; x<Properties.BlockCount; x++)
{
  IBlock block = Properties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Categories.BlockCount; x++)
{
  IBlock block = Categories.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LODs.BlockCount; x++)
{
  IBlock block = LODs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed2.BlockCount; x++)
{
  IBlock block = Unnamed2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PostprocessDefinition.BlockCount; x++)
{
  IBlock block = PostprocessDefinition.GetBlock(x);
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
      public Data Documentation {
        get {
          return this._documentation;
        }
        set {
          this._documentation = value;
        }
      }
      public StringId DefaultMaterialName {
        get {
          return this._defaultMaterialName;
        }
        set {
          this._defaultMaterialName = value;
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
      public TagReference LightResponse {
        get {
          return this._lightResponse;
        }
        set {
          this._lightResponse = value;
        }
      }
      public TagReference Aux1Shader {
        get {
          return this._aux1Shader;
        }
        set {
          this._aux1Shader = value;
        }
      }
      public Enum Aux1Layer {
        get {
          return this._aux1Layer;
        }
        set {
          this._aux1Layer = value;
        }
      }
      public TagReference Aux2Shader {
        get {
          return this._aux2Shader;
        }
        set {
          this._aux2Shader = value;
        }
      }
      public Enum Aux2Layer {
        get {
          return this._aux2Layer;
        }
        set {
          this._aux2Layer = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _documentation.Read(reader);
        _defaultMaterialName.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _properties.Read(reader);
        _categories.Read(reader);
        _lightResponse.Read(reader);
        _lODs.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _aux1Shader.Read(reader);
        _aux1Layer.Read(reader);
        _unnamed3.Read(reader);
        _aux2Shader.Read(reader);
        _aux2Layer.Read(reader);
        _unnamed4.Read(reader);
        _postprocessDefinition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _documentation.ReadBinary(reader);
        _defaultMaterialName.ReadString(reader);
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties.Add(new ShaderTemplatePropertyBlockBlock());
          Properties[x].Read(reader);
        }
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories.Add(new ShaderTemplateCategoryBlockBlock());
          Categories[x].Read(reader);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].ReadChildData(reader);
        }
        _lightResponse.ReadString(reader);
        for (x = 0; (x < _lODs.Count); x = (x + 1)) {
          LODs.Add(new ShaderTemplateLevelOfDetailBlockBlock());
          LODs[x].Read(reader);
        }
        for (x = 0; (x < _lODs.Count); x = (x + 1)) {
          LODs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2.Add(new ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock());
          Unnamed2[x].Read(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].ReadChildData(reader);
        }
        _aux1Shader.ReadString(reader);
        _aux2Shader.ReadString(reader);
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition.Add(new ShaderTemplatePostprocessDefinitionNewBlockBlock());
          PostprocessDefinition[x].Read(reader);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _documentation.Write(bw);
        _defaultMaterialName.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
_properties.Count = Properties.Count;
        _properties.Write(bw);
_categories.Count = Categories.Count;
        _categories.Write(bw);
        _lightResponse.Write(bw);
_lODs.Count = LODs.Count;
        _lODs.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
_unnamed2.Count = Unnamed2.Count;
        _unnamed2.Write(bw);
        _aux1Shader.Write(bw);
        _aux1Layer.Write(bw);
        _unnamed3.Write(bw);
        _aux2Shader.Write(bw);
        _aux2Layer.Write(bw);
        _unnamed4.Write(bw);
_postprocessDefinition.Count = PostprocessDefinition.Count;
        _postprocessDefinition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _documentation.WriteBinary(writer);
        _defaultMaterialName.WriteString(writer);
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].Write(writer);
        }
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].Write(writer);
        }
        for (x = 0; (x < _categories.Count); x = (x + 1)) {
          Categories[x].WriteChildData(writer);
        }
        _lightResponse.WriteString(writer);
        for (x = 0; (x < _lODs.Count); x = (x + 1)) {
          LODs[x].Write(writer);
        }
        for (x = 0; (x < _lODs.Count); x = (x + 1)) {
          LODs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].Write(writer);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].WriteChildData(writer);
        }
        _aux1Shader.WriteString(writer);
        _aux2Shader.WriteString(writer);
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].Write(writer);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTemplatePropertyBlockBlock : IBlock {
      private Enum _property;
      private Pad _unnamed0;
      private StringId _parameterName = new StringId();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePropertyBlockBlock() {
if (this._property is System.ComponentModel.INotifyPropertyChanged)
  (this._property as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._property = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _property.ToString();
        }
      }
      public Enum Property {
        get {
          return this._property;
        }
        set {
          this._property = value;
        }
      }
      public StringId ParameterName {
        get {
          return this._parameterName;
        }
        set {
          this._parameterName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _property.Read(reader);
        _unnamed0.Read(reader);
        _parameterName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _parameterName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _property.Write(bw);
        _unnamed0.Write(bw);
        _parameterName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _parameterName.WriteString(writer);
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
    public class ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplateRuntimeExternalLightResponseIndexBlockBlock() {
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
      public LongInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTemplatePostprocessDefinitionNewBlockBlock : IBlock {
      private Block _levelsOfDetail = new Block();
      private Block _layers = new Block();
      private Block _passes = new Block();
      private Block _implementations = new Block();
      private Block _remappings = new Block();
      public BlockCollection<ShaderTemplatePostprocessLevelOfDetailNewBlockBlock> _levelsOfDetailList = new BlockCollection<ShaderTemplatePostprocessLevelOfDetailNewBlockBlock>();
      public BlockCollection<TagBlockIndexBlockBlock> _layersList = new BlockCollection<TagBlockIndexBlockBlock>();
      public BlockCollection<ShaderTemplatePostprocessPassNewBlockBlock> _passesList = new BlockCollection<ShaderTemplatePostprocessPassNewBlockBlock>();
      public BlockCollection<ShaderTemplatePostprocessImplementationNewBlockBlock> _implementationsList = new BlockCollection<ShaderTemplatePostprocessImplementationNewBlockBlock>();
      public BlockCollection<ShaderTemplatePostprocessRemappingNewBlockBlock> _remappingsList = new BlockCollection<ShaderTemplatePostprocessRemappingNewBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePostprocessDefinitionNewBlockBlock() {
      }
      public BlockCollection<ShaderTemplatePostprocessLevelOfDetailNewBlockBlock> LevelsOfDetail {
        get {
          return this._levelsOfDetailList;
        }
      }
      public BlockCollection<TagBlockIndexBlockBlock> Layers {
        get {
          return this._layersList;
        }
      }
      public BlockCollection<ShaderTemplatePostprocessPassNewBlockBlock> Passes {
        get {
          return this._passesList;
        }
      }
      public BlockCollection<ShaderTemplatePostprocessImplementationNewBlockBlock> Implementations {
        get {
          return this._implementationsList;
        }
      }
      public BlockCollection<ShaderTemplatePostprocessRemappingNewBlockBlock> Remappings {
        get {
          return this._remappingsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<LevelsOfDetail.BlockCount; x++)
{
  IBlock block = LevelsOfDetail.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Layers.BlockCount; x++)
{
  IBlock block = Layers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Passes.BlockCount; x++)
{
  IBlock block = Passes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Implementations.BlockCount; x++)
{
  IBlock block = Implementations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Remappings.BlockCount; x++)
{
  IBlock block = Remappings.GetBlock(x);
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
        _levelsOfDetail.Read(reader);
        _layers.Read(reader);
        _passes.Read(reader);
        _implementations.Read(reader);
        _remappings.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _levelsOfDetail.Count); x = (x + 1)) {
          LevelsOfDetail.Add(new ShaderTemplatePostprocessLevelOfDetailNewBlockBlock());
          LevelsOfDetail[x].Read(reader);
        }
        for (x = 0; (x < _levelsOfDetail.Count); x = (x + 1)) {
          LevelsOfDetail[x].ReadChildData(reader);
        }
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers.Add(new TagBlockIndexBlockBlock());
          Layers[x].Read(reader);
        }
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes.Add(new ShaderTemplatePostprocessPassNewBlockBlock());
          Passes[x].Read(reader);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations.Add(new ShaderTemplatePostprocessImplementationNewBlockBlock());
          Implementations[x].Read(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _remappings.Count); x = (x + 1)) {
          Remappings.Add(new ShaderTemplatePostprocessRemappingNewBlockBlock());
          Remappings[x].Read(reader);
        }
        for (x = 0; (x < _remappings.Count); x = (x + 1)) {
          Remappings[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_levelsOfDetail.Count = LevelsOfDetail.Count;
        _levelsOfDetail.Write(bw);
_layers.Count = Layers.Count;
        _layers.Write(bw);
_passes.Count = Passes.Count;
        _passes.Write(bw);
_implementations.Count = Implementations.Count;
        _implementations.Write(bw);
_remappings.Count = Remappings.Count;
        _remappings.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _levelsOfDetail.Count); x = (x + 1)) {
          LevelsOfDetail[x].Write(writer);
        }
        for (x = 0; (x < _levelsOfDetail.Count); x = (x + 1)) {
          LevelsOfDetail[x].WriteChildData(writer);
        }
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers[x].Write(writer);
        }
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes[x].Write(writer);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].Write(writer);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _remappings.Count); x = (x + 1)) {
          Remappings[x].Write(writer);
        }
        for (x = 0; (x < _remappings.Count); x = (x + 1)) {
          Remappings[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTemplatePostprocessLevelOfDetailNewBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
      private LongInteger _availableLayers = new LongInteger();
      private Real _projectedHeightPercentage = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePostprocessLevelOfDetailNewBlockBlock() {
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
      public ShortInteger BlockIndexData {
        get {
          return this._blockIndexData;
        }
        set {
          this._blockIndexData = value;
        }
      }
      public LongInteger AvailableLayers {
        get {
          return this._availableLayers;
        }
        set {
          this._availableLayers = value;
        }
      }
      public Real ProjectedHeightPercentage {
        get {
          return this._projectedHeightPercentage;
        }
        set {
          this._projectedHeightPercentage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
        _availableLayers.Read(reader);
        _projectedHeightPercentage.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
        _availableLayers.Write(bw);
        _projectedHeightPercentage.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class TagBlockIndexBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public TagBlockIndexBlockBlock() {
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
      public ShortInteger BlockIndexData {
        get {
          return this._blockIndexData;
        }
        set {
          this._blockIndexData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTemplatePostprocessPassNewBlockBlock : IBlock {
      private TagReference _pass = new TagReference();
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePostprocessPassNewBlockBlock() {
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
return "";
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
      public ShortInteger BlockIndexData {
        get {
          return this._blockIndexData;
        }
        set {
          this._blockIndexData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pass.Read(reader);
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _pass.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _pass.Write(bw);
        _blockIndexData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _pass.WriteString(writer);
      }
    }
    public class ShaderTemplatePostprocessImplementationNewBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
      private ShortInteger _blockIndexData2 = new ShortInteger();
      private ShortInteger _blockIndexData3 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePostprocessImplementationNewBlockBlock() {
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
      public ShortInteger BlockIndexData {
        get {
          return this._blockIndexData;
        }
        set {
          this._blockIndexData = value;
        }
      }
      public ShortInteger BlockIndexData2 {
        get {
          return this._blockIndexData2;
        }
        set {
          this._blockIndexData2 = value;
        }
      }
      public ShortInteger BlockIndexData3 {
        get {
          return this._blockIndexData3;
        }
        set {
          this._blockIndexData3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
        _blockIndexData2.Read(reader);
        _blockIndexData3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
        _blockIndexData2.Write(bw);
        _blockIndexData3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTemplatePostprocessRemappingNewBlockBlock : IBlock {
      private Skip _unnamed0;
      private CharInteger _sourceIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderTemplatePostprocessRemappingNewBlockBlock() {
        this._unnamed0 = new Skip(3);
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
      public CharInteger SourceIndex {
        get {
          return this._sourceIndex;
        }
        set {
          this._sourceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _sourceIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _sourceIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
