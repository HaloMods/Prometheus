using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  public class NameFilter : IEntryFilter
  {
    private string name;
    public string Name
    {
      get { return name; }
    }
    public NameFilter(string name)
    {
      this.name = name.ToUpper();
    }
    /// <summary>
    /// Returns a boolean indicating if the specified entry matches the name.
    /// </summary>
    public bool Match(FileTableEntry entry)
    {
      return entry.Name.ToUpper() == name;
    }
  }
}
