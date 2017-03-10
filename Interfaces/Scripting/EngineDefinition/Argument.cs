using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
  public class Argument
  {
    private string m_name;
    private short m_type;
    private string m_description;

    [XmlAttribute()]
    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

    [XmlAttribute()]
    public short Type
    {
      get { return m_type; }
      set { m_type = value; }
    }

    public string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    public Argument(string name, short type, string description)
    {
      m_name = name;
      m_type = type;
      m_description = description;
    }
    
    public Argument() { }
  }
}
