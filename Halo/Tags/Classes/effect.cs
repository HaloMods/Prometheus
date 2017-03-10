// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'effect'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class effect : Interfaces.Pool.Tag {
    private EffectBlock effectValues = new EffectBlock();
    public virtual EffectBlock EffectValues {
      get {
        return effectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(EffectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "effect";
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
effectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
effectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
effectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
effectValues.WriteChildData(writer);
    }
    #endregion
    public class EffectBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _loopStartEvent = new ShortBlockIndex();
      private ShortBlockIndex _loopStopEvent = new ShortBlockIndex();
      private Pad _unnamed;
      private Block _locations = new Block();
      private Block _events = new Block();
      public BlockCollection<EffectLocationsBlock> _locationsList = new BlockCollection<EffectLocationsBlock>();
      public BlockCollection<EffectEventBlock> _eventsList = new BlockCollection<EffectEventBlock>();
public event System.EventHandler BlockNameChanged;
      public EffectBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(32);
      }
      public BlockCollection<EffectLocationsBlock> Locations {
        get {
          return this._locationsList;
        }
      }
      public BlockCollection<EffectEventBlock> Events {
        get {
          return this._eventsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Locations.BlockCount; x++)
{
  IBlock block = Locations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Events.BlockCount; x++)
{
  IBlock block = Events.GetBlock(x);
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
      public ShortBlockIndex LoopStartEvent {
        get {
          return this._loopStartEvent;
        }
        set {
          this._loopStartEvent = value;
        }
      }
      public ShortBlockIndex LoopStopEvent {
        get {
          return this._loopStopEvent;
        }
        set {
          this._loopStopEvent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _loopStartEvent.Read(reader);
        _loopStopEvent.Read(reader);
        _unnamed.Read(reader);
        _locations.Read(reader);
        _events.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations.Add(new EffectLocationsBlock());
          Locations[x].Read(reader);
        }
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events.Add(new EffectEventBlock());
          Events[x].Read(reader);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _loopStartEvent.Write(bw);
        _loopStopEvent.Write(bw);
        _unnamed.Write(bw);
_locations.Count = Locations.Count;
        _locations.Write(bw);
_events.Count = Events.Count;
        _events.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations[x].Write(writer);
        }
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events[x].Write(writer);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events[x].WriteChildData(writer);
        }
      }
    }
    public class EffectLocationsBlock : IBlock {
      private FixedLengthString _markerName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public EffectLocationsBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _markerName.ToString();
        }
      }
      public FixedLengthString MarkerName {
        get {
          return this._markerName;
        }
        set {
          this._markerName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _markerName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EffectEventBlock : IBlock {
      private Pad _unnamed;
      private RealFraction _skipFraction = new RealFraction();
      private RealBounds _delayBounds = new RealBounds();
      private RealBounds _durationBounds = new RealBounds();
      private Pad _unnamed2;
      private Block _parts = new Block();
      private Block _particles = new Block();
      public BlockCollection<EffectPartBlock> _partsList = new BlockCollection<EffectPartBlock>();
      public BlockCollection<EffectParticlesBlock> _particlesList = new BlockCollection<EffectParticlesBlock>();
public event System.EventHandler BlockNameChanged;
      public EffectEventBlock() {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(20);
      }
      public BlockCollection<EffectPartBlock> Parts {
        get {
          return this._partsList;
        }
      }
      public BlockCollection<EffectParticlesBlock> Particles {
        get {
          return this._particlesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Parts.BlockCount; x++)
{
  IBlock block = Parts.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Particles.BlockCount; x++)
{
  IBlock block = Particles.GetBlock(x);
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
      public RealFraction SkipFraction {
        get {
          return this._skipFraction;
        }
        set {
          this._skipFraction = value;
        }
      }
      public RealBounds DelayBounds {
        get {
          return this._delayBounds;
        }
        set {
          this._delayBounds = value;
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
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _skipFraction.Read(reader);
        _delayBounds.Read(reader);
        _durationBounds.Read(reader);
        _unnamed2.Read(reader);
        _parts.Read(reader);
        _particles.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts.Add(new EffectPartBlock());
          Parts[x].Read(reader);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particles.Count); x = (x + 1)) {
          Particles.Add(new EffectParticlesBlock());
          Particles[x].Read(reader);
        }
        for (x = 0; (x < _particles.Count); x = (x + 1)) {
          Particles[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _skipFraction.Write(bw);
        _delayBounds.Write(bw);
        _durationBounds.Write(bw);
        _unnamed2.Write(bw);
_parts.Count = Parts.Count;
        _parts.Write(bw);
_particles.Count = Particles.Count;
        _particles.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].Write(writer);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particles.Count); x = (x + 1)) {
          Particles[x].Write(writer);
        }
        for (x = 0; (x < _particles.Count); x = (x + 1)) {
          Particles[x].WriteChildData(writer);
        }
      }
    }
    public class EffectPartBlock : IBlock {
      private Enum _createIn = new Enum();
      private Enum _createIn2 = new Enum();
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Flags _flags;
      private Pad _unnamed;
      private TagReference _type = new TagReference();
      private Pad _unnamed2;
      private RealBounds _velocityBounds = new RealBounds();
      private Angle _velocityConeAngle = new Angle();
      private AngleBounds _angularVelocityBounds = new AngleBounds();
      private RealBounds _radiusModifierBounds = new RealBounds();
      private Pad _unnamed3;
      private Flags _aScalesValues;
      private Flags _bScalesValues;
public event System.EventHandler BlockNameChanged;
      public EffectPartBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(24);
        this._unnamed3 = new Pad(4);
        this._aScalesValues = new Flags(4);
        this._bScalesValues = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_type.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
        }
      }
      public Enum CreateIn {
        get {
          return this._createIn;
        }
        set {
          this._createIn = value;
        }
      }
      public Enum CreateIn2 {
        get {
          return this._createIn2;
        }
        set {
          this._createIn2 = value;
        }
      }
      public ShortBlockIndex Location {
        get {
          return this._location;
        }
        set {
          this._location = value;
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
      public TagReference Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public RealBounds VelocityBounds {
        get {
          return this._velocityBounds;
        }
        set {
          this._velocityBounds = value;
        }
      }
      public Angle VelocityConeAngle {
        get {
          return this._velocityConeAngle;
        }
        set {
          this._velocityConeAngle = value;
        }
      }
      public AngleBounds AngularVelocityBounds {
        get {
          return this._angularVelocityBounds;
        }
        set {
          this._angularVelocityBounds = value;
        }
      }
      public RealBounds RadiusModifierBounds {
        get {
          return this._radiusModifierBounds;
        }
        set {
          this._radiusModifierBounds = value;
        }
      }
      public Flags AScalesValues {
        get {
          return this._aScalesValues;
        }
        set {
          this._aScalesValues = value;
        }
      }
      public Flags BScalesValues {
        get {
          return this._bScalesValues;
        }
        set {
          this._bScalesValues = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _createIn.Read(reader);
        _createIn2.Read(reader);
        _location.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _type.Read(reader);
        _unnamed2.Read(reader);
        _velocityBounds.Read(reader);
        _velocityConeAngle.Read(reader);
        _angularVelocityBounds.Read(reader);
        _radiusModifierBounds.Read(reader);
        _unnamed3.Read(reader);
        _aScalesValues.Read(reader);
        _bScalesValues.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _type.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _createIn.Write(bw);
        _createIn2.Write(bw);
        _location.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _type.Write(bw);
        _unnamed2.Write(bw);
        _velocityBounds.Write(bw);
        _velocityConeAngle.Write(bw);
        _angularVelocityBounds.Write(bw);
        _radiusModifierBounds.Write(bw);
        _unnamed3.Write(bw);
        _aScalesValues.Write(bw);
        _bScalesValues.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _type.WriteString(writer);
      }
    }
    public class EffectParticlesBlock : IBlock {
      private Enum _createIn = new Enum();
      private Enum _createIn2 = new Enum();
      private Enum _create = new Enum();
      private Pad _unnamed;
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Pad _unnamed2;
      private RealEulerAngles2D _relativeDirection = new RealEulerAngles2D();
      private RealVector3D _relativeOffset = new RealVector3D();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private TagReference _particleType = new TagReference();
      private Flags _flags;
      private Enum _distributionFunction = new Enum();
      private Pad _unnamed5;
      private ShortBounds _count = new ShortBounds();
      private RealBounds _distributionRadius = new RealBounds();
      private Pad _unnamed6;
      private RealBounds _velocity = new RealBounds();
      private Angle _velocityConeAngle = new Angle();
      private AngleBounds _angularVelocity = new AngleBounds();
      private Pad _unnamed7;
      private RealBounds _radius = new RealBounds();
      private Pad _unnamed8;
      private RealARGBColor _tintLowerBound = new RealARGBColor();
      private RealARGBColor _tintUpperBound = new RealARGBColor();
      private Pad _unnamed9;
      private Flags _aScalesValues;
      private Flags _bScalesValues;
public event System.EventHandler BlockNameChanged;
      public EffectParticlesBlock() {
if (this._particleType is System.ComponentModel.INotifyPropertyChanged)
  (this._particleType as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(40);
        this._flags = new Flags(4);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(12);
        this._unnamed7 = new Pad(8);
        this._unnamed8 = new Pad(8);
        this._unnamed9 = new Pad(16);
        this._aScalesValues = new Flags(4);
        this._bScalesValues = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_particleType.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _particleType.ToString();
        }
      }
      public Enum CreateIn {
        get {
          return this._createIn;
        }
        set {
          this._createIn = value;
        }
      }
      public Enum CreateIn2 {
        get {
          return this._createIn2;
        }
        set {
          this._createIn2 = value;
        }
      }
      public Enum Create {
        get {
          return this._create;
        }
        set {
          this._create = value;
        }
      }
      public ShortBlockIndex Location {
        get {
          return this._location;
        }
        set {
          this._location = value;
        }
      }
      public RealEulerAngles2D RelativeDirection {
        get {
          return this._relativeDirection;
        }
        set {
          this._relativeDirection = value;
        }
      }
      public RealVector3D RelativeOffset {
        get {
          return this._relativeOffset;
        }
        set {
          this._relativeOffset = value;
        }
      }
      public TagReference ParticleType {
        get {
          return this._particleType;
        }
        set {
          this._particleType = value;
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
      public Enum DistributionFunction {
        get {
          return this._distributionFunction;
        }
        set {
          this._distributionFunction = value;
        }
      }
      public ShortBounds Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public RealBounds DistributionRadius {
        get {
          return this._distributionRadius;
        }
        set {
          this._distributionRadius = value;
        }
      }
      public RealBounds Velocity {
        get {
          return this._velocity;
        }
        set {
          this._velocity = value;
        }
      }
      public Angle VelocityConeAngle {
        get {
          return this._velocityConeAngle;
        }
        set {
          this._velocityConeAngle = value;
        }
      }
      public AngleBounds AngularVelocity {
        get {
          return this._angularVelocity;
        }
        set {
          this._angularVelocity = value;
        }
      }
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealARGBColor TintLowerBound {
        get {
          return this._tintLowerBound;
        }
        set {
          this._tintLowerBound = value;
        }
      }
      public RealARGBColor TintUpperBound {
        get {
          return this._tintUpperBound;
        }
        set {
          this._tintUpperBound = value;
        }
      }
      public Flags AScalesValues {
        get {
          return this._aScalesValues;
        }
        set {
          this._aScalesValues = value;
        }
      }
      public Flags BScalesValues {
        get {
          return this._bScalesValues;
        }
        set {
          this._bScalesValues = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _createIn.Read(reader);
        _createIn2.Read(reader);
        _create.Read(reader);
        _unnamed.Read(reader);
        _location.Read(reader);
        _unnamed2.Read(reader);
        _relativeDirection.Read(reader);
        _relativeOffset.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _particleType.Read(reader);
        _flags.Read(reader);
        _distributionFunction.Read(reader);
        _unnamed5.Read(reader);
        _count.Read(reader);
        _distributionRadius.Read(reader);
        _unnamed6.Read(reader);
        _velocity.Read(reader);
        _velocityConeAngle.Read(reader);
        _angularVelocity.Read(reader);
        _unnamed7.Read(reader);
        _radius.Read(reader);
        _unnamed8.Read(reader);
        _tintLowerBound.Read(reader);
        _tintUpperBound.Read(reader);
        _unnamed9.Read(reader);
        _aScalesValues.Read(reader);
        _bScalesValues.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _particleType.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _createIn.Write(bw);
        _createIn2.Write(bw);
        _create.Write(bw);
        _unnamed.Write(bw);
        _location.Write(bw);
        _unnamed2.Write(bw);
        _relativeDirection.Write(bw);
        _relativeOffset.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _particleType.Write(bw);
        _flags.Write(bw);
        _distributionFunction.Write(bw);
        _unnamed5.Write(bw);
        _count.Write(bw);
        _distributionRadius.Write(bw);
        _unnamed6.Write(bw);
        _velocity.Write(bw);
        _velocityConeAngle.Write(bw);
        _angularVelocity.Write(bw);
        _unnamed7.Write(bw);
        _radius.Write(bw);
        _unnamed8.Write(bw);
        _tintLowerBound.Write(bw);
        _tintUpperBound.Write(bw);
        _unnamed9.Write(bw);
        _aScalesValues.Write(bw);
        _bScalesValues.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _particleType.WriteString(writer);
      }
    }
  }
}
