using System.IO;
using Core.Rendering;
using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition previewTag;

    private void SetupPreviewTag()
    {
      previewTag = new MenuDefinition(viewEditGroup, "&Preview Tag", previewTag_click);
      previewTag.Priority = -10;
      previewTag.ToolTipText = "Loads the tag into the viewport so that it can be previewed.";
      previewTag.Icon = Resources.cube_molecule16;
      previewTag.MenuItemTest = previewTest;
    }

    private bool previewTest(MultiSourceTreeNode node, NodeInfo info)
    {
      // Check to see if the tag is previewable and isn't already open.
      if (currentGame.TypeTable.Previewable(Path.GetExtension(info.Identifier).TrimStart('.')))
      {
        TagPath path = new TagPath(info.Identifier, currentGame.GameID, TagLocation.Archive);
        return !RenderCore.ContainsScene(path.ToPath());
      }
      return false;
    }

    private void previewTag_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (PreviewTag != null)
      {
        PreviewTag(this,
                   new OpenTagEventArgs(new TagPath(node.InfoEntries[0].Identifier,
                                                    currentGame.GameID,
                                                    TagLocation.Archive)));
      }
    }
  }
}