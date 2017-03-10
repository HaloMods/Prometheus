using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition editGlobal;

    private void SetupEditGlobal()
    {
      editGlobal = new MenuDefinition(viewEditGroup, "&Edit Tag", editGlobalTag);
      editGlobal.Icon = Resources.document_edit16;
      editGlobal.ToolTipText = "Opens the tag in the Tag Editor for editing.<br/><br/><b>Note:</b> This tag exists in the Game Archive and, if saved, will be copied to the local project folder and added to the project references<br/><br/>The default Essential Tag will be replaced with the local copy.";
      editGlobal.MenuItemTest = documentOpenedTest;
    }

    private void editGlobalTag(MultiSourceTreeNode node, NodeInfo info)
    {
      if (EditTag != null)
        EditTag(this, new OpenTagEventArgs(new TagPath(info.Identifier, projectManager.GameID, TagLocation.Archive)));
    }
  }
}