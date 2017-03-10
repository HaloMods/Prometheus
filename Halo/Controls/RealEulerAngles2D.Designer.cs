namespace Games.Halo.Controls
{
  partial class RealEulerAngles2D
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
      this.txtYaw = new System.Windows.Forms.TextBox();
      this.txtPitch = new System.Windows.Forms.TextBox();
      this.labelYaw = new System.Windows.Forms.Label();
      this.labelPitch = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.labelPitch);
      this.panelContainer.Controls.Add(this.labelYaw);
      this.panelContainer.Controls.Add(this.txtPitch);
      this.panelContainer.Controls.Add(this.txtYaw);
      this.panelContainer.Size = new System.Drawing.Size(197, 26);
      // 
      // txtYaw
      // 
      this.txtYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtYaw.Location = new System.Drawing.Point(19, 4);
      this.txtYaw.Name = "txtYaw";
      this.txtYaw.Size = new System.Drawing.Size(50, 18);
      this.txtYaw.TabIndex = 0;
      // 
      // txtPitch
      // 
      this.txtPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPitch.Location = new System.Drawing.Point(85, 4);
      this.txtPitch.Name = "txtPitch";
      this.txtPitch.Size = new System.Drawing.Size(50, 18);
      this.txtPitch.TabIndex = 1;
      // 
      // labelYaw
      // 
      this.labelYaw.AutoSize = true;
      this.labelYaw.Location = new System.Drawing.Point(5, 6);
      this.labelYaw.Name = "labelYaw";
      this.labelYaw.Size = new System.Drawing.Size(12, 13);
      this.labelYaw.TabIndex = 3;
      this.labelYaw.Text = "y";
      // 
      // labelPitch
      // 
      this.labelPitch.AutoSize = true;
      this.labelPitch.Location = new System.Drawing.Point(72, 6);
      this.labelPitch.Name = "labelPitch";
      this.labelPitch.Size = new System.Drawing.Size(14, 13);
      this.labelPitch.TabIndex = 4;
      this.labelPitch.Text = "p";
      // 
      // RealEulerAngles2D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealEulerAngles2D";
      this.Size = new System.Drawing.Size(329, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtYaw;
    private System.Windows.Forms.TextBox txtPitch;
    private System.Windows.Forms.Label labelPitch;
    private System.Windows.Forms.Label labelYaw;
  }
}
