using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting.Assembly.Nodes.Psl
{
	class PslFunctionUsageNode : NodeBase
	{
		private Function m_function;

		public Function Function
		{
			get { return m_function; }
		}

		public List<NodeBase> Arguments
		{
			get { return m_children; }
		}

		public PslFunctionUsageNode(Function function, List<NodeBase> arguments)
			: base(arguments)
		{
			m_function = function;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			PslFunctionUsageNode castNode = node as PslFunctionUsageNode;
			if (castNode == null || castNode.m_children.Count != m_children.Count)
				return NodeComparison.Incompatible;
			return castNode.m_function == m_function ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
