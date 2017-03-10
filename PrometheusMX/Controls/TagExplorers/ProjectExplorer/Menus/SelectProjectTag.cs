using DevComponents.DotNetBar;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition selectProjectTag;

    private void SetupSelectProjectTag()
    {
      selectProjectTag = new MenuDefinition(referenceManagementGroup, "&Select Project Tag", selectProjectTag_click);
      selectProjectTag.Icon = Resources.arrow_left_green16;
      selectProjectTag.ToolTipText = "Browse for a tag to replace the default Essential Tag reference.";
    }

    private void selectProjectTag_click(MultiSourceTreeNode node, NodeInfo info)
    {
      MessageBoxEx.Show("Not yet implemented.");
    }
  }
}