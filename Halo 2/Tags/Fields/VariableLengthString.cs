using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class VariableLengthString : IField, INotifyPropertyChanged
  {
    private string value = String.Empty;

    public string Value
    {
      get { return value; }
      set { this.value = value; NotifyPropertyChanged("Value"); }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Read(BinaryReader reader)
    {
      value = StringOps.ReadCString(reader);
    }

    public void Write(BinaryWriter writer)
    {
      StringOps.WriteCString(value, writer);
    }
  }

  /// <summary>
  /// Generates code for the VariableLengthString class.
  /// </summary>
  public class VariableLengthStringCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public VariableLengthStringCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("VariableLengthString", name, "new VariableLengthString()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("VariableLengthString", name, Accessors.Both);
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
