using System;
using System.Collections.Generic;
using Interfaces.Project;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class EssentialTagsRoot : NodeType
  {
    public EssentialTagsRoot()
      : base("essentialtags", 10, Int32.MaxValue, false) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;
      List<NodeInfo> children = new List<NodeInfo>();
      // Get a list of essential tags from the game definition.
      foreach (TemplateTag tag in source.ProjectManager.Project.Template.TagSet)
      {
        string element = tag.Name;
        if (source.TemplateTags.ContainsTemplateElement(element))
        {
          NodeInfo childInfo = new NodeInfo(source.GetNodeType<ProjectTemplateTagNodeType>(),
                                            source.TemplateTags[element].Path);
          childInfo.Tag = element;
          children.Add(childInfo);
        }
        else
        {
          NodeInfo childInfo = new NodeInfo(source.GetNodeType<GlobalTemplateTagNodeType>(),
                                            tag.DefaultFile + "." + tag.FileType);
          childInfo.Tag = element;
          children.Add(childInfo);
        }
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      return new NodeInfo(ParentSource.GetNodeType<PropertiesRootNodeType>(), "Properties");
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
      return ParentSource.Name + "|" + "Properties\\Essential Tags";
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      return "Essential Tags";
    }
  }
}