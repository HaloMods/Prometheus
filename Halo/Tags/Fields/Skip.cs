using System;
using System.IO;
using System.Xml;
using System.Text;
using System.CodeDom;
using System.Diagnostics;
using Interfaces.Factory;

namespace Games.Halo.Tags.Fields
{
  public class Skip : IField
  {
    private int length;
    private byte[] data;

    public int Length
    {
      get { return length; }
    }

    public Skip(int length)
    {
      this.length = length;
      data = new byte[length];
    }

    public void Read(BinaryReader reader)
    {
      string pos = null; ;
      if (TagDebug.EnableReadDebug) pos = string.Format("    {0:X}:  ", (int)reader.BaseStream.Position + 0x40);
      data = reader.ReadBytes(length);
      if (TagDebug.EnableReadDebug) Trace.WriteLine(pos + ToString());
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write(data);
    }
    public override string ToString()
    {
      int c = 0;
      StringBuilder sb = new StringBuilder();
      //sb.Remove(0, sb.Length);
      sb.Append(string.Format("Skip: Length = 0x{0:X}\r\n", length));
      while (c < length)
      {
        sb.Append(string.Format("{0:X2}", data[c]));

        if (((c + 1) % 4) == 0)
          sb.Append(" ");

        if (((c + 1) % 16) == 0)
          sb.Append("\r\n");
        c++;
      }
      sb.Append("\r\n");
      return (sb.ToString());
    }
  }

  public class SkipCodeGenerator : IFieldCodeGenerator
  {
    private XmlNode node;
    private string name;

    public string Name
    {
      get { return name; }
    }

    public SkipCodeGenerator(XmlNode node)
    {
      this.node = node;
      this.name = node.Attributes["name"].InnerText;
    }

    public CodeMemberField GeneratePrivateMember()
    {
      return GlobalMethods.GeneratePrivateMember("Skip", name);
    }

    public CodeMemberProperty GeneratePublicAccessors()
    {
      return null;
    }

    public string GenerateMetadataInitializer()
    {
      return null;
    }
    public CodeStatement GenerateConstructorLogic()
    {
      int length = Convert.ToInt32(node.Attributes["length"].Value);
      string privateName = GlobalMethods.MakePrivateName(name);
      CodeStatement statement = new CodeAssignStatement(
        new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), privateName),
        new CodeObjectCreateExpression("Skip", new CodePrimitiveExpression(length)));
      return statement;
    }
  }
}
