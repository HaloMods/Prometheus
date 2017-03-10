using Interfaces.Pool;
using Prometheus.Controls.TagExplorers.Project;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    readonly MenuGroup recycleBinGroup = new MenuGroup("Recycle Bin", 0);
    readonly MenuGroup referenceManagementGroup = new MenuGroup("Reference Management", 0);
    readonly MenuGroup viewEditGroup = new MenuGroup("View / Edit", 1);
    readonly MenuGroup debugGroup = new MenuGroup("Debug", -1);

    private void SetupMenus()
    {
      SetupRemoveFolder();
      SetupRemove();
      SetupInclude();
      SetupEdit();
      SetupCopyFromGameArchive();
      SetupPreviewTag();
      SetupRevertEssentialTag();
      SetupEditGlobal();
      SetupSelectProjectTag();
      SetupEmptyRecyleBin();
      SetupBrowseRecycleBin();
#if DEBUG
      SetupDebugInfo();
#endif
    }

    void AddMenus(NodeSource source)
    {
      source.GetNodeType<FolderNodeType>().States[0].AddMenuDefinitions(removeFolder);

      source.GetNodeType<TagNode>().State("missing_reference").AddMenuDefinitions(copyFromGameArchive, remove);
      source.GetNodeType<TagNode>().State("valid_reference").AddMenuDefinitions(remove, edit, previewTag);
      source.GetNodeType<TagNode>().State("unreferenced").AddMenuDefinitions(include);

      source.GetNodeType<ObjectTag>().State("missing_reference").AddMenuDefinitions(copyFromGameArchive, remove);
      source.GetNodeType<ObjectTag>().State("valid_reference").AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ObjectTag>().State("valid_reference").AddDefaultMenuDefinition(edit, remove);

      source.GetNodeType<ModelTag>().State("missing_reference").AddMenuDefinitions(copyFromGameArchive, remove);
      source.GetNodeType<ModelTag>().State("valid_reference").AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ModelTag>().State("valid_reference").AddDefaultMenuDefinition(edit, remove);

      source.GetNodeType<SbspTag>().State("missing_reference").AddMenuDefinitions(copyFromGameArchive, remove);
      source.GetNodeType<SbspTag>().State("valid_reference").AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<SbspTag>().State("valid_reference").AddDefaultMenuDefinition(edit, remove);

      source.GetNodeType<ScenarioTag>().State("missing_reference").AddMenuDefinitions(copyFromGameArchive, remove);
      source.GetNodeType<ScenarioTag>().State("valid_reference").AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ScenarioTag>().State("valid_reference").AddDefaultMenuDefinition(edit, remove);

      source.GetNodeType<ProjectTemplateTagNodeType>().States[0].AddMenuDefinitions(revertEssentialTag, edit);
      source.GetNodeType<GlobalTemplateTagNodeType>().States[0].AddDefaultMenuDefinition(editGlobal, selectProjectTag);

      source.GetNodeType<RecycleBinRootNodeType>().State("recyclebin_not_empty").AddDefaultMenuDefinition(browseRecycleBin, emptyRecycleBin);

#if DEBUG
      source.AddGlobalMenuDefinition(debugInfo);
#endif
    }

    private bool documentOpenedTest(MultiSourceTreeNode node, NodeInfo info)
    {
      TagPath path = new TagPath(info.Identifier, projectManager.GameID, TagLocation.Project);
      return !Core.Prometheus.Instance.DocumentManager.DocumentExists(path.ToPath());
    }
  }
}
