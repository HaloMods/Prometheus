using System;

namespace Core.Pool
{
  /// <summary>
  /// The exception that is thrown when an error occurs in the tag pool.
  /// </summary>
  public class PoolException : CoreException
  {
    public PoolException(string message, params object[] arguments)
      : base(message, arguments)
    { /* Fourth most intuitive class ever... */ }

    public PoolException(Exception innerException, string message, params object[] arguments)
      : base(innerException, String.Format(message, arguments))
    { /* Fifth mo... No, wait... */ }
  }
}
