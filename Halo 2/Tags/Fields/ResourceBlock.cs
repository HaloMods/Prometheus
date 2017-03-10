using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class ResourceBlock : IBinaryField, INotifyPropertyChanged
  {
    private int size;
    private byte[] binary = new byte[0];

    public byte[] Binary
    {
      get { return binary; }
    }

		public ResourceBlock() { }

    public ResourceBlock(byte[] sourceData)
		{
			size = sourceData.Length;
			binary = sourceData;
		}
    
		public void Read(BinaryReader reader)
    {
      reader.BaseStream.Position += 4;
      size = reader.ReadInt32();
    }

    public void ReadBinary(BinaryReader reader)
    {
      binary = reader.ReadBytes(size);
    }

    public void Write(BinaryWriter writer)
    {
      writer.BaseStream.Position += 4;
      writer.Write(size);
    }

    public void WriteBinary(BinaryWriter writer)
    {
      writer.Write(binary);
    }

    public override string ToString()
    {
      return (string.Format("ResourceBlock: size = {0:X}", size));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class ResourceBlockCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public ResourceBlockCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("ResourceBlock", name, "new ResourceBlock()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("ResourceBlock", name, Accessors.Both);
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
