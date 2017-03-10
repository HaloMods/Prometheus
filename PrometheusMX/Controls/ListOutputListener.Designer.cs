namespace Prometheus.Controls
{
  partial class ListOutputListener
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOutputListener));
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.textColumn2 = new XPTable.Models.TextColumn();
      this.infoColumn = new XPTable.Models.TextColumn();
      this.table = new XPTable.Models.Table();
      ((System.ComponentModel.ISupportInitialize)(this.table)).BeginInit();
      this.SuspendLayout();
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "error.png");
      // 
      // textColumn2
      // 
      this.textColumn2.Text = "Description";
      // 
      // infoColumn
      // 
      this.infoColumn.Editable = false;
      // 
      // table
      // 
      this.table.AlternatingRowColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
      this.table.Dock = System.Windows.Forms.DockStyle.Fill;
      this.table.FullRowSelect = true;
      this.table.GridColor = System.Drawing.SystemColors.ControlLight;
      this.table.GridLines = XPTable.Models.GridLines.Rows;
      this.table.GridLineStyle = XPTable.Models.GridLineStyle.Dot;
      this.table.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
      this.table.Location = new System.Drawing.Point(0, 0);
      this.table.Name = "table";
      this.table.NoItemsText = "(There is currently no output)";
      this.table.Size = new System.Drawing.Size(531, 275);
      this.table.TabIndex = 0;
      // 
      // ListOutputListener
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.table);
      this.Name = "ListOutputListener";
      this.Size = new System.Drawing.Size(531, 275);
      ((System.ComponentModel.ISupportInitialize)(this.table)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ImageList imageList1;
    private XPTable.Models.TextColumn textColumn2;
    private XPTable.Models.TextColumn infoColumn;
    private XPTable.Models.Table table;
  }
}
