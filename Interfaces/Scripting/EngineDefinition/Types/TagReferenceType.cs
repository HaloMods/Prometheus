
namespace Interfaces.Scripting.EngineDefinition.Types
{
	public class TagReferenceType : ExtendedTypeBase
	{
		private string[] m_tagTypes;

    public string[] TagTypes
    {
      get { return m_tagTypes; }
      set { m_tagTypes = value; }
    }

		public TagReferenceType(string name, short typeIndex, string[] tagTypes) : base(name, typeIndex, new short[0], null)
		{
			m_tagTypes = tagTypes;
		}

		public TagReferenceType() { }
	}
}
