using System;
using System.Collections.Generic;
using System.Text;
using Prometheus.Dialogs;

namespace Prometheus.Testing
{
  [TestInfoAttribute("Grenadiac", "Cluster Debugger",
  "Interactive Cluster Visualization and Debugging")]
  class ClusterTest : ITest
  {
    public void PerformTest()
    {
      RenderDebug dlg = new RenderDebug();
      dlg.Show();
    }
  }
}
