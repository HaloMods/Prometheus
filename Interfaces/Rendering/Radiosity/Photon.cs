//
// Photon.cs
// 
// Author: James Dickson   james.dickson@gmail.com
// 
// Company: Prometheus Project
// 
// Version: 1.0
//

using System;
using System.Collections.Generic;

using Microsoft.DirectX;

using Interfaces.Rendering.Interfaces;
using Interfaces.Rendering.Primitives;
using System.IO;

namespace Interfaces.Rendering.Radiosity
{
  public struct PhotonVector3
  {
    public static readonly PhotonVector3 Empty = new PhotonVector3(0f, 0f, 0f);

    public float[] _components;// = new float[3];

    public float X { get { return _components[0]; } set { _components[0] = value; } }
    public float Y { get { return _components[1]; } set { _components[1] = value; } }
    public float Z { get { return _components[2]; } set { _components[2] = value; } }
    public float this[int index] { get { return _components[index]; } set { _components[index] = value; } }
    public PhotonVector3(float x, float y, float z)
    {
      _components = new float[3];
      _components[0] = x;
      _components[1] = y;
      _components[2] = z;
    }

    public static PhotonVector3 operator -(PhotonVector3 left, PhotonVector3 right)
    {
      return new PhotonVector3(right[0] - left[0], right[1] - left[1], right[2] - left[2]);
    }
    public override string ToString()
    {
      return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
    }
    public static explicit operator Vector3(PhotonVector3 vector)
    {
      return new Vector3(vector.X, vector.Y, vector.Z);
    }
    public static explicit operator PhotonVector3(Vector3 vector)
    {
      return new PhotonVector3(vector.X, vector.Y, vector.Z);
    }
    public static bool operator ==(PhotonVector3 left, PhotonVector3 right)
    {
      return (left.X == right.X) && (left.Y == right.Y) && (left.Z == right.Z);
    }
    public static bool operator !=(PhotonVector3 left, PhotonVector3 right)
    {
      return (left.X != right.X) || (left.Y != right.Y) || (left.Z != right.Z);
    }
  }
  public static class _Extensions
  {
    public static Vector3 ToVector3(this PhotonVector3 vector)
    {
      return (Vector3)vector;
    }
    public static PhotonVector3 ToPhotonVector(this Vector3 vector)
    {
      return (PhotonVector3)vector;
    }
  }

  public interface I3DSpace
  {
    PhotonVector3 Position { get; set; }
  }

  public class CompressedPhoton : I3DSpace
  {
    public PhotonVector3 position;
    public PhotonVector3 Position { get { return position; } set { position = value; } }
    public byte Phi, Theta;
    public Vector3 Direction;
    public RealColor Power;
    //public short LightmapIndex, MaterialIndex;

    public override string ToString()
    {
      return string.Format("Position: {0}", position);
    }
    public CompressedPhoton()
    {
      Power = RealColor.Black.Copy();
      position = new PhotonVector3(0f,0f,0f);
    }

    public void SaveToStream(BinaryWriter bw)
    {
      bw.Write(position.X);
      bw.Write(position.Y);
      bw.Write(position.Z);
      bw.Write(Direction.X);
      bw.Write(Direction.Y);
      bw.Write(Direction.Z);
      bw.Write(Power.A);
      bw.Write(Power.R);
      bw.Write(Power.G);
      bw.Write(Power.B);
      //bw.Write(LightmapIndex);
      //bw.Write(MaterialIndex);
      bw.Write(Phi);
      bw.Write(Theta);
    }
    public static CompressedPhoton FromStream(BinaryReader br)
    {
      float a, x, y, z;
      CompressedPhoton phot = new CompressedPhoton();
      x = br.ReadSingle(); y = br.ReadSingle(); z = br.ReadSingle();
      phot.position = new PhotonVector3(x, y, z);
      x = br.ReadSingle(); y = br.ReadSingle(); z = br.ReadSingle();
      phot.Direction = new Vector3(x, y, z);
      a = br.ReadSingle(); x = br.ReadSingle(); y = br.ReadSingle(); z = br.ReadSingle();
      phot.Power = new RealColor(a, x, y, z);
      //phot.LightmapIndex = br.ReadInt16();
      //phot.MaterialIndex = br.ReadInt16();
      phot.Phi = br.ReadByte();
      phot.Theta = br.ReadByte();

      return phot;
    }
  }

  /// <summary>
  /// Describes a photon particle.
  /// </summary>
  internal sealed class Photon : IPhoton
  {
    #region Members
    private RealColor m_colour = new RealColor();
    private Vector3 m_position;
    private Vector3 m_direction;
    private float u, v;
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a photon, usually created by a light source. 
    /// </summary>
    /// <param name="position">Position of photon.</param>
    /// <param name="direction">Initial direction of photon.</param>
    /// <param name="color">Colour of photon</param>
    public Photon(Vector3 position, Vector3 direction, RealColor color)
    {
      this.m_position = position;
      this.m_direction = direction;
      this.m_colour = color.Copy();
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the position vector of the photon.
    /// </summary>
    public Vector3 Position
    {
      get { return this.m_position; }
      set { this.m_position = value; }
    }

    /// <summary>
    /// Gets or sets the direction vector of the photon.
    /// </summary>
    public Vector3 Direction
    {
      get { return this.m_direction; }
      set { this.m_direction = value; }
    }

    /// <summary>
    /// Gets or sets the colour of the photon.
    /// </summary>
    public RealColor Color
    {
      get { return this.m_colour; }
      set { this.m_colour = value; }
    }

    /// <summary>
    /// Gets or sets the U component.
    /// </summary>
    public float U
    {
      get { return this.u; }
      set { this.u = value; }
    }

    /// <summary>
    /// Gets or sets the V component.
    /// </summary>
    public float V
    {
      get { return this.v; }
      set { this.v = value; }
    }
    #endregion

    #region BSP Collision Process
    /// <summary>
    /// Processes a collision between photon and BSP.
    /// </summary>
    /// <param name="bsp">BSP to process.</param>
    /// <returns>If intersection occured.</returns>
    public bool ProcessCollision(List<IBsp> bsp, ITextureMapCollection textureCollection)
    {
      RadiosityIntersection radiosityIntersection;

      for (int i = 0; i < bsp.Count;i++ )
      {
        if ((bool)(radiosityIntersection = bsp[i].RadiosityIntersect(this.m_position, this.m_direction)))
        {
          if (radiosityIntersection.LightmapIndex >= 0)
            if (!radiosityIntersection.WrongSide)
            // Set the pixel in the texture collection to the value of the light colour.
              textureCollection[radiosityIntersection.LightmapIndex].SetPixel(radiosityIntersection.U, radiosityIntersection.V, this.m_colour.ToArray(), textureCollection.Radius);

          // Update current position to point of intersection with BSP.
          this.m_position = radiosityIntersection.Position;
          
          this.Color = new RealColor(radiosityIntersection.TextureSampleColor);
          this.Direction = radiosityIntersection.NewDirection;
          return true;
        }
      }
      return false;

    }
    #endregion

    #region Model Collision Process
    /// <summary>
    /// Detects collisions between models and rays.
    /// </summary>
    /// <param name="model">Model to process.</param>
    /// <returns>result of intersection.</returns>
    public bool ProcessCollision(IModel model)
    {
      RadiosityIntersection intersection;
      if ((bool)(intersection = model.Intersection(this.m_direction, this.m_position)))
      {
        /*float dif = m_colour[0] - (float)intersection.TextureSampleColor.R;
        m_colour[0] += dif * 0.5f;
        dif = m_colour[1] - (float)intersection.TextureSampleColor.G;
        m_colour[1] += dif * 0.5f;
        dif = m_colour[2] - (float)intersection.TextureSampleColor.B;
        m_colour[2] += dif * 0.5f;*/
        m_colour[0] = (float)intersection.TextureSampleColor.R;
        m_colour[1] = (float)intersection.TextureSampleColor.G;
        m_colour[2] = (float)intersection.TextureSampleColor.B;

        //this.m_colour = this.ScalePower(intersection.Scale);
        this.m_direction = intersection.NewDirection;
        this.m_position = intersection.Position;
        return true;
      }
      else
      {
        return false;
      }
    }
    #endregion

    #region Scale power
    /// <summary>
    /// Scales power by shader properties.
    /// </summary>
    private float[] ScalePower(float scale)
    {
      float[] result = new float[3];
      result[0] = this.m_colour[0] * scale;
      result[1] = this.Color[1] * scale;
      result[2] = this.Color[2] * scale;
      return result;
    }
    #endregion

    #region IPhoton Members


    public void ProcessCollision(RadiosityIntersection intersection)
    {
      throw new Exception("The method or operation is not implemented.");
    }

    #endregion
  }
}
