namespace Games.Halo.Controls
{
  partial class LongInteger
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
      this.txtbxLongInt = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxLongInt);
      this.panelContainer.Size = new System.Drawing.Size(99, 26);
      // 
      // txtbxLongInt
      // 
      // 
      // 
      // 
      this.txtbxLongInt.Border.Class = "TextBoxBorder";
      this.txtbxLongInt.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxLongInt.FocusHighlightEnabled = true;
      this.txtbxLongInt.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxLongInt.Location = new System.Drawing.Point(0, 3);
      this.txtbxLongInt.MaxLength = 11;
      this.txtbxLongInt.Name = "txtbxLongInt";
      this.txtbxLongInt.Size = new System.Drawing.Size(85, 20);
      this.txtbxLongInt.TabIndex = 1;
      this.txtbxLongInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxLongInt_KeyPress);
      this.txtbxLongInt.TextChanged += new System.EventHandler(this.txtbxLongInt_TextChanged);
      this.txtbxLongInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxLongInt_KeyDown);
      // 
      // LongInteger
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "LongInteger";
      this.Size = new System.Drawing.Size(231, 26);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtbxLongInt;

  }
}
