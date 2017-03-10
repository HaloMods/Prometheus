using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class RealPlane2D : IField, INotifyPropertyChanged
  {
    private float i;
    private float j;
    private float d;

    public float I
    {
      get { return i; }
      set { this.i = value; NotifyPropertyChanged("I"); }
    }

    public float J
    {
      get { return j; }
      set { this.j = value; NotifyPropertyChanged("J"); }
    }

    public float D
    {
      get { return d; }
      set { this.d = value; NotifyPropertyChanged("D"); }
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
      i = reader.ReadSingle();
      j = reader.ReadSingle();
      d = reader.ReadSingle();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(i);
      writer.Write(j);
      writer.Write(d);
    }
    public override string ToString()
    {
      return (string.Format("RealPlane2D: {0:N3}  {1:N3}  {2:N3}", i, j, d));
    }
  }

  public class RealPlane2DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealPlane2DCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealPlane2D", name, "new RealPlane2D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealPlane2D", name, Accessors.Both);
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
