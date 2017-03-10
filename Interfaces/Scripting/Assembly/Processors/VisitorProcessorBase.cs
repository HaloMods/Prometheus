using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.Bsl;
using Interfaces.Scripting.Assembly.Nodes.Psl;
using Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.EngineDefinition;

namespace Interfaces.Scripting.Assembly.Processors
{
	interface IVisitable
	{
		void VisitThis(VisitorProcessorBase visitor);
	}

	abstract class VisitorProcessorBase
	{
		protected ScriptingAssembly m_assembly;
		protected ScriptEngineDefinition m_engineDefinition;

		protected VisitorProcessorBase(ScriptingAssembly assembly)
		{
			m_assembly = assembly;
			m_engineDefinition = assembly.EngineDefinition;
		}

		public virtual void Perform()
		{
			foreach (NamespaceNode n in m_assembly.Namespaces)
				n.VisitThis(this);
		}

		#region Main Nodes

		public abstract void ProcessNode(NamespaceNode node);
		public abstract void ProcessNode(ScriptNode node);
		public abstract void ProcessNode(VariableNode node);
		public abstract void ProcessNode(GroupingNode node);
		public abstract void ProcessNode(ScriptCallNode node);

		#endregion

		#region Bsl Nodes

		public abstract void ProcessNode(BslFunctionCallNode node);
		public abstract void ProcessNode(BslGameGlobalReferenceNode node);

		#endregion

		#region Psl Nodes

		public abstract void ProcessNode(PslArrayElementReferenceNode node);
		public abstract void ProcessNode(PslArrayNode node);
		public abstract void ProcessNode(PslFunctionUsageNode node);
		public abstract void ProcessNode(PslGameGlobalReferenceNode node);
		public abstract void ProcessNode(PslOperatorUsageNode node);

		#region Construct Nodes

		public abstract void ProcessNode(ConditionalConstructNode node);
		public abstract void ProcessNode(RandomizeConstructNode node);

		#endregion

		#endregion

		#region Value Nodes

		public abstract void ProcessNode(BoolValueNode node);
		public abstract void ProcessNode(RealValueNode node);
		public abstract void ProcessNode(ShortValueNode node);
		public abstract void ProcessNode(LongValueNode node);
		public abstract void ProcessNode(StringValueNode node);
		public abstract void ProcessNode(ScriptReferenceValueNode node);
		public abstract void ProcessNode(VariableReferenceValueNode node);
		public abstract void ProcessNode(EnumerationValueNode node);
		public abstract void ProcessNode(TagReferenceValueNode node);
		public abstract void ProcessNode(BlockReferenceValueNode node);

		#endregion
	}
}
