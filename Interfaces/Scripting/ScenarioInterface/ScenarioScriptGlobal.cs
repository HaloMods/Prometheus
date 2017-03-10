
namespace Interfaces.Scripting.ScenarioInterface
{
	public class ScenarioScriptGlobal
	{
		private string m_name;
		private short m_Type;
		private short m_initialisationExpressionIndex;

		public string Name
		{
			get { return m_name; }
		}

		public short Type
		{
			get { return m_Type; }
		}

		public short InitialisationExpressionIndex
		{
			get { return m_initialisationExpressionIndex; }
		}

		public ScenarioScriptGlobal(string name, short type, short initialisationExpressionIndex)
		{
			m_name = name;
			m_Type = type;
			m_initialisationExpressionIndex = initialisationExpressionIndex;
		}
	}
}
