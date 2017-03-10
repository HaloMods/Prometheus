using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class RealPlane3D : IField, INotifyPropertyChanged
  {
    private float i;
    private float j;
    private float k;
    private float d;

    public float I
    {
      get { return i; }
      set { this.i = value; NotifyPropertyChanged("I"); }
    }

    public float K
    {
      get { return k; }
      set { this.k = value; NotifyPropertyChanged("K"); }
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
      i = reader.ReadSingle();
      j = reader.ReadSingle();
      k = reader.ReadSingle();
      d = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(i);
      writer.Write(j);
      writer.Write(k);
      writer.Write(d);
    }
    public override string ToString()
    {
      return (string.Format("RealPlane3D: {0:N3}  {1:N3}  {2:N3}  {3:N3}", i, j, k, d));
    }
  }

  public class RealPlane3DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealPlane3DCodeGenerator(XmlNode node)
    {
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealPlane3D", name, "new RealPlane3D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealPlane3D", name, Accessors.Both);
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
