using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Core;
using Core.Pool;
using Core.Project;
using Core.Radiosity;
using Core.Rendering;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using Interfaces;
using Interfaces.DebugConsole;
using Interfaces.Games;
using DNBHelper = Interfaces.Helpers.DNB;
using Interfaces.Notes;
using Interfaces.Pool;
using Interfaces.Rendering;
using Interfaces.TagEditor;
using Interfaces.UserInterface;
using Prometheus.Controls;
using Prometheus.Controls.ScriptEditor;
using Prometheus.Controls.TagExplorers;
using Prometheus.Properties;
using Prometheus.Controls.TagEditor;
using Prometheus.ThirdParty.Controls;
using Prometheus.UserInterface;
using DNBRendering = DevComponents.DotNetBar.Rendering;
using Timer=System.Windows.Forms.Timer;
using Interfaces.Rendering.Selection;
using Interfaces.DynamicInterface.SceneInstanceMenu;
using System.Collections.Generic;

namespace Prometheus.Dialogs
{
  /// <summary>
  /// The main Prometheus dialog.
  /// </summary>
  public partial class PrometheusGUI : Office2007RibbonForm
  {
    private bool isExpandedTooltipBar = false;
    private static bool displayFPSGraph = false;
    private bool allowCurtains = false;
    protected Core.Prometheus core = null;
    private readonly CurtainForm curtain = new CurtainForm();
    private bool defaultSceneActive = true;
    private Timer fpsUpdateTimer = new Timer();
    private bool ignoreSceneChange = false;

    /// <summary>
    /// Creates a new instance of the PrometheusGUI object.
    /// </summary>
    public PrometheusGUI()
    {
      // Initialize the Output control.
      Output.OutputLevel = OutputTypes.User;
#if DEBUG
      Output.OutputLevel = OutputTypes.Developer;
#endif
      ListOutputListener listener = new ListOutputListener();
      listener.Name = "Main";
      Output.AddListener(listener);

      LogFileListener logListener = new LogFileListener("File", Application.StartupPath + "\\logfile.txt");
      Output.AddListener(logListener);

      // Init the designer control layout
      InitializeComponent();
      ManualInit();

      // Make Vista-only controls visible on Vista systems.
      VistaOnlyControls();

      barFileViewer.Controls.Remove(pdcNewTagTab);
      barFileViewer.Items.Remove(dciNewTagTab);

      // init the core
      core = Core.Prometheus.CreateInstance(renderViewport, this);
      RenderCore.PausedChanged += RenderCore_PausedChanged;
      RenderCore.SceneAdded += RenderCore_SceneAdded;
      RenderCore.SceneRemoved += RenderCore_SceneRemoved;
      RenderCore.SceneChanged += RenderCore_SceneChanged;
      barViewport.DockTabChange += barViewport_DockTabChange;
      barViewport.Closing += new DotNetBarManager.BarClosingEventHandler(barViewport_Closing);
      Disposed += DisposeCore;

      // Some issues to work out here before trying to pause rendering on bar moves.
      //barViewport.MouseDown += new MouseEventHandler(barViewport_MouseDown);
      //barViewport.MouseUp += new MouseEventHandler(barViewport_MouseUp);
      //barViewport.MouseMove += new MouseEventHandler(barViewport_MouseMove);

      // Initialize LibraryExplorer.
      LibraryExplorer le = new LibraryExplorer();
      le.AddTagToProject += le_AddTagToProject;
      le.EditTagForProject += EditTagForProject;
      le.ViewTaginTagEditor += le_ViewTaginTagEditor;
      le.Dock = DockStyle.Fill;
      le.PreviewTag += LibraryExplorer_PreviewTag;
      le.ViewScript += le_ViewScript;
      dciTaskPaneLibraryExplorer.Control = le;

      // Initialize ProjectExplorer.
      ProjectExplorer pe = new ProjectExplorer();
      pe.EditTag += pe_EditTag;
      pe.PreviewTag += LibraryExplorer_PreviewTag;
      pe.Dock = DockStyle.Fill;
      pe.TagAdded += pe_TagAdded;
      dciTaskPaneProjectExplorer.Control = pe;
      dciTaskPaneProjectExplorer.Visible = false;

      // Add the listener control.
      dciOutput.Control = listener;
      dciOutput.Selected = true;

      // Create a new instance of the lightmap rendering system.
      InitializeRadiosity();

      // Setup the document manager.
      barFileViewer.DockTabChange += barFileViewer_DockTabChange;
      barFileViewer.BeforeDockTabDisplayed += barFileViewer_BeforeDockTabDisplayed;
      barFileViewer.DockTabClosing += barFileViewer_DockTabClosing;
      barFileViewer.Closing += barFileViewer_Closing;

      core.DocumentManager = new DocumentManager();
      core.DocumentManager.DocumentOpened += DocumentManager_DocumentOpened;
      core.DocumentManager.DocumentActivated += DocumentManager_DocumentActivated;
      core.DocumentManager.DocumentClosed += DocumentManager_DocumentClosed;
      core.DocumentManager.DocumentRenamed += DocumentManager_DocumentRenamed;
      core.DocumentManager.DirtyDocumentClosing += DocumentManager_DirtyDocumentClosing;

      // Setup handlers for ProjectManager events.
      core.ProjectManager.OpenedProject += ProjectManager_ProjectOpened;
      core.ProjectManager.ScenarioOpening += ProjectManager_ScenarioOpening;
#if DEBUG
      InitializeTests();
      DebugShowAllButton();
      SetupClickListeners();
#endif

      // Setup the final visibility state for the controls (will at some point be
      // determined by settings/persisted data from the last session)
      dciTaskPaneLibraryExplorer.Selected = true;

      fpsUpdateTimer.Tick += fpsUpdateTimer_Tick;
      fpsUpdateTimer.Interval = 500;
      DisplayGraphChanged += PrometheusGUI_DisplayGraphChanged;
    }

    private void DebugShowAllButton()
    {
      ButtonItem showAllButton = new ButtonItem();

      rcPromRibbon.SuspendLayout();
      rcPromRibbon.Items.Insert(rcPromRibbon.Items.Count - 3, showAllButton);

      showAllButton.Text = "Unhide";
      showAllButton.ColorTable = eButtonColor.Magenta;
      showAllButton.ItemAlignment = eItemAlignment.Far;
      showAllButton.Click += new System.EventHandler(this.showAllButton_Click);
      this.stRibbon.SetSuperTooltip(showAllButton, new DevComponents.DotNetBar.SuperTooltipInfo("DEBUG ONLY", null, "This button will unhide any RibbonControl tabs that have been hidden.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new System.Drawing.Size(0, 0)));

      rcPromRibbon.ResumeLayout();
    }

    private void showAllButton_Click(object sender, EventArgs e)
    {
      ButtonItem bi = (sender as ButtonItem);

      switch(bi.Text)
      {
        case "Hide":
          bi.Text = "Unhide";
          rtiModel.Visible = rtiWorld.Visible = false;
          break;
        case "Unhide":
          bi.Text = "Hide";
          rtiModel.Visible = rtiWorld.Visible = true;
          break;
      }

      rcPromRibbon.Refresh();
    }

    public bool FullScreen
    {
      get { return biViewScreenFullScreen.Checked; }
      set { biViewScreenFullScreen.Checked = value; }
    }

    private static event EventHandler DisplayGraphChanged;

    [Console("toggle_fps_graph", "turns on/off the rendering performance graph.")]
    public static void ToggleFPSGraph()
    {
      displayFPSGraph = !displayFPSGraph;
      if (DisplayGraphChanged != null)
        DisplayGraphChanged(null, null);
    }

    private void fpsUpdateTimer_Tick(object sender, EventArgs e)
    {
      fpsGraph.AddValue((decimal) MdxRender.FrameTimer.FPS);
    }

    private void barViewport_MouseMove(object sender, MouseEventArgs e)
    {
      if (barViewportMouseDown)
        if (!RenderCore.Paused)
          RenderCore.Paused = true;
    }

    private void barViewport_MouseUp(object sender, MouseEventArgs e)
    {
      if ((e.Button & MouseButtons.Left) > 0)
        barViewportMouseDown = false;
      if (RenderCore.Paused)
        RenderCore.Paused = false;
    }

    private void barViewport_MouseDown(object sender, MouseEventArgs e)
    {
      if ((e.Button & MouseButtons.Left) > 0)
        barViewportMouseDown = true;
    }

    private bool barViewportMouseDown = false;
    private void barViewport_LocationChanged(object sender, EventArgs e)
    {
      Output.Write(OutputTypes.Debug, "Location Changed");
    }

    private void barFileViewer_Closing(object sender, BarClosingEventArgs e)
    {
      curtain.Show(barFileViewer);
      curtain.Fade();
    }

    private void RenderCore_SceneRemoved(SceneState scene)
    {
      foreach (BaseItem item in barViewport.Items)
      {
        if (item.Name == scene.Identifier)
        {
          if (item is DockContainerItem)
          {
            //if (!ignoreSceneChange)
            DockContainerItem dci = (DockContainerItem) item;
            barViewport.Items.Remove(dci);
            barViewport.Controls.Remove(dci.Control);
            return;
          }
        }
      }
    }

    private void barViewport_Closing(object sender, BarClosingEventArgs e)
    {
      e.Cancel = true;

      if (barViewport.SelectedDockContainerItem == dciViewport)
        return;

      RenderCore.RemoveScene(barViewport.SelectedDockContainerItem.Name);

      if (barViewport.Items.Count == 0)
      {
        barViewport.Controls.Add(pdcViewport);
        barViewport.Items.Add(dciViewport);
        barViewport.SelectedDockContainerItem = dciViewport;
        defaultSceneActive = true;
        e.Cancel = false;

        // Since there are no more scenes loaded, remove the Viewport Tools.
        rtiWorld.Visible = rtiModel.Visible = rbViewRendering.Enabled = false;

        // Reset to old RibbonTabItem
        if (uihelperPreScreneRibbonTabItem != null)
          uihelperPreScreneRibbonTabItem.Select();
        else
          rtiHome.Select();
      }
    }

    private RibbonTabItem uihelperPreScreneRibbonTabItem;
    private void RenderCore_SceneChanged(SceneState scene)
    {
      #region Viewport Tools Handling

      if (rcPromRibbon.SelectedRibbonTabItem != rtiWorld && rcPromRibbon.SelectedRibbonTabItem != rtiModel)
      {
        uihelperPreScreneRibbonTabItem = rcPromRibbon.SelectedRibbonTabItem;
      }
      
      if ((scene.SceneType == SceneType.Scenario) || (scene.SceneType == SceneType.SBSP))
      {
        rtiWorld.Visible = true;
        rtiWorld.Select();
        rtiWorld_SceneLoaded();

        rtiModel.Visible = false;
      }
      else if (scene.SceneType == SceneType.Object || scene.SceneType == SceneType.Model)
      {
        rtiModel.Visible = true;
        rtiModel.Select();
        rtiModel_SceneLoaded();

        rtiWorld.Visible = false;
      }
      else
      {
        rtiModel.Visible = rtiWorld.Visible = false;

        if (uihelperPreScreneRibbonTabItem != null)
          uihelperPreScreneRibbonTabItem.Select();
        else
          rtiHome.Select();
      }

      rbViewRendering.Enabled = (rtiModel.Visible || rtiWorld.Visible); // Render options can only be changed when a scene is active.

      rcPromRibbon.Refresh(); // Required to update RibbonTabItem visibility.

      #endregion

      foreach (BaseItem item in barViewport.Items)
        if (item.Name == scene.Identifier)
          if (item is DockContainerItem)
          {
            if (!ignoreSceneChange)
              barViewport.SelectedDockContainerItem = (DockContainerItem) item;
            return;
          }
    }

    private void barViewport_DockTabChange(object sender, DockTabChangeEventArgs e)
    {
      curtain.Show(barViewport);
      ignoreSceneChange = true;
      if (!(e.NewTab is DockContainerItem)) return;
      Control c = ((DockContainerItem) e.NewTab).Control;

      c.Controls.Add(cmbViewport);
      c.Controls.Add(fpsGraph);
      c.Controls.Add(renderViewport);
      c.Controls.Add(txtbHUGEHACK);

      RenderCore.ActiveSceneName = e.NewTab.Name;
      ignoreSceneChange = false;
      curtain.Fade();
    }

    private void RenderCore_SceneAdded(SceneState scene)
    {
      DockContainerItem dciNewScene = new DockContainerItem();
      dciNewScene.Name = scene.Identifier;

      PanelDockContainer pdcNewScene = new PanelDockContainer();
      string text = UIHelpers.GetTagPathToolTip(new TagPath(scene.Identifier), true);
      pdcNewScene.Text = text;
      dciNewScene.Control = pdcNewScene;
      dciNewScene.Text = text;
      barViewport.Controls.Add(pdcNewScene);
      barViewport.Items.AddRange(new BaseItem[] {dciNewScene});
      barViewport.SelectedDockContainerItem = dciNewScene;

      if (defaultSceneActive)
      {
        barViewport.Controls.Remove(pdcViewport);
        barViewport.Items.Remove(dciViewport);
        defaultSceneActive = false;
      }
    }

    private void barFileViewer_BeforeDockTabDisplayed(object sender, EventArgs e)
    {
      if (allowCurtains)
      {
        curtain.Show(barFileViewer);
        curtain.Fade();
      }
    }

    private void RenderCore_PausedChanged(object sender, EventArgs e)
    {
      if (RenderCore.Paused)
      {
        string text = "Rendering Paused";
        Bitmap backBufferRaw = core.GetBackbuffer();
        Bitmap backBuffer = Helpers.BlurBitmap(backBufferRaw);
        backBufferRaw.Dispose();

        renderViewport.Image = backBuffer;
        curtain.Show(renderViewport);
        using (Graphics g = Graphics.FromImage(backBuffer))
        {
          Font leFont = new Font("Verdana", 16f, FontStyle.Bold);
          int pad = 10;
          // Draw the text.
          int textWidth = Width - (pad*2);
          g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
          SizeF s = g.MeasureString(text, leFont, textWidth);
          Bitmap pauseButton = Resources.pause_button;
          float x = (backBuffer.Width - s.Width)/2;
          float y = (((backBuffer.Height - s.Height) + (pauseButton.Height + 5)/2)/2);
          using (Brush fontBrush = new SolidBrush(Color.White))
          {
            using (Brush fontBrushBG = new SolidBrush(Color.Black))
            {
              RectangleF area = new RectangleF(x, y, s.Width, s.Height);
              RectangleF areaBG = new RectangleF(x + 1, y + 1, s.Width, s.Height);
              StringFormat f = new StringFormat();
              f.Alignment = StringAlignment.Center;
              g.DrawString(text, leFont, fontBrushBG, areaBG, f);
              g.DrawString(text, leFont, fontBrush, area, f);
            }
          }

          int imageX = (backBuffer.Width - pauseButton.Width)/2;
          int imageY = (int) y - (pauseButton.Height + 5);
          g.DrawImage(pauseButton, new Rectangle(imageX - 1, imageY - 1, pauseButton.Width,
                                                 pauseButton.Height));

          Rectangle fadeTop = new Rectangle(0, 0, backBuffer.Width, backBuffer.Height/2);
          using (Brush gradient1 = new LinearGradientBrush(fadeTop,
                                                           Color.Black, Color.Transparent, LinearGradientMode.Vertical))
            g.FillRectangle(gradient1, fadeTop);

          Rectangle fadeBottom = new Rectangle(0, (backBuffer.Height - (backBuffer.Height/2)),
                                               backBuffer.Width, backBuffer.Height/2);
          using (Brush gradient2 = new LinearGradientBrush(fadeBottom,
                                                           Color.Transparent, Color.Black, LinearGradientMode.Vertical))
            g.FillRectangle(gradient2, fadeBottom);
        }
        renderViewport.Image = backBuffer;
        curtain.Fade();
      }
      else
      {
        curtain.Show(renderViewport);
        renderViewport.Image.Dispose();
        renderViewport.Image = null;
        curtain.Fade();
      }
    }

    private void pe_EditTag(object sender, OpenTagEventArgs e)
    {
      Type tagType = core.GetTypeFromTagPath(e.TagPath);
      Tag tag = core.Pool.Open(e.TagPath.ToPath(), tagType, false);
      OpenTagInTagEditor(tag);
    }

    private void le_ViewScript(object sender, OpenTagEventArgs e)
    {
      try
      {
        Cursor = Cursors.WaitCursor;
        curtain.Show(barFileViewer);
        byte[] script = core.Pool.GetTagAttachent(e.TagPath);
        Output.Write(OutputTypes.Developer,
                     "Opened attachment '" + e.TagPath.AttachmentName + "' - " + script.Length + " bytes.");

        ScriptEditorControl editor = new ScriptEditorControl();
        editor.Create(Core.Prometheus.Instance.GetGameDefinitionByGameID(e.TagPath.Game), e.TagPath.ToPath(), true,
                      Encoding.ASCII.GetString(script));

        core.DocumentManager.OpenDocument(editor);
      }
      finally
      {
        curtain.Fade();
        Cursor = Cursors.Default;
      }
    }

    private void le_ViewTaginTagEditor(object sender, OpenTagEventArgs e)
    {
      // TODO: This needs to open the document in read-only mode.
      Type tagType = core.GetTypeFromTagPath(e.TagPath);
      Tag tag = core.Pool.Open(e.TagPath.ToPath(), tagType, false);
      OpenTagInTagEditor(tag);
    }

    private void PrometheusGUI_DisplayGraphChanged(object sender, EventArgs e)
    {
      fpsGraph.Visible = displayFPSGraph;
      if (displayFPSGraph)
        fpsUpdateTimer.Start();
      else
        fpsUpdateTimer.Stop();
    }

    private void ProjectManager_ScenarioOpening(object sender, CancelEventArgs e)
    {
      string scenarioFile = new TagPath(core.ProjectManager.Project.Templates["Scenario"].Path).ToPath(PathFormat.Relative);
      string prompt = "Project loaded successfully!<br/><br/>Would you like to load the scenario file <b>'" +
                      scenarioFile + "'</b> into the render window?";
      if (MessageBoxEx.Show(prompt, "Load Scenario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
          DialogResult.No)
        e.Cancel = true;
      else
        e.Cancel = false;
    }

    private void ProjectManager_ProjectOpened(object sender, EventArgs e)
    {
      Cursor previousCursor = Cursor;
      Cursor = Cursors.WaitCursor;
      try
      {
        // Setup the ProjectExplorer
        ProjectExplorer projectExplorer = (ProjectExplorer)dciTaskPaneProjectExplorer.Control;
        projectExplorer.Initialize(core.ProjectManager);
        dciTaskPaneProjectExplorer.Visible = true;
        dciTaskPaneProjectExplorer.Selected = true;

        // Set the LibraryExplorer to the game associated with the currently loaded project.
        LibraryExplorer libraryExplorer = (LibraryExplorer)dciTaskPaneLibraryExplorer.Control;
        libraryExplorer.SelectGame(core.ProjectManager.GameID);
      }
      finally
      {
        Cursor = previousCursor;
      }
    }

    private void pe_TagAdded(object sender, OpenTagEventArgs e)
    {
      GameDefinition game = core.GetGameDefinitionByGameID(e.TagPath.Game);
      Type tagType = game.TypeTable.LocateEntryByName(e.TagPath.Extension).TagType;
      AddTagToProject(e.TagPath, tagType);
    }

    private void le_AddTagToProject(object sender, OpenTagEventArgs e)
    {
      GameDefinition game = core.GetGameDefinitionByGameID(e.TagPath.Game);
      Type tagType = game.TypeTable.LocateEntryByName(e.TagPath.Extension).TagType;
      // HACK: We shouldn't even be copying files at all, but I'm just tyring to see if this works.
      TagPath newPath = e.TagPath.NewLocation(TagLocation.Archive);
      AddTagToProject(newPath, tagType);
    }

    /// <summary>
    /// Loads the tag from the specified TagPath and adds it to the project;
    /// </summary>
    /// <returns>A bool indicating it the tag was added or not.</returns>
    public static bool AddTagToProject(TagPath tagPath, Type tagType)
    {
      if (!Core.Prometheus.Instance.Pool.TagExists(tagPath))
      {
        string message = "The specified tag file does not exist in the " + EnumReader.GetText(tagPath.Location) +
                         ":" + tagPath.Path + "." + tagPath.Extension;
        MessageBoxEx.Show(message, "Copy Tag File", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      Tag tag = Core.Prometheus.Instance.Pool.Open(tagPath.ToPath(), tagType, false);
      tag.TagPath.Location = TagLocation.Project;

      bool saveFile = true;
      if (Core.Prometheus.Instance.Pool.TagExists(tag.TagPath))
      {
        DialogResult result =
          MessageBoxEx.Show("The specified tag already exists in the project.\r\nWould you like to overwrite it?",
                            "Add Tag to Project", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.No)
          saveFile = false;
      }

      if (saveFile)
        Core.Prometheus.Instance.ProjectManager.AddTagToProject(tag, tagPath.NewLocation(TagLocation.Archive));

      Core.Prometheus.Instance.Pool.DisposeOfTag(ref tag);
      return saveFile;
    }

    /// <summary>
    /// Disposes of the Prometheus core.
    /// </summary>
    protected void DisposeCore(object sender, EventArgs e)
    {
      if (core != null)
        core.Dispose();
    }

    private void EditTagForProject(object sender, OpenTagEventArgs e)
    {
      Type tagType = core.GetTypeFromTagPath(e.TagPath);
      bool openTag = AddTagToProject(e.TagPath, tagType);
      TagPath newTagPath = e.TagPath.NewLocation(TagLocation.Project);

      if (!openTag)
        if (core.Pool.TagExists(newTagPath))
          openTag =
            MessageBoxEx.Show("Would you like to open the existing tag in the Tag Editor?", "Open Tag for Edit",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

      if (openTag)
      {
        Tag tag = core.Pool.Open(newTagPath.ToPath(), tagType, false);
        OpenTagInTagEditor(tag);
      }
    }

    private void OpenTagInTagEditor(Tag tag)
    {
      try
      {
        Cursor = Cursors.WaitCursor;
        curtain.Show(barFileViewer);
        GameDefinition game = core.GetGameDefinitionByGameID(tag.GameID);
        TagEditorControl te = new TagEditorControl();
        te.OpenTag += new OpenTagPathEventHandler(te_OpenTag);
        te.Create(game, game.TypeTable.LocateEntryByName(tag.FileExtension).FourCC, tag);
        core.DocumentManager.OpenDocument(te);
        core.DocumentManager.DocumentStateChanged +=
          new DocumentStateChangedHandler(DocumentManager_DocumentStateChanged);
      }
      finally
      {
        curtain.Fade();
        Cursor = Cursors.Default;
      }
    }

    private void te_OpenTag(TagPath path)
    {
      Type type = core.GetTypeFromTagPath(path);
      Tag tag = core.Pool.Open(path.ToPath(), type, false);
      OpenTagInTagEditor(tag);
    }

    #region Vista Only

    [DllImport("dwmapi.dll", PreserveSig = false)]
    public static extern bool DwmIsCompositionEnabled();

    private void VistaOnlyControls()
    {
      if (NativeMethods.IsVistaOrNewer)
      {
        if (DwmIsCompositionEnabled())
          VistaOnlybiViewScreenUIThemeAeroGlass.Visible = true;
      }
    }

    #endregion

    #region Debug Only

#if DEBUG
    private void SetupClickListeners()
    {
      DateTime start = DateTime.Now;
      int totalHandlers = 0;
      Type t = GetType();
      foreach (FieldInfo fi in t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
      {
        Type f = fi.FieldType;
        EventInfo clickEvent = f.GetEvent("Click");
        if (clickEvent != null)
        {
          // Setup the event handler.
          if (clickEvent.EventHandlerType == typeof (EventHandler))
          {
            object o = fi.GetValue(this);

            if (o != null)
            {
              clickEvent.AddEventHandler(o, new EventHandler(GlobalClickHandler));
              totalHandlers++;
            }
          }
        }
      }
      Output.Write(OutputTypes.Debug, "Setup click handlers for " + totalHandlers + " objects in " +
                                      DateTime.Now.Subtract(start).TotalSeconds + " seconds.");
    }

    private void GlobalClickHandler(object sender, EventArgs e)
    {
      PropertyInfo pi = sender.GetType().GetProperty("Name");
      if (pi != null)
      {
        Output.Write(OutputTypes.Debug, "You clicked on " + (pi.GetValue(sender, null) as string));
      }
      else
      {
        Output.Write(OutputTypes.Debug, "You clicked on " + sender);
      }
    }
#endif

    #endregion

    #region GUI Essentials

    #region GUI Load / Close Events

    private void PrometheusGUI_Load(object sender, EventArgs e)
    {
#if !DEBUG // While debugging, do not collapse the Ribbon on load.
  // Minimize the Ribbon and set our default theme color.
      rcPromRibbon.Expanded = false;
#endif

      PrometheusMainTheme();

#if DEBUG // While debugging, allow us to toggle an auto-loading BSP.
#if false // Turn automatic BSP loading on (true) or off (false).
      Core.Prometheus.Instance.OnAddScene(
        "levels\\test\\bloodgulch\\bloodgulch.scenario_structure_bsp", 
        core.GetGameDefinitionByGameID("halo1pc"),
        Core.Pool.TagLocation.Archive, String.Empty);
#endif
#endif

#if !DEBUG // While debugging, we don't want to persist layout changes between executions.
      try{ dnbmPromLayout.LoadLayout("layout.xml"); }
      catch(System.IO.FileNotFoundException){}
#endif
    }

    private void PrometheusGUI_Shown(object sender, EventArgs e)
    {
      //Update core data displays at 4Hz
      timerCoreGuiUpdates.Interval = 250;
      timerCoreGuiUpdates.Enabled = true;

      allowCurtains = true;
    }

    private void exitPrometheus(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void PrometheusGUI_FormClosing(object sender, FormClosingEventArgs e)
    {
#if !DEBUG // While debugging, we don't want to persist layout changes between executions.
      dnbmPromLayout.SaveLayout("layout.xml");
#endif
    }

    #endregion

    #region Theme Handling

    public static Office2007ColorTable ThemeColorTable()
    {
      // Testing Color Access
      Office2007Renderer renderer = GlobalManager.Renderer as Office2007Renderer;

      if (renderer != null)
        return renderer.ColorTable;
      else
        return null;
    }

    private void PrometheusMainTheme()
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Black, Color.FromArgb(69, 98, 135));
    }

    #endregion

    #region Full Screen Handling

    // biViewScreenFullScreen event handler is in the "View Tab" region of the "Ribbon Events" region.

    private Point formLocation;
    private Size formSize;

    private void ToggleFullScreen()
    {
      if (biViewScreenFullScreen.Checked)
      {
        formSize = Size;
        formLocation = Location;

        Rectangle size = Screen.GetBounds(this);
        Size = new Size(size.Width, size.Height);
        Location = new Point(0, 0);
        MinimizeBox = false;
        MaximizeBox = false;
        TopMost = true;
      }
      else
      {
        Size = formSize;
        Location = formLocation;
        MinimizeBox = true;
        MaximizeBox = true;
        TopMost = false;
      }
    }

    #endregion

    #endregion

    #region Ribbon Events

    #region File Menu

    private void biFileMenuLaunch_Click(object sender, EventArgs e)
    {
      // Nick: This destroys rendering performance due to the constant paint events.
      //biFileMenuLaunch.StopPulse(); // Stop pulsing.
      //biPromRibbonHideToggle.Pulse(); // Guide user to next action.
    }

    #region Fix File Menu Popup Locations

    private void biFileMenuButtons_ExpandChange(object sender, EventArgs e)
    {
      ButtonItem bi = (ButtonItem)sender;

      if (bi.Expanded)
        bi.PopupLocation = icFileMenuRecent.DisplayRectangle.Location;
    }

    #endregion

    #region Create

    private void biFileMenuCreateScript_Click(object sender, EventArgs e)
    {
      try
      {
        Cursor = Cursors.WaitCursor;
        curtain.Show(barFileViewer);
        ScriptEditorControl editor = new ScriptEditorControl();
        editor.Create(Core.Prometheus.Instance.GetGameDefinitionByGameID("halopc"), "Untitled-1.psl", false);
        core.DocumentManager.OpenDocument(editor);
      }
      finally
      {
        curtain.Fade();
        Cursor = Cursors.Default;
      }
    }

    #endregion

    #region Access

    private void biFileMenuAccessProject_Click(object sender, EventArgs e)
    {
      OpenProjectDialog opd = new OpenProjectDialog();
      DialogResult r = opd.ShowDialog();
      if (r == DialogResult.Cancel)
        return;

      core.ProjectManager.OpenProject(opd.Filename, ScenarioAction.PromptUser);
    }

    #endregion

    #region Store

    private void biFileMenuStoreChanges_Click(object sender, EventArgs e)
    {
      SaveCurrentDocument();
    }

    private void biFileMenuStoreEverything_Click(object sender, EventArgs e)
    {
      SaveAllDocuments();
    }

    #endregion

    #region Distribute

    #endregion

    #region Close

    private void biFileMenuClose_Click(object sender, EventArgs e)
    {
      CloseCurrentDocument();
    }

    #endregion

    #endregion

    #region Home Tab

    #region HaloDev Login / Flood Control

    private System.Threading.Timer delayConnections;
    private DateTime lastLoginAttempt;
    private TimeSpan attemptTimeSpan;
    private int loginAttemptCount = 0;

    private void EnableHaloDevIDConnections(Object stateInfo)
    {
      if (InvokeRequired)
      {
        EnableHaloDevIDConnectionsCallback connect = new EnableHaloDevIDConnectionsCallback(EnableHaloDevIDConnections);
        Invoke(connect, new object[] {stateInfo});
      }
      else
      {
        biHomeStayConnectedLogin.Enabled = true;
      }
    }

    private void HaloDevIDLoginFloodControl()
    {
      const int FloodPeriodLength = 1, // Number of minutes that must pass for a login attempt to not increment loginAttemptCount.
                FloodTimeout = 10, // Number of minutes that must pass before loginAttemptCount is reset to zero.
                AttemptsPerPeriod = 3, // Login attemps (as tracked by loginAttemptCount) until delay timer is extended.
                NormalDelay = 5, // Delay, in seconds, between login attempts.
                FloodDelay = 300; // Delay, in seconds, between login attempts when loginAttemptCount exceeds AttemptsPerPeriod.

      if (attemptTimeSpan.Minutes < FloodPeriodLength) // User is potentially being mischievous; log the attempt.
        loginAttemptCount++;
      else if (attemptTimeSpan.Minutes < FloodTimeout)
        // User waited longer than FloodPeriodLength, but didn't reach FloodTimeout; decrement attempt counter.
        loginAttemptCount--;
      else // FloodTimeout has elapsed, reset the attempt counter.
        loginAttemptCount = 0;

      TimerCallback enableConnections = new TimerCallback(EnableHaloDevIDConnections);
      delayConnections =
        new System.Threading.Timer(enableConnections, null,
                                   ((loginAttemptCount > AttemptsPerPeriod) ? (FloodDelay*1000) : (NormalDelay*1000)),
                                   Timeout.Infinite);
      biHomeStayConnectedLogin.Enabled = false;

#if DEBUG
      MessageBoxEx.Show("TimeSpan: " + attemptTimeSpan + "\nLogin Attempt Count: " + loginAttemptCount,
                        "Login Delay Info");
#endif
    }

    private void biHomeStayConnectedLogin_Click(object sender, EventArgs e)
    {
      if (biHomeStayConnectedLogin.Checked) // If the user is currently logged in.
      {
        //HaloDevID.Logout(); // Log the user out of the HaloDev ID system.

        // Set UI elements to their logged-out state.
        biHomeStayConnectedLogin.Text = "HaloDev\r\nLogin";
        biHomeStayConnectedLogin.Checked = false;
        biHomeStayConnectedLogin.ColorTable = eButtonColor.Orange;
        //biHomeStayConnectedSubmitBug.Enabled = false;
        //biHomeStayConnectedUpdateCheck.Enabled = false;

        HaloDevIDLoginFloodControl(); // Make sure the user is playing nice.
      }
      else // If the user is currently logged out.
      {
        bool loginSucceeded = true; //= HaloDevID.Login(); // Log the user in to the HaloDev ID system.

        if (loginSucceeded) // If the login succeeded.
        {
          // Set UI elements to their logged-in state.
          biHomeStayConnectedLogin.Text = "HaloDev\r\nLogout";
          biHomeStayConnectedLogin.Checked = true;
          biHomeStayConnectedLogin.ColorTable = eButtonColor.Blue;
          //biHomeStayConnectedSubmitBug.Enabled = true;
          //biHomeStayConnectedUpdateCheck.Enabled = true;
        }

        if (lastLoginAttempt.Year > 1) // Make sure lastLoginAttempt has been set before.
          attemptTimeSpan = DateTime.Now - lastLoginAttempt;

        lastLoginAttempt = DateTime.Now; // Set DateTime of login attempt for flood protection.
      }
    }

    #region Nested type: EnableHaloDevIDConnectionsCallback

    private delegate void EnableHaloDevIDConnectionsCallback(Object stateInfo);

    #endregion

    #endregion

    private void biHomeStayConnectedResourcesWebsite_Click(object sender, EventArgs e)
    {
      Process.Start("http://www.halodev.org");
    }

    private void biHomeStayConnectedResourcesForums_Click(object sender, EventArgs e)
    {
      Process.Start("http://forums.halodev.org");
    }

    private void biHomeStayConnectedResourcesKnowBase_Click(object sender, EventArgs e)
    {
      Process.Start("http://kb.halodev.org");
    }

    private void biHomeServerStatus_Click(object sender, EventArgs e)
    {
      string biHomeServerStatusDisabled =
        "Turn <b>on</b> the ability to receive files directly from other Prometheus users through the Direct Transfer feature." +
        "<br/><br/><font color=\"green\"><b><div align=\"center\">The server is currently disabled.</div></b></font>" +
        "<br/>Enabling the server will <b>allow</b> outside access to port 31337. Any time you open a port on your computer there is a minor security risk." +
        "<br/><br/>It is recommended that you configure your firewall to only allow Prometheus access to this port, configure the server settings, and only enable the server when you are expecting a file!";
      string biHomeServerStatusEnabled =
        "Turn <b>off</b> the ability to receive files directly from other Prometheus users through the Direct Transfer feature." +
        "<br/><br/><font color=\"red\"><b><div align=\"center\">The server is currently enabled.</div></b></font>" +
        "<br/>Disabling the server will disable the ability to receive files from other Prometheus users. You may, however, still send files to other user with the Direct Transfer feature." +
        "<br/><br/>While the server is enabled, be sure that your firewall is configured to only allow Prometheus access to port 31337. When you are done receiving files, you should <b>disable</b> the server!";

      biHomeServerStatus.Checked = !biHomeServerStatus.Checked;

      if (biHomeServerStatus.Checked)
      {
        biHomeServerStatus.Text = "<b>Enabled</b>";
        biHomeServerStatus.ColorTable = eButtonColor.Blue;
        biHomeServerStatus.ForeColor = Color.Red;
        stRibbon.SetSuperTooltip(biHomeServerStatus,
                                 new SuperTooltipInfo("Disable Direct Transfer Server",
                                                      "Press F1 to configure server settings.",
                                                      biHomeServerStatusEnabled, null, Resources.help216,
                                                      eTooltipColor.Default, true, true, new Size(247, 280)));
      }
      else
      {
        biHomeServerStatus.Text = "Disabled";
        biHomeServerStatus.ColorTable = eButtonColor.Orange;
        biHomeServerStatus.ForeColor = SystemColors.ControlText;
        stRibbon.SetSuperTooltip(biHomeServerStatus,
                                 new SuperTooltipInfo("Enable Direct Transfer Server",
                                                      "Press F1 to configure server settings.",
                                                      biHomeServerStatusDisabled, null, Resources.help216,
                                                      eTooltipColor.Default, true, true, new Size(247, 280)));
      }
    }

    #endregion

    #region Lighting Tab

    #endregion

    #region Tags Tab

    #endregion

    #region Scripting Tab

    #endregion

    #region Project Tab

    #endregion

    #region View Tab

    #region Screen

    private void biViewScreenResetLayout_Click(object sender, EventArgs e)
    {
      try
      {
        StreamReader reader =
          new StreamReader(
            Assembly.GetExecutingAssembly().GetManifestResourceStream("Prometheus.Resources.defaultlayout.xml"));
        dnbmPromLayout.LayoutDefinition = reader.ReadToEnd();
      }
      catch (ArgumentNullException)
      {
      }
    }

    private void biViewScreenFullScreen_Click(object sender, EventArgs e)
    {
      biViewScreenFullScreen.Checked = !biViewScreenFullScreen.Checked;
      ToggleFullScreen();
    }

    #region Visible Panes

    private void biVisibleMainPanes_Click(object sender, EventArgs e)
    {
      switch ((sender as ButtonItem).Name)
      {
        case "biViewScreenVisiblePanesMainPanesViewport":
          barViewport.Visible = !barViewport.Visible;
          break;
        case "biViewScreenVisiblePanesMainPanesTaskPane":
          barTaskPane.Visible = !barTaskPane.Visible;
          break;
        case "biViewScreenVisiblePanesMainPanesOutput":
          bool tabsVisible = false;

          foreach (DockContainerItem dci in barOutput.Items)
            if (dci.Visible)
              tabsVisible = true;

          if (tabsVisible)
            barOutput.Visible = !barOutput.Visible;
          else
          {
            dciOutput.Visible = true;
            barOutput.Visible = !barOutput.Visible;
          }
          break;
        case "biViewScreenVisiblePanesMainPanesFileViewer":
          barFileViewer.Visible = !barFileViewer.Visible;
          break;
      }
    }

    private void biVisibleOutputPanes_Click(object sender, EventArgs e)
    {
      bool noneVisible = true;
      string dockContainerItem = (sender as ButtonItem).Tag.ToString();

      barOutput.Items[dockContainerItem].Visible = !barOutput.Items[dockContainerItem].Visible;

      foreach (DockContainerItem dci in barOutput.Items)
        if (dci.Visible)
          noneVisible = false;

      if (noneVisible)
        barOutput.Visible = false;
      else
      {
        if (barOutput.Items[dockContainerItem].Visible)
          barOutput.Visible = true;
        barOutput.SelectedDockTab = barOutput.Items.IndexOf((sender as ButtonItem).Tag.ToString());
        barOutput.RecalcLayout();
      }
    }

    private void barMainPanes_VisibleChanged(object sender, EventArgs e)
    {
      switch ((sender as Bar).Name)
      {
        case "barViewport":
          biViewScreenVisiblePanesMainPanesViewport.Checked = barViewport.Visible;
          break;
        case "barTaskPane":
          biViewScreenVisiblePanesMainPanesTaskPane.Checked = barTaskPane.Visible;
          break;
        case "barOutput":
          biViewScreenVisiblePanesMainPanesOutput.Checked = barOutput.Visible;
          break;
        case "barFileViewer":
          biViewScreenVisiblePanesMainPanesFileViewer.Checked = barFileViewer.Visible;
          break;
      }
    }

    private void dciOptionPanes_VisibleChanged(object sender, EventArgs e)
    {
      switch (((DockContainerItem) sender).Name)
      {
        case "dciOutput":
          biViewScreenVisiblePanesOutputPanesOutput.Checked = dciOutput.Visible;
          break;
        case "dciTaskList":
          biViewScreenVisiblePanesOutputPanesTaskList.Checked = dciTaskList.Visible;
          break;
        case "dciHelp":
          biViewScreenVisiblePanesOutputPanesHelp.Checked = dciHelp.Visible;
          break;
      }
    }

    private void biViewScreenVisiblePanesRestoreDefaults_Click(object sender, EventArgs e)
    {
      barViewport.Visible = true;
      barTaskPane.Visible = true;
      barOutput.Visible = true;
      barFileViewer.Visible = true;
      dciOutput.Visible = true;
      dciTaskList.Visible = true;
      dciHelp.Visible = true;

      barOutput.RecalcLayout();
    }

    #endregion

    #region Visible Toolbars

    private void BuildViewScreenVisibleToolbarsList()
    {
      //foreach (RibbonTabItem rti in rcPromRibbon.Items)
      for (int i = 0; i < 8; i++)
      {
        ButtonItem bi = new ButtonItem();

        bi.ShowSubItems = true;
          // Temp until there is a fix for setting RibbonBar Visbility to false and haivng it work properly.

        bi.AutoCollapseOnClick = false;
        bi.CanCustomize = false;
        bi.Checked = true;
        bi.SplitButton = true;
        bi.Tag = rcPromRibbon.Items[i].Name;
        bi.Text = rcPromRibbon.Items[i].Text; // rcPromRibbon.Controls[i].Text;

        foreach (RibbonBar rb in (rcPromRibbon.Items[i] as RibbonTabItem).Panel.Controls)
        {
          ButtonItem sbi = new ButtonItem();

          sbi.AutoCollapseOnClick = false;
          sbi.Category = rb.Parent.Name;
          sbi.CanCustomize = false;
          sbi.Checked = true;
          sbi.Tag = rb.Name;
          sbi.Text = rb.Text; // rcPromRibbon.Controls[i].Controls[j].Text;
          sbi.Click += new EventHandler(biViewScreenVisibleToolbarsRibbonBar_Click);

          if (!sbi.Text.Equals("&Screen"))
            bi.SubItems.Add(sbi);
        }

        if (!bi.Text.Equals("View"))
          bi.Click += new EventHandler(biViewScreenVisibleToolbarsRibbonTab_Click);

        biViewScreenVisibleToolbars.SubItems.Add(bi);
      }

      rbViewScreen.RecalcLayout(); // Refresh the layout as items were added to it.
    }

    private void biViewScreenVisibleToolbarsRibbonTab_Click(object sender, EventArgs e)
    {
      ButtonItem button = (ButtonItem)sender;
      string rti = button.Tag.ToString();

      rcPromRibbon.Items[rti].Visible = !rcPromRibbon.Items[rti].Visible;
      buttonItemToggleCheck(sender, e);

      // Commented out until there's a fix for making RibbonBars invisible. Update BuildViewScreenVisibleToolbarsList() when this is uncommented.
      button.ShowSubItems = !button.ShowSubItems;
      button.ClosePopup();

      ((ButtonItem)button.Parent).ClosePopup();

      rcPromRibbon.RecalcLayout();
    }

    private void biViewScreenVisibleToolbarsRibbonBar_Click(object sender, EventArgs e)
    {
      string
        rb = ((ButtonItem) sender).Tag.ToString(),
        rp = ((ButtonItem) sender).Category;

      // RibbonPanel must be visible before changes to the RibbonBar will take place.
      rcPromRibbon.Controls[rp].Visible = true;
      rcPromRibbon.Controls[rp].Controls[rb].Visible = !rcPromRibbon.Controls[rp].Controls[rb].Visible;
      rcPromRibbon.Controls[rp].Visible = false;

      // Make the RibbonPanel visible again if the user is on the tab that received the change.
      if (rcPromRibbon.SelectedRibbonTabItem.Panel.Equals(rcPromRibbon.Controls[rp]))
        rcPromRibbon.Controls[rp].Visible = true;

      // Fix for pop-up being out of place in a specific situation.
      if (rcPromRibbon.Controls[rp].Controls[rb].Text.Equals("&Rendering"))
      {
        biViewScreenVisibleToolbars.Expanded = false;
        biViewScreenVisibleToolbars.Expanded = true;
      }

      buttonItemToggleCheck(sender, e);
    }

    #endregion

    #region Theme

    private string uihelperCurrentThemeName = "Default";

    public string UIHelperCurrentThemeName
    {
      get { return uihelperCurrentThemeName; }
    }

    private void biViewScreenUIThemeDefault_Click(object sender, EventArgs e)
    {
      PrometheusMainTheme();
      uihelperCurrentThemeName = "Default";
      Text = Text.Replace("Pinkmetheus", "Prometheus"); // Cleanup shenanigans.
    }

    private void biViewScreenUIThemeBlack_Click(object sender, EventArgs e)
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Black);
      uihelperCurrentThemeName = "Black";
      Text = Text.Replace("Pinkmetheus", "Prometheus"); // Cleanup shenanigans.
    }

    private void biViewScreenUIThemeBlue_Click(object sender, EventArgs e)
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Blue);
      uihelperCurrentThemeName = "Blue";
      Text = Text.Replace("Pinkmetheus", "Prometheus"); // Cleanup shenanigans.
    }

    private void biViewScreenUIThemeHotPink_Click(object sender, EventArgs e)
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver, Color.FromArgb(237, 28, 36));
      uihelperCurrentThemeName = "Hot Pink";
      Text = Text.Replace("Prometheus", "Pinkmetheus"); // Shenanigans.
    }

    private void biViewScreenUIThemeSilver_Click(object sender, EventArgs e)
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver);
      uihelperCurrentThemeName = "Silver";
      Text = Text.Replace("Pinkmetheus", "Prometheus"); // Cleanup shenanigans.
    }

    private void biViewScreenUIThemeWhite_Click(object sender, EventArgs e)
    {
      RibbonPredefinedColorSchemes.ChangeOffice2007ColorTable(eOffice2007ColorScheme.Silver,
                                                              Color.FromArgb(255, 255, 255));
      uihelperCurrentThemeName = "White";
      Text = Text.Replace("Pinkmetheus", "Prometheus"); // Cleanup shenanigans.
    }

    private void VistaOnlybiViewScreenUIThemeAeroGlass_Click(object sender, EventArgs e)
    {
      string text;

      if (!VistaOnlybiViewScreenUIThemeAeroGlass.Checked) // If the user is changing back to Glass from Custom
        text =
          "Restoring Aero Glass will require an application restart.\n\nDo you wish to proceed and initiate an application restart?";
      else
        text =
          "To restore Aero Glass later, an application restart will be\nrequired at that time.\n\nDo you wish to proceed?";

      DialogResult answer =
        MessageBoxEx.Show(text, "Restoring Glass Requires Application Restart", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

      if (answer.Equals(DialogResult.Yes))
      {
        VistaOnlybiViewScreenUIThemeAeroGlass.Checked = !VistaOnlybiViewScreenUIThemeAeroGlass.Checked;
        EnableGlass = VistaOnlybiViewScreenUIThemeAeroGlass.Checked;

        if (VistaOnlybiViewScreenUIThemeAeroGlass.Checked)
        {
          Process.Start(Application.StartupPath + @"\Prometheus.exe", "-restart");
          Application.Exit();
        }
      }
    }

    #endregion

    #endregion

    #region Rendering



    #endregion

    #endregion

    #region World Tab

    /// <summary>
    /// Enables or disables controls for the World tab as appropriate, based on the loaded SceneType and available tag data.
    /// </summary>
    private void rtiWorld_SceneLoaded()
    {
      bool isScenario = (RenderCore.ActiveSceneState.SceneType == SceneType.Scenario);

      // Enable Comment, Object Placement, and Randomize RibbonBars if the loaded scene is a Scenario.
      rbWorldComment.Enabled = rbWorldObjectPlacement.Enabled = rbWorldRandomize.Enabled = isScenario;
      
      // Conditionally enable controls for Object Positional Information.
      DNBHelper.Controls.ToggleContainerItems(icWorldPosInfoObject.SubItems, isScenario);
    }

    /// <summary>
    /// Update any ribbon bar items containing read-only core info, such as camera
    /// position, object position, etc in this handler.
    /// </summary>
    private void timerCoreGuiUpdates_Tick(object sender, EventArgs e)
    {
      if (!rbWorldPosInfo.Visible) // Do not update positional information if the user cannot even see it.
        return;

      txtbiWorldJumpToX.Enabled = !core.CameraMoved;
      txtbiWorldJumpToY.Enabled = !core.CameraMoved;
      txtbiWorldJumpToZ.Enabled = !core.CameraMoved;

      if (!core.CameraMoved) // If the camera has not been updated, do not update the labels.
        return;

      rbWorldPosInfo.SuspendLayout(); // Stop layout until text is updated.

      // Camera Position
      string CameraX = String.Format("{0:F3}", core.CameraX),
             CameraY = String.Format("{0:F3}", core.CameraY),
             CameraZ = String.Format("{0:F3}", core.CameraZ);

      liWorldPosInfoCameraXValue.Text = CameraX;
      liWorldPosInfoCameraYValue.Text = CameraY;
      liWorldPosInfoCameraZValue.Text = CameraZ;

      txtbiWorldJumpToX.ControlText = CameraX;
      txtbiWorldJumpToY.ControlText = CameraY;
      txtbiWorldJumpToZ.ControlText = CameraZ;

      // Selected Object Position
      if (core.ObjectSelected)
      {
        liWorldPosInfoObjectXValue.Text = string.Format("{0:F3}", core.SelectedObjectX);
        liWorldPosInfoObjectYValue.Text = string.Format("{0:F3}", core.SelectedObjectY);
        liWorldPosInfoObjectZValue.Text = string.Format("{0:F3}", core.SelectedObjectZ);
      }

      rbWorldPosInfo.ResumeLayout(); // Resume layout after text is updated.

      core.CameraMoved = false;
    }

    /// <summary>
    /// Instead of cluttering the UI with the '-' sign, colors are used to indicate if
    /// a value is positive or negative.
    /// 
    /// This function checks if the number is positive or negative, then updates the
    /// color accordingly; if the number is negative, the '-' character is removed.
    /// </summary>
    private void liWorldPosInfo_TextChanged(object sender, EventArgs e)
    {
      Interfaces.Helpers.Strings.ColorizeNumericLabelItem((LabelItem)sender);
    }

    private void rbWorldJumpTo_InputTextChanged(object sender)
    {
      if (txtbiWorldJumpToX.Focused ||
          txtbiWorldJumpToY.Focused ||
          txtbiWorldJumpToZ.Focused)
      {
        float x, y, z;

        try
        {
          x = float.Parse(txtbiWorldJumpToX.ControlText);
        }
        catch (FormatException)
        {
          x = core.CameraX;
          txtbiWorldJumpToX.ControlText = x.ToString();
          Trace.WriteLine("Error setting camera position. Check 'X' coordinate.");
        }

        try
        {
          y = float.Parse(txtbiWorldJumpToY.ControlText);
        }
        catch (FormatException)
        {
          y = core.CameraY;
          txtbiWorldJumpToY.ControlText = y.ToString();
          Trace.WriteLine("Error setting camera position. Check 'Y' coordinate.");
        }

        try
        {
          z = float.Parse(txtbiWorldJumpToZ.ControlText);
        }
        catch (FormatException)
        {
          z = core.CameraZ;
          txtbiWorldJumpToZ.ControlText = z.ToString();
          Trace.WriteLine("Error setting camera position. Check 'Z' coordinate.");
        }

        core.SetCameraPosition(x, y, z);
      }
    }

    private void rbWorldRandomize_Click(object sender, EventArgs e)
    {
      core.RandomizeObjectRotation(
        cboxWorldRandomizeRoll.Checked,
        cboxWorldRandomizePitch.Checked,
        cboxWorldRandomizeYaw.Checked);
    }

    private void biWorldCameraSettingsSpeed_TextChanged(object sender, EventArgs e)
    {
      // TODO: Grenadiac
      // Expose Core property for Camera speed.

      // core.CameraSpeed = biWorldCameraSettingsSpeed.Text;
    }

    private void biWorldCameraSettingsSensitivity_TextChanged(object sender, EventArgs e)
    {
      // TODO: Grenadiac
      // Expose Core property for Camera sensitivity.

      // core.CameraSensitivity = biWorldCameraSettingsSensitivity.Text;
    }

    #endregion

    #region Model Tab

    /// <summary>
    /// Enables or disables controls for the Model tab as appropriate, based on the loaded SceneType and available tag data.
    /// </summary>
    private void rtiModel_SceneLoaded()
    {
      // TODO: Conditionally enable UI elements based on the SceneType of the active scene.
    }

    #endregion

    #region Additional Ribbon Buttons

    private void biPromRibbonHideToggle_Click(object sender, EventArgs e)
    {
      rcPromRibbon.Expanded = !rcPromRibbon.Expanded;

      if (rcPromRibbon.Expanded)
      {
        biPromRibbonHideToggle.Image = Resources.navigate_up16;
        stRibbon.SetSuperTooltip(biPromRibbonHideToggle,
                                 new SuperTooltipInfo("Minimize Ribbon (Ctrl + Alt + M)", "",
                                                      "Pull the ribbon up to free up workspace.", null, null,
                                                      eTooltipColor.BlueMist, true, false, new Size(0, 0)));
      }
      else
      {
        biPromRibbonHideToggle.Image = Resources.navigate_down16;
        stRibbon.SetSuperTooltip(biPromRibbonHideToggle,
                                 new SuperTooltipInfo("Maximize Ribbon (Ctrl + Alt + M)", "",
                                                      "Expand the ribbon to make navigation easier.", null, null,
                                                      eTooltipColor.BlueMist, true, false, new Size(0, 0)));
      }
    }

    #endregion

    #region Quick Access Toolbar

    private void biQatSave_Click(object sender, EventArgs e)
    {
      SaveCurrentDocument();
    }

    private void biQatUndo_Click(object sender, EventArgs e)
    {
      if (core.DocumentManager.ActiveDocument != null)
        if (core.DocumentManager.ActiveDocument is ISupportsUndoRedo)
          (core.DocumentManager.ActiveDocument as ISupportsUndoRedo).Undo();
    }

    private void biQatRedo_Click(object sender, EventArgs e)
    {
      if (core.DocumentManager.ActiveDocument != null)
        if (core.DocumentManager.ActiveDocument is ISupportsUndoRedo)
          (core.DocumentManager.ActiveDocument as ISupportsUndoRedo).Redo();
    }

    #endregion

    #region Shared Events

    #region Rendering States

    // Get Render State
    private void biRenderingState_PopupOpen(object sender, PopupOpenEventArgs e)
    {
      // Make sure that each button has a RenderState associated with it.
#if DEBUG
      List<string> states = new List<string>();

      foreach (string state in Enum.GetNames(typeof(Core.Rendering.RenderState)))
      {
        states.Add(state);
      }

      foreach (BaseItem baseItem in (sender as ButtonItem).SubItems)
      {
        if (!(baseItem is ButtonItem))
          continue;

        ButtonItem bi = (baseItem as ButtonItem);

        foreach (string rs in Enum.GetNames(typeof(Core.Rendering.RenderState)))
        {
          if (bi.Tag.Equals(rs))
            states.Remove(rs);
        }
      }

      if (states.Count > 0)
      {
        StringBuilder sb = new StringBuilder();

        foreach (string str in states)
          sb.AppendLine("   - " + str);

        MessageBox.Show("There are no corresponding buttons for the following MdxRender.RenderState enum values:\n\n" + sb.ToString()
                        + "\nTo remedy this, update the Tag values of the state buttons so they match their appropriate RenderState enum name.");
      }
#endif

      foreach (BaseItem baseItem in (sender as ButtonItem).SubItems)
      {
        if (!(baseItem is ButtonItem))
          continue;

        ButtonItem bi = (baseItem as ButtonItem);

        if (bi.Tag.Equals(RenderCore.ActiveSceneState.RenderState.ToString()))
          bi.Checked = true;
      }
    }

    private void biRenderingState_PopupFinalized(object sender, EventArgs e)
    {
      foreach (BaseItem baseItem in (sender as ButtonItem).SubItems)
      {
        if (!(baseItem is ButtonItem))
          continue;

        (baseItem as ButtonItem).Checked = false;
      }
    }

    // Set Render State
    private void biRenderingStateTextured_Click(object sender, EventArgs e)
    {
      RenderCore.ActiveSceneState.RenderState = Core.Rendering.RenderState.Textured;
    }

    private void biRenderingStateWireframe_Click(object sender, EventArgs e)
    {
      RenderCore.ActiveSceneState.RenderState = Core.Rendering.RenderState.Wireframe;
    }

    private void biRenderingStateOverlay_Click(object sender, EventArgs e)
    {
      RenderCore.ActiveSceneState.RenderState = Core.Rendering.RenderState.Overlay;
    }

    #endregion

    #endregion

    private void RibbonTabItem_MouseHover(object sender, EventArgs e)
    {
      RibbonTabItem rti = (sender as RibbonTabItem);

      rti.Select();

      if (!rcPromRibbon.Expanded)
        rcPromRibbon.PopupRibbon(rti, eEventSource.Code);
    }

    private void buttonItemToggleCheck(object sender, EventArgs e)
    {
      (sender as ButtonItem).Checked = !(sender as ButtonItem).Checked;
    }

    #endregion

    #region Panes Events (Viewport, Task Panes, etc.)

    #region Viewport

    private void barViewport_Enter(object sender, EventArgs e)
    {
      core.RenderWindow_GotFocus(sender, e);
    }

    private void barViewport_Leave(object sender, EventArgs e)
    {
      core.RenderWindow_LostFocus(sender, e);
    }

    Point corehelperViewportLocalMouseLocation = Point.Empty;
    private void renderViewport_MouseUp(object sender, MouseEventArgs e)
    {
      core.RenderWindow_MouseUp(sender, e);

      corehelperViewportLocalMouseLocation = e.Location;

      if (e.Button == MouseButtons.Right)
      {
        Point pScreen = barViewport.PointToScreen(e.Location);

        switch (core.SelectedObjectType)
        {
          case TargetType.None:
          case TargetType.LevelMesh:
            cmnuWorldPalettes.Popup(pScreen);
            break;
          case TargetType.Object:
            cmnuWorldObject.Popup(pScreen);
            break;
            // TODO: As more object menus are added, they need to be 'hooked up' here.
        }
      }
      else if (e.Button == MouseButtons.Middle)
        corehelperMiddleMouseButtonActive = false;
    }

    bool corehelperMiddleMouseButtonActive;
    private void renderViewport_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Middle)
        corehelperMiddleMouseButtonActive = true;

      core.RenderWindow_MouseDown(sender, e);

      // Added here so renderViewport_Click could be removed
      txtbHUGEHACK.Focus();
      core.MdxInputAquired = true;

      renderViewport.Focus(); // Needed for renderViewport_MouseWheel to work.
    }

    private void renderViewport_MouseMove(object sender, MouseEventArgs e)
    {
      core.RenderWindow_MouseMove(sender, e);
    }

    /// <summary>
    /// The mouse wheel functionality is designed to act as "zip line" to quickly get around the
    /// map when scrolled. However, if the mouse wheel is pressed, it instead acts as a camera
    /// speed control with 10 unit increments.
    /// </summary>
    private void renderViewport_MouseWheel(object sender, MouseEventArgs e)
    {
      int rotations = (e.Delta / 120) * -1; // Multiplication by negative one to correct the sign. Default signage is not applicable to our use cases.

      if (corehelperMiddleMouseButtonActive)
      {
        for (int i = 0; i < Math.Abs(rotations); i++)
        {
          // TODO: CameraSpeed property needs to be added to core.

          //core.CameraSpeed += 10 * Math.Sign(rotations); // Adds or subtracts 10 units from the camera speed.
          float units = (float)(rotations * 1.5); // World units to move.

          core.MoveCamera(-1*units);
        }
      }
      else
      {
        float units = (float)(rotations * 1.5); // World units to move.
        
        core.MoveCamera(units);
      }
    }

    private void renderViewport_MouseEnter(object sender, EventArgs e)
    {
      renderViewport.Focus(); // Needed for renderViewport_MouseWheel to work.

      core.RenderWindow_MouseEnter(sender, e);
      core.MdxInputAquired = true;
    }

    private void renderViewport_MouseLeave(object sender, EventArgs e)
    {
      txtbHUGEHACK.Focus(); // Needed for renderViewport_MouseWheel to work.

      core.RenderWindow_MouseLeave(sender, e);
      core.MdxInputAquired = false;
    }

    private void renderViewport_Resize(object sender, EventArgs e)
    {
      if (core != null)
      {
        core.ProcessResize(renderViewport.Width, renderViewport.Height);
        Trace.WriteLine("GUI window size = " + renderViewport.Width + ", " + renderViewport.Height);
      }
    }

    private void renderViewport_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        SimpleContainers.Vector3D intersectionVector = core.IntersectScene(e.Location.X, e.Location.Y);
        SimpleContainers.Vector3D cameraVector = core.GetCameraVector(core.CameraX, core.CameraY, core.CameraZ, intersectionVector.X, intersectionVector.Y, intersectionVector.Z, 2.0f);
				core.SetCameraLookDirection(core.CameraX, core.CameraY, core.CameraZ, cameraVector.X, cameraVector.Y, cameraVector.Z);
        core.SetCameraPosition(cameraVector.X, cameraVector.Y, cameraVector.Z);
      }
    }

    #region World Object Context Menu

    #region Menu Configuration on Popup

    private int instanceNumber = 7; // Temp, duh.
    private string objectName = "Warthog"; // Temp, duh.
    private string uihelperWorldObjectLastTheme = String.Empty;

    private void cmnuWorldObject_PopupOpen(object sender, PopupOpenEventArgs e)
    {
      #region Theme Support for Labels

      // Check if the theme has changed since the menu was last displayed.
      if (!uihelperWorldObjectLastTheme.Equals(uihelperCurrentThemeName))
      {
        DNBHelper.Controls.ThemeMenuLabel(cmiWorldObject);
        DNBHelper.Controls.ThemeMenuLabel(cmiWorldObjectAnimation);
        DNBHelper.Controls.ThemeMenuLabel(cmiWorldObjectManipulate);

        uihelperWorldObjectLastTheme = uihelperCurrentThemeName;
      }

      #endregion

      string instanceName = "   <b>" + objectName + " #" + instanceNumber + "</b>";
      int dividerOffset = instanceName.LastIndexOf('#');

      // Labels
      if (!cmiWorldObject.Text.Contains(instanceName.Substring(0, dividerOffset))) // If the object type is not the same ...
      {
        cmiWorldObject.Text = instanceName;
        cmiWorldObjectDuplicateObject.Text = "&Duplicate " + objectName;
        cmiWorldObjectEditTag.Text = "&Edit " + objectName + " Tag";
        cmiWorldObjectViewObject.Text = "&View " + objectName;
        cmiWorldObjectLockObject.Text = "&Lock " + objectName;

        cmiWorldObjectAnimation.Text = objectName + " Animations";

        cmiWorldObjectManipulate.Text = "Manipulate " + objectName;
        cmiWorldObjectManipulateSnapToSurfaceAboveObject.Text = "&Above " + objectName;
        cmiWorldObjectManipulateSnapToSurfaceBelowObject.Text = "&Below " + objectName;
        cmiWorldObjectManipulateResetObject.Text = "Reset " + objectName;
      }
      else if (!cmiWorldObject.Text.Contains(instanceName.Substring(dividerOffset))) // If the instance is not the same ...
      {
        cmiWorldObject.Text = instanceName; // Update the instanceName to reflect the new instance number.
      }

      // Animations
      if (cmiWorldObjectAnimationPlayAnimation.Items.Count == 0) // TODO: Make this compare the object and instance model animation tagrefs. No need to re-populate if it's the same model animation tag.
      {
        // Populate animation list with animation names.
        cmiWorldObjectAnimationPlayAnimation.Items.AddRange(
          new object[] { "Test Animation One", "Test Animation Two", "Dance Dance Dance Dance Dance", "One Two One", "Seizure" });
      }

      if (!cmiWorldObjectAnimationPlayAnimation.Visible) // TODO: Check if the selected instance has an active animation (i.e. instance.Animation.IsActive).
      {
        cmiWorldObjectAnimationPlayAnimation.SelectedIndex =
          cmiWorldObjectAnimationPlayAnimation.Items.IndexOf("Dance Dance Dance Dance Dance"); // TODO: Set this based on instance (i.e. instance.Animation.Index).
        cmiWorldObjectAnimationPlayAnimation_Click(null, EventArgs.Empty); // Ensures the animation playback controls are displayed and the animation list is hidden.

        cmiWorldObjectAnimationPauseAnimation_Configure(); // Ensures the proper animation playback controls are displayed if the animation is paused.
      }
      else
      {
        cmiWorldObjectAnimationPlayAnimation.SelectedIndex = -1; // Reset the animation list selection.
        cmiWorldObjectAnimationStopAnimation_Click(null, EventArgs.Empty); // Ensures the animation playback controls are hidden and the animation list is displayed.
      }

      // Lock Status
      cmiWorldObjectLockObject_Configure(); // Ensures the proper UI updates occur depending on the lock status of the selected instance.
    }

    #endregion

    #region Object Action Events

    private void cmiWorldObjectDuplicateObject_Click(object sender, EventArgs e)
    {
      // TODO: Create a copy of the selected object and place it to the right of the existing instance.
      objectName = "Banshee"; // DEBUG LINE - delete when fully implemented.
    }

    private void cmiWorldObjectEditTag_Click(object sender, EventArgs e)
    {
      // TODO: Open the object tag in the Tag Editor.
      Random rnd = new Random(DateTime.Now.Millisecond); // DEBUG LINE - delete when fully implemented.
      instanceNumber = rnd.Next(9999); // DEBUG LINE - delete when fully implemented.
    }

    private void cmiWorldObjectViewObject_Click(object sender, EventArgs e)
    {
      // TODO: Load the model in the Model Viewer and switch to it.
    }

    private bool locked = false; // Temp, duh.
    private void cmiWorldObjectLockObject_Click(object sender, EventArgs e)
    {
      locked = !locked; // TODO: Set the lock status (i.e. instance.IsLocked = !instance.IsLocked).

      cmiWorldObjectLockObject_Configure();
        // REMOVE once above TODO is completed. Note: cmiWorldObjectLockObject_Configure() should be called every time IsLocked changes; this should occur in the property set.
    }

    private void cmiWorldObjectLockObject_Configure()
    {
      if (locked) // TODO: Check the lock status based on the selected instance (i.e. instance.IsLocked).
      {
        cmiWorldObject.Image = Resources.lock16;

        cmiWorldObjectLockObject.Image = Resources.lock_open16;
        cmiWorldObjectLockObject.Text = "&Unlock " + objectName;
        stContextMenus.SetSuperTooltip(cmiWorldObjectLockObject,
                                       new SuperTooltipInfo("Unlock Object", "",
                                                            "Allow the object to be moved or rotated freely.", null,
                                                            null, eTooltipColor.Default, true, false, new Size(0, 0)));

        // TODO: Lock edit controls (translate / rotate widget should regress to a "Select Only" mode, where the user cannot modify the position or rotation values).
      }
      else
      {
        cmiWorldObject.Image = Resources.lock_open16;

        cmiWorldObjectLockObject.Image = Resources.lock16;
        cmiWorldObjectLockObject.Text = "&Lock " + objectName;
        stContextMenus.SetSuperTooltip(cmiWorldObjectLockObject,
                                       new SuperTooltipInfo("Lock Object", "",
                                                            "Prevent the object from being moved or rotated until it is unlocked.",
                                                            null, null, eTooltipColor.Default, true, false,
                                                            new Size(0, 0)));

        // TODO: Unlock edit controls (translate / rotate widget should revert to "Full" mode, where the user can modify the position and rotation values).
      }

      cmiWorldObjectManipulateSnapToNormal.Enabled = !locked;
      cmiWorldObjectManipulateRandomizeYPR.Enabled = !locked;
      cmiWorldObjectManipulateResetObject.Enabled = !locked;
    }

    #endregion

    #region Animation Events

    private void cmiWorldObjectAnimationPlayAnimation_Click(object sender, EventArgs e)
    {
      if (cmiWorldObjectAnimationPlayAnimation.SelectedIndex < 0)
        return;

      // TODO: Change this to a SelectedIndexChanged event with it is added to DNB.

      cmiWorldObjectAnimationPlayAnimation.Visible = false;
      cmiWorldObjectAnimationRestartAnimation.Visible = true;
      cmiWorldObjectAnimationPauseAnimation.Visible = true;
      cmiWorldObjectAnimationStopAnimation.Visible = true;

      cmiWorldObjectAnimation.Text = cmiWorldObjectAnimationPlayAnimation.SelectedItem.ToString();
      cmiWorldObjectAnimation.Tooltip = cmiWorldObjectAnimation.Text;
      cmiWorldObjectAnimation.Width = 150;

      // TODO: Set the animation as active (i.e. instance.Animation.IsActive = true).

      // TODO: Set the selected animation index (i.e. instance.Animation.Index = cmiBspObjectAnimationPlayAnimation.SelectedIndex).

      // TODO: Check if the selected animation is loaded already or not. If it is not, load and begin playing it.
    }

    private void cmiWorldObjectAnimationRestartAnimation_Click(object sender, EventArgs e)
    {
      // TODO: Restart the animation from the first frame.
    }

    private bool paused = false; // Temp, duh.
    private void cmiWorldObjectAnimationPauseAnimation_Click(object sender, EventArgs e)
    {
      paused = !paused;
        // TODO: Set the animation pause status (i.e. instance.Animation.IsPaused = !instance.Animation.IsPaused).

      cmiWorldObjectAnimationPauseAnimation_Configure();
        // REMOVE once above TODO is completed. Note: cmiWorldObjectAnimationPauseAnimation_Configure() should be called every time IsPaused changes; this should occur in the property set.
    }

    private void cmiWorldObjectAnimationPauseAnimation_Configure()
    {
      if (paused) // TODO: Check the paused status based on the selected instance (i.e. instance.Animation.IsPaused).
      {
        cmiWorldObjectAnimationPauseAnimation.Image = Resources.media_play_green16;
        cmiWorldObjectAnimationPauseAnimation.Text = "&Play Animation";
        stContextMenus.SetSuperTooltip(cmiWorldObjectAnimationPauseAnimation,
                                       new SuperTooltipInfo("Play Animation", "",
                                                            "Resume playback of the animation from its current frame.",
                                                            null, null, eTooltipColor.Default, true, false,
                                                            new Size(0, 0)));

        cmiWorldObjectAnimationStopAnimation.Image = Resources.navigate_cross10;
        cmiWorldObjectAnimationStopAnimation.Text = "&Close Animation";
        stContextMenus.SetSuperTooltip(cmiWorldObjectAnimationStopAnimation,
                                       new SuperTooltipInfo("Close Animation", "",
                                                            "Close the animation and return the model to its original state.<br /><br />After the animation has been closed, you may select a new animation.",
                                                            null, null, eTooltipColor.Default, true, false,
                                                            new Size(0, 0)));

        // TODO: Pause the animation as it is.
      }
      else
      {
        cmiWorldObjectAnimationPauseAnimation.Image = Resources.media_pause16;
        cmiWorldObjectAnimationPauseAnimation.Text = "&Pause Animation";
        stContextMenus.SetSuperTooltip(cmiWorldObjectAnimationPauseAnimation,
                                       new SuperTooltipInfo("Pause Animation", "",
                                                            "Freeze the animation on its current frame.", null, null,
                                                            eTooltipColor.Default, true, false, new Size(0, 0)));

        cmiWorldObjectAnimationStopAnimation.Image = Resources.media_stop_red16;
        cmiWorldObjectAnimationStopAnimation.Text = "&Stop Animation";
        stContextMenus.SetSuperTooltip(cmiWorldObjectAnimationStopAnimation,
                                       new SuperTooltipInfo("Stop Animation", "",
                                                            "Halt all playback of the animation and return the model to its original state.<br /><br />After the animation has been stopped, you may select a new animation.",
                                                            null, null, eTooltipColor.Default, true, false,
                                                            new Size(0, 0)));

        // TODO: Resume playing the animation.
      }
    }

    private void cmiWorldObjectAnimationStopAnimation_Click(object sender, EventArgs e)
    {
      // TODO: Stop the animation playback.

      cmiWorldObjectAnimationPlayAnimation.Visible = true;
      cmiWorldObjectAnimationRestartAnimation.Visible = false;
      cmiWorldObjectAnimationPauseAnimation.Visible = false;
      cmiWorldObjectAnimationStopAnimation.Visible = false;

      cmiWorldObjectAnimation.Text = objectName + " Animations";
      cmiWorldObjectAnimation.Tooltip = String.Empty;
      cmiWorldObjectAnimation.Width = 0;

      // TODO: Set the animation as inactive (i.e. instance.Animation.IsActive = false). Note: When IsActive is changed to false, IsPaused should also change to false; this should occur in the property set.
      paused = false;
      cmiWorldObjectAnimationPauseAnimation_Configure();
        // REMOVE once above TODO is completed. Note: cmiWorldObjectAnimationPauseAnimation_Configure() should be called every time IsPaused changes; this should occur in the property set.

      // TODO: Revert the selected animation index (i.e. instance.Animation.Index = -1). Note: Leave cmiBspObjectAnimationPlayAnimation.SelectedIndex alone.
    }

    #endregion

    #region Manipulation Events

    private void cmiWorldObjectManipulateSnapToNormal_Click(object sender, EventArgs e)
    {
      // TODO: Snap the model to the nearest normal, regardless of its direction.
    }

    private void cmiWorldObjectManipulateSnapToSurface_Click(object sender, EventArgs e)
    {
      // TODO: Snap the model to the nearest surface, regardless of its direction.
    }

    private void cmiWorldObjectManipulateSnapToSurfaceAboveObject_Click(object sender, EventArgs e)
    {
      // TODO: Snap the model to the nearest surface above the selected object.
    }

    private void cmiWorldObjectManipulateSnapToSurfaceBelowObject_Click(object sender, EventArgs e)
    {
      // TODO: Snap the model to the nearest surface below the selected object.
    }

    private void cmiWorldObjectManipulateRandomizeYPR_Click(object sender, EventArgs e)
    {
      cmiWorldObjectManipulateRandomizeYPRYawOnly_Click(sender, e);
      cmiWorldObjectManipulateRandomizeYPRPitchOnly_Click(sender, e);
      cmiWorldObjectManipulateRandomizeYPRRollOnly_Click(sender, e);
    }

    private void cmiWorldObjectManipulateRandomizeYPRYawOnly_Click(object sender, EventArgs e)
    {
      // TODO: Randomize the selected instance's yaw value;
    }

    private void cmiWorldObjectManipulateRandomizeYPRPitchOnly_Click(object sender, EventArgs e)
    {
      // TODO: Randomize the selected instance's pitch value;
    }

    private void cmiWorldObjectManipulateRandomizeYPRRollOnly_Click(object sender, EventArgs e)
    {
      // TODO: Randomize the selected instance's roll value;
    }

    private void cmiWorldObjectManipulateResetObject_Click(object sender, EventArgs e)
    {
      DialogResult result =
        MessageBoxEx.Show(
          "Resetting the " + objectName +
          " means that all properties\nset for this instance will be replaced by defaults.\n\nDo you wish to reset the " +
          objectName + "?", "Reset " + objectName + " Instance", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
          MessageBoxDefaultButton.Button2);

      if (result == DialogResult.Yes)
      {
        // TODO: Reset the object instance properties to defaults.
      }
    }

    #endregion

    #endregion

    #region World Palettes Context Menu

    private class ObjectID
    {
      public int PaletteID;
      public string ObjectName;
    }

    private string uihelperWorldPalettesLastTheme = String.Empty;
    private int cmnuWorldPalettesMruLimit = 3;
    private int cmnuWorldPalettesMruMemory = 15;
    private List<BaseItem> cmnuWorldPalettesMruList = new List<BaseItem>();
    
    private void cmnuWorldPalettes_PopupOpen(object sender, PopupOpenEventArgs e)
    {
      #region Theme Support for Labels

      // Check if the theme has changed since the menu was last displayed.
      if (!uihelperWorldPalettesLastTheme.Equals(uihelperCurrentThemeName))
      {
        DNBHelper.Controls.ThemeMenuLabel(cmiWorldPalettesRecentObjects);
        DNBHelper.Controls.ThemeMenuLabel(cmiWorldPalettesScenarioPalettes);

        uihelperWorldPalettesLastTheme = uihelperCurrentThemeName;
      }

      #endregion

      // Make sure we're actually in a scenario.
      if (core.ScenarioPalettes == null || core.ScenarioPaletteEntries == null)
      {
        e.Cancel = true;
        return;
      }

      #region Populate Recent Objects Container

      ItemContainer mruContainer = new ItemContainer();
      foreach (BaseItem item in cmnuWorldPalettesMruList)
      {
        if (cmiWorldPalettesRecentObjectsContainer.SubItems.Count < cmnuWorldPalettesMruLimit)
          cmiWorldPalettesRecentObjectsContainer.SubItems.Add(item);
        else
        {
          if (!cmiWorldPalettesRecentObjectsContainer.SubItems.Contains(cmiWorldPalettesRecentObjectsMore))
          {
            cmiWorldPalettesRecentObjectsContainer.SubItems.Add(cmiWorldPalettesRecentObjectsMore);
            cmiWorldPalettesRecentObjectsMore.Visible = true;

            if ((cmnuWorldPalettesMruList.Count - cmnuWorldPalettesMruLimit) > 10)
            {
              mruContainer = new GalleryContainer();
              ((GalleryContainer)mruContainer).EnableGalleryPopup = false;
              ((GalleryContainer)mruContainer).IncrementalSizing = true;
              ((GalleryContainer)mruContainer).DefaultSize = new Size(0, 189);
              ((GalleryContainer)mruContainer).PopupUsesStandardScrollbars = true;
            }
            else
            {
              mruContainer = new ItemContainer();
              mruContainer.MinimumSize = new Size(150, 0);
            }

            mruContainer.LayoutOrientation = eOrientation.Vertical;
            mruContainer.MultiLine = false;

            cmiWorldPalettesRecentObjectsMore.SubItems.Add(mruContainer);
          }

          mruContainer.SubItems.Add(item);
        }
      }

      #endregion

      #region Populate Palettes Container
      foreach (ScenePalette palette in core.ScenarioPalettes)
      {
        System.Collections.Generic.List<BaseItem> list = new System.Collections.Generic.List<BaseItem>();
        ItemContainer container = new ItemContainer();

        ButtonItem bi = new ButtonItem();
        bi.AutoExpandOnClick = true;
        bi.Image = palette.Image;
        bi.Name = "dynamic_palette_" + palette.Name;
        bi.Tag = palette.ID;
        bi.Text = palette.Name;

        foreach (SceneObject entry in core.ScenarioPaletteEntries)
        {
          if (entry.PaletteID == palette.ID)
          {
            string objectName = Path.GetFileNameWithoutExtension(entry.ObjectName);

            ButtonItem so = new ButtonItem();
            so.Click += new EventHandler(cmiWorldPalettesScenarioPalettesContainer_PaletteEntry_Click);
            so.FixedSize = new Size(135, 18);
            so.Name = "dynamic_palette_entry_" + objectName;

            ObjectID id = new ObjectID();
            id.PaletteID = palette.ID;
            id.ObjectName = entry.ObjectName;
            so.Tag = id;

            so.Text = objectName;
            so.Tooltip = "<b>Name:</b> " + objectName + "<br /><b>Instances:</b> 7";
            list.Add(so);
          }
        }

        if (list.Count > 10)
        {
          container = new GalleryContainer();
          ((GalleryContainer)container).EnableGalleryPopup = false;
          ((GalleryContainer)container).IncrementalSizing = true;
          ((GalleryContainer)container).DefaultSize = new Size(0, 189);
          ((GalleryContainer)container).PopupUsesStandardScrollbars = true;
        }
        else
        {
          container = new ItemContainer();
          container.MinimumSize = new Size(150, 0);
        }

        container.LayoutOrientation = eOrientation.Vertical;
        container.MultiLine = false;
        container.Name = "ic" + palette.Name;
        container.SubItems.AddRange(list.ToArray());

        if (container.SubItems.Count > 0)
        {
          bi.SubItems.Add(container);
          cmiWorldPalettesScenarioPalettesContainer.SubItems.Add(bi);
        }
      }

      foreach (ButtonItem bi in cmiWorldPalettesScenarioPalettesContainer.SubItems)
        bi.FixedSize = new Size(145, 18);
      #endregion

      #region Check Item Counts

      bool noRecentItems = (cmiWorldPalettesRecentObjectsContainer.VisibleSubItems == 0);
      bool noPalettes = (cmiWorldPalettesScenarioPalettesContainer.VisibleSubItems == 0);

      if (noRecentItems && noPalettes)
      {
        e.Cancel = true;
        return;
      }

      cmiWorldPalettesRecentObjects.Visible = noRecentItems ? false : true;
      cmiWorldPalettesScenarioPalettes.Visible = noPalettes ? false : true;

      #endregion
    }

    private void cmnuWorldPalettes_PopupFinalized(object sender, EventArgs e)
    {
      // Clear out the lists so that repopulation can occur next time the menu is opened.
      cmiWorldPalettesRecentObjectsMore.SubItems.Clear();
      cmiWorldPalettesRecentObjectsContainer.SubItems.Clear();
      cmiWorldPalettesScenarioPalettesContainer.SubItems.Clear();
    }

    private void cmiWorldPalettesScenarioPalettesContainer_PaletteEntry_Click(object sender, EventArgs e)
    {
      // Commented the following out due to the fact that there is a slight chance (very slight) that the user will actually want to place an object at (0,0), and they should rightfully be able to do so. - Swamp
      /*if (corehelperViewportLocalMouseLocation == Point.Empty)
      {
#if DEBUG
        MessageBox.Show("The menu did not popup before the palette entry was clicked"); // WTF!
#endif
        return;
      }*/

      ButtonItem selectedItem = (ButtonItem)sender;
      selectedItem.FixedSize = new Size(145, 18);

      SimpleContainers.Vector3D intersection = core.IntersectScene(corehelperViewportLocalMouseLocation.X, corehelperViewportLocalMouseLocation.Y);
      core.CreateNewObjectInstance((selectedItem.Tag as ObjectID).PaletteID, (selectedItem.Tag as ObjectID).ObjectName, intersection.X, intersection.Y, intersection.Z);

      try
      {
        // Ensure list size is below defined limit.
        while (cmnuWorldPalettesMruList.Count > (cmnuWorldPalettesMruMemory - 1)) // Limit breached.
          if (cmnuWorldPalettesMruList.Count > 0)
            cmnuWorldPalettesMruList.RemoveAt(cmnuWorldPalettesMruList.Count - 1);

        // Make sure the item is not already in the MRU list.
        bool exists = false;
        int searchResult = -1;

        for (int i = 0; i < cmnuWorldPalettesMruList.Count; i++)
        {
          if (cmnuWorldPalettesMruList[i].Name.Equals(selectedItem.Name))
          {
            exists = true;
            searchResult = i;
            break;
          }
        }

        if (exists && searchResult > -1)
        {
          // Remove the item from the MRU list so it is added to the top.
          BaseItem item = cmnuWorldPalettesMruList[searchResult];
          cmnuWorldPalettesMruList.Remove(item);
        }

        // Add the item to the MRU list.
        cmnuWorldPalettesMruList.Insert(0, selectedItem);
      }
      finally
      {
        /*
        // Unhook the click handlers from all of the palette entry buttons. Is this needed?
        foreach (ButtonItem bi in cmiWorldPalettesScenarioPalettesContainer.SubItems)
          foreach (ButtonItem entry in bi.SubItems[0].SubItems)
            entry.Click -= new EventHandler(cmiWorldPalettesScenarioPalettesContainer_PaletteEntry_Click);
        */
      }

      corehelperViewportLocalMouseLocation = Point.Empty;
    }

    private void cmiWorldPalettesOpenTagScenario_Click(object sender, EventArgs e)
    {
      OpenTagInTagEditor(core.Scenario);
    }

    private void cmiWorldPalettesOpenTagSbsp_Click(object sender, EventArgs e)
    {
      OpenTagInTagEditor(core.StructureBsp);
    }

    #endregion

    #region Model Viewer Context Menu

    private void cmiModelViewportBackgroundColor_SelectedColorChanged(object sender, EventArgs e)
    {
      core.SetViewportColor(cmiModelViewportBackgroundColor.SelectedColor);

      Bitmap color = new Bitmap(13, 13);

      for (int y = 0; y < color.Height; y++)
      {
        for (int x = 0; x < color.Width; x++)
        {
          color.SetPixel(x, y, cmiModelViewportBackgroundColor.SelectedColor);
        }
      }

      cmiModelViewportBackgroundColor.Image = color;
    }

    #endregion

    #endregion

    #region File Area

    #region Tag Document Context Menu

    private void barFileViewer_ControlAdded(object sender, ControlEventArgs e)
    {
      if (e.Control is TabStrip)
        ((TabStrip)e.Control).MouseDown += new MouseEventHandler(this.barFileViewer_TabStrip_MouseDown);
    }

    private void barFileViewer_TabStrip_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Right)
        return;

      // Do magical stuff to make the context menu appear only for tabs.
      Point pLocal = new Point(e.X, e.Y);
      Point pScreen = barFileViewer.PointToScreen(pLocal);
      TabItem tab = ((TabStrip)sender).HitTest(pLocal.X, pLocal.Y);

      if (tab != null)
        cmnuFileArea.Popup(pScreen);
    }

    private void cmiFileAreaSave_Click(object sender, EventArgs e)
    {
      SaveCurrentDocument();
    }

    private void cmiFileAreaClose_Click(object sender, EventArgs e)
    {
      CloseCurrentDocument();
    }

    #endregion

    #region Tab Panel Handling

    private bool isHidingTooltipBar = false;

    private void ipTooltipBar_Resize(object sender, EventArgs e)
    {
      const int ipTooltipBarTextPadding = 6;
      icTooltipBarFieldName.MinimumSize =
        new Size(
          ipTooltipBar.Width - biTooltipBarExpandToggle.Size.Width - biTooltipBarHideToggle.Size.Width -
          ipTooltipBarTextPadding, 0);
    }

    private void biTooltipBarHideToggle_Click(object sender, EventArgs e)
    {
      if (liTooltipBarTooltip.Visible = biTooltipBarExpandToggle.Visible = isHidingTooltipBar)
      {
        ipTooltipBar.Height = icTooltipBarFieldName.Size.Height + 44;
        biTooltipBarHideToggle.Image = Resources.element_down16;
        stRibbon.SetSuperTooltip(biTooltipBarHideToggle,
                                 new SuperTooltipInfo("Minimize Tooltip", "", "Shrink the tooltip area.", null, null,
                                                      eTooltipColor.Default, true, false, new Size(0, 0)));
      }
      else
      {
        ipTooltipBar.Height = icTooltipBarFieldName.Size.Height + 6;
        biTooltipBarHideToggle.Image = Resources.element_up16;
        stRibbon.SetSuperTooltip(biTooltipBarHideToggle,
                                 new SuperTooltipInfo("Restore Tooltip", "", "Restore the tooltip area.", null, null,
                                                      eTooltipColor.Default, true, false, new Size(0, 0)));
      }

      biTooltipBarHideToggle.ImageSize = new Size(12, 12);
      isHidingTooltipBar = !isHidingTooltipBar;
      ipTooltipBar_Resize(ipTooltipBar, EventArgs.Empty);
    }

    private void biTooltipBarExpandToggle_Click(object sender, EventArgs e)
    {
      if (biTooltipBarHideToggle.Visible = isExpandedTooltipBar)
      {
        ipTooltipBar.Height = icTooltipBarFieldName.Size.Height + 44;
        biTooltipBarExpandToggle.Image = Resources.navigate_up16;
        stRibbon.SetSuperTooltip(biTooltipBarExpandToggle,
                                 new SuperTooltipInfo("Expand Tooltip", "", "See the full tooltip.", null, null,
                                                      eTooltipColor.Default, true, false, new Size(0, 0)));
      }
      else
      {
        ipTooltipBar.Height = icTooltipBarFieldName.Size.Height + 94;
        biTooltipBarExpandToggle.Image = Resources.navigate_down16;
        stRibbon.SetSuperTooltip(biTooltipBarExpandToggle,
                                 new SuperTooltipInfo("Collapse Tooltip", "", "Reduce tooltip area size.", null, null,
                                                      eTooltipColor.Default, true, false, new Size(0, 0)));
      }

      biTooltipBarExpandToggle.ImageSize = new Size(10, 10);
      isExpandedTooltipBar = !isExpandedTooltipBar;
      ipTooltipBar_Resize(ipTooltipBar, EventArgs.Empty);
    }

    private void ipWarningBar_Resize(object sender, EventArgs e)
    {
      icWarningBar.MinimumSize = new Size(ipWarningBar.Size.Width, ipWarningBar.Size.Height - 2);
      liWarningBarWarning.Width = ipWarningBar.Size.Width - 24;
    }

    private void tcFileArea_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
    {
      e.OldTab.AttachedControl.Controls.Remove(ipWarningBar);
      e.NewTab.AttachedControl.Controls.Add(ipWarningBar);
      e.OldTab.AttachedControl.Controls.Remove(ipTooltipBar);
      e.NewTab.AttachedControl.Controls.Add(ipTooltipBar);
    }

    #endregion

    #endregion

    #region Task Panes

    #region Library Explorer

    private void LibraryExplorer_PreviewTag(object sender, OpenTagEventArgs e)
    {
      try
      {
        //TagPath path = new TagPath(e.TagPath.Path + "." + e.TagPath.Extension, e.TagPath.Game, TagLocation.Archive, String.Empty);
        Core.Prometheus.Instance.OnAddScene(e.TagPath);
      }
      catch (TagAlreadyExistsException ex)
      {
        Output.Write(OutputTypes.Warning, ex.Message);
      }
      catch (PoolException ex)
      {
        Output.Write(OutputTypes.Warning, ex.Message);
      }
    }

    #endregion

    #endregion

    #region Output Panes

    #endregion

    #endregion

    #region DocumentManager Integration

    private void DocumentManager_DocumentClosed(string documentIdentifier, bool fromGUI)
    {
      if (fromGUI) return;
      DockContainerItem item = LocateDocument(documentIdentifier);
      if (item != null)
        barFileViewer.CloseDockTab(item);
    }

    private void DocumentManager_DocumentRenamed(IDocument document, string oldPath)
    {
      DockContainerItem item = LocateDocument(oldPath);
      if (item != null)
        item.Tag = document.DocumentFilename;
    }

    private void DocumentManager_DirtyDocumentClosing(IDocument document, DocumentSavingEventArgs action)
    {
      DialogResult result =
        MessageBoxEx.Show(
          "There are unsaved changes to the file '" + document.DocumentTitle +
          "'.  Would you like to save the changes before closing?",
          "Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
      if (result == DialogResult.Yes)
        action.Action = SaveAction.SaveChanges;
      else if (result == DialogResult.No)
        action.Action = SaveAction.IgnoreChanges;
      else
        action.Action = SaveAction.Cancel;
    }

    #region Control Event Handlers

    private void barFileViewer_DockTabClosing(object sender, DockTabClosingEventArgs e)
    {
      if (e.DockContainerItem.Control == null) return;
      if (!(e.DockContainerItem.Control is IDocument)) return;
      e.Cancel = !(core.DocumentManager.CloseDocument(e.DockContainerItem.Control as IDocument, true));
    }

    private void barFileViewer_DockTabChange(object sender, DockTabChangeEventArgs e)
    {
      barFileViewer.Visible = true;
      DockContainerItem item = e.NewTab as DockContainerItem;
      if (item.Control == null) return;
      if (!(item.Control is IDocument)) return;
      core.DocumentManager.ActivateDocument(item.Control as IDocument, true);
    }

    #endregion

    #region DocumentManager Event Handlers

    /// <summary>
    /// Sets up an IDocument-based control within a container tab and adds it to the UI.
    /// Handles the DocumentManager.DocumentOpened event.
    /// </summary>
    private void DocumentManager_DocumentOpened(IDocument document, bool fromGUI)
    {
      if (!(document is Control))
        throw new Exception("Documents must inherit from Control to be displayed.");

      Control control = document as Control;
      control.Dock = DockStyle.Fill;

      DockContainerItem dci = new DockContainerItem();
      dci.Tag = document.DocumentFilename;
      dci.Control = control;
      dci.DefaultFloatingSize = new Size(470, 680);
      dci.Image = Resources.document_plain_new16;
      UpdateDocumentTabTitle(dci, document);
      barFileViewer.Items.AddRange(new BaseItem[] {dci});
      dci.Selected = true;
    }

    /// <summary>
    /// Handles the activation of a document as instructed by the DocumentManager.
    /// </summary>
    private void DocumentManager_DocumentActivated(IDocument document, bool fromGUI)
    {
      DockContainerItem item = LocateDocument(document.DocumentFilename);
      if (item == null) return;
      if (item.Selected == false)
        item.Selected = true;
    }

    /// <summary>
    /// Handles updating the title of a document when it's state changes.
    /// </summary>
    private void DocumentManager_DocumentStateChanged(IDocument document, DocumentState state)
    {
      UpdateDocumentTabTitle(document);
    }

    #endregion

    #region Helper Methods

    private void UpdateDocumentTabTitle(IDocument document)
    {
      DockContainerItem container = LocateDocument(document.DocumentFilename);
      if (container == null) return;
      UpdateDocumentTabTitle(container, document);
    }

    private void UpdateDocumentTabTitle(DockContainerItem container, IDocument document)
    {
      string title = document.DocumentTitle;
      if (document.DocumentState == DocumentState.Dirty)
        title += "*";
      else if (document.DocumentState == DocumentState.ReadOnly)
        title += " (read-only)";
      container.Text = title;
      container.Tooltip = document.DocumentTooltip;
    }

    /// <summary>
    /// Searches through the existing DockContainerItem objects for the specified document.
    /// </summary>
    private DockContainerItem LocateDocument(string documentIdentifier)
    {
      foreach (BaseItem item in barFileViewer.Items)
      {
        if (item is DockContainerItem)
          if ((item as DockContainerItem).Tag == documentIdentifier)
            return item as DockContainerItem;
      }
      return null;
    }

    private void SaveCurrentDocument()
    {
      try
      {
        if (core.DocumentManager.ActiveDocument != null)
          core.DocumentManager.SaveDocument(core.DocumentManager.ActiveDocument);
      }
      catch (Exception ex)
      {
        Output.Write(OutputTypes.Error, "Save failed - " + ex.Message);
      }
    }

    private void CloseCurrentDocument()
    {
      if (core.DocumentManager.ActiveDocument != null)
      {
        DockContainerItem item = LocateDocument(core.DocumentManager.ActiveDocument.DocumentFilename);
        if (item != null)
          barFileViewer.CloseDockTab(item);
      }
    }

    private void SaveAllDocuments()
    {
      core.DocumentManager.SaveAllDocuments();
    }

    #endregion

    #endregion

    #region Dialog Windows

    #region Launch Dialog Windows

    private void launchBugReporter(object sender, EventArgs e)
    {
      new BugReport().Show();
    }

    private void launchPrefabExport(object sender, EventArgs e)
    {
      new PrefabExport().ShowDialog();
    }

    private void launchNewProjectDialog(object sender, EventArgs e)
    {
      new NewProjectDialog().ShowDialog();
    }

    private void launchOptions(object sender, EventArgs e)
    {
      new Options().ShowDialog();
    }

    private void launchReferenceAnalyzer(object sender, EventArgs e)
    {
      new ReferenceAnalyzer().ShowDialog();
    }

    private void launchNoteManager(object sender, EventArgs e)
    {
      // TODO: note support for whatever context we are in will be added here - swamp
      new NoteManager(new NoteCollection(null)).ShowDialog();
    }

    private void launchRadiosityOptions(object sender, EventArgs e)
    {
      dialogRadiosityOptions.Show();
      
    }

    private void launchGuerillaTagImporter(object sender, EventArgs e)
    {
      new GuerillaImport().ShowDialog();
    }

    #endregion

    #endregion

    #region ButtonItem DropDownList Helper Functions

    /* 
     * These functions are meant update the parent button with the appropriate
     * text once a child button has been pressed. Since ButtonItem controls can
     * have more than ButtonItems under them, each type of control used needs
     * a generic event handler added to this section.
     * 
     * Since these helper functions are fired when the user clicks a child button
     * or other control, those events cannot be used to reflect changes in the
     * application. For example, clicking a new speed under the camera speed list
     * will fire childButtonItem_Click and the camera's speed has to be changed
     * through other means.
     * 
     * To update the application with the user's input from this drop down setup,
     * the parent ButtonItem's TextChanged event should be used as the functions
     * below center around updating the text.
     * 
     * This was the best way I could see to approach this ButtonItem DropDownList
     * setup. Since I am not primarily a coder, I am positive there is a better
     * way to do this - feel free to implement a better way if one is known.
     * 
     * Nick
     * 
     * Note: These functions should work for ButtonX controls as well.
     */

    /* 
     * Since list item names may be too verbose to fit in the space provided by the
     * parent button, the "Tag" property of ButtonItem objects should contain a
     * representative value for the list item.
     * 
     * For example, the list item "Fastest (100)" under the camera speed button will
     * not fit in the small area provided to the parent button. To remedy this, the
     * Tag property contains "100" in it.
     */

    private void childButtonItem_Click(object sender, EventArgs e)
    {
      ButtonItem
        child = (sender as ButtonItem),
        parent = (child.Parent as ButtonItem);

#if DEBUG
      if (child.Tag.ToString().Equals(String.Empty))
      {
        MessageBoxEx.Show("The following control is missing a value in its Tag property:\n\n" + child.Name,
                          "Tag Property Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
        parent.Text = "<font color=\"red\">ERROR</font>";
        return;
      }
#endif

      // Update the label on the parent button.
      parent.Text = child.Tag.ToString();

      // Update the image on the parent button.
      if (child.Image != null)
      {
        if (parent.Image != null)
        {
          if (parent.Image.Height != child.Image.Height)
          {
#if DEBUG
            if (child.Description.Equals(String.Empty))
            {
              MessageBoxEx.Show(
                "The following control is missing a value in its Description property:\n\n" + child.Name,
                "Description Property Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
              parent.Text = "<font color=\"red\">ERROR</font>";
              return;
            }
#endif

            ResourceManager rm = Resources.ResourceManager;
            string imgName = child.Description;
            imgName = imgName.Remove(imgName.Length - 2);

            switch (parent.Image.Height)
            {
              case 16:
                imgName += "16";
                break;
              case 24:
                imgName += "24";
                break;
              case 32:
                imgName += "32";
                break;
              case 48:
                imgName += "48";
                break;
            }

            parent.Image = (Image) rm.GetObject(imgName);

            // Custom PerformLayout() calls needed
            if (parent.Equals(biProjectBuildState))
              rpProject.PerformLayout();
          }
        }
      }
    }

    private void childTextBoxItem_InputTextChanged(object sender)
    {
      if (!(sender as TextBoxItem).TextBox.Text.Equals(String.Empty))
        (sender as TextBoxItem).Parent.Text = (sender as TextBoxItem).TextBox.Text;
    }

    private void childTextBoxItem_Click(object sender, EventArgs e)
    {
      (sender as TextBoxItem).TextBox.Focus();
    }

    #endregion

    #region TEMP

    // TEMP: Using this button as a surrogate for testing pausing the renderer.
    private void biHomeStayConnectedUpdateCheck_Click(object sender, EventArgs e)
    {
      RenderCore.Paused = !RenderCore.Paused;
    }

    #endregion
  }
}
