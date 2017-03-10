// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'model_animation_graph'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class model_animation_graph : Interfaces.Pool.Tag {
    private ModelAnimationRuntimeDataStructBlockBlock modelAnimationGraphValues = new ModelAnimationRuntimeDataStructBlockBlock();
    public virtual ModelAnimationRuntimeDataStructBlockBlock ModelAnimationGraphValues {
      get {
        return modelAnimationGraphValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ModelAnimationGraphValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "model_animation_graph";
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
modelAnimationGraphValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
modelAnimationGraphValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
modelAnimationGraphValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
modelAnimationGraphValues.WriteChildData(writer);
    }
    #endregion
    public class ModelAnimationRuntimeDataStructBlockBlock : IBlock {
      private TagReference _parentAnimationGraph = new TagReference();
      private Flags _inheritanceFlags;
      private Flags _privateFlags;
      private ShortInteger _animationCodecPack = new ShortInteger();
      private Block _skeletonNodesABCDCC = new Block();
      private Block _soundReferencesABCDCC = new Block();
      private Block _effectReferencesABCDCC = new Block();
      private Block _blendScreensABCDCC = new Block();
      private Block _animationsABCDCC = new Block();
      private Block _modesAABBCC = new Block();
      private Block _vehicleSuspensionCCAABB = new Block();
      private Block _objectOverlaysCCAABB = new Block();
      private Block _inheritenceListBBAAAA = new Block();
      private Block _weaponListBBAAAA = new Block();
      private Pad _unnamed0;
      private Block _rawData = new Block();
      private Block _nodeDataReplacement = new Block();
      public BlockCollection<AnimationGraphNodeBlockBlock> _skeletonNodesABCDCCList = new BlockCollection<AnimationGraphNodeBlockBlock>();
      public BlockCollection<AnimationGraphSoundReferenceBlockBlock> _soundReferencesABCDCCList = new BlockCollection<AnimationGraphSoundReferenceBlockBlock>();
      public BlockCollection<AnimationGraphEffectReferenceBlockBlock> _effectReferencesABCDCCList = new BlockCollection<AnimationGraphEffectReferenceBlockBlock>();
      public BlockCollection<AnimationBlendScreenBlockBlock> _blendScreensABCDCCList = new BlockCollection<AnimationBlendScreenBlockBlock>();
      public BlockCollection<AnimationPoolBlockBlock> _animationsABCDCCList = new BlockCollection<AnimationPoolBlockBlock>();
      public BlockCollection<AnimationModeBlockBlock> _modesAABBCCList = new BlockCollection<AnimationModeBlockBlock>();
      public BlockCollection<VehicleSuspensionBlockBlock> _vehicleSuspensionCCAABBList = new BlockCollection<VehicleSuspensionBlockBlock>();
      public BlockCollection<ObjectAnimationBlockBlock> _objectOverlaysCCAABBList = new BlockCollection<ObjectAnimationBlockBlock>();
      public BlockCollection<InheritedAnimationBlockBlock> _inheritenceListBBAAAAList = new BlockCollection<InheritedAnimationBlockBlock>();
      public BlockCollection<WeaponClassLookupBlockBlock> _weaponListBBAAAAList = new BlockCollection<WeaponClassLookupBlockBlock>();
      public BlockCollection<AnimationRawDataBlockHandmadeBlock> _rawDataList = new BlockCollection<AnimationRawDataBlockHandmadeBlock>();
      public BlockCollection<NodeDataHandcodedBlock> _nodeDataReplacementList = new BlockCollection<NodeDataHandcodedBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelAnimationRuntimeDataStructBlockBlock() {
        this._inheritanceFlags = new Flags(1);
        this._privateFlags = new Flags(1);
        this._unnamed0 = new Pad(80);
      }
      public BlockCollection<AnimationGraphNodeBlockBlock> SkeletonNodesABCDCC {
        get {
          return this._skeletonNodesABCDCCList;
        }
      }
      public BlockCollection<AnimationGraphSoundReferenceBlockBlock> SoundReferencesABCDCC {
        get {
          return this._soundReferencesABCDCCList;
        }
      }
      public BlockCollection<AnimationGraphEffectReferenceBlockBlock> EffectReferencesABCDCC {
        get {
          return this._effectReferencesABCDCCList;
        }
      }
      public BlockCollection<AnimationBlendScreenBlockBlock> BlendScreensABCDCC {
        get {
          return this._blendScreensABCDCCList;
        }
      }
      public BlockCollection<AnimationPoolBlockBlock> AnimationsABCDCC {
        get {
          return this._animationsABCDCCList;
        }
      }
      public BlockCollection<AnimationModeBlockBlock> ModesAABBCC {
        get {
          return this._modesAABBCCList;
        }
      }
      public BlockCollection<VehicleSuspensionBlockBlock> VehicleSuspensionCCAABB {
        get {
          return this._vehicleSuspensionCCAABBList;
        }
      }
      public BlockCollection<ObjectAnimationBlockBlock> ObjectOverlaysCCAABB {
        get {
          return this._objectOverlaysCCAABBList;
        }
      }
      public BlockCollection<InheritedAnimationBlockBlock> InheritenceListBBAAAA {
        get {
          return this._inheritenceListBBAAAAList;
        }
      }
      public BlockCollection<WeaponClassLookupBlockBlock> WeaponListBBAAAA {
        get {
          return this._weaponListBBAAAAList;
        }
      }
      public BlockCollection<AnimationRawDataBlockHandmadeBlock> RawData {
        get {
          return this._rawDataList;
        }
      }
      public BlockCollection<NodeDataHandcodedBlock> NodeDataReplacement {
        get {
          return this._nodeDataReplacementList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_parentAnimationGraph.Value);
for (int x=0; x<SkeletonNodesABCDCC.BlockCount; x++)
{
  IBlock block = SkeletonNodesABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundReferencesABCDCC.BlockCount; x++)
{
  IBlock block = SoundReferencesABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EffectReferencesABCDCC.BlockCount; x++)
{
  IBlock block = EffectReferencesABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BlendScreensABCDCC.BlockCount; x++)
{
  IBlock block = BlendScreensABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AnimationsABCDCC.BlockCount; x++)
{
  IBlock block = AnimationsABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ModesAABBCC.BlockCount; x++)
{
  IBlock block = ModesAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VehicleSuspensionCCAABB.BlockCount; x++)
{
  IBlock block = VehicleSuspensionCCAABB.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ObjectOverlaysCCAABB.BlockCount; x++)
{
  IBlock block = ObjectOverlaysCCAABB.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InheritenceListBBAAAA.BlockCount; x++)
{
  IBlock block = InheritenceListBBAAAA.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponListBBAAAA.BlockCount; x++)
{
  IBlock block = WeaponListBBAAAA.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RawData.BlockCount; x++)
{
  IBlock block = RawData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NodeDataReplacement.BlockCount; x++)
{
  IBlock block = NodeDataReplacement.GetBlock(x);
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
      public TagReference ParentAnimationGraph {
        get {
          return this._parentAnimationGraph;
        }
        set {
          this._parentAnimationGraph = value;
        }
      }
      public Flags InheritanceFlags {
        get {
          return this._inheritanceFlags;
        }
        set {
          this._inheritanceFlags = value;
        }
      }
      public Flags PrivateFlags {
        get {
          return this._privateFlags;
        }
        set {
          this._privateFlags = value;
        }
      }
      public ShortInteger AnimationCodecPack {
        get {
          return this._animationCodecPack;
        }
        set {
          this._animationCodecPack = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parentAnimationGraph.Read(reader);
        _inheritanceFlags.Read(reader);
        _privateFlags.Read(reader);
        _animationCodecPack.Read(reader);
        _skeletonNodesABCDCC.Read(reader);
        _soundReferencesABCDCC.Read(reader);
        _effectReferencesABCDCC.Read(reader);
        _blendScreensABCDCC.Read(reader);
        _animationsABCDCC.Read(reader);
        _modesAABBCC.Read(reader);
        _vehicleSuspensionCCAABB.Read(reader);
        _objectOverlaysCCAABB.Read(reader);
        _inheritenceListBBAAAA.Read(reader);
        _weaponListBBAAAA.Read(reader);
        _unnamed0.Read(reader);
        _rawData.Read(reader);
        _nodeDataReplacement.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _parentAnimationGraph.ReadString(reader);
        for (x = 0; (x < _skeletonNodesABCDCC.Count); x = (x + 1)) {
          SkeletonNodesABCDCC.Add(new AnimationGraphNodeBlockBlock());
          SkeletonNodesABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _skeletonNodesABCDCC.Count); x = (x + 1)) {
          SkeletonNodesABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundReferencesABCDCC.Count); x = (x + 1)) {
          SoundReferencesABCDCC.Add(new AnimationGraphSoundReferenceBlockBlock());
          SoundReferencesABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _soundReferencesABCDCC.Count); x = (x + 1)) {
          SoundReferencesABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _effectReferencesABCDCC.Count); x = (x + 1)) {
          EffectReferencesABCDCC.Add(new AnimationGraphEffectReferenceBlockBlock());
          EffectReferencesABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _effectReferencesABCDCC.Count); x = (x + 1)) {
          EffectReferencesABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _blendScreensABCDCC.Count); x = (x + 1)) {
          BlendScreensABCDCC.Add(new AnimationBlendScreenBlockBlock());
          BlendScreensABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _blendScreensABCDCC.Count); x = (x + 1)) {
          BlendScreensABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animationsABCDCC.Count); x = (x + 1)) {
          AnimationsABCDCC.Add(new AnimationPoolBlockBlock());
          AnimationsABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _animationsABCDCC.Count); x = (x + 1)) {
          AnimationsABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modesAABBCC.Count); x = (x + 1)) {
          ModesAABBCC.Add(new AnimationModeBlockBlock());
          ModesAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _modesAABBCC.Count); x = (x + 1)) {
          ModesAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehicleSuspensionCCAABB.Count); x = (x + 1)) {
          VehicleSuspensionCCAABB.Add(new VehicleSuspensionBlockBlock());
          VehicleSuspensionCCAABB[x].Read(reader);
        }
        for (x = 0; (x < _vehicleSuspensionCCAABB.Count); x = (x + 1)) {
          VehicleSuspensionCCAABB[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectOverlaysCCAABB.Count); x = (x + 1)) {
          ObjectOverlaysCCAABB.Add(new ObjectAnimationBlockBlock());
          ObjectOverlaysCCAABB[x].Read(reader);
        }
        for (x = 0; (x < _objectOverlaysCCAABB.Count); x = (x + 1)) {
          ObjectOverlaysCCAABB[x].ReadChildData(reader);
        }
        for (x = 0; (x < _inheritenceListBBAAAA.Count); x = (x + 1)) {
          InheritenceListBBAAAA.Add(new InheritedAnimationBlockBlock());
          InheritenceListBBAAAA[x].Read(reader);
        }
        for (x = 0; (x < _inheritenceListBBAAAA.Count); x = (x + 1)) {
          InheritenceListBBAAAA[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponListBBAAAA.Count); x = (x + 1)) {
          WeaponListBBAAAA.Add(new WeaponClassLookupBlockBlock());
          WeaponListBBAAAA[x].Read(reader);
        }
        for (x = 0; (x < _weaponListBBAAAA.Count); x = (x + 1)) {
          WeaponListBBAAAA[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rawData.Count); x = (x + 1)) {
          RawData.Add(new AnimationRawDataBlockHandmadeBlock());
          RawData[x].Read(reader);
        }
        for (x = 0; (x < _rawData.Count); x = (x + 1)) {
          RawData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodeDataReplacement.Count); x = (x + 1)) {
          NodeDataReplacement.Add(new NodeDataHandcodedBlock());
          NodeDataReplacement[x].Read(reader);
        }
        for (x = 0; (x < _nodeDataReplacement.Count); x = (x + 1)) {
          NodeDataReplacement[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _parentAnimationGraph.Write(bw);
        _inheritanceFlags.Write(bw);
        _privateFlags.Write(bw);
        _animationCodecPack.Write(bw);
_skeletonNodesABCDCC.Count = SkeletonNodesABCDCC.Count;
        _skeletonNodesABCDCC.Write(bw);
_soundReferencesABCDCC.Count = SoundReferencesABCDCC.Count;
        _soundReferencesABCDCC.Write(bw);
_effectReferencesABCDCC.Count = EffectReferencesABCDCC.Count;
        _effectReferencesABCDCC.Write(bw);
_blendScreensABCDCC.Count = BlendScreensABCDCC.Count;
        _blendScreensABCDCC.Write(bw);
_animationsABCDCC.Count = AnimationsABCDCC.Count;
        _animationsABCDCC.Write(bw);
_modesAABBCC.Count = ModesAABBCC.Count;
        _modesAABBCC.Write(bw);
_vehicleSuspensionCCAABB.Count = VehicleSuspensionCCAABB.Count;
        _vehicleSuspensionCCAABB.Write(bw);
_objectOverlaysCCAABB.Count = ObjectOverlaysCCAABB.Count;
        _objectOverlaysCCAABB.Write(bw);
_inheritenceListBBAAAA.Count = InheritenceListBBAAAA.Count;
        _inheritenceListBBAAAA.Write(bw);
_weaponListBBAAAA.Count = WeaponListBBAAAA.Count;
        _weaponListBBAAAA.Write(bw);
        _unnamed0.Write(bw);
_rawData.Count = RawData.Count;
        _rawData.Write(bw);
_nodeDataReplacement.Count = NodeDataReplacement.Count;
        _nodeDataReplacement.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _parentAnimationGraph.WriteString(writer);
        for (x = 0; (x < _skeletonNodesABCDCC.Count); x = (x + 1)) {
          SkeletonNodesABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _skeletonNodesABCDCC.Count); x = (x + 1)) {
          SkeletonNodesABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundReferencesABCDCC.Count); x = (x + 1)) {
          SoundReferencesABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _soundReferencesABCDCC.Count); x = (x + 1)) {
          SoundReferencesABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _effectReferencesABCDCC.Count); x = (x + 1)) {
          EffectReferencesABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _effectReferencesABCDCC.Count); x = (x + 1)) {
          EffectReferencesABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _blendScreensABCDCC.Count); x = (x + 1)) {
          BlendScreensABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _blendScreensABCDCC.Count); x = (x + 1)) {
          BlendScreensABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animationsABCDCC.Count); x = (x + 1)) {
          AnimationsABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _animationsABCDCC.Count); x = (x + 1)) {
          AnimationsABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modesAABBCC.Count); x = (x + 1)) {
          ModesAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _modesAABBCC.Count); x = (x + 1)) {
          ModesAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vehicleSuspensionCCAABB.Count); x = (x + 1)) {
          VehicleSuspensionCCAABB[x].Write(writer);
        }
        for (x = 0; (x < _vehicleSuspensionCCAABB.Count); x = (x + 1)) {
          VehicleSuspensionCCAABB[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objectOverlaysCCAABB.Count); x = (x + 1)) {
          ObjectOverlaysCCAABB[x].Write(writer);
        }
        for (x = 0; (x < _objectOverlaysCCAABB.Count); x = (x + 1)) {
          ObjectOverlaysCCAABB[x].WriteChildData(writer);
        }
        for (x = 0; (x < _inheritenceListBBAAAA.Count); x = (x + 1)) {
          InheritenceListBBAAAA[x].Write(writer);
        }
        for (x = 0; (x < _inheritenceListBBAAAA.Count); x = (x + 1)) {
          InheritenceListBBAAAA[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponListBBAAAA.Count); x = (x + 1)) {
          WeaponListBBAAAA[x].Write(writer);
        }
        for (x = 0; (x < _weaponListBBAAAA.Count); x = (x + 1)) {
          WeaponListBBAAAA[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rawData.Count); x = (x + 1)) {
          RawData[x].Write(writer);
        }
        for (x = 0; (x < _rawData.Count); x = (x + 1)) {
          RawData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodeDataReplacement.Count); x = (x + 1)) {
          NodeDataReplacement[x].Write(writer);
        }
        for (x = 0; (x < _nodeDataReplacement.Count); x = (x + 1)) {
          NodeDataReplacement[x].WriteChildData(writer);
        }
      }
    }
    public class AnimationGraphNodeBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _nextSiblingNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _parentNodeIndex = new ShortBlockIndex();
      private Flags _modelFlags;
      private Flags _nodeJointFlags;
      private RealVector3D _baseVector = new RealVector3D();
      private Real _vectorRange = new Real();
      private Real _zpos = new Real();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphNodeBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._modelFlags = new Flags(1);
        this._nodeJointFlags = new Flags(1);
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
      public ShortBlockIndex NextSiblingNodeIndex {
        get {
          return this._nextSiblingNodeIndex;
        }
        set {
          this._nextSiblingNodeIndex = value;
        }
      }
      public ShortBlockIndex FirstChildNodeIndex {
        get {
          return this._firstChildNodeIndex;
        }
        set {
          this._firstChildNodeIndex = value;
        }
      }
      public ShortBlockIndex ParentNodeIndex {
        get {
          return this._parentNodeIndex;
        }
        set {
          this._parentNodeIndex = value;
        }
      }
      public Flags ModelFlags {
        get {
          return this._modelFlags;
        }
        set {
          this._modelFlags = value;
        }
      }
      public Flags NodeJointFlags {
        get {
          return this._nodeJointFlags;
        }
        set {
          this._nodeJointFlags = value;
        }
      }
      public RealVector3D BaseVector {
        get {
          return this._baseVector;
        }
        set {
          this._baseVector = value;
        }
      }
      public Real VectorRange {
        get {
          return this._vectorRange;
        }
        set {
          this._vectorRange = value;
        }
      }
      public Real Zpos {
        get {
          return this._zpos;
        }
        set {
          this._zpos = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nextSiblingNodeIndex.Read(reader);
        _firstChildNodeIndex.Read(reader);
        _parentNodeIndex.Read(reader);
        _modelFlags.Read(reader);
        _nodeJointFlags.Read(reader);
        _baseVector.Read(reader);
        _vectorRange.Read(reader);
        _zpos.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nextSiblingNodeIndex.Write(bw);
        _firstChildNodeIndex.Write(bw);
        _parentNodeIndex.Write(bw);
        _modelFlags.Write(bw);
        _nodeJointFlags.Write(bw);
        _baseVector.Write(bw);
        _vectorRange.Write(bw);
        _zpos.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class AnimationGraphSoundReferenceBlockBlock : IBlock {
      private TagReference _sound = new TagReference();
      private Flags _flags;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public AnimationGraphSoundReferenceBlockBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sound.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _sound.ToString();
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
    public class AnimationGraphEffectReferenceBlockBlock : IBlock {
      private TagReference _effect = new TagReference();
      private Flags _flags;
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public AnimationGraphEffectReferenceBlockBlock() {
if (this._effect is System.ComponentModel.INotifyPropertyChanged)
  (this._effect as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_effect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _effect.ToString();
        }
      }
      public TagReference Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
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
        _effect.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _effect.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _effect.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _effect.WriteString(writer);
      }
    }
    public class AnimationBlendScreenBlockBlock : IBlock {
      private StringId _label = new StringId();
      private Angle _rightYawPerFrame = new Angle();
      private Angle _leftYawPerFrame = new Angle();
      private ShortInteger _rightFrameCount = new ShortInteger();
      private ShortInteger _leftFrameCount = new ShortInteger();
      private Angle _downPitchPerFrame = new Angle();
      private Angle _upPitchPerFrame = new Angle();
      private ShortInteger _downPitchFrameCount = new ShortInteger();
      private ShortInteger _upPitchFrameCount = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public AnimationBlendScreenBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public Angle RightYawPerFrame {
        get {
          return this._rightYawPerFrame;
        }
        set {
          this._rightYawPerFrame = value;
        }
      }
      public Angle LeftYawPerFrame {
        get {
          return this._leftYawPerFrame;
        }
        set {
          this._leftYawPerFrame = value;
        }
      }
      public ShortInteger RightFrameCount {
        get {
          return this._rightFrameCount;
        }
        set {
          this._rightFrameCount = value;
        }
      }
      public ShortInteger LeftFrameCount {
        get {
          return this._leftFrameCount;
        }
        set {
          this._leftFrameCount = value;
        }
      }
      public Angle DownPitchPerFrame {
        get {
          return this._downPitchPerFrame;
        }
        set {
          this._downPitchPerFrame = value;
        }
      }
      public Angle UpPitchPerFrame {
        get {
          return this._upPitchPerFrame;
        }
        set {
          this._upPitchPerFrame = value;
        }
      }
      public ShortInteger DownPitchFrameCount {
        get {
          return this._downPitchFrameCount;
        }
        set {
          this._downPitchFrameCount = value;
        }
      }
      public ShortInteger UpPitchFrameCount {
        get {
          return this._upPitchFrameCount;
        }
        set {
          this._upPitchFrameCount = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _rightYawPerFrame.Read(reader);
        _leftYawPerFrame.Read(reader);
        _rightFrameCount.Read(reader);
        _leftFrameCount.Read(reader);
        _downPitchPerFrame.Read(reader);
        _upPitchPerFrame.Read(reader);
        _downPitchFrameCount.Read(reader);
        _upPitchFrameCount.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _label.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
        _rightYawPerFrame.Write(bw);
        _leftYawPerFrame.Write(bw);
        _rightFrameCount.Write(bw);
        _leftFrameCount.Write(bw);
        _downPitchPerFrame.Write(bw);
        _upPitchPerFrame.Write(bw);
        _downPitchFrameCount.Write(bw);
        _upPitchFrameCount.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _label.WriteString(writer);
      }
    }
    public class AnimationPoolBlockBlock : IBlock {
      private StringId _name = new StringId();
      private LongInteger _nodeListChecksum = new LongInteger();
      private LongInteger _productionChecksum = new LongInteger();
      private LongInteger _importchecksum = new LongInteger();
      private Enum _type;
      private Enum _frameInfoType;
      private CharBlockIndex _blendScreen = new CharBlockIndex();
      private CharInteger _nodeCount = new CharInteger();
      private ShortInteger _frameCount = new ShortInteger();
      private Flags _internalFlags;
      private Flags _productionFlags;
      private Flags _playbackFlags;
      private Enum _desiredCompression;
      private Enum _currentCompression;
      private Real _weight = new Real();
      private ShortInteger _loopFrameIndex = new ShortInteger();
      private ShortBlockIndex _unnamed0 = new ShortBlockIndex();
      private ShortBlockIndex _unnamed1 = new ShortBlockIndex();
      private Pad _unnamed2;
      private Skip _animationData;
      private CharInteger _unnamed3 = new CharInteger();
      private CharInteger _unnamed4 = new CharInteger();
      private ShortInteger _unnamed5 = new ShortInteger();
      private ShortInteger _unnamed6 = new ShortInteger();
      private ShortInteger _unnamed7 = new ShortInteger();
      private LongInteger _unnamed8 = new LongInteger();
      private LongInteger _unnamed9 = new LongInteger();
      private Block _frameEventsABCDCC = new Block();
      private Block _soundEventsABCDCC = new Block();
      private Block _effectEventsABCDCC = new Block();
      private Block _object_MinusspaceParentNodesABCDCC = new Block();
      public BlockCollection<AnimationFrameEventBlockBlock> _frameEventsABCDCCList = new BlockCollection<AnimationFrameEventBlockBlock>();
      public BlockCollection<AnimationSoundEventBlockBlock> _soundEventsABCDCCList = new BlockCollection<AnimationSoundEventBlockBlock>();
      public BlockCollection<AnimationEffectEventBlockBlock> _effectEventsABCDCCList = new BlockCollection<AnimationEffectEventBlockBlock>();
      public BlockCollection<ObjectSpaceNodeDataBlockBlock> _object_MinusspaceParentNodesABCDCCList = new BlockCollection<ObjectSpaceNodeDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationPoolBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(1);
        this._frameInfoType = new Enum(1);
        this._internalFlags = new Flags(1);
        this._productionFlags = new Flags(1);
        this._playbackFlags = new Flags(2);
        this._desiredCompression = new Enum(1);
        this._currentCompression = new Enum(1);
        this._unnamed2 = new Pad(2);
        this._animationData = new Skip(20);
      }
      public BlockCollection<AnimationFrameEventBlockBlock> FrameEventsABCDCC {
        get {
          return this._frameEventsABCDCCList;
        }
      }
      public BlockCollection<AnimationSoundEventBlockBlock> SoundEventsABCDCC {
        get {
          return this._soundEventsABCDCCList;
        }
      }
      public BlockCollection<AnimationEffectEventBlockBlock> EffectEventsABCDCC {
        get {
          return this._effectEventsABCDCCList;
        }
      }
      public BlockCollection<ObjectSpaceNodeDataBlockBlock> Object_MinusspaceParentNodesABCDCC {
        get {
          return this._object_MinusspaceParentNodesABCDCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<FrameEventsABCDCC.BlockCount; x++)
{
  IBlock block = FrameEventsABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundEventsABCDCC.BlockCount; x++)
{
  IBlock block = SoundEventsABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EffectEventsABCDCC.BlockCount; x++)
{
  IBlock block = EffectEventsABCDCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Object_MinusspaceParentNodesABCDCC.BlockCount; x++)
{
  IBlock block = Object_MinusspaceParentNodesABCDCC.GetBlock(x);
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
      public LongInteger NodeListChecksum {
        get {
          return this._nodeListChecksum;
        }
        set {
          this._nodeListChecksum = value;
        }
      }
      public LongInteger ProductionChecksum {
        get {
          return this._productionChecksum;
        }
        set {
          this._productionChecksum = value;
        }
      }
      public LongInteger Importchecksum {
        get {
          return this._importchecksum;
        }
        set {
          this._importchecksum = value;
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
      public Enum FrameInfoType {
        get {
          return this._frameInfoType;
        }
        set {
          this._frameInfoType = value;
        }
      }
      public CharBlockIndex BlendScreen {
        get {
          return this._blendScreen;
        }
        set {
          this._blendScreen = value;
        }
      }
      public CharInteger NodeCount {
        get {
          return this._nodeCount;
        }
        set {
          this._nodeCount = value;
        }
      }
      public ShortInteger FrameCount {
        get {
          return this._frameCount;
        }
        set {
          this._frameCount = value;
        }
      }
      public Flags InternalFlags {
        get {
          return this._internalFlags;
        }
        set {
          this._internalFlags = value;
        }
      }
      public Flags ProductionFlags {
        get {
          return this._productionFlags;
        }
        set {
          this._productionFlags = value;
        }
      }
      public Flags PlaybackFlags {
        get {
          return this._playbackFlags;
        }
        set {
          this._playbackFlags = value;
        }
      }
      public Enum DesiredCompression {
        get {
          return this._desiredCompression;
        }
        set {
          this._desiredCompression = value;
        }
      }
      public Enum CurrentCompression {
        get {
          return this._currentCompression;
        }
        set {
          this._currentCompression = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public ShortInteger LoopFrameIndex {
        get {
          return this._loopFrameIndex;
        }
        set {
          this._loopFrameIndex = value;
        }
      }
      public ShortBlockIndex unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public ShortBlockIndex unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public CharInteger unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public CharInteger unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public ShortInteger unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public ShortInteger unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public ShortInteger unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public LongInteger unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public LongInteger unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nodeListChecksum.Read(reader);
        _productionChecksum.Read(reader);
        _importchecksum.Read(reader);
        _type.Read(reader);
        _frameInfoType.Read(reader);
        _blendScreen.Read(reader);
        _nodeCount.Read(reader);
        _frameCount.Read(reader);
        _internalFlags.Read(reader);
        _productionFlags.Read(reader);
        _playbackFlags.Read(reader);
        _desiredCompression.Read(reader);
        _currentCompression.Read(reader);
        _weight.Read(reader);
        _loopFrameIndex.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _animationData.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _frameEventsABCDCC.Read(reader);
        _soundEventsABCDCC.Read(reader);
        _effectEventsABCDCC.Read(reader);
        _object_MinusspaceParentNodesABCDCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _frameEventsABCDCC.Count); x = (x + 1)) {
          FrameEventsABCDCC.Add(new AnimationFrameEventBlockBlock());
          FrameEventsABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _frameEventsABCDCC.Count); x = (x + 1)) {
          FrameEventsABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEventsABCDCC.Count); x = (x + 1)) {
          SoundEventsABCDCC.Add(new AnimationSoundEventBlockBlock());
          SoundEventsABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _soundEventsABCDCC.Count); x = (x + 1)) {
          SoundEventsABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _effectEventsABCDCC.Count); x = (x + 1)) {
          EffectEventsABCDCC.Add(new AnimationEffectEventBlockBlock());
          EffectEventsABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _effectEventsABCDCC.Count); x = (x + 1)) {
          EffectEventsABCDCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _object_MinusspaceParentNodesABCDCC.Count); x = (x + 1)) {
          Object_MinusspaceParentNodesABCDCC.Add(new ObjectSpaceNodeDataBlockBlock());
          Object_MinusspaceParentNodesABCDCC[x].Read(reader);
        }
        for (x = 0; (x < _object_MinusspaceParentNodesABCDCC.Count); x = (x + 1)) {
          Object_MinusspaceParentNodesABCDCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nodeListChecksum.Write(bw);
        _productionChecksum.Write(bw);
        _importchecksum.Write(bw);
        _type.Write(bw);
        _frameInfoType.Write(bw);
        _blendScreen.Write(bw);
        _nodeCount.Write(bw);
        _frameCount.Write(bw);
        _internalFlags.Write(bw);
        _productionFlags.Write(bw);
        _playbackFlags.Write(bw);
        _desiredCompression.Write(bw);
        _currentCompression.Write(bw);
        _weight.Write(bw);
        _loopFrameIndex.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _animationData.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
_frameEventsABCDCC.Count = FrameEventsABCDCC.Count;
        _frameEventsABCDCC.Write(bw);
_soundEventsABCDCC.Count = SoundEventsABCDCC.Count;
        _soundEventsABCDCC.Write(bw);
_effectEventsABCDCC.Count = EffectEventsABCDCC.Count;
        _effectEventsABCDCC.Write(bw);
_object_MinusspaceParentNodesABCDCC.Count = Object_MinusspaceParentNodesABCDCC.Count;
        _object_MinusspaceParentNodesABCDCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _frameEventsABCDCC.Count); x = (x + 1)) {
          FrameEventsABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _frameEventsABCDCC.Count); x = (x + 1)) {
          FrameEventsABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundEventsABCDCC.Count); x = (x + 1)) {
          SoundEventsABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _soundEventsABCDCC.Count); x = (x + 1)) {
          SoundEventsABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _effectEventsABCDCC.Count); x = (x + 1)) {
          EffectEventsABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _effectEventsABCDCC.Count); x = (x + 1)) {
          EffectEventsABCDCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _object_MinusspaceParentNodesABCDCC.Count); x = (x + 1)) {
          Object_MinusspaceParentNodesABCDCC[x].Write(writer);
        }
        for (x = 0; (x < _object_MinusspaceParentNodesABCDCC.Count); x = (x + 1)) {
          Object_MinusspaceParentNodesABCDCC[x].WriteChildData(writer);
        }
      }
    }
    public class AnimationFrameEventBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _frame = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public AnimationFrameEventBlockBlock() {
        this._type = new Enum(2);
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
      public ShortInteger Frame {
        get {
          return this._frame;
        }
        set {
          this._frame = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _frame.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _frame.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationSoundEventBlockBlock : IBlock {
      private ShortBlockIndex _sound = new ShortBlockIndex();
      private ShortInteger _frame = new ShortInteger();
      private StringId _markerName = new StringId();
public event System.EventHandler BlockNameChanged;
      public AnimationSoundEventBlockBlock() {
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
      public ShortBlockIndex Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public ShortInteger Frame {
        get {
          return this._frame;
        }
        set {
          this._frame = value;
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
        _sound.Read(reader);
        _frame.Read(reader);
        _markerName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _markerName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _frame.Write(bw);
        _markerName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _markerName.WriteString(writer);
      }
    }
    public class AnimationEffectEventBlockBlock : IBlock {
      private ShortBlockIndex _effect = new ShortBlockIndex();
      private ShortInteger _frame = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public AnimationEffectEventBlockBlock() {
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
      public ShortBlockIndex Effect {
        get {
          return this._effect;
        }
        set {
          this._effect = value;
        }
      }
      public ShortInteger Frame {
        get {
          return this._frame;
        }
        set {
          this._frame = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _effect.Read(reader);
        _frame.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _effect.Write(bw);
        _frame.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ObjectSpaceNodeDataBlockBlock : IBlock {
      private ShortInteger _nodeindex = new ShortInteger();
      private Flags _componentFlags;
      private ShortInteger _rotationX = new ShortInteger();
      private ShortInteger _rotationY = new ShortInteger();
      private ShortInteger _rotationZ = new ShortInteger();
      private ShortInteger _rotationW = new ShortInteger();
      private RealPoint3D _defaultTranslation = new RealPoint3D();
      private Real _defaultScale = new Real();
public event System.EventHandler BlockNameChanged;
      public ObjectSpaceNodeDataBlockBlock() {
        this._componentFlags = new Flags(2);
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
      public ShortInteger Nodeindex {
        get {
          return this._nodeindex;
        }
        set {
          this._nodeindex = value;
        }
      }
      public Flags ComponentFlags {
        get {
          return this._componentFlags;
        }
        set {
          this._componentFlags = value;
        }
      }
      public ShortInteger RotationX {
        get {
          return this._rotationX;
        }
        set {
          this._rotationX = value;
        }
      }
      public ShortInteger RotationY {
        get {
          return this._rotationY;
        }
        set {
          this._rotationY = value;
        }
      }
      public ShortInteger RotationZ {
        get {
          return this._rotationZ;
        }
        set {
          this._rotationZ = value;
        }
      }
      public ShortInteger RotationW {
        get {
          return this._rotationW;
        }
        set {
          this._rotationW = value;
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
      public Real DefaultScale {
        get {
          return this._defaultScale;
        }
        set {
          this._defaultScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeindex.Read(reader);
        _componentFlags.Read(reader);
        _rotationX.Read(reader);
        _rotationY.Read(reader);
        _rotationZ.Read(reader);
        _rotationW.Read(reader);
        _defaultTranslation.Read(reader);
        _defaultScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeindex.Write(bw);
        _componentFlags.Write(bw);
        _rotationX.Write(bw);
        _rotationY.Write(bw);
        _rotationZ.Write(bw);
        _rotationW.Write(bw);
        _defaultTranslation.Write(bw);
        _defaultScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationModeBlockBlock : IBlock {
      private StringId _label = new StringId();
      private Block _weaponClassAABBCC = new Block();
      private Block _modeIkAABBCC = new Block();
      public BlockCollection<WeaponClassBlockBlock> _weaponClassAABBCCList = new BlockCollection<WeaponClassBlockBlock>();
      public BlockCollection<AnimationIkBlockBlock> _modeIkAABBCCList = new BlockCollection<AnimationIkBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationModeBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<WeaponClassBlockBlock> WeaponClassAABBCC {
        get {
          return this._weaponClassAABBCCList;
        }
      }
      public BlockCollection<AnimationIkBlockBlock> ModeIkAABBCC {
        get {
          return this._modeIkAABBCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<WeaponClassAABBCC.BlockCount; x++)
{
  IBlock block = WeaponClassAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ModeIkAABBCC.BlockCount; x++)
{
  IBlock block = ModeIkAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _weaponClassAABBCC.Read(reader);
        _modeIkAABBCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _label.ReadString(reader);
        for (x = 0; (x < _weaponClassAABBCC.Count); x = (x + 1)) {
          WeaponClassAABBCC.Add(new WeaponClassBlockBlock());
          WeaponClassAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _weaponClassAABBCC.Count); x = (x + 1)) {
          WeaponClassAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _modeIkAABBCC.Count); x = (x + 1)) {
          ModeIkAABBCC.Add(new AnimationIkBlockBlock());
          ModeIkAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _modeIkAABBCC.Count); x = (x + 1)) {
          ModeIkAABBCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
_weaponClassAABBCC.Count = WeaponClassAABBCC.Count;
        _weaponClassAABBCC.Write(bw);
_modeIkAABBCC.Count = ModeIkAABBCC.Count;
        _modeIkAABBCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _label.WriteString(writer);
        for (x = 0; (x < _weaponClassAABBCC.Count); x = (x + 1)) {
          WeaponClassAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _weaponClassAABBCC.Count); x = (x + 1)) {
          WeaponClassAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _modeIkAABBCC.Count); x = (x + 1)) {
          ModeIkAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _modeIkAABBCC.Count); x = (x + 1)) {
          ModeIkAABBCC[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponClassBlockBlock : IBlock {
      private StringId _label = new StringId();
      private Block _weaponTypeAABBCC = new Block();
      private Block _weaponIkAABBCC = new Block();
      public BlockCollection<WeaponTypeBlockBlock> _weaponTypeAABBCCList = new BlockCollection<WeaponTypeBlockBlock>();
      public BlockCollection<AnimationIkBlockBlock> _weaponIkAABBCCList = new BlockCollection<AnimationIkBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponClassBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<WeaponTypeBlockBlock> WeaponTypeAABBCC {
        get {
          return this._weaponTypeAABBCCList;
        }
      }
      public BlockCollection<AnimationIkBlockBlock> WeaponIkAABBCC {
        get {
          return this._weaponIkAABBCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<WeaponTypeAABBCC.BlockCount; x++)
{
  IBlock block = WeaponTypeAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponIkAABBCC.BlockCount; x++)
{
  IBlock block = WeaponIkAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _weaponTypeAABBCC.Read(reader);
        _weaponIkAABBCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _label.ReadString(reader);
        for (x = 0; (x < _weaponTypeAABBCC.Count); x = (x + 1)) {
          WeaponTypeAABBCC.Add(new WeaponTypeBlockBlock());
          WeaponTypeAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _weaponTypeAABBCC.Count); x = (x + 1)) {
          WeaponTypeAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponIkAABBCC.Count); x = (x + 1)) {
          WeaponIkAABBCC.Add(new AnimationIkBlockBlock());
          WeaponIkAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _weaponIkAABBCC.Count); x = (x + 1)) {
          WeaponIkAABBCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
_weaponTypeAABBCC.Count = WeaponTypeAABBCC.Count;
        _weaponTypeAABBCC.Write(bw);
_weaponIkAABBCC.Count = WeaponIkAABBCC.Count;
        _weaponIkAABBCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _label.WriteString(writer);
        for (x = 0; (x < _weaponTypeAABBCC.Count); x = (x + 1)) {
          WeaponTypeAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _weaponTypeAABBCC.Count); x = (x + 1)) {
          WeaponTypeAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponIkAABBCC.Count); x = (x + 1)) {
          WeaponIkAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _weaponIkAABBCC.Count); x = (x + 1)) {
          WeaponIkAABBCC[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponTypeBlockBlock : IBlock {
      private StringId _label = new StringId();
      private Block _actionsAABBCC = new Block();
      private Block _overlaysAABBCC = new Block();
      private Block _deathAndDamageAABBCC = new Block();
      private Block _transitionsAABBCC = new Block();
      private Block _highPrecacheCCCCC = new Block();
      private Block _lowPrecacheCCCCC = new Block();
      public BlockCollection<AnimationEntryBlockBlock> _actionsAABBCCList = new BlockCollection<AnimationEntryBlockBlock>();
      public BlockCollection<AnimationEntryBlockBlock> _overlaysAABBCCList = new BlockCollection<AnimationEntryBlockBlock>();
      public BlockCollection<DamageAnimationBlockBlock> _deathAndDamageAABBCCList = new BlockCollection<DamageAnimationBlockBlock>();
      public BlockCollection<AnimationTransitionBlockBlock> _transitionsAABBCCList = new BlockCollection<AnimationTransitionBlockBlock>();
      public BlockCollection<PrecacheListBlockBlock> _highPrecacheCCCCCList = new BlockCollection<PrecacheListBlockBlock>();
      public BlockCollection<PrecacheListBlockBlock> _lowPrecacheCCCCCList = new BlockCollection<PrecacheListBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public WeaponTypeBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<AnimationEntryBlockBlock> ActionsAABBCC {
        get {
          return this._actionsAABBCCList;
        }
      }
      public BlockCollection<AnimationEntryBlockBlock> OverlaysAABBCC {
        get {
          return this._overlaysAABBCCList;
        }
      }
      public BlockCollection<DamageAnimationBlockBlock> DeathAndDamageAABBCC {
        get {
          return this._deathAndDamageAABBCCList;
        }
      }
      public BlockCollection<AnimationTransitionBlockBlock> TransitionsAABBCC {
        get {
          return this._transitionsAABBCCList;
        }
      }
      public BlockCollection<PrecacheListBlockBlock> HighPrecacheCCCCC {
        get {
          return this._highPrecacheCCCCCList;
        }
      }
      public BlockCollection<PrecacheListBlockBlock> LowPrecacheCCCCC {
        get {
          return this._lowPrecacheCCCCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<ActionsAABBCC.BlockCount; x++)
{
  IBlock block = ActionsAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OverlaysAABBCC.BlockCount; x++)
{
  IBlock block = OverlaysAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DeathAndDamageAABBCC.BlockCount; x++)
{
  IBlock block = DeathAndDamageAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TransitionsAABBCC.BlockCount; x++)
{
  IBlock block = TransitionsAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HighPrecacheCCCCC.BlockCount; x++)
{
  IBlock block = HighPrecacheCCCCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LowPrecacheCCCCC.BlockCount; x++)
{
  IBlock block = LowPrecacheCCCCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _actionsAABBCC.Read(reader);
        _overlaysAABBCC.Read(reader);
        _deathAndDamageAABBCC.Read(reader);
        _transitionsAABBCC.Read(reader);
        _highPrecacheCCCCC.Read(reader);
        _lowPrecacheCCCCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _label.ReadString(reader);
        for (x = 0; (x < _actionsAABBCC.Count); x = (x + 1)) {
          ActionsAABBCC.Add(new AnimationEntryBlockBlock());
          ActionsAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _actionsAABBCC.Count); x = (x + 1)) {
          ActionsAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _overlaysAABBCC.Count); x = (x + 1)) {
          OverlaysAABBCC.Add(new AnimationEntryBlockBlock());
          OverlaysAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _overlaysAABBCC.Count); x = (x + 1)) {
          OverlaysAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _deathAndDamageAABBCC.Count); x = (x + 1)) {
          DeathAndDamageAABBCC.Add(new DamageAnimationBlockBlock());
          DeathAndDamageAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _deathAndDamageAABBCC.Count); x = (x + 1)) {
          DeathAndDamageAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _transitionsAABBCC.Count); x = (x + 1)) {
          TransitionsAABBCC.Add(new AnimationTransitionBlockBlock());
          TransitionsAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _transitionsAABBCC.Count); x = (x + 1)) {
          TransitionsAABBCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _highPrecacheCCCCC.Count); x = (x + 1)) {
          HighPrecacheCCCCC.Add(new PrecacheListBlockBlock());
          HighPrecacheCCCCC[x].Read(reader);
        }
        for (x = 0; (x < _highPrecacheCCCCC.Count); x = (x + 1)) {
          HighPrecacheCCCCC[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lowPrecacheCCCCC.Count); x = (x + 1)) {
          LowPrecacheCCCCC.Add(new PrecacheListBlockBlock());
          LowPrecacheCCCCC[x].Read(reader);
        }
        for (x = 0; (x < _lowPrecacheCCCCC.Count); x = (x + 1)) {
          LowPrecacheCCCCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
_actionsAABBCC.Count = ActionsAABBCC.Count;
        _actionsAABBCC.Write(bw);
_overlaysAABBCC.Count = OverlaysAABBCC.Count;
        _overlaysAABBCC.Write(bw);
_deathAndDamageAABBCC.Count = DeathAndDamageAABBCC.Count;
        _deathAndDamageAABBCC.Write(bw);
_transitionsAABBCC.Count = TransitionsAABBCC.Count;
        _transitionsAABBCC.Write(bw);
_highPrecacheCCCCC.Count = HighPrecacheCCCCC.Count;
        _highPrecacheCCCCC.Write(bw);
_lowPrecacheCCCCC.Count = LowPrecacheCCCCC.Count;
        _lowPrecacheCCCCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _label.WriteString(writer);
        for (x = 0; (x < _actionsAABBCC.Count); x = (x + 1)) {
          ActionsAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _actionsAABBCC.Count); x = (x + 1)) {
          ActionsAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _overlaysAABBCC.Count); x = (x + 1)) {
          OverlaysAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _overlaysAABBCC.Count); x = (x + 1)) {
          OverlaysAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _deathAndDamageAABBCC.Count); x = (x + 1)) {
          DeathAndDamageAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _deathAndDamageAABBCC.Count); x = (x + 1)) {
          DeathAndDamageAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _transitionsAABBCC.Count); x = (x + 1)) {
          TransitionsAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _transitionsAABBCC.Count); x = (x + 1)) {
          TransitionsAABBCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _highPrecacheCCCCC.Count); x = (x + 1)) {
          HighPrecacheCCCCC[x].Write(writer);
        }
        for (x = 0; (x < _highPrecacheCCCCC.Count); x = (x + 1)) {
          HighPrecacheCCCCC[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lowPrecacheCCCCC.Count); x = (x + 1)) {
          LowPrecacheCCCCC[x].Write(writer);
        }
        for (x = 0; (x < _lowPrecacheCCCCC.Count); x = (x + 1)) {
          LowPrecacheCCCCC[x].WriteChildData(writer);
        }
      }
    }
    public class AnimationEntryBlockBlock : IBlock {
      private StringId _label = new StringId();
      private ShortInteger _graphIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public AnimationEntryBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public ShortInteger GraphIndex {
        get {
          return this._graphIndex;
        }
        set {
          this._graphIndex = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _graphIndex.Read(reader);
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _label.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
        _graphIndex.Write(bw);
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _label.WriteString(writer);
      }
    }
    public class DamageAnimationBlockBlock : IBlock {
      private StringId _label = new StringId();
      private Block _directionsAABBCC = new Block();
      public BlockCollection<DamageDirectionBlockBlock> _directionsAABBCCList = new BlockCollection<DamageDirectionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageAnimationBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public BlockCollection<DamageDirectionBlockBlock> DirectionsAABBCC {
        get {
          return this._directionsAABBCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<DirectionsAABBCC.BlockCount; x++)
{
  IBlock block = DirectionsAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _directionsAABBCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _label.ReadString(reader);
        for (x = 0; (x < _directionsAABBCC.Count); x = (x + 1)) {
          DirectionsAABBCC.Add(new DamageDirectionBlockBlock());
          DirectionsAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _directionsAABBCC.Count); x = (x + 1)) {
          DirectionsAABBCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
_directionsAABBCC.Count = DirectionsAABBCC.Count;
        _directionsAABBCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _label.WriteString(writer);
        for (x = 0; (x < _directionsAABBCC.Count); x = (x + 1)) {
          DirectionsAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _directionsAABBCC.Count); x = (x + 1)) {
          DirectionsAABBCC[x].WriteChildData(writer);
        }
      }
    }
    public class DamageDirectionBlockBlock : IBlock {
      private Block _regionsAABBCC = new Block();
      public BlockCollection<DamageRegionBlockBlock> _regionsAABBCCList = new BlockCollection<DamageRegionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DamageDirectionBlockBlock() {
      }
      public BlockCollection<DamageRegionBlockBlock> RegionsAABBCC {
        get {
          return this._regionsAABBCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<RegionsAABBCC.BlockCount; x++)
{
  IBlock block = RegionsAABBCC.GetBlock(x);
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
        _regionsAABBCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _regionsAABBCC.Count); x = (x + 1)) {
          RegionsAABBCC.Add(new DamageRegionBlockBlock());
          RegionsAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _regionsAABBCC.Count); x = (x + 1)) {
          RegionsAABBCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_regionsAABBCC.Count = RegionsAABBCC.Count;
        _regionsAABBCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _regionsAABBCC.Count); x = (x + 1)) {
          RegionsAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _regionsAABBCC.Count); x = (x + 1)) {
          RegionsAABBCC[x].WriteChildData(writer);
        }
      }
    }
    public class DamageRegionBlockBlock : IBlock {
      private ShortInteger _graphIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public DamageRegionBlockBlock() {
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
      public ShortInteger GraphIndex {
        get {
          return this._graphIndex;
        }
        set {
          this._graphIndex = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _graphIndex.Read(reader);
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _graphIndex.Write(bw);
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationTransitionBlockBlock : IBlock {
      private StringId _fullName = new StringId();
      private StringId _stateName = new StringId();
      private Pad _unnamed0;
      private CharInteger _indexA = new CharInteger();
      private CharInteger _indexB = new CharInteger();
      private Block _destinationsAABBCC = new Block();
      public BlockCollection<AnimationTransitionDestinationBlockBlock> _destinationsAABBCCList = new BlockCollection<AnimationTransitionDestinationBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationTransitionBlockBlock() {
if (this._fullName is System.ComponentModel.INotifyPropertyChanged)
  (this._fullName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<AnimationTransitionDestinationBlockBlock> DestinationsAABBCC {
        get {
          return this._destinationsAABBCCList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<DestinationsAABBCC.BlockCount; x++)
{
  IBlock block = DestinationsAABBCC.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _fullName.ToString();
        }
      }
      public StringId FullName {
        get {
          return this._fullName;
        }
        set {
          this._fullName = value;
        }
      }
      public StringId StateName {
        get {
          return this._stateName;
        }
        set {
          this._stateName = value;
        }
      }
      public CharInteger IndexA {
        get {
          return this._indexA;
        }
        set {
          this._indexA = value;
        }
      }
      public CharInteger IndexB {
        get {
          return this._indexB;
        }
        set {
          this._indexB = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fullName.Read(reader);
        _stateName.Read(reader);
        _unnamed0.Read(reader);
        _indexA.Read(reader);
        _indexB.Read(reader);
        _destinationsAABBCC.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _fullName.ReadString(reader);
        _stateName.ReadString(reader);
        for (x = 0; (x < _destinationsAABBCC.Count); x = (x + 1)) {
          DestinationsAABBCC.Add(new AnimationTransitionDestinationBlockBlock());
          DestinationsAABBCC[x].Read(reader);
        }
        for (x = 0; (x < _destinationsAABBCC.Count); x = (x + 1)) {
          DestinationsAABBCC[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _fullName.Write(bw);
        _stateName.Write(bw);
        _unnamed0.Write(bw);
        _indexA.Write(bw);
        _indexB.Write(bw);
_destinationsAABBCC.Count = DestinationsAABBCC.Count;
        _destinationsAABBCC.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _fullName.WriteString(writer);
        _stateName.WriteString(writer);
        for (x = 0; (x < _destinationsAABBCC.Count); x = (x + 1)) {
          DestinationsAABBCC[x].Write(writer);
        }
        for (x = 0; (x < _destinationsAABBCC.Count); x = (x + 1)) {
          DestinationsAABBCC[x].WriteChildData(writer);
        }
      }
    }
    public class AnimationTransitionDestinationBlockBlock : IBlock {
      private StringId _fullName = new StringId();
      private StringId _mode = new StringId();
      private StringId _stateName = new StringId();
      private Enum _frameEventLink;
      private Pad _unnamed0;
      private CharInteger _indexA = new CharInteger();
      private CharInteger _indexB = new CharInteger();
      private ShortInteger _graphIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public AnimationTransitionDestinationBlockBlock() {
if (this._fullName is System.ComponentModel.INotifyPropertyChanged)
  (this._fullName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._frameEventLink = new Enum(1);
        this._unnamed0 = new Pad(1);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _fullName.ToString();
        }
      }
      public StringId FullName {
        get {
          return this._fullName;
        }
        set {
          this._fullName = value;
        }
      }
      public StringId Mode {
        get {
          return this._mode;
        }
        set {
          this._mode = value;
        }
      }
      public StringId StateName {
        get {
          return this._stateName;
        }
        set {
          this._stateName = value;
        }
      }
      public Enum FrameEventLink {
        get {
          return this._frameEventLink;
        }
        set {
          this._frameEventLink = value;
        }
      }
      public CharInteger IndexA {
        get {
          return this._indexA;
        }
        set {
          this._indexA = value;
        }
      }
      public CharInteger IndexB {
        get {
          return this._indexB;
        }
        set {
          this._indexB = value;
        }
      }
      public ShortInteger GraphIndex {
        get {
          return this._graphIndex;
        }
        set {
          this._graphIndex = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _fullName.Read(reader);
        _mode.Read(reader);
        _stateName.Read(reader);
        _frameEventLink.Read(reader);
        _unnamed0.Read(reader);
        _indexA.Read(reader);
        _indexB.Read(reader);
        _graphIndex.Read(reader);
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _fullName.ReadString(reader);
        _mode.ReadString(reader);
        _stateName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _fullName.Write(bw);
        _mode.Write(bw);
        _stateName.Write(bw);
        _frameEventLink.Write(bw);
        _unnamed0.Write(bw);
        _indexA.Write(bw);
        _indexB.Write(bw);
        _graphIndex.Write(bw);
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _fullName.WriteString(writer);
        _mode.WriteString(writer);
        _stateName.WriteString(writer);
      }
    }
    public class PrecacheListBlockBlock : IBlock {
      private LongInteger _cacheBlockIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PrecacheListBlockBlock() {
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
      public LongInteger CacheBlockIndex {
        get {
          return this._cacheBlockIndex;
        }
        set {
          this._cacheBlockIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _cacheBlockIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _cacheBlockIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationIkBlockBlock : IBlock {
      private StringId _marker = new StringId();
      private StringId _attachToMarker = new StringId();
public event System.EventHandler BlockNameChanged;
      public AnimationIkBlockBlock() {
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
      public StringId Marker {
        get {
          return this._marker;
        }
        set {
          this._marker = value;
        }
      }
      public StringId AttachToMarker {
        get {
          return this._attachToMarker;
        }
        set {
          this._attachToMarker = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _marker.Read(reader);
        _attachToMarker.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _marker.ReadString(reader);
        _attachToMarker.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _marker.Write(bw);
        _attachToMarker.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _marker.WriteString(writer);
        _attachToMarker.WriteString(writer);
      }
    }
    public class VehicleSuspensionBlockBlock : IBlock {
      private StringId _label = new StringId();
      private ShortInteger _graphIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private StringId _markerName = new StringId();
      private Real _massPointOffset = new Real();
      private Real _fullExtensionGrounddepth = new Real();
      private Real _fullCompressionGrounddepth = new Real();
      private StringId _regionName = new StringId();
      private Real _destroyedMassPointOffset = new Real();
      private Real _destroyedFullExtensionGrounddepth = new Real();
      private Real _destroyedFullCompressionGrounddepth = new Real();
public event System.EventHandler BlockNameChanged;
      public VehicleSuspensionBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public ShortInteger GraphIndex {
        get {
          return this._graphIndex;
        }
        set {
          this._graphIndex = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
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
      public Real MassPointOffset {
        get {
          return this._massPointOffset;
        }
        set {
          this._massPointOffset = value;
        }
      }
      public Real FullExtensionGrounddepth {
        get {
          return this._fullExtensionGrounddepth;
        }
        set {
          this._fullExtensionGrounddepth = value;
        }
      }
      public Real FullCompressionGrounddepth {
        get {
          return this._fullCompressionGrounddepth;
        }
        set {
          this._fullCompressionGrounddepth = value;
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
      public Real DestroyedMassPointOffset {
        get {
          return this._destroyedMassPointOffset;
        }
        set {
          this._destroyedMassPointOffset = value;
        }
      }
      public Real DestroyedFullExtensionGrounddepth {
        get {
          return this._destroyedFullExtensionGrounddepth;
        }
        set {
          this._destroyedFullExtensionGrounddepth = value;
        }
      }
      public Real DestroyedFullCompressionGrounddepth {
        get {
          return this._destroyedFullCompressionGrounddepth;
        }
        set {
          this._destroyedFullCompressionGrounddepth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _graphIndex.Read(reader);
        _animation.Read(reader);
        _markerName.Read(reader);
        _massPointOffset.Read(reader);
        _fullExtensionGrounddepth.Read(reader);
        _fullCompressionGrounddepth.Read(reader);
        _regionName.Read(reader);
        _destroyedMassPointOffset.Read(reader);
        _destroyedFullExtensionGrounddepth.Read(reader);
        _destroyedFullCompressionGrounddepth.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _label.ReadString(reader);
        _markerName.ReadString(reader);
        _regionName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
        _graphIndex.Write(bw);
        _animation.Write(bw);
        _markerName.Write(bw);
        _massPointOffset.Write(bw);
        _fullExtensionGrounddepth.Write(bw);
        _fullCompressionGrounddepth.Write(bw);
        _regionName.Write(bw);
        _destroyedMassPointOffset.Write(bw);
        _destroyedFullExtensionGrounddepth.Write(bw);
        _destroyedFullCompressionGrounddepth.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _label.WriteString(writer);
        _markerName.WriteString(writer);
        _regionName.WriteString(writer);
      }
    }
    public class ObjectAnimationBlockBlock : IBlock {
      private StringId _label = new StringId();
      private ShortInteger _graphIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private Pad _unnamed0;
      private Enum _functionControls;
      private StringId _function = new StringId();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ObjectAnimationBlockBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._functionControls = new Enum(2);
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
return _label.ToString();
        }
      }
      public StringId Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public ShortInteger GraphIndex {
        get {
          return this._graphIndex;
        }
        set {
          this._graphIndex = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public Enum FunctionControls {
        get {
          return this._functionControls;
        }
        set {
          this._functionControls = value;
        }
      }
      public StringId Function {
        get {
          return this._function;
        }
        set {
          this._function = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _graphIndex.Read(reader);
        _animation.Read(reader);
        _unnamed0.Read(reader);
        _functionControls.Read(reader);
        _function.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _label.ReadString(reader);
        _function.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
        _graphIndex.Write(bw);
        _animation.Write(bw);
        _unnamed0.Write(bw);
        _functionControls.Write(bw);
        _function.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _label.WriteString(writer);
        _function.WriteString(writer);
      }
    }
    public class InheritedAnimationBlockBlock : IBlock {
      private TagReference _inheritedGraph = new TagReference();
      private Block _nodeMap = new Block();
      private Block _nodeMapFlags = new Block();
      private Real _rootZOffset = new Real();
      private LongInteger _inheritanceflags = new LongInteger();
      public BlockCollection<InheritedAnimationNodeMapBlockBlock> _nodeMapList = new BlockCollection<InheritedAnimationNodeMapBlockBlock>();
      public BlockCollection<InheritedAnimationNodeMapFlagBlockBlock> _nodeMapFlagsList = new BlockCollection<InheritedAnimationNodeMapFlagBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public InheritedAnimationBlockBlock() {
      }
      public BlockCollection<InheritedAnimationNodeMapBlockBlock> NodeMap {
        get {
          return this._nodeMapList;
        }
      }
      public BlockCollection<InheritedAnimationNodeMapFlagBlockBlock> NodeMapFlags {
        get {
          return this._nodeMapFlagsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_inheritedGraph.Value);
for (int x=0; x<NodeMap.BlockCount; x++)
{
  IBlock block = NodeMap.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NodeMapFlags.BlockCount; x++)
{
  IBlock block = NodeMapFlags.GetBlock(x);
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
      public TagReference InheritedGraph {
        get {
          return this._inheritedGraph;
        }
        set {
          this._inheritedGraph = value;
        }
      }
      public Real RootZOffset {
        get {
          return this._rootZOffset;
        }
        set {
          this._rootZOffset = value;
        }
      }
      public LongInteger Inheritanceflags {
        get {
          return this._inheritanceflags;
        }
        set {
          this._inheritanceflags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _inheritedGraph.Read(reader);
        _nodeMap.Read(reader);
        _nodeMapFlags.Read(reader);
        _rootZOffset.Read(reader);
        _inheritanceflags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _inheritedGraph.ReadString(reader);
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap.Add(new InheritedAnimationNodeMapBlockBlock());
          NodeMap[x].Read(reader);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodeMapFlags.Count); x = (x + 1)) {
          NodeMapFlags.Add(new InheritedAnimationNodeMapFlagBlockBlock());
          NodeMapFlags[x].Read(reader);
        }
        for (x = 0; (x < _nodeMapFlags.Count); x = (x + 1)) {
          NodeMapFlags[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _inheritedGraph.Write(bw);
_nodeMap.Count = NodeMap.Count;
        _nodeMap.Write(bw);
_nodeMapFlags.Count = NodeMapFlags.Count;
        _nodeMapFlags.Write(bw);
        _rootZOffset.Write(bw);
        _inheritanceflags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _inheritedGraph.WriteString(writer);
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].Write(writer);
        }
        for (x = 0; (x < _nodeMap.Count); x = (x + 1)) {
          NodeMap[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodeMapFlags.Count); x = (x + 1)) {
          NodeMapFlags[x].Write(writer);
        }
        for (x = 0; (x < _nodeMapFlags.Count); x = (x + 1)) {
          NodeMapFlags[x].WriteChildData(writer);
        }
      }
    }
    public class InheritedAnimationNodeMapBlockBlock : IBlock {
      private ShortInteger _localNode = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public InheritedAnimationNodeMapBlockBlock() {
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
      public ShortInteger LocalNode {
        get {
          return this._localNode;
        }
        set {
          this._localNode = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _localNode.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _localNode.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class InheritedAnimationNodeMapFlagBlockBlock : IBlock {
      private LongInteger _localNodeFlags = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public InheritedAnimationNodeMapFlagBlockBlock() {
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
      public LongInteger LocalNodeFlags {
        get {
          return this._localNodeFlags;
        }
        set {
          this._localNodeFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _localNodeFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _localNodeFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class WeaponClassLookupBlockBlock : IBlock {
      private StringId _weaponName = new StringId();
      private StringId _weaponClass = new StringId();
public event System.EventHandler BlockNameChanged;
      public WeaponClassLookupBlockBlock() {
if (this._weaponName is System.ComponentModel.INotifyPropertyChanged)
  (this._weaponName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _weaponName.ToString();
        }
      }
      public StringId WeaponName {
        get {
          return this._weaponName;
        }
        set {
          this._weaponName = value;
        }
      }
      public StringId WeaponClass {
        get {
          return this._weaponClass;
        }
        set {
          this._weaponClass = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weaponName.Read(reader);
        _weaponClass.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weaponName.ReadString(reader);
        _weaponClass.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weaponName.Write(bw);
        _weaponClass.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weaponName.WriteString(writer);
        _weaponClass.WriteString(writer);
      }
    }
    public class AnimationRawDataBlockHandmadeBlock : IBlock {
      private Skip _animationSelfReference;
      private ResourceBlockInverted _resourceData = new ResourceBlockInverted();
      private Skip _unknown;
public event System.EventHandler BlockNameChanged;
      public AnimationRawDataBlockHandmadeBlock() {
        this._animationSelfReference = new Skip(4);
        this._unknown = new Skip(8);
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
      public ResourceBlockInverted ResourceData {
        get {
          return this._resourceData;
        }
        set {
          this._resourceData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animationSelfReference.Read(reader);
        _resourceData.Read(reader);
        _unknown.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _resourceData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _animationSelfReference.Write(bw);
        _resourceData.Write(bw);
        _unknown.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _resourceData.WriteBinary(writer);
      }
    }
    public class NodeDataHandcodedBlock : IBlock {
      private Skip _unnamed0;
public event System.EventHandler BlockNameChanged;
      public NodeDataHandcodedBlock() {
        this._unnamed0 = new Skip(24);
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
  }
}
