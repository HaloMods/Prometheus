namespace Prometheus.Dialogs
{
  partial class NoteManager
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteManager));
        this.ipIntro = new DevComponents.DotNetBar.ItemPanel();
        this.liIntro = new DevComponents.DotNetBar.LabelItem();
        this.barStatus = new DevComponents.DotNetBar.Bar();
        this.liStatus = new DevComponents.DotNetBar.LabelItem();
        this.lbNotes = new System.Windows.Forms.ListBox();
        this.gbStoredNotes = new System.Windows.Forms.GroupBox();
        this.bxNewNote = new DevComponents.DotNetBar.ButtonX();
        this.bxEditNote = new DevComponents.DotNetBar.ButtonX();
        this.bxDeleteNote = new DevComponents.DotNetBar.ButtonX();
        this.bxSaveNotes = new DevComponents.DotNetBar.ButtonX();
        this.txtbNoteName = new System.Windows.Forms.TextBox();
        this.lblName = new System.Windows.Forms.Label();
        this.txtbNoteContents = new System.Windows.Forms.TextBox();
        this.gbSelectedNote = new System.Windows.Forms.GroupBox();
        ((System.ComponentModel.ISupportInitialize)(this.barStatus)).BeginInit();
        this.gbStoredNotes.SuspendLayout();
        this.gbSelectedNote.SuspendLayout();
        this.SuspendLayout();
        // 
        // ipIntro
        // 
        this.ipIntro.AutoScroll = true;
        this.ipIntro.BackColor = System.Drawing.Color.Transparent;
        // 
        // 
        // 
        this.ipIntro.BackgroundStyle.PaddingBottom = 2;
        this.ipIntro.BackgroundStyle.PaddingLeft = 2;
        this.ipIntro.BackgroundStyle.PaddingRight = 2;
        this.ipIntro.BackgroundStyle.PaddingTop = 2;
        this.ipIntro.Dock = System.Windows.Forms.DockStyle.Top;
        this.ipIntro.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liIntro});
        this.ipIntro.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
        this.ipIntro.GetType();
        this.ipIntro.Location = new System.Drawing.Point(0, 0);
        this.ipIntro.Name = "ipIntro";
        this.ipIntro.Size = new System.Drawing.Size(471, 32);
        this.ipIntro.TabIndex = 0;
        // 
        // liIntro
        // 
        this.liIntro.BorderType = DevComponents.DotNetBar.eBorderType.None;
        this.liIntro.Name = "liIntro";
        this.liIntro.Text = "You may view and enter notes regarding <b>[section / tag / project name]</b> here" +
            ". These notes will<br/>be stored in the file and anyone with access to the file " +
            "will be able to see the information.";
        this.liIntro.WordWrap = true;
        // 
        // barStatus
        // 
        this.barStatus.AccessibleDescription = "DotNetBar Bar (barStatus)";
        this.barStatus.AccessibleName = "DotNetBar Bar";
        this.barStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
        this.barStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
        this.barStatus.CanDockBottom = false;
        this.barStatus.CanDockLeft = false;
        this.barStatus.CanDockRight = false;
        this.barStatus.CanDockTab = false;
        this.barStatus.CanDockTop = false;
        this.barStatus.CanReorderTabs = false;
        this.barStatus.CanUndock = false;
        this.barStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.barStatus.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
        this.barStatus.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liStatus});
        this.barStatus.Location = new System.Drawing.Point(0, 230);
        this.barStatus.Margin = new System.Windows.Forms.Padding(0);
        this.barStatus.Name = "barStatus";
        this.barStatus.PaddingBottom = 0;
        this.barStatus.PaddingLeft = 0;
        this.barStatus.PaddingRight = 0;
        this.barStatus.PaddingTop = 3;
        this.barStatus.RoundCorners = false;
        this.barStatus.Size = new System.Drawing.Size(471, 24);
        this.barStatus.Stretch = true;
        this.barStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
        this.barStatus.TabIndex = 14;
        this.barStatus.TabStop = false;
        // 
        // liStatus
        // 
        this.liStatus.BorderType = DevComponents.DotNetBar.eBorderType.RaisedInner;
        this.liStatus.Name = "liStatus";
        this.liStatus.PaddingLeft = 5;
        this.liStatus.Text = "Viewing <b>[Note Name]</b> in read-only mode.";
        // 
        // lbNotes
        // 
        this.lbNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
        this.lbNotes.BackColor = System.Drawing.SystemColors.ControlLight;
        this.lbNotes.FormattingEnabled = true;
        this.lbNotes.IntegralHeight = false;
        this.lbNotes.Location = new System.Drawing.Point(7, 17);
        this.lbNotes.Name = "lbNotes";
        this.lbNotes.Size = new System.Drawing.Size(120, 173);
        this.lbNotes.TabIndex = 1;
        // 
        // gbStoredNotes
        // 
        this.gbStoredNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
        this.gbStoredNotes.BackColor = System.Drawing.Color.Transparent;
        this.gbStoredNotes.Controls.Add(this.lbNotes);
        this.gbStoredNotes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.gbStoredNotes.Location = new System.Drawing.Point(5, 31);
        this.gbStoredNotes.Name = "gbStoredNotes";
        this.gbStoredNotes.Size = new System.Drawing.Size(134, 196);
        this.gbStoredNotes.TabIndex = 15;
        this.gbStoredNotes.TabStop = false;
        this.gbStoredNotes.Text = "Stored Notes";
        // 
        // bxNewNote
        // 
        this.bxNewNote.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxNewNote.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxNewNote.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
        this.bxNewNote.Image = global::Prometheus.Properties.Resources.note_new32;
        this.bxNewNote.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
        this.bxNewNote.Location = new System.Drawing.Point(145, 51);
        this.bxNewNote.Name = "bxNewNote";
        this.bxNewNote.Size = new System.Drawing.Size(41, 36);
        this.bxNewNote.TabIndex = 4;
        // 
        // bxEditNote
        // 
        this.bxEditNote.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxEditNote.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxEditNote.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
        this.bxEditNote.Image = global::Prometheus.Properties.Resources.note_edit32;
        this.bxEditNote.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
        this.bxEditNote.Location = new System.Drawing.Point(145, 93);
        this.bxEditNote.Name = "bxEditNote";
        this.bxEditNote.Size = new System.Drawing.Size(41, 36);
        this.bxEditNote.TabIndex = 5;
        // 
        // bxDeleteNote
        // 
        this.bxDeleteNote.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxDeleteNote.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxDeleteNote.ColorTable = DevComponents.DotNetBar.eButtonColor.Orange;
        this.bxDeleteNote.Image = global::Prometheus.Properties.Resources.note_delete32;
        this.bxDeleteNote.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
        this.bxDeleteNote.Location = new System.Drawing.Point(145, 135);
        this.bxDeleteNote.Name = "bxDeleteNote";
        this.bxDeleteNote.Size = new System.Drawing.Size(41, 36);
        this.bxDeleteNote.TabIndex = 6;
        // 
        // bxSaveNotes
        // 
        this.bxSaveNotes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
        this.bxSaveNotes.ColorScheme.DockSiteBackColorGradientAngle = 0;
        this.bxSaveNotes.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
        this.bxSaveNotes.Image = global::Prometheus.Properties.Resources.disk_blue16;
        this.bxSaveNotes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
        this.bxSaveNotes.Location = new System.Drawing.Point(145, 177);
        this.bxSaveNotes.Name = "bxSaveNotes";
        this.bxSaveNotes.Size = new System.Drawing.Size(41, 36);
        this.bxSaveNotes.TabIndex = 7;
        this.bxSaveNotes.Text = "&Save";
        // 
        // txtbNoteName
        // 
        this.txtbNoteName.BackColor = System.Drawing.SystemColors.ControlLight;
        this.txtbNoteName.Enabled = false;
        this.txtbNoteName.Location = new System.Drawing.Point(45, 16);
        this.txtbNoteName.Name = "txtbNoteName";
        this.txtbNoteName.Size = new System.Drawing.Size(231, 20);
        this.txtbNoteName.TabIndex = 2;
        // 
        // lblName
        // 
        this.lblName.AutoSize = true;
        this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblName.Location = new System.Drawing.Point(4, 19);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(38, 13);
        this.lblName.TabIndex = 1;
        this.lblName.Text = "Name:";
        // 
        // txtbNoteContents
        // 
        this.txtbNoteContents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
        this.txtbNoteContents.BackColor = System.Drawing.SystemColors.ControlLight;
        this.txtbNoteContents.Enabled = false;
        this.txtbNoteContents.Location = new System.Drawing.Point(7, 39);
        this.txtbNoteContents.Multiline = true;
        this.txtbNoteContents.Name = "txtbNoteContents";
        this.txtbNoteContents.Size = new System.Drawing.Size(269, 151);
        this.txtbNoteContents.TabIndex = 3;
        // 
        // gbSelectedNote
        // 
        this.gbSelectedNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)));
        this.gbSelectedNote.BackColor = System.Drawing.Color.Transparent;
        this.gbSelectedNote.Controls.Add(this.txtbNoteContents);
        this.gbSelectedNote.Controls.Add(this.lblName);
        this.gbSelectedNote.Controls.Add(this.txtbNoteName);
        this.gbSelectedNote.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
        this.gbSelectedNote.Location = new System.Drawing.Point(192, 31);
        this.gbSelectedNote.Name = "gbSelectedNote";
        this.gbSelectedNote.Size = new System.Drawing.Size(283, 196);
        this.gbSelectedNote.TabIndex = 16;
        this.gbSelectedNote.TabStop = false;
        this.gbSelectedNote.Text = "[Note Name] Contains";
        // 
        // NoteManager
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CaptionFont = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
        this.ClientSize = new System.Drawing.Size(471, 254);
        this.Controls.Add(this.gbSelectedNote);
        this.Controls.Add(this.bxSaveNotes);
        this.Controls.Add(this.bxDeleteNote);
        this.Controls.Add(this.bxEditNote);
        this.Controls.Add(this.bxNewNote);
        this.Controls.Add(this.gbStoredNotes);
        this.Controls.Add(this.barStatus);
        this.Controls.Add(this.ipIntro);
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.MaximumSize = new System.Drawing.Size(487, 500);
        this.MinimumSize = new System.Drawing.Size(487, 287);
        this.Name = "NoteManager";
        this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Note Manager - [Tag or Project Name]";
        ((System.ComponentModel.ISupportInitialize)(this.barStatus)).EndInit();
        this.gbStoredNotes.ResumeLayout(false);
        this.gbSelectedNote.ResumeLayout(false);
        this.gbSelectedNote.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ItemPanel ipIntro;
    private DevComponents.DotNetBar.Bar barStatus;
    private DevComponents.DotNetBar.LabelItem liStatus;
    private DevComponents.DotNetBar.LabelItem liIntro;
    private System.Windows.Forms.ListBox lbNotes;
    private System.Windows.Forms.GroupBox gbStoredNotes;
    private DevComponents.DotNetBar.ButtonX bxNewNote;
    private DevComponents.DotNetBar.ButtonX bxEditNote;
    private DevComponents.DotNetBar.ButtonX bxDeleteNote;
    private DevComponents.DotNetBar.ButtonX bxSaveNotes;
    private System.Windows.Forms.TextBox txtbNoteName;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtbNoteContents;
    private System.Windows.Forms.GroupBox gbSelectedNote;
  }
}