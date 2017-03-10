using System.IO;
using System.Windows.Forms;
using Core.Libraries;
using Interfaces.Games;

namespace Prometheus.Testing
{
  [TestInfoAttribute("MonoxideC", "Archive Extraction Test",
  "Tests extracting files from the archive to a folder on the disk.")]
  public class ExtractArchive : ITest
  {
    public void PerformTest()
    {
      GameDefinition game = Core.Prometheus.Instance.GetGameDefinitionByGameID("halo1pc");
      TagArchive archive = game.GlobalTagLibrary as TagArchive;
      string[] files = archive.GetFileList("", "*", true);
      
      // Get the extraction folder.
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.Cancel) return;

      foreach (string file in files)
      {
        string path = fbd.SelectedPath + "\\" + file;
        string folder = Path.GetDirectoryName(path);
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        byte[] bin = archive.ReadFile(file);
        FileStream fs = new FileStream(path, FileMode.Create);
        fs.Write(bin, 0, bin.Length);
        fs.Close();
      }
      archive.Close();
    }
  }
}