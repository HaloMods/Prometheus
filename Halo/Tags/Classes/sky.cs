// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'sky'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class sky : Interfaces.Pool.Tag {
    private SkyBlock skyValues = new SkyBlock();
    public virtual SkyBlock SkyValues {
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
    public class SkyBlock : IBlock {
      private TagReference _model = new TagReference();
      private TagReference _animationgraph = new TagReference();
      private Pad _unnamed;
      private RealRGBColor _indoorAmbientRadiosityColor = new RealRGBColor();
      private Real _indoorAmbientRadiosityPower = new Real();
      private RealRGBColor _outdoorAmbientRadiosityColor = new RealRGBColor();
      private Real _outdoorAmbientRadiosityPower = new Real();
      private RealRGBColor _outdoorFogColor = new RealRGBColor();
      private Pad _unnamed2;
      private RealFraction _outdoorFogMaximumDensity = new RealFraction();
      private Real _outdoorFogStartDistance = new Real();
      private Real _outdoorFogOpaqueDistance = new Real();
      private RealRGBColor _indoorFogColor = new RealRGBColor();
      private Pad _unnamed3;
      private RealFraction _indoorFogMaximumDensity = new RealFraction();
      private Real _indoorFogStartDistance = new Real();
      private Real _indoorFogOpaqueDistance = new Real();
      private TagReference _indoorFogScreen = new TagReference();
      private Pad _unnamed4;
      private Block _shaderFunctions = new Block();
      private Block _animations = new Block();
      private Block _lights = new Block();
      public BlockCollection<SkyShaderFunctionBlock> _shaderFunctionsList = new BlockCollection<SkyShaderFunctionBlock>();
      public BlockCollection<SkyAnimationBlock> _animationsList = new BlockCollection<SkyAnimationBlock>();
      public BlockCollection<SkyLightBlock> _lightsList = new BlockCollection<SkyLightBlock>();
public event System.EventHandler BlockNameChanged;
      public SkyBlock() {
        this._unnamed = new Pad(24);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(4);
      }
      public BlockCollection<SkyShaderFunctionBlock> ShaderFunctions {
        get {
          return this._shaderFunctionsList;
        }
      }
      public BlockCollection<SkyAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public BlockCollection<SkyLightBlock> Lights {
        get {
          return this._lightsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_model.Value);
references.Add(_animationgraph.Value);
references.Add(_indoorFogScreen.Value);
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
for (int x=0; x<Lights.BlockCount; x++)
{
  IBlock block = Lights.GetBlock(x);
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
      public TagReference Model {
        get {
          return this._model;
        }
        set {
          this._model = value;
        }
      }
      public TagReference Animationgraph {
        get {
          return this._animationgraph;
        }
        set {
          this._animationgraph = value;
        }
      }
      public RealRGBColor IndoorAmbientRadiosityColor {
        get {
          return this._indoorAmbientRadiosityColor;
        }
        set {
          this._indoorAmbientRadiosityColor = value;
        }
      }
      public Real IndoorAmbientRadiosityPower {
        get {
          return this._indoorAmbientRadiosityPower;
        }
        set {
          this._indoorAmbientRadiosityPower = value;
        }
      }
      public RealRGBColor OutdoorAmbientRadiosityColor {
        get {
          return this._outdoorAmbientRadiosityColor;
        }
        set {
          this._outdoorAmbientRadiosityColor = value;
        }
      }
      public Real OutdoorAmbientRadiosityPower {
        get {
          return this._outdoorAmbientRadiosityPower;
        }
        set {
          this._outdoorAmbientRadiosityPower = value;
        }
      }
      public RealRGBColor OutdoorFogColor {
        get {
          return this._outdoorFogColor;
        }
        set {
          this._outdoorFogColor = value;
        }
      }
      public RealFraction OutdoorFogMaximumDensity {
        get {
          return this._outdoorFogMaximumDensity;
        }
        set {
          this._outdoorFogMaximumDensity = value;
        }
      }
      public Real OutdoorFogStartDistance {
        get {
          return this._outdoorFogStartDistance;
        }
        set {
          this._outdoorFogStartDistance = value;
        }
      }
      public Real OutdoorFogOpaqueDistance {
        get {
          return this._outdoorFogOpaqueDistance;
        }
        set {
          this._outdoorFogOpaqueDistance = value;
        }
      }
      public RealRGBColor IndoorFogColor {
        get {
          return this._indoorFogColor;
        }
        set {
          this._indoorFogColor = value;
        }
      }
      public RealFraction IndoorFogMaximumDensity {
        get {
          return this._indoorFogMaximumDensity;
        }
        set {
          this._indoorFogMaximumDensity = value;
        }
      }
      public Real IndoorFogStartDistance {
        get {
          return this._indoorFogStartDistance;
        }
        set {
          this._indoorFogStartDistance = value;
        }
      }
      public Real IndoorFogOpaqueDistance {
        get {
          return this._indoorFogOpaqueDistance;
        }
        set {
          this._indoorFogOpaqueDistance = value;
        }
      }
      public TagReference IndoorFogScreen {
        get {
          return this._indoorFogScreen;
        }
        set {
          this._indoorFogScreen = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _model.Read(reader);
        _animationgraph.Read(reader);
        _unnamed.Read(reader);
        _indoorAmbientRadiosityColor.Read(reader);
        _indoorAmbientRadiosityPower.Read(reader);
        _outdoorAmbientRadiosityColor.Read(reader);
        _outdoorAmbientRadiosityPower.Read(reader);
        _outdoorFogColor.Read(reader);
        _unnamed2.Read(reader);
        _outdoorFogMaximumDensity.Read(reader);
        _outdoorFogStartDistance.Read(reader);
        _outdoorFogOpaqueDistance.Read(reader);
        _indoorFogColor.Read(reader);
        _unnamed3.Read(reader);
        _indoorFogMaximumDensity.Read(reader);
        _indoorFogStartDistance.Read(reader);
        _indoorFogOpaqueDistance.Read(reader);
        _indoorFogScreen.Read(reader);
        _unnamed4.Read(reader);
        _shaderFunctions.Read(reader);
        _animations.Read(reader);
        _lights.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _model.ReadString(reader);
        _animationgraph.ReadString(reader);
        _indoorFogScreen.ReadString(reader);
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions.Add(new SkyShaderFunctionBlock());
          ShaderFunctions[x].Read(reader);
        }
        for (x = 0; (x < _shaderFunctions.Count); x = (x + 1)) {
          ShaderFunctions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new SkyAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights.Add(new SkyLightBlock());
          Lights[x].Read(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _model.Write(bw);
        _animationgraph.Write(bw);
        _unnamed.Write(bw);
        _indoorAmbientRadiosityColor.Write(bw);
        _indoorAmbientRadiosityPower.Write(bw);
        _outdoorAmbientRadiosityColor.Write(bw);
        _outdoorAmbientRadiosityPower.Write(bw);
        _outdoorFogColor.Write(bw);
        _unnamed2.Write(bw);
        _outdoorFogMaximumDensity.Write(bw);
        _outdoorFogStartDistance.Write(bw);
        _outdoorFogOpaqueDistance.Write(bw);
        _indoorFogColor.Write(bw);
        _unnamed3.Write(bw);
        _indoorFogMaximumDensity.Write(bw);
        _indoorFogStartDistance.Write(bw);
        _indoorFogOpaqueDistance.Write(bw);
        _indoorFogScreen.Write(bw);
        _unnamed4.Write(bw);
_shaderFunctions.Count = ShaderFunctions.Count;
        _shaderFunctions.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
_lights.Count = Lights.Count;
        _lights.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _model.WriteString(writer);
        _animationgraph.WriteString(writer);
        _indoorFogScreen.WriteString(writer);
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
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].Write(writer);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].WriteChildData(writer);
        }
      }
    }
    public class SkyShaderFunctionBlock : IBlock {
      private Pad _unnamed;
      private FixedLengthString _globalFunctionName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public SkyShaderFunctionBlock() {
if (this._globalFunctionName is System.ComponentModel.INotifyPropertyChanged)
  (this._globalFunctionName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
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
        _unnamed.Read(reader);
        _globalFunctionName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _globalFunctionName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyAnimationBlock : IBlock {
      private ShortInteger _animationIndex = new ShortInteger();
      private Pad _unnamed;
      private Real _period = new Real();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public SkyAnimationBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(28);
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
        _unnamed.Read(reader);
        _period.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animationIndex.Write(bw);
        _unnamed.Write(bw);
        _period.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SkyLightBlock : IBlock {
      private TagReference _lensFlare = new TagReference();
      private FixedLengthString _lensFlareMarkerName = new FixedLengthString();
      private Pad _unnamed;
      private Flags _flags;
      private RealRGBColor _color = new RealRGBColor();
      private Real _power = new Real();
      private Real _testDistance = new Real();
      private Pad _unnamed2;
      private RealEulerAngles2D _direction = new RealEulerAngles2D();
      private Angle _diameter = new Angle();
public event System.EventHandler BlockNameChanged;
      public SkyLightBlock() {
        this._unnamed = new Pad(28);
        this._flags = new Flags(4);
        this._unnamed2 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lensFlare.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
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
      public FixedLengthString LensFlareMarkerName {
        get {
          return this._lensFlareMarkerName;
        }
        set {
          this._lensFlareMarkerName = value;
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
      public RealEulerAngles2D Direction {
        get {
          return this._direction;
        }
        set {
          this._direction = value;
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
        _lensFlare.Read(reader);
        _lensFlareMarkerName.Read(reader);
        _unnamed.Read(reader);
        _flags.Read(reader);
        _color.Read(reader);
        _power.Read(reader);
        _testDistance.Read(reader);
        _unnamed2.Read(reader);
        _direction.Read(reader);
        _diameter.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _lensFlare.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _lensFlare.Write(bw);
        _lensFlareMarkerName.Write(bw);
        _unnamed.Write(bw);
        _flags.Write(bw);
        _color.Write(bw);
        _power.Write(bw);
        _testDistance.Write(bw);
        _unnamed2.Write(bw);
        _direction.Write(bw);
        _diameter.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _lensFlare.WriteString(writer);
      }
    }
  }
}
