// ----------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'scenery' (derived from 'object')
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ----------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class scenery : @object {
    private SceneryBlockBlock sceneryValues = new SceneryBlockBlock();
    public virtual SceneryBlockBlock SceneryValues {
      get {
        return sceneryValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(SceneryValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "scenery";
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
sceneryValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
sceneryValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
sceneryValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
sceneryValues.WriteChildData(writer);
    }
    #endregion
    public class SceneryBlockBlock : IBlock {
      private Enum _pathfindingPolicy;
      private Flags _flags;
      private Enum _lightmappingPolicy;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public SceneryBlockBlock() {
        this._pathfindingPolicy = new Enum(2);
        this._flags = new Flags(2);
        this._lightmappingPolicy = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Enum PathfindingPolicy {
        get {
          return this._pathfindingPolicy;
        }
        set {
          this._pathfindingPolicy = value;
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
      public Enum LightmappingPolicy {
        get {
          return this._lightmappingPolicy;
        }
        set {
          this._lightmappingPolicy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pathfindingPolicy.Read(reader);
        _flags.Read(reader);
        _lightmappingPolicy.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _pathfindingPolicy.Write(bw);
        _flags.Write(bw);
        _lightmappingPolicy.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
