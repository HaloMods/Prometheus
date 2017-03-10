// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'point_physics'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class point_physics : Interfaces.Pool.Tag {
    private PointPhysicsBlockBlock pointPhysicsValues = new PointPhysicsBlockBlock();
    public virtual PointPhysicsBlockBlock PointPhysicsValues {
      get {
        return pointPhysicsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PointPhysicsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "point_physics";
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
pointPhysicsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
pointPhysicsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
pointPhysicsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
pointPhysicsValues.WriteChildData(writer);
    }
    #endregion
    public class PointPhysicsBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Real _density = new Real();
      private Real _airFriction = new Real();
      private Real _waterFriction = new Real();
      private Real _surfaceFriction = new Real();
      private Real _elasticity = new Real();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public PointPhysicsBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(28);
        this._unnamed1 = new Pad(12);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public Real AirFriction {
        get {
          return this._airFriction;
        }
        set {
          this._airFriction = value;
        }
      }
      public Real WaterFriction {
        get {
          return this._waterFriction;
        }
        set {
          this._waterFriction = value;
        }
      }
      public Real SurfaceFriction {
        get {
          return this._surfaceFriction;
        }
        set {
          this._surfaceFriction = value;
        }
      }
      public Real Elasticity {
        get {
          return this._elasticity;
        }
        set {
          this._elasticity = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _density.Read(reader);
        _airFriction.Read(reader);
        _waterFriction.Read(reader);
        _surfaceFriction.Read(reader);
        _elasticity.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _density.Write(bw);
        _airFriction.Write(bw);
        _waterFriction.Write(bw);
        _surfaceFriction.Write(bw);
        _elasticity.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
