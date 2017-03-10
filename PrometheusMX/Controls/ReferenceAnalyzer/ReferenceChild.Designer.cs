namespace Prometheus.Controls.ReferenceAnalyzer
{
  partial class ReferenceChild
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
      this.components = new System.ComponentModel.Container();
      this.cmsDirect = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuNullRef = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuSelectLocation = new System.Windows.Forms.ToolStripMenuItem();
      this.cmsRecursive = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuGotoRef = new System.Windows.Forms.ToolStripMenuItem();
      this.ipReferenceChild = new DevComponents.DotNetBar.ItemPanel();
      this.icErrorReference = new DevComponents.DotNetBar.ItemContainer();
      this.liReference = new DevComponents.DotNetBar.LabelItem();
      this.cmsDirect.SuspendLayout();
      this.cmsRecursive.SuspendLayout();
      this.SuspendLayout();
      // 
      // cmsDirect
      // 
      this.cmsDirect.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNullRef,
            this.mnuSelectLocation});
      this.cmsDirect.Name = "cmsDirect";
      this.cmsDirect.Size = new System.Drawing.Size(168, 48);
      // 
      // mnuNullRef
      // 
      this.mnuNullRef.Name = "mnuNullRef";
      this.mnuNullRef.Size = new System.Drawing.Size(167, 22);
      this.mnuNullRef.Text = "&Null Tag Reference";
      this.mnuNullRef.Click += new System.EventHandler(this.mnuNullRef_Click);
      // 
      // mnuSelectLocation
      // 
      this.mnuSelectLocation.Name = "mnuSelectLocation";
      this.mnuSelectLocation.Size = new System.Drawing.Size(167, 22);
      this.mnuSelectLocation.Text = "&Select Tag Location";
      this.mnuSelectLocation.Click += new System.EventHandler(this.mnuSelectLocation_Click);
      // 
      // cmsRecursive
      // 
      this.cmsRecursive.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGotoRef});
      this.cmsRecursive.Name = "cmsDirect";
      this.cmsRecursive.Size = new System.Drawing.Size(193, 26);
      // 
      // mnuGotoRef
      // 
      this.mnuGotoRef.Name = "mnuGotoRef";
      this.mnuGotoRef.Size = new System.Drawing.Size(192, 22);
      this.mnuGotoRef.Text = "&Go To Missing Reference";
      this.mnuGotoRef.Click += new System.EventHandler(this.mnuGotoRef_Click);
      // 
      // ipReferenceChild
      // 
      this.ipReferenceChild.AutoScrollMinSize = new System.Drawing.Size(353, 24);
      this.ipReferenceChild.BackColor = System.Drawing.Color.Transparent;
      this.ipReferenceChild.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ipReferenceChild.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icErrorReference});
      this.ipReferenceChild.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipReferenceChild.GetType();
      this.ipReferenceChild.Location = new System.Drawing.Point(0, 0);
      this.ipReferenceChild.Name = "ipReferenceChild";
      this.ipReferenceChild.Size = new System.Drawing.Size(385, 22);
      this.ipReferenceChild.TabIndex = 2;
      // 
      // icErrorReference
      // 
      // 
      // 
      // 
      this.icErrorReference.BackgroundStyle.MarginLeft = 10;
      this.icErrorReference.BackgroundStyle.MarginRight = 20;
      this.icErrorReference.MinimumSize = new System.Drawing.Size(0, 0);
      this.icErrorReference.Name = "icErrorReference";
      this.icErrorReference.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liReference});
      // 
      // liReference
      // 
      this.liReference.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liReference.ForeColor = System.Drawing.Color.Gray;
      this.liReference.Height = 22;
      this.liReference.Image = global::Prometheus.Properties.Resources.document_error16;
      this.liReference.Name = "liReference";
      this.liReference.PaddingBottom = 2;
      this.liReference.Text = "[Path w/ File Name]";
      this.liReference.Width = 355;
      // 
      // ReferenceChild
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.Controls.Add(this.ipReferenceChild);
      this.Name = "ReferenceChild";
      this.Size = new System.Drawing.Size(385, 22);
      this.cmsDirect.ResumeLayout(false);
      this.cmsRecursive.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip cmsDirect;
    private System.Windows.Forms.ContextMenuStrip cmsRecursive;
    private System.Windows.Forms.ToolStripMenuItem mnuNullRef;
    private System.Windows.Forms.ToolStripMenuItem mnuSelectLocation;
    private System.Windows.Forms.ToolStripMenuItem mnuGotoRef;
    private DevComponents.DotNetBar.ItemPanel ipReferenceChild;
    private DevComponents.DotNetBar.ItemContainer icErrorReference;
    private DevComponents.DotNetBar.LabelItem liReference;
  }
}
