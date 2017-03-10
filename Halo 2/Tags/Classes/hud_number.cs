// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'hud_number'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class hud_number : Interfaces.Pool.Tag {
    private HudNumberBlockBlock hudNumberValues = new HudNumberBlockBlock();
    public virtual HudNumberBlockBlock HudNumberValues {
      get {
        return hudNumberValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(HudNumberValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "hud_number";
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
hudNumberValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
hudNumberValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
hudNumberValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
hudNumberValues.WriteChildData(writer);
    }
    #endregion
    public class HudNumberBlockBlock : IBlock {
      private TagReference _digitsBitmap = new TagReference();
      private CharInteger _bitmapDigitWidth = new CharInteger();
      private CharInteger _screenDigitWidth = new CharInteger();
      private CharInteger _xOffset = new CharInteger();
      private CharInteger _yOffset = new CharInteger();
      private CharInteger _decimalPointWidth = new CharInteger();
      private CharInteger _colonWidth = new CharInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public HudNumberBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(76);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_digitsBitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference DigitsBitmap {
        get {
          return this._digitsBitmap;
        }
        set {
          this._digitsBitmap = value;
        }
      }
      public CharInteger BitmapDigitWidth {
        get {
          return this._bitmapDigitWidth;
        }
        set {
          this._bitmapDigitWidth = value;
        }
      }
      public CharInteger ScreenDigitWidth {
        get {
          return this._screenDigitWidth;
        }
        set {
          this._screenDigitWidth = value;
        }
      }
      public CharInteger XOffset {
        get {
          return this._xOffset;
        }
        set {
          this._xOffset = value;
        }
      }
      public CharInteger YOffset {
        get {
          return this._yOffset;
        }
        set {
          this._yOffset = value;
        }
      }
      public CharInteger DecimalPointWidth {
        get {
          return this._decimalPointWidth;
        }
        set {
          this._decimalPointWidth = value;
        }
      }
      public CharInteger ColonWidth {
        get {
          return this._colonWidth;
        }
        set {
          this._colonWidth = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _digitsBitmap.Read(reader);
        _bitmapDigitWidth.Read(reader);
        _screenDigitWidth.Read(reader);
        _xOffset.Read(reader);
        _yOffset.Read(reader);
        _decimalPointWidth.Read(reader);
        _colonWidth.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _digitsBitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _digitsBitmap.Write(bw);
        _bitmapDigitWidth.Write(bw);
        _screenDigitWidth.Write(bw);
        _xOffset.Write(bw);
        _yOffset.Write(bw);
        _decimalPointWidth.Write(bw);
        _colonWidth.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _digitsBitmap.WriteString(writer);
      }
    }
  }
}
