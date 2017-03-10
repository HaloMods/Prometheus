// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'collision_model'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class collision_model : Interfaces.Pool.Tag {
    private CollisionModelBlockBlock collisionModelValues = new CollisionModelBlockBlock();
    public virtual CollisionModelBlockBlock CollisionModelValues {
      get {
        return collisionModelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(CollisionModelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "collision_model";
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
collisionModelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
collisionModelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
collisionModelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
collisionModelValues.WriteChildData(writer);
    }
    #endregion
    public class CollisionModelBlockBlock : IBlock {
      private Block _importInfo = new Block();
      private Block _errors = new Block();
      private Flags _flags;
      private Block _materials = new Block();
      private Block _regions = new Block();
      private Block _pathfindingSpheres = new Block();
      private Block _nodes = new Block();
      public BlockCollection<GlobalTagImportInfoBlockBlock> _importInfoList = new BlockCollection<GlobalTagImportInfoBlockBlock>();
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> _errorsList = new BlockCollection<GlobalErrorReportCategoriesBlockBlock>();
      public BlockCollection<CollisionModelMaterialBlockBlock> _materialsList = new BlockCollection<CollisionModelMaterialBlockBlock>();
      public BlockCollection<CollisionModelRegionBlockBlock> _regionsList = new BlockCollection<CollisionModelRegionBlockBlock>();
      public BlockCollection<CollisionModelPathfindingSphereBlockBlock> _pathfindingSpheresList = new BlockCollection<CollisionModelPathfindingSphereBlockBlock>();
      public BlockCollection<CollisionModelNodeBlockBlock> _nodesList = new BlockCollection<CollisionModelNodeBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CollisionModelBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<GlobalTagImportInfoBlockBlock> ImportInfo {
        get {
          return this._importInfoList;
        }
      }
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public BlockCollection<CollisionModelMaterialBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<CollisionModelRegionBlockBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<CollisionModelPathfindingSphereBlockBlock> PathfindingSpheres {
        get {
          return this._pathfindingSpheresList;
        }
      }
      public BlockCollection<CollisionModelNodeBlockBlock> Nodes {
        get {
          return this._nodesList;
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
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingSpheres.BlockCount; x++)
{
  IBlock block = PathfindingSpheres.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _importInfo.Read(reader);
        _errors.Read(reader);
        _flags.Read(reader);
        _materials.Read(reader);
        _regions.Read(reader);
        _pathfindingSpheres.Read(reader);
        _nodes.Read(reader);
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
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new GlobalErrorReportCategoriesBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new CollisionModelMaterialBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new CollisionModelRegionBlockBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres.Add(new CollisionModelPathfindingSphereBlockBlock());
          PathfindingSpheres[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new CollisionModelNodeBlockBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_importInfo.Count = ImportInfo.Count;
        _importInfo.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
        _flags.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_pathfindingSpheres.Count = PathfindingSpheres.Count;
        _pathfindingSpheres.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].Write(writer);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
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
    public class CollisionModelMaterialBlockBlock : IBlock {
      private StringId _name = new StringId();
public event System.EventHandler BlockNameChanged;
      public CollisionModelMaterialBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class CollisionModelRegionBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _permutations = new Block();
      public BlockCollection<CollisionModelPermutationBlockBlock> _permutationsList = new BlockCollection<CollisionModelPermutationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CollisionModelRegionBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<CollisionModelPermutationBlockBlock> Permutations {
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new CollisionModelPermutationBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
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
    public class CollisionModelPermutationBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _bsps = new Block();
      private Block _bspphysics = new Block();
      public BlockCollection<CollisionModelBspBlockBlock> _bspsList = new BlockCollection<CollisionModelBspBlockBlock>();
      public BlockCollection<CollisionBspPhysicsBlockBlock> _bspphysicsList = new BlockCollection<CollisionBspPhysicsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CollisionModelPermutationBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<CollisionModelBspBlockBlock> Bsps {
        get {
          return this._bspsList;
        }
      }
      public BlockCollection<CollisionBspPhysicsBlockBlock> Bspphysics {
        get {
          return this._bspphysicsList;
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
for (int x=0; x<Bspphysics.BlockCount; x++)
{
  IBlock block = Bspphysics.GetBlock(x);
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
        _bsps.Read(reader);
        _bspphysics.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps.Add(new CollisionModelBspBlockBlock());
          Bsps[x].Read(reader);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics.Add(new CollisionBspPhysicsBlockBlock());
          Bspphysics[x].Read(reader);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_bsps.Count = Bsps.Count;
        _bsps.Write(bw);
_bspphysics.Count = Bspphysics.Count;
        _bspphysics.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].Write(writer);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].Write(writer);
        }
        for (x = 0; (x < _bspphysics.Count); x = (x + 1)) {
          Bspphysics[x].WriteChildData(writer);
        }
      }
    }
    public class CollisionModelBspBlockBlock : IBlock {
      private ShortInteger _nodeIndex = new ShortInteger();
      private Pad _unnamed0;
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
      public CollisionModelBspBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeIndex.Read(reader);
        _unnamed0.Read(reader);
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
        _nodeIndex.Write(bw);
        _unnamed0.Write(bw);
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
        this._unnamed11 = new Pad(4);
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
    public class CollisionModelPathfindingSphereBlockBlock : IBlock {
      private ShortBlockIndex _node = new ShortBlockIndex();
      private Flags _flags;
      private RealPoint3D _center = new RealPoint3D();
      private Real _radius = new Real();
public event System.EventHandler BlockNameChanged;
      public CollisionModelPathfindingSphereBlockBlock() {
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
      public ShortBlockIndex Node {
        get {
          return this._node;
        }
        set {
          this._node = value;
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
      public RealPoint3D Center {
        get {
          return this._center;
        }
        set {
          this._center = value;
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
      public virtual void Read(BinaryReader reader) {
        _node.Read(reader);
        _flags.Read(reader);
        _center.Read(reader);
        _radius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _node.Write(bw);
        _flags.Write(bw);
        _center.Write(bw);
        _radius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CollisionModelNodeBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Pad _unnamed0;
      private ShortBlockIndex _parentNode = new ShortBlockIndex();
      private ShortBlockIndex _nextSiblingNode = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNode = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public CollisionModelNodeBlockBlock() {
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
      public ShortBlockIndex NextSiblingNode {
        get {
          return this._nextSiblingNode;
        }
        set {
          this._nextSiblingNode = value;
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed0.Read(reader);
        _parentNode.Read(reader);
        _nextSiblingNode.Read(reader);
        _firstChildNode.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
        _parentNode.Write(bw);
        _nextSiblingNode.Write(bw);
        _firstChildNode.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
  }
}
