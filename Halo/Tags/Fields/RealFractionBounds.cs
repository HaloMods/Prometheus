using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo.Tags.Fields
{
  public class RealFractionBounds : IField, INotifyPropertyChanged
  {
    private float lower;
    private float upper;

    public float Lower
    {
      get { return lower; }
      set { lower = value; NotifyPropertyChanged("Lower"); }
    }

    public float Upper
    {
      get { return upper; }
      set { upper = value; NotifyPropertyChanged("Upper"); }
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
      lower = reader.ReadSingle();
      upper = reader.ReadSingle();
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(lower);
      writer.Write(upper);
    }
    public override string ToString()
    {
      return (string.Format("RealFractionBounds: {0}  {1}", lower, upper));
    }
  }

  public class RealFractionBoundsCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public RealFractionBoundsCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("RealFractionBounds", name, "new RealFractionBounds()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("RealFractionBounds", name, Accessors.Both);
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
