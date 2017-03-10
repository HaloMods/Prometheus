// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'planar_fog'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class planar_fog : Interfaces.Pool.Tag {
    private PlanarFogBlockBlock planarFogValues = new PlanarFogBlockBlock();
    public virtual PlanarFogBlockBlock PlanarFogValues {
      get {
        return planarFogValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PlanarFogValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "planar_fog";
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
planarFogValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
planarFogValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
planarFogValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
planarFogValues.WriteChildData(writer);
    }
    #endregion
    public class PlanarFogBlockBlock : IBlock {
      private Flags _flags;
      private ShortInteger _priority = new ShortInteger();
      private StringId _globalMaterialName = new StringId();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private RealFraction _maximumDensity = new RealFraction();
      private Real _opaqueDistance = new Real();
      private Real _opaqueDepth = new Real();
      private RealBounds _atmospheric_MinusplanarDepth = new RealBounds();
      private Real _eyeOffsetScale = new Real();
      private RealRGBColor _color = new RealRGBColor();
      private Block _patchyFog = new Block();
      private TagReference _backgroundSound = new TagReference();
      private TagReference _soundEnvironment = new TagReference();
      private Real _environmentDampingFactor = new Real();
      private Real _backgroundSoundGain = new Real();
      private TagReference _enterSound = new TagReference();
      private TagReference _exitSound = new TagReference();
      public BlockCollection<PlanarFogPatchyFogBlockBlock> _patchyFogList = new BlockCollection<PlanarFogPatchyFogBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlanarFogBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
      }
      public BlockCollection<PlanarFogPatchyFogBlockBlock> PatchyFog {
        get {
          return this._patchyFogList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundSound.Value);
references.Add(_soundEnvironment.Value);
references.Add(_enterSound.Value);
references.Add(_exitSound.Value);
for (int x=0; x<PatchyFog.BlockCount; x++)
{
  IBlock block = PatchyFog.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
        }
      }
      public StringId GlobalMaterialName {
        get {
          return this._globalMaterialName;
        }
        set {
          this._globalMaterialName = value;
        }
      }
      public RealFraction MaximumDensity {
        get {
          return this._maximumDensity;
        }
        set {
          this._maximumDensity = value;
        }
      }
      public Real OpaqueDistance {
        get {
          return this._opaqueDistance;
        }
        set {
          this._opaqueDistance = value;
        }
      }
      public Real OpaqueDepth {
        get {
          return this._opaqueDepth;
        }
        set {
          this._opaqueDepth = value;
        }
      }
      public RealBounds Atmospheric_MinusplanarDepth {
        get {
          return this._atmospheric_MinusplanarDepth;
        }
        set {
          this._atmospheric_MinusplanarDepth = value;
        }
      }
      public Real EyeOffsetScale {
        get {
          return this._eyeOffsetScale;
        }
        set {
          this._eyeOffsetScale = value;
        }
      }
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public TagReference BackgroundSound {
        get {
          return this._backgroundSound;
        }
        set {
          this._backgroundSound = value;
        }
      }
      public TagReference SoundEnvironment {
        get {
          return this._soundEnvironment;
        }
        set {
          this._soundEnvironment = value;
        }
      }
      public Real EnvironmentDampingFactor {
        get {
          return this._environmentDampingFactor;
        }
        set {
          this._environmentDampingFactor = value;
        }
      }
      public Real BackgroundSoundGain {
        get {
          return this._backgroundSoundGain;
        }
        set {
          this._backgroundSoundGain = value;
        }
      }
      public TagReference EnterSound {
        get {
          return this._enterSound;
        }
        set {
          this._enterSound = value;
        }
      }
      public TagReference ExitSound {
        get {
          return this._exitSound;
        }
        set {
          this._exitSound = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _priority.Read(reader);
        _globalMaterialName.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _maximumDensity.Read(reader);
        _opaqueDistance.Read(reader);
        _opaqueDepth.Read(reader);
        _atmospheric_MinusplanarDepth.Read(reader);
        _eyeOffsetScale.Read(reader);
        _color.Read(reader);
        _patchyFog.Read(reader);
        _backgroundSound.Read(reader);
        _soundEnvironment.Read(reader);
        _environmentDampingFactor.Read(reader);
        _backgroundSoundGain.Read(reader);
        _enterSound.Read(reader);
        _exitSound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _globalMaterialName.ReadString(reader);
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog.Add(new PlanarFogPatchyFogBlockBlock());
          PatchyFog[x].Read(reader);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].ReadChildData(reader);
        }
        _backgroundSound.ReadString(reader);
        _soundEnvironment.ReadString(reader);
        _enterSound.ReadString(reader);
        _exitSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _priority.Write(bw);
        _globalMaterialName.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _maximumDensity.Write(bw);
        _opaqueDistance.Write(bw);
        _opaqueDepth.Write(bw);
        _atmospheric_MinusplanarDepth.Write(bw);
        _eyeOffsetScale.Write(bw);
        _color.Write(bw);
_patchyFog.Count = PatchyFog.Count;
        _patchyFog.Write(bw);
        _backgroundSound.Write(bw);
        _soundEnvironment.Write(bw);
        _environmentDampingFactor.Write(bw);
        _backgroundSoundGain.Write(bw);
        _enterSound.Write(bw);
        _exitSound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _globalMaterialName.WriteString(writer);
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].Write(writer);
        }
        for (x = 0; (x < _patchyFog.Count); x = (x + 1)) {
          PatchyFog[x].WriteChildData(writer);
        }
        _backgroundSound.WriteString(writer);
        _soundEnvironment.WriteString(writer);
        _enterSound.WriteString(writer);
        _exitSound.WriteString(writer);
      }
    }
    public class PlanarFogPatchyFogBlockBlock : IBlock {
      private RealRGBColor _color = new RealRGBColor();
      private Pad _unnamed0;
      private FractionBounds _density = new FractionBounds();
      private RealBounds _distance = new RealBounds();
      private RealFraction _minDepthFraction = new RealFraction();
      private TagReference _patchyFog = new TagReference();
public event System.EventHandler BlockNameChanged;
      public PlanarFogPatchyFogBlockBlock() {
        this._unnamed0 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_patchyFog.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public FractionBounds Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public RealBounds Distance {
        get {
          return this._distance;
        }
        set {
          this._distance = value;
        }
      }
      public RealFraction MinDepthFraction {
        get {
          return this._minDepthFraction;
        }
        set {
          this._minDepthFraction = value;
        }
      }
      public TagReference PatchyFog {
        get {
          return this._patchyFog;
        }
        set {
          this._patchyFog = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _color.Read(reader);
        _unnamed0.Read(reader);
        _density.Read(reader);
        _distance.Read(reader);
        _minDepthFraction.Read(reader);
        _patchyFog.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _patchyFog.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _color.Write(bw);
        _unnamed0.Write(bw);
        _density.Write(bw);
        _distance.Write(bw);
        _minDepthFraction.Write(bw);
        _patchyFog.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _patchyFog.WriteString(writer);
      }
    }
  }
}
