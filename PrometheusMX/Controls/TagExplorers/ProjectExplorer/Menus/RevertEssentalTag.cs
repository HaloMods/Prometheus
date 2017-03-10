using Interfaces.Project;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition revertEssentialTag;

    private void SetupRevertEssentialTag()
    {
      revertEssentialTag = new MenuDefinition(referenceManagementGroup, "&Revert to Default", revertToDefault);
      revertEssentialTag.ToolTipText = "Removes the local reference to this template element and reverts to the default file located within the Game Archive.";
      revertEssentialTag.Icon = Resources.document_add16;
      revertEssentialTag.MenuItemTest = templateElementHasDefault;
    }

    private bool templateElementHasDefault(MultiSourceTreeNode node, NodeInfo info)
    {
      string element = info.Tag as string;
      if (element == null)
        return false;

      foreach (TemplateTag tag in projectManager.Project.Template.TagSet)
        if (tag.Name == element)
          if (tag.DefaultFile != "" && tag.DefaultFile != null)
            return true;

      return false;
    }

    private void revertToDefault(MultiSourceTreeNode node, NodeInfo info)
    {
      projectManager.Project.Templates.RemoveByTagPath(info.Identifier);
    }
  }
}