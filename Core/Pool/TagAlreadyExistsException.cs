using System;

namespace Core.Pool
{
  /// <summary>
  /// The exception that is thrown when a tag already exists in a pool and thus cannot be created again.
  /// </summary>
  public class TagAlreadyExistsException : PoolException
  {
    public TagAlreadyExistsException(string message, params object[] arguments)
      : base(message, arguments)
    { /* Third most intuitive class ever... */ }
  }
}
