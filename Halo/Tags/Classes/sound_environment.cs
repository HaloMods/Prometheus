// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'sound_environment'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class sound_environment : Interfaces.Pool.Tag {
    private SoundEnvironmentBlock soundEnvironmentValues = new SoundEnvironmentBlock();
    public virtual SoundEnvironmentBlock SoundEnvironmentValues {
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
    public class SoundEnvironmentBlock : IBlock {
      private Pad _unnamed;
      private ShortInteger _priority = new ShortInteger();
      private Pad _unnamed2;
      private RealFraction _roomIntensity = new RealFraction();
      private RealFraction _roomIntensityHf = new RealFraction();
      private Real _roomRolloff0To10 = new Real();
      private Real _decayTime_Pt1To20 = new Real();
      private Real _decayHfRatio_Pt1To2 = new Real();
      private RealFraction _reflectionsIntensity = new RealFraction();
      private Real _reflectionsDelay0To_Pt3 = new Real();
      private RealFraction _reverbIntensity = new RealFraction();
      private Real _reverbDelay0To_Pt1 = new Real();
      private Real _diffusion = new Real();
      private Real _density = new Real();
      private Real _hfReference20To2 = new Real();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public SoundEnvironmentBlock() {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(16);
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
      public RealFraction RoomIntensity {
        get {
          return this._roomIntensity;
        }
        set {
          this._roomIntensity = value;
        }
      }
      public RealFraction RoomIntensityHf {
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
      public Real DecayTime_Pt1To20 {
        get {
          return this._decayTime_Pt1To20;
        }
        set {
          this._decayTime_Pt1To20 = value;
        }
      }
      public Real DecayHfRatio_Pt1To2 {
        get {
          return this._decayHfRatio_Pt1To2;
        }
        set {
          this._decayHfRatio_Pt1To2 = value;
        }
      }
      public RealFraction ReflectionsIntensity {
        get {
          return this._reflectionsIntensity;
        }
        set {
          this._reflectionsIntensity = value;
        }
      }
      public Real ReflectionsDelay0To_Pt3 {
        get {
          return this._reflectionsDelay0To_Pt3;
        }
        set {
          this._reflectionsDelay0To_Pt3 = value;
        }
      }
      public RealFraction ReverbIntensity {
        get {
          return this._reverbIntensity;
        }
        set {
          this._reverbIntensity = value;
        }
      }
      public Real ReverbDelay0To_Pt1 {
        get {
          return this._reverbDelay0To_Pt1;
        }
        set {
          this._reverbDelay0To_Pt1 = value;
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
      public Real HfReference20To2 {
        get {
          return this._hfReference20To2;
        }
        set {
          this._hfReference20To2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _priority.Read(reader);
        _unnamed2.Read(reader);
        _roomIntensity.Read(reader);
        _roomIntensityHf.Read(reader);
        _roomRolloff0To10.Read(reader);
        _decayTime_Pt1To20.Read(reader);
        _decayHfRatio_Pt1To2.Read(reader);
        _reflectionsIntensity.Read(reader);
        _reflectionsDelay0To_Pt3.Read(reader);
        _reverbIntensity.Read(reader);
        _reverbDelay0To_Pt1.Read(reader);
        _diffusion.Read(reader);
        _density.Read(reader);
        _hfReference20To2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _priority.Write(bw);
        _unnamed2.Write(bw);
        _roomIntensity.Write(bw);
        _roomIntensityHf.Write(bw);
        _roomRolloff0To10.Write(bw);
        _decayTime_Pt1To20.Write(bw);
        _decayHfRatio_Pt1To2.Write(bw);
        _reflectionsIntensity.Write(bw);
        _reflectionsDelay0To_Pt3.Write(bw);
        _reverbIntensity.Write(bw);
        _reverbDelay0To_Pt1.Write(bw);
        _diffusion.Write(bw);
        _density.Write(bw);
        _hfReference20To2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
