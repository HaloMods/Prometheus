using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Core.Libraries;
using Core.Project;
using Interfaces;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.Project;
using Interfaces.UserInterface;
using Prometheus.Controls.TagExplorers.Library;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class ProjectNodeSource : NodeSource
  {
    private ProjectManager projectManager;
    private IDocumentManager documentManager;
    private GameDefinition game;
    private ProjectReferencesLibrary projectReferences;
    private DiskFileLibrary projectFolder;

    public DiskFileLibrary ProjectFolder
    {
      get { return projectFolder; }
    }

    public ProjectReferencesLibrary ProjectReferences
    {
      get { return projectReferences; }
    }

    public GameDefinition GameDefinition
    {
      get { return game; }
    }

    public TemplateTagList TemplateTags
    {
      get { return projectManager.Project.Templates; }
    }

    /// <summary>
    /// Gets a reference to this source's associated ProjectManager.
    /// </summary>
    public ProjectManager ProjectManager
    {
      get { return projectManager; }
    }

    public ProjectNodeSource(string name, IDocumentManager documentManager,
      ProjectManager projectManager, DefaultState defaultState)
      : base(name)
    {
      this.projectManager = projectManager;
      this.documentManager = documentManager;
      this.documentManager.DocumentRenamed += documentManager_DocumentRenamed;
      game = Core.Prometheus.Instance.GetGameDefinitionByGameID(projectManager.GameID);

      // Combined tag source - Project References and TemplateTags that exist in the project.
      projectReferences = new ProjectReferencesLibrary(
        "projectrefs", projectManager.Project, projectManager.Project.Templates);
      projectReferences.FileAdded += FileAdded;
      projectReferences.FileRemoved += FileRemoved;

      projectFolder = projectManager.ProjectFolder;
      projectFolder.FileAdded += FileAdded;
      projectFolder.FileRemoved += FileRemoved;
      projectFolder.FolderAdded += FolderAdded;
      projectFolder.FolderRemoved += FolderRemoved;

      projectManager.Project.Templates.FileAdded += Templates_FileAdded;
      projectManager.Project.Templates.FileRemoved += Templates_FileRemoved;

      AddNodeType(CreateNodeType<RootNodeType>(defaultState));

      UnreferencedState unreferenced = new UnreferencedState(this, "unreferenced", Resources.document_plain16, Resources.document_plain16, Color.Gray, Color.White);
      MissingReferencedState missing = new MissingReferencedState(this, "missing_reference", Resources.document_error16, Resources.document_error16, Color.Red, Color.White); 

      NodeType folder = CreateNodeType<FolderNodeType>(Resources.folder16, Resources.folder_closed16);
      AddNodeType(folder);
      folder.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(folder_NodeRenamed);

      NodeType tagNode = CreateNodeType<TagNode>(Resources.document16);
      tagNode.AddNodeState(new ValidReferencedState(this, "valid_reference", Resources.document16, Resources.document16, Color.Black, Color.White));
      tagNode.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Project, Resources.document_view16, Resources.document_view16, Color.Blue, Color.White));
      tagNode.AddNodeState(unreferenced);
      tagNode.AddNodeState(missing);
      AddNodeType(tagNode);
      tagNode.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(tagNode_NodeRenamed);

      ObjectTag objectFile = CreateNodeType<ObjectTag>(Resources.data16);
      objectFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Project, Resources.data_view16, Resources.data_view16, Color.Blue, Color.White));
      objectFile.AddNodeState(new ValidReferencedState(this, "valid_reference", Resources.data16, Resources.data16, Color.Black, Color.White));
      objectFile.AddNodeState(unreferenced);
      objectFile.AddNodeState(missing);
      AddNodeType(objectFile);
      objectFile.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(tagNode_NodeRenamed);

      NodeType modelFile = CreateNodeType<ModelTag>(Resources.cube_molecule16);
      modelFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Project, Resources.cube_molecule_view16, Resources.cube_molecule_view16, Color.Blue, Color.White));
      modelFile.AddNodeState(new ValidReferencedState(this, "valid_reference", Resources.cube_molecule16, Resources.cube_molecule16, Color.Black, Color.White));
      modelFile.AddNodeState(unreferenced);
      modelFile.AddNodeState(missing);
      AddNodeType(modelFile);
      modelFile.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(tagNode_NodeRenamed);

      NodeType sbspFile = CreateNodeType<SbspTag>(Resources.environment16);
      sbspFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Project, Resources.environment_view16, Resources.environment_view16, Color.Blue, Color.White));
      sbspFile.AddNodeState(new ValidReferencedState(this, "valid_reference", Resources.environment16, Resources.environment16, Color.Black, Color.White));
      sbspFile.AddNodeState(unreferenced);
      sbspFile.AddNodeState(missing);
      AddNodeType(sbspFile);
      sbspFile.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(tagNode_NodeRenamed);

      NodeType scenarioFile = CreateNodeType<ScenarioTag>(Resources.earth16);
      scenarioFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Project, Resources.earth_view16, Resources.earth_view16, Color.Blue, Color.White));
      scenarioFile.AddNodeState(new ValidReferencedState(this, "valid_reference", Resources.earth16, Resources.earth16, Color.Black, Color.White));
      scenarioFile.AddNodeState(unreferenced);
      scenarioFile.AddNodeState(missing);
      AddNodeType(scenarioFile);
      scenarioFile.NodeRenamed += new System.EventHandler<NodeRenamedEventArgs>(tagNode_NodeRenamed);

      NodeType propertiesNode = CreateNodeType<PropertiesRootNodeType>(Resources.preferences16);
      AddNodeType(propertiesNode);

      NodeType essentialTagsNode = CreateNodeType<EssentialTagsRoot>(Resources.components16);
      AddNodeType(essentialTagsNode);

      NodeType projectTemplateTagNode = CreateNodeType<ProjectTemplateTagNodeType>(Resources.application16);
      AddNodeType(projectTemplateTagNode);

      NodeType globalTemplateTagNode = CreateNodeType<GlobalTemplateTagNodeType>(Resources.joystick16);
      AddNodeType(globalTemplateTagNode);

      NodeType recycleBinNode = CreateNodeType<RecycleBinRootNodeType>(Resources.garbage_empty16);
      recycleBinNode.AddNodeState(new RecycleBinContainsFilesState(projectManager.Project.RecycleBin,
        "recyclebin_not_empty", Resources.garbage_full16, Resources.garbage_full16, Color.Black, Color.White));
       //TODO: Need to create a state for when the recycle bin is completely full (though, I'm not sure how this
       //would work, because you can't say that it's "full" because you don't know how big the file is that they
       //are going to try to add - it may fit or it may not, and the recycle bin is very unlikely to contain
       //the exact number of bytes that it can hold before it is considered "full".)
      AddNodeType(recycleBinNode);
    }

    void tagNode_NodeRenamed(object sender, NodeRenamedEventArgs e)
    {
      if (projectFolder.FileExists(e.OldIdentifier))
        projectFolder.RenameFile(e.OldIdentifier, e.NewIdentifier);

      if (projectManager.Project.FileExists(e.OldIdentifier))
        projectManager.Project.RenameFile(e.OldIdentifier, e.NewIdentifier);
    }

    void folder_NodeRenamed(object sender, NodeRenamedEventArgs e)
    {
      // We need to do several things here:
      // 1. We need to rename the folder if it exists on the disk.
      if (projectFolder.FolderExists(e.OldIdentifier))
        projectFolder.RenameFolder(e.OldIdentifier, e.NewIdentifier);

      // 2. If this is a referenced folder, it needs to be renamed in the references table.
      //    NOTE: Due to the hierarchial nature of data in the table, child entries should not need updating.
      if (projectManager.Project.FolderExists(e.OldIdentifier))
        projectManager.Project.RenameFolder(e.OldIdentifier, e.NewIdentifier);

      // 3. Do something to essential tags nodes/references in the table (not sure what this will be yet.)
    }

    private void FolderRemoved(object sender, LibraryFileActionArgs e)
    {
      // This folder may still exist in one of the sources - if so, don't remove it.
      if (projectFolder.FolderExists(e.Filename))
        return;
      if (projectReferences.FolderExists(e.Filename))
        return;

      NodeType nodeType = GetNodeType<FolderNodeType>();
      NodeInfo info = new NodeInfo(nodeType, e.Filename);
      OnItemRemoved(info);
    }
    
    private void FolderAdded(object sender, LibraryFileActionArgs e)
    {
      NodeType nodeType = GetNodeType<FolderNodeType>();
      NodeInfo info = new NodeInfo(nodeType, e.Filename);
      OnItemAdded(info);
    }

    void FileRemoved(object sender, LibraryFileActionArgs e)
    {
      // Make sure the file doesn't exist in either source.
      if (projectReferences.FileExists(e.Filename))
        return;
      if (projectFolder.FileExists(e.Filename))
        return;

      NodeType nodeType = GetNodeType(e.Filename);
      NodeInfo info = new NodeInfo(nodeType, e.Filename);
      OnItemRemoved(info);
    }

    void FileAdded(object sender, LibraryFileActionArgs e)
    {
      NodeType nodeType = GetNodeType(e.Filename);
      NodeInfo info = new NodeInfo(nodeType, e.Filename);
      OnItemAdded(info);
    }

    void documentManager_DocumentRenamed(IDocument document, string oldPath)
    {
      Output.Write(OutputTypes.Debug, "Document renamed from " + oldPath + " to " + document.DocumentFilename);

      TagPath oldTagPath = new TagPath(oldPath);
      string testPath;
      if (oldTagPath.Location == TagLocation.Archive)
        testPath = oldTagPath.ToPath(PathFormat.Relative);
      else
        testPath = oldTagPath.ToPath(PathFormat.ExplicitLocation);

      foreach (ProjectTag tag in projectManager.Project.Templates.GetTemplateList())
      {
        if (tag.Path == testPath)
        {
          projectManager.Project.Templates.UpdateElementPath(
            tag.TemplateElement, document.DocumentFilename);
          return;
        }
      }

      foreach (TemplateTag tag in projectManager.Project.Template.TagSet)
      {
        if (tag.DefaultFile + "." + tag.FileType == testPath)
        {
          projectManager.Project.Templates.Add(tag.Name, new TagPath(document.DocumentFilename));
          return;
        }
      }
    }

    void Templates_FileRemoved(object sender, TemplateTagActionArgs e)
    {
      TagPath path = new TagPath(e.Filename);
      NodeInfo info;
      if (path.Location == TagLocation.Project)
        info = new NodeInfo(GetNodeType<ProjectTemplateTagNodeType>(),
          path.ToPath(PathFormat.ExplicitLocation));
      else
        info = new NodeInfo(GetNodeType<GlobalTemplateTagNodeType>(),
          path.ToPath(PathFormat.Relative));
      
      info.Tag = e.TemplateElement;
      OnItemRemoved(info);
    }

    void Templates_FileAdded(object sender, TemplateTagActionArgs e)
    {
      TagPath path = new TagPath(e.Filename);
      NodeInfo info;
      if (path.Location == TagLocation.Project)
        info = new NodeInfo(GetNodeType<ProjectTemplateTagNodeType>(),
          path.ToPath(PathFormat.ExplicitLocation));
      else
        info = new NodeInfo(GetNodeType<GlobalTemplateTagNodeType>(),
          path.ToPath(PathFormat.Relative));

      info.Tag = e.TemplateElement;
      OnItemAdded(info);
    }

    void OnItemAdded(NodeInfo info)
    {
      if (ItemAdded != null)
        ItemAdded(info);
    }

    void OnItemRemoved(NodeInfo info)
    {
      if (ItemRemoved != null)
        ItemRemoved(info);
    }

    Dictionary<string, NodeType> extensionCache = new Dictionary<string, NodeType>();
    private void CacheTypeExtensions()
    {
      NodeType scenarioNodeType = GetNodeType<ScenarioTag>();
      foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes("Scenarios"))
        extensionCache.Add(entry.FullName, scenarioNodeType);

      NodeType sbspNodeType = GetNodeType<SbspTag>();
      foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes("BSP"))
        extensionCache.Add(entry.FullName, sbspNodeType);

      // Get a list of file types from the 'object' HLT categories.
      NodeType objectNodeType = GetNodeType<ObjectTag>();
      foreach (string group in new string[] { "Bipeds", "Devices", "Misc", "Scenery", "Vehicles", "Weapons" })
        foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes(group))
          extensionCache.Add(entry.FullName, objectNodeType);

      // HACK: This is game specific and needs to be factored into GameDef at some point (low priority)
      NodeType modelNodeType = GetNodeType<ModelTag>();
      extensionCache.Add("gbxmodel", modelNodeType);
      extensionCache.Add("model", modelNodeType);

      // Any other type not in the table...
      extensionCache.Add("*", GetNodeType<TagNode>());
    }

    /// <summary>
    /// Returns the NodeType that matches the specified identifier.
    /// </summary>
    public NodeType GetNodeType(string identifier)
    {
      if (extensionCache.Count == 0)
        CacheTypeExtensions();

      string extension = Path.GetExtension(identifier).Trim('.');
      NodeType type;
      if (!extensionCache.TryGetValue(extension, out type))
        type = extensionCache["*"];

      return type;
    }

    /// <summary>
    /// Gets a value indicating if the NodeSource contains nodes.
    /// </summary>
    public override bool ContainsNodes
    {
      get { return true; }
    }

    /// <summary>
    /// Indicates that an item has been added to the NodeSource.
    /// </summary>
    public override event ItemHandler ItemAdded;

    /// <summary>
    /// Indicates that an item has been removed from the NodeSource.
    /// </summary>
    public override event ItemHandler ItemRemoved;

    /// <summary>
    /// Creates the NodeInfo objects that will be contained in the root node.
    /// </summary>
    public override NodeInfo[] CreateRootNodeInfo()
    {
      List<NodeInfo> infos = new List<NodeInfo>();
      infos.Add(new NodeInfo(GetNodeType<RootNodeType>(), ""));
      return infos.ToArray();
    }

    /// <summary>
    /// Returns a value indicating of the specified child NodeType can be dropped
    /// into a node of the specified parent NodeType.
    /// </summary>
    public override bool CanDropInto(NodeType parentNodeType, NodeType childNodeType)
    {
      if (parentNodeType is RecycleBinRootNodeType)
      {
        if (IsTag(childNodeType))
          return true;
        else if (childNodeType is FolderNodeType)
          return true;
      }
      return false;
    }

    /// <summary>
    /// Returns a value indicating if the specified type represents a tag in the source.
    /// </summary>
    public bool IsTag(NodeType type)
    {
      return (type is TagNode || 
              type is ScenarioTag ||
              type is SbspTag ||
              type is ObjectTag ||
              type is ModelTag);
    }

    public override void HandleNodeDrop(NodeInfo info, NodeInfo targetInfo)
    {
      if (targetInfo.NodeType is RecycleBinRootNodeType)
        if (IsTag(info.NodeType))
          DeleteFile(info.Identifier);
        else if (info.NodeType is FolderNodeType)
          DeleteFolder(info.Identifier);
    }

    /// <summary>
    /// Move the specified folder to the recycle bin.
    /// </summary>
    public void DeleteFolder(string path)
    {
      // Add the folder to the recycle bin.
      projectManager.Project.RecycleBin.AddFolder(path);

      // Remove all of the references.
      foreach (string file in projectManager.Project.GetFileList(path, "*", true))
        projectManager.Project.RemoveTagReference(file, true);

      // Delete all of the physical files.
      RemoveFolderAndChildren(path);
    }

    /// <summary>
    /// Deletes the specified folder and all files and child folders.
    /// </summary>
    private void RemoveFolderAndChildren(string path)
    {
      // Delete the files in this folder.
      foreach (string file in projectManager.ProjectFolder.GetFileList(path))
       projectManager.ProjectFolder.DeleteFile(file);

      // Recursively delete the folders in this folder.
      foreach (string folder in projectManager.ProjectFolder.GetFolderList(path))
        RemoveFolderAndChildren(folder);

      // Delete the current folder, as it is now empty.
      projectManager.ProjectFolder.DeleteFolder(path);
    }

    private void DeleteFile(string path)
    {
      // Remove the project reference, if there is one, bitch.
      bool deleteFile = true;
      if (projectManager.Project.FileExists(path))
        deleteFile = projectManager.Project.RemoveTagReference(path);

      // We fin'a delete dis ma'facka!
      if (deleteFile)
        if (projectManager.ProjectFolder.FileExists(path))
        {
          projectManager.Project.RecycleBin.AddFile(path);
          projectManager.ProjectFolder.DeleteFile(path);
        }
    }
  }
}