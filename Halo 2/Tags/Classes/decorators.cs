// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'decorators'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class decorators : Interfaces.Pool.Tag {
    private DecoratorsBlockBlock decoratorsValues = new DecoratorsBlockBlock();
    public virtual DecoratorsBlockBlock DecoratorsValues {
      get {
        return decoratorsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DecoratorsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "decorators";
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
decoratorsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
decoratorsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
decoratorsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
decoratorsValues.WriteChildData(writer);
    }
    #endregion
    public class DecoratorsBlockBlock : IBlock {
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
      public DecoratorsBlockBlock() {
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
      private Block _cacheBlockData = new Block();
      private Pad _unnamed2;
      private Pad _unnamed3;
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<DecoratorCacheBlockDataBlockBlock> _cacheBlockDataList = new BlockCollection<DecoratorCacheBlockDataBlockBlock>();
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
      public BlockCollection<DecoratorCacheBlockDataBlockBlock> CacheBlockData {
        get {
          return this._cacheBlockDataList;
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
for (int x=0; x<CacheBlockData.BlockCount; x++)
{
  IBlock block = CacheBlockData.GetBlock(x);
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
        _cacheBlockData.Read(reader);
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
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData.Add(new DecoratorCacheBlockDataBlockBlock());
          CacheBlockData[x].Read(reader);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].ReadChildData(reader);
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
_cacheBlockData.Count = CacheBlockData.Count;
        _cacheBlockData.Write(bw);
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
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].Write(writer);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].WriteChildData(writer);
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
    public class DecoratorCacheBlockDataBlockBlock : IBlock {
      private Block _placements = new Block();
      private Block _decalVertices = new Block();
      private Block _decalIndices = new Block();
      private Skip _decalVertexBuffer;
      private Pad _unnamed0;
      private Block _spriteVertices = new Block();
      private Block _spriteIndices = new Block();
      private Skip _spriteVertexBuffer;
      private Pad _unnamed1;
      public BlockCollection<DecoratorPlacementBlockBlock> _placementsList = new BlockCollection<DecoratorPlacementBlockBlock>();
      public BlockCollection<DecalVerticesBlockBlock> _decalVerticesList = new BlockCollection<DecalVerticesBlockBlock>();
      public BlockCollection<IndicesBlockBlock> _decalIndicesList = new BlockCollection<IndicesBlockBlock>();
      public BlockCollection<SpriteVerticesBlockBlock> _spriteVerticesList = new BlockCollection<SpriteVerticesBlockBlock>();
      public BlockCollection<IndicesBlockBlock> _spriteIndicesList = new BlockCollection<IndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorCacheBlockDataBlockBlock() {
        this._decalVertexBuffer = new Skip(32);
        this._unnamed0 = new Pad(16);
        this._spriteVertexBuffer = new Skip(32);
        this._unnamed1 = new Pad(16);
      }
      public BlockCollection<DecoratorPlacementBlockBlock> Placements {
        get {
          return this._placementsList;
        }
      }
      public BlockCollection<DecalVerticesBlockBlock> DecalVertices {
        get {
          return this._decalVerticesList;
        }
      }
      public BlockCollection<IndicesBlockBlock> DecalIndices {
        get {
          return this._decalIndicesList;
        }
      }
      public BlockCollection<SpriteVerticesBlockBlock> SpriteVertices {
        get {
          return this._spriteVerticesList;
        }
      }
      public BlockCollection<IndicesBlockBlock> SpriteIndices {
        get {
          return this._spriteIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Placements.BlockCount; x++)
{
  IBlock block = Placements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalVertices.BlockCount; x++)
{
  IBlock block = DecalVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalIndices.BlockCount; x++)
{
  IBlock block = DecalIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpriteVertices.BlockCount; x++)
{
  IBlock block = SpriteVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpriteIndices.BlockCount; x++)
{
  IBlock block = SpriteIndices.GetBlock(x);
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
        _placements.Read(reader);
        _decalVertices.Read(reader);
        _decalIndices.Read(reader);
        _decalVertexBuffer.Read(reader);
        _unnamed0.Read(reader);
        _spriteVertices.Read(reader);
        _spriteIndices.Read(reader);
        _spriteVertexBuffer.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements.Add(new DecoratorPlacementBlockBlock());
          Placements[x].Read(reader);
        }
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices.Add(new DecalVerticesBlockBlock());
          DecalVertices[x].Read(reader);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices.Add(new IndicesBlockBlock());
          DecalIndices[x].Read(reader);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices.Add(new SpriteVerticesBlockBlock());
          SpriteVertices[x].Read(reader);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices.Add(new IndicesBlockBlock());
          SpriteIndices[x].Read(reader);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_placements.Count = Placements.Count;
        _placements.Write(bw);
_decalVertices.Count = DecalVertices.Count;
        _decalVertices.Write(bw);
_decalIndices.Count = DecalIndices.Count;
        _decalIndices.Write(bw);
        _decalVertexBuffer.Write(bw);
        _unnamed0.Write(bw);
_spriteVertices.Count = SpriteVertices.Count;
        _spriteVertices.Write(bw);
_spriteIndices.Count = SpriteIndices.Count;
        _spriteIndices.Write(bw);
        _spriteVertexBuffer.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].Write(writer);
        }
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].Write(writer);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].Write(writer);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].Write(writer);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].Write(writer);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].WriteChildData(writer);
        }
      }
    }
    public class DecoratorPlacementBlockBlock : IBlock {
      private LongInteger _internalData1 = new LongInteger();
      private LongInteger _compressedPosition = new LongInteger();
      private RGBColor _tintColor = new RGBColor();
      private RGBColor _lightmapColor = new RGBColor();
      private LongInteger _compressedLightDirection = new LongInteger();
      private LongInteger _compressedLight2Direction = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorPlacementBlockBlock() {
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
      public LongInteger InternalData1 {
        get {
          return this._internalData1;
        }
        set {
          this._internalData1 = value;
        }
      }
      public LongInteger CompressedPosition {
        get {
          return this._compressedPosition;
        }
        set {
          this._compressedPosition = value;
        }
      }
      public RGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
        }
      }
      public RGBColor LightmapColor {
        get {
          return this._lightmapColor;
        }
        set {
          this._lightmapColor = value;
        }
      }
      public LongInteger CompressedLightDirection {
        get {
          return this._compressedLightDirection;
        }
        set {
          this._compressedLightDirection = value;
        }
      }
      public LongInteger CompressedLight2Direction {
        get {
          return this._compressedLight2Direction;
        }
        set {
          this._compressedLight2Direction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _internalData1.Read(reader);
        _compressedPosition.Read(reader);
        _tintColor.Read(reader);
        _lightmapColor.Read(reader);
        _compressedLightDirection.Read(reader);
        _compressedLight2Direction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _internalData1.Write(bw);
        _compressedPosition.Write(bw);
        _tintColor.Write(bw);
        _lightmapColor.Write(bw);
        _compressedLightDirection.Write(bw);
        _compressedLight2Direction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecalVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealPoint2D _texcoord0 = new RealPoint2D();
      private RealPoint2D _texcoord1 = new RealPoint2D();
      private RGBColor _color = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public DecalVerticesBlockBlock() {
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
      public RealPoint2D Texcoord0 {
        get {
          return this._texcoord0;
        }
        set {
          this._texcoord0 = value;
        }
      }
      public RealPoint2D Texcoord1 {
        get {
          return this._texcoord1;
        }
        set {
          this._texcoord1 = value;
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
        _position.Read(reader);
        _texcoord0.Read(reader);
        _texcoord1.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _texcoord0.Write(bw);
        _texcoord1.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class IndicesBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public IndicesBlockBlock() {
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
    public class SpriteVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _offset = new RealVector3D();
      private RealVector3D _axis = new RealVector3D();
      private RealPoint2D _texcoord = new RealPoint2D();
      private RGBColor _color = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public SpriteVerticesBlockBlock() {
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
      public RealVector3D Offset {
        get {
          return this._offset;
        }
        set {
          this._offset = value;
        }
      }
      public RealVector3D Axis {
        get {
          return this._axis;
        }
        set {
          this._axis = value;
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
      public RGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _offset.Read(reader);
        _axis.Read(reader);
        _texcoord.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _offset.Write(bw);
        _axis.Write(bw);
        _texcoord.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
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
