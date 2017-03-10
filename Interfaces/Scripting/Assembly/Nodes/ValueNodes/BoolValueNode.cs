using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class BoolValueNode : ValueNodeBase
	{
		private bool m_value;

		public bool Value
		{
			get { return m_value; }
		}

		public BoolValueNode(bool value)
		{
			m_value = value;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			BoolValueNode castNode = node as BoolValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_value == m_value ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.Bool; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
