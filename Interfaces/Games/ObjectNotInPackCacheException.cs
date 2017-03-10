using System;

namespace Interfaces.Games
{
  /// <summary>
  /// The exception that is thrown when an object not located within a PackCacheIndex is attempted to be accessed.
  /// </summary>
  public class ObjectNotInPackCacheException : ApplicationException
  {
    public ObjectNotInPackCacheException(string objectName)
      : base("The object '" + objectName + "' could not be located in the proper pack cache index.")
    { }
  }
}
