namespace Games.Halo.Controls
{
  partial class ShortBlockIndex
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
      this.txtValue = new System.Windows.Forms.TextBox();
      this.cboValue = new DevComponents.DotNetBar.Controls.ComboBoxEx();
      this.lblWarning = new DevComponents.DotNetBar.LabelX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.lblWarning);
      this.panelContainer.Controls.Add(this.cboValue);
      this.panelContainer.Controls.Add(this.txtValue);
      this.panelContainer.Size = new System.Drawing.Size(217, 26);
      // 
      // txtValue
      // 
      this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtValue.Location = new System.Drawing.Point(4, 4);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new System.Drawing.Size(90, 18);
      this.txtValue.TabIndex = 0;
      // 
      // cboValue
      // 
      this.cboValue.DisplayMember = "Text";
      this.cboValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboValue.FormattingEnabled = true;
      this.cboValue.ItemHeight = 11;
      this.cboValue.Location = new System.Drawing.Point(5, 4);
      this.cboValue.Name = "cboValue";
      this.cboValue.Size = new System.Drawing.Size(104, 17);
      this.cboValue.TabIndex = 1;
      // 
      // lblWarning
      // 
      this.lblWarning.Image = global::Games.Halo.Properties.Resources.warning16;
      this.lblWarning.Location = new System.Drawing.Point(117, 5);
      this.lblWarning.Name = "lblWarning";
      this.lblWarning.Size = new System.Drawing.Size(21, 19);
      this.lblWarning.TabIndex = 3;
      // 
      // ShortBlockIndex
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "ShortBlockIndex";
      this.Size = new System.Drawing.Size(349, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtValue;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cboValue;
    private DevComponents.DotNetBar.LabelX lblWarning;
  }
}
