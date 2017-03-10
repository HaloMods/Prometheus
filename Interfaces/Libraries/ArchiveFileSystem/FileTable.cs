using System.Collections.Generic;
using System.IO;
using Core.Libraries.ArchiveFileSystem.EntryFilters;

namespace Core.ArchiveFileSystem
{
  public class FileTable
  {
    #region Private Members
    protected FileTableEntry rootEntry;
    protected BinaryReader diskReader;
    protected BinaryWriter diskWriter;

    protected FileTableHeader header = new FileTableHeader();
    protected uint fileEntryTableOffset = 0x10;
    #endregion
    #region Properties
    /// <summary>
    /// Returns the amount of padding in bytes that will be placed between the filetable
    /// and the data area of the archive.
    /// </summary>
    public int PaddingSize
    {
      get { return 100*1024; }
    }
    public uint NextEntryOffset
    {
      get { return header.FileTableSize + Offset + FileTableHeader.Size; }
    }
    #endregion
    
    public FileTableEntry RootEntry
    {
      get { return rootEntry;  }
    }
    
    public const uint Offset = 0x8;

    #region Constructor
    /// <summary>
    /// Iniitalizes the FileTable with the specified FileStream.
    /// </summary>
    /// <param name="diskStream">The FileStream that you would like to read from
    /// and write to.</param>
    public FileTable(Stream diskStream)
    {
      diskReader = new BinaryReader(diskStream);
      diskWriter = new BinaryWriter(diskStream);
    }
    
    public virtual void Create()
    {
      CreateRootEntry();
      AddEntryToTable(rootEntry);
    }

    /// <summary>
    /// Loads and parses the file table.
    /// </summary>
    public virtual void Load()
    {
      diskReader.BaseStream.Position = Offset;
      header.Load(diskReader);
      CreateRootEntry();
      rootEntry.Load(diskReader, fileEntryTableOffset);      
    }
    
    /// <summary>
    /// Creates the root file entry node.
    /// Override this method to create a root entry of a different type.
    /// </summary>
    protected virtual void CreateRootEntry()
    {
      rootEntry = new FileTableEntry(EntryType.Folder);
    }
    #endregion
    #region Methods for Reading and Writing Entries To/From Disk
    protected virtual void ReadHeader()
    {
      diskReader.BaseStream.Position = Offset;
      header.FileEntryCount = diskReader.ReadUInt32();
      header.FileTableSize = diskReader.ReadUInt32();
    }
    
    /// <summary>
    /// Writes the header ot the file table to disk.
    /// </summary>
    protected virtual void WriteHeader()
    {
      diskWriter.BaseStream.Position = Offset;
      diskWriter.Write(header.FileEntryCount);
      diskWriter.Write(header.FileTableSize);
    }
    
    /// <summary>
    /// Writes all entries in the file table to disk.
    /// </summary>
    protected void WriteEntries()
    {
      diskWriter.BaseStream.Position = fileEntryTableOffset;
      WriteEntries(rootEntry);
    }
   
    /// <summary>
    /// Writes the entry and all child entries to disk.
    /// </summary>
    protected void WriteEntries(FileTableEntry startEntry)
    {
      // Get a recursive list of all of the child folders that exist beneath this node.
      List<FileTableEntry> folderEntries = startEntry.GetChildren(true, new EntryTypeFilter(EntryType.Folder));
      foreach (FileTableEntry folderEntry in folderEntries)
      {
        // Write the folder entry.
        folderEntry.Save(diskWriter);
        
        // Write all of the direct child file entry nodes.
        foreach (FileTableEntry fileEntry in folderEntry.GetChildren(new EntryTypeFilter(EntryType.File)))
        {
          fileEntry.Save(diskWriter);
        }
      }
    }
    
    public void Save()
    {
      WriteEntries();
    }
    #endregion

    /// <summary>
    /// Creates an entry in the file table with the specified path.
    /// </summary>
    /// <param name="path">The complete path of the entry to add.</param>
    /// <param name="entryType">The type of entry to add.</param>
    public FileTableEntry CreateEntry(string path, EntryType entryType)
    {
      //if (path == @"levels\b30\decals-environment\bitmaps\decal fore symb blue b.bitmap")
      //  Debugger.Break();
      // Seperate the path into its different levels.
      string[] parts = path.Split('\\');

      // Locate the corresponsing node for each level of the path.
      // If a level does not exist, create it.
      FileTableEntry result = rootEntry;
      for (int x = 0; x < parts.Length; x++)
      {
        EntryType currentType = (x < parts.Length - 1) ? (EntryType.Folder) : entryType;
        List<FileTableEntry> searchResults = result.GetChildren(
          new NameFilter(parts[x]), new EntryTypeFilter(currentType));
        if (searchResults.Count == 0)
        {
          // We didn't find this level of the path, so create the node.
          // Set it to the proper type if it is the last piece, otherwise it's a folder.
          result = result.AddChild(parts[x], (x<parts.Length-1) ? EntryType.Folder : entryType);
          
          // Add to the table.
          AddEntryToTable(result);
        }
        else
        {
          result = searchResults[0];
        }
      }
      return result;
    }
    
    public void RemoveEntry(string path, EntryType type)
    {
      FileTableEntry entry = GetEntry(path, type);
      FileTableEntry parent = entry.ParentEntry;
      FileTableEntry previousSibling = entry.PreviousSiblingEntry;
      FileTableEntry sibling = entry.SiblingEntry;
      FileTableEntry child = entry.ChildEntry;

      if (parent != null)
      {
        parent.ChildEntry = entry.FirstSiblingInChain;
        if (parent.ChildEntry == entry)
          parent.ChildEntry = null;
        entry.FirstSiblingInChain.ParentEntry = parent;
        entry.FirstSiblingInChain.Save(diskWriter);
        parent.Save(diskWriter);
      }
      if (previousSibling != null)
      {
        previousSibling.SiblingEntry = sibling;
        previousSibling.Save(diskWriter);
      }
      if (sibling != null)
      {
        sibling.PreviousSiblingEntry = previousSibling;
        sibling.Save(diskWriter);
      }
      if (child != null)
      {
        child.ParentEntry = null; 
        child.Save(diskWriter);
      }
    }

    /// <summary>
    /// Adds the specified entry to the end of the filetable, and updates the heder values.
    /// </summary>
    protected void AddEntryToTable(FileTableEntry entry)
    {
      // Set the offset accordingly.
      entry.Offset = NextEntryOffset;
      header.FileTableSize += (uint)entry.Size;
      header.FileEntryCount++;
      // Update the header and save the entry to disk.
      WriteHeader();
      entry.Save(diskWriter);
      if (entry.ParentEntry != null) entry.ParentEntry.Save(diskWriter);
      if (entry.PreviousSiblingEntry != null) entry.PreviousSiblingEntry.Save(diskWriter);
    }
    
    /// <summary>
    /// Locates and returns the entry that matches the specified criteria.
    /// Returns null if no matching entry is found.
    /// </summary>
    public FileTableEntry GetEntry(string path, EntryType type)
    {
      // If there's no path, return the root.
      if (path == "") return rootEntry;
      
      // Split the string, and make sure that it has parts.
      string[] parts = path.Split('\\');
      if (parts.Length == 0) return null;

      // Locate the entry.
      FileTableEntry result = rootEntry;
      for (int x = 0; x < parts.Length; x++)
      {
        List<FileTableEntry> results = result.GetChildren(new NameFilter(parts[x]),
          new EntryTypeFilter((x < (parts.Length - 1)) ? EntryType.Folder : type));
        if (results.Count < 1)
        {
          result = null;
          break;
        }
        result = results[0];
      }
      return (result != rootEntry ? result : null);
    }
    
    public FileTableEntry GetEntry(uint offset)
    {
      List<FileTableEntry> results = rootEntry.GetChildren(true, new EntryTypeFilter(EntryType.File));
      foreach (FileTableEntry entry in results)
      {
        if (entry.Offset == offset) return entry;
      }
      return null;
    }
    
    #region Internally Used FileTableHeader Class
    /// <summary>
    /// Represents the header of a file table.
    /// </summary>
    protected class FileTableHeader
    {
      public const uint Size = 8; // Update this value when modifying the header's structure.
      
      /// <summary>
      /// The number of entries that exist in the table.
      /// </summary>
      public uint FileEntryCount = 0;

      /// <summary>
      /// The size in bytes of the file table, including the header and all
      /// entries - used and unused.
      /// </summary>
      public uint FileTableSize = 0;

      /// <summary>
      /// Reads the file table's values from the specified BinaryReader.
      /// </summary>
      public void Load(BinaryReader reader)
      {
        FileEntryCount = reader.ReadUInt32();
        FileTableSize = reader.ReadUInt32();
      }

      /// <summary>
      /// Write's the file table's values to the specified BinaryWriter.
      /// </summary>
      public void Save(BinaryWriter writer)
      {
        writer.Write(FileEntryCount);
        writer.Write(FileTableSize);
      }
    }
    #endregion
  }
}