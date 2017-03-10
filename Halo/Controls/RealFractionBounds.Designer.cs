namespace Games.Halo.Controls
{
  partial class RealFractionBounds
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
      this.txtLower = new System.Windows.Forms.TextBox();
      this.txtUpper = new System.Windows.Forms.TextBox();
      this.labelTo = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.labelTo);
      this.panelContainer.Controls.Add(this.txtUpper);
      this.panelContainer.Controls.Add(this.txtLower);
      this.panelContainer.Size = new System.Drawing.Size(222, 26);
      // 
      // txtLower
      // 
      this.txtLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtLower.Location = new System.Drawing.Point(5, 4);
      this.txtLower.Name = "txtLower";
      this.txtLower.Size = new System.Drawing.Size(50, 18);
      this.txtLower.TabIndex = 0;
      // 
      // txtUpper
      // 
      this.txtUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtUpper.Location = new System.Drawing.Point(87, 4);
      this.txtUpper.Name = "txtUpper";
      this.txtUpper.Size = new System.Drawing.Size(50, 18);
      this.txtUpper.TabIndex = 1;
      // 
      // labelTo
      // 
      this.labelTo.AutoSize = true;
      this.labelTo.Location = new System.Drawing.Point(65, 6);
      this.labelTo.Name = "labelTo";
      this.labelTo.Size = new System.Drawing.Size(18, 13);
      this.labelTo.TabIndex = 7;
      this.labelTo.Text = "to";
      // 
      // RealFractionBounds
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealFractionBounds";
      this.Size = new System.Drawing.Size(354, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtLower;
    private System.Windows.Forms.TextBox txtUpper;
    private System.Windows.Forms.Label labelTo;
  }
}
