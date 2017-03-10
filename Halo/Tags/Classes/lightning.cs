// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'lightning'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class lightning : Interfaces.Pool.Tag {
    private LightningBlock lightningValues = new LightningBlock();
    public virtual LightningBlock LightningValues {
      get {
        return lightningValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(LightningValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "lightning";
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
lightningValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
lightningValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
lightningValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
lightningValues.WriteChildData(writer);
    }
    #endregion
    public class LightningBlock : IBlock {
      private Pad _unnamed;
      private ShortInteger _count = new ShortInteger();
      private Pad _unnamed2;
      private Real _nearFadeDistance = new Real();
      private Real _farFadeDistance = new Real();
      private Pad _unnamed3;
      private Enum _jitterScaleSource = new Enum();
      private Enum _thicknessScaleSource = new Enum();
      private Enum _tintModulationSource = new Enum();
      private Enum _brightnessScaleSource = new Enum();
      private TagReference _bitmap = new TagReference();
      private Pad _unnamed4;
      private Block _markers = new Block();
      private Block _shader = new Block();
      private Pad _unnamed5;
      public BlockCollection<LightningMarkerBlock> _markersList = new BlockCollection<LightningMarkerBlock>();
      public BlockCollection<LightningShaderBlock> _shaderList = new BlockCollection<LightningShaderBlock>();
public event System.EventHandler BlockNameChanged;
      public LightningBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(84);
        this._unnamed5 = new Pad(88);
      }
      public BlockCollection<LightningMarkerBlock> Markers {
        get {
          return this._markersList;
        }
      }
      public BlockCollection<LightningShaderBlock> Shader {
        get {
          return this._shaderList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
for (int x=0; x<Markers.BlockCount; x++)
{
  IBlock block = Markers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Shader.BlockCount; x++)
{
  IBlock block = Shader.GetBlock(x);
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
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public Enum JitterScaleSource {
        get {
          return this._jitterScaleSource;
        }
        set {
          this._jitterScaleSource = value;
        }
      }
      public Enum ThicknessScaleSource {
        get {
          return this._thicknessScaleSource;
        }
        set {
          this._thicknessScaleSource = value;
        }
      }
      public Enum TintModulationSource {
        get {
          return this._tintModulationSource;
        }
        set {
          this._tintModulationSource = value;
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
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _nearFadeDistance.Read(reader);
        _farFadeDistance.Read(reader);
        _unnamed3.Read(reader);
        _jitterScaleSource.Read(reader);
        _thicknessScaleSource.Read(reader);
        _tintModulationSource.Read(reader);
        _brightnessScaleSource.Read(reader);
        _bitmap.Read(reader);
        _unnamed4.Read(reader);
        _markers.Read(reader);
        _shader.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmap.ReadString(reader);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers.Add(new LightningMarkerBlock());
          Markers[x].Read(reader);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _shader.Count); x = (x + 1)) {
          Shader.Add(new LightningShaderBlock());
          Shader[x].Read(reader);
        }
        for (x = 0; (x < _shader.Count); x = (x + 1)) {
          Shader[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _nearFadeDistance.Write(bw);
        _farFadeDistance.Write(bw);
        _unnamed3.Write(bw);
        _jitterScaleSource.Write(bw);
        _thicknessScaleSource.Write(bw);
        _tintModulationSource.Write(bw);
        _brightnessScaleSource.Write(bw);
        _bitmap.Write(bw);
        _unnamed4.Write(bw);
_markers.Count = Markers.Count;
        _markers.Write(bw);
_shader.Count = Shader.Count;
        _shader.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bitmap.WriteString(writer);
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].Write(writer);
        }
        for (x = 0; (x < _markers.Count); x = (x + 1)) {
          Markers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _shader.Count); x = (x + 1)) {
          Shader[x].Write(writer);
        }
        for (x = 0; (x < _shader.Count); x = (x + 1)) {
          Shader[x].WriteChildData(writer);
        }
      }
    }
    public class LightningMarkerBlock : IBlock {
      private FixedLengthString _attachmentMarker = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private ShortInteger _octavesToNextMarker = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private RealVector3D _randomPositionBounds = new RealVector3D();
      private Real _randomJitter = new Real();
      private Real _thickness = new Real();
      private RealARGBColor _tint = new RealARGBColor();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public LightningMarkerBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(76);
        this._unnamed4 = new Pad(76);
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
      public ShortInteger OctavesToNextMarker {
        get {
          return this._octavesToNextMarker;
        }
        set {
          this._octavesToNextMarker = value;
        }
      }
      public RealVector3D RandomPositionBounds {
        get {
          return this._randomPositionBounds;
        }
        set {
          this._randomPositionBounds = value;
        }
      }
      public Real RandomJitter {
        get {
          return this._randomJitter;
        }
        set {
          this._randomJitter = value;
        }
      }
      public Real Thickness {
        get {
          return this._thickness;
        }
        set {
          this._thickness = value;
        }
      }
      public RealARGBColor Tint {
        get {
          return this._tint;
        }
        set {
          this._tint = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _attachmentMarker.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _octavesToNextMarker.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _randomPositionBounds.Read(reader);
        _randomJitter.Read(reader);
        _thickness.Read(reader);
        _tint.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _attachmentMarker.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _octavesToNextMarker.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _randomPositionBounds.Write(bw);
        _randomJitter.Write(bw);
        _thickness.Write(bw);
        _tint.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LightningShaderBlock : IBlock {
      private Pad _unnamed;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Flags _mapFlags;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public LightningShaderBlock() {
        this._unnamed = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._mapFlags = new Flags(2);
        this._unnamed2 = new Pad(28);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(56);
        this._unnamed7 = new Pad(28);
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
      public Flags ShaderFlags {
        get {
          return this._shaderFlags;
        }
        set {
          this._shaderFlags = value;
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
      public Enum FramebufferFadeMode {
        get {
          return this._framebufferFadeMode;
        }
        set {
          this._framebufferFadeMode = value;
        }
      }
      public Flags MapFlags {
        get {
          return this._mapFlags;
        }
        set {
          this._mapFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
