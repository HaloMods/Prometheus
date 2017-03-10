namespace Prometheus.Controls.TagExplorers
{
  partial class LibraryExplorer
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryExplorer));
      this.ipLibrary = new DevComponents.DotNetBar.ItemPanel();
      this.cbiSystemList = new DevComponents.DotNetBar.ComboBoxItem();
      this.cbiGameList = new DevComponents.DotNetBar.ComboBoxItem();
      this.ipFilter = new DevComponents.DotNetBar.ItemPanel();
      this.liFilter = new DevComponents.DotNetBar.LabelItem();
      this.cbiFilter = new DevComponents.DotNetBar.ComboBoxItem();
      this.btnFilterManager = new DevComponents.DotNetBar.ButtonItem();
      this.esplitMain = new DevComponents.DotNetBar.ExpandableSplitter();
      this.panelItemPanel = new System.Windows.Forms.Panel();
      this.ipFilterManager = new DevComponents.DotNetBar.ItemPanel();
      this.clbFilterTypes = new System.Windows.Forms.CheckedListBox();
      this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
      this.liFilterName = new DevComponents.DotNetBar.LabelItem();
      this.itemContainer5 = new DevComponents.DotNetBar.ItemContainer();
      this.tbiFilterName = new DevComponents.DotNetBar.TextBoxItem();
      this.biFilterNew = new DevComponents.DotNetBar.ButtonItem();
      this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
      this.itemContainer4 = new DevComponents.DotNetBar.ItemContainer();
      this.liFilterTypes = new DevComponents.DotNetBar.LabelItem();
      this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
      this.biFilterDelete = new DevComponents.DotNetBar.ButtonItem();
      this.ipOperations = new DevComponents.DotNetBar.ItemPanel();
      this.icViewAdjustment = new DevComponents.DotNetBar.ItemContainer();
      this.btnView = new DevComponents.DotNetBar.ButtonItem();
      this.btnSplit = new DevComponents.DotNetBar.ButtonItem();
      this.btnMerged = new DevComponents.DotNetBar.ButtonItem();
      this.btnTagView = new DevComponents.DotNetBar.ButtonItem();
      this.btnObjectView = new DevComponents.DotNetBar.ButtonItem();
      this.btnFilter = new DevComponents.DotNetBar.ButtonItem();
      this.treeViewPanel = new System.Windows.Forms.Panel();
      this.panelTreeViewMain = new System.Windows.Forms.Panel();
      this.CHECKYOURSELF = new System.Windows.Forms.Label();
      this.treeView = new Prometheus.Controls.MultiSourceTreeView();
      this.ipDecompile = new DevComponents.DotNetBar.ItemPanel();
      this.biDecompile = new DevComponents.DotNetBar.ButtonItem();
      this.esplitFilter = new DevComponents.DotNetBar.ExpandableSplitter();
      this.stLibraryExplorer = new DevComponents.DotNetBar.SuperTooltip();
      this.esplitOperations = new DevComponents.DotNetBar.ExpandableSplitter();
      this.esplitFilterManager = new DevComponents.DotNetBar.ExpandableSplitter();
      this.esplitLibrary = new DevComponents.DotNetBar.ExpandableSplitter();
      this.esplitDecompile = new DevComponents.DotNetBar.ExpandableSplitter();
      this.panelItemPanel.SuspendLayout();
      this.ipFilterManager.SuspendLayout();
      this.treeViewPanel.SuspendLayout();
      this.panelTreeViewMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
      this.SuspendLayout();
      // 
      // ipLibrary
      // 
      // 
      // 
      // 
      this.ipLibrary.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ipLibrary.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.MenuBar;
      this.ipLibrary.BackgroundStyle.BackColorGradientAngle = 90;
      this.ipLibrary.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
      this.ipLibrary.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipLibrary.BackgroundStyle.BorderBottomWidth = 1;
      this.ipLibrary.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipLibrary.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipLibrary.BackgroundStyle.BorderLeftWidth = 1;
      this.ipLibrary.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipLibrary.BackgroundStyle.BorderRightWidth = 1;
      this.ipLibrary.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipLibrary.BackgroundStyle.BorderTopWidth = 1;
      this.ipLibrary.BackgroundStyle.CornerDiameter = 12;
      this.ipLibrary.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Square;
      this.ipLibrary.BackgroundStyle.PaddingBottom = 2;
      this.ipLibrary.BackgroundStyle.PaddingLeft = 2;
      this.ipLibrary.BackgroundStyle.PaddingRight = 3;
      this.ipLibrary.BackgroundStyle.PaddingTop = 1;
      this.ipLibrary.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipLibrary.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cbiSystemList,
            this.cbiGameList});
      this.ipLibrary.GetType();
      this.ipLibrary.Location = new System.Drawing.Point(0, 0);
      this.ipLibrary.Name = "ipLibrary";
      this.ipLibrary.Size = new System.Drawing.Size(149, 31);
      this.ipLibrary.TabIndex = 1;
      this.ipLibrary.Resize += new System.EventHandler(this.ipLibrary_Resize);
      // 
      // cbiSystemList
      // 
      this.cbiSystemList.ComboWidth = 62;
      this.cbiSystemList.DropDownHeight = 106;
      this.cbiSystemList.Name = "cbiSystemList";
      this.cbiSystemList.Stretch = true;
      this.stLibraryExplorer.SetSuperTooltip(this.cbiSystemList, new DevComponents.DotNetBar.SuperTooltipInfo("System", "", "Select the system the game to be explored runs on.", null, null, DevComponents.DotNetBar.eTooltipColor.System));
      this.cbiSystemList.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.cbiSystemList.WatermarkText = "System";
      this.cbiSystemList.Click += new System.EventHandler(this.cbiSystemList_Click);
      // 
      // cbiGameList
      // 
      this.cbiGameList.ComboWidth = 62;
      this.cbiGameList.DropDownHeight = 106;
      this.cbiGameList.Enabled = false;
      this.cbiGameList.Name = "cbiGameList";
      this.cbiGameList.Stretch = true;
      this.stLibraryExplorer.SetSuperTooltip(this.cbiGameList, new DevComponents.DotNetBar.SuperTooltipInfo("Game", "", "Select a game to build a tag library from or to explore the existing library.", null, null, DevComponents.DotNetBar.eTooltipColor.System));
      this.cbiGameList.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.cbiGameList.WatermarkText = "Game";
      this.cbiGameList.Click += new System.EventHandler(this.cbiGameList_Click);
      // 
      // ipFilter
      // 
      // 
      // 
      // 
      this.ipFilter.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ipFilter.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.InactiveBorder;
      this.ipFilter.BackgroundStyle.BackColorGradientAngle = 90;
      this.ipFilter.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
      this.ipFilter.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilter.BackgroundStyle.BorderBottomWidth = 1;
      this.ipFilter.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipFilter.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilter.BackgroundStyle.BorderLeftWidth = 1;
      this.ipFilter.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilter.BackgroundStyle.BorderRightWidth = 1;
      this.ipFilter.BackgroundStyle.BorderTopWidth = 1;
      this.ipFilter.BackgroundStyle.PaddingBottom = 1;
      this.ipFilter.BackgroundStyle.PaddingLeft = 3;
      this.ipFilter.BackgroundStyle.PaddingRight = 1;
      this.ipFilter.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipFilter.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liFilter,
            this.cbiFilter,
            this.btnFilterManager});
      this.ipFilter.GetType();
      this.ipFilter.Location = new System.Drawing.Point(0, 58);
      this.ipFilter.Name = "ipFilter";
      this.ipFilter.Size = new System.Drawing.Size(149, 25);
      this.ipFilter.TabIndex = 0;
      this.ipFilter.Visible = false;
      // 
      // liFilter
      // 
      this.liFilter.Name = "liFilter";
      this.liFilter.PaddingRight = 8;
      this.liFilter.Text = "Filter:";
      // 
      // cbiFilter
      // 
      this.cbiFilter.ComboWidth = 108;
      this.cbiFilter.DropDownHeight = 106;
      this.cbiFilter.Name = "cbiFilter";
      this.cbiFilter.Click += new System.EventHandler(this.cbiFilter_Click);
      // 
      // btnFilterManager
      // 
      this.btnFilterManager.Enabled = false;
      this.btnFilterManager.Image = global::Prometheus.Properties.Resources.funnel_preferences16;
      this.btnFilterManager.ImagePaddingHorizontal = 8;
      this.btnFilterManager.ImagePaddingVertical = 5;
      this.btnFilterManager.Name = "btnFilterManager";
      this.stLibraryExplorer.SetSuperTooltip(this.btnFilterManager, new DevComponents.DotNetBar.SuperTooltipInfo("Filter Manager", "", "Open the Filter Manager to configure tag type filters for the tag list.\r\n<br/><br" +
                  "/>\r\nThese filters force the tag list to display only the selected tag types.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnFilterManager.Text = "Manage Filters";
      this.btnFilterManager.Click += new System.EventHandler(this.btnFilterManager_Click);
      // 
      // esplitMain
      // 
      this.esplitMain.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitMain.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitMain.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitMain.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitMain.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitMain.ExpandableControl = this.panelItemPanel;
      this.esplitMain.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitMain.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitMain.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitMain.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitMain.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitMain.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitMain.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitMain.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitMain.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitMain.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitMain.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitMain.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitMain.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitMain.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitMain.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitMain.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitMain.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitMain.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitMain.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitMain.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitMain.Location = new System.Drawing.Point(0, 55);
      this.esplitMain.Name = "esplitMain";
      this.esplitMain.Size = new System.Drawing.Size(149, 6);
      this.esplitMain.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitMain.TabIndex = 3;
      this.esplitMain.TabStop = false;
      this.esplitMain.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitMain_ExpandedChanged);
      // 
      // panelItemPanel
      // 
      this.panelItemPanel.AutoSize = true;
      this.panelItemPanel.Controls.Add(this.ipFilterManager);
      this.panelItemPanel.Controls.Add(this.ipFilter);
      this.panelItemPanel.Controls.Add(this.ipOperations);
      this.panelItemPanel.Controls.Add(this.ipLibrary);
      this.panelItemPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelItemPanel.Location = new System.Drawing.Point(0, 0);
      this.panelItemPanel.Name = "panelItemPanel";
      this.panelItemPanel.Size = new System.Drawing.Size(149, 31);
      this.panelItemPanel.TabIndex = 10000;
      // 
      // ipFilterManager
      // 
      this.ipFilterManager.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ipFilterManager.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ipFilterManager.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.InactiveBorder;
      this.ipFilterManager.BackgroundStyle.BackColorGradientAngle = 90;
      this.ipFilterManager.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
      this.ipFilterManager.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilterManager.BackgroundStyle.BorderBottomWidth = 1;
      this.ipFilterManager.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipFilterManager.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilterManager.BackgroundStyle.BorderLeftWidth = 1;
      this.ipFilterManager.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipFilterManager.BackgroundStyle.BorderRightWidth = 1;
      this.ipFilterManager.BackgroundStyle.PaddingBottom = 1;
      this.ipFilterManager.BackgroundStyle.PaddingLeft = 3;
      this.ipFilterManager.BackgroundStyle.PaddingRight = 1;
      this.ipFilterManager.Controls.Add(this.clbFilterTypes);
      this.ipFilterManager.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipFilterManager.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.itemContainer2});
      this.ipFilterManager.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipFilterManager.GetType();
      this.ipFilterManager.Location = new System.Drawing.Point(0, 31);
      this.ipFilterManager.Name = "ipFilterManager";
      this.ipFilterManager.Size = new System.Drawing.Size(149, 107);
      this.ipFilterManager.TabIndex = 10002;
      this.ipFilterManager.Visible = false;
      // 
      // clbFilterTypes
      // 
      this.clbFilterTypes.CheckOnClick = true;
      this.clbFilterTypes.FormattingEnabled = true;
      this.clbFilterTypes.HorizontalExtent = 112;
      this.clbFilterTypes.HorizontalScrollbar = true;
      this.clbFilterTypes.Items.AddRange(new object[] {
            "actor",
            "actor_variant",
            "bitmap",
            "effect",
            "item_collection",
            "model",
            "particle",
            "scenario",
            "sound"});
      this.clbFilterTypes.Location = new System.Drawing.Point(40, 22);
      this.clbFilterTypes.MaximumSize = new System.Drawing.Size(92, 94);
      this.clbFilterTypes.MinimumSize = new System.Drawing.Size(92, 94);
      this.clbFilterTypes.Name = "clbFilterTypes";
      this.clbFilterTypes.Size = new System.Drawing.Size(92, 89);
      this.clbFilterTypes.TabIndex = 1;
      // 
      // itemContainer1
      // 
      this.itemContainer1.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer1.Name = "itemContainer1";
      this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liFilterName,
            this.itemContainer5,
            this.biFilterNew});
      // 
      // liFilterName
      // 
      this.liFilterName.Name = "liFilterName";
      this.liFilterName.PaddingLeft = 1;
      this.liFilterName.Text = "Name:";
      // 
      // itemContainer5
      // 
      // 
      // 
      // 
      this.itemContainer5.BackgroundStyle.PaddingLeft = -1;
      this.itemContainer5.BackgroundStyle.PaddingRight = -1;
      this.itemContainer5.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer5.Name = "itemContainer5";
      this.itemContainer5.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbiFilterName});
      // 
      // tbiFilterName
      // 
      this.tbiFilterName.AlwaysShowCaption = false;
      this.tbiFilterName.ControlText = "";
      this.tbiFilterName.MaxLength = 255;
      this.tbiFilterName.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
      this.tbiFilterName.Name = "tbiFilterName";
      this.tbiFilterName.RecentlyUsed = false;
      this.tbiFilterName.SelectionLength = 0;
      this.tbiFilterName.SelectionStart = 0;
      this.tbiFilterName.TextBoxWidth = 112;
      this.tbiFilterName.WatermarkText = "Enter Filter Name";
      // 
      // biFilterNew
      // 
      this.biFilterNew.Image = global::Prometheus.Properties.Resources.funnel_new16;
      this.biFilterNew.ImagePaddingHorizontal = 8;
      this.biFilterNew.ImagePaddingVertical = 5;
      this.biFilterNew.Name = "biFilterNew";
      this.stLibraryExplorer.SetSuperTooltip(this.biFilterNew, new DevComponents.DotNetBar.SuperTooltipInfo("New Filter", "", "Create a new filter by entering a name that is not already in the filter list.\r\n<" +
                  "br/><br/>\r\nIf the specified name is already in the list, that filter\'s settings " +
                  "will be automatically updated.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.biFilterNew.Text = "New Filter";
      // 
      // itemContainer2
      // 
      this.itemContainer2.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer2.Name = "itemContainer2";
      this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer4,
            this.itemContainer3});
      // 
      // itemContainer4
      // 
      // 
      // 
      // 
      this.itemContainer4.BackgroundStyle.PaddingRight = 114;
      this.itemContainer4.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.itemContainer4.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer4.Name = "itemContainer4";
      this.itemContainer4.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liFilterTypes});
      // 
      // liFilterTypes
      // 
      this.liFilterTypes.Name = "liFilterTypes";
      this.liFilterTypes.PaddingLeft = 2;
      this.liFilterTypes.Text = "Types:";
      // 
      // itemContainer3
      // 
      this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.itemContainer3.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer3.Name = "itemContainer3";
      this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biFilterDelete});
      // 
      // biFilterDelete
      // 
      this.biFilterDelete.Image = global::Prometheus.Properties.Resources.delete216;
      this.biFilterDelete.ImagePaddingHorizontal = 8;
      this.biFilterDelete.Name = "biFilterDelete";
      this.stLibraryExplorer.SetSuperTooltip(this.biFilterDelete, new DevComponents.DotNetBar.SuperTooltipInfo("Delete", "", "The specified name will be removed from the list, if it exists.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.biFilterDelete.Text = "Delete";
      // 
      // ipOperations
      // 
      // 
      // 
      // 
      this.ipOperations.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ipOperations.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.MenuBar;
      this.ipOperations.BackgroundStyle.BackColorGradientAngle = 90;
      this.ipOperations.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
      this.ipOperations.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipOperations.BackgroundStyle.BorderBottomWidth = 1;
      this.ipOperations.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipOperations.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipOperations.BackgroundStyle.BorderLeftWidth = 1;
      this.ipOperations.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipOperations.BackgroundStyle.BorderRightWidth = 1;
      this.ipOperations.BackgroundStyle.BorderTopWidth = 1;
      this.ipOperations.BackgroundStyle.CornerDiameter = 12;
      this.ipOperations.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Square;
      this.ipOperations.BackgroundStyle.PaddingBottom = 1;
      this.ipOperations.BackgroundStyle.PaddingLeft = 2;
      this.ipOperations.BackgroundStyle.PaddingRight = 3;
      this.ipOperations.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipOperations.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
      this.ipOperations.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icViewAdjustment,
            this.btnTagView,
            this.btnObjectView,
            this.btnFilter});
      this.ipOperations.GetType();
      this.ipOperations.Location = new System.Drawing.Point(0, 31);
      this.ipOperations.Name = "ipOperations";
      this.ipOperations.Size = new System.Drawing.Size(149, 27);
      this.ipOperations.TabIndex = 10001;
      this.ipOperations.Visible = false;
      this.ipOperations.Resize += new System.EventHandler(this.ipOperations_Resize);
      // 
      // icViewAdjustment
      // 
      this.icViewAdjustment.MinimumSize = new System.Drawing.Size(59, 0);
      this.icViewAdjustment.Name = "icViewAdjustment";
      this.icViewAdjustment.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnView});
      // 
      // btnView
      // 
      this.btnView.AutoExpandOnClick = true;
      this.btnView.ImagePaddingHorizontal = 8;
      this.btnView.Name = "btnView";
      this.btnView.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSplit,
            this.btnMerged});
      this.stLibraryExplorer.SetSuperTooltip(this.btnView, new DevComponents.DotNetBar.SuperTooltipInfo("List View", "", resources.GetString("btnView.SuperTooltip"), null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(232, 147)));
      this.btnView.Text = "View";
      // 
      // btnSplit
      // 
      this.btnSplit.Checked = true;
      this.btnSplit.ImagePaddingHorizontal = 8;
      this.btnSplit.Name = "btnSplit";
      this.btnSplit.OptionGroup = "1";
      this.btnSplit.Text = "Split Tag List";
      this.btnSplit.CheckedChanged += new System.EventHandler(this.btnSplit_CheckedChanged);
      // 
      // btnMerged
      // 
      this.btnMerged.ImagePaddingHorizontal = 8;
      this.btnMerged.Name = "btnMerged";
      this.btnMerged.OptionGroup = "1";
      this.btnMerged.Text = "Merged Tag List";
      this.btnMerged.CheckedChanged += new System.EventHandler(this.btnMerged_CheckedChanged);
      // 
      // btnTagView
      // 
      this.btnTagView.Image = global::Prometheus.Properties.Resources.document16;
      this.btnTagView.ImagePaddingHorizontal = 8;
      this.btnTagView.ImagePaddingVertical = 5;
      this.btnTagView.Name = "btnTagView";
      this.btnTagView.OptionGroup = "1";
      this.stLibraryExplorer.SetSuperTooltip(this.btnTagView, new DevComponents.DotNetBar.SuperTooltipInfo("Tag Mode", "", "This mode displays each individual tag in the proper folder structure.\r\n<br/><br/" +
                  ">\r\nIt is most similar to how you browse files on your hard drive.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnTagView.Text = "Tag View";
      this.btnTagView.Click += new System.EventHandler(this.btnTagView_Click);
      // 
      // btnObjectView
      // 
      this.btnObjectView.Image = global::Prometheus.Properties.Resources.data16;
      this.btnObjectView.ImagePaddingHorizontal = 8;
      this.btnObjectView.ImagePaddingVertical = 5;
      this.btnObjectView.Name = "btnObjectView";
      this.btnObjectView.OptionGroup = "1";
      this.stLibraryExplorer.SetSuperTooltip(this.btnObjectView, new DevComponents.DotNetBar.SuperTooltipInfo("Object Mode", "", "This mode displays groups of object types with the objects underneat them display" +
                  "ing the tags they depend on.\r\n<br/><br/>\r\nIt focuses on making it simple to find" +
                  " objects.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnObjectView.Text = "Object View";
      this.btnObjectView.Click += new System.EventHandler(this.btnObjectView_Click);
      // 
      // btnFilter
      // 
      this.btnFilter.BeginGroup = true;
      this.btnFilter.Image = global::Prometheus.Properties.Resources.funnel16;
      this.btnFilter.ImagePaddingHorizontal = 8;
      this.btnFilter.ImagePaddingVertical = 5;
      this.btnFilter.Name = "btnFilter";
      this.stLibraryExplorer.SetSuperTooltip(this.btnFilter, new DevComponents.DotNetBar.SuperTooltipInfo("Filter", "", "Choose from predefined and custom tag type filters.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnFilter.Text = "Filter";
      this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
      // 
      // treeViewPanel
      // 
      this.treeViewPanel.Controls.Add(this.panelTreeViewMain);
      this.treeViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeViewPanel.Location = new System.Drawing.Point(0, 31);
      this.treeViewPanel.Name = "treeViewPanel";
      this.treeViewPanel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
      this.treeViewPanel.Size = new System.Drawing.Size(149, 319);
      this.treeViewPanel.TabIndex = 4;
      // 
      // panelTreeViewMain
      // 
      this.panelTreeViewMain.Controls.Add(this.CHECKYOURSELF);
      this.panelTreeViewMain.Controls.Add(this.treeView);
      this.panelTreeViewMain.Controls.Add(this.ipDecompile);
      this.panelTreeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelTreeViewMain.Location = new System.Drawing.Point(0, 6);
      this.panelTreeViewMain.Margin = new System.Windows.Forms.Padding(0);
      this.panelTreeViewMain.Name = "panelTreeViewMain";
      this.panelTreeViewMain.Size = new System.Drawing.Size(149, 313);
      this.panelTreeViewMain.TabIndex = 3;
      // 
      // CHECKYOURSELF
      // 
      this.CHECKYOURSELF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.CHECKYOURSELF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CHECKYOURSELF.ForeColor = System.Drawing.Color.Red;
      this.CHECKYOURSELF.Location = new System.Drawing.Point(23, 94);
      this.CHECKYOURSELF.Name = "CHECKYOURSELF";
      this.CHECKYOURSELF.Size = new System.Drawing.Size(110, 149);
      this.CHECKYOURSELF.TabIndex = 10003;
      this.CHECKYOURSELF.Text = resources.GetString("CHECKYOURSELF.Text");
      // 
      // treeView
      // 
      this.treeView.AllowDrop = true;
      this.treeView.BackColor = System.Drawing.SystemColors.Window;
      this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeView.CheckBoxes = true;
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
      this.treeView.FadeOnMouseOut = true;
      this.treeView.Indent = 9;
      this.treeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(109)))));
      this.treeView.Location = new System.Drawing.Point(0, 0);
      this.treeView.Margin = new System.Windows.Forms.Padding(0);
      this.treeView.MoveNodesOnDragDrop = false;
      this.treeView.Name = "treeView";
      this.treeView.Size = new System.Drawing.Size(149, 313);
      this.treeView.SortMode = Prometheus.Controls.SortMode.NodeSource;
      this.treeView.TabIndex = 0;
      this.treeView.TreeEmptyAlpha = 255;
      this.treeView.TreeEmptyIcon = ((System.Drawing.Bitmap)(resources.GetObject("treeView.TreeEmptyIcon")));
      this.treeView.TreeEmptyText = null;
      this.treeView.TreeEmptyTextColor = System.Drawing.Color.Gray;
      this.treeView.TreeEmptyTextFont = new System.Drawing.Font("Arial", 8.5F);
      this.treeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCheck);
      // 
      // ipDecompile
      // 
      // 
      // 
      // 
      this.ipDecompile.BackgroundStyle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ipDecompile.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.MenuBar;
      this.ipDecompile.BackgroundStyle.BackColorGradientAngle = 90;
      this.ipDecompile.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
      this.ipDecompile.BackgroundStyle.BorderBottomWidth = 1;
      this.ipDecompile.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipDecompile.BackgroundStyle.BorderLeftWidth = 1;
      this.ipDecompile.BackgroundStyle.BorderRightWidth = 1;
      this.ipDecompile.BackgroundStyle.BorderTopWidth = 1;
      this.ipDecompile.BackgroundStyle.CornerDiameter = 12;
      this.ipDecompile.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Square;
      this.ipDecompile.BackgroundStyle.PaddingBottom = 2;
      this.ipDecompile.BackgroundStyle.PaddingLeft = 2;
      this.ipDecompile.BackgroundStyle.PaddingRight = 3;
      this.ipDecompile.BackgroundStyle.PaddingTop = 3;
      this.ipDecompile.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.ipDecompile.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
      this.ipDecompile.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biDecompile});
      this.ipDecompile.GetType();
      this.ipDecompile.Location = new System.Drawing.Point(0, 283);
      this.ipDecompile.Name = "ipDecompile";
      this.ipDecompile.Size = new System.Drawing.Size(149, 30);
      this.ipDecompile.TabIndex = 0;
      this.ipDecompile.Visible = false;
      // 
      // biDecompile
      // 
      this.biDecompile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.biDecompile.FixedSize = new System.Drawing.Size(120, 24);
      this.biDecompile.ImagePaddingHorizontal = 8;
      this.biDecompile.Name = "biDecompile";
      this.biDecompile.Text = "<div align=\"center\" width=\"115\">Add Tags</div>";
      this.biDecompile.Click += new System.EventHandler(this.biDecompile_Click);
      // 
      // esplitFilter
      // 
      this.esplitFilter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitFilter.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitFilter.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitFilter.ExpandableControl = this.ipFilter;
      this.esplitFilter.Expanded = false;
      this.esplitFilter.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilter.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilter.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilter.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitFilter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitFilter.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitFilter.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitFilter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitFilter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitFilter.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilter.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilter.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilter.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitFilter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitFilter.Location = new System.Drawing.Point(0, 37);
      this.esplitFilter.Name = "esplitFilter";
      this.esplitFilter.Size = new System.Drawing.Size(149, 6);
      this.esplitFilter.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitFilter.TabIndex = 0;
      this.esplitFilter.TabStop = false;
      this.esplitFilter.Visible = false;
      this.esplitFilter.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitFilter_ExpandedChanging);
      // 
      // stLibraryExplorer
      // 
      this.stLibraryExplorer.DefaultFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.stLibraryExplorer.GetType();
      this.stLibraryExplorer.MinimumTooltipSize = new System.Drawing.Size(195, 50);
      this.stLibraryExplorer.PositionBelowControl = false;
      this.stLibraryExplorer.TooltipDuration = 0;
      // 
      // esplitOperations
      // 
      this.esplitOperations.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitOperations.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitOperations.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitOperations.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitOperations.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitOperations.ExpandableControl = this.ipOperations;
      this.esplitOperations.Expanded = false;
      this.esplitOperations.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitOperations.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitOperations.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitOperations.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitOperations.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitOperations.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitOperations.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitOperations.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitOperations.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitOperations.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitOperations.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitOperations.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitOperations.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitOperations.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitOperations.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitOperations.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitOperations.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitOperations.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitOperations.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitOperations.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitOperations.Location = new System.Drawing.Point(0, 43);
      this.esplitOperations.Name = "esplitOperations";
      this.esplitOperations.Size = new System.Drawing.Size(149, 6);
      this.esplitOperations.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitOperations.TabIndex = 10001;
      this.esplitOperations.TabStop = false;
      this.esplitOperations.Visible = false;
      this.esplitOperations.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitOperations_ExpandedChanging);
      // 
      // esplitFilterManager
      // 
      this.esplitFilterManager.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilterManager.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilterManager.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitFilterManager.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitFilterManager.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitFilterManager.ExpandableControl = this.ipFilterManager;
      this.esplitFilterManager.Expanded = false;
      this.esplitFilterManager.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilterManager.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilterManager.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilterManager.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilterManager.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilterManager.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilterManager.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitFilterManager.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitFilterManager.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitFilterManager.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitFilterManager.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitFilterManager.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitFilterManager.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilterManager.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilterManager.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitFilterManager.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitFilterManager.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitFilterManager.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitFilterManager.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitFilterManager.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitFilterManager.Location = new System.Drawing.Point(0, 31);
      this.esplitFilterManager.Name = "esplitFilterManager";
      this.esplitFilterManager.Size = new System.Drawing.Size(149, 6);
      this.esplitFilterManager.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitFilterManager.TabIndex = 10002;
      this.esplitFilterManager.TabStop = false;
      this.esplitFilterManager.Visible = false;
      this.esplitFilterManager.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitFilterManager_ExpandedChanged);
      // 
      // esplitLibrary
      // 
      this.esplitLibrary.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitLibrary.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitLibrary.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitLibrary.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitLibrary.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitLibrary.ExpandableControl = this.ipLibrary;
      this.esplitLibrary.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitLibrary.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitLibrary.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitLibrary.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitLibrary.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitLibrary.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitLibrary.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitLibrary.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitLibrary.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitLibrary.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitLibrary.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitLibrary.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitLibrary.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitLibrary.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitLibrary.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitLibrary.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitLibrary.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitLibrary.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitLibrary.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitLibrary.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitLibrary.Location = new System.Drawing.Point(0, 49);
      this.esplitLibrary.Name = "esplitLibrary";
      this.esplitLibrary.Size = new System.Drawing.Size(149, 6);
      this.esplitLibrary.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitLibrary.TabIndex = 10003;
      this.esplitLibrary.TabStop = false;
      this.esplitLibrary.Visible = false;
      this.esplitLibrary.ExpandedChanging += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitLibrary_ExpandedChanging);
      // 
      // esplitDecompile
      // 
      this.esplitDecompile.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitDecompile.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitDecompile.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitDecompile.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitDecompile.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.esplitDecompile.ExpandableControl = this.ipDecompile;
      this.esplitDecompile.Expanded = false;
      this.esplitDecompile.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitDecompile.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitDecompile.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitDecompile.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitDecompile.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitDecompile.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitDecompile.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitDecompile.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitDecompile.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
      this.esplitDecompile.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
      this.esplitDecompile.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.esplitDecompile.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.esplitDecompile.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitDecompile.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitDecompile.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.esplitDecompile.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.esplitDecompile.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitDecompile.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitDecompile.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.esplitDecompile.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.esplitDecompile.Location = new System.Drawing.Point(0, 344);
      this.esplitDecompile.Name = "esplitDecompile";
      this.esplitDecompile.Size = new System.Drawing.Size(149, 6);
      this.esplitDecompile.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitDecompile.TabIndex = 4;
      this.esplitDecompile.TabStop = false;
      this.esplitDecompile.Visible = false;
      // 
      // LibraryExplorer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.Controls.Add(this.esplitDecompile);
      this.Controls.Add(this.esplitMain);
      this.Controls.Add(this.esplitLibrary);
      this.Controls.Add(this.esplitOperations);
      this.Controls.Add(this.esplitFilter);
      this.Controls.Add(this.esplitFilterManager);
      this.Controls.Add(this.treeViewPanel);
      this.Controls.Add(this.panelItemPanel);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.Name = "LibraryExplorer";
      this.Size = new System.Drawing.Size(149, 350);
      this.panelItemPanel.ResumeLayout(false);
      this.ipFilterManager.ResumeLayout(false);
      this.treeViewPanel.ResumeLayout(false);
      this.panelTreeViewMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MultiSourceTreeView treeView;
    private DevComponents.DotNetBar.ItemPanel ipLibrary;
    private DevComponents.DotNetBar.ComboBoxItem cbiGameList;
    private DevComponents.DotNetBar.ExpandableSplitter esplitMain;
    private System.Windows.Forms.Panel treeViewPanel;
    private System.Windows.Forms.Panel panelItemPanel;
    private System.Windows.Forms.Panel panelTreeViewMain;
    private DevComponents.DotNetBar.ItemPanel ipFilter;
    private DevComponents.DotNetBar.ComboBoxItem cbiFilter;
    private DevComponents.DotNetBar.ButtonItem btnFilterManager;
    private DevComponents.DotNetBar.LabelItem liFilter;
    private DevComponents.DotNetBar.ExpandableSplitter esplitFilter;
    private DevComponents.DotNetBar.SuperTooltip stLibraryExplorer;
    private DevComponents.DotNetBar.ItemPanel ipOperations;
    private DevComponents.DotNetBar.ItemContainer icViewAdjustment;
    private DevComponents.DotNetBar.ButtonItem btnView;
    private DevComponents.DotNetBar.ButtonItem btnSplit;
    private DevComponents.DotNetBar.ButtonItem btnMerged;
    private DevComponents.DotNetBar.ButtonItem btnTagView;
    private DevComponents.DotNetBar.ButtonItem btnObjectView;
    private DevComponents.DotNetBar.ButtonItem btnFilter;
    private DevComponents.DotNetBar.ExpandableSplitter esplitOperations;
    private DevComponents.DotNetBar.ItemPanel ipFilterManager;
    private DevComponents.DotNetBar.LabelItem liFilterName;
    private DevComponents.DotNetBar.ButtonItem biFilterNew;
    private DevComponents.DotNetBar.ItemContainer itemContainer1;
    private DevComponents.DotNetBar.ItemContainer itemContainer2;
    private DevComponents.DotNetBar.ItemContainer itemContainer3;
    private DevComponents.DotNetBar.ButtonItem biFilterDelete;
    private DevComponents.DotNetBar.ExpandableSplitter esplitFilterManager;
    private DevComponents.DotNetBar.ExpandableSplitter esplitLibrary;
    private DevComponents.DotNetBar.TextBoxItem tbiFilterName;
    private DevComponents.DotNetBar.ItemContainer itemContainer4;
    private DevComponents.DotNetBar.LabelItem liFilterTypes;
    private System.Windows.Forms.CheckedListBox clbFilterTypes;
    private System.Windows.Forms.Label CHECKYOURSELF;
    private DevComponents.DotNetBar.ItemContainer itemContainer5;
    private DevComponents.DotNetBar.ExpandableSplitter esplitDecompile;
    private DevComponents.DotNetBar.ItemPanel ipDecompile;
    private DevComponents.DotNetBar.ButtonItem biDecompile;
    private DevComponents.DotNetBar.ComboBoxItem cbiSystemList;
  }
}
