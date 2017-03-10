// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'antenna'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class antenna : Interfaces.Pool.Tag {
    private AntennaBlock antennaValues = new AntennaBlock();
    public virtual AntennaBlock AntennaValues {
      get {
        return antennaValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(AntennaValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "antenna";
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
antennaValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
antennaValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
antennaValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
antennaValues.WriteChildData(writer);
    }
    #endregion
    public class AntennaBlock : IBlock {
      private FixedLengthString _attachmentMarkerName = new FixedLengthString();
      private TagReference _bitmaps = new TagReference();
      private TagReference _physics = new TagReference();
      private Pad _unnamed;
      private RealFraction _springStrengthCoefficient = new RealFraction();
      private Real _falloffPixels = new Real();
      private Real _cutoffPixels = new Real();
      private Pad _unnamed2;
      private Block _vertices = new Block();
      public BlockCollection<AntennaVertexBlock> _verticesList = new BlockCollection<AntennaVertexBlock>();
public event System.EventHandler BlockNameChanged;
      public AntennaBlock() {
        this._unnamed = new Pad(80);
        this._unnamed2 = new Pad(40);
      }
      public BlockCollection<AntennaVertexBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmaps.Value);
references.Add(_physics.Value);
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
      public FixedLengthString AttachmentMarkerName {
        get {
          return this._attachmentMarkerName;
        }
        set {
          this._attachmentMarkerName = value;
        }
      }
      public TagReference Bitmaps {
        get {
          return this._bitmaps;
        }
        set {
          this._bitmaps = value;
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
      public RealFraction SpringStrengthCoefficient {
        get {
          return this._springStrengthCoefficient;
        }
        set {
          this._springStrengthCoefficient = value;
        }
      }
      public Real FalloffPixels {
        get {
          return this._falloffPixels;
        }
        set {
          this._falloffPixels = value;
        }
      }
      public Real CutoffPixels {
        get {
          return this._cutoffPixels;
        }
        set {
          this._cutoffPixels = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _attachmentMarkerName.Read(reader);
        _bitmaps.Read(reader);
        _physics.Read(reader);
        _unnamed.Read(reader);
        _springStrengthCoefficient.Read(reader);
        _falloffPixels.Read(reader);
        _cutoffPixels.Read(reader);
        _unnamed2.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmaps.ReadString(reader);
        _physics.ReadString(reader);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new AntennaVertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _attachmentMarkerName.Write(bw);
        _bitmaps.Write(bw);
        _physics.Write(bw);
        _unnamed.Write(bw);
        _springStrengthCoefficient.Write(bw);
        _falloffPixels.Write(bw);
        _cutoffPixels.Write(bw);
        _unnamed2.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bitmaps.WriteString(writer);
        _physics.WriteString(writer);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class AntennaVertexBlock : IBlock {
      private RealFraction _springStrengthCoefficient = new RealFraction();
      private Pad _unnamed;
      private RealEulerAngles2D _angles = new RealEulerAngles2D();
      private Real _length = new Real();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Pad _unnamed2;
      private RealARGBColor _color = new RealARGBColor();
      private RealARGBColor _lODColor = new RealARGBColor();
      private Pad _unnamed3;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public AntennaVertexBlock() {
        this._unnamed = new Pad(24);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(40);
        this._unnamed4 = new Pad(12);
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
      public RealFraction SpringStrengthCoefficient {
        get {
          return this._springStrengthCoefficient;
        }
        set {
          this._springStrengthCoefficient = value;
        }
      }
      public RealEulerAngles2D Angles {
        get {
          return this._angles;
        }
        set {
          this._angles = value;
        }
      }
      public Real Length {
        get {
          return this._length;
        }
        set {
          this._length = value;
        }
      }
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
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
      public RealARGBColor LODColor {
        get {
          return this._lODColor;
        }
        set {
          this._lODColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _springStrengthCoefficient.Read(reader);
        _unnamed.Read(reader);
        _angles.Read(reader);
        _length.Read(reader);
        _sequenceIndex.Read(reader);
        _unnamed2.Read(reader);
        _color.Read(reader);
        _lODColor.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _springStrengthCoefficient.Write(bw);
        _unnamed.Write(bw);
        _angles.Write(bw);
        _length.Write(bw);
        _sequenceIndex.Write(bw);
        _unnamed2.Write(bw);
        _color.Write(bw);
        _lODColor.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
