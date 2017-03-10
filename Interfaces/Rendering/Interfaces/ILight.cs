using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Rendering.Primitives;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Interface specification for light in scene.
  /// </summary>
  public interface ILight //: IRenderable
  {
    /// <summary>
    /// Generate a photon for the scene.
    /// </summary>
    /// <returns>A photon with the lights properties.</returns>
    IPhoton GeneratePhoton();

    float Power { get; set; }
    int PhotonCount { get; set; }
    RealColor Color { get; set; }
  }
}
