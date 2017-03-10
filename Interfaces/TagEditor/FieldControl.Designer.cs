namespace Interfaces.TagEditor
{
  partial class FieldControl
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

        stFieldControl.SetSuperTooltip(imgbError, null);
        stFieldControl.SetSuperTooltip(imgbLockStatus, null);
        stFieldControl.SetSuperTooltip(imgbRevertChanges, null);
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
      this.panelContainer = new System.Windows.Forms.Panel();
      this.lblTitle = new System.Windows.Forms.Label();
      this.titleContainer = new System.Windows.Forms.Panel();
      this.imgbError = new Prometheus.Controls.ImageButton();
      this.imgbRevertChanges = new Prometheus.Controls.ImageButton();
      this.imgbLockStatus = new Prometheus.Controls.ImageButton();
      this.titleContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.BackColor = System.Drawing.Color.Transparent;
      this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelContainer.Location = new System.Drawing.Point(132, 0);
      this.panelContainer.Name = "panelContainer";
      this.panelContainer.Size = new System.Drawing.Size(243, 27);
      this.panelContainer.TabIndex = 0;
      // 
      // lblTitle
      // 
      this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTitle.AutoEllipsis = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 7F);
      this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
      this.lblTitle.Location = new System.Drawing.Point(2, 5);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.lblTitle.Size = new System.Drawing.Size(128, 17);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Title";
      // 
      // titleContainer
      // 
      this.titleContainer.BackColor = System.Drawing.Color.Transparent;
      this.titleContainer.Controls.Add(this.imgbError);
      this.titleContainer.Controls.Add(this.imgbRevertChanges);
      this.titleContainer.Controls.Add(this.imgbLockStatus);
      this.titleContainer.Controls.Add(this.lblTitle);
      this.titleContainer.Dock = System.Windows.Forms.DockStyle.Left;
      this.titleContainer.Location = new System.Drawing.Point(0, 0);
      this.titleContainer.Name = "titleContainer";
      this.titleContainer.Size = new System.Drawing.Size(132, 27);
      this.titleContainer.TabIndex = 0;
      // 
      // imgbError
      // 
      this.imgbError.Image = global::Interfaces.Properties.Resources.warning16;
      this.imgbError.Location = new System.Drawing.Point(2, 5);
      this.imgbError.Name = "imgbError";
      this.imgbError.ShowFocusRectangle = false;
      this.imgbError.Size = new System.Drawing.Size(16, 16);
      this.imgbError.TabIndex = 1;
      this.imgbError.TabStop = false;
      this.imgbError.Visible = false;
      this.imgbError.VisibleChanged += new System.EventHandler(this.imageButton_VisibleChanged);
      this.imgbError.Click += new System.EventHandler(this.imgbError_Click);
      // 
      // imgbRevertChanges
      // 
      this.imgbRevertChanges.Image = global::Interfaces.Properties.Resources.edit16;
      this.imgbRevertChanges.Location = new System.Drawing.Point(2, 5);
      this.imgbRevertChanges.Name = "imgbRevertChanges";
      this.imgbRevertChanges.ShowFocusRectangle = false;
      this.imgbRevertChanges.Size = new System.Drawing.Size(16, 16);
      this.imgbRevertChanges.TabIndex = 0;
      this.imgbRevertChanges.TabStop = false;
      this.imgbRevertChanges.Visible = false;
      this.imgbRevertChanges.VisibleChanged += new System.EventHandler(this.imageButton_VisibleChanged);
      this.imgbRevertChanges.Click += new System.EventHandler(this.imgbRevertChanges_Click);
      // 
      // imgbLockStatus
      // 
      this.imgbLockStatus.Image = global::Interfaces.Properties.Resources.lock16;
      this.imgbLockStatus.Location = new System.Drawing.Point(2, 5);
      this.imgbLockStatus.Name = "imgbLockStatus";
      this.imgbLockStatus.ShowFocusRectangle = false;
      this.imgbLockStatus.Size = new System.Drawing.Size(16, 16);
      this.imgbLockStatus.TabIndex = 0;
      this.imgbLockStatus.TabStop = false;
      this.imgbLockStatus.Visible = false;
      this.imgbLockStatus.VisibleChanged += new System.EventHandler(this.imageButton_VisibleChanged);
      this.imgbLockStatus.Click += new System.EventHandler(this.imgbLockStatus_Click);
      // 
      // FieldControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.panelContainer);
      this.Controls.Add(this.titleContainer);
      this.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(106)))), ((int)(((byte)(170)))));
      this.Name = "FieldControl";
      this.Size = new System.Drawing.Size(375, 27);
      this.titleContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    protected System.Windows.Forms.Panel panelContainer;
    private System.Windows.Forms.Panel titleContainer;
    private Prometheus.Controls.ImageButton imgbLockStatus;
    private Prometheus.Controls.ImageButton imgbRevertChanges;
    private Prometheus.Controls.ImageButton imgbError;
  }
}
