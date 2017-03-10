// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_mix'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_mix : Interfaces.Pool.Tag {
    private SoundGlobalMixStructBlockBlock soundMixValues = new SoundGlobalMixStructBlockBlock();
    public virtual SoundGlobalMixStructBlockBlock SoundMixValues {
      get {
        return soundMixValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundMixValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_mix";
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
soundMixValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundMixValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundMixValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundMixValues.WriteChildData(writer);
    }
    #endregion
    public class SoundGlobalMixStructBlockBlock : IBlock {
      private Real _leftStereoGain = new Real();
      private Real _rightStereoGain = new Real();
      private Real _leftStereoGain2 = new Real();
      private Real _rightStereoGain2 = new Real();
      private Real _leftStereoGain3 = new Real();
      private Real _rightStereoGain3 = new Real();
      private Real _frontSpeakerGain = new Real();
      private Real _rearSpeakerGain = new Real();
      private Real _frontSpeakerGain2 = new Real();
      private Real _rearSpeakerGain2 = new Real();
      private Real _monoUnspatializedGain = new Real();
      private Real _stereoTo3dGain = new Real();
      private Real _rearSurroundToFrontStereoGain = new Real();
      private Real _frontSpeakerGain3 = new Real();
      private Real _centerSpeakerGain = new Real();
      private Real _frontSpeakerGain4 = new Real();
      private Real _centerSpeakerGain2 = new Real();
      private Real _stereoUnspatializedGain = new Real();
      private Real _soloPlayerFadeOutDelay = new Real();
      private Real _soloPlayerFadeOutTime = new Real();
      private Real _soloPlayerFadeInTime = new Real();
      private Real _gameMusicFadeOutTime = new Real();
public event System.EventHandler BlockNameChanged;
      public SoundGlobalMixStructBlockBlock() {
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
      public Real LeftStereoGain {
        get {
          return this._leftStereoGain;
        }
        set {
          this._leftStereoGain = value;
        }
      }
      public Real RightStereoGain {
        get {
          return this._rightStereoGain;
        }
        set {
          this._rightStereoGain = value;
        }
      }
      public Real LeftStereoGain2 {
        get {
          return this._leftStereoGain2;
        }
        set {
          this._leftStereoGain2 = value;
        }
      }
      public Real RightStereoGain2 {
        get {
          return this._rightStereoGain2;
        }
        set {
          this._rightStereoGain2 = value;
        }
      }
      public Real LeftStereoGain3 {
        get {
          return this._leftStereoGain3;
        }
        set {
          this._leftStereoGain3 = value;
        }
      }
      public Real RightStereoGain3 {
        get {
          return this._rightStereoGain3;
        }
        set {
          this._rightStereoGain3 = value;
        }
      }
      public Real FrontSpeakerGain {
        get {
          return this._frontSpeakerGain;
        }
        set {
          this._frontSpeakerGain = value;
        }
      }
      public Real RearSpeakerGain {
        get {
          return this._rearSpeakerGain;
        }
        set {
          this._rearSpeakerGain = value;
        }
      }
      public Real FrontSpeakerGain2 {
        get {
          return this._frontSpeakerGain2;
        }
        set {
          this._frontSpeakerGain2 = value;
        }
      }
      public Real RearSpeakerGain2 {
        get {
          return this._rearSpeakerGain2;
        }
        set {
          this._rearSpeakerGain2 = value;
        }
      }
      public Real MonoUnspatializedGain {
        get {
          return this._monoUnspatializedGain;
        }
        set {
          this._monoUnspatializedGain = value;
        }
      }
      public Real StereoTo3dGain {
        get {
          return this._stereoTo3dGain;
        }
        set {
          this._stereoTo3dGain = value;
        }
      }
      public Real RearSurroundToFrontStereoGain {
        get {
          return this._rearSurroundToFrontStereoGain;
        }
        set {
          this._rearSurroundToFrontStereoGain = value;
        }
      }
      public Real FrontSpeakerGain3 {
        get {
          return this._frontSpeakerGain3;
        }
        set {
          this._frontSpeakerGain3 = value;
        }
      }
      public Real CenterSpeakerGain {
        get {
          return this._centerSpeakerGain;
        }
        set {
          this._centerSpeakerGain = value;
        }
      }
      public Real FrontSpeakerGain4 {
        get {
          return this._frontSpeakerGain4;
        }
        set {
          this._frontSpeakerGain4 = value;
        }
      }
      public Real CenterSpeakerGain2 {
        get {
          return this._centerSpeakerGain2;
        }
        set {
          this._centerSpeakerGain2 = value;
        }
      }
      public Real StereoUnspatializedGain {
        get {
          return this._stereoUnspatializedGain;
        }
        set {
          this._stereoUnspatializedGain = value;
        }
      }
      public Real SoloPlayerFadeOutDelay {
        get {
          return this._soloPlayerFadeOutDelay;
        }
        set {
          this._soloPlayerFadeOutDelay = value;
        }
      }
      public Real SoloPlayerFadeOutTime {
        get {
          return this._soloPlayerFadeOutTime;
        }
        set {
          this._soloPlayerFadeOutTime = value;
        }
      }
      public Real SoloPlayerFadeInTime {
        get {
          return this._soloPlayerFadeInTime;
        }
        set {
          this._soloPlayerFadeInTime = value;
        }
      }
      public Real GameMusicFadeOutTime {
        get {
          return this._gameMusicFadeOutTime;
        }
        set {
          this._gameMusicFadeOutTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _leftStereoGain.Read(reader);
        _rightStereoGain.Read(reader);
        _leftStereoGain2.Read(reader);
        _rightStereoGain2.Read(reader);
        _leftStereoGain3.Read(reader);
        _rightStereoGain3.Read(reader);
        _frontSpeakerGain.Read(reader);
        _rearSpeakerGain.Read(reader);
        _frontSpeakerGain2.Read(reader);
        _rearSpeakerGain2.Read(reader);
        _monoUnspatializedGain.Read(reader);
        _stereoTo3dGain.Read(reader);
        _rearSurroundToFrontStereoGain.Read(reader);
        _frontSpeakerGain3.Read(reader);
        _centerSpeakerGain.Read(reader);
        _frontSpeakerGain4.Read(reader);
        _centerSpeakerGain2.Read(reader);
        _stereoUnspatializedGain.Read(reader);
        _soloPlayerFadeOutDelay.Read(reader);
        _soloPlayerFadeOutTime.Read(reader);
        _soloPlayerFadeInTime.Read(reader);
        _gameMusicFadeOutTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _leftStereoGain.Write(bw);
        _rightStereoGain.Write(bw);
        _leftStereoGain2.Write(bw);
        _rightStereoGain2.Write(bw);
        _leftStereoGain3.Write(bw);
        _rightStereoGain3.Write(bw);
        _frontSpeakerGain.Write(bw);
        _rearSpeakerGain.Write(bw);
        _frontSpeakerGain2.Write(bw);
        _rearSpeakerGain2.Write(bw);
        _monoUnspatializedGain.Write(bw);
        _stereoTo3dGain.Write(bw);
        _rearSurroundToFrontStereoGain.Write(bw);
        _frontSpeakerGain3.Write(bw);
        _centerSpeakerGain.Write(bw);
        _frontSpeakerGain4.Write(bw);
        _centerSpeakerGain2.Write(bw);
        _stereoUnspatializedGain.Write(bw);
        _soloPlayerFadeOutDelay.Write(bw);
        _soloPlayerFadeOutTime.Write(bw);
        _soloPlayerFadeInTime.Write(bw);
        _gameMusicFadeOutTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
