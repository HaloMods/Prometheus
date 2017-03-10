// -----------------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'device_light_fixture' (derived from 'device')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -----------------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class device_light_fixture : device {
    private DeviceLightFixtureBlockBlock deviceLightFixtureValues = new DeviceLightFixtureBlockBlock();
    public virtual DeviceLightFixtureBlockBlock DeviceLightFixtureValues {
      get {
        return deviceLightFixtureValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(DeviceLightFixtureValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "device_light_fixture";
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
deviceLightFixtureValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
deviceLightFixtureValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
deviceLightFixtureValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
deviceLightFixtureValues.WriteChildData(writer);
    }
    #endregion
    public class DeviceLightFixtureBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public DeviceLightFixtureBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
