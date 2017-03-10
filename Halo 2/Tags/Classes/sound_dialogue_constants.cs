// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_dialogue_constants'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_dialogue_constants : Interfaces.Pool.Tag {
    private SoundDialogueConstantsBlockBlock soundDialogueConstantsValues = new SoundDialogueConstantsBlockBlock();
    public virtual SoundDialogueConstantsBlockBlock SoundDialogueConstantsValues {
      get {
        return soundDialogueConstantsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundDialogueConstantsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_dialogue_constants";
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
soundDialogueConstantsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundDialogueConstantsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundDialogueConstantsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundDialogueConstantsValues.WriteChildData(writer);
    }
    #endregion
    public class SoundDialogueConstantsBlockBlock : IBlock {
      private Real _almostNever = new Real();
      private Real _rarely = new Real();
      private Real _somewhat = new Real();
      private Real _often = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public SoundDialogueConstantsBlockBlock() {
        this._unnamed0 = new Pad(24);
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
      public Real AlmostNever {
        get {
          return this._almostNever;
        }
        set {
          this._almostNever = value;
        }
      }
      public Real Rarely {
        get {
          return this._rarely;
        }
        set {
          this._rarely = value;
        }
      }
      public Real Somewhat {
        get {
          return this._somewhat;
        }
        set {
          this._somewhat = value;
        }
      }
      public Real Often {
        get {
          return this._often;
        }
        set {
          this._often = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _almostNever.Read(reader);
        _rarely.Read(reader);
        _somewhat.Read(reader);
        _often.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _almostNever.Write(bw);
        _rarely.Write(bw);
        _somewhat.Write(bw);
        _often.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
