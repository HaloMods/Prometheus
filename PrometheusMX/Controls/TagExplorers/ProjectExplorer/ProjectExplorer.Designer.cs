namespace Prometheus.Controls.TagExplorers
{
  partial class ProjectExplorer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorer));
      this.ipOperations = new DevComponents.DotNetBar.ItemPanel();
      this.icViewAdjustment = new DevComponents.DotNetBar.ItemContainer();
      this.btnView = new DevComponents.DotNetBar.ButtonItem();
      this.btnAllTags = new DevComponents.DotNetBar.ButtonItem();
      this.btnProjectTags = new DevComponents.DotNetBar.ButtonItem();
      this.btnFilter = new DevComponents.DotNetBar.ButtonItem();
      this.esplitMain = new DevComponents.DotNetBar.ExpandableSplitter();
      this.treeView = new Prometheus.Controls.MultiSourceTreeView();
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
      this.SuspendLayout();
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
      this.ipOperations.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipOperations.BackgroundStyle.BorderTopWidth = 1;
      this.ipOperations.BackgroundStyle.CornerDiameter = 12;
      this.ipOperations.BackgroundStyle.CornerTypeBottomRight = DevComponents.DotNetBar.eCornerType.Square;
      this.ipOperations.BackgroundStyle.PaddingBottom = 1;
      this.ipOperations.BackgroundStyle.PaddingLeft = 2;
      this.ipOperations.BackgroundStyle.PaddingRight = 2;
      this.ipOperations.BackgroundStyle.PaddingTop = 1;
      this.ipOperations.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipOperations.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Right;
      this.ipOperations.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icViewAdjustment,
            this.btnFilter});
      this.ipOperations.GetType();
      this.ipOperations.Location = new System.Drawing.Point(0, 0);
      this.ipOperations.Name = "ipOperations";
      this.ipOperations.Size = new System.Drawing.Size(145, 30);
      this.ipOperations.TabIndex = 0;
      this.ipOperations.Resize += new System.EventHandler(this.ipOperations_Resize);
      // 
      // icViewAdjustment
      // 
      this.icViewAdjustment.MinimumSize = new System.Drawing.Size(112, 0);
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
            this.btnAllTags,
            this.btnProjectTags});
      this.btnView.Text = "View";
      // 
      // btnAllTags
      // 
      this.btnAllTags.Checked = true;
      this.btnAllTags.ImagePaddingHorizontal = 8;
      this.btnAllTags.Name = "btnAllTags";
      this.btnAllTags.OptionGroup = "1";
      this.btnAllTags.Text = "All Tags in Directory";
      // 
      // btnProjectTags
      // 
      this.btnProjectTags.ImagePaddingHorizontal = 8;
      this.btnProjectTags.Name = "btnProjectTags";
      this.btnProjectTags.OptionGroup = "1";
      this.btnProjectTags.Text = "Project Tags Only";
      // 
      // btnFilter
      // 
      this.btnFilter.Image = global::Prometheus.Properties.Resources.funnel16;
      this.btnFilter.ImagePaddingHorizontal = 8;
      this.btnFilter.ImagePaddingVertical = 5;
      this.btnFilter.Name = "btnFilter";
      this.btnFilter.Text = "Filter";
      // 
      // esplitMain
      // 
      this.esplitMain.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.esplitMain.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.esplitMain.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.esplitMain.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.esplitMain.Dock = System.Windows.Forms.DockStyle.Top;
      this.esplitMain.ExpandableControl = this.ipOperations;
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
      this.esplitMain.Location = new System.Drawing.Point(0, 30);
      this.esplitMain.Name = "esplitMain";
      this.esplitMain.Size = new System.Drawing.Size(145, 6);
      this.esplitMain.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
      this.esplitMain.TabIndex = 0;
      this.esplitMain.TabStop = false;
      this.esplitMain.ExpandedChanged += new DevComponents.DotNetBar.ExpandChangeEventHandler(this.esplitMain_ExpandedChanged);
      // 
      // treeView
      // 
      this.treeView.AllowDrop = true;
      this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.treeView.CheckBoxes = true;
      this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
      this.treeView.FadeOnMouseOut = true;
      this.treeView.Indent = 9;
      this.treeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(109)))));
      this.treeView.Location = new System.Drawing.Point(0, 36);
      this.treeView.MoveNodesOnDragDrop = false;
      this.treeView.Name = "treeView";
      this.treeView.Size = new System.Drawing.Size(145, 370);
      this.treeView.SortMode = Prometheus.Controls.SortMode.NodeSource;
      this.treeView.TabIndex = 0;
      this.treeView.TreeEmptyAlpha = 255;
      this.treeView.TreeEmptyIcon = ((System.Drawing.Bitmap)(resources.GetObject("treeView.TreeEmptyIcon")));
      this.treeView.TreeEmptyText = null;
      this.treeView.TreeEmptyTextColor = System.Drawing.Color.Gray;
      this.treeView.TreeEmptyTextFont = new System.Drawing.Font("Arial", 8.5F);
      // 
      // ProjectExplorer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.treeView);
      this.Controls.Add(this.esplitMain);
      this.Controls.Add(this.ipOperations);
      this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      this.Name = "ProjectExplorer";
      this.Size = new System.Drawing.Size(145, 406);
      ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ItemPanel ipOperations;
    private DevComponents.DotNetBar.ItemContainer icViewAdjustment;
    private DevComponents.DotNetBar.ButtonItem btnView;
    private DevComponents.DotNetBar.ButtonItem btnAllTags;
    private DevComponents.DotNetBar.ButtonItem btnProjectTags;
    private DevComponents.DotNetBar.ButtonItem btnFilter;
    private MultiSourceTreeView treeView;
    private DevComponents.DotNetBar.ExpandableSplitter esplitMain;

  }
}
