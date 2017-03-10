namespace Prometheus.Controls.TagExplorers
{
  partial class ExtractionProgressPanel
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
      this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
      this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
      this.lblExtension = new System.Windows.Forms.Label();
      this.busyIndicator = new Prometheus.Controls.TagExplorers.BusyIndicator();
      this.lblFilename = new System.Windows.Forms.Label();
      this.lblCurrentMap = new System.Windows.Forms.Label();
      this.lblFolder = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
      this.pbExtractionProgress = new DevComponents.DotNetBar.Controls.ProgressBarX();
      this.btnCancel = new DevComponents.DotNetBar.ButtonX();
      this.lblOverallProgress = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.panelEx5 = new DevComponents.DotNetBar.PanelEx();
      this.lblTitle = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
      this.lblStatus = new System.Windows.Forms.Label();
      this.panelEx1.SuspendLayout();
      this.panelEx3.SuspendLayout();
      this.panelEx2.SuspendLayout();
      this.panelEx5.SuspendLayout();
      this.panelEx4.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelEx1
      // 
      this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
      this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.panelEx1.Controls.Add(this.panelEx3);
      this.panelEx1.Controls.Add(this.label3);
      this.panelEx1.Controls.Add(this.panelEx2);
      this.panelEx1.Controls.Add(this.label2);
      this.panelEx1.Controls.Add(this.panelEx5);
      this.panelEx1.Controls.Add(this.label5);
      this.panelEx1.Controls.Add(this.panelEx4);
      this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelEx1.Location = new System.Drawing.Point(0, 0);
      this.panelEx1.MinimumSize = new System.Drawing.Size(166, 302);
      this.panelEx1.Name = "panelEx1";
      this.panelEx1.Padding = new System.Windows.Forms.Padding(6);
      this.panelEx1.Size = new System.Drawing.Size(166, 302);
      this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.panelEx1.Style.GradientAngle = 90;
      this.panelEx1.TabIndex = 0;
      // 
      // panelEx3
      // 
      this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
      this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.panelEx3.Controls.Add(this.lblExtension);
      this.panelEx3.Controls.Add(this.busyIndicator);
      this.panelEx3.Controls.Add(this.lblFilename);
      this.panelEx3.Controls.Add(this.lblCurrentMap);
      this.panelEx3.Controls.Add(this.lblFolder);
      this.panelEx3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelEx3.Location = new System.Drawing.Point(6, 38);
      this.panelEx3.MinimumSize = new System.Drawing.Size(100, 118);
      this.panelEx3.Name = "panelEx3";
      this.panelEx3.Size = new System.Drawing.Size(154, 123);
      this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.panelEx3.Style.BackColor1.Alpha = ((byte)(0));
      this.panelEx3.Style.BackColor1.Color = System.Drawing.Color.Transparent;
      this.panelEx3.Style.BackColor2.Alpha = ((byte)(0));
      this.panelEx3.Style.BackColor2.Color = System.Drawing.Color.Transparent;
      this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.panelEx3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.panelEx3.Style.GradientAngle = 90;
      this.panelEx3.TabIndex = 7;
      // 
      // lblExtension
      // 
      this.lblExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblExtension.AutoEllipsis = true;
      this.lblExtension.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblExtension.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lblExtension.Location = new System.Drawing.Point(10, 103);
      this.lblExtension.Name = "lblExtension";
      this.lblExtension.Size = new System.Drawing.Size(135, 14);
      this.lblExtension.TabIndex = 8;
      this.lblExtension.Text = "scenario_structure_bsp";
      this.lblExtension.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // busyIndicator
      // 
      this.busyIndicator.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.busyIndicator.Angle = 0F;
      this.busyIndicator.BackColor = System.Drawing.Color.Transparent;
      this.busyIndicator.CircleDiameter = 6F;
      this.busyIndicator.ForeColor = System.Drawing.Color.SeaGreen;
      this.busyIndicator.Image = null;
      this.busyIndicator.Location = new System.Drawing.Point(61, 40);
      this.busyIndicator.Name = "busyIndicator";
      this.busyIndicator.Size = new System.Drawing.Size(34, 33);
      this.busyIndicator.TabIndex = 2;
      this.busyIndicator.Text = "busyIndicator1";
      // 
      // lblFilename
      // 
      this.lblFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblFilename.AutoEllipsis = true;
      this.lblFilename.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFilename.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lblFilename.Location = new System.Drawing.Point(10, 90);
      this.lblFilename.Name = "lblFilename";
      this.lblFilename.Size = new System.Drawing.Size(135, 15);
      this.lblFilename.TabIndex = 7;
      this.lblFilename.Text = "gephyrophobia";
      this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblCurrentMap
      // 
      this.lblCurrentMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCurrentMap.AutoEllipsis = true;
      this.lblCurrentMap.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCurrentMap.ForeColor = System.Drawing.Color.Navy;
      this.lblCurrentMap.Location = new System.Drawing.Point(8, 6);
      this.lblCurrentMap.Name = "lblCurrentMap";
      this.lblCurrentMap.Size = new System.Drawing.Size(139, 31);
      this.lblCurrentMap.TabIndex = 5;
      this.lblCurrentMap.Text = "Extracting from gephyrophopia.map";
      this.lblCurrentMap.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // lblFolder
      // 
      this.lblFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblFolder.AutoEllipsis = true;
      this.lblFolder.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFolder.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lblFolder.Location = new System.Drawing.Point(10, 77);
      this.lblFolder.Name = "lblFolder";
      this.lblFolder.Size = new System.Drawing.Size(135, 15);
      this.lblFolder.TabIndex = 6;
      this.lblFolder.Text = "levels\\test\\gephyrophobia";
      this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label3
      // 
      this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label3.Location = new System.Drawing.Point(6, 161);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(154, 6);
      this.label3.TabIndex = 12;
      // 
      // panelEx2
      // 
      this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
      this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.panelEx2.Controls.Add(this.pbExtractionProgress);
      this.panelEx2.Controls.Add(this.btnCancel);
      this.panelEx2.Controls.Add(this.lblOverallProgress);
      this.panelEx2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelEx2.Location = new System.Drawing.Point(6, 167);
      this.panelEx2.MinimumSize = new System.Drawing.Size(154, 94);
      this.panelEx2.Name = "panelEx2";
      this.panelEx2.Size = new System.Drawing.Size(154, 94);
      this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.panelEx2.Style.BackColor1.Alpha = ((byte)(0));
      this.panelEx2.Style.BackColor1.Color = System.Drawing.Color.Transparent;
      this.panelEx2.Style.BackColor2.Alpha = ((byte)(0));
      this.panelEx2.Style.BackColor2.Color = System.Drawing.Color.Transparent;
      this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.panelEx2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.panelEx2.Style.GradientAngle = 90;
      this.panelEx2.TabIndex = 5;
      // 
      // pbExtractionProgress
      // 
      this.pbExtractionProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pbExtractionProgress.Location = new System.Drawing.Point(10, 31);
      this.pbExtractionProgress.Name = "pbExtractionProgress";
      this.pbExtractionProgress.Size = new System.Drawing.Size(132, 20);
      this.pbExtractionProgress.TabIndex = 0;
      this.pbExtractionProgress.Text = "progressBarX1";
      this.pbExtractionProgress.Value = 45;
      // 
      // btnCancel
      // 
      this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.btnCancel.ColorScheme.DockSiteBackColorGradientAngle = 0;
      this.btnCancel.Location = new System.Drawing.Point(32, 59);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(83, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      // 
      // lblOverallProgress
      // 
      this.lblOverallProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblOverallProgress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblOverallProgress.ForeColor = System.Drawing.Color.Navy;
      this.lblOverallProgress.Location = new System.Drawing.Point(6, 7);
      this.lblOverallProgress.Name = "lblOverallProgress";
      this.lblOverallProgress.Size = new System.Drawing.Size(141, 19);
      this.lblOverallProgress.TabIndex = 3;
      this.lblOverallProgress.Text = "Overall Progress";
      this.lblOverallProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Dock = System.Windows.Forms.DockStyle.Top;
      this.label2.Location = new System.Drawing.Point(6, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(154, 6);
      this.label2.TabIndex = 11;
      // 
      // panelEx5
      // 
      this.panelEx5.CanvasColor = System.Drawing.SystemColors.Control;
      this.panelEx5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.panelEx5.Controls.Add(this.lblTitle);
      this.panelEx5.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelEx5.Location = new System.Drawing.Point(6, 6);
      this.panelEx5.MinimumSize = new System.Drawing.Size(100, 26);
      this.panelEx5.Name = "panelEx5";
      this.panelEx5.Size = new System.Drawing.Size(154, 26);
      this.panelEx5.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.panelEx5.Style.BackColor1.Alpha = ((byte)(0));
      this.panelEx5.Style.BackColor1.Color = System.Drawing.Color.Transparent;
      this.panelEx5.Style.BackColor2.Alpha = ((byte)(0));
      this.panelEx5.Style.BackColor2.Color = System.Drawing.Color.Transparent;
      this.panelEx5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.panelEx5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.panelEx5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.panelEx5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.panelEx5.Style.GradientAngle = 90;
      this.panelEx5.TabIndex = 10;
      // 
      // lblTitle
      // 
      this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTitle.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.ForeColor = System.Drawing.Color.Navy;
      this.lblTitle.Location = new System.Drawing.Point(7, 1);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(141, 27);
      this.lblTitle.TabIndex = 4;
      this.lblTitle.Text = "Extracting Tags...";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label5
      // 
      this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.label5.Location = new System.Drawing.Point(6, 261);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(154, 6);
      this.label5.TabIndex = 8;
      // 
      // panelEx4
      // 
      this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
      this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.panelEx4.Controls.Add(this.lblStatus);
      this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelEx4.Location = new System.Drawing.Point(6, 267);
      this.panelEx4.Name = "panelEx4";
      this.panelEx4.Size = new System.Drawing.Size(154, 29);
      this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.panelEx4.Style.BackColor1.Alpha = ((byte)(0));
      this.panelEx4.Style.BackColor1.Color = System.Drawing.Color.Transparent;
      this.panelEx4.Style.BackColor2.Alpha = ((byte)(0));
      this.panelEx4.Style.BackColor2.Color = System.Drawing.Color.Transparent;
      this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.panelEx4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.panelEx4.Style.GradientAngle = 90;
      this.panelEx4.TabIndex = 9;
      // 
      // lblStatus
      // 
      this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lblStatus.AutoEllipsis = true;
      this.lblStatus.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lblStatus.Location = new System.Drawing.Point(7, 7);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(139, 17);
      this.lblStatus.TabIndex = 5;
      this.lblStatus.Text = "Extracted 4,516 of 19,876 tags.";
      this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // ExtractionProgressPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.panelEx1);
      this.Name = "ExtractionProgressPanel";
      this.Size = new System.Drawing.Size(166, 302);
      this.panelEx1.ResumeLayout(false);
      this.panelEx3.ResumeLayout(false);
      this.panelEx2.ResumeLayout(false);
      this.panelEx5.ResumeLayout(false);
      this.panelEx4.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.PanelEx panelEx1;
    private DevComponents.DotNetBar.Controls.ProgressBarX pbExtractionProgress;
    private BusyIndicator busyIndicator;
    private DevComponents.DotNetBar.ButtonX btnCancel;
    private System.Windows.Forms.Label lblOverallProgress;
    private DevComponents.DotNetBar.PanelEx panelEx2;
    private System.Windows.Forms.Label lblCurrentMap;
    private DevComponents.DotNetBar.PanelEx panelEx3;
    private System.Windows.Forms.Label lblExtension;
    private System.Windows.Forms.Label lblFilename;
    private System.Windows.Forms.Label lblFolder;
    private System.Windows.Forms.Label label5;
    private DevComponents.DotNetBar.PanelEx panelEx4;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private DevComponents.DotNetBar.PanelEx panelEx5;
    private System.Windows.Forms.Label lblTitle;
  }
}
