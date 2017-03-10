using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class StringValueNode : ValueNodeBase
	{
		private string m_value;

		public string Value
		{
			get { return m_value; }
		}

		public StringValueNode(string value)
		{
			m_value = value;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			StringValueNode castNode = node as StringValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_value == m_value ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.String; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
