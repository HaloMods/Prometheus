namespace Games.Halo.Controls
{
  partial class RealPoint3D
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
      this.labelXAxis = new System.Windows.Forms.Label();
      this.labelYAxis = new System.Windows.Forms.Label();
      this.labelZAxis = new System.Windows.Forms.Label();
      this.txtbxXAxis = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxYAxis = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxZAxis = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxZAxis);
      this.panelContainer.Controls.Add(this.txtbxYAxis);
      this.panelContainer.Controls.Add(this.txtbxXAxis);
      this.panelContainer.Controls.Add(this.labelZAxis);
      this.panelContainer.Controls.Add(this.labelYAxis);
      this.panelContainer.Controls.Add(this.labelXAxis);
      this.panelContainer.Size = new System.Drawing.Size(258, 26);
      // 
      // labelXAxis
      // 
      this.labelXAxis.AutoSize = true;
      this.labelXAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelXAxis.Location = new System.Drawing.Point(-3, 7);
      this.labelXAxis.Name = "labelXAxis";
      this.labelXAxis.Size = new System.Drawing.Size(19, 13);
      this.labelXAxis.TabIndex = 0;
      this.labelXAxis.Text = "X:";
      // 
      // labelYAxis
      // 
      this.labelYAxis.AutoSize = true;
      this.labelYAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelYAxis.Location = new System.Drawing.Point(78, 7);
      this.labelYAxis.Name = "labelYAxis";
      this.labelYAxis.Size = new System.Drawing.Size(19, 13);
      this.labelYAxis.TabIndex = 0;
      this.labelYAxis.Text = "Y:";
      // 
      // labelZAxis
      // 
      this.labelZAxis.AutoSize = true;
      this.labelZAxis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelZAxis.Location = new System.Drawing.Point(159, 7);
      this.labelZAxis.Name = "labelZAxis";
      this.labelZAxis.Size = new System.Drawing.Size(19, 13);
      this.labelZAxis.TabIndex = 0;
      this.labelZAxis.Text = "Z:";
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
      this.txtbxXAxis.MaxLength = 10;
      this.txtbxXAxis.Name = "txtbxXAxis";
      this.txtbxXAxis.Size = new System.Drawing.Size(60, 20);
      this.txtbxXAxis.TabIndex = 1;
      this.txtbxXAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbXYZ_KeyPress);
      this.txtbxXAxis.TextChanged += new System.EventHandler(this.txtbXYZ_TextChanged);
      this.txtbxXAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbXYZ_KeyDown);
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
      this.txtbxYAxis.Location = new System.Drawing.Point(97, 3);
      this.txtbxYAxis.MaxLength = 10;
      this.txtbxYAxis.Name = "txtbxYAxis";
      this.txtbxYAxis.Size = new System.Drawing.Size(60, 20);
      this.txtbxYAxis.TabIndex = 2;
      this.txtbxYAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbXYZ_KeyPress);
      this.txtbxYAxis.TextChanged += new System.EventHandler(this.txtbXYZ_TextChanged);
      this.txtbxYAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbXYZ_KeyDown);
      // 
      // txtbxZAxis
      // 
      // 
      // 
      // 
      this.txtbxZAxis.Border.Class = "TextBoxBorder";
      this.txtbxZAxis.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxZAxis.FocusHighlightEnabled = true;
      this.txtbxZAxis.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxZAxis.Location = new System.Drawing.Point(179, 3);
      this.txtbxZAxis.MaxLength = 10;
      this.txtbxZAxis.Name = "txtbxZAxis";
      this.txtbxZAxis.Size = new System.Drawing.Size(60, 20);
      this.txtbxZAxis.TabIndex = 3;
      this.txtbxZAxis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbXYZ_KeyPress);
      this.txtbxZAxis.TextChanged += new System.EventHandler(this.txtbXYZ_TextChanged);
      this.txtbxZAxis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbXYZ_KeyDown);
      // 
      // RealPoint3D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealPoint3D";
      this.Size = new System.Drawing.Size(390, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelZAxis;
    private System.Windows.Forms.Label labelYAxis;
    private System.Windows.Forms.Label labelXAxis;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxXAxis;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxYAxis;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxZAxis;
  }
}
