namespace Prometheus.Testing
{
  partial class ProgressDialog
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
      this.pgbProgress = new DevComponents.DotNetBar.Controls.ProgressBarX();
      this.lblInfo1 = new DevComponents.DotNetBar.LabelX();
      this.lblInfo2 = new DevComponents.DotNetBar.LabelX();
      this.SuspendLayout();
      // 
      // pgbProgress
      // 
      this.pgbProgress.Location = new System.Drawing.Point(12, 103);
      this.pgbProgress.Name = "pgbProgress";
      this.pgbProgress.Size = new System.Drawing.Size(472, 23);
      this.pgbProgress.TabIndex = 1;
      // 
      // lblInfo1
      // 
      this.lblInfo1.AutoSize = true;
      this.lblInfo1.Location = new System.Drawing.Point(12, 12);
      this.lblInfo1.Name = "lblInfo1";
      this.lblInfo1.Size = new System.Drawing.Size(113, 13);
      this.lblInfo1.TabIndex = 2;
      this.lblInfo1.Text = "Currently processing...";
      // 
      // lblInfo2
      // 
      this.lblInfo2.AutoSize = true;
      this.lblInfo2.Location = new System.Drawing.Point(12, 54);
      this.lblInfo2.Name = "lblInfo2";
      this.lblInfo2.Size = new System.Drawing.Size(321, 43);
      this.lblInfo2.TabIndex = 3;
      // 
      // ProgressDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(496, 138);
      this.Controls.Add(this.lblInfo2);
      this.Controls.Add(this.lblInfo1);
      this.Controls.Add(this.pgbProgress);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Name = "ProgressDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "ProgressDialog";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevComponents.DotNetBar.Controls.ProgressBarX pgbProgress;
    private DevComponents.DotNetBar.LabelX lblInfo1;
    private DevComponents.DotNetBar.LabelX lblInfo2;
  }
}