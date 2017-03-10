// ----------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'equipment' (derived from 'item')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ----------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class equipment : item {
    private EquipmentBlockBlock equipmentValues = new EquipmentBlockBlock();
    public virtual EquipmentBlockBlock EquipmentValues {
      get {
        return equipmentValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(EquipmentValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "equipment";
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
equipmentValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
equipmentValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
equipmentValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
equipmentValues.WriteChildData(writer);
    }
    #endregion
    public class EquipmentBlockBlock : IBlock {
      private Enum _powerupType;
      private Enum _grenadeType;
      private Real _powerupTime = new Real();
      private TagReference _pickupSound = new TagReference();
public event System.EventHandler BlockNameChanged;
      public EquipmentBlockBlock() {
        this._powerupType = new Enum(2);
        this._grenadeType = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_pickupSound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum PowerupType {
        get {
          return this._powerupType;
        }
        set {
          this._powerupType = value;
        }
      }
      public Enum GrenadeType {
        get {
          return this._grenadeType;
        }
        set {
          this._grenadeType = value;
        }
      }
      public Real PowerupTime {
        get {
          return this._powerupTime;
        }
        set {
          this._powerupTime = value;
        }
      }
      public TagReference PickupSound {
        get {
          return this._pickupSound;
        }
        set {
          this._pickupSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _powerupType.Read(reader);
        _grenadeType.Read(reader);
        _powerupTime.Read(reader);
        _pickupSound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _pickupSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _powerupType.Write(bw);
        _grenadeType.Write(bw);
        _powerupTime.Write(bw);
        _pickupSound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _pickupSound.WriteString(writer);
      }
    }
  }
}
