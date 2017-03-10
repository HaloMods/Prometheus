using System.IO;
using System.Windows.Forms;

namespace Prometheus.Testing
{
  [TestInfo("SwampFox", "Generate Halo 2 Tag Classes",
  "Creates Tag Loader classes from a set of XML tagdef files (for Halo 2).")]
  public class GenerateHalo2TagClasses : ITest
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
          Core.Prometheus.Instance.GenerateClass("halo2xbox", file, newPath + fileName);
        }
      }
    }
  }
}