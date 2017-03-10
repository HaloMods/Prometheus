using System;
using System.Collections.Generic;
using System.IO;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class ScenarioFileNodeType : NodeType
  {
    public ScenarioFileNodeType() : base("scenariofile", 10, 1, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveNodeSource source = (TagArchiveNodeSource)ParentSource;

      TagPath tagPath = new TagPath(info.Identifier, source.Game.GameID, TagLocation.Archive);
      TagFile file = Core.Prometheus.Instance.Pool.GetTagFile(tagPath);
      foreach (string attachment in file.Attachments)
      {
        NodeInfo attachmentInfo = new NodeInfo(ParentSource.GetNodeType<AttachedScriptNodeType>(),
          info.Identifier + "|" + attachment);
        children.Add(attachmentInfo);
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
      TagPath path = new TagPath(info.Identifier, source.Game.GameID, TagLocation.Archive);
      TagFile file = Core.Prometheus.Instance.Pool.GetTagFile(path);
      return file.Attachments.Length > 0;
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
