namespace Games.Halo.Controls
{
  partial class RealRGBColor
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
      this.txtRed = new System.Windows.Forms.TextBox();
      this.txtGreen = new System.Windows.Forms.TextBox();
      this.txtBlue = new System.Windows.Forms.TextBox();
      this.labelRed = new System.Windows.Forms.Label();
      this.labelGreen = new System.Windows.Forms.Label();
      this.labelBlue = new System.Windows.Forms.Label();
      this.buttonColorPicker = new System.Windows.Forms.Button();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.buttonColorPicker);
      this.panelContainer.Controls.Add(this.labelBlue);
      this.panelContainer.Controls.Add(this.labelGreen);
      this.panelContainer.Controls.Add(this.labelRed);
      this.panelContainer.Controls.Add(this.txtBlue);
      this.panelContainer.Controls.Add(this.txtGreen);
      this.panelContainer.Controls.Add(this.txtRed);
      this.panelContainer.Size = new System.Drawing.Size(240, 26);
      // 
      // txtRed
      // 
      this.txtRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtRed.Location = new System.Drawing.Point(16, 4);
      this.txtRed.Name = "txtRed";
      this.txtRed.Size = new System.Drawing.Size(51, 18);
      this.txtRed.TabIndex = 0;
      // 
      // txtGreen
      // 
      this.txtGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtGreen.Location = new System.Drawing.Point(82, 4);
      this.txtGreen.Name = "txtGreen";
      this.txtGreen.Size = new System.Drawing.Size(50, 18);
      this.txtGreen.TabIndex = 1;
      // 
      // txtBlue
      // 
      this.txtBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtBlue.Location = new System.Drawing.Point(149, 4);
      this.txtBlue.Name = "txtBlue";
      this.txtBlue.Size = new System.Drawing.Size(50, 18);
      this.txtBlue.TabIndex = 2;
      // 
      // labelRed
      // 
      this.labelRed.AutoSize = true;
      this.labelRed.Location = new System.Drawing.Point(5, 6);
      this.labelRed.Name = "labelRed";
      this.labelRed.Size = new System.Drawing.Size(11, 13);
      this.labelRed.TabIndex = 3;
      this.labelRed.Text = "r";
      // 
      // labelGreen
      // 
      this.labelGreen.AutoSize = true;
      this.labelGreen.Location = new System.Drawing.Point(69, 6);
      this.labelGreen.Name = "labelGreen";
      this.labelGreen.Size = new System.Drawing.Size(14, 13);
      this.labelGreen.TabIndex = 4;
      this.labelGreen.Text = "g";
      // 
      // labelBlue
      // 
      this.labelBlue.AutoSize = true;
      this.labelBlue.Location = new System.Drawing.Point(135, 6);
      this.labelBlue.Name = "labelBlue";
      this.labelBlue.Size = new System.Drawing.Size(14, 13);
      this.labelBlue.TabIndex = 5;
      this.labelBlue.Text = "b";
      // 
      // buttonColorPicker
      // 
      this.buttonColorPicker.Location = new System.Drawing.Point(209, 3);
      this.buttonColorPicker.Name = "buttonColorPicker";
      this.buttonColorPicker.Size = new System.Drawing.Size(34, 21);
      this.buttonColorPicker.TabIndex = 6;
      this.buttonColorPicker.Text = "...";
      this.buttonColorPicker.UseVisualStyleBackColor = true;
      // 
      // RealRGBColor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealRGBColor";
      this.Size = new System.Drawing.Size(372, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtRed;
    private System.Windows.Forms.TextBox txtBlue;
    private System.Windows.Forms.TextBox txtGreen;
    private System.Windows.Forms.Button buttonColorPicker;
    private System.Windows.Forms.Label labelBlue;
    private System.Windows.Forms.Label labelGreen;
    private System.Windows.Forms.Label labelRed;
  }
}
