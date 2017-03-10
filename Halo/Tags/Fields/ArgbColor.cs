using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using System.ComponentModel;
using Interfaces.Factory;

namespace Games.Halo.Tags.Fields
{
  public class ARGBColor : IField, System.ComponentModel.INotifyPropertyChanged
  {
    private byte a = 0;
    private byte r = 0;
    private byte g = 0;
    private byte b = 0;

    public byte A
    {
      get { return a; }
      set { a = value; NotifyPropertyChanged("A"); }
    }

    public byte R
    {
      get { return r; }
      set { r = value; NotifyPropertyChanged("R"); }
    }

    public byte G
    {
      get { return g; }
      set { g = value; NotifyPropertyChanged("G"); }
    }

    public byte B
    {
      get { return b; }
      set { b = value; NotifyPropertyChanged("B"); }
    }

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      a = reader.ReadByte();
      r = reader.ReadByte();
      g = reader.ReadByte();
      b = reader.ReadByte();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(a);
      writer.Write(r);
      writer.Write(g);
      writer.Write(b);
    }
    public override string ToString()
    {
      return (string.Format("ARGBColor: {0:X} {1:X} {2:X} {3:X}", a, r, g, b));
    }
    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class ARGBColorCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public ARGBColorCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("ARGBColor", name, "new ARGBColor()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("ARGBColor", name, Accessors.Both);
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
