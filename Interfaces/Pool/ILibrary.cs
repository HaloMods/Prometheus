using System;

namespace Interfaces.Pool
{
  /// <summary>
  /// Provides a base for creating a library of tags.
  /// </summary>
  public interface ILibrary
  {
    /// <summary>
    /// Gets a name associated with this library.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Returns all files in the specified path.
    /// </summary>
    string[] GetFileList(string path);

    /// <summary>
    /// Returns all files in the specified path with the specified extension.
    /// </summary>
    string[] GetFileList(string path, string extension);

    /// <summary>
    /// Returns a recursive list of all files in the specified path with the specified extension.
    /// </summary>
    string[] GetFileList(string path, string extension, bool recursive);

    /// <summary>
    /// Returns all folders in the specified path.
    /// </summary>
    string[] GetFolderList(string path);

    /// <summary>
    /// Returns a boolean indicating if the specified file exists in the library.
    /// </summary>
    bool FileExists(string filename);

    /// <summary>
    /// Returns a boolean indicating if the specified folder exists in the library.
    /// </summary>
    bool FolderExists(string path);

    /// <summary>
    /// Creates a file in the archive with the specified name from a byte buffer.
    /// </summary>
    void AddFile(string filename, byte[] buffer);

    /// <summary>
    /// Returns a byte array containing the specified file.
    /// </summary>
    byte[] ReadFile(string filename);

    /// <summary>
    /// Signals that a file has been added to the ILibrary.
    /// </summary>
    event EventHandler<LibraryFileActionArgs> FileAdded;

    /// <summary>
    /// Signals that a file has been removed from the ILibrary.
    /// </summary>
    event EventHandler<LibraryFileActionArgs> FileRemoved;

    /// <summary>
    /// Signals that a folder has been added to the ILibrary.
    /// </summary>
    event EventHandler<LibraryFileActionArgs> FolderAdded;

    /// <summary>
    /// Signals that a folder has been removed from the ILibrary.
    /// </summary>
    event EventHandler<LibraryFileActionArgs> FolderRemoved;
  }

  /// <summary>
  /// Provides event data for an action involving a file in an ILibrary.
  /// </summary>
  public class LibraryFileActionArgs : EventArgs
  {
    private string filename;

    /// <summary>
    /// The filename of the item that is being represented.
    /// </summary>
    public string Filename
    {
      get { return filename; }
    }

    /// <summary>
    /// Creates an instance of the LibraryFileActionArgs class with the specified filename.
    /// </summary>
    public LibraryFileActionArgs(string filename)
    {
      this.filename = filename;
    }
  }
}