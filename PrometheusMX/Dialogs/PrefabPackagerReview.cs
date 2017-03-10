using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Dialogs
{
  public partial class PrefabPackagerReview : Prometheus.Controls.FloatingPanel
  {
    private bool recommendedSettings = false;

    public PrefabPackagerReview(bool customTags, bool security, bool recoveryPassword,
                                bool passwordStored, bool authorInfo, bool reportPrefab,
                                bool allowDownload, bool customImage)
    {
      InitializeComponent();

      // Using Custom Tags Only?
      if (customTags)
      {
        lblCustomTagsOnlyValue.Text = "Yes";
        lblCustomTagsOnlyValue.ForeColor = Color.DarkGreen;
        pbCustomTagsOnly.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbCustomTagsOnly, new DevComponents.DotNetBar.SuperTooltipInfo("Custom Tags Only", "", "The prefab contains only modified tags and references the inherited tags. This" +
                    " helps to keep prefab file size small.", null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblCustomTagsOnlyValue.Text = "No";
        lblCustomTagsOnlyValue.ForeColor = Color.DarkRed;
        pbCustomTagsOnly.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbCustomTagsOnly, new DevComponents.DotNetBar.SuperTooltipInfo("All Tags", "", "The prefab contains all tags necessary to build it. This typically makes" +
                    " prefab file size much larger than it has to be.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }

      // Security Enabled?
      if (security)
      {
        lblSecurityValue.Text = "On";
        lblSecurityValue.ForeColor = Color.DarkGreen;
        pbSecurity.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbSecurity, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Enabled", "", "The prefab is protected from access by users.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));

      }
      else
      {
        lblSecurityValue.Text = "Off";
        lblSecurityValue.ForeColor = Color.DarkRed;
        pbSecurity.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbSecurity, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Disabled", "", "The contents of this prefab may be accessed by anyone.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }

      // Recovery Password Set?
      if (recoveryPassword)
      {
        lblRecoveryPasswordValue.Text = "Set";
        lblRecoveryPasswordValue.ForeColor = Color.DarkGreen;
        pbRecoveryPassword.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbRecoveryPassword, new DevComponents.DotNetBar.SuperTooltipInfo("Recovery Password Set", "", "A recovery password is set. It can be used to access prefab" +
                    " tags for recovery, if necessary.", null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblRecoveryPasswordValue.Text = "None";
        lblRecoveryPasswordValue.ForeColor = Color.DarkRed;
        pbRecoveryPassword.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbRecoveryPassword, new DevComponents.DotNetBar.SuperTooltipInfo("Recovery Password Not Set", "", "No recovery password is set. The prefab tags can never" +
                    " be recovered.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }
      // Handle display of recoveryPassword based on the value of security.
      lblRecoveryPassword.Enabled = security;
      if(!security)
        lblRecoveryPassword.Text = "Recovery Password";
      lblRecoveryPasswordValue.Visible = security;
      pbRecoveryPassword.Enabled = security;

      // Recovery Password Stored?
      if (passwordStored)
      {
        lblPasswordStoredValue.Text = "Yes";
        lblPasswordStoredValue.ForeColor = Color.DarkGreen;
        pbPasswordStored.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbPasswordStored, new DevComponents.DotNetBar.SuperTooltipInfo("Password Stored Locally", "", "The recovery password has been stored locally. The prefab" +
                    " tags will always be recoverable from this Prometheus installation.", null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblPasswordStoredValue.Text = "No";
        lblPasswordStoredValue.ForeColor = Color.DarkRed;
        pbPasswordStored.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbPasswordStored, new DevComponents.DotNetBar.SuperTooltipInfo("Password Not Stored", "", "The recovery password is not stored locally. If the password is" +
                    " forgotten, the prefab tags can never be recovered.", null, null, DevComponents.DotNetBar.eTooltipColor.Yellow, true, false, new Size(0, 0)));
      }
      // Handle display of passwordStored based on the value of recoveryPassword.
      lblPasswordStored.Enabled = recoveryPassword;
      if (!recoveryPassword)
        lblPasswordStored.Text = "Password Stored";
      lblPasswordStoredValue.Visible = recoveryPassword;
      pbPasswordStored.Enabled = recoveryPassword;

      // Author Info Included?
      if (authorInfo)
      {
        lblAuthorInfoValue.Text = "Included";
        lblAuthorInfoValue.ForeColor = Color.DarkGreen;
        pbAuthorInfo.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbAuthorInfo, new DevComponents.DotNetBar.SuperTooltipInfo("Author Information Included", "", "The prefab will contain individually identifiable author information.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblAuthorInfoValue.Text = "Not Included";
        lblAuthorInfoValue.ForeColor = Color.DarkRed;
        pbAuthorInfo.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbAuthorInfo, new DevComponents.DotNetBar.SuperTooltipInfo("Author Information Not Included", "", "The prefab will contain no author information. This means proof of" +
                    " authorship does not exist.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }

      // Prefab Will Be Reported?
      if (reportPrefab)
      {
        lblReportPrefabValue.Text = "Yes";
        lblReportPrefabValue.ForeColor = Color.DarkGreen;
        pbReportPrefab.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbReportPrefab, new DevComponents.DotNetBar.SuperTooltipInfo("Prefab Will Be Reported", "", "The prefab will be reported to the HaloDev Prefab Database, browsable by users.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblReportPrefabValue.Text = "No";
        lblReportPrefabValue.ForeColor = Color.DarkRed;
        pbReportPrefab.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbReportPrefab, new DevComponents.DotNetBar.SuperTooltipInfo("Prefab Will Not Be Reported", "", "The prefab will not be reported to the HaloDev Prefab Database. The database" +
                    " acts as an information repository for published prefabs and submission is recommended.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }

      // Prefab Will Be Uploaded?
      if (allowDownload)
      {
        lblAllowDownloadsValue.Text = "Yes";
        lblAllowDownloadsValue.ForeColor = Color.DarkGreen;
        pbAllowDownloads.Image = global::Prometheus.Properties.Resources.information16;
        this.stReview.SetSuperTooltip(this.pbAllowDownloads, new DevComponents.DotNetBar.SuperTooltipInfo("Prefab Will Be Uploaded", "", "After creation, the prefab will be uploaded to the HaloDev Prefab Database and be" +
                    " downloadable by users.", null, null, DevComponents.DotNetBar.eTooltipColor.Blue, true, false, new Size(0, 0)));
      }
      else
      {
        lblAllowDownloadsValue.Text = "No";
        lblAllowDownloadsValue.ForeColor = Color.DarkRed;
        pbAllowDownloads.Image = global::Prometheus.Properties.Resources.warning16;
        this.stReview.SetSuperTooltip(this.pbAllowDownloads, new DevComponents.DotNetBar.SuperTooltipInfo("Prefab Will Not Be Uploaded", "", "The prefab will not be uploaded to the HaloDev Prefab Database. Users will be" +
                    " able to read about your prefab, but unable to download it.", null, null, DevComponents.DotNetBar.eTooltipColor.Yellow, true, false, new Size(0, 0)));
      }
      // Handle display of allowDownload based on the value of reportPrefab.
      lblAllowDownloads.Enabled = reportPrefab;
      if (!reportPrefab)
        lblAllowDownloads.Text = "Allow Downloads";
      lblAllowDownloadsValue.Visible = reportPrefab;
      pbAllowDownloads.Enabled = reportPrefab;

      // Using Custom Tags Only?
      if (customImage)
      {
        lblCustomImageValue.Text = "Yes";
        lblCustomImageValue.ForeColor = Color.DarkGreen;
        pbCustomImage.Image = global::Prometheus.Properties.Resources.check16;
        this.stReview.SetSuperTooltip(this.pbCustomImage, new DevComponents.DotNetBar.SuperTooltipInfo("Custom Image", "", "The prefab image has been manually selected.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        lblCustomImageValue.Text = "No";
        lblCustomImageValue.ForeColor = Color.DarkRed;
        pbCustomImage.Image = global::Prometheus.Properties.Resources.error16;
        this.stReview.SetSuperTooltip(this.pbCustomImage, new DevComponents.DotNetBar.SuperTooltipInfo("Automatically Generated Image", "", "The prefab image will be automatically generated. The image generated will not" +
                    " represent the prefab as well as a custom image.<br /><br />Once the prefab is created, the image <b>cannot</b> be changed.", null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }

      recommendedSettings = customTags && security && recoveryPassword && passwordStored && authorInfo && reportPrefab && allowDownload && customImage;
    }

    // Focus must occur outside of instantiation to work.
    private void PrefabPackagerReview_Shown(object sender, EventArgs e)
    {
      // If the user has set all of the recommended settings, give creation focus.
      if (recommendedSettings)
        bxCreate.Focus();
      else // If not, suggest they modify by giving modification focus.
        bxModify.Focus();
    }

    private void Collapse(object sender, EventArgs e)
    {
      expBody.Expanded = false;
    }
  }
}

