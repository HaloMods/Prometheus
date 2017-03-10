// ----------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'scenery' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ----------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class scenery : @object {
    private SceneryBlock sceneryValues = new SceneryBlock();
    public virtual SceneryBlock SceneryValues {
      get {
        return sceneryValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(SceneryValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "scenery";
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
sceneryValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
sceneryValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
sceneryValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
sceneryValues.WriteChildData(writer);
    }
    #endregion
    public class SceneryBlock : IBlock {
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public SceneryBlock() {
        this._unnamed = new Pad(128);
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
