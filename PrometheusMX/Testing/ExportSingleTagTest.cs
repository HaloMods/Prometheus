using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Core.Pool;
using Interfaces.Factory;
using Interfaces.Games;
using Interfaces.Pool;
using Prometheus.Controls;
using Prometheus.Controls.TagExplorers;
using Prometheus.Controls.TagEditor;
using DevComponents.DotNetBar;

namespace Prometheus.Testing
{
  [TestInfoAttribute("SwampFox", "Export Single Tag",
  "Prompts for a map file, and saves the binary metadata for a single tag within it to a location of your choosing.")]
  public class ExportSingleTagTest : ITest
  {
    public void PerformTest()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      SaveFileDialog sfd = new SaveFileDialog();
      if (ofd.ShowDialog() == DialogResult.OK)
      {
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          FileStream stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          Interfaces.Games.IMapFile map = null;
          foreach (GameDefinition gd in Core.Prometheus.Instance.Games)
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
            File.WriteAllBytes(sfd.FileName, map.GetTag(map.GetTagList()[0]));
          }
        }
      }
    }
  }
}
