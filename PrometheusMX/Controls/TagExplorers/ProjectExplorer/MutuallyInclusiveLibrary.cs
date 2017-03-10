using System;
using System.Collections.Generic;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers
{
  /// <summary>
  /// Encapsultes matching entries from two seperate libraries into one.
  /// </summary>
  public class MutuallyInclusiveLibrary : ILibrary, IDisposable
  {
    private ILibrary first;
    private ILibrary second;
    private string name = "";

    public MutuallyInclusiveLibrary(ILibrary first, ILibrary second)
    {
      this.first = first;
      this.second = second;
      name = "MutuallyInclusive_" + first.Name + "-" + second.Name;

      first.FileAdded += new EventHandler<LibraryFileActionArgs>(first_FileAdded);
      second.FileAdded += new EventHandler<LibraryFileActionArgs>(second_FileAdded);
      first.FileRemoved += new EventHandler<LibraryFileActionArgs>(first_FileRemoved);
      second.FileRemoved += new EventHandler<LibraryFileActionArgs>(second_FileRemoved);

      first.FolderAdded += new EventHandler<LibraryFileActionArgs>(first_FolderAdded);
      second.FolderAdded += new EventHandler<LibraryFileActionArgs>(second_FolderAdded);
      first.FolderRemoved += new EventHandler<LibraryFileActionArgs>(first_FolderRemoved);
      second.FolderRemoved += new EventHandler<LibraryFileActionArgs>(second_FolderRemoved);
    }

    void second_FileRemoved(object sender, LibraryFileActionArgs e)
    {
      if (first.FileExists(e.Filename))
        OnFileRemoved(e.Filename);
    }

    void first_FileRemoved(object sender, LibraryFileActionArgs e)
    {
      if (second.FileExists(e.Filename))
        OnFileRemoved(e.Filename);
    }

    void second_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if (first.FileExists(e.Filename))
        OnFileAdded(e.Filename);
    }

    void first_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if (second.FileExists(e.Filename))
        OnFileAdded(e.Filename);
    }

    void second_FolderRemoved(object sender, LibraryFileActionArgs e)
    {
      if (first.FolderExists(e.Filename))
        OnFolderRemoved(e.Filename);
    }

    void first_FolderRemoved(object sender, LibraryFileActionArgs e)
    {
      if (second.FolderExists(e.Filename))
        OnFolderRemoved(e.Filename);
    }

    void second_FolderAdded(object sender, LibraryFileActionArgs e)
    {
      if (first.FolderExists(e.Filename))
        OnFolderAdded(e.Filename);
    }

    void first_FolderAdded(object sender, LibraryFileActionArgs e)
    {
      if (second.FolderExists(e.Filename))
        OnFolderAdded(e.Filename);
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

    protected void OnFolderAdded(string folder)
    {
      if (FolderAdded != null)
        FolderAdded(this, new LibraryFileActionArgs(folder));
    }

    protected void OnFolderRemoved(string folder)
    {
      if (FolderRemoved != null)
        FolderRemoved(this, new LibraryFileActionArgs(folder));
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
      List<string> setA = new List<string>(first.GetFileList(path, extension, recursive));
      List<string> setB = new List<string>();

      foreach (string s in setA)
        if (second.FileExists(s))
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
      List<string> setA = new List<string>(first.GetFolderList(path));
      List<string> setB = new List<string>();

      foreach (string s in setA)
      {
        string folderName = s.Trim('\\');
        if (second.FolderExists(folderName))
        {
          if ((GetFileList(folderName).Length > 0) || GetFolderList(folderName).Length > 0)
            setB.Add(folderName);
        }
      }
      return setB.ToArray();
    }

    public bool FileExists(string filename)
    {
      return (first.FileExists(filename) && second.FileExists(filename));
    }

    public bool FolderExists(string path)
    {
      return (first.FileExists(path) && second.FileExists(path));
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

    ///<summary>
    ///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    ///</summary>
    public void Dispose()
    {
      first.FileAdded -= new EventHandler<LibraryFileActionArgs>(first_FileAdded);
      second.FileAdded -= new EventHandler<LibraryFileActionArgs>(second_FileAdded);
      first.FileRemoved -= new EventHandler<LibraryFileActionArgs>(first_FileRemoved);
      second.FileRemoved -= new EventHandler<LibraryFileActionArgs>(second_FileRemoved);
      
      first.FolderAdded -= new EventHandler<LibraryFileActionArgs>(first_FolderAdded);
      second.FolderAdded -= new EventHandler<LibraryFileActionArgs>(second_FolderAdded);
      first.FolderRemoved -= new EventHandler<LibraryFileActionArgs>(first_FolderRemoved);
      second.FolderRemoved -= new EventHandler<LibraryFileActionArgs>(second_FolderRemoved);
    }
  }
}
