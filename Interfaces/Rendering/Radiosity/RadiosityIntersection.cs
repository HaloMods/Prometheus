using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.Drawing;

using Interfaces.Rendering.Interfaces;

namespace Interfaces.Rendering.Radiosity
{
  public class RadiosityIntersection : Wrappers.Intersection
  {
    bool valid = false;
    //bool absorbed = false;
    private Primitives.Ray newRay = null;
    Vector3 newDirection;
    float scaleFactor;
    int lightmapIndex, materialIndex=-1;
    private Color textureSampleColor = Color.Empty;
    private bool wrongSide = false;

    public static new readonly RadiosityIntersection None = new RadiosityIntersection(Wrappers.Intersection.None);

    public Vector3 NewDirection { get { return newDirection; } set { newDirection = value; valid = false; } }
    public Color TextureSampleColor
    {
      get { return textureSampleColor; }
      set { textureSampleColor = value; }
    }
    public int LightmapIndex { get { return lightmapIndex; } set { lightmapIndex = value; } }
    public int MaterialIndex { get { return materialIndex; } set { materialIndex = value; } }
    public float Scale { get { return scaleFactor; } set { scaleFactor = value; } }
    public IMaterial Material { get; set; }
    public Primitives.Ray NewRay
    {
      get { if (!valid) return newRay = new global::Interfaces.Rendering.Primitives.Ray(position, newDirection); else return newRay; }
      set { position = value.Origin; newDirection = value.Direction; valid = false; }
    }
    /// <summary>
    /// Gets or sets a value indicating whether or not the direction of the ray was within 90 degrees of the surface normal.
    /// </summary>
    public bool WrongSide
    {
      get { return wrongSide; }
      set { wrongSide = value; }
    }
    public bool Absorbed
    {
      get;
      set;
    }

    // As of yet unused:
#if DEBUG
    float scatterFactor = float.NaN;
    float photonSpawnCount = float.NaN;
#endif

    public RadiosityIntersection(IntersectInformation ii, Vector3 position, Vector3 newDirection, float scale, int lightMapIndex)
      : this(position, ii.Dist, ii.FaceIndex, ii.U, ii.V, newDirection, scale, lightMapIndex)
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
    public RadiosityIntersection(Vector3 position, float distance, int faceIndex, float U, float V, Vector3 newDirection)
      : base(position, distance, faceIndex, U, V)
    {
      this.newDirection = newDirection;
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
    public RadiosityIntersection(Vector3 position, float distance, int faceIndex, float U, float V, Vector3 newDirection, float scale)
      : base(position, distance, faceIndex, U, V)
    {
      this.newDirection = newDirection;
      scaleFactor = scale;
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
    public RadiosityIntersection(Vector3 position, float distance, int faceIndex, float U, float V, Vector3 newDirection, float scale, int lightMapIndex)
      : base(position, distance, faceIndex, U, V)
    {
      this.newDirection = newDirection;
      scaleFactor = scale;
      this.lightmapIndex = lightMapIndex;      
    }
    public RadiosityIntersection(Wrappers.Intersection baseClass) : base (baseClass.Position, baseClass.Distance, baseClass.FaceIndex, baseClass.U, baseClass.V)
    {
      noIntersection = baseClass.NoIntersection;
    }
  }
}
