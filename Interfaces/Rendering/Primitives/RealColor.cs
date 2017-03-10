using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Interfaces.Rendering.Interfaces;
using Microsoft.DirectX;

namespace Interfaces.Rendering.Primitives
{
  public struct RealColor
  {
    private static readonly RealColor s_black = new RealColor(1.0f, 0f, 0f, 0f);
    public static RealColor Black { get { return s_black.Copy(); } }

    public float this[int index]
    {
      get
      {
        switch (index)
        {
          case 0: return R;
          case 1: return G;
          case 2: return B;
          case 3: return A;
          default: throw new IndexOutOfRangeException();
        }
      }
      set
      {
        switch (index)
        {
          case 0: R = value; break;
          case 1: G = value; break;
          case 2: B = value;
            break;
          case 3: A = value; break; 
          default: throw new IndexOutOfRangeException();
        }
      }
    }

    public float A { get; set; }
    public float R { get; set; }
    public float G { get; set; }
    public float B { get; set; }

    /*public RealColor()
    {
      A = Black.A;
      R = Black.R;
      G = Black.G;
      B = Black.B;
    }*/
    public RealColor(IRealColor color) : this(color.A, color.R, color.G, color.B)
    {
    }
    public RealColor(System.Drawing.Color color)
      : this((float)color.A / 255f, (float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f)
    {
    }
    public RealColor(float r, float g, float b)
      : this(1.0f, r, g, b)
    {
    }
    public RealColor(float a, float r, float g, float b) : this()
    {
      A = a; R = r; G = g; B = b;
    }

    public RealColor Copy()
    {
      return new RealColor(A, R, G, B);
    }

    public RealColor Multiply(float value)
    {
      R *= value;
      G *= value;
      B *= value;
      return this;
    }
    public RealColor Multiply(RealColor value)
    {
      A *= value.A;
      R *= value.R;
      G *= value.G;
      B *= value.B;
      return this;
    }
    public void Tint(RealColor value)
    {
      Multiply(value.A);
      float other = 1 - value.A;
      Add(new RealColor(value.R * other, value.G * other, value.B * other));
    }
    public RealColor Add(RealColor value)
    {
      R += value.R;
      G += value.G;
      B += value.B;
      return this;
    }

    /// <summary>
    /// Lambertian shades a base color.
    /// </summary>
    /// <param name="baseColor"></param>
    /// <param name="surfaceNormal"></param>
    /// <param name="incomingColor"></param>
    /// <param name="direction"></param>
    /// <returns>base * ambient * Dot(normal, direction)</returns>
    public static RealColor LambertianShade(RealColor baseColor, Vector3 surfaceNormal, RealColor incomingColor, Vector3 direction, RealColor ambient)
    {
      float u = Vector3.Dot(surfaceNormal, direction);
      if (u < 0f)
        return baseColor.Copy();
      RealColor diffuse = baseColor.Copy().Multiply(ambient).Multiply(u);
      diffuse.Add(baseColor);
      //diffuse.Clamp();
      return diffuse;
    }
    public RealColor LambertianShade(Vector3 surfaceNormal, RealColor incomingColor, Vector3 direction, RealColor ambient)
    {
      return RealColor.LambertianShade(this, surfaceNormal, incomingColor, direction, ambient);
    }

    public void Clamp()
    {

      if (A > 1.0f)
        A = 1.0f;
      if (A < 0f)
        A = 0f;
      if (R > 1.0f)
        R = 1.0f;
      if (R < 0f)
        R = 0f;
      if (G > 1.0f)
        G = 1.0f;
      if (G < 0f)
        G = 0f;
      if (B > 1.0f)
        B = 1.0f;
      if (B < 0f)
        B = 0f;
    }

    public override string ToString()
    {
      return string.Format("A: {3} R: {0} G: {1} B: {2}", R, G, B, A);
    }

    public static RealColor Average(RealColor[] values)
    {
      RealColor col = Black.Copy();
      for (int x = 0; x < values.Length; x++)
        col.Add(values[x]);
      col.Multiply(1f / (float)values.Length);
      return col;
    }
    public static RealColor Average(IEnumerable<RealColor> values)
    {
      RealColor col = Black.Copy();
      foreach (RealColor val in values)
        col.Add(val);
      col.Multiply(1f / (float)values.Count());
      return col;
    }

    public float[] ToArray()
    {
      return new float[] { R, G, B };
    }

    public System.Drawing.Color ToARGB()
    {
      return System.Drawing.Color.FromArgb((int)(A * 255f), (int)(R * 255f), (int)(G * 255f), (int)(B * 255f));
    }
  }
}
