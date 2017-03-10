using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class Data : IBinaryField, INotifyPropertyChanged
  {
    private int size;
    private uint tagDataOffset;
    private uint pcDataOffset;
    private byte[] binary = new byte[0];

    public byte[] Binary
    {
      get { return binary; }
    }

		public Data() { }

		// I (rec0) need this constructor to make new Data fields for compiled script data
		public Data(byte[] sourceData)
		{
			size = sourceData.Length;
			binary = sourceData;
		}
    
		public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      size = reader.ReadInt32();
      reader.BaseStream.Position += 4;
      tagDataOffset = reader.ReadUInt32(); //these change if stuff is modified - eek
      pcDataOffset = reader.ReadUInt32(); //this one probably doesn't matter
      reader.BaseStream.Position += 4;
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void ReadBinary(BinaryReader reader)
    {
      binary = reader.ReadBytes(size);
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(size);
      //this is one of those 5 element offsets viper was talking about
      //data is not matching except for 1st element
      writer.Write(0xbaadbaad);
      writer.Write(0xbaadbaad);
      writer.Write(0xbaadbaad);
      writer.Write(0xbaadbaad);
      //writer.BaseStream.Position += 16;
    }

    public void WriteBinary(BinaryWriter writer)
    {
      writer.Write(binary);
    }

    public override string ToString()
    {
      return (string.Format("Data: size = {0:X}", size));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class DataCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public DataCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Data", name, "new Data()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Data", name, Accessors.Both);
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
