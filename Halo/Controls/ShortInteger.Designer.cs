namespace Games.Halo.Controls
{
  partial class ShortInteger
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
      this.txtbxShortInt = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxShortInt);
      this.panelContainer.Size = new System.Drawing.Size(91, 26);
      // 
      // txtbxShortInt
      // 
      // 
      // 
      // 
      this.txtbxShortInt.Border.Class = "TextBoxBorder";
      this.txtbxShortInt.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxShortInt.FocusHighlightEnabled = true;
      this.txtbxShortInt.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxShortInt.Location = new System.Drawing.Point(0, 3);
      this.txtbxShortInt.MaxLength = 6;
      this.txtbxShortInt.Name = "txtbxShortInt";
      this.txtbxShortInt.Size = new System.Drawing.Size(42, 20);
      this.txtbxShortInt.TabIndex = 1;
      this.txtbxShortInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxShortInt_KeyPress);
      this.txtbxShortInt.TextChanged += new System.EventHandler(this.txtbxShortInt_TextChanged);
      this.txtbxShortInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxShortInt_KeyDown);
      // 
      // ShortInteger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "ShortInteger";
      this.Size = new System.Drawing.Size(223, 26);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtbxShortInt;

  }
}
