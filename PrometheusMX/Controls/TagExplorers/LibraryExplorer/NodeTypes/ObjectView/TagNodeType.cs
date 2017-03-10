using System;
using System.Collections.Generic;
using System.IO;
using Core.Pool;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class TagNodeType : NodeType
  {
    public TagNodeType() : base("tag", 2, 1, false) { ; }

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
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveObjectViewNodeSource source = (TagArchiveObjectViewNodeSource)ParentSource;

      // Get a list of dependencies of the tag that matches the specified path.
      Pool pool = Core.Prometheus.Instance.Pool;
      string tagName = Path.GetExtension(info.Identifier).Trim('.');
      Type tagType = source.Game.TypeTable.LocateEntryByName(tagName).TagType;

      TagPath poolPath = new TagPath(info.Identifier, source.Game.GameID, TagLocation.Archive);
      string[] references = new string[0];
      try
      {
        references = pool.GetTagReferences(poolPath.ToPath(), tagType);
      }
      catch
      {
        //NodeInfo errorInfo = new NodeInfo("", "error", this);
        //MultiSourceTreeNode node = CreateNode("Error deserializing tag.", errorInfo);
        //children.Add(node);
      }

      foreach (string reference in references)
      {
        if (reference == "") continue;
        if (!source.Library.FileExists(reference)) continue;
        NodeInfo tagInfo = new NodeInfo(source.GetNodeType<TagNodeType>(), reference);
        children.Add(tagInfo);
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      return null;
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      // For now, we are assuming that the tag has children.
      // TODO: store a bit in the file table entry upon tag extraction that
      // specifies if a tag has children.
      return true;
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public override string GetTreePath(NodeInfo info)
    {
      if (info.Identifier.StartsWith("["))
        return Name + "|" + info.Identifier.Trim('[', ']');

      string groupName = ((TagArchiveObjectViewNodeSource)ParentSource).GetHLTGroupFromFilename(info.Identifier);
      if (groupName == "") return "";
      return Name + "|" + groupName + "\\" + Path.GetFileName(info.Identifier);
    }
  }
}