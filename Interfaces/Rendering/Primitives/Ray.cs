using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.DirectX;

namespace Interfaces.Rendering.Primitives
{
  public class Ray
  {
    Vector3 origin;
    Vector3 direction;
    Vector3 reciprocal;

    public Vector3 Origin { get { return origin; } set { origin = value; } }
    public Vector3 Direction { get { return direction; } set { direction = value; reciprocal = new Vector3(1 / direction.X, 1 / direction.Y, 1 / direction.Z); } }
    public Vector3 Reciprocal { get { return reciprocal; } }

    public Ray(Vector3 origin, Vector3 direction)
    {
      this.origin = origin;
      this.direction = direction;
      this.direction.Normalize();

      reciprocal = new Vector3(1 / direction.X, 1 / direction.Y, 1 / direction.Z);
    }

    public static Vector3 ComputeReflectionDirection(Vector3 surfaceNormal, Vector3 direction)
    {
      Vector3 newDir = direction + (2 * surfaceNormal * -Vector3.Dot(surfaceNormal, direction));
      newDir.Normalize();
      return newDir;
    }
    public static Radiosity.RadiosityIntersection IntersectRayOnPlane(Ray ray, Plane plane)
    {
      Vector3 planeNormal = new Vector3(plane.A, plane.B, plane.C);
      planeNormal.Normalize();
      float t, cosAlpha;

      Vector3 intersectionPoint = ComputeIntersectionPoint(ray, plane, out t, out cosAlpha);
      if (intersectionPoint == Vector3.Empty)
        return Radiosity.RadiosityIntersection.None; // parallel
      if (cosAlpha > 0)
        return Radiosity.RadiosityIntersection.None; // facing the same direction
      if (t < 0)
        return Radiosity.RadiosityIntersection.None; // behind

      float distance = (intersectionPoint - ray.origin).Length();

      return new global::Interfaces.Rendering.Radiosity.RadiosityIntersection(intersectionPoint, distance, -1, 0.0f, 0.0f, ComputeReflectionDirection(planeNormal, ray.direction), 1.0f, -1);
    }
    public static Vector3 ComputeIntersectionPoint(Ray ray, Plane plane, out float t, out float cosAlpha)
    {
      Vector3 planeNormal = new Vector3(plane.A, plane.B, plane.C);
      cosAlpha = Vector3.Dot(ray.Direction, planeNormal);
      float vectorOrigin = -(Vector3.Dot(ray.Origin, planeNormal) + plane.D);

      if (cosAlpha == 0)
      {
        t = float.NaN; ;
        return Vector3.Empty; // the ray and plane are parallel.
      }

      t = vectorOrigin / cosAlpha;
      return ray.origin + (ray.direction * t);
    }
    public static Vector3 ComputeIntersectionPoint(Vector3 origin, Vector3 direction, Vector3 planeNormal, float D, out float t, out float cosAlpha)
    {
      cosAlpha = Vector3.Dot(direction, planeNormal);
      float vectorOrigin = -(Vector3.Dot(origin, planeNormal) + D);

      if (cosAlpha <= 0)
      {
        t = float.NaN; ;
        return Vector3.Empty; // the ray and plane are parallel.
      }

      t = vectorOrigin / cosAlpha;

      if (t < 0)
        return Vector3.Empty;

      return origin + (direction * t);
    }
  }
}
