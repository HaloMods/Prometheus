// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'decorator_set'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class decorator_set : Interfaces.Pool.Tag {
    private GlobalGeometryBlockInfoStructBlockBlock decoratorSetValues = new GlobalGeometryBlockInfoStructBlockBlock();
    public virtual GlobalGeometryBlockInfoStructBlockBlock DecoratorSetValues {
      get {
        return decoratorSetValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DecoratorSetValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "decorator_set";
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
decoratorSetValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
decoratorSetValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
decoratorSetValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
decoratorSetValues.WriteChildData(writer);
    }
    #endregion
    public class GlobalGeometryBlockInfoStructBlockBlock : IBlock {
      private Block _shaders = new Block();
      private Real _lightingMinScale = new Real();
      private Real _lightingMaxScale = new Real();
      private Block _classes = new Block();
      private Block _models = new Block();
      private Block _rawVertices = new Block();
      private Block _indices = new Block();
      private Block _cachedData = new Block();
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
      public BlockCollection<DecoratorShaderReferenceBlockBlock> _shadersList = new BlockCollection<DecoratorShaderReferenceBlockBlock>();
      public BlockCollection<DecoratorClassesBlockBlock> _classesList = new BlockCollection<DecoratorClassesBlockBlock>();
      public BlockCollection<DecoratorModelsBlockBlock> _modelsList = new BlockCollection<DecoratorModelsBlockBlock>();
      public BlockCollection<DecoratorModelVerticesBlockBlock> _rawVerticesList = new BlockCollection<DecoratorModelVerticesBlockBlock>();
      public BlockCollection<DecoratorModelIndicesBlockBlock> _indicesList = new BlockCollection<DecoratorModelIndicesBlockBlock>();
      public BlockCollection<CachedDataBlockBlock> _cachedDataList = new BlockCollection<CachedDataBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryBlockInfoStructBlockBlock() {
        this._geometrySelfReference = new Skip(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(4);
      }
      public BlockCollection<DecoratorShaderReferenceBlockBlock> Shaders {
        get {
          return this._shadersList;
        }
      }
      public BlockCollection<DecoratorClassesBlockBlock> Classes {
        get {
          return this._classesList;
        }
      }
      public BlockCollection<DecoratorModelsBlockBlock> Models {
        get {
          return this._modelsList;
        }
      }
      public BlockCollection<DecoratorModelVerticesBlockBlock> RawVertices {
        get {
          return this._rawVerticesList;
        }
      }
      public BlockCollection<DecoratorModelIndicesBlockBlock> Indices {
        get {
          return this._indicesList;
        }
      }
      public BlockCollection<CachedDataBlockBlock> CachedData {
        get {
          return this._cachedDataList;
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
for (int x=0; x<Shaders.BlockCount; x++)
{
  IBlock block = Shaders.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Classes.BlockCount; x++)
{
  IBlock block = Classes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Models.BlockCount; x++)
{
  IBlock block = Models.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RawVertices.BlockCount; x++)
{
  IBlock block = RawVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Indices.BlockCount; x++)
{
  IBlock block = Indices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CachedData.BlockCount; x++)
{
  IBlock block = CachedData.GetBlock(x);
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
      public Real LightingMinScale {
        get {
          return this._lightingMinScale;
        }
        set {
          this._lightingMinScale = value;
        }
      }
      public Real LightingMaxScale {
        get {
          return this._lightingMaxScale;
        }
        set {
          this._lightingMaxScale = value;
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
        _shaders.Read(reader);
        _lightingMinScale.Read(reader);
        _lightingMaxScale.Read(reader);
        _classes.Read(reader);
        _models.Read(reader);
        _rawVertices.Read(reader);
        _indices.Read(reader);
        _cachedData.Read(reader);
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
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders.Add(new DecoratorShaderReferenceBlockBlock());
          Shaders[x].Read(reader);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].ReadChildData(reader);
        }
        for (x = 0; (x < _classes.Count); x = (x + 1)) {
          Classes.Add(new DecoratorClassesBlockBlock());
          Classes[x].Read(reader);
        }
        for (x = 0; (x < _classes.Count); x = (x + 1)) {
          Classes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _models.Count); x = (x + 1)) {
          Models.Add(new DecoratorModelsBlockBlock());
          Models[x].Read(reader);
        }
        for (x = 0; (x < _models.Count); x = (x + 1)) {
          Models[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices.Add(new DecoratorModelVerticesBlockBlock());
          RawVertices[x].Read(reader);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices.Add(new DecoratorModelIndicesBlockBlock());
          Indices[x].Read(reader);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cachedData.Count); x = (x + 1)) {
          CachedData.Add(new CachedDataBlockBlock());
          CachedData[x].Read(reader);
        }
        for (x = 0; (x < _cachedData.Count); x = (x + 1)) {
          CachedData[x].ReadChildData(reader);
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
_shaders.Count = Shaders.Count;
        _shaders.Write(bw);
        _lightingMinScale.Write(bw);
        _lightingMaxScale.Write(bw);
_classes.Count = Classes.Count;
        _classes.Write(bw);
_models.Count = Models.Count;
        _models.Write(bw);
_rawVertices.Count = RawVertices.Count;
        _rawVertices.Write(bw);
_indices.Count = Indices.Count;
        _indices.Write(bw);
_cachedData.Count = CachedData.Count;
        _cachedData.Write(bw);
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
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].Write(writer);
        }
        for (x = 0; (x < _shaders.Count); x = (x + 1)) {
          Shaders[x].WriteChildData(writer);
        }
        for (x = 0; (x < _classes.Count); x = (x + 1)) {
          Classes[x].Write(writer);
        }
        for (x = 0; (x < _classes.Count); x = (x + 1)) {
          Classes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _models.Count); x = (x + 1)) {
          Models[x].Write(writer);
        }
        for (x = 0; (x < _models.Count); x = (x + 1)) {
          Models[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].Write(writer);
        }
        for (x = 0; (x < _rawVertices.Count); x = (x + 1)) {
          RawVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].Write(writer);
        }
        for (x = 0; (x < _indices.Count); x = (x + 1)) {
          Indices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cachedData.Count); x = (x + 1)) {
          CachedData[x].Write(writer);
        }
        for (x = 0; (x < _cachedData.Count); x = (x + 1)) {
          CachedData[x].WriteChildData(writer);
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
    public class DecoratorShaderReferenceBlockBlock : IBlock {
      private TagReference _shader = new TagReference();
public event System.EventHandler BlockNameChanged;
      public DecoratorShaderReferenceBlockBlock() {
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _shader.WriteString(writer);
      }
    }
    public class DecoratorClassesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _type;
      private Pad _unnamed0;
      private Real _scale = new Real();
      private Block _permutations = new Block();
      public BlockCollection<DecoratorPermutationsBlockBlock> _permutationsList = new BlockCollection<DecoratorPermutationsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorClassesBlockBlock() {
        this._type = new Enum(1);
        this._unnamed0 = new Pad(3);
      }
      public BlockCollection<DecoratorPermutationsBlockBlock> Permutations {
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
        _name.Read(reader);
        _type.Read(reader);
        _unnamed0.Read(reader);
        _scale.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new DecoratorPermutationsBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _unnamed0.Write(bw);
        _scale.Write(bw);
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
    public class DecoratorPermutationsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private CharBlockIndex _shader = new CharBlockIndex();
      private Pad _unnamed0;
      private Flags _flags;
      private Enum _fadeDistance;
      private CharInteger _index = new CharInteger();
      private CharInteger _distributionWeight = new CharInteger();
      private RealBounds _scale = new RealBounds();
      private RGBColor _tint1 = new RGBColor();
      private RGBColor _tint2 = new RGBColor();
      private Real _baseMapTintPercentage = new Real();
      private Real _lightmapTintPercentage = new Real();
      private Real _windScale = new Real();
public event System.EventHandler BlockNameChanged;
      public DecoratorPermutationsBlockBlock() {
        this._unnamed0 = new Pad(3);
        this._flags = new Flags(1);
        this._fadeDistance = new Enum(1);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public CharBlockIndex Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
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
      public Enum FadeDistance {
        get {
          return this._fadeDistance;
        }
        set {
          this._fadeDistance = value;
        }
      }
      public CharInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public CharInteger DistributionWeight {
        get {
          return this._distributionWeight;
        }
        set {
          this._distributionWeight = value;
        }
      }
      public RealBounds Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public RGBColor Tint1 {
        get {
          return this._tint1;
        }
        set {
          this._tint1 = value;
        }
      }
      public RGBColor Tint2 {
        get {
          return this._tint2;
        }
        set {
          this._tint2 = value;
        }
      }
      public Real BaseMapTintPercentage {
        get {
          return this._baseMapTintPercentage;
        }
        set {
          this._baseMapTintPercentage = value;
        }
      }
      public Real LightmapTintPercentage {
        get {
          return this._lightmapTintPercentage;
        }
        set {
          this._lightmapTintPercentage = value;
        }
      }
      public Real WindScale {
        get {
          return this._windScale;
        }
        set {
          this._windScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _shader.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _fadeDistance.Read(reader);
        _index.Read(reader);
        _distributionWeight.Read(reader);
        _scale.Read(reader);
        _tint1.Read(reader);
        _tint2.Read(reader);
        _baseMapTintPercentage.Read(reader);
        _lightmapTintPercentage.Read(reader);
        _windScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _shader.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _fadeDistance.Write(bw);
        _index.Write(bw);
        _distributionWeight.Write(bw);
        _scale.Write(bw);
        _tint1.Write(bw);
        _tint2.Write(bw);
        _baseMapTintPercentage.Write(bw);
        _lightmapTintPercentage.Write(bw);
        _windScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class DecoratorModelsBlockBlock : IBlock {
      private StringId _modelName = new StringId();
      private ShortInteger _indexStart = new ShortInteger();
      private ShortInteger _indexCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorModelsBlockBlock() {
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
      public StringId ModelName {
        get {
          return this._modelName;
        }
        set {
          this._modelName = value;
        }
      }
      public ShortInteger IndexStart {
        get {
          return this._indexStart;
        }
        set {
          this._indexStart = value;
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
      public virtual void Read(BinaryReader reader) {
        _modelName.Read(reader);
        _indexStart.Read(reader);
        _indexCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _modelName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _modelName.Write(bw);
        _indexStart.Write(bw);
        _indexCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _modelName.WriteString(writer);
      }
    }
    public class DecoratorModelVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _normal = new RealVector3D();
      private RealVector3D _tangent = new RealVector3D();
      private RealVector3D _binormal = new RealVector3D();
      private RealPoint2D _texcoord = new RealPoint2D();
public event System.EventHandler BlockNameChanged;
      public DecoratorModelVerticesBlockBlock() {
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
      public RealVector3D Tangent {
        get {
          return this._tangent;
        }
        set {
          this._tangent = value;
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
      public RealPoint2D Texcoord {
        get {
          return this._texcoord;
        }
        set {
          this._texcoord = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _normal.Read(reader);
        _tangent.Read(reader);
        _binormal.Read(reader);
        _texcoord.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _normal.Write(bw);
        _tangent.Write(bw);
        _binormal.Write(bw);
        _texcoord.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorModelIndicesBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorModelIndicesBlockBlock() {
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
    public class CachedDataBlockBlock : IBlock {
      private Skip _vertexBuffer;
public event System.EventHandler BlockNameChanged;
      public CachedDataBlockBlock() {
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
  }
}
