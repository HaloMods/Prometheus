using Interfaces.Pool;
using Prometheus.Controls.TagExplorers.Library;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuGroup viewEditGroup = new MenuGroup("View / Edit", 0);
    private MenuGroup projectGroup = new MenuGroup("Project", -1);
    private MenuGroup debugGroup = new MenuGroup("Debug", -2);
    private MenuGroup information = new MenuGroup("Information", 0);

    private void SetupMenus()
    {
      // Extracted tag menus.
      SetupPreviewTag();
      SetupViewTag();
      SetupViewScript();
      SetupAddToProject();
      SetupAddFolderToProject();
      SetupReplaceInProject();
#if DEBUG
      SetupDebugInfo();
#endif      
      // Unextracted tag menus.
      SetupViewTagInformation();
    }

    private void AddTagViewExtractedMenus(NodeSource source)
    {
      source.GetNodeType<FileNodeType>().States[0].AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<FileNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<ObjectFileNodeType>().States[0].AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ObjectFileNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<ModelFileNodeType>().States[0].AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ModelFileNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<SbspFileNodeType>().States[0].AddDefaultMenuDefinition(viewTag);
      source.GetNodeType<SbspFileNodeType>().States[0].AddDefaultMenuDefinition(
        previewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<ScenarioFileNodeType>().States[0].AddDefaultMenuDefinition(previewTag);
      source.GetNodeType<ScenarioFileNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<FolderNodeType>().States[0].AddMenuDefinitions(addFolderToProject);

      source.GetNodeType<AttachedScriptNodeType>().States[0].AddDefaultMenuDefinition(viewScript);

      AddDebugMenu(source);

      // TODO: Create remaining menu items.
      // Edit Tag for Project
      // Check &Dependencies
    }

    private void AddTagViewUnextractedMenus(NodeSource source)
    {
      source.GetNodeType<UnextractedFileNodeType>().States[0].AddMenuDefinitions(viewTagInformation);
      AddDebugMenu(source);
    }

    private void AddObjectViewExtractedMenus(NodeSource source)
    {
      source.GetNodeType<HLTNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, previewTag, addTagToProject, replaceTagInProject);

      source.GetNodeType<TagNodeType>().States[0].AddDefaultMenuDefinition(
        viewTag, previewTag, addTagToProject, replaceTagInProject);

      AddDebugMenu(source);
    }

    private void AddObjectViewUnextractedMenus(NodeSource source)
    {
      source.GetNodeType<UnextractedHLTNodeType>().States[0].AddMenuDefinitions(viewTagInformation);
      AddDebugMenu(source);
    }

    private void AddDebugMenu(NodeSource source)
    {
#if DEBUG
      source.AddGlobalMenuDefinition(debugInfo);
#endif
    }

    private string GetReadOnlyFooter()
    {
      return "<br/><br/><b>Note:</b> This file exists in the <u>" +
        currentGame.LongName + "</u> Global Archive,<br/>therefore changes cannot be saved.";
    }

    private bool documentOpenedTest(MultiSourceTreeNode node, NodeInfo info)
    {
      TagPath path = new TagPath(info.Identifier, currentGame.GameID, TagLocation.Archive);
      return !Core.Prometheus.Instance.DocumentManager.DocumentExists(path.ToPath());
    }

    //private void editTagForProject_click(MultiSourceTreeNode node, NodeInfo info)
    //{
    //  if (EditTagForProject != null)
    //    EditTagForProject(this, new OpenTagEventArgs(new TagPath(node.InfoEntries[0].FullPath, currentGame.GameID, TagLocation.Archive)));
    //}
  }
}