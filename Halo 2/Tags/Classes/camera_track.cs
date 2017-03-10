// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'camera_track'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class camera_track : Interfaces.Pool.Tag {
    private CameraTrackBlockBlock cameraTrackValues = new CameraTrackBlockBlock();
    public virtual CameraTrackBlockBlock CameraTrackValues {
      get {
        return cameraTrackValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(CameraTrackValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "camera_track";
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
cameraTrackValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
cameraTrackValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
cameraTrackValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
cameraTrackValues.WriteChildData(writer);
    }
    #endregion
    public class CameraTrackBlockBlock : IBlock {
      private Flags _flags;
      private Block _controlPoints = new Block();
      public BlockCollection<CameraTrackControlPointBlockBlock> _controlPointsList = new BlockCollection<CameraTrackControlPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CameraTrackBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<CameraTrackControlPointBlockBlock> ControlPoints {
        get {
          return this._controlPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ControlPoints.BlockCount; x++)
{
  IBlock block = ControlPoints.GetBlock(x);
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
        _controlPoints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _controlPoints.Count); x = (x + 1)) {
          ControlPoints.Add(new CameraTrackControlPointBlockBlock());
          ControlPoints[x].Read(reader);
        }
        for (x = 0; (x < _controlPoints.Count); x = (x + 1)) {
          ControlPoints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
_controlPoints.Count = ControlPoints.Count;
        _controlPoints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _controlPoints.Count); x = (x + 1)) {
          ControlPoints[x].Write(writer);
        }
        for (x = 0; (x < _controlPoints.Count); x = (x + 1)) {
          ControlPoints[x].WriteChildData(writer);
        }
      }
    }
    public class CameraTrackControlPointBlockBlock : IBlock {
      private RealVector3D _position = new RealVector3D();
      private RealQuaternion _orientation = new RealQuaternion();
public event System.EventHandler BlockNameChanged;
      public CameraTrackControlPointBlockBlock() {
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
      public RealVector3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealQuaternion Orientation {
        get {
          return this._orientation;
        }
        set {
          this._orientation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _orientation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _orientation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
