using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition removeFolder;

    private void SetupRemoveFolder()
    {
      removeFolder = new MenuDefinition(referenceManagementGroup, "&Remove from Project", removeFolderFromProject);
      removeFolder.Icon = Resources.undo16;
      removeFolder.ToolTipText = "Removes the folder and all tags that it contains from the Project References.";
    }

    private void removeFolderFromProject(MultiSourceTreeNode node, NodeInfo info)
    {
      // Get a list of all files in this folder.
      projectManager.Project.RemoveFolderReference(info.Identifier);
    }
  }
}