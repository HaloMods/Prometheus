namespace Games.Halo.Controls
{
  partial class Real
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
      this.txtbReal = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbReal);
      this.panelContainer.Size = new System.Drawing.Size(99, 26);
      // 
      // txtbReal
      // 
      // 
      // 
      // 
      this.txtbReal.Border.Class = "TextBoxBorder";
      this.txtbReal.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbReal.FocusHighlightEnabled = true;
      this.txtbReal.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbReal.Location = new System.Drawing.Point(0, 3);
      this.txtbReal.MaxLength = 10;
      this.txtbReal.Name = "txtbReal";
      this.txtbReal.Size = new System.Drawing.Size(60, 20);
      this.txtbReal.TabIndex = 1;
      this.txtbReal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbReal_KeyPress);
      this.txtbReal.TextChanged += new System.EventHandler(this.txtbReal_TextChanged);
      this.txtbReal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbReal_KeyDown);
      // 
      // Real
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Real";
      this.Size = new System.Drawing.Size(231, 26);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtbReal;

  }
}
