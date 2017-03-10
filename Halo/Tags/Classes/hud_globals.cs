// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'hud_globals'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class hud_globals : Interfaces.Pool.Tag {
    private HudGlobalsBlock hudGlobalsValues = new HudGlobalsBlock();
    public virtual HudGlobalsBlock HudGlobalsValues {
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
    public class HudGlobalsBlock : IBlock {
      private Enum _anchor = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private TagReference _singlePlayerFont = new TagReference();
      private TagReference _multiPlayerFont = new TagReference();
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
      private Pad _unnamed5;
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
      private Pad _unnamed6;
      private TagReference _arrowBitmap = new TagReference();
      private Block _waypointArrows = new Block();
      private Pad _unnamed7;
      private Real _hudScaleInMultiplayer = new Real();
      private Pad _unnamed8;
      private TagReference _defaultWeaponHud = new TagReference();
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
      public BlockCollection<HudButtonIconBlock> _buttonIconsList = new BlockCollection<HudButtonIconBlock>();
      public BlockCollection<HudWaypointArrowBlock> _waypointArrowsList = new BlockCollection<HudWaypointArrowBlock>();
public event System.EventHandler BlockNameChanged;
      public HudGlobalsBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._scalingFlags = new Flags(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed5 = new Pad(4);
        this._flashFlags2 = new Flags(2);
        this._unnamed6 = new Pad(32);
        this._unnamed7 = new Pad(80);
        this._unnamed8 = new Pad(256);
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
      public BlockCollection<HudButtonIconBlock> ButtonIcons {
        get {
          return this._buttonIconsList;
        }
      }
      public BlockCollection<HudWaypointArrowBlock> WaypointArrows {
        get {
          return this._waypointArrowsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_singlePlayerFont.Value);
references.Add(_multiPlayerFont.Value);
references.Add(_itemMessageText.Value);
references.Add(_iconBitmap.Value);
references.Add(_alternateIconText.Value);
references.Add(_hudMessages.Value);
references.Add(_arrowBitmap.Value);
references.Add(_defaultWeaponHud.Value);
references.Add(_indicatorBitmap.Value);
references.Add(_carnageReportBitmap.Value);
references.Add(_checkpointSound.Value);
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
      public TagReference SinglePlayerFont {
        get {
          return this._singlePlayerFont;
        }
        set {
          this._singlePlayerFont = value;
        }
      }
      public TagReference MultiPlayerFont {
        get {
          return this._multiPlayerFont;
        }
        set {
          this._multiPlayerFont = value;
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
      public TagReference DefaultWeaponHud {
        get {
          return this._defaultWeaponHud;
        }
        set {
          this._defaultWeaponHud = value;
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
      public virtual void Read(BinaryReader reader) {
        _anchor.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _singlePlayerFont.Read(reader);
        _multiPlayerFont.Read(reader);
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
        _unnamed5.Read(reader);
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
        _unnamed6.Read(reader);
        _arrowBitmap.Read(reader);
        _waypointArrows.Read(reader);
        _unnamed7.Read(reader);
        _hudScaleInMultiplayer.Read(reader);
        _unnamed8.Read(reader);
        _defaultWeaponHud.Read(reader);
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _singlePlayerFont.ReadString(reader);
        _multiPlayerFont.ReadString(reader);
        _itemMessageText.ReadString(reader);
        _iconBitmap.ReadString(reader);
        _alternateIconText.ReadString(reader);
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons.Add(new HudButtonIconBlock());
          ButtonIcons[x].Read(reader);
        }
        for (x = 0; (x < _buttonIcons.Count); x = (x + 1)) {
          ButtonIcons[x].ReadChildData(reader);
        }
        _hudMessages.ReadString(reader);
        _arrowBitmap.ReadString(reader);
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows.Add(new HudWaypointArrowBlock());
          WaypointArrows[x].Read(reader);
        }
        for (x = 0; (x < _waypointArrows.Count); x = (x + 1)) {
          WaypointArrows[x].ReadChildData(reader);
        }
        _defaultWeaponHud.ReadString(reader);
        _indicatorBitmap.ReadString(reader);
        _carnageReportBitmap.ReadString(reader);
        _checkpointSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _anchor.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _singlePlayerFont.Write(bw);
        _multiPlayerFont.Write(bw);
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
        _unnamed5.Write(bw);
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
        _unnamed6.Write(bw);
        _arrowBitmap.Write(bw);
_waypointArrows.Count = WaypointArrows.Count;
        _waypointArrows.Write(bw);
        _unnamed7.Write(bw);
        _hudScaleInMultiplayer.Write(bw);
        _unnamed8.Write(bw);
        _defaultWeaponHud.Write(bw);
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
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _singlePlayerFont.WriteString(writer);
        _multiPlayerFont.WriteString(writer);
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
        _defaultWeaponHud.WriteString(writer);
        _indicatorBitmap.WriteString(writer);
        _carnageReportBitmap.WriteString(writer);
        _checkpointSound.WriteString(writer);
      }
    }
    public class HudButtonIconBlock : IBlock {
      private ShortInteger _sequenceIndex = new ShortInteger();
      private ShortInteger _widthOffset = new ShortInteger();
      private Point2D _offsetFromReferenceCorner = new Point2D();
      private ARGBColor _overrideIconColor = new ARGBColor();
      private CharInteger _frameRate = new CharInteger();
      private Flags _flags;
      private ShortInteger _textIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public HudButtonIconBlock() {
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
      public CharInteger FrameRate {
        get {
          return this._frameRate;
        }
        set {
          this._frameRate = value;
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
        _frameRate.Read(reader);
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
        _frameRate.Write(bw);
        _flags.Write(bw);
        _textIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HudWaypointArrowBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed;
      private RGBColor _color = new RGBColor();
      private Real _opacity = new Real();
      private Real _translucency = new Real();
      private ShortInteger _onScreenSequenceIndex = new ShortInteger();
      private ShortInteger _offScreenSequenceIndex = new ShortInteger();
      private ShortInteger _occludedSequenceIndex = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Flags _flags;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public HudWaypointArrowBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(16);
        this._flags = new Flags(4);
        this._unnamed4 = new Pad(24);
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
        _unnamed.Read(reader);
        _color.Read(reader);
        _opacity.Read(reader);
        _translucency.Read(reader);
        _onScreenSequenceIndex.Read(reader);
        _offScreenSequenceIndex.Read(reader);
        _occludedSequenceIndex.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _flags.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
        _color.Write(bw);
        _opacity.Write(bw);
        _translucency.Write(bw);
        _onScreenSequenceIndex.Write(bw);
        _offScreenSequenceIndex.Write(bw);
        _occludedSequenceIndex.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _flags.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
