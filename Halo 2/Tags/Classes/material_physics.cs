// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'material_physics'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class material_physics : Interfaces.Pool.Tag {
    private MaterialPhysicsBlockBlock materialPhysicsValues = new MaterialPhysicsBlockBlock();
    public virtual MaterialPhysicsBlockBlock MaterialPhysicsValues {
      get {
        return materialPhysicsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MaterialPhysicsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "material_physics";
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
materialPhysicsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
materialPhysicsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
materialPhysicsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
materialPhysicsValues.WriteChildData(writer);
    }
    #endregion
    public class MaterialPhysicsBlockBlock : IBlock {
      private Real _groundFrictionScale = new Real();
      private Real _groundFrictionNormalK1Scale = new Real();
      private Real _groundFrictionNormalK0Scale = new Real();
      private Real _groundDepthScale = new Real();
      private Real _groundDampFractionScale = new Real();
public event System.EventHandler BlockNameChanged;
      public MaterialPhysicsBlockBlock() {
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
      public Real GroundFrictionScale {
        get {
          return this._groundFrictionScale;
        }
        set {
          this._groundFrictionScale = value;
        }
      }
      public Real GroundFrictionNormalK1Scale {
        get {
          return this._groundFrictionNormalK1Scale;
        }
        set {
          this._groundFrictionNormalK1Scale = value;
        }
      }
      public Real GroundFrictionNormalK0Scale {
        get {
          return this._groundFrictionNormalK0Scale;
        }
        set {
          this._groundFrictionNormalK0Scale = value;
        }
      }
      public Real GroundDepthScale {
        get {
          return this._groundDepthScale;
        }
        set {
          this._groundDepthScale = value;
        }
      }
      public Real GroundDampFractionScale {
        get {
          return this._groundDampFractionScale;
        }
        set {
          this._groundDampFractionScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _groundFrictionScale.Read(reader);
        _groundFrictionNormalK1Scale.Read(reader);
        _groundFrictionNormalK0Scale.Read(reader);
        _groundDepthScale.Read(reader);
        _groundDampFractionScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _groundFrictionScale.Write(bw);
        _groundFrictionNormalK1Scale.Write(bw);
        _groundFrictionNormalK0Scale.Write(bw);
        _groundDepthScale.Write(bw);
        _groundDampFractionScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
