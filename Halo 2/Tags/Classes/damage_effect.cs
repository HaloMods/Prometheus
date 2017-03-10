// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'damage_effect'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class damage_effect : Interfaces.Pool.Tag {
    private DamageOuterConeAngleStructBlockBlock damageEffectValues = new DamageOuterConeAngleStructBlockBlock();
    public virtual DamageOuterConeAngleStructBlockBlock DamageEffectValues {
      get {
        return damageEffectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(DamageEffectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "damage_effect";
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
damageEffectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
damageEffectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
damageEffectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
damageEffectValues.WriteChildData(writer);
    }
    #endregion
    public class DamageOuterConeAngleStructBlockBlock : IBlock {
      private RealBounds _radius = new RealBounds();
      private RealFraction _cutoffScale = new RealFraction();
      private Flags _flags;
      private Enum _sideEffect;
      private Enum _category;
      private Flags _flags2;
      private Real _aOECoreRadius = new Real();
      private Real _damageLowerBound = new Real();
      private RealBounds _damageUpperBound = new RealBounds();
      private Angle _dmgInnerConeAngle = new Angle();
      private Angle _dmgOuterConeAngle = new Angle();
      private Real _activeCamouflageDamage = new Real();
      private Real _stun = new Real();
      private Real _maximumStun = new Real();
      private Real _stunTime = new Real();
      private Real _instantaneousAcceleration = new Real();
      private Real _riderDirectDamageScale = new Real();
      private Real _riderMaximumTransferDamageScale = new Real();
      private Real _riderMinimumTransferDamageScale = new Real();
      private StringId _generaldamage = new StringId();
      private StringId _specificdamage = new StringId();
      private Real _aIStunRadius = new Real();
      private RealBounds _aIStunBounds = new RealBounds();
      private Real _shakeRadius = new Real();
      private Real _eMPRadius = new Real();
      private Block _playerResponses = new Block();
      private Real _duration = new Real();
      private Enum _fadeFunction;
      private Pad _unnamed0;
      private Angle _rotation = new Angle();
      private Real _pushback = new Real();
      private RealBounds _jitter = new RealBounds();
      private Real _duration2 = new Real();
      private Enum _falloffFunction;
      private Pad _unnamed1;
      private Real _randomTranslation = new Real();
      private Angle _randomRotation = new Angle();
      private Enum _wobbleFunction;
      private Pad _unnamed2;
      private Real _wobbleFunctionPeriod = new Real();
      private RealFraction _wobbleWeight = new RealFraction();
      private TagReference _sound = new TagReference();
      private Real _forwardVelocity = new Real();
      private Real _forwardRadius = new Real();
      private Real _forwardExponent = new Real();
      private Real _outwardVelocity = new Real();
      private Real _outwardRadius = new Real();
      private Real _outwardExponent = new Real();
      public BlockCollection<DamageEffectPlayerResponseBlockBlock> _playerResponsesList = new BlockCollection<DamageEffectPlayerResponseBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageOuterConeAngleStructBlockBlock() {
        this._flags = new Flags(4);
        this._sideEffect = new Enum(2);
        this._category = new Enum(2);
        this._flags2 = new Flags(4);
        this._fadeFunction = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._falloffFunction = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._wobbleFunction = new Enum(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<DamageEffectPlayerResponseBlockBlock> PlayerResponses {
        get {
          return this._playerResponsesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
for (int x=0; x<PlayerResponses.BlockCount; x++)
{
  IBlock block = PlayerResponses.GetBlock(x);
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
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealFraction CutoffScale {
        get {
          return this._cutoffScale;
        }
        set {
          this._cutoffScale = value;
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
      public Enum SideEffect {
        get {
          return this._sideEffect;
        }
        set {
          this._sideEffect = value;
        }
      }
      public Enum Category {
        get {
          return this._category;
        }
        set {
          this._category = value;
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
      public Real AOECoreRadius {
        get {
          return this._aOECoreRadius;
        }
        set {
          this._aOECoreRadius = value;
        }
      }
      public Real DamageLowerBound {
        get {
          return this._damageLowerBound;
        }
        set {
          this._damageLowerBound = value;
        }
      }
      public RealBounds DamageUpperBound {
        get {
          return this._damageUpperBound;
        }
        set {
          this._damageUpperBound = value;
        }
      }
      public Angle DmgInnerConeAngle {
        get {
          return this._dmgInnerConeAngle;
        }
        set {
          this._dmgInnerConeAngle = value;
        }
      }
      public Angle DmgOuterConeAngle {
        get {
          return this._dmgOuterConeAngle;
        }
        set {
          this._dmgOuterConeAngle = value;
        }
      }
      public Real ActiveCamouflageDamage {
        get {
          return this._activeCamouflageDamage;
        }
        set {
          this._activeCamouflageDamage = value;
        }
      }
      public Real Stun {
        get {
          return this._stun;
        }
        set {
          this._stun = value;
        }
      }
      public Real MaximumStun {
        get {
          return this._maximumStun;
        }
        set {
          this._maximumStun = value;
        }
      }
      public Real StunTime {
        get {
          return this._stunTime;
        }
        set {
          this._stunTime = value;
        }
      }
      public Real InstantaneousAcceleration {
        get {
          return this._instantaneousAcceleration;
        }
        set {
          this._instantaneousAcceleration = value;
        }
      }
      public Real RiderDirectDamageScale {
        get {
          return this._riderDirectDamageScale;
        }
        set {
          this._riderDirectDamageScale = value;
        }
      }
      public Real RiderMaximumTransferDamageScale {
        get {
          return this._riderMaximumTransferDamageScale;
        }
        set {
          this._riderMaximumTransferDamageScale = value;
        }
      }
      public Real RiderMinimumTransferDamageScale {
        get {
          return this._riderMinimumTransferDamageScale;
        }
        set {
          this._riderMinimumTransferDamageScale = value;
        }
      }
      public StringId Generaldamage {
        get {
          return this._generaldamage;
        }
        set {
          this._generaldamage = value;
        }
      }
      public StringId Specificdamage {
        get {
          return this._specificdamage;
        }
        set {
          this._specificdamage = value;
        }
      }
      public Real AIStunRadius {
        get {
          return this._aIStunRadius;
        }
        set {
          this._aIStunRadius = value;
        }
      }
      public RealBounds AIStunBounds {
        get {
          return this._aIStunBounds;
        }
        set {
          this._aIStunBounds = value;
        }
      }
      public Real ShakeRadius {
        get {
          return this._shakeRadius;
        }
        set {
          this._shakeRadius = value;
        }
      }
      public Real EMPRadius {
        get {
          return this._eMPRadius;
        }
        set {
          this._eMPRadius = value;
        }
      }
      public Real Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public Enum FadeFunction {
        get {
          return this._fadeFunction;
        }
        set {
          this._fadeFunction = value;
        }
      }
      public Angle Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public Real Pushback {
        get {
          return this._pushback;
        }
        set {
          this._pushback = value;
        }
      }
      public RealBounds Jitter {
        get {
          return this._jitter;
        }
        set {
          this._jitter = value;
        }
      }
      public Real Duration2 {
        get {
          return this._duration2;
        }
        set {
          this._duration2 = value;
        }
      }
      public Enum FalloffFunction {
        get {
          return this._falloffFunction;
        }
        set {
          this._falloffFunction = value;
        }
      }
      public Real RandomTranslation {
        get {
          return this._randomTranslation;
        }
        set {
          this._randomTranslation = value;
        }
      }
      public Angle RandomRotation {
        get {
          return this._randomRotation;
        }
        set {
          this._randomRotation = value;
        }
      }
      public Enum WobbleFunction {
        get {
          return this._wobbleFunction;
        }
        set {
          this._wobbleFunction = value;
        }
      }
      public Real WobbleFunctionPeriod {
        get {
          return this._wobbleFunctionPeriod;
        }
        set {
          this._wobbleFunctionPeriod = value;
        }
      }
      public RealFraction WobbleWeight {
        get {
          return this._wobbleWeight;
        }
        set {
          this._wobbleWeight = value;
        }
      }
      public TagReference Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public Real ForwardVelocity {
        get {
          return this._forwardVelocity;
        }
        set {
          this._forwardVelocity = value;
        }
      }
      public Real ForwardRadius {
        get {
          return this._forwardRadius;
        }
        set {
          this._forwardRadius = value;
        }
      }
      public Real ForwardExponent {
        get {
          return this._forwardExponent;
        }
        set {
          this._forwardExponent = value;
        }
      }
      public Real OutwardVelocity {
        get {
          return this._outwardVelocity;
        }
        set {
          this._outwardVelocity = value;
        }
      }
      public Real OutwardRadius {
        get {
          return this._outwardRadius;
        }
        set {
          this._outwardRadius = value;
        }
      }
      public Real OutwardExponent {
        get {
          return this._outwardExponent;
        }
        set {
          this._outwardExponent = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _radius.Read(reader);
        _cutoffScale.Read(reader);
        _flags.Read(reader);
        _sideEffect.Read(reader);
        _category.Read(reader);
        _flags2.Read(reader);
        _aOECoreRadius.Read(reader);
        _damageLowerBound.Read(reader);
        _damageUpperBound.Read(reader);
        _dmgInnerConeAngle.Read(reader);
        _dmgOuterConeAngle.Read(reader);
        _activeCamouflageDamage.Read(reader);
        _stun.Read(reader);
        _maximumStun.Read(reader);
        _stunTime.Read(reader);
        _instantaneousAcceleration.Read(reader);
        _riderDirectDamageScale.Read(reader);
        _riderMaximumTransferDamageScale.Read(reader);
        _riderMinimumTransferDamageScale.Read(reader);
        _generaldamage.Read(reader);
        _specificdamage.Read(reader);
        _aIStunRadius.Read(reader);
        _aIStunBounds.Read(reader);
        _shakeRadius.Read(reader);
        _eMPRadius.Read(reader);
        _playerResponses.Read(reader);
        _duration.Read(reader);
        _fadeFunction.Read(reader);
        _unnamed0.Read(reader);
        _rotation.Read(reader);
        _pushback.Read(reader);
        _jitter.Read(reader);
        _duration2.Read(reader);
        _falloffFunction.Read(reader);
        _unnamed1.Read(reader);
        _randomTranslation.Read(reader);
        _randomRotation.Read(reader);
        _wobbleFunction.Read(reader);
        _unnamed2.Read(reader);
        _wobbleFunctionPeriod.Read(reader);
        _wobbleWeight.Read(reader);
        _sound.Read(reader);
        _forwardVelocity.Read(reader);
        _forwardRadius.Read(reader);
        _forwardExponent.Read(reader);
        _outwardVelocity.Read(reader);
        _outwardRadius.Read(reader);
        _outwardExponent.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _generaldamage.ReadString(reader);
        _specificdamage.ReadString(reader);
        for (x = 0; (x < _playerResponses.Count); x = (x + 1)) {
          PlayerResponses.Add(new DamageEffectPlayerResponseBlockBlock());
          PlayerResponses[x].Read(reader);
        }
        for (x = 0; (x < _playerResponses.Count); x = (x + 1)) {
          PlayerResponses[x].ReadChildData(reader);
        }
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _radius.Write(bw);
        _cutoffScale.Write(bw);
        _flags.Write(bw);
        _sideEffect.Write(bw);
        _category.Write(bw);
        _flags2.Write(bw);
        _aOECoreRadius.Write(bw);
        _damageLowerBound.Write(bw);
        _damageUpperBound.Write(bw);
        _dmgInnerConeAngle.Write(bw);
        _dmgOuterConeAngle.Write(bw);
        _activeCamouflageDamage.Write(bw);
        _stun.Write(bw);
        _maximumStun.Write(bw);
        _stunTime.Write(bw);
        _instantaneousAcceleration.Write(bw);
        _riderDirectDamageScale.Write(bw);
        _riderMaximumTransferDamageScale.Write(bw);
        _riderMinimumTransferDamageScale.Write(bw);
        _generaldamage.Write(bw);
        _specificdamage.Write(bw);
        _aIStunRadius.Write(bw);
        _aIStunBounds.Write(bw);
        _shakeRadius.Write(bw);
        _eMPRadius.Write(bw);
_playerResponses.Count = PlayerResponses.Count;
        _playerResponses.Write(bw);
        _duration.Write(bw);
        _fadeFunction.Write(bw);
        _unnamed0.Write(bw);
        _rotation.Write(bw);
        _pushback.Write(bw);
        _jitter.Write(bw);
        _duration2.Write(bw);
        _falloffFunction.Write(bw);
        _unnamed1.Write(bw);
        _randomTranslation.Write(bw);
        _randomRotation.Write(bw);
        _wobbleFunction.Write(bw);
        _unnamed2.Write(bw);
        _wobbleFunctionPeriod.Write(bw);
        _wobbleWeight.Write(bw);
        _sound.Write(bw);
        _forwardVelocity.Write(bw);
        _forwardRadius.Write(bw);
        _forwardExponent.Write(bw);
        _outwardVelocity.Write(bw);
        _outwardRadius.Write(bw);
        _outwardExponent.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _generaldamage.WriteString(writer);
        _specificdamage.WriteString(writer);
        for (x = 0; (x < _playerResponses.Count); x = (x + 1)) {
          PlayerResponses[x].Write(writer);
        }
        for (x = 0; (x < _playerResponses.Count); x = (x + 1)) {
          PlayerResponses[x].WriteChildData(writer);
        }
        _sound.WriteString(writer);
      }
    }
    public class DamageEffectPlayerResponseBlockBlock : IBlock {
      private Enum _responseType;
      private Pad _unnamed0;
      private Enum _type;
      private Enum _priority;
      private Real _duration = new Real();
      private Enum _fadeFunction;
      private Pad _unnamed1;
      private RealFraction _maximumIntensity = new RealFraction();
      private RealARGBColor _color = new RealARGBColor();
      private Real _duration2 = new Real();
      private Block _data = new Block();
      private Real _duration3 = new Real();
      private Block _data2 = new Block();
      private StringId _effectName = new StringId();
      private Real _duration4 = new Real();
      private Block _data3 = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data2List = new BlockCollection<ByteBlockBlock>();
      public BlockCollection<ByteBlockBlock> _data3List = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageEffectPlayerResponseBlockBlock() {
        this._responseType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._type = new Enum(2);
        this._priority = new Enum(2);
        this._fadeFunction = new Enum(2);
        this._unnamed1 = new Pad(2);
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
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum ResponseType {
        get {
          return this._responseType;
        }
        set {
          this._responseType = value;
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
      public Enum Priority {
        get {
          return this._priority;
        }
        set {
          this._priority = value;
        }
      }
      public Real Duration {
        get {
          return this._duration;
        }
        set {
          this._duration = value;
        }
      }
      public Enum FadeFunction {
        get {
          return this._fadeFunction;
        }
        set {
          this._fadeFunction = value;
        }
      }
      public RealFraction MaximumIntensity {
        get {
          return this._maximumIntensity;
        }
        set {
          this._maximumIntensity = value;
        }
      }
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public Real Duration2 {
        get {
          return this._duration2;
        }
        set {
          this._duration2 = value;
        }
      }
      public Real Duration3 {
        get {
          return this._duration3;
        }
        set {
          this._duration3 = value;
        }
      }
      public StringId EffectName {
        get {
          return this._effectName;
        }
        set {
          this._effectName = value;
        }
      }
      public Real Duration4 {
        get {
          return this._duration4;
        }
        set {
          this._duration4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _responseType.Read(reader);
        _unnamed0.Read(reader);
        _type.Read(reader);
        _priority.Read(reader);
        _duration.Read(reader);
        _fadeFunction.Read(reader);
        _unnamed1.Read(reader);
        _maximumIntensity.Read(reader);
        _color.Read(reader);
        _duration2.Read(reader);
        _data.Read(reader);
        _duration3.Read(reader);
        _data2.Read(reader);
        _effectName.Read(reader);
        _duration4.Read(reader);
        _data3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
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
        _effectName.ReadString(reader);
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3.Add(new ByteBlockBlock());
          Data3[x].Read(reader);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _responseType.Write(bw);
        _unnamed0.Write(bw);
        _type.Write(bw);
        _priority.Write(bw);
        _duration.Write(bw);
        _fadeFunction.Write(bw);
        _unnamed1.Write(bw);
        _maximumIntensity.Write(bw);
        _color.Write(bw);
        _duration2.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _duration3.Write(bw);
_data2.Count = Data2.Count;
        _data2.Write(bw);
        _effectName.Write(bw);
        _duration4.Write(bw);
_data3.Count = Data3.Count;
        _data3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
        _effectName.WriteString(writer);
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].Write(writer);
        }
        for (x = 0; (x < _data3.Count); x = (x + 1)) {
          Data3[x].WriteChildData(writer);
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
  }
}
