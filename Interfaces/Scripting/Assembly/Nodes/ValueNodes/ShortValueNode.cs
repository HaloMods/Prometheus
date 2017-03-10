using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class ShortValueNode : ValueNodeBase
	{
		private short m_value;

		public short Value
		{
			get { return m_value; }
		}

		public ShortValueNode(short value)
		{
			m_value = value;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			ShortValueNode castNode = node as ShortValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_value == m_value ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.Short; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
