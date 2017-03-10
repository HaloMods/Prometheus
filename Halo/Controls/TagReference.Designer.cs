namespace Games.Halo.Controls
{
  partial class TagReference
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagReference));
      this.btnxReferenceAction = new DevComponents.DotNetBar.ButtonX();
      this.biReferenceActionSelect = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceActionImport = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceActionNew = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceActionClear = new DevComponents.DotNetBar.ButtonItem();
      this.txtbxTagReference = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.stTagReference = new DevComponents.DotNetBar.SuperTooltip();
      this.imgbOpenTag = new Prometheus.Controls.ImageButton();
      this.btnxReferenceTagScope = new DevComponents.DotNetBar.ButtonX();
      this.biReferenceTagScopeAuto = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceTagScopeProject = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceTagScopeUser = new DevComponents.DotNetBar.ButtonItem();
      this.biReferenceTagScopeGame = new DevComponents.DotNetBar.ButtonItem();
      this.panelContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // panelContainer
      // 
      this.panelContainer.Controls.Add(this.txtbxTagReference);
      this.panelContainer.Controls.Add(this.imgbOpenTag);
      this.panelContainer.Controls.Add(this.btnxReferenceTagScope);
      this.panelContainer.Controls.Add(this.btnxReferenceAction);
      this.panelContainer.Size = new System.Drawing.Size(242, 26);
      // 
      // btnxReferenceAction
      // 
      this.btnxReferenceAction.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnxReferenceAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnxReferenceAction.Image = global::Games.Halo.Properties.Resources.view16;
      this.btnxReferenceAction.Location = new System.Drawing.Point(170, 3);
      this.btnxReferenceAction.Name = "btnxReferenceAction";
      this.btnxReferenceAction.Size = new System.Drawing.Size(34, 20);
      this.btnxReferenceAction.SplitButton = true;
      this.btnxReferenceAction.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biReferenceActionSelect,
            this.biReferenceActionImport,
            this.biReferenceActionNew,
            this.biReferenceActionClear});
      this.stTagReference.SetSuperTooltip(this.btnxReferenceAction, new DevComponents.DotNetBar.SuperTooltipInfo("Tag Reference Action", "", resources.GetString("btnxReferenceAction.SuperTooltip"), null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(232, 203)));
      this.btnxReferenceAction.TabIndex = 2;
      this.btnxReferenceAction.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.btnxReferenceAction.Click += new System.EventHandler(this.btnxReferenceAction_Click);
      // 
      // biReferenceActionSelect
      // 
      this.biReferenceActionSelect.GlobalItem = false;
      this.biReferenceActionSelect.Image = global::Games.Halo.Properties.Resources.view16;
      this.biReferenceActionSelect.ImagePaddingHorizontal = 8;
      this.biReferenceActionSelect.Name = "biReferenceActionSelect";
      this.biReferenceActionSelect.Tag = "Select";
      this.biReferenceActionSelect.Text = "&Select Tag";
      this.biReferenceActionSelect.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // biReferenceActionImport
      // 
      this.biReferenceActionImport.GlobalItem = false;
      this.biReferenceActionImport.Image = global::Games.Halo.Properties.Resources.import116;
      this.biReferenceActionImport.ImagePaddingHorizontal = 8;
      this.biReferenceActionImport.Name = "biReferenceActionImport";
      this.biReferenceActionImport.Tag = "Import";
      this.biReferenceActionImport.Text = "&Import From Tag";
      this.biReferenceActionImport.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // biReferenceActionNew
      // 
      this.biReferenceActionNew.BeginGroup = true;
      this.biReferenceActionNew.GlobalItem = false;
      this.biReferenceActionNew.Image = global::Games.Halo.Properties.Resources.form_blue_new16;
      this.biReferenceActionNew.ImagePaddingHorizontal = 8;
      this.biReferenceActionNew.Name = "biReferenceActionNew";
      this.biReferenceActionNew.Tag = "New";
      this.biReferenceActionNew.Text = "&New Tag";
      this.biReferenceActionNew.Click += new System.EventHandler(this.biReferenceActionNew_Click);
      // 
      // biReferenceActionClear
      // 
      this.biReferenceActionClear.GlobalItem = false;
      this.biReferenceActionClear.ImagePaddingHorizontal = 8;
      this.biReferenceActionClear.Name = "biReferenceActionClear";
      this.biReferenceActionClear.Text = "&Clear Selection";
      this.biReferenceActionClear.Click += new System.EventHandler(this.biReferenceActionClear_Click);
      // 
      // txtbxTagReference
      // 
      this.txtbxTagReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      // 
      // 
      // 
      this.txtbxTagReference.Border.Class = "TextBoxBorder";
      this.txtbxTagReference.FocusHighlightColor = System.Drawing.Color.AliceBlue;
      this.txtbxTagReference.FocusHighlightEnabled = true;
      this.txtbxTagReference.ForeColor = System.Drawing.Color.DarkBlue;
      this.txtbxTagReference.Location = new System.Drawing.Point(19, 3);
      this.txtbxTagReference.Name = "txtbxTagReference";
      this.txtbxTagReference.Size = new System.Drawing.Size(147, 20);
      this.txtbxTagReference.TabIndex = 1;
      this.txtbxTagReference.WatermarkColor = System.Drawing.Color.MediumSeaGreen;
      this.txtbxTagReference.WatermarkText = "<font size=\"8\"><b>Reference Not Set</b></font>";
      this.txtbxTagReference.TextChanged += new System.EventHandler(this.txtbTagReference_TextChanged);
      // 
      // stTagReference
      // 
      this.stTagReference.GetType();
      this.stTagReference.MinimumTooltipSize = new System.Drawing.Size(10, 16);
      this.stTagReference.TooltipDuration = 0;
      // 
      // imgbOpenTag
      // 
      this.imgbOpenTag.Enabled = false;
      this.imgbOpenTag.Image = global::Games.Halo.Properties.Resources.form_blue16;
      this.imgbOpenTag.Location = new System.Drawing.Point(0, 5);
      this.imgbOpenTag.Margin = new System.Windows.Forms.Padding(0);
      this.imgbOpenTag.Name = "imgbOpenTag";
      this.imgbOpenTag.Size = new System.Drawing.Size(16, 16);
      this.stTagReference.SetSuperTooltip(this.imgbOpenTag, new DevComponents.DotNetBar.SuperTooltipInfo("Open Tag", "", "", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      this.imgbOpenTag.TabIndex = 4;
      this.imgbOpenTag.Click += new System.EventHandler(this.imgbOpenTag_Click);
      // 
      // btnxReferenceTagScope
      // 
      this.btnxReferenceTagScope.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnxReferenceTagScope.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnxReferenceTagScope.AutoExpandOnClick = true;
      this.btnxReferenceTagScope.Image = global::Games.Halo.Properties.Resources.magic_wand16;
      this.btnxReferenceTagScope.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
      this.btnxReferenceTagScope.Location = new System.Drawing.Point(208, 3);
      this.btnxReferenceTagScope.MaximumSize = new System.Drawing.Size(31, 20);
      this.btnxReferenceTagScope.MinimumSize = new System.Drawing.Size(31, 20);
      this.btnxReferenceTagScope.Name = "btnxReferenceTagScope";
      this.btnxReferenceTagScope.Size = new System.Drawing.Size(31, 20);
      this.btnxReferenceTagScope.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biReferenceTagScopeAuto,
            this.biReferenceTagScopeProject,
            this.biReferenceTagScopeUser,
            this.biReferenceTagScopeGame});
      this.stTagReference.SetSuperTooltip(this.btnxReferenceTagScope, new DevComponents.DotNetBar.SuperTooltipInfo("Tag Source", "", resources.GetString("btnxReferenceTagScope.SuperTooltip"), null, null, DevComponents.DotNetBar.eTooltipColor.System, true, true, new System.Drawing.Size(232, 193)));
      this.btnxReferenceTagScope.TabIndex = 3;
      this.btnxReferenceTagScope.Tag = "Auto";
      // 
      // biReferenceTagScopeAuto
      // 
      this.biReferenceTagScopeAuto.GlobalItem = false;
      this.biReferenceTagScopeAuto.Image = global::Games.Halo.Properties.Resources.magic_wand16;
      this.biReferenceTagScopeAuto.ImagePaddingHorizontal = 8;
      this.biReferenceTagScopeAuto.Name = "biReferenceTagScopeAuto";
      this.biReferenceTagScopeAuto.Tag = "Auto";
      this.biReferenceTagScopeAuto.Text = "&Automatic";
      this.biReferenceTagScopeAuto.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // biReferenceTagScopeProject
      // 
      this.biReferenceTagScopeProject.BeginGroup = true;
      this.biReferenceTagScopeProject.GlobalItem = false;
      this.biReferenceTagScopeProject.Image = global::Games.Halo.Properties.Resources.application16;
      this.biReferenceTagScopeProject.ImagePaddingHorizontal = 8;
      this.biReferenceTagScopeProject.Name = "biReferenceTagScopeProject";
      this.biReferenceTagScopeProject.Tag = "Project";
      this.biReferenceTagScopeProject.Text = "&Project";
      this.biReferenceTagScopeProject.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // biReferenceTagScopeUser
      // 
      this.biReferenceTagScopeUser.GlobalItem = false;
      this.biReferenceTagScopeUser.Image = global::Games.Halo.Properties.Resources.user116;
      this.biReferenceTagScopeUser.ImagePaddingHorizontal = 8;
      this.biReferenceTagScopeUser.Name = "biReferenceTagScopeUser";
      this.biReferenceTagScopeUser.Tag = "User";
      this.biReferenceTagScopeUser.Text = "&User";
      this.biReferenceTagScopeUser.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // biReferenceTagScopeGame
      // 
      this.biReferenceTagScopeGame.GlobalItem = false;
      this.biReferenceTagScopeGame.Image = global::Games.Halo.Properties.Resources.joystick16;
      this.biReferenceTagScopeGame.ImagePaddingHorizontal = 8;
      this.biReferenceTagScopeGame.Name = "biReferenceTagScopeGame";
      this.biReferenceTagScopeGame.Tag = "Game";
      this.biReferenceTagScopeGame.Text = "&Game";
      this.biReferenceTagScopeGame.Click += new System.EventHandler(this.childButtonXItem_Click);
      // 
      // TagReference
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "TagReference";
      this.Size = new System.Drawing.Size(374, 26);
      this.panelContainer.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ButtonX btnxReferenceAction;
    private DevComponents.DotNetBar.ButtonItem biReferenceActionSelect;
    private DevComponents.DotNetBar.ButtonItem biReferenceActionNew;
    private DevComponents.DotNetBar.ButtonItem biReferenceActionImport;
    private DevComponents.DotNetBar.ButtonItem biReferenceActionClear;
    private DevComponents.DotNetBar.ButtonX btnxReferenceTagScope;
    private DevComponents.DotNetBar.ButtonItem biReferenceTagScopeAuto;
    private DevComponents.DotNetBar.ButtonItem biReferenceTagScopeProject;
    private DevComponents.DotNetBar.ButtonItem biReferenceTagScopeUser;
    private DevComponents.DotNetBar.ButtonItem biReferenceTagScopeGame;
    private Prometheus.Controls.ImageButton imgbOpenTag;
    private DevComponents.DotNetBar.Controls.TextBoxX txtbxTagReference;
    private DevComponents.DotNetBar.SuperTooltip stTagReference;
  }
}
