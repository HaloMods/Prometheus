// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'model'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class model : Interfaces.Pool.Tag {
    private ModelBlockBlock modelValues = new ModelBlockBlock();
    public virtual ModelBlockBlock ModelValues {
      get {
        return modelValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ModelValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "model";
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
modelValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
modelValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
modelValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
modelValues.WriteChildData(writer);
    }
    #endregion
    public class ModelBlockBlock : IBlock {
      private TagReference _renderModel = new TagReference();
      private TagReference _collisionModel = new TagReference();
      private TagReference _animation = new TagReference();
      private TagReference _physics = new TagReference();
      private TagReference _physicsmodel = new TagReference();
      private Real _disappearDistance = new Real();
      private Real _beginFadeDistance = new Real();
      private Pad _unnamed0;
      private Real _reduceToL1 = new Real();
      private Real _reduceToL2 = new Real();
      private Real _reduceToL3 = new Real();
      private Real _reduceToL4 = new Real();
      private Real _reduceToL5 = new Real();
      private Skip _unnamed1;
      private Enum _shadowFadeDistance;
      private Pad _unnamed2;
      private Block _variants = new Block();
      private Block _materials = new Block();
      private Block _newDamageInfo = new Block();
      private Block _targets = new Block();
      private Block _unnamed3 = new Block();
      private Block _unnamed4 = new Block();
      private Pad _unnamed5;
      private Block _modelObjectData = new Block();
      private TagReference _defaultDialogue = new TagReference();
      private TagReference _uNUSED = new TagReference();
      private Flags _flags;
      private StringId _defaultDialogueEffect = new StringId();
      private CharInteger _unnamed6 = new CharInteger();
      private CharInteger _unnamed7 = new CharInteger();
      private CharInteger _unnamed8 = new CharInteger();
      private CharInteger _unnamed9 = new CharInteger();
      private CharInteger _unnamed10 = new CharInteger();
      private CharInteger _unnamed11 = new CharInteger();
      private CharInteger _unnamed12 = new CharInteger();
      private CharInteger _unnamed13 = new CharInteger();
      private CharInteger _unnamed14 = new CharInteger();
      private CharInteger _unnamed15 = new CharInteger();
      private CharInteger _unnamed16 = new CharInteger();
      private CharInteger _unnamed17 = new CharInteger();
      private CharInteger _unnamed18 = new CharInteger();
      private CharInteger _unnamed19 = new CharInteger();
      private CharInteger _unnamed20 = new CharInteger();
      private CharInteger _unnamed21 = new CharInteger();
      private CharInteger _unnamed22 = new CharInteger();
      private CharInteger _unnamed23 = new CharInteger();
      private CharInteger _unnamed24 = new CharInteger();
      private CharInteger _unnamed25 = new CharInteger();
      private CharInteger _unnamed26 = new CharInteger();
      private CharInteger _unnamed27 = new CharInteger();
      private CharInteger _unnamed28 = new CharInteger();
      private CharInteger _unnamed29 = new CharInteger();
      private CharInteger _unnamed30 = new CharInteger();
      private CharInteger _unnamed31 = new CharInteger();
      private CharInteger _unnamed32 = new CharInteger();
      private CharInteger _unnamed33 = new CharInteger();
      private CharInteger _unnamed34 = new CharInteger();
      private CharInteger _unnamed35 = new CharInteger();
      private CharInteger _unnamed36 = new CharInteger();
      private CharInteger _unnamed37 = new CharInteger();
      private CharInteger _unnamed38 = new CharInteger();
      private CharInteger _unnamed39 = new CharInteger();
      private CharInteger _unnamed40 = new CharInteger();
      private CharInteger _unnamed41 = new CharInteger();
      private CharInteger _unnamed42 = new CharInteger();
      private CharInteger _unnamed43 = new CharInteger();
      private CharInteger _unnamed44 = new CharInteger();
      private CharInteger _unnamed45 = new CharInteger();
      private CharInteger _unnamed46 = new CharInteger();
      private CharInteger _unnamed47 = new CharInteger();
      private CharInteger _unnamed48 = new CharInteger();
      private CharInteger _unnamed49 = new CharInteger();
      private CharInteger _unnamed50 = new CharInteger();
      private CharInteger _unnamed51 = new CharInteger();
      private CharInteger _unnamed52 = new CharInteger();
      private CharInteger _unnamed53 = new CharInteger();
      private CharInteger _unnamed54 = new CharInteger();
      private CharInteger _unnamed55 = new CharInteger();
      private CharInteger _unnamed56 = new CharInteger();
      private CharInteger _unnamed57 = new CharInteger();
      private CharInteger _unnamed58 = new CharInteger();
      private CharInteger _unnamed59 = new CharInteger();
      private CharInteger _unnamed60 = new CharInteger();
      private CharInteger _unnamed61 = new CharInteger();
      private CharInteger _unnamed62 = new CharInteger();
      private CharInteger _unnamed63 = new CharInteger();
      private CharInteger _unnamed64 = new CharInteger();
      private CharInteger _unnamed65 = new CharInteger();
      private CharInteger _unnamed66 = new CharInteger();
      private CharInteger _unnamed67 = new CharInteger();
      private CharInteger _unnamed68 = new CharInteger();
      private CharInteger _unnamed69 = new CharInteger();
      private Flags _runtimeFlags;
      private Block _scenarioLoadParameters = new Block();
      private TagReference _hologramShader = new TagReference();
      private StringId _hologramControlFunction = new StringId();
      public BlockCollection<ModelVariantBlockBlock> _variantsList = new BlockCollection<ModelVariantBlockBlock>();
      public BlockCollection<ModelMaterialBlockBlock> _materialsList = new BlockCollection<ModelMaterialBlockBlock>();
      public BlockCollection<GlobalDamageInfoBlockBlock> _newDamageInfoList = new BlockCollection<GlobalDamageInfoBlockBlock>();
      public BlockCollection<ModelTargetBlockBlock> _targetsList = new BlockCollection<ModelTargetBlockBlock>();
      public BlockCollection<ModelRegionBlockBlock> _unnamed3List = new BlockCollection<ModelRegionBlockBlock>();
      public BlockCollection<ModelNodeBlockBlock> _unnamed4List = new BlockCollection<ModelNodeBlockBlock>();
      public BlockCollection<ModelObjectDataBlockBlock> _modelObjectDataList = new BlockCollection<ModelObjectDataBlockBlock>();
      public BlockCollection<GlobalScenarioLoadParametersBlockBlock> _scenarioLoadParametersList = new BlockCollection<GlobalScenarioLoadParametersBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Skip(4);
        this._shadowFadeDistance = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._flags = new Flags(4);
        this._runtimeFlags = new Flags(4);
      }
      public BlockCollection<ModelVariantBlockBlock> Variants {
        get {
          return this._variantsList;
        }
      }
      public BlockCollection<ModelMaterialBlockBlock> Materials {
        get {
          return this._materialsList;
        }
      }
      public BlockCollection<GlobalDamageInfoBlockBlock> NewDamageInfo {
        get {
          return this._newDamageInfoList;
        }
      }
      public BlockCollection<ModelTargetBlockBlock> Targets {
        get {
          return this._targetsList;
        }
      }
      public BlockCollection<ModelRegionBlockBlock> Unnamed3 {
        get {
          return this._unnamed3List;
        }
      }
      public BlockCollection<ModelNodeBlockBlock> Unnamed4 {
        get {
          return this._unnamed4List;
        }
      }
      public BlockCollection<ModelObjectDataBlockBlock> ModelObjectData {
        get {
          return this._modelObjectDataList;
        }
      }
      public BlockCollection<GlobalScenarioLoadParametersBlockBlock> ScenarioLoadParameters {
        get {
          return this._scenarioLoadParametersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_renderModel.Value);
references.Add(_collisionModel.Value);
references.Add(_animation.Value);
references.Add(_physics.Value);
references.Add(_physicsmodel.Value);
references.Add(_defaultDialogue.Value);
references.Add(_uNUSED.Value);
references.Add(_hologramShader.Value);
for (int x=0; x<Variants.BlockCount; x++)
{
  IBlock block = Variants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Materials.BlockCount; x++)
{
  IBlock block = Materials.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NewDamageInfo.BlockCount; x++)
{
  IBlock block = NewDamageInfo.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Targets.BlockCount; x++)
{
  IBlock block = Targets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed3.BlockCount; x++)
{
  IBlock block = Unnamed3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed4.BlockCount; x++)
{
  IBlock block = Unnamed4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ModelObjectData.BlockCount; x++)
{
  IBlock block = ModelObjectData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScenarioLoadParameters.BlockCount; x++)
{
  IBlock block = ScenarioLoadParameters.GetBlock(x);
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
      public TagReference RenderModel {
        get {
          return this._renderModel;
        }
        set {
          this._renderModel = value;
        }
      }
      public TagReference CollisionModel {
        get {
          return this._collisionModel;
        }
        set {
          this._collisionModel = value;
        }
      }
      public TagReference Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public TagReference Physics {
        get {
          return this._physics;
        }
        set {
          this._physics = value;
        }
      }
      public TagReference Physicsmodel {
        get {
          return this._physicsmodel;
        }
        set {
          this._physicsmodel = value;
        }
      }
      public Real DisappearDistance {
        get {
          return this._disappearDistance;
        }
        set {
          this._disappearDistance = value;
        }
      }
      public Real BeginFadeDistance {
        get {
          return this._beginFadeDistance;
        }
        set {
          this._beginFadeDistance = value;
        }
      }
      public Real ReduceToL1 {
        get {
          return this._reduceToL1;
        }
        set {
          this._reduceToL1 = value;
        }
      }
      public Real ReduceToL2 {
        get {
          return this._reduceToL2;
        }
        set {
          this._reduceToL2 = value;
        }
      }
      public Real ReduceToL3 {
        get {
          return this._reduceToL3;
        }
        set {
          this._reduceToL3 = value;
        }
      }
      public Real ReduceToL4 {
        get {
          return this._reduceToL4;
        }
        set {
          this._reduceToL4 = value;
        }
      }
      public Real ReduceToL5 {
        get {
          return this._reduceToL5;
        }
        set {
          this._reduceToL5 = value;
        }
      }
      public Enum ShadowFadeDistance {
        get {
          return this._shadowFadeDistance;
        }
        set {
          this._shadowFadeDistance = value;
        }
      }
      public TagReference DefaultDialogue {
        get {
          return this._defaultDialogue;
        }
        set {
          this._defaultDialogue = value;
        }
      }
      public TagReference UNUSED {
        get {
          return this._uNUSED;
        }
        set {
          this._uNUSED = value;
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
      public StringId DefaultDialogueEffect {
        get {
          return this._defaultDialogueEffect;
        }
        set {
          this._defaultDialogueEffect = value;
        }
      }
      public CharInteger unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public CharInteger unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public CharInteger unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public CharInteger unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public CharInteger unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public CharInteger unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public CharInteger unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public CharInteger unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public CharInteger unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
        }
      }
      public CharInteger unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public CharInteger unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
        }
      }
      public CharInteger unnamed17 {
        get {
          return this._unnamed17;
        }
        set {
          this._unnamed17 = value;
        }
      }
      public CharInteger unnamed18 {
        get {
          return this._unnamed18;
        }
        set {
          this._unnamed18 = value;
        }
      }
      public CharInteger unnamed19 {
        get {
          return this._unnamed19;
        }
        set {
          this._unnamed19 = value;
        }
      }
      public CharInteger unnamed20 {
        get {
          return this._unnamed20;
        }
        set {
          this._unnamed20 = value;
        }
      }
      public CharInteger unnamed21 {
        get {
          return this._unnamed21;
        }
        set {
          this._unnamed21 = value;
        }
      }
      public CharInteger unnamed22 {
        get {
          return this._unnamed22;
        }
        set {
          this._unnamed22 = value;
        }
      }
      public CharInteger unnamed23 {
        get {
          return this._unnamed23;
        }
        set {
          this._unnamed23 = value;
        }
      }
      public CharInteger unnamed24 {
        get {
          return this._unnamed24;
        }
        set {
          this._unnamed24 = value;
        }
      }
      public CharInteger unnamed25 {
        get {
          return this._unnamed25;
        }
        set {
          this._unnamed25 = value;
        }
      }
      public CharInteger unnamed26 {
        get {
          return this._unnamed26;
        }
        set {
          this._unnamed26 = value;
        }
      }
      public CharInteger unnamed27 {
        get {
          return this._unnamed27;
        }
        set {
          this._unnamed27 = value;
        }
      }
      public CharInteger unnamed28 {
        get {
          return this._unnamed28;
        }
        set {
          this._unnamed28 = value;
        }
      }
      public CharInteger unnamed29 {
        get {
          return this._unnamed29;
        }
        set {
          this._unnamed29 = value;
        }
      }
      public CharInteger unnamed30 {
        get {
          return this._unnamed30;
        }
        set {
          this._unnamed30 = value;
        }
      }
      public CharInteger unnamed31 {
        get {
          return this._unnamed31;
        }
        set {
          this._unnamed31 = value;
        }
      }
      public CharInteger unnamed32 {
        get {
          return this._unnamed32;
        }
        set {
          this._unnamed32 = value;
        }
      }
      public CharInteger unnamed33 {
        get {
          return this._unnamed33;
        }
        set {
          this._unnamed33 = value;
        }
      }
      public CharInteger unnamed34 {
        get {
          return this._unnamed34;
        }
        set {
          this._unnamed34 = value;
        }
      }
      public CharInteger unnamed35 {
        get {
          return this._unnamed35;
        }
        set {
          this._unnamed35 = value;
        }
      }
      public CharInteger unnamed36 {
        get {
          return this._unnamed36;
        }
        set {
          this._unnamed36 = value;
        }
      }
      public CharInteger unnamed37 {
        get {
          return this._unnamed37;
        }
        set {
          this._unnamed37 = value;
        }
      }
      public CharInteger unnamed38 {
        get {
          return this._unnamed38;
        }
        set {
          this._unnamed38 = value;
        }
      }
      public CharInteger unnamed39 {
        get {
          return this._unnamed39;
        }
        set {
          this._unnamed39 = value;
        }
      }
      public CharInteger unnamed40 {
        get {
          return this._unnamed40;
        }
        set {
          this._unnamed40 = value;
        }
      }
      public CharInteger unnamed41 {
        get {
          return this._unnamed41;
        }
        set {
          this._unnamed41 = value;
        }
      }
      public CharInteger unnamed42 {
        get {
          return this._unnamed42;
        }
        set {
          this._unnamed42 = value;
        }
      }
      public CharInteger unnamed43 {
        get {
          return this._unnamed43;
        }
        set {
          this._unnamed43 = value;
        }
      }
      public CharInteger unnamed44 {
        get {
          return this._unnamed44;
        }
        set {
          this._unnamed44 = value;
        }
      }
      public CharInteger unnamed45 {
        get {
          return this._unnamed45;
        }
        set {
          this._unnamed45 = value;
        }
      }
      public CharInteger unnamed46 {
        get {
          return this._unnamed46;
        }
        set {
          this._unnamed46 = value;
        }
      }
      public CharInteger unnamed47 {
        get {
          return this._unnamed47;
        }
        set {
          this._unnamed47 = value;
        }
      }
      public CharInteger unnamed48 {
        get {
          return this._unnamed48;
        }
        set {
          this._unnamed48 = value;
        }
      }
      public CharInteger unnamed49 {
        get {
          return this._unnamed49;
        }
        set {
          this._unnamed49 = value;
        }
      }
      public CharInteger unnamed50 {
        get {
          return this._unnamed50;
        }
        set {
          this._unnamed50 = value;
        }
      }
      public CharInteger unnamed51 {
        get {
          return this._unnamed51;
        }
        set {
          this._unnamed51 = value;
        }
      }
      public CharInteger unnamed52 {
        get {
          return this._unnamed52;
        }
        set {
          this._unnamed52 = value;
        }
      }
      public CharInteger unnamed53 {
        get {
          return this._unnamed53;
        }
        set {
          this._unnamed53 = value;
        }
      }
      public CharInteger unnamed54 {
        get {
          return this._unnamed54;
        }
        set {
          this._unnamed54 = value;
        }
      }
      public CharInteger unnamed55 {
        get {
          return this._unnamed55;
        }
        set {
          this._unnamed55 = value;
        }
      }
      public CharInteger unnamed56 {
        get {
          return this._unnamed56;
        }
        set {
          this._unnamed56 = value;
        }
      }
      public CharInteger unnamed57 {
        get {
          return this._unnamed57;
        }
        set {
          this._unnamed57 = value;
        }
      }
      public CharInteger unnamed58 {
        get {
          return this._unnamed58;
        }
        set {
          this._unnamed58 = value;
        }
      }
      public CharInteger unnamed59 {
        get {
          return this._unnamed59;
        }
        set {
          this._unnamed59 = value;
        }
      }
      public CharInteger unnamed60 {
        get {
          return this._unnamed60;
        }
        set {
          this._unnamed60 = value;
        }
      }
      public CharInteger unnamed61 {
        get {
          return this._unnamed61;
        }
        set {
          this._unnamed61 = value;
        }
      }
      public CharInteger unnamed62 {
        get {
          return this._unnamed62;
        }
        set {
          this._unnamed62 = value;
        }
      }
      public CharInteger unnamed63 {
        get {
          return this._unnamed63;
        }
        set {
          this._unnamed63 = value;
        }
      }
      public CharInteger unnamed64 {
        get {
          return this._unnamed64;
        }
        set {
          this._unnamed64 = value;
        }
      }
      public CharInteger unnamed65 {
        get {
          return this._unnamed65;
        }
        set {
          this._unnamed65 = value;
        }
      }
      public CharInteger unnamed66 {
        get {
          return this._unnamed66;
        }
        set {
          this._unnamed66 = value;
        }
      }
      public CharInteger unnamed67 {
        get {
          return this._unnamed67;
        }
        set {
          this._unnamed67 = value;
        }
      }
      public CharInteger unnamed68 {
        get {
          return this._unnamed68;
        }
        set {
          this._unnamed68 = value;
        }
      }
      public CharInteger unnamed69 {
        get {
          return this._unnamed69;
        }
        set {
          this._unnamed69 = value;
        }
      }
      public Flags RuntimeFlags {
        get {
          return this._runtimeFlags;
        }
        set {
          this._runtimeFlags = value;
        }
      }
      public TagReference HologramShader {
        get {
          return this._hologramShader;
        }
        set {
          this._hologramShader = value;
        }
      }
      public StringId HologramControlFunction {
        get {
          return this._hologramControlFunction;
        }
        set {
          this._hologramControlFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _renderModel.Read(reader);
        _collisionModel.Read(reader);
        _animation.Read(reader);
        _physics.Read(reader);
        _physicsmodel.Read(reader);
        _disappearDistance.Read(reader);
        _beginFadeDistance.Read(reader);
        _unnamed0.Read(reader);
        _reduceToL1.Read(reader);
        _reduceToL2.Read(reader);
        _reduceToL3.Read(reader);
        _reduceToL4.Read(reader);
        _reduceToL5.Read(reader);
        _unnamed1.Read(reader);
        _shadowFadeDistance.Read(reader);
        _unnamed2.Read(reader);
        _variants.Read(reader);
        _materials.Read(reader);
        _newDamageInfo.Read(reader);
        _targets.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _modelObjectData.Read(reader);
        _defaultDialogue.Read(reader);
        _uNUSED.Read(reader);
        _flags.Read(reader);
        _defaultDialogueEffect.Read(reader);
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
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _unnamed20.Read(reader);
        _unnamed21.Read(reader);
        _unnamed22.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _unnamed25.Read(reader);
        _unnamed26.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
        _unnamed29.Read(reader);
        _unnamed30.Read(reader);
        _unnamed31.Read(reader);
        _unnamed32.Read(reader);
        _unnamed33.Read(reader);
        _unnamed34.Read(reader);
        _unnamed35.Read(reader);
        _unnamed36.Read(reader);
        _unnamed37.Read(reader);
        _unnamed38.Read(reader);
        _unnamed39.Read(reader);
        _unnamed40.Read(reader);
        _unnamed41.Read(reader);
        _unnamed42.Read(reader);
        _unnamed43.Read(reader);
        _unnamed44.Read(reader);
        _unnamed45.Read(reader);
        _unnamed46.Read(reader);
        _unnamed47.Read(reader);
        _unnamed48.Read(reader);
        _unnamed49.Read(reader);
        _unnamed50.Read(reader);
        _unnamed51.Read(reader);
        _unnamed52.Read(reader);
        _unnamed53.Read(reader);
        _unnamed54.Read(reader);
        _unnamed55.Read(reader);
        _unnamed56.Read(reader);
        _unnamed57.Read(reader);
        _unnamed58.Read(reader);
        _unnamed59.Read(reader);
        _unnamed60.Read(reader);
        _unnamed61.Read(reader);
        _unnamed62.Read(reader);
        _unnamed63.Read(reader);
        _unnamed64.Read(reader);
        _unnamed65.Read(reader);
        _unnamed66.Read(reader);
        _unnamed67.Read(reader);
        _unnamed68.Read(reader);
        _unnamed69.Read(reader);
        _runtimeFlags.Read(reader);
        _scenarioLoadParameters.Read(reader);
        _hologramShader.Read(reader);
        _hologramControlFunction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _renderModel.ReadString(reader);
        _collisionModel.ReadString(reader);
        _animation.ReadString(reader);
        _physics.ReadString(reader);
        _physicsmodel.ReadString(reader);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants.Add(new ModelVariantBlockBlock());
          Variants[x].Read(reader);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials.Add(new ModelMaterialBlockBlock());
          Materials[x].Read(reader);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].ReadChildData(reader);
        }
        for (x = 0; (x < _newDamageInfo.Count); x = (x + 1)) {
          NewDamageInfo.Add(new GlobalDamageInfoBlockBlock());
          NewDamageInfo[x].Read(reader);
        }
        for (x = 0; (x < _newDamageInfo.Count); x = (x + 1)) {
          NewDamageInfo[x].ReadChildData(reader);
        }
        for (x = 0; (x < _targets.Count); x = (x + 1)) {
          Targets.Add(new ModelTargetBlockBlock());
          Targets[x].Read(reader);
        }
        for (x = 0; (x < _targets.Count); x = (x + 1)) {
          Targets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3.Add(new ModelRegionBlockBlock());
          Unnamed3[x].Read(reader);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4.Add(new ModelNodeBlockBlock());
          Unnamed4[x].Read(reader);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modelObjectData.Count); x = (x + 1)) {
          ModelObjectData.Add(new ModelObjectDataBlockBlock());
          ModelObjectData[x].Read(reader);
        }
        for (x = 0; (x < _modelObjectData.Count); x = (x + 1)) {
          ModelObjectData[x].ReadChildData(reader);
        }
        _defaultDialogue.ReadString(reader);
        _uNUSED.ReadString(reader);
        _defaultDialogueEffect.ReadString(reader);
        for (x = 0; (x < _scenarioLoadParameters.Count); x = (x + 1)) {
          ScenarioLoadParameters.Add(new GlobalScenarioLoadParametersBlockBlock());
          ScenarioLoadParameters[x].Read(reader);
        }
        for (x = 0; (x < _scenarioLoadParameters.Count); x = (x + 1)) {
          ScenarioLoadParameters[x].ReadChildData(reader);
        }
        _hologramShader.ReadString(reader);
        _hologramControlFunction.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _renderModel.Write(bw);
        _collisionModel.Write(bw);
        _animation.Write(bw);
        _physics.Write(bw);
        _physicsmodel.Write(bw);
        _disappearDistance.Write(bw);
        _beginFadeDistance.Write(bw);
        _unnamed0.Write(bw);
        _reduceToL1.Write(bw);
        _reduceToL2.Write(bw);
        _reduceToL3.Write(bw);
        _reduceToL4.Write(bw);
        _reduceToL5.Write(bw);
        _unnamed1.Write(bw);
        _shadowFadeDistance.Write(bw);
        _unnamed2.Write(bw);
_variants.Count = Variants.Count;
        _variants.Write(bw);
_materials.Count = Materials.Count;
        _materials.Write(bw);
_newDamageInfo.Count = NewDamageInfo.Count;
        _newDamageInfo.Write(bw);
_targets.Count = Targets.Count;
        _targets.Write(bw);
_unnamed3.Count = Unnamed3.Count;
        _unnamed3.Write(bw);
_unnamed4.Count = Unnamed4.Count;
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
_modelObjectData.Count = ModelObjectData.Count;
        _modelObjectData.Write(bw);
        _defaultDialogue.Write(bw);
        _uNUSED.Write(bw);
        _flags.Write(bw);
        _defaultDialogueEffect.Write(bw);
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
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _unnamed20.Write(bw);
        _unnamed21.Write(bw);
        _unnamed22.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _unnamed25.Write(bw);
        _unnamed26.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
        _unnamed29.Write(bw);
        _unnamed30.Write(bw);
        _unnamed31.Write(bw);
        _unnamed32.Write(bw);
        _unnamed33.Write(bw);
        _unnamed34.Write(bw);
        _unnamed35.Write(bw);
        _unnamed36.Write(bw);
        _unnamed37.Write(bw);
        _unnamed38.Write(bw);
        _unnamed39.Write(bw);
        _unnamed40.Write(bw);
        _unnamed41.Write(bw);
        _unnamed42.Write(bw);
        _unnamed43.Write(bw);
        _unnamed44.Write(bw);
        _unnamed45.Write(bw);
        _unnamed46.Write(bw);
        _unnamed47.Write(bw);
        _unnamed48.Write(bw);
        _unnamed49.Write(bw);
        _unnamed50.Write(bw);
        _unnamed51.Write(bw);
        _unnamed52.Write(bw);
        _unnamed53.Write(bw);
        _unnamed54.Write(bw);
        _unnamed55.Write(bw);
        _unnamed56.Write(bw);
        _unnamed57.Write(bw);
        _unnamed58.Write(bw);
        _unnamed59.Write(bw);
        _unnamed60.Write(bw);
        _unnamed61.Write(bw);
        _unnamed62.Write(bw);
        _unnamed63.Write(bw);
        _unnamed64.Write(bw);
        _unnamed65.Write(bw);
        _unnamed66.Write(bw);
        _unnamed67.Write(bw);
        _unnamed68.Write(bw);
        _unnamed69.Write(bw);
        _runtimeFlags.Write(bw);
_scenarioLoadParameters.Count = ScenarioLoadParameters.Count;
        _scenarioLoadParameters.Write(bw);
        _hologramShader.Write(bw);
        _hologramControlFunction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _renderModel.WriteString(writer);
        _collisionModel.WriteString(writer);
        _animation.WriteString(writer);
        _physics.WriteString(writer);
        _physicsmodel.WriteString(writer);
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].Write(writer);
        }
        for (x = 0; (x < _variants.Count); x = (x + 1)) {
          Variants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].Write(writer);
        }
        for (x = 0; (x < _materials.Count); x = (x + 1)) {
          Materials[x].WriteChildData(writer);
        }
        for (x = 0; (x < _newDamageInfo.Count); x = (x + 1)) {
          NewDamageInfo[x].Write(writer);
        }
        for (x = 0; (x < _newDamageInfo.Count); x = (x + 1)) {
          NewDamageInfo[x].WriteChildData(writer);
        }
        for (x = 0; (x < _targets.Count); x = (x + 1)) {
          Targets[x].Write(writer);
        }
        for (x = 0; (x < _targets.Count); x = (x + 1)) {
          Targets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].Write(writer);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].Write(writer);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modelObjectData.Count); x = (x + 1)) {
          ModelObjectData[x].Write(writer);
        }
        for (x = 0; (x < _modelObjectData.Count); x = (x + 1)) {
          ModelObjectData[x].WriteChildData(writer);
        }
        _defaultDialogue.WriteString(writer);
        _uNUSED.WriteString(writer);
        _defaultDialogueEffect.WriteString(writer);
        for (x = 0; (x < _scenarioLoadParameters.Count); x = (x + 1)) {
          ScenarioLoadParameters[x].Write(writer);
        }
        for (x = 0; (x < _scenarioLoadParameters.Count); x = (x + 1)) {
          ScenarioLoadParameters[x].WriteChildData(writer);
        }
        _hologramShader.WriteString(writer);
        _hologramControlFunction.WriteString(writer);
      }
    }
    public class ModelVariantBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Pad _unnamed0;
      private Block _regions = new Block();
      private Block _objects = new Block();
      private Pad _unnamed1;
      private StringId _dialogueSoundEffect = new StringId();
      private TagReference _dialogue = new TagReference();
      public BlockCollection<ModelVariantRegionBlockBlock> _regionsList = new BlockCollection<ModelVariantRegionBlockBlock>();
      public BlockCollection<ModelVariantObjectBlockBlock> _objectsList = new BlockCollection<ModelVariantObjectBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelVariantBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(16);
        this._unnamed1 = new Pad(8);
      }
      public BlockCollection<ModelVariantRegionBlockBlock> Regions {
        get {
          return this._regionsList;
        }
      }
      public BlockCollection<ModelVariantObjectBlockBlock> Objects {
        get {
          return this._objectsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dialogue.Value);
for (int x=0; x<Regions.BlockCount; x++)
{
  IBlock block = Regions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Objects.BlockCount; x++)
{
  IBlock block = Objects.GetBlock(x);
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
      public StringId DialogueSoundEffect {
        get {
          return this._dialogueSoundEffect;
        }
        set {
          this._dialogueSoundEffect = value;
        }
      }
      public TagReference Dialogue {
        get {
          return this._dialogue;
        }
        set {
          this._dialogue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed0.Read(reader);
        _regions.Read(reader);
        _objects.Read(reader);
        _unnamed1.Read(reader);
        _dialogueSoundEffect.Read(reader);
        _dialogue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions.Add(new ModelVariantRegionBlockBlock());
          Regions[x].Read(reader);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects.Add(new ModelVariantObjectBlockBlock());
          Objects[x].Read(reader);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].ReadChildData(reader);
        }
        _dialogueSoundEffect.ReadString(reader);
        _dialogue.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
_regions.Count = Regions.Count;
        _regions.Write(bw);
_objects.Count = Objects.Count;
        _objects.Write(bw);
        _unnamed1.Write(bw);
        _dialogueSoundEffect.Write(bw);
        _dialogue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].Write(writer);
        }
        for (x = 0; (x < _regions.Count); x = (x + 1)) {
          Regions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].Write(writer);
        }
        for (x = 0; (x < _objects.Count); x = (x + 1)) {
          Objects[x].WriteChildData(writer);
        }
        _dialogueSoundEffect.WriteString(writer);
        _dialogue.WriteString(writer);
      }
    }
    public class ModelVariantRegionBlockBlock : IBlock {
      private StringId _regionName = new StringId();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private ShortBlockIndex _parentVariant = new ShortBlockIndex();
      private Block _permutations = new Block();
      private Enum _sortOrder;
      private Pad _unnamed2;
      public BlockCollection<ModelVariantPermutationBlockBlock> _permutationsList = new BlockCollection<ModelVariantPermutationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelVariantRegionBlockBlock() {
if (this._regionName is System.ComponentModel.INotifyPropertyChanged)
  (this._regionName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(1);
        this._unnamed1 = new Pad(1);
        this._sortOrder = new Enum(2);
        this._unnamed2 = new Pad(2);
      }
      public BlockCollection<ModelVariantPermutationBlockBlock> Permutations {
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
return _regionName.ToString();
        }
      }
      public StringId RegionName {
        get {
          return this._regionName;
        }
        set {
          this._regionName = value;
        }
      }
      public ShortBlockIndex ParentVariant {
        get {
          return this._parentVariant;
        }
        set {
          this._parentVariant = value;
        }
      }
      public Enum SortOrder {
        get {
          return this._sortOrder;
        }
        set {
          this._sortOrder = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _regionName.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _parentVariant.Read(reader);
        _permutations.Read(reader);
        _sortOrder.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _regionName.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new ModelVariantPermutationBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _regionName.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _parentVariant.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
        _sortOrder.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _regionName.WriteString(writer);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class ModelVariantPermutationBlockBlock : IBlock {
      private StringId _permutationName = new StringId();
      private Pad _unnamed0;
      private Flags _flags;
      private Pad _unnamed1;
      private Real _probability = new Real();
      private Block _states = new Block();
      private Pad _unnamed2;
      private Pad _unnamed3;
      public BlockCollection<ModelVariantStateBlockBlock> _statesList = new BlockCollection<ModelVariantStateBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelVariantPermutationBlockBlock() {
if (this._permutationName is System.ComponentModel.INotifyPropertyChanged)
  (this._permutationName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(1);
        this._flags = new Flags(1);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(5);
        this._unnamed3 = new Pad(7);
      }
      public BlockCollection<ModelVariantStateBlockBlock> States {
        get {
          return this._statesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<States.BlockCount; x++)
{
  IBlock block = States.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _permutationName.ToString();
        }
      }
      public StringId PermutationName {
        get {
          return this._permutationName;
        }
        set {
          this._permutationName = value;
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
      public Real Probability {
        get {
          return this._probability;
        }
        set {
          this._probability = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _permutationName.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _unnamed1.Read(reader);
        _probability.Read(reader);
        _states.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _permutationName.ReadString(reader);
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States.Add(new ModelVariantStateBlockBlock());
          States[x].Read(reader);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _permutationName.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _unnamed1.Write(bw);
        _probability.Write(bw);
_states.Count = States.Count;
        _states.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _permutationName.WriteString(writer);
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].Write(writer);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].WriteChildData(writer);
        }
      }
    }
    public class ModelVariantStateBlockBlock : IBlock {
      private StringId _permutationName = new StringId();
      private Pad _unnamed0;
      private Flags _propertyFlags;
      private Enum _state;
      private TagReference _loopingEffect = new TagReference();
      private StringId _loopingEffectMarkerName = new StringId();
      private RealFraction _initialProbability = new RealFraction();
public event System.EventHandler BlockNameChanged;
      public ModelVariantStateBlockBlock() {
if (this._state is System.ComponentModel.INotifyPropertyChanged)
  (this._state as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(1);
        this._propertyFlags = new Flags(1);
        this._state = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_loopingEffect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _state.ToString();
        }
      }
      public StringId PermutationName {
        get {
          return this._permutationName;
        }
        set {
          this._permutationName = value;
        }
      }
      public Flags PropertyFlags {
        get {
          return this._propertyFlags;
        }
        set {
          this._propertyFlags = value;
        }
      }
      public Enum State {
        get {
          return this._state;
        }
        set {
          this._state = value;
        }
      }
      public TagReference LoopingEffect {
        get {
          return this._loopingEffect;
        }
        set {
          this._loopingEffect = value;
        }
      }
      public StringId LoopingEffectMarkerName {
        get {
          return this._loopingEffectMarkerName;
        }
        set {
          this._loopingEffectMarkerName = value;
        }
      }
      public RealFraction InitialProbability {
        get {
          return this._initialProbability;
        }
        set {
          this._initialProbability = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _permutationName.Read(reader);
        _unnamed0.Read(reader);
        _propertyFlags.Read(reader);
        _state.Read(reader);
        _loopingEffect.Read(reader);
        _loopingEffectMarkerName.Read(reader);
        _initialProbability.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _permutationName.ReadString(reader);
        _loopingEffect.ReadString(reader);
        _loopingEffectMarkerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _permutationName.Write(bw);
        _unnamed0.Write(bw);
        _propertyFlags.Write(bw);
        _state.Write(bw);
        _loopingEffect.Write(bw);
        _loopingEffectMarkerName.Write(bw);
        _initialProbability.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _permutationName.WriteString(writer);
        _loopingEffect.WriteString(writer);
        _loopingEffectMarkerName.WriteString(writer);
      }
    }
    public class ModelVariantObjectBlockBlock : IBlock {
      private StringId _parentMarker = new StringId();
      private StringId _childMarker = new StringId();
      private TagReference _childObject = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ModelVariantObjectBlockBlock() {
if (this._parentMarker is System.ComponentModel.INotifyPropertyChanged)
  (this._parentMarker as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_childObject.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _parentMarker.ToString();
        }
      }
      public StringId ParentMarker {
        get {
          return this._parentMarker;
        }
        set {
          this._parentMarker = value;
        }
      }
      public StringId ChildMarker {
        get {
          return this._childMarker;
        }
        set {
          this._childMarker = value;
        }
      }
      public TagReference ChildObject {
        get {
          return this._childObject;
        }
        set {
          this._childObject = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parentMarker.Read(reader);
        _childMarker.Read(reader);
        _childObject.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _parentMarker.ReadString(reader);
        _childMarker.ReadString(reader);
        _childObject.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _parentMarker.Write(bw);
        _childMarker.Write(bw);
        _childObject.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _parentMarker.WriteString(writer);
        _childMarker.WriteString(writer);
        _childObject.WriteString(writer);
      }
    }
    public class ModelMaterialBlockBlock : IBlock {
      private StringId _materialName = new StringId();
      private Enum _materialType;
      private ShortInteger _damageSection = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private StringId _globalMaterialName = new StringId();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ModelMaterialBlockBlock() {
        this._materialType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
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
      public StringId MaterialName {
        get {
          return this._materialName;
        }
        set {
          this._materialName = value;
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
      public ShortInteger DamageSection {
        get {
          return this._damageSection;
        }
        set {
          this._damageSection = value;
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
      public virtual void Read(BinaryReader reader) {
        _materialName.Read(reader);
        _materialType.Read(reader);
        _damageSection.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _globalMaterialName.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _materialName.ReadString(reader);
        _globalMaterialName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _materialName.Write(bw);
        _materialType.Write(bw);
        _damageSection.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _globalMaterialName.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _materialName.WriteString(writer);
        _globalMaterialName.WriteString(writer);
      }
    }
    public class GlobalDamageInfoBlockBlock : IBlock {
      private Flags _flags;
      private StringId _globalIndirectMaterialName = new StringId();
      private ShortInteger _indirectDamageSection = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Enum _collisionDamageReportingType;
      private Enum _responseDamageReportingType;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Real _maximumVitality = new Real();
      private Real _minimumStunDamage = new Real();
      private Real _stunTime = new Real();
      private Real _rechargeTime = new Real();
      private RealFraction _rechargeFraction = new RealFraction();
      private Pad _unnamed4;
      private TagReference _shieldDamagedFirstPersonShader = new TagReference();
      private TagReference _shieldDamagedShader = new TagReference();
      private Real _maximumShieldVitality = new Real();
      private StringId _globalShieldMaterialName = new StringId();
      private Real _minimumStunDamage2 = new Real();
      private Real _stunTime2 = new Real();
      private Real _rechargeTime2 = new Real();
      private Real _shieldDamagedThreshold = new Real();
      private TagReference _shieldDamagedEffect = new TagReference();
      private TagReference _shieldDepletedEffect = new TagReference();
      private TagReference _shieldRechargingEffect = new TagReference();
      private Block _damageSections = new Block();
      private Block _nodes = new Block();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
      private Pad _unnamed8;
      private Block _damageSeats = new Block();
      private Block _damageConstraints = new Block();
      private TagReference _overshieldFirstPersonShader = new TagReference();
      private TagReference _overshieldShader = new TagReference();
      public BlockCollection<GlobalDamageSectionBlockBlock> _damageSectionsList = new BlockCollection<GlobalDamageSectionBlockBlock>();
      public BlockCollection<GlobalDamageNodesBlockBlock> _nodesList = new BlockCollection<GlobalDamageNodesBlockBlock>();
      public BlockCollection<DamageSeatInfoBlockBlock> _damageSeatsList = new BlockCollection<DamageSeatInfoBlockBlock>();
      public BlockCollection<DamageConstraintInfoBlockBlock> _damageConstraintsList = new BlockCollection<DamageConstraintInfoBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalDamageInfoBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._collisionDamageReportingType = new Enum(1);
        this._responseDamageReportingType = new Enum(1);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(20);
        this._unnamed4 = new Pad(64);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(4);
        this._unnamed8 = new Pad(4);
      }
      public BlockCollection<GlobalDamageSectionBlockBlock> DamageSections {
        get {
          return this._damageSectionsList;
        }
      }
      public BlockCollection<GlobalDamageNodesBlockBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<DamageSeatInfoBlockBlock> DamageSeats {
        get {
          return this._damageSeatsList;
        }
      }
      public BlockCollection<DamageConstraintInfoBlockBlock> DamageConstraints {
        get {
          return this._damageConstraintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shieldDamagedFirstPersonShader.Value);
references.Add(_shieldDamagedShader.Value);
references.Add(_shieldDamagedEffect.Value);
references.Add(_shieldDepletedEffect.Value);
references.Add(_shieldRechargingEffect.Value);
references.Add(_overshieldFirstPersonShader.Value);
references.Add(_overshieldShader.Value);
for (int x=0; x<DamageSections.BlockCount; x++)
{
  IBlock block = DamageSections.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DamageSeats.BlockCount; x++)
{
  IBlock block = DamageSeats.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DamageConstraints.BlockCount; x++)
{
  IBlock block = DamageConstraints.GetBlock(x);
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
      public StringId GlobalIndirectMaterialName {
        get {
          return this._globalIndirectMaterialName;
        }
        set {
          this._globalIndirectMaterialName = value;
        }
      }
      public ShortInteger IndirectDamageSection {
        get {
          return this._indirectDamageSection;
        }
        set {
          this._indirectDamageSection = value;
        }
      }
      public Enum CollisionDamageReportingType {
        get {
          return this._collisionDamageReportingType;
        }
        set {
          this._collisionDamageReportingType = value;
        }
      }
      public Enum ResponseDamageReportingType {
        get {
          return this._responseDamageReportingType;
        }
        set {
          this._responseDamageReportingType = value;
        }
      }
      public Real MaximumVitality {
        get {
          return this._maximumVitality;
        }
        set {
          this._maximumVitality = value;
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
      public RealFraction RechargeFraction {
        get {
          return this._rechargeFraction;
        }
        set {
          this._rechargeFraction = value;
        }
      }
      public TagReference ShieldDamagedFirstPersonShader {
        get {
          return this._shieldDamagedFirstPersonShader;
        }
        set {
          this._shieldDamagedFirstPersonShader = value;
        }
      }
      public TagReference ShieldDamagedShader {
        get {
          return this._shieldDamagedShader;
        }
        set {
          this._shieldDamagedShader = value;
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
      public StringId GlobalShieldMaterialName {
        get {
          return this._globalShieldMaterialName;
        }
        set {
          this._globalShieldMaterialName = value;
        }
      }
      public Real MinimumStunDamage2 {
        get {
          return this._minimumStunDamage2;
        }
        set {
          this._minimumStunDamage2 = value;
        }
      }
      public Real StunTime2 {
        get {
          return this._stunTime2;
        }
        set {
          this._stunTime2 = value;
        }
      }
      public Real RechargeTime2 {
        get {
          return this._rechargeTime2;
        }
        set {
          this._rechargeTime2 = value;
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
      public TagReference OvershieldFirstPersonShader {
        get {
          return this._overshieldFirstPersonShader;
        }
        set {
          this._overshieldFirstPersonShader = value;
        }
      }
      public TagReference OvershieldShader {
        get {
          return this._overshieldShader;
        }
        set {
          this._overshieldShader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _globalIndirectMaterialName.Read(reader);
        _indirectDamageSection.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _collisionDamageReportingType.Read(reader);
        _responseDamageReportingType.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _maximumVitality.Read(reader);
        _minimumStunDamage.Read(reader);
        _stunTime.Read(reader);
        _rechargeTime.Read(reader);
        _rechargeFraction.Read(reader);
        _unnamed4.Read(reader);
        _shieldDamagedFirstPersonShader.Read(reader);
        _shieldDamagedShader.Read(reader);
        _maximumShieldVitality.Read(reader);
        _globalShieldMaterialName.Read(reader);
        _minimumStunDamage2.Read(reader);
        _stunTime2.Read(reader);
        _rechargeTime2.Read(reader);
        _shieldDamagedThreshold.Read(reader);
        _shieldDamagedEffect.Read(reader);
        _shieldDepletedEffect.Read(reader);
        _shieldRechargingEffect.Read(reader);
        _damageSections.Read(reader);
        _nodes.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _damageSeats.Read(reader);
        _damageConstraints.Read(reader);
        _overshieldFirstPersonShader.Read(reader);
        _overshieldShader.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _globalIndirectMaterialName.ReadString(reader);
        _shieldDamagedFirstPersonShader.ReadString(reader);
        _shieldDamagedShader.ReadString(reader);
        _globalShieldMaterialName.ReadString(reader);
        _shieldDamagedEffect.ReadString(reader);
        _shieldDepletedEffect.ReadString(reader);
        _shieldRechargingEffect.ReadString(reader);
        for (x = 0; (x < _damageSections.Count); x = (x + 1)) {
          DamageSections.Add(new GlobalDamageSectionBlockBlock());
          DamageSections[x].Read(reader);
        }
        for (x = 0; (x < _damageSections.Count); x = (x + 1)) {
          DamageSections[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new GlobalDamageNodesBlockBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _damageSeats.Count); x = (x + 1)) {
          DamageSeats.Add(new DamageSeatInfoBlockBlock());
          DamageSeats[x].Read(reader);
        }
        for (x = 0; (x < _damageSeats.Count); x = (x + 1)) {
          DamageSeats[x].ReadChildData(reader);
        }
        for (x = 0; (x < _damageConstraints.Count); x = (x + 1)) {
          DamageConstraints.Add(new DamageConstraintInfoBlockBlock());
          DamageConstraints[x].Read(reader);
        }
        for (x = 0; (x < _damageConstraints.Count); x = (x + 1)) {
          DamageConstraints[x].ReadChildData(reader);
        }
        _overshieldFirstPersonShader.ReadString(reader);
        _overshieldShader.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _globalIndirectMaterialName.Write(bw);
        _indirectDamageSection.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _collisionDamageReportingType.Write(bw);
        _responseDamageReportingType.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _maximumVitality.Write(bw);
        _minimumStunDamage.Write(bw);
        _stunTime.Write(bw);
        _rechargeTime.Write(bw);
        _rechargeFraction.Write(bw);
        _unnamed4.Write(bw);
        _shieldDamagedFirstPersonShader.Write(bw);
        _shieldDamagedShader.Write(bw);
        _maximumShieldVitality.Write(bw);
        _globalShieldMaterialName.Write(bw);
        _minimumStunDamage2.Write(bw);
        _stunTime2.Write(bw);
        _rechargeTime2.Write(bw);
        _shieldDamagedThreshold.Write(bw);
        _shieldDamagedEffect.Write(bw);
        _shieldDepletedEffect.Write(bw);
        _shieldRechargingEffect.Write(bw);
_damageSections.Count = DamageSections.Count;
        _damageSections.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
_damageSeats.Count = DamageSeats.Count;
        _damageSeats.Write(bw);
_damageConstraints.Count = DamageConstraints.Count;
        _damageConstraints.Write(bw);
        _overshieldFirstPersonShader.Write(bw);
        _overshieldShader.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _globalIndirectMaterialName.WriteString(writer);
        _shieldDamagedFirstPersonShader.WriteString(writer);
        _shieldDamagedShader.WriteString(writer);
        _globalShieldMaterialName.WriteString(writer);
        _shieldDamagedEffect.WriteString(writer);
        _shieldDepletedEffect.WriteString(writer);
        _shieldRechargingEffect.WriteString(writer);
        for (x = 0; (x < _damageSections.Count); x = (x + 1)) {
          DamageSections[x].Write(writer);
        }
        for (x = 0; (x < _damageSections.Count); x = (x + 1)) {
          DamageSections[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _damageSeats.Count); x = (x + 1)) {
          DamageSeats[x].Write(writer);
        }
        for (x = 0; (x < _damageSeats.Count); x = (x + 1)) {
          DamageSeats[x].WriteChildData(writer);
        }
        for (x = 0; (x < _damageConstraints.Count); x = (x + 1)) {
          DamageConstraints[x].Write(writer);
        }
        for (x = 0; (x < _damageConstraints.Count); x = (x + 1)) {
          DamageConstraints[x].WriteChildData(writer);
        }
        _overshieldFirstPersonShader.WriteString(writer);
        _overshieldShader.WriteString(writer);
      }
    }
    public class GlobalDamageSectionBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _flags;
      private RealFraction _vitalityPercentage = new RealFraction();
      private Block _instantResponses = new Block();
      private Block _unnamed0 = new Block();
      private Block _unnamed1 = new Block();
      private Real _stunTime = new Real();
      private Real _rechargeTime = new Real();
      private Pad _unnamed2;
      private StringId _resurrectionRestoredRegionName = new StringId();
      private Pad _unnamed3;
      public BlockCollection<InstantaneousDamageRepsonseBlockBlock> _instantResponsesList = new BlockCollection<InstantaneousDamageRepsonseBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed0List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed1List = new BlockCollection<GNullBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public GlobalDamageSectionBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
      }
      public BlockCollection<InstantaneousDamageRepsonseBlockBlock> InstantResponses {
        get {
          return this._instantResponsesList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<InstantResponses.BlockCount; x++)
{
  IBlock block = InstantResponses.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public RealFraction VitalityPercentage {
        get {
          return this._vitalityPercentage;
        }
        set {
          this._vitalityPercentage = value;
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
      public StringId ResurrectionRestoredRegionName {
        get {
          return this._resurrectionRestoredRegionName;
        }
        set {
          this._resurrectionRestoredRegionName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _vitalityPercentage.Read(reader);
        _instantResponses.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _stunTime.Read(reader);
        _rechargeTime.Read(reader);
        _unnamed2.Read(reader);
        _resurrectionRestoredRegionName.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _instantResponses.Count); x = (x + 1)) {
          InstantResponses.Add(new InstantaneousDamageRepsonseBlockBlock());
          InstantResponses[x].Read(reader);
        }
        for (x = 0; (x < _instantResponses.Count); x = (x + 1)) {
          InstantResponses[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new GNullBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new GNullBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        _resurrectionRestoredRegionName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _vitalityPercentage.Write(bw);
_instantResponses.Count = InstantResponses.Count;
        _instantResponses.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
        _stunTime.Write(bw);
        _rechargeTime.Write(bw);
        _unnamed2.Write(bw);
        _resurrectionRestoredRegionName.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _instantResponses.Count); x = (x + 1)) {
          InstantResponses[x].Write(writer);
        }
        for (x = 0; (x < _instantResponses.Count); x = (x + 1)) {
          InstantResponses[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        _resurrectionRestoredRegionName.WriteString(writer);
      }
    }
    public class InstantaneousDamageRepsonseBlockBlock : IBlock {
      private Enum _responseType;
      private Enum _constraintDamageType;
      private Flags _flags;
      private Real _damageThreshold = new Real();
      private TagReference _transitionEffect = new TagReference();
      private TagReference _transitionDamageEffect = new TagReference();
      private StringId _region = new StringId();
      private Enum _newState;
      private ShortInteger _runtimeRegionIndex = new ShortInteger();
      private StringId _effectMarkerName = new StringId();
      private StringId _damageEffectMarkerName = new StringId();
      private Real _responseDelay = new Real();
      private TagReference _delayEffect = new TagReference();
      private StringId _delayEffectMarkerName = new StringId();
      private StringId _constraintgroupName = new StringId();
      private StringId _ejectingSeatLabel = new StringId();
      private RealFraction _skipFraction = new RealFraction();
      private StringId _destroyedChildObjectMarkerName = new StringId();
      private RealFraction _totalDamageThreshold = new RealFraction();
public event System.EventHandler BlockNameChanged;
      public InstantaneousDamageRepsonseBlockBlock() {
        this._responseType = new Enum(2);
        this._constraintDamageType = new Enum(2);
        this._flags = new Flags(4);
        this._newState = new Enum(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_transitionEffect.Value);
references.Add(_transitionDamageEffect.Value);
references.Add(_delayEffect.Value);
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
      public Enum ConstraintDamageType {
        get {
          return this._constraintDamageType;
        }
        set {
          this._constraintDamageType = value;
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
      public TagReference TransitionEffect {
        get {
          return this._transitionEffect;
        }
        set {
          this._transitionEffect = value;
        }
      }
      public TagReference TransitionDamageEffect {
        get {
          return this._transitionDamageEffect;
        }
        set {
          this._transitionDamageEffect = value;
        }
      }
      public StringId Region {
        get {
          return this._region;
        }
        set {
          this._region = value;
        }
      }
      public Enum NewState {
        get {
          return this._newState;
        }
        set {
          this._newState = value;
        }
      }
      public ShortInteger RuntimeRegionIndex {
        get {
          return this._runtimeRegionIndex;
        }
        set {
          this._runtimeRegionIndex = value;
        }
      }
      public StringId EffectMarkerName {
        get {
          return this._effectMarkerName;
        }
        set {
          this._effectMarkerName = value;
        }
      }
      public StringId DamageEffectMarkerName {
        get {
          return this._damageEffectMarkerName;
        }
        set {
          this._damageEffectMarkerName = value;
        }
      }
      public Real ResponseDelay {
        get {
          return this._responseDelay;
        }
        set {
          this._responseDelay = value;
        }
      }
      public TagReference DelayEffect {
        get {
          return this._delayEffect;
        }
        set {
          this._delayEffect = value;
        }
      }
      public StringId DelayEffectMarkerName {
        get {
          return this._delayEffectMarkerName;
        }
        set {
          this._delayEffectMarkerName = value;
        }
      }
      public StringId ConstraintgroupName {
        get {
          return this._constraintgroupName;
        }
        set {
          this._constraintgroupName = value;
        }
      }
      public StringId EjectingSeatLabel {
        get {
          return this._ejectingSeatLabel;
        }
        set {
          this._ejectingSeatLabel = value;
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
      public StringId DestroyedChildObjectMarkerName {
        get {
          return this._destroyedChildObjectMarkerName;
        }
        set {
          this._destroyedChildObjectMarkerName = value;
        }
      }
      public RealFraction TotalDamageThreshold {
        get {
          return this._totalDamageThreshold;
        }
        set {
          this._totalDamageThreshold = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _responseType.Read(reader);
        _constraintDamageType.Read(reader);
        _flags.Read(reader);
        _damageThreshold.Read(reader);
        _transitionEffect.Read(reader);
        _transitionDamageEffect.Read(reader);
        _region.Read(reader);
        _newState.Read(reader);
        _runtimeRegionIndex.Read(reader);
        _effectMarkerName.Read(reader);
        _damageEffectMarkerName.Read(reader);
        _responseDelay.Read(reader);
        _delayEffect.Read(reader);
        _delayEffectMarkerName.Read(reader);
        _constraintgroupName.Read(reader);
        _ejectingSeatLabel.Read(reader);
        _skipFraction.Read(reader);
        _destroyedChildObjectMarkerName.Read(reader);
        _totalDamageThreshold.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _transitionEffect.ReadString(reader);
        _transitionDamageEffect.ReadString(reader);
        _region.ReadString(reader);
        _effectMarkerName.ReadString(reader);
        _damageEffectMarkerName.ReadString(reader);
        _delayEffect.ReadString(reader);
        _delayEffectMarkerName.ReadString(reader);
        _constraintgroupName.ReadString(reader);
        _ejectingSeatLabel.ReadString(reader);
        _destroyedChildObjectMarkerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _responseType.Write(bw);
        _constraintDamageType.Write(bw);
        _flags.Write(bw);
        _damageThreshold.Write(bw);
        _transitionEffect.Write(bw);
        _transitionDamageEffect.Write(bw);
        _region.Write(bw);
        _newState.Write(bw);
        _runtimeRegionIndex.Write(bw);
        _effectMarkerName.Write(bw);
        _damageEffectMarkerName.Write(bw);
        _responseDelay.Write(bw);
        _delayEffect.Write(bw);
        _delayEffectMarkerName.Write(bw);
        _constraintgroupName.Write(bw);
        _ejectingSeatLabel.Write(bw);
        _skipFraction.Write(bw);
        _destroyedChildObjectMarkerName.Write(bw);
        _totalDamageThreshold.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _transitionEffect.WriteString(writer);
        _transitionDamageEffect.WriteString(writer);
        _region.WriteString(writer);
        _effectMarkerName.WriteString(writer);
        _damageEffectMarkerName.WriteString(writer);
        _delayEffect.WriteString(writer);
        _delayEffectMarkerName.WriteString(writer);
        _constraintgroupName.WriteString(writer);
        _ejectingSeatLabel.WriteString(writer);
        _destroyedChildObjectMarkerName.WriteString(writer);
      }
    }
    public class GNullBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public GNullBlockBlock() {
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalDamageNodesBlockBlock : IBlock {
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public GlobalDamageNodesBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
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
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DamageSeatInfoBlockBlock : IBlock {
      private StringId _seatLabel = new StringId();
      private RealFraction _directDamageScale = new RealFraction();
      private Real _damageTransferFall_MinusoffRadius = new Real();
      private Real _maximumTransferDamageScale = new Real();
      private Real _minimumTransferDamageScale = new Real();
public event System.EventHandler BlockNameChanged;
      public DamageSeatInfoBlockBlock() {
if (this._seatLabel is System.ComponentModel.INotifyPropertyChanged)
  (this._seatLabel as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _seatLabel.ToString();
        }
      }
      public StringId SeatLabel {
        get {
          return this._seatLabel;
        }
        set {
          this._seatLabel = value;
        }
      }
      public RealFraction DirectDamageScale {
        get {
          return this._directDamageScale;
        }
        set {
          this._directDamageScale = value;
        }
      }
      public Real DamageTransferFall_MinusoffRadius {
        get {
          return this._damageTransferFall_MinusoffRadius;
        }
        set {
          this._damageTransferFall_MinusoffRadius = value;
        }
      }
      public Real MaximumTransferDamageScale {
        get {
          return this._maximumTransferDamageScale;
        }
        set {
          this._maximumTransferDamageScale = value;
        }
      }
      public Real MinimumTransferDamageScale {
        get {
          return this._minimumTransferDamageScale;
        }
        set {
          this._minimumTransferDamageScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _seatLabel.Read(reader);
        _directDamageScale.Read(reader);
        _damageTransferFall_MinusoffRadius.Read(reader);
        _maximumTransferDamageScale.Read(reader);
        _minimumTransferDamageScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _seatLabel.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _seatLabel.Write(bw);
        _directDamageScale.Write(bw);
        _damageTransferFall_MinusoffRadius.Write(bw);
        _maximumTransferDamageScale.Write(bw);
        _minimumTransferDamageScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _seatLabel.WriteString(writer);
      }
    }
    public class DamageConstraintInfoBlockBlock : IBlock {
      private StringId _physicsModelConstraintName = new StringId();
      private StringId _damageConstraintName = new StringId();
      private StringId _damageConstraintGroupName = new StringId();
      private Real _groupProbabilityScale = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public DamageConstraintInfoBlockBlock() {
        this._unnamed0 = new Pad(4);
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
      public StringId PhysicsModelConstraintName {
        get {
          return this._physicsModelConstraintName;
        }
        set {
          this._physicsModelConstraintName = value;
        }
      }
      public StringId DamageConstraintName {
        get {
          return this._damageConstraintName;
        }
        set {
          this._damageConstraintName = value;
        }
      }
      public StringId DamageConstraintGroupName {
        get {
          return this._damageConstraintGroupName;
        }
        set {
          this._damageConstraintGroupName = value;
        }
      }
      public Real GroupProbabilityScale {
        get {
          return this._groupProbabilityScale;
        }
        set {
          this._groupProbabilityScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _physicsModelConstraintName.Read(reader);
        _damageConstraintName.Read(reader);
        _damageConstraintGroupName.Read(reader);
        _groupProbabilityScale.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _physicsModelConstraintName.ReadString(reader);
        _damageConstraintName.ReadString(reader);
        _damageConstraintGroupName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _physicsModelConstraintName.Write(bw);
        _damageConstraintName.Write(bw);
        _damageConstraintGroupName.Write(bw);
        _groupProbabilityScale.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _physicsModelConstraintName.WriteString(writer);
        _damageConstraintName.WriteString(writer);
        _damageConstraintGroupName.WriteString(writer);
      }
    }
    public class ModelTargetBlockBlock : IBlock {
      private StringId _markerName = new StringId();
      private Real _size = new Real();
      private Angle _coneAngle = new Angle();
      private ShortInteger _damageSection = new ShortInteger();
      private ShortBlockIndex _variant = new ShortBlockIndex();
      private RealFraction _targetingRelevance = new RealFraction();
      private Flags _flags;
      private Real _lockOnDistance = new Real();
public event System.EventHandler BlockNameChanged;
      public ModelTargetBlockBlock() {
if (this._markerName is System.ComponentModel.INotifyPropertyChanged)
  (this._markerName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public Real Size {
        get {
          return this._size;
        }
        set {
          this._size = value;
        }
      }
      public Angle ConeAngle {
        get {
          return this._coneAngle;
        }
        set {
          this._coneAngle = value;
        }
      }
      public ShortInteger DamageSection {
        get {
          return this._damageSection;
        }
        set {
          this._damageSection = value;
        }
      }
      public ShortBlockIndex Variant {
        get {
          return this._variant;
        }
        set {
          this._variant = value;
        }
      }
      public RealFraction TargetingRelevance {
        get {
          return this._targetingRelevance;
        }
        set {
          this._targetingRelevance = value;
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
      public Real LockOnDistance {
        get {
          return this._lockOnDistance;
        }
        set {
          this._lockOnDistance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _markerName.Read(reader);
        _size.Read(reader);
        _coneAngle.Read(reader);
        _damageSection.Read(reader);
        _variant.Read(reader);
        _targetingRelevance.Read(reader);
        _flags.Read(reader);
        _lockOnDistance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _markerName.Write(bw);
        _size.Write(bw);
        _coneAngle.Write(bw);
        _damageSection.Write(bw);
        _variant.Write(bw);
        _targetingRelevance.Write(bw);
        _flags.Write(bw);
        _lockOnDistance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
      }
    }
    public class ModelRegionBlockBlock : IBlock {
      private StringId _name = new StringId();
      private CharInteger _collisionRegionIndex = new CharInteger();
      private CharInteger _physicsRegionIndex = new CharInteger();
      private Pad _unnamed0;
      private Block _permutations = new Block();
      public BlockCollection<ModelPermutationBlockBlock> _permutationsList = new BlockCollection<ModelPermutationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelRegionBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<ModelPermutationBlockBlock> Permutations {
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
      public CharInteger CollisionRegionIndex {
        get {
          return this._collisionRegionIndex;
        }
        set {
          this._collisionRegionIndex = value;
        }
      }
      public CharInteger PhysicsRegionIndex {
        get {
          return this._physicsRegionIndex;
        }
        set {
          this._physicsRegionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _collisionRegionIndex.Read(reader);
        _physicsRegionIndex.Read(reader);
        _unnamed0.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new ModelPermutationBlockBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _collisionRegionIndex.Write(bw);
        _physicsRegionIndex.Write(bw);
        _unnamed0.Write(bw);
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
    public class ModelPermutationBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _flags;
      private CharInteger _collisionPermutationIndex = new CharInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ModelPermutationBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(1);
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
      public CharInteger CollisionPermutationIndex {
        get {
          return this._collisionPermutationIndex;
        }
        set {
          this._collisionPermutationIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _collisionPermutationIndex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _collisionPermutationIndex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ModelNodeBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _parentNode = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNode = new ShortBlockIndex();
      private ShortBlockIndex _nextSiblingNode = new ShortBlockIndex();
      private Pad _unnamed0;
      private RealPoint3D _defaultTranslation = new RealPoint3D();
      private RealQuaternion _defaultRotation = new RealQuaternion();
      private Real _defaultInverseScale = new Real();
      private RealVector3D _defaultInverseForward = new RealVector3D();
      private RealVector3D _defaultInverseLeft = new RealVector3D();
      private RealVector3D _defaultInverseUp = new RealVector3D();
      private RealPoint3D _defaultInversePosition = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ModelNodeBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public ShortBlockIndex ParentNode {
        get {
          return this._parentNode;
        }
        set {
          this._parentNode = value;
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
      public ShortBlockIndex NextSiblingNode {
        get {
          return this._nextSiblingNode;
        }
        set {
          this._nextSiblingNode = value;
        }
      }
      public RealPoint3D DefaultTranslation {
        get {
          return this._defaultTranslation;
        }
        set {
          this._defaultTranslation = value;
        }
      }
      public RealQuaternion DefaultRotation {
        get {
          return this._defaultRotation;
        }
        set {
          this._defaultRotation = value;
        }
      }
      public Real DefaultInverseScale {
        get {
          return this._defaultInverseScale;
        }
        set {
          this._defaultInverseScale = value;
        }
      }
      public RealVector3D DefaultInverseForward {
        get {
          return this._defaultInverseForward;
        }
        set {
          this._defaultInverseForward = value;
        }
      }
      public RealVector3D DefaultInverseLeft {
        get {
          return this._defaultInverseLeft;
        }
        set {
          this._defaultInverseLeft = value;
        }
      }
      public RealVector3D DefaultInverseUp {
        get {
          return this._defaultInverseUp;
        }
        set {
          this._defaultInverseUp = value;
        }
      }
      public RealPoint3D DefaultInversePosition {
        get {
          return this._defaultInversePosition;
        }
        set {
          this._defaultInversePosition = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parentNode.Read(reader);
        _firstChildNode.Read(reader);
        _nextSiblingNode.Read(reader);
        _unnamed0.Read(reader);
        _defaultTranslation.Read(reader);
        _defaultRotation.Read(reader);
        _defaultInverseScale.Read(reader);
        _defaultInverseForward.Read(reader);
        _defaultInverseLeft.Read(reader);
        _defaultInverseUp.Read(reader);
        _defaultInversePosition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _parentNode.Write(bw);
        _firstChildNode.Write(bw);
        _nextSiblingNode.Write(bw);
        _unnamed0.Write(bw);
        _defaultTranslation.Write(bw);
        _defaultRotation.Write(bw);
        _defaultInverseScale.Write(bw);
        _defaultInverseForward.Write(bw);
        _defaultInverseLeft.Write(bw);
        _defaultInverseUp.Write(bw);
        _defaultInversePosition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ModelObjectDataBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private RealPoint3D _offset = new RealPoint3D();
      private Real _radius = new Real();
public event System.EventHandler BlockNameChanged;
      public ModelObjectDataBlockBlock() {
        this._type = new Enum(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public RealPoint3D Offset {
        get {
          return this._offset;
        }
        set {
          this._offset = value;
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
        _type.Read(reader);
        _unnamed0.Read(reader);
        _offset.Read(reader);
        _radius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _offset.Write(bw);
        _radius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GlobalScenarioLoadParametersBlockBlock : IBlock {
      private TagReference _scenario = new TagReference();
      private Data _parameters = new Data();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public GlobalScenarioLoadParametersBlockBlock() {
if (this._scenario is System.ComponentModel.INotifyPropertyChanged)
  (this._scenario as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_scenario.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _scenario.ToString();
        }
      }
      public TagReference Scenario {
        get {
          return this._scenario;
        }
        set {
          this._scenario = value;
        }
      }
      public Data Parameters {
        get {
          return this._parameters;
        }
        set {
          this._parameters = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scenario.Read(reader);
        _parameters.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _scenario.ReadString(reader);
        _parameters.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _scenario.Write(bw);
        _parameters.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _scenario.WriteString(writer);
        _parameters.WriteBinary(writer);
      }
    }
  }
}
