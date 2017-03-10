using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Psl
{
	class PslArrayElementReferenceNode : NodeBase
	{
		private VariableNode m_arrayVariable;
		private int m_index;

		public VariableNode ArrayVariable
		{
			get { return m_arrayVariable; }
		}

		public int Index
		{
			get { return m_index; }
		}

		public PslArrayNode ArrayNode
		{
			get { return m_arrayVariable.InitialisationExpression as PslArrayNode; }
		}

		public NodeBase Element
		{
			get { return ArrayNode.Elements[m_index]; }
		}

		public PslArrayElementReferenceNode(VariableNode arrayVariable, int index)
			: base(null)
		{
			m_arrayVariable = arrayVariable;
			m_index = index;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
