using System;

namespace Interfaces.Sound
{
  /// <summary>
  /// The exception that is thrown when I mess up something to do with sounds.
  /// </summary>
  public class SoundSystemException : ApplicationException
  {
    public SoundSystemException(string message, params object[] arguments)
      : base(String.Format(message, arguments))
    { /* Lovely day out isn't it? */ }

    public SoundSystemException(Exception innerException, string message, params object[] arguments)
      : base(String.Format(message, arguments), innerException)
    { /* Yes, it sure is... */ }
  }
}
