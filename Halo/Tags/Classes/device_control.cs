// -----------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'device_control' (derived from 'device')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -----------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class device_control : device {
    private DeviceControlBlock deviceControlValues = new DeviceControlBlock();
    public virtual DeviceControlBlock DeviceControlValues {
      get {
        return deviceControlValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(DeviceControlValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "device_control";
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
deviceControlValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
deviceControlValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
deviceControlValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
deviceControlValues.WriteChildData(writer);
    }
    #endregion
    public class DeviceControlBlock : IBlock {
      private Enum _type = new Enum();
      private Enum _triggersWhen = new Enum();
      private Real _callValue = new Real();
      private Pad _unnamed;
      private TagReference _on = new TagReference();
      private TagReference _off = new TagReference();
      private TagReference _deny = new TagReference();
public event System.EventHandler BlockNameChanged;
      public DeviceControlBlock() {
        this._unnamed = new Pad(80);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_on.Value);
references.Add(_off.Value);
references.Add(_deny.Value);
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
      public Enum TriggersWhen {
        get {
          return this._triggersWhen;
        }
        set {
          this._triggersWhen = value;
        }
      }
      public Real CallValue {
        get {
          return this._callValue;
        }
        set {
          this._callValue = value;
        }
      }
      public TagReference On {
        get {
          return this._on;
        }
        set {
          this._on = value;
        }
      }
      public TagReference Off {
        get {
          return this._off;
        }
        set {
          this._off = value;
        }
      }
      public TagReference Deny {
        get {
          return this._deny;
        }
        set {
          this._deny = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _triggersWhen.Read(reader);
        _callValue.Read(reader);
        _unnamed.Read(reader);
        _on.Read(reader);
        _off.Read(reader);
        _deny.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _on.ReadString(reader);
        _off.ReadString(reader);
        _deny.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _triggersWhen.Write(bw);
        _callValue.Write(bw);
        _unnamed.Write(bw);
        _on.Write(bw);
        _off.Write(bw);
        _deny.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _on.WriteString(writer);
        _off.WriteString(writer);
        _deny.WriteString(writer);
      }
    }
  }
}
