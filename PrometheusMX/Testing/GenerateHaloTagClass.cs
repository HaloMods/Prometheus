using System;
using System.Windows.Forms;

#if DEBUG
namespace Prometheus.Testing
{
  [TestInfo("SwampFox", "Generate Halo Tag Class Definition",
  "Prompts to open an XML file containing a Halo tag definition and then builds a C# tag class definition from it.")]
  public class GenerateHaloTagClassTest : ITest
  {
    public void PerformTest()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Title = "Save As C# File";
      ofd.Title = "Select XML";
      ofd.Filter = "XML File|*.xml|C# File|*.cs|All Files|*.*";
      ofd.FilterIndex = 1;
      sfd.Filter = "XML File|*.xml|C# File|*.cs|All Files|*.*";
      sfd.FilterIndex = 2;
      if (ofd.ShowDialog() == DialogResult.OK)
        if (sfd.ShowDialog() == DialogResult.OK)
          Core.Prometheus.Instance.GenerateClass("halopc", ofd.FileName, sfd.FileName);
    }
  }
}
#endif
