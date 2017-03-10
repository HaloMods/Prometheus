using System;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Instancing.DynamicObjects
{
  /// <summary>
  /// Represents a method that retrieves a color from a dynamic object.
  /// </summary>
  public delegate ColorValue DynamicColorRetrievalMethod(int source, int permutation, float interpolator);
}
