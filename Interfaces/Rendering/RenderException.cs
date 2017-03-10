using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Rendering
{
  /// <summary>
  /// Represents a fault in the Render functionality.
  /// </summary>
  public class RenderException : ApplicationException
  {
    public RenderException(string message, params object[] arguments)
      : base(String.Format(message, arguments))
    { /* Lovely day out isn't it? */ }

    public RenderException(Exception innerException, string message, params object[] arguments)
      : base(String.Format(message, arguments), innerException)
    { /* Yes, it sure is... */ }
  }
}
