using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;
using System.ComponentModel;

namespace Games.Halo2.Tags.Fields
{
  public class ShortIntegerBounds : IField, INotifyPropertyChanged
  {
    private short lower;
    private short upper;

    public short Lower
    {
      get { return lower; }
      set { lower = value; NotifyPropertyChanged("Lower"); }
    }

    public short Upper
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
      lower = reader.ReadInt16();
      upper = reader.ReadInt16();
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(lower);
      writer.Write(upper);
    }
    public override string ToString()
    {
      return (string.Format("ShortBounds: {0} to {1}", lower, upper));
    }
  }

  public class ShortIntegerBoundsCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
    }

    public ShortIntegerBoundsCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("ShortIntegerBounds", name, "new ShortIntegerBounds()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("ShortIntegerBounds", name, Accessors.Both);
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
