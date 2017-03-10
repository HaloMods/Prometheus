// ------------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'user_interface_globals_definition'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// ------------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class user_interface_globals_definition : Interfaces.Pool.Tag {
    private UserInterfaceGlobalsDefinitionBlockBlock userInterfaceGlobalsDefinitionValues = new UserInterfaceGlobalsDefinitionBlockBlock();
    public virtual UserInterfaceGlobalsDefinitionBlockBlock UserInterfaceGlobalsDefinitionValues {
      get {
        return userInterfaceGlobalsDefinitionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(UserInterfaceGlobalsDefinitionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "user_interface_globals_definition";
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
userInterfaceGlobalsDefinitionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
userInterfaceGlobalsDefinitionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
userInterfaceGlobalsDefinitionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
userInterfaceGlobalsDefinitionValues.WriteChildData(writer);
    }
    #endregion
    public class UserInterfaceGlobalsDefinitionBlockBlock : IBlock {
      private TagReference _sharedGlobals = new TagReference();
      private Block _screenWidgets = new Block();
      private TagReference _mpVariantSettingsUi = new TagReference();
      private TagReference _gameHopperDescriptions = new TagReference();
      public BlockCollection<UserInterfaceWidgetReferenceBlockBlock> _screenWidgetsList = new BlockCollection<UserInterfaceWidgetReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserInterfaceGlobalsDefinitionBlockBlock() {
      }
      public BlockCollection<UserInterfaceWidgetReferenceBlockBlock> ScreenWidgets {
        get {
          return this._screenWidgetsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sharedGlobals.Value);
references.Add(_mpVariantSettingsUi.Value);
references.Add(_gameHopperDescriptions.Value);
for (int x=0; x<ScreenWidgets.BlockCount; x++)
{
  IBlock block = ScreenWidgets.GetBlock(x);
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
      public TagReference SharedGlobals {
        get {
          return this._sharedGlobals;
        }
        set {
          this._sharedGlobals = value;
        }
      }
      public TagReference MpVariantSettingsUi {
        get {
          return this._mpVariantSettingsUi;
        }
        set {
          this._mpVariantSettingsUi = value;
        }
      }
      public TagReference GameHopperDescriptions {
        get {
          return this._gameHopperDescriptions;
        }
        set {
          this._gameHopperDescriptions = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sharedGlobals.Read(reader);
        _screenWidgets.Read(reader);
        _mpVariantSettingsUi.Read(reader);
        _gameHopperDescriptions.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _sharedGlobals.ReadString(reader);
        for (x = 0; (x < _screenWidgets.Count); x = (x + 1)) {
          ScreenWidgets.Add(new UserInterfaceWidgetReferenceBlockBlock());
          ScreenWidgets[x].Read(reader);
        }
        for (x = 0; (x < _screenWidgets.Count); x = (x + 1)) {
          ScreenWidgets[x].ReadChildData(reader);
        }
        _mpVariantSettingsUi.ReadString(reader);
        _gameHopperDescriptions.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sharedGlobals.Write(bw);
_screenWidgets.Count = ScreenWidgets.Count;
        _screenWidgets.Write(bw);
        _mpVariantSettingsUi.Write(bw);
        _gameHopperDescriptions.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _sharedGlobals.WriteString(writer);
        for (x = 0; (x < _screenWidgets.Count); x = (x + 1)) {
          ScreenWidgets[x].Write(writer);
        }
        for (x = 0; (x < _screenWidgets.Count); x = (x + 1)) {
          ScreenWidgets[x].WriteChildData(writer);
        }
        _mpVariantSettingsUi.WriteString(writer);
        _gameHopperDescriptions.WriteString(writer);
      }
    }
    public class UserInterfaceWidgetReferenceBlockBlock : IBlock {
      private TagReference _widgetTag = new TagReference();
public event System.EventHandler BlockNameChanged;
      public UserInterfaceWidgetReferenceBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_widgetTag.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference WidgetTag {
        get {
          return this._widgetTag;
        }
        set {
          this._widgetTag = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _widgetTag.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _widgetTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _widgetTag.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _widgetTag.WriteString(writer);
      }
    }
  }
}
