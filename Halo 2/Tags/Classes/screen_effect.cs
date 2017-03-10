// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'screen_effect'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class screen_effect : Interfaces.Pool.Tag {
    private ScreenEffectBlockBlock screenEffectValues = new ScreenEffectBlockBlock();
    public virtual ScreenEffectBlockBlock ScreenEffectValues {
      get {
        return screenEffectValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ScreenEffectValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "screen_effect";
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
screenEffectValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
screenEffectValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
screenEffectValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
screenEffectValues.WriteChildData(writer);
    }
    #endregion
    public class ScreenEffectBlockBlock : IBlock {
      private Pad _unnamed0;
      private TagReference _shader = new TagReference();
      private Pad _unnamed1;
      private Block _passReferences = new Block();
      public BlockCollection<RasterizerScreenEffectPassReferenceBlockBlock> _passReferencesList = new BlockCollection<RasterizerScreenEffectPassReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScreenEffectBlockBlock() {
        this._unnamed0 = new Pad(64);
        this._unnamed1 = new Pad(64);
      }
      public BlockCollection<RasterizerScreenEffectPassReferenceBlockBlock> PassReferences {
        get {
          return this._passReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_shader.Value);
for (int x=0; x<PassReferences.BlockCount; x++)
{
  IBlock block = PassReferences.GetBlock(x);
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
      public TagReference Shader {
        get {
          return this._shader;
        }
        set {
          this._shader = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _shader.Read(reader);
        _unnamed1.Read(reader);
        _passReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _shader.ReadString(reader);
        for (x = 0; (x < _passReferences.Count); x = (x + 1)) {
          PassReferences.Add(new RasterizerScreenEffectPassReferenceBlockBlock());
          PassReferences[x].Read(reader);
        }
        for (x = 0; (x < _passReferences.Count); x = (x + 1)) {
          PassReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _shader.Write(bw);
        _unnamed1.Write(bw);
_passReferences.Count = PassReferences.Count;
        _passReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _shader.WriteString(writer);
        for (x = 0; (x < _passReferences.Count); x = (x + 1)) {
          PassReferences[x].Write(writer);
        }
        for (x = 0; (x < _passReferences.Count); x = (x + 1)) {
          PassReferences[x].WriteChildData(writer);
        }
      }
    }
    public class RasterizerScreenEffectPassReferenceBlockBlock : IBlock {
      private Data _explanation = new Data();
      private ShortInteger _layerPassIndex = new ShortInteger();
      private Pad _unnamed0;
      private CharInteger _primary0AndSecondary0 = new CharInteger();
      private CharInteger _primary0AndSecondary02 = new CharInteger();
      private CharInteger _primary0AndSecondary03 = new CharInteger();
      private CharInteger _primary0AndSecondary04 = new CharInteger();
      private Pad _unnamed1;
      private Enum _stage0Mode;
      private Enum _stage1Mode;
      private Enum _stage2Mode;
      private Enum _stage3Mode;
      private Block _advancedControl = new Block();
      private Enum _target;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Block _convolution = new Block();
      public BlockCollection<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock> _advancedControlList = new BlockCollection<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock>();
      public BlockCollection<RasterizerScreenEffectConvolutionBlockBlock> _convolutionList = new BlockCollection<RasterizerScreenEffectConvolutionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RasterizerScreenEffectPassReferenceBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(64);
        this._stage0Mode = new Enum(2);
        this._stage1Mode = new Enum(2);
        this._stage2Mode = new Enum(2);
        this._stage3Mode = new Enum(2);
        this._target = new Enum(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(64);
      }
      public BlockCollection<RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock> AdvancedControl {
        get {
          return this._advancedControlList;
        }
      }
      public BlockCollection<RasterizerScreenEffectConvolutionBlockBlock> Convolution {
        get {
          return this._convolutionList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<AdvancedControl.BlockCount; x++)
{
  IBlock block = AdvancedControl.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Convolution.BlockCount; x++)
{
  IBlock block = Convolution.GetBlock(x);
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
      public Data Explanation {
        get {
          return this._explanation;
        }
        set {
          this._explanation = value;
        }
      }
      public ShortInteger LayerPassIndex {
        get {
          return this._layerPassIndex;
        }
        set {
          this._layerPassIndex = value;
        }
      }
      public CharInteger Primary0AndSecondary0 {
        get {
          return this._primary0AndSecondary0;
        }
        set {
          this._primary0AndSecondary0 = value;
        }
      }
      public CharInteger Primary0AndSecondary02 {
        get {
          return this._primary0AndSecondary02;
        }
        set {
          this._primary0AndSecondary02 = value;
        }
      }
      public CharInteger Primary0AndSecondary03 {
        get {
          return this._primary0AndSecondary03;
        }
        set {
          this._primary0AndSecondary03 = value;
        }
      }
      public CharInteger Primary0AndSecondary04 {
        get {
          return this._primary0AndSecondary04;
        }
        set {
          this._primary0AndSecondary04 = value;
        }
      }
      public Enum Stage0Mode {
        get {
          return this._stage0Mode;
        }
        set {
          this._stage0Mode = value;
        }
      }
      public Enum Stage1Mode {
        get {
          return this._stage1Mode;
        }
        set {
          this._stage1Mode = value;
        }
      }
      public Enum Stage2Mode {
        get {
          return this._stage2Mode;
        }
        set {
          this._stage2Mode = value;
        }
      }
      public Enum Stage3Mode {
        get {
          return this._stage3Mode;
        }
        set {
          this._stage3Mode = value;
        }
      }
      public Enum Target {
        get {
          return this._target;
        }
        set {
          this._target = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _explanation.Read(reader);
        _layerPassIndex.Read(reader);
        _unnamed0.Read(reader);
        _primary0AndSecondary0.Read(reader);
        _primary0AndSecondary02.Read(reader);
        _primary0AndSecondary03.Read(reader);
        _primary0AndSecondary04.Read(reader);
        _unnamed1.Read(reader);
        _stage0Mode.Read(reader);
        _stage1Mode.Read(reader);
        _stage2Mode.Read(reader);
        _stage3Mode.Read(reader);
        _advancedControl.Read(reader);
        _target.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _convolution.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _explanation.ReadBinary(reader);
        for (x = 0; (x < _advancedControl.Count); x = (x + 1)) {
          AdvancedControl.Add(new RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock());
          AdvancedControl[x].Read(reader);
        }
        for (x = 0; (x < _advancedControl.Count); x = (x + 1)) {
          AdvancedControl[x].ReadChildData(reader);
        }
        for (x = 0; (x < _convolution.Count); x = (x + 1)) {
          Convolution.Add(new RasterizerScreenEffectConvolutionBlockBlock());
          Convolution[x].Read(reader);
        }
        for (x = 0; (x < _convolution.Count); x = (x + 1)) {
          Convolution[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _explanation.Write(bw);
        _layerPassIndex.Write(bw);
        _unnamed0.Write(bw);
        _primary0AndSecondary0.Write(bw);
        _primary0AndSecondary02.Write(bw);
        _primary0AndSecondary03.Write(bw);
        _primary0AndSecondary04.Write(bw);
        _unnamed1.Write(bw);
        _stage0Mode.Write(bw);
        _stage1Mode.Write(bw);
        _stage2Mode.Write(bw);
        _stage3Mode.Write(bw);
_advancedControl.Count = AdvancedControl.Count;
        _advancedControl.Write(bw);
        _target.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
_convolution.Count = Convolution.Count;
        _convolution.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _explanation.WriteBinary(writer);
        for (x = 0; (x < _advancedControl.Count); x = (x + 1)) {
          AdvancedControl[x].Write(writer);
        }
        for (x = 0; (x < _advancedControl.Count); x = (x + 1)) {
          AdvancedControl[x].WriteChildData(writer);
        }
        for (x = 0; (x < _convolution.Count); x = (x + 1)) {
          Convolution[x].Write(writer);
        }
        for (x = 0; (x < _convolution.Count); x = (x + 1)) {
          Convolution[x].WriteChildData(writer);
        }
      }
    }
    public class RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock : IBlock {
      private Flags _stage0Flags;
      private Flags _stage1Flags;
      private Flags _stage2Flags;
      private Flags _stage3Flags;
      private RealPlane3D _stage0Offset = new RealPlane3D();
      private RealPlane3D _stage1Offset = new RealPlane3D();
      private RealPlane3D _stage2Offset = new RealPlane3D();
      private RealPlane3D _stage3Offset = new RealPlane3D();
public event System.EventHandler BlockNameChanged;
      public RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBlock() {
        this._stage0Flags = new Flags(2);
        this._stage1Flags = new Flags(2);
        this._stage2Flags = new Flags(2);
        this._stage3Flags = new Flags(2);
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
      public Flags Stage0Flags {
        get {
          return this._stage0Flags;
        }
        set {
          this._stage0Flags = value;
        }
      }
      public Flags Stage1Flags {
        get {
          return this._stage1Flags;
        }
        set {
          this._stage1Flags = value;
        }
      }
      public Flags Stage2Flags {
        get {
          return this._stage2Flags;
        }
        set {
          this._stage2Flags = value;
        }
      }
      public Flags Stage3Flags {
        get {
          return this._stage3Flags;
        }
        set {
          this._stage3Flags = value;
        }
      }
      public RealPlane3D Stage0Offset {
        get {
          return this._stage0Offset;
        }
        set {
          this._stage0Offset = value;
        }
      }
      public RealPlane3D Stage1Offset {
        get {
          return this._stage1Offset;
        }
        set {
          this._stage1Offset = value;
        }
      }
      public RealPlane3D Stage2Offset {
        get {
          return this._stage2Offset;
        }
        set {
          this._stage2Offset = value;
        }
      }
      public RealPlane3D Stage3Offset {
        get {
          return this._stage3Offset;
        }
        set {
          this._stage3Offset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _stage0Flags.Read(reader);
        _stage1Flags.Read(reader);
        _stage2Flags.Read(reader);
        _stage3Flags.Read(reader);
        _stage0Offset.Read(reader);
        _stage1Offset.Read(reader);
        _stage2Offset.Read(reader);
        _stage3Offset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _stage0Flags.Write(bw);
        _stage1Flags.Write(bw);
        _stage2Flags.Write(bw);
        _stage3Flags.Write(bw);
        _stage0Offset.Write(bw);
        _stage1Offset.Write(bw);
        _stage2Offset.Write(bw);
        _stage3Offset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RasterizerScreenEffectConvolutionBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Real _convolutionAmount = new Real();
      private Real _filterScale = new Real();
      private RealFraction _filterBoxFactor = new RealFraction();
      private Real _zoomFalloffRadius = new Real();
      private Real _zoomCutoffRadius = new Real();
      private RealFraction _resolutionScale = new RealFraction();
public event System.EventHandler BlockNameChanged;
      public RasterizerScreenEffectConvolutionBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(64);
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
      public Real ConvolutionAmount {
        get {
          return this._convolutionAmount;
        }
        set {
          this._convolutionAmount = value;
        }
      }
      public Real FilterScale {
        get {
          return this._filterScale;
        }
        set {
          this._filterScale = value;
        }
      }
      public RealFraction FilterBoxFactor {
        get {
          return this._filterBoxFactor;
        }
        set {
          this._filterBoxFactor = value;
        }
      }
      public Real ZoomFalloffRadius {
        get {
          return this._zoomFalloffRadius;
        }
        set {
          this._zoomFalloffRadius = value;
        }
      }
      public Real ZoomCutoffRadius {
        get {
          return this._zoomCutoffRadius;
        }
        set {
          this._zoomCutoffRadius = value;
        }
      }
      public RealFraction ResolutionScale {
        get {
          return this._resolutionScale;
        }
        set {
          this._resolutionScale = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _convolutionAmount.Read(reader);
        _filterScale.Read(reader);
        _filterBoxFactor.Read(reader);
        _zoomFalloffRadius.Read(reader);
        _zoomCutoffRadius.Read(reader);
        _resolutionScale.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _convolutionAmount.Write(bw);
        _filterScale.Write(bw);
        _filterBoxFactor.Write(bw);
        _zoomFalloffRadius.Write(bw);
        _zoomCutoffRadius.Write(bw);
        _resolutionScale.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
