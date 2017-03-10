using System;

namespace Core
{
  /// <summary>
  /// Represents a fault in the Core functionality.
  /// </summary>
  public class CoreException : ApplicationException
  {
    public CoreException(string message, params object[] arguments)
      : base(String.Format(message, arguments))
    { /* Lovely day out isn't it? */ }

    public CoreException(Exception innerException, string message, params object[] arguments)
      : base(String.Format(message, arguments), innerException)
    { /* Yes, it sure is... */ }
  }
}
