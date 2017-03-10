using System.Collections.Generic;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.EngineDefinition.Lookup
{
	public class DecompilerLookup
	{
		private Dictionary<short, ExpressionReference> m_functionOpCodeLookup;
		private Dictionary<short, Global> m_globalOpCodeLookup;

		public Dictionary<short, ExpressionReference> FunctionOpCodeLookup
		{
			get { return m_functionOpCodeLookup; }
		}

		public Dictionary<short, Global> GlobalOpCodeLookup
		{
			get { return m_globalOpCodeLookup; }
		}

		public DecompilerLookup(ScriptEngineDefinition definition)
		{
			m_functionOpCodeLookup = new Dictionary<short, ExpressionReference>();
			m_globalOpCodeLookup = new Dictionary<short, Global>();

			// Type casters
			foreach (ExtendedTypeBase t in definition.ExtendedTypes)
				foreach (InternalFunction f in t.ExplicitCasters)
					m_functionOpCodeLookup.Add(f.OperationCode, new CasterReference(/*f*/));

			// Special usage functions
			for (int i = 0; i < (int)FunctionSpecification.SupiFunctionCount; i++)
			{
				InternalFunction sf = definition.SpecificFunctions[i];
				m_functionOpCodeLookup.Add(sf.OperationCode, new OperatorReference(sf));
			}

			// Recurse through namespaces
			foreach (Namespace ns in definition.Namespaces)
				CreateLookup(ns, null);
		}

		private void CreateLookup(Namespace ns, string parentFullName)
		{
			ns.GenerateFullName(parentFullName);

			foreach (Global g in ns.Globals)
			{
				if (!g.IsProperty)
					m_globalOpCodeLookup.Add(g.InternalGlobal.OperationCode, g);
				else
				{
					if (g.GetAccessor != null)
						m_functionOpCodeLookup.Add(g.GetAccessor.OperationCode, new GlobalReference(g, GlobalReference.AccessMethod.Get));
					if (g.SetAccessor != null)
						m_functionOpCodeLookup.Add(g.SetAccessor.OperationCode, new GlobalReference(g, GlobalReference.AccessMethod.Set));
				}
				g.GenerateFullName(ns.FullName);
			}

			foreach (Function f in ns.Functions)
			{
				int overloadCount = f.Overloads.Length;
				for (byte i = 0; i < overloadCount; i++)
					m_functionOpCodeLookup.Add(f.Overloads[i].OperationCode, new FunctionReference(f, i));
				f.GenerateFullName(ns.FullName);
			}

			foreach (Namespace sns in ns.Namespaces)
				CreateLookup(sns, ns.FullName);
		}
	}
}
