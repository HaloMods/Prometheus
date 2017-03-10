// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'scenario_structure_bsp'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class scenario_structure_bsp : Interfaces.Pool.Tag {
    private GlobalStructurePhysicsStructBlockBlock scenarioStructureBspValues = new GlobalStructurePhysicsStructBlockBlock();
    public virtual GlobalStructurePhysicsStructBlockBlock ScenarioStructureBspValues {
      get {
        return scenarioStructureBspValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ScenarioStructureBspValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "scenario_structure_bsp";
      }
    }
    #region Read/Write Methods
    public override int Load(byte[] metadata) {
      File.WriteAllBytes(@"C:\Users\Owner\Desktop\test.sbsp", metadata);
      System.IO.BinaryReader reader = new System.IO.BinaryReader(new System.IO.MemoryStream(metadata));
Read(reader);
int position = (int)reader.BaseStream.Position;
ReadChildData(reader);
reader.Close();
      return position;
    }
    public override void Read(BinaryReader reader) {
scenarioStructureBspValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
scenarioStructureBspValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
scenarioStructureBspValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
scenarioStructureBspValues.WriteChildData(writer);
    }
    #endregion
    public class GlobalStructurePhysicsStructBlockBlock : IBlock {
      private Block _importInfo = new Block();
      private Pad _unnamed0;
      private Block _collisionMaterials = new Block();
      private Block _collisionBSP = new Block();
      private Real _vehicleFloor = new Real();
      private Real _vehicleCeiling = new Real();
      private Block _uNUSEDNodes = new Block();
      private Block _leaves = new Block();
      private RealBounds _worldBoundsX = new RealBounds();
      private RealBounds _worldBoundsY = new RealBounds();
      private RealBounds _worldBoundsZ = new RealBounds();
      private Block _surfaceReferences = new Block();
      private Data _clusterData = new Data();
      private Block _clusterPortals = new Block();
      private Block _fogPlanes = new Block();
      private Pad _unnamed1;
      private Block _weatherPalette = new Block();
      private Block _weatherPolyhedra = new Block();
      private Block _detailObjects = new Block();
      private Block _clusters = new Block();
      private Block _materials = new Block();
      private Block _skyOwnerCluster = new Block();
      private Block _conveyorSurfaces = new Block();
      private Block _breakableSurfaces = new Block();
      private Block _pathfindingData = new Block();
      private Block _pathfindingEdges = new Block();
      private Block _backgroundSoundPalette = new Block();
      private Block _soundEnvironmentPalette = new Block();
      private Data _soundPASData = new Data();
      private Block _markers = new Block();
      private Block _runtimeDecals = new Block();
      private Block _environmentObjectPalette = new Block();
      private Block _environmentObjects = new Block();
      private Block _lightmaps = new Block();
      private Pad _unnamed2;
      private Block _leafMapLeaves = new Block();
      private Block _leafMapConnections = new Block();
      private Block _errors = new Block();
      private Block _precomputedLighting = new Block();
      private Block _instancedGeometriesDefinitions = new Block();
      private Block _instancedGeometryInstances = new Block();
      private Block _ambienceSoundClusters = new Block();
      private Block _reverbSoundClusters = new Block();
      private Block _transparentPlanes = new Block();
      private Pad _unnamed3;
      private Real _vehicleSpericalLimitRadius = new Real();
      private RealPoint3D _vehicleSpericalLimitCenter = new RealPoint3D();
      private Block _debugInfo = new Block();
      private TagReference _decorators = new TagReference();
      private Data _moppCode = new Data();
      private Pad _unnamed4;
      private RealPoint3D _moppBoundsMin = new RealPoint3D();
      private RealPoint3D _moppBoundsMax = new RealPoint3D();
      private Data _breakableSurfacesMoppCode = new Data();
      private Block _breakableSurfaceKeyTable = new Block();
      private Block _waterDefinitions = new Block();
      private Block _portaldeviceMapping = new Block();
      private Block _audibility = new Block();
      private Block _objectFakeLightprobes = new Block();
      private Block _decorators2 = new Block();
      public BlockCollection<GlobalTagImportInfoBlockBlock> _importInfoList = new BlockCollection<GlobalTagImportInfoBlockBlock>();
      public BlockCollection<StructureCollisionMaterialsBlockBlock> _collisionMaterialsList = new BlockCollection<StructureCollisionMaterialsBlockBlock>();
      public BlockCollection<GlobalCollisionBspBlockBlock> _collisionBSPList = new BlockCollection<GlobalCollisionBspBlockBlock>();
      public BlockCollection<UNUSEDStructureBspNodeBlockBlock> _uNUSEDNodesList = new BlockCollection<UNUSEDStructureBspNodeBlockBlock>();
      public BlockCollection<StructureBspLeafBlockBlock> _leavesList = new BlockCollection<StructureBspLeafBlockBlock>();
      public BlockCollection<StructureBspSurfaceReferenceBlockBlock> _surfaceReferencesList = new BlockCollection<StructureBspSurfaceReferenceBlockBlock>();
      public BlockCollection<StructureBspClusterPortalBlockBlock> _clusterPortalsList = new BlockCollection<StructureBspClusterPortalBlockBlock>();
      public BlockCollection<StructureBspFogPlaneBlockBlock> _fogPlanesList = new BlockCollection<StructureBspFogPlaneBlockBlock>();
      public BlockCollection<StructureBspWeatherPaletteBlockBlock> _weatherPaletteList = new BlockCollection<StructureBspWeatherPaletteBlockBlock>();
      public BlockCollection<StructureBspWeatherPolyhedronBlockBlock> _weatherPolyhedraList = new BlockCollection<StructureBspWeatherPolyhedronBlockBlock>();
      public BlockCollection<StructureBspDetailObjectDataBlockBlock> _detailObjectsList = new BlockCollection<StructureBspDetailObjectDataBlockBlock>();
      public BlockCollection<StructureBspClusterBlockBlock> _clustersList = new BlockCollection<StructureBspClusterBlockBlock>();
      public BlockCollection<GlobalGeometryMaterialBlockBlock> _materialsList = new BlockCollection<GlobalGeometryMaterialBlockBlock>();
      public BlockCollection<StructureBspSkyOwnerClusterBlockBlock> _skyOwnerClusterList = new BlockCollection<StructureBspSkyOwnerClusterBlockBlock>();
      public BlockCollection<StructureBspConveyorSurfaceBlockBlock> _conveyorSurfacesList = new BlockCollection<StructureBspConveyorSurfaceBlockBlock>();
      public BlockCollection<StructureBspBreakableSurfaceBlockBlock> _breakableSurfacesList = new BlockCollection<StructureBspBreakableSurfaceBlockBlock>();
      public BlockCollection<PathfindingDataBlockBlock> _pathfindingDataList = new BlockCollection<PathfindingDataBlockBlock>();
      public BlockCollection<StructureBspPathfindingEdgesBlockBlock> _pathfindingEdgesList = new BlockCollection<StructureBspPathfindingEdgesBlockBlock>();
      public BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock> _backgroundSoundPaletteList = new BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock>();
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock> _soundEnvironmentPaletteList = new BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock>();
      public BlockCollection<StructureBspMarkerBlockBlock> _markersList = new BlockCollection<StructureBspMarkerBlockBlock>();
      public BlockCollection<StructureBspRuntimeDecalBlockBlock> _runtimeDecalsList = new BlockCollection<StructureBspRuntimeDecalBlockBlock>();
      public BlockCollection<StructureBspEnvironmentObjectPaletteBlockBlock> _environmentObjectPaletteList = new BlockCollection<StructureBspEnvironmentObjectPaletteBlockBlock>();
      public BlockCollection<StructureBspEnvironmentObjectBlockBlock> _environmentObjectsList = new BlockCollection<StructureBspEnvironmentObjectBlockBlock>();
      public BlockCollection<StructureBspLightmapDataBlockBlock> _lightmapsList = new BlockCollection<StructureBspLightmapDataBlockBlock>();
      public BlockCollection<GlobalMapLeafBlockBlock> _leafMapLeavesList = new BlockCollection<GlobalMapLeafBlockBlock>();
      public BlockCollection<GlobalLeafConnectionBlockBlock> _leafMapConnectionsList = new BlockCollection<GlobalLeafConnectionBlockBlock>();
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> _errorsList = new BlockCollection<GlobalErrorReportCategoriesBlockBlock>();
      public BlockCollection<StructureBspPrecomputedLightingBlockBlock> _precomputedLightingList = new BlockCollection<StructureBspPrecomputedLightingBlockBlock>();
      public BlockCollection<StructureBspInstancedGeometryDefinitionBlockBlock> _instancedGeometriesDefinitionsList = new BlockCollection<StructureBspInstancedGeometryDefinitionBlockBlock>();
      public BlockCollection<StructureBspInstancedGeometryInstancesBlockBlock> _instancedGeometryInstancesList = new BlockCollection<StructureBspInstancedGeometryInstancesBlockBlock>();
      public BlockCollection<StructureBspSoundClusterBlockBlock> _ambienceSoundClustersList = new BlockCollection<StructureBspSoundClusterBlockBlock>();
      public BlockCollection<StructureBspSoundClusterBlockBlock> _reverbSoundClustersList = new BlockCollection<StructureBspSoundClusterBlockBlock>();
      public BlockCollection<TransparentPlanesBlockBlock> _transparentPlanesList = new BlockCollection<TransparentPlanesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoBlockBlock> _debugInfoList = new BlockCollection<StructureBspDebugInfoBlockBlock>();
      public BlockCollection<BreakableSurfaceKeyTableBlockBlock> _breakableSurfaceKeyTableList = new BlockCollection<BreakableSurfaceKeyTableBlockBlock>();
      public BlockCollection<GlobalWaterDefinitionsBlockBlock> _waterDefinitionsList = new BlockCollection<GlobalWaterDefinitionsBlockBlock>();
      public BlockCollection<StructurePortalDeviceMappingBlockBlock> _portaldeviceMappingList = new BlockCollection<StructurePortalDeviceMappingBlockBlock>();
      public BlockCollection<StructureBspAudibilityBlockBlock> _audibilityList = new BlockCollection<StructureBspAudibilityBlockBlock>();
      public BlockCollection<StructureBspFakeLightprobesBlockBlock> _objectFakeLightprobesList = new BlockCollection<StructureBspFakeLightprobesBlockBlock>();
      public BlockCollection<DecoratorPlacementDefinitionBlockBlock> _decorators2List = new BlockCollection<DecoratorPlacementDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalStructurePhysicsStructBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(24);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(96);
        this._unnamed4 = new Pad(4);
      }
      public BlockCollection<GlobalTagImportInfoBlockBlock> ImportInfo {
        get {
          return this._importInfoList;
        }
      }
      public BlockCollection<StructureCollisionMaterialsBlockBlock> CollisionMaterials {
        get {
          return this._collisionMaterialsList;
        }
      }
      public BlockCollection<GlobalCollisionBspBlockBlock> CollisionBSP {
        get {
          return this._collisionBSPList;
        }
      }
      public BlockCollection<UNUSEDStructureBspNodeBlockBlock> UNUSEDNodes {
        get {
          return this._uNUSEDNodesList;
        }
      }
      public BlockCollection<StructureBspLeafBlockBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<StructureBspSurfaceReferenceBlockBlock> SurfaceReferences {
        get {
          return this._surfaceReferencesList;
        }
      }
      public BlockCollection<StructureBspClusterPortalBlockBlock> ClusterPortals {
        get {
          return this._clusterPortalsList;
        }
      }
      public BlockCollection<StructureBspFogPlaneBlockBlock> FogPlanes {
        get {
          return this._fogPlanesList;
        }
      }
      public BlockCollection<StructureBspWeatherPaletteBlockBlock> WeatherPalette {
        get {
          return this._weatherPaletteList;
        }
      }
      public BlockCollection<StructureBspWeatherPolyhedronBlockBlock> WeatherPolyhedra {
        get {
          return this._weatherPolyhedraList;
        }
      }
      public BlockCollection<StructureBspDetailObjectDataBlockBlock> DetailObjects {
        get {
          return this._detailObjectsList;
        }
      }
      public BlockCollection<StructureBspClusterBlockBlock> Clusters {
        get {
          return this._clustersList;
        }
      }
      public BlockCollection<GlobalGeometryMaterialBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<StructureBspSkyOwnerClusterBlockBlock> SkyOwnerCluster {
        get {
          return this._skyOwnerClusterList;
        }
      }
      public BlockCollection<StructureBspConveyorSurfaceBlockBlock> ConveyorSurfaces {
        get {
          return this._conveyorSurfacesList;
        }
      }
      public BlockCollection<StructureBspBreakableSurfaceBlockBlock> BreakableSurfaces {
        get {
          return this._breakableSurfacesList;
        }
      }
      public BlockCollection<PathfindingDataBlockBlock> PathfindingData {
        get {
          return this._pathfindingDataList;
        }
      }
      public BlockCollection<StructureBspPathfindingEdgesBlockBlock> PathfindingEdges {
        get {
          return this._pathfindingEdgesList;
        }
      }
      public BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock> BackgroundSoundPalette {
        get {
          return this._backgroundSoundPaletteList;
        }
      }
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock> SoundEnvironmentPalette {
        get {
          return this._soundEnvironmentPaletteList;
        }
      }
      public BlockCollection<StructureBspMarkerBlockBlock> Markers {
        get {
          return this._markersList;
        }
      }
      public BlockCollection<StructureBspRuntimeDecalBlockBlock> RuntimeDecals {
        get {
          return this._runtimeDecalsList;
        }
      }
      public BlockCollection<StructureBspEnvironmentObjectPaletteBlockBlock> EnvironmentObjectPalette {
        get {
          return this._environmentObjectPaletteList;
        }
      }
      public BlockCollection<StructureBspEnvironmentObjectBlockBlock> EnvironmentObjects {
        get {
          return this._environmentObjectsList;
        }
      }
      public BlockCollection<StructureBspLightmapDataBlockBlock> Lightmaps {
        get {
          return this._lightmapsList;
        }
      }
      public BlockCollection<GlobalMapLeafBlockBlock> LeafMapLeaves {
        get {
          return this._leafMapLeavesList;
        }
      }
      public BlockCollection<GlobalLeafConnectionBlockBlock> LeafMapConnections {
        get {
          return this._leafMapConnectionsList;
        }
      }
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public BlockCollection<StructureBspPrecomputedLightingBlockBlock> PrecomputedLighting {
        get {
          return this._precomputedLightingList;
        }
      }
      public BlockCollection<StructureBspInstancedGeometryDefinitionBlockBlock> InstancedGeometriesDefinitions {
        get {
          return this._instancedGeometriesDefinitionsList;
        }
      }
      public BlockCollection<StructureBspInstancedGeometryInstancesBlockBlock> InstancedGeometryInstances {
        get {
          return this._instancedGeometryInstancesList;
        }
      }
      public BlockCollection<StructureBspSoundClusterBlockBlock> AmbienceSoundClusters {
        get {
          return this._ambienceSoundClustersList;
        }
      }
      public BlockCollection<StructureBspSoundClusterBlockBlock> ReverbSoundClusters {
        get {
          return this._reverbSoundClustersList;
        }
      }
      public BlockCollection<TransparentPlanesBlockBlock> TransparentPlanes {
        get {
          return this._transparentPlanesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoBlockBlock> DebugInfo {
        get {
          return this._debugInfoList;
        }
      }
      public BlockCollection<BreakableSurfaceKeyTableBlockBlock> BreakableSurfaceKeyTable {
        get {
          return this._breakableSurfaceKeyTableList;
        }
      }
      public BlockCollection<GlobalWaterDefinitionsBlockBlock> WaterDefinitions {
        get {
          return this._waterDefinitionsList;
        }
      }
      public BlockCollection<StructurePortalDeviceMappingBlockBlock> PortaldeviceMapping {
        get {
          return this._portaldeviceMappingList;
        }
      }
      public BlockCollection<StructureBspAudibilityBlockBlock> Audibility {
        get {
          return this._audibilityList;
        }
      }
      public BlockCollection<StructureBspFakeLightprobesBlockBlock> ObjectFakeLightprobes {
        get {
          return this._objectFakeLightprobesList;
        }
      }
      public BlockCollection<DecoratorPlacementDefinitionBlockBlock> Decorators2 {
        get {
          return this._decorators2List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_decorators.Value);
for (int x=0; x<ImportInfo.BlockCount; x++)
{
  IBlock block = ImportInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CollisionMaterials.BlockCount; x++)
{
  IBlock block = CollisionMaterials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CollisionBSP.BlockCount; x++)
{
  IBlock block = CollisionBSP.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<UNUSEDNodes.BlockCount; x++)
{
  IBlock block = UNUSEDNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Leaves.BlockCount; x++)
{
  IBlock block = Leaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SurfaceReferences.BlockCount; x++)
{
  IBlock block = SurfaceReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterPortals.BlockCount; x++)
{
  IBlock block = ClusterPortals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogPlanes.BlockCount; x++)
{
  IBlock block = FogPlanes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeatherPalette.BlockCount; x++)
{
  IBlock block = WeatherPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeatherPolyhedra.BlockCount; x++)
{
  IBlock block = WeatherPolyhedra.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DetailObjects.BlockCount; x++)
{
  IBlock block = DetailObjects.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Clusters.BlockCount; x++)
{
  IBlock block = Clusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SkyOwnerCluster.BlockCount; x++)
{
  IBlock block = SkyOwnerCluster.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ConveyorSurfaces.BlockCount; x++)
{
  IBlock block = ConveyorSurfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BreakableSurfaces.BlockCount; x++)
{
  IBlock block = BreakableSurfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingData.BlockCount; x++)
{
  IBlock block = PathfindingData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingEdges.BlockCount; x++)
{
  IBlock block = PathfindingEdges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BackgroundSoundPalette.BlockCount; x++)
{
  IBlock block = BackgroundSoundPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundEnvironmentPalette.BlockCount; x++)
{
  IBlock block = SoundEnvironmentPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Markers.BlockCount; x++)
{
  IBlock block = Markers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RuntimeDecals.BlockCount; x++)
{
  IBlock block = RuntimeDecals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EnvironmentObjectPalette.BlockCount; x++)
{
  IBlock block = EnvironmentObjectPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EnvironmentObjects.BlockCount; x++)
{
  IBlock block = EnvironmentObjects.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lightmaps.BlockCount; x++)
{
  IBlock block = Lightmaps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LeafMapLeaves.BlockCount; x++)
{
  IBlock block = LeafMapLeaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LeafMapConnections.BlockCount; x++)
{
  IBlock block = LeafMapConnections.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PrecomputedLighting.BlockCount; x++)
{
  IBlock block = PrecomputedLighting.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstancedGeometriesDefinitions.BlockCount; x++)
{
  IBlock block = InstancedGeometriesDefinitions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstancedGeometryInstances.BlockCount; x++)
{
  IBlock block = InstancedGeometryInstances.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AmbienceSoundClusters.BlockCount; x++)
{
  IBlock block = AmbienceSoundClusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ReverbSoundClusters.BlockCount; x++)
{
  IBlock block = ReverbSoundClusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TransparentPlanes.BlockCount; x++)
{
  IBlock block = TransparentPlanes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DebugInfo.BlockCount; x++)
{
  IBlock block = DebugInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BreakableSurfaceKeyTable.BlockCount; x++)
{
  IBlock block = BreakableSurfaceKeyTable.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WaterDefinitions.BlockCount; x++)
{
  IBlock block = WaterDefinitions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PortaldeviceMapping.BlockCount; x++)
{
  IBlock block = PortaldeviceMapping.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Audibility.BlockCount; x++)
{
  IBlock block = Audibility.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ObjectFakeLightprobes.BlockCount; x++)
{
  IBlock block = ObjectFakeLightprobes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decorators2.BlockCount; x++)
{
  IBlock block = Decorators2.GetBlock(x);
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
      public Real VehicleFloor {
        get {
          return this._vehicleFloor;
        }
        set {
          this._vehicleFloor = value;
        }
      }
      public Real VehicleCeiling {
        get {
          return this._vehicleCeiling;
        }
        set {
          this._vehicleCeiling = value;
        }
      }
      public RealBounds WorldBoundsX {
        get {
          return this._worldBoundsX;
        }
        set {
          this._worldBoundsX = value;
        }
      }
      public RealBounds WorldBoundsY {
        get {
          return this._worldBoundsY;
        }
        set {
          this._worldBoundsY = value;
        }
      }
      public RealBounds WorldBoundsZ {
        get {
          return this._worldBoundsZ;
        }
        set {
          this._worldBoundsZ = value;
        }
      }
      public Data ClusterData {
        get {
          return this._clusterData;
        }
        set {
          this._clusterData = value;
        }
      }
      public Data SoundPASData {
        get {
          return this._soundPASData;
        }
        set {
          this._soundPASData = value;
        }
      }
      public Real VehicleSpericalLimitRadius {
        get {
          return this._vehicleSpericalLimitRadius;
        }
        set {
          this._vehicleSpericalLimitRadius = value;
        }
      }
      public RealPoint3D VehicleSpericalLimitCenter {
        get {
          return this._vehicleSpericalLimitCenter;
        }
        set {
          this._vehicleSpericalLimitCenter = value;
        }
      }
      public TagReference Decorators {
        get {
          return this._decorators;
        }
        set {
          this._decorators = value;
        }
      }
      public Data MoppCode {
        get {
          return this._moppCode;
        }
        set {
          this._moppCode = value;
        }
      }
      public RealPoint3D MoppBoundsMin {
        get {
          return this._moppBoundsMin;
        }
        set {
          this._moppBoundsMin = value;
        }
      }
      public RealPoint3D MoppBoundsMax {
        get {
          return this._moppBoundsMax;
        }
        set {
          this._moppBoundsMax = value;
        }
      }
      public Data BreakableSurfacesMoppCode {
        get {
          return this._breakableSurfacesMoppCode;
        }
        set {
          this._breakableSurfacesMoppCode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _importInfo.Read(reader);
        _unnamed0.Read(reader);
        _collisionMaterials.Read(reader);
        _collisionBSP.Read(reader);
        _vehicleFloor.Read(reader);
        _vehicleCeiling.Read(reader);
        _uNUSEDNodes.Read(reader);
        _leaves.Read(reader);
        _worldBoundsX.Read(reader);
        _worldBoundsY.Read(reader);
        _worldBoundsZ.Read(reader);
        _surfaceReferences.Read(reader);
        _clusterData.Read(reader);
        _clusterPortals.Read(reader);
        _fogPlanes.Read(reader);
        _unnamed1.Read(reader);
        _weatherPalette.Read(reader);
        _weatherPolyhedra.Read(reader);
        _detailObjects.Read(reader);
        _clusters.Read(reader);
        _materials.Read(reader);
        _skyOwnerCluster.Read(reader);
        _conveyorSurfaces.Read(reader);
        _breakableSurfaces.Read(reader);
        _pathfindingData.Read(reader);
        _pathfindingEdges.Read(reader);
        _backgroundSoundPalette.Read(reader);
        _soundEnvironmentPalette.Read(reader);
        _soundPASData.Read(reader);
        _markers.Read(reader);
        _runtimeDecals.Read(reader);
        _environmentObjectPalette.Read(reader);
        _environmentObjects.Read(reader);
        _lightmaps.Read(reader);
        _unnamed2.Read(reader);
        _leafMapLeaves.Read(reader);
        _leafMapConnections.Read(reader);
        _errors.Read(reader);
        _precomputedLighting.Read(reader);
        _instancedGeometriesDefinitions.Read(reader);
        _instancedGeometryInstances.Read(reader);
        _ambienceSoundClusters.Read(reader);
        _reverbSoundClusters.Read(reader);
        _transparentPlanes.Read(reader);
        _unnamed3.Read(reader);
        _vehicleSpericalLimitRadius.Read(reader);
        _vehicleSpericalLimitCenter.Read(reader);
        _debugInfo.Read(reader);
        _decorators.Read(reader);
        _moppCode.Read(reader);
        _unnamed4.Read(reader);
        _moppBoundsMin.Read(reader);
        _moppBoundsMax.Read(reader);
        _breakableSurfacesMoppCode.Read(reader);
        _breakableSurfaceKeyTable.Read(reader);
        _waterDefinitions.Read(reader);
        _portaldeviceMapping.Read(reader);
        _audibility.Read(reader);
        _objectFakeLightprobes.Read(reader);
        _decorators2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo.Add(new GlobalTagImportInfoBlockBlock());
          ImportInfo[x].Read(reader);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials.Add(new StructureCollisionMaterialsBlockBlock());
          CollisionMaterials[x].Read(reader);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _collisionBSP.Count); x = (x + 1)) {
          CollisionBSP.Add(new GlobalCollisionBspBlockBlock());
          CollisionBSP[x].Read(reader);
        }
        for (x = 0; (x < _collisionBSP.Count); x = (x + 1)) {
          CollisionBSP[x].ReadChildData(reader);
        }
        for (x = 0; (x < _uNUSEDNodes.Count); x = (x + 1)) {
          UNUSEDNodes.Add(new UNUSEDStructureBspNodeBlockBlock());
          UNUSEDNodes[x].Read(reader);
        }
        for (x = 0; (x < _uNUSEDNodes.Count); x = (x + 1)) {
          UNUSEDNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new StructureBspLeafBlockBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences.Add(new StructureBspSurfaceReferenceBlockBlock());
          SurfaceReferences[x].Read(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].ReadChildData(reader);
        }
        _clusterData.ReadBinary(reader);
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals.Add(new StructureBspClusterPortalBlockBlock());
          ClusterPortals[x].Read(reader);
        }
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes.Add(new StructureBspFogPlaneBlockBlock());
          FogPlanes[x].Read(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette.Add(new StructureBspWeatherPaletteBlockBlock());
          WeatherPalette[x].Read(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra.Add(new StructureBspWeatherPolyhedronBlockBlock());
          WeatherPolyhedra[x].Read(reader);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects.Add(new StructureBspDetailObjectDataBlockBlock());
          DetailObjects[x].Read(reader);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters.Add(new StructureBspClusterBlockBlock());
          Clusters[x].Read(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new GlobalGeometryMaterialBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _skyOwnerCluster.Count); x = (x + 1)) {
          SkyOwnerCluster.Add(new StructureBspSkyOwnerClusterBlockBlock());
          SkyOwnerCluster[x].Read(reader);
        }
        for (x = 0; (x < _skyOwnerCluster.Count); x = (x + 1)) {
          SkyOwnerCluster[x].ReadChildData(reader);
        }
        for (x = 0; (x < _conveyorSurfaces.Count); x = (x + 1)) {
          ConveyorSurfaces.Add(new StructureBspConveyorSurfaceBlockBlock());
          ConveyorSurfaces[x].Read(reader);
        }
        for (x = 0; (x < _conveyorSurfaces.Count); x = (x + 1)) {
          ConveyorSurfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces.Add(new StructureBspBreakableSurfaceBlockBlock());
          BreakableSurfaces[x].Read(reader);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingData.Count); x = (x + 1)) {
          PathfindingData.Add(new PathfindingDataBlockBlock());
          PathfindingData[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingData.Count); x = (x + 1)) {
          PathfindingData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges.Add(new StructureBspPathfindingEdgesBlockBlock());
          PathfindingEdges[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette.Add(new StructureBspBackgroundSoundPaletteBlockBlock());
          BackgroundSoundPalette[x].Read(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette.Add(new StructureBspSoundEnvironmentPaletteBlockBlock());
          SoundEnvironmentPalette[x].Read(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].ReadChildData(reader);
        }
        _soundPASData.ReadBinary(reader);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new StructureBspMarkerBlockBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals.Add(new StructureBspRuntimeDecalBlockBlock());
          RuntimeDecals[x].Read(reader);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _environmentObjectPalette.Count); x = (x + 1)) {
          EnvironmentObjectPalette.Add(new StructureBspEnvironmentObjectPaletteBlockBlock());
          EnvironmentObjectPalette[x].Read(reader);
        }
        for (x = 0; (x < _environmentObjectPalette.Count); x = (x + 1)) {
          EnvironmentObjectPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _environmentObjects.Count); x = (x + 1)) {
          EnvironmentObjects.Add(new StructureBspEnvironmentObjectBlockBlock());
          EnvironmentObjects[x].Read(reader);
        }
        for (x = 0; (x < _environmentObjects.Count); x = (x + 1)) {
          EnvironmentObjects[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightmaps.Count); x = (x + 1)) {
          Lightmaps.Add(new StructureBspLightmapDataBlockBlock());
          Lightmaps[x].Read(reader);
        }
        for (x = 0; (x < _lightmaps.Count); x = (x + 1)) {
          Lightmaps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves.Add(new GlobalMapLeafBlockBlock());
          LeafMapLeaves[x].Read(reader);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leafMapConnections.Count); x = (x + 1)) {
          LeafMapConnections.Add(new GlobalLeafConnectionBlockBlock());
          LeafMapConnections[x].Read(reader);
        }
        for (x = 0; (x < _leafMapConnections.Count); x = (x + 1)) {
          LeafMapConnections[x].ReadChildData(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new GlobalErrorReportCategoriesBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _precomputedLighting.Count); x = (x + 1)) {
          PrecomputedLighting.Add(new StructureBspPrecomputedLightingBlockBlock());
          PrecomputedLighting[x].Read(reader);
        }
        for (x = 0; (x < _precomputedLighting.Count); x = (x + 1)) {
          PrecomputedLighting[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instancedGeometriesDefinitions.Count); x = (x + 1)) {
          InstancedGeometriesDefinitions.Add(new StructureBspInstancedGeometryDefinitionBlockBlock());
          InstancedGeometriesDefinitions[x].Read(reader);
        }
        for (x = 0; (x < _instancedGeometriesDefinitions.Count); x = (x + 1)) {
          InstancedGeometriesDefinitions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instancedGeometryInstances.Count); x = (x + 1)) {
          InstancedGeometryInstances.Add(new StructureBspInstancedGeometryInstancesBlockBlock());
          InstancedGeometryInstances[x].Read(reader);
        }
        for (x = 0; (x < _instancedGeometryInstances.Count); x = (x + 1)) {
          InstancedGeometryInstances[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ambienceSoundClusters.Count); x = (x + 1)) {
          AmbienceSoundClusters.Add(new StructureBspSoundClusterBlockBlock());
          AmbienceSoundClusters[x].Read(reader);
        }
        for (x = 0; (x < _ambienceSoundClusters.Count); x = (x + 1)) {
          AmbienceSoundClusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _reverbSoundClusters.Count); x = (x + 1)) {
          ReverbSoundClusters.Add(new StructureBspSoundClusterBlockBlock());
          ReverbSoundClusters[x].Read(reader);
        }
        for (x = 0; (x < _reverbSoundClusters.Count); x = (x + 1)) {
          ReverbSoundClusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _transparentPlanes.Count); x = (x + 1)) {
          TransparentPlanes.Add(new TransparentPlanesBlockBlock());
          TransparentPlanes[x].Read(reader);
        }
        for (x = 0; (x < _transparentPlanes.Count); x = (x + 1)) {
          TransparentPlanes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _debugInfo.Count); x = (x + 1)) {
          DebugInfo.Add(new StructureBspDebugInfoBlockBlock());
          DebugInfo[x].Read(reader);
        }
        for (x = 0; (x < _debugInfo.Count); x = (x + 1)) {
          DebugInfo[x].ReadChildData(reader);
        }
        _decorators.ReadString(reader);
        _moppCode.ReadBinary(reader);
        _breakableSurfacesMoppCode.ReadBinary(reader);
        for (x = 0; (x < _breakableSurfaceKeyTable.Count); x = (x + 1)) {
          BreakableSurfaceKeyTable.Add(new BreakableSurfaceKeyTableBlockBlock());
          BreakableSurfaceKeyTable[x].Read(reader);
        }
        for (x = 0; (x < _breakableSurfaceKeyTable.Count); x = (x + 1)) {
          BreakableSurfaceKeyTable[x].ReadChildData(reader);
        }
        for (x = 0; (x < _waterDefinitions.Count); x = (x + 1)) {
          WaterDefinitions.Add(new GlobalWaterDefinitionsBlockBlock());
          WaterDefinitions[x].Read(reader);
        }
        for (x = 0; (x < _waterDefinitions.Count); x = (x + 1)) {
          WaterDefinitions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _portaldeviceMapping.Count); x = (x + 1)) {
          PortaldeviceMapping.Add(new StructurePortalDeviceMappingBlockBlock());
          PortaldeviceMapping[x].Read(reader);
        }
        for (x = 0; (x < _portaldeviceMapping.Count); x = (x + 1)) {
          PortaldeviceMapping[x].ReadChildData(reader);
        }
        for (x = 0; (x < _audibility.Count); x = (x + 1)) {
          Audibility.Add(new StructureBspAudibilityBlockBlock());
          Audibility[x].Read(reader);
        }
        for (x = 0; (x < _audibility.Count); x = (x + 1)) {
          Audibility[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectFakeLightprobes.Count); x = (x + 1)) {
          ObjectFakeLightprobes.Add(new StructureBspFakeLightprobesBlockBlock());
          ObjectFakeLightprobes[x].Read(reader);
        }
        for (x = 0; (x < _objectFakeLightprobes.Count); x = (x + 1)) {
          ObjectFakeLightprobes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decorators2.Count); x = (x + 1)) {
          Decorators2.Add(new DecoratorPlacementDefinitionBlockBlock());
          Decorators2[x].Read(reader);
        }
        for (x = 0; (x < _decorators2.Count); x = (x + 1)) {
          Decorators2[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_importInfo.Count = ImportInfo.Count;
        _importInfo.Write(bw);
        _unnamed0.Write(bw);
_collisionMaterials.Count = CollisionMaterials.Count;
        _collisionMaterials.Write(bw);
_collisionBSP.Count = CollisionBSP.Count;
        _collisionBSP.Write(bw);
        _vehicleFloor.Write(bw);
        _vehicleCeiling.Write(bw);
_uNUSEDNodes.Count = UNUSEDNodes.Count;
        _uNUSEDNodes.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
        _worldBoundsX.Write(bw);
        _worldBoundsY.Write(bw);
        _worldBoundsZ.Write(bw);
_surfaceReferences.Count = SurfaceReferences.Count;
        _surfaceReferences.Write(bw);
        _clusterData.Write(bw);
_clusterPortals.Count = ClusterPortals.Count;
        _clusterPortals.Write(bw);
_fogPlanes.Count = FogPlanes.Count;
        _fogPlanes.Write(bw);
        _unnamed1.Write(bw);
_weatherPalette.Count = WeatherPalette.Count;
        _weatherPalette.Write(bw);
_weatherPolyhedra.Count = WeatherPolyhedra.Count;
        _weatherPolyhedra.Write(bw);
_detailObjects.Count = DetailObjects.Count;
        _detailObjects.Write(bw);
_clusters.Count = Clusters.Count;
        _clusters.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_skyOwnerCluster.Count = SkyOwnerCluster.Count;
        _skyOwnerCluster.Write(bw);
_conveyorSurfaces.Count = ConveyorSurfaces.Count;
        _conveyorSurfaces.Write(bw);
_breakableSurfaces.Count = BreakableSurfaces.Count;
        _breakableSurfaces.Write(bw);
_pathfindingData.Count = PathfindingData.Count;
        _pathfindingData.Write(bw);
_pathfindingEdges.Count = PathfindingEdges.Count;
        _pathfindingEdges.Write(bw);
_backgroundSoundPalette.Count = BackgroundSoundPalette.Count;
        _backgroundSoundPalette.Write(bw);
_soundEnvironmentPalette.Count = SoundEnvironmentPalette.Count;
        _soundEnvironmentPalette.Write(bw);
        _soundPASData.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
_runtimeDecals.Count = RuntimeDecals.Count;
        _runtimeDecals.Write(bw);
_environmentObjectPalette.Count = EnvironmentObjectPalette.Count;
        _environmentObjectPalette.Write(bw);
_environmentObjects.Count = EnvironmentObjects.Count;
        _environmentObjects.Write(bw);
_lightmaps.Count = Lightmaps.Count;
        _lightmaps.Write(bw);
        _unnamed2.Write(bw);
_leafMapLeaves.Count = LeafMapLeaves.Count;
        _leafMapLeaves.Write(bw);
_leafMapConnections.Count = LeafMapConnections.Count;
        _leafMapConnections.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
_precomputedLighting.Count = PrecomputedLighting.Count;
        _precomputedLighting.Write(bw);
_instancedGeometriesDefinitions.Count = InstancedGeometriesDefinitions.Count;
        _instancedGeometriesDefinitions.Write(bw);
_instancedGeometryInstances.Count = InstancedGeometryInstances.Count;
        _instancedGeometryInstances.Write(bw);
_ambienceSoundClusters.Count = AmbienceSoundClusters.Count;
        _ambienceSoundClusters.Write(bw);
_reverbSoundClusters.Count = ReverbSoundClusters.Count;
        _reverbSoundClusters.Write(bw);
_transparentPlanes.Count = TransparentPlanes.Count;
        _transparentPlanes.Write(bw);
        _unnamed3.Write(bw);
        _vehicleSpericalLimitRadius.Write(bw);
        _vehicleSpericalLimitCenter.Write(bw);
_debugInfo.Count = DebugInfo.Count;
        _debugInfo.Write(bw);
        _decorators.Write(bw);
        _moppCode.Write(bw);
        _unnamed4.Write(bw);
        _moppBoundsMin.Write(bw);
        _moppBoundsMax.Write(bw);
        _breakableSurfacesMoppCode.Write(bw);
_breakableSurfaceKeyTable.Count = BreakableSurfaceKeyTable.Count;
        _breakableSurfaceKeyTable.Write(bw);
_waterDefinitions.Count = WaterDefinitions.Count;
        _waterDefinitions.Write(bw);
_portaldeviceMapping.Count = PortaldeviceMapping.Count;
        _portaldeviceMapping.Write(bw);
_audibility.Count = Audibility.Count;
        _audibility.Write(bw);
_objectFakeLightprobes.Count = ObjectFakeLightprobes.Count;
        _objectFakeLightprobes.Write(bw);
_decorators2.Count = Decorators2.Count;
        _decorators2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].Write(writer);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].Write(writer);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _collisionBSP.Count); x = (x + 1)) {
          CollisionBSP[x].Write(writer);
        }
        for (x = 0; (x < _collisionBSP.Count); x = (x + 1)) {
          CollisionBSP[x].WriteChildData(writer);
        }
        for (x = 0; (x < _uNUSEDNodes.Count); x = (x + 1)) {
          UNUSEDNodes[x].Write(writer);
        }
        for (x = 0; (x < _uNUSEDNodes.Count); x = (x + 1)) {
          UNUSEDNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].Write(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].Write(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].WriteChildData(writer);
        }
        _clusterData.WriteBinary(writer);
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].Write(writer);
        }
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].Write(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].Write(writer);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra[x].Write(writer);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra[x].WriteChildData(writer);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].Write(writer);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].Write(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _skyOwnerCluster.Count); x = (x + 1)) {
          SkyOwnerCluster[x].Write(writer);
        }
        for (x = 0; (x < _skyOwnerCluster.Count); x = (x + 1)) {
          SkyOwnerCluster[x].WriteChildData(writer);
        }
        for (x = 0; (x < _conveyorSurfaces.Count); x = (x + 1)) {
          ConveyorSurfaces[x].Write(writer);
        }
        for (x = 0; (x < _conveyorSurfaces.Count); x = (x + 1)) {
          ConveyorSurfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].Write(writer);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingData.Count); x = (x + 1)) {
          PathfindingData[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingData.Count); x = (x + 1)) {
          PathfindingData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].Write(writer);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].Write(writer);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].WriteChildData(writer);
        }
        _soundPASData.WriteBinary(writer);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].Write(writer);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].Write(writer);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _environmentObjectPalette.Count); x = (x + 1)) {
          EnvironmentObjectPalette[x].Write(writer);
        }
        for (x = 0; (x < _environmentObjectPalette.Count); x = (x + 1)) {
          EnvironmentObjectPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _environmentObjects.Count); x = (x + 1)) {
          EnvironmentObjects[x].Write(writer);
        }
        for (x = 0; (x < _environmentObjects.Count); x = (x + 1)) {
          EnvironmentObjects[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightmaps.Count); x = (x + 1)) {
          Lightmaps[x].Write(writer);
        }
        for (x = 0; (x < _lightmaps.Count); x = (x + 1)) {
          Lightmaps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].Write(writer);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leafMapConnections.Count); x = (x + 1)) {
          LeafMapConnections[x].Write(writer);
        }
        for (x = 0; (x < _leafMapConnections.Count); x = (x + 1)) {
          LeafMapConnections[x].WriteChildData(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _precomputedLighting.Count); x = (x + 1)) {
          PrecomputedLighting[x].Write(writer);
        }
        for (x = 0; (x < _precomputedLighting.Count); x = (x + 1)) {
          PrecomputedLighting[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instancedGeometriesDefinitions.Count); x = (x + 1)) {
          InstancedGeometriesDefinitions[x].Write(writer);
        }
        for (x = 0; (x < _instancedGeometriesDefinitions.Count); x = (x + 1)) {
          InstancedGeometriesDefinitions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instancedGeometryInstances.Count); x = (x + 1)) {
          InstancedGeometryInstances[x].Write(writer);
        }
        for (x = 0; (x < _instancedGeometryInstances.Count); x = (x + 1)) {
          InstancedGeometryInstances[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ambienceSoundClusters.Count); x = (x + 1)) {
          AmbienceSoundClusters[x].Write(writer);
        }
        for (x = 0; (x < _ambienceSoundClusters.Count); x = (x + 1)) {
          AmbienceSoundClusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _reverbSoundClusters.Count); x = (x + 1)) {
          ReverbSoundClusters[x].Write(writer);
        }
        for (x = 0; (x < _reverbSoundClusters.Count); x = (x + 1)) {
          ReverbSoundClusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _transparentPlanes.Count); x = (x + 1)) {
          TransparentPlanes[x].Write(writer);
        }
        for (x = 0; (x < _transparentPlanes.Count); x = (x + 1)) {
          TransparentPlanes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _debugInfo.Count); x = (x + 1)) {
          DebugInfo[x].Write(writer);
        }
        for (x = 0; (x < _debugInfo.Count); x = (x + 1)) {
          DebugInfo[x].WriteChildData(writer);
        }
        _decorators.WriteString(writer);
        _moppCode.WriteBinary(writer);
        _breakableSurfacesMoppCode.WriteBinary(writer);
        for (x = 0; (x < _breakableSurfaceKeyTable.Count); x = (x + 1)) {
          BreakableSurfaceKeyTable[x].Write(writer);
        }
        for (x = 0; (x < _breakableSurfaceKeyTable.Count); x = (x + 1)) {
          BreakableSurfaceKeyTable[x].WriteChildData(writer);
        }
        for (x = 0; (x < _waterDefinitions.Count); x = (x + 1)) {
          WaterDefinitions[x].Write(writer);
        }
        for (x = 0; (x < _waterDefinitions.Count); x = (x + 1)) {
          WaterDefinitions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _portaldeviceMapping.Count); x = (x + 1)) {
          PortaldeviceMapping[x].Write(writer);
        }
        for (x = 0; (x < _portaldeviceMapping.Count); x = (x + 1)) {
          PortaldeviceMapping[x].WriteChildData(writer);
        }
        for (x = 0; (x < _audibility.Count); x = (x + 1)) {
          Audibility[x].Write(writer);
        }
        for (x = 0; (x < _audibility.Count); x = (x + 1)) {
          Audibility[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objectFakeLightprobes.Count); x = (x + 1)) {
          ObjectFakeLightprobes[x].Write(writer);
        }
        for (x = 0; (x < _objectFakeLightprobes.Count); x = (x + 1)) {
          ObjectFakeLightprobes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decorators2.Count); x = (x + 1)) {
          Decorators2[x].Write(writer);
        }
        for (x = 0; (x < _decorators2.Count); x = (x + 1)) {
          Decorators2[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalTagImportInfoBlockBlock : IBlock {
      private LongInteger _build = new LongInteger();
      private LongerFixedLengthString _version = new LongerFixedLengthString();
      private FixedLengthString _importDate = new FixedLengthString();
      private FixedLengthString _culprit = new FixedLengthString();
      private Pad _unnamed0;
      private FixedLengthString _importTime = new FixedLengthString();
      private Pad _unnamed1;
      private Block _files = new Block();
      private Pad _unnamed2;
      public BlockCollection<TagImportFileBlockBlock> _filesList = new BlockCollection<TagImportFileBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalTagImportInfoBlockBlock() {
        this._unnamed0 = new Pad(96);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(128);
      }
      public BlockCollection<TagImportFileBlockBlock> Files {
        get {
          return this._filesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Files.BlockCount; x++)
{
  IBlock block = Files.GetBlock(x);
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
      public LongInteger Build {
        get {
          return this._build;
        }
        set {
          this._build = value;
        }
      }
      public LongerFixedLengthString Version {
        get {
          return this._version;
        }
        set {
          this._version = value;
        }
      }
      public FixedLengthString ImportDate {
        get {
          return this._importDate;
        }
        set {
          this._importDate = value;
        }
      }
      public FixedLengthString Culprit {
        get {
          return this._culprit;
        }
        set {
          this._culprit = value;
        }
      }
      public FixedLengthString ImportTime {
        get {
          return this._importTime;
        }
        set {
          this._importTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _build.Read(reader);
        _version.Read(reader);
        _importDate.Read(reader);
        _culprit.Read(reader);
        _unnamed0.Read(reader);
        _importTime.Read(reader);
        _unnamed1.Read(reader);
        _files.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files.Add(new TagImportFileBlockBlock());
          Files[x].Read(reader);
        }
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _build.Write(bw);
        _version.Write(bw);
        _importDate.Write(bw);
        _culprit.Write(bw);
        _unnamed0.Write(bw);
        _importTime.Write(bw);
        _unnamed1.Write(bw);
_files.Count = Files.Count;
        _files.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].Write(writer);
        }
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].WriteChildData(writer);
        }
      }
    }
    public class TagImportFileBlockBlock : IBlock {
      private LongerFixedLengthString _path = new LongerFixedLengthString();
      private FixedLengthString _modificationDate = new FixedLengthString();
      private Skip _unnamed0;
      private Pad _unnamed1;
      private LongInteger _checksum = new LongInteger();
      private LongInteger _size = new LongInteger();
      private Data _zippedData = new Data();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public TagImportFileBlockBlock() {
        this._unnamed0 = new Skip(8);
        this._unnamed1 = new Pad(88);
        this._unnamed2 = new Pad(128);
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
      public LongerFixedLengthString Path {
        get {
          return this._path;
        }
        set {
          this._path = value;
        }
      }
      public FixedLengthString ModificationDate {
        get {
          return this._modificationDate;
        }
        set {
          this._modificationDate = value;
        }
      }
      public LongInteger Checksum {
        get {
          return this._checksum;
        }
        set {
          this._checksum = value;
        }
      }
      public LongInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public Data ZippedData {
        get {
          return this._zippedData;
        }
        set {
          this._zippedData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _path.Read(reader);
        _modificationDate.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _checksum.Read(reader);
        _size.Read(reader);
        _zippedData.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _zippedData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _path.Write(bw);
        _modificationDate.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _checksum.Write(bw);
        _size.Write(bw);
        _zippedData.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _zippedData.WriteBinary(writer);
      }
    }
    public class StructureCollisionMaterialsBlockBlock : IBlock {
      private TagReference _oldShader = new TagReference();
      private Pad _unnamed0;
      private ShortBlockIndex _conveyorSurfaceIndex = new ShortBlockIndex();
      private TagReference _newShader = new TagReference();
public event System.EventHandler BlockNameChanged;
      public StructureCollisionMaterialsBlockBlock() {
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_oldShader.Value);
references.Add(_newShader.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference OldShader {
        get {
          return this._oldShader;
        }
        set {
          this._oldShader = value;
        }
      }
      public ShortBlockIndex ConveyorSurfaceIndex {
        get {
          return this._conveyorSurfaceIndex;
        }
        set {
          this._conveyorSurfaceIndex = value;
        }
      }
      public TagReference NewShader {
        get {
          return this._newShader;
        }
        set {
          this._newShader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _oldShader.Read(reader);
        _unnamed0.Read(reader);
        _conveyorSurfaceIndex.Read(reader);
        _newShader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _oldShader.ReadString(reader);
        _newShader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _oldShader.Write(bw);
        _unnamed0.Write(bw);
        _conveyorSurfaceIndex.Write(bw);
        _newShader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _oldShader.WriteString(writer);
        _newShader.WriteString(writer);
      }
    }
    public class GlobalCollisionBspBlockBlock : IBlock {
      private Block _bSP3DNodes = new Block();
      private Block _planes = new Block();
      private Block _leaves = new Block();
      private Block _bSP2DReferences = new Block();
      private Block _bSP2DNodes = new Block();
      private Block _surfaces = new Block();
      private Block _edges = new Block();
      private Block _vertices = new Block();
      public BlockCollection<Bsp3dNodesBlockBlock> _bSP3DNodesList = new BlockCollection<Bsp3dNodesBlockBlock>();
      public BlockCollection<PlanesBlockBlock> _planesList = new BlockCollection<PlanesBlockBlock>();
      public BlockCollection<LeavesBlockBlock> _leavesList = new BlockCollection<LeavesBlockBlock>();
      public BlockCollection<Bsp2dReferencesBlockBlock> _bSP2DReferencesList = new BlockCollection<Bsp2dReferencesBlockBlock>();
      public BlockCollection<Bsp2dNodesBlockBlock> _bSP2DNodesList = new BlockCollection<Bsp2dNodesBlockBlock>();
      public BlockCollection<SurfacesBlockBlock> _surfacesList = new BlockCollection<SurfacesBlockBlock>();
      public BlockCollection<EdgesBlockBlock> _edgesList = new BlockCollection<EdgesBlockBlock>();
      public BlockCollection<VerticesBlockBlock> _verticesList = new BlockCollection<VerticesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalCollisionBspBlockBlock() {
      }
      public BlockCollection<Bsp3dNodesBlockBlock> BSP3DNodes {
        get {
          return this._bSP3DNodesList;
        }
      }
      public BlockCollection<PlanesBlockBlock> Planes {
        get {
          return this._planesList;
        }
      }
      public BlockCollection<LeavesBlockBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<Bsp2dReferencesBlockBlock> BSP2DReferences {
        get {
          return this._bSP2DReferencesList;
        }
      }
      public BlockCollection<Bsp2dNodesBlockBlock> BSP2DNodes {
        get {
          return this._bSP2DNodesList;
        }
      }
      public BlockCollection<SurfacesBlockBlock> Surfaces {
        get {
          return this._surfacesList;
        }
      }
      public BlockCollection<EdgesBlockBlock> Edges {
        get {
          return this._edgesList;
        }
      }
      public BlockCollection<VerticesBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<BSP3DNodes.BlockCount; x++)
{
  IBlock block = BSP3DNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Planes.BlockCount; x++)
{
  IBlock block = Planes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Leaves.BlockCount; x++)
{
  IBlock block = Leaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSP2DReferences.BlockCount; x++)
{
  IBlock block = BSP2DReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSP2DNodes.BlockCount; x++)
{
  IBlock block = BSP2DNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Surfaces.BlockCount; x++)
{
  IBlock block = Surfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Edges.BlockCount; x++)
{
  IBlock block = Edges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
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
        _bSP3DNodes.Read(reader);
        _planes.Read(reader);
        _leaves.Read(reader);
        _bSP2DReferences.Read(reader);
        _bSP2DNodes.Read(reader);
        _surfaces.Read(reader);
        _edges.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes.Add(new Bsp3dNodesBlockBlock());
          BSP3DNodes[x].Read(reader);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new PlanesBlockBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new LeavesBlockBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences.Add(new Bsp2dReferencesBlockBlock());
          BSP2DReferences[x].Read(reader);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes.Add(new Bsp2dNodesBlockBlock());
          BSP2DNodes[x].Read(reader);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces.Add(new SurfacesBlockBlock());
          Surfaces[x].Read(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges.Add(new EdgesBlockBlock());
          Edges[x].Read(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new VerticesBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_bSP3DNodes.Count = BSP3DNodes.Count;
        _bSP3DNodes.Write(bw);
_planes.Count = Planes.Count;
        _planes.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
_bSP2DReferences.Count = BSP2DReferences.Count;
        _bSP2DReferences.Write(bw);
_bSP2DNodes.Count = BSP2DNodes.Count;
        _bSP2DNodes.Write(bw);
_surfaces.Count = Surfaces.Count;
        _surfaces.Write(bw);
_edges.Count = Edges.Count;
        _edges.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].Write(writer);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].Write(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].Write(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].Write(writer);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].Write(writer);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].Write(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].Write(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class Bsp3dNodesBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public Bsp3dNodesBlockBlock() {
        this._unnamed0 = new Skip(8);
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
    public class PlanesBlockBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public PlanesBlockBlock() {
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
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LeavesBlockBlock : IBlock {
      private Flags _flags;
      private CharInteger _bSP2DReferenceCount = new CharInteger();
      private ShortInteger _firstBSP2DReference = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public LeavesBlockBlock() {
        this._flags = new Flags(1);
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
      public CharInteger BSP2DReferenceCount {
        get {
          return this._bSP2DReferenceCount;
        }
        set {
          this._bSP2DReferenceCount = value;
        }
      }
      public ShortInteger FirstBSP2DReference {
        get {
          return this._firstBSP2DReference;
        }
        set {
          this._firstBSP2DReference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bSP2DReferenceCount.Read(reader);
        _firstBSP2DReference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bSP2DReferenceCount.Write(bw);
        _firstBSP2DReference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dReferencesBlockBlock : IBlock {
      private ShortInteger _plane = new ShortInteger();
      private ShortInteger _bSP2DNode = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dReferencesBlockBlock() {
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
      public ShortInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public ShortInteger BSP2DNode {
        get {
          return this._bSP2DNode;
        }
        set {
          this._bSP2DNode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _bSP2DNode.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _bSP2DNode.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dNodesBlockBlock : IBlock {
      private RealPlane2D _plane = new RealPlane2D();
      private ShortInteger _leftChild = new ShortInteger();
      private ShortInteger _rightChild = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dNodesBlockBlock() {
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
      public RealPlane2D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public ShortInteger LeftChild {
        get {
          return this._leftChild;
        }
        set {
          this._leftChild = value;
        }
      }
      public ShortInteger RightChild {
        get {
          return this._rightChild;
        }
        set {
          this._rightChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _leftChild.Read(reader);
        _rightChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _leftChild.Write(bw);
        _rightChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SurfacesBlockBlock : IBlock {
      private ShortInteger _plane = new ShortInteger();
      private ShortInteger _firstEdge = new ShortInteger();
      private Flags _flags;
      private CharInteger _breakableSurface = new CharInteger();
      private ShortInteger _material = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SurfacesBlockBlock() {
        this._flags = new Flags(1);
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
      public ShortInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public ShortInteger FirstEdge {
        get {
          return this._firstEdge;
        }
        set {
          this._firstEdge = value;
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
      public CharInteger BreakableSurface {
        get {
          return this._breakableSurface;
        }
        set {
          this._breakableSurface = value;
        }
      }
      public ShortInteger Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _firstEdge.Read(reader);
        _flags.Read(reader);
        _breakableSurface.Read(reader);
        _material.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _firstEdge.Write(bw);
        _flags.Write(bw);
        _breakableSurface.Write(bw);
        _material.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EdgesBlockBlock : IBlock {
      private ShortInteger _startVertex = new ShortInteger();
      private ShortInteger _endVertex = new ShortInteger();
      private ShortInteger _forwardEdge = new ShortInteger();
      private ShortInteger _reverseEdge = new ShortInteger();
      private ShortInteger _leftSurface = new ShortInteger();
      private ShortInteger _rightSurface = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public EdgesBlockBlock() {
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
      public ShortInteger StartVertex {
        get {
          return this._startVertex;
        }
        set {
          this._startVertex = value;
        }
      }
      public ShortInteger EndVertex {
        get {
          return this._endVertex;
        }
        set {
          this._endVertex = value;
        }
      }
      public ShortInteger ForwardEdge {
        get {
          return this._forwardEdge;
        }
        set {
          this._forwardEdge = value;
        }
      }
      public ShortInteger ReverseEdge {
        get {
          return this._reverseEdge;
        }
        set {
          this._reverseEdge = value;
        }
      }
      public ShortInteger LeftSurface {
        get {
          return this._leftSurface;
        }
        set {
          this._leftSurface = value;
        }
      }
      public ShortInteger RightSurface {
        get {
          return this._rightSurface;
        }
        set {
          this._rightSurface = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _startVertex.Read(reader);
        _endVertex.Read(reader);
        _forwardEdge.Read(reader);
        _reverseEdge.Read(reader);
        _leftSurface.Read(reader);
        _rightSurface.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _startVertex.Write(bw);
        _endVertex.Write(bw);
        _forwardEdge.Write(bw);
        _reverseEdge.Write(bw);
        _leftSurface.Write(bw);
        _rightSurface.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class VerticesBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private ShortInteger _firstEdge = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public VerticesBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger FirstEdge {
        get {
          return this._firstEdge;
        }
        set {
          this._firstEdge = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _firstEdge.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _firstEdge.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UNUSEDStructureBspNodeBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public UNUSEDStructureBspNodeBlockBlock() {
        this._unnamed0 = new Skip(6);
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
    public class StructureBspLeafBlockBlock : IBlock {
      private ShortInteger _cluster = new ShortInteger();
      private ShortInteger _surfaceReferenceCount = new ShortInteger();
      private LongInteger _firstSurfaceReferenceIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspLeafBlockBlock() {
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
      public ShortInteger Cluster {
        get {
          return this._cluster;
        }
        set {
          this._cluster = value;
        }
      }
      public ShortInteger SurfaceReferenceCount {
        get {
          return this._surfaceReferenceCount;
        }
        set {
          this._surfaceReferenceCount = value;
        }
      }
      public LongInteger FirstSurfaceReferenceIndex {
        get {
          return this._firstSurfaceReferenceIndex;
        }
        set {
          this._firstSurfaceReferenceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _cluster.Read(reader);
        _surfaceReferenceCount.Read(reader);
        _firstSurfaceReferenceIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _cluster.Write(bw);
        _surfaceReferenceCount.Write(bw);
        _firstSurfaceReferenceIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspSurfaceReferenceBlockBlock : IBlock {
      private ShortInteger _stripIndex = new ShortInteger();
      private ShortInteger _lightmapTriangleIndex = new ShortInteger();
      private LongInteger _bSPNodeIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspSurfaceReferenceBlockBlock() {
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
      public ShortInteger StripIndex {
        get {
          return this._stripIndex;
        }
        set {
          this._stripIndex = value;
        }
      }
      public ShortInteger LightmapTriangleIndex {
        get {
          return this._lightmapTriangleIndex;
        }
        set {
          this._lightmapTriangleIndex = value;
        }
      }
      public LongInteger BSPNodeIndex {
        get {
          return this._bSPNodeIndex;
        }
        set {
          this._bSPNodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stripIndex.Read(reader);
        _lightmapTriangleIndex.Read(reader);
        _bSPNodeIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stripIndex.Write(bw);
        _lightmapTriangleIndex.Write(bw);
        _bSPNodeIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspClusterPortalBlockBlock : IBlock {
      private ShortInteger _backCluster = new ShortInteger();
      private ShortInteger _frontCluster = new ShortInteger();
      private LongInteger _planeIndex = new LongInteger();
      private RealPoint3D _centroid = new RealPoint3D();
      private Real _boundingRadius = new Real();
      private Flags _flags;
      private Block _vertices = new Block();
      public BlockCollection<StructureBspClusterPortalVertexBlockBlock> _verticesList = new BlockCollection<StructureBspClusterPortalVertexBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<StructureBspClusterPortalVertexBlockBlock> Vertices {
        get {
          return this._verticesList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortInteger BackCluster {
        get {
          return this._backCluster;
        }
        set {
          this._backCluster = value;
        }
      }
      public ShortInteger FrontCluster {
        get {
          return this._frontCluster;
        }
        set {
          this._frontCluster = value;
        }
      }
      public LongInteger PlaneIndex {
        get {
          return this._planeIndex;
        }
        set {
          this._planeIndex = value;
        }
      }
      public RealPoint3D Centroid {
        get {
          return this._centroid;
        }
        set {
          this._centroid = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _backCluster.Read(reader);
        _frontCluster.Read(reader);
        _planeIndex.Read(reader);
        _centroid.Read(reader);
        _boundingRadius.Read(reader);
        _flags.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new StructureBspClusterPortalVertexBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _backCluster.Write(bw);
        _frontCluster.Write(bw);
        _planeIndex.Write(bw);
        _centroid.Write(bw);
        _boundingRadius.Write(bw);
        _flags.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspClusterPortalVertexBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalVertexBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspFogPlaneBlockBlock : IBlock {
      private ShortInteger _scenarioPlanarFogIndex = new ShortInteger();
      private Pad _unnamed0;
      private RealPlane3D _plane = new RealPlane3D();
      private Flags _flags;
      private ShortInteger _priority = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogPlaneBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger ScenarioPlanarFogIndex {
        get {
          return this._scenarioPlanarFogIndex;
        }
        set {
          this._scenarioPlanarFogIndex = value;
        }
      }
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
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
      public ShortInteger Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scenarioPlanarFogIndex.Read(reader);
        _unnamed0.Read(reader);
        _plane.Read(reader);
        _flags.Read(reader);
        _priority.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scenarioPlanarFogIndex.Write(bw);
        _unnamed0.Write(bw);
        _plane.Write(bw);
        _flags.Write(bw);
        _priority.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspWeatherPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _weatherSystem = new TagReference();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private TagReference _wind = new TagReference();
      private RealVector3D _windDirection = new RealVector3D();
      private Real _windMagnitude = new Real();
      private Pad _unnamed3;
      private FixedLengthString _windScaleFunction = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weatherSystem.Value);
references.Add(_wind.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public TagReference WeatherSystem {
        get {
          return this._weatherSystem;
        }
        set {
          this._weatherSystem = value;
        }
      }
      public TagReference Wind {
        get {
          return this._wind;
        }
        set {
          this._wind = value;
        }
      }
      public RealVector3D WindDirection {
        get {
          return this._windDirection;
        }
        set {
          this._windDirection = value;
        }
      }
      public Real WindMagnitude {
        get {
          return this._windMagnitude;
        }
        set {
          this._windMagnitude = value;
        }
      }
      public FixedLengthString WindScaleFunction {
        get {
          return this._windScaleFunction;
        }
        set {
          this._windScaleFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _weatherSystem.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _wind.Read(reader);
        _windDirection.Read(reader);
        _windMagnitude.Read(reader);
        _unnamed3.Read(reader);
        _windScaleFunction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weatherSystem.ReadString(reader);
        _wind.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _weatherSystem.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _wind.Write(bw);
        _windDirection.Write(bw);
        _windMagnitude.Write(bw);
        _unnamed3.Write(bw);
        _windScaleFunction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weatherSystem.WriteString(writer);
        _wind.WriteString(writer);
      }
    }
    public class StructureBspWeatherPolyhedronBlockBlock : IBlock {
      private RealPoint3D _boundingSphereCenter = new RealPoint3D();
      private Real _boundingSphereRadius = new Real();
      private Block _planes = new Block();
      public BlockCollection<StructureBspWeatherPolyhedronPlaneBlockBlock> _planesList = new BlockCollection<StructureBspWeatherPolyhedronPlaneBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPolyhedronBlockBlock() {
      }
      public BlockCollection<StructureBspWeatherPolyhedronPlaneBlockBlock> Planes {
        get {
          return this._planesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Planes.BlockCount; x++)
{
  IBlock block = Planes.GetBlock(x);
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
      public RealPoint3D BoundingSphereCenter {
        get {
          return this._boundingSphereCenter;
        }
        set {
          this._boundingSphereCenter = value;
        }
      }
      public Real BoundingSphereRadius {
        get {
          return this._boundingSphereRadius;
        }
        set {
          this._boundingSphereRadius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _boundingSphereCenter.Read(reader);
        _boundingSphereRadius.Read(reader);
        _planes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new StructureBspWeatherPolyhedronPlaneBlockBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _boundingSphereCenter.Write(bw);
        _boundingSphereRadius.Write(bw);
_planes.Count = Planes.Count;
        _planes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].Write(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspWeatherPolyhedronPlaneBlockBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPolyhedronPlaneBlockBlock() {
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
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspDetailObjectDataBlockBlock : IBlock {
      private Block _cells = new Block();
      private Block _instances = new Block();
      private Block _counts = new Block();
      private Block _zReferenceVectors = new Block();
      private Pad _unnamed0;
      private Pad _unnamed1;
      public BlockCollection<GlobalDetailObjectCellsBlockBlock> _cellsList = new BlockCollection<GlobalDetailObjectCellsBlockBlock>();
      public BlockCollection<GlobalDetailObjectBlockBlock> _instancesList = new BlockCollection<GlobalDetailObjectBlockBlock>();
      public BlockCollection<GlobalDetailObjectCountsBlockBlock> _countsList = new BlockCollection<GlobalDetailObjectCountsBlockBlock>();
      public BlockCollection<GlobalZReferenceVectorBlockBlock> _zReferenceVectorsList = new BlockCollection<GlobalZReferenceVectorBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspDetailObjectDataBlockBlock() {
        this._unnamed0 = new Pad(1);
        this._unnamed1 = new Pad(3);
      }
      public BlockCollection<GlobalDetailObjectCellsBlockBlock> Cells {
        get {
          return this._cellsList;
        }
      }
      public BlockCollection<GlobalDetailObjectBlockBlock> Instances {
        get {
          return this._instancesList;
        }
      }
      public BlockCollection<GlobalDetailObjectCountsBlockBlock> Counts {
        get {
          return this._countsList;
        }
      }
      public BlockCollection<GlobalZReferenceVectorBlockBlock> ZReferenceVectors {
        get {
          return this._zReferenceVectorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Cells.BlockCount; x++)
{
  IBlock block = Cells.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Instances.BlockCount; x++)
{
  IBlock block = Instances.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Counts.BlockCount; x++)
{
  IBlock block = Counts.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ZReferenceVectors.BlockCount; x++)
{
  IBlock block = ZReferenceVectors.GetBlock(x);
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
        _cells.Read(reader);
        _instances.Read(reader);
        _counts.Read(reader);
        _zReferenceVectors.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells.Add(new GlobalDetailObjectCellsBlockBlock());
          Cells[x].Read(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances.Add(new GlobalDetailObjectBlockBlock());
          Instances[x].Read(reader);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].ReadChildData(reader);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts.Add(new GlobalDetailObjectCountsBlockBlock());
          Counts[x].Read(reader);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _zReferenceVectors.Count); x = (x + 1)) {
          ZReferenceVectors.Add(new GlobalZReferenceVectorBlockBlock());
          ZReferenceVectors[x].Read(reader);
        }
        for (x = 0; (x < _zReferenceVectors.Count); x = (x + 1)) {
          ZReferenceVectors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_cells.Count = Cells.Count;
        _cells.Write(bw);
_instances.Count = Instances.Count;
        _instances.Write(bw);
_counts.Count = Counts.Count;
        _counts.Write(bw);
_zReferenceVectors.Count = ZReferenceVectors.Count;
        _zReferenceVectors.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].Write(writer);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].Write(writer);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].WriteChildData(writer);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts[x].Write(writer);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _zReferenceVectors.Count); x = (x + 1)) {
          ZReferenceVectors[x].Write(writer);
        }
        for (x = 0; (x < _zReferenceVectors.Count); x = (x + 1)) {
          ZReferenceVectors[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalDetailObjectCellsBlockBlock : IBlock {
      private ShortInteger _emptyname = new ShortInteger();
      private ShortInteger @__2 = new ShortInteger();
      private ShortInteger @__3 = new ShortInteger();
      private ShortInteger @__4 = new ShortInteger();
      private LongInteger @__5 = new LongInteger();
      private LongInteger @__6 = new LongInteger();
      private LongInteger @__7 = new LongInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectCellsBlockBlock() {
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
      public ShortInteger emptyname {
        get {
          return this._emptyname;
        }
        set {
          this._emptyname = value;
        }
      }
      public ShortInteger _2 {
        get {
          return this.@__2;
        }
        set {
          this.@__2 = value;
        }
      }
      public ShortInteger _3 {
        get {
          return this.@__3;
        }
        set {
          this.@__3 = value;
        }
      }
      public ShortInteger _4 {
        get {
          return this.@__4;
        }
        set {
          this.@__4 = value;
        }
      }
      public LongInteger _5 {
        get {
          return this.@__5;
        }
        set {
          this.@__5 = value;
        }
      }
      public LongInteger _6 {
        get {
          return this.@__6;
        }
        set {
          this.@__6 = value;
        }
      }
      public LongInteger _7 {
        get {
          return this.@__7;
        }
        set {
          this.@__7 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _emptyname.Read(reader);
        @__2.Read(reader);
        @__3.Read(reader);
        @__4.Read(reader);
        @__5.Read(reader);
        @__6.Read(reader);
        @__7.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _emptyname.Write(bw);
        @__2.Write(bw);
        @__3.Write(bw);
        @__4.Write(bw);
        @__5.Write(bw);
        @__6.Write(bw);
        @__7.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalDetailObjectBlockBlock : IBlock {
      private CharInteger _emptyname = new CharInteger();
      private CharInteger @__2 = new CharInteger();
      private CharInteger @__3 = new CharInteger();
      private CharInteger @__4 = new CharInteger();
      private ShortInteger @__5 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectBlockBlock() {
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
      public CharInteger emptyname {
        get {
          return this._emptyname;
        }
        set {
          this._emptyname = value;
        }
      }
      public CharInteger _2 {
        get {
          return this.@__2;
        }
        set {
          this.@__2 = value;
        }
      }
      public CharInteger _3 {
        get {
          return this.@__3;
        }
        set {
          this.@__3 = value;
        }
      }
      public CharInteger _4 {
        get {
          return this.@__4;
        }
        set {
          this.@__4 = value;
        }
      }
      public ShortInteger _5 {
        get {
          return this.@__5;
        }
        set {
          this.@__5 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _emptyname.Read(reader);
        @__2.Read(reader);
        @__3.Read(reader);
        @__4.Read(reader);
        @__5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _emptyname.Write(bw);
        @__2.Write(bw);
        @__3.Write(bw);
        @__4.Write(bw);
        @__5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalDetailObjectCountsBlockBlock : IBlock {
      private ShortInteger _emptyname = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectCountsBlockBlock() {
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
      public ShortInteger emptyname {
        get {
          return this._emptyname;
        }
        set {
          this._emptyname = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _emptyname.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _emptyname.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalZReferenceVectorBlockBlock : IBlock {
      private Real _emptyname = new Real();
      private Real @__2 = new Real();
      private Real @__3 = new Real();
      private Real @__4 = new Real();
public event System.EventHandler BlockNameChanged;
      public GlobalZReferenceVectorBlockBlock() {
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
      public Real emptyname {
        get {
          return this._emptyname;
        }
        set {
          this._emptyname = value;
        }
      }
      public Real _2 {
        get {
          return this.@__2;
        }
        set {
          this.@__2 = value;
        }
      }
      public Real _3 {
        get {
          return this.@__3;
        }
        set {
          this.@__3 = value;
        }
      }
      public Real _4 {
        get {
          return this.@__4;
        }
        set {
          this.@__4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _emptyname.Read(reader);
        @__2.Read(reader);
        @__3.Read(reader);
        @__4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _emptyname.Write(bw);
        @__2.Write(bw);
        @__3.Write(bw);
        @__4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspClusterBlockBlock : IBlock {
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
      private Block _clusterData = new Block();
      private RealBounds _boundsX = new RealBounds();
      private RealBounds _boundsY = new RealBounds();
      private RealBounds _boundsZ = new RealBounds();
      private CharInteger _scenarioSkyIndex = new CharInteger();
      private CharInteger _mediaIndex = new CharInteger();
      private CharInteger _scenarioVisibleSkyIndex = new CharInteger();
      private CharInteger _scenarioAtmosphericFogIndex = new CharInteger();
      private CharInteger _planarFogDesignator = new CharInteger();
      private CharInteger _visibleFogPlaneIndex = new CharInteger();
      private ShortBlockIndex _backgroundSound = new ShortBlockIndex();
      private ShortBlockIndex _soundEnvironment = new ShortBlockIndex();
      private ShortBlockIndex _weather = new ShortBlockIndex();
      private ShortInteger _transitionStructureBSP = new ShortInteger();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Flags _flags;
      private Pad _unnamed5;
      private Block _predictedResources = new Block();
      private Block _portals = new Block();
      private LongInteger _checksumFromStructure = new LongInteger();
      private Block _instancedGeometryIndices = new Block();
      private Block _indexReorderTable = new Block();
      private Data _collisionMoppCode = new Data();
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> _unnamed0List = new BlockCollection<GlobalGeometryCompressionInfoBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<StructureBspClusterDataBlockNewBlock> _clusterDataList = new BlockCollection<StructureBspClusterDataBlockNewBlock>();
      public BlockCollection<PredictedResourceBlockBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlockBlock>();
      public BlockCollection<StructureBspClusterPortalIndexBlockBlock> _portalsList = new BlockCollection<StructureBspClusterPortalIndexBlockBlock>();
      public BlockCollection<StructureBspClusterInstancedGeometryIndexBlockBlock> _instancedGeometryIndicesList = new BlockCollection<StructureBspClusterInstancedGeometryIndexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _indexReorderTableList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterBlockBlock() {
        this._geometryClassification = new Enum(2);
        this._geometryCompressionFlags = new Flags(2);
        this._sectionLightingFlags = new Flags(2);
        this._geometrySelfReference = new Skip(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(4);
        this._flags = new Flags(2);
        this._unnamed5 = new Pad(2);
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
      public BlockCollection<StructureBspClusterDataBlockNewBlock> ClusterData {
        get {
          return this._clusterDataList;
        }
      }
      public BlockCollection<PredictedResourceBlockBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<StructureBspClusterPortalIndexBlockBlock> Portals {
        get {
          return this._portalsList;
        }
      }
      public BlockCollection<StructureBspClusterInstancedGeometryIndexBlockBlock> InstancedGeometryIndices {
        get {
          return this._instancedGeometryIndicesList;
        }
      }
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> IndexReorderTable {
        get {
          return this._indexReorderTableList;
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
for (int x=0; x<ClusterData.BlockCount; x++)
{
  IBlock block = ClusterData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Portals.BlockCount; x++)
{
  IBlock block = Portals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstancedGeometryIndices.BlockCount; x++)
{
  IBlock block = InstancedGeometryIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IndexReorderTable.BlockCount; x++)
{
  IBlock block = IndexReorderTable.GetBlock(x);
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
      public CharInteger ScenarioSkyIndex {
        get {
          return this._scenarioSkyIndex;
        }
        set {
          this._scenarioSkyIndex = value;
        }
      }
      public CharInteger MediaIndex {
        get {
          return this._mediaIndex;
        }
        set {
          this._mediaIndex = value;
        }
      }
      public CharInteger ScenarioVisibleSkyIndex {
        get {
          return this._scenarioVisibleSkyIndex;
        }
        set {
          this._scenarioVisibleSkyIndex = value;
        }
      }
      public CharInteger ScenarioAtmosphericFogIndex {
        get {
          return this._scenarioAtmosphericFogIndex;
        }
        set {
          this._scenarioAtmosphericFogIndex = value;
        }
      }
      public CharInteger PlanarFogDesignator {
        get {
          return this._planarFogDesignator;
        }
        set {
          this._planarFogDesignator = value;
        }
      }
      public CharInteger VisibleFogPlaneIndex {
        get {
          return this._visibleFogPlaneIndex;
        }
        set {
          this._visibleFogPlaneIndex = value;
        }
      }
      public ShortBlockIndex BackgroundSound {
        get {
          return this._backgroundSound;
        }
        set {
          this._backgroundSound = value;
        }
      }
      public ShortBlockIndex SoundEnvironment {
        get {
          return this._soundEnvironment;
        }
        set {
          this._soundEnvironment = value;
        }
      }
      public ShortBlockIndex Weather {
        get {
          return this._weather;
        }
        set {
          this._weather = value;
        }
      }
      public ShortInteger TransitionStructureBSP {
        get {
          return this._transitionStructureBSP;
        }
        set {
          this._transitionStructureBSP = value;
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
      public LongInteger ChecksumFromStructure {
        get {
          return this._checksumFromStructure;
        }
        set {
          this._checksumFromStructure = value;
        }
      }
      public Data CollisionMoppCode {
        get {
          return this._collisionMoppCode;
        }
        set {
          this._collisionMoppCode = value;
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
        _clusterData.Read(reader);
        _boundsX.Read(reader);
        _boundsY.Read(reader);
        _boundsZ.Read(reader);
        _scenarioSkyIndex.Read(reader);
        _mediaIndex.Read(reader);
        _scenarioVisibleSkyIndex.Read(reader);
        _scenarioAtmosphericFogIndex.Read(reader);
        _planarFogDesignator.Read(reader);
        _visibleFogPlaneIndex.Read(reader);
        _backgroundSound.Read(reader);
        _soundEnvironment.Read(reader);
        _weather.Read(reader);
        _transitionStructureBSP.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _flags.Read(reader);
        _unnamed5.Read(reader);
        _predictedResources.Read(reader);
        _portals.Read(reader);
        _checksumFromStructure.Read(reader);
        _instancedGeometryIndices.Read(reader);
        _indexReorderTable.Read(reader);
        _collisionMoppCode.Read(reader);
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
        for (x = 0; (x < _clusterData.Count); x = (x + 1)) {
          ClusterData.Add(new StructureBspClusterDataBlockNewBlock());
          ClusterData[x].Read(reader);
        }
        for (x = 0; (x < _clusterData.Count); x = (x + 1)) {
          ClusterData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlockBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals.Add(new StructureBspClusterPortalIndexBlockBlock());
          Portals[x].Read(reader);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instancedGeometryIndices.Count); x = (x + 1)) {
          InstancedGeometryIndices.Add(new StructureBspClusterInstancedGeometryIndexBlockBlock());
          InstancedGeometryIndices[x].Read(reader);
        }
        for (x = 0; (x < _instancedGeometryIndices.Count); x = (x + 1)) {
          InstancedGeometryIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable.Add(new GlobalGeometrySectionStripIndexBlockBlock());
          IndexReorderTable[x].Read(reader);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].ReadChildData(reader);
        }
        _collisionMoppCode.ReadBinary(reader);
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
_clusterData.Count = ClusterData.Count;
        _clusterData.Write(bw);
        _boundsX.Write(bw);
        _boundsY.Write(bw);
        _boundsZ.Write(bw);
        _scenarioSkyIndex.Write(bw);
        _mediaIndex.Write(bw);
        _scenarioVisibleSkyIndex.Write(bw);
        _scenarioAtmosphericFogIndex.Write(bw);
        _planarFogDesignator.Write(bw);
        _visibleFogPlaneIndex.Write(bw);
        _backgroundSound.Write(bw);
        _soundEnvironment.Write(bw);
        _weather.Write(bw);
        _transitionStructureBSP.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _flags.Write(bw);
        _unnamed5.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_portals.Count = Portals.Count;
        _portals.Write(bw);
        _checksumFromStructure.Write(bw);
_instancedGeometryIndices.Count = InstancedGeometryIndices.Count;
        _instancedGeometryIndices.Write(bw);
_indexReorderTable.Count = IndexReorderTable.Count;
        _indexReorderTable.Write(bw);
        _collisionMoppCode.Write(bw);
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
        for (x = 0; (x < _clusterData.Count); x = (x + 1)) {
          ClusterData[x].Write(writer);
        }
        for (x = 0; (x < _clusterData.Count); x = (x + 1)) {
          ClusterData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].Write(writer);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instancedGeometryIndices.Count); x = (x + 1)) {
          InstancedGeometryIndices[x].Write(writer);
        }
        for (x = 0; (x < _instancedGeometryIndices.Count); x = (x + 1)) {
          InstancedGeometryIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].Write(writer);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].WriteChildData(writer);
        }
        _collisionMoppCode.WriteBinary(writer);
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
    public class StructureBspClusterDataBlockNewBlock : IBlock {
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
      public StructureBspClusterDataBlockNewBlock() {
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
    public class StructureBspClusterPortalIndexBlockBlock : IBlock {
      private ShortInteger _portalIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalIndexBlockBlock() {
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
      public ShortInteger PortalIndex {
        get {
          return this._portalIndex;
        }
        set {
          this._portalIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _portalIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _portalIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspClusterInstancedGeometryIndexBlockBlock : IBlock {
      private ShortInteger _instancedGeometryIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterInstancedGeometryIndexBlockBlock() {
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
      public ShortInteger InstancedGeometryIndex {
        get {
          return this._instancedGeometryIndex;
        }
        set {
          this._instancedGeometryIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _instancedGeometryIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _instancedGeometryIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometryMaterialBlockBlock : IBlock {
      private TagReference _oldShader = new TagReference();
      private TagReference _shader = new TagReference();
      private Block _properties = new Block();
      private Pad _unnamed0;
      private CharInteger _breakableSurfaceIndex = new CharInteger();
      private Pad _unnamed1;
      public BlockCollection<GlobalGeometryMaterialPropertyBlockBlock> _propertiesList = new BlockCollection<GlobalGeometryMaterialPropertyBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryMaterialBlockBlock() {
if (this._shader is System.ComponentModel.INotifyPropertyChanged)
  (this._shader as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(3);
      }
      public BlockCollection<GlobalGeometryMaterialPropertyBlockBlock> Properties {
        get {
          return this._propertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_oldShader.Value);
references.Add(_shader.Value);
for (int x=0; x<Properties.BlockCount; x++)
{
  IBlock block = Properties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _shader.ToString();
        }
      }
      public TagReference OldShader {
        get {
          return this._oldShader;
        }
        set {
          this._oldShader = value;
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
      public CharInteger BreakableSurfaceIndex {
        get {
          return this._breakableSurfaceIndex;
        }
        set {
          this._breakableSurfaceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _oldShader.Read(reader);
        _shader.Read(reader);
        _properties.Read(reader);
        _unnamed0.Read(reader);
        _breakableSurfaceIndex.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _oldShader.ReadString(reader);
        _shader.ReadString(reader);
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties.Add(new GlobalGeometryMaterialPropertyBlockBlock());
          Properties[x].Read(reader);
        }
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _oldShader.Write(bw);
        _shader.Write(bw);
_properties.Count = Properties.Count;
        _properties.Write(bw);
        _unnamed0.Write(bw);
        _breakableSurfaceIndex.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _oldShader.WriteString(writer);
        _shader.WriteString(writer);
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].Write(writer);
        }
        for (x = 0; (x < _properties.Count); x = (x + 1)) {
          Properties[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalGeometryMaterialPropertyBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _intValue = new ShortInteger();
      private Real _realValue = new Real();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryMaterialPropertyBlockBlock() {
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
      public ShortInteger IntValue {
        get {
          return this._intValue;
        }
        set {
          this._intValue = value;
        }
      }
      public Real RealValue {
        get {
          return this._realValue;
        }
        set {
          this._realValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _intValue.Read(reader);
        _realValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _intValue.Write(bw);
        _realValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspSkyOwnerClusterBlockBlock : IBlock {
      private ShortInteger _clusterOwner = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspSkyOwnerClusterBlockBlock() {
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
      public ShortInteger ClusterOwner {
        get {
          return this._clusterOwner;
        }
        set {
          this._clusterOwner = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _clusterOwner.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _clusterOwner.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspConveyorSurfaceBlockBlock : IBlock {
      private RealVector3D _u = new RealVector3D();
      private RealVector3D _v = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspConveyorSurfaceBlockBlock() {
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
      public RealVector3D U {
        get {
          return this._u;
        }
        set {
          this._u = value;
        }
      }
      public RealVector3D V {
        get {
          return this._v;
        }
        set {
          this._v = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _u.Read(reader);
        _v.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _u.Write(bw);
        _v.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspBreakableSurfaceBlockBlock : IBlock {
      private ShortBlockIndex _instancedGeometryInstance = new ShortBlockIndex();
      private ShortInteger _breakableSurfaceIndex = new ShortInteger();
      private RealPoint3D _centroid = new RealPoint3D();
      private Real _radius = new Real();
      private LongInteger _collisionSurfaceIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspBreakableSurfaceBlockBlock() {
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
      public ShortBlockIndex InstancedGeometryInstance {
        get {
          return this._instancedGeometryInstance;
        }
        set {
          this._instancedGeometryInstance = value;
        }
      }
      public ShortInteger BreakableSurfaceIndex {
        get {
          return this._breakableSurfaceIndex;
        }
        set {
          this._breakableSurfaceIndex = value;
        }
      }
      public RealPoint3D Centroid {
        get {
          return this._centroid;
        }
        set {
          this._centroid = value;
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
      public LongInteger CollisionSurfaceIndex {
        get {
          return this._collisionSurfaceIndex;
        }
        set {
          this._collisionSurfaceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _instancedGeometryInstance.Read(reader);
        _breakableSurfaceIndex.Read(reader);
        _centroid.Read(reader);
        _radius.Read(reader);
        _collisionSurfaceIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _instancedGeometryInstance.Write(bw);
        _breakableSurfaceIndex.Write(bw);
        _centroid.Write(bw);
        _radius.Write(bw);
        _collisionSurfaceIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PathfindingDataBlockBlock : IBlock {
      private Block _sectors = new Block();
      private Block _links = new Block();
      private Block _refs = new Block();
      private Block _bsp2dNodes = new Block();
      private Block _surfaceFlags = new Block();
      private Block _vertices = new Block();
      private Block _objectRefs = new Block();
      private Block _pathfindingHints = new Block();
      private Block _instancedGeometryRefs = new Block();
      private LongInteger _structureChecksum = new LongInteger();
      private Pad _unnamed0;
      private Block _user_MinusplacedHints = new Block();
      public BlockCollection<SectorBlockBlock> _sectorsList = new BlockCollection<SectorBlockBlock>();
      public BlockCollection<SectorLinkBlockBlock> _linksList = new BlockCollection<SectorLinkBlockBlock>();
      public BlockCollection<RefBlockBlock> _refsList = new BlockCollection<RefBlockBlock>();
      public BlockCollection<SectorBsp2dNodesBlockBlock> _bsp2dNodesList = new BlockCollection<SectorBsp2dNodesBlockBlock>();
      public BlockCollection<SurfaceFlagsBlockBlock> _surfaceFlagsList = new BlockCollection<SurfaceFlagsBlockBlock>();
      public BlockCollection<SectorVertexBlockBlock> _verticesList = new BlockCollection<SectorVertexBlockBlock>();
      public BlockCollection<EnvironmentObjectRefsBlock> _objectRefsList = new BlockCollection<EnvironmentObjectRefsBlock>();
      public BlockCollection<PathfindingHintsBlockBlock> _pathfindingHintsList = new BlockCollection<PathfindingHintsBlockBlock>();
      public BlockCollection<InstancedGeometryReferenceBlockBlock> _instancedGeometryRefsList = new BlockCollection<InstancedGeometryReferenceBlockBlock>();
      public BlockCollection<UserHintBlockBlock> _user_MinusplacedHintsList = new BlockCollection<UserHintBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PathfindingDataBlockBlock() {
        this._unnamed0 = new Pad(32);
      }
      public BlockCollection<SectorBlockBlock> Sectors {
        get {
          return this._sectorsList;
        }
      }
      public BlockCollection<SectorLinkBlockBlock> Links {
        get {
          return this._linksList;
        }
      }
      public BlockCollection<RefBlockBlock> Refs {
        get {
          return this._refsList;
        }
      }
      public BlockCollection<SectorBsp2dNodesBlockBlock> Bsp2dNodes {
        get {
          return this._bsp2dNodesList;
        }
      }
      public BlockCollection<SurfaceFlagsBlockBlock> SurfaceFlags {
        get {
          return this._surfaceFlagsList;
        }
      }
      public BlockCollection<SectorVertexBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<EnvironmentObjectRefsBlock> ObjectRefs {
        get {
          return this._objectRefsList;
        }
      }
      public BlockCollection<PathfindingHintsBlockBlock> PathfindingHints {
        get {
          return this._pathfindingHintsList;
        }
      }
      public BlockCollection<InstancedGeometryReferenceBlockBlock> InstancedGeometryRefs {
        get {
          return this._instancedGeometryRefsList;
        }
      }
      public BlockCollection<UserHintBlockBlock> User_MinusplacedHints {
        get {
          return this._user_MinusplacedHintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Sectors.BlockCount; x++)
{
  IBlock block = Sectors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Links.BlockCount; x++)
{
  IBlock block = Links.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Refs.BlockCount; x++)
{
  IBlock block = Refs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bsp2dNodes.BlockCount; x++)
{
  IBlock block = Bsp2dNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SurfaceFlags.BlockCount; x++)
{
  IBlock block = SurfaceFlags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ObjectRefs.BlockCount; x++)
{
  IBlock block = ObjectRefs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingHints.BlockCount; x++)
{
  IBlock block = PathfindingHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstancedGeometryRefs.BlockCount; x++)
{
  IBlock block = InstancedGeometryRefs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<User_MinusplacedHints.BlockCount; x++)
{
  IBlock block = User_MinusplacedHints.GetBlock(x);
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
      public LongInteger StructureChecksum {
        get {
          return this._structureChecksum;
        }
        set {
          this._structureChecksum = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectors.Read(reader);
        _links.Read(reader);
        _refs.Read(reader);
        _bsp2dNodes.Read(reader);
        _surfaceFlags.Read(reader);
        _vertices.Read(reader);
        _objectRefs.Read(reader);
        _pathfindingHints.Read(reader);
        _instancedGeometryRefs.Read(reader);
        _structureChecksum.Read(reader);
        _unnamed0.Read(reader);
        _user_MinusplacedHints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors.Add(new SectorBlockBlock());
          Sectors[x].Read(reader);
        }
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links.Add(new SectorLinkBlockBlock());
          Links[x].Read(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].ReadChildData(reader);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs.Add(new RefBlockBlock());
          Refs[x].Read(reader);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes.Add(new SectorBsp2dNodesBlockBlock());
          Bsp2dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags.Add(new SurfaceFlagsBlockBlock());
          SurfaceFlags[x].Read(reader);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new SectorVertexBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs.Add(new EnvironmentObjectRefsBlock());
          ObjectRefs[x].Read(reader);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints.Add(new PathfindingHintsBlockBlock());
          PathfindingHints[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs.Add(new InstancedGeometryReferenceBlockBlock());
          InstancedGeometryRefs[x].Read(reader);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints.Add(new UserHintBlockBlock());
          User_MinusplacedHints[x].Read(reader);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_sectors.Count = Sectors.Count;
        _sectors.Write(bw);
_links.Count = Links.Count;
        _links.Write(bw);
_refs.Count = Refs.Count;
        _refs.Write(bw);
_bsp2dNodes.Count = Bsp2dNodes.Count;
        _bsp2dNodes.Write(bw);
_surfaceFlags.Count = SurfaceFlags.Count;
        _surfaceFlags.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_objectRefs.Count = ObjectRefs.Count;
        _objectRefs.Write(bw);
_pathfindingHints.Count = PathfindingHints.Count;
        _pathfindingHints.Write(bw);
_instancedGeometryRefs.Count = InstancedGeometryRefs.Count;
        _instancedGeometryRefs.Write(bw);
        _structureChecksum.Write(bw);
        _unnamed0.Write(bw);
_user_MinusplacedHints.Count = User_MinusplacedHints.Count;
        _user_MinusplacedHints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].Write(writer);
        }
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].Write(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].WriteChildData(writer);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].Write(writer);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].Write(writer);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].Write(writer);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].Write(writer);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].Write(writer);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].WriteChildData(writer);
        }
      }
    }
    public class SectorBlockBlock : IBlock {
      private Flags _path_MinusfindingSectorFlags;
      private ShortInteger _hintIndex = new ShortInteger();
      private LongInteger _firstLinkDoNotSetManually = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SectorBlockBlock() {
        this._path_MinusfindingSectorFlags = new Flags(2);
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
      public Flags Path_MinusfindingSectorFlags {
        get {
          return this._path_MinusfindingSectorFlags;
        }
        set {
          this._path_MinusfindingSectorFlags = value;
        }
      }
      public ShortInteger HintIndex {
        get {
          return this._hintIndex;
        }
        set {
          this._hintIndex = value;
        }
      }
      public LongInteger FirstLinkDoNotSetManually {
        get {
          return this._firstLinkDoNotSetManually;
        }
        set {
          this._firstLinkDoNotSetManually = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _path_MinusfindingSectorFlags.Read(reader);
        _hintIndex.Read(reader);
        _firstLinkDoNotSetManually.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _path_MinusfindingSectorFlags.Write(bw);
        _hintIndex.Write(bw);
        _firstLinkDoNotSetManually.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorLinkBlockBlock : IBlock {
      private ShortInteger _vertex1 = new ShortInteger();
      private ShortInteger _vertex2 = new ShortInteger();
      private Flags _linkFlags;
      private ShortInteger _hintIndex = new ShortInteger();
      private ShortInteger _forwardLink = new ShortInteger();
      private ShortInteger _reverseLink = new ShortInteger();
      private ShortInteger _leftSector = new ShortInteger();
      private ShortInteger _rightSector = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SectorLinkBlockBlock() {
        this._linkFlags = new Flags(2);
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
      public ShortInteger Vertex1 {
        get {
          return this._vertex1;
        }
        set {
          this._vertex1 = value;
        }
      }
      public ShortInteger Vertex2 {
        get {
          return this._vertex2;
        }
        set {
          this._vertex2 = value;
        }
      }
      public Flags LinkFlags {
        get {
          return this._linkFlags;
        }
        set {
          this._linkFlags = value;
        }
      }
      public ShortInteger HintIndex {
        get {
          return this._hintIndex;
        }
        set {
          this._hintIndex = value;
        }
      }
      public ShortInteger ForwardLink {
        get {
          return this._forwardLink;
        }
        set {
          this._forwardLink = value;
        }
      }
      public ShortInteger ReverseLink {
        get {
          return this._reverseLink;
        }
        set {
          this._reverseLink = value;
        }
      }
      public ShortInteger LeftSector {
        get {
          return this._leftSector;
        }
        set {
          this._leftSector = value;
        }
      }
      public ShortInteger RightSector {
        get {
          return this._rightSector;
        }
        set {
          this._rightSector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertex1.Read(reader);
        _vertex2.Read(reader);
        _linkFlags.Read(reader);
        _hintIndex.Read(reader);
        _forwardLink.Read(reader);
        _reverseLink.Read(reader);
        _leftSector.Read(reader);
        _rightSector.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertex1.Write(bw);
        _vertex2.Write(bw);
        _linkFlags.Write(bw);
        _hintIndex.Write(bw);
        _forwardLink.Write(bw);
        _reverseLink.Write(bw);
        _leftSector.Write(bw);
        _rightSector.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RefBlockBlock : IBlock {
      private LongInteger _nodeRefOrSectorRef = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public RefBlockBlock() {
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
      public LongInteger NodeRefOrSectorRef {
        get {
          return this._nodeRefOrSectorRef;
        }
        set {
          this._nodeRefOrSectorRef = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeRefOrSectorRef.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeRefOrSectorRef.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorBsp2dNodesBlockBlock : IBlock {
      private RealPlane2D _plane = new RealPlane2D();
      private LongInteger _leftChild = new LongInteger();
      private LongInteger _rightChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SectorBsp2dNodesBlockBlock() {
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
      public RealPlane2D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger LeftChild {
        get {
          return this._leftChild;
        }
        set {
          this._leftChild = value;
        }
      }
      public LongInteger RightChild {
        get {
          return this._rightChild;
        }
        set {
          this._rightChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _leftChild.Read(reader);
        _rightChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _leftChild.Write(bw);
        _rightChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SurfaceFlagsBlockBlock : IBlock {
      private LongInteger _flags = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SurfaceFlagsBlockBlock() {
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
      public LongInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorVertexBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public SectorVertexBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EnvironmentObjectRefsBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private LongInteger _firstSector = new LongInteger();
      private LongInteger _lastSector = new LongInteger();
      private Block _bsps = new Block();
      private Block _nodes = new Block();
      public BlockCollection<EnvironmentObjectBspRefsBlock> _bspsList = new BlockCollection<EnvironmentObjectBspRefsBlock>();
      public BlockCollection<EnvironmentObjectNodesBlock> _nodesList = new BlockCollection<EnvironmentObjectNodesBlock>();
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectRefsBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<EnvironmentObjectBspRefsBlock> Bsps {
        get {
          return this._bspsList;
        }
      }
      public BlockCollection<EnvironmentObjectNodesBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bsps.BlockCount; x++)
{
  IBlock block = Bsps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
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
      public LongInteger FirstSector {
        get {
          return this._firstSector;
        }
        set {
          this._firstSector = value;
        }
      }
      public LongInteger LastSector {
        get {
          return this._lastSector;
        }
        set {
          this._lastSector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _firstSector.Read(reader);
        _lastSector.Read(reader);
        _bsps.Read(reader);
        _nodes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps.Add(new EnvironmentObjectBspRefsBlock());
          Bsps[x].Read(reader);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new EnvironmentObjectNodesBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _firstSector.Write(bw);
        _lastSector.Write(bw);
_bsps.Count = Bsps.Count;
        _bsps.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].Write(writer);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
      }
    }
    public class EnvironmentObjectBspRefsBlock : IBlock {
      private LongInteger _bspReference = new LongInteger();
      private LongInteger _firstSector = new LongInteger();
      private LongInteger _lastSector = new LongInteger();
      private ShortInteger _nodeindex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectBspRefsBlock() {
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
      public LongInteger BspReference {
        get {
          return this._bspReference;
        }
        set {
          this._bspReference = value;
        }
      }
      public LongInteger FirstSector {
        get {
          return this._firstSector;
        }
        set {
          this._firstSector = value;
        }
      }
      public LongInteger LastSector {
        get {
          return this._lastSector;
        }
        set {
          this._lastSector = value;
        }
      }
      public ShortInteger Nodeindex {
        get {
          return this._nodeindex;
        }
        set {
          this._nodeindex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bspReference.Read(reader);
        _firstSector.Read(reader);
        _lastSector.Read(reader);
        _nodeindex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bspReference.Write(bw);
        _firstSector.Write(bw);
        _lastSector.Write(bw);
        _nodeindex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EnvironmentObjectNodesBlock : IBlock {
      private ShortInteger _referenceFrameIndex = new ShortInteger();
      private CharInteger _projectionAxis = new CharInteger();
      private Flags _projectionSign;
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectNodesBlock() {
        this._projectionSign = new Flags(1);
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
      public ShortInteger ReferenceFrameIndex {
        get {
          return this._referenceFrameIndex;
        }
        set {
          this._referenceFrameIndex = value;
        }
      }
      public CharInteger ProjectionAxis {
        get {
          return this._projectionAxis;
        }
        set {
          this._projectionAxis = value;
        }
      }
      public Flags ProjectionSign {
        get {
          return this._projectionSign;
        }
        set {
          this._projectionSign = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _referenceFrameIndex.Read(reader);
        _projectionAxis.Read(reader);
        _projectionSign.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _referenceFrameIndex.Write(bw);
        _projectionAxis.Write(bw);
        _projectionSign.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PathfindingHintsBlockBlock : IBlock {
      private Enum _hintType;
      private ShortInteger _nextHintIndex = new ShortInteger();
      private ShortInteger _hintData0 = new ShortInteger();
      private ShortInteger _hintData1 = new ShortInteger();
      private ShortInteger _hintData2 = new ShortInteger();
      private ShortInteger _hintData3 = new ShortInteger();
      private ShortInteger _hintData4 = new ShortInteger();
      private ShortInteger _hintData5 = new ShortInteger();
      private ShortInteger _hintData6 = new ShortInteger();
      private ShortInteger _hintData7 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PathfindingHintsBlockBlock() {
        this._hintType = new Enum(2);
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
      public Enum HintType {
        get {
          return this._hintType;
        }
        set {
          this._hintType = value;
        }
      }
      public ShortInteger NextHintIndex {
        get {
          return this._nextHintIndex;
        }
        set {
          this._nextHintIndex = value;
        }
      }
      public ShortInteger HintData0 {
        get {
          return this._hintData0;
        }
        set {
          this._hintData0 = value;
        }
      }
      public ShortInteger HintData1 {
        get {
          return this._hintData1;
        }
        set {
          this._hintData1 = value;
        }
      }
      public ShortInteger HintData2 {
        get {
          return this._hintData2;
        }
        set {
          this._hintData2 = value;
        }
      }
      public ShortInteger HintData3 {
        get {
          return this._hintData3;
        }
        set {
          this._hintData3 = value;
        }
      }
      public ShortInteger HintData4 {
        get {
          return this._hintData4;
        }
        set {
          this._hintData4 = value;
        }
      }
      public ShortInteger HintData5 {
        get {
          return this._hintData5;
        }
        set {
          this._hintData5 = value;
        }
      }
      public ShortInteger HintData6 {
        get {
          return this._hintData6;
        }
        set {
          this._hintData6 = value;
        }
      }
      public ShortInteger HintData7 {
        get {
          return this._hintData7;
        }
        set {
          this._hintData7 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _hintType.Read(reader);
        _nextHintIndex.Read(reader);
        _hintData0.Read(reader);
        _hintData1.Read(reader);
        _hintData2.Read(reader);
        _hintData3.Read(reader);
        _hintData4.Read(reader);
        _hintData5.Read(reader);
        _hintData6.Read(reader);
        _hintData7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _hintType.Write(bw);
        _nextHintIndex.Write(bw);
        _hintData0.Write(bw);
        _hintData1.Write(bw);
        _hintData2.Write(bw);
        _hintData3.Write(bw);
        _hintData4.Write(bw);
        _hintData5.Write(bw);
        _hintData6.Write(bw);
        _hintData7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class InstancedGeometryReferenceBlockBlock : IBlock {
      private ShortInteger _pathfindingObjectindex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public InstancedGeometryReferenceBlockBlock() {
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
      public ShortInteger PathfindingObjectindex {
        get {
          return this._pathfindingObjectindex;
        }
        set {
          this._pathfindingObjectindex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pathfindingObjectindex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _pathfindingObjectindex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintBlockBlock : IBlock {
      private Block _pointGeometry = new Block();
      private Block _rayGeometry = new Block();
      private Block _lineSegmentGeometry = new Block();
      private Block _parallelogramGeometry = new Block();
      private Block _polygonGeometry = new Block();
      private Block _jumpHints = new Block();
      private Block _climbHints = new Block();
      private Block _wellHints = new Block();
      private Block _flightHints = new Block();
      public BlockCollection<UserHintPointBlockBlock> _pointGeometryList = new BlockCollection<UserHintPointBlockBlock>();
      public BlockCollection<UserHintRayBlockBlock> _rayGeometryList = new BlockCollection<UserHintRayBlockBlock>();
      public BlockCollection<UserHintLineSegmentBlockBlock> _lineSegmentGeometryList = new BlockCollection<UserHintLineSegmentBlockBlock>();
      public BlockCollection<UserHintParallelogramBlockBlock> _parallelogramGeometryList = new BlockCollection<UserHintParallelogramBlockBlock>();
      public BlockCollection<UserHintPolygonBlockBlock> _polygonGeometryList = new BlockCollection<UserHintPolygonBlockBlock>();
      public BlockCollection<UserHintJumpBlockBlock> _jumpHintsList = new BlockCollection<UserHintJumpBlockBlock>();
      public BlockCollection<UserHintClimbBlockBlock> _climbHintsList = new BlockCollection<UserHintClimbBlockBlock>();
      public BlockCollection<UserHintWellBlockBlock> _wellHintsList = new BlockCollection<UserHintWellBlockBlock>();
      public BlockCollection<UserHintFlightBlockBlock> _flightHintsList = new BlockCollection<UserHintFlightBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintBlockBlock() {
      }
      public BlockCollection<UserHintPointBlockBlock> PointGeometry {
        get {
          return this._pointGeometryList;
        }
      }
      public BlockCollection<UserHintRayBlockBlock> RayGeometry {
        get {
          return this._rayGeometryList;
        }
      }
      public BlockCollection<UserHintLineSegmentBlockBlock> LineSegmentGeometry {
        get {
          return this._lineSegmentGeometryList;
        }
      }
      public BlockCollection<UserHintParallelogramBlockBlock> ParallelogramGeometry {
        get {
          return this._parallelogramGeometryList;
        }
      }
      public BlockCollection<UserHintPolygonBlockBlock> PolygonGeometry {
        get {
          return this._polygonGeometryList;
        }
      }
      public BlockCollection<UserHintJumpBlockBlock> JumpHints {
        get {
          return this._jumpHintsList;
        }
      }
      public BlockCollection<UserHintClimbBlockBlock> ClimbHints {
        get {
          return this._climbHintsList;
        }
      }
      public BlockCollection<UserHintWellBlockBlock> WellHints {
        get {
          return this._wellHintsList;
        }
      }
      public BlockCollection<UserHintFlightBlockBlock> FlightHints {
        get {
          return this._flightHintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PointGeometry.BlockCount; x++)
{
  IBlock block = PointGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RayGeometry.BlockCount; x++)
{
  IBlock block = RayGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LineSegmentGeometry.BlockCount; x++)
{
  IBlock block = LineSegmentGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParallelogramGeometry.BlockCount; x++)
{
  IBlock block = ParallelogramGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PolygonGeometry.BlockCount; x++)
{
  IBlock block = PolygonGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<JumpHints.BlockCount; x++)
{
  IBlock block = JumpHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClimbHints.BlockCount; x++)
{
  IBlock block = ClimbHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WellHints.BlockCount; x++)
{
  IBlock block = WellHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FlightHints.BlockCount; x++)
{
  IBlock block = FlightHints.GetBlock(x);
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
        _pointGeometry.Read(reader);
        _rayGeometry.Read(reader);
        _lineSegmentGeometry.Read(reader);
        _parallelogramGeometry.Read(reader);
        _polygonGeometry.Read(reader);
        _jumpHints.Read(reader);
        _climbHints.Read(reader);
        _wellHints.Read(reader);
        _flightHints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry.Add(new UserHintPointBlockBlock());
          PointGeometry[x].Read(reader);
        }
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry.Add(new UserHintRayBlockBlock());
          RayGeometry[x].Read(reader);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry.Add(new UserHintLineSegmentBlockBlock());
          LineSegmentGeometry[x].Read(reader);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry.Add(new UserHintParallelogramBlockBlock());
          ParallelogramGeometry[x].Read(reader);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry.Add(new UserHintPolygonBlockBlock());
          PolygonGeometry[x].Read(reader);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints.Add(new UserHintJumpBlockBlock());
          JumpHints[x].Read(reader);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints.Add(new UserHintClimbBlockBlock());
          ClimbHints[x].Read(reader);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints.Add(new UserHintWellBlockBlock());
          WellHints[x].Read(reader);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints.Add(new UserHintFlightBlockBlock());
          FlightHints[x].Read(reader);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_pointGeometry.Count = PointGeometry.Count;
        _pointGeometry.Write(bw);
_rayGeometry.Count = RayGeometry.Count;
        _rayGeometry.Write(bw);
_lineSegmentGeometry.Count = LineSegmentGeometry.Count;
        _lineSegmentGeometry.Write(bw);
_parallelogramGeometry.Count = ParallelogramGeometry.Count;
        _parallelogramGeometry.Write(bw);
_polygonGeometry.Count = PolygonGeometry.Count;
        _polygonGeometry.Write(bw);
_jumpHints.Count = JumpHints.Count;
        _jumpHints.Write(bw);
_climbHints.Count = ClimbHints.Count;
        _climbHints.Write(bw);
_wellHints.Count = WellHints.Count;
        _wellHints.Write(bw);
_flightHints.Count = FlightHints.Count;
        _flightHints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].Write(writer);
        }
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].Write(writer);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].Write(writer);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].Write(writer);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].Write(writer);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].Write(writer);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].Write(writer);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].Write(writer);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].Write(writer);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintPointBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public UserHintPointBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintRayBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealVector3D _vector = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public UserHintRayBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealVector3D Vector {
        get {
          return this._vector;
        }
        set {
          this._vector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _vector.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _vector.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintLineSegmentBlockBlock : IBlock {
      private Flags _flags;
      private RealPoint3D _point0 = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _point1 = new RealPoint3D();
      private ShortInteger _referenceFrame2 = new ShortInteger();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public UserHintLineSegmentBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
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
      public RealPoint3D Point0 {
        get {
          return this._point0;
        }
        set {
          this._point0 = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealPoint3D Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public ShortInteger ReferenceFrame2 {
        get {
          return this._referenceFrame2;
        }
        set {
          this._referenceFrame2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _point0.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _point1.Read(reader);
        _referenceFrame2.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _point0.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _point1.Write(bw);
        _referenceFrame2.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintParallelogramBlockBlock : IBlock {
      private Flags _flags;
      private RealPoint3D _point0 = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _point1 = new RealPoint3D();
      private ShortInteger _referenceFrame2 = new ShortInteger();
      private Pad _unnamed1;
      private RealPoint3D _point2 = new RealPoint3D();
      private ShortInteger _referenceFrame3 = new ShortInteger();
      private Pad _unnamed2;
      private RealPoint3D _point3 = new RealPoint3D();
      private ShortInteger _referenceFrame4 = new ShortInteger();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public UserHintParallelogramBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
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
      public RealPoint3D Point0 {
        get {
          return this._point0;
        }
        set {
          this._point0 = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealPoint3D Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public ShortInteger ReferenceFrame2 {
        get {
          return this._referenceFrame2;
        }
        set {
          this._referenceFrame2 = value;
        }
      }
      public RealPoint3D Point2 {
        get {
          return this._point2;
        }
        set {
          this._point2 = value;
        }
      }
      public ShortInteger ReferenceFrame3 {
        get {
          return this._referenceFrame3;
        }
        set {
          this._referenceFrame3 = value;
        }
      }
      public RealPoint3D Point3 {
        get {
          return this._point3;
        }
        set {
          this._point3 = value;
        }
      }
      public ShortInteger ReferenceFrame4 {
        get {
          return this._referenceFrame4;
        }
        set {
          this._referenceFrame4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _point0.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _point1.Read(reader);
        _referenceFrame2.Read(reader);
        _unnamed1.Read(reader);
        _point2.Read(reader);
        _referenceFrame3.Read(reader);
        _unnamed2.Read(reader);
        _point3.Read(reader);
        _referenceFrame4.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _point0.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _point1.Write(bw);
        _referenceFrame2.Write(bw);
        _unnamed1.Write(bw);
        _point2.Write(bw);
        _referenceFrame3.Write(bw);
        _unnamed2.Write(bw);
        _point3.Write(bw);
        _referenceFrame4.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintPolygonBlockBlock : IBlock {
      private Flags _flags;
      private Block _points = new Block();
      public BlockCollection<UserHintPointBlockBlock> _pointsList = new BlockCollection<UserHintPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintPolygonBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<UserHintPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintJumpBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _geometryIndex = new ShortBlockIndex();
      private Enum _forceJumpHeight;
      private Flags _controlFlags;
public event System.EventHandler BlockNameChanged;
      public UserHintJumpBlockBlock() {
        this._flags = new Flags(2);
        this._forceJumpHeight = new Enum(2);
        this._controlFlags = new Flags(2);
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
      public ShortBlockIndex GeometryIndex {
        get {
          return this._geometryIndex;
        }
        set {
          this._geometryIndex = value;
        }
      }
      public Enum ForceJumpHeight {
        get {
          return this._forceJumpHeight;
        }
        set {
          this._forceJumpHeight = value;
        }
      }
      public Flags ControlFlags {
        get {
          return this._controlFlags;
        }
        set {
          this._controlFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _geometryIndex.Read(reader);
        _forceJumpHeight.Read(reader);
        _controlFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _geometryIndex.Write(bw);
        _forceJumpHeight.Write(bw);
        _controlFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintClimbBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _geometryIndex = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public UserHintClimbBlockBlock() {
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortBlockIndex GeometryIndex {
        get {
          return this._geometryIndex;
        }
        set {
          this._geometryIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _geometryIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _geometryIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintWellBlockBlock : IBlock {
      private Flags _flags;
      private Block _points = new Block();
      public BlockCollection<UserHintWellPointBlockBlock> _pointsList = new BlockCollection<UserHintWellPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintWellBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<UserHintWellPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintWellPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintWellPointBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private RealVector3D _point = new RealVector3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed1;
      private LongInteger _sectorIndex = new LongInteger();
      private RealEulerAngles2D _normal = new RealEulerAngles2D();
public event System.EventHandler BlockNameChanged;
      public UserHintWellPointBlockBlock() {
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public RealVector3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public LongInteger SectorIndex {
        get {
          return this._sectorIndex;
        }
        set {
          this._sectorIndex = value;
        }
      }
      public RealEulerAngles2D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed1.Read(reader);
        _sectorIndex.Read(reader);
        _normal.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed1.Write(bw);
        _sectorIndex.Write(bw);
        _normal.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintFlightBlockBlock : IBlock {
      private Block _points = new Block();
      public BlockCollection<UserHintFlightPointBlockBlock> _pointsList = new BlockCollection<UserHintFlightPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintFlightBlockBlock() {
      }
      public BlockCollection<UserHintFlightPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
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
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintFlightPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintFlightPointBlockBlock : IBlock {
      private RealVector3D _point = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public UserHintFlightPointBlockBlock() {
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
      public RealVector3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspPathfindingEdgesBlockBlock : IBlock {
      private CharInteger _midpoint = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspPathfindingEdgesBlockBlock() {
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
      public CharInteger Midpoint {
        get {
          return this._midpoint;
        }
        set {
          this._midpoint = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _midpoint.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _midpoint.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspBackgroundSoundPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _backgroundSound = new TagReference();
      private TagReference _insideClusterSound = new TagReference();
      private Pad _unnamed0;
      private Real _cutoffDistance = new Real();
      private Flags _scaleFlags;
      private RealFraction _interiorScale = new RealFraction();
      private RealFraction _portalScale = new RealFraction();
      private RealFraction _exteriorScale = new RealFraction();
      private Real _interpolationSpeed = new Real();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public StructureBspBackgroundSoundPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(20);
        this._scaleFlags = new Flags(4);
        this._unnamed1 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundSound.Value);
references.Add(_insideClusterSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public TagReference BackgroundSound {
        get {
          return this._backgroundSound;
        }
        set {
          this._backgroundSound = value;
        }
      }
      public TagReference InsideClusterSound {
        get {
          return this._insideClusterSound;
        }
        set {
          this._insideClusterSound = value;
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
      public Flags ScaleFlags {
        get {
          return this._scaleFlags;
        }
        set {
          this._scaleFlags = value;
        }
      }
      public RealFraction InteriorScale {
        get {
          return this._interiorScale;
        }
        set {
          this._interiorScale = value;
        }
      }
      public RealFraction PortalScale {
        get {
          return this._portalScale;
        }
        set {
          this._portalScale = value;
        }
      }
      public RealFraction ExteriorScale {
        get {
          return this._exteriorScale;
        }
        set {
          this._exteriorScale = value;
        }
      }
      public Real InterpolationSpeed {
        get {
          return this._interpolationSpeed;
        }
        set {
          this._interpolationSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _backgroundSound.Read(reader);
        _insideClusterSound.Read(reader);
        _unnamed0.Read(reader);
        _cutoffDistance.Read(reader);
        _scaleFlags.Read(reader);
        _interiorScale.Read(reader);
        _portalScale.Read(reader);
        _exteriorScale.Read(reader);
        _interpolationSpeed.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _backgroundSound.ReadString(reader);
        _insideClusterSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _backgroundSound.Write(bw);
        _insideClusterSound.Write(bw);
        _unnamed0.Write(bw);
        _cutoffDistance.Write(bw);
        _scaleFlags.Write(bw);
        _interiorScale.Write(bw);
        _portalScale.Write(bw);
        _exteriorScale.Write(bw);
        _interpolationSpeed.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _backgroundSound.WriteString(writer);
        _insideClusterSound.WriteString(writer);
      }
    }
    public class StructureBspSoundEnvironmentPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _soundEnvironment = new TagReference();
      private Real _cutoffDistance = new Real();
      private Real _interpolationSpeed = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureBspSoundEnvironmentPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_soundEnvironment.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public TagReference SoundEnvironment {
        get {
          return this._soundEnvironment;
        }
        set {
          this._soundEnvironment = value;
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
      public Real InterpolationSpeed {
        get {
          return this._interpolationSpeed;
        }
        set {
          this._interpolationSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _soundEnvironment.Read(reader);
        _cutoffDistance.Read(reader);
        _interpolationSpeed.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _soundEnvironment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _soundEnvironment.Write(bw);
        _cutoffDistance.Write(bw);
        _interpolationSpeed.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _soundEnvironment.WriteString(writer);
      }
    }
    public class StructureBspMarkerBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealQuaternion _rotation = new RealQuaternion();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspMarkerBlockBlock() {
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public RealQuaternion Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _rotation.Read(reader);
        _position.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _rotation.Write(bw);
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspRuntimeDecalBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureBspRuntimeDecalBlockBlock() {
        this._unnamed0 = new Skip(16);
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
    public class StructureBspEnvironmentObjectPaletteBlockBlock : IBlock {
      private TagReference _definition = new TagReference();
      private TagReference _model = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureBspEnvironmentObjectPaletteBlockBlock() {
        this._unnamed0 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_definition.Value);
references.Add(_model.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Definition {
        get {
          return this._definition;
        }
        set {
          this._definition = value;
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
      public virtual void Read(BinaryReader reader) {
        _definition.Read(reader);
        _model.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _definition.ReadString(reader);
        _model.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _definition.Write(bw);
        _model.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _definition.WriteString(writer);
        _model.WriteString(writer);
      }
    }
    public class StructureBspEnvironmentObjectBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealQuaternion _rotation = new RealQuaternion();
      private RealPoint3D _translation = new RealPoint3D();
      private ShortBlockIndex _paletteindex = new ShortBlockIndex();
      private Pad _unnamed0;
      private LongInteger _uniqueID = new LongInteger();
      private TagSignature _exportedObjectType = new TagSignature();
      private FixedLengthString _scenarioObjectName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public StructureBspEnvironmentObjectBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public RealQuaternion Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public RealPoint3D Translation {
        get {
          return this._translation;
        }
        set {
          this._translation = value;
        }
      }
      public ShortBlockIndex Paletteindex {
        get {
          return this._paletteindex;
        }
        set {
          this._paletteindex = value;
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
      public TagSignature ExportedObjectType {
        get {
          return this._exportedObjectType;
        }
        set {
          this._exportedObjectType = value;
        }
      }
      public FixedLengthString ScenarioObjectName {
        get {
          return this._scenarioObjectName;
        }
        set {
          this._scenarioObjectName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _rotation.Read(reader);
        _translation.Read(reader);
        _paletteindex.Read(reader);
        _unnamed0.Read(reader);
        _uniqueID.Read(reader);
        _exportedObjectType.Read(reader);
        _scenarioObjectName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _rotation.Write(bw);
        _translation.Write(bw);
        _paletteindex.Write(bw);
        _unnamed0.Write(bw);
        _uniqueID.Write(bw);
        _exportedObjectType.Write(bw);
        _scenarioObjectName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspLightmapDataBlockBlock : IBlock {
      private TagReference _bitmapGroup = new TagReference();
public event System.EventHandler BlockNameChanged;
      public StructureBspLightmapDataBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmapGroup.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
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
        _bitmapGroup.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmapGroup.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmapGroup.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmapGroup.WriteString(writer);
      }
    }
    public class GlobalMapLeafBlockBlock : IBlock {
      private Block _faces = new Block();
      private Block _connectionIndices = new Block();
      public BlockCollection<MapLeafFaceBlockBlock> _facesList = new BlockCollection<MapLeafFaceBlockBlock>();
      public BlockCollection<MapLeafConnectionIndexBlockBlock> _connectionIndicesList = new BlockCollection<MapLeafConnectionIndexBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalMapLeafBlockBlock() {
      }
      public BlockCollection<MapLeafFaceBlockBlock> Faces {
        get {
          return this._facesList;
        }
      }
      public BlockCollection<MapLeafConnectionIndexBlockBlock> ConnectionIndices {
        get {
          return this._connectionIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Faces.BlockCount; x++)
{
  IBlock block = Faces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ConnectionIndices.BlockCount; x++)
{
  IBlock block = ConnectionIndices.GetBlock(x);
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
        _faces.Read(reader);
        _connectionIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces.Add(new MapLeafFaceBlockBlock());
          Faces[x].Read(reader);
        }
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _connectionIndices.Count); x = (x + 1)) {
          ConnectionIndices.Add(new MapLeafConnectionIndexBlockBlock());
          ConnectionIndices[x].Read(reader);
        }
        for (x = 0; (x < _connectionIndices.Count); x = (x + 1)) {
          ConnectionIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_faces.Count = Faces.Count;
        _faces.Write(bw);
_connectionIndices.Count = ConnectionIndices.Count;
        _connectionIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].Write(writer);
        }
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _connectionIndices.Count); x = (x + 1)) {
          ConnectionIndices[x].Write(writer);
        }
        for (x = 0; (x < _connectionIndices.Count); x = (x + 1)) {
          ConnectionIndices[x].WriteChildData(writer);
        }
      }
    }
    public class MapLeafFaceBlockBlock : IBlock {
      private LongInteger _nodeIndex = new LongInteger();
      private Block _vertices = new Block();
      public BlockCollection<MapLeafFaceVertexBlockBlock> _verticesList = new BlockCollection<MapLeafFaceVertexBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MapLeafFaceBlockBlock() {
      }
      public BlockCollection<MapLeafFaceVertexBlockBlock> Vertices {
        get {
          return this._verticesList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
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
      public virtual void Read(BinaryReader reader) {
        _nodeIndex.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new MapLeafFaceVertexBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeIndex.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class MapLeafFaceVertexBlockBlock : IBlock {
      private RealPoint3D _vertex = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public MapLeafFaceVertexBlockBlock() {
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
      public RealPoint3D Vertex {
        get {
          return this._vertex;
        }
        set {
          this._vertex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MapLeafConnectionIndexBlockBlock : IBlock {
      private LongInteger _connectionIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public MapLeafConnectionIndexBlockBlock() {
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
      public LongInteger ConnectionIndex {
        get {
          return this._connectionIndex;
        }
        set {
          this._connectionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _connectionIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _connectionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalLeafConnectionBlockBlock : IBlock {
      private LongInteger _planeIndex = new LongInteger();
      private LongInteger _backLeafIndex = new LongInteger();
      private LongInteger _frontLeafIndex = new LongInteger();
      private Block _vertices = new Block();
      private Real _area = new Real();
      public BlockCollection<LeafConnectionVertexBlockBlock> _verticesList = new BlockCollection<LeafConnectionVertexBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalLeafConnectionBlockBlock() {
      }
      public BlockCollection<LeafConnectionVertexBlockBlock> Vertices {
        get {
          return this._verticesList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public LongInteger PlaneIndex {
        get {
          return this._planeIndex;
        }
        set {
          this._planeIndex = value;
        }
      }
      public LongInteger BackLeafIndex {
        get {
          return this._backLeafIndex;
        }
        set {
          this._backLeafIndex = value;
        }
      }
      public LongInteger FrontLeafIndex {
        get {
          return this._frontLeafIndex;
        }
        set {
          this._frontLeafIndex = value;
        }
      }
      public Real Area {
        get {
          return this._area;
        }
        set {
          this._area = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _planeIndex.Read(reader);
        _backLeafIndex.Read(reader);
        _frontLeafIndex.Read(reader);
        _vertices.Read(reader);
        _area.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new LeafConnectionVertexBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _planeIndex.Write(bw);
        _backLeafIndex.Write(bw);
        _frontLeafIndex.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
        _area.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class LeafConnectionVertexBlockBlock : IBlock {
      private RealPoint3D _vertex = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public LeafConnectionVertexBlockBlock() {
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
      public RealPoint3D Vertex {
        get {
          return this._vertex;
        }
        set {
          this._vertex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertex.Write(bw);
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
    public class StructureBspPrecomputedLightingBlockBlock : IBlock {
      private LongInteger _index = new LongInteger();
      private Enum _lightType;
      private CharInteger _attachmentIndex = new CharInteger();
      private CharInteger _objectType = new CharInteger();
      private ShortInteger _projectionCount = new ShortInteger();
      private ShortInteger _clusterCount = new ShortInteger();
      private ShortInteger _volumeCount = new ShortInteger();
      private Pad _unnamed0;
      private Data _projections = new Data();
      private Data _visibilityClusters = new Data();
      private Data _clusterRemapTable = new Data();
      private Data _visibilityVolumes = new Data();
public event System.EventHandler BlockNameChanged;
      public StructureBspPrecomputedLightingBlockBlock() {
        this._lightType = new Enum(2);
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
      public LongInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public Enum LightType {
        get {
          return this._lightType;
        }
        set {
          this._lightType = value;
        }
      }
      public CharInteger AttachmentIndex {
        get {
          return this._attachmentIndex;
        }
        set {
          this._attachmentIndex = value;
        }
      }
      public CharInteger ObjectType {
        get {
          return this._objectType;
        }
        set {
          this._objectType = value;
        }
      }
      public ShortInteger ProjectionCount {
        get {
          return this._projectionCount;
        }
        set {
          this._projectionCount = value;
        }
      }
      public ShortInteger ClusterCount {
        get {
          return this._clusterCount;
        }
        set {
          this._clusterCount = value;
        }
      }
      public ShortInteger VolumeCount {
        get {
          return this._volumeCount;
        }
        set {
          this._volumeCount = value;
        }
      }
      public Data Projections {
        get {
          return this._projections;
        }
        set {
          this._projections = value;
        }
      }
      public Data VisibilityClusters {
        get {
          return this._visibilityClusters;
        }
        set {
          this._visibilityClusters = value;
        }
      }
      public Data ClusterRemapTable {
        get {
          return this._clusterRemapTable;
        }
        set {
          this._clusterRemapTable = value;
        }
      }
      public Data VisibilityVolumes {
        get {
          return this._visibilityVolumes;
        }
        set {
          this._visibilityVolumes = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _index.Read(reader);
        _lightType.Read(reader);
        _attachmentIndex.Read(reader);
        _objectType.Read(reader);
        _projectionCount.Read(reader);
        _clusterCount.Read(reader);
        _volumeCount.Read(reader);
        _unnamed0.Read(reader);
        _projections.Read(reader);
        _visibilityClusters.Read(reader);
        _clusterRemapTable.Read(reader);
        _visibilityVolumes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _projections.ReadBinary(reader);
        _visibilityClusters.ReadBinary(reader);
        _clusterRemapTable.ReadBinary(reader);
        _visibilityVolumes.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _index.Write(bw);
        _lightType.Write(bw);
        _attachmentIndex.Write(bw);
        _objectType.Write(bw);
        _projectionCount.Write(bw);
        _clusterCount.Write(bw);
        _volumeCount.Write(bw);
        _unnamed0.Write(bw);
        _projections.Write(bw);
        _visibilityClusters.Write(bw);
        _clusterRemapTable.Write(bw);
        _visibilityVolumes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _projections.WriteBinary(writer);
        _visibilityClusters.WriteBinary(writer);
        _clusterRemapTable.WriteBinary(writer);
        _visibilityVolumes.WriteBinary(writer);
      }
    }
    public class StructureBspInstancedGeometryDefinitionBlockBlock : IBlock {
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
      private Block _renderData = new Block();
      private Block _indexReorderTable = new Block();
      private LongInteger _checksum = new LongInteger();
      private RealPoint3D _boundingSphereCenter = new RealPoint3D();
      private Real _boundingSphereRadius = new Real();
      private Block _bSP3DNodes = new Block();
      private Block _planes = new Block();
      private Block _leaves = new Block();
      private Block _bSP2DReferences = new Block();
      private Block _bSP2DNodes = new Block();
      private Block _surfaces = new Block();
      private Block _edges = new Block();
      private Block _vertices = new Block();
      private Block _bspphysics = new Block();
      private Block _renderLeaves = new Block();
      private Block _surfaceReferences = new Block();
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> _unnamed0List = new BlockCollection<GlobalGeometryCompressionInfoBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<StructureBspClusterDataBlockNewBlock> _renderDataList = new BlockCollection<StructureBspClusterDataBlockNewBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _indexReorderTableList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
      public BlockCollection<Bsp3dNodesBlockBlock> _bSP3DNodesList = new BlockCollection<Bsp3dNodesBlockBlock>();
      public BlockCollection<PlanesBlockBlock> _planesList = new BlockCollection<PlanesBlockBlock>();
      public BlockCollection<LeavesBlockBlock> _leavesList = new BlockCollection<LeavesBlockBlock>();
      public BlockCollection<Bsp2dReferencesBlockBlock> _bSP2DReferencesList = new BlockCollection<Bsp2dReferencesBlockBlock>();
      public BlockCollection<Bsp2dNodesBlockBlock> _bSP2DNodesList = new BlockCollection<Bsp2dNodesBlockBlock>();
      public BlockCollection<SurfacesBlockBlock> _surfacesList = new BlockCollection<SurfacesBlockBlock>();
      public BlockCollection<EdgesBlockBlock> _edgesList = new BlockCollection<EdgesBlockBlock>();
      public BlockCollection<VerticesBlockBlock> _verticesList = new BlockCollection<VerticesBlockBlock>();
      public BlockCollection<CollisionBspPhysicsBlockBlock> _bspphysicsList = new BlockCollection<CollisionBspPhysicsBlockBlock>();
      public BlockCollection<StructureBspLeafBlockBlock> _renderLeavesList = new BlockCollection<StructureBspLeafBlockBlock>();
      public BlockCollection<StructureBspSurfaceReferenceBlockBlock> _surfaceReferencesList = new BlockCollection<StructureBspSurfaceReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspInstancedGeometryDefinitionBlockBlock() {
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
      public BlockCollection<StructureBspClusterDataBlockNewBlock> RenderData {
        get {
          return this._renderDataList;
        }
      }
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> IndexReorderTable {
        get {
          return this._indexReorderTableList;
        }
      }
      public BlockCollection<Bsp3dNodesBlockBlock> BSP3DNodes {
        get {
          return this._bSP3DNodesList;
        }
      }
      public BlockCollection<PlanesBlockBlock> Planes {
        get {
          return this._planesList;
        }
      }
      public BlockCollection<LeavesBlockBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<Bsp2dReferencesBlockBlock> BSP2DReferences {
        get {
          return this._bSP2DReferencesList;
        }
      }
      public BlockCollection<Bsp2dNodesBlockBlock> BSP2DNodes {
        get {
          return this._bSP2DNodesList;
        }
      }
      public BlockCollection<SurfacesBlockBlock> Surfaces {
        get {
          return this._surfacesList;
        }
      }
      public BlockCollection<EdgesBlockBlock> Edges {
        get {
          return this._edgesList;
        }
      }
      public BlockCollection<VerticesBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<CollisionBspPhysicsBlockBlock> Bspphysics {
        get {
          return this._bspphysicsList;
        }
      }
      public BlockCollection<StructureBspLeafBlockBlock> RenderLeaves {
        get {
          return this._renderLeavesList;
        }
      }
      public BlockCollection<StructureBspSurfaceReferenceBlockBlock> SurfaceReferences {
        get {
          return this._surfaceReferencesList;
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
for (int x=0; x<RenderData.BlockCount; x++)
{
  IBlock block = RenderData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IndexReorderTable.BlockCount; x++)
{
  IBlock block = IndexReorderTable.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSP3DNodes.BlockCount; x++)
{
  IBlock block = BSP3DNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Planes.BlockCount; x++)
{
  IBlock block = Planes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Leaves.BlockCount; x++)
{
  IBlock block = Leaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSP2DReferences.BlockCount; x++)
{
  IBlock block = BSP2DReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSP2DNodes.BlockCount; x++)
{
  IBlock block = BSP2DNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Surfaces.BlockCount; x++)
{
  IBlock block = Surfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Edges.BlockCount; x++)
{
  IBlock block = Edges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bspphysics.BlockCount; x++)
{
  IBlock block = Bspphysics.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RenderLeaves.BlockCount; x++)
{
  IBlock block = RenderLeaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SurfaceReferences.BlockCount; x++)
{
  IBlock block = SurfaceReferences.GetBlock(x);
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
      public LongInteger Checksum {
        get {
          return this._checksum;
        }
        set {
          this._checksum = value;
        }
      }
      public RealPoint3D BoundingSphereCenter {
        get {
          return this._boundingSphereCenter;
        }
        set {
          this._boundingSphereCenter = value;
        }
      }
      public Real BoundingSphereRadius {
        get {
          return this._boundingSphereRadius;
        }
        set {
          this._boundingSphereRadius = value;
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
        _renderData.Read(reader);
        _indexReorderTable.Read(reader);
        _checksum.Read(reader);
        _boundingSphereCenter.Read(reader);
        _boundingSphereRadius.Read(reader);
        _bSP3DNodes.Read(reader);
        _planes.Read(reader);
        _leaves.Read(reader);
        _bSP2DReferences.Read(reader);
        _bSP2DNodes.Read(reader);
        _surfaces.Read(reader);
        _edges.Read(reader);
        _vertices.Read(reader);
        _bspphysics.Read(reader);
        _renderLeaves.Read(reader);
        _surfaceReferences.Read(reader);
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
        for (x = 0; (x < _renderData.Count); x = (x + 1)) {
          RenderData.Add(new StructureBspClusterDataBlockNewBlock());
          RenderData[x].Read(reader);
        }
        for (x = 0; (x < _renderData.Count); x = (x + 1)) {
          RenderData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable.Add(new GlobalGeometrySectionStripIndexBlockBlock());
          IndexReorderTable[x].Read(reader);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes.Add(new Bsp3dNodesBlockBlock());
          BSP3DNodes[x].Read(reader);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new PlanesBlockBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new LeavesBlockBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences.Add(new Bsp2dReferencesBlockBlock());
          BSP2DReferences[x].Read(reader);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes.Add(new Bsp2dNodesBlockBlock());
          BSP2DNodes[x].Read(reader);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces.Add(new SurfacesBlockBlock());
          Surfaces[x].Read(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges.Add(new EdgesBlockBlock());
          Edges[x].Read(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new VerticesBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics.Add(new CollisionBspPhysicsBlockBlock());
          Bspphysics[x].Read(reader);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].ReadChildData(reader);
        }
        for (x = 0; (x < _renderLeaves.Count); x = (x + 1)) {
          RenderLeaves.Add(new StructureBspLeafBlockBlock());
          RenderLeaves[x].Read(reader);
        }
        for (x = 0; (x < _renderLeaves.Count); x = (x + 1)) {
          RenderLeaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences.Add(new StructureBspSurfaceReferenceBlockBlock());
          SurfaceReferences[x].Read(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].ReadChildData(reader);
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
_renderData.Count = RenderData.Count;
        _renderData.Write(bw);
_indexReorderTable.Count = IndexReorderTable.Count;
        _indexReorderTable.Write(bw);
        _checksum.Write(bw);
        _boundingSphereCenter.Write(bw);
        _boundingSphereRadius.Write(bw);
_bSP3DNodes.Count = BSP3DNodes.Count;
        _bSP3DNodes.Write(bw);
_planes.Count = Planes.Count;
        _planes.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
_bSP2DReferences.Count = BSP2DReferences.Count;
        _bSP2DReferences.Write(bw);
_bSP2DNodes.Count = BSP2DNodes.Count;
        _bSP2DNodes.Write(bw);
_surfaces.Count = Surfaces.Count;
        _surfaces.Write(bw);
_edges.Count = Edges.Count;
        _edges.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_bspphysics.Count = Bspphysics.Count;
        _bspphysics.Write(bw);
_renderLeaves.Count = RenderLeaves.Count;
        _renderLeaves.Write(bw);
_surfaceReferences.Count = SurfaceReferences.Count;
        _surfaceReferences.Write(bw);
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
        for (x = 0; (x < _renderData.Count); x = (x + 1)) {
          RenderData[x].Write(writer);
        }
        for (x = 0; (x < _renderData.Count); x = (x + 1)) {
          RenderData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].Write(writer);
        }
        for (x = 0; (x < _indexReorderTable.Count); x = (x + 1)) {
          IndexReorderTable[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].Write(writer);
        }
        for (x = 0; (x < _bSP3DNodes.Count); x = (x + 1)) {
          BSP3DNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].Write(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].Write(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].Write(writer);
        }
        for (x = 0; (x < _bSP2DReferences.Count); x = (x + 1)) {
          BSP2DReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].Write(writer);
        }
        for (x = 0; (x < _bSP2DNodes.Count); x = (x + 1)) {
          BSP2DNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].Write(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].Write(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].Write(writer);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].WriteChildData(writer);
        }
        for (x = 0; (x < _renderLeaves.Count); x = (x + 1)) {
          RenderLeaves[x].Write(writer);
        }
        for (x = 0; (x < _renderLeaves.Count); x = (x + 1)) {
          RenderLeaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].Write(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].WriteChildData(writer);
        }
      }
    }
    public class CollisionBspPhysicsBlockBlock : IBlock {
      private Skip _unnamed0;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed1;
      private Pad _unnamed2;
      private Skip _unnamed3;
      private Pad _unnamed4;
      private Skip _unnamed5;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed6;
      private Pad _unnamed7;
      private Skip _unnamed8;
      private ShortInteger _size3 = new ShortInteger();
      private ShortInteger _count3 = new ShortInteger();
      private Skip _unnamed9;
      private Pad _unnamed10;
      private Data _moppCodeData = new Data();
      private Pad _unnamed11;
public event System.EventHandler BlockNameChanged;
      public CollisionBspPhysicsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Skip(32);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Pad(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
        this._unnamed10 = new Pad(8);
        this._unnamed11 = new Pad(8);
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
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public ShortInteger Size2 {
        get {
          return this._size2;
        }
        set {
          this._size2 = value;
        }
      }
      public ShortInteger Count2 {
        get {
          return this._count2;
        }
        set {
          this._count2 = value;
        }
      }
      public ShortInteger Size3 {
        get {
          return this._size3;
        }
        set {
          this._size3 = value;
        }
      }
      public ShortInteger Count3 {
        get {
          return this._count3;
        }
        set {
          this._count3 = value;
        }
      }
      public Data MoppCodeData {
        get {
          return this._moppCodeData;
        }
        set {
          this._moppCodeData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _size3.Read(reader);
        _count3.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _moppCodeData.Read(reader);
        _unnamed11.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _moppCodeData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _size3.Write(bw);
        _count3.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _moppCodeData.Write(bw);
        _unnamed11.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _moppCodeData.WriteBinary(writer);
      }
    }
    public class StructureBspInstancedGeometryInstancesBlockBlock : IBlock {
      private Real _scale = new Real();
      private RealVector3D _forward = new RealVector3D();
      private RealVector3D _left = new RealVector3D();
      private RealVector3D _up = new RealVector3D();
      private RealPoint3D _position = new RealPoint3D();
      private ShortBlockIndex _instanceDefinition = new ShortBlockIndex();
      private Flags _flags;
      private Pad _unnamed0;
      private Skip _unnamed1;
      private Skip _unnamed2;
      private LongInteger _checksum = new LongInteger();
      private StringId _name = new StringId();
      private Enum _pathfindingPolicy;
      private Enum _lightmappingPolicy;
public event System.EventHandler BlockNameChanged;
      public StructureBspInstancedGeometryInstancesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Skip(12);
        this._unnamed2 = new Skip(4);
        this._pathfindingPolicy = new Enum(2);
        this._lightmappingPolicy = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public RealVector3D Forward {
        get {
          return this._forward;
        }
        set {
          this._forward = value;
        }
      }
      public RealVector3D Left {
        get {
          return this._left;
        }
        set {
          this._left = value;
        }
      }
      public RealVector3D Up {
        get {
          return this._up;
        }
        set {
          this._up = value;
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
      public ShortBlockIndex InstanceDefinition {
        get {
          return this._instanceDefinition;
        }
        set {
          this._instanceDefinition = value;
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
      public LongInteger Checksum {
        get {
          return this._checksum;
        }
        set {
          this._checksum = value;
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
      public Enum PathfindingPolicy {
        get {
          return this._pathfindingPolicy;
        }
        set {
          this._pathfindingPolicy = value;
        }
      }
      public Enum LightmappingPolicy {
        get {
          return this._lightmappingPolicy;
        }
        set {
          this._lightmappingPolicy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scale.Read(reader);
        _forward.Read(reader);
        _left.Read(reader);
        _up.Read(reader);
        _position.Read(reader);
        _instanceDefinition.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _checksum.Read(reader);
        _name.Read(reader);
        _pathfindingPolicy.Read(reader);
        _lightmappingPolicy.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _scale.Write(bw);
        _forward.Write(bw);
        _left.Write(bw);
        _up.Write(bw);
        _position.Write(bw);
        _instanceDefinition.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _checksum.Write(bw);
        _name.Write(bw);
        _pathfindingPolicy.Write(bw);
        _lightmappingPolicy.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class StructureBspSoundClusterBlockBlock : IBlock {
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Block _enclosingPortalDesignators = new Block();
      private Block _interiorClusterIndices = new Block();
      public BlockCollection<StructureSoundClusterPortalDesignatorsBlock> _enclosingPortalDesignatorsList = new BlockCollection<StructureSoundClusterPortalDesignatorsBlock>();
      public BlockCollection<StructureSoundClusterInteriorClusterIndicesBlock> _interiorClusterIndicesList = new BlockCollection<StructureSoundClusterInteriorClusterIndicesBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspSoundClusterBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<StructureSoundClusterPortalDesignatorsBlock> EnclosingPortalDesignators {
        get {
          return this._enclosingPortalDesignatorsList;
        }
      }
      public BlockCollection<StructureSoundClusterInteriorClusterIndicesBlock> InteriorClusterIndices {
        get {
          return this._interiorClusterIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<EnclosingPortalDesignators.BlockCount; x++)
{
  IBlock block = EnclosingPortalDesignators.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InteriorClusterIndices.BlockCount; x++)
{
  IBlock block = InteriorClusterIndices.GetBlock(x);
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
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _enclosingPortalDesignators.Read(reader);
        _interiorClusterIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _enclosingPortalDesignators.Count); x = (x + 1)) {
          EnclosingPortalDesignators.Add(new StructureSoundClusterPortalDesignatorsBlock());
          EnclosingPortalDesignators[x].Read(reader);
        }
        for (x = 0; (x < _enclosingPortalDesignators.Count); x = (x + 1)) {
          EnclosingPortalDesignators[x].ReadChildData(reader);
        }
        for (x = 0; (x < _interiorClusterIndices.Count); x = (x + 1)) {
          InteriorClusterIndices.Add(new StructureSoundClusterInteriorClusterIndicesBlock());
          InteriorClusterIndices[x].Read(reader);
        }
        for (x = 0; (x < _interiorClusterIndices.Count); x = (x + 1)) {
          InteriorClusterIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_enclosingPortalDesignators.Count = EnclosingPortalDesignators.Count;
        _enclosingPortalDesignators.Write(bw);
_interiorClusterIndices.Count = InteriorClusterIndices.Count;
        _interiorClusterIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _enclosingPortalDesignators.Count); x = (x + 1)) {
          EnclosingPortalDesignators[x].Write(writer);
        }
        for (x = 0; (x < _enclosingPortalDesignators.Count); x = (x + 1)) {
          EnclosingPortalDesignators[x].WriteChildData(writer);
        }
        for (x = 0; (x < _interiorClusterIndices.Count); x = (x + 1)) {
          InteriorClusterIndices[x].Write(writer);
        }
        for (x = 0; (x < _interiorClusterIndices.Count); x = (x + 1)) {
          InteriorClusterIndices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureSoundClusterPortalDesignatorsBlock : IBlock {
      private ShortInteger _portalDesignator = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureSoundClusterPortalDesignatorsBlock() {
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
      public ShortInteger PortalDesignator {
        get {
          return this._portalDesignator;
        }
        set {
          this._portalDesignator = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _portalDesignator.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _portalDesignator.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureSoundClusterInteriorClusterIndicesBlock : IBlock {
      private ShortInteger _interiorClusterIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureSoundClusterInteriorClusterIndicesBlock() {
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
      public ShortInteger InteriorClusterIndex {
        get {
          return this._interiorClusterIndex;
        }
        set {
          this._interiorClusterIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _interiorClusterIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _interiorClusterIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class TransparentPlanesBlockBlock : IBlock {
      private ShortInteger _sectionIndex = new ShortInteger();
      private ShortInteger _partIndex = new ShortInteger();
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public TransparentPlanesBlockBlock() {
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
      public ShortInteger SectionIndex {
        get {
          return this._sectionIndex;
        }
        set {
          this._sectionIndex = value;
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
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectionIndex.Read(reader);
        _partIndex.Read(reader);
        _plane.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _sectionIndex.Write(bw);
        _partIndex.Write(bw);
        _plane.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspDebugInfoBlockBlock : IBlock {
      private Pad _unnamed0;
      private Block _clusters = new Block();
      private Block _fogPlanes = new Block();
      private Block _fogZones = new Block();
      public BlockCollection<StructureBspClusterDebugInfoBlockBlock> _clustersList = new BlockCollection<StructureBspClusterDebugInfoBlockBlock>();
      public BlockCollection<StructureBspFogPlaneDebugInfoBlockBlock> _fogPlanesList = new BlockCollection<StructureBspFogPlaneDebugInfoBlockBlock>();
      public BlockCollection<StructureBspFogZoneDebugInfoBlockBlock> _fogZonesList = new BlockCollection<StructureBspFogZoneDebugInfoBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspDebugInfoBlockBlock() {
        this._unnamed0 = new Pad(64);
      }
      public BlockCollection<StructureBspClusterDebugInfoBlockBlock> Clusters {
        get {
          return this._clustersList;
        }
      }
      public BlockCollection<StructureBspFogPlaneDebugInfoBlockBlock> FogPlanes {
        get {
          return this._fogPlanesList;
        }
      }
      public BlockCollection<StructureBspFogZoneDebugInfoBlockBlock> FogZones {
        get {
          return this._fogZonesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Clusters.BlockCount; x++)
{
  IBlock block = Clusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogPlanes.BlockCount; x++)
{
  IBlock block = FogPlanes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogZones.BlockCount; x++)
{
  IBlock block = FogZones.GetBlock(x);
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
        _unnamed0.Read(reader);
        _clusters.Read(reader);
        _fogPlanes.Read(reader);
        _fogZones.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters.Add(new StructureBspClusterDebugInfoBlockBlock());
          Clusters[x].Read(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes.Add(new StructureBspFogPlaneDebugInfoBlockBlock());
          FogPlanes[x].Read(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogZones.Count); x = (x + 1)) {
          FogZones.Add(new StructureBspFogZoneDebugInfoBlockBlock());
          FogZones[x].Read(reader);
        }
        for (x = 0; (x < _fogZones.Count); x = (x + 1)) {
          FogZones[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
_clusters.Count = Clusters.Count;
        _clusters.Write(bw);
_fogPlanes.Count = FogPlanes.Count;
        _fogPlanes.Write(bw);
_fogZones.Count = FogZones.Count;
        _fogZones.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].Write(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].Write(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogZones.Count); x = (x + 1)) {
          FogZones[x].Write(writer);
        }
        for (x = 0; (x < _fogZones.Count); x = (x + 1)) {
          FogZones[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspClusterDebugInfoBlockBlock : IBlock {
      private Flags _errors;
      private Flags _warnings;
      private Pad _unnamed0;
      private Block _lines = new Block();
      private Block _fogPlaneIndices = new Block();
      private Block _visibleFogPlaneIndices = new Block();
      private Block _visFogOmissionClusterIndices = new Block();
      private Block _containingFogZoneIndices = new Block();
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> _linesList = new BlockCollection<StructureBspDebugInfoRenderLineBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _fogPlaneIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _visibleFogPlaneIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _visFogOmissionClusterIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _containingFogZoneIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterDebugInfoBlockBlock() {
        this._errors = new Flags(2);
        this._warnings = new Flags(2);
        this._unnamed0 = new Pad(28);
      }
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> FogPlaneIndices {
        get {
          return this._fogPlaneIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> VisibleFogPlaneIndices {
        get {
          return this._visibleFogPlaneIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> VisFogOmissionClusterIndices {
        get {
          return this._visFogOmissionClusterIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> ContainingFogZoneIndices {
        get {
          return this._containingFogZoneIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogPlaneIndices.BlockCount; x++)
{
  IBlock block = FogPlaneIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VisibleFogPlaneIndices.BlockCount; x++)
{
  IBlock block = VisibleFogPlaneIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VisFogOmissionClusterIndices.BlockCount; x++)
{
  IBlock block = VisFogOmissionClusterIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ContainingFogZoneIndices.BlockCount; x++)
{
  IBlock block = ContainingFogZoneIndices.GetBlock(x);
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
      public Flags Errors {
        get {
          return this._errors;
        }
        set {
          this._errors = value;
        }
      }
      public Flags Warnings {
        get {
          return this._warnings;
        }
        set {
          this._warnings = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _errors.Read(reader);
        _warnings.Read(reader);
        _unnamed0.Read(reader);
        _lines.Read(reader);
        _fogPlaneIndices.Read(reader);
        _visibleFogPlaneIndices.Read(reader);
        _visFogOmissionClusterIndices.Read(reader);
        _containingFogZoneIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new StructureBspDebugInfoRenderLineBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogPlaneIndices.Count); x = (x + 1)) {
          FogPlaneIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          FogPlaneIndices[x].Read(reader);
        }
        for (x = 0; (x < _fogPlaneIndices.Count); x = (x + 1)) {
          FogPlaneIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _visibleFogPlaneIndices.Count); x = (x + 1)) {
          VisibleFogPlaneIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          VisibleFogPlaneIndices[x].Read(reader);
        }
        for (x = 0; (x < _visibleFogPlaneIndices.Count); x = (x + 1)) {
          VisibleFogPlaneIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _visFogOmissionClusterIndices.Count); x = (x + 1)) {
          VisFogOmissionClusterIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          VisFogOmissionClusterIndices[x].Read(reader);
        }
        for (x = 0; (x < _visFogOmissionClusterIndices.Count); x = (x + 1)) {
          VisFogOmissionClusterIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _containingFogZoneIndices.Count); x = (x + 1)) {
          ContainingFogZoneIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          ContainingFogZoneIndices[x].Read(reader);
        }
        for (x = 0; (x < _containingFogZoneIndices.Count); x = (x + 1)) {
          ContainingFogZoneIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _errors.Write(bw);
        _warnings.Write(bw);
        _unnamed0.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_fogPlaneIndices.Count = FogPlaneIndices.Count;
        _fogPlaneIndices.Write(bw);
_visibleFogPlaneIndices.Count = VisibleFogPlaneIndices.Count;
        _visibleFogPlaneIndices.Write(bw);
_visFogOmissionClusterIndices.Count = VisFogOmissionClusterIndices.Count;
        _visFogOmissionClusterIndices.Write(bw);
_containingFogZoneIndices.Count = ContainingFogZoneIndices.Count;
        _containingFogZoneIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogPlaneIndices.Count); x = (x + 1)) {
          FogPlaneIndices[x].Write(writer);
        }
        for (x = 0; (x < _fogPlaneIndices.Count); x = (x + 1)) {
          FogPlaneIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _visibleFogPlaneIndices.Count); x = (x + 1)) {
          VisibleFogPlaneIndices[x].Write(writer);
        }
        for (x = 0; (x < _visibleFogPlaneIndices.Count); x = (x + 1)) {
          VisibleFogPlaneIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _visFogOmissionClusterIndices.Count); x = (x + 1)) {
          VisFogOmissionClusterIndices[x].Write(writer);
        }
        for (x = 0; (x < _visFogOmissionClusterIndices.Count); x = (x + 1)) {
          VisFogOmissionClusterIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _containingFogZoneIndices.Count); x = (x + 1)) {
          ContainingFogZoneIndices[x].Write(writer);
        }
        for (x = 0; (x < _containingFogZoneIndices.Count); x = (x + 1)) {
          ContainingFogZoneIndices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspDebugInfoRenderLineBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _code = new ShortInteger();
      private ShortInteger _padThai = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _point0 = new RealPoint3D();
      private RealPoint3D _point1 = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspDebugInfoRenderLineBlockBlock() {
        this._type = new Enum(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger Code {
        get {
          return this._code;
        }
        set {
          this._code = value;
        }
      }
      public ShortInteger PadThai {
        get {
          return this._padThai;
        }
        set {
          this._padThai = value;
        }
      }
      public RealPoint3D Point0 {
        get {
          return this._point0;
        }
        set {
          this._point0 = value;
        }
      }
      public RealPoint3D Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _code.Read(reader);
        _padThai.Read(reader);
        _unnamed0.Read(reader);
        _point0.Read(reader);
        _point1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _code.Write(bw);
        _padThai.Write(bw);
        _unnamed0.Write(bw);
        _point0.Write(bw);
        _point1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspDebugInfoIndicesBlockBlock : IBlock {
      private LongInteger _index = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspDebugInfoIndicesBlockBlock() {
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
      public LongInteger Index {
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
    public class StructureBspFogPlaneDebugInfoBlockBlock : IBlock {
      private LongInteger _fogZoneIndex = new LongInteger();
      private Pad _unnamed0;
      private LongInteger _connectedPlaneDesignator = new LongInteger();
      private Block _lines = new Block();
      private Block _intersectedClusterIndices = new Block();
      private Block _infExtentClusterIndices = new Block();
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> _linesList = new BlockCollection<StructureBspDebugInfoRenderLineBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _intersectedClusterIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _infExtentClusterIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogPlaneDebugInfoBlockBlock() {
        this._unnamed0 = new Pad(24);
      }
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> IntersectedClusterIndices {
        get {
          return this._intersectedClusterIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> InfExtentClusterIndices {
        get {
          return this._infExtentClusterIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IntersectedClusterIndices.BlockCount; x++)
{
  IBlock block = IntersectedClusterIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InfExtentClusterIndices.BlockCount; x++)
{
  IBlock block = InfExtentClusterIndices.GetBlock(x);
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
      public LongInteger FogZoneIndex {
        get {
          return this._fogZoneIndex;
        }
        set {
          this._fogZoneIndex = value;
        }
      }
      public LongInteger ConnectedPlaneDesignator {
        get {
          return this._connectedPlaneDesignator;
        }
        set {
          this._connectedPlaneDesignator = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fogZoneIndex.Read(reader);
        _unnamed0.Read(reader);
        _connectedPlaneDesignator.Read(reader);
        _lines.Read(reader);
        _intersectedClusterIndices.Read(reader);
        _infExtentClusterIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new StructureBspDebugInfoRenderLineBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _intersectedClusterIndices.Count); x = (x + 1)) {
          IntersectedClusterIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          IntersectedClusterIndices[x].Read(reader);
        }
        for (x = 0; (x < _intersectedClusterIndices.Count); x = (x + 1)) {
          IntersectedClusterIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _infExtentClusterIndices.Count); x = (x + 1)) {
          InfExtentClusterIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          InfExtentClusterIndices[x].Read(reader);
        }
        for (x = 0; (x < _infExtentClusterIndices.Count); x = (x + 1)) {
          InfExtentClusterIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _fogZoneIndex.Write(bw);
        _unnamed0.Write(bw);
        _connectedPlaneDesignator.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_intersectedClusterIndices.Count = IntersectedClusterIndices.Count;
        _intersectedClusterIndices.Write(bw);
_infExtentClusterIndices.Count = InfExtentClusterIndices.Count;
        _infExtentClusterIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _intersectedClusterIndices.Count); x = (x + 1)) {
          IntersectedClusterIndices[x].Write(writer);
        }
        for (x = 0; (x < _intersectedClusterIndices.Count); x = (x + 1)) {
          IntersectedClusterIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _infExtentClusterIndices.Count); x = (x + 1)) {
          InfExtentClusterIndices[x].Write(writer);
        }
        for (x = 0; (x < _infExtentClusterIndices.Count); x = (x + 1)) {
          InfExtentClusterIndices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspFogZoneDebugInfoBlockBlock : IBlock {
      private LongInteger _mediaIndex = new LongInteger();
      private LongInteger _baseFogPlaneIndex = new LongInteger();
      private Pad _unnamed0;
      private Block _lines = new Block();
      private Block _immersedClusterIndices = new Block();
      private Block _boundingFogPlaneIndices = new Block();
      private Block _collisionFogPlaneIndices = new Block();
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> _linesList = new BlockCollection<StructureBspDebugInfoRenderLineBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _immersedClusterIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _boundingFogPlaneIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> _collisionFogPlaneIndicesList = new BlockCollection<StructureBspDebugInfoIndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogZoneDebugInfoBlockBlock() {
        this._unnamed0 = new Pad(24);
      }
      public BlockCollection<StructureBspDebugInfoRenderLineBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> ImmersedClusterIndices {
        get {
          return this._immersedClusterIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> BoundingFogPlaneIndices {
        get {
          return this._boundingFogPlaneIndicesList;
        }
      }
      public BlockCollection<StructureBspDebugInfoIndicesBlockBlock> CollisionFogPlaneIndices {
        get {
          return this._collisionFogPlaneIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ImmersedClusterIndices.BlockCount; x++)
{
  IBlock block = ImmersedClusterIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BoundingFogPlaneIndices.BlockCount; x++)
{
  IBlock block = BoundingFogPlaneIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CollisionFogPlaneIndices.BlockCount; x++)
{
  IBlock block = CollisionFogPlaneIndices.GetBlock(x);
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
      public LongInteger MediaIndex {
        get {
          return this._mediaIndex;
        }
        set {
          this._mediaIndex = value;
        }
      }
      public LongInteger BaseFogPlaneIndex {
        get {
          return this._baseFogPlaneIndex;
        }
        set {
          this._baseFogPlaneIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mediaIndex.Read(reader);
        _baseFogPlaneIndex.Read(reader);
        _unnamed0.Read(reader);
        _lines.Read(reader);
        _immersedClusterIndices.Read(reader);
        _boundingFogPlaneIndices.Read(reader);
        _collisionFogPlaneIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new StructureBspDebugInfoRenderLineBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _immersedClusterIndices.Count); x = (x + 1)) {
          ImmersedClusterIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          ImmersedClusterIndices[x].Read(reader);
        }
        for (x = 0; (x < _immersedClusterIndices.Count); x = (x + 1)) {
          ImmersedClusterIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _boundingFogPlaneIndices.Count); x = (x + 1)) {
          BoundingFogPlaneIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          BoundingFogPlaneIndices[x].Read(reader);
        }
        for (x = 0; (x < _boundingFogPlaneIndices.Count); x = (x + 1)) {
          BoundingFogPlaneIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _collisionFogPlaneIndices.Count); x = (x + 1)) {
          CollisionFogPlaneIndices.Add(new StructureBspDebugInfoIndicesBlockBlock());
          CollisionFogPlaneIndices[x].Read(reader);
        }
        for (x = 0; (x < _collisionFogPlaneIndices.Count); x = (x + 1)) {
          CollisionFogPlaneIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _mediaIndex.Write(bw);
        _baseFogPlaneIndex.Write(bw);
        _unnamed0.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_immersedClusterIndices.Count = ImmersedClusterIndices.Count;
        _immersedClusterIndices.Write(bw);
_boundingFogPlaneIndices.Count = BoundingFogPlaneIndices.Count;
        _boundingFogPlaneIndices.Write(bw);
_collisionFogPlaneIndices.Count = CollisionFogPlaneIndices.Count;
        _collisionFogPlaneIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _immersedClusterIndices.Count); x = (x + 1)) {
          ImmersedClusterIndices[x].Write(writer);
        }
        for (x = 0; (x < _immersedClusterIndices.Count); x = (x + 1)) {
          ImmersedClusterIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _boundingFogPlaneIndices.Count); x = (x + 1)) {
          BoundingFogPlaneIndices[x].Write(writer);
        }
        for (x = 0; (x < _boundingFogPlaneIndices.Count); x = (x + 1)) {
          BoundingFogPlaneIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _collisionFogPlaneIndices.Count); x = (x + 1)) {
          CollisionFogPlaneIndices[x].Write(writer);
        }
        for (x = 0; (x < _collisionFogPlaneIndices.Count); x = (x + 1)) {
          CollisionFogPlaneIndices[x].WriteChildData(writer);
        }
      }
    }
    public class BreakableSurfaceKeyTableBlockBlock : IBlock {
      private ShortInteger _instancedGeometryIndex = new ShortInteger();
      private ShortInteger _breakableSurfaceIndex = new ShortInteger();
      private LongInteger _seedSurfaceIndex = new LongInteger();
      private Real _x0 = new Real();
      private Real _x1 = new Real();
      private Real _y0 = new Real();
      private Real _y1 = new Real();
      private Real _z0 = new Real();
      private Real _z1 = new Real();
public event System.EventHandler BlockNameChanged;
      public BreakableSurfaceKeyTableBlockBlock() {
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
      public ShortInteger InstancedGeometryIndex {
        get {
          return this._instancedGeometryIndex;
        }
        set {
          this._instancedGeometryIndex = value;
        }
      }
      public ShortInteger BreakableSurfaceIndex {
        get {
          return this._breakableSurfaceIndex;
        }
        set {
          this._breakableSurfaceIndex = value;
        }
      }
      public LongInteger SeedSurfaceIndex {
        get {
          return this._seedSurfaceIndex;
        }
        set {
          this._seedSurfaceIndex = value;
        }
      }
      public Real X0 {
        get {
          return this._x0;
        }
        set {
          this._x0 = value;
        }
      }
      public Real X1 {
        get {
          return this._x1;
        }
        set {
          this._x1 = value;
        }
      }
      public Real Y0 {
        get {
          return this._y0;
        }
        set {
          this._y0 = value;
        }
      }
      public Real Y1 {
        get {
          return this._y1;
        }
        set {
          this._y1 = value;
        }
      }
      public Real Z0 {
        get {
          return this._z0;
        }
        set {
          this._z0 = value;
        }
      }
      public Real Z1 {
        get {
          return this._z1;
        }
        set {
          this._z1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _instancedGeometryIndex.Read(reader);
        _breakableSurfaceIndex.Read(reader);
        _seedSurfaceIndex.Read(reader);
        _x0.Read(reader);
        _x1.Read(reader);
        _y0.Read(reader);
        _y1.Read(reader);
        _z0.Read(reader);
        _z1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _instancedGeometryIndex.Write(bw);
        _breakableSurfaceIndex.Write(bw);
        _seedSurfaceIndex.Write(bw);
        _x0.Write(bw);
        _x1.Write(bw);
        _y0.Write(bw);
        _y1.Write(bw);
        _z0.Write(bw);
        _z1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalWaterDefinitionsBlockBlock : IBlock {
      private TagReference _shader = new TagReference();
      private Block _section = new Block();
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private RealRGBColor _sunSpotColor = new RealRGBColor();
      private RealRGBColor _reflectionTint = new RealRGBColor();
      private RealRGBColor _refractionTint = new RealRGBColor();
      private RealRGBColor _horizonColor = new RealRGBColor();
      private Real _sunSpecularPower = new Real();
      private Real _reflectionBumpScale = new Real();
      private Real _refractionBumpScale = new Real();
      private Real _fresnelScale = new Real();
      private Real _sunDirHeading = new Real();
      private Real _sunDirPitch = new Real();
      private Real _fOV = new Real();
      private Real _aspect = new Real();
      private Real _height = new Real();
      private Real _farz = new Real();
      private Real _rotateoffset = new Real();
      private RealVector2D _center = new RealVector2D();
      private RealVector2D _extents = new RealVector2D();
      private Real _fogNear = new Real();
      private Real _fogFar = new Real();
      private Real _dynamicheightbias = new Real();
      public BlockCollection<WaterGeometrySectionBlockBlock> _sectionList = new BlockCollection<WaterGeometrySectionBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalWaterDefinitionsBlockBlock() {
        this._geometrySelfReference = new Skip(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
      }
      public BlockCollection<WaterGeometrySectionBlockBlock> Section {
        get {
          return this._sectionList;
        }
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
for (int x=0; x<Section.BlockCount; x++)
{
  IBlock block = Section.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
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
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
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
      public RealRGBColor SunSpotColor {
        get {
          return this._sunSpotColor;
        }
        set {
          this._sunSpotColor = value;
        }
      }
      public RealRGBColor ReflectionTint {
        get {
          return this._reflectionTint;
        }
        set {
          this._reflectionTint = value;
        }
      }
      public RealRGBColor RefractionTint {
        get {
          return this._refractionTint;
        }
        set {
          this._refractionTint = value;
        }
      }
      public RealRGBColor HorizonColor {
        get {
          return this._horizonColor;
        }
        set {
          this._horizonColor = value;
        }
      }
      public Real SunSpecularPower {
        get {
          return this._sunSpecularPower;
        }
        set {
          this._sunSpecularPower = value;
        }
      }
      public Real ReflectionBumpScale {
        get {
          return this._reflectionBumpScale;
        }
        set {
          this._reflectionBumpScale = value;
        }
      }
      public Real RefractionBumpScale {
        get {
          return this._refractionBumpScale;
        }
        set {
          this._refractionBumpScale = value;
        }
      }
      public Real FresnelScale {
        get {
          return this._fresnelScale;
        }
        set {
          this._fresnelScale = value;
        }
      }
      public Real SunDirHeading {
        get {
          return this._sunDirHeading;
        }
        set {
          this._sunDirHeading = value;
        }
      }
      public Real SunDirPitch {
        get {
          return this._sunDirPitch;
        }
        set {
          this._sunDirPitch = value;
        }
      }
      public Real FOV {
        get {
          return this._fOV;
        }
        set {
          this._fOV = value;
        }
      }
      public Real Aspect {
        get {
          return this._aspect;
        }
        set {
          this._aspect = value;
        }
      }
      public Real Height {
        get {
          return this._height;
        }
        set {
          this._height = value;
        }
      }
      public Real Farz {
        get {
          return this._farz;
        }
        set {
          this._farz = value;
        }
      }
      public Real Rotateoffset {
        get {
          return this._rotateoffset;
        }
        set {
          this._rotateoffset = value;
        }
      }
      public RealVector2D Center {
        get {
          return this._center;
        }
        set {
          this._center = value;
        }
      }
      public RealVector2D Extents {
        get {
          return this._extents;
        }
        set {
          this._extents = value;
        }
      }
      public Real FogNear {
        get {
          return this._fogNear;
        }
        set {
          this._fogNear = value;
        }
      }
      public Real FogFar {
        get {
          return this._fogFar;
        }
        set {
          this._fogFar = value;
        }
      }
      public Real Dynamicheightbias {
        get {
          return this._dynamicheightbias;
        }
        set {
          this._dynamicheightbias = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shader.Read(reader);
        _section.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _sunSpotColor.Read(reader);
        _reflectionTint.Read(reader);
        _refractionTint.Read(reader);
        _horizonColor.Read(reader);
        _sunSpecularPower.Read(reader);
        _reflectionBumpScale.Read(reader);
        _refractionBumpScale.Read(reader);
        _fresnelScale.Read(reader);
        _sunDirHeading.Read(reader);
        _sunDirPitch.Read(reader);
        _fOV.Read(reader);
        _aspect.Read(reader);
        _height.Read(reader);
        _farz.Read(reader);
        _rotateoffset.Read(reader);
        _center.Read(reader);
        _extents.Read(reader);
        _fogNear.Read(reader);
        _fogFar.Read(reader);
        _dynamicheightbias.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _shader.ReadString(reader);
        for (x = 0; (x < _section.Count); x = (x + 1)) {
          Section.Add(new WaterGeometrySectionBlockBlock());
          Section[x].Read(reader);
        }
        for (x = 0; (x < _section.Count); x = (x + 1)) {
          Section[x].ReadChildData(reader);
        }
        _resourceData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
_section.Count = Section.Count;
        _section.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _sunSpotColor.Write(bw);
        _reflectionTint.Write(bw);
        _refractionTint.Write(bw);
        _horizonColor.Write(bw);
        _sunSpecularPower.Write(bw);
        _reflectionBumpScale.Write(bw);
        _refractionBumpScale.Write(bw);
        _fresnelScale.Write(bw);
        _sunDirHeading.Write(bw);
        _sunDirPitch.Write(bw);
        _fOV.Write(bw);
        _aspect.Write(bw);
        _height.Write(bw);
        _farz.Write(bw);
        _rotateoffset.Write(bw);
        _center.Write(bw);
        _extents.Write(bw);
        _fogNear.Write(bw);
        _fogFar.Write(bw);
        _dynamicheightbias.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _shader.WriteString(writer);
        for (x = 0; (x < _section.Count); x = (x + 1)) {
          Section[x].Write(writer);
        }
        for (x = 0; (x < _section.Count); x = (x + 1)) {
          Section[x].WriteChildData(writer);
        }
        _resourceData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
      }
    }
    public class WaterGeometrySectionBlockBlock : IBlock {
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
      public WaterGeometrySectionBlockBlock() {
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
    public class StructurePortalDeviceMappingBlockBlock : IBlock {
      private Block _devicePortalAssociations = new Block();
      private Block _gamePortalToPortalMap = new Block();
      public BlockCollection<StructureDevicePortalAssociationBlockBlock> _devicePortalAssociationsList = new BlockCollection<StructureDevicePortalAssociationBlockBlock>();
      public BlockCollection<GamePortalToPortalMappingBlockBlock> _gamePortalToPortalMapList = new BlockCollection<GamePortalToPortalMappingBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StructurePortalDeviceMappingBlockBlock() {
      }
      public BlockCollection<StructureDevicePortalAssociationBlockBlock> DevicePortalAssociations {
        get {
          return this._devicePortalAssociationsList;
        }
      }
      public BlockCollection<GamePortalToPortalMappingBlockBlock> GamePortalToPortalMap {
        get {
          return this._gamePortalToPortalMapList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<DevicePortalAssociations.BlockCount; x++)
{
  IBlock block = DevicePortalAssociations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<GamePortalToPortalMap.BlockCount; x++)
{
  IBlock block = GamePortalToPortalMap.GetBlock(x);
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
        _devicePortalAssociations.Read(reader);
        _gamePortalToPortalMap.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _devicePortalAssociations.Count); x = (x + 1)) {
          DevicePortalAssociations.Add(new StructureDevicePortalAssociationBlockBlock());
          DevicePortalAssociations[x].Read(reader);
        }
        for (x = 0; (x < _devicePortalAssociations.Count); x = (x + 1)) {
          DevicePortalAssociations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _gamePortalToPortalMap.Count); x = (x + 1)) {
          GamePortalToPortalMap.Add(new GamePortalToPortalMappingBlockBlock());
          GamePortalToPortalMap[x].Read(reader);
        }
        for (x = 0; (x < _gamePortalToPortalMap.Count); x = (x + 1)) {
          GamePortalToPortalMap[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_devicePortalAssociations.Count = DevicePortalAssociations.Count;
        _devicePortalAssociations.Write(bw);
_gamePortalToPortalMap.Count = GamePortalToPortalMap.Count;
        _gamePortalToPortalMap.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _devicePortalAssociations.Count); x = (x + 1)) {
          DevicePortalAssociations[x].Write(writer);
        }
        for (x = 0; (x < _devicePortalAssociations.Count); x = (x + 1)) {
          DevicePortalAssociations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _gamePortalToPortalMap.Count); x = (x + 1)) {
          GamePortalToPortalMap[x].Write(writer);
        }
        for (x = 0; (x < _gamePortalToPortalMap.Count); x = (x + 1)) {
          GamePortalToPortalMap[x].WriteChildData(writer);
        }
      }
    }
    public class StructureDevicePortalAssociationBlockBlock : IBlock {
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type;
      private Enum _source;
      private ShortInteger _firstGamePortalIndex = new ShortInteger();
      private ShortInteger _gamePortalCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureDevicePortalAssociationBlockBlock() {
        this._type = new Enum(1);
        this._source = new Enum(1);
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
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public ShortInteger FirstGamePortalIndex {
        get {
          return this._firstGamePortalIndex;
        }
        set {
          this._firstGamePortalIndex = value;
        }
      }
      public ShortInteger GamePortalCount {
        get {
          return this._gamePortalCount;
        }
        set {
          this._gamePortalCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type.Read(reader);
        _source.Read(reader);
        _firstGamePortalIndex.Read(reader);
        _gamePortalCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type.Write(bw);
        _source.Write(bw);
        _firstGamePortalIndex.Write(bw);
        _gamePortalCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GamePortalToPortalMappingBlockBlock : IBlock {
      private ShortInteger _portalIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GamePortalToPortalMappingBlockBlock() {
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
      public ShortInteger PortalIndex {
        get {
          return this._portalIndex;
        }
        set {
          this._portalIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _portalIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _portalIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspAudibilityBlockBlock : IBlock {
      private LongInteger _doorPortalCount = new LongInteger();
      private RealBounds _clusterDistanceBounds = new RealBounds();
      private Block _encodedDoorPas = new Block();
      private Block _clusterDoorPortalEncodedPas = new Block();
      private Block _aiDeafeningPas = new Block();
      private Block _clusterDistances = new Block();
      private Block _machineDoorMapping = new Block();
      public BlockCollection<DoorEncodedPasBlockBlock> _encodedDoorPasList = new BlockCollection<DoorEncodedPasBlockBlock>();
      public BlockCollection<ClusterDoorPortalEncodedPasBlockBlock> _clusterDoorPortalEncodedPasList = new BlockCollection<ClusterDoorPortalEncodedPasBlockBlock>();
      public BlockCollection<AiDeafeningEncodedPasBlockBlock> _aiDeafeningPasList = new BlockCollection<AiDeafeningEncodedPasBlockBlock>();
      public BlockCollection<EncodedClusterDistancesBlockBlock> _clusterDistancesList = new BlockCollection<EncodedClusterDistancesBlockBlock>();
      public BlockCollection<OccluderToMachineDoorMappingBlock> _machineDoorMappingList = new BlockCollection<OccluderToMachineDoorMappingBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspAudibilityBlockBlock() {
      }
      public BlockCollection<DoorEncodedPasBlockBlock> EncodedDoorPas {
        get {
          return this._encodedDoorPasList;
        }
      }
      public BlockCollection<ClusterDoorPortalEncodedPasBlockBlock> ClusterDoorPortalEncodedPas {
        get {
          return this._clusterDoorPortalEncodedPasList;
        }
      }
      public BlockCollection<AiDeafeningEncodedPasBlockBlock> AiDeafeningPas {
        get {
          return this._aiDeafeningPasList;
        }
      }
      public BlockCollection<EncodedClusterDistancesBlockBlock> ClusterDistances {
        get {
          return this._clusterDistancesList;
        }
      }
      public BlockCollection<OccluderToMachineDoorMappingBlock> MachineDoorMapping {
        get {
          return this._machineDoorMappingList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<EncodedDoorPas.BlockCount; x++)
{
  IBlock block = EncodedDoorPas.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterDoorPortalEncodedPas.BlockCount; x++)
{
  IBlock block = ClusterDoorPortalEncodedPas.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiDeafeningPas.BlockCount; x++)
{
  IBlock block = AiDeafeningPas.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterDistances.BlockCount; x++)
{
  IBlock block = ClusterDistances.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MachineDoorMapping.BlockCount; x++)
{
  IBlock block = MachineDoorMapping.GetBlock(x);
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
      public LongInteger DoorPortalCount {
        get {
          return this._doorPortalCount;
        }
        set {
          this._doorPortalCount = value;
        }
      }
      public RealBounds ClusterDistanceBounds {
        get {
          return this._clusterDistanceBounds;
        }
        set {
          this._clusterDistanceBounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _doorPortalCount.Read(reader);
        _clusterDistanceBounds.Read(reader);
        _encodedDoorPas.Read(reader);
        _clusterDoorPortalEncodedPas.Read(reader);
        _aiDeafeningPas.Read(reader);
        _clusterDistances.Read(reader);
        _machineDoorMapping.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _encodedDoorPas.Count); x = (x + 1)) {
          EncodedDoorPas.Add(new DoorEncodedPasBlockBlock());
          EncodedDoorPas[x].Read(reader);
        }
        for (x = 0; (x < _encodedDoorPas.Count); x = (x + 1)) {
          EncodedDoorPas[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusterDoorPortalEncodedPas.Count); x = (x + 1)) {
          ClusterDoorPortalEncodedPas.Add(new ClusterDoorPortalEncodedPasBlockBlock());
          ClusterDoorPortalEncodedPas[x].Read(reader);
        }
        for (x = 0; (x < _clusterDoorPortalEncodedPas.Count); x = (x + 1)) {
          ClusterDoorPortalEncodedPas[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiDeafeningPas.Count); x = (x + 1)) {
          AiDeafeningPas.Add(new AiDeafeningEncodedPasBlockBlock());
          AiDeafeningPas[x].Read(reader);
        }
        for (x = 0; (x < _aiDeafeningPas.Count); x = (x + 1)) {
          AiDeafeningPas[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusterDistances.Count); x = (x + 1)) {
          ClusterDistances.Add(new EncodedClusterDistancesBlockBlock());
          ClusterDistances[x].Read(reader);
        }
        for (x = 0; (x < _clusterDistances.Count); x = (x + 1)) {
          ClusterDistances[x].ReadChildData(reader);
        }
        for (x = 0; (x < _machineDoorMapping.Count); x = (x + 1)) {
          MachineDoorMapping.Add(new OccluderToMachineDoorMappingBlock());
          MachineDoorMapping[x].Read(reader);
        }
        for (x = 0; (x < _machineDoorMapping.Count); x = (x + 1)) {
          MachineDoorMapping[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _doorPortalCount.Write(bw);
        _clusterDistanceBounds.Write(bw);
_encodedDoorPas.Count = EncodedDoorPas.Count;
        _encodedDoorPas.Write(bw);
_clusterDoorPortalEncodedPas.Count = ClusterDoorPortalEncodedPas.Count;
        _clusterDoorPortalEncodedPas.Write(bw);
_aiDeafeningPas.Count = AiDeafeningPas.Count;
        _aiDeafeningPas.Write(bw);
_clusterDistances.Count = ClusterDistances.Count;
        _clusterDistances.Write(bw);
_machineDoorMapping.Count = MachineDoorMapping.Count;
        _machineDoorMapping.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _encodedDoorPas.Count); x = (x + 1)) {
          EncodedDoorPas[x].Write(writer);
        }
        for (x = 0; (x < _encodedDoorPas.Count); x = (x + 1)) {
          EncodedDoorPas[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusterDoorPortalEncodedPas.Count); x = (x + 1)) {
          ClusterDoorPortalEncodedPas[x].Write(writer);
        }
        for (x = 0; (x < _clusterDoorPortalEncodedPas.Count); x = (x + 1)) {
          ClusterDoorPortalEncodedPas[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiDeafeningPas.Count); x = (x + 1)) {
          AiDeafeningPas[x].Write(writer);
        }
        for (x = 0; (x < _aiDeafeningPas.Count); x = (x + 1)) {
          AiDeafeningPas[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusterDistances.Count); x = (x + 1)) {
          ClusterDistances[x].Write(writer);
        }
        for (x = 0; (x < _clusterDistances.Count); x = (x + 1)) {
          ClusterDistances[x].WriteChildData(writer);
        }
        for (x = 0; (x < _machineDoorMapping.Count); x = (x + 1)) {
          MachineDoorMapping[x].Write(writer);
        }
        for (x = 0; (x < _machineDoorMapping.Count); x = (x + 1)) {
          MachineDoorMapping[x].WriteChildData(writer);
        }
      }
    }
    public class DoorEncodedPasBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DoorEncodedPasBlockBlock() {
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
    public class ClusterDoorPortalEncodedPasBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public ClusterDoorPortalEncodedPasBlockBlock() {
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
    public class AiDeafeningEncodedPasBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public AiDeafeningEncodedPasBlockBlock() {
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
    public class EncodedClusterDistancesBlockBlock : IBlock {
      private CharInteger _unnamed0 = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public EncodedClusterDistancesBlockBlock() {
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
      public CharInteger unnamed0 {
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
    public class OccluderToMachineDoorMappingBlock : IBlock {
      private CharInteger _machineDoorIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public OccluderToMachineDoorMappingBlock() {
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
      public CharInteger MachineDoorIndex {
        get {
          return this._machineDoorIndex;
        }
        set {
          this._machineDoorIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _machineDoorIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _machineDoorIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspFakeLightprobesBlockBlock : IBlock {
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type;
      private Enum _source;
      private RealRGBColor _ambient = new RealRGBColor();
      private RealVector3D _shadowDirection = new RealVector3D();
      private Real _lightingaccuracy = new Real();
      private Real _shadowOpacity = new Real();
      private RealRGBColor _primaryDirectionColor = new RealRGBColor();
      private RealVector3D _primaryDirection = new RealVector3D();
      private RealRGBColor _secondaryDirectionColor = new RealRGBColor();
      private RealVector3D _secondaryDirection = new RealVector3D();
      private ShortInteger _shIndex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureBspFakeLightprobesBlockBlock() {
        this._type = new Enum(1);
        this._source = new Enum(1);
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
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public RealRGBColor Ambient {
        get {
          return this._ambient;
        }
        set {
          this._ambient = value;
        }
      }
      public RealVector3D ShadowDirection {
        get {
          return this._shadowDirection;
        }
        set {
          this._shadowDirection = value;
        }
      }
      public Real Lightingaccuracy {
        get {
          return this._lightingaccuracy;
        }
        set {
          this._lightingaccuracy = value;
        }
      }
      public Real ShadowOpacity {
        get {
          return this._shadowOpacity;
        }
        set {
          this._shadowOpacity = value;
        }
      }
      public RealRGBColor PrimaryDirectionColor {
        get {
          return this._primaryDirectionColor;
        }
        set {
          this._primaryDirectionColor = value;
        }
      }
      public RealVector3D PrimaryDirection {
        get {
          return this._primaryDirection;
        }
        set {
          this._primaryDirection = value;
        }
      }
      public RealRGBColor SecondaryDirectionColor {
        get {
          return this._secondaryDirectionColor;
        }
        set {
          this._secondaryDirectionColor = value;
        }
      }
      public RealVector3D SecondaryDirection {
        get {
          return this._secondaryDirection;
        }
        set {
          this._secondaryDirection = value;
        }
      }
      public ShortInteger ShIndex {
        get {
          return this._shIndex;
        }
        set {
          this._shIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type.Read(reader);
        _source.Read(reader);
        _ambient.Read(reader);
        _shadowDirection.Read(reader);
        _lightingaccuracy.Read(reader);
        _shadowOpacity.Read(reader);
        _primaryDirectionColor.Read(reader);
        _primaryDirection.Read(reader);
        _secondaryDirectionColor.Read(reader);
        _secondaryDirection.Read(reader);
        _shIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type.Write(bw);
        _source.Write(bw);
        _ambient.Write(bw);
        _shadowDirection.Write(bw);
        _lightingaccuracy.Write(bw);
        _shadowOpacity.Write(bw);
        _primaryDirectionColor.Write(bw);
        _primaryDirection.Write(bw);
        _secondaryDirectionColor.Write(bw);
        _secondaryDirection.Write(bw);
        _shIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorPlacementDefinitionBlockBlock : IBlock {
      private RealPoint3D _gridOrigin = new RealPoint3D();
      private LongInteger _cellCountPerDimension = new LongInteger();
      private Block _cacheBlocks = new Block();
      private Block _groups = new Block();
      private Block _cells = new Block();
      private Block _decals = new Block();
      public BlockCollection<DecoratorCacheBlockBlockBlock> _cacheBlocksList = new BlockCollection<DecoratorCacheBlockBlockBlock>();
      public BlockCollection<DecoratorGroupBlockBlock> _groupsList = new BlockCollection<DecoratorGroupBlockBlock>();
      public BlockCollection<DecoratorCellCollectionBlockBlock> _cellsList = new BlockCollection<DecoratorCellCollectionBlockBlock>();
      public BlockCollection<DecoratorProjectedDecalBlockBlock> _decalsList = new BlockCollection<DecoratorProjectedDecalBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorPlacementDefinitionBlockBlock() {
      }
      public BlockCollection<DecoratorCacheBlockBlockBlock> CacheBlocks {
        get {
          return this._cacheBlocksList;
        }
      }
      public BlockCollection<DecoratorGroupBlockBlock> Groups {
        get {
          return this._groupsList;
        }
      }
      public BlockCollection<DecoratorCellCollectionBlockBlock> Cells {
        get {
          return this._cellsList;
        }
      }
      public BlockCollection<DecoratorProjectedDecalBlockBlock> Decals {
        get {
          return this._decalsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CacheBlocks.BlockCount; x++)
{
  IBlock block = CacheBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Groups.BlockCount; x++)
{
  IBlock block = Groups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Cells.BlockCount; x++)
{
  IBlock block = Cells.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decals.BlockCount; x++)
{
  IBlock block = Decals.GetBlock(x);
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
      public RealPoint3D GridOrigin {
        get {
          return this._gridOrigin;
        }
        set {
          this._gridOrigin = value;
        }
      }
      public LongInteger CellCountPerDimension {
        get {
          return this._cellCountPerDimension;
        }
        set {
          this._cellCountPerDimension = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _gridOrigin.Read(reader);
        _cellCountPerDimension.Read(reader);
        _cacheBlocks.Read(reader);
        _groups.Read(reader);
        _cells.Read(reader);
        _decals.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks.Add(new DecoratorCacheBlockBlockBlock());
          CacheBlocks[x].Read(reader);
        }
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups.Add(new DecoratorGroupBlockBlock());
          Groups[x].Read(reader);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells.Add(new DecoratorCellCollectionBlockBlock());
          Cells[x].Read(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals.Add(new DecoratorProjectedDecalBlockBlock());
          Decals[x].Read(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _gridOrigin.Write(bw);
        _cellCountPerDimension.Write(bw);
_cacheBlocks.Count = CacheBlocks.Count;
        _cacheBlocks.Write(bw);
_groups.Count = Groups.Count;
        _groups.Write(bw);
_cells.Count = Cells.Count;
        _cells.Write(bw);
_decals.Count = Decals.Count;
        _decals.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].Write(writer);
        }
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].Write(writer);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].Write(writer);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].Write(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].WriteChildData(writer);
        }
      }
    }
    public class DecoratorCacheBlockBlockBlock : IBlock {
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Pad _unnamed3;
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorCacheBlockBlockBlock() {
        this._geometrySelfReference = new Skip(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
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
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _resourceData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _resourceData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
      }
    }
    public class DecoratorGroupBlockBlock : IBlock {
      private CharBlockIndex _decoratorSet = new CharBlockIndex();
      private Enum _decoratorType;
      private CharInteger _shaderIndex = new CharInteger();
      private CharInteger _compressedRadius = new CharInteger();
      private ShortInteger _cluster = new ShortInteger();
      private ShortBlockIndex _cacheBlock = new ShortBlockIndex();
      private ShortInteger _decoratorStartIndex = new ShortInteger();
      private ShortInteger _decoratorCount = new ShortInteger();
      private ShortInteger _vertexStartOffset = new ShortInteger();
      private ShortInteger _vertexCount = new ShortInteger();
      private ShortInteger _indexStartOffset = new ShortInteger();
      private ShortInteger _indexCount = new ShortInteger();
      private LongInteger _compressedBoundingCenter = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorGroupBlockBlock() {
        this._decoratorType = new Enum(1);
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
      public CharBlockIndex DecoratorSet {
        get {
          return this._decoratorSet;
        }
        set {
          this._decoratorSet = value;
        }
      }
      public Enum DecoratorType {
        get {
          return this._decoratorType;
        }
        set {
          this._decoratorType = value;
        }
      }
      public CharInteger ShaderIndex {
        get {
          return this._shaderIndex;
        }
        set {
          this._shaderIndex = value;
        }
      }
      public CharInteger CompressedRadius {
        get {
          return this._compressedRadius;
        }
        set {
          this._compressedRadius = value;
        }
      }
      public ShortInteger Cluster {
        get {
          return this._cluster;
        }
        set {
          this._cluster = value;
        }
      }
      public ShortBlockIndex CacheBlock {
        get {
          return this._cacheBlock;
        }
        set {
          this._cacheBlock = value;
        }
      }
      public ShortInteger DecoratorStartIndex {
        get {
          return this._decoratorStartIndex;
        }
        set {
          this._decoratorStartIndex = value;
        }
      }
      public ShortInteger DecoratorCount {
        get {
          return this._decoratorCount;
        }
        set {
          this._decoratorCount = value;
        }
      }
      public ShortInteger VertexStartOffset {
        get {
          return this._vertexStartOffset;
        }
        set {
          this._vertexStartOffset = value;
        }
      }
      public ShortInteger VertexCount {
        get {
          return this._vertexCount;
        }
        set {
          this._vertexCount = value;
        }
      }
      public ShortInteger IndexStartOffset {
        get {
          return this._indexStartOffset;
        }
        set {
          this._indexStartOffset = value;
        }
      }
      public ShortInteger IndexCount {
        get {
          return this._indexCount;
        }
        set {
          this._indexCount = value;
        }
      }
      public LongInteger CompressedBoundingCenter {
        get {
          return this._compressedBoundingCenter;
        }
        set {
          this._compressedBoundingCenter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decoratorSet.Read(reader);
        _decoratorType.Read(reader);
        _shaderIndex.Read(reader);
        _compressedRadius.Read(reader);
        _cluster.Read(reader);
        _cacheBlock.Read(reader);
        _decoratorStartIndex.Read(reader);
        _decoratorCount.Read(reader);
        _vertexStartOffset.Read(reader);
        _vertexCount.Read(reader);
        _indexStartOffset.Read(reader);
        _indexCount.Read(reader);
        _compressedBoundingCenter.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decoratorSet.Write(bw);
        _decoratorType.Write(bw);
        _shaderIndex.Write(bw);
        _compressedRadius.Write(bw);
        _cluster.Write(bw);
        _cacheBlock.Write(bw);
        _decoratorStartIndex.Write(bw);
        _decoratorCount.Write(bw);
        _vertexStartOffset.Write(bw);
        _vertexCount.Write(bw);
        _indexStartOffset.Write(bw);
        _indexCount.Write(bw);
        _compressedBoundingCenter.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorCellCollectionBlockBlock : IBlock {
      private ShortInteger _childIndex = new ShortInteger();
      private ShortInteger _childIndex2 = new ShortInteger();
      private ShortInteger _childIndex3 = new ShortInteger();
      private ShortInteger _childIndex4 = new ShortInteger();
      private ShortInteger _childIndex5 = new ShortInteger();
      private ShortInteger _childIndex6 = new ShortInteger();
      private ShortInteger _childIndex7 = new ShortInteger();
      private ShortInteger _childIndex8 = new ShortInteger();
      private ShortBlockIndex _cacheBlockIndex = new ShortBlockIndex();
      private ShortInteger _groupCount = new ShortInteger();
      private LongInteger _groupStartIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorCellCollectionBlockBlock() {
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
      public ShortInteger ChildIndex {
        get {
          return this._childIndex;
        }
        set {
          this._childIndex = value;
        }
      }
      public ShortInteger ChildIndex2 {
        get {
          return this._childIndex2;
        }
        set {
          this._childIndex2 = value;
        }
      }
      public ShortInteger ChildIndex3 {
        get {
          return this._childIndex3;
        }
        set {
          this._childIndex3 = value;
        }
      }
      public ShortInteger ChildIndex4 {
        get {
          return this._childIndex4;
        }
        set {
          this._childIndex4 = value;
        }
      }
      public ShortInteger ChildIndex5 {
        get {
          return this._childIndex5;
        }
        set {
          this._childIndex5 = value;
        }
      }
      public ShortInteger ChildIndex6 {
        get {
          return this._childIndex6;
        }
        set {
          this._childIndex6 = value;
        }
      }
      public ShortInteger ChildIndex7 {
        get {
          return this._childIndex7;
        }
        set {
          this._childIndex7 = value;
        }
      }
      public ShortInteger ChildIndex8 {
        get {
          return this._childIndex8;
        }
        set {
          this._childIndex8 = value;
        }
      }
      public ShortBlockIndex CacheBlockIndex {
        get {
          return this._cacheBlockIndex;
        }
        set {
          this._cacheBlockIndex = value;
        }
      }
      public ShortInteger GroupCount {
        get {
          return this._groupCount;
        }
        set {
          this._groupCount = value;
        }
      }
      public LongInteger GroupStartIndex {
        get {
          return this._groupStartIndex;
        }
        set {
          this._groupStartIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _childIndex.Read(reader);
        _childIndex2.Read(reader);
        _childIndex3.Read(reader);
        _childIndex4.Read(reader);
        _childIndex5.Read(reader);
        _childIndex6.Read(reader);
        _childIndex7.Read(reader);
        _childIndex8.Read(reader);
        _cacheBlockIndex.Read(reader);
        _groupCount.Read(reader);
        _groupStartIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _childIndex.Write(bw);
        _childIndex2.Write(bw);
        _childIndex3.Write(bw);
        _childIndex4.Write(bw);
        _childIndex5.Write(bw);
        _childIndex6.Write(bw);
        _childIndex7.Write(bw);
        _childIndex8.Write(bw);
        _cacheBlockIndex.Write(bw);
        _groupCount.Write(bw);
        _groupStartIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorProjectedDecalBlockBlock : IBlock {
      private CharBlockIndex _decoratorSet = new CharBlockIndex();
      private CharInteger _decoratorClass = new CharInteger();
      private CharInteger _decoratorPermutation = new CharInteger();
      private CharInteger _spriteIndex = new CharInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _left = new RealVector3D();
      private RealVector3D _up = new RealVector3D();
      private RealVector3D _extents = new RealVector3D();
      private RealPoint3D _previousPosition = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public DecoratorProjectedDecalBlockBlock() {
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
      public CharBlockIndex DecoratorSet {
        get {
          return this._decoratorSet;
        }
        set {
          this._decoratorSet = value;
        }
      }
      public CharInteger DecoratorClass {
        get {
          return this._decoratorClass;
        }
        set {
          this._decoratorClass = value;
        }
      }
      public CharInteger DecoratorPermutation {
        get {
          return this._decoratorPermutation;
        }
        set {
          this._decoratorPermutation = value;
        }
      }
      public CharInteger SpriteIndex {
        get {
          return this._spriteIndex;
        }
        set {
          this._spriteIndex = value;
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
      public RealVector3D Left {
        get {
          return this._left;
        }
        set {
          this._left = value;
        }
      }
      public RealVector3D Up {
        get {
          return this._up;
        }
        set {
          this._up = value;
        }
      }
      public RealVector3D Extents {
        get {
          return this._extents;
        }
        set {
          this._extents = value;
        }
      }
      public RealPoint3D PreviousPosition {
        get {
          return this._previousPosition;
        }
        set {
          this._previousPosition = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decoratorSet.Read(reader);
        _decoratorClass.Read(reader);
        _decoratorPermutation.Read(reader);
        _spriteIndex.Read(reader);
        _position.Read(reader);
        _left.Read(reader);
        _up.Read(reader);
        _extents.Read(reader);
        _previousPosition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decoratorSet.Write(bw);
        _decoratorClass.Write(bw);
        _decoratorPermutation.Write(bw);
        _spriteIndex.Write(bw);
        _position.Write(bw);
        _left.Write(bw);
        _up.Write(bw);
        _extents.Write(bw);
        _previousPosition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
