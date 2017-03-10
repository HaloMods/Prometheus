using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class LongValueNode : ValueNodeBase
	{
		private int m_value;

		public int Value
		{
			get { return m_value; }
		}

		public LongValueNode(int value)
		{
			m_value = value;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			LongValueNode castNode = node as LongValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_value == m_value ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.Long; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
