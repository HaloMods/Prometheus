//using System.Windows.Forms;

//namespace Prometheus.Testing
//{
//  [TestInfoAttribute("ViperNeo", "Open Map File",
//  "Prompts for a map file, and tests opening it.<br /><i>Note: this is hardcoded for the second loaded GameDefinition</i>")]
//  public class OpenMapTest : ITest
//  {
//    public void PerformTest()
//    {
//      OpenFileDialog ofd = new OpenFileDialog();
//      if (ofd.ShowDialog() == DialogResult.OK)
//      {
//        Core.Prometheus.Instance.Games[0].MapFile.Load(ofd.FileName,null);
//      }
//    }
//  }
//}