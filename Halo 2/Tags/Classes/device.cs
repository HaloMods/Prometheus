// ---------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'device' (derived from 'object')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ---------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class device : @object {
    private DeviceBlockBlock deviceValues = new DeviceBlockBlock();
    public virtual DeviceBlockBlock DeviceValues {
      get {
        return deviceValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(DeviceValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "device";
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
deviceValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
deviceValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
deviceValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
deviceValues.WriteChildData(writer);
    }
    #endregion
    public class DeviceBlockBlock : IBlock {
      private Flags _flags;
      private Real _powerTransitionTime = new Real();
      private Real _powerAccelerationTime = new Real();
      private Real _positionTransitionTime = new Real();
      private Real _positionAccelerationTime = new Real();
      private Real _depoweredPositionTransitionTime = new Real();
      private Real _depoweredPositionAccelerationTime = new Real();
      private Flags _lightmapFlags;
      private Pad _unnamed0;
      private TagReference _openUp = new TagReference();
      private TagReference _closeDown = new TagReference();
      private TagReference _opened = new TagReference();
      private TagReference _closed = new TagReference();
      private TagReference _depowered = new TagReference();
      private TagReference _repowered = new TagReference();
      private Real _delayTime = new Real();
      private TagReference _delayEffect = new TagReference();
      private Real _automaticActivationRadius = new Real();
public event System.EventHandler BlockNameChanged;
      public DeviceBlockBlock() {
        this._flags = new Flags(4);
        this._lightmapFlags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_openUp.Value);
references.Add(_closeDown.Value);
references.Add(_opened.Value);
references.Add(_closed.Value);
references.Add(_depowered.Value);
references.Add(_repowered.Value);
references.Add(_delayEffect.Value);
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
      public Real PowerTransitionTime {
        get {
          return this._powerTransitionTime;
        }
        set {
          this._powerTransitionTime = value;
        }
      }
      public Real PowerAccelerationTime {
        get {
          return this._powerAccelerationTime;
        }
        set {
          this._powerAccelerationTime = value;
        }
      }
      public Real PositionTransitionTime {
        get {
          return this._positionTransitionTime;
        }
        set {
          this._positionTransitionTime = value;
        }
      }
      public Real PositionAccelerationTime {
        get {
          return this._positionAccelerationTime;
        }
        set {
          this._positionAccelerationTime = value;
        }
      }
      public Real DepoweredPositionTransitionTime {
        get {
          return this._depoweredPositionTransitionTime;
        }
        set {
          this._depoweredPositionTransitionTime = value;
        }
      }
      public Real DepoweredPositionAccelerationTime {
        get {
          return this._depoweredPositionAccelerationTime;
        }
        set {
          this._depoweredPositionAccelerationTime = value;
        }
      }
      public Flags LightmapFlags {
        get {
          return this._lightmapFlags;
        }
        set {
          this._lightmapFlags = value;
        }
      }
      public TagReference OpenUp {
        get {
          return this._openUp;
        }
        set {
          this._openUp = value;
        }
      }
      public TagReference CloseDown {
        get {
          return this._closeDown;
        }
        set {
          this._closeDown = value;
        }
      }
      public TagReference Opened {
        get {
          return this._opened;
        }
        set {
          this._opened = value;
        }
      }
      public TagReference Closed {
        get {
          return this._closed;
        }
        set {
          this._closed = value;
        }
      }
      public TagReference Depowered {
        get {
          return this._depowered;
        }
        set {
          this._depowered = value;
        }
      }
      public TagReference Repowered {
        get {
          return this._repowered;
        }
        set {
          this._repowered = value;
        }
      }
      public Real DelayTime {
        get {
          return this._delayTime;
        }
        set {
          this._delayTime = value;
        }
      }
      public TagReference DelayEffect {
        get {
          return this._delayEffect;
        }
        set {
          this._delayEffect = value;
        }
      }
      public Real AutomaticActivationRadius {
        get {
          return this._automaticActivationRadius;
        }
        set {
          this._automaticActivationRadius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _powerTransitionTime.Read(reader);
        _powerAccelerationTime.Read(reader);
        _positionTransitionTime.Read(reader);
        _positionAccelerationTime.Read(reader);
        _depoweredPositionTransitionTime.Read(reader);
        _depoweredPositionAccelerationTime.Read(reader);
        _lightmapFlags.Read(reader);
        _unnamed0.Read(reader);
        _openUp.Read(reader);
        _closeDown.Read(reader);
        _opened.Read(reader);
        _closed.Read(reader);
        _depowered.Read(reader);
        _repowered.Read(reader);
        _delayTime.Read(reader);
        _delayEffect.Read(reader);
        _automaticActivationRadius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _openUp.ReadString(reader);
        _closeDown.ReadString(reader);
        _opened.ReadString(reader);
        _closed.ReadString(reader);
        _depowered.ReadString(reader);
        _repowered.ReadString(reader);
        _delayEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _powerTransitionTime.Write(bw);
        _powerAccelerationTime.Write(bw);
        _positionTransitionTime.Write(bw);
        _positionAccelerationTime.Write(bw);
        _depoweredPositionTransitionTime.Write(bw);
        _depoweredPositionAccelerationTime.Write(bw);
        _lightmapFlags.Write(bw);
        _unnamed0.Write(bw);
        _openUp.Write(bw);
        _closeDown.Write(bw);
        _opened.Write(bw);
        _closed.Write(bw);
        _depowered.Write(bw);
        _repowered.Write(bw);
        _delayTime.Write(bw);
        _delayEffect.Write(bw);
        _automaticActivationRadius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _openUp.WriteString(writer);
        _closeDown.WriteString(writer);
        _opened.WriteString(writer);
        _closed.WriteString(writer);
        _depowered.WriteString(writer);
        _repowered.WriteString(writer);
        _delayEffect.WriteString(writer);
      }
    }
  }
}
