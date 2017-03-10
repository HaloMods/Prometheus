using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.ArchiveFileSystem;
using Core.Libraries.ArchiveFileSystem.EntryFilters;
using Interfaces;
using Interfaces.Games;
using Interfaces.Libraries.ArchiveFileSystem.EntryFilters;
using Interfaces.Pool;

namespace Core.Libraries
{
  public delegate void TagAddedHandler(string tag);

  public class TagArchive : Archive
  {
    private byte[] fourCC = Encoding.ASCII.GetBytes("PTA ");
    private ResultConstraint resultConstraint = ResultConstraint.ExistingFiles;
    private TagArchive missingFilesArchive;

    /// <summary>
    /// Gets an instance of a Tag Archive that returns only the files and folders
    /// that are missing from the current archive.
    /// </summary>
    public TagArchive MissingFilesArchive
    {
      get { return missingFilesArchive; }
    }

    /// <summary>
    /// Returns the appropriate data based on the ResultConstraint of the Archive.
    /// </summary>
    private IEntryFilter DataFilter
    {
      get
      {
        if (resultConstraint == ResultConstraint.ExistingFiles)
          return new HasDataFilter();
        else return new HasNoDataFilter();
      }
    }
    
    public TagArchive(string filename, ArchiveMode mode)
      : base(filename, mode)
    {
      resultConstraint = ResultConstraint.ExistingFiles;
      missingFilesArchive = new TagArchive(fileTable);
    }

    protected TagArchive(FileTable table) : base(table)
    {
      resultConstraint = ResultConstraint.MissingFiles;
      missingFilesArchive = this;
    }
    
    /// <summary>
    /// Creates a list of the minimum set of maps that contain all of the specified tags.
    /// </summary>
    public List<TagSet> BuildTagLocationList(string[] tags, GameDefinition game)
    {
      ulong availableMapsBitmask = game.GetAvailableMapsBitmask();
      List<TagSet> locationList = new List<TagSet>(); 
      List<TagArchiveFileTableEntry> list = new List<TagArchiveFileTableEntry>();
      List<string> unextractableTags = new List<string>();
      foreach (string tag in tags)
      {
        TagArchiveFileTableEntry entry = (TagArchiveFileTableEntry)FileTable.GetEntry(tag, EntryType.File);
        if (entry == null)
          throw new Exception("The specified tag was not found in the file table: " + tag);
        list.Add(entry);
      }

      bool incompleteExtraction = false;
      while (list.Count > 0)
      {
        int[] maps = GetOptimalSourceMaps(list, availableMapsBitmask);

        // Get the smallest file.
        int smallestMapIndex = -1;
        for (int x = 0; x < maps.Length; x++)
          if (smallestMapIndex == -1)
            smallestMapIndex = maps[x];
          else if (game.Maps[maps[x]].FileSize < game.Maps[smallestMapIndex].FileSize)
            smallestMapIndex = maps[x];

        TagSet set = new TagSet(smallestMapIndex);
        if (set.MapIndex == -1)
        {
          foreach (TagArchiveFileTableEntry entry in list)
            unextractableTags.Add(entry.FullPath);
          list.Clear();
          incompleteExtraction = true;
        }
        else
        {
          for (int x = 0; x < list.Count; x++)
          {
            TagArchiveFileTableEntry entry = list[x];
            if (((ulong)(0x1 << set.MapIndex) & entry.MapsBitmask) != 0)
            {
              set.Tags.Add(entry.FullPath);
              list.Remove(entry);
              x--;
            }
          }
          locationList.Add(set);
        }
      }
      if (incompleteExtraction)
        Output.Write(OutputTypes.Warning, "One or more of the specified tags do not exist in any of the available maps.", unextractableTags.ToArray());
      return locationList;
    }
    
    /// <summary>
    /// Determines the source map in which the largest number of the specified tags are located.
    /// </summary>
    /// <param name="tagList">A list of tags located within the tag archive.</param>
    /// <param name="availableMapsBitmask">A bitmask specifying which maps should be
    /// considered when determining the optimal source map.</param>
    public virtual int[] GetOptimalSourceMaps(List<TagArchiveFileTableEntry> tagList, ulong availableMapsBitmask)
    {
      int[] mapCounters = new int[60];
      int optimalMapIndex = -1;
      
      BitArray mapAvailable = new BitArray(BitConverter.GetBytes(availableMapsBitmask));

      // Get per map count of all tags.
      foreach (TagArchiveFileTableEntry entry in tagList)
      {
        for (int i = 0; i < mapCounters.Length; i++)
        {
          ulong maskBit = (ulong)(0x1 << i);
          if (mapAvailable[i])
            if ((maskBit & entry.MapsBitmask) != 0)
            {
              mapCounters[i]++;
              if ((optimalMapIndex == -1) || (mapCounters[i] > mapCounters[optimalMapIndex]))
                optimalMapIndex = i;
            }
        }
      }

      if (optimalMapIndex == -1)
        return new int[0];

      List<int> optimalMapIndices = new List<int>();
      optimalMapIndices.Add(optimalMapIndex);
      for (int i = 0; i < mapCounters.Length; i++)
        if (mapCounters[i] == mapCounters[optimalMapIndex])
          if (!optimalMapIndices.Contains(i))
            optimalMapIndices.Add(i);
      
      return optimalMapIndices.ToArray();
    }

    /// <summary>
    /// Returns the FourCC code that will be written to the header of the archive.
    /// </summary>
    public override byte[] FourCC
    {
      get { return fourCC; }
    }

    /// <summary>
    /// Creates a new FileTable objects.
    /// </summary>
    protected override FileTable CreateFileTableObject()
    {
      return new TagArchiveFileTable(archiveFile);
    }

    /// <summary>
    /// Determines if any files with the specified extention exist in the archive.
    /// Tentative: Determine if this method is necessary, or if this functionality
    /// should be supported via wildcards in the FileExists method.
    /// </summary>
    public bool FileTypeExists(string extension)
    {
      // TODO: Look into expanding the GetChildren functionality to return only the first result.
      // (In order to speed up searches of this nature.)
      List<FileTableEntry> results = fileTable.RootEntry.GetChildren(true, new ExtensionFilter(extension),
        new EntryTypeFilter(EntryType.File), DataFilter);
      return results.Count > 0;
    }
    
    /// <summary>
    /// Searches the archive to see if the specified file exists.
    /// </summary>
    public override bool FileExists(string filename)
    {
      string path = Path.GetDirectoryName(filename);
      FileTableEntry folder = fileTable.GetEntry(path, EntryType.Folder);
      
      if (folder == null)
        return false;

      return folder.GetChildren(new NameFilter(Path.GetFileName(filename)),
          new EntryTypeFilter(EntryType.File), DataFilter).Count > 0;
    } 

    public override string[] GetFileList(string path, string extension, bool recursive)
    {
      // Make sure that the path we are looking in exists.
      FileTableEntry folder = fileTable.GetEntry(path, EntryType.Folder);
      if (folder == null) return new string[0];

      List<FileTableEntry> entries = folder.GetChildren(recursive,
          new ExtensionFilter(extension), new EntryTypeFilter(EntryType.File), DataFilter);
      return FileTableEntry.EntriesToPaths(entries.ToArray());
    }
    
    public override string[] GetFolderList(string path)
    {
      // TEST CODE ::: Writes (supposedly) all entries in the filetable to a txt file.
      //List<FileTableEntry> test = fileTable.RootEntry.GetChildren(true);
      //System.IO.StreamWriter writer = new StreamWriter("C:\\test.txt");
      //foreach (FileTableEntry testEntry in test)
      //  writer.WriteLine(testEntry.FullPath + " - " + Enum.GetName(typeof(EntryType), testEntry.EntryType));
      //writer.Close();

      // Make sure that the path we are looking in exists.
      FileTableEntry folder = fileTable.GetEntry(path, EntryType.Folder);
      if (folder == null) return new string[0];

      // Get the results.
      List<IEntryFilter> filters = new List<IEntryFilter>();
      filters.Add(new EntryTypeFilter(EntryType.Folder));

      // Apply the proper filters based on the constraint.
      if (resultConstraint == ResultConstraint.ExistingFiles)
        filters.Add(new ContainsFilesFilter());
      if (resultConstraint == ResultConstraint.MissingFiles)
        filters.Add(new ContainsMissingFilesFilter());
      
      // Get the results.
      List<FileTableEntry> entries = folder.GetChildren(filters.ToArray());
      return FileTableEntry.EntriesToPaths(entries.ToArray());
    }
    
    /// <summary>
    /// Adds a tag to the archive.
    /// An entry for the tag must exist in the filetable.
    /// </summary>
    public override void AddFile(string filename, byte[] buffer)
    {
      // See if an entry for this file already exists in the filetable.
      FileTableEntry entry = fileTable.GetEntry(filename, EntryType.File);
      if (entry == null)
        throw new Exception("The specified file is not allowed in this archive: " + filename);
      
      // Add the file under the existing entry in the file table.
      AddFile(entry, buffer);
      OnFileAdded(filename);
    }

    /// <summary>
    /// Reads a file from the archive.
    /// </summary>
    public override byte[] ReadFile(FileTableEntry entry)
    {
      if (entry.DataOffset == FileTableEntry.NullOffset)
        throw new Exception("The specified file does not exist in the archive: " + entry.FullPath);
      return base.ReadFile(entry);
    }
    
    public override string ToString()
    {
      return (Name != "" ? Name : "Tag Archive") + " - " + 
        Enum.GetName(typeof (ResultConstraint), resultConstraint);
    }
  }

  public enum ResultConstraint
  {
    ExistingFiles,
    MissingFiles,
    Both
  }
  
  public class TagArchiveFileTable : FileTable
  {
    public TagArchiveFileTable(Stream diskStream)
      : base(diskStream)
    {
    }

    protected override void CreateRootEntry()
    {
      rootEntry = new TagArchiveFileTableEntry(EntryType.Folder);
    }
  }

  public class TagArchiveFileTableEntry : FileTableEntry
  {
    public ulong MapsBitmask = 0x0;

    public override int Size
    {
      get
      {
        return base.Size + 8; // Original size + MapsBitmask.
      }
    }

    public TagArchiveFileTableEntry(EntryType entryType)
      : base(entryType)
    {
    }

    protected override FileTableEntry CreateEntry(EntryType entryType)
    {
      return new TagArchiveFileTableEntry(entryType);
    }

    public FileTableEntry AddChild(string name, EntryType type, uint mapsBitmask)
    {
      FileTableEntry entry = AddChild(name, type);
      ((TagArchiveFileTableEntry)entry).MapsBitmask = mapsBitmask;
      return entry;
    }

    protected override void ReadExtendedData(BinaryReader reader)
    {
      MapsBitmask = reader.ReadUInt64();
    }

    protected override void WriteExtendedData(BinaryWriter writer)
    {
      writer.Write(MapsBitmask);
    }
  }

  /// <summary>
  /// Represents a map index and a list of tags that can be found within it.
  /// </summary>
  public class TagSet
  {
    private int mapIndex;
    private List<string> tags = new List<string>();

    public int MapIndex
    {
      get { return mapIndex; }
    }

    public List<string> Tags
    {
      get { return tags; }
    }

    public TagSet(int mapIndex)
    {
      this.mapIndex = mapIndex;
    }
  }
}