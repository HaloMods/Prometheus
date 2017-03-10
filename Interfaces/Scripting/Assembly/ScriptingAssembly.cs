using System;
using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting.Assembly
{
	class NeedMoreResearchException : Exception
	{
		public NeedMoreResearchException(string message) : base("Need more research: " + message) { }
	}

	class OnlyForDebuggingException : Exception
	{
		public OnlyForDebuggingException(string message) : base("Debug: " + message) { }
	}

	class ScriptingAssembly
	{
		private ScriptEngineDefinition m_engineDefinition;
		private List<NamespaceNode> m_namespaces;

		public ScriptEngineDefinition EngineDefinition
		{
			get { return m_engineDefinition; }
		}

		public List<NamespaceNode> Namespaces
		{
			get { return m_namespaces; }
		}

		public ScriptingAssembly(ScriptEngineDefinition engineDefinition, List<NodeBase> globals, List<NodeBase> scripts)
		{
			m_engineDefinition = engineDefinition;
			m_namespaces = new List<NamespaceNode>();
			m_namespaces.Add(new NamespaceNode(globals, scripts));
		}

		public ScriptingAssembly(ScriptEngineDefinition engineDefinition)
			: this(engineDefinition, new List<NodeBase>(), new List<NodeBase>())
		{ }
	}
}
