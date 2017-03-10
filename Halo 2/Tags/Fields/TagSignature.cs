using System;
using System.IO;
using System.CodeDom;
using System.Xml;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class TagSignature : IField, INotifyPropertyChanged
  {
    private char[] tag = new char[4];

    public char[] Tag
    {
      get { return tag; }
      set { tag = value; NotifyPropertyChanged("Tag"); }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Read(BinaryReader reader)
    {
      tag = reader.ReadChars(4);
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(tag);
    }
    public override string ToString()
    {
      return (string.Format("Signature: {0}{1}{2}{3}", tag[0], tag[1], tag[2], tag[3]));
    }
  }

  public class TagCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public TagCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("TagSignature", name, "new TagSignature()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("TagSignature", name, Accessors.Both);
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
