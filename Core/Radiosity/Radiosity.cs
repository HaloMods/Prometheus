#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
//using System.Threading.Tasks;
using Interfaces.Rendering.Primitives;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using Core.Rendering;
using CDebug = Core.Radiosity.ConsoleDebug;
using Core.Radiosity.TextureMapping;
using Core.Radiosity.PhotonMapping;

using Interfaces.Games;
using Interfaces.Rendering;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Radiosity;
using Core.Libraries;
#endregion
using Interfaces.Rendering.Wrappers;
using System.Linq;

namespace Core.Radiosity
{
  /// <summary>
  /// Represents a photon based radiosity rendering system.
  /// </summary>
  public sealed partial class RadiosityRenderer : Component
  {
    private static RadiosityRenderer _renderer;

    public delegate void ProcessingCompleteHandler();
    public delegate void ProgressChangeHandler(int val);

    public event ProcessingCompleteHandler OnComplete;
    private  TextureMapCollection m_textures;
    public List<ILight> m_lights;
    private List<IModel> m_models;
    private  List<IBsp> m_bsp;
    private Plane[] m_worldBounds;
    private bool m_saveProgress;
    public  int m_maxPhotons;
    private int m_maxBounces;
    private int m_photonsLost;
    private ScenarioBase _scenario;

    private volatile PhotonMap photonMap;

    private volatile int lightIndex;
    private volatile int photonIndex;
    private volatile int photonsComplete = 0;
    private volatile bool saveRequested = false;
    private volatile bool stopRequested = false;
    private volatile bool updateRequested = false;

    private volatile RadiosityStage p_currentStage = RadiosityStage.NotStarted;
    private volatile string p_currentOperation = "";
    private volatile int p_progress = -1;
    private volatile int p_progressTotal = -1;
    
    private volatile bool updateInProgress = false;
    private Thread radiosityThread;

    /// <summary>
    /// Creates a new instance of Render.
    /// </summary>
    /// <param name="container">Container to place this component in.</param>
    public RadiosityRenderer(IContainer container)
    {
      // Initialise collections.
      m_bsp = null;
      this.m_lights = new List<ILight>();
      this.m_models = new List<IModel>();

      m_textures = new TextureMapCollection();

      // Initialise properties.
      m_maxPhotons = 25;
      this.m_maxBounces = 5;
      this.m_photonsLost = 0;
      this.m_saveProgress = false;

      RenderCore.OnRender += new EventHandler(RenderCore_OnRender);
      Prometheus.Instance.RenderWindow_MouseMoveEvent += new System.Windows.Forms.MouseEventHandler(Instance_RenderWindow_MouseMoveEvent);
      Prometheus.Instance.RenderWindow_MouseUpEvent += new System.Windows.Forms.MouseEventHandler(Instance_RenderWindow_MouseUpEvent);
    }
    
    private void UpdateViewportLightmaps()
    {
      string path = (Prometheus.Instance.ProjectManager.ProjectFolder as DiskFileLibrary).RootPath;
      SetOperation("Updating lightmaps...");
      DiskFileLibrary _folder = Prometheus.Instance.ProjectManager.ProjectFolder as DiskFileLibrary;
      // write all the new lightmaps to 
      foreach (IBsp bsp in m_bsp)
      {
        for (int lIndex = 0; lIndex < m_textures.Count; lIndex++)
        {
          SetOperation("Updating lightmap #" + (lIndex + 1) + "...");
          try
          {
            Texture texture = TextureLoader.FromFile(MdxRender.Device, path + @"LightMaps\lightmap_" + lIndex + ".bmp");
            bsp.UpdateLightmap(lIndex, texture);
          }
          catch (Microsoft.DirectX.Direct3D.InvalidDataException)
          {
            // Dunno why this happens... but we don't want it happening....
          }
        }
      }
    }

    private struct HDRSample { public RealColor AVG; public int Count; public HDRSample(RealColor avg, int count) { AVG = avg; Count = count; } }
    private void CreateLightmaps(object obj)
    {
      CreateLightmaps();
    }
    private void CreateRender()
    {
      int screenWidth = MdxRender.Device.Viewport.Width;
      int screenHeight = MdxRender.Device.Viewport.Height;
      float dist2 = RadiosityHelper.GatherDistance * RadiosityHelper.GatherDistance;

      Bitmap renderBitm;// = new Bitmap(screenWidth, screenHeight);
      float[,,] hdr = new float[screenWidth, screenHeight,3];
      ChangeStage(RadiosityStage.TextureGeneration, screenWidth * screenHeight);
      SetOperation("Rendering...");
      int tenPercent = screenWidth / 10;
      int left = screenWidth/2 - tenPercent;
      int right = screenWidth/2 + tenPercent;
      for (int y=0;y<screenHeight;y++)
        for (int x = 0; x < screenWidth; x++)
        {
          Vector3 direction, origin;
          MdxRender.CalculatePickRayWorld(x, y, out direction, out origin);
          //AddDebugRay(origin, direction);

          RadiosityIntersection intersect = m_bsp[0].RadiosityIntersect(origin, direction);
          //AddDebugPoint(intersect.Position);

          if (!intersect.NoIntersection)
          {
            Vector3 normal = m_bsp[0].GetFaceNormal(intersect.LightmapIndex, intersect.MaterialIndex, intersect.FaceIndex);
            List<CompressedPhoton> photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)intersect.Position, dist2, 10000);
            RealColor sum = RealColor.Black.Copy();//new RealColor(photons.Count, photons.Count, photons.Count);

            if (photons.Count == 0)
              System.Diagnostics.Debugger.Break();
            foreach (CompressedPhoton phot in photons)
            {
              float dotP = Vector3.Dot(-phot.Direction, normal);
              if (dotP < 0)
                dotP = 0;

              sum.Add(phot.Power.Copy().Multiply(dotP));

            }
            if ((sum.G > sum.B) && (sum.G > sum.R))
            {
              if (x >= left)
                if (x <= right)
                {
                  if (photons.Count > 100)
                  {
                    
                    AddDebugRay(origin, direction);
                    AddDebugPoint(origin);
                    
                    foreach (var photon in photons) AddDebugPoint(photon.position.ToVector3());
                  }
                }
              //System.Diagnostics.Debugger.Break();
            }
            //sum.Multiply(1 / (dist2 * (float)Math.PI));
            //sum.Multiply(intersect.Material.AmbientLight);
            for (int c = 0; c < 3; c++)
              hdr[x, y, c] = sum[c];
          }
          else
          {
            hdr[x, y, 0] = 0;
            hdr[x, y, 1] = 0;
            hdr[x, y, 2] = 0;
          }
          IncrementProgress();
        }
      //renderBitm = LinearTonemap(hdr);
      Bitmap tempBitmap = new Bitmap(screenWidth, screenHeight);
      //Graphics g = Graphics.FromImage(tempBitmap);
      //g.DrawImage(renderBitm, 0, 0);
      //g.Dispose();
      //renderBitm.Dispose();
      tempBitmap.Save(@"C:\Users\David\render.bmp");
      return;
    }
    private void CreateLightmaps()
    {
      // Stage 2: Render onto lightmaps
      //   * Step 1: Initialize
      //   * Step 2: Iterate through textures
      //     * Iterate through materials
      //       * Compute a pixel rectangle for the current material
      //       * Iterate through the pixels in the material
      //         * Convert the UV pixel coordinates to a 3D point
      //         * Gather n photons that are on that surface

      int screenWidth = MdxRender.Device.Viewport.Width;
      int screenHeight = MdxRender.Device.Viewport.Height;
      float dist2 = RadiosityHelper.GatherDistance * RadiosityHelper.GatherDistance;      

      if (m_bsp == null)
      {
        _scenario = Prometheus.Instance.ProjectManager.ScenarioTag as ScenarioBase;

        if (_scenario == null)
          throw new RadiosityException("The current project has no scenario tag or the scenario tag is invalid.");

        if (_scenario.BspList.Count <= 0)
          throw new RadiosityException("The current project's scenario tag does not contain a bsp tag or the bsp tag is invalid.");

        SetOperation("Retrieving lighting information...");
        m_bsp = _scenario.BspList;
        WorldBounds bounds = m_bsp[0].WorldBounds;
        foreach (IBsp bsp in m_bsp)
          bounds &= bsp.WorldBounds;

        // We need to find the six planes of world bounds.
        m_worldBounds = bounds.CalculatePlanes();

        for (int i = 0; i < m_bsp.Count; i++)
        {
          // Add the DirectX texture to the high dynamic range texture collection.
          foreach (BaseTexture _texture in m_bsp[i].Lightmaps)
          {
            TextureMap _lightmap = new TextureMap(_texture);
            m_textures.AddTexture(_lightmap);
          }
        }
      }

      Vector3 badPoint = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
      string path = (Prometheus.Instance.ProjectManager.ProjectFolder as DiskFileLibrary).RootPath + "LightMaps\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      //float dist2 = RadiosityHelper.GatherDistance * RadiosityHelper.GatherDistance;
      if ((photonMap != null) && (photonMap.store.Length > 0))
      {
        int totalPixels = 0;

        foreach (TextureMap texMap in m_textures)
          totalPixels += (int)Math.Ceiling(texMap.Width * texMap.Height * RadiosityHelper.LightmapScale * RadiosityHelper.LightmapScale);

        ChangeStage(RadiosityStage.TextureGeneration, totalPixels);

        int texIndex = 0;
        float hemisphereSizeDivisor = 1f / ((float)Math.PI * dist2);
        float maxIntensity = float.MinValue;
        foreach (TextureMap texMap in m_textures)
        {
          CreateLightmap(dist2, badPoint, path, texIndex, hemisphereSizeDivisor, texMap, ref maxIntensity);
          texIndex++;
        }
      }
      UpdateViewportLightmaps();
    }
    

    class RectangleBounds<T> where T:IComparable<T>
    {
      public T left, right, top, bottom;

      public RectangleBounds(T x, T y)
      {
        left = right = x;
        top = bottom = y;
      }

      public void Update(T x, T y)
      {
        if (left.CompareTo(x) > 0)
          left = x;
        if (right.CompareTo(x) < 0)
          right = x;
        if (top.CompareTo(y) > 0)
          top = y;
        if (bottom.CompareTo(y) < 0)
          bottom = y;
      }
    }

    private void CreateLightmap(float dist2, Vector3 badPoint, string path, int texIndex, float hemisphereSizeDivisor, TextureMap texMap, ref float maxIntensity)
    {
      int gatherCount = 100;

      int width = (int)(texMap.Width);// * RadiosityHelper.LightmapScale);
      int height = (int)(texMap.Height);// * RadiosityHelper.LightmapScale);
      float heightF = (float)texMap.Height;// *RadiosityHelper.LightmapScale;
      float widthF = (float)texMap.Width;// *RadiosityHelper.LightmapScale;
      float currentMaxIntensity = float.MinValue;
      float diffuse = (float)RadiosityHelper.RadiosityDiffuseConstant;
      widthF -= 1f;
      heightF -= 1f;

      SetOperation("Creating texture #" + (texIndex + 1));
      //List<CompressedPhoton> photons;

      Bitmap bitm = new Bitmap(width, height, PixelFormat.Format32bppRgb);

      RadiosityMaterial mat; Vector3 norm;

      for (int x=0;x<width;x++)
        for (int y=0;y<heightF;y++)
          bitm.SetPixel(x,y,m_bsp[0].ConvertUVTo3D(x,y, texIndex,1, out mat, out norm) != Vector3.Empty ? new RealColor(1,1,1).ToARGB() : RealColor.Black.ToARGB());
      bitm.Save("k:\\convmap_" + texIndex + "_" + 1);

      //CreateLightmapWork(dist2, ref badPoint, texIndex, hemisphereSizeDivisor, texMap, width, height, heightF, widthF, ref currentMaxIntensity);

      // We are going to cycle through the materials of the bsp.
      EnhancedMesh[] meshes = m_bsp[0].GetMeshes(texIndex);
      for (int m = 0; m < meshes.Length; m++)
      {
        EnhancedMesh material = meshes[m];
        int faceCount = material.Indices.Length;
        RectangleBounds<float> bounds = new RectangleBounds<float>(material.Vertices[0].u2, material.Vertices[0].v2);

        // First we're going to figure out a rectangle for this material.
        for (int v = 0; v < material.Vertices.Length; v++)
          bounds.Update(material.Vertices[v].u2, material.Vertices[v].v2);
        int x = (int)Math.Floor((widthF * bounds.left));
        int startX = x;
        int endX = (int)Math.Ceiling(widthF * bounds.right);
        int y = (int)Math.Floor(heightF * bounds.top);
        int endY = (int)Math.Ceiling(heightF * bounds.bottom);

        //System.Diagnostics.Debugger.Break();

        for (; y <= endY; y++)
        {
          x = startX;
          for (; x <= endX; x++)
          {
            RadiosityMaterial illMaterial;
            Vector3 faceNormal;

              //if (y == 81)
              // // if (x == 2)
                //System.Diagnostics.Debugger.Break();
            Vector3 worldPoint = m_bsp[0].ConvertUVTo3D(x, y, texIndex, m, out illMaterial, out faceNormal);
            //AddDebugRay(worldPoint, faceNormal);
            
            if (worldPoint != Vector3.Empty)
            {
              AddDebugPoint(worldPoint, RadiosityDebugPointListID.EstimateLocations);

              var photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)worldPoint, dist2, gatherCount, faceNormal);

              RealColor estimate = RealColor.Black;

              if (photons.Count > 0)
              {
                for (int p = 0; p < photons.Count; p++)
                {
                  if (photons.list[p].photonPtr == null)
                    continue;
                  float dotP = Vector3.Dot(photons.list[p].photonPtr.Direction, faceNormal);
                  if (dotP < 0)
                  {
                    dotP *= -1;
                    //AddDebugPoint(photons.list[p].photonPtr
                    //AddDebugRay(photons.list[p].photonPtr.position.ToVector3(), photons.list[p].photonPtr.Direction);
                  }

                  estimate.Add(photons.list[p].photonPtr.Power.Copy().Multiply(dotP));
                }

                estimate.Multiply(diffuse);
                estimate.Multiply(hemisphereSizeDivisor);
                estimate.Multiply(illMaterial.AmbientLight);
                //estimate.Multiply(1f / photons.Count);

                if (RadiosityHelper.DoDistantLights)
                {
                  if (illMaterial.DistantLightCount > 1)
                  {
                    estimate.LambertianShade(faceNormal, illMaterial.DistantLight2Color, illMaterial.DistantLight2Direction, illMaterial.AmbientLight);
                    estimate.LambertianShade(faceNormal, illMaterial.DistantLight1Color, illMaterial.DistantLight1Direction, illMaterial.AmbientLight);
                  }
                  else if (illMaterial.DistantLightCount > 0)
                    estimate.LambertianShade(faceNormal, illMaterial.DistantLight1Color, illMaterial.DistantLight1Direction, illMaterial.AmbientLight);
                }
                texMap.SetPixel(x, y, estimate);
              }
              else
                texMap.SetPixel(x, y, new RealColor(Color.Pink));
            }
            //else continue; // if there is no normal, the estimate is useless.
          }
        }
      }

      if (currentMaxIntensity > maxIntensity)
        maxIntensity = currentMaxIntensity;

      texMap.SaveHDR(path + "lightmap_" + texIndex + ".hdr");
      bitm = texMap.Filter(new LinearToneMapper(), false);
      
      bitm.Save(path + "lightmap_" + texIndex + ".bmp");
    }

   /* private void CreateLightmapWork(float dist2, ref Vector3 badPoint, int texIndex, float hemisphereSizeDivisor, TextureMap texMap, int width, int height, float heightF, float widthF, ref float currentMaxIntensity)
    {
      List<CompressedPhoton> photons;
      Parallel.For(0, width, delegate(int x)
      {
        for (int y = 0; y < height; y++)
        {
          if (stopRequested)
            return;

          Vector3 normal;
          RadiosityMaterial material;
          Vector2 curUV = new Vector2((float)x / widthF, (float)y / heightF);
          Vector3 point = m_bsp[0].ConvertUVTo3D(curUV, texIndex, -1, out material, out normal);

          if (point != Vector3.Empty)
          {
            if (point == badPoint)
              texMap.SetPixel(x, y, RealColor.Black);
            else
            {
              // Gather photons
              if (normal != Vector3.Empty) photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)point, dist2, 10000, normal);
              else photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)point, dist2, 10000);

              // Sort photons to get the ones closest to the hemisphere
              CompressedPhoton[] array = SortPhotons(photons, point, 50);

              // Use helper method to get the lighting estimate.
              RealColor estimate = RadiosityHelper.ComputeLightingEstimate(array, material, normal);
              estimate.Multiply(hemisphereSizeDivisor);

              if (estimate.R > currentMaxIntensity)
                currentMaxIntensity = estimate.R;
              if (estimate.G > currentMaxIntensity)
                currentMaxIntensity = estimate.G;
              if (estimate.B > currentMaxIntensity)
                currentMaxIntensity = estimate.B;

              texMap.SetPixel(x, y, estimate);
            }

            IncrementProgress();
          }
          else p_progressTotal--;
        }
      });
      //return photons;
    } */

    struct WrapperPhoton
    {
      public CompressedPhoton p;
      public float dist2;
    }

    public CompressedPhoton[] SortPhotons(List<CompressedPhoton> photons, Vector3 point, int maxCount)
    {
      WrapperPhoton[] array = new WrapperPhoton[(maxCount < photons.Count) ? maxCount : photons.Count];
      PhotonVector3 photonPoint = point.ToPhotonVector();

      int end = 0;

      for (int x = 0; x < photons.Count; x++)
      {
        float dist = (photons[x].position - photonPoint).ToVector3().LengthSq();
        if (end == maxCount)
        {
          // insert
          int y;
          for (y = 0; y < end; y++)
            if (array[y].dist2 > dist)
              break;

          if (y >= end)
            continue;
          WrapperPhoton tempA, tempB;
          
          tempB = new WrapperPhoton();
          tempB.p = photons[x];
          tempB.dist2 = dist;

          for (y++; y < end; y++)
          {
            tempA = array[y];
            array[y] = tempB;
            tempB = tempA;
          }          
        }
        else if (end == 0)
        {
          array[end] = new WrapperPhoton();
          array[end].dist2 = dist;
          array[end].p = photons[x];
          end++;
        }
        else
        {
          int y;
          for (y = 0; y < end; y++)
            if (array[y].dist2 > dist)
              break;

          if (y >= end)
          {
            if (end != maxCount)
            {
              array[end] = new WrapperPhoton();
              array[end].dist2 = dist;
              array[end].p = photons[x];
              end++;
            }
            continue;
          }
          WrapperPhoton tempA, tempB;

          tempB = new WrapperPhoton();
          tempB.p = photons[x];
          tempB.dist2 = dist;

          for (y++; y < end; y++)
          {
            tempA = array[y];
            array[y] = tempB;
            tempB = tempA;
          }
          if (end != maxCount)
          {
            array[end] = tempB;
            end++;
          }
        }
      }
      CompressedPhoton[] result = new CompressedPhoton[end];
      for (int x = 0; x < end; x++)
        result[x] = array[x].p;
      array = null;
      //photons.Clear();
      return result;
    }

    void Instance_RenderWindow_MouseUpEvent(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      if (photonMap != null)
        if (photonMap.Root != null)
        {
          if ((e.Button & System.Windows.Forms.MouseButtons.Left) == System.Windows.Forms.MouseButtons.Left)
          {
            if (d_mouseIntersection != RadiosityIntersection.None)
            {
              RadiosityMaterial m;
              Vector3 norm;
              Vector3 point = m_bsp[0].ConvertUVTo3D(new Vector2(d_mouseIntersection.U, d_mouseIntersection.V), d_mouseIntersection.LightmapIndex, d_mouseIntersection.MaterialIndex, out m, out norm);//m_bsp[0].ConvertUVTo3D(new Vector2(d_mouseIntersection.U, d_mouseIntersection.V), d_mouseIntersection.LightmapIndex, d_mouseIntersection.MaterialIndex, d_mouseIntersection.FaceIndex, new Vector2(0.0035f, 0.0035f));

              //photonMap.Balance();

              Vector3 normal = m_bsp[0].GetFaceNormal(d_mouseIntersection.LightmapIndex, d_mouseIntersection.MaterialIndex, d_mouseIntersection.FaceIndex);
              normal.Normalize();

              RetrievedPhotons photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)d_mouseIntersection.Position, RadiosityHelper.GatherDistance * RadiosityHelper.GatherDistance, 10000, normal);//GetNearestPhotons(_intersectMB.LightmapIndex, new Vector2(_intersectMB.U, _intersectMB.V), 256, 128, 4f, 1000, 1);
              //Array.Clear(d_points, 0, d_points.Length);
              //d_pointPos = 0;
              //d_linePos = 0;


              for (int x = 0; x < photons.Count; x++)
              {
                if (photons.list[x].photonPtr != null)
                {
                  if (Vector3.Dot(photons.list[x].photonPtr.Direction, normal) > 0)
                  AddDebugPoint(photons.list[x].photonPtr.position.ToVector3());
                  AddDebugRay(photons.list[x].photonPtr.position.ToVector3(), photons.list[x].photonPtr.Direction);
                }
              }
              /*PhotonVector3 pt = d_mouseIntersection.Position.ToPhotonVector();
              float minDist = RadiosityHelper.GatherDistance * RadiosityHelper.GatherDistance;
              int count = 0;
              for (int x = 0; x < photonMap.store.Length; x++)
              {
                var phot = photonMap.store[x];
                var difference = phot.position - pt;
                float dist = (difference.X * difference.X) + (difference.Y * difference.Y) + (difference.Z * difference.Z);
                if (dist <= minDist)
                {
                  AddDebugPoint(phot.position.ToVector3());
                  count++;
                }
              }*/

              AddDebugRay(point, normal);
              AddDebugPoint(point);
              AddDebugPoint(point + normal);
            }
          }
        }
    }
    int d_mouseX=-1, d_mouseY=-1;
    void Instance_RenderWindow_MouseMoveEvent(object sender, System.Windows.Forms.MouseEventArgs e)
    {
      d_mouseX = e.X;
      d_mouseY = e.Y;
      if ((m_bsp != null) && (m_bsp.Count > 0))
      {
        Vector3 direction, origin;
        MdxRender.CalculatePickRayWorld(e.X, e.Y, out direction, out origin);
        //Radiosity.RadiosityRenderer.SavePhotonMap();
        d_mouseIntersection = m_bsp[0].RadiosityIntersect(origin, direction);
      }
    }
    void RenderCore_OnRender(object sender, EventArgs e)
    {
      if (DrawDebugPoints)
        d_points.VertexLists[d_pointListIndex].Draw(MdxRender.Device, PrimitiveType.PointList);
      if (DrawDebugLines)
        d_lines.VertexLists[d_lineListIndex].Draw(MdxRender.Device, PrimitiveType.LineList);
      if (d_mouseIntersection != RadiosityIntersection.None)
        if (DrawDebugText)
          RenderCore.DebugFont.DrawText(null, string.Format("({7},{8}) {5}, {6} : ({3}, {4}) : ({0}, {1}, {2})", d_mouseIntersection.Position.X, d_mouseIntersection.Position.Y, d_mouseIntersection.Position.Z, d_mouseIntersection.U, d_mouseIntersection.V, d_mouseIntersection.LightmapIndex, d_mouseIntersection.MaterialIndex, d_mouseX, d_mouseY), 60, 3, Color.White);
      
    }    

    /// <summary>
    /// Begins calculating a light mapping solution.
    /// </summary>
    /// <exception cref="System.ApplicationException">
    /// Thrown when no BSP is in the current scene graph.
    /// </exception>
    public void Begin()
    {
      //      MdxRender.RenderDebug = false;

      SetOperation("Loading scenario...");
      _scenario = Prometheus.Instance.ProjectManager.ScenarioTag as ScenarioBase;

      if (_scenario == null)
        throw new RadiosityException("The current project has no scenario tag or the scenario tag is invalid.");

      if (_scenario.BspList.Count <= 0)
        throw new RadiosityException("The current project's scenario tag does not contain a bsp tag or the bsp tag is invalid.");

      SetOperation("Retrieving lighting information...");
      m_bsp = _scenario.BspList;
      WorldBounds bounds = m_bsp[0].WorldBounds;
      foreach (IBsp bsp in m_bsp)
        bounds &= bsp.WorldBounds;

      // We need to find the six planes of world bounds.
      m_worldBounds = bounds.CalculatePlanes();

      // Try and obtain any lighting information.
      if (Prometheus.Instance.ProjectManager.ScenarioTag != null)
      {
        this.m_lights = _scenario.WorldLighting;
        this.m_models = _scenario.StaticModels;

        if (m_models == null)
          m_models = new List<IModel>();
      }
      else
      {
        ICamera camera = MdxRender.Camera;
        List<RadiosityLight> lights = new List<RadiosityLight>();
        this.m_lights = new List<ILight>();
        m_lights.Add(new RadiosityLight(camera.Position, new RealColor( 1f, 1f, 1.0f), 20f));
      }

      // Get each lightmap from the currently loaded BSP.
      for (int i = 0; i < m_bsp.Count; i++)
      {
        // Add the DirectX texture to the high dynamic range texture collection.
        foreach (BaseTexture _texture in m_bsp[i].Lightmaps)
        {
          TextureMap _lightmap = new TextureMap(_texture);
          m_textures.AddTexture(_lightmap);
        }
      }
      
      // TODO: Figure out the number of photons each light gets. For now, set them all to use the same amount.
      float totalPower = 0f;
      float maxPower = 0f;
      foreach (ILight light in m_lights)
      {
        totalPower += light.Power;
        maxPower = Math.Max(light.Power, maxPower);
      }

      int directionalPhotons = 0;
      foreach (ILight light in m_lights)
      {
        int photonCount = (int)((float)m_maxPhotons * light.Power / totalPower);//(int)Math.Round((light.Power / totalPower) * (float)m_maxPhotons);
        light.PhotonCount = photonCount;
        light.Color.Multiply(light.Power);
        
        if (light is DirectionalLight)
          directionalPhotons += photonCount;
      }
      bool[,] importance;
      int count;
      ChangeStage(RadiosityStage.CreatingImportanceMap, directionalPhotons);
      SetOperation("Optimizing Pass...");
      for(int l=0;l<m_lights.Count;l++)
      {
        if (m_lights[l] is DirectionalLight)
        {
          DirectionalLight light = m_lights[l] as DirectionalLight;
          if (light.PhotonCount > 0)
          {
            importance = CreateImportanceMap(light.Direction, light.PhotonCount, bounds, out count);
          }
          else { importance = null; count = 0; }
          RadiosityHelper.ImportanceMap = importance;
          RadiosityHelper.ImportanceMapOnPixels = count;
        }
      }

      //currentOperation = "Saving any unsaved data...";
      //this.SaveAll();
      photonMap = new PhotonMap(m_maxBounces * m_maxPhotons);
      SetOperation("Perform radiosity...");
      // Process collisions.
      this.ProcessCollisions();

      ChangeStage(RadiosityStage.Done, 100);

      Interfaces.Output.Write(Interfaces.OutputTypes.Information, m_photonsLost + " photon(s) lost during radiosity.");
      if (OnComplete != null)
        OnComplete();
    }
    public bool[,] CreateImportanceMap(Vector3 lightDirection, int photonCount, WorldBounds bounds, out int importanceMapIntersectCount)
    {
      bool[,] hiresMap;

      importanceMapIntersectCount = 0;
      float width = bounds.X.Difference;
      float height = bounds.Y.Difference;
      float countRoot = (float)Math.Sqrt(photonCount);
      int countX = (int)Math.Ceiling((countRoot * height) / width);
      int countY = (int)Math.Ceiling((countRoot * width) / height);
      float distanceX = width / (float)countX;
      float distanceY = height / (float)countY;

      hiresMap = new bool[countX, countY];

      //lightDirection *= -1; // back to original;
      float xPos, yPos;
      yPos = bounds.Y.Lower;
      for (int y = 0; y < countY; y++)
      {
        xPos = bounds.X.Lower;
        for (int x = 0; x < countX; x++)
        {
          RadiosityIntersection intersect = m_bsp[0].RadiosityIntersect(new Vector3(xPos, yPos, bounds.Z.Upper), lightDirection);
          // DeMorgan's Theorem FTW!
          hiresMap[x, y] = !(intersect.NoIntersection || intersect.WrongSide);
          if (hiresMap[x, y])
            importanceMapIntersectCount++;
          xPos += distanceX;
          IncrementProgress();
        }
        yPos += distanceY;
      }
      //importanceMap = hiresMap;
      return hiresMap;
    }
    public void BeginThreaded()
    {
      radiosityThread = new Thread(new ThreadStart(Begin));
      radiosityThread.Start();
    }

    /// <summary>
    /// Main photon processing algorithm.
    /// </summary>
    private void ProcessCollisions()
    {
      ChangeStage(RadiosityStage.PhotonBouncing, m_maxPhotons);

      photonsComplete = 0;

      // Loop through all the lights.
      for (int _currentLightIndex = 0; _currentLightIndex < this.m_lights.Count; _currentLightIndex++)
      {
        lightIndex = _currentLightIndex;
        if (m_lights[_currentLightIndex] is DiffuseLight)
        {
          DiffuseLight light = m_lights[_currentLightIndex] as DiffuseLight;
          //AddDebugRay(light.Center, light.Normal);
          AddDebugRay(light.Center, light.Normal, RadiosityDebugLineListID.LightDirections);
        }

        if (m_lights[_currentLightIndex] is RadiosityLight)
          (m_lights[_currentLightIndex] as RadiosityLight).pointCount = m_maxPhotons;

        int retryCount = 20;

        photonMap.BeginLight();

        // Loop through the number of photons per light.
        Parallel.For(0, m_lights[lightIndex].PhotonCount, delegate(int _currentPhotonIndex)
        {
          if (stopRequested)
            return;


          if (!updateInProgress)
            SetOperation("Bouncing photons...");

          photonIndex = _currentPhotonIndex;

          int _collisionCount = 0;

          IPhoton _photon;
          lock (this.m_lights[_currentLightIndex])
          {
            // Generate a photon from the current light.
            _photon = this.m_lights[_currentLightIndex].GeneratePhoton();
            AddDebugPoint(_photon.Position, RadiosityDebugPointListID.PhotonSpawn);
            AddDebugRay(_photon.Position, _photon.Direction, RadiosityDebugLineListID.DirectOnly);
          }

          //_photon.Color.Multiply(m_lights[_currentLightIndex].Power * m_lights.Count);

          // Bounce the photon around for the maximum permitted bounces.
          while (true)//_collisionCount < this.m_maxBounces)
          {
            RadiosityIntersection closest = RadiosityIntersection.None;
            float distSq = float.MaxValue;

            if (collideModels)
            {
              for (int x = 0; x < m_models.Count; x++)
              {
                RadiosityIntersection intersect = m_models[x].Intersection(_photon.Direction, _photon.Position);
                if (intersect != RadiosityIntersection.None)
                {
                  //AddDebugPoint(intersect.Position);
                  float dist = (intersect.Position - _photon.Position).LengthSq();
                  if (dist < distSq)
                  {
                    distSq = dist;
                    closest = intersect;
                  }
                }
              }
            }

            for (int x = 0; x < m_bsp.Count; x++)
            {
              // TODO: Test radiosity model to see if changes fixed the issues.

              RadiosityIntersection intersect = m_bsp[x].RadiosityIntersect(_photon.Position, _photon.Direction);
              if ((intersect.NoIntersection) || (intersect.WrongSide))
              {
                continue;
              }

              float dist = float.MaxValue;
              if ((dist = (intersect.Position - _photon.Position).LengthSq()) < distSq)
              {
                closest = intersect;
                distSq = dist;
              }
            }

            // If the diffuse light never collided, it will randomly generate another.
            if ((closest == RadiosityIntersection.None))
            {
              if (m_lights[_currentLightIndex] is DiffuseLight)
                if (_collisionCount < 1)
                  if (retryCount > 0)
                  {
                    retryCount--;
                    _currentPhotonIndex--;
                    break;
                  }

              retryCount = 5;
              break;
            }
            retryCount = 5;

            if (_collisionCount == 0)
              AddDebugPoint(closest.Position, RadiosityDebugPointListID.DirectOnly);
            else
              AddDebugPoint(closest.Position, RadiosityDebugPointListID.IndirectOnly);

            Photon phot = new Photon
            {
              LightmapIndex = (short)closest.LightmapIndex,
              MaterialIndex = (short)closest.MaterialIndex,
              Direction = (PhotonVector3)_photon.Direction,
              position = (PhotonVector3)closest.Position,
              Power = _photon.Color.Copy()
            };

            AddDebugRay(closest.Position, closest.NewDirection, RadiosityDebugLineListID.IndirectOnly);

            _photon.Position = closest.Position;
            _photon.Direction = closest.NewDirection;
            
            lock (photonMap)
            {
              photonMap.Store(phot);
            }

            _photon.Color.Tint(closest.Material.ReflectionTint);

            _collisionCount++;

            if ((closest.Absorbed) || (_collisionCount >= m_maxBounces))
              break;
          }
          photonsComplete++;
          IncrementProgress();
        });
        //photonMap.EndLight();
      }

      Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Finished processing photons...");
      ChangeStage(RadiosityStage.TreeBalancing, 100);
      SetOperation("Balancing the photon map...");
      photonMap.Balance();

      RadiosityRenderer.SavePhotonMap();
      Interfaces.Output.Write(Interfaces.OutputTypes.Information, "Saved the photon map!");

      SetOperation("Updating viewport...");
      try
      {
        //UpdateBspLightmaps();
        CreateLightmaps();
      }
      catch (Exception a)
      {
        SetOperation("Error!.. " + a.Message);
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "Error!.. " + a.Message, a.StackTrace);
      }
      try
      {
        UpdateViewportLightmaps();
      }
      catch (System.Threading.AggregateException a)
      {
        Interfaces.Output.Write(Interfaces.OutputTypes.Error, "Error of type AggregateException thrown.");
        foreach (Exception exc in a.InnerExceptions)
        {
          Interfaces.Output.Write(Interfaces.OutputTypes.Error, "Error: " + exc.Message, exc.StackTrace);
        }
      }

      #region Debug
#if DEBUG
      Console.WriteLine("Done!");
#endif
      #endregion
      stopRequested = false; 
    }
    private List<CompressedPhoton> GetNearestPhotons(int texIndex, Vector2 pixelUV, int width, int height, float dist2, int maxPhotons, int minPhotons)
    {
      List<CompressedPhoton> photons;
      Vector3 point;

      point = m_bsp[0].ConvertUVTo3D(pixelUV, texIndex, -1, -1f, Vector2.Empty);
      if (point != Vector3.Empty)
        if ((photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)point, dist2, maxPhotons)).Count >= minPhotons)
          return photons;

      int x = (int)(pixelUV.X * (float)width);
      int y = (int)(pixelUV.Y * (float)height);
      int lowX = x-1, lowY = y-1, highY = y+1,  highX = x+1;
      if (x - 1 < 0)
        lowX = x;
      if (x + 1 >= width)
        highX = x;
      if (y - 1 < 0)
        lowY = y;
      if (y + 1 >= height)
        highY = y;

      for (int i = lowX; i <= highX;i++)
        for (int j = lowY; j <= highY; j++)
        {
          if ((i == x) && (j == y))
            continue; // skip the middle of the rectangle
          point = m_bsp[0].ConvertUVTo3D(new Vector2((i != 0) ? (float)i / (float)width : 0f, (j != 0) ? (float)j / (float)height : 0f), texIndex, -1, -1f, Vector2.Empty);
          if (point != Vector3.Empty)
            if ((photons = photonMap.RetrieveNearestNeighbors((PhotonVector3)point, dist2, maxPhotons)).Count >= minPhotons)
              return photons;
        }
      return new List<CompressedPhoton>();
    }

    public void CancelProcessing()
    {
      stopRequested = true;
      //while (stopRequested)
     //   Thread.Sleep(100);
    }

    #region Progress related
    private void SetOperation(string op)
    {
      p_currentOperation = op;
    }
    private void ChangeStage(RadiosityStage stage, int totalProgress)
    {
      p_currentStage = stage;
      this.p_progressTotal = totalProgress;
      p_progress = 0;
    }
    private void SetProgress(int curProgress)
    {
      p_progress = curProgress;
    }
    private void IncrementProgress()
    {
      //Monitor.Enter(p_progress);
      p_progress++;
      //Monitor.Exit(p_progress);
    }
    #endregion

  }
}