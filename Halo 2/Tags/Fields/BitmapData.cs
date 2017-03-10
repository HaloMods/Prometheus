using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class BitmapData : IBinaryField, INotifyPropertyChanged
  {
    private const int Levels = 6;

    private int[] size = new int[Levels];
    private int[] offset = new int[Levels];
    private byte[][] binary = new byte[Levels][];
    
		public void Read(BinaryReader reader)
    {
      for (int i = 0; i < Levels; i++)
        offset[i] = reader.ReadInt32();
      for (int i = 0; i < Levels; i++)
        size[i] = reader.ReadInt32();
    }

    public void ReadBinary(BinaryReader reader)
    {
      for (int i = 0; i < Levels; i++)
      {
        if (size[i] > 0)
        {
          //reader.BaseStream.Position = offset[i] & 0x3fffffff;
          binary[i] = reader.ReadBytes(size[i]);
        }
        else
          binary[i] = new byte[0];
      }
    }

    public void Write(BinaryWriter writer)
    {
      int currentPosition = (int)writer.BaseStream.Length;
      for (int i = 0; i < Levels; i++)
      {
        if (size[i] > 0)
        {
          offset[i] = (int)(currentPosition | (offset[i] & 0xc0000000));
          writer.Write(offset[i]);
          currentPosition += size[i];
        }
        else
          writer.Write(0);
      }
      for (int i = 0; i < Levels; i++)
        writer.Write(size[i]);
    }

    public void WriteBinary(BinaryWriter writer)
    {
      long position = writer.BaseStream.Position;
      for (int i = 0; i < Levels; i++)
      {
        if (size[i] > 0)
        {
          writer.BaseStream.Position = offset[i] & 0x3fffffff;
          writer.Write(binary[i]);
        }
      }
      writer.BaseStream.Position = position;
    }

    public override string ToString()
    {
      return (string.Format("BitmapData: size = {0:X}", size));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class BitmapDataCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public BitmapDataCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("BitmapData", name, "new BitmapData()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("BitmapData", name, Accessors.Both);
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
