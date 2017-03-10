using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition include;

    private void SetupInclude()
    {
      include = new MenuDefinition(referenceManagementGroup, "&Include in Project", includeInProject);
      include.Icon = Resources.document_add16;
      include.ToolTipText = "Adds the tag to the Project References.<br/><br/>Only referenced tags are included in the map file when you compile your project.";
    }

    private void includeInProject(MultiSourceTreeNode node, NodeInfo info)
    {
      projectManager.Project.AddTagReference(info.Identifier);
    }
  }
}