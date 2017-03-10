using System;
using System.Collections.Generic;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers
{
  /// <summary>
  /// Encapsulates two libraries into a single library that contains only
  /// files that exist in the baseLibrary but not the excludedLibrary.
  /// </summary>
  public class DifferentialLibrary : ILibrary
  {
    private ILibrary baseLibrary;
    private ILibrary excludedLibrary;
    private string name = "";

    public DifferentialLibrary(ILibrary baseLibrary, ILibrary excludedLibrary)
    {
      this.baseLibrary = baseLibrary;
      this.excludedLibrary = excludedLibrary;
      name = "Differential_" + baseLibrary.Name + "-" + excludedLibrary.Name;

      baseLibrary.FileAdded += new EventHandler<LibraryFileActionArgs>(baseLibrary_FileAdded);
      baseLibrary.FileRemoved += new EventHandler<LibraryFileActionArgs>(baseLibrary_FileRemoved);
      excludedLibrary.FileAdded += new EventHandler<LibraryFileActionArgs>(excludedLibrary_FileAdded);
      excludedLibrary.FileRemoved += new EventHandler<LibraryFileActionArgs>(excludedLibrary_FileRemoved);

      baseLibrary.FolderAdded += new EventHandler<LibraryFileActionArgs>(baseLibrary_FolderAdded);
      baseLibrary.FolderRemoved += new EventHandler<LibraryFileActionArgs>(baseLibrary_FolderRemoved);
      excludedLibrary.FolderAdded += new EventHandler<LibraryFileActionArgs>(excludedLibrary_FolderAdded);
      excludedLibrary.FolderRemoved += new EventHandler<LibraryFileActionArgs>(excludedLibrary_FolderRemoved);
    }

    void excludedLibrary_FileRemoved(object sender, LibraryFileActionArgs e)
    {
      if (baseLibrary.FileExists(e.Filename))
        OnFileAdded(e.Filename);
    }

    void excludedLibrary_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if (baseLibrary.FileExists(e.Filename))
        OnFileRemoved(e.Filename);
    }

    void baseLibrary_FileRemoved(object sender, LibraryFileActionArgs e)
    {
      if (!excludedLibrary.FileExists(e.Filename))
        OnFileRemoved(e.Filename);
    }

    void baseLibrary_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if (!excludedLibrary.FileExists(e.Filename))
        OnFileAdded(e.Filename);
    }

    void excludedLibrary_FolderRemoved(object sender, LibraryFileActionArgs e)
    {
      if (baseLibrary.FolderExists(e.Filename))
        OnFolderAdded(e.Filename);
    }

    void excludedLibrary_FolderAdded(object sender, LibraryFileActionArgs e)
    {
      if (baseLibrary.FolderExists(e.Filename))
        OnFolderRemoved(e.Filename);
    }

    void baseLibrary_FolderRemoved(object sender, LibraryFileActionArgs e)
    {
      if (!excludedLibrary.FolderExists(e.Filename))
        OnFolderRemoved(e.Filename);
    }

    void baseLibrary_FolderAdded(object sender, LibraryFileActionArgs e)
    {
      if (!excludedLibrary.FolderExists(e.Filename))
        OnFolderAdded(e.Filename);
    }

    protected void OnFolderAdded(string filename)
    {
      if (FolderAdded != null)
        FolderAdded(this, new LibraryFileActionArgs(filename));
    }

    protected void OnFolderRemoved(string filename)
    {
      if (FolderRemoved != null)
        FolderRemoved(this, new LibraryFileActionArgs(filename));
    }

    protected void OnFileAdded(string filename)
    {
      if (FileAdded != null)
        FileAdded(this, new LibraryFileActionArgs(filename));
    }

    protected void OnFileRemoved(string filename)
    {
      if (FileRemoved != null)
        FileRemoved(this, new LibraryFileActionArgs(filename));
    }

    #region ILibrary Members

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string[] GetFileList(string path)
    {
      return GetFileList(path, "*");
    }

    public string[] GetFileList(string path, string extension)
    {
      return GetFileList(path, extension, false);
    }

    public string[] GetFileList(string path, string extension, bool recursive)
    {
      List<string> setA = new List<string>(baseLibrary.GetFileList(path, extension, recursive));
      List<string> setB = new List<string>();

      foreach (string s in setA)
        if (!excludedLibrary.FileExists(s))
          setB.Add(s);

      if (recursive)
      {
        string[] folders = GetFolderList(path);
        foreach (string folder in folders)
          setB.AddRange(GetFileList(folder, extension, recursive));
      }

      return setB.ToArray();
    }

    public string[] GetFolderList(string path)
    {
      List<string> setA = new List<string>(baseLibrary.GetFolderList(path));
      List<string> setB = new List<string>();

      foreach (string s in setA)
      {
        string folderName = s.Trim('\\');
        if ((GetFileList(folderName).Length > 0) || (GetFolderList(folderName).Length > 0))
          setB.Add(folderName);
       }
      return setB.ToArray();
    }

    //public string[] GetFileList(string path, string extension, bool recursive)
    //{
    //  List<string> setA = new List<string>(baseLibrary.GetFileList(path, extension, recursive));
    //  List<string> setB = new List<string>();

    //  foreach (string s in setA)
    //    if (!excludedLibrary.FileExists(s))
    //      setB.Add(s);

    //  if (recursive)
    //  {
    //    string[] folders = GetFolderList(path);
    //    foreach (string folder in folders)
    //      setB.AddRange(GetFileList(path, extension, recursive));
    //  }

    //  return setB.ToArray();
    //}

    //public string[] GetFolderList(string path)
    //{
    //  List<string> setA = new List<string>(baseLibrary.GetFolderList(path));
    //  List<string> setB = new List<string>();

    //  foreach (string s in setA)
    //    if (!excludedLibrary.FolderExists(s))
    //      setB.Add(s);
    //  return setB.ToArray();
    //}

    public bool FileExists(string filename)
    {
      return (baseLibrary.FileExists(filename) && !excludedLibrary.FileExists(filename));
    }

    public bool FolderExists(string path)
    {
      return (baseLibrary.FileExists(path) && !excludedLibrary.FileExists(path));
    }

    public void AddFile(string filename, byte[] buffer)
    {
      throw new Exception("Adding files is not supported with a DifferentialLibrary.");
    }

    public byte[] ReadFile(string filename)
    {
      throw new Exception("Reading files is not supported with a DifferentialLibrary.");
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

    #endregion
  }
}
