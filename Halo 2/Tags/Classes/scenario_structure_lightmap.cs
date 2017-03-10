// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'scenario_structure_lightmap'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class scenario_structure_lightmap : Interfaces.Pool.Tag {
    private ScenarioStructureLightmapBlockBlock scenarioStructureLightmapValues = new ScenarioStructureLightmapBlockBlock();
    public virtual ScenarioStructureLightmapBlockBlock ScenarioStructureLightmapValues {
      get {
        return scenarioStructureLightmapValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ScenarioStructureLightmapValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "scenario_structure_lightmap";
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
scenarioStructureLightmapValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
scenarioStructureLightmapValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
scenarioStructureLightmapValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
scenarioStructureLightmapValues.WriteChildData(writer);
    }
    #endregion
    public class ScenarioStructureLightmapBlockBlock : IBlock {
      private Real _searchDistanceLowerBound = new Real();
      private Real _searchDistanceUpperBound = new Real();
      private Real _luminelsPerWorldUnit = new Real();
      private Real _outputWhiteReference = new Real();
      private Real _outputBlackReference = new Real();
      private Real _outputSchlickParameter = new Real();
      private Real _diffuseMapScale = new Real();
      private Real _sunScale = new Real();
      private Real _skyScale = new Real();
      private Real _indirectScale = new Real();
      private Real _prtScale = new Real();
      private Real _surfaceLightScale = new Real();
      private Real _scenarioLightScale = new Real();
      private Real _lightprobeInterpolationOveride = new Real();
      private Pad _unnamed0;
      private Block _lightmapGroups = new Block();
      private Pad _unnamed1;
      private Block _errors = new Block();
      private Pad _unnamed2;
      public BlockCollection<StructureLightmapGroupBlockBlock> _lightmapGroupsList = new BlockCollection<StructureLightmapGroupBlockBlock>();
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> _errorsList = new BlockCollection<GlobalErrorReportCategoriesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioStructureLightmapBlockBlock() {
        this._unnamed0 = new Pad(72);
        this._unnamed1 = new Pad(12);
        this._unnamed2 = new Pad(104);
      }
      public BlockCollection<StructureLightmapGroupBlockBlock> LightmapGroups {
        get {
          return this._lightmapGroupsList;
        }
      }
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<LightmapGroups.BlockCount; x++)
{
  IBlock block = LightmapGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
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
      public Real SearchDistanceLowerBound {
        get {
          return this._searchDistanceLowerBound;
        }
        set {
          this._searchDistanceLowerBound = value;
        }
      }
      public Real SearchDistanceUpperBound {
        get {
          return this._searchDistanceUpperBound;
        }
        set {
          this._searchDistanceUpperBound = value;
        }
      }
      public Real LuminelsPerWorldUnit {
        get {
          return this._luminelsPerWorldUnit;
        }
        set {
          this._luminelsPerWorldUnit = value;
        }
      }
      public Real OutputWhiteReference {
        get {
          return this._outputWhiteReference;
        }
        set {
          this._outputWhiteReference = value;
        }
      }
      public Real OutputBlackReference {
        get {
          return this._outputBlackReference;
        }
        set {
          this._outputBlackReference = value;
        }
      }
      public Real OutputSchlickParameter {
        get {
          return this._outputSchlickParameter;
        }
        set {
          this._outputSchlickParameter = value;
        }
      }
      public Real DiffuseMapScale {
        get {
          return this._diffuseMapScale;
        }
        set {
          this._diffuseMapScale = value;
        }
      }
      public Real SunScale {
        get {
          return this._sunScale;
        }
        set {
          this._sunScale = value;
        }
      }
      public Real SkyScale {
        get {
          return this._skyScale;
        }
        set {
          this._skyScale = value;
        }
      }
      public Real IndirectScale {
        get {
          return this._indirectScale;
        }
        set {
          this._indirectScale = value;
        }
      }
      public Real PrtScale {
        get {
          return this._prtScale;
        }
        set {
          this._prtScale = value;
        }
      }
      public Real SurfaceLightScale {
        get {
          return this._surfaceLightScale;
        }
        set {
          this._surfaceLightScale = value;
        }
      }
      public Real ScenarioLightScale {
        get {
          return this._scenarioLightScale;
        }
        set {
          this._scenarioLightScale = value;
        }
      }
      public Real LightprobeInterpolationOveride {
        get {
          return this._lightprobeInterpolationOveride;
        }
        set {
          this._lightprobeInterpolationOveride = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _searchDistanceLowerBound.Read(reader);
        _searchDistanceUpperBound.Read(reader);
        _luminelsPerWorldUnit.Read(reader);
        _outputWhiteReference.Read(reader);
        _outputBlackReference.Read(reader);
        _outputSchlickParameter.Read(reader);
        _diffuseMapScale.Read(reader);
        _sunScale.Read(reader);
        _skyScale.Read(reader);
        _indirectScale.Read(reader);
        _prtScale.Read(reader);
        _surfaceLightScale.Read(reader);
        _scenarioLightScale.Read(reader);
        _lightprobeInterpolationOveride.Read(reader);
        _unnamed0.Read(reader);
        _lightmapGroups.Read(reader);
        _unnamed1.Read(reader);
        _errors.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lightmapGroups.Count); x = (x + 1)) {
          LightmapGroups.Add(new StructureLightmapGroupBlockBlock());
          LightmapGroups[x].Read(reader);
        }
        for (x = 0; (x < _lightmapGroups.Count); x = (x + 1)) {
          LightmapGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new GlobalErrorReportCategoriesBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _searchDistanceLowerBound.Write(bw);
        _searchDistanceUpperBound.Write(bw);
        _luminelsPerWorldUnit.Write(bw);
        _outputWhiteReference.Write(bw);
        _outputBlackReference.Write(bw);
        _outputSchlickParameter.Write(bw);
        _diffuseMapScale.Write(bw);
        _sunScale.Write(bw);
        _skyScale.Write(bw);
        _indirectScale.Write(bw);
        _prtScale.Write(bw);
        _surfaceLightScale.Write(bw);
        _scenarioLightScale.Write(bw);
        _lightprobeInterpolationOveride.Write(bw);
        _unnamed0.Write(bw);
_lightmapGroups.Count = LightmapGroups.Count;
        _lightmapGroups.Write(bw);
        _unnamed1.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lightmapGroups.Count); x = (x + 1)) {
          LightmapGroups[x].Write(writer);
        }
        for (x = 0; (x < _lightmapGroups.Count); x = (x + 1)) {
          LightmapGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
      }
    }
    public class StructureLightmapGroupBlockBlock : IBlock {
      private Enum _type;
      private Flags _flags;
      private LongInteger _structureChecksum = new LongInteger();
      private Block _sectionPalette = new Block();
      private Block _writablePalettes = new Block();
      private TagReference _bitmapGroup = new TagReference();
      private Block _clusters = new Block();
      private Block _clusterRenderInfo = new Block();
      private Block _poopDefinitions = new Block();
      private Block _lightingEnvironments = new Block();
      private Block _geometryBuckets = new Block();
      private Block _instanceRenderInfo = new Block();
      private Block _instanceBucketRefs = new Block();
      private Block _sceneryObjectInfo = new Block();
      private Block _sceneryObjectBucketRefs = new Block();
      public BlockCollection<StructureLightmapPaletteColorBlockBlock> _sectionPaletteList = new BlockCollection<StructureLightmapPaletteColorBlockBlock>();
      public BlockCollection<StructureLightmapPaletteColorBlockBlock> _writablePalettesList = new BlockCollection<StructureLightmapPaletteColorBlockBlock>();
      public BlockCollection<LightmapGeometrySectionBlockBlock> _clustersList = new BlockCollection<LightmapGeometrySectionBlockBlock>();
      public BlockCollection<LightmapGeometryRenderInfoBlockBlock> _clusterRenderInfoList = new BlockCollection<LightmapGeometryRenderInfoBlockBlock>();
      public BlockCollection<LightmapGeometrySectionBlockBlock> _poopDefinitionsList = new BlockCollection<LightmapGeometrySectionBlockBlock>();
      public BlockCollection<StructureLightmapLightingEnvironmentBlockBlock> _lightingEnvironmentsList = new BlockCollection<StructureLightmapLightingEnvironmentBlockBlock>();
      public BlockCollection<LightmapVertexBufferBucketBlockBlock> _geometryBucketsList = new BlockCollection<LightmapVertexBufferBucketBlockBlock>();
      public BlockCollection<LightmapGeometryRenderInfoBlockBlock> _instanceRenderInfoList = new BlockCollection<LightmapGeometryRenderInfoBlockBlock>();
      public BlockCollection<LightmapInstanceBucketReferenceBlockBlock> _instanceBucketRefsList = new BlockCollection<LightmapInstanceBucketReferenceBlockBlock>();
      public BlockCollection<LightmapSceneryObjectInfoBlockBlock> _sceneryObjectInfoList = new BlockCollection<LightmapSceneryObjectInfoBlockBlock>();
      public BlockCollection<LightmapInstanceBucketReferenceBlockBlock> _sceneryObjectBucketRefsList = new BlockCollection<LightmapInstanceBucketReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureLightmapGroupBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
      }
      public BlockCollection<StructureLightmapPaletteColorBlockBlock> SectionPalette {
        get {
          return this._sectionPaletteList;
        }
      }
      public BlockCollection<StructureLightmapPaletteColorBlockBlock> WritablePalettes {
        get {
          return this._writablePalettesList;
        }
      }
      public BlockCollection<LightmapGeometrySectionBlockBlock> Clusters {
        get {
          return this._clustersList;
        }
      }
      public BlockCollection<LightmapGeometryRenderInfoBlockBlock> ClusterRenderInfo {
        get {
          return this._clusterRenderInfoList;
        }
      }
      public BlockCollection<LightmapGeometrySectionBlockBlock> PoopDefinitions {
        get {
          return this._poopDefinitionsList;
        }
      }
      public BlockCollection<StructureLightmapLightingEnvironmentBlockBlock> LightingEnvironments {
        get {
          return this._lightingEnvironmentsList;
        }
      }
      public BlockCollection<LightmapVertexBufferBucketBlockBlock> GeometryBuckets {
        get {
          return this._geometryBucketsList;
        }
      }
      public BlockCollection<LightmapGeometryRenderInfoBlockBlock> InstanceRenderInfo {
        get {
          return this._instanceRenderInfoList;
        }
      }
      public BlockCollection<LightmapInstanceBucketReferenceBlockBlock> InstanceBucketRefs {
        get {
          return this._instanceBucketRefsList;
        }
      }
      public BlockCollection<LightmapSceneryObjectInfoBlockBlock> SceneryObjectInfo {
        get {
          return this._sceneryObjectInfoList;
        }
      }
      public BlockCollection<LightmapInstanceBucketReferenceBlockBlock> SceneryObjectBucketRefs {
        get {
          return this._sceneryObjectBucketRefsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmapGroup.Value);
for (int x=0; x<SectionPalette.BlockCount; x++)
{
  IBlock block = SectionPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WritablePalettes.BlockCount; x++)
{
  IBlock block = WritablePalettes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Clusters.BlockCount; x++)
{
  IBlock block = Clusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterRenderInfo.BlockCount; x++)
{
  IBlock block = ClusterRenderInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PoopDefinitions.BlockCount; x++)
{
  IBlock block = PoopDefinitions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LightingEnvironments.BlockCount; x++)
{
  IBlock block = LightingEnvironments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GeometryBuckets.BlockCount; x++)
{
  IBlock block = GeometryBuckets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstanceRenderInfo.BlockCount; x++)
{
  IBlock block = InstanceRenderInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstanceBucketRefs.BlockCount; x++)
{
  IBlock block = InstanceBucketRefs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SceneryObjectInfo.BlockCount; x++)
{
  IBlock block = SceneryObjectInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SceneryObjectBucketRefs.BlockCount; x++)
{
  IBlock block = SceneryObjectBucketRefs.GetBlock(x);
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
      public LongInteger StructureChecksum {
        get {
          return this._structureChecksum;
        }
        set {
          this._structureChecksum = value;
        }
      }
      public TagReference BitmapGroup {
        get {
          return this._bitmapGroup;
        }
        set {
          this._bitmapGroup = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _structureChecksum.Read(reader);
        _sectionPalette.Read(reader);
        _writablePalettes.Read(reader);
        _bitmapGroup.Read(reader);
        _clusters.Read(reader);
        _clusterRenderInfo.Read(reader);
        _poopDefinitions.Read(reader);
        _lightingEnvironments.Read(reader);
        _geometryBuckets.Read(reader);
        _instanceRenderInfo.Read(reader);
        _instanceBucketRefs.Read(reader);
        _sceneryObjectInfo.Read(reader);
        _sceneryObjectBucketRefs.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sectionPalette.Count); x = (x + 1)) {
          SectionPalette.Add(new StructureLightmapPaletteColorBlockBlock());
          SectionPalette[x].Read(reader);
        }
        for (x = 0; (x < _sectionPalette.Count); x = (x + 1)) {
          SectionPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _writablePalettes.Count); x = (x + 1)) {
          WritablePalettes.Add(new StructureLightmapPaletteColorBlockBlock());
          WritablePalettes[x].Read(reader);
        }
        for (x = 0; (x < _writablePalettes.Count); x = (x + 1)) {
          WritablePalettes[x].ReadChildData(reader);
        }
        _bitmapGroup.ReadString(reader);
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters.Add(new LightmapGeometrySectionBlockBlock());
          Clusters[x].Read(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusterRenderInfo.Count); x = (x + 1)) {
          ClusterRenderInfo.Add(new LightmapGeometryRenderInfoBlockBlock());
          ClusterRenderInfo[x].Read(reader);
        }
        for (x = 0; (x < _clusterRenderInfo.Count); x = (x + 1)) {
          ClusterRenderInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _poopDefinitions.Count); x = (x + 1)) {
          PoopDefinitions.Add(new LightmapGeometrySectionBlockBlock());
          PoopDefinitions[x].Read(reader);
        }
        for (x = 0; (x < _poopDefinitions.Count); x = (x + 1)) {
          PoopDefinitions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightingEnvironments.Count); x = (x + 1)) {
          LightingEnvironments.Add(new StructureLightmapLightingEnvironmentBlockBlock());
          LightingEnvironments[x].Read(reader);
        }
        for (x = 0; (x < _lightingEnvironments.Count); x = (x + 1)) {
          LightingEnvironments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _geometryBuckets.Count); x = (x + 1)) {
          GeometryBuckets.Add(new LightmapVertexBufferBucketBlockBlock());
          GeometryBuckets[x].Read(reader);
        }
        for (x = 0; (x < _geometryBuckets.Count); x = (x + 1)) {
          GeometryBuckets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instanceRenderInfo.Count); x = (x + 1)) {
          InstanceRenderInfo.Add(new LightmapGeometryRenderInfoBlockBlock());
          InstanceRenderInfo[x].Read(reader);
        }
        for (x = 0; (x < _instanceRenderInfo.Count); x = (x + 1)) {
          InstanceRenderInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instanceBucketRefs.Count); x = (x + 1)) {
          InstanceBucketRefs.Add(new LightmapInstanceBucketReferenceBlockBlock());
          InstanceBucketRefs[x].Read(reader);
        }
        for (x = 0; (x < _instanceBucketRefs.Count); x = (x + 1)) {
          InstanceBucketRefs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sceneryObjectInfo.Count); x = (x + 1)) {
          SceneryObjectInfo.Add(new LightmapSceneryObjectInfoBlockBlock());
          SceneryObjectInfo[x].Read(reader);
        }
        for (x = 0; (x < _sceneryObjectInfo.Count); x = (x + 1)) {
          SceneryObjectInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sceneryObjectBucketRefs.Count); x = (x + 1)) {
          SceneryObjectBucketRefs.Add(new LightmapInstanceBucketReferenceBlockBlock());
          SceneryObjectBucketRefs[x].Read(reader);
        }
        for (x = 0; (x < _sceneryObjectBucketRefs.Count); x = (x + 1)) {
          SceneryObjectBucketRefs[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _structureChecksum.Write(bw);
_sectionPalette.Count = SectionPalette.Count;
        _sectionPalette.Write(bw);
_writablePalettes.Count = WritablePalettes.Count;
        _writablePalettes.Write(bw);
        _bitmapGroup.Write(bw);
_clusters.Count = Clusters.Count;
        _clusters.Write(bw);
_clusterRenderInfo.Count = ClusterRenderInfo.Count;
        _clusterRenderInfo.Write(bw);
_poopDefinitions.Count = PoopDefinitions.Count;
        _poopDefinitions.Write(bw);
_lightingEnvironments.Count = LightingEnvironments.Count;
        _lightingEnvironments.Write(bw);
_geometryBuckets.Count = GeometryBuckets.Count;
        _geometryBuckets.Write(bw);
_instanceRenderInfo.Count = InstanceRenderInfo.Count;
        _instanceRenderInfo.Write(bw);
_instanceBucketRefs.Count = InstanceBucketRefs.Count;
        _instanceBucketRefs.Write(bw);
_sceneryObjectInfo.Count = SceneryObjectInfo.Count;
        _sceneryObjectInfo.Write(bw);
_sceneryObjectBucketRefs.Count = SceneryObjectBucketRefs.Count;
        _sceneryObjectBucketRefs.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sectionPalette.Count); x = (x + 1)) {
          SectionPalette[x].Write(writer);
        }
        for (x = 0; (x < _sectionPalette.Count); x = (x + 1)) {
          SectionPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _writablePalettes.Count); x = (x + 1)) {
          WritablePalettes[x].Write(writer);
        }
        for (x = 0; (x < _writablePalettes.Count); x = (x + 1)) {
          WritablePalettes[x].WriteChildData(writer);
        }
        _bitmapGroup.WriteString(writer);
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].Write(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusterRenderInfo.Count); x = (x + 1)) {
          ClusterRenderInfo[x].Write(writer);
        }
        for (x = 0; (x < _clusterRenderInfo.Count); x = (x + 1)) {
          ClusterRenderInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _poopDefinitions.Count); x = (x + 1)) {
          PoopDefinitions[x].Write(writer);
        }
        for (x = 0; (x < _poopDefinitions.Count); x = (x + 1)) {
          PoopDefinitions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightingEnvironments.Count); x = (x + 1)) {
          LightingEnvironments[x].Write(writer);
        }
        for (x = 0; (x < _lightingEnvironments.Count); x = (x + 1)) {
          LightingEnvironments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _geometryBuckets.Count); x = (x + 1)) {
          GeometryBuckets[x].Write(writer);
        }
        for (x = 0; (x < _geometryBuckets.Count); x = (x + 1)) {
          GeometryBuckets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instanceRenderInfo.Count); x = (x + 1)) {
          InstanceRenderInfo[x].Write(writer);
        }
        for (x = 0; (x < _instanceRenderInfo.Count); x = (x + 1)) {
          InstanceRenderInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instanceBucketRefs.Count); x = (x + 1)) {
          InstanceBucketRefs[x].Write(writer);
        }
        for (x = 0; (x < _instanceBucketRefs.Count); x = (x + 1)) {
          InstanceBucketRefs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sceneryObjectInfo.Count); x = (x + 1)) {
          SceneryObjectInfo[x].Write(writer);
        }
        for (x = 0; (x < _sceneryObjectInfo.Count); x = (x + 1)) {
          SceneryObjectInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sceneryObjectBucketRefs.Count); x = (x + 1)) {
          SceneryObjectBucketRefs[x].Write(writer);
        }
        for (x = 0; (x < _sceneryObjectBucketRefs.Count); x = (x + 1)) {
          SceneryObjectBucketRefs[x].WriteChildData(writer);
        }
      }
    }
    public class StructureLightmapPaletteColorBlockBlock : IBlock {
      private LongInteger _fIRSTPaletteColor = new LongInteger();
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureLightmapPaletteColorBlockBlock() {
        this._unnamed0 = new Skip(1020);
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
      public LongInteger FIRSTPaletteColor {
        get {
          return this._fIRSTPaletteColor;
        }
        set {
          this._fIRSTPaletteColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fIRSTPaletteColor.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _fIRSTPaletteColor.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightmapGeometrySectionBlockBlock : IBlock {
      private ShortInteger _totalVertexCount = new ShortInteger();
      private ShortInteger _totalTriangleCount = new ShortInteger();
      private ShortInteger _totalPartCount = new ShortInteger();
      private ShortInteger _shadow_MinusCastingTriangleCount = new ShortInteger();
      private ShortInteger _shadow_MinusCastingPartCount = new ShortInteger();
      private ShortInteger _opaquePointCount = new ShortInteger();
      private ShortInteger _opaqueVertexCount = new ShortInteger();
      private ShortInteger _opaquePartCount = new ShortInteger();
      private CharInteger _opaqueMaxNodesVertex = new CharInteger();
      private CharInteger _transparentMaxNodesVertex = new CharInteger();
      private ShortInteger _shadow_MinusCastingRigidTriangleCount = new ShortInteger();
      private Enum _geometryClassification;
      private Flags _geometryCompressionFlags;
      private Block _unnamed0 = new Block();
      private CharInteger _hardwareNodeCount = new CharInteger();
      private CharInteger _nodeMapSize = new CharInteger();
      private ShortInteger _softwarePlaneCount = new ShortInteger();
      private ShortInteger _totalSubpartcont = new ShortInteger();
      private Flags _sectionLightingFlags;
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Block _cacheData = new Block();
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> _unnamed0List = new BlockCollection<GlobalGeometryCompressionInfoBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<LightmapGeometrySectionCacheDataBlockBlock> _cacheDataList = new BlockCollection<LightmapGeometrySectionCacheDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightmapGeometrySectionBlockBlock() {
        this._geometryClassification = new Enum(2);
        this._geometryCompressionFlags = new Flags(2);
        this._sectionLightingFlags = new Flags(2);
        this._geometrySelfReference = new Skip(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public BlockCollection<LightmapGeometrySectionCacheDataBlockBlock> CacheData {
        get {
          return this._cacheDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CacheData.BlockCount; x++)
{
  IBlock block = CacheData.GetBlock(x);
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
      public ShortInteger TotalVertexCount {
        get {
          return this._totalVertexCount;
        }
        set {
          this._totalVertexCount = value;
        }
      }
      public ShortInteger TotalTriangleCount {
        get {
          return this._totalTriangleCount;
        }
        set {
          this._totalTriangleCount = value;
        }
      }
      public ShortInteger TotalPartCount {
        get {
          return this._totalPartCount;
        }
        set {
          this._totalPartCount = value;
        }
      }
      public ShortInteger Shadow_MinusCastingTriangleCount {
        get {
          return this._shadow_MinusCastingTriangleCount;
        }
        set {
          this._shadow_MinusCastingTriangleCount = value;
        }
      }
      public ShortInteger Shadow_MinusCastingPartCount {
        get {
          return this._shadow_MinusCastingPartCount;
        }
        set {
          this._shadow_MinusCastingPartCount = value;
        }
      }
      public ShortInteger OpaquePointCount {
        get {
          return this._opaquePointCount;
        }
        set {
          this._opaquePointCount = value;
        }
      }
      public ShortInteger OpaqueVertexCount {
        get {
          return this._opaqueVertexCount;
        }
        set {
          this._opaqueVertexCount = value;
        }
      }
      public ShortInteger OpaquePartCount {
        get {
          return this._opaquePartCount;
        }
        set {
          this._opaquePartCount = value;
        }
      }
      public CharInteger OpaqueMaxNodesVertex {
        get {
          return this._opaqueMaxNodesVertex;
        }
        set {
          this._opaqueMaxNodesVertex = value;
        }
      }
      public CharInteger TransparentMaxNodesVertex {
        get {
          return this._transparentMaxNodesVertex;
        }
        set {
          this._transparentMaxNodesVertex = value;
        }
      }
      public ShortInteger Shadow_MinusCastingRigidTriangleCount {
        get {
          return this._shadow_MinusCastingRigidTriangleCount;
        }
        set {
          this._shadow_MinusCastingRigidTriangleCount = value;
        }
      }
      public Enum GeometryClassification {
        get {
          return this._geometryClassification;
        }
        set {
          this._geometryClassification = value;
        }
      }
      public Flags GeometryCompressionFlags {
        get {
          return this._geometryCompressionFlags;
        }
        set {
          this._geometryCompressionFlags = value;
        }
      }
      public CharInteger HardwareNodeCount {
        get {
          return this._hardwareNodeCount;
        }
        set {
          this._hardwareNodeCount = value;
        }
      }
      public CharInteger NodeMapSize {
        get {
          return this._nodeMapSize;
        }
        set {
          this._nodeMapSize = value;
        }
      }
      public ShortInteger SoftwarePlaneCount {
        get {
          return this._softwarePlaneCount;
        }
        set {
          this._softwarePlaneCount = value;
        }
      }
      public ShortInteger TotalSubpartcont {
        get {
          return this._totalSubpartcont;
        }
        set {
          this._totalSubpartcont = value;
        }
      }
      public Flags SectionLightingFlags {
        get {
          return this._sectionLightingFlags;
        }
        set {
          this._sectionLightingFlags = value;
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
      public virtual void Read(BinaryReader reader) {
        _totalVertexCount.Read(reader);
        _totalTriangleCount.Read(reader);
        _totalPartCount.Read(reader);
        _shadow_MinusCastingTriangleCount.Read(reader);
        _shadow_MinusCastingPartCount.Read(reader);
        _opaquePointCount.Read(reader);
        _opaqueVertexCount.Read(reader);
        _opaquePartCount.Read(reader);
        _opaqueMaxNodesVertex.Read(reader);
        _transparentMaxNodesVertex.Read(reader);
        _shadow_MinusCastingRigidTriangleCount.Read(reader);
        _geometryClassification.Read(reader);
        _geometryCompressionFlags.Read(reader);
        _unnamed0.Read(reader);
        _hardwareNodeCount.Read(reader);
        _nodeMapSize.Read(reader);
        _softwarePlaneCount.Read(reader);
        _totalSubpartcont.Read(reader);
        _sectionLightingFlags.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _cacheData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new GlobalGeometryCompressionInfoBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
        _resourceData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData.Add(new LightmapGeometrySectionCacheDataBlockBlock());
          CacheData[x].Read(reader);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _totalVertexCount.Write(bw);
        _totalTriangleCount.Write(bw);
        _totalPartCount.Write(bw);
        _shadow_MinusCastingTriangleCount.Write(bw);
        _shadow_MinusCastingPartCount.Write(bw);
        _opaquePointCount.Write(bw);
        _opaqueVertexCount.Write(bw);
        _opaquePartCount.Write(bw);
        _opaqueMaxNodesVertex.Write(bw);
        _transparentMaxNodesVertex.Write(bw);
        _shadow_MinusCastingRigidTriangleCount.Write(bw);
        _geometryClassification.Write(bw);
        _geometryCompressionFlags.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
        _hardwareNodeCount.Write(bw);
        _nodeMapSize.Write(bw);
        _softwarePlaneCount.Write(bw);
        _totalSubpartcont.Write(bw);
        _sectionLightingFlags.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_cacheData.Count = CacheData.Count;
        _cacheData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
        _resourceData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].Write(writer);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalGeometryCompressionInfoBlockBlock : IBlock {
      private RealBounds _positionBoundsX = new RealBounds();
      private RealBounds _positionBoundsY = new RealBounds();
      private RealBounds _positionBoundsZ = new RealBounds();
      private RealBounds _texcoordBoundsX = new RealBounds();
      private RealBounds _texcoordBoundsY = new RealBounds();
      private RealBounds _secondaryTexcoordBoundsX = new RealBounds();
      private RealBounds _secondaryTexcoordBoundsY = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryCompressionInfoBlockBlock() {
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
      public RealBounds PositionBoundsX {
        get {
          return this._positionBoundsX;
        }
        set {
          this._positionBoundsX = value;
        }
      }
      public RealBounds PositionBoundsY {
        get {
          return this._positionBoundsY;
        }
        set {
          this._positionBoundsY = value;
        }
      }
      public RealBounds PositionBoundsZ {
        get {
          return this._positionBoundsZ;
        }
        set {
          this._positionBoundsZ = value;
        }
      }
      public RealBounds TexcoordBoundsX {
        get {
          return this._texcoordBoundsX;
        }
        set {
          this._texcoordBoundsX = value;
        }
      }
      public RealBounds TexcoordBoundsY {
        get {
          return this._texcoordBoundsY;
        }
        set {
          this._texcoordBoundsY = value;
        }
      }
      public RealBounds SecondaryTexcoordBoundsX {
        get {
          return this._secondaryTexcoordBoundsX;
        }
        set {
          this._secondaryTexcoordBoundsX = value;
        }
      }
      public RealBounds SecondaryTexcoordBoundsY {
        get {
          return this._secondaryTexcoordBoundsY;
        }
        set {
          this._secondaryTexcoordBoundsY = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _positionBoundsX.Read(reader);
        _positionBoundsY.Read(reader);
        _positionBoundsZ.Read(reader);
        _texcoordBoundsX.Read(reader);
        _texcoordBoundsY.Read(reader);
        _secondaryTexcoordBoundsX.Read(reader);
        _secondaryTexcoordBoundsY.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _positionBoundsX.Write(bw);
        _positionBoundsY.Write(bw);
        _positionBoundsZ.Write(bw);
        _texcoordBoundsX.Write(bw);
        _texcoordBoundsY.Write(bw);
        _secondaryTexcoordBoundsX.Write(bw);
        _secondaryTexcoordBoundsY.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
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
    public class LightmapGeometrySectionCacheDataBlockBlock : IBlock {
      private Block _parts = new Block();
      private Block _subparts = new Block();
      private Block _visibilityBounds = new Block();
      private Block _rawVertices = new Block();
      private Block _stripIndices = new Block();
      private Data _visibilityMoppCode = new Data();
      private Block _moppReorderTable = new Block();
      private Block _vertexBuffers = new Block();
      private Pad _unnamed0;
      public BlockCollection<GlobalGeometryPartBlockNewBlock> _partsList = new BlockCollection<GlobalGeometryPartBlockNewBlock>();
      public BlockCollection<GlobalSubpartsBlockBlock> _subpartsList = new BlockCollection<GlobalSubpartsBlockBlock>();
      public BlockCollection<GlobalVisibilityBoundsBlockBlock> _visibilityBoundsList = new BlockCollection<GlobalVisibilityBoundsBlockBlock>();
      public BlockCollection<GlobalGeometrySectionRawVertexBlockBlock> _rawVerticesList = new BlockCollection<GlobalGeometrySectionRawVertexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _stripIndicesList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _moppReorderTableList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock> _vertexBuffersList = new BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightmapGeometrySectionCacheDataBlockBlock() {
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryPartBlockNewBlock> Parts {
        get {
          return this._partsList;
        }
      }
      public BlockCollection<GlobalSubpartsBlockBlock> Subparts {
        get {
          return this._subpartsList;
        }
      }
      public BlockCollection<GlobalVisibilityBoundsBlockBlock> VisibilityBounds {
        get {
          return this._visibilityBoundsList;
        }
      }
      public BlockCollection<GlobalGeometrySectionRawVertexBlockBlock> RawVertices {
        get {
          return this._rawVerticesList;
        }
      }
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> StripIndices {
        get {
          return this._stripIndicesList;
        }
      }
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> MoppReorderTable {
        get {
          return this._moppReorderTableList;
        }
      }
      public BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock> VertexBuffers {
        get {
          return this._vertexBuffersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Parts.BlockCount; x++)
{
  IBlock block = Parts.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Subparts.BlockCount; x++)
{
  IBlock block = Subparts.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VisibilityBounds.BlockCount; x++)
{
  IBlock block = VisibilityBounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RawVertices.BlockCount; x++)
{
  IBlock block = RawVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StripIndices.BlockCount; x++)
{
  IBlock block = StripIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MoppReorderTable.BlockCount; x++)
{
  IBlock block = MoppReorderTable.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VertexBuffers.BlockCount; x++)
{
  IBlock block = VertexBuffers.GetBlock(x);
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
      public Data VisibilityMoppCode {
        get {
          return this._visibilityMoppCode;
        }
        set {
          this._visibilityMoppCode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parts.Read(reader);
        _subparts.Read(reader);
        _visibilityBounds.Read(reader);
        _rawVertices.Read(reader);
        _stripIndices.Read(reader);
        _visibilityMoppCode.Read(reader);
        _moppReorderTable.Read(reader);
        _vertexBuffers.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts.Add(new GlobalGeometryPartBlockNewBlock());
          Parts[x].Read(reader);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _subparts.Count); x = (x + 1)) {
          Subparts.Add(new GlobalSubpartsBlockBlock());
          Subparts[x].Read(reader);
        }
        for (x = 0; (x < _subparts.Count); x = (x + 1)) {
          Subparts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _visibilityBounds.Count); x = (x + 1)) {
          VisibilityBounds.Add(new GlobalVisibilityBoundsBlockBlock());
          VisibilityBounds[x].Read(reader);
        }
        for (x = 0; (x < _visibilityBounds.Count); x = (x + 1)) {
          VisibilityBounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices.Add(new GlobalGeometrySectionRawVertexBlockBlock());
          RawVertices[x].Read(reader);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices.Add(new GlobalGeometrySectionStripIndexBlockBlock());
          StripIndices[x].Read(reader);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].ReadChildData(reader);
        }
        _visibilityMoppCode.ReadBinary(reader);
        for (x = 0; (x < _moppReorderTable.Count); x = (x + 1)) {
          MoppReorderTable.Add(new GlobalGeometrySectionStripIndexBlockBlock());
          MoppReorderTable[x].Read(reader);
        }
        for (x = 0; (x < _moppReorderTable.Count); x = (x + 1)) {
          MoppReorderTable[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers.Add(new GlobalGeometrySectionVertexBufferBlockBlock());
          VertexBuffers[x].Read(reader);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_parts.Count = Parts.Count;
        _parts.Write(bw);
_subparts.Count = Subparts.Count;
        _subparts.Write(bw);
_visibilityBounds.Count = VisibilityBounds.Count;
        _visibilityBounds.Write(bw);
_rawVertices.Count = RawVertices.Count;
        _rawVertices.Write(bw);
_stripIndices.Count = StripIndices.Count;
        _stripIndices.Write(bw);
        _visibilityMoppCode.Write(bw);
_moppReorderTable.Count = MoppReorderTable.Count;
        _moppReorderTable.Write(bw);
_vertexBuffers.Count = VertexBuffers.Count;
        _vertexBuffers.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].Write(writer);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _subparts.Count); x = (x + 1)) {
          Subparts[x].Write(writer);
        }
        for (x = 0; (x < _subparts.Count); x = (x + 1)) {
          Subparts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _visibilityBounds.Count); x = (x + 1)) {
          VisibilityBounds[x].Write(writer);
        }
        for (x = 0; (x < _visibilityBounds.Count); x = (x + 1)) {
          VisibilityBounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].Write(writer);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].Write(writer);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].WriteChildData(writer);
        }
        _visibilityMoppCode.WriteBinary(writer);
        for (x = 0; (x < _moppReorderTable.Count); x = (x + 1)) {
          MoppReorderTable[x].Write(writer);
        }
        for (x = 0; (x < _moppReorderTable.Count); x = (x + 1)) {
          MoppReorderTable[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].Write(writer);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalGeometryPartBlockNewBlock : IBlock {
      private Enum _type;
      private Flags _flags;
      private ShortBlockIndex _material = new ShortBlockIndex();
      private ShortInteger _stripStartIndex = new ShortInteger();
      private ShortInteger _stripLength = new ShortInteger();
      private ShortInteger _firstSubpartIndex = new ShortInteger();
      private ShortInteger _subpartCount = new ShortInteger();
      private CharInteger _maxNodesVertex = new CharInteger();
      private CharInteger _contributingCompoundNodeCount = new CharInteger();
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _lodMipmapMagicNumber = new Real();
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryPartBlockNewBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
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
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
        }
      }
      public ShortInteger StripStartIndex {
        get {
          return this._stripStartIndex;
        }
        set {
          this._stripStartIndex = value;
        }
      }
      public ShortInteger StripLength {
        get {
          return this._stripLength;
        }
        set {
          this._stripLength = value;
        }
      }
      public ShortInteger FirstSubpartIndex {
        get {
          return this._firstSubpartIndex;
        }
        set {
          this._firstSubpartIndex = value;
        }
      }
      public ShortInteger SubpartCount {
        get {
          return this._subpartCount;
        }
        set {
          this._subpartCount = value;
        }
      }
      public CharInteger MaxNodesVertex {
        get {
          return this._maxNodesVertex;
        }
        set {
          this._maxNodesVertex = value;
        }
      }
      public CharInteger ContributingCompoundNodeCount {
        get {
          return this._contributingCompoundNodeCount;
        }
        set {
          this._contributingCompoundNodeCount = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real LodMipmapMagicNumber {
        get {
          return this._lodMipmapMagicNumber;
        }
        set {
          this._lodMipmapMagicNumber = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _material.Read(reader);
        _stripStartIndex.Read(reader);
        _stripLength.Read(reader);
        _firstSubpartIndex.Read(reader);
        _subpartCount.Read(reader);
        _maxNodesVertex.Read(reader);
        _contributingCompoundNodeCount.Read(reader);
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _lodMipmapMagicNumber.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _material.Write(bw);
        _stripStartIndex.Write(bw);
        _stripLength.Write(bw);
        _firstSubpartIndex.Write(bw);
        _subpartCount.Write(bw);
        _maxNodesVertex.Write(bw);
        _contributingCompoundNodeCount.Write(bw);
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _lodMipmapMagicNumber.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalSubpartsBlockBlock : IBlock {
      private ShortInteger _indicesstartindex = new ShortInteger();
      private ShortInteger _indiceslength = new ShortInteger();
      private ShortInteger _visibilityboundsindex = new ShortInteger();
      private ShortInteger _partIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalSubpartsBlockBlock() {
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
      public ShortInteger Indicesstartindex {
        get {
          return this._indicesstartindex;
        }
        set {
          this._indicesstartindex = value;
        }
      }
      public ShortInteger Indiceslength {
        get {
          return this._indiceslength;
        }
        set {
          this._indiceslength = value;
        }
      }
      public ShortInteger Visibilityboundsindex {
        get {
          return this._visibilityboundsindex;
        }
        set {
          this._visibilityboundsindex = value;
        }
      }
      public ShortInteger PartIndex {
        get {
          return this._partIndex;
        }
        set {
          this._partIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _indicesstartindex.Read(reader);
        _indiceslength.Read(reader);
        _visibilityboundsindex.Read(reader);
        _partIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _indicesstartindex.Write(bw);
        _indiceslength.Write(bw);
        _visibilityboundsindex.Write(bw);
        _partIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalVisibilityBoundsBlockBlock : IBlock {
      private Real _positionX = new Real();
      private Real _positionY = new Real();
      private Real _positionZ = new Real();
      private Real _radius = new Real();
      private CharInteger _node0 = new CharInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GlobalVisibilityBoundsBlockBlock() {
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
      public Real PositionX {
        get {
          return this._positionX;
        }
        set {
          this._positionX = value;
        }
      }
      public Real PositionY {
        get {
          return this._positionY;
        }
        set {
          this._positionY = value;
        }
      }
      public Real PositionZ {
        get {
          return this._positionZ;
        }
        set {
          this._positionZ = value;
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
      public CharInteger Node0 {
        get {
          return this._node0;
        }
        set {
          this._node0 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _positionX.Read(reader);
        _positionY.Read(reader);
        _positionZ.Read(reader);
        _radius.Read(reader);
        _node0.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _positionX.Write(bw);
        _positionY.Write(bw);
        _positionZ.Write(bw);
        _radius.Write(bw);
        _node0.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometrySectionRawVertexBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private LongInteger _nodeIndexOLD = new LongInteger();
      private LongInteger _nodeIndexOLD2 = new LongInteger();
      private LongInteger _nodeIndexOLD3 = new LongInteger();
      private LongInteger _nodeIndexOLD4 = new LongInteger();
      private Real _nodeweight = new Real();
      private Real _nodeweight2 = new Real();
      private Real _nodeweight3 = new Real();
      private Real _nodeweight4 = new Real();
      private LongInteger _nodeIndexNEW = new LongInteger();
      private LongInteger _nodeIndexNEW2 = new LongInteger();
      private LongInteger _nodeIndexNEW3 = new LongInteger();
      private LongInteger _nodeIndexNEW4 = new LongInteger();
      private LongInteger _useNewNodeIndices = new LongInteger();
      private LongInteger _adjustedCompoundNodeIndex = new LongInteger();
      private RealPoint2D _texcoord = new RealPoint2D();
      private RealVector3D _normal = new RealVector3D();
      private RealVector3D _binormal = new RealVector3D();
      private RealVector3D _tangent = new RealVector3D();
      private RealVector3D _anisotropicBinormal = new RealVector3D();
      private RealPoint2D _secondaryTexcoord = new RealPoint2D();
      private RealRGBColor _primaryLightmapColor = new RealRGBColor();
      private RealPoint2D _primaryLightmapTexcoord = new RealPoint2D();
      private RealVector3D _primaryLightmapIncidentDirection = new RealVector3D();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public GlobalGeometrySectionRawVertexBlockBlock() {
        this._unnamed0 = new Pad(12);
        this._unnamed1 = new Pad(8);
        this._unnamed2 = new Pad(12);
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public LongInteger NodeIndexOLD {
        get {
          return this._nodeIndexOLD;
        }
        set {
          this._nodeIndexOLD = value;
        }
      }
      public LongInteger NodeIndexOLD2 {
        get {
          return this._nodeIndexOLD2;
        }
        set {
          this._nodeIndexOLD2 = value;
        }
      }
      public LongInteger NodeIndexOLD3 {
        get {
          return this._nodeIndexOLD3;
        }
        set {
          this._nodeIndexOLD3 = value;
        }
      }
      public LongInteger NodeIndexOLD4 {
        get {
          return this._nodeIndexOLD4;
        }
        set {
          this._nodeIndexOLD4 = value;
        }
      }
      public Real Nodeweight {
        get {
          return this._nodeweight;
        }
        set {
          this._nodeweight = value;
        }
      }
      public Real Nodeweight2 {
        get {
          return this._nodeweight2;
        }
        set {
          this._nodeweight2 = value;
        }
      }
      public Real Nodeweight3 {
        get {
          return this._nodeweight3;
        }
        set {
          this._nodeweight3 = value;
        }
      }
      public Real Nodeweight4 {
        get {
          return this._nodeweight4;
        }
        set {
          this._nodeweight4 = value;
        }
      }
      public LongInteger NodeIndexNEW {
        get {
          return this._nodeIndexNEW;
        }
        set {
          this._nodeIndexNEW = value;
        }
      }
      public LongInteger NodeIndexNEW2 {
        get {
          return this._nodeIndexNEW2;
        }
        set {
          this._nodeIndexNEW2 = value;
        }
      }
      public LongInteger NodeIndexNEW3 {
        get {
          return this._nodeIndexNEW3;
        }
        set {
          this._nodeIndexNEW3 = value;
        }
      }
      public LongInteger NodeIndexNEW4 {
        get {
          return this._nodeIndexNEW4;
        }
        set {
          this._nodeIndexNEW4 = value;
        }
      }
      public LongInteger UseNewNodeIndices {
        get {
          return this._useNewNodeIndices;
        }
        set {
          this._useNewNodeIndices = value;
        }
      }
      public LongInteger AdjustedCompoundNodeIndex {
        get {
          return this._adjustedCompoundNodeIndex;
        }
        set {
          this._adjustedCompoundNodeIndex = value;
        }
      }
      public RealPoint2D Texcoord {
        get {
          return this._texcoord;
        }
        set {
          this._texcoord = value;
        }
      }
      public RealVector3D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public RealVector3D Binormal {
        get {
          return this._binormal;
        }
        set {
          this._binormal = value;
        }
      }
      public RealVector3D Tangent {
        get {
          return this._tangent;
        }
        set {
          this._tangent = value;
        }
      }
      public RealVector3D AnisotropicBinormal {
        get {
          return this._anisotropicBinormal;
        }
        set {
          this._anisotropicBinormal = value;
        }
      }
      public RealPoint2D SecondaryTexcoord {
        get {
          return this._secondaryTexcoord;
        }
        set {
          this._secondaryTexcoord = value;
        }
      }
      public RealRGBColor PrimaryLightmapColor {
        get {
          return this._primaryLightmapColor;
        }
        set {
          this._primaryLightmapColor = value;
        }
      }
      public RealPoint2D PrimaryLightmapTexcoord {
        get {
          return this._primaryLightmapTexcoord;
        }
        set {
          this._primaryLightmapTexcoord = value;
        }
      }
      public RealVector3D PrimaryLightmapIncidentDirection {
        get {
          return this._primaryLightmapIncidentDirection;
        }
        set {
          this._primaryLightmapIncidentDirection = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndexOLD.Read(reader);
        _nodeIndexOLD2.Read(reader);
        _nodeIndexOLD3.Read(reader);
        _nodeIndexOLD4.Read(reader);
        _nodeweight.Read(reader);
        _nodeweight2.Read(reader);
        _nodeweight3.Read(reader);
        _nodeweight4.Read(reader);
        _nodeIndexNEW.Read(reader);
        _nodeIndexNEW2.Read(reader);
        _nodeIndexNEW3.Read(reader);
        _nodeIndexNEW4.Read(reader);
        _useNewNodeIndices.Read(reader);
        _adjustedCompoundNodeIndex.Read(reader);
        _texcoord.Read(reader);
        _normal.Read(reader);
        _binormal.Read(reader);
        _tangent.Read(reader);
        _anisotropicBinormal.Read(reader);
        _secondaryTexcoord.Read(reader);
        _primaryLightmapColor.Read(reader);
        _primaryLightmapTexcoord.Read(reader);
        _primaryLightmapIncidentDirection.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndexOLD.Write(bw);
        _nodeIndexOLD2.Write(bw);
        _nodeIndexOLD3.Write(bw);
        _nodeIndexOLD4.Write(bw);
        _nodeweight.Write(bw);
        _nodeweight2.Write(bw);
        _nodeweight3.Write(bw);
        _nodeweight4.Write(bw);
        _nodeIndexNEW.Write(bw);
        _nodeIndexNEW2.Write(bw);
        _nodeIndexNEW3.Write(bw);
        _nodeIndexNEW4.Write(bw);
        _useNewNodeIndices.Write(bw);
        _adjustedCompoundNodeIndex.Write(bw);
        _texcoord.Write(bw);
        _normal.Write(bw);
        _binormal.Write(bw);
        _tangent.Write(bw);
        _anisotropicBinormal.Write(bw);
        _secondaryTexcoord.Write(bw);
        _primaryLightmapColor.Write(bw);
        _primaryLightmapTexcoord.Write(bw);
        _primaryLightmapIncidentDirection.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometrySectionStripIndexBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometrySectionStripIndexBlockBlock() {
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
      public ShortInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _index.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _index.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometrySectionVertexBufferBlockBlock : IBlock {
      private Skip _vertexBuffer;
public event System.EventHandler BlockNameChanged;
      public GlobalGeometrySectionVertexBufferBlockBlock() {
        this._vertexBuffer = new Skip(32);
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
        _vertexBuffer.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertexBuffer.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightmapGeometryRenderInfoBlockBlock : IBlock {
      private ShortInteger _bitmapIndex = new ShortInteger();
      private CharInteger _paletteIndex = new CharInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public LightmapGeometryRenderInfoBlockBlock() {
        this._unnamed0 = new Pad(1);
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
      public CharInteger PaletteIndex {
        get {
          return this._paletteIndex;
        }
        set {
          this._paletteIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmapIndex.Read(reader);
        _paletteIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapIndex.Write(bw);
        _paletteIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureLightmapLightingEnvironmentBlockBlock : IBlock {
      private RealPoint3D _samplepoint = new RealPoint3D();
      private Real _redCoefficient = new Real();
      private Real _redCoefficient2 = new Real();
      private Real _redCoefficient3 = new Real();
      private Real _redCoefficient4 = new Real();
      private Real _redCoefficient5 = new Real();
      private Real _redCoefficient6 = new Real();
      private Real _redCoefficient7 = new Real();
      private Real _redCoefficient8 = new Real();
      private Real _redCoefficient9 = new Real();
      private Real _greenCoefficient = new Real();
      private Real _greenCoefficient2 = new Real();
      private Real _greenCoefficient3 = new Real();
      private Real _greenCoefficient4 = new Real();
      private Real _greenCoefficient5 = new Real();
      private Real _greenCoefficient6 = new Real();
      private Real _greenCoefficient7 = new Real();
      private Real _greenCoefficient8 = new Real();
      private Real _greenCoefficient9 = new Real();
      private Real _blueCoefficient = new Real();
      private Real _blueCoefficient2 = new Real();
      private Real _blueCoefficient3 = new Real();
      private Real _blueCoefficient4 = new Real();
      private Real _blueCoefficient5 = new Real();
      private Real _blueCoefficient6 = new Real();
      private Real _blueCoefficient7 = new Real();
      private Real _blueCoefficient8 = new Real();
      private Real _blueCoefficient9 = new Real();
      private RealVector3D _meanIncomingLightDirection = new RealVector3D();
      private RealPoint3D _incomingLightIntensity = new RealPoint3D();
      private LongInteger _specularBitmapIndex = new LongInteger();
      private RealVector3D _rotationAxis = new RealVector3D();
      private Real _rotationSpeed = new Real();
      private RealVector3D _bumpDirection = new RealVector3D();
      private RealRGBColor _colorTint = new RealRGBColor();
      private Enum _proceduralOveride;
      private Flags _flags;
      private RealVector3D _proceduralParam0 = new RealVector3D();
      private RealVector3D _proceduralParam1xyz = new RealVector3D();
      private Real _proceduralParam1w = new Real();
public event System.EventHandler BlockNameChanged;
      public StructureLightmapLightingEnvironmentBlockBlock() {
        this._proceduralOveride = new Enum(2);
        this._flags = new Flags(2);
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
      public RealPoint3D Samplepoint {
        get {
          return this._samplepoint;
        }
        set {
          this._samplepoint = value;
        }
      }
      public Real RedCoefficient {
        get {
          return this._redCoefficient;
        }
        set {
          this._redCoefficient = value;
        }
      }
      public Real RedCoefficient2 {
        get {
          return this._redCoefficient2;
        }
        set {
          this._redCoefficient2 = value;
        }
      }
      public Real RedCoefficient3 {
        get {
          return this._redCoefficient3;
        }
        set {
          this._redCoefficient3 = value;
        }
      }
      public Real RedCoefficient4 {
        get {
          return this._redCoefficient4;
        }
        set {
          this._redCoefficient4 = value;
        }
      }
      public Real RedCoefficient5 {
        get {
          return this._redCoefficient5;
        }
        set {
          this._redCoefficient5 = value;
        }
      }
      public Real RedCoefficient6 {
        get {
          return this._redCoefficient6;
        }
        set {
          this._redCoefficient6 = value;
        }
      }
      public Real RedCoefficient7 {
        get {
          return this._redCoefficient7;
        }
        set {
          this._redCoefficient7 = value;
        }
      }
      public Real RedCoefficient8 {
        get {
          return this._redCoefficient8;
        }
        set {
          this._redCoefficient8 = value;
        }
      }
      public Real RedCoefficient9 {
        get {
          return this._redCoefficient9;
        }
        set {
          this._redCoefficient9 = value;
        }
      }
      public Real GreenCoefficient {
        get {
          return this._greenCoefficient;
        }
        set {
          this._greenCoefficient = value;
        }
      }
      public Real GreenCoefficient2 {
        get {
          return this._greenCoefficient2;
        }
        set {
          this._greenCoefficient2 = value;
        }
      }
      public Real GreenCoefficient3 {
        get {
          return this._greenCoefficient3;
        }
        set {
          this._greenCoefficient3 = value;
        }
      }
      public Real GreenCoefficient4 {
        get {
          return this._greenCoefficient4;
        }
        set {
          this._greenCoefficient4 = value;
        }
      }
      public Real GreenCoefficient5 {
        get {
          return this._greenCoefficient5;
        }
        set {
          this._greenCoefficient5 = value;
        }
      }
      public Real GreenCoefficient6 {
        get {
          return this._greenCoefficient6;
        }
        set {
          this._greenCoefficient6 = value;
        }
      }
      public Real GreenCoefficient7 {
        get {
          return this._greenCoefficient7;
        }
        set {
          this._greenCoefficient7 = value;
        }
      }
      public Real GreenCoefficient8 {
        get {
          return this._greenCoefficient8;
        }
        set {
          this._greenCoefficient8 = value;
        }
      }
      public Real GreenCoefficient9 {
        get {
          return this._greenCoefficient9;
        }
        set {
          this._greenCoefficient9 = value;
        }
      }
      public Real BlueCoefficient {
        get {
          return this._blueCoefficient;
        }
        set {
          this._blueCoefficient = value;
        }
      }
      public Real BlueCoefficient2 {
        get {
          return this._blueCoefficient2;
        }
        set {
          this._blueCoefficient2 = value;
        }
      }
      public Real BlueCoefficient3 {
        get {
          return this._blueCoefficient3;
        }
        set {
          this._blueCoefficient3 = value;
        }
      }
      public Real BlueCoefficient4 {
        get {
          return this._blueCoefficient4;
        }
        set {
          this._blueCoefficient4 = value;
        }
      }
      public Real BlueCoefficient5 {
        get {
          return this._blueCoefficient5;
        }
        set {
          this._blueCoefficient5 = value;
        }
      }
      public Real BlueCoefficient6 {
        get {
          return this._blueCoefficient6;
        }
        set {
          this._blueCoefficient6 = value;
        }
      }
      public Real BlueCoefficient7 {
        get {
          return this._blueCoefficient7;
        }
        set {
          this._blueCoefficient7 = value;
        }
      }
      public Real BlueCoefficient8 {
        get {
          return this._blueCoefficient8;
        }
        set {
          this._blueCoefficient8 = value;
        }
      }
      public Real BlueCoefficient9 {
        get {
          return this._blueCoefficient9;
        }
        set {
          this._blueCoefficient9 = value;
        }
      }
      public RealVector3D MeanIncomingLightDirection {
        get {
          return this._meanIncomingLightDirection;
        }
        set {
          this._meanIncomingLightDirection = value;
        }
      }
      public RealPoint3D IncomingLightIntensity {
        get {
          return this._incomingLightIntensity;
        }
        set {
          this._incomingLightIntensity = value;
        }
      }
      public LongInteger SpecularBitmapIndex {
        get {
          return this._specularBitmapIndex;
        }
        set {
          this._specularBitmapIndex = value;
        }
      }
      public RealVector3D RotationAxis {
        get {
          return this._rotationAxis;
        }
        set {
          this._rotationAxis = value;
        }
      }
      public Real RotationSpeed {
        get {
          return this._rotationSpeed;
        }
        set {
          this._rotationSpeed = value;
        }
      }
      public RealVector3D BumpDirection {
        get {
          return this._bumpDirection;
        }
        set {
          this._bumpDirection = value;
        }
      }
      public RealRGBColor ColorTint {
        get {
          return this._colorTint;
        }
        set {
          this._colorTint = value;
        }
      }
      public Enum ProceduralOveride {
        get {
          return this._proceduralOveride;
        }
        set {
          this._proceduralOveride = value;
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
      public RealVector3D ProceduralParam0 {
        get {
          return this._proceduralParam0;
        }
        set {
          this._proceduralParam0 = value;
        }
      }
      public RealVector3D ProceduralParam1xyz {
        get {
          return this._proceduralParam1xyz;
        }
        set {
          this._proceduralParam1xyz = value;
        }
      }
      public Real ProceduralParam1w {
        get {
          return this._proceduralParam1w;
        }
        set {
          this._proceduralParam1w = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _samplepoint.Read(reader);
        _redCoefficient.Read(reader);
        _redCoefficient2.Read(reader);
        _redCoefficient3.Read(reader);
        _redCoefficient4.Read(reader);
        _redCoefficient5.Read(reader);
        _redCoefficient6.Read(reader);
        _redCoefficient7.Read(reader);
        _redCoefficient8.Read(reader);
        _redCoefficient9.Read(reader);
        _greenCoefficient.Read(reader);
        _greenCoefficient2.Read(reader);
        _greenCoefficient3.Read(reader);
        _greenCoefficient4.Read(reader);
        _greenCoefficient5.Read(reader);
        _greenCoefficient6.Read(reader);
        _greenCoefficient7.Read(reader);
        _greenCoefficient8.Read(reader);
        _greenCoefficient9.Read(reader);
        _blueCoefficient.Read(reader);
        _blueCoefficient2.Read(reader);
        _blueCoefficient3.Read(reader);
        _blueCoefficient4.Read(reader);
        _blueCoefficient5.Read(reader);
        _blueCoefficient6.Read(reader);
        _blueCoefficient7.Read(reader);
        _blueCoefficient8.Read(reader);
        _blueCoefficient9.Read(reader);
        _meanIncomingLightDirection.Read(reader);
        _incomingLightIntensity.Read(reader);
        _specularBitmapIndex.Read(reader);
        _rotationAxis.Read(reader);
        _rotationSpeed.Read(reader);
        _bumpDirection.Read(reader);
        _colorTint.Read(reader);
        _proceduralOveride.Read(reader);
        _flags.Read(reader);
        _proceduralParam0.Read(reader);
        _proceduralParam1xyz.Read(reader);
        _proceduralParam1w.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _samplepoint.Write(bw);
        _redCoefficient.Write(bw);
        _redCoefficient2.Write(bw);
        _redCoefficient3.Write(bw);
        _redCoefficient4.Write(bw);
        _redCoefficient5.Write(bw);
        _redCoefficient6.Write(bw);
        _redCoefficient7.Write(bw);
        _redCoefficient8.Write(bw);
        _redCoefficient9.Write(bw);
        _greenCoefficient.Write(bw);
        _greenCoefficient2.Write(bw);
        _greenCoefficient3.Write(bw);
        _greenCoefficient4.Write(bw);
        _greenCoefficient5.Write(bw);
        _greenCoefficient6.Write(bw);
        _greenCoefficient7.Write(bw);
        _greenCoefficient8.Write(bw);
        _greenCoefficient9.Write(bw);
        _blueCoefficient.Write(bw);
        _blueCoefficient2.Write(bw);
        _blueCoefficient3.Write(bw);
        _blueCoefficient4.Write(bw);
        _blueCoefficient5.Write(bw);
        _blueCoefficient6.Write(bw);
        _blueCoefficient7.Write(bw);
        _blueCoefficient8.Write(bw);
        _blueCoefficient9.Write(bw);
        _meanIncomingLightDirection.Write(bw);
        _incomingLightIntensity.Write(bw);
        _specularBitmapIndex.Write(bw);
        _rotationAxis.Write(bw);
        _rotationSpeed.Write(bw);
        _bumpDirection.Write(bw);
        _colorTint.Write(bw);
        _proceduralOveride.Write(bw);
        _flags.Write(bw);
        _proceduralParam0.Write(bw);
        _proceduralParam1xyz.Write(bw);
        _proceduralParam1w.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightmapVertexBufferBucketBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Block _rawVertices = new Block();
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Block _cacheData = new Block();
      public BlockCollection<LightmapBucketRawVertexBlockBlock> _rawVerticesList = new BlockCollection<LightmapBucketRawVertexBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<LightmapVertexBufferBucketCacheDataBlockBlock> _cacheDataList = new BlockCollection<LightmapVertexBufferBucketCacheDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightmapVertexBufferBucketBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._geometrySelfReference = new Skip(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
      }
      public BlockCollection<LightmapBucketRawVertexBlockBlock> RawVertices {
        get {
          return this._rawVerticesList;
        }
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public BlockCollection<LightmapVertexBufferBucketCacheDataBlockBlock> CacheData {
        get {
          return this._cacheDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<RawVertices.BlockCount; x++)
{
  IBlock block = RawVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CacheData.BlockCount; x++)
{
  IBlock block = CacheData.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _rawVertices.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _cacheData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices.Add(new LightmapBucketRawVertexBlockBlock());
          RawVertices[x].Read(reader);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].ReadChildData(reader);
        }
        _resourceData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData.Add(new LightmapVertexBufferBucketCacheDataBlockBlock());
          CacheData[x].Read(reader);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
_rawVertices.Count = RawVertices.Count;
        _rawVertices.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_cacheData.Count = CacheData.Count;
        _cacheData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].Write(writer);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].WriteChildData(writer);
        }
        _resourceData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].Write(writer);
        }
        for (x = 0; (x < _cacheData.Count); x = (x + 1)) {
          CacheData[x].WriteChildData(writer);
        }
      }
    }
    public class LightmapBucketRawVertexBlockBlock : IBlock {
      private RealRGBColor _primaryLightmapColor = new RealRGBColor();
      private RealVector3D _primaryLightmapIncidentDirection = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public LightmapBucketRawVertexBlockBlock() {
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
      public RealRGBColor PrimaryLightmapColor {
        get {
          return this._primaryLightmapColor;
        }
        set {
          this._primaryLightmapColor = value;
        }
      }
      public RealVector3D PrimaryLightmapIncidentDirection {
        get {
          return this._primaryLightmapIncidentDirection;
        }
        set {
          this._primaryLightmapIncidentDirection = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _primaryLightmapColor.Read(reader);
        _primaryLightmapIncidentDirection.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _primaryLightmapColor.Write(bw);
        _primaryLightmapIncidentDirection.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightmapVertexBufferBucketCacheDataBlockBlock : IBlock {
      private Block _vertexBuffers = new Block();
      public BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock> _vertexBuffersList = new BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightmapVertexBufferBucketCacheDataBlockBlock() {
      }
      public BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock> VertexBuffers {
        get {
          return this._vertexBuffersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<VertexBuffers.BlockCount; x++)
{
  IBlock block = VertexBuffers.GetBlock(x);
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
        _vertexBuffers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers.Add(new GlobalGeometrySectionVertexBufferBlockBlock());
          VertexBuffers[x].Read(reader);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_vertexBuffers.Count = VertexBuffers.Count;
        _vertexBuffers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].Write(writer);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].WriteChildData(writer);
        }
      }
    }
    public class LightmapInstanceBucketReferenceBlockBlock : IBlock {
      private ShortInteger _flags = new ShortInteger();
      private ShortInteger _bucketIndex = new ShortInteger();
      private Block _sectionOffsets = new Block();
      public BlockCollection<LightmapInstanceBucketSectionOffsetBlockBlock> _sectionOffsetsList = new BlockCollection<LightmapInstanceBucketSectionOffsetBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LightmapInstanceBucketReferenceBlockBlock() {
      }
      public BlockCollection<LightmapInstanceBucketSectionOffsetBlockBlock> SectionOffsets {
        get {
          return this._sectionOffsetsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SectionOffsets.BlockCount; x++)
{
  IBlock block = SectionOffsets.GetBlock(x);
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
      public ShortInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger BucketIndex {
        get {
          return this._bucketIndex;
        }
        set {
          this._bucketIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bucketIndex.Read(reader);
        _sectionOffsets.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sectionOffsets.Count); x = (x + 1)) {
          SectionOffsets.Add(new LightmapInstanceBucketSectionOffsetBlockBlock());
          SectionOffsets[x].Read(reader);
        }
        for (x = 0; (x < _sectionOffsets.Count); x = (x + 1)) {
          SectionOffsets[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bucketIndex.Write(bw);
_sectionOffsets.Count = SectionOffsets.Count;
        _sectionOffsets.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sectionOffsets.Count); x = (x + 1)) {
          SectionOffsets[x].Write(writer);
        }
        for (x = 0; (x < _sectionOffsets.Count); x = (x + 1)) {
          SectionOffsets[x].WriteChildData(writer);
        }
      }
    }
    public class LightmapInstanceBucketSectionOffsetBlockBlock : IBlock {
      private ShortInteger _sectionOffset = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public LightmapInstanceBucketSectionOffsetBlockBlock() {
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
      public ShortInteger SectionOffset {
        get {
          return this._sectionOffset;
        }
        set {
          this._sectionOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectionOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _sectionOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightmapSceneryObjectInfoBlockBlock : IBlock {
      private LongInteger _uniqueID = new LongInteger();
      private ShortInteger _originBSPIndex = new ShortInteger();
      private CharInteger _type = new CharInteger();
      private CharInteger _source = new CharInteger();
      private LongInteger _renderModelChecksum = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public LightmapSceneryObjectInfoBlockBlock() {
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
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortInteger OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
        }
      }
      public CharInteger Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public CharInteger Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public LongInteger RenderModelChecksum {
        get {
          return this._renderModelChecksum;
        }
        set {
          this._renderModelChecksum = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type.Read(reader);
        _source.Read(reader);
        _renderModelChecksum.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type.Write(bw);
        _source.Write(bw);
        _renderModelChecksum.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalErrorReportCategoriesBlockBlock : IBlock {
      private LongerFixedLengthString _name = new LongerFixedLengthString();
      private Enum _reportType;
      private Flags _flags;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Block _reports = new Block();
      public BlockCollection<ErrorReportsBlockBlock> _reportsList = new BlockCollection<ErrorReportsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalErrorReportCategoriesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._reportType = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(404);
      }
      public BlockCollection<ErrorReportsBlockBlock> Reports {
        get {
          return this._reportsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reports.BlockCount; x++)
{
  IBlock block = Reports.GetBlock(x);
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
      public LongerFixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Enum ReportType {
        get {
          return this._reportType;
        }
        set {
          this._reportType = value;
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
        _name.Read(reader);
        _reportType.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _reports.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports.Add(new ErrorReportsBlockBlock());
          Reports[x].Read(reader);
        }
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _reportType.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_reports.Count = Reports.Count;
        _reports.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].Write(writer);
        }
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].WriteChildData(writer);
        }
      }
    }
    public class ErrorReportsBlockBlock : IBlock {
      private Enum _type;
      private Flags _flags;
      private Data _text = new Data();
      private FixedLengthString _sourceFilename = new FixedLengthString();
      private LongInteger _sourceLineNumber = new LongInteger();
      private Block _vertices = new Block();
      private Block _vectors = new Block();
      private Block _lines = new Block();
      private Block _triangles = new Block();
      private Block _quads = new Block();
      private Block _comments = new Block();
      private Pad _unnamed0;
      private LongInteger _reportKey = new LongInteger();
      private LongInteger _nodeIndex = new LongInteger();
      private RealBounds _boundsX = new RealBounds();
      private RealBounds _boundsY = new RealBounds();
      private RealBounds _boundsZ = new RealBounds();
      private RealARGBColor _color = new RealARGBColor();
      private Pad _unnamed1;
      public BlockCollection<ErrorReportVerticesBlockBlock> _verticesList = new BlockCollection<ErrorReportVerticesBlockBlock>();
      public BlockCollection<ErrorReportVectorsBlockBlock> _vectorsList = new BlockCollection<ErrorReportVectorsBlockBlock>();
      public BlockCollection<ErrorReportLinesBlockBlock> _linesList = new BlockCollection<ErrorReportLinesBlockBlock>();
      public BlockCollection<ErrorReportTrianglesBlockBlock> _trianglesList = new BlockCollection<ErrorReportTrianglesBlockBlock>();
      public BlockCollection<ErrorReportQuadsBlockBlock> _quadsList = new BlockCollection<ErrorReportQuadsBlockBlock>();
      public BlockCollection<ErrorReportCommentsBlockBlock> _commentsList = new BlockCollection<ErrorReportCommentsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ErrorReportsBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(380);
        this._unnamed1 = new Pad(84);
      }
      public BlockCollection<ErrorReportVerticesBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<ErrorReportVectorsBlockBlock> Vectors {
        get {
          return this._vectorsList;
        }
      }
      public BlockCollection<ErrorReportLinesBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<ErrorReportTrianglesBlockBlock> Triangles {
        get {
          return this._trianglesList;
        }
      }
      public BlockCollection<ErrorReportQuadsBlockBlock> Quads {
        get {
          return this._quadsList;
        }
      }
      public BlockCollection<ErrorReportCommentsBlockBlock> Comments {
        get {
          return this._commentsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vectors.BlockCount; x++)
{
  IBlock block = Vectors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Triangles.BlockCount; x++)
{
  IBlock block = Triangles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Quads.BlockCount; x++)
{
  IBlock block = Quads.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Comments.BlockCount; x++)
{
  IBlock block = Comments.GetBlock(x);
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
      public Data Text {
        get {
          return this._text;
        }
        set {
          this._text = value;
        }
      }
      public FixedLengthString SourceFilename {
        get {
          return this._sourceFilename;
        }
        set {
          this._sourceFilename = value;
        }
      }
      public LongInteger SourceLineNumber {
        get {
          return this._sourceLineNumber;
        }
        set {
          this._sourceLineNumber = value;
        }
      }
      public LongInteger ReportKey {
        get {
          return this._reportKey;
        }
        set {
          this._reportKey = value;
        }
      }
      public LongInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public RealBounds BoundsX {
        get {
          return this._boundsX;
        }
        set {
          this._boundsX = value;
        }
      }
      public RealBounds BoundsY {
        get {
          return this._boundsY;
        }
        set {
          this._boundsY = value;
        }
      }
      public RealBounds BoundsZ {
        get {
          return this._boundsZ;
        }
        set {
          this._boundsZ = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _text.Read(reader);
        _sourceFilename.Read(reader);
        _sourceLineNumber.Read(reader);
        _vertices.Read(reader);
        _vectors.Read(reader);
        _lines.Read(reader);
        _triangles.Read(reader);
        _quads.Read(reader);
        _comments.Read(reader);
        _unnamed0.Read(reader);
        _reportKey.Read(reader);
        _nodeIndex.Read(reader);
        _boundsX.Read(reader);
        _boundsY.Read(reader);
        _boundsZ.Read(reader);
        _color.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _text.ReadBinary(reader);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new ErrorReportVerticesBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors.Add(new ErrorReportVectorsBlockBlock());
          Vectors[x].Read(reader);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new ErrorReportLinesBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles.Add(new ErrorReportTrianglesBlockBlock());
          Triangles[x].Read(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads.Add(new ErrorReportQuadsBlockBlock());
          Quads[x].Read(reader);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].ReadChildData(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments.Add(new ErrorReportCommentsBlockBlock());
          Comments[x].Read(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _text.Write(bw);
        _sourceFilename.Write(bw);
        _sourceLineNumber.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_vectors.Count = Vectors.Count;
        _vectors.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_triangles.Count = Triangles.Count;
        _triangles.Write(bw);
_quads.Count = Quads.Count;
        _quads.Write(bw);
_comments.Count = Comments.Count;
        _comments.Write(bw);
        _unnamed0.Write(bw);
        _reportKey.Write(bw);
        _nodeIndex.Write(bw);
        _boundsX.Write(bw);
        _boundsY.Write(bw);
        _boundsZ.Write(bw);
        _color.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _text.WriteBinary(writer);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].Write(writer);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].Write(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].Write(writer);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].WriteChildData(writer);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].Write(writer);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].WriteChildData(writer);
        }
      }
    }
    public class ErrorReportVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
      private Real _screenSize = new Real();
public event System.EventHandler BlockNameChanged;
      public ErrorReportVerticesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public Real ScreenSize {
        get {
          return this._screenSize;
        }
        set {
          this._screenSize = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
        _screenSize.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
        _screenSize.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportVectorsBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
      private RealVector3D _normal = new RealVector3D();
      private Real _screenLength = new Real();
public event System.EventHandler BlockNameChanged;
      public ErrorReportVectorsBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public RealVector3D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public Real ScreenLength {
        get {
          return this._screenLength;
        }
        set {
          this._screenLength = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
        _normal.Read(reader);
        _screenLength.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
        _normal.Write(bw);
        _screenLength.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportLinesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportLinesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportTrianglesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private RealPoint3D _position3 = new RealPoint3D();
      private CharInteger _nodeIndex9 = new CharInteger();
      private CharInteger _nodeIndex10 = new CharInteger();
      private CharInteger _nodeIndex11 = new CharInteger();
      private CharInteger _nodeIndex12 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportTrianglesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public RealPoint3D Position3 {
        get {
          return this._position3;
        }
        set {
          this._position3 = value;
        }
      }
      public CharInteger NodeIndex9 {
        get {
          return this._nodeIndex9;
        }
        set {
          this._nodeIndex9 = value;
        }
      }
      public CharInteger NodeIndex10 {
        get {
          return this._nodeIndex10;
        }
        set {
          this._nodeIndex10 = value;
        }
      }
      public CharInteger NodeIndex11 {
        get {
          return this._nodeIndex11;
        }
        set {
          this._nodeIndex11 = value;
        }
      }
      public CharInteger NodeIndex12 {
        get {
          return this._nodeIndex12;
        }
        set {
          this._nodeIndex12 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _position3.Read(reader);
        _nodeIndex9.Read(reader);
        _nodeIndex10.Read(reader);
        _nodeIndex11.Read(reader);
        _nodeIndex12.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _position3.Write(bw);
        _nodeIndex9.Write(bw);
        _nodeIndex10.Write(bw);
        _nodeIndex11.Write(bw);
        _nodeIndex12.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportQuadsBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private RealPoint3D _position3 = new RealPoint3D();
      private CharInteger _nodeIndex9 = new CharInteger();
      private CharInteger _nodeIndex10 = new CharInteger();
      private CharInteger _nodeIndex11 = new CharInteger();
      private CharInteger _nodeIndex12 = new CharInteger();
      private RealPoint3D _position4 = new RealPoint3D();
      private CharInteger _nodeIndex13 = new CharInteger();
      private CharInteger _nodeIndex14 = new CharInteger();
      private CharInteger _nodeIndex15 = new CharInteger();
      private CharInteger _nodeIndex16 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportQuadsBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public RealPoint3D Position3 {
        get {
          return this._position3;
        }
        set {
          this._position3 = value;
        }
      }
      public CharInteger NodeIndex9 {
        get {
          return this._nodeIndex9;
        }
        set {
          this._nodeIndex9 = value;
        }
      }
      public CharInteger NodeIndex10 {
        get {
          return this._nodeIndex10;
        }
        set {
          this._nodeIndex10 = value;
        }
      }
      public CharInteger NodeIndex11 {
        get {
          return this._nodeIndex11;
        }
        set {
          this._nodeIndex11 = value;
        }
      }
      public CharInteger NodeIndex12 {
        get {
          return this._nodeIndex12;
        }
        set {
          this._nodeIndex12 = value;
        }
      }
      public RealPoint3D Position4 {
        get {
          return this._position4;
        }
        set {
          this._position4 = value;
        }
      }
      public CharInteger NodeIndex13 {
        get {
          return this._nodeIndex13;
        }
        set {
          this._nodeIndex13 = value;
        }
      }
      public CharInteger NodeIndex14 {
        get {
          return this._nodeIndex14;
        }
        set {
          this._nodeIndex14 = value;
        }
      }
      public CharInteger NodeIndex15 {
        get {
          return this._nodeIndex15;
        }
        set {
          this._nodeIndex15 = value;
        }
      }
      public CharInteger NodeIndex16 {
        get {
          return this._nodeIndex16;
        }
        set {
          this._nodeIndex16 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _position3.Read(reader);
        _nodeIndex9.Read(reader);
        _nodeIndex10.Read(reader);
        _nodeIndex11.Read(reader);
        _nodeIndex12.Read(reader);
        _position4.Read(reader);
        _nodeIndex13.Read(reader);
        _nodeIndex14.Read(reader);
        _nodeIndex15.Read(reader);
        _nodeIndex16.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _position3.Write(bw);
        _nodeIndex9.Write(bw);
        _nodeIndex10.Write(bw);
        _nodeIndex11.Write(bw);
        _nodeIndex12.Write(bw);
        _position4.Write(bw);
        _nodeIndex13.Write(bw);
        _nodeIndex14.Write(bw);
        _nodeIndex15.Write(bw);
        _nodeIndex16.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportCommentsBlockBlock : IBlock {
      private Data _text = new Data();
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportCommentsBlockBlock() {
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
      public Data Text {
        get {
          return this._text;
        }
        set {
          this._text = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _text.Read(reader);
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _text.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _text.Write(bw);
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _text.WriteBinary(writer);
      }
    }
  }
}
