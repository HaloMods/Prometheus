using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class LongBlockIndex : IField, INotifyPropertyChanged
  {
    private int _value;

    public int Value
    {
      get { return _value; }
      set { _value = value; NotifyPropertyChanged("Value"); }
    }

    public void Read(BinaryReader reader)
    {
      _value = reader.ReadInt32();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(_value);
    }
    public override string ToString()
    {
      return (string.Format("LongBlockIndex: {0}", _value));
    }
    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class LongBlockIndexCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public LongBlockIndexCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("LongBlockIndex", name, "new LongBlockIndex()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("LongBlockIndex", name, Accessors.Both);
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
