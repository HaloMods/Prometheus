namespace Prometheus.Controls
{
  partial class RecycleBinBrowser
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
      if (disposing)
      {
        if (components != null)
          components.Dispose();
        UnhookEvents();
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
      this.components = new System.ComponentModel.Container();
      this.recycleBinList = new Prometheus.ThirdParty.Controls.ObjectListView();
      this.olvFilename = new Prometheus.ThirdParty.Controls.OLVColumn();
      this.olvType = new Prometheus.ThirdParty.Controls.OLVColumn();
      this.olvDate = new Prometheus.ThirdParty.Controls.OLVColumn();
      this.olvPath = new Prometheus.ThirdParty.Controls.OLVColumn();
      this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
      this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
      this.biDetailsView = new DevComponents.DotNetBar.ButtonItem();
      this.biTilesView = new DevComponents.DotNetBar.ButtonItem();
      this.biRestoreItem = new DevComponents.DotNetBar.ButtonItem();
      this.splitter = new DevComponents.DotNetBar.ExpandableSplitter();
      this.lblXStatus = new DevComponents.DotNetBar.LabelX();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.recycleBinList)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // recycleBinList
      // 
      this.recycleBinList.AlternateRowBackColor = System.Drawing.Color.Empty;
      this.recycleBinList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvFilename,
            this.olvType,
            this.olvDate,
            this.olvPath});
      this.recycleBinList.Dock = System.Windows.Forms.DockStyle.Fill;
      this.recycleBinList.Location = new System.Drawing.Point(0, 35);
      this.recycleBinList.Name = "recycleBinList";
      this.recycleBinList.Size = new System.Drawing.Size(639, 253);
      this.recycleBinList.TabIndex = 0;
      this.recycleBinList.UseCompatibleStateImageBehavior = false;
      this.recycleBinList.View = System.Windows.Forms.View.Details;
      this.recycleBinList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.recycleBinList_ItemSelectionChanged);
      // 
      // olvFilename
      // 
      this.olvFilename.AspectName = null;
      this.olvFilename.IsTileViewColumn = true;
      this.olvFilename.Text = "Filename";
      this.olvFilename.UseInitialLetterForGroup = true;
      this.olvFilename.Width = 211;
      // 
      // olvType
      // 
      this.olvType.AspectName = null;
      this.olvType.IsTileViewColumn = true;
      this.olvType.Text = "Type";
      this.olvType.Width = 59;
      // 
      // olvDate
      // 
      this.olvDate.AspectName = null;
      this.olvDate.IsTileViewColumn = true;
      this.olvDate.Text = "Date Deleted";
      this.olvDate.Width = 115;
      // 
      // olvPath
      // 
      this.olvPath.AspectName = null;
      this.olvPath.IsTileViewColumn = true;
      this.olvPath.Text = "Path";
      this.olvPath.Width = 126;
      // 
      // itemPanel1
      // 
      // 
      // 
      // 
      this.itemPanel1.BackgroundStyle.BackColor = System.Drawing.Color.White;
      this.itemPanel1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.itemPanel1.BackgroundStyle.BorderBottomWidth = 1;
      this.itemPanel1.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.itemPanel1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.itemPanel1.BackgroundStyle.BorderLeftWidth = 1;
      this.itemPanel1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.itemPanel1.BackgroundStyle.BorderRightWidth = 1;
      this.itemPanel1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.itemPanel1.BackgroundStyle.BorderTopWidth = 1;
      this.itemPanel1.BackgroundStyle.PaddingBottom = 1;
      this.itemPanel1.BackgroundStyle.PaddingLeft = 1;
      this.itemPanel1.BackgroundStyle.PaddingRight = 1;
      this.itemPanel1.BackgroundStyle.PaddingTop = 1;
      this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
      this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.itemPanel1.GetType();
      this.itemPanel1.Location = new System.Drawing.Point(0, 0);
      this.itemPanel1.Name = "itemPanel1";
      this.itemPanel1.Size = new System.Drawing.Size(639, 29);
      this.itemPanel1.TabIndex = 3;
      this.itemPanel1.Text = "itemPanel1";
      // 
      // itemContainer1
      // 
      this.itemContainer1.MinimumSize = new System.Drawing.Size(0, 0);
      this.itemContainer1.Name = "itemContainer1";
      this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biDetailsView,
            this.biTilesView,
            this.biRestoreItem});
      // 
      // biDetailsView
      // 
      this.biDetailsView.Image = global::Prometheus.Properties.Resources.form_blue16;
      this.biDetailsView.ImagePaddingHorizontal = 8;
      this.biDetailsView.Name = "biDetailsView";
      this.biDetailsView.OptionGroup = "1";
      this.biDetailsView.Text = "Details View";
      this.biDetailsView.CheckedChanged += new System.EventHandler(this.biDetailsView_CheckedChanged);
      // 
      // biTilesView
      // 
      this.biTilesView.Image = global::Prometheus.Properties.Resources.environment16;
      this.biTilesView.ImagePaddingHorizontal = 8;
      this.biTilesView.Name = "biTilesView";
      this.biTilesView.OptionGroup = "1";
      this.biTilesView.Text = "Tiles View";
      this.biTilesView.CheckedChanged += new System.EventHandler(this.biTilesView_CheckedChanged);
      // 
      // biRestoreItem
      // 
      this.biRestoreItem.BeginGroup = true;
      this.biRestoreItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.biRestoreItem.Enabled = false;
      this.biRestoreItem.Image = global::Prometheus.Properties.Resources.arrow_right_green16;
      this.biRestoreItem.ImagePaddingHorizontal = 8;
      this.biRestoreItem.Name = "biRestoreItem";
      this.biRestoreItem.Text = "<i>No items selected.</i>";
      this.biRestoreItem.Click += new System.EventHandler(this.biRestoreItem_Click);
      // 
      // splitter
      // 
      this.splitter.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
      this.splitter.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.splitter.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
      this.splitter.ExpandableControl = this.itemPanel1;
      this.splitter.ExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
      this.splitter.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.splitter.ExpandLineColor = System.Drawing.SystemColors.ControlText;
      this.splitter.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.splitter.GripDarkColor = System.Drawing.SystemColors.ControlText;
      this.splitter.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.splitter.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
      this.splitter.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.splitter.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(174)))), ((int)(((byte)(201)))));
      this.splitter.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(237)))), ((int)(((byte)(243)))));
      this.splitter.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
      this.splitter.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
      this.splitter.HotExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
      this.splitter.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.splitter.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
      this.splitter.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
      this.splitter.HotGripDarkColor = System.Drawing.SystemColors.ControlDarkDark;
      this.splitter.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.splitter.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
      this.splitter.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
      this.splitter.Location = new System.Drawing.Point(0, 29);
      this.splitter.Name = "splitter";
      this.splitter.Size = new System.Drawing.Size(639, 6);
      this.splitter.TabIndex = 4;
      this.splitter.TabStop = false;
      // 
      // lblXStatus
      // 
      this.lblXStatus.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblXStatus.Location = new System.Drawing.Point(5, 0);
      this.lblXStatus.Name = "lblXStatus";
      this.lblXStatus.Size = new System.Drawing.Size(629, 21);
      this.lblXStatus.TabIndex = 5;
      this.lblXStatus.Text = "No items selected.";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblXStatus);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(0, 288);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.panel1.Size = new System.Drawing.Size(639, 21);
      this.panel1.TabIndex = 6;
      // 
      // RecycleBinBrowser
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.recycleBinList);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.splitter);
      this.Controls.Add(this.itemPanel1);
      this.Name = "RecycleBinBrowser";
      this.Size = new System.Drawing.Size(639, 309);
      ((System.ComponentModel.ISupportInitialize)(this.recycleBinList)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Prometheus.ThirdParty.Controls.ObjectListView recycleBinList;
    private Prometheus.ThirdParty.Controls.OLVColumn olvFilename;
    private Prometheus.ThirdParty.Controls.OLVColumn olvType;
    private Prometheus.ThirdParty.Controls.OLVColumn olvDate;
    private Prometheus.ThirdParty.Controls.OLVColumn olvPath;
    private DevComponents.DotNetBar.ItemPanel itemPanel1;
    private DevComponents.DotNetBar.ButtonItem biTilesView;
    private DevComponents.DotNetBar.ButtonItem biDetailsView;
    private DevComponents.DotNetBar.ItemContainer itemContainer1;
    private DevComponents.DotNetBar.ButtonItem biRestoreItem;
    private DevComponents.DotNetBar.ExpandableSplitter splitter;
    private DevComponents.DotNetBar.LabelX lblXStatus;
    private System.Windows.Forms.Panel panel1;
  }
}
