using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	class ScriptCallNode : NodeBase
	{
		private ScriptNode m_script;

		public List<NodeBase> Arguments
		{
			get { return m_children; }
		}

		public ScriptNode Script
		{
			get { return m_script; }
		}

		public ScriptCallNode(ScriptNode script, List<NodeBase> arguments) : base(arguments)
		{
			m_script = script;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			ScriptCallNode castNode = node as ScriptCallNode;
			if (castNode == null || castNode.m_children.Count != m_children.Count)
				return NodeComparison.Incompatible;
			return castNode.m_script == m_script ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
