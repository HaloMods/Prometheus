using System;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Interfaces
{
  public interface IDynamicShader : IShader
  {
    /// <summary>
    /// Gets the dynamic color source of this shader.
    /// </summary>
    int DynamicColorSource { get; }

    /// <summary>
    /// Sets the dynamic color for the shader.
    /// </summary>
    ColorValue DynamicColor { set; }
  }
}
