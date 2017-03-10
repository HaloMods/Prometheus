using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Text;

namespace Prometheus.Dialogs
{
  public partial class BugReport : DevComponents.DotNetBar.Office2007Form
  {
    #region Report Variables
    private string exception;
    #endregion

    #region Dropdown Values
    private static readonly string[] categories = { "Syst$em Funct642io.nality",
                                                    "...End points" };
    enum Categories
    {
      SystemFunctionality = 1,
      Endpoints = 145,
    }

    private static readonly string[] severity = { "Critical - Crashing, locking, or data loss.",
                                                  "Major - An issue that impedes usability.",
                                                  "Normal - An issue with the application.",
                                                  "Minor - An issue that can be easily worked around.",
                                                  "Minimal - Superficial issue with text or layout."};
    enum Severity
    {
      Critical = 5,
      Major = 4,
      Normal = 3,
      Minor = 2,
      Minimal = 1,
    }

    private static readonly string[] priority = { "Vital - Resolve before any work proceeds.",
                                                  "Immediate - Resolve before new features.",
                                                  "Urgent - Should be resolved ASAP.",
                                                  "High - An issue that can be easily worked around.",
                                                  "Normal - When there is a chance.",
                                                  "Low - Will be resolved ... eventually."};
    enum Priority
    {
      Vital = 6,
      Immediate = 5,
      Urgent = 4,
      High = 3,
      Normal = 2,
      Low = 1,
    }
    #endregion

    public BugReport() : this(String.Empty) { }
    public BugReport(string exception)
    {
      this.exception = exception;

      InitializeComponent();

      cookieContainer = new CookieContainer();

      cboxxBugCategory.Items.AddRange(categories);
      cboxxBugCategory.SelectedIndex = 0;
      cboxxBugSeverity.Items.AddRange(severity);
      cboxxBugSeverity.SelectedIndex = 0;
      comboBoxEx_SelectionChangeCommitted(cboxxBugSeverity, EventArgs.Empty);
      cboxxBugPriority.Items.AddRange(priority);
      cboxxBugPriority.SelectedIndex = 0;
      comboBoxEx_SelectionChangeCommitted(cboxxBugPriority, EventArgs.Empty);
    }

    public static DialogResult Display(string exception)
    {
      BugReport form = new BugReport(exception);
      return form.ShowDialog();
    }

    #region UI Handling

    private void BugReport_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!sendSucceeded)
        DialogResult = DialogResult.Cancel;

      BugWritingTips.Instance.Close();
    }

    private void bxSubmit_Click(object sender, EventArgs e)
    {
      // Temp login / submit setup so I can get this checked in.
      if(isLoggedIn)
        SendData();
      else
        IssueTrackerLogin(txtbxLoginUsername.Text, txtbxLoginPassword.Text);
    }

    private void bxCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void llBugTips_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      BugWritingTips.Instance.Show();
    }

    private void txtbxBugSummary_Leave(object sender, EventArgs e)
    {
      txtbxBugSummary.Text = Prometheus.ThirdParty.Helpers.Strings.TitleCase(txtbxBugSummary.Text);
    }

    /// <summary>
    /// The purpose of this event is to shorten the string displayed on the ComboBoxEx
    /// and restore the removed details when a new item is selected.
    /// 
    /// cboxxSender.Tag: Stores descriptive string.
    /// cboxxSender.MaxLength: Stores index for previously selected value.
    /// </summary>
    private void comboBoxEx_SelectionChangeCommitted(object sender, EventArgs e)
    {
      DevComponents.DotNetBar.Controls.ComboBoxEx cboxxSender = (sender as DevComponents.DotNetBar.Controls.ComboBoxEx);

      // Restore descriptive text to previously selected item.
      if (cboxxSender.Tag != null)
      {
        if (!cboxxSender.Tag.ToString().Equals(String.Empty))
        {
          if (cboxxSender.MaxLength > -1 && cboxxSender.MaxLength < cboxxSender.Items.Count) // If oldIndex is in bounds.
          {
            if (!cboxxSender.Items[cboxxSender.MaxLength].ToString().Contains("-")) // If the item does not already have a descriptive string.
            {
              (cboxxSender.Items[cboxxSender.MaxLength]) += cboxxSender.Tag.ToString(); // Restore text.
            }
          }
        }
      }

      // Backup excess text to temp variable.
      string currentText = (cboxxSender.Items[cboxxSender.SelectedIndex] as string);
      int dividerLocation = currentText.IndexOf('-');
      cboxxSender.Tag = currentText.Substring(dividerLocation - 1);

      // Remove excess text.
      cboxxSender.Items[cboxxSender.SelectedIndex] = currentText.Substring(0, (currentText.IndexOf('-') - 1));
      cboxxSender.Refresh();

      cboxxSender.MaxLength = cboxxSender.SelectedIndex; // Backup latest selection value.
    }

    private void txtbxReproSteps_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(txtbxBugReproSteps.Text))
      {
        txtbxBugReproSteps.Text = "<#> \r\n<#> \r\n<#> ";
        txtbxBugReproSteps.SelectionStart = 4;
      }
    }

    private void txtbxReproSteps_Leave(object sender, EventArgs e)
    {
      if (txtbxBugReproSteps.Text.Equals("<#> \r\n<#> \r\n<#> "))
        txtbxBugReproSteps.Text = String.Empty;
    }

    private void txtbxBugReproCount_TextChanged(object sender, EventArgs e)
    {
      if (txtbxBugReproCount.Text.Length > 0)
        txtbxBugReproAttempts.Enabled = true;
      else
        txtbxBugReproAttempts.Enabled = false;
    }

    private void txtbxBugReproAttempts_EnabledChanged(object sender, EventArgs e)
    {
      txtbxBugReproAttempts.Clear();
    }

    /// <summary>
    /// This event handler is a bit of a hack to "remove" all Example Data from the user's view.
    /// 
    /// I have requested a WatermarkEnabled property to achieve the same effect in a more proper
    /// way, but this will do until that is implemented.
    /// </summary>
    string bugStatusWatermark;
    private void cboxxHideExampleData_CheckedChanged(object sender, EventArgs e)
    {
      DevComponents.DotNetBar.Controls.TextBoxX[] txtbx = new DevComponents.DotNetBar.Controls.TextBoxX[] { txtbxBugDescription, txtbxBugReproSteps, txtbxBugActualResults, txtbxBugExpectedResults, txtbxBugNotes };
      if (chkxHideExampleData.Checked)
      {
        bugStatusWatermark = txtbxBugSummary.WatermarkText;
        txtbxBugSummary.WatermarkText = "Bug Summary";

        foreach (DevComponents.DotNetBar.Controls.TextBoxX textBoxX in txtbx)
        {
          textBoxX.WatermarkText = textBoxX.WatermarkText.Replace("#BC8F8F", "white");
          textBoxX.WatermarkText = textBoxX.WatermarkText.Replace("#8FBC8F", "#FFFFFF");
          textBoxX.WatermarkColor = Color.White;
        }
      }
      else
      {
        txtbxBugSummary.WatermarkText = bugStatusWatermark;

        foreach (DevComponents.DotNetBar.Controls.TextBoxX textBoxX in txtbx)
        {
          textBoxX.WatermarkText = textBoxX.WatermarkText.Replace("white", "#BC8F8F");
          textBoxX.WatermarkText = textBoxX.WatermarkText.Replace("#FFFFFF", "#8FBC8F");
          textBoxX.WatermarkColor = System.Drawing.SystemColors.GrayText;
        }
      }
    }

    #endregion

    private readonly string issueTrackerUrl = @"http://www.computernova.com/flyspray_/";
    private string userAgent = "Test " + "(" + Environment.OSVersion + ";" + Environment.Version + ")";

    #region Session & Permission Management

    private CookieContainer cookieContainer; // Stores the cookies set by the login process.
    private bool isLoggedIn = false;
    private void IssueTrackerLogin(string username, string password)
    {
      try
      {
        WebClientEx webClient = new WebClientEx();
        webClient.Headers.Add("user-agent", userAgent);
        webClient.Method = "POST";

        webClient.QueryString.Add("user_name", username);
        webClient.QueryString.Add("password", password);
        webClient.QueryString.Add("remember_login", "on"); // Always remember login.

        webClient.UploadValuesCompleted += new UploadValuesCompletedEventHandler(IssueTrackerLogin_Completed);
        webClient.UploadValuesAsync(new Uri(issueTrackerUrl + "?do=nakedauth"), webClient.QueryString);
      }
      catch (WebException)
      {
        ConnectionError();
      }
    }

    void IssueTrackerLogin_Completed(object sender, UploadValuesCompletedEventArgs e)
    {
      WebClientEx webClient = (sender as WebClientEx);

      if (webClient == null) // No webClient, nothing to do.
        return;

      // Convert page data to a string.
      string result = Encoding.ASCII.GetString(e.Result);

      // Determine login status.
      if (result.StartsWith("Success"))
      {
        // Login Successful
        MessageBox.Show("Success!");
        isLoggedIn = true;

        // Determine which permissions are granted.
        PermissionParser(result);

        // Save returned cookies.
        cookieContainer = webClient.Cookies;
      }
      else
      {
        switch (result)
        {
          case "Failure":
            // Login Failed
            MessageBox.Show("Failure!");
            isLoggedIn = false;
            break;
          case "Bad Username":
            // Check Username
            MessageBox.Show("Bad Username!");
            isLoggedIn = false;
            break;
          case "Go Away":
            // Username & Password Missing
            MessageBox.Show("This shouldn't happen!");
            isLoggedIn = false;
            break;
          default:
            // Connection Error?
            MessageBox.Show("Connection Error?");
            isLoggedIn = false;
            break;
        }
      }

      // Update the UI.

      // Unhook event handler.
      webClient.UploadValuesCompleted -= IssueTrackerLogin_Completed;
      webClient.Dispose();
    }

    private bool canViewTasks = false,
                 canCreateTasks = false,
                 canSetPriority = false,
                 canAttachFiles = false;
    private void PermissionParser(string list)
    {
      if (list.Contains("view tasks = 1"))
      {
        canViewTasks = true;

        if (list.Contains("open new tasks = 1"))
        {
          canCreateTasks = true;

          if (list.Contains("modify all tasks = 1"))
            canSetPriority = true;
          else
            canSetPriority = false;

          if (list.Contains("create attachments = 1"))
            canAttachFiles = true;
          else
            canAttachFiles = false;
        }
        else
        {
          canCreateTasks = false;
          canAttachFiles = false;
          canSetPriority = false;
        }
      }
      else
      {
        canViewTasks = false;
        canCreateTasks = false;
        canAttachFiles = false;
        canSetPriority = false;
      }
    }

    private void IssueTrackerLogout()
    {
      try
      {
        WebClientEx webClient = new WebClientEx();
        webClient.Headers.Add("user-agent", userAgent);
        webClient.Method = "GET";

        webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(IssueTrackerLogout_Completed);
        webClient.DownloadStringAsync(new Uri(issueTrackerUrl + "?do=nakedauth&logout=1"));
      }
      catch (WebException)
      {
        ConnectionError();
      }
    }

    void IssueTrackerLogout_Completed(object sender, DownloadStringCompletedEventArgs e)
    {
      WebClientEx webClient = (sender as WebClientEx);

      if (webClient == null) // No webClient, nothing to do.
        return;

      if (e.Result.Equals("Logged Out"))
      {
        // Logout Successful
        MessageBox.Show("Logged Out!");
        isLoggedIn = false;

        // Reset all permissions.
        canViewTasks = false;
        canCreateTasks = false;
        canSetPriority = false;
        canAttachFiles = false;

        // Clear set cookies.
        cookieContainer = new CookieContainer();
      }
      else
      {
        // WTF
        MessageBox.Show("Connection Error?");
      }

      // Update the UI.

      // Unhook event handler.
      webClient.DownloadStringCompleted -= IssueTrackerLogout_Completed;
      webClient.Dispose();
    }

    #endregion

    #region Report Data Collection & Submission

    private void BuildPost(NameValueCollection data)
    {
      // Hardcoded Values
      data.Add("action", "newtask.newtask");
      data.Add("project_id", "1");
      data.Add("task_type", "1");
      data.Add("item_status", "2");
      data.Add("product_version", "1");
      data.Add("notifyme", "1");

      // Determine OS
      int operatingSystem = 0;
      switch (Environment.OSVersion.Version.Major)
      {
        case 6:
          operatingSystem = 1; // Number for Vista
          break;
        case 5:
          switch (Environment.OSVersion.Version.Minor)
          {
            case 1:
              operatingSystem = 4; // Number for XP
              break;
            case 0:
              operatingSystem = 2; // Number for 2000
              break;
            default:
              operatingSystem = 5; // Other
              break;
          }
          break;
        default:
          operatingSystem = 5; // Other
          break;
      }
      data.Add("operating_system", operatingSystem.ToString());

      // Item Summary
      data.Add("item_summary", txtbxBugSummary.Text);

      // Category
      string categoryStripped = System.Text.RegularExpressions.Regex.Replace(cboxxBugCategory.SelectedItem.ToString(), "[^A-Za-z]+", String.Empty);
      data.Add("product_category", ((int)Enum.Parse(typeof(Categories), categoryStripped, false)).ToString());

      // Severity
      string severityStripped = System.Text.RegularExpressions.Regex.Replace(cboxxBugSeverity.SelectedItem.ToString(), "[^A-Za-z]+", String.Empty);
      data.Add("task_severity", ((int)Enum.Parse(typeof(Severity), severityStripped, false)).ToString());

      // Priority
      string priorityStripped = System.Text.RegularExpressions.Regex.Replace(cboxxBugPriority.SelectedItem.ToString(), "[^A-Za-z]+", String.Empty);
      data.Add("task_priority", ((int)Enum.Parse(typeof(Priority), priorityStripped, false)).ToString());

      // Description
      #region Description Builder
      StringBuilder description = new StringBuilder();

      #region Summary Description
      // 'Description' Header
      description.Append("__**Description**__\r\n\r\n");
      // 'Description' Data
      description.Append(txtbxBugDescription.Text.Trim());
      description.Append("\r\n\r\n----\r\n"); // Spacing + Horizontal Rule
      #endregion

      #region Reproduction Steps & Rate
      // 'Reproduction Steps' Header
      description.Append("__**Reproduction Steps**__\r\n\r\n");
      // 'Reproduction Steps' Data
      description.Append(txtbxBugReproSteps.Text.Trim());
      description.Append("\r\n\r\n"); // Space
      // 'Reproduction Rate' Header
      description.Append("//**Reproduction Rate**//: ");
      // 'Reproduction Rate' Data
      description.Append(txtbxBugReproCount.Text);
      description.Append(" of "); // Seperator
      description.Append(txtbxBugReproAttempts.Text);
      description.Append("\r\n\r\n----\r\n"); // Spacing + Horizontal Rule
      #endregion

      #region Results
      // 'Actual Results' Header
      description.Append("__**Actual Results**__\r\n\r\n");
      // 'Actual Results' Data
      description.Append(txtbxBugActualResults.Text.Trim());
      description.Append("\r\n\r\n"); // Space

      // 'Expected Results' Header
      description.Append("__**Expected Results**__\r\n\r\n");
      // 'Expected Results' Data
      description.Append(txtbxBugExpectedResults.Text.Trim());
      description.Append("\r\n\r\n----\r\n"); // Spacing + Horizontal Rule
      #endregion

      #region Exception Information
      if(!String.IsNullOrEmpty(exception)) // Is there exception data?
      {
        // 'Exception' Header
        description.Append("__**Exception**__\r\n\r\n");
        // 'Exception' Data
        description.Append(exception.Trim());
        description.Append("\r\n\r\n----\r\n"); // Spacing + Horizontal Rule
      }
      #endregion

      #region Notes
      operatingSystem = 5; // DEBUG
      // 'Notes' Header
      description.Append("__**Notes**__");
      // 'Notes' Data
      if (!String.IsNullOrEmpty(txtbxBugNotes.Text)) // Notes are optional; ensure notes exist to add.
      {
        description.Append("\r\n\r\n"); // Space
        description.Append(txtbxBugNotes.Text.Trim());
      }
      if (operatingSystem == 5)
      {
        description.Append("\r\n\r\n"); // Space
        description.Append("**OS:** " + Environment.OSVersion.VersionString);
      }
      if (chkxBugNewToVersion.Checked)
      {
        description.Append("\r\n\r\n"); // Space
        description.Append("The bug is **new** to //this build//. It did not exist in prior builds.");
      }
      if (chkxSendSystemData.Checked)
      {
        description.Append("\r\n\r\n"); // Space
        description.Append("[System Data Here]");
      }
      #endregion

      // Convert list types
      description.Replace("<#>", "\r\n  -"); // Convert our markup to Dokuwiki markup.
      description.Replace("\r\n\r\n  -", "\r\n  -"); // Clean up instances where two newlines precede list value.
      description.Replace("<!>", "\r\n  *"); // Convert our markup to Dokuwiki markup.
      description.Replace("\r\n\r\n  *", "\r\n  *"); // Clean up instances where two newlines precede list value.
      #endregion
      data.Add("detailed_desc", description.ToString());
    }

    private void SendData()
    {
      if (!isLoggedIn)
      {
        MessageBox.Show("Must be logged in to submit the bug. Enter login information.");
        return;
      }

      try
      {
        WebClientEx webClient = new WebClientEx();
        webClient.Cookies = cookieContainer;
        webClient.Headers.Add("user-agent", userAgent);
        webClient.Method = "POST";

        // Get data to send.
        BuildPost(webClient.QueryString);

        //webClient.UploadValuesCompleted += new UploadValuesCompletedEventHandler(SendData_Completed);
        webClient.UploadValues(new Uri(issueTrackerUrl + "?do=newtask&project=1"), webClient.QueryString);
      }
      catch (WebException)
      {
        ConnectionError();
      }
    }

    private bool sendSucceeded = false;
    private void SendData_Completed(object sender, UploadValuesCompletedEventArgs e)
    {
      WebClientEx webClient = (sender as WebClientEx);

      if (webClient == null) // No webClient, nothing to do.
        return;

      // Convert page data to a string.
      string result = Encoding.ASCII.GetString(e.Result);

      if (result.Contains("<div class=\"errpadding\">Your new task has been added.</div>"))
      {
        // Submission Successful
        MessageBox.Show("Submission was successful.\n\nThank you!", "Bug Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        sendSucceeded = true;
      }
      else
      {
        // Submission Failed
        MessageBox.Show("Submission failed.\n\nTry again later.", "Bug Not Submitted", MessageBoxButtons.OK, MessageBoxIcon.Error);
        sendSucceeded = false;
      }

      // Update the UI.
      if (sendSucceeded)
        bxSubmit.Text = "Sent";
      else
        bxSubmit.Enabled = true;

      // Unhook event handler.
      webClient.UploadValuesCompleted -= SendData_Completed;
      webClient.Dispose();
    }

    #endregion

    private void ConnectionError()
    {
      MessageBox.Show(
        "A connection error has occurred. Please check your network connection and try again.\n\nIf this error persists, there may be an issue with the server. Please try again later.",
        "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    #region WebClientEx Class
    public class WebClientEx : WebClient
    {
      private CookieContainer container;
      private HttpWebRequest httpRequest;
      private string method = "GET";

      public string Method
      {
        get { return method; }
        set { method = value; }
      }

      public CookieContainer Cookies
      {
        get
        {
          if (container == null)
          {
            container = new CookieContainer();
          }
          return container;
        }
        set
        {
          container = value;
        }
      }

      protected override WebRequest GetWebRequest(Uri address)
      {
        httpRequest = (HttpWebRequest)base.GetWebRequest(address);
        httpRequest.Method = this.Method;
        httpRequest.CookieContainer = Cookies;
        return httpRequest;
      }

      protected override WebResponse GetWebResponse(WebRequest request)
      {
        return this.httpRequest.GetResponse();
      }

      protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
      {
        return this.httpRequest.EndGetResponse(result);
      }
    }
    #endregion

    #region BugWritingTips Class

    protected class BugWritingTips : Prometheus.Controls.FloatingPanel
    {
      private static BugWritingTips instance = null;

      private BugWritingTips()
      {
        InitializeComponent();

        try
        {
          rtbBugWritingTips.LoadFile(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Prometheus.Resources.BugWritingTips.rtf"), RichTextBoxStreamType.RichText);
        }
        catch (Exception)
        {
#if DEBUG
          MessageBox.Show("BugWritingTips.rtf missing from project folder.");
#endif
        }

        rtbBugWritingTips.BackColor = PrometheusGUI.ThemeColorTable().RibbonBar.MouseOver.TopBackground.End;
      }

      public static BugWritingTips Instance
      {
        get
        {
          if (instance == null)
            instance = new BugWritingTips();
          else if (instance.IsDisposed)
            instance = new BugWritingTips();

          if (!instance.Focused)
            instance.Focus();

          return instance;
        }
      }

      #region Designer

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
        this.rtbBugWritingTips = new System.Windows.Forms.RichTextBox();
        this.expBody.SuspendLayout();
        this.SuspendLayout();
        // 
        // expBody
        // 
        this.expBody.AnimationTime = 200;
        this.expBody.Controls.Add(this.rtbBugWritingTips);
        this.expBody.Size = new System.Drawing.Size(480, 600);
        // 
        // rtbBugWritingTips
        // 
        this.rtbBugWritingTips.AutoWordSelection = true;
        this.rtbBugWritingTips.BackColor = Color.White;
        this.rtbBugWritingTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.rtbBugWritingTips.Dock = System.Windows.Forms.DockStyle.Fill;
        this.rtbBugWritingTips.Location = new System.Drawing.Point(0, 0);
        this.rtbBugWritingTips.Name = "rtbBugWritingTips";
        this.rtbBugWritingTips.ReadOnly = true;
        this.rtbBugWritingTips.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        this.rtbBugWritingTips.ShortcutsEnabled = false;
        this.rtbBugWritingTips.Size = new System.Drawing.Size(480, 600);
        // 
        // BugWritingTips
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.ClientSize = new System.Drawing.Size(480, 600);
        this.Name = "BugWritingTips";
        this.Text = "<b>Bug Writing Tips</b>";
        this.Icon = new Icon(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Prometheus.Resources.BugWritingTips.ico"));
        this.expBody.ResumeLayout(false);
        this.ResumeLayout(false);
      }

      #endregion

      private System.Windows.Forms.RichTextBox rtbBugWritingTips;

      #endregion
    }

    #endregion
  }
}