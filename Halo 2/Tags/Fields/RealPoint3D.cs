using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Interfaces.Factory;
using Interfaces.Rendering.Wrappers;

namespace Games.Halo2.Tags.Fields
{
  public class RealPoint3D : IField, IPoint3D, INotifyPropertyChanged
  {
    private float x, y, z;

    public float X
    {
      get { return x; }
      set
      {
        x = value;
        NotifyPropertyChanged("X");
      }
    }

    public float Y
    {
      get { return y; }
      set
      {
        y = value;
        NotifyPropertyChanged("Y");
      }
    }

    public float Z
    {
      get { return z; }
      set
      {
        z = value;
        NotifyPropertyChanged("Z");
      }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public void Read(BinaryReader reader)
    {
      x = reader.ReadSingle();
      y = reader.ReadSingle();
      z = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(x);
      writer.Write(y);
      writer.Write(z);
    }
    public override string ToString()
    {
      return (string.Format("RealPoint3D: ({0:N3},{1:N3},{2:N3})", x, y, z));
    }

    ///<summary>
    ///Occurs when a property value changes.
    ///</summary>
    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class RealPoint3DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealPoint3DCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealPoint3D", name, "new RealPoint3D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealPoint3D", name, Accessors.Both);
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
