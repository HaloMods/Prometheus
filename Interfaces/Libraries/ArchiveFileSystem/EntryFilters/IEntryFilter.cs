using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  /// <summary>
  /// Represents a condition that is used to filter FileTableEntry objects.
  /// </summary>
  public interface IEntryFilter
  {
    /// <summary>
    /// Returns a boolean indicating if the specified entry matches the filter's criteria.
    /// </summary>
    bool Match(FileTableEntry entry);
  }
}
