using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Pool;
using Core.Pool;

namespace Prometheus.Testing
{
  [TestInfo("ZeldaFreak", "HaloPC Tag Loading", "Loads and presents every tag in the library in order to test databinding and tag loading.")]
  class HaloPCTagLoadingTest : ITest
  {
    #region ITest Members


    public void PerformTest()
    {
      try
      {
        System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\tagerrors.txt");
        Interfaces.Games.GameDefinition def = Core.Prometheus.Instance.GetGameDefinitionByGameID("halopc");
        Core.Libraries.TagArchive tagArchive = (Core.Libraries.TagArchive)def.GlobalTagLibrary;
        string[] files = tagArchive.GetFileList("", "*", true);

        ProgressDialog pd = new ProgressDialog();
        pd.Show();

        pd.SuspendLayout();

        pd.Maximum = files.Length;

        for (int x = 0; x < files.Length; x++)
        {
          try
          {
            string fileExt = files[x].Substring(files[x].LastIndexOf('.') + 1); // get the extension of the file.
            if (fileExt.ToLower() == "scenario") continue;
            if (fileExt.ToLower() == "scenario_structure_bsp") continue;
            if (fileExt.ToLower() == "unit_hud_interface") continue;

            using (Prometheus.Controls.TagEditor.TagEditorControl tempTagEditorControl = new Prometheus.Controls.TagEditor.TagEditorControl())
            {
              // Setup the progress dialog.
              pd.Info1 = "Testing tags... (" + (x + 1) + " out of " + files.Length + ")";
              pd.Info2 = files[x];
              pd.Refresh();

              // Open the tag.
              TagPath path = new TagPath(files[x], "halopc", TagLocation.Archive);
              Type type = Core.Prometheus.Instance.GetTypeFromTagPath(path);
              Tag tag = Core.Prometheus.Instance.Pool.Open(path.ToPath(), type, false);

              // Load the tag in the tag editor
              try
              {
                tempTagEditorControl.Create(def, def.TypeTable.LocateEntryByName(tag.FileExtension).FourCC, tag);
                sw.WriteLine("File: " + files[x] + "(" + x + ")");
                Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Tag completed sucessfully!");
              }
              catch (Exception ex)
              {
                // Write any error data
                Interfaces.Output.Write(Interfaces.OutputTypes.Error, "There was an error loading tag " + x + " \"" + files[x] + "\": " + ex.Message, "");
                sw.WriteLine("File: " + files[x] + "(" + x + ")");
                sw.WriteLine("Error: " + ex.Message);
                sw.WriteLine("Trace: " + ex.StackTrace);
                sw.Flush();
              }
              // refresh the tooltip
              //Interfaces.TagEditor.FieldControl.stFieldControl = new DevComponents.DotNetBar.SuperTooltip();
            }

            pd.Value = x;
          }
          catch (Exception ex)
          {
            Interfaces.Output.Write(Interfaces.OutputTypes.Error, "There was an error loading tag " + x + " \"" + files[x] + "\":" + ex.Message, "");
            sw.WriteLine("File: " + files[x]);
            sw.WriteLine("Error: " + ex.Message);
            sw.WriteLine("Trace: " + ex.StackTrace);
            sw.Flush();
          }
        }
        pd.Close();
        sw.Close();
      }
      catch (Exception ex)
      {
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "There was an error performing the test: " + ex.Message, "");
      }
    }

    #endregion
  }
  [TestInfo("ZeldaFreak", "HaloPC Class Loader", "Loads and presents the first encountered tag of every class.")]
  class HaloPCClassLoadingTest : ITest
  {
    #region ITest Members

    public void PerformTest()
    {
      Interfaces.Games.GameDefinition def = Core.Prometheus.Instance.GetGameDefinitionByGameID("halopc");
      Core.Libraries.TagArchive tagArchive = (Core.Libraries.TagArchive)def.GlobalTagLibrary;
      string[] files = tagArchive.GetFileList("", "*", true);

      ProgressDialog pd = new ProgressDialog();
      pd.Show();
      pd.SuspendLayout();
      pd.Maximum = files.Length;

      List<string> classes = new List<string>(100);

      for (int x = 0; x < files.Length; x++)
      {
        pd.Info2 = files[x];
        pd.Value = x;
        pd.Refresh();

        string fileExt = files[x].Substring(files[x].LastIndexOf('.')).ToLower();

        if (classes.Contains(fileExt))
          continue;

        // Open the tag.
        TagPath path = new TagPath(files[x], "halopc", TagLocation.Archive);
        Type type = Core.Prometheus.Instance.GetTypeFromTagPath(path);
        Tag tag = Core.Prometheus.Instance.Pool.Open(path.ToPath(), type, false);

        using (Prometheus.Controls.TagEditor.TagEditorControl tempTagEditorControl = new Prometheus.Controls.TagEditor.TagEditorControl())
        {

          try
          {
            // Load the tag in the tag editor
            tempTagEditorControl.Create(def, def.TypeTable.LocateEntryByName(tag.FileExtension).FourCC, tag);
          }
          catch
          {
            Interfaces.Output.Write(Interfaces.OutputTypes.Error, "There was an error loading tag " + x + ": " + files[x]);
          }
        }

        classes.Add(fileExt);
      }
      System.Windows.Forms.MessageBox.Show("A total of " + classes.Count + " tags/classes were tested!");
    }

    #endregion
  }

  [TestInfo("ZeldaFreak", "Collect Garbage", "Calls GC.Collect.")]
  class GarbageCollectionTest : ITest
  {
    #region ITest Members

    public void PerformTest()
    {
      GC.Collect();
    }

    #endregion
  }
}
