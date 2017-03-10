namespace Games.Halo.Controls
{
  partial class RealVector2D
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
      this.txtIValue = new System.Windows.Forms.TextBox();
      this.txtJValue = new System.Windows.Forms.TextBox();
      this.labelJ = new System.Windows.Forms.Label();
      this.labelI = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.labelJ);
      this.panelContainer.Controls.Add(this.labelI);
      this.panelContainer.Controls.Add(this.txtJValue);
      this.panelContainer.Controls.Add(this.txtIValue);
      this.panelContainer.Size = new System.Drawing.Size(223, 26);
      // 
      // txtIValue
      // 
      this.txtIValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtIValue.Location = new System.Drawing.Point(19, 4);
      this.txtIValue.Name = "txtIValue";
      this.txtIValue.Size = new System.Drawing.Size(50, 18);
      this.txtIValue.TabIndex = 0;
      // 
      // txtJValue
      // 
      this.txtJValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtJValue.Location = new System.Drawing.Point(88, 4);
      this.txtJValue.Name = "txtJValue";
      this.txtJValue.Size = new System.Drawing.Size(50, 18);
      this.txtJValue.TabIndex = 1;
      // 
      // labelJ
      // 
      this.labelJ.AutoSize = true;
      this.labelJ.Location = new System.Drawing.Point(74, 6);
      this.labelJ.Name = "labelJ";
      this.labelJ.Size = new System.Drawing.Size(10, 13);
      this.labelJ.TabIndex = 7;
      this.labelJ.Text = "j";
      // 
      // labelI
      // 
      this.labelI.AutoSize = true;
      this.labelI.Location = new System.Drawing.Point(5, 6);
      this.labelI.Name = "labelI";
      this.labelI.Size = new System.Drawing.Size(10, 13);
      this.labelI.TabIndex = 6;
      this.labelI.Text = "i";
      // 
      // RealVector2D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealVector2D";
      this.Size = new System.Drawing.Size(355, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtIValue;
    private System.Windows.Forms.TextBox txtJValue;
    private System.Windows.Forms.Label labelJ;
    private System.Windows.Forms.Label labelI;
  }
}
