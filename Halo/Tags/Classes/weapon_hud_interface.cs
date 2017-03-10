// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'weapon_hud_interface'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class weapon_hud_interface : Interfaces.Pool.Tag {
    private WeaponHudInterfaceBlock weaponHudInterfaceValues = new WeaponHudInterfaceBlock();
    public virtual WeaponHudInterfaceBlock WeaponHudInterfaceValues {
      get {
        return weaponHudInterfaceValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(WeaponHudInterfaceValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "weapon_hud_interface";
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
weaponHudInterfaceValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
weaponHudInterfaceValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
weaponHudInterfaceValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
weaponHudInterfaceValues.WriteChildData(writer);
    }
    #endregion
    public class WeaponHudInterfaceBlock : IBlock {
      private TagReference _childHud = new TagReference();
      private Flags _flags;
      private Pad _unnamed;
      private ShortInteger _totalAmmoCutoff = new ShortInteger();
      private ShortInteger _loadedAmmoCutoff = new ShortInteger();
      private ShortInteger _heatCutoff = new ShortInteger();
      private ShortInteger _ageCutoff = new ShortInteger();
      private Pad _unnamed2;
      private Enum _anchor = new Enum();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Block _staticElements = new Block();
      private Block _meterElements = new Block();
      private Block _numberElements = new Block();
      private Block _crosshairs = new Block();
      private Block _overlayElements = new Block();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Block _screenEffect = new Block();
      private Pad _unnamed7;
      private ShortInteger _sequenceIndex = new ShortInteger();
      private ShortInteger _widthOffset = new ShortInteger();
      private Point2D _offsetFromReferenceCorner = new Point2D();
      private ARGBColor _overrideIconColor = new ARGBColor();
      private CharInteger _frameRate = new CharInteger();
      private Flags _flags2;
      private ShortInteger _textIndex = new ShortInteger();
      private Pad _unnamed8;
      public BlockCollection<WeaponHudStaticBlock> _staticElementsList = new BlockCollection<WeaponHudStaticBlock>();
      public BlockCollection<WeaponHudMeterBlock> _meterElementsList = new BlockCollection<WeaponHudMeterBlock>();
      public BlockCollection<WeaponHudNumberBlock> _numberElementsList = new BlockCollection<WeaponHudNumberBlock>();
      public BlockCollection<WeaponHudCrosshairBlock> _crosshairsList = new BlockCollection<WeaponHudCrosshairBlock>();
      public BlockCollection<WeaponHudOverlaysBlock> _overlayElementsList = new BlockCollection<WeaponHudOverlaysBlock>();
      public BlockCollection<GlobalHudScreenEffectDefinitionBlock> _screenEffectList = new BlockCollection<GlobalHudScreenEffectDefinitionBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponHudInterfaceBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(32);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(12);
        this._unnamed7 = new Pad(132);
        this._flags2 = new Flags(1);
        this._unnamed8 = new Pad(48);
      }
      public BlockCollection<WeaponHudStaticBlock> StaticElements {
        get {
          return this._staticElementsList;
        }
      }
      public BlockCollection<WeaponHudMeterBlock> MeterElements {
        get {
          return this._meterElementsList;
        }
      }
      public BlockCollection<WeaponHudNumberBlock> NumberElements {
        get {
          return this._numberElementsList;
        }
      }
      public BlockCollection<WeaponHudCrosshairBlock> Crosshairs {
        get {
          return this._crosshairsList;
        }
      }
      public BlockCollection<WeaponHudOverlaysBlock> OverlayElements {
        get {
          return this._overlayElementsList;
        }
      }
      public BlockCollection<GlobalHudScreenEffectDefinitionBlock> ScreenEffect {
        get {
          return this._screenEffectList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_childHud.Value);
for (int x=0; x<StaticElements.BlockCount; x++)
{
  IBlock block = StaticElements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MeterElements.BlockCount; x++)
{
  IBlock block = MeterElements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NumberElements.BlockCount; x++)
{
  IBlock block = NumberElements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Crosshairs.BlockCount; x++)
{
  IBlock block = Crosshairs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OverlayElements.BlockCount; x++)
{
  IBlock block = OverlayElements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScreenEffect.BlockCount; x++)
{
  IBlock block = ScreenEffect.GetBlock(x);
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
      public TagReference ChildHud {
        get {
          return this._childHud;
        }
        set {
          this._childHud = value;
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
      public ShortInteger TotalAmmoCutoff {
        get {
          return this._totalAmmoCutoff;
        }
        set {
          this._totalAmmoCutoff = value;
        }
      }
      public ShortInteger LoadedAmmoCutoff {
        get {
          return this._loadedAmmoCutoff;
        }
        set {
          this._loadedAmmoCutoff = value;
        }
      }
      public ShortInteger HeatCutoff {
        get {
          return this._heatCutoff;
        }
        set {
          this._heatCutoff = value;
        }
      }
      public ShortInteger AgeCutoff {
        get {
          return this._ageCutoff;
        }
        set {
          this._ageCutoff = value;
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
        _childHud.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _totalAmmoCutoff.Read(reader);
        _loadedAmmoCutoff.Read(reader);
        _heatCutoff.Read(reader);
        _ageCutoff.Read(reader);
        _unnamed2.Read(reader);
        _anchor.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _staticElements.Read(reader);
        _meterElements.Read(reader);
        _numberElements.Read(reader);
        _crosshairs.Read(reader);
        _overlayElements.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _screenEffect.Read(reader);
        _unnamed7.Read(reader);
        _sequenceIndex.Read(reader);
        _widthOffset.Read(reader);
        _offsetFromReferenceCorner.Read(reader);
        _overrideIconColor.Read(reader);
        _frameRate.Read(reader);
        _flags2.Read(reader);
        _textIndex.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _childHud.ReadString(reader);
        for (x = 0; (x < _staticElements.Count); x = (x + 1)) {
          StaticElements.Add(new WeaponHudStaticBlock());
          StaticElements[x].Read(reader);
        }
        for (x = 0; (x < _staticElements.Count); x = (x + 1)) {
          StaticElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _meterElements.Count); x = (x + 1)) {
          MeterElements.Add(new WeaponHudMeterBlock());
          MeterElements[x].Read(reader);
        }
        for (x = 0; (x < _meterElements.Count); x = (x + 1)) {
          MeterElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _numberElements.Count); x = (x + 1)) {
          NumberElements.Add(new WeaponHudNumberBlock());
          NumberElements[x].Read(reader);
        }
        for (x = 0; (x < _numberElements.Count); x = (x + 1)) {
          NumberElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _crosshairs.Count); x = (x + 1)) {
          Crosshairs.Add(new WeaponHudCrosshairBlock());
          Crosshairs[x].Read(reader);
        }
        for (x = 0; (x < _crosshairs.Count); x = (x + 1)) {
          Crosshairs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _overlayElements.Count); x = (x + 1)) {
          OverlayElements.Add(new WeaponHudOverlaysBlock());
          OverlayElements[x].Read(reader);
        }
        for (x = 0; (x < _overlayElements.Count); x = (x + 1)) {
          OverlayElements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _screenEffect.Count); x = (x + 1)) {
          ScreenEffect.Add(new GlobalHudScreenEffectDefinitionBlock());
          ScreenEffect[x].Read(reader);
        }
        for (x = 0; (x < _screenEffect.Count); x = (x + 1)) {
          ScreenEffect[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _childHud.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _totalAmmoCutoff.Write(bw);
        _loadedAmmoCutoff.Write(bw);
        _heatCutoff.Write(bw);
        _ageCutoff.Write(bw);
        _unnamed2.Write(bw);
        _anchor.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
_staticElements.Count = StaticElements.Count;
        _staticElements.Write(bw);
_meterElements.Count = MeterElements.Count;
        _meterElements.Write(bw);
_numberElements.Count = NumberElements.Count;
        _numberElements.Write(bw);
_crosshairs.Count = Crosshairs.Count;
        _crosshairs.Write(bw);
_overlayElements.Count = OverlayElements.Count;
        _overlayElements.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
_screenEffect.Count = ScreenEffect.Count;
        _screenEffect.Write(bw);
        _unnamed7.Write(bw);
        _sequenceIndex.Write(bw);
        _widthOffset.Write(bw);
        _offsetFromReferenceCorner.Write(bw);
        _overrideIconColor.Write(bw);
        _frameRate.Write(bw);
        _flags2.Write(bw);
        _textIndex.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _childHud.WriteString(writer);
        for (x = 0; (x < _staticElements.Count); x = (x + 1)) {
          StaticElements[x].Write(writer);
        }
        for (x = 0; (x < _staticElements.Count); x = (x + 1)) {
          StaticElements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _meterElements.Count); x = (x + 1)) {
          MeterElements[x].Write(writer);
        }
        for (x = 0; (x < _meterElements.Count); x = (x + 1)) {
          MeterElements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _numberElements.Count); x = (x + 1)) {
          NumberElements[x].Write(writer);
        }
        for (x = 0; (x < _numberElements.Count); x = (x + 1)) {
          NumberElements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _crosshairs.Count); x = (x + 1)) {
          Crosshairs[x].Write(writer);
        }
        for (x = 0; (x < _crosshairs.Count); x = (x + 1)) {
          Crosshairs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _overlayElements.Count); x = (x + 1)) {
          OverlayElements[x].Write(writer);
        }
        for (x = 0; (x < _overlayElements.Count); x = (x + 1)) {
          OverlayElements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _screenEffect.Count); x = (x + 1)) {
          ScreenEffect[x].Write(writer);
        }
        for (x = 0; (x < _screenEffect.Count); x = (x + 1)) {
          ScreenEffect[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponHudStaticBlock : IBlock {
      private Enum _stateAttachedTo = new Enum();
      private Pad _unnamed;
      private Enum _canUseOnMapType = new Enum();
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
      private Pad _unnamed9;
      public BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock> _multitexOverlayList = new BlockCollection<GlobalHudMultitextureOverlayDefinitionBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponHudStaticBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(28);
        this._scalingFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(4);
        this._unnamed9 = new Pad(40);
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
      public Enum StateAttachedTo {
        get {
          return this._stateAttachedTo;
        }
        set {
          this._stateAttachedTo = value;
        }
      }
      public Enum CanUseOnMapType {
        get {
          return this._canUseOnMapType;
        }
        set {
          this._canUseOnMapType = value;
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
      public virtual void Read(BinaryReader reader) {
        _stateAttachedTo.Read(reader);
        _unnamed.Read(reader);
        _canUseOnMapType.Read(reader);
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
        _unnamed9.Read(reader);
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
        _stateAttachedTo.Write(bw);
        _unnamed.Write(bw);
        _canUseOnMapType.Write(bw);
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
        _unnamed9.Write(bw);
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
    public class WeaponHudMeterBlock : IBlock {
      private Enum _stateAttachedTo = new Enum();
      private Pad _unnamed;
      private Enum _canUseOnMapType = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private TagReference _meterBitmap = new TagReference();
      private RGBColor _colorAtMeterMinimum = new RGBColor();
      private RGBColor _colorAtMeterMaximum = new RGBColor();
      private RGBColor _flashColor = new RGBColor();
      private ARGBColor _emptyColor = new ARGBColor();
      private Flags _flags;
      private CharInteger _minumumMeterValue = new CharInteger();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private CharInteger _alphaMultiplier = new CharInteger();
      private CharInteger _alphaBias = new CharInteger();
      private ShortInteger _valueScale = new ShortInteger();
      private Real _opacity = new Real();
      private Real _translucency = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed6;
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public WeaponHudMeterBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(28);
        this._scalingFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
        this._flags = new Flags(1);
        this._unnamed6 = new Pad(16);
        this._unnamed7 = new Pad(40);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_meterBitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum StateAttachedTo {
        get {
          return this._stateAttachedTo;
        }
        set {
          this._stateAttachedTo = value;
        }
      }
      public Enum CanUseOnMapType {
        get {
          return this._canUseOnMapType;
        }
        set {
          this._canUseOnMapType = value;
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
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
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
      public ARGBColor DisabledColor {
        get {
          return this._disabledColor;
        }
        set {
          this._disabledColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stateAttachedTo.Read(reader);
        _unnamed.Read(reader);
        _canUseOnMapType.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _meterBitmap.Read(reader);
        _colorAtMeterMinimum.Read(reader);
        _colorAtMeterMaximum.Read(reader);
        _flashColor.Read(reader);
        _emptyColor.Read(reader);
        _flags.Read(reader);
        _minumumMeterValue.Read(reader);
        _sequenceIndex.Read(reader);
        _alphaMultiplier.Read(reader);
        _alphaBias.Read(reader);
        _valueScale.Read(reader);
        _opacity.Read(reader);
        _translucency.Read(reader);
        _disabledColor.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _meterBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _stateAttachedTo.Write(bw);
        _unnamed.Write(bw);
        _canUseOnMapType.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _meterBitmap.Write(bw);
        _colorAtMeterMinimum.Write(bw);
        _colorAtMeterMaximum.Write(bw);
        _flashColor.Write(bw);
        _emptyColor.Write(bw);
        _flags.Write(bw);
        _minumumMeterValue.Write(bw);
        _sequenceIndex.Write(bw);
        _alphaMultiplier.Write(bw);
        _alphaBias.Write(bw);
        _valueScale.Write(bw);
        _opacity.Write(bw);
        _translucency.Write(bw);
        _disabledColor.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _meterBitmap.WriteString(writer);
      }
    }
    public class WeaponHudNumberBlock : IBlock {
      private Enum _stateAttachedTo = new Enum();
      private Pad _unnamed;
      private Enum _canUseOnMapType = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Point2D _anchorOffset = new Point2D();
      private Real _widthScale = new Real();
      private Real _heightScale = new Real();
      private Flags _scalingFlags;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private ARGBColor _defaultColor = new ARGBColor();
      private ARGBColor _flashingColor = new ARGBColor();
      private Real _flashPeriod = new Real();
      private Real _flashDelay = new Real();
      private ShortInteger _numberOfFlashes = new ShortInteger();
      private Flags _flashFlags;
      private Real _flashLength = new Real();
      private ARGBColor _disabledColor = new ARGBColor();
      private Pad _unnamed6;
      private CharInteger _maximumNumberOfDigits = new CharInteger();
      private Flags _flags;
      private CharInteger _numberOfFractionalDigits = new CharInteger();
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Flags _weaponSpecificFlags;
      private Pad _unnamed9;
      private Pad _unnamed10;
public event System.EventHandler BlockNameChanged;
      public WeaponHudNumberBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(28);
        this._scalingFlags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed6 = new Pad(4);
        this._flags = new Flags(1);
        this._unnamed7 = new Pad(1);
        this._unnamed8 = new Pad(12);
        this._weaponSpecificFlags = new Flags(2);
        this._unnamed9 = new Pad(2);
        this._unnamed10 = new Pad(36);
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
      public Enum StateAttachedTo {
        get {
          return this._stateAttachedTo;
        }
        set {
          this._stateAttachedTo = value;
        }
      }
      public Enum CanUseOnMapType {
        get {
          return this._canUseOnMapType;
        }
        set {
          this._canUseOnMapType = value;
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
      public Flags WeaponSpecificFlags {
        get {
          return this._weaponSpecificFlags;
        }
        set {
          this._weaponSpecificFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stateAttachedTo.Read(reader);
        _unnamed.Read(reader);
        _canUseOnMapType.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _anchorOffset.Read(reader);
        _widthScale.Read(reader);
        _heightScale.Read(reader);
        _scalingFlags.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _defaultColor.Read(reader);
        _flashingColor.Read(reader);
        _flashPeriod.Read(reader);
        _flashDelay.Read(reader);
        _numberOfFlashes.Read(reader);
        _flashFlags.Read(reader);
        _flashLength.Read(reader);
        _disabledColor.Read(reader);
        _unnamed6.Read(reader);
        _maximumNumberOfDigits.Read(reader);
        _flags.Read(reader);
        _numberOfFractionalDigits.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _weaponSpecificFlags.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stateAttachedTo.Write(bw);
        _unnamed.Write(bw);
        _canUseOnMapType.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _anchorOffset.Write(bw);
        _widthScale.Write(bw);
        _heightScale.Write(bw);
        _scalingFlags.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _defaultColor.Write(bw);
        _flashingColor.Write(bw);
        _flashPeriod.Write(bw);
        _flashDelay.Write(bw);
        _numberOfFlashes.Write(bw);
        _flashFlags.Write(bw);
        _flashLength.Write(bw);
        _disabledColor.Write(bw);
        _unnamed6.Write(bw);
        _maximumNumberOfDigits.Write(bw);
        _flags.Write(bw);
        _numberOfFractionalDigits.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _weaponSpecificFlags.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class WeaponHudCrosshairBlock : IBlock {
      private Enum _crosshairType = new Enum();
      private Pad _unnamed;
      private Enum _canUseOnMapType = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _crosshairBitmap = new TagReference();
      private Block _crosshairOverlays = new Block();
      private Pad _unnamed4;
      public BlockCollection<WeaponHudCrosshairItemBlock> _crosshairOverlaysList = new BlockCollection<WeaponHudCrosshairItemBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponHudCrosshairBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(28);
        this._unnamed4 = new Pad(40);
      }
      public BlockCollection<WeaponHudCrosshairItemBlock> CrosshairOverlays {
        get {
          return this._crosshairOverlaysList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_crosshairBitmap.Value);
for (int x=0; x<CrosshairOverlays.BlockCount; x++)
{
  IBlock block = CrosshairOverlays.GetBlock(x);
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
      public Enum CrosshairType {
        get {
          return this._crosshairType;
        }
        set {
          this._crosshairType = value;
        }
      }
      public Enum CanUseOnMapType {
        get {
          return this._canUseOnMapType;
        }
        set {
          this._canUseOnMapType = value;
        }
      }
      public TagReference CrosshairBitmap {
        get {
          return this._crosshairBitmap;
        }
        set {
          this._crosshairBitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _crosshairType.Read(reader);
        _unnamed.Read(reader);
        _canUseOnMapType.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _crosshairBitmap.Read(reader);
        _crosshairOverlays.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _crosshairBitmap.ReadString(reader);
        for (x = 0; (x < _crosshairOverlays.Count); x = (x + 1)) {
          CrosshairOverlays.Add(new WeaponHudCrosshairItemBlock());
          CrosshairOverlays[x].Read(reader);
        }
        for (x = 0; (x < _crosshairOverlays.Count); x = (x + 1)) {
          CrosshairOverlays[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _crosshairType.Write(bw);
        _unnamed.Write(bw);
        _canUseOnMapType.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _crosshairBitmap.Write(bw);
_crosshairOverlays.Count = CrosshairOverlays.Count;
        _crosshairOverlays.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _crosshairBitmap.WriteString(writer);
        for (x = 0; (x < _crosshairOverlays.Count); x = (x + 1)) {
          CrosshairOverlays[x].Write(writer);
        }
        for (x = 0; (x < _crosshairOverlays.Count); x = (x + 1)) {
          CrosshairOverlays[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponHudCrosshairItemBlock : IBlock {
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
      private ShortInteger _frameRate = new ShortInteger();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Flags _flags;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public WeaponHudCrosshairItemBlock() {
        this._scalingFlags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed3 = new Pad(4);
        this._flags = new Flags(4);
        this._unnamed4 = new Pad(32);
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
      public ShortInteger FrameRate {
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
        _flags.Read(reader);
        _unnamed4.Read(reader);
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
        _flags.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class WeaponHudOverlaysBlock : IBlock {
      private Enum _stateAttachedTo = new Enum();
      private Pad _unnamed;
      private Enum _canUseOnMapType = new Enum();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _overlayBitmap = new TagReference();
      private Block _overlays = new Block();
      private Pad _unnamed4;
      public BlockCollection<WeaponHudOverlayBlock> _overlaysList = new BlockCollection<WeaponHudOverlayBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponHudOverlaysBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(28);
        this._unnamed4 = new Pad(40);
      }
      public BlockCollection<WeaponHudOverlayBlock> Overlays {
        get {
          return this._overlaysList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_overlayBitmap.Value);
for (int x=0; x<Overlays.BlockCount; x++)
{
  IBlock block = Overlays.GetBlock(x);
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
      public Enum StateAttachedTo {
        get {
          return this._stateAttachedTo;
        }
        set {
          this._stateAttachedTo = value;
        }
      }
      public Enum CanUseOnMapType {
        get {
          return this._canUseOnMapType;
        }
        set {
          this._canUseOnMapType = value;
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
      public virtual void Read(BinaryReader reader) {
        _stateAttachedTo.Read(reader);
        _unnamed.Read(reader);
        _canUseOnMapType.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _overlayBitmap.Read(reader);
        _overlays.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _overlayBitmap.ReadString(reader);
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays.Add(new WeaponHudOverlayBlock());
          Overlays[x].Read(reader);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _stateAttachedTo.Write(bw);
        _unnamed.Write(bw);
        _canUseOnMapType.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _overlayBitmap.Write(bw);
_overlays.Count = Overlays.Count;
        _overlays.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _overlayBitmap.WriteString(writer);
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].Write(writer);
        }
        for (x = 0; (x < _overlays.Count); x = (x + 1)) {
          Overlays[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponHudOverlayBlock : IBlock {
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
      private ShortInteger _frameRate = new ShortInteger();
      private Pad _unnamed4;
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Flags _type;
      private Flags _flags;
      private Pad _unnamed5;
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public WeaponHudOverlayBlock() {
        this._scalingFlags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(20);
        this._flashFlags = new Flags(2);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(2);
        this._type = new Flags(2);
        this._flags = new Flags(4);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(40);
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
      public ShortInteger FrameRate {
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
        _unnamed4.Read(reader);
        _sequenceIndex.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
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
        _unnamed4.Write(bw);
        _sequenceIndex.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalHudScreenEffectDefinitionBlock : IBlock {
      private Pad _unnamed;
      private Flags _flags;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _maskFullscreen = new TagReference();
      private TagReference _maskSplitscreen = new TagReference();
      private Pad _unnamed4;
      private Flags _flags2;
      private Pad _unnamed5;
      private AngleBounds _fOVInBounds = new AngleBounds();
      private RealBounds _radiusOutBounds = new RealBounds();
      private Pad _unnamed6;
      private Flags _flags3;
      private ShortInteger _scriptSource = new ShortInteger();
      private RealFraction _intensity = new RealFraction();
      private Pad _unnamed7;
      private Flags _flags4;
      private ShortInteger _scriptSource2 = new ShortInteger();
      private RealFraction _intensity2 = new RealFraction();
      private RealRGBColor _tint = new RealRGBColor();
      private Pad _unnamed8;
public event System.EventHandler BlockNameChanged;
      public GlobalHudScreenEffectDefinitionBlock() {
        this._unnamed = new Pad(4);
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(8);
        this._flags2 = new Flags(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(24);
        this._flags3 = new Flags(2);
        this._unnamed7 = new Pad(24);
        this._flags4 = new Flags(2);
        this._unnamed8 = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_maskFullscreen.Value);
references.Add(_maskSplitscreen.Value);
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
      public TagReference MaskFullscreen {
        get {
          return this._maskFullscreen;
        }
        set {
          this._maskFullscreen = value;
        }
      }
      public TagReference MaskSplitscreen {
        get {
          return this._maskSplitscreen;
        }
        set {
          this._maskSplitscreen = value;
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
      public AngleBounds FOVInBounds {
        get {
          return this._fOVInBounds;
        }
        set {
          this._fOVInBounds = value;
        }
      }
      public RealBounds RadiusOutBounds {
        get {
          return this._radiusOutBounds;
        }
        set {
          this._radiusOutBounds = value;
        }
      }
      public Flags Flags3 {
        get {
          return this._flags3;
        }
        set {
          this._flags3 = value;
        }
      }
      public ShortInteger ScriptSource {
        get {
          return this._scriptSource;
        }
        set {
          this._scriptSource = value;
        }
      }
      public RealFraction Intensity {
        get {
          return this._intensity;
        }
        set {
          this._intensity = value;
        }
      }
      public Flags Flags4 {
        get {
          return this._flags4;
        }
        set {
          this._flags4 = value;
        }
      }
      public ShortInteger ScriptSource2 {
        get {
          return this._scriptSource2;
        }
        set {
          this._scriptSource2 = value;
        }
      }
      public RealFraction Intensity2 {
        get {
          return this._intensity2;
        }
        set {
          this._intensity2 = value;
        }
      }
      public RealRGBColor Tint {
        get {
          return this._tint;
        }
        set {
          this._tint = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _maskFullscreen.Read(reader);
        _maskSplitscreen.Read(reader);
        _unnamed4.Read(reader);
        _flags2.Read(reader);
        _unnamed5.Read(reader);
        _fOVInBounds.Read(reader);
        _radiusOutBounds.Read(reader);
        _unnamed6.Read(reader);
        _flags3.Read(reader);
        _scriptSource.Read(reader);
        _intensity.Read(reader);
        _unnamed7.Read(reader);
        _flags4.Read(reader);
        _scriptSource2.Read(reader);
        _intensity2.Read(reader);
        _tint.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _maskFullscreen.ReadString(reader);
        _maskSplitscreen.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _maskFullscreen.Write(bw);
        _maskSplitscreen.Write(bw);
        _unnamed4.Write(bw);
        _flags2.Write(bw);
        _unnamed5.Write(bw);
        _fOVInBounds.Write(bw);
        _radiusOutBounds.Write(bw);
        _unnamed6.Write(bw);
        _flags3.Write(bw);
        _scriptSource.Write(bw);
        _intensity.Write(bw);
        _unnamed7.Write(bw);
        _flags4.Write(bw);
        _scriptSource2.Write(bw);
        _intensity2.Write(bw);
        _tint.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _maskFullscreen.WriteString(writer);
        _maskSplitscreen.WriteString(writer);
      }
    }
  }
}
