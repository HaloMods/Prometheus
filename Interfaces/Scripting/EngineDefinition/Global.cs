using System;
using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
	public class Global
	{
		private string m_name;
		private short m_type;
		private string m_description;
		private InternalGlobal m_internalGlobal;
		private InternalFunction m_getAccessor;
		private InternalFunction m_setAccessor;

		[XmlAttribute()]
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}

		[XmlAttribute()]
		public short Type
		{
			get { return m_type; }
			set { m_type = value; }
		}

		public string Description
		{
			get { return m_description; }
			set { m_description = value; }
		}

		[XmlIgnore()]
		public bool ReadOnly
		{
			get { return m_getAccessor != null && m_setAccessor == null; }
		}

		[XmlIgnore()]
		public bool IsProperty
		{
			get { return m_internalGlobal == null; }
		}

		public InternalGlobal InternalGlobal
		{
			get { return m_internalGlobal; }
			set { m_internalGlobal = value; }
		}

		public InternalFunction GetAccessor
		{
			get { return m_getAccessor; }
			set { m_getAccessor = value; }
		}

		public InternalFunction SetAccessor
		{
			get { return m_setAccessor; }
			set { m_setAccessor = value; }
		}

		public Global(string name, short type, string description, InternalGlobal internalGlobal, InternalFunction getAccessor, InternalFunction setAccessor)
		{
			m_name = name;
			m_type = type;
			m_description = description;
			m_internalGlobal = internalGlobal;
			m_getAccessor = getAccessor;
			m_setAccessor = setAccessor;
		}

		public Global(string name, InternalGlobal internalGlobal)
		{
			m_name = name;
			m_type = internalGlobal.Type;
			m_description = String.Empty;
			m_internalGlobal = internalGlobal;
			m_getAccessor = null;
			m_setAccessor = null;
		}

		public Global(string name, short type, string description)
		{
			m_name = name;
			m_type = type;
			m_description = description;
			m_internalGlobal = null;
			m_getAccessor = null;
			m_setAccessor = null;
		}

		public Global() { }

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
