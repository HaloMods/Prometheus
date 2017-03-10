using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Dialogs
{
  public partial class CrashDialogForm : DevComponents.DotNetBar.Office2007Form
  {
    public bool Restart
    {
      get { return cbRestart.Checked; }
    }

    public string ErrorText
    {
      set { txtError.Text = value; }
    }

    private CrashDialogForm()
    {
      InitializeComponent();
    }

    private void btnSubmitReport_Click(object sender, EventArgs e)
    {
      btnSubmitReport.Enabled = false;

      if (BugReport.Display(txtError.Text) == DialogResult.Cancel)
        btnSubmitReport.Enabled = true;
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      if (Restart) DialogResult = DialogResult.Retry;
      Close();
    }

    public static DialogResult Display(string errorText)
    {
      CrashDialogForm form = new CrashDialogForm();
      form.ErrorText = errorText;
      return form.ShowDialog();
    }
  }
  public enum CrashDialogResult
  {
    Restart,
    DoNotRestart
  }
}