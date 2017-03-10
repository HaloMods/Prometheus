using System;
using System.Collections.Generic;
using System.IO;
using Interfaces.Games;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class FolderNodeType : NodeType
  {
    public FolderNodeType() : base("folder", 3, 1, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;

      string[] folders = source.Library.GetFolderList(info.Identifier);
      foreach (string folder in folders)
      {
        FolderNodeType nodeType = source.GetNodeType<FolderNodeType>();
        NodeInfo newInfo = new NodeInfo(nodeType, folder);
        children.Add(newInfo);
      }

      string[] files = source.Library.GetFileList(info.Identifier, "*");
      foreach (string file in files)
      {
        NodeType nodeType = source.GetNodeType(file);
        NodeInfo newInfo = new NodeInfo(nodeType, file);
        children.Add(newInfo);
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      NodeInfo newInfo = new NodeInfo(
        ParentSource.GetNodeType<FolderNodeType>(), Path.GetDirectoryName(info.Identifier));
      return newInfo;
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;
      bool hasChildren = false;
      if (source.Library.GetFolderList(info.Identifier).Length > 0)
        hasChildren = true;
      else if (source.Library.GetFileList(info.Identifier).Length > 0)
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
      return Path.GetFileName(identifier);
    }
  }
}
