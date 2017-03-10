// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'physics_model'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class physics_model : Interfaces.Pool.Tag {
    private PhysicsModelBlockBlock physicsModelValues = new PhysicsModelBlockBlock();
    public virtual PhysicsModelBlockBlock PhysicsModelValues {
      get {
        return physicsModelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PhysicsModelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "physics_model";
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
physicsModelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
physicsModelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
physicsModelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
physicsModelValues.WriteChildData(writer);
    }
    #endregion
    public class PhysicsModelBlockBlock : IBlock {
      private Flags _flags;
      private Real _mass = new Real();
      private Real _lowFreqDeactivationScale = new Real();
      private Real _highFreqDeactivationScale = new Real();
      private Pad _unnamed0;
      private Block _phantomTypes = new Block();
      private Block _nodeEdges = new Block();
      private Block _rigidBodies = new Block();
      private Block _materials = new Block();
      private Block _spheres = new Block();
      private Block _multiSpheres = new Block();
      private Block _pills = new Block();
      private Block _boxes = new Block();
      private Block _triangles = new Block();
      private Block _polyhedra = new Block();
      private Block _polyhedronFourVectors = new Block();
      private Block _polyhedronPlaneEquations = new Block();
      private Block _massDistributions = new Block();
      private Block _lists = new Block();
      private Block _listShapes = new Block();
      private Block _mopps = new Block();
      private Data _moppCodes = new Data();
      private Block _hingeConstraints = new Block();
      private Block _ragdollConstraints = new Block();
      private Block _regions = new Block();
      private Block _nodes = new Block();
      private Block _importInfo = new Block();
      private Block _errors = new Block();
      private Block _pointToPathCurves = new Block();
      private Block _limitedHingeConstraints = new Block();
      private Block _ballAndSocketConstraints = new Block();
      private Block _stiffSpringConstraints = new Block();
      private Block _prismaticConstraints = new Block();
      private Block _phantoms = new Block();
      public BlockCollection<PhantomTypesBlockBlock> _phantomTypesList = new BlockCollection<PhantomTypesBlockBlock>();
      public BlockCollection<PhysicsModelNodeConstraintEdgeBlockBlock> _nodeEdgesList = new BlockCollection<PhysicsModelNodeConstraintEdgeBlockBlock>();
      public BlockCollection<RigidBodiesBlockBlock> _rigidBodiesList = new BlockCollection<RigidBodiesBlockBlock>();
      public BlockCollection<MaterialsBlockBlock> _materialsList = new BlockCollection<MaterialsBlockBlock>();
      public BlockCollection<SpheresBlockBlock> _spheresList = new BlockCollection<SpheresBlockBlock>();
      public BlockCollection<MultiSpheresBlockBlock> _multiSpheresList = new BlockCollection<MultiSpheresBlockBlock>();
      public BlockCollection<PillsBlockBlock> _pillsList = new BlockCollection<PillsBlockBlock>();
      public BlockCollection<BoxesBlockBlock> _boxesList = new BlockCollection<BoxesBlockBlock>();
      public BlockCollection<TrianglesBlockBlock> _trianglesList = new BlockCollection<TrianglesBlockBlock>();
      public BlockCollection<PolyhedraBlockBlock> _polyhedraList = new BlockCollection<PolyhedraBlockBlock>();
      public BlockCollection<PolyhedronFourVectorsBlockBlock> _polyhedronFourVectorsList = new BlockCollection<PolyhedronFourVectorsBlockBlock>();
      public BlockCollection<PolyhedronPlaneEquationsBlockBlock> _polyhedronPlaneEquationsList = new BlockCollection<PolyhedronPlaneEquationsBlockBlock>();
      public BlockCollection<MassDistributionsBlockBlock> _massDistributionsList = new BlockCollection<MassDistributionsBlockBlock>();
      public BlockCollection<ListsBlockBlock> _listsList = new BlockCollection<ListsBlockBlock>();
      public BlockCollection<ListShapesBlockBlock> _listShapesList = new BlockCollection<ListShapesBlockBlock>();
      public BlockCollection<MoppsBlockBlock> _moppsList = new BlockCollection<MoppsBlockBlock>();
      public BlockCollection<HingeConstraintsBlockBlock> _hingeConstraintsList = new BlockCollection<HingeConstraintsBlockBlock>();
      public BlockCollection<RagdollConstraintsBlockBlock> _ragdollConstraintsList = new BlockCollection<RagdollConstraintsBlockBlock>();
      public BlockCollection<RegionsBlockBlock> _regionsList = new BlockCollection<RegionsBlockBlock>();
      public BlockCollection<NodesBlockBlock> _nodesList = new BlockCollection<NodesBlockBlock>();
      public BlockCollection<GlobalTagImportInfoBlockBlock> _importInfoList = new BlockCollection<GlobalTagImportInfoBlockBlock>();
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> _errorsList = new BlockCollection<GlobalErrorReportCategoriesBlockBlock>();
      public BlockCollection<PointToPathCurveBlockBlock> _pointToPathCurvesList = new BlockCollection<PointToPathCurveBlockBlock>();
      public BlockCollection<LimitedHingeConstraintsBlockBlock> _limitedHingeConstraintsList = new BlockCollection<LimitedHingeConstraintsBlockBlock>();
      public BlockCollection<BallAndSocketConstraintsBlockBlock> _ballAndSocketConstraintsList = new BlockCollection<BallAndSocketConstraintsBlockBlock>();
      public BlockCollection<StiffSpringConstraintsBlockBlock> _stiffSpringConstraintsList = new BlockCollection<StiffSpringConstraintsBlockBlock>();
      public BlockCollection<PrismaticConstraintsBlockBlock> _prismaticConstraintsList = new BlockCollection<PrismaticConstraintsBlockBlock>();
      public BlockCollection<PhantomsBlockBlock> _phantomsList = new BlockCollection<PhantomsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PhysicsModelBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(24);
      }
      public BlockCollection<PhantomTypesBlockBlock> PhantomTypes {
        get {
          return this._phantomTypesList;
        }
      }
      public BlockCollection<PhysicsModelNodeConstraintEdgeBlockBlock> NodeEdges {
        get {
          return this._nodeEdgesList;
        }
      }
      public BlockCollection<RigidBodiesBlockBlock> RigidBodies {
        get {
          return this._rigidBodiesList;
        }
      }
      public BlockCollection<MaterialsBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<SpheresBlockBlock> Spheres {
        get {
          return this._spheresList;
        }
      }
      public BlockCollection<MultiSpheresBlockBlock> MultiSpheres {
        get {
          return this._multiSpheresList;
        }
      }
      public BlockCollection<PillsBlockBlock> Pills {
        get {
          return this._pillsList;
        }
      }
      public BlockCollection<BoxesBlockBlock> Boxes {
        get {
          return this._boxesList;
        }
      }
      public BlockCollection<TrianglesBlockBlock> Triangles {
        get {
          return this._trianglesList;
        }
      }
      public BlockCollection<PolyhedraBlockBlock> Polyhedra {
        get {
          return this._polyhedraList;
        }
      }
      public BlockCollection<PolyhedronFourVectorsBlockBlock> PolyhedronFourVectors {
        get {
          return this._polyhedronFourVectorsList;
        }
      }
      public BlockCollection<PolyhedronPlaneEquationsBlockBlock> PolyhedronPlaneEquations {
        get {
          return this._polyhedronPlaneEquationsList;
        }
      }
      public BlockCollection<MassDistributionsBlockBlock> MassDistributions {
        get {
          return this._massDistributionsList;
        }
      }
      public BlockCollection<ListsBlockBlock> Lists {
        get {
          return this._listsList;
        }
      }
      public BlockCollection<ListShapesBlockBlock> ListShapes {
        get {
          return this._listShapesList;
        }
      }
      public BlockCollection<MoppsBlockBlock> Mopps {
        get {
          return this._moppsList;
        }
      }
      public BlockCollection<HingeConstraintsBlockBlock> HingeConstraints {
        get {
          return this._hingeConstraintsList;
        }
      }
      public BlockCollection<RagdollConstraintsBlockBlock> RagdollConstraints {
        get {
          return this._ragdollConstraintsList;
        }
      }
      public BlockCollection<RegionsBlockBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<NodesBlockBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<GlobalTagImportInfoBlockBlock> ImportInfo {
        get {
          return this._importInfoList;
        }
      }
      public BlockCollection<GlobalErrorReportCategoriesBlockBlock> Errors {
        get {
          return this._errorsList;
        }
      }
      public BlockCollection<PointToPathCurveBlockBlock> PointToPathCurves {
        get {
          return this._pointToPathCurvesList;
        }
      }
      public BlockCollection<LimitedHingeConstraintsBlockBlock> LimitedHingeConstraints {
        get {
          return this._limitedHingeConstraintsList;
        }
      }
      public BlockCollection<BallAndSocketConstraintsBlockBlock> BallAndSocketConstraints {
        get {
          return this._ballAndSocketConstraintsList;
        }
      }
      public BlockCollection<StiffSpringConstraintsBlockBlock> StiffSpringConstraints {
        get {
          return this._stiffSpringConstraintsList;
        }
      }
      public BlockCollection<PrismaticConstraintsBlockBlock> PrismaticConstraints {
        get {
          return this._prismaticConstraintsList;
        }
      }
      public BlockCollection<PhantomsBlockBlock> Phantoms {
        get {
          return this._phantomsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PhantomTypes.BlockCount; x++)
{
  IBlock block = PhantomTypes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NodeEdges.BlockCount; x++)
{
  IBlock block = NodeEdges.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RigidBodies.BlockCount; x++)
{
  IBlock block = RigidBodies.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Spheres.BlockCount; x++)
{
  IBlock block = Spheres.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MultiSpheres.BlockCount; x++)
{
  IBlock block = MultiSpheres.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Pills.BlockCount; x++)
{
  IBlock block = Pills.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Boxes.BlockCount; x++)
{
  IBlock block = Boxes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Triangles.BlockCount; x++)
{
  IBlock block = Triangles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Polyhedra.BlockCount; x++)
{
  IBlock block = Polyhedra.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PolyhedronFourVectors.BlockCount; x++)
{
  IBlock block = PolyhedronFourVectors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PolyhedronPlaneEquations.BlockCount; x++)
{
  IBlock block = PolyhedronPlaneEquations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MassDistributions.BlockCount; x++)
{
  IBlock block = MassDistributions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lists.BlockCount; x++)
{
  IBlock block = Lists.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ListShapes.BlockCount; x++)
{
  IBlock block = ListShapes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Mopps.BlockCount; x++)
{
  IBlock block = Mopps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HingeConstraints.BlockCount; x++)
{
  IBlock block = HingeConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RagdollConstraints.BlockCount; x++)
{
  IBlock block = RagdollConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ImportInfo.BlockCount; x++)
{
  IBlock block = ImportInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Errors.BlockCount; x++)
{
  IBlock block = Errors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PointToPathCurves.BlockCount; x++)
{
  IBlock block = PointToPathCurves.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LimitedHingeConstraints.BlockCount; x++)
{
  IBlock block = LimitedHingeConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BallAndSocketConstraints.BlockCount; x++)
{
  IBlock block = BallAndSocketConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StiffSpringConstraints.BlockCount; x++)
{
  IBlock block = StiffSpringConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PrismaticConstraints.BlockCount; x++)
{
  IBlock block = PrismaticConstraints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Phantoms.BlockCount; x++)
{
  IBlock block = Phantoms.GetBlock(x);
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
      public Real Mass {
        get {
          return this._mass;
        }
        set {
          this._mass = value;
        }
      }
      public Real LowFreqDeactivationScale {
        get {
          return this._lowFreqDeactivationScale;
        }
        set {
          this._lowFreqDeactivationScale = value;
        }
      }
      public Real HighFreqDeactivationScale {
        get {
          return this._highFreqDeactivationScale;
        }
        set {
          this._highFreqDeactivationScale = value;
        }
      }
      public Data MoppCodes {
        get {
          return this._moppCodes;
        }
        set {
          this._moppCodes = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _mass.Read(reader);
        _lowFreqDeactivationScale.Read(reader);
        _highFreqDeactivationScale.Read(reader);
        _unnamed0.Read(reader);
        _phantomTypes.Read(reader);
        _nodeEdges.Read(reader);
        _rigidBodies.Read(reader);
        _materials.Read(reader);
        _spheres.Read(reader);
        _multiSpheres.Read(reader);
        _pills.Read(reader);
        _boxes.Read(reader);
        _triangles.Read(reader);
        _polyhedra.Read(reader);
        _polyhedronFourVectors.Read(reader);
        _polyhedronPlaneEquations.Read(reader);
        _massDistributions.Read(reader);
        _lists.Read(reader);
        _listShapes.Read(reader);
        _mopps.Read(reader);
        _moppCodes.Read(reader);
        _hingeConstraints.Read(reader);
        _ragdollConstraints.Read(reader);
        _regions.Read(reader);
        _nodes.Read(reader);
        _importInfo.Read(reader);
        _errors.Read(reader);
        _pointToPathCurves.Read(reader);
        _limitedHingeConstraints.Read(reader);
        _ballAndSocketConstraints.Read(reader);
        _stiffSpringConstraints.Read(reader);
        _prismaticConstraints.Read(reader);
        _phantoms.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _phantomTypes.Count); x = (x + 1)) {
          PhantomTypes.Add(new PhantomTypesBlockBlock());
          PhantomTypes[x].Read(reader);
        }
        for (x = 0; (x < _phantomTypes.Count); x = (x + 1)) {
          PhantomTypes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodeEdges.Count); x = (x + 1)) {
          NodeEdges.Add(new PhysicsModelNodeConstraintEdgeBlockBlock());
          NodeEdges[x].Read(reader);
        }
        for (x = 0; (x < _nodeEdges.Count); x = (x + 1)) {
          NodeEdges[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies.Add(new RigidBodiesBlockBlock());
          RigidBodies[x].Read(reader);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new MaterialsBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spheres.Count); x = (x + 1)) {
          Spheres.Add(new SpheresBlockBlock());
          Spheres[x].Read(reader);
        }
        for (x = 0; (x < _spheres.Count); x = (x + 1)) {
          Spheres[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiSpheres.Count); x = (x + 1)) {
          MultiSpheres.Add(new MultiSpheresBlockBlock());
          MultiSpheres[x].Read(reader);
        }
        for (x = 0; (x < _multiSpheres.Count); x = (x + 1)) {
          MultiSpheres[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pills.Count); x = (x + 1)) {
          Pills.Add(new PillsBlockBlock());
          Pills[x].Read(reader);
        }
        for (x = 0; (x < _pills.Count); x = (x + 1)) {
          Pills[x].ReadChildData(reader);
        }
        for (x = 0; (x < _boxes.Count); x = (x + 1)) {
          Boxes.Add(new BoxesBlockBlock());
          Boxes[x].Read(reader);
        }
        for (x = 0; (x < _boxes.Count); x = (x + 1)) {
          Boxes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles.Add(new TrianglesBlockBlock());
          Triangles[x].Read(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _polyhedra.Count); x = (x + 1)) {
          Polyhedra.Add(new PolyhedraBlockBlock());
          Polyhedra[x].Read(reader);
        }
        for (x = 0; (x < _polyhedra.Count); x = (x + 1)) {
          Polyhedra[x].ReadChildData(reader);
        }
        for (x = 0; (x < _polyhedronFourVectors.Count); x = (x + 1)) {
          PolyhedronFourVectors.Add(new PolyhedronFourVectorsBlockBlock());
          PolyhedronFourVectors[x].Read(reader);
        }
        for (x = 0; (x < _polyhedronFourVectors.Count); x = (x + 1)) {
          PolyhedronFourVectors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _polyhedronPlaneEquations.Count); x = (x + 1)) {
          PolyhedronPlaneEquations.Add(new PolyhedronPlaneEquationsBlockBlock());
          PolyhedronPlaneEquations[x].Read(reader);
        }
        for (x = 0; (x < _polyhedronPlaneEquations.Count); x = (x + 1)) {
          PolyhedronPlaneEquations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _massDistributions.Count); x = (x + 1)) {
          MassDistributions.Add(new MassDistributionsBlockBlock());
          MassDistributions[x].Read(reader);
        }
        for (x = 0; (x < _massDistributions.Count); x = (x + 1)) {
          MassDistributions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lists.Count); x = (x + 1)) {
          Lists.Add(new ListsBlockBlock());
          Lists[x].Read(reader);
        }
        for (x = 0; (x < _lists.Count); x = (x + 1)) {
          Lists[x].ReadChildData(reader);
        }
        for (x = 0; (x < _listShapes.Count); x = (x + 1)) {
          ListShapes.Add(new ListShapesBlockBlock());
          ListShapes[x].Read(reader);
        }
        for (x = 0; (x < _listShapes.Count); x = (x + 1)) {
          ListShapes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _mopps.Count); x = (x + 1)) {
          Mopps.Add(new MoppsBlockBlock());
          Mopps[x].Read(reader);
        }
        for (x = 0; (x < _mopps.Count); x = (x + 1)) {
          Mopps[x].ReadChildData(reader);
        }
        _moppCodes.ReadBinary(reader);
        for (x = 0; (x < _hingeConstraints.Count); x = (x + 1)) {
          HingeConstraints.Add(new HingeConstraintsBlockBlock());
          HingeConstraints[x].Read(reader);
        }
        for (x = 0; (x < _hingeConstraints.Count); x = (x + 1)) {
          HingeConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ragdollConstraints.Count); x = (x + 1)) {
          RagdollConstraints.Add(new RagdollConstraintsBlockBlock());
          RagdollConstraints[x].Read(reader);
        }
        for (x = 0; (x < _ragdollConstraints.Count); x = (x + 1)) {
          RagdollConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new RegionsBlockBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new NodesBlockBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo.Add(new GlobalTagImportInfoBlockBlock());
          ImportInfo[x].Read(reader);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors.Add(new GlobalErrorReportCategoriesBlockBlock());
          Errors[x].Read(reader);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pointToPathCurves.Count); x = (x + 1)) {
          PointToPathCurves.Add(new PointToPathCurveBlockBlock());
          PointToPathCurves[x].Read(reader);
        }
        for (x = 0; (x < _pointToPathCurves.Count); x = (x + 1)) {
          PointToPathCurves[x].ReadChildData(reader);
        }
        for (x = 0; (x < _limitedHingeConstraints.Count); x = (x + 1)) {
          LimitedHingeConstraints.Add(new LimitedHingeConstraintsBlockBlock());
          LimitedHingeConstraints[x].Read(reader);
        }
        for (x = 0; (x < _limitedHingeConstraints.Count); x = (x + 1)) {
          LimitedHingeConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ballAndSocketConstraints.Count); x = (x + 1)) {
          BallAndSocketConstraints.Add(new BallAndSocketConstraintsBlockBlock());
          BallAndSocketConstraints[x].Read(reader);
        }
        for (x = 0; (x < _ballAndSocketConstraints.Count); x = (x + 1)) {
          BallAndSocketConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stiffSpringConstraints.Count); x = (x + 1)) {
          StiffSpringConstraints.Add(new StiffSpringConstraintsBlockBlock());
          StiffSpringConstraints[x].Read(reader);
        }
        for (x = 0; (x < _stiffSpringConstraints.Count); x = (x + 1)) {
          StiffSpringConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _prismaticConstraints.Count); x = (x + 1)) {
          PrismaticConstraints.Add(new PrismaticConstraintsBlockBlock());
          PrismaticConstraints[x].Read(reader);
        }
        for (x = 0; (x < _prismaticConstraints.Count); x = (x + 1)) {
          PrismaticConstraints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _phantoms.Count); x = (x + 1)) {
          Phantoms.Add(new PhantomsBlockBlock());
          Phantoms[x].Read(reader);
        }
        for (x = 0; (x < _phantoms.Count); x = (x + 1)) {
          Phantoms[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _mass.Write(bw);
        _lowFreqDeactivationScale.Write(bw);
        _highFreqDeactivationScale.Write(bw);
        _unnamed0.Write(bw);
_phantomTypes.Count = PhantomTypes.Count;
        _phantomTypes.Write(bw);
_nodeEdges.Count = NodeEdges.Count;
        _nodeEdges.Write(bw);
_rigidBodies.Count = RigidBodies.Count;
        _rigidBodies.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_spheres.Count = Spheres.Count;
        _spheres.Write(bw);
_multiSpheres.Count = MultiSpheres.Count;
        _multiSpheres.Write(bw);
_pills.Count = Pills.Count;
        _pills.Write(bw);
_boxes.Count = Boxes.Count;
        _boxes.Write(bw);
_triangles.Count = Triangles.Count;
        _triangles.Write(bw);
_polyhedra.Count = Polyhedra.Count;
        _polyhedra.Write(bw);
_polyhedronFourVectors.Count = PolyhedronFourVectors.Count;
        _polyhedronFourVectors.Write(bw);
_polyhedronPlaneEquations.Count = PolyhedronPlaneEquations.Count;
        _polyhedronPlaneEquations.Write(bw);
_massDistributions.Count = MassDistributions.Count;
        _massDistributions.Write(bw);
_lists.Count = Lists.Count;
        _lists.Write(bw);
_listShapes.Count = ListShapes.Count;
        _listShapes.Write(bw);
_mopps.Count = Mopps.Count;
        _mopps.Write(bw);
        _moppCodes.Write(bw);
_hingeConstraints.Count = HingeConstraints.Count;
        _hingeConstraints.Write(bw);
_ragdollConstraints.Count = RagdollConstraints.Count;
        _ragdollConstraints.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
_importInfo.Count = ImportInfo.Count;
        _importInfo.Write(bw);
_errors.Count = Errors.Count;
        _errors.Write(bw);
_pointToPathCurves.Count = PointToPathCurves.Count;
        _pointToPathCurves.Write(bw);
_limitedHingeConstraints.Count = LimitedHingeConstraints.Count;
        _limitedHingeConstraints.Write(bw);
_ballAndSocketConstraints.Count = BallAndSocketConstraints.Count;
        _ballAndSocketConstraints.Write(bw);
_stiffSpringConstraints.Count = StiffSpringConstraints.Count;
        _stiffSpringConstraints.Write(bw);
_prismaticConstraints.Count = PrismaticConstraints.Count;
        _prismaticConstraints.Write(bw);
_phantoms.Count = Phantoms.Count;
        _phantoms.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _phantomTypes.Count); x = (x + 1)) {
          PhantomTypes[x].Write(writer);
        }
        for (x = 0; (x < _phantomTypes.Count); x = (x + 1)) {
          PhantomTypes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodeEdges.Count); x = (x + 1)) {
          NodeEdges[x].Write(writer);
        }
        for (x = 0; (x < _nodeEdges.Count); x = (x + 1)) {
          NodeEdges[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].Write(writer);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spheres.Count); x = (x + 1)) {
          Spheres[x].Write(writer);
        }
        for (x = 0; (x < _spheres.Count); x = (x + 1)) {
          Spheres[x].WriteChildData(writer);
        }
        for (x = 0; (x < _multiSpheres.Count); x = (x + 1)) {
          MultiSpheres[x].Write(writer);
        }
        for (x = 0; (x < _multiSpheres.Count); x = (x + 1)) {
          MultiSpheres[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pills.Count); x = (x + 1)) {
          Pills[x].Write(writer);
        }
        for (x = 0; (x < _pills.Count); x = (x + 1)) {
          Pills[x].WriteChildData(writer);
        }
        for (x = 0; (x < _boxes.Count); x = (x + 1)) {
          Boxes[x].Write(writer);
        }
        for (x = 0; (x < _boxes.Count); x = (x + 1)) {
          Boxes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].Write(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _polyhedra.Count); x = (x + 1)) {
          Polyhedra[x].Write(writer);
        }
        for (x = 0; (x < _polyhedra.Count); x = (x + 1)) {
          Polyhedra[x].WriteChildData(writer);
        }
        for (x = 0; (x < _polyhedronFourVectors.Count); x = (x + 1)) {
          PolyhedronFourVectors[x].Write(writer);
        }
        for (x = 0; (x < _polyhedronFourVectors.Count); x = (x + 1)) {
          PolyhedronFourVectors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _polyhedronPlaneEquations.Count); x = (x + 1)) {
          PolyhedronPlaneEquations[x].Write(writer);
        }
        for (x = 0; (x < _polyhedronPlaneEquations.Count); x = (x + 1)) {
          PolyhedronPlaneEquations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _massDistributions.Count); x = (x + 1)) {
          MassDistributions[x].Write(writer);
        }
        for (x = 0; (x < _massDistributions.Count); x = (x + 1)) {
          MassDistributions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lists.Count); x = (x + 1)) {
          Lists[x].Write(writer);
        }
        for (x = 0; (x < _lists.Count); x = (x + 1)) {
          Lists[x].WriteChildData(writer);
        }
        for (x = 0; (x < _listShapes.Count); x = (x + 1)) {
          ListShapes[x].Write(writer);
        }
        for (x = 0; (x < _listShapes.Count); x = (x + 1)) {
          ListShapes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _mopps.Count); x = (x + 1)) {
          Mopps[x].Write(writer);
        }
        for (x = 0; (x < _mopps.Count); x = (x + 1)) {
          Mopps[x].WriteChildData(writer);
        }
        _moppCodes.WriteBinary(writer);
        for (x = 0; (x < _hingeConstraints.Count); x = (x + 1)) {
          HingeConstraints[x].Write(writer);
        }
        for (x = 0; (x < _hingeConstraints.Count); x = (x + 1)) {
          HingeConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ragdollConstraints.Count); x = (x + 1)) {
          RagdollConstraints[x].Write(writer);
        }
        for (x = 0; (x < _ragdollConstraints.Count); x = (x + 1)) {
          RagdollConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].Write(writer);
        }
        for (x = 0; (x < _importInfo.Count); x = (x + 1)) {
          ImportInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].Write(writer);
        }
        for (x = 0; (x < _errors.Count); x = (x + 1)) {
          Errors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pointToPathCurves.Count); x = (x + 1)) {
          PointToPathCurves[x].Write(writer);
        }
        for (x = 0; (x < _pointToPathCurves.Count); x = (x + 1)) {
          PointToPathCurves[x].WriteChildData(writer);
        }
        for (x = 0; (x < _limitedHingeConstraints.Count); x = (x + 1)) {
          LimitedHingeConstraints[x].Write(writer);
        }
        for (x = 0; (x < _limitedHingeConstraints.Count); x = (x + 1)) {
          LimitedHingeConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ballAndSocketConstraints.Count); x = (x + 1)) {
          BallAndSocketConstraints[x].Write(writer);
        }
        for (x = 0; (x < _ballAndSocketConstraints.Count); x = (x + 1)) {
          BallAndSocketConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stiffSpringConstraints.Count); x = (x + 1)) {
          StiffSpringConstraints[x].Write(writer);
        }
        for (x = 0; (x < _stiffSpringConstraints.Count); x = (x + 1)) {
          StiffSpringConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _prismaticConstraints.Count); x = (x + 1)) {
          PrismaticConstraints[x].Write(writer);
        }
        for (x = 0; (x < _prismaticConstraints.Count); x = (x + 1)) {
          PrismaticConstraints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _phantoms.Count); x = (x + 1)) {
          Phantoms[x].Write(writer);
        }
        for (x = 0; (x < _phantoms.Count); x = (x + 1)) {
          Phantoms[x].WriteChildData(writer);
        }
      }
    }
    public class PhantomTypesBlockBlock : IBlock {
      private Flags _flags;
      private Enum _minimumSize;
      private Enum _maximumSize;
      private Pad _unnamed0;
      private StringId _markerName = new StringId();
      private StringId _alignmentMarkerName = new StringId();
      private Pad _unnamed1;
      private Real _hookesLawE = new Real();
      private Real _linearDeadRadius = new Real();
      private Real _centerAcc = new Real();
      private Real _centerMaxVel = new Real();
      private Real _axisAcc = new Real();
      private Real _axisMaxVel = new Real();
      private Real _directionAcc = new Real();
      private Real _directionMaxVel = new Real();
      private Pad _unnamed2;
      private Real _alignmentHookesLawE = new Real();
      private Real _alignmentAcc = new Real();
      private Real _alignmentMaxVel = new Real();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public PhantomTypesBlockBlock() {
        this._flags = new Flags(4);
        this._minimumSize = new Enum(1);
        this._maximumSize = new Enum(1);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(8);
        this._unnamed2 = new Pad(28);
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
      public Enum MinimumSize {
        get {
          return this._minimumSize;
        }
        set {
          this._minimumSize = value;
        }
      }
      public Enum MaximumSize {
        get {
          return this._maximumSize;
        }
        set {
          this._maximumSize = value;
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
      public StringId AlignmentMarkerName {
        get {
          return this._alignmentMarkerName;
        }
        set {
          this._alignmentMarkerName = value;
        }
      }
      public Real HookesLawE {
        get {
          return this._hookesLawE;
        }
        set {
          this._hookesLawE = value;
        }
      }
      public Real LinearDeadRadius {
        get {
          return this._linearDeadRadius;
        }
        set {
          this._linearDeadRadius = value;
        }
      }
      public Real CenterAcc {
        get {
          return this._centerAcc;
        }
        set {
          this._centerAcc = value;
        }
      }
      public Real CenterMaxVel {
        get {
          return this._centerMaxVel;
        }
        set {
          this._centerMaxVel = value;
        }
      }
      public Real AxisAcc {
        get {
          return this._axisAcc;
        }
        set {
          this._axisAcc = value;
        }
      }
      public Real AxisMaxVel {
        get {
          return this._axisMaxVel;
        }
        set {
          this._axisMaxVel = value;
        }
      }
      public Real DirectionAcc {
        get {
          return this._directionAcc;
        }
        set {
          this._directionAcc = value;
        }
      }
      public Real DirectionMaxVel {
        get {
          return this._directionMaxVel;
        }
        set {
          this._directionMaxVel = value;
        }
      }
      public Real AlignmentHookesLawE {
        get {
          return this._alignmentHookesLawE;
        }
        set {
          this._alignmentHookesLawE = value;
        }
      }
      public Real AlignmentAcc {
        get {
          return this._alignmentAcc;
        }
        set {
          this._alignmentAcc = value;
        }
      }
      public Real AlignmentMaxVel {
        get {
          return this._alignmentMaxVel;
        }
        set {
          this._alignmentMaxVel = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _minimumSize.Read(reader);
        _maximumSize.Read(reader);
        _unnamed0.Read(reader);
        _markerName.Read(reader);
        _alignmentMarkerName.Read(reader);
        _unnamed1.Read(reader);
        _hookesLawE.Read(reader);
        _linearDeadRadius.Read(reader);
        _centerAcc.Read(reader);
        _centerMaxVel.Read(reader);
        _axisAcc.Read(reader);
        _axisMaxVel.Read(reader);
        _directionAcc.Read(reader);
        _directionMaxVel.Read(reader);
        _unnamed2.Read(reader);
        _alignmentHookesLawE.Read(reader);
        _alignmentAcc.Read(reader);
        _alignmentMaxVel.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
        _alignmentMarkerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _minimumSize.Write(bw);
        _maximumSize.Write(bw);
        _unnamed0.Write(bw);
        _markerName.Write(bw);
        _alignmentMarkerName.Write(bw);
        _unnamed1.Write(bw);
        _hookesLawE.Write(bw);
        _linearDeadRadius.Write(bw);
        _centerAcc.Write(bw);
        _centerMaxVel.Write(bw);
        _axisAcc.Write(bw);
        _axisMaxVel.Write(bw);
        _directionAcc.Write(bw);
        _directionMaxVel.Write(bw);
        _unnamed2.Write(bw);
        _alignmentHookesLawE.Write(bw);
        _alignmentAcc.Write(bw);
        _alignmentMaxVel.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
        _alignmentMarkerName.WriteString(writer);
      }
    }
    public class PhysicsModelNodeConstraintEdgeBlockBlock : IBlock {
      private Pad _unnamed0;
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Block _constraints = new Block();
      private StringId _nodeAMaterial = new StringId();
      private StringId _nodeBMaterial = new StringId();
      public BlockCollection<PhysicsModelConstraintEdgeConstraintBlockBlock> _constraintsList = new BlockCollection<PhysicsModelConstraintEdgeConstraintBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PhysicsModelNodeConstraintEdgeBlockBlock() {
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<PhysicsModelConstraintEdgeConstraintBlockBlock> Constraints {
        get {
          return this._constraintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Constraints.BlockCount; x++)
{
  IBlock block = Constraints.GetBlock(x);
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
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public StringId NodeAMaterial {
        get {
          return this._nodeAMaterial;
        }
        set {
          this._nodeAMaterial = value;
        }
      }
      public StringId NodeBMaterial {
        get {
          return this._nodeBMaterial;
        }
        set {
          this._nodeBMaterial = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _constraints.Read(reader);
        _nodeAMaterial.Read(reader);
        _nodeBMaterial.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _constraints.Count); x = (x + 1)) {
          Constraints.Add(new PhysicsModelConstraintEdgeConstraintBlockBlock());
          Constraints[x].Read(reader);
        }
        for (x = 0; (x < _constraints.Count); x = (x + 1)) {
          Constraints[x].ReadChildData(reader);
        }
        _nodeAMaterial.ReadString(reader);
        _nodeBMaterial.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
_constraints.Count = Constraints.Count;
        _constraints.Write(bw);
        _nodeAMaterial.Write(bw);
        _nodeBMaterial.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _constraints.Count); x = (x + 1)) {
          Constraints[x].Write(writer);
        }
        for (x = 0; (x < _constraints.Count); x = (x + 1)) {
          Constraints[x].WriteChildData(writer);
        }
        _nodeAMaterial.WriteString(writer);
        _nodeBMaterial.WriteString(writer);
      }
    }
    public class PhysicsModelConstraintEdgeConstraintBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _index = new ShortInteger();
      private Flags _flags;
      private Real _friction = new Real();
public event System.EventHandler BlockNameChanged;
      public PhysicsModelConstraintEdgeConstraintBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(4);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
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
      public Real Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _index.Read(reader);
        _flags.Read(reader);
        _friction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _index.Write(bw);
        _flags.Write(bw);
        _friction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RigidBodiesBlockBlock : IBlock {
      private ShortBlockIndex _node = new ShortBlockIndex();
      private ShortBlockIndex _region = new ShortBlockIndex();
      private ShortInteger _permutattion = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _boudingSphereOffset = new RealPoint3D();
      private Real _boundingSphereRadius = new Real();
      private Flags _flags;
      private Enum _motionType;
      private ShortBlockIndex _noPhantomPowerAlt = new ShortBlockIndex();
      private Enum _size;
      private Real _inertiaTensorScale = new Real();
      private Real _linearDamping = new Real();
      private Real _angularDamping = new Real();
      private RealVector3D _centerOffMassOffset = new RealVector3D();
      private Enum _shapeType;
      private ShortInteger _shape = new ShortInteger();
      private Real _mass = new Real();
      private RealVector3D _centerOfMass = new RealVector3D();
      private Skip _unnamed1;
      private RealVector3D _intertiaTensorX = new RealVector3D();
      private Skip _unnamed2;
      private RealVector3D _intertiaTensorY = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _intertiaTensorZ = new RealVector3D();
      private Skip _unnamed4;
      private Real _boundingSpherePad = new Real();
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public RigidBodiesBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
        this._motionType = new Enum(2);
        this._size = new Enum(2);
        this._shapeType = new Enum(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Pad(12);
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
      public ShortBlockIndex Region {
        get {
          return this._region;
        }
        set {
          this._region = value;
        }
      }
      public ShortInteger Permutattion {
        get {
          return this._permutattion;
        }
        set {
          this._permutattion = value;
        }
      }
      public RealPoint3D BoudingSphereOffset {
        get {
          return this._boudingSphereOffset;
        }
        set {
          this._boudingSphereOffset = value;
        }
      }
      public Real BoundingSphereRadius {
        get {
          return this._boundingSphereRadius;
        }
        set {
          this._boundingSphereRadius = value;
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
      public Enum MotionType {
        get {
          return this._motionType;
        }
        set {
          this._motionType = value;
        }
      }
      public ShortBlockIndex NoPhantomPowerAlt {
        get {
          return this._noPhantomPowerAlt;
        }
        set {
          this._noPhantomPowerAlt = value;
        }
      }
      public Enum Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public Real InertiaTensorScale {
        get {
          return this._inertiaTensorScale;
        }
        set {
          this._inertiaTensorScale = value;
        }
      }
      public Real LinearDamping {
        get {
          return this._linearDamping;
        }
        set {
          this._linearDamping = value;
        }
      }
      public Real AngularDamping {
        get {
          return this._angularDamping;
        }
        set {
          this._angularDamping = value;
        }
      }
      public RealVector3D CenterOffMassOffset {
        get {
          return this._centerOffMassOffset;
        }
        set {
          this._centerOffMassOffset = value;
        }
      }
      public Enum ShapeType {
        get {
          return this._shapeType;
        }
        set {
          this._shapeType = value;
        }
      }
      public ShortInteger Shape {
        get {
          return this._shape;
        }
        set {
          this._shape = value;
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
      public RealVector3D CenterOfMass {
        get {
          return this._centerOfMass;
        }
        set {
          this._centerOfMass = value;
        }
      }
      public RealVector3D IntertiaTensorX {
        get {
          return this._intertiaTensorX;
        }
        set {
          this._intertiaTensorX = value;
        }
      }
      public RealVector3D IntertiaTensorY {
        get {
          return this._intertiaTensorY;
        }
        set {
          this._intertiaTensorY = value;
        }
      }
      public RealVector3D IntertiaTensorZ {
        get {
          return this._intertiaTensorZ;
        }
        set {
          this._intertiaTensorZ = value;
        }
      }
      public Real BoundingSpherePad {
        get {
          return this._boundingSpherePad;
        }
        set {
          this._boundingSpherePad = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _node.Read(reader);
        _region.Read(reader);
        _permutattion.Read(reader);
        _unnamed0.Read(reader);
        _boudingSphereOffset.Read(reader);
        _boundingSphereRadius.Read(reader);
        _flags.Read(reader);
        _motionType.Read(reader);
        _noPhantomPowerAlt.Read(reader);
        _size.Read(reader);
        _inertiaTensorScale.Read(reader);
        _linearDamping.Read(reader);
        _angularDamping.Read(reader);
        _centerOffMassOffset.Read(reader);
        _shapeType.Read(reader);
        _shape.Read(reader);
        _mass.Read(reader);
        _centerOfMass.Read(reader);
        _unnamed1.Read(reader);
        _intertiaTensorX.Read(reader);
        _unnamed2.Read(reader);
        _intertiaTensorY.Read(reader);
        _unnamed3.Read(reader);
        _intertiaTensorZ.Read(reader);
        _unnamed4.Read(reader);
        _boundingSpherePad.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _node.Write(bw);
        _region.Write(bw);
        _permutattion.Write(bw);
        _unnamed0.Write(bw);
        _boudingSphereOffset.Write(bw);
        _boundingSphereRadius.Write(bw);
        _flags.Write(bw);
        _motionType.Write(bw);
        _noPhantomPowerAlt.Write(bw);
        _size.Write(bw);
        _inertiaTensorScale.Write(bw);
        _linearDamping.Write(bw);
        _angularDamping.Write(bw);
        _centerOffMassOffset.Write(bw);
        _shapeType.Write(bw);
        _shape.Write(bw);
        _mass.Write(bw);
        _centerOfMass.Write(bw);
        _unnamed1.Write(bw);
        _intertiaTensorX.Write(bw);
        _unnamed2.Write(bw);
        _intertiaTensorY.Write(bw);
        _unnamed3.Write(bw);
        _intertiaTensorZ.Write(bw);
        _unnamed4.Write(bw);
        _boundingSpherePad.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MaterialsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private StringId _globalMaterialName = new StringId();
      private ShortBlockIndex _phantomType = new ShortBlockIndex();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public MaterialsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
return _name.ToString();
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
      public StringId GlobalMaterialName {
        get {
          return this._globalMaterialName;
        }
        set {
          this._globalMaterialName = value;
        }
      }
      public ShortBlockIndex PhantomType {
        get {
          return this._phantomType;
        }
        set {
          this._phantomType = value;
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
        _name.Read(reader);
        _globalMaterialName.Read(reader);
        _phantomType.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _globalMaterialName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _globalMaterialName.Write(bw);
        _phantomType.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _globalMaterialName.WriteString(writer);
      }
    }
    public class SpheresBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private Skip _unnamed3;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed4;
      private Skip _unnamed5;
      private RealVector3D _rotationI = new RealVector3D();
      private Skip _unnamed6;
      private RealVector3D _rotationJ = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _rotationK = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _translation = new RealVector3D();
      private Skip _unnamed9;
public event System.EventHandler BlockNameChanged;
      public SpheresBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public ShortInteger Size2 {
        get {
          return this._size2;
        }
        set {
          this._size2 = value;
        }
      }
      public ShortInteger Count2 {
        get {
          return this._count2;
        }
        set {
          this._count2 = value;
        }
      }
      public RealVector3D RotationI {
        get {
          return this._rotationI;
        }
        set {
          this._rotationI = value;
        }
      }
      public RealVector3D RotationJ {
        get {
          return this._rotationJ;
        }
        set {
          this._rotationJ = value;
        }
      }
      public RealVector3D RotationK {
        get {
          return this._rotationK;
        }
        set {
          this._rotationK = value;
        }
      }
      public RealVector3D Translation {
        get {
          return this._translation;
        }
        set {
          this._translation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _unnamed3.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _rotationI.Read(reader);
        _unnamed6.Read(reader);
        _rotationJ.Read(reader);
        _unnamed7.Read(reader);
        _rotationK.Read(reader);
        _unnamed8.Read(reader);
        _translation.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _unnamed3.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _rotationI.Write(bw);
        _unnamed6.Write(bw);
        _rotationJ.Write(bw);
        _unnamed7.Write(bw);
        _rotationK.Write(bw);
        _unnamed8.Write(bw);
        _translation.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class MultiSpheresBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private LongInteger _numSpheres = new LongInteger();
      private RealVector3D _sphere = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _sphere2 = new RealVector3D();
      private Skip _unnamed4;
      private RealVector3D _sphere3 = new RealVector3D();
      private Skip _unnamed5;
      private RealVector3D _sphere4 = new RealVector3D();
      private Skip _unnamed6;
      private RealVector3D _sphere5 = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _sphere6 = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _sphere7 = new RealVector3D();
      private Skip _unnamed9;
      private RealVector3D _sphere8 = new RealVector3D();
      private Skip _unnamed10;
public event System.EventHandler BlockNameChanged;
      public MultiSpheresBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
        this._unnamed10 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public LongInteger NumSpheres {
        get {
          return this._numSpheres;
        }
        set {
          this._numSpheres = value;
        }
      }
      public RealVector3D Sphere {
        get {
          return this._sphere;
        }
        set {
          this._sphere = value;
        }
      }
      public RealVector3D Sphere2 {
        get {
          return this._sphere2;
        }
        set {
          this._sphere2 = value;
        }
      }
      public RealVector3D Sphere3 {
        get {
          return this._sphere3;
        }
        set {
          this._sphere3 = value;
        }
      }
      public RealVector3D Sphere4 {
        get {
          return this._sphere4;
        }
        set {
          this._sphere4 = value;
        }
      }
      public RealVector3D Sphere5 {
        get {
          return this._sphere5;
        }
        set {
          this._sphere5 = value;
        }
      }
      public RealVector3D Sphere6 {
        get {
          return this._sphere6;
        }
        set {
          this._sphere6 = value;
        }
      }
      public RealVector3D Sphere7 {
        get {
          return this._sphere7;
        }
        set {
          this._sphere7 = value;
        }
      }
      public RealVector3D Sphere8 {
        get {
          return this._sphere8;
        }
        set {
          this._sphere8 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _numSpheres.Read(reader);
        _sphere.Read(reader);
        _unnamed3.Read(reader);
        _sphere2.Read(reader);
        _unnamed4.Read(reader);
        _sphere3.Read(reader);
        _unnamed5.Read(reader);
        _sphere4.Read(reader);
        _unnamed6.Read(reader);
        _sphere5.Read(reader);
        _unnamed7.Read(reader);
        _sphere6.Read(reader);
        _unnamed8.Read(reader);
        _sphere7.Read(reader);
        _unnamed9.Read(reader);
        _sphere8.Read(reader);
        _unnamed10.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _numSpheres.Write(bw);
        _sphere.Write(bw);
        _unnamed3.Write(bw);
        _sphere2.Write(bw);
        _unnamed4.Write(bw);
        _sphere3.Write(bw);
        _unnamed5.Write(bw);
        _sphere4.Write(bw);
        _unnamed6.Write(bw);
        _sphere5.Write(bw);
        _unnamed7.Write(bw);
        _sphere6.Write(bw);
        _unnamed8.Write(bw);
        _sphere7.Write(bw);
        _unnamed9.Write(bw);
        _sphere8.Write(bw);
        _unnamed10.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PillsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private RealVector3D _bottom = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _top = new RealVector3D();
      private Skip _unnamed4;
public event System.EventHandler BlockNameChanged;
      public PillsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public RealVector3D Bottom {
        get {
          return this._bottom;
        }
        set {
          this._bottom = value;
        }
      }
      public RealVector3D Top {
        get {
          return this._top;
        }
        set {
          this._top = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _bottom.Read(reader);
        _unnamed3.Read(reader);
        _top.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _bottom.Write(bw);
        _unnamed3.Write(bw);
        _top.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class BoxesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private RealVector3D _halfExtents = new RealVector3D();
      private Skip _unnamed3;
      private Skip _unnamed4;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed5;
      private Skip _unnamed6;
      private RealVector3D _rotationI = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _rotationJ = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _rotationK = new RealVector3D();
      private Skip _unnamed9;
      private RealVector3D _translation = new RealVector3D();
      private Skip _unnamed10;
public event System.EventHandler BlockNameChanged;
      public BoxesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
        this._unnamed10 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public RealVector3D HalfExtents {
        get {
          return this._halfExtents;
        }
        set {
          this._halfExtents = value;
        }
      }
      public ShortInteger Size2 {
        get {
          return this._size2;
        }
        set {
          this._size2 = value;
        }
      }
      public ShortInteger Count2 {
        get {
          return this._count2;
        }
        set {
          this._count2 = value;
        }
      }
      public RealVector3D RotationI {
        get {
          return this._rotationI;
        }
        set {
          this._rotationI = value;
        }
      }
      public RealVector3D RotationJ {
        get {
          return this._rotationJ;
        }
        set {
          this._rotationJ = value;
        }
      }
      public RealVector3D RotationK {
        get {
          return this._rotationK;
        }
        set {
          this._rotationK = value;
        }
      }
      public RealVector3D Translation {
        get {
          return this._translation;
        }
        set {
          this._translation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _halfExtents.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _rotationI.Read(reader);
        _unnamed7.Read(reader);
        _rotationJ.Read(reader);
        _unnamed8.Read(reader);
        _rotationK.Read(reader);
        _unnamed9.Read(reader);
        _translation.Read(reader);
        _unnamed10.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _halfExtents.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _rotationI.Write(bw);
        _unnamed7.Write(bw);
        _rotationJ.Write(bw);
        _unnamed8.Write(bw);
        _rotationK.Write(bw);
        _unnamed9.Write(bw);
        _translation.Write(bw);
        _unnamed10.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class TrianglesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private RealVector3D _pointA = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _pointB = new RealVector3D();
      private Skip _unnamed4;
      private RealVector3D _pointC = new RealVector3D();
      private Skip _unnamed5;
public event System.EventHandler BlockNameChanged;
      public TrianglesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public RealVector3D PointA {
        get {
          return this._pointA;
        }
        set {
          this._pointA = value;
        }
      }
      public RealVector3D PointB {
        get {
          return this._pointB;
        }
        set {
          this._pointB = value;
        }
      }
      public RealVector3D PointC {
        get {
          return this._pointC;
        }
        set {
          this._pointC = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _pointA.Read(reader);
        _unnamed3.Read(reader);
        _pointB.Read(reader);
        _unnamed4.Read(reader);
        _pointC.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _pointA.Write(bw);
        _unnamed3.Write(bw);
        _pointB.Write(bw);
        _unnamed4.Write(bw);
        _pointC.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PolyhedraBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _material = new ShortBlockIndex();
      private Flags _flags;
      private Real _relativeMassScale = new Real();
      private RealFraction _friction = new RealFraction();
      private RealFraction _restitution = new RealFraction();
      private Real _volume = new Real();
      private Real _mass = new Real();
      private Skip _unnamed0;
      private ShortBlockIndex _phantom = new ShortBlockIndex();
      private Skip _unnamed1;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed2;
      private Real _radius = new Real();
      private RealVector3D _aabbHalfExtents = new RealVector3D();
      private Skip _unnamed3;
      private RealVector3D _aabbCenter = new RealVector3D();
      private Skip _unnamed4;
      private Skip _unnamed5;
      private LongInteger _fourVectorsSize = new LongInteger();
      private LongInteger _fourVectorsCapacity = new LongInteger();
      private LongInteger _numVertices = new LongInteger();
      private RealVector3D _fourVectorsX = new RealVector3D();
      private Skip _unnamed6;
      private RealVector3D _fourVectorsY = new RealVector3D();
      private Skip _unnamed7;
      private RealVector3D _fourVectorsZ = new RealVector3D();
      private Skip _unnamed8;
      private RealVector3D _fourVectorsX2 = new RealVector3D();
      private Skip _unnamed9;
      private RealVector3D _fourVectorsY2 = new RealVector3D();
      private Skip _unnamed10;
      private RealVector3D _fourVectorsZ2 = new RealVector3D();
      private Skip _unnamed11;
      private RealVector3D _fourVectorsX3 = new RealVector3D();
      private Skip _unnamed12;
      private RealVector3D _fourVectorsY3 = new RealVector3D();
      private Skip _unnamed13;
      private RealVector3D _fourVectorsZ3 = new RealVector3D();
      private Skip _unnamed14;
      private Skip _unnamed15;
      private LongInteger _planeEquationsSize = new LongInteger();
      private LongInteger _planeEquationsCapacity = new LongInteger();
      private Skip _unnamed16;
public event System.EventHandler BlockNameChanged;
      public PolyhedraBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
        this._unnamed6 = new Skip(4);
        this._unnamed7 = new Skip(4);
        this._unnamed8 = new Skip(4);
        this._unnamed9 = new Skip(4);
        this._unnamed10 = new Skip(4);
        this._unnamed11 = new Skip(4);
        this._unnamed12 = new Skip(4);
        this._unnamed13 = new Skip(4);
        this._unnamed14 = new Skip(4);
        this._unnamed15 = new Skip(4);
        this._unnamed16 = new Skip(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex Material {
        get {
          return this._material;
        }
        set {
          this._material = value;
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
      public Real RelativeMassScale {
        get {
          return this._relativeMassScale;
        }
        set {
          this._relativeMassScale = value;
        }
      }
      public RealFraction Friction {
        get {
          return this._friction;
        }
        set {
          this._friction = value;
        }
      }
      public RealFraction Restitution {
        get {
          return this._restitution;
        }
        set {
          this._restitution = value;
        }
      }
      public Real Volume {
        get {
          return this._volume;
        }
        set {
          this._volume = value;
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
      public ShortBlockIndex Phantom {
        get {
          return this._phantom;
        }
        set {
          this._phantom = value;
        }
      }
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
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
      public RealVector3D AabbHalfExtents {
        get {
          return this._aabbHalfExtents;
        }
        set {
          this._aabbHalfExtents = value;
        }
      }
      public RealVector3D AabbCenter {
        get {
          return this._aabbCenter;
        }
        set {
          this._aabbCenter = value;
        }
      }
      public LongInteger FourVectorsSize {
        get {
          return this._fourVectorsSize;
        }
        set {
          this._fourVectorsSize = value;
        }
      }
      public LongInteger FourVectorsCapacity {
        get {
          return this._fourVectorsCapacity;
        }
        set {
          this._fourVectorsCapacity = value;
        }
      }
      public LongInteger NumVertices {
        get {
          return this._numVertices;
        }
        set {
          this._numVertices = value;
        }
      }
      public RealVector3D FourVectorsX {
        get {
          return this._fourVectorsX;
        }
        set {
          this._fourVectorsX = value;
        }
      }
      public RealVector3D FourVectorsY {
        get {
          return this._fourVectorsY;
        }
        set {
          this._fourVectorsY = value;
        }
      }
      public RealVector3D FourVectorsZ {
        get {
          return this._fourVectorsZ;
        }
        set {
          this._fourVectorsZ = value;
        }
      }
      public RealVector3D FourVectorsX2 {
        get {
          return this._fourVectorsX2;
        }
        set {
          this._fourVectorsX2 = value;
        }
      }
      public RealVector3D FourVectorsY2 {
        get {
          return this._fourVectorsY2;
        }
        set {
          this._fourVectorsY2 = value;
        }
      }
      public RealVector3D FourVectorsZ2 {
        get {
          return this._fourVectorsZ2;
        }
        set {
          this._fourVectorsZ2 = value;
        }
      }
      public RealVector3D FourVectorsX3 {
        get {
          return this._fourVectorsX3;
        }
        set {
          this._fourVectorsX3 = value;
        }
      }
      public RealVector3D FourVectorsY3 {
        get {
          return this._fourVectorsY3;
        }
        set {
          this._fourVectorsY3 = value;
        }
      }
      public RealVector3D FourVectorsZ3 {
        get {
          return this._fourVectorsZ3;
        }
        set {
          this._fourVectorsZ3 = value;
        }
      }
      public LongInteger PlaneEquationsSize {
        get {
          return this._planeEquationsSize;
        }
        set {
          this._planeEquationsSize = value;
        }
      }
      public LongInteger PlaneEquationsCapacity {
        get {
          return this._planeEquationsCapacity;
        }
        set {
          this._planeEquationsCapacity = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _material.Read(reader);
        _flags.Read(reader);
        _relativeMassScale.Read(reader);
        _friction.Read(reader);
        _restitution.Read(reader);
        _volume.Read(reader);
        _mass.Read(reader);
        _unnamed0.Read(reader);
        _phantom.Read(reader);
        _unnamed1.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed2.Read(reader);
        _radius.Read(reader);
        _aabbHalfExtents.Read(reader);
        _unnamed3.Read(reader);
        _aabbCenter.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _fourVectorsSize.Read(reader);
        _fourVectorsCapacity.Read(reader);
        _numVertices.Read(reader);
        _fourVectorsX.Read(reader);
        _unnamed6.Read(reader);
        _fourVectorsY.Read(reader);
        _unnamed7.Read(reader);
        _fourVectorsZ.Read(reader);
        _unnamed8.Read(reader);
        _fourVectorsX2.Read(reader);
        _unnamed9.Read(reader);
        _fourVectorsY2.Read(reader);
        _unnamed10.Read(reader);
        _fourVectorsZ2.Read(reader);
        _unnamed11.Read(reader);
        _fourVectorsX3.Read(reader);
        _unnamed12.Read(reader);
        _fourVectorsY3.Read(reader);
        _unnamed13.Read(reader);
        _fourVectorsZ3.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _planeEquationsSize.Read(reader);
        _planeEquationsCapacity.Read(reader);
        _unnamed16.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _material.Write(bw);
        _flags.Write(bw);
        _relativeMassScale.Write(bw);
        _friction.Write(bw);
        _restitution.Write(bw);
        _volume.Write(bw);
        _mass.Write(bw);
        _unnamed0.Write(bw);
        _phantom.Write(bw);
        _unnamed1.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed2.Write(bw);
        _radius.Write(bw);
        _aabbHalfExtents.Write(bw);
        _unnamed3.Write(bw);
        _aabbCenter.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _fourVectorsSize.Write(bw);
        _fourVectorsCapacity.Write(bw);
        _numVertices.Write(bw);
        _fourVectorsX.Write(bw);
        _unnamed6.Write(bw);
        _fourVectorsY.Write(bw);
        _unnamed7.Write(bw);
        _fourVectorsZ.Write(bw);
        _unnamed8.Write(bw);
        _fourVectorsX2.Write(bw);
        _unnamed9.Write(bw);
        _fourVectorsY2.Write(bw);
        _unnamed10.Write(bw);
        _fourVectorsZ2.Write(bw);
        _unnamed11.Write(bw);
        _fourVectorsX3.Write(bw);
        _unnamed12.Write(bw);
        _fourVectorsY3.Write(bw);
        _unnamed13.Write(bw);
        _fourVectorsZ3.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _planeEquationsSize.Write(bw);
        _planeEquationsCapacity.Write(bw);
        _unnamed16.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PolyhedronFourVectorsBlockBlock : IBlock {
      private RealVector3D _fourVectorsX = new RealVector3D();
      private Skip _unnamed0;
      private RealVector3D _fourVectorsY = new RealVector3D();
      private Skip _unnamed1;
      private RealVector3D _fourVectorsZ = new RealVector3D();
      private Skip _unnamed2;
public event System.EventHandler BlockNameChanged;
      public PolyhedronFourVectorsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
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
      public RealVector3D FourVectorsX {
        get {
          return this._fourVectorsX;
        }
        set {
          this._fourVectorsX = value;
        }
      }
      public RealVector3D FourVectorsY {
        get {
          return this._fourVectorsY;
        }
        set {
          this._fourVectorsY = value;
        }
      }
      public RealVector3D FourVectorsZ {
        get {
          return this._fourVectorsZ;
        }
        set {
          this._fourVectorsZ = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fourVectorsX.Read(reader);
        _unnamed0.Read(reader);
        _fourVectorsY.Read(reader);
        _unnamed1.Read(reader);
        _fourVectorsZ.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _fourVectorsX.Write(bw);
        _unnamed0.Write(bw);
        _fourVectorsY.Write(bw);
        _unnamed1.Write(bw);
        _fourVectorsZ.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PolyhedronPlaneEquationsBlockBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public PolyhedronPlaneEquationsBlockBlock() {
        this._unnamed0 = new Skip(16);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MassDistributionsBlockBlock : IBlock {
      private RealVector3D _centerOfMass = new RealVector3D();
      private Skip _unnamed0;
      private RealVector3D _inertiaTensorI = new RealVector3D();
      private Skip _unnamed1;
      private RealVector3D _inertiaTensorJ = new RealVector3D();
      private Skip _unnamed2;
      private RealVector3D _inertiaTensorK = new RealVector3D();
      private Skip _unnamed3;
public event System.EventHandler BlockNameChanged;
      public MassDistributionsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._unnamed3 = new Skip(4);
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
      public RealVector3D CenterOfMass {
        get {
          return this._centerOfMass;
        }
        set {
          this._centerOfMass = value;
        }
      }
      public RealVector3D InertiaTensorI {
        get {
          return this._inertiaTensorI;
        }
        set {
          this._inertiaTensorI = value;
        }
      }
      public RealVector3D InertiaTensorJ {
        get {
          return this._inertiaTensorJ;
        }
        set {
          this._inertiaTensorJ = value;
        }
      }
      public RealVector3D InertiaTensorK {
        get {
          return this._inertiaTensorK;
        }
        set {
          this._inertiaTensorK = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _centerOfMass.Read(reader);
        _unnamed0.Read(reader);
        _inertiaTensorI.Read(reader);
        _unnamed1.Read(reader);
        _inertiaTensorJ.Read(reader);
        _unnamed2.Read(reader);
        _inertiaTensorK.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _centerOfMass.Write(bw);
        _unnamed0.Write(bw);
        _inertiaTensorI.Write(bw);
        _unnamed1.Write(bw);
        _inertiaTensorJ.Write(bw);
        _unnamed2.Write(bw);
        _inertiaTensorK.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ListsBlockBlock : IBlock {
      private Skip _unnamed0;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed1;
      private Skip _unnamed2;
      private LongInteger _childShapesSize = new LongInteger();
      private LongInteger _childShapesCapacity = new LongInteger();
      private Enum _shapeType;
      private ShortInteger _shape = new ShortInteger();
      private LongInteger _collisionFilter = new LongInteger();
      private Enum _shapeType2;
      private ShortInteger _shape2 = new ShortInteger();
      private LongInteger _collisionFilter2 = new LongInteger();
      private Enum _shapeType3;
      private ShortInteger _shape3 = new ShortInteger();
      private LongInteger _collisionFilter3 = new LongInteger();
      private Enum _shapeType4;
      private ShortInteger _shape4 = new ShortInteger();
      private LongInteger _collisionFilter4 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public ListsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Skip(4);
        this._shapeType = new Enum(2);
        this._shapeType2 = new Enum(2);
        this._shapeType3 = new Enum(2);
        this._shapeType4 = new Enum(2);
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
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public LongInteger ChildShapesSize {
        get {
          return this._childShapesSize;
        }
        set {
          this._childShapesSize = value;
        }
      }
      public LongInteger ChildShapesCapacity {
        get {
          return this._childShapesCapacity;
        }
        set {
          this._childShapesCapacity = value;
        }
      }
      public Enum ShapeType {
        get {
          return this._shapeType;
        }
        set {
          this._shapeType = value;
        }
      }
      public ShortInteger Shape {
        get {
          return this._shape;
        }
        set {
          this._shape = value;
        }
      }
      public LongInteger CollisionFilter {
        get {
          return this._collisionFilter;
        }
        set {
          this._collisionFilter = value;
        }
      }
      public Enum ShapeType2 {
        get {
          return this._shapeType2;
        }
        set {
          this._shapeType2 = value;
        }
      }
      public ShortInteger Shape2 {
        get {
          return this._shape2;
        }
        set {
          this._shape2 = value;
        }
      }
      public LongInteger CollisionFilter2 {
        get {
          return this._collisionFilter2;
        }
        set {
          this._collisionFilter2 = value;
        }
      }
      public Enum ShapeType3 {
        get {
          return this._shapeType3;
        }
        set {
          this._shapeType3 = value;
        }
      }
      public ShortInteger Shape3 {
        get {
          return this._shape3;
        }
        set {
          this._shape3 = value;
        }
      }
      public LongInteger CollisionFilter3 {
        get {
          return this._collisionFilter3;
        }
        set {
          this._collisionFilter3 = value;
        }
      }
      public Enum ShapeType4 {
        get {
          return this._shapeType4;
        }
        set {
          this._shapeType4 = value;
        }
      }
      public ShortInteger Shape4 {
        get {
          return this._shape4;
        }
        set {
          this._shape4 = value;
        }
      }
      public LongInteger CollisionFilter4 {
        get {
          return this._collisionFilter4;
        }
        set {
          this._collisionFilter4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _childShapesSize.Read(reader);
        _childShapesCapacity.Read(reader);
        _shapeType.Read(reader);
        _shape.Read(reader);
        _collisionFilter.Read(reader);
        _shapeType2.Read(reader);
        _shape2.Read(reader);
        _collisionFilter2.Read(reader);
        _shapeType3.Read(reader);
        _shape3.Read(reader);
        _collisionFilter3.Read(reader);
        _shapeType4.Read(reader);
        _shape4.Read(reader);
        _collisionFilter4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _childShapesSize.Write(bw);
        _childShapesCapacity.Write(bw);
        _shapeType.Write(bw);
        _shape.Write(bw);
        _collisionFilter.Write(bw);
        _shapeType2.Write(bw);
        _shape2.Write(bw);
        _collisionFilter2.Write(bw);
        _shapeType3.Write(bw);
        _shape3.Write(bw);
        _collisionFilter3.Write(bw);
        _shapeType4.Write(bw);
        _shape4.Write(bw);
        _collisionFilter4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ListShapesBlockBlock : IBlock {
      private Enum _shapeType;
      private ShortInteger _shape = new ShortInteger();
      private LongInteger _collisionFilter = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public ListShapesBlockBlock() {
        this._shapeType = new Enum(2);
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
      public Enum ShapeType {
        get {
          return this._shapeType;
        }
        set {
          this._shapeType = value;
        }
      }
      public ShortInteger Shape {
        get {
          return this._shape;
        }
        set {
          this._shape = value;
        }
      }
      public LongInteger CollisionFilter {
        get {
          return this._collisionFilter;
        }
        set {
          this._collisionFilter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _shapeType.Read(reader);
        _shape.Read(reader);
        _collisionFilter.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _shapeType.Write(bw);
        _shape.Write(bw);
        _collisionFilter.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class MoppsBlockBlock : IBlock {
      private Skip _unnamed0;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed1;
      private Pad _unnamed2;
      private ShortBlockIndex _list = new ShortBlockIndex();
      private LongInteger _codeOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public MoppsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Pad(2);
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
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public ShortBlockIndex List {
        get {
          return this._list;
        }
        set {
          this._list = value;
        }
      }
      public LongInteger CodeOffset {
        get {
          return this._codeOffset;
        }
        set {
          this._codeOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _list.Read(reader);
        _codeOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _list.Write(bw);
        _codeOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HingeConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public HingeConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class RagdollConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _minTwist = new Real();
      private Real _maxTwist = new Real();
      private Real _minCone = new Real();
      private Real _maxCone = new Real();
      private Real _minPlane = new Real();
      private Real _maxPlane = new Real();
      private Real _maxFricitonTorque = new Real();
public event System.EventHandler BlockNameChanged;
      public RagdollConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public Real MinTwist {
        get {
          return this._minTwist;
        }
        set {
          this._minTwist = value;
        }
      }
      public Real MaxTwist {
        get {
          return this._maxTwist;
        }
        set {
          this._maxTwist = value;
        }
      }
      public Real MinCone {
        get {
          return this._minCone;
        }
        set {
          this._minCone = value;
        }
      }
      public Real MaxCone {
        get {
          return this._maxCone;
        }
        set {
          this._maxCone = value;
        }
      }
      public Real MinPlane {
        get {
          return this._minPlane;
        }
        set {
          this._minPlane = value;
        }
      }
      public Real MaxPlane {
        get {
          return this._maxPlane;
        }
        set {
          this._maxPlane = value;
        }
      }
      public Real MaxFricitonTorque {
        get {
          return this._maxFricitonTorque;
        }
        set {
          this._maxFricitonTorque = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _minTwist.Read(reader);
        _maxTwist.Read(reader);
        _minCone.Read(reader);
        _maxCone.Read(reader);
        _minPlane.Read(reader);
        _maxPlane.Read(reader);
        _maxFricitonTorque.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _minTwist.Write(bw);
        _maxTwist.Write(bw);
        _minCone.Write(bw);
        _maxCone.Write(bw);
        _minPlane.Write(bw);
        _maxPlane.Write(bw);
        _maxFricitonTorque.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class RegionsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _permutations = new Block();
      public BlockCollection<PermutationsBlockBlock> _permutationsList = new BlockCollection<PermutationsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RegionsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<PermutationsBlockBlock> Permutations {
        get {
          return this._permutationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new PermutationsBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class PermutationsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Block _rigidBodies = new Block();
      public BlockCollection<RigidBodyIndicesBlockBlock> _rigidBodiesList = new BlockCollection<RigidBodyIndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PermutationsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<RigidBodyIndicesBlockBlock> RigidBodies {
        get {
          return this._rigidBodiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<RigidBodies.BlockCount; x++)
{
  IBlock block = RigidBodies.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _rigidBodies.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies.Add(new RigidBodyIndicesBlockBlock());
          RigidBodies[x].Read(reader);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_rigidBodies.Count = RigidBodies.Count;
        _rigidBodies.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].Write(writer);
        }
        for (x = 0; (x < _rigidBodies.Count); x = (x + 1)) {
          RigidBodies[x].WriteChildData(writer);
        }
      }
    }
    public class RigidBodyIndicesBlockBlock : IBlock {
      private ShortBlockIndex _rigidBody = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public RigidBodyIndicesBlockBlock() {
if (this._rigidBody is System.ComponentModel.INotifyPropertyChanged)
  (this._rigidBody as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _rigidBody.ToString();
        }
      }
      public ShortBlockIndex RigidBody {
        get {
          return this._rigidBody;
        }
        set {
          this._rigidBody = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _rigidBody.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _rigidBody.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class NodesBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _flags;
      private ShortBlockIndex _parent = new ShortBlockIndex();
      private ShortBlockIndex _sibling = new ShortBlockIndex();
      private ShortBlockIndex _child = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public NodesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
return _name.ToString();
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortBlockIndex Parent {
        get {
          return this._parent;
        }
        set {
          this._parent = value;
        }
      }
      public ShortBlockIndex Sibling {
        get {
          return this._sibling;
        }
        set {
          this._sibling = value;
        }
      }
      public ShortBlockIndex Child {
        get {
          return this._child;
        }
        set {
          this._child = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _parent.Read(reader);
        _sibling.Read(reader);
        _child.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _parent.Write(bw);
        _sibling.Write(bw);
        _child.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class GlobalTagImportInfoBlockBlock : IBlock {
      private LongInteger _build = new LongInteger();
      private LongerFixedLengthString _version = new LongerFixedLengthString();
      private FixedLengthString _importDate = new FixedLengthString();
      private FixedLengthString _culprit = new FixedLengthString();
      private Pad _unnamed0;
      private FixedLengthString _importTime = new FixedLengthString();
      private Pad _unnamed1;
      private Block _files = new Block();
      private Pad _unnamed2;
      public BlockCollection<TagImportFileBlockBlock> _filesList = new BlockCollection<TagImportFileBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalTagImportInfoBlockBlock() {
        this._unnamed0 = new Pad(96);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(128);
      }
      public BlockCollection<TagImportFileBlockBlock> Files {
        get {
          return this._filesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Files.BlockCount; x++)
{
  IBlock block = Files.GetBlock(x);
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
      public LongInteger Build {
        get {
          return this._build;
        }
        set {
          this._build = value;
        }
      }
      public LongerFixedLengthString Version {
        get {
          return this._version;
        }
        set {
          this._version = value;
        }
      }
      public FixedLengthString ImportDate {
        get {
          return this._importDate;
        }
        set {
          this._importDate = value;
        }
      }
      public FixedLengthString Culprit {
        get {
          return this._culprit;
        }
        set {
          this._culprit = value;
        }
      }
      public FixedLengthString ImportTime {
        get {
          return this._importTime;
        }
        set {
          this._importTime = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _build.Read(reader);
        _version.Read(reader);
        _importDate.Read(reader);
        _culprit.Read(reader);
        _unnamed0.Read(reader);
        _importTime.Read(reader);
        _unnamed1.Read(reader);
        _files.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files.Add(new TagImportFileBlockBlock());
          Files[x].Read(reader);
        }
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _build.Write(bw);
        _version.Write(bw);
        _importDate.Write(bw);
        _culprit.Write(bw);
        _unnamed0.Write(bw);
        _importTime.Write(bw);
        _unnamed1.Write(bw);
_files.Count = Files.Count;
        _files.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].Write(writer);
        }
        for (x = 0; (x < _files.Count); x = (x + 1)) {
          Files[x].WriteChildData(writer);
        }
      }
    }
    public class TagImportFileBlockBlock : IBlock {
      private LongerFixedLengthString _path = new LongerFixedLengthString();
      private FixedLengthString _modificationDate = new FixedLengthString();
      private Skip _unnamed0;
      private Pad _unnamed1;
      private LongInteger _checksum = new LongInteger();
      private LongInteger _size = new LongInteger();
      private Data _zippedData = new Data();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public TagImportFileBlockBlock() {
        this._unnamed0 = new Skip(8);
        this._unnamed1 = new Pad(88);
        this._unnamed2 = new Pad(128);
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
      public LongerFixedLengthString Path {
        get {
          return this._path;
        }
        set {
          this._path = value;
        }
      }
      public FixedLengthString ModificationDate {
        get {
          return this._modificationDate;
        }
        set {
          this._modificationDate = value;
        }
      }
      public LongInteger Checksum {
        get {
          return this._checksum;
        }
        set {
          this._checksum = value;
        }
      }
      public LongInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public Data ZippedData {
        get {
          return this._zippedData;
        }
        set {
          this._zippedData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _path.Read(reader);
        _modificationDate.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _checksum.Read(reader);
        _size.Read(reader);
        _zippedData.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _zippedData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _path.Write(bw);
        _modificationDate.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _checksum.Write(bw);
        _size.Write(bw);
        _zippedData.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _zippedData.WriteBinary(writer);
      }
    }
    public class GlobalErrorReportCategoriesBlockBlock : IBlock {
      private LongerFixedLengthString _name = new LongerFixedLengthString();
      private Enum _reportType;
      private Flags _flags;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Block _reports = new Block();
      public BlockCollection<ErrorReportsBlockBlock> _reportsList = new BlockCollection<ErrorReportsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalErrorReportCategoriesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._reportType = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(404);
      }
      public BlockCollection<ErrorReportsBlockBlock> Reports {
        get {
          return this._reportsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Reports.BlockCount; x++)
{
  IBlock block = Reports.GetBlock(x);
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
      public LongerFixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Enum ReportType {
        get {
          return this._reportType;
        }
        set {
          this._reportType = value;
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
        _name.Read(reader);
        _reportType.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _reports.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports.Add(new ErrorReportsBlockBlock());
          Reports[x].Read(reader);
        }
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _reportType.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_reports.Count = Reports.Count;
        _reports.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].Write(writer);
        }
        for (x = 0; (x < _reports.Count); x = (x + 1)) {
          Reports[x].WriteChildData(writer);
        }
      }
    }
    public class ErrorReportsBlockBlock : IBlock {
      private Enum _type;
      private Flags _flags;
      private Data _text = new Data();
      private FixedLengthString _sourceFilename = new FixedLengthString();
      private LongInteger _sourceLineNumber = new LongInteger();
      private Block _vertices = new Block();
      private Block _vectors = new Block();
      private Block _lines = new Block();
      private Block _triangles = new Block();
      private Block _quads = new Block();
      private Block _comments = new Block();
      private Pad _unnamed0;
      private LongInteger _reportKey = new LongInteger();
      private LongInteger _nodeIndex = new LongInteger();
      private RealBounds _boundsX = new RealBounds();
      private RealBounds _boundsY = new RealBounds();
      private RealBounds _boundsZ = new RealBounds();
      private RealARGBColor _color = new RealARGBColor();
      private Pad _unnamed1;
      public BlockCollection<ErrorReportVerticesBlockBlock> _verticesList = new BlockCollection<ErrorReportVerticesBlockBlock>();
      public BlockCollection<ErrorReportVectorsBlockBlock> _vectorsList = new BlockCollection<ErrorReportVectorsBlockBlock>();
      public BlockCollection<ErrorReportLinesBlockBlock> _linesList = new BlockCollection<ErrorReportLinesBlockBlock>();
      public BlockCollection<ErrorReportTrianglesBlockBlock> _trianglesList = new BlockCollection<ErrorReportTrianglesBlockBlock>();
      public BlockCollection<ErrorReportQuadsBlockBlock> _quadsList = new BlockCollection<ErrorReportQuadsBlockBlock>();
      public BlockCollection<ErrorReportCommentsBlockBlock> _commentsList = new BlockCollection<ErrorReportCommentsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ErrorReportsBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(380);
        this._unnamed1 = new Pad(84);
      }
      public BlockCollection<ErrorReportVerticesBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<ErrorReportVectorsBlockBlock> Vectors {
        get {
          return this._vectorsList;
        }
      }
      public BlockCollection<ErrorReportLinesBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<ErrorReportTrianglesBlockBlock> Triangles {
        get {
          return this._trianglesList;
        }
      }
      public BlockCollection<ErrorReportQuadsBlockBlock> Quads {
        get {
          return this._quadsList;
        }
      }
      public BlockCollection<ErrorReportCommentsBlockBlock> Comments {
        get {
          return this._commentsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vectors.BlockCount; x++)
{
  IBlock block = Vectors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Triangles.BlockCount; x++)
{
  IBlock block = Triangles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Quads.BlockCount; x++)
{
  IBlock block = Quads.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Comments.BlockCount; x++)
{
  IBlock block = Comments.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Data Text {
        get {
          return this._text;
        }
        set {
          this._text = value;
        }
      }
      public FixedLengthString SourceFilename {
        get {
          return this._sourceFilename;
        }
        set {
          this._sourceFilename = value;
        }
      }
      public LongInteger SourceLineNumber {
        get {
          return this._sourceLineNumber;
        }
        set {
          this._sourceLineNumber = value;
        }
      }
      public LongInteger ReportKey {
        get {
          return this._reportKey;
        }
        set {
          this._reportKey = value;
        }
      }
      public LongInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public RealBounds BoundsX {
        get {
          return this._boundsX;
        }
        set {
          this._boundsX = value;
        }
      }
      public RealBounds BoundsY {
        get {
          return this._boundsY;
        }
        set {
          this._boundsY = value;
        }
      }
      public RealBounds BoundsZ {
        get {
          return this._boundsZ;
        }
        set {
          this._boundsZ = value;
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _flags.Read(reader);
        _text.Read(reader);
        _sourceFilename.Read(reader);
        _sourceLineNumber.Read(reader);
        _vertices.Read(reader);
        _vectors.Read(reader);
        _lines.Read(reader);
        _triangles.Read(reader);
        _quads.Read(reader);
        _comments.Read(reader);
        _unnamed0.Read(reader);
        _reportKey.Read(reader);
        _nodeIndex.Read(reader);
        _boundsX.Read(reader);
        _boundsY.Read(reader);
        _boundsZ.Read(reader);
        _color.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _text.ReadBinary(reader);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new ErrorReportVerticesBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors.Add(new ErrorReportVectorsBlockBlock());
          Vectors[x].Read(reader);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new ErrorReportLinesBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles.Add(new ErrorReportTrianglesBlockBlock());
          Triangles[x].Read(reader);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads.Add(new ErrorReportQuadsBlockBlock());
          Quads[x].Read(reader);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].ReadChildData(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments.Add(new ErrorReportCommentsBlockBlock());
          Comments[x].Read(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _flags.Write(bw);
        _text.Write(bw);
        _sourceFilename.Write(bw);
        _sourceLineNumber.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_vectors.Count = Vectors.Count;
        _vectors.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_triangles.Count = Triangles.Count;
        _triangles.Write(bw);
_quads.Count = Quads.Count;
        _quads.Write(bw);
_comments.Count = Comments.Count;
        _comments.Write(bw);
        _unnamed0.Write(bw);
        _reportKey.Write(bw);
        _nodeIndex.Write(bw);
        _boundsX.Write(bw);
        _boundsY.Write(bw);
        _boundsZ.Write(bw);
        _color.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _text.WriteBinary(writer);
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].Write(writer);
        }
        for (x = 0; (x < _vectors.Count); x = (x + 1)) {
          Vectors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].Write(writer);
        }
        for (x = 0; (x < _triangles.Count); x = (x + 1)) {
          Triangles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].Write(writer);
        }
        for (x = 0; (x < _quads.Count); x = (x + 1)) {
          Quads[x].WriteChildData(writer);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].Write(writer);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].WriteChildData(writer);
        }
      }
    }
    public class ErrorReportVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
      private Real _screenSize = new Real();
public event System.EventHandler BlockNameChanged;
      public ErrorReportVerticesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public Real ScreenSize {
        get {
          return this._screenSize;
        }
        set {
          this._screenSize = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
        _screenSize.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
        _screenSize.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportVectorsBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
      private RealVector3D _normal = new RealVector3D();
      private Real _screenLength = new Real();
public event System.EventHandler BlockNameChanged;
      public ErrorReportVectorsBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public RealVector3D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public Real ScreenLength {
        get {
          return this._screenLength;
        }
        set {
          this._screenLength = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
        _normal.Read(reader);
        _screenLength.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
        _normal.Write(bw);
        _screenLength.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportLinesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportLinesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportTrianglesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private RealPoint3D _position3 = new RealPoint3D();
      private CharInteger _nodeIndex9 = new CharInteger();
      private CharInteger _nodeIndex10 = new CharInteger();
      private CharInteger _nodeIndex11 = new CharInteger();
      private CharInteger _nodeIndex12 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportTrianglesBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public RealPoint3D Position3 {
        get {
          return this._position3;
        }
        set {
          this._position3 = value;
        }
      }
      public CharInteger NodeIndex9 {
        get {
          return this._nodeIndex9;
        }
        set {
          this._nodeIndex9 = value;
        }
      }
      public CharInteger NodeIndex10 {
        get {
          return this._nodeIndex10;
        }
        set {
          this._nodeIndex10 = value;
        }
      }
      public CharInteger NodeIndex11 {
        get {
          return this._nodeIndex11;
        }
        set {
          this._nodeIndex11 = value;
        }
      }
      public CharInteger NodeIndex12 {
        get {
          return this._nodeIndex12;
        }
        set {
          this._nodeIndex12 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _position3.Read(reader);
        _nodeIndex9.Read(reader);
        _nodeIndex10.Read(reader);
        _nodeIndex11.Read(reader);
        _nodeIndex12.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _position3.Write(bw);
        _nodeIndex9.Write(bw);
        _nodeIndex10.Write(bw);
        _nodeIndex11.Write(bw);
        _nodeIndex12.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportQuadsBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private RealPoint3D _position2 = new RealPoint3D();
      private CharInteger _nodeIndex5 = new CharInteger();
      private CharInteger _nodeIndex6 = new CharInteger();
      private CharInteger _nodeIndex7 = new CharInteger();
      private CharInteger _nodeIndex8 = new CharInteger();
      private RealPoint3D _position3 = new RealPoint3D();
      private CharInteger _nodeIndex9 = new CharInteger();
      private CharInteger _nodeIndex10 = new CharInteger();
      private CharInteger _nodeIndex11 = new CharInteger();
      private CharInteger _nodeIndex12 = new CharInteger();
      private RealPoint3D _position4 = new RealPoint3D();
      private CharInteger _nodeIndex13 = new CharInteger();
      private CharInteger _nodeIndex14 = new CharInteger();
      private CharInteger _nodeIndex15 = new CharInteger();
      private CharInteger _nodeIndex16 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportQuadsBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public RealPoint3D Position2 {
        get {
          return this._position2;
        }
        set {
          this._position2 = value;
        }
      }
      public CharInteger NodeIndex5 {
        get {
          return this._nodeIndex5;
        }
        set {
          this._nodeIndex5 = value;
        }
      }
      public CharInteger NodeIndex6 {
        get {
          return this._nodeIndex6;
        }
        set {
          this._nodeIndex6 = value;
        }
      }
      public CharInteger NodeIndex7 {
        get {
          return this._nodeIndex7;
        }
        set {
          this._nodeIndex7 = value;
        }
      }
      public CharInteger NodeIndex8 {
        get {
          return this._nodeIndex8;
        }
        set {
          this._nodeIndex8 = value;
        }
      }
      public RealPoint3D Position3 {
        get {
          return this._position3;
        }
        set {
          this._position3 = value;
        }
      }
      public CharInteger NodeIndex9 {
        get {
          return this._nodeIndex9;
        }
        set {
          this._nodeIndex9 = value;
        }
      }
      public CharInteger NodeIndex10 {
        get {
          return this._nodeIndex10;
        }
        set {
          this._nodeIndex10 = value;
        }
      }
      public CharInteger NodeIndex11 {
        get {
          return this._nodeIndex11;
        }
        set {
          this._nodeIndex11 = value;
        }
      }
      public CharInteger NodeIndex12 {
        get {
          return this._nodeIndex12;
        }
        set {
          this._nodeIndex12 = value;
        }
      }
      public RealPoint3D Position4 {
        get {
          return this._position4;
        }
        set {
          this._position4 = value;
        }
      }
      public CharInteger NodeIndex13 {
        get {
          return this._nodeIndex13;
        }
        set {
          this._nodeIndex13 = value;
        }
      }
      public CharInteger NodeIndex14 {
        get {
          return this._nodeIndex14;
        }
        set {
          this._nodeIndex14 = value;
        }
      }
      public CharInteger NodeIndex15 {
        get {
          return this._nodeIndex15;
        }
        set {
          this._nodeIndex15 = value;
        }
      }
      public CharInteger NodeIndex16 {
        get {
          return this._nodeIndex16;
        }
        set {
          this._nodeIndex16 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _position2.Read(reader);
        _nodeIndex5.Read(reader);
        _nodeIndex6.Read(reader);
        _nodeIndex7.Read(reader);
        _nodeIndex8.Read(reader);
        _position3.Read(reader);
        _nodeIndex9.Read(reader);
        _nodeIndex10.Read(reader);
        _nodeIndex11.Read(reader);
        _nodeIndex12.Read(reader);
        _position4.Read(reader);
        _nodeIndex13.Read(reader);
        _nodeIndex14.Read(reader);
        _nodeIndex15.Read(reader);
        _nodeIndex16.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _position2.Write(bw);
        _nodeIndex5.Write(bw);
        _nodeIndex6.Write(bw);
        _nodeIndex7.Write(bw);
        _nodeIndex8.Write(bw);
        _position3.Write(bw);
        _nodeIndex9.Write(bw);
        _nodeIndex10.Write(bw);
        _nodeIndex11.Write(bw);
        _nodeIndex12.Write(bw);
        _position4.Write(bw);
        _nodeIndex13.Write(bw);
        _nodeIndex14.Write(bw);
        _nodeIndex15.Write(bw);
        _nodeIndex16.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ErrorReportCommentsBlockBlock : IBlock {
      private Data _text = new Data();
      private RealPoint3D _position = new RealPoint3D();
      private CharInteger _nodeIndex = new CharInteger();
      private CharInteger _nodeIndex2 = new CharInteger();
      private CharInteger _nodeIndex3 = new CharInteger();
      private CharInteger _nodeIndex4 = new CharInteger();
      private Real _nodeWeight = new Real();
      private Real _nodeWeight2 = new Real();
      private Real _nodeWeight3 = new Real();
      private Real _nodeWeight4 = new Real();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ErrorReportCommentsBlockBlock() {
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
      public Data Text {
        get {
          return this._text;
        }
        set {
          this._text = value;
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
      public CharInteger NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public CharInteger NodeIndex2 {
        get {
          return this._nodeIndex2;
        }
        set {
          this._nodeIndex2 = value;
        }
      }
      public CharInteger NodeIndex3 {
        get {
          return this._nodeIndex3;
        }
        set {
          this._nodeIndex3 = value;
        }
      }
      public CharInteger NodeIndex4 {
        get {
          return this._nodeIndex4;
        }
        set {
          this._nodeIndex4 = value;
        }
      }
      public Real NodeWeight {
        get {
          return this._nodeWeight;
        }
        set {
          this._nodeWeight = value;
        }
      }
      public Real NodeWeight2 {
        get {
          return this._nodeWeight2;
        }
        set {
          this._nodeWeight2 = value;
        }
      }
      public Real NodeWeight3 {
        get {
          return this._nodeWeight3;
        }
        set {
          this._nodeWeight3 = value;
        }
      }
      public Real NodeWeight4 {
        get {
          return this._nodeWeight4;
        }
        set {
          this._nodeWeight4 = value;
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
      public virtual void Read(BinaryReader reader) {
        _text.Read(reader);
        _position.Read(reader);
        _nodeIndex.Read(reader);
        _nodeIndex2.Read(reader);
        _nodeIndex3.Read(reader);
        _nodeIndex4.Read(reader);
        _nodeWeight.Read(reader);
        _nodeWeight2.Read(reader);
        _nodeWeight3.Read(reader);
        _nodeWeight4.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _text.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _text.Write(bw);
        _position.Write(bw);
        _nodeIndex.Write(bw);
        _nodeIndex2.Write(bw);
        _nodeIndex3.Write(bw);
        _nodeIndex4.Write(bw);
        _nodeWeight.Write(bw);
        _nodeWeight2.Write(bw);
        _nodeWeight3.Write(bw);
        _nodeWeight4.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _text.WriteBinary(writer);
      }
    }
    public class PointToPathCurveBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Block _points = new Block();
      public BlockCollection<PointToPathCurvePointBlockBlock> _pointsList = new BlockCollection<PointToPathCurvePointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PointToPathCurveBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<PointToPathCurvePointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeIndex {
        get {
          return this._nodeIndex;
        }
        set {
          this._nodeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeIndex.Read(reader);
        _unnamed0.Read(reader);
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new PointToPathCurvePointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeIndex.Write(bw);
        _unnamed0.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class PointToPathCurvePointBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Real _tValue = new Real();
public event System.EventHandler BlockNameChanged;
      public PointToPathCurvePointBlockBlock() {
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Real TValue {
        get {
          return this._tValue;
        }
        set {
          this._tValue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _tValue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _tValue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class LimitedHingeConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _limitFriction = new Real();
      private Real _limitMinAngle = new Real();
      private Real _limitMaxAngle = new Real();
public event System.EventHandler BlockNameChanged;
      public LimitedHingeConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public Real LimitFriction {
        get {
          return this._limitFriction;
        }
        set {
          this._limitFriction = value;
        }
      }
      public Real LimitMinAngle {
        get {
          return this._limitMinAngle;
        }
        set {
          this._limitMinAngle = value;
        }
      }
      public Real LimitMaxAngle {
        get {
          return this._limitMaxAngle;
        }
        set {
          this._limitMaxAngle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _limitFriction.Read(reader);
        _limitMinAngle.Read(reader);
        _limitMaxAngle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _limitFriction.Write(bw);
        _limitMinAngle.Write(bw);
        _limitMaxAngle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class BallAndSocketConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public BallAndSocketConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class StiffSpringConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _springlength = new Real();
public event System.EventHandler BlockNameChanged;
      public StiffSpringConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public Real Springlength {
        get {
          return this._springlength;
        }
        set {
          this._springlength = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _springlength.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _springlength.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PrismaticConstraintsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nodeA = new ShortBlockIndex();
      private ShortBlockIndex _nodeB = new ShortBlockIndex();
      private Real _aScale = new Real();
      private RealVector3D _aForward = new RealVector3D();
      private RealVector3D _aLeft = new RealVector3D();
      private RealVector3D _aUp = new RealVector3D();
      private RealPoint3D _aPosition = new RealPoint3D();
      private Real _bScale = new Real();
      private RealVector3D _bForward = new RealVector3D();
      private RealVector3D _bLeft = new RealVector3D();
      private RealVector3D _bUp = new RealVector3D();
      private RealPoint3D _bPosition = new RealPoint3D();
      private ShortBlockIndex _edgeIndex = new ShortBlockIndex();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _minlimit = new Real();
      private Real _maxlimit = new Real();
      private Real _maxfrictionforce = new Real();
public event System.EventHandler BlockNameChanged;
      public PrismaticConstraintsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex NodeA {
        get {
          return this._nodeA;
        }
        set {
          this._nodeA = value;
        }
      }
      public ShortBlockIndex NodeB {
        get {
          return this._nodeB;
        }
        set {
          this._nodeB = value;
        }
      }
      public Real AScale {
        get {
          return this._aScale;
        }
        set {
          this._aScale = value;
        }
      }
      public RealVector3D AForward {
        get {
          return this._aForward;
        }
        set {
          this._aForward = value;
        }
      }
      public RealVector3D ALeft {
        get {
          return this._aLeft;
        }
        set {
          this._aLeft = value;
        }
      }
      public RealVector3D AUp {
        get {
          return this._aUp;
        }
        set {
          this._aUp = value;
        }
      }
      public RealPoint3D APosition {
        get {
          return this._aPosition;
        }
        set {
          this._aPosition = value;
        }
      }
      public Real BScale {
        get {
          return this._bScale;
        }
        set {
          this._bScale = value;
        }
      }
      public RealVector3D BForward {
        get {
          return this._bForward;
        }
        set {
          this._bForward = value;
        }
      }
      public RealVector3D BLeft {
        get {
          return this._bLeft;
        }
        set {
          this._bLeft = value;
        }
      }
      public RealVector3D BUp {
        get {
          return this._bUp;
        }
        set {
          this._bUp = value;
        }
      }
      public RealPoint3D BPosition {
        get {
          return this._bPosition;
        }
        set {
          this._bPosition = value;
        }
      }
      public ShortBlockIndex EdgeIndex {
        get {
          return this._edgeIndex;
        }
        set {
          this._edgeIndex = value;
        }
      }
      public Real Minlimit {
        get {
          return this._minlimit;
        }
        set {
          this._minlimit = value;
        }
      }
      public Real Maxlimit {
        get {
          return this._maxlimit;
        }
        set {
          this._maxlimit = value;
        }
      }
      public Real Maxfrictionforce {
        get {
          return this._maxfrictionforce;
        }
        set {
          this._maxfrictionforce = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeA.Read(reader);
        _nodeB.Read(reader);
        _aScale.Read(reader);
        _aForward.Read(reader);
        _aLeft.Read(reader);
        _aUp.Read(reader);
        _aPosition.Read(reader);
        _bScale.Read(reader);
        _bForward.Read(reader);
        _bLeft.Read(reader);
        _bUp.Read(reader);
        _bPosition.Read(reader);
        _edgeIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _minlimit.Read(reader);
        _maxlimit.Read(reader);
        _maxfrictionforce.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeA.Write(bw);
        _nodeB.Write(bw);
        _aScale.Write(bw);
        _aForward.Write(bw);
        _aLeft.Write(bw);
        _aUp.Write(bw);
        _aPosition.Write(bw);
        _bScale.Write(bw);
        _bForward.Write(bw);
        _bLeft.Write(bw);
        _bUp.Write(bw);
        _bPosition.Write(bw);
        _edgeIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _minlimit.Write(bw);
        _maxlimit.Write(bw);
        _maxfrictionforce.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class PhantomsBlockBlock : IBlock {
      private Skip _unnamed0;
      private ShortInteger _size = new ShortInteger();
      private ShortInteger _count = new ShortInteger();
      private Skip _unnamed1;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Skip _unnamed4;
      private ShortInteger _size2 = new ShortInteger();
      private ShortInteger _count2 = new ShortInteger();
      private Skip _unnamed5;
public event System.EventHandler BlockNameChanged;
      public PhantomsBlockBlock() {
        this._unnamed0 = new Skip(4);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Skip(4);
        this._unnamed5 = new Skip(4);
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
      public ShortInteger Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public ShortInteger Count {
        get {
          return this._count;
        }
        set {
          this._count = value;
        }
      }
      public ShortInteger Size2 {
        get {
          return this._size2;
        }
        set {
          this._size2 = value;
        }
      }
      public ShortInteger Count2 {
        get {
          return this._count2;
        }
        set {
          this._count2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _size.Read(reader);
        _count.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _size2.Read(reader);
        _count2.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _size.Write(bw);
        _count.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _size2.Write(bw);
        _count2.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
