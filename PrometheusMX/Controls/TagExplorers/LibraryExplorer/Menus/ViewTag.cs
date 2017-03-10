using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition viewTag;

    private void SetupViewTag()
    {
      viewTag = new MenuDefinition(viewEditGroup, "&View Tag", viewTagInTagEditor_click);
      viewTag.DynamicTooltipCallback = delegate
      {
        return "Opens the tag in the Tag Editor." + GetReadOnlyFooter();
      };
      viewTag.Icon = Resources.document_view16;
      viewTag.BeginGroup = true;
      viewTag.MenuItemTest = documentOpenedTest;
    }

    private void viewTagInTagEditor_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (ViewTaginTagEditor != null)
        ViewTaginTagEditor(this, new OpenTagEventArgs(new TagPath(node.InfoEntries[0].Identifier, currentGame.GameID, TagLocation.Archive)));
    }
  }
}