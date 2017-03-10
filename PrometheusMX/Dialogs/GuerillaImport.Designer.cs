namespace Prometheus.Dialogs
{
  partial class GuerillaImport
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
        this.lbTags = new System.Windows.Forms.ListBox();
        this.bxAddTag = new DevComponents.DotNetBar.ButtonX();
        this.bxRemoveTag = new DevComponents.DotNetBar.ButtonX();
        this.bxClearTags = new DevComponents.DotNetBar.ButtonX();
        this.bxCancel = new DevComponents.DotNetBar.ButtonX();
        this.bxImportTags = new DevComponents.DotNetBar.ButtonX();
        this.SuspendLayout();
        // 
        // lbTags
        // 
        this.lbTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
        this.lbTags.FormattingEnabled = true;
        this.lbTags.Items.AddRange(new object[] {
            "This",
            "Is",
            "A",
            "Test",
            "Of",
            "This",
            "List",
            "Box",
            "."});
        this.lbTags.Location = new System.Drawing.Point(2, 5);
        this.lbTags.Name = "lbTags";
        this.lbTags.Size = new System.Drawing.Size(320, 199);
        this.lbTags.TabIndex = 0;
        // 
        // bxAddTag
        // 
        this.bxAddTag.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxAddTag.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxAddTag.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
        this.bxAddTag.Image = global::Prometheus.Properties.Resources.document_plain_new16;
        this.bxAddTag.Location = new System.Drawing.Point(2, 208);
        this.bxAddTag.Name = "bxAddTag";
        this.bxAddTag.Size = new System.Drawing.Size(35, 20);
        this.bxAddTag.TabIndex = 1;
        // 
        // bxRemoveTag
        // 
        this.bxRemoveTag.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxRemoveTag.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxRemoveTag.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
        this.bxRemoveTag.Image = global::Prometheus.Properties.Resources.delete216;
        this.bxRemoveTag.Location = new System.Drawing.Point(43, 208);
        this.bxRemoveTag.Name = "bxRemoveTag";
        this.bxRemoveTag.Size = new System.Drawing.Size(35, 20);
        this.bxRemoveTag.TabIndex = 2;
        this.bxRemoveTag.Click += new System.EventHandler(this.bxRemoveTag_Click);
        // 
        // bxClearTags
        // 
        this.bxClearTags.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxClearTags.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxClearTags.ColorTable = DevComponents.DotNetBar.eButtonColor.Magenta;
        this.bxClearTags.Location = new System.Drawing.Point(276, 208);
        this.bxClearTags.Name = "bxClearTags";
        this.bxClearTags.Size = new System.Drawing.Size(46, 20);
        this.bxClearTags.TabIndex = 3;
        this.bxClearTags.Text = "&Clear";
        this.bxClearTags.Click += new System.EventHandler(this.bxClearTags_Click);
        // 
        // bxCancel
        // 
        this.bxCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxCancel.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
        this.bxCancel.Location = new System.Drawing.Point(247, 242);
        this.bxCancel.Name = "bxCancel";
        this.bxCancel.Size = new System.Drawing.Size(75, 23);
        this.bxCancel.TabIndex = 5;
        this.bxCancel.Text = "Ca&ncel";
        this.bxCancel.Click += new System.EventHandler(this.bxCancel_Click);
        // 
        // bxImportTags
        // 
        this.bxImportTags.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxImportTags.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxImportTags.Location = new System.Drawing.Point(2, 242);
        this.bxImportTags.Name = "bxImportTags";
        this.bxImportTags.Size = new System.Drawing.Size(75, 23);
        this.bxImportTags.TabIndex = 4;
        this.bxImportTags.Text = "&Import";
        // 
        // GuerillaImport
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CaptionFont = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
        this.ClientSize = new System.Drawing.Size(326, 268);
        this.Controls.Add(this.bxCancel);
        this.Controls.Add(this.bxImportTags);
        this.Controls.Add(this.bxClearTags);
        this.Controls.Add(this.bxRemoveTag);
        this.Controls.Add(this.bxAddTag);
        this.Controls.Add(this.lbTags);
        this.MaximizeBox = false;
        this.Name = "GuerillaImport";
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Guerilla Tag Import";
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListBox lbTags;
    private DevComponents.DotNetBar.ButtonX bxAddTag;
    private DevComponents.DotNetBar.ButtonX bxRemoveTag;
    private DevComponents.DotNetBar.ButtonX bxClearTags;
    private DevComponents.DotNetBar.ButtonX bxCancel;
    private DevComponents.DotNetBar.ButtonX bxImportTags;
  }
}