// ----------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'equipment' (derived from 'item')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ----------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class equipment : item {
    private EquipmentBlock equipmentValues = new EquipmentBlock();
    public virtual EquipmentBlock EquipmentValues {
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
    public class EquipmentBlock : IBlock {
      private Enum _powerupType = new Enum();
      private Enum _grenadeType = new Enum();
      private Real _powerupTime = new Real();
      private TagReference _pickupSound = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public EquipmentBlock() {
        this._unnamed = new Pad(144);
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
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _pickupSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _powerupType.Write(bw);
        _grenadeType.Write(bw);
        _powerupTime.Write(bw);
        _pickupSound.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _pickupSound.WriteString(writer);
      }
    }
  }
}
