namespace Prometheus.Controls.ReferenceAnalyzer
{
  partial class ReferenceContainer
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.ipContainer = new DevComponents.DotNetBar.ItemPanel();
      this.SuspendLayout();
      // 
      // ipContainer
      // 
      this.ipContainer.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ipContainer.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.ipContainer.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipContainer.BackgroundStyle.BorderBottomWidth = 1;
      this.ipContainer.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipContainer.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipContainer.BackgroundStyle.BorderLeftWidth = 1;
      this.ipContainer.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipContainer.BackgroundStyle.BorderRightWidth = 1;
      this.ipContainer.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.ipContainer.BackgroundStyle.BorderTopWidth = 1;
      this.ipContainer.BackgroundStyle.PaddingBottom = 1;
      this.ipContainer.BackgroundStyle.PaddingLeft = 1;
      this.ipContainer.BackgroundStyle.PaddingRight = 1;
      this.ipContainer.BackgroundStyle.PaddingTop = 1;
      this.ipContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ipContainer.GetType();
      this.ipContainer.Location = new System.Drawing.Point(0, 0);
      this.ipContainer.Name = "ipContainer";
      this.ipContainer.Size = new System.Drawing.Size(357, 214);
      this.ipContainer.TabIndex = 0;
      // 
      // ReferenceContainer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoScroll = true;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.Controls.Add(this.ipContainer);
      this.Name = "ReferenceContainer";
      this.Size = new System.Drawing.Size(357, 214);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ItemPanel ipContainer;
  }
}
