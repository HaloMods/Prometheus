using System;
using System.IO;
using System.Xml;
using System.CodeDom;
using System.Diagnostics;
using System.Collections.Generic;
using Interfaces.Factory;
using Interfaces.Games;
using System.ComponentModel;
using System.Text;

namespace Games.Halo2.Tags.Fields
{
  public class PredictedResource : IStringField, INotifyPropertyChanged
  {
    private int stringLength;
    private int stringOffset;
    private string value = "";

    public string Value
    {
      get
      { return value; }
      set
      {
        this.value = value;
        stringLength = value.Length;
      }
    }

    public void Read(BinaryReader reader)
    {
      uint encoded = reader.ReadUInt32();

      if (encoded != 0x0 && encoded != 0xffffffff)
      {
        stringLength = (int)((encoded >> 24) & 0xff);
        stringOffset = (int)(encoded & 0x00ffffff);
      }
    }

    public void ReadString(BinaryReader reader)
    {
      if (stringLength > 0)
      {
        byte[] temp = reader.ReadBytes(stringLength + 1);
        value = Encoding.ASCII.GetString(temp, 0, stringLength);
      }
    }

    public void Write(BinaryWriter writer)
    {
      if (stringLength == 0)
        writer.Write(0);
      else
      {
        uint encoded = (uint)(stringOffset = (int)writer.BaseStream.Length) & 0x00ffffff;
        encoded |= (uint)((stringLength << 24) & 0xff000000);
        writer.Write(encoded);
      }
    }

    public void WriteString(BinaryWriter writer)
    {
      if (stringLength > 0)
        StringOps.WriteCString(value, writer);
    }
    public override string ToString()
    {
      return "PredictedResource: " + value;
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }

  public class PredictedResourceCodeGenerator : IFieldCodeGenerator
  {
    private string name;

    public string Name
    {
      get { return name; }
      set { name = value; }
    }

    public PredictedResourceCodeGenerator(XmlNode node)
    {
      name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("PredictedResource", name, "new PredictedResource()");
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return GlobalMethods.GeneratePublicAccessors("PredictedResource", name, Accessors.Both);
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
