using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class Rectangle2D : IField, INotifyPropertyChanged
  {
    private short t;
    private short l;
    private short b;
    private short r;

    public short T
    {
      get { return t; }
      set { t = value; NotifyPropertyChanged("T"); }
    }

    public short L
    {
      get { return l; }
      set { l = value; NotifyPropertyChanged("L"); }
    }

    public short B
    {
      get { return b; }
      set { b = value; NotifyPropertyChanged("B"); }
    }

    public short R
    {
      get { return r; }
      set { r = value; NotifyPropertyChanged("R"); }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      t = reader.ReadInt16();
      l = reader.ReadInt16();
      b = reader.ReadInt16();
      r = reader.ReadInt16();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(t);
      writer.Write(l);
      writer.Write(b);
      writer.Write(r);
    }
    public override string ToString()
    {
      return (string.Format("Rectangle2D: {0:N5} {1:N5} {2:N5} {3:N5}", t, l, b, r));
    }
  }

  public class Rectangle2DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public Rectangle2DCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Rectangle2D", name, "new Rectangle2D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Rectangle2D", name, Accessors.Both);
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
