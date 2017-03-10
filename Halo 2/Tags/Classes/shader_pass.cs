// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'shader_pass'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class shader_pass : Interfaces.Pool.Tag {
    private ShaderPassBlockBlock shaderPassValues = new ShaderPassBlockBlock();
    public virtual ShaderPassBlockBlock ShaderPassValues {
      get {
        return shaderPassValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ShaderPassValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_pass";
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
shaderPassValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
shaderPassValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
shaderPassValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
shaderPassValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderPassBlockBlock : IBlock {
      private Data _documentation = new Data();
      private Block _parameters = new Block();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Block _implementations = new Block();
      private Block _postprocessDefinition = new Block();
      public BlockCollection<ShaderPassParameterBlockBlock> _parametersList = new BlockCollection<ShaderPassParameterBlockBlock>();
      public BlockCollection<ShaderPassImplementationBlockBlock> _implementationsList = new BlockCollection<ShaderPassImplementationBlockBlock>();
      public BlockCollection<ShaderPassPostprocessDefinitionNewBlockBlock> _postprocessDefinitionList = new BlockCollection<ShaderPassPostprocessDefinitionNewBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPassBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<ShaderPassParameterBlockBlock> Parameters {
        get {
          return this._parametersList;
        }
      }
      public BlockCollection<ShaderPassImplementationBlockBlock> Implementations {
        get {
          return this._implementationsList;
        }
      }
      public BlockCollection<ShaderPassPostprocessDefinitionNewBlockBlock> PostprocessDefinition {
        get {
          return this._postprocessDefinitionList;
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
for (int x=0; x<Implementations.BlockCount; x++)
{
  IBlock block = Implementations.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _documentation.Read(reader);
        _parameters.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _implementations.Read(reader);
        _postprocessDefinition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _documentation.ReadBinary(reader);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters.Add(new ShaderPassParameterBlockBlock());
          Parameters[x].Read(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations.Add(new ShaderPassImplementationBlockBlock());
          Implementations[x].Read(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition.Add(new ShaderPassPostprocessDefinitionNewBlockBlock());
          PostprocessDefinition[x].Read(reader);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _documentation.Write(bw);
_parameters.Count = Parameters.Count;
        _parameters.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_implementations.Count = Implementations.Count;
        _implementations.Write(bw);
_postprocessDefinition.Count = PostprocessDefinition.Count;
        _postprocessDefinition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _documentation.WriteBinary(writer);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].Write(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].Write(writer);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].Write(writer);
        }
        for (x = 0; (x < _postprocessDefinition.Count); x = (x + 1)) {
          PostprocessDefinition[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPassParameterBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Data _explanation = new Data();
      private Enum _type;
      private Flags _flags;
      private TagReference _defaultBitmap = new TagReference();
      private Real _defaultConstValue = new Real();
      private RealRGBColor _defaultConstColor = new RealRGBColor();
      private Enum _sourceExtern;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderPassParameterBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._sourceExtern = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Enum SourceExtern {
        get {
          return this._sourceExtern;
        }
        set {
          this._sourceExtern = value;
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
        _sourceExtern.Read(reader);
        _unnamed0.Read(reader);
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
        _sourceExtern.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _explanation.WriteBinary(writer);
        _defaultBitmap.WriteString(writer);
      }
    }
    public class ShaderPassImplementationBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Block _textures = new Block();
      private TagReference _vertexShader = new TagReference();
      private Block _vsConstants = new Block();
      private Data _pixelShaderCodeNOLONGERUSED = new Data();
      private Enum _channels;
      private Enum _alpha_Minusblend;
      private Enum _depth;
      private Pad _unnamed1;
      private Block _channelState = new Block();
      private Block _alpha_MinusblendState = new Block();
      private Block _alpha_MinustestState = new Block();
      private Block _depthState = new Block();
      private Block _cullState = new Block();
      private Block _fillState = new Block();
      private Block _miscState = new Block();
      private Block _constants = new Block();
      private TagReference _pixelShader = new TagReference();
      public BlockCollection<ShaderPassTextureBlockBlock> _texturesList = new BlockCollection<ShaderPassTextureBlockBlock>();
      public BlockCollection<ShaderPassVertexShaderConstantBlockBlock> _vsConstantsList = new BlockCollection<ShaderPassVertexShaderConstantBlockBlock>();
      public BlockCollection<ShaderStateChannelsStateBlockBlock> _channelStateList = new BlockCollection<ShaderStateChannelsStateBlockBlock>();
      public BlockCollection<ShaderStateAlphaBlendStateBlockBlock> _alpha_MinusblendStateList = new BlockCollection<ShaderStateAlphaBlendStateBlockBlock>();
      public BlockCollection<ShaderStateAlphaTestStateBlockBlock> _alpha_MinustestStateList = new BlockCollection<ShaderStateAlphaTestStateBlockBlock>();
      public BlockCollection<ShaderStateDepthStateBlockBlock> _depthStateList = new BlockCollection<ShaderStateDepthStateBlockBlock>();
      public BlockCollection<ShaderStateCullStateBlockBlock> _cullStateList = new BlockCollection<ShaderStateCullStateBlockBlock>();
      public BlockCollection<ShaderStateFillStateBlockBlock> _fillStateList = new BlockCollection<ShaderStateFillStateBlockBlock>();
      public BlockCollection<ShaderStateMiscStateBlockBlock> _miscStateList = new BlockCollection<ShaderStateMiscStateBlockBlock>();
      public BlockCollection<ShaderStateConstantBlockBlock> _constantsList = new BlockCollection<ShaderStateConstantBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPassImplementationBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._channels = new Enum(2);
        this._alpha_Minusblend = new Enum(2);
        this._depth = new Enum(2);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<ShaderPassTextureBlockBlock> Textures {
        get {
          return this._texturesList;
        }
      }
      public BlockCollection<ShaderPassVertexShaderConstantBlockBlock> VsConstants {
        get {
          return this._vsConstantsList;
        }
      }
      public BlockCollection<ShaderStateChannelsStateBlockBlock> ChannelState {
        get {
          return this._channelStateList;
        }
      }
      public BlockCollection<ShaderStateAlphaBlendStateBlockBlock> Alpha_MinusblendState {
        get {
          return this._alpha_MinusblendStateList;
        }
      }
      public BlockCollection<ShaderStateAlphaTestStateBlockBlock> Alpha_MinustestState {
        get {
          return this._alpha_MinustestStateList;
        }
      }
      public BlockCollection<ShaderStateDepthStateBlockBlock> DepthState {
        get {
          return this._depthStateList;
        }
      }
      public BlockCollection<ShaderStateCullStateBlockBlock> CullState {
        get {
          return this._cullStateList;
        }
      }
      public BlockCollection<ShaderStateFillStateBlockBlock> FillState {
        get {
          return this._fillStateList;
        }
      }
      public BlockCollection<ShaderStateMiscStateBlockBlock> MiscState {
        get {
          return this._miscStateList;
        }
      }
      public BlockCollection<ShaderStateConstantBlockBlock> Constants {
        get {
          return this._constantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vertexShader.Value);
references.Add(_pixelShader.Value);
for (int x=0; x<Textures.BlockCount; x++)
{
  IBlock block = Textures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VsConstants.BlockCount; x++)
{
  IBlock block = VsConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ChannelState.BlockCount; x++)
{
  IBlock block = ChannelState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Alpha_MinusblendState.BlockCount; x++)
{
  IBlock block = Alpha_MinusblendState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Alpha_MinustestState.BlockCount; x++)
{
  IBlock block = Alpha_MinustestState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DepthState.BlockCount; x++)
{
  IBlock block = DepthState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CullState.BlockCount; x++)
{
  IBlock block = CullState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FillState.BlockCount; x++)
{
  IBlock block = FillState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MiscState.BlockCount; x++)
{
  IBlock block = MiscState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Constants.BlockCount; x++)
{
  IBlock block = Constants.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public TagReference VertexShader {
        get {
          return this._vertexShader;
        }
        set {
          this._vertexShader = value;
        }
      }
      public Data PixelShaderCodeNOLONGERUSED {
        get {
          return this._pixelShaderCodeNOLONGERUSED;
        }
        set {
          this._pixelShaderCodeNOLONGERUSED = value;
        }
      }
      public Enum Channels {
        get {
          return this._channels;
        }
        set {
          this._channels = value;
        }
      }
      public Enum Alpha_Minusblend {
        get {
          return this._alpha_Minusblend;
        }
        set {
          this._alpha_Minusblend = value;
        }
      }
      public Enum Depth {
        get {
          return this._depth;
        }
        set {
          this._depth = value;
        }
      }
      public TagReference PixelShader {
        get {
          return this._pixelShader;
        }
        set {
          this._pixelShader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _textures.Read(reader);
        _vertexShader.Read(reader);
        _vsConstants.Read(reader);
        _pixelShaderCodeNOLONGERUSED.Read(reader);
        _channels.Read(reader);
        _alpha_Minusblend.Read(reader);
        _depth.Read(reader);
        _unnamed1.Read(reader);
        _channelState.Read(reader);
        _alpha_MinusblendState.Read(reader);
        _alpha_MinustestState.Read(reader);
        _depthState.Read(reader);
        _cullState.Read(reader);
        _fillState.Read(reader);
        _miscState.Read(reader);
        _constants.Read(reader);
        _pixelShader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures.Add(new ShaderPassTextureBlockBlock());
          Textures[x].Read(reader);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].ReadChildData(reader);
        }
        _vertexShader.ReadString(reader);
        for (x = 0; (x < _vsConstants.Count); x = (x + 1)) {
          VsConstants.Add(new ShaderPassVertexShaderConstantBlockBlock());
          VsConstants[x].Read(reader);
        }
        for (x = 0; (x < _vsConstants.Count); x = (x + 1)) {
          VsConstants[x].ReadChildData(reader);
        }
        _pixelShaderCodeNOLONGERUSED.ReadBinary(reader);
        for (x = 0; (x < _channelState.Count); x = (x + 1)) {
          ChannelState.Add(new ShaderStateChannelsStateBlockBlock());
          ChannelState[x].Read(reader);
        }
        for (x = 0; (x < _channelState.Count); x = (x + 1)) {
          ChannelState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _alpha_MinusblendState.Count); x = (x + 1)) {
          Alpha_MinusblendState.Add(new ShaderStateAlphaBlendStateBlockBlock());
          Alpha_MinusblendState[x].Read(reader);
        }
        for (x = 0; (x < _alpha_MinusblendState.Count); x = (x + 1)) {
          Alpha_MinusblendState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _alpha_MinustestState.Count); x = (x + 1)) {
          Alpha_MinustestState.Add(new ShaderStateAlphaTestStateBlockBlock());
          Alpha_MinustestState[x].Read(reader);
        }
        for (x = 0; (x < _alpha_MinustestState.Count); x = (x + 1)) {
          Alpha_MinustestState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _depthState.Count); x = (x + 1)) {
          DepthState.Add(new ShaderStateDepthStateBlockBlock());
          DepthState[x].Read(reader);
        }
        for (x = 0; (x < _depthState.Count); x = (x + 1)) {
          DepthState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cullState.Count); x = (x + 1)) {
          CullState.Add(new ShaderStateCullStateBlockBlock());
          CullState[x].Read(reader);
        }
        for (x = 0; (x < _cullState.Count); x = (x + 1)) {
          CullState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fillState.Count); x = (x + 1)) {
          FillState.Add(new ShaderStateFillStateBlockBlock());
          FillState[x].Read(reader);
        }
        for (x = 0; (x < _fillState.Count); x = (x + 1)) {
          FillState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState.Add(new ShaderStateMiscStateBlockBlock());
          MiscState[x].Read(reader);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants.Add(new ShaderStateConstantBlockBlock());
          Constants[x].Read(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].ReadChildData(reader);
        }
        _pixelShader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
_textures.Count = Textures.Count;
        _textures.Write(bw);
        _vertexShader.Write(bw);
_vsConstants.Count = VsConstants.Count;
        _vsConstants.Write(bw);
        _pixelShaderCodeNOLONGERUSED.Write(bw);
        _channels.Write(bw);
        _alpha_Minusblend.Write(bw);
        _depth.Write(bw);
        _unnamed1.Write(bw);
_channelState.Count = ChannelState.Count;
        _channelState.Write(bw);
_alpha_MinusblendState.Count = Alpha_MinusblendState.Count;
        _alpha_MinusblendState.Write(bw);
_alpha_MinustestState.Count = Alpha_MinustestState.Count;
        _alpha_MinustestState.Write(bw);
_depthState.Count = DepthState.Count;
        _depthState.Write(bw);
_cullState.Count = CullState.Count;
        _cullState.Write(bw);
_fillState.Count = FillState.Count;
        _fillState.Write(bw);
_miscState.Count = MiscState.Count;
        _miscState.Write(bw);
_constants.Count = Constants.Count;
        _constants.Write(bw);
        _pixelShader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].Write(writer);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].WriteChildData(writer);
        }
        _vertexShader.WriteString(writer);
        for (x = 0; (x < _vsConstants.Count); x = (x + 1)) {
          VsConstants[x].Write(writer);
        }
        for (x = 0; (x < _vsConstants.Count); x = (x + 1)) {
          VsConstants[x].WriteChildData(writer);
        }
        _pixelShaderCodeNOLONGERUSED.WriteBinary(writer);
        for (x = 0; (x < _channelState.Count); x = (x + 1)) {
          ChannelState[x].Write(writer);
        }
        for (x = 0; (x < _channelState.Count); x = (x + 1)) {
          ChannelState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _alpha_MinusblendState.Count); x = (x + 1)) {
          Alpha_MinusblendState[x].Write(writer);
        }
        for (x = 0; (x < _alpha_MinusblendState.Count); x = (x + 1)) {
          Alpha_MinusblendState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _alpha_MinustestState.Count); x = (x + 1)) {
          Alpha_MinustestState[x].Write(writer);
        }
        for (x = 0; (x < _alpha_MinustestState.Count); x = (x + 1)) {
          Alpha_MinustestState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _depthState.Count); x = (x + 1)) {
          DepthState[x].Write(writer);
        }
        for (x = 0; (x < _depthState.Count); x = (x + 1)) {
          DepthState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cullState.Count); x = (x + 1)) {
          CullState[x].Write(writer);
        }
        for (x = 0; (x < _cullState.Count); x = (x + 1)) {
          CullState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fillState.Count); x = (x + 1)) {
          FillState[x].Write(writer);
        }
        for (x = 0; (x < _fillState.Count); x = (x + 1)) {
          FillState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].Write(writer);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].Write(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].WriteChildData(writer);
        }
        _pixelShader.WriteString(writer);
      }
    }
    public class ShaderPassTextureBlockBlock : IBlock {
      private StringId _sourceParameter = new StringId();
      private Enum _sourceExtern;
      private Pad _unnamed0;
      private Skip _unnamed1;
      private Enum _mode;
      private Pad _unnamed2;
      private Enum _dotMapping;
      private ShortInteger _inputStage = new ShortInteger();
      private Pad _unnamed3;
      private Block _addressState = new Block();
      private Block _filterState = new Block();
      private Block _killState = new Block();
      private Block _miscState = new Block();
      private Block _constants = new Block();
      public BlockCollection<ShaderTextureStateAddressStateBlockBlock> _addressStateList = new BlockCollection<ShaderTextureStateAddressStateBlockBlock>();
      public BlockCollection<ShaderTextureStateFilterStateBlockBlock> _filterStateList = new BlockCollection<ShaderTextureStateFilterStateBlockBlock>();
      public BlockCollection<ShaderTextureStateKillStateBlockBlock> _killStateList = new BlockCollection<ShaderTextureStateKillStateBlockBlock>();
      public BlockCollection<ShaderTextureStateMiscStateBlockBlock> _miscStateList = new BlockCollection<ShaderTextureStateMiscStateBlockBlock>();
      public BlockCollection<ShaderTextureStateConstantBlockBlock> _constantsList = new BlockCollection<ShaderTextureStateConstantBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPassTextureBlockBlock() {
        this._sourceExtern = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Skip(2);
        this._mode = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._dotMapping = new Enum(2);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<ShaderTextureStateAddressStateBlockBlock> AddressState {
        get {
          return this._addressStateList;
        }
      }
      public BlockCollection<ShaderTextureStateFilterStateBlockBlock> FilterState {
        get {
          return this._filterStateList;
        }
      }
      public BlockCollection<ShaderTextureStateKillStateBlockBlock> KillState {
        get {
          return this._killStateList;
        }
      }
      public BlockCollection<ShaderTextureStateMiscStateBlockBlock> MiscState {
        get {
          return this._miscStateList;
        }
      }
      public BlockCollection<ShaderTextureStateConstantBlockBlock> Constants {
        get {
          return this._constantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<AddressState.BlockCount; x++)
{
  IBlock block = AddressState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FilterState.BlockCount; x++)
{
  IBlock block = FilterState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<KillState.BlockCount; x++)
{
  IBlock block = KillState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MiscState.BlockCount; x++)
{
  IBlock block = MiscState.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Constants.BlockCount; x++)
{
  IBlock block = Constants.GetBlock(x);
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
      public StringId SourceParameter {
        get {
          return this._sourceParameter;
        }
        set {
          this._sourceParameter = value;
        }
      }
      public Enum SourceExtern {
        get {
          return this._sourceExtern;
        }
        set {
          this._sourceExtern = value;
        }
      }
      public Enum Mode {
        get {
          return this._mode;
        }
        set {
          this._mode = value;
        }
      }
      public Enum DotMapping {
        get {
          return this._dotMapping;
        }
        set {
          this._dotMapping = value;
        }
      }
      public ShortInteger InputStage {
        get {
          return this._inputStage;
        }
        set {
          this._inputStage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sourceParameter.Read(reader);
        _sourceExtern.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _mode.Read(reader);
        _unnamed2.Read(reader);
        _dotMapping.Read(reader);
        _inputStage.Read(reader);
        _unnamed3.Read(reader);
        _addressState.Read(reader);
        _filterState.Read(reader);
        _killState.Read(reader);
        _miscState.Read(reader);
        _constants.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _sourceParameter.ReadString(reader);
        for (x = 0; (x < _addressState.Count); x = (x + 1)) {
          AddressState.Add(new ShaderTextureStateAddressStateBlockBlock());
          AddressState[x].Read(reader);
        }
        for (x = 0; (x < _addressState.Count); x = (x + 1)) {
          AddressState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _filterState.Count); x = (x + 1)) {
          FilterState.Add(new ShaderTextureStateFilterStateBlockBlock());
          FilterState[x].Read(reader);
        }
        for (x = 0; (x < _filterState.Count); x = (x + 1)) {
          FilterState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _killState.Count); x = (x + 1)) {
          KillState.Add(new ShaderTextureStateKillStateBlockBlock());
          KillState[x].Read(reader);
        }
        for (x = 0; (x < _killState.Count); x = (x + 1)) {
          KillState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState.Add(new ShaderTextureStateMiscStateBlockBlock());
          MiscState[x].Read(reader);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].ReadChildData(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants.Add(new ShaderTextureStateConstantBlockBlock());
          Constants[x].Read(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _sourceParameter.Write(bw);
        _sourceExtern.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _mode.Write(bw);
        _unnamed2.Write(bw);
        _dotMapping.Write(bw);
        _inputStage.Write(bw);
        _unnamed3.Write(bw);
_addressState.Count = AddressState.Count;
        _addressState.Write(bw);
_filterState.Count = FilterState.Count;
        _filterState.Write(bw);
_killState.Count = KillState.Count;
        _killState.Write(bw);
_miscState.Count = MiscState.Count;
        _miscState.Write(bw);
_constants.Count = Constants.Count;
        _constants.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _sourceParameter.WriteString(writer);
        for (x = 0; (x < _addressState.Count); x = (x + 1)) {
          AddressState[x].Write(writer);
        }
        for (x = 0; (x < _addressState.Count); x = (x + 1)) {
          AddressState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _filterState.Count); x = (x + 1)) {
          FilterState[x].Write(writer);
        }
        for (x = 0; (x < _filterState.Count); x = (x + 1)) {
          FilterState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _killState.Count); x = (x + 1)) {
          KillState[x].Write(writer);
        }
        for (x = 0; (x < _killState.Count); x = (x + 1)) {
          KillState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].Write(writer);
        }
        for (x = 0; (x < _miscState.Count); x = (x + 1)) {
          MiscState[x].WriteChildData(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].Write(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTextureStateAddressStateBlockBlock : IBlock {
      private Enum _uAddressMode;
      private Enum _vAddressMode;
      private Enum _wAddressMode;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderTextureStateAddressStateBlockBlock() {
        this._uAddressMode = new Enum(2);
        this._vAddressMode = new Enum(2);
        this._wAddressMode = new Enum(2);
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
return "";
        }
      }
      public Enum UAddressMode {
        get {
          return this._uAddressMode;
        }
        set {
          this._uAddressMode = value;
        }
      }
      public Enum VAddressMode {
        get {
          return this._vAddressMode;
        }
        set {
          this._vAddressMode = value;
        }
      }
      public Enum WAddressMode {
        get {
          return this._wAddressMode;
        }
        set {
          this._wAddressMode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uAddressMode.Read(reader);
        _vAddressMode.Read(reader);
        _wAddressMode.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _uAddressMode.Write(bw);
        _vAddressMode.Write(bw);
        _wAddressMode.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTextureStateFilterStateBlockBlock : IBlock {
      private Enum _magFilter;
      private Enum _minFilter;
      private Enum _mipFilter;
      private Pad _unnamed0;
      private Real _mipmapBias = new Real();
      private ShortInteger _maxMipmapIndex = new ShortInteger();
      private Enum _anisotropy;
public event System.EventHandler BlockNameChanged;
      public ShaderTextureStateFilterStateBlockBlock() {
        this._magFilter = new Enum(2);
        this._minFilter = new Enum(2);
        this._mipFilter = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._anisotropy = new Enum(2);
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
      public Enum MagFilter {
        get {
          return this._magFilter;
        }
        set {
          this._magFilter = value;
        }
      }
      public Enum MinFilter {
        get {
          return this._minFilter;
        }
        set {
          this._minFilter = value;
        }
      }
      public Enum MipFilter {
        get {
          return this._mipFilter;
        }
        set {
          this._mipFilter = value;
        }
      }
      public Real MipmapBias {
        get {
          return this._mipmapBias;
        }
        set {
          this._mipmapBias = value;
        }
      }
      public ShortInteger MaxMipmapIndex {
        get {
          return this._maxMipmapIndex;
        }
        set {
          this._maxMipmapIndex = value;
        }
      }
      public Enum Anisotropy {
        get {
          return this._anisotropy;
        }
        set {
          this._anisotropy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _magFilter.Read(reader);
        _minFilter.Read(reader);
        _mipFilter.Read(reader);
        _unnamed0.Read(reader);
        _mipmapBias.Read(reader);
        _maxMipmapIndex.Read(reader);
        _anisotropy.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _magFilter.Write(bw);
        _minFilter.Write(bw);
        _mipFilter.Write(bw);
        _unnamed0.Write(bw);
        _mipmapBias.Write(bw);
        _maxMipmapIndex.Write(bw);
        _anisotropy.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTextureStateKillStateBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Enum _colorkeyMode;
      private Pad _unnamed1;
      private RGBColor _colorkeyColor = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public ShaderTextureStateKillStateBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._colorkeyMode = new Enum(2);
        this._unnamed1 = new Pad(2);
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
      public Enum ColorkeyMode {
        get {
          return this._colorkeyMode;
        }
        set {
          this._colorkeyMode = value;
        }
      }
      public RGBColor ColorkeyColor {
        get {
          return this._colorkeyColor;
        }
        set {
          this._colorkeyColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _colorkeyMode.Read(reader);
        _unnamed1.Read(reader);
        _colorkeyColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _colorkeyMode.Write(bw);
        _unnamed1.Write(bw);
        _colorkeyColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTextureStateMiscStateBlockBlock : IBlock {
      private Flags _componentSignFlags;
      private Pad _unnamed0;
      private ARGBColor _borderColor = new ARGBColor();
public event System.EventHandler BlockNameChanged;
      public ShaderTextureStateMiscStateBlockBlock() {
        this._componentSignFlags = new Flags(2);
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
return "";
        }
      }
      public Flags ComponentSignFlags {
        get {
          return this._componentSignFlags;
        }
        set {
          this._componentSignFlags = value;
        }
      }
      public ARGBColor BorderColor {
        get {
          return this._borderColor;
        }
        set {
          this._borderColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _componentSignFlags.Read(reader);
        _unnamed0.Read(reader);
        _borderColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _componentSignFlags.Write(bw);
        _unnamed0.Write(bw);
        _borderColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderTextureStateConstantBlockBlock : IBlock {
      private StringId _sourceParameter = new StringId();
      private Pad _unnamed0;
      private Enum _constant;
public event System.EventHandler BlockNameChanged;
      public ShaderTextureStateConstantBlockBlock() {
if (this._constant is System.ComponentModel.INotifyPropertyChanged)
  (this._constant as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._constant = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _constant.ToString();
        }
      }
      public StringId SourceParameter {
        get {
          return this._sourceParameter;
        }
        set {
          this._sourceParameter = value;
        }
      }
      public Enum Constant {
        get {
          return this._constant;
        }
        set {
          this._constant = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sourceParameter.Read(reader);
        _unnamed0.Read(reader);
        _constant.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sourceParameter.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sourceParameter.Write(bw);
        _unnamed0.Write(bw);
        _constant.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sourceParameter.WriteString(writer);
      }
    }
    public class ShaderPassVertexShaderConstantBlockBlock : IBlock {
      private StringId _sourceParameter = new StringId();
      private Enum _scaleByTextureStage;
      private Enum _registerBank;
      private ShortInteger _registerIndex = new ShortInteger();
      private Enum _componentMask;
public event System.EventHandler BlockNameChanged;
      public ShaderPassVertexShaderConstantBlockBlock() {
        this._scaleByTextureStage = new Enum(2);
        this._registerBank = new Enum(2);
        this._componentMask = new Enum(2);
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
      public StringId SourceParameter {
        get {
          return this._sourceParameter;
        }
        set {
          this._sourceParameter = value;
        }
      }
      public Enum ScaleByTextureStage {
        get {
          return this._scaleByTextureStage;
        }
        set {
          this._scaleByTextureStage = value;
        }
      }
      public Enum RegisterBank {
        get {
          return this._registerBank;
        }
        set {
          this._registerBank = value;
        }
      }
      public ShortInteger RegisterIndex {
        get {
          return this._registerIndex;
        }
        set {
          this._registerIndex = value;
        }
      }
      public Enum ComponentMask {
        get {
          return this._componentMask;
        }
        set {
          this._componentMask = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sourceParameter.Read(reader);
        _scaleByTextureStage.Read(reader);
        _registerBank.Read(reader);
        _registerIndex.Read(reader);
        _componentMask.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sourceParameter.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sourceParameter.Write(bw);
        _scaleByTextureStage.Write(bw);
        _registerBank.Write(bw);
        _registerIndex.Write(bw);
        _componentMask.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sourceParameter.WriteString(writer);
      }
    }
    public class ShaderStateChannelsStateBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderStateChannelsStateBlockBlock() {
        this._flags = new Flags(2);
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateAlphaBlendStateBlockBlock : IBlock {
      private Enum _blendFunction;
      private Enum _blendSrcFactor;
      private Enum _blendDstFactor;
      private Pad _unnamed0;
      private ARGBColor _blendColor = new ARGBColor();
      private Flags _logic_MinusopFlags;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ShaderStateAlphaBlendStateBlockBlock() {
        this._blendFunction = new Enum(2);
        this._blendSrcFactor = new Enum(2);
        this._blendDstFactor = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._logic_MinusopFlags = new Flags(2);
        this._unnamed1 = new Pad(2);
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
      public Enum BlendFunction {
        get {
          return this._blendFunction;
        }
        set {
          this._blendFunction = value;
        }
      }
      public Enum BlendSrcFactor {
        get {
          return this._blendSrcFactor;
        }
        set {
          this._blendSrcFactor = value;
        }
      }
      public Enum BlendDstFactor {
        get {
          return this._blendDstFactor;
        }
        set {
          this._blendDstFactor = value;
        }
      }
      public ARGBColor BlendColor {
        get {
          return this._blendColor;
        }
        set {
          this._blendColor = value;
        }
      }
      public Flags Logic_MinusopFlags {
        get {
          return this._logic_MinusopFlags;
        }
        set {
          this._logic_MinusopFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blendFunction.Read(reader);
        _blendSrcFactor.Read(reader);
        _blendDstFactor.Read(reader);
        _unnamed0.Read(reader);
        _blendColor.Read(reader);
        _logic_MinusopFlags.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _blendFunction.Write(bw);
        _blendSrcFactor.Write(bw);
        _blendDstFactor.Write(bw);
        _unnamed0.Write(bw);
        _blendColor.Write(bw);
        _logic_MinusopFlags.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateAlphaTestStateBlockBlock : IBlock {
      private Flags _flags;
      private Enum _alphaCompareFunction;
      private ShortInteger _alpha_MinustestRef = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderStateAlphaTestStateBlockBlock() {
        this._flags = new Flags(2);
        this._alphaCompareFunction = new Enum(2);
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
      public Enum AlphaCompareFunction {
        get {
          return this._alphaCompareFunction;
        }
        set {
          this._alphaCompareFunction = value;
        }
      }
      public ShortInteger Alpha_MinustestRef {
        get {
          return this._alpha_MinustestRef;
        }
        set {
          this._alpha_MinustestRef = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _alphaCompareFunction.Read(reader);
        _alpha_MinustestRef.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _alphaCompareFunction.Write(bw);
        _alpha_MinustestRef.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateDepthStateBlockBlock : IBlock {
      private Enum _mode;
      private Enum _depthCompareFunction;
      private Flags _flags;
      private Pad _unnamed0;
      private Real _depthBiasSlopeScale = new Real();
      private Real _depthBias = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderStateDepthStateBlockBlock() {
        this._mode = new Enum(2);
        this._depthCompareFunction = new Enum(2);
        this._flags = new Flags(2);
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
return "";
        }
      }
      public Enum Mode {
        get {
          return this._mode;
        }
        set {
          this._mode = value;
        }
      }
      public Enum DepthCompareFunction {
        get {
          return this._depthCompareFunction;
        }
        set {
          this._depthCompareFunction = value;
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
      public Real DepthBiasSlopeScale {
        get {
          return this._depthBiasSlopeScale;
        }
        set {
          this._depthBiasSlopeScale = value;
        }
      }
      public Real DepthBias {
        get {
          return this._depthBias;
        }
        set {
          this._depthBias = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mode.Read(reader);
        _depthCompareFunction.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _depthBiasSlopeScale.Read(reader);
        _depthBias.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _mode.Write(bw);
        _depthCompareFunction.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _depthBiasSlopeScale.Write(bw);
        _depthBias.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateCullStateBlockBlock : IBlock {
      private Enum _mode;
      private Enum _frontFace;
public event System.EventHandler BlockNameChanged;
      public ShaderStateCullStateBlockBlock() {
        this._mode = new Enum(2);
        this._frontFace = new Enum(2);
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
      public Enum Mode {
        get {
          return this._mode;
        }
        set {
          this._mode = value;
        }
      }
      public Enum FrontFace {
        get {
          return this._frontFace;
        }
        set {
          this._frontFace = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mode.Read(reader);
        _frontFace.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _mode.Write(bw);
        _frontFace.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateFillStateBlockBlock : IBlock {
      private Flags _flags;
      private Enum _fillMode;
      private Enum _backFillMode;
      private Pad _unnamed0;
      private Real _lineWidth = new Real();
public event System.EventHandler BlockNameChanged;
      public ShaderStateFillStateBlockBlock() {
        this._flags = new Flags(2);
        this._fillMode = new Enum(2);
        this._backFillMode = new Enum(2);
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
      public Enum FillMode {
        get {
          return this._fillMode;
        }
        set {
          this._fillMode = value;
        }
      }
      public Enum BackFillMode {
        get {
          return this._backFillMode;
        }
        set {
          this._backFillMode = value;
        }
      }
      public Real LineWidth {
        get {
          return this._lineWidth;
        }
        set {
          this._lineWidth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _fillMode.Read(reader);
        _backFillMode.Read(reader);
        _unnamed0.Read(reader);
        _lineWidth.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _fillMode.Write(bw);
        _backFillMode.Write(bw);
        _unnamed0.Write(bw);
        _lineWidth.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateMiscStateBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private RGBColor _fogColor = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public ShaderStateMiscStateBlockBlock() {
        this._flags = new Flags(2);
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
      public RGBColor FogColor {
        get {
          return this._fogColor;
        }
        set {
          this._fogColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _fogColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _fogColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderStateConstantBlockBlock : IBlock {
      private StringId _sourceParameter = new StringId();
      private Pad _unnamed0;
      private Enum _constant;
public event System.EventHandler BlockNameChanged;
      public ShaderStateConstantBlockBlock() {
if (this._constant is System.ComponentModel.INotifyPropertyChanged)
  (this._constant as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._constant = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _constant.ToString();
        }
      }
      public StringId SourceParameter {
        get {
          return this._sourceParameter;
        }
        set {
          this._sourceParameter = value;
        }
      }
      public Enum Constant {
        get {
          return this._constant;
        }
        set {
          this._constant = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sourceParameter.Read(reader);
        _unnamed0.Read(reader);
        _constant.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sourceParameter.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sourceParameter.Write(bw);
        _unnamed0.Write(bw);
        _constant.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sourceParameter.WriteString(writer);
      }
    }
    public class ShaderPassPostprocessDefinitionNewBlockBlock : IBlock {
      private Block _implementations = new Block();
      private Block _textures = new Block();
      private Block _renderStates = new Block();
      private Block _textureStates = new Block();
      private Block _psFragments = new Block();
      private Block _psPermutations = new Block();
      private Block _psCombiners = new Block();
      private Block _externs = new Block();
      private Block _constants = new Block();
      private Block _constantInfo = new Block();
      private Block _oldImplementations = new Block();
      public BlockCollection<ShaderPassPostprocessImplementationNewBlockBlock> _implementationsList = new BlockCollection<ShaderPassPostprocessImplementationNewBlockBlock>();
      public BlockCollection<ShaderPassPostprocessTextureNewBlockBlock> _texturesList = new BlockCollection<ShaderPassPostprocessTextureNewBlockBlock>();
      public BlockCollection<RenderStateBlockBlock> _renderStatesList = new BlockCollection<RenderStateBlockBlock>();
      public BlockCollection<ShaderPassPostprocessTextureStateBlockBlock> _textureStatesList = new BlockCollection<ShaderPassPostprocessTextureStateBlockBlock>();
      public BlockCollection<PixelShaderFragmentBlockBlock> _psFragmentsList = new BlockCollection<PixelShaderFragmentBlockBlock>();
      public BlockCollection<PixelShaderPermutationNewBlockBlock> _psPermutationsList = new BlockCollection<PixelShaderPermutationNewBlockBlock>();
      public BlockCollection<PixelShaderCombinerBlockBlock> _psCombinersList = new BlockCollection<PixelShaderCombinerBlockBlock>();
      public BlockCollection<ShaderPassPostprocessExternNewBlockBlock> _externsList = new BlockCollection<ShaderPassPostprocessExternNewBlockBlock>();
      public BlockCollection<ShaderPassPostprocessConstantNewBlockBlock> _constantsList = new BlockCollection<ShaderPassPostprocessConstantNewBlockBlock>();
      public BlockCollection<ShaderPassPostprocessConstantInfoNewBlockBlock> _constantInfoList = new BlockCollection<ShaderPassPostprocessConstantInfoNewBlockBlock>();
      public BlockCollection<ShaderPassPostprocessImplementationBlockBlock> _oldImplementationsList = new BlockCollection<ShaderPassPostprocessImplementationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessDefinitionNewBlockBlock() {
      }
      public BlockCollection<ShaderPassPostprocessImplementationNewBlockBlock> Implementations {
        get {
          return this._implementationsList;
        }
      }
      public BlockCollection<ShaderPassPostprocessTextureNewBlockBlock> Textures {
        get {
          return this._texturesList;
        }
      }
      public BlockCollection<RenderStateBlockBlock> RenderStates {
        get {
          return this._renderStatesList;
        }
      }
      public BlockCollection<ShaderPassPostprocessTextureStateBlockBlock> TextureStates {
        get {
          return this._textureStatesList;
        }
      }
      public BlockCollection<PixelShaderFragmentBlockBlock> PsFragments {
        get {
          return this._psFragmentsList;
        }
      }
      public BlockCollection<PixelShaderPermutationNewBlockBlock> PsPermutations {
        get {
          return this._psPermutationsList;
        }
      }
      public BlockCollection<PixelShaderCombinerBlockBlock> PsCombiners {
        get {
          return this._psCombinersList;
        }
      }
      public BlockCollection<ShaderPassPostprocessExternNewBlockBlock> Externs {
        get {
          return this._externsList;
        }
      }
      public BlockCollection<ShaderPassPostprocessConstantNewBlockBlock> Constants {
        get {
          return this._constantsList;
        }
      }
      public BlockCollection<ShaderPassPostprocessConstantInfoNewBlockBlock> ConstantInfo {
        get {
          return this._constantInfoList;
        }
      }
      public BlockCollection<ShaderPassPostprocessImplementationBlockBlock> OldImplementations {
        get {
          return this._oldImplementationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Implementations.BlockCount; x++)
{
  IBlock block = Implementations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Textures.BlockCount; x++)
{
  IBlock block = Textures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RenderStates.BlockCount; x++)
{
  IBlock block = RenderStates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TextureStates.BlockCount; x++)
{
  IBlock block = TextureStates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PsFragments.BlockCount; x++)
{
  IBlock block = PsFragments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PsPermutations.BlockCount; x++)
{
  IBlock block = PsPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PsCombiners.BlockCount; x++)
{
  IBlock block = PsCombiners.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Externs.BlockCount; x++)
{
  IBlock block = Externs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Constants.BlockCount; x++)
{
  IBlock block = Constants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ConstantInfo.BlockCount; x++)
{
  IBlock block = ConstantInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OldImplementations.BlockCount; x++)
{
  IBlock block = OldImplementations.GetBlock(x);
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
        _implementations.Read(reader);
        _textures.Read(reader);
        _renderStates.Read(reader);
        _textureStates.Read(reader);
        _psFragments.Read(reader);
        _psPermutations.Read(reader);
        _psCombiners.Read(reader);
        _externs.Read(reader);
        _constants.Read(reader);
        _constantInfo.Read(reader);
        _oldImplementations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations.Add(new ShaderPassPostprocessImplementationNewBlockBlock());
          Implementations[x].Read(reader);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures.Add(new ShaderPassPostprocessTextureNewBlockBlock());
          Textures[x].Read(reader);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates.Add(new RenderStateBlockBlock());
          RenderStates[x].Read(reader);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textureStates.Count); x = (x + 1)) {
          TextureStates.Add(new ShaderPassPostprocessTextureStateBlockBlock());
          TextureStates[x].Read(reader);
        }
        for (x = 0; (x < _textureStates.Count); x = (x + 1)) {
          TextureStates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _psFragments.Count); x = (x + 1)) {
          PsFragments.Add(new PixelShaderFragmentBlockBlock());
          PsFragments[x].Read(reader);
        }
        for (x = 0; (x < _psFragments.Count); x = (x + 1)) {
          PsFragments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _psPermutations.Count); x = (x + 1)) {
          PsPermutations.Add(new PixelShaderPermutationNewBlockBlock());
          PsPermutations[x].Read(reader);
        }
        for (x = 0; (x < _psPermutations.Count); x = (x + 1)) {
          PsPermutations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _psCombiners.Count); x = (x + 1)) {
          PsCombiners.Add(new PixelShaderCombinerBlockBlock());
          PsCombiners[x].Read(reader);
        }
        for (x = 0; (x < _psCombiners.Count); x = (x + 1)) {
          PsCombiners[x].ReadChildData(reader);
        }
        for (x = 0; (x < _externs.Count); x = (x + 1)) {
          Externs.Add(new ShaderPassPostprocessExternNewBlockBlock());
          Externs[x].Read(reader);
        }
        for (x = 0; (x < _externs.Count); x = (x + 1)) {
          Externs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants.Add(new ShaderPassPostprocessConstantNewBlockBlock());
          Constants[x].Read(reader);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _constantInfo.Count); x = (x + 1)) {
          ConstantInfo.Add(new ShaderPassPostprocessConstantInfoNewBlockBlock());
          ConstantInfo[x].Read(reader);
        }
        for (x = 0; (x < _constantInfo.Count); x = (x + 1)) {
          ConstantInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _oldImplementations.Count); x = (x + 1)) {
          OldImplementations.Add(new ShaderPassPostprocessImplementationBlockBlock());
          OldImplementations[x].Read(reader);
        }
        for (x = 0; (x < _oldImplementations.Count); x = (x + 1)) {
          OldImplementations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_implementations.Count = Implementations.Count;
        _implementations.Write(bw);
_textures.Count = Textures.Count;
        _textures.Write(bw);
_renderStates.Count = RenderStates.Count;
        _renderStates.Write(bw);
_textureStates.Count = TextureStates.Count;
        _textureStates.Write(bw);
_psFragments.Count = PsFragments.Count;
        _psFragments.Write(bw);
_psPermutations.Count = PsPermutations.Count;
        _psPermutations.Write(bw);
_psCombiners.Count = PsCombiners.Count;
        _psCombiners.Write(bw);
_externs.Count = Externs.Count;
        _externs.Write(bw);
_constants.Count = Constants.Count;
        _constants.Write(bw);
_constantInfo.Count = ConstantInfo.Count;
        _constantInfo.Write(bw);
_oldImplementations.Count = OldImplementations.Count;
        _oldImplementations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].Write(writer);
        }
        for (x = 0; (x < _implementations.Count); x = (x + 1)) {
          Implementations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].Write(writer);
        }
        for (x = 0; (x < _textures.Count); x = (x + 1)) {
          Textures[x].WriteChildData(writer);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].Write(writer);
        }
        for (x = 0; (x < _renderStates.Count); x = (x + 1)) {
          RenderStates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textureStates.Count); x = (x + 1)) {
          TextureStates[x].Write(writer);
        }
        for (x = 0; (x < _textureStates.Count); x = (x + 1)) {
          TextureStates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _psFragments.Count); x = (x + 1)) {
          PsFragments[x].Write(writer);
        }
        for (x = 0; (x < _psFragments.Count); x = (x + 1)) {
          PsFragments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _psPermutations.Count); x = (x + 1)) {
          PsPermutations[x].Write(writer);
        }
        for (x = 0; (x < _psPermutations.Count); x = (x + 1)) {
          PsPermutations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _psCombiners.Count); x = (x + 1)) {
          PsCombiners[x].Write(writer);
        }
        for (x = 0; (x < _psCombiners.Count); x = (x + 1)) {
          PsCombiners[x].WriteChildData(writer);
        }
        for (x = 0; (x < _externs.Count); x = (x + 1)) {
          Externs[x].Write(writer);
        }
        for (x = 0; (x < _externs.Count); x = (x + 1)) {
          Externs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].Write(writer);
        }
        for (x = 0; (x < _constants.Count); x = (x + 1)) {
          Constants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _constantInfo.Count); x = (x + 1)) {
          ConstantInfo[x].Write(writer);
        }
        for (x = 0; (x < _constantInfo.Count); x = (x + 1)) {
          ConstantInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _oldImplementations.Count); x = (x + 1)) {
          OldImplementations[x].Write(writer);
        }
        for (x = 0; (x < _oldImplementations.Count); x = (x + 1)) {
          OldImplementations[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderPassPostprocessImplementationNewBlockBlock : IBlock {
      private ShortInteger _blockIndexData = new ShortInteger();
      private ShortInteger _blockIndexData2 = new ShortInteger();
      private ShortInteger _blockIndexData3 = new ShortInteger();
      private Skip _unnamed0;
      private ShortInteger _blockIndexData4 = new ShortInteger();
      private ShortInteger _blockIndexData5 = new ShortInteger();
      private ShortInteger _blockIndexData6 = new ShortInteger();
      private TagReference _vertexShader = new TagReference();
      private Skip _unnamed1;
      private Skip _unnamed2;
      private Skip _unnamed3;
      private Skip _unnamed4;
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
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessImplementationNewBlockBlock() {
        this._unnamed0 = new Skip(240);
        this._unnamed1 = new Skip(8);
        this._unnamed2 = new Skip(8);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vertexShader.Value);
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
      public TagReference VertexShader {
        get {
          return this._vertexShader;
        }
        set {
          this._vertexShader = value;
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
      public virtual void Read(BinaryReader reader) {
        _blockIndexData.Read(reader);
        _blockIndexData2.Read(reader);
        _blockIndexData3.Read(reader);
        _unnamed0.Read(reader);
        _blockIndexData4.Read(reader);
        _blockIndexData5.Read(reader);
        _blockIndexData6.Read(reader);
        _vertexShader.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vertexShader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _blockIndexData.Write(bw);
        _blockIndexData2.Write(bw);
        _blockIndexData3.Write(bw);
        _unnamed0.Write(bw);
        _blockIndexData4.Write(bw);
        _blockIndexData5.Write(bw);
        _blockIndexData6.Write(bw);
        _vertexShader.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
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
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vertexShader.WriteString(writer);
      }
    }
    public class ShaderPassPostprocessTextureNewBlockBlock : IBlock {
      private CharInteger _bitmapParameterIndex = new CharInteger();
      private CharInteger _bitmapExternIndex = new CharInteger();
      private CharInteger _textureStageIndex = new CharInteger();
      private CharInteger _flags = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessTextureNewBlockBlock() {
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
      public CharInteger BitmapParameterIndex {
        get {
          return this._bitmapParameterIndex;
        }
        set {
          this._bitmapParameterIndex = value;
        }
      }
      public CharInteger BitmapExternIndex {
        get {
          return this._bitmapExternIndex;
        }
        set {
          this._bitmapExternIndex = value;
        }
      }
      public CharInteger TextureStageIndex {
        get {
          return this._textureStageIndex;
        }
        set {
          this._textureStageIndex = value;
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
        _bitmapParameterIndex.Read(reader);
        _bitmapExternIndex.Read(reader);
        _textureStageIndex.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapParameterIndex.Write(bw);
        _bitmapExternIndex.Write(bw);
        _textureStageIndex.Write(bw);
        _flags.Write(bw);
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
    public class ShaderPassPostprocessTextureStateBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessTextureStateBlockBlock() {
        this._unnamed0 = new Skip(24);
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
    public class PixelShaderFragmentBlockBlock : IBlock {
      private CharInteger _switchParameterIndex = new CharInteger();
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PixelShaderFragmentBlockBlock() {
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
      public CharInteger SwitchParameterIndex {
        get {
          return this._switchParameterIndex;
        }
        set {
          this._switchParameterIndex = value;
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
        _switchParameterIndex.Read(reader);
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _switchParameterIndex.Write(bw);
        _blockIndexData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PixelShaderPermutationNewBlockBlock : IBlock {
      private ShortInteger _enumIndex = new ShortInteger();
      private ShortInteger _flags = new ShortInteger();
      private ShortInteger _blockIndexData = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PixelShaderPermutationNewBlockBlock() {
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
      public ShortInteger EnumIndex {
        get {
          return this._enumIndex;
        }
        set {
          this._enumIndex = value;
        }
      }
      public ShortInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
        _enumIndex.Read(reader);
        _flags.Read(reader);
        _blockIndexData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _enumIndex.Write(bw);
        _flags.Write(bw);
        _blockIndexData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PixelShaderCombinerBlockBlock : IBlock {
      private Pad _unnamed0;
      private ARGBColor _constantColor0 = new ARGBColor();
      private ARGBColor _constantColor1 = new ARGBColor();
      private CharInteger _colorARegisterPtrIndex = new CharInteger();
      private CharInteger _colorBRegisterPtrIndex = new CharInteger();
      private CharInteger _colorCRegisterPtrIndex = new CharInteger();
      private CharInteger _colorDRegisterPtrIndex = new CharInteger();
      private CharInteger _alphaARegisterPtrIndex = new CharInteger();
      private CharInteger _alphaBRegisterPtrIndex = new CharInteger();
      private CharInteger _alphaCRegisterPtrIndex = new CharInteger();
      private CharInteger _alphaDRegisterPtrIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public PixelShaderCombinerBlockBlock() {
        this._unnamed0 = new Pad(16);
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
      public ARGBColor ConstantColor0 {
        get {
          return this._constantColor0;
        }
        set {
          this._constantColor0 = value;
        }
      }
      public ARGBColor ConstantColor1 {
        get {
          return this._constantColor1;
        }
        set {
          this._constantColor1 = value;
        }
      }
      public CharInteger ColorARegisterPtrIndex {
        get {
          return this._colorARegisterPtrIndex;
        }
        set {
          this._colorARegisterPtrIndex = value;
        }
      }
      public CharInteger ColorBRegisterPtrIndex {
        get {
          return this._colorBRegisterPtrIndex;
        }
        set {
          this._colorBRegisterPtrIndex = value;
        }
      }
      public CharInteger ColorCRegisterPtrIndex {
        get {
          return this._colorCRegisterPtrIndex;
        }
        set {
          this._colorCRegisterPtrIndex = value;
        }
      }
      public CharInteger ColorDRegisterPtrIndex {
        get {
          return this._colorDRegisterPtrIndex;
        }
        set {
          this._colorDRegisterPtrIndex = value;
        }
      }
      public CharInteger AlphaARegisterPtrIndex {
        get {
          return this._alphaARegisterPtrIndex;
        }
        set {
          this._alphaARegisterPtrIndex = value;
        }
      }
      public CharInteger AlphaBRegisterPtrIndex {
        get {
          return this._alphaBRegisterPtrIndex;
        }
        set {
          this._alphaBRegisterPtrIndex = value;
        }
      }
      public CharInteger AlphaCRegisterPtrIndex {
        get {
          return this._alphaCRegisterPtrIndex;
        }
        set {
          this._alphaCRegisterPtrIndex = value;
        }
      }
      public CharInteger AlphaDRegisterPtrIndex {
        get {
          return this._alphaDRegisterPtrIndex;
        }
        set {
          this._alphaDRegisterPtrIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _constantColor0.Read(reader);
        _constantColor1.Read(reader);
        _colorARegisterPtrIndex.Read(reader);
        _colorBRegisterPtrIndex.Read(reader);
        _colorCRegisterPtrIndex.Read(reader);
        _colorDRegisterPtrIndex.Read(reader);
        _alphaARegisterPtrIndex.Read(reader);
        _alphaBRegisterPtrIndex.Read(reader);
        _alphaCRegisterPtrIndex.Read(reader);
        _alphaDRegisterPtrIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _constantColor0.Write(bw);
        _constantColor1.Write(bw);
        _colorARegisterPtrIndex.Write(bw);
        _colorBRegisterPtrIndex.Write(bw);
        _colorCRegisterPtrIndex.Write(bw);
        _colorDRegisterPtrIndex.Write(bw);
        _alphaARegisterPtrIndex.Write(bw);
        _alphaBRegisterPtrIndex.Write(bw);
        _alphaCRegisterPtrIndex.Write(bw);
        _alphaDRegisterPtrIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPassPostprocessExternNewBlockBlock : IBlock {
      private Skip _unnamed0;
      private CharInteger _externIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessExternNewBlockBlock() {
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
      public CharInteger ExternIndex {
        get {
          return this._externIndex;
        }
        set {
          this._externIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _externIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _externIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShaderPassPostprocessConstantNewBlockBlock : IBlock {
      private StringId _parameterName = new StringId();
      private CharInteger _componentMask = new CharInteger();
      private CharInteger _scaleByTextureStage = new CharInteger();
      private CharInteger _functionIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessConstantNewBlockBlock() {
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
      public StringId ParameterName {
        get {
          return this._parameterName;
        }
        set {
          this._parameterName = value;
        }
      }
      public CharInteger ComponentMask {
        get {
          return this._componentMask;
        }
        set {
          this._componentMask = value;
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
      public CharInteger FunctionIndex {
        get {
          return this._functionIndex;
        }
        set {
          this._functionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterName.Read(reader);
        _componentMask.Read(reader);
        _scaleByTextureStage.Read(reader);
        _functionIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _parameterName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterName.Write(bw);
        _componentMask.Write(bw);
        _scaleByTextureStage.Write(bw);
        _functionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _parameterName.WriteString(writer);
      }
    }
    public class ShaderPassPostprocessConstantInfoNewBlockBlock : IBlock {
      private StringId _parameterName = new StringId();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessConstantInfoNewBlockBlock() {
        this._unnamed0 = new Pad(3);
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
      public StringId ParameterName {
        get {
          return this._parameterName;
        }
        set {
          this._parameterName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterName.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _parameterName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterName.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _parameterName.WriteString(writer);
      }
    }
    public class ShaderPassPostprocessImplementationBlockBlock : IBlock {
      private Block _renderStates = new Block();
      private Block _textureStageStates = new Block();
      private Block _renderStateParameters = new Block();
      private Block _textureStageParameters = new Block();
      private Block _textures = new Block();
      private Block _vnConstants = new Block();
      private Block _cnConstants = new Block();
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
      private TagReference _vertexShader = new TagReference();
      private Skip _unnamed0;
      private Skip _unnamed1;
      private Skip _unnamed2;
      private Skip _unnamed3;
      private Block _valueExterns = new Block();
      private Block _colorExterns = new Block();
      private Block _switchExterns = new Block();
      private ShortInteger _bitmapParameterCount = new ShortInteger();
      private Pad _unnamed4;
      private Skip _unnamed5;
      private Block _pixelShaderFragments = new Block();
      private Block _pixelShaderPermutations = new Block();
      private Block _pixelShaderCombiners = new Block();
      private Block _pixelShaderConstants = new Block();
      private Skip _unnamed6;
      private Skip _unnamed7;
      public BlockCollection<RenderStateBlockBlock> _renderStatesList = new BlockCollection<RenderStateBlockBlock>();
      public BlockCollection<TextureStageStateBlockBlock> _textureStageStatesList = new BlockCollection<TextureStageStateBlockBlock>();
      public BlockCollection<RenderStateParameterBlockBlock> _renderStateParametersList = new BlockCollection<RenderStateParameterBlockBlock>();
      public BlockCollection<TextureStageStateParameterBlockBlock> _textureStageParametersList = new BlockCollection<TextureStageStateParameterBlockBlock>();
      public BlockCollection<TextureBlockBlock> _texturesList = new BlockCollection<TextureBlockBlock>();
      public BlockCollection<VertexShaderConstantBlockBlock> _vnConstantsList = new BlockCollection<VertexShaderConstantBlockBlock>();
      public BlockCollection<VertexShaderConstantBlockBlock> _cnConstantsList = new BlockCollection<VertexShaderConstantBlockBlock>();
      public BlockCollection<ExternReferenceBlockBlock> _valueExternsList = new BlockCollection<ExternReferenceBlockBlock>();
      public BlockCollection<ExternReferenceBlockBlock> _colorExternsList = new BlockCollection<ExternReferenceBlockBlock>();
      public BlockCollection<ExternReferenceBlockBlock> _switchExternsList = new BlockCollection<ExternReferenceBlockBlock>();
      public BlockCollection<PixelShaderFragmentBlockBlock> _pixelShaderFragmentsList = new BlockCollection<PixelShaderFragmentBlockBlock>();
      public BlockCollection<PixelShaderPermutationBlockBlock> _pixelShaderPermutationsList = new BlockCollection<PixelShaderPermutationBlockBlock>();
      public BlockCollection<PixelShaderCombinerBlockBlock> _pixelShaderCombinersList = new BlockCollection<PixelShaderCombinerBlockBlock>();
      public BlockCollection<PixelShaderConstantBlockBlock> _pixelShaderConstantsList = new BlockCollection<PixelShaderConstantBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderPassPostprocessImplementationBlockBlock() {
        this._unnamed0 = new Skip(8);
        this._unnamed1 = new Skip(8);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Skip(240);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
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
      public BlockCollection<ExternReferenceBlockBlock> ValueExterns {
        get {
          return this._valueExternsList;
        }
      }
      public BlockCollection<ExternReferenceBlockBlock> ColorExterns {
        get {
          return this._colorExternsList;
        }
      }
      public BlockCollection<ExternReferenceBlockBlock> SwitchExterns {
        get {
          return this._switchExternsList;
        }
      }
      public BlockCollection<PixelShaderFragmentBlockBlock> PixelShaderFragments {
        get {
          return this._pixelShaderFragmentsList;
        }
      }
      public BlockCollection<PixelShaderPermutationBlockBlock> PixelShaderPermutations {
        get {
          return this._pixelShaderPermutationsList;
        }
      }
      public BlockCollection<PixelShaderCombinerBlockBlock> PixelShaderCombiners {
        get {
          return this._pixelShaderCombinersList;
        }
      }
      public BlockCollection<PixelShaderConstantBlockBlock> PixelShaderConstants {
        get {
          return this._pixelShaderConstantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vertexShader.Value);
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
for (int x=0; x<ValueExterns.BlockCount; x++)
{
  IBlock block = ValueExterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ColorExterns.BlockCount; x++)
{
  IBlock block = ColorExterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SwitchExterns.BlockCount; x++)
{
  IBlock block = SwitchExterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PixelShaderFragments.BlockCount; x++)
{
  IBlock block = PixelShaderFragments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PixelShaderPermutations.BlockCount; x++)
{
  IBlock block = PixelShaderPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PixelShaderCombiners.BlockCount; x++)
{
  IBlock block = PixelShaderCombiners.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PixelShaderConstants.BlockCount; x++)
{
  IBlock block = PixelShaderConstants.GetBlock(x);
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
      public TagReference VertexShader {
        get {
          return this._vertexShader;
        }
        set {
          this._vertexShader = value;
        }
      }
      public ShortInteger BitmapParameterCount {
        get {
          return this._bitmapParameterCount;
        }
        set {
          this._bitmapParameterCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _renderStates.Read(reader);
        _textureStageStates.Read(reader);
        _renderStateParameters.Read(reader);
        _textureStageParameters.Read(reader);
        _textures.Read(reader);
        _vnConstants.Read(reader);
        _cnConstants.Read(reader);
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
        _vertexShader.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _valueExterns.Read(reader);
        _colorExterns.Read(reader);
        _switchExterns.Read(reader);
        _bitmapParameterCount.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _pixelShaderFragments.Read(reader);
        _pixelShaderPermutations.Read(reader);
        _pixelShaderCombiners.Read(reader);
        _pixelShaderConstants.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
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
        _vertexShader.ReadString(reader);
        for (x = 0; (x < _valueExterns.Count); x = (x + 1)) {
          ValueExterns.Add(new ExternReferenceBlockBlock());
          ValueExterns[x].Read(reader);
        }
        for (x = 0; (x < _valueExterns.Count); x = (x + 1)) {
          ValueExterns[x].ReadChildData(reader);
        }
        for (x = 0; (x < _colorExterns.Count); x = (x + 1)) {
          ColorExterns.Add(new ExternReferenceBlockBlock());
          ColorExterns[x].Read(reader);
        }
        for (x = 0; (x < _colorExterns.Count); x = (x + 1)) {
          ColorExterns[x].ReadChildData(reader);
        }
        for (x = 0; (x < _switchExterns.Count); x = (x + 1)) {
          SwitchExterns.Add(new ExternReferenceBlockBlock());
          SwitchExterns[x].Read(reader);
        }
        for (x = 0; (x < _switchExterns.Count); x = (x + 1)) {
          SwitchExterns[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pixelShaderFragments.Count); x = (x + 1)) {
          PixelShaderFragments.Add(new PixelShaderFragmentBlockBlock());
          PixelShaderFragments[x].Read(reader);
        }
        for (x = 0; (x < _pixelShaderFragments.Count); x = (x + 1)) {
          PixelShaderFragments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pixelShaderPermutations.Count); x = (x + 1)) {
          PixelShaderPermutations.Add(new PixelShaderPermutationBlockBlock());
          PixelShaderPermutations[x].Read(reader);
        }
        for (x = 0; (x < _pixelShaderPermutations.Count); x = (x + 1)) {
          PixelShaderPermutations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pixelShaderCombiners.Count); x = (x + 1)) {
          PixelShaderCombiners.Add(new PixelShaderCombinerBlockBlock());
          PixelShaderCombiners[x].Read(reader);
        }
        for (x = 0; (x < _pixelShaderCombiners.Count); x = (x + 1)) {
          PixelShaderCombiners[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pixelShaderConstants.Count); x = (x + 1)) {
          PixelShaderConstants.Add(new PixelShaderConstantBlockBlock());
          PixelShaderConstants[x].Read(reader);
        }
        for (x = 0; (x < _pixelShaderConstants.Count); x = (x + 1)) {
          PixelShaderConstants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
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
        _vertexShader.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
_valueExterns.Count = ValueExterns.Count;
        _valueExterns.Write(bw);
_colorExterns.Count = ColorExterns.Count;
        _colorExterns.Write(bw);
_switchExterns.Count = SwitchExterns.Count;
        _switchExterns.Write(bw);
        _bitmapParameterCount.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
_pixelShaderFragments.Count = PixelShaderFragments.Count;
        _pixelShaderFragments.Write(bw);
_pixelShaderPermutations.Count = PixelShaderPermutations.Count;
        _pixelShaderPermutations.Write(bw);
_pixelShaderCombiners.Count = PixelShaderCombiners.Count;
        _pixelShaderCombiners.Write(bw);
_pixelShaderConstants.Count = PixelShaderConstants.Count;
        _pixelShaderConstants.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
        _vertexShader.WriteString(writer);
        for (x = 0; (x < _valueExterns.Count); x = (x + 1)) {
          ValueExterns[x].Write(writer);
        }
        for (x = 0; (x < _valueExterns.Count); x = (x + 1)) {
          ValueExterns[x].WriteChildData(writer);
        }
        for (x = 0; (x < _colorExterns.Count); x = (x + 1)) {
          ColorExterns[x].Write(writer);
        }
        for (x = 0; (x < _colorExterns.Count); x = (x + 1)) {
          ColorExterns[x].WriteChildData(writer);
        }
        for (x = 0; (x < _switchExterns.Count); x = (x + 1)) {
          SwitchExterns[x].Write(writer);
        }
        for (x = 0; (x < _switchExterns.Count); x = (x + 1)) {
          SwitchExterns[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pixelShaderFragments.Count); x = (x + 1)) {
          PixelShaderFragments[x].Write(writer);
        }
        for (x = 0; (x < _pixelShaderFragments.Count); x = (x + 1)) {
          PixelShaderFragments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pixelShaderPermutations.Count); x = (x + 1)) {
          PixelShaderPermutations[x].Write(writer);
        }
        for (x = 0; (x < _pixelShaderPermutations.Count); x = (x + 1)) {
          PixelShaderPermutations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pixelShaderCombiners.Count); x = (x + 1)) {
          PixelShaderCombiners[x].Write(writer);
        }
        for (x = 0; (x < _pixelShaderCombiners.Count); x = (x + 1)) {
          PixelShaderCombiners[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pixelShaderConstants.Count); x = (x + 1)) {
          PixelShaderConstants[x].Write(writer);
        }
        for (x = 0; (x < _pixelShaderConstants.Count); x = (x + 1)) {
          PixelShaderConstants[x].WriteChildData(writer);
        }
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
    public class ExternReferenceBlockBlock : IBlock {
      private CharInteger _parameterIndex = new CharInteger();
      private CharInteger _externIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ExternReferenceBlockBlock() {
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
      public CharInteger ExternIndex {
        get {
          return this._externIndex;
        }
        set {
          this._externIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterIndex.Read(reader);
        _externIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterIndex.Write(bw);
        _externIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PixelShaderPermutationBlockBlock : IBlock {
      private ShortInteger _enumIndex = new ShortInteger();
      private Flags _flags;
      private ShortInteger _blockIndexData = new ShortInteger();
      private ShortInteger _blockIndexData2 = new ShortInteger();
      private Skip _unnamed0;
      private Skip _unnamed1;
public event System.EventHandler BlockNameChanged;
      public PixelShaderPermutationBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
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
      public ShortInteger EnumIndex {
        get {
          return this._enumIndex;
        }
        set {
          this._enumIndex = value;
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
      public virtual void Read(BinaryReader reader) {
        _enumIndex.Read(reader);
        _flags.Read(reader);
        _blockIndexData.Read(reader);
        _blockIndexData2.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _enumIndex.Write(bw);
        _flags.Write(bw);
        _blockIndexData.Write(bw);
        _blockIndexData2.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PixelShaderConstantBlockBlock : IBlock {
      private Enum _parameterType;
      private CharInteger _combinerIndex = new CharInteger();
      private CharInteger _registerIndex = new CharInteger();
      private Enum _componentMask;
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public PixelShaderConstantBlockBlock() {
        this._parameterType = new Enum(1);
        this._componentMask = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._unnamed1 = new Pad(1);
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
      public Enum ParameterType {
        get {
          return this._parameterType;
        }
        set {
          this._parameterType = value;
        }
      }
      public CharInteger CombinerIndex {
        get {
          return this._combinerIndex;
        }
        set {
          this._combinerIndex = value;
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
      public Enum ComponentMask {
        get {
          return this._componentMask;
        }
        set {
          this._componentMask = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parameterType.Read(reader);
        _combinerIndex.Read(reader);
        _registerIndex.Read(reader);
        _componentMask.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterType.Write(bw);
        _combinerIndex.Write(bw);
        _registerIndex.Write(bw);
        _componentMask.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
