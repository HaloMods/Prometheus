// ---------------------------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'shader_transparent_glass' (derived from 'shader')
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ---------------------------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class shader_transparent_glass : shader {
    private ShaderTransparentGlassBlock shaderTransparentGlassValues = new ShaderTransparentGlassBlock();
    public virtual ShaderTransparentGlassBlock ShaderTransparentGlassValues {
      get {
        return shaderTransparentGlassValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(base.TagReferenceList);
references.AddRange(ShaderTransparentGlassValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "shader_transparent_glass";
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
shaderTransparentGlassValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
base.ReadChildData(reader);
shaderTransparentGlassValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
base.Write(writer);
shaderTransparentGlassValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
base.WriteChildData(writer);
shaderTransparentGlassValues.WriteChildData(writer);
    }
    #endregion
    public class ShaderTransparentGlassBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Pad _unnamed2;
      private RealRGBColor _backgroundTintColor = new RealRGBColor();
      private Real _backgroundTintMapScale = new Real();
      private TagReference _backgroundTintMap = new TagReference();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Enum _reflectionType = new Enum();
      private RealFraction _perpendicularBrightness = new RealFraction();
      private RealRGBColor _perpendicularTintColor = new RealRGBColor();
      private RealFraction _parallelBrightness = new RealFraction();
      private RealRGBColor _parallelTintColor = new RealRGBColor();
      private TagReference _reflectionMap = new TagReference();
      private Real _bumpMapScale = new Real();
      private TagReference _bumpMap = new TagReference();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Real _diffuseMapScale = new Real();
      private TagReference _diffuseMap = new TagReference();
      private Real _diffuseDetailMapScale = new Real();
      private TagReference _diffuseDetailMap = new TagReference();
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Real _specularMapScale = new Real();
      private TagReference _specularMap = new TagReference();
      private Real _specularDetailMapScale = new Real();
      private TagReference _specularDetailMap = new TagReference();
      private Pad _unnamed9;
public event System.EventHandler BlockNameChanged;
      public ShaderTransparentGlassBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(40);
        this._unnamed3 = new Pad(20);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(128);
        this._unnamed6 = new Pad(4);
        this._unnamed7 = new Pad(28);
        this._unnamed8 = new Pad(4);
        this._unnamed9 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundTintMap.Value);
references.Add(_reflectionMap.Value);
references.Add(_bumpMap.Value);
references.Add(_diffuseMap.Value);
references.Add(_diffuseDetailMap.Value);
references.Add(_specularMap.Value);
references.Add(_specularDetailMap.Value);
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
      public RealRGBColor BackgroundTintColor {
        get {
          return this._backgroundTintColor;
        }
        set {
          this._backgroundTintColor = value;
        }
      }
      public Real BackgroundTintMapScale {
        get {
          return this._backgroundTintMapScale;
        }
        set {
          this._backgroundTintMapScale = value;
        }
      }
      public TagReference BackgroundTintMap {
        get {
          return this._backgroundTintMap;
        }
        set {
          this._backgroundTintMap = value;
        }
      }
      public Enum ReflectionType {
        get {
          return this._reflectionType;
        }
        set {
          this._reflectionType = value;
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
      public TagReference ReflectionMap {
        get {
          return this._reflectionMap;
        }
        set {
          this._reflectionMap = value;
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
      public Real DiffuseMapScale {
        get {
          return this._diffuseMapScale;
        }
        set {
          this._diffuseMapScale = value;
        }
      }
      public TagReference DiffuseMap {
        get {
          return this._diffuseMap;
        }
        set {
          this._diffuseMap = value;
        }
      }
      public Real DiffuseDetailMapScale {
        get {
          return this._diffuseDetailMapScale;
        }
        set {
          this._diffuseDetailMapScale = value;
        }
      }
      public TagReference DiffuseDetailMap {
        get {
          return this._diffuseDetailMap;
        }
        set {
          this._diffuseDetailMap = value;
        }
      }
      public Real SpecularMapScale {
        get {
          return this._specularMapScale;
        }
        set {
          this._specularMapScale = value;
        }
      }
      public TagReference SpecularMap {
        get {
          return this._specularMap;
        }
        set {
          this._specularMap = value;
        }
      }
      public Real SpecularDetailMapScale {
        get {
          return this._specularDetailMapScale;
        }
        set {
          this._specularDetailMapScale = value;
        }
      }
      public TagReference SpecularDetailMap {
        get {
          return this._specularDetailMap;
        }
        set {
          this._specularDetailMap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _backgroundTintColor.Read(reader);
        _backgroundTintMapScale.Read(reader);
        _backgroundTintMap.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _reflectionType.Read(reader);
        _perpendicularBrightness.Read(reader);
        _perpendicularTintColor.Read(reader);
        _parallelBrightness.Read(reader);
        _parallelTintColor.Read(reader);
        _reflectionMap.Read(reader);
        _bumpMapScale.Read(reader);
        _bumpMap.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _diffuseMapScale.Read(reader);
        _diffuseMap.Read(reader);
        _diffuseDetailMapScale.Read(reader);
        _diffuseDetailMap.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _specularMapScale.Read(reader);
        _specularMap.Read(reader);
        _specularDetailMapScale.Read(reader);
        _specularDetailMap.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _backgroundTintMap.ReadString(reader);
        _reflectionMap.ReadString(reader);
        _bumpMap.ReadString(reader);
        _diffuseMap.ReadString(reader);
        _diffuseDetailMap.ReadString(reader);
        _specularMap.ReadString(reader);
        _specularDetailMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _backgroundTintColor.Write(bw);
        _backgroundTintMapScale.Write(bw);
        _backgroundTintMap.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _reflectionType.Write(bw);
        _perpendicularBrightness.Write(bw);
        _perpendicularTintColor.Write(bw);
        _parallelBrightness.Write(bw);
        _parallelTintColor.Write(bw);
        _reflectionMap.Write(bw);
        _bumpMapScale.Write(bw);
        _bumpMap.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _diffuseMapScale.Write(bw);
        _diffuseMap.Write(bw);
        _diffuseDetailMapScale.Write(bw);
        _diffuseDetailMap.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _specularMapScale.Write(bw);
        _specularMap.Write(bw);
        _specularDetailMapScale.Write(bw);
        _specularDetailMap.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _backgroundTintMap.WriteString(writer);
        _reflectionMap.WriteString(writer);
        _bumpMap.WriteString(writer);
        _diffuseMap.WriteString(writer);
        _diffuseDetailMap.WriteString(writer);
        _specularMap.WriteString(writer);
        _specularDetailMap.WriteString(writer);
      }
    }
  }
}
