// ---------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_model' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_model : shader {
    private ShaderModelBlock shaderModelValues = new ShaderModelBlock();
    public virtual ShaderModelBlock ShaderModelValues {
      get {
        return shaderModelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderModelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_model";
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
shaderModelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderModelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderModelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderModelValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderModelBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private RealFraction _translucency = new RealFraction();
      private Pad _unnamed3;
      private Enum _changeColorSource = new Enum();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Flags _flags2;
      private Pad _unnamed6;
      private Enum _colorSource = new Enum();
      private Enum _animationFunction = new Enum();
      private Real _animationPeriod = new Real();
      private RealRGBColor _animationColorLowerBound = new RealRGBColor();
      private RealRGBColor _animationColorUpperBound = new RealRGBColor();
      private Pad _unnamed7;
      private Real _map = new Real();
      private Real _map2 = new Real();
      private TagReference _baseMap = new TagReference();
      private Pad _unnamed8;
      private TagReference _multipurposeMap = new TagReference();
      private Pad _unnamed9;
      private Enum _detailFunction = new Enum();
      private Enum _detailMask = new Enum();
      private Real _detailMapScale = new Real();
      private TagReference _detailMap = new TagReference();
      private Real _detailMap2 = new Real();
      private Pad _unnamed10;
      private Enum _unnamed11 = new Enum();
      private Enum _unnamed12 = new Enum();
      private Real _unnamed13 = new Real();
      private Real _unnamed14 = new Real();
      private Real _unnamed15 = new Real();
      private Enum _unnamed16 = new Enum();
      private Enum _unnamed17 = new Enum();
      private Real _unnamed18 = new Real();
      private Real _unnamed19 = new Real();
      private Real _unnamed20 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
      private Pad _unnamed21;
      private Real _reflectionFalloffDistance = new Real();
      private Real _reflectionCutoffDistance = new Real();
      private RealFraction _perpendicularBrightness = new RealFraction();
      private RealRGBColor _perpendicularTintColor = new RealRGBColor();
      private RealFraction _parallelBrightness = new RealFraction();
      private RealRGBColor _parallelTintColor = new RealRGBColor();
      private TagReference _reflectionCubeMap = new TagReference();
      private Pad _unnamed22;
      private Pad _unnamed23;
      private Pad _unnamed24;
      private Pad _unnamed25;
public event System.EventHandler BlockNameChanged;
      public ShaderModelBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(28);
        this._flags2 = new Flags(2);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(12);
        this._unnamed8 = new Pad(8);
        this._unnamed9 = new Pad(8);
        this._unnamed10 = new Pad(12);
        this._unnamed21 = new Pad(8);
        this._unnamed22 = new Pad(16);
        this._unnamed23 = new Pad(4);
        this._unnamed24 = new Pad(16);
        this._unnamed25 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_baseMap.Value);
references.Add(_multipurposeMap.Value);
references.Add(_detailMap.Value);
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
      public RealFraction Translucency {
        get {
          return this._translucency;
        }
        set {
          this._translucency = value;
        }
      }
      public Enum ChangeColorSource {
        get {
          return this._changeColorSource;
        }
        set {
          this._changeColorSource = value;
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
      public Enum ColorSource {
        get {
          return this._colorSource;
        }
        set {
          this._colorSource = value;
        }
      }
      public Enum AnimationFunction {
        get {
          return this._animationFunction;
        }
        set {
          this._animationFunction = value;
        }
      }
      public Real AnimationPeriod {
        get {
          return this._animationPeriod;
        }
        set {
          this._animationPeriod = value;
        }
      }
      public RealRGBColor AnimationColorLowerBound {
        get {
          return this._animationColorLowerBound;
        }
        set {
          this._animationColorLowerBound = value;
        }
      }
      public RealRGBColor AnimationColorUpperBound {
        get {
          return this._animationColorUpperBound;
        }
        set {
          this._animationColorUpperBound = value;
        }
      }
      public Real Map {
        get {
          return this._map;
        }
        set {
          this._map = value;
        }
      }
      public Real Map2 {
        get {
          return this._map2;
        }
        set {
          this._map2 = value;
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
      public TagReference MultipurposeMap {
        get {
          return this._multipurposeMap;
        }
        set {
          this._multipurposeMap = value;
        }
      }
      public Enum DetailFunction {
        get {
          return this._detailFunction;
        }
        set {
          this._detailFunction = value;
        }
      }
      public Enum DetailMask {
        get {
          return this._detailMask;
        }
        set {
          this._detailMask = value;
        }
      }
      public Real DetailMapScale {
        get {
          return this._detailMapScale;
        }
        set {
          this._detailMapScale = value;
        }
      }
      public TagReference DetailMap {
        get {
          return this._detailMap;
        }
        set {
          this._detailMap = value;
        }
      }
      public Real DetailMap2 {
        get {
          return this._detailMap2;
        }
        set {
          this._detailMap2 = value;
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
      public Enum unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
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
      public Real unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public Enum unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
        }
      }
      public Enum unnamed17 {
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
      public Real unnamed19 {
        get {
          return this._unnamed19;
        }
        set {
          this._unnamed19 = value;
        }
      }
      public Real unnamed20 {
        get {
          return this._unnamed20;
        }
        set {
          this._unnamed20 = value;
        }
      }
      public Enum Rotatio {
        get {
          return this._rotatio;
        }
        set {
          this._rotatio = value;
        }
      }
      public Enum Rotatio2 {
        get {
          return this._rotatio2;
        }
        set {
          this._rotatio2 = value;
        }
      }
      public Real Rotatio3 {
        get {
          return this._rotatio3;
        }
        set {
          this._rotatio3 = value;
        }
      }
      public Real Rotatio4 {
        get {
          return this._rotatio4;
        }
        set {
          this._rotatio4 = value;
        }
      }
      public Real Rotatio5 {
        get {
          return this._rotatio5;
        }
        set {
          this._rotatio5 = value;
        }
      }
      public RealPoint2D Rotatio6 {
        get {
          return this._rotatio6;
        }
        set {
          this._rotatio6 = value;
        }
      }
      public Real ReflectionFalloffDistance {
        get {
          return this._reflectionFalloffDistance;
        }
        set {
          this._reflectionFalloffDistance = value;
        }
      }
      public Real ReflectionCutoffDistance {
        get {
          return this._reflectionCutoffDistance;
        }
        set {
          this._reflectionCutoffDistance = value;
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
      public RealRGBColor PerpendicularTintColor {
        get {
          return this._perpendicularTintColor;
        }
        set {
          this._perpendicularTintColor = value;
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
      public RealRGBColor ParallelTintColor {
        get {
          return this._parallelTintColor;
        }
        set {
          this._parallelTintColor = value;
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
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _translucency.Read(reader);
        _unnamed3.Read(reader);
        _changeColorSource.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _flags2.Read(reader);
        _unnamed6.Read(reader);
        _colorSource.Read(reader);
        _animationFunction.Read(reader);
        _animationPeriod.Read(reader);
        _animationColorLowerBound.Read(reader);
        _animationColorUpperBound.Read(reader);
        _unnamed7.Read(reader);
        _map.Read(reader);
        _map2.Read(reader);
        _baseMap.Read(reader);
        _unnamed8.Read(reader);
        _multipurposeMap.Read(reader);
        _unnamed9.Read(reader);
        _detailFunction.Read(reader);
        _detailMask.Read(reader);
        _detailMapScale.Read(reader);
        _detailMap.Read(reader);
        _detailMap2.Read(reader);
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
        _unnamed20.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
        _unnamed21.Read(reader);
        _reflectionFalloffDistance.Read(reader);
        _reflectionCutoffDistance.Read(reader);
        _perpendicularBrightness.Read(reader);
        _perpendicularTintColor.Read(reader);
        _parallelBrightness.Read(reader);
        _parallelTintColor.Read(reader);
        _reflectionCubeMap.Read(reader);
        _unnamed22.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _unnamed25.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _baseMap.ReadString(reader);
        _multipurposeMap.ReadString(reader);
        _detailMap.ReadString(reader);
        _reflectionCubeMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _translucency.Write(bw);
        _unnamed3.Write(bw);
        _changeColorSource.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _flags2.Write(bw);
        _unnamed6.Write(bw);
        _colorSource.Write(bw);
        _animationFunction.Write(bw);
        _animationPeriod.Write(bw);
        _animationColorLowerBound.Write(bw);
        _animationColorUpperBound.Write(bw);
        _unnamed7.Write(bw);
        _map.Write(bw);
        _map2.Write(bw);
        _baseMap.Write(bw);
        _unnamed8.Write(bw);
        _multipurposeMap.Write(bw);
        _unnamed9.Write(bw);
        _detailFunction.Write(bw);
        _detailMask.Write(bw);
        _detailMapScale.Write(bw);
        _detailMap.Write(bw);
        _detailMap2.Write(bw);
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
        _unnamed20.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
        _unnamed21.Write(bw);
        _reflectionFalloffDistance.Write(bw);
        _reflectionCutoffDistance.Write(bw);
        _perpendicularBrightness.Write(bw);
        _perpendicularTintColor.Write(bw);
        _parallelBrightness.Write(bw);
        _parallelTintColor.Write(bw);
        _reflectionCubeMap.Write(bw);
        _unnamed22.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _unnamed25.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _baseMap.WriteString(writer);
        _multipurposeMap.WriteString(writer);
        _detailMap.WriteString(writer);
        _reflectionCubeMap.WriteString(writer);
      }
    }
  }
}
