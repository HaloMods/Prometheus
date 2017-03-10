namespace Games.Halo.Controls
{
  partial class Angle
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
      this.lblDegrees = new System.Windows.Forms.Label();
      this.txtbxAngle = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxAngle);
      this.panelContainer.Controls.Add(this.lblDegrees);
      this.panelContainer.Size = new System.Drawing.Size(131, 26);
      // 
      // lblDegrees
      // 
      this.lblDegrees.AutoSize = true;
      this.lblDegrees.Location = new System.Drawing.Point(63, 6);
      this.lblDegrees.Name = "lblDegrees";
      this.lblDegrees.Size = new System.Drawing.Size(48, 13);
      this.lblDegrees.TabIndex = 1;
      this.lblDegrees.Text = "degrees";
      // 
      // txtbxAngle
      // 
      // 
      // 
      // 
      this.txtbxAngle.Border.Class = "TextBoxBorder";
      this.txtbxAngle.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxAngle.FocusHighlightEnabled = true;
      this.txtbxAngle.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxAngle.Location = new System.Drawing.Point(0, 3);
      this.txtbxAngle.MaxLength = 10;
      this.txtbxAngle.Name = "txtbxAngle";
      this.txtbxAngle.Size = new System.Drawing.Size(60, 20);
      this.txtbxAngle.TabIndex = 2;
      this.txtbxAngle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxAngle_KeyPress);
      this.txtbxAngle.TextChanged += new System.EventHandler(this.txtbxAngle_TextChanged);
      this.txtbxAngle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxAngle_KeyDown);
      // 
      // Angle
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Angle";
      this.Size = new System.Drawing.Size(263, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblDegrees;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxAngle;
  }
}
