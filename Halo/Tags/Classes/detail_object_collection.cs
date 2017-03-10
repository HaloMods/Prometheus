// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'detail_object_collection'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class detail_object_collection : Interfaces.Pool.Tag {
    private DetailObjectCollectionBlock detailObjectCollectionValues = new DetailObjectCollectionBlock();
    public virtual DetailObjectCollectionBlock DetailObjectCollectionValues {
      get {
        return detailObjectCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DetailObjectCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "detail_object_collection";
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
detailObjectCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
detailObjectCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
detailObjectCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
detailObjectCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class DetailObjectCollectionBlock : IBlock {
      private Enum _collectionType = new Enum();
      private Pad _unnamed;
      private Real _globalZOffset = new Real();
      private Pad _unnamed2;
      private TagReference _spritePlate = new TagReference();
      private Block _types = new Block();
      private Pad _unnamed3;
      public BlockCollection<DetailObjectTypeBlock> _typesList = new BlockCollection<DetailObjectTypeBlock>();
public event System.EventHandler BlockNameChanged;
      public DetailObjectCollectionBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(44);
        this._unnamed3 = new Pad(48);
      }
      public BlockCollection<DetailObjectTypeBlock> Types {
        get {
          return this._typesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_spritePlate.Value);
for (int x=0; x<Types.BlockCount; x++)
{
  IBlock block = Types.GetBlock(x);
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
      public Enum CollectionType {
        get {
          return this._collectionType;
        }
        set {
          this._collectionType = value;
        }
      }
      public Real GlobalZOffset {
        get {
          return this._globalZOffset;
        }
        set {
          this._globalZOffset = value;
        }
      }
      public TagReference SpritePlate {
        get {
          return this._spritePlate;
        }
        set {
          this._spritePlate = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _collectionType.Read(reader);
        _unnamed.Read(reader);
        _globalZOffset.Read(reader);
        _unnamed2.Read(reader);
        _spritePlate.Read(reader);
        _types.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _spritePlate.ReadString(reader);
        for (x = 0; (x < _types.Count); x = (x + 1)) {
          Types.Add(new DetailObjectTypeBlock());
          Types[x].Read(reader);
        }
        for (x = 0; (x < _types.Count); x = (x + 1)) {
          Types[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _collectionType.Write(bw);
        _unnamed.Write(bw);
        _globalZOffset.Write(bw);
        _unnamed2.Write(bw);
        _spritePlate.Write(bw);
_types.Count = Types.Count;
        _types.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _spritePlate.WriteString(writer);
        for (x = 0; (x < _types.Count); x = (x + 1)) {
          Types[x].Write(writer);
        }
        for (x = 0; (x < _types.Count); x = (x + 1)) {
          Types[x].WriteChildData(writer);
        }
      }
    }
    public class DetailObjectTypeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private CharInteger _sequenceIndex = new CharInteger();
      private Flags _typeFlags;
      private Pad _unnamed;
      private RealFraction _colorOverrideFactor = new RealFraction();
      private Pad _unnamed2;
      private Real _nearFadeDistance = new Real();
      private Real _farFadeDistance = new Real();
      private Real _size = new Real();
      private Pad _unnamed3;
      private RealRGBColor _minimumColor = new RealRGBColor();
      private RealRGBColor _maximumColor = new RealRGBColor();
      private ARGBColor _ambientColor = new ARGBColor();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public DetailObjectTypeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._typeFlags = new Flags(1);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
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
      public CharInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
        }
      }
      public Flags TypeFlags {
        get {
          return this._typeFlags;
        }
        set {
          this._typeFlags = value;
        }
      }
      public RealFraction ColorOverrideFactor {
        get {
          return this._colorOverrideFactor;
        }
        set {
          this._colorOverrideFactor = value;
        }
      }
      public Real NearFadeDistance {
        get {
          return this._nearFadeDistance;
        }
        set {
          this._nearFadeDistance = value;
        }
      }
      public Real FarFadeDistance {
        get {
          return this._farFadeDistance;
        }
        set {
          this._farFadeDistance = value;
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
      public RealRGBColor MinimumColor {
        get {
          return this._minimumColor;
        }
        set {
          this._minimumColor = value;
        }
      }
      public RealRGBColor MaximumColor {
        get {
          return this._maximumColor;
        }
        set {
          this._maximumColor = value;
        }
      }
      public ARGBColor AmbientColor {
        get {
          return this._ambientColor;
        }
        set {
          this._ambientColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _sequenceIndex.Read(reader);
        _typeFlags.Read(reader);
        _unnamed.Read(reader);
        _colorOverrideFactor.Read(reader);
        _unnamed2.Read(reader);
        _nearFadeDistance.Read(reader);
        _farFadeDistance.Read(reader);
        _size.Read(reader);
        _unnamed3.Read(reader);
        _minimumColor.Read(reader);
        _maximumColor.Read(reader);
        _ambientColor.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _sequenceIndex.Write(bw);
        _typeFlags.Write(bw);
        _unnamed.Write(bw);
        _colorOverrideFactor.Write(bw);
        _unnamed2.Write(bw);
        _nearFadeDistance.Write(bw);
        _farFadeDistance.Write(bw);
        _size.Write(bw);
        _unnamed3.Write(bw);
        _minimumColor.Write(bw);
        _maximumColor.Write(bw);
        _ambientColor.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
