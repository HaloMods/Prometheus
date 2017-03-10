// -------------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'user_interface_shared_globals_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class user_interface_shared_globals_definition : Interfaces.Pool.Tag {
    private UserInterfaceSharedGlobalsDefinitionBlockBlock userInterfaceSharedGlobalsDefinitionValues = new UserInterfaceSharedGlobalsDefinitionBlockBlock();
    public virtual UserInterfaceSharedGlobalsDefinitionBlockBlock UserInterfaceSharedGlobalsDefinitionValues {
      get {
        return userInterfaceSharedGlobalsDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UserInterfaceSharedGlobalsDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "user_interface_shared_globals_definition";
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
userInterfaceSharedGlobalsDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
userInterfaceSharedGlobalsDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
userInterfaceSharedGlobalsDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
userInterfaceSharedGlobalsDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class UserInterfaceSharedGlobalsDefinitionBlockBlock : IBlock {
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Real _overlayedScreenAlphaMod = new Real();
      private ShortInteger _incTextUpdatePeriod = new ShortInteger();
      private ShortInteger _incTextBlockCharacter = new ShortInteger();
      private Real _calloutTextScale = new Real();
      private RealARGBColor _progressBarColor = new RealARGBColor();
      private Real _nearClipPlaneDistance = new Real();
      private Real _projectionPlaneDistance = new Real();
      private Real _farClipPlaneDistance = new Real();
      private RealARGBColor _overlayedInterfaceColor = new RealARGBColor();
      private Pad _unnamed8;
      private Block _errors = new Block();
      private TagReference _soundTag = new TagReference();
      private TagReference _soundTag2 = new TagReference();
      private TagReference _soundTag3 = new TagReference();
      private TagReference _soundTag4 = new TagReference();
      private TagReference _soundTag5 = new TagReference();
      private TagReference _soundTag6 = new TagReference();
      private TagReference _soundTag7 = new TagReference();
      private TagReference _soundTag8 = new TagReference();
      private TagReference _soundTag9 = new TagReference();
      private TagReference _soundTag10 = new TagReference();
      private TagReference _soundTag11 = new TagReference();
      private TagReference _unnamed9 = new TagReference();
      private TagReference _soundTag12 = new TagReference();
      private TagReference _unnamed10 = new TagReference();
      private TagReference _unnamed11 = new TagReference();
      private TagReference _unnamed12 = new TagReference();
      private TagReference _globalBitmapsTag = new TagReference();
      private TagReference _unicodeStringListTag = new TagReference();
      private Block _screenAnimations = new Block();
      private Block _shapeGroups = new Block();
      private Block _animations = new Block();
      private Block _listItemSkins = new Block();
      private TagReference _buttonKeyTypeStrings = new TagReference();
      private TagReference _gameTypeStrings = new TagReference();
      private TagReference _unnamed13 = new TagReference();
      private Block _skillMappings = new Block();
      private Enum _fullScreenHeaderTextFont;
      private Enum _largeDialogHeaderTextFont;
      private Enum _halfDialogHeaderTextFont;
      private Enum _qtrDialogHeaderTextFont;
      private RealARGBColor _defaultTextColor = new RealARGBColor();
      private Rectangle2D _fullScreenHeaderTextBounds = new Rectangle2D();
      private Rectangle2D _fullScreenButtonKeyTextBounds = new Rectangle2D();
      private Rectangle2D _largeDialogHeaderTextBounds = new Rectangle2D();
      private Rectangle2D _largeDialogButtonKeyTextBounds = new Rectangle2D();
      private Rectangle2D _halfDialogHeaderTextBounds = new Rectangle2D();
      private Rectangle2D _halfDialogButtonKeyTextBounds = new Rectangle2D();
      private Rectangle2D _qtrDialogHeaderTextBounds = new Rectangle2D();
      private Rectangle2D _qtrDialogButtonKeyTextBounds = new Rectangle2D();
      private TagReference _mainMenuMusic = new TagReference();
      private LongInteger _musicFadeTime = new LongInteger();
      public BlockCollection<UiErrorCategoryBlockBlock> _errorsList = new BlockCollection<UiErrorCategoryBlockBlock>();
      public BlockCollection<AnimationReferenceBlockBlock> _screenAnimationsList = new BlockCollection<AnimationReferenceBlockBlock>();
      public BlockCollection<ShapeGroupReferenceBlockBlock> _shapeGroupsList = new BlockCollection<ShapeGroupReferenceBlockBlock>();
      public BlockCollection<PersistentBackgroundAnimationBlockBlock> _animationsList = new BlockCollection<PersistentBackgroundAnimationBlockBlock>();
      public BlockCollection<ListSkinReferenceBlockBlock> _listItemSkinsList = new BlockCollection<ListSkinReferenceBlockBlock>();
      public BlockCollection<SkillToRankMappingBlockBlock> _skillMappingsList = new BlockCollection<SkillToRankMappingBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserInterfaceSharedGlobalsDefinitionBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(8);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(12);
        this._fullScreenHeaderTextFont = new Enum(2);
        this._largeDialogHeaderTextFont = new Enum(2);
        this._halfDialogHeaderTextFont = new Enum(2);
        this._qtrDialogHeaderTextFont = new Enum(2);
      }
      public BlockCollection<UiErrorCategoryBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public BlockCollection<AnimationReferenceBlockBlock> ScreenAnimations {
        get {
          return this._screenAnimationsList;
        }
      }
      public BlockCollection<ShapeGroupReferenceBlockBlock> ShapeGroups {
        get {
          return this._shapeGroupsList;
        }
      }
      public BlockCollection<PersistentBackgroundAnimationBlockBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public BlockCollection<ListSkinReferenceBlockBlock> ListItemSkins {
        get {
          return this._listItemSkinsList;
        }
      }
      public BlockCollection<SkillToRankMappingBlockBlock> SkillMappings {
        get {
          return this._skillMappingsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_soundTag.Value);
references.Add(_soundTag2.Value);
references.Add(_soundTag3.Value);
references.Add(_soundTag4.Value);
references.Add(_soundTag5.Value);
references.Add(_soundTag6.Value);
references.Add(_soundTag7.Value);
references.Add(_soundTag8.Value);
references.Add(_soundTag9.Value);
references.Add(_soundTag10.Value);
references.Add(_soundTag11.Value);
references.Add(_unnamed9.Value);
references.Add(_soundTag12.Value);
references.Add(_unnamed10.Value);
references.Add(_unnamed11.Value);
references.Add(_unnamed12.Value);
references.Add(_globalBitmapsTag.Value);
references.Add(_unicodeStringListTag.Value);
references.Add(_buttonKeyTypeStrings.Value);
references.Add(_gameTypeStrings.Value);
references.Add(_unnamed13.Value);
references.Add(_mainMenuMusic.Value);
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScreenAnimations.BlockCount; x++)
{
  IBlock block = ScreenAnimations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ShapeGroups.BlockCount; x++)
{
  IBlock block = ShapeGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ListItemSkins.BlockCount; x++)
{
  IBlock block = ListItemSkins.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SkillMappings.BlockCount; x++)
{
  IBlock block = SkillMappings.GetBlock(x);
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
      public Real OverlayedScreenAlphaMod {
        get {
          return this._overlayedScreenAlphaMod;
        }
        set {
          this._overlayedScreenAlphaMod = value;
        }
      }
      public ShortInteger IncTextUpdatePeriod {
        get {
          return this._incTextUpdatePeriod;
        }
        set {
          this._incTextUpdatePeriod = value;
        }
      }
      public ShortInteger IncTextBlockCharacter {
        get {
          return this._incTextBlockCharacter;
        }
        set {
          this._incTextBlockCharacter = value;
        }
      }
      public Real CalloutTextScale {
        get {
          return this._calloutTextScale;
        }
        set {
          this._calloutTextScale = value;
        }
      }
      public RealARGBColor ProgressBarColor {
        get {
          return this._progressBarColor;
        }
        set {
          this._progressBarColor = value;
        }
      }
      public Real NearClipPlaneDistance {
        get {
          return this._nearClipPlaneDistance;
        }
        set {
          this._nearClipPlaneDistance = value;
        }
      }
      public Real ProjectionPlaneDistance {
        get {
          return this._projectionPlaneDistance;
        }
        set {
          this._projectionPlaneDistance = value;
        }
      }
      public Real FarClipPlaneDistance {
        get {
          return this._farClipPlaneDistance;
        }
        set {
          this._farClipPlaneDistance = value;
        }
      }
      public RealARGBColor OverlayedInterfaceColor {
        get {
          return this._overlayedInterfaceColor;
        }
        set {
          this._overlayedInterfaceColor = value;
        }
      }
      public TagReference SoundTag {
        get {
          return this._soundTag;
        }
        set {
          this._soundTag = value;
        }
      }
      public TagReference SoundTag2 {
        get {
          return this._soundTag2;
        }
        set {
          this._soundTag2 = value;
        }
      }
      public TagReference SoundTag3 {
        get {
          return this._soundTag3;
        }
        set {
          this._soundTag3 = value;
        }
      }
      public TagReference SoundTag4 {
        get {
          return this._soundTag4;
        }
        set {
          this._soundTag4 = value;
        }
      }
      public TagReference SoundTag5 {
        get {
          return this._soundTag5;
        }
        set {
          this._soundTag5 = value;
        }
      }
      public TagReference SoundTag6 {
        get {
          return this._soundTag6;
        }
        set {
          this._soundTag6 = value;
        }
      }
      public TagReference SoundTag7 {
        get {
          return this._soundTag7;
        }
        set {
          this._soundTag7 = value;
        }
      }
      public TagReference SoundTag8 {
        get {
          return this._soundTag8;
        }
        set {
          this._soundTag8 = value;
        }
      }
      public TagReference SoundTag9 {
        get {
          return this._soundTag9;
        }
        set {
          this._soundTag9 = value;
        }
      }
      public TagReference SoundTag10 {
        get {
          return this._soundTag10;
        }
        set {
          this._soundTag10 = value;
        }
      }
      public TagReference SoundTag11 {
        get {
          return this._soundTag11;
        }
        set {
          this._soundTag11 = value;
        }
      }
      public TagReference unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public TagReference SoundTag12 {
        get {
          return this._soundTag12;
        }
        set {
          this._soundTag12 = value;
        }
      }
      public TagReference unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public TagReference unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public TagReference unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public TagReference GlobalBitmapsTag {
        get {
          return this._globalBitmapsTag;
        }
        set {
          this._globalBitmapsTag = value;
        }
      }
      public TagReference UnicodeStringListTag {
        get {
          return this._unicodeStringListTag;
        }
        set {
          this._unicodeStringListTag = value;
        }
      }
      public TagReference ButtonKeyTypeStrings {
        get {
          return this._buttonKeyTypeStrings;
        }
        set {
          this._buttonKeyTypeStrings = value;
        }
      }
      public TagReference GameTypeStrings {
        get {
          return this._gameTypeStrings;
        }
        set {
          this._gameTypeStrings = value;
        }
      }
      public TagReference unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public Enum FullScreenHeaderTextFont {
        get {
          return this._fullScreenHeaderTextFont;
        }
        set {
          this._fullScreenHeaderTextFont = value;
        }
      }
      public Enum LargeDialogHeaderTextFont {
        get {
          return this._largeDialogHeaderTextFont;
        }
        set {
          this._largeDialogHeaderTextFont = value;
        }
      }
      public Enum HalfDialogHeaderTextFont {
        get {
          return this._halfDialogHeaderTextFont;
        }
        set {
          this._halfDialogHeaderTextFont = value;
        }
      }
      public Enum QtrDialogHeaderTextFont {
        get {
          return this._qtrDialogHeaderTextFont;
        }
        set {
          this._qtrDialogHeaderTextFont = value;
        }
      }
      public RealARGBColor DefaultTextColor {
        get {
          return this._defaultTextColor;
        }
        set {
          this._defaultTextColor = value;
        }
      }
      public Rectangle2D FullScreenHeaderTextBounds {
        get {
          return this._fullScreenHeaderTextBounds;
        }
        set {
          this._fullScreenHeaderTextBounds = value;
        }
      }
      public Rectangle2D FullScreenButtonKeyTextBounds {
        get {
          return this._fullScreenButtonKeyTextBounds;
        }
        set {
          this._fullScreenButtonKeyTextBounds = value;
        }
      }
      public Rectangle2D LargeDialogHeaderTextBounds {
        get {
          return this._largeDialogHeaderTextBounds;
        }
        set {
          this._largeDialogHeaderTextBounds = value;
        }
      }
      public Rectangle2D LargeDialogButtonKeyTextBounds {
        get {
          return this._largeDialogButtonKeyTextBounds;
        }
        set {
          this._largeDialogButtonKeyTextBounds = value;
        }
      }
      public Rectangle2D HalfDialogHeaderTextBounds {
        get {
          return this._halfDialogHeaderTextBounds;
        }
        set {
          this._halfDialogHeaderTextBounds = value;
        }
      }
      public Rectangle2D HalfDialogButtonKeyTextBounds {
        get {
          return this._halfDialogButtonKeyTextBounds;
        }
        set {
          this._halfDialogButtonKeyTextBounds = value;
        }
      }
      public Rectangle2D QtrDialogHeaderTextBounds {
        get {
          return this._qtrDialogHeaderTextBounds;
        }
        set {
          this._qtrDialogHeaderTextBounds = value;
        }
      }
      public Rectangle2D QtrDialogButtonKeyTextBounds {
        get {
          return this._qtrDialogButtonKeyTextBounds;
        }
        set {
          this._qtrDialogButtonKeyTextBounds = value;
        }
      }
      public TagReference MainMenuMusic {
        get {
          return this._mainMenuMusic;
        }
        set {
          this._mainMenuMusic = value;
        }
      }
      public LongInteger MusicFadeTime {
        get {
          return this._musicFadeTime;
        }
        set {
          this._musicFadeTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _overlayedScreenAlphaMod.Read(reader);
        _incTextUpdatePeriod.Read(reader);
        _incTextBlockCharacter.Read(reader);
        _calloutTextScale.Read(reader);
        _progressBarColor.Read(reader);
        _nearClipPlaneDistance.Read(reader);
        _projectionPlaneDistance.Read(reader);
        _farClipPlaneDistance.Read(reader);
        _overlayedInterfaceColor.Read(reader);
        _unnamed8.Read(reader);
        _errors.Read(reader);
        _soundTag.Read(reader);
        _soundTag2.Read(reader);
        _soundTag3.Read(reader);
        _soundTag4.Read(reader);
        _soundTag5.Read(reader);
        _soundTag6.Read(reader);
        _soundTag7.Read(reader);
        _soundTag8.Read(reader);
        _soundTag9.Read(reader);
        _soundTag10.Read(reader);
        _soundTag11.Read(reader);
        _unnamed9.Read(reader);
        _soundTag12.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _globalBitmapsTag.Read(reader);
        _unicodeStringListTag.Read(reader);
        _screenAnimations.Read(reader);
        _shapeGroups.Read(reader);
        _animations.Read(reader);
        _listItemSkins.Read(reader);
        _buttonKeyTypeStrings.Read(reader);
        _gameTypeStrings.Read(reader);
        _unnamed13.Read(reader);
        _skillMappings.Read(reader);
        _fullScreenHeaderTextFont.Read(reader);
        _largeDialogHeaderTextFont.Read(reader);
        _halfDialogHeaderTextFont.Read(reader);
        _qtrDialogHeaderTextFont.Read(reader);
        _defaultTextColor.Read(reader);
        _fullScreenHeaderTextBounds.Read(reader);
        _fullScreenButtonKeyTextBounds.Read(reader);
        _largeDialogHeaderTextBounds.Read(reader);
        _largeDialogButtonKeyTextBounds.Read(reader);
        _halfDialogHeaderTextBounds.Read(reader);
        _halfDialogButtonKeyTextBounds.Read(reader);
        _qtrDialogHeaderTextBounds.Read(reader);
        _qtrDialogButtonKeyTextBounds.Read(reader);
        _mainMenuMusic.Read(reader);
        _musicFadeTime.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new UiErrorCategoryBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
        _soundTag.ReadString(reader);
        _soundTag2.ReadString(reader);
        _soundTag3.ReadString(reader);
        _soundTag4.ReadString(reader);
        _soundTag5.ReadString(reader);
        _soundTag6.ReadString(reader);
        _soundTag7.ReadString(reader);
        _soundTag8.ReadString(reader);
        _soundTag9.ReadString(reader);
        _soundTag10.ReadString(reader);
        _soundTag11.ReadString(reader);
        _unnamed9.ReadString(reader);
        _soundTag12.ReadString(reader);
        _unnamed10.ReadString(reader);
        _unnamed11.ReadString(reader);
        _unnamed12.ReadString(reader);
        _globalBitmapsTag.ReadString(reader);
        _unicodeStringListTag.ReadString(reader);
        for (x = 0; (x < _screenAnimations.Count); x = (x + 1)) {
          ScreenAnimations.Add(new AnimationReferenceBlockBlock());
          ScreenAnimations[x].Read(reader);
        }
        for (x = 0; (x < _screenAnimations.Count); x = (x + 1)) {
          ScreenAnimations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shapeGroups.Count); x = (x + 1)) {
          ShapeGroups.Add(new ShapeGroupReferenceBlockBlock());
          ShapeGroups[x].Read(reader);
        }
        for (x = 0; (x < _shapeGroups.Count); x = (x + 1)) {
          ShapeGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new PersistentBackgroundAnimationBlockBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _listItemSkins.Count); x = (x + 1)) {
          ListItemSkins.Add(new ListSkinReferenceBlockBlock());
          ListItemSkins[x].Read(reader);
        }
        for (x = 0; (x < _listItemSkins.Count); x = (x + 1)) {
          ListItemSkins[x].ReadChildData(reader);
        }
        _buttonKeyTypeStrings.ReadString(reader);
        _gameTypeStrings.ReadString(reader);
        _unnamed13.ReadString(reader);
        for (x = 0; (x < _skillMappings.Count); x = (x + 1)) {
          SkillMappings.Add(new SkillToRankMappingBlockBlock());
          SkillMappings[x].Read(reader);
        }
        for (x = 0; (x < _skillMappings.Count); x = (x + 1)) {
          SkillMappings[x].ReadChildData(reader);
        }
        _mainMenuMusic.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _overlayedScreenAlphaMod.Write(bw);
        _incTextUpdatePeriod.Write(bw);
        _incTextBlockCharacter.Write(bw);
        _calloutTextScale.Write(bw);
        _progressBarColor.Write(bw);
        _nearClipPlaneDistance.Write(bw);
        _projectionPlaneDistance.Write(bw);
        _farClipPlaneDistance.Write(bw);
        _overlayedInterfaceColor.Write(bw);
        _unnamed8.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
        _soundTag.Write(bw);
        _soundTag2.Write(bw);
        _soundTag3.Write(bw);
        _soundTag4.Write(bw);
        _soundTag5.Write(bw);
        _soundTag6.Write(bw);
        _soundTag7.Write(bw);
        _soundTag8.Write(bw);
        _soundTag9.Write(bw);
        _soundTag10.Write(bw);
        _soundTag11.Write(bw);
        _unnamed9.Write(bw);
        _soundTag12.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _globalBitmapsTag.Write(bw);
        _unicodeStringListTag.Write(bw);
_screenAnimations.Count = ScreenAnimations.Count;
        _screenAnimations.Write(bw);
_shapeGroups.Count = ShapeGroups.Count;
        _shapeGroups.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
_listItemSkins.Count = ListItemSkins.Count;
        _listItemSkins.Write(bw);
        _buttonKeyTypeStrings.Write(bw);
        _gameTypeStrings.Write(bw);
        _unnamed13.Write(bw);
_skillMappings.Count = SkillMappings.Count;
        _skillMappings.Write(bw);
        _fullScreenHeaderTextFont.Write(bw);
        _largeDialogHeaderTextFont.Write(bw);
        _halfDialogHeaderTextFont.Write(bw);
        _qtrDialogHeaderTextFont.Write(bw);
        _defaultTextColor.Write(bw);
        _fullScreenHeaderTextBounds.Write(bw);
        _fullScreenButtonKeyTextBounds.Write(bw);
        _largeDialogHeaderTextBounds.Write(bw);
        _largeDialogButtonKeyTextBounds.Write(bw);
        _halfDialogHeaderTextBounds.Write(bw);
        _halfDialogButtonKeyTextBounds.Write(bw);
        _qtrDialogHeaderTextBounds.Write(bw);
        _qtrDialogButtonKeyTextBounds.Write(bw);
        _mainMenuMusic.Write(bw);
        _musicFadeTime.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
        _soundTag.WriteString(writer);
        _soundTag2.WriteString(writer);
        _soundTag3.WriteString(writer);
        _soundTag4.WriteString(writer);
        _soundTag5.WriteString(writer);
        _soundTag6.WriteString(writer);
        _soundTag7.WriteString(writer);
        _soundTag8.WriteString(writer);
        _soundTag9.WriteString(writer);
        _soundTag10.WriteString(writer);
        _soundTag11.WriteString(writer);
        _unnamed9.WriteString(writer);
        _soundTag12.WriteString(writer);
        _unnamed10.WriteString(writer);
        _unnamed11.WriteString(writer);
        _unnamed12.WriteString(writer);
        _globalBitmapsTag.WriteString(writer);
        _unicodeStringListTag.WriteString(writer);
        for (x = 0; (x < _screenAnimations.Count); x = (x + 1)) {
          ScreenAnimations[x].Write(writer);
        }
        for (x = 0; (x < _screenAnimations.Count); x = (x + 1)) {
          ScreenAnimations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shapeGroups.Count); x = (x + 1)) {
          ShapeGroups[x].Write(writer);
        }
        for (x = 0; (x < _shapeGroups.Count); x = (x + 1)) {
          ShapeGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _listItemSkins.Count); x = (x + 1)) {
          ListItemSkins[x].Write(writer);
        }
        for (x = 0; (x < _listItemSkins.Count); x = (x + 1)) {
          ListItemSkins[x].WriteChildData(writer);
        }
        _buttonKeyTypeStrings.WriteString(writer);
        _gameTypeStrings.WriteString(writer);
        _unnamed13.WriteString(writer);
        for (x = 0; (x < _skillMappings.Count); x = (x + 1)) {
          SkillMappings[x].Write(writer);
        }
        for (x = 0; (x < _skillMappings.Count); x = (x + 1)) {
          SkillMappings[x].WriteChildData(writer);
        }
        _mainMenuMusic.WriteString(writer);
      }
    }
    public class UiErrorCategoryBlockBlock : IBlock {
      private StringId _categoryName = new StringId();
      private Flags _flags;
      private Enum _defaultButton;
      private Pad _unnamed0;
      private TagReference _stringTag = new TagReference();
      private StringId _defaultTitle = new StringId();
      private StringId _defaultMessage = new StringId();
      private StringId _defaultOk = new StringId();
      private StringId _defaultCancel = new StringId();
      private Block _errorBlock = new Block();
      public BlockCollection<UiErrorBlockBlock> _errorBlockList = new BlockCollection<UiErrorBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UiErrorCategoryBlockBlock() {
if (this._categoryName is System.ComponentModel.INotifyPropertyChanged)
  (this._categoryName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._defaultButton = new Enum(1);
        this._unnamed0 = new Pad(1);
      }
      public BlockCollection<UiErrorBlockBlock> ErrorBlock {
        get {
          return this._errorBlockList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_stringTag.Value);
for (int x=0; x<ErrorBlock.BlockCount; x++)
{
  IBlock block = ErrorBlock.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _categoryName.ToString();
        }
      }
      public StringId CategoryName {
        get {
          return this._categoryName;
        }
        set {
          this._categoryName = value;
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
      public Enum DefaultButton {
        get {
          return this._defaultButton;
        }
        set {
          this._defaultButton = value;
        }
      }
      public TagReference StringTag {
        get {
          return this._stringTag;
        }
        set {
          this._stringTag = value;
        }
      }
      public StringId DefaultTitle {
        get {
          return this._defaultTitle;
        }
        set {
          this._defaultTitle = value;
        }
      }
      public StringId DefaultMessage {
        get {
          return this._defaultMessage;
        }
        set {
          this._defaultMessage = value;
        }
      }
      public StringId DefaultOk {
        get {
          return this._defaultOk;
        }
        set {
          this._defaultOk = value;
        }
      }
      public StringId DefaultCancel {
        get {
          return this._defaultCancel;
        }
        set {
          this._defaultCancel = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _categoryName.Read(reader);
        _flags.Read(reader);
        _defaultButton.Read(reader);
        _unnamed0.Read(reader);
        _stringTag.Read(reader);
        _defaultTitle.Read(reader);
        _defaultMessage.Read(reader);
        _defaultOk.Read(reader);
        _defaultCancel.Read(reader);
        _errorBlock.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _categoryName.ReadString(reader);
        _stringTag.ReadString(reader);
        _defaultTitle.ReadString(reader);
        _defaultMessage.ReadString(reader);
        _defaultOk.ReadString(reader);
        _defaultCancel.ReadString(reader);
        for (x = 0; (x < _errorBlock.Count); x = (x + 1)) {
          ErrorBlock.Add(new UiErrorBlockBlock());
          ErrorBlock[x].Read(reader);
        }
        for (x = 0; (x < _errorBlock.Count); x = (x + 1)) {
          ErrorBlock[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _categoryName.Write(bw);
        _flags.Write(bw);
        _defaultButton.Write(bw);
        _unnamed0.Write(bw);
        _stringTag.Write(bw);
        _defaultTitle.Write(bw);
        _defaultMessage.Write(bw);
        _defaultOk.Write(bw);
        _defaultCancel.Write(bw);
_errorBlock.Count = ErrorBlock.Count;
        _errorBlock.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _categoryName.WriteString(writer);
        _stringTag.WriteString(writer);
        _defaultTitle.WriteString(writer);
        _defaultMessage.WriteString(writer);
        _defaultOk.WriteString(writer);
        _defaultCancel.WriteString(writer);
        for (x = 0; (x < _errorBlock.Count); x = (x + 1)) {
          ErrorBlock[x].Write(writer);
        }
        for (x = 0; (x < _errorBlock.Count); x = (x + 1)) {
          ErrorBlock[x].WriteChildData(writer);
        }
      }
    }
    public class UiErrorBlockBlock : IBlock {
      private Enum _error;
      private Flags _flags;
      private Enum _defaultButton;
      private Pad _unnamed0;
      private StringId _title = new StringId();
      private StringId _message = new StringId();
      private StringId _ok = new StringId();
      private StringId _cancel = new StringId();
public event System.EventHandler BlockNameChanged;
      public UiErrorBlockBlock() {
        this._error = new Enum(4);
        this._flags = new Flags(2);
        this._defaultButton = new Enum(1);
        this._unnamed0 = new Pad(1);
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
      public Enum Error {
        get {
          return this._error;
        }
        set {
          this._error = value;
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
      public Enum DefaultButton {
        get {
          return this._defaultButton;
        }
        set {
          this._defaultButton = value;
        }
      }
      public StringId Title {
        get {
          return this._title;
        }
        set {
          this._title = value;
        }
      }
      public StringId Message {
        get {
          return this._message;
        }
        set {
          this._message = value;
        }
      }
      public StringId Ok {
        get {
          return this._ok;
        }
        set {
          this._ok = value;
        }
      }
      public StringId Cancel {
        get {
          return this._cancel;
        }
        set {
          this._cancel = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _error.Read(reader);
        _flags.Read(reader);
        _defaultButton.Read(reader);
        _unnamed0.Read(reader);
        _title.Read(reader);
        _message.Read(reader);
        _ok.Read(reader);
        _cancel.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _title.ReadString(reader);
        _message.ReadString(reader);
        _ok.ReadString(reader);
        _cancel.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _error.Write(bw);
        _flags.Write(bw);
        _defaultButton.Write(bw);
        _unnamed0.Write(bw);
        _title.Write(bw);
        _message.Write(bw);
        _ok.Write(bw);
        _cancel.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _title.WriteString(writer);
        _message.WriteString(writer);
        _ok.WriteString(writer);
        _cancel.WriteString(writer);
      }
    }
    public class AnimationReferenceBlockBlock : IBlock {
      private Flags _flags;
      private LongInteger _animationPeriod = new LongInteger();
      private Block _keyframes = new Block();
      private LongInteger _animationPeriod2 = new LongInteger();
      private Block _keyframes2 = new Block();
      private LongInteger _animationPeriod3 = new LongInteger();
      private Enum _ambientAnimationLoopingStyle;
      private Pad _unnamed0;
      private Block _keyframes3 = new Block();
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> _keyframesList = new BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock>();
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> _keyframes2List = new BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock>();
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> _keyframes3List = new BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._ambientAnimationLoopingStyle = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> Keyframes {
        get {
          return this._keyframesList;
        }
      }
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> Keyframes2 {
        get {
          return this._keyframes2List;
        }
      }
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> Keyframes3 {
        get {
          return this._keyframes3List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Keyframes.BlockCount; x++)
{
  IBlock block = Keyframes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Keyframes2.BlockCount; x++)
{
  IBlock block = Keyframes2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Keyframes3.BlockCount; x++)
{
  IBlock block = Keyframes3.GetBlock(x);
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
      public LongInteger AnimationPeriod {
        get {
          return this._animationPeriod;
        }
        set {
          this._animationPeriod = value;
        }
      }
      public LongInteger AnimationPeriod2 {
        get {
          return this._animationPeriod2;
        }
        set {
          this._animationPeriod2 = value;
        }
      }
      public LongInteger AnimationPeriod3 {
        get {
          return this._animationPeriod3;
        }
        set {
          this._animationPeriod3 = value;
        }
      }
      public Enum AmbientAnimationLoopingStyle {
        get {
          return this._ambientAnimationLoopingStyle;
        }
        set {
          this._ambientAnimationLoopingStyle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationPeriod.Read(reader);
        _keyframes.Read(reader);
        _animationPeriod2.Read(reader);
        _keyframes2.Read(reader);
        _animationPeriod3.Read(reader);
        _ambientAnimationLoopingStyle.Read(reader);
        _unnamed0.Read(reader);
        _keyframes3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes.Add(new ScreenAnimationKeyframeReferenceBlockBlock());
          Keyframes[x].Read(reader);
        }
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _keyframes2.Count); x = (x + 1)) {
          Keyframes2.Add(new ScreenAnimationKeyframeReferenceBlockBlock());
          Keyframes2[x].Read(reader);
        }
        for (x = 0; (x < _keyframes2.Count); x = (x + 1)) {
          Keyframes2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _keyframes3.Count); x = (x + 1)) {
          Keyframes3.Add(new ScreenAnimationKeyframeReferenceBlockBlock());
          Keyframes3[x].Read(reader);
        }
        for (x = 0; (x < _keyframes3.Count); x = (x + 1)) {
          Keyframes3[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationPeriod.Write(bw);
_keyframes.Count = Keyframes.Count;
        _keyframes.Write(bw);
        _animationPeriod2.Write(bw);
_keyframes2.Count = Keyframes2.Count;
        _keyframes2.Write(bw);
        _animationPeriod3.Write(bw);
        _ambientAnimationLoopingStyle.Write(bw);
        _unnamed0.Write(bw);
_keyframes3.Count = Keyframes3.Count;
        _keyframes3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes[x].Write(writer);
        }
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _keyframes2.Count); x = (x + 1)) {
          Keyframes2[x].Write(writer);
        }
        for (x = 0; (x < _keyframes2.Count); x = (x + 1)) {
          Keyframes2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _keyframes3.Count); x = (x + 1)) {
          Keyframes3[x].Write(writer);
        }
        for (x = 0; (x < _keyframes3.Count); x = (x + 1)) {
          Keyframes3[x].WriteChildData(writer);
        }
      }
    }
    public class ScreenAnimationKeyframeReferenceBlockBlock : IBlock {
      private Pad _unnamed0;
      private Real _alpha = new Real();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScreenAnimationKeyframeReferenceBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public Real Alpha {
        get {
          return this._alpha;
        }
        set {
          this._alpha = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _alpha.Read(reader);
        _position.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _alpha.Write(bw);
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ShapeGroupReferenceBlockBlock : IBlock {
      private Block _shapes = new Block();
      private Block _modelSceneBlocks = new Block();
      private Block _bitmapBlocks = new Block();
      public BlockCollection<ShapeBlockReferenceBlockBlock> _shapesList = new BlockCollection<ShapeBlockReferenceBlockBlock>();
      public BlockCollection<UiModelSceneReferenceBlockBlock> _modelSceneBlocksList = new BlockCollection<UiModelSceneReferenceBlockBlock>();
      public BlockCollection<BitmapBlockReferenceBlockBlock> _bitmapBlocksList = new BlockCollection<BitmapBlockReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShapeGroupReferenceBlockBlock() {
      }
      public BlockCollection<ShapeBlockReferenceBlockBlock> Shapes {
        get {
          return this._shapesList;
        }
      }
      public BlockCollection<UiModelSceneReferenceBlockBlock> ModelSceneBlocks {
        get {
          return this._modelSceneBlocksList;
        }
      }
      public BlockCollection<BitmapBlockReferenceBlockBlock> BitmapBlocks {
        get {
          return this._bitmapBlocksList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Shapes.BlockCount; x++)
{
  IBlock block = Shapes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ModelSceneBlocks.BlockCount; x++)
{
  IBlock block = ModelSceneBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BitmapBlocks.BlockCount; x++)
{
  IBlock block = BitmapBlocks.GetBlock(x);
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
        _shapes.Read(reader);
        _modelSceneBlocks.Read(reader);
        _bitmapBlocks.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _shapes.Count); x = (x + 1)) {
          Shapes.Add(new ShapeBlockReferenceBlockBlock());
          Shapes[x].Read(reader);
        }
        for (x = 0; (x < _shapes.Count); x = (x + 1)) {
          Shapes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks.Add(new UiModelSceneReferenceBlockBlock());
          ModelSceneBlocks[x].Read(reader);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks.Add(new BitmapBlockReferenceBlockBlock());
          BitmapBlocks[x].Read(reader);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_shapes.Count = Shapes.Count;
        _shapes.Write(bw);
_modelSceneBlocks.Count = ModelSceneBlocks.Count;
        _modelSceneBlocks.Write(bw);
_bitmapBlocks.Count = BitmapBlocks.Count;
        _bitmapBlocks.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _shapes.Count); x = (x + 1)) {
          Shapes[x].Write(writer);
        }
        for (x = 0; (x < _shapes.Count); x = (x + 1)) {
          Shapes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].Write(writer);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].Write(writer);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].WriteChildData(writer);
        }
      }
    }
    public class ShapeBlockReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private RealARGBColor _color = new RealARGBColor();
      private Block _points = new Block();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private Pad _unnamed0;
      public BlockCollection<PointBlockReferenceBlockBlock> _pointsList = new BlockCollection<PointBlockReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ShapeBlockReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._unnamed0 = new Pad(14);
      }
      public BlockCollection<PointBlockReferenceBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
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
      public Enum AnimationIndex {
        get {
          return this._animationIndex;
        }
        set {
          this._animationIndex = value;
        }
      }
      public ShortInteger IntroAnimationDelayMilliseconds {
        get {
          return this._introAnimationDelayMilliseconds;
        }
        set {
          this._introAnimationDelayMilliseconds = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public ShortInteger RenderDepthBias {
        get {
          return this._renderDepthBias;
        }
        set {
          this._renderDepthBias = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _color.Read(reader);
        _points.Read(reader);
        _renderDepthBias.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new PointBlockReferenceBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _color.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
        _renderDepthBias.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class PointBlockReferenceBlockBlock : IBlock {
      private Point2D _coordinates = new Point2D();
public event System.EventHandler BlockNameChanged;
      public PointBlockReferenceBlockBlock() {
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
      public Point2D Coordinates {
        get {
          return this._coordinates;
        }
        set {
          this._coordinates = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _coordinates.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _coordinates.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UiModelSceneReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private Pad _unnamed0;
      private Block _objects = new Block();
      private Block _lights = new Block();
      private RealVector3D _animationScaleFactor = new RealVector3D();
      private RealPoint3D _cameraPosition = new RealPoint3D();
      private Real _fovDegress = new Real();
      private Rectangle2D _uiViewport = new Rectangle2D();
      private StringId _uNUSEDIntroAnim = new StringId();
      private StringId _uNUSEDOutroAnim = new StringId();
      private StringId _uNUSEDAmbientAnim = new StringId();
      public BlockCollection<UiObjectReferenceBlockBlock> _objectsList = new BlockCollection<UiObjectReferenceBlockBlock>();
      public BlockCollection<UiLightReferenceBlockBlock> _lightsList = new BlockCollection<UiLightReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UiModelSceneReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<UiObjectReferenceBlockBlock> Objects {
        get {
          return this._objectsList;
        }
      }
      public BlockCollection<UiLightReferenceBlockBlock> Lights {
        get {
          return this._lightsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Objects.BlockCount; x++)
{
  IBlock block = Objects.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lights.BlockCount; x++)
{
  IBlock block = Lights.GetBlock(x);
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
      public Enum AnimationIndex {
        get {
          return this._animationIndex;
        }
        set {
          this._animationIndex = value;
        }
      }
      public ShortInteger IntroAnimationDelayMilliseconds {
        get {
          return this._introAnimationDelayMilliseconds;
        }
        set {
          this._introAnimationDelayMilliseconds = value;
        }
      }
      public ShortInteger RenderDepthBias {
        get {
          return this._renderDepthBias;
        }
        set {
          this._renderDepthBias = value;
        }
      }
      public RealVector3D AnimationScaleFactor {
        get {
          return this._animationScaleFactor;
        }
        set {
          this._animationScaleFactor = value;
        }
      }
      public RealPoint3D CameraPosition {
        get {
          return this._cameraPosition;
        }
        set {
          this._cameraPosition = value;
        }
      }
      public Real FovDegress {
        get {
          return this._fovDegress;
        }
        set {
          this._fovDegress = value;
        }
      }
      public Rectangle2D UiViewport {
        get {
          return this._uiViewport;
        }
        set {
          this._uiViewport = value;
        }
      }
      public StringId UNUSEDIntroAnim {
        get {
          return this._uNUSEDIntroAnim;
        }
        set {
          this._uNUSEDIntroAnim = value;
        }
      }
      public StringId UNUSEDOutroAnim {
        get {
          return this._uNUSEDOutroAnim;
        }
        set {
          this._uNUSEDOutroAnim = value;
        }
      }
      public StringId UNUSEDAmbientAnim {
        get {
          return this._uNUSEDAmbientAnim;
        }
        set {
          this._uNUSEDAmbientAnim = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _renderDepthBias.Read(reader);
        _unnamed0.Read(reader);
        _objects.Read(reader);
        _lights.Read(reader);
        _animationScaleFactor.Read(reader);
        _cameraPosition.Read(reader);
        _fovDegress.Read(reader);
        _uiViewport.Read(reader);
        _uNUSEDIntroAnim.Read(reader);
        _uNUSEDOutroAnim.Read(reader);
        _uNUSEDAmbientAnim.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects.Add(new UiObjectReferenceBlockBlock());
          Objects[x].Read(reader);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights.Add(new UiLightReferenceBlockBlock());
          Lights[x].Read(reader);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].ReadChildData(reader);
        }
        _uNUSEDIntroAnim.ReadString(reader);
        _uNUSEDOutroAnim.ReadString(reader);
        _uNUSEDAmbientAnim.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _renderDepthBias.Write(bw);
        _unnamed0.Write(bw);
_objects.Count = Objects.Count;
        _objects.Write(bw);
_lights.Count = Lights.Count;
        _lights.Write(bw);
        _animationScaleFactor.Write(bw);
        _cameraPosition.Write(bw);
        _fovDegress.Write(bw);
        _uiViewport.Write(bw);
        _uNUSEDIntroAnim.Write(bw);
        _uNUSEDOutroAnim.Write(bw);
        _uNUSEDAmbientAnim.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].Write(writer);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].Write(writer);
        }
        for (x = 0; (x < _lights.Count); x = (x + 1)) {
          Lights[x].WriteChildData(writer);
        }
        _uNUSEDIntroAnim.WriteString(writer);
        _uNUSEDOutroAnim.WriteString(writer);
        _uNUSEDAmbientAnim.WriteString(writer);
      }
    }
    public class UiObjectReferenceBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public UiObjectReferenceBlockBlock() {
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UiLightReferenceBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public UiLightReferenceBlockBlock() {
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class BitmapBlockReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private Enum _bitmapBlendMethod;
      private ShortInteger _initialSpriteFrame = new ShortInteger();
      private Point2D _top_Minusleft = new Point2D();
      private Real _horizTextureWrapssecond = new Real();
      private Real _vertTextureWrapssecond = new Real();
      private TagReference _bitmapTag = new TagReference();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private Pad _unnamed0;
      private Real _spriteAnimationSpeedFps = new Real();
      private Point2D _progressBottom_Minusleft = new Point2D();
      private StringId _stringIdentifier = new StringId();
      private RealVector2D _progressScale = new RealVector2D();
public event System.EventHandler BlockNameChanged;
      public BitmapBlockReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._bitmapBlendMethod = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmapTag.Value);
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
      public Enum AnimationIndex {
        get {
          return this._animationIndex;
        }
        set {
          this._animationIndex = value;
        }
      }
      public ShortInteger IntroAnimationDelayMilliseconds {
        get {
          return this._introAnimationDelayMilliseconds;
        }
        set {
          this._introAnimationDelayMilliseconds = value;
        }
      }
      public Enum BitmapBlendMethod {
        get {
          return this._bitmapBlendMethod;
        }
        set {
          this._bitmapBlendMethod = value;
        }
      }
      public ShortInteger InitialSpriteFrame {
        get {
          return this._initialSpriteFrame;
        }
        set {
          this._initialSpriteFrame = value;
        }
      }
      public Point2D Top_Minusleft {
        get {
          return this._top_Minusleft;
        }
        set {
          this._top_Minusleft = value;
        }
      }
      public Real HorizTextureWrapssecond {
        get {
          return this._horizTextureWrapssecond;
        }
        set {
          this._horizTextureWrapssecond = value;
        }
      }
      public Real VertTextureWrapssecond {
        get {
          return this._vertTextureWrapssecond;
        }
        set {
          this._vertTextureWrapssecond = value;
        }
      }
      public TagReference BitmapTag {
        get {
          return this._bitmapTag;
        }
        set {
          this._bitmapTag = value;
        }
      }
      public ShortInteger RenderDepthBias {
        get {
          return this._renderDepthBias;
        }
        set {
          this._renderDepthBias = value;
        }
      }
      public Real SpriteAnimationSpeedFps {
        get {
          return this._spriteAnimationSpeedFps;
        }
        set {
          this._spriteAnimationSpeedFps = value;
        }
      }
      public Point2D ProgressBottom_Minusleft {
        get {
          return this._progressBottom_Minusleft;
        }
        set {
          this._progressBottom_Minusleft = value;
        }
      }
      public StringId StringIdentifier {
        get {
          return this._stringIdentifier;
        }
        set {
          this._stringIdentifier = value;
        }
      }
      public RealVector2D ProgressScale {
        get {
          return this._progressScale;
        }
        set {
          this._progressScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _bitmapBlendMethod.Read(reader);
        _initialSpriteFrame.Read(reader);
        _top_Minusleft.Read(reader);
        _horizTextureWrapssecond.Read(reader);
        _vertTextureWrapssecond.Read(reader);
        _bitmapTag.Read(reader);
        _renderDepthBias.Read(reader);
        _unnamed0.Read(reader);
        _spriteAnimationSpeedFps.Read(reader);
        _progressBottom_Minusleft.Read(reader);
        _stringIdentifier.Read(reader);
        _progressScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmapTag.ReadString(reader);
        _stringIdentifier.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _bitmapBlendMethod.Write(bw);
        _initialSpriteFrame.Write(bw);
        _top_Minusleft.Write(bw);
        _horizTextureWrapssecond.Write(bw);
        _vertTextureWrapssecond.Write(bw);
        _bitmapTag.Write(bw);
        _renderDepthBias.Write(bw);
        _unnamed0.Write(bw);
        _spriteAnimationSpeedFps.Write(bw);
        _progressBottom_Minusleft.Write(bw);
        _stringIdentifier.Write(bw);
        _progressScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmapTag.WriteString(writer);
        _stringIdentifier.WriteString(writer);
      }
    }
    public class PersistentBackgroundAnimationBlockBlock : IBlock {
      private Pad _unnamed0;
      private LongInteger _animationPeriod = new LongInteger();
      private Block _interpolatedKeyframes = new Block();
      public BlockCollection<BackgroundAnimationKeyframeReferenceBlockBlock> _interpolatedKeyframesList = new BlockCollection<BackgroundAnimationKeyframeReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PersistentBackgroundAnimationBlockBlock() {
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<BackgroundAnimationKeyframeReferenceBlockBlock> InterpolatedKeyframes {
        get {
          return this._interpolatedKeyframesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<InterpolatedKeyframes.BlockCount; x++)
{
  IBlock block = InterpolatedKeyframes.GetBlock(x);
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
      public LongInteger AnimationPeriod {
        get {
          return this._animationPeriod;
        }
        set {
          this._animationPeriod = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _animationPeriod.Read(reader);
        _interpolatedKeyframes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _interpolatedKeyframes.Count); x = (x + 1)) {
          InterpolatedKeyframes.Add(new BackgroundAnimationKeyframeReferenceBlockBlock());
          InterpolatedKeyframes[x].Read(reader);
        }
        for (x = 0; (x < _interpolatedKeyframes.Count); x = (x + 1)) {
          InterpolatedKeyframes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _animationPeriod.Write(bw);
_interpolatedKeyframes.Count = InterpolatedKeyframes.Count;
        _interpolatedKeyframes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _interpolatedKeyframes.Count); x = (x + 1)) {
          InterpolatedKeyframes[x].Write(writer);
        }
        for (x = 0; (x < _interpolatedKeyframes.Count); x = (x + 1)) {
          InterpolatedKeyframes[x].WriteChildData(writer);
        }
      }
    }
    public class BackgroundAnimationKeyframeReferenceBlockBlock : IBlock {
      private LongInteger _startTransitionIndex = new LongInteger();
      private Real _alpha = new Real();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public BackgroundAnimationKeyframeReferenceBlockBlock() {
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
      public LongInteger StartTransitionIndex {
        get {
          return this._startTransitionIndex;
        }
        set {
          this._startTransitionIndex = value;
        }
      }
      public Real Alpha {
        get {
          return this._alpha;
        }
        set {
          this._alpha = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _startTransitionIndex.Read(reader);
        _alpha.Read(reader);
        _position.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _startTransitionIndex.Write(bw);
        _alpha.Write(bw);
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ListSkinReferenceBlockBlock : IBlock {
      private TagReference _listItemSkins = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ListSkinReferenceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_listItemSkins.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference ListItemSkins {
        get {
          return this._listItemSkins;
        }
        set {
          this._listItemSkins = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _listItemSkins.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _listItemSkins.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _listItemSkins.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _listItemSkins.WriteString(writer);
      }
    }
    public class SkillToRankMappingBlockBlock : IBlock {
      private ShortIntegerBounds _skillBounds = new ShortIntegerBounds();
public event System.EventHandler BlockNameChanged;
      public SkillToRankMappingBlockBlock() {
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
      public ShortIntegerBounds SkillBounds {
        get {
          return this._skillBounds;
        }
        set {
          this._skillBounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _skillBounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _skillBounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
