// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'model_collision_geometry'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class model_collision_geometry : Interfaces.Pool.Tag {
    private ModelCollisionGeometryBlock modelCollisionGeometryValues = new ModelCollisionGeometryBlock();
    public virtual ModelCollisionGeometryBlock ModelCollisionGeometryValues {
      get {
        return modelCollisionGeometryValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ModelCollisionGeometryValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "model_collision_geometry";
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
modelCollisionGeometryValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
modelCollisionGeometryValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
modelCollisionGeometryValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
modelCollisionGeometryValues.WriteChildData(writer);
    }
    #endregion
    public class ModelCollisionGeometryBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _indirectDamageMaterial = new ShortBlockIndex();
      private Pad _unnamed;
      private Real _maximumBodyVitality = new Real();
      private Real _bodySystemShock = new Real();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private RealFraction _friendlyDamageResistance = new RealFraction();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private TagReference _localizedDamageEffect = new TagReference();
      private Real _areaDamageEffectThreshold = new Real();
      private TagReference _areaDamageEffect = new TagReference();
      private Real _bodyDamagedThreshold = new Real();
      private TagReference _bodyDamagedEffect = new TagReference();
      private TagReference _bodyDepletedEffect = new TagReference();
      private Real _bodyDestroyedThreshold = new Real();
      private TagReference _bodyDestroyedEffect = new TagReference();
      private Real _maximumShieldVitality = new Real();
      private Pad _unnamed6;
      private Enum _shieldMaterialType = new Enum();
      private Pad _unnamed7;
      private Enum _shieldFailureFunction = new Enum();
      private Pad _unnamed8;
      private RealFraction _shieldFailureThreshold = new RealFraction();
      private RealFraction _failingShieldLeakFraction = new RealFraction();
      private Pad _unnamed9;
      private Real _minimumStunDamage = new Real();
      private Real _stunTime = new Real();
      private Real _rechargeTime = new Real();
      private Pad _unnamed10;
      private Pad _unnamed11;
      private Real _shieldDamagedThreshold = new Real();
      private TagReference _shieldDamagedEffect = new TagReference();
      private TagReference _shieldDepletedEffect = new TagReference();
      private TagReference _shieldRechargingEffect = new TagReference();
      private Pad _unnamed12;
      private Pad _unnamed13;
      private Block _materials = new Block();
      private Block _regions = new Block();
      private Block _modifiers = new Block();
      private Pad _unnamed14;
      private RealBounds _x = new RealBounds();
      private RealBounds _y = new RealBounds();
      private RealBounds _z = new RealBounds();
      private Block _pathfindingSpheres = new Block();
      private Block _nodes = new Block();
      public BlockCollection<DamageMaterialsBlock> _materialsList = new BlockCollection<DamageMaterialsBlock>();
      public BlockCollection<DamageRegionsBlock> _regionsList = new BlockCollection<DamageRegionsBlock>();
      public BlockCollection<DamageModifiersBlock> _modifiersList = new BlockCollection<DamageModifiersBlock>();
      public BlockCollection<SphereBlock> _pathfindingSpheresList = new BlockCollection<SphereBlock>();
      public BlockCollection<NodeBlock> _nodesList = new BlockCollection<NodeBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelCollisionGeometryBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(24);
        this._unnamed3 = new Pad(28);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(24);
        this._unnamed8 = new Pad(2);
        this._unnamed9 = new Pad(16);
        this._unnamed10 = new Pad(16);
        this._unnamed11 = new Pad(96);
        this._unnamed12 = new Pad(12);
        this._unnamed13 = new Pad(112);
        this._unnamed14 = new Pad(16);
      }
      public BlockCollection<DamageMaterialsBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<DamageRegionsBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<DamageModifiersBlock> Modifiers {
        get {
          return this._modifiersList;
        }
      }
      public BlockCollection<SphereBlock> PathfindingSpheres {
        get {
          return this._pathfindingSpheresList;
        }
      }
      public BlockCollection<NodeBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_localizedDamageEffect.Value);
references.Add(_areaDamageEffect.Value);
references.Add(_bodyDamagedEffect.Value);
references.Add(_bodyDepletedEffect.Value);
references.Add(_bodyDestroyedEffect.Value);
references.Add(_shieldDamagedEffect.Value);
references.Add(_shieldDepletedEffect.Value);
references.Add(_shieldRechargingEffect.Value);
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Modifiers.BlockCount; x++)
{
  IBlock block = Modifiers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingSpheres.BlockCount; x++)
{
  IBlock block = PathfindingSpheres.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
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
      public ShortBlockIndex IndirectDamageMaterial {
        get {
          return this._indirectDamageMaterial;
        }
        set {
          this._indirectDamageMaterial = value;
        }
      }
      public Real MaximumBodyVitality {
        get {
          return this._maximumBodyVitality;
        }
        set {
          this._maximumBodyVitality = value;
        }
      }
      public Real BodySystemShock {
        get {
          return this._bodySystemShock;
        }
        set {
          this._bodySystemShock = value;
        }
      }
      public RealFraction FriendlyDamageResistance {
        get {
          return this._friendlyDamageResistance;
        }
        set {
          this._friendlyDamageResistance = value;
        }
      }
      public TagReference LocalizedDamageEffect {
        get {
          return this._localizedDamageEffect;
        }
        set {
          this._localizedDamageEffect = value;
        }
      }
      public Real AreaDamageEffectThreshold {
        get {
          return this._areaDamageEffectThreshold;
        }
        set {
          this._areaDamageEffectThreshold = value;
        }
      }
      public TagReference AreaDamageEffect {
        get {
          return this._areaDamageEffect;
        }
        set {
          this._areaDamageEffect = value;
        }
      }
      public Real BodyDamagedThreshold {
        get {
          return this._bodyDamagedThreshold;
        }
        set {
          this._bodyDamagedThreshold = value;
        }
      }
      public TagReference BodyDamagedEffect {
        get {
          return this._bodyDamagedEffect;
        }
        set {
          this._bodyDamagedEffect = value;
        }
      }
      public TagReference BodyDepletedEffect {
        get {
          return this._bodyDepletedEffect;
        }
        set {
          this._bodyDepletedEffect = value;
        }
      }
      public Real BodyDestroyedThreshold {
        get {
          return this._bodyDestroyedThreshold;
        }
        set {
          this._bodyDestroyedThreshold = value;
        }
      }
      public TagReference BodyDestroyedEffect {
        get {
          return this._bodyDestroyedEffect;
        }
        set {
          this._bodyDestroyedEffect = value;
        }
      }
      public Real MaximumShieldVitality {
        get {
          return this._maximumShieldVitality;
        }
        set {
          this._maximumShieldVitality = value;
        }
      }
      public Enum ShieldMaterialType {
        get {
          return this._shieldMaterialType;
        }
        set {
          this._shieldMaterialType = value;
        }
      }
      public Enum ShieldFailureFunction {
        get {
          return this._shieldFailureFunction;
        }
        set {
          this._shieldFailureFunction = value;
        }
      }
      public RealFraction ShieldFailureThreshold {
        get {
          return this._shieldFailureThreshold;
        }
        set {
          this._shieldFailureThreshold = value;
        }
      }
      public RealFraction FailingShieldLeakFraction {
        get {
          return this._failingShieldLeakFraction;
        }
        set {
          this._failingShieldLeakFraction = value;
        }
      }
      public Real MinimumStunDamage {
        get {
          return this._minimumStunDamage;
        }
        set {
          this._minimumStunDamage = value;
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
      public Real RechargeTime {
        get {
          return this._rechargeTime;
        }
        set {
          this._rechargeTime = value;
        }
      }
      public Real ShieldDamagedThreshold {
        get {
          return this._shieldDamagedThreshold;
        }
        set {
          this._shieldDamagedThreshold = value;
        }
      }
      public TagReference ShieldDamagedEffect {
        get {
          return this._shieldDamagedEffect;
        }
        set {
          this._shieldDamagedEffect = value;
        }
      }
      public TagReference ShieldDepletedEffect {
        get {
          return this._shieldDepletedEffect;
        }
        set {
          this._shieldDepletedEffect = value;
        }
      }
      public TagReference ShieldRechargingEffect {
        get {
          return this._shieldRechargingEffect;
        }
        set {
          this._shieldRechargingEffect = value;
        }
      }
      public RealBounds X {
        get {
          return this._x;
        }
        set {
          this._x = value;
        }
      }
      public RealBounds Y {
        get {
          return this._y;
        }
        set {
          this._y = value;
        }
      }
      public RealBounds Z {
        get {
          return this._z;
        }
        set {
          this._z = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _indirectDamageMaterial.Read(reader);
        _unnamed.Read(reader);
        _maximumBodyVitality.Read(reader);
        _bodySystemShock.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _friendlyDamageResistance.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _localizedDamageEffect.Read(reader);
        _areaDamageEffectThreshold.Read(reader);
        _areaDamageEffect.Read(reader);
        _bodyDamagedThreshold.Read(reader);
        _bodyDamagedEffect.Read(reader);
        _bodyDepletedEffect.Read(reader);
        _bodyDestroyedThreshold.Read(reader);
        _bodyDestroyedEffect.Read(reader);
        _maximumShieldVitality.Read(reader);
        _unnamed6.Read(reader);
        _shieldMaterialType.Read(reader);
        _unnamed7.Read(reader);
        _shieldFailureFunction.Read(reader);
        _unnamed8.Read(reader);
        _shieldFailureThreshold.Read(reader);
        _failingShieldLeakFraction.Read(reader);
        _unnamed9.Read(reader);
        _minimumStunDamage.Read(reader);
        _stunTime.Read(reader);
        _rechargeTime.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _shieldDamagedThreshold.Read(reader);
        _shieldDamagedEffect.Read(reader);
        _shieldDepletedEffect.Read(reader);
        _shieldRechargingEffect.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _materials.Read(reader);
        _regions.Read(reader);
        _modifiers.Read(reader);
        _unnamed14.Read(reader);
        _x.Read(reader);
        _y.Read(reader);
        _z.Read(reader);
        _pathfindingSpheres.Read(reader);
        _nodes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _localizedDamageEffect.ReadString(reader);
        _areaDamageEffect.ReadString(reader);
        _bodyDamagedEffect.ReadString(reader);
        _bodyDepletedEffect.ReadString(reader);
        _bodyDestroyedEffect.ReadString(reader);
        _shieldDamagedEffect.ReadString(reader);
        _shieldDepletedEffect.ReadString(reader);
        _shieldRechargingEffect.ReadString(reader);
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new DamageMaterialsBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new DamageRegionsBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modifiers.Count); x = (x + 1)) {
          Modifiers.Add(new DamageModifiersBlock());
          Modifiers[x].Read(reader);
        }
        for (x = 0; (x < _modifiers.Count); x = (x + 1)) {
          Modifiers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres.Add(new SphereBlock());
          PathfindingSpheres[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new NodeBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _indirectDamageMaterial.Write(bw);
        _unnamed.Write(bw);
        _maximumBodyVitality.Write(bw);
        _bodySystemShock.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _friendlyDamageResistance.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _localizedDamageEffect.Write(bw);
        _areaDamageEffectThreshold.Write(bw);
        _areaDamageEffect.Write(bw);
        _bodyDamagedThreshold.Write(bw);
        _bodyDamagedEffect.Write(bw);
        _bodyDepletedEffect.Write(bw);
        _bodyDestroyedThreshold.Write(bw);
        _bodyDestroyedEffect.Write(bw);
        _maximumShieldVitality.Write(bw);
        _unnamed6.Write(bw);
        _shieldMaterialType.Write(bw);
        _unnamed7.Write(bw);
        _shieldFailureFunction.Write(bw);
        _unnamed8.Write(bw);
        _shieldFailureThreshold.Write(bw);
        _failingShieldLeakFraction.Write(bw);
        _unnamed9.Write(bw);
        _minimumStunDamage.Write(bw);
        _stunTime.Write(bw);
        _rechargeTime.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _shieldDamagedThreshold.Write(bw);
        _shieldDamagedEffect.Write(bw);
        _shieldDepletedEffect.Write(bw);
        _shieldRechargingEffect.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_modifiers.Count = Modifiers.Count;
        _modifiers.Write(bw);
        _unnamed14.Write(bw);
        _x.Write(bw);
        _y.Write(bw);
        _z.Write(bw);
_pathfindingSpheres.Count = PathfindingSpheres.Count;
        _pathfindingSpheres.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _localizedDamageEffect.WriteString(writer);
        _areaDamageEffect.WriteString(writer);
        _bodyDamagedEffect.WriteString(writer);
        _bodyDepletedEffect.WriteString(writer);
        _bodyDestroyedEffect.WriteString(writer);
        _shieldDamagedEffect.WriteString(writer);
        _shieldDepletedEffect.WriteString(writer);
        _shieldRechargingEffect.WriteString(writer);
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modifiers.Count); x = (x + 1)) {
          Modifiers[x].Write(writer);
        }
        for (x = 0; (x < _modifiers.Count); x = (x + 1)) {
          Modifiers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingSpheres.Count); x = (x + 1)) {
          PathfindingSpheres[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
      }
    }
    public class DamageMaterialsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Enum _materialType = new Enum();
      private Pad _unnamed;
      private RealFraction _shieldLeakPercentage = new RealFraction();
      private Real _shieldDamageMultiplier = new Real();
      private Pad _unnamed2;
      private Real _bodyDamageMultiplier = new Real();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public DamageMaterialsBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Enum MaterialType {
        get {
          return this._materialType;
        }
        set {
          this._materialType = value;
        }
      }
      public RealFraction ShieldLeakPercentage {
        get {
          return this._shieldLeakPercentage;
        }
        set {
          this._shieldLeakPercentage = value;
        }
      }
      public Real ShieldDamageMultiplier {
        get {
          return this._shieldDamageMultiplier;
        }
        set {
          this._shieldDamageMultiplier = value;
        }
      }
      public Real BodyDamageMultiplier {
        get {
          return this._bodyDamageMultiplier;
        }
        set {
          this._bodyDamageMultiplier = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _materialType.Read(reader);
        _unnamed.Read(reader);
        _shieldLeakPercentage.Read(reader);
        _shieldDamageMultiplier.Read(reader);
        _unnamed2.Read(reader);
        _bodyDamageMultiplier.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _materialType.Write(bw);
        _unnamed.Write(bw);
        _shieldLeakPercentage.Write(bw);
        _shieldDamageMultiplier.Write(bw);
        _unnamed2.Write(bw);
        _bodyDamageMultiplier.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DamageRegionsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private Real _damageThreshold = new Real();
      private Pad _unnamed2;
      private TagReference _destroyedEffect = new TagReference();
      private Block _permutations = new Block();
      public BlockCollection<DamagePermutationsBlock> _permutationsList = new BlockCollection<DamagePermutationsBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageRegionsBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(12);
      }
      public BlockCollection<DamagePermutationsBlock> Permutations {
        get {
          return this._permutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_destroyedEffect.Value);
for (int x=0; x<Permutations.BlockCount; x++)
{
  IBlock block = Permutations.GetBlock(x);
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
      public Real DamageThreshold {
        get {
          return this._damageThreshold;
        }
        set {
          this._damageThreshold = value;
        }
      }
      public TagReference DestroyedEffect {
        get {
          return this._destroyedEffect;
        }
        set {
          this._destroyedEffect = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _damageThreshold.Read(reader);
        _unnamed2.Read(reader);
        _destroyedEffect.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _destroyedEffect.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new DamagePermutationsBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _damageThreshold.Write(bw);
        _unnamed2.Write(bw);
        _destroyedEffect.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _destroyedEffect.WriteString(writer);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class DamagePermutationsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public DamagePermutationsBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DamageModifiersBlock : IBlock {
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public DamageModifiersBlock() {
        this._unnamed = new Pad(52);
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
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SphereBlock : IBlock {
      private ShortBlockIndex _node = new ShortBlockIndex();
      private Pad _unnamed;
      private Pad _unnamed2;
      private RealPoint3D _center = new RealPoint3D();
      private Real _radius = new Real();
public event System.EventHandler BlockNameChanged;
      public SphereBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(12);
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
      public ShortBlockIndex Node {
        get {
          return this._node;
        }
        set {
          this._node = value;
        }
      }
      public RealPoint3D Center {
        get {
          return this._center;
        }
        set {
          this._center = value;
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
      public virtual void Read(BinaryReader reader) {
        _node.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _center.Read(reader);
        _radius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _node.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _center.Write(bw);
        _radius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class NodeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _region = new ShortBlockIndex();
      private ShortBlockIndex _parentNode = new ShortBlockIndex();
      private ShortBlockIndex _nextSiblingNode = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNode = new ShortBlockIndex();
      private Pad _unnamed;
      private Block _bsps = new Block();
      public BlockCollection<BspBlock> _bspsList = new BlockCollection<BspBlock>();
public event System.EventHandler BlockNameChanged;
      public NodeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(12);
      }
      public BlockCollection<BspBlock> Bsps {
        get {
          return this._bspsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bsps.BlockCount; x++)
{
  IBlock block = Bsps.GetBlock(x);
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
      public ShortBlockIndex Region {
        get {
          return this._region;
        }
        set {
          this._region = value;
        }
      }
      public ShortBlockIndex ParentNode {
        get {
          return this._parentNode;
        }
        set {
          this._parentNode = value;
        }
      }
      public ShortBlockIndex NextSiblingNode {
        get {
          return this._nextSiblingNode;
        }
        set {
          this._nextSiblingNode = value;
        }
      }
      public ShortBlockIndex FirstChildNode {
        get {
          return this._firstChildNode;
        }
        set {
          this._firstChildNode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _region.Read(reader);
        _parentNode.Read(reader);
        _nextSiblingNode.Read(reader);
        _firstChildNode.Read(reader);
        _unnamed.Read(reader);
        _bsps.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps.Add(new BspBlock());
          Bsps[x].Read(reader);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _region.Write(bw);
        _parentNode.Write(bw);
        _nextSiblingNode.Write(bw);
        _firstChildNode.Write(bw);
        _unnamed.Write(bw);
_bsps.Count = Bsps.Count;
        _bsps.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].Write(writer);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].WriteChildData(writer);
        }
      }
    }
    public class BspBlock : IBlock {
      private Block _bsp3dNodes = new Block();
      private Block _planes = new Block();
      private Block _leaves = new Block();
      private Block _bsp2dReferences = new Block();
      private Block _bsp2dNodes = new Block();
      private Block _surfaces = new Block();
      private Block _edges = new Block();
      private Block _vertices = new Block();
      public BlockCollection<Bsp3dnodeBlock> _bsp3dNodesList = new BlockCollection<Bsp3dnodeBlock>();
      public BlockCollection<PlaneBlock> _planesList = new BlockCollection<PlaneBlock>();
      public BlockCollection<LeafBlock> _leavesList = new BlockCollection<LeafBlock>();
      public BlockCollection<Bsp2dreferenceBlock> _bsp2dReferencesList = new BlockCollection<Bsp2dreferenceBlock>();
      public BlockCollection<Bsp2dnodeBlock> _bsp2dNodesList = new BlockCollection<Bsp2dnodeBlock>();
      public BlockCollection<SurfaceBlock> _surfacesList = new BlockCollection<SurfaceBlock>();
      public BlockCollection<EdgeBlock> _edgesList = new BlockCollection<EdgeBlock>();
      public BlockCollection<VertexBlock> _verticesList = new BlockCollection<VertexBlock>();
public event System.EventHandler BlockNameChanged;
      public BspBlock() {
      }
      public BlockCollection<Bsp3dnodeBlock> Bsp3dNodes {
        get {
          return this._bsp3dNodesList;
        }
      }
      public BlockCollection<PlaneBlock> Planes {
        get {
          return this._planesList;
        }
      }
      public BlockCollection<LeafBlock> Leaves {
        get {
          return this._leavesList;
        }
      }
      public BlockCollection<Bsp2dreferenceBlock> Bsp2dReferences {
        get {
          return this._bsp2dReferencesList;
        }
      }
      public BlockCollection<Bsp2dnodeBlock> Bsp2dNodes {
        get {
          return this._bsp2dNodesList;
        }
      }
      public BlockCollection<SurfaceBlock> Surfaces {
        get {
          return this._surfacesList;
        }
      }
      public BlockCollection<EdgeBlock> Edges {
        get {
          return this._edgesList;
        }
      }
      public BlockCollection<VertexBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bsp3dNodes.BlockCount; x++)
{
  IBlock block = Bsp3dNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Planes.BlockCount; x++)
{
  IBlock block = Planes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Leaves.BlockCount; x++)
{
  IBlock block = Leaves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bsp2dReferences.BlockCount; x++)
{
  IBlock block = Bsp2dReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bsp2dNodes.BlockCount; x++)
{
  IBlock block = Bsp2dNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Surfaces.BlockCount; x++)
{
  IBlock block = Surfaces.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Edges.BlockCount; x++)
{
  IBlock block = Edges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
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
      public virtual void Read(BinaryReader reader) {
        _bsp3dNodes.Read(reader);
        _planes.Read(reader);
        _leaves.Read(reader);
        _bsp2dReferences.Read(reader);
        _bsp2dNodes.Read(reader);
        _surfaces.Read(reader);
        _edges.Read(reader);
        _vertices.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes.Add(new Bsp3dnodeBlock());
          Bsp3dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes.Add(new PlaneBlock());
          Planes[x].Read(reader);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves.Add(new LeafBlock());
          Leaves[x].Read(reader);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences.Add(new Bsp2dreferenceBlock());
          Bsp2dReferences[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes.Add(new Bsp2dnodeBlock());
          Bsp2dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces.Add(new SurfaceBlock());
          Surfaces[x].Read(reader);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].ReadChildData(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges.Add(new EdgeBlock());
          Edges[x].Read(reader);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new VertexBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_bsp3dNodes.Count = Bsp3dNodes.Count;
        _bsp3dNodes.Write(bw);
_planes.Count = Planes.Count;
        _planes.Write(bw);
_leaves.Count = Leaves.Count;
        _leaves.Write(bw);
_bsp2dReferences.Count = Bsp2dReferences.Count;
        _bsp2dReferences.Write(bw);
_bsp2dNodes.Count = Bsp2dNodes.Count;
        _bsp2dNodes.Write(bw);
_surfaces.Count = Surfaces.Count;
        _surfaces.Write(bw);
_edges.Count = Edges.Count;
        _edges.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp3dNodes.Count); x = (x + 1)) {
          Bsp3dNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].Write(writer);
        }
        for (x = 0; (x < _planes.Count); x = (x + 1)) {
          Planes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].Write(writer);
        }
        for (x = 0; (x < _leaves.Count); x = (x + 1)) {
          Leaves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dReferences.Count); x = (x + 1)) {
          Bsp2dReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].Write(writer);
        }
        for (x = 0; (x < _surfaces.Count); x = (x + 1)) {
          Surfaces[x].WriteChildData(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].Write(writer);
        }
        for (x = 0; (x < _edges.Count); x = (x + 1)) {
          Edges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
      }
    }
    public class Bsp3dnodeBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _backChild = new LongInteger();
      private LongInteger _frontChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp3dnodeBlock() {
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger BackChild {
        get {
          return this._backChild;
        }
        set {
          this._backChild = value;
        }
      }
      public LongInteger FrontChild {
        get {
          return this._frontChild;
        }
        set {
          this._frontChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _backChild.Read(reader);
        _frontChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _backChild.Write(bw);
        _frontChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlaneBlock : IBlock {
      private RealPlane3D _plane = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public PlaneBlock() {
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
      public RealPlane3D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LeafBlock : IBlock {
      private Flags _flags;
      private ShortInteger _bsp2dReferenceCount = new ShortInteger();
      private LongInteger _firstBsp2dReference = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public LeafBlock() {
        this._flags = new Flags(2);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger Bsp2dReferenceCount {
        get {
          return this._bsp2dReferenceCount;
        }
        set {
          this._bsp2dReferenceCount = value;
        }
      }
      public LongInteger FirstBsp2dReference {
        get {
          return this._firstBsp2dReference;
        }
        set {
          this._firstBsp2dReference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _bsp2dReferenceCount.Read(reader);
        _firstBsp2dReference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _bsp2dReferenceCount.Write(bw);
        _firstBsp2dReference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dreferenceBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _bsp2dNode = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dreferenceBlock() {
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger Bsp2dNode {
        get {
          return this._bsp2dNode;
        }
        set {
          this._bsp2dNode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _bsp2dNode.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _bsp2dNode.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class Bsp2dnodeBlock : IBlock {
      private RealPlane2D _plane = new RealPlane2D();
      private LongInteger _leftChild = new LongInteger();
      private LongInteger _rightChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public Bsp2dnodeBlock() {
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
      public RealPlane2D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger LeftChild {
        get {
          return this._leftChild;
        }
        set {
          this._leftChild = value;
        }
      }
      public LongInteger RightChild {
        get {
          return this._rightChild;
        }
        set {
          this._rightChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _leftChild.Read(reader);
        _rightChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _leftChild.Write(bw);
        _rightChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SurfaceBlock : IBlock {
      private LongInteger _plane = new LongInteger();
      private LongInteger _firstEdge = new LongInteger();
      private Flags _flags;
      private CharInteger _breakableSurface = new CharInteger();
      private ShortInteger _material = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SurfaceBlock() {
        this._flags = new Flags(1);
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
      public LongInteger Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger FirstEdge {
        get {
          return this._firstEdge;
        }
        set {
          this._firstEdge = value;
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
      public CharInteger BreakableSurface {
        get {
          return this._breakableSurface;
        }
        set {
          this._breakableSurface = value;
        }
      }
      public ShortInteger Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _firstEdge.Read(reader);
        _flags.Read(reader);
        _breakableSurface.Read(reader);
        _material.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _firstEdge.Write(bw);
        _flags.Write(bw);
        _breakableSurface.Write(bw);
        _material.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EdgeBlock : IBlock {
      private LongInteger _startVertex = new LongInteger();
      private LongInteger _endVertex = new LongInteger();
      private LongInteger _forwardEdge = new LongInteger();
      private LongInteger _reverseEdge = new LongInteger();
      private LongInteger _leftSurface = new LongInteger();
      private LongInteger _rightSurface = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public EdgeBlock() {
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
      public LongInteger StartVertex {
        get {
          return this._startVertex;
        }
        set {
          this._startVertex = value;
        }
      }
      public LongInteger EndVertex {
        get {
          return this._endVertex;
        }
        set {
          this._endVertex = value;
        }
      }
      public LongInteger ForwardEdge {
        get {
          return this._forwardEdge;
        }
        set {
          this._forwardEdge = value;
        }
      }
      public LongInteger ReverseEdge {
        get {
          return this._reverseEdge;
        }
        set {
          this._reverseEdge = value;
        }
      }
      public LongInteger LeftSurface {
        get {
          return this._leftSurface;
        }
        set {
          this._leftSurface = value;
        }
      }
      public LongInteger RightSurface {
        get {
          return this._rightSurface;
        }
        set {
          this._rightSurface = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _startVertex.Read(reader);
        _endVertex.Read(reader);
        _forwardEdge.Read(reader);
        _reverseEdge.Read(reader);
        _leftSurface.Read(reader);
        _rightSurface.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _startVertex.Write(bw);
        _endVertex.Write(bw);
        _forwardEdge.Write(bw);
        _reverseEdge.Write(bw);
        _leftSurface.Write(bw);
        _rightSurface.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class VertexBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private LongInteger _firstEdge = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public VertexBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public LongInteger FirstEdge {
        get {
          return this._firstEdge;
        }
        set {
          this._firstEdge = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _firstEdge.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _firstEdge.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
