
namespace Interfaces.Scripting.EngineDefinition.Types
{
	public enum BlockSourceTag
	{
		Scenario,
		HudGlobals
	}

	public class BlockReferenceType : ExtendedTypeBase
	{
		private string m_friendlyPluralName;
		private BlockSourceTag m_blockSource;
		private short m_instantiationTypeIndex;

		public string FriendlyPluralName
		{
			get { return m_friendlyPluralName; }
			set { m_friendlyPluralName = value; }
		}

		public BlockSourceTag BlockSource
		{
			get { return m_blockSource; }
			set { m_blockSource = value; }
		}

		public short InstantiationTypeIndex
		{
			get { return m_instantiationTypeIndex; }
			set { m_instantiationTypeIndex = value; }
		}

		public BlockReferenceType(string name, string friendlyPluralName, short typeIndex, short instantiationTypeIndex, BlockSourceTag blockSource) : base(name, typeIndex, new short[0], null)
		{
			m_friendlyPluralName = friendlyPluralName;
			m_blockSource = blockSource;
			m_instantiationTypeIndex = instantiationTypeIndex;
		}

		public BlockReferenceType() { }
	}
}
