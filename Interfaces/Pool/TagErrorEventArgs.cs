using System;

namespace Interfaces.Pool
{
  /// <summary>
  /// Represents event data for a tag error event.
  /// </summary>
  public class TagErrorEventArgs : EventArgs
  {
    private string error = null;

    /// <summary>
    /// Creates a new instance of the TagErrorEventArgs class.
    /// </summary>
    /// <param name="errorMessage"></param>
    public TagErrorEventArgs(string errorMessage)
    { error = errorMessage; }

    /// <summary>
    /// Gets the error message provided by the tag.
    /// </summary>
    public string ErrorMessage
    {
      get
      { return error; }
    }
  }
}
