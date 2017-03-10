// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'colony'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class colony : Interfaces.Pool.Tag {
    private ColonyBlockBlock colonyValues = new ColonyBlockBlock();
    public virtual ColonyBlockBlock ColonyValues {
      get {
        return colonyValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ColonyValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "colony";
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
colonyValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
colonyValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
colonyValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
colonyValues.WriteChildData(writer);
    }
    #endregion
    public class ColonyBlockBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private Pad _unnamed1;
      private RealBounds _radius = new RealBounds();
      private Pad _unnamed2;
      private RealARGBColor _debugColor = new RealARGBColor();
      private TagReference _baseMap = new TagReference();
      private TagReference _detailMap = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ColonyBlockBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_baseMap.Value);
references.Add(_detailMap.Value);
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
      public RealBounds Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public RealARGBColor DebugColor {
        get {
          return this._debugColor;
        }
        set {
          this._debugColor = value;
        }
      }
      public TagReference BaseMap {
        get {
          return this._baseMap;
        }
        set {
          this._baseMap = value;
        }
      }
      public TagReference DetailMap {
        get {
          return this._detailMap;
        }
        set {
          this._detailMap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _radius.Read(reader);
        _unnamed2.Read(reader);
        _debugColor.Read(reader);
        _baseMap.Read(reader);
        _detailMap.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _baseMap.ReadString(reader);
        _detailMap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _radius.Write(bw);
        _unnamed2.Write(bw);
        _debugColor.Write(bw);
        _baseMap.Write(bw);
        _detailMap.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _baseMap.WriteString(writer);
        _detailMap.WriteString(writer);
      }
    }
  }
}
