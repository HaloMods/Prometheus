namespace Games.Halo.Controls
{
  partial class CharInteger
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
      this.txtbxCharInt = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxCharInt);
      this.panelContainer.Size = new System.Drawing.Size(75, 26);
      // 
      // txtbxCharInt
      // 
      // 
      // 
      // 
      this.txtbxCharInt.Border.Class = "TextBoxBorder";
      this.txtbxCharInt.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxCharInt.FocusHighlightEnabled = true;
      this.txtbxCharInt.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxCharInt.Location = new System.Drawing.Point(0, 3);
      this.txtbxCharInt.MaxLength = 4;
      this.txtbxCharInt.Name = "txtbxCharInt";
      this.txtbxCharInt.Size = new System.Drawing.Size(30, 20);
      this.txtbxCharInt.TabIndex = 1;
      this.txtbxCharInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxCharInt_KeyPress);
      this.txtbxCharInt.TextChanged += new System.EventHandler(this.txtbxCharInt_TextChanged);
      this.txtbxCharInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxCharInt_KeyDown);
      // 
      // CharInteger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "CharInteger";
      this.Size = new System.Drawing.Size(207, 26);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtbxCharInt;

  }
}
