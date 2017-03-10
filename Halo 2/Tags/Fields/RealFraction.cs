using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class RealFraction : IField
  {
    private float value;
    public float Value
    {
      get { return value; }
      set
      {
        this.value = value;
        NotifyPropertyChanged("Value");
      }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Read(BinaryReader reader)
    {
      value = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(value);
    }
    public override string ToString()
    {
      return (string.Format("RealFraction: {0:N3}", value));
    }
  }

  public class RealFractionCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealFractionCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealFraction", name, "new RealFraction()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealFraction", name, Accessors.Both);
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
