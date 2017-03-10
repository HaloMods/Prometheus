using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Dialogs
{
  public partial class GuerillaImport : DevComponents.DotNetBar.Office2007Form
  {
    public GuerillaImport()
    {
      InitializeComponent();
    }

    private void bxCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void bxClearTags_Click(object sender, EventArgs e)
    {
      lbTags.Items.Clear();
    }

    private void bxRemoveTag_Click(object sender, EventArgs e)
    {
      if (lbTags.Items.Count > 0 && lbTags.SelectedIndex != -1)
        lbTags.Items.RemoveAt(lbTags.SelectedIndex);
    }
  }
}