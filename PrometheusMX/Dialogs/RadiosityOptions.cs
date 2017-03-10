using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using Core.Radiosity;

using Interfaces.Settings;

namespace Prometheus.Dialogs
{
  public partial class RadiosityOptions : Office2007Form, IPersistable
  {
    public delegate void RunEventHandler();
    public event RunEventHandler OnRun;

    public delegate void CancelEventHandler();
    public event CancelEventHandler OnCancel;

    public delegate void FormClosedEventHandler();
    public event FormClosedEventHandler OnClose;

    private bool isRunThreaded;

    [Interfaces.Settings.PersistableOption("PhotonCount", "Radiosity", 100, OptionsFile.System)]
    public int PhotonCount
    {
      get
      {
        return Convert.ToInt32((String.IsNullOrEmpty(m_photonCount.Text)) ? m_photonCount.WatermarkText : m_photonCount.Text);
      }
      set
      {
        m_photonCount.Text = Convert.ToString(value);
      }
    }

    [Interfaces.Settings.PersistableOption("MaxBounces", "Radiosity", 3, OptionsFile.System)]
    public int MaxBounces
    {
      get
      {
        return Convert.ToInt32((String.IsNullOrEmpty(m_bounceLimit.Text)) ? m_bounceLimit.WatermarkText : m_bounceLimit.Text);
      }
      set
      {
        m_bounceLimit.Text = Convert.ToString(value);
      }
    }

    [Interfaces.Settings.PersistableOption("TexelRadius", "Radiosity", 5, OptionsFile.System)]
    public int TexelRadius
    {
      get
      {
        return Convert.ToInt32((String.IsNullOrEmpty(m_texelRadius.Text)) ? m_texelRadius.WatermarkText : m_texelRadius.Text);
      }
      set
      {
        m_texelRadius.Text = Convert.ToString(value);
      }
    }

    [Interfaces.Settings.OptionUpdateNotifier("PhotonCount")]
    public event EventHandler PhotonCountUpdated;
    [Interfaces.Settings.OptionUpdateNotifier("MaxBounces")]
    public event EventHandler MaxBouncesUpdated;
    [Interfaces.Settings.OptionUpdateNotifier("TexelRadius")]
    public event EventHandler TexelRadiusUpdated;

    private int ConvertString(string value)
    {
      if (!string.IsNullOrEmpty(value))
        return Convert.ToInt32(value);
      else
        return 0;
    }

    /// <summary>
    /// Creates a new instance of radiosity options.
    /// </summary>
    public RadiosityOptions()
    {
      InitializeComponent();
      this.isRunThreaded = false;

#if DEBUG
#else
            MaximumSize = new Size(MaximumSize.Width, 400);
            Size = MaximumSize;
#endif

      (this as IPersistable).Load();
    }

    /// <summary>
    /// Determines if the user wishes to run the processing
    /// using a threaded archictecture.
    /// </summary>
    public bool IsRunThreaded
    {
      get { return this.isRunThreaded; }
    }

    /// <summary>
    /// This is executed when the user clicks the cancel button.
    /// </summary>
    /// <param name="sender">Cancel button.</param>
    /// <param name="e">Cancel button events.</param>
    private void CancelClick(object sender, EventArgs e)
    {
      // Notify subscribers that the user wishes to cancel.
      if (this.OnCancel != null)
        this.OnCancel();

      // Renable all the controls.
      this.EnableAll();

      // Close the dialog.
      this.Hide();
    }

    private void HideClick(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void tbiProfileNameToggle(object sender, EventArgs e)
    {
      if ((sender as ButtonItem).Text.Equals("Default Settings"))
      {
        tbiProfileName.Enabled = false;
        cboxxProfileGlobal.Enabled = false;
      }
      else
      {
        tbiProfileName.Enabled = true;
        cboxxProfileGlobal.Enabled = true;
      }

      tbiProfileName.ControlText = (sender as ButtonItem).Text;
    }

    private void cboxxAutoSaveOptionsEnabled_CheckedChanged(object sender, EventArgs e)
    {
      if (!cboxxAutoSaveOptionsEnabled.Checked)
      {
        txtxAutoSaveOptionsSaveRate.Text = String.Empty;
        txtxAutoSaveOptionsKeepCount.Text = String.Empty;
      }

      txtxAutoSaveOptionsSaveRate.Enabled = !txtxAutoSaveOptionsSaveRate.Enabled;
      lblAutoSaveOptionsSaveRate.Enabled = !lblAutoSaveOptionsSaveRate.Enabled;
      lblAutoSaveOptionsSaveRateMinutes.Enabled = !lblAutoSaveOptionsSaveRateMinutes.Enabled;

      txtxAutoSaveOptionsKeepCount.Enabled = !txtxAutoSaveOptionsKeepCount.Enabled;
      lblAutoSaveOptionsKeepCount.Enabled = !lblAutoSaveOptionsKeepCount.Enabled;
      lblAutoSaveOptionsKeepCountBackups.Enabled = !lblAutoSaveOptionsKeepCountBackups.Enabled;
    }

    private void RadiosityOptions_Load(object sender, EventArgs e)
    {
      tbiProfileNameToggle(biGlobalProfileDefaultProfile, EventArgs.Empty);
    }

    /// <summary>
    /// Disables all controls that need to be in order to do
    /// radiosity processing.
    /// </summary>
    private void DisableAll()
    {
    }

    private void EnableAll()
    {
    }

    /// <summary>
    /// Raises the OnRun event to notify subscribers that the user
    /// has clicked the Run button.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void RunRadiosity(object sender, EventArgs e)
    {
      // Disable controls which can't be changed during
      // processing.
      this.DisableAll();

      if (this.OnRun != null)
        this.OnRun();
    }

    private void cpddPhotonMappingDefaultDiffuse_SelectedColorChanged(object sender, EventArgs e)
    {
      panDefaultDiffuseColorSelected.BackColor = cpddPhotonMappingDefaultDiffuse.SelectedColor;
    }

    private void RadiosityOptions_FormClosing(object sender, FormClosingEventArgs e)
    {
      //if (OnClose != null) // We need to ask the user if they want to cancel or just hide the window.
        //OnClose();

      e.Cancel = true;
      this.Hide();
    }

    #region IPersistable Members

    string IPersistable.InstanceName
    {
      get { return "RadiosityOptionsDialog"; }
    }

    bool loadingSettings = false;
    void IPersistable.Load()
    {
      loadingSettings = true;
      SettingsManager.Instance.LoadInstance(this);
      loadingSettings = false;
    }

    void IPersistable.Save()
    {
      SettingsManager.Instance.SaveInstance(this);
    }

    #endregion

    private void m_photonCount_TextChanged(object sender, EventArgs e)
    {
      if (!loadingSettings)
        if (!String.IsNullOrEmpty(m_photonCount.Text))
          if (PhotonCountUpdated != null) PhotonCountUpdated(this, null);
    }

    private void m_bounceLimit_TextChanged(object sender, EventArgs e)
    {
      if (!loadingSettings)
        if (!String.IsNullOrEmpty(m_bounceLimit.Text))
          if (MaxBouncesUpdated != null) MaxBouncesUpdated(this, null);
    }

    private void m_texelRadius_TextChanged(object sender, EventArgs e)
    {
      if (!loadingSettings)
        if (!String.IsNullOrEmpty(m_texelRadius.Text))
          if (TexelRadiusUpdated != null) TexelRadiusUpdated(this, null);
    }
  }
}