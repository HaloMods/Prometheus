using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Core.Libraries;
using Core.Pool;
using Interfaces;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.Project;
using System.ComponentModel;

namespace Core.Project
{
  /// <summary>
  /// Manages all open projects, and controls the creation of new projects.
  /// </summary>
  public class ProjectManager
  {
    private ProjectFile project;
    private string filename = "";
    private GameDefinition gameDefinition = null;
    private DiskFileLibrary projectFolder = null;
    private string scenarioTag = "";
    private static ProjectManager instance = null;

    /// <summary>
    /// Inticates that a scenario is about to be opened.
    /// </summary>
    public event CancelEventHandler ScenarioOpening;

    /// <summary>
    /// Indicates that a project has been opened in the ProjectManager.
    /// </summary>
    public event EventHandler OpenedProject;

    /// <summary>
    /// Generates the OpenedProject event.
    /// </summary>
    protected void OnOpenedProject()
    {
      if (OpenedProject != null)
        OpenedProject(this, new EventArgs());
    }

    /// <summary>
    /// Gets a reference to the ProjectManager's singleton instance.
    /// </summary>
    public static ProjectManager Instance
    {
      get
      {
        if (instance == null)
          instance = new ProjectManager();
        return instance;
      }
    }

    /// <summary>
    /// Gets a reference to the current project's scenario tag.
    /// If the tag is not loaded, null will be returned.
    /// </summary>
    public Tag ScenarioTag
    {
      get 
      {
        if (scenarioTag != null && scenarioTag != "")
        {
          TagPath scenarioPath = new TagPath(scenarioTag);
          scenarioPath.Game = gameDefinition.GameID;
          Type type = gameDefinition.TypeTable.LocateEntryByName(
            scenarioPath.Extension).TagType;
          if (Core.Prometheus.Instance.Pool.Contains(scenarioPath, type))
            return Core.Prometheus.Instance.Pool.Open(scenarioPath.ToPath(), type, false);
        }
        return null;
      }
    }

    /// <summary>
    /// Gets the filename of the scenario tag associated with this project. (Will also do "set" in DEBUG only. Do NOT use to set the scenario in any non-debug code.)
    /// </summary>
    /// <remarks>At this time, there is no way to use a valid scenario file for projects; thus, I have added the set operative for debugging at this time. -ZeldaFreak</remarks>
    public string ScenarioFilename
    {
      get { return scenarioTag; }
#if DEBUG
        set { scenarioTag = value; }
#endif
    }

    /// <summary>
    /// The DiskFileLibrary that wraps the project's folder.
    /// </summary>
    public DiskFileLibrary ProjectFolder
    {
      get { return projectFolder; }
    }

    /// <summary>
    /// Gets a value indicating if a project is currently loaded.
    /// </summary>
    public bool ProjectLoaded
    {
      get { return project != null; }
    }

    /// <summary>
    /// Returns the GameID of the game that the current project belongs to.
    /// </summary>
    public string GameID
    {
      get
      {
        if (gameDefinition != null)
          return gameDefinition.GameID;
        else
          return "";
      }
    }
    
    /// <summary>
    /// Gets the currently active project file.
    /// </summary>
    public ProjectFile Project
    {
      get { return project; }
    }

    /// <summary>
    /// Private constructor to promote the Singleton pattern.
    /// </summary>
    private ProjectManager()
    {
      ProjectFile.GameDefinitionRequest += new EventHandler<GameDefinitionRequestEventArgs>(ProjectFile_GameDefinitionRequest);
    }

    static void ProjectFile_GameDefinitionRequest(object sender, GameDefinitionRequestEventArgs e)
    {
      e.GameDefinition = Prometheus.Instance.GetGameDefinitionByGameID(e.GameID);
    }

    /// <summary>
    /// Creates a new project file with the specified parameters and saves the file.
    /// </summary>
    public string CreateProject(string mapName, string author, string gameID, ProjectTemplate template, string filename)
    {
      // TODO: Have more specific error handling here.
      try 
      {
        string fullFilename = filename;
        if (!fullFilename.EndsWith(".pproj")) fullFilename += ".pproj";

        gameDefinition = Prometheus.Instance.GetGameDefinitionByGameID(gameID);

        string projectFolder = Application.StartupPath + "\\Games\\" + gameDefinition.GameID + "\\Projects\\" + filename;
        string tagsFolder = projectFolder + "\\Tags";
        
        // Create the proper folders, if they do not already exist.
        if (!Directory.Exists(tagsFolder)) Directory.CreateDirectory(tagsFolder); // Project folder will auto-create.
        
        // We must create a new instance of the Scenario tag and save it to the Tags folder.
        // TODO: In the future, this will need to be based on an existing scenario_structure_bsp tag.
        // The functioanlity of adding the bsp reference will need to be abstracted into the
        // Scenario base.

        // TODO: We should have the option to create the project based on an existing scenario file.
        // TODO: This will require a tag browser dialog.

        Type t = gameDefinition.TypeTable.LocateEntryByFourCC("scnr").TagType;
        Tag newTag = (Tag)Activator.CreateInstance(t);
        newTag.New();

        // Create the folders
        string scenarioFolder = tagsFolder + "\\levels\\" + filename;
        if (!Directory.Exists(scenarioFolder)) Directory.CreateDirectory(scenarioFolder);
        BinaryWriter writer = new BinaryWriter(new FileStream(scenarioFolder + "\\" + filename + ".scenario", FileMode.Create));
        writer.Write(newTag.Save());
        writer.Close();

        // NOTE: This is temporary, we will use the TBD to get this file eventually.
        scenarioTag = "levels\\" + filename + "\\" + filename + ".scenario";

        ProjectFile project = new ProjectFile(mapName, author, gameDefinition, template);

        // TODO: Implement a method that will automatically check to see if an item exists before adding it,
        // and update it instead.  CollectionBase might be better for this, as lookups can be
        // done using a case-insensitive comparison.
        TagPath scenarioPath = new TagPath("levels\\" + filename + "\\" + filename + ".scenario", "", TagLocation.Project);
        project.AddTemplateReference(scenarioPath, "Scenario");
        string fullProjectFileName = projectFolder + "\\" + fullFilename;
        SaveProject(fullProjectFileName, project);
        return fullProjectFileName;
      }
      catch(Exception ex)
      {
        throw new CreateProjectFailedException("Failed to create project: " + filename, ex);
      }
    }

    /// <summary>
    /// Loads the specified project file into a ProjectFile object.
    /// </summary>
    public ProjectFile OpenProject(string filename)
    {
      return OpenProject(filename, ScenarioAction.DoNotLoad);
    }

    /// <summary>
    /// Loads the specified project file into a ProjectFile object, optionally notifying
    /// the GUI to load the scenario file.
    /// </summary>
    public ProjectFile OpenProject(string filename, ScenarioAction action)
    {
      // TODO: Ensure that the file exists.
      StreamReader reader = new StreamReader(new FileStream(filename, FileMode.Open));
      string xmlText = reader.ReadToEnd();
      reader.Close();

      XmlDocument projectDoc = new XmlDocument();
      projectDoc.LoadXml(xmlText);

      // Setup the object and locate its GameDef/Template objects.
      ProjectFile project = new ProjectFile(projectDoc);
      Platform platform = (Platform)Enum.Parse(typeof(Platform), project.GamePlatform);
      string gameID = GameDefinition.GetGameID(project.GameName, platform);
      GameDefinition def = Prometheus.Instance.GetGameDefinitionByGameID(gameID);
      gameDefinition = def;
      foreach (ProjectTemplate template in def.ProjectTemplates)
        if (template.Name == project.TemplateName)
          project.Template = template;

      // Locate the scenario tag.
      if (project.Templates.ContainsTemplateElement("Scenario"))
        scenarioTag = project.Templates["Scenario"].Path;
      else
        throw new Exception("The project does not reference a scenario, which is a required element.");

      // Open the DiskFileLibrary for the project.
      string projectFolder = Path.GetDirectoryName(filename);
      DiskFileLibrary library = new DiskFileLibrary(projectFolder + "\\Tags", project.MapName);
      // TODO: Decide which one of these is neccessary.
      project.ProjectFolder = library;
      this.projectFolder = library;

      // Add the project to the list and register it with the Pool.
      this.filename = filename;
      this.project = project;
      this.project.Dirty += new EventHandler(project_Dirty);
      Prometheus.Instance.Pool.RegisterProject(def.Name, library);

      // Hey other code!  Guess what we just did!!!!!11
      OnOpenedProject();

      bool loadScenario = false;
      if (action == ScenarioAction.Load)
        loadScenario = true;
      else if (action == ScenarioAction.PromptUser)
      {
        CancelEventArgs e = new CancelEventArgs(false);
        if (ScenarioOpening != null)
          ScenarioOpening(this, e);
        loadScenario = !e.Cancel;
      }

      if (loadScenario)
      {
        try
        {
          TagPath path = new TagPath(project.Templates["Scenario"].Path, GameID, TagLocation.Project);
          Prometheus.Instance.OnAddScene(path);
        }
        catch (TagAlreadyExistsException ex)
        {
          Output.Write(OutputTypes.Warning, ex.Message);
        }
        catch (PoolException ex)
        {
          Output.Write(OutputTypes.Warning, ex.Message);
        }
      }
      return project;
    }

    void project_Dirty(object sender, EventArgs e)
    {
      SaveProject();
    }

    /// <summary>
    /// Saves the current project to disk.
    /// </summary>
    public void SaveProject()
    {
      SaveProject(filename, project);
    }

    /// <summary>
    /// Saves the specified project to the specified file.
    /// </summary>
    public void SaveProject(string filename, ProjectFile project)
    {
      string xml = project.SaveToXML();
      StreamWriter writer = new StreamWriter(new FileStream(filename, FileMode.Create));
      writer.Write(xml);
      writer.Close();
    }

    /// <summary>
    /// Closes the project with the specified filename.
    /// </summary>
    public void CloseProject()
    {
      // TODO: before closing, we will want to give the user a chance to save the file (if it is dirty).
      // Not sure if we will handle this completely from the GUI, or some combination of the two.
      Prometheus.Instance.Pool.ResetProject();
      gameDefinition = null;
      scenarioTag = "";
      project.Dirty -= new EventHandler(project_Dirty);
    }

    /// <summary>
    /// Adds the specified tag to the project file's tag references and saves it to the project folder.
    /// </summary>
    /// <param name="tag">The tag object to be saved.</param>
    /// <param name="path">The TagPath representing the file to save to.</param>
    public void AddTagToProject(Tag tag, TagPath path)
    {
      project.AddTagReference(path.Path + "." + path.Extension);
      Prometheus.Instance.Pool.SaveTag(tag, Prometheus.Instance.Pool.GetTagFile(path));
      Output.Write(OutputTypes.Information, "Saved '" + tag.TagPath.Path + "." + tag.TagPath.Extension + "' to the project folder.");
    }
  }

  /// <summary>
  /// A list of actions specifying how the GUI should handle opening a scneario
  /// file once the project has been loaded.
  /// </summary>
  public enum ScenarioAction
  {
    Load,
    DoNotLoad,
    PromptUser
  }

  public class CreateProjectFailedException : Exception
  {
    public CreateProjectFailedException(string message, Exception innerException) : base(message, innerException) { ; }
    public CreateProjectFailedException(string message) : base(message) { ; }
  }
}