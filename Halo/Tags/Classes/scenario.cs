// ------------------------------------------------
// Prometheus Tag Library - Halo
// Tag definition for 'scenario'
// Generated on 6/21/2007 at 11:03 PM by YUMMY\Your
// ------------------------------------------------
namespace Games.Halo.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo.Tags.Fields;
  using Interfaces.Games;
  
  public partial class scenario : ScenarioBase {
    private ScenarioBlock scenarioValues = new ScenarioBlock();
    public virtual ScenarioBlock ScenarioValues {
      get {
        return scenarioValues;
      }
    }
    public override string[] TagReferenceList {
      get {
UniqueStringCollection references = new UniqueStringCollection();
references.AddRange(ScenarioValues.TagReferenceList);
return references.ToArray();
      }
    }
    public override string FileExtension {
      get {
return "scenario";
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
scenarioValues.Read(reader);
    }
    public override void ReadChildData(BinaryReader reader) {
scenarioValues.ReadChildData(reader);
    }
    public override byte[] Save() {
BinaryWriter writer = new BinaryWriter(new MemoryStream());
Write(writer);
WriteChildData(writer);
return (writer.BaseStream as MemoryStream).ToArray();
    }
    public override void Write(BinaryWriter writer) {
scenarioValues.Write(writer);
    }
    public override void WriteChildData(BinaryWriter writer) {
scenarioValues.WriteChildData(writer);
    }
    #endregion
    public class ScenarioBlock : IBlock {
      private TagReference _dONTUSE = new TagReference();
      private TagReference _wONTUSE = new TagReference();
      private TagReference _cANTUSE = new TagReference();
      private Block _skies = new Block();
      private Enum _type = new Enum();
      private Flags _flags;
      private Block _childScenarios = new Block();
      private Angle _localNorth = new Angle();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Block _predictedResources = new Block();
      private Block _functions = new Block();
      private Data _editorScenarioData = new Data();
      private Block _comments = new Block();
      private Pad _unnamed3;
      private Block _objectNames = new Block();
      private Block _scenery = new Block();
      private Block _sceneryPalette = new Block();
      private Block _bipeds = new Block();
      private Block _bipedPalette = new Block();
      private Block _vehicles = new Block();
      private Block _vehiclePalette = new Block();
      private Block _equipment = new Block();
      private Block _equipmentPalette = new Block();
      private Block _weapons = new Block();
      private Block _weaponPalette = new Block();
      private Block _deviceGroups = new Block();
      private Block _machines = new Block();
      private Block _machinePalette = new Block();
      private Block _controls = new Block();
      private Block _controlPalette = new Block();
      private Block _lightFixtures = new Block();
      private Block _lightFixturesPalette = new Block();
      private Block _soundScenery = new Block();
      private Block _soundSceneryPalette = new Block();
      private Pad _unnamed4;
      private Block _playerStartingProfile = new Block();
      private Block _playerStartingLocations = new Block();
      private Block _triggerVolumes = new Block();
      private Block _recordedAnimations = new Block();
      private Block _netgameFlags = new Block();
      private Block _netgameEquipment = new Block();
      private Block _startingEquipment = new Block();
      private Block _bspSwitchTriggerVolumes = new Block();
      private Block _decals = new Block();
      private Block _decalPalette = new Block();
      private Block _detailObjectCollectionPalette = new Block();
      private Pad _unnamed5;
      private Block _actorPalette = new Block();
      private Block _encounters = new Block();
      private Block _commandLists = new Block();
      private Block _aiAnimationReferences = new Block();
      private Block _aiScriptReferences = new Block();
      private Block _aiRecordingReferences = new Block();
      private Block _aiConversations = new Block();
      private Data _scriptSyntaxData = new Data();
      private Data _scriptStringData = new Data();
      private Block _scripts = new Block();
      private Block _globals = new Block();
      private Block _references = new Block();
      private Block _sourceFiles = new Block();
      private Pad _unnamed6;
      private Block _cutsceneFlags = new Block();
      private Block _cutsceneCameraPoints = new Block();
      private Block _cutsceneTitles = new Block();
      private Pad _unnamed7;
      private TagReference _customObjectNames = new TagReference();
      private TagReference _ingameHelpText = new TagReference();
      private TagReference _hudMessages = new TagReference();
      private Block _structureBsps = new Block();
      public BlockCollection<ScenarioSkyReferenceBlock> _skiesList = new BlockCollection<ScenarioSkyReferenceBlock>();
      public BlockCollection<ScenarioChildScenarioBlock> _childScenariosList = new BlockCollection<ScenarioChildScenarioBlock>();
      public BlockCollection<PredictedResourceBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlock>();
      public BlockCollection<ScenarioFunctionBlock> _functionsList = new BlockCollection<ScenarioFunctionBlock>();
      public BlockCollection<EditorCommentBlock> _commentsList = new BlockCollection<EditorCommentBlock>();
      public BlockCollection<ScenarioObjectNamesBlock> _objectNamesList = new BlockCollection<ScenarioObjectNamesBlock>();
      public BlockCollection<ScenarioSceneryBlock> _sceneryList = new BlockCollection<ScenarioSceneryBlock>();
      public BlockCollection<ScenarioSceneryPaletteBlock> _sceneryPaletteList = new BlockCollection<ScenarioSceneryPaletteBlock>();
      public BlockCollection<ScenarioBipedBlock> _bipedsList = new BlockCollection<ScenarioBipedBlock>();
      public BlockCollection<ScenarioBipedPaletteBlock> _bipedPaletteList = new BlockCollection<ScenarioBipedPaletteBlock>();
      public BlockCollection<ScenarioVehicleBlock> _vehiclesList = new BlockCollection<ScenarioVehicleBlock>();
      public BlockCollection<ScenarioVehiclePaletteBlock> _vehiclePaletteList = new BlockCollection<ScenarioVehiclePaletteBlock>();
      public BlockCollection<ScenarioEquipmentBlock> _equipmentList = new BlockCollection<ScenarioEquipmentBlock>();
      public BlockCollection<ScenarioEquipmentPaletteBlock> _equipmentPaletteList = new BlockCollection<ScenarioEquipmentPaletteBlock>();
      public BlockCollection<ScenarioWeaponBlock> _weaponsList = new BlockCollection<ScenarioWeaponBlock>();
      public BlockCollection<ScenarioWeaponPaletteBlock> _weaponPaletteList = new BlockCollection<ScenarioWeaponPaletteBlock>();
      public BlockCollection<DeviceGroupBlock> _deviceGroupsList = new BlockCollection<DeviceGroupBlock>();
      public BlockCollection<ScenarioMachineBlock> _machinesList = new BlockCollection<ScenarioMachineBlock>();
      public BlockCollection<ScenarioMachinePaletteBlock> _machinePaletteList = new BlockCollection<ScenarioMachinePaletteBlock>();
      public BlockCollection<ScenarioControlBlock> _controlsList = new BlockCollection<ScenarioControlBlock>();
      public BlockCollection<ScenarioControlPaletteBlock> _controlPaletteList = new BlockCollection<ScenarioControlPaletteBlock>();
      public BlockCollection<ScenarioLightFixtureBlock> _lightFixturesList = new BlockCollection<ScenarioLightFixtureBlock>();
      public BlockCollection<ScenarioLightFixturePaletteBlock> _lightFixturesPaletteList = new BlockCollection<ScenarioLightFixturePaletteBlock>();
      public BlockCollection<ScenarioSoundSceneryBlock> _soundSceneryList = new BlockCollection<ScenarioSoundSceneryBlock>();
      public BlockCollection<ScenarioSoundSceneryPaletteBlock> _soundSceneryPaletteList = new BlockCollection<ScenarioSoundSceneryPaletteBlock>();
      public BlockCollection<ScenarioProfilesBlock> _playerStartingProfileList = new BlockCollection<ScenarioProfilesBlock>();
      public BlockCollection<ScenarioPlayersBlock> _playerStartingLocationsList = new BlockCollection<ScenarioPlayersBlock>();
      public BlockCollection<ScenarioTriggerVolumeBlock> _triggerVolumesList = new BlockCollection<ScenarioTriggerVolumeBlock>();
      public BlockCollection<RecordedAnimationBlock> _recordedAnimationsList = new BlockCollection<RecordedAnimationBlock>();
      public BlockCollection<ScenarioNetgameFlagsBlock> _netgameFlagsList = new BlockCollection<ScenarioNetgameFlagsBlock>();
      public BlockCollection<ScenarioNetgameEquipmentBlock> _netgameEquipmentList = new BlockCollection<ScenarioNetgameEquipmentBlock>();
      public BlockCollection<ScenarioStartingEquipmentBlock> _startingEquipmentList = new BlockCollection<ScenarioStartingEquipmentBlock>();
      public BlockCollection<ScenarioBspSwitchTriggerVolumeBlock> _bspSwitchTriggerVolumesList = new BlockCollection<ScenarioBspSwitchTriggerVolumeBlock>();
      public BlockCollection<ScenarioDecalsBlock> _decalsList = new BlockCollection<ScenarioDecalsBlock>();
      public BlockCollection<ScenarioDecalPaletteBlock> _decalPaletteList = new BlockCollection<ScenarioDecalPaletteBlock>();
      public BlockCollection<ScenarioDetailObjectCollectionPaletteBlock> _detailObjectCollectionPaletteList = new BlockCollection<ScenarioDetailObjectCollectionPaletteBlock>();
      public BlockCollection<ActorPaletteBlock> _actorPaletteList = new BlockCollection<ActorPaletteBlock>();
      public BlockCollection<EncounterBlock> _encountersList = new BlockCollection<EncounterBlock>();
      public BlockCollection<AiCommandListBlock> _commandListsList = new BlockCollection<AiCommandListBlock>();
      public BlockCollection<AiAnimationReferenceBlock> _aiAnimationReferencesList = new BlockCollection<AiAnimationReferenceBlock>();
      public BlockCollection<AiScriptReferenceBlock> _aiScriptReferencesList = new BlockCollection<AiScriptReferenceBlock>();
      public BlockCollection<AiRecordingReferenceBlock> _aiRecordingReferencesList = new BlockCollection<AiRecordingReferenceBlock>();
      public BlockCollection<AiConversationBlock> _aiConversationsList = new BlockCollection<AiConversationBlock>();
      public BlockCollection<HsScriptsBlock> _scriptsList = new BlockCollection<HsScriptsBlock>();
      public BlockCollection<HsGlobalsBlock> _globalsList = new BlockCollection<HsGlobalsBlock>();
      public BlockCollection<HsReferencesBlock> _referencesList = new BlockCollection<HsReferencesBlock>();
      public BlockCollection<HsSourceFilesBlock> _sourceFilesList = new BlockCollection<HsSourceFilesBlock>();
      public BlockCollection<ScenarioCutsceneFlagBlock> _cutsceneFlagsList = new BlockCollection<ScenarioCutsceneFlagBlock>();
      public BlockCollection<ScenarioCutsceneCameraPointBlock> _cutsceneCameraPointsList = new BlockCollection<ScenarioCutsceneCameraPointBlock>();
      public BlockCollection<ScenarioCutsceneTitleBlock> _cutsceneTitlesList = new BlockCollection<ScenarioCutsceneTitleBlock>();
      public BlockCollection<ScenarioStructureBspsBlock> _structureBspsList = new BlockCollection<ScenarioStructureBspsBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(20);
        this._unnamed2 = new Pad(136);
        this._unnamed3 = new Pad(224);
        this._unnamed4 = new Pad(84);
        this._unnamed5 = new Pad(84);
        this._unnamed6 = new Pad(24);
        this._unnamed7 = new Pad(108);
      }
      public BlockCollection<ScenarioSkyReferenceBlock> Skies {
        get {
          return this._skiesList;
        }
      }
      public BlockCollection<ScenarioChildScenarioBlock> ChildScenarios {
        get {
          return this._childScenariosList;
        }
      }
      public BlockCollection<PredictedResourceBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<ScenarioFunctionBlock> Functions {
        get {
          return this._functionsList;
        }
      }
      public BlockCollection<EditorCommentBlock> Comments {
        get {
          return this._commentsList;
        }
      }
      public BlockCollection<ScenarioObjectNamesBlock> ObjectNames {
        get {
          return this._objectNamesList;
        }
      }
      public BlockCollection<ScenarioSceneryBlock> Scenery {
        get {
          return this._sceneryList;
        }
      }
      public BlockCollection<ScenarioSceneryPaletteBlock> SceneryPalette {
        get {
          return this._sceneryPaletteList;
        }
      }
      public BlockCollection<ScenarioBipedBlock> Bipeds {
        get {
          return this._bipedsList;
        }
      }
      public BlockCollection<ScenarioBipedPaletteBlock> BipedPalette {
        get {
          return this._bipedPaletteList;
        }
      }
      public BlockCollection<ScenarioVehicleBlock> Vehicles {
        get {
          return this._vehiclesList;
        }
      }
      public BlockCollection<ScenarioVehiclePaletteBlock> VehiclePalette {
        get {
          return this._vehiclePaletteList;
        }
      }
      public BlockCollection<ScenarioEquipmentBlock> Equipment {
        get {
          return this._equipmentList;
        }
      }
      public BlockCollection<ScenarioEquipmentPaletteBlock> EquipmentPalette {
        get {
          return this._equipmentPaletteList;
        }
      }
      public BlockCollection<ScenarioWeaponBlock> Weapons {
        get {
          return this._weaponsList;
        }
      }
      public BlockCollection<ScenarioWeaponPaletteBlock> WeaponPalette {
        get {
          return this._weaponPaletteList;
        }
      }
      public BlockCollection<DeviceGroupBlock> DeviceGroups {
        get {
          return this._deviceGroupsList;
        }
      }
      public BlockCollection<ScenarioMachineBlock> Machines {
        get {
          return this._machinesList;
        }
      }
      public BlockCollection<ScenarioMachinePaletteBlock> MachinePalette {
        get {
          return this._machinePaletteList;
        }
      }
      public BlockCollection<ScenarioControlBlock> Controls {
        get {
          return this._controlsList;
        }
      }
      public BlockCollection<ScenarioControlPaletteBlock> ControlPalette {
        get {
          return this._controlPaletteList;
        }
      }
      public BlockCollection<ScenarioLightFixtureBlock> LightFixtures {
        get {
          return this._lightFixturesList;
        }
      }
      public BlockCollection<ScenarioLightFixturePaletteBlock> LightFixturesPalette {
        get {
          return this._lightFixturesPaletteList;
        }
      }
      public BlockCollection<ScenarioSoundSceneryBlock> SoundScenery {
        get {
          return this._soundSceneryList;
        }
      }
      public BlockCollection<ScenarioSoundSceneryPaletteBlock> SoundSceneryPalette {
        get {
          return this._soundSceneryPaletteList;
        }
      }
      public BlockCollection<ScenarioProfilesBlock> PlayerStartingProfile {
        get {
          return this._playerStartingProfileList;
        }
      }
      public BlockCollection<ScenarioPlayersBlock> PlayerStartingLocations {
        get {
          return this._playerStartingLocationsList;
        }
      }
      public BlockCollection<ScenarioTriggerVolumeBlock> TriggerVolumes {
        get {
          return this._triggerVolumesList;
        }
      }
      public BlockCollection<RecordedAnimationBlock> RecordedAnimations {
        get {
          return this._recordedAnimationsList;
        }
      }
      public BlockCollection<ScenarioNetgameFlagsBlock> NetgameFlags {
        get {
          return this._netgameFlagsList;
        }
      }
      public BlockCollection<ScenarioNetgameEquipmentBlock> NetgameEquipment {
        get {
          return this._netgameEquipmentList;
        }
      }
      public BlockCollection<ScenarioStartingEquipmentBlock> StartingEquipment {
        get {
          return this._startingEquipmentList;
        }
      }
      public BlockCollection<ScenarioBspSwitchTriggerVolumeBlock> BspSwitchTriggerVolumes {
        get {
          return this._bspSwitchTriggerVolumesList;
        }
      }
      public BlockCollection<ScenarioDecalsBlock> Decals {
        get {
          return this._decalsList;
        }
      }
      public BlockCollection<ScenarioDecalPaletteBlock> DecalPalette {
        get {
          return this._decalPaletteList;
        }
      }
      public BlockCollection<ScenarioDetailObjectCollectionPaletteBlock> DetailObjectCollectionPalette {
        get {
          return this._detailObjectCollectionPaletteList;
        }
      }
      public BlockCollection<ActorPaletteBlock> ActorPalette {
        get {
          return this._actorPaletteList;
        }
      }
      public BlockCollection<EncounterBlock> Encounters {
        get {
          return this._encountersList;
        }
      }
      public BlockCollection<AiCommandListBlock> CommandLists {
        get {
          return this._commandListsList;
        }
      }
      public BlockCollection<AiAnimationReferenceBlock> AiAnimationReferences {
        get {
          return this._aiAnimationReferencesList;
        }
      }
      public BlockCollection<AiScriptReferenceBlock> AiScriptReferences {
        get {
          return this._aiScriptReferencesList;
        }
      }
      public BlockCollection<AiRecordingReferenceBlock> AiRecordingReferences {
        get {
          return this._aiRecordingReferencesList;
        }
      }
      public BlockCollection<AiConversationBlock> AiConversations {
        get {
          return this._aiConversationsList;
        }
      }
      public BlockCollection<HsScriptsBlock> Scripts {
        get {
          return this._scriptsList;
        }
      }
      public BlockCollection<HsGlobalsBlock> Globals {
        get {
          return this._globalsList;
        }
      }
      public BlockCollection<HsReferencesBlock> References {
        get {
          return this._referencesList;
        }
      }
      public BlockCollection<HsSourceFilesBlock> SourceFiles {
        get {
          return this._sourceFilesList;
        }
      }
      public BlockCollection<ScenarioCutsceneFlagBlock> CutsceneFlags {
        get {
          return this._cutsceneFlagsList;
        }
      }
      public BlockCollection<ScenarioCutsceneCameraPointBlock> CutsceneCameraPoints {
        get {
          return this._cutsceneCameraPointsList;
        }
      }
      public BlockCollection<ScenarioCutsceneTitleBlock> CutsceneTitles {
        get {
          return this._cutsceneTitlesList;
        }
      }
      public BlockCollection<ScenarioStructureBspsBlock> StructureBsps {
        get {
          return this._structureBspsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_dONTUSE.Value);
references.Add(_wONTUSE.Value);
references.Add(_cANTUSE.Value);
references.Add(_customObjectNames.Value);
references.Add(_ingameHelpText.Value);
references.Add(_hudMessages.Value);
for (int x=0; x<Skies.BlockCount; x++)
{
  IBlock block = Skies.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ChildScenarios.BlockCount; x++)
{
  IBlock block = ChildScenarios.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PredictedResources.BlockCount; x++)
{
  IBlock block = PredictedResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Functions.BlockCount; x++)
{
  IBlock block = Functions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Comments.BlockCount; x++)
{
  IBlock block = Comments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ObjectNames.BlockCount; x++)
{
  IBlock block = ObjectNames.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Scenery.BlockCount; x++)
{
  IBlock block = Scenery.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SceneryPalette.BlockCount; x++)
{
  IBlock block = SceneryPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bipeds.BlockCount; x++)
{
  IBlock block = Bipeds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BipedPalette.BlockCount; x++)
{
  IBlock block = BipedPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vehicles.BlockCount; x++)
{
  IBlock block = Vehicles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<VehiclePalette.BlockCount; x++)
{
  IBlock block = VehiclePalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Equipment.BlockCount; x++)
{
  IBlock block = Equipment.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EquipmentPalette.BlockCount; x++)
{
  IBlock block = EquipmentPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Weapons.BlockCount; x++)
{
  IBlock block = Weapons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeaponPalette.BlockCount; x++)
{
  IBlock block = WeaponPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DeviceGroups.BlockCount; x++)
{
  IBlock block = DeviceGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Machines.BlockCount; x++)
{
  IBlock block = Machines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MachinePalette.BlockCount; x++)
{
  IBlock block = MachinePalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Controls.BlockCount; x++)
{
  IBlock block = Controls.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ControlPalette.BlockCount; x++)
{
  IBlock block = ControlPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LightFixtures.BlockCount; x++)
{
  IBlock block = LightFixtures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LightFixturesPalette.BlockCount; x++)
{
  IBlock block = LightFixturesPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundScenery.BlockCount; x++)
{
  IBlock block = SoundScenery.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundSceneryPalette.BlockCount; x++)
{
  IBlock block = SoundSceneryPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerStartingProfile.BlockCount; x++)
{
  IBlock block = PlayerStartingProfile.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerStartingLocations.BlockCount; x++)
{
  IBlock block = PlayerStartingLocations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<TriggerVolumes.BlockCount; x++)
{
  IBlock block = TriggerVolumes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RecordedAnimations.BlockCount; x++)
{
  IBlock block = RecordedAnimations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NetgameFlags.BlockCount; x++)
{
  IBlock block = NetgameFlags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<NetgameEquipment.BlockCount; x++)
{
  IBlock block = NetgameEquipment.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StartingEquipment.BlockCount; x++)
{
  IBlock block = StartingEquipment.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BspSwitchTriggerVolumes.BlockCount; x++)
{
  IBlock block = BspSwitchTriggerVolumes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decals.BlockCount; x++)
{
  IBlock block = Decals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalPalette.BlockCount; x++)
{
  IBlock block = DecalPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DetailObjectCollectionPalette.BlockCount; x++)
{
  IBlock block = DetailObjectCollectionPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ActorPalette.BlockCount; x++)
{
  IBlock block = ActorPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Encounters.BlockCount; x++)
{
  IBlock block = Encounters.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CommandLists.BlockCount; x++)
{
  IBlock block = CommandLists.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiAnimationReferences.BlockCount; x++)
{
  IBlock block = AiAnimationReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiScriptReferences.BlockCount; x++)
{
  IBlock block = AiScriptReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiRecordingReferences.BlockCount; x++)
{
  IBlock block = AiRecordingReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AiConversations.BlockCount; x++)
{
  IBlock block = AiConversations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Scripts.BlockCount; x++)
{
  IBlock block = Scripts.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Globals.BlockCount; x++)
{
  IBlock block = Globals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<References.BlockCount; x++)
{
  IBlock block = References.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SourceFiles.BlockCount; x++)
{
  IBlock block = SourceFiles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CutsceneFlags.BlockCount; x++)
{
  IBlock block = CutsceneFlags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CutsceneCameraPoints.BlockCount; x++)
{
  IBlock block = CutsceneCameraPoints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CutsceneTitles.BlockCount; x++)
{
  IBlock block = CutsceneTitles.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StructureBsps.BlockCount; x++)
{
  IBlock block = StructureBsps.GetBlock(x);
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
      public TagReference DONTUSE {
        get {
          return this._dONTUSE;
        }
        set {
          this._dONTUSE = value;
        }
      }
      public TagReference WONTUSE {
        get {
          return this._wONTUSE;
        }
        set {
          this._wONTUSE = value;
        }
      }
      public TagReference CANTUSE {
        get {
          return this._cANTUSE;
        }
        set {
          this._cANTUSE = value;
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public Angle LocalNorth {
        get {
          return this._localNorth;
        }
        set {
          this._localNorth = value;
        }
      }
      public Data EditorScenarioData {
        get {
          return this._editorScenarioData;
        }
        set {
          this._editorScenarioData = value;
        }
      }
      public Data ScriptSyntaxData {
        get {
          return this._scriptSyntaxData;
        }
        set {
          this._scriptSyntaxData = value;
        }
      }
      public Data ScriptStringData {
        get {
          return this._scriptStringData;
        }
        set {
          this._scriptStringData = value;
        }
      }
      public TagReference CustomObjectNames {
        get {
          return this._customObjectNames;
        }
        set {
          this._customObjectNames = value;
        }
      }
      public TagReference IngameHelpText {
        get {
          return this._ingameHelpText;
        }
        set {
          this._ingameHelpText = value;
        }
      }
      public TagReference HudMessages {
        get {
          return this._hudMessages;
        }
        set {
          this._hudMessages = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dONTUSE.Read(reader);
        _wONTUSE.Read(reader);
        _cANTUSE.Read(reader);
        _skies.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _childScenarios.Read(reader);
        _localNorth.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _predictedResources.Read(reader);
        _functions.Read(reader);
        _editorScenarioData.Read(reader);
        _comments.Read(reader);
        _unnamed3.Read(reader);
        _objectNames.Read(reader);
        _scenery.Read(reader);
        _sceneryPalette.Read(reader);
        _bipeds.Read(reader);
        _bipedPalette.Read(reader);
        _vehicles.Read(reader);
        _vehiclePalette.Read(reader);
        _equipment.Read(reader);
        _equipmentPalette.Read(reader);
        _weapons.Read(reader);
        _weaponPalette.Read(reader);
        _deviceGroups.Read(reader);
        _machines.Read(reader);
        _machinePalette.Read(reader);
        _controls.Read(reader);
        _controlPalette.Read(reader);
        _lightFixtures.Read(reader);
        _lightFixturesPalette.Read(reader);
        _soundScenery.Read(reader);
        _soundSceneryPalette.Read(reader);
        _unnamed4.Read(reader);
        _playerStartingProfile.Read(reader);
        _playerStartingLocations.Read(reader);
        _triggerVolumes.Read(reader);
        _recordedAnimations.Read(reader);
        _netgameFlags.Read(reader);
        _netgameEquipment.Read(reader);
        _startingEquipment.Read(reader);
        _bspSwitchTriggerVolumes.Read(reader);
        _decals.Read(reader);
        _decalPalette.Read(reader);
        _detailObjectCollectionPalette.Read(reader);
        _unnamed5.Read(reader);
        _actorPalette.Read(reader);
        _encounters.Read(reader);
        _commandLists.Read(reader);
        _aiAnimationReferences.Read(reader);
        _aiScriptReferences.Read(reader);
        _aiRecordingReferences.Read(reader);
        _aiConversations.Read(reader);
        _scriptSyntaxData.Read(reader);
        _scriptStringData.Read(reader);
        _scripts.Read(reader);
        _globals.Read(reader);
        _references.Read(reader);
        _sourceFiles.Read(reader);
        _unnamed6.Read(reader);
        _cutsceneFlags.Read(reader);
        _cutsceneCameraPoints.Read(reader);
        _cutsceneTitles.Read(reader);
        _unnamed7.Read(reader);
        _customObjectNames.Read(reader);
        _ingameHelpText.Read(reader);
        _hudMessages.Read(reader);
        _structureBsps.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _dONTUSE.ReadString(reader);
        _wONTUSE.ReadString(reader);
        _cANTUSE.ReadString(reader);
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies.Add(new ScenarioSkyReferenceBlock());
          Skies[x].Read(reader);
        }
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies[x].ReadChildData(reader);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios.Add(new ScenarioChildScenarioBlock());
          ChildScenarios[x].Read(reader);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions.Add(new ScenarioFunctionBlock());
          Functions[x].Read(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].ReadChildData(reader);
        }
        _editorScenarioData.ReadBinary(reader);
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments.Add(new EditorCommentBlock());
          Comments[x].Read(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames.Add(new ScenarioObjectNamesBlock());
          ObjectNames[x].Read(reader);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery.Add(new ScenarioSceneryBlock());
          Scenery[x].Read(reader);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette.Add(new ScenarioSceneryPaletteBlock());
          SceneryPalette[x].Read(reader);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds.Add(new ScenarioBipedBlock());
          Bipeds[x].Read(reader);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette.Add(new ScenarioBipedPaletteBlock());
          BipedPalette[x].Read(reader);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles.Add(new ScenarioVehicleBlock());
          Vehicles[x].Read(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette.Add(new ScenarioVehiclePaletteBlock());
          VehiclePalette[x].Read(reader);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment.Add(new ScenarioEquipmentBlock());
          Equipment[x].Read(reader);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette.Add(new ScenarioEquipmentPaletteBlock());
          EquipmentPalette[x].Read(reader);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons.Add(new ScenarioWeaponBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette.Add(new ScenarioWeaponPaletteBlock());
          WeaponPalette[x].Read(reader);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups.Add(new DeviceGroupBlock());
          DeviceGroups[x].Read(reader);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines.Add(new ScenarioMachineBlock());
          Machines[x].Read(reader);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette.Add(new ScenarioMachinePaletteBlock());
          MachinePalette[x].Read(reader);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls.Add(new ScenarioControlBlock());
          Controls[x].Read(reader);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls[x].ReadChildData(reader);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette.Add(new ScenarioControlPaletteBlock());
          ControlPalette[x].Read(reader);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures.Add(new ScenarioLightFixtureBlock());
          LightFixtures[x].Read(reader);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette.Add(new ScenarioLightFixturePaletteBlock());
          LightFixturesPalette[x].Read(reader);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery.Add(new ScenarioSoundSceneryBlock());
          SoundScenery[x].Read(reader);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette.Add(new ScenarioSoundSceneryPaletteBlock());
          SoundSceneryPalette[x].Read(reader);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile.Add(new ScenarioProfilesBlock());
          PlayerStartingProfile[x].Read(reader);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations.Add(new ScenarioPlayersBlock());
          PlayerStartingLocations[x].Read(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triggerVolumes.Count); x = (x + 1)) {
          TriggerVolumes.Add(new ScenarioTriggerVolumeBlock());
          TriggerVolumes[x].Read(reader);
        }
        for (x = 0; (x < _triggerVolumes.Count); x = (x + 1)) {
          TriggerVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations.Add(new RecordedAnimationBlock());
          RecordedAnimations[x].Read(reader);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags.Add(new ScenarioNetgameFlagsBlock());
          NetgameFlags[x].Read(reader);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment.Add(new ScenarioNetgameEquipmentBlock());
          NetgameEquipment[x].Read(reader);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment.Add(new ScenarioStartingEquipmentBlock());
          StartingEquipment[x].Read(reader);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bspSwitchTriggerVolumes.Count); x = (x + 1)) {
          BspSwitchTriggerVolumes.Add(new ScenarioBspSwitchTriggerVolumeBlock());
          BspSwitchTriggerVolumes[x].Read(reader);
        }
        for (x = 0; (x < _bspSwitchTriggerVolumes.Count); x = (x + 1)) {
          BspSwitchTriggerVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals.Add(new ScenarioDecalsBlock());
          Decals[x].Read(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalPalette.Count); x = (x + 1)) {
          DecalPalette.Add(new ScenarioDecalPaletteBlock());
          DecalPalette[x].Read(reader);
        }
        for (x = 0; (x < _decalPalette.Count); x = (x + 1)) {
          DecalPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette.Add(new ScenarioDetailObjectCollectionPaletteBlock());
          DetailObjectCollectionPalette[x].Read(reader);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _actorPalette.Count); x = (x + 1)) {
          ActorPalette.Add(new ActorPaletteBlock());
          ActorPalette[x].Read(reader);
        }
        for (x = 0; (x < _actorPalette.Count); x = (x + 1)) {
          ActorPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _encounters.Count); x = (x + 1)) {
          Encounters.Add(new EncounterBlock());
          Encounters[x].Read(reader);
        }
        for (x = 0; (x < _encounters.Count); x = (x + 1)) {
          Encounters[x].ReadChildData(reader);
        }
        for (x = 0; (x < _commandLists.Count); x = (x + 1)) {
          CommandLists.Add(new AiCommandListBlock());
          CommandLists[x].Read(reader);
        }
        for (x = 0; (x < _commandLists.Count); x = (x + 1)) {
          CommandLists[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiAnimationReferences.Count); x = (x + 1)) {
          AiAnimationReferences.Add(new AiAnimationReferenceBlock());
          AiAnimationReferences[x].Read(reader);
        }
        for (x = 0; (x < _aiAnimationReferences.Count); x = (x + 1)) {
          AiAnimationReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiScriptReferences.Count); x = (x + 1)) {
          AiScriptReferences.Add(new AiScriptReferenceBlock());
          AiScriptReferences[x].Read(reader);
        }
        for (x = 0; (x < _aiScriptReferences.Count); x = (x + 1)) {
          AiScriptReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiRecordingReferences.Count); x = (x + 1)) {
          AiRecordingReferences.Add(new AiRecordingReferenceBlock());
          AiRecordingReferences[x].Read(reader);
        }
        for (x = 0; (x < _aiRecordingReferences.Count); x = (x + 1)) {
          AiRecordingReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aiConversations.Count); x = (x + 1)) {
          AiConversations.Add(new AiConversationBlock());
          AiConversations[x].Read(reader);
        }
        for (x = 0; (x < _aiConversations.Count); x = (x + 1)) {
          AiConversations[x].ReadChildData(reader);
        }
        _scriptSyntaxData.ReadBinary(reader);
        _scriptStringData.ReadBinary(reader);
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts.Add(new HsScriptsBlock());
          Scripts[x].Read(reader);
        }
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals.Add(new HsGlobalsBlock());
          Globals[x].Read(reader);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References.Add(new HsReferencesBlock());
          References[x].Read(reader);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles.Add(new HsSourceFilesBlock());
          SourceFiles[x].Read(reader);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags.Add(new ScenarioCutsceneFlagBlock());
          CutsceneFlags[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints.Add(new ScenarioCutsceneCameraPointBlock());
          CutsceneCameraPoints[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles.Add(new ScenarioCutsceneTitleBlock());
          CutsceneTitles[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles[x].ReadChildData(reader);
        }
        _customObjectNames.ReadString(reader);
        _ingameHelpText.ReadString(reader);
        _hudMessages.ReadString(reader);
        for (x = 0; (x < _structureBsps.Count); x = (x + 1)) {
          StructureBsps.Add(new ScenarioStructureBspsBlock());
          StructureBsps[x].Read(reader);
        }
        for (x = 0; (x < _structureBsps.Count); x = (x + 1)) {
          StructureBsps[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dONTUSE.Write(bw);
        _wONTUSE.Write(bw);
        _cANTUSE.Write(bw);
_skies.Count = Skies.Count;
        _skies.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
_childScenarios.Count = ChildScenarios.Count;
        _childScenarios.Write(bw);
        _localNorth.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_functions.Count = Functions.Count;
        _functions.Write(bw);
        _editorScenarioData.Write(bw);
_comments.Count = Comments.Count;
        _comments.Write(bw);
        _unnamed3.Write(bw);
_objectNames.Count = ObjectNames.Count;
        _objectNames.Write(bw);
_scenery.Count = Scenery.Count;
        _scenery.Write(bw);
_sceneryPalette.Count = SceneryPalette.Count;
        _sceneryPalette.Write(bw);
_bipeds.Count = Bipeds.Count;
        _bipeds.Write(bw);
_bipedPalette.Count = BipedPalette.Count;
        _bipedPalette.Write(bw);
_vehicles.Count = Vehicles.Count;
        _vehicles.Write(bw);
_vehiclePalette.Count = VehiclePalette.Count;
        _vehiclePalette.Write(bw);
_equipment.Count = Equipment.Count;
        _equipment.Write(bw);
_equipmentPalette.Count = EquipmentPalette.Count;
        _equipmentPalette.Write(bw);
_weapons.Count = Weapons.Count;
        _weapons.Write(bw);
_weaponPalette.Count = WeaponPalette.Count;
        _weaponPalette.Write(bw);
_deviceGroups.Count = DeviceGroups.Count;
        _deviceGroups.Write(bw);
_machines.Count = Machines.Count;
        _machines.Write(bw);
_machinePalette.Count = MachinePalette.Count;
        _machinePalette.Write(bw);
_controls.Count = Controls.Count;
        _controls.Write(bw);
_controlPalette.Count = ControlPalette.Count;
        _controlPalette.Write(bw);
_lightFixtures.Count = LightFixtures.Count;
        _lightFixtures.Write(bw);
_lightFixturesPalette.Count = LightFixturesPalette.Count;
        _lightFixturesPalette.Write(bw);
_soundScenery.Count = SoundScenery.Count;
        _soundScenery.Write(bw);
_soundSceneryPalette.Count = SoundSceneryPalette.Count;
        _soundSceneryPalette.Write(bw);
        _unnamed4.Write(bw);
_playerStartingProfile.Count = PlayerStartingProfile.Count;
        _playerStartingProfile.Write(bw);
_playerStartingLocations.Count = PlayerStartingLocations.Count;
        _playerStartingLocations.Write(bw);
_triggerVolumes.Count = TriggerVolumes.Count;
        _triggerVolumes.Write(bw);
_recordedAnimations.Count = RecordedAnimations.Count;
        _recordedAnimations.Write(bw);
_netgameFlags.Count = NetgameFlags.Count;
        _netgameFlags.Write(bw);
_netgameEquipment.Count = NetgameEquipment.Count;
        _netgameEquipment.Write(bw);
_startingEquipment.Count = StartingEquipment.Count;
        _startingEquipment.Write(bw);
_bspSwitchTriggerVolumes.Count = BspSwitchTriggerVolumes.Count;
        _bspSwitchTriggerVolumes.Write(bw);
_decals.Count = Decals.Count;
        _decals.Write(bw);
_decalPalette.Count = DecalPalette.Count;
        _decalPalette.Write(bw);
_detailObjectCollectionPalette.Count = DetailObjectCollectionPalette.Count;
        _detailObjectCollectionPalette.Write(bw);
        _unnamed5.Write(bw);
_actorPalette.Count = ActorPalette.Count;
        _actorPalette.Write(bw);
_encounters.Count = Encounters.Count;
        _encounters.Write(bw);
_commandLists.Count = CommandLists.Count;
        _commandLists.Write(bw);
_aiAnimationReferences.Count = AiAnimationReferences.Count;
        _aiAnimationReferences.Write(bw);
_aiScriptReferences.Count = AiScriptReferences.Count;
        _aiScriptReferences.Write(bw);
_aiRecordingReferences.Count = AiRecordingReferences.Count;
        _aiRecordingReferences.Write(bw);
_aiConversations.Count = AiConversations.Count;
        _aiConversations.Write(bw);
        _scriptSyntaxData.Write(bw);
        _scriptStringData.Write(bw);
_scripts.Count = Scripts.Count;
        _scripts.Write(bw);
_globals.Count = Globals.Count;
        _globals.Write(bw);
_references.Count = References.Count;
        _references.Write(bw);
_sourceFiles.Count = SourceFiles.Count;
        _sourceFiles.Write(bw);
        _unnamed6.Write(bw);
_cutsceneFlags.Count = CutsceneFlags.Count;
        _cutsceneFlags.Write(bw);
_cutsceneCameraPoints.Count = CutsceneCameraPoints.Count;
        _cutsceneCameraPoints.Write(bw);
_cutsceneTitles.Count = CutsceneTitles.Count;
        _cutsceneTitles.Write(bw);
        _unnamed7.Write(bw);
        _customObjectNames.Write(bw);
        _ingameHelpText.Write(bw);
        _hudMessages.Write(bw);
_structureBsps.Count = StructureBsps.Count;
        _structureBsps.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _dONTUSE.WriteString(writer);
        _wONTUSE.WriteString(writer);
        _cANTUSE.WriteString(writer);
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies[x].Write(writer);
        }
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies[x].WriteChildData(writer);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios[x].Write(writer);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios[x].WriteChildData(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].Write(writer);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].Write(writer);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].WriteChildData(writer);
        }
        _editorScenarioData.WriteBinary(writer);
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].Write(writer);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames[x].Write(writer);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery[x].Write(writer);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette[x].Write(writer);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds[x].Write(writer);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette[x].Write(writer);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].Write(writer);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette[x].Write(writer);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment[x].Write(writer);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment[x].WriteChildData(writer);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette[x].Write(writer);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].Write(writer);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette[x].Write(writer);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups[x].Write(writer);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines[x].Write(writer);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines[x].WriteChildData(writer);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette[x].Write(writer);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls[x].Write(writer);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls[x].WriteChildData(writer);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette[x].Write(writer);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures[x].Write(writer);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette[x].Write(writer);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery[x].Write(writer);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette[x].Write(writer);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile[x].Write(writer);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].Write(writer);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triggerVolumes.Count); x = (x + 1)) {
          TriggerVolumes[x].Write(writer);
        }
        for (x = 0; (x < _triggerVolumes.Count); x = (x + 1)) {
          TriggerVolumes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations[x].Write(writer);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations[x].WriteChildData(writer);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags[x].Write(writer);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment[x].Write(writer);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment[x].WriteChildData(writer);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment[x].Write(writer);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bspSwitchTriggerVolumes.Count); x = (x + 1)) {
          BspSwitchTriggerVolumes[x].Write(writer);
        }
        for (x = 0; (x < _bspSwitchTriggerVolumes.Count); x = (x + 1)) {
          BspSwitchTriggerVolumes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].Write(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalPalette.Count); x = (x + 1)) {
          DecalPalette[x].Write(writer);
        }
        for (x = 0; (x < _decalPalette.Count); x = (x + 1)) {
          DecalPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].Write(writer);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _actorPalette.Count); x = (x + 1)) {
          ActorPalette[x].Write(writer);
        }
        for (x = 0; (x < _actorPalette.Count); x = (x + 1)) {
          ActorPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _encounters.Count); x = (x + 1)) {
          Encounters[x].Write(writer);
        }
        for (x = 0; (x < _encounters.Count); x = (x + 1)) {
          Encounters[x].WriteChildData(writer);
        }
        for (x = 0; (x < _commandLists.Count); x = (x + 1)) {
          CommandLists[x].Write(writer);
        }
        for (x = 0; (x < _commandLists.Count); x = (x + 1)) {
          CommandLists[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiAnimationReferences.Count); x = (x + 1)) {
          AiAnimationReferences[x].Write(writer);
        }
        for (x = 0; (x < _aiAnimationReferences.Count); x = (x + 1)) {
          AiAnimationReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiScriptReferences.Count); x = (x + 1)) {
          AiScriptReferences[x].Write(writer);
        }
        for (x = 0; (x < _aiScriptReferences.Count); x = (x + 1)) {
          AiScriptReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiRecordingReferences.Count); x = (x + 1)) {
          AiRecordingReferences[x].Write(writer);
        }
        for (x = 0; (x < _aiRecordingReferences.Count); x = (x + 1)) {
          AiRecordingReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aiConversations.Count); x = (x + 1)) {
          AiConversations[x].Write(writer);
        }
        for (x = 0; (x < _aiConversations.Count); x = (x + 1)) {
          AiConversations[x].WriteChildData(writer);
        }
        _scriptSyntaxData.WriteBinary(writer);
        _scriptStringData.WriteBinary(writer);
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts[x].Write(writer);
        }
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts[x].WriteChildData(writer);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals[x].Write(writer);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].Write(writer);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles[x].Write(writer);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags[x].Write(writer);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints[x].Write(writer);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles[x].Write(writer);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles[x].WriteChildData(writer);
        }
        _customObjectNames.WriteString(writer);
        _ingameHelpText.WriteString(writer);
        _hudMessages.WriteString(writer);
        for (x = 0; (x < _structureBsps.Count); x = (x + 1)) {
          StructureBsps[x].Write(writer);
        }
        for (x = 0; (x < _structureBsps.Count); x = (x + 1)) {
          StructureBsps[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioSkyReferenceBlock : IBlock {
      private TagReference _sky = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioSkyReferenceBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_sky.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference Sky {
        get {
          return this._sky;
        }
        set {
          this._sky = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sky.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _sky.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _sky.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _sky.WriteString(writer);
      }
    }
    public class ScenarioChildScenarioBlock : IBlock {
      private TagReference _childScenario = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioChildScenarioBlock() {
        this._unnamed = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_childScenario.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference ChildScenario {
        get {
          return this._childScenario;
        }
        set {
          this._childScenario = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _childScenario.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _childScenario.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _childScenario.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _childScenario.WriteString(writer);
      }
    }
    public class PredictedResourceBlock : IBlock {
      private Enum _type = new Enum();
      private ShortInteger _resourceIndex = new ShortInteger();
      private LongInteger _tagIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger ResourceIndex {
        get {
          return this._resourceIndex;
        }
        set {
          this._resourceIndex = value;
        }
      }
      public LongInteger TagIndex {
        get {
          return this._tagIndex;
        }
        set {
          this._tagIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _tagIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _tagIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioFunctionBlock : IBlock {
      private Flags _flags;
      private FixedLengthString _name = new FixedLengthString();
      private Real _period = new Real();
      private ShortBlockIndex _scalePeriodBy = new ShortBlockIndex();
      private Enum _function = new Enum();
      private ShortBlockIndex _scaleFunctionBy = new ShortBlockIndex();
      private Enum _wobbleFunction = new Enum();
      private Real _wobblePeriod = new Real();
      private Real _wobbleMagnitude = new Real();
      private RealFraction _squareWaveThreshold = new RealFraction();
      private ShortInteger _stepCount = new ShortInteger();
      private Enum _mapTo = new Enum();
      private ShortInteger _sawtoothCount = new ShortInteger();
      private Pad _unnamed;
      private ShortBlockIndex _scaleResultBy = new ShortBlockIndex();
      private Enum _boundsMode = new Enum();
      private RealFractionBounds _bounds = new RealFractionBounds();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private ShortBlockIndex _turnOffWith = new ShortBlockIndex();
      private Pad _unnamed4;
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public ScenarioFunctionBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(16);
        this._unnamed5 = new Pad(16);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
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
      public Real Period {
        get {
          return this._period;
        }
        set {
          this._period = value;
        }
      }
      public ShortBlockIndex ScalePeriodBy {
        get {
          return this._scalePeriodBy;
        }
        set {
          this._scalePeriodBy = value;
        }
      }
      public Enum Function {
        get {
          return this._function;
        }
        set {
          this._function = value;
        }
      }
      public ShortBlockIndex ScaleFunctionBy {
        get {
          return this._scaleFunctionBy;
        }
        set {
          this._scaleFunctionBy = value;
        }
      }
      public Enum WobbleFunction {
        get {
          return this._wobbleFunction;
        }
        set {
          this._wobbleFunction = value;
        }
      }
      public Real WobblePeriod {
        get {
          return this._wobblePeriod;
        }
        set {
          this._wobblePeriod = value;
        }
      }
      public Real WobbleMagnitude {
        get {
          return this._wobbleMagnitude;
        }
        set {
          this._wobbleMagnitude = value;
        }
      }
      public RealFraction SquareWaveThreshold {
        get {
          return this._squareWaveThreshold;
        }
        set {
          this._squareWaveThreshold = value;
        }
      }
      public ShortInteger StepCount {
        get {
          return this._stepCount;
        }
        set {
          this._stepCount = value;
        }
      }
      public Enum MapTo {
        get {
          return this._mapTo;
        }
        set {
          this._mapTo = value;
        }
      }
      public ShortInteger SawtoothCount {
        get {
          return this._sawtoothCount;
        }
        set {
          this._sawtoothCount = value;
        }
      }
      public ShortBlockIndex ScaleResultBy {
        get {
          return this._scaleResultBy;
        }
        set {
          this._scaleResultBy = value;
        }
      }
      public Enum BoundsMode {
        get {
          return this._boundsMode;
        }
        set {
          this._boundsMode = value;
        }
      }
      public RealFractionBounds Bounds {
        get {
          return this._bounds;
        }
        set {
          this._bounds = value;
        }
      }
      public ShortBlockIndex TurnOffWith {
        get {
          return this._turnOffWith;
        }
        set {
          this._turnOffWith = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _name.Read(reader);
        _period.Read(reader);
        _scalePeriodBy.Read(reader);
        _function.Read(reader);
        _scaleFunctionBy.Read(reader);
        _wobbleFunction.Read(reader);
        _wobblePeriod.Read(reader);
        _wobbleMagnitude.Read(reader);
        _squareWaveThreshold.Read(reader);
        _stepCount.Read(reader);
        _mapTo.Read(reader);
        _sawtoothCount.Read(reader);
        _unnamed.Read(reader);
        _scaleResultBy.Read(reader);
        _boundsMode.Read(reader);
        _bounds.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _turnOffWith.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _name.Write(bw);
        _period.Write(bw);
        _scalePeriodBy.Write(bw);
        _function.Write(bw);
        _scaleFunctionBy.Write(bw);
        _wobbleFunction.Write(bw);
        _wobblePeriod.Write(bw);
        _wobbleMagnitude.Write(bw);
        _squareWaveThreshold.Write(bw);
        _stepCount.Write(bw);
        _mapTo.Write(bw);
        _sawtoothCount.Write(bw);
        _unnamed.Write(bw);
        _scaleResultBy.Write(bw);
        _boundsMode.Write(bw);
        _bounds.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _turnOffWith.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EditorCommentBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Pad _unnamed;
      private Data _comment = new Data();
public event System.EventHandler BlockNameChanged;
      public EditorCommentBlock() {
        this._unnamed = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Data Comment {
        get {
          return this._comment;
        }
        set {
          this._comment = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _unnamed.Read(reader);
        _comment.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _comment.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _unnamed.Write(bw);
        _comment.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _comment.WriteBinary(writer);
      }
    }
    public class ScenarioObjectNamesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioObjectNamesBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSceneryBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public ScenarioSceneryBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSceneryPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioSceneryPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioBipedBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Real _bodyVitality = new Real();
      private Flags _flags;
      private Pad _unnamed5;
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public ScenarioBipedBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(8);
        this._flags = new Flags(4);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public Real BodyVitality {
        get {
          return this._bodyVitality;
        }
        set {
          this._bodyVitality = value;
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _bodyVitality.Read(reader);
        _flags.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _bodyVitality.Write(bw);
        _flags.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioBipedPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioBipedPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioVehicleBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private Real _bodyVitality = new Real();
      private Flags _flags;
      private Pad _unnamed5;
      private CharInteger _multiplayerTeamIndex = new CharInteger();
      private Pad _unnamed6;
      private Flags _multiplayerSpawnFlags;
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public ScenarioVehicleBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(8);
        this._flags = new Flags(4);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(1);
        this._multiplayerSpawnFlags = new Flags(2);
        this._unnamed7 = new Pad(28);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public Real BodyVitality {
        get {
          return this._bodyVitality;
        }
        set {
          this._bodyVitality = value;
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
      public CharInteger MultiplayerTeamIndex {
        get {
          return this._multiplayerTeamIndex;
        }
        set {
          this._multiplayerTeamIndex = value;
        }
      }
      public Flags MultiplayerSpawnFlags {
        get {
          return this._multiplayerSpawnFlags;
        }
        set {
          this._multiplayerSpawnFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _bodyVitality.Read(reader);
        _flags.Read(reader);
        _unnamed5.Read(reader);
        _multiplayerTeamIndex.Read(reader);
        _unnamed6.Read(reader);
        _multiplayerSpawnFlags.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _bodyVitality.Write(bw);
        _flags.Write(bw);
        _unnamed5.Write(bw);
        _multiplayerTeamIndex.Write(bw);
        _unnamed6.Write(bw);
        _multiplayerSpawnFlags.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioVehiclePaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioVehiclePaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioEquipmentBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private Flags _miscFlags;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioEquipmentBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(2);
        this._miscFlags = new Flags(2);
        this._unnamed2 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public Flags MiscFlags {
        get {
          return this._miscFlags;
        }
        set {
          this._miscFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _miscFlags.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _miscFlags.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioEquipmentPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioEquipmentPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioWeaponBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Pad _unnamed4;
      private ShortInteger _roundsLeft = new ShortInteger();
      private ShortInteger _roundsLoaded = new ShortInteger();
      private Flags _flags;
      private Pad _unnamed5;
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public ScenarioWeaponBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(16);
        this._unnamed3 = new Pad(8);
        this._unnamed4 = new Pad(8);
        this._flags = new Flags(2);
        this._unnamed5 = new Pad(2);
        this._unnamed6 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public ShortInteger RoundsLeft {
        get {
          return this._roundsLeft;
        }
        set {
          this._roundsLeft = value;
        }
      }
      public ShortInteger RoundsLoaded {
        get {
          return this._roundsLoaded;
        }
        set {
          this._roundsLoaded = value;
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _roundsLeft.Read(reader);
        _roundsLoaded.Read(reader);
        _flags.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _roundsLeft.Write(bw);
        _roundsLoaded.Write(bw);
        _flags.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioWeaponPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioWeaponPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class DeviceGroupBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Real _initialValue = new Real();
      private Flags _flags;
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public DeviceGroupBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(12);
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
      public Real InitialValue {
        get {
          return this._initialValue;
        }
        set {
          this._initialValue = value;
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _initialValue.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _initialValue.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioMachineBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private Flags _flags2;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioMachineBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._flags = new Flags(4);
        this._flags2 = new Flags(4);
        this._unnamed2 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public ShortBlockIndex PowerGroup {
        get {
          return this._powerGroup;
        }
        set {
          this._powerGroup = value;
        }
      }
      public ShortBlockIndex PositionGroup {
        get {
          return this._positionGroup;
        }
        set {
          this._positionGroup = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _flags2.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _flags2.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioMachinePaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioMachinePaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioControlBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private Flags _flags2;
      private ShortInteger _unnamed2 = new ShortInteger();
      private Pad _unnamed4;
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public ScenarioControlBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._flags = new Flags(4);
        this._flags2 = new Flags(4);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public ShortBlockIndex PowerGroup {
        get {
          return this._powerGroup;
        }
        set {
          this._powerGroup = value;
        }
      }
      public ShortBlockIndex PositionGroup {
        get {
          return this._positionGroup;
        }
        set {
          this._positionGroup = value;
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
      public Flags Flags2 {
        get {
          return this._flags2;
        }
        set {
          this._flags2 = value;
        }
      }
      public ShortInteger unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _flags2.Read(reader);
        _unnamed2.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _flags2.Write(bw);
        _unnamed2.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioControlPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioControlPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioLightFixtureBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private RealRGBColor _color = new RealRGBColor();
      private Real _intensity = new Real();
      private Angle _falloffAngle = new Angle();
      private Angle _cutoffAngle = new Angle();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioLightFixtureBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
        this._flags = new Flags(4);
        this._unnamed2 = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public ShortBlockIndex PowerGroup {
        get {
          return this._powerGroup;
        }
        set {
          this._powerGroup = value;
        }
      }
      public ShortBlockIndex PositionGroup {
        get {
          return this._positionGroup;
        }
        set {
          this._positionGroup = value;
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
      public RealRGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public Real Intensity {
        get {
          return this._intensity;
        }
        set {
          this._intensity = value;
        }
      }
      public Angle FalloffAngle {
        get {
          return this._falloffAngle;
        }
        set {
          this._falloffAngle = value;
        }
      }
      public Angle CutoffAngle {
        get {
          return this._cutoffAngle;
        }
        set {
          this._cutoffAngle = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _color.Read(reader);
        _intensity.Read(reader);
        _falloffAngle.Read(reader);
        _cutoffAngle.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _color.Write(bw);
        _intensity.Write(bw);
        _falloffAngle.Write(bw);
        _cutoffAngle.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioLightFixturePaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioLightFixturePaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioSoundSceneryBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _notPlaced;
      private ShortInteger _desiredPermutation = new ShortInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioSoundSceneryBlock() {
        this._notPlaced = new Flags(2);
        this._unnamed = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortBlockIndex Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags NotPlaced {
        get {
          return this._notPlaced;
        }
        set {
          this._notPlaced = value;
        }
      }
      public ShortInteger DesiredPermutation {
        get {
          return this._desiredPermutation;
        }
        set {
          this._desiredPermutation = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Rotation {
        get {
          return this._rotation;
        }
        set {
          this._rotation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _notPlaced.Read(reader);
        _desiredPermutation.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _notPlaced.Write(bw);
        _desiredPermutation.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSoundSceneryPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioSoundSceneryPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioProfilesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealFraction _startingHealthModifier = new RealFraction();
      private RealFraction _startingShieldModifier = new RealFraction();
      private TagReference _primaryWeapon = new TagReference();
      private ShortInteger _roundsLoaded = new ShortInteger();
      private ShortInteger _roundsTotal = new ShortInteger();
      private TagReference _secondaryWeapon = new TagReference();
      private ShortInteger _roundsLoaded2 = new ShortInteger();
      private ShortInteger _roundsTotal2 = new ShortInteger();
      private CharInteger _startingFragmentationGrenadeCount = new CharInteger();
      private CharInteger _startingPlasmaGrenadeCount = new CharInteger();
      private CharInteger _startingUnknownGrenadeCount = new CharInteger();
      private CharInteger _startingUnknownGrenadeCount2 = new CharInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioProfilesBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(20);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_primaryWeapon.Value);
references.Add(_secondaryWeapon.Value);
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
      public RealFraction StartingHealthModifier {
        get {
          return this._startingHealthModifier;
        }
        set {
          this._startingHealthModifier = value;
        }
      }
      public RealFraction StartingShieldModifier {
        get {
          return this._startingShieldModifier;
        }
        set {
          this._startingShieldModifier = value;
        }
      }
      public TagReference PrimaryWeapon {
        get {
          return this._primaryWeapon;
        }
        set {
          this._primaryWeapon = value;
        }
      }
      public ShortInteger RoundsLoaded {
        get {
          return this._roundsLoaded;
        }
        set {
          this._roundsLoaded = value;
        }
      }
      public ShortInteger RoundsTotal {
        get {
          return this._roundsTotal;
        }
        set {
          this._roundsTotal = value;
        }
      }
      public TagReference SecondaryWeapon {
        get {
          return this._secondaryWeapon;
        }
        set {
          this._secondaryWeapon = value;
        }
      }
      public ShortInteger RoundsLoaded2 {
        get {
          return this._roundsLoaded2;
        }
        set {
          this._roundsLoaded2 = value;
        }
      }
      public ShortInteger RoundsTotal2 {
        get {
          return this._roundsTotal2;
        }
        set {
          this._roundsTotal2 = value;
        }
      }
      public CharInteger StartingFragmentationGrenadeCount {
        get {
          return this._startingFragmentationGrenadeCount;
        }
        set {
          this._startingFragmentationGrenadeCount = value;
        }
      }
      public CharInteger StartingPlasmaGrenadeCount {
        get {
          return this._startingPlasmaGrenadeCount;
        }
        set {
          this._startingPlasmaGrenadeCount = value;
        }
      }
      public CharInteger StartingUnknownGrenadeCount {
        get {
          return this._startingUnknownGrenadeCount;
        }
        set {
          this._startingUnknownGrenadeCount = value;
        }
      }
      public CharInteger StartingUnknownGrenadeCount2 {
        get {
          return this._startingUnknownGrenadeCount2;
        }
        set {
          this._startingUnknownGrenadeCount2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _startingHealthModifier.Read(reader);
        _startingShieldModifier.Read(reader);
        _primaryWeapon.Read(reader);
        _roundsLoaded.Read(reader);
        _roundsTotal.Read(reader);
        _secondaryWeapon.Read(reader);
        _roundsLoaded2.Read(reader);
        _roundsTotal2.Read(reader);
        _startingFragmentationGrenadeCount.Read(reader);
        _startingPlasmaGrenadeCount.Read(reader);
        _startingUnknownGrenadeCount.Read(reader);
        _startingUnknownGrenadeCount2.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _primaryWeapon.ReadString(reader);
        _secondaryWeapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _startingHealthModifier.Write(bw);
        _startingShieldModifier.Write(bw);
        _primaryWeapon.Write(bw);
        _roundsLoaded.Write(bw);
        _roundsTotal.Write(bw);
        _secondaryWeapon.Write(bw);
        _roundsLoaded2.Write(bw);
        _roundsTotal2.Write(bw);
        _startingFragmentationGrenadeCount.Write(bw);
        _startingPlasmaGrenadeCount.Write(bw);
        _startingUnknownGrenadeCount.Write(bw);
        _startingUnknownGrenadeCount2.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _primaryWeapon.WriteString(writer);
        _secondaryWeapon.WriteString(writer);
      }
    }
    public class ScenarioPlayersBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private ShortInteger _teamIndex = new ShortInteger();
      private ShortInteger _bspIndex = new ShortInteger();
      private Enum _type0 = new Enum();
      private Enum _type1 = new Enum();
      private Enum _type2 = new Enum();
      private Enum _type3 = new Enum();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioPlayersBlock() {
        this._unnamed = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Angle Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public ShortInteger TeamIndex {
        get {
          return this._teamIndex;
        }
        set {
          this._teamIndex = value;
        }
      }
      public ShortInteger BspIndex {
        get {
          return this._bspIndex;
        }
        set {
          this._bspIndex = value;
        }
      }
      public Enum Type0 {
        get {
          return this._type0;
        }
        set {
          this._type0 = value;
        }
      }
      public Enum Type1 {
        get {
          return this._type1;
        }
        set {
          this._type1 = value;
        }
      }
      public Enum Type2 {
        get {
          return this._type2;
        }
        set {
          this._type2 = value;
        }
      }
      public Enum Type3 {
        get {
          return this._type3;
        }
        set {
          this._type3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _teamIndex.Read(reader);
        _bspIndex.Read(reader);
        _type0.Read(reader);
        _type1.Read(reader);
        _type2.Read(reader);
        _type3.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _teamIndex.Write(bw);
        _bspIndex.Write(bw);
        _type0.Write(bw);
        _type1.Write(bw);
        _type2.Write(bw);
        _type3.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioTriggerVolumeBlock : IBlock {
      private Skip _unnamed;
      private FixedLengthString _name = new FixedLengthString();
      private RealPoint3D _min = new RealPoint3D();
      private RealPoint3D _max = new RealPoint3D();
      private RealPoint3D _trigvol1 = new RealPoint3D();
      private RealPoint3D _trigvol2 = new RealPoint3D();
      private RealPoint3D _trigvol3 = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScenarioTriggerVolumeBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Skip(4);
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
      public RealPoint3D Min {
        get {
          return this._min;
        }
        set {
          this._min = value;
        }
      }
      public RealPoint3D Max {
        get {
          return this._max;
        }
        set {
          this._max = value;
        }
      }
      public RealPoint3D Trigvol1 {
        get {
          return this._trigvol1;
        }
        set {
          this._trigvol1 = value;
        }
      }
      public RealPoint3D Trigvol2 {
        get {
          return this._trigvol2;
        }
        set {
          this._trigvol2 = value;
        }
      }
      public RealPoint3D Trigvol3 {
        get {
          return this._trigvol3;
        }
        set {
          this._trigvol3 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _name.Read(reader);
        _min.Read(reader);
        _max.Read(reader);
        _trigvol1.Read(reader);
        _trigvol2.Read(reader);
        _trigvol3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _name.Write(bw);
        _min.Write(bw);
        _max.Write(bw);
        _trigvol1.Write(bw);
        _trigvol2.Write(bw);
        _trigvol3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RecordedAnimationBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private CharInteger _version = new CharInteger();
      private CharInteger _rawAnimationData = new CharInteger();
      private CharInteger _unitControlDataVersion = new CharInteger();
      private Pad _unnamed;
      private ShortInteger _lengthOfAnimation = new ShortInteger();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Data _recordedAnimationEventStream = new Data();
public event System.EventHandler BlockNameChanged;
      public RecordedAnimationBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(1);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(4);
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
      public CharInteger Version {
        get {
          return this._version;
        }
        set {
          this._version = value;
        }
      }
      public CharInteger RawAnimationData {
        get {
          return this._rawAnimationData;
        }
        set {
          this._rawAnimationData = value;
        }
      }
      public CharInteger UnitControlDataVersion {
        get {
          return this._unitControlDataVersion;
        }
        set {
          this._unitControlDataVersion = value;
        }
      }
      public ShortInteger LengthOfAnimation {
        get {
          return this._lengthOfAnimation;
        }
        set {
          this._lengthOfAnimation = value;
        }
      }
      public Data RecordedAnimationEventStream {
        get {
          return this._recordedAnimationEventStream;
        }
        set {
          this._recordedAnimationEventStream = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _version.Read(reader);
        _rawAnimationData.Read(reader);
        _unitControlDataVersion.Read(reader);
        _unnamed.Read(reader);
        _lengthOfAnimation.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _recordedAnimationEventStream.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _recordedAnimationEventStream.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _version.Write(bw);
        _rawAnimationData.Write(bw);
        _unitControlDataVersion.Write(bw);
        _unnamed.Write(bw);
        _lengthOfAnimation.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _recordedAnimationEventStream.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _recordedAnimationEventStream.WriteBinary(writer);
      }
    }
    public class ScenarioNetgameFlagsBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private Enum _type = new Enum();
      private ShortInteger _teamIndex = new ShortInteger();
      private TagReference _weaponGroup = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioNetgameFlagsBlock() {
        this._unnamed = new Pad(112);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weaponGroup.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Angle Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger TeamIndex {
        get {
          return this._teamIndex;
        }
        set {
          this._teamIndex = value;
        }
      }
      public TagReference WeaponGroup {
        get {
          return this._weaponGroup;
        }
        set {
          this._weaponGroup = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _type.Read(reader);
        _teamIndex.Read(reader);
        _weaponGroup.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weaponGroup.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _type.Write(bw);
        _teamIndex.Write(bw);
        _weaponGroup.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weaponGroup.WriteString(writer);
      }
    }
    public class ScenarioNetgameEquipmentBlock : IBlock {
      private Flags _flags;
      private Enum _type0 = new Enum();
      private Enum _type1 = new Enum();
      private Enum _type2 = new Enum();
      private Enum _type3 = new Enum();
      private ShortInteger _teamIndex = new ShortInteger();
      private ShortInteger _spawnTimeInSecond = new ShortInteger();
      private Pad _unnamed;
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private TagReference _itemCollection = new TagReference();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioNetgameEquipmentBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(48);
        this._unnamed2 = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_itemCollection.Value);
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
      public Enum Type0 {
        get {
          return this._type0;
        }
        set {
          this._type0 = value;
        }
      }
      public Enum Type1 {
        get {
          return this._type1;
        }
        set {
          this._type1 = value;
        }
      }
      public Enum Type2 {
        get {
          return this._type2;
        }
        set {
          this._type2 = value;
        }
      }
      public Enum Type3 {
        get {
          return this._type3;
        }
        set {
          this._type3 = value;
        }
      }
      public ShortInteger TeamIndex {
        get {
          return this._teamIndex;
        }
        set {
          this._teamIndex = value;
        }
      }
      public ShortInteger SpawnTimeInSecond {
        get {
          return this._spawnTimeInSecond;
        }
        set {
          this._spawnTimeInSecond = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Angle Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public TagReference ItemCollection {
        get {
          return this._itemCollection;
        }
        set {
          this._itemCollection = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type0.Read(reader);
        _type1.Read(reader);
        _type2.Read(reader);
        _type3.Read(reader);
        _teamIndex.Read(reader);
        _spawnTimeInSecond.Read(reader);
        _unnamed.Read(reader);
        _position.Read(reader);
        _facing.Read(reader);
        _itemCollection.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _itemCollection.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type0.Write(bw);
        _type1.Write(bw);
        _type2.Write(bw);
        _type3.Write(bw);
        _teamIndex.Write(bw);
        _spawnTimeInSecond.Write(bw);
        _unnamed.Write(bw);
        _position.Write(bw);
        _facing.Write(bw);
        _itemCollection.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _itemCollection.WriteString(writer);
      }
    }
    public class ScenarioStartingEquipmentBlock : IBlock {
      private Flags _flags;
      private Enum _type0 = new Enum();
      private Enum _type1 = new Enum();
      private Enum _type2 = new Enum();
      private Enum _type3 = new Enum();
      private Pad _unnamed;
      private TagReference _itemCollection1 = new TagReference();
      private TagReference _itemCollection2 = new TagReference();
      private TagReference _itemCollection3 = new TagReference();
      private TagReference _itemCollection4 = new TagReference();
      private TagReference _itemCollection5 = new TagReference();
      private TagReference _itemCollection6 = new TagReference();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioStartingEquipmentBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(48);
        this._unnamed2 = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_itemCollection1.Value);
references.Add(_itemCollection2.Value);
references.Add(_itemCollection3.Value);
references.Add(_itemCollection4.Value);
references.Add(_itemCollection5.Value);
references.Add(_itemCollection6.Value);
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
      public Enum Type0 {
        get {
          return this._type0;
        }
        set {
          this._type0 = value;
        }
      }
      public Enum Type1 {
        get {
          return this._type1;
        }
        set {
          this._type1 = value;
        }
      }
      public Enum Type2 {
        get {
          return this._type2;
        }
        set {
          this._type2 = value;
        }
      }
      public Enum Type3 {
        get {
          return this._type3;
        }
        set {
          this._type3 = value;
        }
      }
      public TagReference ItemCollection1 {
        get {
          return this._itemCollection1;
        }
        set {
          this._itemCollection1 = value;
        }
      }
      public TagReference ItemCollection2 {
        get {
          return this._itemCollection2;
        }
        set {
          this._itemCollection2 = value;
        }
      }
      public TagReference ItemCollection3 {
        get {
          return this._itemCollection3;
        }
        set {
          this._itemCollection3 = value;
        }
      }
      public TagReference ItemCollection4 {
        get {
          return this._itemCollection4;
        }
        set {
          this._itemCollection4 = value;
        }
      }
      public TagReference ItemCollection5 {
        get {
          return this._itemCollection5;
        }
        set {
          this._itemCollection5 = value;
        }
      }
      public TagReference ItemCollection6 {
        get {
          return this._itemCollection6;
        }
        set {
          this._itemCollection6 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type0.Read(reader);
        _type1.Read(reader);
        _type2.Read(reader);
        _type3.Read(reader);
        _unnamed.Read(reader);
        _itemCollection1.Read(reader);
        _itemCollection2.Read(reader);
        _itemCollection3.Read(reader);
        _itemCollection4.Read(reader);
        _itemCollection5.Read(reader);
        _itemCollection6.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _itemCollection1.ReadString(reader);
        _itemCollection2.ReadString(reader);
        _itemCollection3.ReadString(reader);
        _itemCollection4.ReadString(reader);
        _itemCollection5.ReadString(reader);
        _itemCollection6.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type0.Write(bw);
        _type1.Write(bw);
        _type2.Write(bw);
        _type3.Write(bw);
        _unnamed.Write(bw);
        _itemCollection1.Write(bw);
        _itemCollection2.Write(bw);
        _itemCollection3.Write(bw);
        _itemCollection4.Write(bw);
        _itemCollection5.Write(bw);
        _itemCollection6.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _itemCollection1.WriteString(writer);
        _itemCollection2.WriteString(writer);
        _itemCollection3.WriteString(writer);
        _itemCollection4.WriteString(writer);
        _itemCollection5.WriteString(writer);
        _itemCollection6.WriteString(writer);
      }
    }
    public class ScenarioBspSwitchTriggerVolumeBlock : IBlock {
      private ShortBlockIndex _triggerVolume = new ShortBlockIndex();
      private ShortInteger _source = new ShortInteger();
      private ShortInteger _destination = new ShortInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioBspSwitchTriggerVolumeBlock() {
        this._unnamed = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public ShortBlockIndex TriggerVolume {
        get {
          return this._triggerVolume;
        }
        set {
          this._triggerVolume = value;
        }
      }
      public ShortInteger Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public ShortInteger Destination {
        get {
          return this._destination;
        }
        set {
          this._destination = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _triggerVolume.Read(reader);
        _source.Read(reader);
        _destination.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _triggerVolume.Write(bw);
        _source.Write(bw);
        _destination.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioDecalsBlock : IBlock {
      private ShortBlockIndex _decalType = new ShortBlockIndex();
      private CharInteger _ya = new CharInteger();
      private CharInteger _pitc = new CharInteger();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScenarioDecalsBlock() {
if (this._decalType is System.ComponentModel.INotifyPropertyChanged)
  (this._decalType as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _decalType.ToString();
        }
      }
      public ShortBlockIndex DecalType {
        get {
          return this._decalType;
        }
        set {
          this._decalType = value;
        }
      }
      public CharInteger Ya {
        get {
          return this._ya;
        }
        set {
          this._ya = value;
        }
      }
      public CharInteger Pitc {
        get {
          return this._pitc;
        }
        set {
          this._pitc = value;
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decalType.Read(reader);
        _ya.Read(reader);
        _pitc.Read(reader);
        _position.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decalType.Write(bw);
        _ya.Write(bw);
        _pitc.Write(bw);
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioDecalPaletteBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioDecalPaletteBlock() {
if (this._reference is System.ComponentModel.INotifyPropertyChanged)
  (this._reference as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_reference.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _reference.ToString();
        }
      }
      public TagReference Reference {
        get {
          return this._reference;
        }
        set {
          this._reference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _reference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _reference.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _reference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _reference.WriteString(writer);
      }
    }
    public class ScenarioDetailObjectCollectionPaletteBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public ScenarioDetailObjectCollectionPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(32);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_name.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public TagReference Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ActorPaletteBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ActorPaletteBlock() {
if (this._reference is System.ComponentModel.INotifyPropertyChanged)
  (this._reference as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_reference.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _reference.ToString();
        }
      }
      public TagReference Reference {
        get {
          return this._reference;
        }
        set {
          this._reference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _reference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _reference.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _reference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _reference.WriteString(writer);
      }
    }
    public class EncounterBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Enum _teamIndex = new Enum();
      private Skip _unnamed;
      private Enum _searchBehavior = new Enum();
      private ShortInteger _manualBspIndex = new ShortInteger();
      private RealBounds _respawnDelay = new RealBounds();
      private Pad _unnamed2;
      private Block _squads = new Block();
      private Block _platoons = new Block();
      private Block _firingPositions = new Block();
      private Block _playerStartingLocations = new Block();
      public BlockCollection<SquadsBlock> _squadsList = new BlockCollection<SquadsBlock>();
      public BlockCollection<PlatoonsBlock> _platoonsList = new BlockCollection<PlatoonsBlock>();
      public BlockCollection<FiringPositionsBlock> _firingPositionsList = new BlockCollection<FiringPositionsBlock>();
      public BlockCollection<ScenarioPlayersBlock> _playerStartingLocationsList = new BlockCollection<ScenarioPlayersBlock>();
public event System.EventHandler BlockNameChanged;
      public EncounterBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Skip(2);
        this._unnamed2 = new Pad(76);
      }
      public BlockCollection<SquadsBlock> Squads {
        get {
          return this._squadsList;
        }
      }
      public BlockCollection<PlatoonsBlock> Platoons {
        get {
          return this._platoonsList;
        }
      }
      public BlockCollection<FiringPositionsBlock> FiringPositions {
        get {
          return this._firingPositionsList;
        }
      }
      public BlockCollection<ScenarioPlayersBlock> PlayerStartingLocations {
        get {
          return this._playerStartingLocationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Squads.BlockCount; x++)
{
  IBlock block = Squads.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Platoons.BlockCount; x++)
{
  IBlock block = Platoons.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FiringPositions.BlockCount; x++)
{
  IBlock block = FiringPositions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlayerStartingLocations.BlockCount; x++)
{
  IBlock block = PlayerStartingLocations.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum TeamIndex {
        get {
          return this._teamIndex;
        }
        set {
          this._teamIndex = value;
        }
      }
      public Enum SearchBehavior {
        get {
          return this._searchBehavior;
        }
        set {
          this._searchBehavior = value;
        }
      }
      public ShortInteger ManualBspIndex {
        get {
          return this._manualBspIndex;
        }
        set {
          this._manualBspIndex = value;
        }
      }
      public RealBounds RespawnDelay {
        get {
          return this._respawnDelay;
        }
        set {
          this._respawnDelay = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _teamIndex.Read(reader);
        _unnamed.Read(reader);
        _searchBehavior.Read(reader);
        _manualBspIndex.Read(reader);
        _respawnDelay.Read(reader);
        _unnamed2.Read(reader);
        _squads.Read(reader);
        _platoons.Read(reader);
        _firingPositions.Read(reader);
        _playerStartingLocations.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads.Add(new SquadsBlock());
          Squads[x].Read(reader);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].ReadChildData(reader);
        }
        for (x = 0; (x < _platoons.Count); x = (x + 1)) {
          Platoons.Add(new PlatoonsBlock());
          Platoons[x].Read(reader);
        }
        for (x = 0; (x < _platoons.Count); x = (x + 1)) {
          Platoons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions.Add(new FiringPositionsBlock());
          FiringPositions[x].Read(reader);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations.Add(new ScenarioPlayersBlock());
          PlayerStartingLocations[x].Read(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _teamIndex.Write(bw);
        _unnamed.Write(bw);
        _searchBehavior.Write(bw);
        _manualBspIndex.Write(bw);
        _respawnDelay.Write(bw);
        _unnamed2.Write(bw);
_squads.Count = Squads.Count;
        _squads.Write(bw);
_platoons.Count = Platoons.Count;
        _platoons.Write(bw);
_firingPositions.Count = FiringPositions.Count;
        _firingPositions.Write(bw);
_playerStartingLocations.Count = PlayerStartingLocations.Count;
        _playerStartingLocations.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].Write(writer);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].WriteChildData(writer);
        }
        for (x = 0; (x < _platoons.Count); x = (x + 1)) {
          Platoons[x].Write(writer);
        }
        for (x = 0; (x < _platoons.Count); x = (x + 1)) {
          Platoons[x].WriteChildData(writer);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].Write(writer);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].Write(writer);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].WriteChildData(writer);
        }
      }
    }
    public class SquadsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _actorType = new ShortBlockIndex();
      private ShortBlockIndex _platoon = new ShortBlockIndex();
      private Enum _initialState = new Enum();
      private Enum _returnState = new Enum();
      private Flags _flags;
      private Enum _uniqueLeaderType = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
      private Pad _unnamed3;
      private ShortBlockIndex _maneuverToSquad = new ShortBlockIndex();
      private Real _squadDelayTime = new Real();
      private Flags _attacking;
      private Flags _attackingSearch;
      private Flags _attackingGuard;
      private Flags _defending;
      private Flags _defendingSearch;
      private Flags _defendingGuard;
      private Flags _pursuing;
      private Pad _unnamed4;
      private Pad _unnamed5;
      private ShortInteger _normalDiffCount = new ShortInteger();
      private ShortInteger _insaneDiffCount = new ShortInteger();
      private Enum _majorUpgrade = new Enum();
      private Pad _unnamed6;
      private ShortInteger _respawnMinActors = new ShortInteger();
      private ShortInteger _respawnMaxActors = new ShortInteger();
      private ShortInteger _respawnTotal = new ShortInteger();
      private Pad _unnamed7;
      private RealBounds _respawnDelay = new RealBounds();
      private Pad _unnamed8;
      private Block _movePositions = new Block();
      private Block _startingLocations = new Block();
      private Pad _unnamed9;
      public BlockCollection<MovePositionsBlock> _movePositionsList = new BlockCollection<MovePositionsBlock>();
      public BlockCollection<ActorStartingLocationsBlock> _startingLocationsList = new BlockCollection<ActorStartingLocationsBlock>();
public event System.EventHandler BlockNameChanged;
      public SquadsBlock() {
        this._flags = new Flags(4);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(28);
        this._unnamed3 = new Pad(2);
        this._attacking = new Flags(4);
        this._attackingSearch = new Flags(4);
        this._attackingGuard = new Flags(4);
        this._defending = new Flags(4);
        this._defendingSearch = new Flags(4);
        this._defendingGuard = new Flags(4);
        this._pursuing = new Flags(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(8);
        this._unnamed6 = new Pad(2);
        this._unnamed7 = new Pad(2);
        this._unnamed8 = new Pad(48);
        this._unnamed9 = new Pad(12);
      }
      public BlockCollection<MovePositionsBlock> MovePositions {
        get {
          return this._movePositionsList;
        }
      }
      public BlockCollection<ActorStartingLocationsBlock> StartingLocations {
        get {
          return this._startingLocationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<MovePositions.BlockCount; x++)
{
  IBlock block = MovePositions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StartingLocations.BlockCount; x++)
{
  IBlock block = StartingLocations.GetBlock(x);
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public ShortBlockIndex ActorType {
        get {
          return this._actorType;
        }
        set {
          this._actorType = value;
        }
      }
      public ShortBlockIndex Platoon {
        get {
          return this._platoon;
        }
        set {
          this._platoon = value;
        }
      }
      public Enum InitialState {
        get {
          return this._initialState;
        }
        set {
          this._initialState = value;
        }
      }
      public Enum ReturnState {
        get {
          return this._returnState;
        }
        set {
          this._returnState = value;
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
      public Enum UniqueLeaderType {
        get {
          return this._uniqueLeaderType;
        }
        set {
          this._uniqueLeaderType = value;
        }
      }
      public ShortBlockIndex ManeuverToSquad {
        get {
          return this._maneuverToSquad;
        }
        set {
          this._maneuverToSquad = value;
        }
      }
      public Real SquadDelayTime {
        get {
          return this._squadDelayTime;
        }
        set {
          this._squadDelayTime = value;
        }
      }
      public Flags Attacking {
        get {
          return this._attacking;
        }
        set {
          this._attacking = value;
        }
      }
      public Flags AttackingSearch {
        get {
          return this._attackingSearch;
        }
        set {
          this._attackingSearch = value;
        }
      }
      public Flags AttackingGuard {
        get {
          return this._attackingGuard;
        }
        set {
          this._attackingGuard = value;
        }
      }
      public Flags Defending {
        get {
          return this._defending;
        }
        set {
          this._defending = value;
        }
      }
      public Flags DefendingSearch {
        get {
          return this._defendingSearch;
        }
        set {
          this._defendingSearch = value;
        }
      }
      public Flags DefendingGuard {
        get {
          return this._defendingGuard;
        }
        set {
          this._defendingGuard = value;
        }
      }
      public Flags Pursuing {
        get {
          return this._pursuing;
        }
        set {
          this._pursuing = value;
        }
      }
      public ShortInteger NormalDiffCount {
        get {
          return this._normalDiffCount;
        }
        set {
          this._normalDiffCount = value;
        }
      }
      public ShortInteger InsaneDiffCount {
        get {
          return this._insaneDiffCount;
        }
        set {
          this._insaneDiffCount = value;
        }
      }
      public Enum MajorUpgrade {
        get {
          return this._majorUpgrade;
        }
        set {
          this._majorUpgrade = value;
        }
      }
      public ShortInteger RespawnMinActors {
        get {
          return this._respawnMinActors;
        }
        set {
          this._respawnMinActors = value;
        }
      }
      public ShortInteger RespawnMaxActors {
        get {
          return this._respawnMaxActors;
        }
        set {
          this._respawnMaxActors = value;
        }
      }
      public ShortInteger RespawnTotal {
        get {
          return this._respawnTotal;
        }
        set {
          this._respawnTotal = value;
        }
      }
      public RealBounds RespawnDelay {
        get {
          return this._respawnDelay;
        }
        set {
          this._respawnDelay = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _actorType.Read(reader);
        _platoon.Read(reader);
        _initialState.Read(reader);
        _returnState.Read(reader);
        _flags.Read(reader);
        _uniqueLeaderType.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _maneuverToSquad.Read(reader);
        _squadDelayTime.Read(reader);
        _attacking.Read(reader);
        _attackingSearch.Read(reader);
        _attackingGuard.Read(reader);
        _defending.Read(reader);
        _defendingSearch.Read(reader);
        _defendingGuard.Read(reader);
        _pursuing.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _normalDiffCount.Read(reader);
        _insaneDiffCount.Read(reader);
        _majorUpgrade.Read(reader);
        _unnamed6.Read(reader);
        _respawnMinActors.Read(reader);
        _respawnMaxActors.Read(reader);
        _respawnTotal.Read(reader);
        _unnamed7.Read(reader);
        _respawnDelay.Read(reader);
        _unnamed8.Read(reader);
        _movePositions.Read(reader);
        _startingLocations.Read(reader);
        _unnamed9.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _movePositions.Count); x = (x + 1)) {
          MovePositions.Add(new MovePositionsBlock());
          MovePositions[x].Read(reader);
        }
        for (x = 0; (x < _movePositions.Count); x = (x + 1)) {
          MovePositions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations.Add(new ActorStartingLocationsBlock());
          StartingLocations[x].Read(reader);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _actorType.Write(bw);
        _platoon.Write(bw);
        _initialState.Write(bw);
        _returnState.Write(bw);
        _flags.Write(bw);
        _uniqueLeaderType.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _maneuverToSquad.Write(bw);
        _squadDelayTime.Write(bw);
        _attacking.Write(bw);
        _attackingSearch.Write(bw);
        _attackingGuard.Write(bw);
        _defending.Write(bw);
        _defendingSearch.Write(bw);
        _defendingGuard.Write(bw);
        _pursuing.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _normalDiffCount.Write(bw);
        _insaneDiffCount.Write(bw);
        _majorUpgrade.Write(bw);
        _unnamed6.Write(bw);
        _respawnMinActors.Write(bw);
        _respawnMaxActors.Write(bw);
        _respawnTotal.Write(bw);
        _unnamed7.Write(bw);
        _respawnDelay.Write(bw);
        _unnamed8.Write(bw);
_movePositions.Count = MovePositions.Count;
        _movePositions.Write(bw);
_startingLocations.Count = StartingLocations.Count;
        _startingLocations.Write(bw);
        _unnamed9.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _movePositions.Count); x = (x + 1)) {
          MovePositions[x].Write(writer);
        }
        for (x = 0; (x < _movePositions.Count); x = (x + 1)) {
          MovePositions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].Write(writer);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].WriteChildData(writer);
        }
      }
    }
    public class MovePositionsBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private Real _weight = new Real();
      private RealBounds _time = new RealBounds();
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private CharInteger _sequenceID = new CharInteger();
      private Pad _unnamed;
      private Pad _unnamed2;
      private LongInteger _surfaceIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public MovePositionsBlock() {
        this._unnamed = new Pad(1);
        this._unnamed2 = new Pad(44);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Angle Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public Real Weight {
        get {
          return this._weight;
        }
        set {
          this._weight = value;
        }
      }
      public RealBounds Time {
        get {
          return this._time;
        }
        set {
          this._time = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public CharInteger SequenceID {
        get {
          return this._sequenceID;
        }
        set {
          this._sequenceID = value;
        }
      }
      public LongInteger SurfaceIndex {
        get {
          return this._surfaceIndex;
        }
        set {
          this._surfaceIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _weight.Read(reader);
        _time.Read(reader);
        _animation.Read(reader);
        _sequenceID.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _surfaceIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _weight.Write(bw);
        _time.Write(bw);
        _animation.Write(bw);
        _sequenceID.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _surfaceIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ActorStartingLocationsBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private Pad _unnamed;
      private CharInteger _sequenceID = new CharInteger();
      private Flags _flags;
      private Enum _returnState = new Enum();
      private Enum _initialState = new Enum();
      private ShortBlockIndex _actorType = new ShortBlockIndex();
      private ShortBlockIndex _commandList = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public ActorStartingLocationsBlock() {
        this._unnamed = new Pad(2);
        this._flags = new Flags(1);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Angle Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public CharInteger SequenceID {
        get {
          return this._sequenceID;
        }
        set {
          this._sequenceID = value;
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
      public Enum ReturnState {
        get {
          return this._returnState;
        }
        set {
          this._returnState = value;
        }
      }
      public Enum InitialState {
        get {
          return this._initialState;
        }
        set {
          this._initialState = value;
        }
      }
      public ShortBlockIndex ActorType {
        get {
          return this._actorType;
        }
        set {
          this._actorType = value;
        }
      }
      public ShortBlockIndex CommandList {
        get {
          return this._commandList;
        }
        set {
          this._commandList = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _unnamed.Read(reader);
        _sequenceID.Read(reader);
        _flags.Read(reader);
        _returnState.Read(reader);
        _initialState.Read(reader);
        _actorType.Read(reader);
        _commandList.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _unnamed.Write(bw);
        _sequenceID.Write(bw);
        _flags.Write(bw);
        _returnState.Write(bw);
        _initialState.Write(bw);
        _actorType.Write(bw);
        _commandList.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PlatoonsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private Enum _changeAttackingdefendingStateWhen = new Enum();
      private ShortBlockIndex _happensTo = new ShortBlockIndex();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private Enum _maneuverWhen = new Enum();
      private ShortBlockIndex _happensTo2 = new ShortBlockIndex();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private Pad _unnamed6;
      private Pad _unnamed7;
public event System.EventHandler BlockNameChanged;
      public PlatoonsBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(12);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(64);
        this._unnamed7 = new Pad(36);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Enum ChangeAttackingdefendingStateWhen {
        get {
          return this._changeAttackingdefendingStateWhen;
        }
        set {
          this._changeAttackingdefendingStateWhen = value;
        }
      }
      public ShortBlockIndex HappensTo {
        get {
          return this._happensTo;
        }
        set {
          this._happensTo = value;
        }
      }
      public Enum ManeuverWhen {
        get {
          return this._maneuverWhen;
        }
        set {
          this._maneuverWhen = value;
        }
      }
      public ShortBlockIndex HappensTo2 {
        get {
          return this._happensTo2;
        }
        set {
          this._happensTo2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _changeAttackingdefendingStateWhen.Read(reader);
        _happensTo.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _maneuverWhen.Read(reader);
        _happensTo2.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _changeAttackingdefendingStateWhen.Write(bw);
        _happensTo.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _maneuverWhen.Write(bw);
        _happensTo2.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class FiringPositionsBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Enum _groupIndex = new Enum();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public FiringPositionsBlock() {
        this._unnamed = new Pad(10);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Enum GroupIndex {
        get {
          return this._groupIndex;
        }
        set {
          this._groupIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _groupIndex.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _groupIndex.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiCommandListBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private ShortInteger _manualBspIndex = new ShortInteger();
      private Pad _unnamed2;
      private Block _commands = new Block();
      private Block _points = new Block();
      private Pad _unnamed3;
      public BlockCollection<AiCommandBlock> _commandsList = new BlockCollection<AiCommandBlock>();
      public BlockCollection<AiCommandPointBlock> _pointsList = new BlockCollection<AiCommandPointBlock>();
public event System.EventHandler BlockNameChanged;
      public AiCommandListBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed = new Pad(8);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(24);
      }
      public BlockCollection<AiCommandBlock> Commands {
        get {
          return this._commandsList;
        }
      }
      public BlockCollection<AiCommandPointBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Commands.BlockCount; x++)
{
  IBlock block = Commands.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Points.BlockCount; x++)
{
  IBlock block = Points.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public ShortInteger ManualBspIndex {
        get {
          return this._manualBspIndex;
        }
        set {
          this._manualBspIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _manualBspIndex.Read(reader);
        _unnamed2.Read(reader);
        _commands.Read(reader);
        _points.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _commands.Count); x = (x + 1)) {
          Commands.Add(new AiCommandBlock());
          Commands[x].Read(reader);
        }
        for (x = 0; (x < _commands.Count); x = (x + 1)) {
          Commands[x].ReadChildData(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new AiCommandPointBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _manualBspIndex.Write(bw);
        _unnamed2.Write(bw);
_commands.Count = Commands.Count;
        _commands.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _commands.Count); x = (x + 1)) {
          Commands[x].Write(writer);
        }
        for (x = 0; (x < _commands.Count); x = (x + 1)) {
          Commands[x].WriteChildData(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class AiCommandBlock : IBlock {
      private Enum _atomType = new Enum();
      private ShortInteger _atomModifier = new ShortInteger();
      private Real _parameter1 = new Real();
      private Real _parameter2 = new Real();
      private ShortBlockIndex _point1 = new ShortBlockIndex();
      private ShortBlockIndex _point2 = new ShortBlockIndex();
      private ShortBlockIndex _animation = new ShortBlockIndex();
      private ShortBlockIndex _script = new ShortBlockIndex();
      private ShortBlockIndex _recording = new ShortBlockIndex();
      private ShortBlockIndex _command = new ShortBlockIndex();
      private ShortBlockIndex _objectName = new ShortBlockIndex();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AiCommandBlock() {
        this._unnamed = new Pad(6);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public Enum AtomType {
        get {
          return this._atomType;
        }
        set {
          this._atomType = value;
        }
      }
      public ShortInteger AtomModifier {
        get {
          return this._atomModifier;
        }
        set {
          this._atomModifier = value;
        }
      }
      public Real Parameter1 {
        get {
          return this._parameter1;
        }
        set {
          this._parameter1 = value;
        }
      }
      public Real Parameter2 {
        get {
          return this._parameter2;
        }
        set {
          this._parameter2 = value;
        }
      }
      public ShortBlockIndex Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public ShortBlockIndex Point2 {
        get {
          return this._point2;
        }
        set {
          this._point2 = value;
        }
      }
      public ShortBlockIndex Animation {
        get {
          return this._animation;
        }
        set {
          this._animation = value;
        }
      }
      public ShortBlockIndex Script {
        get {
          return this._script;
        }
        set {
          this._script = value;
        }
      }
      public ShortBlockIndex Recording {
        get {
          return this._recording;
        }
        set {
          this._recording = value;
        }
      }
      public ShortBlockIndex Command {
        get {
          return this._command;
        }
        set {
          this._command = value;
        }
      }
      public ShortBlockIndex ObjectName {
        get {
          return this._objectName;
        }
        set {
          this._objectName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _atomType.Read(reader);
        _atomModifier.Read(reader);
        _parameter1.Read(reader);
        _parameter2.Read(reader);
        _point1.Read(reader);
        _point2.Read(reader);
        _animation.Read(reader);
        _script.Read(reader);
        _recording.Read(reader);
        _command.Read(reader);
        _objectName.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _atomType.Write(bw);
        _atomModifier.Write(bw);
        _parameter1.Write(bw);
        _parameter2.Write(bw);
        _point1.Write(bw);
        _point2.Write(bw);
        _animation.Write(bw);
        _script.Write(bw);
        _recording.Write(bw);
        _command.Write(bw);
        _objectName.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiCommandPointBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AiCommandPointBlock() {
        this._unnamed = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiAnimationReferenceBlock : IBlock {
      private FixedLengthString _animationName = new FixedLengthString();
      private TagReference _animationGraph = new TagReference();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AiAnimationReferenceBlock() {
if (this._animationName is System.ComponentModel.INotifyPropertyChanged)
  (this._animationName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_animationGraph.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _animationName.ToString();
        }
      }
      public FixedLengthString AnimationName {
        get {
          return this._animationName;
        }
        set {
          this._animationName = value;
        }
      }
      public TagReference AnimationGraph {
        get {
          return this._animationGraph;
        }
        set {
          this._animationGraph = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _animationName.Read(reader);
        _animationGraph.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _animationGraph.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _animationName.Write(bw);
        _animationGraph.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _animationGraph.WriteString(writer);
      }
    }
    public class AiScriptReferenceBlock : IBlock {
      private FixedLengthString _scriptName = new FixedLengthString();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AiScriptReferenceBlock() {
if (this._scriptName is System.ComponentModel.INotifyPropertyChanged)
  (this._scriptName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _scriptName.ToString();
        }
      }
      public FixedLengthString ScriptName {
        get {
          return this._scriptName;
        }
        set {
          this._scriptName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _scriptName.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scriptName.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiRecordingReferenceBlock : IBlock {
      private FixedLengthString _recordingName = new FixedLengthString();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public AiRecordingReferenceBlock() {
if (this._recordingName is System.ComponentModel.INotifyPropertyChanged)
  (this._recordingName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _recordingName.ToString();
        }
      }
      public FixedLengthString RecordingName {
        get {
          return this._recordingName;
        }
        set {
          this._recordingName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _recordingName.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _recordingName.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiConversationBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed;
      private Real _triggerDistance = new Real();
      private Real _ru = new Real();
      private Pad _unnamed2;
      private Block _participants = new Block();
      private Block _lines = new Block();
      private Pad _unnamed3;
      public BlockCollection<AiConversationParticipantBlock> _participantsList = new BlockCollection<AiConversationParticipantBlock>();
      public BlockCollection<AiConversationLineBlock> _linesList = new BlockCollection<AiConversationLineBlock>();
public event System.EventHandler BlockNameChanged;
      public AiConversationBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(36);
        this._unnamed3 = new Pad(12);
      }
      public BlockCollection<AiConversationParticipantBlock> Participants {
        get {
          return this._participantsList;
        }
      }
      public BlockCollection<AiConversationLineBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Participants.BlockCount; x++)
{
  IBlock block = Participants.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Lines.BlockCount; x++)
{
  IBlock block = Lines.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public Real TriggerDistance {
        get {
          return this._triggerDistance;
        }
        set {
          this._triggerDistance = value;
        }
      }
      public Real Ru {
        get {
          return this._ru;
        }
        set {
          this._ru = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed.Read(reader);
        _triggerDistance.Read(reader);
        _ru.Read(reader);
        _unnamed2.Read(reader);
        _participants.Read(reader);
        _lines.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants.Add(new AiConversationParticipantBlock());
          Participants[x].Read(reader);
        }
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new AiConversationLineBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed.Write(bw);
        _triggerDistance.Write(bw);
        _ru.Write(bw);
        _unnamed2.Write(bw);
_participants.Count = Participants.Count;
        _participants.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants[x].Write(writer);
        }
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].Write(writer);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].WriteChildData(writer);
        }
      }
    }
    public class AiConversationParticipantBlock : IBlock {
      private Pad _unnamed;
      private Flags _flags;
      private Enum _selectionType = new Enum();
      private Enum _actorType = new Enum();
      private ShortBlockIndex _useThisObject = new ShortBlockIndex();
      private ShortBlockIndex _setNewName = new ShortBlockIndex();
      private Pad _unnamed2;
      private Pad _unnamed3;
      private FixedLengthString _encounterName = new FixedLengthString();
      private Pad _unnamed4;
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public AiConversationParticipantBlock() {
        this._unnamed = new Pad(2);
        this._flags = new Flags(2);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(12);
        this._unnamed4 = new Pad(4);
        this._unnamed5 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Enum SelectionType {
        get {
          return this._selectionType;
        }
        set {
          this._selectionType = value;
        }
      }
      public Enum ActorType {
        get {
          return this._actorType;
        }
        set {
          this._actorType = value;
        }
      }
      public ShortBlockIndex UseThisObject {
        get {
          return this._useThisObject;
        }
        set {
          this._useThisObject = value;
        }
      }
      public ShortBlockIndex SetNewName {
        get {
          return this._setNewName;
        }
        set {
          this._setNewName = value;
        }
      }
      public FixedLengthString EncounterName {
        get {
          return this._encounterName;
        }
        set {
          this._encounterName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _flags.Read(reader);
        _selectionType.Read(reader);
        _actorType.Read(reader);
        _useThisObject.Read(reader);
        _setNewName.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _encounterName.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _flags.Write(bw);
        _selectionType.Write(bw);
        _actorType.Write(bw);
        _useThisObject.Write(bw);
        _setNewName.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _encounterName.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiConversationLineBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _participant = new ShortBlockIndex();
      private Enum _addressee = new Enum();
      private ShortBlockIndex _addresseeParticipant = new ShortBlockIndex();
      private Pad _unnamed;
      private Real _lineDelayTime = new Real();
      private Pad _unnamed2;
      private TagReference _variant1 = new TagReference();
      private TagReference _variant2 = new TagReference();
      private TagReference _variant3 = new TagReference();
      private TagReference _variant4 = new TagReference();
      private TagReference _variant5 = new TagReference();
      private TagReference _variant6 = new TagReference();
public event System.EventHandler BlockNameChanged;
      public AiConversationLineBlock() {
        this._flags = new Flags(2);
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(12);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_variant1.Value);
references.Add(_variant2.Value);
references.Add(_variant3.Value);
references.Add(_variant4.Value);
references.Add(_variant5.Value);
references.Add(_variant6.Value);
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
      public ShortBlockIndex Participant {
        get {
          return this._participant;
        }
        set {
          this._participant = value;
        }
      }
      public Enum Addressee {
        get {
          return this._addressee;
        }
        set {
          this._addressee = value;
        }
      }
      public ShortBlockIndex AddresseeParticipant {
        get {
          return this._addresseeParticipant;
        }
        set {
          this._addresseeParticipant = value;
        }
      }
      public Real LineDelayTime {
        get {
          return this._lineDelayTime;
        }
        set {
          this._lineDelayTime = value;
        }
      }
      public TagReference Variant1 {
        get {
          return this._variant1;
        }
        set {
          this._variant1 = value;
        }
      }
      public TagReference Variant2 {
        get {
          return this._variant2;
        }
        set {
          this._variant2 = value;
        }
      }
      public TagReference Variant3 {
        get {
          return this._variant3;
        }
        set {
          this._variant3 = value;
        }
      }
      public TagReference Variant4 {
        get {
          return this._variant4;
        }
        set {
          this._variant4 = value;
        }
      }
      public TagReference Variant5 {
        get {
          return this._variant5;
        }
        set {
          this._variant5 = value;
        }
      }
      public TagReference Variant6 {
        get {
          return this._variant6;
        }
        set {
          this._variant6 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _participant.Read(reader);
        _addressee.Read(reader);
        _addresseeParticipant.Read(reader);
        _unnamed.Read(reader);
        _lineDelayTime.Read(reader);
        _unnamed2.Read(reader);
        _variant1.Read(reader);
        _variant2.Read(reader);
        _variant3.Read(reader);
        _variant4.Read(reader);
        _variant5.Read(reader);
        _variant6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variant1.ReadString(reader);
        _variant2.ReadString(reader);
        _variant3.ReadString(reader);
        _variant4.ReadString(reader);
        _variant5.ReadString(reader);
        _variant6.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _participant.Write(bw);
        _addressee.Write(bw);
        _addresseeParticipant.Write(bw);
        _unnamed.Write(bw);
        _lineDelayTime.Write(bw);
        _unnamed2.Write(bw);
        _variant1.Write(bw);
        _variant2.Write(bw);
        _variant3.Write(bw);
        _variant4.Write(bw);
        _variant5.Write(bw);
        _variant6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variant1.WriteString(writer);
        _variant2.WriteString(writer);
        _variant3.WriteString(writer);
        _variant4.WriteString(writer);
        _variant5.WriteString(writer);
        _variant6.WriteString(writer);
      }
    }
    public class HsScriptsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _scriptType = new Enum();
      private Enum _returnType = new Enum();
      private LongInteger _rootExpressionIndex = new LongInteger();
      private Pad _unnamed;
public event System.EventHandler BlockNameChanged;
      public HsScriptsBlock() {
        this._unnamed = new Pad(52);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Enum ScriptType {
        get {
          return this._scriptType;
        }
        set {
          this._scriptType = value;
        }
      }
      public Enum ReturnType {
        get {
          return this._returnType;
        }
        set {
          this._returnType = value;
        }
      }
      public LongInteger RootExpressionIndex {
        get {
          return this._rootExpressionIndex;
        }
        set {
          this._rootExpressionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _scriptType.Read(reader);
        _returnType.Read(reader);
        _rootExpressionIndex.Read(reader);
        _unnamed.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _scriptType.Write(bw);
        _returnType.Write(bw);
        _rootExpressionIndex.Write(bw);
        _unnamed.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsGlobalsBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _type = new Enum();
      private Pad _unnamed;
      private Pad _unnamed2;
      private LongInteger _initializationExpressionIndex = new LongInteger();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public HsGlobalsBlock() {
        this._unnamed = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public LongInteger InitializationExpressionIndex {
        get {
          return this._initializationExpressionIndex;
        }
        set {
          this._initializationExpressionIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _type.Read(reader);
        _unnamed.Read(reader);
        _unnamed2.Read(reader);
        _initializationExpressionIndex.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _unnamed.Write(bw);
        _unnamed2.Write(bw);
        _initializationExpressionIndex.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsReferencesBlock : IBlock {
      private Pad _unnamed;
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public HsReferencesBlock() {
if (this._reference is System.ComponentModel.INotifyPropertyChanged)
  (this._reference as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_reference.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _reference.ToString();
        }
      }
      public TagReference Reference {
        get {
          return this._reference;
        }
        set {
          this._reference = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _reference.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _reference.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _reference.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _reference.WriteString(writer);
      }
    }
    public class HsSourceFilesBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Data _source = new Data();
public event System.EventHandler BlockNameChanged;
      public HsSourceFilesBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Data Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _source.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _source.ReadBinary(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _source.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _source.WriteBinary(writer);
      }
    }
    public class ScenarioCutsceneFlagBlock : IBlock {
      private Pad _unnamed;
      private FixedLengthString _name = new FixedLengthString();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles2D _facing = new RealEulerAngles2D();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneFlagBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(36);
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles2D Facing {
        get {
          return this._facing;
        }
        set {
          this._facing = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _name.Read(reader);
        _position.Read(reader);
        _facing.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _name.Write(bw);
        _position.Write(bw);
        _facing.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCutsceneCameraPointBlock : IBlock {
      private Pad _unnamed;
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed2;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _orientation = new RealEulerAngles3D();
      private Angle _fieldOfView = new Angle();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneCameraPointBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(36);
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles3D Orientation {
        get {
          return this._orientation;
        }
        set {
          this._orientation = value;
        }
      }
      public Angle FieldOfView {
        get {
          return this._fieldOfView;
        }
        set {
          this._fieldOfView = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _name.Read(reader);
        _unnamed2.Read(reader);
        _position.Read(reader);
        _orientation.Read(reader);
        _fieldOfView.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _name.Write(bw);
        _unnamed2.Write(bw);
        _position.Write(bw);
        _orientation.Write(bw);
        _fieldOfView.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCutsceneTitleBlock : IBlock {
      private Pad _unnamed;
      private FixedLengthString _name = new FixedLengthString();
      private Pad _unnamed2;
      private Rectangle2D _textBoundsOnScreen = new Rectangle2D();
      private ShortInteger _stringIndex = new ShortInteger();
      private Pad _unnamed3;
      private Enum _justification = new Enum();
      private Pad _unnamed4;
      private Pad _unnamed5;
      private ARGBColor _textColor = new ARGBColor();
      private ARGBColor _shadowColor = new ARGBColor();
      private Real _fadeInTimeSeconds = new Real();
      private Real _upTimeSeconds = new Real();
      private Real _fadeOutTimeSeconds = new Real();
      private Pad _unnamed6;
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneTitleBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(4);
        this._unnamed6 = new Pad(16);
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
      public Rectangle2D TextBoundsOnScreen {
        get {
          return this._textBoundsOnScreen;
        }
        set {
          this._textBoundsOnScreen = value;
        }
      }
      public ShortInteger StringIndex {
        get {
          return this._stringIndex;
        }
        set {
          this._stringIndex = value;
        }
      }
      public Enum Justification {
        get {
          return this._justification;
        }
        set {
          this._justification = value;
        }
      }
      public ARGBColor TextColor {
        get {
          return this._textColor;
        }
        set {
          this._textColor = value;
        }
      }
      public ARGBColor ShadowColor {
        get {
          return this._shadowColor;
        }
        set {
          this._shadowColor = value;
        }
      }
      public Real FadeInTimeSeconds {
        get {
          return this._fadeInTimeSeconds;
        }
        set {
          this._fadeInTimeSeconds = value;
        }
      }
      public Real UpTimeSeconds {
        get {
          return this._upTimeSeconds;
        }
        set {
          this._upTimeSeconds = value;
        }
      }
      public Real FadeOutTimeSeconds {
        get {
          return this._fadeOutTimeSeconds;
        }
        set {
          this._fadeOutTimeSeconds = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _name.Read(reader);
        _unnamed2.Read(reader);
        _textBoundsOnScreen.Read(reader);
        _stringIndex.Read(reader);
        _unnamed3.Read(reader);
        _justification.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _textColor.Read(reader);
        _shadowColor.Read(reader);
        _fadeInTimeSeconds.Read(reader);
        _upTimeSeconds.Read(reader);
        _fadeOutTimeSeconds.Read(reader);
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _name.Write(bw);
        _unnamed2.Write(bw);
        _textBoundsOnScreen.Write(bw);
        _stringIndex.Write(bw);
        _unnamed3.Write(bw);
        _justification.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _textColor.Write(bw);
        _shadowColor.Write(bw);
        _fadeInTimeSeconds.Write(bw);
        _upTimeSeconds.Write(bw);
        _fadeOutTimeSeconds.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioStructureBspsBlock : IBlock {
      private Pad _unnamed;
      private TagReference _structureBsp = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioStructureBspsBlock() {
if (this._structureBsp is System.ComponentModel.INotifyPropertyChanged)
  (this._structureBsp as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed = new Pad(16);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_structureBsp.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _structureBsp.ToString();
        }
      }
      public TagReference StructureBsp {
        get {
          return this._structureBsp;
        }
        set {
          this._structureBsp = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed.Read(reader);
        _structureBsp.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _structureBsp.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed.Write(bw);
        _structureBsp.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _structureBsp.WriteString(writer);
      }
    }
  }
}
