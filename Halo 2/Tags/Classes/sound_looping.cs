// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_looping'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_looping : Interfaces.Pool.Tag {
    private SoundLoopingBlockBlock soundLoopingValues = new SoundLoopingBlockBlock();
    public virtual SoundLoopingBlockBlock SoundLoopingValues {
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
    public class SoundLoopingBlockBlock : IBlock {
      private Flags _flags;
      private Real _martysMusicTime = new Real();
      private Real _unnamed0 = new Real();
      private Pad _unnamed1;
      private TagReference _unnamed2 = new TagReference();
      private Block _tracks = new Block();
      private Block _detailSounds = new Block();
      public BlockCollection<LoopingSoundTrackBlockBlock> _tracksList = new BlockCollection<LoopingSoundTrackBlockBlock>();
      public BlockCollection<LoopingSoundDetailBlockBlock> _detailSoundsList = new BlockCollection<LoopingSoundDetailBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundLoopingBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed1 = new Pad(8);
      }
      public BlockCollection<LoopingSoundTrackBlockBlock> Tracks {
        get {
          return this._tracksList;
        }
      }
      public BlockCollection<LoopingSoundDetailBlockBlock> DetailSounds {
        get {
          return this._detailSoundsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unnamed2.Value);
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
      public Real MartysMusicTime {
        get {
          return this._martysMusicTime;
        }
        set {
          this._martysMusicTime = value;
        }
      }
      public Real unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public TagReference unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _martysMusicTime.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _tracks.Read(reader);
        _detailSounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _unnamed2.ReadString(reader);
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks.Add(new LoopingSoundTrackBlockBlock());
          Tracks[x].Read(reader);
        }
        for (x = 0; (x < _tracks.Count); x = (x + 1)) {
          Tracks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds.Add(new LoopingSoundDetailBlockBlock());
          DetailSounds[x].Read(reader);
        }
        for (x = 0; (x < _detailSounds.Count); x = (x + 1)) {
          DetailSounds[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _martysMusicTime.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_tracks.Count = Tracks.Count;
        _tracks.Write(bw);
_detailSounds.Count = DetailSounds.Count;
        _detailSounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _unnamed2.WriteString(writer);
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
    public class LoopingSoundTrackBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _flags;
      private Real _gain = new Real();
      private Real _fadeInDuration = new Real();
      private Real _fadeOutDuration = new Real();
      private TagReference _in = new TagReference();
      private TagReference _loop = new TagReference();
      private TagReference _out = new TagReference();
      private TagReference _altLoop = new TagReference();
      private TagReference _altOut = new TagReference();
      private Enum _outputEffect;
      private Pad _unnamed0;
      private TagReference _altTransIn = new TagReference();
      private TagReference _altTransOut = new TagReference();
      private Real _altCrossfadeDuration = new Real();
      private Real _altFadeOutDuration = new Real();
public event System.EventHandler BlockNameChanged;
      public LoopingSoundTrackBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._outputEffect = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_in.Value);
references.Add(_loop.Value);
references.Add(_out.Value);
references.Add(_altLoop.Value);
references.Add(_altOut.Value);
references.Add(_altTransIn.Value);
references.Add(_altTransOut.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public Real Gain {
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
      public TagReference In {
        get {
          return this._in;
        }
        set {
          this._in = value;
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
      public TagReference Out {
        get {
          return this._out;
        }
        set {
          this._out = value;
        }
      }
      public TagReference AltLoop {
        get {
          return this._altLoop;
        }
        set {
          this._altLoop = value;
        }
      }
      public TagReference AltOut {
        get {
          return this._altOut;
        }
        set {
          this._altOut = value;
        }
      }
      public Enum OutputEffect {
        get {
          return this._outputEffect;
        }
        set {
          this._outputEffect = value;
        }
      }
      public TagReference AltTransIn {
        get {
          return this._altTransIn;
        }
        set {
          this._altTransIn = value;
        }
      }
      public TagReference AltTransOut {
        get {
          return this._altTransOut;
        }
        set {
          this._altTransOut = value;
        }
      }
      public Real AltCrossfadeDuration {
        get {
          return this._altCrossfadeDuration;
        }
        set {
          this._altCrossfadeDuration = value;
        }
      }
      public Real AltFadeOutDuration {
        get {
          return this._altFadeOutDuration;
        }
        set {
          this._altFadeOutDuration = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _gain.Read(reader);
        _fadeInDuration.Read(reader);
        _fadeOutDuration.Read(reader);
        _in.Read(reader);
        _loop.Read(reader);
        _out.Read(reader);
        _altLoop.Read(reader);
        _altOut.Read(reader);
        _outputEffect.Read(reader);
        _unnamed0.Read(reader);
        _altTransIn.Read(reader);
        _altTransOut.Read(reader);
        _altCrossfadeDuration.Read(reader);
        _altFadeOutDuration.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _in.ReadString(reader);
        _loop.ReadString(reader);
        _out.ReadString(reader);
        _altLoop.ReadString(reader);
        _altOut.ReadString(reader);
        _altTransIn.ReadString(reader);
        _altTransOut.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _gain.Write(bw);
        _fadeInDuration.Write(bw);
        _fadeOutDuration.Write(bw);
        _in.Write(bw);
        _loop.Write(bw);
        _out.Write(bw);
        _altLoop.Write(bw);
        _altOut.Write(bw);
        _outputEffect.Write(bw);
        _unnamed0.Write(bw);
        _altTransIn.Write(bw);
        _altTransOut.Write(bw);
        _altCrossfadeDuration.Write(bw);
        _altFadeOutDuration.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _in.WriteString(writer);
        _loop.WriteString(writer);
        _out.WriteString(writer);
        _altLoop.WriteString(writer);
        _altOut.WriteString(writer);
        _altTransIn.WriteString(writer);
        _altTransOut.WriteString(writer);
      }
    }
    public class LoopingSoundDetailBlockBlock : IBlock {
      private StringId _name = new StringId();
      private TagReference _sound = new TagReference();
      private RealBounds _randomPeriodBounds = new RealBounds();
      private Real _unnamed0 = new Real();
      private Flags _flags;
      private AngleBounds _yawBounds = new AngleBounds();
      private AngleBounds _pitchBounds = new AngleBounds();
      private RealBounds _distanceBounds = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public LoopingSoundDetailBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
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
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public Real unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
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
        _name.Read(reader);
        _sound.Read(reader);
        _randomPeriodBounds.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _yawBounds.Read(reader);
        _pitchBounds.Read(reader);
        _distanceBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _sound.Write(bw);
        _randomPeriodBounds.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _yawBounds.Write(bw);
        _pitchBounds.Write(bw);
        _distanceBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _sound.WriteString(writer);
      }
    }
  }
}
