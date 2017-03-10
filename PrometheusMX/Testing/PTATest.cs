using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Core;
using Core.ArchiveFileSystem;
using Core.Libraries;
using Interfaces.Games;

namespace Prometheus.Testing
{
  [TestInfoAttribute("MonoxideC", "PTA Write Test", "Tests writing files to a PTA.")]
  public class PTATest : ITest
  {
    /// <summary>
    /// The code to be tested is placed inside this method.
    /// </summary>
    public void PerformTest()
    {
      GameDefinition game = Core.Prometheus.Instance.GetGameDefinitionByGameID("halo1pc");
      TagArchive archive = game.GlobalTagLibrary as TagArchive;

      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (fbd.ShowDialog() == DialogResult.Cancel) return;

      foreach (string filename in Helpers.GetRecursiveFiles(fbd.SelectedPath))
      {
        FileStream stream = new FileStream(filename, FileMode.Open);
        byte[] buffer = new byte[stream.Length];
        stream.Read(buffer, 0, (int)stream.Length);

        string tagPath = filename.Substring(fbd.SelectedPath.Length+1);
        archive.AddFile(tagPath, buffer);
      }
      archive.Close();
    }
  }
}
