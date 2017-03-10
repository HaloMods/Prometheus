using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class Block : IField, INotifyPropertyChanged
  {
    private int count;
    private int offset;
    private int offsetLocation;

    public int Count
    {
      get { return count; }
      set { count = value; NotifyPropertyChanged("Count"); }
    }
    public int Offset
    {
      get { return offset; }
      set { offset = value; NotifyPropertyChanged("Offset"); }
    }

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      count = reader.ReadInt32();
      offset = reader.ReadInt32();
      reader.BaseStream.Position += 4;
      if (TagDebug.EnableReadDebug && (count > 0)) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(count);

      //store the location of the reflexive offset so we can update it later
      offsetLocation = (int)writer.BaseStream.Position;
      Trace.WriteLine(string.Format("offset at {0:X}", (int)writer.BaseStream.Position + 0x40));
      //writer.Write(0xbaadf00d);
      writer.BaseStream.Position += 8;
    }
    public override string ToString()
    {
      return (string.Format("Block:  Count = {0}  Offset = 0x{1:X}", count, offset));
    }
    public void UpdateReflexiveOffset(BinaryWriter writer)
    {
      if (count > 0)
      {
        int current_location = (int)writer.BaseStream.Position;
        writer.BaseStream.Position = this.offsetLocation;
        writer.Write(current_location);
        writer.BaseStream.Position = current_location;
      }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class BlockCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public BlockCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Block", name, "new Block()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Block", name, Accessors.Both);
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
