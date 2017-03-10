// ---------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'device' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class device : @object {
    private DeviceBlock deviceValues = new DeviceBlock();
    public virtual DeviceBlock DeviceValues {
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
    public class DeviceBlock : IBlock {
      private Flags _flags;
      private Real _powerTransitionTime = new Real();
      private Real _powerAccelerationTime = new Real();
      private Real _positionTransitionTime = new Real();
      private Real _positionAccelerationTime = new Real();
      private Real _depoweredPositionTransitionTime = new Real();
      private Real _depoweredPositionAccelerationTime = new Real();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private TagReference _openUp = new TagReference();
      private TagReference _closeDown = new TagReference();
      private TagReference _opened = new TagReference();
      private TagReference _closed = new TagReference();
      private TagReference _depowered = new TagReference();
      private TagReference _repowered = new TagReference();
      private Real _delayTime = new Real();
      private Pad _unnamed;
      private TagReference _delayEffect = new TagReference();
      private Real _automaticActivationRadius = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public DeviceBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(84);
        this._unnamed3 = new Pad(28);
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
      public Enum AIn {
        get {
          return this._aIn;
        }
        set {
          this._aIn = value;
        }
      }
      public Enum BIn {
        get {
          return this._bIn;
        }
        set {
          this._bIn = value;
        }
      }
      public Enum CIn {
        get {
          return this._cIn;
        }
        set {
          this._cIn = value;
        }
      }
      public Enum DIn {
        get {
          return this._dIn;
        }
        set {
          this._dIn = value;
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
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _openUp.Read(reader);
        _closeDown.Read(reader);
        _opened.Read(reader);
        _closed.Read(reader);
        _depowered.Read(reader);
        _repowered.Read(reader);
        _delayTime.Read(reader);
        _unnamed.Read(reader);
        _delayEffect.Read(reader);
        _automaticActivationRadius.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
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
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _openUp.Write(bw);
        _closeDown.Write(bw);
        _opened.Write(bw);
        _closed.Write(bw);
        _depowered.Write(bw);
        _repowered.Write(bw);
        _delayTime.Write(bw);
        _unnamed.Write(bw);
        _delayEffect.Write(bw);
        _automaticActivationRadius.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
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
