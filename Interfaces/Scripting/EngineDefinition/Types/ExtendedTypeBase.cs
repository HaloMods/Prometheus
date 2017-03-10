using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition.Types
{
	public enum IntegralValueType : short
	{
		Unparsed = 0,
		SpecialForm,
		FunctionName,
		Passthrough,
		Void,
		Bool,
		Real,
		Short,
		Long,
		String,
		Script,
		IntegralValueTypeCount
	}

	public abstract class ExtendedTypeBase
	{
		public const short FirstTypeIndex = 11;

		private string m_name;
		private short m_typeIndex;
		private short[] m_implicitCastables;
		private InternalFunction[] m_explicitCasters;

		[XmlAttribute()]
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		public short TypeIndex
		{
			get { return m_typeIndex; }
			set { m_typeIndex = value; }
		}

		/// <summary>
		/// Array of type indices that this type can be implicitly cast to.
		/// </summary>
		public short[] ImplicitCastables
		{
			get { return m_implicitCastables; }
			set { m_implicitCastables = value; }
		}

		public InternalFunction[] ExplicitCasters
		{
			get { return m_explicitCasters; }
			set { m_explicitCasters = value; }
		}

		protected ExtendedTypeBase(string name, short typeIndex, short[] implicitCastables, InternalFunction[] explicitCasters)
		{
			m_name = name;
			m_typeIndex = typeIndex;
			m_implicitCastables = implicitCastables;
			m_explicitCasters = explicitCasters ?? new InternalFunction[0];
		}

		protected ExtendedTypeBase() { }
	}
}
