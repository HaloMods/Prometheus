// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'light'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class light : Interfaces.Pool.Tag {
    private LightBlockBlock lightValues = new LightBlockBlock();
    public virtual LightBlockBlock LightValues {
      get {
        return lightValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LightValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "light";
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
lightValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lightValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lightValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lightValues.WriteChildData(writer);
    }
    #endregion
    public class LightBlockBlock : IBlock {
      private Flags _flags;
      private Enum _type;
      private Pad _unnamed0;
      private RealBounds _sizeModifer = new RealBounds();
      private Real _shadowQualityBias = new Real();
      private Enum _shadowTapBias;
      private Pad _unnamed1;
      private Real _radius = new Real();
      private Real _specularRadius = new Real();
      private Real _nearWidth = new Real();
      private Real _heightStretch = new Real();
      private Real _fieldOfView = new Real();
      private Real _falloffDistance = new Real();
      private Real _cutoffDistance = new Real();
      private Flags _interpolationFlags;
      private RealBounds _bloomBounds = new RealBounds();
      private RealRGBColor _specularLowerBound = new RealRGBColor();
      private RealRGBColor _specularUpperBound = new RealRGBColor();
      private RealRGBColor _diffuseLowerBound = new RealRGBColor();
      private RealRGBColor _diffuseUpperBound = new RealRGBColor();
      private RealBounds _brightnessBounds = new RealBounds();
      private TagReference _gelMap = new TagReference();
      private Enum _specularMask;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Enum _falloffFunction;
      private Enum _diffuseContrast;
      private Enum _specularContrast;
      private Enum _falloffGeometry;
      private TagReference _lensFlare = new TagReference();
      private Real _boundingRadius = new Real();
      private TagReference _lightVolume = new TagReference();
      private Enum _defaultLightmapSetting;
      private Pad _unnamed4;
      private Real _lightmapHalfLife = new Real();
      private Real _lightmapLightScale = new Real();
      private Real _duration = new Real();
      private Pad _unnamed5;
      private Enum _falloffFunction2;
      private Enum _illuminationFade;
      private Enum _shadowFade;
      private Enum _specularFade;
      private Pad _unnamed6;
      private Flags _flags2;
      private Block _brightnessAnimation = new Block();
      private Block _colorAnimation = new Block();
      private Block _gelAnimation = new Block();
      private TagReference _shader = new TagReference();
      public BlockCollection<LightBrightnessAnimationBlockBlock> _brightnessAnimationList = new BlockCollection<LightBrightnessAnimationBlockBlock>();
      public BlockCollection<LightColorAnimationBlockBlock> _colorAnimationList = new BlockCollection<LightColorAnimationBlockBlock>();
      public BlockCollection<LightGelAnimationBlockBlock> _gelAnimationList = new BlockCollection<LightGelAnimationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightBlockBlock() {
        this._flags = new Flags(4);
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._shadowTapBias = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._interpolationFlags = new Flags(4);
        this._specularMask = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(4);
        this._falloffFunction = new Enum(2);
        this._diffuseContrast = new Enum(2);
        this._specularContrast = new Enum(2);
        this._falloffGeometry = new Enum(2);
        this._defaultLightmapSetting = new Enum(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(2);
        this._falloffFunction2 = new Enum(2);
        this._illuminationFade = new Enum(2);
        this._shadowFade = new Enum(2);
        this._specularFade = new Enum(2);
        this._unnamed6 = new Pad(2);
        this._flags2 = new Flags(4);
      }
      public BlockCollection<LightBrightnessAnimationBlockBlock> BrightnessAnimation {
        get {
          return this._brightnessAnimationList;
        }
      }
      public BlockCollection<LightColorAnimationBlockBlock> ColorAnimation {
        get {
          return this._colorAnimationList;
        }
      }
      public BlockCollection<LightGelAnimationBlockBlock> GelAnimation {
        get {
          return this._gelAnimationList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_gelMap.Value);
references.Add(_lensFlare.Value);
references.Add(_lightVolume.Value);
references.Add(_shader.Value);
for (int x=0; x<BrightnessAnimation.BlockCount; x++)
{
  IBlock block = BrightnessAnimation.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ColorAnimation.BlockCount; x++)
{
  IBlock block = ColorAnimation.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GelAnimation.BlockCount; x++)
{
  IBlock block = GelAnimation.GetBlock(x);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public RealBounds SizeModifer {
        get {
          return this._sizeModifer;
        }
        set {
          this._sizeModifer = value;
        }
      }
      public Real ShadowQualityBias {
        get {
          return this._shadowQualityBias;
        }
        set {
          this._shadowQualityBias = value;
        }
      }
      public Enum ShadowTapBias {
        get {
          return this._shadowTapBias;
        }
        set {
          this._shadowTapBias = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public Real SpecularRadius {
        get {
          return this._specularRadius;
        }
        set {
          this._specularRadius = value;
        }
      }
      public Real NearWidth {
        get {
          return this._nearWidth;
        }
        set {
          this._nearWidth = value;
        }
      }
      public Real HeightStretch {
        get {
          return this._heightStretch;
        }
        set {
          this._heightStretch = value;
        }
      }
      public Real FieldOfView {
        get {
          return this._fieldOfView;
        }
        set {
          this._fieldOfView = value;
        }
      }
      public Real FalloffDistance {
        get {
          return this._falloffDistance;
        }
        set {
          this._falloffDistance = value;
        }
      }
      public Real CutoffDistance {
        get {
          return this._cutoffDistance;
        }
        set {
          this._cutoffDistance = value;
        }
      }
      public Flags InterpolationFlags {
        get {
          return this._interpolationFlags;
        }
        set {
          this._interpolationFlags = value;
        }
      }
      public RealBounds BloomBounds {
        get {
          return this._bloomBounds;
        }
        set {
          this._bloomBounds = value;
        }
      }
      public RealRGBColor SpecularLowerBound {
        get {
          return this._specularLowerBound;
        }
        set {
          this._specularLowerBound = value;
        }
      }
      public RealRGBColor SpecularUpperBound {
        get {
          return this._specularUpperBound;
        }
        set {
          this._specularUpperBound = value;
        }
      }
      public RealRGBColor DiffuseLowerBound {
        get {
          return this._diffuseLowerBound;
        }
        set {
          this._diffuseLowerBound = value;
        }
      }
      public RealRGBColor DiffuseUpperBound {
        get {
          return this._diffuseUpperBound;
        }
        set {
          this._diffuseUpperBound = value;
        }
      }
      public RealBounds BrightnessBounds {
        get {
          return this._brightnessBounds;
        }
        set {
          this._brightnessBounds = value;
        }
      }
      public TagReference GelMap {
        get {
          return this._gelMap;
        }
        set {
          this._gelMap = value;
        }
      }
      public Enum SpecularMask {
        get {
          return this._specularMask;
        }
        set {
          this._specularMask = value;
        }
      }
      public Enum FalloffFunction {
        get {
          return this._falloffFunction;
        }
        set {
          this._falloffFunction = value;
        }
      }
      public Enum DiffuseContrast {
        get {
          return this._diffuseContrast;
        }
        set {
          this._diffuseContrast = value;
        }
      }
      public Enum SpecularContrast {
        get {
          return this._specularContrast;
        }
        set {
          this._specularContrast = value;
        }
      }
      public Enum FalloffGeometry {
        get {
          return this._falloffGeometry;
        }
        set {
          this._falloffGeometry = value;
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
      public Real BoundingRadius {
        get {
          return this._boundingRadius;
        }
        set {
          this._boundingRadius = value;
        }
      }
      public TagReference LightVolume {
        get {
          return this._lightVolume;
        }
        set {
          this._lightVolume = value;
        }
      }
      public Enum DefaultLightmapSetting {
        get {
          return this._defaultLightmapSetting;
        }
        set {
          this._defaultLightmapSetting = value;
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
      public Real LightmapLightScale {
        get {
          return this._lightmapLightScale;
        }
        set {
          this._lightmapLightScale = value;
        }
      }
      public Real Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public Enum FalloffFunction2 {
        get {
          return this._falloffFunction2;
        }
        set {
          this._falloffFunction2 = value;
        }
      }
      public Enum IlluminationFade {
        get {
          return this._illuminationFade;
        }
        set {
          this._illuminationFade = value;
        }
      }
      public Enum ShadowFade {
        get {
          return this._shadowFade;
        }
        set {
          this._shadowFade = value;
        }
      }
      public Enum SpecularFade {
        get {
          return this._specularFade;
        }
        set {
          this._specularFade = value;
        }
      }
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
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
        _flags.Read(reader);
        _type.Read(reader);
        _unnamed0.Read(reader);
        _sizeModifer.Read(reader);
        _shadowQualityBias.Read(reader);
        _shadowTapBias.Read(reader);
        _unnamed1.Read(reader);
        _radius.Read(reader);
        _specularRadius.Read(reader);
        _nearWidth.Read(reader);
        _heightStretch.Read(reader);
        _fieldOfView.Read(reader);
        _falloffDistance.Read(reader);
        _cutoffDistance.Read(reader);
        _interpolationFlags.Read(reader);
        _bloomBounds.Read(reader);
        _specularLowerBound.Read(reader);
        _specularUpperBound.Read(reader);
        _diffuseLowerBound.Read(reader);
        _diffuseUpperBound.Read(reader);
        _brightnessBounds.Read(reader);
        _gelMap.Read(reader);
        _specularMask.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _falloffFunction.Read(reader);
        _diffuseContrast.Read(reader);
        _specularContrast.Read(reader);
        _falloffGeometry.Read(reader);
        _lensFlare.Read(reader);
        _boundingRadius.Read(reader);
        _lightVolume.Read(reader);
        _defaultLightmapSetting.Read(reader);
        _unnamed4.Read(reader);
        _lightmapHalfLife.Read(reader);
        _lightmapLightScale.Read(reader);
        _duration.Read(reader);
        _unnamed5.Read(reader);
        _falloffFunction2.Read(reader);
        _illuminationFade.Read(reader);
        _shadowFade.Read(reader);
        _specularFade.Read(reader);
        _unnamed6.Read(reader);
        _flags2.Read(reader);
        _brightnessAnimation.Read(reader);
        _colorAnimation.Read(reader);
        _gelAnimation.Read(reader);
        _shader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _gelMap.ReadString(reader);
        _lensFlare.ReadString(reader);
        _lightVolume.ReadString(reader);
        for (x = 0; (x < _brightnessAnimation.Count); x = (x + 1)) {
          BrightnessAnimation.Add(new LightBrightnessAnimationBlockBlock());
          BrightnessAnimation[x].Read(reader);
        }
        for (x = 0; (x < _brightnessAnimation.Count); x = (x + 1)) {
          BrightnessAnimation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _colorAnimation.Count); x = (x + 1)) {
          ColorAnimation.Add(new LightColorAnimationBlockBlock());
          ColorAnimation[x].Read(reader);
        }
        for (x = 0; (x < _colorAnimation.Count); x = (x + 1)) {
          ColorAnimation[x].ReadChildData(reader);
        }
        for (x = 0; (x < _gelAnimation.Count); x = (x + 1)) {
          GelAnimation.Add(new LightGelAnimationBlockBlock());
          GelAnimation[x].Read(reader);
        }
        for (x = 0; (x < _gelAnimation.Count); x = (x + 1)) {
          GelAnimation[x].ReadChildData(reader);
        }
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _unnamed0.Write(bw);
        _sizeModifer.Write(bw);
        _shadowQualityBias.Write(bw);
        _shadowTapBias.Write(bw);
        _unnamed1.Write(bw);
        _radius.Write(bw);
        _specularRadius.Write(bw);
        _nearWidth.Write(bw);
        _heightStretch.Write(bw);
        _fieldOfView.Write(bw);
        _falloffDistance.Write(bw);
        _cutoffDistance.Write(bw);
        _interpolationFlags.Write(bw);
        _bloomBounds.Write(bw);
        _specularLowerBound.Write(bw);
        _specularUpperBound.Write(bw);
        _diffuseLowerBound.Write(bw);
        _diffuseUpperBound.Write(bw);
        _brightnessBounds.Write(bw);
        _gelMap.Write(bw);
        _specularMask.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _falloffFunction.Write(bw);
        _diffuseContrast.Write(bw);
        _specularContrast.Write(bw);
        _falloffGeometry.Write(bw);
        _lensFlare.Write(bw);
        _boundingRadius.Write(bw);
        _lightVolume.Write(bw);
        _defaultLightmapSetting.Write(bw);
        _unnamed4.Write(bw);
        _lightmapHalfLife.Write(bw);
        _lightmapLightScale.Write(bw);
        _duration.Write(bw);
        _unnamed5.Write(bw);
        _falloffFunction2.Write(bw);
        _illuminationFade.Write(bw);
        _shadowFade.Write(bw);
        _specularFade.Write(bw);
        _unnamed6.Write(bw);
        _flags2.Write(bw);
_brightnessAnimation.Count = BrightnessAnimation.Count;
        _brightnessAnimation.Write(bw);
_colorAnimation.Count = ColorAnimation.Count;
        _colorAnimation.Write(bw);
_gelAnimation.Count = GelAnimation.Count;
        _gelAnimation.Write(bw);
        _shader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _gelMap.WriteString(writer);
        _lensFlare.WriteString(writer);
        _lightVolume.WriteString(writer);
        for (x = 0; (x < _brightnessAnimation.Count); x = (x + 1)) {
          BrightnessAnimation[x].Write(writer);
        }
        for (x = 0; (x < _brightnessAnimation.Count); x = (x + 1)) {
          BrightnessAnimation[x].WriteChildData(writer);
        }
        for (x = 0; (x < _colorAnimation.Count); x = (x + 1)) {
          ColorAnimation[x].Write(writer);
        }
        for (x = 0; (x < _colorAnimation.Count); x = (x + 1)) {
          ColorAnimation[x].WriteChildData(writer);
        }
        for (x = 0; (x < _gelAnimation.Count); x = (x + 1)) {
          GelAnimation[x].Write(writer);
        }
        for (x = 0; (x < _gelAnimation.Count); x = (x + 1)) {
          GelAnimation[x].WriteChildData(writer);
        }
        _shader.WriteString(writer);
      }
    }
    public class LightBrightnessAnimationBlockBlock : IBlock {
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightBrightnessAnimationBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
    public class LightColorAnimationBlockBlock : IBlock {
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightColorAnimationBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class LightGelAnimationBlockBlock : IBlock {
      private Block _data = new Block();
      private Block _data2 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightGelAnimationBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
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
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
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
        _data.Read(reader);
        _data2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_data.Count = Data.Count;
        _data.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
      }
    }
  }
}
