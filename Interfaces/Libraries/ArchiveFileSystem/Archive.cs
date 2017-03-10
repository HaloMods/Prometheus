using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Libraries.ArchiveFileSystem.EntryFilters;
using Interfaces.Pool;

namespace Core.ArchiveFileSystem
{
  /// <summary>
  /// Represents an archive file.
  /// </summary>
  public class Archive : ILibrary 
  {
    #region Members
    protected Stream archiveFile;
    protected BinaryReader br;
    protected BinaryWriter bw;

    protected FileTable fileTable;
    private ArchiveStatus archiveStatus = ArchiveStatus.Closed;
    private string name = "";
    #endregion

    #region Properties
    public ArchiveStatus ArchiveStatus
    {
      get { return archiveStatus; }
    }
    public FileTable FileTable
    {
      get { return fileTable; }
    }
    public Stream BaseStream
    {
      get { return archiveFile; }
    }
    /// <summary>
    /// Gets the name of the Archive.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// Returns the FourCC code that will be written to the header of the archive.
    /// </summary>
    public virtual byte[] FourCC 
    {
      get { return Encoding.ASCII.GetBytes("ARCV"); }
    }

    /// <summary>
    /// Returns the offset of the FileTable.
    /// </summary>
    public virtual uint FileTableOffset
    {
      get { return 0x10; }
    }

    /// <summary>
    /// Specifies if the archive should be opened from an existing file, or
    /// created into a new file.
    /// </summary>
    public enum ArchiveMode
    {
      Open,
      Create
    }
    #endregion

    #region Initialization
    public Archive(string filename, ArchiveMode mode)
    {
      if (mode == ArchiveMode.Open)
        Open(filename);
      else 
        Create(filename);

      // The archive was successfuly opened (or created).
      archiveStatus = ArchiveStatus.Open;
    }
    
    protected Archive(FileTable table)
    {
      fileTable = table;
      archiveStatus = ArchiveStatus.Open;
    }
    
    /// <summary>
    /// Opens the archive from the specified file.
    /// </summary>
    protected void Open(string filename)
    {
      // If the specified file exists, open it.
      if (!File.Exists(filename))
        throw new Exception("Could not open the specified archive - the file does not exist.");

      archiveFile = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);

      // Create the reader/writer objects.
      br = new BinaryReader(archiveFile);
      bw = new BinaryWriter(archiveFile);
      
      // Make sure that the FourCC is correct.
      byte[] fcc = br.ReadBytes(4);
      if (Encoding.ASCII.GetString(fcc)
          != Encoding.ASCII.GetString(FourCC))
        throw new Exception("Not a valid archive: " + filename);

      // Load the file table.
      fileTable = CreateFileTableObject();
      fileTable.Load();
    }

    /// <summary>
    /// Creates a new archive in the specified file.
    /// </summary>
    protected void Create(string filename)
    {
      // Create a new file.
      string folder = Path.GetDirectoryName(filename);
      if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
      archiveFile = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);

      // Create the reader/writer objects.
      br = new BinaryReader(archiveFile);
      bw = new BinaryWriter(archiveFile);
      
      // Write our FourCC to the header.
      bw.Write(FourCC);

      // Create a new file table.
      fileTable = CreateFileTableObject();
      fileTable.Create();
    }
    
    /// <summary>
    /// Creates a new FileTable objects.
    /// Override this method to create a different type of FileTable in a derived class.
    /// </summary>
    protected virtual FileTable CreateFileTableObject()
    {
      return new FileTable(archiveFile);
    }
    #endregion
    
    #region Events
    /// <summary>
    /// Occurs when the PTA file is about to be closed.
    /// </summary>
    public event EventHandler ArchiveClosing;
    #endregion

    /// <summary>
    /// Closes the archive.
    /// </summary>
    public void Close()
    {
      // Generate the ArchiveClosing event to inform users of this archive.
      if (ArchiveClosing != null) ArchiveClosing(this, new EventArgs());

      // Set the new status, and close the stream.
      archiveStatus = ArchiveStatus.Closed;
      if (archiveFile != null) archiveFile.Close();
    }

    /// <summary>
    /// Retreives a list of files in the specified path.
    /// </summary>
    public string[] GetFileList(string path)
    {
      return GetFileList(path, "*");
    }

   
    /// <summary>
    /// Retreives a list of files in the specified path with the specified extension.
    /// </summary>
    /// <param name="extension">The extension to filter by (ex: "vehicle")
    /// Use "*" to return all files.</param>
    public virtual string[] GetFileList(string path, string extension)
    {
      return GetFileList(path, extension, false);
    }

    public virtual string[] GetFileList(string path, string extension, bool recursive)
    {
      // Make sure that the path we are looking in exists.
      FileTableEntry folder = fileTable.GetEntry(path, EntryType.Folder);
      if (folder == null) return new string[0];

      // Get the results.
      List<FileTableEntry> entries = folder.GetChildren(recursive,
        new ExtensionFilter(extension), new EntryTypeFilter(EntryType.File));
      return FileTableEntry.EntriesToPaths(entries.ToArray());
    }

    public virtual string[] GetFolderList(string path)
    {
      // Make sure that the path we are looking in exists.
      FileTableEntry folder = fileTable.GetEntry(path, EntryType.Folder);
      if (folder == null) return new string[0];

      // Get the results.
      List<FileTableEntry> entries = folder.GetChildren(new EntryTypeFilter(EntryType.Folder));
      return FileTableEntry.EntriesToPaths(entries.ToArray());
    }

    public virtual bool FileExists(string filename)
    {
      return fileTable.GetEntry(filename, EntryType.File) != null;
    }

    public virtual bool FolderExists(string foldername)
    {
      return fileTable.GetEntry(foldername, EntryType.Folder) != null;
    }

    protected void AddFile(FileTableEntry entry, byte[] buffer)
    {
      entry.DataSize = (uint)buffer.Length;

      // Set the offset to the end of the file.
      entry.DataOffset = (uint)archiveFile.Length;
      entry.Save(bw);
      WriteData(entry, buffer);      
    }
    
    /// <summary>
    /// Adds a file to the archive.
    /// </summary>
    public virtual void AddFile(string filename, byte[] buffer)
    {
      // See if the file already exists in the archive
      if (fileTable.GetEntry(filename, EntryType.File) == null)
      {
        uint offset = GetDataDescriptor(fileTable.NextEntryOffset);
        if (offset != FileTableEntry.NullOffset)
        {
          if (offset <= fileTable.NextEntryOffset)
          {
            // We have reached the data area of the archive, and will need to move
            // this entry's data to the end of the file, in order to make room
            // for more entries in the filetable.
            FileTableEntry moveMe = fileTable.GetEntry(offset);
            byte[] data = ReadFile(moveMe);
            moveMe.DataOffset = (uint)archiveFile.Length;
            moveMe.Save(bw);
            WriteData(moveMe, data);
          }
        }
        
        FileTableEntry entry = fileTable.CreateEntry(filename, EntryType.File);
        AddFile(entry, buffer);

      }
    }
    
    protected virtual void WriteData(FileTableEntry entry, byte[] data)
    {
      bw.BaseStream.Position = entry.DataOffset;
      bw.Write(Encoding.ASCII.GetBytes("_BIN"));
      bw.Write(entry.Offset);
      bw.Write(data);
    }
    
    public uint GetDataDescriptor(uint offset)
    {
      br.BaseStream.Position = offset;
      string id = Encoding.ASCII.GetString(br.ReadBytes(4));
      if (id == "_BIN") return br.ReadUInt32();
      
      // If the _BIN tag didn't exist, then there was no descriptor at this offset.
      return FileTableEntry.NullOffset;
    }
    
    public virtual byte[] ReadFile(FileTableEntry entry)
    {
      if (entry.DataOffset == FileTableEntry.NullOffset)
        throw new Exception("No data exists in the archive for entry " + entry.FullPath);

      if (GetDataDescriptor(entry.DataOffset) != entry.Offset)
        throw new Exception("Error reading data element for entry " + entry.FullPath);

      br.BaseStream.Position = entry.DataOffset + 8;
      byte[] data = br.ReadBytes((int)entry.DataSize);
      return data;
    }
    
    public byte[] ReadFile(string filename)
    {
      FileTableEntry entry = fileTable.GetEntry(filename, EntryType.File);
      return ReadFile(entry);
    }

    /// <summary>
    /// Signals that a file has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileAdded;

    /// <summary>
    /// Generates the FileAdded event.
    /// </summary>
    protected void OnFileAdded(string filename)
    {
      if (FileAdded != null)
        FileAdded(this, new LibraryFileActionArgs(filename));
    }

    /// <summary>
    /// Signals that a file has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FileRemoved;

    /// <summary>
    /// Generates the FileRemoved event.
    /// </summary>
    protected void OnFileRemoved(string filename)
    {
      if (FileRemoved != null)
        FileRemoved(this, new LibraryFileActionArgs(filename));
    }

    /// <summary>
    /// Signals that a folder has been added to the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderAdded;

    /// <summary>
    /// Signals that a folder has been removed from the ILibrary.
    /// </summary>
    public event EventHandler<LibraryFileActionArgs> FolderRemoved;
  }

  /// <summary>
  /// Specifies the status of an archive.
  /// </summary>
  public enum ArchiveStatus
  {
    Open,
    Closed
  }
}