// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'shader'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class shader : Interfaces.Pool.Tag {
    private ShaderBlockBlock shaderValues = new ShaderBlockBlock();
    public virtual ShaderBlockBlock ShaderValues {
      get {
        return shaderValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ShaderValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader";
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
shaderValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
shaderValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
shaderValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
shaderValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderBlockBlock : IBlock {
      private TagReference _template = new TagReference();
      private StringId _materialName = new StringId();
      private Block _runtimeProperties = new Block();
      private Pad _unnamed0;
      private Flags _flags;
      private Block _parameters = new Block();
      private Block _postprocessDefinition = new Block();
      private Pad _unnamed1;
      private Block _predictedResources = new Block();
      private TagReference _lightResponse = new TagReference();
      private Enum _shaderLODBias;
      private Enum _specularType;
      private Enum _lightmapType;
      private Pad _unnamed2;
      private Real _lightmapSpecularBrightness = new Real();
      private Real _lightmapAmbientBias = new Real();
      private Block _postprocessProperties = new Block();
      private Real _addedDepthBiasOffset = new Real();
      private Real _addedDepthBiasSlopeScale = new Real();
      public BlockCollection<ShaderPropertiesBlockBlock> _runtimePropertiesList = new BlockCollection<ShaderPropertiesBlockBlock>();
      public BlockCollection<GlobalShaderParameterBlockBlock> _parametersList = new BlockCollection<GlobalShaderParameterBlockBlock>();
      public BlockCollection<ShaderPostprocessDefinitionNewBlockBlock> _postprocessDefinitionList = new BlockCollection<ShaderPostprocessDefinitionNewBlockBlock>();
      public BlockCollection<PredictedResourceBlockBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlockBlock>();
      public BlockCollection<LongBlockBlock> _postprocessPropertiesList = new BlockCollection<LongBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
        this._unnamed1 = new Pad(4);
        this._shaderLODBias = new Enum(2);
        this._specularType = new Enum(2);
        this._lightmapType = new Enum(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<ShaderPropertiesBlockBlock> RuntimeProperties {
        get {
          return this._runtimePropertiesList;
        }
      }
      public BlockCollection<GlobalShaderParameterBlockBlock> Parameters {
        get {
          return this._parametersList;
        }
      }
      public BlockCollection<ShaderPostprocessDefinitionNewBlockBlock> PostprocessDefinition {
        get {
          return this._postprocessDefinitionList;
        }
      }
      public BlockCollection<PredictedResourceBlockBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<LongBlockBlock> PostprocessProperties {
        get {
          return this._postprocessPropertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_template.Value);
references.Add(_lightResponse.Value);
for (int x=0; x<RuntimeProperties.BlockCount; x++)
{
  IBlock block = RuntimeProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Parameters.BlockCount; x++)
{
  IBlock block = Parameters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PostprocessDefinition.BlockCount; x++)
{
  IBlock block = PostprocessDefinition.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PostprocessProperties.BlockCount; x++)
{
  IBlock block = PostprocessProperties.GetBlock(x);
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
      public TagReference Template {
        get {
          return this._template;
        }
        set {
          this._template = value;
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
      public Enum ShaderLODBias {
        get {
          return this._shaderLODBias;
        }
        set {
          this._shaderLODBias = value;
        }
      }
      public Enum SpecularType {
        get {
          return this._specularType;
        }
        set {
          this._specularType = value;
        }
      }
      public Enum LightmapType {
        get {
          return this._lightmapType;
        }
        set {
          this._lightmapType = value;
        }
      }
      public Real LightmapSpecularBrightness {
        get {
          return this._lightmapSpecularBrightness;
        }
        set {
          this._lightmapSpecularBrightness = value;
        }
      }
      public Real LightmapAmbientBias {
        get {
          return this._lightmapAmbientBias;
        }
        set {
          this._lightmapAmbientBias = value;
        }
      }
      public Real AddedDepthBiasOffset {
        get {
          return this._addedDepthBiasOffset;
        }
        set {
          this._addedDepthBiasOffset = value;
        }
      }
      public Real AddedDepthBiasSlopeScale {
        get {
          return this._addedDepthBiasSlopeScale;
        }
        set {
          this._addedDepthBiasSlopeScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _template.Read(reader);
        _materialName.Read(reader);
        _runtimeProperties.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _parameters.Read(reader);
        _postprocessDefinition.Read(reader);
        _unnamed1.Read(reader);
        _predictedResources.Read(reader);
        _lightResponse.Read(reader);
        _shaderLODBias.Read(reader);
        _specularType.Read(reader);
        _lightmapType.Read(reader);
        _unnamed2.Read(reader);
        _lightmapSpecularBrightness.Read(reader);
        _lightmapAmbientBias.Read(reader);
        _postprocessProperties.Read(reader);
        _addedDepthBiasOffset.Read(reader);
        _addedDepthBiasSlopeScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _template.ReadString(reader);
        _materialName.ReadString(reader);
        for (x = 0; (x < _runtimeProperties.Count); x = (x + 1)) {
          RuntimeProperties.Add(new ShaderPropertiesBlockBlock());
          RuntimeProperties[x].Read(reader);
        }
        for (x = 0; (x < _runtimeProperties.Count); x = (x + 1)) {
          RuntimeProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters.Add(new GlobalShaderParameterBlockBlock());
          Parameters[x].Read(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition.Add(new ShaderPostprocessDefinitionNewBlockBlock());
          PostprocessDefinition[x].Read(reader);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlockBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        _lightResponse.ReadString(reader);
        for (x = 0; (x < _postprocessProperties.Count); x = (x + 1)) {
          PostprocessProperties.Add(new LongBlockBlock());
          PostprocessProperties[x].Read(reader);
        }
        for (x = 0; (x < _postprocessProperties.Count); x = (x + 1)) {
          PostprocessProperties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _template.Write(bw);
        _materialName.Write(bw);
_runtimeProperties.Count = RuntimeProperties.Count;
        _runtimeProperties.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
_parameters.Count = Parameters.Count;
        _parameters.Write(bw);
_postprocessDefinition.Count = PostprocessDefinition.Count;
        _postprocessDefinition.Write(bw);
        _unnamed1.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
        _lightResponse.Write(bw);
        _shaderLODBias.Write(bw);
        _specularType.Write(bw);
        _lightmapType.Write(bw);
        _unnamed2.Write(bw);
        _lightmapSpecularBrightness.Write(bw);
        _lightmapAmbientBias.Write(bw);
_postprocessProperties.Count = PostprocessProperties.Count;
        _postprocessProperties.Write(bw);
        _addedDepthBiasOffset.Write(bw);
        _addedDepthBiasSlopeScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _template.WriteString(writer);
        _materialName.WriteString(writer);
        for (x = 0; (x < _runtimeProperties.Count); x = (x + 1)) {
          RuntimeProperties[x].Write(writer);
        }
        for (x = 0; (x < _runtimeProperties.Count); x = (x + 1)) {
          RuntimeProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].Write(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].Write(writer);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].WriteChildData(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
        _lightResponse.WriteString(writer);
        for (x = 0; (x < _postprocessProperties.Count); x = (x + 1)) {
          PostprocessProperties[x].Write(writer);
        }
        for (x = 0; (x < _postprocessProperties.Count); x = (x + 1)) {
          PostprocessProperties[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPropertiesBlockBlock : IBlock {
      private TagReference _diffuseMap = new TagReference();
      private TagReference _lightmapEmissiveMap = new TagReference();
      private RealRGBColor _lightmapEmissiveColor = new RealRGBColor();
      private Real _lightmapEmissivePower = new Real();
      private Real _lightmapResolutionScale = new Real();
      private Real _lightmapHalfLife = new Real();
      private Real _lightmapDiffuseScale = new Real();
      private TagReference _alphaTestMap = new TagReference();
      private TagReference _translucentMap = new TagReference();
      private RealRGBColor _lightmapTransparentColor = new RealRGBColor();
      private Real _lightmapTransparentAlpha = new Real();
      private Real _lightmapFoliageScale = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPropertiesBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_diffuseMap.Value);
references.Add(_lightmapEmissiveMap.Value);
references.Add(_alphaTestMap.Value);
references.Add(_translucentMap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference DiffuseMap {
        get {
          return this._diffuseMap;
        }
        set {
          this._diffuseMap = value;
        }
      }
      public TagReference LightmapEmissiveMap {
        get {
          return this._lightmapEmissiveMap;
        }
        set {
          this._lightmapEmissiveMap = value;
        }
      }
      public RealRGBColor LightmapEmissiveColor {
        get {
          return this._lightmapEmissiveColor;
        }
        set {
          this._lightmapEmissiveColor = value;
        }
      }
      public Real LightmapEmissivePower {
        get {
          return this._lightmapEmissivePower;
        }
        set {
          this._lightmapEmissivePower = value;
        }
      }
      public Real LightmapResolutionScale {
        get {
          return this._lightmapResolutionScale;
        }
        set {
          this._lightmapResolutionScale = value;
        }
      }
      public Real LightmapHalfLife {
        get {
          return this._lightmapHalfLife;
        }
        set {
          this._lightmapHalfLife = value;
        }
      }
      public Real LightmapDiffuseScale {
        get {
          return this._lightmapDiffuseScale;
        }
        set {
          this._lightmapDiffuseScale = value;
        }
      }
      public TagReference AlphaTestMap {
        get {
          return this._alphaTestMap;
        }
        set {
          this._alphaTestMap = value;
        }
      }
      public TagReference TranslucentMap {
        get {
          return this._translucentMap;
        }
        set {
          this._translucentMap = value;
        }
      }
      public RealRGBColor LightmapTransparentColor {
        get {
          return this._lightmapTransparentColor;
        }
        set {
          this._lightmapTransparentColor = value;
        }
      }
      public Real LightmapTransparentAlpha {
        get {
          return this._lightmapTransparentAlpha;
        }
        set {
          this._lightmapTransparentAlpha = value;
        }
      }
      public Real LightmapFoliageScale {
        get {
          return this._lightmapFoliageScale;
        }
        set {
          this._lightmapFoliageScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _diffuseMap.Read(reader);
        _lightmapEmissiveMap.Read(reader);
        _lightmapEmissiveColor.Read(reader);
        _lightmapEmissivePower.Read(reader);
        _lightmapResolutionScale.Read(reader);
        _lightmapHalfLife.Read(reader);
        _lightmapDiffuseScale.Read(reader);
        _alphaTestMap.Read(reader);
        _translucentMap.Read(reader);
        _lightmapTransparentColor.Read(reader);
        _lightmapTransparentAlpha.Read(reader);
        _lightmapFoliageScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _diffuseMap.ReadString(reader);
        _lightmapEmissiveMap.ReadString(reader);
        _alphaTestMap.ReadString(reader);
        _translucentMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _diffuseMap.Write(bw);
        _lightmapEmissiveMap.Write(bw);
        _lightmapEmissiveColor.Write(bw);
        _lightmapEmissivePower.Write(bw);
        _lightmapResolutionScale.Write(bw);
        _lightmapHalfLife.Write(bw);
        _lightmapDiffuseScale.Write(bw);
        _alphaTestMap.Write(bw);
        _translucentMap.Write(bw);
        _lightmapTransparentColor.Write(bw);
        _lightmapTransparentAlpha.Write(bw);
        _lightmapFoliageScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _diffuseMap.WriteString(writer);
        _lightmapEmissiveMap.WriteString(writer);
        _alphaTestMap.WriteString(writer);
        _translucentMap.WriteString(writer);
      }
    }
    public class GlobalShaderParameterBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _type;
      private Pad _unnamed0;
      private TagReference _bitmap = new TagReference();
      private Real _constValue = new Real();
      private RealRGBColor _constColor = new RealRGBColor();
      private Block _animationProperties = new Block();
      public BlockCollection<ShaderAnimationPropertyBlockBlock> _animationPropertiesList = new BlockCollection<ShaderAnimationPropertyBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalShaderParameterBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ShaderAnimationPropertyBlockBlock> AnimationProperties {
        get {
          return this._animationPropertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
for (int x=0; x<AnimationProperties.BlockCount; x++)
{
  IBlock block = AnimationProperties.GetBlock(x);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public Real ConstValue {
        get {
          return this._constValue;
        }
        set {
          this._constValue = value;
        }
      }
      public RealRGBColor ConstColor {
        get {
          return this._constColor;
        }
        set {
          this._constColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _type.Read(reader);
        _unnamed0.Read(reader);
        _bitmap.Read(reader);
        _constValue.Read(reader);
        _constColor.Read(reader);
        _animationProperties.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _bitmap.ReadString(reader);
        for (x = 0; (x < _animationProperties.Count); x = (x + 1)) {
          AnimationProperties.Add(new ShaderAnimationPropertyBlockBlock());
          AnimationProperties[x].Read(reader);
        }
        for (x = 0; (x < _animationProperties.Count); x = (x + 1)) {
          AnimationProperties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _unnamed0.Write(bw);
        _bitmap.Write(bw);
        _constValue.Write(bw);
        _constColor.Write(bw);
_animationProperties.Count = AnimationProperties.Count;
        _animationProperties.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _bitmap.WriteString(writer);
        for (x = 0; (x < _animationProperties.Count); x = (x + 1)) {
          AnimationProperties[x].Write(writer);
        }
        for (x = 0; (x < _animationProperties.Count); x = (x + 1)) {
          AnimationProperties[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderAnimationPropertyBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriod = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderAnimationPropertyBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
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
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriod {
        get {
          return this._timePeriod;
        }
        set {
          this._timePeriod = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriod.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriod.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ByteBlockBlock : IBlock {
      private CharInteger _value = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockBlock() {
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
      public CharInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessDefinitionNewBlockBlock : IBlock {
      private LongInteger _shaderTemplateIndex = new LongInteger();
      private Block _bitmaps = new Block();
      private Block _pixelConstants = new Block();
      private Block _vertexConstants = new Block();
      private Block _levelsOfDetail = new Block();
      private Block _layers = new Block();
      private Block _passes = new Block();
      private Block _implementations = new Block();
      private Block _overlays = new Block();
      private Block _overlayReferences = new Block();
      private Block _animatedParameters = new Block();
      private Block _animatedParameterReferences = new Block();
      private Block _bitmapProperties = new Block();
      private Block _colorProperties = new Block();
      private Block _valueProperties = new Block();
      private Block _oldLevelsOfDetail = new Block();
      public BlockCollection<ShaderPostprocessBitmapNewBlockBlock> _bitmapsList = new BlockCollection<ShaderPostprocessBitmapNewBlockBlock>();
      public BlockCollection<Pixel32BlockBlock> _pixelConstantsList = new BlockCollection<Pixel32BlockBlock>();
      public BlockCollection<RealVector4dBlockBlock> _vertexConstantsList = new BlockCollection<RealVector4dBlockBlock>();
      public BlockCollection<ShaderPostprocessLevelOfDetailNewBlockBlock> _levelsOfDetailList = new BlockCollection<ShaderPostprocessLevelOfDetailNewBlockBlock>();
      public BlockCollection<TagBlockIndexBlockBlock> _layersList = new BlockCollection<TagBlockIndexBlockBlock>();
      public BlockCollection<TagBlockIndexBlockBlock> _passesList = new BlockCollection<TagBlockIndexBlockBlock>();
      public BlockCollection<ShaderPostprocessImplementationNewBlockBlock> _implementationsList = new BlockCollection<ShaderPostprocessImplementationNewBlockBlock>();
      public BlockCollection<ShaderPostprocessOverlayNewBlockBlock> _overlaysList = new BlockCollection<ShaderPostprocessOverlayNewBlockBlock>();
      public BlockCollection<ShaderPostprocessOverlayReferenceNewBlockBlock> _overlayReferencesList = new BlockCollection<ShaderPostprocessOverlayReferenceNewBlockBlock>();
      public BlockCollection<ShaderPostprocessAnimatedParameterNewBlockBlock> _animatedParametersList = new BlockCollection<ShaderPostprocessAnimatedParameterNewBlockBlock>();
      public BlockCollection<ShaderPostprocessAnimatedParameterReferenceNewBlockBlock> _animatedParameterReferencesList = new BlockCollection<ShaderPostprocessAnimatedParameterReferenceNewBlockBlock>();
      public BlockCollection<ShaderPostprocessBitmapPropertyBlockBlock> _bitmapPropertiesList = new BlockCollection<ShaderPostprocessBitmapPropertyBlockBlock>();
      public BlockCollection<ShaderPostprocessColorPropertyBlockBlock> _colorPropertiesList = new BlockCollection<ShaderPostprocessColorPropertyBlockBlock>();
      public BlockCollection<ShaderPostprocessValuePropertyBlockBlock> _valuePropertiesList = new BlockCollection<ShaderPostprocessValuePropertyBlockBlock>();
      public BlockCollection<ShaderPostprocessLevelOfDetailBlockBlock> _oldLevelsOfDetailList = new BlockCollection<ShaderPostprocessLevelOfDetailBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessDefinitionNewBlockBlock() {
      }
      public BlockCollection<ShaderPostprocessBitmapNewBlockBlock> Bitmaps {
        get {
          return this._bitmapsList;
        }
      }
      public BlockCollection<Pixel32BlockBlock> PixelConstants {
        get {
          return this._pixelConstantsList;
        }
      }
      public BlockCollection<RealVector4dBlockBlock> VertexConstants {
        get {
          return this._vertexConstantsList;
        }
      }
      public BlockCollection<ShaderPostprocessLevelOfDetailNewBlockBlock> LevelsOfDetail {
        get {
          return this._levelsOfDetailList;
        }
      }
      public BlockCollection<TagBlockIndexBlockBlock> Layers {
        get {
          return this._layersList;
        }
      }
      public BlockCollection<TagBlockIndexBlockBlock> Passes {
        get {
          return this._passesList;
        }
      }
      public BlockCollection<ShaderPostprocessImplementationNewBlockBlock> Implementations {
        get {
          return this._implementationsList;
        }
      }
      public BlockCollection<ShaderPostprocessOverlayNewBlockBlock> Overlays {
        get {
          return this._overlaysList;
        }
      }
      public BlockCollection<ShaderPostprocessOverlayReferenceNewBlockBlock> OverlayReferences {
        get {
          return this._overlayReferencesList;
        }
      }
      public BlockCollection<ShaderPostprocessAnimatedParameterNewBlockBlock> AnimatedParameters {
        get {
          return this._animatedParametersList;
        }
      }
      public BlockCollection<ShaderPostprocessAnimatedParameterReferenceNewBlockBlock> AnimatedParameterReferences {
        get {
          return this._animatedParameterReferencesList;
        }
      }
      public BlockCollection<ShaderPostprocessBitmapPropertyBlockBlock> BitmapProperties {
        get {
          return this._bitmapPropertiesList;
        }
      }
      public BlockCollection<ShaderPostprocessColorPropertyBlockBlock> ColorProperties {
        get {
          return this._colorPropertiesList;
        }
      }
      public BlockCollection<ShaderPostprocessValuePropertyBlockBlock> ValueProperties {
        get {
          return this._valuePropertiesList;
        }
      }
      public BlockCollection<ShaderPostprocessLevelOfDetailBlockBlock> OldLevelsOfDetail {
        get {
          return this._oldLevelsOfDetailList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bitmaps.BlockCount; x++)
{
  IBlock block = Bitmaps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PixelConstants.BlockCount; x++)
{
  IBlock block = PixelConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VertexConstants.BlockCount; x++)
{
  IBlock block = VertexConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
for (int x=0; x<Overlays.BlockCount; x++)
{
  IBlock block = Overlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OverlayReferences.BlockCount; x++)
{
  IBlock block = OverlayReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AnimatedParameters.BlockCount; x++)
{
  IBlock block = AnimatedParameters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AnimatedParameterReferences.BlockCount; x++)
{
  IBlock block = AnimatedParameterReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BitmapProperties.BlockCount; x++)
{
  IBlock block = BitmapProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ColorProperties.BlockCount; x++)
{
  IBlock block = ColorProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ValueProperties.BlockCount; x++)
{
  IBlock block = ValueProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OldLevelsOfDetail.BlockCount; x++)
{
  IBlock block = OldLevelsOfDetail.GetBlock(x);
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
      public LongInteger ShaderTemplateIndex {
        get {
          return this._shaderTemplateIndex;
        }
        set {
          this._shaderTemplateIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shaderTemplateIndex.Read(reader);
        _bitmaps.Read(reader);
        _pixelConstants.Read(reader);
        _vertexConstants.Read(reader);
        _levelsOfDetail.Read(reader);
        _layers.Read(reader);
        _passes.Read(reader);
        _implementations.Read(reader);
        _overlays.Read(reader);
        _overlayReferences.Read(reader);
        _animatedParameters.Read(reader);
        _animatedParameterReferences.Read(reader);
        _bitmapProperties.Read(reader);
        _colorProperties.Read(reader);
        _valueProperties.Read(reader);
        _oldLevelsOfDetail.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps.Add(new ShaderPostprocessBitmapNewBlockBlock());
          Bitmaps[x].Read(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pixelConstants.Count); x = (x + 1)) {
          PixelConstants.Add(new Pixel32BlockBlock());
          PixelConstants[x].Read(reader);
        }
        for (x = 0; (x < _pixelConstants.Count); x = (x + 1)) {
          PixelConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertexConstants.Count); x = (x + 1)) {
          VertexConstants.Add(new RealVector4dBlockBlock());
          VertexConstants[x].Read(reader);
        }
        for (x = 0; (x < _vertexConstants.Count); x = (x + 1)) {
          VertexConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _levelsOfDetail.Count); x = (x + 1)) {
          LevelsOfDetail.Add(new ShaderPostprocessLevelOfDetailNewBlockBlock());
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
          Passes.Add(new TagBlockIndexBlockBlock());
          Passes[x].Read(reader);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations.Add(new ShaderPostprocessImplementationNewBlockBlock());
          Implementations[x].Read(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays.Add(new ShaderPostprocessOverlayNewBlockBlock());
          Overlays[x].Read(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _overlayReferences.Count); x = (x + 1)) {
          OverlayReferences.Add(new ShaderPostprocessOverlayReferenceNewBlockBlock());
          OverlayReferences[x].Read(reader);
        }
        for (x = 0; (x < _overlayReferences.Count); x = (x + 1)) {
          OverlayReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animatedParameters.Count); x = (x + 1)) {
          AnimatedParameters.Add(new ShaderPostprocessAnimatedParameterNewBlockBlock());
          AnimatedParameters[x].Read(reader);
        }
        for (x = 0; (x < _animatedParameters.Count); x = (x + 1)) {
          AnimatedParameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animatedParameterReferences.Count); x = (x + 1)) {
          AnimatedParameterReferences.Add(new ShaderPostprocessAnimatedParameterReferenceNewBlockBlock());
          AnimatedParameterReferences[x].Read(reader);
        }
        for (x = 0; (x < _animatedParameterReferences.Count); x = (x + 1)) {
          AnimatedParameterReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmapProperties.Count); x = (x + 1)) {
          BitmapProperties.Add(new ShaderPostprocessBitmapPropertyBlockBlock());
          BitmapProperties[x].Read(reader);
        }
        for (x = 0; (x < _bitmapProperties.Count); x = (x + 1)) {
          BitmapProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _colorProperties.Count); x = (x + 1)) {
          ColorProperties.Add(new ShaderPostprocessColorPropertyBlockBlock());
          ColorProperties[x].Read(reader);
        }
        for (x = 0; (x < _colorProperties.Count); x = (x + 1)) {
          ColorProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _valueProperties.Count); x = (x + 1)) {
          ValueProperties.Add(new ShaderPostprocessValuePropertyBlockBlock());
          ValueProperties[x].Read(reader);
        }
        for (x = 0; (x < _valueProperties.Count); x = (x + 1)) {
          ValueProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _oldLevelsOfDetail.Count); x = (x + 1)) {
          OldLevelsOfDetail.Add(new ShaderPostprocessLevelOfDetailBlockBlock());
          OldLevelsOfDetail[x].Read(reader);
        }
        for (x = 0; (x < _oldLevelsOfDetail.Count); x = (x + 1)) {
          OldLevelsOfDetail[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _shaderTemplateIndex.Write(bw);
_bitmaps.Count = Bitmaps.Count;
        _bitmaps.Write(bw);
_pixelConstants.Count = PixelConstants.Count;
        _pixelConstants.Write(bw);
_vertexConstants.Count = VertexConstants.Count;
        _vertexConstants.Write(bw);
_levelsOfDetail.Count = LevelsOfDetail.Count;
        _levelsOfDetail.Write(bw);
_layers.Count = Layers.Count;
        _layers.Write(bw);
_passes.Count = Passes.Count;
        _passes.Write(bw);
_implementations.Count = Implementations.Count;
        _implementations.Write(bw);
_overlays.Count = Overlays.Count;
        _overlays.Write(bw);
_overlayReferences.Count = OverlayReferences.Count;
        _overlayReferences.Write(bw);
_animatedParameters.Count = AnimatedParameters.Count;
        _animatedParameters.Write(bw);
_animatedParameterReferences.Count = AnimatedParameterReferences.Count;
        _animatedParameterReferences.Write(bw);
_bitmapProperties.Count = BitmapProperties.Count;
        _bitmapProperties.Write(bw);
_colorProperties.Count = ColorProperties.Count;
        _colorProperties.Write(bw);
_valueProperties.Count = ValueProperties.Count;
        _valueProperties.Write(bw);
_oldLevelsOfDetail.Count = OldLevelsOfDetail.Count;
        _oldLevelsOfDetail.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].Write(writer);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pixelConstants.Count); x = (x + 1)) {
          PixelConstants[x].Write(writer);
        }
        for (x = 0; (x < _pixelConstants.Count); x = (x + 1)) {
          PixelConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertexConstants.Count); x = (x + 1)) {
          VertexConstants[x].Write(writer);
        }
        for (x = 0; (x < _vertexConstants.Count); x = (x + 1)) {
          VertexConstants[x].WriteChildData(writer);
        }
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
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].Write(writer);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _overlayReferences.Count); x = (x + 1)) {
          OverlayReferences[x].Write(writer);
        }
        for (x = 0; (x < _overlayReferences.Count); x = (x + 1)) {
          OverlayReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animatedParameters.Count); x = (x + 1)) {
          AnimatedParameters[x].Write(writer);
        }
        for (x = 0; (x < _animatedParameters.Count); x = (x + 1)) {
          AnimatedParameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animatedParameterReferences.Count); x = (x + 1)) {
          AnimatedParameterReferences[x].Write(writer);
        }
        for (x = 0; (x < _animatedParameterReferences.Count); x = (x + 1)) {
          AnimatedParameterReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmapProperties.Count); x = (x + 1)) {
          BitmapProperties[x].Write(writer);
        }
        for (x = 0; (x < _bitmapProperties.Count); x = (x + 1)) {
          BitmapProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _colorProperties.Count); x = (x + 1)) {
          ColorProperties[x].Write(writer);
        }
        for (x = 0; (x < _colorProperties.Count); x = (x + 1)) {
          ColorProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _valueProperties.Count); x = (x + 1)) {
          ValueProperties[x].Write(writer);
        }
        for (x = 0; (x < _valueProperties.Count); x = (x + 1)) {
          ValueProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _oldLevelsOfDetail.Count); x = (x + 1)) {
          OldLevelsOfDetail[x].Write(writer);
        }
        for (x = 0; (x < _oldLevelsOfDetail.Count); x = (x + 1)) {
          OldLevelsOfDetail[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessBitmapNewBlockBlock : IBlock {
      private Skip _shaderBitmapReference;
      private LongInteger _bitmapIndex = new LongInteger();
      private Real _logBitmapDimension = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessBitmapNewBlockBlock() {
        this._shaderBitmapReference = new Skip(4);
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
      public LongInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public Real LogBitmapDimension {
        get {
          return this._logBitmapDimension;
        }
        set {
          this._logBitmapDimension = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shaderBitmapReference.Read(reader);
        _bitmapIndex.Read(reader);
        _logBitmapDimension.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _shaderBitmapReference.Write(bw);
        _bitmapIndex.Write(bw);
        _logBitmapDimension.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Pixel32BlockBlock : IBlock {
      private ARGBColor _color = new ARGBColor();
public event System.EventHandler BlockNameChanged;
      public Pixel32BlockBlock() {
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
      public ARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RealVector4dBlockBlock : IBlock {
      private RealVector3D _vector3 = new RealVector3D();
      private Real _w = new Real();
public event System.EventHandler BlockNameChanged;
      public RealVector4dBlockBlock() {
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
      public RealVector3D Vector3 {
        get {
          return this._vector3;
        }
        set {
          this._vector3 = value;
        }
      }
      public Real W {
        get {
          return this._w;
        }
        set {
          this._w = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vector3.Read(reader);
        _w.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vector3.Write(bw);
        _w.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessLevelOfDetailNewBlockBlock : IBlock {
      private LongInteger _availableLayerFlags = new LongInteger();
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessLevelOfDetailNewBlockBlock() {
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
      public LongInteger AvailableLayerFlags {
        get {
          return this._availableLayerFlags;
        }
        set {
          this._availableLayerFlags = value;
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
        _availableLayerFlags.Read(reader);
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _availableLayerFlags.Write(bw);
        _blockIndexData.Write(bw);
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
    public class ShaderPostprocessImplementationNewBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
      private ShortInteger _blockIndexData2 = new ShortInteger();
      private ShortInteger _blockIndexData3 = new ShortInteger();
      private ShortInteger _blockIndexData4 = new ShortInteger();
      private ShortInteger _blockIndexData5 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessImplementationNewBlockBlock() {
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
      public ShortInteger BlockIndexData4 {
        get {
          return this._blockIndexData4;
        }
        set {
          this._blockIndexData4 = value;
        }
      }
      public ShortInteger BlockIndexData5 {
        get {
          return this._blockIndexData5;
        }
        set {
          this._blockIndexData5 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
        _blockIndexData2.Read(reader);
        _blockIndexData3.Read(reader);
        _blockIndexData4.Read(reader);
        _blockIndexData5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
        _blockIndexData2.Write(bw);
        _blockIndexData3.Write(bw);
        _blockIndexData4.Write(bw);
        _blockIndexData5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessOverlayNewBlockBlock : IBlock {
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriodInSeconds = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessOverlayNewBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriodInSeconds {
        get {
          return this._timePeriodInSeconds;
        }
        set {
          this._timePeriodInSeconds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriodInSeconds.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriodInSeconds.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessOverlayReferenceNewBlockBlock : IBlock {
      private ShortInteger _overlayIndex = new ShortInteger();
      private ShortInteger _transformIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessOverlayReferenceNewBlockBlock() {
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
      public ShortInteger OverlayIndex {
        get {
          return this._overlayIndex;
        }
        set {
          this._overlayIndex = value;
        }
      }
      public ShortInteger TransformIndex {
        get {
          return this._transformIndex;
        }
        set {
          this._transformIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _overlayIndex.Read(reader);
        _transformIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _overlayIndex.Write(bw);
        _transformIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessAnimatedParameterNewBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessAnimatedParameterNewBlockBlock() {
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
    public class ShaderPostprocessAnimatedParameterReferenceNewBlockBlock : IBlock {
      private Skip _unnamed0;
      private CharInteger _parameterIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessAnimatedParameterReferenceNewBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _parameterIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _parameterIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessBitmapPropertyBlockBlock : IBlock {
      private ShortInteger _bitmapIndex = new ShortInteger();
      private ShortInteger _animatedParameterIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessBitmapPropertyBlockBlock() {
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
      public ShortInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public ShortInteger AnimatedParameterIndex {
        get {
          return this._animatedParameterIndex;
        }
        set {
          this._animatedParameterIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmapIndex.Read(reader);
        _animatedParameterIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapIndex.Write(bw);
        _animatedParameterIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessColorPropertyBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessColorPropertyBlockBlock() {
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
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessValuePropertyBlockBlock : IBlock {
      private Real _value = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessValuePropertyBlockBlock() {
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
      public Real Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessLevelOfDetailBlockBlock : IBlock {
      private Real _projectedHeightPercentage = new Real();
      private LongInteger _availableLayers = new LongInteger();
      private Block _layers = new Block();
      private Block _passes = new Block();
      private Block _implementations = new Block();
      private Block _bitmaps = new Block();
      private Block _bitmapTransforms = new Block();
      private Block _values = new Block();
      private Block _colors = new Block();
      private Block _bitmapTransformOverlays = new Block();
      private Block _valueOverlays = new Block();
      private Block _colorOverlays = new Block();
      private Block _vertexShaderConstants = new Block();
      private Block _renderStates = new Block();
      private Block _textureStageStates = new Block();
      private Block _renderStateParameters = new Block();
      private Block _textureStageParameters = new Block();
      private Block _textures = new Block();
      private Block _vnConstants = new Block();
      private Block _cnConstants = new Block();
      public BlockCollection<ShaderPostprocessLayerBlockBlock> _layersList = new BlockCollection<ShaderPostprocessLayerBlockBlock>();
      public BlockCollection<ShaderPostprocessPassBlockBlock> _passesList = new BlockCollection<ShaderPostprocessPassBlockBlock>();
      public BlockCollection<ShaderPostprocessImplementationBlockBlock> _implementationsList = new BlockCollection<ShaderPostprocessImplementationBlockBlock>();
      public BlockCollection<ShaderPostprocessBitmapBlockBlock> _bitmapsList = new BlockCollection<ShaderPostprocessBitmapBlockBlock>();
      public BlockCollection<ShaderPostprocessBitmapTransformBlockBlock> _bitmapTransformsList = new BlockCollection<ShaderPostprocessBitmapTransformBlockBlock>();
      public BlockCollection<ShaderPostprocessValueBlockBlock> _valuesList = new BlockCollection<ShaderPostprocessValueBlockBlock>();
      public BlockCollection<ShaderPostprocessColorBlockBlock> _colorsList = new BlockCollection<ShaderPostprocessColorBlockBlock>();
      public BlockCollection<ShaderPostprocessBitmapTransformOverlayBlockBlock> _bitmapTransformOverlaysList = new BlockCollection<ShaderPostprocessBitmapTransformOverlayBlockBlock>();
      public BlockCollection<ShaderPostprocessValueOverlayBlockBlock> _valueOverlaysList = new BlockCollection<ShaderPostprocessValueOverlayBlockBlock>();
      public BlockCollection<ShaderPostprocessColorOverlayBlockBlock> _colorOverlaysList = new BlockCollection<ShaderPostprocessColorOverlayBlockBlock>();
      public BlockCollection<ShaderPostprocessVertexShaderConstantBlockBlock> _vertexShaderConstantsList = new BlockCollection<ShaderPostprocessVertexShaderConstantBlockBlock>();
      public BlockCollection<RenderStateBlockBlock> _renderStatesList = new BlockCollection<RenderStateBlockBlock>();
      public BlockCollection<TextureStageStateBlockBlock> _textureStageStatesList = new BlockCollection<TextureStageStateBlockBlock>();
      public BlockCollection<RenderStateParameterBlockBlock> _renderStateParametersList = new BlockCollection<RenderStateParameterBlockBlock>();
      public BlockCollection<TextureStageStateParameterBlockBlock> _textureStageParametersList = new BlockCollection<TextureStageStateParameterBlockBlock>();
      public BlockCollection<TextureBlockBlock> _texturesList = new BlockCollection<TextureBlockBlock>();
      public BlockCollection<VertexShaderConstantBlockBlock> _vnConstantsList = new BlockCollection<VertexShaderConstantBlockBlock>();
      public BlockCollection<VertexShaderConstantBlockBlock> _cnConstantsList = new BlockCollection<VertexShaderConstantBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessLevelOfDetailBlockBlock() {
      }
      public BlockCollection<ShaderPostprocessLayerBlockBlock> Layers {
        get {
          return this._layersList;
        }
      }
      public BlockCollection<ShaderPostprocessPassBlockBlock> Passes {
        get {
          return this._passesList;
        }
      }
      public BlockCollection<ShaderPostprocessImplementationBlockBlock> Implementations {
        get {
          return this._implementationsList;
        }
      }
      public BlockCollection<ShaderPostprocessBitmapBlockBlock> Bitmaps {
        get {
          return this._bitmapsList;
        }
      }
      public BlockCollection<ShaderPostprocessBitmapTransformBlockBlock> BitmapTransforms {
        get {
          return this._bitmapTransformsList;
        }
      }
      public BlockCollection<ShaderPostprocessValueBlockBlock> Values {
        get {
          return this._valuesList;
        }
      }
      public BlockCollection<ShaderPostprocessColorBlockBlock> Colors {
        get {
          return this._colorsList;
        }
      }
      public BlockCollection<ShaderPostprocessBitmapTransformOverlayBlockBlock> BitmapTransformOverlays {
        get {
          return this._bitmapTransformOverlaysList;
        }
      }
      public BlockCollection<ShaderPostprocessValueOverlayBlockBlock> ValueOverlays {
        get {
          return this._valueOverlaysList;
        }
      }
      public BlockCollection<ShaderPostprocessColorOverlayBlockBlock> ColorOverlays {
        get {
          return this._colorOverlaysList;
        }
      }
      public BlockCollection<ShaderPostprocessVertexShaderConstantBlockBlock> VertexShaderConstants {
        get {
          return this._vertexShaderConstantsList;
        }
      }
      public BlockCollection<RenderStateBlockBlock> RenderStates {
        get {
          return this._renderStatesList;
        }
      }
      public BlockCollection<TextureStageStateBlockBlock> TextureStageStates {
        get {
          return this._textureStageStatesList;
        }
      }
      public BlockCollection<RenderStateParameterBlockBlock> RenderStateParameters {
        get {
          return this._renderStateParametersList;
        }
      }
      public BlockCollection<TextureStageStateParameterBlockBlock> TextureStageParameters {
        get {
          return this._textureStageParametersList;
        }
      }
      public BlockCollection<TextureBlockBlock> Textures {
        get {
          return this._texturesList;
        }
      }
      public BlockCollection<VertexShaderConstantBlockBlock> VnConstants {
        get {
          return this._vnConstantsList;
        }
      }
      public BlockCollection<VertexShaderConstantBlockBlock> CnConstants {
        get {
          return this._cnConstantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
for (int x=0; x<Bitmaps.BlockCount; x++)
{
  IBlock block = Bitmaps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BitmapTransforms.BlockCount; x++)
{
  IBlock block = BitmapTransforms.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Values.BlockCount; x++)
{
  IBlock block = Values.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Colors.BlockCount; x++)
{
  IBlock block = Colors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BitmapTransformOverlays.BlockCount; x++)
{
  IBlock block = BitmapTransformOverlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ValueOverlays.BlockCount; x++)
{
  IBlock block = ValueOverlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ColorOverlays.BlockCount; x++)
{
  IBlock block = ColorOverlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VertexShaderConstants.BlockCount; x++)
{
  IBlock block = VertexShaderConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RenderStates.BlockCount; x++)
{
  IBlock block = RenderStates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TextureStageStates.BlockCount; x++)
{
  IBlock block = TextureStageStates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RenderStateParameters.BlockCount; x++)
{
  IBlock block = RenderStateParameters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TextureStageParameters.BlockCount; x++)
{
  IBlock block = TextureStageParameters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Textures.BlockCount; x++)
{
  IBlock block = Textures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VnConstants.BlockCount; x++)
{
  IBlock block = VnConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CnConstants.BlockCount; x++)
{
  IBlock block = CnConstants.GetBlock(x);
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
      public Real ProjectedHeightPercentage {
        get {
          return this._projectedHeightPercentage;
        }
        set {
          this._projectedHeightPercentage = value;
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
      public virtual void Read(BinaryReader reader) {
        _projectedHeightPercentage.Read(reader);
        _availableLayers.Read(reader);
        _layers.Read(reader);
        _passes.Read(reader);
        _implementations.Read(reader);
        _bitmaps.Read(reader);
        _bitmapTransforms.Read(reader);
        _values.Read(reader);
        _colors.Read(reader);
        _bitmapTransformOverlays.Read(reader);
        _valueOverlays.Read(reader);
        _colorOverlays.Read(reader);
        _vertexShaderConstants.Read(reader);
        _renderStates.Read(reader);
        _textureStageStates.Read(reader);
        _renderStateParameters.Read(reader);
        _textureStageParameters.Read(reader);
        _textures.Read(reader);
        _vnConstants.Read(reader);
        _cnConstants.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers.Add(new ShaderPostprocessLayerBlockBlock());
          Layers[x].Read(reader);
        }
        for (x = 0; (x < _layers.Count); x = (x + 1)) {
          Layers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes.Add(new ShaderPostprocessPassBlockBlock());
          Passes[x].Read(reader);
        }
        for (x = 0; (x < _passes.Count); x = (x + 1)) {
          Passes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations.Add(new ShaderPostprocessImplementationBlockBlock());
          Implementations[x].Read(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps.Add(new ShaderPostprocessBitmapBlockBlock());
          Bitmaps[x].Read(reader);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmapTransforms.Count); x = (x + 1)) {
          BitmapTransforms.Add(new ShaderPostprocessBitmapTransformBlockBlock());
          BitmapTransforms[x].Read(reader);
        }
        for (x = 0; (x < _bitmapTransforms.Count); x = (x + 1)) {
          BitmapTransforms[x].ReadChildData(reader);
        }
        for (x = 0; (x < _values.Count); x = (x + 1)) {
          Values.Add(new ShaderPostprocessValueBlockBlock());
          Values[x].Read(reader);
        }
        for (x = 0; (x < _values.Count); x = (x + 1)) {
          Values[x].ReadChildData(reader);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors.Add(new ShaderPostprocessColorBlockBlock());
          Colors[x].Read(reader);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmapTransformOverlays.Count); x = (x + 1)) {
          BitmapTransformOverlays.Add(new ShaderPostprocessBitmapTransformOverlayBlockBlock());
          BitmapTransformOverlays[x].Read(reader);
        }
        for (x = 0; (x < _bitmapTransformOverlays.Count); x = (x + 1)) {
          BitmapTransformOverlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _valueOverlays.Count); x = (x + 1)) {
          ValueOverlays.Add(new ShaderPostprocessValueOverlayBlockBlock());
          ValueOverlays[x].Read(reader);
        }
        for (x = 0; (x < _valueOverlays.Count); x = (x + 1)) {
          ValueOverlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _colorOverlays.Count); x = (x + 1)) {
          ColorOverlays.Add(new ShaderPostprocessColorOverlayBlockBlock());
          ColorOverlays[x].Read(reader);
        }
        for (x = 0; (x < _colorOverlays.Count); x = (x + 1)) {
          ColorOverlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertexShaderConstants.Count); x = (x + 1)) {
          VertexShaderConstants.Add(new ShaderPostprocessVertexShaderConstantBlockBlock());
          VertexShaderConstants[x].Read(reader);
        }
        for (x = 0; (x < _vertexShaderConstants.Count); x = (x + 1)) {
          VertexShaderConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates.Add(new RenderStateBlockBlock());
          RenderStates[x].Read(reader);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textureStageStates.Count); x = (x + 1)) {
          TextureStageStates.Add(new TextureStageStateBlockBlock());
          TextureStageStates[x].Read(reader);
        }
        for (x = 0; (x < _textureStageStates.Count); x = (x + 1)) {
          TextureStageStates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _renderStateParameters.Count); x = (x + 1)) {
          RenderStateParameters.Add(new RenderStateParameterBlockBlock());
          RenderStateParameters[x].Read(reader);
        }
        for (x = 0; (x < _renderStateParameters.Count); x = (x + 1)) {
          RenderStateParameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textureStageParameters.Count); x = (x + 1)) {
          TextureStageParameters.Add(new TextureStageStateParameterBlockBlock());
          TextureStageParameters[x].Read(reader);
        }
        for (x = 0; (x < _textureStageParameters.Count); x = (x + 1)) {
          TextureStageParameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures.Add(new TextureBlockBlock());
          Textures[x].Read(reader);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vnConstants.Count); x = (x + 1)) {
          VnConstants.Add(new VertexShaderConstantBlockBlock());
          VnConstants[x].Read(reader);
        }
        for (x = 0; (x < _vnConstants.Count); x = (x + 1)) {
          VnConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cnConstants.Count); x = (x + 1)) {
          CnConstants.Add(new VertexShaderConstantBlockBlock());
          CnConstants[x].Read(reader);
        }
        for (x = 0; (x < _cnConstants.Count); x = (x + 1)) {
          CnConstants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _projectedHeightPercentage.Write(bw);
        _availableLayers.Write(bw);
_layers.Count = Layers.Count;
        _layers.Write(bw);
_passes.Count = Passes.Count;
        _passes.Write(bw);
_implementations.Count = Implementations.Count;
        _implementations.Write(bw);
_bitmaps.Count = Bitmaps.Count;
        _bitmaps.Write(bw);
_bitmapTransforms.Count = BitmapTransforms.Count;
        _bitmapTransforms.Write(bw);
_values.Count = Values.Count;
        _values.Write(bw);
_colors.Count = Colors.Count;
        _colors.Write(bw);
_bitmapTransformOverlays.Count = BitmapTransformOverlays.Count;
        _bitmapTransformOverlays.Write(bw);
_valueOverlays.Count = ValueOverlays.Count;
        _valueOverlays.Write(bw);
_colorOverlays.Count = ColorOverlays.Count;
        _colorOverlays.Write(bw);
_vertexShaderConstants.Count = VertexShaderConstants.Count;
        _vertexShaderConstants.Write(bw);
_renderStates.Count = RenderStates.Count;
        _renderStates.Write(bw);
_textureStageStates.Count = TextureStageStates.Count;
        _textureStageStates.Write(bw);
_renderStateParameters.Count = RenderStateParameters.Count;
        _renderStateParameters.Write(bw);
_textureStageParameters.Count = TextureStageParameters.Count;
        _textureStageParameters.Write(bw);
_textures.Count = Textures.Count;
        _textures.Write(bw);
_vnConstants.Count = VnConstants.Count;
        _vnConstants.Write(bw);
_cnConstants.Count = CnConstants.Count;
        _cnConstants.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].Write(writer);
        }
        for (x = 0; (x < _bitmaps.Count); x = (x + 1)) {
          Bitmaps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmapTransforms.Count); x = (x + 1)) {
          BitmapTransforms[x].Write(writer);
        }
        for (x = 0; (x < _bitmapTransforms.Count); x = (x + 1)) {
          BitmapTransforms[x].WriteChildData(writer);
        }
        for (x = 0; (x < _values.Count); x = (x + 1)) {
          Values[x].Write(writer);
        }
        for (x = 0; (x < _values.Count); x = (x + 1)) {
          Values[x].WriteChildData(writer);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].Write(writer);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmapTransformOverlays.Count); x = (x + 1)) {
          BitmapTransformOverlays[x].Write(writer);
        }
        for (x = 0; (x < _bitmapTransformOverlays.Count); x = (x + 1)) {
          BitmapTransformOverlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _valueOverlays.Count); x = (x + 1)) {
          ValueOverlays[x].Write(writer);
        }
        for (x = 0; (x < _valueOverlays.Count); x = (x + 1)) {
          ValueOverlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _colorOverlays.Count); x = (x + 1)) {
          ColorOverlays[x].Write(writer);
        }
        for (x = 0; (x < _colorOverlays.Count); x = (x + 1)) {
          ColorOverlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertexShaderConstants.Count); x = (x + 1)) {
          VertexShaderConstants[x].Write(writer);
        }
        for (x = 0; (x < _vertexShaderConstants.Count); x = (x + 1)) {
          VertexShaderConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].Write(writer);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textureStageStates.Count); x = (x + 1)) {
          TextureStageStates[x].Write(writer);
        }
        for (x = 0; (x < _textureStageStates.Count); x = (x + 1)) {
          TextureStageStates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _renderStateParameters.Count); x = (x + 1)) {
          RenderStateParameters[x].Write(writer);
        }
        for (x = 0; (x < _renderStateParameters.Count); x = (x + 1)) {
          RenderStateParameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textureStageParameters.Count); x = (x + 1)) {
          TextureStageParameters[x].Write(writer);
        }
        for (x = 0; (x < _textureStageParameters.Count); x = (x + 1)) {
          TextureStageParameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].Write(writer);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vnConstants.Count); x = (x + 1)) {
          VnConstants[x].Write(writer);
        }
        for (x = 0; (x < _vnConstants.Count); x = (x + 1)) {
          VnConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cnConstants.Count); x = (x + 1)) {
          CnConstants[x].Write(writer);
        }
        for (x = 0; (x < _cnConstants.Count); x = (x + 1)) {
          CnConstants[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessLayerBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessLayerBlockBlock() {
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
    public class ShaderPostprocessPassBlockBlock : IBlock {
      private TagReference _shaderPass = new TagReference();
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessPassBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shaderPass.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference ShaderPass {
        get {
          return this._shaderPass;
        }
        set {
          this._shaderPass = value;
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
        _shaderPass.Read(reader);
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shaderPass.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shaderPass.Write(bw);
        _blockIndexData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shaderPass.WriteString(writer);
      }
    }
    public class ShaderPostprocessImplementationBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
      private ShortInteger _blockIndexData2 = new ShortInteger();
      private ShortInteger _blockIndexData3 = new ShortInteger();
      private ShortInteger _blockIndexData4 = new ShortInteger();
      private ShortInteger _blockIndexData5 = new ShortInteger();
      private ShortInteger _blockIndexData6 = new ShortInteger();
      private ShortInteger _blockIndexData7 = new ShortInteger();
      private ShortInteger _blockIndexData8 = new ShortInteger();
      private ShortInteger _blockIndexData9 = new ShortInteger();
      private ShortInteger _blockIndexData10 = new ShortInteger();
      private ShortInteger _blockIndexData11 = new ShortInteger();
      private ShortInteger _blockIndexData12 = new ShortInteger();
      private ShortInteger _blockIndexData13 = new ShortInteger();
      private ShortInteger _blockIndexData14 = new ShortInteger();
      private ShortInteger _blockIndexData15 = new ShortInteger();
      private ShortInteger _blockIndexData16 = new ShortInteger();
      private ShortInteger _blockIndexData17 = new ShortInteger();
      private ShortInteger _blockIndexData18 = new ShortInteger();
      private ShortInteger _blockIndexData19 = new ShortInteger();
      private ShortInteger _blockIndexData20 = new ShortInteger();
      private ShortInteger _blockIndexData21 = new ShortInteger();
      private ShortInteger _blockIndexData22 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessImplementationBlockBlock() {
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
      public ShortInteger BlockIndexData4 {
        get {
          return this._blockIndexData4;
        }
        set {
          this._blockIndexData4 = value;
        }
      }
      public ShortInteger BlockIndexData5 {
        get {
          return this._blockIndexData5;
        }
        set {
          this._blockIndexData5 = value;
        }
      }
      public ShortInteger BlockIndexData6 {
        get {
          return this._blockIndexData6;
        }
        set {
          this._blockIndexData6 = value;
        }
      }
      public ShortInteger BlockIndexData7 {
        get {
          return this._blockIndexData7;
        }
        set {
          this._blockIndexData7 = value;
        }
      }
      public ShortInteger BlockIndexData8 {
        get {
          return this._blockIndexData8;
        }
        set {
          this._blockIndexData8 = value;
        }
      }
      public ShortInteger BlockIndexData9 {
        get {
          return this._blockIndexData9;
        }
        set {
          this._blockIndexData9 = value;
        }
      }
      public ShortInteger BlockIndexData10 {
        get {
          return this._blockIndexData10;
        }
        set {
          this._blockIndexData10 = value;
        }
      }
      public ShortInteger BlockIndexData11 {
        get {
          return this._blockIndexData11;
        }
        set {
          this._blockIndexData11 = value;
        }
      }
      public ShortInteger BlockIndexData12 {
        get {
          return this._blockIndexData12;
        }
        set {
          this._blockIndexData12 = value;
        }
      }
      public ShortInteger BlockIndexData13 {
        get {
          return this._blockIndexData13;
        }
        set {
          this._blockIndexData13 = value;
        }
      }
      public ShortInteger BlockIndexData14 {
        get {
          return this._blockIndexData14;
        }
        set {
          this._blockIndexData14 = value;
        }
      }
      public ShortInteger BlockIndexData15 {
        get {
          return this._blockIndexData15;
        }
        set {
          this._blockIndexData15 = value;
        }
      }
      public ShortInteger BlockIndexData16 {
        get {
          return this._blockIndexData16;
        }
        set {
          this._blockIndexData16 = value;
        }
      }
      public ShortInteger BlockIndexData17 {
        get {
          return this._blockIndexData17;
        }
        set {
          this._blockIndexData17 = value;
        }
      }
      public ShortInteger BlockIndexData18 {
        get {
          return this._blockIndexData18;
        }
        set {
          this._blockIndexData18 = value;
        }
      }
      public ShortInteger BlockIndexData19 {
        get {
          return this._blockIndexData19;
        }
        set {
          this._blockIndexData19 = value;
        }
      }
      public ShortInteger BlockIndexData20 {
        get {
          return this._blockIndexData20;
        }
        set {
          this._blockIndexData20 = value;
        }
      }
      public ShortInteger BlockIndexData21 {
        get {
          return this._blockIndexData21;
        }
        set {
          this._blockIndexData21 = value;
        }
      }
      public ShortInteger BlockIndexData22 {
        get {
          return this._blockIndexData22;
        }
        set {
          this._blockIndexData22 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
        _blockIndexData2.Read(reader);
        _blockIndexData3.Read(reader);
        _blockIndexData4.Read(reader);
        _blockIndexData5.Read(reader);
        _blockIndexData6.Read(reader);
        _blockIndexData7.Read(reader);
        _blockIndexData8.Read(reader);
        _blockIndexData9.Read(reader);
        _blockIndexData10.Read(reader);
        _blockIndexData11.Read(reader);
        _blockIndexData12.Read(reader);
        _blockIndexData13.Read(reader);
        _blockIndexData14.Read(reader);
        _blockIndexData15.Read(reader);
        _blockIndexData16.Read(reader);
        _blockIndexData17.Read(reader);
        _blockIndexData18.Read(reader);
        _blockIndexData19.Read(reader);
        _blockIndexData20.Read(reader);
        _blockIndexData21.Read(reader);
        _blockIndexData22.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
        _blockIndexData2.Write(bw);
        _blockIndexData3.Write(bw);
        _blockIndexData4.Write(bw);
        _blockIndexData5.Write(bw);
        _blockIndexData6.Write(bw);
        _blockIndexData7.Write(bw);
        _blockIndexData8.Write(bw);
        _blockIndexData9.Write(bw);
        _blockIndexData10.Write(bw);
        _blockIndexData11.Write(bw);
        _blockIndexData12.Write(bw);
        _blockIndexData13.Write(bw);
        _blockIndexData14.Write(bw);
        _blockIndexData15.Write(bw);
        _blockIndexData16.Write(bw);
        _blockIndexData17.Write(bw);
        _blockIndexData18.Write(bw);
        _blockIndexData19.Write(bw);
        _blockIndexData20.Write(bw);
        _blockIndexData21.Write(bw);
        _blockIndexData22.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessBitmapBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _flags = new CharInteger();
      private LongInteger _bitmapGroupIndex = new LongInteger();
      private Real _logBitmapDimension = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessBitmapBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public LongInteger BitmapGroupIndex {
        get {
          return this._bitmapGroupIndex;
        }
        set {
          this._bitmapGroupIndex = value;
        }
      }
      public Real LogBitmapDimension {
        get {
          return this._logBitmapDimension;
        }
        set {
          this._logBitmapDimension = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _flags.Read(reader);
        _bitmapGroupIndex.Read(reader);
        _logBitmapDimension.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _flags.Write(bw);
        _bitmapGroupIndex.Write(bw);
        _logBitmapDimension.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessBitmapTransformBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _bitmapTransformIndex = new CharInteger();
      private Real _value = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessBitmapTransformBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger BitmapTransformIndex {
        get {
          return this._bitmapTransformIndex;
        }
        set {
          this._bitmapTransformIndex = value;
        }
      }
      public Real Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _bitmapTransformIndex.Read(reader);
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _bitmapTransformIndex.Write(bw);
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessValueBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private Real _value = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessValueBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public Real Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessColorBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private RealRGBColor _color = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessColorBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPostprocessBitmapTransformOverlayBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _transformIndex = new CharInteger();
      private CharInteger _animationPropertyType = new CharInteger();
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriodInSeconds = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessBitmapTransformOverlayBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger TransformIndex {
        get {
          return this._transformIndex;
        }
        set {
          this._transformIndex = value;
        }
      }
      public CharInteger AnimationPropertyType {
        get {
          return this._animationPropertyType;
        }
        set {
          this._animationPropertyType = value;
        }
      }
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriodInSeconds {
        get {
          return this._timePeriodInSeconds;
        }
        set {
          this._timePeriodInSeconds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _transformIndex.Read(reader);
        _animationPropertyType.Read(reader);
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriodInSeconds.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _transformIndex.Write(bw);
        _animationPropertyType.Write(bw);
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriodInSeconds.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessValueOverlayBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriodInSeconds = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessValueOverlayBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriodInSeconds {
        get {
          return this._timePeriodInSeconds;
        }
        set {
          this._timePeriodInSeconds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriodInSeconds.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriodInSeconds.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessColorOverlayBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriodInSeconds = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessColorOverlayBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriodInSeconds {
        get {
          return this._timePeriodInSeconds;
        }
        set {
          this._timePeriodInSeconds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriodInSeconds.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriodInSeconds.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPostprocessVertexShaderConstantBlockBlock : IBlock {
      private CharInteger _registerIndex = new CharInteger();
      private CharInteger _registerBank = new CharInteger();
      private Real _data = new Real();
      private Real _data2 = new Real();
      private Real _data3 = new Real();
      private Real _data4 = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderPostprocessVertexShaderConstantBlockBlock() {
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
      public CharInteger RegisterIndex {
        get {
          return this._registerIndex;
        }
        set {
          this._registerIndex = value;
        }
      }
      public CharInteger RegisterBank {
        get {
          return this._registerBank;
        }
        set {
          this._registerBank = value;
        }
      }
      public Real Data {
        get {
          return this._data;
        }
        set {
          this._data = value;
        }
      }
      public Real Data2 {
        get {
          return this._data2;
        }
        set {
          this._data2 = value;
        }
      }
      public Real Data3 {
        get {
          return this._data3;
        }
        set {
          this._data3 = value;
        }
      }
      public Real Data4 {
        get {
          return this._data4;
        }
        set {
          this._data4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _registerIndex.Read(reader);
        _registerBank.Read(reader);
        _data.Read(reader);
        _data2.Read(reader);
        _data3.Read(reader);
        _data4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _registerIndex.Write(bw);
        _registerBank.Write(bw);
        _data.Write(bw);
        _data2.Write(bw);
        _data3.Write(bw);
        _data4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RenderStateBlockBlock : IBlock {
      private CharInteger _stateIndex = new CharInteger();
      private LongInteger _stateValue = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public RenderStateBlockBlock() {
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
      public CharInteger StateIndex {
        get {
          return this._stateIndex;
        }
        set {
          this._stateIndex = value;
        }
      }
      public LongInteger StateValue {
        get {
          return this._stateValue;
        }
        set {
          this._stateValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stateIndex.Read(reader);
        _stateValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stateIndex.Write(bw);
        _stateValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class TextureStageStateBlockBlock : IBlock {
      private CharInteger _stateIndex = new CharInteger();
      private CharInteger _stageIndex = new CharInteger();
      private LongInteger _stateValue = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public TextureStageStateBlockBlock() {
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
      public CharInteger StateIndex {
        get {
          return this._stateIndex;
        }
        set {
          this._stateIndex = value;
        }
      }
      public CharInteger StageIndex {
        get {
          return this._stageIndex;
        }
        set {
          this._stageIndex = value;
        }
      }
      public LongInteger StateValue {
        get {
          return this._stateValue;
        }
        set {
          this._stateValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stateIndex.Read(reader);
        _stageIndex.Read(reader);
        _stateValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stateIndex.Write(bw);
        _stageIndex.Write(bw);
        _stateValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RenderStateParameterBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _parameterType = new CharInteger();
      private CharInteger _stateIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public RenderStateParameterBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger ParameterType {
        get {
          return this._parameterType;
        }
        set {
          this._parameterType = value;
        }
      }
      public CharInteger StateIndex {
        get {
          return this._stateIndex;
        }
        set {
          this._stateIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _parameterType.Read(reader);
        _stateIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _parameterType.Write(bw);
        _stateIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class TextureStageStateParameterBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _parameterType = new CharInteger();
      private CharInteger _stateIndex = new CharInteger();
      private CharInteger _stageIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public TextureStageStateParameterBlockBlock() {
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
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger ParameterType {
        get {
          return this._parameterType;
        }
        set {
          this._parameterType = value;
        }
      }
      public CharInteger StateIndex {
        get {
          return this._stateIndex;
        }
        set {
          this._stateIndex = value;
        }
      }
      public CharInteger StageIndex {
        get {
          return this._stageIndex;
        }
        set {
          this._stageIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _parameterType.Read(reader);
        _stateIndex.Read(reader);
        _stageIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _parameterType.Write(bw);
        _stateIndex.Write(bw);
        _stageIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class TextureBlockBlock : IBlock {
      private CharInteger _stageIndex = new CharInteger();
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _globalTextureIndex = new CharInteger();
      private CharInteger _flags = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public TextureBlockBlock() {
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
      public CharInteger StageIndex {
        get {
          return this._stageIndex;
        }
        set {
          this._stageIndex = value;
        }
      }
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger GlobalTextureIndex {
        get {
          return this._globalTextureIndex;
        }
        set {
          this._globalTextureIndex = value;
        }
      }
      public CharInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stageIndex.Read(reader);
        _parameterIndex.Read(reader);
        _globalTextureIndex.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stageIndex.Write(bw);
        _parameterIndex.Write(bw);
        _globalTextureIndex.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class VertexShaderConstantBlockBlock : IBlock {
      private CharInteger _registerIndex = new CharInteger();
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _destinationMask = new CharInteger();
      private CharInteger _scaleByTextureStage = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public VertexShaderConstantBlockBlock() {
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
      public CharInteger RegisterIndex {
        get {
          return this._registerIndex;
        }
        set {
          this._registerIndex = value;
        }
      }
      public CharInteger ParameterIndex {
        get {
          return this._parameterIndex;
        }
        set {
          this._parameterIndex = value;
        }
      }
      public CharInteger DestinationMask {
        get {
          return this._destinationMask;
        }
        set {
          this._destinationMask = value;
        }
      }
      public CharInteger ScaleByTextureStage {
        get {
          return this._scaleByTextureStage;
        }
        set {
          this._scaleByTextureStage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _registerIndex.Read(reader);
        _parameterIndex.Read(reader);
        _destinationMask.Read(reader);
        _scaleByTextureStage.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _registerIndex.Write(bw);
        _parameterIndex.Write(bw);
        _destinationMask.Write(bw);
        _scaleByTextureStage.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PredictedResourceBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _resourceIndex = new ShortInteger();
      private PredictedResource _predictedResourceTag = new PredictedResource();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlockBlock() {
        this._type = new Enum(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger ResourceIndex {
        get {
          return this._resourceIndex;
        }
        set {
          this._resourceIndex = value;
        }
      }
      public PredictedResource PredictedResourceTag {
        get {
          return this._predictedResourceTag;
        }
        set {
          this._predictedResourceTag = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _predictedResourceTag.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _predictedResourceTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _predictedResourceTag.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _predictedResourceTag.WriteString(writer);
      }
    }
    public class LongBlockBlock : IBlock {
      private LongInteger _bitmapGroupIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public LongBlockBlock() {
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
      public LongInteger BitmapGroupIndex {
        get {
          return this._bitmapGroupIndex;
        }
        set {
          this._bitmapGroupIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmapGroupIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapGroupIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
