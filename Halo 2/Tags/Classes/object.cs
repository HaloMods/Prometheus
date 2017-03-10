// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'object'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class @object : Interfaces.Pool.Tag {
    private ObjectBlockBlock objectValues = new ObjectBlockBlock();
    public virtual ObjectBlockBlock ObjectValues {
      get {
        return objectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ObjectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "object";
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
objectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
objectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
objectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
objectValues.WriteChildData(writer);
    }
    #endregion
    public class ObjectBlockBlock : IBlock {
      private Pad _unnamed0;
      private Flags _flags;
      private Real _boundingRadius = new Real();
      private RealPoint3D _boundingOffset = new RealPoint3D();
      private Real _accelerationScale = new Real();
      private Enum _lightmapShadowMode;
      private Enum _sweetenerSize;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Real _dynamicLightSphereRadius = new Real();
      private RealPoint3D _dynamicLightSphereOffset = new RealPoint3D();
      private StringId _defaultModelVariant = new StringId();
      private TagReference _model = new TagReference();
      private TagReference _crateObject = new TagReference();
      private TagReference _modifierShader = new TagReference();
      private TagReference _creationEffect = new TagReference();
      private TagReference _materialEffects = new TagReference();
      private Block _aiProperties = new Block();
      private Block _functions = new Block();
      private Real _applyCollisionDamageScale = new Real();
      private Real _minGameAccDefault = new Real();
      private Real _maxGameAccDefault = new Real();
      private Real _minGameScaleDefault = new Real();
      private Real _maxGameScaleDefault = new Real();
      private Real _minAbsAccDefault = new Real();
      private Real _maxAbsAccDefault = new Real();
      private Real _minAbsScaleDefault = new Real();
      private Real _maxAbsScaleDefault = new Real();
      private ShortInteger _hudTextMessageIndex = new ShortInteger();
      private Pad _unnamed3;
      private Block _attachments = new Block();
      private Block _widgets = new Block();
      private Block _oldFunctions = new Block();
      private Block _changeColors = new Block();
      private Block _predictedResources = new Block();
      public BlockCollection<ObjectAiPropertiesBlockBlock> _aiPropertiesList = new BlockCollection<ObjectAiPropertiesBlockBlock>();
      public BlockCollection<ObjectFunctionBlockBlock> _functionsList = new BlockCollection<ObjectFunctionBlockBlock>();
      public BlockCollection<ObjectAttachmentBlockBlock> _attachmentsList = new BlockCollection<ObjectAttachmentBlockBlock>();
      public BlockCollection<ObjectWidgetBlockBlock> _widgetsList = new BlockCollection<ObjectWidgetBlockBlock>();
      public BlockCollection<OldObjectFunctionBlockBlock> _oldFunctionsList = new BlockCollection<OldObjectFunctionBlockBlock>();
      public BlockCollection<ObjectChangeColorsBlock> _changeColorsList = new BlockCollection<ObjectChangeColorsBlock>();
      public BlockCollection<PredictedResourceBlockBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ObjectBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
        this._lightmapShadowMode = new Enum(2);
        this._sweetenerSize = new Enum(1);
        this._unnamed1 = new Pad(1);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<ObjectAiPropertiesBlockBlock> AiProperties {
        get {
          return this._aiPropertiesList;
        }
      }
      public BlockCollection<ObjectFunctionBlockBlock> Functions {
        get {
          return this._functionsList;
        }
      }
      public BlockCollection<ObjectAttachmentBlockBlock> Attachments {
        get {
          return this._attachmentsList;
        }
      }
      public BlockCollection<ObjectWidgetBlockBlock> Widgets {
        get {
          return this._widgetsList;
        }
      }
      public BlockCollection<OldObjectFunctionBlockBlock> OldFunctions {
        get {
          return this._oldFunctionsList;
        }
      }
      public BlockCollection<ObjectChangeColorsBlock> ChangeColors {
        get {
          return this._changeColorsList;
        }
      }
      public BlockCollection<PredictedResourceBlockBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_model.Value);
references.Add(_crateObject.Value);
references.Add(_modifierShader.Value);
references.Add(_creationEffect.Value);
references.Add(_materialEffects.Value);
for (int x=0; x<AiProperties.BlockCount; x++)
{
  IBlock block = AiProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Functions.BlockCount; x++)
{
  IBlock block = Functions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Attachments.BlockCount; x++)
{
  IBlock block = Attachments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Widgets.BlockCount; x++)
{
  IBlock block = Widgets.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OldFunctions.BlockCount; x++)
{
  IBlock block = OldFunctions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ChangeColors.BlockCount; x++)
{
  IBlock block = ChangeColors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
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
      public Real BoundingRadius {
        get {
          return this._boundingRadius;
        }
        set {
          this._boundingRadius = value;
        }
      }
      public RealPoint3D BoundingOffset {
        get {
          return this._boundingOffset;
        }
        set {
          this._boundingOffset = value;
        }
      }
      public Real AccelerationScale {
        get {
          return this._accelerationScale;
        }
        set {
          this._accelerationScale = value;
        }
      }
      public Enum LightmapShadowMode {
        get {
          return this._lightmapShadowMode;
        }
        set {
          this._lightmapShadowMode = value;
        }
      }
      public Enum SweetenerSize {
        get {
          return this._sweetenerSize;
        }
        set {
          this._sweetenerSize = value;
        }
      }
      public Real DynamicLightSphereRadius {
        get {
          return this._dynamicLightSphereRadius;
        }
        set {
          this._dynamicLightSphereRadius = value;
        }
      }
      public RealPoint3D DynamicLightSphereOffset {
        get {
          return this._dynamicLightSphereOffset;
        }
        set {
          this._dynamicLightSphereOffset = value;
        }
      }
      public StringId DefaultModelVariant {
        get {
          return this._defaultModelVariant;
        }
        set {
          this._defaultModelVariant = value;
        }
      }
      public TagReference Model {
        get {
          return this._model;
        }
        set {
          this._model = value;
        }
      }
      public TagReference CrateObject {
        get {
          return this._crateObject;
        }
        set {
          this._crateObject = value;
        }
      }
      public TagReference ModifierShader {
        get {
          return this._modifierShader;
        }
        set {
          this._modifierShader = value;
        }
      }
      public TagReference CreationEffect {
        get {
          return this._creationEffect;
        }
        set {
          this._creationEffect = value;
        }
      }
      public TagReference MaterialEffects {
        get {
          return this._materialEffects;
        }
        set {
          this._materialEffects = value;
        }
      }
      public Real ApplyCollisionDamageScale {
        get {
          return this._applyCollisionDamageScale;
        }
        set {
          this._applyCollisionDamageScale = value;
        }
      }
      public Real MinGameAccDefault {
        get {
          return this._minGameAccDefault;
        }
        set {
          this._minGameAccDefault = value;
        }
      }
      public Real MaxGameAccDefault {
        get {
          return this._maxGameAccDefault;
        }
        set {
          this._maxGameAccDefault = value;
        }
      }
      public Real MinGameScaleDefault {
        get {
          return this._minGameScaleDefault;
        }
        set {
          this._minGameScaleDefault = value;
        }
      }
      public Real MaxGameScaleDefault {
        get {
          return this._maxGameScaleDefault;
        }
        set {
          this._maxGameScaleDefault = value;
        }
      }
      public Real MinAbsAccDefault {
        get {
          return this._minAbsAccDefault;
        }
        set {
          this._minAbsAccDefault = value;
        }
      }
      public Real MaxAbsAccDefault {
        get {
          return this._maxAbsAccDefault;
        }
        set {
          this._maxAbsAccDefault = value;
        }
      }
      public Real MinAbsScaleDefault {
        get {
          return this._minAbsScaleDefault;
        }
        set {
          this._minAbsScaleDefault = value;
        }
      }
      public Real MaxAbsScaleDefault {
        get {
          return this._maxAbsScaleDefault;
        }
        set {
          this._maxAbsScaleDefault = value;
        }
      }
      public ShortInteger HudTextMessageIndex {
        get {
          return this._hudTextMessageIndex;
        }
        set {
          this._hudTextMessageIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _boundingRadius.Read(reader);
        _boundingOffset.Read(reader);
        _accelerationScale.Read(reader);
        _lightmapShadowMode.Read(reader);
        _sweetenerSize.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _dynamicLightSphereRadius.Read(reader);
        _dynamicLightSphereOffset.Read(reader);
        _defaultModelVariant.Read(reader);
        _model.Read(reader);
        _crateObject.Read(reader);
        _modifierShader.Read(reader);
        _creationEffect.Read(reader);
        _materialEffects.Read(reader);
        _aiProperties.Read(reader);
        _functions.Read(reader);
        _applyCollisionDamageScale.Read(reader);
        _minGameAccDefault.Read(reader);
        _maxGameAccDefault.Read(reader);
        _minGameScaleDefault.Read(reader);
        _maxGameScaleDefault.Read(reader);
        _minAbsAccDefault.Read(reader);
        _maxAbsAccDefault.Read(reader);
        _minAbsScaleDefault.Read(reader);
        _maxAbsScaleDefault.Read(reader);
        _hudTextMessageIndex.Read(reader);
        _unnamed3.Read(reader);
        _attachments.Read(reader);
        _widgets.Read(reader);
        _oldFunctions.Read(reader);
        _changeColors.Read(reader);
        _predictedResources.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _defaultModelVariant.ReadString(reader);
        _model.ReadString(reader);
        _crateObject.ReadString(reader);
        _modifierShader.ReadString(reader);
        _creationEffect.ReadString(reader);
        _materialEffects.ReadString(reader);
        for (x = 0; (x < _aiProperties.Count); x = (x + 1)) {
          AiProperties.Add(new ObjectAiPropertiesBlockBlock());
          AiProperties[x].Read(reader);
        }
        for (x = 0; (x < _aiProperties.Count); x = (x + 1)) {
          AiProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions.Add(new ObjectFunctionBlockBlock());
          Functions[x].Read(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments.Add(new ObjectAttachmentBlockBlock());
          Attachments[x].Read(reader);
        }
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets.Add(new ObjectWidgetBlockBlock());
          Widgets[x].Read(reader);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _oldFunctions.Count); x = (x + 1)) {
          OldFunctions.Add(new OldObjectFunctionBlockBlock());
          OldFunctions[x].Read(reader);
        }
        for (x = 0; (x < _oldFunctions.Count); x = (x + 1)) {
          OldFunctions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors.Add(new ObjectChangeColorsBlock());
          ChangeColors[x].Read(reader);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlockBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _boundingRadius.Write(bw);
        _boundingOffset.Write(bw);
        _accelerationScale.Write(bw);
        _lightmapShadowMode.Write(bw);
        _sweetenerSize.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _dynamicLightSphereRadius.Write(bw);
        _dynamicLightSphereOffset.Write(bw);
        _defaultModelVariant.Write(bw);
        _model.Write(bw);
        _crateObject.Write(bw);
        _modifierShader.Write(bw);
        _creationEffect.Write(bw);
        _materialEffects.Write(bw);
_aiProperties.Count = AiProperties.Count;
        _aiProperties.Write(bw);
_functions.Count = Functions.Count;
        _functions.Write(bw);
        _applyCollisionDamageScale.Write(bw);
        _minGameAccDefault.Write(bw);
        _maxGameAccDefault.Write(bw);
        _minGameScaleDefault.Write(bw);
        _maxGameScaleDefault.Write(bw);
        _minAbsAccDefault.Write(bw);
        _maxAbsAccDefault.Write(bw);
        _minAbsScaleDefault.Write(bw);
        _maxAbsScaleDefault.Write(bw);
        _hudTextMessageIndex.Write(bw);
        _unnamed3.Write(bw);
_attachments.Count = Attachments.Count;
        _attachments.Write(bw);
_widgets.Count = Widgets.Count;
        _widgets.Write(bw);
_oldFunctions.Count = OldFunctions.Count;
        _oldFunctions.Write(bw);
_changeColors.Count = ChangeColors.Count;
        _changeColors.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _defaultModelVariant.WriteString(writer);
        _model.WriteString(writer);
        _crateObject.WriteString(writer);
        _modifierShader.WriteString(writer);
        _creationEffect.WriteString(writer);
        _materialEffects.WriteString(writer);
        for (x = 0; (x < _aiProperties.Count); x = (x + 1)) {
          AiProperties[x].Write(writer);
        }
        for (x = 0; (x < _aiProperties.Count); x = (x + 1)) {
          AiProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].Write(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments[x].Write(writer);
        }
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets[x].Write(writer);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets[x].WriteChildData(writer);
        }
        for (x = 0; (x < _oldFunctions.Count); x = (x + 1)) {
          OldFunctions[x].Write(writer);
        }
        for (x = 0; (x < _oldFunctions.Count); x = (x + 1)) {
          OldFunctions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].Write(writer);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
      }
    }
    public class ObjectAiPropertiesBlockBlock : IBlock {
      private Flags _aiFlags;
      private StringId _aiTypeName = new StringId();
      private Pad _unnamed0;
      private Enum _aiSize;
      private Enum _leapJumpSpeed;
public event System.EventHandler BlockNameChanged;
      public ObjectAiPropertiesBlockBlock() {
        this._aiFlags = new Flags(4);
        this._unnamed0 = new Pad(4);
        this._aiSize = new Enum(2);
        this._leapJumpSpeed = new Enum(2);
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
      public Flags AiFlags {
        get {
          return this._aiFlags;
        }
        set {
          this._aiFlags = value;
        }
      }
      public StringId AiTypeName {
        get {
          return this._aiTypeName;
        }
        set {
          this._aiTypeName = value;
        }
      }
      public Enum AiSize {
        get {
          return this._aiSize;
        }
        set {
          this._aiSize = value;
        }
      }
      public Enum LeapJumpSpeed {
        get {
          return this._leapJumpSpeed;
        }
        set {
          this._leapJumpSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _aiFlags.Read(reader);
        _aiTypeName.Read(reader);
        _unnamed0.Read(reader);
        _aiSize.Read(reader);
        _leapJumpSpeed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _aiTypeName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _aiFlags.Write(bw);
        _aiTypeName.Write(bw);
        _unnamed0.Write(bw);
        _aiSize.Write(bw);
        _leapJumpSpeed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _aiTypeName.WriteString(writer);
      }
    }
    public class ObjectFunctionBlockBlock : IBlock {
      private Flags _flags;
      private StringId _importName = new StringId();
      private StringId _exportName = new StringId();
      private StringId _turnOffWith = new StringId();
      private Real _minValue = new Real();
      private Block _data = new Block();
      private StringId _scaleBy = new StringId();
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ObjectFunctionBlockBlock() {
        this._flags = new Flags(4);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public StringId ImportName {
        get {
          return this._importName;
        }
        set {
          this._importName = value;
        }
      }
      public StringId ExportName {
        get {
          return this._exportName;
        }
        set {
          this._exportName = value;
        }
      }
      public StringId TurnOffWith {
        get {
          return this._turnOffWith;
        }
        set {
          this._turnOffWith = value;
        }
      }
      public Real MinValue {
        get {
          return this._minValue;
        }
        set {
          this._minValue = value;
        }
      }
      public StringId ScaleBy {
        get {
          return this._scaleBy;
        }
        set {
          this._scaleBy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _importName.Read(reader);
        _exportName.Read(reader);
        _turnOffWith.Read(reader);
        _minValue.Read(reader);
        _data.Read(reader);
        _scaleBy.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _importName.ReadString(reader);
        _exportName.ReadString(reader);
        _turnOffWith.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
        _scaleBy.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _importName.Write(bw);
        _exportName.Write(bw);
        _turnOffWith.Write(bw);
        _minValue.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _scaleBy.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _importName.WriteString(writer);
        _exportName.WriteString(writer);
        _turnOffWith.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
        _scaleBy.WriteString(writer);
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
    public class ObjectAttachmentBlockBlock : IBlock {
      private TagReference _type = new TagReference();
      private StringId _marker = new StringId();
      private Enum _changeColor;
      private Pad _unnamed0;
      private StringId _primaryScale = new StringId();
      private StringId _secondaryScale = new StringId();
public event System.EventHandler BlockNameChanged;
      public ObjectAttachmentBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._changeColor = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_type.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
        }
      }
      public TagReference Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public Enum ChangeColor {
        get {
          return this._changeColor;
        }
        set {
          this._changeColor = value;
        }
      }
      public StringId PrimaryScale {
        get {
          return this._primaryScale;
        }
        set {
          this._primaryScale = value;
        }
      }
      public StringId SecondaryScale {
        get {
          return this._secondaryScale;
        }
        set {
          this._secondaryScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _marker.Read(reader);
        _changeColor.Read(reader);
        _unnamed0.Read(reader);
        _primaryScale.Read(reader);
        _secondaryScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _type.ReadString(reader);
        _marker.ReadString(reader);
        _primaryScale.ReadString(reader);
        _secondaryScale.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _marker.Write(bw);
        _changeColor.Write(bw);
        _unnamed0.Write(bw);
        _primaryScale.Write(bw);
        _secondaryScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _type.WriteString(writer);
        _marker.WriteString(writer);
        _primaryScale.WriteString(writer);
        _secondaryScale.WriteString(writer);
      }
    }
    public class ObjectWidgetBlockBlock : IBlock {
      private TagReference _type = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ObjectWidgetBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_type.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _type.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _type.WriteString(writer);
      }
    }
    public class OldObjectFunctionBlockBlock : IBlock {
      private Pad _unnamed0;
      private StringId _unnamed1 = new StringId();
public event System.EventHandler BlockNameChanged;
      public OldObjectFunctionBlockBlock() {
        this._unnamed0 = new Pad(76);
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
      public StringId unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unnamed1.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unnamed1.WriteString(writer);
      }
    }
    public class ObjectChangeColorsBlock : IBlock {
      private Block _initialPermutations = new Block();
      private Block _functions = new Block();
      public BlockCollection<ObjectChangeColorInitialPermutationBlock> _initialPermutationsList = new BlockCollection<ObjectChangeColorInitialPermutationBlock>();
      public BlockCollection<ObjectChangeColorFunctionBlock> _functionsList = new BlockCollection<ObjectChangeColorFunctionBlock>();
public event System.EventHandler BlockNameChanged;
      public ObjectChangeColorsBlock() {
      }
      public BlockCollection<ObjectChangeColorInitialPermutationBlock> InitialPermutations {
        get {
          return this._initialPermutationsList;
        }
      }
      public BlockCollection<ObjectChangeColorFunctionBlock> Functions {
        get {
          return this._functionsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<InitialPermutations.BlockCount; x++)
{
  IBlock block = InitialPermutations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Functions.BlockCount; x++)
{
  IBlock block = Functions.GetBlock(x);
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
        _initialPermutations.Read(reader);
        _functions.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _initialPermutations.Count); x = (x + 1)) {
          InitialPermutations.Add(new ObjectChangeColorInitialPermutationBlock());
          InitialPermutations[x].Read(reader);
        }
        for (x = 0; (x < _initialPermutations.Count); x = (x + 1)) {
          InitialPermutations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions.Add(new ObjectChangeColorFunctionBlock());
          Functions[x].Read(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_initialPermutations.Count = InitialPermutations.Count;
        _initialPermutations.Write(bw);
_functions.Count = Functions.Count;
        _functions.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _initialPermutations.Count); x = (x + 1)) {
          InitialPermutations[x].Write(writer);
        }
        for (x = 0; (x < _initialPermutations.Count); x = (x + 1)) {
          InitialPermutations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].Write(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].WriteChildData(writer);
        }
      }
    }
    public class ObjectChangeColorInitialPermutationBlock : IBlock {
      private Real _weight = new Real();
      private RealRGBColor _colorLowerBound = new RealRGBColor();
      private RealRGBColor _colorUpperBound = new RealRGBColor();
      private StringId _variantName = new StringId();
public event System.EventHandler BlockNameChanged;
      public ObjectChangeColorInitialPermutationBlock() {
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
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public RealRGBColor ColorLowerBound {
        get {
          return this._colorLowerBound;
        }
        set {
          this._colorLowerBound = value;
        }
      }
      public RealRGBColor ColorUpperBound {
        get {
          return this._colorUpperBound;
        }
        set {
          this._colorUpperBound = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _weight.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _variantName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _weight.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _variantName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
      }
    }
    public class ObjectChangeColorFunctionBlock : IBlock {
      private Pad _unnamed0;
      private Flags _scaleFlags;
      private RealRGBColor _colorLowerBound = new RealRGBColor();
      private RealRGBColor _colorUpperBound = new RealRGBColor();
      private StringId _darkenBy = new StringId();
      private StringId _scaleBy = new StringId();
public event System.EventHandler BlockNameChanged;
      public ObjectChangeColorFunctionBlock() {
        this._unnamed0 = new Pad(4);
        this._scaleFlags = new Flags(4);
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
      public Flags ScaleFlags {
        get {
          return this._scaleFlags;
        }
        set {
          this._scaleFlags = value;
        }
      }
      public RealRGBColor ColorLowerBound {
        get {
          return this._colorLowerBound;
        }
        set {
          this._colorLowerBound = value;
        }
      }
      public RealRGBColor ColorUpperBound {
        get {
          return this._colorUpperBound;
        }
        set {
          this._colorUpperBound = value;
        }
      }
      public StringId DarkenBy {
        get {
          return this._darkenBy;
        }
        set {
          this._darkenBy = value;
        }
      }
      public StringId ScaleBy {
        get {
          return this._scaleBy;
        }
        set {
          this._scaleBy = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _scaleFlags.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _darkenBy.Read(reader);
        _scaleBy.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _darkenBy.ReadString(reader);
        _scaleBy.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _scaleFlags.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
        _darkenBy.Write(bw);
        _scaleBy.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _darkenBy.WriteString(writer);
        _scaleBy.WriteString(writer);
      }
    }
    public class PredictedResourceBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _resourceIndex = new ShortInteger();
      private PredictedResource _predictedResourceTag = new PredictedResource();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlockBlock() {
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
      public ShortInteger ResourceIndex {
        get {
          return this._resourceIndex;
        }
        set {
          this._resourceIndex = value;
        }
      }
      public PredictedResource PredictedResourceTag {
        get {
          return this._predictedResourceTag;
        }
        set {
          this._predictedResourceTag = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _predictedResourceTag.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _predictedResourceTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _predictedResourceTag.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _predictedResourceTag.WriteString(writer);
      }
    }
  }
}
