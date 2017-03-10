using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Interfaces.Libraries
{
  /// <summary>
  /// Stores file and folder paths in a hierarchy that allows searching.
  /// </summary>
  public class FileHierarchy
  {
    public FolderEntry rootFolder = new FolderEntry("", null);

    /// <summary>
    /// Parses a full path containing the folder and filename, and creates
    /// the appropriate folder and file entries in the heirarchy.
    /// </summary>
    public FileEntry Add(string filename)
    {
      string fullPath = filename;
      string[] parts = fullPath.Split('\\');
      FolderEntry currentEntry = rootFolder;
      for (int x = 0; x < parts.Length - 1; x++) // Last part should be a filename.
      {
        int index = currentEntry.FolderEntries.IndexOf(parts[x]);
        if (index == -1)
        {
          FolderEntry entry = new FolderEntry(parts[x], currentEntry);
          currentEntry.FolderEntries.Add(entry);
          currentEntry = entry;
        }
        else
        {
          currentEntry = currentEntry.FolderEntries[index];
        }
      }
      FileEntry file = new FileEntry(parts[parts.Length - 1], currentEntry);
      currentEntry.FileEntries.Add(file);
      return file;
    }

    private string FixPath(string path)
    {
      return path.TrimStart('\\').TrimEnd('\\');
    }

    public string[] GetRecursiveFileList(string path)
    {
      FolderEntry entry = LocateFolderByPath(path);
      if (entry == null)
        return new string[0];
      else
        return entry.GetRecursiveFileList();
    }

    public void VisualizeHierarchy(string filename)
    {
      IndentedTextWriter writer = new IndentedTextWriter(
        new StreamWriter(filename));
      writer.NewLine = "\r\n";
      WriteFolder(writer, rootFolder);
      writer.Close();
    }

    protected void WriteFolder(IndentedTextWriter writer, FolderEntry folder)
    {
      writer.Indent += 2;
      writer.WriteLine("[" + folder.Name + "]");
      foreach (FolderEntry childFolder in folder.FolderEntries)
        WriteFolder(writer, childFolder);
      foreach (string childFile in folder.FileList())
        writer.WriteLine(childFile);
      writer.Indent -= 2;
    }

    public FolderEntry LocateFolderByPath(string path)
    {
      path = FixPath(path);
      if (path == "") return rootFolder;

      string[] parts = path.Split('\\');
      FolderEntry currentEntry = rootFolder;
      // TODO: Consolidate the redundant code between this method and the Add method.
      for (int x = 0; x < parts.Length; x++)
      {
        int index = currentEntry.FolderEntries.IndexOf(parts[x]);
        if (index > -1)
          currentEntry = currentEntry.FolderEntries[index];
        else
          return null;
      }
      return currentEntry;
    }

    public bool RemoveFile(string path)
    {
      FileEntry entry = LocateFileByPath(path);
      if (entry == null)
        return false;
      if (entry.ParentFolder == null) return false;
      entry.ParentFolder.FileEntries.Remove(entry);
      return true;
    }

    public bool RemoveFolder(string path)
    {
      FolderEntry entry = LocateFolderByPath(path);
      if (entry == null)
        return false;
      if (entry.ParentFolder == null) return false;
      entry.ParentFolder.FolderEntries.Remove(entry);
      return true;
    }

    public FileEntry LocateFileByPath(string path)
    {
      path = FixPath(path);
      string folder = Path.GetDirectoryName(path);
      FolderEntry folderEntry = LocateFolderByPath(folder);
      if (folderEntry == null)
        return null;
      foreach (FileEntry fileEntry in folderEntry.FileEntries)
      {
        string entryLower = fileEntry.FullPath.ToLower();
        string pathLower = path.ToLower();
        if (entryLower == pathLower)
          return fileEntry;
      }
      return null;
    }
  }

  /// <summary>
  /// Represents a folder in the heirarchy.
  /// </summary>
  public class FolderEntry
  {
    private string name;
    private FolderEntry parentFolder;
    private FileEntryCollection fileEntries = new FileEntryCollection();
    private FolderEntryCollection folderEntries = new FolderEntryCollection();

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public FolderEntry ParentFolder
    {
      get { return parentFolder; }
    }

    public FileEntryCollection FileEntries
    {
      get { return fileEntries; }
      set { fileEntries = value; }
    }

    public FolderEntryCollection FolderEntries
    {
      get { return folderEntries; }
      set { folderEntries = value; }
    }

    public FolderEntry(string name, FolderEntry parentFolder)
    {
      this.name = name;
      this.parentFolder = parentFolder;
    }

    public string[] FileList()
    {
      List<string> files = new List<string>();
      foreach (FileEntry entry in fileEntries)
        files.Add(entry.FullPath);
      return files.ToArray();
    }

    public string[] FolderList()
    {
      List<string> folders = new List<string>();
      foreach (FolderEntry entry in folderEntries)
        folders.Add(entry.FullPath);
      return folders.ToArray();
    }

    public string FullPath
    {
      get
      {
        FolderEntry entry = this;
        string fullPath = entry.name;
        while (entry.ParentFolder != null)
        {
          entry = entry.ParentFolder;
          fullPath = entry.Name + "\\" + fullPath;
        }
        // HACK: It's adding the root directory as well, which is causing the
        // string to begin with a backslash.  I'm just trimming it off for now
        // rather than fixing the problem.. because I'm lazy ;p
        string fixedPath = fullPath.TrimStart('\\');
        return fixedPath;
      }
    }

    public string[] GetRecursiveFileList()
    {
      List<string> files = new List<string>();
      foreach (FileEntry fileEntry in FileEntries)
        files.Add(fileEntry.FullPath);
      foreach (FolderEntry folderEntry in FolderEntries)
        files.AddRange(folderEntry.GetRecursiveFileList());
      return files.ToArray();
    }
  }

  /// <summary>
  /// Represents a file in the heirarchy.
  /// </summary>
  public class FileEntry
  {
    private string name = "";
    private string extension = "";
    private FolderEntry parentFolder;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public string Extension
    {
      get { return extension; }
      set { extension = value; }
    }

    public FolderEntry ParentFolder
    {
      get { return parentFolder; }
    }

    public string FullPath
    {
      get
      {  
        return (parentFolder.FullPath + "\\" + name + "." + extension).Trim('\\'); 
      }
    }

    public FileEntry(string filename, FolderEntry parentFolder)
    {
      name = Path.GetFileNameWithoutExtension(filename);
      if (filename.IndexOf('.') > -1)
        extension = Path.GetExtension(filename).Substring(1);
      else
        extension = "";
      this.parentFolder = parentFolder;
    }
  }

  /// <summary>
  /// A strongly-typed collection of FolderEntry objects.
  /// </summary>
  public class FolderEntryCollection : CollectionBase
  {
    public void Add(FolderEntry folder)
    {
      if (folder.ParentFolder != null)
        //if (folder.ParentFolder.Name == folder.Name)
          //throw new Exception("Uhhh, double you tee eff?");
      InnerList.Add(folder);
    }
    public void Remove(FolderEntry folder)
    {
      foreach (FileEntry entry in folder.FileEntries.ToArray())
        folder.FileEntries.Remove(entry);
      foreach (FolderEntry entry in folder.FolderEntries.ToArray())
        folder.FolderEntries.Remove(entry);
      InnerList.Remove(folder);
    }
    public FolderEntry[] ToArray()
    {
      FolderEntry[] entries = new FolderEntry[Count];
      for (int x = 0; x < entries.Length; x++)
        entries[x] = this[x];
      return entries;
    }
    public int IndexOf(string name)
    {
      int x = 0;
      foreach (FolderEntry entry in InnerList)
      {
        if (entry.Name == name) return x;
        x++;
      }
      return -1;
    }
    public FolderEntry this[int index]
    {
      get { return (InnerList[index] as FolderEntry); }
    }
    public string[] GetItems()
    {
      ArrayList values = new ArrayList();
      foreach (FolderEntry entry in InnerList)
        values.Add(entry.FullPath);
      return (string[])values.ToArray(typeof(string));
    }
  }

  /// <summary>
  /// A strongly-typed collection of FileEntry objects.
  /// </summary>
  public class FileEntryCollection : CollectionBase
  {
    public void Add(FileEntry file)
    {
      InnerList.Add(file);
    }
    public int IndexOf(string name)
    {
      int x = 0;
      foreach (FileEntry entry in InnerList)
      {
        if ((entry.Name + entry.Extension) == name) return x;
        x++;
      }
      return -1;
    }
    public void Remove(FileEntry entry)
    {
      InnerList.Remove(entry);
    }
    public FileEntry[] ToArray()
    {
      FileEntry[] entries = new FileEntry[Count];
      for (int x = 0; x < entries.Length; x++)
        entries[x] = this[x];
      return entries;
    }
    public FileEntry this[int index]
    {
      get { return (InnerList[index] as FileEntry); }
    }
    public string[] GetItems()
    {
      return GetItems("");
    }
    public string[] GetItems(string extension)
    {
      ArrayList values = new ArrayList();
      foreach (FileEntry entry in InnerList)
        if ((entry.Extension == extension) || (extension == ""))
          values.Add(entry.FullPath);
      return (string[])values.ToArray(typeof(string));
    }
  }
}
