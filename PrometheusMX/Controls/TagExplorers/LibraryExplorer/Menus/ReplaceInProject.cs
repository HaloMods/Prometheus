using Core.Project;
using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition replaceTagInProject;

    private void SetupReplaceInProject()
    {
      replaceTagInProject = new MenuDefinition(projectGroup, "&Replace Tag in Project", replaceTagInProject_click);
      replaceTagInProject.DynamicTooltipCallback = delegate
      {
        if (Core.Prometheus.Instance.ProjectManager.ProjectLoaded)
          return "Replaces an existing tag in the currently active<br/>project - <b>" +
            Core.Prometheus.Instance.ProjectManager.Project.MapName + ".</b>";
        else
          return ""; // This shouldn't ever be visible unless a project is loaded.
      };
      replaceTagInProject.Icon = Resources.document_add16;
      replaceTagInProject.MenuItemTest = replaceTagInProjectTest;
    }

    /// <summary>
    /// Checks to see if the specified node can be added to the project (if one exists.)
    /// </summary>
    private bool replaceTagInProjectTest(MultiSourceTreeNode node, NodeInfo info)
    {
      // Is a project loaded?      
      ProjectManager pm = Core.Prometheus.Instance.ProjectManager;
      if (!pm.ProjectLoaded)
        return false;

      // Is it the game that we have selected?
      if (pm.GameID != currentGame.GameID)
        return false;

      // Does the file already exist in the project?
      return pm.Project.FileExists(info.Identifier);
    }

    private void replaceTagInProject_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (AddTagToProject != null)
        AddTagToProject(this, new OpenTagEventArgs(new TagPath(node.InfoEntries[0].Identifier, currentGame.GameID, TagLocation.Archive)));
    }
  }
}