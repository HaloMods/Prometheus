
namespace Interfaces.Scripting.ScenarioInterface
{
	public class ScenarioScript
	{
		private string m_name;
		private short m_scriptType;
		private short m_returnType;
		private short m_rootExpressionIndex;

		public string Name
		{
			get { return m_name; }
		}

		public short ScriptType
		{
			get { return m_scriptType; }
		}

		public short ReturnType
		{
			get { return m_returnType; }
		}

		public short RootExpressionIndex
		{
			get { return m_rootExpressionIndex; }
		}

		public ScenarioScript(string name, short scriptType, short returnType, short rootExpressionIndex)
		{
			m_name = name;
			m_scriptType = scriptType;
			m_returnType = returnType;
			m_rootExpressionIndex = rootExpressionIndex;
		}
	}
}
