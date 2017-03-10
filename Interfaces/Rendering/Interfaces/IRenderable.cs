using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering;
using Interfaces.Rendering.Wrappers;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Defines functions that renderable objects use.
  /// </summary>
  public interface IRenderable
  {
    /// <summary>
    /// Draws at the current position in the world.
    /// </summary>
    void Render();

    /// <summary>
    /// Intersects a ray with the rendered object's bounding box.
    /// </summary>
    /// <param name="origin">origin of the ray</param>
    /// <param name="direction">direction of the ray</param>
    /// <returns>true if intersection, false if not</returns>
    bool IntersectRayAABB(Vector3 origin, Vector3 direction);

    /// <summary>
    /// Intersects a ray with the rendered object's mesh.
    /// </summary>
    /// <param name="origin">origin of the ray</param>
    /// <param name="direction">direction of the ray</param>
    /// <returns>an IntersectInformation structure or null if no intersection</returns>
    Intersection IntersectRay(Vector3 origin, Vector3 direction);

    /// <summary>
    /// Gets the pixel fill count from occlusion queries.  This interface exists so that
    /// ObjectInstance can update the model implementations.
    /// </summary>
    int PixelFillCount { get; set; }

    /// <summary>
    /// Intersects the object with the camera frustum to determine visibility.
    /// </summary>
    /// <param name="Camera"></param>
    /// <returns>Result of intersection.</returns>
    bool IntersectCamera(ICamera camera);

    /// <summary>
    /// Intersects a plane and the objects Axis Aligned Bounding Box.
    /// </summary>
    /// <param name="Plane"></param>
    /// <returns>Result of intersection.</returns>
    bool IntersectPlaneAABB(IPlane plane);
  }
}
