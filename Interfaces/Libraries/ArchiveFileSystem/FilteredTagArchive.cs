//using Core.Libraries;
//using Interfaces.Pool;

//namespace Interfaces.Libraries.ArchiveFileSystem
//{
//  public class FilteredTagArchive : ILibrary
//  {
//    private string name;
//    private TagArchive archive;
    
//    public FilteredTagArchive(TagArchive archive)
//    {
//      name = archive.Name + "Filtered";
//      this.archive = archive;
//    }

//    /// <summary>
//    /// Gets a name associated with this library.
//    /// </summary>
//    public string Name
//    {
//      get { return name; }
//    }

//    /// <summary>
//    /// Returns all files in the specified path.
//    /// </summary>
//    public string[] GetFileList(string path)
//    {
//      return GetFileList(path, "*");
//    }

//    /// <summary>
//    /// Returns all files in the specified path with the specified extension.
//    /// </summary>
//    public string[] GetFileList(string path, string extension)
//    {
//      return GetFileList(path, extension, false);
//    }

//    public string[] GetFileList(string path, string extension, bool recursive)
//    {
//      return archive.GetFileList(path, extension, recursive, ResultConstraint.MissingFiles);
//    }

//    /// <summary>
//    /// Returns all folders in the specified path.
//    /// </summary>
//    public string[] GetFolderList(string path)
//    {
//      // TODO: Need to implement a similar filter for this.
//      return archive.GetFolderList(path);
//    }

//    /// <summary>
//    /// Returns a boolean indicating if the specified file exists in the library.
//    /// </summary>
//    public bool FileExists(string filename)
//    {
//      return archive.FileExists(filename);
//    }

//    /// <summary>
//    /// Returns a boolean indicating if the specified folder exists in the library.
//    /// </summary>
//    public bool FolderExists(string path)
//    {
//      return archive.FolderExists(path);
//    }

//    /// <summary>
//    /// Creates a file in the archive with the specified name from a byte buffer.
//    /// </summary>
//    public void AddFile(string filename, byte[] buffer)
//    {
//      archive.AddFile(filename, buffer);
//    }

//    /// <summary>
//    /// Opens a read-only stream to the specified file in the archive.
//    /// </summary>
//    public byte[] ReadFile(string filename)
//    {
//      return archive.ReadFile(filename);
//    }
//  }
//}
