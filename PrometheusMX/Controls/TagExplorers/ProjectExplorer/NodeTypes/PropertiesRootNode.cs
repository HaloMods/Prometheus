using System;
using System.Collections.Generic;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class PropertiesRootNodeType : NodeType
  {
    public PropertiesRootNodeType()
      : base("properties", 20, Int32.MaxValue, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      children.Add(new NodeInfo(ParentSource.GetNodeType<EssentialTagsRoot>(), "Essential Tags"));
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      return null; // We will never need to udpdate this node's parent.
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      return true; // Will always contain child entries.
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
      return "Properties";
    }
  }
}