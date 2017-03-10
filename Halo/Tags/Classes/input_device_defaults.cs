// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'input_device_defaults'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class input_device_defaults : Interfaces.Pool.Tag {
    private InputDeviceDefaultsBlock inputDeviceDefaultsValues = new InputDeviceDefaultsBlock();
    public virtual InputDeviceDefaultsBlock InputDeviceDefaultsValues {
      get {
        return inputDeviceDefaultsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(InputDeviceDefaultsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "input_device_defaults";
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
inputDeviceDefaultsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
inputDeviceDefaultsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
inputDeviceDefaultsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
inputDeviceDefaultsValues.WriteChildData(writer);
    }
    #endregion
    public class InputDeviceDefaultsBlock : IBlock {
      private Enum _deviceType = new Enum();
      private Flags _flags;
      private Data _deviceId = new Data();
      private Data _profile = new Data();
public event System.EventHandler BlockNameChanged;
      public InputDeviceDefaultsBlock() {
        this._flags = new Flags(2);
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
      public Enum DeviceType {
        get {
          return this._deviceType;
        }
        set {
          this._deviceType = value;
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
      public Data DeviceId {
        get {
          return this._deviceId;
        }
        set {
          this._deviceId = value;
        }
      }
      public Data Profile {
        get {
          return this._profile;
        }
        set {
          this._profile = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _deviceType.Read(reader);
        _flags.Read(reader);
        _deviceId.Read(reader);
        _profile.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _deviceId.ReadBinary(reader);
        _profile.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _deviceType.Write(bw);
        _flags.Write(bw);
        _deviceId.Write(bw);
        _profile.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _deviceId.WriteBinary(writer);
        _profile.WriteBinary(writer);
      }
    }
  }
}
