// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'object'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class @object : Interfaces.Pool.Tag {
    private ObjectBlock objectValues = new ObjectBlock();
    public virtual ObjectBlock ObjectValues {
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
    public class ObjectBlock : IBlock {
      private Pad _unnamed;
      private Flags _flags;
      private Real _boundingRadius = new Real();
      private RealPoint3D _boundingOffset = new RealPoint3D();
      private RealPoint3D _originOffset = new RealPoint3D();
      private Real _accelerationScale = new Real();
      private Pad _unnamed2;
      private TagReference _model = new TagReference();
      private TagReference _animationGraph = new TagReference();
      private Pad _unnamed3;
      private TagReference _collisionModel = new TagReference();
      private TagReference _physics = new TagReference();
      private TagReference _modifierShader = new TagReference();
      private TagReference _creationEffect = new TagReference();
      private Pad _unnamed4;
      private Real _renderBoundingRadius = new Real();
      private Enum _aIn = new Enum();
      private Enum _bIn = new Enum();
      private Enum _cIn = new Enum();
      private Enum _dIn = new Enum();
      private Pad _unnamed5;
      private ShortInteger _hudTextMessageIndex = new ShortInteger();
      private ShortInteger _forcedShaderPermuationIndex = new ShortInteger();
      private Block _attachments = new Block();
      private Block _widgets = new Block();
      private Block _functions = new Block();
      private Block _changeColors = new Block();
      private Block _predictedResources = new Block();
      public BlockCollection<ObjectAttachmentBlock> _attachmentsList = new BlockCollection<ObjectAttachmentBlock>();
      public BlockCollection<ObjectWidgetBlock> _widgetsList = new BlockCollection<ObjectWidgetBlock>();
      public BlockCollection<ObjectFunctionBlock> _functionsList = new BlockCollection<ObjectFunctionBlock>();
      public BlockCollection<ObjectChangeColorsBlock> _changeColorsList = new BlockCollection<ObjectChangeColorsBlock>();
      public BlockCollection<PredictedResourceBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlock>();
public event System.EventHandler BlockNameChanged;
      public ObjectBlock() {
        this._unnamed = new Pad(2);
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(40);
        this._unnamed4 = new Pad(84);
        this._unnamed5 = new Pad(44);
      }
      public BlockCollection<ObjectAttachmentBlock> Attachments {
        get {
          return this._attachmentsList;
        }
      }
      public BlockCollection<ObjectWidgetBlock> Widgets {
        get {
          return this._widgetsList;
        }
      }
      public BlockCollection<ObjectFunctionBlock> Functions {
        get {
          return this._functionsList;
        }
      }
      public BlockCollection<ObjectChangeColorsBlock> ChangeColors {
        get {
          return this._changeColorsList;
        }
      }
      public BlockCollection<PredictedResourceBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_model.Value);
references.Add(_animationGraph.Value);
references.Add(_collisionModel.Value);
references.Add(_physics.Value);
references.Add(_modifierShader.Value);
references.Add(_creationEffect.Value);
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
for (int x=0; x<Functions.BlockCount; x++)
{
  IBlock block = Functions.GetBlock(x);
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
      public RealPoint3D OriginOffset {
        get {
          return this._originOffset;
        }
        set {
          this._originOffset = value;
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
      public TagReference Model {
        get {
          return this._model;
        }
        set {
          this._model = value;
        }
      }
      public TagReference AnimationGraph {
        get {
          return this._animationGraph;
        }
        set {
          this._animationGraph = value;
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
      public TagReference Physics {
        get {
          return this._physics;
        }
        set {
          this._physics = value;
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
      public Real RenderBoundingRadius {
        get {
          return this._renderBoundingRadius;
        }
        set {
          this._renderBoundingRadius = value;
        }
      }
      public Enum AIn {
        get {
          return this._aIn;
        }
        set {
          this._aIn = value;
        }
      }
      public Enum BIn {
        get {
          return this._bIn;
        }
        set {
          this._bIn = value;
        }
      }
      public Enum CIn {
        get {
          return this._cIn;
        }
        set {
          this._cIn = value;
        }
      }
      public Enum DIn {
        get {
          return this._dIn;
        }
        set {
          this._dIn = value;
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
      public ShortInteger ForcedShaderPermuationIndex {
        get {
          return this._forcedShaderPermuationIndex;
        }
        set {
          this._forcedShaderPermuationIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _flags.Read(reader);
        _boundingRadius.Read(reader);
        _boundingOffset.Read(reader);
        _originOffset.Read(reader);
        _accelerationScale.Read(reader);
        _unnamed2.Read(reader);
        _model.Read(reader);
        _animationGraph.Read(reader);
        _unnamed3.Read(reader);
        _collisionModel.Read(reader);
        _physics.Read(reader);
        _modifierShader.Read(reader);
        _creationEffect.Read(reader);
        _unnamed4.Read(reader);
        _renderBoundingRadius.Read(reader);
        _aIn.Read(reader);
        _bIn.Read(reader);
        _cIn.Read(reader);
        _dIn.Read(reader);
        _unnamed5.Read(reader);
        _hudTextMessageIndex.Read(reader);
        _forcedShaderPermuationIndex.Read(reader);
        _attachments.Read(reader);
        _widgets.Read(reader);
        _functions.Read(reader);
        _changeColors.Read(reader);
        _predictedResources.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _model.ReadString(reader);
        _animationGraph.ReadString(reader);
        _collisionModel.ReadString(reader);
        _physics.ReadString(reader);
        _modifierShader.ReadString(reader);
        _creationEffect.ReadString(reader);
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments.Add(new ObjectAttachmentBlock());
          Attachments[x].Read(reader);
        }
        for (x = 0; (x < _attachments.Count); x = (x + 1)) {
          Attachments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets.Add(new ObjectWidgetBlock());
          Widgets[x].Read(reader);
        }
        for (x = 0; (x < _widgets.Count); x = (x + 1)) {
          Widgets[x].ReadChildData(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions.Add(new ObjectFunctionBlock());
          Functions[x].Read(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors.Add(new ObjectChangeColorsBlock());
          ChangeColors[x].Read(reader);
        }
        for (x = 0; (x < _changeColors.Count); x = (x + 1)) {
          ChangeColors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _flags.Write(bw);
        _boundingRadius.Write(bw);
        _boundingOffset.Write(bw);
        _originOffset.Write(bw);
        _accelerationScale.Write(bw);
        _unnamed2.Write(bw);
        _model.Write(bw);
        _animationGraph.Write(bw);
        _unnamed3.Write(bw);
        _collisionModel.Write(bw);
        _physics.Write(bw);
        _modifierShader.Write(bw);
        _creationEffect.Write(bw);
        _unnamed4.Write(bw);
        _renderBoundingRadius.Write(bw);
        _aIn.Write(bw);
        _bIn.Write(bw);
        _cIn.Write(bw);
        _dIn.Write(bw);
        _unnamed5.Write(bw);
        _hudTextMessageIndex.Write(bw);
        _forcedShaderPermuationIndex.Write(bw);
_attachments.Count = Attachments.Count;
        _attachments.Write(bw);
_widgets.Count = Widgets.Count;
        _widgets.Write(bw);
_functions.Count = Functions.Count;
        _functions.Write(bw);
_changeColors.Count = ChangeColors.Count;
        _changeColors.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _model.WriteString(writer);
        _animationGraph.WriteString(writer);
        _collisionModel.WriteString(writer);
        _physics.WriteString(writer);
        _modifierShader.WriteString(writer);
        _creationEffect.WriteString(writer);
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
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].Write(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].WriteChildData(writer);
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
    public class ObjectAttachmentBlock : IBlock {
      private TagReference _type = new TagReference();
      private FixedLengthString _marker = new FixedLengthString();
      private Enum _primaryScale = new Enum();
      private Enum _secondaryScale = new Enum();
      private Enum _changeColor = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ObjectAttachmentBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(16);
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
      public FixedLengthString Marker {
        get {
          return this._marker;
        }
        set {
          this._marker = value;
        }
      }
      public Enum PrimaryScale {
        get {
          return this._primaryScale;
        }
        set {
          this._primaryScale = value;
        }
      }
      public Enum SecondaryScale {
        get {
          return this._secondaryScale;
        }
        set {
          this._secondaryScale = value;
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _marker.Read(reader);
        _primaryScale.Read(reader);
        _secondaryScale.Read(reader);
        _changeColor.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _type.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _marker.Write(bw);
        _primaryScale.Write(bw);
        _secondaryScale.Write(bw);
        _changeColor.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _type.WriteString(writer);
      }
    }
    public class ObjectWidgetBlock : IBlock {
      private TagReference _reference = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ObjectWidgetBlock() {
if (this._reference is System.ComponentModel.INotifyPropertyChanged)
  (this._reference as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_reference.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _reference.ToString();
        }
      }
      public TagReference Reference {
        get {
          return this._reference;
        }
        set {
          this._reference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _reference.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _reference.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _reference.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _reference.WriteString(writer);
      }
    }
    public class ObjectFunctionBlock : IBlock {
      private Flags _flags;
      private Real _period = new Real();
      private Enum _scalePeriodBy = new Enum();
      private Enum _function = new Enum();
      private Enum _scaleFunctionBy = new Enum();
      private Enum _wobbleFunction = new Enum();
      private Real _wobblePeriod = new Real();
      private Real _wobbleMagnitude = new Real();
      private RealFraction _squareWaveThreshold = new RealFraction();
      private ShortInteger _stepCount = new ShortInteger();
      private Enum _mapTo = new Enum();
      private ShortInteger _sawtoothCount = new ShortInteger();
      private Enum _add = new Enum();
      private Enum _scaleResultBy = new Enum();
      private Enum _boundsMode = new Enum();
      private RealFractionBounds _bounds = new RealFractionBounds();
      private Pad _unnamed;
      private Pad _unnamed2;
      private ShortBlockIndex _turnOffWith = new ShortBlockIndex();
      private Real _scaleBy = new Real();
      private Pad _unnamed3;
      private Pad _unnamed4;
      private FixedLengthString _usage = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public ObjectFunctionBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(252);
        this._unnamed4 = new Pad(16);
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
      public Real Period {
        get {
          return this._period;
        }
        set {
          this._period = value;
        }
      }
      public Enum ScalePeriodBy {
        get {
          return this._scalePeriodBy;
        }
        set {
          this._scalePeriodBy = value;
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
      public Enum ScaleFunctionBy {
        get {
          return this._scaleFunctionBy;
        }
        set {
          this._scaleFunctionBy = value;
        }
      }
      public Enum WobbleFunction {
        get {
          return this._wobbleFunction;
        }
        set {
          this._wobbleFunction = value;
        }
      }
      public Real WobblePeriod {
        get {
          return this._wobblePeriod;
        }
        set {
          this._wobblePeriod = value;
        }
      }
      public Real WobbleMagnitude {
        get {
          return this._wobbleMagnitude;
        }
        set {
          this._wobbleMagnitude = value;
        }
      }
      public RealFraction SquareWaveThreshold {
        get {
          return this._squareWaveThreshold;
        }
        set {
          this._squareWaveThreshold = value;
        }
      }
      public ShortInteger StepCount {
        get {
          return this._stepCount;
        }
        set {
          this._stepCount = value;
        }
      }
      public Enum MapTo {
        get {
          return this._mapTo;
        }
        set {
          this._mapTo = value;
        }
      }
      public ShortInteger SawtoothCount {
        get {
          return this._sawtoothCount;
        }
        set {
          this._sawtoothCount = value;
        }
      }
      public Enum Add {
        get {
          return this._add;
        }
        set {
          this._add = value;
        }
      }
      public Enum ScaleResultBy {
        get {
          return this._scaleResultBy;
        }
        set {
          this._scaleResultBy = value;
        }
      }
      public Enum BoundsMode {
        get {
          return this._boundsMode;
        }
        set {
          this._boundsMode = value;
        }
      }
      public RealFractionBounds Bounds {
        get {
          return this._bounds;
        }
        set {
          this._bounds = value;
        }
      }
      public ShortBlockIndex TurnOffWith {
        get {
          return this._turnOffWith;
        }
        set {
          this._turnOffWith = value;
        }
      }
      public Real ScaleBy {
        get {
          return this._scaleBy;
        }
        set {
          this._scaleBy = value;
        }
      }
      public FixedLengthString Usage {
        get {
          return this._usage;
        }
        set {
          this._usage = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _period.Read(reader);
        _scalePeriodBy.Read(reader);
        _function.Read(reader);
        _scaleFunctionBy.Read(reader);
        _wobbleFunction.Read(reader);
        _wobblePeriod.Read(reader);
        _wobbleMagnitude.Read(reader);
        _squareWaveThreshold.Read(reader);
        _stepCount.Read(reader);
        _mapTo.Read(reader);
        _sawtoothCount.Read(reader);
        _add.Read(reader);
        _scaleResultBy.Read(reader);
        _boundsMode.Read(reader);
        _bounds.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _turnOffWith.Read(reader);
        _scaleBy.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _usage.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _period.Write(bw);
        _scalePeriodBy.Write(bw);
        _function.Write(bw);
        _scaleFunctionBy.Write(bw);
        _wobbleFunction.Write(bw);
        _wobblePeriod.Write(bw);
        _wobbleMagnitude.Write(bw);
        _squareWaveThreshold.Write(bw);
        _stepCount.Write(bw);
        _mapTo.Write(bw);
        _sawtoothCount.Write(bw);
        _add.Write(bw);
        _scaleResultBy.Write(bw);
        _boundsMode.Write(bw);
        _bounds.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _turnOffWith.Write(bw);
        _scaleBy.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _usage.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ObjectChangeColorsBlock : IBlock {
      private Enum _darkenBy = new Enum();
      private Enum _scaleBy = new Enum();
      private Flags _scaleFlags;
      private RealRGBColor _colorLowerBound = new RealRGBColor();
      private RealRGBColor _colorUpperBound = new RealRGBColor();
      private Block _permutations = new Block();
      public BlockCollection<ObjectChangeColorPermutationsBlock> _permutationsList = new BlockCollection<ObjectChangeColorPermutationsBlock>();
public event System.EventHandler BlockNameChanged;
      public ObjectChangeColorsBlock() {
        this._scaleFlags = new Flags(4);
      }
      public BlockCollection<ObjectChangeColorPermutationsBlock> Permutations {
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
return "";
        }
      }
      public Enum DarkenBy {
        get {
          return this._darkenBy;
        }
        set {
          this._darkenBy = value;
        }
      }
      public Enum ScaleBy {
        get {
          return this._scaleBy;
        }
        set {
          this._scaleBy = value;
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
      public virtual void Read(BinaryReader reader) {
        _darkenBy.Read(reader);
        _scaleBy.Read(reader);
        _scaleFlags.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
        _permutations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations.Add(new ObjectChangeColorPermutationsBlock());
          Permutations[x].Read(reader);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _darkenBy.Write(bw);
        _scaleBy.Write(bw);
        _scaleFlags.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
_permutations.Count = Permutations.Count;
        _permutations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].Write(writer);
        }
        for (x = 0; (x < _permutations.Count); x = (x + 1)) {
          Permutations[x].WriteChildData(writer);
        }
      }
    }
    public class ObjectChangeColorPermutationsBlock : IBlock {
      private Real _weight = new Real();
      private RealRGBColor _colorLowerBound = new RealRGBColor();
      private RealRGBColor _colorUpperBound = new RealRGBColor();
public event System.EventHandler BlockNameChanged;
      public ObjectChangeColorPermutationsBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _weight.Read(reader);
        _colorLowerBound.Read(reader);
        _colorUpperBound.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _weight.Write(bw);
        _colorLowerBound.Write(bw);
        _colorUpperBound.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PredictedResourceBlock : IBlock {
      private Enum _type = new Enum();
      private ShortInteger _resourceIndex = new ShortInteger();
      private LongInteger _tagIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlock() {
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
      public LongInteger TagIndex {
        get {
          return this._tagIndex;
        }
        set {
          this._tagIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _tagIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _tagIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
