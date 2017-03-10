// --------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'user_interface_list_skin_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// --------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class user_interface_list_skin_definition : Interfaces.Pool.Tag {
    private UserInterfaceListSkinDefinitionBlockBlock userInterfaceListSkinDefinitionValues = new UserInterfaceListSkinDefinitionBlockBlock();
    public virtual UserInterfaceListSkinDefinitionBlockBlock UserInterfaceListSkinDefinitionValues {
      get {
        return userInterfaceListSkinDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UserInterfaceListSkinDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "user_interface_list_skin_definition";
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
userInterfaceListSkinDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
userInterfaceListSkinDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
userInterfaceListSkinDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
userInterfaceListSkinDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class UserInterfaceListSkinDefinitionBlockBlock : IBlock {
      private Flags _listFlags;
      private TagReference _arrowsBitmap = new TagReference();
      private Point2D _up_MinusarrowsOffset = new Point2D();
      private Point2D _down_MinusarrowsOffset = new Point2D();
      private Block _itemAnimations = new Block();
      private Block _textBlocks = new Block();
      private Block _bitmapBlocks = new Block();
      private Block _hudBlocks = new Block();
      private Block _playerBlocks = new Block();
      public BlockCollection<SingleAnimationReferenceBlockBlock> _itemAnimationsList = new BlockCollection<SingleAnimationReferenceBlockBlock>();
      public BlockCollection<TextBlockReferenceBlockBlock> _textBlocksList = new BlockCollection<TextBlockReferenceBlockBlock>();
      public BlockCollection<BitmapBlockReferenceBlockBlock> _bitmapBlocksList = new BlockCollection<BitmapBlockReferenceBlockBlock>();
      public BlockCollection<HudBlockReferenceBlockBlock> _hudBlocksList = new BlockCollection<HudBlockReferenceBlockBlock>();
      public BlockCollection<PlayerBlockReferenceBlockBlock> _playerBlocksList = new BlockCollection<PlayerBlockReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserInterfaceListSkinDefinitionBlockBlock() {
        this._listFlags = new Flags(4);
      }
      public BlockCollection<SingleAnimationReferenceBlockBlock> ItemAnimations {
        get {
          return this._itemAnimationsList;
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
references.Add(_arrowsBitmap.Value);
for (int x=0; x<ItemAnimations.BlockCount; x++)
{
  IBlock block = ItemAnimations.GetBlock(x);
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
      public Flags ListFlags {
        get {
          return this._listFlags;
        }
        set {
          this._listFlags = value;
        }
      }
      public TagReference ArrowsBitmap {
        get {
          return this._arrowsBitmap;
        }
        set {
          this._arrowsBitmap = value;
        }
      }
      public Point2D Up_MinusarrowsOffset {
        get {
          return this._up_MinusarrowsOffset;
        }
        set {
          this._up_MinusarrowsOffset = value;
        }
      }
      public Point2D Down_MinusarrowsOffset {
        get {
          return this._down_MinusarrowsOffset;
        }
        set {
          this._down_MinusarrowsOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _listFlags.Read(reader);
        _arrowsBitmap.Read(reader);
        _up_MinusarrowsOffset.Read(reader);
        _down_MinusarrowsOffset.Read(reader);
        _itemAnimations.Read(reader);
        _textBlocks.Read(reader);
        _bitmapBlocks.Read(reader);
        _hudBlocks.Read(reader);
        _playerBlocks.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _arrowsBitmap.ReadString(reader);
        for (x = 0; (x < _itemAnimations.Count); x = (x + 1)) {
          ItemAnimations.Add(new SingleAnimationReferenceBlockBlock());
          ItemAnimations[x].Read(reader);
        }
        for (x = 0; (x < _itemAnimations.Count); x = (x + 1)) {
          ItemAnimations[x].ReadChildData(reader);
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
        _listFlags.Write(bw);
        _arrowsBitmap.Write(bw);
        _up_MinusarrowsOffset.Write(bw);
        _down_MinusarrowsOffset.Write(bw);
_itemAnimations.Count = ItemAnimations.Count;
        _itemAnimations.Write(bw);
_textBlocks.Count = TextBlocks.Count;
        _textBlocks.Write(bw);
_bitmapBlocks.Count = BitmapBlocks.Count;
        _bitmapBlocks.Write(bw);
_hudBlocks.Count = HudBlocks.Count;
        _hudBlocks.Write(bw);
_playerBlocks.Count = PlayerBlocks.Count;
        _playerBlocks.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _arrowsBitmap.WriteString(writer);
        for (x = 0; (x < _itemAnimations.Count); x = (x + 1)) {
          ItemAnimations[x].Write(writer);
        }
        for (x = 0; (x < _itemAnimations.Count); x = (x + 1)) {
          ItemAnimations[x].WriteChildData(writer);
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
    public class SingleAnimationReferenceBlockBlock : IBlock {
      private Flags _flags;
      private LongInteger _animationPeriod = new LongInteger();
      private Block _keyframes = new Block();
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> _keyframesList = new BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SingleAnimationReferenceBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<ScreenAnimationKeyframeReferenceBlockBlock> Keyframes {
        get {
          return this._keyframesList;
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _animationPeriod.Read(reader);
        _keyframes.Read(reader);
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
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _animationPeriod.Write(bw);
_keyframes.Count = Keyframes.Count;
        _keyframes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes[x].Write(writer);
        }
        for (x = 0; (x < _keyframes.Count); x = (x + 1)) {
          Keyframes[x].WriteChildData(writer);
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
  }
}
