// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'weather_system'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class weather_system : Interfaces.Pool.Tag {
    private GlobalWindModelStructBlockBlock weatherSystemValues = new GlobalWindModelStructBlockBlock();
    public virtual GlobalWindModelStructBlockBlock WeatherSystemValues {
      get {
        return weatherSystemValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(WeatherSystemValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "weather_system";
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
weatherSystemValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
weatherSystemValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
weatherSystemValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
weatherSystemValues.WriteChildData(writer);
    }
    #endregion
    public class GlobalWindModelStructBlockBlock : IBlock {
      private Block _particleSystem = new Block();
      private Block _backgroundPlates = new Block();
      private Real _windTilingScale = new Real();
      private RealVector3D _windPrimaryHeadingpitchstrength = new RealVector3D();
      private Real _primaryRateOfChange = new Real();
      private Real _primaryMinStrength = new Real();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private RealVector3D _windGustingHeadingpitchstrength = new RealVector3D();
      private Real _gustDiretionalRateOfChange = new Real();
      private Real _gustStrengthRateOfChange = new Real();
      private Real _gustConeAngle = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Real _turbulanceRateOfChange = new Real();
      private RealVector3D _turbulencescaleXYZ = new RealVector3D();
      private Real _gravityConstant = new Real();
      private Block _windpirmitives = new Block();
      private Pad _unnamed9;
      private Real _fadeRadius = new Real();
      public BlockCollection<GlobalParticleSystemLiteBlockBlock> _particleSystemList = new BlockCollection<GlobalParticleSystemLiteBlockBlock>();
      public BlockCollection<GlobalWeatherBackgroundPlateBlockBlock> _backgroundPlatesList = new BlockCollection<GlobalWeatherBackgroundPlateBlockBlock>();
      public BlockCollection<GloalWindPrimitivesBlockBlock> _windpirmitivesList = new BlockCollection<GloalWindPrimitivesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalWindModelStructBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(12);
        this._unnamed6 = new Pad(12);
        this._unnamed7 = new Pad(12);
        this._unnamed8 = new Pad(12);
        this._unnamed9 = new Pad(4);
      }
      public BlockCollection<GlobalParticleSystemLiteBlockBlock> ParticleSystem {
        get {
          return this._particleSystemList;
        }
      }
      public BlockCollection<GlobalWeatherBackgroundPlateBlockBlock> BackgroundPlates {
        get {
          return this._backgroundPlatesList;
        }
      }
      public BlockCollection<GloalWindPrimitivesBlockBlock> Windpirmitives {
        get {
          return this._windpirmitivesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ParticleSystem.BlockCount; x++)
{
  IBlock block = ParticleSystem.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BackgroundPlates.BlockCount; x++)
{
  IBlock block = BackgroundPlates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Windpirmitives.BlockCount; x++)
{
  IBlock block = Windpirmitives.GetBlock(x);
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
      public Real WindTilingScale {
        get {
          return this._windTilingScale;
        }
        set {
          this._windTilingScale = value;
        }
      }
      public RealVector3D WindPrimaryHeadingpitchstrength {
        get {
          return this._windPrimaryHeadingpitchstrength;
        }
        set {
          this._windPrimaryHeadingpitchstrength = value;
        }
      }
      public Real PrimaryRateOfChange {
        get {
          return this._primaryRateOfChange;
        }
        set {
          this._primaryRateOfChange = value;
        }
      }
      public Real PrimaryMinStrength {
        get {
          return this._primaryMinStrength;
        }
        set {
          this._primaryMinStrength = value;
        }
      }
      public RealVector3D WindGustingHeadingpitchstrength {
        get {
          return this._windGustingHeadingpitchstrength;
        }
        set {
          this._windGustingHeadingpitchstrength = value;
        }
      }
      public Real GustDiretionalRateOfChange {
        get {
          return this._gustDiretionalRateOfChange;
        }
        set {
          this._gustDiretionalRateOfChange = value;
        }
      }
      public Real GustStrengthRateOfChange {
        get {
          return this._gustStrengthRateOfChange;
        }
        set {
          this._gustStrengthRateOfChange = value;
        }
      }
      public Real GustConeAngle {
        get {
          return this._gustConeAngle;
        }
        set {
          this._gustConeAngle = value;
        }
      }
      public Real TurbulanceRateOfChange {
        get {
          return this._turbulanceRateOfChange;
        }
        set {
          this._turbulanceRateOfChange = value;
        }
      }
      public RealVector3D TurbulencescaleXYZ {
        get {
          return this._turbulencescaleXYZ;
        }
        set {
          this._turbulencescaleXYZ = value;
        }
      }
      public Real GravityConstant {
        get {
          return this._gravityConstant;
        }
        set {
          this._gravityConstant = value;
        }
      }
      public Real FadeRadius {
        get {
          return this._fadeRadius;
        }
        set {
          this._fadeRadius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _particleSystem.Read(reader);
        _backgroundPlates.Read(reader);
        _windTilingScale.Read(reader);
        _windPrimaryHeadingpitchstrength.Read(reader);
        _primaryRateOfChange.Read(reader);
        _primaryMinStrength.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _windGustingHeadingpitchstrength.Read(reader);
        _gustDiretionalRateOfChange.Read(reader);
        _gustStrengthRateOfChange.Read(reader);
        _gustConeAngle.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _turbulanceRateOfChange.Read(reader);
        _turbulencescaleXYZ.Read(reader);
        _gravityConstant.Read(reader);
        _windpirmitives.Read(reader);
        _unnamed9.Read(reader);
        _fadeRadius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _particleSystem.Count); x = (x + 1)) {
          ParticleSystem.Add(new GlobalParticleSystemLiteBlockBlock());
          ParticleSystem[x].Read(reader);
        }
        for (x = 0; (x < _particleSystem.Count); x = (x + 1)) {
          ParticleSystem[x].ReadChildData(reader);
        }
        for (x = 0; (x < _backgroundPlates.Count); x = (x + 1)) {
          BackgroundPlates.Add(new GlobalWeatherBackgroundPlateBlockBlock());
          BackgroundPlates[x].Read(reader);
        }
        for (x = 0; (x < _backgroundPlates.Count); x = (x + 1)) {
          BackgroundPlates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _windpirmitives.Count); x = (x + 1)) {
          Windpirmitives.Add(new GloalWindPrimitivesBlockBlock());
          Windpirmitives[x].Read(reader);
        }
        for (x = 0; (x < _windpirmitives.Count); x = (x + 1)) {
          Windpirmitives[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_particleSystem.Count = ParticleSystem.Count;
        _particleSystem.Write(bw);
_backgroundPlates.Count = BackgroundPlates.Count;
        _backgroundPlates.Write(bw);
        _windTilingScale.Write(bw);
        _windPrimaryHeadingpitchstrength.Write(bw);
        _primaryRateOfChange.Write(bw);
        _primaryMinStrength.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _windGustingHeadingpitchstrength.Write(bw);
        _gustDiretionalRateOfChange.Write(bw);
        _gustStrengthRateOfChange.Write(bw);
        _gustConeAngle.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _turbulanceRateOfChange.Write(bw);
        _turbulencescaleXYZ.Write(bw);
        _gravityConstant.Write(bw);
_windpirmitives.Count = Windpirmitives.Count;
        _windpirmitives.Write(bw);
        _unnamed9.Write(bw);
        _fadeRadius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _particleSystem.Count); x = (x + 1)) {
          ParticleSystem[x].Write(writer);
        }
        for (x = 0; (x < _particleSystem.Count); x = (x + 1)) {
          ParticleSystem[x].WriteChildData(writer);
        }
        for (x = 0; (x < _backgroundPlates.Count); x = (x + 1)) {
          BackgroundPlates[x].Write(writer);
        }
        for (x = 0; (x < _backgroundPlates.Count); x = (x + 1)) {
          BackgroundPlates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _windpirmitives.Count); x = (x + 1)) {
          Windpirmitives[x].Write(writer);
        }
        for (x = 0; (x < _windpirmitives.Count); x = (x + 1)) {
          Windpirmitives[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalParticleSystemLiteBlockBlock : IBlock {
      private TagReference _sprites = new TagReference();
      private Real _viewBoxWidth = new Real();
      private Real _viewBoxHeight = new Real();
      private Real _viewBoxDepth = new Real();
      private Real _exclusionRadius = new Real();
      private Real _maxVelocity = new Real();
      private Real _minMass = new Real();
      private Real _maxMass = new Real();
      private Real _minSize = new Real();
      private Real _maxSize = new Real();
      private LongInteger _maximumNumberOfParticles = new LongInteger();
      private RealVector3D _initialVelocity = new RealVector3D();
      private Real _bitmapAnimationSpeed = new Real();
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Block _particleSystemData = new Block();
      private Enum _type;
      private Pad _unnamed2;
      private Real _mininumOpacity = new Real();
      private Real _maxinumOpacity = new Real();
      private Real _rainStreakScale = new Real();
      private Real _rainLineWidth = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<ParticleSystemLiteDataBlockBlock> _particleSystemDataList = new BlockCollection<ParticleSystemLiteDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalParticleSystemLiteBlockBlock() {
        this._geometrySelfReference = new Skip(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._type = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public BlockCollection<ParticleSystemLiteDataBlockBlock> ParticleSystemData {
        get {
          return this._particleSystemDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sprites.Value);
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParticleSystemData.BlockCount; x++)
{
  IBlock block = ParticleSystemData.GetBlock(x);
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
      public TagReference Sprites {
        get {
          return this._sprites;
        }
        set {
          this._sprites = value;
        }
      }
      public Real ViewBoxWidth {
        get {
          return this._viewBoxWidth;
        }
        set {
          this._viewBoxWidth = value;
        }
      }
      public Real ViewBoxHeight {
        get {
          return this._viewBoxHeight;
        }
        set {
          this._viewBoxHeight = value;
        }
      }
      public Real ViewBoxDepth {
        get {
          return this._viewBoxDepth;
        }
        set {
          this._viewBoxDepth = value;
        }
      }
      public Real ExclusionRadius {
        get {
          return this._exclusionRadius;
        }
        set {
          this._exclusionRadius = value;
        }
      }
      public Real MaxVelocity {
        get {
          return this._maxVelocity;
        }
        set {
          this._maxVelocity = value;
        }
      }
      public Real MinMass {
        get {
          return this._minMass;
        }
        set {
          this._minMass = value;
        }
      }
      public Real MaxMass {
        get {
          return this._maxMass;
        }
        set {
          this._maxMass = value;
        }
      }
      public Real MinSize {
        get {
          return this._minSize;
        }
        set {
          this._minSize = value;
        }
      }
      public Real MaxSize {
        get {
          return this._maxSize;
        }
        set {
          this._maxSize = value;
        }
      }
      public LongInteger MaximumNumberOfParticles {
        get {
          return this._maximumNumberOfParticles;
        }
        set {
          this._maximumNumberOfParticles = value;
        }
      }
      public RealVector3D InitialVelocity {
        get {
          return this._initialVelocity;
        }
        set {
          this._initialVelocity = value;
        }
      }
      public Real BitmapAnimationSpeed {
        get {
          return this._bitmapAnimationSpeed;
        }
        set {
          this._bitmapAnimationSpeed = value;
        }
      }
      public ResourceBlock ResourceData {
        get {
          return this._resourceData;
        }
        set {
          this._resourceData = value;
        }
      }
      public LongInteger SectionDataSize {
        get {
          return this._sectionDataSize;
        }
        set {
          this._sectionDataSize = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public ShortInteger OwnerTagSectionOffset {
        get {
          return this._ownerTagSectionOffset;
        }
        set {
          this._ownerTagSectionOffset = value;
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
      public Real MininumOpacity {
        get {
          return this._mininumOpacity;
        }
        set {
          this._mininumOpacity = value;
        }
      }
      public Real MaxinumOpacity {
        get {
          return this._maxinumOpacity;
        }
        set {
          this._maxinumOpacity = value;
        }
      }
      public Real RainStreakScale {
        get {
          return this._rainStreakScale;
        }
        set {
          this._rainStreakScale = value;
        }
      }
      public Real RainLineWidth {
        get {
          return this._rainLineWidth;
        }
        set {
          this._rainLineWidth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sprites.Read(reader);
        _viewBoxWidth.Read(reader);
        _viewBoxHeight.Read(reader);
        _viewBoxDepth.Read(reader);
        _exclusionRadius.Read(reader);
        _maxVelocity.Read(reader);
        _minMass.Read(reader);
        _maxMass.Read(reader);
        _minSize.Read(reader);
        _maxSize.Read(reader);
        _maximumNumberOfParticles.Read(reader);
        _initialVelocity.Read(reader);
        _bitmapAnimationSpeed.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _particleSystemData.Read(reader);
        _type.Read(reader);
        _unnamed2.Read(reader);
        _mininumOpacity.Read(reader);
        _maxinumOpacity.Read(reader);
        _rainStreakScale.Read(reader);
        _rainLineWidth.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _sprites.ReadString(reader);
        _resourceData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particleSystemData.Count); x = (x + 1)) {
          ParticleSystemData.Add(new ParticleSystemLiteDataBlockBlock());
          ParticleSystemData[x].Read(reader);
        }
        for (x = 0; (x < _particleSystemData.Count); x = (x + 1)) {
          ParticleSystemData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _sprites.Write(bw);
        _viewBoxWidth.Write(bw);
        _viewBoxHeight.Write(bw);
        _viewBoxDepth.Write(bw);
        _exclusionRadius.Write(bw);
        _maxVelocity.Write(bw);
        _minMass.Write(bw);
        _maxMass.Write(bw);
        _minSize.Write(bw);
        _maxSize.Write(bw);
        _maximumNumberOfParticles.Write(bw);
        _initialVelocity.Write(bw);
        _bitmapAnimationSpeed.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_particleSystemData.Count = ParticleSystemData.Count;
        _particleSystemData.Write(bw);
        _type.Write(bw);
        _unnamed2.Write(bw);
        _mininumOpacity.Write(bw);
        _maxinumOpacity.Write(bw);
        _rainStreakScale.Write(bw);
        _rainLineWidth.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _sprites.WriteString(writer);
        _resourceData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particleSystemData.Count); x = (x + 1)) {
          ParticleSystemData[x].Write(writer);
        }
        for (x = 0; (x < _particleSystemData.Count); x = (x + 1)) {
          ParticleSystemData[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalGeometryBlockResourceBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private ShortInteger _primaryLocator = new ShortInteger();
      private ShortInteger _secondaryLocator = new ShortInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private LongInteger _resourceDataOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryBlockResourceBlockBlock() {
        this._type = new Enum(1);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger PrimaryLocator {
        get {
          return this._primaryLocator;
        }
        set {
          this._primaryLocator = value;
        }
      }
      public ShortInteger SecondaryLocator {
        get {
          return this._secondaryLocator;
        }
        set {
          this._secondaryLocator = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public LongInteger ResourceDataOffset {
        get {
          return this._resourceDataOffset;
        }
        set {
          this._resourceDataOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _primaryLocator.Read(reader);
        _secondaryLocator.Read(reader);
        _resourceDataSize.Read(reader);
        _resourceDataOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _primaryLocator.Write(bw);
        _secondaryLocator.Write(bw);
        _resourceDataSize.Write(bw);
        _resourceDataOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ParticleSystemLiteDataBlockBlock : IBlock {
      private Block _particlesRenderData = new Block();
      private Block _particlesOtherData = new Block();
      private Pad _unnamed0;
      public BlockCollection<ParticlesRenderDataBlockBlock> _particlesRenderDataList = new BlockCollection<ParticlesRenderDataBlockBlock>();
      public BlockCollection<ParticlesUpdateDataBlockBlock> _particlesOtherDataList = new BlockCollection<ParticlesUpdateDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemLiteDataBlockBlock() {
        this._unnamed0 = new Pad(32);
      }
      public BlockCollection<ParticlesRenderDataBlockBlock> ParticlesRenderData {
        get {
          return this._particlesRenderDataList;
        }
      }
      public BlockCollection<ParticlesUpdateDataBlockBlock> ParticlesOtherData {
        get {
          return this._particlesOtherDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ParticlesRenderData.BlockCount; x++)
{
  IBlock block = ParticlesRenderData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParticlesOtherData.BlockCount; x++)
{
  IBlock block = ParticlesOtherData.GetBlock(x);
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
        _particlesRenderData.Read(reader);
        _particlesOtherData.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _particlesRenderData.Count); x = (x + 1)) {
          ParticlesRenderData.Add(new ParticlesRenderDataBlockBlock());
          ParticlesRenderData[x].Read(reader);
        }
        for (x = 0; (x < _particlesRenderData.Count); x = (x + 1)) {
          ParticlesRenderData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particlesOtherData.Count); x = (x + 1)) {
          ParticlesOtherData.Add(new ParticlesUpdateDataBlockBlock());
          ParticlesOtherData[x].Read(reader);
        }
        for (x = 0; (x < _particlesOtherData.Count); x = (x + 1)) {
          ParticlesOtherData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_particlesRenderData.Count = ParticlesRenderData.Count;
        _particlesRenderData.Write(bw);
_particlesOtherData.Count = ParticlesOtherData.Count;
        _particlesOtherData.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _particlesRenderData.Count); x = (x + 1)) {
          ParticlesRenderData[x].Write(writer);
        }
        for (x = 0; (x < _particlesRenderData.Count); x = (x + 1)) {
          ParticlesRenderData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particlesOtherData.Count); x = (x + 1)) {
          ParticlesOtherData[x].Write(writer);
        }
        for (x = 0; (x < _particlesOtherData.Count); x = (x + 1)) {
          ParticlesOtherData[x].WriteChildData(writer);
        }
      }
    }
    public class ParticlesRenderDataBlockBlock : IBlock {
      private Real _positionx = new Real();
      private Real _positiony = new Real();
      private Real _positionz = new Real();
      private Real _size = new Real();
      private RGBColor _color = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public ParticlesRenderDataBlockBlock() {
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
      public Real Positionx {
        get {
          return this._positionx;
        }
        set {
          this._positionx = value;
        }
      }
      public Real Positiony {
        get {
          return this._positiony;
        }
        set {
          this._positiony = value;
        }
      }
      public Real Positionz {
        get {
          return this._positionz;
        }
        set {
          this._positionz = value;
        }
      }
      public Real Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public RGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _positionx.Read(reader);
        _positiony.Read(reader);
        _positionz.Read(reader);
        _size.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _positionx.Write(bw);
        _positiony.Write(bw);
        _positionz.Write(bw);
        _size.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ParticlesUpdateDataBlockBlock : IBlock {
      private Real _velocityx = new Real();
      private Real _velocityy = new Real();
      private Real _velocityz = new Real();
      private Pad _unnamed0;
      private Real _mass = new Real();
      private Real _creationTimeStamp = new Real();
public event System.EventHandler BlockNameChanged;
      public ParticlesUpdateDataBlockBlock() {
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
      public Real Velocityx {
        get {
          return this._velocityx;
        }
        set {
          this._velocityx = value;
        }
      }
      public Real Velocityy {
        get {
          return this._velocityy;
        }
        set {
          this._velocityy = value;
        }
      }
      public Real Velocityz {
        get {
          return this._velocityz;
        }
        set {
          this._velocityz = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public Real CreationTimeStamp {
        get {
          return this._creationTimeStamp;
        }
        set {
          this._creationTimeStamp = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _velocityx.Read(reader);
        _velocityy.Read(reader);
        _velocityz.Read(reader);
        _unnamed0.Read(reader);
        _mass.Read(reader);
        _creationTimeStamp.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _velocityx.Write(bw);
        _velocityy.Write(bw);
        _velocityz.Write(bw);
        _unnamed0.Write(bw);
        _mass.Write(bw);
        _creationTimeStamp.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalWeatherBackgroundPlateBlockBlock : IBlock {
      private TagReference _texture0 = new TagReference();
      private TagReference _texture1 = new TagReference();
      private TagReference _texture2 = new TagReference();
      private Real _platePositions0 = new Real();
      private Real _platePositions1 = new Real();
      private Real _platePositions2 = new Real();
      private RealVector3D _moveSpeed0 = new RealVector3D();
      private RealVector3D _moveSpeed1 = new RealVector3D();
      private RealVector3D _moveSpeed2 = new RealVector3D();
      private Real _textureScale0 = new Real();
      private Real _textureScale1 = new Real();
      private Real _textureScale2 = new Real();
      private RealVector3D _jitter0 = new RealVector3D();
      private RealVector3D _jitter1 = new RealVector3D();
      private RealVector3D _jitter2 = new RealVector3D();
      private Real _plateZNear = new Real();
      private Real _plateZFar = new Real();
      private Real _depthBlendZNear = new Real();
      private Real _depthBlendZFar = new Real();
      private Real _opacity0 = new Real();
      private Real _opacity1 = new Real();
      private Real _opacity2 = new Real();
      private Flags _flags;
      private RealRGBColor _tintColor0 = new RealRGBColor();
      private RealRGBColor _tintColor1 = new RealRGBColor();
      private RealRGBColor _tintColor2 = new RealRGBColor();
      private Real _mass1 = new Real();
      private Real _mass2 = new Real();
      private Real _mass3 = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GlobalWeatherBackgroundPlateBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(736);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_texture0.Value);
references.Add(_texture1.Value);
references.Add(_texture2.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Texture0 {
        get {
          return this._texture0;
        }
        set {
          this._texture0 = value;
        }
      }
      public TagReference Texture1 {
        get {
          return this._texture1;
        }
        set {
          this._texture1 = value;
        }
      }
      public TagReference Texture2 {
        get {
          return this._texture2;
        }
        set {
          this._texture2 = value;
        }
      }
      public Real PlatePositions0 {
        get {
          return this._platePositions0;
        }
        set {
          this._platePositions0 = value;
        }
      }
      public Real PlatePositions1 {
        get {
          return this._platePositions1;
        }
        set {
          this._platePositions1 = value;
        }
      }
      public Real PlatePositions2 {
        get {
          return this._platePositions2;
        }
        set {
          this._platePositions2 = value;
        }
      }
      public RealVector3D MoveSpeed0 {
        get {
          return this._moveSpeed0;
        }
        set {
          this._moveSpeed0 = value;
        }
      }
      public RealVector3D MoveSpeed1 {
        get {
          return this._moveSpeed1;
        }
        set {
          this._moveSpeed1 = value;
        }
      }
      public RealVector3D MoveSpeed2 {
        get {
          return this._moveSpeed2;
        }
        set {
          this._moveSpeed2 = value;
        }
      }
      public Real TextureScale0 {
        get {
          return this._textureScale0;
        }
        set {
          this._textureScale0 = value;
        }
      }
      public Real TextureScale1 {
        get {
          return this._textureScale1;
        }
        set {
          this._textureScale1 = value;
        }
      }
      public Real TextureScale2 {
        get {
          return this._textureScale2;
        }
        set {
          this._textureScale2 = value;
        }
      }
      public RealVector3D Jitter0 {
        get {
          return this._jitter0;
        }
        set {
          this._jitter0 = value;
        }
      }
      public RealVector3D Jitter1 {
        get {
          return this._jitter1;
        }
        set {
          this._jitter1 = value;
        }
      }
      public RealVector3D Jitter2 {
        get {
          return this._jitter2;
        }
        set {
          this._jitter2 = value;
        }
      }
      public Real PlateZNear {
        get {
          return this._plateZNear;
        }
        set {
          this._plateZNear = value;
        }
      }
      public Real PlateZFar {
        get {
          return this._plateZFar;
        }
        set {
          this._plateZFar = value;
        }
      }
      public Real DepthBlendZNear {
        get {
          return this._depthBlendZNear;
        }
        set {
          this._depthBlendZNear = value;
        }
      }
      public Real DepthBlendZFar {
        get {
          return this._depthBlendZFar;
        }
        set {
          this._depthBlendZFar = value;
        }
      }
      public Real Opacity0 {
        get {
          return this._opacity0;
        }
        set {
          this._opacity0 = value;
        }
      }
      public Real Opacity1 {
        get {
          return this._opacity1;
        }
        set {
          this._opacity1 = value;
        }
      }
      public Real Opacity2 {
        get {
          return this._opacity2;
        }
        set {
          this._opacity2 = value;
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
      public RealRGBColor TintColor0 {
        get {
          return this._tintColor0;
        }
        set {
          this._tintColor0 = value;
        }
      }
      public RealRGBColor TintColor1 {
        get {
          return this._tintColor1;
        }
        set {
          this._tintColor1 = value;
        }
      }
      public RealRGBColor TintColor2 {
        get {
          return this._tintColor2;
        }
        set {
          this._tintColor2 = value;
        }
      }
      public Real Mass1 {
        get {
          return this._mass1;
        }
        set {
          this._mass1 = value;
        }
      }
      public Real Mass2 {
        get {
          return this._mass2;
        }
        set {
          this._mass2 = value;
        }
      }
      public Real Mass3 {
        get {
          return this._mass3;
        }
        set {
          this._mass3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _texture0.Read(reader);
        _texture1.Read(reader);
        _texture2.Read(reader);
        _platePositions0.Read(reader);
        _platePositions1.Read(reader);
        _platePositions2.Read(reader);
        _moveSpeed0.Read(reader);
        _moveSpeed1.Read(reader);
        _moveSpeed2.Read(reader);
        _textureScale0.Read(reader);
        _textureScale1.Read(reader);
        _textureScale2.Read(reader);
        _jitter0.Read(reader);
        _jitter1.Read(reader);
        _jitter2.Read(reader);
        _plateZNear.Read(reader);
        _plateZFar.Read(reader);
        _depthBlendZNear.Read(reader);
        _depthBlendZFar.Read(reader);
        _opacity0.Read(reader);
        _opacity1.Read(reader);
        _opacity2.Read(reader);
        _flags.Read(reader);
        _tintColor0.Read(reader);
        _tintColor1.Read(reader);
        _tintColor2.Read(reader);
        _mass1.Read(reader);
        _mass2.Read(reader);
        _mass3.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _texture0.ReadString(reader);
        _texture1.ReadString(reader);
        _texture2.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _texture0.Write(bw);
        _texture1.Write(bw);
        _texture2.Write(bw);
        _platePositions0.Write(bw);
        _platePositions1.Write(bw);
        _platePositions2.Write(bw);
        _moveSpeed0.Write(bw);
        _moveSpeed1.Write(bw);
        _moveSpeed2.Write(bw);
        _textureScale0.Write(bw);
        _textureScale1.Write(bw);
        _textureScale2.Write(bw);
        _jitter0.Write(bw);
        _jitter1.Write(bw);
        _jitter2.Write(bw);
        _plateZNear.Write(bw);
        _plateZFar.Write(bw);
        _depthBlendZNear.Write(bw);
        _depthBlendZFar.Write(bw);
        _opacity0.Write(bw);
        _opacity1.Write(bw);
        _opacity2.Write(bw);
        _flags.Write(bw);
        _tintColor0.Write(bw);
        _tintColor1.Write(bw);
        _tintColor2.Write(bw);
        _mass1.Write(bw);
        _mass2.Write(bw);
        _mass3.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _texture0.WriteString(writer);
        _texture1.WriteString(writer);
        _texture2.WriteString(writer);
      }
    }
    public class GloalWindPrimitivesBlockBlock : IBlock {
      private RealVector3D _position = new RealVector3D();
      private Real _radius = new Real();
      private Real _strength = new Real();
      private Enum _windPrimitiveType;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GloalWindPrimitivesBlockBlock() {
        this._windPrimitiveType = new Enum(2);
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
      public RealVector3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
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
      public Real Strength {
        get {
          return this._strength;
        }
        set {
          this._strength = value;
        }
      }
      public Enum WindPrimitiveType {
        get {
          return this._windPrimitiveType;
        }
        set {
          this._windPrimitiveType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _radius.Read(reader);
        _strength.Read(reader);
        _windPrimitiveType.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _radius.Write(bw);
        _strength.Write(bw);
        _windPrimitiveType.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
