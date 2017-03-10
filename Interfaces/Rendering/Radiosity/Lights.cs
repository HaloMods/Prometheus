//
// Radiosity.cs
// 
// Author: James Dickson   james.dickson@gmail.com
// 
// Company: Prometheus Project
// 
// Version: 0.1
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

using Interfaces.Rendering.Primitives;
using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Wrappers;

namespace Interfaces.Rendering.Radiosity
{
  #region Enum
  /// <summary>
  /// Enumerator for the type of light in a scene.
  /// </summary>
  public enum RadiosityLightType { Diffuse, Spot, Point };
  #endregion

  /// <summary>
  /// Represents a directional light, or a light that is distributed evenly on a plane.
  /// </summary>
  public class DirectionalLight : ILight
  {
    public Vector3 Direction { get; set;}
    RealColor color;
    float distanceX, distanceY;
    float originX, originY, originZ;
    int countX;
    float power;
    WorldBounds bounds;

    // for use with an importance map
    int perMapPixel;
    float remainderPerPixel;
    float accumulator;
    int pixelsLeft = 0;
    int curPixels = 0;
    //pixel subdivision

    int x, y;
    int pointCount = 0;

    public int PhotonCount
    {
      get { return pointCount; }
      set { pointCount = value; SetPointCount(pointCount); }
    }
    public RealColor Color { get { return color; } set { color = value.Copy(); } }

    public DirectionalLight(Vector3 direction, RealColor colour, WorldBounds bounds, int pointCount, float _power)
    {
      this.Direction = direction;
      this.color = colour.Copy();

      this.bounds = bounds;

      power = _power;

      SetPointCount(pointCount);
    }

    public DirectionalLight(Vector3 direction, RealColor colour, WorldBounds bounds, float _power)
    {
      this.Direction = direction;
      this.color = colour.Copy();

      this.bounds = bounds;

      power = _power;
    }

    RadiosityLight light;
    public void SetPointCount(int pointCount)
    {
      if (RadiosityHelper.ImportanceMap == null)
      {
        float countRoot = (float)Math.Sqrt(pointCount + 1);

        float width = bounds.X.Upper - bounds.X.Lower;
        float height = bounds.Y.Upper - bounds.Y.Lower;

        distanceX = width / countRoot;
        distanceY = height / countRoot;

        originX = bounds.X.Lower;
        originY = bounds.Y.Lower;
        originZ = bounds.Z.Upper;

        countX = (int)Math.Round(countRoot);
      }
      else
      {
        float width = (float)RadiosityHelper.ImportanceMap.GetLength(0);//bounds.X.Difference;
        float height = (float)RadiosityHelper.ImportanceMap.GetLength(1);//bounds.Y.Difference;
        float levelWidth = bounds.X.Difference;
        float levelHeight = bounds.Y.Difference;
        float countRoot = (float)Math.Sqrt(pointCount);
        countX = (int)Math.Ceiling((countRoot * height) / width);
        //countY = (int)Math.Ceiling((countRoot * width) / height);
        distanceX = levelWidth / width;//width / (float)countX;
        distanceY = levelHeight / height;//height / (float)countY;

        float tempDiv = (float)RadiosityHelper.ImportanceMapOnPixels / (float)pointCount;
        perMapPixel = (int)(Math.Floor(tempDiv));
        remainderPerPixel = tempDiv - perMapPixel;

        x = y = curPixels = pixelsLeft = 0;
      }

      //light = new RadiosityLight(direction, color, bounds, pointCount);
    }

    public IPhoton GeneratePhoton()
    {
      IPhoton photon = null;
      if (RadiosityHelper.ImportanceMap == null)
      {
        photon = new Photon(new Vector3(originX + ((x + 1) * distanceX), originY + ((y + 1) * distanceY), originZ - 1f), Direction, color);        

        x++;
        if (x >= countX)
        {
          y++;
          x = 0;
        }
      }
      else
      {
        int tempX = x, tempY = y;
        int height = RadiosityHelper.ImportanceMap.GetLength(1);
          int width = RadiosityHelper.ImportanceMap.GetLength(0);
        if (pixelsLeft == 0)
        {
          // scan for an "on" pixel
          while (y < height)
          {
            while (x < width)
            {
              if (RadiosityHelper.ImportanceMap[x, y])
                break;
              x++;
            }
            x=0;
            y++;
          }
          if (y >= height)
          { // none found
            x = tempX; y = tempY;
          }
          curPixels = pixelsLeft = perMapPixel + (int)Math.Floor(accumulator);
          accumulator += remainderPerPixel;
        }
        if (pixelsLeft != 0)
        {

          if (pixelsLeft == 1)
          {
            photon = new Photon(new Vector3(bounds.X.Lower + (x * distanceX), bounds.Y.Lower + (y * distanceY), bounds.Z.Upper), Direction, color);
          }
          else
          {
            // TODO: do this correctly by evenly distributing within this pixel.
            // When doing this, be sure to do pixelWidth / (pixelsAcross + 1) etc so you don't spawn two photons in the same place.
            photon = new Photon(new Vector3(bounds.X.Lower + (x * distanceX), bounds.Y.Lower + (y * distanceY), bounds.Z.Upper), Direction, color);
            //System.Diagnostics.Debugger.Break(); 
          }

          pixelsLeft--;
        }
      }
      return photon;
    }
    public float Power { get { return power; } set { power = value; } }
  }
  /// <summary>
  /// Represent a diffuse light, or a light which radiates randomly from a triangle.
  /// </summary>
  public class DiffuseLight : ILight
  {
    float power;
    RealColor color;
    Vertex a, b, c;
    public Vector3 Normal { get; set;}
    public Vector3 Center { get; set; }
    public RealColor Color { get { return color; } set { color = value.Copy(); } }

    public DiffuseLight(Vertex[] triangle, RealColor color, float power)
    {
      a = triangle[0]; b = triangle[1]; c = triangle[2];

      this.color = color.Copy();

      this.power = power;
      Normal = RadiosityHelper.ComputeTriangleNormal(a, b, c);
      Center = Vector3.BaryCentric(a.position, b.position, c.position, 0.333333f, 0.333333f);
    }
    public DiffuseLight(Vertex[] triangle, RealColor color, float power, bool transparent)
    {
      a = triangle[0]; b = triangle[1]; c = triangle[2];

      this.color = color.Copy();

      this.power = power;
      Normal = RadiosityHelper.ComputeTriangleNormal(a, b, c);
      if (!transparent)
        Normal *= -1f;
      Center = Vector3.BaryCentric(a.position, b.position, c.position, 0.333333f, 0.333333f);
    }
    public DiffuseLight Transform(BindingTransform transform)
    {
      Vector4 vector = Vector3.Transform(a.position, transform.matrix);
      a.position = new Vector3(vector.X, vector.Y, vector.Z);
      vector = Vector3.Transform(b.position, transform.matrix);
      b.position = new Vector3(vector.X, vector.Y, vector.Z);
      vector = Vector3.Transform(c.position, transform.matrix);
      c.position = new Vector3(vector.X, vector.Y, vector.Z);
      return this;
    }

    #region ILight Members

    public IPhoton GeneratePhoton()
    {
      float u = (float)RadiosityHelper.RandomDouble;
      float v = (float)RadiosityHelper.RandomDouble;   
      float w = (float)RadiosityHelper.RandomDouble;
      
      float sum = u + v + w;
      u /= sum; v /= sum;

      Vector3 position = Vector3.BaryCentric(a.position, b.position, c.position, u, v);
      position += (Normal * 0.005f);

      #region Random Direction
      /*float x = ((float)RadiosityHelper.Random.NextDouble() * 2f) - 1f;
      if (x == 0f)
        RadiosityHelper.Random = new Random();
      float y = ((float)RadiosityHelper.Random.NextDouble() * 2f) - 1f;
      if (y == 0f)
        RadiosityHelper.Random = new Random();
      float z = ((float)RadiosityHelper.Random.NextDouble() * 2f)- 1f; 
      if (z == 0f)
        RadiosityHelper.Random = new Random();
      Vector3 direction = new Vector3(x, y, z);
      direction.Normalize();*/
      #endregion

      double f = RadiosityHelper.RandomDoubleRange(2.0, -1.0); // get it within the range of -1 to +1

      Vector3 direction = Normal * (float)Math.Cos(f);

      return new Photon(position, direction, color);
    }

    public float Power
    {
      get
      {
        return power;
      }
      set
      {
        power = value;
      }
    }

    #endregion

    public int PhotonCount { get; set; }
  }

  /// <summary>
  /// Radiosity light within a scene.
  /// </summary>
  public class RadiosityLight : ILight
  {
    public static Primitives.BoundingBox scenarioBox;

    #region Members
    private Random m_randomNumberGen;
    private Vector3 m_direction;
    private Vector3 m_position;
    public RealColor m_colour;
    private float m_power;

    private WorldBounds bounds;
    private float width = 0; float height = 0;
    private int increment = 0;
    public int pointCount = 0;

    // DX3D version:
    private Light m_light;
    #endregion

    public RealColor Color { get { return m_colour; } set { m_colour = value.Copy(); } }
   
    #region Diffuse constructor
    /// <summary>
    /// Constructs a diffuse light.
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="colour"></param>
    public RadiosityLight(Vector3 direction, RealColor colour, WorldBounds bounds, int pointCount)
    {
      this.m_randomNumberGen = new Random();
      this.m_direction = direction;
      this.m_colour = colour.Copy();

      // Create DX3D version:
      this.m_light = new Light();
      this.m_light.Type = LightType.Directional;
      /*this.m_light.Diffuse = Color.FromArgb((int)(m_colour[0] * 255),
          (int)(m_colour[1] * 255),
          (int)(m_colour[2] * 255));*/
      this.m_light.Direction = this.m_direction;

      this.bounds = bounds;
      this.pointCount = pointCount;
      width = bounds.X.Upper - bounds.X.Lower;
      height = bounds.Y.Upper - bounds.Y.Lower;
    }
    #endregion

    #region Point constructor
    /// <summary>
    /// Constructs a point light.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="colour"></param>
    /// <param name="power"></param>
    public RadiosityLight(Vector3 position, RealColor colour, float power)
    {
      this.m_randomNumberGen = new Random();

      this.m_position = position;
      this.m_colour = colour;
      this.m_power = power;

      // Create DX3D version:
      this.m_light = new Light();
      this.m_light.Type = LightType.Point;
      this.m_light.Diffuse = System.Drawing.Color.FromArgb((int)(m_colour[0] * 255),
          (int)(m_colour[1] * 255),
          (int)(m_colour[2] * 255));
      this.m_light.Position = this.m_position;
      this.m_light.Attenuation0 = this.m_power;
    }
    #endregion

    /// <summary>
    /// Constructs a spot light.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="direction"></param>
    /// <param name="colour"></param>
    /// <param name="power"></param>
    public RadiosityLight(Vector3 position, Vector3 direction, RealColor colour, float power)
    {
      this.m_randomNumberGen = new Random();
      this.m_position = position;
      this.m_direction = direction;
      m_colour = colour.Copy();
      //this.m_colour = colour;
      this.m_power = power;

      // Create DX version.
      this.m_light = new Light();
      this.m_light.Type = LightType.Spot;
      this.m_light.Diffuse = System.Drawing.Color.FromArgb((int)m_colour[0],
          (int)m_colour[1],
          (int)m_colour[2]);
      this.m_light.Position = m_position;
      this.m_light.Direction = m_direction;
      this.m_light.Range = 1.0f;
      this.m_light.InnerConeAngle = 0.5f;
      this.m_light.OuterConeAngle = 1.0f;
      this.m_light.Falloff = 1.0f;
      this.m_light.Attenuation0 = m_power;
    }

    /// <summary>
    /// Generates a photon along a direction.
    /// </summary>
    /// <returns>Photon as if from a diffuse ambient light.</returns>
    private IPhoton DiffuseScatter()
    {
      //TODO: DiffuseScatter.
      // Create a polygon, then create random points within that
      // polygon.
      // All have the same direction vector.
      //return PointScatter();

      float countRoot = (float)Math.Sqrt(pointCount+1);
      float distanceX = width / countRoot;
      float distanceY = height / countRoot;
      int countX = (int)(width / distanceX);
      int countY = (int)(height / distanceY);

      int y = increment / countY;
      int x = increment % countY;

      increment++;
       return new Photon(new Vector3(bounds.X.Lower + ((x+1) * distanceX), bounds.Y.Lower + ((y+1) * distanceY), bounds.Z.Upper - 1f), m_direction, m_colour);
       

      /*float countRoot = (float)Math.Sqrt(pointCount + 2);
      float countX = ((countRoot * width) / height);
      float countY = ((countRoot * height) / width);
      float distanceX = width / countX;
      float distanceY = height / countY;

      float y = (float)Math.Floor(increment / countY);
      float x = increment - (y * countY); 

      increment++;

      return new Photon(new Vector3(bounds.X.Lower + ((x+1) * distanceX), bounds.Y.Lower + ((y+1) * distanceY), bounds.Z.Upper - 1f), m_direction, m_colour);*/
    }

    /// <summary>
    /// Directional scatter of photons.
    /// </summary>
    /// <returns>Photon as if scattered from a directional light.</returns>
    private IPhoton SpotScatter()
    {
      //TODO: DirectinalScatter.
      return PointScatter();
    }

    #region Uniform point scatter
    /// <summary>
    /// Creates a photon as if from a point light.
    /// </summary>
    /// <returns>A photon with random direction from point light.</returns>
    private IPhoton PointScatter()
    {
      float x, y, z, r;
      do
      {
        x = -1 + 2 * (float)this.m_randomNumberGen.Next(0, 0x7fff) / 0x7fff;
        y = -1 + 2 * (float)this.m_randomNumberGen.Next(0, 0x7fff) / 0x7fff;
        z = -1 + 2 * (float)this.m_randomNumberGen.Next(0, 0x7fff) / 0x7fff;
        r = x * x + y * y + z * z;
      } while (r > 1 || r == 0);

      r = (float)Math.Sqrt(-2 * Math.Log(r, Math.E) / r);
      x *= r; y *= r; z *= r;

      Vector3 _dir = new Vector3(x, y, z);
      _dir.Normalize();

      return new Photon(this.m_position, _dir, this.m_colour);
    }
    #endregion

    public int PhotonCount { get; set; }

    #region Get directx light
    public Light GetDX3DLight
    {
      get { return this.m_light; }
    }
    #endregion

    #region ILight Members
    /// <summary>
    /// Creates a photon dependant on light type.
    /// </summary>
    /// <returns>Photon with particular light properties.</returns>
    /// <exception cref="System.ApplicationException">
    ///     Thrown when an unsupported light type is
    ///     detected.
    /// </exception>
    public IPhoton GeneratePhoton()
    {
      switch (this.m_light.Type)
      {
        case LightType.Point:
          return this.PointScatter();
        case LightType.Spot:
          return this.SpotScatter();
        case LightType.Directional:
          return this.DiffuseScatter();
        default:
          throw new ApplicationException("Unsupported light type");
      }
    }
    #endregion

    #region IRenderable Members
    /// <summary>
    /// Renders the light if it is currently enabled.
    /// </summary>
    public void Render()
    {
      if (this.m_light.Enabled)
      {
        //render the light.
      }
    }

    /// <summary>
    /// Intersection of a ray and lights bounding box.
    /// </summary>
    /// <param name="origin">Starting point of the ray.</param>
    /// <param name="direction">Direction of the ray.</param>
    /// <returns>Result of the light and ray intersect.</returns>
    public bool IntersectRayAABB(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    public Intersection IntersectRay(Vector3 origin, Vector3 direction)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    /// <summary>
    /// This member is not valid for lights.
    /// </summary>
    public int PixelFillCount
    {
      get
      {
        return 0;
      }
      set
      {
        return;
      }
    }

    public bool IntersectCamera(ICamera camera)
    {
      // As a diffuse light can generally be seen from everywhere, just turn it on.
      if (this.m_light.Type == LightType.Directional)
      {
        this.m_light.Enabled = true;
        return true;
      }
      else
      {
        //TODO: frustum culling.
        this.m_light.Enabled = false;
        return false;
      }
    }

    public bool IntersectPlaneAABB(IPlane plane)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region ILight Members


    public IPhoton GeneratePhoton(int photonIndex, int totalPhotons)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion

    #region ILight Members


    public float Power
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    #endregion
  }
}
