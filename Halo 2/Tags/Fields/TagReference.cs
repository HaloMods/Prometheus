using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using System.Collections.Generic;
using Interfaces.Factory;
using Interfaces.Games;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class TagReference : IStringField, INotifyPropertyChanged
  {
    static TypeTable typeTable = new Halo2TypeTable();
    
    private byte[] tagGroup = new byte[4];
    private int stringLength;
    private int stringOffset;
    private string value = "";

    public string TagGroup
    {
      get
      {
        char[] fourcc = new char[4] { (char)tagGroup[3], (char)tagGroup[2], (char)tagGroup[1], (char)tagGroup[0], };
        string tmp = new string(fourcc);
        return tmp;
      }
      set
      {
        tagGroup[0] = (byte)value[3];
        tagGroup[1] = (byte)value[2];
        tagGroup[2] = (byte)value[1];
        tagGroup[3] = (byte)value[0];
      }
    }

    public string Value
    {
      get
      {
        if (value == "") return "";
        else return value + "." + typeTable.LocateEntryByFourCC(TagGroup).FullName; }
      set
      {
        if (!String.IsNullOrEmpty(value))
        {
          string newValue = Path.GetDirectoryName(value) + "\\" + Path.GetFileNameWithoutExtension(value);
          if (newValue != this.value)
          {
            // TODO: This does not yet support files that are of a different extension than the default.
            // This will involve looking up the extension in the TypeTable and setting the tagGroup.

            // Set the new value and fire the event.
            this.value = newValue;
            stringLength = value.Length;
            if (PropertyChanged != null)
              PropertyChanged(this, new PropertyChangedEventArgs("Value"));
          }
        }
      }
    }

    public void Read(BinaryReader reader)
    {
      tagGroup = reader.ReadBytes(4);

      uint encoded = reader.ReadUInt32();
      if (encoded != 0xffffffff && encoded != 0x0)
      {
        stringLength = (int)((encoded >> 24) & 0xff);
        stringOffset = (int)(encoded & 0x00ffffff);
      }
      else
        stringLength = 0;
    }

    public void ReadString(BinaryReader reader)
    {
      if (stringLength > 0)
      {
        byte[] temp = reader.ReadBytes(stringLength + 1);
        value = System.Text.Encoding.ASCII.GetString(temp, 0, stringLength);
      }
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(tagGroup);
      if (stringLength == 0)
        writer.Write(0);
      else
      {
        uint encoded = (uint)(stringOffset = (int)writer.BaseStream.Length) & 0x00ffffff;
        encoded |= (uint)((stringLength << 24) & 0xff000000);
        writer.Write(encoded);
      }
    }

    public void WriteString(BinaryWriter writer)
    {
      if (stringLength > 0)
        StringOps.WriteCString(value, writer);
    }

    public override string ToString()
    {
      return Path.GetFileName(value);
    }
    public string ToPreString()
    {
      return (string.Format("TagRef: {0}{1}{2}{3} strlen= {4}", (char)tagGroup[0], (char)tagGroup[1], (char)tagGroup[2], (char)tagGroup[3], stringLength));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class TagReferenceCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public TagReferenceCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("TagReference", name, "new TagReference()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("TagReference", name, Accessors.Both);
    }

    public string GenerateMetadataInitializer()
    {
      return null;
    }

    public CodeStatement GenerateConstructorLogic()
    {
      return null;
    }
  }
}
