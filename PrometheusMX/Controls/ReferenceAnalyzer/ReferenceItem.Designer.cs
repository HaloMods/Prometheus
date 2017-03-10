namespace Prometheus.Controls.ReferenceAnalyzer
{
  partial class ReferenceItem
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
      this.ipReference = new DevComponents.DotNetBar.ItemPanel();
      this.icErrorSummary = new DevComponents.DotNetBar.ItemContainer();
      this.liErrorSummary = new DevComponents.DotNetBar.LabelItem();
      this.ipReferenceCount = new DevComponents.DotNetBar.ItemPanel();
      this.icMissing = new DevComponents.DotNetBar.ItemContainer();
      this.icMissingDirectly = new DevComponents.DotNetBar.ItemContainer();
      this.liMissingDirectly = new DevComponents.DotNetBar.LabelItem();
      this.liMissingDirectlyValue = new DevComponents.DotNetBar.LabelItem();
      this.icMissingRecursively = new DevComponents.DotNetBar.ItemContainer();
      this.liMissingRecursively = new DevComponents.DotNetBar.LabelItem();
      this.liMissingRecursivelyValue = new DevComponents.DotNetBar.LabelItem();
      this.SuspendLayout();
      // 
      // ipReference
      // 
      this.ipReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ipReference.BackColor = System.Drawing.Color.Transparent;
      this.ipReference.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icErrorSummary});
      this.ipReference.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipReference.GetType();
      this.ipReference.Location = new System.Drawing.Point(0, 0);
      this.ipReference.Name = "ipReference";
      this.ipReference.Size = new System.Drawing.Size(254, 47);
      this.ipReference.TabIndex = 9;
      // 
      // icErrorSummary
      // 
      // 
      // 
      // 
      this.icErrorSummary.BackgroundStyle.MarginBottom = 5;
      this.icErrorSummary.BackgroundStyle.MarginLeft = 2;
      this.icErrorSummary.BackgroundStyle.MarginRight = 20;
      this.icErrorSummary.BackgroundStyle.MarginTop = 2;
      this.icErrorSummary.MinimumSize = new System.Drawing.Size(0, 0);
      this.icErrorSummary.Name = "icErrorSummary";
      this.icErrorSummary.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liErrorSummary});
      this.icErrorSummary.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
      // 
      // liErrorSummary
      // 
      this.liErrorSummary.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liErrorSummary.Height = 40;
      this.liErrorSummary.Image = global::Prometheus.Properties.Resources.document_warning32;
      this.liErrorSummary.Name = "liErrorSummary";
      this.liErrorSummary.PaddingTop = 3;
      this.liErrorSummary.Text = "<b>[Name]</b> (<font color=\"navy\">[Type]</font>)<br/>\r\n<font color=\"gray\">[Path O" +
          "nly]</font>";
      this.liErrorSummary.Width = 250;
      this.liErrorSummary.WordWrap = true;
      this.liErrorSummary.Click += new System.EventHandler(this.liErrorSummary_Click);
      // 
      // ipReferenceCount
      // 
      this.ipReferenceCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      // 
      // 
      // 
      this.ipReferenceCount.BackgroundStyle.BackColor = System.Drawing.Color.WhiteSmoke;
      this.ipReferenceCount.BackgroundStyle.BorderBottomWidth = 1;
      this.ipReferenceCount.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipReferenceCount.BackgroundStyle.BorderLeftWidth = 1;
      this.ipReferenceCount.BackgroundStyle.BorderRightWidth = 1;
      this.ipReferenceCount.BackgroundStyle.BorderTopWidth = 1;
      this.ipReferenceCount.BackgroundStyle.PaddingBottom = 1;
      this.ipReferenceCount.BackgroundStyle.PaddingLeft = 1;
      this.ipReferenceCount.BackgroundStyle.PaddingRight = 1;
      this.ipReferenceCount.BackgroundStyle.PaddingTop = 1;
      this.ipReferenceCount.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icMissing});
      this.ipReferenceCount.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipReferenceCount.GetType();
      this.ipReferenceCount.Location = new System.Drawing.Point(253, 0);
      this.ipReferenceCount.Name = "ipReferenceCount";
      this.ipReferenceCount.Size = new System.Drawing.Size(132, 47);
      this.ipReferenceCount.TabIndex = 10;
      this.ipReferenceCount.Text = "itemPanel1";
      // 
      // icMissing
      // 
      this.icMissing.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.icMissing.MinimumSize = new System.Drawing.Size(0, 0);
      this.icMissing.Name = "icMissing";
      this.icMissing.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icMissingDirectly,
            this.icMissingRecursively});
      // 
      // icMissingDirectly
      // 
      // 
      // 
      // 
      this.icMissingDirectly.BackgroundStyle.MarginTop = 3;
      this.icMissingDirectly.MinimumSize = new System.Drawing.Size(0, 0);
      this.icMissingDirectly.Name = "icMissingDirectly";
      this.icMissingDirectly.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liMissingDirectly,
            this.liMissingDirectlyValue});
      // 
      // liMissingDirectly
      // 
      this.liMissingDirectly.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liMissingDirectly.Name = "liMissingDirectly";
      this.liMissingDirectly.Text = "Directly Missing:";
      // 
      // liMissingDirectlyValue
      // 
      this.liMissingDirectlyValue.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liMissingDirectlyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.liMissingDirectlyValue.ForeColor = System.Drawing.Color.Black;
      this.liMissingDirectlyValue.Name = "liMissingDirectlyValue";
      this.liMissingDirectlyValue.Text = "0";
      this.liMissingDirectlyValue.TextAlignment = System.Drawing.StringAlignment.Far;
      this.liMissingDirectlyValue.Width = 40;
      // 
      // icMissingRecursively
      // 
      // 
      // 
      // 
      this.icMissingRecursively.BackgroundStyle.MarginTop = 5;
      this.icMissingRecursively.MinimumSize = new System.Drawing.Size(0, 0);
      this.icMissingRecursively.Name = "icMissingRecursively";
      this.icMissingRecursively.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liMissingRecursively,
            this.liMissingRecursivelyValue});
      // 
      // liMissingRecursively
      // 
      this.liMissingRecursively.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liMissingRecursively.Name = "liMissingRecursively";
      this.liMissingRecursively.Text = "Recursively Missing:";
      // 
      // liMissingRecursivelyValue
      // 
      this.liMissingRecursivelyValue.BorderType = DevComponents.DotNetBar.eBorderType.None;
      this.liMissingRecursivelyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.liMissingRecursivelyValue.ForeColor = System.Drawing.Color.Black;
      this.liMissingRecursivelyValue.Name = "liMissingRecursivelyValue";
      this.liMissingRecursivelyValue.Text = "0";
      this.liMissingRecursivelyValue.TextAlignment = System.Drawing.StringAlignment.Far;
      this.liMissingRecursivelyValue.Width = 20;
      // 
      // ReferenceItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.WhiteSmoke;
      this.Controls.Add(this.ipReferenceCount);
      this.Controls.Add(this.ipReference);
      this.Name = "ReferenceItem";
      this.Size = new System.Drawing.Size(385, 47);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ItemPanel ipReference;
    private DevComponents.DotNetBar.ItemContainer icErrorSummary;
    private DevComponents.DotNetBar.LabelItem liErrorSummary;
    private DevComponents.DotNetBar.ItemPanel ipReferenceCount;
    private DevComponents.DotNetBar.ItemContainer icMissing;
    private DevComponents.DotNetBar.ItemContainer icMissingDirectly;
    private DevComponents.DotNetBar.LabelItem liMissingDirectly;
    private DevComponents.DotNetBar.LabelItem liMissingDirectlyValue;
    private DevComponents.DotNetBar.ItemContainer icMissingRecursively;
    private DevComponents.DotNetBar.LabelItem liMissingRecursively;
    private DevComponents.DotNetBar.LabelItem liMissingRecursivelyValue;
  }
}