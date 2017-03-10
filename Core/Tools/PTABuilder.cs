using System.IO;
using System.Xml;
using Core.ArchiveFileSystem;
using Core.Libraries;
using Interfaces.Games;

namespace Core.Tools
{
  public class PTABuilder
  {
    public void BuildPTA(GameDefinition gameDef, XmlDocument tagDocument)
    {
      TagArchive archive = new TagArchive(
        gameDef.HomePath + "\\" + gameDef.GameID + ".pta.clean", Archive.ArchiveMode.Create);
      
      
      XmlNodeList tagNodes = tagDocument.SelectNodes("//tag");
      foreach (XmlNode tagNode in tagNodes)
      {
        string filename = tagNode.Attributes["filename"].InnerText;
        XmlNodeList mapNodes = tagNode.SelectNodes("map");

        // Calculate the map location bitmask for this tag.
        ulong bitmask = 0x0000000000000000;
        foreach (XmlNode mapNode in mapNodes)
        {
          string map = mapNode.InnerText;
          for (int x=0; x<gameDef.Maps.Length; x++)
          {
            if (gameDef.Maps[x].Filename == map)
            {
              bitmask = bitmask | ((ulong)1 << x);
            }
          }
        }
        
        // Create the entry in the filetable.
        TagArchiveFileTableEntry entry = (archive.FileTable.CreateEntry(
          filename, EntryType.File) as TagArchiveFileTableEntry);
        entry.MapsBitmask = bitmask;
        entry.Save(new BinaryWriter(archive.BaseStream));
      }
      archive.FileTable.Save();
      archive.Close();
    }
  }
}
