// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'particle_physics'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class particle_physics : Interfaces.Pool.Tag {
    private ParticlePhysicsBlockBlock particlePhysicsValues = new ParticlePhysicsBlockBlock();
    public virtual ParticlePhysicsBlockBlock ParticlePhysicsValues {
      get {
        return particlePhysicsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ParticlePhysicsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "particle_physics";
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
particlePhysicsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
particlePhysicsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
particlePhysicsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
particlePhysicsValues.WriteChildData(writer);
    }
    #endregion
    public class ParticlePhysicsBlockBlock : IBlock {
      private TagReference _template = new TagReference();
      private Flags _flags;
      private Block _movements = new Block();
      public BlockCollection<ParticleControllerBlock> _movementsList = new BlockCollection<ParticleControllerBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticlePhysicsBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<ParticleControllerBlock> Movements {
        get {
          return this._movementsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_template.Value);
for (int x=0; x<Movements.BlockCount; x++)
{
  IBlock block = Movements.GetBlock(x);
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
      public TagReference Template {
        get {
          return this._template;
        }
        set {
          this._template = value;
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
        _template.Read(reader);
        _flags.Read(reader);
        _movements.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _template.ReadString(reader);
        for (x = 0; (x < _movements.Count); x = (x + 1)) {
          Movements.Add(new ParticleControllerBlock());
          Movements[x].Read(reader);
        }
        for (x = 0; (x < _movements.Count); x = (x + 1)) {
          Movements[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _template.Write(bw);
        _flags.Write(bw);
_movements.Count = Movements.Count;
        _movements.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _template.WriteString(writer);
        for (x = 0; (x < _movements.Count); x = (x + 1)) {
          Movements[x].Write(writer);
        }
        for (x = 0; (x < _movements.Count); x = (x + 1)) {
          Movements[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleControllerBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private Block _parameters = new Block();
      private Pad _unnamed1;
      public BlockCollection<ParticleControllerParametersBlock> _parametersList = new BlockCollection<ParticleControllerParametersBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleControllerBlock() {
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(8);
      }
      public BlockCollection<ParticleControllerParametersBlock> Parameters {
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _parameters.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters.Add(new ParticleControllerParametersBlock());
          Parameters[x].Read(reader);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
_parameters.Count = Parameters.Count;
        _parameters.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].Write(writer);
        }
        for (x = 0; (x < _parameters.Count); x = (x + 1)) {
          Parameters[x].WriteChildData(writer);
        }
      }
    }
    public class ParticleControllerParametersBlock : IBlock {
      private LongInteger _parameterId = new LongInteger();
      private Enum _inputVariable;
      private Enum _rangeVariable;
      private Enum _outputModifier;
      private Enum _outputModifierInput;
      private Block _data = new Block();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ParticleControllerParametersBlock() {
        this._inputVariable = new Enum(2);
        this._rangeVariable = new Enum(2);
        this._outputModifier = new Enum(2);
        this._outputModifierInput = new Enum(2);
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
      public LongInteger ParameterId {
        get {
          return this._parameterId;
        }
        set {
          this._parameterId = value;
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
      public virtual void Read(BinaryReader reader) {
        _parameterId.Read(reader);
        _inputVariable.Read(reader);
        _rangeVariable.Read(reader);
        _outputModifier.Read(reader);
        _outputModifierInput.Read(reader);
        _data.Read(reader);
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
      }
      public virtual void Write(BinaryWriter bw) {
        _parameterId.Write(bw);
        _inputVariable.Write(bw);
        _rangeVariable.Write(bw);
        _outputModifier.Write(bw);
        _outputModifierInput.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
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
  }
}
