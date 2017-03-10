using System;

namespace Interfaces.Policies
{
  /// <summary>
  /// Represents a single, static instance of any class or structure that can be instanciated with no arguments.
  /// </summary>
  /// <typeparam name="T">type of singleton to access</typeparam>
  public static class Singleton<T> where T : new()
  {
    private static T instance = new T();

    /// <summary>
    /// Gets the instance of the class or structure contained by this Singleton.
    /// </summary>
    public static T Instance
    {
      get
      { return instance; }
    }
  }
}
