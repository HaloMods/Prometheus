using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting.Assembly.Nodes.Psl
{
	class PslOperatorUsageNode : NodeBase
	{
		private InternalFunction m_operator;

		public InternalFunction Operator
		{
			get { return m_operator; }
		}

		public List<NodeBase> Operands
		{
			get { return m_children; }
		}

		public PslOperatorUsageNode(InternalFunction @operator, List<NodeBase> operands) : base(operands)
		{
			m_operator = @operator;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
