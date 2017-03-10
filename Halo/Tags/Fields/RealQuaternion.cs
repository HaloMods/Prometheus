using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class RealQuaternion : IField, INotifyPropertyChanged
  {
    private float i = 0;
    private float j = 0;
    private float k = 0;
    private float w = 0;

    public float I
    {
      get { return i; }
      set { i = value; NotifyPropertyChanged("I"); }
    }

    public float J
    {
      get { return j; }
      set { j = value; NotifyPropertyChanged("J"); }
    }

    public float K
    {
      get { return k; }
      set { k = value; NotifyPropertyChanged("K"); }
    }

    public float W
    {
      get { return w; }
      set { w = value; NotifyPropertyChanged("W"); }
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
      k = reader.ReadSingle();
      w = reader.ReadSingle();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(i);
      writer.Write(j);
      writer.Write(k);
      writer.Write(w);
    }
    public override string ToString()
    {
      return (string.Format("RealQuaternion: {0:N3}  {1:N3}  {2:N3}  {3:N3}", i, j, k, w));
    }
  }

  public class RealQuaternionCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public RealQuaternionCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public string Name
    {
      get { return name; }
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealQuaternion", name, "new RealQuaternion()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealQuaternion", name, Accessors.Both);
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
