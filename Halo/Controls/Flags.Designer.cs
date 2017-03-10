namespace Games.Halo.Controls
{
  partial class Flags
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
      this.checkValue = new System.Windows.Forms.CheckedListBox();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.checkValue);
      this.panelContainer.Size = new System.Drawing.Size(242, 63);
      // 
      // checkValue
      // 
      this.checkValue.CheckOnClick = true;
      this.checkValue.FormattingEnabled = true;
      this.checkValue.HorizontalScrollbar = true;
      this.checkValue.Items.AddRange(new object[] {
            ""});
      this.checkValue.Location = new System.Drawing.Point(0, 4);
      this.checkValue.MaximumSize = new System.Drawing.Size(190, 275);
      this.checkValue.Name = "checkValue";
      this.checkValue.Size = new System.Drawing.Size(190, 4);
      this.checkValue.Sorted = true;
      this.checkValue.TabIndex = 1;
      this.checkValue.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkValue_ItemCheck);
      // 
      // Flags
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "Flags";
      this.Size = new System.Drawing.Size(374, 63);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.CheckedListBox checkValue;

  }
}
