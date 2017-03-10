// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'flag'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class flag : Interfaces.Pool.Tag {
    private FlagBlock flagValues = new FlagBlock();
    public virtual FlagBlock FlagValues {
      get {
        return flagValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(FlagValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "flag";
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
flagValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
flagValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
flagValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
flagValues.WriteChildData(writer);
    }
    #endregion
    public class FlagBlock : IBlock {
      private Flags _flags;
      private Enum _trailingEdgeShape = new Enum();
      private ShortInteger _trailingEdgeShapeOffset = new ShortInteger();
      private Enum _attachedEdgeShape = new Enum();
      private Pad _unnamed;
      private ShortInteger _width = new ShortInteger();
      private ShortInteger _height = new ShortInteger();
      private Real _cellWidth = new Real();
      private Real _cellHeight = new Real();
      private TagReference _redFlagShader = new TagReference();
      private TagReference _physics = new TagReference();
      private Real _windNoise = new Real();
      private Pad _unnamed2;
      private TagReference _blueFlagShader = new TagReference();
      private Block _attachmentPoints = new Block();
      public BlockCollection<FlagAttachmentPointBlock> _attachmentPointsList = new BlockCollection<FlagAttachmentPointBlock>();
public event System.EventHandler BlockNameChanged;
      public FlagBlock() {
if (this._blueFlagShader is System.ComponentModel.INotifyPropertyChanged)
  (this._blueFlagShader as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(8);
      }
      public BlockCollection<FlagAttachmentPointBlock> AttachmentPoints {
        get {
          return this._attachmentPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_redFlagShader.Value);
references.Add(_physics.Value);
references.Add(_blueFlagShader.Value);
for (int x=0; x<AttachmentPoints.BlockCount; x++)
{
  IBlock block = AttachmentPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _blueFlagShader.ToString();
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
      public Enum TrailingEdgeShape {
        get {
          return this._trailingEdgeShape;
        }
        set {
          this._trailingEdgeShape = value;
        }
      }
      public ShortInteger TrailingEdgeShapeOffset {
        get {
          return this._trailingEdgeShapeOffset;
        }
        set {
          this._trailingEdgeShapeOffset = value;
        }
      }
      public Enum AttachedEdgeShape {
        get {
          return this._attachedEdgeShape;
        }
        set {
          this._attachedEdgeShape = value;
        }
      }
      public ShortInteger Width {
        get {
          return this._width;
        }
        set {
          this._width = value;
        }
      }
      public ShortInteger Height {
        get {
          return this._height;
        }
        set {
          this._height = value;
        }
      }
      public Real CellWidth {
        get {
          return this._cellWidth;
        }
        set {
          this._cellWidth = value;
        }
      }
      public Real CellHeight {
        get {
          return this._cellHeight;
        }
        set {
          this._cellHeight = value;
        }
      }
      public TagReference RedFlagShader {
        get {
          return this._redFlagShader;
        }
        set {
          this._redFlagShader = value;
        }
      }
      public TagReference Physics {
        get {
          return this._physics;
        }
        set {
          this._physics = value;
        }
      }
      public Real WindNoise {
        get {
          return this._windNoise;
        }
        set {
          this._windNoise = value;
        }
      }
      public TagReference BlueFlagShader {
        get {
          return this._blueFlagShader;
        }
        set {
          this._blueFlagShader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _trailingEdgeShape.Read(reader);
        _trailingEdgeShapeOffset.Read(reader);
        _attachedEdgeShape.Read(reader);
        _unnamed.Read(reader);
        _width.Read(reader);
        _height.Read(reader);
        _cellWidth.Read(reader);
        _cellHeight.Read(reader);
        _redFlagShader.Read(reader);
        _physics.Read(reader);
        _windNoise.Read(reader);
        _unnamed2.Read(reader);
        _blueFlagShader.Read(reader);
        _attachmentPoints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _redFlagShader.ReadString(reader);
        _physics.ReadString(reader);
        _blueFlagShader.ReadString(reader);
        for (x = 0; (x < _attachmentPoints.Count); x = (x + 1)) {
          AttachmentPoints.Add(new FlagAttachmentPointBlock());
          AttachmentPoints[x].Read(reader);
        }
        for (x = 0; (x < _attachmentPoints.Count); x = (x + 1)) {
          AttachmentPoints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _trailingEdgeShape.Write(bw);
        _trailingEdgeShapeOffset.Write(bw);
        _attachedEdgeShape.Write(bw);
        _unnamed.Write(bw);
        _width.Write(bw);
        _height.Write(bw);
        _cellWidth.Write(bw);
        _cellHeight.Write(bw);
        _redFlagShader.Write(bw);
        _physics.Write(bw);
        _windNoise.Write(bw);
        _unnamed2.Write(bw);
        _blueFlagShader.Write(bw);
_attachmentPoints.Count = AttachmentPoints.Count;
        _attachmentPoints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _redFlagShader.WriteString(writer);
        _physics.WriteString(writer);
        _blueFlagShader.WriteString(writer);
        for (x = 0; (x < _attachmentPoints.Count); x = (x + 1)) {
          AttachmentPoints[x].Write(writer);
        }
        for (x = 0; (x < _attachmentPoints.Count); x = (x + 1)) {
          AttachmentPoints[x].WriteChildData(writer);
        }
      }
    }
    public class FlagAttachmentPointBlock : IBlock {
      private ShortInteger _heighttonextattachment = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private FixedLengthString _markerName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public FlagAttachmentPointBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _markerName.ToString();
        }
      }
      public ShortInteger Heighttonextattachment {
        get {
          return this._heighttonextattachment;
        }
        set {
          this._heighttonextattachment = value;
        }
      }
      public FixedLengthString MarkerName {
        get {
          return this._markerName;
        }
        set {
          this._markerName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _heighttonextattachment.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _markerName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _heighttonextattachment.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
