using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Interfaces.Games;

namespace Core.Tools
{
  /// <summary>
  /// Used to create a list of unique tags and their usage from a specified set of map files.
  /// </summary>
  public class TagListCompiler
  {
    private Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo>();

    public IDictionary<string, TagInfo> Tags
    {
      get { return tags; }
    }

    /// <summary>
    /// Add all of the tags contained within mapFileInterface to the list.
    /// </summary>
    public void AddMap(IMapFile mapFile)
    {
      string[] tagList = mapFile.GetTagList();
      for (int x=0; x<tagList.Length; x++)
      {
        if (tagList[x].Contains("\\\\"))
          tagList[x] = tagList[x].Replace("\\\\", "\\");
        TagInfo tagInfo;
        if (tags.ContainsKey(tagList[x]))
        {
          tagInfo = tags[tagList[x]];
        }
        else
        {
          // Create a new entry for the tag and add it.
          tagInfo = new TagInfo();
          tagInfo.Path = tagList[x];
          tags.Add(tagList[x], tagInfo);
        }

        // If the tag does not already reference the current map, add it.
        string mapName = Path.GetFileName(mapFile.Filename);
        if (!tagInfo.Maps.ContainsKey(mapName))
        {
          tagInfo.Maps.Add(mapName, mapName);
        }
      }
    }

    /// <summary>
    /// Write the tag list to the specified Xml document.
    /// </summary>
    public void WriteXml(string filename)
    {
      // Write the XML Document
      XmlTextWriter writer = new XmlTextWriter(filename, Encoding.ASCII);
      writer.Formatting = Formatting.Indented;
      writer.WriteStartDocument();

      writer.WriteStartElement("xml");
      foreach (KeyValuePair<string, TagInfo> keyPair in Tags)
      {
        writer.WriteStartElement("tag");
        writer.WriteAttributeString("filename", keyPair.Value.Path);

        foreach (KeyValuePair<string, string> mapName in keyPair.Value.Maps)
        {
          writer.WriteElementString("map", mapName.Value);
        }
        writer.WriteEndElement();
      }
      writer.WriteEndElement();
      writer.WriteEndDocument();
      writer.Close();
    }
  }

  /// <summary>
  /// Represents a tag's filename, and a list of maps that it is contained in.
  /// </summary>
  public class TagInfo
  {
    private string path = "";
    private Dictionary<string, string> maps = new Dictionary<string, string>();

    public string Path
    {
      get { return path; }
      set { path = value; }
    }

    public IDictionary<string, string> Maps
    {
      get { return maps; }
    }
  }
}
