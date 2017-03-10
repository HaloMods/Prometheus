namespace Games.Halo.Controls
{
  partial class RealPlane2D
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
      this.txtI = new System.Windows.Forms.TextBox();
      this.txtJ = new System.Windows.Forms.TextBox();
      this.txtD = new System.Windows.Forms.TextBox();
      this.labelI = new System.Windows.Forms.Label();
      this.labelJ = new System.Windows.Forms.Label();
      this.labelD = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.labelD);
      this.panelContainer.Controls.Add(this.labelJ);
      this.panelContainer.Controls.Add(this.labelI);
      this.panelContainer.Controls.Add(this.txtD);
      this.panelContainer.Controls.Add(this.txtJ);
      this.panelContainer.Controls.Add(this.txtI);
      this.panelContainer.Size = new System.Drawing.Size(197, 26);
      // 
      // txtI
      // 
      this.txtI.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtI.Location = new System.Drawing.Point(19, 4);
      this.txtI.Name = "txtI";
      this.txtI.Size = new System.Drawing.Size(50, 18);
      this.txtI.TabIndex = 0;
      // 
      // txtJ
      // 
      this.txtJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtJ.Location = new System.Drawing.Point(85, 4);
      this.txtJ.Name = "txtJ";
      this.txtJ.Size = new System.Drawing.Size(50, 18);
      this.txtJ.TabIndex = 1;
      // 
      // txtD
      // 
      this.txtD.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtD.Location = new System.Drawing.Point(152, 4);
      this.txtD.Name = "txtD";
      this.txtD.Size = new System.Drawing.Size(50, 18);
      this.txtD.TabIndex = 2;
      // 
      // labelI
      // 
      this.labelI.AutoSize = true;
      this.labelI.Location = new System.Drawing.Point(5, 6);
      this.labelI.Name = "labelI";
      this.labelI.Size = new System.Drawing.Size(10, 13);
      this.labelI.TabIndex = 3;
      this.labelI.Text = "i";
      // 
      // labelJ
      // 
      this.labelJ.AutoSize = true;
      this.labelJ.Location = new System.Drawing.Point(72, 6);
      this.labelJ.Name = "labelJ";
      this.labelJ.Size = new System.Drawing.Size(10, 13);
      this.labelJ.TabIndex = 4;
      this.labelJ.Text = "j";
      // 
      // labelD
      // 
      this.labelD.AutoSize = true;
      this.labelD.Location = new System.Drawing.Point(138, 6);
      this.labelD.Name = "labelD";
      this.labelD.Size = new System.Drawing.Size(14, 13);
      this.labelD.TabIndex = 5;
      this.labelD.Text = "d";
      // 
      // RealPlane2D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealPlane2D";
      this.Size = new System.Drawing.Size(329, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtI;
    private System.Windows.Forms.TextBox txtD;
    private System.Windows.Forms.TextBox txtJ;
    private System.Windows.Forms.Label labelD;
    private System.Windows.Forms.Label labelJ;
    private System.Windows.Forms.Label labelI;
  }
}
