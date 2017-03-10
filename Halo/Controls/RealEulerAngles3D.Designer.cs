namespace Games.Halo.Controls
{
  partial class RealEulerAngles3D
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
      this.labelYaw = new System.Windows.Forms.Label();
      this.labelPitch = new System.Windows.Forms.Label();
      this.labelRoll = new System.Windows.Forms.Label();
      this.txtbxYaw = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxPitch = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtbxRoll = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxRoll);
      this.panelContainer.Controls.Add(this.txtbxPitch);
      this.panelContainer.Controls.Add(this.txtbxYaw);
      this.panelContainer.Controls.Add(this.labelRoll);
      this.panelContainer.Controls.Add(this.labelPitch);
      this.panelContainer.Controls.Add(this.labelYaw);
      this.panelContainer.Size = new System.Drawing.Size(258, 26);
      // 
      // labelYaw
      // 
      this.labelYaw.AutoSize = true;
      this.labelYaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelYaw.Location = new System.Drawing.Point(-3, 7);
      this.labelYaw.Name = "labelYaw";
      this.labelYaw.Size = new System.Drawing.Size(19, 13);
      this.labelYaw.TabIndex = 0;
      this.labelYaw.Text = "Y:";
      // 
      // labelPitch
      // 
      this.labelPitch.AutoSize = true;
      this.labelPitch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelPitch.Location = new System.Drawing.Point(78, 7);
      this.labelPitch.Name = "labelPitch";
      this.labelPitch.Size = new System.Drawing.Size(19, 13);
      this.labelPitch.TabIndex = 0;
      this.labelPitch.Text = "P:";
      // 
      // labelRoll
      // 
      this.labelRoll.AutoSize = true;
      this.labelRoll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelRoll.Location = new System.Drawing.Point(159, 7);
      this.labelRoll.Name = "labelRoll";
      this.labelRoll.Size = new System.Drawing.Size(20, 13);
      this.labelRoll.TabIndex = 0;
      this.labelRoll.Text = "R:";
      // 
      // txtbxYaw
      // 
      // 
      // 
      // 
      this.txtbxYaw.Border.Class = "TextBoxBorder";
      this.txtbxYaw.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxYaw.FocusHighlightEnabled = true;
      this.txtbxYaw.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxYaw.Location = new System.Drawing.Point(16, 3);
      this.txtbxYaw.MaxLength = 10;
      this.txtbxYaw.Name = "txtbxYaw";
      this.txtbxYaw.Size = new System.Drawing.Size(60, 20);
      this.txtbxYaw.TabIndex = 1;
      this.txtbxYaw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbYPR_KeyPress);
      this.txtbxYaw.TextChanged += new System.EventHandler(this.txtbYPR_TextChanged);
      this.txtbxYaw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbYPR_KeyDown);
      // 
      // txtbxPitch
      // 
      // 
      // 
      // 
      this.txtbxPitch.Border.Class = "TextBoxBorder";
      this.txtbxPitch.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxPitch.FocusHighlightEnabled = true;
      this.txtbxPitch.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxPitch.Location = new System.Drawing.Point(97, 3);
      this.txtbxPitch.MaxLength = 10;
      this.txtbxPitch.Name = "txtbxPitch";
      this.txtbxPitch.Size = new System.Drawing.Size(60, 20);
      this.txtbxPitch.TabIndex = 2;
      this.txtbxPitch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbYPR_KeyPress);
      this.txtbxPitch.TextChanged += new System.EventHandler(this.txtbYPR_TextChanged);
      this.txtbxPitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbYPR_KeyDown);
      // 
      // txtbxRoll
      // 
      // 
      // 
      // 
      this.txtbxRoll.Border.Class = "TextBoxBorder";
      this.txtbxRoll.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxRoll.FocusHighlightEnabled = true;
      this.txtbxRoll.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxRoll.Location = new System.Drawing.Point(179, 3);
      this.txtbxRoll.MaxLength = 10;
      this.txtbxRoll.Name = "txtbxRoll";
      this.txtbxRoll.Size = new System.Drawing.Size(60, 20);
      this.txtbxRoll.TabIndex = 3;
      this.txtbxRoll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbYPR_KeyPress);
      this.txtbxRoll.TextChanged += new System.EventHandler(this.txtbYPR_TextChanged);
      this.txtbxRoll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbYPR_KeyDown);
      // 
      // RealEulerAngles3D
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "RealEulerAngles3D";
      this.Size = new System.Drawing.Size(390, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label labelRoll;
    private System.Windows.Forms.Label labelPitch;
    private System.Windows.Forms.Label labelYaw;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxYaw;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxPitch;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxRoll;
  }
}
