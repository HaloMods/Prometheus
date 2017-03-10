// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'hud_globals'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class hud_globals : Interfaces.Pool.Tag {
    private GlobalNewHudGlobalsConstantsStructBlockBlock hudGlobalsValues = new GlobalNewHudGlobalsConstantsStructBlockBlock();
    public virtual GlobalNewHudGlobalsConstantsStructBlockBlock HudGlobalsValues {
      get {
        return hudGlobalsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(HudGlobalsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "hud_globals";
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
hudGlobalsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
hudGlobalsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
hudGlobalsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
hudGlobalsValues.WriteChildData(writer);
    }
    #endregion
    public class GlobalNewHudGlobalsConstantsStructBlockBlock : IBlock {
      private Enum _anchor;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _obsolete1 = new TagReference();
      private TagReference _obsolete2 = new TagReference();
      private Real _upTime = new Real();
      private Real _fadeTime = new Real();
      private RealARGBColor _iconColor = new RealARGBColor();
      private RealARGBColor _textColor = new RealARGBColor();
      private Real _textSpacing = new Real();
      private TagReference _itemMessageText = new TagReference();
      private TagReference _iconBitmap = new TagReference();
      private TagReference _alternateIconText = new TagReference();
      private Block _buttonIcons = new Block();
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed4;
      private TagReference _hudMessages = new TagReference();
      private ARGBColor _defaultColor2 = new ARGBColor();
      private ARGBColor _flashingColor2 = new ARGBColor();
      private Real _flashPeriod2 = new Real();
      private Real _flashDelay2 = new Real();
      private ShortInteger _numberOfFlashes2 = new ShortInteger();
      private Flags _flashFlags2;
      private Real _flashLength2 = new Real();
      private ARGBColor _disabledColor2 = new ARGBColor();
      private ShortInteger _uptimeTicks = new ShortInteger();
      private ShortInteger _fadeTicks = new ShortInteger();
      private Real _topOffset = new Real();
      private Real _bottomOffset = new Real();
      private Real _leftOffset = new Real();
      private Real _rightOffset = new Real();
      private Pad _unnamed5;
      private TagReference _arrowBitmap = new TagReference();
      private Block _waypointArrows = new Block();
      private Pad _unnamed6;
      private Real _hudScaleInMultiplayer = new Real();
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Real _motionSensorRange = new Real();
      private Real _motionSensorVelocitySensitivity = new Real();
      private Real _motionSensorScaleDONTTOUCHEVER = new Real();
      private Rectangle2D _defaultChapterTitleBounds = new Rectangle2D();
      private Pad _unnamed9;
      private ShortInteger _topOffset2 = new ShortInteger();
      private ShortInteger _bottomOffset2 = new ShortInteger();
      private ShortInteger _leftOffset2 = new ShortInteger();
      private ShortInteger _rightOffset2 = new ShortInteger();
      private Pad _unnamed10;
      private TagReference _indicatorBitmap = new TagReference();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private ShortInteger _multiplayerSequenceIndex = new ShortInteger();
      private ARGBColor _color = new ARGBColor();
      private Pad _unnamed11;
      private ARGBColor _defaultColor3 = new ARGBColor();
      private ARGBColor _flashingColor3 = new ARGBColor();
      private Real _flashPeriod3 = new Real();
      private Real _flashDelay3 = new Real();
      private ShortInteger _numberOfFlashes3 = new ShortInteger();
      private Flags _flashFlags3;
      private Real _flashLength3 = new Real();
      private ARGBColor _disabledColor3 = new ARGBColor();
      private Pad _unnamed12;
      private ARGBColor _defaultColor4 = new ARGBColor();
      private ARGBColor _flashingColor4 = new ARGBColor();
      private Real _flashPeriod4 = new Real();
      private Real _flashDelay4 = new Real();
      private ShortInteger _numberOfFlashes4 = new ShortInteger();
      private Flags _flashFlags4;
      private Real _flashLength4 = new Real();
      private ARGBColor _disabledColor4 = new ARGBColor();
      private Pad _unnamed13;
      private Pad _unnamed14;
      private TagReference _carnageReportBitmap = new TagReference();
      private ShortInteger _loadingBeginText = new ShortInteger();
      private ShortInteger _loadingEndText = new ShortInteger();
      private ShortInteger _checkpointBeginText = new ShortInteger();
      private ShortInteger _checkpointEndText = new ShortInteger();
      private TagReference _checkpointSound = new TagReference();
      private Pad _unnamed15;
      private TagReference _hudText = new TagReference();
      private Block _dashlights = new Block();
      private Block _waypointArrows2 = new Block();
      private Block _waypoints = new Block();
      private Block _hudSounds = new Block();
      private Block _playerTrainingData = new Block();
      private TagReference _primaryMessageSound = new TagReference();
      private TagReference _secondaryMessageSound = new TagReference();
      private StringId _bootGrieferString = new StringId();
      private StringId _cannotBootGrieferString = new StringId();
      private TagReference _trainingShader = new TagReference();
      private TagReference _humanTrainingTopRight = new TagReference();
      private TagReference _humanTrainingTopCenter = new TagReference();
      private TagReference _humanTrainingTopLeft = new TagReference();
      private TagReference _humanTrainingMiddle = new TagReference();
      private TagReference _eliteTrainingTopRight = new TagReference();
      private TagReference _eliteTrainingTopCenter = new TagReference();
      private TagReference _eliteTrainingTopLeft = new TagReference();
      private TagReference _eliteTrainingMiddle = new TagReference();
      public BlockCollection<HudButtonIconBlockBlock> _buttonIconsList = new BlockCollection<HudButtonIconBlockBlock>();
      public BlockCollection<HudWaypointArrowBlockBlock> _waypointArrowsList = new BlockCollection<HudWaypointArrowBlockBlock>();
      public BlockCollection<HudDashlightsBlockBlock> _dashlightsList = new BlockCollection<HudDashlightsBlockBlock>();
      public BlockCollection<HudWaypointArrowBlockBlock> _waypointArrows2List = new BlockCollection<HudWaypointArrowBlockBlock>();
      public BlockCollection<HudWaypointBlockBlock> _waypointsList = new BlockCollection<HudWaypointBlockBlock>();
      public BlockCollection<NewHudSoundBlockBlock> _hudSoundsList = new BlockCollection<NewHudSoundBlockBlock>();
      public BlockCollection<PlayerTrainingEntryDataBlockBlock> _playerTrainingDataList = new BlockCollection<PlayerTrainingEntryDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalNewHudGlobalsConstantsStructBlockBlock() {
        this._anchor = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(32);
        this._scalingFlags = new Flags(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed4 = new Pad(4);
        this._flashFlags2 = new Flags(2);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(80);
        this._unnamed7 = new Pad(256);
        this._unnamed8 = new Pad(16);
        this._unnamed9 = new Pad(44);
        this._unnamed10 = new Pad(32);
        this._unnamed11 = new Pad(16);
        this._flashFlags3 = new Flags(2);
        this._unnamed12 = new Pad(4);
        this._flashFlags4 = new Flags(2);
        this._unnamed13 = new Pad(4);
        this._unnamed14 = new Pad(40);
        this._unnamed15 = new Pad(96);
      }
      public BlockCollection<HudButtonIconBlockBlock> ButtonIcons {
        get {
          return this._buttonIconsList;
        }
      }
      public BlockCollection<HudWaypointArrowBlockBlock> WaypointArrows {
        get {
          return this._waypointArrowsList;
        }
      }
      public BlockCollection<HudDashlightsBlockBlock> Dashlights {
        get {
          return this._dashlightsList;
        }
      }
      public BlockCollection<HudWaypointArrowBlockBlock> WaypointArrows2 {
        get {
          return this._waypointArrows2List;
        }
      }
      public BlockCollection<HudWaypointBlockBlock> Waypoints {
        get {
          return this._waypointsList;
        }
      }
      public BlockCollection<NewHudSoundBlockBlock> HudSounds {
        get {
          return this._hudSoundsList;
        }
      }
      public BlockCollection<PlayerTrainingEntryDataBlockBlock> PlayerTrainingData {
        get {
          return this._playerTrainingDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_obsolete1.Value);
references.Add(_obsolete2.Value);
references.Add(_itemMessageText.Value);
references.Add(_iconBitmap.Value);
references.Add(_alternateIconText.Value);
references.Add(_hudMessages.Value);
references.Add(_arrowBitmap.Value);
references.Add(_indicatorBitmap.Value);
references.Add(_carnageReportBitmap.Value);
references.Add(_checkpointSound.Value);
references.Add(_hudText.Value);
references.Add(_primaryMessageSound.Value);
references.Add(_secondaryMessageSound.Value);
references.Add(_trainingShader.Value);
references.Add(_humanTrainingTopRight.Value);
references.Add(_humanTrainingTopCenter.Value);
references.Add(_humanTrainingTopLeft.Value);
references.Add(_humanTrainingMiddle.Value);
references.Add(_eliteTrainingTopRight.Value);
references.Add(_eliteTrainingTopCenter.Value);
references.Add(_eliteTrainingTopLeft.Value);
references.Add(_eliteTrainingMiddle.Value);
for (int x=0; x<ButtonIcons.BlockCount; x++)
{
  IBlock block = ButtonIcons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WaypointArrows.BlockCount; x++)
{
  IBlock block = WaypointArrows.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Dashlights.BlockCount; x++)
{
  IBlock block = Dashlights.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WaypointArrows2.BlockCount; x++)
{
  IBlock block = WaypointArrows2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Waypoints.BlockCount; x++)
{
  IBlock block = Waypoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HudSounds.BlockCount; x++)
{
  IBlock block = HudSounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerTrainingData.BlockCount; x++)
{
  IBlock block = PlayerTrainingData.GetBlock(x);
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
      public Enum Anchor {
        get {
          return this._anchor;
        }
        set {
          this._anchor = value;
        }
      }
      public Point2D AnchorOffset {
        get {
          return this._anchorOffset;
        }
        set {
          this._anchorOffset = value;
        }
      }
      public Real WidthScale {
        get {
          return this._widthScale;
        }
        set {
          this._widthScale = value;
        }
      }
      public Real HeightScale {
        get {
          return this._heightScale;
        }
        set {
          this._heightScale = value;
        }
      }
      public Flags ScalingFlags {
        get {
          return this._scalingFlags;
        }
        set {
          this._scalingFlags = value;
        }
      }
      public TagReference Obsolete1 {
        get {
          return this._obsolete1;
        }
        set {
          this._obsolete1 = value;
        }
      }
      public TagReference Obsolete2 {
        get {
          return this._obsolete2;
        }
        set {
          this._obsolete2 = value;
        }
      }
      public Real UpTime {
        get {
          return this._upTime;
        }
        set {
          this._upTime = value;
        }
      }
      public Real FadeTime {
        get {
          return this._fadeTime;
        }
        set {
          this._fadeTime = value;
        }
      }
      public RealARGBColor IconColor {
        get {
          return this._iconColor;
        }
        set {
          this._iconColor = value;
        }
      }
      public RealARGBColor TextColor {
        get {
          return this._textColor;
        }
        set {
          this._textColor = value;
        }
      }
      public Real TextSpacing {
        get {
          return this._textSpacing;
        }
        set {
          this._textSpacing = value;
        }
      }
      public TagReference ItemMessageText {
        get {
          return this._itemMessageText;
        }
        set {
          this._itemMessageText = value;
        }
      }
      public TagReference IconBitmap {
        get {
          return this._iconBitmap;
        }
        set {
          this._iconBitmap = value;
        }
      }
      public TagReference AlternateIconText {
        get {
          return this._alternateIconText;
        }
        set {
          this._alternateIconText = value;
        }
      }
      public ARGBColor DefaultColor {
        get {
          return this._defaultColor;
        }
        set {
          this._defaultColor = value;
        }
      }
      public ARGBColor FlashingColor {
        get {
          return this._flashingColor;
        }
        set {
          this._flashingColor = value;
        }
      }
      public Real FlashPeriod {
        get {
          return this._flashPeriod;
        }
        set {
          this._flashPeriod = value;
        }
      }
      public Real FlashDelay {
        get {
          return this._flashDelay;
        }
        set {
          this._flashDelay = value;
        }
      }
      public ShortInteger NumberOfFlashes {
        get {
          return this._numberOfFlashes;
        }
        set {
          this._numberOfFlashes = value;
        }
      }
      public Flags FlashFlags {
        get {
          return this._flashFlags;
        }
        set {
          this._flashFlags = value;
        }
      }
      public Real FlashLength {
        get {
          return this._flashLength;
        }
        set {
          this._flashLength = value;
        }
      }
      public ARGBColor DisabledColor {
        get {
          return this._disabledColor;
        }
        set {
          this._disabledColor = value;
        }
      }
      public TagReference HudMessages {
        get {
          return this._hudMessages;
        }
        set {
          this._hudMessages = value;
        }
      }
      public ARGBColor DefaultColor2 {
        get {
          return this._defaultColor2;
        }
        set {
          this._defaultColor2 = value;
        }
      }
      public ARGBColor FlashingColor2 {
        get {
          return this._flashingColor2;
        }
        set {
          this._flashingColor2 = value;
        }
      }
      public Real FlashPeriod2 {
        get {
          return this._flashPeriod2;
        }
        set {
          this._flashPeriod2 = value;
        }
      }
      public Real FlashDelay2 {
        get {
          return this._flashDelay2;
        }
        set {
          this._flashDelay2 = value;
        }
      }
      public ShortInteger NumberOfFlashes2 {
        get {
          return this._numberOfFlashes2;
        }
        set {
          this._numberOfFlashes2 = value;
        }
      }
      public Flags FlashFlags2 {
        get {
          return this._flashFlags2;
        }
        set {
          this._flashFlags2 = value;
        }
      }
      public Real FlashLength2 {
        get {
          return this._flashLength2;
        }
        set {
          this._flashLength2 = value;
        }
      }
      public ARGBColor DisabledColor2 {
        get {
          return this._disabledColor2;
        }
        set {
          this._disabledColor2 = value;
        }
      }
      public ShortInteger UptimeTicks {
        get {
          return this._uptimeTicks;
        }
        set {
          this._uptimeTicks = value;
        }
      }
      public ShortInteger FadeTicks {
        get {
          return this._fadeTicks;
        }
        set {
          this._fadeTicks = value;
        }
      }
      public Real TopOffset {
        get {
          return this._topOffset;
        }
        set {
          this._topOffset = value;
        }
      }
      public Real BottomOffset {
        get {
          return this._bottomOffset;
        }
        set {
          this._bottomOffset = value;
        }
      }
      public Real LeftOffset {
        get {
          return this._leftOffset;
        }
        set {
          this._leftOffset = value;
        }
      }
      public Real RightOffset {
        get {
          return this._rightOffset;
        }
        set {
          this._rightOffset = value;
        }
      }
      public TagReference ArrowBitmap {
        get {
          return this._arrowBitmap;
        }
        set {
          this._arrowBitmap = value;
        }
      }
      public Real HudScaleInMultiplayer {
        get {
          return this._hudScaleInMultiplayer;
        }
        set {
          this._hudScaleInMultiplayer = value;
        }
      }
      public Real MotionSensorRange {
        get {
          return this._motionSensorRange;
        }
        set {
          this._motionSensorRange = value;
        }
      }
      public Real MotionSensorVelocitySensitivity {
        get {
          return this._motionSensorVelocitySensitivity;
        }
        set {
          this._motionSensorVelocitySensitivity = value;
        }
      }
      public Real MotionSensorScaleDONTTOUCHEVER {
        get {
          return this._motionSensorScaleDONTTOUCHEVER;
        }
        set {
          this._motionSensorScaleDONTTOUCHEVER = value;
        }
      }
      public Rectangle2D DefaultChapterTitleBounds {
        get {
          return this._defaultChapterTitleBounds;
        }
        set {
          this._defaultChapterTitleBounds = value;
        }
      }
      public ShortInteger TopOffset2 {
        get {
          return this._topOffset2;
        }
        set {
          this._topOffset2 = value;
        }
      }
      public ShortInteger BottomOffset2 {
        get {
          return this._bottomOffset2;
        }
        set {
          this._bottomOffset2 = value;
        }
      }
      public ShortInteger LeftOffset2 {
        get {
          return this._leftOffset2;
        }
        set {
          this._leftOffset2 = value;
        }
      }
      public ShortInteger RightOffset2 {
        get {
          return this._rightOffset2;
        }
        set {
          this._rightOffset2 = value;
        }
      }
      public TagReference IndicatorBitmap {
        get {
          return this._indicatorBitmap;
        }
        set {
          this._indicatorBitmap = value;
        }
      }
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
        }
      }
      public ShortInteger MultiplayerSequenceIndex {
        get {
          return this._multiplayerSequenceIndex;
        }
        set {
          this._multiplayerSequenceIndex = value;
        }
      }
      public ARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public ARGBColor DefaultColor3 {
        get {
          return this._defaultColor3;
        }
        set {
          this._defaultColor3 = value;
        }
      }
      public ARGBColor FlashingColor3 {
        get {
          return this._flashingColor3;
        }
        set {
          this._flashingColor3 = value;
        }
      }
      public Real FlashPeriod3 {
        get {
          return this._flashPeriod3;
        }
        set {
          this._flashPeriod3 = value;
        }
      }
      public Real FlashDelay3 {
        get {
          return this._flashDelay3;
        }
        set {
          this._flashDelay3 = value;
        }
      }
      public ShortInteger NumberOfFlashes3 {
        get {
          return this._numberOfFlashes3;
        }
        set {
          this._numberOfFlashes3 = value;
        }
      }
      public Flags FlashFlags3 {
        get {
          return this._flashFlags3;
        }
        set {
          this._flashFlags3 = value;
        }
      }
      public Real FlashLength3 {
        get {
          return this._flashLength3;
        }
        set {
          this._flashLength3 = value;
        }
      }
      public ARGBColor DisabledColor3 {
        get {
          return this._disabledColor3;
        }
        set {
          this._disabledColor3 = value;
        }
      }
      public ARGBColor DefaultColor4 {
        get {
          return this._defaultColor4;
        }
        set {
          this._defaultColor4 = value;
        }
      }
      public ARGBColor FlashingColor4 {
        get {
          return this._flashingColor4;
        }
        set {
          this._flashingColor4 = value;
        }
      }
      public Real FlashPeriod4 {
        get {
          return this._flashPeriod4;
        }
        set {
          this._flashPeriod4 = value;
        }
      }
      public Real FlashDelay4 {
        get {
          return this._flashDelay4;
        }
        set {
          this._flashDelay4 = value;
        }
      }
      public ShortInteger NumberOfFlashes4 {
        get {
          return this._numberOfFlashes4;
        }
        set {
          this._numberOfFlashes4 = value;
        }
      }
      public Flags FlashFlags4 {
        get {
          return this._flashFlags4;
        }
        set {
          this._flashFlags4 = value;
        }
      }
      public Real FlashLength4 {
        get {
          return this._flashLength4;
        }
        set {
          this._flashLength4 = value;
        }
      }
      public ARGBColor DisabledColor4 {
        get {
          return this._disabledColor4;
        }
        set {
          this._disabledColor4 = value;
        }
      }
      public TagReference CarnageReportBitmap {
        get {
          return this._carnageReportBitmap;
        }
        set {
          this._carnageReportBitmap = value;
        }
      }
      public ShortInteger LoadingBeginText {
        get {
          return this._loadingBeginText;
        }
        set {
          this._loadingBeginText = value;
        }
      }
      public ShortInteger LoadingEndText {
        get {
          return this._loadingEndText;
        }
        set {
          this._loadingEndText = value;
        }
      }
      public ShortInteger CheckpointBeginText {
        get {
          return this._checkpointBeginText;
        }
        set {
          this._checkpointBeginText = value;
        }
      }
      public ShortInteger CheckpointEndText {
        get {
          return this._checkpointEndText;
        }
        set {
          this._checkpointEndText = value;
        }
      }
      public TagReference CheckpointSound {
        get {
          return this._checkpointSound;
        }
        set {
          this._checkpointSound = value;
        }
      }
      public TagReference HudText {
        get {
          return this._hudText;
        }
        set {
          this._hudText = value;
        }
      }
      public TagReference PrimaryMessageSound {
        get {
          return this._primaryMessageSound;
        }
        set {
          this._primaryMessageSound = value;
        }
      }
      public TagReference SecondaryMessageSound {
        get {
          return this._secondaryMessageSound;
        }
        set {
          this._secondaryMessageSound = value;
        }
      }
      public StringId BootGrieferString {
        get {
          return this._bootGrieferString;
        }
        set {
          this._bootGrieferString = value;
        }
      }
      public StringId CannotBootGrieferString {
        get {
          return this._cannotBootGrieferString;
        }
        set {
          this._cannotBootGrieferString = value;
        }
      }
      public TagReference TrainingShader {
        get {
          return this._trainingShader;
        }
        set {
          this._trainingShader = value;
        }
      }
      public TagReference HumanTrainingTopRight {
        get {
          return this._humanTrainingTopRight;
        }
        set {
          this._humanTrainingTopRight = value;
        }
      }
      public TagReference HumanTrainingTopCenter {
        get {
          return this._humanTrainingTopCenter;
        }
        set {
          this._humanTrainingTopCenter = value;
        }
      }
      public TagReference HumanTrainingTopLeft {
        get {
          return this._humanTrainingTopLeft;
        }
        set {
          this._humanTrainingTopLeft = value;
        }
      }
      public TagReference HumanTrainingMiddle {
        get {
          return this._humanTrainingMiddle;
        }
        set {
          this._humanTrainingMiddle = value;
        }
      }
      public TagReference EliteTrainingTopRight {
        get {
          return this._eliteTrainingTopRight;
        }
        set {
          this._eliteTrainingTopRight = value;
        }
      }
      public TagReference EliteTrainingTopCenter {
        get {
          return this._eliteTrainingTopCenter;
        }
        set {
          this._eliteTrainingTopCenter = value;
        }
      }
      public TagReference EliteTrainingTopLeft {
        get {
          return this._eliteTrainingTopLeft;
        }
        set {
          this._eliteTrainingTopLeft = value;
        }
      }
      public TagReference EliteTrainingMiddle {
        get {
          return this._eliteTrainingMiddle;
        }
        set {
          this._eliteTrainingMiddle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _anchor.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _obsolete1.Read(reader);
        _obsolete2.Read(reader);
        _upTime.Read(reader);
        _fadeTime.Read(reader);
        _iconColor.Read(reader);
        _textColor.Read(reader);
        _textSpacing.Read(reader);
        _itemMessageText.Read(reader);
        _iconBitmap.Read(reader);
        _alternateIconText.Read(reader);
        _buttonIcons.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed4.Read(reader);
        _hudMessages.Read(reader);
        _defaultColor2.Read(reader);
        _flashingColor2.Read(reader);
        _flashPeriod2.Read(reader);
        _flashDelay2.Read(reader);
        _numberOfFlashes2.Read(reader);
        _flashFlags2.Read(reader);
        _flashLength2.Read(reader);
        _disabledColor2.Read(reader);
        _uptimeTicks.Read(reader);
        _fadeTicks.Read(reader);
        _topOffset.Read(reader);
        _bottomOffset.Read(reader);
        _leftOffset.Read(reader);
        _rightOffset.Read(reader);
        _unnamed5.Read(reader);
        _arrowBitmap.Read(reader);
        _waypointArrows.Read(reader);
        _unnamed6.Read(reader);
        _hudScaleInMultiplayer.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _motionSensorRange.Read(reader);
        _motionSensorVelocitySensitivity.Read(reader);
        _motionSensorScaleDONTTOUCHEVER.Read(reader);
        _defaultChapterTitleBounds.Read(reader);
        _unnamed9.Read(reader);
        _topOffset2.Read(reader);
        _bottomOffset2.Read(reader);
        _leftOffset2.Read(reader);
        _rightOffset2.Read(reader);
        _unnamed10.Read(reader);
        _indicatorBitmap.Read(reader);
        _sequenceIndex.Read(reader);
        _multiplayerSequenceIndex.Read(reader);
        _color.Read(reader);
        _unnamed11.Read(reader);
        _defaultColor3.Read(reader);
        _flashingColor3.Read(reader);
        _flashPeriod3.Read(reader);
        _flashDelay3.Read(reader);
        _numberOfFlashes3.Read(reader);
        _flashFlags3.Read(reader);
        _flashLength3.Read(reader);
        _disabledColor3.Read(reader);
        _unnamed12.Read(reader);
        _defaultColor4.Read(reader);
        _flashingColor4.Read(reader);
        _flashPeriod4.Read(reader);
        _flashDelay4.Read(reader);
        _numberOfFlashes4.Read(reader);
        _flashFlags4.Read(reader);
        _flashLength4.Read(reader);
        _disabledColor4.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _carnageReportBitmap.Read(reader);
        _loadingBeginText.Read(reader);
        _loadingEndText.Read(reader);
        _checkpointBeginText.Read(reader);
        _checkpointEndText.Read(reader);
        _checkpointSound.Read(reader);
        _unnamed15.Read(reader);
        _hudText.Read(reader);
        _dashlights.Read(reader);
        _waypointArrows2.Read(reader);
        _waypoints.Read(reader);
        _hudSounds.Read(reader);
        _playerTrainingData.Read(reader);
        _primaryMessageSound.Read(reader);
        _secondaryMessageSound.Read(reader);
        _bootGrieferString.Read(reader);
        _cannotBootGrieferString.Read(reader);
        _trainingShader.Read(reader);
        _humanTrainingTopRight.Read(reader);
        _humanTrainingTopCenter.Read(reader);
        _humanTrainingTopLeft.Read(reader);
        _humanTrainingMiddle.Read(reader);
        _eliteTrainingTopRight.Read(reader);
        _eliteTrainingTopCenter.Read(reader);
        _eliteTrainingTopLeft.Read(reader);
        _eliteTrainingMiddle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _obsolete1.ReadString(reader);
        _obsolete2.ReadString(reader);
        _itemMessageText.ReadString(reader);
        _iconBitmap.ReadString(reader);
        _alternateIconText.ReadString(reader);
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons.Add(new HudButtonIconBlockBlock());
          ButtonIcons[x].Read(reader);
        }
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons[x].ReadChildData(reader);
        }
        _hudMessages.ReadString(reader);
        _arrowBitmap.ReadString(reader);
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows.Add(new HudWaypointArrowBlockBlock());
          WaypointArrows[x].Read(reader);
        }
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows[x].ReadChildData(reader);
        }
        _indicatorBitmap.ReadString(reader);
        _carnageReportBitmap.ReadString(reader);
        _checkpointSound.ReadString(reader);
        _hudText.ReadString(reader);
        for (x = 0; (x < _dashlights.Count); x = (x + 1)) {
          Dashlights.Add(new HudDashlightsBlockBlock());
          Dashlights[x].Read(reader);
        }
        for (x = 0; (x < _dashlights.Count); x = (x + 1)) {
          Dashlights[x].ReadChildData(reader);
        }
        for (x = 0; (x < _waypointArrows2.Count); x = (x + 1)) {
          WaypointArrows2.Add(new HudWaypointArrowBlockBlock());
          WaypointArrows2[x].Read(reader);
        }
        for (x = 0; (x < _waypointArrows2.Count); x = (x + 1)) {
          WaypointArrows2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _waypoints.Count); x = (x + 1)) {
          Waypoints.Add(new HudWaypointBlockBlock());
          Waypoints[x].Read(reader);
        }
        for (x = 0; (x < _waypoints.Count); x = (x + 1)) {
          Waypoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _hudSounds.Count); x = (x + 1)) {
          HudSounds.Add(new NewHudSoundBlockBlock());
          HudSounds[x].Read(reader);
        }
        for (x = 0; (x < _hudSounds.Count); x = (x + 1)) {
          HudSounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerTrainingData.Count); x = (x + 1)) {
          PlayerTrainingData.Add(new PlayerTrainingEntryDataBlockBlock());
          PlayerTrainingData[x].Read(reader);
        }
        for (x = 0; (x < _playerTrainingData.Count); x = (x + 1)) {
          PlayerTrainingData[x].ReadChildData(reader);
        }
        _primaryMessageSound.ReadString(reader);
        _secondaryMessageSound.ReadString(reader);
        _bootGrieferString.ReadString(reader);
        _cannotBootGrieferString.ReadString(reader);
        _trainingShader.ReadString(reader);
        _humanTrainingTopRight.ReadString(reader);
        _humanTrainingTopCenter.ReadString(reader);
        _humanTrainingTopLeft.ReadString(reader);
        _humanTrainingMiddle.ReadString(reader);
        _eliteTrainingTopRight.ReadString(reader);
        _eliteTrainingTopCenter.ReadString(reader);
        _eliteTrainingTopLeft.ReadString(reader);
        _eliteTrainingMiddle.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _anchor.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _obsolete1.Write(bw);
        _obsolete2.Write(bw);
        _upTime.Write(bw);
        _fadeTime.Write(bw);
        _iconColor.Write(bw);
        _textColor.Write(bw);
        _textSpacing.Write(bw);
        _itemMessageText.Write(bw);
        _iconBitmap.Write(bw);
        _alternateIconText.Write(bw);
_buttonIcons.Count = ButtonIcons.Count;
        _buttonIcons.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed4.Write(bw);
        _hudMessages.Write(bw);
        _defaultColor2.Write(bw);
        _flashingColor2.Write(bw);
        _flashPeriod2.Write(bw);
        _flashDelay2.Write(bw);
        _numberOfFlashes2.Write(bw);
        _flashFlags2.Write(bw);
        _flashLength2.Write(bw);
        _disabledColor2.Write(bw);
        _uptimeTicks.Write(bw);
        _fadeTicks.Write(bw);
        _topOffset.Write(bw);
        _bottomOffset.Write(bw);
        _leftOffset.Write(bw);
        _rightOffset.Write(bw);
        _unnamed5.Write(bw);
        _arrowBitmap.Write(bw);
_waypointArrows.Count = WaypointArrows.Count;
        _waypointArrows.Write(bw);
        _unnamed6.Write(bw);
        _hudScaleInMultiplayer.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _motionSensorRange.Write(bw);
        _motionSensorVelocitySensitivity.Write(bw);
        _motionSensorScaleDONTTOUCHEVER.Write(bw);
        _defaultChapterTitleBounds.Write(bw);
        _unnamed9.Write(bw);
        _topOffset2.Write(bw);
        _bottomOffset2.Write(bw);
        _leftOffset2.Write(bw);
        _rightOffset2.Write(bw);
        _unnamed10.Write(bw);
        _indicatorBitmap.Write(bw);
        _sequenceIndex.Write(bw);
        _multiplayerSequenceIndex.Write(bw);
        _color.Write(bw);
        _unnamed11.Write(bw);
        _defaultColor3.Write(bw);
        _flashingColor3.Write(bw);
        _flashPeriod3.Write(bw);
        _flashDelay3.Write(bw);
        _numberOfFlashes3.Write(bw);
        _flashFlags3.Write(bw);
        _flashLength3.Write(bw);
        _disabledColor3.Write(bw);
        _unnamed12.Write(bw);
        _defaultColor4.Write(bw);
        _flashingColor4.Write(bw);
        _flashPeriod4.Write(bw);
        _flashDelay4.Write(bw);
        _numberOfFlashes4.Write(bw);
        _flashFlags4.Write(bw);
        _flashLength4.Write(bw);
        _disabledColor4.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _carnageReportBitmap.Write(bw);
        _loadingBeginText.Write(bw);
        _loadingEndText.Write(bw);
        _checkpointBeginText.Write(bw);
        _checkpointEndText.Write(bw);
        _checkpointSound.Write(bw);
        _unnamed15.Write(bw);
        _hudText.Write(bw);
_dashlights.Count = Dashlights.Count;
        _dashlights.Write(bw);
_waypointArrows2.Count = WaypointArrows2.Count;
        _waypointArrows2.Write(bw);
_waypoints.Count = Waypoints.Count;
        _waypoints.Write(bw);
_hudSounds.Count = HudSounds.Count;
        _hudSounds.Write(bw);
_playerTrainingData.Count = PlayerTrainingData.Count;
        _playerTrainingData.Write(bw);
        _primaryMessageSound.Write(bw);
        _secondaryMessageSound.Write(bw);
        _bootGrieferString.Write(bw);
        _cannotBootGrieferString.Write(bw);
        _trainingShader.Write(bw);
        _humanTrainingTopRight.Write(bw);
        _humanTrainingTopCenter.Write(bw);
        _humanTrainingTopLeft.Write(bw);
        _humanTrainingMiddle.Write(bw);
        _eliteTrainingTopRight.Write(bw);
        _eliteTrainingTopCenter.Write(bw);
        _eliteTrainingTopLeft.Write(bw);
        _eliteTrainingMiddle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _obsolete1.WriteString(writer);
        _obsolete2.WriteString(writer);
        _itemMessageText.WriteString(writer);
        _iconBitmap.WriteString(writer);
        _alternateIconText.WriteString(writer);
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons[x].Write(writer);
        }
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons[x].WriteChildData(writer);
        }
        _hudMessages.WriteString(writer);
        _arrowBitmap.WriteString(writer);
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows[x].Write(writer);
        }
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows[x].WriteChildData(writer);
        }
        _indicatorBitmap.WriteString(writer);
        _carnageReportBitmap.WriteString(writer);
        _checkpointSound.WriteString(writer);
        _hudText.WriteString(writer);
        for (x = 0; (x < _dashlights.Count); x = (x + 1)) {
          Dashlights[x].Write(writer);
        }
        for (x = 0; (x < _dashlights.Count); x = (x + 1)) {
          Dashlights[x].WriteChildData(writer);
        }
        for (x = 0; (x < _waypointArrows2.Count); x = (x + 1)) {
          WaypointArrows2[x].Write(writer);
        }
        for (x = 0; (x < _waypointArrows2.Count); x = (x + 1)) {
          WaypointArrows2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _waypoints.Count); x = (x + 1)) {
          Waypoints[x].Write(writer);
        }
        for (x = 0; (x < _waypoints.Count); x = (x + 1)) {
          Waypoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _hudSounds.Count); x = (x + 1)) {
          HudSounds[x].Write(writer);
        }
        for (x = 0; (x < _hudSounds.Count); x = (x + 1)) {
          HudSounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerTrainingData.Count); x = (x + 1)) {
          PlayerTrainingData[x].Write(writer);
        }
        for (x = 0; (x < _playerTrainingData.Count); x = (x + 1)) {
          PlayerTrainingData[x].WriteChildData(writer);
        }
        _primaryMessageSound.WriteString(writer);
        _secondaryMessageSound.WriteString(writer);
        _bootGrieferString.WriteString(writer);
        _cannotBootGrieferString.WriteString(writer);
        _trainingShader.WriteString(writer);
        _humanTrainingTopRight.WriteString(writer);
        _humanTrainingTopCenter.WriteString(writer);
        _humanTrainingTopLeft.WriteString(writer);
        _humanTrainingMiddle.WriteString(writer);
        _eliteTrainingTopRight.WriteString(writer);
        _eliteTrainingTopCenter.WriteString(writer);
        _eliteTrainingTopLeft.WriteString(writer);
        _eliteTrainingMiddle.WriteString(writer);
      }
    }
    public class HudButtonIconBlockBlock : IBlock {
      private ShortInteger _sequenceIndex = new ShortInteger();
      private ShortInteger _widthOffset = new ShortInteger();
      private Point2D _offsetFromReferenceCorner = new Point2D();
      private ARGBColor _overrideIconColor = new ARGBColor();
      private CharInteger _frameRate030 = new CharInteger();
      private Flags _flags;
      private ShortInteger _textIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public HudButtonIconBlockBlock() {
        this._flags = new Flags(1);
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
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
        }
      }
      public ShortInteger WidthOffset {
        get {
          return this._widthOffset;
        }
        set {
          this._widthOffset = value;
        }
      }
      public Point2D OffsetFromReferenceCorner {
        get {
          return this._offsetFromReferenceCorner;
        }
        set {
          this._offsetFromReferenceCorner = value;
        }
      }
      public ARGBColor OverrideIconColor {
        get {
          return this._overrideIconColor;
        }
        set {
          this._overrideIconColor = value;
        }
      }
      public CharInteger FrameRate030 {
        get {
          return this._frameRate030;
        }
        set {
          this._frameRate030 = value;
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
      public ShortInteger TextIndex {
        get {
          return this._textIndex;
        }
        set {
          this._textIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sequenceIndex.Read(reader);
        _widthOffset.Read(reader);
        _offsetFromReferenceCorner.Read(reader);
        _overrideIconColor.Read(reader);
        _frameRate030.Read(reader);
        _flags.Read(reader);
        _textIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _sequenceIndex.Write(bw);
        _widthOffset.Write(bw);
        _offsetFromReferenceCorner.Write(bw);
        _overrideIconColor.Write(bw);
        _frameRate030.Write(bw);
        _flags.Write(bw);
        _textIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HudWaypointArrowBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed0;
      private RGBColor _color = new RGBColor();
      private Real _opacity = new Real();
      private Real _translucency = new Real();
      private ShortInteger _onScreenSequenceIndex = new ShortInteger();
      private ShortInteger _offScreenSequenceIndex = new ShortInteger();
      private ShortInteger _occludedSequenceIndex = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Flags _flags;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public HudWaypointArrowBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(8);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(16);
        this._flags = new Flags(4);
        this._unnamed3 = new Pad(24);
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
      public RGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public Real Opacity {
        get {
          return this._opacity;
        }
        set {
          this._opacity = value;
        }
      }
      public Real Translucency {
        get {
          return this._translucency;
        }
        set {
          this._translucency = value;
        }
      }
      public ShortInteger OnScreenSequenceIndex {
        get {
          return this._onScreenSequenceIndex;
        }
        set {
          this._onScreenSequenceIndex = value;
        }
      }
      public ShortInteger OffScreenSequenceIndex {
        get {
          return this._offScreenSequenceIndex;
        }
        set {
          this._offScreenSequenceIndex = value;
        }
      }
      public ShortInteger OccludedSequenceIndex {
        get {
          return this._occludedSequenceIndex;
        }
        set {
          this._occludedSequenceIndex = value;
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
        _color.Read(reader);
        _opacity.Read(reader);
        _translucency.Read(reader);
        _onScreenSequenceIndex.Read(reader);
        _offScreenSequenceIndex.Read(reader);
        _occludedSequenceIndex.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _flags.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
        _color.Write(bw);
        _opacity.Write(bw);
        _translucency.Write(bw);
        _onScreenSequenceIndex.Write(bw);
        _offScreenSequenceIndex.Write(bw);
        _occludedSequenceIndex.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _flags.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HudDashlightsBlockBlock : IBlock {
      private TagReference _bitmap = new TagReference();
      private TagReference _shader = new TagReference();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Flags _flags;
      private TagReference _sound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public HudDashlightsBlockBlock() {
        this._flags = new Flags(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_shader.Value);
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
        }
      }
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
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
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmap.Read(reader);
        _shader.Read(reader);
        _sequenceIndex.Read(reader);
        _flags.Read(reader);
        _sound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
        _shader.ReadString(reader);
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmap.Write(bw);
        _shader.Write(bw);
        _sequenceIndex.Write(bw);
        _flags.Write(bw);
        _sound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
        _shader.WriteString(writer);
        _sound.WriteString(writer);
      }
    }
    public class HudWaypointBlockBlock : IBlock {
      private TagReference _bitmap = new TagReference();
      private TagReference _shader = new TagReference();
      private ShortInteger _onscreenSequenceIndex = new ShortInteger();
      private ShortInteger _occludedSequenceIndex = new ShortInteger();
      private ShortInteger _offscreenSequenceIndex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public HudWaypointBlockBlock() {
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_shader.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
        }
      }
      public ShortInteger OnscreenSequenceIndex {
        get {
          return this._onscreenSequenceIndex;
        }
        set {
          this._onscreenSequenceIndex = value;
        }
      }
      public ShortInteger OccludedSequenceIndex {
        get {
          return this._occludedSequenceIndex;
        }
        set {
          this._occludedSequenceIndex = value;
        }
      }
      public ShortInteger OffscreenSequenceIndex {
        get {
          return this._offscreenSequenceIndex;
        }
        set {
          this._offscreenSequenceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bitmap.Read(reader);
        _shader.Read(reader);
        _onscreenSequenceIndex.Read(reader);
        _occludedSequenceIndex.Read(reader);
        _offscreenSequenceIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmap.Write(bw);
        _shader.Write(bw);
        _onscreenSequenceIndex.Write(bw);
        _occludedSequenceIndex.Write(bw);
        _offscreenSequenceIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
        _shader.WriteString(writer);
      }
    }
    public class NewHudSoundBlockBlock : IBlock {
      private TagReference _chiefSound = new TagReference();
      private Flags _latchedTo;
      private Real _scale = new Real();
      private TagReference _dervishSound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public NewHudSoundBlockBlock() {
if (this._chiefSound is System.ComponentModel.INotifyPropertyChanged)
  (this._chiefSound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._latchedTo = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_chiefSound.Value);
references.Add(_dervishSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _chiefSound.ToString();
        }
      }
      public TagReference ChiefSound {
        get {
          return this._chiefSound;
        }
        set {
          this._chiefSound = value;
        }
      }
      public Flags LatchedTo {
        get {
          return this._latchedTo;
        }
        set {
          this._latchedTo = value;
        }
      }
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public TagReference DervishSound {
        get {
          return this._dervishSound;
        }
        set {
          this._dervishSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _chiefSound.Read(reader);
        _latchedTo.Read(reader);
        _scale.Read(reader);
        _dervishSound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _chiefSound.ReadString(reader);
        _dervishSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _chiefSound.Write(bw);
        _latchedTo.Write(bw);
        _scale.Write(bw);
        _dervishSound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _chiefSound.WriteString(writer);
        _dervishSound.WriteString(writer);
      }
    }
    public class PlayerTrainingEntryDataBlockBlock : IBlock {
      private StringId _displayString = new StringId();
      private ShortInteger _maxDisplayTime = new ShortInteger();
      private ShortInteger _displayCount = new ShortInteger();
      private ShortInteger _dissapearDelay = new ShortInteger();
      private ShortInteger _redisplayDelay = new ShortInteger();
      private Real _displayDelayS = new Real();
      private Flags _flags;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public PlayerTrainingEntryDataBlockBlock() {
        this._flags = new Flags(2);
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
      public StringId DisplayString {
        get {
          return this._displayString;
        }
        set {
          this._displayString = value;
        }
      }
      public ShortInteger MaxDisplayTime {
        get {
          return this._maxDisplayTime;
        }
        set {
          this._maxDisplayTime = value;
        }
      }
      public ShortInteger DisplayCount {
        get {
          return this._displayCount;
        }
        set {
          this._displayCount = value;
        }
      }
      public ShortInteger DissapearDelay {
        get {
          return this._dissapearDelay;
        }
        set {
          this._dissapearDelay = value;
        }
      }
      public ShortInteger RedisplayDelay {
        get {
          return this._redisplayDelay;
        }
        set {
          this._redisplayDelay = value;
        }
      }
      public Real DisplayDelayS {
        get {
          return this._displayDelayS;
        }
        set {
          this._displayDelayS = value;
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
        _displayString.Read(reader);
        _maxDisplayTime.Read(reader);
        _displayCount.Read(reader);
        _dissapearDelay.Read(reader);
        _redisplayDelay.Read(reader);
        _displayDelayS.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _displayString.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _displayString.Write(bw);
        _maxDisplayTime.Write(bw);
        _displayCount.Write(bw);
        _dissapearDelay.Write(bw);
        _redisplayDelay.Write(bw);
        _displayDelayS.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _displayString.WriteString(writer);
      }
    }
  }
}
