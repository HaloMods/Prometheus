using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Prometheus.Dialogs
{
  public partial class PrefabExport : DevComponents.DotNetBar.Office2007Form
  {
    public PrefabExport()
    {
      InitializeComponent();

      // Add Label to the TitlePanel to fix background color issue.
      expPrefabProtection.Controls.Remove(this.lblProtectionHelpMeChoose);
      expPrefabProtection.TitlePanel.Controls.Add(this.lblProtectionHelpMeChoose);

      // Add pbSuccessImageLarge; initially left out for Designer purposes.
      pxSuccess.Controls.Add(this.pbSuccessImageLarge);

      // Add "Disabled" Panels; will be activated later.
      this.pxPrefabPackager.Controls.Add(this.tpanelDisableMain);
      this.expPrefabProtection.TitlePanel.Controls.Add(this.tpanelDisablePrefabProtectionHeader);
      this.expPrefabProtection.Controls.Add(this.tpanelDisablePrefabProtection);
    }

    private void PrefabExport_FormClosing(object sender, FormClosingEventArgs e)
    {
      // If the user didn't do anything, close the form instantly.
      if (String.IsNullOrEmpty(txtbxPrefabName.Text)
          && String.IsNullOrEmpty(txtbxPrefabDescription.Text)
          && !bxCustomizePackagedTags.Enabled
          && chkxProtectionProtected.Checked
          && String.IsNullOrEmpty(txtbxProtectionPassword.Text)
          && chkxAllowDownload.Checked)
      {
        return; // If return is not here, the code below will be executed.
      }

      // They did do something, so let's ask them if they really want to quit.
      DialogResult result = MessageBoxEx.Show("All entered information will be lost.\n\nAre you sure you wish to cancel?", "Verify Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

      if (result == DialogResult.Yes)
      {
        return; // Redundant right now, but if code is added below this line later, the return is needed.
      }

      // They want to stay, so we'll let them ... for now.
      e.Cancel = true;
    }
    
    private void txtbxPrefabName_Enter(object sender, EventArgs e)
    {
      pxPrefabPackager.TabStop = false;
    }

    private void imgbChooseRootTag_Click(object sender, EventArgs e)
    {
#if DEBUG
      txtbxPrefabRootTag.Text = "vehicles\\warthog\\warthog.vehicle";
#endif
      //txtbxPrefabRootTag.Text = TagBrowserDialog().SelectedTag;

      bxCustomizePackagedTags.Enabled = !String.IsNullOrEmpty(txtbxPrefabRootTag.Text);
      pbPrefabRootTagLocation.Enabled = bxCustomizePackagedTags.Enabled;
    }

    private bool customTagsOnly = false;
    private void bxCustomizePackagedTags_Click(object sender, EventArgs e)
    {
#if DEBUG
      customTagsOnly = !customTagsOnly;
#endif

      //if (new PrefabPackagerCustomize(out customTagsOnly).ShowDialog() = DialogResult.Cancel)
        //return;
    }

    #region Checkbox Dependency Handling

    private void chkxReportInfo_CheckedChanged(object sender, EventArgs e)
    {
      if(chkxReportPrefab.Checked)
        chkxIncludeAuthorInfo.Checked = true;

      chkxIncludeAuthorInfo.Enabled = !chkxIncludeAuthorInfo.Enabled;
      infoIncludeAuthorInfo.Enabled = chkxIncludeAuthorInfo.Enabled;
    }

    private void chkxAllowDownload_CheckedChanged(object sender, EventArgs e)
    {
      if(chkxAllowDownload.Checked)
        chkxReportPrefab.Checked = true;
      
      chkxReportPrefab.Enabled = !chkxReportPrefab.Enabled;
      infoReportPrefab.Enabled = chkxReportPrefab.Enabled;
    }

    #endregion

    #region Protection and Password Handling

    private void chkxProtectionNoProtection_CheckedChanged(object sender, EventArgs e)
    {
      if (chkxProtectionNoProtection.Checked)
      {
        txtbxProtectionPassword.Text = String.Empty;
        txtbxProtectionPasswordVerify.Text = String.Empty;
      }
      
      txtbxProtectionPassword.Enabled = !txtbxProtectionPassword.Enabled;
    }

    private void txtbxProtectionProtectedPassword_TextChanged(object sender, EventArgs e)
    {
      bool passwordEntered = !String.IsNullOrEmpty(txtbxProtectionPassword.Text);
      
      txtbxProtectionPasswordVerify.Visible = passwordEntered;

      /*if (passwordEntered)
        txtbxProtectionPasswordVerify_TextChanged(null, EventArgs.Empty);
      else*/
      
      txtbxProtectionPasswordVerify.Text = String.Empty;
    }

    private void txtbxProtectionProtectedPassword_EnabledChanged(object sender, EventArgs e)
    {
      if (!txtbxProtectionPassword.Enabled)
        txtbxProtectionPasswordVerify.Visible = false;
      else
        if(!String.IsNullOrEmpty(txtbxProtectionPassword.Text))
          txtbxProtectionPasswordVerify.Visible = false;
    }

    private void txtbxProtectionPasswordVerify_TextChanged(object sender, EventArgs e)
    {
      bool passwordsMatch = txtbxProtectionPasswordVerify.Text.Equals(txtbxProtectionPassword.Text);

      if (passwordsMatch)
        txtbxProtectionPasswordVerify.ForeColor = Color.Green;
      else
        txtbxProtectionPasswordVerify.ForeColor = Color.Red;

      txtbxProtectionPasswordVerify.Visible = !passwordsMatch;
      bxCreatePrefab.Enabled = passwordsMatch;

      // If the user has emptied the Password field, force the following properties to be false.
      if (String.IsNullOrEmpty(txtbxProtectionPassword.Text))
      {
        txtbxProtectionPasswordVerify.ForeColor = Color.Red;
        passwordsMatch = false;
      }

      pbProtectionPasswordSet.Visible = passwordsMatch;
      chkxProtectionPasswordRemembered.Visible = passwordsMatch;
      infoProtectionPasswordRemembered.Visible = passwordsMatch;
    }

    private void txtbxProtectionPasswordVerify_VisibleChanged(object sender, EventArgs e)
    {
      // Uncheck "Remember Password" checkbox if the Verify textbox disappeared because the user did not provide a Recovery Password.
      if (!pbProtectionPasswordSet.Visible)
        chkxProtectionPasswordRemembered.Checked = false;
    }

    private void chkxProtectionPasswordRemembered_VisibleChanged(object sender, EventArgs e)
    {
      if (chkxProtectionPasswordRemembered.Visible)
        chkxProtectionPasswordRemembered.Focus();
    }

    private void txtbxProtectionPassword_Enter(object sender, EventArgs e)
    {
      txtbxProtectionPassword.SelectAll();
    }

    private void txtbxProtectionPasswordVerify_Enter(object sender, EventArgs e)
    {
      txtbxProtectionPasswordVerify.SelectAll();
    }

    #endregion

    private Image prefabImage;
    private bool customImage = false;
    private void imgbScreenshot_Click(object sender, EventArgs e)
    {
#if DEBUG
      customImage = !customImage;
#endif

      if (!customImage) // The user has not created an image for this prefab yet.
      {
        // Set prefabImage to the image the user creates.
        // 
      }
      else // The user has created an image previously.
      {
        
      }
    }

    #region Prefab Creation

    string[] creationResults;
    private void bxCreatePrefab_Click(object sender, EventArgs e)
    {
      #region Data Checking
      // If the user failed to provide the Prefab Name, inform them.
      if (String.IsNullOrEmpty(txtbxPrefabName.Text))
      {
        MessageBoxEx.Show("The Prefab Name has not been set; it is a required field.\n\nEnter the Prefab Name and try again.", "Prefab Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        
        txtbxPrefabName.Focus();
        return;
      }

      // If the user failed to provide the Prefab Description, inform them.
      if (String.IsNullOrEmpty(txtbxPrefabDescription.Text))
      {
        MessageBoxEx.Show("The Prefab Description has not been set; it is a required field.\n\nEnter the Prefab Description and try again.", "Prefab Description Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        
        txtbxPrefabDescription.Focus();
        return;
      }

      // If the user failed to provide the Prefab's Root Tag, inform them.
      if (!bxCustomizePackagedTags.Enabled)
      {
        MessageBoxEx.Show("The Prefab's Root Tag has not been set; it is a required field.\n\nEnter the Prefab's Root Tag and try again.", "Prefab's Root Tag Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        
        imgbChooseRootTag.Focus();
        return;
      }

      // If the user failed to provide a custom image, recommend otherwise.
      if (!customImage)
      {
        DialogResult result;

        result = MessageBoxEx.Show("The Prefab's Image has not been set; an automatically generated image will be used instead.<br /><br />An automatically generated image <b>will not</b> represent the prefab as well as a custom image.<br /><br />Create a custom image now?", "Prefab Image Will Be Automatically Generated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        if(result == DialogResult.Yes)
        {
          // Allow user to set custom image now.
          customImage = true;
        }
      }
      #endregion

      // Set the mood.
      tpanelDisableMain.Visible = true;
      tpanelDisablePrefabProtectionHeader.Visible = true;
      tpanelDisablePrefabProtection.Visible = true;
      tpanelDisableMain.BringToFront();
      tpanelDisablePrefabProtectionHeader.BringToFront();
      tpanelDisablePrefabProtection.BringToFront();
      this.Opacity = 80;

      // Ask the user if they wish to proceed with the specified settings.
      DialogResult proceed = new PrefabPackagerReview(customTagsOnly,
                                   chkxProtectionProtected.Checked,
                                   pbProtectionPasswordSet.Visible,
                                   chkxProtectionPasswordRemembered.Checked,
                                   chkxIncludeAuthorInfo.Checked,
                                   chkxReportPrefab.Checked,
                                   chkxAllowDownload.Checked,
                                   customImage).ShowDialog();

      // Turn up the lights, no magic yet.
      this.Opacity = 100;
      tpanelDisableMain.Visible = false;
      tpanelDisablePrefabProtectionHeader.Visible = false;
      tpanelDisablePrefabProtection.Visible = false;
      
      // The user wants to bail; kick them out.
      if(proceed == DialogResult.Cancel)
        return;

      // The user is happy with their settings, create the prefab.
      creationResults = GeneratePrefab();

      // If something goes wrong during prefab creation, end the creation process so the user may attempt to correct the issue and try again.
      // The GeneratePrefab() function should have notified the user of the error's cause, so nothing to do here but return.
      if (creationResults.Equals(null))
      {
        txtbxProtectionPassword.Clear();
        return;
      }

      // The prefab has been created and saved to the hard disk successfully; report to the user.
      pxPrefabPackager.Visible = false;
      pxSuccess.Visible = true;
    }

    private string[] GeneratePrefab()
    {
      // Produce a prefab file.
#if DEBUG
      return new string[] { "warthog.ppfb", "3.82MB", "49 Inherited, 7 Custom", "God (HID #1)", @"C:\Prometheus\Prefabs\warthog.ppfb" };
#else
      return null;
#endif
    }

    #endregion

    #region Success Panel

    private void pxSuccess_VisibleChanged(object sender, EventArgs e)
    {
      // User cannot see panel, exit event.
      if (!pxSuccess.Visible || creationResults == null)
        return;

      #region Top Right Images
      if (chkxProtectionPasswordRemembered.Checked)
      {
        pbSuccessSecurityRight.Image = global::Prometheus.Properties.Resources.safe16;
        pbSuccessSecurityMiddle.Image = global::Prometheus.Properties.Resources.key116;
        pbSuccessSecurityLeft.Image = global::Prometheus.Properties.Resources.lock16;

        this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityRight, new DevComponents.DotNetBar.SuperTooltipInfo("Password Stored Locally", "", "The recovery password has been stored locally.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
        this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityMiddle, new DevComponents.DotNetBar.SuperTooltipInfo("Recovery Password Set", "", "A password is set to enable prefab recovery.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
        this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityLeft, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Enabled", "", "The prefab contents are protected from access.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else if (txtbxProtectionPasswordVerify.ForeColor.Equals(Color.Green)) // Only valid test now that pxPrefabPackager.Visible is false.
      {
        pbSuccessSecurityRight.Image = global::Prometheus.Properties.Resources.key116;
        pbSuccessSecurityMiddle.Image = global::Prometheus.Properties.Resources.lock16;

        this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityRight, new DevComponents.DotNetBar.SuperTooltipInfo("Recovery Password Set", "", "A password is set to enable prefab recovery.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
        this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityMiddle, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Enabled", "", "The prefab contents are protected from access.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        if (chkxProtectionProtected.Checked)
        {
          pbSuccessSecurityRight.Image = global::Prometheus.Properties.Resources.lock16;
          this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityRight, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Enabled", "", "The prefab contents are protected from access.",
                      null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
        }
        else
        {
          pbSuccessSecurityRight.Image = global::Prometheus.Properties.Resources.lock_open16;
          this.stPrefabPackager.SetSuperTooltip(this.pbSuccessSecurityRight, new DevComponents.DotNetBar.SuperTooltipInfo("Protection Disabled", "", "The contents of this prefab may be accessed by anyone.",
                      null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
        }
      }
      #endregion

      #region Labels
      lblSuccessName.Text = txtbxPrefabName.Text;
      lblSuccessDescription.Text = txtbxPrefabDescription.Text;

      // Fix panelDetails location if AutoSize made Description label taller.
      if (flpSuccessDescription.Height > 13)
      {
        int additionalPixels = flpSuccessDescription.Height - 13;
        panelSuccessDetails.Location = new System.Drawing.Point(13, (82 + additionalPixels));
      }

      lblSuccessFilenameValue.Text = creationResults[0];
      lblSuccessSizeValue.Text = creationResults[1];
      lblSuccessTagCountValue.Text = creationResults[2];

      lblSuccessAuthorValue.Text = creationResults[3];
      #endregion

      #region Prefab Image
      //pbSuccessImageSmall.Image = ;
      //pbSuccessImageLarge.Image = ;

      // Custom cursors to better illustrate what action clicking the PictureBox performs.
      Cursor zoomIn = new Cursor(global::Prometheus.Properties.Resources.zoom_in16.GetHicon()),
             zoomOut = new Cursor(global::Prometheus.Properties.Resources.zoom_out16.GetHicon());

      pbSuccessImageSmall.Cursor = zoomIn;
      pbSuccessImageLarge.Cursor = zoomOut;
      #endregion

      #region Upload Data
      // Determine if the prefab needs uploading and handle it.
      string urlToPrefab;
      if (chkxAllowDownload.Checked)
      {
        this.ControlBox = false;
        bxSuccessClose.Enabled = false;
        lblSuccessUploaded.Text = "Uploading:";
        lblSuccessUploadedValue.Visible = false;
        pbxUploadStatus.Visible = true;

        // Upload the prefab.
        urlToPrefab = UploadPrefabData(creationResults[4]);

        this.ControlBox = true;
        bxSuccessClose.Enabled = true;
        pbxUploadStatus.Visible = false;
        lblSuccessUploaded.Text = "Uploaded:";
        lblSuccessUploadedValue.Visible = true;
      }
      else
      {
        urlToPrefab = UploadPrefabData(null);
      }

      if (!String.IsNullOrEmpty(urlToPrefab))
      {
        lblSuccessRecordedValue.Text = "<a href=\"" + urlToPrefab + "\">Yes</a>";
        lblSuccessUploadedValue.Text = "<a href=\"" + urlToPrefab + "\">Yes</a>";
      }
      else
      {
        lblSuccessRecordedValue.Text = "No";
        lblSuccessUploadedValue.Text = "No";
      }
      #endregion

      // Turn Esc key on.
      this.CancelButton = bxSuccessClose;

      bxSuccessClose.Focus();
    }

    private string UploadPrefabData(string path)
    {
      // Upload the prefab.
#if DEBUG
      //System.Threading.Thread.Sleep(3000);
      return "http://www.halodev.org";
#else
      return null;
#endif
    }

    private void pbSuccessImageSmall_Click(object sender, EventArgs e)
    {
      pbSuccessImageLarge.Visible = true;
      pbSuccessImageLarge.BringToFront();
    }

    private void pbSuccessImageLarge_Click(object sender, EventArgs e)
    {
      pbSuccessImageLarge.Visible = false;
    }

    #endregion
  }
}