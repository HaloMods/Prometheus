namespace Games.Halo.Controls
{
  partial class Rectangle2D
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
      this.txtT = new System.Windows.Forms.TextBox();
      this.txtB = new System.Windows.Forms.TextBox();
      this.txtL = new System.Windows.Forms.TextBox();
      this.labelTop = new System.Windows.Forms.Label();
      this.labelBottom = new System.Windows.Forms.Label();
      this.labelLeft = new System.Windows.Forms.Label();
      this.labelRight = new System.Windows.Forms.Label();
      this.txtR = new System.Windows.Forms.TextBox();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.labelRight);
      this.panelContainer.Controls.Add(this.txtR);
      this.panelContainer.Controls.Add(this.labelLeft);
      this.panelContainer.Controls.Add(this.labelBottom);
      this.panelContainer.Controls.Add(this.labelTop);
      this.panelContainer.Controls.Add(this.txtL);
      this.panelContainer.Controls.Add(this.txtB);
      this.panelContainer.Controls.Add(this.txtT);
      this.panelContainer.Size = new System.Drawing.Size(271, 49);
      // 
      // txtT
      // 
      this.txtT.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtT.Location = new System.Drawing.Point(125, 4);
      this.txtT.Name = "txtT";
      this.txtT.Size = new System.Drawing.Size(50, 18);
      this.txtT.TabIndex = 0;
      // 
      // txtB
      // 
      this.txtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtB.Location = new System.Drawing.Point(125, 28);
      this.txtB.Name = "txtB";
      this.txtB.Size = new System.Drawing.Size(50, 18);
      this.txtB.TabIndex = 1;
      // 
      // txtL
      // 
      this.txtL.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtL.Location = new System.Drawing.Point(29, 15);
      this.txtL.Name = "txtL";
      this.txtL.Size = new System.Drawing.Size(50, 18);
      this.txtL.TabIndex = 2;
      // 
      // labelTop
      // 
      this.labelTop.AutoSize = true;
      this.labelTop.Location = new System.Drawing.Point(101, 6);
      this.labelTop.Name = "labelTop";
      this.labelTop.Size = new System.Drawing.Size(25, 13);
      this.labelTop.TabIndex = 3;
      this.labelTop.Text = "top";
      // 
      // labelBottom
      // 
      this.labelBottom.AutoSize = true;
      this.labelBottom.Location = new System.Drawing.Point(85, 30);
      this.labelBottom.Name = "labelBottom";
      this.labelBottom.Size = new System.Drawing.Size(45, 13);
      this.labelBottom.TabIndex = 4;
      this.labelBottom.Text = "bottom";
      // 
      // labelLeft
      // 
      this.labelLeft.AutoSize = true;
      this.labelLeft.Location = new System.Drawing.Point(5, 17);
      this.labelLeft.Name = "labelLeft";
      this.labelLeft.Size = new System.Drawing.Size(24, 13);
      this.labelLeft.TabIndex = 5;
      this.labelLeft.Text = "left";
      // 
      // labelRight
      // 
      this.labelRight.AutoSize = true;
      this.labelRight.Location = new System.Drawing.Point(189, 17);
      this.labelRight.Name = "labelRight";
      this.labelRight.Size = new System.Drawing.Size(32, 13);
      this.labelRight.TabIndex = 7;
      this.labelRight.Text = "right";
      // 
      // txtR
      // 
      this.txtR.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtR.Location = new System.Drawing.Point(222, 15);
      this.txtR.Name = "txtR";
      this.txtR.Size = new System.Drawing.Size(50, 18);
      this.txtR.TabIndex = 6;
      // 
      // Rectangle2D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Rectangle2D";
      this.Size = new System.Drawing.Size(403, 49);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtT;
    private System.Windows.Forms.TextBox txtL;
    private System.Windows.Forms.TextBox txtB;
    private System.Windows.Forms.Label labelLeft;
    private System.Windows.Forms.Label labelBottom;
    private System.Windows.Forms.Label labelTop;
    private System.Windows.Forms.Label labelRight;
    private System.Windows.Forms.TextBox txtR;
  }
}
