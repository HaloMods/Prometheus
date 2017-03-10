// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'preferences_network_game'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class preferences_network_game : Interfaces.Pool.Tag {
    private PreferencesNetworkGameBlock preferencesNetworkGameValues = new PreferencesNetworkGameBlock();
    public virtual PreferencesNetworkGameBlock PreferencesNetworkGameValues {
      get {
        return preferencesNetworkGameValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(PreferencesNetworkGameValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "preferences_network_game";
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
preferencesNetworkGameValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
preferencesNetworkGameValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
preferencesNetworkGameValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
preferencesNetworkGameValues.WriteChildData(writer);
    }
    #endregion
    public class PreferencesNetworkGameBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealRGBColor _primaryColor = new RealRGBColor();
      private RealRGBColor _secondaryColor = new RealRGBColor();
      private TagReference _pattern = new TagReference();
      private ShortInteger _bitmapIndex = new ShortInteger();
      private Pad _unnamed;
      private TagReference _decal = new TagReference();
      private ShortInteger _bitmapIndex2 = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public PreferencesNetworkGameBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(800);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_pattern.Value);
references.Add(_decal.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
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
      public RealRGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RealRGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public TagReference Pattern {
        get {
          return this._pattern;
        }
        set {
          this._pattern = value;
        }
      }
      public ShortInteger BitmapIndex {
        get {
          return this._bitmapIndex;
        }
        set {
          this._bitmapIndex = value;
        }
      }
      public TagReference Decal {
        get {
          return this._decal;
        }
        set {
          this._decal = value;
        }
      }
      public ShortInteger BitmapIndex2 {
        get {
          return this._bitmapIndex2;
        }
        set {
          this._bitmapIndex2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _pattern.Read(reader);
        _bitmapIndex.Read(reader);
        _unnamed.Read(reader);
        _decal.Read(reader);
        _bitmapIndex2.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _pattern.ReadString(reader);
        _decal.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _pattern.Write(bw);
        _bitmapIndex.Write(bw);
        _unnamed.Write(bw);
        _decal.Write(bw);
        _bitmapIndex2.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _pattern.WriteString(writer);
        _decal.WriteString(writer);
      }
    }
  }
}
