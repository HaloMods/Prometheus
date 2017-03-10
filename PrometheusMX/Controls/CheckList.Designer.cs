namespace Prometheus.Controls
{
  partial class CheckList
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
        // Unsubscribe to the theme event.
        if (renderer != null)
          renderer.ColorTableChanged -= OnColorTableChanged;

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
      this.components = new System.ComponentModel.Container();
      this.stCheckList = new DevComponents.DotNetBar.SuperTooltip();
      this.imgbClearAll = new Prometheus.Controls.ImageButton();
      this.imgbInvertChecks = new Prometheus.Controls.ImageButton();
      this.imgbCheckAll = new Prometheus.Controls.ImageButton();
      this.ipCheckList = new DevComponents.DotNetBar.ItemPanel();
      this.icGroup = new DevComponents.DotNetBar.ItemContainer();
      this.lblGroupLabel = new DevComponents.DotNetBar.LabelItem();
      this.icGroupItems = new DevComponents.DotNetBar.ItemContainer();
      this.checkBoxItem1 = new DevComponents.DotNetBar.CheckBoxItem();
      this.panelProgress = new System.Windows.Forms.Panel();
      this.timerUpdate = new System.Windows.Forms.Timer(this.components);
      this.busyIndicator = new Prometheus.Controls.TagExplorers.BusyIndicator();
      this.panelProgress.SuspendLayout();
      this.SuspendLayout();
      // 
      // stCheckList
      // 
      this.stCheckList.DefaultTooltipSettings = new DevComponents.DotNetBar.SuperTooltipInfo("", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0));
      this.stCheckList.GetType();
      this.stCheckList.MaximumWidth = 250;
      this.stCheckList.MinimumTooltipSize = new System.Drawing.Size(0, 19);
      this.stCheckList.PositionBelowControl = false;
      // 
      // imgbClearAll
      // 
      this.imgbClearAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.imgbClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbClearAll.Image = global::Prometheus.Properties.Resources.delete216;
      this.imgbClearAll.Location = new System.Drawing.Point(117, 87);
      this.imgbClearAll.Name = "imgbClearAll";
      this.imgbClearAll.Size = new System.Drawing.Size(23, 19);
      this.stCheckList.SetSuperTooltip(this.imgbClearAll, new DevComponents.DotNetBar.SuperTooltipInfo("Clear All Flags", "", "Uncheck all flags in the list, regardless of their current check state.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.imgbClearAll.TabIndex = 3;
      this.imgbClearAll.Click += new System.EventHandler(this.imgbClearAll_Click);
      // 
      // imgbInvertChecks
      // 
      this.imgbInvertChecks.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.imgbInvertChecks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbInvertChecks.Image = global::Prometheus.Properties.Resources.replace216;
      this.imgbInvertChecks.Location = new System.Drawing.Point(117, 26);
      this.imgbInvertChecks.Name = "imgbInvertChecks";
      this.imgbInvertChecks.Size = new System.Drawing.Size(23, 21);
      this.stCheckList.SetSuperTooltip(this.imgbInvertChecks, new DevComponents.DotNetBar.SuperTooltipInfo("Invert Selection", "", "Check all unchecked flags and uncheck all checked flags.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.imgbInvertChecks.TabIndex = 2;
      this.imgbInvertChecks.Click += new System.EventHandler(this.imgbInvertChecks_Click);
      // 
      // imgbCheckAll
      // 
      this.imgbCheckAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.imgbCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbCheckAll.Image = global::Prometheus.Properties.Resources.checks16;
      this.imgbCheckAll.Location = new System.Drawing.Point(117, 2);
      this.imgbCheckAll.Name = "imgbCheckAll";
      this.imgbCheckAll.Size = new System.Drawing.Size(23, 18);
      this.stCheckList.SetSuperTooltip(this.imgbCheckAll, new DevComponents.DotNetBar.SuperTooltipInfo("Check All Flags", "", "Check all flags in the list, regardless of their current check state.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.imgbCheckAll.TabIndex = 1;
      this.imgbCheckAll.Click += new System.EventHandler(this.imgbCheckAll_Click);
      // 
      // ipCheckList
      // 
      this.ipCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ipCheckList.AutoScroll = true;
      // 
      // 
      // 
      this.ipCheckList.BackgroundStyle.BackColor = System.Drawing.Color.White;
      this.ipCheckList.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipCheckList.BackgroundStyle.BorderBottomWidth = 1;
      this.ipCheckList.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipCheckList.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipCheckList.BackgroundStyle.BorderLeftWidth = 1;
      this.ipCheckList.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipCheckList.BackgroundStyle.BorderRightWidth = 1;
      this.ipCheckList.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipCheckList.BackgroundStyle.BorderTopWidth = 1;
      this.ipCheckList.BackgroundStyle.WordWrap = true;
      this.ipCheckList.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icGroup});
      this.ipCheckList.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipCheckList.GetType();
      this.ipCheckList.Location = new System.Drawing.Point(0, 0);
      this.ipCheckList.Name = "ipCheckList";
      this.ipCheckList.Size = new System.Drawing.Size(116, 104);
      this.ipCheckList.TabIndex = 0;
      this.ipCheckList.Resize += new System.EventHandler(this.ipCheckList_Resize);
      this.ipCheckList.ItemAdded += new System.EventHandler(this.ipCheckList_ItemAdded);
      // 
      // icGroup
      // 
      // 
      // 
      // 
      this.icGroup.BackgroundStyle.WordWrap = true;
      this.icGroup.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.icGroup.MinimumSize = new System.Drawing.Size(94, 0);
      this.icGroup.Name = "icGroup";
      this.icGroup.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblGroupLabel,
            this.icGroupItems});
      // 
      // lblGroupLabel
      // 
      this.lblGroupLabel.BackColor = System.Drawing.Color.LightSteelBlue;
      this.lblGroupLabel.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
      this.lblGroupLabel.BorderType = DevComponents.DotNetBar.eBorderType.Raised;
      this.lblGroupLabel.CanCustomize = false;
      this.lblGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGroupLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lblGroupLabel.Name = "lblGroupLabel";
      this.lblGroupLabel.PaddingBottom = 1;
      this.lblGroupLabel.PaddingTop = 1;
      this.lblGroupLabel.Text = "GroupName";
      this.lblGroupLabel.WordWrap = true;
      // 
      // icGroupItems
      // 
      this.icGroupItems.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.icGroupItems.MinimumSize = new System.Drawing.Size(0, 0);
      this.icGroupItems.Name = "icGroupItems";
      this.icGroupItems.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.checkBoxItem1});
      // 
      // checkBoxItem1
      // 
      this.checkBoxItem1.Name = "checkBoxItem1";
      this.checkBoxItem1.Text = "Test";
      // 
      // panelProgress
      // 
      this.panelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.panelProgress.BackColor = System.Drawing.Color.White;
      this.panelProgress.Controls.Add(this.busyIndicator);
      this.panelProgress.Location = new System.Drawing.Point(1, 1);
      this.panelProgress.Name = "panelProgress";
      this.panelProgress.Size = new System.Drawing.Size(114, 102);
      this.panelProgress.TabIndex = 0;
      this.panelProgress.Visible = false;
      this.panelProgress.VisibleChanged += new System.EventHandler(this.panelProgress_VisibleChanged);
      // 
      // timerUpdate
      // 
      this.timerUpdate.Interval = 300;
      this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
      // 
      // busyIndicator
      // 
      this.busyIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.busyIndicator.Angle = 0F;
      this.busyIndicator.BackColor = System.Drawing.Color.Transparent;
      this.busyIndicator.CircleDiameter = 10F;
      this.busyIndicator.ForeColor = System.Drawing.Color.DarkBlue;
      this.busyIndicator.Image = null;
      this.busyIndicator.Location = new System.Drawing.Point(30, 24);
      this.busyIndicator.Name = "busyIndicator";
      this.busyIndicator.Size = new System.Drawing.Size(54, 54);
      this.busyIndicator.TabIndex = 1;
      this.busyIndicator.Text = "busyIndicator1";
      // 
      // CheckList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.panelProgress);
      this.Controls.Add(this.imgbClearAll);
      this.Controls.Add(this.imgbInvertChecks);
      this.Controls.Add(this.imgbCheckAll);
      this.Controls.Add(this.ipCheckList);
      this.DoubleBuffered = true;
      this.MinimumSize = new System.Drawing.Size(95, 75);
      this.Name = "CheckList";
      this.Size = new System.Drawing.Size(139, 104);
      this.Load += new System.EventHandler(this.CheckList_Load);
      this.panelProgress.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.SuperTooltip stCheckList;
    private DevComponents.DotNetBar.ItemPanel ipCheckList;
    private ImageButton imgbCheckAll;
    private ImageButton imgbInvertChecks;
    private ImageButton imgbClearAll;
    private DevComponents.DotNetBar.ItemContainer icGroup;
    private DevComponents.DotNetBar.ItemContainer icGroupItems;
    private DevComponents.DotNetBar.CheckBoxItem checkBoxItem1;
    private DevComponents.DotNetBar.LabelItem lblGroupLabel;
    private System.Windows.Forms.Panel panelProgress;
    private System.Windows.Forms.Timer timerUpdate;
    private Prometheus.Controls.TagExplorers.BusyIndicator busyIndicator;


  }
}