using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class RealRGBColor : IField, INotifyPropertyChanged
  {
    private float r;
    private float g;
    private float b;

    public float R
    {
      get { return r; }
      set { r = value; NotifyPropertyChanged("R"); }
    }

    public float G
    {
      get { return g; }
      set { g = value; NotifyPropertyChanged("G"); }
    }

    public float B
    {
      get { return b; }
      set { b = value; NotifyPropertyChanged("B"); }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void Read(BinaryReader reader)
    {
      r = reader.ReadSingle();
      g = reader.ReadSingle();
      b = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(r);
      writer.Write(g);
      writer.Write(b);
    }
    public override string ToString()
    {
      return (string.Format("RealRGBColor: {0:N3} {1:N3} {2:N3}", r, g, b));
    }
  }

  public class RealRGBColorCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealRGBColorCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealRGBColor", name, "new RealRGBColor()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealRGBColor", name, Accessors.Both);
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
