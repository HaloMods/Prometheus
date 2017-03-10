using System;

namespace Interfaces.Pool
{
  /// <summary>
  /// This interface is the connection between tags in this and game-specific libraries to the core.
  /// Kind of like a header file...
  /// </summary>
  public interface IPool
  {
    /// <summary>
    /// A method used to open a tag and return a handle to the tag.
    /// </summary>
    /// <typeparam name="T">type of the tag to be opened</typeparam>
    /// <param name="name">tag path name of the tag to be opened</param>
    /// <returns>the newly created tag or null if bad call</returns>
    T Open<T>(string name, bool @lock) where T : Tag;

    /// <summary>
    /// A method used to open a tag and return a handle to the tag.
    /// </summary>
    /// <typeparam name="T">type of the tag to be opened</typeparam>
    /// <param name="name">tag path name of the tag to be opened</param>
    /// <returns>the newly created tag or null if bad call</returns>
    T Open<T>(string name, bool locked, string GameID) where T : Tag;

    /// <summary>
    /// A method used to create a tag and return a handle to the tag.
    /// </summary>
    /// <typeparam name="T">type of the tag to be created</typeparam>
    /// <param name="name">tag path name of the tag to be created</param>
    /// <returns>the newly created tag or null if bad call</returns>
    T Create<T>(string name) where T : Tag;

    /// <summary>
    /// Releases a tag from the grasp of another tag.
    /// </summary>
    /// <param name="tag">tag to release</param>
    void Release(Tag tag);

    /// <summary>
    /// Gets the default globals tag for the specified game.
    /// </summary>
    /// <param name="game">game to look up</param>
    /// <returns>the game's default globals tag</returns>
    Tag GetGlobals(string game);
  }
}
