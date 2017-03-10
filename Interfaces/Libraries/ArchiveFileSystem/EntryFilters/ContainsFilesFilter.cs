using System.Collections.Generic;
using Core.ArchiveFileSystem;
using Core.Libraries.ArchiveFileSystem.EntryFilters;

namespace Interfaces.Libraries.ArchiveFileSystem.EntryFilters
{
  public class ContainsFilesFilter : IEntryFilter
  {
    /// <summary>
    /// Returns a boolean indicating if the specified entry matches the filter's criteria.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      List<FileTableEntry> files = entry.GetChildren(true, new EntryTypeFilter(EntryType.File), new HasDataFilter());
      return (files.Count > 0);
    }
  }
  
  public class ContainsMissingFilesFilter : IEntryFilter
  {
    /// <summary>
    /// Returns a boolean indicating if the specified entry matches the filter's criteria.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      List<FileTableEntry> files = entry.GetChildren(true, new EntryTypeFilter(EntryType.File), new HasNoDataFilter());
      return (files.Count > 0);
    }
  }
}
