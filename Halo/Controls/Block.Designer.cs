namespace Games.Halo.Controls
{
  partial class Block
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
      this.btnDeleteAll = new Prometheus.Controls.ImageButton();
      this.btnAdd = new Prometheus.Controls.ImageButton();
      this.btnDelete = new Prometheus.Controls.ImageButton();
      this.btnInsert = new Prometheus.Controls.ImageButton();
      this.btnDuplicate = new Prometheus.Controls.ImageButton();
      this.cboBlockList = new DevComponents.DotNetBar.Controls.ComboBoxEx();
      this.stBlock = new DevComponents.DotNetBar.SuperTooltip();
      this.SuspendLayout();
      // 
      // btnDeleteAll
      // 
      this.btnDeleteAll.Image = global::Games.Halo.Properties.Resources.data_deleteall16;
      this.btnDeleteAll.Location = new System.Drawing.Point(267, 3);
      this.btnDeleteAll.Name = "btnDeleteAll";
      this.btnDeleteAll.Size = new System.Drawing.Size(20, 23);
      this.stBlock.SetSuperTooltip(this.btnDeleteAll, new DevComponents.DotNetBar.SuperTooltipInfo("Delete All Blocks", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnDeleteAll.TabIndex = 5;
      // 
      // btnAdd
      // 
      this.btnAdd.Image = global::Games.Halo.Properties.Resources.data_new16;
      this.btnAdd.Location = new System.Drawing.Point(163, 3);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(20, 23);
      this.stBlock.SetSuperTooltip(this.btnAdd, new DevComponents.DotNetBar.SuperTooltipInfo("Add Block", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnAdd.TabIndex = 4;
      // 
      // btnDelete
      // 
      this.btnDelete.Image = global::Games.Halo.Properties.Resources.data_delete16;
      this.btnDelete.Location = new System.Drawing.Point(241, 3);
      this.btnDelete.Name = "btnDelete";
      this.btnDelete.Size = new System.Drawing.Size(20, 23);
      this.stBlock.SetSuperTooltip(this.btnDelete, new DevComponents.DotNetBar.SuperTooltipInfo("Delete Block", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnDelete.TabIndex = 3;
      // 
      // btnInsert
      // 
      this.btnInsert.Image = global::Games.Halo.Properties.Resources.data_add16;
      this.btnInsert.Location = new System.Drawing.Point(189, 3);
      this.btnInsert.Name = "btnInsert";
      this.btnInsert.Size = new System.Drawing.Size(20, 23);
      this.stBlock.SetSuperTooltip(this.btnInsert, new DevComponents.DotNetBar.SuperTooltipInfo("Insert Block", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnInsert.TabIndex = 2;
      // 
      // btnDuplicate
      // 
      this.btnDuplicate.Image = global::Games.Halo.Properties.Resources.data_copy16;
      this.btnDuplicate.Location = new System.Drawing.Point(215, 3);
      this.btnDuplicate.Name = "btnDuplicate";
      this.btnDuplicate.Size = new System.Drawing.Size(20, 23);
      this.stBlock.SetSuperTooltip(this.btnDuplicate, new DevComponents.DotNetBar.SuperTooltipInfo("Duplicate Block", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.btnDuplicate.TabIndex = 1;
      // 
      // cboBlockList
      // 
      this.cboBlockList.DisplayMember = "Text";
      this.cboBlockList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cboBlockList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboBlockList.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboBlockList.ForeColor = System.Drawing.Color.DarkBlue;
      this.cboBlockList.FormattingEnabled = true;
      this.cboBlockList.ItemHeight = 13;
      this.cboBlockList.Location = new System.Drawing.Point(7, 5);
      this.cboBlockList.Name = "cboBlockList";
      this.cboBlockList.Size = new System.Drawing.Size(143, 19);
      this.cboBlockList.TabIndex = 7;
      // 
      // stBlock
      // 
      this.stBlock.GetType();
      this.stBlock.MinimumTooltipSize = new System.Drawing.Size(10, 16);
      this.stBlock.TooltipDuration = 0;
      // 
      // Block
      // 
      this.Controls.Add(this.cboBlockList);
      this.Controls.Add(this.btnDeleteAll);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnDelete);
      this.Controls.Add(this.btnInsert);
      this.Controls.Add(this.btnDuplicate);
      this.Name = "Block";
      this.Size = new System.Drawing.Size(317, 29);
      this.ResumeLayout(false);

    }

    #endregion

    private Prometheus.Controls.ImageButton btnDuplicate;
    private Prometheus.Controls.ImageButton btnInsert;
    private Prometheus.Controls.ImageButton btnDelete;
    private Prometheus.Controls.ImageButton btnAdd;
    private Prometheus.Controls.ImageButton btnDeleteAll;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cboBlockList;
    private DevComponents.DotNetBar.SuperTooltip stBlock;
  }
}
