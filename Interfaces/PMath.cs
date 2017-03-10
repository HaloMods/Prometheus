using System;
using Microsoft.DirectX;

namespace Interfaces
{
  /// <summary>
  /// Contains static mathematical functions for use all over this hell of an application.
  /// Also simulates a generic function generator.
  /// Disclaimer: These functions are not guaranteed to model actual Halo functions.
  /// </summary>
  public static class PMath
  {
    private static float phase = 0.0f;
    private static float sparkValue = 0.0f;
    private static double sparkSeconds = -1.0;
    private static float jitterValue = 0.0f;
    private static double jitterSeconds = -1.0;
    private static Random random = new Random();

    /// <summary>
    /// Decompresses an 11.11.10-bit Vector3 from a dword.
    /// </summary>
    /// <param name="compressed_norm">dword vector</param>
    /// <param name="pVector">at least 3-element array of floats for the returned vector</param>
    /// <exception cref="ArgumentException">thrown if pVector is not at least 3 elements long</exception>
    public static void DecompressIntToVector(uint compressed_norm, ref float[] pVector)
    {
      int cx, cy, cz;

      if (pVector.Length < 3)
        throw new ArgumentException("pVector needs to be at least 3 floats long.", "pVector");

      cx = (int)(compressed_norm << 21);
      cy = (int)((compressed_norm >> 11) << 21);
      cz = (int)((compressed_norm >> 22) << 22);

      pVector[0] = (float)((((float)cx / 1048576.0) + 1.0) / 2047.0);
      pVector[1] = (float)((((float)cy / 1048576.0) + 1.0) / 2047.0);
      pVector[2] = (float)((((float)cz / 1048576.0) + 1.0) / 2047.0);

      //float mag = sqrt(pVector[0]*pVector[0] + pVector[1]*pVector[1] + pVector[2]*pVector[2]);
    }

    /// <summary>
    /// Returns 1.0f.
    /// </summary>
    /// <returns>one</returns>
    public static float One()
    { return 1.0f; }

    /// <summary>
    /// Returns 0.0f.
    /// </summary>
    /// <returns>zero</returns>
    public static float Zero()
    { return 0.0f; }

    /// <summary>
    /// Returns a cosine wave form.
    /// </summary>
    /// <param name="period">period of the wave</param>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>cosine wave</returns>
    public static float Cosine(double period, float scale)
    { return (float)Math.Cos((Seconds / Math.Abs(period)) * Math.PI) * scale * Math.Sign(period); }

    /// <summary>
    /// Returns a triangle wave form.
    /// </summary>
    /// <param name="period">period of the wave</param>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>triangle wave</returns>
    public static float Triangle(double period, float scale)
    {
      double x = Seconds / Math.Abs(period);
      if (x % 2.0 < 1.0)
        return (float)(x % 1.0) * scale * Math.Sign(period);
      else
        return (1.0f - (float)(x % 1.0)) * scale * Math.Sign(period);
    }

    /// <summary>
    /// Returns a sawtooth wave form.
    /// </summary>
    /// <param name="period">period of the wave</param>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>sliding, sawtooth wave</returns>
    public static float Sawtooth(double period, float scale)
    { return (float)((Seconds / Math.Abs(period)) % 1.0) * scale * Math.Sign(period); }

    /// <summary>
    /// Returns pseudo-random noise.
    /// </summary>
    /// <param name="scale">amplitude of the noise</param>
    /// <returns>the pseudo-random noise</returns>
    public static float Noise(float scale)
    { return ((float)random.Next(60) / 60.0f) * scale; }

    /// <summary>
    /// Returns a jittering wave.
    /// </summary>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>jitteriness</returns>
    public static float Jitter(float scale)
    {
      if (jitterSeconds - Seconds < 0.0)
      {
        jitterSeconds = Seconds + (double)random.Next(10) / 10.0;
        return jitterValue = ((float)random.Next(4) / 4.0f) * scale;
      }
      else
        return jitterValue;
    }

    /// <summary>
    /// Returns a wandering wave.
    /// </summary>
    /// <param name="period">period of the wave</param>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>wanderingness</returns>
    public static float Wander(double period, float scale)
    { return (float)(Math.Cos((Seconds / Math.Abs(period)) * Math.PI) + Math.Sin((Seconds / Math.Abs(period)) * Math.PI)) * (scale / 1.4142136f) * Math.Sign(period); }

    /// <summary>
    /// Returns a spark-form wave.
    /// </summary>
    /// <param name="scale">amplitude of the wave</param>
    /// <returns>sparkyness</returns>
    public static float Spark(float scale)
    {
      if (sparkSeconds - Seconds < 0.0)
      {
        sparkSeconds = Seconds + (double)random.Next(10) / 20.0;
        return sparkValue = (float)random.Next(1) * scale;
      }
      else
        return sparkValue;
    }

    /// <summary>
    /// Gets how many seconds the environment has been running for.
    /// </summary>
    private static double Seconds
    {
      get { return (double)Environment.TickCount / 1000.0 + phase; }
    }

    /// <summary>
    /// Gets or sets the phase shift used by the function generator.
    /// </summary>
    public static float Phase
    {
      get
      { return phase; }
      set
      { phase = value; }
    }

    /// <summary>
    /// Calculates point of intersection between Ray and Plane.
    /// </summary>
    /// <param name="ray_origin"></param>
    /// <param name="ray_direction"></param>
    /// <param name="plane_normal"></param>
    /// <param name="intersect">returned point of intersection.  Is (0,0,0) when return value is false.</param>
    /// <returns>true if intersection occurs, false otherwise</returns>
    static public bool RayIntersectPlane(Vector3 ray_origin, Vector3 ray_direction, Plane plane, out Vector3 intersect)
    {
      intersect.X = 0;
      intersect.Y = 0;
      intersect.Z = 0;
      bool bIntersected = false;
      float Vd, V0, t;
      Vd = Plane.DotNormal(plane, ray_direction);

      if ((Vd < -0.001f) || (Vd > 0.001f)) //check for parallel to plane
      {
        V0 = -Plane.DotNormal(plane, ray_origin) + plane.D;
        t = V0 / Vd;

        if (t >= 0) //intersection is not behind the ray origin
        {
          intersect.X = ray_origin.X + ray_direction.X * t;
          intersect.Y = ray_origin.Y + ray_direction.Y * t;
          intersect.Z = ray_origin.Z + ray_direction.Z * t;
          bIntersected = true;
        }
      }

      return (bIntersected);
    }
  }
}
