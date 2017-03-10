// ---------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_water' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_water : shader {
    private ShaderTransparentWaterBlock shaderTransparentWaterValues = new ShaderTransparentWaterBlock();
    public virtual ShaderTransparentWaterBlock ShaderTransparentWaterValues {
      get {
        return shaderTransparentWaterValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentWaterValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_water";
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
shaderTransparentWaterValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentWaterValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentWaterValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentWaterValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentWaterBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private TagReference _baseMap = new TagReference();
      private Pad _unnamed3;
      private RealFraction _viewPerpendicularBrightness = new RealFraction();
      private RealRGBColor _viewPerpendicularTintColor = new RealRGBColor();
      private RealFraction _viewParallelBrightness = new RealFraction();
      private RealRGBColor _viewParallelTintColor = new RealRGBColor();
      private Pad _unnamed4;
      private TagReference _reflectionMap = new TagReference();
      private Pad _unnamed5;
      private Angle _rippleAnimationAngle = new Angle();
      private Real _rippleAnimationVelocity = new Real();
      private Real _rippleScale = new Real();
      private TagReference _rippleMaps = new TagReference();
      private ShortInteger _rippleMipmapLevels = new ShortInteger();
      private Pad _unnamed6;
      private RealFraction _rippleMipmapFadeFactor = new RealFraction();
      private Real _rippleMipmapDetailBias = new Real();
      private Pad _unnamed7;
      private Block _ripples = new Block();
      private Pad _unnamed8;
      public BlockCollection<ShaderTransparentWaterRippleBlock> _ripplesList = new BlockCollection<ShaderTransparentWaterRippleBlock>();
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentWaterBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(16);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(64);
        this._unnamed8 = new Pad(16);
      }
      public BlockCollection<ShaderTransparentWaterRippleBlock> Ripples {
        get {
          return this._ripplesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_baseMap.Value);
references.Add(_reflectionMap.Value);
references.Add(_rippleMaps.Value);
for (int x=0; x<Ripples.BlockCount; x++)
{
  IBlock block = Ripples.GetBlock(x);
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
      public TagReference BaseMap {
        get {
          return this._baseMap;
        }
        set {
          this._baseMap = value;
        }
      }
      public RealFraction ViewPerpendicularBrightness {
        get {
          return this._viewPerpendicularBrightness;
        }
        set {
          this._viewPerpendicularBrightness = value;
        }
      }
      public RealRGBColor ViewPerpendicularTintColor {
        get {
          return this._viewPerpendicularTintColor;
        }
        set {
          this._viewPerpendicularTintColor = value;
        }
      }
      public RealFraction ViewParallelBrightness {
        get {
          return this._viewParallelBrightness;
        }
        set {
          this._viewParallelBrightness = value;
        }
      }
      public RealRGBColor ViewParallelTintColor {
        get {
          return this._viewParallelTintColor;
        }
        set {
          this._viewParallelTintColor = value;
        }
      }
      public TagReference ReflectionMap {
        get {
          return this._reflectionMap;
        }
        set {
          this._reflectionMap = value;
        }
      }
      public Angle RippleAnimationAngle {
        get {
          return this._rippleAnimationAngle;
        }
        set {
          this._rippleAnimationAngle = value;
        }
      }
      public Real RippleAnimationVelocity {
        get {
          return this._rippleAnimationVelocity;
        }
        set {
          this._rippleAnimationVelocity = value;
        }
      }
      public Real RippleScale {
        get {
          return this._rippleScale;
        }
        set {
          this._rippleScale = value;
        }
      }
      public TagReference RippleMaps {
        get {
          return this._rippleMaps;
        }
        set {
          this._rippleMaps = value;
        }
      }
      public ShortInteger RippleMipmapLevels {
        get {
          return this._rippleMipmapLevels;
        }
        set {
          this._rippleMipmapLevels = value;
        }
      }
      public RealFraction RippleMipmapFadeFactor {
        get {
          return this._rippleMipmapFadeFactor;
        }
        set {
          this._rippleMipmapFadeFactor = value;
        }
      }
      public Real RippleMipmapDetailBias {
        get {
          return this._rippleMipmapDetailBias;
        }
        set {
          this._rippleMipmapDetailBias = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _baseMap.Read(reader);
        _unnamed3.Read(reader);
        _viewPerpendicularBrightness.Read(reader);
        _viewPerpendicularTintColor.Read(reader);
        _viewParallelBrightness.Read(reader);
        _viewParallelTintColor.Read(reader);
        _unnamed4.Read(reader);
        _reflectionMap.Read(reader);
        _unnamed5.Read(reader);
        _rippleAnimationAngle.Read(reader);
        _rippleAnimationVelocity.Read(reader);
        _rippleScale.Read(reader);
        _rippleMaps.Read(reader);
        _rippleMipmapLevels.Read(reader);
        _unnamed6.Read(reader);
        _rippleMipmapFadeFactor.Read(reader);
        _rippleMipmapDetailBias.Read(reader);
        _unnamed7.Read(reader);
        _ripples.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _baseMap.ReadString(reader);
        _reflectionMap.ReadString(reader);
        _rippleMaps.ReadString(reader);
        for (x = 0; (x < _ripples.Count); x = (x + 1)) {
          Ripples.Add(new ShaderTransparentWaterRippleBlock());
          Ripples[x].Read(reader);
        }
        for (x = 0; (x < _ripples.Count); x = (x + 1)) {
          Ripples[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _baseMap.Write(bw);
        _unnamed3.Write(bw);
        _viewPerpendicularBrightness.Write(bw);
        _viewPerpendicularTintColor.Write(bw);
        _viewParallelBrightness.Write(bw);
        _viewParallelTintColor.Write(bw);
        _unnamed4.Write(bw);
        _reflectionMap.Write(bw);
        _unnamed5.Write(bw);
        _rippleAnimationAngle.Write(bw);
        _rippleAnimationVelocity.Write(bw);
        _rippleScale.Write(bw);
        _rippleMaps.Write(bw);
        _rippleMipmapLevels.Write(bw);
        _unnamed6.Write(bw);
        _rippleMipmapFadeFactor.Write(bw);
        _rippleMipmapDetailBias.Write(bw);
        _unnamed7.Write(bw);
_ripples.Count = Ripples.Count;
        _ripples.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _baseMap.WriteString(writer);
        _reflectionMap.WriteString(writer);
        _rippleMaps.WriteString(writer);
        for (x = 0; (x < _ripples.Count); x = (x + 1)) {
          Ripples[x].Write(writer);
        }
        for (x = 0; (x < _ripples.Count); x = (x + 1)) {
          Ripples[x].WriteChildData(writer);
        }
      }
    }
    public class ShaderTransparentWaterRippleBlock : IBlock {
      private Pad _unnamed;
      private Pad _unnamed2;
      private RealFraction _contributionFactor = new RealFraction();
      private Pad _unnamed3;
      private Angle _animationAngle = new Angle();
      private Real _animationVelocity = new Real();
      private RealVector2D _mapOffset = new RealVector2D();
      private ShortInteger _mapRepeats = new ShortInteger();
      private ShortInteger _mapIndex = new ShortInteger();
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentWaterRippleBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(32);
        this._unnamed4 = new Pad(16);
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
      public RealFraction ContributionFactor {
        get {
          return this._contributionFactor;
        }
        set {
          this._contributionFactor = value;
        }
      }
      public Angle AnimationAngle {
        get {
          return this._animationAngle;
        }
        set {
          this._animationAngle = value;
        }
      }
      public Real AnimationVelocity {
        get {
          return this._animationVelocity;
        }
        set {
          this._animationVelocity = value;
        }
      }
      public RealVector2D MapOffset {
        get {
          return this._mapOffset;
        }
        set {
          this._mapOffset = value;
        }
      }
      public ShortInteger MapRepeats {
        get {
          return this._mapRepeats;
        }
        set {
          this._mapRepeats = value;
        }
      }
      public ShortInteger MapIndex {
        get {
          return this._mapIndex;
        }
        set {
          this._mapIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _contributionFactor.Read(reader);
        _unnamed3.Read(reader);
        _animationAngle.Read(reader);
        _animationVelocity.Read(reader);
        _mapOffset.Read(reader);
        _mapRepeats.Read(reader);
        _mapIndex.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _contributionFactor.Write(bw);
        _unnamed3.Write(bw);
        _animationAngle.Write(bw);
        _animationVelocity.Write(bw);
        _mapOffset.Write(bw);
        _mapRepeats.Write(bw);
        _mapIndex.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
