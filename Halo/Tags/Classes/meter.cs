// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'meter'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class meter : Interfaces.Pool.Tag {
    private MeterBlock meterValues = new MeterBlock();
    public virtual MeterBlock MeterValues {
      get {
        return meterValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MeterValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "meter";
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
meterValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
meterValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
meterValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
meterValues.WriteChildData(writer);
    }
    #endregion
    public class MeterBlock : IBlock {
      private Flags _flags;
      private TagReference _stencilBitmaps = new TagReference();
      private TagReference _sourceBitmap = new TagReference();
      private ShortInteger _stencilSequenceIndex = new ShortInteger();
      private ShortInteger _sourceSequenceIndex = new ShortInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Enum _interpolateColors_Pt_Pt_Pt = new Enum();
      private Enum _anchorColors_Pt_Pt_Pt = new Enum();
      private Pad _unnamed3;
      private RealARGBColor _emptyColor = new RealARGBColor();
      private RealARGBColor _fullColor = new RealARGBColor();
      private Pad _unnamed4;
      private Real _unmaskDistance = new Real();
      private Real _maskDistance = new Real();
      private Pad _unnamed5;
      private Data _encodedStencil = new Data();
public event System.EventHandler BlockNameChanged;
      public MeterBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(16);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(20);
        this._unnamed5 = new Pad(20);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_stencilBitmaps.Value);
references.Add(_sourceBitmap.Value);
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
      public TagReference StencilBitmaps {
        get {
          return this._stencilBitmaps;
        }
        set {
          this._stencilBitmaps = value;
        }
      }
      public TagReference SourceBitmap {
        get {
          return this._sourceBitmap;
        }
        set {
          this._sourceBitmap = value;
        }
      }
      public ShortInteger StencilSequenceIndex {
        get {
          return this._stencilSequenceIndex;
        }
        set {
          this._stencilSequenceIndex = value;
        }
      }
      public ShortInteger SourceSequenceIndex {
        get {
          return this._sourceSequenceIndex;
        }
        set {
          this._sourceSequenceIndex = value;
        }
      }
      public Enum InterpolateColors_Pt_Pt_Pt {
        get {
          return this._interpolateColors_Pt_Pt_Pt;
        }
        set {
          this._interpolateColors_Pt_Pt_Pt = value;
        }
      }
      public Enum AnchorColors_Pt_Pt_Pt {
        get {
          return this._anchorColors_Pt_Pt_Pt;
        }
        set {
          this._anchorColors_Pt_Pt_Pt = value;
        }
      }
      public RealARGBColor EmptyColor {
        get {
          return this._emptyColor;
        }
        set {
          this._emptyColor = value;
        }
      }
      public RealARGBColor FullColor {
        get {
          return this._fullColor;
        }
        set {
          this._fullColor = value;
        }
      }
      public Real UnmaskDistance {
        get {
          return this._unmaskDistance;
        }
        set {
          this._unmaskDistance = value;
        }
      }
      public Real MaskDistance {
        get {
          return this._maskDistance;
        }
        set {
          this._maskDistance = value;
        }
      }
      public Data EncodedStencil {
        get {
          return this._encodedStencil;
        }
        set {
          this._encodedStencil = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _stencilBitmaps.Read(reader);
        _sourceBitmap.Read(reader);
        _stencilSequenceIndex.Read(reader);
        _sourceSequenceIndex.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _interpolateColors_Pt_Pt_Pt.Read(reader);
        _anchorColors_Pt_Pt_Pt.Read(reader);
        _unnamed3.Read(reader);
        _emptyColor.Read(reader);
        _fullColor.Read(reader);
        _unnamed4.Read(reader);
        _unmaskDistance.Read(reader);
        _maskDistance.Read(reader);
        _unnamed5.Read(reader);
        _encodedStencil.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _stencilBitmaps.ReadString(reader);
        _sourceBitmap.ReadString(reader);
        _encodedStencil.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _stencilBitmaps.Write(bw);
        _sourceBitmap.Write(bw);
        _stencilSequenceIndex.Write(bw);
        _sourceSequenceIndex.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _interpolateColors_Pt_Pt_Pt.Write(bw);
        _anchorColors_Pt_Pt_Pt.Write(bw);
        _unnamed3.Write(bw);
        _emptyColor.Write(bw);
        _fullColor.Write(bw);
        _unnamed4.Write(bw);
        _unmaskDistance.Write(bw);
        _maskDistance.Write(bw);
        _unnamed5.Write(bw);
        _encodedStencil.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _stencilBitmaps.WriteString(writer);
        _sourceBitmap.WriteString(writer);
        _encodedStencil.WriteBinary(writer);
      }
    }
  }
}
