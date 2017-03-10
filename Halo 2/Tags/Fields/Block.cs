using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
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
      count = reader.ReadInt32();
      offset = reader.ReadInt32();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(count);

      //store the location of the reflexive offset so we can update it later
      offsetLocation = (int)writer.BaseStream.Position;
      writer.BaseStream.Position += 4;
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
