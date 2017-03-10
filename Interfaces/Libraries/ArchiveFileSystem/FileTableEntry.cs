using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Core.Libraries.ArchiveFileSystem.EntryFilters;

namespace Core.ArchiveFileSystem
{
  /// <summary>
  /// Represents an entry in the file table of an ArchiveFile.
  /// </summary>
  public class FileTableEntry
  {
    public const uint NullOffset = 0xffffffff;
    private EntryType entryType;

    public FileTableEntry ParentEntry;
    public FileTableEntry PreviousSiblingEntry;
    public FileTableEntry SiblingEntry;
    public FileTableEntry ChildEntry;
    public uint Offset;
    public uint DataOffset = NullOffset;
    public uint DataSize = 0;
    public string Name = "";
    
    public FileTableEntry FirstSiblingInChain
    {
      get
      {
        FileTableEntry entry = this;
        while (entry.PreviousSiblingEntry != null)
          entry = entry.PreviousSiblingEntry;
        return entry;
      }
    }

    public virtual int Size
    {
      get
      {
        return 1 // EntryType
               + 4 // DataOffset
               + 4 // DataSize
               + 4 // SiblingOffset
               + 4 // ChildOffset
               + Name.Length + 1; // Extra byte for .NET string serialization.
      }
    }
    
    public EntryType EntryType
    {
      get { return entryType; }
    }

    /// <summary>
    /// Returns the offset of the node's referenced parent node.
    /// </summary>
    public uint ParentOffset
    {
      get
      {
        if (ParentEntry == null) return NullOffset;
        return ParentEntry.Offset;
      }
    }

    /// <summary>
    /// Returns the offset of the node's referenced sibling node.
    /// </summary>
    public uint SiblingOffset
    {
      get
      {
        if (SiblingEntry == null) return NullOffset; 
        return SiblingEntry.Offset;
      }
    }
    
    /// <summary>
    /// Returns the offset of the node's referenced child node.
    /// </summary>
    public uint ChildOffset
    {
      get
      {
        if (ChildEntry == null) return NullOffset;
        return ChildEntry.Offset;
      }
    }

    /// <summary>
    /// Returns the complete path of the entry.
    /// </summary>
    public string FullPath
    {
      get
      {
        string s = Name;
        FileTableEntry parent = ParentEntry;

        while (parent != null && parent.Name != "")
        {
          s = parent.Name + "\\" + s;
          parent = parent.ParentEntry;
        }
        return s;
      }
    }

    /// <summary>
    /// Initiallizes a new file entry object with the specified entry type.
    /// </summary>
    public FileTableEntry(EntryType entryType)
    {
      this.entryType = entryType;
    }

    /// <summary>
    /// Converts an array of FileTableEntry objects to a strings array containing their paths.
    /// </summary>
    public static string[] EntriesToPaths(FileTableEntry[] entries)
    {
      string[] results = new string[entries.Length];
      for (int x = 0; x < entries.Length; x++)
        results[x] = entries[x].FullPath;
      return results;
    }
    
    /// <summary>
    /// Returns a list of the entry's direct children that match the specified criteria.
    /// </summary>
    public List<FileTableEntry> GetChildren(params IEntryFilter[] filters)
    {
      return GetChildren(false, filters);
    }
    
    /// <summary>
    /// Returns a list of the entry's children that match the specified criteria.
    /// Optionally recursive.
    /// </summary>
    public List<FileTableEntry> GetChildren(bool recursive, params IEntryFilter[] filters)
    {
      List<FileTableEntry> entryList = new List<FileTableEntry>();
      FileTableEntry child = ChildEntry;

      while (child != null)
      {
        // Test the entry against all of the supplied filters.
        bool match = true;
        foreach (IEntryFilter filter in filters)
        {
          if (!filter.Match(child))
          {
            match = false;
            break;
          }
        }
        
        // Add to the list of results if it matched every filter.
        if (match) entryList.Add(child);
        
        // Test the entry's sibling next.
        child = child.SiblingEntry;
      }
      
      if (recursive)
      {
        // Get all of the items from any subfolders as well.
        List<FileTableEntry> folderList = GetChildren(new EntryTypeFilter(EntryType.Folder));
        foreach (FileTableEntry folder in folderList)
        {
          entryList.AddRange(folder.GetChildren(true, filters));
        }
      }
      return (entryList);
    }

    /// <summary>
    /// Adds a child entry with the specified name of the specified type.
    /// </summary>
    public FileTableEntry AddChild(string name, EntryType type)
    {
      // See if the entry already exists in this node's children
      if (ParentEntry != null)
      {
        List<FileTableEntry> entries = GetChildren(new NameFilter(name));
        if (entries.Count > 0)
          return entries[0];
      }

      // Creat the new entry and assign it's values.
      FileTableEntry newNode = CreateEntry(type);
      newNode.ParentEntry = this;
      newNode.Name = name;

      // If this is the first child of this entry, set the reference.
      if (ChildEntry == null)
      {
        ChildEntry = newNode;
      }
      else
      {
        // If not, set it up as a sibling to the existing child.
        ChildEntry.AddSibling(newNode);
      }
      return (newNode);
    }
    
    /// <summary>
    /// Creates a new FileTableEntry object.
    /// Override this method in a derived class to use a different filetableentry.
    /// </summary>
    protected virtual FileTableEntry CreateEntry(EntryType entryType)
    {
      return new FileTableEntry(entryType);
    }

    /// <summary>
    /// Adds a new sibling to the node.
    /// </summary>
    public void AddSibling(FileTableEntry newSibling)
    {
      // TODO: Verify that the sibling doesnt already exist.
      // (Do this the same way that AddChild does)
      if (SiblingEntry == null)
      {
        newSibling.PreviousSiblingEntry = this;
        SiblingEntry = newSibling;
      }
      else
        SiblingEntry.AddSibling(newSibling);
      
    }


    #region Save/Load
    /// <summary>
    /// Save the entry to the specified BinaryWriter.
    /// </summary>
    /// <param name="writer"></param>
    public void Save(BinaryWriter writer)
    {
      writer.BaseStream.Position = Offset;
      writer.Write((byte)EntryType);
      writer.Write(DataOffset);
      writer.Write(DataSize);
      if (SiblingOffset < 16 || ChildOffset < 16)
        Debugger.Break();
      writer.Write(SiblingOffset);
      writer.Write(ChildOffset);
      WriteExtendedData(writer);
      writer.Write(Name);
    }

    public void Load(BinaryReader reader, uint offset)
    {
      Load(reader, offset, null);
    }
    
    public void Load(BinaryReader reader, uint offset, FileTableEntry parentEntry)
    {
      Load(reader, offset, parentEntry, null);
    }
    
    /// <summary>
    /// Loads an entry, and all of it's referenced entries.
    /// </summary>
    protected void Load(BinaryReader reader, uint offset, FileTableEntry parentEntry,
      FileTableEntry previousSiblingEntry)
    {
      if (offset != NullOffset)
      {
        reader.BaseStream.Position = offset;
        entryType = (EntryType) reader.ReadByte();
        Offset = offset;
        DataOffset = reader.ReadUInt32();
        DataSize = reader.ReadUInt32();
        uint siblingOffset = reader.ReadUInt32();
        uint childOffset = reader.ReadUInt32();
        ReadExtendedData(reader);
        Name = reader.ReadString();

        if (SiblingOffset < 16 || ChildOffset < 16)
          Debugger.Break();
        
        // Load the referenced entries.
        ParentEntry = parentEntry;
        PreviousSiblingEntry = previousSiblingEntry;
        
        if (siblingOffset != NullOffset)
        {
          SiblingEntry = CreateEntry(EntryType.Folder);
          SiblingEntry.Load(reader, siblingOffset, parentEntry);
        }

        if (childOffset != NullOffset)
        {
          ChildEntry = CreateEntry(EntryType.Folder);
          ChildEntry.Load(reader, childOffset, this);
        }
      }
    }
    /// <summary>
    /// Reads any additional data that will be associated with the entry in a derived class.
    /// </summary>
    protected virtual void ReadExtendedData(BinaryReader reader) { ; }

    /// <summary>
    /// Reads any additional data that will be associated with the entry in a derived class.
    /// </summary>
    protected virtual void WriteExtendedData(BinaryWriter writer) { ; }
    #endregion
    
    public override string ToString()
    {
      return string.Format("{0} ({1}) - {2}", Name, FullPath, EntryType == EntryType.Folder ? "Folder" : "File");
    }
  }

  /// <summary>
  /// Specifies the type of the entry (file or folder).
  /// </summary>
  public enum EntryType : byte
  {
    File,
    Folder
  }
}