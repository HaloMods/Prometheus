//Obtained from Halo PC.
using System.IO;
using System.Text;
using System.Windows.Forms;
using Core;
using Core.ArchiveFileSystem;
using Core.Libraries;
using Interfaces.Games;
using Interfaces.Pool;

namespace Prometheus.Testing
{
  [TestInfo("MonoxideC", "Build PTA From HaloPC Tags",
  "Creates a PTA file from a set of old-format extracted tags from Halo PC, converting to the new format on the fly.")]
  public class CreatePTAFromOldTags : ITest
  {
    public void PerformTest()
    {
      GameDefinition def = Core.Prometheus.Instance.GetGameDefinitionByGameID("halo1pc");
      
      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.Cancel) return;

      SaveFileDialog sfd = new SaveFileDialog();
      sfd.Filter = "Prometheus Tag Archive (*.pta)|*.pta";
      sfd.AddExtension = true;
      if (sfd.ShowDialog() == DialogResult.Cancel) return;
      
      TagArchive archive = new TagArchive(sfd.FileName, Archive.ArchiveMode.Open);
           
      string[] files = Helpers.GetRecursiveFiles(fbd.SelectedPath);
      foreach (string file in files)
      {
        FileStream stream = new FileStream(file, FileMode.Open);
        stream.Position = 0x8;
        string[] classes = new string[] {ReadClass(stream), ReadClass(stream), ReadClass(stream)};
        
        stream.Position = 0x40;
        byte[] data = new byte[stream.Length - 40];
        stream.Read(data, 0, (int)stream.Length - 40);
        
        TagFile tag = new TagFile(data, "Bungie", "Obtained from Halo PC.",
          classes[0], classes[1], classes[2],
          Encoding.ASCII.GetBytes(def.GameID));

        byte[] tagBin = tag.ToBytes();
        string fullPath = file.Substring(fbd.SelectedPath.Length + 1);
        string folder = Path.GetDirectoryName(fullPath);
        string extension = def.TypeTable.LocateEntryByFourCC(classes[0]).FullName;
        string filename = Path.GetFileNameWithoutExtension(fullPath) + "." + extension;
        archive.AddFile(folder + "\\" + filename, tagBin);
      }
      archive.Close();
    }
    
    private string ReadClass(Stream source)
    {
      byte[] b = new byte[4];
      source.Read(b, 0, 4);
      byte[] c = new byte[4];
      c[0] = b[3];
      c[1] = b[2];
      c[2] = b[1];
      c[3] = b[0];
      return Encoding.ASCII.GetString(c);
    }
  }
}
