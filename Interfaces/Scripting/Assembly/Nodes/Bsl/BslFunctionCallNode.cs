using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Bsl
{
	class BslFunctionCallNode : NodeBase
	{
		private short m_operationCode;

		public short OperationCode
		{
			get { return m_operationCode; }
		}

		public BslFunctionCallNode(short operationCode, List<NodeBase> parameters) : base(parameters)
		{
			m_operationCode = operationCode;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			BslFunctionCallNode castNode = node as BslFunctionCallNode;
			if (castNode == null || castNode.m_children.Count != m_children.Count)
				return NodeComparison.Incompatible;
			return castNode.m_operationCode == m_operationCode ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
