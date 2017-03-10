// -----------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'device_machine' (derived from 'device')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -----------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class device_machine : device {
    private DeviceMachineBlockBlock deviceMachineValues = new DeviceMachineBlockBlock();
    public virtual DeviceMachineBlockBlock DeviceMachineValues {
      get {
        return deviceMachineValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(DeviceMachineValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "device_machine";
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
base.Read(reader);
deviceMachineValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
deviceMachineValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
deviceMachineValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
deviceMachineValues.WriteChildData(writer);
    }
    #endregion
    public class DeviceMachineBlockBlock : IBlock {
      private Enum _type;
      private Flags _flags;
      private Real _doorOpenTime = new Real();
      private FractionBounds _doorOcclusionBounds = new FractionBounds();
      private Enum _collisionResponse;
      private ShortInteger _elevatorNode = new ShortInteger();
      private Enum _pathfindingPolicy;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public DeviceMachineBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._collisionResponse = new Enum(2);
        this._pathfindingPolicy = new Enum(2);
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
      public Real DoorOpenTime {
        get {
          return this._doorOpenTime;
        }
        set {
          this._doorOpenTime = value;
        }
      }
      public FractionBounds DoorOcclusionBounds {
        get {
          return this._doorOcclusionBounds;
        }
        set {
          this._doorOcclusionBounds = value;
        }
      }
      public Enum CollisionResponse {
        get {
          return this._collisionResponse;
        }
        set {
          this._collisionResponse = value;
        }
      }
      public ShortInteger ElevatorNode {
        get {
          return this._elevatorNode;
        }
        set {
          this._elevatorNode = value;
        }
      }
      public Enum PathfindingPolicy {
        get {
          return this._pathfindingPolicy;
        }
        set {
          this._pathfindingPolicy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _doorOpenTime.Read(reader);
        _doorOcclusionBounds.Read(reader);
        _collisionResponse.Read(reader);
        _elevatorNode.Read(reader);
        _pathfindingPolicy.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _doorOpenTime.Write(bw);
        _doorOcclusionBounds.Write(bw);
        _collisionResponse.Write(bw);
        _elevatorNode.Write(bw);
        _pathfindingPolicy.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
