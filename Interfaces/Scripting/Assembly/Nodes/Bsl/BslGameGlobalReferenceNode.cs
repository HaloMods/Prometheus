using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Bsl
{
	class BslGameGlobalReferenceNode : NodeBase
	{
		private short m_index;
		private short m_typeInUsage;

		public short Index
		{
			get { return m_index; }
		}

		public short TypeInUsage
		{
			get { return m_typeInUsage; }
		}

		public BslGameGlobalReferenceNode(short index, short typeInUsage) : base(null)
		{
			m_index = index;
			m_typeInUsage = typeInUsage;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			BslGameGlobalReferenceNode castNode = node as BslGameGlobalReferenceNode;
			if (castNode == null || castNode.m_typeInUsage != m_typeInUsage)
				return NodeComparison.Incompatible;
			return castNode.m_index == m_index ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
