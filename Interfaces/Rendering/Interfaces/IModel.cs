using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Describes the type of model.
  /// </summary>
  public enum ModelType
  {
    Scenery,
    Vehicle,
    Weapon,
    Other,
    Collision,
    Unknown
  }

  /// <summary>
  /// Interface specification for model in scene.
  /// </summary>
  public interface IModel : IRenderable
  {
    /// <summary>
    /// Gets the type of object.
    /// </summary>
    ModelType GetModelType { get;}

    /// <summary>
    /// Calculates intersection of ray and model.
    /// </summary>
    /// <param name="direction">Direction of ray.</param>
    /// <param name="origin">Origin of ray.</param>
    /// <param name="point">Point of intersection</param>
    /// <param name="new_dir">New direction of photon.</param>
    /// <param name="new_pow">Light scale power.</param>
    /// <returns>Result of intersection.</returns>
    Radiosity.RadiosityIntersection Intersection(Vector3 direction, Vector3 origin);

    List<ILight> RadiosityLights { get; }
  }
}
