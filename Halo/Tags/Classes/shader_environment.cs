// ---------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_environment' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_environment : shader {
    private ShaderEnvironmentBlock shaderEnvironmentValues = new ShaderEnvironmentBlock();
    public virtual ShaderEnvironmentBlock ShaderEnvironmentValues {
      get {
        return shaderEnvironmentValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderEnvironmentValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_environment";
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
shaderEnvironmentValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderEnvironmentValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderEnvironmentValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderEnvironmentValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderEnvironmentBlock : IBlock {
      private Flags _flags;
      private Enum _type = new Enum();
      private Real _lensFlareSpacing = new Real();
      private TagReference _lensFlare = new TagReference();
      private Pad _unnamed;
      private Flags _flags2;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private TagReference _baseMap = new TagReference();
      private Pad _unnamed4;
      private Enum _detailMapFunction = new Enum();
      private Pad _unnamed5;
      private Real _primaryDetailMapScale = new Real();
      private TagReference _primaryDetailMap = new TagReference();
      private Real _secondaryDetailMapScale = new Real();
      private TagReference _secondaryDetailMap = new TagReference();
      private Pad _unnamed6;
      private Enum _microDetailMapFunction = new Enum();
      private Pad _unnamed7;
      private Real _microDetailMapScale = new Real();
      private TagReference _microDetailMap = new TagReference();
      private RealRGBColor _materialColor = new RealRGBColor();
      private Pad _unnamed8;
      private Real _bumpMapScale = new Real();
      private TagReference _bumpMap = new TagReference();
      private Pad _unnamed9;
      private Pad _unnamed10;
      private Enum _unnamed11 = new Enum();
      private Pad _unnamed12;
      private Real _unnamed13 = new Real();
      private Real _unnamed14 = new Real();
      private Enum _unnamed15 = new Enum();
      private Pad _unnamed16;
      private Real _unnamed17 = new Real();
      private Real _unnamed18 = new Real();
      private Pad _unnamed19;
      private Flags _flags3;
      private Pad _unnamed20;
      private Pad _unnamed21;
      private RealRGBColor _primaryOnColor = new RealRGBColor();
      private RealRGBColor _primaryOffColor = new RealRGBColor();
      private Enum _primaryAnimationFunction = new Enum();
      private Pad _unnamed22;
      private Real _primaryAnimationPeriod = new Real();
      private Real _primaryAnimationPhase = new Real();
      private Pad _unnamed23;
      private RealRGBColor _secondaryOnColor = new RealRGBColor();
      private RealRGBColor _secondaryOffColor = new RealRGBColor();
      private Enum _secondaryAnimationFunction = new Enum();
      private Pad _unnamed24;
      private Real _secondaryAnimationPeriod = new Real();
      private Real _secondaryAnimationPhase = new Real();
      private Pad _unnamed25;
      private RealRGBColor _plasmaOnColor = new RealRGBColor();
      private RealRGBColor _plasmaOffColor = new RealRGBColor();
      private Enum _plasmaAnimationFunction = new Enum();
      private Pad _unnamed26;
      private Real _plasmaAnimationPeriod = new Real();
      private Real _plasmaAnimationPhase = new Real();
      private Pad _unnamed27;
      private Real _mapScale = new Real();
      private TagReference _map = new TagReference();
      private Pad _unnamed28;
      private Flags _flags4;
      private Pad _unnamed29;
      private Pad _unnamed30;
      private RealFraction _brightness = new RealFraction();
      private Pad _unnamed31;
      private RealRGBColor _perpendicularColor = new RealRGBColor();
      private RealRGBColor _parallelColor = new RealRGBColor();
      private Pad _unnamed32;
      private Flags _flags5;
      private Enum _type2 = new Enum();
      private RealFraction _lightmapBrightnessScale = new RealFraction();
      private Pad _unnamed33;
      private RealFraction _perpendicularBrightness = new RealFraction();
      private RealFraction _parallelBrightness = new RealFraction();
      private Pad _unnamed34;
      private Pad _unnamed35;
      private Pad _unnamed36;
      private TagReference _reflectionCubeMap = new TagReference();
      private Pad _unnamed37;
public event System.EventHandler BlockNameChanged;
      public ShaderEnvironmentBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(44);
        this._flags2 = new Flags(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(24);
        this._unnamed4 = new Pad(24);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(24);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(12);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(16);
        this._unnamed12 = new Pad(2);
        this._unnamed16 = new Pad(2);
        this._unnamed19 = new Pad(24);
        this._flags3 = new Flags(2);
        this._unnamed20 = new Pad(2);
        this._unnamed21 = new Pad(24);
        this._unnamed22 = new Pad(2);
        this._unnamed23 = new Pad(24);
        this._unnamed24 = new Pad(2);
        this._unnamed25 = new Pad(24);
        this._unnamed26 = new Pad(2);
        this._unnamed27 = new Pad(24);
        this._unnamed28 = new Pad(24);
        this._flags4 = new Flags(2);
        this._unnamed29 = new Pad(2);
        this._unnamed30 = new Pad(16);
        this._unnamed31 = new Pad(20);
        this._unnamed32 = new Pad(16);
        this._flags5 = new Flags(2);
        this._unnamed33 = new Pad(28);
        this._unnamed34 = new Pad(16);
        this._unnamed35 = new Pad(8);
        this._unnamed36 = new Pad(16);
        this._unnamed37 = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_lensFlare.Value);
references.Add(_baseMap.Value);
references.Add(_primaryDetailMap.Value);
references.Add(_secondaryDetailMap.Value);
references.Add(_microDetailMap.Value);
references.Add(_bumpMap.Value);
references.Add(_map.Value);
references.Add(_reflectionCubeMap.Value);
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
      public Real LensFlareSpacing {
        get {
          return this._lensFlareSpacing;
        }
        set {
          this._lensFlareSpacing = value;
        }
      }
      public TagReference LensFlare {
        get {
          return this._lensFlare;
        }
        set {
          this._lensFlare = value;
        }
      }
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
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
      public Enum DetailMapFunction {
        get {
          return this._detailMapFunction;
        }
        set {
          this._detailMapFunction = value;
        }
      }
      public Real PrimaryDetailMapScale {
        get {
          return this._primaryDetailMapScale;
        }
        set {
          this._primaryDetailMapScale = value;
        }
      }
      public TagReference PrimaryDetailMap {
        get {
          return this._primaryDetailMap;
        }
        set {
          this._primaryDetailMap = value;
        }
      }
      public Real SecondaryDetailMapScale {
        get {
          return this._secondaryDetailMapScale;
        }
        set {
          this._secondaryDetailMapScale = value;
        }
      }
      public TagReference SecondaryDetailMap {
        get {
          return this._secondaryDetailMap;
        }
        set {
          this._secondaryDetailMap = value;
        }
      }
      public Enum MicroDetailMapFunction {
        get {
          return this._microDetailMapFunction;
        }
        set {
          this._microDetailMapFunction = value;
        }
      }
      public Real MicroDetailMapScale {
        get {
          return this._microDetailMapScale;
        }
        set {
          this._microDetailMapScale = value;
        }
      }
      public TagReference MicroDetailMap {
        get {
          return this._microDetailMap;
        }
        set {
          this._microDetailMap = value;
        }
      }
      public RealRGBColor MaterialColor {
        get {
          return this._materialColor;
        }
        set {
          this._materialColor = value;
        }
      }
      public Real BumpMapScale {
        get {
          return this._bumpMapScale;
        }
        set {
          this._bumpMapScale = value;
        }
      }
      public TagReference BumpMap {
        get {
          return this._bumpMap;
        }
        set {
          this._bumpMap = value;
        }
      }
      public Enum unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Real unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public Real unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
        }
      }
      public Enum unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public Real unnamed17 {
        get {
          return this._unnamed17;
        }
        set {
          this._unnamed17 = value;
        }
      }
      public Real unnamed18 {
        get {
          return this._unnamed18;
        }
        set {
          this._unnamed18 = value;
        }
      }
      public Flags Flags3 {
        get {
          return this._flags3;
        }
        set {
          this._flags3 = value;
        }
      }
      public RealRGBColor PrimaryOnColor {
        get {
          return this._primaryOnColor;
        }
        set {
          this._primaryOnColor = value;
        }
      }
      public RealRGBColor PrimaryOffColor {
        get {
          return this._primaryOffColor;
        }
        set {
          this._primaryOffColor = value;
        }
      }
      public Enum PrimaryAnimationFunction {
        get {
          return this._primaryAnimationFunction;
        }
        set {
          this._primaryAnimationFunction = value;
        }
      }
      public Real PrimaryAnimationPeriod {
        get {
          return this._primaryAnimationPeriod;
        }
        set {
          this._primaryAnimationPeriod = value;
        }
      }
      public Real PrimaryAnimationPhase {
        get {
          return this._primaryAnimationPhase;
        }
        set {
          this._primaryAnimationPhase = value;
        }
      }
      public RealRGBColor SecondaryOnColor {
        get {
          return this._secondaryOnColor;
        }
        set {
          this._secondaryOnColor = value;
        }
      }
      public RealRGBColor SecondaryOffColor {
        get {
          return this._secondaryOffColor;
        }
        set {
          this._secondaryOffColor = value;
        }
      }
      public Enum SecondaryAnimationFunction {
        get {
          return this._secondaryAnimationFunction;
        }
        set {
          this._secondaryAnimationFunction = value;
        }
      }
      public Real SecondaryAnimationPeriod {
        get {
          return this._secondaryAnimationPeriod;
        }
        set {
          this._secondaryAnimationPeriod = value;
        }
      }
      public Real SecondaryAnimationPhase {
        get {
          return this._secondaryAnimationPhase;
        }
        set {
          this._secondaryAnimationPhase = value;
        }
      }
      public RealRGBColor PlasmaOnColor {
        get {
          return this._plasmaOnColor;
        }
        set {
          this._plasmaOnColor = value;
        }
      }
      public RealRGBColor PlasmaOffColor {
        get {
          return this._plasmaOffColor;
        }
        set {
          this._plasmaOffColor = value;
        }
      }
      public Enum PlasmaAnimationFunction {
        get {
          return this._plasmaAnimationFunction;
        }
        set {
          this._plasmaAnimationFunction = value;
        }
      }
      public Real PlasmaAnimationPeriod {
        get {
          return this._plasmaAnimationPeriod;
        }
        set {
          this._plasmaAnimationPeriod = value;
        }
      }
      public Real PlasmaAnimationPhase {
        get {
          return this._plasmaAnimationPhase;
        }
        set {
          this._plasmaAnimationPhase = value;
        }
      }
      public Real MapScale {
        get {
          return this._mapScale;
        }
        set {
          this._mapScale = value;
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
      public Flags Flags4 {
        get {
          return this._flags4;
        }
        set {
          this._flags4 = value;
        }
      }
      public RealFraction Brightness {
        get {
          return this._brightness;
        }
        set {
          this._brightness = value;
        }
      }
      public RealRGBColor PerpendicularColor {
        get {
          return this._perpendicularColor;
        }
        set {
          this._perpendicularColor = value;
        }
      }
      public RealRGBColor ParallelColor {
        get {
          return this._parallelColor;
        }
        set {
          this._parallelColor = value;
        }
      }
      public Flags Flags5 {
        get {
          return this._flags5;
        }
        set {
          this._flags5 = value;
        }
      }
      public Enum Type2 {
        get {
          return this._type2;
        }
        set {
          this._type2 = value;
        }
      }
      public RealFraction LightmapBrightnessScale {
        get {
          return this._lightmapBrightnessScale;
        }
        set {
          this._lightmapBrightnessScale = value;
        }
      }
      public RealFraction PerpendicularBrightness {
        get {
          return this._perpendicularBrightness;
        }
        set {
          this._perpendicularBrightness = value;
        }
      }
      public RealFraction ParallelBrightness {
        get {
          return this._parallelBrightness;
        }
        set {
          this._parallelBrightness = value;
        }
      }
      public TagReference ReflectionCubeMap {
        get {
          return this._reflectionCubeMap;
        }
        set {
          this._reflectionCubeMap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type.Read(reader);
        _lensFlareSpacing.Read(reader);
        _lensFlare.Read(reader);
        _unnamed.Read(reader);
        _flags2.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _baseMap.Read(reader);
        _unnamed4.Read(reader);
        _detailMapFunction.Read(reader);
        _unnamed5.Read(reader);
        _primaryDetailMapScale.Read(reader);
        _primaryDetailMap.Read(reader);
        _secondaryDetailMapScale.Read(reader);
        _secondaryDetailMap.Read(reader);
        _unnamed6.Read(reader);
        _microDetailMapFunction.Read(reader);
        _unnamed7.Read(reader);
        _microDetailMapScale.Read(reader);
        _microDetailMap.Read(reader);
        _materialColor.Read(reader);
        _unnamed8.Read(reader);
        _bumpMapScale.Read(reader);
        _bumpMap.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _flags3.Read(reader);
        _unnamed20.Read(reader);
        _unnamed21.Read(reader);
        _primaryOnColor.Read(reader);
        _primaryOffColor.Read(reader);
        _primaryAnimationFunction.Read(reader);
        _unnamed22.Read(reader);
        _primaryAnimationPeriod.Read(reader);
        _primaryAnimationPhase.Read(reader);
        _unnamed23.Read(reader);
        _secondaryOnColor.Read(reader);
        _secondaryOffColor.Read(reader);
        _secondaryAnimationFunction.Read(reader);
        _unnamed24.Read(reader);
        _secondaryAnimationPeriod.Read(reader);
        _secondaryAnimationPhase.Read(reader);
        _unnamed25.Read(reader);
        _plasmaOnColor.Read(reader);
        _plasmaOffColor.Read(reader);
        _plasmaAnimationFunction.Read(reader);
        _unnamed26.Read(reader);
        _plasmaAnimationPeriod.Read(reader);
        _plasmaAnimationPhase.Read(reader);
        _unnamed27.Read(reader);
        _mapScale.Read(reader);
        _map.Read(reader);
        _unnamed28.Read(reader);
        _flags4.Read(reader);
        _unnamed29.Read(reader);
        _unnamed30.Read(reader);
        _brightness.Read(reader);
        _unnamed31.Read(reader);
        _perpendicularColor.Read(reader);
        _parallelColor.Read(reader);
        _unnamed32.Read(reader);
        _flags5.Read(reader);
        _type2.Read(reader);
        _lightmapBrightnessScale.Read(reader);
        _unnamed33.Read(reader);
        _perpendicularBrightness.Read(reader);
        _parallelBrightness.Read(reader);
        _unnamed34.Read(reader);
        _unnamed35.Read(reader);
        _unnamed36.Read(reader);
        _reflectionCubeMap.Read(reader);
        _unnamed37.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _lensFlare.ReadString(reader);
        _baseMap.ReadString(reader);
        _primaryDetailMap.ReadString(reader);
        _secondaryDetailMap.ReadString(reader);
        _microDetailMap.ReadString(reader);
        _bumpMap.ReadString(reader);
        _map.ReadString(reader);
        _reflectionCubeMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _lensFlareSpacing.Write(bw);
        _lensFlare.Write(bw);
        _unnamed.Write(bw);
        _flags2.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _baseMap.Write(bw);
        _unnamed4.Write(bw);
        _detailMapFunction.Write(bw);
        _unnamed5.Write(bw);
        _primaryDetailMapScale.Write(bw);
        _primaryDetailMap.Write(bw);
        _secondaryDetailMapScale.Write(bw);
        _secondaryDetailMap.Write(bw);
        _unnamed6.Write(bw);
        _microDetailMapFunction.Write(bw);
        _unnamed7.Write(bw);
        _microDetailMapScale.Write(bw);
        _microDetailMap.Write(bw);
        _materialColor.Write(bw);
        _unnamed8.Write(bw);
        _bumpMapScale.Write(bw);
        _bumpMap.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _flags3.Write(bw);
        _unnamed20.Write(bw);
        _unnamed21.Write(bw);
        _primaryOnColor.Write(bw);
        _primaryOffColor.Write(bw);
        _primaryAnimationFunction.Write(bw);
        _unnamed22.Write(bw);
        _primaryAnimationPeriod.Write(bw);
        _primaryAnimationPhase.Write(bw);
        _unnamed23.Write(bw);
        _secondaryOnColor.Write(bw);
        _secondaryOffColor.Write(bw);
        _secondaryAnimationFunction.Write(bw);
        _unnamed24.Write(bw);
        _secondaryAnimationPeriod.Write(bw);
        _secondaryAnimationPhase.Write(bw);
        _unnamed25.Write(bw);
        _plasmaOnColor.Write(bw);
        _plasmaOffColor.Write(bw);
        _plasmaAnimationFunction.Write(bw);
        _unnamed26.Write(bw);
        _plasmaAnimationPeriod.Write(bw);
        _plasmaAnimationPhase.Write(bw);
        _unnamed27.Write(bw);
        _mapScale.Write(bw);
        _map.Write(bw);
        _unnamed28.Write(bw);
        _flags4.Write(bw);
        _unnamed29.Write(bw);
        _unnamed30.Write(bw);
        _brightness.Write(bw);
        _unnamed31.Write(bw);
        _perpendicularColor.Write(bw);
        _parallelColor.Write(bw);
        _unnamed32.Write(bw);
        _flags5.Write(bw);
        _type2.Write(bw);
        _lightmapBrightnessScale.Write(bw);
        _unnamed33.Write(bw);
        _perpendicularBrightness.Write(bw);
        _parallelBrightness.Write(bw);
        _unnamed34.Write(bw);
        _unnamed35.Write(bw);
        _unnamed36.Write(bw);
        _reflectionCubeMap.Write(bw);
        _unnamed37.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _lensFlare.WriteString(writer);
        _baseMap.WriteString(writer);
        _primaryDetailMap.WriteString(writer);
        _secondaryDetailMap.WriteString(writer);
        _microDetailMap.WriteString(writer);
        _bumpMap.WriteString(writer);
        _map.WriteString(writer);
        _reflectionCubeMap.WriteString(writer);
      }
    }
  }
}
