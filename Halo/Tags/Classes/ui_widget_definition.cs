// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'ui_widget_definition'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class ui_widget_definition : Interfaces.Pool.Tag {
    private UiWidgetDefinitionBlock uiWidgetDefinitionValues = new UiWidgetDefinitionBlock();
    public virtual UiWidgetDefinitionBlock UiWidgetDefinitionValues {
      get {
        return uiWidgetDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UiWidgetDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "ui_widget_definition";
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
uiWidgetDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
uiWidgetDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
uiWidgetDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
uiWidgetDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class UiWidgetDefinitionBlock : IBlock {
      private Enum _widgetType = new Enum();
      private Enum _controllerIndex = new Enum();
      private FixedLengthString _name = new FixedLengthString();
      private Rectangle2D _bounds = new Rectangle2D();
      private Flags _flags;
      private LongInteger _millisecondsToAutoClose = new LongInteger();
      private LongInteger _millisecondsAutoCloseFadeTime = new LongInteger();
      private TagReference _backgroundBitmap = new TagReference();
      private Block _gameDataInputs = new Block();
      private Block _eventHandlers = new Block();
      private Block _searchAndReplaceFunctions = new Block();
      private Pad _unnamed;
      private TagReference _textLabelUnicodeStringsList = new TagReference();
      private TagReference _textFont = new TagReference();
      private RealARGBColor _textColor = new RealARGBColor();
      private Enum _justification = new Enum();
      private Flags _flags2;
      private Pad _unnamed2;
      private ShortInteger _stringListIndex = new ShortInteger();
      private ShortInteger _horizOffset = new ShortInteger();
      private ShortInteger _vertOffset = new ShortInteger();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Flags _flags3;
      private TagReference _listHeaderBitmap = new TagReference();
      private TagReference _listFooterBitmap = new TagReference();
      private Rectangle2D _headerBounds = new Rectangle2D();
      private Rectangle2D _footerBounds = new Rectangle2D();
      private Pad _unnamed5;
      private TagReference _extendedDescriptionWidget = new TagReference();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Block _conditionalWidgets = new Block();
      private Pad _unnamed8;
      private Pad _unnamed9;
      private Block _childWidgets = new Block();
      public BlockCollection<GameDataInputReferencesBlock> _gameDataInputsList = new BlockCollection<GameDataInputReferencesBlock>();
      public BlockCollection<EventHandlerReferencesBlock> _eventHandlersList = new BlockCollection<EventHandlerReferencesBlock>();
      public BlockCollection<SearchAndReplaceReferenceBlock> _searchAndReplaceFunctionsList = new BlockCollection<SearchAndReplaceReferenceBlock>();
      public BlockCollection<ConditionalWidgetReferenceBlock> _conditionalWidgetsList = new BlockCollection<ConditionalWidgetReferenceBlock>();
      public BlockCollection<ChildWidgetReferenceBlock> _childWidgetsList = new BlockCollection<ChildWidgetReferenceBlock>();
public event System.EventHandler BlockNameChanged;
      public UiWidgetDefinitionBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(128);
        this._flags2 = new Flags(4);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(26);
        this._unnamed4 = new Pad(2);
        this._flags3 = new Flags(4);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(32);
        this._unnamed7 = new Pad(256);
        this._unnamed8 = new Pad(128);
        this._unnamed9 = new Pad(128);
      }
      public BlockCollection<GameDataInputReferencesBlock> GameDataInputs {
        get {
          return this._gameDataInputsList;
        }
      }
      public BlockCollection<EventHandlerReferencesBlock> EventHandlers {
        get {
          return this._eventHandlersList;
        }
      }
      public BlockCollection<SearchAndReplaceReferenceBlock> SearchAndReplaceFunctions {
        get {
          return this._searchAndReplaceFunctionsList;
        }
      }
      public BlockCollection<ConditionalWidgetReferenceBlock> ConditionalWidgets {
        get {
          return this._conditionalWidgetsList;
        }
      }
      public BlockCollection<ChildWidgetReferenceBlock> ChildWidgets {
        get {
          return this._childWidgetsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundBitmap.Value);
references.Add(_textLabelUnicodeStringsList.Value);
references.Add(_textFont.Value);
references.Add(_listHeaderBitmap.Value);
references.Add(_listFooterBitmap.Value);
references.Add(_extendedDescriptionWidget.Value);
for (int x=0; x<GameDataInputs.BlockCount; x++)
{
  IBlock block = GameDataInputs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EventHandlers.BlockCount; x++)
{
  IBlock block = EventHandlers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SearchAndReplaceFunctions.BlockCount; x++)
{
  IBlock block = SearchAndReplaceFunctions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ConditionalWidgets.BlockCount; x++)
{
  IBlock block = ConditionalWidgets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ChildWidgets.BlockCount; x++)
{
  IBlock block = ChildWidgets.GetBlock(x);
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
      public Enum WidgetType {
        get {
          return this._widgetType;
        }
        set {
          this._widgetType = value;
        }
      }
      public Enum ControllerIndex {
        get {
          return this._controllerIndex;
        }
        set {
          this._controllerIndex = value;
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
      public Rectangle2D Bounds {
        get {
          return this._bounds;
        }
        set {
          this._bounds = value;
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
      public LongInteger MillisecondsToAutoClose {
        get {
          return this._millisecondsToAutoClose;
        }
        set {
          this._millisecondsToAutoClose = value;
        }
      }
      public LongInteger MillisecondsAutoCloseFadeTime {
        get {
          return this._millisecondsAutoCloseFadeTime;
        }
        set {
          this._millisecondsAutoCloseFadeTime = value;
        }
      }
      public TagReference BackgroundBitmap {
        get {
          return this._backgroundBitmap;
        }
        set {
          this._backgroundBitmap = value;
        }
      }
      public TagReference TextLabelUnicodeStringsList {
        get {
          return this._textLabelUnicodeStringsList;
        }
        set {
          this._textLabelUnicodeStringsList = value;
        }
      }
      public TagReference TextFont {
        get {
          return this._textFont;
        }
        set {
          this._textFont = value;
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
      public Enum Justification {
        get {
          return this._justification;
        }
        set {
          this._justification = value;
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
      public ShortInteger StringListIndex {
        get {
          return this._stringListIndex;
        }
        set {
          this._stringListIndex = value;
        }
      }
      public ShortInteger HorizOffset {
        get {
          return this._horizOffset;
        }
        set {
          this._horizOffset = value;
        }
      }
      public ShortInteger VertOffset {
        get {
          return this._vertOffset;
        }
        set {
          this._vertOffset = value;
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
      public TagReference ListHeaderBitmap {
        get {
          return this._listHeaderBitmap;
        }
        set {
          this._listHeaderBitmap = value;
        }
      }
      public TagReference ListFooterBitmap {
        get {
          return this._listFooterBitmap;
        }
        set {
          this._listFooterBitmap = value;
        }
      }
      public Rectangle2D HeaderBounds {
        get {
          return this._headerBounds;
        }
        set {
          this._headerBounds = value;
        }
      }
      public Rectangle2D FooterBounds {
        get {
          return this._footerBounds;
        }
        set {
          this._footerBounds = value;
        }
      }
      public TagReference ExtendedDescriptionWidget {
        get {
          return this._extendedDescriptionWidget;
        }
        set {
          this._extendedDescriptionWidget = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _widgetType.Read(reader);
        _controllerIndex.Read(reader);
        _name.Read(reader);
        _bounds.Read(reader);
        _flags.Read(reader);
        _millisecondsToAutoClose.Read(reader);
        _millisecondsAutoCloseFadeTime.Read(reader);
        _backgroundBitmap.Read(reader);
        _gameDataInputs.Read(reader);
        _eventHandlers.Read(reader);
        _searchAndReplaceFunctions.Read(reader);
        _unnamed.Read(reader);
        _textLabelUnicodeStringsList.Read(reader);
        _textFont.Read(reader);
        _textColor.Read(reader);
        _justification.Read(reader);
        _flags2.Read(reader);
        _unnamed2.Read(reader);
        _stringListIndex.Read(reader);
        _horizOffset.Read(reader);
        _vertOffset.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _flags3.Read(reader);
        _listHeaderBitmap.Read(reader);
        _listFooterBitmap.Read(reader);
        _headerBounds.Read(reader);
        _footerBounds.Read(reader);
        _unnamed5.Read(reader);
        _extendedDescriptionWidget.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _conditionalWidgets.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _childWidgets.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _backgroundBitmap.ReadString(reader);
        for (x = 0; (x < _gameDataInputs.Count); x = (x + 1)) {
          GameDataInputs.Add(new GameDataInputReferencesBlock());
          GameDataInputs[x].Read(reader);
        }
        for (x = 0; (x < _gameDataInputs.Count); x = (x + 1)) {
          GameDataInputs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _eventHandlers.Count); x = (x + 1)) {
          EventHandlers.Add(new EventHandlerReferencesBlock());
          EventHandlers[x].Read(reader);
        }
        for (x = 0; (x < _eventHandlers.Count); x = (x + 1)) {
          EventHandlers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _searchAndReplaceFunctions.Count); x = (x + 1)) {
          SearchAndReplaceFunctions.Add(new SearchAndReplaceReferenceBlock());
          SearchAndReplaceFunctions[x].Read(reader);
        }
        for (x = 0; (x < _searchAndReplaceFunctions.Count); x = (x + 1)) {
          SearchAndReplaceFunctions[x].ReadChildData(reader);
        }
        _textLabelUnicodeStringsList.ReadString(reader);
        _textFont.ReadString(reader);
        _listHeaderBitmap.ReadString(reader);
        _listFooterBitmap.ReadString(reader);
        _extendedDescriptionWidget.ReadString(reader);
        for (x = 0; (x < _conditionalWidgets.Count); x = (x + 1)) {
          ConditionalWidgets.Add(new ConditionalWidgetReferenceBlock());
          ConditionalWidgets[x].Read(reader);
        }
        for (x = 0; (x < _conditionalWidgets.Count); x = (x + 1)) {
          ConditionalWidgets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _childWidgets.Count); x = (x + 1)) {
          ChildWidgets.Add(new ChildWidgetReferenceBlock());
          ChildWidgets[x].Read(reader);
        }
        for (x = 0; (x < _childWidgets.Count); x = (x + 1)) {
          ChildWidgets[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _widgetType.Write(bw);
        _controllerIndex.Write(bw);
        _name.Write(bw);
        _bounds.Write(bw);
        _flags.Write(bw);
        _millisecondsToAutoClose.Write(bw);
        _millisecondsAutoCloseFadeTime.Write(bw);
        _backgroundBitmap.Write(bw);
_gameDataInputs.Count = GameDataInputs.Count;
        _gameDataInputs.Write(bw);
_eventHandlers.Count = EventHandlers.Count;
        _eventHandlers.Write(bw);
_searchAndReplaceFunctions.Count = SearchAndReplaceFunctions.Count;
        _searchAndReplaceFunctions.Write(bw);
        _unnamed.Write(bw);
        _textLabelUnicodeStringsList.Write(bw);
        _textFont.Write(bw);
        _textColor.Write(bw);
        _justification.Write(bw);
        _flags2.Write(bw);
        _unnamed2.Write(bw);
        _stringListIndex.Write(bw);
        _horizOffset.Write(bw);
        _vertOffset.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _flags3.Write(bw);
        _listHeaderBitmap.Write(bw);
        _listFooterBitmap.Write(bw);
        _headerBounds.Write(bw);
        _footerBounds.Write(bw);
        _unnamed5.Write(bw);
        _extendedDescriptionWidget.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
_conditionalWidgets.Count = ConditionalWidgets.Count;
        _conditionalWidgets.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
_childWidgets.Count = ChildWidgets.Count;
        _childWidgets.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _backgroundBitmap.WriteString(writer);
        for (x = 0; (x < _gameDataInputs.Count); x = (x + 1)) {
          GameDataInputs[x].Write(writer);
        }
        for (x = 0; (x < _gameDataInputs.Count); x = (x + 1)) {
          GameDataInputs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _eventHandlers.Count); x = (x + 1)) {
          EventHandlers[x].Write(writer);
        }
        for (x = 0; (x < _eventHandlers.Count); x = (x + 1)) {
          EventHandlers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _searchAndReplaceFunctions.Count); x = (x + 1)) {
          SearchAndReplaceFunctions[x].Write(writer);
        }
        for (x = 0; (x < _searchAndReplaceFunctions.Count); x = (x + 1)) {
          SearchAndReplaceFunctions[x].WriteChildData(writer);
        }
        _textLabelUnicodeStringsList.WriteString(writer);
        _textFont.WriteString(writer);
        _listHeaderBitmap.WriteString(writer);
        _listFooterBitmap.WriteString(writer);
        _extendedDescriptionWidget.WriteString(writer);
        for (x = 0; (x < _conditionalWidgets.Count); x = (x + 1)) {
          ConditionalWidgets[x].Write(writer);
        }
        for (x = 0; (x < _conditionalWidgets.Count); x = (x + 1)) {
          ConditionalWidgets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _childWidgets.Count); x = (x + 1)) {
          ChildWidgets[x].Write(writer);
        }
        for (x = 0; (x < _childWidgets.Count); x = (x + 1)) {
          ChildWidgets[x].WriteChildData(writer);
        }
      }
    }
    public class GameDataInputReferencesBlock : IBlock {
      private Enum _function = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public GameDataInputReferencesBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
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
      public Enum Function {
        get {
          return this._function;
        }
        set {
          this._function = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _function.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _function.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EventHandlerReferencesBlock : IBlock {
      private Flags _flags;
      private Enum _eventType = new Enum();
      private Enum _function = new Enum();
      private TagReference _widgetTag = new TagReference();
      private TagReference _soundEffect = new TagReference();
      private FixedLengthString _script = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public EventHandlerReferencesBlock() {
        this._flags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_widgetTag.Value);
references.Add(_soundEffect.Value);
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
      public Enum EventType {
        get {
          return this._eventType;
        }
        set {
          this._eventType = value;
        }
      }
      public Enum Function {
        get {
          return this._function;
        }
        set {
          this._function = value;
        }
      }
      public TagReference WidgetTag {
        get {
          return this._widgetTag;
        }
        set {
          this._widgetTag = value;
        }
      }
      public TagReference SoundEffect {
        get {
          return this._soundEffect;
        }
        set {
          this._soundEffect = value;
        }
      }
      public FixedLengthString Script {
        get {
          return this._script;
        }
        set {
          this._script = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _eventType.Read(reader);
        _function.Read(reader);
        _widgetTag.Read(reader);
        _soundEffect.Read(reader);
        _script.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _widgetTag.ReadString(reader);
        _soundEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _eventType.Write(bw);
        _function.Write(bw);
        _widgetTag.Write(bw);
        _soundEffect.Write(bw);
        _script.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _widgetTag.WriteString(writer);
        _soundEffect.WriteString(writer);
      }
    }
    public class SearchAndReplaceReferenceBlock : IBlock {
      private FixedLengthString _searchString = new FixedLengthString();
      private Enum _replaceFunction = new Enum();
public event System.EventHandler BlockNameChanged;
      public SearchAndReplaceReferenceBlock() {
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
      public FixedLengthString SearchString {
        get {
          return this._searchString;
        }
        set {
          this._searchString = value;
        }
      }
      public Enum ReplaceFunction {
        get {
          return this._replaceFunction;
        }
        set {
          this._replaceFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _searchString.Read(reader);
        _replaceFunction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _searchString.Write(bw);
        _replaceFunction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ConditionalWidgetReferenceBlock : IBlock {
      private TagReference _widgetTag = new TagReference();
      private FixedLengthString _nameUnused = new FixedLengthString();
      private Flags _flags;
      private ShortInteger _customControllerIndexUnused = new ShortInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ConditionalWidgetReferenceBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(26);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_widgetTag.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference WidgetTag {
        get {
          return this._widgetTag;
        }
        set {
          this._widgetTag = value;
        }
      }
      public FixedLengthString NameUnused {
        get {
          return this._nameUnused;
        }
        set {
          this._nameUnused = value;
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
      public ShortInteger CustomControllerIndexUnused {
        get {
          return this._customControllerIndexUnused;
        }
        set {
          this._customControllerIndexUnused = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _widgetTag.Read(reader);
        _nameUnused.Read(reader);
        _flags.Read(reader);
        _customControllerIndexUnused.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _widgetTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _widgetTag.Write(bw);
        _nameUnused.Write(bw);
        _flags.Write(bw);
        _customControllerIndexUnused.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _widgetTag.WriteString(writer);
      }
    }
    public class ChildWidgetReferenceBlock : IBlock {
      private TagReference _widgetTag = new TagReference();
      private FixedLengthString _nameUnused = new FixedLengthString();
      private Flags _flags;
      private ShortInteger _customControllerIndex = new ShortInteger();
      private ShortInteger _verticalOffset = new ShortInteger();
      private ShortInteger _horizontalOffset = new ShortInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ChildWidgetReferenceBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(22);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_widgetTag.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference WidgetTag {
        get {
          return this._widgetTag;
        }
        set {
          this._widgetTag = value;
        }
      }
      public FixedLengthString NameUnused {
        get {
          return this._nameUnused;
        }
        set {
          this._nameUnused = value;
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
      public ShortInteger CustomControllerIndex {
        get {
          return this._customControllerIndex;
        }
        set {
          this._customControllerIndex = value;
        }
      }
      public ShortInteger VerticalOffset {
        get {
          return this._verticalOffset;
        }
        set {
          this._verticalOffset = value;
        }
      }
      public ShortInteger HorizontalOffset {
        get {
          return this._horizontalOffset;
        }
        set {
          this._horizontalOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _widgetTag.Read(reader);
        _nameUnused.Read(reader);
        _flags.Read(reader);
        _customControllerIndex.Read(reader);
        _verticalOffset.Read(reader);
        _horizontalOffset.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _widgetTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _widgetTag.Write(bw);
        _nameUnused.Write(bw);
        _flags.Write(bw);
        _customControllerIndex.Write(bw);
        _verticalOffset.Write(bw);
        _horizontalOffset.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _widgetTag.WriteString(writer);
      }
    }
  }
}
