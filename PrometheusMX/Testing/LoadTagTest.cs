using System;
using System.IO;
using System.Windows.Forms;
using Interfaces.Pool;
using Interfaces.Games;

#if DEBUG
namespace Prometheus.Testing
{
  [TestInfoAttribute("SwampFox", "Load a Tag",
  "Loads and postprocesses the head revision of any Prometheus tag file.")]
  public class LoadTagTest : ITest
  {
    public void PerformTest()
    {
      Core.Pool.Pool pool = Core.Prometheus.Instance.Pool;

      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.Cancel)
        return;
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.InitialDirectory = fbd.SelectedPath;
      if (ofd.ShowDialog() == DialogResult.Cancel)
        return;

      FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
      TagFile tf = new TagFile(fs);
      GameDefinition game = null;
      for (int i = 0; i < Core.Prometheus.Instance.Games.Count; i++)
      {
        if (Core.Prometheus.Instance.Games[i].TagIdentifier[0] == tf.GameID[0] && Core.Prometheus.Instance.Games[i].TagIdentifier[1] == tf.GameID[1] && Core.Prometheus.Instance.Games[i].TagIdentifier[2] == tf.GameID[2] && Core.Prometheus.Instance.Games[i].TagIdentifier[3] == tf.GameID[3])
        {
          game = Core.Prometheus.Instance.Games[i];
          break;
        }
      }
      fs.Close();

      try
      {
        ILibrary library = new Core.Libraries.DiskFileLibrary(fbd.SelectedPath, "Tag Loader Test for " + game.GameID);
        pool.RegisterProject(game.GameID, library);
        Tag tag = pool.Open("<" + game.GameID + ">p:\\" + ofd.FileName.Replace(fbd.SelectedPath + '\\', ""), game.TypeTable.LocateEntryByName(Path.GetExtension(ofd.FileName).Remove(0, 1)).TagType, true);
        pool.Release(tag);
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Encountered the following error loading the tag: " + ex.Message, ex);
      }
      finally
      {
        pool.ResetProject();
      }
    }
  }
}
#endif
