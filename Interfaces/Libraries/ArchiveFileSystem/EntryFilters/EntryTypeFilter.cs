using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  public class EntryTypeFilter : IEntryFilter
  {
    private EntryType entryType;
    public EntryType EntryType
    {
      get { return entryType; }
    }
    public EntryTypeFilter(EntryType entryType)
    {
      this.entryType = entryType;
    }
    public bool Match(FileTableEntry entry)
    {
      return entry.EntryType == entryType;
    }
  }
}
