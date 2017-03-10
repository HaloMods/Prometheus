using System;
using System.Drawing;
using System.Windows.Forms;
using Core.Project;
using DevComponents.DotNetBar;
using Interfaces.Games;
using Interfaces.Pool;
using Prometheus.Controls.TagExplorers.Project;
using Prometheus.Dialogs;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer : UserControl
  {
    private ProjectExplorerDisplayMode displayMode = ProjectExplorerDisplayMode.AllFilesInProjectFolder;
    private TagView view = TagView.Tags;
    private ProjectManager projectManager = null;
    private GameDefinition game;

    public event EventHandler<OpenTagEventArgs> CopyToProject;
    public event OpenTagHandler PreviewTag;
    public event OpenTagHandler TagAdded;

    public TagView View
    {
      get { return view; }
      set
      {
        view = value;
        if (projectManager != null)
          Initialize(projectManager);
      }
    }

    public ProjectExplorerDisplayMode DisplayMode
    {
      get { return displayMode; }
      set
      {
        displayMode = value;
        if (projectManager != null) 
          Initialize(projectManager);
      }
    }

    public event EventHandler<OpenTagEventArgs> EditTag;

    public ProjectExplorer()
    {
      InitializeComponent();
      treeView.SortMode = SortMode.Alphabetical;
      SetupMenus();
    }

    public void Initialize(ProjectManager projectManager)
    {
      this.projectManager = projectManager;
      this.projectManager.Project.TemplateReverting += Project_TemplateReverting;
      treeView.Reset();
            
      // Initialize the NodeHierarchies.
      treeView.TreeEmptyText = "";
      treeView.TreeEmptyIcon = null;

      NodeHierarchy main = new NodeHierarchy(projectManager.Project.MapName, Resources.cabinet16);
      main.NodeSources.Add(CreateProjectNodeSource());

      // Add the node hierarchies to the TreeView.
      treeView.AddNodeHierarchy(main);

      // And... this one shouldn't need any explaination...
      treeView.Initialize();

      treeView.LabelEdit = true;
    }

    void Project_TemplateReverting(object sender, ForceTemplateRevertArgs e)
    {
      string prompt = String.Format(
        "Removing this tag from the project will forcibly revert {0} to its default tag.  Remove {1} and revert {0}?",
        e.TemplateName, e.TemplatePath);
      if (MessageBoxEx.Show(prompt, "Revert Tag", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        e.Cancel = true;
    }

    private NodeSource CreateProjectNodeSource()
    {
      DefaultState defaultState = new DefaultState(Resources.application16);
      ProjectNodeSource source = new ProjectNodeSource("Project", Core.Prometheus.Instance.DocumentManager,
        Core.Prometheus.Instance.ProjectManager, defaultState);
      game = source.GameDefinition;

      AddMenus(source);
      return source;
    }

    /// <summary>
    /// Add the specified Archive tag to the currently active project.
    /// </summary>
    private static void AddGameTagToProject(TagPath path)
    {
      GameDefinition game = Core.Prometheus.Instance.GetGameDefinitionByGameID(
        Core.Prometheus.Instance.ProjectManager.GameID);
      Type tagType = game.TypeTable.LocateEntryByName(
        path.Extension.TrimStart('.')).TagType;
      PrometheusGUI.AddTagToProject(path, tagType);
    }

    private void esplitMain_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitMain.Expanded)
        esplitMain.Cursor = Cursors.PanNorth;
      else
        esplitMain.Cursor = Cursors.PanSouth;
    }

    private void ipOperations_Resize(object sender, EventArgs e)
    {
      icViewAdjustment.MinimumSize = new Size(ipOperations.Width - 38, 0);
    }
  }

  public enum ProjectExplorerDisplayMode
  {
    ProjectFiles,
    AllFilesInProjectFolder
  }
}
