using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition viewScript;

    private void SetupViewScript()
    {
      viewScript = new MenuDefinition(viewEditGroup, "&View Script", viewScript_click);
      viewScript.DynamicTooltipCallback = delegate
      {
        return "Opens the script in the Script Editor." + GetReadOnlyFooter();
      };
      viewScript.Icon = Resources.document_view16;
      viewScript.BeginGroup = true;
      viewScript.MenuItemTest = documentOpenedTest;
    }

    private void viewScript_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (ViewScript != null)
        ViewScript(this, new OpenTagEventArgs(new TagPath(info.Identifier, currentGame.GameID, TagLocation.Archive)));
    }
  }
}