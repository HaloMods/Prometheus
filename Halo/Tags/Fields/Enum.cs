using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class Enum : IField, INotifyPropertyChanged
  {
    private short value;

    public short Value
    {
      get { return value; }
      set
      {
        this.value = value;
        NotifyPropertyChanged("Value");
      }
    }
  	
  	public Enum() { }
		public Enum(short value) { this.value = value; }

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      value = reader.ReadInt16();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(value);
    }
    public override string ToString()
    {
      return (string.Format("Enum: {0}", value));
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

    public string Name
    {
      get { return name; }
    }

    public EnumCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Enum", name, "new Enum()");
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
      return null;
    }
  }
}
