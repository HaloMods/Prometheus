// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'wind'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class wind : Interfaces.Pool.Tag {
    private WindBlock windValues = new WindBlock();
    public virtual WindBlock WindValues {
      get {
        return windValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(WindValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "wind";
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
windValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
windValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
windValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
windValues.WriteChildData(writer);
    }
    #endregion
    public class WindBlock : IBlock {
      private RealBounds _velocity = new RealBounds();
      private RealEulerAngles2D _variationArea = new RealEulerAngles2D();
      private Real _localVariationWeight = new Real();
      private Real _localVariationRate = new Real();
      private Real _damping = new Real();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public WindBlock() {
        this._unnamed = new Pad(36);
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
      public RealBounds Velocity {
        get {
          return this._velocity;
        }
        set {
          this._velocity = value;
        }
      }
      public RealEulerAngles2D VariationArea {
        get {
          return this._variationArea;
        }
        set {
          this._variationArea = value;
        }
      }
      public Real LocalVariationWeight {
        get {
          return this._localVariationWeight;
        }
        set {
          this._localVariationWeight = value;
        }
      }
      public Real LocalVariationRate {
        get {
          return this._localVariationRate;
        }
        set {
          this._localVariationRate = value;
        }
      }
      public Real Damping {
        get {
          return this._damping;
        }
        set {
          this._damping = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _velocity.Read(reader);
        _variationArea.Read(reader);
        _localVariationWeight.Read(reader);
        _localVariationRate.Read(reader);
        _damping.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _velocity.Write(bw);
        _variationArea.Write(bw);
        _localVariationWeight.Write(bw);
        _localVariationRate.Write(bw);
        _damping.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
