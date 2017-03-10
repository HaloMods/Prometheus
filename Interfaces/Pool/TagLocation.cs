using System;

namespace Interfaces.Pool
{
  /// <summary>
  /// Lists the valid locations for a tag to reside.
  /// </summary>
  public enum TagLocation : byte
  {
    /// <summary>
    /// Scope should be determined by the Pool.  (default)
    /// </summary>
    Auto = 0,
    /// <summary>
    /// Resides in the project folder.
    /// </summary>
    Project,
    /// <summary>
    /// Resides in a prefab archive.
    /// </summary>
    Prefab,
    /// <summary>
    /// Resides in a shared directory.
    /// </summary>
    Shared,
    /// <summary>
    /// Resides in a PTA.
    /// </summary>
    Archive
  }
}
