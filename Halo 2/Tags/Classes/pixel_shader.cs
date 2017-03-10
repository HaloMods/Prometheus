// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'pixel_shader'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class pixel_shader : Interfaces.Pool.Tag {
    private PixelShaderBlockBlock pixelShaderValues = new PixelShaderBlockBlock();
    public virtual PixelShaderBlockBlock PixelShaderValues {
      get {
        return pixelShaderValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PixelShaderValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "pixel_shader";
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
pixelShaderValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
pixelShaderValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
pixelShaderValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
pixelShaderValues.WriteChildData(writer);
    }
    #endregion
    public class PixelShaderBlockBlock : IBlock {
      private Pad _unnamed0;
      private Data _compiledshader = new Data();
public event System.EventHandler BlockNameChanged;
      public PixelShaderBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public Data Compiledshader {
        get {
          return this._compiledshader;
        }
        set {
          this._compiledshader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _compiledshader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _compiledshader.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _compiledshader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _compiledshader.WriteBinary(writer);
      }
    }
  }
}
