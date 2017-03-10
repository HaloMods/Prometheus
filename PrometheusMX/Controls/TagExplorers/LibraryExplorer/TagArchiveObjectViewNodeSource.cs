using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Core.Libraries;
using Interfaces.Games;
using Interfaces.Pool;
using Interfaces.UserInterface;
using Prometheus.Controls.TagExplorers.Library;
using Prometheus.Properties;

namespace Prometheus.Controls
{
  public class TagArchiveObjectViewNodeSource : NodeSource
  {
    #region Private Members
    private GameDefinition game;
    private DisplayItems items;
    private bool loadDependencies = false;
    #endregion

    public TagArchiveObjectViewNodeSource(string name, GameDefinition game,
      IDocumentManager documentManager, DisplayItems items, DefaultState defaultState)
      : this(name, game, documentManager, items, defaultState, true) { ; }

    public TagArchiveObjectViewNodeSource(string name, GameDefinition game, IDocumentManager documentManager,
      DisplayItems items, DefaultState defaultState, bool loadDependencies)
      : base(name)
    {
      this.game = game;
      this.items = items;
      this.loadDependencies = loadDependencies;
      Library.FileAdded += new EventHandler<LibraryFileActionArgs>(Library_FileAdded);

      if ((items & DisplayItems.AllExtractedItems) > 0)
      {
        AddNodeType(CreateNodeType<ObjectViewRootNodeType>(defaultState));

        HLTGroupNodeType groups = CreateNodeType<HLTGroupNodeType>(
          new DefaultState(Resources.book_open16, Resources.book_blue16, Color.Black, Color.White));
        AddNodeType(groups);

        HLTNodeType htlType = CreateNodeType<HLTNodeType>(Resources.data16);
        htlType.AddNodeState(
          new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.data_view16, Resources.data_view16, Color.Blue, Color.White));
        AddNodeType(htlType);

        TagNodeType tagType = CreateNodeType<TagNodeType>(Resources.document_up16);
        tagType.AddNodeState(
          new DocumentOpenState(documentManager, game.GameID, TagLocation.Archive, Resources.document_view16, Resources.document_view16, Color.Blue,
                                Color.White));
        AddNodeType(tagType);
      }
      if ((items & DisplayItems.AllUnextractedItems) > 0)
      {
        AddNodeType(CreateNodeType<UnextractedObjectViewRootNodeType>(defaultState));

        UnextractedHLTGroupNodeType unextractedHLTGroup = CreateNodeType<UnextractedHLTGroupNodeType>(
          new DefaultState(Resources.book_open16, Resources.book_blue16, Color.Gray, Color.White));
        AddNodeType(unextractedHLTGroup);

        UnextractedHLTNodeType unextractedHLT = CreateNodeType<UnextractedHLTNodeType>(
          new DefaultState(Resources.data16, Resources.data16, Color.Gray, Color.White));
        AddNodeType(unextractedHLT);
      }
    }

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

    public bool LoadDependencies
    {
      get { return loadDependencies; }
      set { loadDependencies = value; }
    }

    /// <summary>
    /// Indicates that an item has been added to the NodeSource.
    /// </summary>
    public override event ItemHandler ItemAdded;

    /// <summary>
    /// Indicates that an item has been removed from the NodeSource.
    /// </summary>
    public override event ItemHandler ItemRemoved;

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
        NodeType nodeType = GetNodeType<HLTNodeType>();
        NodeInfo addedInfo = new NodeInfo(nodeType, e.Filename);
        OnItemAdded(addedInfo);
      }

      if ((items & DisplayItems.UnextractedFiles) != 0)
      {
        NodeType nodeType = GetNodeType<UnextractedHLTNodeType>();
        NodeInfo removedInfo = new NodeInfo(nodeType, e.Filename);
        OnItemRemoved(removedInfo);
      }
    }

    public string GetHLTGroupFromFilename(string filename)
    {
      string extension = Path.GetExtension(filename).TrimStart('.');
      foreach (string group in game.TypeTable.HighLevelTypeGroups)
        foreach (TypeTableEntry entry in game.TypeTable.GetHighLevelTypes(group))
          if (entry.FullName == extension)
            return group;
      return "";
    }

    /// <summary>
    /// Creates the NodeInfo objects that will be contained in the root node.
    /// </summary>
    public override NodeInfo[] CreateRootNodeInfo()
    {
      List<NodeInfo> infos = new List<NodeInfo>();

      if ((items & DisplayItems.Folders) != 0)
        infos.Add(new NodeInfo(GetNodeType<ObjectViewRootNodeType>(), ""));
      if ((items & DisplayItems.UnextractedFolders) != 0)
        infos.Add(new NodeInfo(GetNodeType<UnextractedObjectViewRootNodeType>(), ""));
      return infos.ToArray();
    }

    /// <summary>
    /// Returns a value indicating of the specified parent NodeType can be dropped
    /// into a node of the specified child NodeType.
    /// </summary>
    public override bool CanDropInto(NodeType parentNodeType, NodeType childNodeType)
    {
      return false; // Nope!
    }

    public override void HandleNodeDrop(NodeInfo info, NodeInfo targetInfo)
    {
      
    }
  }
}