using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Core.Tools;
using Interfaces;
using Interfaces.Games;
using Prometheus.Testing;
using DevComponents.DotNetBar;

namespace Prometheus.Testing
{
  [TestInfoAttribute("Project Tools", "Create Halo PC TagList", "Creates an XML file containing a list of all retail Halo PC tags.")]
  public class GenerateHaloPCTagList : ITest { public void PerformTest() { TaglistGenerator.GenerateList("halopc"); } }

  [TestInfoAttribute("Project Tools", "Create Halo CE TagList", "Creates an XML file containing a list of all retail Halo CE tags.")]
  public class GenerateHaloCETagList : ITest { public void PerformTest() { TaglistGenerator.GenerateList("halocepc"); } }

  [TestInfoAttribute("Project Tools", "Create Halo Xbox TagList", "Creates an XML file containing a list of all retail Halo Xbox tags.")]
  public class GenerateHaloXboxTagList : ITest { public void PerformTest() { TaglistGenerator.GenerateList("haloxbox"); } }

  [TestInfoAttribute("Project Tools", "Create Halo 2 Xbox TagList", "Creates an XML file containing a list of all retail Halo 2 Xbox tags.")]
  public class GenerateHalo2XboxTagList : ITest { public void PerformTest() { TaglistGenerator.GenerateList("halo2xbox"); } }

  public class TaglistGenerator
  {
    /// <summary>
    /// Creates an XML file containing a list of all retail tags for the specified game.
    /// </summary>
    public static void GenerateList(string gameID)
    {
      GameDefinition def = null;
      foreach (GameDefinition g in Core.Prometheus.Instance.Games)
        if (g.GameID == gameID)
          def = g;

      if (def == null)
      {
        MessageBoxEx.Show("Could not locate a game definition for '" + gameID + "'");
        return;
      }

      FolderBrowserDialog fbd = new FolderBrowserDialog();
      if (def.MapFilePath != "")
        if (Directory.Exists(def.MapFilePath))
          fbd.SelectedPath = def.MapFilePath;

      fbd.Description = "Select the folder that contains your '" + gameID + "' map files.";
      if (fbd.ShowDialog() == DialogResult.Cancel) return;
      string basePath = fbd.SelectedPath;
      
      StreamWriter writer = new StreamWriter(basePath + "\\" + gameID + " mapinfo.txt");
      TagListCompiler comp = new TagListCompiler();
      try
      {
        foreach (MapFileDefinition mapDef in def.Maps)
        {
          IMapFile map = def.CreateMapFileObject();
          string file = basePath + "\\" + mapDef.Filename;
          if (!File.Exists(file))
          {
            Output.Write(OutputTypes.Warning, "File not found: " + file);
            continue;
          }
          map.Load(file);
          byte[] checksum = map.CalculateChecksum();
          long low = BitConverter.ToInt64(checksum, 0);
          long high = BitConverter.ToInt64(checksum, 8);
          FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          long fileSize = fileStream.Length;
          fileStream.Close();

          // 0 = filename, 1 = checksum low, 2 = checksum high, 3 = filesize
          writer.WriteLine("new MapFileDefinition(\"{0}\", 0x{1}, 0x{2}, {3}),",
                           mapDef.Filename, Convert.ToString(low, 16), Convert.ToString(high, 16), fileSize);

          comp.AddMap(map);
        }
      }
      finally
      {
        writer.Close();
      }
      comp.WriteXml(basePath + "\\" + gameID + " tag list.xml");
    }
  }

  [TestInfoAttribute("Project Tools", "Create Halo PC PTA", "Creates the HaloPC PTA based on the chosen XML file.")]
  public class CreateHaloPCPTA : ITest { public void PerformTest() { PTACreator.CreatePTA("halopc"); } }

  [TestInfoAttribute("Project Tools", "Create Halo CE PTA", "Creates the Halo CE PTA based on the chosen XML file..")]
  public class CreateHaloCEPTA : ITest { public void PerformTest() { PTACreator.CreatePTA("halocepc"); } }

  [TestInfoAttribute("Project Tools", "Create Halo Xbox PTA", "Creates the Halo Xbox PTA based on the chosen XML file..")]
  public class CreateHaloXboxPTA : ITest { public void PerformTest() { PTACreator.CreatePTA("haloxbox"); } }

  [TestInfoAttribute("Project Tools", "Create Halo 2 Xbox PTA", "Creates the Halo 2 Xbox PTA based on the chosen XML file..")]
  public class CreateHalo2XboxPTA : ITest { public void PerformTest() { PTACreator.CreatePTA("halo2xbox"); } }

  public class PTACreator
  {
    public static void CreatePTA(string gameID)
    {
      GameDefinition def = null;
      foreach (GameDefinition g in Core.Prometheus.Instance.Games)
        if (g.GameID == gameID)
          def = g;
      if (def == null)
      {
        MessageBoxEx.Show("Could not locate a game definition for '" + gameID + "'");
        return;
      }

      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Xml Files (*.xml)|*.xml";
      if (ofd.ShowDialog() == DialogResult.Cancel) return;
      
      PTABuilder builder = new PTABuilder();
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.Load(ofd.FileName);
      builder.BuildPTA(def, xmlDoc);
    }
  }
}