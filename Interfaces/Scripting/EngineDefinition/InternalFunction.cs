using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
	public enum FunctionSpecification
	{
		// Special-use (cannot be used with PSL function syntax) programmatically identifiable (SUPI) functions
			OperatorsStart,
			// Mathematical operators
			Add = OperatorsStart,
			Subtract,
			Multiply,
			Divide,
			// Comparison operators
			Equals,
			NotEquals,
			GreaterThan,
			LessThan,
			GreaterThanOrEqualTo,
			LessThanOrEqualTo,
			// Logical operators
			And,
			Or,
			Not,
			// Special operations
			SpecialOperationsStart,
			Begin = SpecialOperationsStart,
			BeginRandom,
			If,
			Cond,
			Set,
			ListGet,
		// End SUPI functions
		SupiFunctionCount,
		// Regular-use (PSL function syntax) programmatically identifiable (RUPI) functions
			RupiFunctionsStart = SupiFunctionCount,
			Sleep = RupiFunctionsStart,
		// End RUPI functions
		SpecificFunctionCount,
	}
	
  public class InternalFunction
  {
    private string m_name;
		private FunctionSpecification m_specification;
    private short m_operationCode;
    private short m_returnType;
    private string m_description;
    private Argument[] m_arguments;

    [XmlAttribute()]
    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

		[XmlAttribute()]
  	public FunctionSpecification Specification
  	{
  		get { return m_specification; }
  		set { m_specification = value; }
  	}

  	[XmlAttribute()]
    public short OperationCode
    {
      get { return m_operationCode; }
      set { m_operationCode = value; }
    }

    [XmlAttribute()]
    public short ReturnType
    {
      get { return m_returnType; }
      set { m_returnType = value; }
    }

    public string Description
    {
      get { return m_description; }
      set { m_description = value; }
    }

    public Argument[] Arguments
    {
      get { return m_arguments; }
      set { m_arguments = value; }
    }

    public InternalFunction(string name, short operationCode, short returnType, string description, Argument[] arguments)
    {
      m_name = name;
      m_operationCode = operationCode;
      m_returnType = returnType;
      m_description = description;
      m_arguments = arguments;
    }
    
    public InternalFunction() { }
  }
}
