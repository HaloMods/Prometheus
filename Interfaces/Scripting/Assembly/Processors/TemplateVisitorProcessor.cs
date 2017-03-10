using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.Bsl;
using Interfaces.Scripting.Assembly.Nodes.Psl;
using Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;

namespace Interfaces.Scripting.Assembly.Processors
{
	class TemplateVisitorProcessor : VisitorProcessorBase
	{
		public TemplateVisitorProcessor(ScriptingAssembly assembly) : base(assembly)
		{
			
		}

		#region Main Nodes

		public override void ProcessNode(NamespaceNode node)
		{

		}

		public override void ProcessNode(ScriptNode node)
		{

		}

		public override void ProcessNode(VariableNode node)
		{

		}

		public override void ProcessNode(GroupingNode node)
		{

		}

		public override void ProcessNode(ScriptCallNode node)
		{

		}

		#endregion

		#region Bsl Nodes

		public override void ProcessNode(BslFunctionCallNode node)
		{

		}

		public override void ProcessNode(BslGameGlobalReferenceNode node)
		{
			
		}

		#endregion

		#region Psl Nodes

		public override void ProcessNode(PslArrayElementReferenceNode node)
		{

		}

		public override void ProcessNode(PslArrayNode node)
		{

		}

		public override void ProcessNode(PslFunctionUsageNode node)
		{

		}

		public override void ProcessNode(PslGameGlobalReferenceNode node)
		{
			
		}

		public override void ProcessNode(PslOperatorUsageNode node)
		{

		}

		#region Construct Nodes

		public override void ProcessNode(ConditionalConstructNode node)
		{

		}

		public override void ProcessNode(RandomizeConstructNode node)
		{

		}

		#endregion

		#endregion

		#region Value Nodes

		public override void ProcessNode(BoolValueNode node)
		{

		}

		public override void ProcessNode(RealValueNode node)
		{

		}

		public override void ProcessNode(ShortValueNode node)
		{

		}

		public override void ProcessNode(LongValueNode node)
		{

		}

		public override void ProcessNode(StringValueNode node)
		{

		}

		public override void ProcessNode(ScriptReferenceValueNode node)
		{

		}

		public override void ProcessNode(VariableReferenceValueNode node)
		{

		}

		public override void ProcessNode(EnumerationValueNode node)
		{

		}

		public override void ProcessNode(TagReferenceValueNode node)
		{

		}

		public override void ProcessNode(BlockReferenceValueNode node)
		{

		}

		#endregion
	}
}
