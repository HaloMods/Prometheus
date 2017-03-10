// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'sound_looping'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class sound_looping : Interfaces.Pool.Tag {
    private SoundLoopingBlock soundLoopingValues = new SoundLoopingBlock();
    public virtual SoundLoopingBlock SoundLoopingValues {
      get {
        return soundLoopingValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundLoopingValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_looping";
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
soundLoopingValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundLoopingValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundLoopingValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundLoopingValues.WriteChildData(writer);
    }
    #endregion
    public class SoundLoopingBlock : IBlock {
      private Flags _flags;
      private Real _detailSoundPeriod = new Real();
      private Pad _unnamed;
      private Real _detailSoundPeriod2 = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _continuousDamageEffect = new TagReference();
      private Block _tracks = new Block();
      private Block _detailSounds = new Block();
      public BlockCollection<LoopingSoundTrackBlock> _tracksList = new BlockCollection<LoopingSoundTrackBlock>();
      public BlockCollection<LoopingSoundDetailBlock> _detailSoundsList = new BlockCollection<LoopingSoundDetailBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundLoopingBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(8);
        this._unnamed3 = new Pad(16);
      }
      public BlockCollection<LoopingSoundTrackBlock> Tracks {
        get {
          return this._tracksList;
        }
      }
      public BlockCollection<LoopingSoundDetailBlock> DetailSounds {
        get {
          return this._detailSoundsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_continuousDamageEffect.Value);
for (int x=0; x<Tracks.BlockCount; x++)
{
  IBlock block = Tracks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DetailSounds.BlockCount; x++)
{
  IBlock block = DetailSounds.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real DetailSoundPeriod {
        get {
          return this._detailSoundPeriod;
        }
        set {
          this._detailSoundPeriod = value;
        }
      }
      public Real DetailSoundPeriod2 {
        get {
          return this._detailSoundPeriod2;
        }
        set {
          this._detailSoundPeriod2 = value;
        }
      }
      public TagReference ContinuousDamageEffect {
        get {
          return this._continuousDamageEffect;
        }
        set {
          this._continuousDamageEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _detailSoundPeriod.Read(reader);
        _unnamed.Read(reader);
        _detailSoundPeriod2.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _continuousDamageEffect.Read(reader);
        _tracks.Read(reader);
        _detailSounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _continuousDamageEffect.ReadString(reader);
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks.Add(new LoopingSoundTrackBlock());
          Tracks[x].Read(reader);
        }
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds.Add(new LoopingSoundDetailBlock());
          DetailSounds[x].Read(reader);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _detailSoundPeriod.Write(bw);
        _unnamed.Write(bw);
        _detailSoundPeriod2.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _continuousDamageEffect.Write(bw);
_tracks.Count = Tracks.Count;
        _tracks.Write(bw);
_detailSounds.Count = DetailSounds.Count;
        _detailSounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _continuousDamageEffect.WriteString(writer);
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks[x].Write(writer);
        }
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds[x].Write(writer);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds[x].WriteChildData(writer);
        }
      }
    }
    public class LoopingSoundTrackBlock : IBlock {
      private Flags _flags;
      private RealFraction _gain = new RealFraction();
      private Real _fadeInDuration = new Real();
      private Real _fadeOutDuration = new Real();
      private Pad _unnamed;
      private TagReference _start = new TagReference();
      private TagReference _loop = new TagReference();
      private TagReference _end = new TagReference();
      private Pad _unnamed2;
      private TagReference _alternateLoop = new TagReference();
      private TagReference _alternateEnd = new TagReference();
public event System.EventHandler BlockNameChanged;
      public LoopingSoundTrackBlock() {
if (this._loop is System.ComponentModel.INotifyPropertyChanged)
  (this._loop as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
        this._unnamed2 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_start.Value);
references.Add(_loop.Value);
references.Add(_end.Value);
references.Add(_alternateLoop.Value);
references.Add(_alternateEnd.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _loop.ToString();
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
      public RealFraction Gain {
        get {
          return this._gain;
        }
        set {
          this._gain = value;
        }
      }
      public Real FadeInDuration {
        get {
          return this._fadeInDuration;
        }
        set {
          this._fadeInDuration = value;
        }
      }
      public Real FadeOutDuration {
        get {
          return this._fadeOutDuration;
        }
        set {
          this._fadeOutDuration = value;
        }
      }
      public TagReference Start {
        get {
          return this._start;
        }
        set {
          this._start = value;
        }
      }
      public TagReference Loop {
        get {
          return this._loop;
        }
        set {
          this._loop = value;
        }
      }
      public TagReference End {
        get {
          return this._end;
        }
        set {
          this._end = value;
        }
      }
      public TagReference AlternateLoop {
        get {
          return this._alternateLoop;
        }
        set {
          this._alternateLoop = value;
        }
      }
      public TagReference AlternateEnd {
        get {
          return this._alternateEnd;
        }
        set {
          this._alternateEnd = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _gain.Read(reader);
        _fadeInDuration.Read(reader);
        _fadeOutDuration.Read(reader);
        _unnamed.Read(reader);
        _start.Read(reader);
        _loop.Read(reader);
        _end.Read(reader);
        _unnamed2.Read(reader);
        _alternateLoop.Read(reader);
        _alternateEnd.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _start.ReadString(reader);
        _loop.ReadString(reader);
        _end.ReadString(reader);
        _alternateLoop.ReadString(reader);
        _alternateEnd.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _gain.Write(bw);
        _fadeInDuration.Write(bw);
        _fadeOutDuration.Write(bw);
        _unnamed.Write(bw);
        _start.Write(bw);
        _loop.Write(bw);
        _end.Write(bw);
        _unnamed2.Write(bw);
        _alternateLoop.Write(bw);
        _alternateEnd.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _start.WriteString(writer);
        _loop.WriteString(writer);
        _end.WriteString(writer);
        _alternateLoop.WriteString(writer);
        _alternateEnd.WriteString(writer);
      }
    }
    public class LoopingSoundDetailBlock : IBlock {
      private TagReference _sound = new TagReference();
      private RealBounds _randomPeriodBounds = new RealBounds();
      private RealFraction _gain = new RealFraction();
      private Flags _flags;
      private Pad _unnamed;
      private AngleBounds _yawBounds = new AngleBounds();
      private AngleBounds _pitchBounds = new AngleBounds();
      private RealBounds _distanceBounds = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public LoopingSoundDetailBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public RealBounds RandomPeriodBounds {
        get {
          return this._randomPeriodBounds;
        }
        set {
          this._randomPeriodBounds = value;
        }
      }
      public RealFraction Gain {
        get {
          return this._gain;
        }
        set {
          this._gain = value;
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
      public AngleBounds YawBounds {
        get {
          return this._yawBounds;
        }
        set {
          this._yawBounds = value;
        }
      }
      public AngleBounds PitchBounds {
        get {
          return this._pitchBounds;
        }
        set {
          this._pitchBounds = value;
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
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
        _randomPeriodBounds.Read(reader);
        _gain.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _yawBounds.Read(reader);
        _pitchBounds.Read(reader);
        _distanceBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _randomPeriodBounds.Write(bw);
        _gain.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _yawBounds.Write(bw);
        _pitchBounds.Write(bw);
        _distanceBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
  }
}
