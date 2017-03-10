namespace Prometheus.Dialogs
{
  partial class RadiosityOptions
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadiosityOptions));
      this.ipProfileSetup = new DevComponents.DotNetBar.ItemPanel();
      this.icProfile = new DevComponents.DotNetBar.ItemContainer();
      this.liRadiosityProfile = new DevComponents.DotNetBar.LabelItem();
      this.icProfileOptions = new DevComponents.DotNetBar.ItemContainer();
      this.biProfile = new DevComponents.DotNetBar.ButtonItem();
      this.liProjectProfiles = new DevComponents.DotNetBar.LabelItem();
      this.biProjectProfile1 = new DevComponents.DotNetBar.ButtonItem();
      this.liGlobalProfiles = new DevComponents.DotNetBar.LabelItem();
      this.biGlobalProfile1 = new DevComponents.DotNetBar.ButtonItem();
      this.biGlobalProfileDefaultProfile = new DevComponents.DotNetBar.ButtonItem();
      this.biProfileOptionsSave = new DevComponents.DotNetBar.ButtonItem();
      this.biProfileOptionsDelete = new DevComponents.DotNetBar.ButtonItem();
      this.icProfileName = new DevComponents.DotNetBar.ItemContainer();
      this.tbiProfileName = new DevComponents.DotNetBar.TextBoxItem();
      this.bxRadiosityHide = new DevComponents.DotNetBar.ButtonX();
      this.bxRadiosityCancel = new DevComponents.DotNetBar.ButtonX();
      this.m_runRadiosityBtn = new DevComponents.DotNetBar.ButtonX();
      this.stRadiosityOptions = new DevComponents.DotNetBar.SuperTooltip();
      this.gpTextureGeneration = new DevComponents.DotNetBar.Controls.GroupPanel();
      this.cboxxRealtimePreview = new DevComponents.DotNetBar.Controls.CheckBoxX();
      this.cboxxTextureGenerationTmo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
      this.ciTextureGenerationTmoReinhard = new DevComponents.Editors.ComboItem();
      this.lblTextureGenerationTmo = new System.Windows.Forms.Label();
      this.lblTextureGenerationSaturationAlgo = new System.Windows.Forms.Label();
      this.cboxxTextureGenerationSaturationAlgo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
      this.ciTextureGenerationSaturationAlgoSceneMax = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationSaturationAlgoSceneMean3 = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationSaturationAlgoSceneMean2 = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationSaturationAlgoSceneMean1 = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationFilterAlgoNone = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationFilterAlgo3x3 = new DevComponents.Editors.ComboItem();
      this.ciTextureGenerationFilterAlgo5x5 = new DevComponents.Editors.ComboItem();
      this.gpPhotonMapping = new DevComponents.DotNetBar.Controls.GroupPanel();
      this.panDefaultDiffuseColorSelected = new System.Windows.Forms.Panel();
      this.ipDefaultDiffuseHost = new DevComponents.DotNetBar.ItemPanel();
      this.cpddPhotonMappingDefaultDiffuse = new DevComponents.DotNetBar.ColorPickerDropDown();
      this.lblPhotonMappingBounceLimit = new System.Windows.Forms.Label();
      this.m_bounceLimit = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lblPhotonMappingTexelRadius = new System.Windows.Forms.Label();
      this.m_texelRadius = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lblPhotonMappingPhotonCount = new System.Windows.Forms.Label();
      this.m_photonCount = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.gpAutoSaveOptions = new DevComponents.DotNetBar.Controls.GroupPanel();
      this.txtxAutoSaveOptionsKeepCount = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.txtxAutoSaveOptionsSaveRate = new DevComponents.DotNetBar.Controls.TextBoxX();
      this.lblAutoSaveOptionsKeepCountBackups = new System.Windows.Forms.Label();
      this.lblAutoSaveOptionsKeepCount = new System.Windows.Forms.Label();
      this.lblAutoSaveOptionsSaveRateMinutes = new System.Windows.Forms.Label();
      this.lblAutoSaveOptionsSaveRate = new System.Windows.Forms.Label();
      this.cboxxAutoSaveOptionsEnabled = new DevComponents.DotNetBar.Controls.CheckBoxX();
      this.cboxxAlwaysShowDialog = new DevComponents.DotNetBar.Controls.CheckBoxX();
      this.cboxxProfileGlobal = new DevComponents.DotNetBar.Controls.CheckBoxX();
      this.gpTextureGeneration.SuspendLayout();
      this.gpPhotonMapping.SuspendLayout();
      this.gpAutoSaveOptions.SuspendLayout();
      this.SuspendLayout();
      // 
      // ipProfileSetup
      // 
      this.ipProfileSetup.AutoScroll = true;
      this.ipProfileSetup.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ipProfileSetup.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.ipProfileSetup.BackgroundStyle.PaddingBottom = 1;
      this.ipProfileSetup.BackgroundStyle.PaddingLeft = 1;
      this.ipProfileSetup.BackgroundStyle.PaddingRight = 1;
      this.ipProfileSetup.BackgroundStyle.PaddingTop = 1;
      this.ipProfileSetup.Dock = System.Windows.Forms.DockStyle.Top;
      this.ipProfileSetup.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icProfile,
            this.icProfileName});
      this.ipProfileSetup.GetType();
      this.ipProfileSetup.Location = new System.Drawing.Point(0, 0);
      this.ipProfileSetup.Name = "ipProfileSetup";
      this.ipProfileSetup.Size = new System.Drawing.Size(357, 42);
      this.ipProfileSetup.TabIndex = 0;
      // 
      // icProfile
      // 
      // 
      // 
      // 
      this.icProfile.BackgroundStyle.MarginTop = 4;
      this.icProfile.BackgroundStyle.PaddingLeft = 3;
      this.icProfile.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.icProfile.MinimumSize = new System.Drawing.Size(0, 0);
      this.icProfile.Name = "icProfile";
      this.icProfile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liRadiosityProfile,
            this.icProfileOptions});
      // 
      // liRadiosityProfile
      // 
      this.liRadiosityProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.liRadiosityProfile.Name = "liRadiosityProfile";
      this.liRadiosityProfile.PaddingLeft = 3;
      this.liRadiosityProfile.Text = "Profile:";
      // 
      // icProfileOptions
      // 
      // 
      // 
      // 
      this.icProfileOptions.BackgroundStyle.MarginLeft = 3;
      this.icProfileOptions.MinimumSize = new System.Drawing.Size(0, 0);
      this.icProfileOptions.Name = "icProfileOptions";
      this.icProfileOptions.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.biProfile,
            this.biProfileOptionsSave,
            this.biProfileOptionsDelete});
      // 
      // biProfile
      // 
      this.biProfile.AutoExpandOnClick = true;
      this.biProfile.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
      this.biProfile.FixedSize = new System.Drawing.Size(120, 20);
      this.biProfile.ImagePaddingHorizontal = 8;
      this.biProfile.ImagePaddingVertical = 3;
      this.biProfile.Name = "biProfile";
      this.biProfile.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.liProjectProfiles,
            this.biProjectProfile1,
            this.liGlobalProfiles,
            this.biGlobalProfile1,
            this.biGlobalProfileDefaultProfile});
      this.biProfile.Text = "Default Settings";
      // 
      // liProjectProfiles
      // 
      this.liProjectProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
      this.liProjectProfiles.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
      this.liProjectProfiles.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.liProjectProfiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
      this.liProjectProfiles.Name = "liProjectProfiles";
      this.liProjectProfiles.PaddingBottom = 1;
      this.liProjectProfiles.PaddingLeft = 10;
      this.liProjectProfiles.PaddingTop = 1;
      this.liProjectProfiles.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
      this.liProjectProfiles.Text = "Project Profiles";
      // 
      // biProjectProfile1
      // 
      this.biProjectProfile1.ImagePaddingHorizontal = 8;
      this.biProjectProfile1.Name = "biProjectProfile1";
      this.biProjectProfile1.Text = "Night Pass (SAMPLE)";
      this.biProjectProfile1.Click += new System.EventHandler(this.tbiProfileNameToggle);
      // 
      // liGlobalProfiles
      // 
      this.liGlobalProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(231)))), ((int)(((byte)(238)))));
      this.liGlobalProfiles.BorderSide = DevComponents.DotNetBar.eBorderSide.Bottom;
      this.liGlobalProfiles.BorderType = DevComponents.DotNetBar.eBorderType.SingleLine;
      this.liGlobalProfiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(21)))), ((int)(((byte)(110)))));
      this.liGlobalProfiles.Name = "liGlobalProfiles";
      this.liGlobalProfiles.PaddingBottom = 1;
      this.liGlobalProfiles.PaddingLeft = 10;
      this.liGlobalProfiles.PaddingTop = 1;
      this.liGlobalProfiles.SingleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
      this.liGlobalProfiles.Text = "Global Profiles";
      // 
      // biGlobalProfile1
      // 
      this.biGlobalProfile1.ImagePaddingHorizontal = 8;
      this.biGlobalProfile1.Name = "biGlobalProfile1";
      this.biGlobalProfile1.Text = "Perfect Settings (SAMPLE)";
      this.biGlobalProfile1.Click += new System.EventHandler(this.tbiProfileNameToggle);
      // 
      // biGlobalProfileDefaultProfile
      // 
      this.biGlobalProfileDefaultProfile.BeginGroup = true;
      this.biGlobalProfileDefaultProfile.ImagePaddingHorizontal = 8;
      this.biGlobalProfileDefaultProfile.Name = "biGlobalProfileDefaultProfile";
      this.biGlobalProfileDefaultProfile.Text = "Default Settings";
      this.biGlobalProfileDefaultProfile.Click += new System.EventHandler(this.tbiProfileNameToggle);
      // 
      // biProfileOptionsSave
      // 
      this.biProfileOptionsSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
      this.biProfileOptionsSave.Image = global::Prometheus.Properties.Resources.disk_blue16;
      this.biProfileOptionsSave.ImagePaddingHorizontal = 8;
      this.biProfileOptionsSave.ImagePaddingVertical = 3;
      this.biProfileOptionsSave.Name = "biProfileOptionsSave";
      // 
      // biProfileOptionsDelete
      // 
      this.biProfileOptionsDelete.Image = global::Prometheus.Properties.Resources.delete216;
      this.biProfileOptionsDelete.ImagePaddingHorizontal = 8;
      this.biProfileOptionsDelete.ImagePaddingVertical = 3;
      this.biProfileOptionsDelete.Name = "biProfileOptionsDelete";
      this.biProfileOptionsDelete.Text = "buttonItem2";
      // 
      // icProfileName
      // 
      // 
      // 
      // 
      this.icProfileName.BackgroundStyle.MarginTop = 18;
      this.icProfileName.MinimumSize = new System.Drawing.Size(0, 0);
      this.icProfileName.Name = "icProfileName";
      this.icProfileName.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbiProfileName});
      // 
      // tbiProfileName
      // 
      this.tbiProfileName.AlwaysShowCaption = true;
      this.tbiProfileName.ControlText = "";
      this.tbiProfileName.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
      this.tbiProfileName.Name = "tbiProfileName";
      this.tbiProfileName.RecentlyUsed = false;
      this.tbiProfileName.SelectionLength = 0;
      this.tbiProfileName.SelectionStart = 0;
      this.tbiProfileName.Text = "Name";
      this.tbiProfileName.TextBoxWidth = 127;
      // 
      // bxRadiosityHide
      // 
      this.bxRadiosityHide.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.bxRadiosityHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bxRadiosityHide.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.bxRadiosityHide.Image = global::Prometheus.Properties.Resources.ghost16;
      this.bxRadiosityHide.Location = new System.Drawing.Point(94, 319);
      this.bxRadiosityHide.Name = "bxRadiosityHide";
      this.bxRadiosityHide.Size = new System.Drawing.Size(75, 23);
      this.bxRadiosityHide.TabIndex = 2;
      this.bxRadiosityHide.Text = "Hide";
      this.bxRadiosityHide.Click += new System.EventHandler(this.HideClick);
      // 
      // bxRadiosityCancel
      // 
      this.bxRadiosityCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.bxRadiosityCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.bxRadiosityCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
      this.bxRadiosityCancel.Location = new System.Drawing.Point(277, 319);
      this.bxRadiosityCancel.Name = "bxRadiosityCancel";
      this.bxRadiosityCancel.Size = new System.Drawing.Size(75, 23);
      this.bxRadiosityCancel.TabIndex = 3;
      this.bxRadiosityCancel.Text = "Cancel";
      this.bxRadiosityCancel.Click += new System.EventHandler(this.CancelClick);
      // 
      // m_runRadiosityBtn
      // 
      this.m_runRadiosityBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.m_runRadiosityBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.m_runRadiosityBtn.Image = global::Prometheus.Properties.Resources.lightbulb_on16;
      this.m_runRadiosityBtn.Location = new System.Drawing.Point(4, 319);
      this.m_runRadiosityBtn.Name = "m_runRadiosityBtn";
      this.m_runRadiosityBtn.Size = new System.Drawing.Size(75, 23);
      this.m_runRadiosityBtn.TabIndex = 4;
      this.m_runRadiosityBtn.Text = "Run";
      this.m_runRadiosityBtn.Click += new System.EventHandler(this.RunRadiosity);
      // 
      // stRadiosityOptions
      // 
      this.stRadiosityOptions.DefaultFont = new System.Drawing.Font("Tahoma", 8.25F);
      this.stRadiosityOptions.GetType();
      this.stRadiosityOptions.MinimumTooltipSize = new System.Drawing.Size(150, 50);
      this.stRadiosityOptions.TooltipDuration = 0;
      // 
      // gpTextureGeneration
      // 
      this.gpTextureGeneration.CanvasColor = System.Drawing.SystemColors.Control;
      this.gpTextureGeneration.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.gpTextureGeneration.Controls.Add(this.cboxxRealtimePreview);
      this.gpTextureGeneration.Controls.Add(this.cboxxTextureGenerationTmo);
      this.gpTextureGeneration.Controls.Add(this.lblTextureGenerationTmo);
      this.gpTextureGeneration.Controls.Add(this.lblTextureGenerationSaturationAlgo);
      this.gpTextureGeneration.Controls.Add(this.cboxxTextureGenerationSaturationAlgo);
      this.gpTextureGeneration.Location = new System.Drawing.Point(4, 156);
      this.gpTextureGeneration.Name = "gpTextureGeneration";
      this.gpTextureGeneration.Size = new System.Drawing.Size(348, 81);
      // 
      // 
      // 
      this.gpTextureGeneration.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.gpTextureGeneration.Style.BackColorGradientAngle = 90;
      this.gpTextureGeneration.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.gpTextureGeneration.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpTextureGeneration.Style.BorderBottomWidth = 1;
      this.gpTextureGeneration.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.gpTextureGeneration.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpTextureGeneration.Style.BorderLeftWidth = 1;
      this.gpTextureGeneration.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpTextureGeneration.Style.BorderRightWidth = 1;
      this.gpTextureGeneration.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpTextureGeneration.Style.BorderTopWidth = 1;
      this.gpTextureGeneration.Style.CornerDiameter = 4;
      this.gpTextureGeneration.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.gpTextureGeneration.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.gpTextureGeneration.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
      this.gpTextureGeneration.TabIndex = 13;
      this.gpTextureGeneration.Text = "<b>Texture Generation Configuration</b>";
      // 
      // cboxxRealtimePreview
      // 
      this.cboxxRealtimePreview.BackColor = System.Drawing.Color.Transparent;
      this.cboxxRealtimePreview.Checked = true;
      this.cboxxRealtimePreview.Location = new System.Drawing.Point(223, 26);
      this.cboxxRealtimePreview.Name = "cboxxRealtimePreview";
      this.cboxxRealtimePreview.Size = new System.Drawing.Size(116, 23);
      this.cboxxRealtimePreview.TabIndex = 19;
      this.cboxxRealtimePreview.Text = "Realtime Preview";
      // 
      // cboxxTextureGenerationTmo
      // 
      this.cboxxTextureGenerationTmo.DisplayMember = "Text";
      this.cboxxTextureGenerationTmo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cboxxTextureGenerationTmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboxxTextureGenerationTmo.FormattingEnabled = true;
      this.cboxxTextureGenerationTmo.Items.AddRange(new object[] {
            this.ciTextureGenerationTmoReinhard});
      this.cboxxTextureGenerationTmo.Location = new System.Drawing.Point(130, 28);
      this.cboxxTextureGenerationTmo.Name = "cboxxTextureGenerationTmo";
      this.cboxxTextureGenerationTmo.Size = new System.Drawing.Size(81, 21);
      this.cboxxTextureGenerationTmo.TabIndex = 12;
      this.cboxxTextureGenerationTmo.WatermarkText = "Reinhard";
      // 
      // ciTextureGenerationTmoReinhard
      // 
      this.ciTextureGenerationTmoReinhard.Text = "Reinhard";
      // 
      // lblTextureGenerationTmo
      // 
      this.lblTextureGenerationTmo.AutoSize = true;
      this.lblTextureGenerationTmo.BackColor = System.Drawing.Color.Transparent;
      this.lblTextureGenerationTmo.Location = new System.Drawing.Point(5, 32);
      this.lblTextureGenerationTmo.Name = "lblTextureGenerationTmo";
      this.lblTextureGenerationTmo.Size = new System.Drawing.Size(120, 13);
      this.lblTextureGenerationTmo.TabIndex = 9;
      this.lblTextureGenerationTmo.Text = "Tone Mapping Operator";
      // 
      // lblTextureGenerationSaturationAlgo
      // 
      this.lblTextureGenerationSaturationAlgo.AutoSize = true;
      this.lblTextureGenerationSaturationAlgo.BackColor = System.Drawing.Color.Transparent;
      this.lblTextureGenerationSaturationAlgo.Location = new System.Drawing.Point(5, 9);
      this.lblTextureGenerationSaturationAlgo.Name = "lblTextureGenerationSaturationAlgo";
      this.lblTextureGenerationSaturationAlgo.Size = new System.Drawing.Size(101, 13);
      this.lblTextureGenerationSaturationAlgo.TabIndex = 7;
      this.lblTextureGenerationSaturationAlgo.Text = "Saturation Algorithm";
      // 
      // cboxxTextureGenerationSaturationAlgo
      // 
      this.cboxxTextureGenerationSaturationAlgo.DisplayMember = "Text";
      this.cboxxTextureGenerationSaturationAlgo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cboxxTextureGenerationSaturationAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cboxxTextureGenerationSaturationAlgo.FormattingEnabled = true;
      this.cboxxTextureGenerationSaturationAlgo.Items.AddRange(new object[] {
            this.ciTextureGenerationSaturationAlgoSceneMax,
            this.ciTextureGenerationSaturationAlgoSceneMean3,
            this.ciTextureGenerationSaturationAlgoSceneMean2,
            this.ciTextureGenerationSaturationAlgoSceneMean1});
      this.cboxxTextureGenerationSaturationAlgo.Location = new System.Drawing.Point(130, 1);
      this.cboxxTextureGenerationSaturationAlgo.Name = "cboxxTextureGenerationSaturationAlgo";
      this.cboxxTextureGenerationSaturationAlgo.Size = new System.Drawing.Size(81, 21);
      this.cboxxTextureGenerationSaturationAlgo.TabIndex = 10;
      this.cboxxTextureGenerationSaturationAlgo.WatermarkText = "Scene Max";
      // 
      // ciTextureGenerationSaturationAlgoSceneMax
      // 
      this.ciTextureGenerationSaturationAlgoSceneMax.Text = "Scene Max";
      // 
      // ciTextureGenerationSaturationAlgoSceneMean3
      // 
      this.ciTextureGenerationSaturationAlgoSceneMean3.Text = "Mean + 3";
      // 
      // ciTextureGenerationSaturationAlgoSceneMean2
      // 
      this.ciTextureGenerationSaturationAlgoSceneMean2.Text = "Mean + 2";
      // 
      // ciTextureGenerationSaturationAlgoSceneMean1
      // 
      this.ciTextureGenerationSaturationAlgoSceneMean1.Text = "Mean + 1";
      // 
      // ciTextureGenerationFilterAlgoNone
      // 
      this.ciTextureGenerationFilterAlgoNone.Text = "None";
      // 
      // ciTextureGenerationFilterAlgo3x3
      // 
      this.ciTextureGenerationFilterAlgo3x3.Text = "3x3 Gaussian";
      // 
      // ciTextureGenerationFilterAlgo5x5
      // 
      this.ciTextureGenerationFilterAlgo5x5.Text = "5x5 Gaussian";
      // 
      // gpPhotonMapping
      // 
      this.gpPhotonMapping.CanvasColor = System.Drawing.SystemColors.Control;
      this.gpPhotonMapping.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.gpPhotonMapping.Controls.Add(this.panDefaultDiffuseColorSelected);
      this.gpPhotonMapping.Controls.Add(this.ipDefaultDiffuseHost);
      this.gpPhotonMapping.Controls.Add(this.lblPhotonMappingBounceLimit);
      this.gpPhotonMapping.Controls.Add(this.m_bounceLimit);
      this.gpPhotonMapping.Controls.Add(this.lblPhotonMappingTexelRadius);
      this.gpPhotonMapping.Controls.Add(this.m_texelRadius);
      this.gpPhotonMapping.Controls.Add(this.lblPhotonMappingPhotonCount);
      this.gpPhotonMapping.Controls.Add(this.m_photonCount);
      this.gpPhotonMapping.Location = new System.Drawing.Point(4, 64);
      this.gpPhotonMapping.Name = "gpPhotonMapping";
      this.gpPhotonMapping.Size = new System.Drawing.Size(348, 86);
      // 
      // 
      // 
      this.gpPhotonMapping.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.gpPhotonMapping.Style.BackColorGradientAngle = 90;
      this.gpPhotonMapping.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.gpPhotonMapping.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpPhotonMapping.Style.BorderBottomWidth = 1;
      this.gpPhotonMapping.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.gpPhotonMapping.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpPhotonMapping.Style.BorderLeftWidth = 1;
      this.gpPhotonMapping.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpPhotonMapping.Style.BorderRightWidth = 1;
      this.gpPhotonMapping.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpPhotonMapping.Style.BorderTopWidth = 1;
      this.gpPhotonMapping.Style.CornerDiameter = 4;
      this.gpPhotonMapping.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.gpPhotonMapping.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.gpPhotonMapping.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
      this.gpPhotonMapping.TabIndex = 14;
      this.gpPhotonMapping.Text = "<b>Photon Mapping Configuration</b>";
      // 
      // panDefaultDiffuseColorSelected
      // 
      this.panDefaultDiffuseColorSelected.BackColor = System.Drawing.Color.White;
      this.panDefaultDiffuseColorSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panDefaultDiffuseColorSelected.Location = new System.Drawing.Point(310, 30);
      this.panDefaultDiffuseColorSelected.Name = "panDefaultDiffuseColorSelected";
      this.panDefaultDiffuseColorSelected.Size = new System.Drawing.Size(24, 21);
      this.panDefaultDiffuseColorSelected.TabIndex = 0;
      // 
      // ipDefaultDiffuseHost
      // 
      this.ipDefaultDiffuseHost.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ipDefaultDiffuseHost.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.ipDefaultDiffuseHost.BackgroundStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(157)))), ((int)(((byte)(185)))));
      this.ipDefaultDiffuseHost.BackgroundStyle.PaddingBottom = 1;
      this.ipDefaultDiffuseHost.BackgroundStyle.PaddingLeft = 1;
      this.ipDefaultDiffuseHost.BackgroundStyle.PaddingRight = 1;
      this.ipDefaultDiffuseHost.BackgroundStyle.PaddingTop = 1;
      this.ipDefaultDiffuseHost.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cpddPhotonMappingDefaultDiffuse});
      this.ipDefaultDiffuseHost.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.ipDefaultDiffuseHost.GetType();
      this.ipDefaultDiffuseHost.Location = new System.Drawing.Point(176, 28);
      this.ipDefaultDiffuseHost.Name = "ipDefaultDiffuseHost";
      this.ipDefaultDiffuseHost.Size = new System.Drawing.Size(128, 28);
      this.ipDefaultDiffuseHost.TabIndex = 18;
      // 
      // cpddPhotonMappingDefaultDiffuse
      // 
      this.cpddPhotonMappingDefaultDiffuse.AutoExpandOnClick = true;
      this.cpddPhotonMappingDefaultDiffuse.GlobalItem = false;
      this.cpddPhotonMappingDefaultDiffuse.ImagePaddingHorizontal = 8;
      this.cpddPhotonMappingDefaultDiffuse.Name = "cpddPhotonMappingDefaultDiffuse";
      this.cpddPhotonMappingDefaultDiffuse.SplitButton = true;
      this.cpddPhotonMappingDefaultDiffuse.Text = "Default Diffuse Color";
      this.cpddPhotonMappingDefaultDiffuse.SelectedColorChanged += new System.EventHandler(this.cpddPhotonMappingDefaultDiffuse_SelectedColorChanged);
      // 
      // lblPhotonMappingBounceLimit
      // 
      this.lblPhotonMappingBounceLimit.AutoSize = true;
      this.lblPhotonMappingBounceLimit.BackColor = System.Drawing.Color.Transparent;
      this.lblPhotonMappingBounceLimit.Location = new System.Drawing.Point(176, 5);
      this.lblPhotonMappingBounceLimit.Name = "lblPhotonMappingBounceLimit";
      this.lblPhotonMappingBounceLimit.Size = new System.Drawing.Size(68, 13);
      this.lblPhotonMappingBounceLimit.TabIndex = 14;
      this.lblPhotonMappingBounceLimit.Text = "Bounce Limit";
      // 
      // m_bounceLimit
      // 
      // 
      // 
      // 
      this.m_bounceLimit.Border.Class = "TextBoxBorder";
      this.m_bounceLimit.Location = new System.Drawing.Point(254, 2);
      this.m_bounceLimit.MaxLength = 2;
      this.m_bounceLimit.Name = "m_bounceLimit";
      this.m_bounceLimit.Size = new System.Drawing.Size(81, 20);
      this.m_bounceLimit.TabIndex = 13;
      this.m_bounceLimit.WatermarkText = "2";
      this.m_bounceLimit.TextChanged += new System.EventHandler(this.m_bounceLimit_TextChanged);
      // 
      // lblPhotonMappingTexelRadius
      // 
      this.lblPhotonMappingTexelRadius.AutoSize = true;
      this.lblPhotonMappingTexelRadius.BackColor = System.Drawing.Color.Transparent;
      this.lblPhotonMappingTexelRadius.Location = new System.Drawing.Point(7, 32);
      this.lblPhotonMappingTexelRadius.Name = "lblPhotonMappingTexelRadius";
      this.lblPhotonMappingTexelRadius.Size = new System.Drawing.Size(69, 13);
      this.lblPhotonMappingTexelRadius.TabIndex = 12;
      this.lblPhotonMappingTexelRadius.Text = "Texel Radius";
      // 
      // m_texelRadius
      // 
      // 
      // 
      // 
      this.m_texelRadius.Border.Class = "TextBoxBorder";
      this.m_texelRadius.Location = new System.Drawing.Point(85, 29);
      this.m_texelRadius.MaxLength = 5;
      this.m_texelRadius.Name = "m_texelRadius";
      this.m_texelRadius.Size = new System.Drawing.Size(81, 20);
      this.m_texelRadius.TabIndex = 11;
      this.m_texelRadius.WatermarkText = "5";
      this.m_texelRadius.TextChanged += new System.EventHandler(this.m_texelRadius_TextChanged);
      // 
      // lblPhotonMappingPhotonCount
      // 
      this.lblPhotonMappingPhotonCount.AutoSize = true;
      this.lblPhotonMappingPhotonCount.BackColor = System.Drawing.Color.Transparent;
      this.lblPhotonMappingPhotonCount.Location = new System.Drawing.Point(7, 5);
      this.lblPhotonMappingPhotonCount.Name = "lblPhotonMappingPhotonCount";
      this.lblPhotonMappingPhotonCount.Size = new System.Drawing.Size(72, 13);
      this.lblPhotonMappingPhotonCount.TabIndex = 10;
      this.lblPhotonMappingPhotonCount.Text = "Photon Count";
      // 
      // m_photonCount
      // 
      // 
      // 
      // 
      this.m_photonCount.Border.Class = "TextBoxBorder";
      this.m_photonCount.Location = new System.Drawing.Point(85, 2);
      this.m_photonCount.MaxLength = 8;
      this.m_photonCount.Name = "m_photonCount";
      this.m_photonCount.Size = new System.Drawing.Size(81, 20);
      this.m_photonCount.TabIndex = 9;
      this.m_photonCount.WatermarkText = "10000";
      this.m_photonCount.TextChanged += new System.EventHandler(this.m_photonCount_TextChanged);
      // 
      // gpAutoSaveOptions
      // 
      this.gpAutoSaveOptions.CanvasColor = System.Drawing.SystemColors.Control;
      this.gpAutoSaveOptions.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.gpAutoSaveOptions.Controls.Add(this.txtxAutoSaveOptionsKeepCount);
      this.gpAutoSaveOptions.Controls.Add(this.txtxAutoSaveOptionsSaveRate);
      this.gpAutoSaveOptions.Controls.Add(this.lblAutoSaveOptionsKeepCountBackups);
      this.gpAutoSaveOptions.Controls.Add(this.lblAutoSaveOptionsKeepCount);
      this.gpAutoSaveOptions.Controls.Add(this.lblAutoSaveOptionsSaveRateMinutes);
      this.gpAutoSaveOptions.Controls.Add(this.lblAutoSaveOptionsSaveRate);
      this.gpAutoSaveOptions.Controls.Add(this.cboxxAutoSaveOptionsEnabled);
      this.gpAutoSaveOptions.Location = new System.Drawing.Point(4, 243);
      this.gpAutoSaveOptions.Name = "gpAutoSaveOptions";
      this.gpAutoSaveOptions.Size = new System.Drawing.Size(348, 47);
      // 
      // 
      // 
      this.gpAutoSaveOptions.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.gpAutoSaveOptions.Style.BackColorGradientAngle = 90;
      this.gpAutoSaveOptions.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.gpAutoSaveOptions.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpAutoSaveOptions.Style.BorderBottomWidth = 1;
      this.gpAutoSaveOptions.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.gpAutoSaveOptions.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpAutoSaveOptions.Style.BorderLeftWidth = 1;
      this.gpAutoSaveOptions.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpAutoSaveOptions.Style.BorderRightWidth = 1;
      this.gpAutoSaveOptions.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gpAutoSaveOptions.Style.BorderTopWidth = 1;
      this.gpAutoSaveOptions.Style.CornerDiameter = 4;
      this.gpAutoSaveOptions.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.gpAutoSaveOptions.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.gpAutoSaveOptions.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
      this.gpAutoSaveOptions.TabIndex = 16;
      this.gpAutoSaveOptions.Text = "<b>Auto Save Options</b>";
      // 
      // txtxAutoSaveOptionsKeepCount
      // 
      // 
      // 
      // 
      this.txtxAutoSaveOptionsKeepCount.Border.Class = "TextBoxBorder";
      this.txtxAutoSaveOptionsKeepCount.Location = new System.Drawing.Point(246, 0);
      this.txtxAutoSaveOptionsKeepCount.MaxLength = 2;
      this.txtxAutoSaveOptionsKeepCount.Name = "txtxAutoSaveOptionsKeepCount";
      this.txtxAutoSaveOptionsKeepCount.Size = new System.Drawing.Size(23, 20);
      this.txtxAutoSaveOptionsKeepCount.TabIndex = 17;
      this.txtxAutoSaveOptionsKeepCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtxAutoSaveOptionsKeepCount.WatermarkText = "7";
      // 
      // txtxAutoSaveOptionsSaveRate
      // 
      // 
      // 
      // 
      this.txtxAutoSaveOptionsSaveRate.Border.Class = "TextBoxBorder";
      this.txtxAutoSaveOptionsSaveRate.Location = new System.Drawing.Point(145, 0);
      this.txtxAutoSaveOptionsSaveRate.MaxLength = 2;
      this.txtxAutoSaveOptionsSaveRate.Name = "txtxAutoSaveOptionsSaveRate";
      this.txtxAutoSaveOptionsSaveRate.Size = new System.Drawing.Size(23, 20);
      this.txtxAutoSaveOptionsSaveRate.TabIndex = 14;
      this.txtxAutoSaveOptionsSaveRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtxAutoSaveOptionsSaveRate.WatermarkText = "3";
      // 
      // lblAutoSaveOptionsKeepCountBackups
      // 
      this.lblAutoSaveOptionsKeepCountBackups.AutoSize = true;
      this.lblAutoSaveOptionsKeepCountBackups.BackColor = System.Drawing.Color.Transparent;
      this.lblAutoSaveOptionsKeepCountBackups.Location = new System.Drawing.Point(270, 3);
      this.lblAutoSaveOptionsKeepCountBackups.Name = "lblAutoSaveOptionsKeepCountBackups";
      this.lblAutoSaveOptionsKeepCountBackups.Size = new System.Drawing.Size(51, 13);
      this.lblAutoSaveOptionsKeepCountBackups.TabIndex = 19;
      this.lblAutoSaveOptionsKeepCountBackups.Text = "backups.";
      // 
      // lblAutoSaveOptionsKeepCount
      // 
      this.lblAutoSaveOptionsKeepCount.AutoSize = true;
      this.lblAutoSaveOptionsKeepCount.BackColor = System.Drawing.Color.Transparent;
      this.lblAutoSaveOptionsKeepCount.Location = new System.Drawing.Point(215, 3);
      this.lblAutoSaveOptionsKeepCount.Name = "lblAutoSaveOptionsKeepCount";
      this.lblAutoSaveOptionsKeepCount.Size = new System.Drawing.Size(32, 13);
      this.lblAutoSaveOptionsKeepCount.TabIndex = 18;
      this.lblAutoSaveOptionsKeepCount.Text = "Keep";
      // 
      // lblAutoSaveOptionsSaveRateMinutes
      // 
      this.lblAutoSaveOptionsSaveRateMinutes.AutoSize = true;
      this.lblAutoSaveOptionsSaveRateMinutes.BackColor = System.Drawing.Color.Transparent;
      this.lblAutoSaveOptionsSaveRateMinutes.Location = new System.Drawing.Point(169, 3);
      this.lblAutoSaveOptionsSaveRateMinutes.Name = "lblAutoSaveOptionsSaveRateMinutes";
      this.lblAutoSaveOptionsSaveRateMinutes.Size = new System.Drawing.Size(46, 13);
      this.lblAutoSaveOptionsSaveRateMinutes.TabIndex = 16;
      this.lblAutoSaveOptionsSaveRateMinutes.Text = "minutes.";
      // 
      // lblAutoSaveOptionsSaveRate
      // 
      this.lblAutoSaveOptionsSaveRate.AutoSize = true;
      this.lblAutoSaveOptionsSaveRate.BackColor = System.Drawing.Color.Transparent;
      this.lblAutoSaveOptionsSaveRate.Location = new System.Drawing.Point(85, 3);
      this.lblAutoSaveOptionsSaveRate.Name = "lblAutoSaveOptionsSaveRate";
      this.lblAutoSaveOptionsSaveRate.Size = new System.Drawing.Size(61, 13);
      this.lblAutoSaveOptionsSaveRate.TabIndex = 15;
      this.lblAutoSaveOptionsSaveRate.Text = "Save every";
      // 
      // cboxxAutoSaveOptionsEnabled
      // 
      this.cboxxAutoSaveOptionsEnabled.BackColor = System.Drawing.Color.Transparent;
      this.cboxxAutoSaveOptionsEnabled.Checked = true;
      this.cboxxAutoSaveOptionsEnabled.Location = new System.Drawing.Point(10, -3);
      this.cboxxAutoSaveOptionsEnabled.Name = "cboxxAutoSaveOptionsEnabled";
      this.cboxxAutoSaveOptionsEnabled.Size = new System.Drawing.Size(69, 23);
      this.cboxxAutoSaveOptionsEnabled.TabIndex = 13;
      this.cboxxAutoSaveOptionsEnabled.Text = "Enabled";
      this.cboxxAutoSaveOptionsEnabled.CheckedChanged += new System.EventHandler(this.cboxxAutoSaveOptionsEnabled_CheckedChanged);
      // 
      // cboxxAlwaysShowDialog
      // 
      this.cboxxAlwaysShowDialog.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.cboxxAlwaysShowDialog.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.cboxxAlwaysShowDialog.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
      this.cboxxAlwaysShowDialog.Checked = true;
      this.cboxxAlwaysShowDialog.Location = new System.Drawing.Point(4, 296);
      this.cboxxAlwaysShowDialog.Name = "cboxxAlwaysShowDialog";
      this.cboxxAlwaysShowDialog.Size = new System.Drawing.Size(270, 17);
      this.cboxxAlwaysShowDialog.TabIndex = 17;
      this.cboxxAlwaysShowDialog.Text = "Always show this dialog before running radiosity.";
      // 
      // cboxxProfileGlobal
      // 
      this.cboxxProfileGlobal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cboxxProfileGlobal.BackColor = System.Drawing.Color.Transparent;
      this.cboxxProfileGlobal.Checked = true;
      this.cboxxProfileGlobal.Location = new System.Drawing.Point(234, 41);
      this.cboxxProfileGlobal.Name = "cboxxProfileGlobal";
      this.cboxxProfileGlobal.Size = new System.Drawing.Size(118, 17);
      this.cboxxProfileGlobal.TabIndex = 18;
      this.cboxxProfileGlobal.Text = "Make Profile Global";
      // 
      // RadiosityOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.CaptionFont = new System.Drawing.Font("Franklin Gothic Medium", 9.75F);
      this.ClientSize = new System.Drawing.Size(357, 346);
      this.Controls.Add(this.gpAutoSaveOptions);
      this.Controls.Add(this.cboxxProfileGlobal);
      this.Controls.Add(this.gpPhotonMapping);
      this.Controls.Add(this.gpTextureGeneration);
      this.Controls.Add(this.m_runRadiosityBtn);
      this.Controls.Add(this.bxRadiosityCancel);
      this.Controls.Add(this.bxRadiosityHide);
      this.Controls.Add(this.ipProfileSetup);
      this.Controls.Add(this.cboxxAlwaysShowDialog);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(363, 370);
      this.MinimumSize = new System.Drawing.Size(363, 370);
      this.Name = "RadiosityOptions";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Radiosity Options";
      this.Load += new System.EventHandler(this.RadiosityOptions_Load);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadiosityOptions_FormClosing);
      this.gpTextureGeneration.ResumeLayout(false);
      this.gpTextureGeneration.PerformLayout();
      this.gpPhotonMapping.ResumeLayout(false);
      this.gpPhotonMapping.PerformLayout();
      this.gpAutoSaveOptions.ResumeLayout(false);
      this.gpAutoSaveOptions.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevComponents.DotNetBar.ItemPanel ipProfileSetup;
    private DevComponents.DotNetBar.ItemContainer icProfile;
    private DevComponents.DotNetBar.LabelItem liRadiosityProfile;
    private DevComponents.DotNetBar.TextBoxItem tbiProfileName;
    private DevComponents.DotNetBar.ItemContainer icProfileOptions;
    private DevComponents.DotNetBar.ButtonItem biProfileOptionsSave;
    private DevComponents.DotNetBar.ButtonItem biProfileOptionsDelete;
    private DevComponents.DotNetBar.ButtonX bxRadiosityHide;
    private DevComponents.DotNetBar.ButtonX bxRadiosityCancel;
    private DevComponents.DotNetBar.ButtonX m_runRadiosityBtn;
    private DevComponents.DotNetBar.ItemContainer icProfileName;
    private DevComponents.DotNetBar.SuperTooltip stRadiosityOptions;
    private DevComponents.DotNetBar.ButtonItem biProfile;
    private DevComponents.DotNetBar.ButtonItem biGlobalProfile1;
    private DevComponents.DotNetBar.ButtonItem biProjectProfile1;
    private DevComponents.DotNetBar.LabelItem liProjectProfiles;
    private DevComponents.DotNetBar.LabelItem liGlobalProfiles;
    private DevComponents.DotNetBar.Controls.GroupPanel gpTextureGeneration;
    private DevComponents.DotNetBar.Controls.ComboBoxEx cboxxTextureGenerationSaturationAlgo;
      private System.Windows.Forms.Label lblTextureGenerationTmo;
    private System.Windows.Forms.Label lblTextureGenerationSaturationAlgo;
      private DevComponents.DotNetBar.Controls.ComboBoxEx cboxxTextureGenerationTmo;
      private DevComponents.DotNetBar.Controls.GroupPanel gpPhotonMapping;
    private System.Windows.Forms.Label lblPhotonMappingBounceLimit;
    private DevComponents.DotNetBar.Controls.TextBoxX m_bounceLimit;
    private System.Windows.Forms.Label lblPhotonMappingTexelRadius;
    private DevComponents.DotNetBar.Controls.TextBoxX m_texelRadius;
    private System.Windows.Forms.Label lblPhotonMappingPhotonCount;
    private DevComponents.DotNetBar.Controls.TextBoxX m_photonCount;
    private DevComponents.Editors.ComboItem ciTextureGenerationSaturationAlgoSceneMax;
    private DevComponents.Editors.ComboItem ciTextureGenerationSaturationAlgoSceneMean3;
    private DevComponents.Editors.ComboItem ciTextureGenerationSaturationAlgoSceneMean2;
    private DevComponents.Editors.ComboItem ciTextureGenerationSaturationAlgoSceneMean1;
    private DevComponents.Editors.ComboItem ciTextureGenerationTmoReinhard;
    private DevComponents.Editors.ComboItem ciTextureGenerationFilterAlgoNone;
    private DevComponents.Editors.ComboItem ciTextureGenerationFilterAlgo3x3;
      private DevComponents.Editors.ComboItem ciTextureGenerationFilterAlgo5x5;
    private DevComponents.DotNetBar.ButtonItem biGlobalProfileDefaultProfile;
    private DevComponents.DotNetBar.Controls.GroupPanel gpAutoSaveOptions;
    private DevComponents.DotNetBar.Controls.CheckBoxX cboxxAutoSaveOptionsEnabled;
    private System.Windows.Forms.Label lblAutoSaveOptionsSaveRateMinutes;
    private System.Windows.Forms.Label lblAutoSaveOptionsSaveRate;
    private DevComponents.DotNetBar.Controls.TextBoxX txtxAutoSaveOptionsSaveRate;
    private System.Windows.Forms.Label lblAutoSaveOptionsKeepCountBackups;
    private System.Windows.Forms.Label lblAutoSaveOptionsKeepCount;
    private DevComponents.DotNetBar.Controls.TextBoxX txtxAutoSaveOptionsKeepCount;
    private DevComponents.DotNetBar.Controls.CheckBoxX cboxxAlwaysShowDialog;
    private DevComponents.DotNetBar.Controls.CheckBoxX cboxxProfileGlobal;
    private DevComponents.DotNetBar.ItemPanel ipDefaultDiffuseHost;
    private DevComponents.DotNetBar.ColorPickerDropDown cpddPhotonMappingDefaultDiffuse;
      private DevComponents.DotNetBar.Controls.CheckBoxX cboxxRealtimePreview;
    private System.Windows.Forms.Panel panDefaultDiffuseColorSelected;

  }
}