using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces.Rendering.Radiosity
{
  public enum RadiosityStage : int
  {
    NotStarted = 0,
    ScenarioLoading,
    CreatingImportanceMap,
    PhotonBouncing,
    TreeBalancing,
    TextureGeneration,
    Done,
  }
  public class RadiosityStageHelper
  {
    public string this[RadiosityStage stage]
    {
      get
      {
        return GetName(stage);
      }
    }
    public static string GetName(RadiosityStage stage)
    {
      switch (stage)
      {
        case RadiosityStage.NotStarted:
          return "Not Started";
        case RadiosityStage.ScenarioLoading:
          return "Loading Scenario";
        case RadiosityStage.TextureGeneration:
          return "Generating Textures";
        case RadiosityStage.TreeBalancing:
          return "Balancing Tree";
        case RadiosityStage.Done:
          return "Done";
        case RadiosityStage.CreatingImportanceMap:
          return "Optimizing Pass";
        default:
          return "Unknown";
      }
    }
    public static bool HasProgress(RadiosityStage stage)
    {
      int intStage = (int)stage;
      return ((intStage > 0) && (intStage < (int)RadiosityStage.Done));
    }
    public static readonly RadiosityStageHelper Instance = new RadiosityStageHelper();
  }
}
