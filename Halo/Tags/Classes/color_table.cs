// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'color_table'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class color_table : Interfaces.Pool.Tag {
    private ColorTableBlock colorTableValues = new ColorTableBlock();
    public virtual ColorTableBlock ColorTableValues {
      get {
        return colorTableValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ColorTableValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "color_table";
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
colorTableValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
colorTableValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
colorTableValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
colorTableValues.WriteChildData(writer);
    }
    #endregion
    public class ColorTableBlock : IBlock {
      private Block _colors = new Block();
      public BlockCollection<ColorBlock> _colorsList = new BlockCollection<ColorBlock>();
public event System.EventHandler BlockNameChanged;
      public ColorTableBlock() {
      }
      public BlockCollection<ColorBlock> Colors {
        get {
          return this._colorsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Colors.BlockCount; x++)
{
  IBlock block = Colors.GetBlock(x);
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
        _colors.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors.Add(new ColorBlock());
          Colors[x].Read(reader);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_colors.Count = Colors.Count;
        _colors.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].Write(writer);
        }
        for (x = 0; (x < _colors.Count); x = (x + 1)) {
          Colors[x].WriteChildData(writer);
        }
      }
    }
    public class ColorBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealARGBColor _color = new RealARGBColor();
public event System.EventHandler BlockNameChanged;
      public ColorBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
      public RealARGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
