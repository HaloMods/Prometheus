using System;
using Core.Project;
using DevComponents.DotNetBar;
using System.IO;
using System.Text;
using System.Drawing;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class ProjectTemplateTagNodeType : NodeType
  {
    public ProjectTemplateTagNodeType() : this("projecttemplatetag", 2, 1, false) { ; }

    protected ProjectTemplateTagNodeType(string name, int sortingPriority, int typePriority, bool displayCheckbox)
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
      return new NodeInfo(ParentSource.GetNodeType<EssentialTagsRoot>(), "Essential Tags");
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
      if (info.Tag != null)
        if (info.Tag is string)
          return ParentSource.Name + "|" + "Properties\\Essential Tags\\" + info.Tag;
      throw new Exception("Tag did not contain the template element name.");
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;
      ProjectTag[] tags = source.TemplateTags.GetTemplateList();
      for (int x = 0; x < tags.Length; x++)
        if (tags[x].Path == identifier)
          return tags[x].TemplateElement;
      return "Invalid Template element!";
    }

    public override SuperTooltipInfo GetTooltip(NodeInfo info)
    {
      // Get the modified date for the specified file.
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;

      string filename = Path.GetFileName(info.Identifier);
      string baseFilename = Path.GetFileNameWithoutExtension(info.Identifier);
      string fileExtension = Path.GetExtension(info.Identifier).TrimStart('.');

      string nodeName = GetNodeName(info.Identifier);

      StringBuilder sb = new StringBuilder();
      sb.Append("<span padding=\"0,4,2,0\"><b>Source:</b></span><img src=\"global::Prometheus.Properties.Resources.application16\" /><span padding=\"4,0,2,0\">Project</span>");
      sb.Append("<br/>");

      sb.Append("<b>Name: </b>");
      sb.Append(baseFilename);
      sb.Append("<br/>");

      sb.Append("<b>Type: </b>");
      sb.Append(fileExtension);

      return new SuperTooltipInfo(
        nodeName, "", sb.ToString(), null, null, eTooltipColor.System, true,
        false, new Size(0, 0));
    }
  }
}