using System;
using Microsoft.DirectX;

namespace Core.Rendering.Camera
{
  internal class FrustumPlane
  {
    private Vector3 normal;
    private float distance;

    public Vector3 Normal
    {
      get { return normal; }
      set
      {
        normal = value;
        Normalize();
      }
    }

    public float Distance
    {
      get { return distance; }
      set { distance = value; }
    }

    private void Normalize()
    {
      float denom = (float)(1 / Math.Sqrt((normal.X * normal.X) + (normal.Y * normal.Y) + (normal.Z * normal.Z)));
      normal.X = normal.X * denom;
      normal.Y = normal.Y * denom;
      normal.Z = normal.Z * denom;
      distance = distance * denom;
    }

    public float DistanceToPoint(Vector3 point)
    {
      float value = Vector3.Dot(normal, point) + distance;
      return value;
    }
  }
}
