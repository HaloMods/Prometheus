// --------------------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_chicago_extended' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// --------------------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_chicago_extended : shader {
    private ShaderTransparentChicagoExtendedBlock shaderTransparentChicagoExtendedValues = new ShaderTransparentChicagoExtendedBlock();
    public virtual ShaderTransparentChicagoExtendedBlock ShaderTransparentChicagoExtendedValues {
      get {
        return shaderTransparentChicagoExtendedValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentChicagoExtendedValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_chicago_extended";
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
shaderTransparentChicagoExtendedValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentChicagoExtendedValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentChicagoExtendedValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentChicagoExtendedValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentChicagoExtendedBlock : IBlock {
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
      private Block @__4StageMaps = new Block();
      private Block @__2StageMaps = new Block();
      private Flags _extraFlags;
      private Pad _unnamed2;
      public BlockCollection<ShaderTransparentLayerBlock> _extraLayersList = new BlockCollection<ShaderTransparentLayerBlock>();
      public BlockCollection<ShaderTransparentChicagoMapBlock> @__4StageMapsList = new BlockCollection<ShaderTransparentChicagoMapBlock>();
      public BlockCollection<ShaderTransparentChicagoMapBlock> @__2StageMapsList = new BlockCollection<ShaderTransparentChicagoMapBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentChicagoExtendedBlock() {
        this._flags = new Flags(1);
        this._unnamed = new Pad(2);
        this._extraFlags = new Flags(4);
        this._unnamed2 = new Pad(8);
      }
      public BlockCollection<ShaderTransparentLayerBlock> ExtraLayers {
        get {
          return this._extraLayersList;
        }
      }
      public BlockCollection<ShaderTransparentChicagoMapBlock> _4StageMaps {
        get {
          return this.@__4StageMapsList;
        }
      }
      public BlockCollection<ShaderTransparentChicagoMapBlock> _2StageMaps {
        get {
          return this.@__2StageMapsList;
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
for (int x=0; x<_4StageMaps.BlockCount; x++)
{
  IBlock block = _4StageMaps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<_2StageMaps.BlockCount; x++)
{
  IBlock block = _2StageMaps.GetBlock(x);
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
      public Flags ExtraFlags {
        get {
          return this._extraFlags;
        }
        set {
          this._extraFlags = value;
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
        @__4StageMaps.Read(reader);
        @__2StageMaps.Read(reader);
        _extraFlags.Read(reader);
        _unnamed2.Read(reader);
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
        for (x = 0; (x < @__4StageMaps.Count); x = (x + 1)) {
          _4StageMaps.Add(new ShaderTransparentChicagoMapBlock());
          _4StageMaps[x].Read(reader);
        }
        for (x = 0; (x < @__4StageMaps.Count); x = (x + 1)) {
          _4StageMaps[x].ReadChildData(reader);
        }
        for (x = 0; (x < @__2StageMaps.Count); x = (x + 1)) {
          _2StageMaps.Add(new ShaderTransparentChicagoMapBlock());
          _2StageMaps[x].Read(reader);
        }
        for (x = 0; (x < @__2StageMaps.Count); x = (x + 1)) {
          _2StageMaps[x].ReadChildData(reader);
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
__4StageMaps.Count = _4StageMaps.Count;
        @__4StageMaps.Write(bw);
__2StageMaps.Count = _2StageMaps.Count;
        @__2StageMaps.Write(bw);
        _extraFlags.Write(bw);
        _unnamed2.Write(bw);
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
        for (x = 0; (x < @__4StageMaps.Count); x = (x + 1)) {
          _4StageMaps[x].Write(writer);
        }
        for (x = 0; (x < @__4StageMaps.Count); x = (x + 1)) {
          _4StageMaps[x].WriteChildData(writer);
        }
        for (x = 0; (x < @__2StageMaps.Count); x = (x + 1)) {
          _2StageMaps[x].Write(writer);
        }
        for (x = 0; (x < @__2StageMaps.Count); x = (x + 1)) {
          _2StageMaps[x].WriteChildData(writer);
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
    public class ShaderTransparentChicagoMapBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private Enum _colorFunction = new Enum();
      private Enum _alphaFunction = new Enum();
      private Pad _unnamed3;
      private Real _map = new Real();
      private Real _map2 = new Real();
      private Real _map3 = new Real();
      private Real _map4 = new Real();
      private Real _mapRotation = new Real();
      private RealFraction _mipmapBias = new RealFraction();
      private TagReference _map5 = new TagReference();
      private Pad _unnamed4;
      private Enum _unnamed5 = new Enum();
      private Enum _unnamed6 = new Enum();
      private Real _unnamed7 = new Real();
      private Real _unnamed8 = new Real();
      private Real _unnamed9 = new Real();
      private Enum _unnamed10 = new Enum();
      private Enum _unnamed11 = new Enum();
      private Real _unnamed12 = new Real();
      private Real _unnamed13 = new Real();
      private Real _unnamed14 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentChicagoMapBlock() {
if (this._map5 is System.ComponentModel.INotifyPropertyChanged)
  (this._map5 as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(40);
        this._unnamed3 = new Pad(36);
        this._unnamed4 = new Pad(40);
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
return _map5.ToString();
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
      public Enum ColorFunction {
        get {
          return this._colorFunction;
        }
        set {
          this._colorFunction = value;
        }
      }
      public Enum AlphaFunction {
        get {
          return this._alphaFunction;
        }
        set {
          this._alphaFunction = value;
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
      public Enum unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public Enum unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public Real unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public Real unnamed8 {
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
      public Enum unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public Enum unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Real unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public Real unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public Real unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
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
        _unnamed2.Read(reader);
        _colorFunction.Read(reader);
        _alphaFunction.Read(reader);
        _unnamed3.Read(reader);
        _map.Read(reader);
        _map2.Read(reader);
        _map3.Read(reader);
        _map4.Read(reader);
        _mapRotation.Read(reader);
        _mipmapBias.Read(reader);
        _map5.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
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
        _unnamed2.Write(bw);
        _colorFunction.Write(bw);
        _alphaFunction.Write(bw);
        _unnamed3.Write(bw);
        _map.Write(bw);
        _map2.Write(bw);
        _map3.Write(bw);
        _map4.Write(bw);
        _mapRotation.Write(bw);
        _mipmapBias.Write(bw);
        _map5.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
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
  }
}
