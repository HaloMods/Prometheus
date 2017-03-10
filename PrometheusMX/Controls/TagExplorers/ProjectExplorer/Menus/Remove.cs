using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition remove;

    private void SetupRemove()
    {
      remove = new MenuDefinition(referenceManagementGroup, "&Remove from Project", removeFromProject);
      remove.Icon = Resources.undo16;
      remove.ToolTipText = "Removes the tag from the Project References.<br/><br/><b>Note:</b> The tag will not be deleted from the project folder, and will still show up as an unreferenced file.<br/><br/>If you wish to re-add it to the project, simply right click the file and choose <b>Include in Project</b>";
    }

    private void removeFromProject(MultiSourceTreeNode node, NodeInfo info)
    {
      projectManager.Project.RemoveTagReference(info.Identifier);
    }
  }
}