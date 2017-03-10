// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'sound'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class sound : Interfaces.Pool.Tag {
    private SoundBlock soundValues = new SoundBlock();
    public virtual SoundBlock SoundValues {
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
    public class SoundBlock : IBlock {
      private Flags _flags;
      private Enum _class = new Enum();
      private Enum _sampleRate = new Enum();
      private Real _minimumDistance = new Real();
      private Real _maximumDistance = new Real();
      private RealFraction _skipFraction = new RealFraction();
      private RealBounds _randomPitchBounds = new RealBounds();
      private Angle _innerConeAngle = new Angle();
      private Angle _outerConeAngle = new Angle();
      private RealFraction _outerConeGain = new RealFraction();
      private Real _gainModifier = new Real();
      private Real _maximumBendPerSecond = new Real();
      private Pad _unnamed;
      private Real _skipFractionModifier = new Real();
      private Real _gainModifier2 = new Real();
      private Real _pitchModifier = new Real();
      private Pad _unnamed2;
      private Real _skipFractionModifier2 = new Real();
      private Real _gainModifier3 = new Real();
      private Real _pitchModifier2 = new Real();
      private Pad _unnamed3;
      private Enum _encoding = new Enum();
      private Enum _compression = new Enum();
      private TagReference _promotionSound = new TagReference();
      private ShortInteger _promotionCount = new ShortInteger();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Block _pitchRanges = new Block();
      public BlockCollection<SoundPitchRangeBlock> _pitchRangesList = new BlockCollection<SoundPitchRangeBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(12);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
      }
      public BlockCollection<SoundPitchRangeBlock> PitchRanges {
        get {
          return this._pitchRangesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_promotionSound.Value);
for (int x=0; x<PitchRanges.BlockCount; x++)
{
  IBlock block = PitchRanges.GetBlock(x);
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
      public Enum Class {
        get {
          return this._class;
        }
        set {
          this._class = value;
        }
      }
      public Enum SampleRate {
        get {
          return this._sampleRate;
        }
        set {
          this._sampleRate = value;
        }
      }
      public Real MinimumDistance {
        get {
          return this._minimumDistance;
        }
        set {
          this._minimumDistance = value;
        }
      }
      public Real MaximumDistance {
        get {
          return this._maximumDistance;
        }
        set {
          this._maximumDistance = value;
        }
      }
      public RealFraction SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public RealBounds RandomPitchBounds {
        get {
          return this._randomPitchBounds;
        }
        set {
          this._randomPitchBounds = value;
        }
      }
      public Angle InnerConeAngle {
        get {
          return this._innerConeAngle;
        }
        set {
          this._innerConeAngle = value;
        }
      }
      public Angle OuterConeAngle {
        get {
          return this._outerConeAngle;
        }
        set {
          this._outerConeAngle = value;
        }
      }
      public RealFraction OuterConeGain {
        get {
          return this._outerConeGain;
        }
        set {
          this._outerConeGain = value;
        }
      }
      public Real GainModifier {
        get {
          return this._gainModifier;
        }
        set {
          this._gainModifier = value;
        }
      }
      public Real MaximumBendPerSecond {
        get {
          return this._maximumBendPerSecond;
        }
        set {
          this._maximumBendPerSecond = value;
        }
      }
      public Real SkipFractionModifier {
        get {
          return this._skipFractionModifier;
        }
        set {
          this._skipFractionModifier = value;
        }
      }
      public Real GainModifier2 {
        get {
          return this._gainModifier2;
        }
        set {
          this._gainModifier2 = value;
        }
      }
      public Real PitchModifier {
        get {
          return this._pitchModifier;
        }
        set {
          this._pitchModifier = value;
        }
      }
      public Real SkipFractionModifier2 {
        get {
          return this._skipFractionModifier2;
        }
        set {
          this._skipFractionModifier2 = value;
        }
      }
      public Real GainModifier3 {
        get {
          return this._gainModifier3;
        }
        set {
          this._gainModifier3 = value;
        }
      }
      public Real PitchModifier2 {
        get {
          return this._pitchModifier2;
        }
        set {
          this._pitchModifier2 = value;
        }
      }
      public Enum Encoding {
        get {
          return this._encoding;
        }
        set {
          this._encoding = value;
        }
      }
      public Enum Compression {
        get {
          return this._compression;
        }
        set {
          this._compression = value;
        }
      }
      public TagReference PromotionSound {
        get {
          return this._promotionSound;
        }
        set {
          this._promotionSound = value;
        }
      }
      public ShortInteger PromotionCount {
        get {
          return this._promotionCount;
        }
        set {
          this._promotionCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _class.Read(reader);
        _sampleRate.Read(reader);
        _minimumDistance.Read(reader);
        _maximumDistance.Read(reader);
        _skipFraction.Read(reader);
        _randomPitchBounds.Read(reader);
        _innerConeAngle.Read(reader);
        _outerConeAngle.Read(reader);
        _outerConeGain.Read(reader);
        _gainModifier.Read(reader);
        _maximumBendPerSecond.Read(reader);
        _unnamed.Read(reader);
        _skipFractionModifier.Read(reader);
        _gainModifier2.Read(reader);
        _pitchModifier.Read(reader);
        _unnamed2.Read(reader);
        _skipFractionModifier2.Read(reader);
        _gainModifier3.Read(reader);
        _pitchModifier2.Read(reader);
        _unnamed3.Read(reader);
        _encoding.Read(reader);
        _compression.Read(reader);
        _promotionSound.Read(reader);
        _promotionCount.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _pitchRanges.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _promotionSound.ReadString(reader);
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges.Add(new SoundPitchRangeBlock());
          PitchRanges[x].Read(reader);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _class.Write(bw);
        _sampleRate.Write(bw);
        _minimumDistance.Write(bw);
        _maximumDistance.Write(bw);
        _skipFraction.Write(bw);
        _randomPitchBounds.Write(bw);
        _innerConeAngle.Write(bw);
        _outerConeAngle.Write(bw);
        _outerConeGain.Write(bw);
        _gainModifier.Write(bw);
        _maximumBendPerSecond.Write(bw);
        _unnamed.Write(bw);
        _skipFractionModifier.Write(bw);
        _gainModifier2.Write(bw);
        _pitchModifier.Write(bw);
        _unnamed2.Write(bw);
        _skipFractionModifier2.Write(bw);
        _gainModifier3.Write(bw);
        _pitchModifier2.Write(bw);
        _unnamed3.Write(bw);
        _encoding.Write(bw);
        _compression.Write(bw);
        _promotionSound.Write(bw);
        _promotionCount.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
_pitchRanges.Count = PitchRanges.Count;
        _pitchRanges.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _promotionSound.WriteString(writer);
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].Write(writer);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].WriteChildData(writer);
        }
      }
    }
    public class SoundPitchRangeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Real _naturalPitch = new Real();
      private RealBounds _bendBounds = new RealBounds();
      private ShortInteger _actualPermutationCount = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Block _permutations = new Block();
      public BlockCollection<SoundPermutationsBlock> _permutationsList = new BlockCollection<SoundPermutationsBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundPitchRangeBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
      }
      public BlockCollection<SoundPermutationsBlock> Permutations {
        get {
          return this._permutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Permutations.BlockCount; x++)
{
  IBlock block = Permutations.GetBlock(x);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Real NaturalPitch {
        get {
          return this._naturalPitch;
        }
        set {
          this._naturalPitch = value;
        }
      }
      public RealBounds BendBounds {
        get {
          return this._bendBounds;
        }
        set {
          this._bendBounds = value;
        }
      }
      public ShortInteger ActualPermutationCount {
        get {
          return this._actualPermutationCount;
        }
        set {
          this._actualPermutationCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _naturalPitch.Read(reader);
        _bendBounds.Read(reader);
        _actualPermutationCount.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new SoundPermutationsBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _naturalPitch.Write(bw);
        _bendBounds.Write(bw);
        _actualPermutationCount.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class SoundPermutationsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealFraction _skipFraction = new RealFraction();
      private RealFraction _gain = new RealFraction();
      private Enum _compression = new Enum();
      private ShortInteger _nextPermutationIndex = new ShortInteger();
      private Pad _unnamed;
      private Data _samples = new Data();
      private Data _mouthData = new Data();
      private Data _subtitleData = new Data();
public event System.EventHandler BlockNameChanged;
      public SoundPermutationsBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(20);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public RealFraction SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
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
      public Enum Compression {
        get {
          return this._compression;
        }
        set {
          this._compression = value;
        }
      }
      public ShortInteger NextPermutationIndex {
        get {
          return this._nextPermutationIndex;
        }
        set {
          this._nextPermutationIndex = value;
        }
      }
      public Data Samples {
        get {
          return this._samples;
        }
        set {
          this._samples = value;
        }
      }
      public Data MouthData {
        get {
          return this._mouthData;
        }
        set {
          this._mouthData = value;
        }
      }
      public Data SubtitleData {
        get {
          return this._subtitleData;
        }
        set {
          this._subtitleData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _skipFraction.Read(reader);
        _gain.Read(reader);
        _compression.Read(reader);
        _nextPermutationIndex.Read(reader);
        _unnamed.Read(reader);
        _samples.Read(reader);
        _mouthData.Read(reader);
        _subtitleData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _samples.ReadBinary(reader);
        _mouthData.ReadBinary(reader);
        _subtitleData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _skipFraction.Write(bw);
        _gain.Write(bw);
        _compression.Write(bw);
        _nextPermutationIndex.Write(bw);
        _unnamed.Write(bw);
        _samples.Write(bw);
        _mouthData.Write(bw);
        _subtitleData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _samples.WriteBinary(writer);
        _mouthData.WriteBinary(writer);
        _subtitleData.WriteBinary(writer);
      }
    }
  }
}
