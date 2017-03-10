using System.Collections.Generic;
using System.IO;
using Interfaces.Pool;

namespace Interfaces.Games
{
  /// <summary>
  /// Provides methods and properties used in all map file implementations.
  /// </summary>
  public interface IMapFile
  {
    /// <summary>
    /// A list of file extensions that map to the fourcc of each tag type.
    /// </summary>
    TypeTable TypeTable { get; }

    /// <summary>
    /// Loads the map from the specified file.
    /// </summary>
    void Load(string filename);

    /// <summary>
    /// Loads a tag in preparation for compilation.
    /// </summary>
    void RegisterTag(ILibrary library, string tagName);

    /// <summary>
    /// Compiles the map with all tags currently registered and writes the cache to the output stream.
    /// </summary>
    void CompileCache(Stream output, ILibrary library);
    
    /// <summary>
    /// Gets the filename of the map.
    /// </summary>
    string Filename { get; }

    /// <summary>
    /// Gets a list of all tags in the map.
    /// </summary>
    string[] GetTagList();
    
    /// <summary>
    /// Exports a tag from the map.
    /// </summary>
    /// <param name="path">The tag to extract, including extension.</param>
    byte[] GetTag(string path);

    /// <summary>
    /// Extracts all tags in the map to the given library.
    /// </summary>
    /// <param name="library">library to extract to</param>
    void Decompile(ILibrary library);

    /// <summary>
    /// Calculates the map's checksum by performing an MD5 hash of the tag index.
    /// </summary>
    /// <returns>A byte array representing an MD5 checksum.</returns>
    byte[] CalculateChecksum();

    /// <summary>
    /// Gets the uncompressed length of this cache.
    /// </summary>
    int EoF
    { get; }
  }
}
