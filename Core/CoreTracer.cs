using System;
using System.Diagnostics;

namespace Core
{
  /// <summary>
  /// Provides methods to perform trace operations in a more simplified manner. (As well as speed things up a bit, and prevent "looking in". :P)
  /// </summary>
  public static class CoreTracer
  {
    /// <summary>
    /// Writes a message in its own line to the trace listeners.
    /// </summary>
    /// <param name="value">message or value to write</param>
    public static void WriteLine(object value)
    {
#if DEBUG
      Trace.WriteLine(value);
#endif
    }

    /// <summary>
    /// Writes a formatted message in its own line to the trace listeners.
    /// </summary>
    /// <param name="message">message to write</param>
    /// <param name="arguments">arguments in the message</param>
    public static void WriteLine(string message, params object[] arguments)
    {
#if DEBUG
      Trace.WriteLine(String.Format(message, arguments));
#endif
    }
  }
}
