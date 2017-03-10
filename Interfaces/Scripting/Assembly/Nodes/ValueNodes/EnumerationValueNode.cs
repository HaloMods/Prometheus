using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class EnumerationValueNode : ValueNodeBase
	{
		private EnumerationType m_type;
		private short m_index;

		public EnumerationType Type
		{
			get { return m_type; }
		}

		public short Index
		{
			get { return m_index; }
		}

		public string Value
		{
			get { return m_type.Values[m_index]; }
		}

		public EnumerationValueNode(EnumerationType type, short index)
		{
			m_type = type;
			m_index = index;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			EnumerationValueNode castNode = node as EnumerationValueNode;
			if (castNode == null || castNode.m_type != m_type)
				return NodeComparison.Incompatible;
			return castNode.m_index == m_index ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return m_type.TypeIndex; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
