using System;
using System.Collections.Generic;
using Interfaces.Libraries;
using Interfaces.Pool;
using Interfaces.Project;
using Core.Project;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class ProjectReferencesLibrary : ILibrary
  {
    private string name;
    private ProjectFile references;
    private TemplateTagList templates;

    public ProjectReferencesLibrary(string name, ProjectFile references, TemplateTagList templates)
    {
      this.name = name;
      this.references = references;
      this.templates = templates;
      references.FileAdded += references_FileAdded;
      references.FileRemoved += references_FileRemoved;
      this.templates.FileAdded += templates_FileAdded;
      this.templates.FileRemoved += templates_FileRemoved;
    }

    void templates_FileRemoved(object sender, TemplateTagActionArgs e)
    {
      if (FileRemoved != null)
        if (e.Filename.StartsWith("p:\\"))
          FileRemoved(this, new LibraryFileActionArgs(e.Filename.Replace("p:\\", "")));
    }

    void templates_FileAdded(object sender, TemplateTagActionArgs e)
    {
      if (FileAdded != null)
        if (e.Filename.StartsWith("p:\\"))
          FileAdded(this, new LibraryFileActionArgs(e.Filename.Replace("p:\\", "")));
    }

    void references_FileRemoved(object sender, LibraryFileActionArgs e)
    {
      if (FileRemoved != null)
        FileRemoved(this, e);
    }

    void references_FileAdded(object sender, LibraryFileActionArgs e)
    {
      if (FileAdded != null)
        FileAdded(this, e);
    }

    /// <summary>
    /// Gets a name associated with this library.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// Returns all files in the specified path.
    /// </summary>
    public string[] GetFileList(string path)
    {
      return GetFileList(path, "*");
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
      // Get the references.
      string[] results = references.GetFileList(path, extension, recursive);
      List<string> resultsList = new List<string>(results);

      // Add all project references from the template tag list (if they aren't already in the list).
      if (!recursive)
      {
        FolderEntry entry = templates.TemplateTagHierarchy.LocateFolderByPath(path);
        if (entry != null)
        {
          string[] entries = entry.FileList();
          foreach (string filename in entries)
            if (extension == "*" || filename.EndsWith(extension))
              resultsList.Add(filename);
        }
      }
      else
        resultsList.AddRange(templates.TemplateTagHierarchy.GetRecursiveFileList(path));

      return resultsList.ToArray();
    }

    /// <summary>
    /// Returns all folders in the specified path.
    /// </summary>
    public string[] GetFolderList(string path)
    {
      // Get the references.
      string[] results = references.GetFolderList(path);
      List<string> resultsList = new List<string>(results);

      // Add all project references from the template tag list (if they aren't already in the list).
      FolderEntry entry = templates.TemplateTagHierarchy.LocateFolderByPath(path);
      if (entry != null)
        resultsList.AddRange(entry.FolderList());
      return resultsList.ToArray();
    }

    /// <summary>
    /// Returns a boolean indicating if the specified file exists in the library.
    /// </summary>
    public bool FileExists(string filename)
    {
      bool referenceExists = references.FileExists(filename);
      bool templateReferenceExists = (templates.TemplateTagHierarchy.LocateFileByPath(filename) != null);

      return referenceExists || templateReferenceExists;
    }

    /// <summary>
    /// Returns a boolean indicating if the specified folder exists in the library.
    /// </summary>
    public bool FolderExists(string path)
    {
      return references.FolderExists(path) &&
        (templates.TemplateTagHierarchy.LocateFolderByPath(path) != null);
    }

    /// <summary>
    /// Creates a file in the archive with the specified name from a byte buffer.
    /// </summary>
    public void AddFile(string filename, byte[] buffer)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a byte array containing the specified file.
    /// </summary>
    public byte[] ReadFile(string filename)
    {
      throw new NotImplementedException();
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

  }
}
