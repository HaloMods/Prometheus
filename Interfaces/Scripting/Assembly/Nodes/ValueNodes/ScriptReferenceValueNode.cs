using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	class ScriptReferenceValueNode : ValueNodeBase
	{
		private ScriptNode m_script;

		public ScriptNode Script
		{
			get { return m_script; }
		}

		public ScriptReferenceValueNode(ScriptNode script)
		{
			m_script = script;
		}

		public override NodeComparison ShallowCompare(NodeBase node)
		{
			ScriptReferenceValueNode castNode = node as ScriptReferenceValueNode;
			if (castNode == null)
				return NodeComparison.Incompatible;
			return castNode.m_script == m_script ? NodeComparison.Equal : NodeComparison.Unequal;
		}

		public override short TypeIndex
		{
			get { return (short)IntegralValueType.Script; }
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
