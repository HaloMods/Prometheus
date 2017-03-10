using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class Point2D : IField, INotifyPropertyChanged
  {
    private short x;
    private short y;

    public short X
    {
      get { return x; }
      set { this.x = value; NotifyPropertyChanged("X"); }
    }

    public short Y
    {
      get { return y; }
      set { this.y = value; NotifyPropertyChanged("Y"); }
    }

    public void Read(BinaryReader reader)
    {
      x = reader.ReadInt16();
      y = reader.ReadInt16();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(x);
      writer.Write(y);
    }

    public override string ToString()
    {
      return (string.Format("Point2D: ({0},{1})", x, y));
    }
    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class Point2DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public Point2DCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Point2D", name, "new Point2D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Point2D", name, Accessors.Both);
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
