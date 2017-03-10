using Interfaces.Project;
using DevComponents.DotNetBar;
using System.IO;
using System.Text;
using System.Drawing;
using Interfaces.Games;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class GlobalTemplateTagNodeType : ProjectTemplateTagNodeType
  {
    public GlobalTemplateTagNodeType() : base("globaltemplatetag", 2, 1, false) { ; }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;
      foreach (TemplateTag tag in source.ProjectManager.Project.Template.TagSet)
        if (tag.DefaultFile + "." + tag.FileType == identifier)
          return tag.Name;
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
      sb.Append("<span padding=\"0,4,2,0\"><b>Source:</b></span><img src=\"global::Prometheus.Properties.Resources.joystick16\" /><span padding=\"4,0,2,0\">");
      sb.Append(source.GameDefinition.Name + " " + source.GameDefinition.Platform);
      sb.Append("</span><br/>");

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