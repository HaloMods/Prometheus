using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Core.Pool;
using Interfaces.Games;
using Interfaces.Pool;
using Prometheus.Controls.TagEditor;

namespace Prometheus.Testing
{
  [TestInfo("MonoxideC", "Tag Editor Test",
  "Tests loading a tag into the tag edior.")]
  public class TagEditorTest : ITest
  {
    public void PerformTest()
    {
      GameDefinition game = Core.Prometheus.Instance.GetGameDefinitionByGameID("halopc");
      TagEditorControl te = new TagEditorControl();
      ILibrary library = game.GlobalTagLibrary;
      Pool pool = Core.Prometheus.Instance.Pool;
      pool.RegisterProject(game.GameID, library);

      string tagName = "vehicle";
      string tagPath = "vehicles\\warthog\\mp_warthog.vehicle";
      Type tagType = game.TypeTable.LocateEntryByName(tagName).TagType;
      Tag tag = pool.Open("<" + game.GameID + ">p:\\" + tagPath, tagType, true);

      te.Dock = DockStyle.Fill;
      te.Create(game, "vehi", tag);
      ControlHierarchy.Visualize(te, Application.StartupPath + "\\heirarchy.xml");

      Form frm = new Form();
      frm.Size = new Size(400, 600);
      frm.Controls.Add(te);
      frm.ShowDialog();
      pool.DisposeOfTag(ref tag);
      pool.ResetProject();
    }
  }
}