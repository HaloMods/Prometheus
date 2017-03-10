using System.IO;
using System.Windows.Forms;
using Interfaces.Pool;
using Interfaces.Games;
using Core.Libraries;

namespace Prometheus.Testing
{
#if DEBUG
  [TestInfo("SwampFox", "Compile Cache", "Attempts to compile a map given a directory and a scenario, followed by any number of other tags.")]
  public class CompilerTest : ITest
  {
    public void PerformTest()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      SaveFileDialog sfd = new SaveFileDialog();
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      fbd.Description = "Where did you decompile to?";
      if (fbd.ShowDialog() == DialogResult.OK)
      {
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          if (ofd.ShowDialog() == DialogResult.OK)
          {
            FileStream fs = File.OpenRead(ofd.FileName);
            TagFile tf = new TagFile(fs);
            fs.Close();

            GameDefinition gd = Core.Prometheus.Instance.GetGameDefinitionByGameID(tf.GameID);
            IMapFile map = gd.CreateMapFileObject();
            ILibrary library = new DiskFileLibrary(fbd.SelectedPath, "Compiler Test Library");
            map.RegisterTag(library, ofd.FileName.Replace(fbd.SelectedPath + '\\', ""));
            while (ofd.ShowDialog() == DialogResult.OK)
              map.RegisterTag(library, ofd.FileName.Replace(fbd.SelectedPath + '\\', ""));
            
            fs = File.Create(sfd.FileName);
            map.CompileCache(fs, library);
            fs.Close();
          }
        }
      }
    }
  }
#endif
}
