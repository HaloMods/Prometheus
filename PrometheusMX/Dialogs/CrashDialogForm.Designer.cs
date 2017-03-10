namespace Prometheus.Dialogs
{
  partial class CrashDialogForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrashDialogForm));
      this.txtError = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.btnSubmitReport = new DevComponents.DotNetBar.ButtonX();
      this.cbRestart = new DevComponents.DotNetBar.Controls.CheckBoxX();
      this.btnExit = new DevComponents.DotNetBar.ButtonX();
      this.pxCrashDialog = new DevComponents.DotNetBar.PanelEx();
      this.pxCrashDialog.SuspendLayout();
      this.SuspendLayout();
      // 
      // txtError
      // 
      // 
      // 
      // 
      this.txtError.Border.Class = "TextBoxBorder";
      this.txtError.Location = new System.Drawing.Point(6, 49);
      this.txtError.Multiline = true;
      this.txtError.Name = "txtError";
      this.txtError.ReadOnly = true;
      this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtError.Size = new System.Drawing.Size(510, 78);
      this.txtError.TabIndex = 0;
      this.txtError.TabStop = false;
      // 
      // btnSubmitReport
      // 
      this.btnSubmitReport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnSubmitReport.Image = global::Prometheus.Properties.Resources.bugmail16;
      this.btnSubmitReport.Location = new System.Drawing.Point(6, 133);
      this.btnSubmitReport.Name = "btnSubmitReport";
      this.btnSubmitReport.Size = new System.Drawing.Size(119, 23);
      this.btnSubmitReport.TabIndex = 1;
      this.btnSubmitReport.Text = "Submit Report";
      this.btnSubmitReport.Click += new System.EventHandler(this.btnSubmitReport_Click);
      // 
      // cbRestart
      // 
      this.cbRestart.Checked = true;
      this.cbRestart.Location = new System.Drawing.Point(326, 133);
      this.cbRestart.Name = "cbRestart";
      this.cbRestart.Size = new System.Drawing.Size(118, 23);
      this.cbRestart.TabIndex = 2;
      this.cbRestart.Text = "Restart Prometheus";
      // 
      // btnExit
      // 
      this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Image = global::Prometheus.Properties.Resources.exit16;
      this.btnExit.Location = new System.Drawing.Point(450, 133);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(66, 23);
      this.btnExit.TabIndex = 3;
      this.btnExit.Text = "Exit";
      this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
      // 
      // pxCrashDialog
      // 
      this.pxCrashDialog.CanvasColor = System.Drawing.Color.Transparent;
      this.pxCrashDialog.ColorScheme.BarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(208)))), ((int)(((byte)(213)))));
      this.pxCrashDialog.ColorScheme.BarBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(146)))), ((int)(((byte)(155)))));
      this.pxCrashDialog.ColorScheme.BarCaptionBackground = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(128)))), ((int)(((byte)(142)))));
      this.pxCrashDialog.ColorScheme.BarCaptionBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(83)))), ((int)(((byte)(92)))));
      this.pxCrashDialog.ColorScheme.BarCaptionInactiveBackground = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
      this.pxCrashDialog.ColorScheme.BarCaptionInactiveBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
      this.pxCrashDialog.ColorScheme.BarCaptionInactiveText = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
      this.pxCrashDialog.ColorScheme.BarDockedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(83)))), ((int)(((byte)(92)))));
      this.pxCrashDialog.ColorScheme.BarFloatingBorder = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
      this.pxCrashDialog.ColorScheme.BarPopupBorder = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
      this.pxCrashDialog.ColorScheme.BarStripeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(67)))));
      this.pxCrashDialog.ColorScheme.CustomizeBackground = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(183)))), ((int)(((byte)(191)))));
      this.pxCrashDialog.ColorScheme.CustomizeBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(88)))), ((int)(((byte)(98)))));
      this.pxCrashDialog.ColorScheme.DockSiteBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
      this.pxCrashDialog.ColorScheme.ExplorerBarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
      this.pxCrashDialog.ColorScheme.ExplorerBarBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
      this.pxCrashDialog.ColorScheme.ItemCheckedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(211)))), ((int)(((byte)(106)))));
      this.pxCrashDialog.ColorScheme.ItemDesignTimeBorder = System.Drawing.Color.Black;
      this.pxCrashDialog.ColorScheme.ItemExpandedBackground = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
      this.pxCrashDialog.ColorScheme.ItemExpandedBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
      this.pxCrashDialog.ColorScheme.ItemExpandedBorder = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
      this.pxCrashDialog.ColorScheme.ItemSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
      this.pxCrashDialog.ColorScheme.ItemSeparatorShade = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
      this.pxCrashDialog.ColorScheme.MenuBarBackground = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
      this.pxCrashDialog.ColorScheme.MenuBorder = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(153)))), ((int)(((byte)(164)))));
      this.pxCrashDialog.ColorScheme.MenuSide = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
      this.pxCrashDialog.ColorScheme.MenuUnusedSide = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
      this.pxCrashDialog.ColorScheme.PanelBackground = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(241)))), ((int)(((byte)(242)))));
      this.pxCrashDialog.ColorScheme.PanelBackground2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(194)))), ((int)(((byte)(201)))));
      this.pxCrashDialog.ColorScheme.PanelBorder = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(182)))));
      this.pxCrashDialog.ColorScheme.PanelText = System.Drawing.Color.Black;
      this.pxCrashDialog.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.pxCrashDialog.Controls.Add(this.txtError);
      this.pxCrashDialog.Controls.Add(this.btnSubmitReport);
      this.pxCrashDialog.Controls.Add(this.btnExit);
      this.pxCrashDialog.Controls.Add(this.cbRestart);
      this.pxCrashDialog.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pxCrashDialog.Location = new System.Drawing.Point(0, 0);
      this.pxCrashDialog.Name = "pxCrashDialog";
      this.pxCrashDialog.Size = new System.Drawing.Size(522, 162);
      this.pxCrashDialog.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.pxCrashDialog.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.pxCrashDialog.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.pxCrashDialog.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.pxCrashDialog.Style.GradientAngle = 90;
      this.pxCrashDialog.Style.MarginLeft = 2;
      this.pxCrashDialog.Style.MarginRight = 3;
      this.pxCrashDialog.Style.MarginTop = 3;
      this.pxCrashDialog.TabIndex = 6;
      this.pxCrashDialog.Text = resources.GetString("pxCrashDialog.Text");
      // 
      // CrashDialogForm
      // 
      this.AcceptButton = this.btnSubmitReport;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnExit;
      this.ClientSize = new System.Drawing.Size(522, 162);
      this.ControlBox = false;
      this.Controls.Add(this.pxCrashDialog);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(528, 186);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(528, 186);
      this.Name = "CrashDialogForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Slipspace Rupture";
      this.pxCrashDialog.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtError;
    private DevComponents.DotNetBar.ButtonX btnSubmitReport;
    private DevComponents.DotNetBar.Controls.CheckBoxX cbRestart;
    private DevComponents.DotNetBar.ButtonX btnExit;
    private DevComponents.DotNetBar.PanelEx pxCrashDialog;
  }
}