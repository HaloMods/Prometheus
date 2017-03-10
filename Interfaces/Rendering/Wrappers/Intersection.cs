using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Wrappers
{
  /// <summary>
  /// Provides data for an intersection. Rewritten by ZeldaFreak to accomodate a broader range of uses.
  /// </summary>
  public class Intersection
  {
    protected bool noIntersection = true;
    public static readonly Intersection None = new Intersection(true);

    protected Vector3 position;
    protected float distance;
    protected int faceIndex;
    protected float u;
    protected float v;

    private Intersection(bool noIntersection) : this(Vector3.Empty, float.NaN, -1, float.NaN, float.NaN)
    {
      this.noIntersection = noIntersection;
    }

    /// <summary>
    /// Creates a new instance of the Intersection class.
    /// </summary>
    public Intersection(IntersectInformation input, Vector3 intersectionPosition) : this(intersectionPosition, input.Dist, input.FaceIndex, input.U, input.V)
    {
    }
    /// <summary>
    /// Creates a new instance of RadiosityIntersection
    /// </summary>
    /// <param name="position">The position at which the intersection occurred.</param>
    /// <param name="distance">The distance from the origin to the point of intersection.</param>
    /// <param name="faceIndex">The index to the face which was intersected.</param>
    /// <param name="U">The barycentric U coordinate of the intersection.</param>
    /// <param name="V">The barycentric V coordinate of the intersection.</param>
    /// <param name="newDirection">The new direction of the intersected ray.</param>
    /// <param name="scale">The scale of to apply to the photon's intensity (aka power) after the intersection.</param>
    /// <param name="lightMapIndex">The index to the lightmap to apply tone mapping of the collision to.</param>
    public Intersection(Vector3 intersectPosition, float distance) : this(intersectPosition, distance, -1, float.NaN, float.NaN)
    {
    }
    /// <summary>
    /// Creates a new instance of RadiosityIntersection
    /// </summary>
    /// <param name="position">The position at which the intersection occurred.</param>
    /// <param name="distance">The distance from the origin to the point of intersection.</param>
    /// <param name="faceIndex">The index to the face which was intersected.</param>
    /// <param name="U">The barycentric U coordinate of the intersection.</param>
    /// <param name="V">The barycentric V coordinate of the intersection.</param>
    /// <param name="newDirection">The new direction of the intersected ray.</param>
    /// <param name="scale">The scale of to apply to the photon's intensity (aka power) after the intersection.</param>
    /// <param name="lightMapIndex">The index to the lightmap to apply tone mapping of the collision to.</param>
    public Intersection(Vector3 intersectPosition, float distance, int faceIndex)
      : this(intersectPosition, distance, faceIndex, float.NaN, float.NaN)
    {
    }
    /// <summary>
    /// Creates a new instance of RadiosityIntersection
    /// </summary>
    /// <param name="position">The position at which the intersection occurred.</param>
    /// <param name="distance">The distance from the origin to the point of intersection.</param>
    /// <param name="faceIndex">The index to the face which was intersected.</param>
    /// <param name="U">The barycentric U coordinate of the intersection.</param>
    /// <param name="V">The barycentric V coordinate of the intersection.</param>
    /// <param name="newDirection">The new direction of the intersected ray.</param>
    /// <param name="scale">The scale of to apply to the photon's intensity (aka power) after the intersection.</param>
    /// <param name="lightMapIndex">The index to the lightmap to apply tone mapping of the collision to.</param>
    public Intersection(Vector3 intersectPosition, float intersectDistance, int intersectedFaceIndex, float u, float v)
    {
      noIntersection = false;
      position = intersectPosition;
      distance = intersectDistance;
      faceIndex = intersectedFaceIndex;
      this.u = u;
      this.v = v;
    }
    /// <summary>
    /// Creates a new instance of RadiosityIntersection
    /// </summary>
    /// <param name="position">The position at which the intersection occurred.</param>
    /// <param name="distance">The distance from the origin to the point of intersection.</param>
    /// <param name="faceIndex">The index to the face which was intersected.</param>
    /// <param name="U">The barycentric U coordinate of the intersection.</param>
    /// <param name="V">The barycentric V coordinate of the intersection.</param>
    /// <param name="newDirection">The new direction of the intersected ray.</param>
    /// <param name="scale">The scale of to apply to the photon's intensity (aka power) after the intersection.</param>
    /// <param name="lightMapIndex">The index to the lightmap to apply tone mapping of the collision to.</param>
    public Intersection(Vector3 position, float distance, int faceIndex, Vector2 UV) : this (position, distance, faceIndex, UV.X, UV.Y)
    {
    }

    public bool NoIntersection
    {
      get { return noIntersection; }
    }
    /// <summary>
    /// Gets or sets the distance along the ray where the intersection occurs.
    /// </summary>
    public float Distance
    {
      get
      { return distance; }
      set
      { distance = value; }
    }

    /// <summary>
    /// Gets or sets the face index where the intersection occurs.
    /// </summary>
    public int FaceIndex
    {
      get
      { return faceIndex; }
      set
      { faceIndex = value; }
    }

    /// <summary>
    /// Gets or sets the barycentric U coordinate of the intersection.
    /// </summary>
    public float U
    {
      get
      { return u; }
      set
      { u = value; }
    }

    /// <summary>
    /// Gets or sets the barycentric V coordinate of the intersection.
    /// </summary>
    public float V
    {
      get
      { return v; }
      set
      { v = value; }
    }

    /// <summary>
    /// Gets or sets the X,Y,Z position at which the intersection occured.
    /// </summary>
    public Vector3 Position
    {
      get
      { return position; }
      set
      { position = value; }
    }

    public override string ToString()
    {
      return String.Format("Pos.: {0} Dist.: {1} Face: {2} U, V: {3}, {4}", position, distance, faceIndex, u, v);
    }
    public static explicit operator bool(Intersection a)
    {
      return !a.noIntersection;
    }
    public static explicit operator Intersection(bool intersection)
    {
      return new Intersection(!intersection);
    }
  }
  
}
