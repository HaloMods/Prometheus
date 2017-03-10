using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Interfaces.Factory;

namespace Core.Factory
{
  /// <summary>
  /// Provides methods to convert XML tag definitions into the obscure Prometheus XML format.
  /// </summary>
  public static class XmlXmlConverter
  {
    public static void ConvertFolder(string sourcePath, string destinationPath, string platform)
    {
      string[] files = Directory.GetFiles(sourcePath, "*.xml");
      foreach (string file in files)
      {
        string fileName = Path.GetFileName(file);
        XmlDocument doc = new XmlDocument();
        XmlDocument src = new XmlDocument();
        src.Load(file);
        ConvertXML(src, doc, platform);
        doc.Save(destinationPath + '\\' + fileName);
      }
    }

    public static void ConvertXML(XmlDocument source, XmlDocument converted, string platform)
    {
      XmlElement tagGroupElement = source["tagGroup"];
      XmlElement xmlElement = converted.CreateElement("xml");

      {
        XmlElement nameElement = converted.CreateElement("name");
        {
          nameElement.InnerText = GlobalMethods.MakePublicName(tagGroupElement.Attributes["name"].InnerText.Replace('_', ' '));

          XmlAttribute nameElementAttribute = converted.CreateAttribute("type");
          nameElementAttribute.InnerText = tagGroupElement.Attributes["groupTag"].InnerText;
          nameElement.Attributes.Append(nameElementAttribute);

          nameElementAttribute = converted.CreateAttribute("parenttype");
          nameElementAttribute.InnerText = tagGroupElement.Attributes["groupTagParent"].InnerText;
          nameElement.Attributes.Append(nameElementAttribute);
        }
        xmlElement.AppendChild(nameElement);

        XmlElement platformElement = converted.CreateElement("platform");
        platformElement.InnerText = platform;
        xmlElement.AppendChild(platformElement);

        XmlElement pluginElement = converted.CreateElement("plugin");
        pluginElement.AppendChild(BuildBlock(tagGroupElement["block"], converted));
        xmlElement.AppendChild(pluginElement);
      }

      converted.AppendChild(xmlElement);
    }

    private static void BuildBlock(XmlElement source, XmlElement structNode, XmlDocument converted, List<string> typenames, Dictionary<string, int> repeats, ref int unnamed)
    {
      XmlAttribute structNodeNameAttribute = converted.CreateAttribute("name");
      structNodeNameAttribute.InnerText = GlobalMethods.MakePublicName(source.Attributes["name"].InnerText.Replace('_', ' '));
      structNode.Attributes.Append(structNodeNameAttribute);
      if (repeats == null)
        repeats = new Dictionary<string, int>();
      if (typenames == null)
        typenames = new List<string>();

      int arrayStartIndex = -1, arrayLoopsRemain = -1;
      int innerArrayStartIndex = -1, innerArrayLoopsRemain = -1;

      for (int fieldIndex = 0; fieldIndex < source["fields"].ChildNodes.Count; fieldIndex++)
      {
        XmlNode field = source["fields"].ChildNodes[fieldIndex];

        if (field is XmlElement)
        {
          if (field.Name == "field")
          {
            XmlElement valueElement = converted.CreateElement("value");
            XmlAttribute typeAttribute = converted.CreateAttribute("type");
            XmlAttribute nameAttribute = converted.CreateAttribute("name");
            XmlAttribute lengthAttribute = converted.CreateAttribute("length");
            XmlAttribute disabledAttribute = converted.CreateAttribute("disabled");

            switch (field.Attributes["type"].InnerText)
            {
              #region recursive
              case "Block":
                XmlElement blockElement = field["block"];
                XmlElement structElement = converted.CreateElement("struct");
                XmlAttribute structNameAttribute = converted.CreateAttribute("name");

                string structName = GlobalMethods.MakePublicName(blockElement.Attributes["name"].InnerText.Replace('_', ' '));
                if (!typenames.Contains(structName))
                {
                  int childUnnamed = 0;
                  BuildBlock(blockElement, structElement, converted, null, null, ref childUnnamed);
                  structNameAttribute.InnerText = structName;
                  structElement.Attributes.Append(structNameAttribute);
                  structNode.AppendChild(structElement);
                  typenames.Add(structName);
                }

                XmlAttribute blockStructAttribute = converted.CreateAttribute("struct");
                blockStructAttribute.InnerText = structName;
                valueElement.Attributes.Append(blockStructAttribute);

                XmlAttribute maxElementsAttribute = converted.CreateAttribute("maxelements");
                maxElementsAttribute.InnerText = blockElement.Attributes["maxCount"].InnerText;
                valueElement.Attributes.Append(maxElementsAttribute);
                goto default;
              case "Struct":
                BuildBlock(field["struct"]["block"], structNode, converted, typenames, repeats, ref unnamed);
                continue;
              #endregion
              #region block index
              case "ShortBlockIndex1":
              case "LongBlockIndex":
                XmlAttribute blockAttribute = converted.CreateAttribute("block");
                blockAttribute.InnerText = GlobalMethods.MakePublicName(field.Attributes["definition"].InnerText.Replace('_', ' '));
                valueElement.Attributes.Append(blockAttribute);
                goto default;
              #endregion
              #region tag reference
              case "TagReference":
                XmlElement tagReference = field["definition"];
                XmlAttribute extensionsAttribute = converted.CreateAttribute("extensions");
                if (tagReference.Attributes["groupTag"] == null)
                {
                  StringBuilder extensions = new StringBuilder();
                  foreach (XmlNode extensionNode in tagReference["groupTags"])
                    extensions.Append(extensionNode.InnerText + '|');
                  extensionsAttribute.InnerText = extensions.ToString(0, extensions.Length - 1);
                }
                else
                  extensionsAttribute.InnerText = tagReference.Attributes["groupTag"].InnerText;
                valueElement.Attributes.Append(extensionsAttribute);
                goto default;
              #endregion
              #region flags
              case "ByteFlags":
                lengthAttribute.InnerText = "1";
                goto case "<flags>";
              case "WordFlags":
                lengthAttribute.InnerText = "2";
                goto case "<flags>";
              case "LongFlags":
                lengthAttribute.InnerText = "4";
                goto case "<flags>";
              case "<flags>":
                XmlElement bitsElement = field["definition"];
                int bitsCount = Convert.ToInt32(bitsElement.Attributes["count"].InnerText);
                for (int i = 0; i < bitsCount; i++)
                {
                  XmlElement bitElement = converted.CreateElement("bit");
                  XmlAttribute bitIndexAttribute = converted.CreateAttribute("index");
                  bitIndexAttribute.InnerText = i.ToString();
                  bitElement.Attributes.Append(bitIndexAttribute);
                  XmlAttribute bitNameAttribute = converted.CreateAttribute("name");

                  string[] bitTooltipSplit = bitsElement.ChildNodes[i].InnerText.Split('#');
                  bitNameAttribute.InnerText = bitTooltipSplit[0];

                  if (bitTooltipSplit.Length > 1)
                  {
                    XmlElement bitTooltipElement = converted.CreateElement("tooltip");
                    bitTooltipElement.InnerText = bitTooltipSplit[1];
                    bitElement.AppendChild(bitTooltipElement);
                  }

                  bitElement.Attributes.Append(bitNameAttribute);
                  valueElement.AppendChild(bitElement);
                }
                goto default;
              #endregion
              #region enums
              case "CharEnum":
                lengthAttribute.InnerText = "1";
                goto case "<enum>";
              case "Enum":
                lengthAttribute.InnerText = "2";
                goto case "<enum>";
              case "LongEnum":
                lengthAttribute.InnerText = "4";
                goto case "<enum>";
              case "<enum>":
                XmlElement entriesElement = field["definition"];
                int entriesCount = Convert.ToInt32(entriesElement.Attributes["count"].InnerText);
                for (int i = 0; i < entriesCount; i++)
                {
                  XmlElement itemElement = converted.CreateElement("item");
                  XmlAttribute itemValueAttribute = converted.CreateAttribute("value");
                  itemValueAttribute.InnerText = i.ToString();
                  itemElement.Attributes.Append(itemValueAttribute);
                  XmlAttribute itemNameAttribute = converted.CreateAttribute("name");
                  itemNameAttribute.InnerText = entriesElement.ChildNodes[i].InnerText;
                  itemElement.Attributes.Append(itemNameAttribute);
                  valueElement.AppendChild(itemElement);
                }
                goto default;
              #endregion
              #region padding
              case "Pad":
              case "Skip":
                lengthAttribute.InnerText = field.Attributes["definition"].InnerText;
                goto default;
              case "VertexBuffer":
                lengthAttribute.InnerText = "32";
                goto default;
              case "ID":
                lengthAttribute.InnerText = "4";
                goto default;
              #endregion
              #region skipped
              case "Explanation":
              case "Terminator":
              case "UeslessPad": // not a typo
              case "Custom":
                continue;
              #endregion
              default:
                string renamedStringString = field.Attributes["type"].InnerText;

                if (renamedStringString == "String")
                  renamedStringString = "FixedLengthString";
                else if (renamedStringString == "LongString")
                  renamedStringString = "LongerFixedLengthString";

                if (field.Attributes["name"] != null)
                  if (renamedStringString == "ID" && field.Attributes["name"].InnerText.ToLower().Contains("predicted"))
                    renamedStringString = "PredictedResource";

                typeAttribute.InnerText = renamedStringString
                  .Replace("LongFlags", "Flags")
                  .Replace("WordFlags", "Flags")
                  .Replace("ByteFlags", "Flags")
                  .Replace("LongEnum", "Enum")
                  .Replace("CharEnum", "Enum")
                  .Replace("ID", "Skip")
                  .Replace("VertexBuffer", "Skip")
                  .Replace("OldStringId", "StringId")
                  .Replace("ShortBlockIndex1", "ShortBlockIndex")
                  .Replace("ShortBlockIndex2", "ShortInteger")
                  .Replace("LongBlockIndex1", "LongBlockIndex")
                  .Replace("LongBlockIndex2", "LongInteger")
                  .Replace("CharBlockIndex1", "CharBlockIndex")
                  .Replace("CharBlockIndex2", "CharInteger")
                  .Replace("WordBlockFlags", "ShortInteger");

                if (field.Attributes["name"] == null || String.IsNullOrEmpty(field.Attributes["name"].InnerText))
                  nameAttribute.InnerText = "_unnamed" + unnamed++;
                else
                {
                  string fieldName = field.Attributes["name"].InnerText;

                  bool disabled = fieldName.Contains("*");
                  fieldName = fieldName.Replace("*", "");
                  bool blockName = fieldName.Contains("^");
                  fieldName = fieldName.Replace("^", "");

                  string[] tooltipSplit = fieldName.Split('#');
                  if (tooltipSplit.Length > 1)
                  {
                    XmlElement tooltipElement = converted.CreateElement("tooltip");
                    tooltipElement.InnerText = tooltipSplit[1];
                    valueElement.AppendChild(tooltipElement);
                  }

                  string[] unitSplit = tooltipSplit[0].Split(':');
                  if (unitSplit.Length > 1)
                  {
                    XmlAttribute unitAttribute = converted.CreateAttribute("unit");
                    unitAttribute.InnerText = unitSplit[1];
                    valueElement.Attributes.Append(unitAttribute);
                  }

                  if (blockName)
                  {
                    XmlAttribute blockNameAttribute = converted.CreateAttribute("blockname");
                    blockNameAttribute.InnerText = "true";
                    valueElement.Attributes.Append(blockNameAttribute);
                  }

                  string sanitized = unitSplit[0]
                    .Replace("(", "")
                    .Replace(")", "")
                    .Replace("[", "")
                    .Replace("]", "")
                    .Replace("{", "")
                    .Replace("}", "")
                    .Replace("|", "")
                    .Replace("\\", "")
                    .Replace("/", "")
                    .Replace("$", "")
                    .Replace("`", "")
                    .Replace("!", "")
                    .Replace("@", "")
                    .Replace(".", "")
                    .Replace(",", "")
                    .Replace(";", "")
                    .Replace("=", "")
                    .Replace("'", "")
                    .Replace("\"", "")
                    .Replace("<", "")
                    .Replace(">", "")
                    .Replace("?", "")
                    .Replace("~", "");

                  if (repeats.ContainsKey(sanitized))
                  {
                    int repeatCount = repeats[sanitized] + 1;
                    nameAttribute.InnerText = sanitized + repeatCount;
                    repeats[sanitized] = repeatCount;
                  }
                  else
                  {
                    nameAttribute.InnerText = sanitized;
                    repeats.Add(sanitized, 1);
                  }

                  disabledAttribute.InnerText = disabled ? "true" : "false";
                }
                break;
            }

            if (!String.IsNullOrEmpty(disabledAttribute.InnerText))
              valueElement.Attributes.Prepend(disabledAttribute);
            if (!String.IsNullOrEmpty(lengthAttribute.InnerText))
              valueElement.Attributes.Prepend(lengthAttribute);
            valueElement.Attributes.Prepend(nameAttribute);
            valueElement.Attributes.Prepend(typeAttribute);

            structNode.AppendChild(valueElement);
          }
          else if (field.Name == "arrayStart")
          {
            if (arrayLoopsRemain >= 0)
            {
              if (innerArrayLoopsRemain >= 0)
                throw new Exception("Triple-deep array constructs are not supported.");

              innerArrayStartIndex = fieldIndex;
              innerArrayLoopsRemain = Convert.ToInt32(field.Attributes["definition"].InnerText) - 1;
            }
            else
            {
              arrayStartIndex = fieldIndex;
              arrayLoopsRemain = Convert.ToInt32(field.Attributes["definition"].InnerText) - 1;
            }
          }
          else if (field.Name == "arrayEnd")
          {
            if (innerArrayLoopsRemain > 0)
            {
              innerArrayLoopsRemain--;
              fieldIndex = innerArrayStartIndex;
            }
            else
            {
              innerArrayLoopsRemain = -1;
              if (arrayLoopsRemain > 0)
              {
                arrayLoopsRemain--;
                fieldIndex = arrayStartIndex;
              }
              else
                arrayLoopsRemain = -1;
            }
          }
          else if (field.Name == "#comment")
          {
            // ignore comments
          }
          else
            throw new Exception("Unknown Element: " + field.Name);
        }
      }
    }

    private static XmlElement BuildBlock(XmlElement source, XmlDocument converted)
    {
      XmlElement structNode = converted.CreateElement("struct");
      int unnamed = 0;
      BuildBlock(source, structNode, converted, null, null, ref unnamed);
      return structNode;
    }
  }
}
