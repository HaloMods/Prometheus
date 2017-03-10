// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'virtual_keyboard'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class virtual_keyboard : Interfaces.Pool.Tag {
    private VirtualKeyboardBlock virtualKeyboardValues = new VirtualKeyboardBlock();
    public virtual VirtualKeyboardBlock VirtualKeyboardValues {
      get {
        return virtualKeyboardValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(VirtualKeyboardValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "virtual_keyboard";
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
virtualKeyboardValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
virtualKeyboardValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
virtualKeyboardValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
virtualKeyboardValues.WriteChildData(writer);
    }
    #endregion
    public class VirtualKeyboardBlock : IBlock {
      private TagReference _displayFont = new TagReference();
      private TagReference _backgroundBitmap = new TagReference();
      private TagReference _specialKeyLabelsStringList = new TagReference();
      private Block _virtualKeys = new Block();
      public BlockCollection<VirtualKeyBlock> _virtualKeysList = new BlockCollection<VirtualKeyBlock>();
public event System.EventHandler BlockNameChanged;
      public VirtualKeyboardBlock() {
      }
      public BlockCollection<VirtualKeyBlock> VirtualKeys {
        get {
          return this._virtualKeysList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_displayFont.Value);
references.Add(_backgroundBitmap.Value);
references.Add(_specialKeyLabelsStringList.Value);
for (int x=0; x<VirtualKeys.BlockCount; x++)
{
  IBlock block = VirtualKeys.GetBlock(x);
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
      public TagReference DisplayFont {
        get {
          return this._displayFont;
        }
        set {
          this._displayFont = value;
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
      public TagReference SpecialKeyLabelsStringList {
        get {
          return this._specialKeyLabelsStringList;
        }
        set {
          this._specialKeyLabelsStringList = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _displayFont.Read(reader);
        _backgroundBitmap.Read(reader);
        _specialKeyLabelsStringList.Read(reader);
        _virtualKeys.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _displayFont.ReadString(reader);
        _backgroundBitmap.ReadString(reader);
        _specialKeyLabelsStringList.ReadString(reader);
        for (x = 0; (x < _virtualKeys.Count); x = (x + 1)) {
          VirtualKeys.Add(new VirtualKeyBlock());
          VirtualKeys[x].Read(reader);
        }
        for (x = 0; (x < _virtualKeys.Count); x = (x + 1)) {
          VirtualKeys[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _displayFont.Write(bw);
        _backgroundBitmap.Write(bw);
        _specialKeyLabelsStringList.Write(bw);
_virtualKeys.Count = VirtualKeys.Count;
        _virtualKeys.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _displayFont.WriteString(writer);
        _backgroundBitmap.WriteString(writer);
        _specialKeyLabelsStringList.WriteString(writer);
        for (x = 0; (x < _virtualKeys.Count); x = (x + 1)) {
          VirtualKeys[x].Write(writer);
        }
        for (x = 0; (x < _virtualKeys.Count); x = (x + 1)) {
          VirtualKeys[x].WriteChildData(writer);
        }
      }
    }
    public class VirtualKeyBlock : IBlock {
      private Enum _keyboardKey = new Enum();
      private ShortInteger _lowercaseCharacter = new ShortInteger();
      private ShortInteger _shiftCharacter = new ShortInteger();
      private ShortInteger _capsCharacter = new ShortInteger();
      private ShortInteger _symbolsCharacter = new ShortInteger();
      private ShortInteger _shift_PluscapsCharacter = new ShortInteger();
      private ShortInteger _shift_PlussymbolsCharacter = new ShortInteger();
      private ShortInteger _caps_PlussymbolsCharacter = new ShortInteger();
      private TagReference _unselectedBackgroundBitmap = new TagReference();
      private TagReference _selectedBackgroundBitmap = new TagReference();
      private TagReference _activeBackgroundBitmap = new TagReference();
      private TagReference _stickyBackgroundBitmap = new TagReference();
public event System.EventHandler BlockNameChanged;
      public VirtualKeyBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_unselectedBackgroundBitmap.Value);
references.Add(_selectedBackgroundBitmap.Value);
references.Add(_activeBackgroundBitmap.Value);
references.Add(_stickyBackgroundBitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum KeyboardKey {
        get {
          return this._keyboardKey;
        }
        set {
          this._keyboardKey = value;
        }
      }
      public ShortInteger LowercaseCharacter {
        get {
          return this._lowercaseCharacter;
        }
        set {
          this._lowercaseCharacter = value;
        }
      }
      public ShortInteger ShiftCharacter {
        get {
          return this._shiftCharacter;
        }
        set {
          this._shiftCharacter = value;
        }
      }
      public ShortInteger CapsCharacter {
        get {
          return this._capsCharacter;
        }
        set {
          this._capsCharacter = value;
        }
      }
      public ShortInteger SymbolsCharacter {
        get {
          return this._symbolsCharacter;
        }
        set {
          this._symbolsCharacter = value;
        }
      }
      public ShortInteger Shift_PluscapsCharacter {
        get {
          return this._shift_PluscapsCharacter;
        }
        set {
          this._shift_PluscapsCharacter = value;
        }
      }
      public ShortInteger Shift_PlussymbolsCharacter {
        get {
          return this._shift_PlussymbolsCharacter;
        }
        set {
          this._shift_PlussymbolsCharacter = value;
        }
      }
      public ShortInteger Caps_PlussymbolsCharacter {
        get {
          return this._caps_PlussymbolsCharacter;
        }
        set {
          this._caps_PlussymbolsCharacter = value;
        }
      }
      public TagReference UnselectedBackgroundBitmap {
        get {
          return this._unselectedBackgroundBitmap;
        }
        set {
          this._unselectedBackgroundBitmap = value;
        }
      }
      public TagReference SelectedBackgroundBitmap {
        get {
          return this._selectedBackgroundBitmap;
        }
        set {
          this._selectedBackgroundBitmap = value;
        }
      }
      public TagReference ActiveBackgroundBitmap {
        get {
          return this._activeBackgroundBitmap;
        }
        set {
          this._activeBackgroundBitmap = value;
        }
      }
      public TagReference StickyBackgroundBitmap {
        get {
          return this._stickyBackgroundBitmap;
        }
        set {
          this._stickyBackgroundBitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _keyboardKey.Read(reader);
        _lowercaseCharacter.Read(reader);
        _shiftCharacter.Read(reader);
        _capsCharacter.Read(reader);
        _symbolsCharacter.Read(reader);
        _shift_PluscapsCharacter.Read(reader);
        _shift_PlussymbolsCharacter.Read(reader);
        _caps_PlussymbolsCharacter.Read(reader);
        _unselectedBackgroundBitmap.Read(reader);
        _selectedBackgroundBitmap.Read(reader);
        _activeBackgroundBitmap.Read(reader);
        _stickyBackgroundBitmap.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unselectedBackgroundBitmap.ReadString(reader);
        _selectedBackgroundBitmap.ReadString(reader);
        _activeBackgroundBitmap.ReadString(reader);
        _stickyBackgroundBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _keyboardKey.Write(bw);
        _lowercaseCharacter.Write(bw);
        _shiftCharacter.Write(bw);
        _capsCharacter.Write(bw);
        _symbolsCharacter.Write(bw);
        _shift_PluscapsCharacter.Write(bw);
        _shift_PlussymbolsCharacter.Write(bw);
        _caps_PlussymbolsCharacter.Write(bw);
        _unselectedBackgroundBitmap.Write(bw);
        _selectedBackgroundBitmap.Write(bw);
        _activeBackgroundBitmap.Write(bw);
        _stickyBackgroundBitmap.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unselectedBackgroundBitmap.WriteString(writer);
        _selectedBackgroundBitmap.WriteString(writer);
        _activeBackgroundBitmap.WriteString(writer);
        _stickyBackgroundBitmap.WriteString(writer);
      }
    }
  }
}
