using System;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using Interfaces.Rendering.Wrappers;

namespace Games.Halo2.Tags.Fields
{
  public class Angle : IField, IAngle3D, INotifyPropertyChanged
  {
    private float value = 0f;

    public float Value
    {
      get { return value; }
      set
      {
        this.value = value;
        NotifyPropertyChanged("Value");
      }
    }

    public int ValueDegrees
    {
      get { return Convert.ToInt32(Math.Round(value / (Math.PI / 180))); }
      set { Value = Convert.ToSingle(Math.PI / 180) * value; }
    }

    public float Pitch
    {
      get { return 0; }
      set { }
    }

    public float Roll
    {
      get { return 0; }
      set { }
    }

    public float Yaw
    {
      get { return Value; }
      set { Value = value; }
    }

    private void NotifyPropertyChanged(string info)
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs(info));
    }

    public void Read(BinaryReader reader)
    {
      value = reader.ReadSingle();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(value);
    }
    public override string ToString()
    {
      return (string.Format("Angle: {0:N3}", value));
    }

    ///<summary>
    ///Occurs when a property value changes.
    ///</summary>
    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class AngleCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public AngleCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Angle", name, "new Angle()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("Angle", name, Accessors.Both);
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
