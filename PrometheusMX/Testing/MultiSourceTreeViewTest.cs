using System.IO;
using System.Windows.Forms;
using Prometheus.Controls.TagExplorers;

namespace Prometheus.Testing
{
  [TestInfo("MonoxideC", "MultiSourceTreeView Test",
  "Tests opening an ILibrary in a MultiSourceTreeView control.")]
  public class MultiSourceTreeViewTest : ITest
  {
    public void PerformTest()
    {
      LibraryExplorer explorer = new LibraryExplorer();
      explorer.Dock = DockStyle.Fill;

      Form frm = new Form();
      frm.Controls.Add(explorer);
      frm.ShowDialog();
    }
  }
}