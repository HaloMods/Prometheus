using System.IO;
using System.Windows.Forms;
using Interfaces.Pool;
using Interfaces.Games;
using Core.Libraries;

namespace Prometheus.Testing
{
#if DEBUG
  [TestInfo("SwampFox", "Compile Halo PC Cache", "Attempts to compile a map given a directory and a scenario - it will assume all other required tags to be the defaults.")]
  public class HPCCompilerTest : ITest
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
            GameDefinition gd = Core.Prometheus.Instance.GetGameDefinitionByGameID("halopc");
            IMapFile map = gd.CreateMapFileObject();
            ILibrary library = new DiskFileLibrary(fbd.SelectedPath, "Compiler Test Library");
            map.RegisterTag(library, ofd.FileName.Replace(fbd.SelectedPath + '\\', ""));
            map.RegisterTag(library, @"globals\globals.globals");
            map.RegisterTag(library, @"ui\ui_tags_loaded_all_scenario_types.tag_collection");
            map.RegisterTag(library, @"ui\shell\bitmaps\background.bitmap");
            map.RegisterTag(library, @"ui\shell\strings\loading.unicode_string_list");
            map.RegisterTag(library, @"ui\shell\main_menu\mp_map_list.unicode_string_list");
            map.RegisterTag(library, @"ui\shell\bitmaps\trouble_brewing.bitmap");
            map.RegisterTag(library, @"sound\sfx\ui\cursor.sound");
            map.RegisterTag(library, @"sound\sfx\ui\forward.sound");
            map.RegisterTag(library, @"sound\sfx\ui\back.sound");
            map.RegisterTag(library, @"ui\ui_tags_loaded_multiplayer_scenario_type.tag_collection");
            
            FileStream fs = File.Create(sfd.FileName);
            map.CompileCache(fs, library);
            fs.Close();
          }
        }
      }
    }
  }
#endif
}
