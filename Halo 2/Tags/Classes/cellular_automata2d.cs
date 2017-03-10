// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'cellular_automata2d'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class cellular_automata2d : Interfaces.Pool.Tag {
    private CellularAutomata2dBlockBlock cellularAutomata2dValues = new CellularAutomata2dBlockBlock();
    public virtual CellularAutomata2dBlockBlock CellularAutomata2dValues {
      get {
        return cellularAutomata2dValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(CellularAutomata2dValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "cellular_automata2d";
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
cellularAutomata2dValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
cellularAutomata2dValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
cellularAutomata2dValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
cellularAutomata2dValues.WriteChildData(writer);
    }
    #endregion
    public class CellularAutomata2dBlockBlock : IBlock {
      private ShortInteger _updatesPerSecond = new ShortInteger();
      private Pad _unnamed0;
      private Real _deadCellPenalty = new Real();
      private Real _liveCellBonus = new Real();
      private Pad _unnamed1;
      private ShortInteger _width = new ShortInteger();
      private ShortInteger _height = new ShortInteger();
      private Real _cellWidth = new Real();
      private Real _height2 = new Real();
      private RealVector2D _velocity = new RealVector2D();
      private Pad _unnamed2;
      private StringId _marker = new StringId();
      private Flags _interpolationFlags;
      private RealRGBColor _baseColor = new RealRGBColor();
      private RealRGBColor _peakColor = new RealRGBColor();
      private Pad _unnamed3;
      private ShortInteger _width2 = new ShortInteger();
      private ShortInteger _height3 = new ShortInteger();
      private Real _cellWidth2 = new Real();
      private RealVector2D _velocity2 = new RealVector2D();
      private Pad _unnamed4;
      private StringId _marker2 = new StringId();
      private ShortInteger _textureWidth = new ShortInteger();
      private Pad _unnamed5;
      private Pad _unnamed6;
      private TagReference _texture = new TagReference();
      private Pad _unnamed7;
      private Block _rules = new Block();
      public BlockCollection<RulesBlockBlock> _rulesList = new BlockCollection<RulesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CellularAutomata2dBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(80);
        this._unnamed2 = new Pad(28);
        this._interpolationFlags = new Flags(4);
        this._unnamed3 = new Pad(76);
        this._unnamed4 = new Pad(48);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(48);
        this._unnamed7 = new Pad(160);
      }
      public BlockCollection<RulesBlockBlock> Rules {
        get {
          return this._rulesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_texture.Value);
for (int x=0; x<Rules.BlockCount; x++)
{
  IBlock block = Rules.GetBlock(x);
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
      public ShortInteger UpdatesPerSecond {
        get {
          return this._updatesPerSecond;
        }
        set {
          this._updatesPerSecond = value;
        }
      }
      public Real DeadCellPenalty {
        get {
          return this._deadCellPenalty;
        }
        set {
          this._deadCellPenalty = value;
        }
      }
      public Real LiveCellBonus {
        get {
          return this._liveCellBonus;
        }
        set {
          this._liveCellBonus = value;
        }
      }
      public ShortInteger Width {
        get {
          return this._width;
        }
        set {
          this._width = value;
        }
      }
      public ShortInteger Height {
        get {
          return this._height;
        }
        set {
          this._height = value;
        }
      }
      public Real CellWidth {
        get {
          return this._cellWidth;
        }
        set {
          this._cellWidth = value;
        }
      }
      public Real Height2 {
        get {
          return this._height2;
        }
        set {
          this._height2 = value;
        }
      }
      public RealVector2D Velocity {
        get {
          return this._velocity;
        }
        set {
          this._velocity = value;
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
      public Flags InterpolationFlags {
        get {
          return this._interpolationFlags;
        }
        set {
          this._interpolationFlags = value;
        }
      }
      public RealRGBColor BaseColor {
        get {
          return this._baseColor;
        }
        set {
          this._baseColor = value;
        }
      }
      public RealRGBColor PeakColor {
        get {
          return this._peakColor;
        }
        set {
          this._peakColor = value;
        }
      }
      public ShortInteger Width2 {
        get {
          return this._width2;
        }
        set {
          this._width2 = value;
        }
      }
      public ShortInteger Height3 {
        get {
          return this._height3;
        }
        set {
          this._height3 = value;
        }
      }
      public Real CellWidth2 {
        get {
          return this._cellWidth2;
        }
        set {
          this._cellWidth2 = value;
        }
      }
      public RealVector2D Velocity2 {
        get {
          return this._velocity2;
        }
        set {
          this._velocity2 = value;
        }
      }
      public StringId Marker2 {
        get {
          return this._marker2;
        }
        set {
          this._marker2 = value;
        }
      }
      public ShortInteger TextureWidth {
        get {
          return this._textureWidth;
        }
        set {
          this._textureWidth = value;
        }
      }
      public TagReference Texture {
        get {
          return this._texture;
        }
        set {
          this._texture = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _updatesPerSecond.Read(reader);
        _unnamed0.Read(reader);
        _deadCellPenalty.Read(reader);
        _liveCellBonus.Read(reader);
        _unnamed1.Read(reader);
        _width.Read(reader);
        _height.Read(reader);
        _cellWidth.Read(reader);
        _height2.Read(reader);
        _velocity.Read(reader);
        _unnamed2.Read(reader);
        _marker.Read(reader);
        _interpolationFlags.Read(reader);
        _baseColor.Read(reader);
        _peakColor.Read(reader);
        _unnamed3.Read(reader);
        _width2.Read(reader);
        _height3.Read(reader);
        _cellWidth2.Read(reader);
        _velocity2.Read(reader);
        _unnamed4.Read(reader);
        _marker2.Read(reader);
        _textureWidth.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _texture.Read(reader);
        _unnamed7.Read(reader);
        _rules.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _marker.ReadString(reader);
        _marker2.ReadString(reader);
        _texture.ReadString(reader);
        for (x = 0; (x < _rules.Count); x = (x + 1)) {
          Rules.Add(new RulesBlockBlock());
          Rules[x].Read(reader);
        }
        for (x = 0; (x < _rules.Count); x = (x + 1)) {
          Rules[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _updatesPerSecond.Write(bw);
        _unnamed0.Write(bw);
        _deadCellPenalty.Write(bw);
        _liveCellBonus.Write(bw);
        _unnamed1.Write(bw);
        _width.Write(bw);
        _height.Write(bw);
        _cellWidth.Write(bw);
        _height2.Write(bw);
        _velocity.Write(bw);
        _unnamed2.Write(bw);
        _marker.Write(bw);
        _interpolationFlags.Write(bw);
        _baseColor.Write(bw);
        _peakColor.Write(bw);
        _unnamed3.Write(bw);
        _width2.Write(bw);
        _height3.Write(bw);
        _cellWidth2.Write(bw);
        _velocity2.Write(bw);
        _unnamed4.Write(bw);
        _marker2.Write(bw);
        _textureWidth.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _texture.Write(bw);
        _unnamed7.Write(bw);
_rules.Count = Rules.Count;
        _rules.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _marker.WriteString(writer);
        _marker2.WriteString(writer);
        _texture.WriteString(writer);
        for (x = 0; (x < _rules.Count); x = (x + 1)) {
          Rules[x].Write(writer);
        }
        for (x = 0; (x < _rules.Count); x = (x + 1)) {
          Rules[x].WriteChildData(writer);
        }
      }
    }
    public class RulesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealRGBColor _tintColor = new RealRGBColor();
      private Pad _unnamed0;
      private Block _states = new Block();
      public BlockCollection<StatesBlockBlock> _statesList = new BlockCollection<StatesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public RulesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
      }
      public BlockCollection<StatesBlockBlock> States {
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
      public RealRGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _tintColor.Read(reader);
        _unnamed0.Read(reader);
        _states.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States.Add(new StatesBlockBlock());
          States[x].Read(reader);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _tintColor.Write(bw);
        _unnamed0.Write(bw);
_states.Count = States.Count;
        _states.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].Write(writer);
        }
        for (x = 0; (x < _states.Count); x = (x + 1)) {
          States[x].WriteChildData(writer);
        }
      }
    }
    public class StatesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealRGBColor _color = new RealRGBColor();
      private ShortInteger _countsAs = new ShortInteger();
      private Pad _unnamed0;
      private Real _initialPlacementWeight = new Real();
      private Pad _unnamed1;
      private ShortBlockIndex _zero = new ShortBlockIndex();
      private ShortBlockIndex _one = new ShortBlockIndex();
      private ShortBlockIndex _two = new ShortBlockIndex();
      private ShortBlockIndex _three = new ShortBlockIndex();
      private ShortBlockIndex _four = new ShortBlockIndex();
      private ShortBlockIndex _five = new ShortBlockIndex();
      private ShortBlockIndex _six = new ShortBlockIndex();
      private ShortBlockIndex _seven = new ShortBlockIndex();
      private ShortBlockIndex _eight = new ShortBlockIndex();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public StatesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(24);
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
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public ShortInteger CountsAs {
        get {
          return this._countsAs;
        }
        set {
          this._countsAs = value;
        }
      }
      public Real InitialPlacementWeight {
        get {
          return this._initialPlacementWeight;
        }
        set {
          this._initialPlacementWeight = value;
        }
      }
      public ShortBlockIndex Zero {
        get {
          return this._zero;
        }
        set {
          this._zero = value;
        }
      }
      public ShortBlockIndex One {
        get {
          return this._one;
        }
        set {
          this._one = value;
        }
      }
      public ShortBlockIndex Two {
        get {
          return this._two;
        }
        set {
          this._two = value;
        }
      }
      public ShortBlockIndex Three {
        get {
          return this._three;
        }
        set {
          this._three = value;
        }
      }
      public ShortBlockIndex Four {
        get {
          return this._four;
        }
        set {
          this._four = value;
        }
      }
      public ShortBlockIndex Five {
        get {
          return this._five;
        }
        set {
          this._five = value;
        }
      }
      public ShortBlockIndex Six {
        get {
          return this._six;
        }
        set {
          this._six = value;
        }
      }
      public ShortBlockIndex Seven {
        get {
          return this._seven;
        }
        set {
          this._seven = value;
        }
      }
      public ShortBlockIndex Eight {
        get {
          return this._eight;
        }
        set {
          this._eight = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _color.Read(reader);
        _countsAs.Read(reader);
        _unnamed0.Read(reader);
        _initialPlacementWeight.Read(reader);
        _unnamed1.Read(reader);
        _zero.Read(reader);
        _one.Read(reader);
        _two.Read(reader);
        _three.Read(reader);
        _four.Read(reader);
        _five.Read(reader);
        _six.Read(reader);
        _seven.Read(reader);
        _eight.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _color.Write(bw);
        _countsAs.Write(bw);
        _unnamed0.Write(bw);
        _initialPlacementWeight.Write(bw);
        _unnamed1.Write(bw);
        _zero.Write(bw);
        _one.Write(bw);
        _two.Write(bw);
        _three.Write(bw);
        _four.Write(bw);
        _five.Write(bw);
        _six.Write(bw);
        _seven.Write(bw);
        _eight.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
