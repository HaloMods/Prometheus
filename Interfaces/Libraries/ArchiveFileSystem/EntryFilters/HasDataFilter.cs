using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  /// <summary>
  /// Filters out entries that do not contain file data.
  /// </summary>
  public class HasDataFilter : IEntryFilter
  {
    /// <summary>
    /// Returns a boolean indicating if the specified entry has file data.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      return entry.DataOffset != FileTableEntry.NullOffset;
    }
  }

  /// <summary>
  /// Filters out entries that do not contain file data.
  /// </summary>
  public class HasNoDataFilter : IEntryFilter
  {
    /// <summary>
    /// Returns a boolean indicating if the specified entry has file data.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      if (entry.FullPath.Contains("collectidsfsdon")) System.Diagnostics.Debugger.Break();
      return entry.DataOffset == FileTableEntry.NullOffset;
    }
  }
}
