// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader : Interfaces.Pool.Tag {
    private ShaderBlock shaderValues = new ShaderBlock();
    public virtual ShaderBlock ShaderValues {
      get {
        return shaderValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ShaderValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader";
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
shaderValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
shaderValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
shaderValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
shaderValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderBlock : IBlock {
      private Flags _flags;
      private Enum _detailLevel = new Enum();
      private Real _power = new Real();
      private RealRGBColor _colorOfEmittedLight = new RealRGBColor();
      private RealRGBColor _tintColor = new RealRGBColor();
      private Flags _flags2;
      private Enum _materialType = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ShaderBlock() {
        this._flags = new Flags(2);
        this._flags2 = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum DetailLevel {
        get {
          return this._detailLevel;
        }
        set {
          this._detailLevel = value;
        }
      }
      public Real Power {
        get {
          return this._power;
        }
        set {
          this._power = value;
        }
      }
      public RealRGBColor ColorOfEmittedLight {
        get {
          return this._colorOfEmittedLight;
        }
        set {
          this._colorOfEmittedLight = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public Enum MaterialType {
        get {
          return this._materialType;
        }
        set {
          this._materialType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _detailLevel.Read(reader);
        _power.Read(reader);
        _colorOfEmittedLight.Read(reader);
        _tintColor.Read(reader);
        _flags2.Read(reader);
        _materialType.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _detailLevel.Write(bw);
        _power.Write(bw);
        _colorOfEmittedLight.Write(bw);
        _tintColor.Write(bw);
        _flags2.Write(bw);
        _materialType.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
