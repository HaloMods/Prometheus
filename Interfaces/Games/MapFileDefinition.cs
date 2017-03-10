namespace Interfaces.Games
{
  /// <summary>
  /// A definition of a mapfile and it's checksum.
  /// </summary>
  public class MapFileDefinition
  {
    private string filename;
    private ulong lowChecksum;
    private ulong highChecksum;
    private long fileSize;

    public string Filename
    {
      get { return filename; }
    }

    public ulong LowChecksum
    {
      get { return lowChecksum; }
    }

    public ulong HighChecksum
    {
      get { return highChecksum; }
    }

    public long FileSize
    {
      get { return fileSize; }
    }

    public MapFileDefinition(string filename, ulong lowChecksum, ulong highChecksum, long fileSize)
    {
      this.filename = filename;
      this.lowChecksum = lowChecksum;
      this.highChecksum = highChecksum;
      this.fileSize = fileSize;
    }
  }
}