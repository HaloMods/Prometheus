using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;

namespace Games.Halo2.Compiler.Classes
{
  /// <summary>
  /// Loads and stores all internal Class objects in the Class library.
  /// </summary>
  public class ClassManager
  {
    private const string Namespace = "Games.Halo2.Resources.Classes";

    private List<Class> classes = new List<Class>();

    /// <summary>
    /// Creates a new instance of the ClassManager class.
    /// </summary>
    public ClassManager()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      string[] source = assembly.GetManifestResourceNames();

      foreach (string file in source)
      {
        if (file.IndexOf(Namespace) == 0)
        {
          string name = file.Substring(Namespace.Length + 1);
          name = name.Remove(name.LastIndexOf('.'));
          using (Stream stream = assembly.GetManifestResourceStream(file))
            classes.Add(new Class(stream, name));
        }
      }
    }

    /// <summary>
    /// Gets the Class in the collection with the specified name.
    /// </summary>
    public Class GetClassByName(string name)
    {
      foreach (Class type in classes)
        if (type.Name == name)
          return type;
      return null;
    }

    /// <summary>
    /// Gets the Class in the collection with the specified identifier.
    /// </summary>
    public Class GetClassByID(int id)
    {
      foreach (Class type in classes)
        if (type.ID == id)
          return type;
      return null;
    }
  }
}
