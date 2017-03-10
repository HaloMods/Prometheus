// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_effect_collection'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_effect_collection : Interfaces.Pool.Tag {
    private SoundEffectCollectionBlockBlock soundEffectCollectionValues = new SoundEffectCollectionBlockBlock();
    public virtual SoundEffectCollectionBlockBlock SoundEffectCollectionValues {
      get {
        return soundEffectCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundEffectCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_effect_collection";
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
soundEffectCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundEffectCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundEffectCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundEffectCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class SoundEffectCollectionBlockBlock : IBlock {
      private Block _soundEffects = new Block();
      public BlockCollection<PlatformSoundPlaybackBlockBlock> _soundEffectsList = new BlockCollection<PlatformSoundPlaybackBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectCollectionBlockBlock() {
      }
      public BlockCollection<PlatformSoundPlaybackBlockBlock> SoundEffects {
        get {
          return this._soundEffectsList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
        _soundEffects.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects.Add(new PlatformSoundPlaybackBlockBlock());
          SoundEffects[x].Read(reader);
        }
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_soundEffects.Count = SoundEffects.Count;
        _soundEffects.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].Write(writer);
        }
        for (x = 0; (x < _soundEffects.Count); x = (x + 1)) {
          SoundEffects[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundPlaybackBlockBlock : IBlock {
      private StringId _name = new StringId();
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
      public PlatformSoundPlaybackBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
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
        _name.ReadString(reader);
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
        _name.Write(bw);
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
        _name.WriteString(writer);
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
  }
}
