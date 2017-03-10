using System;
using System.Windows.Forms;
using Interfaces.DynamicInterface.RuntimeMenu;
using DevComponents.DotNetBar;

namespace Prometheus.Testing
{
  [TestInfo("SwampFox", "Dynamic Menu", "Tests the dynamic menu builder.")]
  public class DynamicMenuTest : ITest
  {
    public void PerformTest()
    {
      MessageBox.Show("Since this UI library is real hard to understand fully, there is no real test here. I couldn't replicate a scenario in which a single buttonitem or itemcontainer could be drawn.");
    }

    private static readonly RuntimeMenuButton myButton = new RuntimeMenuButton("Test Button", "Clicking on <b>this</b> button should bring up a little message.", global::Prometheus.Properties.Resources.about16, false, new EventHandler(ShowMessageBox));

    private static void ShowMessageBox(object sender, EventArgs e)
    {
      MessageBox.Show("Here's your message.");
    }
  }
}
