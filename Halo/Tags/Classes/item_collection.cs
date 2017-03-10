// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'item_collection'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class item_collection : Interfaces.Pool.Tag {
    private ItemCollectionBlock itemCollectionValues = new ItemCollectionBlock();
    public virtual ItemCollectionBlock ItemCollectionValues {
      get {
        return itemCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ItemCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "item_collection";
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
itemCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
itemCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
itemCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
itemCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class ItemCollectionBlock : IBlock {
      private Block _itemPermutations = new Block();
      private ShortInteger _spawnTimeInSecond = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      public BlockCollection<ItemPermutationBlock> _itemPermutationsList = new BlockCollection<ItemPermutationBlock>();
public event System.EventHandler BlockNameChanged;
      public ItemCollectionBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(76);
      }
      public BlockCollection<ItemPermutationBlock> ItemPermutations {
        get {
          return this._itemPermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ItemPermutations.BlockCount; x++)
{
  IBlock block = ItemPermutations.GetBlock(x);
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
      public ShortInteger SpawnTimeInSecond {
        get {
          return this._spawnTimeInSecond;
        }
        set {
          this._spawnTimeInSecond = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _itemPermutations.Read(reader);
        _spawnTimeInSecond.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _itemPermutations.Count); x = (x + 1)) {
          ItemPermutations.Add(new ItemPermutationBlock());
          ItemPermutations[x].Read(reader);
        }
        for (x = 0; (x < _itemPermutations.Count); x = (x + 1)) {
          ItemPermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_itemPermutations.Count = ItemPermutations.Count;
        _itemPermutations.Write(bw);
        _spawnTimeInSecond.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _itemPermutations.Count); x = (x + 1)) {
          ItemPermutations[x].Write(writer);
        }
        for (x = 0; (x < _itemPermutations.Count); x = (x + 1)) {
          ItemPermutations[x].WriteChildData(writer);
        }
      }
    }
    public class ItemPermutationBlock : IBlock {
      private Pad _unnamed;
      private Real _weight = new Real();
      private TagReference _item = new TagReference();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ItemPermutationBlock() {
if (this._item is System.ComponentModel.INotifyPropertyChanged)
  (this._item as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
        this._unnamed2 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_item.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _item.ToString();
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public TagReference Item {
        get {
          return this._item;
        }
        set {
          this._item = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _weight.Read(reader);
        _item.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _item.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _weight.Write(bw);
        _item.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _item.WriteString(writer);
      }
    }
  }
}
