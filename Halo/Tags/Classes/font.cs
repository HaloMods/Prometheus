// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'font'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class font : Interfaces.Pool.Tag {
    private FontBlock fontValues = new FontBlock();
    public virtual FontBlock FontValues {
      get {
        return fontValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(FontValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "font";
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
fontValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
fontValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
fontValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
fontValues.WriteChildData(writer);
    }
    #endregion
    public class FontBlock : IBlock {
      private LongInteger _flags = new LongInteger();
      private ShortInteger _ascendingHeight = new ShortInteger();
      private ShortInteger _decendingHeight = new ShortInteger();
      private ShortInteger _leadingHeight = new ShortInteger();
      private ShortInteger _leadinWidth = new ShortInteger();
      private Pad _unnamed;
      private Block _characterTables = new Block();
      private TagReference _bold = new TagReference();
      private TagReference _italic = new TagReference();
      private TagReference _condense = new TagReference();
      private TagReference _underline = new TagReference();
      private Block _characters = new Block();
      private Data _pixels = new Data();
      public BlockCollection<FontCharacterTablesBlock> _characterTablesList = new BlockCollection<FontCharacterTablesBlock>();
      public BlockCollection<CharacterBlock> _charactersList = new BlockCollection<CharacterBlock>();
public event System.EventHandler BlockNameChanged;
      public FontBlock() {
        this._unnamed = new Pad(36);
      }
      public BlockCollection<FontCharacterTablesBlock> CharacterTables {
        get {
          return this._characterTablesList;
        }
      }
      public BlockCollection<CharacterBlock> Characters {
        get {
          return this._charactersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bold.Value);
references.Add(_italic.Value);
references.Add(_condense.Value);
references.Add(_underline.Value);
for (int x=0; x<CharacterTables.BlockCount; x++)
{
  IBlock block = CharacterTables.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Characters.BlockCount; x++)
{
  IBlock block = Characters.GetBlock(x);
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
      public LongInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger AscendingHeight {
        get {
          return this._ascendingHeight;
        }
        set {
          this._ascendingHeight = value;
        }
      }
      public ShortInteger DecendingHeight {
        get {
          return this._decendingHeight;
        }
        set {
          this._decendingHeight = value;
        }
      }
      public ShortInteger LeadingHeight {
        get {
          return this._leadingHeight;
        }
        set {
          this._leadingHeight = value;
        }
      }
      public ShortInteger LeadinWidth {
        get {
          return this._leadinWidth;
        }
        set {
          this._leadinWidth = value;
        }
      }
      public TagReference Bold {
        get {
          return this._bold;
        }
        set {
          this._bold = value;
        }
      }
      public TagReference Italic {
        get {
          return this._italic;
        }
        set {
          this._italic = value;
        }
      }
      public TagReference Condense {
        get {
          return this._condense;
        }
        set {
          this._condense = value;
        }
      }
      public TagReference Underline {
        get {
          return this._underline;
        }
        set {
          this._underline = value;
        }
      }
      public Data Pixels {
        get {
          return this._pixels;
        }
        set {
          this._pixels = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _ascendingHeight.Read(reader);
        _decendingHeight.Read(reader);
        _leadingHeight.Read(reader);
        _leadinWidth.Read(reader);
        _unnamed.Read(reader);
        _characterTables.Read(reader);
        _bold.Read(reader);
        _italic.Read(reader);
        _condense.Read(reader);
        _underline.Read(reader);
        _characters.Read(reader);
        _pixels.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _characterTables.Count); x = (x + 1)) {
          CharacterTables.Add(new FontCharacterTablesBlock());
          CharacterTables[x].Read(reader);
        }
        for (x = 0; (x < _characterTables.Count); x = (x + 1)) {
          CharacterTables[x].ReadChildData(reader);
        }
        _bold.ReadString(reader);
        _italic.ReadString(reader);
        _condense.ReadString(reader);
        _underline.ReadString(reader);
        for (x = 0; (x < _characters.Count); x = (x + 1)) {
          Characters.Add(new CharacterBlock());
          Characters[x].Read(reader);
        }
        for (x = 0; (x < _characters.Count); x = (x + 1)) {
          Characters[x].ReadChildData(reader);
        }
        _pixels.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _ascendingHeight.Write(bw);
        _decendingHeight.Write(bw);
        _leadingHeight.Write(bw);
        _leadinWidth.Write(bw);
        _unnamed.Write(bw);
_characterTables.Count = CharacterTables.Count;
        _characterTables.Write(bw);
        _bold.Write(bw);
        _italic.Write(bw);
        _condense.Write(bw);
        _underline.Write(bw);
_characters.Count = Characters.Count;
        _characters.Write(bw);
        _pixels.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _characterTables.Count); x = (x + 1)) {
          CharacterTables[x].Write(writer);
        }
        for (x = 0; (x < _characterTables.Count); x = (x + 1)) {
          CharacterTables[x].WriteChildData(writer);
        }
        _bold.WriteString(writer);
        _italic.WriteString(writer);
        _condense.WriteString(writer);
        _underline.WriteString(writer);
        for (x = 0; (x < _characters.Count); x = (x + 1)) {
          Characters[x].Write(writer);
        }
        for (x = 0; (x < _characters.Count); x = (x + 1)) {
          Characters[x].WriteChildData(writer);
        }
        _pixels.WriteBinary(writer);
      }
    }
    public class FontCharacterTablesBlock : IBlock {
      private Block _characterTable = new Block();
      public BlockCollection<FontCharacterTableBlock> _characterTableList = new BlockCollection<FontCharacterTableBlock>();
public event System.EventHandler BlockNameChanged;
      public FontCharacterTablesBlock() {
      }
      public BlockCollection<FontCharacterTableBlock> CharacterTable {
        get {
          return this._characterTableList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CharacterTable.BlockCount; x++)
{
  IBlock block = CharacterTable.GetBlock(x);
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
        _characterTable.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _characterTable.Count); x = (x + 1)) {
          CharacterTable.Add(new FontCharacterTableBlock());
          CharacterTable[x].Read(reader);
        }
        for (x = 0; (x < _characterTable.Count); x = (x + 1)) {
          CharacterTable[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_characterTable.Count = CharacterTable.Count;
        _characterTable.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _characterTable.Count); x = (x + 1)) {
          CharacterTable[x].Write(writer);
        }
        for (x = 0; (x < _characterTable.Count); x = (x + 1)) {
          CharacterTable[x].WriteChildData(writer);
        }
      }
    }
    public class FontCharacterTableBlock : IBlock {
      private ShortBlockIndex _characterIndex = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public FontCharacterTableBlock() {
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
      public ShortBlockIndex CharacterIndex {
        get {
          return this._characterIndex;
        }
        set {
          this._characterIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _characterIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _characterIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class CharacterBlock : IBlock {
      private ShortInteger _character = new ShortInteger();
      private ShortInteger _characterWidth = new ShortInteger();
      private ShortInteger _bitmapWidth = new ShortInteger();
      private ShortInteger _bitmapHeight = new ShortInteger();
      private ShortInteger _bitmapOriginX = new ShortInteger();
      private ShortInteger _bitmapOriginY = new ShortInteger();
      private ShortInteger _hardwareCharacterIndex = new ShortInteger();
      private Pad _unnamed;
      private LongInteger _pixelsOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public CharacterBlock() {
        this._unnamed = new Pad(2);
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
      public ShortInteger Character {
        get {
          return this._character;
        }
        set {
          this._character = value;
        }
      }
      public ShortInteger CharacterWidth {
        get {
          return this._characterWidth;
        }
        set {
          this._characterWidth = value;
        }
      }
      public ShortInteger BitmapWidth {
        get {
          return this._bitmapWidth;
        }
        set {
          this._bitmapWidth = value;
        }
      }
      public ShortInteger BitmapHeight {
        get {
          return this._bitmapHeight;
        }
        set {
          this._bitmapHeight = value;
        }
      }
      public ShortInteger BitmapOriginX {
        get {
          return this._bitmapOriginX;
        }
        set {
          this._bitmapOriginX = value;
        }
      }
      public ShortInteger BitmapOriginY {
        get {
          return this._bitmapOriginY;
        }
        set {
          this._bitmapOriginY = value;
        }
      }
      public ShortInteger HardwareCharacterIndex {
        get {
          return this._hardwareCharacterIndex;
        }
        set {
          this._hardwareCharacterIndex = value;
        }
      }
      public LongInteger PixelsOffset {
        get {
          return this._pixelsOffset;
        }
        set {
          this._pixelsOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _character.Read(reader);
        _characterWidth.Read(reader);
        _bitmapWidth.Read(reader);
        _bitmapHeight.Read(reader);
        _bitmapOriginX.Read(reader);
        _bitmapOriginY.Read(reader);
        _hardwareCharacterIndex.Read(reader);
        _unnamed.Read(reader);
        _pixelsOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _character.Write(bw);
        _characterWidth.Write(bw);
        _bitmapWidth.Write(bw);
        _bitmapHeight.Write(bw);
        _bitmapOriginX.Write(bw);
        _bitmapOriginY.Write(bw);
        _hardwareCharacterIndex.Write(bw);
        _unnamed.Write(bw);
        _pixelsOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
