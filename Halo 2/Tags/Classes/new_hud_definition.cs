// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'new_hud_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class new_hud_definition : Interfaces.Pool.Tag {
    private NewHudDashlightDataStructBlockBlock newHudDefinitionValues = new NewHudDashlightDataStructBlockBlock();
    public virtual NewHudDashlightDataStructBlockBlock NewHudDefinitionValues {
      get {
        return newHudDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(NewHudDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "new_hud_definition";
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
newHudDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
newHudDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
newHudDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
newHudDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class NewHudDashlightDataStructBlockBlock : IBlock {
      private TagReference _dONOTUSE = new TagReference();
      private Block _bitmapWidgets = new Block();
      private Block _textWidgets = new Block();
      private ShortInteger _lowClipCutoff = new ShortInteger();
      private ShortInteger _lowAmmoCutoff = new ShortInteger();
      private Real _ageCutoff = new Real();
      private Block _screenEffectWidgets = new Block();
      public BlockCollection<HudBitmapWidgetsBlock> _bitmapWidgetsList = new BlockCollection<HudBitmapWidgetsBlock>();
      public BlockCollection<HudTextWidgetsBlock> _textWidgetsList = new BlockCollection<HudTextWidgetsBlock>();
      public BlockCollection<HudScreenEffectWidgetsBlock> _screenEffectWidgetsList = new BlockCollection<HudScreenEffectWidgetsBlock>();
public event System.EventHandler BlockNameChanged;
      public NewHudDashlightDataStructBlockBlock() {
      }
      public BlockCollection<HudBitmapWidgetsBlock> BitmapWidgets {
        get {
          return this._bitmapWidgetsList;
        }
      }
      public BlockCollection<HudTextWidgetsBlock> TextWidgets {
        get {
          return this._textWidgetsList;
        }
      }
      public BlockCollection<HudScreenEffectWidgetsBlock> ScreenEffectWidgets {
        get {
          return this._screenEffectWidgetsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dONOTUSE.Value);
for (int x=0; x<BitmapWidgets.BlockCount; x++)
{
  IBlock block = BitmapWidgets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TextWidgets.BlockCount; x++)
{
  IBlock block = TextWidgets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScreenEffectWidgets.BlockCount; x++)
{
  IBlock block = ScreenEffectWidgets.GetBlock(x);
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
      public TagReference DONOTUSE {
        get {
          return this._dONOTUSE;
        }
        set {
          this._dONOTUSE = value;
        }
      }
      public ShortInteger LowClipCutoff {
        get {
          return this._lowClipCutoff;
        }
        set {
          this._lowClipCutoff = value;
        }
      }
      public ShortInteger LowAmmoCutoff {
        get {
          return this._lowAmmoCutoff;
        }
        set {
          this._lowAmmoCutoff = value;
        }
      }
      public Real AgeCutoff {
        get {
          return this._ageCutoff;
        }
        set {
          this._ageCutoff = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dONOTUSE.Read(reader);
        _bitmapWidgets.Read(reader);
        _textWidgets.Read(reader);
        _lowClipCutoff.Read(reader);
        _lowAmmoCutoff.Read(reader);
        _ageCutoff.Read(reader);
        _screenEffectWidgets.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _dONOTUSE.ReadString(reader);
        for (x = 0; (x < _bitmapWidgets.Count); x = (x + 1)) {
          BitmapWidgets.Add(new HudBitmapWidgetsBlock());
          BitmapWidgets[x].Read(reader);
        }
        for (x = 0; (x < _bitmapWidgets.Count); x = (x + 1)) {
          BitmapWidgets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textWidgets.Count); x = (x + 1)) {
          TextWidgets.Add(new HudTextWidgetsBlock());
          TextWidgets[x].Read(reader);
        }
        for (x = 0; (x < _textWidgets.Count); x = (x + 1)) {
          TextWidgets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _screenEffectWidgets.Count); x = (x + 1)) {
          ScreenEffectWidgets.Add(new HudScreenEffectWidgetsBlock());
          ScreenEffectWidgets[x].Read(reader);
        }
        for (x = 0; (x < _screenEffectWidgets.Count); x = (x + 1)) {
          ScreenEffectWidgets[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dONOTUSE.Write(bw);
_bitmapWidgets.Count = BitmapWidgets.Count;
        _bitmapWidgets.Write(bw);
_textWidgets.Count = TextWidgets.Count;
        _textWidgets.Write(bw);
        _lowClipCutoff.Write(bw);
        _lowAmmoCutoff.Write(bw);
        _ageCutoff.Write(bw);
_screenEffectWidgets.Count = ScreenEffectWidgets.Count;
        _screenEffectWidgets.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _dONOTUSE.WriteString(writer);
        for (x = 0; (x < _bitmapWidgets.Count); x = (x + 1)) {
          BitmapWidgets[x].Write(writer);
        }
        for (x = 0; (x < _bitmapWidgets.Count); x = (x + 1)) {
          BitmapWidgets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textWidgets.Count); x = (x + 1)) {
          TextWidgets[x].Write(writer);
        }
        for (x = 0; (x < _textWidgets.Count); x = (x + 1)) {
          TextWidgets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _screenEffectWidgets.Count); x = (x + 1)) {
          ScreenEffectWidgets[x].Write(writer);
        }
        for (x = 0; (x < _screenEffectWidgets.Count); x = (x + 1)) {
          ScreenEffectWidgets[x].WriteChildData(writer);
        }
      }
    }
    public class HudBitmapWidgetsBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _input1;
      private Enum _input2;
      private Enum _input3;
      private Enum _input4;
      private Flags _yUnitFlags;
      private Flags _yExtraFlags;
      private Flags _yWeaponFlags;
      private Flags _yGameEngineStateFlags;
      private Flags _nUnitFlags;
      private Flags _nExtraFlags;
      private Flags _nWeaponFlags;
      private Flags _nGameEngineStateFlags;
      private CharInteger _ageCutoff = new CharInteger();
      private CharInteger _clipCutoff = new CharInteger();
      private CharInteger _totalCutoff = new CharInteger();
      private Pad _unnamed0;
      private Enum _anchor;
      private Flags _flags;
      private TagReference _bitmap = new TagReference();
      private TagReference _shader = new TagReference();
      private CharInteger _fullscreenSequenceIndex = new CharInteger();
      private CharInteger _halfscreenSequenceIndex = new CharInteger();
      private CharInteger _quarterscreenSequenceIndex = new CharInteger();
      private Pad _unnamed1;
      private Point2D _fullscreenOffset = new Point2D();
      private Point2D _halfscreenOffset = new Point2D();
      private Point2D _quarterscreenOffset = new Point2D();
      private RealPoint2D _fullscreenRegistrationPoint = new RealPoint2D();
      private RealPoint2D _halfscreenRegistrationPoint = new RealPoint2D();
      private RealPoint2D _quarterscreenRegistrationPoint = new RealPoint2D();
      private Block _effect = new Block();
      private Enum _specialHudType;
      private Pad _unnamed2;
      public BlockCollection<HudWidgetEffectBlockBlock> _effectList = new BlockCollection<HudWidgetEffectBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public HudBitmapWidgetsBlock() {
        this._input1 = new Enum(1);
        this._input2 = new Enum(1);
        this._input3 = new Enum(1);
        this._input4 = new Enum(1);
        this._yUnitFlags = new Flags(2);
        this._yExtraFlags = new Flags(2);
        this._yWeaponFlags = new Flags(2);
        this._yGameEngineStateFlags = new Flags(2);
        this._nUnitFlags = new Flags(2);
        this._nExtraFlags = new Flags(2);
        this._nWeaponFlags = new Flags(2);
        this._nGameEngineStateFlags = new Flags(2);
        this._unnamed0 = new Pad(1);
        this._anchor = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed1 = new Pad(1);
        this._specialHudType = new Enum(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<HudWidgetEffectBlockBlock> Effect {
        get {
          return this._effectList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_shader.Value);
for (int x=0; x<Effect.BlockCount; x++)
{
  IBlock block = Effect.GetBlock(x);
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
      public Enum Input1 {
        get {
          return this._input1;
        }
        set {
          this._input1 = value;
        }
      }
      public Enum Input2 {
        get {
          return this._input2;
        }
        set {
          this._input2 = value;
        }
      }
      public Enum Input3 {
        get {
          return this._input3;
        }
        set {
          this._input3 = value;
        }
      }
      public Enum Input4 {
        get {
          return this._input4;
        }
        set {
          this._input4 = value;
        }
      }
      public Flags YUnitFlags {
        get {
          return this._yUnitFlags;
        }
        set {
          this._yUnitFlags = value;
        }
      }
      public Flags YExtraFlags {
        get {
          return this._yExtraFlags;
        }
        set {
          this._yExtraFlags = value;
        }
      }
      public Flags YWeaponFlags {
        get {
          return this._yWeaponFlags;
        }
        set {
          this._yWeaponFlags = value;
        }
      }
      public Flags YGameEngineStateFlags {
        get {
          return this._yGameEngineStateFlags;
        }
        set {
          this._yGameEngineStateFlags = value;
        }
      }
      public Flags NUnitFlags {
        get {
          return this._nUnitFlags;
        }
        set {
          this._nUnitFlags = value;
        }
      }
      public Flags NExtraFlags {
        get {
          return this._nExtraFlags;
        }
        set {
          this._nExtraFlags = value;
        }
      }
      public Flags NWeaponFlags {
        get {
          return this._nWeaponFlags;
        }
        set {
          this._nWeaponFlags = value;
        }
      }
      public Flags NGameEngineStateFlags {
        get {
          return this._nGameEngineStateFlags;
        }
        set {
          this._nGameEngineStateFlags = value;
        }
      }
      public CharInteger AgeCutoff {
        get {
          return this._ageCutoff;
        }
        set {
          this._ageCutoff = value;
        }
      }
      public CharInteger ClipCutoff {
        get {
          return this._clipCutoff;
        }
        set {
          this._clipCutoff = value;
        }
      }
      public CharInteger TotalCutoff {
        get {
          return this._totalCutoff;
        }
        set {
          this._totalCutoff = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public CharInteger FullscreenSequenceIndex {
        get {
          return this._fullscreenSequenceIndex;
        }
        set {
          this._fullscreenSequenceIndex = value;
        }
      }
      public CharInteger HalfscreenSequenceIndex {
        get {
          return this._halfscreenSequenceIndex;
        }
        set {
          this._halfscreenSequenceIndex = value;
        }
      }
      public CharInteger QuarterscreenSequenceIndex {
        get {
          return this._quarterscreenSequenceIndex;
        }
        set {
          this._quarterscreenSequenceIndex = value;
        }
      }
      public Point2D FullscreenOffset {
        get {
          return this._fullscreenOffset;
        }
        set {
          this._fullscreenOffset = value;
        }
      }
      public Point2D HalfscreenOffset {
        get {
          return this._halfscreenOffset;
        }
        set {
          this._halfscreenOffset = value;
        }
      }
      public Point2D QuarterscreenOffset {
        get {
          return this._quarterscreenOffset;
        }
        set {
          this._quarterscreenOffset = value;
        }
      }
      public RealPoint2D FullscreenRegistrationPoint {
        get {
          return this._fullscreenRegistrationPoint;
        }
        set {
          this._fullscreenRegistrationPoint = value;
        }
      }
      public RealPoint2D HalfscreenRegistrationPoint {
        get {
          return this._halfscreenRegistrationPoint;
        }
        set {
          this._halfscreenRegistrationPoint = value;
        }
      }
      public RealPoint2D QuarterscreenRegistrationPoint {
        get {
          return this._quarterscreenRegistrationPoint;
        }
        set {
          this._quarterscreenRegistrationPoint = value;
        }
      }
      public Enum SpecialHudType {
        get {
          return this._specialHudType;
        }
        set {
          this._specialHudType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _input1.Read(reader);
        _input2.Read(reader);
        _input3.Read(reader);
        _input4.Read(reader);
        _yUnitFlags.Read(reader);
        _yExtraFlags.Read(reader);
        _yWeaponFlags.Read(reader);
        _yGameEngineStateFlags.Read(reader);
        _nUnitFlags.Read(reader);
        _nExtraFlags.Read(reader);
        _nWeaponFlags.Read(reader);
        _nGameEngineStateFlags.Read(reader);
        _ageCutoff.Read(reader);
        _clipCutoff.Read(reader);
        _totalCutoff.Read(reader);
        _unnamed0.Read(reader);
        _anchor.Read(reader);
        _flags.Read(reader);
        _bitmap.Read(reader);
        _shader.Read(reader);
        _fullscreenSequenceIndex.Read(reader);
        _halfscreenSequenceIndex.Read(reader);
        _quarterscreenSequenceIndex.Read(reader);
        _unnamed1.Read(reader);
        _fullscreenOffset.Read(reader);
        _halfscreenOffset.Read(reader);
        _quarterscreenOffset.Read(reader);
        _fullscreenRegistrationPoint.Read(reader);
        _halfscreenRegistrationPoint.Read(reader);
        _quarterscreenRegistrationPoint.Read(reader);
        _effect.Read(reader);
        _specialHudType.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _bitmap.ReadString(reader);
        _shader.ReadString(reader);
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect.Add(new HudWidgetEffectBlockBlock());
          Effect[x].Read(reader);
        }
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _input1.Write(bw);
        _input2.Write(bw);
        _input3.Write(bw);
        _input4.Write(bw);
        _yUnitFlags.Write(bw);
        _yExtraFlags.Write(bw);
        _yWeaponFlags.Write(bw);
        _yGameEngineStateFlags.Write(bw);
        _nUnitFlags.Write(bw);
        _nExtraFlags.Write(bw);
        _nWeaponFlags.Write(bw);
        _nGameEngineStateFlags.Write(bw);
        _ageCutoff.Write(bw);
        _clipCutoff.Write(bw);
        _totalCutoff.Write(bw);
        _unnamed0.Write(bw);
        _anchor.Write(bw);
        _flags.Write(bw);
        _bitmap.Write(bw);
        _shader.Write(bw);
        _fullscreenSequenceIndex.Write(bw);
        _halfscreenSequenceIndex.Write(bw);
        _quarterscreenSequenceIndex.Write(bw);
        _unnamed1.Write(bw);
        _fullscreenOffset.Write(bw);
        _halfscreenOffset.Write(bw);
        _quarterscreenOffset.Write(bw);
        _fullscreenRegistrationPoint.Write(bw);
        _halfscreenRegistrationPoint.Write(bw);
        _quarterscreenRegistrationPoint.Write(bw);
_effect.Count = Effect.Count;
        _effect.Write(bw);
        _specialHudType.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _bitmap.WriteString(writer);
        _shader.WriteString(writer);
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].Write(writer);
        }
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].WriteChildData(writer);
        }
      }
    }
    public class HudWidgetEffectBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private StringId _inputName = new StringId();
      private StringId _rangeName = new StringId();
      private Real _timePeriodInSeconds = new Real();
      private Block _data = new Block();
      private StringId _inputName2 = new StringId();
      private StringId _rangeName2 = new StringId();
      private Real _timePeriodInSeconds2 = new Real();
      private Block _data2 = new Block();
      private StringId _inputName3 = new StringId();
      private StringId _rangeName3 = new StringId();
      private Real _timePeriodInSeconds3 = new Real();
      private Block _data3 = new Block();
      private StringId _inputName4 = new StringId();
      private StringId _rangeName4 = new StringId();
      private Real _timePeriodInSeconds4 = new Real();
      private Block _data4 = new Block();
      private StringId _inputName5 = new StringId();
      private StringId _rangeName5 = new StringId();
      private Real _timePeriodInSeconds5 = new Real();
      private Block _data5 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public HudWidgetEffectBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data3 {
        get {
          return this._data3List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data4 {
        get {
          return this._data4List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data5 {
        get {
          return this._data5List;
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
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data3.BlockCount; x++)
{
  IBlock block = Data3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data4.BlockCount; x++)
{
  IBlock block = Data4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data5.BlockCount; x++)
{
  IBlock block = Data5.GetBlock(x);
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
      public StringId InputName {
        get {
          return this._inputName;
        }
        set {
          this._inputName = value;
        }
      }
      public StringId RangeName {
        get {
          return this._rangeName;
        }
        set {
          this._rangeName = value;
        }
      }
      public Real TimePeriodInSeconds {
        get {
          return this._timePeriodInSeconds;
        }
        set {
          this._timePeriodInSeconds = value;
        }
      }
      public StringId InputName2 {
        get {
          return this._inputName2;
        }
        set {
          this._inputName2 = value;
        }
      }
      public StringId RangeName2 {
        get {
          return this._rangeName2;
        }
        set {
          this._rangeName2 = value;
        }
      }
      public Real TimePeriodInSeconds2 {
        get {
          return this._timePeriodInSeconds2;
        }
        set {
          this._timePeriodInSeconds2 = value;
        }
      }
      public StringId InputName3 {
        get {
          return this._inputName3;
        }
        set {
          this._inputName3 = value;
        }
      }
      public StringId RangeName3 {
        get {
          return this._rangeName3;
        }
        set {
          this._rangeName3 = value;
        }
      }
      public Real TimePeriodInSeconds3 {
        get {
          return this._timePeriodInSeconds3;
        }
        set {
          this._timePeriodInSeconds3 = value;
        }
      }
      public StringId InputName4 {
        get {
          return this._inputName4;
        }
        set {
          this._inputName4 = value;
        }
      }
      public StringId RangeName4 {
        get {
          return this._rangeName4;
        }
        set {
          this._rangeName4 = value;
        }
      }
      public Real TimePeriodInSeconds4 {
        get {
          return this._timePeriodInSeconds4;
        }
        set {
          this._timePeriodInSeconds4 = value;
        }
      }
      public StringId InputName5 {
        get {
          return this._inputName5;
        }
        set {
          this._inputName5 = value;
        }
      }
      public StringId RangeName5 {
        get {
          return this._rangeName5;
        }
        set {
          this._rangeName5 = value;
        }
      }
      public Real TimePeriodInSeconds5 {
        get {
          return this._timePeriodInSeconds5;
        }
        set {
          this._timePeriodInSeconds5 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _inputName.Read(reader);
        _rangeName.Read(reader);
        _timePeriodInSeconds.Read(reader);
        _data.Read(reader);
        _inputName2.Read(reader);
        _rangeName2.Read(reader);
        _timePeriodInSeconds2.Read(reader);
        _data2.Read(reader);
        _inputName3.Read(reader);
        _rangeName3.Read(reader);
        _timePeriodInSeconds3.Read(reader);
        _data3.Read(reader);
        _inputName4.Read(reader);
        _rangeName4.Read(reader);
        _timePeriodInSeconds4.Read(reader);
        _data4.Read(reader);
        _inputName5.Read(reader);
        _rangeName5.Read(reader);
        _timePeriodInSeconds5.Read(reader);
        _data5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputName.ReadString(reader);
        _rangeName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        _inputName2.ReadString(reader);
        _rangeName2.ReadString(reader);
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
        _inputName3.ReadString(reader);
        _rangeName3.ReadString(reader);
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
        _inputName4.ReadString(reader);
        _rangeName4.ReadString(reader);
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4.Add(new ByteBlockBlock());
          Data4[x].Read(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].ReadChildData(reader);
        }
        _inputName5.ReadString(reader);
        _rangeName5.ReadString(reader);
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5.Add(new ByteBlockBlock());
          Data5[x].Read(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _inputName.Write(bw);
        _rangeName.Write(bw);
        _timePeriodInSeconds.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _inputName2.Write(bw);
        _rangeName2.Write(bw);
        _timePeriodInSeconds2.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _inputName3.Write(bw);
        _rangeName3.Write(bw);
        _timePeriodInSeconds3.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
        _inputName4.Write(bw);
        _rangeName4.Write(bw);
        _timePeriodInSeconds4.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
        _inputName5.Write(bw);
        _rangeName5.Write(bw);
        _timePeriodInSeconds5.Write(bw);
_data5.Count = Data5.Count;
        _data5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputName.WriteString(writer);
        _rangeName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        _inputName2.WriteString(writer);
        _rangeName2.WriteString(writer);
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
        _inputName3.WriteString(writer);
        _rangeName3.WriteString(writer);
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
        }
        _inputName4.WriteString(writer);
        _rangeName4.WriteString(writer);
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].Write(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].WriteChildData(writer);
        }
        _inputName5.WriteString(writer);
        _rangeName5.WriteString(writer);
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].Write(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].WriteChildData(writer);
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
    public class HudTextWidgetsBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _input1;
      private Enum _input2;
      private Enum _input3;
      private Enum _input4;
      private Flags _yUnitFlags;
      private Flags _yExtraFlags;
      private Flags _yWeaponFlags;
      private Flags _yGameEngineStateFlags;
      private Flags _nUnitFlags;
      private Flags _nExtraFlags;
      private Flags _nWeaponFlags;
      private Flags _nGameEngineStateFlags;
      private CharInteger _ageCutoff = new CharInteger();
      private CharInteger _clipCutoff = new CharInteger();
      private CharInteger _totalCutoff = new CharInteger();
      private Pad _unnamed0;
      private Enum _anchor;
      private Flags _flags;
      private TagReference _shader = new TagReference();
      private StringId _string = new StringId();
      private Enum _justification;
      private Pad _unnamed1;
      private Enum _fullscreenFontIndex;
      private Enum _halfscreenFontIndex;
      private Enum _quarterscreenFontIndex;
      private Pad _unnamed2;
      private Real _fullscreenScale = new Real();
      private Real _halfscreenScale = new Real();
      private Real _quarterscreenScale = new Real();
      private Point2D _fullscreenOffset = new Point2D();
      private Point2D _halfscreenOffset = new Point2D();
      private Point2D _quarterscreenOffset = new Point2D();
      private Block _effect = new Block();
      public BlockCollection<HudWidgetEffectBlockBlock> _effectList = new BlockCollection<HudWidgetEffectBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public HudTextWidgetsBlock() {
        this._input1 = new Enum(1);
        this._input2 = new Enum(1);
        this._input3 = new Enum(1);
        this._input4 = new Enum(1);
        this._yUnitFlags = new Flags(2);
        this._yExtraFlags = new Flags(2);
        this._yWeaponFlags = new Flags(2);
        this._yGameEngineStateFlags = new Flags(2);
        this._nUnitFlags = new Flags(2);
        this._nExtraFlags = new Flags(2);
        this._nWeaponFlags = new Flags(2);
        this._nGameEngineStateFlags = new Flags(2);
        this._unnamed0 = new Pad(1);
        this._anchor = new Enum(2);
        this._flags = new Flags(2);
        this._justification = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._fullscreenFontIndex = new Enum(1);
        this._halfscreenFontIndex = new Enum(1);
        this._quarterscreenFontIndex = new Enum(1);
        this._unnamed2 = new Pad(1);
      }
      public BlockCollection<HudWidgetEffectBlockBlock> Effect {
        get {
          return this._effectList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
for (int x=0; x<Effect.BlockCount; x++)
{
  IBlock block = Effect.GetBlock(x);
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
      public Enum Input1 {
        get {
          return this._input1;
        }
        set {
          this._input1 = value;
        }
      }
      public Enum Input2 {
        get {
          return this._input2;
        }
        set {
          this._input2 = value;
        }
      }
      public Enum Input3 {
        get {
          return this._input3;
        }
        set {
          this._input3 = value;
        }
      }
      public Enum Input4 {
        get {
          return this._input4;
        }
        set {
          this._input4 = value;
        }
      }
      public Flags YUnitFlags {
        get {
          return this._yUnitFlags;
        }
        set {
          this._yUnitFlags = value;
        }
      }
      public Flags YExtraFlags {
        get {
          return this._yExtraFlags;
        }
        set {
          this._yExtraFlags = value;
        }
      }
      public Flags YWeaponFlags {
        get {
          return this._yWeaponFlags;
        }
        set {
          this._yWeaponFlags = value;
        }
      }
      public Flags YGameEngineStateFlags {
        get {
          return this._yGameEngineStateFlags;
        }
        set {
          this._yGameEngineStateFlags = value;
        }
      }
      public Flags NUnitFlags {
        get {
          return this._nUnitFlags;
        }
        set {
          this._nUnitFlags = value;
        }
      }
      public Flags NExtraFlags {
        get {
          return this._nExtraFlags;
        }
        set {
          this._nExtraFlags = value;
        }
      }
      public Flags NWeaponFlags {
        get {
          return this._nWeaponFlags;
        }
        set {
          this._nWeaponFlags = value;
        }
      }
      public Flags NGameEngineStateFlags {
        get {
          return this._nGameEngineStateFlags;
        }
        set {
          this._nGameEngineStateFlags = value;
        }
      }
      public CharInteger AgeCutoff {
        get {
          return this._ageCutoff;
        }
        set {
          this._ageCutoff = value;
        }
      }
      public CharInteger ClipCutoff {
        get {
          return this._clipCutoff;
        }
        set {
          this._clipCutoff = value;
        }
      }
      public CharInteger TotalCutoff {
        get {
          return this._totalCutoff;
        }
        set {
          this._totalCutoff = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public StringId String {
        get {
          return this._string;
        }
        set {
          this._string = value;
        }
      }
      public Enum Justification {
        get {
          return this._justification;
        }
        set {
          this._justification = value;
        }
      }
      public Enum FullscreenFontIndex {
        get {
          return this._fullscreenFontIndex;
        }
        set {
          this._fullscreenFontIndex = value;
        }
      }
      public Enum HalfscreenFontIndex {
        get {
          return this._halfscreenFontIndex;
        }
        set {
          this._halfscreenFontIndex = value;
        }
      }
      public Enum QuarterscreenFontIndex {
        get {
          return this._quarterscreenFontIndex;
        }
        set {
          this._quarterscreenFontIndex = value;
        }
      }
      public Real FullscreenScale {
        get {
          return this._fullscreenScale;
        }
        set {
          this._fullscreenScale = value;
        }
      }
      public Real HalfscreenScale {
        get {
          return this._halfscreenScale;
        }
        set {
          this._halfscreenScale = value;
        }
      }
      public Real QuarterscreenScale {
        get {
          return this._quarterscreenScale;
        }
        set {
          this._quarterscreenScale = value;
        }
      }
      public Point2D FullscreenOffset {
        get {
          return this._fullscreenOffset;
        }
        set {
          this._fullscreenOffset = value;
        }
      }
      public Point2D HalfscreenOffset {
        get {
          return this._halfscreenOffset;
        }
        set {
          this._halfscreenOffset = value;
        }
      }
      public Point2D QuarterscreenOffset {
        get {
          return this._quarterscreenOffset;
        }
        set {
          this._quarterscreenOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _input1.Read(reader);
        _input2.Read(reader);
        _input3.Read(reader);
        _input4.Read(reader);
        _yUnitFlags.Read(reader);
        _yExtraFlags.Read(reader);
        _yWeaponFlags.Read(reader);
        _yGameEngineStateFlags.Read(reader);
        _nUnitFlags.Read(reader);
        _nExtraFlags.Read(reader);
        _nWeaponFlags.Read(reader);
        _nGameEngineStateFlags.Read(reader);
        _ageCutoff.Read(reader);
        _clipCutoff.Read(reader);
        _totalCutoff.Read(reader);
        _unnamed0.Read(reader);
        _anchor.Read(reader);
        _flags.Read(reader);
        _shader.Read(reader);
        _string.Read(reader);
        _justification.Read(reader);
        _unnamed1.Read(reader);
        _fullscreenFontIndex.Read(reader);
        _halfscreenFontIndex.Read(reader);
        _quarterscreenFontIndex.Read(reader);
        _unnamed2.Read(reader);
        _fullscreenScale.Read(reader);
        _halfscreenScale.Read(reader);
        _quarterscreenScale.Read(reader);
        _fullscreenOffset.Read(reader);
        _halfscreenOffset.Read(reader);
        _quarterscreenOffset.Read(reader);
        _effect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _shader.ReadString(reader);
        _string.ReadString(reader);
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect.Add(new HudWidgetEffectBlockBlock());
          Effect[x].Read(reader);
        }
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _input1.Write(bw);
        _input2.Write(bw);
        _input3.Write(bw);
        _input4.Write(bw);
        _yUnitFlags.Write(bw);
        _yExtraFlags.Write(bw);
        _yWeaponFlags.Write(bw);
        _yGameEngineStateFlags.Write(bw);
        _nUnitFlags.Write(bw);
        _nExtraFlags.Write(bw);
        _nWeaponFlags.Write(bw);
        _nGameEngineStateFlags.Write(bw);
        _ageCutoff.Write(bw);
        _clipCutoff.Write(bw);
        _totalCutoff.Write(bw);
        _unnamed0.Write(bw);
        _anchor.Write(bw);
        _flags.Write(bw);
        _shader.Write(bw);
        _string.Write(bw);
        _justification.Write(bw);
        _unnamed1.Write(bw);
        _fullscreenFontIndex.Write(bw);
        _halfscreenFontIndex.Write(bw);
        _quarterscreenFontIndex.Write(bw);
        _unnamed2.Write(bw);
        _fullscreenScale.Write(bw);
        _halfscreenScale.Write(bw);
        _quarterscreenScale.Write(bw);
        _fullscreenOffset.Write(bw);
        _halfscreenOffset.Write(bw);
        _quarterscreenOffset.Write(bw);
_effect.Count = Effect.Count;
        _effect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _shader.WriteString(writer);
        _string.WriteString(writer);
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].Write(writer);
        }
        for (x = 0; (x < _effect.Count); x = (x + 1)) {
          Effect[x].WriteChildData(writer);
        }
      }
    }
    public class HudScreenEffectWidgetsBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _input1;
      private Enum _input2;
      private Enum _input3;
      private Enum _input4;
      private Flags _yUnitFlags;
      private Flags _yExtraFlags;
      private Flags _yWeaponFlags;
      private Flags _yGameEngineStateFlags;
      private Flags _nUnitFlags;
      private Flags _nExtraFlags;
      private Flags _nWeaponFlags;
      private Flags _nGameEngineStateFlags;
      private CharInteger _ageCutoff = new CharInteger();
      private CharInteger _clipCutoff = new CharInteger();
      private CharInteger _totalCutoff = new CharInteger();
      private Pad _unnamed0;
      private Enum _anchor;
      private Flags _flags;
      private TagReference _bitmap = new TagReference();
      private TagReference _fullscreenScreenEffect = new TagReference();
      private TagReference _halfscreenScreenEffect = new TagReference();
      private TagReference _quarterscreenScreenEffect = new TagReference();
      private CharInteger _fullscreenSequenceIndex = new CharInteger();
      private CharInteger _halfscreenSequenceIndex = new CharInteger();
      private CharInteger _quarterscreenSequenceIndex = new CharInteger();
      private Pad _unnamed1;
      private Point2D _fullscreenOffset = new Point2D();
      private Point2D _halfscreenOffset = new Point2D();
      private Point2D _quarterscreenOffset = new Point2D();
public event System.EventHandler BlockNameChanged;
      public HudScreenEffectWidgetsBlock() {
        this._input1 = new Enum(1);
        this._input2 = new Enum(1);
        this._input3 = new Enum(1);
        this._input4 = new Enum(1);
        this._yUnitFlags = new Flags(2);
        this._yExtraFlags = new Flags(2);
        this._yWeaponFlags = new Flags(2);
        this._yGameEngineStateFlags = new Flags(2);
        this._nUnitFlags = new Flags(2);
        this._nExtraFlags = new Flags(2);
        this._nWeaponFlags = new Flags(2);
        this._nGameEngineStateFlags = new Flags(2);
        this._unnamed0 = new Pad(1);
        this._anchor = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed1 = new Pad(1);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
references.Add(_fullscreenScreenEffect.Value);
references.Add(_halfscreenScreenEffect.Value);
references.Add(_quarterscreenScreenEffect.Value);
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
      public Enum Input1 {
        get {
          return this._input1;
        }
        set {
          this._input1 = value;
        }
      }
      public Enum Input2 {
        get {
          return this._input2;
        }
        set {
          this._input2 = value;
        }
      }
      public Enum Input3 {
        get {
          return this._input3;
        }
        set {
          this._input3 = value;
        }
      }
      public Enum Input4 {
        get {
          return this._input4;
        }
        set {
          this._input4 = value;
        }
      }
      public Flags YUnitFlags {
        get {
          return this._yUnitFlags;
        }
        set {
          this._yUnitFlags = value;
        }
      }
      public Flags YExtraFlags {
        get {
          return this._yExtraFlags;
        }
        set {
          this._yExtraFlags = value;
        }
      }
      public Flags YWeaponFlags {
        get {
          return this._yWeaponFlags;
        }
        set {
          this._yWeaponFlags = value;
        }
      }
      public Flags YGameEngineStateFlags {
        get {
          return this._yGameEngineStateFlags;
        }
        set {
          this._yGameEngineStateFlags = value;
        }
      }
      public Flags NUnitFlags {
        get {
          return this._nUnitFlags;
        }
        set {
          this._nUnitFlags = value;
        }
      }
      public Flags NExtraFlags {
        get {
          return this._nExtraFlags;
        }
        set {
          this._nExtraFlags = value;
        }
      }
      public Flags NWeaponFlags {
        get {
          return this._nWeaponFlags;
        }
        set {
          this._nWeaponFlags = value;
        }
      }
      public Flags NGameEngineStateFlags {
        get {
          return this._nGameEngineStateFlags;
        }
        set {
          this._nGameEngineStateFlags = value;
        }
      }
      public CharInteger AgeCutoff {
        get {
          return this._ageCutoff;
        }
        set {
          this._ageCutoff = value;
        }
      }
      public CharInteger ClipCutoff {
        get {
          return this._clipCutoff;
        }
        set {
          this._clipCutoff = value;
        }
      }
      public CharInteger TotalCutoff {
        get {
          return this._totalCutoff;
        }
        set {
          this._totalCutoff = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public TagReference FullscreenScreenEffect {
        get {
          return this._fullscreenScreenEffect;
        }
        set {
          this._fullscreenScreenEffect = value;
        }
      }
      public TagReference HalfscreenScreenEffect {
        get {
          return this._halfscreenScreenEffect;
        }
        set {
          this._halfscreenScreenEffect = value;
        }
      }
      public TagReference QuarterscreenScreenEffect {
        get {
          return this._quarterscreenScreenEffect;
        }
        set {
          this._quarterscreenScreenEffect = value;
        }
      }
      public CharInteger FullscreenSequenceIndex {
        get {
          return this._fullscreenSequenceIndex;
        }
        set {
          this._fullscreenSequenceIndex = value;
        }
      }
      public CharInteger HalfscreenSequenceIndex {
        get {
          return this._halfscreenSequenceIndex;
        }
        set {
          this._halfscreenSequenceIndex = value;
        }
      }
      public CharInteger QuarterscreenSequenceIndex {
        get {
          return this._quarterscreenSequenceIndex;
        }
        set {
          this._quarterscreenSequenceIndex = value;
        }
      }
      public Point2D FullscreenOffset {
        get {
          return this._fullscreenOffset;
        }
        set {
          this._fullscreenOffset = value;
        }
      }
      public Point2D HalfscreenOffset {
        get {
          return this._halfscreenOffset;
        }
        set {
          this._halfscreenOffset = value;
        }
      }
      public Point2D QuarterscreenOffset {
        get {
          return this._quarterscreenOffset;
        }
        set {
          this._quarterscreenOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _input1.Read(reader);
        _input2.Read(reader);
        _input3.Read(reader);
        _input4.Read(reader);
        _yUnitFlags.Read(reader);
        _yExtraFlags.Read(reader);
        _yWeaponFlags.Read(reader);
        _yGameEngineStateFlags.Read(reader);
        _nUnitFlags.Read(reader);
        _nExtraFlags.Read(reader);
        _nWeaponFlags.Read(reader);
        _nGameEngineStateFlags.Read(reader);
        _ageCutoff.Read(reader);
        _clipCutoff.Read(reader);
        _totalCutoff.Read(reader);
        _unnamed0.Read(reader);
        _anchor.Read(reader);
        _flags.Read(reader);
        _bitmap.Read(reader);
        _fullscreenScreenEffect.Read(reader);
        _halfscreenScreenEffect.Read(reader);
        _quarterscreenScreenEffect.Read(reader);
        _fullscreenSequenceIndex.Read(reader);
        _halfscreenSequenceIndex.Read(reader);
        _quarterscreenSequenceIndex.Read(reader);
        _unnamed1.Read(reader);
        _fullscreenOffset.Read(reader);
        _halfscreenOffset.Read(reader);
        _quarterscreenOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _bitmap.ReadString(reader);
        _fullscreenScreenEffect.ReadString(reader);
        _halfscreenScreenEffect.ReadString(reader);
        _quarterscreenScreenEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _input1.Write(bw);
        _input2.Write(bw);
        _input3.Write(bw);
        _input4.Write(bw);
        _yUnitFlags.Write(bw);
        _yExtraFlags.Write(bw);
        _yWeaponFlags.Write(bw);
        _yGameEngineStateFlags.Write(bw);
        _nUnitFlags.Write(bw);
        _nExtraFlags.Write(bw);
        _nWeaponFlags.Write(bw);
        _nGameEngineStateFlags.Write(bw);
        _ageCutoff.Write(bw);
        _clipCutoff.Write(bw);
        _totalCutoff.Write(bw);
        _unnamed0.Write(bw);
        _anchor.Write(bw);
        _flags.Write(bw);
        _bitmap.Write(bw);
        _fullscreenScreenEffect.Write(bw);
        _halfscreenScreenEffect.Write(bw);
        _quarterscreenScreenEffect.Write(bw);
        _fullscreenSequenceIndex.Write(bw);
        _halfscreenSequenceIndex.Write(bw);
        _quarterscreenSequenceIndex.Write(bw);
        _unnamed1.Write(bw);
        _fullscreenOffset.Write(bw);
        _halfscreenOffset.Write(bw);
        _quarterscreenOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _bitmap.WriteString(writer);
        _fullscreenScreenEffect.WriteString(writer);
        _halfscreenScreenEffect.WriteString(writer);
        _quarterscreenScreenEffect.WriteString(writer);
      }
    }
  }
}
