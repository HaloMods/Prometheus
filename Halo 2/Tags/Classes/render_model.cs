// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'render_model'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class render_model : Interfaces.Pool.Tag {
    private RenderModelBlockBlock renderModelValues = new RenderModelBlockBlock();
    public virtual RenderModelBlockBlock RenderModelValues {
      get {
        return renderModelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(RenderModelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "render_model";
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
renderModelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
renderModelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
renderModelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
renderModelValues.WriteChildData(writer);
    }
    #endregion
    public class RenderModelBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _renderModelFlags;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Block _importInfo = new Block();
      private Block _compressionInfo = new Block();
      private Block _regions = new Block();
      private Block _sections = new Block();
      private Block _invalidSectionPairBits = new Block();
      private Block _sectionGroups = new Block();
      private CharInteger _l1SectionGroupIndex = new CharInteger();
      private CharInteger _l2SectionGroupIndex = new CharInteger();
      private CharInteger _l3SectionGroupIndex = new CharInteger();
      private CharInteger _l4SectionGroupIndex = new CharInteger();
      private CharInteger _l5SectionGroupIndex = new CharInteger();
      private CharInteger _l6SectionGroupIndex = new CharInteger();
      private Pad _unnamed2;
      private LongInteger _nodeListChecksum = new LongInteger();
      private Block _nodes = new Block();
      private Block _nodeMapOLD = new Block();
      private Block _markerGroups = new Block();
      private Block _materials = new Block();
      private Block _errors = new Block();
      private Real _dontDrawOverCameraCosineAngle = new Real();
      private Block _pRTInfo = new Block();
      private Block _sectionRenderLeaves = new Block();
      public BlockCollection<GlobalTagImportInfoBlockBlock> _importInfoList = new BlockCollection<GlobalTagImportInfoBlockBlock>();
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> _compressionInfoList = new BlockCollection<GlobalGeometryCompressionInfoBlockBlock>();
      public BlockCollection<RenderModelRegionBlockBlock> _regionsList = new BlockCollection<RenderModelRegionBlockBlock>();
      public BlockCollection<RenderModelSectionBlockBlock> _sectionsList = new BlockCollection<RenderModelSectionBlockBlock>();
      public BlockCollection<RenderModelInvalidSectionPairsBlockBlock> _invalidSectionPairBitsList = new BlockCollection<RenderModelInvalidSectionPairsBlockBlock>();
      public BlockCollection<RenderModelSectionGroupBlockBlock> _sectionGroupsList = new BlockCollection<RenderModelSectionGroupBlockBlock>();
      public BlockCollection<RenderModelNodeBlockBlock> _nodesList = new BlockCollection<RenderModelNodeBlockBlock>();
      public BlockCollection<RenderModelNodeMapBlockOLDBlock> _nodeMapOLDList = new BlockCollection<RenderModelNodeMapBlockOLDBlock>();
      public BlockCollection<RenderModelMarkerGroupBlockBlock> _markerGroupsList = new BlockCollection<RenderModelMarkerGroupBlockBlock>();
      public BlockCollection<GlobalGeometryMaterialBlockBlock> _materialsList = new BlockCollection<GlobalGeometryMaterialBlockBlock>();
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> _errorsList = new BlockCollection<GlobalErrorReportCategoriesBlockBlock>();
      public BlockCollection<PrtInfoBlockBlock> _pRTInfoList = new BlockCollection<PrtInfoBlockBlock>();
      public BlockCollection<SectionRenderLeavesBlockBlock> _sectionRenderLeavesList = new BlockCollection<SectionRenderLeavesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelBlockBlock() {
        this._renderModelFlags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<GlobalTagImportInfoBlockBlock> ImportInfo {
        get {
          return this._importInfoList;
        }
      }
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> CompressionInfo {
        get {
          return this._compressionInfoList;
        }
      }
      public BlockCollection<RenderModelRegionBlockBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<RenderModelSectionBlockBlock> Sections {
        get {
          return this._sectionsList;
        }
      }
      public BlockCollection<RenderModelInvalidSectionPairsBlockBlock> InvalidSectionPairBits {
        get {
          return this._invalidSectionPairBitsList;
        }
      }
      public BlockCollection<RenderModelSectionGroupBlockBlock> SectionGroups {
        get {
          return this._sectionGroupsList;
        }
      }
      public BlockCollection<RenderModelNodeBlockBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<RenderModelNodeMapBlockOLDBlock> NodeMapOLD {
        get {
          return this._nodeMapOLDList;
        }
      }
      public BlockCollection<RenderModelMarkerGroupBlockBlock> MarkerGroups {
        get {
          return this._markerGroupsList;
        }
      }
      public BlockCollection<GlobalGeometryMaterialBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public BlockCollection<PrtInfoBlockBlock> PRTInfo {
        get {
          return this._pRTInfoList;
        }
      }
      public BlockCollection<SectionRenderLeavesBlockBlock> SectionRenderLeaves {
        get {
          return this._sectionRenderLeavesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ImportInfo.BlockCount; x++)
{
  IBlock block = ImportInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CompressionInfo.BlockCount; x++)
{
  IBlock block = CompressionInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sections.BlockCount; x++)
{
  IBlock block = Sections.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InvalidSectionPairBits.BlockCount; x++)
{
  IBlock block = InvalidSectionPairBits.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SectionGroups.BlockCount; x++)
{
  IBlock block = SectionGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NodeMapOLD.BlockCount; x++)
{
  IBlock block = NodeMapOLD.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MarkerGroups.BlockCount; x++)
{
  IBlock block = MarkerGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PRTInfo.BlockCount; x++)
{
  IBlock block = PRTInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SectionRenderLeaves.BlockCount; x++)
{
  IBlock block = SectionRenderLeaves.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags RenderModelFlags {
        get {
          return this._renderModelFlags;
        }
        set {
          this._renderModelFlags = value;
        }
      }
      public CharInteger L1SectionGroupIndex {
        get {
          return this._l1SectionGroupIndex;
        }
        set {
          this._l1SectionGroupIndex = value;
        }
      }
      public CharInteger L2SectionGroupIndex {
        get {
          return this._l2SectionGroupIndex;
        }
        set {
          this._l2SectionGroupIndex = value;
        }
      }
      public CharInteger L3SectionGroupIndex {
        get {
          return this._l3SectionGroupIndex;
        }
        set {
          this._l3SectionGroupIndex = value;
        }
      }
      public CharInteger L4SectionGroupIndex {
        get {
          return this._l4SectionGroupIndex;
        }
        set {
          this._l4SectionGroupIndex = value;
        }
      }
      public CharInteger L5SectionGroupIndex {
        get {
          return this._l5SectionGroupIndex;
        }
        set {
          this._l5SectionGroupIndex = value;
        }
      }
      public CharInteger L6SectionGroupIndex {
        get {
          return this._l6SectionGroupIndex;
        }
        set {
          this._l6SectionGroupIndex = value;
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
      public Real DontDrawOverCameraCosineAngle {
        get {
          return this._dontDrawOverCameraCosineAngle;
        }
        set {
          this._dontDrawOverCameraCosineAngle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _renderModelFlags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _importInfo.Read(reader);
        _compressionInfo.Read(reader);
        _regions.Read(reader);
        _sections.Read(reader);
        _invalidSectionPairBits.Read(reader);
        _sectionGroups.Read(reader);
        _l1SectionGroupIndex.Read(reader);
        _l2SectionGroupIndex.Read(reader);
        _l3SectionGroupIndex.Read(reader);
        _l4SectionGroupIndex.Read(reader);
        _l5SectionGroupIndex.Read(reader);
        _l6SectionGroupIndex.Read(reader);
        _unnamed2.Read(reader);
        _nodeListChecksum.Read(reader);
        _nodes.Read(reader);
        _nodeMapOLD.Read(reader);
        _markerGroups.Read(reader);
        _materials.Read(reader);
        _errors.Read(reader);
        _dontDrawOverCameraCosineAngle.Read(reader);
        _pRTInfo.Read(reader);
        _sectionRenderLeaves.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo.Add(new GlobalTagImportInfoBlockBlock());
          ImportInfo[x].Read(reader);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _compressionInfo.Count); x = (x + 1)) {
          CompressionInfo.Add(new GlobalGeometryCompressionInfoBlockBlock());
          CompressionInfo[x].Read(reader);
        }
        for (x = 0; (x < _compressionInfo.Count); x = (x + 1)) {
          CompressionInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new RenderModelRegionBlockBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sections.Count); x = (x + 1)) {
          Sections.Add(new RenderModelSectionBlockBlock());
          Sections[x].Read(reader);
        }
        for (x = 0; (x < _sections.Count); x = (x + 1)) {
          Sections[x].ReadChildData(reader);
        }
        for (x = 0; (x < _invalidSectionPairBits.Count); x = (x + 1)) {
          InvalidSectionPairBits.Add(new RenderModelInvalidSectionPairsBlockBlock());
          InvalidSectionPairBits[x].Read(reader);
        }
        for (x = 0; (x < _invalidSectionPairBits.Count); x = (x + 1)) {
          InvalidSectionPairBits[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sectionGroups.Count); x = (x + 1)) {
          SectionGroups.Add(new RenderModelSectionGroupBlockBlock());
          SectionGroups[x].Read(reader);
        }
        for (x = 0; (x < _sectionGroups.Count); x = (x + 1)) {
          SectionGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new RenderModelNodeBlockBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodeMapOLD.Count); x = (x + 1)) {
          NodeMapOLD.Add(new RenderModelNodeMapBlockOLDBlock());
          NodeMapOLD[x].Read(reader);
        }
        for (x = 0; (x < _nodeMapOLD.Count); x = (x + 1)) {
          NodeMapOLD[x].ReadChildData(reader);
        }
        for (x = 0; (x < _markerGroups.Count); x = (x + 1)) {
          MarkerGroups.Add(new RenderModelMarkerGroupBlockBlock());
          MarkerGroups[x].Read(reader);
        }
        for (x = 0; (x < _markerGroups.Count); x = (x + 1)) {
          MarkerGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new GlobalGeometryMaterialBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new GlobalErrorReportCategoriesBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pRTInfo.Count); x = (x + 1)) {
          PRTInfo.Add(new PrtInfoBlockBlock());
          PRTInfo[x].Read(reader);
        }
        for (x = 0; (x < _pRTInfo.Count); x = (x + 1)) {
          PRTInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sectionRenderLeaves.Count); x = (x + 1)) {
          SectionRenderLeaves.Add(new SectionRenderLeavesBlockBlock());
          SectionRenderLeaves[x].Read(reader);
        }
        for (x = 0; (x < _sectionRenderLeaves.Count); x = (x + 1)) {
          SectionRenderLeaves[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _renderModelFlags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_importInfo.Count = ImportInfo.Count;
        _importInfo.Write(bw);
_compressionInfo.Count = CompressionInfo.Count;
        _compressionInfo.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_sections.Count = Sections.Count;
        _sections.Write(bw);
_invalidSectionPairBits.Count = InvalidSectionPairBits.Count;
        _invalidSectionPairBits.Write(bw);
_sectionGroups.Count = SectionGroups.Count;
        _sectionGroups.Write(bw);
        _l1SectionGroupIndex.Write(bw);
        _l2SectionGroupIndex.Write(bw);
        _l3SectionGroupIndex.Write(bw);
        _l4SectionGroupIndex.Write(bw);
        _l5SectionGroupIndex.Write(bw);
        _l6SectionGroupIndex.Write(bw);
        _unnamed2.Write(bw);
        _nodeListChecksum.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
_nodeMapOLD.Count = NodeMapOLD.Count;
        _nodeMapOLD.Write(bw);
_markerGroups.Count = MarkerGroups.Count;
        _markerGroups.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
        _dontDrawOverCameraCosineAngle.Write(bw);
_pRTInfo.Count = PRTInfo.Count;
        _pRTInfo.Write(bw);
_sectionRenderLeaves.Count = SectionRenderLeaves.Count;
        _sectionRenderLeaves.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].Write(writer);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _compressionInfo.Count); x = (x + 1)) {
          CompressionInfo[x].Write(writer);
        }
        for (x = 0; (x < _compressionInfo.Count); x = (x + 1)) {
          CompressionInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sections.Count); x = (x + 1)) {
          Sections[x].Write(writer);
        }
        for (x = 0; (x < _sections.Count); x = (x + 1)) {
          Sections[x].WriteChildData(writer);
        }
        for (x = 0; (x < _invalidSectionPairBits.Count); x = (x + 1)) {
          InvalidSectionPairBits[x].Write(writer);
        }
        for (x = 0; (x < _invalidSectionPairBits.Count); x = (x + 1)) {
          InvalidSectionPairBits[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sectionGroups.Count); x = (x + 1)) {
          SectionGroups[x].Write(writer);
        }
        for (x = 0; (x < _sectionGroups.Count); x = (x + 1)) {
          SectionGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodeMapOLD.Count); x = (x + 1)) {
          NodeMapOLD[x].Write(writer);
        }
        for (x = 0; (x < _nodeMapOLD.Count); x = (x + 1)) {
          NodeMapOLD[x].WriteChildData(writer);
        }
        for (x = 0; (x < _markerGroups.Count); x = (x + 1)) {
          MarkerGroups[x].Write(writer);
        }
        for (x = 0; (x < _markerGroups.Count); x = (x + 1)) {
          MarkerGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pRTInfo.Count); x = (x + 1)) {
          PRTInfo[x].Write(writer);
        }
        for (x = 0; (x < _pRTInfo.Count); x = (x + 1)) {
          PRTInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sectionRenderLeaves.Count); x = (x + 1)) {
          SectionRenderLeaves[x].Write(writer);
        }
        for (x = 0; (x < _sectionRenderLeaves.Count); x = (x + 1)) {
          SectionRenderLeaves[x].WriteChildData(writer);
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
    public class RenderModelRegionBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortInteger _nodeMapOffsetOLD = new ShortInteger();
      private ShortInteger _nodeMapSizeOLD = new ShortInteger();
      private Block _permutations = new Block();
      public BlockCollection<RenderModelPermutationBlockBlock> _permutationsList = new BlockCollection<RenderModelPermutationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelRegionBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<RenderModelPermutationBlockBlock> Permutations {
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger NodeMapOffsetOLD {
        get {
          return this._nodeMapOffsetOLD;
        }
        set {
          this._nodeMapOffsetOLD = value;
        }
      }
      public ShortInteger NodeMapSizeOLD {
        get {
          return this._nodeMapSizeOLD;
        }
        set {
          this._nodeMapSizeOLD = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeMapOffsetOLD.Read(reader);
        _nodeMapSizeOLD.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new RenderModelPermutationBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeMapOffsetOLD.Write(bw);
        _nodeMapSizeOLD.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class RenderModelPermutationBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortInteger _l1SectionIndex = new ShortInteger();
      private ShortInteger _l2SectionIndex = new ShortInteger();
      private ShortInteger _l3SectionIndex = new ShortInteger();
      private ShortInteger _l4SectionIndex = new ShortInteger();
      private ShortInteger _l5SectionIndex = new ShortInteger();
      private ShortInteger _l6SectionIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public RenderModelPermutationBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger L1SectionIndex {
        get {
          return this._l1SectionIndex;
        }
        set {
          this._l1SectionIndex = value;
        }
      }
      public ShortInteger L2SectionIndex {
        get {
          return this._l2SectionIndex;
        }
        set {
          this._l2SectionIndex = value;
        }
      }
      public ShortInteger L3SectionIndex {
        get {
          return this._l3SectionIndex;
        }
        set {
          this._l3SectionIndex = value;
        }
      }
      public ShortInteger L4SectionIndex {
        get {
          return this._l4SectionIndex;
        }
        set {
          this._l4SectionIndex = value;
        }
      }
      public ShortInteger L5SectionIndex {
        get {
          return this._l5SectionIndex;
        }
        set {
          this._l5SectionIndex = value;
        }
      }
      public ShortInteger L6SectionIndex {
        get {
          return this._l6SectionIndex;
        }
        set {
          this._l6SectionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _l1SectionIndex.Read(reader);
        _l2SectionIndex.Read(reader);
        _l3SectionIndex.Read(reader);
        _l4SectionIndex.Read(reader);
        _l5SectionIndex.Read(reader);
        _l6SectionIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _l1SectionIndex.Write(bw);
        _l2SectionIndex.Write(bw);
        _l3SectionIndex.Write(bw);
        _l4SectionIndex.Write(bw);
        _l5SectionIndex.Write(bw);
        _l6SectionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class RenderModelSectionBlockBlock : IBlock {
      private Enum _globalgeometryclassificationenumdefinition;
      private Pad _unnamed0;
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
      private Block _internalCompressionInfo = new Block();
      private CharInteger _hardwareNodeCount = new CharInteger();
      private CharInteger _nodeMapSize = new CharInteger();
      private ShortInteger _softwarePlaneCount = new ShortInteger();
      private ShortInteger _totalSubpartcont = new ShortInteger();
      private Flags _sectionLightingFlags;
      private ShortBlockIndex _rigidNode = new ShortBlockIndex();
      private Flags _sectionPostprocessFlags;
      private Block _sectionData = new Block();
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> _internalCompressionInfoList = new BlockCollection<GlobalGeometryCompressionInfoBlockBlock>();
      public BlockCollection<RenderModelSectionDataBlockBlock> _sectionDataList = new BlockCollection<RenderModelSectionDataBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelSectionBlockBlock() {
        this._globalgeometryclassificationenumdefinition = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._geometryClassification = new Enum(2);
        this._geometryCompressionFlags = new Flags(2);
        this._sectionLightingFlags = new Flags(2);
        this._sectionPostprocessFlags = new Flags(2);
        this._geometrySelfReference = new Skip(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryCompressionInfoBlockBlock> InternalCompressionInfo {
        get {
          return this._internalCompressionInfoList;
        }
      }
      public BlockCollection<RenderModelSectionDataBlockBlock> SectionData {
        get {
          return this._sectionDataList;
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
for (int x=0; x<InternalCompressionInfo.BlockCount; x++)
{
  IBlock block = InternalCompressionInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SectionData.BlockCount; x++)
{
  IBlock block = SectionData.GetBlock(x);
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
      public Enum Globalgeometryclassificationenumdefinition {
        get {
          return this._globalgeometryclassificationenumdefinition;
        }
        set {
          this._globalgeometryclassificationenumdefinition = value;
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
      public ShortBlockIndex RigidNode {
        get {
          return this._rigidNode;
        }
        set {
          this._rigidNode = value;
        }
      }
      public Flags SectionPostprocessFlags {
        get {
          return this._sectionPostprocessFlags;
        }
        set {
          this._sectionPostprocessFlags = value;
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
        _globalgeometryclassificationenumdefinition.Read(reader);
        _unnamed0.Read(reader);
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
        _internalCompressionInfo.Read(reader);
        _hardwareNodeCount.Read(reader);
        _nodeMapSize.Read(reader);
        _softwarePlaneCount.Read(reader);
        _totalSubpartcont.Read(reader);
        _sectionLightingFlags.Read(reader);
        _rigidNode.Read(reader);
        _sectionPostprocessFlags.Read(reader);
        _sectionData.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _internalCompressionInfo.Count); x = (x + 1)) {
          InternalCompressionInfo.Add(new GlobalGeometryCompressionInfoBlockBlock());
          InternalCompressionInfo[x].Read(reader);
        }
        for (x = 0; (x < _internalCompressionInfo.Count); x = (x + 1)) {
          InternalCompressionInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sectionData.Count); x = (x + 1)) {
          SectionData.Add(new RenderModelSectionDataBlockBlock());
          SectionData[x].Read(reader);
        }
        for (x = 0; (x < _sectionData.Count); x = (x + 1)) {
          SectionData[x].ReadChildData(reader);
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
        _globalgeometryclassificationenumdefinition.Write(bw);
        _unnamed0.Write(bw);
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
_internalCompressionInfo.Count = InternalCompressionInfo.Count;
        _internalCompressionInfo.Write(bw);
        _hardwareNodeCount.Write(bw);
        _nodeMapSize.Write(bw);
        _softwarePlaneCount.Write(bw);
        _totalSubpartcont.Write(bw);
        _sectionLightingFlags.Write(bw);
        _rigidNode.Write(bw);
        _sectionPostprocessFlags.Write(bw);
_sectionData.Count = SectionData.Count;
        _sectionData.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _internalCompressionInfo.Count); x = (x + 1)) {
          InternalCompressionInfo[x].Write(writer);
        }
        for (x = 0; (x < _internalCompressionInfo.Count); x = (x + 1)) {
          InternalCompressionInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sectionData.Count); x = (x + 1)) {
          SectionData[x].Write(writer);
        }
        for (x = 0; (x < _sectionData.Count); x = (x + 1)) {
          SectionData[x].WriteChildData(writer);
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
    public class RenderModelSectionDataBlockBlock : IBlock {
      private Block _parts = new Block();
      private Block _subparts = new Block();
      private Block _visibilityBounds = new Block();
      private Block _rawVertices = new Block();
      private Block _stripIndices = new Block();
      private Data _visibilityMoppCode = new Data();
      private Block _moppReorderTable = new Block();
      private Block _vertexBuffers = new Block();
      private Pad _unnamed0;
      private Block _rawPoints = new Block();
      private Data _runtimePointData = new Data();
      private Block _rigidPointGroups = new Block();
      private Block _vertex_MinusPointIndices = new Block();
      private Block _nodeMap = new Block();
      private Pad _unnamed1;
      public BlockCollection<GlobalGeometryPartBlockNewBlock> _partsList = new BlockCollection<GlobalGeometryPartBlockNewBlock>();
      public BlockCollection<GlobalSubpartsBlockBlock> _subpartsList = new BlockCollection<GlobalSubpartsBlockBlock>();
      public BlockCollection<GlobalVisibilityBoundsBlockBlock> _visibilityBoundsList = new BlockCollection<GlobalVisibilityBoundsBlockBlock>();
      public BlockCollection<GlobalGeometrySectionRawVertexBlockBlock> _rawVerticesList = new BlockCollection<GlobalGeometrySectionRawVertexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _stripIndicesList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionStripIndexBlockBlock> _moppReorderTableList = new BlockCollection<GlobalGeometrySectionStripIndexBlockBlock>();
      public BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock> _vertexBuffersList = new BlockCollection<GlobalGeometrySectionVertexBufferBlockBlock>();
      public BlockCollection<GlobalGeometryRawPointBlockBlock> _rawPointsList = new BlockCollection<GlobalGeometryRawPointBlockBlock>();
      public BlockCollection<GlobalGeometryRigidPointGroupBlockBlock> _rigidPointGroupsList = new BlockCollection<GlobalGeometryRigidPointGroupBlockBlock>();
      public BlockCollection<GlobalGeometryPointDataIndexBlockBlock> _vertex_MinusPointIndicesList = new BlockCollection<GlobalGeometryPointDataIndexBlockBlock>();
      public BlockCollection<RenderModelNodeMapBlockBlock> _nodeMapList = new BlockCollection<RenderModelNodeMapBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelSectionDataBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(4);
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
      public BlockCollection<GlobalGeometryRawPointBlockBlock> RawPoints {
        get {
          return this._rawPointsList;
        }
      }
      public BlockCollection<GlobalGeometryRigidPointGroupBlockBlock> RigidPointGroups {
        get {
          return this._rigidPointGroupsList;
        }
      }
      public BlockCollection<GlobalGeometryPointDataIndexBlockBlock> Vertex_MinusPointIndices {
        get {
          return this._vertex_MinusPointIndicesList;
        }
      }
      public BlockCollection<RenderModelNodeMapBlockBlock> NodeMap {
        get {
          return this._nodeMapList;
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
for (int x=0; x<RawPoints.BlockCount; x++)
{
  IBlock block = RawPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RigidPointGroups.BlockCount; x++)
{
  IBlock block = RigidPointGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertex_MinusPointIndices.BlockCount; x++)
{
  IBlock block = Vertex_MinusPointIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NodeMap.BlockCount; x++)
{
  IBlock block = NodeMap.GetBlock(x);
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
      public Data RuntimePointData {
        get {
          return this._runtimePointData;
        }
        set {
          this._runtimePointData = value;
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
        _rawPoints.Read(reader);
        _runtimePointData.Read(reader);
        _rigidPointGroups.Read(reader);
        _vertex_MinusPointIndices.Read(reader);
        _nodeMap.Read(reader);
        _unnamed1.Read(reader);
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
        for (x = 0; (x < _rawPoints.Count); x = (x + 1)) {
          RawPoints.Add(new GlobalGeometryRawPointBlockBlock());
          RawPoints[x].Read(reader);
        }
        for (x = 0; (x < _rawPoints.Count); x = (x + 1)) {
          RawPoints[x].ReadChildData(reader);
        }
        _runtimePointData.ReadBinary(reader);
        for (x = 0; (x < _rigidPointGroups.Count); x = (x + 1)) {
          RigidPointGroups.Add(new GlobalGeometryRigidPointGroupBlockBlock());
          RigidPointGroups[x].Read(reader);
        }
        for (x = 0; (x < _rigidPointGroups.Count); x = (x + 1)) {
          RigidPointGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertex_MinusPointIndices.Count); x = (x + 1)) {
          Vertex_MinusPointIndices.Add(new GlobalGeometryPointDataIndexBlockBlock());
          Vertex_MinusPointIndices[x].Read(reader);
        }
        for (x = 0; (x < _vertex_MinusPointIndices.Count); x = (x + 1)) {
          Vertex_MinusPointIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap.Add(new RenderModelNodeMapBlockBlock());
          NodeMap[x].Read(reader);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].ReadChildData(reader);
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
_rawPoints.Count = RawPoints.Count;
        _rawPoints.Write(bw);
        _runtimePointData.Write(bw);
_rigidPointGroups.Count = RigidPointGroups.Count;
        _rigidPointGroups.Write(bw);
_vertex_MinusPointIndices.Count = Vertex_MinusPointIndices.Count;
        _vertex_MinusPointIndices.Write(bw);
_nodeMap.Count = NodeMap.Count;
        _nodeMap.Write(bw);
        _unnamed1.Write(bw);
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
        for (x = 0; (x < _rawPoints.Count); x = (x + 1)) {
          RawPoints[x].Write(writer);
        }
        for (x = 0; (x < _rawPoints.Count); x = (x + 1)) {
          RawPoints[x].WriteChildData(writer);
        }
        _runtimePointData.WriteBinary(writer);
        for (x = 0; (x < _rigidPointGroups.Count); x = (x + 1)) {
          RigidPointGroups[x].Write(writer);
        }
        for (x = 0; (x < _rigidPointGroups.Count); x = (x + 1)) {
          RigidPointGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertex_MinusPointIndices.Count); x = (x + 1)) {
          Vertex_MinusPointIndices[x].Write(writer);
        }
        for (x = 0; (x < _vertex_MinusPointIndices.Count); x = (x + 1)) {
          Vertex_MinusPointIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].Write(writer);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].WriteChildData(writer);
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
    public class GlobalGeometryRawPointBlockBlock : IBlock {
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
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryRawPointBlockBlock() {
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
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometryRigidPointGroupBlockBlock : IBlock {
      private CharInteger _rigidNodeIndex = new CharInteger();
      private CharInteger _nodesPoint = new CharInteger();
      private ShortInteger _pointCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryRigidPointGroupBlockBlock() {
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
      public CharInteger RigidNodeIndex {
        get {
          return this._rigidNodeIndex;
        }
        set {
          this._rigidNodeIndex = value;
        }
      }
      public CharInteger NodesPoint {
        get {
          return this._nodesPoint;
        }
        set {
          this._nodesPoint = value;
        }
      }
      public ShortInteger PointCount {
        get {
          return this._pointCount;
        }
        set {
          this._pointCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _rigidNodeIndex.Read(reader);
        _nodesPoint.Read(reader);
        _pointCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _rigidNodeIndex.Write(bw);
        _nodesPoint.Write(bw);
        _pointCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometryPointDataIndexBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryPointDataIndexBlockBlock() {
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
    public class RenderModelNodeMapBlockBlock : IBlock {
      private CharInteger _nodeIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public RenderModelNodeMapBlockBlock() {
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
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeIndex.Write(bw);
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
    public class RenderModelInvalidSectionPairsBlockBlock : IBlock {
      private LongInteger _bits = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public RenderModelInvalidSectionPairsBlockBlock() {
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
      public LongInteger Bits {
        get {
          return this._bits;
        }
        set {
          this._bits = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bits.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bits.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RenderModelSectionGroupBlockBlock : IBlock {
      private Flags _detailLevels;
      private Pad _unnamed0;
      private Block _compoundNodes = new Block();
      public BlockCollection<RenderModelCompoundNodeBlockBlock> _compoundNodesList = new BlockCollection<RenderModelCompoundNodeBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelSectionGroupBlockBlock() {
        this._detailLevels = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<RenderModelCompoundNodeBlockBlock> CompoundNodes {
        get {
          return this._compoundNodesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CompoundNodes.BlockCount; x++)
{
  IBlock block = CompoundNodes.GetBlock(x);
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
      public Flags DetailLevels {
        get {
          return this._detailLevels;
        }
        set {
          this._detailLevels = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _detailLevels.Read(reader);
        _unnamed0.Read(reader);
        _compoundNodes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _compoundNodes.Count); x = (x + 1)) {
          CompoundNodes.Add(new RenderModelCompoundNodeBlockBlock());
          CompoundNodes[x].Read(reader);
        }
        for (x = 0; (x < _compoundNodes.Count); x = (x + 1)) {
          CompoundNodes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _detailLevels.Write(bw);
        _unnamed0.Write(bw);
_compoundNodes.Count = CompoundNodes.Count;
        _compoundNodes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _compoundNodes.Count); x = (x + 1)) {
          CompoundNodes[x].Write(writer);
        }
        for (x = 0; (x < _compoundNodes.Count); x = (x + 1)) {
          CompoundNodes[x].WriteChildData(writer);
        }
      }
    }
    public class RenderModelCompoundNodeBlockBlock : IBlock {
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
public event System.EventHandler BlockNameChanged;
      public RenderModelCompoundNodeBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RenderModelNodeBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _parentNode = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNode = new ShortBlockIndex();
      private ShortBlockIndex _nextSiblingNode = new ShortBlockIndex();
      private ShortInteger _importNodeIndex = new ShortInteger();
      private RealPoint3D _defaultTranslation = new RealPoint3D();
      private RealQuaternion _defaultRotation = new RealQuaternion();
      private RealVector3D _inverseForward = new RealVector3D();
      private RealVector3D _inverseLeft = new RealVector3D();
      private RealVector3D _inverseUp = new RealVector3D();
      private RealPoint3D _inversePosition = new RealPoint3D();
      private Real _inverseScale = new Real();
      private Real _distanceFromParent = new Real();
public event System.EventHandler BlockNameChanged;
      public RenderModelNodeBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex ParentNode {
        get {
          return this._parentNode;
        }
        set {
          this._parentNode = value;
        }
      }
      public ShortBlockIndex FirstChildNode {
        get {
          return this._firstChildNode;
        }
        set {
          this._firstChildNode = value;
        }
      }
      public ShortBlockIndex NextSiblingNode {
        get {
          return this._nextSiblingNode;
        }
        set {
          this._nextSiblingNode = value;
        }
      }
      public ShortInteger ImportNodeIndex {
        get {
          return this._importNodeIndex;
        }
        set {
          this._importNodeIndex = value;
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
      public RealVector3D InverseForward {
        get {
          return this._inverseForward;
        }
        set {
          this._inverseForward = value;
        }
      }
      public RealVector3D InverseLeft {
        get {
          return this._inverseLeft;
        }
        set {
          this._inverseLeft = value;
        }
      }
      public RealVector3D InverseUp {
        get {
          return this._inverseUp;
        }
        set {
          this._inverseUp = value;
        }
      }
      public RealPoint3D InversePosition {
        get {
          return this._inversePosition;
        }
        set {
          this._inversePosition = value;
        }
      }
      public Real InverseScale {
        get {
          return this._inverseScale;
        }
        set {
          this._inverseScale = value;
        }
      }
      public Real DistanceFromParent {
        get {
          return this._distanceFromParent;
        }
        set {
          this._distanceFromParent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parentNode.Read(reader);
        _firstChildNode.Read(reader);
        _nextSiblingNode.Read(reader);
        _importNodeIndex.Read(reader);
        _defaultTranslation.Read(reader);
        _defaultRotation.Read(reader);
        _inverseForward.Read(reader);
        _inverseLeft.Read(reader);
        _inverseUp.Read(reader);
        _inversePosition.Read(reader);
        _inverseScale.Read(reader);
        _distanceFromParent.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _parentNode.Write(bw);
        _firstChildNode.Write(bw);
        _nextSiblingNode.Write(bw);
        _importNodeIndex.Write(bw);
        _defaultTranslation.Write(bw);
        _defaultRotation.Write(bw);
        _inverseForward.Write(bw);
        _inverseLeft.Write(bw);
        _inverseUp.Write(bw);
        _inversePosition.Write(bw);
        _inverseScale.Write(bw);
        _distanceFromParent.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class RenderModelNodeMapBlockOLDBlock : IBlock {
      private CharInteger _nodeIndex = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public RenderModelNodeMapBlockOLDBlock() {
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
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RenderModelMarkerGroupBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _markers = new Block();
      public BlockCollection<RenderModelMarkerBlockBlock> _markersList = new BlockCollection<RenderModelMarkerBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RenderModelMarkerGroupBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<RenderModelMarkerBlockBlock> Markers {
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _markers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new RenderModelMarkerBlockBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].Write(writer);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].WriteChildData(writer);
        }
      }
    }
    public class RenderModelMarkerBlockBlock : IBlock {
      private CharInteger _regionIndex = new CharInteger();
      private CharInteger _permutationIndex = new CharInteger();
      private CharInteger _nodeIndex = new CharInteger();
      private Pad _unnamed0;
      private RealPoint3D _translation = new RealPoint3D();
      private RealQuaternion _rotation = new RealQuaternion();
      private Real _scale = new Real();
public event System.EventHandler BlockNameChanged;
      public RenderModelMarkerBlockBlock() {
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _regionIndex.Read(reader);
        _permutationIndex.Read(reader);
        _nodeIndex.Read(reader);
        _unnamed0.Read(reader);
        _translation.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _regionIndex.Write(bw);
        _permutationIndex.Write(bw);
        _nodeIndex.Write(bw);
        _unnamed0.Write(bw);
        _translation.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
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
    public class PrtInfoBlockBlock : IBlock {
      private ShortInteger _sHOrder = new ShortInteger();
      private ShortInteger _numOfClusters = new ShortInteger();
      private ShortInteger _pcaVectorsPerCluster = new ShortInteger();
      private ShortInteger _numberOfRays = new ShortInteger();
      private ShortInteger _numberOfBounces = new ShortInteger();
      private ShortInteger _matIndexForSbsfcScattering = new ShortInteger();
      private Real _lengthScale = new Real();
      private ShortInteger _numberOfLodsInModel = new ShortInteger();
      private Pad _unnamed0;
      private Block _lodInfo = new Block();
      private Block _clusterBasis = new Block();
      private Block _rawpcadata = new Block();
      private Block _vertexBuffers = new Block();
      private ResourceBlock _resourceData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      public BlockCollection<PrtLodInfoBlockBlock> _lodInfoList = new BlockCollection<PrtLodInfoBlockBlock>();
      public BlockCollection<PrtClusterBasisBlockBlock> _clusterBasisList = new BlockCollection<PrtClusterBasisBlockBlock>();
      public BlockCollection<PrtRawPcaDataBlockBlock> _rawpcadataList = new BlockCollection<PrtRawPcaDataBlockBlock>();
      public BlockCollection<PrtVertexBuffersBlockBlock> _vertexBuffersList = new BlockCollection<PrtVertexBuffersBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PrtInfoBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._geometrySelfReference = new Skip(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
      }
      public BlockCollection<PrtLodInfoBlockBlock> LodInfo {
        get {
          return this._lodInfoList;
        }
      }
      public BlockCollection<PrtClusterBasisBlockBlock> ClusterBasis {
        get {
          return this._clusterBasisList;
        }
      }
      public BlockCollection<PrtRawPcaDataBlockBlock> Rawpcadata {
        get {
          return this._rawpcadataList;
        }
      }
      public BlockCollection<PrtVertexBuffersBlockBlock> VertexBuffers {
        get {
          return this._vertexBuffersList;
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
for (int x=0; x<LodInfo.BlockCount; x++)
{
  IBlock block = LodInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterBasis.BlockCount; x++)
{
  IBlock block = ClusterBasis.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Rawpcadata.BlockCount; x++)
{
  IBlock block = Rawpcadata.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VertexBuffers.BlockCount; x++)
{
  IBlock block = VertexBuffers.GetBlock(x);
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
      public ShortInteger SHOrder {
        get {
          return this._sHOrder;
        }
        set {
          this._sHOrder = value;
        }
      }
      public ShortInteger NumOfClusters {
        get {
          return this._numOfClusters;
        }
        set {
          this._numOfClusters = value;
        }
      }
      public ShortInteger PcaVectorsPerCluster {
        get {
          return this._pcaVectorsPerCluster;
        }
        set {
          this._pcaVectorsPerCluster = value;
        }
      }
      public ShortInteger NumberOfRays {
        get {
          return this._numberOfRays;
        }
        set {
          this._numberOfRays = value;
        }
      }
      public ShortInteger NumberOfBounces {
        get {
          return this._numberOfBounces;
        }
        set {
          this._numberOfBounces = value;
        }
      }
      public ShortInteger MatIndexForSbsfcScattering {
        get {
          return this._matIndexForSbsfcScattering;
        }
        set {
          this._matIndexForSbsfcScattering = value;
        }
      }
      public Real LengthScale {
        get {
          return this._lengthScale;
        }
        set {
          this._lengthScale = value;
        }
      }
      public ShortInteger NumberOfLodsInModel {
        get {
          return this._numberOfLodsInModel;
        }
        set {
          this._numberOfLodsInModel = value;
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
        _sHOrder.Read(reader);
        _numOfClusters.Read(reader);
        _pcaVectorsPerCluster.Read(reader);
        _numberOfRays.Read(reader);
        _numberOfBounces.Read(reader);
        _matIndexForSbsfcScattering.Read(reader);
        _lengthScale.Read(reader);
        _numberOfLodsInModel.Read(reader);
        _unnamed0.Read(reader);
        _lodInfo.Read(reader);
        _clusterBasis.Read(reader);
        _rawpcadata.Read(reader);
        _vertexBuffers.Read(reader);
        _resourceData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _lodInfo.Count); x = (x + 1)) {
          LodInfo.Add(new PrtLodInfoBlockBlock());
          LodInfo[x].Read(reader);
        }
        for (x = 0; (x < _lodInfo.Count); x = (x + 1)) {
          LodInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusterBasis.Count); x = (x + 1)) {
          ClusterBasis.Add(new PrtClusterBasisBlockBlock());
          ClusterBasis[x].Read(reader);
        }
        for (x = 0; (x < _clusterBasis.Count); x = (x + 1)) {
          ClusterBasis[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rawpcadata.Count); x = (x + 1)) {
          Rawpcadata.Add(new PrtRawPcaDataBlockBlock());
          Rawpcadata[x].Read(reader);
        }
        for (x = 0; (x < _rawpcadata.Count); x = (x + 1)) {
          Rawpcadata[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers.Add(new PrtVertexBuffersBlockBlock());
          VertexBuffers[x].Read(reader);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].ReadChildData(reader);
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
        _sHOrder.Write(bw);
        _numOfClusters.Write(bw);
        _pcaVectorsPerCluster.Write(bw);
        _numberOfRays.Write(bw);
        _numberOfBounces.Write(bw);
        _matIndexForSbsfcScattering.Write(bw);
        _lengthScale.Write(bw);
        _numberOfLodsInModel.Write(bw);
        _unnamed0.Write(bw);
_lodInfo.Count = LodInfo.Count;
        _lodInfo.Write(bw);
_clusterBasis.Count = ClusterBasis.Count;
        _clusterBasis.Write(bw);
_rawpcadata.Count = Rawpcadata.Count;
        _rawpcadata.Write(bw);
_vertexBuffers.Count = VertexBuffers.Count;
        _vertexBuffers.Write(bw);
        _resourceData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _lodInfo.Count); x = (x + 1)) {
          LodInfo[x].Write(writer);
        }
        for (x = 0; (x < _lodInfo.Count); x = (x + 1)) {
          LodInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusterBasis.Count); x = (x + 1)) {
          ClusterBasis[x].Write(writer);
        }
        for (x = 0; (x < _clusterBasis.Count); x = (x + 1)) {
          ClusterBasis[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rawpcadata.Count); x = (x + 1)) {
          Rawpcadata[x].Write(writer);
        }
        for (x = 0; (x < _rawpcadata.Count); x = (x + 1)) {
          Rawpcadata[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].Write(writer);
        }
        for (x = 0; (x < _vertexBuffers.Count); x = (x + 1)) {
          VertexBuffers[x].WriteChildData(writer);
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
    public class PrtLodInfoBlockBlock : IBlock {
      private LongInteger _clusterOffset = new LongInteger();
      private Block _sectionInfo = new Block();
      public BlockCollection<PrtSectionInfoBlockBlock> _sectionInfoList = new BlockCollection<PrtSectionInfoBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PrtLodInfoBlockBlock() {
      }
      public BlockCollection<PrtSectionInfoBlockBlock> SectionInfo {
        get {
          return this._sectionInfoList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SectionInfo.BlockCount; x++)
{
  IBlock block = SectionInfo.GetBlock(x);
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
      public LongInteger ClusterOffset {
        get {
          return this._clusterOffset;
        }
        set {
          this._clusterOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _clusterOffset.Read(reader);
        _sectionInfo.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sectionInfo.Count); x = (x + 1)) {
          SectionInfo.Add(new PrtSectionInfoBlockBlock());
          SectionInfo[x].Read(reader);
        }
        for (x = 0; (x < _sectionInfo.Count); x = (x + 1)) {
          SectionInfo[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _clusterOffset.Write(bw);
_sectionInfo.Count = SectionInfo.Count;
        _sectionInfo.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sectionInfo.Count); x = (x + 1)) {
          SectionInfo[x].Write(writer);
        }
        for (x = 0; (x < _sectionInfo.Count); x = (x + 1)) {
          SectionInfo[x].WriteChildData(writer);
        }
      }
    }
    public class PrtSectionInfoBlockBlock : IBlock {
      private LongInteger _sectionIndex = new LongInteger();
      private LongInteger _pcaDataOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PrtSectionInfoBlockBlock() {
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
      public LongInteger SectionIndex {
        get {
          return this._sectionIndex;
        }
        set {
          this._sectionIndex = value;
        }
      }
      public LongInteger PcaDataOffset {
        get {
          return this._pcaDataOffset;
        }
        set {
          this._pcaDataOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectionIndex.Read(reader);
        _pcaDataOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _sectionIndex.Write(bw);
        _pcaDataOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PrtClusterBasisBlockBlock : IBlock {
      private Real _basisData = new Real();
public event System.EventHandler BlockNameChanged;
      public PrtClusterBasisBlockBlock() {
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
      public Real BasisData {
        get {
          return this._basisData;
        }
        set {
          this._basisData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _basisData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _basisData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PrtRawPcaDataBlockBlock : IBlock {
      private Real _rawPcaData = new Real();
public event System.EventHandler BlockNameChanged;
      public PrtRawPcaDataBlockBlock() {
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
      public Real RawPcaData {
        get {
          return this._rawPcaData;
        }
        set {
          this._rawPcaData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _rawPcaData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _rawPcaData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PrtVertexBuffersBlockBlock : IBlock {
      private Skip _vertexBuffer;
public event System.EventHandler BlockNameChanged;
      public PrtVertexBuffersBlockBlock() {
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
    public class SectionRenderLeavesBlockBlock : IBlock {
      private Block _nodeRenderLeaves = new Block();
      public BlockCollection<NodeRenderLeavesBlockBlock> _nodeRenderLeavesList = new BlockCollection<NodeRenderLeavesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SectionRenderLeavesBlockBlock() {
      }
      public BlockCollection<NodeRenderLeavesBlockBlock> NodeRenderLeaves {
        get {
          return this._nodeRenderLeavesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<NodeRenderLeaves.BlockCount; x++)
{
  IBlock block = NodeRenderLeaves.GetBlock(x);
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
        _nodeRenderLeaves.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _nodeRenderLeaves.Count); x = (x + 1)) {
          NodeRenderLeaves.Add(new NodeRenderLeavesBlockBlock());
          NodeRenderLeaves[x].Read(reader);
        }
        for (x = 0; (x < _nodeRenderLeaves.Count); x = (x + 1)) {
          NodeRenderLeaves[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_nodeRenderLeaves.Count = NodeRenderLeaves.Count;
        _nodeRenderLeaves.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _nodeRenderLeaves.Count); x = (x + 1)) {
          NodeRenderLeaves[x].Write(writer);
        }
        for (x = 0; (x < _nodeRenderLeaves.Count); x = (x + 1)) {
          NodeRenderLeaves[x].WriteChildData(writer);
        }
      }
    }
    public class NodeRenderLeavesBlockBlock : IBlock {
      private Block _collisionLeaves = new Block();
      private Block _surfaceReferences = new Block();
      public BlockCollection<BspLeafBlockBlock> _collisionLeavesList = new BlockCollection<BspLeafBlockBlock>();
      public BlockCollection<BspSurfaceReferenceBlockBlock> _surfaceReferencesList = new BlockCollection<BspSurfaceReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public NodeRenderLeavesBlockBlock() {
      }
      public BlockCollection<BspLeafBlockBlock> CollisionLeaves {
        get {
          return this._collisionLeavesList;
        }
      }
      public BlockCollection<BspSurfaceReferenceBlockBlock> SurfaceReferences {
        get {
          return this._surfaceReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CollisionLeaves.BlockCount; x++)
{
  IBlock block = CollisionLeaves.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _collisionLeaves.Read(reader);
        _surfaceReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _collisionLeaves.Count); x = (x + 1)) {
          CollisionLeaves.Add(new BspLeafBlockBlock());
          CollisionLeaves[x].Read(reader);
        }
        for (x = 0; (x < _collisionLeaves.Count); x = (x + 1)) {
          CollisionLeaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences.Add(new BspSurfaceReferenceBlockBlock());
          SurfaceReferences[x].Read(reader);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_collisionLeaves.Count = CollisionLeaves.Count;
        _collisionLeaves.Write(bw);
_surfaceReferences.Count = SurfaceReferences.Count;
        _surfaceReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _collisionLeaves.Count); x = (x + 1)) {
          CollisionLeaves[x].Write(writer);
        }
        for (x = 0; (x < _collisionLeaves.Count); x = (x + 1)) {
          CollisionLeaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].Write(writer);
        }
        for (x = 0; (x < _surfaceReferences.Count); x = (x + 1)) {
          SurfaceReferences[x].WriteChildData(writer);
        }
      }
    }
    public class BspLeafBlockBlock : IBlock {
      private ShortInteger _cluster = new ShortInteger();
      private ShortInteger _surfaceReferenceCount = new ShortInteger();
      private LongInteger _firstSurfaceReferenceIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public BspLeafBlockBlock() {
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
    public class BspSurfaceReferenceBlockBlock : IBlock {
      private ShortInteger _stripIndex = new ShortInteger();
      private ShortInteger _lightmapTriangleIndex = new ShortInteger();
      private LongInteger _bspNodeIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public BspSurfaceReferenceBlockBlock() {
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
      public LongInteger BspNodeIndex {
        get {
          return this._bspNodeIndex;
        }
        set {
          this._bspNodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stripIndex.Read(reader);
        _lightmapTriangleIndex.Read(reader);
        _bspNodeIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stripIndex.Write(bw);
        _lightmapTriangleIndex.Write(bw);
        _bspNodeIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
