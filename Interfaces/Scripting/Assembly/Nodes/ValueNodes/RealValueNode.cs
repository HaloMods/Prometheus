using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class RealValueNode : ValueNodeBase
	{
		private float m_value;

		public float Value
		{
			get { return m_value; }
		}

		public RealValueNode(float value)
		{
			m_value = value;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			RealValueNode castNode = node as RealValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_value == m_value ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.Real; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
