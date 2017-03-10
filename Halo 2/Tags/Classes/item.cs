// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'item' (derived from 'object')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class item : @object {
    private ItemBlockBlock itemValues = new ItemBlockBlock();
    public virtual ItemBlockBlock ItemValues {
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
    public class ItemBlockBlock : IBlock {
      private Flags _flags;
      private ShortInteger _oLDMessageIndex = new ShortInteger();
      private ShortInteger _sortOrder = new ShortInteger();
      private Real _multiplayerOn_MinusgroundScale = new Real();
      private Real _campaignOn_MinusgroundScale = new Real();
      private StringId _pickupMessage = new StringId();
      private StringId _swapMessage = new StringId();
      private StringId _pickupOrDualMsg = new StringId();
      private StringId _swapOrDualMsg = new StringId();
      private StringId _dual_MinusonlyMsg = new StringId();
      private StringId _pickedUpMsg = new StringId();
      private StringId _singluarQuantityMsg = new StringId();
      private StringId _pluralQuantityMsg = new StringId();
      private StringId _switch_MinustoMsg = new StringId();
      private StringId _switch_MinustoFromAiMsg = new StringId();
      private TagReference _uNUSED = new TagReference();
      private TagReference _collisionSound = new TagReference();
      private Block _predictedBitmaps = new Block();
      private TagReference _detonationDamageEffect = new TagReference();
      private RealBounds _detonationDelay = new RealBounds();
      private TagReference _detonatingEffect = new TagReference();
      private TagReference _detonationEffect = new TagReference();
      public BlockCollection<PredictedBitmapsBlockBlock> _predictedBitmapsList = new BlockCollection<PredictedBitmapsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ItemBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<PredictedBitmapsBlockBlock> PredictedBitmaps {
        get {
          return this._predictedBitmapsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_uNUSED.Value);
references.Add(_collisionSound.Value);
references.Add(_detonationDamageEffect.Value);
references.Add(_detonatingEffect.Value);
references.Add(_detonationEffect.Value);
for (int x=0; x<PredictedBitmaps.BlockCount; x++)
{
  IBlock block = PredictedBitmaps.GetBlock(x);
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
      public ShortInteger OLDMessageIndex {
        get {
          return this._oLDMessageIndex;
        }
        set {
          this._oLDMessageIndex = value;
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
      public Real MultiplayerOn_MinusgroundScale {
        get {
          return this._multiplayerOn_MinusgroundScale;
        }
        set {
          this._multiplayerOn_MinusgroundScale = value;
        }
      }
      public Real CampaignOn_MinusgroundScale {
        get {
          return this._campaignOn_MinusgroundScale;
        }
        set {
          this._campaignOn_MinusgroundScale = value;
        }
      }
      public StringId PickupMessage {
        get {
          return this._pickupMessage;
        }
        set {
          this._pickupMessage = value;
        }
      }
      public StringId SwapMessage {
        get {
          return this._swapMessage;
        }
        set {
          this._swapMessage = value;
        }
      }
      public StringId PickupOrDualMsg {
        get {
          return this._pickupOrDualMsg;
        }
        set {
          this._pickupOrDualMsg = value;
        }
      }
      public StringId SwapOrDualMsg {
        get {
          return this._swapOrDualMsg;
        }
        set {
          this._swapOrDualMsg = value;
        }
      }
      public StringId Dual_MinusonlyMsg {
        get {
          return this._dual_MinusonlyMsg;
        }
        set {
          this._dual_MinusonlyMsg = value;
        }
      }
      public StringId PickedUpMsg {
        get {
          return this._pickedUpMsg;
        }
        set {
          this._pickedUpMsg = value;
        }
      }
      public StringId SingluarQuantityMsg {
        get {
          return this._singluarQuantityMsg;
        }
        set {
          this._singluarQuantityMsg = value;
        }
      }
      public StringId PluralQuantityMsg {
        get {
          return this._pluralQuantityMsg;
        }
        set {
          this._pluralQuantityMsg = value;
        }
      }
      public StringId Switch_MinustoMsg {
        get {
          return this._switch_MinustoMsg;
        }
        set {
          this._switch_MinustoMsg = value;
        }
      }
      public StringId Switch_MinustoFromAiMsg {
        get {
          return this._switch_MinustoFromAiMsg;
        }
        set {
          this._switch_MinustoFromAiMsg = value;
        }
      }
      public TagReference UNUSED {
        get {
          return this._uNUSED;
        }
        set {
          this._uNUSED = value;
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
      public TagReference DetonationDamageEffect {
        get {
          return this._detonationDamageEffect;
        }
        set {
          this._detonationDamageEffect = value;
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
        _oLDMessageIndex.Read(reader);
        _sortOrder.Read(reader);
        _multiplayerOn_MinusgroundScale.Read(reader);
        _campaignOn_MinusgroundScale.Read(reader);
        _pickupMessage.Read(reader);
        _swapMessage.Read(reader);
        _pickupOrDualMsg.Read(reader);
        _swapOrDualMsg.Read(reader);
        _dual_MinusonlyMsg.Read(reader);
        _pickedUpMsg.Read(reader);
        _singluarQuantityMsg.Read(reader);
        _pluralQuantityMsg.Read(reader);
        _switch_MinustoMsg.Read(reader);
        _switch_MinustoFromAiMsg.Read(reader);
        _uNUSED.Read(reader);
        _collisionSound.Read(reader);
        _predictedBitmaps.Read(reader);
        _detonationDamageEffect.Read(reader);
        _detonationDelay.Read(reader);
        _detonatingEffect.Read(reader);
        _detonationEffect.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _pickupMessage.ReadString(reader);
        _swapMessage.ReadString(reader);
        _pickupOrDualMsg.ReadString(reader);
        _swapOrDualMsg.ReadString(reader);
        _dual_MinusonlyMsg.ReadString(reader);
        _pickedUpMsg.ReadString(reader);
        _singluarQuantityMsg.ReadString(reader);
        _pluralQuantityMsg.ReadString(reader);
        _switch_MinustoMsg.ReadString(reader);
        _switch_MinustoFromAiMsg.ReadString(reader);
        _uNUSED.ReadString(reader);
        _collisionSound.ReadString(reader);
        for (x = 0; (x < _predictedBitmaps.Count); x = (x + 1)) {
          PredictedBitmaps.Add(new PredictedBitmapsBlockBlock());
          PredictedBitmaps[x].Read(reader);
        }
        for (x = 0; (x < _predictedBitmaps.Count); x = (x + 1)) {
          PredictedBitmaps[x].ReadChildData(reader);
        }
        _detonationDamageEffect.ReadString(reader);
        _detonatingEffect.ReadString(reader);
        _detonationEffect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _oLDMessageIndex.Write(bw);
        _sortOrder.Write(bw);
        _multiplayerOn_MinusgroundScale.Write(bw);
        _campaignOn_MinusgroundScale.Write(bw);
        _pickupMessage.Write(bw);
        _swapMessage.Write(bw);
        _pickupOrDualMsg.Write(bw);
        _swapOrDualMsg.Write(bw);
        _dual_MinusonlyMsg.Write(bw);
        _pickedUpMsg.Write(bw);
        _singluarQuantityMsg.Write(bw);
        _pluralQuantityMsg.Write(bw);
        _switch_MinustoMsg.Write(bw);
        _switch_MinustoFromAiMsg.Write(bw);
        _uNUSED.Write(bw);
        _collisionSound.Write(bw);
_predictedBitmaps.Count = PredictedBitmaps.Count;
        _predictedBitmaps.Write(bw);
        _detonationDamageEffect.Write(bw);
        _detonationDelay.Write(bw);
        _detonatingEffect.Write(bw);
        _detonationEffect.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _pickupMessage.WriteString(writer);
        _swapMessage.WriteString(writer);
        _pickupOrDualMsg.WriteString(writer);
        _swapOrDualMsg.WriteString(writer);
        _dual_MinusonlyMsg.WriteString(writer);
        _pickedUpMsg.WriteString(writer);
        _singluarQuantityMsg.WriteString(writer);
        _pluralQuantityMsg.WriteString(writer);
        _switch_MinustoMsg.WriteString(writer);
        _switch_MinustoFromAiMsg.WriteString(writer);
        _uNUSED.WriteString(writer);
        _collisionSound.WriteString(writer);
        for (x = 0; (x < _predictedBitmaps.Count); x = (x + 1)) {
          PredictedBitmaps[x].Write(writer);
        }
        for (x = 0; (x < _predictedBitmaps.Count); x = (x + 1)) {
          PredictedBitmaps[x].WriteChildData(writer);
        }
        _detonationDamageEffect.WriteString(writer);
        _detonatingEffect.WriteString(writer);
        _detonationEffect.WriteString(writer);
      }
    }
    public class PredictedBitmapsBlockBlock : IBlock {
      private TagReference _bitmap = new TagReference();
public event System.EventHandler BlockNameChanged;
      public PredictedBitmapsBlockBlock() {
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
