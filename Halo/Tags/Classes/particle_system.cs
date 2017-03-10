// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'particle_system'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class particle_system : Interfaces.Pool.Tag {
    private ParticleSystemBlock particleSystemValues = new ParticleSystemBlock();
    public virtual ParticleSystemBlock ParticleSystemValues {
      get {
        return particleSystemValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ParticleSystemValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "particle_system";
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
particleSystemValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
particleSystemValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
particleSystemValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
particleSystemValues.WriteChildData(writer);
    }
    #endregion
    public class ParticleSystemBlock : IBlock {
      private Pad _unnamed;
      private Pad _unnamed2;
      private TagReference _pointPhysics = new TagReference();
      private Enum _systemUpdatePhysics = new Enum();
      private Pad _unnamed3;
      private Flags _physicsFlags;
      private Block _physicsConstants = new Block();
      private Block _particleTypes = new Block();
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> _physicsConstantsList = new BlockCollection<ParticleSystemPhysicsConstantsBlock>();
      public BlockCollection<ParticleSystemTypesBlock> _particleTypesList = new BlockCollection<ParticleSystemTypesBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemBlock() {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(52);
        this._unnamed3 = new Pad(2);
        this._physicsFlags = new Flags(4);
      }
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> PhysicsConstants {
        get {
          return this._physicsConstantsList;
        }
      }
      public BlockCollection<ParticleSystemTypesBlock> ParticleTypes {
        get {
          return this._particleTypesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_pointPhysics.Value);
for (int x=0; x<PhysicsConstants.BlockCount; x++)
{
  IBlock block = PhysicsConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public TagReference PointPhysics {
        get {
          return this._pointPhysics;
        }
        set {
          this._pointPhysics = value;
        }
      }
      public Enum SystemUpdatePhysics {
        get {
          return this._systemUpdatePhysics;
        }
        set {
          this._systemUpdatePhysics = value;
        }
      }
      public Flags PhysicsFlags {
        get {
          return this._physicsFlags;
        }
        set {
          this._physicsFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _pointPhysics.Read(reader);
        _systemUpdatePhysics.Read(reader);
        _unnamed3.Read(reader);
        _physicsFlags.Read(reader);
        _physicsConstants.Read(reader);
        _particleTypes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _pointPhysics.ReadString(reader);
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants.Add(new ParticleSystemPhysicsConstantsBlock());
          PhysicsConstants[x].Read(reader);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes.Add(new ParticleSystemTypesBlock());
          ParticleTypes[x].Read(reader);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _pointPhysics.Write(bw);
        _systemUpdatePhysics.Write(bw);
        _unnamed3.Write(bw);
        _physicsFlags.Write(bw);
_physicsConstants.Count = PhysicsConstants.Count;
        _physicsConstants.Write(bw);
_particleTypes.Count = ParticleTypes.Count;
        _particleTypes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _pointPhysics.WriteString(writer);
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].Write(writer);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].Write(writer);
        }
        for (x = 0; (x < _particleTypes.Count); x = (x + 1)) {
          ParticleTypes[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleSystemPhysicsConstantsBlock : IBlock {
      private Real _k = new Real();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemPhysicsConstantsBlock() {
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
      public Real K {
        get {
          return this._k;
        }
        set {
          this._k = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _k.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _k.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ParticleSystemTypesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private ShortInteger _initialParticleCount = new ShortInteger();
      private Pad _unnamed;
      private Enum _complexSpriteRenderModes = new Enum();
      private Pad _unnamed2;
      private Real _radius = new Real();
      private Pad _unnamed3;
      private Enum _particleCreationPhysics = new Enum();
      private Pad _unnamed4;
      private Flags _physicsFlags;
      private Block _physicsConstants = new Block();
      private Block _states = new Block();
      private Block _particleStates = new Block();
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> _physicsConstantsList = new BlockCollection<ParticleSystemPhysicsConstantsBlock>();
      public BlockCollection<ParticleSystemTypeStatesBlock> _statesList = new BlockCollection<ParticleSystemTypeStatesBlock>();
      public BlockCollection<ParticleSystemTypeParticleStatesBlock> _particleStatesList = new BlockCollection<ParticleSystemTypeParticleStatesBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemTypesBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(36);
        this._unnamed4 = new Pad(2);
        this._physicsFlags = new Flags(4);
      }
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> PhysicsConstants {
        get {
          return this._physicsConstantsList;
        }
      }
      public BlockCollection<ParticleSystemTypeStatesBlock> States {
        get {
          return this._statesList;
        }
      }
      public BlockCollection<ParticleSystemTypeParticleStatesBlock> ParticleStates {
        get {
          return this._particleStatesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PhysicsConstants.BlockCount; x++)
{
  IBlock block = PhysicsConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<States.BlockCount; x++)
{
  IBlock block = States.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParticleStates.BlockCount; x++)
{
  IBlock block = ParticleStates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public ShortInteger InitialParticleCount {
        get {
          return this._initialParticleCount;
        }
        set {
          this._initialParticleCount = value;
        }
      }
      public Enum ComplexSpriteRenderModes {
        get {
          return this._complexSpriteRenderModes;
        }
        set {
          this._complexSpriteRenderModes = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public Enum ParticleCreationPhysics {
        get {
          return this._particleCreationPhysics;
        }
        set {
          this._particleCreationPhysics = value;
        }
      }
      public Flags PhysicsFlags {
        get {
          return this._physicsFlags;
        }
        set {
          this._physicsFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _initialParticleCount.Read(reader);
        _unnamed.Read(reader);
        _complexSpriteRenderModes.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _unnamed3.Read(reader);
        _particleCreationPhysics.Read(reader);
        _unnamed4.Read(reader);
        _physicsFlags.Read(reader);
        _physicsConstants.Read(reader);
        _states.Read(reader);
        _particleStates.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants.Add(new ParticleSystemPhysicsConstantsBlock());
          PhysicsConstants[x].Read(reader);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States.Add(new ParticleSystemTypeStatesBlock());
          States[x].Read(reader);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particleStates.Count); x = (x + 1)) {
          ParticleStates.Add(new ParticleSystemTypeParticleStatesBlock());
          ParticleStates[x].Read(reader);
        }
        for (x = 0; (x < _particleStates.Count); x = (x + 1)) {
          ParticleStates[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _initialParticleCount.Write(bw);
        _unnamed.Write(bw);
        _complexSpriteRenderModes.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _unnamed3.Write(bw);
        _particleCreationPhysics.Write(bw);
        _unnamed4.Write(bw);
        _physicsFlags.Write(bw);
_physicsConstants.Count = PhysicsConstants.Count;
        _physicsConstants.Write(bw);
_states.Count = States.Count;
        _states.Write(bw);
_particleStates.Count = ParticleStates.Count;
        _particleStates.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].Write(writer);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].Write(writer);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particleStates.Count); x = (x + 1)) {
          ParticleStates[x].Write(writer);
        }
        for (x = 0; (x < _particleStates.Count); x = (x + 1)) {
          ParticleStates[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleSystemTypeStatesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealBounds _durationBounds = new RealBounds();
      private RealBounds _transitionTimeBounds = new RealBounds();
      private Pad _unnamed;
      private Real _scaleMultiplier = new Real();
      private Real _animationratemultiplier = new Real();
      private Real _rotationRateMultiplier = new Real();
      private RealARGBColor _colorMultiplier = new RealARGBColor();
      private Real _radiusMultiplier = new Real();
      private Real _minimumParticleCount = new Real();
      private Real _particleCreationRate = new Real();
      private Pad _unnamed2;
      private Enum _particleCreationPhysics = new Enum();
      private Enum _particleUpdatePhysics = new Enum();
      private Block _physicsConstants = new Block();
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> _physicsConstantsList = new BlockCollection<ParticleSystemPhysicsConstantsBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemTypeStatesBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(84);
      }
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> PhysicsConstants {
        get {
          return this._physicsConstantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PhysicsConstants.BlockCount; x++)
{
  IBlock block = PhysicsConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public RealBounds DurationBounds {
        get {
          return this._durationBounds;
        }
        set {
          this._durationBounds = value;
        }
      }
      public RealBounds TransitionTimeBounds {
        get {
          return this._transitionTimeBounds;
        }
        set {
          this._transitionTimeBounds = value;
        }
      }
      public Real ScaleMultiplier {
        get {
          return this._scaleMultiplier;
        }
        set {
          this._scaleMultiplier = value;
        }
      }
      public Real Animationratemultiplier {
        get {
          return this._animationratemultiplier;
        }
        set {
          this._animationratemultiplier = value;
        }
      }
      public Real RotationRateMultiplier {
        get {
          return this._rotationRateMultiplier;
        }
        set {
          this._rotationRateMultiplier = value;
        }
      }
      public RealARGBColor ColorMultiplier {
        get {
          return this._colorMultiplier;
        }
        set {
          this._colorMultiplier = value;
        }
      }
      public Real RadiusMultiplier {
        get {
          return this._radiusMultiplier;
        }
        set {
          this._radiusMultiplier = value;
        }
      }
      public Real MinimumParticleCount {
        get {
          return this._minimumParticleCount;
        }
        set {
          this._minimumParticleCount = value;
        }
      }
      public Real ParticleCreationRate {
        get {
          return this._particleCreationRate;
        }
        set {
          this._particleCreationRate = value;
        }
      }
      public Enum ParticleCreationPhysics {
        get {
          return this._particleCreationPhysics;
        }
        set {
          this._particleCreationPhysics = value;
        }
      }
      public Enum ParticleUpdatePhysics {
        get {
          return this._particleUpdatePhysics;
        }
        set {
          this._particleUpdatePhysics = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _durationBounds.Read(reader);
        _transitionTimeBounds.Read(reader);
        _unnamed.Read(reader);
        _scaleMultiplier.Read(reader);
        _animationratemultiplier.Read(reader);
        _rotationRateMultiplier.Read(reader);
        _colorMultiplier.Read(reader);
        _radiusMultiplier.Read(reader);
        _minimumParticleCount.Read(reader);
        _particleCreationRate.Read(reader);
        _unnamed2.Read(reader);
        _particleCreationPhysics.Read(reader);
        _particleUpdatePhysics.Read(reader);
        _physicsConstants.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants.Add(new ParticleSystemPhysicsConstantsBlock());
          PhysicsConstants[x].Read(reader);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _durationBounds.Write(bw);
        _transitionTimeBounds.Write(bw);
        _unnamed.Write(bw);
        _scaleMultiplier.Write(bw);
        _animationratemultiplier.Write(bw);
        _rotationRateMultiplier.Write(bw);
        _colorMultiplier.Write(bw);
        _radiusMultiplier.Write(bw);
        _minimumParticleCount.Write(bw);
        _particleCreationRate.Write(bw);
        _unnamed2.Write(bw);
        _particleCreationPhysics.Write(bw);
        _particleUpdatePhysics.Write(bw);
_physicsConstants.Count = PhysicsConstants.Count;
        _physicsConstants.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].Write(writer);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleSystemTypeParticleStatesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealBounds _durationBounds = new RealBounds();
      private RealBounds _transitionTimeBounds = new RealBounds();
      private TagReference _bitmaps = new TagReference();
      private ShortInteger _sequenceIndex = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private RealBounds _scale = new RealBounds();
      private RealBounds _animationRate = new RealBounds();
      private AngleBounds _rotationRate = new AngleBounds();
      private RealARGBColor _color1 = new RealARGBColor();
      private RealARGBColor _color2 = new RealARGBColor();
      private Real _radiusMultiplier = new Real();
      private TagReference _pointPhysics = new TagReference();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Flags _shaderFlags;
      private Enum _framebufferBlendFunction = new Enum();
      private Enum _framebufferFadeMode = new Enum();
      private Flags _mapFlags;
      private Pad _unnamed5;
      private TagReference _bitmap = new TagReference();
      private Enum _anchor = new Enum();
      private Flags _flags;
      private Enum _unnamed6 = new Enum();
      private Enum _unnamed7 = new Enum();
      private Real _unnamed8 = new Real();
      private Real _unnamed9 = new Real();
      private Real _unnamed10 = new Real();
      private Enum _unnamed11 = new Enum();
      private Enum _unnamed12 = new Enum();
      private Real _unnamed13 = new Real();
      private Real _unnamed14 = new Real();
      private Real _unnamed15 = new Real();
      private Enum _rotatio = new Enum();
      private Enum _rotatio2 = new Enum();
      private Real _rotatio3 = new Real();
      private Real _rotatio4 = new Real();
      private Real _rotatio5 = new Real();
      private RealPoint2D _rotatio6 = new RealPoint2D();
      private Pad _unnamed16;
      private Real _zspriteRadiusScale = new Real();
      private Pad _unnamed17;
      private Block _physicsConstants = new Block();
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> _physicsConstantsList = new BlockCollection<ParticleSystemPhysicsConstantsBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemTypeParticleStatesBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(36);
        this._unnamed4 = new Pad(40);
        this._shaderFlags = new Flags(2);
        this._mapFlags = new Flags(2);
        this._unnamed5 = new Pad(28);
        this._flags = new Flags(2);
        this._unnamed16 = new Pad(4);
        this._unnamed17 = new Pad(20);
      }
      public BlockCollection<ParticleSystemPhysicsConstantsBlock> PhysicsConstants {
        get {
          return this._physicsConstantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmaps.Value);
references.Add(_pointPhysics.Value);
references.Add(_bitmap.Value);
for (int x=0; x<PhysicsConstants.BlockCount; x++)
{
  IBlock block = PhysicsConstants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public RealBounds DurationBounds {
        get {
          return this._durationBounds;
        }
        set {
          this._durationBounds = value;
        }
      }
      public RealBounds TransitionTimeBounds {
        get {
          return this._transitionTimeBounds;
        }
        set {
          this._transitionTimeBounds = value;
        }
      }
      public TagReference Bitmaps {
        get {
          return this._bitmaps;
        }
        set {
          this._bitmaps = value;
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
      public RealBounds Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
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
      public RealARGBColor Color1 {
        get {
          return this._color1;
        }
        set {
          this._color1 = value;
        }
      }
      public RealARGBColor Color2 {
        get {
          return this._color2;
        }
        set {
          this._color2 = value;
        }
      }
      public Real RadiusMultiplier {
        get {
          return this._radiusMultiplier;
        }
        set {
          this._radiusMultiplier = value;
        }
      }
      public TagReference PointPhysics {
        get {
          return this._pointPhysics;
        }
        set {
          this._pointPhysics = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public Enum unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public Real unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public Real unnamed9 {
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
        _durationBounds.Read(reader);
        _transitionTimeBounds.Read(reader);
        _bitmaps.Read(reader);
        _sequenceIndex.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _scale.Read(reader);
        _animationRate.Read(reader);
        _rotationRate.Read(reader);
        _color1.Read(reader);
        _color2.Read(reader);
        _radiusMultiplier.Read(reader);
        _pointPhysics.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _shaderFlags.Read(reader);
        _framebufferBlendFunction.Read(reader);
        _framebufferFadeMode.Read(reader);
        _mapFlags.Read(reader);
        _unnamed5.Read(reader);
        _bitmap.Read(reader);
        _anchor.Read(reader);
        _flags.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _rotatio.Read(reader);
        _rotatio2.Read(reader);
        _rotatio3.Read(reader);
        _rotatio4.Read(reader);
        _rotatio5.Read(reader);
        _rotatio6.Read(reader);
        _unnamed16.Read(reader);
        _zspriteRadiusScale.Read(reader);
        _unnamed17.Read(reader);
        _physicsConstants.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bitmaps.ReadString(reader);
        _pointPhysics.ReadString(reader);
        _bitmap.ReadString(reader);
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants.Add(new ParticleSystemPhysicsConstantsBlock());
          PhysicsConstants[x].Read(reader);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _durationBounds.Write(bw);
        _transitionTimeBounds.Write(bw);
        _bitmaps.Write(bw);
        _sequenceIndex.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _scale.Write(bw);
        _animationRate.Write(bw);
        _rotationRate.Write(bw);
        _color1.Write(bw);
        _color2.Write(bw);
        _radiusMultiplier.Write(bw);
        _pointPhysics.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _shaderFlags.Write(bw);
        _framebufferBlendFunction.Write(bw);
        _framebufferFadeMode.Write(bw);
        _mapFlags.Write(bw);
        _unnamed5.Write(bw);
        _bitmap.Write(bw);
        _anchor.Write(bw);
        _flags.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _rotatio.Write(bw);
        _rotatio2.Write(bw);
        _rotatio3.Write(bw);
        _rotatio4.Write(bw);
        _rotatio5.Write(bw);
        _rotatio6.Write(bw);
        _unnamed16.Write(bw);
        _zspriteRadiusScale.Write(bw);
        _unnamed17.Write(bw);
_physicsConstants.Count = PhysicsConstants.Count;
        _physicsConstants.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bitmaps.WriteString(writer);
        _pointPhysics.WriteString(writer);
        _bitmap.WriteString(writer);
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].Write(writer);
        }
        for (x = 0; (x < _physicsConstants.Count); x = (x + 1)) {
          PhysicsConstants[x].WriteChildData(writer);
        }
      }
    }
  }
}
