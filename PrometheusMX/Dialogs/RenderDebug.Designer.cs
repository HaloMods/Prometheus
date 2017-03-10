namespace Prometheus.Dialogs
{
  partial class RenderDebug
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
      this.numericUpDownActiveCluster = new System.Windows.Forms.NumericUpDown();
      this.label1 = new System.Windows.Forms.Label();
      this.checkBoxLockVis = new System.Windows.Forms.CheckBox();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActiveCluster)).BeginInit();
      this.SuspendLayout();
      // 
      // numericUpDownActiveCluster
      // 
      this.numericUpDownActiveCluster.Location = new System.Drawing.Point(153, 17);
      this.numericUpDownActiveCluster.Name = "numericUpDownActiveCluster";
      this.numericUpDownActiveCluster.Size = new System.Drawing.Size(57, 22);
      this.numericUpDownActiveCluster.TabIndex = 0;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 19);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(135, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Active Cluster Index:";
      // 
      // checkBoxLockVis
      // 
      this.checkBoxLockVis.AutoSize = true;
      this.checkBoxLockVis.Location = new System.Drawing.Point(93, 66);
      this.checkBoxLockVis.Name = "checkBoxLockVis";
      this.checkBoxLockVis.Size = new System.Drawing.Size(85, 21);
      this.checkBoxLockVis.TabIndex = 0;
      this.checkBoxLockVis.Text = "Lock VIS";
      this.checkBoxLockVis.UseVisualStyleBackColor = true;
      this.checkBoxLockVis.CheckedChanged += new System.EventHandler(this.checkBoxLockVis_CheckedChanged);
      // 
      // RenderDebug
      // 
      this.ClientSize = new System.Drawing.Size(292, 260);
      this.Controls.Add(this.checkBoxLockVis);
      this.Name = "RenderDebug";
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownActiveCluster)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NumericUpDown numericUpDownActiveCluster;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox checkBoxLockVis;
  }
}