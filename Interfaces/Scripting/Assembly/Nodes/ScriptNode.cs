using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	enum ScriptType
	{
		Startup,
		Dormant,
		Continuous,
		Static,
		Stub,
		Random
	}
	
	class ScriptNode : NodeBase
	{
		private NamespaceNode m_namespace;
		private string m_name;
		private ScriptType m_scriptType;
		private short m_returnType;

		public NamespaceNode Namespace
		{
			get { return m_namespace; }
		}

		public void AssignToNamespace(NamespaceNode @namespace)
		{
			m_namespace = @namespace;
		}

		public string Name
		{
			get { return m_name; }
		}

		public ScriptType ScriptType
		{
			get { return m_scriptType; }
		}

		public short ReturnType
		{
			get { return m_returnType; }
		}

		public GroupingNode ParameterNode
		{
			get { return m_children[0] as GroupingNode; }
		}

		public GroupingNode ExpressionNode
		{
			get { return m_children[1] as GroupingNode; }
		}

		public ScriptNode(string name, ScriptType scriptType, short returnType, List<NodeBase> parameters, List<NodeBase> expressions)
			: base (new List<NodeBase>(new NodeBase[] { parameters == null ? null : new GroupingNode(parameters), new GroupingNode(expressions ?? new List<NodeBase>()) }))
		{
			m_name = name;
			m_scriptType = scriptType;
			m_returnType = returnType;
		}

		public ScriptNode(string name, ScriptType scriptType, short returnType, List<NodeBase> expressions)
			: base (new List<NodeBase>(new NodeBase[] { null, new GroupingNode(expressions ?? new List<NodeBase>()) }))
		{
			m_name = name;
			m_scriptType = scriptType;
			m_returnType = returnType;
		}

		public void Rename(string name)
		{
			m_name = name;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			if (!(node is ScriptNode))
				return NodeComparison.Incompatible;
			return NodeComparison.Equal;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
