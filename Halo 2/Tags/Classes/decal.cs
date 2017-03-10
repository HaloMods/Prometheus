// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'decal'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class decal : Interfaces.Pool.Tag {
    private DecalBlockBlock decalValues = new DecalBlockBlock();
    public virtual DecalBlockBlock DecalValues {
      get {
        return decalValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DecalValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "decal";
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
decalValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
decalValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
decalValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
decalValues.WriteChildData(writer);
    }
    #endregion
    public class DecalBlockBlock : IBlock {
      private Flags _flags;
      private Enum _type;
      private Enum _layer;
      private ShortInteger _maxOverlappingCount = new ShortInteger();
      private TagReference _nextDecalInChain = new TagReference();
      private RealBounds _radius = new RealBounds();
      private Real _radiusOverlapRejection = new Real();
      private RealRGBColor _colorLowerBounds = new RealRGBColor();
      private RealRGBColor _colorUpperBounds = new RealRGBColor();
      private RealBounds _lifetime = new RealBounds();
      private RealBounds _decayTime = new RealBounds();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private TagReference _bitmap = new TagReference();
      private Pad _unnamed6;
      private Real _maximumSpriteExtent = new Real();
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public DecalBlockBlock() {
        this._flags = new Flags(2);
        this._type = new Enum(2);
        this._layer = new Enum(2);
        this._unnamed0 = new Pad(40);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(20);
        this._unnamed6 = new Pad(20);
        this._unnamed7 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_nextDecalInChain.Value);
references.Add(_bitmap.Value);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Enum Layer {
        get {
          return this._layer;
        }
        set {
          this._layer = value;
        }
      }
      public ShortInteger MaxOverlappingCount {
        get {
          return this._maxOverlappingCount;
        }
        set {
          this._maxOverlappingCount = value;
        }
      }
      public TagReference NextDecalInChain {
        get {
          return this._nextDecalInChain;
        }
        set {
          this._nextDecalInChain = value;
        }
      }
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public Real RadiusOverlapRejection {
        get {
          return this._radiusOverlapRejection;
        }
        set {
          this._radiusOverlapRejection = value;
        }
      }
      public RealRGBColor ColorLowerBounds {
        get {
          return this._colorLowerBounds;
        }
        set {
          this._colorLowerBounds = value;
        }
      }
      public RealRGBColor ColorUpperBounds {
        get {
          return this._colorUpperBounds;
        }
        set {
          this._colorUpperBounds = value;
        }
      }
      public RealBounds Lifetime {
        get {
          return this._lifetime;
        }
        set {
          this._lifetime = value;
        }
      }
      public RealBounds DecayTime {
        get {
          return this._decayTime;
        }
        set {
          this._decayTime = value;
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
      public Real MaximumSpriteExtent {
        get {
          return this._maximumSpriteExtent;
        }
        set {
          this._maximumSpriteExtent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type.Read(reader);
        _layer.Read(reader);
        _maxOverlappingCount.Read(reader);
        _nextDecalInChain.Read(reader);
        _radius.Read(reader);
        _radiusOverlapRejection.Read(reader);
        _colorLowerBounds.Read(reader);
        _colorUpperBounds.Read(reader);
        _lifetime.Read(reader);
        _decayTime.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _bitmap.Read(reader);
        _unnamed6.Read(reader);
        _maximumSpriteExtent.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _nextDecalInChain.ReadString(reader);
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _layer.Write(bw);
        _maxOverlappingCount.Write(bw);
        _nextDecalInChain.Write(bw);
        _radius.Write(bw);
        _radiusOverlapRejection.Write(bw);
        _colorLowerBounds.Write(bw);
        _colorUpperBounds.Write(bw);
        _lifetime.Write(bw);
        _decayTime.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _bitmap.Write(bw);
        _unnamed6.Write(bw);
        _maximumSpriteExtent.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _nextDecalInChain.WriteString(writer);
        _bitmap.WriteString(writer);
      }
    }
  }
}
