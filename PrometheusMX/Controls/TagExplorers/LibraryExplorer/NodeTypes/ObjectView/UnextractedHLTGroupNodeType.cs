using System.Collections.Generic;
using System.IO;
using Interfaces.Games;

namespace Prometheus.Controls.TagExplorers.Library
{
  public class UnextractedHLTGroupNodeType : NodeType
  {
    public UnextractedHLTGroupNodeType() : base("unextractedhltgroup", 3, 11, true) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      TagArchiveObjectViewNodeSource source = (TagArchiveObjectViewNodeSource)ParentSource;

      string group = info.Identifier.Trim('[', ']');
      foreach (TypeTableEntry entry in source.Game.TypeTable.GetHighLevelTypes(group))
      {
        // Get a list of the tags that match the HLT supplied inside the brackets.
        string[] files = (source.Library.MissingFilesArchive.GetFileList("", entry.FullName, true));
        foreach (string file in files)
        {
          NodeInfo child = new NodeInfo(ParentSource.GetNodeType<UnextractedHLTNodeType>(), file.Trim('\\'));
          children.Add(child);
        }
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      return new NodeInfo(ParentSource.GetNodeType<UnextractedObjectViewRootNodeType>(), "");
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      TagArchiveObjectViewNodeSource source = (TagArchiveObjectViewNodeSource)ParentSource;

      string group = info.Identifier.Trim('[', ']');
      foreach (TypeTableEntry entry in source.Game.TypeTable.GetHighLevelTypes(group))
        if (source.Library.MissingFilesArchive.FileTypeExists(entry.FullName))
          return true;
      return false;
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
      return Path.GetFileName(identifier).Trim('[', ']');
    }
  }
}
