// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'ui_widget_collection'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class ui_widget_collection : Interfaces.Pool.Tag {
    private UiWidgetCollectionBlock uiWidgetCollectionValues = new UiWidgetCollectionBlock();
    public virtual UiWidgetCollectionBlock UiWidgetCollectionValues {
      get {
        return uiWidgetCollectionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UiWidgetCollectionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "ui_widget_collection";
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
uiWidgetCollectionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
uiWidgetCollectionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
uiWidgetCollectionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
uiWidgetCollectionValues.WriteChildData(writer);
    }
    #endregion
    public class UiWidgetCollectionBlock : IBlock {
      private Block _uiWidgetDefinitions = new Block();
      public BlockCollection<UiWidgetReferencesBlock> _uiWidgetDefinitionsList = new BlockCollection<UiWidgetReferencesBlock>();
public event System.EventHandler BlockNameChanged;
      public UiWidgetCollectionBlock() {
      }
      public BlockCollection<UiWidgetReferencesBlock> UiWidgetDefinitions {
        get {
          return this._uiWidgetDefinitionsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<UiWidgetDefinitions.BlockCount; x++)
{
  IBlock block = UiWidgetDefinitions.GetBlock(x);
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
        _uiWidgetDefinitions.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _uiWidgetDefinitions.Count); x = (x + 1)) {
          UiWidgetDefinitions.Add(new UiWidgetReferencesBlock());
          UiWidgetDefinitions[x].Read(reader);
        }
        for (x = 0; (x < _uiWidgetDefinitions.Count); x = (x + 1)) {
          UiWidgetDefinitions[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_uiWidgetDefinitions.Count = UiWidgetDefinitions.Count;
        _uiWidgetDefinitions.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _uiWidgetDefinitions.Count); x = (x + 1)) {
          UiWidgetDefinitions[x].Write(writer);
        }
        for (x = 0; (x < _uiWidgetDefinitions.Count); x = (x + 1)) {
          UiWidgetDefinitions[x].WriteChildData(writer);
        }
      }
    }
    public class UiWidgetReferencesBlock : IBlock {
      private TagReference _uiwidgetdefinition = new TagReference();
public event System.EventHandler BlockNameChanged;
      public UiWidgetReferencesBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_uiwidgetdefinition.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Uiwidgetdefinition {
        get {
          return this._uiwidgetdefinition;
        }
        set {
          this._uiwidgetdefinition = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uiwidgetdefinition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _uiwidgetdefinition.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _uiwidgetdefinition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _uiwidgetdefinition.WriteString(writer);
      }
    }
  }
}
