// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_cache_file_gestalt'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_cache_file_gestalt : Interfaces.Pool.Tag {
    private SoundCacheFileGestaltBlockBlock soundCacheFileGestaltValues = new SoundCacheFileGestaltBlockBlock();
    public virtual SoundCacheFileGestaltBlockBlock SoundCacheFileGestaltValues {
      get {
        return soundCacheFileGestaltValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundCacheFileGestaltValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_cache_file_gestalt";
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
soundCacheFileGestaltValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundCacheFileGestaltValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundCacheFileGestaltValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundCacheFileGestaltValues.WriteChildData(writer);
    }
    #endregion
    public class SoundCacheFileGestaltBlockBlock : IBlock {
      private Block _playbacks = new Block();
      private Block _scales = new Block();
      private Block _importNames = new Block();
      private Block _pitchRangeParameters = new Block();
      private Block _pitchRanges = new Block();
      private Block _permutations = new Block();
      private Block _customPlaybacks = new Block();
      private Block _runtimePermutationFlags = new Block();
      private Block _chunks = new Block();
      private Block _promotions = new Block();
      private Block _extraInfos = new Block();
      public BlockCollection<SoundGestaltPlaybackBlockBlock> _playbacksList = new BlockCollection<SoundGestaltPlaybackBlockBlock>();
      public BlockCollection<SoundGestaltScaleBlockBlock> _scalesList = new BlockCollection<SoundGestaltScaleBlockBlock>();
      public BlockCollection<SoundGestaltImportNamesBlockBlock> _importNamesList = new BlockCollection<SoundGestaltImportNamesBlockBlock>();
      public BlockCollection<SoundGestaltPitchRangeParametersBlockBlock> _pitchRangeParametersList = new BlockCollection<SoundGestaltPitchRangeParametersBlockBlock>();
      public BlockCollection<SoundGestaltPitchRangesBlockBlock> _pitchRangesList = new BlockCollection<SoundGestaltPitchRangesBlockBlock>();
      public BlockCollection<SoundGestaltPermutationsBlockBlock> _permutationsList = new BlockCollection<SoundGestaltPermutationsBlockBlock>();
      public BlockCollection<SoundGestaltCustomPlaybackBlockBlock> _customPlaybacksList = new BlockCollection<SoundGestaltCustomPlaybackBlockBlock>();
      public BlockCollection<SoundGestaltRuntimePermutationBitVectorBlockBlock> _runtimePermutationFlagsList = new BlockCollection<SoundGestaltRuntimePermutationBitVectorBlockBlock>();
      public BlockCollection<SoundPermutationChunkBlockBlock> _chunksList = new BlockCollection<SoundPermutationChunkBlockBlock>();
      public BlockCollection<SoundGestaltPromotionsBlockBlock> _promotionsList = new BlockCollection<SoundGestaltPromotionsBlockBlock>();
      public BlockCollection<SoundGestaltExtraInfoBlockBlock> _extraInfosList = new BlockCollection<SoundGestaltExtraInfoBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundCacheFileGestaltBlockBlock() {
      }
      public BlockCollection<SoundGestaltPlaybackBlockBlock> Playbacks {
        get {
          return this._playbacksList;
        }
      }
      public BlockCollection<SoundGestaltScaleBlockBlock> Scales {
        get {
          return this._scalesList;
        }
      }
      public BlockCollection<SoundGestaltImportNamesBlockBlock> ImportNames {
        get {
          return this._importNamesList;
        }
      }
      public BlockCollection<SoundGestaltPitchRangeParametersBlockBlock> PitchRangeParameters {
        get {
          return this._pitchRangeParametersList;
        }
      }
      public BlockCollection<SoundGestaltPitchRangesBlockBlock> PitchRanges {
        get {
          return this._pitchRangesList;
        }
      }
      public BlockCollection<SoundGestaltPermutationsBlockBlock> Permutations {
        get {
          return this._permutationsList;
        }
      }
      public BlockCollection<SoundGestaltCustomPlaybackBlockBlock> CustomPlaybacks {
        get {
          return this._customPlaybacksList;
        }
      }
      public BlockCollection<SoundGestaltRuntimePermutationBitVectorBlockBlock> RuntimePermutationFlags {
        get {
          return this._runtimePermutationFlagsList;
        }
      }
      public BlockCollection<SoundPermutationChunkBlockBlock> Chunks {
        get {
          return this._chunksList;
        }
      }
      public BlockCollection<SoundGestaltPromotionsBlockBlock> Promotions {
        get {
          return this._promotionsList;
        }
      }
      public BlockCollection<SoundGestaltExtraInfoBlockBlock> ExtraInfos {
        get {
          return this._extraInfosList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Playbacks.BlockCount; x++)
{
  IBlock block = Playbacks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Scales.BlockCount; x++)
{
  IBlock block = Scales.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ImportNames.BlockCount; x++)
{
  IBlock block = ImportNames.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PitchRangeParameters.BlockCount; x++)
{
  IBlock block = PitchRangeParameters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PitchRanges.BlockCount; x++)
{
  IBlock block = PitchRanges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Permutations.BlockCount; x++)
{
  IBlock block = Permutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CustomPlaybacks.BlockCount; x++)
{
  IBlock block = CustomPlaybacks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RuntimePermutationFlags.BlockCount; x++)
{
  IBlock block = RuntimePermutationFlags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Chunks.BlockCount; x++)
{
  IBlock block = Chunks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Promotions.BlockCount; x++)
{
  IBlock block = Promotions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ExtraInfos.BlockCount; x++)
{
  IBlock block = ExtraInfos.GetBlock(x);
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
        _playbacks.Read(reader);
        _scales.Read(reader);
        _importNames.Read(reader);
        _pitchRangeParameters.Read(reader);
        _pitchRanges.Read(reader);
        _permutations.Read(reader);
        _customPlaybacks.Read(reader);
        _runtimePermutationFlags.Read(reader);
        _chunks.Read(reader);
        _promotions.Read(reader);
        _extraInfos.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _playbacks.Count); x = (x + 1)) {
          Playbacks.Add(new SoundGestaltPlaybackBlockBlock());
          Playbacks[x].Read(reader);
        }
        for (x = 0; (x < _playbacks.Count); x = (x + 1)) {
          Playbacks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scales.Count); x = (x + 1)) {
          Scales.Add(new SoundGestaltScaleBlockBlock());
          Scales[x].Read(reader);
        }
        for (x = 0; (x < _scales.Count); x = (x + 1)) {
          Scales[x].ReadChildData(reader);
        }
        for (x = 0; (x < _importNames.Count); x = (x + 1)) {
          ImportNames.Add(new SoundGestaltImportNamesBlockBlock());
          ImportNames[x].Read(reader);
        }
        for (x = 0; (x < _importNames.Count); x = (x + 1)) {
          ImportNames[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pitchRangeParameters.Count); x = (x + 1)) {
          PitchRangeParameters.Add(new SoundGestaltPitchRangeParametersBlockBlock());
          PitchRangeParameters[x].Read(reader);
        }
        for (x = 0; (x < _pitchRangeParameters.Count); x = (x + 1)) {
          PitchRangeParameters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges.Add(new SoundGestaltPitchRangesBlockBlock());
          PitchRanges[x].Read(reader);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new SoundGestaltPermutationsBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _customPlaybacks.Count); x = (x + 1)) {
          CustomPlaybacks.Add(new SoundGestaltCustomPlaybackBlockBlock());
          CustomPlaybacks[x].Read(reader);
        }
        for (x = 0; (x < _customPlaybacks.Count); x = (x + 1)) {
          CustomPlaybacks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _runtimePermutationFlags.Count); x = (x + 1)) {
          RuntimePermutationFlags.Add(new SoundGestaltRuntimePermutationBitVectorBlockBlock());
          RuntimePermutationFlags[x].Read(reader);
        }
        for (x = 0; (x < _runtimePermutationFlags.Count); x = (x + 1)) {
          RuntimePermutationFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _chunks.Count); x = (x + 1)) {
          Chunks.Add(new SoundPermutationChunkBlockBlock());
          Chunks[x].Read(reader);
        }
        for (x = 0; (x < _chunks.Count); x = (x + 1)) {
          Chunks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _promotions.Count); x = (x + 1)) {
          Promotions.Add(new SoundGestaltPromotionsBlockBlock());
          Promotions[x].Read(reader);
        }
        for (x = 0; (x < _promotions.Count); x = (x + 1)) {
          Promotions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _extraInfos.Count); x = (x + 1)) {
          ExtraInfos.Add(new SoundGestaltExtraInfoBlockBlock());
          ExtraInfos[x].Read(reader);
        }
        for (x = 0; (x < _extraInfos.Count); x = (x + 1)) {
          ExtraInfos[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_playbacks.Count = Playbacks.Count;
        _playbacks.Write(bw);
_scales.Count = Scales.Count;
        _scales.Write(bw);
_importNames.Count = ImportNames.Count;
        _importNames.Write(bw);
_pitchRangeParameters.Count = PitchRangeParameters.Count;
        _pitchRangeParameters.Write(bw);
_pitchRanges.Count = PitchRanges.Count;
        _pitchRanges.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
_customPlaybacks.Count = CustomPlaybacks.Count;
        _customPlaybacks.Write(bw);
_runtimePermutationFlags.Count = RuntimePermutationFlags.Count;
        _runtimePermutationFlags.Write(bw);
_chunks.Count = Chunks.Count;
        _chunks.Write(bw);
_promotions.Count = Promotions.Count;
        _promotions.Write(bw);
_extraInfos.Count = ExtraInfos.Count;
        _extraInfos.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _playbacks.Count); x = (x + 1)) {
          Playbacks[x].Write(writer);
        }
        for (x = 0; (x < _playbacks.Count); x = (x + 1)) {
          Playbacks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scales.Count); x = (x + 1)) {
          Scales[x].Write(writer);
        }
        for (x = 0; (x < _scales.Count); x = (x + 1)) {
          Scales[x].WriteChildData(writer);
        }
        for (x = 0; (x < _importNames.Count); x = (x + 1)) {
          ImportNames[x].Write(writer);
        }
        for (x = 0; (x < _importNames.Count); x = (x + 1)) {
          ImportNames[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pitchRangeParameters.Count); x = (x + 1)) {
          PitchRangeParameters[x].Write(writer);
        }
        for (x = 0; (x < _pitchRangeParameters.Count); x = (x + 1)) {
          PitchRangeParameters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].Write(writer);
        }
        for (x = 0; (x < _pitchRanges.Count); x = (x + 1)) {
          PitchRanges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _customPlaybacks.Count); x = (x + 1)) {
          CustomPlaybacks[x].Write(writer);
        }
        for (x = 0; (x < _customPlaybacks.Count); x = (x + 1)) {
          CustomPlaybacks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _runtimePermutationFlags.Count); x = (x + 1)) {
          RuntimePermutationFlags[x].Write(writer);
        }
        for (x = 0; (x < _runtimePermutationFlags.Count); x = (x + 1)) {
          RuntimePermutationFlags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _chunks.Count); x = (x + 1)) {
          Chunks[x].Write(writer);
        }
        for (x = 0; (x < _chunks.Count); x = (x + 1)) {
          Chunks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _promotions.Count); x = (x + 1)) {
          Promotions[x].Write(writer);
        }
        for (x = 0; (x < _promotions.Count); x = (x + 1)) {
          Promotions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _extraInfos.Count); x = (x + 1)) {
          ExtraInfos[x].Write(writer);
        }
        for (x = 0; (x < _extraInfos.Count); x = (x + 1)) {
          ExtraInfos[x].WriteChildData(writer);
        }
      }
    }
    public class SoundGestaltPlaybackBlockBlock : IBlock {
      private Real _minimumDistance = new Real();
      private Real _maximumDistance = new Real();
      private RealFraction _skipFraction = new RealFraction();
      private Real _maximumBendPerSecond = new Real();
      private Real _gainBase = new Real();
      private Real _gainVariance = new Real();
      private ShortIntegerBounds _randomPitchBounds = new ShortIntegerBounds();
      private Angle _innerConeAngle = new Angle();
      private Angle _outerConeAngle = new Angle();
      private Real _outerConeGain = new Real();
      private Flags _flags;
      private Angle _azimuth = new Angle();
      private Real _positionalGain = new Real();
      private Real _firstPersonGain = new Real();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltPlaybackBlockBlock() {
        this._flags = new Flags(4);
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
      public Real MaximumBendPerSecond {
        get {
          return this._maximumBendPerSecond;
        }
        set {
          this._maximumBendPerSecond = value;
        }
      }
      public Real GainBase {
        get {
          return this._gainBase;
        }
        set {
          this._gainBase = value;
        }
      }
      public Real GainVariance {
        get {
          return this._gainVariance;
        }
        set {
          this._gainVariance = value;
        }
      }
      public ShortIntegerBounds RandomPitchBounds {
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
      public Real OuterConeGain {
        get {
          return this._outerConeGain;
        }
        set {
          this._outerConeGain = value;
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
      public Angle Azimuth {
        get {
          return this._azimuth;
        }
        set {
          this._azimuth = value;
        }
      }
      public Real PositionalGain {
        get {
          return this._positionalGain;
        }
        set {
          this._positionalGain = value;
        }
      }
      public Real FirstPersonGain {
        get {
          return this._firstPersonGain;
        }
        set {
          this._firstPersonGain = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _minimumDistance.Read(reader);
        _maximumDistance.Read(reader);
        _skipFraction.Read(reader);
        _maximumBendPerSecond.Read(reader);
        _gainBase.Read(reader);
        _gainVariance.Read(reader);
        _randomPitchBounds.Read(reader);
        _innerConeAngle.Read(reader);
        _outerConeAngle.Read(reader);
        _outerConeGain.Read(reader);
        _flags.Read(reader);
        _azimuth.Read(reader);
        _positionalGain.Read(reader);
        _firstPersonGain.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _minimumDistance.Write(bw);
        _maximumDistance.Write(bw);
        _skipFraction.Write(bw);
        _maximumBendPerSecond.Write(bw);
        _gainBase.Write(bw);
        _gainVariance.Write(bw);
        _randomPitchBounds.Write(bw);
        _innerConeAngle.Write(bw);
        _outerConeAngle.Write(bw);
        _outerConeGain.Write(bw);
        _flags.Write(bw);
        _azimuth.Write(bw);
        _positionalGain.Write(bw);
        _firstPersonGain.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltScaleBlockBlock : IBlock {
      private RealBounds _gainModifier = new RealBounds();
      private ShortIntegerBounds _pitchModifier = new ShortIntegerBounds();
      private FractionBounds _skipFractionModifier = new FractionBounds();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltScaleBlockBlock() {
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
      public RealBounds GainModifier {
        get {
          return this._gainModifier;
        }
        set {
          this._gainModifier = value;
        }
      }
      public ShortIntegerBounds PitchModifier {
        get {
          return this._pitchModifier;
        }
        set {
          this._pitchModifier = value;
        }
      }
      public FractionBounds SkipFractionModifier {
        get {
          return this._skipFractionModifier;
        }
        set {
          this._skipFractionModifier = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _gainModifier.Read(reader);
        _pitchModifier.Read(reader);
        _skipFractionModifier.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _gainModifier.Write(bw);
        _pitchModifier.Write(bw);
        _skipFractionModifier.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltImportNamesBlockBlock : IBlock {
      private StringId _importName = new StringId();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltImportNamesBlockBlock() {
if (this._importName is System.ComponentModel.INotifyPropertyChanged)
  (this._importName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _importName.ToString();
        }
      }
      public StringId ImportName {
        get {
          return this._importName;
        }
        set {
          this._importName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _importName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _importName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _importName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _importName.WriteString(writer);
      }
    }
    public class SoundGestaltPitchRangeParametersBlockBlock : IBlock {
      private ShortInteger _naturalPitch = new ShortInteger();
      private ShortIntegerBounds _bendBounds = new ShortIntegerBounds();
      private ShortIntegerBounds _maxGainPitchBounds = new ShortIntegerBounds();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltPitchRangeParametersBlockBlock() {
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
      public ShortInteger NaturalPitch {
        get {
          return this._naturalPitch;
        }
        set {
          this._naturalPitch = value;
        }
      }
      public ShortIntegerBounds BendBounds {
        get {
          return this._bendBounds;
        }
        set {
          this._bendBounds = value;
        }
      }
      public ShortIntegerBounds MaxGainPitchBounds {
        get {
          return this._maxGainPitchBounds;
        }
        set {
          this._maxGainPitchBounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _naturalPitch.Read(reader);
        _bendBounds.Read(reader);
        _maxGainPitchBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _naturalPitch.Write(bw);
        _bendBounds.Write(bw);
        _maxGainPitchBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltPitchRangesBlockBlock : IBlock {
      private ShortBlockIndex _name = new ShortBlockIndex();
      private ShortBlockIndex _parameters = new ShortBlockIndex();
      private ShortInteger _encodedPermutationData = new ShortInteger();
      private ShortInteger _firstRuntimePermutationFlagIndex = new ShortInteger();
      private ShortBlockIndex _firstPermutation = new ShortBlockIndex();
      private ShortInteger _permutationCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltPitchRangesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Parameters {
        get {
          return this._parameters;
        }
        set {
          this._parameters = value;
        }
      }
      public ShortInteger EncodedPermutationData {
        get {
          return this._encodedPermutationData;
        }
        set {
          this._encodedPermutationData = value;
        }
      }
      public ShortInteger FirstRuntimePermutationFlagIndex {
        get {
          return this._firstRuntimePermutationFlagIndex;
        }
        set {
          this._firstRuntimePermutationFlagIndex = value;
        }
      }
      public ShortBlockIndex FirstPermutation {
        get {
          return this._firstPermutation;
        }
        set {
          this._firstPermutation = value;
        }
      }
      public ShortInteger PermutationCount {
        get {
          return this._permutationCount;
        }
        set {
          this._permutationCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parameters.Read(reader);
        _encodedPermutationData.Read(reader);
        _firstRuntimePermutationFlagIndex.Read(reader);
        _firstPermutation.Read(reader);
        _permutationCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _parameters.Write(bw);
        _encodedPermutationData.Write(bw);
        _firstRuntimePermutationFlagIndex.Write(bw);
        _firstPermutation.Write(bw);
        _permutationCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltPermutationsBlockBlock : IBlock {
      private ShortBlockIndex _name = new ShortBlockIndex();
      private ShortInteger _encodedSkipFraction = new ShortInteger();
      private CharInteger _encodedGain = new CharInteger();
      private CharInteger _permutationInfoIndex = new CharInteger();
      private ShortInteger _languageNeutralTime = new ShortInteger();
      private LongInteger _sampleSize = new LongInteger();
      private ShortBlockIndex _firstChunk = new ShortBlockIndex();
      private ShortInteger _chunkCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltPermutationsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortInteger EncodedSkipFraction {
        get {
          return this._encodedSkipFraction;
        }
        set {
          this._encodedSkipFraction = value;
        }
      }
      public CharInteger EncodedGain {
        get {
          return this._encodedGain;
        }
        set {
          this._encodedGain = value;
        }
      }
      public CharInteger PermutationInfoIndex {
        get {
          return this._permutationInfoIndex;
        }
        set {
          this._permutationInfoIndex = value;
        }
      }
      public ShortInteger LanguageNeutralTime {
        get {
          return this._languageNeutralTime;
        }
        set {
          this._languageNeutralTime = value;
        }
      }
      public LongInteger SampleSize {
        get {
          return this._sampleSize;
        }
        set {
          this._sampleSize = value;
        }
      }
      public ShortBlockIndex FirstChunk {
        get {
          return this._firstChunk;
        }
        set {
          this._firstChunk = value;
        }
      }
      public ShortInteger ChunkCount {
        get {
          return this._chunkCount;
        }
        set {
          this._chunkCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _encodedSkipFraction.Read(reader);
        _encodedGain.Read(reader);
        _permutationInfoIndex.Read(reader);
        _languageNeutralTime.Read(reader);
        _sampleSize.Read(reader);
        _firstChunk.Read(reader);
        _chunkCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _encodedSkipFraction.Write(bw);
        _encodedGain.Write(bw);
        _permutationInfoIndex.Write(bw);
        _languageNeutralTime.Write(bw);
        _sampleSize.Write(bw);
        _firstChunk.Write(bw);
        _chunkCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltCustomPlaybackBlockBlock : IBlock {
      private Block _unnamed0 = new Block();
      private Flags _flags;
      private Pad _unnamed1;
      private Block _filter = new Block();
      private Block _pitchLfo = new Block();
      private Block _filterLfo = new Block();
      private Block _soundEffect = new Block();
      public BlockCollection<PlatformSoundOverrideMixbinsBlockBlock> _unnamed0List = new BlockCollection<PlatformSoundOverrideMixbinsBlockBlock>();
      public BlockCollection<PlatformSoundFilterBlockBlock> _filterList = new BlockCollection<PlatformSoundFilterBlockBlock>();
      public BlockCollection<PlatformSoundPitchLfoBlockBlock> _pitchLfoList = new BlockCollection<PlatformSoundPitchLfoBlockBlock>();
      public BlockCollection<PlatformSoundFilterLfoBlockBlock> _filterLfoList = new BlockCollection<PlatformSoundFilterLfoBlockBlock>();
      public BlockCollection<SoundEffectPlaybackBlockBlock> _soundEffectList = new BlockCollection<SoundEffectPlaybackBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltCustomPlaybackBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed1 = new Pad(8);
      }
      public BlockCollection<PlatformSoundOverrideMixbinsBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public BlockCollection<PlatformSoundFilterBlockBlock> Filter {
        get {
          return this._filterList;
        }
      }
      public BlockCollection<PlatformSoundPitchLfoBlockBlock> PitchLfo {
        get {
          return this._pitchLfoList;
        }
      }
      public BlockCollection<PlatformSoundFilterLfoBlockBlock> FilterLfo {
        get {
          return this._filterLfoList;
        }
      }
      public BlockCollection<SoundEffectPlaybackBlockBlock> SoundEffect {
        get {
          return this._soundEffectList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Filter.BlockCount; x++)
{
  IBlock block = Filter.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PitchLfo.BlockCount; x++)
{
  IBlock block = PitchLfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FilterLfo.BlockCount; x++)
{
  IBlock block = FilterLfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundEffect.BlockCount; x++)
{
  IBlock block = SoundEffect.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _unnamed1.Read(reader);
        _filter.Read(reader);
        _pitchLfo.Read(reader);
        _filterLfo.Read(reader);
        _soundEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new PlatformSoundOverrideMixbinsBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
        for (x = 0; (x < _filter.Count); x = (x + 1)) {
          Filter.Add(new PlatformSoundFilterBlockBlock());
          Filter[x].Read(reader);
        }
        for (x = 0; (x < _filter.Count); x = (x + 1)) {
          Filter[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pitchLfo.Count); x = (x + 1)) {
          PitchLfo.Add(new PlatformSoundPitchLfoBlockBlock());
          PitchLfo[x].Read(reader);
        }
        for (x = 0; (x < _pitchLfo.Count); x = (x + 1)) {
          PitchLfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _filterLfo.Count); x = (x + 1)) {
          FilterLfo.Add(new PlatformSoundFilterLfoBlockBlock());
          FilterLfo[x].Read(reader);
        }
        for (x = 0; (x < _filterLfo.Count); x = (x + 1)) {
          FilterLfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEffect.Count); x = (x + 1)) {
          SoundEffect.Add(new SoundEffectPlaybackBlockBlock());
          SoundEffect[x].Read(reader);
        }
        for (x = 0; (x < _soundEffect.Count); x = (x + 1)) {
          SoundEffect[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _unnamed1.Write(bw);
_filter.Count = Filter.Count;
        _filter.Write(bw);
_pitchLfo.Count = PitchLfo.Count;
        _pitchLfo.Write(bw);
_filterLfo.Count = FilterLfo.Count;
        _filterLfo.Write(bw);
_soundEffect.Count = SoundEffect.Count;
        _soundEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
        for (x = 0; (x < _filter.Count); x = (x + 1)) {
          Filter[x].Write(writer);
        }
        for (x = 0; (x < _filter.Count); x = (x + 1)) {
          Filter[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pitchLfo.Count); x = (x + 1)) {
          PitchLfo[x].Write(writer);
        }
        for (x = 0; (x < _pitchLfo.Count); x = (x + 1)) {
          PitchLfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _filterLfo.Count); x = (x + 1)) {
          FilterLfo[x].Write(writer);
        }
        for (x = 0; (x < _filterLfo.Count); x = (x + 1)) {
          FilterLfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundEffect.Count); x = (x + 1)) {
          SoundEffect[x].Write(writer);
        }
        for (x = 0; (x < _soundEffect.Count); x = (x + 1)) {
          SoundEffect[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundOverrideMixbinsBlockBlock : IBlock {
      private Enum _mixbin;
      private Real _gain = new Real();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundOverrideMixbinsBlockBlock() {
        this._mixbin = new Enum(4);
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
      public Enum Mixbin {
        get {
          return this._mixbin;
        }
        set {
          this._mixbin = value;
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
      public virtual void Read(BinaryReader reader) {
        _mixbin.Read(reader);
        _gain.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _mixbin.Write(bw);
        _gain.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatformSoundFilterBlockBlock : IBlock {
      private Enum _filterType;
      private LongInteger _filterWidth = new LongInteger();
      private RealBounds _scaleBounds = new RealBounds();
      private RealBounds _randomBaseAndVariance = new RealBounds();
      private RealBounds _scaleBounds2 = new RealBounds();
      private RealBounds _randomBaseAndVariance2 = new RealBounds();
      private RealBounds _scaleBounds3 = new RealBounds();
      private RealBounds _randomBaseAndVariance3 = new RealBounds();
      private RealBounds _scaleBounds4 = new RealBounds();
      private RealBounds _randomBaseAndVariance4 = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundFilterBlockBlock() {
        this._filterType = new Enum(4);
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
      public Enum FilterType {
        get {
          return this._filterType;
        }
        set {
          this._filterType = value;
        }
      }
      public LongInteger FilterWidth {
        get {
          return this._filterWidth;
        }
        set {
          this._filterWidth = value;
        }
      }
      public RealBounds ScaleBounds {
        get {
          return this._scaleBounds;
        }
        set {
          this._scaleBounds = value;
        }
      }
      public RealBounds RandomBaseAndVariance {
        get {
          return this._randomBaseAndVariance;
        }
        set {
          this._randomBaseAndVariance = value;
        }
      }
      public RealBounds ScaleBounds2 {
        get {
          return this._scaleBounds2;
        }
        set {
          this._scaleBounds2 = value;
        }
      }
      public RealBounds RandomBaseAndVariance2 {
        get {
          return this._randomBaseAndVariance2;
        }
        set {
          this._randomBaseAndVariance2 = value;
        }
      }
      public RealBounds ScaleBounds3 {
        get {
          return this._scaleBounds3;
        }
        set {
          this._scaleBounds3 = value;
        }
      }
      public RealBounds RandomBaseAndVariance3 {
        get {
          return this._randomBaseAndVariance3;
        }
        set {
          this._randomBaseAndVariance3 = value;
        }
      }
      public RealBounds ScaleBounds4 {
        get {
          return this._scaleBounds4;
        }
        set {
          this._scaleBounds4 = value;
        }
      }
      public RealBounds RandomBaseAndVariance4 {
        get {
          return this._randomBaseAndVariance4;
        }
        set {
          this._randomBaseAndVariance4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _filterType.Read(reader);
        _filterWidth.Read(reader);
        _scaleBounds.Read(reader);
        _randomBaseAndVariance.Read(reader);
        _scaleBounds2.Read(reader);
        _randomBaseAndVariance2.Read(reader);
        _scaleBounds3.Read(reader);
        _randomBaseAndVariance3.Read(reader);
        _scaleBounds4.Read(reader);
        _randomBaseAndVariance4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _filterType.Write(bw);
        _filterWidth.Write(bw);
        _scaleBounds.Write(bw);
        _randomBaseAndVariance.Write(bw);
        _scaleBounds2.Write(bw);
        _randomBaseAndVariance2.Write(bw);
        _scaleBounds3.Write(bw);
        _randomBaseAndVariance3.Write(bw);
        _scaleBounds4.Write(bw);
        _randomBaseAndVariance4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatformSoundPitchLfoBlockBlock : IBlock {
      private RealBounds _scaleBounds = new RealBounds();
      private RealBounds _randomBaseAndVariance = new RealBounds();
      private RealBounds _scaleBounds2 = new RealBounds();
      private RealBounds _randomBaseAndVariance2 = new RealBounds();
      private RealBounds _scaleBounds3 = new RealBounds();
      private RealBounds _randomBaseAndVariance3 = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundPitchLfoBlockBlock() {
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
      public RealBounds ScaleBounds {
        get {
          return this._scaleBounds;
        }
        set {
          this._scaleBounds = value;
        }
      }
      public RealBounds RandomBaseAndVariance {
        get {
          return this._randomBaseAndVariance;
        }
        set {
          this._randomBaseAndVariance = value;
        }
      }
      public RealBounds ScaleBounds2 {
        get {
          return this._scaleBounds2;
        }
        set {
          this._scaleBounds2 = value;
        }
      }
      public RealBounds RandomBaseAndVariance2 {
        get {
          return this._randomBaseAndVariance2;
        }
        set {
          this._randomBaseAndVariance2 = value;
        }
      }
      public RealBounds ScaleBounds3 {
        get {
          return this._scaleBounds3;
        }
        set {
          this._scaleBounds3 = value;
        }
      }
      public RealBounds RandomBaseAndVariance3 {
        get {
          return this._randomBaseAndVariance3;
        }
        set {
          this._randomBaseAndVariance3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scaleBounds.Read(reader);
        _randomBaseAndVariance.Read(reader);
        _scaleBounds2.Read(reader);
        _randomBaseAndVariance2.Read(reader);
        _scaleBounds3.Read(reader);
        _randomBaseAndVariance3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scaleBounds.Write(bw);
        _randomBaseAndVariance.Write(bw);
        _scaleBounds2.Write(bw);
        _randomBaseAndVariance2.Write(bw);
        _scaleBounds3.Write(bw);
        _randomBaseAndVariance3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatformSoundFilterLfoBlockBlock : IBlock {
      private RealBounds _scaleBounds = new RealBounds();
      private RealBounds _randomBaseAndVariance = new RealBounds();
      private RealBounds _scaleBounds2 = new RealBounds();
      private RealBounds _randomBaseAndVariance2 = new RealBounds();
      private RealBounds _scaleBounds3 = new RealBounds();
      private RealBounds _randomBaseAndVariance3 = new RealBounds();
      private RealBounds _scaleBounds4 = new RealBounds();
      private RealBounds _randomBaseAndVariance4 = new RealBounds();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundFilterLfoBlockBlock() {
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
      public RealBounds ScaleBounds {
        get {
          return this._scaleBounds;
        }
        set {
          this._scaleBounds = value;
        }
      }
      public RealBounds RandomBaseAndVariance {
        get {
          return this._randomBaseAndVariance;
        }
        set {
          this._randomBaseAndVariance = value;
        }
      }
      public RealBounds ScaleBounds2 {
        get {
          return this._scaleBounds2;
        }
        set {
          this._scaleBounds2 = value;
        }
      }
      public RealBounds RandomBaseAndVariance2 {
        get {
          return this._randomBaseAndVariance2;
        }
        set {
          this._randomBaseAndVariance2 = value;
        }
      }
      public RealBounds ScaleBounds3 {
        get {
          return this._scaleBounds3;
        }
        set {
          this._scaleBounds3 = value;
        }
      }
      public RealBounds RandomBaseAndVariance3 {
        get {
          return this._randomBaseAndVariance3;
        }
        set {
          this._randomBaseAndVariance3 = value;
        }
      }
      public RealBounds ScaleBounds4 {
        get {
          return this._scaleBounds4;
        }
        set {
          this._scaleBounds4 = value;
        }
      }
      public RealBounds RandomBaseAndVariance4 {
        get {
          return this._randomBaseAndVariance4;
        }
        set {
          this._randomBaseAndVariance4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scaleBounds.Read(reader);
        _randomBaseAndVariance.Read(reader);
        _scaleBounds2.Read(reader);
        _randomBaseAndVariance2.Read(reader);
        _scaleBounds3.Read(reader);
        _randomBaseAndVariance3.Read(reader);
        _scaleBounds4.Read(reader);
        _randomBaseAndVariance4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scaleBounds.Write(bw);
        _randomBaseAndVariance.Write(bw);
        _scaleBounds2.Write(bw);
        _randomBaseAndVariance2.Write(bw);
        _scaleBounds3.Write(bw);
        _randomBaseAndVariance3.Write(bw);
        _scaleBounds4.Write(bw);
        _randomBaseAndVariance4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundEffectPlaybackBlockBlock : IBlock {
      private TagReference _unnamed0 = new TagReference();
      private Block _components = new Block();
      private Block _unnamed1 = new Block();
      private Data _unnamed2 = new Data();
      private Block _unnamed3 = new Block();
      public BlockCollection<SoundEffectComponentBlockBlock> _componentsList = new BlockCollection<SoundEffectComponentBlockBlock>();
      public BlockCollection<SoundEffectOverridesBlockBlock> _unnamed1List = new BlockCollection<SoundEffectOverridesBlockBlock>();
      public BlockCollection<PlatformSoundEffectCollectionBlockBlock> _unnamed3List = new BlockCollection<PlatformSoundEffectCollectionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectPlaybackBlockBlock() {
      }
      public BlockCollection<SoundEffectComponentBlockBlock> Components {
        get {
          return this._componentsList;
        }
      }
      public BlockCollection<SoundEffectOverridesBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public BlockCollection<PlatformSoundEffectCollectionBlockBlock> Unnamed3 {
        get {
          return this._unnamed3List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unnamed0.Value);
for (int x=0; x<Components.BlockCount; x++)
{
  IBlock block = Components.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed3.BlockCount; x++)
{
  IBlock block = Unnamed3.GetBlock(x);
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
      public TagReference unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public Data unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _components.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _unnamed0.ReadString(reader);
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components.Add(new SoundEffectComponentBlockBlock());
          Components[x].Read(reader);
        }
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new SoundEffectOverridesBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        _unnamed2.ReadBinary(reader);
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3.Add(new PlatformSoundEffectCollectionBlockBlock());
          Unnamed3[x].Read(reader);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
_components.Count = Components.Count;
        _components.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_unnamed3.Count = Unnamed3.Count;
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _unnamed0.WriteString(writer);
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].Write(writer);
        }
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        _unnamed2.WriteBinary(writer);
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].Write(writer);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].WriteChildData(writer);
        }
      }
    }
    public class SoundEffectComponentBlockBlock : IBlock {
      private TagReference _sound = new TagReference();
      private Real _gain = new Real();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public SoundEffectComponentBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
      public Real Gain {
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
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
        _gain.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _gain.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
    public class SoundEffectOverridesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _overrides = new Block();
      public BlockCollection<SoundEffectOverrideParametersBlockBlock> _overridesList = new BlockCollection<SoundEffectOverrideParametersBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectOverridesBlockBlock() {
      }
      public BlockCollection<SoundEffectOverrideParametersBlockBlock> Overrides {
        get {
          return this._overridesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Overrides.BlockCount; x++)
{
  IBlock block = Overrides.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _overrides.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _overrides.Count); x = (x + 1)) {
          Overrides.Add(new SoundEffectOverrideParametersBlockBlock());
          Overrides[x].Read(reader);
        }
        for (x = 0; (x < _overrides.Count); x = (x + 1)) {
          Overrides[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_overrides.Count = Overrides.Count;
        _overrides.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _overrides.Count); x = (x + 1)) {
          Overrides[x].Write(writer);
        }
        for (x = 0; (x < _overrides.Count); x = (x + 1)) {
          Overrides[x].WriteChildData(writer);
        }
      }
    }
    public class SoundEffectOverrideParametersBlockBlock : IBlock {
      private StringId _name = new StringId();
      private StringId _input = new StringId();
      private StringId _range = new StringId();
      private Real _timePeriod = new Real();
      private LongInteger _integerValue = new LongInteger();
      private Real _realValue = new Real();
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectOverrideParametersBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public StringId Input {
        get {
          return this._input;
        }
        set {
          this._input = value;
        }
      }
      public StringId Range {
        get {
          return this._range;
        }
        set {
          this._range = value;
        }
      }
      public Real TimePeriod {
        get {
          return this._timePeriod;
        }
        set {
          this._timePeriod = value;
        }
      }
      public LongInteger IntegerValue {
        get {
          return this._integerValue;
        }
        set {
          this._integerValue = value;
        }
      }
      public Real RealValue {
        get {
          return this._realValue;
        }
        set {
          this._realValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _input.Read(reader);
        _range.Read(reader);
        _timePeriod.Read(reader);
        _integerValue.Read(reader);
        _realValue.Read(reader);
        _data.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _input.ReadString(reader);
        _range.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _input.Write(bw);
        _range.Write(bw);
        _timePeriod.Write(bw);
        _integerValue.Write(bw);
        _realValue.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _input.WriteString(writer);
        _range.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ByteBlockBlock : IBlock {
      private CharInteger _value = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockBlock() {
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
      public CharInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatformSoundEffectCollectionBlockBlock : IBlock {
      private Block _soundEffects = new Block();
      private Block _lowFrequencyInput = new Block();
      private LongInteger _soundEffectOverrides = new LongInteger();
      public BlockCollection<PlatformSoundEffectBlockBlock> _soundEffectsList = new BlockCollection<PlatformSoundEffectBlockBlock>();
      public BlockCollection<PlatformSoundEffectFunctionBlockBlock> _lowFrequencyInputList = new BlockCollection<PlatformSoundEffectFunctionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectCollectionBlockBlock() {
      }
      public BlockCollection<PlatformSoundEffectBlockBlock> SoundEffects {
        get {
          return this._soundEffectsList;
        }
      }
      public BlockCollection<PlatformSoundEffectFunctionBlockBlock> LowFrequencyInput {
        get {
          return this._lowFrequencyInputList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SoundEffects.BlockCount; x++)
{
  IBlock block = SoundEffects.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LowFrequencyInput.BlockCount; x++)
{
  IBlock block = LowFrequencyInput.GetBlock(x);
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
      public LongInteger SoundEffectOverrides {
        get {
          return this._soundEffectOverrides;
        }
        set {
          this._soundEffectOverrides = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundEffects.Read(reader);
        _lowFrequencyInput.Read(reader);
        _soundEffectOverrides.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects.Add(new PlatformSoundEffectBlockBlock());
          SoundEffects[x].Read(reader);
        }
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lowFrequencyInput.Count); x = (x + 1)) {
          LowFrequencyInput.Add(new PlatformSoundEffectFunctionBlockBlock());
          LowFrequencyInput[x].Read(reader);
        }
        for (x = 0; (x < _lowFrequencyInput.Count); x = (x + 1)) {
          LowFrequencyInput[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_soundEffects.Count = SoundEffects.Count;
        _soundEffects.Write(bw);
_lowFrequencyInput.Count = LowFrequencyInput.Count;
        _lowFrequencyInput.Write(bw);
        _soundEffectOverrides.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].Write(writer);
        }
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lowFrequencyInput.Count); x = (x + 1)) {
          LowFrequencyInput[x].Write(writer);
        }
        for (x = 0; (x < _lowFrequencyInput.Count); x = (x + 1)) {
          LowFrequencyInput[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundEffectBlockBlock : IBlock {
      private Block _functionInputs = new Block();
      private Block _constantInputs = new Block();
      private Block _templateOverrideDescriptors = new Block();
      private LongInteger _inputOverrides = new LongInteger();
      public BlockCollection<PlatformSoundEffectFunctionBlockBlock> _functionInputsList = new BlockCollection<PlatformSoundEffectFunctionBlockBlock>();
      public BlockCollection<PlatformSoundEffectConstantBlockBlock> _constantInputsList = new BlockCollection<PlatformSoundEffectConstantBlockBlock>();
      public BlockCollection<PlatformSoundEffectOverrideDescriptorBlockBlock> _templateOverrideDescriptorsList = new BlockCollection<PlatformSoundEffectOverrideDescriptorBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectBlockBlock() {
      }
      public BlockCollection<PlatformSoundEffectFunctionBlockBlock> FunctionInputs {
        get {
          return this._functionInputsList;
        }
      }
      public BlockCollection<PlatformSoundEffectConstantBlockBlock> ConstantInputs {
        get {
          return this._constantInputsList;
        }
      }
      public BlockCollection<PlatformSoundEffectOverrideDescriptorBlockBlock> TemplateOverrideDescriptors {
        get {
          return this._templateOverrideDescriptorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<FunctionInputs.BlockCount; x++)
{
  IBlock block = FunctionInputs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ConstantInputs.BlockCount; x++)
{
  IBlock block = ConstantInputs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TemplateOverrideDescriptors.BlockCount; x++)
{
  IBlock block = TemplateOverrideDescriptors.GetBlock(x);
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
      public LongInteger InputOverrides {
        get {
          return this._inputOverrides;
        }
        set {
          this._inputOverrides = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _functionInputs.Read(reader);
        _constantInputs.Read(reader);
        _templateOverrideDescriptors.Read(reader);
        _inputOverrides.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _functionInputs.Count); x = (x + 1)) {
          FunctionInputs.Add(new PlatformSoundEffectFunctionBlockBlock());
          FunctionInputs[x].Read(reader);
        }
        for (x = 0; (x < _functionInputs.Count); x = (x + 1)) {
          FunctionInputs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _constantInputs.Count); x = (x + 1)) {
          ConstantInputs.Add(new PlatformSoundEffectConstantBlockBlock());
          ConstantInputs[x].Read(reader);
        }
        for (x = 0; (x < _constantInputs.Count); x = (x + 1)) {
          ConstantInputs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _templateOverrideDescriptors.Count); x = (x + 1)) {
          TemplateOverrideDescriptors.Add(new PlatformSoundEffectOverrideDescriptorBlockBlock());
          TemplateOverrideDescriptors[x].Read(reader);
        }
        for (x = 0; (x < _templateOverrideDescriptors.Count); x = (x + 1)) {
          TemplateOverrideDescriptors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_functionInputs.Count = FunctionInputs.Count;
        _functionInputs.Write(bw);
_constantInputs.Count = ConstantInputs.Count;
        _constantInputs.Write(bw);
_templateOverrideDescriptors.Count = TemplateOverrideDescriptors.Count;
        _templateOverrideDescriptors.Write(bw);
        _inputOverrides.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _functionInputs.Count); x = (x + 1)) {
          FunctionInputs[x].Write(writer);
        }
        for (x = 0; (x < _functionInputs.Count); x = (x + 1)) {
          FunctionInputs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _constantInputs.Count); x = (x + 1)) {
          ConstantInputs[x].Write(writer);
        }
        for (x = 0; (x < _constantInputs.Count); x = (x + 1)) {
          ConstantInputs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _templateOverrideDescriptors.Count); x = (x + 1)) {
          TemplateOverrideDescriptors[x].Write(writer);
        }
        for (x = 0; (x < _templateOverrideDescriptors.Count); x = (x + 1)) {
          TemplateOverrideDescriptors[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundEffectFunctionBlockBlock : IBlock {
      private Enum _input;
      private Enum _range;
      private Block _data = new Block();
      private Real _timePeriod = new Real();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectFunctionBlockBlock() {
        this._input = new Enum(2);
        this._range = new Enum(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public Enum Input {
        get {
          return this._input;
        }
        set {
          this._input = value;
        }
      }
      public Enum Range {
        get {
          return this._range;
        }
        set {
          this._range = value;
        }
      }
      public Real TimePeriod {
        get {
          return this._timePeriod;
        }
        set {
          this._timePeriod = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _input.Read(reader);
        _range.Read(reader);
        _data.Read(reader);
        _timePeriod.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _input.Write(bw);
        _range.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _timePeriod.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundEffectConstantBlockBlock : IBlock {
      private Real _constantValue = new Real();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectConstantBlockBlock() {
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
      public Real ConstantValue {
        get {
          return this._constantValue;
        }
        set {
          this._constantValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _constantValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _constantValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatformSoundEffectOverrideDescriptorBlockBlock : IBlock {
      private CharInteger _overrideDescriptor = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectOverrideDescriptorBlockBlock() {
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
      public CharInteger OverrideDescriptor {
        get {
          return this._overrideDescriptor;
        }
        set {
          this._overrideDescriptor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _overrideDescriptor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _overrideDescriptor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltRuntimePermutationBitVectorBlockBlock : IBlock {
      private CharInteger _unnamed0 = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltRuntimePermutationBitVectorBlockBlock() {
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
      public CharInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
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
    public class SoundPermutationChunkBlockBlock : IBlock {
      private LongInteger _fileOffset = new LongInteger();
      private LongInteger _unnamed0 = new LongInteger();
      private LongInteger _unnamed1 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SoundPermutationChunkBlockBlock() {
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
      public LongInteger FileOffset {
        get {
          return this._fileOffset;
        }
        set {
          this._fileOffset = value;
        }
      }
      public LongInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public LongInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fileOffset.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _fileOffset.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundGestaltPromotionsBlockBlock : IBlock {
      private Block _promotionRules = new Block();
      private Block _unnamed0 = new Block();
      private Pad _unnamed1;
      public BlockCollection<SoundPromotionRuleBlockBlock> _promotionRulesList = new BlockCollection<SoundPromotionRuleBlockBlock>();
      public BlockCollection<SoundPromotionRuntimeTimerBlockBlock> _unnamed0List = new BlockCollection<SoundPromotionRuntimeTimerBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltPromotionsBlockBlock() {
        this._unnamed1 = new Pad(12);
      }
      public BlockCollection<SoundPromotionRuleBlockBlock> PromotionRules {
        get {
          return this._promotionRulesList;
        }
      }
      public BlockCollection<SoundPromotionRuntimeTimerBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PromotionRules.BlockCount; x++)
{
  IBlock block = PromotionRules.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
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
        _promotionRules.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _promotionRules.Count); x = (x + 1)) {
          PromotionRules.Add(new SoundPromotionRuleBlockBlock());
          PromotionRules[x].Read(reader);
        }
        for (x = 0; (x < _promotionRules.Count); x = (x + 1)) {
          PromotionRules[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new SoundPromotionRuntimeTimerBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_promotionRules.Count = PromotionRules.Count;
        _promotionRules.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _promotionRules.Count); x = (x + 1)) {
          PromotionRules[x].Write(writer);
        }
        for (x = 0; (x < _promotionRules.Count); x = (x + 1)) {
          PromotionRules[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
      }
    }
    public class SoundPromotionRuleBlockBlock : IBlock {
      private ShortBlockIndex _pitchRange = new ShortBlockIndex();
      private ShortInteger _maximumPlayingCount = new ShortInteger();
      private Real _suppressionTime = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public SoundPromotionRuleBlockBlock() {
if (this._pitchRange is System.ComponentModel.INotifyPropertyChanged)
  (this._pitchRange as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _pitchRange.ToString();
        }
      }
      public ShortBlockIndex PitchRange {
        get {
          return this._pitchRange;
        }
        set {
          this._pitchRange = value;
        }
      }
      public ShortInteger MaximumPlayingCount {
        get {
          return this._maximumPlayingCount;
        }
        set {
          this._maximumPlayingCount = value;
        }
      }
      public Real SuppressionTime {
        get {
          return this._suppressionTime;
        }
        set {
          this._suppressionTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pitchRange.Read(reader);
        _maximumPlayingCount.Read(reader);
        _suppressionTime.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _pitchRange.Write(bw);
        _maximumPlayingCount.Write(bw);
        _suppressionTime.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SoundPromotionRuntimeTimerBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SoundPromotionRuntimeTimerBlockBlock() {
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
      public LongInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
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
    public class SoundGestaltExtraInfoBlockBlock : IBlock {
      private Block _encodedPermutationSection = new Block();
      private ResourceBlock _coconutsData = new ResourceBlock();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Skip _geometrySelfReference;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      public BlockCollection<SoundEncodedDialogueSectionBlockBlock> _encodedPermutationSectionList = new BlockCollection<SoundEncodedDialogueSectionBlockBlock>();
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundGestaltExtraInfoBlockBlock() {
        this._geometrySelfReference = new Skip(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
      }
      public BlockCollection<SoundEncodedDialogueSectionBlockBlock> EncodedPermutationSection {
        get {
          return this._encodedPermutationSectionList;
        }
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<EncodedPermutationSection.BlockCount; x++)
{
  IBlock block = EncodedPermutationSection.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
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
      public ResourceBlock CoconutsData {
        get {
          return this._coconutsData;
        }
        set {
          this._coconutsData = value;
        }
      }
      public LongInteger SectionDataSize {
        get {
          return this._sectionDataSize;
        }
        set {
          this._sectionDataSize = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public ShortInteger OwnerTagSectionOffset {
        get {
          return this._ownerTagSectionOffset;
        }
        set {
          this._ownerTagSectionOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _encodedPermutationSection.Read(reader);
        _coconutsData.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _geometrySelfReference.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _encodedPermutationSection.Count); x = (x + 1)) {
          EncodedPermutationSection.Add(new SoundEncodedDialogueSectionBlockBlock());
          EncodedPermutationSection[x].Read(reader);
        }
        for (x = 0; (x < _encodedPermutationSection.Count); x = (x + 1)) {
          EncodedPermutationSection[x].ReadChildData(reader);
        }
        _coconutsData.ReadBinary(reader);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_encodedPermutationSection.Count = EncodedPermutationSection.Count;
        _encodedPermutationSection.Write(bw);
        _coconutsData.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _geometrySelfReference.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _encodedPermutationSection.Count); x = (x + 1)) {
          EncodedPermutationSection[x].Write(writer);
        }
        for (x = 0; (x < _encodedPermutationSection.Count); x = (x + 1)) {
          EncodedPermutationSection[x].WriteChildData(writer);
        }
        _coconutsData.WriteBinary(writer);
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
      }
    }
    public class SoundEncodedDialogueSectionBlockBlock : IBlock {
      private Data _encodedData = new Data();
      private Block _soundDialogueInfo = new Block();
      public BlockCollection<SoundPermutationDialogueInfoBlockBlock> _soundDialogueInfoList = new BlockCollection<SoundPermutationDialogueInfoBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEncodedDialogueSectionBlockBlock() {
      }
      public BlockCollection<SoundPermutationDialogueInfoBlockBlock> SoundDialogueInfo {
        get {
          return this._soundDialogueInfoList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SoundDialogueInfo.BlockCount; x++)
{
  IBlock block = SoundDialogueInfo.GetBlock(x);
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
      public Data EncodedData {
        get {
          return this._encodedData;
        }
        set {
          this._encodedData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _encodedData.Read(reader);
        _soundDialogueInfo.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _encodedData.ReadBinary(reader);
        for (x = 0; (x < _soundDialogueInfo.Count); x = (x + 1)) {
          SoundDialogueInfo.Add(new SoundPermutationDialogueInfoBlockBlock());
          SoundDialogueInfo[x].Read(reader);
        }
        for (x = 0; (x < _soundDialogueInfo.Count); x = (x + 1)) {
          SoundDialogueInfo[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _encodedData.Write(bw);
_soundDialogueInfo.Count = SoundDialogueInfo.Count;
        _soundDialogueInfo.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _encodedData.WriteBinary(writer);
        for (x = 0; (x < _soundDialogueInfo.Count); x = (x + 1)) {
          SoundDialogueInfo[x].Write(writer);
        }
        for (x = 0; (x < _soundDialogueInfo.Count); x = (x + 1)) {
          SoundDialogueInfo[x].WriteChildData(writer);
        }
      }
    }
    public class SoundPermutationDialogueInfoBlockBlock : IBlock {
      private LongInteger _mouthDataOffset = new LongInteger();
      private LongInteger _mouthDataLength = new LongInteger();
      private LongInteger _lipsyncDataOffset = new LongInteger();
      private LongInteger _lipsyncDataLength = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SoundPermutationDialogueInfoBlockBlock() {
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
      public LongInteger MouthDataOffset {
        get {
          return this._mouthDataOffset;
        }
        set {
          this._mouthDataOffset = value;
        }
      }
      public LongInteger MouthDataLength {
        get {
          return this._mouthDataLength;
        }
        set {
          this._mouthDataLength = value;
        }
      }
      public LongInteger LipsyncDataOffset {
        get {
          return this._lipsyncDataOffset;
        }
        set {
          this._lipsyncDataOffset = value;
        }
      }
      public LongInteger LipsyncDataLength {
        get {
          return this._lipsyncDataLength;
        }
        set {
          this._lipsyncDataLength = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mouthDataOffset.Read(reader);
        _mouthDataLength.Read(reader);
        _lipsyncDataOffset.Read(reader);
        _lipsyncDataLength.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _mouthDataOffset.Write(bw);
        _mouthDataLength.Write(bw);
        _lipsyncDataOffset.Write(bw);
        _lipsyncDataLength.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalGeometryBlockResourceBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private ShortInteger _primaryLocator = new ShortInteger();
      private ShortInteger _secondaryLocator = new ShortInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private LongInteger _resourceDataOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryBlockResourceBlockBlock() {
        this._type = new Enum(1);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger PrimaryLocator {
        get {
          return this._primaryLocator;
        }
        set {
          this._primaryLocator = value;
        }
      }
      public ShortInteger SecondaryLocator {
        get {
          return this._secondaryLocator;
        }
        set {
          this._secondaryLocator = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public LongInteger ResourceDataOffset {
        get {
          return this._resourceDataOffset;
        }
        set {
          this._resourceDataOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _primaryLocator.Read(reader);
        _secondaryLocator.Read(reader);
        _resourceDataSize.Read(reader);
        _resourceDataOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _primaryLocator.Write(bw);
        _secondaryLocator.Write(bw);
        _resourceDataSize.Write(bw);
        _resourceDataOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
