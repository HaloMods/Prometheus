using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class TagReferenceValueNode : ValueNodeBase
	{
		private TagReferenceType m_type;
		private string m_tagPath;

		public TagReferenceType Type
		{
			get { return m_type; }
		}

		public string TagPath
		{
			get { return m_tagPath; }
		}

		public TagReferenceValueNode(TagReferenceType type, string tagPath)
		{
			m_type = type;
			m_tagPath = tagPath;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			TagReferenceValueNode castNode = node as TagReferenceValueNode;
			if (castNode == null || castNode.m_type != m_type)
				return NodeComparison.Incompatible;
			return castNode.m_tagPath == m_tagPath ? NodeComparison.Equal : NodeComparison.Unequal;
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
