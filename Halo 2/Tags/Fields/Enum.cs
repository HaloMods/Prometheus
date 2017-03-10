using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class Enum : IField, INotifyPropertyChanged
  {
    private int value;
    private int length;

    public int Value
    {
      get { return value; }
      set
      {
        this.value = value;
        NotifyPropertyChanged("Value");
      }
    }
  	
		public Enum(int length) { this.length = length; }

    public void Read(BinaryReader reader)
    {
      if (length == 1) value = (int)reader.ReadSByte();
      else if (length == 2) value = (int)reader.ReadInt16();
      else if (length == 4) value = reader.ReadInt32();
    }

    public void Write(BinaryWriter writer)
    {
      if (length == 1) writer.Write(Convert.ToSByte(value));
      else if (length == 2) writer.Write(Convert.ToInt16(value));
      else if (length == 4) writer.Write(value);
    }
    public override string ToString()
    {
      return (string.Format("{1}-bit Enum: {0}", value, length));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class EnumCodeGenerator : IFieldCodeGenerator
  {
    private string name;
    private XmlNode node;

    public string Name
    {
      get { return name; }
    }

    public EnumCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
      this.node = node;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Enum", name);
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Enum", name, Accessors.Both);
    }

    public string GenerateMetadataInitializer()
    {
      return null;
    }

    public CodeStatement GenerateConstructorLogic()
    {
      int length = Convert.ToInt32(node.Attributes["length"].InnerText);
      string privateName = GlobalMethods.MakePrivateName(name);
      CodeStatement statement = new CodeAssignStatement(
        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), privateName),
        new CodeObjectCreateExpression("Enum", new CodePrimitiveExpression(length)));
      return statement;
    }
  }
}
