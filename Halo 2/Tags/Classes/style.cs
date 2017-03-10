// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'style'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class style : Interfaces.Pool.Tag {
    private StyleBlockBlock styleValues = new StyleBlockBlock();
    public virtual StyleBlockBlock StyleValues {
      get {
        return styleValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(StyleValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "style";
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
styleValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
styleValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
styleValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
styleValues.WriteChildData(writer);
    }
    #endregion
    public class StyleBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _combatStatusDecayOptions;
      private Pad _unnamed0;
      private Enum _attitude;
      private Pad _unnamed1;
      private Enum _engageAttitude;
      private Enum _evasionAttitude;
      private Enum _coverAttitude;
      private Enum _searchAttitude;
      private Enum _presearchAttitude;
      private Enum _retreatAttitude;
      private Enum _chargeAttitude;
      private Enum _readyAttitude;
      private Enum _idleAttitude;
      private Enum _weaponAttitude;
      private Enum _swarmAttitude;
      private Pad _unnamed2;
      private Flags _styleControl;
      private Flags _behaviors1;
      private Flags _behaviors2;
      private Flags _behaviors3;
      private Flags _behaviors4;
      private Flags _behaviors5;
      private Block _specialMovement = new Block();
      private Block _behaviorList = new Block();
      public BlockCollection<SpecialMovementBlockBlock> _specialMovementList = new BlockCollection<SpecialMovementBlockBlock>();
      public BlockCollection<BehaviorNamesBlockBlock> _behaviorListList = new BlockCollection<BehaviorNamesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public StyleBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._combatStatusDecayOptions = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._attitude = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._engageAttitude = new Enum(1);
        this._evasionAttitude = new Enum(1);
        this._coverAttitude = new Enum(1);
        this._searchAttitude = new Enum(1);
        this._presearchAttitude = new Enum(1);
        this._retreatAttitude = new Enum(1);
        this._chargeAttitude = new Enum(1);
        this._readyAttitude = new Enum(1);
        this._idleAttitude = new Enum(1);
        this._weaponAttitude = new Enum(1);
        this._swarmAttitude = new Enum(1);
        this._unnamed2 = new Pad(1);
        this._styleControl = new Flags(4);
        this._behaviors1 = new Flags(4);
        this._behaviors2 = new Flags(4);
        this._behaviors3 = new Flags(4);
        this._behaviors4 = new Flags(4);
        this._behaviors5 = new Flags(4);
      }
      public BlockCollection<SpecialMovementBlockBlock> SpecialMovement {
        get {
          return this._specialMovementList;
        }
      }
      public BlockCollection<BehaviorNamesBlockBlock> BehaviorList {
        get {
          return this._behaviorListList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<SpecialMovement.BlockCount; x++)
{
  IBlock block = SpecialMovement.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BehaviorList.BlockCount; x++)
{
  IBlock block = BehaviorList.GetBlock(x);
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
      public Enum CombatStatusDecayOptions {
        get {
          return this._combatStatusDecayOptions;
        }
        set {
          this._combatStatusDecayOptions = value;
        }
      }
      public Enum Attitude {
        get {
          return this._attitude;
        }
        set {
          this._attitude = value;
        }
      }
      public Enum EngageAttitude {
        get {
          return this._engageAttitude;
        }
        set {
          this._engageAttitude = value;
        }
      }
      public Enum EvasionAttitude {
        get {
          return this._evasionAttitude;
        }
        set {
          this._evasionAttitude = value;
        }
      }
      public Enum CoverAttitude {
        get {
          return this._coverAttitude;
        }
        set {
          this._coverAttitude = value;
        }
      }
      public Enum SearchAttitude {
        get {
          return this._searchAttitude;
        }
        set {
          this._searchAttitude = value;
        }
      }
      public Enum PresearchAttitude {
        get {
          return this._presearchAttitude;
        }
        set {
          this._presearchAttitude = value;
        }
      }
      public Enum RetreatAttitude {
        get {
          return this._retreatAttitude;
        }
        set {
          this._retreatAttitude = value;
        }
      }
      public Enum ChargeAttitude {
        get {
          return this._chargeAttitude;
        }
        set {
          this._chargeAttitude = value;
        }
      }
      public Enum ReadyAttitude {
        get {
          return this._readyAttitude;
        }
        set {
          this._readyAttitude = value;
        }
      }
      public Enum IdleAttitude {
        get {
          return this._idleAttitude;
        }
        set {
          this._idleAttitude = value;
        }
      }
      public Enum WeaponAttitude {
        get {
          return this._weaponAttitude;
        }
        set {
          this._weaponAttitude = value;
        }
      }
      public Enum SwarmAttitude {
        get {
          return this._swarmAttitude;
        }
        set {
          this._swarmAttitude = value;
        }
      }
      public Flags StyleControl {
        get {
          return this._styleControl;
        }
        set {
          this._styleControl = value;
        }
      }
      public Flags Behaviors1 {
        get {
          return this._behaviors1;
        }
        set {
          this._behaviors1 = value;
        }
      }
      public Flags Behaviors2 {
        get {
          return this._behaviors2;
        }
        set {
          this._behaviors2 = value;
        }
      }
      public Flags Behaviors3 {
        get {
          return this._behaviors3;
        }
        set {
          this._behaviors3 = value;
        }
      }
      public Flags Behaviors4 {
        get {
          return this._behaviors4;
        }
        set {
          this._behaviors4 = value;
        }
      }
      public Flags Behaviors5 {
        get {
          return this._behaviors5;
        }
        set {
          this._behaviors5 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _combatStatusDecayOptions.Read(reader);
        _unnamed0.Read(reader);
        _attitude.Read(reader);
        _unnamed1.Read(reader);
        _engageAttitude.Read(reader);
        _evasionAttitude.Read(reader);
        _coverAttitude.Read(reader);
        _searchAttitude.Read(reader);
        _presearchAttitude.Read(reader);
        _retreatAttitude.Read(reader);
        _chargeAttitude.Read(reader);
        _readyAttitude.Read(reader);
        _idleAttitude.Read(reader);
        _weaponAttitude.Read(reader);
        _swarmAttitude.Read(reader);
        _unnamed2.Read(reader);
        _styleControl.Read(reader);
        _behaviors1.Read(reader);
        _behaviors2.Read(reader);
        _behaviors3.Read(reader);
        _behaviors4.Read(reader);
        _behaviors5.Read(reader);
        _specialMovement.Read(reader);
        _behaviorList.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement.Add(new SpecialMovementBlockBlock());
          SpecialMovement[x].Read(reader);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].ReadChildData(reader);
        }
        for (x = 0; (x < _behaviorList.Count); x = (x + 1)) {
          BehaviorList.Add(new BehaviorNamesBlockBlock());
          BehaviorList[x].Read(reader);
        }
        for (x = 0; (x < _behaviorList.Count); x = (x + 1)) {
          BehaviorList[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _combatStatusDecayOptions.Write(bw);
        _unnamed0.Write(bw);
        _attitude.Write(bw);
        _unnamed1.Write(bw);
        _engageAttitude.Write(bw);
        _evasionAttitude.Write(bw);
        _coverAttitude.Write(bw);
        _searchAttitude.Write(bw);
        _presearchAttitude.Write(bw);
        _retreatAttitude.Write(bw);
        _chargeAttitude.Write(bw);
        _readyAttitude.Write(bw);
        _idleAttitude.Write(bw);
        _weaponAttitude.Write(bw);
        _swarmAttitude.Write(bw);
        _unnamed2.Write(bw);
        _styleControl.Write(bw);
        _behaviors1.Write(bw);
        _behaviors2.Write(bw);
        _behaviors3.Write(bw);
        _behaviors4.Write(bw);
        _behaviors5.Write(bw);
_specialMovement.Count = SpecialMovement.Count;
        _specialMovement.Write(bw);
_behaviorList.Count = BehaviorList.Count;
        _behaviorList.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].Write(writer);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].WriteChildData(writer);
        }
        for (x = 0; (x < _behaviorList.Count); x = (x + 1)) {
          BehaviorList[x].Write(writer);
        }
        for (x = 0; (x < _behaviorList.Count); x = (x + 1)) {
          BehaviorList[x].WriteChildData(writer);
        }
      }
    }
    public class SpecialMovementBlockBlock : IBlock {
      private Flags _specialMovement1;
public event System.EventHandler BlockNameChanged;
      public SpecialMovementBlockBlock() {
        this._specialMovement1 = new Flags(4);
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
      public Flags SpecialMovement1 {
        get {
          return this._specialMovement1;
        }
        set {
          this._specialMovement1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _specialMovement1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _specialMovement1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class BehaviorNamesBlockBlock : IBlock {
      private FixedLengthString _behaviorName = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public BehaviorNamesBlockBlock() {
if (this._behaviorName is System.ComponentModel.INotifyPropertyChanged)
  (this._behaviorName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _behaviorName.ToString();
        }
      }
      public FixedLengthString BehaviorName {
        get {
          return this._behaviorName;
        }
        set {
          this._behaviorName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _behaviorName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _behaviorName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
