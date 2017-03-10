using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Interfaces.Rendering.Radiosity;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Core.Radiosity
{
  public enum RadiosityDebugPointListID : int
  {
    AllPurpose = 0,
    PhotonSpawn,
    AllPhotonsForLight,
    IndirectOnly,
    DirectOnly,

    EstimateLocations
  }
  public enum RadiosityDebugLineListID : int
  {
    AllPurpose = 0,
    LightDirections,
    PhotonDirectionsForLight,
    IndirectOnly,
    DirectOnly
  }
  public class VertexList
  {
    public static int StepSize = 5000;

    public Microsoft.DirectX.Direct3D.CustomVertex.PositionColored[] vertices;
    public int index = -1;
    public VertexList(int initialSize)
    {
      vertices = new CustomVertex.PositionColored[initialSize];
      index = 0;
    }
    public VertexList()
      : this(StepSize)
    {
    }

    public CustomVertex.PositionColored this[int index]
    {
      get { return vertices[index]; }
    }

    public void Add(Vector3 pos, Color color)
    {
      Add(new CustomVertex.PositionColored(pos, color.ToArgb()));
    }
    public void Add(Vector3 pos)
    {
      Add(pos, Color.White);
    }
    public void Add(CustomVertex.PositionColored vertex)
    {
      if (index >= vertices.Length)
        Array.Resize(ref vertices, vertices.Length + StepSize);
      vertices[index++] = vertex;
    }

    public void Clear() { index = 0; }

    public void Draw(Microsoft.DirectX.Direct3D.Device device, PrimitiveType type)
    {
      if (index > 0)
      {
        int primCount = 0;
        switch (type)
        {
          case PrimitiveType.LineList:
            primCount = index / 2;
            break;
          case PrimitiveType.LineStrip:
            primCount = index - 1;
            break;
          case PrimitiveType.PointList:
            primCount = index;
            break;
          case PrimitiveType.TriangleStrip:
          case PrimitiveType.TriangleFan:
            primCount = index - 2;
            break;
          case PrimitiveType.TriangleList:
            primCount = index / 3;
            break;
        }
        device.DrawUserPrimitives(type, primCount, vertices);
      }
    }
  }
  public class VertexListCollection<enumT> : IEnumerable<VertexList> where enumT : new()
  {
    public VertexList[] VertexLists;
    public enumT[] Values;

    /// <summary>
    /// Creates a new instance of VertexListCollection
    /// </summary>
    /// <param name="enumeration">The type used for the creation of this list.</param>
    public VertexListCollection()
    {
      string[] names = Enum.GetNames(typeof(enumT));

      VertexLists = new VertexList[names.Length];
      Values = new enumT[names.Length];
      for (int x = 0; x < VertexLists.Length; x++)
      {
        VertexLists[x] = new VertexList();
        Values[x] = (enumT)Enum.Parse(typeof(enumT), names[x]);
      }
    }

    public void Add(CustomVertex.PositionColored vert, enumT value)
    {
      for (int x = 0; x < Values.Length; x++)
        if (Values[x].Equals(value))
          VertexLists[x].Add(vert);
    }
    public void Add(Vector3 vert, enumT value)
    {
      for (int x = 0; x < Values.Length; x++)
        if (Values[x].Equals(value))
          VertexLists[x].Add(vert);
    }
    public void Add(Vector3 vert, Color color, enumT value)
    {
      for (int x = 0; x < Values.Length; x++)
        if (Values[x].Equals(value))
          VertexLists[x].Add(vert, color);
    }

    #region IEnumerable<VertexList> Members

    public IEnumerator<VertexList> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion
  }

  public partial class RadiosityRenderer
  {
    #region Debug Members
    RadiosityIntersection d_mouseIntersection = RadiosityIntersection.None;
    //public static List<Vector3[]> d_lines = new List<Vector3[]>(100000);
    public static VertexListCollection<RadiosityDebugPointListID> d_points = new VertexListCollection<RadiosityDebugPointListID>();//new CustomVertex.PositionColored[Enum.GetNames(typeof(RadiosityDebugPointListID)).Length][];
    public static VertexListCollection<RadiosityDebugLineListID> d_lines = new VertexListCollection<RadiosityDebugLineListID>();//new CustomVertex.PositionColored[Enum.GetNames(typeof(RadiosityDebugLineListID)).Length][];
    //static int d_pointPos = 0;
    //static int d_linePos = 0;
    static int d_pointListIndex = 0;
    static int d_lineListIndex = 0;

    [Interfaces.DebugConsole.ConsoleAttribute("rad_txt")]
    public static bool DrawDebugText = true;
    [Interfaces.DebugConsole.ConsoleAttribute("rad_dots", "A boolean value whether or not to draw debug points.")]
    public static bool DrawDebugPoints = true;
    [Interfaces.DebugConsole.ConsoleAttribute("rad_lines")]
    public static bool DrawDebugLines = true;
    public static bool collideModels = false;
    #endregion

    public static RadiosityRenderer Instance
    {
      get { return _renderer; }
    }

    static RadiosityRenderer()
    {
      _renderer = new RadiosityRenderer(null);

      
    }

    public static void AddDebugPoint(Vector3 point, RadiosityDebugPointListID list)
    {
      lock (d_points)
      {
        d_points.Add(new CustomVertex.PositionColored(point, Color.White.ToArgb()), list);
      }
    }
    public static void AddDebugPoint(Vector3 point)
    {
      AddDebugPoint(point, RadiosityDebugPointListID.AllPurpose);
    }
    
    public static void AddDebugRay(Vector3 origin, Vector3 direction, RadiosityDebugLineListID list)
    {
      lock (d_lines)
      {
        d_lines.Add(origin, list);
        d_lines.Add(origin + (direction * 0.1f), list);
      }
    }
    public static void AddDebugRay(Vector3 origin, Vector3 direction)
    {
      AddDebugRay(origin, direction, RadiosityDebugLineListID.AllPurpose);
    }

    [Interfaces.DebugConsole.Console("savephotonmap")]
    public static void SavePhotonMap()
    {
      if (Instance.photonMap != null)
      {
        string path = Core.Prometheus.Instance.ProjectManager.ProjectFolder.RootPath + "\\phtn.map";
        Instance.photonMap.SaveToFile(path,true);
        Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Wrote the photon map to file.");
      }
    }
    [Interfaces.DebugConsole.Console("loadphotonmap")]
    public static void LoadPhotonMap()
    {
      string path = Core.Prometheus.Instance.ProjectManager.ProjectFolder.RootPath + "\\phtn.map";
      if (File.Exists(path))
      {
        try
        {
          PhotonMapping.PhotonMap map = new Core.Radiosity.PhotonMapping.PhotonMap(100);
          map.LoadFromFile(path);
          Instance.photonMap = map;
          Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Successfully loaded photon map with " + map.store.Length + " photons.");

          
        }
        catch (Exception a)
        {
          Interfaces.Output.Write(Interfaces.OutputTypes.Error, a.Message);
          Interfaces.Output.Write(Interfaces.OutputTypes.Error, a.StackTrace);
        }
      }
      else
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "No photon map file detected.");
    }
    [Interfaces.DebugConsole.Console("testphotonmap")]
    public static void TestPhotonMap()
    {
      Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Now testing photon map data structure...");
      int count = Instance.photonMap.TestPhotonMap();
      Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Test complete. " + count + " photons were not found.");
    }

    [Interfaces.DebugConsole.Console("setlightmapscale")]
    public static void SetLightmapScale(float newScale)
    {
      RadiosityHelper.LightmapScale = newScale;
    }

    [Interfaces.DebugConsole.Console("radpointnames")]
    public static void PointListNames()
    {
      string[] names = Enum.GetNames(typeof(RadiosityDebugPointListID));
      Interfaces.Output.Write(Interfaces.OutputTypes.Debug, "", names);
    }
    [Interfaces.DebugConsole.Console("radlinenames")]
    public static void LineListNames()
    {
      string[] names = Enum.GetNames(typeof(RadiosityDebugLineListID));
      Interfaces.Output.Write(Interfaces.OutputTypes.Debug, "", names);
    }
    [Interfaces.DebugConsole.Console("radshowpoints")]
    public static void ShowPointList(string name)
    {
      string[] names = Enum.GetNames(typeof(RadiosityDebugPointListID));
      int index = 0; for (; index < names.Length; index++) if (names[index].ToLower() == name.ToLower()) break;
      if (index < names.Length)
      {
        d_pointListIndex = index;
        Interfaces.Output.Write(Interfaces.OutputTypes.Debug, "Changed to: " + names[index]);
      }
    }
    public static void NextPointList()
    {
    }
    [Interfaces.DebugConsole.Console("radshowlines")]
    public static void ShowLineList(string name)
    {
      string[] names = Enum.GetNames(typeof(RadiosityDebugLineListID));
      int index = 0; for (; index < names.Length; index++) if (names[index].ToLower() == name.ToLower()) break;
      if (index < names.Length)
      {
        d_lineListIndex = index;
        Interfaces.Output.Write(Interfaces.OutputTypes.Debug, "Changed to: " + names[index]);
      }
    }
    public static void NextLineList()
    {
    }

    public static void RefreshTextures()
    {
      Instance.UpdateViewportLightmaps();
    }

    [Interfaces.DebugConsole.Console("dolightmap", "Uses the photon map created by the last run to do the lightmap again.")]
    public static void DoLightmapping()
    {
      System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(Instance.CreateLightmaps));
      //Instance.CreateLightmaps();
    }

    [Obsolete("Use the progress properties.")]
    public static int CompletedPhotons
    {
      get { return Instance.photonsComplete; }
    }

    public static bool UpdateRequested
    {
      get { return Instance.updateRequested; }
    }
    public static bool UpdateInProgress
    {
      get { return Instance.updateInProgress; }
    }
    public static bool StopRequested
    {
      get { return Instance.stopRequested; }
    }

    [Interfaces.DebugConsole.Console("radstop")]
    public static void RequestStop()
    {
      Instance.stopRequested = true;
    }
    public static void RequestUpdate()
    {
      Instance.updateRequested = true;
    }

    public static int PhotonCount
    {
      get { return Instance.m_maxPhotons; }
    }
    public static int StoreCount
    {
      get { if ((Instance.photonMap != null) && (Instance.photonMap.store != null)) return Instance.photonMap.store.Length; else return 0; }
    }

    #region Progress
    public static RadiosityStage CurrentStage { get { return Instance.p_currentStage; } }
    public static string CurrentOperation { get { return Instance.p_currentOperation; } }
    public static int Progress
    {
      get
      {
        if (CurrentStage == RadiosityStage.TreeBalancing)
          return Instance.photonMap.Progress;
        else
          return Instance.p_progress;
      }
    }
    public static int ProgressTotal 
    { 
      get 
      {
        if (CurrentStage == RadiosityStage.TreeBalancing)
          return Instance.photonMap.Total;
        else 
          return Instance.p_progressTotal; 
      } 
    }
    #endregion
  }
}
