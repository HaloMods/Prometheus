using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Prometheus.Testing
{
  [TestInfoAttribute("SwampFox", "Decompile Map",
 "Prompts for a map file, and tests decompiling it.")]
  public class DecompilerTest : ITest
  {
    public void PerformTest()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.Description = "Where to save?";
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        if (ofd.ShowDialog() == DialogResult.OK)
        {
          FileStream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          Interfaces.Games.IMapFile map = null;
          foreach (Interfaces.Games.GameDefinition gd in Core.Prometheus.Instance.Games)
          {
            if (gd.MapIsValid(stream))
            {
              map = gd.CreateMapFileObject();
              break;
            }
          }
          stream.Close();

          if (map == null)
            MessageBoxEx.Show("No suitable game definition could be found to open the specified map.", "Problem With File", MessageBoxButtons.OK, MessageBoxIcon.Error);
          else
          {
            map.Load(ofd.FileName);
            map.Decompile(new Core.Libraries.DiskFileLibrary(fbd.SelectedPath, "Decompiler Test Library"));
          }
        }
      }
    }
  }
}
