using System;
using System.Collections.Generic;
using System.IO;
using Prometheus.Controls;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class RootNodeType : NodeType
  {
    public RootNodeType() : base("root", 1, Int32.MaxValue, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;
      string[] folders = source.Library.GetFolderList("");
      foreach (string folder in folders)
      {
        FolderNodeType nodeType = source.GetNodeType<FolderNodeType>();
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
      if (source.Library.GetFolderList("").Length > 0)
        hasChildren = true;
      else if (source.Library.GetFileList("").Length > 0)
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