using System.Collections.Generic;
using System.Xml.Serialization;

namespace Interfaces.Scripting.EngineDefinition
{
  public class Namespace
  {
    private string m_name;
    private Namespace[] m_namespaces;
    private Function[] m_functions;
    private Global[] m_globals;

    [XmlAttribute()]
    public string Name
    {
      get { return m_name; }
      set { m_name = value; }
    }

    public Namespace[] Namespaces
    {
      get { return m_namespaces; }
      set { m_namespaces = value; }
    }

    public Function[] Functions
    {
      get { return m_functions; }
      set { m_functions = value; }
    }

    public Global[] Globals
    {
      get { return m_globals; }
      set { m_globals = value; }
    }

    public Namespace(string name, Namespace[] namespaces, Function[] functions, Global[] globals)
    {
      m_name = name;
      m_namespaces = namespaces;
      m_functions = functions;
      m_globals = globals;
    }
    
    public Namespace() { }

		#region Namespace Lookup

		private Dictionary<string, Namespace> m_namespaceLookup = null;

    [XmlIgnore()]
    public Dictionary<string, Namespace> NamespaceLookup
    {
      get { return m_namespaceLookup; }
    }
    
    public void CreateLookup()
    {
      if (m_namespaceLookup != null)
        return;

      m_namespaceLookup = new Dictionary<string, Namespace>();
      foreach (Namespace ns in m_namespaces)
      {
        ns.CreateLookup();
        m_namespaceLookup.Add(ns.Name, ns);
      }
		}

		public void DestroyLookup()
		{
			m_namespaceLookup.Clear();
			m_namespaceLookup = null;

			foreach (Namespace ns in m_namespaces)
				ns.DestroyLookup();

			/*foreach (Function f in m_functions)
				f.DestroyDecompilerLookup();

			foreach (Global g in m_globals)
				g.DestroyDecompilerLookup();*/
		}

		#endregion

		#region Qualified Name Handling

		private string m_fullName;

		public string FullName
		{
			get { return m_fullName; }
		}

		public void GenerateFullName(string parentFullName)
		{
			if (parentFullName == null)
				m_fullName = m_name;
			else
				m_fullName = parentFullName + "." + m_name;
		}

		#endregion
	}
}
