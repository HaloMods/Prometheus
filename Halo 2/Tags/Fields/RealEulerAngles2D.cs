using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class RealEulerAngles2D : IField, INotifyPropertyChanged
  {
    private float y;
    private float p;

    public float Y
    {
      get { return y; }
      set
      {
        y = value;
        NotifyPropertyChanged("Y");
      }
    }    
    public float P
    {
      get { return p; }
      set
      {
        p = value;
        NotifyPropertyChanged("P");
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
      y = reader.ReadSingle();
      p = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(y);
      writer.Write(p);
    }
    public override string ToString()
    {
      return (string.Format("RealEulerAngles2D: {0:N3}  {0:N3}", y, p));
    }
  }

  public class RealEulerAngles2DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealEulerAngles2DCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealEulerAngles2D", name, "new RealEulerAngles2D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealEulerAngles2D", name, Accessors.Both);
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
