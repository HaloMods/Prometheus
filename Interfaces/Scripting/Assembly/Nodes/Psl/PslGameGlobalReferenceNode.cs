using Interfaces.Scripting.Assembly.Processors;
using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting.Assembly.Nodes.Psl
{
	class PslGameGlobalReferenceNode : NodeBase
	{
		private Global m_global;

		public Global Global
		{
			get { return m_global; }
		}

		public PslGameGlobalReferenceNode(Global global) : base(null)
		{
			m_global = global;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
