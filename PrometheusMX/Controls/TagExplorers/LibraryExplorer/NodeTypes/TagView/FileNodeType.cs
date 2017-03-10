using System;
using System.IO;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class FileNodeType : NodeType
  {
    public FileNodeType() : this("file", 2, 1, false) { ; }

    protected FileNodeType(string name, int sortingPriority, int typePriority, bool displayCheckbox)
      :base(name, sortingPriority, typePriority, displayCheckbox) { ; }
      

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      return new NodeInfo[0]; // No children in this NodeType.
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
      return false; // No children in this NodeType.
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