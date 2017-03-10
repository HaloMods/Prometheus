// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'camera_track'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class camera_track : Interfaces.Pool.Tag {
    private CameraTrackBlock cameraTrackValues = new CameraTrackBlock();
    public virtual CameraTrackBlock CameraTrackValues {
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
    public class CameraTrackBlock : IBlock {
      private Flags _flags;
      private Block _controlPoints = new Block();
      private Pad _unnamed;
      public BlockCollection<CameraTrackControlPointBlock> _controlPointsList = new BlockCollection<CameraTrackControlPointBlock>();
public event System.EventHandler BlockNameChanged;
      public CameraTrackBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
      }
      public BlockCollection<CameraTrackControlPointBlock> ControlPoints {
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _controlPoints.Count); x = (x + 1)) {
          ControlPoints.Add(new CameraTrackControlPointBlock());
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
        _unnamed.Write(bw);
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
    public class CameraTrackControlPointBlock : IBlock {
      private RealVector3D _position = new RealVector3D();
      private RealQuaternion _orientation = new RealQuaternion();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public CameraTrackControlPointBlock() {
        this._unnamed = new Pad(32);
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _orientation.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
