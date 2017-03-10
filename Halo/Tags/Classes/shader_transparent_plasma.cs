// ----------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_plasma' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ----------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_plasma : shader {
    private ShaderTransparentPlasmaBlock shaderTransparentPlasmaValues = new ShaderTransparentPlasmaBlock();
    public virtual ShaderTransparentPlasmaBlock ShaderTransparentPlasmaValues {
      get {
        return shaderTransparentPlasmaValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentPlasmaValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_plasma";
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
shaderTransparentPlasmaValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentPlasmaValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentPlasmaValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentPlasmaValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentPlasmaBlock : IBlock {
      private Pad _unnamed;
      private Pad _unnamed2;
      private Enum _intensitySource = new Enum();
      private Pad _unnamed3;
      private Real _intensityExponent = new Real();
      private Enum _offsetSource = new Enum();
      private Pad _unnamed4;
      private Real _offsetAmount = new Real();
      private Real _offsetExponent = new Real();
      private Pad _unnamed5;
      private RealFraction _perpendicularBrightness = new RealFraction();
      private RealRGBColor _perpendicularTintColor = new RealRGBColor();
      private RealFraction _parallelBrightness = new RealFraction();
      private RealRGBColor _parallelTintColor = new RealRGBColor();
      private Enum _tintColorSource = new Enum();
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Pad _unnamed9;
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Pad _unnamed12;
      private Real _primaryAnimationPeriod = new Real();
      private RealVector3D _primaryAnimationDirection = new RealVector3D();
      private Real _primaryNoiseMapScale = new Real();
      private TagReference _primaryNoiseMap = new TagReference();
      private Pad _unnamed13;
      private Pad _unnamed14;
      private Real _secondaryAnimationPeriod = new Real();
      private RealVector3D _secondaryAnimationDirection = new RealVector3D();
      private Real _secondaryNoiseMapScale = new Real();
      private TagReference _secondaryNoiseMap = new TagReference();
      private Pad _unnamed15;
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentPlasmaBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(32);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(2);
        this._unnamed10 = new Pad(16);
        this._unnamed11 = new Pad(4);
        this._unnamed12 = new Pad(4);
        this._unnamed13 = new Pad(32);
        this._unnamed14 = new Pad(4);
        this._unnamed15 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_primaryNoiseMap.Value);
references.Add(_secondaryNoiseMap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum IntensitySource {
        get {
          return this._intensitySource;
        }
        set {
          this._intensitySource = value;
        }
      }
      public Real IntensityExponent {
        get {
          return this._intensityExponent;
        }
        set {
          this._intensityExponent = value;
        }
      }
      public Enum OffsetSource {
        get {
          return this._offsetSource;
        }
        set {
          this._offsetSource = value;
        }
      }
      public Real OffsetAmount {
        get {
          return this._offsetAmount;
        }
        set {
          this._offsetAmount = value;
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
      public Enum TintColorSource {
        get {
          return this._tintColorSource;
        }
        set {
          this._tintColorSource = value;
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
      public RealVector3D PrimaryAnimationDirection {
        get {
          return this._primaryAnimationDirection;
        }
        set {
          this._primaryAnimationDirection = value;
        }
      }
      public Real PrimaryNoiseMapScale {
        get {
          return this._primaryNoiseMapScale;
        }
        set {
          this._primaryNoiseMapScale = value;
        }
      }
      public TagReference PrimaryNoiseMap {
        get {
          return this._primaryNoiseMap;
        }
        set {
          this._primaryNoiseMap = value;
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
      public RealVector3D SecondaryAnimationDirection {
        get {
          return this._secondaryAnimationDirection;
        }
        set {
          this._secondaryAnimationDirection = value;
        }
      }
      public Real SecondaryNoiseMapScale {
        get {
          return this._secondaryNoiseMapScale;
        }
        set {
          this._secondaryNoiseMapScale = value;
        }
      }
      public TagReference SecondaryNoiseMap {
        get {
          return this._secondaryNoiseMap;
        }
        set {
          this._secondaryNoiseMap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _intensitySource.Read(reader);
        _unnamed3.Read(reader);
        _intensityExponent.Read(reader);
        _offsetSource.Read(reader);
        _unnamed4.Read(reader);
        _offsetAmount.Read(reader);
        _offsetExponent.Read(reader);
        _unnamed5.Read(reader);
        _perpendicularBrightness.Read(reader);
        _perpendicularTintColor.Read(reader);
        _parallelBrightness.Read(reader);
        _parallelTintColor.Read(reader);
        _tintColorSource.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _primaryAnimationPeriod.Read(reader);
        _primaryAnimationDirection.Read(reader);
        _primaryNoiseMapScale.Read(reader);
        _primaryNoiseMap.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _secondaryAnimationPeriod.Read(reader);
        _secondaryAnimationDirection.Read(reader);
        _secondaryNoiseMapScale.Read(reader);
        _secondaryNoiseMap.Read(reader);
        _unnamed15.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _primaryNoiseMap.ReadString(reader);
        _secondaryNoiseMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _intensitySource.Write(bw);
        _unnamed3.Write(bw);
        _intensityExponent.Write(bw);
        _offsetSource.Write(bw);
        _unnamed4.Write(bw);
        _offsetAmount.Write(bw);
        _offsetExponent.Write(bw);
        _unnamed5.Write(bw);
        _perpendicularBrightness.Write(bw);
        _perpendicularTintColor.Write(bw);
        _parallelBrightness.Write(bw);
        _parallelTintColor.Write(bw);
        _tintColorSource.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _primaryAnimationPeriod.Write(bw);
        _primaryAnimationDirection.Write(bw);
        _primaryNoiseMapScale.Write(bw);
        _primaryNoiseMap.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _secondaryAnimationPeriod.Write(bw);
        _secondaryAnimationDirection.Write(bw);
        _secondaryNoiseMapScale.Write(bw);
        _secondaryNoiseMap.Write(bw);
        _unnamed15.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _primaryNoiseMap.WriteString(writer);
        _secondaryNoiseMap.WriteString(writer);
      }
    }
  }
}
