namespace Prometheus.Controls
{
  partial class ListEditor
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
      this.imgbUpdate = new Prometheus.Controls.ImageButton();
      this.imgbMoveDown = new Prometheus.Controls.ImageButton();
      this.imgbMoveUp = new Prometheus.Controls.ImageButton();
      this.imgbDelete = new Prometheus.Controls.ImageButton();
      this.imgbAdd = new Prometheus.Controls.ImageButton();
      this.txtbxDataEntry = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lbList = new System.Windows.Forms.ListBox();
      this.stListEditor = new DevComponents.DotNetBar.SuperTooltip();
      this.SuspendLayout();
      // 
      // imgbUpdate
      // 
      this.imgbUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbUpdate.Enabled = false;
      this.imgbUpdate.Image = global::Prometheus.Properties.Resources.refresh16;
      this.imgbUpdate.Location = new System.Drawing.Point(214, 0);
      this.imgbUpdate.Name = "imgbUpdate";
      this.imgbUpdate.ShrinkOnPush = true;
      this.imgbUpdate.Size = new System.Drawing.Size(20, 20);
      this.imgbUpdate.TabIndex = 2;
      this.imgbUpdate.Click += new System.EventHandler(this.imgbUpdate_Click);
      // 
      // imgbMoveDown
      // 
      this.imgbMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbMoveDown.Cursor = System.Windows.Forms.Cursors.PanSouth;
      this.imgbMoveDown.Image = global::Prometheus.Properties.Resources.nav_down_blue16;
      this.imgbMoveDown.Location = new System.Drawing.Point(237, 101);
      this.imgbMoveDown.Name = "imgbMoveDown";
      this.imgbMoveDown.ShrinkOnPush = true;
      this.imgbMoveDown.Size = new System.Drawing.Size(20, 20);
      this.imgbMoveDown.TabIndex = 6;
      this.imgbMoveDown.Click += new System.EventHandler(this.imgbMoveDown_Click);
      // 
      // imgbMoveUp
      // 
      this.imgbMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbMoveUp.Cursor = System.Windows.Forms.Cursors.PanNorth;
      this.imgbMoveUp.Image = global::Prometheus.Properties.Resources.nav_up_blue16;
      this.imgbMoveUp.Location = new System.Drawing.Point(237, 78);
      this.imgbMoveUp.Name = "imgbMoveUp";
      this.imgbMoveUp.ShrinkOnPush = true;
      this.imgbMoveUp.Size = new System.Drawing.Size(20, 20);
      this.imgbMoveUp.TabIndex = 5;
      this.imgbMoveUp.Click += new System.EventHandler(this.imgbMoveUp_Click);
      // 
      // imgbDelete
      // 
      this.imgbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbDelete.Image = global::Prometheus.Properties.Resources.delete216;
      this.imgbDelete.Location = new System.Drawing.Point(237, 49);
      this.imgbDelete.Name = "imgbDelete";
      this.imgbDelete.ShrinkOnPush = true;
      this.imgbDelete.Size = new System.Drawing.Size(20, 20);
      this.imgbDelete.TabIndex = 4;
      this.imgbDelete.Click += new System.EventHandler(this.imgbDelete_Click);
      // 
      // imgbAdd
      // 
      this.imgbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgbAdd.Image = global::Prometheus.Properties.Resources.add216;
      this.imgbAdd.Location = new System.Drawing.Point(237, 26);
      this.imgbAdd.Name = "imgbAdd";
      this.imgbAdd.ShrinkOnPush = true;
      this.imgbAdd.Size = new System.Drawing.Size(20, 20);
      this.imgbAdd.TabIndex = 3;
      this.imgbAdd.Click += new System.EventHandler(this.imgbAdd_Click);
      // 
      // txtbxDataEntry
      // 
      this.txtbxDataEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      // 
      // 
      // 
      this.txtbxDataEntry.Border.Class = "TextBoxBorder";
      this.txtbxDataEntry.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxDataEntry.FocusHighlightEnabled = true;
      this.txtbxDataEntry.Location = new System.Drawing.Point(0, 0);
      this.txtbxDataEntry.MaxLength = 32;
      this.txtbxDataEntry.Name = "txtbxDataEntry";
      this.txtbxDataEntry.Size = new System.Drawing.Size(212, 20);
      this.txtbxDataEntry.TabIndex = 1;
      this.txtbxDataEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxDataEntry_KeyPress);
      this.txtbxDataEntry.TextChanged += new System.EventHandler(this.txtbxDataEntry_TextChanged);
      // 
      // lbList
      // 
      this.lbList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lbList.FormattingEnabled = true;
      this.lbList.IntegralHeight = false;
      this.lbList.Location = new System.Drawing.Point(0, 26);
      this.lbList.Name = "lbList";
      this.lbList.ScrollAlwaysVisible = true;
      this.lbList.Size = new System.Drawing.Size(232, 95);
      this.lbList.TabIndex = 7;
      this.lbList.SelectedIndexChanged += new System.EventHandler(this.lbList_SelectedIndexChanged);
      // 
      // stListEditor
      // 
      this.stListEditor.GetType();
      this.stListEditor.MinimumTooltipSize = new System.Drawing.Size(50, 24);
      // 
      // ListEditor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Transparent;
      this.Controls.Add(this.imgbUpdate);
      this.Controls.Add(this.imgbMoveDown);
      this.Controls.Add(this.imgbMoveUp);
      this.Controls.Add(this.imgbDelete);
      this.Controls.Add(this.imgbAdd);
      this.Controls.Add(this.txtbxDataEntry);
      this.Controls.Add(this.lbList);
      this.MinimumSize = new System.Drawing.Size(70, 121);
      this.Name = "ListEditor";
      this.Size = new System.Drawing.Size(257, 121);
      this.ResumeLayout(false);

    }

    #endregion

    private ImageButton imgbUpdate;
    private ImageButton imgbMoveDown;
    private ImageButton imgbMoveUp;
    private ImageButton imgbDelete;
    private ImageButton imgbAdd;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxDataEntry;
    private System.Windows.Forms.ListBox lbList;
    private DevComponents.DotNetBar.SuperTooltip stListEditor;

  }
}
