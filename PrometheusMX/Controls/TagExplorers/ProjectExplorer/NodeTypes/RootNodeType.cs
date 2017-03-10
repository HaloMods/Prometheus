using System;
using System.Collections.Generic;
using DevComponents.DotNetBar;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class RootNodeType : FolderNodeType
  {
    public RootNodeType()
      : base("root", 1, Int32.MaxValue, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      children.Add(new NodeInfo(ParentSource.GetNodeType<PropertiesRootNodeType>(), "properties"));
      children.AddRange(base.GetChildNodes(info));
      children.Add(new NodeInfo(ParentSource.GetNodeType<RecycleBinRootNodeType>(), "recyclebin"));
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
      return true;
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

    public override bool SupportsRenaming
    {
      get { return false; }
    }

    public override SuperTooltipInfo GetTooltip(NodeInfo info)
    {
      return null; 
    }
  }
}