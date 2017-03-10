using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class BlockReferenceValueNode : ValueNodeBase
	{
		private BlockReferenceType m_type;
		private string m_blockIdentifier;

		public BlockReferenceType Type
		{
			get { return m_type; }
		}

		public string BlockIdentifier
		{
			get { return m_blockIdentifier; }
		}

		public BlockReferenceValueNode(BlockReferenceType type, string blockName)
		{
			m_type = type;
			m_blockIdentifier = blockName;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			BlockReferenceValueNode castNode = node as BlockReferenceValueNode;
			if (castNode == null || castNode.m_type != m_type)
				return NodeComparison.Incompatible;
			return castNode.m_blockIdentifier == m_blockIdentifier ? NodeComparison.Equal : NodeComparison.Unequal;
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
