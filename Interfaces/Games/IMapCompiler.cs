using System;
using System.IO;
using Interfaces.Pool;

namespace Interfaces.Games
{
  /// <summary>
  /// Provides a base for a map file compiler.
  /// </summary>
  public interface IMapCompiler
  {
    /// <summary>
    /// Adds a library to the list referenced at compile time.
    /// </summary>
    /// <param name="library">library to add</param>
    void AddLibrary(ILibrary library);

    /// <summary>
    /// Removes a library from the list referenced at compile time.
    /// </summary>
    /// <param name="library">library to remove</param>
    void RemoveLibrary(ILibrary library);

    /// <summary>
    /// Compiles a set of top-level tags into a cache file.
    /// </summary>
    /// <param name="topLevelTags">top level tags to compile from</param>
    /// <param name="output">stream to compile to. must exist already.</param>
    void Compile(string[] topLevelTags, Stream output);
  }
}
