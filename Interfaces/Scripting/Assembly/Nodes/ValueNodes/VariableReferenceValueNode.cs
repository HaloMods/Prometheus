using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class VariableReferenceValueNode : ValueNodeBase
	{
		private VariableNode m_variable;
		private short m_typeInUsage;

		public VariableNode Variable
		{
			get { return m_variable; }
		}

		public short TypeInUsage
		{
			get { return m_typeInUsage; }
		}

		public VariableReferenceValueNode(VariableNode variable, short typeInUsage)
		{
			m_variable = variable;
			m_variable.References.Add(this);
			m_typeInUsage = typeInUsage;
		}

		/*public VariableReferenceValueNode(VariableClass @class, VariableNode variable)
			: this(@class, variable, variable.Type)
		{ }*/

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			VariableReferenceValueNode castNode = node as VariableReferenceValueNode;
			if (castNode == null || castNode.m_typeInUsage != m_typeInUsage)
				return NodeComparison.Incompatible;
			return castNode.m_variable == m_variable ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return m_typeInUsage; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
