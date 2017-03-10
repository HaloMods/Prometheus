// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'cloth'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class cloth : Interfaces.Pool.Tag {
    private ClothPropertiesBlockBlock clothValues = new ClothPropertiesBlockBlock();
    public virtual ClothPropertiesBlockBlock ClothValues {
      get {
        return clothValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ClothValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "cloth";
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
clothValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
clothValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
clothValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
clothValues.WriteChildData(writer);
    }
    #endregion
    public class ClothPropertiesBlockBlock : IBlock {
      private Flags _flags;
      private StringId _markerAttachmentName = new StringId();
      private TagReference _shader = new TagReference();
      private ShortInteger _gridXDimension = new ShortInteger();
      private ShortInteger _gridYDimension = new ShortInteger();
      private Real _gridSpacingX = new Real();
      private Real _gridSpacingY = new Real();
      private Enum _integrationType;
      private ShortInteger _numberIterations = new ShortInteger();
      private Real _weight = new Real();
      private Real _drag = new Real();
      private Real _windscale = new Real();
      private Real _windflappinessscale = new Real();
      private Real _longestrod = new Real();
      private Pad _unnamed0;
      private Block _vertices = new Block();
      private Block _indices = new Block();
      private Block _stripIndices = new Block();
      private Block _links = new Block();
      public BlockCollection<ClothVerticesBlockBlock> _verticesList = new BlockCollection<ClothVerticesBlockBlock>();
      public BlockCollection<ClothIndicesBlockBlock> _indicesList = new BlockCollection<ClothIndicesBlockBlock>();
      public BlockCollection<ClothIndicesBlockBlock> _stripIndicesList = new BlockCollection<ClothIndicesBlockBlock>();
      public BlockCollection<ClothLinksBlockBlock> _linksList = new BlockCollection<ClothLinksBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ClothPropertiesBlockBlock() {
        this._flags = new Flags(4);
        this._integrationType = new Enum(2);
        this._unnamed0 = new Pad(24);
      }
      public BlockCollection<ClothVerticesBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<ClothIndicesBlockBlock> Indices {
        get {
          return this._indicesList;
        }
      }
      public BlockCollection<ClothIndicesBlockBlock> StripIndices {
        get {
          return this._stripIndicesList;
        }
      }
      public BlockCollection<ClothLinksBlockBlock> Links {
        get {
          return this._linksList;
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
for (int x=0; x<Indices.BlockCount; x++)
{
  IBlock block = Indices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StripIndices.BlockCount; x++)
{
  IBlock block = StripIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Links.BlockCount; x++)
{
  IBlock block = Links.GetBlock(x);
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
      public StringId MarkerAttachmentName {
        get {
          return this._markerAttachmentName;
        }
        set {
          this._markerAttachmentName = value;
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
      public ShortInteger GridXDimension {
        get {
          return this._gridXDimension;
        }
        set {
          this._gridXDimension = value;
        }
      }
      public ShortInteger GridYDimension {
        get {
          return this._gridYDimension;
        }
        set {
          this._gridYDimension = value;
        }
      }
      public Real GridSpacingX {
        get {
          return this._gridSpacingX;
        }
        set {
          this._gridSpacingX = value;
        }
      }
      public Real GridSpacingY {
        get {
          return this._gridSpacingY;
        }
        set {
          this._gridSpacingY = value;
        }
      }
      public Enum IntegrationType {
        get {
          return this._integrationType;
        }
        set {
          this._integrationType = value;
        }
      }
      public ShortInteger NumberIterations {
        get {
          return this._numberIterations;
        }
        set {
          this._numberIterations = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real Drag {
        get {
          return this._drag;
        }
        set {
          this._drag = value;
        }
      }
      public Real Windscale {
        get {
          return this._windscale;
        }
        set {
          this._windscale = value;
        }
      }
      public Real Windflappinessscale {
        get {
          return this._windflappinessscale;
        }
        set {
          this._windflappinessscale = value;
        }
      }
      public Real Longestrod {
        get {
          return this._longestrod;
        }
        set {
          this._longestrod = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _markerAttachmentName.Read(reader);
        _shader.Read(reader);
        _gridXDimension.Read(reader);
        _gridYDimension.Read(reader);
        _gridSpacingX.Read(reader);
        _gridSpacingY.Read(reader);
        _integrationType.Read(reader);
        _numberIterations.Read(reader);
        _weight.Read(reader);
        _drag.Read(reader);
        _windscale.Read(reader);
        _windflappinessscale.Read(reader);
        _longestrod.Read(reader);
        _unnamed0.Read(reader);
        _vertices.Read(reader);
        _indices.Read(reader);
        _stripIndices.Read(reader);
        _links.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _markerAttachmentName.ReadString(reader);
        _shader.ReadString(reader);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new ClothVerticesBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices.Add(new ClothIndicesBlockBlock());
          Indices[x].Read(reader);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices.Add(new ClothIndicesBlockBlock());
          StripIndices[x].Read(reader);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links.Add(new ClothLinksBlockBlock());
          Links[x].Read(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _markerAttachmentName.Write(bw);
        _shader.Write(bw);
        _gridXDimension.Write(bw);
        _gridYDimension.Write(bw);
        _gridSpacingX.Write(bw);
        _gridSpacingY.Write(bw);
        _integrationType.Write(bw);
        _numberIterations.Write(bw);
        _weight.Write(bw);
        _drag.Write(bw);
        _windscale.Write(bw);
        _windflappinessscale.Write(bw);
        _longestrod.Write(bw);
        _unnamed0.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_indices.Count = Indices.Count;
        _indices.Write(bw);
_stripIndices.Count = StripIndices.Count;
        _stripIndices.Write(bw);
_links.Count = Links.Count;
        _links.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _markerAttachmentName.WriteString(writer);
        _shader.WriteString(writer);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].Write(writer);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].Write(writer);
        }
        for (x = 0; (x < _stripIndices.Count); x = (x + 1)) {
          StripIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].Write(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].WriteChildData(writer);
        }
      }
    }
    public class ClothVerticesBlockBlock : IBlock {
      private RealPoint3D _initialPosition = new RealPoint3D();
      private RealVector2D _uv = new RealVector2D();
public event System.EventHandler BlockNameChanged;
      public ClothVerticesBlockBlock() {
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
      public RealPoint3D InitialPosition {
        get {
          return this._initialPosition;
        }
        set {
          this._initialPosition = value;
        }
      }
      public RealVector2D Uv {
        get {
          return this._uv;
        }
        set {
          this._uv = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _initialPosition.Read(reader);
        _uv.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _initialPosition.Write(bw);
        _uv.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ClothIndicesBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ClothIndicesBlockBlock() {
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
    public class ClothLinksBlockBlock : IBlock {
      private LongInteger _attachmentBits = new LongInteger();
      private ShortInteger _index1 = new ShortInteger();
      private ShortInteger _index2 = new ShortInteger();
      private Real _defaultdistance = new Real();
      private Real _dampingmultiplier = new Real();
public event System.EventHandler BlockNameChanged;
      public ClothLinksBlockBlock() {
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
      public LongInteger AttachmentBits {
        get {
          return this._attachmentBits;
        }
        set {
          this._attachmentBits = value;
        }
      }
      public ShortInteger Index1 {
        get {
          return this._index1;
        }
        set {
          this._index1 = value;
        }
      }
      public ShortInteger Index2 {
        get {
          return this._index2;
        }
        set {
          this._index2 = value;
        }
      }
      public Real Defaultdistance {
        get {
          return this._defaultdistance;
        }
        set {
          this._defaultdistance = value;
        }
      }
      public Real Dampingmultiplier {
        get {
          return this._dampingmultiplier;
        }
        set {
          this._dampingmultiplier = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _attachmentBits.Read(reader);
        _index1.Read(reader);
        _index2.Read(reader);
        _defaultdistance.Read(reader);
        _dampingmultiplier.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _attachmentBits.Write(bw);
        _index1.Write(bw);
        _index2.Write(bw);
        _defaultdistance.Write(bw);
        _dampingmultiplier.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
