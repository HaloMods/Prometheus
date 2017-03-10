// -------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'item' (derived from 'object')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class item : @object {
    private ItemBlock itemValues = new ItemBlock();
    public virtual ItemBlock ItemValues {
      get {
        return itemValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ItemValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "item";
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
base.Read(reader);
itemValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
itemValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
itemValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
itemValues.WriteChildData(writer);
    }
    #endregion
    public class ItemBlock : IBlock {
      private Flags _flags;
      private ShortInteger _messageIndex = new ShortInteger();
      private ShortInteger _sortOrder = new ShortInteger();
      private Real _scale = new Real();
      private ShortInteger _hudMessageValueScale = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private Pad _unnamed3;
      private TagReference _materialEffects = new TagReference();
      private TagReference _collisionSound = new TagReference();
      private Pad _unnamed4;
      private RealBounds _detonationDelay = new RealBounds();
      private TagReference _detonatingEffect = new TagReference();
      private TagReference _detonationEffect = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ItemBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(164);
        this._unnamed4 = new Pad(120);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_materialEffects.Value);
references.Add(_collisionSound.Value);
references.Add(_detonatingEffect.Value);
references.Add(_detonationEffect.Value);
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
      public ShortInteger MessageIndex {
        get {
          return this._messageIndex;
        }
        set {
          this._messageIndex = value;
        }
      }
      public ShortInteger SortOrder {
        get {
          return this._sortOrder;
        }
        set {
          this._sortOrder = value;
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
      public ShortInteger HudMessageValueScale {
        get {
          return this._hudMessageValueScale;
        }
        set {
          this._hudMessageValueScale = value;
        }
      }
      public Enum AIn {
        get {
          return this._aIn;
        }
        set {
          this._aIn = value;
        }
      }
      public Enum BIn {
        get {
          return this._bIn;
        }
        set {
          this._bIn = value;
        }
      }
      public Enum CIn {
        get {
          return this._cIn;
        }
        set {
          this._cIn = value;
        }
      }
      public Enum DIn {
        get {
          return this._dIn;
        }
        set {
          this._dIn = value;
        }
      }
      public TagReference MaterialEffects {
        get {
          return this._materialEffects;
        }
        set {
          this._materialEffects = value;
        }
      }
      public TagReference CollisionSound {
        get {
          return this._collisionSound;
        }
        set {
          this._collisionSound = value;
        }
      }
      public RealBounds DetonationDelay {
        get {
          return this._detonationDelay;
        }
        set {
          this._detonationDelay = value;
        }
      }
      public TagReference DetonatingEffect {
        get {
          return this._detonatingEffect;
        }
        set {
          this._detonatingEffect = value;
        }
      }
      public TagReference DetonationEffect {
        get {
          return this._detonationEffect;
        }
        set {
          this._detonationEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _messageIndex.Read(reader);
        _sortOrder.Read(reader);
        _scale.Read(reader);
        _hudMessageValueScale.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _unnamed3.Read(reader);
        _materialEffects.Read(reader);
        _collisionSound.Read(reader);
        _unnamed4.Read(reader);
        _detonationDelay.Read(reader);
        _detonatingEffect.Read(reader);
        _detonationEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _materialEffects.ReadString(reader);
        _collisionSound.ReadString(reader);
        _detonatingEffect.ReadString(reader);
        _detonationEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _messageIndex.Write(bw);
        _sortOrder.Write(bw);
        _scale.Write(bw);
        _hudMessageValueScale.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _unnamed3.Write(bw);
        _materialEffects.Write(bw);
        _collisionSound.Write(bw);
        _unnamed4.Write(bw);
        _detonationDelay.Write(bw);
        _detonatingEffect.Write(bw);
        _detonationEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _materialEffects.WriteString(writer);
        _collisionSound.WriteString(writer);
        _detonatingEffect.WriteString(writer);
        _detonationEffect.WriteString(writer);
      }
    }
  }
}
