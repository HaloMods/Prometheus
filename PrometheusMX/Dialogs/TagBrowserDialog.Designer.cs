namespace Prometheus.Dialogs
{
  partial class TagBrowserDialog
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagBrowserDialog));
        this.listView1 = new System.Windows.Forms.ListView();
        this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
        this.panel1 = new System.Windows.Forms.Panel();
        this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
        this.treeView = new Prometheus.Controls.MultiSourceTreeView();
        this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
        this.panel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.treeView)).BeginInit();
        this.SuspendLayout();
        // 
        // listView1
        // 
        this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.listView1.Location = new System.Drawing.Point(0, 0);
        this.listView1.Name = "listView1";
        this.listView1.Size = new System.Drawing.Size(440, 340);
        this.listView1.TabIndex = 1;
        this.listView1.UseCompatibleStateImageBehavior = false;
        // 
        // buttonX1
        // 
        this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.buttonX1.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.buttonX1.Location = new System.Drawing.Point(377, 358);
        this.buttonX1.Name = "buttonX1";
        this.buttonX1.Size = new System.Drawing.Size(75, 23);
        this.buttonX1.TabIndex = 1;
        this.buttonX1.Text = "Select";
        // 
        // panel1
        // 
        this.panel1.Controls.Add(this.expandableSplitter1);
        this.panel1.Controls.Add(this.treeView);
        this.panel1.Controls.Add(this.listView1);
        this.panel1.Location = new System.Drawing.Point(12, 12);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(440, 340);
        this.panel1.TabIndex = 3;
        // 
        // expandableSplitter1
        // 
        this.expandableSplitter1.BackColor2 = System.Drawing.SystemColors.ControlDarkDark;
        this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
        this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
        this.expandableSplitter1.ExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
        this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
        this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
        this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
        this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
        this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
        this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
        this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
        this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
        this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
        this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
        this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
        this.expandableSplitter1.HotExpandFillColor = System.Drawing.SystemColors.ControlDarkDark;
        this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
        this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
        this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
        this.expandableSplitter1.HotGripDarkColor = System.Drawing.SystemColors.ControlDarkDark;
        this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
        this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
        this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
        this.expandableSplitter1.Location = new System.Drawing.Point(149, 0);
        this.expandableSplitter1.Name = "expandableSplitter1";
        this.expandableSplitter1.Size = new System.Drawing.Size(10, 340);
        this.expandableSplitter1.TabIndex = 2;
        this.expandableSplitter1.TabStop = false;
        // 
        // treeView
        // 
        this.treeView.AllowDrop = true;
        this.treeView.CheckBoxes = true;
        this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
        this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
        this.treeView.FadeOnMouseOut = true;
        this.treeView.Location = new System.Drawing.Point(0, 0);
        this.treeView.MoveNodesOnDragDrop = false;
        this.treeView.Name = "treeView";
        this.treeView.Size = new System.Drawing.Size(149, 340);
        this.treeView.SortMode = Prometheus.Controls.SortMode.NodeSource;
        this.treeView.TabIndex = 0;
        this.treeView.TreeEmptyAlpha = 255;
        this.treeView.TreeEmptyIcon = ((System.Drawing.Bitmap)(resources.GetObject("treeView.TreeEmptyIcon")));
        this.treeView.TreeEmptyText = null;
        this.treeView.TreeEmptyTextColor = System.Drawing.Color.Gray;
        this.treeView.TreeEmptyTextFont = new System.Drawing.Font("Arial", 8.5F);
        // 
        // buttonX2
        // 
        this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.buttonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonX2.Location = new System.Drawing.Point(296, 358);
        this.buttonX2.Name = "buttonX2";
        this.buttonX2.Size = new System.Drawing.Size(75, 23);
        this.buttonX2.TabIndex = 4;
        this.buttonX2.Text = "Cancel";
        // 
        // TagBrowserDialog
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(464, 393);
        this.Controls.Add(this.buttonX2);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.buttonX1);
        this.Name = "TagBrowserDialog";
        this.Text = "TagBrowserDialog";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagBrowserDialog_FormClosing);
        this.panel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.treeView)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private Prometheus.Controls.MultiSourceTreeView treeView;
    private System.Windows.Forms.ListView listView1;
    private DevComponents.DotNetBar.ButtonX buttonX1;
    private System.Windows.Forms.Panel panel1;
    private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
    private DevComponents.DotNetBar.ButtonX buttonX2;
  }
}