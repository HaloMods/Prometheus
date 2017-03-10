
namespace Interfaces.Scripting.EngineDefinition.Lookup
{
	public abstract class ExpressionReference
	{
	}

	public class FunctionReference : ExpressionReference
	{
		private Function m_function;
		private byte m_overload;

		public Function Function
		{
			get { return m_function; }
		}

		public byte Overload
		{
			get { return m_overload; }
		}

		public FunctionReference(Function function, byte overload)
		{
			m_function = function;
			m_overload = overload;
		}
	}

	public class OperatorReference : ExpressionReference
	{
		private InternalFunction m_operation;

		public InternalFunction Operation
		{
			get { return m_operation; }
		}

		public OperatorReference(InternalFunction @operator)
		{
			m_operation = @operator;
		}
	}

	public class GlobalReference : ExpressionReference
	{
		public enum AccessMethod
		{
			Get,
			Set
		}

		private Global m_global;
		private AccessMethod m_method;

		public Global Global
		{
			get { return m_global; }
		}

		public AccessMethod Method
		{
			get { return m_method; }
		}

		public GlobalReference(Global global, AccessMethod method)
		{
			m_global = global;
			m_method = method;
		}
	}

	public class CasterReference : ExpressionReference
	{
		/*private InternalFunction m_caster;

		public InternalFunction Caster
		{
			get { return m_caster; }
		}

		public CasterReference(InternalFunction caster)
		{
			m_caster = caster;
		}*/
	}
}
