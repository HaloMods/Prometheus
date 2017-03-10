using System;
using System.Drawing;

namespace Interfaces.Rendering.Interfaces
{
  public interface IEnvironment
  {
    /// <summary>
    /// Gets the ambient lighting color at the given coordinates.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <param name="z">z coordinate</param>
    /// <param name="down">true to get lighting below coordinates; false to get lighting around coordinates</param>
    /// <returns>ambient lighting color</returns>
    Color GetAmbientLighting(float x, float y, float z, float radius, bool down);

    /// <summary>
    /// Gets an ID representing the visibility set for the given point, or -1 if it is not known.
    /// </summary>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <param name="z">z coordinate</param>
    /// <returns>visibility ID</returns>
    int GetVisibilityID(float x, float y, float z);

    /// <summary>
    /// Indicates whether or not the given point is visible to a viewer inside the given visibility ID.
    /// </summary>
    /// <param name="id">visibility ID</param>
    /// <param name="x">x coordinate</param>
    /// <param name="y">y coordinate</param>
    /// <param name="z">z coordinate</param>
    /// <returns>true if the point is visible; false if not</returns>
    bool PointIsVisibleFrom(int id, float x, float y, float z);

    /// <summary>
    /// Indicates whether or not two visibility groups are visible to each other.
    /// </summary>
    /// <param name="idA">visibility group A</param>
    /// <param name="idB">visibility group B</param>
    /// <returns>true if they are visible to each other; false if not</returns>
    bool IDIsVisibleFrom(int idA, int idB);

    /// <summary>
    /// Gets the visibility ID of the camera - this should be cached by the environment.
    /// </summary>
    int CameraID
    { get; }
  }
}
