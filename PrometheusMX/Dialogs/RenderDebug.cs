using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Interfaces.Rendering;

namespace Prometheus.Dialogs
{
  public partial class RenderDebug : Form
  {
    public RenderDebug()
    {
      InitializeComponent();
    }

    private void numericUpDownActiveCluster_ValueChanged(object sender, EventArgs e)
    {
      //GrenDebugger.DebugClusterIndex = (int)numericUpDownActiveCluster.Value;
    }

    private void checkBoxLockVis_CheckedChanged(object sender, EventArgs e)
    {
      MdxRender.bLockVis = checkBoxLockVis.Checked;
    }
  }
}