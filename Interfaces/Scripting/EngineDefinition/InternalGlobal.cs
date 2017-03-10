using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
  public class InternalGlobal
  {
    private string m_name;
    private short m_operationCode;
    private short m_type;

    [XmlAttribute()]
    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

    [XmlAttribute()]
    public short OperationCode
    {
      get { return m_operationCode; }
      set { m_operationCode = value; }
    }

    [XmlAttribute()]
    public short Type
    {
      get { return m_type; }
      set { m_type = value; }
    }

    public InternalGlobal(string name, short operationCode, short type)
    {
      m_name = name;
      m_operationCode = operationCode;
      m_type = type;
    }

    public InternalGlobal() { }
  }
}
