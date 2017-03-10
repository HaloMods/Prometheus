using System.IO;
using Core.Rendering;
using Interfaces.Pool;
using Prometheus.Controls.TagExplorers.Project;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
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
      if (game.TypeTable.Previewable(Path.GetExtension(info.Identifier).TrimStart('.')))
      {
        TagPath path = new TagPath(info.Identifier, game.GameID, TagLocation.Project);
        return !RenderCore.ContainsScene(path.ToPath());
      }
      return false;
    }

    private void previewTag_click(MultiSourceTreeNode node, NodeInfo info)
    {
      if (PreviewTag != null)
      {
        PreviewTag(this,
                   new OpenTagEventArgs(new TagPath(info.Identifier,
                                                    game.GameID,
                                                    TagLocation.Project)));
      }
    }
  }
}