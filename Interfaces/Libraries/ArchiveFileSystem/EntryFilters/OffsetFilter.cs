using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  public class OffsetFilter : IEntryFilter
  {
    private int offset;
    
    public int Offset
    {
      get { return offset; }
    }
    
    public OffsetFilter(int offset)
    {
      this.offset = offset;
    }
    
    /// <summary>
    /// Returns a boolean indicating if the specified entry exists at the specified offset.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      return entry.Offset == offset;
    }
  }
}
