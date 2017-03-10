// -------------------------------------------------
// Prometheus Tag Library - Halo2
// Tag definition for 'scenario'
// Generated on 1/1/2008 at 7:09 PM by The Swamp Fox
// -------------------------------------------------
namespace Games.Halo2.Tags.Classes {
  using System.IO;
  using System.Diagnostics;
  using System.Collections.Generic;
  using Interfaces;
  using Interfaces.Factory;
  using Games.Halo2.Tags.Fields;
  
  public partial class scenario : Interfaces.Pool.Tag {
    private ScenarioBlockBlock scenarioValues = new ScenarioBlockBlock();
    public virtual ScenarioBlockBlock ScenarioValues {
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
    public class ScenarioBlockBlock : IBlock {
      private TagReference _doNotUse = new TagReference();
      private Block _skies = new Block();
      private Enum _type;
      private Flags _flags;
      private Block _childScenarios = new Block();
      private Angle _localNorth = new Angle();
      private Block _predictedResources = new Block();
      private Block _functions = new Block();
      private Data _editorScenarioData = new Data();
      private Block _comments = new Block();
      private Block _emptyname = new Block();
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
      private Block _lightVolumes = new Block();
      private Block _lightVolumesPalette = new Block();
      private Block _playerStartingProfile = new Block();
      private Block _playerStartingLocations = new Block();
      private Block _killTriggerVolumes = new Block();
      private Block _recordedAnimations = new Block();
      private Block _netgameFlags = new Block();
      private Block _netgameEquipment = new Block();
      private Block _startingEquipment = new Block();
      private Block _bSPSwitchTriggerVolumes = new Block();
      private Block _decals = new Block();
      private Block _decalsPalette = new Block();
      private Block _detailObjectCollectionPalette = new Block();
      private Block _stylePalette = new Block();
      private Block _squadGroups = new Block();
      private Block _squads = new Block();
      private Block _zones = new Block();
      private Block _missionScenes = new Block();
      private Block _characterPalette = new Block();
      private Block _aIPathfindingData = new Block();
      private Block _aIAnimationReferences = new Block();
      private Block _aIScriptReferences = new Block();
      private Block _aIRecordingReferences = new Block();
      private Block _aIConversations = new Block();
      private Data _scriptSyntaxData = new Data();
      private Data _scriptStringData = new Data();
      private Block _scripts = new Block();
      private Block _globals = new Block();
      private Block _references = new Block();
      private Block _sourceFiles = new Block();
      private Block _scriptingData = new Block();
      private Block _cutsceneFlags = new Block();
      private Block _cutsceneCameraPoints = new Block();
      private Block _cutsceneTitles = new Block();
      private TagReference _customObjectNames = new TagReference();
      private TagReference _chapterTitleText = new TagReference();
      private TagReference _hUDMessages = new TagReference();
      private Block _structureBSPs = new Block();
      private Block _scenarioResources = new Block();
      private Block _scenarioResources2 = new Block();
      private Block _hsUnitSeats = new Block();
      private Block _scenarioKillTriggers = new Block();
      private Block _hsSyntaxDatums = new Block();
      private Block _orders = new Block();
      private Block _triggers = new Block();
      private Block _backgroundSoundPalette = new Block();
      private Block _soundEnvironmentPalette = new Block();
      private Block _weatherPalette = new Block();
      private Block _unnamed0 = new Block();
      private Block _unnamed1 = new Block();
      private Block _unnamed2 = new Block();
      private Block _unnamed3 = new Block();
      private Block _unnamed4 = new Block();
      private Block _scenarioClusterData = new Block();
      private LongInteger _unnamed5 = new LongInteger();
      private LongInteger _unnamed6 = new LongInteger();
      private LongInteger _unnamed7 = new LongInteger();
      private LongInteger _unnamed8 = new LongInteger();
      private LongInteger _unnamed9 = new LongInteger();
      private LongInteger _unnamed10 = new LongInteger();
      private LongInteger _unnamed11 = new LongInteger();
      private LongInteger _unnamed12 = new LongInteger();
      private LongInteger _unnamed13 = new LongInteger();
      private LongInteger _unnamed14 = new LongInteger();
      private LongInteger _unnamed15 = new LongInteger();
      private LongInteger _unnamed16 = new LongInteger();
      private LongInteger _unnamed17 = new LongInteger();
      private LongInteger _unnamed18 = new LongInteger();
      private LongInteger _unnamed19 = new LongInteger();
      private LongInteger _unnamed20 = new LongInteger();
      private LongInteger _unnamed21 = new LongInteger();
      private LongInteger _unnamed22 = new LongInteger();
      private LongInteger _unnamed23 = new LongInteger();
      private LongInteger _unnamed24 = new LongInteger();
      private LongInteger _unnamed25 = new LongInteger();
      private LongInteger _unnamed26 = new LongInteger();
      private LongInteger _unnamed27 = new LongInteger();
      private LongInteger _unnamed28 = new LongInteger();
      private LongInteger _unnamed29 = new LongInteger();
      private LongInteger _unnamed30 = new LongInteger();
      private LongInteger _unnamed31 = new LongInteger();
      private LongInteger _unnamed32 = new LongInteger();
      private LongInteger _unnamed33 = new LongInteger();
      private LongInteger _unnamed34 = new LongInteger();
      private LongInteger _unnamed35 = new LongInteger();
      private LongInteger _unnamed36 = new LongInteger();
      private Block _spawnData = new Block();
      private TagReference _soundEffectCollection = new TagReference();
      private Block _crates = new Block();
      private Block _cratesPalette = new Block();
      private TagReference _globalLighting = new TagReference();
      private Block _atmosphericFogPalette = new Block();
      private Block _planarFogPalette = new Block();
      private Block _flocks = new Block();
      private TagReference _subtitles = new TagReference();
      private Block _decorators = new Block();
      private Block _creatures = new Block();
      private Block _creaturesPalette = new Block();
      private Block _decoratorsPalette = new Block();
      private Block _bSPTransitionVolumes = new Block();
      private Block _structureBSPLighting = new Block();
      private Block _editorFolders = new Block();
      private Block _levelData = new Block();
      private TagReference _territoryLocationNames = new TagReference();
      private Pad _unnamed37;
      private Block _missionDialogue = new Block();
      private TagReference _objectives = new TagReference();
      private Block _interpolators = new Block();
      private Block _sharedReferences = new Block();
      private Block _screenEffectReferences = new Block();
      private Block _simulationDefinitionTable = new Block();
      public BlockCollection<ScenarioSkyReferenceBlockBlock> _skiesList = new BlockCollection<ScenarioSkyReferenceBlockBlock>();
      public BlockCollection<ScenarioChildScenarioBlockBlock> _childScenariosList = new BlockCollection<ScenarioChildScenarioBlockBlock>();
      public BlockCollection<PredictedResourceBlockBlock> _predictedResourcesList = new BlockCollection<PredictedResourceBlockBlock>();
      public BlockCollection<ScenarioFunctionBlockBlock> _functionsList = new BlockCollection<ScenarioFunctionBlockBlock>();
      public BlockCollection<EditorCommentBlockBlock> _commentsList = new BlockCollection<EditorCommentBlockBlock>();
      public BlockCollection<DontUseMeScenarioEnvironmentObjectBlockBlock> _emptynameList = new BlockCollection<DontUseMeScenarioEnvironmentObjectBlockBlock>();
      public BlockCollection<ScenarioObjectNamesBlockBlock> _objectNamesList = new BlockCollection<ScenarioObjectNamesBlockBlock>();
      public BlockCollection<ScenarioSceneryBlockBlock> _sceneryList = new BlockCollection<ScenarioSceneryBlockBlock>();
      public BlockCollection<ScenarioSceneryPaletteBlockBlock> _sceneryPaletteList = new BlockCollection<ScenarioSceneryPaletteBlockBlock>();
      public BlockCollection<ScenarioBipedBlockBlock> _bipedsList = new BlockCollection<ScenarioBipedBlockBlock>();
      public BlockCollection<ScenarioBipedPaletteBlockBlock> _bipedPaletteList = new BlockCollection<ScenarioBipedPaletteBlockBlock>();
      public BlockCollection<ScenarioVehicleBlockBlock> _vehiclesList = new BlockCollection<ScenarioVehicleBlockBlock>();
      public BlockCollection<ScenarioVehiclePaletteBlockBlock> _vehiclePaletteList = new BlockCollection<ScenarioVehiclePaletteBlockBlock>();
      public BlockCollection<ScenarioEquipmentBlockBlock> _equipmentList = new BlockCollection<ScenarioEquipmentBlockBlock>();
      public BlockCollection<ScenarioEquipmentPaletteBlockBlock> _equipmentPaletteList = new BlockCollection<ScenarioEquipmentPaletteBlockBlock>();
      public BlockCollection<ScenarioWeaponBlockBlock> _weaponsList = new BlockCollection<ScenarioWeaponBlockBlock>();
      public BlockCollection<ScenarioWeaponPaletteBlockBlock> _weaponPaletteList = new BlockCollection<ScenarioWeaponPaletteBlockBlock>();
      public BlockCollection<DeviceGroupBlockBlock> _deviceGroupsList = new BlockCollection<DeviceGroupBlockBlock>();
      public BlockCollection<ScenarioMachineBlockBlock> _machinesList = new BlockCollection<ScenarioMachineBlockBlock>();
      public BlockCollection<ScenarioMachinePaletteBlockBlock> _machinePaletteList = new BlockCollection<ScenarioMachinePaletteBlockBlock>();
      public BlockCollection<ScenarioControlBlockBlock> _controlsList = new BlockCollection<ScenarioControlBlockBlock>();
      public BlockCollection<ScenarioControlPaletteBlockBlock> _controlPaletteList = new BlockCollection<ScenarioControlPaletteBlockBlock>();
      public BlockCollection<ScenarioLightFixtureBlockBlock> _lightFixturesList = new BlockCollection<ScenarioLightFixtureBlockBlock>();
      public BlockCollection<ScenarioLightFixturePaletteBlockBlock> _lightFixturesPaletteList = new BlockCollection<ScenarioLightFixturePaletteBlockBlock>();
      public BlockCollection<ScenarioSoundSceneryBlockBlock> _soundSceneryList = new BlockCollection<ScenarioSoundSceneryBlockBlock>();
      public BlockCollection<ScenarioSoundSceneryPaletteBlockBlock> _soundSceneryPaletteList = new BlockCollection<ScenarioSoundSceneryPaletteBlockBlock>();
      public BlockCollection<ScenarioLightBlockBlock> _lightVolumesList = new BlockCollection<ScenarioLightBlockBlock>();
      public BlockCollection<ScenarioLightPaletteBlockBlock> _lightVolumesPaletteList = new BlockCollection<ScenarioLightPaletteBlockBlock>();
      public BlockCollection<ScenarioProfilesBlockBlock> _playerStartingProfileList = new BlockCollection<ScenarioProfilesBlockBlock>();
      public BlockCollection<ScenarioPlayersBlockBlock> _playerStartingLocationsList = new BlockCollection<ScenarioPlayersBlockBlock>();
      public BlockCollection<ScenarioTriggerVolumeBlockBlock> _killTriggerVolumesList = new BlockCollection<ScenarioTriggerVolumeBlockBlock>();
      public BlockCollection<RecordedAnimationBlockBlock> _recordedAnimationsList = new BlockCollection<RecordedAnimationBlockBlock>();
      public BlockCollection<ScenarioNetpointsBlockBlock> _netgameFlagsList = new BlockCollection<ScenarioNetpointsBlockBlock>();
      public BlockCollection<ScenarioNetgameEquipmentBlockBlock> _netgameEquipmentList = new BlockCollection<ScenarioNetgameEquipmentBlockBlock>();
      public BlockCollection<ScenarioStartingEquipmentBlockBlock> _startingEquipmentList = new BlockCollection<ScenarioStartingEquipmentBlockBlock>();
      public BlockCollection<ScenarioBspSwitchTriggerVolumeBlockBlock> _bSPSwitchTriggerVolumesList = new BlockCollection<ScenarioBspSwitchTriggerVolumeBlockBlock>();
      public BlockCollection<ScenarioDecalsBlockBlock> _decalsList = new BlockCollection<ScenarioDecalsBlockBlock>();
      public BlockCollection<ScenarioDecalPaletteBlockBlock> _decalsPaletteList = new BlockCollection<ScenarioDecalPaletteBlockBlock>();
      public BlockCollection<ScenarioDetailObjectCollectionPaletteBlockBlock> _detailObjectCollectionPaletteList = new BlockCollection<ScenarioDetailObjectCollectionPaletteBlockBlock>();
      public BlockCollection<StylePaletteBlockBlock> _stylePaletteList = new BlockCollection<StylePaletteBlockBlock>();
      public BlockCollection<SquadGroupsBlockBlock> _squadGroupsList = new BlockCollection<SquadGroupsBlockBlock>();
      public BlockCollection<SquadsBlockBlock> _squadsList = new BlockCollection<SquadsBlockBlock>();
      public BlockCollection<ZoneBlockBlock> _zonesList = new BlockCollection<ZoneBlockBlock>();
      public BlockCollection<AiSceneBlockBlock> _missionScenesList = new BlockCollection<AiSceneBlockBlock>();
      public BlockCollection<CharacterPaletteBlockBlock> _characterPaletteList = new BlockCollection<CharacterPaletteBlockBlock>();
      public BlockCollection<PathfindingDataBlockBlock> _aIPathfindingDataList = new BlockCollection<PathfindingDataBlockBlock>();
      public BlockCollection<AiAnimationReferenceBlockBlock> _aIAnimationReferencesList = new BlockCollection<AiAnimationReferenceBlockBlock>();
      public BlockCollection<AiScriptReferenceBlockBlock> _aIScriptReferencesList = new BlockCollection<AiScriptReferenceBlockBlock>();
      public BlockCollection<AiRecordingReferenceBlockBlock> _aIRecordingReferencesList = new BlockCollection<AiRecordingReferenceBlockBlock>();
      public BlockCollection<AiConversationBlockBlock> _aIConversationsList = new BlockCollection<AiConversationBlockBlock>();
      public BlockCollection<HsScriptsBlockBlock> _scriptsList = new BlockCollection<HsScriptsBlockBlock>();
      public BlockCollection<HsGlobalsBlockBlock> _globalsList = new BlockCollection<HsGlobalsBlockBlock>();
      public BlockCollection<HsReferencesBlockBlock> _referencesList = new BlockCollection<HsReferencesBlockBlock>();
      public BlockCollection<HsSourceFilesBlockBlock> _sourceFilesList = new BlockCollection<HsSourceFilesBlockBlock>();
      public BlockCollection<CsScriptDataBlockBlock> _scriptingDataList = new BlockCollection<CsScriptDataBlockBlock>();
      public BlockCollection<ScenarioCutsceneFlagBlockBlock> _cutsceneFlagsList = new BlockCollection<ScenarioCutsceneFlagBlockBlock>();
      public BlockCollection<ScenarioCutsceneCameraPointBlockBlock> _cutsceneCameraPointsList = new BlockCollection<ScenarioCutsceneCameraPointBlockBlock>();
      public BlockCollection<ScenarioCutsceneTitleBlockBlock> _cutsceneTitlesList = new BlockCollection<ScenarioCutsceneTitleBlockBlock>();
      public BlockCollection<ScenarioStructureBspReferenceBlockBlock> _structureBSPsList = new BlockCollection<ScenarioStructureBspReferenceBlockBlock>();
      public BlockCollection<ScenarioResourcesBlockBlock> _scenarioResourcesList = new BlockCollection<ScenarioResourcesBlockBlock>();
      public BlockCollection<OldUnusedStrucurePhysicsBlockBlock> _scenarioResources2List = new BlockCollection<OldUnusedStrucurePhysicsBlockBlock>();
      public BlockCollection<HsUnitSeatBlockBlock> _hsUnitSeatsList = new BlockCollection<HsUnitSeatBlockBlock>();
      public BlockCollection<ScenarioKillTriggerVolumesBlockBlock> _scenarioKillTriggersList = new BlockCollection<ScenarioKillTriggerVolumesBlockBlock>();
      public BlockCollection<SyntaxDatumBlockBlock> _hsSyntaxDatumsList = new BlockCollection<SyntaxDatumBlockBlock>();
      public BlockCollection<OrdersBlockBlock> _ordersList = new BlockCollection<OrdersBlockBlock>();
      public BlockCollection<TriggersBlockBlock> _triggersList = new BlockCollection<TriggersBlockBlock>();
      public BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock> _backgroundSoundPaletteList = new BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock>();
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock> _soundEnvironmentPaletteList = new BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock>();
      public BlockCollection<StructureBspWeatherPaletteBlockBlock> _weatherPaletteList = new BlockCollection<StructureBspWeatherPaletteBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed0List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed1List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed2List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed3List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed4List = new BlockCollection<GNullBlockBlock>();
      public BlockCollection<ScenarioClusterDataBlockBlock> _scenarioClusterDataList = new BlockCollection<ScenarioClusterDataBlockBlock>();
      public BlockCollection<ScenarioSpawnDataBlockBlock> _spawnDataList = new BlockCollection<ScenarioSpawnDataBlockBlock>();
      public BlockCollection<ScenarioCrateBlockBlock> _cratesList = new BlockCollection<ScenarioCrateBlockBlock>();
      public BlockCollection<ScenarioCratePaletteBlockBlock> _cratesPaletteList = new BlockCollection<ScenarioCratePaletteBlockBlock>();
      public BlockCollection<ScenarioAtmosphericFogPaletteBlock> _atmosphericFogPaletteList = new BlockCollection<ScenarioAtmosphericFogPaletteBlock>();
      public BlockCollection<ScenarioPlanarFogPaletteBlock> _planarFogPaletteList = new BlockCollection<ScenarioPlanarFogPaletteBlock>();
      public BlockCollection<FlockDefinitionBlockBlock> _flocksList = new BlockCollection<FlockDefinitionBlockBlock>();
      public BlockCollection<DecoratorPlacementDefinitionBlockBlock> _decoratorsList = new BlockCollection<DecoratorPlacementDefinitionBlockBlock>();
      public BlockCollection<ScenarioCreatureBlockBlock> _creaturesList = new BlockCollection<ScenarioCreatureBlockBlock>();
      public BlockCollection<ScenarioCreaturePaletteBlockBlock> _creaturesPaletteList = new BlockCollection<ScenarioCreaturePaletteBlockBlock>();
      public BlockCollection<ScenarioDecoratorSetPaletteEntryBlockBlock> _decoratorsPaletteList = new BlockCollection<ScenarioDecoratorSetPaletteEntryBlockBlock>();
      public BlockCollection<ScenarioBspSwitchTransitionVolumeBlockBlock> _bSPTransitionVolumesList = new BlockCollection<ScenarioBspSwitchTransitionVolumeBlockBlock>();
      public BlockCollection<ScenarioStructureBspSphericalHarmonicLightingBlockBlock> _structureBSPLightingList = new BlockCollection<ScenarioStructureBspSphericalHarmonicLightingBlockBlock>();
      public BlockCollection<GScenarioEditorFolderBlockBlock> _editorFoldersList = new BlockCollection<GScenarioEditorFolderBlockBlock>();
      public BlockCollection<ScenarioLevelDataBlockBlock> _levelDataList = new BlockCollection<ScenarioLevelDataBlockBlock>();
      public BlockCollection<AiScenarioMissionDialogueBlockBlock> _missionDialogueList = new BlockCollection<AiScenarioMissionDialogueBlockBlock>();
      public BlockCollection<ScenarioInterpolatorBlockBlock> _interpolatorsList = new BlockCollection<ScenarioInterpolatorBlockBlock>();
      public BlockCollection<HsReferencesBlockBlock> _sharedReferencesList = new BlockCollection<HsReferencesBlockBlock>();
      public BlockCollection<ScenarioScreenEffectReferenceBlockBlock> _screenEffectReferencesList = new BlockCollection<ScenarioScreenEffectReferenceBlockBlock>();
      public BlockCollection<ScenarioSimulationDefinitionTableBlockBlock> _simulationDefinitionTableList = new BlockCollection<ScenarioSimulationDefinitionTableBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioBlockBlock() {
        this._type = new Enum(2);
        this._flags = new Flags(2);
        this._unnamed37 = new Pad(8);
      }
      public BlockCollection<ScenarioSkyReferenceBlockBlock> Skies {
        get {
          return this._skiesList;
        }
      }
      public BlockCollection<ScenarioChildScenarioBlockBlock> ChildScenarios {
        get {
          return this._childScenariosList;
        }
      }
      public BlockCollection<PredictedResourceBlockBlock> PredictedResources {
        get {
          return this._predictedResourcesList;
        }
      }
      public BlockCollection<ScenarioFunctionBlockBlock> Functions {
        get {
          return this._functionsList;
        }
      }
      public BlockCollection<EditorCommentBlockBlock> Comments {
        get {
          return this._commentsList;
        }
      }
      public BlockCollection<DontUseMeScenarioEnvironmentObjectBlockBlock> Emptyname {
        get {
          return this._emptynameList;
        }
      }
      public BlockCollection<ScenarioObjectNamesBlockBlock> ObjectNames {
        get {
          return this._objectNamesList;
        }
      }
      public BlockCollection<ScenarioSceneryBlockBlock> Scenery {
        get {
          return this._sceneryList;
        }
      }
      public BlockCollection<ScenarioSceneryPaletteBlockBlock> SceneryPalette {
        get {
          return this._sceneryPaletteList;
        }
      }
      public BlockCollection<ScenarioBipedBlockBlock> Bipeds {
        get {
          return this._bipedsList;
        }
      }
      public BlockCollection<ScenarioBipedPaletteBlockBlock> BipedPalette {
        get {
          return this._bipedPaletteList;
        }
      }
      public BlockCollection<ScenarioVehicleBlockBlock> Vehicles {
        get {
          return this._vehiclesList;
        }
      }
      public BlockCollection<ScenarioVehiclePaletteBlockBlock> VehiclePalette {
        get {
          return this._vehiclePaletteList;
        }
      }
      public BlockCollection<ScenarioEquipmentBlockBlock> Equipment {
        get {
          return this._equipmentList;
        }
      }
      public BlockCollection<ScenarioEquipmentPaletteBlockBlock> EquipmentPalette {
        get {
          return this._equipmentPaletteList;
        }
      }
      public BlockCollection<ScenarioWeaponBlockBlock> Weapons {
        get {
          return this._weaponsList;
        }
      }
      public BlockCollection<ScenarioWeaponPaletteBlockBlock> WeaponPalette {
        get {
          return this._weaponPaletteList;
        }
      }
      public BlockCollection<DeviceGroupBlockBlock> DeviceGroups {
        get {
          return this._deviceGroupsList;
        }
      }
      public BlockCollection<ScenarioMachineBlockBlock> Machines {
        get {
          return this._machinesList;
        }
      }
      public BlockCollection<ScenarioMachinePaletteBlockBlock> MachinePalette {
        get {
          return this._machinePaletteList;
        }
      }
      public BlockCollection<ScenarioControlBlockBlock> Controls {
        get {
          return this._controlsList;
        }
      }
      public BlockCollection<ScenarioControlPaletteBlockBlock> ControlPalette {
        get {
          return this._controlPaletteList;
        }
      }
      public BlockCollection<ScenarioLightFixtureBlockBlock> LightFixtures {
        get {
          return this._lightFixturesList;
        }
      }
      public BlockCollection<ScenarioLightFixturePaletteBlockBlock> LightFixturesPalette {
        get {
          return this._lightFixturesPaletteList;
        }
      }
      public BlockCollection<ScenarioSoundSceneryBlockBlock> SoundScenery {
        get {
          return this._soundSceneryList;
        }
      }
      public BlockCollection<ScenarioSoundSceneryPaletteBlockBlock> SoundSceneryPalette {
        get {
          return this._soundSceneryPaletteList;
        }
      }
      public BlockCollection<ScenarioLightBlockBlock> LightVolumes {
        get {
          return this._lightVolumesList;
        }
      }
      public BlockCollection<ScenarioLightPaletteBlockBlock> LightVolumesPalette {
        get {
          return this._lightVolumesPaletteList;
        }
      }
      public BlockCollection<ScenarioProfilesBlockBlock> PlayerStartingProfile {
        get {
          return this._playerStartingProfileList;
        }
      }
      public BlockCollection<ScenarioPlayersBlockBlock> PlayerStartingLocations {
        get {
          return this._playerStartingLocationsList;
        }
      }
      public BlockCollection<ScenarioTriggerVolumeBlockBlock> KillTriggerVolumes {
        get {
          return this._killTriggerVolumesList;
        }
      }
      public BlockCollection<RecordedAnimationBlockBlock> RecordedAnimations {
        get {
          return this._recordedAnimationsList;
        }
      }
      public BlockCollection<ScenarioNetpointsBlockBlock> NetgameFlags {
        get {
          return this._netgameFlagsList;
        }
      }
      public BlockCollection<ScenarioNetgameEquipmentBlockBlock> NetgameEquipment {
        get {
          return this._netgameEquipmentList;
        }
      }
      public BlockCollection<ScenarioStartingEquipmentBlockBlock> StartingEquipment {
        get {
          return this._startingEquipmentList;
        }
      }
      public BlockCollection<ScenarioBspSwitchTriggerVolumeBlockBlock> BSPSwitchTriggerVolumes {
        get {
          return this._bSPSwitchTriggerVolumesList;
        }
      }
      public BlockCollection<ScenarioDecalsBlockBlock> Decals {
        get {
          return this._decalsList;
        }
      }
      public BlockCollection<ScenarioDecalPaletteBlockBlock> DecalsPalette {
        get {
          return this._decalsPaletteList;
        }
      }
      public BlockCollection<ScenarioDetailObjectCollectionPaletteBlockBlock> DetailObjectCollectionPalette {
        get {
          return this._detailObjectCollectionPaletteList;
        }
      }
      public BlockCollection<StylePaletteBlockBlock> StylePalette {
        get {
          return this._stylePaletteList;
        }
      }
      public BlockCollection<SquadGroupsBlockBlock> SquadGroups {
        get {
          return this._squadGroupsList;
        }
      }
      public BlockCollection<SquadsBlockBlock> Squads {
        get {
          return this._squadsList;
        }
      }
      public BlockCollection<ZoneBlockBlock> Zones {
        get {
          return this._zonesList;
        }
      }
      public BlockCollection<AiSceneBlockBlock> MissionScenes {
        get {
          return this._missionScenesList;
        }
      }
      public BlockCollection<CharacterPaletteBlockBlock> CharacterPalette {
        get {
          return this._characterPaletteList;
        }
      }
      public BlockCollection<PathfindingDataBlockBlock> AIPathfindingData {
        get {
          return this._aIPathfindingDataList;
        }
      }
      public BlockCollection<AiAnimationReferenceBlockBlock> AIAnimationReferences {
        get {
          return this._aIAnimationReferencesList;
        }
      }
      public BlockCollection<AiScriptReferenceBlockBlock> AIScriptReferences {
        get {
          return this._aIScriptReferencesList;
        }
      }
      public BlockCollection<AiRecordingReferenceBlockBlock> AIRecordingReferences {
        get {
          return this._aIRecordingReferencesList;
        }
      }
      public BlockCollection<AiConversationBlockBlock> AIConversations {
        get {
          return this._aIConversationsList;
        }
      }
      public BlockCollection<HsScriptsBlockBlock> Scripts {
        get {
          return this._scriptsList;
        }
      }
      public BlockCollection<HsGlobalsBlockBlock> Globals {
        get {
          return this._globalsList;
        }
      }
      public BlockCollection<HsReferencesBlockBlock> References {
        get {
          return this._referencesList;
        }
      }
      public BlockCollection<HsSourceFilesBlockBlock> SourceFiles {
        get {
          return this._sourceFilesList;
        }
      }
      public BlockCollection<CsScriptDataBlockBlock> ScriptingData {
        get {
          return this._scriptingDataList;
        }
      }
      public BlockCollection<ScenarioCutsceneFlagBlockBlock> CutsceneFlags {
        get {
          return this._cutsceneFlagsList;
        }
      }
      public BlockCollection<ScenarioCutsceneCameraPointBlockBlock> CutsceneCameraPoints {
        get {
          return this._cutsceneCameraPointsList;
        }
      }
      public BlockCollection<ScenarioCutsceneTitleBlockBlock> CutsceneTitles {
        get {
          return this._cutsceneTitlesList;
        }
      }
      public BlockCollection<ScenarioStructureBspReferenceBlockBlock> StructureBSPs {
        get {
          return this._structureBSPsList;
        }
      }
      public BlockCollection<ScenarioResourcesBlockBlock> ScenarioResources {
        get {
          return this._scenarioResourcesList;
        }
      }
      public BlockCollection<OldUnusedStrucurePhysicsBlockBlock> ScenarioResources2 {
        get {
          return this._scenarioResources2List;
        }
      }
      public BlockCollection<HsUnitSeatBlockBlock> HsUnitSeats {
        get {
          return this._hsUnitSeatsList;
        }
      }
      public BlockCollection<ScenarioKillTriggerVolumesBlockBlock> ScenarioKillTriggers {
        get {
          return this._scenarioKillTriggersList;
        }
      }
      public BlockCollection<SyntaxDatumBlockBlock> HsSyntaxDatums {
        get {
          return this._hsSyntaxDatumsList;
        }
      }
      public BlockCollection<OrdersBlockBlock> Orders {
        get {
          return this._ordersList;
        }
      }
      public BlockCollection<TriggersBlockBlock> Triggers {
        get {
          return this._triggersList;
        }
      }
      public BlockCollection<StructureBspBackgroundSoundPaletteBlockBlock> BackgroundSoundPalette {
        get {
          return this._backgroundSoundPaletteList;
        }
      }
      public BlockCollection<StructureBspSoundEnvironmentPaletteBlockBlock> SoundEnvironmentPalette {
        get {
          return this._soundEnvironmentPaletteList;
        }
      }
      public BlockCollection<StructureBspWeatherPaletteBlockBlock> WeatherPalette {
        get {
          return this._weatherPaletteList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed0 {
        get {
          return this._unnamed0List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed1 {
        get {
          return this._unnamed1List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed2 {
        get {
          return this._unnamed2List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed3 {
        get {
          return this._unnamed3List;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed4 {
        get {
          return this._unnamed4List;
        }
      }
      public BlockCollection<ScenarioClusterDataBlockBlock> ScenarioClusterData {
        get {
          return this._scenarioClusterDataList;
        }
      }
      public BlockCollection<ScenarioSpawnDataBlockBlock> SpawnData {
        get {
          return this._spawnDataList;
        }
      }
      public BlockCollection<ScenarioCrateBlockBlock> Crates {
        get {
          return this._cratesList;
        }
      }
      public BlockCollection<ScenarioCratePaletteBlockBlock> CratesPalette {
        get {
          return this._cratesPaletteList;
        }
      }
      public BlockCollection<ScenarioAtmosphericFogPaletteBlock> AtmosphericFogPalette {
        get {
          return this._atmosphericFogPaletteList;
        }
      }
      public BlockCollection<ScenarioPlanarFogPaletteBlock> PlanarFogPalette {
        get {
          return this._planarFogPaletteList;
        }
      }
      public BlockCollection<FlockDefinitionBlockBlock> Flocks {
        get {
          return this._flocksList;
        }
      }
      public BlockCollection<DecoratorPlacementDefinitionBlockBlock> Decorators {
        get {
          return this._decoratorsList;
        }
      }
      public BlockCollection<ScenarioCreatureBlockBlock> Creatures {
        get {
          return this._creaturesList;
        }
      }
      public BlockCollection<ScenarioCreaturePaletteBlockBlock> CreaturesPalette {
        get {
          return this._creaturesPaletteList;
        }
      }
      public BlockCollection<ScenarioDecoratorSetPaletteEntryBlockBlock> DecoratorsPalette {
        get {
          return this._decoratorsPaletteList;
        }
      }
      public BlockCollection<ScenarioBspSwitchTransitionVolumeBlockBlock> BSPTransitionVolumes {
        get {
          return this._bSPTransitionVolumesList;
        }
      }
      public BlockCollection<ScenarioStructureBspSphericalHarmonicLightingBlockBlock> StructureBSPLighting {
        get {
          return this._structureBSPLightingList;
        }
      }
      public BlockCollection<GScenarioEditorFolderBlockBlock> EditorFolders {
        get {
          return this._editorFoldersList;
        }
      }
      public BlockCollection<ScenarioLevelDataBlockBlock> LevelData {
        get {
          return this._levelDataList;
        }
      }
      public BlockCollection<AiScenarioMissionDialogueBlockBlock> MissionDialogue {
        get {
          return this._missionDialogueList;
        }
      }
      public BlockCollection<ScenarioInterpolatorBlockBlock> Interpolators {
        get {
          return this._interpolatorsList;
        }
      }
      public BlockCollection<HsReferencesBlockBlock> SharedReferences {
        get {
          return this._sharedReferencesList;
        }
      }
      public BlockCollection<ScenarioScreenEffectReferenceBlockBlock> ScreenEffectReferences {
        get {
          return this._screenEffectReferencesList;
        }
      }
      public BlockCollection<ScenarioSimulationDefinitionTableBlockBlock> SimulationDefinitionTable {
        get {
          return this._simulationDefinitionTableList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_doNotUse.Value);
references.Add(_customObjectNames.Value);
references.Add(_chapterTitleText.Value);
references.Add(_hUDMessages.Value);
references.Add(_soundEffectCollection.Value);
references.Add(_globalLighting.Value);
references.Add(_subtitles.Value);
references.Add(_territoryLocationNames.Value);
references.Add(_objectives.Value);
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
for (int x=0; x<Emptyname.BlockCount; x++)
{
  IBlock block = Emptyname.GetBlock(x);
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
for (int x=0; x<LightVolumes.BlockCount; x++)
{
  IBlock block = LightVolumes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LightVolumesPalette.BlockCount; x++)
{
  IBlock block = LightVolumesPalette.GetBlock(x);
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
for (int x=0; x<KillTriggerVolumes.BlockCount; x++)
{
  IBlock block = KillTriggerVolumes.GetBlock(x);
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
for (int x=0; x<BSPSwitchTriggerVolumes.BlockCount; x++)
{
  IBlock block = BSPSwitchTriggerVolumes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decals.BlockCount; x++)
{
  IBlock block = Decals.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalsPalette.BlockCount; x++)
{
  IBlock block = DecalsPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DetailObjectCollectionPalette.BlockCount; x++)
{
  IBlock block = DetailObjectCollectionPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StylePalette.BlockCount; x++)
{
  IBlock block = StylePalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SquadGroups.BlockCount; x++)
{
  IBlock block = SquadGroups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Squads.BlockCount; x++)
{
  IBlock block = Squads.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Zones.BlockCount; x++)
{
  IBlock block = Zones.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MissionScenes.BlockCount; x++)
{
  IBlock block = MissionScenes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CharacterPalette.BlockCount; x++)
{
  IBlock block = CharacterPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIPathfindingData.BlockCount; x++)
{
  IBlock block = AIPathfindingData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIAnimationReferences.BlockCount; x++)
{
  IBlock block = AIAnimationReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIScriptReferences.BlockCount; x++)
{
  IBlock block = AIScriptReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIRecordingReferences.BlockCount; x++)
{
  IBlock block = AIRecordingReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIConversations.BlockCount; x++)
{
  IBlock block = AIConversations.GetBlock(x);
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
for (int x=0; x<ScriptingData.BlockCount; x++)
{
  IBlock block = ScriptingData.GetBlock(x);
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
for (int x=0; x<StructureBSPs.BlockCount; x++)
{
  IBlock block = StructureBSPs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScenarioResources.BlockCount; x++)
{
  IBlock block = ScenarioResources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScenarioResources2.BlockCount; x++)
{
  IBlock block = ScenarioResources2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HsUnitSeats.BlockCount; x++)
{
  IBlock block = HsUnitSeats.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScenarioKillTriggers.BlockCount; x++)
{
  IBlock block = ScenarioKillTriggers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<HsSyntaxDatums.BlockCount; x++)
{
  IBlock block = HsSyntaxDatums.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Orders.BlockCount; x++)
{
  IBlock block = Orders.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Triggers.BlockCount; x++)
{
  IBlock block = Triggers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BackgroundSoundPalette.BlockCount; x++)
{
  IBlock block = BackgroundSoundPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundEnvironmentPalette.BlockCount; x++)
{
  IBlock block = SoundEnvironmentPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeatherPalette.BlockCount; x++)
{
  IBlock block = WeatherPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed0.BlockCount; x++)
{
  IBlock block = Unnamed0.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed1.BlockCount; x++)
{
  IBlock block = Unnamed1.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed2.BlockCount; x++)
{
  IBlock block = Unnamed2.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed3.BlockCount; x++)
{
  IBlock block = Unnamed3.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Unnamed4.BlockCount; x++)
{
  IBlock block = Unnamed4.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScenarioClusterData.BlockCount; x++)
{
  IBlock block = ScenarioClusterData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpawnData.BlockCount; x++)
{
  IBlock block = SpawnData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Crates.BlockCount; x++)
{
  IBlock block = Crates.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CratesPalette.BlockCount; x++)
{
  IBlock block = CratesPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AtmosphericFogPalette.BlockCount; x++)
{
  IBlock block = AtmosphericFogPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PlanarFogPalette.BlockCount; x++)
{
  IBlock block = PlanarFogPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Flocks.BlockCount; x++)
{
  IBlock block = Flocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decorators.BlockCount; x++)
{
  IBlock block = Decorators.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Creatures.BlockCount; x++)
{
  IBlock block = Creatures.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CreaturesPalette.BlockCount; x++)
{
  IBlock block = CreaturesPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecoratorsPalette.BlockCount; x++)
{
  IBlock block = DecoratorsPalette.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<BSPTransitionVolumes.BlockCount; x++)
{
  IBlock block = BSPTransitionVolumes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StructureBSPLighting.BlockCount; x++)
{
  IBlock block = StructureBSPLighting.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<EditorFolders.BlockCount; x++)
{
  IBlock block = EditorFolders.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LevelData.BlockCount; x++)
{
  IBlock block = LevelData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<MissionDialogue.BlockCount; x++)
{
  IBlock block = MissionDialogue.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Interpolators.BlockCount; x++)
{
  IBlock block = Interpolators.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SharedReferences.BlockCount; x++)
{
  IBlock block = SharedReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScreenEffectReferences.BlockCount; x++)
{
  IBlock block = ScreenEffectReferences.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SimulationDefinitionTable.BlockCount; x++)
{
  IBlock block = SimulationDefinitionTable.GetBlock(x);
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
      public TagReference DoNotUse {
        get {
          return this._doNotUse;
        }
        set {
          this._doNotUse = value;
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
      public TagReference ChapterTitleText {
        get {
          return this._chapterTitleText;
        }
        set {
          this._chapterTitleText = value;
        }
      }
      public TagReference HUDMessages {
        get {
          return this._hUDMessages;
        }
        set {
          this._hUDMessages = value;
        }
      }
      public LongInteger unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public LongInteger unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
        }
      }
      public LongInteger unnamed7 {
        get {
          return this._unnamed7;
        }
        set {
          this._unnamed7 = value;
        }
      }
      public LongInteger unnamed8 {
        get {
          return this._unnamed8;
        }
        set {
          this._unnamed8 = value;
        }
      }
      public LongInteger unnamed9 {
        get {
          return this._unnamed9;
        }
        set {
          this._unnamed9 = value;
        }
      }
      public LongInteger unnamed10 {
        get {
          return this._unnamed10;
        }
        set {
          this._unnamed10 = value;
        }
      }
      public LongInteger unnamed11 {
        get {
          return this._unnamed11;
        }
        set {
          this._unnamed11 = value;
        }
      }
      public LongInteger unnamed12 {
        get {
          return this._unnamed12;
        }
        set {
          this._unnamed12 = value;
        }
      }
      public LongInteger unnamed13 {
        get {
          return this._unnamed13;
        }
        set {
          this._unnamed13 = value;
        }
      }
      public LongInteger unnamed14 {
        get {
          return this._unnamed14;
        }
        set {
          this._unnamed14 = value;
        }
      }
      public LongInteger unnamed15 {
        get {
          return this._unnamed15;
        }
        set {
          this._unnamed15 = value;
        }
      }
      public LongInteger unnamed16 {
        get {
          return this._unnamed16;
        }
        set {
          this._unnamed16 = value;
        }
      }
      public LongInteger unnamed17 {
        get {
          return this._unnamed17;
        }
        set {
          this._unnamed17 = value;
        }
      }
      public LongInteger unnamed18 {
        get {
          return this._unnamed18;
        }
        set {
          this._unnamed18 = value;
        }
      }
      public LongInteger unnamed19 {
        get {
          return this._unnamed19;
        }
        set {
          this._unnamed19 = value;
        }
      }
      public LongInteger unnamed20 {
        get {
          return this._unnamed20;
        }
        set {
          this._unnamed20 = value;
        }
      }
      public LongInteger unnamed21 {
        get {
          return this._unnamed21;
        }
        set {
          this._unnamed21 = value;
        }
      }
      public LongInteger unnamed22 {
        get {
          return this._unnamed22;
        }
        set {
          this._unnamed22 = value;
        }
      }
      public LongInteger unnamed23 {
        get {
          return this._unnamed23;
        }
        set {
          this._unnamed23 = value;
        }
      }
      public LongInteger unnamed24 {
        get {
          return this._unnamed24;
        }
        set {
          this._unnamed24 = value;
        }
      }
      public LongInteger unnamed25 {
        get {
          return this._unnamed25;
        }
        set {
          this._unnamed25 = value;
        }
      }
      public LongInteger unnamed26 {
        get {
          return this._unnamed26;
        }
        set {
          this._unnamed26 = value;
        }
      }
      public LongInteger unnamed27 {
        get {
          return this._unnamed27;
        }
        set {
          this._unnamed27 = value;
        }
      }
      public LongInteger unnamed28 {
        get {
          return this._unnamed28;
        }
        set {
          this._unnamed28 = value;
        }
      }
      public LongInteger unnamed29 {
        get {
          return this._unnamed29;
        }
        set {
          this._unnamed29 = value;
        }
      }
      public LongInteger unnamed30 {
        get {
          return this._unnamed30;
        }
        set {
          this._unnamed30 = value;
        }
      }
      public LongInteger unnamed31 {
        get {
          return this._unnamed31;
        }
        set {
          this._unnamed31 = value;
        }
      }
      public LongInteger unnamed32 {
        get {
          return this._unnamed32;
        }
        set {
          this._unnamed32 = value;
        }
      }
      public LongInteger unnamed33 {
        get {
          return this._unnamed33;
        }
        set {
          this._unnamed33 = value;
        }
      }
      public LongInteger unnamed34 {
        get {
          return this._unnamed34;
        }
        set {
          this._unnamed34 = value;
        }
      }
      public LongInteger unnamed35 {
        get {
          return this._unnamed35;
        }
        set {
          this._unnamed35 = value;
        }
      }
      public LongInteger unnamed36 {
        get {
          return this._unnamed36;
        }
        set {
          this._unnamed36 = value;
        }
      }
      public TagReference SoundEffectCollection {
        get {
          return this._soundEffectCollection;
        }
        set {
          this._soundEffectCollection = value;
        }
      }
      public TagReference GlobalLighting {
        get {
          return this._globalLighting;
        }
        set {
          this._globalLighting = value;
        }
      }
      public TagReference Subtitles {
        get {
          return this._subtitles;
        }
        set {
          this._subtitles = value;
        }
      }
      public TagReference TerritoryLocationNames {
        get {
          return this._territoryLocationNames;
        }
        set {
          this._territoryLocationNames = value;
        }
      }
      public TagReference Objectives {
        get {
          return this._objectives;
        }
        set {
          this._objectives = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _doNotUse.Read(reader);
        _skies.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _childScenarios.Read(reader);
        _localNorth.Read(reader);
        _predictedResources.Read(reader);
        _functions.Read(reader);
        _editorScenarioData.Read(reader);
        _comments.Read(reader);
        _emptyname.Read(reader);
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
        _lightVolumes.Read(reader);
        _lightVolumesPalette.Read(reader);
        _playerStartingProfile.Read(reader);
        _playerStartingLocations.Read(reader);
        _killTriggerVolumes.Read(reader);
        _recordedAnimations.Read(reader);
        _netgameFlags.Read(reader);
        _netgameEquipment.Read(reader);
        _startingEquipment.Read(reader);
        _bSPSwitchTriggerVolumes.Read(reader);
        _decals.Read(reader);
        _decalsPalette.Read(reader);
        _detailObjectCollectionPalette.Read(reader);
        _stylePalette.Read(reader);
        _squadGroups.Read(reader);
        _squads.Read(reader);
        _zones.Read(reader);
        _missionScenes.Read(reader);
        _characterPalette.Read(reader);
        _aIPathfindingData.Read(reader);
        _aIAnimationReferences.Read(reader);
        _aIScriptReferences.Read(reader);
        _aIRecordingReferences.Read(reader);
        _aIConversations.Read(reader);
        _scriptSyntaxData.Read(reader);
        _scriptStringData.Read(reader);
        _scripts.Read(reader);
        _globals.Read(reader);
        _references.Read(reader);
        _sourceFiles.Read(reader);
        _scriptingData.Read(reader);
        _cutsceneFlags.Read(reader);
        _cutsceneCameraPoints.Read(reader);
        _cutsceneTitles.Read(reader);
        _customObjectNames.Read(reader);
        _chapterTitleText.Read(reader);
        _hUDMessages.Read(reader);
        _structureBSPs.Read(reader);
        _scenarioResources.Read(reader);
        _scenarioResources2.Read(reader);
        _hsUnitSeats.Read(reader);
        _scenarioKillTriggers.Read(reader);
        _hsSyntaxDatums.Read(reader);
        _orders.Read(reader);
        _triggers.Read(reader);
        _backgroundSoundPalette.Read(reader);
        _soundEnvironmentPalette.Read(reader);
        _weatherPalette.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _scenarioClusterData.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _unnamed7.Read(reader);
        _unnamed8.Read(reader);
        _unnamed9.Read(reader);
        _unnamed10.Read(reader);
        _unnamed11.Read(reader);
        _unnamed12.Read(reader);
        _unnamed13.Read(reader);
        _unnamed14.Read(reader);
        _unnamed15.Read(reader);
        _unnamed16.Read(reader);
        _unnamed17.Read(reader);
        _unnamed18.Read(reader);
        _unnamed19.Read(reader);
        _unnamed20.Read(reader);
        _unnamed21.Read(reader);
        _unnamed22.Read(reader);
        _unnamed23.Read(reader);
        _unnamed24.Read(reader);
        _unnamed25.Read(reader);
        _unnamed26.Read(reader);
        _unnamed27.Read(reader);
        _unnamed28.Read(reader);
        _unnamed29.Read(reader);
        _unnamed30.Read(reader);
        _unnamed31.Read(reader);
        _unnamed32.Read(reader);
        _unnamed33.Read(reader);
        _unnamed34.Read(reader);
        _unnamed35.Read(reader);
        _unnamed36.Read(reader);
        _spawnData.Read(reader);
        _soundEffectCollection.Read(reader);
        _crates.Read(reader);
        _cratesPalette.Read(reader);
        _globalLighting.Read(reader);
        _atmosphericFogPalette.Read(reader);
        _planarFogPalette.Read(reader);
        _flocks.Read(reader);
        _subtitles.Read(reader);
        _decorators.Read(reader);
        _creatures.Read(reader);
        _creaturesPalette.Read(reader);
        _decoratorsPalette.Read(reader);
        _bSPTransitionVolumes.Read(reader);
        _structureBSPLighting.Read(reader);
        _editorFolders.Read(reader);
        _levelData.Read(reader);
        _territoryLocationNames.Read(reader);
        _unnamed37.Read(reader);
        _missionDialogue.Read(reader);
        _objectives.Read(reader);
        _interpolators.Read(reader);
        _sharedReferences.Read(reader);
        _screenEffectReferences.Read(reader);
        _simulationDefinitionTable.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _doNotUse.ReadString(reader);
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies.Add(new ScenarioSkyReferenceBlockBlock());
          Skies[x].Read(reader);
        }
        for (x = 0; (x < _skies.Count); x = (x + 1)) {
          Skies[x].ReadChildData(reader);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios.Add(new ScenarioChildScenarioBlockBlock());
          ChildScenarios[x].Read(reader);
        }
        for (x = 0; (x < _childScenarios.Count); x = (x + 1)) {
          ChildScenarios[x].ReadChildData(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources.Add(new PredictedResourceBlockBlock());
          PredictedResources[x].Read(reader);
        }
        for (x = 0; (x < _predictedResources.Count); x = (x + 1)) {
          PredictedResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions.Add(new ScenarioFunctionBlockBlock());
          Functions[x].Read(reader);
        }
        for (x = 0; (x < _functions.Count); x = (x + 1)) {
          Functions[x].ReadChildData(reader);
        }
        _editorScenarioData.ReadBinary(reader);
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments.Add(new EditorCommentBlockBlock());
          Comments[x].Read(reader);
        }
        for (x = 0; (x < _comments.Count); x = (x + 1)) {
          Comments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname.Add(new DontUseMeScenarioEnvironmentObjectBlockBlock());
          Emptyname[x].Read(reader);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames.Add(new ScenarioObjectNamesBlockBlock());
          ObjectNames[x].Read(reader);
        }
        for (x = 0; (x < _objectNames.Count); x = (x + 1)) {
          ObjectNames[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery.Add(new ScenarioSceneryBlockBlock());
          Scenery[x].Read(reader);
        }
        for (x = 0; (x < _scenery.Count); x = (x + 1)) {
          Scenery[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette.Add(new ScenarioSceneryPaletteBlockBlock());
          SceneryPalette[x].Read(reader);
        }
        for (x = 0; (x < _sceneryPalette.Count); x = (x + 1)) {
          SceneryPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds.Add(new ScenarioBipedBlockBlock());
          Bipeds[x].Read(reader);
        }
        for (x = 0; (x < _bipeds.Count); x = (x + 1)) {
          Bipeds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette.Add(new ScenarioBipedPaletteBlockBlock());
          BipedPalette[x].Read(reader);
        }
        for (x = 0; (x < _bipedPalette.Count); x = (x + 1)) {
          BipedPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles.Add(new ScenarioVehicleBlockBlock());
          Vehicles[x].Read(reader);
        }
        for (x = 0; (x < _vehicles.Count); x = (x + 1)) {
          Vehicles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette.Add(new ScenarioVehiclePaletteBlockBlock());
          VehiclePalette[x].Read(reader);
        }
        for (x = 0; (x < _vehiclePalette.Count); x = (x + 1)) {
          VehiclePalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment.Add(new ScenarioEquipmentBlockBlock());
          Equipment[x].Read(reader);
        }
        for (x = 0; (x < _equipment.Count); x = (x + 1)) {
          Equipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette.Add(new ScenarioEquipmentPaletteBlockBlock());
          EquipmentPalette[x].Read(reader);
        }
        for (x = 0; (x < _equipmentPalette.Count); x = (x + 1)) {
          EquipmentPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons.Add(new ScenarioWeaponBlockBlock());
          Weapons[x].Read(reader);
        }
        for (x = 0; (x < _weapons.Count); x = (x + 1)) {
          Weapons[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette.Add(new ScenarioWeaponPaletteBlockBlock());
          WeaponPalette[x].Read(reader);
        }
        for (x = 0; (x < _weaponPalette.Count); x = (x + 1)) {
          WeaponPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups.Add(new DeviceGroupBlockBlock());
          DeviceGroups[x].Read(reader);
        }
        for (x = 0; (x < _deviceGroups.Count); x = (x + 1)) {
          DeviceGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines.Add(new ScenarioMachineBlockBlock());
          Machines[x].Read(reader);
        }
        for (x = 0; (x < _machines.Count); x = (x + 1)) {
          Machines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette.Add(new ScenarioMachinePaletteBlockBlock());
          MachinePalette[x].Read(reader);
        }
        for (x = 0; (x < _machinePalette.Count); x = (x + 1)) {
          MachinePalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls.Add(new ScenarioControlBlockBlock());
          Controls[x].Read(reader);
        }
        for (x = 0; (x < _controls.Count); x = (x + 1)) {
          Controls[x].ReadChildData(reader);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette.Add(new ScenarioControlPaletteBlockBlock());
          ControlPalette[x].Read(reader);
        }
        for (x = 0; (x < _controlPalette.Count); x = (x + 1)) {
          ControlPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures.Add(new ScenarioLightFixtureBlockBlock());
          LightFixtures[x].Read(reader);
        }
        for (x = 0; (x < _lightFixtures.Count); x = (x + 1)) {
          LightFixtures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette.Add(new ScenarioLightFixturePaletteBlockBlock());
          LightFixturesPalette[x].Read(reader);
        }
        for (x = 0; (x < _lightFixturesPalette.Count); x = (x + 1)) {
          LightFixturesPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery.Add(new ScenarioSoundSceneryBlockBlock());
          SoundScenery[x].Read(reader);
        }
        for (x = 0; (x < _soundScenery.Count); x = (x + 1)) {
          SoundScenery[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette.Add(new ScenarioSoundSceneryPaletteBlockBlock());
          SoundSceneryPalette[x].Read(reader);
        }
        for (x = 0; (x < _soundSceneryPalette.Count); x = (x + 1)) {
          SoundSceneryPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightVolumes.Count); x = (x + 1)) {
          LightVolumes.Add(new ScenarioLightBlockBlock());
          LightVolumes[x].Read(reader);
        }
        for (x = 0; (x < _lightVolumes.Count); x = (x + 1)) {
          LightVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lightVolumesPalette.Count); x = (x + 1)) {
          LightVolumesPalette.Add(new ScenarioLightPaletteBlockBlock());
          LightVolumesPalette[x].Read(reader);
        }
        for (x = 0; (x < _lightVolumesPalette.Count); x = (x + 1)) {
          LightVolumesPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile.Add(new ScenarioProfilesBlockBlock());
          PlayerStartingProfile[x].Read(reader);
        }
        for (x = 0; (x < _playerStartingProfile.Count); x = (x + 1)) {
          PlayerStartingProfile[x].ReadChildData(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations.Add(new ScenarioPlayersBlockBlock());
          PlayerStartingLocations[x].Read(reader);
        }
        for (x = 0; (x < _playerStartingLocations.Count); x = (x + 1)) {
          PlayerStartingLocations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _killTriggerVolumes.Count); x = (x + 1)) {
          KillTriggerVolumes.Add(new ScenarioTriggerVolumeBlockBlock());
          KillTriggerVolumes[x].Read(reader);
        }
        for (x = 0; (x < _killTriggerVolumes.Count); x = (x + 1)) {
          KillTriggerVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations.Add(new RecordedAnimationBlockBlock());
          RecordedAnimations[x].Read(reader);
        }
        for (x = 0; (x < _recordedAnimations.Count); x = (x + 1)) {
          RecordedAnimations[x].ReadChildData(reader);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags.Add(new ScenarioNetpointsBlockBlock());
          NetgameFlags[x].Read(reader);
        }
        for (x = 0; (x < _netgameFlags.Count); x = (x + 1)) {
          NetgameFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment.Add(new ScenarioNetgameEquipmentBlockBlock());
          NetgameEquipment[x].Read(reader);
        }
        for (x = 0; (x < _netgameEquipment.Count); x = (x + 1)) {
          NetgameEquipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment.Add(new ScenarioStartingEquipmentBlockBlock());
          StartingEquipment[x].Read(reader);
        }
        for (x = 0; (x < _startingEquipment.Count); x = (x + 1)) {
          StartingEquipment[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSPSwitchTriggerVolumes.Count); x = (x + 1)) {
          BSPSwitchTriggerVolumes.Add(new ScenarioBspSwitchTriggerVolumeBlockBlock());
          BSPSwitchTriggerVolumes[x].Read(reader);
        }
        for (x = 0; (x < _bSPSwitchTriggerVolumes.Count); x = (x + 1)) {
          BSPSwitchTriggerVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals.Add(new ScenarioDecalsBlockBlock());
          Decals[x].Read(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalsPalette.Count); x = (x + 1)) {
          DecalsPalette.Add(new ScenarioDecalPaletteBlockBlock());
          DecalsPalette[x].Read(reader);
        }
        for (x = 0; (x < _decalsPalette.Count); x = (x + 1)) {
          DecalsPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette.Add(new ScenarioDetailObjectCollectionPaletteBlockBlock());
          DetailObjectCollectionPalette[x].Read(reader);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _stylePalette.Count); x = (x + 1)) {
          StylePalette.Add(new StylePaletteBlockBlock());
          StylePalette[x].Read(reader);
        }
        for (x = 0; (x < _stylePalette.Count); x = (x + 1)) {
          StylePalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _squadGroups.Count); x = (x + 1)) {
          SquadGroups.Add(new SquadGroupsBlockBlock());
          SquadGroups[x].Read(reader);
        }
        for (x = 0; (x < _squadGroups.Count); x = (x + 1)) {
          SquadGroups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads.Add(new SquadsBlockBlock());
          Squads[x].Read(reader);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].ReadChildData(reader);
        }
        for (x = 0; (x < _zones.Count); x = (x + 1)) {
          Zones.Add(new ZoneBlockBlock());
          Zones[x].Read(reader);
        }
        for (x = 0; (x < _zones.Count); x = (x + 1)) {
          Zones[x].ReadChildData(reader);
        }
        for (x = 0; (x < _missionScenes.Count); x = (x + 1)) {
          MissionScenes.Add(new AiSceneBlockBlock());
          MissionScenes[x].Read(reader);
        }
        for (x = 0; (x < _missionScenes.Count); x = (x + 1)) {
          MissionScenes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _characterPalette.Count); x = (x + 1)) {
          CharacterPalette.Add(new CharacterPaletteBlockBlock());
          CharacterPalette[x].Read(reader);
        }
        for (x = 0; (x < _characterPalette.Count); x = (x + 1)) {
          CharacterPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIPathfindingData.Count); x = (x + 1)) {
          AIPathfindingData.Add(new PathfindingDataBlockBlock());
          AIPathfindingData[x].Read(reader);
        }
        for (x = 0; (x < _aIPathfindingData.Count); x = (x + 1)) {
          AIPathfindingData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIAnimationReferences.Count); x = (x + 1)) {
          AIAnimationReferences.Add(new AiAnimationReferenceBlockBlock());
          AIAnimationReferences[x].Read(reader);
        }
        for (x = 0; (x < _aIAnimationReferences.Count); x = (x + 1)) {
          AIAnimationReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIScriptReferences.Count); x = (x + 1)) {
          AIScriptReferences.Add(new AiScriptReferenceBlockBlock());
          AIScriptReferences[x].Read(reader);
        }
        for (x = 0; (x < _aIScriptReferences.Count); x = (x + 1)) {
          AIScriptReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIRecordingReferences.Count); x = (x + 1)) {
          AIRecordingReferences.Add(new AiRecordingReferenceBlockBlock());
          AIRecordingReferences[x].Read(reader);
        }
        for (x = 0; (x < _aIRecordingReferences.Count); x = (x + 1)) {
          AIRecordingReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIConversations.Count); x = (x + 1)) {
          AIConversations.Add(new AiConversationBlockBlock());
          AIConversations[x].Read(reader);
        }
        for (x = 0; (x < _aIConversations.Count); x = (x + 1)) {
          AIConversations[x].ReadChildData(reader);
        }
        _scriptSyntaxData.ReadBinary(reader);
        _scriptStringData.ReadBinary(reader);
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts.Add(new HsScriptsBlockBlock());
          Scripts[x].Read(reader);
        }
        for (x = 0; (x < _scripts.Count); x = (x + 1)) {
          Scripts[x].ReadChildData(reader);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals.Add(new HsGlobalsBlockBlock());
          Globals[x].Read(reader);
        }
        for (x = 0; (x < _globals.Count); x = (x + 1)) {
          Globals[x].ReadChildData(reader);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References.Add(new HsReferencesBlockBlock());
          References[x].Read(reader);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles.Add(new HsSourceFilesBlockBlock());
          SourceFiles[x].Read(reader);
        }
        for (x = 0; (x < _sourceFiles.Count); x = (x + 1)) {
          SourceFiles[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scriptingData.Count); x = (x + 1)) {
          ScriptingData.Add(new CsScriptDataBlockBlock());
          ScriptingData[x].Read(reader);
        }
        for (x = 0; (x < _scriptingData.Count); x = (x + 1)) {
          ScriptingData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags.Add(new ScenarioCutsceneFlagBlockBlock());
          CutsceneFlags[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneFlags.Count); x = (x + 1)) {
          CutsceneFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints.Add(new ScenarioCutsceneCameraPointBlockBlock());
          CutsceneCameraPoints[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneCameraPoints.Count); x = (x + 1)) {
          CutsceneCameraPoints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles.Add(new ScenarioCutsceneTitleBlockBlock());
          CutsceneTitles[x].Read(reader);
        }
        for (x = 0; (x < _cutsceneTitles.Count); x = (x + 1)) {
          CutsceneTitles[x].ReadChildData(reader);
        }
        _customObjectNames.ReadString(reader);
        _chapterTitleText.ReadString(reader);
        _hUDMessages.ReadString(reader);
        for (x = 0; (x < _structureBSPs.Count); x = (x + 1)) {
          StructureBSPs.Add(new ScenarioStructureBspReferenceBlockBlock());
          StructureBSPs[x].Read(reader);
        }
        for (x = 0; (x < _structureBSPs.Count); x = (x + 1)) {
          StructureBSPs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenarioResources.Count); x = (x + 1)) {
          ScenarioResources.Add(new ScenarioResourcesBlockBlock());
          ScenarioResources[x].Read(reader);
        }
        for (x = 0; (x < _scenarioResources.Count); x = (x + 1)) {
          ScenarioResources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenarioResources2.Count); x = (x + 1)) {
          ScenarioResources2.Add(new OldUnusedStrucurePhysicsBlockBlock());
          ScenarioResources2[x].Read(reader);
        }
        for (x = 0; (x < _scenarioResources2.Count); x = (x + 1)) {
          ScenarioResources2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _hsUnitSeats.Count); x = (x + 1)) {
          HsUnitSeats.Add(new HsUnitSeatBlockBlock());
          HsUnitSeats[x].Read(reader);
        }
        for (x = 0; (x < _hsUnitSeats.Count); x = (x + 1)) {
          HsUnitSeats[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenarioKillTriggers.Count); x = (x + 1)) {
          ScenarioKillTriggers.Add(new ScenarioKillTriggerVolumesBlockBlock());
          ScenarioKillTriggers[x].Read(reader);
        }
        for (x = 0; (x < _scenarioKillTriggers.Count); x = (x + 1)) {
          ScenarioKillTriggers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _hsSyntaxDatums.Count); x = (x + 1)) {
          HsSyntaxDatums.Add(new SyntaxDatumBlockBlock());
          HsSyntaxDatums[x].Read(reader);
        }
        for (x = 0; (x < _hsSyntaxDatums.Count); x = (x + 1)) {
          HsSyntaxDatums[x].ReadChildData(reader);
        }
        for (x = 0; (x < _orders.Count); x = (x + 1)) {
          Orders.Add(new OrdersBlockBlock());
          Orders[x].Read(reader);
        }
        for (x = 0; (x < _orders.Count); x = (x + 1)) {
          Orders[x].ReadChildData(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers.Add(new TriggersBlockBlock());
          Triggers[x].Read(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].ReadChildData(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette.Add(new StructureBspBackgroundSoundPaletteBlockBlock());
          BackgroundSoundPalette[x].Read(reader);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette.Add(new StructureBspSoundEnvironmentPaletteBlockBlock());
          SoundEnvironmentPalette[x].Read(reader);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette.Add(new StructureBspWeatherPaletteBlockBlock());
          WeatherPalette[x].Read(reader);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0.Add(new GNullBlockBlock());
          Unnamed0[x].Read(reader);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1.Add(new GNullBlockBlock());
          Unnamed1[x].Read(reader);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2.Add(new GNullBlockBlock());
          Unnamed2[x].Read(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3.Add(new GNullBlockBlock());
          Unnamed3[x].Read(reader);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4.Add(new GNullBlockBlock());
          Unnamed4[x].Read(reader);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scenarioClusterData.Count); x = (x + 1)) {
          ScenarioClusterData.Add(new ScenarioClusterDataBlockBlock());
          ScenarioClusterData[x].Read(reader);
        }
        for (x = 0; (x < _scenarioClusterData.Count); x = (x + 1)) {
          ScenarioClusterData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spawnData.Count); x = (x + 1)) {
          SpawnData.Add(new ScenarioSpawnDataBlockBlock());
          SpawnData[x].Read(reader);
        }
        for (x = 0; (x < _spawnData.Count); x = (x + 1)) {
          SpawnData[x].ReadChildData(reader);
        }
        _soundEffectCollection.ReadString(reader);
        for (x = 0; (x < _crates.Count); x = (x + 1)) {
          Crates.Add(new ScenarioCrateBlockBlock());
          Crates[x].Read(reader);
        }
        for (x = 0; (x < _crates.Count); x = (x + 1)) {
          Crates[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cratesPalette.Count); x = (x + 1)) {
          CratesPalette.Add(new ScenarioCratePaletteBlockBlock());
          CratesPalette[x].Read(reader);
        }
        for (x = 0; (x < _cratesPalette.Count); x = (x + 1)) {
          CratesPalette[x].ReadChildData(reader);
        }
        _globalLighting.ReadString(reader);
        for (x = 0; (x < _atmosphericFogPalette.Count); x = (x + 1)) {
          AtmosphericFogPalette.Add(new ScenarioAtmosphericFogPaletteBlock());
          AtmosphericFogPalette[x].Read(reader);
        }
        for (x = 0; (x < _atmosphericFogPalette.Count); x = (x + 1)) {
          AtmosphericFogPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _planarFogPalette.Count); x = (x + 1)) {
          PlanarFogPalette.Add(new ScenarioPlanarFogPaletteBlock());
          PlanarFogPalette[x].Read(reader);
        }
        for (x = 0; (x < _planarFogPalette.Count); x = (x + 1)) {
          PlanarFogPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _flocks.Count); x = (x + 1)) {
          Flocks.Add(new FlockDefinitionBlockBlock());
          Flocks[x].Read(reader);
        }
        for (x = 0; (x < _flocks.Count); x = (x + 1)) {
          Flocks[x].ReadChildData(reader);
        }
        _subtitles.ReadString(reader);
        for (x = 0; (x < _decorators.Count); x = (x + 1)) {
          Decorators.Add(new DecoratorPlacementDefinitionBlockBlock());
          Decorators[x].Read(reader);
        }
        for (x = 0; (x < _decorators.Count); x = (x + 1)) {
          Decorators[x].ReadChildData(reader);
        }
        for (x = 0; (x < _creatures.Count); x = (x + 1)) {
          Creatures.Add(new ScenarioCreatureBlockBlock());
          Creatures[x].Read(reader);
        }
        for (x = 0; (x < _creatures.Count); x = (x + 1)) {
          Creatures[x].ReadChildData(reader);
        }
        for (x = 0; (x < _creaturesPalette.Count); x = (x + 1)) {
          CreaturesPalette.Add(new ScenarioCreaturePaletteBlockBlock());
          CreaturesPalette[x].Read(reader);
        }
        for (x = 0; (x < _creaturesPalette.Count); x = (x + 1)) {
          CreaturesPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decoratorsPalette.Count); x = (x + 1)) {
          DecoratorsPalette.Add(new ScenarioDecoratorSetPaletteEntryBlockBlock());
          DecoratorsPalette[x].Read(reader);
        }
        for (x = 0; (x < _decoratorsPalette.Count); x = (x + 1)) {
          DecoratorsPalette[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bSPTransitionVolumes.Count); x = (x + 1)) {
          BSPTransitionVolumes.Add(new ScenarioBspSwitchTransitionVolumeBlockBlock());
          BSPTransitionVolumes[x].Read(reader);
        }
        for (x = 0; (x < _bSPTransitionVolumes.Count); x = (x + 1)) {
          BSPTransitionVolumes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _structureBSPLighting.Count); x = (x + 1)) {
          StructureBSPLighting.Add(new ScenarioStructureBspSphericalHarmonicLightingBlockBlock());
          StructureBSPLighting[x].Read(reader);
        }
        for (x = 0; (x < _structureBSPLighting.Count); x = (x + 1)) {
          StructureBSPLighting[x].ReadChildData(reader);
        }
        for (x = 0; (x < _editorFolders.Count); x = (x + 1)) {
          EditorFolders.Add(new GScenarioEditorFolderBlockBlock());
          EditorFolders[x].Read(reader);
        }
        for (x = 0; (x < _editorFolders.Count); x = (x + 1)) {
          EditorFolders[x].ReadChildData(reader);
        }
        for (x = 0; (x < _levelData.Count); x = (x + 1)) {
          LevelData.Add(new ScenarioLevelDataBlockBlock());
          LevelData[x].Read(reader);
        }
        for (x = 0; (x < _levelData.Count); x = (x + 1)) {
          LevelData[x].ReadChildData(reader);
        }
        _territoryLocationNames.ReadString(reader);
        for (x = 0; (x < _missionDialogue.Count); x = (x + 1)) {
          MissionDialogue.Add(new AiScenarioMissionDialogueBlockBlock());
          MissionDialogue[x].Read(reader);
        }
        for (x = 0; (x < _missionDialogue.Count); x = (x + 1)) {
          MissionDialogue[x].ReadChildData(reader);
        }
        _objectives.ReadString(reader);
        for (x = 0; (x < _interpolators.Count); x = (x + 1)) {
          Interpolators.Add(new ScenarioInterpolatorBlockBlock());
          Interpolators[x].Read(reader);
        }
        for (x = 0; (x < _interpolators.Count); x = (x + 1)) {
          Interpolators[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sharedReferences.Count); x = (x + 1)) {
          SharedReferences.Add(new HsReferencesBlockBlock());
          SharedReferences[x].Read(reader);
        }
        for (x = 0; (x < _sharedReferences.Count); x = (x + 1)) {
          SharedReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _screenEffectReferences.Count); x = (x + 1)) {
          ScreenEffectReferences.Add(new ScenarioScreenEffectReferenceBlockBlock());
          ScreenEffectReferences[x].Read(reader);
        }
        for (x = 0; (x < _screenEffectReferences.Count); x = (x + 1)) {
          ScreenEffectReferences[x].ReadChildData(reader);
        }
        for (x = 0; (x < _simulationDefinitionTable.Count); x = (x + 1)) {
          SimulationDefinitionTable.Add(new ScenarioSimulationDefinitionTableBlockBlock());
          SimulationDefinitionTable[x].Read(reader);
        }
        for (x = 0; (x < _simulationDefinitionTable.Count); x = (x + 1)) {
          SimulationDefinitionTable[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _doNotUse.Write(bw);
_skies.Count = Skies.Count;
        _skies.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
_childScenarios.Count = ChildScenarios.Count;
        _childScenarios.Write(bw);
        _localNorth.Write(bw);
_predictedResources.Count = PredictedResources.Count;
        _predictedResources.Write(bw);
_functions.Count = Functions.Count;
        _functions.Write(bw);
        _editorScenarioData.Write(bw);
_comments.Count = Comments.Count;
        _comments.Write(bw);
_emptyname.Count = Emptyname.Count;
        _emptyname.Write(bw);
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
_lightVolumes.Count = LightVolumes.Count;
        _lightVolumes.Write(bw);
_lightVolumesPalette.Count = LightVolumesPalette.Count;
        _lightVolumesPalette.Write(bw);
_playerStartingProfile.Count = PlayerStartingProfile.Count;
        _playerStartingProfile.Write(bw);
_playerStartingLocations.Count = PlayerStartingLocations.Count;
        _playerStartingLocations.Write(bw);
_killTriggerVolumes.Count = KillTriggerVolumes.Count;
        _killTriggerVolumes.Write(bw);
_recordedAnimations.Count = RecordedAnimations.Count;
        _recordedAnimations.Write(bw);
_netgameFlags.Count = NetgameFlags.Count;
        _netgameFlags.Write(bw);
_netgameEquipment.Count = NetgameEquipment.Count;
        _netgameEquipment.Write(bw);
_startingEquipment.Count = StartingEquipment.Count;
        _startingEquipment.Write(bw);
_bSPSwitchTriggerVolumes.Count = BSPSwitchTriggerVolumes.Count;
        _bSPSwitchTriggerVolumes.Write(bw);
_decals.Count = Decals.Count;
        _decals.Write(bw);
_decalsPalette.Count = DecalsPalette.Count;
        _decalsPalette.Write(bw);
_detailObjectCollectionPalette.Count = DetailObjectCollectionPalette.Count;
        _detailObjectCollectionPalette.Write(bw);
_stylePalette.Count = StylePalette.Count;
        _stylePalette.Write(bw);
_squadGroups.Count = SquadGroups.Count;
        _squadGroups.Write(bw);
_squads.Count = Squads.Count;
        _squads.Write(bw);
_zones.Count = Zones.Count;
        _zones.Write(bw);
_missionScenes.Count = MissionScenes.Count;
        _missionScenes.Write(bw);
_characterPalette.Count = CharacterPalette.Count;
        _characterPalette.Write(bw);
_aIPathfindingData.Count = AIPathfindingData.Count;
        _aIPathfindingData.Write(bw);
_aIAnimationReferences.Count = AIAnimationReferences.Count;
        _aIAnimationReferences.Write(bw);
_aIScriptReferences.Count = AIScriptReferences.Count;
        _aIScriptReferences.Write(bw);
_aIRecordingReferences.Count = AIRecordingReferences.Count;
        _aIRecordingReferences.Write(bw);
_aIConversations.Count = AIConversations.Count;
        _aIConversations.Write(bw);
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
_scriptingData.Count = ScriptingData.Count;
        _scriptingData.Write(bw);
_cutsceneFlags.Count = CutsceneFlags.Count;
        _cutsceneFlags.Write(bw);
_cutsceneCameraPoints.Count = CutsceneCameraPoints.Count;
        _cutsceneCameraPoints.Write(bw);
_cutsceneTitles.Count = CutsceneTitles.Count;
        _cutsceneTitles.Write(bw);
        _customObjectNames.Write(bw);
        _chapterTitleText.Write(bw);
        _hUDMessages.Write(bw);
_structureBSPs.Count = StructureBSPs.Count;
        _structureBSPs.Write(bw);
_scenarioResources.Count = ScenarioResources.Count;
        _scenarioResources.Write(bw);
_scenarioResources2.Count = ScenarioResources2.Count;
        _scenarioResources2.Write(bw);
_hsUnitSeats.Count = HsUnitSeats.Count;
        _hsUnitSeats.Write(bw);
_scenarioKillTriggers.Count = ScenarioKillTriggers.Count;
        _scenarioKillTriggers.Write(bw);
_hsSyntaxDatums.Count = HsSyntaxDatums.Count;
        _hsSyntaxDatums.Write(bw);
_orders.Count = Orders.Count;
        _orders.Write(bw);
_triggers.Count = Triggers.Count;
        _triggers.Write(bw);
_backgroundSoundPalette.Count = BackgroundSoundPalette.Count;
        _backgroundSoundPalette.Write(bw);
_soundEnvironmentPalette.Count = SoundEnvironmentPalette.Count;
        _soundEnvironmentPalette.Write(bw);
_weatherPalette.Count = WeatherPalette.Count;
        _weatherPalette.Write(bw);
_unnamed0.Count = Unnamed0.Count;
        _unnamed0.Write(bw);
_unnamed1.Count = Unnamed1.Count;
        _unnamed1.Write(bw);
_unnamed2.Count = Unnamed2.Count;
        _unnamed2.Write(bw);
_unnamed3.Count = Unnamed3.Count;
        _unnamed3.Write(bw);
_unnamed4.Count = Unnamed4.Count;
        _unnamed4.Write(bw);
_scenarioClusterData.Count = ScenarioClusterData.Count;
        _scenarioClusterData.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _unnamed7.Write(bw);
        _unnamed8.Write(bw);
        _unnamed9.Write(bw);
        _unnamed10.Write(bw);
        _unnamed11.Write(bw);
        _unnamed12.Write(bw);
        _unnamed13.Write(bw);
        _unnamed14.Write(bw);
        _unnamed15.Write(bw);
        _unnamed16.Write(bw);
        _unnamed17.Write(bw);
        _unnamed18.Write(bw);
        _unnamed19.Write(bw);
        _unnamed20.Write(bw);
        _unnamed21.Write(bw);
        _unnamed22.Write(bw);
        _unnamed23.Write(bw);
        _unnamed24.Write(bw);
        _unnamed25.Write(bw);
        _unnamed26.Write(bw);
        _unnamed27.Write(bw);
        _unnamed28.Write(bw);
        _unnamed29.Write(bw);
        _unnamed30.Write(bw);
        _unnamed31.Write(bw);
        _unnamed32.Write(bw);
        _unnamed33.Write(bw);
        _unnamed34.Write(bw);
        _unnamed35.Write(bw);
        _unnamed36.Write(bw);
_spawnData.Count = SpawnData.Count;
        _spawnData.Write(bw);
        _soundEffectCollection.Write(bw);
_crates.Count = Crates.Count;
        _crates.Write(bw);
_cratesPalette.Count = CratesPalette.Count;
        _cratesPalette.Write(bw);
        _globalLighting.Write(bw);
_atmosphericFogPalette.Count = AtmosphericFogPalette.Count;
        _atmosphericFogPalette.Write(bw);
_planarFogPalette.Count = PlanarFogPalette.Count;
        _planarFogPalette.Write(bw);
_flocks.Count = Flocks.Count;
        _flocks.Write(bw);
        _subtitles.Write(bw);
_decorators.Count = Decorators.Count;
        _decorators.Write(bw);
_creatures.Count = Creatures.Count;
        _creatures.Write(bw);
_creaturesPalette.Count = CreaturesPalette.Count;
        _creaturesPalette.Write(bw);
_decoratorsPalette.Count = DecoratorsPalette.Count;
        _decoratorsPalette.Write(bw);
_bSPTransitionVolumes.Count = BSPTransitionVolumes.Count;
        _bSPTransitionVolumes.Write(bw);
_structureBSPLighting.Count = StructureBSPLighting.Count;
        _structureBSPLighting.Write(bw);
_editorFolders.Count = EditorFolders.Count;
        _editorFolders.Write(bw);
_levelData.Count = LevelData.Count;
        _levelData.Write(bw);
        _territoryLocationNames.Write(bw);
        _unnamed37.Write(bw);
_missionDialogue.Count = MissionDialogue.Count;
        _missionDialogue.Write(bw);
        _objectives.Write(bw);
_interpolators.Count = Interpolators.Count;
        _interpolators.Write(bw);
_sharedReferences.Count = SharedReferences.Count;
        _sharedReferences.Write(bw);
_screenEffectReferences.Count = ScreenEffectReferences.Count;
        _screenEffectReferences.Write(bw);
_simulationDefinitionTable.Count = SimulationDefinitionTable.Count;
        _simulationDefinitionTable.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _doNotUse.WriteString(writer);
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
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].Write(writer);
        }
        for (x = 0; (x < _emptyname.Count); x = (x + 1)) {
          Emptyname[x].WriteChildData(writer);
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
        for (x = 0; (x < _lightVolumes.Count); x = (x + 1)) {
          LightVolumes[x].Write(writer);
        }
        for (x = 0; (x < _lightVolumes.Count); x = (x + 1)) {
          LightVolumes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lightVolumesPalette.Count); x = (x + 1)) {
          LightVolumesPalette[x].Write(writer);
        }
        for (x = 0; (x < _lightVolumesPalette.Count); x = (x + 1)) {
          LightVolumesPalette[x].WriteChildData(writer);
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
        for (x = 0; (x < _killTriggerVolumes.Count); x = (x + 1)) {
          KillTriggerVolumes[x].Write(writer);
        }
        for (x = 0; (x < _killTriggerVolumes.Count); x = (x + 1)) {
          KillTriggerVolumes[x].WriteChildData(writer);
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
        for (x = 0; (x < _bSPSwitchTriggerVolumes.Count); x = (x + 1)) {
          BSPSwitchTriggerVolumes[x].Write(writer);
        }
        for (x = 0; (x < _bSPSwitchTriggerVolumes.Count); x = (x + 1)) {
          BSPSwitchTriggerVolumes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].Write(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalsPalette.Count); x = (x + 1)) {
          DecalsPalette[x].Write(writer);
        }
        for (x = 0; (x < _decalsPalette.Count); x = (x + 1)) {
          DecalsPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].Write(writer);
        }
        for (x = 0; (x < _detailObjectCollectionPalette.Count); x = (x + 1)) {
          DetailObjectCollectionPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _stylePalette.Count); x = (x + 1)) {
          StylePalette[x].Write(writer);
        }
        for (x = 0; (x < _stylePalette.Count); x = (x + 1)) {
          StylePalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _squadGroups.Count); x = (x + 1)) {
          SquadGroups[x].Write(writer);
        }
        for (x = 0; (x < _squadGroups.Count); x = (x + 1)) {
          SquadGroups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].Write(writer);
        }
        for (x = 0; (x < _squads.Count); x = (x + 1)) {
          Squads[x].WriteChildData(writer);
        }
        for (x = 0; (x < _zones.Count); x = (x + 1)) {
          Zones[x].Write(writer);
        }
        for (x = 0; (x < _zones.Count); x = (x + 1)) {
          Zones[x].WriteChildData(writer);
        }
        for (x = 0; (x < _missionScenes.Count); x = (x + 1)) {
          MissionScenes[x].Write(writer);
        }
        for (x = 0; (x < _missionScenes.Count); x = (x + 1)) {
          MissionScenes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _characterPalette.Count); x = (x + 1)) {
          CharacterPalette[x].Write(writer);
        }
        for (x = 0; (x < _characterPalette.Count); x = (x + 1)) {
          CharacterPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIPathfindingData.Count); x = (x + 1)) {
          AIPathfindingData[x].Write(writer);
        }
        for (x = 0; (x < _aIPathfindingData.Count); x = (x + 1)) {
          AIPathfindingData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIAnimationReferences.Count); x = (x + 1)) {
          AIAnimationReferences[x].Write(writer);
        }
        for (x = 0; (x < _aIAnimationReferences.Count); x = (x + 1)) {
          AIAnimationReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIScriptReferences.Count); x = (x + 1)) {
          AIScriptReferences[x].Write(writer);
        }
        for (x = 0; (x < _aIScriptReferences.Count); x = (x + 1)) {
          AIScriptReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIRecordingReferences.Count); x = (x + 1)) {
          AIRecordingReferences[x].Write(writer);
        }
        for (x = 0; (x < _aIRecordingReferences.Count); x = (x + 1)) {
          AIRecordingReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIConversations.Count); x = (x + 1)) {
          AIConversations[x].Write(writer);
        }
        for (x = 0; (x < _aIConversations.Count); x = (x + 1)) {
          AIConversations[x].WriteChildData(writer);
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
        for (x = 0; (x < _scriptingData.Count); x = (x + 1)) {
          ScriptingData[x].Write(writer);
        }
        for (x = 0; (x < _scriptingData.Count); x = (x + 1)) {
          ScriptingData[x].WriteChildData(writer);
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
        _chapterTitleText.WriteString(writer);
        _hUDMessages.WriteString(writer);
        for (x = 0; (x < _structureBSPs.Count); x = (x + 1)) {
          StructureBSPs[x].Write(writer);
        }
        for (x = 0; (x < _structureBSPs.Count); x = (x + 1)) {
          StructureBSPs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scenarioResources.Count); x = (x + 1)) {
          ScenarioResources[x].Write(writer);
        }
        for (x = 0; (x < _scenarioResources.Count); x = (x + 1)) {
          ScenarioResources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scenarioResources2.Count); x = (x + 1)) {
          ScenarioResources2[x].Write(writer);
        }
        for (x = 0; (x < _scenarioResources2.Count); x = (x + 1)) {
          ScenarioResources2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _hsUnitSeats.Count); x = (x + 1)) {
          HsUnitSeats[x].Write(writer);
        }
        for (x = 0; (x < _hsUnitSeats.Count); x = (x + 1)) {
          HsUnitSeats[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scenarioKillTriggers.Count); x = (x + 1)) {
          ScenarioKillTriggers[x].Write(writer);
        }
        for (x = 0; (x < _scenarioKillTriggers.Count); x = (x + 1)) {
          ScenarioKillTriggers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _hsSyntaxDatums.Count); x = (x + 1)) {
          HsSyntaxDatums[x].Write(writer);
        }
        for (x = 0; (x < _hsSyntaxDatums.Count); x = (x + 1)) {
          HsSyntaxDatums[x].WriteChildData(writer);
        }
        for (x = 0; (x < _orders.Count); x = (x + 1)) {
          Orders[x].Write(writer);
        }
        for (x = 0; (x < _orders.Count); x = (x + 1)) {
          Orders[x].WriteChildData(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].Write(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].WriteChildData(writer);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].Write(writer);
        }
        for (x = 0; (x < _backgroundSoundPalette.Count); x = (x + 1)) {
          BackgroundSoundPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].Write(writer);
        }
        for (x = 0; (x < _soundEnvironmentPalette.Count); x = (x + 1)) {
          SoundEnvironmentPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].Write(writer);
        }
        for (x = 0; (x < _weatherPalette.Count); x = (x + 1)) {
          WeatherPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].Write(writer);
        }
        for (x = 0; (x < _unnamed0.Count); x = (x + 1)) {
          Unnamed0[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].Write(writer);
        }
        for (x = 0; (x < _unnamed1.Count); x = (x + 1)) {
          Unnamed1[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].Write(writer);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].Write(writer);
        }
        for (x = 0; (x < _unnamed3.Count); x = (x + 1)) {
          Unnamed3[x].WriteChildData(writer);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].Write(writer);
        }
        for (x = 0; (x < _unnamed4.Count); x = (x + 1)) {
          Unnamed4[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scenarioClusterData.Count); x = (x + 1)) {
          ScenarioClusterData[x].Write(writer);
        }
        for (x = 0; (x < _scenarioClusterData.Count); x = (x + 1)) {
          ScenarioClusterData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spawnData.Count); x = (x + 1)) {
          SpawnData[x].Write(writer);
        }
        for (x = 0; (x < _spawnData.Count); x = (x + 1)) {
          SpawnData[x].WriteChildData(writer);
        }
        _soundEffectCollection.WriteString(writer);
        for (x = 0; (x < _crates.Count); x = (x + 1)) {
          Crates[x].Write(writer);
        }
        for (x = 0; (x < _crates.Count); x = (x + 1)) {
          Crates[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cratesPalette.Count); x = (x + 1)) {
          CratesPalette[x].Write(writer);
        }
        for (x = 0; (x < _cratesPalette.Count); x = (x + 1)) {
          CratesPalette[x].WriteChildData(writer);
        }
        _globalLighting.WriteString(writer);
        for (x = 0; (x < _atmosphericFogPalette.Count); x = (x + 1)) {
          AtmosphericFogPalette[x].Write(writer);
        }
        for (x = 0; (x < _atmosphericFogPalette.Count); x = (x + 1)) {
          AtmosphericFogPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _planarFogPalette.Count); x = (x + 1)) {
          PlanarFogPalette[x].Write(writer);
        }
        for (x = 0; (x < _planarFogPalette.Count); x = (x + 1)) {
          PlanarFogPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _flocks.Count); x = (x + 1)) {
          Flocks[x].Write(writer);
        }
        for (x = 0; (x < _flocks.Count); x = (x + 1)) {
          Flocks[x].WriteChildData(writer);
        }
        _subtitles.WriteString(writer);
        for (x = 0; (x < _decorators.Count); x = (x + 1)) {
          Decorators[x].Write(writer);
        }
        for (x = 0; (x < _decorators.Count); x = (x + 1)) {
          Decorators[x].WriteChildData(writer);
        }
        for (x = 0; (x < _creatures.Count); x = (x + 1)) {
          Creatures[x].Write(writer);
        }
        for (x = 0; (x < _creatures.Count); x = (x + 1)) {
          Creatures[x].WriteChildData(writer);
        }
        for (x = 0; (x < _creaturesPalette.Count); x = (x + 1)) {
          CreaturesPalette[x].Write(writer);
        }
        for (x = 0; (x < _creaturesPalette.Count); x = (x + 1)) {
          CreaturesPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decoratorsPalette.Count); x = (x + 1)) {
          DecoratorsPalette[x].Write(writer);
        }
        for (x = 0; (x < _decoratorsPalette.Count); x = (x + 1)) {
          DecoratorsPalette[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bSPTransitionVolumes.Count); x = (x + 1)) {
          BSPTransitionVolumes[x].Write(writer);
        }
        for (x = 0; (x < _bSPTransitionVolumes.Count); x = (x + 1)) {
          BSPTransitionVolumes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _structureBSPLighting.Count); x = (x + 1)) {
          StructureBSPLighting[x].Write(writer);
        }
        for (x = 0; (x < _structureBSPLighting.Count); x = (x + 1)) {
          StructureBSPLighting[x].WriteChildData(writer);
        }
        for (x = 0; (x < _editorFolders.Count); x = (x + 1)) {
          EditorFolders[x].Write(writer);
        }
        for (x = 0; (x < _editorFolders.Count); x = (x + 1)) {
          EditorFolders[x].WriteChildData(writer);
        }
        for (x = 0; (x < _levelData.Count); x = (x + 1)) {
          LevelData[x].Write(writer);
        }
        for (x = 0; (x < _levelData.Count); x = (x + 1)) {
          LevelData[x].WriteChildData(writer);
        }
        _territoryLocationNames.WriteString(writer);
        for (x = 0; (x < _missionDialogue.Count); x = (x + 1)) {
          MissionDialogue[x].Write(writer);
        }
        for (x = 0; (x < _missionDialogue.Count); x = (x + 1)) {
          MissionDialogue[x].WriteChildData(writer);
        }
        _objectives.WriteString(writer);
        for (x = 0; (x < _interpolators.Count); x = (x + 1)) {
          Interpolators[x].Write(writer);
        }
        for (x = 0; (x < _interpolators.Count); x = (x + 1)) {
          Interpolators[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sharedReferences.Count); x = (x + 1)) {
          SharedReferences[x].Write(writer);
        }
        for (x = 0; (x < _sharedReferences.Count); x = (x + 1)) {
          SharedReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _screenEffectReferences.Count); x = (x + 1)) {
          ScreenEffectReferences[x].Write(writer);
        }
        for (x = 0; (x < _screenEffectReferences.Count); x = (x + 1)) {
          ScreenEffectReferences[x].WriteChildData(writer);
        }
        for (x = 0; (x < _simulationDefinitionTable.Count); x = (x + 1)) {
          SimulationDefinitionTable[x].Write(writer);
        }
        for (x = 0; (x < _simulationDefinitionTable.Count); x = (x + 1)) {
          SimulationDefinitionTable[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioSkyReferenceBlockBlock : IBlock {
      private TagReference _sky = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioSkyReferenceBlockBlock() {
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
    public class ScenarioChildScenarioBlockBlock : IBlock {
      private TagReference _childScenario = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioChildScenarioBlockBlock() {
        this._unnamed0 = new Pad(16);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _childScenario.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _childScenario.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _childScenario.WriteString(writer);
      }
    }
    public class PredictedResourceBlockBlock : IBlock {
      private Enum _type;
      private ShortInteger _resourceIndex = new ShortInteger();
      private PredictedResource _predictedResourceTag = new PredictedResource();
public event System.EventHandler BlockNameChanged;
      public PredictedResourceBlockBlock() {
        this._type = new Enum(2);
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
      public PredictedResource PredictedResourceTag {
        get {
          return this._predictedResourceTag;
        }
        set {
          this._predictedResourceTag = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _resourceIndex.Read(reader);
        _predictedResourceTag.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _predictedResourceTag.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _resourceIndex.Write(bw);
        _predictedResourceTag.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _predictedResourceTag.WriteString(writer);
      }
    }
    public class ScenarioFunctionBlockBlock : IBlock {
      private Flags _flags;
      private FixedLengthString _name = new FixedLengthString();
      private Real _period = new Real();
      private ShortBlockIndex _scalePeriodBy = new ShortBlockIndex();
      private Enum _function;
      private ShortBlockIndex _scaleFunctionBy = new ShortBlockIndex();
      private Enum _wobbleFunction;
      private Real _wobblePeriod = new Real();
      private Real _wobbleMagnitude = new Real();
      private RealFraction _squareWaveThreshold = new RealFraction();
      private ShortInteger _stepCount = new ShortInteger();
      private Enum _mapTo;
      private ShortInteger _sawtoothCount = new ShortInteger();
      private Pad _unnamed0;
      private ShortBlockIndex _scaleResultBy = new ShortBlockIndex();
      private Enum _boundsMode;
      private FractionBounds _bounds = new FractionBounds();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private ShortBlockIndex _turnOffWith = new ShortBlockIndex();
      private Pad _unnamed3;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public ScenarioFunctionBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._function = new Enum(2);
        this._wobbleFunction = new Enum(2);
        this._mapTo = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._boundsMode = new Enum(2);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(16);
        this._unnamed4 = new Pad(16);
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
      public FractionBounds Bounds {
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
        _unnamed0.Read(reader);
        _scaleResultBy.Read(reader);
        _boundsMode.Read(reader);
        _bounds.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _turnOffWith.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
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
        _unnamed0.Write(bw);
        _scaleResultBy.Write(bw);
        _boundsMode.Write(bw);
        _bounds.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _turnOffWith.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EditorCommentBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Enum _type;
      private FixedLengthString _name = new FixedLengthString();
      private LongerFixedLengthString _comment = new LongerFixedLengthString();
public event System.EventHandler BlockNameChanged;
      public EditorCommentBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._type = new Enum(4);
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
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
      public FixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public LongerFixedLengthString Comment {
        get {
          return this._comment;
        }
        set {
          this._comment = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _type.Read(reader);
        _name.Read(reader);
        _comment.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _type.Write(bw);
        _name.Write(bw);
        _comment.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DontUseMeScenarioEnvironmentObjectBlockBlock : IBlock {
      private ShortBlockIndex _bSP = new ShortBlockIndex();
      private ShortInteger _unnamed0 = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private Pad _unnamed1;
      private TagSignature _objectDefinitionTag = new TagSignature();
      private LongInteger _object = new LongInteger();
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public DontUseMeScenarioEnvironmentObjectBlockBlock() {
if (this._object is System.ComponentModel.INotifyPropertyChanged)
  (this._object as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed1 = new Pad(4);
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
return _object.ToString();
        }
      }
      public ShortBlockIndex BSP {
        get {
          return this._bSP;
        }
        set {
          this._bSP = value;
        }
      }
      public ShortInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public TagSignature ObjectDefinitionTag {
        get {
          return this._objectDefinitionTag;
        }
        set {
          this._objectDefinitionTag = value;
        }
      }
      public LongInteger Object {
        get {
          return this._object;
        }
        set {
          this._object = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bSP.Read(reader);
        _unnamed0.Read(reader);
        _uniqueID.Read(reader);
        _unnamed1.Read(reader);
        _objectDefinitionTag.Read(reader);
        _object.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bSP.Write(bw);
        _unnamed0.Write(bw);
        _uniqueID.Write(bw);
        _unnamed1.Write(bw);
        _objectDefinitionTag.Write(bw);
        _object.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioObjectNamesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _unnamed0 = new ShortBlockIndex();
      private ShortInteger _unnamed1 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ScenarioObjectNamesBlockBlock() {
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
      public ShortBlockIndex unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public ShortInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSceneryBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private StringId _variantName = new StringId();
      private Flags _activeChangeColors;
      private RGBColor _primaryColor = new RGBColor();
      private RGBColor _secondaryColor = new RGBColor();
      private RGBColor _tertiaryColor = new RGBColor();
      private RGBColor _quaternaryColor = new RGBColor();
      private Enum _pathfindingPolicy;
      private Enum _lightmappingPolicy;
      private Block _pathfindingReferences = new Block();
      private Pad _unnamed1;
      private Flags _validMultiplayerGames;
      public BlockCollection<PathfindingObjectIndexListBlockBlock> _pathfindingReferencesList = new BlockCollection<PathfindingObjectIndexListBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioSceneryBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._activeChangeColors = new Flags(4);
        this._pathfindingPolicy = new Enum(2);
        this._lightmappingPolicy = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._validMultiplayerGames = new Flags(2);
      }
      public BlockCollection<PathfindingObjectIndexListBlockBlock> PathfindingReferences {
        get {
          return this._pathfindingReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PathfindingReferences.BlockCount; x++)
{
  IBlock block = PathfindingReferences.GetBlock(x);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Flags ActiveChangeColors {
        get {
          return this._activeChangeColors;
        }
        set {
          this._activeChangeColors = value;
        }
      }
      public RGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public RGBColor TertiaryColor {
        get {
          return this._tertiaryColor;
        }
        set {
          this._tertiaryColor = value;
        }
      }
      public RGBColor QuaternaryColor {
        get {
          return this._quaternaryColor;
        }
        set {
          this._quaternaryColor = value;
        }
      }
      public Enum PathfindingPolicy {
        get {
          return this._pathfindingPolicy;
        }
        set {
          this._pathfindingPolicy = value;
        }
      }
      public Enum LightmappingPolicy {
        get {
          return this._lightmappingPolicy;
        }
        set {
          this._lightmappingPolicy = value;
        }
      }
      public Flags ValidMultiplayerGames {
        get {
          return this._validMultiplayerGames;
        }
        set {
          this._validMultiplayerGames = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _variantName.Read(reader);
        _activeChangeColors.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _tertiaryColor.Read(reader);
        _quaternaryColor.Read(reader);
        _pathfindingPolicy.Read(reader);
        _lightmappingPolicy.Read(reader);
        _pathfindingReferences.Read(reader);
        _unnamed1.Read(reader);
        _validMultiplayerGames.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _variantName.ReadString(reader);
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences.Add(new PathfindingObjectIndexListBlockBlock());
          PathfindingReferences[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _variantName.Write(bw);
        _activeChangeColors.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _tertiaryColor.Write(bw);
        _quaternaryColor.Write(bw);
        _pathfindingPolicy.Write(bw);
        _lightmappingPolicy.Write(bw);
_pathfindingReferences.Count = PathfindingReferences.Count;
        _pathfindingReferences.Write(bw);
        _unnamed1.Write(bw);
        _validMultiplayerGames.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _variantName.WriteString(writer);
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].WriteChildData(writer);
        }
      }
    }
    public class PathfindingObjectIndexListBlockBlock : IBlock {
      private ShortInteger _bSPIndex = new ShortInteger();
      private ShortInteger _pathfindingObjectIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PathfindingObjectIndexListBlockBlock() {
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
      public ShortInteger BSPIndex {
        get {
          return this._bSPIndex;
        }
        set {
          this._bSPIndex = value;
        }
      }
      public ShortInteger PathfindingObjectIndex {
        get {
          return this._pathfindingObjectIndex;
        }
        set {
          this._pathfindingObjectIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bSPIndex.Read(reader);
        _pathfindingObjectIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bSPIndex.Write(bw);
        _pathfindingObjectIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSceneryPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioSceneryPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioBipedBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private StringId _variantName = new StringId();
      private Flags _activeChangeColors;
      private RGBColor _primaryColor = new RGBColor();
      private RGBColor _secondaryColor = new RGBColor();
      private RGBColor _tertiaryColor = new RGBColor();
      private RGBColor _quaternaryColor = new RGBColor();
      private Real _bodyVitality = new Real();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public ScenarioBipedBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._activeChangeColors = new Flags(4);
        this._flags = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Flags ActiveChangeColors {
        get {
          return this._activeChangeColors;
        }
        set {
          this._activeChangeColors = value;
        }
      }
      public RGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public RGBColor TertiaryColor {
        get {
          return this._tertiaryColor;
        }
        set {
          this._tertiaryColor = value;
        }
      }
      public RGBColor QuaternaryColor {
        get {
          return this._quaternaryColor;
        }
        set {
          this._quaternaryColor = value;
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
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _variantName.Read(reader);
        _activeChangeColors.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _tertiaryColor.Read(reader);
        _quaternaryColor.Read(reader);
        _bodyVitality.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _variantName.Write(bw);
        _activeChangeColors.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _tertiaryColor.Write(bw);
        _quaternaryColor.Write(bw);
        _bodyVitality.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
      }
    }
    public class ScenarioBipedPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioBipedPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioVehicleBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private StringId _variantName = new StringId();
      private Flags _activeChangeColors;
      private RGBColor _primaryColor = new RGBColor();
      private RGBColor _secondaryColor = new RGBColor();
      private RGBColor _tertiaryColor = new RGBColor();
      private RGBColor _quaternaryColor = new RGBColor();
      private Real _bodyVitality = new Real();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public ScenarioVehicleBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._activeChangeColors = new Flags(4);
        this._flags = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Flags ActiveChangeColors {
        get {
          return this._activeChangeColors;
        }
        set {
          this._activeChangeColors = value;
        }
      }
      public RGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public RGBColor TertiaryColor {
        get {
          return this._tertiaryColor;
        }
        set {
          this._tertiaryColor = value;
        }
      }
      public RGBColor QuaternaryColor {
        get {
          return this._quaternaryColor;
        }
        set {
          this._quaternaryColor = value;
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
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _variantName.Read(reader);
        _activeChangeColors.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _tertiaryColor.Read(reader);
        _quaternaryColor.Read(reader);
        _bodyVitality.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _variantName.Write(bw);
        _activeChangeColors.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _tertiaryColor.Write(bw);
        _quaternaryColor.Write(bw);
        _bodyVitality.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
      }
    }
    public class ScenarioVehiclePaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioVehiclePaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioEquipmentBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private Flags _equipmentFlags;
public event System.EventHandler BlockNameChanged;
      public ScenarioEquipmentBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._equipmentFlags = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public Flags EquipmentFlags {
        get {
          return this._equipmentFlags;
        }
        set {
          this._equipmentFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _equipmentFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _equipmentFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioEquipmentPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioEquipmentPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioWeaponBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private StringId _variantName = new StringId();
      private Flags _activeChangeColors;
      private RGBColor _primaryColor = new RGBColor();
      private RGBColor _secondaryColor = new RGBColor();
      private RGBColor _tertiaryColor = new RGBColor();
      private RGBColor _quaternaryColor = new RGBColor();
      private ShortInteger _roundsLeft = new ShortInteger();
      private ShortInteger _roundsLoaded = new ShortInteger();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public ScenarioWeaponBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._activeChangeColors = new Flags(4);
        this._flags = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Flags ActiveChangeColors {
        get {
          return this._activeChangeColors;
        }
        set {
          this._activeChangeColors = value;
        }
      }
      public RGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public RGBColor TertiaryColor {
        get {
          return this._tertiaryColor;
        }
        set {
          this._tertiaryColor = value;
        }
      }
      public RGBColor QuaternaryColor {
        get {
          return this._quaternaryColor;
        }
        set {
          this._quaternaryColor = value;
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
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _variantName.Read(reader);
        _activeChangeColors.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _tertiaryColor.Read(reader);
        _quaternaryColor.Read(reader);
        _roundsLeft.Read(reader);
        _roundsLoaded.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _variantName.Write(bw);
        _activeChangeColors.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _tertiaryColor.Write(bw);
        _quaternaryColor.Write(bw);
        _roundsLeft.Write(bw);
        _roundsLoaded.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
      }
    }
    public class ScenarioWeaponPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioWeaponPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class DeviceGroupBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Real _initialValue = new Real();
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public DeviceGroupBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _initialValue.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioMachineBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private Flags _flags2;
      private Block _pathfindingReferences = new Block();
      public BlockCollection<PathfindingObjectIndexListBlockBlock> _pathfindingReferencesList = new BlockCollection<PathfindingObjectIndexListBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioMachineBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._flags = new Flags(4);
        this._flags2 = new Flags(4);
      }
      public BlockCollection<PathfindingObjectIndexListBlockBlock> PathfindingReferences {
        get {
          return this._pathfindingReferencesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PathfindingReferences.BlockCount; x++)
{
  IBlock block = PathfindingReferences.GetBlock(x);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
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
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _flags2.Read(reader);
        _pathfindingReferences.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences.Add(new PathfindingObjectIndexListBlockBlock());
          PathfindingReferences[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _flags2.Write(bw);
_pathfindingReferences.Count = PathfindingReferences.Count;
        _pathfindingReferences.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingReferences.Count); x = (x + 1)) {
          PathfindingReferences[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioMachinePaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioMachinePaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioControlBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private Flags _flags2;
      private ShortInteger _dONTTOUCHTHIS = new ShortInteger();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ScenarioControlBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._flags = new Flags(4);
        this._flags2 = new Flags(4);
        this._unnamed1 = new Pad(2);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
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
      public ShortInteger DONTTOUCHTHIS {
        get {
          return this._dONTTOUCHTHIS;
        }
        set {
          this._dONTTOUCHTHIS = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _flags2.Read(reader);
        _dONTTOUCHTHIS.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _flags2.Write(bw);
        _dONTTOUCHTHIS.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioControlPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioControlPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioLightFixtureBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private RealRGBColor _color = new RealRGBColor();
      private Real _intensity = new Real();
      private Angle _falloffAngle = new Angle();
      private Angle _cutoffAngle = new Angle();
public event System.EventHandler BlockNameChanged;
      public ScenarioLightFixtureBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._flags = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
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
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _color.Read(reader);
        _intensity.Read(reader);
        _falloffAngle.Read(reader);
        _cutoffAngle.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _color.Write(bw);
        _intensity.Write(bw);
        _falloffAngle.Write(bw);
        _cutoffAngle.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioLightFixturePaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioLightFixturePaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioSoundSceneryBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private Enum _volumeType;
      private Real _height = new Real();
      private RealBounds _overrideDistanceBounds = new RealBounds();
      private AngleBounds _overrideConeAngleBounds = new AngleBounds();
      private Real _overrideOuterConeGain = new Real();
public event System.EventHandler BlockNameChanged;
      public ScenarioSoundSceneryBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._volumeType = new Enum(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public Enum VolumeType {
        get {
          return this._volumeType;
        }
        set {
          this._volumeType = value;
        }
      }
      public Real Height {
        get {
          return this._height;
        }
        set {
          this._height = value;
        }
      }
      public RealBounds OverrideDistanceBounds {
        get {
          return this._overrideDistanceBounds;
        }
        set {
          this._overrideDistanceBounds = value;
        }
      }
      public AngleBounds OverrideConeAngleBounds {
        get {
          return this._overrideConeAngleBounds;
        }
        set {
          this._overrideConeAngleBounds = value;
        }
      }
      public Real OverrideOuterConeGain {
        get {
          return this._overrideOuterConeGain;
        }
        set {
          this._overrideOuterConeGain = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _volumeType.Read(reader);
        _height.Read(reader);
        _overrideDistanceBounds.Read(reader);
        _overrideConeAngleBounds.Read(reader);
        _overrideOuterConeGain.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _volumeType.Write(bw);
        _height.Write(bw);
        _overrideDistanceBounds.Write(bw);
        _overrideConeAngleBounds.Write(bw);
        _overrideOuterConeGain.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSoundSceneryPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioSoundSceneryPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioLightBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private ShortBlockIndex _powerGroup = new ShortBlockIndex();
      private ShortBlockIndex _positionGroup = new ShortBlockIndex();
      private Flags _flags;
      private Enum _type3;
      private Flags _flags2;
      private Enum _lightmapType;
      private Flags _lightmapFlags;
      private Real _lightmapHalfLife = new Real();
      private Real _lightmapLightScale = new Real();
      private RealPoint3D _targetPoint = new RealPoint3D();
      private Real _width = new Real();
      private Real _heightScale = new Real();
      private Angle _fieldOfView = new Angle();
      private Real _falloffDistance = new Real();
      private Real _cutoffDistance = new Real();
public event System.EventHandler BlockNameChanged;
      public ScenarioLightBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._flags = new Flags(4);
        this._type3 = new Enum(2);
        this._flags2 = new Flags(2);
        this._lightmapType = new Enum(2);
        this._lightmapFlags = new Flags(2);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
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
      public Enum Type3 {
        get {
          return this._type3;
        }
        set {
          this._type3 = value;
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
      public Enum LightmapType {
        get {
          return this._lightmapType;
        }
        set {
          this._lightmapType = value;
        }
      }
      public Flags LightmapFlags {
        get {
          return this._lightmapFlags;
        }
        set {
          this._lightmapFlags = value;
        }
      }
      public Real LightmapHalfLife {
        get {
          return this._lightmapHalfLife;
        }
        set {
          this._lightmapHalfLife = value;
        }
      }
      public Real LightmapLightScale {
        get {
          return this._lightmapLightScale;
        }
        set {
          this._lightmapLightScale = value;
        }
      }
      public RealPoint3D TargetPoint {
        get {
          return this._targetPoint;
        }
        set {
          this._targetPoint = value;
        }
      }
      public Real Width {
        get {
          return this._width;
        }
        set {
          this._width = value;
        }
      }
      public Real HeightScale {
        get {
          return this._heightScale;
        }
        set {
          this._heightScale = value;
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
      public Real FalloffDistance {
        get {
          return this._falloffDistance;
        }
        set {
          this._falloffDistance = value;
        }
      }
      public Real CutoffDistance {
        get {
          return this._cutoffDistance;
        }
        set {
          this._cutoffDistance = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _powerGroup.Read(reader);
        _positionGroup.Read(reader);
        _flags.Read(reader);
        _type3.Read(reader);
        _flags2.Read(reader);
        _lightmapType.Read(reader);
        _lightmapFlags.Read(reader);
        _lightmapHalfLife.Read(reader);
        _lightmapLightScale.Read(reader);
        _targetPoint.Read(reader);
        _width.Read(reader);
        _heightScale.Read(reader);
        _fieldOfView.Read(reader);
        _falloffDistance.Read(reader);
        _cutoffDistance.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _powerGroup.Write(bw);
        _positionGroup.Write(bw);
        _flags.Write(bw);
        _type3.Write(bw);
        _flags2.Write(bw);
        _lightmapType.Write(bw);
        _lightmapFlags.Write(bw);
        _lightmapHalfLife.Write(bw);
        _lightmapLightScale.Write(bw);
        _targetPoint.Write(bw);
        _width.Write(bw);
        _heightScale.Write(bw);
        _fieldOfView.Write(bw);
        _falloffDistance.Write(bw);
        _cutoffDistance.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioLightPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioLightPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioProfilesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealFraction _startingHealthDamage = new RealFraction();
      private RealFraction _startingShieldDamage = new RealFraction();
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
public event System.EventHandler BlockNameChanged;
      public ScenarioProfilesBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
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
      public RealFraction StartingHealthDamage {
        get {
          return this._startingHealthDamage;
        }
        set {
          this._startingHealthDamage = value;
        }
      }
      public RealFraction StartingShieldDamage {
        get {
          return this._startingShieldDamage;
        }
        set {
          this._startingShieldDamage = value;
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
        _startingHealthDamage.Read(reader);
        _startingShieldDamage.Read(reader);
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _primaryWeapon.ReadString(reader);
        _secondaryWeapon.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _startingHealthDamage.Write(bw);
        _startingShieldDamage.Write(bw);
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
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _primaryWeapon.WriteString(writer);
        _secondaryWeapon.WriteString(writer);
      }
    }
    public class ScenarioPlayersBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private Enum _teamDesignator;
      private ShortInteger _bSPIndex = new ShortInteger();
      private Enum _gameType1;
      private Enum _gameType2;
      private Enum _gameType3;
      private Enum _gameType4;
      private Enum _spawnType0;
      private Enum _spawnType1;
      private Enum _spawnType2;
      private Enum _spawnType3;
      private StringId _unnamed0 = new StringId();
      private StringId _unnamed1 = new StringId();
      private Enum _campaignPlayerType;
      private Pad _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioPlayersBlockBlock() {
        this._teamDesignator = new Enum(2);
        this._gameType1 = new Enum(2);
        this._gameType2 = new Enum(2);
        this._gameType3 = new Enum(2);
        this._gameType4 = new Enum(2);
        this._spawnType0 = new Enum(2);
        this._spawnType1 = new Enum(2);
        this._spawnType2 = new Enum(2);
        this._spawnType3 = new Enum(2);
        this._campaignPlayerType = new Enum(2);
        this._unnamed2 = new Pad(6);
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
      public Enum TeamDesignator {
        get {
          return this._teamDesignator;
        }
        set {
          this._teamDesignator = value;
        }
      }
      public ShortInteger BSPIndex {
        get {
          return this._bSPIndex;
        }
        set {
          this._bSPIndex = value;
        }
      }
      public Enum GameType1 {
        get {
          return this._gameType1;
        }
        set {
          this._gameType1 = value;
        }
      }
      public Enum GameType2 {
        get {
          return this._gameType2;
        }
        set {
          this._gameType2 = value;
        }
      }
      public Enum GameType3 {
        get {
          return this._gameType3;
        }
        set {
          this._gameType3 = value;
        }
      }
      public Enum GameType4 {
        get {
          return this._gameType4;
        }
        set {
          this._gameType4 = value;
        }
      }
      public Enum SpawnType0 {
        get {
          return this._spawnType0;
        }
        set {
          this._spawnType0 = value;
        }
      }
      public Enum SpawnType1 {
        get {
          return this._spawnType1;
        }
        set {
          this._spawnType1 = value;
        }
      }
      public Enum SpawnType2 {
        get {
          return this._spawnType2;
        }
        set {
          this._spawnType2 = value;
        }
      }
      public Enum SpawnType3 {
        get {
          return this._spawnType3;
        }
        set {
          this._spawnType3 = value;
        }
      }
      public StringId unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public StringId unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public Enum CampaignPlayerType {
        get {
          return this._campaignPlayerType;
        }
        set {
          this._campaignPlayerType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _teamDesignator.Read(reader);
        _bSPIndex.Read(reader);
        _gameType1.Read(reader);
        _gameType2.Read(reader);
        _gameType3.Read(reader);
        _gameType4.Read(reader);
        _spawnType0.Read(reader);
        _spawnType1.Read(reader);
        _spawnType2.Read(reader);
        _spawnType3.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _campaignPlayerType.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unnamed0.ReadString(reader);
        _unnamed1.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _teamDesignator.Write(bw);
        _bSPIndex.Write(bw);
        _gameType1.Write(bw);
        _gameType2.Write(bw);
        _gameType3.Write(bw);
        _gameType4.Write(bw);
        _spawnType0.Write(bw);
        _spawnType1.Write(bw);
        _spawnType2.Write(bw);
        _spawnType3.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _campaignPlayerType.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unnamed0.WriteString(writer);
        _unnamed1.WriteString(writer);
      }
    }
    public class ScenarioTriggerVolumeBlockBlock : IBlock {
      private StringId _name = new StringId();
      private ShortBlockIndex _objectName = new ShortBlockIndex();
      private Skip _unnamed0;
      private StringId _nodeName = new StringId();
      private Real _unnamed1 = new Real();
      private Real _unnamed2 = new Real();
      private Real _unnamed3 = new Real();
      private Real _unnamed4 = new Real();
      private Real _unnamed5 = new Real();
      private Real _unnamed6 = new Real();
      private RealPoint3D _position = new RealPoint3D();
      private RealPoint3D _extents = new RealPoint3D();
      private Pad _unnamed7;
      private ShortBlockIndex _killTriggerVolume = new ShortBlockIndex();
      private Pad _unnamed8;
public event System.EventHandler BlockNameChanged;
      public ScenarioTriggerVolumeBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Skip(2);
        this._unnamed7 = new Pad(4);
        this._unnamed8 = new Pad(2);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public StringId NodeName {
        get {
          return this._nodeName;
        }
        set {
          this._nodeName = value;
        }
      }
      public Real unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public Real unnamed2 {
        get {
          return this._unnamed2;
        }
        set {
          this._unnamed2 = value;
        }
      }
      public Real unnamed3 {
        get {
          return this._unnamed3;
        }
        set {
          this._unnamed3 = value;
        }
      }
      public Real unnamed4 {
        get {
          return this._unnamed4;
        }
        set {
          this._unnamed4 = value;
        }
      }
      public Real unnamed5 {
        get {
          return this._unnamed5;
        }
        set {
          this._unnamed5 = value;
        }
      }
      public Real unnamed6 {
        get {
          return this._unnamed6;
        }
        set {
          this._unnamed6 = value;
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
      public RealPoint3D Extents {
        get {
          return this._extents;
        }
        set {
          this._extents = value;
        }
      }
      public ShortBlockIndex KillTriggerVolume {
        get {
          return this._killTriggerVolume;
        }
        set {
          this._killTriggerVolume = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _objectName.Read(reader);
        _unnamed0.Read(reader);
        _nodeName.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
        _unnamed5.Read(reader);
        _unnamed6.Read(reader);
        _position.Read(reader);
        _extents.Read(reader);
        _unnamed7.Read(reader);
        _killTriggerVolume.Read(reader);
        _unnamed8.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _nodeName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _objectName.Write(bw);
        _unnamed0.Write(bw);
        _nodeName.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
        _unnamed5.Write(bw);
        _unnamed6.Write(bw);
        _position.Write(bw);
        _extents.Write(bw);
        _unnamed7.Write(bw);
        _killTriggerVolume.Write(bw);
        _unnamed8.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _nodeName.WriteString(writer);
      }
    }
    public class RecordedAnimationBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private CharInteger _version = new CharInteger();
      private CharInteger _rawAnimationData = new CharInteger();
      private CharInteger _unitControlDataVersion = new CharInteger();
      private Pad _unnamed0;
      private ShortInteger _lengthOfAnimation = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Data _recordedAnimationEventStream = new Data();
public event System.EventHandler BlockNameChanged;
      public RecordedAnimationBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(1);
        this._unnamed1 = new Pad(2);
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
        _unnamed0.Read(reader);
        _lengthOfAnimation.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
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
        _unnamed0.Write(bw);
        _lengthOfAnimation.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _recordedAnimationEventStream.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _recordedAnimationEventStream.WriteBinary(writer);
      }
    }
    public class ScenarioNetpointsBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private Angle _facing = new Angle();
      private Enum _type;
      private Enum _teamDesignator;
      private ShortInteger _identifier = new ShortInteger();
      private Flags _flags;
      private StringId _unnamed0 = new StringId();
      private StringId _unnamed1 = new StringId();
public event System.EventHandler BlockNameChanged;
      public ScenarioNetpointsBlockBlock() {
        this._type = new Enum(2);
        this._teamDesignator = new Enum(2);
        this._flags = new Flags(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public Enum TeamDesignator {
        get {
          return this._teamDesignator;
        }
        set {
          this._teamDesignator = value;
        }
      }
      public ShortInteger Identifier {
        get {
          return this._identifier;
        }
        set {
          this._identifier = value;
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
      public StringId unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public StringId unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _facing.Read(reader);
        _type.Read(reader);
        _teamDesignator.Read(reader);
        _identifier.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _unnamed0.ReadString(reader);
        _unnamed1.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _facing.Write(bw);
        _type.Write(bw);
        _teamDesignator.Write(bw);
        _identifier.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _unnamed0.WriteString(writer);
        _unnamed1.WriteString(writer);
      }
    }
    public class ScenarioNetgameEquipmentBlockBlock : IBlock {
      private Flags _flags;
      private Enum _gameType1;
      private Enum _gameType2;
      private Enum _gameType3;
      private Enum _gameType4;
      private Pad _unnamed0;
      private ShortInteger _spawnTimeInSeconds0Default = new ShortInteger();
      private ShortInteger _respawnOnEmptyTime = new ShortInteger();
      private Enum _respawnTimerStarts;
      private Enum _classification;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _orientation = new RealEulerAngles3D();
      private TagReference _itemVehicleCollection = new TagReference();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public ScenarioNetgameEquipmentBlockBlock() {
        this._flags = new Flags(4);
        this._gameType1 = new Enum(2);
        this._gameType2 = new Enum(2);
        this._gameType3 = new Enum(2);
        this._gameType4 = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._respawnTimerStarts = new Enum(2);
        this._classification = new Enum(1);
        this._unnamed1 = new Pad(3);
        this._unnamed2 = new Pad(40);
        this._unnamed3 = new Pad(48);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_itemVehicleCollection.Value);
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
      public Enum GameType1 {
        get {
          return this._gameType1;
        }
        set {
          this._gameType1 = value;
        }
      }
      public Enum GameType2 {
        get {
          return this._gameType2;
        }
        set {
          this._gameType2 = value;
        }
      }
      public Enum GameType3 {
        get {
          return this._gameType3;
        }
        set {
          this._gameType3 = value;
        }
      }
      public Enum GameType4 {
        get {
          return this._gameType4;
        }
        set {
          this._gameType4 = value;
        }
      }
      public ShortInteger SpawnTimeInSeconds0Default {
        get {
          return this._spawnTimeInSeconds0Default;
        }
        set {
          this._spawnTimeInSeconds0Default = value;
        }
      }
      public ShortInteger RespawnOnEmptyTime {
        get {
          return this._respawnOnEmptyTime;
        }
        set {
          this._respawnOnEmptyTime = value;
        }
      }
      public Enum RespawnTimerStarts {
        get {
          return this._respawnTimerStarts;
        }
        set {
          this._respawnTimerStarts = value;
        }
      }
      public Enum Classification {
        get {
          return this._classification;
        }
        set {
          this._classification = value;
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
      public TagReference ItemVehicleCollection {
        get {
          return this._itemVehicleCollection;
        }
        set {
          this._itemVehicleCollection = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _gameType1.Read(reader);
        _gameType2.Read(reader);
        _gameType3.Read(reader);
        _gameType4.Read(reader);
        _unnamed0.Read(reader);
        _spawnTimeInSeconds0Default.Read(reader);
        _respawnOnEmptyTime.Read(reader);
        _respawnTimerStarts.Read(reader);
        _classification.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _position.Read(reader);
        _orientation.Read(reader);
        _itemVehicleCollection.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _itemVehicleCollection.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _gameType1.Write(bw);
        _gameType2.Write(bw);
        _gameType3.Write(bw);
        _gameType4.Write(bw);
        _unnamed0.Write(bw);
        _spawnTimeInSeconds0Default.Write(bw);
        _respawnOnEmptyTime.Write(bw);
        _respawnTimerStarts.Write(bw);
        _classification.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _position.Write(bw);
        _orientation.Write(bw);
        _itemVehicleCollection.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _itemVehicleCollection.WriteString(writer);
      }
    }
    public class ScenarioStartingEquipmentBlockBlock : IBlock {
      private Flags _flags;
      private Enum _gameType1;
      private Enum _gameType2;
      private Enum _gameType3;
      private Enum _gameType4;
      private Pad _unnamed0;
      private TagReference _itemCollection1 = new TagReference();
      private TagReference _itemCollection2 = new TagReference();
      private TagReference _itemCollection3 = new TagReference();
      private TagReference _itemCollection4 = new TagReference();
      private TagReference _itemCollection5 = new TagReference();
      private TagReference _itemCollection6 = new TagReference();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ScenarioStartingEquipmentBlockBlock() {
        this._flags = new Flags(4);
        this._gameType1 = new Enum(2);
        this._gameType2 = new Enum(2);
        this._gameType3 = new Enum(2);
        this._gameType4 = new Enum(2);
        this._unnamed0 = new Pad(48);
        this._unnamed1 = new Pad(48);
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
      public Enum GameType1 {
        get {
          return this._gameType1;
        }
        set {
          this._gameType1 = value;
        }
      }
      public Enum GameType2 {
        get {
          return this._gameType2;
        }
        set {
          this._gameType2 = value;
        }
      }
      public Enum GameType3 {
        get {
          return this._gameType3;
        }
        set {
          this._gameType3 = value;
        }
      }
      public Enum GameType4 {
        get {
          return this._gameType4;
        }
        set {
          this._gameType4 = value;
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
        _gameType1.Read(reader);
        _gameType2.Read(reader);
        _gameType3.Read(reader);
        _gameType4.Read(reader);
        _unnamed0.Read(reader);
        _itemCollection1.Read(reader);
        _itemCollection2.Read(reader);
        _itemCollection3.Read(reader);
        _itemCollection4.Read(reader);
        _itemCollection5.Read(reader);
        _itemCollection6.Read(reader);
        _unnamed1.Read(reader);
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
        _gameType1.Write(bw);
        _gameType2.Write(bw);
        _gameType3.Write(bw);
        _gameType4.Write(bw);
        _unnamed0.Write(bw);
        _itemCollection1.Write(bw);
        _itemCollection2.Write(bw);
        _itemCollection3.Write(bw);
        _itemCollection4.Write(bw);
        _itemCollection5.Write(bw);
        _itemCollection6.Write(bw);
        _unnamed1.Write(bw);
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
    public class ScenarioBspSwitchTriggerVolumeBlockBlock : IBlock {
      private ShortBlockIndex _triggerVolume = new ShortBlockIndex();
      private ShortInteger _source = new ShortInteger();
      private ShortInteger _destination = new ShortInteger();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public ScenarioBspSwitchTriggerVolumeBlockBlock() {
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
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
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _triggerVolume.Write(bw);
        _source.Write(bw);
        _destination.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioDecalsBlockBlock : IBlock {
      private ShortBlockIndex _decalType = new ShortBlockIndex();
      private CharInteger _yaw_Minus127127 = new CharInteger();
      private CharInteger _pitch_Minus127127 = new CharInteger();
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScenarioDecalsBlockBlock() {
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
      public CharInteger Yaw_Minus127127 {
        get {
          return this._yaw_Minus127127;
        }
        set {
          this._yaw_Minus127127 = value;
        }
      }
      public CharInteger Pitch_Minus127127 {
        get {
          return this._pitch_Minus127127;
        }
        set {
          this._pitch_Minus127127 = value;
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
        _yaw_Minus127127.Read(reader);
        _pitch_Minus127127.Read(reader);
        _position.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decalType.Write(bw);
        _yaw_Minus127127.Write(bw);
        _pitch_Minus127127.Write(bw);
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioDecalPaletteBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioDecalPaletteBlockBlock() {
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
    public class ScenarioDetailObjectCollectionPaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioDetailObjectCollectionPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class StylePaletteBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public StylePaletteBlockBlock() {
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
    public class SquadGroupsBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _parent = new ShortBlockIndex();
      private ShortBlockIndex _initialOrders = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public SquadGroupsBlockBlock() {
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
      public ShortBlockIndex Parent {
        get {
          return this._parent;
        }
        set {
          this._parent = value;
        }
      }
      public ShortBlockIndex InitialOrders {
        get {
          return this._initialOrders;
        }
        set {
          this._initialOrders = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _parent.Read(reader);
        _initialOrders.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _parent.Write(bw);
        _initialOrders.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SquadsBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Enum _team;
      private ShortBlockIndex _parent = new ShortBlockIndex();
      private Real _squadDelayTime = new Real();
      private ShortInteger _normalDiffCount = new ShortInteger();
      private ShortInteger _insaneDiffCount = new ShortInteger();
      private Enum _majorUpgrade;
      private Pad _unnamed0;
      private ShortBlockIndex _vehicleType = new ShortBlockIndex();
      private ShortBlockIndex _characterType = new ShortBlockIndex();
      private ShortBlockIndex _initialZone = new ShortBlockIndex();
      private Pad _unnamed1;
      private ShortBlockIndex _initialWeapon = new ShortBlockIndex();
      private ShortBlockIndex _initialSecondaryWeapon = new ShortBlockIndex();
      private Enum _grenadeType;
      private ShortBlockIndex _initialOrder = new ShortBlockIndex();
      private StringId _vehicleVariant = new StringId();
      private Block _startingLocations = new Block();
      private FixedLengthString _placementScript = new FixedLengthString();
      private Skip _unnamed2;
      private Pad _unnamed3;
      public BlockCollection<ActorStartingLocationsBlockBlock> _startingLocationsList = new BlockCollection<ActorStartingLocationsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public SquadsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._team = new Enum(2);
        this._majorUpgrade = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._grenadeType = new Enum(2);
        this._unnamed2 = new Skip(2);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<ActorStartingLocationsBlockBlock> StartingLocations {
        get {
          return this._startingLocationsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public Enum Team {
        get {
          return this._team;
        }
        set {
          this._team = value;
        }
      }
      public ShortBlockIndex Parent {
        get {
          return this._parent;
        }
        set {
          this._parent = value;
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
      public ShortBlockIndex VehicleType {
        get {
          return this._vehicleType;
        }
        set {
          this._vehicleType = value;
        }
      }
      public ShortBlockIndex CharacterType {
        get {
          return this._characterType;
        }
        set {
          this._characterType = value;
        }
      }
      public ShortBlockIndex InitialZone {
        get {
          return this._initialZone;
        }
        set {
          this._initialZone = value;
        }
      }
      public ShortBlockIndex InitialWeapon {
        get {
          return this._initialWeapon;
        }
        set {
          this._initialWeapon = value;
        }
      }
      public ShortBlockIndex InitialSecondaryWeapon {
        get {
          return this._initialSecondaryWeapon;
        }
        set {
          this._initialSecondaryWeapon = value;
        }
      }
      public Enum GrenadeType {
        get {
          return this._grenadeType;
        }
        set {
          this._grenadeType = value;
        }
      }
      public ShortBlockIndex InitialOrder {
        get {
          return this._initialOrder;
        }
        set {
          this._initialOrder = value;
        }
      }
      public StringId VehicleVariant {
        get {
          return this._vehicleVariant;
        }
        set {
          this._vehicleVariant = value;
        }
      }
      public FixedLengthString PlacementScript {
        get {
          return this._placementScript;
        }
        set {
          this._placementScript = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _team.Read(reader);
        _parent.Read(reader);
        _squadDelayTime.Read(reader);
        _normalDiffCount.Read(reader);
        _insaneDiffCount.Read(reader);
        _majorUpgrade.Read(reader);
        _unnamed0.Read(reader);
        _vehicleType.Read(reader);
        _characterType.Read(reader);
        _initialZone.Read(reader);
        _unnamed1.Read(reader);
        _initialWeapon.Read(reader);
        _initialSecondaryWeapon.Read(reader);
        _grenadeType.Read(reader);
        _initialOrder.Read(reader);
        _vehicleVariant.Read(reader);
        _startingLocations.Read(reader);
        _placementScript.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _vehicleVariant.ReadString(reader);
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations.Add(new ActorStartingLocationsBlockBlock());
          StartingLocations[x].Read(reader);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _team.Write(bw);
        _parent.Write(bw);
        _squadDelayTime.Write(bw);
        _normalDiffCount.Write(bw);
        _insaneDiffCount.Write(bw);
        _majorUpgrade.Write(bw);
        _unnamed0.Write(bw);
        _vehicleType.Write(bw);
        _characterType.Write(bw);
        _initialZone.Write(bw);
        _unnamed1.Write(bw);
        _initialWeapon.Write(bw);
        _initialSecondaryWeapon.Write(bw);
        _grenadeType.Write(bw);
        _initialOrder.Write(bw);
        _vehicleVariant.Write(bw);
_startingLocations.Count = StartingLocations.Count;
        _startingLocations.Write(bw);
        _placementScript.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _vehicleVariant.WriteString(writer);
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].Write(writer);
        }
        for (x = 0; (x < _startingLocations.Count); x = (x + 1)) {
          StartingLocations[x].WriteChildData(writer);
        }
      }
    }
    public class ActorStartingLocationsBlockBlock : IBlock {
      private StringId _name = new StringId();
      private RealPoint3D _position = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealEulerAngles2D _facingYawPitch = new RealEulerAngles2D();
      private Flags _flags;
      private ShortBlockIndex _characterType = new ShortBlockIndex();
      private ShortBlockIndex _initialWeapon = new ShortBlockIndex();
      private ShortBlockIndex _initialSecondaryWeapon = new ShortBlockIndex();
      private Pad _unnamed1;
      private ShortBlockIndex _vehicleType = new ShortBlockIndex();
      private Enum _seatType;
      private Enum _grenadeType;
      private ShortInteger _swarmCount = new ShortInteger();
      private StringId _actorVariantName = new StringId();
      private StringId _vehicleVariantName = new StringId();
      private Real _initialMovementDistance = new Real();
      private ShortBlockIndex _emitterVehicle = new ShortBlockIndex();
      private Enum _initialMovementMode;
      private FixedLengthString _placementScript = new FixedLengthString();
      private Skip _unnamed2;
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public ActorStartingLocationsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(4);
        this._unnamed1 = new Pad(2);
        this._seatType = new Enum(2);
        this._grenadeType = new Enum(2);
        this._initialMovementMode = new Enum(2);
        this._unnamed2 = new Skip(2);
        this._unnamed3 = new Pad(2);
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
      public StringId Name {
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
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealEulerAngles2D FacingYawPitch {
        get {
          return this._facingYawPitch;
        }
        set {
          this._facingYawPitch = value;
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
      public ShortBlockIndex CharacterType {
        get {
          return this._characterType;
        }
        set {
          this._characterType = value;
        }
      }
      public ShortBlockIndex InitialWeapon {
        get {
          return this._initialWeapon;
        }
        set {
          this._initialWeapon = value;
        }
      }
      public ShortBlockIndex InitialSecondaryWeapon {
        get {
          return this._initialSecondaryWeapon;
        }
        set {
          this._initialSecondaryWeapon = value;
        }
      }
      public ShortBlockIndex VehicleType {
        get {
          return this._vehicleType;
        }
        set {
          this._vehicleType = value;
        }
      }
      public Enum SeatType {
        get {
          return this._seatType;
        }
        set {
          this._seatType = value;
        }
      }
      public Enum GrenadeType {
        get {
          return this._grenadeType;
        }
        set {
          this._grenadeType = value;
        }
      }
      public ShortInteger SwarmCount {
        get {
          return this._swarmCount;
        }
        set {
          this._swarmCount = value;
        }
      }
      public StringId ActorVariantName {
        get {
          return this._actorVariantName;
        }
        set {
          this._actorVariantName = value;
        }
      }
      public StringId VehicleVariantName {
        get {
          return this._vehicleVariantName;
        }
        set {
          this._vehicleVariantName = value;
        }
      }
      public Real InitialMovementDistance {
        get {
          return this._initialMovementDistance;
        }
        set {
          this._initialMovementDistance = value;
        }
      }
      public ShortBlockIndex EmitterVehicle {
        get {
          return this._emitterVehicle;
        }
        set {
          this._emitterVehicle = value;
        }
      }
      public Enum InitialMovementMode {
        get {
          return this._initialMovementMode;
        }
        set {
          this._initialMovementMode = value;
        }
      }
      public FixedLengthString PlacementScript {
        get {
          return this._placementScript;
        }
        set {
          this._placementScript = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _position.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _facingYawPitch.Read(reader);
        _flags.Read(reader);
        _characterType.Read(reader);
        _initialWeapon.Read(reader);
        _initialSecondaryWeapon.Read(reader);
        _unnamed1.Read(reader);
        _vehicleType.Read(reader);
        _seatType.Read(reader);
        _grenadeType.Read(reader);
        _swarmCount.Read(reader);
        _actorVariantName.Read(reader);
        _vehicleVariantName.Read(reader);
        _initialMovementDistance.Read(reader);
        _emitterVehicle.Read(reader);
        _initialMovementMode.Read(reader);
        _placementScript.Read(reader);
        _unnamed2.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _actorVariantName.ReadString(reader);
        _vehicleVariantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _position.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _facingYawPitch.Write(bw);
        _flags.Write(bw);
        _characterType.Write(bw);
        _initialWeapon.Write(bw);
        _initialSecondaryWeapon.Write(bw);
        _unnamed1.Write(bw);
        _vehicleType.Write(bw);
        _seatType.Write(bw);
        _grenadeType.Write(bw);
        _swarmCount.Write(bw);
        _actorVariantName.Write(bw);
        _vehicleVariantName.Write(bw);
        _initialMovementDistance.Write(bw);
        _emitterVehicle.Write(bw);
        _initialMovementMode.Write(bw);
        _placementScript.Write(bw);
        _unnamed2.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _actorVariantName.WriteString(writer);
        _vehicleVariantName.WriteString(writer);
      }
    }
    public class ZoneBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private ShortBlockIndex _manualBsp = new ShortBlockIndex();
      private Pad _unnamed0;
      private Block _firingPositions = new Block();
      private Block _areas = new Block();
      public BlockCollection<FiringPositionsBlockBlock> _firingPositionsList = new BlockCollection<FiringPositionsBlockBlock>();
      public BlockCollection<AreasBlockBlock> _areasList = new BlockCollection<AreasBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ZoneBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<FiringPositionsBlockBlock> FiringPositions {
        get {
          return this._firingPositionsList;
        }
      }
      public BlockCollection<AreasBlockBlock> Areas {
        get {
          return this._areasList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<FiringPositions.BlockCount; x++)
{
  IBlock block = FiringPositions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Areas.BlockCount; x++)
{
  IBlock block = Areas.GetBlock(x);
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
      public ShortBlockIndex ManualBsp {
        get {
          return this._manualBsp;
        }
        set {
          this._manualBsp = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _manualBsp.Read(reader);
        _unnamed0.Read(reader);
        _firingPositions.Read(reader);
        _areas.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions.Add(new FiringPositionsBlockBlock());
          FiringPositions[x].Read(reader);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _areas.Count); x = (x + 1)) {
          Areas.Add(new AreasBlockBlock());
          Areas[x].Read(reader);
        }
        for (x = 0; (x < _areas.Count); x = (x + 1)) {
          Areas[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _manualBsp.Write(bw);
        _unnamed0.Write(bw);
_firingPositions.Count = FiringPositions.Count;
        _firingPositions.Write(bw);
_areas.Count = Areas.Count;
        _areas.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].Write(writer);
        }
        for (x = 0; (x < _firingPositions.Count); x = (x + 1)) {
          FiringPositions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _areas.Count); x = (x + 1)) {
          Areas[x].Write(writer);
        }
        for (x = 0; (x < _areas.Count); x = (x + 1)) {
          Areas[x].WriteChildData(writer);
        }
      }
    }
    public class FiringPositionsBlockBlock : IBlock {
      private RealPoint3D _positionLocal = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Flags _flags;
      private ShortBlockIndex _area = new ShortBlockIndex();
      private ShortInteger _clusterIndex = new ShortInteger();
      private Skip _unnamed0;
      private RealEulerAngles2D _normal = new RealEulerAngles2D();
public event System.EventHandler BlockNameChanged;
      public FiringPositionsBlockBlock() {
if (this._area is System.ComponentModel.INotifyPropertyChanged)
  (this._area as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Skip(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _area.ToString();
        }
      }
      public RealPoint3D PositionLocal {
        get {
          return this._positionLocal;
        }
        set {
          this._positionLocal = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
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
      public ShortBlockIndex Area {
        get {
          return this._area;
        }
        set {
          this._area = value;
        }
      }
      public ShortInteger ClusterIndex {
        get {
          return this._clusterIndex;
        }
        set {
          this._clusterIndex = value;
        }
      }
      public RealEulerAngles2D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _positionLocal.Read(reader);
        _referenceFrame.Read(reader);
        _flags.Read(reader);
        _area.Read(reader);
        _clusterIndex.Read(reader);
        _unnamed0.Read(reader);
        _normal.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _positionLocal.Write(bw);
        _referenceFrame.Write(bw);
        _flags.Write(bw);
        _area.Write(bw);
        _clusterIndex.Write(bw);
        _unnamed0.Write(bw);
        _normal.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AreasBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _areaFlags;
      private Skip _unnamed0;
      private Skip _unnamed1;
      private Pad _unnamed2;
      private ShortInteger _manualReferenceFrame = new ShortInteger();
      private Pad _unnamed3;
      private Block _flighthints = new Block();
      public BlockCollection<FlightReferenceBlockBlock> _flighthintsList = new BlockCollection<FlightReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AreasBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._areaFlags = new Flags(4);
        this._unnamed0 = new Skip(20);
        this._unnamed1 = new Skip(4);
        this._unnamed2 = new Pad(64);
        this._unnamed3 = new Pad(2);
      }
      public BlockCollection<FlightReferenceBlockBlock> Flighthints {
        get {
          return this._flighthintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Flighthints.BlockCount; x++)
{
  IBlock block = Flighthints.GetBlock(x);
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
      public Flags AreaFlags {
        get {
          return this._areaFlags;
        }
        set {
          this._areaFlags = value;
        }
      }
      public ShortInteger ManualReferenceFrame {
        get {
          return this._manualReferenceFrame;
        }
        set {
          this._manualReferenceFrame = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _areaFlags.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _manualReferenceFrame.Read(reader);
        _unnamed3.Read(reader);
        _flighthints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _flighthints.Count); x = (x + 1)) {
          Flighthints.Add(new FlightReferenceBlockBlock());
          Flighthints[x].Read(reader);
        }
        for (x = 0; (x < _flighthints.Count); x = (x + 1)) {
          Flighthints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _areaFlags.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _manualReferenceFrame.Write(bw);
        _unnamed3.Write(bw);
_flighthints.Count = Flighthints.Count;
        _flighthints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _flighthints.Count); x = (x + 1)) {
          Flighthints[x].Write(writer);
        }
        for (x = 0; (x < _flighthints.Count); x = (x + 1)) {
          Flighthints[x].WriteChildData(writer);
        }
      }
    }
    public class FlightReferenceBlockBlock : IBlock {
      private ShortInteger _flightHintIndex = new ShortInteger();
      private ShortInteger _poitIndex = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public FlightReferenceBlockBlock() {
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
      public ShortInteger FlightHintIndex {
        get {
          return this._flightHintIndex;
        }
        set {
          this._flightHintIndex = value;
        }
      }
      public ShortInteger PoitIndex {
        get {
          return this._poitIndex;
        }
        set {
          this._poitIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flightHintIndex.Read(reader);
        _poitIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flightHintIndex.Write(bw);
        _poitIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiSceneBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _flags;
      private Block _triggerConditions = new Block();
      private Block _roles = new Block();
      public BlockCollection<AiSceneTriggerBlockBlock> _triggerConditionsList = new BlockCollection<AiSceneTriggerBlockBlock>();
      public BlockCollection<AiSceneRoleBlockBlock> _rolesList = new BlockCollection<AiSceneRoleBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiSceneBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
      }
      public BlockCollection<AiSceneTriggerBlockBlock> TriggerConditions {
        get {
          return this._triggerConditionsList;
        }
      }
      public BlockCollection<AiSceneRoleBlockBlock> Roles {
        get {
          return this._rolesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<TriggerConditions.BlockCount; x++)
{
  IBlock block = TriggerConditions.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Roles.BlockCount; x++)
{
  IBlock block = Roles.GetBlock(x);
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
      public StringId Name {
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _triggerConditions.Read(reader);
        _roles.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _triggerConditions.Count); x = (x + 1)) {
          TriggerConditions.Add(new AiSceneTriggerBlockBlock());
          TriggerConditions[x].Read(reader);
        }
        for (x = 0; (x < _triggerConditions.Count); x = (x + 1)) {
          TriggerConditions[x].ReadChildData(reader);
        }
        for (x = 0; (x < _roles.Count); x = (x + 1)) {
          Roles.Add(new AiSceneRoleBlockBlock());
          Roles[x].Read(reader);
        }
        for (x = 0; (x < _roles.Count); x = (x + 1)) {
          Roles[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
_triggerConditions.Count = TriggerConditions.Count;
        _triggerConditions.Write(bw);
_roles.Count = Roles.Count;
        _roles.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _triggerConditions.Count); x = (x + 1)) {
          TriggerConditions[x].Write(writer);
        }
        for (x = 0; (x < _triggerConditions.Count); x = (x + 1)) {
          TriggerConditions[x].WriteChildData(writer);
        }
        for (x = 0; (x < _roles.Count); x = (x + 1)) {
          Roles[x].Write(writer);
        }
        for (x = 0; (x < _roles.Count); x = (x + 1)) {
          Roles[x].WriteChildData(writer);
        }
      }
    }
    public class AiSceneTriggerBlockBlock : IBlock {
      private Enum _combinationRule;
      private Pad _unnamed0;
      private Block _triggers = new Block();
      public BlockCollection<TriggerReferencesBlock> _triggersList = new BlockCollection<TriggerReferencesBlock>();
public event System.EventHandler BlockNameChanged;
      public AiSceneTriggerBlockBlock() {
        this._combinationRule = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<TriggerReferencesBlock> Triggers {
        get {
          return this._triggersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Triggers.BlockCount; x++)
{
  IBlock block = Triggers.GetBlock(x);
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
      public Enum CombinationRule {
        get {
          return this._combinationRule;
        }
        set {
          this._combinationRule = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _combinationRule.Read(reader);
        _unnamed0.Read(reader);
        _triggers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers.Add(new TriggerReferencesBlock());
          Triggers[x].Read(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _combinationRule.Write(bw);
        _unnamed0.Write(bw);
_triggers.Count = Triggers.Count;
        _triggers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].Write(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].WriteChildData(writer);
        }
      }
    }
    public class TriggerReferencesBlock : IBlock {
      private Flags _triggerFlags;
      private ShortBlockIndex _trigger = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public TriggerReferencesBlock() {
if (this._trigger is System.ComponentModel.INotifyPropertyChanged)
  (this._trigger as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._triggerFlags = new Flags(4);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _trigger.ToString();
        }
      }
      public Flags TriggerFlags {
        get {
          return this._triggerFlags;
        }
        set {
          this._triggerFlags = value;
        }
      }
      public ShortBlockIndex Trigger {
        get {
          return this._trigger;
        }
        set {
          this._trigger = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _triggerFlags.Read(reader);
        _trigger.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _triggerFlags.Write(bw);
        _trigger.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiSceneRoleBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Enum _group;
      private Pad _unnamed0;
      private Block _roleVariants = new Block();
      public BlockCollection<AiSceneRoleVariantsBlockBlock> _roleVariantsList = new BlockCollection<AiSceneRoleVariantsBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiSceneRoleBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._group = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<AiSceneRoleVariantsBlockBlock> RoleVariants {
        get {
          return this._roleVariantsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<RoleVariants.BlockCount; x++)
{
  IBlock block = RoleVariants.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Enum Group {
        get {
          return this._group;
        }
        set {
          this._group = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _group.Read(reader);
        _unnamed0.Read(reader);
        _roleVariants.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        for (x = 0; (x < _roleVariants.Count); x = (x + 1)) {
          RoleVariants.Add(new AiSceneRoleVariantsBlockBlock());
          RoleVariants[x].Read(reader);
        }
        for (x = 0; (x < _roleVariants.Count); x = (x + 1)) {
          RoleVariants[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _group.Write(bw);
        _unnamed0.Write(bw);
_roleVariants.Count = RoleVariants.Count;
        _roleVariants.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        for (x = 0; (x < _roleVariants.Count); x = (x + 1)) {
          RoleVariants[x].Write(writer);
        }
        for (x = 0; (x < _roleVariants.Count); x = (x + 1)) {
          RoleVariants[x].WriteChildData(writer);
        }
      }
    }
    public class AiSceneRoleVariantsBlockBlock : IBlock {
      private StringId _variantDesignation = new StringId();
public event System.EventHandler BlockNameChanged;
      public AiSceneRoleVariantsBlockBlock() {
if (this._variantDesignation is System.ComponentModel.INotifyPropertyChanged)
  (this._variantDesignation as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
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
return _variantDesignation.ToString();
        }
      }
      public StringId VariantDesignation {
        get {
          return this._variantDesignation;
        }
        set {
          this._variantDesignation = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _variantDesignation.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantDesignation.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _variantDesignation.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantDesignation.WriteString(writer);
      }
    }
    public class CharacterPaletteBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public CharacterPaletteBlockBlock() {
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
    public class PathfindingDataBlockBlock : IBlock {
      private Block _sectors = new Block();
      private Block _links = new Block();
      private Block _refs = new Block();
      private Block _bsp2dNodes = new Block();
      private Block _surfaceFlags = new Block();
      private Block _vertices = new Block();
      private Block _objectRefs = new Block();
      private Block _pathfindingHints = new Block();
      private Block _instancedGeometryRefs = new Block();
      private LongInteger _structureChecksum = new LongInteger();
      private Pad _unnamed0;
      private Block _user_MinusplacedHints = new Block();
      public BlockCollection<SectorBlockBlock> _sectorsList = new BlockCollection<SectorBlockBlock>();
      public BlockCollection<SectorLinkBlockBlock> _linksList = new BlockCollection<SectorLinkBlockBlock>();
      public BlockCollection<RefBlockBlock> _refsList = new BlockCollection<RefBlockBlock>();
      public BlockCollection<SectorBsp2dNodesBlockBlock> _bsp2dNodesList = new BlockCollection<SectorBsp2dNodesBlockBlock>();
      public BlockCollection<SurfaceFlagsBlockBlock> _surfaceFlagsList = new BlockCollection<SurfaceFlagsBlockBlock>();
      public BlockCollection<SectorVertexBlockBlock> _verticesList = new BlockCollection<SectorVertexBlockBlock>();
      public BlockCollection<EnvironmentObjectRefsBlock> _objectRefsList = new BlockCollection<EnvironmentObjectRefsBlock>();
      public BlockCollection<PathfindingHintsBlockBlock> _pathfindingHintsList = new BlockCollection<PathfindingHintsBlockBlock>();
      public BlockCollection<InstancedGeometryReferenceBlockBlock> _instancedGeometryRefsList = new BlockCollection<InstancedGeometryReferenceBlockBlock>();
      public BlockCollection<UserHintBlockBlock> _user_MinusplacedHintsList = new BlockCollection<UserHintBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public PathfindingDataBlockBlock() {
        this._unnamed0 = new Pad(32);
      }
      public BlockCollection<SectorBlockBlock> Sectors {
        get {
          return this._sectorsList;
        }
      }
      public BlockCollection<SectorLinkBlockBlock> Links {
        get {
          return this._linksList;
        }
      }
      public BlockCollection<RefBlockBlock> Refs {
        get {
          return this._refsList;
        }
      }
      public BlockCollection<SectorBsp2dNodesBlockBlock> Bsp2dNodes {
        get {
          return this._bsp2dNodesList;
        }
      }
      public BlockCollection<SurfaceFlagsBlockBlock> SurfaceFlags {
        get {
          return this._surfaceFlagsList;
        }
      }
      public BlockCollection<SectorVertexBlockBlock> Vertices {
        get {
          return this._verticesList;
        }
      }
      public BlockCollection<EnvironmentObjectRefsBlock> ObjectRefs {
        get {
          return this._objectRefsList;
        }
      }
      public BlockCollection<PathfindingHintsBlockBlock> PathfindingHints {
        get {
          return this._pathfindingHintsList;
        }
      }
      public BlockCollection<InstancedGeometryReferenceBlockBlock> InstancedGeometryRefs {
        get {
          return this._instancedGeometryRefsList;
        }
      }
      public BlockCollection<UserHintBlockBlock> User_MinusplacedHints {
        get {
          return this._user_MinusplacedHintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Sectors.BlockCount; x++)
{
  IBlock block = Sectors.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Links.BlockCount; x++)
{
  IBlock block = Links.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Refs.BlockCount; x++)
{
  IBlock block = Refs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Bsp2dNodes.BlockCount; x++)
{
  IBlock block = Bsp2dNodes.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SurfaceFlags.BlockCount; x++)
{
  IBlock block = SurfaceFlags.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Vertices.BlockCount; x++)
{
  IBlock block = Vertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ObjectRefs.BlockCount; x++)
{
  IBlock block = ObjectRefs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PathfindingHints.BlockCount; x++)
{
  IBlock block = PathfindingHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<InstancedGeometryRefs.BlockCount; x++)
{
  IBlock block = InstancedGeometryRefs.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<User_MinusplacedHints.BlockCount; x++)
{
  IBlock block = User_MinusplacedHints.GetBlock(x);
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
      public LongInteger StructureChecksum {
        get {
          return this._structureChecksum;
        }
        set {
          this._structureChecksum = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _sectors.Read(reader);
        _links.Read(reader);
        _refs.Read(reader);
        _bsp2dNodes.Read(reader);
        _surfaceFlags.Read(reader);
        _vertices.Read(reader);
        _objectRefs.Read(reader);
        _pathfindingHints.Read(reader);
        _instancedGeometryRefs.Read(reader);
        _structureChecksum.Read(reader);
        _unnamed0.Read(reader);
        _user_MinusplacedHints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors.Add(new SectorBlockBlock());
          Sectors[x].Read(reader);
        }
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].ReadChildData(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links.Add(new SectorLinkBlockBlock());
          Links[x].Read(reader);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].ReadChildData(reader);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs.Add(new RefBlockBlock());
          Refs[x].Read(reader);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes.Add(new SectorBsp2dNodesBlockBlock());
          Bsp2dNodes[x].Read(reader);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].ReadChildData(reader);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags.Add(new SurfaceFlagsBlockBlock());
          SurfaceFlags[x].Read(reader);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].ReadChildData(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices.Add(new SectorVertexBlockBlock());
          Vertices[x].Read(reader);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs.Add(new EnvironmentObjectRefsBlock());
          ObjectRefs[x].Read(reader);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints.Add(new PathfindingHintsBlockBlock());
          PathfindingHints[x].Read(reader);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs.Add(new InstancedGeometryReferenceBlockBlock());
          InstancedGeometryRefs[x].Read(reader);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].ReadChildData(reader);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints.Add(new UserHintBlockBlock());
          User_MinusplacedHints[x].Read(reader);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_sectors.Count = Sectors.Count;
        _sectors.Write(bw);
_links.Count = Links.Count;
        _links.Write(bw);
_refs.Count = Refs.Count;
        _refs.Write(bw);
_bsp2dNodes.Count = Bsp2dNodes.Count;
        _bsp2dNodes.Write(bw);
_surfaceFlags.Count = SurfaceFlags.Count;
        _surfaceFlags.Write(bw);
_vertices.Count = Vertices.Count;
        _vertices.Write(bw);
_objectRefs.Count = ObjectRefs.Count;
        _objectRefs.Write(bw);
_pathfindingHints.Count = PathfindingHints.Count;
        _pathfindingHints.Write(bw);
_instancedGeometryRefs.Count = InstancedGeometryRefs.Count;
        _instancedGeometryRefs.Write(bw);
        _structureChecksum.Write(bw);
        _unnamed0.Write(bw);
_user_MinusplacedHints.Count = User_MinusplacedHints.Count;
        _user_MinusplacedHints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].Write(writer);
        }
        for (x = 0; (x < _sectors.Count); x = (x + 1)) {
          Sectors[x].WriteChildData(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].Write(writer);
        }
        for (x = 0; (x < _links.Count); x = (x + 1)) {
          Links[x].WriteChildData(writer);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].Write(writer);
        }
        for (x = 0; (x < _refs.Count); x = (x + 1)) {
          Refs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].Write(writer);
        }
        for (x = 0; (x < _bsp2dNodes.Count); x = (x + 1)) {
          Bsp2dNodes[x].WriteChildData(writer);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].Write(writer);
        }
        for (x = 0; (x < _surfaceFlags.Count); x = (x + 1)) {
          SurfaceFlags[x].WriteChildData(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].Write(writer);
        }
        for (x = 0; (x < _vertices.Count); x = (x + 1)) {
          Vertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].Write(writer);
        }
        for (x = 0; (x < _objectRefs.Count); x = (x + 1)) {
          ObjectRefs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].Write(writer);
        }
        for (x = 0; (x < _pathfindingHints.Count); x = (x + 1)) {
          PathfindingHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].Write(writer);
        }
        for (x = 0; (x < _instancedGeometryRefs.Count); x = (x + 1)) {
          InstancedGeometryRefs[x].WriteChildData(writer);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].Write(writer);
        }
        for (x = 0; (x < _user_MinusplacedHints.Count); x = (x + 1)) {
          User_MinusplacedHints[x].WriteChildData(writer);
        }
      }
    }
    public class SectorBlockBlock : IBlock {
      private Flags _path_MinusfindingSectorFlags;
      private ShortInteger _hintIndex = new ShortInteger();
      private LongInteger _firstLinkDoNotSetManually = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SectorBlockBlock() {
        this._path_MinusfindingSectorFlags = new Flags(2);
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
      public Flags Path_MinusfindingSectorFlags {
        get {
          return this._path_MinusfindingSectorFlags;
        }
        set {
          this._path_MinusfindingSectorFlags = value;
        }
      }
      public ShortInteger HintIndex {
        get {
          return this._hintIndex;
        }
        set {
          this._hintIndex = value;
        }
      }
      public LongInteger FirstLinkDoNotSetManually {
        get {
          return this._firstLinkDoNotSetManually;
        }
        set {
          this._firstLinkDoNotSetManually = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _path_MinusfindingSectorFlags.Read(reader);
        _hintIndex.Read(reader);
        _firstLinkDoNotSetManually.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _path_MinusfindingSectorFlags.Write(bw);
        _hintIndex.Write(bw);
        _firstLinkDoNotSetManually.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorLinkBlockBlock : IBlock {
      private ShortInteger _vertex1 = new ShortInteger();
      private ShortInteger _vertex2 = new ShortInteger();
      private Flags _linkFlags;
      private ShortInteger _hintIndex = new ShortInteger();
      private ShortInteger _forwardLink = new ShortInteger();
      private ShortInteger _reverseLink = new ShortInteger();
      private ShortInteger _leftSector = new ShortInteger();
      private ShortInteger _rightSector = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SectorLinkBlockBlock() {
        this._linkFlags = new Flags(2);
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
      public ShortInteger Vertex1 {
        get {
          return this._vertex1;
        }
        set {
          this._vertex1 = value;
        }
      }
      public ShortInteger Vertex2 {
        get {
          return this._vertex2;
        }
        set {
          this._vertex2 = value;
        }
      }
      public Flags LinkFlags {
        get {
          return this._linkFlags;
        }
        set {
          this._linkFlags = value;
        }
      }
      public ShortInteger HintIndex {
        get {
          return this._hintIndex;
        }
        set {
          this._hintIndex = value;
        }
      }
      public ShortInteger ForwardLink {
        get {
          return this._forwardLink;
        }
        set {
          this._forwardLink = value;
        }
      }
      public ShortInteger ReverseLink {
        get {
          return this._reverseLink;
        }
        set {
          this._reverseLink = value;
        }
      }
      public ShortInteger LeftSector {
        get {
          return this._leftSector;
        }
        set {
          this._leftSector = value;
        }
      }
      public ShortInteger RightSector {
        get {
          return this._rightSector;
        }
        set {
          this._rightSector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _vertex1.Read(reader);
        _vertex2.Read(reader);
        _linkFlags.Read(reader);
        _hintIndex.Read(reader);
        _forwardLink.Read(reader);
        _reverseLink.Read(reader);
        _leftSector.Read(reader);
        _rightSector.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _vertex1.Write(bw);
        _vertex2.Write(bw);
        _linkFlags.Write(bw);
        _hintIndex.Write(bw);
        _forwardLink.Write(bw);
        _reverseLink.Write(bw);
        _leftSector.Write(bw);
        _rightSector.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class RefBlockBlock : IBlock {
      private LongInteger _nodeRefOrSectorRef = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public RefBlockBlock() {
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
      public LongInteger NodeRefOrSectorRef {
        get {
          return this._nodeRefOrSectorRef;
        }
        set {
          this._nodeRefOrSectorRef = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nodeRefOrSectorRef.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _nodeRefOrSectorRef.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorBsp2dNodesBlockBlock : IBlock {
      private RealPlane2D _plane = new RealPlane2D();
      private LongInteger _leftChild = new LongInteger();
      private LongInteger _rightChild = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SectorBsp2dNodesBlockBlock() {
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
      public RealPlane2D Plane {
        get {
          return this._plane;
        }
        set {
          this._plane = value;
        }
      }
      public LongInteger LeftChild {
        get {
          return this._leftChild;
        }
        set {
          this._leftChild = value;
        }
      }
      public LongInteger RightChild {
        get {
          return this._rightChild;
        }
        set {
          this._rightChild = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _plane.Read(reader);
        _leftChild.Read(reader);
        _rightChild.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _plane.Write(bw);
        _leftChild.Write(bw);
        _rightChild.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SurfaceFlagsBlockBlock : IBlock {
      private LongInteger _flags = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SurfaceFlagsBlockBlock() {
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
      public LongInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SectorVertexBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public SectorVertexBlockBlock() {
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EnvironmentObjectRefsBlock : IBlock {
      private Flags _flags;
      private Pad _unnamed0;
      private LongInteger _firstSector = new LongInteger();
      private LongInteger _lastSector = new LongInteger();
      private Block _bsps = new Block();
      private Block _nodes = new Block();
      public BlockCollection<EnvironmentObjectBspRefsBlock> _bspsList = new BlockCollection<EnvironmentObjectBspRefsBlock>();
      public BlockCollection<EnvironmentObjectNodesBlock> _nodesList = new BlockCollection<EnvironmentObjectNodesBlock>();
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectRefsBlock() {
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<EnvironmentObjectBspRefsBlock> Bsps {
        get {
          return this._bspsList;
        }
      }
      public BlockCollection<EnvironmentObjectNodesBlock> Nodes {
        get {
          return this._nodesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Bsps.BlockCount; x++)
{
  IBlock block = Bsps.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Nodes.BlockCount; x++)
{
  IBlock block = Nodes.GetBlock(x);
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
      public Flags Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public LongInteger FirstSector {
        get {
          return this._firstSector;
        }
        set {
          this._firstSector = value;
        }
      }
      public LongInteger LastSector {
        get {
          return this._lastSector;
        }
        set {
          this._lastSector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _firstSector.Read(reader);
        _lastSector.Read(reader);
        _bsps.Read(reader);
        _nodes.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps.Add(new EnvironmentObjectBspRefsBlock());
          Bsps[x].Read(reader);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].ReadChildData(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes.Add(new EnvironmentObjectNodesBlock());
          Nodes[x].Read(reader);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _firstSector.Write(bw);
        _lastSector.Write(bw);
_bsps.Count = Bsps.Count;
        _bsps.Write(bw);
_nodes.Count = Nodes.Count;
        _nodes.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].Write(writer);
        }
        for (x = 0; (x < _bsps.Count); x = (x + 1)) {
          Bsps[x].WriteChildData(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].Write(writer);
        }
        for (x = 0; (x < _nodes.Count); x = (x + 1)) {
          Nodes[x].WriteChildData(writer);
        }
      }
    }
    public class EnvironmentObjectBspRefsBlock : IBlock {
      private LongInteger _bspReference = new LongInteger();
      private LongInteger _firstSector = new LongInteger();
      private LongInteger _lastSector = new LongInteger();
      private ShortInteger _nodeindex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectBspRefsBlock() {
        this._unnamed0 = new Pad(2);
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
      public LongInteger BspReference {
        get {
          return this._bspReference;
        }
        set {
          this._bspReference = value;
        }
      }
      public LongInteger FirstSector {
        get {
          return this._firstSector;
        }
        set {
          this._firstSector = value;
        }
      }
      public LongInteger LastSector {
        get {
          return this._lastSector;
        }
        set {
          this._lastSector = value;
        }
      }
      public ShortInteger Nodeindex {
        get {
          return this._nodeindex;
        }
        set {
          this._nodeindex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bspReference.Read(reader);
        _firstSector.Read(reader);
        _lastSector.Read(reader);
        _nodeindex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bspReference.Write(bw);
        _firstSector.Write(bw);
        _lastSector.Write(bw);
        _nodeindex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class EnvironmentObjectNodesBlock : IBlock {
      private ShortInteger _referenceFrameIndex = new ShortInteger();
      private CharInteger _projectionAxis = new CharInteger();
      private Flags _projectionSign;
public event System.EventHandler BlockNameChanged;
      public EnvironmentObjectNodesBlock() {
        this._projectionSign = new Flags(1);
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
      public ShortInteger ReferenceFrameIndex {
        get {
          return this._referenceFrameIndex;
        }
        set {
          this._referenceFrameIndex = value;
        }
      }
      public CharInteger ProjectionAxis {
        get {
          return this._projectionAxis;
        }
        set {
          this._projectionAxis = value;
        }
      }
      public Flags ProjectionSign {
        get {
          return this._projectionSign;
        }
        set {
          this._projectionSign = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _referenceFrameIndex.Read(reader);
        _projectionAxis.Read(reader);
        _projectionSign.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _referenceFrameIndex.Write(bw);
        _projectionAxis.Write(bw);
        _projectionSign.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class PathfindingHintsBlockBlock : IBlock {
      private Enum _hintType;
      private ShortInteger _nextHintIndex = new ShortInteger();
      private ShortInteger _hintData0 = new ShortInteger();
      private ShortInteger _hintData1 = new ShortInteger();
      private ShortInteger _hintData2 = new ShortInteger();
      private ShortInteger _hintData3 = new ShortInteger();
      private ShortInteger _hintData4 = new ShortInteger();
      private ShortInteger _hintData5 = new ShortInteger();
      private ShortInteger _hintData6 = new ShortInteger();
      private ShortInteger _hintData7 = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public PathfindingHintsBlockBlock() {
        this._hintType = new Enum(2);
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
      public Enum HintType {
        get {
          return this._hintType;
        }
        set {
          this._hintType = value;
        }
      }
      public ShortInteger NextHintIndex {
        get {
          return this._nextHintIndex;
        }
        set {
          this._nextHintIndex = value;
        }
      }
      public ShortInteger HintData0 {
        get {
          return this._hintData0;
        }
        set {
          this._hintData0 = value;
        }
      }
      public ShortInteger HintData1 {
        get {
          return this._hintData1;
        }
        set {
          this._hintData1 = value;
        }
      }
      public ShortInteger HintData2 {
        get {
          return this._hintData2;
        }
        set {
          this._hintData2 = value;
        }
      }
      public ShortInteger HintData3 {
        get {
          return this._hintData3;
        }
        set {
          this._hintData3 = value;
        }
      }
      public ShortInteger HintData4 {
        get {
          return this._hintData4;
        }
        set {
          this._hintData4 = value;
        }
      }
      public ShortInteger HintData5 {
        get {
          return this._hintData5;
        }
        set {
          this._hintData5 = value;
        }
      }
      public ShortInteger HintData6 {
        get {
          return this._hintData6;
        }
        set {
          this._hintData6 = value;
        }
      }
      public ShortInteger HintData7 {
        get {
          return this._hintData7;
        }
        set {
          this._hintData7 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _hintType.Read(reader);
        _nextHintIndex.Read(reader);
        _hintData0.Read(reader);
        _hintData1.Read(reader);
        _hintData2.Read(reader);
        _hintData3.Read(reader);
        _hintData4.Read(reader);
        _hintData5.Read(reader);
        _hintData6.Read(reader);
        _hintData7.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _hintType.Write(bw);
        _nextHintIndex.Write(bw);
        _hintData0.Write(bw);
        _hintData1.Write(bw);
        _hintData2.Write(bw);
        _hintData3.Write(bw);
        _hintData4.Write(bw);
        _hintData5.Write(bw);
        _hintData6.Write(bw);
        _hintData7.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class InstancedGeometryReferenceBlockBlock : IBlock {
      private ShortInteger _pathfindingObjectindex = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public InstancedGeometryReferenceBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public ShortInteger PathfindingObjectindex {
        get {
          return this._pathfindingObjectindex;
        }
        set {
          this._pathfindingObjectindex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _pathfindingObjectindex.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _pathfindingObjectindex.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintBlockBlock : IBlock {
      private Block _pointGeometry = new Block();
      private Block _rayGeometry = new Block();
      private Block _lineSegmentGeometry = new Block();
      private Block _parallelogramGeometry = new Block();
      private Block _polygonGeometry = new Block();
      private Block _jumpHints = new Block();
      private Block _climbHints = new Block();
      private Block _wellHints = new Block();
      private Block _flightHints = new Block();
      public BlockCollection<UserHintPointBlockBlock> _pointGeometryList = new BlockCollection<UserHintPointBlockBlock>();
      public BlockCollection<UserHintRayBlockBlock> _rayGeometryList = new BlockCollection<UserHintRayBlockBlock>();
      public BlockCollection<UserHintLineSegmentBlockBlock> _lineSegmentGeometryList = new BlockCollection<UserHintLineSegmentBlockBlock>();
      public BlockCollection<UserHintParallelogramBlockBlock> _parallelogramGeometryList = new BlockCollection<UserHintParallelogramBlockBlock>();
      public BlockCollection<UserHintPolygonBlockBlock> _polygonGeometryList = new BlockCollection<UserHintPolygonBlockBlock>();
      public BlockCollection<UserHintJumpBlockBlock> _jumpHintsList = new BlockCollection<UserHintJumpBlockBlock>();
      public BlockCollection<UserHintClimbBlockBlock> _climbHintsList = new BlockCollection<UserHintClimbBlockBlock>();
      public BlockCollection<UserHintWellBlockBlock> _wellHintsList = new BlockCollection<UserHintWellBlockBlock>();
      public BlockCollection<UserHintFlightBlockBlock> _flightHintsList = new BlockCollection<UserHintFlightBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintBlockBlock() {
      }
      public BlockCollection<UserHintPointBlockBlock> PointGeometry {
        get {
          return this._pointGeometryList;
        }
      }
      public BlockCollection<UserHintRayBlockBlock> RayGeometry {
        get {
          return this._rayGeometryList;
        }
      }
      public BlockCollection<UserHintLineSegmentBlockBlock> LineSegmentGeometry {
        get {
          return this._lineSegmentGeometryList;
        }
      }
      public BlockCollection<UserHintParallelogramBlockBlock> ParallelogramGeometry {
        get {
          return this._parallelogramGeometryList;
        }
      }
      public BlockCollection<UserHintPolygonBlockBlock> PolygonGeometry {
        get {
          return this._polygonGeometryList;
        }
      }
      public BlockCollection<UserHintJumpBlockBlock> JumpHints {
        get {
          return this._jumpHintsList;
        }
      }
      public BlockCollection<UserHintClimbBlockBlock> ClimbHints {
        get {
          return this._climbHintsList;
        }
      }
      public BlockCollection<UserHintWellBlockBlock> WellHints {
        get {
          return this._wellHintsList;
        }
      }
      public BlockCollection<UserHintFlightBlockBlock> FlightHints {
        get {
          return this._flightHintsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PointGeometry.BlockCount; x++)
{
  IBlock block = PointGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<RayGeometry.BlockCount; x++)
{
  IBlock block = RayGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<LineSegmentGeometry.BlockCount; x++)
{
  IBlock block = LineSegmentGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ParallelogramGeometry.BlockCount; x++)
{
  IBlock block = ParallelogramGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<PolygonGeometry.BlockCount; x++)
{
  IBlock block = PolygonGeometry.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<JumpHints.BlockCount; x++)
{
  IBlock block = JumpHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClimbHints.BlockCount; x++)
{
  IBlock block = ClimbHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WellHints.BlockCount; x++)
{
  IBlock block = WellHints.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<FlightHints.BlockCount; x++)
{
  IBlock block = FlightHints.GetBlock(x);
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
        _pointGeometry.Read(reader);
        _rayGeometry.Read(reader);
        _lineSegmentGeometry.Read(reader);
        _parallelogramGeometry.Read(reader);
        _polygonGeometry.Read(reader);
        _jumpHints.Read(reader);
        _climbHints.Read(reader);
        _wellHints.Read(reader);
        _flightHints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry.Add(new UserHintPointBlockBlock());
          PointGeometry[x].Read(reader);
        }
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry.Add(new UserHintRayBlockBlock());
          RayGeometry[x].Read(reader);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry.Add(new UserHintLineSegmentBlockBlock());
          LineSegmentGeometry[x].Read(reader);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry.Add(new UserHintParallelogramBlockBlock());
          ParallelogramGeometry[x].Read(reader);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry.Add(new UserHintPolygonBlockBlock());
          PolygonGeometry[x].Read(reader);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].ReadChildData(reader);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints.Add(new UserHintJumpBlockBlock());
          JumpHints[x].Read(reader);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints.Add(new UserHintClimbBlockBlock());
          ClimbHints[x].Read(reader);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints.Add(new UserHintWellBlockBlock());
          WellHints[x].Read(reader);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].ReadChildData(reader);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints.Add(new UserHintFlightBlockBlock());
          FlightHints[x].Read(reader);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_pointGeometry.Count = PointGeometry.Count;
        _pointGeometry.Write(bw);
_rayGeometry.Count = RayGeometry.Count;
        _rayGeometry.Write(bw);
_lineSegmentGeometry.Count = LineSegmentGeometry.Count;
        _lineSegmentGeometry.Write(bw);
_parallelogramGeometry.Count = ParallelogramGeometry.Count;
        _parallelogramGeometry.Write(bw);
_polygonGeometry.Count = PolygonGeometry.Count;
        _polygonGeometry.Write(bw);
_jumpHints.Count = JumpHints.Count;
        _jumpHints.Write(bw);
_climbHints.Count = ClimbHints.Count;
        _climbHints.Write(bw);
_wellHints.Count = WellHints.Count;
        _wellHints.Write(bw);
_flightHints.Count = FlightHints.Count;
        _flightHints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].Write(writer);
        }
        for (x = 0; (x < _pointGeometry.Count); x = (x + 1)) {
          PointGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].Write(writer);
        }
        for (x = 0; (x < _rayGeometry.Count); x = (x + 1)) {
          RayGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].Write(writer);
        }
        for (x = 0; (x < _lineSegmentGeometry.Count); x = (x + 1)) {
          LineSegmentGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].Write(writer);
        }
        for (x = 0; (x < _parallelogramGeometry.Count); x = (x + 1)) {
          ParallelogramGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].Write(writer);
        }
        for (x = 0; (x < _polygonGeometry.Count); x = (x + 1)) {
          PolygonGeometry[x].WriteChildData(writer);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].Write(writer);
        }
        for (x = 0; (x < _jumpHints.Count); x = (x + 1)) {
          JumpHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].Write(writer);
        }
        for (x = 0; (x < _climbHints.Count); x = (x + 1)) {
          ClimbHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].Write(writer);
        }
        for (x = 0; (x < _wellHints.Count); x = (x + 1)) {
          WellHints[x].WriteChildData(writer);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].Write(writer);
        }
        for (x = 0; (x < _flightHints.Count); x = (x + 1)) {
          FlightHints[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintPointBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public UserHintPointBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintRayBlockBlock : IBlock {
      private RealPoint3D _point = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealVector3D _vector = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public UserHintRayBlockBlock() {
        this._unnamed0 = new Pad(2);
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
      public RealPoint3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealVector3D Vector {
        get {
          return this._vector;
        }
        set {
          this._vector = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _vector.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _vector.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintLineSegmentBlockBlock : IBlock {
      private Flags _flags;
      private RealPoint3D _point0 = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _point1 = new RealPoint3D();
      private ShortInteger _referenceFrame2 = new ShortInteger();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public UserHintLineSegmentBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
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
      public RealPoint3D Point0 {
        get {
          return this._point0;
        }
        set {
          this._point0 = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealPoint3D Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public ShortInteger ReferenceFrame2 {
        get {
          return this._referenceFrame2;
        }
        set {
          this._referenceFrame2 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _point0.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _point1.Read(reader);
        _referenceFrame2.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _point0.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _point1.Write(bw);
        _referenceFrame2.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintParallelogramBlockBlock : IBlock {
      private Flags _flags;
      private RealPoint3D _point0 = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private RealPoint3D _point1 = new RealPoint3D();
      private ShortInteger _referenceFrame2 = new ShortInteger();
      private Pad _unnamed1;
      private RealPoint3D _point2 = new RealPoint3D();
      private ShortInteger _referenceFrame3 = new ShortInteger();
      private Pad _unnamed2;
      private RealPoint3D _point3 = new RealPoint3D();
      private ShortInteger _referenceFrame4 = new ShortInteger();
      private Pad _unnamed3;
public event System.EventHandler BlockNameChanged;
      public UserHintParallelogramBlockBlock() {
        this._flags = new Flags(4);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._unnamed3 = new Pad(2);
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
      public RealPoint3D Point0 {
        get {
          return this._point0;
        }
        set {
          this._point0 = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public RealPoint3D Point1 {
        get {
          return this._point1;
        }
        set {
          this._point1 = value;
        }
      }
      public ShortInteger ReferenceFrame2 {
        get {
          return this._referenceFrame2;
        }
        set {
          this._referenceFrame2 = value;
        }
      }
      public RealPoint3D Point2 {
        get {
          return this._point2;
        }
        set {
          this._point2 = value;
        }
      }
      public ShortInteger ReferenceFrame3 {
        get {
          return this._referenceFrame3;
        }
        set {
          this._referenceFrame3 = value;
        }
      }
      public RealPoint3D Point3 {
        get {
          return this._point3;
        }
        set {
          this._point3 = value;
        }
      }
      public ShortInteger ReferenceFrame4 {
        get {
          return this._referenceFrame4;
        }
        set {
          this._referenceFrame4 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _point0.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _point1.Read(reader);
        _referenceFrame2.Read(reader);
        _unnamed1.Read(reader);
        _point2.Read(reader);
        _referenceFrame3.Read(reader);
        _unnamed2.Read(reader);
        _point3.Read(reader);
        _referenceFrame4.Read(reader);
        _unnamed3.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _point0.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _point1.Write(bw);
        _referenceFrame2.Write(bw);
        _unnamed1.Write(bw);
        _point2.Write(bw);
        _referenceFrame3.Write(bw);
        _unnamed2.Write(bw);
        _point3.Write(bw);
        _referenceFrame4.Write(bw);
        _unnamed3.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintPolygonBlockBlock : IBlock {
      private Flags _flags;
      private Block _points = new Block();
      public BlockCollection<UserHintPointBlockBlock> _pointsList = new BlockCollection<UserHintPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintPolygonBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<UserHintPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintJumpBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _geometryIndex = new ShortBlockIndex();
      private Enum _forceJumpHeight;
      private Flags _controlFlags;
public event System.EventHandler BlockNameChanged;
      public UserHintJumpBlockBlock() {
        this._flags = new Flags(2);
        this._forceJumpHeight = new Enum(2);
        this._controlFlags = new Flags(2);
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
      public ShortBlockIndex GeometryIndex {
        get {
          return this._geometryIndex;
        }
        set {
          this._geometryIndex = value;
        }
      }
      public Enum ForceJumpHeight {
        get {
          return this._forceJumpHeight;
        }
        set {
          this._forceJumpHeight = value;
        }
      }
      public Flags ControlFlags {
        get {
          return this._controlFlags;
        }
        set {
          this._controlFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _geometryIndex.Read(reader);
        _forceJumpHeight.Read(reader);
        _controlFlags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _geometryIndex.Write(bw);
        _forceJumpHeight.Write(bw);
        _controlFlags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintClimbBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _geometryIndex = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public UserHintClimbBlockBlock() {
        this._flags = new Flags(2);
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
      public ShortBlockIndex GeometryIndex {
        get {
          return this._geometryIndex;
        }
        set {
          this._geometryIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _geometryIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _geometryIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintWellBlockBlock : IBlock {
      private Flags _flags;
      private Block _points = new Block();
      public BlockCollection<UserHintWellPointBlockBlock> _pointsList = new BlockCollection<UserHintWellPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintWellBlockBlock() {
        this._flags = new Flags(4);
      }
      public BlockCollection<UserHintWellPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintWellPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintWellPointBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private RealVector3D _point = new RealVector3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed1;
      private LongInteger _sectorIndex = new LongInteger();
      private RealEulerAngles2D _normal = new RealEulerAngles2D();
public event System.EventHandler BlockNameChanged;
      public UserHintWellPointBlockBlock() {
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
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
      public RealVector3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
        }
      }
      public LongInteger SectorIndex {
        get {
          return this._sectorIndex;
        }
        set {
          this._sectorIndex = value;
        }
      }
      public RealEulerAngles2D Normal {
        get {
          return this._normal;
        }
        set {
          this._normal = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _point.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed1.Read(reader);
        _sectorIndex.Read(reader);
        _normal.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _point.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed1.Write(bw);
        _sectorIndex.Write(bw);
        _normal.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class UserHintFlightBlockBlock : IBlock {
      private Block _points = new Block();
      public BlockCollection<UserHintFlightPointBlockBlock> _pointsList = new BlockCollection<UserHintFlightPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public UserHintFlightBlockBlock() {
      }
      public BlockCollection<UserHintFlightPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
return "";
        }
      }
      public virtual void Read(BinaryReader reader) {
        _points.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new UserHintFlightPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_points.Count = Points.Count;
        _points.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class UserHintFlightPointBlockBlock : IBlock {
      private RealVector3D _point = new RealVector3D();
public event System.EventHandler BlockNameChanged;
      public UserHintFlightPointBlockBlock() {
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
      public RealVector3D Point {
        get {
          return this._point;
        }
        set {
          this._point = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _point.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _point.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiAnimationReferenceBlockBlock : IBlock {
      private FixedLengthString _animationName = new FixedLengthString();
      private TagReference _animationGraph = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public AiAnimationReferenceBlockBlock() {
if (this._animationName is System.ComponentModel.INotifyPropertyChanged)
  (this._animationName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(12);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _animationGraph.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _animationName.Write(bw);
        _animationGraph.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _animationGraph.WriteString(writer);
      }
    }
    public class AiScriptReferenceBlockBlock : IBlock {
      private FixedLengthString _scriptName = new FixedLengthString();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public AiScriptReferenceBlockBlock() {
if (this._scriptName is System.ComponentModel.INotifyPropertyChanged)
  (this._scriptName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(8);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _scriptName.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiRecordingReferenceBlockBlock : IBlock {
      private FixedLengthString _recordingName = new FixedLengthString();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public AiRecordingReferenceBlockBlock() {
if (this._recordingName is System.ComponentModel.INotifyPropertyChanged)
  (this._recordingName as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(8);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _recordingName.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiConversationBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _flags;
      private Pad _unnamed0;
      private Real _triggerDistance = new Real();
      private Real _run_Minusto_MinusplayerDist = new Real();
      private Pad _unnamed1;
      private Block _participants = new Block();
      private Block _lines = new Block();
      private Block _unnamed2 = new Block();
      public BlockCollection<AiConversationParticipantBlockBlock> _participantsList = new BlockCollection<AiConversationParticipantBlockBlock>();
      public BlockCollection<AiConversationLineBlockBlock> _linesList = new BlockCollection<AiConversationLineBlockBlock>();
      public BlockCollection<GNullBlockBlock> _unnamed2List = new BlockCollection<GNullBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public AiConversationBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(36);
      }
      public BlockCollection<AiConversationParticipantBlockBlock> Participants {
        get {
          return this._participantsList;
        }
      }
      public BlockCollection<AiConversationLineBlockBlock> Lines {
        get {
          return this._linesList;
        }
      }
      public BlockCollection<GNullBlockBlock> Unnamed2 {
        get {
          return this._unnamed2List;
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
for (int x=0; x<Unnamed2.BlockCount; x++)
{
  IBlock block = Unnamed2.GetBlock(x);
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
      public Real Run_Minusto_MinusplayerDist {
        get {
          return this._run_Minusto_MinusplayerDist;
        }
        set {
          this._run_Minusto_MinusplayerDist = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _flags.Read(reader);
        _unnamed0.Read(reader);
        _triggerDistance.Read(reader);
        _run_Minusto_MinusplayerDist.Read(reader);
        _unnamed1.Read(reader);
        _participants.Read(reader);
        _lines.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants.Add(new AiConversationParticipantBlockBlock());
          Participants[x].Read(reader);
        }
        for (x = 0; (x < _participants.Count); x = (x + 1)) {
          Participants[x].ReadChildData(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines.Add(new AiConversationLineBlockBlock());
          Lines[x].Read(reader);
        }
        for (x = 0; (x < _lines.Count); x = (x + 1)) {
          Lines[x].ReadChildData(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2.Add(new GNullBlockBlock());
          Unnamed2[x].Read(reader);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _flags.Write(bw);
        _unnamed0.Write(bw);
        _triggerDistance.Write(bw);
        _run_Minusto_MinusplayerDist.Write(bw);
        _unnamed1.Write(bw);
_participants.Count = Participants.Count;
        _participants.Write(bw);
_lines.Count = Lines.Count;
        _lines.Write(bw);
_unnamed2.Count = Unnamed2.Count;
        _unnamed2.Write(bw);
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
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].Write(writer);
        }
        for (x = 0; (x < _unnamed2.Count); x = (x + 1)) {
          Unnamed2[x].WriteChildData(writer);
        }
      }
    }
    public class AiConversationParticipantBlockBlock : IBlock {
      private Pad _unnamed0;
      private ShortBlockIndex _useThisObject = new ShortBlockIndex();
      private ShortBlockIndex _setNewName = new ShortBlockIndex();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private FixedLengthString _encounterName = new FixedLengthString();
      private Pad _unnamed3;
      private Pad _unnamed4;
public event System.EventHandler BlockNameChanged;
      public AiConversationParticipantBlockBlock() {
        this._unnamed0 = new Pad(8);
        this._unnamed1 = new Pad(12);
        this._unnamed2 = new Pad(12);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(12);
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
        _unnamed0.Read(reader);
        _useThisObject.Read(reader);
        _setNewName.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _encounterName.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _useThisObject.Write(bw);
        _setNewName.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _encounterName.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class AiConversationLineBlockBlock : IBlock {
      private Flags _flags;
      private ShortBlockIndex _participant = new ShortBlockIndex();
      private Enum _addressee;
      private ShortBlockIndex _addresseeParticipant = new ShortBlockIndex();
      private Pad _unnamed0;
      private Real _lineDelayTime = new Real();
      private Pad _unnamed1;
      private TagReference _variant1 = new TagReference();
      private TagReference _variant2 = new TagReference();
      private TagReference _variant3 = new TagReference();
      private TagReference _variant4 = new TagReference();
      private TagReference _variant5 = new TagReference();
      private TagReference _variant6 = new TagReference();
public event System.EventHandler BlockNameChanged;
      public AiConversationLineBlockBlock() {
        this._flags = new Flags(2);
        this._addressee = new Enum(2);
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(12);
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
        _unnamed0.Read(reader);
        _lineDelayTime.Read(reader);
        _unnamed1.Read(reader);
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
        _unnamed0.Write(bw);
        _lineDelayTime.Write(bw);
        _unnamed1.Write(bw);
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
    public class GNullBlockBlock : IBlock {
public event System.EventHandler BlockNameChanged;
      public GNullBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsScriptsBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _scriptType;
      private Enum _returnType;
      private LongInteger _rootExpressionIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public HsScriptsBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._scriptType = new Enum(2);
        this._returnType = new Enum(2);
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _scriptType.Write(bw);
        _returnType.Write(bw);
        _rootExpressionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsGlobalsBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Enum _type;
      private Pad _unnamed0;
      private LongInteger _initializationExpressionIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public HsGlobalsBlockBlock() {
        this._type = new Enum(2);
        this._unnamed0 = new Pad(2);
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
        _unnamed0.Read(reader);
        _initializationExpressionIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _type.Write(bw);
        _unnamed0.Write(bw);
        _initializationExpressionIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsReferencesBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public HsReferencesBlockBlock() {
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
    public class HsSourceFilesBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Data _source = new Data();
public event System.EventHandler BlockNameChanged;
      public HsSourceFilesBlockBlock() {
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
    public class CsScriptDataBlockBlock : IBlock {
      private Block _pointSets = new Block();
      private Pad _unnamed0;
      public BlockCollection<CsPointSetBlockBlock> _pointSetsList = new BlockCollection<CsPointSetBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CsScriptDataBlockBlock() {
        this._unnamed0 = new Pad(120);
      }
      public BlockCollection<CsPointSetBlockBlock> PointSets {
        get {
          return this._pointSetsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PointSets.BlockCount; x++)
{
  IBlock block = PointSets.GetBlock(x);
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
        _pointSets.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _pointSets.Count); x = (x + 1)) {
          PointSets.Add(new CsPointSetBlockBlock());
          PointSets[x].Read(reader);
        }
        for (x = 0; (x < _pointSets.Count); x = (x + 1)) {
          PointSets[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_pointSets.Count = PointSets.Count;
        _pointSets.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _pointSets.Count); x = (x + 1)) {
          PointSets[x].Write(writer);
        }
        for (x = 0; (x < _pointSets.Count); x = (x + 1)) {
          PointSets[x].WriteChildData(writer);
        }
      }
    }
    public class CsPointSetBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Block _points = new Block();
      private ShortBlockIndex _bspIndex = new ShortBlockIndex();
      private ShortInteger _manualReferenceFrame = new ShortInteger();
      private Flags _flags;
      public BlockCollection<CsPointBlockBlock> _pointsList = new BlockCollection<CsPointBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public CsPointSetBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(4);
      }
      public BlockCollection<CsPointBlockBlock> Points {
        get {
          return this._pointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
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
      public ShortBlockIndex BspIndex {
        get {
          return this._bspIndex;
        }
        set {
          this._bspIndex = value;
        }
      }
      public ShortInteger ManualReferenceFrame {
        get {
          return this._manualReferenceFrame;
        }
        set {
          this._manualReferenceFrame = value;
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
        _points.Read(reader);
        _bspIndex.Read(reader);
        _manualReferenceFrame.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points.Add(new CsPointBlockBlock());
          Points[x].Read(reader);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
_points.Count = Points.Count;
        _points.Write(bw);
        _bspIndex.Write(bw);
        _manualReferenceFrame.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].Write(writer);
        }
        for (x = 0; (x < _points.Count); x = (x + 1)) {
          Points[x].WriteChildData(writer);
        }
      }
    }
    public class CsPointBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private RealPoint3D _position = new RealPoint3D();
      private ShortInteger _referenceFrame = new ShortInteger();
      private Pad _unnamed0;
      private LongInteger _surfaceIndex = new LongInteger();
      private RealEulerAngles2D _facingDirection = new RealEulerAngles2D();
public event System.EventHandler BlockNameChanged;
      public CsPointBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
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
      public ShortInteger ReferenceFrame {
        get {
          return this._referenceFrame;
        }
        set {
          this._referenceFrame = value;
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
      public RealEulerAngles2D FacingDirection {
        get {
          return this._facingDirection;
        }
        set {
          this._facingDirection = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _position.Read(reader);
        _referenceFrame.Read(reader);
        _unnamed0.Read(reader);
        _surfaceIndex.Read(reader);
        _facingDirection.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _position.Write(bw);
        _referenceFrame.Write(bw);
        _unnamed0.Write(bw);
        _surfaceIndex.Write(bw);
        _facingDirection.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCutsceneFlagBlockBlock : IBlock {
      private Pad _unnamed0;
      private FixedLengthString _name = new FixedLengthString();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles2D _facing = new RealEulerAngles2D();
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneFlagBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(4);
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
        _unnamed0.Read(reader);
        _name.Read(reader);
        _position.Read(reader);
        _facing.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _name.Write(bw);
        _position.Write(bw);
        _facing.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCutsceneCameraPointBlockBlock : IBlock {
      private Flags _flags;
      private Enum _type;
      private FixedLengthString _name = new FixedLengthString();
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _orientation = new RealEulerAngles3D();
      private Angle _unused = new Angle();
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneCameraPointBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._flags = new Flags(2);
        this._type = new Enum(2);
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
      public Enum Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
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
      public Angle Unused {
        get {
          return this._unused;
        }
        set {
          this._unused = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _flags.Read(reader);
        _type.Read(reader);
        _name.Read(reader);
        _position.Read(reader);
        _orientation.Read(reader);
        _unused.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _flags.Write(bw);
        _type.Write(bw);
        _name.Write(bw);
        _position.Write(bw);
        _orientation.Write(bw);
        _unused.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCutsceneTitleBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Rectangle2D _textBoundsOnScreen = new Rectangle2D();
      private Enum _justification;
      private Enum _font;
      private RGBColor _textColor = new RGBColor();
      private RGBColor _shadowColor = new RGBColor();
      private Real _fadeInTimeSeconds = new Real();
      private Real _upTimeSeconds = new Real();
      private Real _fadeOutTimeSeconds = new Real();
public event System.EventHandler BlockNameChanged;
      public ScenarioCutsceneTitleBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._justification = new Enum(2);
        this._font = new Enum(2);
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
      public StringId Name {
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
      public Enum Justification {
        get {
          return this._justification;
        }
        set {
          this._justification = value;
        }
      }
      public Enum Font {
        get {
          return this._font;
        }
        set {
          this._font = value;
        }
      }
      public RGBColor TextColor {
        get {
          return this._textColor;
        }
        set {
          this._textColor = value;
        }
      }
      public RGBColor ShadowColor {
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
        _name.Read(reader);
        _textBoundsOnScreen.Read(reader);
        _justification.Read(reader);
        _font.Read(reader);
        _textColor.Read(reader);
        _shadowColor.Read(reader);
        _fadeInTimeSeconds.Read(reader);
        _upTimeSeconds.Read(reader);
        _fadeOutTimeSeconds.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _textBoundsOnScreen.Write(bw);
        _justification.Write(bw);
        _font.Write(bw);
        _textColor.Write(bw);
        _shadowColor.Write(bw);
        _fadeInTimeSeconds.Write(bw);
        _upTimeSeconds.Write(bw);
        _fadeOutTimeSeconds.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioStructureBspReferenceBlockBlock : IBlock {
      private Pad _unnamed0;
      private TagReference _structureBSP = new TagReference();
      private TagReference _structureLightmap = new TagReference();
      private Pad _unnamed1;
      private Real _uNUSEDRadianceEstSearchDistance = new Real();
      private Pad _unnamed2;
      private Real _uNUSEDLuminelsPerWorldUnit = new Real();
      private Real _uNUSEDOutputWhiteReference = new Real();
      private Pad _unnamed3;
      private Flags _flags;
      private Pad _unnamed4;
      private ShortBlockIndex _defaultSky = new ShortBlockIndex();
      private Pad _unnamed5;
public event System.EventHandler BlockNameChanged;
      public ScenarioStructureBspReferenceBlockBlock() {
if (this._structureLightmap is System.ComponentModel.INotifyPropertyChanged)
  (this._structureLightmap as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(16);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(8);
        this._flags = new Flags(2);
        this._unnamed4 = new Pad(2);
        this._unnamed5 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_structureBSP.Value);
references.Add(_structureLightmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _structureLightmap.ToString();
        }
      }
      public TagReference StructureBSP {
        get {
          return this._structureBSP;
        }
        set {
          this._structureBSP = value;
        }
      }
      public TagReference StructureLightmap {
        get {
          return this._structureLightmap;
        }
        set {
          this._structureLightmap = value;
        }
      }
      public Real UNUSEDRadianceEstSearchDistance {
        get {
          return this._uNUSEDRadianceEstSearchDistance;
        }
        set {
          this._uNUSEDRadianceEstSearchDistance = value;
        }
      }
      public Real UNUSEDLuminelsPerWorldUnit {
        get {
          return this._uNUSEDLuminelsPerWorldUnit;
        }
        set {
          this._uNUSEDLuminelsPerWorldUnit = value;
        }
      }
      public Real UNUSEDOutputWhiteReference {
        get {
          return this._uNUSEDOutputWhiteReference;
        }
        set {
          this._uNUSEDOutputWhiteReference = value;
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
      public ShortBlockIndex DefaultSky {
        get {
          return this._defaultSky;
        }
        set {
          this._defaultSky = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _structureBSP.Read(reader);
        _structureLightmap.Read(reader);
        _unnamed1.Read(reader);
        _uNUSEDRadianceEstSearchDistance.Read(reader);
        _unnamed2.Read(reader);
        _uNUSEDLuminelsPerWorldUnit.Read(reader);
        _uNUSEDOutputWhiteReference.Read(reader);
        _unnamed3.Read(reader);
        _flags.Read(reader);
        _unnamed4.Read(reader);
        _defaultSky.Read(reader);
        _unnamed5.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _structureBSP.ReadString(reader);
        _structureLightmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _structureBSP.Write(bw);
        _structureLightmap.Write(bw);
        _unnamed1.Write(bw);
        _uNUSEDRadianceEstSearchDistance.Write(bw);
        _unnamed2.Write(bw);
        _uNUSEDLuminelsPerWorldUnit.Write(bw);
        _uNUSEDOutputWhiteReference.Write(bw);
        _unnamed3.Write(bw);
        _flags.Write(bw);
        _unnamed4.Write(bw);
        _defaultSky.Write(bw);
        _unnamed5.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _structureBSP.WriteString(writer);
        _structureLightmap.WriteString(writer);
      }
    }
    public class ScenarioResourcesBlockBlock : IBlock {
      private Block _references = new Block();
      private Block _scriptSource = new Block();
      private Block _aIResources = new Block();
      public BlockCollection<ScenarioResourceReferenceBlockBlock> _referencesList = new BlockCollection<ScenarioResourceReferenceBlockBlock>();
      public BlockCollection<ScenarioHsSourceReferenceBlockBlock> _scriptSourceList = new BlockCollection<ScenarioHsSourceReferenceBlockBlock>();
      public BlockCollection<ScenarioAiResourceReferenceBlockBlock> _aIResourcesList = new BlockCollection<ScenarioAiResourceReferenceBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioResourcesBlockBlock() {
      }
      public BlockCollection<ScenarioResourceReferenceBlockBlock> References {
        get {
          return this._referencesList;
        }
      }
      public BlockCollection<ScenarioHsSourceReferenceBlockBlock> ScriptSource {
        get {
          return this._scriptSourceList;
        }
      }
      public BlockCollection<ScenarioAiResourceReferenceBlockBlock> AIResources {
        get {
          return this._aIResourcesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<References.BlockCount; x++)
{
  IBlock block = References.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ScriptSource.BlockCount; x++)
{
  IBlock block = ScriptSource.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AIResources.BlockCount; x++)
{
  IBlock block = AIResources.GetBlock(x);
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
        _references.Read(reader);
        _scriptSource.Read(reader);
        _aIResources.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References.Add(new ScenarioResourceReferenceBlockBlock());
          References[x].Read(reader);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].ReadChildData(reader);
        }
        for (x = 0; (x < _scriptSource.Count); x = (x + 1)) {
          ScriptSource.Add(new ScenarioHsSourceReferenceBlockBlock());
          ScriptSource[x].Read(reader);
        }
        for (x = 0; (x < _scriptSource.Count); x = (x + 1)) {
          ScriptSource[x].ReadChildData(reader);
        }
        for (x = 0; (x < _aIResources.Count); x = (x + 1)) {
          AIResources.Add(new ScenarioAiResourceReferenceBlockBlock());
          AIResources[x].Read(reader);
        }
        for (x = 0; (x < _aIResources.Count); x = (x + 1)) {
          AIResources[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_references.Count = References.Count;
        _references.Write(bw);
_scriptSource.Count = ScriptSource.Count;
        _scriptSource.Write(bw);
_aIResources.Count = AIResources.Count;
        _aIResources.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].Write(writer);
        }
        for (x = 0; (x < _references.Count); x = (x + 1)) {
          References[x].WriteChildData(writer);
        }
        for (x = 0; (x < _scriptSource.Count); x = (x + 1)) {
          ScriptSource[x].Write(writer);
        }
        for (x = 0; (x < _scriptSource.Count); x = (x + 1)) {
          ScriptSource[x].WriteChildData(writer);
        }
        for (x = 0; (x < _aIResources.Count); x = (x + 1)) {
          AIResources[x].Write(writer);
        }
        for (x = 0; (x < _aIResources.Count); x = (x + 1)) {
          AIResources[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioResourceReferenceBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioResourceReferenceBlockBlock() {
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
return "";
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
    public class ScenarioHsSourceReferenceBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioHsSourceReferenceBlockBlock() {
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
return "";
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
    public class ScenarioAiResourceReferenceBlockBlock : IBlock {
      private TagReference _reference = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioAiResourceReferenceBlockBlock() {
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
return "";
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
    public class OldUnusedStrucurePhysicsBlockBlock : IBlock {
      private Data _moppCode = new Data();
      private Block _evironmentObjectIdentifiers = new Block();
      private Pad _unnamed0;
      private RealPoint3D _moppBoundsMin = new RealPoint3D();
      private RealPoint3D _moppBoundsMax = new RealPoint3D();
      public BlockCollection<OldUnusedObjectIdentifiersBlockBlock> _evironmentObjectIdentifiersList = new BlockCollection<OldUnusedObjectIdentifiersBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public OldUnusedStrucurePhysicsBlockBlock() {
        this._unnamed0 = new Pad(4);
      }
      public BlockCollection<OldUnusedObjectIdentifiersBlockBlock> EvironmentObjectIdentifiers {
        get {
          return this._evironmentObjectIdentifiersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<EvironmentObjectIdentifiers.BlockCount; x++)
{
  IBlock block = EvironmentObjectIdentifiers.GetBlock(x);
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
      public Data MoppCode {
        get {
          return this._moppCode;
        }
        set {
          this._moppCode = value;
        }
      }
      public RealPoint3D MoppBoundsMin {
        get {
          return this._moppBoundsMin;
        }
        set {
          this._moppBoundsMin = value;
        }
      }
      public RealPoint3D MoppBoundsMax {
        get {
          return this._moppBoundsMax;
        }
        set {
          this._moppBoundsMax = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _moppCode.Read(reader);
        _evironmentObjectIdentifiers.Read(reader);
        _unnamed0.Read(reader);
        _moppBoundsMin.Read(reader);
        _moppBoundsMax.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _moppCode.ReadBinary(reader);
        for (x = 0; (x < _evironmentObjectIdentifiers.Count); x = (x + 1)) {
          EvironmentObjectIdentifiers.Add(new OldUnusedObjectIdentifiersBlockBlock());
          EvironmentObjectIdentifiers[x].Read(reader);
        }
        for (x = 0; (x < _evironmentObjectIdentifiers.Count); x = (x + 1)) {
          EvironmentObjectIdentifiers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _moppCode.Write(bw);
_evironmentObjectIdentifiers.Count = EvironmentObjectIdentifiers.Count;
        _evironmentObjectIdentifiers.Write(bw);
        _unnamed0.Write(bw);
        _moppBoundsMin.Write(bw);
        _moppBoundsMax.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _moppCode.WriteBinary(writer);
        for (x = 0; (x < _evironmentObjectIdentifiers.Count); x = (x + 1)) {
          EvironmentObjectIdentifiers[x].Write(writer);
        }
        for (x = 0; (x < _evironmentObjectIdentifiers.Count); x = (x + 1)) {
          EvironmentObjectIdentifiers[x].WriteChildData(writer);
        }
      }
    }
    public class OldUnusedObjectIdentifiersBlockBlock : IBlock {
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type;
      private Enum _source;
public event System.EventHandler BlockNameChanged;
      public OldUnusedObjectIdentifiersBlockBlock() {
        this._type = new Enum(1);
        this._source = new Enum(1);
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
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type.Read(reader);
        _source.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type.Write(bw);
        _source.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class HsUnitSeatBlockBlock : IBlock {
      private LongInteger _unnamed0 = new LongInteger();
      private LongInteger _unnamed1 = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public HsUnitSeatBlockBlock() {
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
      public LongInteger unnamed0 {
        get {
          return this._unnamed0;
        }
        set {
          this._unnamed0 = value;
        }
      }
      public LongInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioKillTriggerVolumesBlockBlock : IBlock {
      private ShortBlockIndex _triggerVolume = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public ScenarioKillTriggerVolumesBlockBlock() {
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
      public virtual void Read(BinaryReader reader) {
        _triggerVolume.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _triggerVolume.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SyntaxDatumBlockBlock : IBlock {
      private ShortInteger _datumHeader = new ShortInteger();
      private ShortInteger _scriptIndexFunctionIndexConstantTypeUnion = new ShortInteger();
      private ShortInteger _type = new ShortInteger();
      private ShortInteger _flags = new ShortInteger();
      private LongInteger _nextNodeIndex = new LongInteger();
      private LongInteger _data = new LongInteger();
      private LongInteger _sourceoffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public SyntaxDatumBlockBlock() {
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
      public ShortInteger DatumHeader {
        get {
          return this._datumHeader;
        }
        set {
          this._datumHeader = value;
        }
      }
      public ShortInteger ScriptIndexFunctionIndexConstantTypeUnion {
        get {
          return this._scriptIndexFunctionIndexConstantTypeUnion;
        }
        set {
          this._scriptIndexFunctionIndexConstantTypeUnion = value;
        }
      }
      public ShortInteger Type {
        get {
          return this._type;
        }
        set {
          this._type = value;
        }
      }
      public ShortInteger Flags {
        get {
          return this._flags;
        }
        set {
          this._flags = value;
        }
      }
      public LongInteger NextNodeIndex {
        get {
          return this._nextNodeIndex;
        }
        set {
          this._nextNodeIndex = value;
        }
      }
      public LongInteger Data {
        get {
          return this._data;
        }
        set {
          this._data = value;
        }
      }
      public LongInteger Sourceoffset {
        get {
          return this._sourceoffset;
        }
        set {
          this._sourceoffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _datumHeader.Read(reader);
        _scriptIndexFunctionIndexConstantTypeUnion.Read(reader);
        _type.Read(reader);
        _flags.Read(reader);
        _nextNodeIndex.Read(reader);
        _data.Read(reader);
        _sourceoffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _datumHeader.Write(bw);
        _scriptIndexFunctionIndexConstantTypeUnion.Write(bw);
        _type.Write(bw);
        _flags.Write(bw);
        _nextNodeIndex.Write(bw);
        _data.Write(bw);
        _sourceoffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class OrdersBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private ShortBlockIndex _style = new ShortBlockIndex();
      private Pad _unnamed0;
      private Flags _flags;
      private Enum _forceCombatStatus;
      private Pad _unnamed1;
      private FixedLengthString _entryScript = new FixedLengthString();
      private Skip _unnamed2;
      private ShortBlockIndex _followSquad = new ShortBlockIndex();
      private Real _followRadius = new Real();
      private Block _primaryAreaSet = new Block();
      private Block _secondaryAreaSet = new Block();
      private Block _secondarySetTrigger = new Block();
      private Block _specialMovement = new Block();
      private Block _orderEndings = new Block();
      public BlockCollection<ZoneSetBlockBlock> _primaryAreaSetList = new BlockCollection<ZoneSetBlockBlock>();
      public BlockCollection<SecondaryZoneSetBlockBlock> _secondaryAreaSetList = new BlockCollection<SecondaryZoneSetBlockBlock>();
      public BlockCollection<SecondarySetTriggerBlockBlock> _secondarySetTriggerList = new BlockCollection<SecondarySetTriggerBlockBlock>();
      public BlockCollection<SpecialMovementBlockBlock> _specialMovementList = new BlockCollection<SpecialMovementBlockBlock>();
      public BlockCollection<OrderEndingBlockBlock> _orderEndingsList = new BlockCollection<OrderEndingBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public OrdersBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(4);
        this._forceCombatStatus = new Enum(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Skip(2);
      }
      public BlockCollection<ZoneSetBlockBlock> PrimaryAreaSet {
        get {
          return this._primaryAreaSetList;
        }
      }
      public BlockCollection<SecondaryZoneSetBlockBlock> SecondaryAreaSet {
        get {
          return this._secondaryAreaSetList;
        }
      }
      public BlockCollection<SecondarySetTriggerBlockBlock> SecondarySetTrigger {
        get {
          return this._secondarySetTriggerList;
        }
      }
      public BlockCollection<SpecialMovementBlockBlock> SpecialMovement {
        get {
          return this._specialMovementList;
        }
      }
      public BlockCollection<OrderEndingBlockBlock> OrderEndings {
        get {
          return this._orderEndingsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<PrimaryAreaSet.BlockCount; x++)
{
  IBlock block = PrimaryAreaSet.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SecondaryAreaSet.BlockCount; x++)
{
  IBlock block = SecondaryAreaSet.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SecondarySetTrigger.BlockCount; x++)
{
  IBlock block = SecondarySetTrigger.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpecialMovement.BlockCount; x++)
{
  IBlock block = SpecialMovement.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<OrderEndings.BlockCount; x++)
{
  IBlock block = OrderEndings.GetBlock(x);
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
      public ShortBlockIndex Style {
        get {
          return this._style;
        }
        set {
          this._style = value;
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
      public Enum ForceCombatStatus {
        get {
          return this._forceCombatStatus;
        }
        set {
          this._forceCombatStatus = value;
        }
      }
      public FixedLengthString EntryScript {
        get {
          return this._entryScript;
        }
        set {
          this._entryScript = value;
        }
      }
      public ShortBlockIndex FollowSquad {
        get {
          return this._followSquad;
        }
        set {
          this._followSquad = value;
        }
      }
      public Real FollowRadius {
        get {
          return this._followRadius;
        }
        set {
          this._followRadius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _style.Read(reader);
        _unnamed0.Read(reader);
        _flags.Read(reader);
        _forceCombatStatus.Read(reader);
        _unnamed1.Read(reader);
        _entryScript.Read(reader);
        _unnamed2.Read(reader);
        _followSquad.Read(reader);
        _followRadius.Read(reader);
        _primaryAreaSet.Read(reader);
        _secondaryAreaSet.Read(reader);
        _secondarySetTrigger.Read(reader);
        _specialMovement.Read(reader);
        _orderEndings.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _primaryAreaSet.Count); x = (x + 1)) {
          PrimaryAreaSet.Add(new ZoneSetBlockBlock());
          PrimaryAreaSet[x].Read(reader);
        }
        for (x = 0; (x < _primaryAreaSet.Count); x = (x + 1)) {
          PrimaryAreaSet[x].ReadChildData(reader);
        }
        for (x = 0; (x < _secondaryAreaSet.Count); x = (x + 1)) {
          SecondaryAreaSet.Add(new SecondaryZoneSetBlockBlock());
          SecondaryAreaSet[x].Read(reader);
        }
        for (x = 0; (x < _secondaryAreaSet.Count); x = (x + 1)) {
          SecondaryAreaSet[x].ReadChildData(reader);
        }
        for (x = 0; (x < _secondarySetTrigger.Count); x = (x + 1)) {
          SecondarySetTrigger.Add(new SecondarySetTriggerBlockBlock());
          SecondarySetTrigger[x].Read(reader);
        }
        for (x = 0; (x < _secondarySetTrigger.Count); x = (x + 1)) {
          SecondarySetTrigger[x].ReadChildData(reader);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement.Add(new SpecialMovementBlockBlock());
          SpecialMovement[x].Read(reader);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].ReadChildData(reader);
        }
        for (x = 0; (x < _orderEndings.Count); x = (x + 1)) {
          OrderEndings.Add(new OrderEndingBlockBlock());
          OrderEndings[x].Read(reader);
        }
        for (x = 0; (x < _orderEndings.Count); x = (x + 1)) {
          OrderEndings[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _style.Write(bw);
        _unnamed0.Write(bw);
        _flags.Write(bw);
        _forceCombatStatus.Write(bw);
        _unnamed1.Write(bw);
        _entryScript.Write(bw);
        _unnamed2.Write(bw);
        _followSquad.Write(bw);
        _followRadius.Write(bw);
_primaryAreaSet.Count = PrimaryAreaSet.Count;
        _primaryAreaSet.Write(bw);
_secondaryAreaSet.Count = SecondaryAreaSet.Count;
        _secondaryAreaSet.Write(bw);
_secondarySetTrigger.Count = SecondarySetTrigger.Count;
        _secondarySetTrigger.Write(bw);
_specialMovement.Count = SpecialMovement.Count;
        _specialMovement.Write(bw);
_orderEndings.Count = OrderEndings.Count;
        _orderEndings.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _primaryAreaSet.Count); x = (x + 1)) {
          PrimaryAreaSet[x].Write(writer);
        }
        for (x = 0; (x < _primaryAreaSet.Count); x = (x + 1)) {
          PrimaryAreaSet[x].WriteChildData(writer);
        }
        for (x = 0; (x < _secondaryAreaSet.Count); x = (x + 1)) {
          SecondaryAreaSet[x].Write(writer);
        }
        for (x = 0; (x < _secondaryAreaSet.Count); x = (x + 1)) {
          SecondaryAreaSet[x].WriteChildData(writer);
        }
        for (x = 0; (x < _secondarySetTrigger.Count); x = (x + 1)) {
          SecondarySetTrigger[x].Write(writer);
        }
        for (x = 0; (x < _secondarySetTrigger.Count); x = (x + 1)) {
          SecondarySetTrigger[x].WriteChildData(writer);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].Write(writer);
        }
        for (x = 0; (x < _specialMovement.Count); x = (x + 1)) {
          SpecialMovement[x].WriteChildData(writer);
        }
        for (x = 0; (x < _orderEndings.Count); x = (x + 1)) {
          OrderEndings[x].Write(writer);
        }
        for (x = 0; (x < _orderEndings.Count); x = (x + 1)) {
          OrderEndings[x].WriteChildData(writer);
        }
      }
    }
    public class ZoneSetBlockBlock : IBlock {
      private Enum _areaType;
      private Pad _unnamed0;
      private ShortBlockIndex _zone = new ShortBlockIndex();
      private ShortInteger _area = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public ZoneSetBlockBlock() {
if (this._area is System.ComponentModel.INotifyPropertyChanged)
  (this._area as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._areaType = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _area.ToString();
        }
      }
      public Enum AreaType {
        get {
          return this._areaType;
        }
        set {
          this._areaType = value;
        }
      }
      public ShortBlockIndex Zone {
        get {
          return this._zone;
        }
        set {
          this._zone = value;
        }
      }
      public ShortInteger Area {
        get {
          return this._area;
        }
        set {
          this._area = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _areaType.Read(reader);
        _unnamed0.Read(reader);
        _zone.Read(reader);
        _area.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _areaType.Write(bw);
        _unnamed0.Write(bw);
        _zone.Write(bw);
        _area.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SecondaryZoneSetBlockBlock : IBlock {
      private Enum _areaType;
      private Pad _unnamed0;
      private ShortBlockIndex _zone = new ShortBlockIndex();
      private ShortInteger _area = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public SecondaryZoneSetBlockBlock() {
if (this._area is System.ComponentModel.INotifyPropertyChanged)
  (this._area as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._areaType = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _area.ToString();
        }
      }
      public Enum AreaType {
        get {
          return this._areaType;
        }
        set {
          this._areaType = value;
        }
      }
      public ShortBlockIndex Zone {
        get {
          return this._zone;
        }
        set {
          this._zone = value;
        }
      }
      public ShortInteger Area {
        get {
          return this._area;
        }
        set {
          this._area = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _areaType.Read(reader);
        _unnamed0.Read(reader);
        _zone.Read(reader);
        _area.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _areaType.Write(bw);
        _unnamed0.Write(bw);
        _zone.Write(bw);
        _area.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SecondarySetTriggerBlockBlock : IBlock {
      private Enum _combinationRule;
      private Enum _dialogueType;
      private Block _triggers = new Block();
      public BlockCollection<TriggerReferencesBlock> _triggersList = new BlockCollection<TriggerReferencesBlock>();
public event System.EventHandler BlockNameChanged;
      public SecondarySetTriggerBlockBlock() {
        this._combinationRule = new Enum(2);
        this._dialogueType = new Enum(2);
      }
      public BlockCollection<TriggerReferencesBlock> Triggers {
        get {
          return this._triggersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Triggers.BlockCount; x++)
{
  IBlock block = Triggers.GetBlock(x);
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
      public Enum CombinationRule {
        get {
          return this._combinationRule;
        }
        set {
          this._combinationRule = value;
        }
      }
      public Enum DialogueType {
        get {
          return this._dialogueType;
        }
        set {
          this._dialogueType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _combinationRule.Read(reader);
        _dialogueType.Read(reader);
        _triggers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers.Add(new TriggerReferencesBlock());
          Triggers[x].Read(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _combinationRule.Write(bw);
        _dialogueType.Write(bw);
_triggers.Count = Triggers.Count;
        _triggers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].Write(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].WriteChildData(writer);
        }
      }
    }
    public class SpecialMovementBlockBlock : IBlock {
      private Flags _specialMovement1;
public event System.EventHandler BlockNameChanged;
      public SpecialMovementBlockBlock() {
        this._specialMovement1 = new Flags(4);
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
      public Flags SpecialMovement1 {
        get {
          return this._specialMovement1;
        }
        set {
          this._specialMovement1 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _specialMovement1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _specialMovement1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class OrderEndingBlockBlock : IBlock {
      private ShortBlockIndex _nextOrder = new ShortBlockIndex();
      private Enum _combinationRule;
      private Real _delayTime = new Real();
      private Enum _dialogueType;
      private Pad _unnamed0;
      private Block _triggers = new Block();
      public BlockCollection<TriggerReferencesBlock> _triggersList = new BlockCollection<TriggerReferencesBlock>();
public event System.EventHandler BlockNameChanged;
      public OrderEndingBlockBlock() {
if (this._nextOrder is System.ComponentModel.INotifyPropertyChanged)
  (this._nextOrder as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._combinationRule = new Enum(2);
        this._dialogueType = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<TriggerReferencesBlock> Triggers {
        get {
          return this._triggersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Triggers.BlockCount; x++)
{
  IBlock block = Triggers.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _nextOrder.ToString();
        }
      }
      public ShortBlockIndex NextOrder {
        get {
          return this._nextOrder;
        }
        set {
          this._nextOrder = value;
        }
      }
      public Enum CombinationRule {
        get {
          return this._combinationRule;
        }
        set {
          this._combinationRule = value;
        }
      }
      public Real DelayTime {
        get {
          return this._delayTime;
        }
        set {
          this._delayTime = value;
        }
      }
      public Enum DialogueType {
        get {
          return this._dialogueType;
        }
        set {
          this._dialogueType = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _nextOrder.Read(reader);
        _combinationRule.Read(reader);
        _delayTime.Read(reader);
        _dialogueType.Read(reader);
        _unnamed0.Read(reader);
        _triggers.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers.Add(new TriggerReferencesBlock());
          Triggers[x].Read(reader);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _nextOrder.Write(bw);
        _combinationRule.Write(bw);
        _delayTime.Write(bw);
        _dialogueType.Write(bw);
        _unnamed0.Write(bw);
_triggers.Count = Triggers.Count;
        _triggers.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].Write(writer);
        }
        for (x = 0; (x < _triggers.Count); x = (x + 1)) {
          Triggers[x].WriteChildData(writer);
        }
      }
    }
    public class TriggersBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private Flags _triggerFlags;
      private Enum _combinationRule;
      private Pad _unnamed0;
      private Block _conditions = new Block();
      public BlockCollection<OrderCompletionConditionBlock> _conditionsList = new BlockCollection<OrderCompletionConditionBlock>();
public event System.EventHandler BlockNameChanged;
      public TriggersBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._triggerFlags = new Flags(4);
        this._combinationRule = new Enum(2);
        this._unnamed0 = new Pad(2);
      }
      public BlockCollection<OrderCompletionConditionBlock> Conditions {
        get {
          return this._conditionsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Conditions.BlockCount; x++)
{
  IBlock block = Conditions.GetBlock(x);
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
      public Flags TriggerFlags {
        get {
          return this._triggerFlags;
        }
        set {
          this._triggerFlags = value;
        }
      }
      public Enum CombinationRule {
        get {
          return this._combinationRule;
        }
        set {
          this._combinationRule = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _triggerFlags.Read(reader);
        _combinationRule.Read(reader);
        _unnamed0.Read(reader);
        _conditions.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _conditions.Count); x = (x + 1)) {
          Conditions.Add(new OrderCompletionConditionBlock());
          Conditions[x].Read(reader);
        }
        for (x = 0; (x < _conditions.Count); x = (x + 1)) {
          Conditions[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _triggerFlags.Write(bw);
        _combinationRule.Write(bw);
        _unnamed0.Write(bw);
_conditions.Count = Conditions.Count;
        _conditions.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _conditions.Count); x = (x + 1)) {
          Conditions[x].Write(writer);
        }
        for (x = 0; (x < _conditions.Count); x = (x + 1)) {
          Conditions[x].WriteChildData(writer);
        }
      }
    }
    public class OrderCompletionConditionBlock : IBlock {
      private Enum _ruleType;
      private ShortBlockIndex _squad = new ShortBlockIndex();
      private ShortBlockIndex _squadGroup = new ShortBlockIndex();
      private ShortInteger _a = new ShortInteger();
      private Real _x = new Real();
      private ShortBlockIndex _triggerVolume = new ShortBlockIndex();
      private Pad _unnamed0;
      private FixedLengthString _exitConditionScript = new FixedLengthString();
      private ShortInteger _unnamed1 = new ShortInteger();
      private Pad _unnamed2;
      private Flags _flags;
public event System.EventHandler BlockNameChanged;
      public OrderCompletionConditionBlock() {
if (this._ruleType is System.ComponentModel.INotifyPropertyChanged)
  (this._ruleType as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._ruleType = new Enum(2);
        this._unnamed0 = new Pad(2);
        this._unnamed2 = new Pad(2);
        this._flags = new Flags(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _ruleType.ToString();
        }
      }
      public Enum RuleType {
        get {
          return this._ruleType;
        }
        set {
          this._ruleType = value;
        }
      }
      public ShortBlockIndex Squad {
        get {
          return this._squad;
        }
        set {
          this._squad = value;
        }
      }
      public ShortBlockIndex SquadGroup {
        get {
          return this._squadGroup;
        }
        set {
          this._squadGroup = value;
        }
      }
      public ShortInteger A {
        get {
          return this._a;
        }
        set {
          this._a = value;
        }
      }
      public Real X {
        get {
          return this._x;
        }
        set {
          this._x = value;
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
      public FixedLengthString ExitConditionScript {
        get {
          return this._exitConditionScript;
        }
        set {
          this._exitConditionScript = value;
        }
      }
      public ShortInteger unnamed1 {
        get {
          return this._unnamed1;
        }
        set {
          this._unnamed1 = value;
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
        _ruleType.Read(reader);
        _squad.Read(reader);
        _squadGroup.Read(reader);
        _a.Read(reader);
        _x.Read(reader);
        _triggerVolume.Read(reader);
        _unnamed0.Read(reader);
        _exitConditionScript.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _flags.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _ruleType.Write(bw);
        _squad.Write(bw);
        _squadGroup.Write(bw);
        _a.Write(bw);
        _x.Write(bw);
        _triggerVolume.Write(bw);
        _unnamed0.Write(bw);
        _exitConditionScript.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _flags.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StructureBspBackgroundSoundPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _backgroundSound = new TagReference();
      private TagReference _insideClusterSound = new TagReference();
      private Pad _unnamed0;
      private Real _cutoffDistance = new Real();
      private Flags _scaleFlags;
      private RealFraction _interiorScale = new RealFraction();
      private RealFraction _portalScale = new RealFraction();
      private RealFraction _exteriorScale = new RealFraction();
      private Real _interpolationSpeed = new Real();
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public StructureBspBackgroundSoundPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(20);
        this._scaleFlags = new Flags(4);
        this._unnamed1 = new Pad(8);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_backgroundSound.Value);
references.Add(_insideClusterSound.Value);
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
      public TagReference BackgroundSound {
        get {
          return this._backgroundSound;
        }
        set {
          this._backgroundSound = value;
        }
      }
      public TagReference InsideClusterSound {
        get {
          return this._insideClusterSound;
        }
        set {
          this._insideClusterSound = value;
        }
      }
      public Real CutoffDistance {
        get {
          return this._cutoffDistance;
        }
        set {
          this._cutoffDistance = value;
        }
      }
      public Flags ScaleFlags {
        get {
          return this._scaleFlags;
        }
        set {
          this._scaleFlags = value;
        }
      }
      public RealFraction InteriorScale {
        get {
          return this._interiorScale;
        }
        set {
          this._interiorScale = value;
        }
      }
      public RealFraction PortalScale {
        get {
          return this._portalScale;
        }
        set {
          this._portalScale = value;
        }
      }
      public RealFraction ExteriorScale {
        get {
          return this._exteriorScale;
        }
        set {
          this._exteriorScale = value;
        }
      }
      public Real InterpolationSpeed {
        get {
          return this._interpolationSpeed;
        }
        set {
          this._interpolationSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _backgroundSound.Read(reader);
        _insideClusterSound.Read(reader);
        _unnamed0.Read(reader);
        _cutoffDistance.Read(reader);
        _scaleFlags.Read(reader);
        _interiorScale.Read(reader);
        _portalScale.Read(reader);
        _exteriorScale.Read(reader);
        _interpolationSpeed.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _backgroundSound.ReadString(reader);
        _insideClusterSound.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _backgroundSound.Write(bw);
        _insideClusterSound.Write(bw);
        _unnamed0.Write(bw);
        _cutoffDistance.Write(bw);
        _scaleFlags.Write(bw);
        _interiorScale.Write(bw);
        _portalScale.Write(bw);
        _exteriorScale.Write(bw);
        _interpolationSpeed.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _backgroundSound.WriteString(writer);
        _insideClusterSound.WriteString(writer);
      }
    }
    public class StructureBspSoundEnvironmentPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _soundEnvironment = new TagReference();
      private Real _cutoffDistance = new Real();
      private Real _interpolationSpeed = new Real();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public StructureBspSoundEnvironmentPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(24);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_soundEnvironment.Value);
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
      public TagReference SoundEnvironment {
        get {
          return this._soundEnvironment;
        }
        set {
          this._soundEnvironment = value;
        }
      }
      public Real CutoffDistance {
        get {
          return this._cutoffDistance;
        }
        set {
          this._cutoffDistance = value;
        }
      }
      public Real InterpolationSpeed {
        get {
          return this._interpolationSpeed;
        }
        set {
          this._interpolationSpeed = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _soundEnvironment.Read(reader);
        _cutoffDistance.Read(reader);
        _interpolationSpeed.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _soundEnvironment.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _soundEnvironment.Write(bw);
        _cutoffDistance.Write(bw);
        _interpolationSpeed.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _soundEnvironment.WriteString(writer);
      }
    }
    public class StructureBspWeatherPaletteBlockBlock : IBlock {
      private FixedLengthString _name = new FixedLengthString();
      private TagReference _weatherSystem = new TagReference();
      private Pad _unnamed0;
      private Pad _unnamed1;
      private Pad _unnamed2;
      private TagReference _wind = new TagReference();
      private RealVector3D _windDirection = new RealVector3D();
      private Real _windMagnitude = new Real();
      private Pad _unnamed3;
      private FixedLengthString _windScaleFunction = new FixedLengthString();
public event System.EventHandler BlockNameChanged;
      public StructureBspWeatherPaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(32);
        this._unnamed3 = new Pad(4);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_weatherSystem.Value);
references.Add(_wind.Value);
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
      public TagReference WeatherSystem {
        get {
          return this._weatherSystem;
        }
        set {
          this._weatherSystem = value;
        }
      }
      public TagReference Wind {
        get {
          return this._wind;
        }
        set {
          this._wind = value;
        }
      }
      public RealVector3D WindDirection {
        get {
          return this._windDirection;
        }
        set {
          this._windDirection = value;
        }
      }
      public Real WindMagnitude {
        get {
          return this._windMagnitude;
        }
        set {
          this._windMagnitude = value;
        }
      }
      public FixedLengthString WindScaleFunction {
        get {
          return this._windScaleFunction;
        }
        set {
          this._windScaleFunction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _weatherSystem.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _wind.Read(reader);
        _windDirection.Read(reader);
        _windMagnitude.Read(reader);
        _unnamed3.Read(reader);
        _windScaleFunction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _weatherSystem.ReadString(reader);
        _wind.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _weatherSystem.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
        _wind.Write(bw);
        _windDirection.Write(bw);
        _windMagnitude.Write(bw);
        _unnamed3.Write(bw);
        _windScaleFunction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _weatherSystem.WriteString(writer);
        _wind.WriteString(writer);
      }
    }
    public class ScenarioClusterDataBlockBlock : IBlock {
      private TagReference _bSP = new TagReference();
      private Block _backgroundSounds = new Block();
      private Block _soundEnvironments = new Block();
      private LongInteger _bSPChecksum = new LongInteger();
      private Block _clusterCentroids = new Block();
      private Block _weatherProperties = new Block();
      private Block _atmosphericFogProperties = new Block();
      public BlockCollection<ScenarioClusterBackgroundSoundsBlockBlock> _backgroundSoundsList = new BlockCollection<ScenarioClusterBackgroundSoundsBlockBlock>();
      public BlockCollection<ScenarioClusterSoundEnvironmentsBlockBlock> _soundEnvironmentsList = new BlockCollection<ScenarioClusterSoundEnvironmentsBlockBlock>();
      public BlockCollection<ScenarioClusterPointsBlockBlock> _clusterCentroidsList = new BlockCollection<ScenarioClusterPointsBlockBlock>();
      public BlockCollection<ScenarioClusterWeatherPropertiesBlockBlock> _weatherPropertiesList = new BlockCollection<ScenarioClusterWeatherPropertiesBlockBlock>();
      public BlockCollection<ScenarioClusterAtmosphericFogPropertiesBlockBlock> _atmosphericFogPropertiesList = new BlockCollection<ScenarioClusterAtmosphericFogPropertiesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterDataBlockBlock() {
      }
      public BlockCollection<ScenarioClusterBackgroundSoundsBlockBlock> BackgroundSounds {
        get {
          return this._backgroundSoundsList;
        }
      }
      public BlockCollection<ScenarioClusterSoundEnvironmentsBlockBlock> SoundEnvironments {
        get {
          return this._soundEnvironmentsList;
        }
      }
      public BlockCollection<ScenarioClusterPointsBlockBlock> ClusterCentroids {
        get {
          return this._clusterCentroidsList;
        }
      }
      public BlockCollection<ScenarioClusterWeatherPropertiesBlockBlock> WeatherProperties {
        get {
          return this._weatherPropertiesList;
        }
      }
      public BlockCollection<ScenarioClusterAtmosphericFogPropertiesBlockBlock> AtmosphericFogProperties {
        get {
          return this._atmosphericFogPropertiesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bSP.Value);
for (int x=0; x<BackgroundSounds.BlockCount; x++)
{
  IBlock block = BackgroundSounds.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SoundEnvironments.BlockCount; x++)
{
  IBlock block = SoundEnvironments.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<ClusterCentroids.BlockCount; x++)
{
  IBlock block = ClusterCentroids.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<WeatherProperties.BlockCount; x++)
{
  IBlock block = WeatherProperties.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<AtmosphericFogProperties.BlockCount; x++)
{
  IBlock block = AtmosphericFogProperties.GetBlock(x);
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
      public TagReference BSP {
        get {
          return this._bSP;
        }
        set {
          this._bSP = value;
        }
      }
      public LongInteger BSPChecksum {
        get {
          return this._bSPChecksum;
        }
        set {
          this._bSPChecksum = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bSP.Read(reader);
        _backgroundSounds.Read(reader);
        _soundEnvironments.Read(reader);
        _bSPChecksum.Read(reader);
        _clusterCentroids.Read(reader);
        _weatherProperties.Read(reader);
        _atmosphericFogProperties.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bSP.ReadString(reader);
        for (x = 0; (x < _backgroundSounds.Count); x = (x + 1)) {
          BackgroundSounds.Add(new ScenarioClusterBackgroundSoundsBlockBlock());
          BackgroundSounds[x].Read(reader);
        }
        for (x = 0; (x < _backgroundSounds.Count); x = (x + 1)) {
          BackgroundSounds[x].ReadChildData(reader);
        }
        for (x = 0; (x < _soundEnvironments.Count); x = (x + 1)) {
          SoundEnvironments.Add(new ScenarioClusterSoundEnvironmentsBlockBlock());
          SoundEnvironments[x].Read(reader);
        }
        for (x = 0; (x < _soundEnvironments.Count); x = (x + 1)) {
          SoundEnvironments[x].ReadChildData(reader);
        }
        for (x = 0; (x < _clusterCentroids.Count); x = (x + 1)) {
          ClusterCentroids.Add(new ScenarioClusterPointsBlockBlock());
          ClusterCentroids[x].Read(reader);
        }
        for (x = 0; (x < _clusterCentroids.Count); x = (x + 1)) {
          ClusterCentroids[x].ReadChildData(reader);
        }
        for (x = 0; (x < _weatherProperties.Count); x = (x + 1)) {
          WeatherProperties.Add(new ScenarioClusterWeatherPropertiesBlockBlock());
          WeatherProperties[x].Read(reader);
        }
        for (x = 0; (x < _weatherProperties.Count); x = (x + 1)) {
          WeatherProperties[x].ReadChildData(reader);
        }
        for (x = 0; (x < _atmosphericFogProperties.Count); x = (x + 1)) {
          AtmosphericFogProperties.Add(new ScenarioClusterAtmosphericFogPropertiesBlockBlock());
          AtmosphericFogProperties[x].Read(reader);
        }
        for (x = 0; (x < _atmosphericFogProperties.Count); x = (x + 1)) {
          AtmosphericFogProperties[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _bSP.Write(bw);
_backgroundSounds.Count = BackgroundSounds.Count;
        _backgroundSounds.Write(bw);
_soundEnvironments.Count = SoundEnvironments.Count;
        _soundEnvironments.Write(bw);
        _bSPChecksum.Write(bw);
_clusterCentroids.Count = ClusterCentroids.Count;
        _clusterCentroids.Write(bw);
_weatherProperties.Count = WeatherProperties.Count;
        _weatherProperties.Write(bw);
_atmosphericFogProperties.Count = AtmosphericFogProperties.Count;
        _atmosphericFogProperties.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bSP.WriteString(writer);
        for (x = 0; (x < _backgroundSounds.Count); x = (x + 1)) {
          BackgroundSounds[x].Write(writer);
        }
        for (x = 0; (x < _backgroundSounds.Count); x = (x + 1)) {
          BackgroundSounds[x].WriteChildData(writer);
        }
        for (x = 0; (x < _soundEnvironments.Count); x = (x + 1)) {
          SoundEnvironments[x].Write(writer);
        }
        for (x = 0; (x < _soundEnvironments.Count); x = (x + 1)) {
          SoundEnvironments[x].WriteChildData(writer);
        }
        for (x = 0; (x < _clusterCentroids.Count); x = (x + 1)) {
          ClusterCentroids[x].Write(writer);
        }
        for (x = 0; (x < _clusterCentroids.Count); x = (x + 1)) {
          ClusterCentroids[x].WriteChildData(writer);
        }
        for (x = 0; (x < _weatherProperties.Count); x = (x + 1)) {
          WeatherProperties[x].Write(writer);
        }
        for (x = 0; (x < _weatherProperties.Count); x = (x + 1)) {
          WeatherProperties[x].WriteChildData(writer);
        }
        for (x = 0; (x < _atmosphericFogProperties.Count); x = (x + 1)) {
          AtmosphericFogProperties[x].Write(writer);
        }
        for (x = 0; (x < _atmosphericFogProperties.Count); x = (x + 1)) {
          AtmosphericFogProperties[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioClusterBackgroundSoundsBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterBackgroundSoundsBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioClusterSoundEnvironmentsBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterSoundEnvironmentsBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioClusterPointsBlockBlock : IBlock {
      private RealPoint3D _centroid = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterPointsBlockBlock() {
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
      public RealPoint3D Centroid {
        get {
          return this._centroid;
        }
        set {
          this._centroid = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _centroid.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _centroid.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioClusterWeatherPropertiesBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterWeatherPropertiesBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioClusterAtmosphericFogPropertiesBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioClusterAtmosphericFogPropertiesBlockBlock() {
if (this._type is System.ComponentModel.INotifyPropertyChanged)
  (this._type as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _type.ToString();
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
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioSpawnDataBlockBlock : IBlock {
      private Real _dynamicSpawnLowerHeight = new Real();
      private Real _dynamicSpawnUpperHeight = new Real();
      private Real _gameObjectResetHeight = new Real();
      private Pad _unnamed0;
      private Block _dynamicSpawnOverloads = new Block();
      private Block _staticRespawnZones = new Block();
      private Block _staticInitialSpawnZones = new Block();
      public BlockCollection<DynamicSpawnZoneOverloadBlockBlock> _dynamicSpawnOverloadsList = new BlockCollection<DynamicSpawnZoneOverloadBlockBlock>();
      public BlockCollection<StaticSpawnZoneBlockBlock> _staticRespawnZonesList = new BlockCollection<StaticSpawnZoneBlockBlock>();
      public BlockCollection<StaticSpawnZoneBlockBlock> _staticInitialSpawnZonesList = new BlockCollection<StaticSpawnZoneBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioSpawnDataBlockBlock() {
        this._unnamed0 = new Pad(60);
      }
      public BlockCollection<DynamicSpawnZoneOverloadBlockBlock> DynamicSpawnOverloads {
        get {
          return this._dynamicSpawnOverloadsList;
        }
      }
      public BlockCollection<StaticSpawnZoneBlockBlock> StaticRespawnZones {
        get {
          return this._staticRespawnZonesList;
        }
      }
      public BlockCollection<StaticSpawnZoneBlockBlock> StaticInitialSpawnZones {
        get {
          return this._staticInitialSpawnZonesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<DynamicSpawnOverloads.BlockCount; x++)
{
  IBlock block = DynamicSpawnOverloads.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StaticRespawnZones.BlockCount; x++)
{
  IBlock block = StaticRespawnZones.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<StaticInitialSpawnZones.BlockCount; x++)
{
  IBlock block = StaticInitialSpawnZones.GetBlock(x);
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
      public Real DynamicSpawnLowerHeight {
        get {
          return this._dynamicSpawnLowerHeight;
        }
        set {
          this._dynamicSpawnLowerHeight = value;
        }
      }
      public Real DynamicSpawnUpperHeight {
        get {
          return this._dynamicSpawnUpperHeight;
        }
        set {
          this._dynamicSpawnUpperHeight = value;
        }
      }
      public Real GameObjectResetHeight {
        get {
          return this._gameObjectResetHeight;
        }
        set {
          this._gameObjectResetHeight = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _dynamicSpawnLowerHeight.Read(reader);
        _dynamicSpawnUpperHeight.Read(reader);
        _gameObjectResetHeight.Read(reader);
        _unnamed0.Read(reader);
        _dynamicSpawnOverloads.Read(reader);
        _staticRespawnZones.Read(reader);
        _staticInitialSpawnZones.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _dynamicSpawnOverloads.Count); x = (x + 1)) {
          DynamicSpawnOverloads.Add(new DynamicSpawnZoneOverloadBlockBlock());
          DynamicSpawnOverloads[x].Read(reader);
        }
        for (x = 0; (x < _dynamicSpawnOverloads.Count); x = (x + 1)) {
          DynamicSpawnOverloads[x].ReadChildData(reader);
        }
        for (x = 0; (x < _staticRespawnZones.Count); x = (x + 1)) {
          StaticRespawnZones.Add(new StaticSpawnZoneBlockBlock());
          StaticRespawnZones[x].Read(reader);
        }
        for (x = 0; (x < _staticRespawnZones.Count); x = (x + 1)) {
          StaticRespawnZones[x].ReadChildData(reader);
        }
        for (x = 0; (x < _staticInitialSpawnZones.Count); x = (x + 1)) {
          StaticInitialSpawnZones.Add(new StaticSpawnZoneBlockBlock());
          StaticInitialSpawnZones[x].Read(reader);
        }
        for (x = 0; (x < _staticInitialSpawnZones.Count); x = (x + 1)) {
          StaticInitialSpawnZones[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _dynamicSpawnLowerHeight.Write(bw);
        _dynamicSpawnUpperHeight.Write(bw);
        _gameObjectResetHeight.Write(bw);
        _unnamed0.Write(bw);
_dynamicSpawnOverloads.Count = DynamicSpawnOverloads.Count;
        _dynamicSpawnOverloads.Write(bw);
_staticRespawnZones.Count = StaticRespawnZones.Count;
        _staticRespawnZones.Write(bw);
_staticInitialSpawnZones.Count = StaticInitialSpawnZones.Count;
        _staticInitialSpawnZones.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _dynamicSpawnOverloads.Count); x = (x + 1)) {
          DynamicSpawnOverloads[x].Write(writer);
        }
        for (x = 0; (x < _dynamicSpawnOverloads.Count); x = (x + 1)) {
          DynamicSpawnOverloads[x].WriteChildData(writer);
        }
        for (x = 0; (x < _staticRespawnZones.Count); x = (x + 1)) {
          StaticRespawnZones[x].Write(writer);
        }
        for (x = 0; (x < _staticRespawnZones.Count); x = (x + 1)) {
          StaticRespawnZones[x].WriteChildData(writer);
        }
        for (x = 0; (x < _staticInitialSpawnZones.Count); x = (x + 1)) {
          StaticInitialSpawnZones[x].Write(writer);
        }
        for (x = 0; (x < _staticInitialSpawnZones.Count); x = (x + 1)) {
          StaticInitialSpawnZones[x].WriteChildData(writer);
        }
      }
    }
    public class DynamicSpawnZoneOverloadBlockBlock : IBlock {
      private Enum _overloadType;
      private Pad _unnamed0;
      private Real _innerRadius = new Real();
      private Real _outerRadius = new Real();
      private Real _weight = new Real();
public event System.EventHandler BlockNameChanged;
      public DynamicSpawnZoneOverloadBlockBlock() {
        this._overloadType = new Enum(2);
        this._unnamed0 = new Pad(2);
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
      public Enum OverloadType {
        get {
          return this._overloadType;
        }
        set {
          this._overloadType = value;
        }
      }
      public Real InnerRadius {
        get {
          return this._innerRadius;
        }
        set {
          this._innerRadius = value;
        }
      }
      public Real OuterRadius {
        get {
          return this._outerRadius;
        }
        set {
          this._outerRadius = value;
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
      public virtual void Read(BinaryReader reader) {
        _overloadType.Read(reader);
        _unnamed0.Read(reader);
        _innerRadius.Read(reader);
        _outerRadius.Read(reader);
        _weight.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _overloadType.Write(bw);
        _unnamed0.Write(bw);
        _innerRadius.Write(bw);
        _outerRadius.Write(bw);
        _weight.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class StaticSpawnZoneBlockBlock : IBlock {
      private StringId _name = new StringId();
      private Flags _relevantTeam;
      private Flags _relevantGames;
      private Flags _flags;
      private RealPoint3D _position = new RealPoint3D();
      private Real _lowerHeight = new Real();
      private Real _upperHeight = new Real();
      private Real _innerRadius = new Real();
      private Real _outerRadius = new Real();
      private Real _weight = new Real();
public event System.EventHandler BlockNameChanged;
      public StaticSpawnZoneBlockBlock() {
        this._relevantTeam = new Flags(4);
        this._relevantGames = new Flags(4);
        this._flags = new Flags(4);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public Flags RelevantTeam {
        get {
          return this._relevantTeam;
        }
        set {
          this._relevantTeam = value;
        }
      }
      public Flags RelevantGames {
        get {
          return this._relevantGames;
        }
        set {
          this._relevantGames = value;
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
      public RealPoint3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Real LowerHeight {
        get {
          return this._lowerHeight;
        }
        set {
          this._lowerHeight = value;
        }
      }
      public Real UpperHeight {
        get {
          return this._upperHeight;
        }
        set {
          this._upperHeight = value;
        }
      }
      public Real InnerRadius {
        get {
          return this._innerRadius;
        }
        set {
          this._innerRadius = value;
        }
      }
      public Real OuterRadius {
        get {
          return this._outerRadius;
        }
        set {
          this._outerRadius = value;
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
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _relevantTeam.Read(reader);
        _relevantGames.Read(reader);
        _flags.Read(reader);
        _position.Read(reader);
        _lowerHeight.Read(reader);
        _upperHeight.Read(reader);
        _innerRadius.Read(reader);
        _outerRadius.Read(reader);
        _weight.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _relevantTeam.Write(bw);
        _relevantGames.Write(bw);
        _flags.Write(bw);
        _position.Write(bw);
        _lowerHeight.Write(bw);
        _upperHeight.Write(bw);
        _innerRadius.Write(bw);
        _outerRadius.Write(bw);
        _weight.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioCrateBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
      private StringId _variantName = new StringId();
      private Flags _activeChangeColors;
      private RGBColor _primaryColor = new RGBColor();
      private RGBColor _secondaryColor = new RGBColor();
      private RGBColor _tertiaryColor = new RGBColor();
      private RGBColor _quaternaryColor = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public ScenarioCrateBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
        this._activeChangeColors = new Flags(4);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public StringId VariantName {
        get {
          return this._variantName;
        }
        set {
          this._variantName = value;
        }
      }
      public Flags ActiveChangeColors {
        get {
          return this._activeChangeColors;
        }
        set {
          this._activeChangeColors = value;
        }
      }
      public RGBColor PrimaryColor {
        get {
          return this._primaryColor;
        }
        set {
          this._primaryColor = value;
        }
      }
      public RGBColor SecondaryColor {
        get {
          return this._secondaryColor;
        }
        set {
          this._secondaryColor = value;
        }
      }
      public RGBColor TertiaryColor {
        get {
          return this._tertiaryColor;
        }
        set {
          this._tertiaryColor = value;
        }
      }
      public RGBColor QuaternaryColor {
        get {
          return this._quaternaryColor;
        }
        set {
          this._quaternaryColor = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
        _variantName.Read(reader);
        _activeChangeColors.Read(reader);
        _primaryColor.Read(reader);
        _secondaryColor.Read(reader);
        _tertiaryColor.Read(reader);
        _quaternaryColor.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _variantName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
        _variantName.Write(bw);
        _activeChangeColors.Write(bw);
        _primaryColor.Write(bw);
        _secondaryColor.Write(bw);
        _tertiaryColor.Write(bw);
        _quaternaryColor.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _variantName.WriteString(writer);
      }
    }
    public class ScenarioCratePaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioCratePaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioAtmosphericFogPaletteBlock : IBlock {
      private StringId _name = new StringId();
      private RealRGBColor _color = new RealRGBColor();
      private Real _spreadDistance = new Real();
      private Pad _unnamed0;
      private RealFraction _maximumDensity = new RealFraction();
      private Real _startDistance = new Real();
      private Real _opaqueDistance = new Real();
      private RealRGBColor _color2 = new RealRGBColor();
      private Pad _unnamed1;
      private RealFraction _maximumDensity2 = new RealFraction();
      private Real _startDistance2 = new Real();
      private Real _opaqueDistance2 = new Real();
      private Pad _unnamed2;
      private RealRGBColor _planarColor = new RealRGBColor();
      private RealFraction _planarMaxDensity = new RealFraction();
      private RealFraction _planarOverrideAmount = new RealFraction();
      private Real _planarMinDistanceBias = new Real();
      private Pad _unnamed3;
      private RealRGBColor _patchyColor = new RealRGBColor();
      private Pad _unnamed4;
      private FractionBounds _patchyDensity = new FractionBounds();
      private RealBounds _patchyDistance = new RealBounds();
      private Pad _unnamed5;
      private TagReference _patchyFog = new TagReference();
      private Block _mixers = new Block();
      private RealFraction _amount = new RealFraction();
      private RealFraction _threshold = new RealFraction();
      private RealFraction _brightness = new RealFraction();
      private Real _gammaPower = new Real();
      private Flags _cameraImmersionFlags;
      private Pad _unnamed6;
      public BlockCollection<ScenarioAtmosphericFogMixerBlockBlock> _mixersList = new BlockCollection<ScenarioAtmosphericFogMixerBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioAtmosphericFogPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(4);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(44);
        this._unnamed4 = new Pad(12);
        this._unnamed5 = new Pad(32);
        this._cameraImmersionFlags = new Flags(2);
        this._unnamed6 = new Pad(2);
      }
      public BlockCollection<ScenarioAtmosphericFogMixerBlockBlock> Mixers {
        get {
          return this._mixersList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_patchyFog.Value);
for (int x=0; x<Mixers.BlockCount; x++)
{
  IBlock block = Mixers.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
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
      public Real SpreadDistance {
        get {
          return this._spreadDistance;
        }
        set {
          this._spreadDistance = value;
        }
      }
      public RealFraction MaximumDensity {
        get {
          return this._maximumDensity;
        }
        set {
          this._maximumDensity = value;
        }
      }
      public Real StartDistance {
        get {
          return this._startDistance;
        }
        set {
          this._startDistance = value;
        }
      }
      public Real OpaqueDistance {
        get {
          return this._opaqueDistance;
        }
        set {
          this._opaqueDistance = value;
        }
      }
      public RealRGBColor Color2 {
        get {
          return this._color2;
        }
        set {
          this._color2 = value;
        }
      }
      public RealFraction MaximumDensity2 {
        get {
          return this._maximumDensity2;
        }
        set {
          this._maximumDensity2 = value;
        }
      }
      public Real StartDistance2 {
        get {
          return this._startDistance2;
        }
        set {
          this._startDistance2 = value;
        }
      }
      public Real OpaqueDistance2 {
        get {
          return this._opaqueDistance2;
        }
        set {
          this._opaqueDistance2 = value;
        }
      }
      public RealRGBColor PlanarColor {
        get {
          return this._planarColor;
        }
        set {
          this._planarColor = value;
        }
      }
      public RealFraction PlanarMaxDensity {
        get {
          return this._planarMaxDensity;
        }
        set {
          this._planarMaxDensity = value;
        }
      }
      public RealFraction PlanarOverrideAmount {
        get {
          return this._planarOverrideAmount;
        }
        set {
          this._planarOverrideAmount = value;
        }
      }
      public Real PlanarMinDistanceBias {
        get {
          return this._planarMinDistanceBias;
        }
        set {
          this._planarMinDistanceBias = value;
        }
      }
      public RealRGBColor PatchyColor {
        get {
          return this._patchyColor;
        }
        set {
          this._patchyColor = value;
        }
      }
      public FractionBounds PatchyDensity {
        get {
          return this._patchyDensity;
        }
        set {
          this._patchyDensity = value;
        }
      }
      public RealBounds PatchyDistance {
        get {
          return this._patchyDistance;
        }
        set {
          this._patchyDistance = value;
        }
      }
      public TagReference PatchyFog {
        get {
          return this._patchyFog;
        }
        set {
          this._patchyFog = value;
        }
      }
      public RealFraction Amount {
        get {
          return this._amount;
        }
        set {
          this._amount = value;
        }
      }
      public RealFraction Threshold {
        get {
          return this._threshold;
        }
        set {
          this._threshold = value;
        }
      }
      public RealFraction Brightness {
        get {
          return this._brightness;
        }
        set {
          this._brightness = value;
        }
      }
      public Real GammaPower {
        get {
          return this._gammaPower;
        }
        set {
          this._gammaPower = value;
        }
      }
      public Flags CameraImmersionFlags {
        get {
          return this._cameraImmersionFlags;
        }
        set {
          this._cameraImmersionFlags = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _color.Read(reader);
        _spreadDistance.Read(reader);
        _unnamed0.Read(reader);
        _maximumDensity.Read(reader);
        _startDistance.Read(reader);
        _opaqueDistance.Read(reader);
        _color2.Read(reader);
        _unnamed1.Read(reader);
        _maximumDensity2.Read(reader);
        _startDistance2.Read(reader);
        _opaqueDistance2.Read(reader);
        _unnamed2.Read(reader);
        _planarColor.Read(reader);
        _planarMaxDensity.Read(reader);
        _planarOverrideAmount.Read(reader);
        _planarMinDistanceBias.Read(reader);
        _unnamed3.Read(reader);
        _patchyColor.Read(reader);
        _unnamed4.Read(reader);
        _patchyDensity.Read(reader);
        _patchyDistance.Read(reader);
        _unnamed5.Read(reader);
        _patchyFog.Read(reader);
        _mixers.Read(reader);
        _amount.Read(reader);
        _threshold.Read(reader);
        _brightness.Read(reader);
        _gammaPower.Read(reader);
        _cameraImmersionFlags.Read(reader);
        _unnamed6.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _patchyFog.ReadString(reader);
        for (x = 0; (x < _mixers.Count); x = (x + 1)) {
          Mixers.Add(new ScenarioAtmosphericFogMixerBlockBlock());
          Mixers[x].Read(reader);
        }
        for (x = 0; (x < _mixers.Count); x = (x + 1)) {
          Mixers[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _color.Write(bw);
        _spreadDistance.Write(bw);
        _unnamed0.Write(bw);
        _maximumDensity.Write(bw);
        _startDistance.Write(bw);
        _opaqueDistance.Write(bw);
        _color2.Write(bw);
        _unnamed1.Write(bw);
        _maximumDensity2.Write(bw);
        _startDistance2.Write(bw);
        _opaqueDistance2.Write(bw);
        _unnamed2.Write(bw);
        _planarColor.Write(bw);
        _planarMaxDensity.Write(bw);
        _planarOverrideAmount.Write(bw);
        _planarMinDistanceBias.Write(bw);
        _unnamed3.Write(bw);
        _patchyColor.Write(bw);
        _unnamed4.Write(bw);
        _patchyDensity.Write(bw);
        _patchyDistance.Write(bw);
        _unnamed5.Write(bw);
        _patchyFog.Write(bw);
_mixers.Count = Mixers.Count;
        _mixers.Write(bw);
        _amount.Write(bw);
        _threshold.Write(bw);
        _brightness.Write(bw);
        _gammaPower.Write(bw);
        _cameraImmersionFlags.Write(bw);
        _unnamed6.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _patchyFog.WriteString(writer);
        for (x = 0; (x < _mixers.Count); x = (x + 1)) {
          Mixers[x].Write(writer);
        }
        for (x = 0; (x < _mixers.Count); x = (x + 1)) {
          Mixers[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioAtmosphericFogMixerBlockBlock : IBlock {
      private Pad _unnamed0;
      private StringId _atmosphericFogSource = new StringId();
      private StringId _interpolator = new StringId();
      private Skip _unnamed1;
      private Skip _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioAtmosphericFogMixerBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Skip(2);
        this._unnamed2 = new Skip(2);
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
      public StringId AtmosphericFogSource {
        get {
          return this._atmosphericFogSource;
        }
        set {
          this._atmosphericFogSource = value;
        }
      }
      public StringId Interpolator {
        get {
          return this._interpolator;
        }
        set {
          this._interpolator = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _atmosphericFogSource.Read(reader);
        _interpolator.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _atmosphericFogSource.ReadString(reader);
        _interpolator.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _atmosphericFogSource.Write(bw);
        _interpolator.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _atmosphericFogSource.WriteString(writer);
        _interpolator.WriteString(writer);
      }
    }
    public class ScenarioPlanarFogPaletteBlock : IBlock {
      private StringId _name = new StringId();
      private TagReference _planarFog = new TagReference();
      private Pad _unnamed0;
      private Pad _unnamed1;
public event System.EventHandler BlockNameChanged;
      public ScenarioPlanarFogPaletteBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._unnamed1 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_planarFog.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _name.ToString();
        }
      }
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public TagReference PlanarFog {
        get {
          return this._planarFog;
        }
        set {
          this._planarFog = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _planarFog.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
        _planarFog.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _planarFog.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
        _planarFog.WriteString(writer);
      }
    }
    public class FlockDefinitionBlockBlock : IBlock {
      private ShortBlockIndex _bsp = new ShortBlockIndex();
      private Pad _unnamed0;
      private ShortBlockIndex _boundingVolume = new ShortBlockIndex();
      private Flags _flags;
      private Real _ecologyMargin = new Real();
      private Block _sources = new Block();
      private Block _sinks = new Block();
      private Real _productionFrequency = new Real();
      private RealBounds _scale = new RealBounds();
      private TagReference _creature = new TagReference();
      private ShortIntegerBounds _boidCount = new ShortIntegerBounds();
      private Real _neighborhoodRadius = new Real();
      private Real _avoidanceRadius = new Real();
      private Real _forwardScale = new Real();
      private Real _alignmentScale = new Real();
      private Real _avoidanceScale = new Real();
      private Real _levelingForceScale = new Real();
      private Real _sinkScale = new Real();
      private Angle _perceptionAngle = new Angle();
      private Real _averageThrottle = new Real();
      private Real _maximumThrottle = new Real();
      private Real _positionScale = new Real();
      private Real _positionMinRadius = new Real();
      private Real _positionMaxRadius = new Real();
      private Real _movementWeightThreshold = new Real();
      private Real _dangerRadius = new Real();
      private Real _dangerScale = new Real();
      private Real _randomOffsetScale = new Real();
      private RealBounds _randomOffsetPeriod = new RealBounds();
      private StringId _flockName = new StringId();
      public BlockCollection<FlockSourceBlockBlock> _sourcesList = new BlockCollection<FlockSourceBlockBlock>();
      public BlockCollection<FlockSinkBlockBlock> _sinksList = new BlockCollection<FlockSinkBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public FlockDefinitionBlockBlock() {
if (this._creature is System.ComponentModel.INotifyPropertyChanged)
  (this._creature as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
        this._flags = new Flags(2);
      }
      public BlockCollection<FlockSourceBlockBlock> Sources {
        get {
          return this._sourcesList;
        }
      }
      public BlockCollection<FlockSinkBlockBlock> Sinks {
        get {
          return this._sinksList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_creature.Value);
for (int x=0; x<Sources.BlockCount; x++)
{
  IBlock block = Sources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Sinks.BlockCount; x++)
{
  IBlock block = Sinks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _creature.ToString();
        }
      }
      public ShortBlockIndex Bsp {
        get {
          return this._bsp;
        }
        set {
          this._bsp = value;
        }
      }
      public ShortBlockIndex BoundingVolume {
        get {
          return this._boundingVolume;
        }
        set {
          this._boundingVolume = value;
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
      public Real EcologyMargin {
        get {
          return this._ecologyMargin;
        }
        set {
          this._ecologyMargin = value;
        }
      }
      public Real ProductionFrequency {
        get {
          return this._productionFrequency;
        }
        set {
          this._productionFrequency = value;
        }
      }
      public RealBounds Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public TagReference Creature {
        get {
          return this._creature;
        }
        set {
          this._creature = value;
        }
      }
      public ShortIntegerBounds BoidCount {
        get {
          return this._boidCount;
        }
        set {
          this._boidCount = value;
        }
      }
      public Real NeighborhoodRadius {
        get {
          return this._neighborhoodRadius;
        }
        set {
          this._neighborhoodRadius = value;
        }
      }
      public Real AvoidanceRadius {
        get {
          return this._avoidanceRadius;
        }
        set {
          this._avoidanceRadius = value;
        }
      }
      public Real ForwardScale {
        get {
          return this._forwardScale;
        }
        set {
          this._forwardScale = value;
        }
      }
      public Real AlignmentScale {
        get {
          return this._alignmentScale;
        }
        set {
          this._alignmentScale = value;
        }
      }
      public Real AvoidanceScale {
        get {
          return this._avoidanceScale;
        }
        set {
          this._avoidanceScale = value;
        }
      }
      public Real LevelingForceScale {
        get {
          return this._levelingForceScale;
        }
        set {
          this._levelingForceScale = value;
        }
      }
      public Real SinkScale {
        get {
          return this._sinkScale;
        }
        set {
          this._sinkScale = value;
        }
      }
      public Angle PerceptionAngle {
        get {
          return this._perceptionAngle;
        }
        set {
          this._perceptionAngle = value;
        }
      }
      public Real AverageThrottle {
        get {
          return this._averageThrottle;
        }
        set {
          this._averageThrottle = value;
        }
      }
      public Real MaximumThrottle {
        get {
          return this._maximumThrottle;
        }
        set {
          this._maximumThrottle = value;
        }
      }
      public Real PositionScale {
        get {
          return this._positionScale;
        }
        set {
          this._positionScale = value;
        }
      }
      public Real PositionMinRadius {
        get {
          return this._positionMinRadius;
        }
        set {
          this._positionMinRadius = value;
        }
      }
      public Real PositionMaxRadius {
        get {
          return this._positionMaxRadius;
        }
        set {
          this._positionMaxRadius = value;
        }
      }
      public Real MovementWeightThreshold {
        get {
          return this._movementWeightThreshold;
        }
        set {
          this._movementWeightThreshold = value;
        }
      }
      public Real DangerRadius {
        get {
          return this._dangerRadius;
        }
        set {
          this._dangerRadius = value;
        }
      }
      public Real DangerScale {
        get {
          return this._dangerScale;
        }
        set {
          this._dangerScale = value;
        }
      }
      public Real RandomOffsetScale {
        get {
          return this._randomOffsetScale;
        }
        set {
          this._randomOffsetScale = value;
        }
      }
      public RealBounds RandomOffsetPeriod {
        get {
          return this._randomOffsetPeriod;
        }
        set {
          this._randomOffsetPeriod = value;
        }
      }
      public StringId FlockName {
        get {
          return this._flockName;
        }
        set {
          this._flockName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bsp.Read(reader);
        _unnamed0.Read(reader);
        _boundingVolume.Read(reader);
        _flags.Read(reader);
        _ecologyMargin.Read(reader);
        _sources.Read(reader);
        _sinks.Read(reader);
        _productionFrequency.Read(reader);
        _scale.Read(reader);
        _creature.Read(reader);
        _boidCount.Read(reader);
        _neighborhoodRadius.Read(reader);
        _avoidanceRadius.Read(reader);
        _forwardScale.Read(reader);
        _alignmentScale.Read(reader);
        _avoidanceScale.Read(reader);
        _levelingForceScale.Read(reader);
        _sinkScale.Read(reader);
        _perceptionAngle.Read(reader);
        _averageThrottle.Read(reader);
        _maximumThrottle.Read(reader);
        _positionScale.Read(reader);
        _positionMinRadius.Read(reader);
        _positionMaxRadius.Read(reader);
        _movementWeightThreshold.Read(reader);
        _dangerRadius.Read(reader);
        _dangerScale.Read(reader);
        _randomOffsetScale.Read(reader);
        _randomOffsetPeriod.Read(reader);
        _flockName.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _sources.Count); x = (x + 1)) {
          Sources.Add(new FlockSourceBlockBlock());
          Sources[x].Read(reader);
        }
        for (x = 0; (x < _sources.Count); x = (x + 1)) {
          Sources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _sinks.Count); x = (x + 1)) {
          Sinks.Add(new FlockSinkBlockBlock());
          Sinks[x].Read(reader);
        }
        for (x = 0; (x < _sinks.Count); x = (x + 1)) {
          Sinks[x].ReadChildData(reader);
        }
        _creature.ReadString(reader);
        _flockName.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _bsp.Write(bw);
        _unnamed0.Write(bw);
        _boundingVolume.Write(bw);
        _flags.Write(bw);
        _ecologyMargin.Write(bw);
_sources.Count = Sources.Count;
        _sources.Write(bw);
_sinks.Count = Sinks.Count;
        _sinks.Write(bw);
        _productionFrequency.Write(bw);
        _scale.Write(bw);
        _creature.Write(bw);
        _boidCount.Write(bw);
        _neighborhoodRadius.Write(bw);
        _avoidanceRadius.Write(bw);
        _forwardScale.Write(bw);
        _alignmentScale.Write(bw);
        _avoidanceScale.Write(bw);
        _levelingForceScale.Write(bw);
        _sinkScale.Write(bw);
        _perceptionAngle.Write(bw);
        _averageThrottle.Write(bw);
        _maximumThrottle.Write(bw);
        _positionScale.Write(bw);
        _positionMinRadius.Write(bw);
        _positionMaxRadius.Write(bw);
        _movementWeightThreshold.Write(bw);
        _dangerRadius.Write(bw);
        _dangerScale.Write(bw);
        _randomOffsetScale.Write(bw);
        _randomOffsetPeriod.Write(bw);
        _flockName.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _sources.Count); x = (x + 1)) {
          Sources[x].Write(writer);
        }
        for (x = 0; (x < _sources.Count); x = (x + 1)) {
          Sources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _sinks.Count); x = (x + 1)) {
          Sinks[x].Write(writer);
        }
        for (x = 0; (x < _sinks.Count); x = (x + 1)) {
          Sinks[x].WriteChildData(writer);
        }
        _creature.WriteString(writer);
        _flockName.WriteString(writer);
      }
    }
    public class FlockSourceBlockBlock : IBlock {
      private RealVector3D _position = new RealVector3D();
      private RealEulerAngles2D _startingYawPitch = new RealEulerAngles2D();
      private Real _radius = new Real();
      private Real _weight = new Real();
public event System.EventHandler BlockNameChanged;
      public FlockSourceBlockBlock() {
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
      public RealVector3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public RealEulerAngles2D StartingYawPitch {
        get {
          return this._startingYawPitch;
        }
        set {
          this._startingYawPitch = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
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
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _startingYawPitch.Read(reader);
        _radius.Read(reader);
        _weight.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _startingYawPitch.Write(bw);
        _radius.Write(bw);
        _weight.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class FlockSinkBlockBlock : IBlock {
      private RealVector3D _position = new RealVector3D();
      private Real _radius = new Real();
public event System.EventHandler BlockNameChanged;
      public FlockSinkBlockBlock() {
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
      public RealVector3D Position {
        get {
          return this._position;
        }
        set {
          this._position = value;
        }
      }
      public Real Radius {
        get {
          return this._radius;
        }
        set {
          this._radius = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _radius.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _radius.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorPlacementDefinitionBlockBlock : IBlock {
      private RealPoint3D _gridOrigin = new RealPoint3D();
      private LongInteger _cellCountPerDimension = new LongInteger();
      private Block _cacheBlocks = new Block();
      private Block _groups = new Block();
      private Block _cells = new Block();
      private Block _decals = new Block();
      public BlockCollection<DecoratorCacheBlockBlockBlock> _cacheBlocksList = new BlockCollection<DecoratorCacheBlockBlockBlock>();
      public BlockCollection<DecoratorGroupBlockBlock> _groupsList = new BlockCollection<DecoratorGroupBlockBlock>();
      public BlockCollection<DecoratorCellCollectionBlockBlock> _cellsList = new BlockCollection<DecoratorCellCollectionBlockBlock>();
      public BlockCollection<DecoratorProjectedDecalBlockBlock> _decalsList = new BlockCollection<DecoratorProjectedDecalBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorPlacementDefinitionBlockBlock() {
      }
      public BlockCollection<DecoratorCacheBlockBlockBlock> CacheBlocks {
        get {
          return this._cacheBlocksList;
        }
      }
      public BlockCollection<DecoratorGroupBlockBlock> Groups {
        get {
          return this._groupsList;
        }
      }
      public BlockCollection<DecoratorCellCollectionBlockBlock> Cells {
        get {
          return this._cellsList;
        }
      }
      public BlockCollection<DecoratorProjectedDecalBlockBlock> Decals {
        get {
          return this._decalsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<CacheBlocks.BlockCount; x++)
{
  IBlock block = CacheBlocks.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Groups.BlockCount; x++)
{
  IBlock block = Groups.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Cells.BlockCount; x++)
{
  IBlock block = Cells.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Decals.BlockCount; x++)
{
  IBlock block = Decals.GetBlock(x);
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
      public RealPoint3D GridOrigin {
        get {
          return this._gridOrigin;
        }
        set {
          this._gridOrigin = value;
        }
      }
      public LongInteger CellCountPerDimension {
        get {
          return this._cellCountPerDimension;
        }
        set {
          this._cellCountPerDimension = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _gridOrigin.Read(reader);
        _cellCountPerDimension.Read(reader);
        _cacheBlocks.Read(reader);
        _groups.Read(reader);
        _cells.Read(reader);
        _decals.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks.Add(new DecoratorCacheBlockBlockBlock());
          CacheBlocks[x].Read(reader);
        }
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].ReadChildData(reader);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups.Add(new DecoratorGroupBlockBlock());
          Groups[x].Read(reader);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells.Add(new DecoratorCellCollectionBlockBlock());
          Cells[x].Read(reader);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals.Add(new DecoratorProjectedDecalBlockBlock());
          Decals[x].Read(reader);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _gridOrigin.Write(bw);
        _cellCountPerDimension.Write(bw);
_cacheBlocks.Count = CacheBlocks.Count;
        _cacheBlocks.Write(bw);
_groups.Count = Groups.Count;
        _groups.Write(bw);
_cells.Count = Cells.Count;
        _cells.Write(bw);
_decals.Count = Decals.Count;
        _decals.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].Write(writer);
        }
        for (x = 0; (x < _cacheBlocks.Count); x = (x + 1)) {
          CacheBlocks[x].WriteChildData(writer);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].Write(writer);
        }
        for (x = 0; (x < _groups.Count); x = (x + 1)) {
          Groups[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].Write(writer);
        }
        for (x = 0; (x < _cells.Count); x = (x + 1)) {
          Cells[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].Write(writer);
        }
        for (x = 0; (x < _decals.Count); x = (x + 1)) {
          Decals[x].WriteChildData(writer);
        }
      }
    }
    public class DecoratorCacheBlockBlockBlock : IBlock {
      private LongInteger _blockOffset = new LongInteger();
      private LongInteger _blockSize = new LongInteger();
      private LongInteger _sectionDataSize = new LongInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private Block _resources = new Block();
      private Pad _unnamed0;
      private ShortInteger _ownerTagSectionOffset = new ShortInteger();
      private Pad _unnamed1;
      private Pad _unnamed2;
      private Block _cacheBlockData = new Block();
      private Pad _unnamed3;
      private Pad _unnamed4;
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> _resourcesList = new BlockCollection<GlobalGeometryBlockResourceBlockBlock>();
      public BlockCollection<DecoratorCacheBlockDataBlockBlock> _cacheBlockDataList = new BlockCollection<DecoratorCacheBlockDataBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorCacheBlockBlockBlock() {
        this._unnamed0 = new Pad(4);
        this._unnamed1 = new Pad(2);
        this._unnamed2 = new Pad(4);
        this._unnamed3 = new Pad(4);
        this._unnamed4 = new Pad(4);
      }
      public BlockCollection<GlobalGeometryBlockResourceBlockBlock> Resources {
        get {
          return this._resourcesList;
        }
      }
      public BlockCollection<DecoratorCacheBlockDataBlockBlock> CacheBlockData {
        get {
          return this._cacheBlockDataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Resources.BlockCount; x++)
{
  IBlock block = Resources.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<CacheBlockData.BlockCount; x++)
{
  IBlock block = CacheBlockData.GetBlock(x);
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
      public LongInteger BlockOffset {
        get {
          return this._blockOffset;
        }
        set {
          this._blockOffset = value;
        }
      }
      public LongInteger BlockSize {
        get {
          return this._blockSize;
        }
        set {
          this._blockSize = value;
        }
      }
      public LongInteger SectionDataSize {
        get {
          return this._sectionDataSize;
        }
        set {
          this._sectionDataSize = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public ShortInteger OwnerTagSectionOffset {
        get {
          return this._ownerTagSectionOffset;
        }
        set {
          this._ownerTagSectionOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _blockOffset.Read(reader);
        _blockSize.Read(reader);
        _sectionDataSize.Read(reader);
        _resourceDataSize.Read(reader);
        _resources.Read(reader);
        _unnamed0.Read(reader);
        _ownerTagSectionOffset.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
        _cacheBlockData.Read(reader);
        _unnamed3.Read(reader);
        _unnamed4.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources.Add(new GlobalGeometryBlockResourceBlockBlock());
          Resources[x].Read(reader);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].ReadChildData(reader);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData.Add(new DecoratorCacheBlockDataBlockBlock());
          CacheBlockData[x].Read(reader);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _blockOffset.Write(bw);
        _blockSize.Write(bw);
        _sectionDataSize.Write(bw);
        _resourceDataSize.Write(bw);
_resources.Count = Resources.Count;
        _resources.Write(bw);
        _unnamed0.Write(bw);
        _ownerTagSectionOffset.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
_cacheBlockData.Count = CacheBlockData.Count;
        _cacheBlockData.Write(bw);
        _unnamed3.Write(bw);
        _unnamed4.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].Write(writer);
        }
        for (x = 0; (x < _resources.Count); x = (x + 1)) {
          Resources[x].WriteChildData(writer);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].Write(writer);
        }
        for (x = 0; (x < _cacheBlockData.Count); x = (x + 1)) {
          CacheBlockData[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalGeometryBlockResourceBlockBlock : IBlock {
      private Enum _type;
      private Pad _unnamed0;
      private ShortInteger _primaryLocator = new ShortInteger();
      private ShortInteger _secondaryLocator = new ShortInteger();
      private LongInteger _resourceDataSize = new LongInteger();
      private LongInteger _resourceDataOffset = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalGeometryBlockResourceBlockBlock() {
        this._type = new Enum(1);
        this._unnamed0 = new Pad(3);
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
      public ShortInteger PrimaryLocator {
        get {
          return this._primaryLocator;
        }
        set {
          this._primaryLocator = value;
        }
      }
      public ShortInteger SecondaryLocator {
        get {
          return this._secondaryLocator;
        }
        set {
          this._secondaryLocator = value;
        }
      }
      public LongInteger ResourceDataSize {
        get {
          return this._resourceDataSize;
        }
        set {
          this._resourceDataSize = value;
        }
      }
      public LongInteger ResourceDataOffset {
        get {
          return this._resourceDataOffset;
        }
        set {
          this._resourceDataOffset = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _unnamed0.Read(reader);
        _primaryLocator.Read(reader);
        _secondaryLocator.Read(reader);
        _resourceDataSize.Read(reader);
        _resourceDataOffset.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _unnamed0.Write(bw);
        _primaryLocator.Write(bw);
        _secondaryLocator.Write(bw);
        _resourceDataSize.Write(bw);
        _resourceDataOffset.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorCacheBlockDataBlockBlock : IBlock {
      private Block _placements = new Block();
      private Block _decalVertices = new Block();
      private Block _decalIndices = new Block();
      private Skip _decalVertexBuffer;
      private Pad _unnamed0;
      private Block _spriteVertices = new Block();
      private Block _spriteIndices = new Block();
      private Skip _spriteVertexBuffer;
      private Pad _unnamed1;
      public BlockCollection<DecoratorPlacementBlockBlock> _placementsList = new BlockCollection<DecoratorPlacementBlockBlock>();
      public BlockCollection<DecalVerticesBlockBlock> _decalVerticesList = new BlockCollection<DecalVerticesBlockBlock>();
      public BlockCollection<IndicesBlockBlock> _decalIndicesList = new BlockCollection<IndicesBlockBlock>();
      public BlockCollection<SpriteVerticesBlockBlock> _spriteVerticesList = new BlockCollection<SpriteVerticesBlockBlock>();
      public BlockCollection<IndicesBlockBlock> _spriteIndicesList = new BlockCollection<IndicesBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public DecoratorCacheBlockDataBlockBlock() {
        this._decalVertexBuffer = new Skip(32);
        this._unnamed0 = new Pad(16);
        this._spriteVertexBuffer = new Skip(32);
        this._unnamed1 = new Pad(16);
      }
      public BlockCollection<DecoratorPlacementBlockBlock> Placements {
        get {
          return this._placementsList;
        }
      }
      public BlockCollection<DecalVerticesBlockBlock> DecalVertices {
        get {
          return this._decalVerticesList;
        }
      }
      public BlockCollection<IndicesBlockBlock> DecalIndices {
        get {
          return this._decalIndicesList;
        }
      }
      public BlockCollection<SpriteVerticesBlockBlock> SpriteVertices {
        get {
          return this._spriteVerticesList;
        }
      }
      public BlockCollection<IndicesBlockBlock> SpriteIndices {
        get {
          return this._spriteIndicesList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Placements.BlockCount; x++)
{
  IBlock block = Placements.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalVertices.BlockCount; x++)
{
  IBlock block = DecalVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<DecalIndices.BlockCount; x++)
{
  IBlock block = DecalIndices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpriteVertices.BlockCount; x++)
{
  IBlock block = SpriteVertices.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<SpriteIndices.BlockCount; x++)
{
  IBlock block = SpriteIndices.GetBlock(x);
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
        _placements.Read(reader);
        _decalVertices.Read(reader);
        _decalIndices.Read(reader);
        _decalVertexBuffer.Read(reader);
        _unnamed0.Read(reader);
        _spriteVertices.Read(reader);
        _spriteIndices.Read(reader);
        _spriteVertexBuffer.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements.Add(new DecoratorPlacementBlockBlock());
          Placements[x].Read(reader);
        }
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices.Add(new DecalVerticesBlockBlock());
          DecalVertices[x].Read(reader);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices.Add(new IndicesBlockBlock());
          DecalIndices[x].Read(reader);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices.Add(new SpriteVerticesBlockBlock());
          SpriteVertices[x].Read(reader);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].ReadChildData(reader);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices.Add(new IndicesBlockBlock());
          SpriteIndices[x].Read(reader);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
_placements.Count = Placements.Count;
        _placements.Write(bw);
_decalVertices.Count = DecalVertices.Count;
        _decalVertices.Write(bw);
_decalIndices.Count = DecalIndices.Count;
        _decalIndices.Write(bw);
        _decalVertexBuffer.Write(bw);
        _unnamed0.Write(bw);
_spriteVertices.Count = SpriteVertices.Count;
        _spriteVertices.Write(bw);
_spriteIndices.Count = SpriteIndices.Count;
        _spriteIndices.Write(bw);
        _spriteVertexBuffer.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].Write(writer);
        }
        for (x = 0; (x < _placements.Count); x = (x + 1)) {
          Placements[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].Write(writer);
        }
        for (x = 0; (x < _decalVertices.Count); x = (x + 1)) {
          DecalVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].Write(writer);
        }
        for (x = 0; (x < _decalIndices.Count); x = (x + 1)) {
          DecalIndices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].Write(writer);
        }
        for (x = 0; (x < _spriteVertices.Count); x = (x + 1)) {
          SpriteVertices[x].WriteChildData(writer);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].Write(writer);
        }
        for (x = 0; (x < _spriteIndices.Count); x = (x + 1)) {
          SpriteIndices[x].WriteChildData(writer);
        }
      }
    }
    public class DecoratorPlacementBlockBlock : IBlock {
      private LongInteger _internalData1 = new LongInteger();
      private LongInteger _compressedPosition = new LongInteger();
      private RGBColor _tintColor = new RGBColor();
      private RGBColor _lightmapColor = new RGBColor();
      private LongInteger _compressedLightDirection = new LongInteger();
      private LongInteger _compressedLight2Direction = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorPlacementBlockBlock() {
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
      public LongInteger InternalData1 {
        get {
          return this._internalData1;
        }
        set {
          this._internalData1 = value;
        }
      }
      public LongInteger CompressedPosition {
        get {
          return this._compressedPosition;
        }
        set {
          this._compressedPosition = value;
        }
      }
      public RGBColor TintColor {
        get {
          return this._tintColor;
        }
        set {
          this._tintColor = value;
        }
      }
      public RGBColor LightmapColor {
        get {
          return this._lightmapColor;
        }
        set {
          this._lightmapColor = value;
        }
      }
      public LongInteger CompressedLightDirection {
        get {
          return this._compressedLightDirection;
        }
        set {
          this._compressedLightDirection = value;
        }
      }
      public LongInteger CompressedLight2Direction {
        get {
          return this._compressedLight2Direction;
        }
        set {
          this._compressedLight2Direction = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _internalData1.Read(reader);
        _compressedPosition.Read(reader);
        _tintColor.Read(reader);
        _lightmapColor.Read(reader);
        _compressedLightDirection.Read(reader);
        _compressedLight2Direction.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _internalData1.Write(bw);
        _compressedPosition.Write(bw);
        _tintColor.Write(bw);
        _lightmapColor.Write(bw);
        _compressedLightDirection.Write(bw);
        _compressedLight2Direction.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecalVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealPoint2D _texcoord0 = new RealPoint2D();
      private RealPoint2D _texcoord1 = new RealPoint2D();
      private RGBColor _color = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public DecalVerticesBlockBlock() {
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
      public RealPoint2D Texcoord0 {
        get {
          return this._texcoord0;
        }
        set {
          this._texcoord0 = value;
        }
      }
      public RealPoint2D Texcoord1 {
        get {
          return this._texcoord1;
        }
        set {
          this._texcoord1 = value;
        }
      }
      public RGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _texcoord0.Read(reader);
        _texcoord1.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _texcoord0.Write(bw);
        _texcoord1.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class IndicesBlockBlock : IBlock {
      private ShortInteger _index = new ShortInteger();
public event System.EventHandler BlockNameChanged;
      public IndicesBlockBlock() {
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
      public ShortInteger Index {
        get {
          return this._index;
        }
        set {
          this._index = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _index.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _index.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class SpriteVerticesBlockBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _offset = new RealVector3D();
      private RealVector3D _axis = new RealVector3D();
      private RealPoint2D _texcoord = new RealPoint2D();
      private RGBColor _color = new RGBColor();
public event System.EventHandler BlockNameChanged;
      public SpriteVerticesBlockBlock() {
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
      public RealVector3D Offset {
        get {
          return this._offset;
        }
        set {
          this._offset = value;
        }
      }
      public RealVector3D Axis {
        get {
          return this._axis;
        }
        set {
          this._axis = value;
        }
      }
      public RealPoint2D Texcoord {
        get {
          return this._texcoord;
        }
        set {
          this._texcoord = value;
        }
      }
      public RGBColor Color {
        get {
          return this._color;
        }
        set {
          this._color = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _position.Read(reader);
        _offset.Read(reader);
        _axis.Read(reader);
        _texcoord.Read(reader);
        _color.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
        _offset.Write(bw);
        _axis.Write(bw);
        _texcoord.Write(bw);
        _color.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorGroupBlockBlock : IBlock {
      private CharBlockIndex _decoratorSet = new CharBlockIndex();
      private Enum _decoratorType;
      private CharInteger _shaderIndex = new CharInteger();
      private CharInteger _compressedRadius = new CharInteger();
      private ShortInteger _cluster = new ShortInteger();
      private ShortBlockIndex _cacheBlock = new ShortBlockIndex();
      private ShortInteger _decoratorStartIndex = new ShortInteger();
      private ShortInteger _decoratorCount = new ShortInteger();
      private ShortInteger _vertexStartOffset = new ShortInteger();
      private ShortInteger _vertexCount = new ShortInteger();
      private ShortInteger _indexStartOffset = new ShortInteger();
      private ShortInteger _indexCount = new ShortInteger();
      private LongInteger _compressedBoundingCenter = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorGroupBlockBlock() {
        this._decoratorType = new Enum(1);
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
      public CharBlockIndex DecoratorSet {
        get {
          return this._decoratorSet;
        }
        set {
          this._decoratorSet = value;
        }
      }
      public Enum DecoratorType {
        get {
          return this._decoratorType;
        }
        set {
          this._decoratorType = value;
        }
      }
      public CharInteger ShaderIndex {
        get {
          return this._shaderIndex;
        }
        set {
          this._shaderIndex = value;
        }
      }
      public CharInteger CompressedRadius {
        get {
          return this._compressedRadius;
        }
        set {
          this._compressedRadius = value;
        }
      }
      public ShortInteger Cluster {
        get {
          return this._cluster;
        }
        set {
          this._cluster = value;
        }
      }
      public ShortBlockIndex CacheBlock {
        get {
          return this._cacheBlock;
        }
        set {
          this._cacheBlock = value;
        }
      }
      public ShortInteger DecoratorStartIndex {
        get {
          return this._decoratorStartIndex;
        }
        set {
          this._decoratorStartIndex = value;
        }
      }
      public ShortInteger DecoratorCount {
        get {
          return this._decoratorCount;
        }
        set {
          this._decoratorCount = value;
        }
      }
      public ShortInteger VertexStartOffset {
        get {
          return this._vertexStartOffset;
        }
        set {
          this._vertexStartOffset = value;
        }
      }
      public ShortInteger VertexCount {
        get {
          return this._vertexCount;
        }
        set {
          this._vertexCount = value;
        }
      }
      public ShortInteger IndexStartOffset {
        get {
          return this._indexStartOffset;
        }
        set {
          this._indexStartOffset = value;
        }
      }
      public ShortInteger IndexCount {
        get {
          return this._indexCount;
        }
        set {
          this._indexCount = value;
        }
      }
      public LongInteger CompressedBoundingCenter {
        get {
          return this._compressedBoundingCenter;
        }
        set {
          this._compressedBoundingCenter = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decoratorSet.Read(reader);
        _decoratorType.Read(reader);
        _shaderIndex.Read(reader);
        _compressedRadius.Read(reader);
        _cluster.Read(reader);
        _cacheBlock.Read(reader);
        _decoratorStartIndex.Read(reader);
        _decoratorCount.Read(reader);
        _vertexStartOffset.Read(reader);
        _vertexCount.Read(reader);
        _indexStartOffset.Read(reader);
        _indexCount.Read(reader);
        _compressedBoundingCenter.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decoratorSet.Write(bw);
        _decoratorType.Write(bw);
        _shaderIndex.Write(bw);
        _compressedRadius.Write(bw);
        _cluster.Write(bw);
        _cacheBlock.Write(bw);
        _decoratorStartIndex.Write(bw);
        _decoratorCount.Write(bw);
        _vertexStartOffset.Write(bw);
        _vertexCount.Write(bw);
        _indexStartOffset.Write(bw);
        _indexCount.Write(bw);
        _compressedBoundingCenter.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorCellCollectionBlockBlock : IBlock {
      private ShortInteger _childIndex = new ShortInteger();
      private ShortInteger _childIndex2 = new ShortInteger();
      private ShortInteger _childIndex3 = new ShortInteger();
      private ShortInteger _childIndex4 = new ShortInteger();
      private ShortInteger _childIndex5 = new ShortInteger();
      private ShortInteger _childIndex6 = new ShortInteger();
      private ShortInteger _childIndex7 = new ShortInteger();
      private ShortInteger _childIndex8 = new ShortInteger();
      private ShortBlockIndex _cacheBlockIndex = new ShortBlockIndex();
      private ShortInteger _groupCount = new ShortInteger();
      private LongInteger _groupStartIndex = new LongInteger();
public event System.EventHandler BlockNameChanged;
      public DecoratorCellCollectionBlockBlock() {
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
      public ShortInteger ChildIndex {
        get {
          return this._childIndex;
        }
        set {
          this._childIndex = value;
        }
      }
      public ShortInteger ChildIndex2 {
        get {
          return this._childIndex2;
        }
        set {
          this._childIndex2 = value;
        }
      }
      public ShortInteger ChildIndex3 {
        get {
          return this._childIndex3;
        }
        set {
          this._childIndex3 = value;
        }
      }
      public ShortInteger ChildIndex4 {
        get {
          return this._childIndex4;
        }
        set {
          this._childIndex4 = value;
        }
      }
      public ShortInteger ChildIndex5 {
        get {
          return this._childIndex5;
        }
        set {
          this._childIndex5 = value;
        }
      }
      public ShortInteger ChildIndex6 {
        get {
          return this._childIndex6;
        }
        set {
          this._childIndex6 = value;
        }
      }
      public ShortInteger ChildIndex7 {
        get {
          return this._childIndex7;
        }
        set {
          this._childIndex7 = value;
        }
      }
      public ShortInteger ChildIndex8 {
        get {
          return this._childIndex8;
        }
        set {
          this._childIndex8 = value;
        }
      }
      public ShortBlockIndex CacheBlockIndex {
        get {
          return this._cacheBlockIndex;
        }
        set {
          this._cacheBlockIndex = value;
        }
      }
      public ShortInteger GroupCount {
        get {
          return this._groupCount;
        }
        set {
          this._groupCount = value;
        }
      }
      public LongInteger GroupStartIndex {
        get {
          return this._groupStartIndex;
        }
        set {
          this._groupStartIndex = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _childIndex.Read(reader);
        _childIndex2.Read(reader);
        _childIndex3.Read(reader);
        _childIndex4.Read(reader);
        _childIndex5.Read(reader);
        _childIndex6.Read(reader);
        _childIndex7.Read(reader);
        _childIndex8.Read(reader);
        _cacheBlockIndex.Read(reader);
        _groupCount.Read(reader);
        _groupStartIndex.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _childIndex.Write(bw);
        _childIndex2.Write(bw);
        _childIndex3.Write(bw);
        _childIndex4.Write(bw);
        _childIndex5.Write(bw);
        _childIndex6.Write(bw);
        _childIndex7.Write(bw);
        _childIndex8.Write(bw);
        _cacheBlockIndex.Write(bw);
        _groupCount.Write(bw);
        _groupStartIndex.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class DecoratorProjectedDecalBlockBlock : IBlock {
      private CharBlockIndex _decoratorSet = new CharBlockIndex();
      private CharInteger _decoratorClass = new CharInteger();
      private CharInteger _decoratorPermutation = new CharInteger();
      private CharInteger _spriteIndex = new CharInteger();
      private RealPoint3D _position = new RealPoint3D();
      private RealVector3D _left = new RealVector3D();
      private RealVector3D _up = new RealVector3D();
      private RealVector3D _extents = new RealVector3D();
      private RealPoint3D _previousPosition = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public DecoratorProjectedDecalBlockBlock() {
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
      public CharBlockIndex DecoratorSet {
        get {
          return this._decoratorSet;
        }
        set {
          this._decoratorSet = value;
        }
      }
      public CharInteger DecoratorClass {
        get {
          return this._decoratorClass;
        }
        set {
          this._decoratorClass = value;
        }
      }
      public CharInteger DecoratorPermutation {
        get {
          return this._decoratorPermutation;
        }
        set {
          this._decoratorPermutation = value;
        }
      }
      public CharInteger SpriteIndex {
        get {
          return this._spriteIndex;
        }
        set {
          this._spriteIndex = value;
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
      public RealVector3D Left {
        get {
          return this._left;
        }
        set {
          this._left = value;
        }
      }
      public RealVector3D Up {
        get {
          return this._up;
        }
        set {
          this._up = value;
        }
      }
      public RealVector3D Extents {
        get {
          return this._extents;
        }
        set {
          this._extents = value;
        }
      }
      public RealPoint3D PreviousPosition {
        get {
          return this._previousPosition;
        }
        set {
          this._previousPosition = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decoratorSet.Read(reader);
        _decoratorClass.Read(reader);
        _decoratorPermutation.Read(reader);
        _spriteIndex.Read(reader);
        _position.Read(reader);
        _left.Read(reader);
        _up.Read(reader);
        _extents.Read(reader);
        _previousPosition.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _decoratorSet.Write(bw);
        _decoratorClass.Write(bw);
        _decoratorPermutation.Write(bw);
        _spriteIndex.Write(bw);
        _position.Write(bw);
        _left.Write(bw);
        _up.Write(bw);
        _extents.Write(bw);
        _previousPosition.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCreatureBlockBlock : IBlock {
      private ShortBlockIndex _type = new ShortBlockIndex();
      private ShortBlockIndex _name = new ShortBlockIndex();
      private Flags _placementFlags;
      private RealPoint3D _position = new RealPoint3D();
      private RealEulerAngles3D _rotation = new RealEulerAngles3D();
      private Real _scale = new Real();
      private Flags _transformFlags;
      private ShortInteger _manualBSPFlags = new ShortInteger();
      private LongInteger _uniqueID = new LongInteger();
      private ShortBlockIndex _originBSPIndex = new ShortBlockIndex();
      private Enum _type2;
      private Enum _source;
      private Enum _bSPPolicy;
      private Pad _unnamed0;
      private ShortBlockIndex _editorFolder = new ShortBlockIndex();
public event System.EventHandler BlockNameChanged;
      public ScenarioCreatureBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._placementFlags = new Flags(4);
        this._transformFlags = new Flags(2);
        this._type2 = new Enum(1);
        this._source = new Enum(1);
        this._bSPPolicy = new Enum(1);
        this._unnamed0 = new Pad(1);
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
      public Flags PlacementFlags {
        get {
          return this._placementFlags;
        }
        set {
          this._placementFlags = value;
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
      public Real Scale {
        get {
          return this._scale;
        }
        set {
          this._scale = value;
        }
      }
      public Flags TransformFlags {
        get {
          return this._transformFlags;
        }
        set {
          this._transformFlags = value;
        }
      }
      public ShortInteger ManualBSPFlags {
        get {
          return this._manualBSPFlags;
        }
        set {
          this._manualBSPFlags = value;
        }
      }
      public LongInteger UniqueID {
        get {
          return this._uniqueID;
        }
        set {
          this._uniqueID = value;
        }
      }
      public ShortBlockIndex OriginBSPIndex {
        get {
          return this._originBSPIndex;
        }
        set {
          this._originBSPIndex = value;
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
      public Enum Source {
        get {
          return this._source;
        }
        set {
          this._source = value;
        }
      }
      public Enum BSPPolicy {
        get {
          return this._bSPPolicy;
        }
        set {
          this._bSPPolicy = value;
        }
      }
      public ShortBlockIndex EditorFolder {
        get {
          return this._editorFolder;
        }
        set {
          this._editorFolder = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _type.Read(reader);
        _name.Read(reader);
        _placementFlags.Read(reader);
        _position.Read(reader);
        _rotation.Read(reader);
        _scale.Read(reader);
        _transformFlags.Read(reader);
        _manualBSPFlags.Read(reader);
        _uniqueID.Read(reader);
        _originBSPIndex.Read(reader);
        _type2.Read(reader);
        _source.Read(reader);
        _bSPPolicy.Read(reader);
        _unnamed0.Read(reader);
        _editorFolder.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _type.Write(bw);
        _name.Write(bw);
        _placementFlags.Write(bw);
        _position.Write(bw);
        _rotation.Write(bw);
        _scale.Write(bw);
        _transformFlags.Write(bw);
        _manualBSPFlags.Write(bw);
        _uniqueID.Write(bw);
        _originBSPIndex.Write(bw);
        _type2.Write(bw);
        _source.Write(bw);
        _bSPPolicy.Write(bw);
        _unnamed0.Write(bw);
        _editorFolder.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioCreaturePaletteBlockBlock : IBlock {
      private TagReference _name = new TagReference();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioCreaturePaletteBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(32);
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
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _name.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _name.WriteString(writer);
      }
    }
    public class ScenarioDecoratorSetPaletteEntryBlockBlock : IBlock {
      private TagReference _decoratorSet = new TagReference();
public event System.EventHandler BlockNameChanged;
      public ScenarioDecoratorSetPaletteEntryBlockBlock() {
if (this._decoratorSet is System.ComponentModel.INotifyPropertyChanged)
  (this._decoratorSet as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_decoratorSet.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _decoratorSet.ToString();
        }
      }
      public TagReference DecoratorSet {
        get {
          return this._decoratorSet;
        }
        set {
          this._decoratorSet = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _decoratorSet.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _decoratorSet.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _decoratorSet.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _decoratorSet.WriteString(writer);
      }
    }
    public class ScenarioBspSwitchTransitionVolumeBlockBlock : IBlock {
      private LongInteger _bSPIndexKey = new LongInteger();
      private ShortBlockIndex _triggerVolume = new ShortBlockIndex();
      private Pad _unnamed0;
public event System.EventHandler BlockNameChanged;
      public ScenarioBspSwitchTransitionVolumeBlockBlock() {
if (this._triggerVolume is System.ComponentModel.INotifyPropertyChanged)
  (this._triggerVolume as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Pad(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return _triggerVolume.ToString();
        }
      }
      public LongInteger BSPIndexKey {
        get {
          return this._bSPIndexKey;
        }
        set {
          this._bSPIndexKey = value;
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
      public virtual void Read(BinaryReader reader) {
        _bSPIndexKey.Read(reader);
        _triggerVolume.Read(reader);
        _unnamed0.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _bSPIndexKey.Write(bw);
        _triggerVolume.Write(bw);
        _unnamed0.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioStructureBspSphericalHarmonicLightingBlockBlock : IBlock {
      private TagReference _bSP = new TagReference();
      private Block _lightingPoints = new Block();
      public BlockCollection<ScenarioSphericalHarmonicLightingPointBlock> _lightingPointsList = new BlockCollection<ScenarioSphericalHarmonicLightingPointBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioStructureBspSphericalHarmonicLightingBlockBlock() {
      }
      public BlockCollection<ScenarioSphericalHarmonicLightingPointBlock> LightingPoints {
        get {
          return this._lightingPointsList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bSP.Value);
for (int x=0; x<LightingPoints.BlockCount; x++)
{
  IBlock block = LightingPoints.GetBlock(x);
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
      public TagReference BSP {
        get {
          return this._bSP;
        }
        set {
          this._bSP = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _bSP.Read(reader);
        _lightingPoints.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _bSP.ReadString(reader);
        for (x = 0; (x < _lightingPoints.Count); x = (x + 1)) {
          LightingPoints.Add(new ScenarioSphericalHarmonicLightingPointBlock());
          LightingPoints[x].Read(reader);
        }
        for (x = 0; (x < _lightingPoints.Count); x = (x + 1)) {
          LightingPoints[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _bSP.Write(bw);
_lightingPoints.Count = LightingPoints.Count;
        _lightingPoints.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _bSP.WriteString(writer);
        for (x = 0; (x < _lightingPoints.Count); x = (x + 1)) {
          LightingPoints[x].Write(writer);
        }
        for (x = 0; (x < _lightingPoints.Count); x = (x + 1)) {
          LightingPoints[x].WriteChildData(writer);
        }
      }
    }
    public class ScenarioSphericalHarmonicLightingPointBlock : IBlock {
      private RealPoint3D _position = new RealPoint3D();
public event System.EventHandler BlockNameChanged;
      public ScenarioSphericalHarmonicLightingPointBlock() {
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
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _position.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class GScenarioEditorFolderBlockBlock : IBlock {
      private LongBlockIndex _parentFolder = new LongBlockIndex();
      private LongerFixedLengthString _name = new LongerFixedLengthString();
public event System.EventHandler BlockNameChanged;
      public GScenarioEditorFolderBlockBlock() {
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
      public LongBlockIndex ParentFolder {
        get {
          return this._parentFolder;
        }
        set {
          this._parentFolder = value;
        }
      }
      public LongerFixedLengthString Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _parentFolder.Read(reader);
        _name.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _parentFolder.Write(bw);
        _name.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioLevelDataBlockBlock : IBlock {
      private TagReference _levelDescription = new TagReference();
      private Block _campaignLevelData = new Block();
      private Block _multiplayer = new Block();
      public BlockCollection<GlobalUiCampaignLevelBlockBlock> _campaignLevelDataList = new BlockCollection<GlobalUiCampaignLevelBlockBlock>();
      public BlockCollection<GlobalUiMultiplayerLevelBlockBlock> _multiplayerList = new BlockCollection<GlobalUiMultiplayerLevelBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioLevelDataBlockBlock() {
      }
      public BlockCollection<GlobalUiCampaignLevelBlockBlock> CampaignLevelData {
        get {
          return this._campaignLevelDataList;
        }
      }
      public BlockCollection<GlobalUiMultiplayerLevelBlockBlock> Multiplayer {
        get {
          return this._multiplayerList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_levelDescription.Value);
for (int x=0; x<CampaignLevelData.BlockCount; x++)
{
  IBlock block = CampaignLevelData.GetBlock(x);
  references.AddRange(block.TagReferenceList);
}
for (int x=0; x<Multiplayer.BlockCount; x++)
{
  IBlock block = Multiplayer.GetBlock(x);
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
      public TagReference LevelDescription {
        get {
          return this._levelDescription;
        }
        set {
          this._levelDescription = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _levelDescription.Read(reader);
        _campaignLevelData.Read(reader);
        _multiplayer.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _levelDescription.ReadString(reader);
        for (x = 0; (x < _campaignLevelData.Count); x = (x + 1)) {
          CampaignLevelData.Add(new GlobalUiCampaignLevelBlockBlock());
          CampaignLevelData[x].Read(reader);
        }
        for (x = 0; (x < _campaignLevelData.Count); x = (x + 1)) {
          CampaignLevelData[x].ReadChildData(reader);
        }
        for (x = 0; (x < _multiplayer.Count); x = (x + 1)) {
          Multiplayer.Add(new GlobalUiMultiplayerLevelBlockBlock());
          Multiplayer[x].Read(reader);
        }
        for (x = 0; (x < _multiplayer.Count); x = (x + 1)) {
          Multiplayer[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _levelDescription.Write(bw);
_campaignLevelData.Count = CampaignLevelData.Count;
        _campaignLevelData.Write(bw);
_multiplayer.Count = Multiplayer.Count;
        _multiplayer.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _levelDescription.WriteString(writer);
        for (x = 0; (x < _campaignLevelData.Count); x = (x + 1)) {
          CampaignLevelData[x].Write(writer);
        }
        for (x = 0; (x < _campaignLevelData.Count); x = (x + 1)) {
          CampaignLevelData[x].WriteChildData(writer);
        }
        for (x = 0; (x < _multiplayer.Count); x = (x + 1)) {
          Multiplayer[x].Write(writer);
        }
        for (x = 0; (x < _multiplayer.Count); x = (x + 1)) {
          Multiplayer[x].WriteChildData(writer);
        }
      }
    }
    public class GlobalUiCampaignLevelBlockBlock : IBlock {
      private LongInteger _campaignID = new LongInteger();
      private LongInteger _mapID = new LongInteger();
      private TagReference _bitmap = new TagReference();
      private Skip _unnamed0;
      private Skip _unnamed1;
public event System.EventHandler BlockNameChanged;
      public GlobalUiCampaignLevelBlockBlock() {
        this._unnamed0 = new Skip(576);
        this._unnamed1 = new Skip(2304);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public LongInteger CampaignID {
        get {
          return this._campaignID;
        }
        set {
          this._campaignID = value;
        }
      }
      public LongInteger MapID {
        get {
          return this._mapID;
        }
        set {
          this._mapID = value;
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _campaignID.Read(reader);
        _mapID.Read(reader);
        _bitmap.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _campaignID.Write(bw);
        _mapID.Write(bw);
        _bitmap.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
      }
    }
    public class GlobalUiMultiplayerLevelBlockBlock : IBlock {
      private LongInteger _mapID = new LongInteger();
      private TagReference _bitmap = new TagReference();
      private Skip _unnamed0;
      private Skip _unnamed1;
      private LongerFixedLengthString _path = new LongerFixedLengthString();
      private LongInteger _sortOrder = new LongInteger();
      private Flags _flags;
      private Pad _unnamed2;
      private CharInteger _maxTeamsNone = new CharInteger();
      private CharInteger _maxTeamsCTF = new CharInteger();
      private CharInteger _maxTeamsSlayer = new CharInteger();
      private CharInteger _maxTeamsOddball = new CharInteger();
      private CharInteger _maxTeamsKOTH = new CharInteger();
      private CharInteger _maxTeamsRace = new CharInteger();
      private CharInteger _maxTeamsHeadhunter = new CharInteger();
      private CharInteger _maxTeamsJuggernaut = new CharInteger();
      private CharInteger _maxTeamsTerritories = new CharInteger();
      private CharInteger _maxTeamsAssault = new CharInteger();
      private CharInteger _maxTeamsStub10 = new CharInteger();
      private CharInteger _maxTeamsStub11 = new CharInteger();
      private CharInteger _maxTeamsStub12 = new CharInteger();
      private CharInteger _maxTeamsStub13 = new CharInteger();
      private CharInteger _maxTeamsStub14 = new CharInteger();
      private CharInteger _maxTeamsStub15 = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public GlobalUiMultiplayerLevelBlockBlock() {
        this._unnamed0 = new Skip(576);
        this._unnamed1 = new Skip(2304);
        this._flags = new Flags(1);
        this._unnamed2 = new Pad(3);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_bitmap.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public LongInteger MapID {
        get {
          return this._mapID;
        }
        set {
          this._mapID = value;
        }
      }
      public TagReference Bitmap {
        get {
          return this._bitmap;
        }
        set {
          this._bitmap = value;
        }
      }
      public LongerFixedLengthString Path {
        get {
          return this._path;
        }
        set {
          this._path = value;
        }
      }
      public LongInteger SortOrder {
        get {
          return this._sortOrder;
        }
        set {
          this._sortOrder = value;
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
      public CharInteger MaxTeamsNone {
        get {
          return this._maxTeamsNone;
        }
        set {
          this._maxTeamsNone = value;
        }
      }
      public CharInteger MaxTeamsCTF {
        get {
          return this._maxTeamsCTF;
        }
        set {
          this._maxTeamsCTF = value;
        }
      }
      public CharInteger MaxTeamsSlayer {
        get {
          return this._maxTeamsSlayer;
        }
        set {
          this._maxTeamsSlayer = value;
        }
      }
      public CharInteger MaxTeamsOddball {
        get {
          return this._maxTeamsOddball;
        }
        set {
          this._maxTeamsOddball = value;
        }
      }
      public CharInteger MaxTeamsKOTH {
        get {
          return this._maxTeamsKOTH;
        }
        set {
          this._maxTeamsKOTH = value;
        }
      }
      public CharInteger MaxTeamsRace {
        get {
          return this._maxTeamsRace;
        }
        set {
          this._maxTeamsRace = value;
        }
      }
      public CharInteger MaxTeamsHeadhunter {
        get {
          return this._maxTeamsHeadhunter;
        }
        set {
          this._maxTeamsHeadhunter = value;
        }
      }
      public CharInteger MaxTeamsJuggernaut {
        get {
          return this._maxTeamsJuggernaut;
        }
        set {
          this._maxTeamsJuggernaut = value;
        }
      }
      public CharInteger MaxTeamsTerritories {
        get {
          return this._maxTeamsTerritories;
        }
        set {
          this._maxTeamsTerritories = value;
        }
      }
      public CharInteger MaxTeamsAssault {
        get {
          return this._maxTeamsAssault;
        }
        set {
          this._maxTeamsAssault = value;
        }
      }
      public CharInteger MaxTeamsStub10 {
        get {
          return this._maxTeamsStub10;
        }
        set {
          this._maxTeamsStub10 = value;
        }
      }
      public CharInteger MaxTeamsStub11 {
        get {
          return this._maxTeamsStub11;
        }
        set {
          this._maxTeamsStub11 = value;
        }
      }
      public CharInteger MaxTeamsStub12 {
        get {
          return this._maxTeamsStub12;
        }
        set {
          this._maxTeamsStub12 = value;
        }
      }
      public CharInteger MaxTeamsStub13 {
        get {
          return this._maxTeamsStub13;
        }
        set {
          this._maxTeamsStub13 = value;
        }
      }
      public CharInteger MaxTeamsStub14 {
        get {
          return this._maxTeamsStub14;
        }
        set {
          this._maxTeamsStub14 = value;
        }
      }
      public CharInteger MaxTeamsStub15 {
        get {
          return this._maxTeamsStub15;
        }
        set {
          this._maxTeamsStub15 = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _mapID.Read(reader);
        _bitmap.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
        _path.Read(reader);
        _sortOrder.Read(reader);
        _flags.Read(reader);
        _unnamed2.Read(reader);
        _maxTeamsNone.Read(reader);
        _maxTeamsCTF.Read(reader);
        _maxTeamsSlayer.Read(reader);
        _maxTeamsOddball.Read(reader);
        _maxTeamsKOTH.Read(reader);
        _maxTeamsRace.Read(reader);
        _maxTeamsHeadhunter.Read(reader);
        _maxTeamsJuggernaut.Read(reader);
        _maxTeamsTerritories.Read(reader);
        _maxTeamsAssault.Read(reader);
        _maxTeamsStub10.Read(reader);
        _maxTeamsStub11.Read(reader);
        _maxTeamsStub12.Read(reader);
        _maxTeamsStub13.Read(reader);
        _maxTeamsStub14.Read(reader);
        _maxTeamsStub15.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _bitmap.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _mapID.Write(bw);
        _bitmap.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
        _path.Write(bw);
        _sortOrder.Write(bw);
        _flags.Write(bw);
        _unnamed2.Write(bw);
        _maxTeamsNone.Write(bw);
        _maxTeamsCTF.Write(bw);
        _maxTeamsSlayer.Write(bw);
        _maxTeamsOddball.Write(bw);
        _maxTeamsKOTH.Write(bw);
        _maxTeamsRace.Write(bw);
        _maxTeamsHeadhunter.Write(bw);
        _maxTeamsJuggernaut.Write(bw);
        _maxTeamsTerritories.Write(bw);
        _maxTeamsAssault.Write(bw);
        _maxTeamsStub10.Write(bw);
        _maxTeamsStub11.Write(bw);
        _maxTeamsStub12.Write(bw);
        _maxTeamsStub13.Write(bw);
        _maxTeamsStub14.Write(bw);
        _maxTeamsStub15.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _bitmap.WriteString(writer);
      }
    }
    public class AiScenarioMissionDialogueBlockBlock : IBlock {
      private TagReference _missionDialogue = new TagReference();
public event System.EventHandler BlockNameChanged;
      public AiScenarioMissionDialogueBlockBlock() {
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_missionDialogue.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference MissionDialogue {
        get {
          return this._missionDialogue;
        }
        set {
          this._missionDialogue = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _missionDialogue.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _missionDialogue.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _missionDialogue.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _missionDialogue.WriteString(writer);
      }
    }
    public class ScenarioInterpolatorBlockBlock : IBlock {
      private StringId _name = new StringId();
      private StringId _acceleratorName = new StringId();
      private StringId _multiplierName = new StringId();
      private Block _data = new Block();
      private Skip _unnamed0;
      private Skip _unnamed1;
      public BlockCollection<ByteBlockBlock> _dataList = new BlockCollection<ByteBlockBlock>();
public event System.EventHandler BlockNameChanged;
      public ScenarioInterpolatorBlockBlock() {
if (this._name is System.ComponentModel.INotifyPropertyChanged)
  (this._name as System.ComponentModel.INotifyPropertyChanged).PropertyChanged +=
  (System.ComponentModel.PropertyChangedEventHandler)delegate
  { if (BlockNameChanged != null) BlockNameChanged(this, new System.EventArgs()); };
        this._unnamed0 = new Skip(2);
        this._unnamed1 = new Skip(2);
      }
      public BlockCollection<ByteBlockBlock> Data {
        get {
          return this._dataList;
        }
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
for (int x=0; x<Data.BlockCount; x++)
{
  IBlock block = Data.GetBlock(x);
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
      public StringId Name {
        get {
          return this._name;
        }
        set {
          this._name = value;
        }
      }
      public StringId AcceleratorName {
        get {
          return this._acceleratorName;
        }
        set {
          this._acceleratorName = value;
        }
      }
      public StringId MultiplierName {
        get {
          return this._multiplierName;
        }
        set {
          this._multiplierName = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _name.Read(reader);
        _acceleratorName.Read(reader);
        _multiplierName.Read(reader);
        _data.Read(reader);
        _unnamed0.Read(reader);
        _unnamed1.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        int x = 0;
        _name.ReadString(reader);
        _acceleratorName.ReadString(reader);
        _multiplierName.ReadString(reader);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data.Add(new ByteBlockBlock());
          Data[x].Read(reader);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].ReadChildData(reader);
        }
      }
      public virtual void Write(BinaryWriter bw) {
        _name.Write(bw);
        _acceleratorName.Write(bw);
        _multiplierName.Write(bw);
_data.Count = Data.Count;
        _data.Write(bw);
        _unnamed0.Write(bw);
        _unnamed1.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        int x = 0;
        _name.WriteString(writer);
        _acceleratorName.WriteString(writer);
        _multiplierName.WriteString(writer);
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].Write(writer);
        }
        for (x = 0; (x < _data.Count); x = (x + 1)) {
          Data[x].WriteChildData(writer);
        }
      }
    }
    public class ByteBlockBlock : IBlock {
      private CharInteger _value = new CharInteger();
public event System.EventHandler BlockNameChanged;
      public ByteBlockBlock() {
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
      public CharInteger Value {
        get {
          return this._value;
        }
        set {
          this._value = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _value.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _value.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
    public class ScenarioScreenEffectReferenceBlockBlock : IBlock {
      private Pad _unnamed0;
      private TagReference _screenEffect = new TagReference();
      private StringId _primaryInput = new StringId();
      private StringId _secondaryInput = new StringId();
      private Skip _unnamed1;
      private Skip _unnamed2;
public event System.EventHandler BlockNameChanged;
      public ScenarioScreenEffectReferenceBlockBlock() {
        this._unnamed0 = new Pad(16);
        this._unnamed1 = new Skip(2);
        this._unnamed2 = new Skip(2);
      }
      public virtual string[] TagReferenceList {
        get {
UniqueStringCollection references = new UniqueStringCollection();
references.Add(_screenEffect.Value);
return references.ToArray();
        }
      }
      public virtual string BlockName {
        get {
return "";
        }
      }
      public TagReference ScreenEffect {
        get {
          return this._screenEffect;
        }
        set {
          this._screenEffect = value;
        }
      }
      public StringId PrimaryInput {
        get {
          return this._primaryInput;
        }
        set {
          this._primaryInput = value;
        }
      }
      public StringId SecondaryInput {
        get {
          return this._secondaryInput;
        }
        set {
          this._secondaryInput = value;
        }
      }
      public virtual void Read(BinaryReader reader) {
        _unnamed0.Read(reader);
        _screenEffect.Read(reader);
        _primaryInput.Read(reader);
        _secondaryInput.Read(reader);
        _unnamed1.Read(reader);
        _unnamed2.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
        _screenEffect.ReadString(reader);
        _primaryInput.ReadString(reader);
        _secondaryInput.ReadString(reader);
      }
      public virtual void Write(BinaryWriter bw) {
        _unnamed0.Write(bw);
        _screenEffect.Write(bw);
        _primaryInput.Write(bw);
        _secondaryInput.Write(bw);
        _unnamed1.Write(bw);
        _unnamed2.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
        _screenEffect.WriteString(writer);
        _primaryInput.WriteString(writer);
        _secondaryInput.WriteString(writer);
      }
    }
    public class ScenarioSimulationDefinitionTableBlockBlock : IBlock {
      private Skip _object;
public event System.EventHandler BlockNameChanged;
      public ScenarioSimulationDefinitionTableBlockBlock() {
        this._object = new Skip(4);
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
      public virtual void Read(BinaryReader reader) {
        _object.Read(reader);
      }
      public virtual void ReadChildData(BinaryReader reader) {
      }
      public virtual void Write(BinaryWriter bw) {
        _object.Write(bw);
      }
      public virtual void WriteChildData(BinaryWriter writer) {
      }
    }
  }
}
