using System;
using System.Collections.Generic;
using System.Text;
using Core.Libraries;
using Interfaces.Pool;
using Core.ArchiveFileSystem;
using System.IO;
using System.Xml;
using System.IO.Compression;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;

namespace Interfaces.Libraries
{
  /// <summary>
  /// Represents a RecycleBin, which allows files to be deleted from and restored to an ILibrary.
  /// </summary>
  public class RecycleBin
  {
    DiskFileLibrary recycleFolder;
    RecycleBinEntryCollection entryTable = new RecycleBinEntryCollection();
    ILibrary linkedLibrary;
    int maximumSize;

    public event EventHandler StateChanged;
    public event EventHandler<CancelEventArgs> BeforeOverwriteFile;
    public event EventHandler<CancelEventArgs> BeforeOverwriteFolder;

    private string sourceFolder
    {
      get { return recycleFolder.RootPath; }
    }

    /// <summary>
    /// Returns the total number of files currently contained within the recycle bin.
    /// </summary>
    public int TotalFiles
    {
      get
      {
        // For now we are just getting the entry list count, but we may need to break up
        // the count based on files, folder, sub files inside deleted folders, etc.
        return entryTable.Count;
      }
    }

    /// <summary>
    /// Gets or sets the maximum size in bytes that the recycle bin can contain.
    /// </summary>
    public int MaximumSize
    {
      get { return maximumSize; }
      set { maximumSize = value; }
    }

    public RecycleBin(string sourceFolder, ILibrary linkedLibrary)
    {
      if (!Directory.Exists(sourceFolder))
        Directory.CreateDirectory(sourceFolder);
      File.SetAttributes(sourceFolder, FileAttributes.Hidden);
      recycleFolder = new DiskFileLibrary(sourceFolder, linkedLibrary.Name + "_RecycleBin");
      this.linkedLibrary = linkedLibrary;

      LoadEntryTable();
    }

    void recycleFolder_Changed(object sender, LibraryFileActionArgs e)
    {
      OnStateChanged();
    }

    void OnStateChanged()
    {
      if (StateChanged != null)
        StateChanged(this, new EventArgs());
    }

    bool OnBeforeOverwriteFile()
    {
      CancelEventArgs e = new CancelEventArgs();
      if (BeforeOverwriteFile != null)
        BeforeOverwriteFile(this, e);
      return e.Cancel;
    }

    bool OnBeforeOverwriteFolder()
    {
      CancelEventArgs e = new CancelEventArgs();
      if (BeforeOverwriteFolder != null)
        BeforeOverwriteFolder(this, e);
      return e.Cancel;
    }

    /// <summary>
    /// Removed an item from the recycle bin.
    /// </summary>
    public void RemoveItem(string path)
    {
      foreach (RecycleBinEntry entry in entryTable)
        if (entry.OriginalPath == path)
        {
          RemoveItem(entry);
          return;
        }
    }

    private void RemoveItem(RecycleBinEntry entry)
    {
      if (recycleFolder.FileExists(entry.Filename))
        recycleFolder.DeleteFile(entry.Filename);
      entryTable.Remove(entry);
      SaveEntryTable();
      OnStateChanged();
      return;
    }

    /// <summary>
    /// Restores the specified file to the project.
    /// </summary>
    public bool RestoreFolder(RecycleBinEntry entry)
    {
      if (linkedLibrary.FolderExists(entry.OriginalPath))
        if (OnBeforeOverwriteFolder())
          return false; // Return if the operation was cancelled via that event.

      Archive folderArchive = new Archive(recycleFolder.RootPath + "\\" + entry.Filename, Archive.ArchiveMode.Open);
      string[] files = folderArchive.GetFileList("", "*", true);
      foreach (string file in files)
      {
        byte[] fileData = folderArchive.ReadFile(file);
        linkedLibrary.AddFile(file, fileData);
      }
      folderArchive.Close();

      recycleFolder.DeleteFile(entry.Filename);
      entryTable.Remove(entry);
      SaveEntryTable();
      OnStateChanged();
      return true;
    }

    /// <summary>
    /// Restores the specified file to the project.
    /// </summary>
    public bool RestoreFile(RecycleBinEntry entry)
    {
      if (linkedLibrary.FileExists(entry.OriginalPath))
        if (OnBeforeOverwriteFile())
          return false; // Return if the operation was cancelled via that event.

      byte[] file = recycleFolder.ReadFile(entry.Filename);
      linkedLibrary.AddFile(entry.OriginalPath, file);
      recycleFolder.DeleteFile(entry.Filename);
      entryTable.Remove(entry);
      SaveEntryTable();
      OnStateChanged();
      return true;
    }

    /// <summary>
    /// Reads the specified file from the linked library and adds it to the Recycle Bin.
    /// </summary>
    public void AddFile(string path)
    {
      if (linkedLibrary.FileExists(path))
      {
        // Generate a file name for this deleted item.
        string recycleBinFilename = CreateRandomFilename();

        byte[] deletedFile = linkedLibrary.ReadFile(path);
        recycleFolder.AddFile(recycleBinFilename, deletedFile);

        RecycleBinEntry entry = new RecycleBinEntry();
        entry.Filename = recycleBinFilename;
        entry.OriginalPath = path;
        entry.EntryType = RecycleBinEntryType.File;
        entry.DeletedTimeStamp = DateTime.Now;
        entryTable.Add(entry);

        SaveEntryTable();
        OnStateChanged();
      }
    }

    /// <summary>
    /// Adds the folder located at the specified path, and all child folders/files that it contains, to the recycle bin.
    /// </summary>
    public void AddFolder(string path)
    {
      if (linkedLibrary.FolderExists(path))
      {
        // Generate a file name for this deleted item.
        string recycleBinFolderName = CreateRandomFilename();

        // Create a new archive to contain the folder and it's child items.
        Archive folderArchive = new Archive(recycleFolder.RootPath + "\\" + recycleBinFolderName, Archive.ArchiveMode.Create);
        string[] files = linkedLibrary.GetFileList(path, "*", true);
        if (files.Length < 1)
          Output.Write(OutputTypes.Information, "The folder '" + path + "' does not contain any files, and will simply be deleted from the project folder.");

        // Copy all of the child files to the archive.
        foreach (string file in files)
        {
          byte[] fileData = linkedLibrary.ReadFile(file);
          folderArchive.AddFile(file, fileData);
        }
        folderArchive.Close();

        RecycleBinEntry entry = new RecycleBinEntry();
        entry.Filename = recycleBinFolderName;
        entry.OriginalPath = path;
        entry.EntryType = RecycleBinEntryType.Folder;
        entry.DeletedTimeStamp = DateTime.Now;
        entryTable.Add(entry);

        SaveEntryTable();
        OnStateChanged();
      }
    }

    /// <summary>
    /// Removes any entries from the table that do not point to valid existing files in the recycle bin folder.
    /// </summary>
    protected void CleanEntryTable()
    {
      foreach (RecycleBinEntry entry in entryTable.ToArray())
        if (!recycleFolder.FileExists(entry.Filename))
        {
          entryTable.Remove(entry);
          OnStateChanged();
        }
    }

    protected void SaveEntryTable()
    {
      CleanEntryTable();

      MemoryStream ms = new MemoryStream();
      XmlTextWriter writer = new XmlTextWriter(ms, Encoding.ASCII);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartDocument();
      writer.WriteStartElement("recyclebinentrylist");
      foreach (RecycleBinEntry entry in entryTable)
      {
        writer.WriteStartElement("entry");
        writer.WriteAttributeString("filename", entry.Filename);
        writer.WriteAttributeString("originalpath", entry.OriginalPath);
        writer.WriteAttributeString("deletedtimestamp", entry.DeletedTimeStamp.ToString());
        writer.WriteAttributeString("entrytype", EnumReader.GetText(entry.EntryType));
        writer.WriteEndElement();
      }
      writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Flush();

      string filename = sourceFolder + "\\entries.list";
      FileStream outputFile = new FileStream(filename, FileMode.Create);
      try
      {
        using (GZipStream zipStream = new GZipStream(outputFile, CompressionMode.Compress))
        {
          byte[] documentBytes = ms.ToArray();
          zipStream.Write(documentBytes, 0, documentBytes.Length);
        }
      }
      finally
      {
        outputFile.Close();
      }
    }

    protected void LoadEntryTable()
    {
      entryTable = new RecycleBinEntryCollection();

      string filename = sourceFolder + "\\entries.list";
      if (!File.Exists(filename))
        return;

      FileStream inputFile = new FileStream(filename, FileMode.Open);
      GZipStream zipStream = new GZipStream(inputFile, CompressionMode.Decompress);
      MemoryStream decompressedData = new MemoryStream();

      byte[] buffer = new byte[100];
      while (true)
      {
        int bytesRead = zipStream.Read(buffer, 0, 100);
        if (bytesRead == 0)
          break;

        decompressedData.Write(buffer, 0, bytesRead);
      }
      inputFile.Close();

      string xml = Encoding.ASCII.GetString(decompressedData.ToArray());
      XmlDocument document = new XmlDocument();
      document.LoadXml(xml);

      XmlNodeList entryNodes = document.SelectNodes("//entry");
      foreach (XmlNode entryNode in entryNodes)
      {
        RecycleBinEntry entry = new RecycleBinEntry();
        entry.Filename = entryNode.Attributes["filename"].Value;
        entry.OriginalPath = entryNode.Attributes["originalpath"].Value;
        entry.DeletedTimeStamp = DateTime.Parse(entryNode.Attributes["deletedtimestamp"].Value);
        entry.EntryType = EnumReader.Parse<RecycleBinEntryType>(entryNode.Attributes["entrytype"].Value);
        entryTable.Add(entry);
      }
    }

    /// <summary>
    /// Creates a random filename, ensuring that it does not already exist in the recycle bin.
    /// </summary>
    protected string CreateRandomFilename()
    {
      int x;
      for (x = 0; x < 50; x++)
      {
        string filename = Path.GetRandomFileName();
        if (!recycleFolder.FileExists(filename))
          return filename;
      }
      throw new Exception("After " + x + " tries, a unique filename could not be generated.");
    }

    /// <summary>
    /// Returns a bool indicating if the recycle bin contains files.
    /// </summary>
    public bool ContainsFiles()
    {
      return TotalFiles > 0;
    }

    /// <summary>
    /// Removes all items from the recycle bin.
    /// </summary>
    public void Empty()
    {
      foreach (RecycleBinEntry entry in entryTable.ToArray())
        RemoveItem(entry);
    }

    public RecycleBinEntryCollection EntryTable
    {
      get { return entryTable; }
    }

    public RecycleBinEntry[] GetEntryList()
    {
      return entryTable.ToArray();
    }
  }

  /// <summary>
  /// Represents an entry in the recycle bin.
  /// </summary>
  public class RecycleBinEntry
  {
    string filename;
    string originalPath;
    RecycleBinEntryType entryType;
    DateTime deletedTimeStamp;

    /// <summary>
    /// The random recycle bin filename.
    /// </summary>
    public string Filename
    {
      get { return filename; }
      set { filename = value; }
    }

    /// <summary>
    /// The original full path of the deleted entry.
    /// </summary>
    public string OriginalPath
    {
      get { return originalPath; }
      set { originalPath = value; }
    }

    /// <summary>
    /// The type of entry that is being represented.
    /// </summary>
    public RecycleBinEntryType EntryType
    {
      get { return entryType; }
      set { entryType = value; }
    }

    /// <summary>
    /// The date and time that the file was deleted.
    /// </summary>
    public DateTime DeletedTimeStamp
    {
      get { return deletedTimeStamp; }
      set { deletedTimeStamp = value; }
    }
  }

  /// <summary>
  /// Represents the types of entries that can be contained within the recycle bin.
  /// </summary>
  public enum RecycleBinEntryType
  {
    /// <summary>
    /// A single file.
    /// </summary>
    File,

    /// <summary>
    /// A folder containing multiple files.
    /// </summary>
    Folder
  }

  /// <summary>
  /// Represents a collection of RecycleBinEntry objects.
  /// This collection supports notification of addition and removal of objects from the list.
  /// </summary>
  public class RecycleBinEntryCollection : CollectionBase
  {
    public event ListChangedEventHandler ListChanged;

    protected void OnListChanged(ListChangedEventArgs e)
    {
      if (ListChanged != null)
        ListChanged(this, e);
    }

    public void Add(RecycleBinEntry entry)
    {
      int index = InnerList.Add(entry);
      OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
    }

    public void Remove(RecycleBinEntry entry)
    {
      InnerList.Remove(entry);
      OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, -1));
    }

    public RecycleBinEntry this[int index]
    {
      get { return (RecycleBinEntry)InnerList[index]; }
      set { InnerList[index] = value; }
    }

    public RecycleBinEntry[] ToArray()
    {
      return (RecycleBinEntry[])InnerList.ToArray(typeof(RecycleBinEntry));
    }
  }
}