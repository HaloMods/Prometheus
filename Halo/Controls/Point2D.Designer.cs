namespace Games.Halo.Controls
{
  partial class Point2D
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
      this.txtbxYAxis = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxXAxis = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.labelYAxis = new System.Windows.Forms.Label();
      this.labelXAxis = new System.Windows.Forms.Label();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxYAxis);
      this.panelContainer.Controls.Add(this.txtbxXAxis);
      this.panelContainer.Controls.Add(this.labelYAxis);
      this.panelContainer.Controls.Add(this.labelXAxis);
      this.panelContainer.Size = new System.Drawing.Size(165, 26);
      // 
      // txtbxYAxis
      // 
      // 
      // 
      // 
      this.txtbxYAxis.Border.Class = "TextBoxBorder";
      this.txtbxYAxis.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxYAxis.FocusHighlightEnabled = true;
      this.txtbxYAxis.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxYAxis.Location = new System.Drawing.Point(82, 3);
      this.txtbxYAxis.MaxLength = 6;
      this.txtbxYAxis.Name = "txtbxYAxis";
      this.txtbxYAxis.Size = new System.Drawing.Size(45, 20);
      this.txtbxYAxis.TabIndex = 6;
      this.txtbxYAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxXY_KeyPress);
      this.txtbxYAxis.TextChanged += new System.EventHandler(this.txtbxXY_TextChanged);
      this.txtbxYAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxXY_KeyDown);
      // 
      // txtbxXAxis
      // 
      // 
      // 
      // 
      this.txtbxXAxis.Border.Class = "TextBoxBorder";
      this.txtbxXAxis.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxXAxis.FocusHighlightEnabled = true;
      this.txtbxXAxis.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxXAxis.Location = new System.Drawing.Point(16, 3);
      this.txtbxXAxis.MaxLength = 6;
      this.txtbxXAxis.Name = "txtbxXAxis";
      this.txtbxXAxis.Size = new System.Drawing.Size(45, 20);
      this.txtbxXAxis.TabIndex = 5;
      this.txtbxXAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxXY_KeyPress);
      this.txtbxXAxis.TextChanged += new System.EventHandler(this.txtbxXY_TextChanged);
      this.txtbxXAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxXY_KeyDown);
      // 
      // labelYAxis
      // 
      this.labelYAxis.AutoSize = true;
      this.labelYAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelYAxis.Location = new System.Drawing.Point(63, 7);
      this.labelYAxis.Name = "labelYAxis";
      this.labelYAxis.Size = new System.Drawing.Size(19, 13);
      this.labelYAxis.TabIndex = 3;
      this.labelYAxis.Text = "Y:";
      // 
      // labelXAxis
      // 
      this.labelXAxis.AutoSize = true;
      this.labelXAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelXAxis.Location = new System.Drawing.Point(-3, 7);
      this.labelXAxis.Name = "labelXAxis";
      this.labelXAxis.Size = new System.Drawing.Size(19, 13);
      this.labelXAxis.TabIndex = 4;
      this.labelXAxis.Text = "X:";
      // 
      // Point2D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Point2D";
      this.Size = new System.Drawing.Size(297, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.Controls.TextBoxX txtbxYAxis;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxXAxis;
    private System.Windows.Forms.Label labelYAxis;
    private System.Windows.Forms.Label labelXAxis;

  }
}
