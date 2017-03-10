using Interfaces.Pool;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition copyFromGameArchive;

    private void SetupCopyFromGameArchive()
    {
      copyFromGameArchive = new MenuDefinition(
        referenceManagementGroup, "&Copy from Game Archive", extractFromGameArchive);
      copyFromGameArchive.ToolTipText = "Attempts to replace the missing file with a matching tag in the Game Archive.";
      copyFromGameArchive.Icon = Resources.document_add16;
    }

    private void extractFromGameArchive(MultiSourceTreeNode node, NodeInfo info)
    {
      TagPath path = new TagPath(info.Identifier, projectManager.GameID, TagLocation.Archive);
      AddGameTagToProject(path);
    }
  }
}