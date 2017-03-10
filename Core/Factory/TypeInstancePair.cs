using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Factory
{
  /// <summary>
  /// Represents a paired Type and an instance of that Type.
  /// </summary>
  /// <typeparam name="T">high level type to assign the instance to</typeparam>
  public struct TypeInstancePair<T>
  {
    private Type type;
    private T instance;

    /// <summary>
    /// Initializes the TypeInstancePair structure.
    /// </summary>
    /// <param name="instance">object instance</param>
    public TypeInstancePair(T instance)
    {
      if (instance == null)
        throw new ArgumentNullException("instance", "instance cannot be null.");

      type = instance.GetType();
      this.instance = instance;
    }

    /// <summary>
    /// Gets the Type associated with this object.
    /// </summary>
    public Type Type
    {
      get
      { return type; }
    }

    /// <summary>
    /// Gets the object wrapped by this structure.
    /// </summary>
    public T Instance
    {
      get
      { return instance; }
    }
  }
}
