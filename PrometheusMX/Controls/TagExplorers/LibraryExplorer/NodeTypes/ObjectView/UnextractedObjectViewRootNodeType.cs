using System;
using System.Collections.Generic;
using Interfaces.Games;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class UnextractedObjectViewRootNodeType : NodeType
  {
    public UnextractedObjectViewRootNodeType() : base("unextractedroot", 1, 101, true) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveObjectViewNodeSource source = (TagArchiveObjectViewNodeSource)ParentSource;

      foreach (string group in source.Game.TypeTable.HighLevelTypeGroups)
      {
       foreach (TypeTableEntry entry in source.Game.TypeTable.GetHighLevelTypes(group))
        if (source.Library.MissingFilesArchive.FileTypeExists(entry.FullName))
        {
          children.Add(new NodeInfo(ParentSource.GetNodeType<UnextractedHLTGroupNodeType>(), "[" + group + "]"));
          break;
        }
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      return null; // This is a root node, and can have no parent nodes.
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;
      bool hasChildren = false;
      if (source.Library.MissingFilesArchive.GetFolderList("").Length > 0)
        hasChildren = true;
      else if (source.Library.MissingFilesArchive.GetFileList("").Length > 0)
        hasChildren = true;
      return hasChildren;
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public override string GetTreePath(NodeInfo info)
    {
      return ParentSource.Name + "|" + info.Identifier.Replace("|", "\\");
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      return "";
    }
  }
}