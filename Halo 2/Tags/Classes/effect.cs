// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'effect'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class effect : Interfaces.Pool.Tag {
    private EffectBlockBlock effectValues = new EffectBlockBlock();
    public virtual EffectBlockBlock EffectValues {
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
    public class EffectBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _loopStartEvent = new ShortBlockIndex();
      private Skip _unnamed0;
      private Pad _unnamed1;
      private Block _locations = new Block();
      private Block _events = new Block();
      private TagReference _loopingSound = new TagReference();
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Skip _unnamed2;
      private Real _alwaysPlayDistance = new Real();
      private Real _neverPlayDistance = new Real();
      public BlockCollection<EffectLocationsBlockBlock> _locationsList = new BlockCollection<EffectLocationsBlockBlock>();
      public BlockCollection<EffectEventBlockBlock> _eventsList = new BlockCollection<EffectEventBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public EffectBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Skip(2);
      }
      public BlockCollection<EffectLocationsBlockBlock> Locations {
        get {
          return this._locationsList;
        }
      }
      public BlockCollection<EffectEventBlockBlock> Events {
        get {
          return this._eventsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_loopingSound.Value);
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
      public TagReference LoopingSound {
        get {
          return this._loopingSound;
        }
        set {
          this._loopingSound = value;
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
      public Real AlwaysPlayDistance {
        get {
          return this._alwaysPlayDistance;
        }
        set {
          this._alwaysPlayDistance = value;
        }
      }
      public Real NeverPlayDistance {
        get {
          return this._neverPlayDistance;
        }
        set {
          this._neverPlayDistance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _loopStartEvent.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _locations.Read(reader);
        _events.Read(reader);
        _loopingSound.Read(reader);
        _location.Read(reader);
        _unnamed2.Read(reader);
        _alwaysPlayDistance.Read(reader);
        _neverPlayDistance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations.Add(new EffectLocationsBlockBlock());
          Locations[x].Read(reader);
        }
        for (x = 0; (x < _locations.Count); x = (x + 1)) {
          Locations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events.Add(new EffectEventBlockBlock());
          Events[x].Read(reader);
        }
        for (x = 0; (x < _events.Count); x = (x + 1)) {
          Events[x].ReadChildData(reader);
        }
        _loopingSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _loopStartEvent.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_locations.Count = Locations.Count;
        _locations.Write(bw);
_events.Count = Events.Count;
        _events.Write(bw);
        _loopingSound.Write(bw);
        _location.Write(bw);
        _unnamed2.Write(bw);
        _alwaysPlayDistance.Write(bw);
        _neverPlayDistance.Write(bw);
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
        _loopingSound.WriteString(writer);
      }
    }
    public class EffectLocationsBlockBlock : IBlock {
      private StringId _markerName = new StringId();
public event System.EventHandler BlockNameChanged;
      public EffectLocationsBlockBlock() {
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
      public StringId MarkerName {
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
        _markerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
      }
    }
    public class EffectEventBlockBlock : IBlock {
      private Flags _flags;
      private RealFraction _skipFraction = new RealFraction();
      private RealBounds _delayBounds = new RealBounds();
      private RealBounds _durationBounds = new RealBounds();
      private Block _parts = new Block();
      private Block _beams = new Block();
      private Block _accelerations = new Block();
      private Block _particleSystems = new Block();
      public BlockCollection<EffectPartBlockBlock> _partsList = new BlockCollection<EffectPartBlockBlock>();
      public BlockCollection<BeamBlockBlock> _beamsList = new BlockCollection<BeamBlockBlock>();
      public BlockCollection<EffectAccelerationsBlockBlock> _accelerationsList = new BlockCollection<EffectAccelerationsBlockBlock>();
      public BlockCollection<ParticleSystemDefinitionBlockNewBlock> _particleSystemsList = new BlockCollection<ParticleSystemDefinitionBlockNewBlock>();
public event System.EventHandler BlockNameChanged;
      public EffectEventBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<EffectPartBlockBlock> Parts {
        get {
          return this._partsList;
        }
      }
      public BlockCollection<BeamBlockBlock> Beams {
        get {
          return this._beamsList;
        }
      }
      public BlockCollection<EffectAccelerationsBlockBlock> Accelerations {
        get {
          return this._accelerationsList;
        }
      }
      public BlockCollection<ParticleSystemDefinitionBlockNewBlock> ParticleSystems {
        get {
          return this._particleSystemsList;
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
for (int x=0; x<Beams.BlockCount; x++)
{
  IBlock block = Beams.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Accelerations.BlockCount; x++)
{
  IBlock block = Accelerations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParticleSystems.BlockCount; x++)
{
  IBlock block = ParticleSystems.GetBlock(x);
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
        _flags.Read(reader);
        _skipFraction.Read(reader);
        _delayBounds.Read(reader);
        _durationBounds.Read(reader);
        _parts.Read(reader);
        _beams.Read(reader);
        _accelerations.Read(reader);
        _particleSystems.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts.Add(new EffectPartBlockBlock());
          Parts[x].Read(reader);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _beams.Count); x = (x + 1)) {
          Beams.Add(new BeamBlockBlock());
          Beams[x].Read(reader);
        }
        for (x = 0; (x < _beams.Count); x = (x + 1)) {
          Beams[x].ReadChildData(reader);
        }
        for (x = 0; (x < _accelerations.Count); x = (x + 1)) {
          Accelerations.Add(new EffectAccelerationsBlockBlock());
          Accelerations[x].Read(reader);
        }
        for (x = 0; (x < _accelerations.Count); x = (x + 1)) {
          Accelerations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _particleSystems.Count); x = (x + 1)) {
          ParticleSystems.Add(new ParticleSystemDefinitionBlockNewBlock());
          ParticleSystems[x].Read(reader);
        }
        for (x = 0; (x < _particleSystems.Count); x = (x + 1)) {
          ParticleSystems[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _skipFraction.Write(bw);
        _delayBounds.Write(bw);
        _durationBounds.Write(bw);
_parts.Count = Parts.Count;
        _parts.Write(bw);
_beams.Count = Beams.Count;
        _beams.Write(bw);
_accelerations.Count = Accelerations.Count;
        _accelerations.Write(bw);
_particleSystems.Count = ParticleSystems.Count;
        _particleSystems.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].Write(writer);
        }
        for (x = 0; (x < _parts.Count); x = (x + 1)) {
          Parts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _beams.Count); x = (x + 1)) {
          Beams[x].Write(writer);
        }
        for (x = 0; (x < _beams.Count); x = (x + 1)) {
          Beams[x].WriteChildData(writer);
        }
        for (x = 0; (x < _accelerations.Count); x = (x + 1)) {
          Accelerations[x].Write(writer);
        }
        for (x = 0; (x < _accelerations.Count); x = (x + 1)) {
          Accelerations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _particleSystems.Count); x = (x + 1)) {
          ParticleSystems[x].Write(writer);
        }
        for (x = 0; (x < _particleSystems.Count); x = (x + 1)) {
          ParticleSystems[x].WriteChildData(writer);
        }
      }
    }
    public class EffectPartBlockBlock : IBlock {
      private Enum _createIn;
      private Enum _createIn2;
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Flags _flags;
      private Pad _unnamed0;
      private TagReference _type = new TagReference();
      private RealBounds _velocityBounds = new RealBounds();
      private Angle _velocityConeAngle = new Angle();
      private AngleBounds _angularVelocityBounds = new AngleBounds();
      private RealBounds _radiusModifierBounds = new RealBounds();
      private Flags _aScalesValues;
      private Flags _bScalesValues;
public event System.EventHandler BlockNameChanged;
      public EffectPartBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._createIn = new Enum(2);
        this._createIn2 = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(4);
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
        _unnamed0.Read(reader);
        _type.Read(reader);
        _velocityBounds.Read(reader);
        _velocityConeAngle.Read(reader);
        _angularVelocityBounds.Read(reader);
        _radiusModifierBounds.Read(reader);
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
        _unnamed0.Write(bw);
        _type.Write(bw);
        _velocityBounds.Write(bw);
        _velocityConeAngle.Write(bw);
        _angularVelocityBounds.Write(bw);
        _radiusModifierBounds.Write(bw);
        _aScalesValues.Write(bw);
        _bScalesValues.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _type.WriteString(writer);
      }
    }
    public class BeamBlockBlock : IBlock {
      private TagReference _shader = new TagReference();
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Pad _unnamed0;
      private Block _data = new Block();
      private Block _data2 = new Block();
      private Block _data3 = new Block();
      private Block _data4 = new Block();
      private Block _data5 = new Block();
      private Block _data6 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data6List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public BeamBlockBlock() {
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data3 {
        get {
          return this._data3List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data4 {
        get {
          return this._data4List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data5 {
        get {
          return this._data5List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data6 {
        get {
          return this._data6List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data3.BlockCount; x++)
{
  IBlock block = Data3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data4.BlockCount; x++)
{
  IBlock block = Data4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data5.BlockCount; x++)
{
  IBlock block = Data5.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data6.BlockCount; x++)
{
  IBlock block = Data6.GetBlock(x);
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
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
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
      public virtual void Read(BinaryReader reader) {
        _shader.Read(reader);
        _location.Read(reader);
        _unnamed0.Read(reader);
        _data.Read(reader);
        _data2.Read(reader);
        _data3.Read(reader);
        _data4.Read(reader);
        _data5.Read(reader);
        _data6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _shader.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4.Add(new ByteBlockBlock());
          Data4[x].Read(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5.Add(new ByteBlockBlock());
          Data5[x].Read(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6.Add(new ByteBlockBlock());
          Data6[x].Read(reader);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _shader.Write(bw);
        _location.Write(bw);
        _unnamed0.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
_data5.Count = Data5.Count;
        _data5.Write(bw);
_data6.Count = Data6.Count;
        _data6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _shader.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].Write(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].Write(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].Write(writer);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].WriteChildData(writer);
        }
      }
    }
    public class ByteBlockBlock : IBlock {
      private CharInteger _value = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockBlock() {
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
      public CharInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EffectAccelerationsBlockBlock : IBlock {
      private Enum _createIn;
      private Enum _createIn2;
      private ShortBlockIndex _location = new ShortBlockIndex();
      private Pad _unnamed0;
      private Real _acceleration = new Real();
      private Real _innerConeAngle = new Real();
      private Real _outerConeAngle = new Real();
public event System.EventHandler BlockNameChanged;
      public EffectAccelerationsBlockBlock() {
        this._createIn = new Enum(2);
        this._createIn2 = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Real Acceleration {
        get {
          return this._acceleration;
        }
        set {
          this._acceleration = value;
        }
      }
      public Real InnerConeAngle {
        get {
          return this._innerConeAngle;
        }
        set {
          this._innerConeAngle = value;
        }
      }
      public Real OuterConeAngle {
        get {
          return this._outerConeAngle;
        }
        set {
          this._outerConeAngle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _createIn.Read(reader);
        _createIn2.Read(reader);
        _location.Read(reader);
        _unnamed0.Read(reader);
        _acceleration.Read(reader);
        _innerConeAngle.Read(reader);
        _outerConeAngle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _createIn.Write(bw);
        _createIn2.Write(bw);
        _location.Write(bw);
        _unnamed0.Write(bw);
        _acceleration.Write(bw);
        _innerConeAngle.Write(bw);
        _outerConeAngle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ParticleSystemDefinitionBlockNewBlock : IBlock {
      private TagReference _particle = new TagReference();
      private LongBlockIndex _location = new LongBlockIndex();
      private Enum _coordinateSystem;
      private Enum _environment;
      private Enum _disposition;
      private Enum _cameraMode;
      private ShortInteger _sortBias = new ShortInteger();
      private Flags _flags;
      private Real _lODInDistance = new Real();
      private Real _lODFeatherInDelta = new Real();
      private Skip _unnamed0;
      private Real _lODOutDistance = new Real();
      private Real _lODFeatherOutDelta = new Real();
      private Skip _unnamed1;
      private Block _emitters = new Block();
      public BlockCollection<ParticleSystemEmitterDefinitionBlockBlock> _emittersList = new BlockCollection<ParticleSystemEmitterDefinitionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemDefinitionBlockNewBlock() {
        this._coordinateSystem = new Enum(2);
        this._environment = new Enum(2);
        this._disposition = new Enum(2);
        this._cameraMode = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
      }
      public BlockCollection<ParticleSystemEmitterDefinitionBlockBlock> Emitters {
        get {
          return this._emittersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_particle.Value);
for (int x=0; x<Emitters.BlockCount; x++)
{
  IBlock block = Emitters.GetBlock(x);
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
      public TagReference Particle {
        get {
          return this._particle;
        }
        set {
          this._particle = value;
        }
      }
      public LongBlockIndex Location {
        get {
          return this._location;
        }
        set {
          this._location = value;
        }
      }
      public Enum CoordinateSystem {
        get {
          return this._coordinateSystem;
        }
        set {
          this._coordinateSystem = value;
        }
      }
      public Enum Environment {
        get {
          return this._environment;
        }
        set {
          this._environment = value;
        }
      }
      public Enum Disposition {
        get {
          return this._disposition;
        }
        set {
          this._disposition = value;
        }
      }
      public Enum CameraMode {
        get {
          return this._cameraMode;
        }
        set {
          this._cameraMode = value;
        }
      }
      public ShortInteger SortBias {
        get {
          return this._sortBias;
        }
        set {
          this._sortBias = value;
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
      public Real LODInDistance {
        get {
          return this._lODInDistance;
        }
        set {
          this._lODInDistance = value;
        }
      }
      public Real LODFeatherInDelta {
        get {
          return this._lODFeatherInDelta;
        }
        set {
          this._lODFeatherInDelta = value;
        }
      }
      public Real LODOutDistance {
        get {
          return this._lODOutDistance;
        }
        set {
          this._lODOutDistance = value;
        }
      }
      public Real LODFeatherOutDelta {
        get {
          return this._lODFeatherOutDelta;
        }
        set {
          this._lODFeatherOutDelta = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _particle.Read(reader);
        _location.Read(reader);
        _coordinateSystem.Read(reader);
        _environment.Read(reader);
        _disposition.Read(reader);
        _cameraMode.Read(reader);
        _sortBias.Read(reader);
        _flags.Read(reader);
        _lODInDistance.Read(reader);
        _lODFeatherInDelta.Read(reader);
        _unnamed0.Read(reader);
        _lODOutDistance.Read(reader);
        _lODFeatherOutDelta.Read(reader);
        _unnamed1.Read(reader);
        _emitters.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _particle.ReadString(reader);
        for (x = 0; (x < _emitters.Count); x = (x + 1)) {
          Emitters.Add(new ParticleSystemEmitterDefinitionBlockBlock());
          Emitters[x].Read(reader);
        }
        for (x = 0; (x < _emitters.Count); x = (x + 1)) {
          Emitters[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _particle.Write(bw);
        _location.Write(bw);
        _coordinateSystem.Write(bw);
        _environment.Write(bw);
        _disposition.Write(bw);
        _cameraMode.Write(bw);
        _sortBias.Write(bw);
        _flags.Write(bw);
        _lODInDistance.Write(bw);
        _lODFeatherInDelta.Write(bw);
        _unnamed0.Write(bw);
        _lODOutDistance.Write(bw);
        _lODFeatherOutDelta.Write(bw);
        _unnamed1.Write(bw);
_emitters.Count = Emitters.Count;
        _emitters.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _particle.WriteString(writer);
        for (x = 0; (x < _emitters.Count); x = (x + 1)) {
          Emitters[x].Write(writer);
        }
        for (x = 0; (x < _emitters.Count); x = (x + 1)) {
          Emitters[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleSystemEmitterDefinitionBlockBlock : IBlock {
      private TagReference _particlePhysics = new TagReference();
      private Enum _inputVariable;
      private Enum _rangeVariable;
      private Enum _outputModifier;
      private Enum _outputModifierInput;
      private Block _data = new Block();
      private Enum _inputVariable2;
      private Enum _rangeVariable2;
      private Enum _outputModifier2;
      private Enum _outputModifierInput2;
      private Block _data2 = new Block();
      private Enum _inputVariable3;
      private Enum _rangeVariable3;
      private Enum _outputModifier3;
      private Enum _outputModifierInput3;
      private Block _data3 = new Block();
      private Enum _inputVariable4;
      private Enum _rangeVariable4;
      private Enum _outputModifier4;
      private Enum _outputModifierInput4;
      private Block _data4 = new Block();
      private Enum _inputVariable5;
      private Enum _rangeVariable5;
      private Enum _outputModifier5;
      private Enum _outputModifierInput5;
      private Block _data5 = new Block();
      private Enum _inputVariable6;
      private Enum _rangeVariable6;
      private Enum _outputModifier6;
      private Enum _outputModifierInput6;
      private Block _data6 = new Block();
      private Enum _inputVariable7;
      private Enum _rangeVariable7;
      private Enum _outputModifier7;
      private Enum _outputModifierInput7;
      private Block _data7 = new Block();
      private Enum _emissionShape;
      private Enum _inputVariable8;
      private Enum _rangeVariable8;
      private Enum _outputModifier8;
      private Enum _outputModifierInput8;
      private Block _data8 = new Block();
      private Enum _inputVariable9;
      private Enum _rangeVariable9;
      private Enum _outputModifier9;
      private Enum _outputModifierInput9;
      private Block _data9 = new Block();
      private RealPoint3D _translationalOffset = new RealPoint3D();
      private RealEulerAngles2D _relativeDirection = new RealEulerAngles2D();
      private Pad _unnamed0;
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data4List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data5List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data6List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data7List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data8List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data9List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleSystemEmitterDefinitionBlockBlock() {
        this._inputVariable = new Enum(2);
        this._rangeVariable = new Enum(2);
        this._outputModifier = new Enum(2);
        this._outputModifierInput = new Enum(2);
        this._inputVariable2 = new Enum(2);
        this._rangeVariable2 = new Enum(2);
        this._outputModifier2 = new Enum(2);
        this._outputModifierInput2 = new Enum(2);
        this._inputVariable3 = new Enum(2);
        this._rangeVariable3 = new Enum(2);
        this._outputModifier3 = new Enum(2);
        this._outputModifierInput3 = new Enum(2);
        this._inputVariable4 = new Enum(2);
        this._rangeVariable4 = new Enum(2);
        this._outputModifier4 = new Enum(2);
        this._outputModifierInput4 = new Enum(2);
        this._inputVariable5 = new Enum(2);
        this._rangeVariable5 = new Enum(2);
        this._outputModifier5 = new Enum(2);
        this._outputModifierInput5 = new Enum(2);
        this._inputVariable6 = new Enum(2);
        this._rangeVariable6 = new Enum(2);
        this._outputModifier6 = new Enum(2);
        this._outputModifierInput6 = new Enum(2);
        this._inputVariable7 = new Enum(2);
        this._rangeVariable7 = new Enum(2);
        this._outputModifier7 = new Enum(2);
        this._outputModifierInput7 = new Enum(2);
        this._emissionShape = new Enum(4);
        this._inputVariable8 = new Enum(2);
        this._rangeVariable8 = new Enum(2);
        this._outputModifier8 = new Enum(2);
        this._outputModifierInput8 = new Enum(2);
        this._inputVariable9 = new Enum(2);
        this._rangeVariable9 = new Enum(2);
        this._outputModifier9 = new Enum(2);
        this._outputModifierInput9 = new Enum(2);
        this._unnamed0 = new Pad(8);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public BlockCollection<ByteBlockBlock> Data2 {
        get {
          return this._data2List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data3 {
        get {
          return this._data3List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data4 {
        get {
          return this._data4List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data5 {
        get {
          return this._data5List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data6 {
        get {
          return this._data6List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data7 {
        get {
          return this._data7List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data8 {
        get {
          return this._data8List;
        }
      }
      public BlockCollection<ByteBlockBlock> Data9 {
        get {
          return this._data9List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_particlePhysics.Value);
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data2.BlockCount; x++)
{
  IBlock block = Data2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data3.BlockCount; x++)
{
  IBlock block = Data3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data4.BlockCount; x++)
{
  IBlock block = Data4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data5.BlockCount; x++)
{
  IBlock block = Data5.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data6.BlockCount; x++)
{
  IBlock block = Data6.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data7.BlockCount; x++)
{
  IBlock block = Data7.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data8.BlockCount; x++)
{
  IBlock block = Data8.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Data9.BlockCount; x++)
{
  IBlock block = Data9.GetBlock(x);
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
      public TagReference ParticlePhysics {
        get {
          return this._particlePhysics;
        }
        set {
          this._particlePhysics = value;
        }
      }
      public Enum InputVariable {
        get {
          return this._inputVariable;
        }
        set {
          this._inputVariable = value;
        }
      }
      public Enum RangeVariable {
        get {
          return this._rangeVariable;
        }
        set {
          this._rangeVariable = value;
        }
      }
      public Enum OutputModifier {
        get {
          return this._outputModifier;
        }
        set {
          this._outputModifier = value;
        }
      }
      public Enum OutputModifierInput {
        get {
          return this._outputModifierInput;
        }
        set {
          this._outputModifierInput = value;
        }
      }
      public Enum InputVariable2 {
        get {
          return this._inputVariable2;
        }
        set {
          this._inputVariable2 = value;
        }
      }
      public Enum RangeVariable2 {
        get {
          return this._rangeVariable2;
        }
        set {
          this._rangeVariable2 = value;
        }
      }
      public Enum OutputModifier2 {
        get {
          return this._outputModifier2;
        }
        set {
          this._outputModifier2 = value;
        }
      }
      public Enum OutputModifierInput2 {
        get {
          return this._outputModifierInput2;
        }
        set {
          this._outputModifierInput2 = value;
        }
      }
      public Enum InputVariable3 {
        get {
          return this._inputVariable3;
        }
        set {
          this._inputVariable3 = value;
        }
      }
      public Enum RangeVariable3 {
        get {
          return this._rangeVariable3;
        }
        set {
          this._rangeVariable3 = value;
        }
      }
      public Enum OutputModifier3 {
        get {
          return this._outputModifier3;
        }
        set {
          this._outputModifier3 = value;
        }
      }
      public Enum OutputModifierInput3 {
        get {
          return this._outputModifierInput3;
        }
        set {
          this._outputModifierInput3 = value;
        }
      }
      public Enum InputVariable4 {
        get {
          return this._inputVariable4;
        }
        set {
          this._inputVariable4 = value;
        }
      }
      public Enum RangeVariable4 {
        get {
          return this._rangeVariable4;
        }
        set {
          this._rangeVariable4 = value;
        }
      }
      public Enum OutputModifier4 {
        get {
          return this._outputModifier4;
        }
        set {
          this._outputModifier4 = value;
        }
      }
      public Enum OutputModifierInput4 {
        get {
          return this._outputModifierInput4;
        }
        set {
          this._outputModifierInput4 = value;
        }
      }
      public Enum InputVariable5 {
        get {
          return this._inputVariable5;
        }
        set {
          this._inputVariable5 = value;
        }
      }
      public Enum RangeVariable5 {
        get {
          return this._rangeVariable5;
        }
        set {
          this._rangeVariable5 = value;
        }
      }
      public Enum OutputModifier5 {
        get {
          return this._outputModifier5;
        }
        set {
          this._outputModifier5 = value;
        }
      }
      public Enum OutputModifierInput5 {
        get {
          return this._outputModifierInput5;
        }
        set {
          this._outputModifierInput5 = value;
        }
      }
      public Enum InputVariable6 {
        get {
          return this._inputVariable6;
        }
        set {
          this._inputVariable6 = value;
        }
      }
      public Enum RangeVariable6 {
        get {
          return this._rangeVariable6;
        }
        set {
          this._rangeVariable6 = value;
        }
      }
      public Enum OutputModifier6 {
        get {
          return this._outputModifier6;
        }
        set {
          this._outputModifier6 = value;
        }
      }
      public Enum OutputModifierInput6 {
        get {
          return this._outputModifierInput6;
        }
        set {
          this._outputModifierInput6 = value;
        }
      }
      public Enum InputVariable7 {
        get {
          return this._inputVariable7;
        }
        set {
          this._inputVariable7 = value;
        }
      }
      public Enum RangeVariable7 {
        get {
          return this._rangeVariable7;
        }
        set {
          this._rangeVariable7 = value;
        }
      }
      public Enum OutputModifier7 {
        get {
          return this._outputModifier7;
        }
        set {
          this._outputModifier7 = value;
        }
      }
      public Enum OutputModifierInput7 {
        get {
          return this._outputModifierInput7;
        }
        set {
          this._outputModifierInput7 = value;
        }
      }
      public Enum EmissionShape {
        get {
          return this._emissionShape;
        }
        set {
          this._emissionShape = value;
        }
      }
      public Enum InputVariable8 {
        get {
          return this._inputVariable8;
        }
        set {
          this._inputVariable8 = value;
        }
      }
      public Enum RangeVariable8 {
        get {
          return this._rangeVariable8;
        }
        set {
          this._rangeVariable8 = value;
        }
      }
      public Enum OutputModifier8 {
        get {
          return this._outputModifier8;
        }
        set {
          this._outputModifier8 = value;
        }
      }
      public Enum OutputModifierInput8 {
        get {
          return this._outputModifierInput8;
        }
        set {
          this._outputModifierInput8 = value;
        }
      }
      public Enum InputVariable9 {
        get {
          return this._inputVariable9;
        }
        set {
          this._inputVariable9 = value;
        }
      }
      public Enum RangeVariable9 {
        get {
          return this._rangeVariable9;
        }
        set {
          this._rangeVariable9 = value;
        }
      }
      public Enum OutputModifier9 {
        get {
          return this._outputModifier9;
        }
        set {
          this._outputModifier9 = value;
        }
      }
      public Enum OutputModifierInput9 {
        get {
          return this._outputModifierInput9;
        }
        set {
          this._outputModifierInput9 = value;
        }
      }
      public RealPoint3D TranslationalOffset {
        get {
          return this._translationalOffset;
        }
        set {
          this._translationalOffset = value;
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
      public virtual void Read(BinaryReader reader) {
        _particlePhysics.Read(reader);
        _inputVariable.Read(reader);
        _rangeVariable.Read(reader);
        _outputModifier.Read(reader);
        _outputModifierInput.Read(reader);
        _data.Read(reader);
        _inputVariable2.Read(reader);
        _rangeVariable2.Read(reader);
        _outputModifier2.Read(reader);
        _outputModifierInput2.Read(reader);
        _data2.Read(reader);
        _inputVariable3.Read(reader);
        _rangeVariable3.Read(reader);
        _outputModifier3.Read(reader);
        _outputModifierInput3.Read(reader);
        _data3.Read(reader);
        _inputVariable4.Read(reader);
        _rangeVariable4.Read(reader);
        _outputModifier4.Read(reader);
        _outputModifierInput4.Read(reader);
        _data4.Read(reader);
        _inputVariable5.Read(reader);
        _rangeVariable5.Read(reader);
        _outputModifier5.Read(reader);
        _outputModifierInput5.Read(reader);
        _data5.Read(reader);
        _inputVariable6.Read(reader);
        _rangeVariable6.Read(reader);
        _outputModifier6.Read(reader);
        _outputModifierInput6.Read(reader);
        _data6.Read(reader);
        _inputVariable7.Read(reader);
        _rangeVariable7.Read(reader);
        _outputModifier7.Read(reader);
        _outputModifierInput7.Read(reader);
        _data7.Read(reader);
        _emissionShape.Read(reader);
        _inputVariable8.Read(reader);
        _rangeVariable8.Read(reader);
        _outputModifier8.Read(reader);
        _outputModifierInput8.Read(reader);
        _data8.Read(reader);
        _inputVariable9.Read(reader);
        _rangeVariable9.Read(reader);
        _outputModifier9.Read(reader);
        _outputModifierInput9.Read(reader);
        _data9.Read(reader);
        _translationalOffset.Read(reader);
        _relativeDirection.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _particlePhysics.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2.Add(new ByteBlockBlock());
          Data2[x].Read(reader);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4.Add(new ByteBlockBlock());
          Data4[x].Read(reader);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5.Add(new ByteBlockBlock());
          Data5[x].Read(reader);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6.Add(new ByteBlockBlock());
          Data6[x].Read(reader);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data7.Count); x = (x + 1)) {
          Data7.Add(new ByteBlockBlock());
          Data7[x].Read(reader);
        }
        for (x = 0; (x < _data7.Count); x = (x + 1)) {
          Data7[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data8.Count); x = (x + 1)) {
          Data8.Add(new ByteBlockBlock());
          Data8[x].Read(reader);
        }
        for (x = 0; (x < _data8.Count); x = (x + 1)) {
          Data8[x].ReadChildData(reader);
        }
        for (x = 0; (x < _data9.Count); x = (x + 1)) {
          Data9.Add(new ByteBlockBlock());
          Data9[x].Read(reader);
        }
        for (x = 0; (x < _data9.Count); x = (x + 1)) {
          Data9[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _particlePhysics.Write(bw);
        _inputVariable.Write(bw);
        _rangeVariable.Write(bw);
        _outputModifier.Write(bw);
        _outputModifierInput.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _inputVariable2.Write(bw);
        _rangeVariable2.Write(bw);
        _outputModifier2.Write(bw);
        _outputModifierInput2.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _inputVariable3.Write(bw);
        _rangeVariable3.Write(bw);
        _outputModifier3.Write(bw);
        _outputModifierInput3.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
        _inputVariable4.Write(bw);
        _rangeVariable4.Write(bw);
        _outputModifier4.Write(bw);
        _outputModifierInput4.Write(bw);
_data4.Count = Data4.Count;
        _data4.Write(bw);
        _inputVariable5.Write(bw);
        _rangeVariable5.Write(bw);
        _outputModifier5.Write(bw);
        _outputModifierInput5.Write(bw);
_data5.Count = Data5.Count;
        _data5.Write(bw);
        _inputVariable6.Write(bw);
        _rangeVariable6.Write(bw);
        _outputModifier6.Write(bw);
        _outputModifierInput6.Write(bw);
_data6.Count = Data6.Count;
        _data6.Write(bw);
        _inputVariable7.Write(bw);
        _rangeVariable7.Write(bw);
        _outputModifier7.Write(bw);
        _outputModifierInput7.Write(bw);
_data7.Count = Data7.Count;
        _data7.Write(bw);
        _emissionShape.Write(bw);
        _inputVariable8.Write(bw);
        _rangeVariable8.Write(bw);
        _outputModifier8.Write(bw);
        _outputModifierInput8.Write(bw);
_data8.Count = Data8.Count;
        _data8.Write(bw);
        _inputVariable9.Write(bw);
        _rangeVariable9.Write(bw);
        _outputModifier9.Write(bw);
        _outputModifierInput9.Write(bw);
_data9.Count = Data9.Count;
        _data9.Write(bw);
        _translationalOffset.Write(bw);
        _relativeDirection.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _particlePhysics.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].Write(writer);
        }
        for (x = 0; (x < _data2.Count); x = (x + 1)) {
          Data2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].Write(writer);
        }
        for (x = 0; (x < _data4.Count); x = (x + 1)) {
          Data4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].Write(writer);
        }
        for (x = 0; (x < _data5.Count); x = (x + 1)) {
          Data5[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].Write(writer);
        }
        for (x = 0; (x < _data6.Count); x = (x + 1)) {
          Data6[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data7.Count); x = (x + 1)) {
          Data7[x].Write(writer);
        }
        for (x = 0; (x < _data7.Count); x = (x + 1)) {
          Data7[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data8.Count); x = (x + 1)) {
          Data8[x].Write(writer);
        }
        for (x = 0; (x < _data8.Count); x = (x + 1)) {
          Data8[x].WriteChildData(writer);
        }
        for (x = 0; (x < _data9.Count); x = (x + 1)) {
          Data9[x].Write(writer);
        }
        for (x = 0; (x < _data9.Count); x = (x + 1)) {
          Data9[x].WriteChildData(writer);
        }
      }
    }
  }
}
