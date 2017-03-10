using System;
using System.Collections.Generic;
using System.IO;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class UnextractedHLTNodeType : NodeType
  {
    public UnextractedHLTNodeType() : base("unextractedhlt", 2, 2, true) { ; }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      return Path.GetFileName(identifier);
    }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      return new List<NodeInfo>().ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      TagArchiveObjectViewNodeSource source = (TagArchiveObjectViewNodeSource)ParentSource;
      string groupName = source.GetHLTGroupFromFilename(info.Identifier);
      NodeInfo parentInfo = new NodeInfo(ParentSource.GetNodeType<UnextractedHLTGroupNodeType>(), groupName);
      return parentInfo;
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      return false;
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public override string GetTreePath(NodeInfo info)
    {
      if (info.Identifier.StartsWith("["))
        return ParentSource.Name + "|" + info.Identifier.Trim('[', ']');

      string groupName = ((TagArchiveObjectViewNodeSource)ParentSource).GetHLTGroupFromFilename(info.Identifier);
      if (groupName == "") return "";
      return ParentSource.Name + "|" + groupName + "\\" + Path.GetFileName(info.Identifier);
    }
  }
}