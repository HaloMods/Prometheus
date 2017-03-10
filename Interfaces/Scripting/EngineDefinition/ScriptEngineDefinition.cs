using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.EngineDefinition;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.EngineDefinition
{
  public class ScriptEngineDefinition
  {
    [XmlAttribute()]
    public string Game;
    [XmlAttribute()]
    public string Platform;

		private ExtendedTypeBase[] m_extendedTypes;
  	private InternalFunction[] m_specificFunctions;
    private Namespace[] m_namespaces;

		[XmlArrayItem(typeof(BlockReferenceType)), XmlArrayItem(typeof(EnumerationType)),
		XmlArrayItem(typeof(TagReferenceType))]
    public ExtendedTypeBase[] ExtendedTypes
    {
      get { return m_extendedTypes; }
      set { m_extendedTypes = value; }
    }

  	public InternalFunction[] SpecificFunctions
  	{
  		get { return m_specificFunctions; }
  		set { m_specificFunctions = value; }
  	}

  	public Namespace[] Namespaces
    {
      get { return m_namespaces; }
      set { m_namespaces = value; }
    }

		public string GetTypeName(short typeIndex)
		{
			if (typeIndex < (short)IntegralValueType.IntegralValueTypeCount)
			{
				return Enum.GetName(typeof(IntegralValueType), typeIndex).ToLower();
			}
			else
			{
				return m_extendedTypes[typeIndex - (short)IntegralValueType.IntegralValueTypeCount].Name.ToLower();
			}
		}

		#region Namespace Lookup

		private Dictionary<string, Namespace> m_namespaceLookup = null;

		[XmlIgnore()]
    public Dictionary<string, Namespace> NamespaceLookup
    {
      get { return m_namespaceLookup; }
    }

    public void CreateNamespaceLookup()
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

		public void DestroyNamespaceLookup()
		{
			m_namespaceLookup.Clear();
			m_namespaceLookup = null;

			foreach (Namespace ns in m_namespaces)
				ns.DestroyLookup();
		}

		#endregion
	}
}
