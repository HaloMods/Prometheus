using System.IO;
using System.Windows.Forms;

namespace Prometheus.Testing
{
  [TestInfo("Project Tools", "Generate Tag Classes",
  "Creates Tag Loader classes from a set of XML tagdef files.")]
  public class GenerateTagClasses : ITest
  {
    public void PerformTest()
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.SelectedPath = Application.StartupPath;
      fbd.Description = "Choose the folder where the XML files are located.";
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        string newPath = fbd.SelectedPath + "\\output\\";
        if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);
        foreach (string file in Directory.GetFiles(fbd.SelectedPath))
        {
          string fileName = Path.GetFileNameWithoutExtension(file) + ".cs";
          Core.Prometheus.Instance.GenerateClass("halopc", file, newPath + fileName);
        }
      }
    }
  }
}