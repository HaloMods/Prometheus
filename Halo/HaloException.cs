using System;

namespace Games.Halo
{
  /// <summary>
  /// The exception that is thrown when an error occurs in game-specific Halo processing.
  /// </summary>
  public class HaloException : ApplicationException
  {
    public HaloException(string message, params object[] arguments)
      : base(String.Format(message, arguments))
    { /* I love this job. */ }

    public HaloException(Exception innerException, string message, params object[] arguments)
      : base(String.Format(message, arguments), innerException)
    { /* Don't you? */ }
  }
}
