// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'item_collection'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class item_collection : Interfaces.Pool.Tag {
    private ItemCollectionBlockBlock itemCollectionValues = new ItemCollectionBlockBlock();
    public virtual ItemCollectionBlockBlock ItemCollectionValues {
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
    public class ItemCollectionBlockBlock : IBlock {
      private Block _itemPermutations = new Block();
      private ShortInteger _spawnTimeInSeconds0Default = new ShortInteger();
      private Pad _unnamed0;
      public BlockCollection<ItemPermutationBlock> _itemPermutationsList = new BlockCollection<ItemPermutationBlock>();
public event System.EventHandler BlockNameChanged;
      public ItemCollectionBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger SpawnTimeInSeconds0Default {
        get {
          return this._spawnTimeInSeconds0Default;
        }
        set {
          this._spawnTimeInSeconds0Default = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _itemPermutations.Read(reader);
        _spawnTimeInSeconds0Default.Read(reader);
        _unnamed0.Read(reader);
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
        _spawnTimeInSeconds0Default.Write(bw);
        _unnamed0.Write(bw);
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
      private Real _weight = new Real();
      private TagReference _item = new TagReference();
      private StringId _variantName = new StringId();
public event System.EventHandler BlockNameChanged;
      public ItemPermutationBlock() {
if (this._item is System.ComponentModel.INotifyPropertyChanged)
  (this._item as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weight.Read(reader);
        _item.Read(reader);
        _variantName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _item.ReadString(reader);
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weight.Write(bw);
        _item.Write(bw);
        _variantName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _item.WriteString(writer);
        _variantName.WriteString(writer);
      }
    }
  }
}
