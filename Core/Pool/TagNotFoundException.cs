using System;

namespace Core.Pool
{
  /// <summary>
  /// The exception that is thrown when a tag is attempted to be loaded, but cannot be found.
  /// </summary>
  public class TagNotFoundException : PoolException
  {
    public TagNotFoundException(string message, params object[] arguments)
      : base(message, arguments)
    { /* Most... Intuitive... Class... Ever... */ }
  }
}
