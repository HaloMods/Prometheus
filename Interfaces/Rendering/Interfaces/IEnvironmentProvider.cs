using System;

namespace Interfaces.Rendering.Interfaces
{
  public interface IEnvironmentProvider
  {
    /// <summary>
    /// Gets the current IEnvironment representing the world.
    /// </summary>
    IEnvironment Environment
    { get; }
  }
}
