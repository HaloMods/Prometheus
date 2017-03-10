using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Interfaces.Factory;

namespace Games.Halo.Tags.Fields
{
  public class RealVector3D : IField, INotifyPropertyChanged
  {
    private float i;
    private float j;
    private float k;

    public float I
    {
      get { return i; }
      set 
      {
        i = value;
        NotifyPropertyChanged("I");
      }
    }

    public float K
    {
      get { return k; }
      set
      {
        k = value;
        NotifyPropertyChanged("K");
      }
    }

    public float J
    {
      get { return j; }
      set
      {
        j = value;
        NotifyPropertyChanged("J");
      }
    }

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      i = reader.ReadSingle();
      j = reader.ReadSingle();
      k = reader.ReadSingle();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(i);
      writer.Write(j);
      writer.Write(k);
    }

    public override string ToString()
    {
      return (string.Format("RealVector3D: {0:N3}  {1:N3}  {2:N3}", i, j, k));
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    ///<summary>
    ///Occurs when a property value changes.
    ///</summary>
    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class RealVector3DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealVector3DCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealVector3D", name, "new RealVector3D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealVector3D", name, Accessors.Both);
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
