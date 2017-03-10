// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'spheroid'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class spheroid : Interfaces.Pool.Tag {
    private SpheroidBlock spheroidValues = new SpheroidBlock();
    public virtual SpheroidBlock SpheroidValues {
      get {
        return spheroidValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SpheroidValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "spheroid";
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
spheroidValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
spheroidValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
spheroidValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
spheroidValues.WriteChildData(writer);
    }
    #endregion
    public class SpheroidBlock : IBlock {
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public SpheroidBlock() {
        this._unnamed = new Pad(4);
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
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
