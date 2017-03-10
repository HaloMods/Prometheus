using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using System.Collections.Generic;
using Interfaces.Factory;
using Interfaces.Games;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class TagReference : IStringField, INotifyPropertyChanged
  {
    static TypeTable typeTable = new HaloTypeTable();
    static public Queue<int> StringOffsetQueue = new Queue<int>();
    
    private byte[] tagGroup = new byte[4];
    private int stringLength;
    private string value = "";

    public string TagGroup
    {
      get
      {
        char[] fourcc = new char[4] { (char)tagGroup[3], (char)tagGroup[2], (char)tagGroup[1], (char)tagGroup[0], };
        string tmp = new string(fourcc);

        // HACK: For some reason,certain fourcc's are reversed in the tag...  probably related
        // to the old decompiler in some way.  Hacking in a fix here for now, until this can be looked at,
        // or verified as already fixed.
        if (tmp == "2dom") return "mod2";
        if (tmp == "lloc") return "coll";
        
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
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      tagGroup = reader.ReadBytes(4);
      reader.BaseStream.Position += 4;
      stringLength = reader.ReadInt32();
      reader.BaseStream.Position += 4;
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToPreString());
    }

    public void ReadString(BinaryReader reader)
    {
      if (stringLength > 0)
      {
        byte[] temp = reader.ReadBytes(stringLength + 1);
        value = System.Text.Encoding.ASCII.GetString(temp, 0, stringLength);
        if (TagDebug.EnableReadDebug) Trace.WriteLine(ToString() + "\r\n" + string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40));
      }
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(tagGroup);
      if (stringLength > 0)
        StringOffsetQueue.Enqueue((int)writer.BaseStream.Position);
      writer.Write(0);
      writer.Write(stringLength);
      writer.Write(-1);
    }

    public void WriteString(BinaryWriter writer)
    {
      if (stringLength > 0)
      {
        int current_offset = (int)writer.BaseStream.Position;
        int offset_location = StringOffsetQueue.Dequeue();
        writer.BaseStream.Position = offset_location;
        writer.Write(current_offset);
        writer.BaseStream.Position = current_offset;
        StringOps.WriteCString(value, writer);
      }
    }
    public override string ToString()
    {
      //return (string.Format("TagRef(string): {0}{1}{2}{3} -> {4}", (char)tagGroup[0], (char)tagGroup[1], (char)tagGroup[2], (char)tagGroup[3], value));
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
