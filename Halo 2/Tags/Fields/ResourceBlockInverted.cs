using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class ResourceBlockInverted : IBinaryField, INotifyPropertyChanged
  {
    private int size;
    private byte[] binary = new byte[0];

    public byte[] Binary
    {
      get { return binary; }
    }

    public ResourceBlockInverted() { }

    public ResourceBlockInverted(byte[] sourceData)
		{
			size = sourceData.Length;
			binary = sourceData;
		}
    
		public void Read(BinaryReader reader)
    {
      size = reader.ReadInt32();
      reader.BaseStream.Position += 4;
    }

    public void ReadBinary(BinaryReader reader)
    {
      binary = reader.ReadBytes(size);
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(size);
      writer.BaseStream.Position += 4;
    }

    public void WriteBinary(BinaryWriter writer)
    {
      writer.Write(binary);
    }

    public override string ToString()
    {
      return (string.Format("ResourceBlockInverted: size = {0:X}", size));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class ResourceBlockInvertedCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public ResourceBlockInvertedCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("ResourceBlockInverted", name, "new ResourceBlockInverted()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("ResourceBlockInverted", name, Accessors.Both);
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
