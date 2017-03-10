using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
	public class Function
	{
		private string m_name;
		
		private Argument m_overloaderArgument;
		private string m_overloadedDescription;
		private InternalFunction[] m_overloads;
		private bool m_addPostWhitespace = false;

		[XmlAttribute()]
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		[XmlIgnore()]
		public short ReturnType
		{
			get { return m_overloads[0].ReturnType; }
		}

		[XmlIgnore()]
		public bool IsOverloadedByBooleanArgument
		{
			get { return m_overloaderArgument != null; }
		}

		public bool AddPostWhitespace
		{
			get { return m_addPostWhitespace; }
			set { m_addPostWhitespace = value; }
		}

		public Argument OverloaderArgument
		{
			get { return m_overloaderArgument; }
			set { m_overloaderArgument = value; }
		}

		public string OverloadedDescription
		{
			get { return m_overloadedDescription; }
			set { m_overloadedDescription = value; }
		}

		public InternalFunction[] Overloads
		{
			get { return m_overloads; }
			set { m_overloads = value; }
		}

		public Function(string name, Argument overloaderArgument, string overloadedDescription, InternalFunction[] overloads)
		{
			m_name = name;
			m_overloaderArgument = overloaderArgument;
			m_overloadedDescription = overloadedDescription;
			m_overloads = overloads;
		}

		public Function(string name, InternalFunction[] overloads)
		{
			m_name = name;
			m_overloaderArgument = null;
			m_overloadedDescription = null;
			m_overloads = overloads;
		}

		public Function(string name, InternalFunction internalFunction)
		{
			m_name = name;
			m_overloaderArgument = null;
			m_overloadedDescription = null;
			m_overloads = new InternalFunction[] { internalFunction };
		}

		public Function() { }

		#region Qualified Name Handling

		private string m_fullName;

		public string FullName
		{
			get { return m_fullName; }
		}

		public void GenerateFullName(string parentFullName)
		{
				m_fullName = parentFullName + "." + m_name;
		}

		#endregion
	}
}