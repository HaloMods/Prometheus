using Interfaces.Pool;
using Prometheus.Properties;
using Core.Project;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition browseRecycleBin;

    private string GetRecycleBinDocumentTitle()
    {
      ProjectFile project = Core.Prometheus.Instance.ProjectManager.Project;
      return "Recycle Bin (" + project.MapName + ")";
    }

    private void SetupBrowseRecycleBin()
    {
      browseRecycleBin = new MenuDefinition(
        recycleBinGroup, "&Browse Recycle Bin", browseRecycleBin_Click);
      browseRecycleBin.ToolTipText = "Opens the Recycle Bin to allow browsing and restoration of deleted files and folders.";
      browseRecycleBin.Icon = Resources.view16;
      browseRecycleBin.MenuItemTest = RecycleBinContentsCheck;
      browseRecycleBin.MenuItemTest += RecycleBinDocumentNotOpenTest;
      browseRecycleBin.BeginGroup = true;
    }

    private bool RecycleBinDocumentNotOpenTest(MultiSourceTreeNode node, NodeInfo info)
    {
      return !Core.Prometheus.Instance.DocumentManager.DocumentExists(GetRecycleBinDocumentTitle());
    }

    private bool RecycleBinContentsCheck(MultiSourceTreeNode node, NodeInfo info)
    {
      return Core.Prometheus.Instance.ProjectManager.Project.RecycleBin.ContainsFiles();
    }

    private void browseRecycleBin_Click(MultiSourceTreeNode node, NodeInfo info)
    {
      ProjectFile project = Core.Prometheus.Instance.ProjectManager.Project;
      string title = GetRecycleBinDocumentTitle();
      if (!Core.Prometheus.Instance.DocumentManager.DocumentExists(title))
      {
        // Create an instance of the browser control.
        RecycleBinBrowser browser = new RecycleBinBrowser();
        browser.Initialize(project.RecycleBin);
        browser.DocumentTitle = title;
        
        // Open the control in the document manager.
        Core.Prometheus.Instance.DocumentManager.OpenDocument(browser);
      }
    }
  }
}