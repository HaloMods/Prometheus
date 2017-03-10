using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Core.Factory
{
  /// <summary>
  /// Creates a prometheus-format XML definition from a Kornman-format tag definition
  /// extracted from Guerilla.
  /// </summary>
  public class TdfXmlConverter
  {
    public class FieldTypeCollection : CollectionBase
    {
      public void Add(string value)
      {
        foreach (string s in InnerList)
        {
          if (s == value) return;
        }
        InnerList.Add(value);
      }
    }

    public static FieldTypeCollection FieldTypes = new FieldTypeCollection();
    private static string tagType = "";

    public static XmlDocument ToPrometheusFormat(XmlDocument doc)
    {
      // Create the new document and the root element.
      XmlDocument prom = new XmlDocument();
      prom.AppendChild(prom.CreateNode(XmlNodeType.XmlDeclaration, "", ""));
      XmlElement rootElement = prom.CreateElement("xml");
      prom.AppendChild(rootElement);

      XmlNode kornmanMainStructNode = doc.SelectSingleNode("TagGroup");
      string temp = kornmanMainStructNode.SelectSingleNode("Group").InnerText;

      // Convert name to proper format (ex: sound_environment to SoundEnvironment)
      string[] tagTypeParts = temp.Split('_');
      tagType = "";
      for (int x = 0; x < tagTypeParts.Length; x++)
      {
        tagType += tagTypeParts[x].Substring(0, 1).ToUpper() + tagTypeParts[x].Substring(1);
      }

      string tagAbbreviation = kornmanMainStructNode.SelectSingleNode("GroupTag").InnerText;
      string parentTag = kornmanMainStructNode.SelectSingleNode("ParentGroupTag").InnerText;

      // Name, Platform.
      XmlElement nameElement = prom.CreateElement("name");

      XmlAttribute typeAttribute = prom.CreateAttribute("type");
      typeAttribute.InnerText = tagAbbreviation;
      XmlAttribute parentTypeAttribute = prom.CreateAttribute("parenttype");
      parentTypeAttribute.InnerText = parentTag;

      nameElement.Attributes.Append(typeAttribute);

      nameElement.Attributes.Append(parentTypeAttribute);

      nameElement.AppendChild(prom.CreateTextNode(tagType));
      XmlElement platformElement = prom.CreateElement("platform");
      platformElement.AppendChild(prom.CreateTextNode("Halo1"));
      rootElement.AppendChild(nameElement);
      rootElement.AppendChild(platformElement);

      // Plugin
      XmlElement pluginElement = prom.CreateElement("plugin");
      rootElement.AppendChild(pluginElement);

      // Create "Main" struct

      pluginElement.AppendChild(ConvertNode(kornmanMainStructNode, prom, pluginElement));
      rootElement.AppendChild(pluginElement);

      // Print out the field types.
      foreach (string s in FieldTypes)
      {
        Console.WriteLine(s);
      }

      return prom;
    }

    public class NameTracker
    {
      public string Name;
      public int Uses;
    }

    public class NameCollection : CollectionBase
    {
      public int Add(string name)
      {
        if (Contains(name))
        {
          NameTracker t = this[name];
          t.Uses++;
          return t.Uses;
        }
        else
        {
          NameTracker t = new NameTracker();
          t.Name = name;
          t.Uses = 1;
          InnerList.Add(t);
          return 1;
        }
      }
      public NameTracker this[string name]
      {
        get
        {
          foreach (NameTracker t in InnerList)
          {
            if (t.Name == name)
            {
              return t;
            }
          }
          return null;
        }
      }
      public bool Contains(string name)
      {
        foreach (NameTracker t in InnerList)
        {
          if (t.Name == name)
          {
            return true;
          }
        }
        return false;
      }
      public void IncrementUses(string name)
      {
        foreach (NameTracker t in InnerList)
        {
          if (t.Name == name)
          {
            t.Uses++;
            return;
          }
        }
      }
    }

    protected static XmlNode ConvertNode(XmlNode node, XmlDocument prom, XmlNode rootNode)
    {
      int unknownCount = 0;
      XmlNode fieldsNode = node.SelectSingleNode("Fields");
      XmlElement mainStructElement = prom.CreateElement("struct");

      XmlNode nameNode = node.SelectSingleNode("Name");
      //string structName = "Main";
      string structName = tagType;
      if (nameNode != null) structName = FixStructName(nameNode.InnerText);

      XmlAttribute structNameAttribute = prom.CreateAttribute("name");
      structNameAttribute.InnerText = structName;
      mainStructElement.Attributes.Append(structNameAttribute);

      NameCollection names = new NameCollection();

      foreach (XmlNode fieldNode in fieldsNode.SelectNodes("Field"))
      {
        NameElements elements = ParseControlName(fieldNode.SelectSingleNode("Name").InnerText);

        // Create a node in the output XML doc based on the type.
        XmlAttribute typeAttribute = prom.CreateAttribute("type");
        string fieldType = fieldNode.SelectSingleNode("Type").InnerText;

        // Ignore Terminator_X
        if (fieldType == "Terminator_X") continue;

        // TODO: Create a section based on these.  Continue for now.
        if (fieldType == "Explanation") continue;

        // Fix up the field name string.
        fieldType = ConvertDataTypeString(fieldType);

        XmlElement valueElement = prom.CreateElement("value");

        if (elements.name == "")
        {
          //unknownCount++;
          elements.name = "_unnamed" + unknownCount.ToString();
          elements.name = "_unnamed"; //+ unknownCount.ToString();
        }

        int uses = names.Add(elements.name);
        if (uses > 1)
        {
          elements.name += uses.ToString();
        }

        typeAttribute.InnerText = fieldType;
        valueElement.Attributes.Append(typeAttribute);

        XmlAttribute nameAttribute = prom.CreateAttribute("name");
        nameAttribute.InnerText = elements.name;
        valueElement.Attributes.Append(nameAttribute);

        if (elements.tooltip != null)
        {
          XmlElement tooltipElement = prom.CreateElement("tooltip");
          tooltipElement.AppendChild(prom.CreateTextNode(SentenceCase(elements.tooltip)));
          valueElement.AppendChild(tooltipElement);
        }

        if (elements.blocksName)
        {
          XmlAttribute blockNameAttribute = prom.CreateAttribute("blockname");
          blockNameAttribute.Value = "true";
          valueElement.Attributes.Append(blockNameAttribute);
        }

        // Based on the type, we may need to append other elements.
        if (fieldType == "Block")
        {
          // Add the MaxElements tag.
          XmlNode blockNode = fieldNode.SelectSingleNode("Block");
          string blockName = FixStructName(blockNode.SelectSingleNode("Name").InnerText);

          XmlAttribute blockNameAttribute = prom.CreateAttribute("struct");
          blockNameAttribute.InnerText = blockName;
          valueElement.Attributes.Append(blockNameAttribute);

          string maxElements = blockNode.SelectSingleNode("MaxElements").InnerText;
          XmlAttribute maxElementsAttribute = prom.CreateAttribute("maxelements");
          maxElementsAttribute.Value = maxElements;
          valueElement.Attributes.Append(maxElementsAttribute);

          // Create a new struct and add it to the current parent.
          XmlNode newStructNode = ConvertNode(blockNode, prom, rootNode);
          mainStructElement.AppendChild(newStructNode);

        }
        else if (fieldType == "TagReference")
        {
          string extensions = "";
          XmlNodeList subFields = fieldNode.SelectNodes("Fields/*");
          foreach (XmlNode subFieldNode in subFields)
            extensions += subFieldNode.InnerText + "|";
          extensions = extensions.TrimEnd('|');

          XmlAttribute extensionsAttribute = prom.CreateAttribute("extensions");
          extensionsAttribute.Value = extensions;
          valueElement.Attributes.Append(extensionsAttribute);
        }
        else if (fieldType == "ShortBlockIndex")
        {
          XmlNode blockNameNode = fieldNode.SelectSingleNode("Block");
          XmlAttribute blockNameAttribute = prom.CreateAttribute("block");
          blockNameAttribute.Value = FixStructName(blockNameNode.InnerText);
          valueElement.Attributes.Append(blockNameAttribute);
        }
        else if (fieldType == "Enum")
        {
          XmlNodeList subFields = fieldNode.SelectNodes("Fields/*");
          int index = 0;
          foreach (XmlNode subFieldNode in subFields)
          {
            NameElements tmpElements = ParseControlName(subFieldNode.InnerText);
            XmlElement itemElement = prom.CreateElement("item");
            XmlAttribute itemValueAttribute = prom.CreateAttribute("value");
            itemValueAttribute.InnerText = index.ToString();
            index++;
            XmlAttribute itemNameAttribute = prom.CreateAttribute("name");
            itemNameAttribute.InnerText = tmpElements.name;
            itemElement.Attributes.Append(itemValueAttribute);
            itemElement.Attributes.Append(itemNameAttribute);
            if (tmpElements.tooltip != null)
            {
              XmlElement tooltipElement = prom.CreateElement("tooltip");
              tooltipElement.AppendChild(prom.CreateTextNode(SentenceCase(elements.tooltip)));
              itemElement.AppendChild(tooltipElement);
            }
            valueElement.AppendChild(itemElement);
          }
        }
        else if (fieldType == "String")
        {
          // Change the name, since String in c# is a bad choice.
          fieldType = "FixedLengthString";
          typeAttribute.InnerText = fieldType;
        }
        else if ((fieldType == "ByteFlags") || (fieldType == "WordFlags") || (fieldType == "LongFlags"))
        {
          XmlAttribute flagsLengthAttribute = prom.CreateAttribute("length");
          if (fieldType == "ByteFlags") flagsLengthAttribute.InnerText = "1";
          if (fieldType == "WordFlags") flagsLengthAttribute.InnerText = "2";
          if (fieldType == "LongFlags") flagsLengthAttribute.InnerText = "4";
          valueElement.Attributes.Append(flagsLengthAttribute);

          // Manually override the name so that we can use the generic flags handler.
          fieldType = "Flags";
          typeAttribute.InnerText = fieldType;

          XmlNodeList subFields = fieldNode.SelectNodes("Fields/*");
          int index = 0;
          foreach (XmlNode subFieldNode in subFields)
          {
            NameElements tmpElements = ParseControlName(subFieldNode.InnerText);
            XmlElement bitElement = prom.CreateElement("bit");
            XmlAttribute bitIndexAttribute = prom.CreateAttribute("index");
            bitIndexAttribute.InnerText = index.ToString();
            index++;
            XmlAttribute bitNameAttribute = prom.CreateAttribute("name");
            bitNameAttribute.InnerText = tmpElements.name;
            bitElement.Attributes.Append(bitIndexAttribute);
            bitElement.Attributes.Append(bitNameAttribute);
            if (tmpElements.tooltip != null)
            {
              XmlElement tooltipElement = prom.CreateElement("tooltip");
              tooltipElement.AppendChild(prom.CreateTextNode(SentenceCase(tmpElements.tooltip)));
              bitElement.AppendChild(tooltipElement);
            }
            valueElement.AppendChild(bitElement);
          }
        }
        else if ((fieldType == "Pad") || (fieldType == "Skip"))
        {
          string length = fieldNode.SelectSingleNode("Value").InnerText;
          XmlAttribute lengthAttribute = prom.CreateAttribute("length");
          lengthAttribute.Value = length;
          valueElement.Attributes.Append(lengthAttribute);
        }
        else if (fieldType == "ArrayStart")
        {
          // TODO: Revisit Arrays.
          // Not sure how we're handling this stuff.
          // Just adding in a comment for now to show where they are.
          string fieldCount = fieldNode.SelectSingleNode("Array/FieldCount").InnerText;
          XmlComment comment = prom.CreateComment("Array field goes here: Length=" + fieldCount);
          valueElement.AppendChild(comment);
        }
        mainStructElement.AppendChild(valueElement);

        // Add to collection.
        FieldTypes.Add(fieldType);
      }
      return mainStructElement;
    }

    private static string SentenceCase(string p)
    {
      if (p == null) return null;
      return p.Substring(0, 1).ToUpper() + p.Substring(1) + ".";
    }

    protected static string FixStructName(string name)
    {
      string[] parts = name.Split('_');
      string newName = String.Empty;
      for (int x = 0; x < parts.Length; x++)
      {
        if (parts[x] != "block")
        {
          string firstLetter = parts[x].Substring(0, 1);
          string remainingLetters = parts[x].Substring(1);
          newName += firstLetter.ToUpper() + remainingLetters;
        }
      }
      newName = newName.Replace(" ", "");
      return newName;
    }

    protected static string ConvertDataTypeString(string original)
    {
      switch (original)
      {
        case "SomeSpecialCase":
          return "";
        default:
          return original.Replace("_", "");
      }
    }

    public static string[] ParseRegEx(string ex, string term)
    {
      Regex rx = new Regex(term);

      return rx.Split(ex);
    }

    public struct NameElements
    {
      public string name;
      public string units;
      public string tooltip;
      public bool hidden;
      public bool enabled;
      public bool blocksName;
    }

    protected static NameElements ParseControlName(string name)
    {
      string temp = name.Replace("!", "\n!\n").Replace("^", "\n^\n").Replace("*", "\n*\n").Replace(":", "\n:\n").Replace("#", "\n#\n");
      string[] parse = ParseRegEx(temp, "\n");

      NameElements elements = new NameElements();
      elements.name = parse[0];

      for (int x = 1; x < parse.Length; x++)
      {
        switch (parse[x])
        {
          case "!":
            elements.hidden = true;
            break;
          case "^":
            elements.blocksName = true;
            break;
          case "*":
            elements.enabled = false;
            break;
          case ":":
            elements.units = parse[x + 1];
            break;
          case "#":
            elements.tooltip = parse[x + 1];
            break;
        }
      }

      // Fix any craziness that may be going on in the name.
      elements.name = FixInvalidName(elements.name);

      return elements;
    }

    protected static string FixInvalidName(string name)
    {
      // We'll add more as they become apparant.
      name = name.Replace("'", "");
      name = name.Replace("/", "");
      name = RemoveSubString(name, '<', '>');
      name = RemoveSubString(name, '(', ')');
      name = RemoveSubString(name, '[', ']');
      name = RemoveAfterChar(name, ',');
      name = RemoveAfterChar(name, '-');
      return name.TrimEnd(' ');
    }

    protected static string RemoveAfterChar(string text, char theChar)
    {
      try
      {
        if (text.IndexOf(theChar) > 0)
        {
          text = text.Substring(0, text.IndexOf(theChar) - 1);
        }
      }
      catch
      {
        return text.Replace(Convert.ToString(theChar), "");
      }
      return text;
    }

    protected static string RemoveSubString(string text, char startChar, char endChar)
    {
      if (text.IndexOf(startChar) > -1)
      {
        int start = text.IndexOf(startChar);
        int end = text.LastIndexOf(endChar);
        if (end == -1) end = text.Length - 1;
        text = text.Substring(0, start) + text.Substring(start + 1, (end - start) - 1) + text.Substring(end + 1);
      }
      return text;
    }
  }
}