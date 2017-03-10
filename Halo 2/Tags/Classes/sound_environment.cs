// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_environment'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_environment : Interfaces.Pool.Tag {
    private SoundEnvironmentBlockBlock soundEnvironmentValues = new SoundEnvironmentBlockBlock();
    public virtual SoundEnvironmentBlockBlock SoundEnvironmentValues {
      get {
        return soundEnvironmentValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundEnvironmentValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_environment";
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
soundEnvironmentValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundEnvironmentValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundEnvironmentValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundEnvironmentValues.WriteChildData(writer);
    }
    #endregion
    public class SoundEnvironmentBlockBlock : IBlock {
      private Pad _unnamed0;
      private ShortInteger _priority = new ShortInteger();
      private Pad _unnamed1;
      private Real _roomIntensity = new Real();
      private Real _roomIntensityHf = new Real();
      private Real _roomRolloff0To10 = new Real();
      private Real _decayTime1To20 = new Real();
      private Real _decayHfRatio1To2 = new Real();
      private Real _reflectionsIntensity = new Real();
      private Real _reflectionsDelay0To3 = new Real();
      private Real _reverbIntensity = new Real();
      private Real _reverbDelay0To1 = new Real();
      private Real _diffusion = new Real();
      private Real _density = new Real();
      private Real _hfReference20To20000 = new Real();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public SoundEnvironmentBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(16);
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
      public ShortInteger Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
        }
      }
      public Real RoomIntensity {
        get {
          return this._roomIntensity;
        }
        set {
          this._roomIntensity = value;
        }
      }
      public Real RoomIntensityHf {
        get {
          return this._roomIntensityHf;
        }
        set {
          this._roomIntensityHf = value;
        }
      }
      public Real RoomRolloff0To10 {
        get {
          return this._roomRolloff0To10;
        }
        set {
          this._roomRolloff0To10 = value;
        }
      }
      public Real DecayTime1To20 {
        get {
          return this._decayTime1To20;
        }
        set {
          this._decayTime1To20 = value;
        }
      }
      public Real DecayHfRatio1To2 {
        get {
          return this._decayHfRatio1To2;
        }
        set {
          this._decayHfRatio1To2 = value;
        }
      }
      public Real ReflectionsIntensity {
        get {
          return this._reflectionsIntensity;
        }
        set {
          this._reflectionsIntensity = value;
        }
      }
      public Real ReflectionsDelay0To3 {
        get {
          return this._reflectionsDelay0To3;
        }
        set {
          this._reflectionsDelay0To3 = value;
        }
      }
      public Real ReverbIntensity {
        get {
          return this._reverbIntensity;
        }
        set {
          this._reverbIntensity = value;
        }
      }
      public Real ReverbDelay0To1 {
        get {
          return this._reverbDelay0To1;
        }
        set {
          this._reverbDelay0To1 = value;
        }
      }
      public Real Diffusion {
        get {
          return this._diffusion;
        }
        set {
          this._diffusion = value;
        }
      }
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public Real HfReference20To20000 {
        get {
          return this._hfReference20To20000;
        }
        set {
          this._hfReference20To20000 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _priority.Read(reader);
        _unnamed1.Read(reader);
        _roomIntensity.Read(reader);
        _roomIntensityHf.Read(reader);
        _roomRolloff0To10.Read(reader);
        _decayTime1To20.Read(reader);
        _decayHfRatio1To2.Read(reader);
        _reflectionsIntensity.Read(reader);
        _reflectionsDelay0To3.Read(reader);
        _reverbIntensity.Read(reader);
        _reverbDelay0To1.Read(reader);
        _diffusion.Read(reader);
        _density.Read(reader);
        _hfReference20To20000.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _priority.Write(bw);
        _unnamed1.Write(bw);
        _roomIntensity.Write(bw);
        _roomIntensityHf.Write(bw);
        _roomRolloff0To10.Write(bw);
        _decayTime1To20.Write(bw);
        _decayHfRatio1To2.Write(bw);
        _reflectionsIntensity.Write(bw);
        _reflectionsDelay0To3.Write(bw);
        _reverbIntensity.Write(bw);
        _reverbDelay0To1.Write(bw);
        _diffusion.Write(bw);
        _density.Write(bw);
        _hfReference20To20000.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
