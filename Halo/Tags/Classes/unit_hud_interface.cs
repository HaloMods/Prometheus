// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'unit_hud_interface'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class unit_hud_interface : Interfaces.Pool.Tag {
    private UnitHudInterfaceBlock unitHudInterfaceValues = new UnitHudInterfaceBlock();
    public virtual UnitHudInterfaceBlock UnitHudInterfaceValues {
      get {
        return unitHudInterfaceValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UnitHudInterfaceValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "unit_hud_interface";
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
unitHudInterfaceValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
unitHudInterfaceValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
unitHudInterfaceValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
unitHudInterfaceValues.WriteChildData(writer);
    }
    #endregion
    public class UnitHudInterfaceBlock : IBlock {
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
      private TagReference _meterBitmap = new TagReference();
      private RGBColor _colorAtMeterMinimum = new RGBColor();
      private RGBColor _colorAtMeterMaximum = new RGBColor();
      private RGBColor _flashColor = new RGBColor();
      private ARGBColor _emptyColor = new ARGBColor();
      private Flags _flags;
      private CharInteger _minumumMeterValue = new CharInteger();
      private ShortInteger _sequenceIndex3 = new ShortInteger();
      private CharInteger _alphaMultiplier = new CharInteger();
      private CharInteger _alphaBias = new CharInteger();
      private ShortInteger _valueScale = new ShortInteger();
      private Real _opacity = new Real();
      private Real _translucency = new Real();
      private ARGBColor _disabledColor3 = new ARGBColor();
      private Pad _unnamed16;
      private RGBColor _overchargeMinimumColor = new RGBColor();
      private RGBColor _overchargeMaximumColor = new RGBColor();
      private RGBColor _overchargeFlashColor = new RGBColor();
      private RGBColor _overchargeEmptyColor = new RGBColor();
      private Pad _unnamed17;
      private Point2D _anchorOffset4 = new Point2D();
      private Real _widthScale4 = new Real();
      private Real _heightScale4 = new Real();
      private Flags _scalingFlags4;
      private Pad _unnamed18;
      private Pad _unnamed19;
      private TagReference _interfaceBitmap3 = new TagReference();
      private ARGBColor _defaultColor3 = new ARGBColor();
      private ARGBColor _flashingColor3 = new ARGBColor();
      private Real _flashPeriod3 = new Real();
      private Real _flashDelay3 = new Real();
      private ShortInteger _numberOfFlashes3 = new ShortInteger();
      private Flags _flashFlags3;
      private Real _flashLength3 = new Real();
      private ARGBColor _disabledColor4 = new ARGBColor();
      private Pad _unnamed20;
      private ShortInteger _sequenceIndex4 = new ShortInteger();
      private Pad _unnamed21;
      private Block _multitexOverlay3 = new Block();
      private Pad _unnamed22;
      private Point2D _anchorOffset5 = new Point2D();
      private Real _widthScale5 = new Real();
      private Real _heightScale5 = new Real();
      private Flags _scalingFlags5;
      private Pad _unnamed23;
      private Pad _unnamed24;
      private TagReference _meterBitmap2 = new TagReference();
      private RGBColor _colorAtMeterMinimum2 = new RGBColor();
      private RGBColor _colorAtMeterMaximum2 = new RGBColor();
      private RGBColor _flashColor2 = new RGBColor();
      private ARGBColor _emptyColor2 = new ARGBColor();
      private Flags _flags2;
      private CharInteger _minumumMeterValue2 = new CharInteger();
      private ShortInteger _sequenceIndex5 = new ShortInteger();
      private CharInteger _alphaMultiplier2 = new CharInteger();
      private CharInteger _alphaBias2 = new CharInteger();
      private ShortInteger _valueScale2 = new ShortInteger();
      private Real _opacity2 = new Real();
      private Real _translucency2 = new Real();
      private ARGBColor _disabledColor5 = new ARGBColor();
      private Pad _unnamed25;
      private RGBColor _mediumHealthLeftColor = new RGBColor();
      private Real _maxColorHealthFractionCutoff = new Real();
      private Real _minColorHealthFractionCutoff = new Real();
      private Pad _unnamed26;
      private Point2D _anchorOffset6 = new Point2D();
      private Real _widthScale6 = new Real();
      private Real _heightScale6 = new Real();
      private Flags _scalingFlags6;
      private Pad _unnamed27;
      private Pad _unnamed28;
      private TagReference _interfaceBitmap4 = new TagReference();
      private ARGBColor _defaultColor4 = new ARGBColor();
      private ARGBColor _flashingColor4 = new ARGBColor();
      private Real _flashPeriod4 = new Real();
      private Real _flashDelay4 = new Real();
      private ShortInteger _numberOfFlashes4 = new ShortInteger();
      private Flags _flashFlags4;
      private Real _flashLength4 = new Real();
      private ARGBColor _disabledColor6 = new ARGBColor();
      private Pad _unnamed29;
      private ShortInteger _sequenceIndex6 = new ShortInteger();
      private Pad _unnamed30;
      private Block _multitexOverlay4 = new Block();
      private Pad _unnamed31;
      private Point2D _anchorOffset7 = new Point2D();
      private Real _widthScale7 = new Real();
      private Real _heightScale7 = new Real();
      private Flags _scalingFlags7;
      private Pad _unnamed32;
      private Pad _unnamed33;
      private TagReference _interfaceBitmap5 = new TagReference();
      private ARGBColor _defaultColor5 = new ARGBColor();
      private ARGBColor _flashingColor5 = new ARGBColor();
      private Real _flashPeriod5 = new Real();
      private Real _flashDelay5 = new Real();
      private ShortInteger _numberOfFlashes5 = new ShortInteger();
      private Flags _flashFlags5;
      private Real _flashLength5 = new Real();
      private ARGBColor _disabledColor7 = new ARGBColor();
      private Pad _unnamed34;
      private ShortInteger _sequenceIndex7 = new ShortInteger();
      private Pad _unnamed35;
      private Block _multitexOverlay5 = new Block();
      private Pad _unnamed36;
      private Pad _unnamed37;
      private Point2D _anchorOffset8 = new Point2D();
      private Real _widthScale8 = new Real();
      private Real _heightScale8 = new Real();
      private Flags _scalingFlags8;
      private Pad _unnamed38;
      private Pad _unnamed39;
      private Enum _anchor2 = new Enum();
      private Pad _unnamed40;
      private Pad _unnamed41;
      private Block _overlays = new Block();
      private Pad _unnamed42;
      private Block _sounds = new Block();
      private Block _meters = new Block();
      private Pad _unnamed43;
      private Pad _unnamed44;
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlayList = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlay2List = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlay3List = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlay4List = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlay5List = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
      public BlockCollection<UnitHudAuxilaryOverlayBlock> _overlaysList = new BlockCollection<UnitHudAuxilaryOverlayBlock>();
      public BlockCollection<UnitHudSoundBlock> _soundsList = new BlockCollection<UnitHudSoundBlock>();
      public BlockCollection<UnitHudAuxilaryPanelBlock> _metersList = new BlockCollection<UnitHudAuxilaryPanelBlock>();
public event System.EventHandler BlockNameChanged;
      public UnitHudInterfaceBlock() {
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
        this._flags = new Flags(1);
        this._unnamed16 = new Pad(16);
        this._unnamed17 = new Pad(16);
        this._scalingFlags4 = new Flags(2);
        this._unnamed18 = new Pad(2);
        this._unnamed19 = new Pad(20);
        this._flashFlags3 = new Flags(2);
        this._unnamed20 = new Pad(4);
        this._unnamed21 = new Pad(2);
        this._unnamed22 = new Pad(4);
        this._scalingFlags5 = new Flags(2);
        this._unnamed23 = new Pad(2);
        this._unnamed24 = new Pad(20);
        this._flags2 = new Flags(1);
        this._unnamed25 = new Pad(16);
        this._unnamed26 = new Pad(20);
        this._scalingFlags6 = new Flags(2);
        this._unnamed27 = new Pad(2);
        this._unnamed28 = new Pad(20);
        this._flashFlags4 = new Flags(2);
        this._unnamed29 = new Pad(4);
        this._unnamed30 = new Pad(2);
        this._unnamed31 = new Pad(4);
        this._scalingFlags7 = new Flags(2);
        this._unnamed32 = new Pad(2);
        this._unnamed33 = new Pad(20);
        this._flashFlags5 = new Flags(2);
        this._unnamed34 = new Pad(4);
        this._unnamed35 = new Pad(2);
        this._unnamed36 = new Pad(4);
        this._unnamed37 = new Pad(32);
        this._scalingFlags8 = new Flags(2);
        this._unnamed38 = new Pad(2);
        this._unnamed39 = new Pad(20);
        this._unnamed40 = new Pad(2);
        this._unnamed41 = new Pad(32);
        this._unnamed42 = new Pad(16);
        this._unnamed43 = new Pad(356);
        this._unnamed44 = new Pad(48);
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
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay3 {
        get {
          return this._multitexOverlay3List;
        }
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay4 {
        get {
          return this._multitexOverlay4List;
        }
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay5 {
        get {
          return this._multitexOverlay5List;
        }
      }
      public BlockCollection<UnitHudAuxilaryOverlayBlock> Overlays {
        get {
          return this._overlaysList;
        }
      }
      public BlockCollection<UnitHudSoundBlock> Sounds {
        get {
          return this._soundsList;
        }
      }
      public BlockCollection<UnitHudAuxilaryPanelBlock> Meters {
        get {
          return this._metersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_interfaceBitmap.Value);
references.Add(_interfaceBitmap2.Value);
references.Add(_meterBitmap.Value);
references.Add(_interfaceBitmap3.Value);
references.Add(_meterBitmap2.Value);
references.Add(_interfaceBitmap4.Value);
references.Add(_interfaceBitmap5.Value);
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
for (int x=0; x<MultitexOverlay3.BlockCount; x++)
{
  IBlock block = MultitexOverlay3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultitexOverlay4.BlockCount; x++)
{
  IBlock block = MultitexOverlay4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultitexOverlay5.BlockCount; x++)
{
  IBlock block = MultitexOverlay5.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Overlays.BlockCount; x++)
{
  IBlock block = Overlays.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sounds.BlockCount; x++)
{
  IBlock block = Sounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Meters.BlockCount; x++)
{
  IBlock block = Meters.GetBlock(x);
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
      public TagReference MeterBitmap {
        get {
          return this._meterBitmap;
        }
        set {
          this._meterBitmap = value;
        }
      }
      public RGBColor ColorAtMeterMinimum {
        get {
          return this._colorAtMeterMinimum;
        }
        set {
          this._colorAtMeterMinimum = value;
        }
      }
      public RGBColor ColorAtMeterMaximum {
        get {
          return this._colorAtMeterMaximum;
        }
        set {
          this._colorAtMeterMaximum = value;
        }
      }
      public RGBColor FlashColor {
        get {
          return this._flashColor;
        }
        set {
          this._flashColor = value;
        }
      }
      public ARGBColor EmptyColor {
        get {
          return this._emptyColor;
        }
        set {
          this._emptyColor = value;
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
      public CharInteger MinumumMeterValue {
        get {
          return this._minumumMeterValue;
        }
        set {
          this._minumumMeterValue = value;
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
      public CharInteger AlphaMultiplier {
        get {
          return this._alphaMultiplier;
        }
        set {
          this._alphaMultiplier = value;
        }
      }
      public CharInteger AlphaBias {
        get {
          return this._alphaBias;
        }
        set {
          this._alphaBias = value;
        }
      }
      public ShortInteger ValueScale {
        get {
          return this._valueScale;
        }
        set {
          this._valueScale = value;
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
      public ARGBColor DisabledColor3 {
        get {
          return this._disabledColor3;
        }
        set {
          this._disabledColor3 = value;
        }
      }
      public RGBColor OverchargeMinimumColor {
        get {
          return this._overchargeMinimumColor;
        }
        set {
          this._overchargeMinimumColor = value;
        }
      }
      public RGBColor OverchargeMaximumColor {
        get {
          return this._overchargeMaximumColor;
        }
        set {
          this._overchargeMaximumColor = value;
        }
      }
      public RGBColor OverchargeFlashColor {
        get {
          return this._overchargeFlashColor;
        }
        set {
          this._overchargeFlashColor = value;
        }
      }
      public RGBColor OverchargeEmptyColor {
        get {
          return this._overchargeEmptyColor;
        }
        set {
          this._overchargeEmptyColor = value;
        }
      }
      public Point2D AnchorOffset4 {
        get {
          return this._anchorOffset4;
        }
        set {
          this._anchorOffset4 = value;
        }
      }
      public Real WidthScale4 {
        get {
          return this._widthScale4;
        }
        set {
          this._widthScale4 = value;
        }
      }
      public Real HeightScale4 {
        get {
          return this._heightScale4;
        }
        set {
          this._heightScale4 = value;
        }
      }
      public Flags ScalingFlags4 {
        get {
          return this._scalingFlags4;
        }
        set {
          this._scalingFlags4 = value;
        }
      }
      public TagReference InterfaceBitmap3 {
        get {
          return this._interfaceBitmap3;
        }
        set {
          this._interfaceBitmap3 = value;
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
      public ARGBColor DisabledColor4 {
        get {
          return this._disabledColor4;
        }
        set {
          this._disabledColor4 = value;
        }
      }
      public ShortInteger SequenceIndex4 {
        get {
          return this._sequenceIndex4;
        }
        set {
          this._sequenceIndex4 = value;
        }
      }
      public Point2D AnchorOffset5 {
        get {
          return this._anchorOffset5;
        }
        set {
          this._anchorOffset5 = value;
        }
      }
      public Real WidthScale5 {
        get {
          return this._widthScale5;
        }
        set {
          this._widthScale5 = value;
        }
      }
      public Real HeightScale5 {
        get {
          return this._heightScale5;
        }
        set {
          this._heightScale5 = value;
        }
      }
      public Flags ScalingFlags5 {
        get {
          return this._scalingFlags5;
        }
        set {
          this._scalingFlags5 = value;
        }
      }
      public TagReference MeterBitmap2 {
        get {
          return this._meterBitmap2;
        }
        set {
          this._meterBitmap2 = value;
        }
      }
      public RGBColor ColorAtMeterMinimum2 {
        get {
          return this._colorAtMeterMinimum2;
        }
        set {
          this._colorAtMeterMinimum2 = value;
        }
      }
      public RGBColor ColorAtMeterMaximum2 {
        get {
          return this._colorAtMeterMaximum2;
        }
        set {
          this._colorAtMeterMaximum2 = value;
        }
      }
      public RGBColor FlashColor2 {
        get {
          return this._flashColor2;
        }
        set {
          this._flashColor2 = value;
        }
      }
      public ARGBColor EmptyColor2 {
        get {
          return this._emptyColor2;
        }
        set {
          this._emptyColor2 = value;
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
      public CharInteger MinumumMeterValue2 {
        get {
          return this._minumumMeterValue2;
        }
        set {
          this._minumumMeterValue2 = value;
        }
      }
      public ShortInteger SequenceIndex5 {
        get {
          return this._sequenceIndex5;
        }
        set {
          this._sequenceIndex5 = value;
        }
      }
      public CharInteger AlphaMultiplier2 {
        get {
          return this._alphaMultiplier2;
        }
        set {
          this._alphaMultiplier2 = value;
        }
      }
      public CharInteger AlphaBias2 {
        get {
          return this._alphaBias2;
        }
        set {
          this._alphaBias2 = value;
        }
      }
      public ShortInteger ValueScale2 {
        get {
          return this._valueScale2;
        }
        set {
          this._valueScale2 = value;
        }
      }
      public Real Opacity2 {
        get {
          return this._opacity2;
        }
        set {
          this._opacity2 = value;
        }
      }
      public Real Translucency2 {
        get {
          return this._translucency2;
        }
        set {
          this._translucency2 = value;
        }
      }
      public ARGBColor DisabledColor5 {
        get {
          return this._disabledColor5;
        }
        set {
          this._disabledColor5 = value;
        }
      }
      public RGBColor MediumHealthLeftColor {
        get {
          return this._mediumHealthLeftColor;
        }
        set {
          this._mediumHealthLeftColor = value;
        }
      }
      public Real MaxColorHealthFractionCutoff {
        get {
          return this._maxColorHealthFractionCutoff;
        }
        set {
          this._maxColorHealthFractionCutoff = value;
        }
      }
      public Real MinColorHealthFractionCutoff {
        get {
          return this._minColorHealthFractionCutoff;
        }
        set {
          this._minColorHealthFractionCutoff = value;
        }
      }
      public Point2D AnchorOffset6 {
        get {
          return this._anchorOffset6;
        }
        set {
          this._anchorOffset6 = value;
        }
      }
      public Real WidthScale6 {
        get {
          return this._widthScale6;
        }
        set {
          this._widthScale6 = value;
        }
      }
      public Real HeightScale6 {
        get {
          return this._heightScale6;
        }
        set {
          this._heightScale6 = value;
        }
      }
      public Flags ScalingFlags6 {
        get {
          return this._scalingFlags6;
        }
        set {
          this._scalingFlags6 = value;
        }
      }
      public TagReference InterfaceBitmap4 {
        get {
          return this._interfaceBitmap4;
        }
        set {
          this._interfaceBitmap4 = value;
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
      public ARGBColor DisabledColor6 {
        get {
          return this._disabledColor6;
        }
        set {
          this._disabledColor6 = value;
        }
      }
      public ShortInteger SequenceIndex6 {
        get {
          return this._sequenceIndex6;
        }
        set {
          this._sequenceIndex6 = value;
        }
      }
      public Point2D AnchorOffset7 {
        get {
          return this._anchorOffset7;
        }
        set {
          this._anchorOffset7 = value;
        }
      }
      public Real WidthScale7 {
        get {
          return this._widthScale7;
        }
        set {
          this._widthScale7 = value;
        }
      }
      public Real HeightScale7 {
        get {
          return this._heightScale7;
        }
        set {
          this._heightScale7 = value;
        }
      }
      public Flags ScalingFlags7 {
        get {
          return this._scalingFlags7;
        }
        set {
          this._scalingFlags7 = value;
        }
      }
      public TagReference InterfaceBitmap5 {
        get {
          return this._interfaceBitmap5;
        }
        set {
          this._interfaceBitmap5 = value;
        }
      }
      public ARGBColor DefaultColor5 {
        get {
          return this._defaultColor5;
        }
        set {
          this._defaultColor5 = value;
        }
      }
      public ARGBColor FlashingColor5 {
        get {
          return this._flashingColor5;
        }
        set {
          this._flashingColor5 = value;
        }
      }
      public Real FlashPeriod5 {
        get {
          return this._flashPeriod5;
        }
        set {
          this._flashPeriod5 = value;
        }
      }
      public Real FlashDelay5 {
        get {
          return this._flashDelay5;
        }
        set {
          this._flashDelay5 = value;
        }
      }
      public ShortInteger NumberOfFlashes5 {
        get {
          return this._numberOfFlashes5;
        }
        set {
          this._numberOfFlashes5 = value;
        }
      }
      public Flags FlashFlags5 {
        get {
          return this._flashFlags5;
        }
        set {
          this._flashFlags5 = value;
        }
      }
      public Real FlashLength5 {
        get {
          return this._flashLength5;
        }
        set {
          this._flashLength5 = value;
        }
      }
      public ARGBColor DisabledColor7 {
        get {
          return this._disabledColor7;
        }
        set {
          this._disabledColor7 = value;
        }
      }
      public ShortInteger SequenceIndex7 {
        get {
          return this._sequenceIndex7;
        }
        set {
          this._sequenceIndex7 = value;
        }
      }
      public Point2D AnchorOffset8 {
        get {
          return this._anchorOffset8;
        }
        set {
          this._anchorOffset8 = value;
        }
      }
      public Real WidthScale8 {
        get {
          return this._widthScale8;
        }
        set {
          this._widthScale8 = value;
        }
      }
      public Real HeightScale8 {
        get {
          return this._heightScale8;
        }
        set {
          this._heightScale8 = value;
        }
      }
      public Flags ScalingFlags8 {
        get {
          return this._scalingFlags8;
        }
        set {
          this._scalingFlags8 = value;
        }
      }
      public Enum Anchor2 {
        get {
          return this._anchor2;
        }
        set {
          this._anchor2 = value;
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
        _meterBitmap.Read(reader);
        _colorAtMeterMinimum.Read(reader);
        _colorAtMeterMaximum.Read(reader);
        _flashColor.Read(reader);
        _emptyColor.Read(reader);
        _flags.Read(reader);
        _minumumMeterValue.Read(reader);
        _sequenceIndex3.Read(reader);
        _alphaMultiplier.Read(reader);
        _alphaBias.Read(reader);
        _valueScale.Read(reader);
        _opacity.Read(reader);
        _translucency.Read(reader);
        _disabledColor3.Read(reader);
        _unnamed16.Read(reader);
        _overchargeMinimumColor.Read(reader);
        _overchargeMaximumColor.Read(reader);
        _overchargeFlashColor.Read(reader);
        _overchargeEmptyColor.Read(reader);
        _unnamed17.Read(reader);
        _anchorOffset4.Read(reader);
        _widthScale4.Read(reader);
        _heightScale4.Read(reader);
        _scalingFlags4.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _interfaceBitmap3.Read(reader);
        _defaultColor3.Read(reader);
        _flashingColor3.Read(reader);
        _flashPeriod3.Read(reader);
        _flashDelay3.Read(reader);
        _numberOfFlashes3.Read(reader);
        _flashFlags3.Read(reader);
        _flashLength3.Read(reader);
        _disabledColor4.Read(reader);
        _unnamed20.Read(reader);
        _sequenceIndex4.Read(reader);
        _unnamed21.Read(reader);
        _multitexOverlay3.Read(reader);
        _unnamed22.Read(reader);
        _anchorOffset5.Read(reader);
        _widthScale5.Read(reader);
        _heightScale5.Read(reader);
        _scalingFlags5.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _meterBitmap2.Read(reader);
        _colorAtMeterMinimum2.Read(reader);
        _colorAtMeterMaximum2.Read(reader);
        _flashColor2.Read(reader);
        _emptyColor2.Read(reader);
        _flags2.Read(reader);
        _minumumMeterValue2.Read(reader);
        _sequenceIndex5.Read(reader);
        _alphaMultiplier2.Read(reader);
        _alphaBias2.Read(reader);
        _valueScale2.Read(reader);
        _opacity2.Read(reader);
        _translucency2.Read(reader);
        _disabledColor5.Read(reader);
        _unnamed25.Read(reader);
        _mediumHealthLeftColor.Read(reader);
        _maxColorHealthFractionCutoff.Read(reader);
        _minColorHealthFractionCutoff.Read(reader);
        _unnamed26.Read(reader);
        _anchorOffset6.Read(reader);
        _widthScale6.Read(reader);
        _heightScale6.Read(reader);
        _scalingFlags6.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
        _interfaceBitmap4.Read(reader);
        _defaultColor4.Read(reader);
        _flashingColor4.Read(reader);
        _flashPeriod4.Read(reader);
        _flashDelay4.Read(reader);
        _numberOfFlashes4.Read(reader);
        _flashFlags4.Read(reader);
        _flashLength4.Read(reader);
        _disabledColor6.Read(reader);
        _unnamed29.Read(reader);
        _sequenceIndex6.Read(reader);
        _unnamed30.Read(reader);
        _multitexOverlay4.Read(reader);
        _unnamed31.Read(reader);
        _anchorOffset7.Read(reader);
        _widthScale7.Read(reader);
        _heightScale7.Read(reader);
        _scalingFlags7.Read(reader);
        _unnamed32.Read(reader);
        _unnamed33.Read(reader);
        _interfaceBitmap5.Read(reader);
        _defaultColor5.Read(reader);
        _flashingColor5.Read(reader);
        _flashPeriod5.Read(reader);
        _flashDelay5.Read(reader);
        _numberOfFlashes5.Read(reader);
        _flashFlags5.Read(reader);
        _flashLength5.Read(reader);
        _disabledColor7.Read(reader);
        _unnamed34.Read(reader);
        _sequenceIndex7.Read(reader);
        _unnamed35.Read(reader);
        _multitexOverlay5.Read(reader);
        _unnamed36.Read(reader);
        _unnamed37.Read(reader);
        _anchorOffset8.Read(reader);
        _widthScale8.Read(reader);
        _heightScale8.Read(reader);
        _scalingFlags8.Read(reader);
        _unnamed38.Read(reader);
        _unnamed39.Read(reader);
        _anchor2.Read(reader);
        _unnamed40.Read(reader);
        _unnamed41.Read(reader);
        _overlays.Read(reader);
        _unnamed42.Read(reader);
        _sounds.Read(reader);
        _meters.Read(reader);
        _unnamed43.Read(reader);
        _unnamed44.Read(reader);
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
        _meterBitmap.ReadString(reader);
        _interfaceBitmap3.ReadString(reader);
        for (x = 0; (x < _multitexOverlay3.Count); x = (x + 1)) {
          MultitexOverlay3.Add(new GlobalHudMultitextureOverlayDefinitionBlock());
          MultitexOverlay3[x].Read(reader);
        }
        for (x = 0; (x < _multitexOverlay3.Count); x = (x + 1)) {
          MultitexOverlay3[x].ReadChildData(reader);
        }
        _meterBitmap2.ReadString(reader);
        _interfaceBitmap4.ReadString(reader);
        for (x = 0; (x < _multitexOverlay4.Count); x = (x + 1)) {
          MultitexOverlay4.Add(new GlobalHudMultitextureOverlayDefinitionBlock());
          MultitexOverlay4[x].Read(reader);
        }
        for (x = 0; (x < _multitexOverlay4.Count); x = (x + 1)) {
          MultitexOverlay4[x].ReadChildData(reader);
        }
        _interfaceBitmap5.ReadString(reader);
        for (x = 0; (x < _multitexOverlay5.Count); x = (x + 1)) {
          MultitexOverlay5.Add(new GlobalHudMultitextureOverlayDefinitionBlock());
          MultitexOverlay5[x].Read(reader);
        }
        for (x = 0; (x < _multitexOverlay5.Count); x = (x + 1)) {
          MultitexOverlay5[x].ReadChildData(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays.Add(new UnitHudAuxilaryOverlayBlock());
          Overlays[x].Read(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds.Add(new UnitHudSoundBlock());
          Sounds[x].Read(reader);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _meters.Count); x = (x + 1)) {
          Meters.Add(new UnitHudAuxilaryPanelBlock());
          Meters[x].Read(reader);
        }
        for (x = 0; (x < _meters.Count); x = (x + 1)) {
          Meters[x].ReadChildData(reader);
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
        _meterBitmap.Write(bw);
        _colorAtMeterMinimum.Write(bw);
        _colorAtMeterMaximum.Write(bw);
        _flashColor.Write(bw);
        _emptyColor.Write(bw);
        _flags.Write(bw);
        _minumumMeterValue.Write(bw);
        _sequenceIndex3.Write(bw);
        _alphaMultiplier.Write(bw);
        _alphaBias.Write(bw);
        _valueScale.Write(bw);
        _opacity.Write(bw);
        _translucency.Write(bw);
        _disabledColor3.Write(bw);
        _unnamed16.Write(bw);
        _overchargeMinimumColor.Write(bw);
        _overchargeMaximumColor.Write(bw);
        _overchargeFlashColor.Write(bw);
        _overchargeEmptyColor.Write(bw);
        _unnamed17.Write(bw);
        _anchorOffset4.Write(bw);
        _widthScale4.Write(bw);
        _heightScale4.Write(bw);
        _scalingFlags4.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _interfaceBitmap3.Write(bw);
        _defaultColor3.Write(bw);
        _flashingColor3.Write(bw);
        _flashPeriod3.Write(bw);
        _flashDelay3.Write(bw);
        _numberOfFlashes3.Write(bw);
        _flashFlags3.Write(bw);
        _flashLength3.Write(bw);
        _disabledColor4.Write(bw);
        _unnamed20.Write(bw);
        _sequenceIndex4.Write(bw);
        _unnamed21.Write(bw);
_multitexOverlay3.Count = MultitexOverlay3.Count;
        _multitexOverlay3.Write(bw);
        _unnamed22.Write(bw);
        _anchorOffset5.Write(bw);
        _widthScale5.Write(bw);
        _heightScale5.Write(bw);
        _scalingFlags5.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _meterBitmap2.Write(bw);
        _colorAtMeterMinimum2.Write(bw);
        _colorAtMeterMaximum2.Write(bw);
        _flashColor2.Write(bw);
        _emptyColor2.Write(bw);
        _flags2.Write(bw);
        _minumumMeterValue2.Write(bw);
        _sequenceIndex5.Write(bw);
        _alphaMultiplier2.Write(bw);
        _alphaBias2.Write(bw);
        _valueScale2.Write(bw);
        _opacity2.Write(bw);
        _translucency2.Write(bw);
        _disabledColor5.Write(bw);
        _unnamed25.Write(bw);
        _mediumHealthLeftColor.Write(bw);
        _maxColorHealthFractionCutoff.Write(bw);
        _minColorHealthFractionCutoff.Write(bw);
        _unnamed26.Write(bw);
        _anchorOffset6.Write(bw);
        _widthScale6.Write(bw);
        _heightScale6.Write(bw);
        _scalingFlags6.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
        _interfaceBitmap4.Write(bw);
        _defaultColor4.Write(bw);
        _flashingColor4.Write(bw);
        _flashPeriod4.Write(bw);
        _flashDelay4.Write(bw);
        _numberOfFlashes4.Write(bw);
        _flashFlags4.Write(bw);
        _flashLength4.Write(bw);
        _disabledColor6.Write(bw);
        _unnamed29.Write(bw);
        _sequenceIndex6.Write(bw);
        _unnamed30.Write(bw);
_multitexOverlay4.Count = MultitexOverlay4.Count;
        _multitexOverlay4.Write(bw);
        _unnamed31.Write(bw);
        _anchorOffset7.Write(bw);
        _widthScale7.Write(bw);
        _heightScale7.Write(bw);
        _scalingFlags7.Write(bw);
        _unnamed32.Write(bw);
        _unnamed33.Write(bw);
        _interfaceBitmap5.Write(bw);
        _defaultColor5.Write(bw);
        _flashingColor5.Write(bw);
        _flashPeriod5.Write(bw);
        _flashDelay5.Write(bw);
        _numberOfFlashes5.Write(bw);
        _flashFlags5.Write(bw);
        _flashLength5.Write(bw);
        _disabledColor7.Write(bw);
        _unnamed34.Write(bw);
        _sequenceIndex7.Write(bw);
        _unnamed35.Write(bw);
_multitexOverlay5.Count = MultitexOverlay5.Count;
        _multitexOverlay5.Write(bw);
        _unnamed36.Write(bw);
        _unnamed37.Write(bw);
        _anchorOffset8.Write(bw);
        _widthScale8.Write(bw);
        _heightScale8.Write(bw);
        _scalingFlags8.Write(bw);
        _unnamed38.Write(bw);
        _unnamed39.Write(bw);
        _anchor2.Write(bw);
        _unnamed40.Write(bw);
        _unnamed41.Write(bw);
_overlays.Count = Overlays.Count;
        _overlays.Write(bw);
        _unnamed42.Write(bw);
_sounds.Count = Sounds.Count;
        _sounds.Write(bw);
_meters.Count = Meters.Count;
        _meters.Write(bw);
        _unnamed43.Write(bw);
        _unnamed44.Write(bw);
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
        _meterBitmap.WriteString(writer);
        _interfaceBitmap3.WriteString(writer);
        for (x = 0; (x < _multitexOverlay3.Count); x = (x + 1)) {
          MultitexOverlay3[x].Write(writer);
        }
        for (x = 0; (x < _multitexOverlay3.Count); x = (x + 1)) {
          MultitexOverlay3[x].WriteChildData(writer);
        }
        _meterBitmap2.WriteString(writer);
        _interfaceBitmap4.WriteString(writer);
        for (x = 0; (x < _multitexOverlay4.Count); x = (x + 1)) {
          MultitexOverlay4[x].Write(writer);
        }
        for (x = 0; (x < _multitexOverlay4.Count); x = (x + 1)) {
          MultitexOverlay4[x].WriteChildData(writer);
        }
        _interfaceBitmap5.WriteString(writer);
        for (x = 0; (x < _multitexOverlay5.Count); x = (x + 1)) {
          MultitexOverlay5[x].Write(writer);
        }
        for (x = 0; (x < _multitexOverlay5.Count); x = (x + 1)) {
          MultitexOverlay5[x].WriteChildData(writer);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].Write(writer);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].Write(writer);
        }
        for (x = 0; (x < _sounds.Count); x = (x + 1)) {
          Sounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _meters.Count); x = (x + 1)) {
          Meters[x].Write(writer);
        }
        for (x = 0; (x < _meters.Count); x = (x + 1)) {
          Meters[x].WriteChildData(writer);
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
    public class UnitHudAuxilaryOverlayBlock : IBlock {
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private TagReference _interfaceBitmap = new TagReference();
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed3;
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Pad _unnamed4;
      private Block _multitexOverlay = new Block();
      private Pad _unnamed5;
      private Enum _type = new Enum();
      private Flags _flags;
      private Pad _unnamed6;
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlayList = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
public event System.EventHandler BlockNameChanged;
      public UnitHudAuxilaryOverlayBlock() {
        this._scalingFlags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._flags = new Flags(2);
        this._unnamed6 = new Pad(24);
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay {
        get {
          return this._multitexOverlayList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_interfaceBitmap.Value);
for (int x=0; x<MultitexOverlay.BlockCount; x++)
{
  IBlock block = MultitexOverlay.GetBlock(x);
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
      public Enum Type {
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
        _interfaceBitmap.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed3.Read(reader);
        _sequenceIndex.Read(reader);
        _unnamed4.Read(reader);
        _multitexOverlay.Read(reader);
        _unnamed5.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _unnamed6.Read(reader);
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
      }
      public virtual void Write(BinaryWriter bw) {
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _interfaceBitmap.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed3.Write(bw);
        _sequenceIndex.Write(bw);
        _unnamed4.Write(bw);
_multitexOverlay.Count = MultitexOverlay.Count;
        _multitexOverlay.Write(bw);
        _unnamed5.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _unnamed6.Write(bw);
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
      }
    }
    public class UnitHudSoundBlock : IBlock {
      private TagReference _sound = new TagReference();
      private Flags _latchedTo;
      private Real _scale = new Real();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public UnitHudSoundBlock() {
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
    public class UnitHudAuxilaryPanelBlock : IBlock {
      private Enum _type = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private TagReference _interfaceBitmap = new TagReference();
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed5;
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Pad _unnamed6;
      private Block _multitexOverlay = new Block();
      private Pad _unnamed7;
      private Point2D _anchorOffset2 = new Point2D();
      private Real _widthScale2 = new Real();
      private Real _heightScale2 = new Real();
      private Flags _scalingFlags2;
      private Pad _unnamed8;
      private Pad _unnamed9;
      private TagReference _meterBitmap = new TagReference();
      private RGBColor _colorAtMeterMinimum = new RGBColor();
      private RGBColor _colorAtMeterMaximum = new RGBColor();
      private RGBColor _flashColor = new RGBColor();
      private ARGBColor _emptyColor = new ARGBColor();
      private Flags _flags;
      private CharInteger _minumumMeterValue = new CharInteger();
      private ShortInteger _sequenceIndex2 = new ShortInteger();
      private CharInteger _alphaMultiplier = new CharInteger();
      private CharInteger _alphaBias = new CharInteger();
      private ShortInteger _valueScale = new ShortInteger();
      private Real _opacity = new Real();
      private Real _translucency = new Real();
      private ARGBColor _disabledColor2 = new ARGBColor();
      private Pad _unnamed10;
      private Real _minimumFractionCutoff = new Real();
      private Flags _flags2;
      private Pad _unnamed11;
      private Pad _unnamed12;
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlayList = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
public event System.EventHandler BlockNameChanged;
      public UnitHudAuxilaryPanelBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
        this._scalingFlags = new Flags(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(4);
        this._scalingFlags2 = new Flags(2);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(20);
        this._flags = new Flags(1);
        this._unnamed10 = new Pad(16);
        this._flags2 = new Flags(4);
        this._unnamed11 = new Pad(24);
        this._unnamed12 = new Pad(64);
      }
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> MultitexOverlay {
        get {
          return this._multitexOverlayList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_interfaceBitmap.Value);
references.Add(_meterBitmap.Value);
for (int x=0; x<MultitexOverlay.BlockCount; x++)
{
  IBlock block = MultitexOverlay.GetBlock(x);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public TagReference MeterBitmap {
        get {
          return this._meterBitmap;
        }
        set {
          this._meterBitmap = value;
        }
      }
      public RGBColor ColorAtMeterMinimum {
        get {
          return this._colorAtMeterMinimum;
        }
        set {
          this._colorAtMeterMinimum = value;
        }
      }
      public RGBColor ColorAtMeterMaximum {
        get {
          return this._colorAtMeterMaximum;
        }
        set {
          this._colorAtMeterMaximum = value;
        }
      }
      public RGBColor FlashColor {
        get {
          return this._flashColor;
        }
        set {
          this._flashColor = value;
        }
      }
      public ARGBColor EmptyColor {
        get {
          return this._emptyColor;
        }
        set {
          this._emptyColor = value;
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
      public CharInteger MinumumMeterValue {
        get {
          return this._minumumMeterValue;
        }
        set {
          this._minumumMeterValue = value;
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
      public CharInteger AlphaMultiplier {
        get {
          return this._alphaMultiplier;
        }
        set {
          this._alphaMultiplier = value;
        }
      }
      public CharInteger AlphaBias {
        get {
          return this._alphaBias;
        }
        set {
          this._alphaBias = value;
        }
      }
      public ShortInteger ValueScale {
        get {
          return this._valueScale;
        }
        set {
          this._valueScale = value;
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
      public ARGBColor DisabledColor2 {
        get {
          return this._disabledColor2;
        }
        set {
          this._disabledColor2 = value;
        }
      }
      public Real MinimumFractionCutoff {
        get {
          return this._minimumFractionCutoff;
        }
        set {
          this._minimumFractionCutoff = value;
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _interfaceBitmap.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed5.Read(reader);
        _sequenceIndex.Read(reader);
        _unnamed6.Read(reader);
        _multitexOverlay.Read(reader);
        _unnamed7.Read(reader);
        _anchorOffset2.Read(reader);
        _widthScale2.Read(reader);
        _heightScale2.Read(reader);
        _scalingFlags2.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _meterBitmap.Read(reader);
        _colorAtMeterMinimum.Read(reader);
        _colorAtMeterMaximum.Read(reader);
        _flashColor.Read(reader);
        _emptyColor.Read(reader);
        _flags.Read(reader);
        _minumumMeterValue.Read(reader);
        _sequenceIndex2.Read(reader);
        _alphaMultiplier.Read(reader);
        _alphaBias.Read(reader);
        _valueScale.Read(reader);
        _opacity.Read(reader);
        _translucency.Read(reader);
        _disabledColor2.Read(reader);
        _unnamed10.Read(reader);
        _minimumFractionCutoff.Read(reader);
        _flags2.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
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
        _meterBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _interfaceBitmap.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed5.Write(bw);
        _sequenceIndex.Write(bw);
        _unnamed6.Write(bw);
_multitexOverlay.Count = MultitexOverlay.Count;
        _multitexOverlay.Write(bw);
        _unnamed7.Write(bw);
        _anchorOffset2.Write(bw);
        _widthScale2.Write(bw);
        _heightScale2.Write(bw);
        _scalingFlags2.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _meterBitmap.Write(bw);
        _colorAtMeterMinimum.Write(bw);
        _colorAtMeterMaximum.Write(bw);
        _flashColor.Write(bw);
        _emptyColor.Write(bw);
        _flags.Write(bw);
        _minumumMeterValue.Write(bw);
        _sequenceIndex2.Write(bw);
        _alphaMultiplier.Write(bw);
        _alphaBias.Write(bw);
        _valueScale.Write(bw);
        _opacity.Write(bw);
        _translucency.Write(bw);
        _disabledColor2.Write(bw);
        _unnamed10.Write(bw);
        _minimumFractionCutoff.Write(bw);
        _flags2.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
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
        _meterBitmap.WriteString(writer);
      }
    }
  }
}
