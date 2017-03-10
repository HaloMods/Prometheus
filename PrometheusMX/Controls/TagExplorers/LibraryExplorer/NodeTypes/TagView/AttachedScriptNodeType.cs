namespace Prometheus.Controls.TagExplorers.Library
{
  public class AttachedScriptNodeType : NodeType
  {
    public AttachedScriptNodeType() : base("attachedscript", 2, 1, false) { ; }

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
      NodeInfo newInfo = new NodeInfo(ParentSource.GetNodeType<ScenarioFileNodeType>(),
        info.Identifier.Remove(info.Identifier.IndexOf('|')));
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
      return identifier.Substring(identifier.IndexOf('|')+1);
    }
  }
}