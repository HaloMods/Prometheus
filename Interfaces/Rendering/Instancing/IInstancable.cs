using System;

namespace Interfaces.Rendering.Instancing
{
  public interface IInstanceable
  {
    /// <summary>
    /// Gets an Instance that can in itself represent this entity.
    /// </summary>
    Instance Instance { get; }
  }
}
