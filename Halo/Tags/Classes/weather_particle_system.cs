// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'weather_particle_system'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class weather_particle_system : Interfaces.Pool.Tag {
    private WeatherParticleSystemBlock weatherParticleSystemValues = new WeatherParticleSystemBlock();
    public virtual WeatherParticleSystemBlock WeatherParticleSystemValues {
      get {
        return weatherParticleSystemValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(WeatherParticleSystemValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "weather_particle_system";
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
weatherParticleSystemValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
weatherParticleSystemValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
weatherParticleSystemValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
weatherParticleSystemValues.WriteChildData(writer);
    }
    #endregion
    public class WeatherParticleSystemBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed;
      private Block _particleTypes = new Block();
      public BlockCollection<WeatherParticleTypeBlock> _particleTypesList = new BlockCollection<WeatherParticleTypeBlock>();
public event System.EventHandler BlockNameChanged;
      public WeatherParticleSystemBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
      }
      public BlockCollection<WeatherParticleTypeBlock> ParticleTypes {
        get {
          return this._particleTypesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ParticleTypes.BlockCount; x++)
{
  IBlock block = ParticleTypes.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed.Read(reader);
        _particleTypes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes.Add(new WeatherParticleTypeBlock());
          ParticleTypes[x].Read(reader);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed.Write(bw);
_particleTypes.Count = ParticleTypes.Count;
        _particleTypes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].Write(writer);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].WriteChildData(writer);
        }
      }
    }
    public class WeatherParticleTypeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Real _fad = new Real();
      private Real _fad2 = new Real();
      private Real _fad3 = new Real();
      private Real _fad4 = new Real();
      private Real _fad5 = new Real();
      private Real _fad6 = new Real();
      private Real _fad7 = new Real();
      private Real _fad8 = new Real();
      private Pad _unnamed;
      private RealBounds _particleCount = new RealBounds();
      private TagReference _physics = new TagReference();
      private Pad _unnamed2;
      private RealBounds _accelerationMagnitude = new RealBounds();
      private RealFraction _accelerationTurningRate = new RealFraction();
      private Real _accelerationChangeRate = new Real();
      private Pad _unnamed3;
      private RealBounds _particleRadius = new RealBounds();
      private RealBounds _animationRate = new RealBounds();
      private AngleBounds _rotationRate = new AngleBounds();
      private Pad _unnamed4;
      private RealARGBColor _colorLowerBound = new RealARGBColor();
      private RealARGBColor _colorUpperBound = new RealARGBColor();
      private Pad _unnamed5;
      private TagReference _spriteBitmap = new TagReference();
      private Enum _renderMode = new Enum();
      private Enum _renderDirectionSource = new Enum();
      private Pad _unnamed6;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Flags _mapFlags;
      private Pad _unnamed7;
      private TagReference _bitmap = new TagReference();
      private Enum _anchor = new Enum();
      private Flags _flags2;
      private Enum _unnamed8 = new Enum();
      private Enum _unnamed9 = new Enum();
      private Real _unnamed10 = new Real();
      private Real _unnamed11 = new Real();
      private Real _unnamed12 = new Real();
      private Enum _unnamed13 = new Enum();
      private Enum _unnamed14 = new Enum();
      private Real _unnamed15 = new Real();
      private Real _unnamed16 = new Real();
      private Real _unnamed17 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
      private Pad _unnamed18;
      private Real _zspriteRadiusScale = new Real();
      private Pad _unnamed19;
public event System.EventHandler BlockNameChanged;
      public WeatherParticleTypeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(96);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(32);
        this._unnamed4 = new Pad(32);
        this._unnamed5 = new Pad(64);
        this._unnamed6 = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._mapFlags = new Flags(2);
        this._unnamed7 = new Pad(28);
        this._flags2 = new Flags(2);
        this._unnamed18 = new Pad(4);
        this._unnamed19 = new Pad(20);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_physics.Value);
references.Add(_spriteBitmap.Value);
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public Real Fad {
        get {
          return this._fad;
        }
        set {
          this._fad = value;
        }
      }
      public Real Fad2 {
        get {
          return this._fad2;
        }
        set {
          this._fad2 = value;
        }
      }
      public Real Fad3 {
        get {
          return this._fad3;
        }
        set {
          this._fad3 = value;
        }
      }
      public Real Fad4 {
        get {
          return this._fad4;
        }
        set {
          this._fad4 = value;
        }
      }
      public Real Fad5 {
        get {
          return this._fad5;
        }
        set {
          this._fad5 = value;
        }
      }
      public Real Fad6 {
        get {
          return this._fad6;
        }
        set {
          this._fad6 = value;
        }
      }
      public Real Fad7 {
        get {
          return this._fad7;
        }
        set {
          this._fad7 = value;
        }
      }
      public Real Fad8 {
        get {
          return this._fad8;
        }
        set {
          this._fad8 = value;
        }
      }
      public RealBounds ParticleCount {
        get {
          return this._particleCount;
        }
        set {
          this._particleCount = value;
        }
      }
      public TagReference Physics {
        get {
          return this._physics;
        }
        set {
          this._physics = value;
        }
      }
      public RealBounds AccelerationMagnitude {
        get {
          return this._accelerationMagnitude;
        }
        set {
          this._accelerationMagnitude = value;
        }
      }
      public RealFraction AccelerationTurningRate {
        get {
          return this._accelerationTurningRate;
        }
        set {
          this._accelerationTurningRate = value;
        }
      }
      public Real AccelerationChangeRate {
        get {
          return this._accelerationChangeRate;
        }
        set {
          this._accelerationChangeRate = value;
        }
      }
      public RealBounds ParticleRadius {
        get {
          return this._particleRadius;
        }
        set {
          this._particleRadius = value;
        }
      }
      public RealBounds AnimationRate {
        get {
          return this._animationRate;
        }
        set {
          this._animationRate = value;
        }
      }
      public AngleBounds RotationRate {
        get {
          return this._rotationRate;
        }
        set {
          this._rotationRate = value;
        }
      }
      public RealARGBColor ColorLowerBound {
        get {
          return this._colorLowerBound;
        }
        set {
          this._colorLowerBound = value;
        }
      }
      public RealARGBColor ColorUpperBound {
        get {
          return this._colorUpperBound;
        }
        set {
          this._colorUpperBound = value;
        }
      }
      public TagReference SpriteBitmap {
        get {
          return this._spriteBitmap;
        }
        set {
          this._spriteBitmap = value;
        }
      }
      public Enum RenderMode {
        get {
          return this._renderMode;
        }
        set {
          this._renderMode = value;
        }
      }
      public Enum RenderDirectionSource {
        get {
          return this._renderDirectionSource;
        }
        set {
          this._renderDirectionSource = value;
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
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public Enum Anchor {
        get {
          return this._anchor;
        }
        set {
          this._anchor = value;
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
      public Enum unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public Enum unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public Real unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public Real unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public Real unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public Enum unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public Enum unnamed14 {
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
      public Real unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
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
      public Real ZspriteRadiusScale {
        get {
          return this._zspriteRadiusScale;
        }
        set {
          this._zspriteRadiusScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _fad.Read(reader);
        _fad2.Read(reader);
        _fad3.Read(reader);
        _fad4.Read(reader);
        _fad5.Read(reader);
        _fad6.Read(reader);
        _fad7.Read(reader);
        _fad8.Read(reader);
        _unnamed.Read(reader);
        _particleCount.Read(reader);
        _physics.Read(reader);
        _unnamed2.Read(reader);
        _accelerationMagnitude.Read(reader);
        _accelerationTurningRate.Read(reader);
        _accelerationChangeRate.Read(reader);
        _unnamed3.Read(reader);
        _particleRadius.Read(reader);
        _animationRate.Read(reader);
        _rotationRate.Read(reader);
        _unnamed4.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _unnamed5.Read(reader);
        _spriteBitmap.Read(reader);
        _renderMode.Read(reader);
        _renderDirectionSource.Read(reader);
        _unnamed6.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed7.Read(reader);
        _bitmap.Read(reader);
        _anchor.Read(reader);
        _flags2.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
        _unnamed18.Read(reader);
        _zspriteRadiusScale.Read(reader);
        _unnamed19.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _physics.ReadString(reader);
        _spriteBitmap.ReadString(reader);
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _fad.Write(bw);
        _fad2.Write(bw);
        _fad3.Write(bw);
        _fad4.Write(bw);
        _fad5.Write(bw);
        _fad6.Write(bw);
        _fad7.Write(bw);
        _fad8.Write(bw);
        _unnamed.Write(bw);
        _particleCount.Write(bw);
        _physics.Write(bw);
        _unnamed2.Write(bw);
        _accelerationMagnitude.Write(bw);
        _accelerationTurningRate.Write(bw);
        _accelerationChangeRate.Write(bw);
        _unnamed3.Write(bw);
        _particleRadius.Write(bw);
        _animationRate.Write(bw);
        _rotationRate.Write(bw);
        _unnamed4.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _unnamed5.Write(bw);
        _spriteBitmap.Write(bw);
        _renderMode.Write(bw);
        _renderDirectionSource.Write(bw);
        _unnamed6.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed7.Write(bw);
        _bitmap.Write(bw);
        _anchor.Write(bw);
        _flags2.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
        _unnamed18.Write(bw);
        _zspriteRadiusScale.Write(bw);
        _unnamed19.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _physics.WriteString(writer);
        _spriteBitmap.WriteString(writer);
        _bitmap.WriteString(writer);
      }
    }
  }
}
