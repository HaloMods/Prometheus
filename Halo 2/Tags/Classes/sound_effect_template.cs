// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'sound_effect_template'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class sound_effect_template : Interfaces.Pool.Tag {
    private SoundEffectTemplateBlockBlock soundEffectTemplateValues = new SoundEffectTemplateBlockBlock();
    public virtual SoundEffectTemplateBlockBlock SoundEffectTemplateValues {
      get {
        return soundEffectTemplateValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(SoundEffectTemplateValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "sound_effect_template";
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
soundEffectTemplateValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
soundEffectTemplateValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
soundEffectTemplateValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
soundEffectTemplateValues.WriteChildData(writer);
    }
    #endregion
    public class SoundEffectTemplateBlockBlock : IBlock {
      private Block _templateCollection = new Block();
      private StringId _inputEffectName = new StringId();
      private Block _additionalSoundInputs = new Block();
      private Block _unnamed0 = new Block();
      public BlockCollection<SoundEffectTemplatesBlockBlock> _templateCollectionList = new BlockCollection<SoundEffectTemplatesBlockBlock>();
      public BlockCollection<SoundEffectTemplateAdditionalSoundInputBlockBlock> _additionalSoundInputsList = new BlockCollection<SoundEffectTemplateAdditionalSoundInputBlockBlock>();
      public BlockCollection<PlatformSoundEffectTemplateCollectionBlockBlock> _unnamed0List = new BlockCollection<PlatformSoundEffectTemplateCollectionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectTemplateBlockBlock() {
      }
      public BlockCollection<SoundEffectTemplatesBlockBlock> TemplateCollection {
        get {
          return this._templateCollectionList;
        }
      }
      public BlockCollection<SoundEffectTemplateAdditionalSoundInputBlockBlock> AdditionalSoundInputs {
        get {
          return this._additionalSoundInputsList;
        }
      }
      public BlockCollection<PlatformSoundEffectTemplateCollectionBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<TemplateCollection.BlockCount; x++)
{
  IBlock block = TemplateCollection.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AdditionalSoundInputs.BlockCount; x++)
{
  IBlock block = AdditionalSoundInputs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
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
      public StringId InputEffectName {
        get {
          return this._inputEffectName;
        }
        set {
          this._inputEffectName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _templateCollection.Read(reader);
        _inputEffectName.Read(reader);
        _additionalSoundInputs.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _templateCollection.Count); x = (x + 1)) {
          TemplateCollection.Add(new SoundEffectTemplatesBlockBlock());
          TemplateCollection[x].Read(reader);
        }
        for (x = 0; (x < _templateCollection.Count); x = (x + 1)) {
          TemplateCollection[x].ReadChildData(reader);
        }
        _inputEffectName.ReadString(reader);
        for (x = 0; (x < _additionalSoundInputs.Count); x = (x + 1)) {
          AdditionalSoundInputs.Add(new SoundEffectTemplateAdditionalSoundInputBlockBlock());
          AdditionalSoundInputs[x].Read(reader);
        }
        for (x = 0; (x < _additionalSoundInputs.Count); x = (x + 1)) {
          AdditionalSoundInputs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new PlatformSoundEffectTemplateCollectionBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_templateCollection.Count = TemplateCollection.Count;
        _templateCollection.Write(bw);
        _inputEffectName.Write(bw);
_additionalSoundInputs.Count = AdditionalSoundInputs.Count;
        _additionalSoundInputs.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _templateCollection.Count); x = (x + 1)) {
          TemplateCollection[x].Write(writer);
        }
        for (x = 0; (x < _templateCollection.Count); x = (x + 1)) {
          TemplateCollection[x].WriteChildData(writer);
        }
        _inputEffectName.WriteString(writer);
        for (x = 0; (x < _additionalSoundInputs.Count); x = (x + 1)) {
          AdditionalSoundInputs[x].Write(writer);
        }
        for (x = 0; (x < _additionalSoundInputs.Count); x = (x + 1)) {
          AdditionalSoundInputs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
      }
    }
    public class SoundEffectTemplatesBlockBlock : IBlock {
      private StringId _dspEffect = new StringId();
      private Data _explanation = new Data();
      private Flags _flags;
      private ShortInteger _unnamed0 = new ShortInteger();
      private ShortInteger _unnamed1 = new ShortInteger();
      private Block _parameters = new Block();
      public BlockCollection<SoundEffectTemplateParameterBlockBlock> _parametersList = new BlockCollection<SoundEffectTemplateParameterBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectTemplatesBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<SoundEffectTemplateParameterBlockBlock> Parameters {
        get {
          return this._parametersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Parameters.BlockCount; x++)
{
  IBlock block = Parameters.GetBlock(x);
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
      public StringId DspEffect {
        get {
          return this._dspEffect;
        }
        set {
          this._dspEffect = value;
        }
      }
      public Data Explanation {
        get {
          return this._explanation;
        }
        set {
          this._explanation = value;
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
      public ShortInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public ShortInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dspEffect.Read(reader);
        _explanation.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _parameters.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _dspEffect.ReadString(reader);
        _explanation.ReadBinary(reader);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters.Add(new SoundEffectTemplateParameterBlockBlock());
          Parameters[x].Read(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dspEffect.Write(bw);
        _explanation.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
_parameters.Count = Parameters.Count;
        _parameters.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _dspEffect.WriteString(writer);
        _explanation.WriteBinary(writer);
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].Write(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].WriteChildData(writer);
        }
      }
    }
    public class SoundEffectTemplateParameterBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _type;
      private Flags _flags;
      private LongInteger _hardwareOffset = new LongInteger();
      private LongInteger _defaultEnumIntegerValue = new LongInteger();
      private Real _defaultScalarValue = new Real();
      private Block _data = new Block();
      private Real _minimumScalarValue = new Real();
      private Real _maximumScalarValue = new Real();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectTemplateParameterBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public LongInteger HardwareOffset {
        get {
          return this._hardwareOffset;
        }
        set {
          this._hardwareOffset = value;
        }
      }
      public LongInteger DefaultEnumIntegerValue {
        get {
          return this._defaultEnumIntegerValue;
        }
        set {
          this._defaultEnumIntegerValue = value;
        }
      }
      public Real DefaultScalarValue {
        get {
          return this._defaultScalarValue;
        }
        set {
          this._defaultScalarValue = value;
        }
      }
      public Real MinimumScalarValue {
        get {
          return this._minimumScalarValue;
        }
        set {
          this._minimumScalarValue = value;
        }
      }
      public Real MaximumScalarValue {
        get {
          return this._maximumScalarValue;
        }
        set {
          this._maximumScalarValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _hardwareOffset.Read(reader);
        _defaultEnumIntegerValue.Read(reader);
        _defaultScalarValue.Read(reader);
        _data.Read(reader);
        _minimumScalarValue.Read(reader);
        _maximumScalarValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _hardwareOffset.Write(bw);
        _defaultEnumIntegerValue.Write(bw);
        _defaultScalarValue.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _minimumScalarValue.Write(bw);
        _maximumScalarValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
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
    public class SoundEffectTemplateAdditionalSoundInputBlockBlock : IBlock {
      private StringId _dspEffect = new StringId();
      private Block _data = new Block();
      private Real _timePeriod = new Real();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SoundEffectTemplateAdditionalSoundInputBlockBlock() {
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
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
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public StringId DspEffect {
        get {
          return this._dspEffect;
        }
        set {
          this._dspEffect = value;
        }
      }
      public Real TimePeriod {
        get {
          return this._timePeriod;
        }
        set {
          this._timePeriod = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dspEffect.Read(reader);
        _data.Read(reader);
        _timePeriod.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _dspEffect.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dspEffect.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _timePeriod.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _dspEffect.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundEffectTemplateCollectionBlockBlock : IBlock {
      private Block _platformEffectTemplates = new Block();
      private StringId _inputDspEffectName = new StringId();
      public BlockCollection<PlatformSoundEffectTemplateBlockBlock> _platformEffectTemplatesList = new BlockCollection<PlatformSoundEffectTemplateBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectTemplateCollectionBlockBlock() {
      }
      public BlockCollection<PlatformSoundEffectTemplateBlockBlock> PlatformEffectTemplates {
        get {
          return this._platformEffectTemplatesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PlatformEffectTemplates.BlockCount; x++)
{
  IBlock block = PlatformEffectTemplates.GetBlock(x);
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
      public StringId InputDspEffectName {
        get {
          return this._inputDspEffectName;
        }
        set {
          this._inputDspEffectName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _platformEffectTemplates.Read(reader);
        _inputDspEffectName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _platformEffectTemplates.Count); x = (x + 1)) {
          PlatformEffectTemplates.Add(new PlatformSoundEffectTemplateBlockBlock());
          PlatformEffectTemplates[x].Read(reader);
        }
        for (x = 0; (x < _platformEffectTemplates.Count); x = (x + 1)) {
          PlatformEffectTemplates[x].ReadChildData(reader);
        }
        _inputDspEffectName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
_platformEffectTemplates.Count = PlatformEffectTemplates.Count;
        _platformEffectTemplates.Write(bw);
        _inputDspEffectName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _platformEffectTemplates.Count); x = (x + 1)) {
          PlatformEffectTemplates[x].Write(writer);
        }
        for (x = 0; (x < _platformEffectTemplates.Count); x = (x + 1)) {
          PlatformEffectTemplates[x].WriteChildData(writer);
        }
        _inputDspEffectName.WriteString(writer);
      }
    }
    public class PlatformSoundEffectTemplateBlockBlock : IBlock {
      private StringId _inputDspEffectName = new StringId();
      private Pad _unnamed0;
      private Block _components = new Block();
      public BlockCollection<PlatformSoundEffectTemplateComponentBlockBlock> _componentsList = new BlockCollection<PlatformSoundEffectTemplateComponentBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectTemplateBlockBlock() {
        this._unnamed0 = new Pad(12);
      }
      public BlockCollection<PlatformSoundEffectTemplateComponentBlockBlock> Components {
        get {
          return this._componentsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Components.BlockCount; x++)
{
  IBlock block = Components.GetBlock(x);
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
      public StringId InputDspEffectName {
        get {
          return this._inputDspEffectName;
        }
        set {
          this._inputDspEffectName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _inputDspEffectName.Read(reader);
        _unnamed0.Read(reader);
        _components.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inputDspEffectName.ReadString(reader);
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components.Add(new PlatformSoundEffectTemplateComponentBlockBlock());
          Components[x].Read(reader);
        }
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _inputDspEffectName.Write(bw);
        _unnamed0.Write(bw);
_components.Count = Components.Count;
        _components.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inputDspEffectName.WriteString(writer);
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].Write(writer);
        }
        for (x = 0; (x < _components.Count); x = (x + 1)) {
          Components[x].WriteChildData(writer);
        }
      }
    }
    public class PlatformSoundEffectTemplateComponentBlockBlock : IBlock {
      private Enum _valueType;
      private Real _defaultValue = new Real();
      private Real _minimumValue = new Real();
      private Real _maximumValue = new Real();
public event System.EventHandler BlockNameChanged;
      public PlatformSoundEffectTemplateComponentBlockBlock() {
        this._valueType = new Enum(4);
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
      public Enum ValueType {
        get {
          return this._valueType;
        }
        set {
          this._valueType = value;
        }
      }
      public Real DefaultValue {
        get {
          return this._defaultValue;
        }
        set {
          this._defaultValue = value;
        }
      }
      public Real MinimumValue {
        get {
          return this._minimumValue;
        }
        set {
          this._minimumValue = value;
        }
      }
      public Real MaximumValue {
        get {
          return this._maximumValue;
        }
        set {
          this._maximumValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _valueType.Read(reader);
        _defaultValue.Read(reader);
        _minimumValue.Read(reader);
        _maximumValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _valueType.Write(bw);
        _defaultValue.Write(bw);
        _minimumValue.Write(bw);
        _maximumValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
