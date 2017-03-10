using System;
using Microsoft.DirectX;

namespace Interfaces.Rendering.Radiosity
{
  public struct Bounds
  {
    private float lower;
    private float upper;
    private float difference;

    public static readonly Bounds None = new Bounds(float.NaN, float.NaN);

    public float Lower { get { return lower;} }
    public float Upper { get { return upper;} }

    public float Difference { get { return difference; } }

    public Bounds(float low, float high)
    {
      lower = low; upper = high;
      difference = high - low;
    }
    public static Bounds operator &(Bounds left, Bounds right)
    {
      return new Bounds(Math.Min(left.lower, right.lower), Math.Max(right.upper, left.upper));
    }
    public static Bounds operator &(Bounds left, float right)
    {
      if (left.lower > right)
        left.lower = right;
      else if (left.upper < right)
        left.upper = right;
      left.difference = left.upper - left.lower;
      return left;
    }
    public static bool operator !=(Bounds left, Bounds right)
    {
      return !(left == right);
    }
    public static bool operator ==(Bounds left, Bounds right)
    {
      return (left.lower == right.lower) && (left.upper == right.upper);
    }
    public bool InBounds(float val)
    {
      return ((val > lower) && (val < upper));
    }
  }
  public struct WorldBounds
  {
    public Bounds X;
    public Bounds Y;
    public Bounds Z;

    public static readonly WorldBounds None = new WorldBounds(Bounds.None, Bounds.None, Bounds.None);

    /// <summary>
    /// Calculates the six planes which make up the world bounds. 
    /// </summary>
    /// <returns>Returns them in the order: Top, Right, Bottom, Left, Front, Back</returns>
    public Plane[] CalculatePlanes()
    {
      // These are arbitrary points. Any four points can be used as long as both the lower and the upper of every dimension is included.
      // Of course, the following algorithm would have to be modified, though, to output the right planes.
      Vector3[] point = new Vector3[] { new Vector3(X.Upper, Y.Lower, Z.Upper),
      new Vector3(X.Upper, Y.Upper, Z.Upper),
      new Vector3(X.Lower, Y.Upper, Z.Upper),
      new Vector3(X.Lower, Y.Lower, Z.Lower) };

      // let A = X.Lower and B = X.Upper
      // center point (Pc) = A + (B-A)/2
      // Pc = (2A + (B-A))/2
      // Pc = (A+B) / 2
      Vector3 boxCenter = new Vector3((X.Upper + X.Lower) * 0.5f, (Y.Upper + Y.Lower) * 0.5f, (Z.Upper + Z.Lower) * 0.5f);

      Plane[] planes = new Plane[6];

      // These two variables are for temporary storage of the plane's normal and d.
      Vector3 normal; float d;

      // We want the vector from the center of the plane to the center of the box.
      // Consider the triangle ABD. The "correct" method for normal calculation is B - A x D - A, but we then 
      // have the problem of which way the normal will point-- outwards, or inwards?

      for (int x = 0; x < 6; x++)
      {
        int basePoint = x - (4 * AboveThree(x));
        normal = boxCenter - ((point[basePoint] + point[AboveThree(x) + basePoint]) * 0.5f);
        normal.Normalize();
        d = -Vector3.Dot(normal, point[basePoint]);

        planes[x] = new Plane(normal.X, normal.Y, normal.Z, d);
      }

      return planes;
    }
    /// <summary>
    /// Returns 1 if the value is above three, else returns 0.
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private int AboveThree(int x)
    {
      return (Math.Abs(x - 3) - Math.Abs(x - 4) + 1) / 2;
    }

    public WorldBounds(Bounds xBounds, Bounds yBounds, Bounds zBounds)
    {
      X = xBounds;
      Y = yBounds;
      Z = zBounds;
    }
    public WorldBounds(Vector3 lowerVector, Vector3 upperVector)
    {
      X = new Bounds(lowerVector.X, upperVector.X);
      Y = new Bounds(lowerVector.Y, upperVector.Y);
      Z = new Bounds(lowerVector.Z, upperVector.Z);
    }

    public bool InBounds(Vector3 point)
    {
      return X.InBounds(point.X) && Y.InBounds(point.Y) && Z.InBounds(point.Z);
    }

    public static WorldBounds operator &(WorldBounds left, WorldBounds right)
    {
      return new WorldBounds(left.X & right.X, left.Y & right.Y, left.Z & right.Z);
    }
    public static WorldBounds operator &(WorldBounds left, Vector3 right)
    {
      left.X &= right.X;
      left.Y &= right.Y;
      left.Z &= right.Z;
      return left;
    }
    public static bool operator !=(WorldBounds left, WorldBounds right)
    {
      return !(left == right);
    }
    public static bool operator ==(WorldBounds left, WorldBounds right)
    {
      return (left.X == right.X) && (left.Y == right.Y) && (left.Z == right.Z);
    }
  }
}