namespace Prometheus.Dialogs
{
  partial class OpenProjectDialog
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
      this.listProject = new DevComponents.DotNetBar.Controls.ListViewEx();
      this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
      this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
      this.labelX1 = new DevComponents.DotNetBar.LabelX();
      this.btnCancel = new DevComponents.DotNetBar.ButtonX();
      this.btnOpen = new DevComponents.DotNetBar.ButtonX();
      this.SuspendLayout();
      // 
      // listProject
      // 
      this.listProject.AllowColumnReorder = true;
      this.listProject.AutoArrange = false;
      // 
      // 
      // 
      this.listProject.Border.Class = "ListViewBorder";
      this.listProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
      this.listProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listProject.FullRowSelect = true;
      this.listProject.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listProject.Location = new System.Drawing.Point(12, 36);
      this.listProject.Name = "listProject";
      this.listProject.Size = new System.Drawing.Size(508, 174);
      this.listProject.TabIndex = 0;
      this.listProject.UseCompatibleStateImageBehavior = false;
      this.listProject.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Name";
      this.columnHeader1.Width = 130;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "Author";
      this.columnHeader5.Width = 94;
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "Last Modified";
      this.columnHeader6.Width = 109;
      // 
      // columnHeader7
      // 
      this.columnHeader7.Text = "Platform";
      this.columnHeader7.Width = 170;
      // 
      // labelX1
      // 
      this.labelX1.Location = new System.Drawing.Point(12, 5);
      this.labelX1.Name = "labelX1";
      this.labelX1.Size = new System.Drawing.Size(412, 25);
      this.labelX1.TabIndex = 1;
      this.labelX1.Text = "Choose a project from the list below, and click the <b>Open</b> button to load th" +
          "e file.";
      // 
      // btnCancel
      // 
      this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(445, 214);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 2;
      this.btnCancel.Text = "Cancel";
      // 
      // btnOpen
      // 
      this.btnOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnOpen.Location = new System.Drawing.Point(364, 214);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 3;
      this.btnOpen.Text = "&Open";
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // OpenProjectDialog
      // 
      this.AcceptButton = this.btnOpen;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(532, 244);
      this.Controls.Add(this.btnOpen);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.labelX1);
      this.Controls.Add(this.listProject);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "OpenProjectDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Open Project";
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.ListViewEx listProject;
    private DevComponents.DotNetBar.LabelX labelX1;
    private DevComponents.DotNetBar.ButtonX btnCancel;
    private DevComponents.DotNetBar.ButtonX btnOpen;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.ColumnHeader columnHeader7;
  }
}