// -----------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'multiplayer_scenario_description'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// -----------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  
  public partial class multiplayer_scenario_description : Interfaces.Pool.Tag {
    private MultiplayerScenarioDescriptionBlock multiplayerScenarioDescriptionValues = new MultiplayerScenarioDescriptionBlock();
    public virtual MultiplayerScenarioDescriptionBlock MultiplayerScenarioDescriptionValues {
      get {
        return multiplayerScenarioDescriptionValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(MultiplayerScenarioDescriptionValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "multiplayer_scenario_description";
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
multiplayerScenarioDescriptionValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
multiplayerScenarioDescriptionValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
multiplayerScenarioDescriptionValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
multiplayerScenarioDescriptionValues.WriteChildData(writer);
    }
    #endregion
    public class MultiplayerScenarioDescriptionBlock : IBlock {
      private Block _multiplayerScenarios = new Block();
      public BlockCollection<ScenarioDescriptionBlock> _multiplayerScenariosList = new BlockCollection<ScenarioDescriptionBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerScenarioDescriptionBlock() {
      }
      public BlockCollection<ScenarioDescriptionBlock> MultiplayerScenarios {
        get {
          return this._multiplayerScenariosList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<MultiplayerScenarios.BlockCount; x++)
{
  IBlock block = MultiplayerScenarios.GetBlock(x);
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
        _multiplayerScenarios.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _multiplayerScenarios.Count); x = (x + 1)) {
          MultiplayerScenarios.Add(new ScenarioDescriptionBlock());
          MultiplayerScenarios[x].Read(reader);
        }
        for (x = 0; (x < _multiplayerScenarios.Count); x = (x + 1)) {
          MultiplayerScenarios[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_multiplayerScenarios.Count = MultiplayerScenarios.Count;
        _multiplayerScenarios.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _multiplayerScenarios.Count); x = (x + 1)) {
          MultiplayerScenarios[x].Write(writer);
        }
        for (x = 0; (x < _multiplayerScenarios.Count); x = (x + 1)) {
          MultiplayerScenarios[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioDescriptionBlock : IBlock {
      private TagReference _descriptiveBitmap = new TagReference();
      private TagReference _displayedMapName = new TagReference();
      private FixedLengthString _scenarioTagDirectoryPath = new FixedLengthString();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioDescriptionBlock() {
        this._unnamed = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_descriptiveBitmap.Value);
references.Add(_displayedMapName.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference DescriptiveBitmap {
        get {
          return this._descriptiveBitmap;
        }
        set {
          this._descriptiveBitmap = value;
        }
      }
      public TagReference DisplayedMapName {
        get {
          return this._displayedMapName;
        }
        set {
          this._displayedMapName = value;
        }
      }
      public FixedLengthString ScenarioTagDirectoryPath {
        get {
          return this._scenarioTagDirectoryPath;
        }
        set {
          this._scenarioTagDirectoryPath = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _descriptiveBitmap.Read(reader);
        _displayedMapName.Read(reader);
        _scenarioTagDirectoryPath.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _descriptiveBitmap.ReadString(reader);
        _displayedMapName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _descriptiveBitmap.Write(bw);
        _displayedMapName.Write(bw);
        _scenarioTagDirectoryPath.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _descriptiveBitmap.WriteString(writer);
        _displayedMapName.WriteString(writer);
      }
    }
  }
}
