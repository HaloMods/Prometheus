// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'scenario_structure_bsp'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class scenario_structure_bsp : Interfaces.Pool.Tag {
    private ScenarioStructureBspBlock scenarioStructureBspValues = new ScenarioStructureBspBlock();
    public virtual ScenarioStructureBspBlock ScenarioStructureBspValues {
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
    public class ScenarioStructureBspBlock : IBlock {
      private TagReference _lightmaps = new TagReference();
      private Real _vehicleFloor = new Real();
      private Real _vehicleCeiling = new Real();
      private Pad _unnamed;
      private RealRGBColor _defaultAmbientColor = new RealRGBColor();
      private Pad _unnamed2;
      private RealRGBColor _defaultDistantLight0Color = new RealRGBColor();
      private RealVector3D _defaultDistantLight0Direction = new RealVector3D();
      private RealRGBColor _defaultDistantLight1Color = new RealRGBColor();
      private RealVector3D _defaultDistantLight1Direction = new RealVector3D();
      private Pad _unnamed3;
      private RealARGBColor _defaultReflectionTint = new RealARGBColor();
      private RealVector3D _defaultShadowVector = new RealVector3D();
      private RealRGBColor _defaultShadowColor = new RealRGBColor();
      private Pad _unnamed4;
      private Block _collisionMaterials = new Block();
      private Block _collisionBsp = new Block();
      private Block _nodes = new Block();
      private RealBounds _worldBoundsX = new RealBounds();
      private RealBounds _worldBoundsY = new RealBounds();
      private RealBounds _worldBoundsZ = new RealBounds();
      private Block _leaves = new Block();
      private Block _leafSurfaces = new Block();
      private Block _surfaces = new Block();
      private Block _lightmaps2 = new Block();
      private Pad _unnamed5;
      private Block _lensFlares = new Block();
      private Block _lensFlareMarkers = new Block();
      private Block _clusters = new Block();
      private Data _clusterData = new Data();
      private Block _clusterPortals = new Block();
      private Pad _unnamed6;
      private Block _breakableSurfaces = new Block();
      private Block _fogPlanes = new Block();
      private Block _fogRegions = new Block();
      private Block _fogPalette = new Block();
      private Pad _unnamed7;
      private Block _weatherPalette = new Block();
      private Block _weatherPolyhedra = new Block();
      private Pad _unnamed8;
      private Block _pathfindingSurfaces = new Block();
      private Block _pathfindingEdges = new Block();
      private Block _backgroundSoundPalette = new Block();
      private Block _soundEnvironmentPalette = new Block();
      private Data _soundPASData = new Data();
      private Pad _unnamed9;
      private Block _markers = new Block();
      private Block _detailObjects = new Block();
      private Block _runtimeDecals = new Block();
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Block _leafMapLeaves = new Block();
      private Block _leafMapPortals = new Block();
      public BlockCollection<StructureCollisionMaterialsBlock> _collisionMaterialsList = new BlockCollection<StructureCollisionMaterialsBlock>();
      public BlockCollection<BspBlock> _collisionBspList = new BlockCollection<BspBlock>();
      public BlockCollection<StructureBspNodeBlock> _nodesList = new BlockCollection<StructureBspNodeBlock>();
      public BlockCollection<StructureBspLeafBlock> _leavesList = new BlockCollection<StructureBspLeafBlock>();
      public BlockCollection<StructureBspSurfaceReferenceBlock> _leafSurfacesList = new BlockCollection<StructureBspSurfaceReferenceBlock>();
      public BlockCollection<StructureBspSurfaceBlock> _surfacesList = new BlockCollection<StructureBspSurfaceBlock>();
      public BlockCollection<StructureBspLightmapBlock> _lightmaps2List = new BlockCollection<StructureBspLightmapBlock>();
      public BlockCollection<StructureBspLensFlareBlock> _lensFlaresList = new BlockCollection<StructureBspLensFlareBlock>();
      public BlockCollection<StructureBspLensFlareMarkerBlock> _lensFlareMarkersList = new BlockCollection<StructureBspLensFlareMarkerBlock>();
      public BlockCollection<StructureBspClusterBlock> _clustersList = new BlockCollection<StructureBspClusterBlock>();
      public BlockCollection<StructureBspClusterPortalBlock> _clusterPortalsList = new BlockCollection<StructureBspClusterPortalBlock>();
      public BlockCollection<StructureBspBreakableSurfaceBlock> _breakableSurfacesList = new BlockCollection<StructureBspBreakableSurfaceBlock>();
      public BlockCollection<StructureBspFogPlaneBlock> _fogPlanesList = new BlockCollection<StructureBspFogPlaneBlock>();
      public BlockCollection<StructureBspFogRegionBlock> _fogRegionsList = new BlockCollection<StructureBspFogRegionBlock>();
      public BlockCollection<StructureBspFogPaletteBlock> _fogPaletteList = new BlockCollection<StructureBspFogPaletteBlock>();
      public BlockCollection<StructureBspWeatherPaletteBlock> _weatherPaletteList = new BlockCollection<StructureBspWeatherPaletteBlock>();
      public BlockCollection<StructureBspWeatherPolyhedronBlock> _weatherPolyhedraList = new BlockCollection<StructureBspWeatherPolyhedronBlock>();
      public BlockCollection<StructureBspPathfindingSurfacesBlock> _pathfindingSurfacesList = new BlockCollection<StructureBspPathfindingSurfacesBlock>();
      public BlockCollection<StructureBspPathfindingEdgesBlock> _pathfindingEdgesList = new BlockCollection<StructureBspPathfindingEdgesBlock>();
      public BlockCollection<StructureBspBackgroundSoundPaletteBlock> _backgroundSoundPaletteList = new BlockCollection<StructureBspBackgroundSoundPaletteBlock>();
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlock> _soundEnvironmentPaletteList = new BlockCollection<StructureBspSoundEnvironmentPaletteBlock>();
      public BlockCollection<StructureBspMarkerBlock> _markersList = new BlockCollection<StructureBspMarkerBlock>();
      public BlockCollection<StructureBspDetailObjectDataBlock> _detailObjectsList = new BlockCollection<StructureBspDetailObjectDataBlock>();
      public BlockCollection<StructureBspRuntimeDecalBlock> _runtimeDecalsList = new BlockCollection<StructureBspRuntimeDecalBlock>();
      public BlockCollection<GlobalMapLeafBlock> _leafMapLeavesList = new BlockCollection<GlobalMapLeafBlock>();
      public BlockCollection<GlobalLeafPortalBlock> _leafMapPortalsList = new BlockCollection<GlobalLeafPortalBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioStructureBspBlock() {
        this._unnamed = new Pad(20);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(12);
        this._unnamed6 = new Pad(12);
        this._unnamed7 = new Pad(24);
        this._unnamed8 = new Pad(24);
        this._unnamed9 = new Pad(24);
        this._unnamed10 = new Pad(8);
        this._unnamed11 = new Pad(4);
      }
      public BlockCollection<StructureCollisionMaterialsBlock> CollisionMaterials {
        get {
          return this._collisionMaterialsList;
        }
      }
      public BlockCollection<BspBlock> CollisionBsp {
        get {
          return this._collisionBspList;
        }
      }
      public BlockCollection<StructureBspNodeBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<StructureBspLeafBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<StructureBspSurfaceReferenceBlock> LeafSurfaces {
        get {
          return this._leafSurfacesList;
        }
      }
      public BlockCollection<StructureBspSurfaceBlock> Surfaces {
        get {
          return this._surfacesList;
        }
      }
      public BlockCollection<StructureBspLightmapBlock> Lightmaps2 {
        get {
          return this._lightmaps2List;
        }
      }
      public BlockCollection<StructureBspLensFlareBlock> LensFlares {
        get {
          return this._lensFlaresList;
        }
      }
      public BlockCollection<StructureBspLensFlareMarkerBlock> LensFlareMarkers {
        get {
          return this._lensFlareMarkersList;
        }
      }
      public BlockCollection<StructureBspClusterBlock> Clusters {
        get {
          return this._clustersList;
        }
      }
      public BlockCollection<StructureBspClusterPortalBlock> ClusterPortals {
        get {
          return this._clusterPortalsList;
        }
      }
      public BlockCollection<StructureBspBreakableSurfaceBlock> BreakableSurfaces {
        get {
          return this._breakableSurfacesList;
        }
      }
      public BlockCollection<StructureBspFogPlaneBlock> FogPlanes {
        get {
          return this._fogPlanesList;
        }
      }
      public BlockCollection<StructureBspFogRegionBlock> FogRegions {
        get {
          return this._fogRegionsList;
        }
      }
      public BlockCollection<StructureBspFogPaletteBlock> FogPalette {
        get {
          return this._fogPaletteList;
        }
      }
      public BlockCollection<StructureBspWeatherPaletteBlock> WeatherPalette {
        get {
          return this._weatherPaletteList;
        }
      }
      public BlockCollection<StructureBspWeatherPolyhedronBlock> WeatherPolyhedra {
        get {
          return this._weatherPolyhedraList;
        }
      }
      public BlockCollection<StructureBspPathfindingSurfacesBlock> PathfindingSurfaces {
        get {
          return this._pathfindingSurfacesList;
        }
      }
      public BlockCollection<StructureBspPathfindingEdgesBlock> PathfindingEdges {
        get {
          return this._pathfindingEdgesList;
        }
      }
      public BlockCollection<StructureBspBackgroundSoundPaletteBlock> BackgroundSoundPalette {
        get {
          return this._backgroundSoundPaletteList;
        }
      }
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlock> SoundEnvironmentPalette {
        get {
          return this._soundEnvironmentPaletteList;
        }
      }
      public BlockCollection<StructureBspMarkerBlock> Markers {
        get {
          return this._markersList;
        }
      }
      public BlockCollection<StructureBspDetailObjectDataBlock> DetailObjects {
        get {
          return this._detailObjectsList;
        }
      }
      public BlockCollection<StructureBspRuntimeDecalBlock> RuntimeDecals {
        get {
          return this._runtimeDecalsList;
        }
      }
      public BlockCollection<GlobalMapLeafBlock> LeafMapLeaves {
        get {
          return this._leafMapLeavesList;
        }
      }
      public BlockCollection<GlobalLeafPortalBlock> LeafMapPortals {
        get {
          return this._leafMapPortalsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lightmaps.Value);
for (int x=0; x<CollisionMaterials.BlockCount; x++)
{
  IBlock block = CollisionMaterials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CollisionBsp.BlockCount; x++)
{
  IBlock block = CollisionBsp.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Leaves.BlockCount; x++)
{
  IBlock block = Leaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LeafSurfaces.BlockCount; x++)
{
  IBlock block = LeafSurfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Surfaces.BlockCount; x++)
{
  IBlock block = Surfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lightmaps2.BlockCount; x++)
{
  IBlock block = Lightmaps2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LensFlares.BlockCount; x++)
{
  IBlock block = LensFlares.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LensFlareMarkers.BlockCount; x++)
{
  IBlock block = LensFlareMarkers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Clusters.BlockCount; x++)
{
  IBlock block = Clusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterPortals.BlockCount; x++)
{
  IBlock block = ClusterPortals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BreakableSurfaces.BlockCount; x++)
{
  IBlock block = BreakableSurfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogPlanes.BlockCount; x++)
{
  IBlock block = FogPlanes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogRegions.BlockCount; x++)
{
  IBlock block = FogRegions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FogPalette.BlockCount; x++)
{
  IBlock block = FogPalette.GetBlock(x);
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
for (int x=0; x<PathfindingSurfaces.BlockCount; x++)
{
  IBlock block = PathfindingSurfaces.GetBlock(x);
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
for (int x=0; x<DetailObjects.BlockCount; x++)
{
  IBlock block = DetailObjects.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RuntimeDecals.BlockCount; x++)
{
  IBlock block = RuntimeDecals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LeafMapLeaves.BlockCount; x++)
{
  IBlock block = LeafMapLeaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LeafMapPortals.BlockCount; x++)
{
  IBlock block = LeafMapPortals.GetBlock(x);
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
      public TagReference Lightmaps {
        get {
          return this._lightmaps;
        }
        set {
          this._lightmaps = value;
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
      public RealRGBColor DefaultAmbientColor {
        get {
          return this._defaultAmbientColor;
        }
        set {
          this._defaultAmbientColor = value;
        }
      }
      public RealRGBColor DefaultDistantLight0Color {
        get {
          return this._defaultDistantLight0Color;
        }
        set {
          this._defaultDistantLight0Color = value;
        }
      }
      public RealVector3D DefaultDistantLight0Direction {
        get {
          return this._defaultDistantLight0Direction;
        }
        set {
          this._defaultDistantLight0Direction = value;
        }
      }
      public RealRGBColor DefaultDistantLight1Color {
        get {
          return this._defaultDistantLight1Color;
        }
        set {
          this._defaultDistantLight1Color = value;
        }
      }
      public RealVector3D DefaultDistantLight1Direction {
        get {
          return this._defaultDistantLight1Direction;
        }
        set {
          this._defaultDistantLight1Direction = value;
        }
      }
      public RealARGBColor DefaultReflectionTint {
        get {
          return this._defaultReflectionTint;
        }
        set {
          this._defaultReflectionTint = value;
        }
      }
      public RealVector3D DefaultShadowVector {
        get {
          return this._defaultShadowVector;
        }
        set {
          this._defaultShadowVector = value;
        }
      }
      public RealRGBColor DefaultShadowColor {
        get {
          return this._defaultShadowColor;
        }
        set {
          this._defaultShadowColor = value;
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
      public virtual void Read(BinaryReader reader) {
        _lightmaps.Read(reader);
        _vehicleFloor.Read(reader);
        _vehicleCeiling.Read(reader);
        _unnamed.Read(reader);
        _defaultAmbientColor.Read(reader);
        _unnamed2.Read(reader);
        _defaultDistantLight0Color.Read(reader);
        _defaultDistantLight0Direction.Read(reader);
        _defaultDistantLight1Color.Read(reader);
        _defaultDistantLight1Direction.Read(reader);
        _unnamed3.Read(reader);
        _defaultReflectionTint.Read(reader);
        _defaultShadowVector.Read(reader);
        _defaultShadowColor.Read(reader);
        _unnamed4.Read(reader);
        _collisionMaterials.Read(reader);
        _collisionBsp.Read(reader);
        _nodes.Read(reader);
        _worldBoundsX.Read(reader);
        _worldBoundsY.Read(reader);
        _worldBoundsZ.Read(reader);
        _leaves.Read(reader);
        _leafSurfaces.Read(reader);
        _surfaces.Read(reader);
        _lightmaps2.Read(reader);
        _unnamed5.Read(reader);
        _lensFlares.Read(reader);
        _lensFlareMarkers.Read(reader);
        _clusters.Read(reader);
        _clusterData.Read(reader);
        _clusterPortals.Read(reader);
        _unnamed6.Read(reader);
        _breakableSurfaces.Read(reader);
        _fogPlanes.Read(reader);
        _fogRegions.Read(reader);
        _fogPalette.Read(reader);
        _unnamed7.Read(reader);
        _weatherPalette.Read(reader);
        _weatherPolyhedra.Read(reader);
        _unnamed8.Read(reader);
        _pathfindingSurfaces.Read(reader);
        _pathfindingEdges.Read(reader);
        _backgroundSoundPalette.Read(reader);
        _soundEnvironmentPalette.Read(reader);
        _soundPASData.Read(reader);
        _unnamed9.Read(reader);
        _markers.Read(reader);
        _detailObjects.Read(reader);
        _runtimeDecals.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _leafMapLeaves.Read(reader);
        _leafMapPortals.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _lightmaps.ReadString(reader);
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials.Add(new StructureCollisionMaterialsBlock());
          CollisionMaterials[x].Read(reader);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _collisionBsp.Count); x = (x + 1)) {
          CollisionBsp.Add(new BspBlock());
          CollisionBsp[x].Read(reader);
        }
        for (x = 0; (x < _collisionBsp.Count); x = (x + 1)) {
          CollisionBsp[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new StructureBspNodeBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new StructureBspLeafBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leafSurfaces.Count); x = (x + 1)) {
          LeafSurfaces.Add(new StructureBspSurfaceReferenceBlock());
          LeafSurfaces[x].Read(reader);
        }
        for (x = 0; (x < _leafSurfaces.Count); x = (x + 1)) {
          LeafSurfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces.Add(new StructureBspSurfaceBlock());
          Surfaces[x].Read(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightmaps2.Count); x = (x + 1)) {
          Lightmaps2.Add(new StructureBspLightmapBlock());
          Lightmaps2[x].Read(reader);
        }
        for (x = 0; (x < _lightmaps2.Count); x = (x + 1)) {
          Lightmaps2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lensFlares.Count); x = (x + 1)) {
          LensFlares.Add(new StructureBspLensFlareBlock());
          LensFlares[x].Read(reader);
        }
        for (x = 0; (x < _lensFlares.Count); x = (x + 1)) {
          LensFlares[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lensFlareMarkers.Count); x = (x + 1)) {
          LensFlareMarkers.Add(new StructureBspLensFlareMarkerBlock());
          LensFlareMarkers[x].Read(reader);
        }
        for (x = 0; (x < _lensFlareMarkers.Count); x = (x + 1)) {
          LensFlareMarkers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters.Add(new StructureBspClusterBlock());
          Clusters[x].Read(reader);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].ReadChildData(reader);
        }
        _clusterData.ReadBinary(reader);
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals.Add(new StructureBspClusterPortalBlock());
          ClusterPortals[x].Read(reader);
        }
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces.Add(new StructureBspBreakableSurfaceBlock());
          BreakableSurfaces[x].Read(reader);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes.Add(new StructureBspFogPlaneBlock());
          FogPlanes[x].Read(reader);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogRegions.Count); x = (x + 1)) {
          FogRegions.Add(new StructureBspFogRegionBlock());
          FogRegions[x].Read(reader);
        }
        for (x = 0; (x < _fogRegions.Count); x = (x + 1)) {
          FogRegions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fogPalette.Count); x = (x + 1)) {
          FogPalette.Add(new StructureBspFogPaletteBlock());
          FogPalette[x].Read(reader);
        }
        for (x = 0; (x < _fogPalette.Count); x = (x + 1)) {
          FogPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette.Add(new StructureBspWeatherPaletteBlock());
          WeatherPalette[x].Read(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra.Add(new StructureBspWeatherPolyhedronBlock());
          WeatherPolyhedra[x].Read(reader);
        }
        for (x = 0; (x < _weatherPolyhedra.Count); x = (x + 1)) {
          WeatherPolyhedra[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingSurfaces.Count); x = (x + 1)) {
          PathfindingSurfaces.Add(new StructureBspPathfindingSurfacesBlock());
          PathfindingSurfaces[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingSurfaces.Count); x = (x + 1)) {
          PathfindingSurfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges.Add(new StructureBspPathfindingEdgesBlock());
          PathfindingEdges[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingEdges.Count); x = (x + 1)) {
          PathfindingEdges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette.Add(new StructureBspBackgroundSoundPaletteBlock());
          BackgroundSoundPalette[x].Read(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette.Add(new StructureBspSoundEnvironmentPaletteBlock());
          SoundEnvironmentPalette[x].Read(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].ReadChildData(reader);
        }
        _soundPASData.ReadBinary(reader);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new StructureBspMarkerBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects.Add(new StructureBspDetailObjectDataBlock());
          DetailObjects[x].Read(reader);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].ReadChildData(reader);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals.Add(new StructureBspRuntimeDecalBlock());
          RuntimeDecals[x].Read(reader);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves.Add(new GlobalMapLeafBlock());
          LeafMapLeaves[x].Read(reader);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leafMapPortals.Count); x = (x + 1)) {
          LeafMapPortals.Add(new GlobalLeafPortalBlock());
          LeafMapPortals[x].Read(reader);
        }
        for (x = 0; (x < _leafMapPortals.Count); x = (x + 1)) {
          LeafMapPortals[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _lightmaps.Write(bw);
        _vehicleFloor.Write(bw);
        _vehicleCeiling.Write(bw);
        _unnamed.Write(bw);
        _defaultAmbientColor.Write(bw);
        _unnamed2.Write(bw);
        _defaultDistantLight0Color.Write(bw);
        _defaultDistantLight0Direction.Write(bw);
        _defaultDistantLight1Color.Write(bw);
        _defaultDistantLight1Direction.Write(bw);
        _unnamed3.Write(bw);
        _defaultReflectionTint.Write(bw);
        _defaultShadowVector.Write(bw);
        _defaultShadowColor.Write(bw);
        _unnamed4.Write(bw);
_collisionMaterials.Count = CollisionMaterials.Count;
        _collisionMaterials.Write(bw);
_collisionBsp.Count = CollisionBsp.Count;
        _collisionBsp.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
        _worldBoundsX.Write(bw);
        _worldBoundsY.Write(bw);
        _worldBoundsZ.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
_leafSurfaces.Count = LeafSurfaces.Count;
        _leafSurfaces.Write(bw);
_surfaces.Count = Surfaces.Count;
        _surfaces.Write(bw);
_lightmaps2.Count = Lightmaps2.Count;
        _lightmaps2.Write(bw);
        _unnamed5.Write(bw);
_lensFlares.Count = LensFlares.Count;
        _lensFlares.Write(bw);
_lensFlareMarkers.Count = LensFlareMarkers.Count;
        _lensFlareMarkers.Write(bw);
_clusters.Count = Clusters.Count;
        _clusters.Write(bw);
        _clusterData.Write(bw);
_clusterPortals.Count = ClusterPortals.Count;
        _clusterPortals.Write(bw);
        _unnamed6.Write(bw);
_breakableSurfaces.Count = BreakableSurfaces.Count;
        _breakableSurfaces.Write(bw);
_fogPlanes.Count = FogPlanes.Count;
        _fogPlanes.Write(bw);
_fogRegions.Count = FogRegions.Count;
        _fogRegions.Write(bw);
_fogPalette.Count = FogPalette.Count;
        _fogPalette.Write(bw);
        _unnamed7.Write(bw);
_weatherPalette.Count = WeatherPalette.Count;
        _weatherPalette.Write(bw);
_weatherPolyhedra.Count = WeatherPolyhedra.Count;
        _weatherPolyhedra.Write(bw);
        _unnamed8.Write(bw);
_pathfindingSurfaces.Count = PathfindingSurfaces.Count;
        _pathfindingSurfaces.Write(bw);
_pathfindingEdges.Count = PathfindingEdges.Count;
        _pathfindingEdges.Write(bw);
_backgroundSoundPalette.Count = BackgroundSoundPalette.Count;
        _backgroundSoundPalette.Write(bw);
_soundEnvironmentPalette.Count = SoundEnvironmentPalette.Count;
        _soundEnvironmentPalette.Write(bw);
        _soundPASData.Write(bw);
        _unnamed9.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
_detailObjects.Count = DetailObjects.Count;
        _detailObjects.Write(bw);
_runtimeDecals.Count = RuntimeDecals.Count;
        _runtimeDecals.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
_leafMapLeaves.Count = LeafMapLeaves.Count;
        _leafMapLeaves.Write(bw);
_leafMapPortals.Count = LeafMapPortals.Count;
        _leafMapPortals.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _lightmaps.WriteString(writer);
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].Write(writer);
        }
        for (x = 0; (x < _collisionMaterials.Count); x = (x + 1)) {
          CollisionMaterials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _collisionBsp.Count); x = (x + 1)) {
          CollisionBsp[x].Write(writer);
        }
        for (x = 0; (x < _collisionBsp.Count); x = (x + 1)) {
          CollisionBsp[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].Write(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leafSurfaces.Count); x = (x + 1)) {
          LeafSurfaces[x].Write(writer);
        }
        for (x = 0; (x < _leafSurfaces.Count); x = (x + 1)) {
          LeafSurfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].Write(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightmaps2.Count); x = (x + 1)) {
          Lightmaps2[x].Write(writer);
        }
        for (x = 0; (x < _lightmaps2.Count); x = (x + 1)) {
          Lightmaps2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lensFlares.Count); x = (x + 1)) {
          LensFlares[x].Write(writer);
        }
        for (x = 0; (x < _lensFlares.Count); x = (x + 1)) {
          LensFlares[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lensFlareMarkers.Count); x = (x + 1)) {
          LensFlareMarkers[x].Write(writer);
        }
        for (x = 0; (x < _lensFlareMarkers.Count); x = (x + 1)) {
          LensFlareMarkers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].Write(writer);
        }
        for (x = 0; (x < _clusters.Count); x = (x + 1)) {
          Clusters[x].WriteChildData(writer);
        }
        _clusterData.WriteBinary(writer);
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].Write(writer);
        }
        for (x = 0; (x < _clusterPortals.Count); x = (x + 1)) {
          ClusterPortals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].Write(writer);
        }
        for (x = 0; (x < _breakableSurfaces.Count); x = (x + 1)) {
          BreakableSurfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].Write(writer);
        }
        for (x = 0; (x < _fogPlanes.Count); x = (x + 1)) {
          FogPlanes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogRegions.Count); x = (x + 1)) {
          FogRegions[x].Write(writer);
        }
        for (x = 0; (x < _fogRegions.Count); x = (x + 1)) {
          FogRegions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fogPalette.Count); x = (x + 1)) {
          FogPalette[x].Write(writer);
        }
        for (x = 0; (x < _fogPalette.Count); x = (x + 1)) {
          FogPalette[x].WriteChildData(writer);
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
        for (x = 0; (x < _pathfindingSurfaces.Count); x = (x + 1)) {
          PathfindingSurfaces[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingSurfaces.Count); x = (x + 1)) {
          PathfindingSurfaces[x].WriteChildData(writer);
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
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].Write(writer);
        }
        for (x = 0; (x < _detailObjects.Count); x = (x + 1)) {
          DetailObjects[x].WriteChildData(writer);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].Write(writer);
        }
        for (x = 0; (x < _runtimeDecals.Count); x = (x + 1)) {
          RuntimeDecals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].Write(writer);
        }
        for (x = 0; (x < _leafMapLeaves.Count); x = (x + 1)) {
          LeafMapLeaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leafMapPortals.Count); x = (x + 1)) {
          LeafMapPortals[x].Write(writer);
        }
        for (x = 0; (x < _leafMapPortals.Count); x = (x + 1)) {
          LeafMapPortals[x].WriteChildData(writer);
        }
      }
    }
    public class StructureCollisionMaterialsBlock : IBlock {
      private TagReference _shader = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public StructureCollisionMaterialsBlock() {
        this._unnamed = new Pad(4);
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shader.WriteString(writer);
      }
    }
    public class BspBlock : IBlock {
      private Block _bsp3dNodes = new Block();
      private Block _planes = new Block();
      private Block _leaves = new Block();
      private Block _bsp2dReferences = new Block();
      private Block _bsp2dNodes = new Block();
      private Block _surfaces = new Block();
      private Block _edges = new Block();
      private Block _vertices = new Block();
      public BlockCollection<Bsp3dnodeBlock> _bsp3dNodesList = new BlockCollection<Bsp3dnodeBlock>();
      public BlockCollection<PlaneBlock> _planesList = new BlockCollection<PlaneBlock>();
      public BlockCollection<LeafBlock> _leavesList = new BlockCollection<LeafBlock>();
      public BlockCollection<Bsp2dreferenceBlock> _bsp2dReferencesList = new BlockCollection<Bsp2dreferenceBlock>();
      public BlockCollection<Bsp2dnodeBlock> _bsp2dNodesList = new BlockCollection<Bsp2dnodeBlock>();
      public BlockCollection<SurfaceBlock> _surfacesList = new BlockCollection<SurfaceBlock>();
      public BlockCollection<EdgeBlock> _edgesList = new BlockCollection<EdgeBlock>();
      public BlockCollection<VertexBlock> _verticesList = new BlockCollection<VertexBlock>();
public event System.EventHandler BlockNameChanged;
      public BspBlock() {
      }
      public BlockCollection<Bsp3dnodeBlock> Bsp3dNodes {
        get {
          return this._bsp3dNodesList;
        }
      }
      public BlockCollection<PlaneBlock> Planes {
        get {
          return this._planesList;
        }
      }
      public BlockCollection<LeafBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<Bsp2dreferenceBlock> Bsp2dReferences {
        get {
          return this._bsp2dReferencesList;
        }
      }
      public BlockCollection<Bsp2dnodeBlock> Bsp2dNodes {
        get {
          return this._bsp2dNodesList;
        }
      }
      public BlockCollection<SurfaceBlock> Surfaces {
        get {
          return this._surfacesList;
        }
      }
      public BlockCollection<EdgeBlock> Edges {
        get {
          return this._edgesList;
        }
      }
      public BlockCollection<VertexBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bsp3dNodes.BlockCount; x++)
{
  IBlock block = Bsp3dNodes.GetBlock(x);
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
for (int x=0; x<Bsp2dReferences.BlockCount; x++)
{
  IBlock block = Bsp2dReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bsp2dNodes.BlockCount; x++)
{
  IBlock block = Bsp2dNodes.GetBlock(x);
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
        _bsp3dNodes.Read(reader);
        _planes.Read(reader);
        _leaves.Read(reader);
        _bsp2dReferences.Read(reader);
        _bsp2dNodes.Read(reader);
        _surfaces.Read(reader);
        _edges.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes.Add(new Bsp3dnodeBlock());
          Bsp3dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new PlaneBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new LeafBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences.Add(new Bsp2dreferenceBlock());
          Bsp2dReferences[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes.Add(new Bsp2dnodeBlock());
          Bsp2dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces.Add(new SurfaceBlock());
          Surfaces[x].Read(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges.Add(new EdgeBlock());
          Edges[x].Read(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new VertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_bsp3dNodes.Count = Bsp3dNodes.Count;
        _bsp3dNodes.Write(bw);
_planes.Count = Planes.Count;
        _planes.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
_bsp2dReferences.Count = Bsp2dReferences.Count;
        _bsp2dReferences.Write(bw);
_bsp2dNodes.Count = Bsp2dNodes.Count;
        _bsp2dNodes.Write(bw);
_surfaces.Count = Surfaces.Count;
        _surfaces.Write(bw);
_edges.Count = Edges.Count;
        _edges.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].WriteChildData(writer);
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
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].WriteChildData(writer);
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
    public class Bsp3dnodeBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _backChild = new LongInteger();
      private LongInteger _frontChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp3dnodeBlock() {
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger BackChild {
        get {
          return this._backChild;
        }
        set {
          this._backChild = value;
        }
      }
      public LongInteger FrontChild {
        get {
          return this._frontChild;
        }
        set {
          this._frontChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _backChild.Read(reader);
        _frontChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _backChild.Write(bw);
        _frontChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlaneBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public PlaneBlock() {
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
    public class LeafBlock : IBlock {
      private Flags _flags;
      private ShortInteger _bsp2dReferenceCount = new ShortInteger();
      private LongInteger _firstBsp2dReference = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public LeafBlock() {
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
      public ShortInteger Bsp2dReferenceCount {
        get {
          return this._bsp2dReferenceCount;
        }
        set {
          this._bsp2dReferenceCount = value;
        }
      }
      public LongInteger FirstBsp2dReference {
        get {
          return this._firstBsp2dReference;
        }
        set {
          this._firstBsp2dReference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bsp2dReferenceCount.Read(reader);
        _firstBsp2dReference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bsp2dReferenceCount.Write(bw);
        _firstBsp2dReference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dreferenceBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _bsp2dNode = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dreferenceBlock() {
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger Bsp2dNode {
        get {
          return this._bsp2dNode;
        }
        set {
          this._bsp2dNode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _bsp2dNode.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _bsp2dNode.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dnodeBlock : IBlock {
      private RealPlane2D _plane = new RealPlane2D();
      private LongInteger _leftChild = new LongInteger();
      private LongInteger _rightChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dnodeBlock() {
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
    public class SurfaceBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _firstEdge = new LongInteger();
      private Flags _flags;
      private CharInteger _breakableSurface = new CharInteger();
      private ShortInteger _material = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SurfaceBlock() {
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger FirstEdge {
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
    public class EdgeBlock : IBlock {
      private LongInteger _startVertex = new LongInteger();
      private LongInteger _endVertex = new LongInteger();
      private LongInteger _forwardEdge = new LongInteger();
      private LongInteger _reverseEdge = new LongInteger();
      private LongInteger _leftSurface = new LongInteger();
      private LongInteger _rightSurface = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public EdgeBlock() {
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
      public LongInteger StartVertex {
        get {
          return this._startVertex;
        }
        set {
          this._startVertex = value;
        }
      }
      public LongInteger EndVertex {
        get {
          return this._endVertex;
        }
        set {
          this._endVertex = value;
        }
      }
      public LongInteger ForwardEdge {
        get {
          return this._forwardEdge;
        }
        set {
          this._forwardEdge = value;
        }
      }
      public LongInteger ReverseEdge {
        get {
          return this._reverseEdge;
        }
        set {
          this._reverseEdge = value;
        }
      }
      public LongInteger LeftSurface {
        get {
          return this._leftSurface;
        }
        set {
          this._leftSurface = value;
        }
      }
      public LongInteger RightSurface {
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
    public class VertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private LongInteger _firstEdge = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public VertexBlock() {
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
      public LongInteger FirstEdge {
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _firstEdge.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspNodeBlock : IBlock {
      private Skip _unnamed;
public event System.EventHandler BlockNameChanged;
      public StructureBspNodeBlock() {
        this._unnamed = new Skip(6);
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspLeafBlock : IBlock {
      private Skip _unnamed;
      private Pad _unnamed2;
      private ShortInteger _cluster = new ShortInteger();
      private ShortInteger _surfaceReferenceCount = new ShortInteger();
      private LongBlockIndex _surfaceReferences = new LongBlockIndex();
public event System.EventHandler BlockNameChanged;
      public StructureBspLeafBlock() {
        this._unnamed = new Skip(6);
        this._unnamed2 = new Pad(2);
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
      public LongBlockIndex SurfaceReferences {
        get {
          return this._surfaceReferences;
        }
        set {
          this._surfaceReferences = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _cluster.Read(reader);
        _surfaceReferenceCount.Read(reader);
        _surfaceReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _cluster.Write(bw);
        _surfaceReferenceCount.Write(bw);
        _surfaceReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspSurfaceReferenceBlock : IBlock {
      private LongBlockIndex _surface = new LongBlockIndex();
      private LongBlockIndex _node = new LongBlockIndex();
public event System.EventHandler BlockNameChanged;
      public StructureBspSurfaceReferenceBlock() {
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
      public LongBlockIndex Surface {
        get {
          return this._surface;
        }
        set {
          this._surface = value;
        }
      }
      public LongBlockIndex Node {
        get {
          return this._node;
        }
        set {
          this._node = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _surface.Read(reader);
        _node.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _surface.Write(bw);
        _node.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspSurfaceBlock : IBlock {
      private ShortBlockIndex _tria = new ShortBlockIndex();
      private ShortBlockIndex _trib = new ShortBlockIndex();
      private ShortBlockIndex _tric = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public StructureBspSurfaceBlock() {
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
      public ShortBlockIndex Tria {
        get {
          return this._tria;
        }
        set {
          this._tria = value;
        }
      }
      public ShortBlockIndex Trib {
        get {
          return this._trib;
        }
        set {
          this._trib = value;
        }
      }
      public ShortBlockIndex Tric {
        get {
          return this._tric;
        }
        set {
          this._tric = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _tria.Read(reader);
        _trib.Read(reader);
        _tric.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _tria.Write(bw);
        _trib.Write(bw);
        _tric.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspLightmapBlock : IBlock {
      private ShortInteger _bitmap = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Block _materials = new Block();
      public BlockCollection<StructureBspMaterialBlock> _materialsList = new BlockCollection<StructureBspMaterialBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspLightmapBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
      }
      public BlockCollection<StructureBspMaterialBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
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
      public ShortInteger Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmap.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _materials.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new StructureBspMaterialBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmap.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspMaterialBlock : IBlock {
      private TagReference _shader = new TagReference();
      private ShortInteger _shaderPermutation = new ShortInteger();
      private Flags _flags;
      private LongBlockIndex _surfaces = new LongBlockIndex();
      private LongInteger _surfaceCount = new LongInteger();
      private RealPoint3D _centroid = new RealPoint3D();
      private RealRGBColor _ambientColor = new RealRGBColor();
      private ShortInteger _distantLightCount = new ShortInteger();
      private Pad _unnamed;
      private RealRGBColor _distantLight0Color = new RealRGBColor();
      private RealVector3D _distantLight0Direction = new RealVector3D();
      private RealRGBColor _distantLight1Color = new RealRGBColor();
      private RealVector3D _distantLight1Direction = new RealVector3D();
      private Pad _unnamed2;
      private RealARGBColor _reflectionTint = new RealARGBColor();
      private RealVector3D _shadowVector = new RealVector3D();
      private RealRGBColor _shadowColor = new RealRGBColor();
      private RealPlane3D _plane = new RealPlane3D();
      private ShortInteger _breakableSurface = new ShortInteger();
      private Pad _unnamed3;
      private LongInteger _vertexConstant = new LongInteger();
      private LongInteger _vertexCount = new LongInteger();
      private Pad _unnamed4;
      private LongInteger _vertexOffset = new LongInteger();
      private LongInteger _lightmapConstant = new LongInteger();
      private LongInteger _lightmapCount = new LongInteger();
      private Pad _unnamed5;
      private LongInteger _lightmapOffset = new LongInteger();
      private Data _uncompressedVertices = new Data();
      private Data _compressedVertices = new Data();
public event System.EventHandler BlockNameChanged;
      public StructureBspMaterialBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(8);
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
      public ShortInteger ShaderPermutation {
        get {
          return this._shaderPermutation;
        }
        set {
          this._shaderPermutation = value;
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
      public LongBlockIndex Surfaces {
        get {
          return this._surfaces;
        }
        set {
          this._surfaces = value;
        }
      }
      public LongInteger SurfaceCount {
        get {
          return this._surfaceCount;
        }
        set {
          this._surfaceCount = value;
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
      public RealRGBColor AmbientColor {
        get {
          return this._ambientColor;
        }
        set {
          this._ambientColor = value;
        }
      }
      public ShortInteger DistantLightCount {
        get {
          return this._distantLightCount;
        }
        set {
          this._distantLightCount = value;
        }
      }
      public RealRGBColor DistantLight0Color {
        get {
          return this._distantLight0Color;
        }
        set {
          this._distantLight0Color = value;
        }
      }
      public RealVector3D DistantLight0Direction {
        get {
          return this._distantLight0Direction;
        }
        set {
          this._distantLight0Direction = value;
        }
      }
      public RealRGBColor DistantLight1Color {
        get {
          return this._distantLight1Color;
        }
        set {
          this._distantLight1Color = value;
        }
      }
      public RealVector3D DistantLight1Direction {
        get {
          return this._distantLight1Direction;
        }
        set {
          this._distantLight1Direction = value;
        }
      }
      public RealARGBColor ReflectionTint {
        get {
          return this._reflectionTint;
        }
        set {
          this._reflectionTint = value;
        }
      }
      public RealVector3D ShadowVector {
        get {
          return this._shadowVector;
        }
        set {
          this._shadowVector = value;
        }
      }
      public RealRGBColor ShadowColor {
        get {
          return this._shadowColor;
        }
        set {
          this._shadowColor = value;
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
      public ShortInteger BreakableSurface {
        get {
          return this._breakableSurface;
        }
        set {
          this._breakableSurface = value;
        }
      }
      public LongInteger VertexConstant {
        get {
          return this._vertexConstant;
        }
        set {
          this._vertexConstant = value;
        }
      }
      public LongInteger VertexCount {
        get {
          return this._vertexCount;
        }
        set {
          this._vertexCount = value;
        }
      }
      public LongInteger VertexOffset {
        get {
          return this._vertexOffset;
        }
        set {
          this._vertexOffset = value;
        }
      }
      public LongInteger LightmapConstant {
        get {
          return this._lightmapConstant;
        }
        set {
          this._lightmapConstant = value;
        }
      }
      public LongInteger LightmapCount {
        get {
          return this._lightmapCount;
        }
        set {
          this._lightmapCount = value;
        }
      }
      public LongInteger LightmapOffset {
        get {
          return this._lightmapOffset;
        }
        set {
          this._lightmapOffset = value;
        }
      }
      public Data UncompressedVertices {
        get {
          return this._uncompressedVertices;
        }
        set {
          this._uncompressedVertices = value;
        }
      }
      public Data CompressedVertices {
        get {
          return this._compressedVertices;
        }
        set {
          this._compressedVertices = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shader.Read(reader);
        _shaderPermutation.Read(reader);
        _flags.Read(reader);
        _surfaces.Read(reader);
        _surfaceCount.Read(reader);
        _centroid.Read(reader);
        _ambientColor.Read(reader);
        _distantLightCount.Read(reader);
        _unnamed.Read(reader);
        _distantLight0Color.Read(reader);
        _distantLight0Direction.Read(reader);
        _distantLight1Color.Read(reader);
        _distantLight1Direction.Read(reader);
        _unnamed2.Read(reader);
        _reflectionTint.Read(reader);
        _shadowVector.Read(reader);
        _shadowColor.Read(reader);
        _plane.Read(reader);
        _breakableSurface.Read(reader);
        _unnamed3.Read(reader);
        _vertexConstant.Read(reader);
        _vertexCount.Read(reader);
        _unnamed4.Read(reader);
        _vertexOffset.Read(reader);
        _lightmapConstant.Read(reader);
        _lightmapCount.Read(reader);
        _unnamed5.Read(reader);
        _lightmapOffset.Read(reader);
        _uncompressedVertices.Read(reader);
        _compressedVertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shader.ReadString(reader);
        _uncompressedVertices.ReadBinary(reader);
        _compressedVertices.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
        _shaderPermutation.Write(bw);
        _flags.Write(bw);
        _surfaces.Write(bw);
        _surfaceCount.Write(bw);
        _centroid.Write(bw);
        _ambientColor.Write(bw);
        _distantLightCount.Write(bw);
        _unnamed.Write(bw);
        _distantLight0Color.Write(bw);
        _distantLight0Direction.Write(bw);
        _distantLight1Color.Write(bw);
        _distantLight1Direction.Write(bw);
        _unnamed2.Write(bw);
        _reflectionTint.Write(bw);
        _shadowVector.Write(bw);
        _shadowColor.Write(bw);
        _plane.Write(bw);
        _breakableSurface.Write(bw);
        _unnamed3.Write(bw);
        _vertexConstant.Write(bw);
        _vertexCount.Write(bw);
        _unnamed4.Write(bw);
        _vertexOffset.Write(bw);
        _lightmapConstant.Write(bw);
        _lightmapCount.Write(bw);
        _unnamed5.Write(bw);
        _lightmapOffset.Write(bw);
        _uncompressedVertices.Write(bw);
        _compressedVertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shader.WriteString(writer);
        _uncompressedVertices.WriteBinary(writer);
        _compressedVertices.WriteBinary(writer);
      }
    }
    public class StructureBspLensFlareBlock : IBlock {
      private TagReference _lensFlare = new TagReference();
public event System.EventHandler BlockNameChanged;
      public StructureBspLensFlareBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _lensFlare.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _lensFlare.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _lensFlare.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _lensFlare.WriteString(writer);
      }
    }
    public class StructureBspLensFlareMarkerBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _direction = new CharInteger();
      private CharInteger _direction2 = new CharInteger();
      private CharInteger _direction3 = new CharInteger();
      private CharInteger _lensFlareIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspLensFlareMarkerBlock() {
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
      public CharInteger Direction {
        get {
          return this._direction;
        }
        set {
          this._direction = value;
        }
      }
      public CharInteger Direction2 {
        get {
          return this._direction2;
        }
        set {
          this._direction2 = value;
        }
      }
      public CharInteger Direction3 {
        get {
          return this._direction3;
        }
        set {
          this._direction3 = value;
        }
      }
      public CharInteger LensFlareIndex {
        get {
          return this._lensFlareIndex;
        }
        set {
          this._lensFlareIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _direction.Read(reader);
        _direction2.Read(reader);
        _direction3.Read(reader);
        _lensFlareIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _direction.Write(bw);
        _direction2.Write(bw);
        _direction3.Write(bw);
        _lensFlareIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspClusterBlock : IBlock {
      private ShortInteger _sky = new ShortInteger();
      private ShortInteger _fog = new ShortInteger();
      private ShortBlockIndex _backgroundSound = new ShortBlockIndex();
      private ShortBlockIndex _soundEnvironment = new ShortBlockIndex();
      private ShortBlockIndex _weather = new ShortBlockIndex();
      private ShortInteger _transitionStructureBsp = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Block _predictedResources = new Block();
      private Block _subclusters = new Block();
      private ShortInteger _firstLensFlareMarkerIndex = new ShortInteger();
      private ShortInteger _lensFlareMarkerCount = new ShortInteger();
      private Block _surfaceIndices = new Block();
      private Block _mirrors = new Block();
      private Block _portals = new Block();
      public BlockCollection<PredictedResourceBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlock>();
      public BlockCollection<StructureBspSubclusterBlock> _subclustersList = new BlockCollection<StructureBspSubclusterBlock>();
      public BlockCollection<StructureBspClusterSurfaceIndexBlock> _surfaceIndicesList = new BlockCollection<StructureBspClusterSurfaceIndexBlock>();
      public BlockCollection<StructureBspMirrorBlock> _mirrorsList = new BlockCollection<StructureBspMirrorBlock>();
      public BlockCollection<StructureBspClusterPortalIndexBlock> _portalsList = new BlockCollection<StructureBspClusterPortalIndexBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterBlock() {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(24);
      }
      public BlockCollection<PredictedResourceBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<StructureBspSubclusterBlock> Subclusters {
        get {
          return this._subclustersList;
        }
      }
      public BlockCollection<StructureBspClusterSurfaceIndexBlock> SurfaceIndices {
        get {
          return this._surfaceIndicesList;
        }
      }
      public BlockCollection<StructureBspMirrorBlock> Mirrors {
        get {
          return this._mirrorsList;
        }
      }
      public BlockCollection<StructureBspClusterPortalIndexBlock> Portals {
        get {
          return this._portalsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Subclusters.BlockCount; x++)
{
  IBlock block = Subclusters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SurfaceIndices.BlockCount; x++)
{
  IBlock block = SurfaceIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Mirrors.BlockCount; x++)
{
  IBlock block = Mirrors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Portals.BlockCount; x++)
{
  IBlock block = Portals.GetBlock(x);
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
      public ShortInteger Sky {
        get {
          return this._sky;
        }
        set {
          this._sky = value;
        }
      }
      public ShortInteger Fog {
        get {
          return this._fog;
        }
        set {
          this._fog = value;
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
      public ShortInteger TransitionStructureBsp {
        get {
          return this._transitionStructureBsp;
        }
        set {
          this._transitionStructureBsp = value;
        }
      }
      public ShortInteger FirstLensFlareMarkerIndex {
        get {
          return this._firstLensFlareMarkerIndex;
        }
        set {
          this._firstLensFlareMarkerIndex = value;
        }
      }
      public ShortInteger LensFlareMarkerCount {
        get {
          return this._lensFlareMarkerCount;
        }
        set {
          this._lensFlareMarkerCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sky.Read(reader);
        _fog.Read(reader);
        _backgroundSound.Read(reader);
        _soundEnvironment.Read(reader);
        _weather.Read(reader);
        _transitionStructureBsp.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _predictedResources.Read(reader);
        _subclusters.Read(reader);
        _firstLensFlareMarkerIndex.Read(reader);
        _lensFlareMarkerCount.Read(reader);
        _surfaceIndices.Read(reader);
        _mirrors.Read(reader);
        _portals.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _subclusters.Count); x = (x + 1)) {
          Subclusters.Add(new StructureBspSubclusterBlock());
          Subclusters[x].Read(reader);
        }
        for (x = 0; (x < _subclusters.Count); x = (x + 1)) {
          Subclusters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices.Add(new StructureBspClusterSurfaceIndexBlock());
          SurfaceIndices[x].Read(reader);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _mirrors.Count); x = (x + 1)) {
          Mirrors.Add(new StructureBspMirrorBlock());
          Mirrors[x].Read(reader);
        }
        for (x = 0; (x < _mirrors.Count); x = (x + 1)) {
          Mirrors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals.Add(new StructureBspClusterPortalIndexBlock());
          Portals[x].Read(reader);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _sky.Write(bw);
        _fog.Write(bw);
        _backgroundSound.Write(bw);
        _soundEnvironment.Write(bw);
        _weather.Write(bw);
        _transitionStructureBsp.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_subclusters.Count = Subclusters.Count;
        _subclusters.Write(bw);
        _firstLensFlareMarkerIndex.Write(bw);
        _lensFlareMarkerCount.Write(bw);
_surfaceIndices.Count = SurfaceIndices.Count;
        _surfaceIndices.Write(bw);
_mirrors.Count = Mirrors.Count;
        _mirrors.Write(bw);
_portals.Count = Portals.Count;
        _portals.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _subclusters.Count); x = (x + 1)) {
          Subclusters[x].Write(writer);
        }
        for (x = 0; (x < _subclusters.Count); x = (x + 1)) {
          Subclusters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].Write(writer);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _mirrors.Count); x = (x + 1)) {
          Mirrors[x].Write(writer);
        }
        for (x = 0; (x < _mirrors.Count); x = (x + 1)) {
          Mirrors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].Write(writer);
        }
        for (x = 0; (x < _portals.Count); x = (x + 1)) {
          Portals[x].WriteChildData(writer);
        }
      }
    }
    public class PredictedResourceBlock : IBlock {
      private Enum _type = new Enum();
      private ShortInteger _resourceIndex = new ShortInteger();
      private LongInteger _tagIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlock() {
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
      public LongInteger TagIndex {
        get {
          return this._tagIndex;
        }
        set {
          this._tagIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _tagIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _tagIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspSubclusterBlock : IBlock {
      private RealBounds _worldBoundsX = new RealBounds();
      private RealBounds _worldBoundsY = new RealBounds();
      private RealBounds _worldBoundsZ = new RealBounds();
      private Block _surfaceIndices = new Block();
      public BlockCollection<StructureBspSubclusterSurfaceIndexBlock> _surfaceIndicesList = new BlockCollection<StructureBspSubclusterSurfaceIndexBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspSubclusterBlock() {
      }
      public BlockCollection<StructureBspSubclusterSurfaceIndexBlock> SurfaceIndices {
        get {
          return this._surfaceIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SurfaceIndices.BlockCount; x++)
{
  IBlock block = SurfaceIndices.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _worldBoundsX.Read(reader);
        _worldBoundsY.Read(reader);
        _worldBoundsZ.Read(reader);
        _surfaceIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices.Add(new StructureBspSubclusterSurfaceIndexBlock());
          SurfaceIndices[x].Read(reader);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _worldBoundsX.Write(bw);
        _worldBoundsY.Write(bw);
        _worldBoundsZ.Write(bw);
_surfaceIndices.Count = SurfaceIndices.Count;
        _surfaceIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].Write(writer);
        }
        for (x = 0; (x < _surfaceIndices.Count); x = (x + 1)) {
          SurfaceIndices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspSubclusterSurfaceIndexBlock : IBlock {
      private LongInteger _index = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspSubclusterSurfaceIndexBlock() {
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
    public class StructureBspClusterSurfaceIndexBlock : IBlock {
      private LongInteger _index = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterSurfaceIndexBlock() {
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
    public class StructureBspMirrorBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
      private Pad _unnamed;
      private TagReference _shader = new TagReference();
      private Block _vertices = new Block();
      public BlockCollection<StructureBspMirrorVertexBlock> _verticesList = new BlockCollection<StructureBspMirrorVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspMirrorBlock() {
        this._unnamed = new Pad(20);
      }
      public BlockCollection<StructureBspMirrorVertexBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
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
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
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
        _plane.Read(reader);
        _unnamed.Read(reader);
        _shader.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _shader.ReadString(reader);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new StructureBspMirrorVertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _unnamed.Write(bw);
        _shader.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _shader.WriteString(writer);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class StructureBspMirrorVertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspMirrorVertexBlock() {
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
    public class StructureBspClusterPortalIndexBlock : IBlock {
      private ShortInteger _portal = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalIndexBlock() {
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
      public ShortInteger Portal {
        get {
          return this._portal;
        }
        set {
          this._portal = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _portal.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _portal.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspClusterPortalBlock : IBlock {
      private ShortInteger _frontCluster = new ShortInteger();
      private ShortInteger _backCluster = new ShortInteger();
      private LongInteger _planeIndex = new LongInteger();
      private RealPoint3D _centroid = new RealPoint3D();
      private Real _boundingRadius = new Real();
      private Flags _flags;
      private Pad _unnamed;
      private Block _vertices = new Block();
      public BlockCollection<StructureBspClusterPortalVertexBlock> _verticesList = new BlockCollection<StructureBspClusterPortalVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(24);
      }
      public BlockCollection<StructureBspClusterPortalVertexBlock> Vertices {
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
      public ShortInteger FrontCluster {
        get {
          return this._frontCluster;
        }
        set {
          this._frontCluster = value;
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
        _frontCluster.Read(reader);
        _backCluster.Read(reader);
        _planeIndex.Read(reader);
        _centroid.Read(reader);
        _boundingRadius.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new StructureBspClusterPortalVertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _frontCluster.Write(bw);
        _backCluster.Write(bw);
        _planeIndex.Write(bw);
        _centroid.Write(bw);
        _boundingRadius.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
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
    public class StructureBspClusterPortalVertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspClusterPortalVertexBlock() {
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
    public class StructureBspBreakableSurfaceBlock : IBlock {
      private RealPoint3D _centroid = new RealPoint3D();
      private Real _radius = new Real();
      private LongInteger _collisionSurfaceIndex = new LongInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public StructureBspBreakableSurfaceBlock() {
        this._unnamed = new Pad(28);
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
        _centroid.Read(reader);
        _radius.Read(reader);
        _collisionSurfaceIndex.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _centroid.Write(bw);
        _radius.Write(bw);
        _collisionSurfaceIndex.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspFogPlaneBlock : IBlock {
      private ShortBlockIndex _frontRegion = new ShortBlockIndex();
      private Pad _unnamed;
      private RealPlane3D _plane = new RealPlane3D();
      private Block _vertices = new Block();
      public BlockCollection<StructureBspFogPlaneVertexBlock> _verticesList = new BlockCollection<StructureBspFogPlaneVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogPlaneBlock() {
        this._unnamed = new Pad(2);
      }
      public BlockCollection<StructureBspFogPlaneVertexBlock> Vertices {
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
      public ShortBlockIndex FrontRegion {
        get {
          return this._frontRegion;
        }
        set {
          this._frontRegion = value;
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
        _frontRegion.Read(reader);
        _unnamed.Read(reader);
        _plane.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new StructureBspFogPlaneVertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _frontRegion.Write(bw);
        _unnamed.Write(bw);
        _plane.Write(bw);
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
    public class StructureBspFogPlaneVertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogPlaneVertexBlock() {
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
    public class StructureBspFogRegionBlock : IBlock {
      private Pad _unnamed;
      private ShortBlockIndex _fogPalette = new ShortBlockIndex();
      private ShortBlockIndex _weatherPalette = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public StructureBspFogRegionBlock() {
        this._unnamed = new Pad(36);
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
      public ShortBlockIndex FogPalette {
        get {
          return this._fogPalette;
        }
        set {
          this._fogPalette = value;
        }
      }
      public ShortBlockIndex WeatherPalette {
        get {
          return this._weatherPalette;
        }
        set {
          this._weatherPalette = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _fogPalette.Read(reader);
        _weatherPalette.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _fogPalette.Write(bw);
        _weatherPalette.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspFogPaletteBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _fog = new TagReference();
      private Pad _unnamed;
      private FixedLengthString _fogScaleFunction = new FixedLengthString();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public StructureBspFogPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(52);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_fog.Value);
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
      public TagReference Fog {
        get {
          return this._fog;
        }
        set {
          this._fog = value;
        }
      }
      public FixedLengthString FogScaleFunction {
        get {
          return this._fogScaleFunction;
        }
        set {
          this._fogScaleFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _fog.Read(reader);
        _unnamed.Read(reader);
        _fogScaleFunction.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _fog.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _fog.Write(bw);
        _unnamed.Write(bw);
        _fogScaleFunction.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _fog.WriteString(writer);
      }
    }
    public class StructureBspWeatherPaletteBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _particleSystem = new TagReference();
      private Pad _unnamed;
      private FixedLengthString _particleSystemScaleFunction = new FixedLengthString();
      private Pad _unnamed2;
      private TagReference _wind = new TagReference();
      private RealVector3D _windDirection = new RealVector3D();
      private Real _windMagnitude = new Real();
      private Pad _unnamed3;
      private FixedLengthString _windScaleFunction = new FixedLengthString();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(44);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(44);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_particleSystem.Value);
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
      public TagReference ParticleSystem {
        get {
          return this._particleSystem;
        }
        set {
          this._particleSystem = value;
        }
      }
      public FixedLengthString ParticleSystemScaleFunction {
        get {
          return this._particleSystemScaleFunction;
        }
        set {
          this._particleSystemScaleFunction = value;
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
        _particleSystem.Read(reader);
        _unnamed.Read(reader);
        _particleSystemScaleFunction.Read(reader);
        _unnamed2.Read(reader);
        _wind.Read(reader);
        _windDirection.Read(reader);
        _windMagnitude.Read(reader);
        _unnamed3.Read(reader);
        _windScaleFunction.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _particleSystem.ReadString(reader);
        _wind.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _particleSystem.Write(bw);
        _unnamed.Write(bw);
        _particleSystemScaleFunction.Write(bw);
        _unnamed2.Write(bw);
        _wind.Write(bw);
        _windDirection.Write(bw);
        _windMagnitude.Write(bw);
        _unnamed3.Write(bw);
        _windScaleFunction.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _particleSystem.WriteString(writer);
        _wind.WriteString(writer);
      }
    }
    public class StructureBspWeatherPolyhedronBlock : IBlock {
      private RealPoint3D _boundingSphereCenter = new RealPoint3D();
      private Real _boundingSphereRadius = new Real();
      private Pad _unnamed;
      private Block _planes = new Block();
      public BlockCollection<StructureBspWeatherPolyhedronPlaneBlock> _planesList = new BlockCollection<StructureBspWeatherPolyhedronPlaneBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPolyhedronBlock() {
        this._unnamed = new Pad(4);
      }
      public BlockCollection<StructureBspWeatherPolyhedronPlaneBlock> Planes {
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
        _unnamed.Read(reader);
        _planes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new StructureBspWeatherPolyhedronPlaneBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _boundingSphereCenter.Write(bw);
        _boundingSphereRadius.Write(bw);
        _unnamed.Write(bw);
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
    public class StructureBspWeatherPolyhedronPlaneBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPolyhedronPlaneBlock() {
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
    public class StructureBspPathfindingSurfacesBlock : IBlock {
      private CharInteger _data = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspPathfindingSurfacesBlock() {
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
      public CharInteger Data {
        get {
          return this._data;
        }
        set {
          this._data = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspPathfindingEdgesBlock : IBlock {
      private CharInteger _midpoint = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public StructureBspPathfindingEdgesBlock() {
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
    public class StructureBspBackgroundSoundPaletteBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _backgroundSound = new TagReference();
      private Pad _unnamed;
      private FixedLengthString _scaleFunction = new FixedLengthString();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public StructureBspBackgroundSoundPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundSound.Value);
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
      public FixedLengthString ScaleFunction {
        get {
          return this._scaleFunction;
        }
        set {
          this._scaleFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _backgroundSound.Read(reader);
        _unnamed.Read(reader);
        _scaleFunction.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _backgroundSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _backgroundSound.Write(bw);
        _unnamed.Write(bw);
        _scaleFunction.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _backgroundSound.WriteString(writer);
      }
    }
    public class StructureBspSoundEnvironmentPaletteBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _soundEnvironment = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public StructureBspSoundEnvironmentPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _soundEnvironment.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _soundEnvironment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _soundEnvironment.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _soundEnvironment.WriteString(writer);
      }
    }
    public class StructureBspMarkerBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealQuaternion _rotation = new RealQuaternion();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public StructureBspMarkerBlock() {
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
    public class StructureBspDetailObjectDataBlock : IBlock {
      private Block _cells = new Block();
      private Block _instances = new Block();
      private Block _counts = new Block();
      private Block _zReferenceVectors = new Block();
      private Pad _unnamed;
      public BlockCollection<GlobalDetailObjectCellsBlock> _cellsList = new BlockCollection<GlobalDetailObjectCellsBlock>();
      public BlockCollection<GlobalDetailObjectBlock> _instancesList = new BlockCollection<GlobalDetailObjectBlock>();
      public BlockCollection<GlobalDetailObjectCountsBlock> _countsList = new BlockCollection<GlobalDetailObjectCountsBlock>();
      public BlockCollection<GlobalZReferenceVectorBlock> _zReferenceVectorsList = new BlockCollection<GlobalZReferenceVectorBlock>();
public event System.EventHandler BlockNameChanged;
      public StructureBspDetailObjectDataBlock() {
        this._unnamed = new Pad(16);
      }
      public BlockCollection<GlobalDetailObjectCellsBlock> Cells {
        get {
          return this._cellsList;
        }
      }
      public BlockCollection<GlobalDetailObjectBlock> Instances {
        get {
          return this._instancesList;
        }
      }
      public BlockCollection<GlobalDetailObjectCountsBlock> Counts {
        get {
          return this._countsList;
        }
      }
      public BlockCollection<GlobalZReferenceVectorBlock> ZReferenceVectors {
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells.Add(new GlobalDetailObjectCellsBlock());
          Cells[x].Read(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances.Add(new GlobalDetailObjectBlock());
          Instances[x].Read(reader);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].ReadChildData(reader);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts.Add(new GlobalDetailObjectCountsBlock());
          Counts[x].Read(reader);
        }
        for (x = 0; (x < _counts.Count); x = (x + 1)) {
          Counts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _zReferenceVectors.Count); x = (x + 1)) {
          ZReferenceVectors.Add(new GlobalZReferenceVectorBlock());
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
        _unnamed.Write(bw);
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
    public class GlobalDetailObjectCellsBlock : IBlock {
      private ShortInteger _unnamed = new ShortInteger();
      private ShortInteger _unnamed2 = new ShortInteger();
      private ShortInteger _unnamed3 = new ShortInteger();
      private ShortInteger _unnamed4 = new ShortInteger();
      private LongInteger _unnamed5 = new LongInteger();
      private LongInteger _unnamed6 = new LongInteger();
      private LongInteger _unnamed7 = new LongInteger();
      private Pad _unnamed8;
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectCellsBlock() {
        this._unnamed8 = new Pad(12);
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
      public ShortInteger unnamed {
        get {
          return this._unnamed;
        }
        set {
          this._unnamed = value;
        }
      }
      public ShortInteger unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public ShortInteger unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public ShortInteger unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public LongInteger unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public LongInteger unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public LongInteger unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalDetailObjectBlock : IBlock {
      private CharInteger _unnamed = new CharInteger();
      private CharInteger _unnamed2 = new CharInteger();
      private CharInteger _unnamed3 = new CharInteger();
      private CharInteger _unnamed4 = new CharInteger();
      private ShortInteger _unnamed5 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectBlock() {
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
      public CharInteger unnamed {
        get {
          return this._unnamed;
        }
        set {
          this._unnamed = value;
        }
      }
      public CharInteger unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public CharInteger unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public CharInteger unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public ShortInteger unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalDetailObjectCountsBlock : IBlock {
      private ShortInteger _unnamed = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalDetailObjectCountsBlock() {
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
      public ShortInteger unnamed {
        get {
          return this._unnamed;
        }
        set {
          this._unnamed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalZReferenceVectorBlock : IBlock {
      private Real _unnamed = new Real();
      private Real _unnamed2 = new Real();
      private Real _unnamed3 = new Real();
      private Real _unnamed4 = new Real();
public event System.EventHandler BlockNameChanged;
      public GlobalZReferenceVectorBlock() {
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
      public Real unnamed {
        get {
          return this._unnamed;
        }
        set {
          this._unnamed = value;
        }
      }
      public Real unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public Real unnamed3 {
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
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspRuntimeDecalBlock : IBlock {
      private Skip _unnamed;
public event System.EventHandler BlockNameChanged;
      public StructureBspRuntimeDecalBlock() {
        this._unnamed = new Skip(16);
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalMapLeafBlock : IBlock {
      private Block _faces = new Block();
      private Block _portalIndices = new Block();
      public BlockCollection<MapLeafFaceBlock> _facesList = new BlockCollection<MapLeafFaceBlock>();
      public BlockCollection<MapLeafPortalIndexBlock> _portalIndicesList = new BlockCollection<MapLeafPortalIndexBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalMapLeafBlock() {
      }
      public BlockCollection<MapLeafFaceBlock> Faces {
        get {
          return this._facesList;
        }
      }
      public BlockCollection<MapLeafPortalIndexBlock> PortalIndices {
        get {
          return this._portalIndicesList;
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
for (int x=0; x<PortalIndices.BlockCount; x++)
{
  IBlock block = PortalIndices.GetBlock(x);
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
        _portalIndices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces.Add(new MapLeafFaceBlock());
          Faces[x].Read(reader);
        }
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _portalIndices.Count); x = (x + 1)) {
          PortalIndices.Add(new MapLeafPortalIndexBlock());
          PortalIndices[x].Read(reader);
        }
        for (x = 0; (x < _portalIndices.Count); x = (x + 1)) {
          PortalIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_faces.Count = Faces.Count;
        _faces.Write(bw);
_portalIndices.Count = PortalIndices.Count;
        _portalIndices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].Write(writer);
        }
        for (x = 0; (x < _faces.Count); x = (x + 1)) {
          Faces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _portalIndices.Count); x = (x + 1)) {
          PortalIndices[x].Write(writer);
        }
        for (x = 0; (x < _portalIndices.Count); x = (x + 1)) {
          PortalIndices[x].WriteChildData(writer);
        }
      }
    }
    public class MapLeafFaceBlock : IBlock {
      private LongInteger _nodeIndex = new LongInteger();
      private Block _vertices = new Block();
      public BlockCollection<MapLeafFaceVertexBlock> _verticesList = new BlockCollection<MapLeafFaceVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public MapLeafFaceBlock() {
      }
      public BlockCollection<MapLeafFaceVertexBlock> Vertices {
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
          Vertices.Add(new MapLeafFaceVertexBlock());
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
    public class MapLeafFaceVertexBlock : IBlock {
      private RealPoint2D _vertex = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public MapLeafFaceVertexBlock() {
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
      public RealPoint2D Vertex {
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
    public class MapLeafPortalIndexBlock : IBlock {
      private LongInteger _portalIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public MapLeafPortalIndexBlock() {
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
      public LongInteger PortalIndex {
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
    public class GlobalLeafPortalBlock : IBlock {
      private LongInteger _planeIndex = new LongInteger();
      private LongInteger _backLeafIndex = new LongInteger();
      private LongInteger _frontLeafIndex = new LongInteger();
      private Block _vertices = new Block();
      public BlockCollection<LeafPortalVertexBlock> _verticesList = new BlockCollection<LeafPortalVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalLeafPortalBlock() {
      }
      public BlockCollection<LeafPortalVertexBlock> Vertices {
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
      public virtual void Read(BinaryReader reader) {
        _planeIndex.Read(reader);
        _backLeafIndex.Read(reader);
        _frontLeafIndex.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new LeafPortalVertexBlock());
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
    public class LeafPortalVertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public LeafPortalVertexBlock() {
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
  }
}
