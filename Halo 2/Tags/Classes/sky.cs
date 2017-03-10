// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sky'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sky : Interfaces.Pool.Tag {
    private SkyBlockBlock skyValues = new SkyBlockBlock();
    public virtual SkyBlockBlock SkyValues {
      get {
        return skyValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SkyValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sky";
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
skyValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
skyValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
skyValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
skyValues.WriteChildData(writer);
    }
    #endregion
    public class SkyBlockBlock : IBlock {
      private TagReference _renderModel = new TagReference();
      private TagReference _animationGraph = new TagReference();
      private Flags _flags;
      private Real _renderModelScale = new Real();
      private Real _movementScale = new Real();
      private Block _cubeMap = new Block();
      private RealRGBColor _indoorAmbientColor = new RealRGBColor();
      private Pad _unnamed0;
      private RealRGBColor _outdoorAmbientColor = new RealRGBColor();
      private Pad _unnamed1;
      private Real _fogSpreadDistance = new Real();
      private Block _atmosphericFog = new Block();
      private Block _secondaryFog = new Block();
      private Block _skyFog = new Block();
      private Block _patchyFog = new Block();
      private RealFraction _amount = new RealFraction();
      private RealFraction _threshold = new RealFraction();
      private RealFraction _brightness = new RealFraction();
      private Real _gammaPower = new Real();
      private Block _lights = new Block();
      private Angle _globalSkyRotation = new Angle();
      private Block _shaderFunctions = new Block();
      private Block _animations = new Block();
      private Pad _unnamed2;
      private RealRGBColor _clearColor = new RealRGBColor();
      public BlockCollection<SkyCubemapBlockBlock> _cubeMapList = new BlockCollection<SkyCubemapBlockBlock>();
      public BlockCollection<SkyAtmosphericFogBlockBlock> _atmosphericFogList = new BlockCollection<SkyAtmosphericFogBlockBlock>();
      public BlockCollection<SkyAtmosphericFogBlockBlock> _secondaryFogList = new BlockCollection<SkyAtmosphericFogBlockBlock>();
      public BlockCollection<SkyFogBlockBlock> _skyFogList = new BlockCollection<SkyFogBlockBlock>();
      public BlockCollection<SkyPatchyFogBlockBlock> _patchyFogList = new BlockCollection<SkyPatchyFogBlockBlock>();
      public BlockCollection<SkyLightBlockBlock> _lightsList = new BlockCollection<SkyLightBlockBlock>();
      public BlockCollection<SkyShaderFunctionBlockBlock> _shaderFunctionsList = new BlockCollection<SkyShaderFunctionBlockBlock>();
      public BlockCollection<SkyAnimationBlockBlock> _animationsList = new BlockCollection<SkyAnimationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SkyBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(12);
      }
      public BlockCollection<SkyCubemapBlockBlock> CubeMap {
        get {
          return this._cubeMapList;
        }
      }
      public BlockCollection<SkyAtmosphericFogBlockBlock> AtmosphericFog {
        get {
          return this._atmosphericFogList;
        }
      }
      public BlockCollection<SkyAtmosphericFogBlockBlock> SecondaryFog {
        get {
          return this._secondaryFogList;
        }
      }
      public BlockCollection<SkyFogBlockBlock> SkyFog {
        get {
          return this._skyFogList;
        }
      }
      public BlockCollection<SkyPatchyFogBlockBlock> PatchyFog {
        get {
          return this._patchyFogList;
        }
      }
      public BlockCollection<SkyLightBlockBlock> Lights {
        get {
          return this._lightsList;
        }
      }
      public BlockCollection<SkyShaderFunctionBlockBlock> ShaderFunctions {
        get {
          return this._shaderFunctionsList;
        }
      }
      public BlockCollection<SkyAnimationBlockBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_renderModel.Value);
references.Add(_animationGraph.Value);
for (int x=0; x<CubeMap.BlockCount; x++)
{
  IBlock block = CubeMap.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AtmosphericFog.BlockCount; x++)
{
  IBlock block = AtmosphericFog.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SecondaryFog.BlockCount; x++)
{
  IBlock block = SecondaryFog.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SkyFog.BlockCount; x++)
{
  IBlock block = SkyFog.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PatchyFog.BlockCount; x++)
{
  IBlock block = PatchyFog.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lights.BlockCount; x++)
{
  IBlock block = Lights.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ShaderFunctions.BlockCount; x++)
{
  IBlock block = ShaderFunctions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
      public TagReference RenderModel {
        get {
          return this._renderModel;
        }
        set {
          this._renderModel = value;
        }
      }
      public TagReference AnimationGraph {
        get {
          return this._animationGraph;
        }
        set {
          this._animationGraph = value;
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
      public Real RenderModelScale {
        get {
          return this._renderModelScale;
        }
        set {
          this._renderModelScale = value;
        }
      }
      public Real MovementScale {
        get {
          return this._movementScale;
        }
        set {
          this._movementScale = value;
        }
      }
      public RealRGBColor IndoorAmbientColor {
        get {
          return this._indoorAmbientColor;
        }
        set {
          this._indoorAmbientColor = value;
        }
      }
      public RealRGBColor OutdoorAmbientColor {
        get {
          return this._outdoorAmbientColor;
        }
        set {
          this._outdoorAmbientColor = value;
        }
      }
      public Real FogSpreadDistance {
        get {
          return this._fogSpreadDistance;
        }
        set {
          this._fogSpreadDistance = value;
        }
      }
      public RealFraction Amount {
        get {
          return this._amount;
        }
        set {
          this._amount = value;
        }
      }
      public RealFraction Threshold {
        get {
          return this._threshold;
        }
        set {
          this._threshold = value;
        }
      }
      public RealFraction Brightness {
        get {
          return this._brightness;
        }
        set {
          this._brightness = value;
        }
      }
      public Real GammaPower {
        get {
          return this._gammaPower;
        }
        set {
          this._gammaPower = value;
        }
      }
      public Angle GlobalSkyRotation {
        get {
          return this._globalSkyRotation;
        }
        set {
          this._globalSkyRotation = value;
        }
      }
      public RealRGBColor ClearColor {
        get {
          return this._clearColor;
        }
        set {
          this._clearColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _renderModel.Read(reader);
        _animationGraph.Read(reader);
        _flags.Read(reader);
        _renderModelScale.Read(reader);
        _movementScale.Read(reader);
        _cubeMap.Read(reader);
        _indoorAmbientColor.Read(reader);
        _unnamed0.Read(reader);
        _outdoorAmbientColor.Read(reader);
        _unnamed1.Read(reader);
        _fogSpreadDistance.Read(reader);
        _atmosphericFog.Read(reader);
        _secondaryFog.Read(reader);
        _skyFog.Read(reader);
        _patchyFog.Read(reader);
        _amount.Read(reader);
        _threshold.Read(reader);
        _brightness.Read(reader);
        _gammaPower.Read(reader);
        _lights.Read(reader);
        _globalSkyRotation.Read(reader);
        _shaderFunctions.Read(reader);
        _animations.Read(reader);
        _unnamed2.Read(reader);
        _clearColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _renderModel.ReadString(reader);
        _animationGraph.ReadString(reader);
        for (x = 0; (x < _cubeMap.Count); x = (x + 1)) {
          CubeMap.Add(new SkyCubemapBlockBlock());
          CubeMap[x].Read(reader);
        }
        for (x = 0; (x < _cubeMap.Count); x = (x + 1)) {
          CubeMap[x].ReadChildData(reader);
        }
        for (x = 0; (x < _atmosphericFog.Count); x = (x + 1)) {
          AtmosphericFog.Add(new SkyAtmosphericFogBlockBlock());
          AtmosphericFog[x].Read(reader);
        }
        for (x = 0; (x < _atmosphericFog.Count); x = (x + 1)) {
          AtmosphericFog[x].ReadChildData(reader);
        }
        for (x = 0; (x < _secondaryFog.Count); x = (x + 1)) {
          SecondaryFog.Add(new SkyAtmosphericFogBlockBlock());
          SecondaryFog[x].Read(reader);
        }
        for (x = 0; (x < _secondaryFog.Count); x = (x + 1)) {
          SecondaryFog[x].ReadChildData(reader);
        }
        for (x = 0; (x < _skyFog.Count); x = (x + 1)) {
          SkyFog.Add(new SkyFogBlockBlock());
          SkyFog[x].Read(reader);
        }
        for (x = 0; (x < _skyFog.Count); x = (x + 1)) {
          SkyFog[x].ReadChildData(reader);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog.Add(new SkyPatchyFogBlockBlock());
          PatchyFog[x].Read(reader);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights.Add(new SkyLightBlockBlock());
          Lights[x].Read(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions.Add(new SkyShaderFunctionBlockBlock());
          ShaderFunctions[x].Read(reader);
        }
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new SkyAnimationBlockBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _renderModel.Write(bw);
        _animationGraph.Write(bw);
        _flags.Write(bw);
        _renderModelScale.Write(bw);
        _movementScale.Write(bw);
_cubeMap.Count = CubeMap.Count;
        _cubeMap.Write(bw);
        _indoorAmbientColor.Write(bw);
        _unnamed0.Write(bw);
        _outdoorAmbientColor.Write(bw);
        _unnamed1.Write(bw);
        _fogSpreadDistance.Write(bw);
_atmosphericFog.Count = AtmosphericFog.Count;
        _atmosphericFog.Write(bw);
_secondaryFog.Count = SecondaryFog.Count;
        _secondaryFog.Write(bw);
_skyFog.Count = SkyFog.Count;
        _skyFog.Write(bw);
_patchyFog.Count = PatchyFog.Count;
        _patchyFog.Write(bw);
        _amount.Write(bw);
        _threshold.Write(bw);
        _brightness.Write(bw);
        _gammaPower.Write(bw);
_lights.Count = Lights.Count;
        _lights.Write(bw);
        _globalSkyRotation.Write(bw);
_shaderFunctions.Count = ShaderFunctions.Count;
        _shaderFunctions.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
        _unnamed2.Write(bw);
        _clearColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _renderModel.WriteString(writer);
        _animationGraph.WriteString(writer);
        for (x = 0; (x < _cubeMap.Count); x = (x + 1)) {
          CubeMap[x].Write(writer);
        }
        for (x = 0; (x < _cubeMap.Count); x = (x + 1)) {
          CubeMap[x].WriteChildData(writer);
        }
        for (x = 0; (x < _atmosphericFog.Count); x = (x + 1)) {
          AtmosphericFog[x].Write(writer);
        }
        for (x = 0; (x < _atmosphericFog.Count); x = (x + 1)) {
          AtmosphericFog[x].WriteChildData(writer);
        }
        for (x = 0; (x < _secondaryFog.Count); x = (x + 1)) {
          SecondaryFog[x].Write(writer);
        }
        for (x = 0; (x < _secondaryFog.Count); x = (x + 1)) {
          SecondaryFog[x].WriteChildData(writer);
        }
        for (x = 0; (x < _skyFog.Count); x = (x + 1)) {
          SkyFog[x].Write(writer);
        }
        for (x = 0; (x < _skyFog.Count); x = (x + 1)) {
          SkyFog[x].WriteChildData(writer);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].Write(writer);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].Write(writer);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions[x].Write(writer);
        }
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class SkyCubemapBlockBlock : IBlock {
      private TagReference _cubeMapReference = new TagReference();
      private Real _powerScale = new Real();
public event System.EventHandler BlockNameChanged;
      public SkyCubemapBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_cubeMapReference.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference CubeMapReference {
        get {
          return this._cubeMapReference;
        }
        set {
          this._cubeMapReference = value;
        }
      }
      public Real PowerScale {
        get {
          return this._powerScale;
        }
        set {
          this._powerScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _cubeMapReference.Read(reader);
        _powerScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _cubeMapReference.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _cubeMapReference.Write(bw);
        _powerScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _cubeMapReference.WriteString(writer);
      }
    }
    public class SkyAtmosphericFogBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
      private RealFraction _maximumDensity = new RealFraction();
      private Real _startDistance = new Real();
      private Real _opaqueDistance = new Real();
public event System.EventHandler BlockNameChanged;
      public SkyAtmosphericFogBlockBlock() {
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
      public RealFraction MaximumDensity {
        get {
          return this._maximumDensity;
        }
        set {
          this._maximumDensity = value;
        }
      }
      public Real StartDistance {
        get {
          return this._startDistance;
        }
        set {
          this._startDistance = value;
        }
      }
      public Real OpaqueDistance {
        get {
          return this._opaqueDistance;
        }
        set {
          this._opaqueDistance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
        _maximumDensity.Read(reader);
        _startDistance.Read(reader);
        _opaqueDistance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
        _maximumDensity.Write(bw);
        _startDistance.Write(bw);
        _opaqueDistance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyFogBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
      private RealFraction _density = new RealFraction();
public event System.EventHandler BlockNameChanged;
      public SkyFogBlockBlock() {
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
      public RealFraction Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
        _density.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
        _density.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyPatchyFogBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
      private Pad _unnamed0;
      private FractionBounds _density = new FractionBounds();
      private RealBounds _distance = new RealBounds();
      private Pad _unnamed1;
      private TagReference _patchyFog = new TagReference();
public event System.EventHandler BlockNameChanged;
      public SkyPatchyFogBlockBlock() {
        this._unnamed0 = new Pad(12);
        this._unnamed1 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_patchyFog.Value);
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
      public FractionBounds Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public RealBounds Distance {
        get {
          return this._distance;
        }
        set {
          this._distance = value;
        }
      }
      public TagReference PatchyFog {
        get {
          return this._patchyFog;
        }
        set {
          this._patchyFog = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
        _unnamed0.Read(reader);
        _density.Read(reader);
        _distance.Read(reader);
        _unnamed1.Read(reader);
        _patchyFog.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _patchyFog.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
        _unnamed0.Write(bw);
        _density.Write(bw);
        _distance.Write(bw);
        _unnamed1.Write(bw);
        _patchyFog.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _patchyFog.WriteString(writer);
      }
    }
    public class SkyLightBlockBlock : IBlock {
      private RealVector3D _directionVector = new RealVector3D();
      private RealEulerAngles2D _direction = new RealEulerAngles2D();
      private TagReference _lensFlare = new TagReference();
      private Block _fog = new Block();
      private Block _fogOpposite = new Block();
      private Block _radiosity = new Block();
      public BlockCollection<SkyLightFogBlockBlock> _fogList = new BlockCollection<SkyLightFogBlockBlock>();
      public BlockCollection<SkyLightFogBlockBlock> _fogOppositeList = new BlockCollection<SkyLightFogBlockBlock>();
      public BlockCollection<SkyRadiosityLightBlockBlock> _radiosityList = new BlockCollection<SkyRadiosityLightBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SkyLightBlockBlock() {
      }
      public BlockCollection<SkyLightFogBlockBlock> Fog {
        get {
          return this._fogList;
        }
      }
      public BlockCollection<SkyLightFogBlockBlock> FogOpposite {
        get {
          return this._fogOppositeList;
        }
      }
      public BlockCollection<SkyRadiosityLightBlockBlock> Radiosity {
        get {
          return this._radiosityList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lensFlare.Value);
for (int x=0; x<Fog.BlockCount; x++)
{
  IBlock block = Fog.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogOpposite.BlockCount; x++)
{
  IBlock block = FogOpposite.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Radiosity.BlockCount; x++)
{
  IBlock block = Radiosity.GetBlock(x);
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
      public RealVector3D DirectionVector {
        get {
          return this._directionVector;
        }
        set {
          this._directionVector = value;
        }
      }
      public RealEulerAngles2D Direction {
        get {
          return this._direction;
        }
        set {
          this._direction = value;
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
        _directionVector.Read(reader);
        _direction.Read(reader);
        _lensFlare.Read(reader);
        _fog.Read(reader);
        _fogOpposite.Read(reader);
        _radiosity.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _lensFlare.ReadString(reader);
        for (x = 0; (x < _fog.Count); x = (x + 1)) {
          Fog.Add(new SkyLightFogBlockBlock());
          Fog[x].Read(reader);
        }
        for (x = 0; (x < _fog.Count); x = (x + 1)) {
          Fog[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogOpposite.Count); x = (x + 1)) {
          FogOpposite.Add(new SkyLightFogBlockBlock());
          FogOpposite[x].Read(reader);
        }
        for (x = 0; (x < _fogOpposite.Count); x = (x + 1)) {
          FogOpposite[x].ReadChildData(reader);
        }
        for (x = 0; (x < _radiosity.Count); x = (x + 1)) {
          Radiosity.Add(new SkyRadiosityLightBlockBlock());
          Radiosity[x].Read(reader);
        }
        for (x = 0; (x < _radiosity.Count); x = (x + 1)) {
          Radiosity[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _directionVector.Write(bw);
        _direction.Write(bw);
        _lensFlare.Write(bw);
_fog.Count = Fog.Count;
        _fog.Write(bw);
_fogOpposite.Count = FogOpposite.Count;
        _fogOpposite.Write(bw);
_radiosity.Count = Radiosity.Count;
        _radiosity.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _lensFlare.WriteString(writer);
        for (x = 0; (x < _fog.Count); x = (x + 1)) {
          Fog[x].Write(writer);
        }
        for (x = 0; (x < _fog.Count); x = (x + 1)) {
          Fog[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogOpposite.Count); x = (x + 1)) {
          FogOpposite[x].Write(writer);
        }
        for (x = 0; (x < _fogOpposite.Count); x = (x + 1)) {
          FogOpposite[x].WriteChildData(writer);
        }
        for (x = 0; (x < _radiosity.Count); x = (x + 1)) {
          Radiosity[x].Write(writer);
        }
        for (x = 0; (x < _radiosity.Count); x = (x + 1)) {
          Radiosity[x].WriteChildData(writer);
        }
      }
    }
    public class SkyLightFogBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
      private RealFraction _maximumDensity = new RealFraction();
      private Real _startDistance = new Real();
      private Real _opaqueDistance = new Real();
      private AngleBounds _cone = new AngleBounds();
      private RealFraction _atmosphericFogInfluence = new RealFraction();
      private RealFraction _secondaryFogInfluence = new RealFraction();
      private RealFraction _skyFogInfluence = new RealFraction();
public event System.EventHandler BlockNameChanged;
      public SkyLightFogBlockBlock() {
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
      public RealFraction MaximumDensity {
        get {
          return this._maximumDensity;
        }
        set {
          this._maximumDensity = value;
        }
      }
      public Real StartDistance {
        get {
          return this._startDistance;
        }
        set {
          this._startDistance = value;
        }
      }
      public Real OpaqueDistance {
        get {
          return this._opaqueDistance;
        }
        set {
          this._opaqueDistance = value;
        }
      }
      public AngleBounds Cone {
        get {
          return this._cone;
        }
        set {
          this._cone = value;
        }
      }
      public RealFraction AtmosphericFogInfluence {
        get {
          return this._atmosphericFogInfluence;
        }
        set {
          this._atmosphericFogInfluence = value;
        }
      }
      public RealFraction SecondaryFogInfluence {
        get {
          return this._secondaryFogInfluence;
        }
        set {
          this._secondaryFogInfluence = value;
        }
      }
      public RealFraction SkyFogInfluence {
        get {
          return this._skyFogInfluence;
        }
        set {
          this._skyFogInfluence = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
        _maximumDensity.Read(reader);
        _startDistance.Read(reader);
        _opaqueDistance.Read(reader);
        _cone.Read(reader);
        _atmosphericFogInfluence.Read(reader);
        _secondaryFogInfluence.Read(reader);
        _skyFogInfluence.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
        _maximumDensity.Write(bw);
        _startDistance.Write(bw);
        _opaqueDistance.Write(bw);
        _cone.Write(bw);
        _atmosphericFogInfluence.Write(bw);
        _secondaryFogInfluence.Write(bw);
        _skyFogInfluence.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyRadiosityLightBlockBlock : IBlock {
      private Flags _flags;
      private RealRGBColor _color = new RealRGBColor();
      private Real _power = new Real();
      private Real _testDistance = new Real();
      private Pad _unnamed0;
      private Angle _diameter = new Angle();
public event System.EventHandler BlockNameChanged;
      public SkyRadiosityLightBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(12);
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
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public Real Power {
        get {
          return this._power;
        }
        set {
          this._power = value;
        }
      }
      public Real TestDistance {
        get {
          return this._testDistance;
        }
        set {
          this._testDistance = value;
        }
      }
      public Angle Diameter {
        get {
          return this._diameter;
        }
        set {
          this._diameter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _color.Read(reader);
        _power.Read(reader);
        _testDistance.Read(reader);
        _unnamed0.Read(reader);
        _diameter.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _color.Write(bw);
        _power.Write(bw);
        _testDistance.Write(bw);
        _unnamed0.Write(bw);
        _diameter.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyShaderFunctionBlockBlock : IBlock {
      private Pad _unnamed0;
      private FixedLengthString _globalFunctionName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public SkyShaderFunctionBlockBlock() {
if (this._globalFunctionName is System.ComponentModel.INotifyPropertyChanged)
  (this._globalFunctionName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _globalFunctionName.ToString();
        }
      }
      public FixedLengthString GlobalFunctionName {
        get {
          return this._globalFunctionName;
        }
        set {
          this._globalFunctionName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _globalFunctionName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _globalFunctionName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyAnimationBlockBlock : IBlock {
      private ShortInteger _animationIndex = new ShortInteger();
      private Pad _unnamed0;
      private Real _period = new Real();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public SkyAnimationBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(28);
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
      public ShortInteger AnimationIndex {
        get {
          return this._animationIndex;
        }
        set {
          this._animationIndex = value;
        }
      }
      public Real Period {
        get {
          return this._period;
        }
        set {
          this._period = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animationIndex.Read(reader);
        _unnamed0.Read(reader);
        _period.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animationIndex.Write(bw);
        _unnamed0.Write(bw);
        _period.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
