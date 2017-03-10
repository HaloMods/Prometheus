// -----------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'multiplayer_scenario_description'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -----------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class multiplayer_scenario_description : Interfaces.Pool.Tag {
    private MultiplayerScenarioDescriptionBlockBlock multiplayerScenarioDescriptionValues = new MultiplayerScenarioDescriptionBlockBlock();
    public virtual MultiplayerScenarioDescriptionBlockBlock MultiplayerScenarioDescriptionValues {
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
    public class MultiplayerScenarioDescriptionBlockBlock : IBlock {
      private Block _multiplayerScenarios = new Block();
      public BlockCollection<ScenarioDescriptionBlockBlock> _multiplayerScenariosList = new BlockCollection<ScenarioDescriptionBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public MultiplayerScenarioDescriptionBlockBlock() {
      }
      public BlockCollection<ScenarioDescriptionBlockBlock> MultiplayerScenarios {
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
          MultiplayerScenarios.Add(new ScenarioDescriptionBlockBlock());
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
    public class ScenarioDescriptionBlockBlock : IBlock {
      private TagReference _descriptiveBitmap = new TagReference();
      private TagReference _displayedMapName = new TagReference();
      private FixedLengthString _scenarioTagDirectoryPath = new FixedLengthString();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioDescriptionBlockBlock() {
        this._unnamed0 = new Pad(4);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _descriptiveBitmap.ReadString(reader);
        _displayedMapName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _descriptiveBitmap.Write(bw);
        _displayedMapName.Write(bw);
        _scenarioTagDirectoryPath.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _descriptiveBitmap.WriteString(writer);
        _displayedMapName.WriteString(writer);
      }
    }
  }
}
