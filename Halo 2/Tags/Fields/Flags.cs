using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class Flags : IField,INotifyPropertyChanged
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

    public int Length
    {
      get { return length; }
      set { length = value; NotifyPropertyChanged("Length"); }
    }

    /// <param name="length">Length in bytes of the Flags field.  Can be 1, 2, or 4.</param>
    public Flags(int length)
    {
      this.length = length;
    }

    public bool GetFlag(int index)
    {
      return ((value & (1 << (index - 1))) > 0);
    }

    public void SetFlag(int index, bool on)
    {
      if (on)
      {
        Value = this.value | (1 << (index - 1));
      }
      else
      {
        Value = this.value & ~(1 << (index - 1));
      }
    }

    public void Read(BinaryReader reader)
    {
      if (length == 1) value = (int)reader.ReadByte();
      else if (length == 2) value = (int)reader.ReadInt16();
      else if (length == 4) value = reader.ReadInt32();
    }

    public void Write(BinaryWriter writer)
    {
      if (length == 1) writer.Write(Convert.ToByte(value));
      else if (length == 2) writer.Write(Convert.ToInt16(value));
      else if (length == 4) writer.Write(value);
    }
    public override string ToString()
    {
      return (string.Format("Flags: {0:X}", value));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class FlagsCodeGenerator : IFieldCodeGenerator
  {
    private string name;
    private XmlNode node;

    public string Name
    {
      get { return name; }
    }

    public FlagsCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
      this.node = node;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Flags", name);
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Flags", name, Accessors.Both);
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
        new CodeObjectCreateExpression("Flags", new CodePrimitiveExpression(length)));
      return statement;
    }
  }
}
