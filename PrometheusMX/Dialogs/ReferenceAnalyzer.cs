using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Dialogs
{
  public partial class ReferenceAnalyzer : DevComponents.DotNetBar.Office2007Form
  {
    public ReferenceAnalyzer()
    {
      InitializeComponent();

      // cheap hacky hardcode bullcrap
      Prometheus.Controls.ReferenceAnalyzer.ReferenceItem ri = new Prometheus.Controls.ReferenceAnalyzer.ReferenceItem(Prometheus.Controls.ReferenceAnalyzer.ReferenceAnalyzerMode.Tag, @"levels\test\bloodgulch\bloodgulch.scenario");
      ri.AddItem(@"sky\mp clear afternoon\mp clear afternoon.sky", Prometheus.Controls.ReferenceAnalyzer.ReferenceType.Direct);
      ri.AddItem(@"sound\sfx\ambience\multiplayer\bloodgultch.sound_looping", Prometheus.Controls.ReferenceAnalyzer.ReferenceType.Recursive);
      rcAnalyzer.AddItem(ri);
      ri = new Prometheus.Controls.ReferenceAnalyzer.ReferenceItem(Prometheus.Controls.ReferenceAnalyzer.ReferenceAnalyzerMode.Tag, @"levels\test\bloodgulch\bloodgulch.scenario_structure_bsp");
      ri.AddItem(@"sound\sfx\ambience\multiplayer\bloodgultch.sound_looping", Prometheus.Controls.ReferenceAnalyzer.ReferenceType.Direct);
      rcAnalyzer.AddItem(ri);
    }

    private void rcAnalyzer_CountChanged(object sender, EventArgs e)
    { liTotalValue.Text = Convert.ToString(rcAnalyzer.Count); }
  }
}