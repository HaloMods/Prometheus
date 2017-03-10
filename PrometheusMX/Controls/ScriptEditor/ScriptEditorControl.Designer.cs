namespace Prometheus.Controls.ScriptEditor
{
  partial class ScriptEditorControl
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
      ActiproSoftware.SyntaxEditor.Document document1 = new ActiproSoftware.SyntaxEditor.Document();
      this.syntaxEditor = new ActiproSoftware.SyntaxEditor.SyntaxEditor();
      this.SuspendLayout();
      // 
      // syntaxEditor
      // 
      this.syntaxEditor.BracketHighlightingInclusive = true;
      this.syntaxEditor.BracketHighlightingVisible = true;
      this.syntaxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      document1.LineModificationMarkingEnabled = true;
      document1.Outlining.Mode = ActiproSoftware.SyntaxEditor.OutliningMode.Automatic;
      document1.TabSize = 2;
      this.syntaxEditor.Document = document1;
      this.syntaxEditor.LineNumberMarginVisible = true;
      this.syntaxEditor.Location = new System.Drawing.Point(8, 8);
      this.syntaxEditor.Name = "syntaxEditor";
      this.syntaxEditor.Size = new System.Drawing.Size(560, 528);
      this.syntaxEditor.SplitType = ActiproSoftware.SyntaxEditor.SyntaxEditorSplitType.None;
      this.syntaxEditor.TabIndex = 0;
      // 
      // ScriptEditorControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.syntaxEditor);
      this.Name = "ScriptEditorControl";
      this.Padding = new System.Windows.Forms.Padding(8);
      this.Size = new System.Drawing.Size(576, 544);
      this.ResumeLayout(false);

    }

    #endregion

    private ActiproSoftware.SyntaxEditor.SyntaxEditor syntaxEditor;
  }
}
