using Prometheus.Controls.ReferenceAnalyzer;

namespace Prometheus.Dialogs
{
  partial class ReferenceAnalyzer
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceAnalyzer));
        this.bxOutputToFile = new DevComponents.DotNetBar.ButtonX();
        this.bxPurgeAll = new DevComponents.DotNetBar.ButtonX();
        this.ipTotal = new DevComponents.DotNetBar.ItemPanel();
        this.liTotal = new DevComponents.DotNetBar.LabelItem();
        this.liTotalValue = new DevComponents.DotNetBar.LabelItem();
        this.barStatus = new DevComponents.DotNetBar.Bar();
        this.liStatus = new DevComponents.DotNetBar.LabelItem();
        this.liViewMode = new DevComponents.DotNetBar.LabelItem();
        this.rcAnalyzer = new Prometheus.Controls.ReferenceAnalyzer.ReferenceContainer();
        ((System.ComponentModel.ISupportInitialize)(this.barStatus)).BeginInit();
        this.SuspendLayout();
        // 
        // bxOutputToFile
        // 
        this.bxOutputToFile.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxOutputToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bxOutputToFile.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxOutputToFile.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
        this.bxOutputToFile.Location = new System.Drawing.Point(186, 206);
        this.bxOutputToFile.Name = "bxOutputToFile";
        this.bxOutputToFile.Size = new System.Drawing.Size(85, 23);
        this.bxOutputToFile.TabIndex = 1;
        this.bxOutputToFile.Text = "Output to File";
        // 
        // bxPurgeAll
        // 
        this.bxPurgeAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxPurgeAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.bxPurgeAll.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxPurgeAll.Location = new System.Drawing.Point(4, 206);
        this.bxPurgeAll.Name = "bxPurgeAll";
        this.bxPurgeAll.Size = new System.Drawing.Size(163, 23);
        this.bxPurgeAll.TabIndex = 2;
        this.bxPurgeAll.Text = "Purge All Missing References";
        // 
        // ipTotal
        // 
        this.ipTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.ipTotal.AutoScroll = true;
        // 
        // 
        // 
        this.ipTotal.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
        this.ipTotal.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
        this.ipTotal.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liTotal,
            this.liTotalValue});
        this.ipTotal.GetType();
        this.ipTotal.Location = new System.Drawing.Point(342, 211);
        this.ipTotal.Name = "ipTotal";
        this.ipTotal.Size = new System.Drawing.Size(56, 20);
        this.ipTotal.TabIndex = 7;
        this.ipTotal.Text = "ipTotal";
        // 
        // liTotal
        // 
        this.liTotal.BorderType = DevComponents.DotNetBar.eBorderType.None;
        this.liTotal.Name = "liTotal";
        this.liTotal.Text = "Total:";
        // 
        // liTotalValue
        // 
        this.liTotalValue.BorderType = DevComponents.DotNetBar.eBorderType.None;
        this.liTotalValue.Name = "liTotalValue";
        this.liTotalValue.Text = "0";
        this.liTotalValue.TextAlignment = System.Drawing.StringAlignment.Far;
        this.liTotalValue.Width = 25;
        // 
        // barStatus
        // 
        this.barStatus.AccessibleDescription = "DotNetBar Bar (barStatus)";
        this.barStatus.AccessibleName = "DotNetBar Bar";
        this.barStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
        this.barStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
        this.barStatus.CanDockBottom = false;
        this.barStatus.CanDockLeft = false;
        this.barStatus.CanDockRight = false;
        this.barStatus.CanDockTab = false;
        this.barStatus.CanDockTop = false;
        this.barStatus.CanReorderTabs = false;
        this.barStatus.CanUndock = false;
        this.barStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.barStatus.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
        this.barStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liStatus,
            this.liViewMode});
        this.barStatus.Location = new System.Drawing.Point(0, 232);
        this.barStatus.Margin = new System.Windows.Forms.Padding(0);
        this.barStatus.Name = "barStatus";
        this.barStatus.PaddingBottom = 0;
        this.barStatus.PaddingLeft = 0;
        this.barStatus.PaddingRight = 0;
        this.barStatus.PaddingTop = 2;
        this.barStatus.SingleLineColor = System.Drawing.Color.Empty;
        this.barStatus.Size = new System.Drawing.Size(404, 23);
        this.barStatus.Stretch = true;
        this.barStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
        this.barStatus.TabIndex = 13;
        this.barStatus.TabStop = false;
        // 
        // liStatus
        // 
        this.liStatus.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner;
        this.liStatus.Name = "liStatus";
        this.liStatus.PaddingLeft = 5;
        this.liStatus.Text = "Broken tag references are ready for purging or repair.";
        // 
        // liViewMode
        // 
        this.liViewMode.BorderType = DevComponents.DotNetBar.eBorderType.None;
        this.liViewMode.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
        this.liViewMode.Name = "liViewMode";
        this.liViewMode.Text = "Tag View";
        // 
        // rcAnalyzer
        // 
        this.rcAnalyzer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.rcAnalyzer.AutoScroll = true;
        this.rcAnalyzer.BackColor = System.Drawing.Color.WhiteSmoke;
        this.rcAnalyzer.Location = new System.Drawing.Point(4, 4);
        this.rcAnalyzer.Name = "rcAnalyzer";
        this.rcAnalyzer.Size = new System.Drawing.Size(396, 198);
        this.rcAnalyzer.TabIndex = 12;
        this.rcAnalyzer.CountChanged += new System.EventHandler(this.rcAnalyzer_CountChanged);
        // 
        // ReferenceAnalyzer
        // 
        this.CaptionFont = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ClientSize = new System.Drawing.Size(404, 255);
        this.Controls.Add(this.barStatus);
        this.Controls.Add(this.rcAnalyzer);
        this.Controls.Add(this.ipTotal);
        this.Controls.Add(this.bxPurgeAll);
        this.Controls.Add(this.bxOutputToFile);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximumSize = new System.Drawing.Size(550, 600);
        this.MinimumSize = new System.Drawing.Size(410, 288);
        this.Name = "ReferenceAnalyzer";
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Reference Analyzer";
        ((System.ComponentModel.ISupportInitialize)(this.barStatus)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX bxOutputToFile;
    private DevComponents.DotNetBar.ButtonX bxPurgeAll;
    private DevComponents.DotNetBar.ItemPanel ipTotal;
    private DevComponents.DotNetBar.LabelItem liTotal;
    private DevComponents.DotNetBar.LabelItem liTotalValue;
    private ReferenceContainer rcAnalyzer;
    private DevComponents.DotNetBar.Bar barStatus;
    private DevComponents.DotNetBar.LabelItem liStatus;
    private DevComponents.DotNetBar.LabelItem liViewMode;
  }
}