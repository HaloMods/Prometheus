// ---------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_meter' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_meter : shader {
    private ShaderTransparentMeterBlock shaderTransparentMeterValues = new ShaderTransparentMeterBlock();
    public virtual ShaderTransparentMeterBlock ShaderTransparentMeterValues {
      get {
        return shaderTransparentMeterValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentMeterValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_meter";
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
shaderTransparentMeterValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentMeterValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentMeterValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentMeterValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentMeterBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private TagReference _map = new TagReference();
      private Pad _unnamed3;
      private RealRGBColor _gradientMinColor = new RealRGBColor();
      private RealRGBColor _gradientMaxColor = new RealRGBColor();
      private RealRGBColor _backgroundColor = new RealRGBColor();
      private RealRGBColor _flashColor = new RealRGBColor();
      private RealRGBColor _tintColor = new RealRGBColor();
      private RealFraction _meterTransparency = new RealFraction();
      private RealFraction _backgroundTransparency = new RealFraction();
      private Pad _unnamed4;
      private Enum _meterBrightnessSource = new Enum();
      private Enum _flashBrightnessSource = new Enum();
      private Enum _valueSource = new Enum();
      private Enum _gradientSource = new Enum();
      private Enum _flas = new Enum();
      private Pad _unnamed5;
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentMeterBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(32);
        this._unnamed4 = new Pad(24);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_map.Value);
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
      public TagReference Map {
        get {
          return this._map;
        }
        set {
          this._map = value;
        }
      }
      public RealRGBColor GradientMinColor {
        get {
          return this._gradientMinColor;
        }
        set {
          this._gradientMinColor = value;
        }
      }
      public RealRGBColor GradientMaxColor {
        get {
          return this._gradientMaxColor;
        }
        set {
          this._gradientMaxColor = value;
        }
      }
      public RealRGBColor BackgroundColor {
        get {
          return this._backgroundColor;
        }
        set {
          this._backgroundColor = value;
        }
      }
      public RealRGBColor FlashColor {
        get {
          return this._flashColor;
        }
        set {
          this._flashColor = value;
        }
      }
      public RealRGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
        }
      }
      public RealFraction MeterTransparency {
        get {
          return this._meterTransparency;
        }
        set {
          this._meterTransparency = value;
        }
      }
      public RealFraction BackgroundTransparency {
        get {
          return this._backgroundTransparency;
        }
        set {
          this._backgroundTransparency = value;
        }
      }
      public Enum MeterBrightnessSource {
        get {
          return this._meterBrightnessSource;
        }
        set {
          this._meterBrightnessSource = value;
        }
      }
      public Enum FlashBrightnessSource {
        get {
          return this._flashBrightnessSource;
        }
        set {
          this._flashBrightnessSource = value;
        }
      }
      public Enum ValueSource {
        get {
          return this._valueSource;
        }
        set {
          this._valueSource = value;
        }
      }
      public Enum GradientSource {
        get {
          return this._gradientSource;
        }
        set {
          this._gradientSource = value;
        }
      }
      public Enum Flas {
        get {
          return this._flas;
        }
        set {
          this._flas = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _map.Read(reader);
        _unnamed3.Read(reader);
        _gradientMinColor.Read(reader);
        _gradientMaxColor.Read(reader);
        _backgroundColor.Read(reader);
        _flashColor.Read(reader);
        _tintColor.Read(reader);
        _meterTransparency.Read(reader);
        _backgroundTransparency.Read(reader);
        _unnamed4.Read(reader);
        _meterBrightnessSource.Read(reader);
        _flashBrightnessSource.Read(reader);
        _valueSource.Read(reader);
        _gradientSource.Read(reader);
        _flas.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _map.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _map.Write(bw);
        _unnamed3.Write(bw);
        _gradientMinColor.Write(bw);
        _gradientMaxColor.Write(bw);
        _backgroundColor.Write(bw);
        _flashColor.Write(bw);
        _tintColor.Write(bw);
        _meterTransparency.Write(bw);
        _backgroundTransparency.Write(bw);
        _unnamed4.Write(bw);
        _meterBrightnessSource.Write(bw);
        _flashBrightnessSource.Write(bw);
        _valueSource.Write(bw);
        _gradientSource.Write(bw);
        _flas.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _map.WriteString(writer);
      }
    }
  }
}
