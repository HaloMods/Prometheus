// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_classes'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_classes : Interfaces.Pool.Tag {
    private SoundClassesBlockBlock soundClassesValues = new SoundClassesBlockBlock();
    public virtual SoundClassesBlockBlock SoundClassesValues {
      get {
        return soundClassesValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundClassesValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_classes";
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
soundClassesValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundClassesValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundClassesValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundClassesValues.WriteChildData(writer);
    }
    #endregion
    public class SoundClassesBlockBlock : IBlock {
      private Block _soundClasses = new Block();
      public BlockCollection<SoundClassBlockBlock> _soundClassesList = new BlockCollection<SoundClassBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundClassesBlockBlock() {
      }
      public BlockCollection<SoundClassBlockBlock> SoundClasses {
        get {
          return this._soundClassesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SoundClasses.BlockCount; x++)
{
  IBlock block = SoundClasses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundClasses.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _soundClasses.Count); x = (x + 1)) {
          SoundClasses.Add(new SoundClassBlockBlock());
          SoundClasses[x].Read(reader);
        }
        for (x = 0; (x < _soundClasses.Count); x = (x + 1)) {
          SoundClasses[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_soundClasses.Count = SoundClasses.Count;
        _soundClasses.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _soundClasses.Count); x = (x + 1)) {
          SoundClasses[x].Write(writer);
        }
        for (x = 0; (x < _soundClasses.Count); x = (x + 1)) {
          SoundClasses[x].WriteChildData(writer);
        }
      }
    }
    public class SoundClassBlockBlock : IBlock {
      private ShortInteger _maxSoundsPerTag116 = new ShortInteger();
      private ShortInteger _maxSoundsPerObject116 = new ShortInteger();
      private LongInteger _preemptionTime = new LongInteger();
      private Flags _internalFlags;
      private Flags _flags;
      private ShortInteger _priority = new ShortInteger();
      private Enum _cacheMissMode;
      private Real _reverbGain = new Real();
      private Real _overrideSpeakerGain = new Real();
      private RealBounds _distanceBounds = new RealBounds();
      private RealBounds _gainBounds = new RealBounds();
      private Real _cutsceneDucking = new Real();
      private Real _cutsceneDuckingFadeInTime = new Real();
      private Real _cutsceneDuckingSustainTime = new Real();
      private Real _cutsceneDuckingFadeOutTime = new Real();
      private Real _scriptedDialogDucking = new Real();
      private Real _scriptedDialogDuckingFadeInTime = new Real();
      private Real _scriptedDialogDuckingSustainTime = new Real();
      private Real _scriptedDialogDuckingFadeOutTime = new Real();
      private Real _dopplerFactor = new Real();
      private Enum _stereoPlaybackType;
      private Pad _unnamed0;
      private Real _transmissionMultiplier = new Real();
      private Real _obstructionMaxBend = new Real();
      private Real _occlusionMaxBend = new Real();
public event System.EventHandler BlockNameChanged;
      public SoundClassBlockBlock() {
        this._internalFlags = new Flags(2);
        this._flags = new Flags(2);
        this._cacheMissMode = new Enum(2);
        this._stereoPlaybackType = new Enum(1);
        this._unnamed0 = new Pad(3);
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
      public ShortInteger MaxSoundsPerTag116 {
        get {
          return this._maxSoundsPerTag116;
        }
        set {
          this._maxSoundsPerTag116 = value;
        }
      }
      public ShortInteger MaxSoundsPerObject116 {
        get {
          return this._maxSoundsPerObject116;
        }
        set {
          this._maxSoundsPerObject116 = value;
        }
      }
      public LongInteger PreemptionTime {
        get {
          return this._preemptionTime;
        }
        set {
          this._preemptionTime = value;
        }
      }
      public Flags InternalFlags {
        get {
          return this._internalFlags;
        }
        set {
          this._internalFlags = value;
        }
      }
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public Enum CacheMissMode {
        get {
          return this._cacheMissMode;
        }
        set {
          this._cacheMissMode = value;
        }
      }
      public Real ReverbGain {
        get {
          return this._reverbGain;
        }
        set {
          this._reverbGain = value;
        }
      }
      public Real OverrideSpeakerGain {
        get {
          return this._overrideSpeakerGain;
        }
        set {
          this._overrideSpeakerGain = value;
        }
      }
      public RealBounds DistanceBounds {
        get {
          return this._distanceBounds;
        }
        set {
          this._distanceBounds = value;
        }
      }
      public RealBounds GainBounds {
        get {
          return this._gainBounds;
        }
        set {
          this._gainBounds = value;
        }
      }
      public Real CutsceneDucking {
        get {
          return this._cutsceneDucking;
        }
        set {
          this._cutsceneDucking = value;
        }
      }
      public Real CutsceneDuckingFadeInTime {
        get {
          return this._cutsceneDuckingFadeInTime;
        }
        set {
          this._cutsceneDuckingFadeInTime = value;
        }
      }
      public Real CutsceneDuckingSustainTime {
        get {
          return this._cutsceneDuckingSustainTime;
        }
        set {
          this._cutsceneDuckingSustainTime = value;
        }
      }
      public Real CutsceneDuckingFadeOutTime {
        get {
          return this._cutsceneDuckingFadeOutTime;
        }
        set {
          this._cutsceneDuckingFadeOutTime = value;
        }
      }
      public Real ScriptedDialogDucking {
        get {
          return this._scriptedDialogDucking;
        }
        set {
          this._scriptedDialogDucking = value;
        }
      }
      public Real ScriptedDialogDuckingFadeInTime {
        get {
          return this._scriptedDialogDuckingFadeInTime;
        }
        set {
          this._scriptedDialogDuckingFadeInTime = value;
        }
      }
      public Real ScriptedDialogDuckingSustainTime {
        get {
          return this._scriptedDialogDuckingSustainTime;
        }
        set {
          this._scriptedDialogDuckingSustainTime = value;
        }
      }
      public Real ScriptedDialogDuckingFadeOutTime {
        get {
          return this._scriptedDialogDuckingFadeOutTime;
        }
        set {
          this._scriptedDialogDuckingFadeOutTime = value;
        }
      }
      public Real DopplerFactor {
        get {
          return this._dopplerFactor;
        }
        set {
          this._dopplerFactor = value;
        }
      }
      public Enum StereoPlaybackType {
        get {
          return this._stereoPlaybackType;
        }
        set {
          this._stereoPlaybackType = value;
        }
      }
      public Real TransmissionMultiplier {
        get {
          return this._transmissionMultiplier;
        }
        set {
          this._transmissionMultiplier = value;
        }
      }
      public Real ObstructionMaxBend {
        get {
          return this._obstructionMaxBend;
        }
        set {
          this._obstructionMaxBend = value;
        }
      }
      public Real OcclusionMaxBend {
        get {
          return this._occlusionMaxBend;
        }
        set {
          this._occlusionMaxBend = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _maxSoundsPerTag116.Read(reader);
        _maxSoundsPerObject116.Read(reader);
        _preemptionTime.Read(reader);
        _internalFlags.Read(reader);
        _flags.Read(reader);
        _priority.Read(reader);
        _cacheMissMode.Read(reader);
        _reverbGain.Read(reader);
        _overrideSpeakerGain.Read(reader);
        _distanceBounds.Read(reader);
        _gainBounds.Read(reader);
        _cutsceneDucking.Read(reader);
        _cutsceneDuckingFadeInTime.Read(reader);
        _cutsceneDuckingSustainTime.Read(reader);
        _cutsceneDuckingFadeOutTime.Read(reader);
        _scriptedDialogDucking.Read(reader);
        _scriptedDialogDuckingFadeInTime.Read(reader);
        _scriptedDialogDuckingSustainTime.Read(reader);
        _scriptedDialogDuckingFadeOutTime.Read(reader);
        _dopplerFactor.Read(reader);
        _stereoPlaybackType.Read(reader);
        _unnamed0.Read(reader);
        _transmissionMultiplier.Read(reader);
        _obstructionMaxBend.Read(reader);
        _occlusionMaxBend.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _maxSoundsPerTag116.Write(bw);
        _maxSoundsPerObject116.Write(bw);
        _preemptionTime.Write(bw);
        _internalFlags.Write(bw);
        _flags.Write(bw);
        _priority.Write(bw);
        _cacheMissMode.Write(bw);
        _reverbGain.Write(bw);
        _overrideSpeakerGain.Write(bw);
        _distanceBounds.Write(bw);
        _gainBounds.Write(bw);
        _cutsceneDucking.Write(bw);
        _cutsceneDuckingFadeInTime.Write(bw);
        _cutsceneDuckingSustainTime.Write(bw);
        _cutsceneDuckingFadeOutTime.Write(bw);
        _scriptedDialogDucking.Write(bw);
        _scriptedDialogDuckingFadeInTime.Write(bw);
        _scriptedDialogDuckingSustainTime.Write(bw);
        _scriptedDialogDuckingFadeOutTime.Write(bw);
        _dopplerFactor.Write(bw);
        _stereoPlaybackType.Write(bw);
        _unnamed0.Write(bw);
        _transmissionMultiplier.Write(bw);
        _obstructionMaxBend.Write(bw);
        _occlusionMaxBend.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
