using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition edit;

    private void SetupEdit()
    {
      edit = new MenuDefinition(viewEditGroup, "&Edit Tag", editTag);
      edit.Icon = Resources.document_edit16;
      edit.BeginGroup = true;
      edit.ToolTipText = "Opens the tag in the Tag Editor for editing.";
      edit.MenuItemTest = documentOpenedTest;
    }

    private void editTag(MultiSourceTreeNode node, NodeInfo info)
    {
      if (EditTag != null)
        EditTag(this, new OpenTagEventArgs(new TagPath(info.Identifier, projectManager.GameID, TagLocation.Project)));
    }
  }
}