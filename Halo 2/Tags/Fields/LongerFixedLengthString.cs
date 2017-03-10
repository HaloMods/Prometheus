using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class LongerFixedLengthString : IField, INotifyPropertyChanged
  {
    private string value = "";

    public string Value
    {
      get { return value; }
      set
      {
        this.value = value;
        NotifyPropertyChanged("Value");
      }
    }

    public LongerFixedLengthString() { }
  	public LongerFixedLengthString(string @string) { value = @string; }
  	
    public void Read(BinaryReader reader)
    {
    	value = StringOps.ReadFixedLengthCString(reader, 256);
    }

    public void Write(BinaryWriter writer)
    {
      StringOps.WriteFixedLengthCString(value, writer, 256);
    }

    public override string ToString()
    {
      return value;
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
  public class LongerFixedLengthStringCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public LongerFixedLengthStringCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("LongerFixedLengthString", name, "new LongerFixedLengthString()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("LongerFixedLengthString", name, Accessors.Both);
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
