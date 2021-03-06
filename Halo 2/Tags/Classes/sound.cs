// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound : Interfaces.Pool.Tag {
    private SoundBlockBlock soundValues = new SoundBlockBlock();
    public virtual SoundBlockBlock SoundValues {
      get {
        return soundValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound";
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
soundValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundValues.WriteChildData(writer);
    }
    #endregion
    public class SoundBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public SoundBlockBlock() {
        this._unnamed0 = new Skip(20);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
