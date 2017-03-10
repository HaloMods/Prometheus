using System.CodeDom;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Interfaces.Factory;
using Interfaces.Rendering.Wrappers;

namespace Games.Halo2.Tags.Fields
{
  public class RealEulerAngles3D : IField, IAngle3D, INotifyPropertyChanged
  {
    private float roll, pitch, yaw;

    public float Yaw
    {
      get { return yaw; }
      set
      {
        yaw = value;
        NotifyPropertyChanged("Yaw");
      }
    }

    public float Pitch
    {
      get { return pitch; }
      set
      {
        pitch = value;
        NotifyPropertyChanged("Pitch");
      }
    }

    public float Roll
    {
      get { return roll; }
      set
      {
        roll = value;
        NotifyPropertyChanged("Roll");
      }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public void Read(BinaryReader reader)
    {
      yaw = reader.ReadSingle();
      pitch = reader.ReadSingle();
      roll = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(yaw);
      writer.Write(pitch);
      writer.Write(roll);
    }

    public override string ToString()
    {
      return (string.Format("RealEulerAngles3D: {0:N3}  {1:N3}  {2:N3}", yaw, pitch, roll));
    }

    ///<summary>
    ///Occurs when a property value changes.
    ///</summary>
    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class RealEulerAngles3DCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealEulerAngles3DCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealEulerAngles3D", name, "new RealEulerAngles3D()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealEulerAngles3D", name, Accessors.Both);
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
