namespace Games.Halo.Controls
{
  partial class RealARGBColor
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RealARGBColor));
      this.cpbColor = new DevComponents.DotNetBar.ColorPickerButton();
      this.txtbxB = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lblB = new System.Windows.Forms.Label();
      this.txtbxG = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxR = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxA = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lblG = new System.Windows.Forms.Label();
      this.lblR = new System.Windows.Forms.Label();
      this.lblA = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.cpbColor);
      this.panelContainer.Controls.Add(this.txtbxB);
      this.panelContainer.Controls.Add(this.lblB);
      this.panelContainer.Controls.Add(this.txtbxG);
      this.panelContainer.Controls.Add(this.txtbxR);
      this.panelContainer.Controls.Add(this.txtbxA);
      this.panelContainer.Controls.Add(this.lblG);
      this.panelContainer.Controls.Add(this.lblR);
      this.panelContainer.Controls.Add(this.lblA);
      this.panelContainer.Size = new System.Drawing.Size(261, 26);
      // 
      // cpbColor
      // 
      this.cpbColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.cpbColor.AutoExpandOnClick = true;
      this.cpbColor.Image = ((System.Drawing.Image)(resources.GetObject("cpbColor.Image")));
      this.cpbColor.Location = new System.Drawing.Point(181, 3);
      this.cpbColor.Name = "cpbColor";
      this.cpbColor.SelectedColorImageRectangle = new System.Drawing.Rectangle(2, 2, 12, 12);
      this.cpbColor.Size = new System.Drawing.Size(37, 20);
      this.cpbColor.TabIndex = 21;
      this.cpbColor.SelectedColorChanged += new System.EventHandler(this.cpbColor_SelectedColorChanged);
      // 
      // txtbxB
      // 
      // 
      // 
      // 
      this.txtbxB.Border.Class = "TextBoxBorder";
      this.txtbxB.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxB.FocusHighlightEnabled = true;
      this.txtbxB.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxB.Location = new System.Drawing.Point(151, 3);
      this.txtbxB.MaxLength = 3;
      this.txtbxB.Name = "txtbxB";
      this.txtbxB.Size = new System.Drawing.Size(24, 20);
      this.txtbxB.TabIndex = 20;
      this.txtbxB.Tag = "";
      this.txtbxB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtbxB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
      this.txtbxB.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
      this.txtbxB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyDown);
      // 
      // lblB
      // 
      this.lblB.AutoSize = true;
      this.lblB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblB.Location = new System.Drawing.Point(132, 7);
      this.lblB.Name = "lblB";
      this.lblB.Size = new System.Drawing.Size(19, 13);
      this.lblB.TabIndex = 19;
      this.lblB.Text = "B:";
      // 
      // txtbxG
      // 
      // 
      // 
      // 
      this.txtbxG.Border.Class = "TextBoxBorder";
      this.txtbxG.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxG.FocusHighlightEnabled = true;
      this.txtbxG.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxG.Location = new System.Drawing.Point(106, 3);
      this.txtbxG.MaxLength = 3;
      this.txtbxG.Name = "txtbxG";
      this.txtbxG.Size = new System.Drawing.Size(24, 20);
      this.txtbxG.TabIndex = 18;
      this.txtbxG.Tag = "";
      this.txtbxG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtbxG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
      this.txtbxG.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
      this.txtbxG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyDown);
      // 
      // txtbxR
      // 
      // 
      // 
      // 
      this.txtbxR.Border.Class = "TextBoxBorder";
      this.txtbxR.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxR.FocusHighlightEnabled = true;
      this.txtbxR.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxR.Location = new System.Drawing.Point(61, 3);
      this.txtbxR.MaxLength = 3;
      this.txtbxR.Name = "txtbxR";
      this.txtbxR.Size = new System.Drawing.Size(24, 20);
      this.txtbxR.TabIndex = 17;
      this.txtbxR.Tag = "";
      this.txtbxR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtbxR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
      this.txtbxR.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
      this.txtbxR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyDown);
      // 
      // txtbxA
      // 
      // 
      // 
      // 
      this.txtbxA.Border.Class = "TextBoxBorder";
      this.txtbxA.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxA.FocusHighlightEnabled = true;
      this.txtbxA.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxA.Location = new System.Drawing.Point(16, 3);
      this.txtbxA.MaxLength = 3;
      this.txtbxA.Name = "txtbxA";
      this.txtbxA.Size = new System.Drawing.Size(24, 20);
      this.txtbxA.TabIndex = 16;
      this.txtbxA.Tag = "";
      this.txtbxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtbxA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbx_KeyPress);
      this.txtbxA.TextChanged += new System.EventHandler(this.txtbx_TextChanged);
      this.txtbxA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_KeyDown);
      // 
      // lblG
      // 
      this.lblG.AutoSize = true;
      this.lblG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblG.Location = new System.Drawing.Point(87, 7);
      this.lblG.Name = "lblG";
      this.lblG.Size = new System.Drawing.Size(20, 13);
      this.lblG.TabIndex = 13;
      this.lblG.Text = "G:";
      // 
      // lblR
      // 
      this.lblR.AutoSize = true;
      this.lblR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblR.Location = new System.Drawing.Point(42, 7);
      this.lblR.Name = "lblR";
      this.lblR.Size = new System.Drawing.Size(20, 13);
      this.lblR.TabIndex = 14;
      this.lblR.Text = "R:";
      // 
      // lblA
      // 
      this.lblA.AutoSize = true;
      this.lblA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblA.Location = new System.Drawing.Point(-3, 7);
      this.lblA.Name = "lblA";
      this.lblA.Size = new System.Drawing.Size(19, 13);
      this.lblA.TabIndex = 15;
      this.lblA.Text = "A:";
      // 
      // RealARGBColor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealARGBColor";
      this.Size = new System.Drawing.Size(393, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ColorPickerButton cpbColor;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxB;
    private System.Windows.Forms.Label lblB;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxG;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxR;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxA;
    private System.Windows.Forms.Label lblG;
    private System.Windows.Forms.Label lblR;
    private System.Windows.Forms.Label lblA;

  }
}
