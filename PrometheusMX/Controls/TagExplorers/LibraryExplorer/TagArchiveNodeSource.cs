using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Core.Libraries;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.UserInterface;
using Prometheus.Controls.TagExplorers;
using Prometheus.Controls.TagExplorers.Library;
using Prometheus.Properties;

namespace Prometheus.Controls
{
  public class TagArchiveNodeSource : NodeSource
  {
    #region Private Members
    private GameDefinition game;
    private DisplayItems items;
    #endregion

    /// <summary>
    /// Gets the game that this source belong to.
    /// </summary>
    public GameDefinition Game
    {
      get { return game; }
    }

    /// <summary>
    /// Gets the tag archive that is represented by this NodeSource.
    /// </summary>
    public TagArchive Library
    {
      get { return (TagArchive)game.GlobalTagLibrary; }
    }

    /// <summary>
    /// Gets a value indicating if the NodeSource contains nodes.
    /// </summary>
    public override bool ContainsNodes
    {
      get
      {
        if ((items & DisplayItems.Files) > 0)
          if (Library.GetFileList("", "*").Length > 0)
            return true;
        if ((items & DisplayItems.Folders) > 0)
          if (Library.GetFolderList("").Length > 0)
            return true;
        if ((items & DisplayItems.UnextractedFiles) > 0)
          if (Library.MissingFilesArchive.GetFileList("", "*").Length > 0)
            return true;
        if ((items & DisplayItems.UnextractedFolders) > 0)
          if (Library.MissingFilesArchive.GetFolderList("").Length > 0)
            return true;
        return false;
      }
    }

    public override event ItemHandler ItemAdded;
    public override event ItemHandler ItemRemoved;

    public TagArchiveNodeSource(string name, GameDefinition game, IDocumentManager documentManager,
      DefaultState defaultState)
      : this(name, game, documentManager, DisplayItems.AllExtractedItems,
      defaultState) { ; }

    public TagArchiveNodeSource(string name, GameDefinition game, IDocumentManager documentManager,
      DisplayItems items, DefaultState defaultState)
      : base(name)
    {
      this.game = game;
      Library.FileAdded += new EventHandler<LibraryFileActionArgs>(Library_FileAdded);
      this.items = items;

      // Add NodeTypes
      if ((items & DisplayItems.AllExtractedItems) > 0)
      {
        AddNodeType(CreateNodeType<RootNodeType>(defaultState));

        FolderNodeType folder = CreateNodeType<FolderNodeType>(Resources.folder16, Resources.folder_closed16);
        AddNodeType(folder);

        FileNodeType file = CreateNodeType<FileNodeType>(Resources.document16);
        file.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.document_view16, Resources.document_view16, Color.Blue, Color.White));
        AddNodeType(file);

        ObjectFileNodeType objectFile = CreateNodeType<ObjectFileNodeType>(Resources.data16);
        objectFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.data_view16, Resources.data_view16, Color.Blue, Color.White));
        AddNodeType(objectFile);

        ModelFileNodeType modelFile = CreateNodeType<ModelFileNodeType>(Resources.cube_molecule16);
        modelFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.cube_molecule_view16, Resources.cube_molecule_view16, Color.Blue, Color.White));
        AddNodeType(modelFile);

        SbspFileNodeType sbspFile = CreateNodeType<SbspFileNodeType>(Resources.environment16);
        sbspFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.environment_view16, Resources.environment_view16, Color.Blue, Color.White));
        AddNodeType(sbspFile);

        ScenarioFileNodeType scenarioFile = CreateNodeType<ScenarioFileNodeType>(Resources.earth16);
        scenarioFile.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.earth_view16, Resources.earth_view16, Color.Blue, Color.White));
        AddNodeType(scenarioFile);

        AttachedScriptNodeType attachedScript = CreateNodeType<AttachedScriptNodeType>(Resources.text_code_colored16);
        attachedScript.AddNodeState(new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.text_view16, Resources.text_view16, Color.Blue, Color.White));
        AddNodeType(attachedScript);
      }

      if ((items & DisplayItems.AllUnextractedItems) > 0)
      {
        AddNodeType(CreateNodeType<UnextractedRootNodeType>(defaultState));

        UnextractedFolderNodeType unextractedfolder = CreateNodeType<UnextractedFolderNodeType>(
          new DefaultState(Resources.folder16, Resources.folder_closed16, Color.Gray, Color.White));
        AddNodeType(unextractedfolder);

        UnextractedFileNodeType unextractedfile = CreateNodeType<UnextractedFileNodeType>(
          new DefaultState(Resources.document_text16, Resources.document_text16, Color.Gray, Color.White));
        AddNodeType(unextractedfile);
      }
    }

    public override void Dispose()
    {
      Library.FileAdded -= new EventHandler<LibraryFileActionArgs>(Library_FileAdded);
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

    void Library_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if ((items & DisplayItems.Files) != 0)
      {
        NodeType nodeType = GetNodeType(e.Filename);
        NodeInfo addedInfo = new NodeInfo(nodeType, e.Filename);
        OnItemAdded(addedInfo);
      }

      if ((items & DisplayItems.UnextractedFiles) != 0)
      {
        NodeType nodeType = GetNodeType<UnextractedFileNodeType>();
        NodeInfo removedInfo = new NodeInfo(nodeType, e.Filename);
        OnItemRemoved(removedInfo);
      }
    }

    Dictionary<string, NodeType> extensionCache = new Dictionary<string, NodeType>();
    private void CacheTypeExtensions()
    {
      NodeType scenarioNodeType = GetNodeType<ScenarioFileNodeType>();
      foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes("Scenarios"))
        extensionCache.Add(entry.FullName, scenarioNodeType);

      NodeType sbspNodeType = GetNodeType<SbspFileNodeType>();
      foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes("BSP"))
        extensionCache.Add(entry.FullName, sbspNodeType);

      // Get a list of file types from the 'object' HLT categories.
      NodeType objectNodeType = GetNodeType<ObjectFileNodeType>();
      foreach (string group in new string[] { "Bipeds", "Devices", "Misc", "Scenery", "Vehicles", "Weapons" })
        foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes(group))
          extensionCache.Add(entry.FullName, objectNodeType);

      // HACK: This is game specific and needs to be factored into GameDef at some point (low priority)
      NodeType modelNodeType = GetNodeType<ModelFileNodeType>();
      extensionCache.Add("gbxmodel", modelNodeType);
      extensionCache.Add("model", modelNodeType);

      // Any other type not in the table...
      extensionCache.Add("*", GetNodeType<FileNodeType>());
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

    public override bool CanDropInto(NodeType parentNodeType, NodeType childNodeType)
    {
      // Node dragging/dropping is not allowed with data from this node source.
      return false;
    }

    public override NodeInfo[] CreateRootNodeInfo()
    {
      List<NodeInfo> infos = new List<NodeInfo>();

      if ((items & DisplayItems.Folders) != 0)
        infos.Add(new NodeInfo(GetNodeType<RootNodeType>(), ""));
      if ((items & DisplayItems.UnextractedFolders) != 0)
        infos.Add(new NodeInfo(GetNodeType<UnextractedRootNodeType>(), ""));
      return infos.ToArray();
    }

    public override void HandleNodeDrop(NodeInfo info, NodeInfo targetInfo)
    {
      
    }
  }

  [Flags]
  public enum DisplayItems
  {
    None = 0,
    Files = 1,
    Folders = 2,
    AllExtractedItems = Files | Folders,
    UnextractedFiles = 4,
    UnextractedFolders = 8,
    AllUnextractedItems = UnextractedFiles | UnextractedFolders,
    AllItems = AllExtractedItems | AllUnextractedItems
  }
}