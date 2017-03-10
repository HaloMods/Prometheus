using System;
using Microsoft.DirectX.Direct3D;
using Interfaces.Rendering.Instancing;

namespace Interfaces.Rendering.Interfaces
{
  public interface IDynamicObject : IRenderable, IInstanceable
  {
    /// <summary>
    /// Gets the number of available color sources.
    /// </summary>
    int ColorSourceCount { get; }

    /// <summary>
    /// Returns a pseudo-random permutation within the available permutation bounds for the given color source.
    /// </summary>
    int GetColorPermutation(int source);

    /// <summary>
    /// Gets a dynamic object color given the specified parameters.
    /// </summary>
    ColorValue GetColor(int source, int permutation, float interpolator);

    /// <summary>
    /// Gets a list of dynamic output values provided by this object.
    /// </summary>
    float[] OutputFunctions { get; }

    /// <summary>
    /// Gets the pieces used by the dynamic object renderer to draw the dynamic object.
    /// </summary>
    InstanceCollection DynamicInstances { get; }
  }
}
