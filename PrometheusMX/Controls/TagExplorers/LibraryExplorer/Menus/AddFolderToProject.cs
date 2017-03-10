using System.Windows.Forms;
using Core.Project;
using DevComponents.DotNetBar;
using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition addFolderToProject;

    private void SetupAddFolderToProject()
    {
      addFolderToProject = new MenuDefinition(projectGroup, "&Add Folder to Project", addFolderToProject_click);
      addFolderToProject.DynamicTooltipCallback = delegate
      {
        if (Core.Prometheus.Instance.ProjectManager.ProjectLoaded)
          return "Adds the folder and all tags that it contains to the currently active<br/>project - <b>" +
            Core.Prometheus.Instance.ProjectManager.Project.MapName + ".</b>";
        else
          return ""; // This shouldn't ever be visible unless a project is loaded.
      };
      addFolderToProject.Icon = Resources.folder_add16;
      addFolderToProject.MenuItemTest = addFolderToProjectTest;
    }

    /// <summary>
    /// Checks to see if the specified node can be added to the project (if one exists.)
    /// </summary>
    private bool addFolderToProjectTest(MultiSourceTreeNode node, NodeInfo info)
    {
      // Is a project loaded?      
      ProjectManager pm = Core.Prometheus.Instance.ProjectManager;
      if (!pm.ProjectLoaded)
        return false;

      // Is it the game that we have selected?
      if (pm.GameID != currentGame.GameID)
        return false;

      return true;
    }

    private void addFolderToProject_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (AddTagToProject == null)
        return;

      try
      {
        string[] files = extractedSource.Library.GetFileList(info.Identifier, "*", true);
        if (files.Length > 50)
        {
          if (MessageBoxEx.Show("ZOMG, a large number of tags will be copied ("
            + files.Length + ") and could take a while.  Do you wish to proceed?",
            "Add Tags to Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            return;
        }
        Cursor = Cursors.WaitCursor;
        Refresh();
        foreach (string file in files)
          if (!Core.Prometheus.Instance.ProjectManager.Project.FileExists(file))
          {
            Cursor = Cursors.WaitCursor;
            AddTagToProject(this, new OpenTagEventArgs(new TagPath(file, currentGame.GameID, TagLocation.Archive)));
          }
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }
  }
}