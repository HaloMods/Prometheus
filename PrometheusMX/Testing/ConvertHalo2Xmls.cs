using System.IO;
using System.Windows.Forms;
using Core.Factory;

namespace Prometheus.Testing
{
  [TestInfo("SwampFox", "Create Halo 2 XML Definitions",
  "Converts odd-formatted XML definitions into Prom-formatted XML tagdef files.")]
  public class ConvertHalo2Xmls : ITest
  {
    public void PerformTest()
    {
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.SelectedPath = Application.StartupPath;
      fbd.Description = "Choose the folder where the source XML files are located.";
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        string newPath = fbd.SelectedPath + "\\output\\";
        if (!Directory.Exists(newPath))
          Directory.CreateDirectory(newPath);
        XmlXmlConverter.ConvertFolder(fbd.SelectedPath, newPath, "Halo2");
        MessageBox.Show("Finished.", "Xml->Xml Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
  }
}