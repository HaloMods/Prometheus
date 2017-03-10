using System;
using System.Collections.Generic;
using Prometheus.Controls;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class UnextractedRootNodeType : NodeType
  {
    public UnextractedRootNodeType() : base("unextractedroot", 1, Int32.MaxValue, true) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;
      string[] folders = source.Library.MissingFilesArchive.GetFolderList("");
      foreach (string folder in folders)
      {
        UnextractedFolderNodeType nodeType = source.GetNodeType<UnextractedFolderNodeType>();
        NodeInfo folderInfo = new NodeInfo(nodeType, folder);
        children.Add(folderInfo);
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