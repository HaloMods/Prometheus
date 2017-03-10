// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'stereo_system'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class stereo_system : Interfaces.Pool.Tag {
    private StereoSystemBlockBlock stereoSystemValues = new StereoSystemBlockBlock();
    public virtual StereoSystemBlockBlock StereoSystemValues {
      get {
        return stereoSystemValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(StereoSystemValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "stereo_system";
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
stereoSystemValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
stereoSystemValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
stereoSystemValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
stereoSystemValues.WriteChildData(writer);
    }
    #endregion
    public class StereoSystemBlockBlock : IBlock {
      private LongInteger _unused = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public StereoSystemBlockBlock() {
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
      public LongInteger Unused {
        get {
          return this._unused;
        }
        set {
          this._unused = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unused.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unused.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
