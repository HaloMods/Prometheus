// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'physics'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class physics : Interfaces.Pool.Tag {
    private PhysicsBlock physicsValues = new PhysicsBlock();
    public virtual PhysicsBlock PhysicsValues {
      get {
        return physicsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PhysicsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "physics";
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
physicsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
physicsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
physicsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
physicsValues.WriteChildData(writer);
    }
    #endregion
    public class PhysicsBlock : IBlock {
      private Real _radius = new Real();
      private RealFraction _momentScale = new RealFraction();
      private Real _mass = new Real();
      private RealPoint3D _centerOfMass = new RealPoint3D();
      private Real _density = new Real();
      private Real _gravityScale = new Real();
      private Real _groundFriction = new Real();
      private Real _groundDepth = new Real();
      private RealFraction _groundDampFraction = new RealFraction();
      private Real _groundNormalK1 = new Real();
      private Real _groundNormalK0 = new Real();
      private Pad _unnamed;
      private Real _waterFriction = new Real();
      private Real _waterDepth = new Real();
      private Real _waterDensity = new Real();
      private Pad _unnamed2;
      private RealFraction _airFriction = new RealFraction();
      private Pad _unnamed3;
      private Real _xxMoment = new Real();
      private Real _yyMoment = new Real();
      private Real _zzMoment = new Real();
      private Block _inertialMatrixAndInverse = new Block();
      private Block _poweredMassPoints = new Block();
      private Block _massPoints = new Block();
      public BlockCollection<InertialMatrixBlock> _inertialMatrixAndInverseList = new BlockCollection<InertialMatrixBlock>();
      public BlockCollection<PoweredMassPointBlock> _poweredMassPointsList = new BlockCollection<PoweredMassPointBlock>();
      public BlockCollection<MassPointBlock> _massPointsList = new BlockCollection<MassPointBlock>();
public event System.EventHandler BlockNameChanged;
      public PhysicsBlock() {
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
      }
      public BlockCollection<InertialMatrixBlock> InertialMatrixAndInverse {
        get {
          return this._inertialMatrixAndInverseList;
        }
      }
      public BlockCollection<PoweredMassPointBlock> PoweredMassPoints {
        get {
          return this._poweredMassPointsList;
        }
      }
      public BlockCollection<MassPointBlock> MassPoints {
        get {
          return this._massPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<InertialMatrixAndInverse.BlockCount; x++)
{
  IBlock block = InertialMatrixAndInverse.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PoweredMassPoints.BlockCount; x++)
{
  IBlock block = PoweredMassPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MassPoints.BlockCount; x++)
{
  IBlock block = MassPoints.GetBlock(x);
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
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealFraction MomentScale {
        get {
          return this._momentScale;
        }
        set {
          this._momentScale = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public RealPoint3D CenterOfMass {
        get {
          return this._centerOfMass;
        }
        set {
          this._centerOfMass = value;
        }
      }
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public Real GravityScale {
        get {
          return this._gravityScale;
        }
        set {
          this._gravityScale = value;
        }
      }
      public Real GroundFriction {
        get {
          return this._groundFriction;
        }
        set {
          this._groundFriction = value;
        }
      }
      public Real GroundDepth {
        get {
          return this._groundDepth;
        }
        set {
          this._groundDepth = value;
        }
      }
      public RealFraction GroundDampFraction {
        get {
          return this._groundDampFraction;
        }
        set {
          this._groundDampFraction = value;
        }
      }
      public Real GroundNormalK1 {
        get {
          return this._groundNormalK1;
        }
        set {
          this._groundNormalK1 = value;
        }
      }
      public Real GroundNormalK0 {
        get {
          return this._groundNormalK0;
        }
        set {
          this._groundNormalK0 = value;
        }
      }
      public Real WaterFriction {
        get {
          return this._waterFriction;
        }
        set {
          this._waterFriction = value;
        }
      }
      public Real WaterDepth {
        get {
          return this._waterDepth;
        }
        set {
          this._waterDepth = value;
        }
      }
      public Real WaterDensity {
        get {
          return this._waterDensity;
        }
        set {
          this._waterDensity = value;
        }
      }
      public RealFraction AirFriction {
        get {
          return this._airFriction;
        }
        set {
          this._airFriction = value;
        }
      }
      public Real XxMoment {
        get {
          return this._xxMoment;
        }
        set {
          this._xxMoment = value;
        }
      }
      public Real YyMoment {
        get {
          return this._yyMoment;
        }
        set {
          this._yyMoment = value;
        }
      }
      public Real ZzMoment {
        get {
          return this._zzMoment;
        }
        set {
          this._zzMoment = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _radius.Read(reader);
        _momentScale.Read(reader);
        _mass.Read(reader);
        _centerOfMass.Read(reader);
        _density.Read(reader);
        _gravityScale.Read(reader);
        _groundFriction.Read(reader);
        _groundDepth.Read(reader);
        _groundDampFraction.Read(reader);
        _groundNormalK1.Read(reader);
        _groundNormalK0.Read(reader);
        _unnamed.Read(reader);
        _waterFriction.Read(reader);
        _waterDepth.Read(reader);
        _waterDensity.Read(reader);
        _unnamed2.Read(reader);
        _airFriction.Read(reader);
        _unnamed3.Read(reader);
        _xxMoment.Read(reader);
        _yyMoment.Read(reader);
        _zzMoment.Read(reader);
        _inertialMatrixAndInverse.Read(reader);
        _poweredMassPoints.Read(reader);
        _massPoints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _inertialMatrixAndInverse.Count); x = (x + 1)) {
          InertialMatrixAndInverse.Add(new InertialMatrixBlock());
          InertialMatrixAndInverse[x].Read(reader);
        }
        for (x = 0; (x < _inertialMatrixAndInverse.Count); x = (x + 1)) {
          InertialMatrixAndInverse[x].ReadChildData(reader);
        }
        for (x = 0; (x < _poweredMassPoints.Count); x = (x + 1)) {
          PoweredMassPoints.Add(new PoweredMassPointBlock());
          PoweredMassPoints[x].Read(reader);
        }
        for (x = 0; (x < _poweredMassPoints.Count); x = (x + 1)) {
          PoweredMassPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _massPoints.Count); x = (x + 1)) {
          MassPoints.Add(new MassPointBlock());
          MassPoints[x].Read(reader);
        }
        for (x = 0; (x < _massPoints.Count); x = (x + 1)) {
          MassPoints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _radius.Write(bw);
        _momentScale.Write(bw);
        _mass.Write(bw);
        _centerOfMass.Write(bw);
        _density.Write(bw);
        _gravityScale.Write(bw);
        _groundFriction.Write(bw);
        _groundDepth.Write(bw);
        _groundDampFraction.Write(bw);
        _groundNormalK1.Write(bw);
        _groundNormalK0.Write(bw);
        _unnamed.Write(bw);
        _waterFriction.Write(bw);
        _waterDepth.Write(bw);
        _waterDensity.Write(bw);
        _unnamed2.Write(bw);
        _airFriction.Write(bw);
        _unnamed3.Write(bw);
        _xxMoment.Write(bw);
        _yyMoment.Write(bw);
        _zzMoment.Write(bw);
_inertialMatrixAndInverse.Count = InertialMatrixAndInverse.Count;
        _inertialMatrixAndInverse.Write(bw);
_poweredMassPoints.Count = PoweredMassPoints.Count;
        _poweredMassPoints.Write(bw);
_massPoints.Count = MassPoints.Count;
        _massPoints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _inertialMatrixAndInverse.Count); x = (x + 1)) {
          InertialMatrixAndInverse[x].Write(writer);
        }
        for (x = 0; (x < _inertialMatrixAndInverse.Count); x = (x + 1)) {
          InertialMatrixAndInverse[x].WriteChildData(writer);
        }
        for (x = 0; (x < _poweredMassPoints.Count); x = (x + 1)) {
          PoweredMassPoints[x].Write(writer);
        }
        for (x = 0; (x < _poweredMassPoints.Count); x = (x + 1)) {
          PoweredMassPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _massPoints.Count); x = (x + 1)) {
          MassPoints[x].Write(writer);
        }
        for (x = 0; (x < _massPoints.Count); x = (x + 1)) {
          MassPoints[x].WriteChildData(writer);
        }
      }
    }
    public class InertialMatrixBlock : IBlock {
      private RealVector3D _yy_Pluszz = new RealVector3D();
      private RealVector3D _unnamed = new RealVector3D();
      private RealVector3D _unnamed2 = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public InertialMatrixBlock() {
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
      public RealVector3D Yy_Pluszz {
        get {
          return this._yy_Pluszz;
        }
        set {
          this._yy_Pluszz = value;
        }
      }
      public RealVector3D unnamed {
        get {
          return this._unnamed;
        }
        set {
          this._unnamed = value;
        }
      }
      public RealVector3D unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _yy_Pluszz.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _yy_Pluszz.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PoweredMassPointBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Real _antigravStrength = new Real();
      private Real _antigravOffset = new Real();
      private Real _antigravHeight = new Real();
      private Real _antigravDampFraction = new Real();
      private Real _antigravNormalK1 = new Real();
      private Real _antigravNormalK0 = new Real();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public PoweredMassPointBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(68);
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
      public Real AntigravStrength {
        get {
          return this._antigravStrength;
        }
        set {
          this._antigravStrength = value;
        }
      }
      public Real AntigravOffset {
        get {
          return this._antigravOffset;
        }
        set {
          this._antigravOffset = value;
        }
      }
      public Real AntigravHeight {
        get {
          return this._antigravHeight;
        }
        set {
          this._antigravHeight = value;
        }
      }
      public Real AntigravDampFraction {
        get {
          return this._antigravDampFraction;
        }
        set {
          this._antigravDampFraction = value;
        }
      }
      public Real AntigravNormalK1 {
        get {
          return this._antigravNormalK1;
        }
        set {
          this._antigravNormalK1 = value;
        }
      }
      public Real AntigravNormalK0 {
        get {
          return this._antigravNormalK0;
        }
        set {
          this._antigravNormalK0 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _antigravStrength.Read(reader);
        _antigravOffset.Read(reader);
        _antigravHeight.Read(reader);
        _antigravDampFraction.Read(reader);
        _antigravNormalK1.Read(reader);
        _antigravNormalK0.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _antigravStrength.Write(bw);
        _antigravOffset.Write(bw);
        _antigravHeight.Write(bw);
        _antigravDampFraction.Write(bw);
        _antigravNormalK1.Write(bw);
        _antigravNormalK0.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MassPointBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _poweredMassPoint = new ShortBlockIndex();
      private ShortInteger _modelNode = new ShortInteger();
      private Flags _flags;
      private Real _relativeMass = new Real();
      private Real _mass = new Real();
      private Real _relativeDensity = new Real();
      private Real _density = new Real();
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _forward = new RealVector3D();
      private RealVector3D _up = new RealVector3D();
      private Enum _frictionType = new Enum();
      private Pad _unnamed;
      private Real _frictionParallelScale = new Real();
      private Real _frictionPerpendicularScale = new Real();
      private Real _radius = new Real();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public MassPointBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(20);
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
      public ShortBlockIndex PoweredMassPoint {
        get {
          return this._poweredMassPoint;
        }
        set {
          this._poweredMassPoint = value;
        }
      }
      public ShortInteger ModelNode {
        get {
          return this._modelNode;
        }
        set {
          this._modelNode = value;
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
      public Real RelativeMass {
        get {
          return this._relativeMass;
        }
        set {
          this._relativeMass = value;
        }
      }
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public Real RelativeDensity {
        get {
          return this._relativeDensity;
        }
        set {
          this._relativeDensity = value;
        }
      }
      public Real Density {
        get {
          return this._density;
        }
        set {
          this._density = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealVector3D Forward {
        get {
          return this._forward;
        }
        set {
          this._forward = value;
        }
      }
      public RealVector3D Up {
        get {
          return this._up;
        }
        set {
          this._up = value;
        }
      }
      public Enum FrictionType {
        get {
          return this._frictionType;
        }
        set {
          this._frictionType = value;
        }
      }
      public Real FrictionParallelScale {
        get {
          return this._frictionParallelScale;
        }
        set {
          this._frictionParallelScale = value;
        }
      }
      public Real FrictionPerpendicularScale {
        get {
          return this._frictionPerpendicularScale;
        }
        set {
          this._frictionPerpendicularScale = value;
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
        _name.Read(reader);
        _poweredMassPoint.Read(reader);
        _modelNode.Read(reader);
        _flags.Read(reader);
        _relativeMass.Read(reader);
        _mass.Read(reader);
        _relativeDensity.Read(reader);
        _density.Read(reader);
        _position.Read(reader);
        _forward.Read(reader);
        _up.Read(reader);
        _frictionType.Read(reader);
        _unnamed.Read(reader);
        _frictionParallelScale.Read(reader);
        _frictionPerpendicularScale.Read(reader);
        _radius.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _poweredMassPoint.Write(bw);
        _modelNode.Write(bw);
        _flags.Write(bw);
        _relativeMass.Write(bw);
        _mass.Write(bw);
        _relativeDensity.Write(bw);
        _density.Write(bw);
        _position.Write(bw);
        _forward.Write(bw);
        _up.Write(bw);
        _frictionType.Write(bw);
        _unnamed.Write(bw);
        _frictionParallelScale.Write(bw);
        _frictionPerpendicularScale.Write(bw);
        _radius.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
