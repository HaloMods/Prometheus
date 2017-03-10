// -----------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_generic' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -----------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_generic : shader {
    private ShaderTransparentGenericBlock shaderTransparentGenericValues = new ShaderTransparentGenericBlock();
    public virtual ShaderTransparentGenericBlock ShaderTransparentGenericValues {
      get {
        return shaderTransparentGenericValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentGenericValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_generic";
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
base.Read(reader);
shaderTransparentGenericValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentGenericValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentGenericValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentGenericValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentGenericBlock : IBlock {
      private CharInteger _numericCounterLimit = new CharInteger();
      private Flags _flags;
      private Enum _firstMapType = new Enum();
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Enum _framebufferFadeSource = new Enum();
      private Pad _unnamed;
      private Real _lensFlareSpacing = new Real();
      private TagReference _lensFlare = new TagReference();
      private Block _extraLayers = new Block();
      private Block _maps = new Block();
      private Block _stages = new Block();
      public BlockCollection<ShaderTransparentLayerBlock> _extraLayersList = new BlockCollection<ShaderTransparentLayerBlock>();
      public BlockCollection<ShaderTransparentGenericMapBlock> _mapsList = new BlockCollection<ShaderTransparentGenericMapBlock>();
      public BlockCollection<ShaderTransparentGenericStageBlock> _stagesList = new BlockCollection<ShaderTransparentGenericStageBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentGenericBlock() {
        this._flags = new Flags(1);
        this._unnamed = new Pad(2);
      }
      public BlockCollection<ShaderTransparentLayerBlock> ExtraLayers {
        get {
          return this._extraLayersList;
        }
      }
      public BlockCollection<ShaderTransparentGenericMapBlock> Maps {
        get {
          return this._mapsList;
        }
      }
      public BlockCollection<ShaderTransparentGenericStageBlock> Stages {
        get {
          return this._stagesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lensFlare.Value);
for (int x=0; x<ExtraLayers.BlockCount; x++)
{
  IBlock block = ExtraLayers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Maps.BlockCount; x++)
{
  IBlock block = Maps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Stages.BlockCount; x++)
{
  IBlock block = Stages.GetBlock(x);
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
      public CharInteger NumericCounterLimit {
        get {
          return this._numericCounterLimit;
        }
        set {
          this._numericCounterLimit = value;
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
      public Enum FirstMapType {
        get {
          return this._firstMapType;
        }
        set {
          this._firstMapType = value;
        }
      }
      public Enum FramebufferBlendFunction {
        get {
          return this._framebufferBlendFunction;
        }
        set {
          this._framebufferBlendFunction = value;
        }
      }
      public Enum FramebufferFadeMode {
        get {
          return this._framebufferFadeMode;
        }
        set {
          this._framebufferFadeMode = value;
        }
      }
      public Enum FramebufferFadeSource {
        get {
          return this._framebufferFadeSource;
        }
        set {
          this._framebufferFadeSource = value;
        }
      }
      public Real LensFlareSpacing {
        get {
          return this._lensFlareSpacing;
        }
        set {
          this._lensFlareSpacing = value;
        }
      }
      public TagReference LensFlare {
        get {
          return this._lensFlare;
        }
        set {
          this._lensFlare = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _numericCounterLimit.Read(reader);
        _flags.Read(reader);
        _firstMapType.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _framebufferFadeSource.Read(reader);
        _unnamed.Read(reader);
        _lensFlareSpacing.Read(reader);
        _lensFlare.Read(reader);
        _extraLayers.Read(reader);
        _maps.Read(reader);
        _stages.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _lensFlare.ReadString(reader);
        for (x = 0; (x < _extraLayers.Count); x = (x + 1)) {
          ExtraLayers.Add(new ShaderTransparentLayerBlock());
          ExtraLayers[x].Read(reader);
        }
        for (x = 0; (x < _extraLayers.Count); x = (x + 1)) {
          ExtraLayers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _maps.Count); x = (x + 1)) {
          Maps.Add(new ShaderTransparentGenericMapBlock());
          Maps[x].Read(reader);
        }
        for (x = 0; (x < _maps.Count); x = (x + 1)) {
          Maps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stages.Count); x = (x + 1)) {
          Stages.Add(new ShaderTransparentGenericStageBlock());
          Stages[x].Read(reader);
        }
        for (x = 0; (x < _stages.Count); x = (x + 1)) {
          Stages[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _numericCounterLimit.Write(bw);
        _flags.Write(bw);
        _firstMapType.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _framebufferFadeSource.Write(bw);
        _unnamed.Write(bw);
        _lensFlareSpacing.Write(bw);
        _lensFlare.Write(bw);
_extraLayers.Count = ExtraLayers.Count;
        _extraLayers.Write(bw);
_maps.Count = Maps.Count;
        _maps.Write(bw);
_stages.Count = Stages.Count;
        _stages.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _lensFlare.WriteString(writer);
        for (x = 0; (x < _extraLayers.Count); x = (x + 1)) {
          ExtraLayers[x].Write(writer);
        }
        for (x = 0; (x < _extraLayers.Count); x = (x + 1)) {
          ExtraLayers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _maps.Count); x = (x + 1)) {
          Maps[x].Write(writer);
        }
        for (x = 0; (x < _maps.Count); x = (x + 1)) {
          Maps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stages.Count); x = (x + 1)) {
          Stages[x].Write(writer);
        }
        for (x = 0; (x < _stages.Count); x = (x + 1)) {
          Stages[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTransparentLayerBlock : IBlock {
      private TagReference _shader = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentLayerBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shader.WriteString(writer);
      }
    }
    public class ShaderTransparentGenericMapBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Real _map = new Real();
      private Real _map2 = new Real();
      private Real _map3 = new Real();
      private Real _map4 = new Real();
      private Real _mapRotation = new Real();
      private RealFraction _mipmapBias = new RealFraction();
      private TagReference _map5 = new TagReference();
      private Enum _unnamed2 = new Enum();
      private Enum _unnamed3 = new Enum();
      private Real _unnamed4 = new Real();
      private Real _unnamed5 = new Real();
      private Real _unnamed6 = new Real();
      private Enum _unnamed7 = new Enum();
      private Enum _unnamed8 = new Enum();
      private Real _unnamed9 = new Real();
      private Real _unnamed10 = new Real();
      private Real _unnamed11 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentGenericMapBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_map5.Value);
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
      public Real Map {
        get {
          return this._map;
        }
        set {
          this._map = value;
        }
      }
      public Real Map2 {
        get {
          return this._map2;
        }
        set {
          this._map2 = value;
        }
      }
      public Real Map3 {
        get {
          return this._map3;
        }
        set {
          this._map3 = value;
        }
      }
      public Real Map4 {
        get {
          return this._map4;
        }
        set {
          this._map4 = value;
        }
      }
      public Real MapRotation {
        get {
          return this._mapRotation;
        }
        set {
          this._mapRotation = value;
        }
      }
      public RealFraction MipmapBias {
        get {
          return this._mipmapBias;
        }
        set {
          this._mipmapBias = value;
        }
      }
      public TagReference Map5 {
        get {
          return this._map5;
        }
        set {
          this._map5 = value;
        }
      }
      public Enum unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public Enum unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public Real unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public Real unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public Real unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public Enum unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public Enum unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public Real unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public Real unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public Real unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Enum Rotatio {
        get {
          return this._rotatio;
        }
        set {
          this._rotatio = value;
        }
      }
      public Enum Rotatio2 {
        get {
          return this._rotatio2;
        }
        set {
          this._rotatio2 = value;
        }
      }
      public Real Rotatio3 {
        get {
          return this._rotatio3;
        }
        set {
          this._rotatio3 = value;
        }
      }
      public Real Rotatio4 {
        get {
          return this._rotatio4;
        }
        set {
          this._rotatio4 = value;
        }
      }
      public Real Rotatio5 {
        get {
          return this._rotatio5;
        }
        set {
          this._rotatio5 = value;
        }
      }
      public RealPoint2D Rotatio6 {
        get {
          return this._rotatio6;
        }
        set {
          this._rotatio6 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _map.Read(reader);
        _map2.Read(reader);
        _map3.Read(reader);
        _map4.Read(reader);
        _mapRotation.Read(reader);
        _mipmapBias.Read(reader);
        _map5.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _map5.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _map.Write(bw);
        _map2.Write(bw);
        _map3.Write(bw);
        _map4.Write(bw);
        _mapRotation.Write(bw);
        _mipmapBias.Write(bw);
        _map5.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _map5.WriteString(writer);
      }
    }
    public class ShaderTransparentGenericStageBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Enum _color0Source = new Enum();
      private Enum _color0AnimationFunction = new Enum();
      private Real _color0AnimationPeriod = new Real();
      private RealARGBColor _color0AnimationLowerBound = new RealARGBColor();
      private RealARGBColor _color0AnimationUpperBound = new RealARGBColor();
      private RealARGBColor _color1 = new RealARGBColor();
      private Enum _inputA = new Enum();
      private Enum _inputAMapping = new Enum();
      private Enum _inputB = new Enum();
      private Enum _inputBMapping = new Enum();
      private Enum _inputC = new Enum();
      private Enum _inputCMapping = new Enum();
      private Enum _inputD = new Enum();
      private Enum _inputDMapping = new Enum();
      private Enum _outputAB = new Enum();
      private Enum _outputABFunction = new Enum();
      private Enum _outputCD = new Enum();
      private Enum _outputCDFunction = new Enum();
      private Enum _outputABCDMuxsum = new Enum();
      private Enum _outputMapping = new Enum();
      private Enum _inputA2 = new Enum();
      private Enum _inputAMapping2 = new Enum();
      private Enum _inputB2 = new Enum();
      private Enum _inputBMapping2 = new Enum();
      private Enum _inputC2 = new Enum();
      private Enum _inputCMapping2 = new Enum();
      private Enum _inputD2 = new Enum();
      private Enum _inputDMapping2 = new Enum();
      private Enum _outputAB2 = new Enum();
      private Enum _outputCD2 = new Enum();
      private Enum _outputABCDMuxsum2 = new Enum();
      private Enum _outputMapping2 = new Enum();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentGenericStageBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
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
      public Enum Color0Source {
        get {
          return this._color0Source;
        }
        set {
          this._color0Source = value;
        }
      }
      public Enum Color0AnimationFunction {
        get {
          return this._color0AnimationFunction;
        }
        set {
          this._color0AnimationFunction = value;
        }
      }
      public Real Color0AnimationPeriod {
        get {
          return this._color0AnimationPeriod;
        }
        set {
          this._color0AnimationPeriod = value;
        }
      }
      public RealARGBColor Color0AnimationLowerBound {
        get {
          return this._color0AnimationLowerBound;
        }
        set {
          this._color0AnimationLowerBound = value;
        }
      }
      public RealARGBColor Color0AnimationUpperBound {
        get {
          return this._color0AnimationUpperBound;
        }
        set {
          this._color0AnimationUpperBound = value;
        }
      }
      public RealARGBColor Color1 {
        get {
          return this._color1;
        }
        set {
          this._color1 = value;
        }
      }
      public Enum InputA {
        get {
          return this._inputA;
        }
        set {
          this._inputA = value;
        }
      }
      public Enum InputAMapping {
        get {
          return this._inputAMapping;
        }
        set {
          this._inputAMapping = value;
        }
      }
      public Enum InputB {
        get {
          return this._inputB;
        }
        set {
          this._inputB = value;
        }
      }
      public Enum InputBMapping {
        get {
          return this._inputBMapping;
        }
        set {
          this._inputBMapping = value;
        }
      }
      public Enum InputC {
        get {
          return this._inputC;
        }
        set {
          this._inputC = value;
        }
      }
      public Enum InputCMapping {
        get {
          return this._inputCMapping;
        }
        set {
          this._inputCMapping = value;
        }
      }
      public Enum InputD {
        get {
          return this._inputD;
        }
        set {
          this._inputD = value;
        }
      }
      public Enum InputDMapping {
        get {
          return this._inputDMapping;
        }
        set {
          this._inputDMapping = value;
        }
      }
      public Enum OutputAB {
        get {
          return this._outputAB;
        }
        set {
          this._outputAB = value;
        }
      }
      public Enum OutputABFunction {
        get {
          return this._outputABFunction;
        }
        set {
          this._outputABFunction = value;
        }
      }
      public Enum OutputCD {
        get {
          return this._outputCD;
        }
        set {
          this._outputCD = value;
        }
      }
      public Enum OutputCDFunction {
        get {
          return this._outputCDFunction;
        }
        set {
          this._outputCDFunction = value;
        }
      }
      public Enum OutputABCDMuxsum {
        get {
          return this._outputABCDMuxsum;
        }
        set {
          this._outputABCDMuxsum = value;
        }
      }
      public Enum OutputMapping {
        get {
          return this._outputMapping;
        }
        set {
          this._outputMapping = value;
        }
      }
      public Enum InputA2 {
        get {
          return this._inputA2;
        }
        set {
          this._inputA2 = value;
        }
      }
      public Enum InputAMapping2 {
        get {
          return this._inputAMapping2;
        }
        set {
          this._inputAMapping2 = value;
        }
      }
      public Enum InputB2 {
        get {
          return this._inputB2;
        }
        set {
          this._inputB2 = value;
        }
      }
      public Enum InputBMapping2 {
        get {
          return this._inputBMapping2;
        }
        set {
          this._inputBMapping2 = value;
        }
      }
      public Enum InputC2 {
        get {
          return this._inputC2;
        }
        set {
          this._inputC2 = value;
        }
      }
      public Enum InputCMapping2 {
        get {
          return this._inputCMapping2;
        }
        set {
          this._inputCMapping2 = value;
        }
      }
      public Enum InputD2 {
        get {
          return this._inputD2;
        }
        set {
          this._inputD2 = value;
        }
      }
      public Enum InputDMapping2 {
        get {
          return this._inputDMapping2;
        }
        set {
          this._inputDMapping2 = value;
        }
      }
      public Enum OutputAB2 {
        get {
          return this._outputAB2;
        }
        set {
          this._outputAB2 = value;
        }
      }
      public Enum OutputCD2 {
        get {
          return this._outputCD2;
        }
        set {
          this._outputCD2 = value;
        }
      }
      public Enum OutputABCDMuxsum2 {
        get {
          return this._outputABCDMuxsum2;
        }
        set {
          this._outputABCDMuxsum2 = value;
        }
      }
      public Enum OutputMapping2 {
        get {
          return this._outputMapping2;
        }
        set {
          this._outputMapping2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _color0Source.Read(reader);
        _color0AnimationFunction.Read(reader);
        _color0AnimationPeriod.Read(reader);
        _color0AnimationLowerBound.Read(reader);
        _color0AnimationUpperBound.Read(reader);
        _color1.Read(reader);
        _inputA.Read(reader);
        _inputAMapping.Read(reader);
        _inputB.Read(reader);
        _inputBMapping.Read(reader);
        _inputC.Read(reader);
        _inputCMapping.Read(reader);
        _inputD.Read(reader);
        _inputDMapping.Read(reader);
        _outputAB.Read(reader);
        _outputABFunction.Read(reader);
        _outputCD.Read(reader);
        _outputCDFunction.Read(reader);
        _outputABCDMuxsum.Read(reader);
        _outputMapping.Read(reader);
        _inputA2.Read(reader);
        _inputAMapping2.Read(reader);
        _inputB2.Read(reader);
        _inputBMapping2.Read(reader);
        _inputC2.Read(reader);
        _inputCMapping2.Read(reader);
        _inputD2.Read(reader);
        _inputDMapping2.Read(reader);
        _outputAB2.Read(reader);
        _outputCD2.Read(reader);
        _outputABCDMuxsum2.Read(reader);
        _outputMapping2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _color0Source.Write(bw);
        _color0AnimationFunction.Write(bw);
        _color0AnimationPeriod.Write(bw);
        _color0AnimationLowerBound.Write(bw);
        _color0AnimationUpperBound.Write(bw);
        _color1.Write(bw);
        _inputA.Write(bw);
        _inputAMapping.Write(bw);
        _inputB.Write(bw);
        _inputBMapping.Write(bw);
        _inputC.Write(bw);
        _inputCMapping.Write(bw);
        _inputD.Write(bw);
        _inputDMapping.Write(bw);
        _outputAB.Write(bw);
        _outputABFunction.Write(bw);
        _outputCD.Write(bw);
        _outputCDFunction.Write(bw);
        _outputABCDMuxsum.Write(bw);
        _outputMapping.Write(bw);
        _inputA2.Write(bw);
        _inputAMapping2.Write(bw);
        _inputB2.Write(bw);
        _inputBMapping2.Write(bw);
        _inputC2.Write(bw);
        _inputCMapping2.Write(bw);
        _inputD2.Write(bw);
        _inputDMapping2.Write(bw);
        _outputAB2.Write(bw);
        _outputCD2.Write(bw);
        _outputABCDMuxsum2.Write(bw);
        _outputMapping2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
