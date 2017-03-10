// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'ai_dialogue_globals'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class ai_dialogue_globals : Interfaces.Pool.Tag {
    private AiDialogueGlobalsBlockBlock aiDialogueGlobalsValues = new AiDialogueGlobalsBlockBlock();
    public virtual AiDialogueGlobalsBlockBlock AiDialogueGlobalsValues {
      get {
        return aiDialogueGlobalsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(AiDialogueGlobalsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "ai_dialogue_globals";
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
aiDialogueGlobalsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
aiDialogueGlobalsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
aiDialogueGlobalsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
aiDialogueGlobalsValues.WriteChildData(writer);
    }
    #endregion
    public class AiDialogueGlobalsBlockBlock : IBlock {
      private Block _vocalizations = new Block();
      private Block _patterns = new Block();
      private Pad _unnamed0;
      private Block _dialogueData = new Block();
      private Block _involuntaryData = new Block();
      public BlockCollection<VocalizationDefinitionsBlock0Block> _vocalizationsList = new BlockCollection<VocalizationDefinitionsBlock0Block>();
      public BlockCollection<VocalizationPatternsBlockBlock> _patternsList = new BlockCollection<VocalizationPatternsBlockBlock>();
      public BlockCollection<DialogueDataBlockBlock> _dialogueDataList = new BlockCollection<DialogueDataBlockBlock>();
      public BlockCollection<InvoluntaryDataBlockBlock> _involuntaryDataList = new BlockCollection<InvoluntaryDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiDialogueGlobalsBlockBlock() {
        this._unnamed0 = new Pad(12);
      }
      public BlockCollection<VocalizationDefinitionsBlock0Block> Vocalizations {
        get {
          return this._vocalizationsList;
        }
      }
      public BlockCollection<VocalizationPatternsBlockBlock> Patterns {
        get {
          return this._patternsList;
        }
      }
      public BlockCollection<DialogueDataBlockBlock> DialogueData {
        get {
          return this._dialogueDataList;
        }
      }
      public BlockCollection<InvoluntaryDataBlockBlock> InvoluntaryData {
        get {
          return this._involuntaryDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Vocalizations.BlockCount; x++)
{
  IBlock block = Vocalizations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Patterns.BlockCount; x++)
{
  IBlock block = Patterns.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DialogueData.BlockCount; x++)
{
  IBlock block = DialogueData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InvoluntaryData.BlockCount; x++)
{
  IBlock block = InvoluntaryData.GetBlock(x);
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
        _vocalizations.Read(reader);
        _patterns.Read(reader);
        _unnamed0.Read(reader);
        _dialogueData.Read(reader);
        _involuntaryData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations.Add(new VocalizationDefinitionsBlock0Block());
          Vocalizations[x].Read(reader);
        }
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _patterns.Count); x = (x + 1)) {
          Patterns.Add(new VocalizationPatternsBlockBlock());
          Patterns[x].Read(reader);
        }
        for (x = 0; (x < _patterns.Count); x = (x + 1)) {
          Patterns[x].ReadChildData(reader);
        }
        for (x = 0; (x < _dialogueData.Count); x = (x + 1)) {
          DialogueData.Add(new DialogueDataBlockBlock());
          DialogueData[x].Read(reader);
        }
        for (x = 0; (x < _dialogueData.Count); x = (x + 1)) {
          DialogueData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _involuntaryData.Count); x = (x + 1)) {
          InvoluntaryData.Add(new InvoluntaryDataBlockBlock());
          InvoluntaryData[x].Read(reader);
        }
        for (x = 0; (x < _involuntaryData.Count); x = (x + 1)) {
          InvoluntaryData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_vocalizations.Count = Vocalizations.Count;
        _vocalizations.Write(bw);
_patterns.Count = Patterns.Count;
        _patterns.Write(bw);
        _unnamed0.Write(bw);
_dialogueData.Count = DialogueData.Count;
        _dialogueData.Write(bw);
_involuntaryData.Count = InvoluntaryData.Count;
        _involuntaryData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].Write(writer);
        }
        for (x = 0; (x < _vocalizations.Count); x = (x + 1)) {
          Vocalizations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _patterns.Count); x = (x + 1)) {
          Patterns[x].Write(writer);
        }
        for (x = 0; (x < _patterns.Count); x = (x + 1)) {
          Patterns[x].WriteChildData(writer);
        }
        for (x = 0; (x < _dialogueData.Count); x = (x + 1)) {
          DialogueData[x].Write(writer);
        }
        for (x = 0; (x < _dialogueData.Count); x = (x + 1)) {
          DialogueData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _involuntaryData.Count); x = (x + 1)) {
          InvoluntaryData[x].Write(writer);
        }
        for (x = 0; (x < _involuntaryData.Count); x = (x + 1)) {
          InvoluntaryData[x].WriteChildData(writer);
        }
      }
    }
    public class VocalizationDefinitionsBlock0Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _children = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<VocalizationDefinitionsBlock1Block> _childrenList = new BlockCollection<VocalizationDefinitionsBlock1Block>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock0Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<VocalizationDefinitionsBlock1Block> Children {
        get {
          return this._childrenList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Children.BlockCount; x++)
{
  IBlock block = Children.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _children.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children.Add(new VocalizationDefinitionsBlock1Block());
          Children[x].Read(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_children.Count = Children.Count;
        _children.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].Write(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].WriteChildData(writer);
        }
      }
    }
    public class ResponseBlockBlock : IBlock {
      private StringId _vocalizationName = new StringId();
      private Flags _flags;
      private ShortInteger _vocalizationIndexPostProcess = new ShortInteger();
      private Enum _responseType;
      private ShortInteger _dialogueIndexImport = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ResponseBlockBlock() {
        this._flags = new Flags(2);
        this._responseType = new Enum(2);
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
      public StringId VocalizationName {
        get {
          return this._vocalizationName;
        }
        set {
          this._vocalizationName = value;
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
      public ShortInteger VocalizationIndexPostProcess {
        get {
          return this._vocalizationIndexPostProcess;
        }
        set {
          this._vocalizationIndexPostProcess = value;
        }
      }
      public Enum ResponseType {
        get {
          return this._responseType;
        }
        set {
          this._responseType = value;
        }
      }
      public ShortInteger DialogueIndexImport {
        get {
          return this._dialogueIndexImport;
        }
        set {
          this._dialogueIndexImport = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalizationName.Read(reader);
        _flags.Read(reader);
        _vocalizationIndexPostProcess.Read(reader);
        _responseType.Read(reader);
        _dialogueIndexImport.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vocalizationName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalizationName.Write(bw);
        _flags.Write(bw);
        _vocalizationIndexPostProcess.Write(bw);
        _responseType.Write(bw);
        _dialogueIndexImport.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vocalizationName.WriteString(writer);
      }
    }
    public class VocalizationDefinitionsBlock1Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _children = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<VocalizationDefinitionsBlock2Block> _childrenList = new BlockCollection<VocalizationDefinitionsBlock2Block>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock1Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<VocalizationDefinitionsBlock2Block> Children {
        get {
          return this._childrenList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Children.BlockCount; x++)
{
  IBlock block = Children.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _children.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children.Add(new VocalizationDefinitionsBlock2Block());
          Children[x].Read(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_children.Count = Children.Count;
        _children.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].Write(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].WriteChildData(writer);
        }
      }
    }
    public class VocalizationDefinitionsBlock2Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _children = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<VocalizationDefinitionsBlock3Block> _childrenList = new BlockCollection<VocalizationDefinitionsBlock3Block>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock2Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<VocalizationDefinitionsBlock3Block> Children {
        get {
          return this._childrenList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Children.BlockCount; x++)
{
  IBlock block = Children.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _children.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children.Add(new VocalizationDefinitionsBlock3Block());
          Children[x].Read(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_children.Count = Children.Count;
        _children.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].Write(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].WriteChildData(writer);
        }
      }
    }
    public class VocalizationDefinitionsBlock3Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _children = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<VocalizationDefinitionsBlock4Block> _childrenList = new BlockCollection<VocalizationDefinitionsBlock4Block>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock3Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<VocalizationDefinitionsBlock4Block> Children {
        get {
          return this._childrenList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Children.BlockCount; x++)
{
  IBlock block = Children.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _children.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children.Add(new VocalizationDefinitionsBlock4Block());
          Children[x].Read(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_children.Count = Children.Count;
        _children.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].Write(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].WriteChildData(writer);
        }
      }
    }
    public class VocalizationDefinitionsBlock4Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _children = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<VocalizationDefinitionsBlock5Block> _childrenList = new BlockCollection<VocalizationDefinitionsBlock5Block>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock4Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<VocalizationDefinitionsBlock5Block> Children {
        get {
          return this._childrenList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Children.BlockCount; x++)
{
  IBlock block = Children.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _children.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children.Add(new VocalizationDefinitionsBlock5Block());
          Children[x].Read(reader);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_children.Count = Children.Count;
        _children.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].Write(writer);
        }
        for (x = 0; (x < _children.Count); x = (x + 1)) {
          Children[x].WriteChildData(writer);
        }
      }
    }
    public class VocalizationDefinitionsBlock5Block : IBlock {
      private StringId _vocalization = new StringId();
      private StringId _parentVocalization = new StringId();
      private ShortInteger _parentIndex = new ShortInteger();
      private Enum _priority;
      private Flags _flags;
      private Enum _glanceBehavior;
      private Enum _glanceRecipientBehavior;
      private Enum _perceptionType;
      private Enum _maxCombatStatus;
      private Enum _animationImpulse;
      private Enum _overlapPriority;
      private Real _soundRepetitionDelay = new Real();
      private Real _allowableQueueDelay = new Real();
      private Real _preVocDelay = new Real();
      private Real _notificationDelay = new Real();
      private Real _postVocDelay = new Real();
      private Real _repeatDelay = new Real();
      private Real _weight = new Real();
      private Real _speakerFreezeTime = new Real();
      private Real _listenerFreezeTime = new Real();
      private Enum _speakerEmotion;
      private Enum _listenerEmotion;
      private Real _playerSkipFraction = new Real();
      private Real _skipFraction = new Real();
      private StringId _sampleLine = new StringId();
      private Block _reponses = new Block();
      private Block _unnamed0 = new Block();
      public BlockCollection<ResponseBlockBlock> _reponsesList = new BlockCollection<ResponseBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed0List = new BlockCollection<GNullBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public VocalizationDefinitionsBlock5Block() {
if (this._vocalization is System.ComponentModel.INotifyPropertyChanged)
  (this._vocalization as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._priority = new Enum(2);
        this._flags = new Flags(4);
        this._glanceBehavior = new Enum(2);
        this._glanceRecipientBehavior = new Enum(2);
        this._perceptionType = new Enum(2);
        this._maxCombatStatus = new Enum(2);
        this._animationImpulse = new Enum(2);
        this._overlapPriority = new Enum(2);
        this._speakerEmotion = new Enum(2);
        this._listenerEmotion = new Enum(2);
      }
      public BlockCollection<ResponseBlockBlock> Reponses {
        get {
          return this._reponsesList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reponses.BlockCount; x++)
{
  IBlock block = Reponses.GetBlock(x);
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
return _vocalization.ToString();
        }
      }
      public StringId Vocalization {
        get {
          return this._vocalization;
        }
        set {
          this._vocalization = value;
        }
      }
      public StringId ParentVocalization {
        get {
          return this._parentVocalization;
        }
        set {
          this._parentVocalization = value;
        }
      }
      public ShortInteger ParentIndex {
        get {
          return this._parentIndex;
        }
        set {
          this._parentIndex = value;
        }
      }
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
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
      public Enum GlanceBehavior {
        get {
          return this._glanceBehavior;
        }
        set {
          this._glanceBehavior = value;
        }
      }
      public Enum GlanceRecipientBehavior {
        get {
          return this._glanceRecipientBehavior;
        }
        set {
          this._glanceRecipientBehavior = value;
        }
      }
      public Enum PerceptionType {
        get {
          return this._perceptionType;
        }
        set {
          this._perceptionType = value;
        }
      }
      public Enum MaxCombatStatus {
        get {
          return this._maxCombatStatus;
        }
        set {
          this._maxCombatStatus = value;
        }
      }
      public Enum AnimationImpulse {
        get {
          return this._animationImpulse;
        }
        set {
          this._animationImpulse = value;
        }
      }
      public Enum OverlapPriority {
        get {
          return this._overlapPriority;
        }
        set {
          this._overlapPriority = value;
        }
      }
      public Real SoundRepetitionDelay {
        get {
          return this._soundRepetitionDelay;
        }
        set {
          this._soundRepetitionDelay = value;
        }
      }
      public Real AllowableQueueDelay {
        get {
          return this._allowableQueueDelay;
        }
        set {
          this._allowableQueueDelay = value;
        }
      }
      public Real PreVocDelay {
        get {
          return this._preVocDelay;
        }
        set {
          this._preVocDelay = value;
        }
      }
      public Real NotificationDelay {
        get {
          return this._notificationDelay;
        }
        set {
          this._notificationDelay = value;
        }
      }
      public Real PostVocDelay {
        get {
          return this._postVocDelay;
        }
        set {
          this._postVocDelay = value;
        }
      }
      public Real RepeatDelay {
        get {
          return this._repeatDelay;
        }
        set {
          this._repeatDelay = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public Real SpeakerFreezeTime {
        get {
          return this._speakerFreezeTime;
        }
        set {
          this._speakerFreezeTime = value;
        }
      }
      public Real ListenerFreezeTime {
        get {
          return this._listenerFreezeTime;
        }
        set {
          this._listenerFreezeTime = value;
        }
      }
      public Enum SpeakerEmotion {
        get {
          return this._speakerEmotion;
        }
        set {
          this._speakerEmotion = value;
        }
      }
      public Enum ListenerEmotion {
        get {
          return this._listenerEmotion;
        }
        set {
          this._listenerEmotion = value;
        }
      }
      public Real PlayerSkipFraction {
        get {
          return this._playerSkipFraction;
        }
        set {
          this._playerSkipFraction = value;
        }
      }
      public Real SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public StringId SampleLine {
        get {
          return this._sampleLine;
        }
        set {
          this._sampleLine = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vocalization.Read(reader);
        _parentVocalization.Read(reader);
        _parentIndex.Read(reader);
        _priority.Read(reader);
        _flags.Read(reader);
        _glanceBehavior.Read(reader);
        _glanceRecipientBehavior.Read(reader);
        _perceptionType.Read(reader);
        _maxCombatStatus.Read(reader);
        _animationImpulse.Read(reader);
        _overlapPriority.Read(reader);
        _soundRepetitionDelay.Read(reader);
        _allowableQueueDelay.Read(reader);
        _preVocDelay.Read(reader);
        _notificationDelay.Read(reader);
        _postVocDelay.Read(reader);
        _repeatDelay.Read(reader);
        _weight.Read(reader);
        _speakerFreezeTime.Read(reader);
        _listenerFreezeTime.Read(reader);
        _speakerEmotion.Read(reader);
        _listenerEmotion.Read(reader);
        _playerSkipFraction.Read(reader);
        _skipFraction.Read(reader);
        _sampleLine.Read(reader);
        _reponses.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vocalization.ReadString(reader);
        _parentVocalization.ReadString(reader);
        _sampleLine.ReadString(reader);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses.Add(new ResponseBlockBlock());
          Reponses[x].Read(reader);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new GNullBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _vocalization.Write(bw);
        _parentVocalization.Write(bw);
        _parentIndex.Write(bw);
        _priority.Write(bw);
        _flags.Write(bw);
        _glanceBehavior.Write(bw);
        _glanceRecipientBehavior.Write(bw);
        _perceptionType.Write(bw);
        _maxCombatStatus.Write(bw);
        _animationImpulse.Write(bw);
        _overlapPriority.Write(bw);
        _soundRepetitionDelay.Write(bw);
        _allowableQueueDelay.Write(bw);
        _preVocDelay.Write(bw);
        _notificationDelay.Write(bw);
        _postVocDelay.Write(bw);
        _repeatDelay.Write(bw);
        _weight.Write(bw);
        _speakerFreezeTime.Write(bw);
        _listenerFreezeTime.Write(bw);
        _speakerEmotion.Write(bw);
        _listenerEmotion.Write(bw);
        _playerSkipFraction.Write(bw);
        _skipFraction.Write(bw);
        _sampleLine.Write(bw);
_reponses.Count = Reponses.Count;
        _reponses.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vocalization.WriteString(writer);
        _parentVocalization.WriteString(writer);
        _sampleLine.WriteString(writer);
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].Write(writer);
        }
        for (x = 0; (x < _reponses.Count); x = (x + 1)) {
          Reponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
      }
    }
    public class GNullBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public GNullBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class VocalizationPatternsBlockBlock : IBlock {
      private Enum _dialogueType;
      private ShortInteger _vocalizationIndex = new ShortInteger();
      private StringId _vocalizationName = new StringId();
      private Enum _speakerType;
      private Flags _flags;
      private Enum _listenertarget;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Enum _hostility;
      private Enum _damageType;
      private Enum _dangerLevel;
      private Enum _attitude;
      private Pad _unnamed2;
      private Enum _subjectActorType;
      private Enum _causeActorType;
      private Enum _causeType;
      private Enum _subjectType;
      private StringId _causeAiTypeName = new StringId();
      private Enum _spatialRelation;
      private Pad _unnamed3;
      private StringId _subjectAiTypeName = new StringId();
      private Pad _unnamed4;
      private Flags _conditions;
public event System.EventHandler BlockNameChanged;
      public VocalizationPatternsBlockBlock() {
        this._dialogueType = new Enum(2);
        this._speakerType = new Enum(2);
        this._flags = new Flags(2);
        this._listenertarget = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._hostility = new Enum(2);
        this._damageType = new Enum(2);
        this._dangerLevel = new Enum(2);
        this._attitude = new Enum(2);
        this._unnamed2 = new Pad(4);
        this._subjectActorType = new Enum(2);
        this._causeActorType = new Enum(2);
        this._causeType = new Enum(2);
        this._subjectType = new Enum(2);
        this._spatialRelation = new Enum(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(8);
        this._conditions = new Flags(4);
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
      public Enum DialogueType {
        get {
          return this._dialogueType;
        }
        set {
          this._dialogueType = value;
        }
      }
      public ShortInteger VocalizationIndex {
        get {
          return this._vocalizationIndex;
        }
        set {
          this._vocalizationIndex = value;
        }
      }
      public StringId VocalizationName {
        get {
          return this._vocalizationName;
        }
        set {
          this._vocalizationName = value;
        }
      }
      public Enum SpeakerType {
        get {
          return this._speakerType;
        }
        set {
          this._speakerType = value;
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
      public Enum Listenertarget {
        get {
          return this._listenertarget;
        }
        set {
          this._listenertarget = value;
        }
      }
      public Enum Hostility {
        get {
          return this._hostility;
        }
        set {
          this._hostility = value;
        }
      }
      public Enum DamageType {
        get {
          return this._damageType;
        }
        set {
          this._damageType = value;
        }
      }
      public Enum DangerLevel {
        get {
          return this._dangerLevel;
        }
        set {
          this._dangerLevel = value;
        }
      }
      public Enum Attitude {
        get {
          return this._attitude;
        }
        set {
          this._attitude = value;
        }
      }
      public Enum SubjectActorType {
        get {
          return this._subjectActorType;
        }
        set {
          this._subjectActorType = value;
        }
      }
      public Enum CauseActorType {
        get {
          return this._causeActorType;
        }
        set {
          this._causeActorType = value;
        }
      }
      public Enum CauseType {
        get {
          return this._causeType;
        }
        set {
          this._causeType = value;
        }
      }
      public Enum SubjectType {
        get {
          return this._subjectType;
        }
        set {
          this._subjectType = value;
        }
      }
      public StringId CauseAiTypeName {
        get {
          return this._causeAiTypeName;
        }
        set {
          this._causeAiTypeName = value;
        }
      }
      public Enum SpatialRelation {
        get {
          return this._spatialRelation;
        }
        set {
          this._spatialRelation = value;
        }
      }
      public StringId SubjectAiTypeName {
        get {
          return this._subjectAiTypeName;
        }
        set {
          this._subjectAiTypeName = value;
        }
      }
      public Flags Conditions {
        get {
          return this._conditions;
        }
        set {
          this._conditions = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dialogueType.Read(reader);
        _vocalizationIndex.Read(reader);
        _vocalizationName.Read(reader);
        _speakerType.Read(reader);
        _flags.Read(reader);
        _listenertarget.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _hostility.Read(reader);
        _damageType.Read(reader);
        _dangerLevel.Read(reader);
        _attitude.Read(reader);
        _unnamed2.Read(reader);
        _subjectActorType.Read(reader);
        _causeActorType.Read(reader);
        _causeType.Read(reader);
        _subjectType.Read(reader);
        _causeAiTypeName.Read(reader);
        _spatialRelation.Read(reader);
        _unnamed3.Read(reader);
        _subjectAiTypeName.Read(reader);
        _unnamed4.Read(reader);
        _conditions.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vocalizationName.ReadString(reader);
        _causeAiTypeName.ReadString(reader);
        _subjectAiTypeName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _dialogueType.Write(bw);
        _vocalizationIndex.Write(bw);
        _vocalizationName.Write(bw);
        _speakerType.Write(bw);
        _flags.Write(bw);
        _listenertarget.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _hostility.Write(bw);
        _damageType.Write(bw);
        _dangerLevel.Write(bw);
        _attitude.Write(bw);
        _unnamed2.Write(bw);
        _subjectActorType.Write(bw);
        _causeActorType.Write(bw);
        _causeType.Write(bw);
        _subjectType.Write(bw);
        _causeAiTypeName.Write(bw);
        _spatialRelation.Write(bw);
        _unnamed3.Write(bw);
        _subjectAiTypeName.Write(bw);
        _unnamed4.Write(bw);
        _conditions.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vocalizationName.WriteString(writer);
        _causeAiTypeName.WriteString(writer);
        _subjectAiTypeName.WriteString(writer);
      }
    }
    public class DialogueDataBlockBlock : IBlock {
      private ShortInteger _startIndexPostprocess = new ShortInteger();
      private ShortInteger _lengthPostprocess = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public DialogueDataBlockBlock() {
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
      public ShortInteger StartIndexPostprocess {
        get {
          return this._startIndexPostprocess;
        }
        set {
          this._startIndexPostprocess = value;
        }
      }
      public ShortInteger LengthPostprocess {
        get {
          return this._lengthPostprocess;
        }
        set {
          this._lengthPostprocess = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _startIndexPostprocess.Read(reader);
        _lengthPostprocess.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _startIndexPostprocess.Write(bw);
        _lengthPostprocess.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class InvoluntaryDataBlockBlock : IBlock {
      private ShortInteger _involuntaryVocalizationIndex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public InvoluntaryDataBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger InvoluntaryVocalizationIndex {
        get {
          return this._involuntaryVocalizationIndex;
        }
        set {
          this._involuntaryVocalizationIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _involuntaryVocalizationIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _involuntaryVocalizationIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
