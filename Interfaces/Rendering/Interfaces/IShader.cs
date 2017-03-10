using System;
using Microsoft.DirectX.Direct3D;

namespace Interfaces.Rendering.Interfaces
{
  /// <summary>
  /// Defines a shader.
  /// </summary>
  public interface IShader
  {
    /// <summary>
    /// Begins application of a shader, with pass zero.
    /// </summary>
    /// <returns>number of passes</returns>
    int BeginApply();

    /// <summary>
    /// Applies a pass in the shader.
    /// </summary>
    /// <param name="pass">which pass to apply</param>
    void SetPass(int pass);

    /// <summary>
    /// Returns the device to its state before shader application.
    /// </summary>
    void EndApply();

    /// <summary>
    /// Gets or sets the lightmap to apply in tandem with this shader.
    /// </summary>
    Texture Lightmap
    {
      get;
      set;
    }

    /// <summary>
    /// Returns true if this shader is transparent.
    /// </summary>
    bool Transparent
    { get; }
  }
}
