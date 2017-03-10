// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'light_volume'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class light_volume : Interfaces.Pool.Tag {
    private LightVolumeBlock lightVolumeValues = new LightVolumeBlock();
    public virtual LightVolumeBlock LightVolumeValues {
      get {
        return lightVolumeValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LightVolumeValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "light_volume";
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
lightVolumeValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lightVolumeValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lightVolumeValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lightVolumeValues.WriteChildData(writer);
    }
    #endregion
    public class LightVolumeBlock : IBlock {
      private FixedLengthString _attachmentMarker = new FixedLengthString();
      private Pad _unnamed;
      private Flags _flags;
      private Pad _unnamed2;
      private Real _nearFadeDistance = new Real();
      private Real _farFadeDistance = new Real();
      private RealFraction _perpendicularBrightnessScale = new RealFraction();
      private RealFraction _parallelBrightnessScale = new RealFraction();
      private Enum _brightnessScaleSource = new Enum();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private TagReference _map = new TagReference();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Pad _unnamed5;
      private Enum _frameAnimationSource = new Enum();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Block _frames = new Block();
      private Pad _unnamed9;
      public BlockCollection<LightVolumeFrameBlock> _framesList = new BlockCollection<LightVolumeFrameBlock>();
public event System.EventHandler BlockNameChanged;
      public LightVolumeBlock() {
        this._unnamed = new Pad(2);
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(20);
        this._unnamed5 = new Pad(72);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(36);
        this._unnamed8 = new Pad(64);
        this._unnamed9 = new Pad(32);
      }
      public BlockCollection<LightVolumeFrameBlock> Frames {
        get {
          return this._framesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_map.Value);
for (int x=0; x<Frames.BlockCount; x++)
{
  IBlock block = Frames.GetBlock(x);
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
      public FixedLengthString AttachmentMarker {
        get {
          return this._attachmentMarker;
        }
        set {
          this._attachmentMarker = value;
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
      public Real NearFadeDistance {
        get {
          return this._nearFadeDistance;
        }
        set {
          this._nearFadeDistance = value;
        }
      }
      public Real FarFadeDistance {
        get {
          return this._farFadeDistance;
        }
        set {
          this._farFadeDistance = value;
        }
      }
      public RealFraction PerpendicularBrightnessScale {
        get {
          return this._perpendicularBrightnessScale;
        }
        set {
          this._perpendicularBrightnessScale = value;
        }
      }
      public RealFraction ParallelBrightnessScale {
        get {
          return this._parallelBrightnessScale;
        }
        set {
          this._parallelBrightnessScale = value;
        }
      }
      public Enum BrightnessScaleSource {
        get {
          return this._brightnessScaleSource;
        }
        set {
          this._brightnessScaleSource = value;
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
      public ShortInteger SequenceIndex {
        get {
          return this._sequenceIndex;
        }
        set {
          this._sequenceIndex = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public Enum FrameAnimationSource {
        get {
          return this._frameAnimationSource;
        }
        set {
          this._frameAnimationSource = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _attachmentMarker.Read(reader);
        _unnamed.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _nearFadeDistance.Read(reader);
        _farFadeDistance.Read(reader);
        _perpendicularBrightnessScale.Read(reader);
        _parallelBrightnessScale.Read(reader);
        _brightnessScaleSource.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _map.Read(reader);
        _sequenceIndex.Read(reader);
        _count.Read(reader);
        _unnamed5.Read(reader);
        _frameAnimationSource.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _frames.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _map.ReadString(reader);
        for (x = 0; (x < _frames.Count); x = (x + 1)) {
          Frames.Add(new LightVolumeFrameBlock());
          Frames[x].Read(reader);
        }
        for (x = 0; (x < _frames.Count); x = (x + 1)) {
          Frames[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _attachmentMarker.Write(bw);
        _unnamed.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _nearFadeDistance.Write(bw);
        _farFadeDistance.Write(bw);
        _perpendicularBrightnessScale.Write(bw);
        _parallelBrightnessScale.Write(bw);
        _brightnessScaleSource.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _map.Write(bw);
        _sequenceIndex.Write(bw);
        _count.Write(bw);
        _unnamed5.Write(bw);
        _frameAnimationSource.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
_frames.Count = Frames.Count;
        _frames.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _map.WriteString(writer);
        for (x = 0; (x < _frames.Count); x = (x + 1)) {
          Frames[x].Write(writer);
        }
        for (x = 0; (x < _frames.Count); x = (x + 1)) {
          Frames[x].WriteChildData(writer);
        }
      }
    }
    public class LightVolumeFrameBlock : IBlock {
      private Pad _unnamed;
      private Real _offsetFromMarker = new Real();
      private Real _offsetExponent = new Real();
      private Real _length = new Real();
      private Pad _unnamed2;
      private Real _radiusHither = new Real();
      private Real _radiusYon = new Real();
      private Real _radiusExponent = new Real();
      private Pad _unnamed3;
      private RealARGBColor _tintColorHither = new RealARGBColor();
      private RealARGBColor _tintColorYon = new RealARGBColor();
      private Real _tintColorExponent = new Real();
      private Real _brightnessExponent = new Real();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public LightVolumeFrameBlock() {
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(32);
        this._unnamed4 = new Pad(32);
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
      public Real OffsetFromMarker {
        get {
          return this._offsetFromMarker;
        }
        set {
          this._offsetFromMarker = value;
        }
      }
      public Real OffsetExponent {
        get {
          return this._offsetExponent;
        }
        set {
          this._offsetExponent = value;
        }
      }
      public Real Length {
        get {
          return this._length;
        }
        set {
          this._length = value;
        }
      }
      public Real RadiusHither {
        get {
          return this._radiusHither;
        }
        set {
          this._radiusHither = value;
        }
      }
      public Real RadiusYon {
        get {
          return this._radiusYon;
        }
        set {
          this._radiusYon = value;
        }
      }
      public Real RadiusExponent {
        get {
          return this._radiusExponent;
        }
        set {
          this._radiusExponent = value;
        }
      }
      public RealARGBColor TintColorHither {
        get {
          return this._tintColorHither;
        }
        set {
          this._tintColorHither = value;
        }
      }
      public RealARGBColor TintColorYon {
        get {
          return this._tintColorYon;
        }
        set {
          this._tintColorYon = value;
        }
      }
      public Real TintColorExponent {
        get {
          return this._tintColorExponent;
        }
        set {
          this._tintColorExponent = value;
        }
      }
      public Real BrightnessExponent {
        get {
          return this._brightnessExponent;
        }
        set {
          this._brightnessExponent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _offsetFromMarker.Read(reader);
        _offsetExponent.Read(reader);
        _length.Read(reader);
        _unnamed2.Read(reader);
        _radiusHither.Read(reader);
        _radiusYon.Read(reader);
        _radiusExponent.Read(reader);
        _unnamed3.Read(reader);
        _tintColorHither.Read(reader);
        _tintColorYon.Read(reader);
        _tintColorExponent.Read(reader);
        _brightnessExponent.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _offsetFromMarker.Write(bw);
        _offsetExponent.Write(bw);
        _length.Write(bw);
        _unnamed2.Write(bw);
        _radiusHither.Write(bw);
        _radiusYon.Write(bw);
        _radiusExponent.Write(bw);
        _unnamed3.Write(bw);
        _tintColorHither.Write(bw);
        _tintColorYon.Write(bw);
        _tintColorExponent.Write(bw);
        _brightnessExponent.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
