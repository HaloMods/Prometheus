// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'gbxmodel'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class gbxmodel : Interfaces.Pool.Tag {
    private GbxmodelBlock gbxmodelValues = new GbxmodelBlock();
    public virtual GbxmodelBlock GbxmodelValues {
      get {
        return gbxmodelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(GbxmodelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "gbxmodel";
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
gbxmodelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
gbxmodelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
gbxmodelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
gbxmodelValues.WriteChildData(writer);
    }
    #endregion
    public class GbxmodelBlock : IBlock {
      private Flags _flags;
      private LongInteger _nodeListChecksum = new LongInteger();
      private Real _superLowDetailCutoff = new Real();
      private Real _lowDetailCutoff = new Real();
      private Real _mediumDetailCutoff = new Real();
      private Real _highDetailCutoff = new Real();
      private Real _superHighDetailCutoff = new Real();
      private ShortInteger _superLowDetailNodeCount = new ShortInteger();
      private ShortInteger _lowDetailNodeCount = new ShortInteger();
      private ShortInteger _mediumDetailNodeCount = new ShortInteger();
      private ShortInteger _highDetailNodeCount = new ShortInteger();
      private ShortInteger _superHighDetailNodeCount = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Real _baseMap = new Real();
      private Real _baseMap2 = new Real();
      private Pad _unnamed3;
      private Block _markers = new Block();
      private Block _nodes = new Block();
      private Block _regions = new Block();
      private Block _geometries = new Block();
      private Block _shaders = new Block();
      public BlockCollection<ModelMarkersBlock> _markersList = new BlockCollection<ModelMarkersBlock>();
      public BlockCollection<ModelNodeBlock> _nodesList = new BlockCollection<ModelNodeBlock>();
      public BlockCollection<GbxmodelRegionBlock> _regionsList = new BlockCollection<GbxmodelRegionBlock>();
      public BlockCollection<GbxmodelGeometryBlock> _geometriesList = new BlockCollection<GbxmodelGeometryBlock>();
      public BlockCollection<ModelShaderReferenceBlock> _shadersList = new BlockCollection<ModelShaderReferenceBlock>();
public event System.EventHandler BlockNameChanged;
      public GbxmodelBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(116);
      }
      public BlockCollection<ModelMarkersBlock> Markers {
        get {
          return this._markersList;
        }
      }
      public BlockCollection<ModelNodeBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<GbxmodelRegionBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<GbxmodelGeometryBlock> Geometries {
        get {
          return this._geometriesList;
        }
      }
      public BlockCollection<ModelShaderReferenceBlock> Shaders {
        get {
          return this._shadersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Markers.BlockCount; x++)
{
  IBlock block = Markers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Geometries.BlockCount; x++)
{
  IBlock block = Geometries.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Shaders.BlockCount; x++)
{
  IBlock block = Shaders.GetBlock(x);
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
      public LongInteger NodeListChecksum {
        get {
          return this._nodeListChecksum;
        }
        set {
          this._nodeListChecksum = value;
        }
      }
      public Real SuperLowDetailCutoff {
        get {
          return this._superLowDetailCutoff;
        }
        set {
          this._superLowDetailCutoff = value;
        }
      }
      public Real LowDetailCutoff {
        get {
          return this._lowDetailCutoff;
        }
        set {
          this._lowDetailCutoff = value;
        }
      }
      public Real MediumDetailCutoff {
        get {
          return this._mediumDetailCutoff;
        }
        set {
          this._mediumDetailCutoff = value;
        }
      }
      public Real HighDetailCutoff {
        get {
          return this._highDetailCutoff;
        }
        set {
          this._highDetailCutoff = value;
        }
      }
      public Real SuperHighDetailCutoff {
        get {
          return this._superHighDetailCutoff;
        }
        set {
          this._superHighDetailCutoff = value;
        }
      }
      public ShortInteger SuperLowDetailNodeCount {
        get {
          return this._superLowDetailNodeCount;
        }
        set {
          this._superLowDetailNodeCount = value;
        }
      }
      public ShortInteger LowDetailNodeCount {
        get {
          return this._lowDetailNodeCount;
        }
        set {
          this._lowDetailNodeCount = value;
        }
      }
      public ShortInteger MediumDetailNodeCount {
        get {
          return this._mediumDetailNodeCount;
        }
        set {
          this._mediumDetailNodeCount = value;
        }
      }
      public ShortInteger HighDetailNodeCount {
        get {
          return this._highDetailNodeCount;
        }
        set {
          this._highDetailNodeCount = value;
        }
      }
      public ShortInteger SuperHighDetailNodeCount {
        get {
          return this._superHighDetailNodeCount;
        }
        set {
          this._superHighDetailNodeCount = value;
        }
      }
      public Real BaseMap {
        get {
          return this._baseMap;
        }
        set {
          this._baseMap = value;
        }
      }
      public Real BaseMap2 {
        get {
          return this._baseMap2;
        }
        set {
          this._baseMap2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _nodeListChecksum.Read(reader);
        _superLowDetailCutoff.Read(reader);
        _lowDetailCutoff.Read(reader);
        _mediumDetailCutoff.Read(reader);
        _highDetailCutoff.Read(reader);
        _superHighDetailCutoff.Read(reader);
        _superLowDetailNodeCount.Read(reader);
        _lowDetailNodeCount.Read(reader);
        _mediumDetailNodeCount.Read(reader);
        _highDetailNodeCount.Read(reader);
        _superHighDetailNodeCount.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _baseMap.Read(reader);
        _baseMap2.Read(reader);
        _unnamed3.Read(reader);
        _markers.Read(reader);
        _nodes.Read(reader);
        _regions.Read(reader);
        _geometries.Read(reader);
        _shaders.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new ModelMarkersBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new ModelNodeBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new GbxmodelRegionBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _geometries.Count); x = (x + 1)) {
          Geometries.Add(new GbxmodelGeometryBlock());
          Geometries[x].Read(reader);
        }
        for (x = 0; (x < _geometries.Count); x = (x + 1)) {
          Geometries[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders.Add(new ModelShaderReferenceBlock());
          Shaders[x].Read(reader);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _nodeListChecksum.Write(bw);
        _superLowDetailCutoff.Write(bw);
        _lowDetailCutoff.Write(bw);
        _mediumDetailCutoff.Write(bw);
        _highDetailCutoff.Write(bw);
        _superHighDetailCutoff.Write(bw);
        _superLowDetailNodeCount.Write(bw);
        _lowDetailNodeCount.Write(bw);
        _mediumDetailNodeCount.Write(bw);
        _highDetailNodeCount.Write(bw);
        _superHighDetailNodeCount.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _baseMap.Write(bw);
        _baseMap2.Write(bw);
        _unnamed3.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_geometries.Count = Geometries.Count;
        _geometries.Write(bw);
_shaders.Count = Shaders.Count;
        _shaders.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].Write(writer);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _geometries.Count); x = (x + 1)) {
          Geometries[x].Write(writer);
        }
        for (x = 0; (x < _geometries.Count); x = (x + 1)) {
          Geometries[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].Write(writer);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].WriteChildData(writer);
        }
      }
    }
    public class ModelMarkersBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortInteger _magicIdentifier = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Block _instances = new Block();
      public BlockCollection<ModelMarkerInstanceBlock> _instancesList = new BlockCollection<ModelMarkerInstanceBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelMarkersBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
      }
      public BlockCollection<ModelMarkerInstanceBlock> Instances {
        get {
          return this._instancesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Instances.BlockCount; x++)
{
  IBlock block = Instances.GetBlock(x);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger MagicIdentifier {
        get {
          return this._magicIdentifier;
        }
        set {
          this._magicIdentifier = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _magicIdentifier.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _instances.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances.Add(new ModelMarkerInstanceBlock());
          Instances[x].Read(reader);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _magicIdentifier.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
_instances.Count = Instances.Count;
        _instances.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].Write(writer);
        }
        for (x = 0; (x < _instances.Count); x = (x + 1)) {
          Instances[x].WriteChildData(writer);
        }
      }
    }
    public class ModelMarkerInstanceBlock : IBlock {
      private CharInteger _regionIndex = new CharInteger();
      private CharInteger _permutationIndex = new CharInteger();
      private CharInteger _nodeIndex = new CharInteger();
      private Pad _unnamed;
      private RealPoint3D _translation = new RealPoint3D();
      private RealQuaternion _rotation = new RealQuaternion();
public event System.EventHandler BlockNameChanged;
      public ModelMarkerInstanceBlock() {
        this._unnamed = new Pad(1);
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
      public CharInteger RegionIndex {
        get {
          return this._regionIndex;
        }
        set {
          this._regionIndex = value;
        }
      }
      public CharInteger PermutationIndex {
        get {
          return this._permutationIndex;
        }
        set {
          this._permutationIndex = value;
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
      public RealPoint3D Translation {
        get {
          return this._translation;
        }
        set {
          this._translation = value;
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
      public virtual void Read(BinaryReader reader) {
        _regionIndex.Read(reader);
        _permutationIndex.Read(reader);
        _nodeIndex.Read(reader);
        _unnamed.Read(reader);
        _translation.Read(reader);
        _rotation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _regionIndex.Write(bw);
        _permutationIndex.Write(bw);
        _nodeIndex.Write(bw);
        _unnamed.Write(bw);
        _translation.Write(bw);
        _rotation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ModelNodeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _nextSiblingNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _parentNodeIndex = new ShortBlockIndex();
      private Pad _unnamed;
      private RealPoint3D _defaultTranslation = new RealPoint3D();
      private RealQuaternion _defaultRotation = new RealQuaternion();
      private Real _nodeDistanceFromParent = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public ModelNodeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(52);
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
      public ShortBlockIndex NextSiblingNodeIndex {
        get {
          return this._nextSiblingNodeIndex;
        }
        set {
          this._nextSiblingNodeIndex = value;
        }
      }
      public ShortBlockIndex FirstChildNodeIndex {
        get {
          return this._firstChildNodeIndex;
        }
        set {
          this._firstChildNodeIndex = value;
        }
      }
      public ShortBlockIndex ParentNodeIndex {
        get {
          return this._parentNodeIndex;
        }
        set {
          this._parentNodeIndex = value;
        }
      }
      public RealPoint3D DefaultTranslation {
        get {
          return this._defaultTranslation;
        }
        set {
          this._defaultTranslation = value;
        }
      }
      public RealQuaternion DefaultRotation {
        get {
          return this._defaultRotation;
        }
        set {
          this._defaultRotation = value;
        }
      }
      public Real NodeDistanceFromParent {
        get {
          return this._nodeDistanceFromParent;
        }
        set {
          this._nodeDistanceFromParent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nextSiblingNodeIndex.Read(reader);
        _firstChildNodeIndex.Read(reader);
        _parentNodeIndex.Read(reader);
        _unnamed.Read(reader);
        _defaultTranslation.Read(reader);
        _defaultRotation.Read(reader);
        _nodeDistanceFromParent.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nextSiblingNodeIndex.Write(bw);
        _firstChildNodeIndex.Write(bw);
        _parentNodeIndex.Write(bw);
        _unnamed.Write(bw);
        _defaultTranslation.Write(bw);
        _defaultRotation.Write(bw);
        _nodeDistanceFromParent.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GbxmodelRegionBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed;
      private Block _permutations = new Block();
      public BlockCollection<GbxmodelRegionPermutationBlock> _permutationsList = new BlockCollection<GbxmodelRegionPermutationBlock>();
public event System.EventHandler BlockNameChanged;
      public GbxmodelRegionBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public BlockCollection<GbxmodelRegionPermutationBlock> Permutations {
        get {
          return this._permutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Permutations.BlockCount; x++)
{
  IBlock block = Permutations.GetBlock(x);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new GbxmodelRegionPermutationBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class GbxmodelRegionPermutationBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private ShortBlockIndex _superLow = new ShortBlockIndex();
      private ShortBlockIndex _low = new ShortBlockIndex();
      private ShortBlockIndex _medium = new ShortBlockIndex();
      private ShortBlockIndex _high = new ShortBlockIndex();
      private ShortBlockIndex _superHigh = new ShortBlockIndex();
      private Pad _unnamed2;
      private Block _markers = new Block();
      public BlockCollection<ModelRegionPermutationMarkerBlock> _markersList = new BlockCollection<ModelRegionPermutationMarkerBlock>();
public event System.EventHandler BlockNameChanged;
      public GbxmodelRegionPermutationBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(28);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<ModelRegionPermutationMarkerBlock> Markers {
        get {
          return this._markersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Markers.BlockCount; x++)
{
  IBlock block = Markers.GetBlock(x);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public ShortBlockIndex SuperLow {
        get {
          return this._superLow;
        }
        set {
          this._superLow = value;
        }
      }
      public ShortBlockIndex Low {
        get {
          return this._low;
        }
        set {
          this._low = value;
        }
      }
      public ShortBlockIndex Medium {
        get {
          return this._medium;
        }
        set {
          this._medium = value;
        }
      }
      public ShortBlockIndex High {
        get {
          return this._high;
        }
        set {
          this._high = value;
        }
      }
      public ShortBlockIndex SuperHigh {
        get {
          return this._superHigh;
        }
        set {
          this._superHigh = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _superLow.Read(reader);
        _low.Read(reader);
        _medium.Read(reader);
        _high.Read(reader);
        _superHigh.Read(reader);
        _unnamed2.Read(reader);
        _markers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new ModelRegionPermutationMarkerBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _superLow.Write(bw);
        _low.Write(bw);
        _medium.Write(bw);
        _high.Write(bw);
        _superHigh.Write(bw);
        _unnamed2.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].Write(writer);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].WriteChildData(writer);
        }
      }
    }
    public class ModelRegionPermutationMarkerBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _nodeIndex = new ShortBlockIndex();
      private Pad _unnamed;
      private RealQuaternion _rotation = new RealQuaternion();
      private RealPoint3D _translation = new RealPoint3D();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ModelRegionPermutationMarkerBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
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
      public ShortBlockIndex NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeIndex.Read(reader);
        _unnamed.Read(reader);
        _rotation.Read(reader);
        _translation.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeIndex.Write(bw);
        _unnamed.Write(bw);
        _rotation.Write(bw);
        _translation.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GbxmodelGeometryBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Block _parts = new Block();
      public BlockCollection<GbxmodelGeometryPartBlock> _partsList = new BlockCollection<GbxmodelGeometryPartBlock>();
public event System.EventHandler BlockNameChanged;
      public GbxmodelGeometryBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
      }
      public BlockCollection<GbxmodelGeometryPartBlock> Parts {
        get {
          return this._partsList;
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
        _unnamed.Read(reader);
        _parts.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts.Add(new GbxmodelGeometryPartBlock());
          Parts[x].Read(reader);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
_parts.Count = Parts.Count;
        _parts.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].Write(writer);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].WriteChildData(writer);
        }
      }
    }
    public class GbxmodelGeometryPartBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _shaderIndex = new ShortBlockIndex();
      private CharInteger _prevFilthyPartIndex = new CharInteger();
      private CharInteger _nextFilthyPartIndex = new CharInteger();
      private ShortInteger _centroidPrimaryNode = new ShortInteger();
      private ShortInteger _centroidSecondaryNode = new ShortInteger();
      private RealFraction _centroidPrimaryWeight = new RealFraction();
      private RealFraction _centroidSecondaryWeight = new RealFraction();
      private RealPoint3D _centroid = new RealPoint3D();
      private Block _uncompressedVertices = new Block();
      private Block _compressedVertices = new Block();
      private Block _triangles = new Block();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      public BlockCollection<ModelVertexUncompressedBlock> _uncompressedVerticesList = new BlockCollection<ModelVertexUncompressedBlock>();
      public BlockCollection<ModelVertexCompressedBlock> _compressedVerticesList = new BlockCollection<ModelVertexCompressedBlock>();
      public BlockCollection<ModelTriangleBlock> _trianglesList = new BlockCollection<ModelTriangleBlock>();
public event System.EventHandler BlockNameChanged;
      public GbxmodelGeometryPartBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(20);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(1);
        this._unnamed4 = new Pad(1);
        this._unnamed5 = new Pad(1);
        this._unnamed6 = new Pad(1);
        this._unnamed7 = new Pad(24);
      }
      public BlockCollection<ModelVertexUncompressedBlock> UncompressedVertices {
        get {
          return this._uncompressedVerticesList;
        }
      }
      public BlockCollection<ModelVertexCompressedBlock> CompressedVertices {
        get {
          return this._compressedVerticesList;
        }
      }
      public BlockCollection<ModelTriangleBlock> Triangles {
        get {
          return this._trianglesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<UncompressedVertices.BlockCount; x++)
{
  IBlock block = UncompressedVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CompressedVertices.BlockCount; x++)
{
  IBlock block = CompressedVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Triangles.BlockCount; x++)
{
  IBlock block = Triangles.GetBlock(x);
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
      public ShortBlockIndex ShaderIndex {
        get {
          return this._shaderIndex;
        }
        set {
          this._shaderIndex = value;
        }
      }
      public CharInteger PrevFilthyPartIndex {
        get {
          return this._prevFilthyPartIndex;
        }
        set {
          this._prevFilthyPartIndex = value;
        }
      }
      public CharInteger NextFilthyPartIndex {
        get {
          return this._nextFilthyPartIndex;
        }
        set {
          this._nextFilthyPartIndex = value;
        }
      }
      public ShortInteger CentroidPrimaryNode {
        get {
          return this._centroidPrimaryNode;
        }
        set {
          this._centroidPrimaryNode = value;
        }
      }
      public ShortInteger CentroidSecondaryNode {
        get {
          return this._centroidSecondaryNode;
        }
        set {
          this._centroidSecondaryNode = value;
        }
      }
      public RealFraction CentroidPrimaryWeight {
        get {
          return this._centroidPrimaryWeight;
        }
        set {
          this._centroidPrimaryWeight = value;
        }
      }
      public RealFraction CentroidSecondaryWeight {
        get {
          return this._centroidSecondaryWeight;
        }
        set {
          this._centroidSecondaryWeight = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _shaderIndex.Read(reader);
        _prevFilthyPartIndex.Read(reader);
        _nextFilthyPartIndex.Read(reader);
        _centroidPrimaryNode.Read(reader);
        _centroidSecondaryNode.Read(reader);
        _centroidPrimaryWeight.Read(reader);
        _centroidSecondaryWeight.Read(reader);
        _centroid.Read(reader);
        _uncompressedVertices.Read(reader);
        _compressedVertices.Read(reader);
        _triangles.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _uncompressedVertices.Count); x = (x + 1)) {
          UncompressedVertices.Add(new ModelVertexUncompressedBlock());
          UncompressedVertices[x].Read(reader);
        }
        for (x = 0; (x < _uncompressedVertices.Count); x = (x + 1)) {
          UncompressedVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _compressedVertices.Count); x = (x + 1)) {
          CompressedVertices.Add(new ModelVertexCompressedBlock());
          CompressedVertices[x].Read(reader);
        }
        for (x = 0; (x < _compressedVertices.Count); x = (x + 1)) {
          CompressedVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles.Add(new ModelTriangleBlock());
          Triangles[x].Read(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _shaderIndex.Write(bw);
        _prevFilthyPartIndex.Write(bw);
        _nextFilthyPartIndex.Write(bw);
        _centroidPrimaryNode.Write(bw);
        _centroidSecondaryNode.Write(bw);
        _centroidPrimaryWeight.Write(bw);
        _centroidSecondaryWeight.Write(bw);
        _centroid.Write(bw);
_uncompressedVertices.Count = UncompressedVertices.Count;
        _uncompressedVertices.Write(bw);
_compressedVertices.Count = CompressedVertices.Count;
        _compressedVertices.Write(bw);
_triangles.Count = Triangles.Count;
        _triangles.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _uncompressedVertices.Count); x = (x + 1)) {
          UncompressedVertices[x].Write(writer);
        }
        for (x = 0; (x < _uncompressedVertices.Count); x = (x + 1)) {
          UncompressedVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _compressedVertices.Count); x = (x + 1)) {
          CompressedVertices[x].Write(writer);
        }
        for (x = 0; (x < _compressedVertices.Count); x = (x + 1)) {
          CompressedVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].Write(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].WriteChildData(writer);
        }
      }
    }
    public class ModelVertexUncompressedBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _normal = new RealVector3D();
      private RealVector3D _binormal = new RealVector3D();
      private RealVector3D _tangent = new RealVector3D();
      private RealPoint2D _textureCoords = new RealPoint2D();
      private ShortInteger _node0Index = new ShortInteger();
      private ShortInteger _node1Index = new ShortInteger();
      private Real _node0Weight = new Real();
      private Real _node1Weight = new Real();
public event System.EventHandler BlockNameChanged;
      public ModelVertexUncompressedBlock() {
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
      public RealPoint2D TextureCoords {
        get {
          return this._textureCoords;
        }
        set {
          this._textureCoords = value;
        }
      }
      public ShortInteger Node0Index {
        get {
          return this._node0Index;
        }
        set {
          this._node0Index = value;
        }
      }
      public ShortInteger Node1Index {
        get {
          return this._node1Index;
        }
        set {
          this._node1Index = value;
        }
      }
      public Real Node0Weight {
        get {
          return this._node0Weight;
        }
        set {
          this._node0Weight = value;
        }
      }
      public Real Node1Weight {
        get {
          return this._node1Weight;
        }
        set {
          this._node1Weight = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _normal.Read(reader);
        _binormal.Read(reader);
        _tangent.Read(reader);
        _textureCoords.Read(reader);
        _node0Index.Read(reader);
        _node1Index.Read(reader);
        _node0Weight.Read(reader);
        _node1Weight.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _normal.Write(bw);
        _binormal.Write(bw);
        _tangent.Write(bw);
        _textureCoords.Write(bw);
        _node0Index.Write(bw);
        _node1Index.Write(bw);
        _node0Weight.Write(bw);
        _node1Weight.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ModelVertexCompressedBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private LongInteger _normal11_Pt11_Pt1 = new LongInteger();
      private LongInteger _binormal11_Pt11_Pt1 = new LongInteger();
      private LongInteger _tangent11_Pt11_Pt1 = new LongInteger();
      private ShortInteger _textureCoordinateU1 = new ShortInteger();
      private ShortInteger _textureCoordinateV1 = new ShortInteger();
      private CharInteger _node0Indexx3 = new CharInteger();
      private CharInteger _node1Indexx3 = new CharInteger();
      private ShortInteger _node0Weight1 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ModelVertexCompressedBlock() {
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
      public LongInteger Normal11_Pt11_Pt1 {
        get {
          return this._normal11_Pt11_Pt1;
        }
        set {
          this._normal11_Pt11_Pt1 = value;
        }
      }
      public LongInteger Binormal11_Pt11_Pt1 {
        get {
          return this._binormal11_Pt11_Pt1;
        }
        set {
          this._binormal11_Pt11_Pt1 = value;
        }
      }
      public LongInteger Tangent11_Pt11_Pt1 {
        get {
          return this._tangent11_Pt11_Pt1;
        }
        set {
          this._tangent11_Pt11_Pt1 = value;
        }
      }
      public ShortInteger TextureCoordinateU1 {
        get {
          return this._textureCoordinateU1;
        }
        set {
          this._textureCoordinateU1 = value;
        }
      }
      public ShortInteger TextureCoordinateV1 {
        get {
          return this._textureCoordinateV1;
        }
        set {
          this._textureCoordinateV1 = value;
        }
      }
      public CharInteger Node0Indexx3 {
        get {
          return this._node0Indexx3;
        }
        set {
          this._node0Indexx3 = value;
        }
      }
      public CharInteger Node1Indexx3 {
        get {
          return this._node1Indexx3;
        }
        set {
          this._node1Indexx3 = value;
        }
      }
      public ShortInteger Node0Weight1 {
        get {
          return this._node0Weight1;
        }
        set {
          this._node0Weight1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _normal11_Pt11_Pt1.Read(reader);
        _binormal11_Pt11_Pt1.Read(reader);
        _tangent11_Pt11_Pt1.Read(reader);
        _textureCoordinateU1.Read(reader);
        _textureCoordinateV1.Read(reader);
        _node0Indexx3.Read(reader);
        _node1Indexx3.Read(reader);
        _node0Weight1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _normal11_Pt11_Pt1.Write(bw);
        _binormal11_Pt11_Pt1.Write(bw);
        _tangent11_Pt11_Pt1.Write(bw);
        _textureCoordinateU1.Write(bw);
        _textureCoordinateV1.Write(bw);
        _node0Indexx3.Write(bw);
        _node1Indexx3.Write(bw);
        _node0Weight1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ModelTriangleBlock : IBlock {
      private ShortInteger _vertex0Index = new ShortInteger();
      private ShortInteger _vertex1Index = new ShortInteger();
      private ShortInteger _vertex2Index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ModelTriangleBlock() {
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
      public ShortInteger Vertex0Index {
        get {
          return this._vertex0Index;
        }
        set {
          this._vertex0Index = value;
        }
      }
      public ShortInteger Vertex1Index {
        get {
          return this._vertex1Index;
        }
        set {
          this._vertex1Index = value;
        }
      }
      public ShortInteger Vertex2Index {
        get {
          return this._vertex2Index;
        }
        set {
          this._vertex2Index = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertex0Index.Read(reader);
        _vertex1Index.Read(reader);
        _vertex2Index.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertex0Index.Write(bw);
        _vertex1Index.Write(bw);
        _vertex2Index.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ModelShaderReferenceBlock : IBlock {
      private TagReference _shader = new TagReference();
      private ShortInteger _permutation = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ModelShaderReferenceBlock() {
if (this._shader is System.ComponentModel.INotifyPropertyChanged)
  (this._shader as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
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
return _shader.ToString();
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
      public ShortInteger Permutation {
        get {
          return this._permutation;
        }
        set {
          this._permutation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shader.Read(reader);
        _permutation.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
        _permutation.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shader.WriteString(writer);
      }
    }
  }
}
