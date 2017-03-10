using System.IO;
using Core.ArchiveFileSystem;

namespace Core.Libraries.ArchiveFileSystem.EntryFilters
{
  public class ExtensionFilter : IEntryFilter
  {
    private string fileExtension;
    public string FileExtension
    {
      get { return fileExtension; }
    }
    public ExtensionFilter(string fileExtension)
    {
      this.fileExtension = fileExtension.ToLower();
    }
    public bool Match(FileTableEntry entry)
    {
      return (Path.GetExtension(entry.Name).Trim('.').ToLower() == fileExtension) || fileExtension == "*";
    }
  }
}
