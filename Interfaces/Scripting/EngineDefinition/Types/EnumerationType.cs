
namespace Interfaces.Scripting.EngineDefinition.Types
{
	public class EnumerationType : ExtendedTypeBase
	{
		private string[] m_values;

    public string[] Values
    {
      get { return m_values; }
      set { m_values = value; }
    }

		public EnumerationType(string name, short typeIndex, string[] values) : base(name, typeIndex, new short[0], null)
		{
			m_values = values;
		}

		public EnumerationType() { }
	}
}
