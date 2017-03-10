// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'model_animations'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class model_animations : Interfaces.Pool.Tag {
    private ModelAnimationsBlock modelAnimationsValues = new ModelAnimationsBlock();
    public virtual ModelAnimationsBlock ModelAnimationsValues {
      get {
        return modelAnimationsValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ModelAnimationsValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "model_animations";
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
modelAnimationsValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
modelAnimationsValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
modelAnimationsValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
modelAnimationsValues.WriteChildData(writer);
    }
    #endregion
    public class ModelAnimationsBlock : IBlock {
      private Block _oBJECTS = new Block();
      private Block _uNITS = new Block();
      private Block _wEAPONS = new Block();
      private Block _vEHICLES = new Block();
      private Block _dEVICES = new Block();
      private Block _uNITDAMAGE = new Block();
      private Block _fIRSTPERSONWEAPONS = new Block();
      private Block _soundReferences = new Block();
      private Real _limpBodyNodeRadius = new Real();
      private Flags _flags;
      private Pad _unnamed;
      private Block _nodes = new Block();
      private Block _animations = new Block();
      public BlockCollection<AnimationGraphObjectOverlayBlock> _oBJECTSList = new BlockCollection<AnimationGraphObjectOverlayBlock>();
      public BlockCollection<AnimationGraphUnitSeatBlock> _uNITSList = new BlockCollection<AnimationGraphUnitSeatBlock>();
      public BlockCollection<AnimationGraphWeaponAnimationsBlock> _wEAPONSList = new BlockCollection<AnimationGraphWeaponAnimationsBlock>();
      public BlockCollection<AnimationGraphVehicleAnimationsBlock> _vEHICLESList = new BlockCollection<AnimationGraphVehicleAnimationsBlock>();
      public BlockCollection<DeviceAnimationsBlock> _dEVICESList = new BlockCollection<DeviceAnimationsBlock>();
      public BlockCollection<UnitDamageAnimationsBlock> _uNITDAMAGEList = new BlockCollection<UnitDamageAnimationsBlock>();
      public BlockCollection<AnimationGraphFirstPersonWeaponAnimationsBlock> _fIRSTPERSONWEAPONSList = new BlockCollection<AnimationGraphFirstPersonWeaponAnimationsBlock>();
      public BlockCollection<AnimationGraphSoundReferenceBlock> _soundReferencesList = new BlockCollection<AnimationGraphSoundReferenceBlock>();
      public BlockCollection<AnimationGraphNodeBlock> _nodesList = new BlockCollection<AnimationGraphNodeBlock>();
      public BlockCollection<AnimationBlock> _animationsList = new BlockCollection<AnimationBlock>();
public event System.EventHandler BlockNameChanged;
      public ModelAnimationsBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
      }
      public BlockCollection<AnimationGraphObjectOverlayBlock> OBJECTS {
        get {
          return this._oBJECTSList;
        }
      }
      public BlockCollection<AnimationGraphUnitSeatBlock> UNITS {
        get {
          return this._uNITSList;
        }
      }
      public BlockCollection<AnimationGraphWeaponAnimationsBlock> WEAPONS {
        get {
          return this._wEAPONSList;
        }
      }
      public BlockCollection<AnimationGraphVehicleAnimationsBlock> VEHICLES {
        get {
          return this._vEHICLESList;
        }
      }
      public BlockCollection<DeviceAnimationsBlock> DEVICES {
        get {
          return this._dEVICESList;
        }
      }
      public BlockCollection<UnitDamageAnimationsBlock> UNITDAMAGE {
        get {
          return this._uNITDAMAGEList;
        }
      }
      public BlockCollection<AnimationGraphFirstPersonWeaponAnimationsBlock> FIRSTPERSONWEAPONS {
        get {
          return this._fIRSTPERSONWEAPONSList;
        }
      }
      public BlockCollection<AnimationGraphSoundReferenceBlock> SoundReferences {
        get {
          return this._soundReferencesList;
        }
      }
      public BlockCollection<AnimationGraphNodeBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public BlockCollection<AnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<OBJECTS.BlockCount; x++)
{
  IBlock block = OBJECTS.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<UNITS.BlockCount; x++)
{
  IBlock block = UNITS.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WEAPONS.BlockCount; x++)
{
  IBlock block = WEAPONS.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VEHICLES.BlockCount; x++)
{
  IBlock block = VEHICLES.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DEVICES.BlockCount; x++)
{
  IBlock block = DEVICES.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<UNITDAMAGE.BlockCount; x++)
{
  IBlock block = UNITDAMAGE.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FIRSTPERSONWEAPONS.BlockCount; x++)
{
  IBlock block = FIRSTPERSONWEAPONS.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundReferences.BlockCount; x++)
{
  IBlock block = SoundReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
      public Real LimpBodyNodeRadius {
        get {
          return this._limpBodyNodeRadius;
        }
        set {
          this._limpBodyNodeRadius = value;
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
        _oBJECTS.Read(reader);
        _uNITS.Read(reader);
        _wEAPONS.Read(reader);
        _vEHICLES.Read(reader);
        _dEVICES.Read(reader);
        _uNITDAMAGE.Read(reader);
        _fIRSTPERSONWEAPONS.Read(reader);
        _soundReferences.Read(reader);
        _limpBodyNodeRadius.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _nodes.Read(reader);
        _animations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _oBJECTS.Count); x = (x + 1)) {
          OBJECTS.Add(new AnimationGraphObjectOverlayBlock());
          OBJECTS[x].Read(reader);
        }
        for (x = 0; (x < _oBJECTS.Count); x = (x + 1)) {
          OBJECTS[x].ReadChildData(reader);
        }
        for (x = 0; (x < _uNITS.Count); x = (x + 1)) {
          UNITS.Add(new AnimationGraphUnitSeatBlock());
          UNITS[x].Read(reader);
        }
        for (x = 0; (x < _uNITS.Count); x = (x + 1)) {
          UNITS[x].ReadChildData(reader);
        }
        for (x = 0; (x < _wEAPONS.Count); x = (x + 1)) {
          WEAPONS.Add(new AnimationGraphWeaponAnimationsBlock());
          WEAPONS[x].Read(reader);
        }
        for (x = 0; (x < _wEAPONS.Count); x = (x + 1)) {
          WEAPONS[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vEHICLES.Count); x = (x + 1)) {
          VEHICLES.Add(new AnimationGraphVehicleAnimationsBlock());
          VEHICLES[x].Read(reader);
        }
        for (x = 0; (x < _vEHICLES.Count); x = (x + 1)) {
          VEHICLES[x].ReadChildData(reader);
        }
        for (x = 0; (x < _dEVICES.Count); x = (x + 1)) {
          DEVICES.Add(new DeviceAnimationsBlock());
          DEVICES[x].Read(reader);
        }
        for (x = 0; (x < _dEVICES.Count); x = (x + 1)) {
          DEVICES[x].ReadChildData(reader);
        }
        for (x = 0; (x < _uNITDAMAGE.Count); x = (x + 1)) {
          UNITDAMAGE.Add(new UnitDamageAnimationsBlock());
          UNITDAMAGE[x].Read(reader);
        }
        for (x = 0; (x < _uNITDAMAGE.Count); x = (x + 1)) {
          UNITDAMAGE[x].ReadChildData(reader);
        }
        for (x = 0; (x < _fIRSTPERSONWEAPONS.Count); x = (x + 1)) {
          FIRSTPERSONWEAPONS.Add(new AnimationGraphFirstPersonWeaponAnimationsBlock());
          FIRSTPERSONWEAPONS[x].Read(reader);
        }
        for (x = 0; (x < _fIRSTPERSONWEAPONS.Count); x = (x + 1)) {
          FIRSTPERSONWEAPONS[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundReferences.Count); x = (x + 1)) {
          SoundReferences.Add(new AnimationGraphSoundReferenceBlock());
          SoundReferences[x].Read(reader);
        }
        for (x = 0; (x < _soundReferences.Count); x = (x + 1)) {
          SoundReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new AnimationGraphNodeBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new AnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_oBJECTS.Count = OBJECTS.Count;
        _oBJECTS.Write(bw);
_uNITS.Count = UNITS.Count;
        _uNITS.Write(bw);
_wEAPONS.Count = WEAPONS.Count;
        _wEAPONS.Write(bw);
_vEHICLES.Count = VEHICLES.Count;
        _vEHICLES.Write(bw);
_dEVICES.Count = DEVICES.Count;
        _dEVICES.Write(bw);
_uNITDAMAGE.Count = UNITDAMAGE.Count;
        _uNITDAMAGE.Write(bw);
_fIRSTPERSONWEAPONS.Count = FIRSTPERSONWEAPONS.Count;
        _fIRSTPERSONWEAPONS.Write(bw);
_soundReferences.Count = SoundReferences.Count;
        _soundReferences.Write(bw);
        _limpBodyNodeRadius.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _oBJECTS.Count); x = (x + 1)) {
          OBJECTS[x].Write(writer);
        }
        for (x = 0; (x < _oBJECTS.Count); x = (x + 1)) {
          OBJECTS[x].WriteChildData(writer);
        }
        for (x = 0; (x < _uNITS.Count); x = (x + 1)) {
          UNITS[x].Write(writer);
        }
        for (x = 0; (x < _uNITS.Count); x = (x + 1)) {
          UNITS[x].WriteChildData(writer);
        }
        for (x = 0; (x < _wEAPONS.Count); x = (x + 1)) {
          WEAPONS[x].Write(writer);
        }
        for (x = 0; (x < _wEAPONS.Count); x = (x + 1)) {
          WEAPONS[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vEHICLES.Count); x = (x + 1)) {
          VEHICLES[x].Write(writer);
        }
        for (x = 0; (x < _vEHICLES.Count); x = (x + 1)) {
          VEHICLES[x].WriteChildData(writer);
        }
        for (x = 0; (x < _dEVICES.Count); x = (x + 1)) {
          DEVICES[x].Write(writer);
        }
        for (x = 0; (x < _dEVICES.Count); x = (x + 1)) {
          DEVICES[x].WriteChildData(writer);
        }
        for (x = 0; (x < _uNITDAMAGE.Count); x = (x + 1)) {
          UNITDAMAGE[x].Write(writer);
        }
        for (x = 0; (x < _uNITDAMAGE.Count); x = (x + 1)) {
          UNITDAMAGE[x].WriteChildData(writer);
        }
        for (x = 0; (x < _fIRSTPERSONWEAPONS.Count); x = (x + 1)) {
          FIRSTPERSONWEAPONS[x].Write(writer);
        }
        for (x = 0; (x < _fIRSTPERSONWEAPONS.Count); x = (x + 1)) {
          FIRSTPERSONWEAPONS[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundReferences.Count); x = (x + 1)) {
          SoundReferences[x].Write(writer);
        }
        for (x = 0; (x < _soundReferences.Count); x = (x + 1)) {
          SoundReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class AnimationGraphObjectOverlayBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private Enum _function = new Enum();
      private Enum _functionControls = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public AnimationGraphObjectOverlayBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public Enum Function {
        get {
          return this._function;
        }
        set {
          this._function = value;
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
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
        _function.Read(reader);
        _functionControls.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
        _function.Write(bw);
        _functionControls.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphUnitSeatBlock : IBlock {
      private FixedLengthString _label = new FixedLengthString();
      private Angle _rightYawPerFrame = new Angle();
      private Angle _leftYawPerFrame = new Angle();
      private ShortInteger _rightFrameCount = new ShortInteger();
      private ShortInteger _leftFrameCount = new ShortInteger();
      private Angle _downPitchPerFrame = new Angle();
      private Angle _upPitchPerFrame = new Angle();
      private ShortInteger _downPitchFrameCount = new ShortInteger();
      private ShortInteger _upPitchFrameCount = new ShortInteger();
      private Pad _unnamed;
      private Block _animations = new Block();
      private Block _ikPoints = new Block();
      private Block _weapons = new Block();
      public BlockCollection<UnitSeatAnimationBlock> _animationsList = new BlockCollection<UnitSeatAnimationBlock>();
      public BlockCollection<AnimationGraphUnitSeatIkPointBlock> _ikPointsList = new BlockCollection<AnimationGraphUnitSeatIkPointBlock>();
      public BlockCollection<AnimationGraphWeaponBlock> _weaponsList = new BlockCollection<AnimationGraphWeaponBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphUnitSeatBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(8);
      }
      public BlockCollection<UnitSeatAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public BlockCollection<AnimationGraphUnitSeatIkPointBlock> IkPoints {
        get {
          return this._ikPointsList;
        }
      }
      public BlockCollection<AnimationGraphWeaponBlock> Weapons {
        get {
          return this._weaponsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IkPoints.BlockCount; x++)
{
  IBlock block = IkPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Weapons.BlockCount; x++)
{
  IBlock block = Weapons.GetBlock(x);
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
      public FixedLengthString Label {
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
        _unnamed.Read(reader);
        _animations.Read(reader);
        _ikPoints.Read(reader);
        _weapons.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new UnitSeatAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints.Add(new AnimationGraphUnitSeatIkPointBlock());
          IkPoints[x].Read(reader);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons.Add(new AnimationGraphWeaponBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].ReadChildData(reader);
        }
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
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
_ikPoints.Count = IkPoints.Count;
        _ikPoints.Write(bw);
_weapons.Count = Weapons.Count;
        _weapons.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].Write(writer);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].Write(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].WriteChildData(writer);
        }
      }
    }
    public class UnitSeatAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public UnitSeatAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphUnitSeatIkPointBlock : IBlock {
      private FixedLengthString _marker = new FixedLengthString();
      private FixedLengthString _attachToMarker = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphUnitSeatIkPointBlock() {
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
      public FixedLengthString Marker {
        get {
          return this._marker;
        }
        set {
          this._marker = value;
        }
      }
      public FixedLengthString AttachToMarker {
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
      }
      public virtual void Write(BinaryWriter bw) {
        _marker.Write(bw);
        _attachToMarker.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphWeaponBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private FixedLengthString _gripMarker = new FixedLengthString();
      private FixedLengthString _handMarker = new FixedLengthString();
      private Angle _rightYawPerFrame = new Angle();
      private Angle _leftYawPerFrame = new Angle();
      private ShortInteger _rightFrameCount = new ShortInteger();
      private ShortInteger _leftFrameCount = new ShortInteger();
      private Angle _downPitchPerFrame = new Angle();
      private Angle _upPitchPerFrame = new Angle();
      private ShortInteger _downPitchFrameCount = new ShortInteger();
      private ShortInteger _upPitchFrameCount = new ShortInteger();
      private Pad _unnamed;
      private Block _animations = new Block();
      private Block _ikPoints = new Block();
      private Block _weaponTypes = new Block();
      public BlockCollection<WeaponClassAnimationBlock> _animationsList = new BlockCollection<WeaponClassAnimationBlock>();
      public BlockCollection<AnimationGraphUnitSeatIkPointBlock> _ikPointsList = new BlockCollection<AnimationGraphUnitSeatIkPointBlock>();
      public BlockCollection<AnimationGraphWeaponTypeBlock> _weaponTypesList = new BlockCollection<AnimationGraphWeaponTypeBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphWeaponBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public BlockCollection<WeaponClassAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public BlockCollection<AnimationGraphUnitSeatIkPointBlock> IkPoints {
        get {
          return this._ikPointsList;
        }
      }
      public BlockCollection<AnimationGraphWeaponTypeBlock> WeaponTypes {
        get {
          return this._weaponTypesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<IkPoints.BlockCount; x++)
{
  IBlock block = IkPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponTypes.BlockCount; x++)
{
  IBlock block = WeaponTypes.GetBlock(x);
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
      public FixedLengthString GripMarker {
        get {
          return this._gripMarker;
        }
        set {
          this._gripMarker = value;
        }
      }
      public FixedLengthString HandMarker {
        get {
          return this._handMarker;
        }
        set {
          this._handMarker = value;
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
        _name.Read(reader);
        _gripMarker.Read(reader);
        _handMarker.Read(reader);
        _rightYawPerFrame.Read(reader);
        _leftYawPerFrame.Read(reader);
        _rightFrameCount.Read(reader);
        _leftFrameCount.Read(reader);
        _downPitchPerFrame.Read(reader);
        _upPitchPerFrame.Read(reader);
        _downPitchFrameCount.Read(reader);
        _upPitchFrameCount.Read(reader);
        _unnamed.Read(reader);
        _animations.Read(reader);
        _ikPoints.Read(reader);
        _weaponTypes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new WeaponClassAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints.Add(new AnimationGraphUnitSeatIkPointBlock());
          IkPoints[x].Read(reader);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponTypes.Count); x = (x + 1)) {
          WeaponTypes.Add(new AnimationGraphWeaponTypeBlock());
          WeaponTypes[x].Read(reader);
        }
        for (x = 0; (x < _weaponTypes.Count); x = (x + 1)) {
          WeaponTypes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _gripMarker.Write(bw);
        _handMarker.Write(bw);
        _rightYawPerFrame.Write(bw);
        _leftYawPerFrame.Write(bw);
        _rightFrameCount.Write(bw);
        _leftFrameCount.Write(bw);
        _downPitchPerFrame.Write(bw);
        _upPitchPerFrame.Write(bw);
        _downPitchFrameCount.Write(bw);
        _upPitchFrameCount.Write(bw);
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
_ikPoints.Count = IkPoints.Count;
        _ikPoints.Write(bw);
_weaponTypes.Count = WeaponTypes.Count;
        _weaponTypes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].Write(writer);
        }
        for (x = 0; (x < _ikPoints.Count); x = (x + 1)) {
          IkPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponTypes.Count); x = (x + 1)) {
          WeaponTypes[x].Write(writer);
        }
        for (x = 0; (x < _weaponTypes.Count); x = (x + 1)) {
          WeaponTypes[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponClassAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public WeaponClassAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphWeaponTypeBlock : IBlock {
      private FixedLengthString _label = new FixedLengthString();
      private Pad _unnamed;
      private Block _animations = new Block();
      public BlockCollection<WeaponTypeAnimationBlock> _animationsList = new BlockCollection<WeaponTypeAnimationBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphWeaponTypeBlock() {
if (this._label is System.ComponentModel.INotifyPropertyChanged)
  (this._label as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(16);
      }
      public BlockCollection<WeaponTypeAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
      public FixedLengthString Label {
        get {
          return this._label;
        }
        set {
          this._label = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _label.Read(reader);
        _unnamed.Read(reader);
        _animations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new WeaponTypeAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _label.Write(bw);
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponTypeAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public WeaponTypeAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphWeaponAnimationsBlock : IBlock {
      private Pad _unnamed;
      private Block _animations = new Block();
      public BlockCollection<WeaponAnimationBlock> _animationsList = new BlockCollection<WeaponAnimationBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphWeaponAnimationsBlock() {
        this._unnamed = new Pad(16);
      }
      public BlockCollection<WeaponAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
        _unnamed.Read(reader);
        _animations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new WeaponAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class WeaponAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public WeaponAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphVehicleAnimationsBlock : IBlock {
      private Angle _rightYawPerFrame = new Angle();
      private Angle _leftYawPerFrame = new Angle();
      private ShortInteger _rightFrameCount = new ShortInteger();
      private ShortInteger _leftFrameCount = new ShortInteger();
      private Angle _downPitchPerFrame = new Angle();
      private Angle _upPitchPerFrame = new Angle();
      private ShortInteger _downPitchFrameCount = new ShortInteger();
      private ShortInteger _upPitchFrameCount = new ShortInteger();
      private Pad _unnamed;
      private Block _animations = new Block();
      private Block _suspensionAnimations = new Block();
      public BlockCollection<VehicleAnimationBlock> _animationsList = new BlockCollection<VehicleAnimationBlock>();
      public BlockCollection<SuspensionAnimationBlock> _suspensionAnimationsList = new BlockCollection<SuspensionAnimationBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphVehicleAnimationsBlock() {
        this._unnamed = new Pad(68);
      }
      public BlockCollection<VehicleAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public BlockCollection<SuspensionAnimationBlock> SuspensionAnimations {
        get {
          return this._suspensionAnimationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SuspensionAnimations.BlockCount; x++)
{
  IBlock block = SuspensionAnimations.GetBlock(x);
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
        _rightYawPerFrame.Read(reader);
        _leftYawPerFrame.Read(reader);
        _rightFrameCount.Read(reader);
        _leftFrameCount.Read(reader);
        _downPitchPerFrame.Read(reader);
        _upPitchPerFrame.Read(reader);
        _downPitchFrameCount.Read(reader);
        _upPitchFrameCount.Read(reader);
        _unnamed.Read(reader);
        _animations.Read(reader);
        _suspensionAnimations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new VehicleAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _suspensionAnimations.Count); x = (x + 1)) {
          SuspensionAnimations.Add(new SuspensionAnimationBlock());
          SuspensionAnimations[x].Read(reader);
        }
        for (x = 0; (x < _suspensionAnimations.Count); x = (x + 1)) {
          SuspensionAnimations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _rightYawPerFrame.Write(bw);
        _leftYawPerFrame.Write(bw);
        _rightFrameCount.Write(bw);
        _leftFrameCount.Write(bw);
        _downPitchPerFrame.Write(bw);
        _upPitchPerFrame.Write(bw);
        _downPitchFrameCount.Write(bw);
        _upPitchFrameCount.Write(bw);
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
_suspensionAnimations.Count = SuspensionAnimations.Count;
        _suspensionAnimations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _suspensionAnimations.Count); x = (x + 1)) {
          SuspensionAnimations[x].Write(writer);
        }
        for (x = 0; (x < _suspensionAnimations.Count); x = (x + 1)) {
          SuspensionAnimations[x].WriteChildData(writer);
        }
      }
    }
    public class VehicleAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public VehicleAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SuspensionAnimationBlock : IBlock {
      private ShortInteger _massPointIndex = new ShortInteger();
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private Real _fullExtensionGrounddepth = new Real();
      private Real _fullCompressionGrounddepth = new Real();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public SuspensionAnimationBlock() {
if (this._animation is System.ComponentModel.INotifyPropertyChanged)
  (this._animation as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _animation.ToString();
        }
      }
      public ShortInteger MassPointIndex {
        get {
          return this._massPointIndex;
        }
        set {
          this._massPointIndex = value;
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
      public virtual void Read(BinaryReader reader) {
        _massPointIndex.Read(reader);
        _animation.Read(reader);
        _fullExtensionGrounddepth.Read(reader);
        _fullCompressionGrounddepth.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _massPointIndex.Write(bw);
        _animation.Write(bw);
        _fullExtensionGrounddepth.Write(bw);
        _fullCompressionGrounddepth.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DeviceAnimationsBlock : IBlock {
      private Pad _unnamed;
      private Block _animations = new Block();
      public BlockCollection<DeviceAnimationBlock> _animationsList = new BlockCollection<DeviceAnimationBlock>();
public event System.EventHandler BlockNameChanged;
      public DeviceAnimationsBlock() {
        this._unnamed = new Pad(84);
      }
      public BlockCollection<DeviceAnimationBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
        _unnamed.Read(reader);
        _animations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new DeviceAnimationBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class DeviceAnimationBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public DeviceAnimationBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UnitDamageAnimationsBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public UnitDamageAnimationsBlock() {
if (this._animation is System.ComponentModel.INotifyPropertyChanged)
  (this._animation as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _animation.ToString();
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
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphFirstPersonWeaponAnimationsBlock : IBlock {
      private Pad _unnamed;
      private Block _animations = new Block();
      public BlockCollection<FirstPersonWeaponBlock> _animationsList = new BlockCollection<FirstPersonWeaponBlock>();
public event System.EventHandler BlockNameChanged;
      public AnimationGraphFirstPersonWeaponAnimationsBlock() {
        this._unnamed = new Pad(16);
      }
      public BlockCollection<FirstPersonWeaponBlock> Animations {
        get {
          return this._animationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Animations.BlockCount; x++)
{
  IBlock block = Animations.GetBlock(x);
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
        _unnamed.Read(reader);
        _animations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations.Add(new FirstPersonWeaponBlock());
          Animations[x].Read(reader);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
_animations.Count = Animations.Count;
        _animations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].Write(writer);
        }
        for (x = 0; (x < _animations.Count); x = (x + 1)) {
          Animations[x].WriteChildData(writer);
        }
      }
    }
    public class FirstPersonWeaponBlock : IBlock {
      private ShortBlockIndex _animation = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public FirstPersonWeaponBlock() {
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
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _animation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationGraphSoundReferenceBlock : IBlock {
      private TagReference _sound = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AnimationGraphSoundReferenceBlock() {
if (this._sound is System.ComponentModel.INotifyPropertyChanged)
  (this._sound as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
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
      public virtual void Read(BinaryReader reader) {
        _sound.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sound.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sound.WriteString(writer);
      }
    }
    public class AnimationGraphNodeBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _nextSiblingNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _firstChildNodeIndex = new ShortBlockIndex();
      private ShortBlockIndex _parentNodeIndex = new ShortBlockIndex();
      private Pad _unnamed;
      private Flags _nodeJointFlags;
      private RealVector3D _baseVector = new RealVector3D();
      private Real _vectorRange = new Real();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public AnimationGraphNodeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._nodeJointFlags = new Flags(4);
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _nextSiblingNodeIndex.Read(reader);
        _firstChildNodeIndex.Read(reader);
        _parentNodeIndex.Read(reader);
        _unnamed.Read(reader);
        _nodeJointFlags.Read(reader);
        _baseVector.Read(reader);
        _vectorRange.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _nextSiblingNodeIndex.Write(bw);
        _firstChildNodeIndex.Write(bw);
        _parentNodeIndex.Write(bw);
        _unnamed.Write(bw);
        _nodeJointFlags.Write(bw);
        _baseVector.Write(bw);
        _vectorRange.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AnimationBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _type = new Enum();
      private ShortInteger _frameCount = new ShortInteger();
      private ShortInteger _frameSize = new ShortInteger();
      private Enum _frameInfoType = new Enum();
      private LongInteger _nodeListChecksum = new LongInteger();
      private ShortInteger _nodeCount = new ShortInteger();
      private ShortInteger _loopFrameIndex = new ShortInteger();
      private RealFraction _weight = new RealFraction();
      private ShortInteger _keyFrameIndex = new ShortInteger();
      private ShortInteger _secondKeyFrameIndex = new ShortInteger();
      private ShortBlockIndex _nextAnimation = new ShortBlockIndex();
      private Flags _flags;
      private ShortBlockIndex _sound = new ShortBlockIndex();
      private ShortInteger _soundFrameIndex = new ShortInteger();
      private CharInteger _leftFootFrameIndex = new CharInteger();
      private CharInteger _rightFootFrameIndex = new CharInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Data _frameInfo = new Data();
      private LongInteger _nodeTranslationFlagsA = new LongInteger();
      private LongInteger _nodeTranslationFlagsB = new LongInteger();
      private Pad _unnamed4;
      private LongInteger _nodeRotationFlagsA = new LongInteger();
      private LongInteger _nodeRotationFlagsB = new LongInteger();
      private Pad _unnamed5;
      private LongInteger _nodeScaleFlagsA = new LongInteger();
      private LongInteger _nodeScaleFlagsB = new LongInteger();
      private Pad _unnamed6;
      private LongInteger _offsetToCompressedData = new LongInteger();
      private Data _defaultData = new Data();
      private Data _frameData = new Data();
public event System.EventHandler BlockNameChanged;
      public AnimationBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed4 = new Pad(8);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(4);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public ShortInteger FrameSize {
        get {
          return this._frameSize;
        }
        set {
          this._frameSize = value;
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
      public LongInteger NodeListChecksum {
        get {
          return this._nodeListChecksum;
        }
        set {
          this._nodeListChecksum = value;
        }
      }
      public ShortInteger NodeCount {
        get {
          return this._nodeCount;
        }
        set {
          this._nodeCount = value;
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
      public RealFraction Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public ShortInteger KeyFrameIndex {
        get {
          return this._keyFrameIndex;
        }
        set {
          this._keyFrameIndex = value;
        }
      }
      public ShortInteger SecondKeyFrameIndex {
        get {
          return this._secondKeyFrameIndex;
        }
        set {
          this._secondKeyFrameIndex = value;
        }
      }
      public ShortBlockIndex NextAnimation {
        get {
          return this._nextAnimation;
        }
        set {
          this._nextAnimation = value;
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
      public ShortBlockIndex Sound {
        get {
          return this._sound;
        }
        set {
          this._sound = value;
        }
      }
      public ShortInteger SoundFrameIndex {
        get {
          return this._soundFrameIndex;
        }
        set {
          this._soundFrameIndex = value;
        }
      }
      public CharInteger LeftFootFrameIndex {
        get {
          return this._leftFootFrameIndex;
        }
        set {
          this._leftFootFrameIndex = value;
        }
      }
      public CharInteger RightFootFrameIndex {
        get {
          return this._rightFootFrameIndex;
        }
        set {
          this._rightFootFrameIndex = value;
        }
      }
      public Data FrameInfo {
        get {
          return this._frameInfo;
        }
        set {
          this._frameInfo = value;
        }
      }
      public LongInteger NodeTranslationFlagsA {
        get {
          return this._nodeTranslationFlagsA;
        }
        set {
          this._nodeTranslationFlagsA = value;
        }
      }
      public LongInteger NodeTranslationFlagsB {
        get {
          return this._nodeTranslationFlagsB;
        }
        set {
          this._nodeTranslationFlagsB = value;
        }
      }
      public LongInteger NodeRotationFlagsA {
        get {
          return this._nodeRotationFlagsA;
        }
        set {
          this._nodeRotationFlagsA = value;
        }
      }
      public LongInteger NodeRotationFlagsB {
        get {
          return this._nodeRotationFlagsB;
        }
        set {
          this._nodeRotationFlagsB = value;
        }
      }
      public LongInteger NodeScaleFlagsA {
        get {
          return this._nodeScaleFlagsA;
        }
        set {
          this._nodeScaleFlagsA = value;
        }
      }
      public LongInteger NodeScaleFlagsB {
        get {
          return this._nodeScaleFlagsB;
        }
        set {
          this._nodeScaleFlagsB = value;
        }
      }
      public LongInteger OffsetToCompressedData {
        get {
          return this._offsetToCompressedData;
        }
        set {
          this._offsetToCompressedData = value;
        }
      }
      public Data DefaultData {
        get {
          return this._defaultData;
        }
        set {
          this._defaultData = value;
        }
      }
      public Data FrameData {
        get {
          return this._frameData;
        }
        set {
          this._frameData = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _type.Read(reader);
        _frameCount.Read(reader);
        _frameSize.Read(reader);
        _frameInfoType.Read(reader);
        _nodeListChecksum.Read(reader);
        _nodeCount.Read(reader);
        _loopFrameIndex.Read(reader);
        _weight.Read(reader);
        _keyFrameIndex.Read(reader);
        _secondKeyFrameIndex.Read(reader);
        _nextAnimation.Read(reader);
        _flags.Read(reader);
        _sound.Read(reader);
        _soundFrameIndex.Read(reader);
        _leftFootFrameIndex.Read(reader);
        _rightFootFrameIndex.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _frameInfo.Read(reader);
        _nodeTranslationFlagsA.Read(reader);
        _nodeTranslationFlagsB.Read(reader);
        _unnamed4.Read(reader);
        _nodeRotationFlagsA.Read(reader);
        _nodeRotationFlagsB.Read(reader);
        _unnamed5.Read(reader);
        _nodeScaleFlagsA.Read(reader);
        _nodeScaleFlagsB.Read(reader);
        _unnamed6.Read(reader);
        _offsetToCompressedData.Read(reader);
        _defaultData.Read(reader);
        _frameData.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _frameInfo.ReadBinary(reader);
        _defaultData.ReadBinary(reader);
        _frameData.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _frameCount.Write(bw);
        _frameSize.Write(bw);
        _frameInfoType.Write(bw);
        _nodeListChecksum.Write(bw);
        _nodeCount.Write(bw);
        _loopFrameIndex.Write(bw);
        _weight.Write(bw);
        _keyFrameIndex.Write(bw);
        _secondKeyFrameIndex.Write(bw);
        _nextAnimation.Write(bw);
        _flags.Write(bw);
        _sound.Write(bw);
        _soundFrameIndex.Write(bw);
        _leftFootFrameIndex.Write(bw);
        _rightFootFrameIndex.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _frameInfo.Write(bw);
        _nodeTranslationFlagsA.Write(bw);
        _nodeTranslationFlagsB.Write(bw);
        _unnamed4.Write(bw);
        _nodeRotationFlagsA.Write(bw);
        _nodeRotationFlagsB.Write(bw);
        _unnamed5.Write(bw);
        _nodeScaleFlagsA.Write(bw);
        _nodeScaleFlagsB.Write(bw);
        _unnamed6.Write(bw);
        _offsetToCompressedData.Write(bw);
        _defaultData.Write(bw);
        _frameData.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _frameInfo.WriteBinary(writer);
        _defaultData.WriteBinary(writer);
        _frameData.WriteBinary(writer);
      }
    }
  }
}
