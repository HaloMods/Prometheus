using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Core.Factory;
using Core.Input;
using Core.Project;
using Core.Rendering;
using Core.Rendering.Camera;
using Interfaces.DebugConsole;
using Interfaces.Factory.CommonTypes;
using Interfaces.Games;
using Interfaces.Options;
using Interfaces.Pool;
using Interfaces.Project;
using Interfaces.Rendering;
using Interfaces.Rendering.Instancing;
using Interfaces.Rendering.Interfaces;
using Interfaces.Settings;
using Interfaces.Sound;
using Interfaces.UserInterface;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX.DirectInput;
using Microsoft.DirectX.DirectSound;
using DS = Microsoft.DirectX.DirectSound;
using D3D = Microsoft.DirectX.Direct3D;
using Device=Microsoft.DirectX.DirectSound.Device;
using Interfaces.Rendering.Selection;
using Interfaces.DynamicInterface.SceneInstanceMenu;
using Interfaces;

namespace Core
{

  /// <summary>
  /// Working body of the Prometheus application. Connects the GUI to the Core. This class cannot be inherited.
  /// </summary>
  public sealed class Prometheus : IDisposable
  {
    private Pool.Pool pool = null; 
    private List<Assembly> assemblies = null;
    private List<GameDefinition> games = null;
    private Dictionary<string, Tag> scenes = null;
    private bool dsInitialized = false, diInitialized = false;
    private static Prometheus instance = null;
    private static InputManager input = null;
    private bool mdxInputAquired = true;
    private ProjectManager projectManager = null;
    //private static SettingsManager settingsManager = null;
    private IDocumentManager documentManager = null;
    private TargetType selectionType = TargetType.None;
    private SceneObject[] scenarioPaletteEntries = null;
    private ScenePalette[] scenarioPalettes = null;
    private Tag structureBsp = null;
    private Tag scenario = null;

    // added by ZeldaFreak. need access to the mouse events for photon mapping debugging.
    public event MouseEventHandler RenderWindow_MouseMoveEvent;
    public event MouseEventHandler RenderWindow_MouseDownEvent;
    public event MouseEventHandler RenderWindow_MouseUpEvent;

    #region External Event Handlers
    #region Render Window
    public void RenderWindow_MouseUp(object sender, MouseEventArgs e)
    {      
      //TODO: send x,y to instance collection for picking
      //TODO: if we are still using the preview->project "button" and we are
      //      in preview mode, test for click on it

      //If the scene is a scenario, call MouseMove handler ...and some other stuff
      if (scenes.Count > 0)
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          ScenarioBase scenario = scenes[RenderCore.ActiveSceneName] as ScenarioBase;

          scenario.SelectionEdit_MouseUp(e.X, e.Y);
          if (scenario.SelectedObject != null)
            selectionType = scenario.SelectedObject.TargetType;
          else
            selectionType = TargetType.None;

          scenarioPalettes = scenario.Palettes;
          scenarioPaletteEntries = scenario.PaletteEntries;
          this.scenario = scenario;
          this.structureBsp = scenario.ActiveBspTag;
        }
      }
      if (RenderWindow_MouseUpEvent != null)
        RenderWindow_MouseUpEvent(sender, e);
    }

    public void RenderWindow_MouseDown(object sender, MouseEventArgs e)
    {
      //If the scene is a scenario, call MouseDown handler
      if (scenes.Count > 0)
      {
        if(scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).SelectionEdit_MouseDown(e.X, e.Y);
        }
      }
      if (RenderWindow_MouseDownEvent != null)
        RenderWindow_MouseDownEvent(sender, e);
    }

    /// <summary>
    /// Mouse Move event occurred in the render window.  Initiate manual lightmap
    /// painting, object selection frustum, or object movement editing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RenderWindow_MouseMove(object sender, MouseEventArgs e)
    {
      //TODO:  lightmap painter
      //TODO:  multi-select handler
      //TODO:  object movement edit
      
      //If the scene is a scenario, call MouseMove handler
      if (scenes.Count > 0)
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).SelectionEdit_MouseMove(e.X, e.Y);
        }
      }

      if (RenderWindow_MouseMoveEvent != null)
        RenderWindow_MouseMoveEvent(sender, e);
    }

    /// <summary>
    /// Mouse entered the render window.  Enable camera updates.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RenderWindow_MouseEnter(object sender, EventArgs e)
    {
      RenderCore.MouseEnabled = true;
    }

    /// <summary>
    /// Mouse left the render window.  Disable camera updates.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void RenderWindow_MouseLeave(object sender, EventArgs e)
    {
      RenderCore.MouseEnabled = false;
    }

    public void RenderWindow_Click(object sender, EventArgs e)
    {
      RenderCore.EnableCameraInput = true;
      //this.dockRenderWindow.Focus();
    }

    public void RenderWindow_GotFocus(object sender, EventArgs e)
    {
      //TODO: enable camera input
      RenderCore.EnableCameraInput = true;
    }

    public void RenderWindow_LostFocus(object sender, EventArgs e)
    {
      //TODO: disable camera input
      RenderCore.EnableCameraInput = false;
    }

    public void CreateNewObjectInstance(int paletteID, string objectName, float x, float y, float z)
    {
      if (scenes.Count > 0)
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          ScenarioBase scenario = scenes[RenderCore.ActiveSceneName] as ScenarioBase;
          scenario.CreateNewObjectInstance(paletteID, objectName, x, y, z);
        }
      }
    }

    #endregion

    #region Camera and Object Interaction
    public void SetCameraPosition(Vector3 position)
    {
      MdxRender.Camera.Position = position;
    }

		public void SetCameraPosition(float x, float y, float z)
		{
			Vector3 position = new Vector3(x, y, z);
			SetCameraPosition(position);
		}

		public void SetCameraLookDirection(float sourceX, float sourceY, float sourceZ, float destX, float destY, float destZ)
		{
			Vector3 direction = new Vector3(destX - sourceX, destY - sourceY, destZ - sourceZ);
			direction.Normalize();
			MdxRender.Camera.SetLookAt(new Vector3(sourceX, sourceY, sourceZ), new Vector3(destX, destY, destZ));
		}

    public void MoveCamera(float distance)
    {
      MdxRender.Camera.Move(distance);
    }

    public bool RandomizeObjectRotation(bool bRandomRoll, bool bRandomPitch, bool bRandomYaw)
    {
      //generate random values
      bool bStatus = false;
      Random autoRand = new Random();
      float roll = (float)(autoRand.NextDouble()*360.0);
      float pitch = (float)(autoRand.NextDouble() * 360.0);
      float yaw = (float)(autoRand.NextDouble() * 360.0);

      //access selected object
      if (scenes.Count > 0)
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          bStatus = true;
          ScenarioBase sb = (ScenarioBase)scenes[RenderCore.ActiveSceneName];
          BindingAngle3 angle = sb.SelectionRotation;

          if(bRandomPitch)
            angle.Pitch = pitch;
          if (bRandomRoll)
            angle.Roll = roll;
          if (bRandomYaw)
            angle.Yaw = yaw;

          sb.SelectionRotation = angle;
        }
      }

      return (bStatus);
    }
    #endregion

    #endregion

    #region Scene

    public string OnAddScene(TagPath path)
    {
      GameDefinition game = instance.GetGameDefinitionByGameID(path.Game);
      string tagName = path.Path + "." + path.Extension;
      Type type = game.TypeTable.LocateEntryByName(path.Extension).TagType;
      if(!new List<Type>(type.GetInterfaces()).Contains(typeof(IInstanceable)))
        throw new CoreException("Cannot preview tag; {0} does not implement {1}.", type.FullName, typeof(IInstanceable).Name);

      Tag tag = pool.Open(path.ToPath(), type, true);
      string identifier = path.ToPath();
      if (!scenes.ContainsKey(identifier))
        scenes.Add(identifier, tag);

      Camera newCam = new Camera();
      if (tag is ScenarioBase)
      {
        Interfaces.Rendering.Radiosity.WorldBounds totalBounds = (tag as ScenarioBase).BspList[0].WorldBounds;
        foreach(IBsp bsp in (tag as ScenarioBase).BspList)
          totalBounds &= bsp.WorldBounds;

        newCam.Position = new Vector3((totalBounds.X.Lower + totalBounds.X.Upper)/2, (totalBounds.Y.Lower + totalBounds.Y.Upper) / 2, (totalBounds.Z.Lower + totalBounds.Z.Upper)/2);
      }

      RenderCore.AddScene(identifier, tagName, newCam, ((IInstanceable)tag).Instance, RenderState.Textured, game.GetSceneType(tag)); // Temp using RenderState.Textured until we load the value from the project file.
      RenderCore.ActiveSceneName = identifier;  //added this line to activate the latest Scene - gren
      return identifier;
    }

    [Console("remove_scene", "removes the scene with the given key name", "<scene>")]
    private static void StaticRemoveScene(string scene)
    {
      instance.OnRemoveScene(scene);
    }

    public void OnRemoveScene(string scene)
    {
      RenderCore.RemoveScene(scene);
    }

    private void RenderCore_SceneRemoved(SceneState scene)
    {
      if (scenes.ContainsKey(scene.Identifier))
      {
        pool.Release(scenes[scene.Identifier]);
        scenes.Remove(scene.Identifier);
      }
    }

    [Console("clear_scenes", "removes all scenes from the render list.")]
    public static void ClearAllScenes()
    {
      int i = 0;
      string[] sceneNames = new string[instance.scenes.Count];
      foreach (string key in instance.scenes.Keys)
        sceneNames[i++] = key;
      foreach (string scene in sceneNames)
        instance.OnRemoveScene(scene);
    }

    public void OnSelectScene(string scene)
    {
      RenderCore.ActiveSceneName = scene;
    }

    /// <summary>
    /// Check the ScenarioBase for camera lock request.
    /// </summary>
    /// <returns></returns>
    public bool IsCameraLockRequested()
    {
      bool bLockRequested = false;

      if (Core.Rendering.RenderCore.SceneCount > 0)
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          bLockRequested = ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).CameraLockRequested;
        }
      }

      return bLockRequested;
    }

    public SimpleContainers.Vector3D IntersectScene(int x, int y)
    {
      Vector3 origin, direction;
      MdxRender.CalculatePickRayWorld(x, y, out direction, out origin);
      Vector3 vector = RenderCore.IntersectCurrentScene(origin, direction);
      return new SimpleContainers.Vector3D(vector);
    }

    public SimpleContainers.Vector3D GetCameraVector(float startX, float startY, float startZ, float destinationX, float destinationY, float destinationZ, float distance)
    {
      Vector3 start = new Vector3(startX, startY, startZ);
      Vector3 end = new Vector3(destinationX, destinationY, destinationZ);
      Vector3 vector = Vector3.Subtract(end, start);
      vector.Normalize();
      vector.Scale(distance);
      vector = Vector3.Subtract(end, vector);
      return new SimpleContainers.Vector3D(vector);
    }
    #endregion

    #region Properties
    public IDocumentManager DocumentManager
    {
      get { return documentManager; }
      set { documentManager = value; }
    }

    public ProjectManager ProjectManager
    {
      get { return projectManager; }
    }

    public List<GameDefinition> Games
    {
      get
      { return games; }
    }
    
    public Pool.Pool Pool
    {
      get
      { return pool; }
    }

    public bool CameraMoved
    {
      get
      { return MdxRender.Camera.Moved; }
      set
      { MdxRender.Camera.Moved = value; }
    }

    public bool ObjectSelected
    {
      get
      {
        if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
        {
          ScenarioBase scenario = scenes[RenderCore.ActiveSceneName] as ScenarioBase;
          return scenario.SelectionCount > 0;
        }
        else
          return false;
      }
    }

    public void SetViewportColor(Color color)
    {
      RenderCore.SetClearColor(color);
    }

    public static Prometheus Instance
    {
      get { return instance; }
    }

    public static InputManager Input
    {
      get
      {
        return input;
      }
    }
    public bool MdxInputAquired
    {
      // who wrote this property? cause they messed up good
      get
      {
        //MdxInput.Keyboard.Acquire();
        return mdxInputAquired;
      }
      set
      {
        if (value)
        {
          if (!mdxInputAquired)
            MdxInput.Keyboard.Acquire();
        }
        else
        {
          if (mdxInputAquired)
            MdxInput.Keyboard.Unacquire();
        }
        mdxInputAquired = value;
        RenderCore.EnableKeyboardInput = value;
      }
    }

    public float CameraX
    {
      get { return MdxRender.Camera.Position.X; }
    }
    public float CameraY
    {
      get { return MdxRender.Camera.Position.Y; }
    }
    public float CameraZ
    {
      get { return MdxRender.Camera.Position.Z; }
    }

    public float SelectedObjectX
    {
      get
      {
        float val = 0;

        if (RenderCore.SceneCount > 0)
          if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
            val = ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).SelectionPosition.X;

        return val;
      }
    }
    public float SelectedObjectY
    {
      get
      {
        float val = 0;

        if (scenes.Count > 0)
          if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
            val = ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).SelectionPosition.Y;

        return val;
      }
    }
    public float SelectedObjectZ
    {
      get
      {
        float val = 0;

        if (scenes.Count > 0)
          if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
            val = ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).SelectionPosition.Z;

        return val;
      }
    }

    public TargetType SelectedObjectType
    {
      get
      { return selectionType; }
    }
    public ScenePalette[] ScenarioPalettes
    {
      get
      { return scenarioPalettes; }
    }
    public SceneObject[] ScenarioPaletteEntries
    {
      get
      { return scenarioPaletteEntries; }
    }
    public Tag StructureBsp
    {
      get
      { return structureBsp; }
    }
    public Tag Scenario
    {
      get
      { return scenario; }
    }

    public List<IBsp> ActiveBspList
    {
      get
      {
        List<IBsp> tmp = null;

        if (scenes.Count > 0)
          if (scenes[RenderCore.ActiveSceneName] is ScenarioBase)
            tmp = ((ScenarioBase)scenes[RenderCore.ActiveSceneName]).ActiveBspList;

        return tmp;
      }
    }
    #endregion

    #region Constants
    private static readonly string[] ApplicationLibraries =
    {
      "Core.dll",
      "Interfaces.dll",
      "Microsoft.DirectX.dll",
      "Microsoft.DirectX.Direct3D.dll",
      "Microsoft.DirectX.DirectInput.dll",
      "Microsoft.DirectX.Direct3DX.dll",
      "Microsoft.DirectX.DirectSound.dll",
      "DevComponents.DotNetBar2.dll",
      "Nini.dll",
      "umutil.dll",
      "zlib-1.dll",
      "AForge.Imaging.dll",
      "AForge.Math.dll",
      "ICSharpCode.SharpZipLib.dll",
      "TagEditor.dll"
    };
    #endregion

    #region Creating and Disposing
    /// <summary>
    /// Creates static singleton instance of the Prometheus class.
    /// </summary>
    public static Prometheus CreateInstance(Control renderTarget, Control topLevelForm)
    {
      //if (instance != null)
      //  throw new CoreException("An instance of the Prometheus class has already been created.");

      instance = new Prometheus();
      instance.Init(renderTarget, topLevelForm);
      return instance;
    }
    
    /// <summary>
    /// Enforces creation of a static singleton instance of the Prometheus class.
    /// </summary>
    private Prometheus()
    {
      if (instance != null)
        throw new CoreException("Attempted to create multiple Prometheus singleton instances.");
    }

    private void Init(Control renderTarget, Control topLevelForm)
    {
      // initialize scene dictionary
      scenes = new Dictionary<string, Tag>();

      // initialize the game definition and assembly parallel lists
      games = new List<GameDefinition>();
      assemblies = new List<Assembly>();
      LoadLibraries();

      Assembly interfacesLibrary = Assembly.LoadFile(Application.StartupPath + "\\Interfaces.dll");
      //OptionController.RegisterAssembly(interfacesLibrary);
      DebugConsole.DebugConsole.RegisterAssembly(interfacesLibrary);
      foreach (Assembly gameLibrary in assemblies)
      {
        //OptionController.RegisterAssembly(gameLibrary);
        DebugConsole.DebugConsole.RegisterAssembly(gameLibrary);
      }

      pool = new Pool.Pool();

      if (renderTarget != null)
      {
        InitializeGraphics(renderTarget, topLevelForm);
        Application.Idle += new EventHandler(DoRenderLoop);
      }

      // initialize the pool
      foreach (GameDefinition game in games)
        pool.RegisterGame(game.GameID, game.GlobalsTagName, game.TypeTable, game.GlobalTagLibrary);

      // load up options
      LoadOptions();

      // Initialize the Project Manager
      projectManager = ProjectManager.Instance;

      Core.Rendering.RenderCore.SceneRemoved += RenderCore_SceneRemoved;
    }

    /// <summary>
    /// Loads any game libraries in the Prometheus directory.
    /// </summary>
    private void LoadLibraries()
    {
      string[] libs = Directory.GetFiles(Application.StartupPath, "*.dll");

      for (int i = 0; i < libs.Length; i++)
      {
        for (int j = 0; j < ApplicationLibraries.Length; j++)
        {
          if (Application.StartupPath + '\\' + ApplicationLibraries[j] == libs[i])
          {
            i++;
            if (i >= libs.Length)
              return;
            j = 0;
          }
        }

        try
        {
          Assembly lib = Assembly.LoadFile(libs[i]);
          Type[] types = lib.GetTypes();
          Type tGameDefinition = typeof(GameDefinition);

          foreach (Type t in types)
          {
            if (t.IsSubclassOf(tGameDefinition))
            {
              GameDefinition game = Activator.CreateInstance(t) as GameDefinition;
              if (game == null)
                throw new CoreException("Failed to instantiate the game definition for {0}.", t.Name);
              if (game is IPersistable)
                (game as IPersistable).Load();
              games.Add(game);
              assemblies.Add(lib);
            }
          }
        }
        catch (Exception ex)
        {
          Trace.WriteLine(ex.Message);
#if DEBUG
          Debugger.Break();
#endif
        }
      }
    }

    /// <summary>
    /// Prepares the Prometheus class to be garbage collectified.
    /// </summary>
    public void Dispose()
    {
      SaveOptions();
      pool.Dispose();
      if (diInitialized)
        MdxInput.Keyboard.Dispose();
      if (dsInitialized)
        MdxSound.Device.Dispose();
    }
    #endregion

    #region DirectX
    /// <summary>
    /// Application.Idle handler.
    /// </summary>
    private void DoRenderLoop(object sender, EventArgs e)
    {
      if (RenderCore.DeviceInitialized && diInitialized && dsInitialized)
      {
        RenderCore.CameraLockRequested = IsCameraLockRequested();
        RenderCore.Render();
      }
    }

    /// <summary>
    /// Creates the DirectX devices.
    /// </summary>
    /// <param name="renderTarget">render target control</param>
    /// <param name="topLevelForm">top level control</param>
    private void InitializeGraphics(Control renderTarget, Control topLevelForm)
    {
      InitializeDirect3D(renderTarget);
      InitializeDirectInput(topLevelForm);
      InitializeDirectSound(topLevelForm);
    }


    /// <summary>
    /// Initializes DirectX asynchronous keyboard/mouse input.
    /// </summary>
    /// <param name="topLevelForm">reference to top level form</param>
    private void InitializeDirectInput(Control topLevelForm)
    {
      if (diInitialized)
        return;

      MdxInput.Keyboard = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Keyboard);
      MdxInput.Keyboard.SetCooperativeLevel(topLevelForm, CooperativeLevelFlags.Background |
        CooperativeLevelFlags.NonExclusive);
      MdxInput.Keyboard.Acquire();

      MdxInput.Mouse = new Microsoft.DirectX.DirectInput.Device(SystemGuid.Mouse);
      MdxInput.Mouse.SetCooperativeLevel(topLevelForm, CooperativeLevelFlags.Background |
        CooperativeLevelFlags.NonExclusive);
      MdxInput.Mouse.Acquire();

      input = new InputManager();

      diInitialized = true;
    }

    private void InitializeDirectSound(Control topLevelForm)
    {
      if (dsInitialized)
        return;
      MdxSound.Device = new Device();
      dsInitialized = true;

      Speakers speakerSetup = MdxSound.Device.SpeakerConfig;
      speakerSetup.Stereo = true;
      MdxSound.Device.SpeakerConfig = speakerSetup;
      MdxSound.Device.SetCooperativeLevel(topLevelForm, CooperativeLevel.Priority);
    }

    private void InitializeDirect3D(Control renderWindow)
    {
      MdxRender.Camera = new Camera();
      RenderCore.Initialize(renderWindow, pool);
    }

    public void ProcessResize(int sizeX, int sizeY)
    {
      RenderCore.PerformDeviceReset(sizeX, sizeY);
    }

    public void SaveImage(string fileName)
    {
      ScreenCapture.SaveImage(MdxRender.Device, fileName, ImageFileFormat.Jpg);
    }

    public Bitmap GetBackbuffer()
    {
      return ScreenCapture.GetBackBuffer(MdxRender.Device);
      //byte[] buffer;
      //D3D.Viewport vp = MdxRender.Device.Viewport;
      //using (D3D.Surface surface = MdxRender.Device.GetBackBuffer(0, 0, D3D.BackBufferType.Mono))
      //{
      //  Stream stream = surface.LockRectangle(D3D.LockFlags.ReadOnly);
      //  buffer = new byte[vp.Width * vp.Height * 4];
      //  stream.Read(buffer, 0, buffer.Length);
      //  surface.UnlockRectangle();
      //  stream.Dispose();
      //}

      //Bitmap bitmap = new Bitmap(vp.Width, vp.Height, PixelFormat.Format32bppRgb);
      //for (int x = 0; x < vp.Width; x++)
      //  for (int y = 0; y < vp.Height; y++)
      //    bitmap.SetPixel(x, y, Color.FromArgb(BitConverter.ToInt32(buffer, (y * x + x) * 4)));
      //return bitmap;
    }
    #endregion

    #region Class Generator
    public void GenerateClass(string gameID, string xmlPath, string outputPath)
    {
      int index = 0;
      for (; index < games.Count; index++)
        if (games[index].GameID == gameID)
          break;

      ClassGenerator cg = new ClassGenerator(assemblies[index], games[index].FieldTypeNamespace);
      XmlDocument xml = new XmlDocument();
      xml.Load(xmlPath);
      File.WriteAllText(outputPath, cg.GenerateClass(xml.SelectSingleNode("//xml"), games[index].TypeTable));
    }
    #endregion

    #region Options
    public void LoadOptions()
    {
      OptionManager.LoadProfile(Application.StartupPath + "\\options.ini");
    }

    public void SaveOptions()
    {
      OptionManager.SaveProfile(Application.StartupPath + "\\options.ini");
    }
    #endregion

    public GameDefinition GetGameDefinitionByProjectTemplate(string templateName)
    {
      foreach (GameDefinition def in Games)
      {
        foreach (ProjectTemplate template in def.ProjectTemplates)
          if (template.Name == templateName) return def;
      }
      throw new CoreException("The specified project template was not found: " + templateName);
    }

    public GameDefinition GetGameDefinitionByGameID(string id)
    {
      foreach (GameDefinition def in Games)
        if (def.GameID == id) return def;
      throw new CoreException("The specified game definition does not exist: " + id);
    }

    public GameDefinition GetGameDefinitionByGameID(byte[] id)
    {
      foreach (GameDefinition def in Games)
        if (BitConverter.ToInt32(id, 0) == BitConverter.ToInt32(def.TagIdentifier, 0)) return def;
      throw new CoreException("The specified game definition does not exist: " + Encoding.ASCII.GetString(id));
    }

    public GameDefinition GetGameDefinitionByTagType(Type type)
    {
      foreach (GameDefinition def in Games)
        if (def.TypeTable != null)
          if (def.TypeTable.Contains(type))
            return def;
      throw new Exception("The specified tag type was not found in any game definitions: " + type);
    }

    public Type GetTypeFromTagPath(TagPath path)
    {
      GameDefinition game = GetGameDefinitionByGameID(path.Game);
      Type tagType = game.TypeTable.LocateEntryByName(path.Extension).TagType;
      return tagType;
    }
  }
}
