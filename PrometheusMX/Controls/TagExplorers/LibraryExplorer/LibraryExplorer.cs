using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Interfaces.Games;
using Interfaces.Settings;
using Prometheus.Properties;
using Prometheus.ThirdParty.Controls;

namespace Prometheus.Controls.TagExplorers
{
  /// <summary>
  /// Tree-based control that allows exploration of pre-built game archives.
  /// Also handles decompilation of original assets into their respective game archives.
  /// </summary>
  public partial class LibraryExplorer : UserControl, IPersistable
  {
    private LibraryDisplayMode displayMode;
    private GameDefinition currentGame = null;
    private TagView view = TagView.Tags;
    private CurtainForm curtain = new CurtainForm();
    private TagArchiveNodeSource extractedSource;
    private bool silentGameSelect = false;

    #region Properties
    public TagView View
    {
      get { return view; }
      set
      {
        view = value;
        if (view == TagView.Tags) btnTagView.Checked = true;
        if (view == TagView.Objects) btnObjectView.Checked = true;
        if (currentGame != null) Initialize(currentGame);
      }
    }

    public LibraryDisplayMode DisplayMode
    {
      get { return displayMode; }
      set
      {
        displayMode = value;
        if (currentGame != null) Initialize(currentGame);
      }
    }

    [PersistableOption("FadeInOnMouseOut", "VisualOptions", true, OptionsFile.User)]
    public bool FadeInOnMouseOut
    {
      get { return treeView.FadeOnMouseOut; }
      set { treeView.FadeOnMouseOut = value; }
    }
    #endregion

    #region Events
    public event OpenTagHandler PreviewTag;
    public event OpenTagHandler EditTagForProject;
    public event OpenTagHandler AddTagToProject;
    public event OpenTagHandler ViewTaginTagEditor;
    public event OpenTagHandler ViewScript;
    #endregion

    #region Constructor
    public LibraryExplorer()
    {
      InitializeComponent();
      InitializeExtractionComponents();
      CustomComponentInitialization();
      SetupMenus();

      // Load options.
      ((IPersistable)this).Load();

      // This is a warning for design-time only; remove it from runtime.
      CHECKYOURSELF.Dispose();
    }

    private void CustomComponentInitialization()
    {
      // Setup Library combo box based on the available GameDefinitions
      ArrayList systemList = new ArrayList();
      foreach (GameDefinition def in Core.Prometheus.Instance.Games)
        if (!systemList.Contains(def.Platform))
          systemList.Add(def.Platform);
      systemList.Sort();
      cbiSystemList.Items.AddRange(systemList.ToArray());

      // Setup Filter combo box based on built-in and user-saved profiles.
      cbiFilter.Items.AddRange(new string[] { "No Filter", "", "Art", "Audio", "Effects", "Objects", "Shaders", "Textures" });

      // Le TreeView settings.
      treeView.SortMode = SortMode.Alphabetical;
      treeView.AfterCheck += treeView_AfterCheck;
      SetDefaultTreeText();

      // Setup initial state.
      DisplayMode = LibraryDisplayMode.Split;
      View = TagView.Tags;
      cbiFilter.SelectedIndex = 0;
    }
    #endregion

    protected void Initialize(GameDefinition game)
    {
      Cursor previousCursor = Cursor;
      try
      {
        if (!silentGameSelect)
        {
          Cursor = Cursors.WaitCursor;
          Refresh();
          curtain.Show(this);
        }

        currentGame = game;
        treeView.Reset();
        extractionQueue.Clear();
        
        UpdateExtractionButton();
        
        if (game.GlobalTagLibrary == null)
        {
          treeView.TreeEmptyText = "The Tag Library for " + game.Name + " was not found.";
          treeView.TreeEmptyTextColor = Color.Red;
          treeView.TreeEmptyIcon = Resources.error64;
          treeView.Reset();
        }
        else
        {
          // Figure out which method we will use to create the node sources, based on our current View.
          if (View == TagView.Tags)
          {
            // Initialize the NodeHierarchies.
            treeView.TreeEmptyText = "";
            treeView.TreeEmptyIcon = null;

            NodeHierarchy main = new NodeHierarchy(game.Name + " Tag Library", Resources.cabinet16);
            if (DisplayMode == LibraryDisplayMode.Split)
            {
              main.NodeSources.Add(SetupExtractedSource());

              NodeHierarchy unextracted = new NodeHierarchy("Unextracted Tags", Resources.cd16);
              NodeSource unextractedSource = SetupUnextractedSource();
              if (unextractedSource.ContainsNodes)
                unextracted.NodeSources.Add(unextractedSource);

              treeView.AddNodeHierarchy(main);
              treeView.AddNodeHierarchy(unextracted);
            }
            else
            {
              NodeSource mergedSource = SetupMergedSource();
              if (mergedSource.ContainsNodes)
                main.NodeSources.Add(mergedSource);
              treeView.AddNodeHierarchy(main);
            }
          }
          else
          {
            // Initialize the NodeHierarchies.
            treeView.TreeEmptyText = "";
            treeView.TreeEmptyIcon = null;

            NodeHierarchy main = new NodeHierarchy(game.Name + " Tag Library", Resources.cabinet16);
            if (DisplayMode == LibraryDisplayMode.Split)
            {
              main.NodeSources.Add(SetupExtractedObjectViewSource());
              NodeHierarchy unextracted = new NodeHierarchy("Unextracted Objects", Resources.cd16);
              unextracted.NodeSources.Add(SetupUnextractedObjectViewSource());
              treeView.AddNodeHierarchy(main);
              treeView.AddNodeHierarchy(unextracted);
            }
            else
            {
              main.NodeSources.Add(SetupExtractedObjectViewSource());
              main.NodeSources.Add(SetupUnextractedObjectViewSource());
              treeView.AddNodeHierarchy(main);
            }
          }
          treeView.Initialize();
        }

        treeView.SelectedNode = null;
      }
      finally
      {
        if (!silentGameSelect)
        {
          curtain.Fade();
          Cursor = previousCursor;
        }
      }
    }

    private NodeSource SetupMergedSource()
    {
      // This is majorly inefficient, but I'm lazy... :D
      bool unextractedTagsExist = SetupUnextractedSource().ContainsNodes;

      DefaultState defaultState = new DefaultState(Resources.cabinet16);
      extractedSource = new TagArchiveNodeSource("Merged", currentGame, Core.Prometheus.Instance.DocumentManager, unextractedTagsExist ? DisplayItems.AllItems : DisplayItems.AllExtractedItems, defaultState);
      AddTagViewExtractedMenus(extractedSource);
      if (unextractedTagsExist)
        AddTagViewUnextractedMenus(extractedSource);
      return extractedSource;
    }
   
    private NodeSource SetupExtractedSource()
    {
      DefaultState defaultState = new DefaultState(Resources.cabinet16);
      extractedSource = new TagArchiveNodeSource("Extracted", currentGame,
        Core.Prometheus.Instance.DocumentManager, DisplayItems.AllExtractedItems, defaultState);
      AddTagViewExtractedMenus(extractedSource);
      return extractedSource;
    }

    private NodeSource SetupUnextractedSource()
    {
      DefaultState defaultState = new DefaultState(Resources.cd16);
      TagArchiveNodeSource source = new TagArchiveNodeSource("Unextracted", currentGame, Core.Prometheus.Instance.DocumentManager, DisplayItems.AllUnextractedItems, defaultState);
      AddTagViewUnextractedMenus(source);
      return source;
    }

    private NodeSource SetupExtractedObjectViewSource()
    {
      DefaultState defaultState = new DefaultState(Resources.cabinet16);
      TagArchiveObjectViewNodeSource source = new TagArchiveObjectViewNodeSource("ObjectViewExtracted", currentGame, Core.Prometheus.Instance.DocumentManager, DisplayItems.AllExtractedItems, defaultState);
      source.LoadDependencies = true;
      AddObjectViewExtractedMenus(source);
      return source;
    }

    private NodeSource SetupUnextractedObjectViewSource()
    {
      DefaultState defaultState = new DefaultState(Resources.cd16);
      TagArchiveObjectViewNodeSource source = new TagArchiveObjectViewNodeSource("ObjectViewUnextracted", currentGame, Core.Prometheus.Instance.DocumentManager, DisplayItems.AllUnextractedItems, defaultState);
      source.LoadDependencies = false;
      AddObjectViewUnextractedMenus(source);
      return source;
    }

    private void SetDefaultTreeText()
    {
      treeView.TreeEmptyText = "Choose a game library from the above list.";
      treeView.TreeEmptyTextColor = Color.FromArgb(75, Color.Black);
      treeView.TreeEmptyTextFont = new Font("Arial", 10f);
      treeView.TreeEmptyIcon = Resources.forward64;
      treeView.TreeEmptyAlpha = 150;
    }

    private void esplitMain_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitMain.Expanded)
        esplitMain.Cursor = Cursors.PanNorth;
      else
        esplitMain.Cursor = Cursors.PanSouth;
    }

    #region Library Panel

    private void esplitLibrary_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitLibrary.Expanded) // Will collapse after this event.
        esplitOperations.Expanded = false;
    }

    private void cbiSystemList_Click(object sender, EventArgs e)
    {
      if (cbiSystemList.SelectedIndex < 0)
        return;

      cbiGameList.Items.Clear();

      // Add the available games.
      ArrayList gameList = new ArrayList();
      foreach (GameDefinition game in Core.Prometheus.Instance.Games)
        if (game.Platform == (Platform)cbiSystemList.SelectedItem)
          gameList.Add(new GameDefinitionWrapper(game));
      gameList.Sort(new GameDefinitionWrapperComparer());
      cbiGameList.Items.AddRange(gameList.ToArray());

      cbiGameList.Enabled = true;
      cbiGameList.Refresh();

      if (!silentGameSelect)
      {
        // If there is only one option, auto-select it.
        if (cbiGameList.Items.Count == 1)
          cbiGameList.SelectedIndex = 0;
        else if (cbiGameList.Items.Count > 0)
        {
          cbiGameList.Focus();
          cbiGameList.ComboBoxEx.DroppedDown = true;
        }
      }
    }

    protected struct GameDefinitionWrapper
    {
      public GameDefinition Definition;
      public GameDefinitionWrapper(GameDefinition definition)
      {
        Definition = definition;
      }
      public override string ToString()
      {
        return Definition.Name;
      }
    }

    protected class GameDefinitionWrapperComparer : IComparer
    {
      public int Compare(object x, object y)
      {
        string sx = ((GameDefinitionWrapper)x).ToString();
        string sy = ((GameDefinitionWrapper)y).ToString();
        return string.Compare(sx, sy);
      }
    }

    void cbiGameList_Click(object sender, EventArgs e)
    {
      if (cbiGameList.SelectedIndex > -1)
      {
        Initialize(((GameDefinitionWrapper)cbiGameList.SelectedItem).Definition);
        esplitOperations.Expanded = true;
      }
      else
      {
        currentGame = null;
        SetDefaultTreeText();
        treeView.Reset();
      }
    }

    #endregion

    #region Operations Panel

    private void esplitOperations_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitOperations.Expanded  // Will collapse after this event.
          && !esplitFilterManager.Expanded)
      {
        esplitFilter.Expanded = false;
        btnFilter.Checked = false;
      }
      else // Will expand after this event.
      {
        ipLibrary.BackgroundStyle.BorderBottom = eStyleBorderType.None;
        ipLibrary.InvalidateNonClient(); // Refresh borders.
      }
    }

    private void btnMerged_CheckedChanged(object sender, EventArgs e)
    {
      if (btnMerged.Checked)
        DisplayMode = LibraryDisplayMode.Merged;
    }

    private void btnSplit_CheckedChanged(object sender, EventArgs e)
    {
      if (btnSplit.Checked)
        DisplayMode = LibraryDisplayMode.Split;
    }

    private void btnTagView_Click(object sender, EventArgs e)
    {
      if (View == TagView.Tags)
        return;

      esplitDecompile.Expanded = false;
      biDecompile.Text = "<div align=\"center\" width=\"160\">Add Tags to Library</div>";
      biDecompile.Refresh();
      extractionQueue.Clear();

      View = TagView.Tags;
    }

    private void btnObjectView_Click(object sender, EventArgs e)
    {
      if (View == TagView.Objects)
        return;

      esplitDecompile.Expanded = false;
      biDecompile.Text = "<div align=\"center\" width=\"160\">Add Objects to Library</div>";
      biDecompile.Refresh();
      extractionQueue.Clear();

      View = TagView.Objects;
    }

    private void btnFilter_Click(object sender, EventArgs e)
    {
      btnFilter.Checked = !btnFilter.Checked;

      ipFilter.BringToFront(); // Put panel at bottom.
      esplitFilter.Expanded = btnFilter.Checked;
    }

    #endregion

    #region Filter Panel

    private void esplitFilter_ExpandedChanging(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitFilter.Expanded) // Will collapse after this event.
      {
        esplitFilterManager.Expanded = false;
        ipOperations.BackgroundStyle.BorderBottom = eStyleBorderType.Solid;
      }
      else // Will expand after this event.
        ipOperations.BackgroundStyle.BorderBottom = eStyleBorderType.None;

      ipOperations.InvalidateNonClient(); // Refresh borders.
    }

    private void cbiFilter_Click(object sender, EventArgs e)
    {
      if (cbiFilter.SelectedIndex > 1)
      {
        btnFilterManager.Enabled = true;
        tbiFilterName.ControlText = cbiFilter.Items[cbiFilter.SelectedIndex].ToString();
      }
      else
      {
        cbiFilter.SelectedIndex = 0;
        btnFilterManager.Enabled = false;
        tbiFilterName.ControlText = "";
      }
    }

    private void btnFilterManager_Click(object sender, EventArgs e)
    {
      if (cbiFilter.SelectedIndex > -1)
      {
        // Setup AnimationTime properties for smoother animation.
        if (btnFilterManager.Checked)
        {
          esplitLibrary.AnimationTime = 0;
          esplitOperations.AnimationTime = 0;
          esplitFilterManager.AnimationTime = 100; // Default restored.
        }
        else
        {
          esplitLibrary.AnimationTime = 100; // Default restored.
          esplitOperations.AnimationTime = 100; // Default restored.
          esplitFilterManager.AnimationTime = 0;
        }

        btnFilterManager.Checked = !btnFilterManager.Checked;

        ipFilterManager.BringToFront(); // Put panel at bottom.
        esplitFilterManager.Expanded = btnFilterManager.Checked;
      }
    }

    #endregion

    #region Filter Manager Panel

    private void esplitFilterManager_ExpandedChanged(object sender, ExpandedChangeEventArgs e)
    {
      if (esplitFilterManager.Expanded)
      {
        ipFilter.BackgroundStyle.BorderTop = eStyleBorderType.Solid;
        ipFilter.BackgroundStyle.BorderBottom = eStyleBorderType.None;
        ipFilter.Size = new Size(ipFilter.Size.Width, ipFilter.Size.Height + 2);
        ipFilter.InvalidateNonClient(); // Refresh borders.
      }
      else
      {
        ipFilter.BackgroundStyle.BorderTop = eStyleBorderType.None;
        ipFilter.BackgroundStyle.BorderBottom = eStyleBorderType.Solid;
        ipFilter.Size = new Size(ipFilter.Size.Width, ipFilter.Size.Height - 2);
        ipFilter.InvalidateNonClient(); // Refresh borders.

        /* esplitLibrary.Expanded handles esplitOperations.Expanded when
         * esplitFilterManager.Expanded is false, but we have to deal with
         * it when esplitFilterManager.Expanded is true.
         */
        esplitOperations.Expanded = true;
      }

      esplitLibrary.Expanded = !esplitFilterManager.Expanded;
    }

    #endregion

    #region IPersistable Implementation
    string IPersistable.InstanceName
    {
      get { return "LibraryExplorer"; }
    }

    void IPersistable.Load()
    {
      SettingsManager.Instance.LoadInstance(this);
    }

    void IPersistable.Save()
    {
      SettingsManager.Instance.SaveInstance(this);
    }
    #endregion

    private void ipLibrary_Resize(object sender, EventArgs e)
    {
      int width = ipLibrary.Size.Width,
          portionWidth = (width / 2) - 11;

      cbiSystemList.ComboWidth = portionWidth;
      cbiGameList.ComboWidth = portionWidth;
    }

    private void ipOperations_Resize(object sender, EventArgs e)
    {
      icViewAdjustment.MinimumSize = new Size(ipOperations.Width - 92, 0);
    }

    /// <summary>
    /// Locates and selects the appropriate platform and game definition in the selection comboboxes
    /// in order to activate the game matching the specified game id.
    /// </summary>
    public void SelectGame(string gameID)
    {
      try
      {
        // Turn on silent mode so that we don't do any fancy schmancy UI stuff.
        silentGameSelect = true;

        GameDefinition def = Core.Prometheus.Instance.GetGameDefinitionByGameID(gameID);
        cbiSystemList.SelectedItem = def.Platform;
        foreach (object item in cbiGameList.Items)
          if (item is GameDefinitionWrapper)
            if (((GameDefinitionWrapper)item).Definition == def)
            {
              cbiGameList.SelectedItem = item;
              break;
            }
      }
      finally
      {
        silentGameSelect = false;
      }
    }
  }

  public enum TagView
  {
    Tags,
    Objects
  }

  public enum LibraryDisplayMode
  {
    Merged,
    Split
  }
}