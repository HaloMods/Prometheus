// -----------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'device_machine' (derived from 'device')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -----------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class device_machine : device {
    private DeviceMachineBlock deviceMachineValues = new DeviceMachineBlock();
    public virtual DeviceMachineBlock DeviceMachineValues {
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
    public class DeviceMachineBlock : IBlock {
      private Enum _type = new Enum();
      private Flags _flags;
      private Real _doorOpenTime = new Real();
      private Pad _unnamed;
      private Enum _collisionResponse = new Enum();
      private ShortInteger _elevatorNode = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public DeviceMachineBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(80);
        this._unnamed2 = new Pad(52);
        this._unnamed3 = new Pad(4);
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _doorOpenTime.Read(reader);
        _unnamed.Read(reader);
        _collisionResponse.Read(reader);
        _elevatorNode.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _doorOpenTime.Write(bw);
        _unnamed.Write(bw);
        _collisionResponse.Write(bw);
        _elevatorNode.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
