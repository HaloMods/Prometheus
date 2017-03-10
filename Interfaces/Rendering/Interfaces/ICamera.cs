using System;
using Microsoft.DirectX;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Exposes methods required of a 3d camera.
  /// </summary>
  public interface ICamera
  {
    /// <summary>
    /// Obtains the frustum planes that represent a 2d box plastered over a 3d scene.
    /// </summary>
    void GetFrustumPlanes(int startX, int startY, int stopX, int stopY, out Plane[] frustumPlanes);

    /// <summary>
    /// Returns the viewer's distance away from the specified point.
    /// </summary>
    float GetObjectDistance(float x, float y, float z);

    /// <summary>
    /// Returns the current view matrix.
    /// </summary>
    Matrix GetViewMatrix();

    /// <summary>
    /// Returns true if the bounding box is within the view frustum.
    /// </summary>
    bool VisibleBoundingBox(BoundingBox box);

    /// <summary>
    /// Returns true if the described sphere is within the view frustum.
    /// </summary>
    bool VisibleBoundingSphere(Vector3 position, float radius);

    /*
    /// <summary>
    /// Taking an AABB min and max in world space, work out its interaction with the view frustum.
    /// </summary>
    /// <returns>0 is outside, 1 is partially in, 2 is completely within.</returns>
    int CullAABB(Vector3 aabbMin, Vector3 aabbMax);
    */

    void Move(float fDistance);
    void Strafe(float fDistance);
    void Up(float fDistance);
    void SetFPS(float fps);
    void Pitch(float fAngle);
    void Yaw(float fAngle);

    Matrix InverseView { get;}

		Vector3 LookVector { get; }
  	void SetLookAt(Vector3 vFrom, Vector3 vTo);
    Vector3 Position { get; set; }

    bool Moved { get; set; }
  }
}
