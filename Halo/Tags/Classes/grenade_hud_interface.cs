// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'grenade_hud_interface'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class grenade_hud_interface : Interfaces.Pool.Tag {
    private GrenadeHudInterfaceBlock grenadeHudInterfaceValues = new GrenadeHudInterfaceBlock();
    public virtual GrenadeHudInterfaceBlock GrenadeHudInterfaceValues {
      get {
        return grenadeHudInterfaceValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(GrenadeHudInterfaceValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "grenade_hud_interface";
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
grenadeHudInterfaceValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
grenadeHudInterfaceValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
grenadeHudInterfaceValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
grenadeHudInterfaceValues.WriteChildData(writer);
    }
    #endregion
    public class GrenadeHudInterfaceBlock : IBlock {
      private Enum _anchor = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private TagReference _interfaceBitmap = new TagReference();
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed6;
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Pad _unnamed7;
      private Block _multitexOverlay = new Block();
      private Pad _unnamed8;
      private Point2D _anchorOffset2 = new Point2D();
      private Real _widthScale2 = new Real();
      private Real _heightScale2 = new Real();
      private Flags _scalingFlags2;
      private Pad _unnamed9;
      private Pad _unnamed10;
      private TagReference _interfaceBitmap2 = new TagReference();
      private ARGBColor _defaultColor2 = new ARGBColor();
      private ARGBColor _flashingColor2 = new ARGBColor();
      private Real _flashPeriod2 = new Real();
      private Real _flashDelay2 = new Real();
      private ShortInteger _numberOfFlashes2 = new ShortInteger();
      private Flags _flashFlags2;
      private Real _flashLength2 = new Real();
      private ARGBColor _disabledColor2 = new ARGBColor();
      private Pad _unnamed11;
      private ShortInteger _sequenceIndex2 = new ShortInteger();
      private Pad _unnamed12;
      private Block _multitexOverlay2 = new Block();
      private Pad _unnamed13;
      private Point2D _anchorOffset3 = new Point2D();
      private Real _widthScale3 = new Real();
      private Real _heightScale3 = new Real();
      private Flags _scalingFlags3;
      private Pad _unnamed14;
      private Pad _unnamed15;
      private ARGBColor _defaultColor3 = new ARGBColor();
      private ARGBColor _flashingColor3 = new ARGBColor();
      private Real _flashPeriod3 = new Real();
      private Real _flashDelay3 = new Real();
      private ShortInteger _numberOfFlashes3 = new ShortInteger();
      private Flags _flashFlags3;
      private Real _flashLength3 = new Real();
      private ARGBColor _disabledColor3 = new ARGBColor();
      private Pad _unnamed16;
      private CharInteger _maximumNumberOfDigits = new CharInteger();
      private Flags _flags;
      private CharInteger _numberOfFractionalDigits = new CharInteger();
      private Pad _unnamed17;
      private Pad _unnamed18;
      private ShortInteger _flashCutoff = new ShortInteger();
      private Pad _unnamed19;
      private TagReference _overlayBitmap = new TagReference();
      private Block _overlays = new Block();
      private Block _warningSounds = new Block();
      private Pad _unnamed20;
      private ShortInteger _sequenceIndex3 = new ShortInteger();
      private ShortInteger _widthOffset = new ShortInteger();
      private Point2D _offsetFromReferenceCorner = new Point2D();
      private ARGBColor _overrideIconColor = new ARGBColor();
      private CharInteger _frameRate = new CharInteger();
      private Flags _flags2;
      private ShortInteger _textIndex = new ShortInteger();
      private Pad _unnamed21;
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlayList = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlay2List = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GrenadeHudOverlayBlock> _overlaysList = new BlockCollection<GrenadeHudOverlayBlock>();
      public BlockCollection<GrenadeHudSoundBlock> _warningSoundsList = new BlockCollection<GrenadeHudSoundBlock>();
public event System.EventHandler BlockNameChanged;
      public GrenadeHudInterfaceBlock() {
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(32);
        this._scalingFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(4);
        this._scalingFlags2 = new Flags(2);
        this._unnamed9 = new Pad(2);
        this._unnamed10 = new Pad(20);
        this._flashFlags2 = new Flags(2);
        this._unnamed11 = new Pad(4);
        this._unnamed12 = new Pad(2);
        this._unnamed13 = new Pad(4);
        this._scalingFlags3 = new Flags(2);
        this._unnamed14 = new Pad(2);
        this._unnamed15 = new Pad(20);
        this._flashFlags3 = new Flags(2);
        this._unnamed16 = new Pad(4);
        this._flags = new Flags(1);
        this._unnamed17 = new Pad(1);
        this._unnamed18 = new Pad(12);
        this._unnamed19 = new Pad(2);
        this._unnamed20 = new Pad(68);
        this._flags2 = new Flags(1);
        this._unnamed21 = new Pad(48);
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay {
        get {
          return this._multitexOverlayList;
        }
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay2 {
        get {
          return this._multitexOverlay2List;
        }
      }
      public BlockCollection<GrenadeHudOverlayBlock> Overlays {
        get {
          return this._overlaysList;
        }
      }
      public BlockCollection<GrenadeHudSoundBlock> WarningSounds {
        get {
          return this._warningSoundsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_interfaceBitmap.Value);
references.Add(_interfaceBitmap2.Value);
references.Add(_overlayBitmap.Value);
for (int x=0; x<MultitexOverlay.BlockCount; x++)
{
  IBlock block = MultitexOverlay.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultitexOverlay2.BlockCount; x++)
{
  IBlock block = MultitexOverlay2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Overlays.BlockCount; x++)
{
  IBlock block = Overlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WarningSounds.BlockCount; x++)
{
  IBlock block = WarningSounds.GetBlock(x);
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
      public TagReference InterfaceBitmap {
        get {
          return this._interfaceBitmap;
        }
        set {
          this._interfaceBitmap = value;
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
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
        }
      }
      public Point2D AnchorOffset2 {
        get {
          return this._anchorOffset2;
        }
        set {
          this._anchorOffset2 = value;
        }
      }
      public Real WidthScale2 {
        get {
          return this._widthScale2;
        }
        set {
          this._widthScale2 = value;
        }
      }
      public Real HeightScale2 {
        get {
          return this._heightScale2;
        }
        set {
          this._heightScale2 = value;
        }
      }
      public Flags ScalingFlags2 {
        get {
          return this._scalingFlags2;
        }
        set {
          this._scalingFlags2 = value;
        }
      }
      public TagReference InterfaceBitmap2 {
        get {
          return this._interfaceBitmap2;
        }
        set {
          this._interfaceBitmap2 = value;
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
      public ShortInteger SequenceIndex2 {
        get {
          return this._sequenceIndex2;
        }
        set {
          this._sequenceIndex2 = value;
        }
      }
      public Point2D AnchorOffset3 {
        get {
          return this._anchorOffset3;
        }
        set {
          this._anchorOffset3 = value;
        }
      }
      public Real WidthScale3 {
        get {
          return this._widthScale3;
        }
        set {
          this._widthScale3 = value;
        }
      }
      public Real HeightScale3 {
        get {
          return this._heightScale3;
        }
        set {
          this._heightScale3 = value;
        }
      }
      public Flags ScalingFlags3 {
        get {
          return this._scalingFlags3;
        }
        set {
          this._scalingFlags3 = value;
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
      public CharInteger MaximumNumberOfDigits {
        get {
          return this._maximumNumberOfDigits;
        }
        set {
          this._maximumNumberOfDigits = value;
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
      public CharInteger NumberOfFractionalDigits {
        get {
          return this._numberOfFractionalDigits;
        }
        set {
          this._numberOfFractionalDigits = value;
        }
      }
      public ShortInteger FlashCutoff {
        get {
          return this._flashCutoff;
        }
        set {
          this._flashCutoff = value;
        }
      }
      public TagReference OverlayBitmap {
        get {
          return this._overlayBitmap;
        }
        set {
          this._overlayBitmap = value;
        }
      }
      public ShortInteger SequenceIndex3 {
        get {
          return this._sequenceIndex3;
        }
        set {
          this._sequenceIndex3 = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
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
        _anchor.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _interfaceBitmap.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed6.Read(reader);
        _sequenceIndex.Read(reader);
        _unnamed7.Read(reader);
        _multitexOverlay.Read(reader);
        _unnamed8.Read(reader);
        _anchorOffset2.Read(reader);
        _widthScale2.Read(reader);
        _heightScale2.Read(reader);
        _scalingFlags2.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _interfaceBitmap2.Read(reader);
        _defaultColor2.Read(reader);
        _flashingColor2.Read(reader);
        _flashPeriod2.Read(reader);
        _flashDelay2.Read(reader);
        _numberOfFlashes2.Read(reader);
        _flashFlags2.Read(reader);
        _flashLength2.Read(reader);
        _disabledColor2.Read(reader);
        _unnamed11.Read(reader);
        _sequenceIndex2.Read(reader);
        _unnamed12.Read(reader);
        _multitexOverlay2.Read(reader);
        _unnamed13.Read(reader);
        _anchorOffset3.Read(reader);
        _widthScale3.Read(reader);
        _heightScale3.Read(reader);
        _scalingFlags3.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _defaultColor3.Read(reader);
        _flashingColor3.Read(reader);
        _flashPeriod3.Read(reader);
        _flashDelay3.Read(reader);
        _numberOfFlashes3.Read(reader);
        _flashFlags3.Read(reader);
        _flashLength3.Read(reader);
        _disabledColor3.Read(reader);
        _unnamed16.Read(reader);
        _maximumNumberOfDigits.Read(reader);
        _flags.Read(reader);
        _numberOfFractionalDigits.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _flashCutoff.Read(reader);
        _unnamed19.Read(reader);
        _overlayBitmap.Read(reader);
        _overlays.Read(reader);
        _warningSounds.Read(reader);
        _unnamed20.Read(reader);
        _sequenceIndex3.Read(reader);
        _widthOffset.Read(reader);
        _offsetFromReferenceCorner.Read(reader);
        _overrideIconColor.Read(reader);
        _frameRate.Read(reader);
        _flags2.Read(reader);
        _textIndex.Read(reader);
        _unnamed21.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _interfaceBitmap.ReadString(reader);
        for (x = 0; (x < _multitexOverlay.Count); x = (x + 1)) {
          MultitexOverlay.Add(new GlobalHudMultitextureOverlayDefinitionBlock());
          MultitexOverlay[x].Read(reader);
        }
        for (x = 0; (x < _multitexOverlay.Count); x = (x + 1)) {
          MultitexOverlay[x].ReadChildData(reader);
        }
        _interfaceBitmap2.ReadString(reader);
        for (x = 0; (x < _multitexOverlay2.Count); x = (x + 1)) {
          MultitexOverlay2.Add(new GlobalHudMultitextureOverlayDefinitionBlock());
          MultitexOverlay2[x].Read(reader);
        }
        for (x = 0; (x < _multitexOverlay2.Count); x = (x + 1)) {
          MultitexOverlay2[x].ReadChildData(reader);
        }
        _overlayBitmap.ReadString(reader);
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays.Add(new GrenadeHudOverlayBlock());
          Overlays[x].Read(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _warningSounds.Count); x = (x + 1)) {
          WarningSounds.Add(new GrenadeHudSoundBlock());
          WarningSounds[x].Read(reader);
        }
        for (x = 0; (x < _warningSounds.Count); x = (x + 1)) {
          WarningSounds[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _anchor.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _interfaceBitmap.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed6.Write(bw);
        _sequenceIndex.Write(bw);
        _unnamed7.Write(bw);
_multitexOverlay.Count = MultitexOverlay.Count;
        _multitexOverlay.Write(bw);
        _unnamed8.Write(bw);
        _anchorOffset2.Write(bw);
        _widthScale2.Write(bw);
        _heightScale2.Write(bw);
        _scalingFlags2.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _interfaceBitmap2.Write(bw);
        _defaultColor2.Write(bw);
        _flashingColor2.Write(bw);
        _flashPeriod2.Write(bw);
        _flashDelay2.Write(bw);
        _numberOfFlashes2.Write(bw);
        _flashFlags2.Write(bw);
        _flashLength2.Write(bw);
        _disabledColor2.Write(bw);
        _unnamed11.Write(bw);
        _sequenceIndex2.Write(bw);
        _unnamed12.Write(bw);
_multitexOverlay2.Count = MultitexOverlay2.Count;
        _multitexOverlay2.Write(bw);
        _unnamed13.Write(bw);
        _anchorOffset3.Write(bw);
        _widthScale3.Write(bw);
        _heightScale3.Write(bw);
        _scalingFlags3.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _defaultColor3.Write(bw);
        _flashingColor3.Write(bw);
        _flashPeriod3.Write(bw);
        _flashDelay3.Write(bw);
        _numberOfFlashes3.Write(bw);
        _flashFlags3.Write(bw);
        _flashLength3.Write(bw);
        _disabledColor3.Write(bw);
        _unnamed16.Write(bw);
        _maximumNumberOfDigits.Write(bw);
        _flags.Write(bw);
        _numberOfFractionalDigits.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _flashCutoff.Write(bw);
        _unnamed19.Write(bw);
        _overlayBitmap.Write(bw);
_overlays.Count = Overlays.Count;
        _overlays.Write(bw);
_warningSounds.Count = WarningSounds.Count;
        _warningSounds.Write(bw);
        _unnamed20.Write(bw);
        _sequenceIndex3.Write(bw);
        _widthOffset.Write(bw);
        _offsetFromReferenceCorner.Write(bw);
        _overrideIconColor.Write(bw);
        _frameRate.Write(bw);
        _flags2.Write(bw);
        _textIndex.Write(bw);
        _unnamed21.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _interfaceBitmap.WriteString(writer);
        for (x = 0; (x < _multitexOverlay.Count); x = (x + 1)) {
          MultitexOverlay[x].Write(writer);
        }
        for (x = 0; (x < _multitexOverlay.Count); x = (x + 1)) {
          MultitexOverlay[x].WriteChildData(writer);
        }
        _interfaceBitmap2.WriteString(writer);
        for (x = 0; (x < _multitexOverlay2.Count); x = (x + 1)) {
          MultitexOverlay2[x].Write(writer);
        }
        for (x = 0; (x < _multitexOverlay2.Count); x = (x + 1)) {
          MultitexOverlay2[x].WriteChildData(writer);
        }
        _overlayBitmap.WriteString(writer);
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].Write(writer);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _warningSounds.Count); x = (x + 1)) {
          WarningSounds[x].Write(writer);
        }
        for (x = 0; (x < _warningSounds.Count); x = (x + 1)) {
          WarningSounds[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalHudMultitextureOverlayDefinitionBlock : IBlock {
      private Pad _unnamed;
      private ShortInteger _type = new ShortInteger();
      private Enum _framebufferBlendFunc = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Enum _primaryAnchor = new Enum();
      private Enum _secondaryAnchor = new Enum();
      private Enum _tertiaryAnchor = new Enum();
      private Enum @__0To1BlendFunc = new Enum();
      private Enum @__1To2BlendFunc = new Enum();
      private Pad _unnamed4;
      private RealPoint2D _primaryScale = new RealPoint2D();
      private RealPoint2D _secondaryScale = new RealPoint2D();
      private RealPoint2D _tertiaryScale = new RealPoint2D();
      private RealPoint2D _primaryOffset = new RealPoint2D();
      private RealPoint2D _secondaryOffset = new RealPoint2D();
      private RealPoint2D _tertiaryOffset = new RealPoint2D();
      private TagReference _primary = new TagReference();
      private TagReference _secondary = new TagReference();
      private TagReference _tertiary = new TagReference();
      private Enum _primaryWrapMode = new Enum();
      private Enum _secondaryWrapMode = new Enum();
      private Enum _tertiaryWrapMode = new Enum();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _effectors = new Block();
      private Pad _unnamed7;
      public BlockCollection<GlobalHudMultitextureOverlayEffectorDefinitionBlock> _effectorsList = new BlockCollection<GlobalHudMultitextureOverlayEffectorDefinitionBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalHudMultitextureOverlayDefinitionBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(32);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(184);
        this._unnamed7 = new Pad(128);
      }
      public BlockCollection<GlobalHudMultitextureOverlayEffectorDefinitionBlock> Effectors {
        get {
          return this._effectorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_primary.Value);
references.Add(_secondary.Value);
references.Add(_tertiary.Value);
for (int x=0; x<Effectors.BlockCount; x++)
{
  IBlock block = Effectors.GetBlock(x);
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
      public ShortInteger Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Enum FramebufferBlendFunc {
        get {
          return this._framebufferBlendFunc;
        }
        set {
          this._framebufferBlendFunc = value;
        }
      }
      public Enum PrimaryAnchor {
        get {
          return this._primaryAnchor;
        }
        set {
          this._primaryAnchor = value;
        }
      }
      public Enum SecondaryAnchor {
        get {
          return this._secondaryAnchor;
        }
        set {
          this._secondaryAnchor = value;
        }
      }
      public Enum TertiaryAnchor {
        get {
          return this._tertiaryAnchor;
        }
        set {
          this._tertiaryAnchor = value;
        }
      }
      public Enum _0To1BlendFunc {
        get {
          return this.@__0To1BlendFunc;
        }
        set {
          this.@__0To1BlendFunc = value;
        }
      }
      public Enum _1To2BlendFunc {
        get {
          return this.@__1To2BlendFunc;
        }
        set {
          this.@__1To2BlendFunc = value;
        }
      }
      public RealPoint2D PrimaryScale {
        get {
          return this._primaryScale;
        }
        set {
          this._primaryScale = value;
        }
      }
      public RealPoint2D SecondaryScale {
        get {
          return this._secondaryScale;
        }
        set {
          this._secondaryScale = value;
        }
      }
      public RealPoint2D TertiaryScale {
        get {
          return this._tertiaryScale;
        }
        set {
          this._tertiaryScale = value;
        }
      }
      public RealPoint2D PrimaryOffset {
        get {
          return this._primaryOffset;
        }
        set {
          this._primaryOffset = value;
        }
      }
      public RealPoint2D SecondaryOffset {
        get {
          return this._secondaryOffset;
        }
        set {
          this._secondaryOffset = value;
        }
      }
      public RealPoint2D TertiaryOffset {
        get {
          return this._tertiaryOffset;
        }
        set {
          this._tertiaryOffset = value;
        }
      }
      public TagReference Primary {
        get {
          return this._primary;
        }
        set {
          this._primary = value;
        }
      }
      public TagReference Secondary {
        get {
          return this._secondary;
        }
        set {
          this._secondary = value;
        }
      }
      public TagReference Tertiary {
        get {
          return this._tertiary;
        }
        set {
          this._tertiary = value;
        }
      }
      public Enum PrimaryWrapMode {
        get {
          return this._primaryWrapMode;
        }
        set {
          this._primaryWrapMode = value;
        }
      }
      public Enum SecondaryWrapMode {
        get {
          return this._secondaryWrapMode;
        }
        set {
          this._secondaryWrapMode = value;
        }
      }
      public Enum TertiaryWrapMode {
        get {
          return this._tertiaryWrapMode;
        }
        set {
          this._tertiaryWrapMode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _type.Read(reader);
        _framebufferBlendFunc.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _primaryAnchor.Read(reader);
        _secondaryAnchor.Read(reader);
        _tertiaryAnchor.Read(reader);
        @__0To1BlendFunc.Read(reader);
        @__1To2BlendFunc.Read(reader);
        _unnamed4.Read(reader);
        _primaryScale.Read(reader);
        _secondaryScale.Read(reader);
        _tertiaryScale.Read(reader);
        _primaryOffset.Read(reader);
        _secondaryOffset.Read(reader);
        _tertiaryOffset.Read(reader);
        _primary.Read(reader);
        _secondary.Read(reader);
        _tertiary.Read(reader);
        _primaryWrapMode.Read(reader);
        _secondaryWrapMode.Read(reader);
        _tertiaryWrapMode.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _effectors.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _primary.ReadString(reader);
        _secondary.ReadString(reader);
        _tertiary.ReadString(reader);
        for (x = 0; (x < _effectors.Count); x = (x + 1)) {
          Effectors.Add(new GlobalHudMultitextureOverlayEffectorDefinitionBlock());
          Effectors[x].Read(reader);
        }
        for (x = 0; (x < _effectors.Count); x = (x + 1)) {
          Effectors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _type.Write(bw);
        _framebufferBlendFunc.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _primaryAnchor.Write(bw);
        _secondaryAnchor.Write(bw);
        _tertiaryAnchor.Write(bw);
        @__0To1BlendFunc.Write(bw);
        @__1To2BlendFunc.Write(bw);
        _unnamed4.Write(bw);
        _primaryScale.Write(bw);
        _secondaryScale.Write(bw);
        _tertiaryScale.Write(bw);
        _primaryOffset.Write(bw);
        _secondaryOffset.Write(bw);
        _tertiaryOffset.Write(bw);
        _primary.Write(bw);
        _secondary.Write(bw);
        _tertiary.Write(bw);
        _primaryWrapMode.Write(bw);
        _secondaryWrapMode.Write(bw);
        _tertiaryWrapMode.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_effectors.Count = Effectors.Count;
        _effectors.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _primary.WriteString(writer);
        _secondary.WriteString(writer);
        _tertiary.WriteString(writer);
        for (x = 0; (x < _effectors.Count); x = (x + 1)) {
          Effectors[x].Write(writer);
        }
        for (x = 0; (x < _effectors.Count); x = (x + 1)) {
          Effectors[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalHudMultitextureOverlayEffectorDefinitionBlock : IBlock {
      private Pad _unnamed;
      private Enum _destinationType = new Enum();
      private Enum _destination = new Enum();
      private Enum _source = new Enum();
      private Pad _unnamed2;
      private RealBounds _inBounds = new RealBounds();
      private RealBounds _outBounds = new RealBounds();
      private Pad _unnamed3;
      private RealRGBColor _tintColorLowerBound = new RealRGBColor();
      private RealRGBColor _tintColorUpperBound = new RealRGBColor();
      private Enum _periodicFunction = new Enum();
      private Pad _unnamed4;
      private Real _functionPeriod = new Real();
      private Real _functionPhase = new Real();
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public GlobalHudMultitextureOverlayEffectorDefinitionBlock() {
        this._unnamed = new Pad(64);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(64);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(32);
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
      public Enum DestinationType {
        get {
          return this._destinationType;
        }
        set {
          this._destinationType = value;
        }
      }
      public Enum Destination {
        get {
          return this._destination;
        }
        set {
          this._destination = value;
        }
      }
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public RealBounds InBounds {
        get {
          return this._inBounds;
        }
        set {
          this._inBounds = value;
        }
      }
      public RealBounds OutBounds {
        get {
          return this._outBounds;
        }
        set {
          this._outBounds = value;
        }
      }
      public RealRGBColor TintColorLowerBound {
        get {
          return this._tintColorLowerBound;
        }
        set {
          this._tintColorLowerBound = value;
        }
      }
      public RealRGBColor TintColorUpperBound {
        get {
          return this._tintColorUpperBound;
        }
        set {
          this._tintColorUpperBound = value;
        }
      }
      public Enum PeriodicFunction {
        get {
          return this._periodicFunction;
        }
        set {
          this._periodicFunction = value;
        }
      }
      public Real FunctionPeriod {
        get {
          return this._functionPeriod;
        }
        set {
          this._functionPeriod = value;
        }
      }
      public Real FunctionPhase {
        get {
          return this._functionPhase;
        }
        set {
          this._functionPhase = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _destinationType.Read(reader);
        _destination.Read(reader);
        _source.Read(reader);
        _unnamed2.Read(reader);
        _inBounds.Read(reader);
        _outBounds.Read(reader);
        _unnamed3.Read(reader);
        _tintColorLowerBound.Read(reader);
        _tintColorUpperBound.Read(reader);
        _periodicFunction.Read(reader);
        _unnamed4.Read(reader);
        _functionPeriod.Read(reader);
        _functionPhase.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _destinationType.Write(bw);
        _destination.Write(bw);
        _source.Write(bw);
        _unnamed2.Write(bw);
        _inBounds.Write(bw);
        _outBounds.Write(bw);
        _unnamed3.Write(bw);
        _tintColorLowerBound.Write(bw);
        _tintColorUpperBound.Write(bw);
        _periodicFunction.Write(bw);
        _unnamed4.Write(bw);
        _functionPeriod.Write(bw);
        _functionPhase.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GrenadeHudOverlayBlock : IBlock {
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed3;
      private Real _frameRate = new Real();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Flags _type;
      private Flags _flags;
      private Pad _unnamed4;
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public GrenadeHudOverlayBlock() {
        this._scalingFlags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed3 = new Pad(4);
        this._type = new Flags(2);
        this._flags = new Flags(4);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(40);
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
      public Real FrameRate {
        get {
          return this._frameRate;
        }
        set {
          this._frameRate = value;
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
      public Flags Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed3.Read(reader);
        _frameRate.Read(reader);
        _sequenceIndex.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed3.Write(bw);
        _frameRate.Write(bw);
        _sequenceIndex.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GrenadeHudSoundBlock : IBlock {
      private TagReference _sound = new TagReference();
      private Flags _latchedTo;
      private Real _scale = new Real();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public GrenadeHudSoundBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._latchedTo = new Flags(4);
        this._unnamed = new Pad(32);
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
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
        _latchedTo.Read(reader);
        _scale.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _latchedTo.Write(bw);
        _scale.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
  }
}
