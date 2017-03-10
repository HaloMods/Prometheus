// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'cellular_automata'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class cellular_automata : Interfaces.Pool.Tag {
    private CellularAutomataBlockBlock cellularAutomataValues = new CellularAutomataBlockBlock();
    public virtual CellularAutomataBlockBlock CellularAutomataValues {
      get {
        return cellularAutomataValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(CellularAutomataValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "cellular_automata";
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
cellularAutomataValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
cellularAutomataValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
cellularAutomataValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
cellularAutomataValues.WriteChildData(writer);
    }
    #endregion
    public class CellularAutomataBlockBlock : IBlock {
      private ShortInteger _updatesPerSecond = new ShortInteger();
      private ShortInteger _xWidth = new ShortInteger();
      private ShortInteger _yDepth = new ShortInteger();
      private ShortInteger _zHeight = new ShortInteger();
      private Real _xWidth2 = new Real();
      private Real _yDepth2 = new Real();
      private Real _zHeight2 = new Real();
      private Pad _unnamed0;
      private StringId _marker = new StringId();
      private RealFraction _cellBirthChance = new RealFraction();
      private Pad _unnamed1;
      private LongInteger _cellGeneMutates1In = new LongInteger();
      private LongInteger _virusGeneMutations1In = new LongInteger();
      private Pad _unnamed2;
      private ShortIntegerBounds _infectedCellLifespan = new ShortIntegerBounds();
      private ShortInteger _minimumInfectionAge = new ShortInteger();
      private Pad _unnamed3;
      private RealFraction _cellInfectionChance = new RealFraction();
      private RealFraction _infectionThreshold = new RealFraction();
      private Pad _unnamed4;
      private RealFraction _newCellFilledChance = new RealFraction();
      private RealFraction _newCellInfectedChance = new RealFraction();
      private Pad _unnamed5;
      private RealFraction _detailTextureChangeChance = new RealFraction();
      private Pad _unnamed6;
      private ShortInteger _detailTextureWidth = new ShortInteger();
      private Pad _unnamed7;
      private TagReference _detailTexture = new TagReference();
      private Pad _unnamed8;
      private TagReference _maskBitmap = new TagReference();
      private Pad _unnamed9;
public event System.EventHandler BlockNameChanged;
      public CellularAutomataBlockBlock() {
        this._unnamed0 = new Pad(32);
        this._unnamed1 = new Pad(32);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(32);
        this._unnamed5 = new Pad(32);
        this._unnamed6 = new Pad(32);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(32);
        this._unnamed9 = new Pad(240);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_detailTexture.Value);
references.Add(_maskBitmap.Value);
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
      public ShortInteger XWidth {
        get {
          return this._xWidth;
        }
        set {
          this._xWidth = value;
        }
      }
      public ShortInteger YDepth {
        get {
          return this._yDepth;
        }
        set {
          this._yDepth = value;
        }
      }
      public ShortInteger ZHeight {
        get {
          return this._zHeight;
        }
        set {
          this._zHeight = value;
        }
      }
      public Real XWidth2 {
        get {
          return this._xWidth2;
        }
        set {
          this._xWidth2 = value;
        }
      }
      public Real YDepth2 {
        get {
          return this._yDepth2;
        }
        set {
          this._yDepth2 = value;
        }
      }
      public Real ZHeight2 {
        get {
          return this._zHeight2;
        }
        set {
          this._zHeight2 = value;
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
      public RealFraction CellBirthChance {
        get {
          return this._cellBirthChance;
        }
        set {
          this._cellBirthChance = value;
        }
      }
      public LongInteger CellGeneMutates1In {
        get {
          return this._cellGeneMutates1In;
        }
        set {
          this._cellGeneMutates1In = value;
        }
      }
      public LongInteger VirusGeneMutations1In {
        get {
          return this._virusGeneMutations1In;
        }
        set {
          this._virusGeneMutations1In = value;
        }
      }
      public ShortIntegerBounds InfectedCellLifespan {
        get {
          return this._infectedCellLifespan;
        }
        set {
          this._infectedCellLifespan = value;
        }
      }
      public ShortInteger MinimumInfectionAge {
        get {
          return this._minimumInfectionAge;
        }
        set {
          this._minimumInfectionAge = value;
        }
      }
      public RealFraction CellInfectionChance {
        get {
          return this._cellInfectionChance;
        }
        set {
          this._cellInfectionChance = value;
        }
      }
      public RealFraction InfectionThreshold {
        get {
          return this._infectionThreshold;
        }
        set {
          this._infectionThreshold = value;
        }
      }
      public RealFraction NewCellFilledChance {
        get {
          return this._newCellFilledChance;
        }
        set {
          this._newCellFilledChance = value;
        }
      }
      public RealFraction NewCellInfectedChance {
        get {
          return this._newCellInfectedChance;
        }
        set {
          this._newCellInfectedChance = value;
        }
      }
      public RealFraction DetailTextureChangeChance {
        get {
          return this._detailTextureChangeChance;
        }
        set {
          this._detailTextureChangeChance = value;
        }
      }
      public ShortInteger DetailTextureWidth {
        get {
          return this._detailTextureWidth;
        }
        set {
          this._detailTextureWidth = value;
        }
      }
      public TagReference DetailTexture {
        get {
          return this._detailTexture;
        }
        set {
          this._detailTexture = value;
        }
      }
      public TagReference MaskBitmap {
        get {
          return this._maskBitmap;
        }
        set {
          this._maskBitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _updatesPerSecond.Read(reader);
        _xWidth.Read(reader);
        _yDepth.Read(reader);
        _zHeight.Read(reader);
        _xWidth2.Read(reader);
        _yDepth2.Read(reader);
        _zHeight2.Read(reader);
        _unnamed0.Read(reader);
        _marker.Read(reader);
        _cellBirthChance.Read(reader);
        _unnamed1.Read(reader);
        _cellGeneMutates1In.Read(reader);
        _virusGeneMutations1In.Read(reader);
        _unnamed2.Read(reader);
        _infectedCellLifespan.Read(reader);
        _minimumInfectionAge.Read(reader);
        _unnamed3.Read(reader);
        _cellInfectionChance.Read(reader);
        _infectionThreshold.Read(reader);
        _unnamed4.Read(reader);
        _newCellFilledChance.Read(reader);
        _newCellInfectedChance.Read(reader);
        _unnamed5.Read(reader);
        _detailTextureChangeChance.Read(reader);
        _unnamed6.Read(reader);
        _detailTextureWidth.Read(reader);
        _unnamed7.Read(reader);
        _detailTexture.Read(reader);
        _unnamed8.Read(reader);
        _maskBitmap.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _marker.ReadString(reader);
        _detailTexture.ReadString(reader);
        _maskBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _updatesPerSecond.Write(bw);
        _xWidth.Write(bw);
        _yDepth.Write(bw);
        _zHeight.Write(bw);
        _xWidth2.Write(bw);
        _yDepth2.Write(bw);
        _zHeight2.Write(bw);
        _unnamed0.Write(bw);
        _marker.Write(bw);
        _cellBirthChance.Write(bw);
        _unnamed1.Write(bw);
        _cellGeneMutates1In.Write(bw);
        _virusGeneMutations1In.Write(bw);
        _unnamed2.Write(bw);
        _infectedCellLifespan.Write(bw);
        _minimumInfectionAge.Write(bw);
        _unnamed3.Write(bw);
        _cellInfectionChance.Write(bw);
        _infectionThreshold.Write(bw);
        _unnamed4.Write(bw);
        _newCellFilledChance.Write(bw);
        _newCellInfectedChance.Write(bw);
        _unnamed5.Write(bw);
        _detailTextureChangeChance.Write(bw);
        _unnamed6.Write(bw);
        _detailTextureWidth.Write(bw);
        _unnamed7.Write(bw);
        _detailTexture.Write(bw);
        _unnamed8.Write(bw);
        _maskBitmap.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _marker.WriteString(writer);
        _detailTexture.WriteString(writer);
        _maskBitmap.WriteString(writer);
      }
    }
  }
}
