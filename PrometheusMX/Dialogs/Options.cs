using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Prometheus.Dialogs
{
  public partial class Options : DevComponents.DotNetBar.Office2007Form
  {
    public Options()
    {
      InitializeComponent();
    }

    private void bxCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ButtonItemToggleCheck(object sender, EventArgs e)
    {
      (sender as ButtonItem).Checked = !(sender as ButtonItem).Checked;
    }

    private void biOptionCategoriesGameConfig_Click(object sender, EventArgs e)
    {
      ipOptions.Items.Clear();
      this.ipOptions.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icOptionsGameConfig });
      ipOptions.Invalidate();
      ipOptions.Refresh();
    }

    private void biOptionCategoriesRendering_Click(object sender, EventArgs e)
    {
      ipOptions.Items.Clear();
      this.ipOptions.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icOptionsRendering});
      ipOptions.Invalidate();
    }
    
    private void NotFinished(object sender, EventArgs e)
    {
      ipOptions.Items.Clear();
      this.ipOptions.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.icNotFinished});
      ipOptions.Invalidate();
    }
  }
}