// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'vehicle_collection'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class vehicle_collection : Interfaces.Pool.Tag {
    private VehicleCollectionBlockBlock vehicleCollectionValues = new VehicleCollectionBlockBlock();
    public virtual VehicleCollectionBlockBlock VehicleCollectionValues {
      get {
        return vehicleCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(VehicleCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "vehicle_collection";
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
vehicleCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
vehicleCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
vehicleCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
vehicleCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class VehicleCollectionBlockBlock : IBlock {
      private Block _vehiclePermutations = new Block();
      private ShortInteger _spawnTimeInSeconds0Default = new ShortInteger();
      private Pad _unnamed0;
      public BlockCollection<VehiclePermutationBlock> _vehiclePermutationsList = new BlockCollection<VehiclePermutationBlock>();
public event System.EventHandler BlockNameChanged;
      public VehicleCollectionBlockBlock() {
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<VehiclePermutationBlock> VehiclePermutations {
        get {
          return this._vehiclePermutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<VehiclePermutations.BlockCount; x++)
{
  IBlock block = VehiclePermutations.GetBlock(x);
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
        _vehiclePermutations.Read(reader);
        _spawnTimeInSeconds0Default.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _vehiclePermutations.Count); x = (x + 1)) {
          VehiclePermutations.Add(new VehiclePermutationBlock());
          VehiclePermutations[x].Read(reader);
        }
        for (x = 0; (x < _vehiclePermutations.Count); x = (x + 1)) {
          VehiclePermutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_vehiclePermutations.Count = VehiclePermutations.Count;
        _vehiclePermutations.Write(bw);
        _spawnTimeInSeconds0Default.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _vehiclePermutations.Count); x = (x + 1)) {
          VehiclePermutations[x].Write(writer);
        }
        for (x = 0; (x < _vehiclePermutations.Count); x = (x + 1)) {
          VehiclePermutations[x].WriteChildData(writer);
        }
      }
    }
    public class VehiclePermutationBlock : IBlock {
      private Real _weight = new Real();
      private TagReference _vehicle = new TagReference();
      private StringId _variantName = new StringId();
public event System.EventHandler BlockNameChanged;
      public VehiclePermutationBlock() {
if (this._vehicle is System.ComponentModel.INotifyPropertyChanged)
  (this._vehicle as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_vehicle.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _vehicle.ToString();
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
      public TagReference Vehicle {
        get {
          return this._vehicle;
        }
        set {
          this._vehicle = value;
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
        _vehicle.Read(reader);
        _variantName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _vehicle.ReadString(reader);
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weight.Write(bw);
        _vehicle.Write(bw);
        _variantName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _vehicle.WriteString(writer);
        _variantName.WriteString(writer);
      }
    }
  }
}
