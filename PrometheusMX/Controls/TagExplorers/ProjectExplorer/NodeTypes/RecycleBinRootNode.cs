using System;
using System.Collections.Generic;
using DevComponents.DotNetBar;
using System.Drawing;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class RecycleBinRootNodeType : NodeType
  {
    public RecycleBinRootNodeType()
      : base("recyclebin", 19, Int32.MaxValue, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
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
      // This is not yet implemented.
      return false;
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public override string GetTreePath(NodeInfo info)
    {
      return ParentSource.Name + "|" + "Properties\\Recycle Bin";
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      return "Recycle Bin";
    }

    public override SuperTooltipInfo GetTooltip(NodeInfo info)
    {
      // Get the modified date for the specified file.
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;

      // Count the number of files unde the specified path.
      int fileCount = source.ProjectManager.Project.RecycleBin.TotalFiles;

      return new SuperTooltipInfo(
        "Recycle Bin", "", fileCount > 0 ? "<b>Total Files Contained:</b> " + String.Format("{0:,0}", fileCount) : "<i>Currently Empty</i>", null, null, eTooltipColor.System, true,
        false, new Size(0, 0));
    }
  }
}