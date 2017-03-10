// -----------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'device_control' (derived from 'device')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -----------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class device_control : device {
    private DeviceControlBlockBlock deviceControlValues = new DeviceControlBlockBlock();
    public virtual DeviceControlBlockBlock DeviceControlValues {
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
    public class DeviceControlBlockBlock : IBlock {
      private Enum _type;
      private Enum _triggersWhen;
      private Real _callValue = new Real();
      private StringId _actionString = new StringId();
      private TagReference _on = new TagReference();
      private TagReference _off = new TagReference();
      private TagReference _deny = new TagReference();
public event System.EventHandler BlockNameChanged;
      public DeviceControlBlockBlock() {
        this._type = new Enum(2);
        this._triggersWhen = new Enum(2);
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
      public StringId ActionString {
        get {
          return this._actionString;
        }
        set {
          this._actionString = value;
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
        _actionString.Read(reader);
        _on.Read(reader);
        _off.Read(reader);
        _deny.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _actionString.ReadString(reader);
        _on.ReadString(reader);
        _off.ReadString(reader);
        _deny.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _triggersWhen.Write(bw);
        _callValue.Write(bw);
        _actionString.Write(bw);
        _on.Write(bw);
        _off.Write(bw);
        _deny.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _actionString.WriteString(writer);
        _on.WriteString(writer);
        _off.WriteString(writer);
        _deny.WriteString(writer);
      }
    }
  }
}
