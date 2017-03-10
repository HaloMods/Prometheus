using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Interfaces;
using Interfaces.Games;
using Interfaces.Libraries;
using Interfaces.Pool;
using Interfaces.Project;
using Core.Libraries;

namespace Core.Project
{
  /// <summary>
  /// Represents a Prometheus Project File.
  /// The project file contains all project-specific data including author and map information.
  /// Since the project file also contains references to tags, programmatic access to these
  /// references is provided by this class.
  /// </summary>
  public class ProjectFile : ILibrary
  {
    #region Members
    private DiskFileLibrary projectFolder;
    private ProjectVersion version;
    private string author;
    private string description;
    private GameDefinition game;
    private ProjectTemplate template;
    private string templateName;
    private string mapName;
    private string filename;
    private string uiText;
    private string uiScreenShotFile;
    private TemplateTagList templates;
    private FileHierarchy projectReferencesTable = new FileHierarchy();
    private RecycleBin recycleBin;
    #endregion

    #region Events
    /// <summary>
    /// Indicates that the project file has unsaved changes.
    /// </summary>
    public event EventHandler Dirty;

    /// <summary>
    /// Indicates that an essential tag (template) is about to be forcibly reverted due to its reference being removed.
    /// This event can be cancelled.
    /// </summary>
    public event EventHandler<ForceTemplateRevertArgs> TemplateReverting;

    /// <summary>
    /// Indicates that the project file is requesting a reference to a GameDefinition via its identifier.
    /// This event is used to obtain data from the Core.
    /// </summary>
    public static event EventHandler<GameDefinitionRequestEventArgs> GameDefinitionRequest;
    #endregion

    #region Properties
    /// <summary>
    /// Gets a reference to the RecycleBin that is associated with this project.
    /// </summary>
    public RecycleBin RecycleBin
    {
      get { return recycleBin; }
    }

    public TemplateTagList Templates
    {
      get { return templates; }
    }

    /// <summary>
    /// Gets or sets the DiskFileLibrary that wraps the folder that this project resides in.
    /// </summary>
    public DiskFileLibrary ProjectFolder
    {
      get { return projectFolder; }
      set
      {
        projectFolder = value;
        string recycleBinFolder = Path.GetDirectoryName(projectFolder.RootPath + ".hack") + "\\~Recycle";
        recycleBin = new RecycleBin(recycleBinFolder, projectFolder);
      }
    }

    /// <summary>
    /// Gets the version of the project.
    /// </summary>
    public ProjectVersion Version
    {
      get { return version; }
    }

    /// <summary>
    /// Gets or sets the author of the project.
    /// </summary>
    public string Author
    {
      get { return author; }
      set { author = value; }
    }

    /// <summary>
    /// Gets or sets the description of the project.
    /// </summary>
    public string Description
    {
      get { return description; }
      set { description = value; }
    }

    /// <summary>
    /// Gets the name of the game that this project targets.
    /// </summary>
    public string GameName
    {
      get { return game.Name; }
    }

    /// <summary>
    /// Gets the name of the platform that this project targets.
    /// </summary>
    public string GamePlatform
    {
      get { return EnumReader.GetText(game.Platform); }
    }

    /// <summary>
    /// Gets the name of the project template.
    /// </summary>
    public string TemplateName
    {
      get { return templateName; }
    }

    /// <summary>
    /// Gets or sets the template associated with this project.
    /// </summary>
    public ProjectTemplate Template
    {
      get { return template; }
      set { template = value; }
    }

    /// <summary>
    /// Gets or sets the map name of the project.
    /// </summary>
    public string MapName
    {
      get { return mapName; }
      set { mapName = value; }
    }

    /// <summary>
    /// Gets or sets the filename to be used when compiling the project to a map file.
    /// </summary>
    public string Filename
    {
      get { return filename; }
      set { filename = value; }
    }

    /// <summary>
    /// Gets or sets the text displayed in the UI.
    /// </summary>
    public string UIText
    {
      get { return uiText; }
      set { uiText = value; }
    }

    /// <summary>
    /// Gets or sets filename of the image that will be displayed in the UI.
    /// </summary>
    public string UIScreenShotFile
    {
      get { return uiScreenShotFile; }
      set { uiScreenShotFile = value; }
    }
    #endregion

    #region Constructors
    /// <param name="mapName">The name of the map project.</param>
    /// <param name="author">The author information for the map project.</param>
    /// <param name="gameDefinition">The GameDefinition of the project's associated game.</param>
    /// <param name="template">The template that the project will be based off of.</param>
    public ProjectFile(string mapName, string author, GameDefinition gameDefinition, ProjectTemplate template)
    {
      game = gameDefinition;
      this.mapName = mapName;
      this.author = author;
      version = new ProjectVersion();
      this.template = template;
      templates = new TemplateTagList(template);
      templates.FileAdded += templates_FileAdded;
      templates.FileRemoved += templates_FileRemoved;
    }
    
    /// <param name="xml">A string containing the XML that represents the project file.</param>
    public ProjectFile(string xml)
    {
      XmlDocument doc = new XmlDocument();

      // Attempt to pase the XML.
      try
      {
        doc.LoadXml(xml);
      }
      catch (XmlException ex)
      {
        throw new ProjectFileNotValidException("Could not parse the project file's XML data.", ex);
      }

      // Document was valid, load the values.
      ParseProjectFile(doc);
    }

    /// <param name="document">An XML document representing the project file.</param>
    public ProjectFile(XmlDocument document)
    {
      ParseProjectFile(document);
    }
    #endregion

    #region Public Methods
    /// <summary>
    /// Adds a reference to the specified file, if it is not already referenced.
    /// </summary>
    public void AddTagReference(string path)
    {
      if (!FileExists(path))
      {
        projectReferencesTable.Add(path);
        OnFileAdded(path);
      }
    }

    /// <summary>
    /// Adds the specified template element to the list of explicit references.
    /// If the element already exists, the path is updated with the supplied value.
    /// </summary>
    public void AddTemplateReference(TagPath tagPath, string templateElement)
    {
      if (templateElement != "")
      {
        if (!templates.ContainsTemplateElement(templateElement))
          templates.Add(templateElement, tagPath);
        else
          templates.UpdateElementPath(templateElement, tagPath);
      }
    }

    /// <summary>
    /// Removes the specified tag from the list of tag references for this project.
    /// </summary>
    /// <param name="path">The path of the reference to remove.</param>
    /// <returns>A value indicating if the reference was removed.</returns>
    public bool RemoveTagReference(string path)
    {
      return RemoveTagReference(path, false);
    }

    /// <summary>
    /// Removes the specified tag from the list of tag references for this project.
    /// </summary>
    /// <param name="path">The path of the reference to remove.</param>
    /// <param name="autoRevertTemplateTag">If the reference points to an essential tag, specifies if it will automatically be reverted to its default tag.  Normally, the user is prompted in this scenario.</param>
    /// <returns>A value indicating if the reference was removed.</returns>
    public bool RemoveTagReference(string path, bool autoRevertEssentialTag)
    {
      // In order to see if this is a referenced essential tag, we need to
      // create a project-scoped explicit path to check against.
      // TODO: After shared folder / prefabs are implemented, we will also need to check those.
      TagPath projectPath = new TagPath(path);
      projectPath.Location = TagLocation.Project;
      string projectPathString = projectPath.ToPath(PathFormat.ExplicitLocation);

      // Check the essential tags collection (templates), not the normal references table (projectReferencesTable).
      if (templates.ContainsPath(projectPathString))
      {
        // This is an essential tag, so get it's corresponding template name.
        // Ex: 'levels\test\bloodgulch\bloodgulch.scenario' would be the 'Scenario' template element.
        string templateName = templates.GetTemplateNameBypath(projectPathString);

        // If we aren't auto-reverting, generate the TemplateReverting event to prompt the user.
        bool revertEssentialTag = autoRevertEssentialTag;

        if (!autoRevertEssentialTag)
          // The value returned here indicates whether the event was cancelled, so we want the inverse of it.
          revertEssentialTag = !OnTemplateReverting(projectPathString, templateName);

        if (revertEssentialTag)
          templates.RemoveByTagPath(projectPathString);  // User chose to remove, or auto-revert was set.
        else
          return false; // Nothing was removed.
      }
      else // This was not an essential tag.
      {
        if (FileExists(path))
        {
          // Remove the reference from the references table and raise the corresponding event.
          projectReferencesTable.RemoveFile(path);
          OnFileRemoved(path);
        }
      }
      return true; // References were removed.
    }

    /// <summary>
    /// Returns the path to the template tag that matches the specified element.
    /// </summary>
    public string GetTemplateTagPath(string templateElement)
    {
      if (templates.ContainsTemplateElement(templateElement))
        return templates[templateElement].Path;
      else
        return "";
    }

    /// <summary>
    /// Returns a XML-formatted string containing the ProjectFile data.
    /// </summary>
    public string SaveToXML()
    {
      XmlTextWriter writer = new XmlTextWriter(new MemoryStream(), new ASCIIEncoding());
      writer.Formatting = Formatting.Indented;
      writer.WriteStartDocument();

      writer.WriteStartElement("project");
      writer.WriteStartElement("game");
      writer.WriteAttributeString("name", GameName);
      writer.WriteAttributeString("platform", GamePlatform);
      writer.WriteEndElement(); // </game>

      writer.WriteStartElement("info");
      writer.WriteElementString("author", author);
      writer.WriteElementString("description", description);
      writer.WriteElementString("version", version.ToString());
      writer.WriteEndElement(); // </info>

      writer.WriteElementString("template", template.Name);

      writer.WriteStartElement("mapinfo");
      writer.WriteElementString("name", mapName);
      writer.WriteElementString("filename", filename);
      writer.WriteElementString("uitext", uiText);
      writer.WriteElementString("uiscreenshot", uiScreenShotFile);
      writer.WriteEndElement(); // </mapinfo>

      writer.WriteStartElement("essentialTags");
      foreach (ProjectTag tag in templates.GetTemplateList())
      {
        writer.WriteStartElement("tag");
        if (tag.TemplateElement != "")
          writer.WriteAttributeString("template_id", tag.TemplateElement);
        writer.WriteString(tag.Path);
        writer.WriteEndElement(); // </tag>
      }
      writer.WriteEndElement(); // </essentialtags>

      writer.WriteStartElement("references");
      string[] nonTemplateReferences = GetNonTemplateReferences();
      foreach (string tag in nonTemplateReferences)
      {
        writer.WriteStartElement("tag");
        writer.WriteString(tag.Trim('\\'));
        writer.WriteEndElement(); // </tag>
      }
      writer.WriteEndElement(); // </references>

      writer.WriteEndElement(); // </project>
      
      writer.WriteEndDocument();
      writer.Flush();

      // Get a string containing all of the emitted XML.
      byte[] data = new byte[writer.BaseStream.Length];
      writer.BaseStream.Position = 0;
      writer.BaseStream.Read(data, 0, data.Length);
      string s = Encoding.ASCII.GetString(data);
      return s;
    }

    /// <summary>
    /// Returns a list of references that are not essential tags (templates).
    /// </summary>
    public string[] GetNonTemplateReferences()
    {
      // Get a list of all template references.
      Dictionary<string, string> templateTagFilenames = new Dictionary<string, string>();
      foreach (ProjectTag tag in templates.GetTemplateList())
        templateTagFilenames.Add(tag.Path, "");
      
      // Get a list of all references.
      string[] allReferences = GetFileList("", "*", true);

      // Compare the list of all references against the list of templates, and remove template references.
      List<string> nonTemplateReferences = new List<string>();
      foreach (string reference in allReferences)
        if (!templateTagFilenames.ContainsKey(reference))
          nonTemplateReferences.Add(reference);
      
      // We now have a list of all references that are not essential tags - return it.
      return nonTemplateReferences.ToArray();
    }

    /// <summary>
    /// Removes references to all files that are contained by the specified folder.
    /// </summary>
    public void RemoveFolderReference(string path)
    {
      FolderEntry folder = projectReferencesTable.LocateFolderByPath(path);
      if (folder == null) return;
      foreach (FileEntry file in folder.FileEntries.ToArray())
        RemoveTagReference(file.FullPath);
      foreach (FolderEntry childFolder in folder.FolderEntries.ToArray())
        RemoveFolderReference(childFolder.FullPath);
    }

    /// <summary>
    /// Renames the file at the specified path.
    /// </summary>
    /// <param name="oldPath">The path of the file to be renamed.</param>
    /// <param name="newPath">The new full path to the file.</param>
    public void RenameFile(string oldPath, string newPath)
    {
      FileEntry file = projectReferencesTable.LocateFileByPath(oldPath);
      string newFileName = newPath.Substring(newPath.LastIndexOf("\\") + 1);
      file.Name = Path.GetFileNameWithoutExtension(newFileName);
      OnDirty();
    }

    /// <summary>
    /// Renames the folder at the specified path.
    /// </summary>
    /// <param name="oldPath">The path of the folder to be renamed.</param>
    /// <param name="newPath">The new full path to the folder.</param>
    public void RenameFolder(string oldPath, string newPath)
    {
      FolderEntry folder = projectReferencesTable.LocateFolderByPath(oldPath);
      string newFolderName = newPath.Substring(newPath.LastIndexOf("\\") + 1);
      folder.Name = newFolderName;
      OnDirty();
    }
    #endregion

    #region Protected Event Invokers
    /// <summary>
    /// Raises the TemplateReverting event and returns a value indicating
    /// if the action is marked to be cancelled.
    /// </summary>
    protected bool OnTemplateReverting(string templatePath, string templateName)
    {
      ForceTemplateRevertArgs e = new ForceTemplateRevertArgs(templatePath, templateName);
      if (TemplateReverting != null)
        TemplateReverting(this, e);
      return e.Cancel;
    }

    /// <summary>
    /// Raises the Dirty event.
    /// </summary>
    protected void OnDirty()
    {
      if (Dirty != null)
        Dirty(this, new EventArgs());
    }

    /// <summary>
    /// Raises the FileRemoved event.
    /// </summary>
    protected void OnFileRemoved(string path)
    {
      if (FileRemoved != null)
        FileRemoved(this, new LibraryFileActionArgs(path));
      OnDirty();
    }

    /// <summary>
    /// Raises the FileAdded event.
    /// </summary>
    protected void OnFileAdded(string path)
    {
      if (FileAdded != null)
        FileAdded(this, new LibraryFileActionArgs(path));
      OnDirty();
    }
    #endregion

    #region Event Handlers
    void templates_FileRemoved(object sender, TemplateTagActionArgs e)
    {
      OnDirty();
    }

    private void templates_FileAdded(object sender, TemplateTagActionArgs e)
    {
      OnDirty();
    }
    #endregion

    #region Non-Public Methods
    /// <summary>
    /// Reads and parses a previously emitted XML document representing the project.
    /// </summary>
    protected void ParseProjectFile(XmlDocument document)
    {
      // Loading data from various XML nodes.
      XmlNode projectNode = document.SelectSingleNode("//project");
      XmlNode gameNode = projectNode.SelectSingleNode("game");
      string gameName = gameNode.Attributes["name"].Value;

      // Make sure that we have a valid platform here.
      string gamePlatform = gameNode.Attributes["platform"].Value;
      if (!Enum.IsDefined(typeof(Platform), gamePlatform))
        throw new ProjectFileNotValidException("The specified platform does not exist: " + gamePlatform);

      Platform platform = (Platform)Enum.Parse(typeof(Platform), gamePlatform);
      if (GameDefinitionRequest != null)
      {
        GameDefinitionRequestEventArgs e = new GameDefinitionRequestEventArgs(gameName, platform);
        GameDefinitionRequest(this, e);
        game = e.GameDefinition;
        if (game == null)
          throw new ProjectFileNotValidException("Could not identify the referenced game id: " + e.GameID);
      }
      else
        throw new Exception(
          "Cannot retrieve game definition - the GameDefinitionRequest event is not handled by the Core.");

      XmlNode infoNode = projectNode.SelectSingleNode("info");
      author = infoNode.SelectSingleNode("author").InnerText;
      description = infoNode.SelectSingleNode("description").InnerText;
      version = new ProjectVersion(infoNode.SelectSingleNode("version").InnerText);

      XmlNode templatesNode = projectNode.SelectSingleNode("template");
      templateName = templatesNode.InnerText;

      XmlNode mapInfoNode = projectNode.SelectSingleNode("mapinfo");
      mapName = mapInfoNode.SelectSingleNode("name").InnerText;
      filename = mapInfoNode.SelectSingleNode("filename").InnerText;
      uiText = mapInfoNode.SelectSingleNode("uitext").InnerText;
      uiScreenShotFile = mapInfoNode.SelectSingleNode("uiscreenshot").InnerText;

      projectReferencesTable = new FileHierarchy();

      XmlNodeList referencesNodeList = projectNode.SelectNodes("references//tag");
      foreach (XmlNode tagNode in referencesNodeList)
      {
        string path = tagNode.InnerText;
        AddTagReference(path);
      }

      templates = new TemplateTagList(game.GetProjectTemplate(templateName));
      templates.FileAdded += templates_FileAdded;
      templates.FileRemoved += templates_FileRemoved;

      XmlNodeList templatesNodeList = projectNode.SelectNodes("essentialTags//tag");
      foreach (XmlNode tagNode in templatesNodeList)
      {
        string templateID = tagNode.Attributes["template_id"].InnerText;
        TagPath path = new TagPath(tagNode.InnerText);
        templates.Add(templateID, path);
      }
    }
    #endregion

    #region ILibrary Implementation
    /// <summary>
    /// Gets the name used to identify the ILibrary.
    /// </summary>
    public string Name
    {
      get { return "Project_" + mapName; }
    }

    /// <summary>
    /// Returns a list of all referenced files located under the specified path.
    /// </summary>
    public string[] GetFileList(string path)
    {
      return GetFileList(path, "*");
    }

    /// <summary>
    /// Returns a list of referenced files located under the specified path with the specified extension.
    /// </summary>
    public string[] GetFileList(string path, string extension)
    {
      return GetFileList(path, extension, false);
    }

    /// <summary>
    /// Returns a list of referenced files located under the specified path with the specified extension,
    /// optionally recursively returning all results from child folders under the path as well.
    /// </summary>
    public string[] GetFileList(string path, string extension, bool recursive)
    {
      // Make sure that the path we are looking in exists.
      FolderEntry folder = projectReferencesTable.LocateFolderByPath(path);
      if (folder == null) return new string[0];

      // Get the results.
      if (recursive)
        return folder.GetRecursiveFileList();
      else
        return folder.FileList();
    }

    /// <summary>
    /// Returns a list of referenced folders located under the specified path.
    /// </summary>
    public string[] GetFolderList(string path)
    {
      // Make sure that the path we are looking in exists.
      FolderEntry folder = projectReferencesTable.LocateFolderByPath(path);
      if (folder == null) return new string[0];

      return folder.FolderList();
    }

    /// <summary>
    /// Returns a bool indicating if the specified file is referenced by the project.
    /// </summary>
    public bool FileExists(string filename)
    {
      return projectReferencesTable.LocateFileByPath(filename.Trim('\\')) != null;
    }

    /// <summary>
    /// Returns a value indicating if the specified folder exists.
    /// </summary>
    public bool FolderExists(string foldername)
    {
      return projectReferencesTable.LocateFolderByPath(foldername) != null;
    }

    /// <summary>
    /// This method is not supported.
    /// </summary>
    public void AddFile(string filename, byte[] buffer)
    {
      throw new NotSupportedException("The ProjectFile ILibrary implementation does not support adding binary files.");
    }

    /// <summary>
    /// This method is not supported.
    /// </summary>
    public byte[] ReadFile(string filename)
    {
      throw new NotSupportedException("The ProjectFile ILibrary implementation does not support reading binary files.");
    }

    /// <summary>
    /// Signals that a file has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileAdded;

    /// <summary>
    /// Signals that a file has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileRemoved;

    /// <summary>
    /// Signals that a folder has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderAdded;

    /// <summary>
    /// Signals that a folder has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderRemoved;
    #endregion
  }

  #region Associated Classes
  /// <summary>
  /// Represents an exception during project load caused by a project file that contains invalid data.
  /// </summary>
  public class ProjectFileNotValidException : Exception
  {
    #region Constructors
    public ProjectFileNotValidException(string message)
      : base(message)
    {
    }

    public ProjectFileNotValidException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
    #endregion
  }

  /// <summary>
  /// Provides event data for informing the UI of a forced template reversion.
  /// </summary>
  public class ForceTemplateRevertArgs : EventArgs
  {
    #region Private Members
    private string templateName;
    private string templatePath;
    private bool cancel;
    #endregion

    #region Public Properties
    /// <summary>
    /// Gets the name of the template element being reverted.
    /// </summary>
    public string TemplateName
    {
      get { return templateName; }
    }

    /// <summary>
    /// Gets the path of the template element being reverted.
    /// </summary>
    public string TemplatePath
    {
      get { return templatePath; }
    }

    /// <summary>
    /// Gets or sets a value indicating if the action should be cancelled.
    /// </summary>
    public bool Cancel
    {
      get { return cancel; }
      set { cancel = value; }
    }
    #endregion

    #region Constructor
    /// <param name="templatePath">The path of the template element being reverted.</param>
    /// <param name="templateName">The name of the template element being reverted.</param>
    public ForceTemplateRevertArgs(string templatePath, string templateName)
    {
      this.templatePath = templatePath;
      this.templateName = templateName;
    }
    #endregion
  }

  /// <summary>
  /// Provides event data for a GameDefinitionRequest event.
  /// </summary>
  public class GameDefinitionRequestEventArgs : EventArgs
  {
    #region Private Members
    private GameDefinition gameDefinition = null;
    private string gameID;
    #endregion

    #region Public Properties
    public GameDefinition GameDefinition
    {
      get { return gameDefinition; }
      set { gameDefinition = value; }
    }

    /// <summary>
    /// The ID of the game being requested.
    /// </summary>
    public string GameID
    {
      get { return gameID; }
    }
    #endregion

    #region Constructors
    /// <param name="name">The name of the game that is being requested.</param>
    /// <param name="platform">The platfirm of the game that is being requested.</param>
    public GameDefinitionRequestEventArgs(string name, Platform platform)
      : this(Interfaces.Games.GameDefinition.GetGameID(name, platform)) { ; }

    /// <param name="gameID">The ID of the game that is being requested.</param>
    public GameDefinitionRequestEventArgs(string gameID)
    {
      this.gameID = gameID;
    }
    #endregion
  }
  #endregion
}