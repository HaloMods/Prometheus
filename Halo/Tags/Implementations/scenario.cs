using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.DirectX;

using Enum = Games.Halo.Tags.Fields.Enum;
using Games.Halo.Tags.Fields;

using Interfaces.Factory;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Radiosity;
using Interfaces.Rendering.Wrappers;
using Interfaces.Scripting.ScenarioInterface;
using Interfaces.Rendering.Selection;
using Interfaces.DynamicInterface.SceneInstanceMenu;

namespace Games.Halo.Tags.Classes
{
  public partial class scenario : IInstanceable, IRenderStateModifier, IEnvironmentProvider
  {
    private int bspIndex = 0;

    protected List<IBsp> bspList = new List<IBsp>();
    private List<sky> skyPalette = new List<sky>();
    private List<scenery> sceneryPalette = new List<scenery>();
    private List<biped> bipedPalette = new List<biped>();
    private List<vehicle> vehiclePalette = new List<vehicle>();
    private List<equipment> equipmentPalette = new List<equipment>();
    private List<weapon> weaponPalette = new List<weapon>();
    private List<device_machine> machinePalette = new List<device_machine>();
    private List<device_control> controlPalette = new List<device_control>();
    private List<device_light_fixture> lightFixturePalette = new List<device_light_fixture>();
    private List<sound_scenery> soundSceneryPalette = new List<sound_scenery>();
    private List<scenario_structure_bsp> bspPalette = new List<scenario_structure_bsp>();
    private List<item_collection> itemCollections = new List<item_collection>();

    public Plane[] WorldBounds
    {
      get
      {
        if ((bspPalette != null) && (bspPalette.Count > 0))
        {
          WorldBounds a = bspPalette[0].WorldBounds;
          foreach (scenario_structure_bsp bsp in bspPalette)
            a &= bsp.WorldBounds;
          return a.CalculatePlanes();
        }
        return null;
      }
    }
    public WorldBounds RadiosityBounds { get; set; }

    /// <summary>
    /// Returns a list of the current and any past active bsps.
    /// </summary>
    public sealed override List<IBsp> ActiveBspList
    {
      get { return bspList; }
    }
    /// <summary>
    /// Returns all the structure bsps of this scenario.
    /// </summary>
    /// <remarks>Casts the base collection's ToArray method to IBsp[] and uses that to return the BspList. Instead of calling this property repeatedly, it's better to cache it.</remarks>
    public sealed override List<IBsp> BspList
    {
      get { return new List<IBsp>((IBsp[])bspPalette.ToArray()); }
    }
    public sealed override int ActiveBspIndex
    {
      get { return bspIndex; }
    } 

    public Instance Instance
    {
      get { return new StateModifierInstance(instances, instances.Centroid, instances.BoundingBox, this); }
    }

    public sealed override void DoPostProcess()
    {
      base.DoPostProcess();

      palettes = new ScenePalette[]
      {
        new ScenePalette(0, null, "Scenery", sceneryPalette, PaletteTarget.Campaign | PaletteTarget.Multiplayer | PaletteTarget.UI),
        new ScenePalette(1, null, "Bipeds", bipedPalette, PaletteTarget.Campaign),
        new ScenePalette(2, null, "Vehicles", vehiclePalette, PaletteTarget.Campaign | PaletteTarget.Multiplayer),
        new ScenePalette(3, null, "Equipment", equipmentPalette, PaletteTarget.Campaign),
        new ScenePalette(4, null, "Weapons", weaponPalette, PaletteTarget.Campaign),
        new ScenePalette(5, null, "Machines", machinePalette, PaletteTarget.Campaign | PaletteTarget.Multiplayer | PaletteTarget.UI),
        new ScenePalette(6, null, "Controls", controlPalette, PaletteTarget.Campaign),
        new ScenePalette(7, null, "Light Fixtures", lightFixturePalette, PaletteTarget.Campaign | PaletteTarget.Multiplayer | PaletteTarget.UI),
        new ScenePalette(8, null, "Sound Scenery", soundSceneryPalette, PaletteTarget.Campaign | PaletteTarget.Multiplayer | PaletteTarget.UI),
        new ScenePalette(9, null, "Decals", null, PaletteTarget.Campaign | PaletteTarget.UI),
      };

      for (int i = 0; i < scenarioValues.Skies.Count; i++)
        skyPalette.Add(Open<sky>(scenarioValues.Skies[i].Sky.Value));

      for (int i = 0; i < scenarioValues.SceneryPalette.Count; i++)
        sceneryPalette.Add(Open<scenery>(scenarioValues.SceneryPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.BipedPalette.Count; i++)
        bipedPalette.Add(Open<biped>(scenarioValues.BipedPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.VehiclePalette.Count; i++)
        vehiclePalette.Add(Open<vehicle>(scenarioValues.VehiclePalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.EquipmentPalette.Count; i++)
        equipmentPalette.Add(Open<equipment>(scenarioValues.EquipmentPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.WeaponPalette.Count; i++)
        weaponPalette.Add(Open<weapon>(scenarioValues.WeaponPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.MachinePalette.Count; i++)
        machinePalette.Add(Open<device_machine>(scenarioValues.MachinePalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.ControlPalette.Count; i++)
        controlPalette.Add(Open<device_control>(scenarioValues.ControlPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.LightFixturesPalette.Count; i++)
        lightFixturePalette.Add(Open<device_light_fixture>(scenarioValues.LightFixturesPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.SoundSceneryPalette.Count; i++)
        soundSceneryPalette.Add(Open<sound_scenery>(scenarioValues.SoundSceneryPalette[i].Name.Value));

      for (int i = 0; i < scenarioValues.StructureBsps.Count; i++)
        bspPalette.Add(Open<scenario_structure_bsp>(scenarioValues.StructureBsps[i].StructureBsp.Value));

      for (int i = 0; i < scenarioValues.NetgameEquipment.Count; i++)
        itemCollections.Add(Open<item_collection>(scenarioValues.NetgameEquipment[i].ItemCollection.Value));

      if (bspPalette.Count > 0)
      {
        instances.Add(bspPalette[bspIndex].Instance);
        bspList.Add(bspPalette[bspIndex]);
      }

      foreach (ScenarioSceneryBlock scenery in scenarioValues.Scenery)
      {
        if (scenery.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)sceneryPalette[scenery.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;
        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(scenery.Rotation, scenery.Position));
        instances.Add(instance);
      }

      for (int i = 0; i < itemCollections.Count; i++)
      {
        if (itemCollections[i] == null)
          continue;

        WorldInstance instance = (WorldInstance)itemCollections[i].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;
        instance.TargetType = TargetType.NetgameEquipment;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(
          scenarioValues.NetgameEquipment[i].Facing, scenarioValues.NetgameEquipment[i].Position));
        instances.Add(instance);
      }

      foreach (ScenarioBipedBlock biped in scenarioValues.Bipeds)
      {
        if (biped.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)bipedPalette[biped.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;
        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(biped.Rotation, biped.Position));
        instances.Add(instance);
      }

      foreach (ScenarioVehicleBlock vehicle in scenarioValues.Vehicles)
      {
        if (vehicle.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)vehiclePalette[vehicle.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;

        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(vehicle.Rotation, vehicle.Position));
        instances.Add(instance);
      }

      foreach (ScenarioEquipmentBlock equipment in scenarioValues.Equipment)
      {
        if (equipment.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)equipmentPalette[equipment.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;

        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(equipment.Rotation, equipment.Position));
        instances.Add(instance);
      }

      foreach (ScenarioWeaponBlock weapon in scenarioValues.Weapons)
      {
        if (weapon.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)weaponPalette[weapon.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;

        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(weapon.Rotation, weapon.Position));
        instances.Add(instance);
      }

      foreach (ScenarioMachineBlock machine in scenarioValues.Machines)
      {
        if (machine.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)machinePalette[machine.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;

        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(machine.Rotation, machine.Position));
        instances.Add(instance);
      }

      foreach (ScenarioControlBlock control in scenarioValues.Controls)
      {
        if (control.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)controlPalette[control.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;

        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(control.Rotation, control.Position));
        instances.Add(instance);
      }

      foreach (ScenarioLightFixtureBlock lightFixture in scenarioValues.LightFixtures)
      {
        if (lightFixture.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)lightFixturePalette[lightFixture.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;
        instance.TargetType = TargetType.Object;
        instance.OcclusionNode = true;
        instance.SetBindingTransform(new BindingTransform(lightFixture.Rotation, lightFixture.Position));
        instances.Add(instance);
      }

      foreach (ScenarioSoundSceneryBlock soundScenery in scenarioValues.SoundScenery)
      {
        if (soundScenery.Type.Value < 0)
          continue;

        WorldInstance instance = (WorldInstance)soundSceneryPalette[soundScenery.Type.Value].Instance;
        if (instance is ObjectInstance)
          (instance as ObjectInstance).EnvironmentProvider = this;
        instance.TargetType = TargetType.Object;
        instance.SetBindingTransform(new BindingTransform(soundScenery.Rotation, soundScenery.Position));
        instances.Add(instance);
      }

      foreach (ScenarioNetgameFlagsBlock flagBlock in scenarioValues.NetgameFlags)
      {
        Billboard bb = new Billboard((BillboardType)flagBlock.Type.Value);
        BoundingBox box = new BoundingBox();
        box.min[0] = -1;
        box.min[1] = -1;
        box.min[2] = -1;
        box.max[0] = 1;
        box.max[1] = 1;
        box.max[2] = 1;
        BillboardInstance bi = new BillboardInstance(bb, new Vector3(), box);
        bi.TargetType = TargetType.NetgameFlag;
        bi.SetBindingTransform(new BindingTransform(flagBlock.Facing, flagBlock.Position));
        instances.Add(bi);
      }

      bspPalette[0].WorldBounds = bspPalette[0].CalculateWorldBounds(AnglesToVector(skyPalette[0].SkyValues.Lights[0].Direction.P, skyPalette[0].SkyValues.Lights[0].Direction.Y, 0));

      WorldBounds totalBounds = bspPalette[0].WorldBounds;
      foreach (IBsp bsp in bspPalette)
      {
        totalBounds &= bsp.WorldBounds;
      }
      RadiosityBounds = totalBounds;      
    }

    public sealed override void Dispose()
    {
      base.Dispose();

      if (skyPalette != null)
        for (int i = 0; i < skyPalette.Count; i++)
          Release(skyPalette[i]);

      if (sceneryPalette != null)
        for (int i = 0; i < sceneryPalette.Count; i++)
          Release(sceneryPalette[i]);

      if (bipedPalette != null)
        for (int i = 0; i < bipedPalette.Count; i++)
          Release(bipedPalette[i]);

      if (vehiclePalette != null)
        for (int i = 0; i < vehiclePalette.Count; i++)
          Release(vehiclePalette[i]);

      if (equipmentPalette != null)
        for (int i = 0; i < equipmentPalette.Count; i++)
          Release(equipmentPalette[i]);

      if (weaponPalette != null)
        for (int i = 0; i < weaponPalette.Count; i++)
          Release(weaponPalette[i]);

      if (machinePalette != null)
        for (int i = 0; i < machinePalette.Count; i++)
          Release(machinePalette[i]);

      if (controlPalette != null)
        for (int i = 0; i < controlPalette.Count; i++)
          Release(controlPalette[i]);

      if (lightFixturePalette != null)
        for (int i = 0; i < lightFixturePalette.Count; i++)
          Release(lightFixturePalette[i]);

      if (soundSceneryPalette != null)
        for (int i = 0; i < soundSceneryPalette.Count; i++)
          Release(soundSceneryPalette[i]);

      if (bspPalette != null)
        for (int i = 0; i < bspPalette.Count; i++)
          Release(bspPalette[i]);

      if (itemCollections != null)
        for (int i = 0; i < itemCollections.Count; i++)
          Release(itemCollections[i]);
    }

    public void ModifyStateBeforeScene()
    {
      if (skyPalette.Count > 0)
      {
        if (bspIndex >= 0)
        {
          int skyIndex = bspPalette[bspIndex].ActiveSkyIndex;
          if (skyIndex >= 0)
          {
            MdxRender.Device.RenderState.ZBufferWriteEnable = false;
            skyPalette[skyIndex].Render();
            MdxRender.Device.RenderState.ZBufferWriteEnable = true;
            skyPalette[skyIndex].ApplyWeather(sky.WeatherEffectEnvironment.Outdoor);
          }
        }
      }
    }

    public void ModifyStateAfterScene()
    {
      MdxRender.Device.RenderState.FogEnable = false;
    }

    public sealed override void OnDeviceLost()
    {
      base.OnDeviceLost();

      foreach (Instance i in instances)
        i.OnDeviceLost();
    }

    public sealed override void OnDeviceReset()
    {
      base.OnDeviceReset();

      foreach (Instance i in instances)
        i.OnDeviceReset();
    }

    public IEnvironment Environment
    {
      get
      {
        if (bspIndex < 0)
          return null;
        else
          return bspPalette[bspIndex];
      }
    }

    #region Scripting

    public override void AddScript(ScenarioScript scenarioScript)
    {
      BlockCollection<HsScriptsBlock> scriptBlocks = scenarioValues._scriptsList;
      HsScriptsBlock scriptBlock = new HsScriptsBlock();

      scriptBlock.Name = new FixedLengthString(scenarioScript.Name);
      scriptBlock.ReturnType = new Enum(scenarioScript.ReturnType);
      scriptBlock.RootExpressionIndex = new LongInteger(scenarioScript.RootExpressionIndex * 0x10000);
      scriptBlock.ScriptType = new Enum(scenarioScript.ScriptType);

      scriptBlocks.Add(scriptBlock);
    }

    private ScenarioScript[] m_scripts = null;

    public override ScenarioScript[] GetScripts()
    {
      if (m_scripts == null)
      {
        BlockCollection<HsScriptsBlock> scriptBlocks = scenarioValues._scriptsList;
        m_scripts = new ScenarioScript[scriptBlocks.Count];

        for (int i = 0; i < scriptBlocks.Count; i++)
          m_scripts[i] =
            new ScenarioScript(scriptBlocks[i].Name.Value, scriptBlocks[i].ScriptType.Value,
                               scriptBlocks[i].ReturnType.Value,
                               BitConverter.ToInt16(BitConverter.GetBytes(scriptBlocks[i].RootExpressionIndex.Value), 0));
      }
      return m_scripts;
    }

    public override void AddScriptGlobal(ScenarioScriptGlobal scenarioScriptGlobal)
    {
      BlockCollection<HsGlobalsBlock> globalBlocks = scenarioValues._globalsList;
      HsGlobalsBlock globalBlock = new HsGlobalsBlock();

      globalBlock.Name = new FixedLengthString(scenarioScriptGlobal.Name);
      globalBlock.Type = new Enum(scenarioScriptGlobal.Type);
      globalBlock.InitializationExpressionIndex = new LongInteger(scenarioScriptGlobal.InitialisationExpressionIndex);

      globalBlocks.Add(globalBlock);
    }

    private ScenarioScriptGlobal[] m_scriptGlobals;

    public override ScenarioScriptGlobal[] GetScriptGlobals()
    {
      if (m_scriptGlobals == null)
      {
        BlockCollection<HsGlobalsBlock> globalBlocks = scenarioValues._globalsList;
        m_scriptGlobals = new ScenarioScriptGlobal[globalBlocks.Count];

        for (int i = 0; i < globalBlocks.Count; i++)
          m_scriptGlobals[i] =
            new ScenarioScriptGlobal(globalBlocks[i].Name.Value, globalBlocks[i].Type.Value,
                                     BitConverter.ToInt16(
                                       BitConverter.GetBytes(globalBlocks[i].InitializationExpressionIndex.Value), 0));
      }
      return m_scriptGlobals;
    }

    public override void ClearScripting()
    {
      BlockCollection<HsScriptsBlock> scriptBlocks = scenarioValues._scriptsList;
      BlockCollection<HsGlobalsBlock> globalBlocks = scenarioValues._globalsList;

      scriptBlocks.Clear();
      globalBlocks.Clear();

      m_scripts = null;
      m_scriptGlobals = null;
    }

    private IBlockCollection GetBlockCollectionForScriptingReferenceType(short type)
    {
      switch (type)
      {
        case 11:
          return scenarioValues._triggerVolumesList;
        case 12:
          return scenarioValues._cutsceneFlagsList;
        case 13:
          return scenarioValues._cutsceneCameraPointsList;
        case 14:
          return scenarioValues._cutsceneTitlesList;
        case 15:
          return scenarioValues._recordedAnimationsList;
        case 16:
          return scenarioValues._deviceGroupsList;
        case 17:
          return scenarioValues._encountersList;
        case 18:
          return scenarioValues._commandListsList;
        case 19:
          return scenarioValues._playerStartingProfileList;
        case 20:
          return scenarioValues._aiConversationsList;
        /*case 23:
                  return scenarioValues._objectNamesList;
              case 36:
                  return scenarioValues._objectNamesList;
              case 37:
                  return scenarioValues._objectNamesList;
              case 38:
                  return scenarioValues._vehiclesList;
              case 39:
                  return scenarioValues._weaponsList;
              case 40:
                  return scenarioValues._machinesList;
              case 41:
                  return scenarioValues._sceneryList;
              case 42:
                  return scenarioValues._objectNamesList;
              case 43:
                  return scenarioValues._objectNamesList;*/
        default:
          //throw new Exception("No associated block for type " + type);
          return scenarioValues._objectNamesList;
      }
    }

    public override string[] GetBlockStringsForScriptingReferenceType(short type)
    {
      IBlockCollection blocks = GetBlockCollectionForScriptingReferenceType(type);

      string[] blockStrings = new string[blocks.BlockCount];

      for (int i = 0; i < blocks.BlockCount; i++)
        blockStrings[i] = blocks.GetBlock(i).BlockName;

      return blockStrings;
    }

    public override string GetBlockStringForScriptingReferenceType(short blockIndex, short type)
    {
      IBlockCollection blocks = GetBlockCollectionForScriptingReferenceType(type);
      if (blocks != null)
        return "\"" + blocks.GetBlock(blockIndex).BlockName + "\"";
      else
        return blockIndex.ToString();
    }

    public override byte[] GetScriptSyntaxData()
    {
      return scenarioValues.ScriptSyntaxData.Binary;
    }

    public override void SetScriptSyntaxData(byte[] data)
    {
      scenarioValues.ScriptSyntaxData = new Data(data);
    }

    public override string GetScriptString(int offset)
    {
      return StringOps.ReadCString(scenarioValues.ScriptStringData.Binary, offset);
    }

    public override void SetScriptStringData(byte[] data)
    {
      scenarioValues.ScriptStringData = new Data(data);
    }

    #endregion

    #region Radiosity
    private static float ComputeTriangleArea(float a, float b, float c)
    {
      float s = a + b + c; s /= 2;
      return (float)Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }
    public float SurfaceArea(scenario_structure_bsp.StructureBspSurfaceBlock surface, EnhancedMesh mesh)
    {
      Vector3 v1 = mesh.Vertices[surface.Tria].position;
      Vector3 v2 = mesh.Vertices[surface.Trib].position;
      Vector3 v3 = mesh.Vertices[surface.Tric].position;
      
      return ComputeTriangleArea((v2 - v1).Length(), (v3 - v2).Length(), (v1 - v3).Length());
    }
    public float SurfaceArea(Vertex a, Vertex b, Vertex c)
    {
      return ComputeTriangleArea((b.position - a.position).Length(), (c.position - b.position).Length(), (a.position - c.position).Length());
    }
    public float SurfaceArea(scenario_structure_bsp bsp, scenario_structure_bsp.StructureBspMaterialBlock material, int f, EnhancedMesh mesh)
    {
      float area = 0f;
      int end = f + material.SurfaceCount;
      for (int x=f;x<end;x++)
      {
        Vector3 v1 = mesh.Vertices[bsp.ScenarioStructureBspValues.Surfaces[x].Tria].position;
        Vector3 v2 = mesh.Vertices[bsp.ScenarioStructureBspValues.Surfaces[x].Trib].position;
        Vector3 v3 = mesh.Vertices[bsp.ScenarioStructureBspValues.Surfaces[x].Tric].position;

        area += ComputeTriangleArea((v2 - v1).Length(), (v3 - v2).Length(), (v1 - v3).Length());
      }
      return area;
    }
    public override List<ILight> WorldLighting
    {
      get
      {
#if DEBUG
        scenario_structure_bsp _bsp = bspList[0] as scenario_structure_bsp;
        _bsp.debugPhotonCollisions.Clear();

        
#endif
        /*
         * 1. Start with the sky. Each polygon with the "sky" property needs to have a diffuse light created for it.
         * 2. Need to go through the BSP's polygons (or through the shaders) and 
        */
        List<ILight> lights = new List<ILight>();

        Plane[] bounds = WorldBounds;

        #region Check BSP Materials for lights
        WorldBounds a = bspPalette[0].WorldBounds;
        foreach (scenario_structure_bsp bsp in bspPalette)
        {
          a &= bsp.WorldBounds;
        }
        lights.AddRange((from bsp in bspPalette
                         from lightmap in bsp.ScenarioStructureBspValues.Lightmaps2
                         let l = bsp.ScenarioStructureBspValues.Lightmaps2.IndexOf(lightmap)
                         from material in lightmap.Materials
                         where material.SurfaceCount > 0
                         let m = lightmap.Materials.IndexOf(material)
                         let meshes = bsp.GetMeshes(l)
                         where bsp.shaders[l][m].ShaderValues.Power > 0f
                         let shader = bsp.shaders[l][m].ShaderValues
                         let f = material.Surfaces.Value
                         let color = shader.ColorOfEmittedLight
                         let power = shader.Power
                         let surfaceArea = SurfaceArea(bsp, material, f, meshes[m])
                         from surface in bsp.ScenarioStructureBspValues.Surfaces.Skip(f).Take(material.SurfaceCount)
                         let verts = new Vertex[] { meshes[m].Vertices[surface.Tria], meshes[m].Vertices[surface.Trib], meshes[m].Vertices[surface.Tric] }
                         select new DiffuseLight(verts, new RealColor(color), power * SurfaceArea(verts[0], verts[1], verts[2]) / surfaceArea, bsp.shaders[l][m].Transparent)).ToArray());
        
        #endregion

        #region Get sky lights
        lights.AddRange((from curSky in skyPalette
                   from curLight in curSky.SkyValues.Lights
                   where curLight.Power > 0f
                   select new DirectionalLight(AnglesToVector(curLight.Direction.P, curLight.Direction.Y, 0f),
                     new RealColor(curLight.Color.R, curLight.Color.G, curLight.Color.B),
                     RadiosityBounds, 
                     curLight.Power)).ToArray());
     
        #endregion

        //light fixtures
        lights.AddRange(
          (from instance in scenarioValues.LightFixtures
           let transform = new BindingTransform(instance.Rotation, instance.Position)
          let fixture = lightFixturePalette[instance.Type].ModelTag
          where fixture != null
           let fLights = fixture.RadiosityLights
           where fLights.Count > 0
           from fLight in fLights
          select (fLight as DiffuseLight).Transform(transform)).ToArray());
        //scenery material lights
        lights.AddRange(
          (from instance in scenarioValues.Scenery
          let scenery = sceneryPalette[instance.Type].ModelTag
          let transform = new BindingTransform(instance.Rotation, instance.Position)
          where scenery != null
           let fLights = scenery.RadiosityLights
           where fLights.Count > 0
           from sLight in fLights
          select (sLight as DiffuseLight).Transform(transform)).ToArray());
        
        return lights;
      }
    }
    private static Vector3 AnglesToVector(float p, float y, float r)
    {
      RealEulerAngles3D angle3D = new RealEulerAngles3D();
      angle3D.Pitch = p;
      angle3D.Yaw = y;
      angle3D.Roll = r;
      BindingTransform transform = new BindingTransform(angle3D, new RealPoint3D());
      Vector4 vector = Vector3.Transform(new Vector3(-1f, 0, 0), transform.matrix);

      return new Vector3(vector.X, vector.Y, vector.Z);
    }
    public override List<IModel> StaticModels
    {
      get 
      {
        List<IModel> models = new List<IModel>(scenarioValues.Scenery.Count);

        #region scenery
        models.AddRange((
          from sceneryBlock in scenarioValues.Scenery
          let sceneryModel = sceneryPalette[sceneryBlock.Type.Value].ModelTag
          where sceneryModel != null
          select new RadiosityModel(sceneryModel, new BindingTransform(sceneryBlock.Rotation, sceneryBlock.Position))).ToArray());
        #endregion
        return models;
      }
    }
    #endregion

    public sealed override SceneObject[] PaletteEntries
    {
      get
      {
        List<SceneObject> entries = new List<SceneObject>();

        foreach (scenery sceneryEntry in sceneryPalette)
          entries.Add(new SceneObject(0, sceneryEntry.Name));
        foreach (biped bipedEntry in bipedPalette)
          entries.Add(new SceneObject(1, bipedEntry.Name));
        foreach (vehicle vehicleEntry in vehiclePalette)
          entries.Add(new SceneObject(2, vehicleEntry.Name));
        foreach (equipment equipmentEntry in equipmentPalette)
          entries.Add(new SceneObject(3, equipmentEntry.Name));
        foreach (weapon weaponEntry in weaponPalette)
          entries.Add(new SceneObject(4, weaponEntry.Name));
        foreach (device_machine machineEntry in machinePalette)
          entries.Add(new SceneObject(5, machineEntry.Name));
        foreach (device_control controlEntry in controlPalette)
          entries.Add(new SceneObject(6, controlEntry.Name));
        foreach (device_light_fixture lightFixtureEntry in lightFixturePalette)
          entries.Add(new SceneObject(7, lightFixtureEntry.Name));
        foreach (sound_scenery soundSceneryEntry in soundSceneryPalette)
          entries.Add(new SceneObject(8, soundSceneryEntry.Name));

        return entries.ToArray();
      }
    }

    public sealed override void CreateNewObjectInstance(int paletteID, string objectName, float x, float y, float z)
    {
      foreach (ScenePalette palette in palettes)
      {
        if (palette.ID == paletteID)
        {
          for (short i = 0; i < palette.Palette.Count; i++)
          {
            @object obj = palette.Palette[i] as @object;

            if (obj.Name == objectName)
            {
              WorldInstance instance = null;
              switch (paletteID)
              {
                case 0:
                  scenarioValues.Scenery.AddNewBlock();
                  scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Position.X = x;
                  scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Position.Y = y;
                  scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Position.Z = z;
                  scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Type.Value = i;

                  instance = (WorldInstance)sceneryPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Rotation, scenarioValues.Scenery[scenarioValues.Scenery.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 1:
                  scenarioValues.Bipeds.AddNewBlock();
                  scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Position.X = x;
                  scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Position.Y = y;
                  scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Position.Z = z;
                  scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Type.Value = i;

                  instance = (WorldInstance)bipedPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Rotation, scenarioValues.Bipeds[scenarioValues.Bipeds.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 2:
                  scenarioValues.Vehicles.AddNewBlock();
                  scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Position.X = x;
                  scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Position.Y = y;
                  scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Position.Z = z;
                  scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Type.Value = i;

                  instance = (WorldInstance)vehiclePalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Rotation, scenarioValues.Vehicles[scenarioValues.Vehicles.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 3:
                  scenarioValues.Equipment.AddNewBlock();
                  scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Position.X = x;
                  scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Position.Y = y;
                  scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Position.Z = z;
                  scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Type.Value = i;

                  instance = (WorldInstance)equipmentPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Rotation, scenarioValues.Equipment[scenarioValues.Equipment.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 4:
                  scenarioValues.Weapons.AddNewBlock();
                  scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Position.X = x;
                  scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Position.Y = y;
                  scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Position.Z = z;
                  scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Type.Value = i;

                  instance = (WorldInstance)weaponPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Rotation, scenarioValues.Weapons[scenarioValues.Weapons.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 5:
                  scenarioValues.Machines.AddNewBlock();
                  scenarioValues.Machines[scenarioValues.Machines.Count - 1].Position.X = x;
                  scenarioValues.Machines[scenarioValues.Machines.Count - 1].Position.Y = y;
                  scenarioValues.Machines[scenarioValues.Machines.Count - 1].Position.Z = z;
                  scenarioValues.Machines[scenarioValues.Machines.Count - 1].Type.Value = i;

                  instance = (WorldInstance)machinePalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Machines[scenarioValues.Machines.Count - 1].Rotation, scenarioValues.Machines[scenarioValues.Machines.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 6:
                  scenarioValues.Controls.AddNewBlock();
                  scenarioValues.Controls[scenarioValues.Controls.Count - 1].Position.X = x;
                  scenarioValues.Controls[scenarioValues.Controls.Count - 1].Position.Y = y;
                  scenarioValues.Controls[scenarioValues.Controls.Count - 1].Position.Z = z;
                  scenarioValues.Controls[scenarioValues.Controls.Count - 1].Type.Value = i;

                  instance = (WorldInstance)controlPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.Controls[scenarioValues.Controls.Count - 1].Rotation, scenarioValues.Controls[scenarioValues.Controls.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 7:
                  scenarioValues.LightFixtures.AddNewBlock();
                  scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Position.X = x;
                  scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Position.Y = y;
                  scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Position.Z = z;
                  scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Type.Value = i;

                  instance = (WorldInstance)lightFixturePalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Rotation, scenarioValues.LightFixtures[scenarioValues.LightFixtures.Count - 1].Position));
                  instances.Add(instance);
                  break;

                case 8:
                  scenarioValues.SoundScenery.AddNewBlock();
                  scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Position.X = x;
                  scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Position.Y = y;
                  scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Position.Z = z;
                  scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Type.Value = i;

                  instance = (WorldInstance)soundSceneryPalette[i].Instance;
                  if (instance is ObjectInstance)
                    (instance as ObjectInstance).EnvironmentProvider = this;
                  instance.TargetType = TargetType.Object;
                  instance.SetBindingTransform(new BindingTransform(scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Rotation, scenarioValues.SoundScenery[scenarioValues.SoundScenery.Count - 1].Position));
                  instances.Add(instance);
                  break;
              }
              break;
            }
          }
          break;
        }
      }
    }

    #region Palette Definitions
    private ScenePalette[] palettes;

    public override ScenePalette[] Palettes
    {
      get
      { return palettes; }
    }

    protected override Interfaces.Pool.Tag[] BspTagList
    {
      get
      { return bspPalette.ToArray(); }
    }
    #endregion

    bool mouseDown = false;
    public sealed override void SelectionEdit_MouseDown(int mouseX, int mouseY)
    {
      base.SelectionEdit_MouseDown(mouseX, mouseY);
      mouseDown = true;
      DrawOnLightmap(mouseX, mouseY);
    }
    public override void SelectionEdit_MouseUp(int mouseX, int mouseY)
    {
      base.SelectionEdit_MouseUp(mouseX, mouseY);

      mouseDown = false;
    }
    public override void SelectionEdit_MouseMove(int mouseX, int mouseY)
    {
      base.SelectionEdit_MouseMove(mouseX, mouseY);

      if (mouseDown)
        DrawOnLightmap(mouseX, mouseY);
    }

    private void DrawOnLightmap(int mouseX, int mouseY)
    {
      //Vector3 direction, origin;

      //MdxRender.CalculatePickRayWorld(mouseX, mouseY, out direction, out origin);
        //RadiosityIntersection ab = bspPalette[bspIndex].RadiosityIntersect(origin, direction);

        //bspPalette[0].LightmapSamplers[ab.LightmapIndex].Write(System.Drawing.Color.White, ab.U, ab.V);
    }
    
  }
}
