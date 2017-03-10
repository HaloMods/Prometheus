namespace Games.Halo.Controls
{
  partial class FixedLengthString
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
      this.txtValue = new System.Windows.Forms.TextBox();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtValue);
      this.panelContainer.Size = new System.Drawing.Size(183, 26);
      // 
      // txtValue
      // 
      this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtValue.Location = new System.Drawing.Point(5, 4);
      this.txtValue.Name = "txtValue";
      this.txtValue.Size = new System.Drawing.Size(100, 18);
      this.txtValue.TabIndex = 0;
      // 
      // FixedLengthString
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
      this.Name = "FixedLengthString";
      this.Size = new System.Drawing.Size(315, 26);
      this.panelContainer.ResumeLayout(false);
      this.panelContainer.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TextBox txtValue;
  }
}
