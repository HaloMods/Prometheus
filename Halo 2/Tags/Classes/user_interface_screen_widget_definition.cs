// ------------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'user_interface_screen_widget_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ------------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class user_interface_screen_widget_definition : Interfaces.Pool.Tag {
    private UserInterfaceScreenWidgetDefinitionBlockBlock userInterfaceScreenWidgetDefinitionValues = new UserInterfaceScreenWidgetDefinitionBlockBlock();
    public virtual UserInterfaceScreenWidgetDefinitionBlockBlock UserInterfaceScreenWidgetDefinitionValues {
      get {
        return userInterfaceScreenWidgetDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UserInterfaceScreenWidgetDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "user_interface_screen_widget_definition";
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
userInterfaceScreenWidgetDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
userInterfaceScreenWidgetDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
userInterfaceScreenWidgetDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
userInterfaceScreenWidgetDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class UserInterfaceScreenWidgetDefinitionBlockBlock : IBlock {
      private Flags _flags;
      private Enum _screenID;
      private Enum _buttonKeyType;
      private RealARGBColor _textColor = new RealARGBColor();
      private TagReference _stringListTag = new TagReference();
      private Block _panes = new Block();
      private Enum _shapeGroup;
      private Pad _unnamed0;
      private StringId _headerStringId = new StringId();
      private Block _localStrings = new Block();
      private Block _localBitmaps = new Block();
      private RealRGBColor _sourceColor = new RealRGBColor();
      private RealRGBColor _destinationColor = new RealRGBColor();
      private Real _accumulateZoomScaleX = new Real();
      private Real _accumulateZoomScaleY = new Real();
      private Real _refractionScaleX = new Real();
      private Real _refractionScaleY = new Real();
      public BlockCollection<WindowPaneReferenceBlockBlock> _panesList = new BlockCollection<WindowPaneReferenceBlockBlock>();
      public BlockCollection<LocalStringIdListSectionReferenceBlockBlock> _localStringsList = new BlockCollection<LocalStringIdListSectionReferenceBlockBlock>();
      public BlockCollection<LocalBitmapReferenceBlockBlock> _localBitmapsList = new BlockCollection<LocalBitmapReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserInterfaceScreenWidgetDefinitionBlockBlock() {
        this._flags = new Flags(4);
        this._screenID = new Enum(2);
        this._buttonKeyType = new Enum(2);
        this._shapeGroup = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<WindowPaneReferenceBlockBlock> Panes {
        get {
          return this._panesList;
        }
      }
      public BlockCollection<LocalStringIdListSectionReferenceBlockBlock> LocalStrings {
        get {
          return this._localStringsList;
        }
      }
      public BlockCollection<LocalBitmapReferenceBlockBlock> LocalBitmaps {
        get {
          return this._localBitmapsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_stringListTag.Value);
for (int x=0; x<Panes.BlockCount; x++)
{
  IBlock block = Panes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LocalStrings.BlockCount; x++)
{
  IBlock block = LocalStrings.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LocalBitmaps.BlockCount; x++)
{
  IBlock block = LocalBitmaps.GetBlock(x);
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
      public Enum ScreenID {
        get {
          return this._screenID;
        }
        set {
          this._screenID = value;
        }
      }
      public Enum ButtonKeyType {
        get {
          return this._buttonKeyType;
        }
        set {
          this._buttonKeyType = value;
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
      public TagReference StringListTag {
        get {
          return this._stringListTag;
        }
        set {
          this._stringListTag = value;
        }
      }
      public Enum ShapeGroup {
        get {
          return this._shapeGroup;
        }
        set {
          this._shapeGroup = value;
        }
      }
      public StringId HeaderStringId {
        get {
          return this._headerStringId;
        }
        set {
          this._headerStringId = value;
        }
      }
      public RealRGBColor SourceColor {
        get {
          return this._sourceColor;
        }
        set {
          this._sourceColor = value;
        }
      }
      public RealRGBColor DestinationColor {
        get {
          return this._destinationColor;
        }
        set {
          this._destinationColor = value;
        }
      }
      public Real AccumulateZoomScaleX {
        get {
          return this._accumulateZoomScaleX;
        }
        set {
          this._accumulateZoomScaleX = value;
        }
      }
      public Real AccumulateZoomScaleY {
        get {
          return this._accumulateZoomScaleY;
        }
        set {
          this._accumulateZoomScaleY = value;
        }
      }
      public Real RefractionScaleX {
        get {
          return this._refractionScaleX;
        }
        set {
          this._refractionScaleX = value;
        }
      }
      public Real RefractionScaleY {
        get {
          return this._refractionScaleY;
        }
        set {
          this._refractionScaleY = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _screenID.Read(reader);
        _buttonKeyType.Read(reader);
        _textColor.Read(reader);
        _stringListTag.Read(reader);
        _panes.Read(reader);
        _shapeGroup.Read(reader);
        _unnamed0.Read(reader);
        _headerStringId.Read(reader);
        _localStrings.Read(reader);
        _localBitmaps.Read(reader);
        _sourceColor.Read(reader);
        _destinationColor.Read(reader);
        _accumulateZoomScaleX.Read(reader);
        _accumulateZoomScaleY.Read(reader);
        _refractionScaleX.Read(reader);
        _refractionScaleY.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _stringListTag.ReadString(reader);
        for (x = 0; (x < _panes.Count); x = (x + 1)) {
          Panes.Add(new WindowPaneReferenceBlockBlock());
          Panes[x].Read(reader);
        }
        for (x = 0; (x < _panes.Count); x = (x + 1)) {
          Panes[x].ReadChildData(reader);
        }
        _headerStringId.ReadString(reader);
        for (x = 0; (x < _localStrings.Count); x = (x + 1)) {
          LocalStrings.Add(new LocalStringIdListSectionReferenceBlockBlock());
          LocalStrings[x].Read(reader);
        }
        for (x = 0; (x < _localStrings.Count); x = (x + 1)) {
          LocalStrings[x].ReadChildData(reader);
        }
        for (x = 0; (x < _localBitmaps.Count); x = (x + 1)) {
          LocalBitmaps.Add(new LocalBitmapReferenceBlockBlock());
          LocalBitmaps[x].Read(reader);
        }
        for (x = 0; (x < _localBitmaps.Count); x = (x + 1)) {
          LocalBitmaps[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _screenID.Write(bw);
        _buttonKeyType.Write(bw);
        _textColor.Write(bw);
        _stringListTag.Write(bw);
_panes.Count = Panes.Count;
        _panes.Write(bw);
        _shapeGroup.Write(bw);
        _unnamed0.Write(bw);
        _headerStringId.Write(bw);
_localStrings.Count = LocalStrings.Count;
        _localStrings.Write(bw);
_localBitmaps.Count = LocalBitmaps.Count;
        _localBitmaps.Write(bw);
        _sourceColor.Write(bw);
        _destinationColor.Write(bw);
        _accumulateZoomScaleX.Write(bw);
        _accumulateZoomScaleY.Write(bw);
        _refractionScaleX.Write(bw);
        _refractionScaleY.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _stringListTag.WriteString(writer);
        for (x = 0; (x < _panes.Count); x = (x + 1)) {
          Panes[x].Write(writer);
        }
        for (x = 0; (x < _panes.Count); x = (x + 1)) {
          Panes[x].WriteChildData(writer);
        }
        _headerStringId.WriteString(writer);
        for (x = 0; (x < _localStrings.Count); x = (x + 1)) {
          LocalStrings[x].Write(writer);
        }
        for (x = 0; (x < _localStrings.Count); x = (x + 1)) {
          LocalStrings[x].WriteChildData(writer);
        }
        for (x = 0; (x < _localBitmaps.Count); x = (x + 1)) {
          LocalBitmaps[x].Write(writer);
        }
        for (x = 0; (x < _localBitmaps.Count); x = (x + 1)) {
          LocalBitmaps[x].WriteChildData(writer);
        }
      }
    }
    public class WindowPaneReferenceBlockBlock : IBlock {
      private Pad _unnamed0;
      private Enum _animationIndex;
      private Block _buttons = new Block();
      private Block _listBlock = new Block();
      private Block _tableView = new Block();
      private Block _textBlocks = new Block();
      private Block _bitmapBlocks = new Block();
      private Block _modelSceneBlocks = new Block();
      private Block _text_MinusvalueBlocks = new Block();
      private Block _hudBlocks = new Block();
      private Block _playerBlocks = new Block();
      public BlockCollection<ButtonWidgetReferenceBlockBlock> _buttonsList = new BlockCollection<ButtonWidgetReferenceBlockBlock>();
      public BlockCollection<ListReferenceBlockBlock> _listBlockList = new BlockCollection<ListReferenceBlockBlock>();
      public BlockCollection<TableViewListReferenceBlockBlock> _tableViewList = new BlockCollection<TableViewListReferenceBlockBlock>();
      public BlockCollection<TextBlockReferenceBlockBlock> _textBlocksList = new BlockCollection<TextBlockReferenceBlockBlock>();
      public BlockCollection<BitmapBlockReferenceBlockBlock> _bitmapBlocksList = new BlockCollection<BitmapBlockReferenceBlockBlock>();
      public BlockCollection<UiModelSceneReferenceBlockBlock> _modelSceneBlocksList = new BlockCollection<UiModelSceneReferenceBlockBlock>();
      public BlockCollection<STextValuePairBlocksBlockUNUSEDBlock> _text_MinusvalueBlocksList = new BlockCollection<STextValuePairBlocksBlockUNUSEDBlock>();
      public BlockCollection<HudBlockReferenceBlockBlock> _hudBlocksList = new BlockCollection<HudBlockReferenceBlockBlock>();
      public BlockCollection<PlayerBlockReferenceBlockBlock> _playerBlocksList = new BlockCollection<PlayerBlockReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public WindowPaneReferenceBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._animationIndex = new Enum(2);
      }
      public BlockCollection<ButtonWidgetReferenceBlockBlock> Buttons {
        get {
          return this._buttonsList;
        }
      }
      public BlockCollection<ListReferenceBlockBlock> ListBlock {
        get {
          return this._listBlockList;
        }
      }
      public BlockCollection<TableViewListReferenceBlockBlock> TableView {
        get {
          return this._tableViewList;
        }
      }
      public BlockCollection<TextBlockReferenceBlockBlock> TextBlocks {
        get {
          return this._textBlocksList;
        }
      }
      public BlockCollection<BitmapBlockReferenceBlockBlock> BitmapBlocks {
        get {
          return this._bitmapBlocksList;
        }
      }
      public BlockCollection<UiModelSceneReferenceBlockBlock> ModelSceneBlocks {
        get {
          return this._modelSceneBlocksList;
        }
      }
      public BlockCollection<STextValuePairBlocksBlockUNUSEDBlock> Text_MinusvalueBlocks {
        get {
          return this._text_MinusvalueBlocksList;
        }
      }
      public BlockCollection<HudBlockReferenceBlockBlock> HudBlocks {
        get {
          return this._hudBlocksList;
        }
      }
      public BlockCollection<PlayerBlockReferenceBlockBlock> PlayerBlocks {
        get {
          return this._playerBlocksList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Buttons.BlockCount; x++)
{
  IBlock block = Buttons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ListBlock.BlockCount; x++)
{
  IBlock block = ListBlock.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TableView.BlockCount; x++)
{
  IBlock block = TableView.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TextBlocks.BlockCount; x++)
{
  IBlock block = TextBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BitmapBlocks.BlockCount; x++)
{
  IBlock block = BitmapBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ModelSceneBlocks.BlockCount; x++)
{
  IBlock block = ModelSceneBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Text_MinusvalueBlocks.BlockCount; x++)
{
  IBlock block = Text_MinusvalueBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HudBlocks.BlockCount; x++)
{
  IBlock block = HudBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerBlocks.BlockCount; x++)
{
  IBlock block = PlayerBlocks.GetBlock(x);
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
      public Enum AnimationIndex {
        get {
          return this._animationIndex;
        }
        set {
          this._animationIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _animationIndex.Read(reader);
        _buttons.Read(reader);
        _listBlock.Read(reader);
        _tableView.Read(reader);
        _textBlocks.Read(reader);
        _bitmapBlocks.Read(reader);
        _modelSceneBlocks.Read(reader);
        _text_MinusvalueBlocks.Read(reader);
        _hudBlocks.Read(reader);
        _playerBlocks.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _buttons.Count); x = (x + 1)) {
          Buttons.Add(new ButtonWidgetReferenceBlockBlock());
          Buttons[x].Read(reader);
        }
        for (x = 0; (x < _buttons.Count); x = (x + 1)) {
          Buttons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _listBlock.Count); x = (x + 1)) {
          ListBlock.Add(new ListReferenceBlockBlock());
          ListBlock[x].Read(reader);
        }
        for (x = 0; (x < _listBlock.Count); x = (x + 1)) {
          ListBlock[x].ReadChildData(reader);
        }
        for (x = 0; (x < _tableView.Count); x = (x + 1)) {
          TableView.Add(new TableViewListReferenceBlockBlock());
          TableView[x].Read(reader);
        }
        for (x = 0; (x < _tableView.Count); x = (x + 1)) {
          TableView[x].ReadChildData(reader);
        }
        for (x = 0; (x < _textBlocks.Count); x = (x + 1)) {
          TextBlocks.Add(new TextBlockReferenceBlockBlock());
          TextBlocks[x].Read(reader);
        }
        for (x = 0; (x < _textBlocks.Count); x = (x + 1)) {
          TextBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks.Add(new BitmapBlockReferenceBlockBlock());
          BitmapBlocks[x].Read(reader);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks.Add(new UiModelSceneReferenceBlockBlock());
          ModelSceneBlocks[x].Read(reader);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _text_MinusvalueBlocks.Count); x = (x + 1)) {
          Text_MinusvalueBlocks.Add(new STextValuePairBlocksBlockUNUSEDBlock());
          Text_MinusvalueBlocks[x].Read(reader);
        }
        for (x = 0; (x < _text_MinusvalueBlocks.Count); x = (x + 1)) {
          Text_MinusvalueBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _hudBlocks.Count); x = (x + 1)) {
          HudBlocks.Add(new HudBlockReferenceBlockBlock());
          HudBlocks[x].Read(reader);
        }
        for (x = 0; (x < _hudBlocks.Count); x = (x + 1)) {
          HudBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerBlocks.Count); x = (x + 1)) {
          PlayerBlocks.Add(new PlayerBlockReferenceBlockBlock());
          PlayerBlocks[x].Read(reader);
        }
        for (x = 0; (x < _playerBlocks.Count); x = (x + 1)) {
          PlayerBlocks[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _animationIndex.Write(bw);
_buttons.Count = Buttons.Count;
        _buttons.Write(bw);
_listBlock.Count = ListBlock.Count;
        _listBlock.Write(bw);
_tableView.Count = TableView.Count;
        _tableView.Write(bw);
_textBlocks.Count = TextBlocks.Count;
        _textBlocks.Write(bw);
_bitmapBlocks.Count = BitmapBlocks.Count;
        _bitmapBlocks.Write(bw);
_modelSceneBlocks.Count = ModelSceneBlocks.Count;
        _modelSceneBlocks.Write(bw);
_text_MinusvalueBlocks.Count = Text_MinusvalueBlocks.Count;
        _text_MinusvalueBlocks.Write(bw);
_hudBlocks.Count = HudBlocks.Count;
        _hudBlocks.Write(bw);
_playerBlocks.Count = PlayerBlocks.Count;
        _playerBlocks.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _buttons.Count); x = (x + 1)) {
          Buttons[x].Write(writer);
        }
        for (x = 0; (x < _buttons.Count); x = (x + 1)) {
          Buttons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _listBlock.Count); x = (x + 1)) {
          ListBlock[x].Write(writer);
        }
        for (x = 0; (x < _listBlock.Count); x = (x + 1)) {
          ListBlock[x].WriteChildData(writer);
        }
        for (x = 0; (x < _tableView.Count); x = (x + 1)) {
          TableView[x].Write(writer);
        }
        for (x = 0; (x < _tableView.Count); x = (x + 1)) {
          TableView[x].WriteChildData(writer);
        }
        for (x = 0; (x < _textBlocks.Count); x = (x + 1)) {
          TextBlocks[x].Write(writer);
        }
        for (x = 0; (x < _textBlocks.Count); x = (x + 1)) {
          TextBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].Write(writer);
        }
        for (x = 0; (x < _bitmapBlocks.Count); x = (x + 1)) {
          BitmapBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].Write(writer);
        }
        for (x = 0; (x < _modelSceneBlocks.Count); x = (x + 1)) {
          ModelSceneBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _text_MinusvalueBlocks.Count); x = (x + 1)) {
          Text_MinusvalueBlocks[x].Write(writer);
        }
        for (x = 0; (x < _text_MinusvalueBlocks.Count); x = (x + 1)) {
          Text_MinusvalueBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _hudBlocks.Count); x = (x + 1)) {
          HudBlocks[x].Write(writer);
        }
        for (x = 0; (x < _hudBlocks.Count); x = (x + 1)) {
          HudBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerBlocks.Count); x = (x + 1)) {
          PlayerBlocks[x].Write(writer);
        }
        for (x = 0; (x < _playerBlocks.Count); x = (x + 1)) {
          PlayerBlocks[x].WriteChildData(writer);
        }
      }
    }
    public class ButtonWidgetReferenceBlockBlock : IBlock {
      private Flags _textFlags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private Pad _unnamed0;
      private Enum _customFont;
      private RealARGBColor _textColor = new RealARGBColor();
      private Rectangle2D _bounds = new Rectangle2D();
      private TagReference _bitmap = new TagReference();
      private Point2D _bitmapOffset = new Point2D();
      private StringId _stringId = new StringId();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private ShortInteger _mouseRegionTopOffset = new ShortInteger();
      private Flags _buttonFlags;
public event System.EventHandler BlockNameChanged;
      public ButtonWidgetReferenceBlockBlock() {
        this._textFlags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._customFont = new Enum(2);
        this._buttonFlags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Flags TextFlags {
        get {
          return this._textFlags;
        }
        set {
          this._textFlags = value;
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
      public Enum CustomFont {
        get {
          return this._customFont;
        }
        set {
          this._customFont = value;
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
      public Rectangle2D Bounds {
        get {
          return this._bounds;
        }
        set {
          this._bounds = value;
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
      public Point2D BitmapOffset {
        get {
          return this._bitmapOffset;
        }
        set {
          this._bitmapOffset = value;
        }
      }
      public StringId StringId {
        get {
          return this._stringId;
        }
        set {
          this._stringId = value;
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
      public ShortInteger MouseRegionTopOffset {
        get {
          return this._mouseRegionTopOffset;
        }
        set {
          this._mouseRegionTopOffset = value;
        }
      }
      public Flags ButtonFlags {
        get {
          return this._buttonFlags;
        }
        set {
          this._buttonFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _textFlags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _unnamed0.Read(reader);
        _customFont.Read(reader);
        _textColor.Read(reader);
        _bounds.Read(reader);
        _bitmap.Read(reader);
        _bitmapOffset.Read(reader);
        _stringId.Read(reader);
        _renderDepthBias.Read(reader);
        _mouseRegionTopOffset.Read(reader);
        _buttonFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
        _stringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _textFlags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _unnamed0.Write(bw);
        _customFont.Write(bw);
        _textColor.Write(bw);
        _bounds.Write(bw);
        _bitmap.Write(bw);
        _bitmapOffset.Write(bw);
        _stringId.Write(bw);
        _renderDepthBias.Write(bw);
        _mouseRegionTopOffset.Write(bw);
        _buttonFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
        _stringId.WriteString(writer);
      }
    }
    public class ListReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _skinIndex;
      private ShortInteger _numVisibleItems = new ShortInteger();
      private Point2D _bottomLeft = new Point2D();
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private Block _uNUSED = new Block();
      public BlockCollection<STextValuePairReferenceBlockUNUSEDBlock> _uNUSEDList = new BlockCollection<STextValuePairReferenceBlockUNUSEDBlock>();
public event System.EventHandler BlockNameChanged;
      public ListReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._skinIndex = new Enum(2);
        this._animationIndex = new Enum(2);
      }
      public BlockCollection<STextValuePairReferenceBlockUNUSEDBlock> UNUSED {
        get {
          return this._uNUSEDList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<UNUSED.BlockCount; x++)
{
  IBlock block = UNUSED.GetBlock(x);
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
      public Enum SkinIndex {
        get {
          return this._skinIndex;
        }
        set {
          this._skinIndex = value;
        }
      }
      public ShortInteger NumVisibleItems {
        get {
          return this._numVisibleItems;
        }
        set {
          this._numVisibleItems = value;
        }
      }
      public Point2D BottomLeft {
        get {
          return this._bottomLeft;
        }
        set {
          this._bottomLeft = value;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _skinIndex.Read(reader);
        _numVisibleItems.Read(reader);
        _bottomLeft.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _uNUSED.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _uNUSED.Count); x = (x + 1)) {
          UNUSED.Add(new STextValuePairReferenceBlockUNUSEDBlock());
          UNUSED[x].Read(reader);
        }
        for (x = 0; (x < _uNUSED.Count); x = (x + 1)) {
          UNUSED[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _skinIndex.Write(bw);
        _numVisibleItems.Write(bw);
        _bottomLeft.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
_uNUSED.Count = UNUSED.Count;
        _uNUSED.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _uNUSED.Count); x = (x + 1)) {
          UNUSED[x].Write(writer);
        }
        for (x = 0; (x < _uNUSED.Count); x = (x + 1)) {
          UNUSED[x].WriteChildData(writer);
        }
      }
    }
    public class STextValuePairReferenceBlockUNUSEDBlock : IBlock {
      private Enum _valueType;
      private Enum _booleanValue;
      private LongInteger _integerValue = new LongInteger();
      private Real _fpValue = new Real();
      private StringId _textValueStringid = new StringId();
      private StringId _textLabelStringid = new StringId();
public event System.EventHandler BlockNameChanged;
      public STextValuePairReferenceBlockUNUSEDBlock() {
        this._valueType = new Enum(2);
        this._booleanValue = new Enum(2);
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
      public Enum ValueType {
        get {
          return this._valueType;
        }
        set {
          this._valueType = value;
        }
      }
      public Enum BooleanValue {
        get {
          return this._booleanValue;
        }
        set {
          this._booleanValue = value;
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
      public Real FpValue {
        get {
          return this._fpValue;
        }
        set {
          this._fpValue = value;
        }
      }
      public StringId TextValueStringid {
        get {
          return this._textValueStringid;
        }
        set {
          this._textValueStringid = value;
        }
      }
      public StringId TextLabelStringid {
        get {
          return this._textLabelStringid;
        }
        set {
          this._textLabelStringid = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _valueType.Read(reader);
        _booleanValue.Read(reader);
        _integerValue.Read(reader);
        _fpValue.Read(reader);
        _textValueStringid.Read(reader);
        _textLabelStringid.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _textValueStringid.ReadString(reader);
        _textLabelStringid.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _valueType.Write(bw);
        _booleanValue.Write(bw);
        _integerValue.Write(bw);
        _fpValue.Write(bw);
        _textValueStringid.Write(bw);
        _textLabelStringid.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _textValueStringid.WriteString(writer);
        _textLabelStringid.WriteString(writer);
      }
    }
    public class TableViewListReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private Enum _customFont;
      private Pad _unnamed0;
      private RealARGBColor _textColor = new RealARGBColor();
      private Point2D _top_Minusleft = new Point2D();
      private Block _tableRows = new Block();
      public BlockCollection<TableViewListRowReferenceBlockBlock> _tableRowsList = new BlockCollection<TableViewListRowReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public TableViewListReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._customFont = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<TableViewListRowReferenceBlockBlock> TableRows {
        get {
          return this._tableRowsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<TableRows.BlockCount; x++)
{
  IBlock block = TableRows.GetBlock(x);
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
      public Enum CustomFont {
        get {
          return this._customFont;
        }
        set {
          this._customFont = value;
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
      public Point2D Top_Minusleft {
        get {
          return this._top_Minusleft;
        }
        set {
          this._top_Minusleft = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _customFont.Read(reader);
        _unnamed0.Read(reader);
        _textColor.Read(reader);
        _top_Minusleft.Read(reader);
        _tableRows.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _tableRows.Count); x = (x + 1)) {
          TableRows.Add(new TableViewListRowReferenceBlockBlock());
          TableRows[x].Read(reader);
        }
        for (x = 0; (x < _tableRows.Count); x = (x + 1)) {
          TableRows[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _customFont.Write(bw);
        _unnamed0.Write(bw);
        _textColor.Write(bw);
        _top_Minusleft.Write(bw);
_tableRows.Count = TableRows.Count;
        _tableRows.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _tableRows.Count); x = (x + 1)) {
          TableRows[x].Write(writer);
        }
        for (x = 0; (x < _tableRows.Count); x = (x + 1)) {
          TableRows[x].WriteChildData(writer);
        }
      }
    }
    public class TableViewListRowReferenceBlockBlock : IBlock {
      private Flags _flags;
      private ShortInteger _rowHeight = new ShortInteger();
      private Pad _unnamed0;
      private Block _rowCells = new Block();
      public BlockCollection<TableViewListItemReferenceBlockBlock> _rowCellsList = new BlockCollection<TableViewListItemReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public TableViewListRowReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<TableViewListItemReferenceBlockBlock> RowCells {
        get {
          return this._rowCellsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<RowCells.BlockCount; x++)
{
  IBlock block = RowCells.GetBlock(x);
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
      public ShortInteger RowHeight {
        get {
          return this._rowHeight;
        }
        set {
          this._rowHeight = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _rowHeight.Read(reader);
        _unnamed0.Read(reader);
        _rowCells.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _rowCells.Count); x = (x + 1)) {
          RowCells.Add(new TableViewListItemReferenceBlockBlock());
          RowCells[x].Read(reader);
        }
        for (x = 0; (x < _rowCells.Count); x = (x + 1)) {
          RowCells[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _rowHeight.Write(bw);
        _unnamed0.Write(bw);
_rowCells.Count = RowCells.Count;
        _rowCells.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _rowCells.Count); x = (x + 1)) {
          RowCells[x].Write(writer);
        }
        for (x = 0; (x < _rowCells.Count); x = (x + 1)) {
          RowCells[x].WriteChildData(writer);
        }
      }
    }
    public class TableViewListItemReferenceBlockBlock : IBlock {
      private Flags _textFlags;
      private ShortInteger _cellWidth = new ShortInteger();
      private Pad _unnamed0;
      private Point2D _bitmapTop_Minusleft = new Point2D();
      private TagReference _bitmapTag = new TagReference();
      private StringId _stringId = new StringId();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public TableViewListItemReferenceBlockBlock() {
        this._textFlags = new Flags(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
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
      public Flags TextFlags {
        get {
          return this._textFlags;
        }
        set {
          this._textFlags = value;
        }
      }
      public ShortInteger CellWidth {
        get {
          return this._cellWidth;
        }
        set {
          this._cellWidth = value;
        }
      }
      public Point2D BitmapTop_Minusleft {
        get {
          return this._bitmapTop_Minusleft;
        }
        set {
          this._bitmapTop_Minusleft = value;
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
      public StringId StringId {
        get {
          return this._stringId;
        }
        set {
          this._stringId = value;
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
        _textFlags.Read(reader);
        _cellWidth.Read(reader);
        _unnamed0.Read(reader);
        _bitmapTop_Minusleft.Read(reader);
        _bitmapTag.Read(reader);
        _stringId.Read(reader);
        _renderDepthBias.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmapTag.ReadString(reader);
        _stringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _textFlags.Write(bw);
        _cellWidth.Write(bw);
        _unnamed0.Write(bw);
        _bitmapTop_Minusleft.Write(bw);
        _bitmapTag.Write(bw);
        _stringId.Write(bw);
        _renderDepthBias.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmapTag.WriteString(writer);
        _stringId.WriteString(writer);
      }
    }
    public class TextBlockReferenceBlockBlock : IBlock {
      private Flags _textFlags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private Pad _unnamed0;
      private Enum _customFont;
      private RealARGBColor _textColor = new RealARGBColor();
      private Rectangle2D _textBounds = new Rectangle2D();
      private StringId _stringId = new StringId();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public TextBlockReferenceBlockBlock() {
        this._textFlags = new Flags(4);
        this._animationIndex = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._customFont = new Enum(2);
        this._unnamed1 = new Pad(2);
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
      public Flags TextFlags {
        get {
          return this._textFlags;
        }
        set {
          this._textFlags = value;
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
      public Enum CustomFont {
        get {
          return this._customFont;
        }
        set {
          this._customFont = value;
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
      public Rectangle2D TextBounds {
        get {
          return this._textBounds;
        }
        set {
          this._textBounds = value;
        }
      }
      public StringId StringId {
        get {
          return this._stringId;
        }
        set {
          this._stringId = value;
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
        _textFlags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _unnamed0.Read(reader);
        _customFont.Read(reader);
        _textColor.Read(reader);
        _textBounds.Read(reader);
        _stringId.Read(reader);
        _renderDepthBias.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _stringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _textFlags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _unnamed0.Write(bw);
        _customFont.Write(bw);
        _textColor.Write(bw);
        _textBounds.Write(bw);
        _stringId.Write(bw);
        _renderDepthBias.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _stringId.WriteString(writer);
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
    public class STextValuePairBlocksBlockUNUSEDBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Block _textValuePairs = new Block();
      public BlockCollection<STextValuePairReferenceBlockUNUSEDBlock> _textValuePairsList = new BlockCollection<STextValuePairReferenceBlockUNUSEDBlock>();
public event System.EventHandler BlockNameChanged;
      public STextValuePairBlocksBlockUNUSEDBlock() {
      }
      public BlockCollection<STextValuePairReferenceBlockUNUSEDBlock> TextValuePairs {
        get {
          return this._textValuePairsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<TextValuePairs.BlockCount; x++)
{
  IBlock block = TextValuePairs.GetBlock(x);
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
        _textValuePairs.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs.Add(new STextValuePairReferenceBlockUNUSEDBlock());
          TextValuePairs[x].Read(reader);
        }
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_textValuePairs.Count = TextValuePairs.Count;
        _textValuePairs.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].Write(writer);
        }
        for (x = 0; (x < _textValuePairs.Count); x = (x + 1)) {
          TextValuePairs[x].WriteChildData(writer);
        }
      }
    }
    public class HudBlockReferenceBlockBlock : IBlock {
      private Flags _flags;
      private Enum _animationIndex;
      private ShortInteger _introAnimationDelayMilliseconds = new ShortInteger();
      private ShortInteger _renderDepthBias = new ShortInteger();
      private ShortInteger _startingBitmapSequenceIndex = new ShortInteger();
      private TagReference _bitmap = new TagReference();
      private TagReference _shader = new TagReference();
      private Rectangle2D _bounds = new Rectangle2D();
public event System.EventHandler BlockNameChanged;
      public HudBlockReferenceBlockBlock() {
        this._flags = new Flags(4);
        this._animationIndex = new Enum(2);
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
      public ShortInteger StartingBitmapSequenceIndex {
        get {
          return this._startingBitmapSequenceIndex;
        }
        set {
          this._startingBitmapSequenceIndex = value;
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
      public Rectangle2D Bounds {
        get {
          return this._bounds;
        }
        set {
          this._bounds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationIndex.Read(reader);
        _introAnimationDelayMilliseconds.Read(reader);
        _renderDepthBias.Read(reader);
        _startingBitmapSequenceIndex.Read(reader);
        _bitmap.Read(reader);
        _shader.Read(reader);
        _bounds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
        _shader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationIndex.Write(bw);
        _introAnimationDelayMilliseconds.Write(bw);
        _renderDepthBias.Write(bw);
        _startingBitmapSequenceIndex.Write(bw);
        _bitmap.Write(bw);
        _shader.Write(bw);
        _bounds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
        _shader.WriteString(writer);
      }
    }
    public class PlayerBlockReferenceBlockBlock : IBlock {
      private Pad _unnamed0;
      private TagReference _skin = new TagReference();
      private Point2D _bottom_Minusleft = new Point2D();
      private Enum _tableOrder;
      private CharInteger _maximumPlayerCount = new CharInteger();
      private CharInteger _rowCount = new CharInteger();
      private CharInteger _columnCount = new CharInteger();
      private ShortInteger _rowHeight = new ShortInteger();
      private ShortInteger _columnWidth = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PlayerBlockReferenceBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._tableOrder = new Enum(1);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_skin.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Skin {
        get {
          return this._skin;
        }
        set {
          this._skin = value;
        }
      }
      public Point2D Bottom_Minusleft {
        get {
          return this._bottom_Minusleft;
        }
        set {
          this._bottom_Minusleft = value;
        }
      }
      public Enum TableOrder {
        get {
          return this._tableOrder;
        }
        set {
          this._tableOrder = value;
        }
      }
      public CharInteger MaximumPlayerCount {
        get {
          return this._maximumPlayerCount;
        }
        set {
          this._maximumPlayerCount = value;
        }
      }
      public CharInteger RowCount {
        get {
          return this._rowCount;
        }
        set {
          this._rowCount = value;
        }
      }
      public CharInteger ColumnCount {
        get {
          return this._columnCount;
        }
        set {
          this._columnCount = value;
        }
      }
      public ShortInteger RowHeight {
        get {
          return this._rowHeight;
        }
        set {
          this._rowHeight = value;
        }
      }
      public ShortInteger ColumnWidth {
        get {
          return this._columnWidth;
        }
        set {
          this._columnWidth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _skin.Read(reader);
        _bottom_Minusleft.Read(reader);
        _tableOrder.Read(reader);
        _maximumPlayerCount.Read(reader);
        _rowCount.Read(reader);
        _columnCount.Read(reader);
        _rowHeight.Read(reader);
        _columnWidth.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _skin.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _skin.Write(bw);
        _bottom_Minusleft.Write(bw);
        _tableOrder.Write(bw);
        _maximumPlayerCount.Write(bw);
        _rowCount.Write(bw);
        _columnCount.Write(bw);
        _rowHeight.Write(bw);
        _columnWidth.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _skin.WriteString(writer);
      }
    }
    public class LocalStringIdListSectionReferenceBlockBlock : IBlock {
      private StringId _sectionName = new StringId();
      private Block _localStringSectionReferences = new Block();
      public BlockCollection<LocalStringIdListStringReferenceBlockBlock> _localStringSectionReferencesList = new BlockCollection<LocalStringIdListStringReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public LocalStringIdListSectionReferenceBlockBlock() {
if (this._sectionName is System.ComponentModel.INotifyPropertyChanged)
  (this._sectionName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<LocalStringIdListStringReferenceBlockBlock> LocalStringSectionReferences {
        get {
          return this._localStringSectionReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<LocalStringSectionReferences.BlockCount; x++)
{
  IBlock block = LocalStringSectionReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sectionName.ToString();
        }
      }
      public StringId SectionName {
        get {
          return this._sectionName;
        }
        set {
          this._sectionName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectionName.Read(reader);
        _localStringSectionReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _sectionName.ReadString(reader);
        for (x = 0; (x < _localStringSectionReferences.Count); x = (x + 1)) {
          LocalStringSectionReferences.Add(new LocalStringIdListStringReferenceBlockBlock());
          LocalStringSectionReferences[x].Read(reader);
        }
        for (x = 0; (x < _localStringSectionReferences.Count); x = (x + 1)) {
          LocalStringSectionReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _sectionName.Write(bw);
_localStringSectionReferences.Count = LocalStringSectionReferences.Count;
        _localStringSectionReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _sectionName.WriteString(writer);
        for (x = 0; (x < _localStringSectionReferences.Count); x = (x + 1)) {
          LocalStringSectionReferences[x].Write(writer);
        }
        for (x = 0; (x < _localStringSectionReferences.Count); x = (x + 1)) {
          LocalStringSectionReferences[x].WriteChildData(writer);
        }
      }
    }
    public class LocalStringIdListStringReferenceBlockBlock : IBlock {
      private StringId _stringId = new StringId();
public event System.EventHandler BlockNameChanged;
      public LocalStringIdListStringReferenceBlockBlock() {
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
      public StringId StringId {
        get {
          return this._stringId;
        }
        set {
          this._stringId = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stringId.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _stringId.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _stringId.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _stringId.WriteString(writer);
      }
    }
    public class LocalBitmapReferenceBlockBlock : IBlock {
      private TagReference _bitmap = new TagReference();
public event System.EventHandler BlockNameChanged;
      public LocalBitmapReferenceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
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
      public virtual void Read(BinaryReader reader) {
        _bitmap.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _bitmap.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
      }
    }
  }
}
