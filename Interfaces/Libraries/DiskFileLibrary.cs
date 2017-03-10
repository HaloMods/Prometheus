using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Interfaces.Pool;

namespace Core.Libraries
{
  /// <summary>
  /// Encapsulates a physical disk folder heirarchy in an ILibrary.
  /// </summary>
  public class DiskFileLibrary : ILibrary
  {
    private string name;
    private string rootPath;
    private FileSystemWatcher watcher;

    public string Name
    {
      get { return name; }
    }

    public string RootPath
    {
      get { return rootPath; }
    }

    public DiskFileLibrary(string rootPath, string name)
    {
      this.name = name;
      this.rootPath = rootPath.Trim('\\');
      watcher = new FileSystemWatcher(this.rootPath);
      watcher.IncludeSubdirectories = true;
      watcher.Created += new FileSystemEventHandler(watcher_Created);
      watcher.Deleted += new FileSystemEventHandler(watcher_Deleted);
      watcher.Renamed += new RenamedEventHandler(watcher_Renamed);
      watcher.EnableRaisingEvents = true;
    }

    void watcher_Renamed(object sender, RenamedEventArgs e)
    {
      if (Directory.Exists(e.FullPath))
      {
        OnFolderRemoved(e.OldFullPath);
        OnFolderAdded(e.FullPath);
      }
      else
      {
        OnFileRemoved(e.OldFullPath);
        OnFileAdded(e.FullPath);
      }
    }

    void watcher_Deleted(object sender, FileSystemEventArgs e)
    {
      OnFileRemoved(e.FullPath);
      OnFolderRemoved(e.FullPath);
    }

    private void watcher_Created(object sender, FileSystemEventArgs e)
    {
      if (File.Exists(e.FullPath))
        OnFileAdded(e.FullPath);
      else if (Directory.Exists(e.FullPath))
        OnFolderAdded(e.FullPath);
    }

    protected void OnFileAdded(string filename)
    {
      string relativePath = filename.Remove(0, rootPath.Length+1);
      if (FileAdded != null)
        FileAdded(this, new LibraryFileActionArgs(relativePath));
    }

    protected void OnFileRemoved(string filename)
    {
      string relativePath = filename.Remove(0, rootPath.Length + 1);
      if (FileRemoved != null)
        FileRemoved(this, new LibraryFileActionArgs(relativePath));
    }

    protected void OnFolderAdded(string folder)
    {
      string relativePath = folder.Remove(0, rootPath.Length + 1);
      if (FolderAdded != null)
        FolderAdded(this, new LibraryFileActionArgs(relativePath));
    }

    protected void OnFolderRemoved(string folder)
    {
      string relativePath = folder.Remove(0, rootPath.Length + 1);
      if (FolderRemoved != null)
        FolderRemoved(this, new LibraryFileActionArgs(relativePath));
    }

    /// <summary>
    /// Returns all files in the specified path.
    /// </summary>
    public string[] GetFileList(string path)
    {
      return (GetFileList(path, "*.*"));
    }

    /// <summary>
    /// Returns all files in the specified path with the specified extension.
    /// </summary>
    public string[] GetFileList(string path, string extension)
    {
      return GetFileList(path, extension, false);
    }
    
    /// <summary>
    /// Returns a recursive list of all files in the specified path with the specified extension.
    /// </summary>
    public string[] GetFileList(string path, string extension, bool recursive)
    {
      return ReformatPaths(GetFiles(rootPath.Trim('\\') + "\\" + path, extension, recursive));
    }

    /// <summary>
    /// Returns a recursive list of all files in the specified path with the specified extension.
    /// This method expects a fully qualified path.
    /// </summary>
    protected string[] GetFiles(string path, string extension, bool recursive)
    {
      if ((extension == null) || (extension == "*")) extension = "*";
      path = path.Trim('\\');

      List<string> results = new List<string>();

      if (Directory.Exists(path))
      {
        string[] files = Directory.GetFiles(path, extension);
        results.AddRange(files);

        if (recursive)
        {
          string[] folders = Directory.GetDirectories(path);
          foreach (string folder in folders)
            results.AddRange(GetFiles(folder, extension, recursive));
        }
      }

      return results.ToArray();
    }

    /// <summary>
    /// Returns all folders in the specified path.
    /// </summary>
    public string[] GetFolderList(string path)
    {
      path = path.Trim('\\');
      if (Directory.Exists(rootPath + "\\" + path))
      {
        string[] results = Directory.GetDirectories(rootPath + "\\" + path);
        return ReformatPaths(results);
      }
      else
        return new string[0];
    }

    /// <summary>
    /// Deletes the specified file from the disk.
    /// </summary>
    public void DeleteFile(string filename)
    {
      filename = rootPath + "\\" + filename.Trim('\\');
      filename = filename.Replace("\\\\", "\\");
      File.Delete(filename);
    }

    /// <summary>
    /// Returns a boolean indicating if the specified file exists in the library.
    /// </summary>
    public bool FileExists(string filename)
    {
      filename = filename.Trim('\\');
      return File.Exists(rootPath + "\\" + filename);
    }

    /// <summary>
    /// Returns a boolean indicating if the specified folder exists in the library.
    /// </summary>
    public bool FolderExists(string path)
    {
      path = path.Trim('\\');
      return Directory.Exists(rootPath + "\\" + path);
    }

    /// <summary>
    /// Creates a file in the archive with the specified name from a byte buffer.
    /// </summary>
    public void AddFile(string filename, byte[] buffer)
    {
      if (!Directory.Exists(Path.GetDirectoryName(rootPath + "\\" + filename)))
        Directory.CreateDirectory(Path.GetDirectoryName(rootPath + "\\" + filename));

      FileStream fs = File.Create(rootPath + "\\" + filename);
      try
      {
        fs.Write(buffer, 0, buffer.Length);
      }
      finally
      {
        fs.Close();
      }
    }

    /// <summary>
    /// Reads a file from the archive into a byte array.
    /// </summary>
    public byte[] ReadFile(string filename)
    {
      BinaryReader br = new BinaryReader(new FileStream(rootPath + '\\' + filename, FileMode.Open));
      try
      {
        byte[] fileData = br.ReadBytes((int)br.BaseStream.Length);
        return fileData;
      }
      finally
      {
        br.Close();
      }
    }

    /// <summary>
    /// Signals that a file has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileAdded;

    /// <summary>
    /// Signals that a file has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileRemoved;

    /// <summary>
    /// Signals that a folder has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderAdded;

    /// <summary>
    /// Signals that a folder has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderRemoved;

    /// <summary>
    /// Removes the base path from a set of path strings.
    /// </summary>
    internal string[] ReformatPaths(params string[] paths)
    {
      for (int x = 0; x < paths.Length; x++)
      {
        paths[x] = paths[x].Substring(rootPath.Length).Trim('\\');
      }
      return paths;
    }

    /// <summary>
    /// Returns all files from the specified folder and all child folders.
    /// </summary>
    public static string[] GetRecursiveFiles(string path)
    {
      return GetRecursiveFiles(path, "*");
    }

    /// <summary>
    /// Returns all files with the specified extension from the specified folder and all child folders.
    /// </summary>
    public static string[] GetRecursiveFiles(string path, string extension)
    {
      extension = "." + extension.Trim('.');
      if (extension == "*") extension = "";

      List<string> results = new List<string>();
      string[] folders = Directory.GetDirectories(path);
      foreach (string folder in folders)
      {
        string[] files = GetRecursiveFiles(folder, extension);
        foreach (string file in files)
          if (Path.GetExtension(file) == extension || extension == ".")
            results.Add(file);
      }
      results.AddRange(Directory.GetFiles(path));
      return results.ToArray();
    }

    public void DeleteFolder(string path)
    {
      if (GetFileList(path).Length > 0 || GetFolderList(path).Length > 0)
        throw new FolderNotEmptyException(path);

      path = rootPath + "\\" + path.Trim('\\');
      path = path.Replace("\\\\", "\\");
      Directory.Delete(path);
    }

    public DateTime GetModifiedTime(string filename)
    {
      string path = rootPath + '\\' + filename;
      return File.GetLastWriteTime(path);
    }

    public long GetFileSize(string filename)
    {
      string path = rootPath + '\\' + filename;
      FileInfo fi = new FileInfo(path);
      return fi.Length;
    }

    /// <summary>
    /// Renames the folder located at the specified path to the provided new name.
    /// </summary>
    public void RenameFolder(string oldPath, string newPath)
    {
      Directory.Move(rootPath + '\\' + oldPath, rootPath + '\\' + newPath);
    }

    /// <summary>
    /// Renames the file located at the specified path to the provided new name.
    /// </summary>
    public void RenameFile(string oldPath, string newPath)
    {
      File.Move(rootPath + '\\' + oldPath, rootPath + '\\' + newPath);
    }
  }

  /// <summary>
  /// Represents an exception in which a folder cannot be deleted because it still
  /// contains other files or folders.
  /// </summary>
  public class FolderNotEmptyException : Exception
  {
    private string path;

    /// <summary>
    /// The path of the folder that cannot be deleted.
    /// </summary>
    public string Path
    {
      get { return path; }
    }

    public FolderNotEmptyException(string path) 
      : base ("The specified folder is not empty and cannot be deleted from the DiskFileLibrary: " + path)
    {
      this.path = path;
    }
  }
}
