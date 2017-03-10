// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'decal'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class decal : Interfaces.Pool.Tag {
    private DecalBlock decalValues = new DecalBlock();
    public virtual DecalBlock DecalValues {
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
    public class DecalBlock : IBlock {
      private Flags _flags;
      private Enum _type = new Enum();
      private Enum _layer = new Enum();
      private Pad _unnamed;
      private TagReference _nextDecalInChain = new TagReference();
      private RealBounds _radius = new RealBounds();
      private Pad _unnamed2;
      private RealFractionBounds _intensity = new RealFractionBounds();
      private RealRGBColor _colorLowerBounds = new RealRGBColor();
      private RealRGBColor _colorUpperBounds = new RealRGBColor();
      private Pad _unnamed3;
      private ShortInteger _animationLoopFrame = new ShortInteger();
      private ShortInteger _animationSpeed = new ShortInteger();
      private Pad _unnamed4;
      private RealBounds _lifetime = new RealBounds();
      private RealBounds _decayTime = new RealBounds();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Enum _framebufferBlendFunction = new Enum();
      private Pad _unnamed9;
      private Pad _unnamed10;
      private TagReference _map = new TagReference();
      private Pad _unnamed11;
      private Real _maximumSpriteExtent = new Real();
      private Pad _unnamed12;
      private Pad _unnamed13;
public event System.EventHandler BlockNameChanged;
      public DecalBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(28);
        this._unnamed5 = new Pad(12);
        this._unnamed6 = new Pad(40);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(2);
        this._unnamed10 = new Pad(20);
        this._unnamed11 = new Pad(20);
        this._unnamed12 = new Pad(4);
        this._unnamed13 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_nextDecalInChain.Value);
references.Add(_map.Value);
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
      public RealFractionBounds Intensity {
        get {
          return this._intensity;
        }
        set {
          this._intensity = value;
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
      public ShortInteger AnimationLoopFrame {
        get {
          return this._animationLoopFrame;
        }
        set {
          this._animationLoopFrame = value;
        }
      }
      public ShortInteger AnimationSpeed {
        get {
          return this._animationSpeed;
        }
        set {
          this._animationSpeed = value;
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
      public Enum FramebufferBlendFunction {
        get {
          return this._framebufferBlendFunction;
        }
        set {
          this._framebufferBlendFunction = value;
        }
      }
      public TagReference Map {
        get {
          return this._map;
        }
        set {
          this._map = value;
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
        _unnamed.Read(reader);
        _nextDecalInChain.Read(reader);
        _radius.Read(reader);
        _unnamed2.Read(reader);
        _intensity.Read(reader);
        _colorLowerBounds.Read(reader);
        _colorUpperBounds.Read(reader);
        _unnamed3.Read(reader);
        _animationLoopFrame.Read(reader);
        _animationSpeed.Read(reader);
        _unnamed4.Read(reader);
        _lifetime.Read(reader);
        _decayTime.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _map.Read(reader);
        _unnamed11.Read(reader);
        _maximumSpriteExtent.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _nextDecalInChain.ReadString(reader);
        _map.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _layer.Write(bw);
        _unnamed.Write(bw);
        _nextDecalInChain.Write(bw);
        _radius.Write(bw);
        _unnamed2.Write(bw);
        _intensity.Write(bw);
        _colorLowerBounds.Write(bw);
        _colorUpperBounds.Write(bw);
        _unnamed3.Write(bw);
        _animationLoopFrame.Write(bw);
        _animationSpeed.Write(bw);
        _unnamed4.Write(bw);
        _lifetime.Write(bw);
        _decayTime.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _map.Write(bw);
        _unnamed11.Write(bw);
        _maximumSpriteExtent.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _nextDecalInChain.WriteString(writer);
        _map.WriteString(writer);
      }
    }
  }
}
