using Core.Project;
using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition addTagToProject;

    private void SetupAddToProject()
    {
      addTagToProject = new MenuDefinition(projectGroup, "&Add Tag to Project", addTagToProject_click);
      addTagToProject.DynamicTooltipCallback = delegate
      {
        if (Core.Prometheus.Instance.ProjectManager.ProjectLoaded)
          return "Adds the tag to the currently active<br/>project - <b>" +
            Core.Prometheus.Instance.ProjectManager.Project.MapName + ".</b>";
        else
          return ""; // This shouldn't ever be visible unless a project is loaded.
      };
      addTagToProject.Icon = Resources.document_add16;
      addTagToProject.MenuItemTest = addToProjectTest;
    }

    /// <summary>
    /// Checks to see if the specified node can be added to the project (if one exists.)
    /// </summary>
    private bool addToProjectTest(MultiSourceTreeNode node, NodeInfo info)
    {
      // Is a project loaded?      
      ProjectManager pm = Core.Prometheus.Instance.ProjectManager;
      if (!pm.ProjectLoaded)
        return false;

      // Is it the game that we have selected?
      if (pm.GameID != currentGame.GameID)
        return false;

      // Does the file already exist in the project? (return the opposite)
      return !pm.Project.FileExists(info.Identifier);
    }

    private void addTagToProject_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (AddTagToProject != null)
        AddTagToProject(this, new OpenTagEventArgs(new TagPath(node.InfoEntries[0].Identifier, currentGame.GameID, TagLocation.Archive)));
    }
  }
}