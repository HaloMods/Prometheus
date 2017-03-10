namespace Games.Halo.Controls
{
  partial class ShortBounds
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
      this.labelTo = new System.Windows.Forms.Label();
      this.txtbxShortIntLower = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxShortIntUpper = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxShortIntUpper);
      this.panelContainer.Controls.Add(this.txtbxShortIntLower);
      this.panelContainer.Controls.Add(this.labelTo);
      this.panelContainer.Size = new System.Drawing.Size(153, 26);
      // 
      // labelTo
      // 
      this.labelTo.AutoSize = true;
      this.labelTo.Location = new System.Drawing.Point(51, 7);
      this.labelTo.Name = "labelTo";
      this.labelTo.Size = new System.Drawing.Size(18, 13);
      this.labelTo.TabIndex = 7;
      this.labelTo.Text = "to";
      // 
      // txtbxShortIntLower
      // 
      // 
      // 
      // 
      this.txtbxShortIntLower.Border.Class = "TextBoxBorder";
      this.txtbxShortIntLower.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxShortIntLower.FocusHighlightEnabled = true;
      this.txtbxShortIntLower.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxShortIntLower.Location = new System.Drawing.Point(0, 3);
      this.txtbxShortIntLower.MaxLength = 6;
      this.txtbxShortIntLower.Name = "txtbxShortIntLower";
      this.txtbxShortIntLower.Size = new System.Drawing.Size(45, 20);
      this.txtbxShortIntLower.TabIndex = 8;
      this.txtbxShortIntLower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxShortIntBounds_KeyPress);
      this.txtbxShortIntLower.TextChanged += new System.EventHandler(this.txtbxShortIntBounds_TextChanged);
      this.txtbxShortIntLower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxShortIntBounds_KeyDown);
      // 
      // txtbxShortIntUpper
      // 
      // 
      // 
      // 
      this.txtbxShortIntUpper.Border.Class = "TextBoxBorder";
      this.txtbxShortIntUpper.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxShortIntUpper.FocusHighlightEnabled = true;
      this.txtbxShortIntUpper.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxShortIntUpper.Location = new System.Drawing.Point(73, 3);
      this.txtbxShortIntUpper.MaxLength = 6;
      this.txtbxShortIntUpper.Name = "txtbxShortIntUpper";
      this.txtbxShortIntUpper.Size = new System.Drawing.Size(45, 20);
      this.txtbxShortIntUpper.TabIndex = 9;
      this.txtbxShortIntUpper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxShortIntBounds_KeyPress);
      this.txtbxShortIntUpper.TextChanged += new System.EventHandler(this.txtbxShortIntBounds_TextChanged);
      this.txtbxShortIntUpper.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxShortIntBounds_KeyDown);
      // 
      // ShortBounds
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "ShortBounds";
      this.Size = new System.Drawing.Size(285, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelTo;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxShortIntUpper;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxShortIntLower;
  }
}
