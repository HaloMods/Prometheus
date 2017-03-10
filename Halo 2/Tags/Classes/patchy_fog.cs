// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'patchy_fog'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class patchy_fog : Interfaces.Pool.Tag {
    private PatchyFogBlockBlock patchyFogValues = new PatchyFogBlockBlock();
    public virtual PatchyFogBlockBlock PatchyFogValues {
      get {
        return patchyFogValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PatchyFogValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "patchy_fog";
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
patchyFogValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
patchyFogValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
patchyFogValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
patchyFogValues.WriteChildData(writer);
    }
    #endregion
    public class PatchyFogBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private RealFraction _rotationMultiplier = new RealFraction();
      private RealFraction _strafingMultiplier = new RealFraction();
      private RealFraction _zoomMultiplier = new RealFraction();
      private Real _noiseMapScale = new Real();
      private TagReference _noiseMap = new TagReference();
      private Real _noiseVerticalScaleForward = new Real();
      private Real _noiseVerticalScaleUp = new Real();
      private Real _noiseOpacityScaleUp = new Real();
      private Real _animationPeriod = new Real();
      private RealBounds _windVelocity = new RealBounds();
      private RealBounds _windPeriod = new RealBounds();
      private RealFraction _windAccelerationWeight = new RealFraction();
      private RealFraction _windPerpendicularWeight = new RealFraction();
      private Real _windConstantVelocityX = new Real();
      private Real _windConstantVelocityY = new Real();
      private Real _windConstantVelocityZ = new Real();
public event System.EventHandler BlockNameChanged;
      public PatchyFogBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_noiseMap.Value);
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
      public RealFraction RotationMultiplier {
        get {
          return this._rotationMultiplier;
        }
        set {
          this._rotationMultiplier = value;
        }
      }
      public RealFraction StrafingMultiplier {
        get {
          return this._strafingMultiplier;
        }
        set {
          this._strafingMultiplier = value;
        }
      }
      public RealFraction ZoomMultiplier {
        get {
          return this._zoomMultiplier;
        }
        set {
          this._zoomMultiplier = value;
        }
      }
      public Real NoiseMapScale {
        get {
          return this._noiseMapScale;
        }
        set {
          this._noiseMapScale = value;
        }
      }
      public TagReference NoiseMap {
        get {
          return this._noiseMap;
        }
        set {
          this._noiseMap = value;
        }
      }
      public Real NoiseVerticalScaleForward {
        get {
          return this._noiseVerticalScaleForward;
        }
        set {
          this._noiseVerticalScaleForward = value;
        }
      }
      public Real NoiseVerticalScaleUp {
        get {
          return this._noiseVerticalScaleUp;
        }
        set {
          this._noiseVerticalScaleUp = value;
        }
      }
      public Real NoiseOpacityScaleUp {
        get {
          return this._noiseOpacityScaleUp;
        }
        set {
          this._noiseOpacityScaleUp = value;
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
      public RealBounds WindVelocity {
        get {
          return this._windVelocity;
        }
        set {
          this._windVelocity = value;
        }
      }
      public RealBounds WindPeriod {
        get {
          return this._windPeriod;
        }
        set {
          this._windPeriod = value;
        }
      }
      public RealFraction WindAccelerationWeight {
        get {
          return this._windAccelerationWeight;
        }
        set {
          this._windAccelerationWeight = value;
        }
      }
      public RealFraction WindPerpendicularWeight {
        get {
          return this._windPerpendicularWeight;
        }
        set {
          this._windPerpendicularWeight = value;
        }
      }
      public Real WindConstantVelocityX {
        get {
          return this._windConstantVelocityX;
        }
        set {
          this._windConstantVelocityX = value;
        }
      }
      public Real WindConstantVelocityY {
        get {
          return this._windConstantVelocityY;
        }
        set {
          this._windConstantVelocityY = value;
        }
      }
      public Real WindConstantVelocityZ {
        get {
          return this._windConstantVelocityZ;
        }
        set {
          this._windConstantVelocityZ = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _rotationMultiplier.Read(reader);
        _strafingMultiplier.Read(reader);
        _zoomMultiplier.Read(reader);
        _noiseMapScale.Read(reader);
        _noiseMap.Read(reader);
        _noiseVerticalScaleForward.Read(reader);
        _noiseVerticalScaleUp.Read(reader);
        _noiseOpacityScaleUp.Read(reader);
        _animationPeriod.Read(reader);
        _windVelocity.Read(reader);
        _windPeriod.Read(reader);
        _windAccelerationWeight.Read(reader);
        _windPerpendicularWeight.Read(reader);
        _windConstantVelocityX.Read(reader);
        _windConstantVelocityY.Read(reader);
        _windConstantVelocityZ.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _noiseMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _rotationMultiplier.Write(bw);
        _strafingMultiplier.Write(bw);
        _zoomMultiplier.Write(bw);
        _noiseMapScale.Write(bw);
        _noiseMap.Write(bw);
        _noiseVerticalScaleForward.Write(bw);
        _noiseVerticalScaleUp.Write(bw);
        _noiseOpacityScaleUp.Write(bw);
        _animationPeriod.Write(bw);
        _windVelocity.Write(bw);
        _windPeriod.Write(bw);
        _windAccelerationWeight.Write(bw);
        _windPerpendicularWeight.Write(bw);
        _windConstantVelocityX.Write(bw);
        _windConstantVelocityY.Write(bw);
        _windConstantVelocityZ.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _noiseMap.WriteString(writer);
      }
    }
  }
}
