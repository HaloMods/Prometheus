using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition emptyRecycleBin;

    private void SetupEmptyRecyleBin()
    {
      emptyRecycleBin = new MenuDefinition(
        recycleBinGroup, "&Empty Recycle Bin", emptyRecycleBin_click);
      emptyRecycleBin.ToolTipText = "Permenantly deletes all files from the recycle bin.<br/><br/><img src=\"global::Prometheus.Properties.Resources.warning16\" /> <b>This action is not undoable.</b>";
      emptyRecycleBin.Icon = Resources.garbage16;
      emptyRecycleBin.MenuItemTest = RecycleBinContentsCheck;
    }

    private void emptyRecycleBin_click(MultiSourceTreeNode node, NodeInfo info)
    {
      projectManager.Project.RecycleBin.Empty();
      
      // TODO: Figure out how to play the system-defined recycle bin empty sound.
      // Or, perhaps play a custom Prometheus sound for this action.
      System.Media.SystemSounds.Exclamation.Play();
    }
  }
}