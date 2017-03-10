namespace Games.Halo.Controls
{
  partial class Enum
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
      this.cboxxEnumList = new DevComponents.DotNetBar.Controls.ComboBoxEx();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.cboxxEnumList);
      this.panelContainer.Size = new System.Drawing.Size(206, 28);
      // 
      // cboxxEnumList
      // 
      this.cboxxEnumList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cboxxEnumList.DisplayMember = "Text";
      this.cboxxEnumList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cboxxEnumList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboxxEnumList.ForeColor = System.Drawing.Color.DarkBlue;
      this.cboxxEnumList.FormattingEnabled = true;
      this.cboxxEnumList.ItemHeight = 16;
      this.cboxxEnumList.Location = new System.Drawing.Point(0, 3);
      this.cboxxEnumList.Name = "cboxxEnumList";
      this.cboxxEnumList.Size = new System.Drawing.Size(203, 22);
      this.cboxxEnumList.TabIndex = 1;
      // 
      // Enum
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Enum";
      this.Size = new System.Drawing.Size(338, 28);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.ComboBoxEx cboxxEnumList;

  }
}
