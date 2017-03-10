// --------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'placeholder' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// --------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class placeholder : @object {
    private PlaceholderBlock placeholderValues = new PlaceholderBlock();
    public virtual PlaceholderBlock PlaceholderValues {
      get {
        return placeholderValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(PlaceholderValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "placeholder";
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
placeholderValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
placeholderValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
placeholderValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
placeholderValues.WriteChildData(writer);
    }
    #endregion
    public class PlaceholderBlock : IBlock {
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public PlaceholderBlock() {
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
