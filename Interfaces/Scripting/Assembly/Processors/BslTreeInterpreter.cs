using System.Collections.Generic;
using Interfaces.Factory;
using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.Bsl;
using Interfaces.Scripting.Assembly.Nodes.Psl;
using Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.EngineDefinition;
using Interfaces.Scripting.EngineDefinition.Lookup;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Processors
{
	class BslTreeInterpreter : VisitorProcessorBase
	{
		#region Utility

		/*class ListInsertionQueue<T>
		{
			class InsertionRequest
			{
				public int Index;
				public T Item;

				public InsertionRequest(int index, T item)
				{
					Index = index;
					Item = item;
				}
			}

			private List<InsertionRequest> m_inserts = new List<InsertionRequest>();

			public void QueueInsertion(int index, T item)
			{
				m_inserts.Add(new InsertionRequest(index, item));
			}

			public void PerformInsertions(List<T> list)
			{
				m_inserts.Sort(delegate (InsertionRequest x, InsertionRequest y) { return x.Index.CompareTo(y.Index); });

				int count = m_inserts.Count;
				for (int i = 0; i < count; i++)
				{
					InsertionRequest ir = m_inserts[i];
					list.Insert(ir.Index + i, ir.Item);
				}
			}
		}*/

		class GroupingInsertionQueue
		{
			class InsertionRequest
			{
				public int Index;
				public NodeBase Item;

				public InsertionRequest(int index, NodeBase item)
				{
					Index = index;
					Item = item;
				}
			}

			private List<InsertionRequest> m_inserts = new List<InsertionRequest>();

			public void QueueInsertion(int index, NodeBase item)
			{
				m_inserts.Add(new InsertionRequest(index, item));
			}

			public void PerformInsertions(GroupingNode grouping)
			{
				m_inserts.Sort(delegate(InsertionRequest x, InsertionRequest y) { return x.Index.CompareTo(y.Index); });

				int count = m_inserts.Count;
				for (int i = 0; i < count; i++)
				{
					InsertionRequest ir = m_inserts[i];
					grouping.Insert(ir.Index + i, ir.Item);
				}
			}
		}

		private string FormatName(string name)
		{
			return ScriptingStringOps.ToPslFormatting(name, m_mapName);
		}

		#endregion

		struct BslTDState
		{
			public int CurrentScriptIndex;
		}

		private string m_mapName;
		private DecompilerLookup m_decompilerLookup;
		private GroupingInsertionQueue m_scriptInsertionQueue;
		private BslTDState m_state;

		public BslTreeInterpreter(ScriptingAssembly assembly, string mapName, DecompilerLookup decompilerLookup) : base(assembly)
		{
			m_mapName = mapName;
			m_decompilerLookup = decompilerLookup;
		}

		public override void Perform()
		{
			NamespaceNode rootNamespace = m_assembly.Namespaces[0];
			m_assembly.Namespaces[0] = new NamespaceNode("Campaign." + m_mapName.ToUpper(), rootNamespace.GlobalsNode, rootNamespace.ScriptsNode);
			base.Perform();
		}

		#region Main Nodes

		public override void ProcessNode(NamespaceNode node)
		{
			m_scriptInsertionQueue = new GroupingInsertionQueue();
			m_state.CurrentScriptIndex = -1;

			foreach (VariableNode v in node.GlobalsNode.Children)
				v.VisitThis(this);

			foreach (ScriptNode s in node.ScriptsNode.Children)
			{
				m_state.CurrentScriptIndex++;
				s.VisitThis(this);
			}

			m_scriptInsertionQueue.PerformInsertions(node.ScriptsNode);
		}

		public override void ProcessNode(ScriptNode node)
		{
			node.Rename(FormatName(node.Name));
			foreach (NodeBase child in node.Children)
				child.VisitThis(this);
		}

		public override void ProcessNode(VariableNode node)
		{
			node.Rename(FormatName(node.Name));
			node.InitialisationExpression.VisitThis(this);
		}

		public override void ProcessNode(GroupingNode node)
		{
			foreach (NodeBase child in node.Children)
				child.VisitThis(this);
		}

		public override void ProcessNode(ScriptCallNode node)
		{
			foreach (NodeBase child in node.Children)
				child.VisitThis(this);
		}

		#endregion

		#region Bsl Nodes

		public override void ProcessNode(BslFunctionCallNode node)
		{
			ExpressionReference expressionReference = m_decompilerLookup.FunctionOpCodeLookup[node.OperationCode];

			FunctionReference functionReference;
			OperatorReference operatorReference;
			GlobalReference globalReference;

			if ((functionReference = expressionReference as FunctionReference) != null)
			{
				if (functionReference.Function.IsOverloadedByBooleanArgument)
					node.Children.Add(new BoolValueNode(functionReference.Overload == 1));
				node.Replace(new PslFunctionUsageNode(functionReference.Function, node.Children));

				foreach (NodeBase child in node.Children)
					child.VisitThis(this);
			}
			else if ((operatorReference = expressionReference as OperatorReference) != null)
			{
				switch (operatorReference.Operation.Specification)
				{
					case FunctionSpecification.Begin:
						node.Replace(new GroupingNode(node.Children));
						foreach (NodeBase child in node.Children)
							child.VisitThis(this);
						break;
					case FunctionSpecification.BeginRandom:
						ValueDiscrepancy vd = SingleValueDiscrepancySearch.Perform(node.Children);

						if (vd != null)
						{
							short typeIndex = vd.TypeIndex;
							string pluralTypeName = m_engineDefinition.GetTypeName(typeIndex);
							List<NodeBase> randomizerExpressions = node.Children[0].Children;
							VariableNode iteratorParameter = new VariableNode(pluralTypeName + "s", typeIndex, true, true, null);
							vd.Nodes[0].Replace(new VariableReferenceValueNode(iteratorParameter, typeIndex));
							List<NodeBase> parameters = new List<NodeBase>();
							parameters.Add(iteratorParameter);
							ScriptNode randomFunction = new ScriptNode("Randomize" + StringOps.CapitalizeWords(pluralTypeName), ScriptType.Random, (short)IntegralValueType.Void, randomizerExpressions);
							m_scriptInsertionQueue.QueueInsertion(m_state.CurrentScriptIndex, randomFunction);
							
							List<NodeBase> randomFunctionArguments = new List<NodeBase>();
							randomFunctionArguments.Add(new PslArrayNode(typeIndex, vd.Nodes));

							node.Replace(new ScriptCallNode(randomFunction, randomFunctionArguments));

							foreach (NodeBase child in node.Children)
								child.VisitThis(this);
						}
						break;
					case FunctionSpecification.If:
						// Early recursion to identify GroupingNodes and sub Ifs before constructing conditional node
						foreach (NodeBase child in node.Children)
							child.VisitThis(this);

						ConditionalConstructNode conditionalConstruct = null;

						NodeBase condition = node.Children[0];
						GroupingNode expressions = GroupingNode.MakeGrouping(node.Children[1]);

						GroupingNode elseExpressions = null;
						if (node.Children.Count > 2)
						{
							elseExpressions = GroupingNode.MakeGrouping(node.Children[2]);

							ConditionalConstructNode embeddedIf;
							if (elseExpressions.Children.Count == 1 && (embeddedIf = elseExpressions.Children[0] as ConditionalConstructNode) != null)
							{
								BoolValueNode potentialAlwaysTrueStatement = embeddedIf.Conditions[0] as BoolValueNode;
								if (potentialAlwaysTrueStatement != null && potentialAlwaysTrueStatement.Value)
									elseExpressions = embeddedIf.ExpressionSets[0] as GroupingNode;
								else
								{
									conditionalConstruct = embeddedIf;
									conditionalConstruct.InsertConditional(condition, expressions);
								}
							}
						}
						
						if (conditionalConstruct == null)
						{
							List<NodeBase> conditions = new List<NodeBase>();
							conditions.Add(condition);
							List<NodeBase> expressionSets = new List<NodeBase>();
							expressionSets.Add(expressions);
							conditionalConstruct = new ConditionalConstructNode(conditions, expressionSets, elseExpressions);
						}

						node.Replace(conditionalConstruct);
						break;
					case FunctionSpecification.Cond:
						throw new NeedMoreResearchException("How does cond look in compiled form - how are its children mapped out?");
						//node.Replace(new ConditionalConstructNode());
						//break;
					default:
						List<NodeBase> children = node.Children;
						node.Replace(new PslOperatorUsageNode(operatorReference.Operation, children));
						foreach (NodeBase child in children)
							child.VisitThis(this);
						break;
				}
			}
			else if ((globalReference = expressionReference as GlobalReference) != null)
			{
				switch (globalReference.Method)
				{
					case GlobalReference.AccessMethod.Get:
						node.Replace(new PslGameGlobalReferenceNode(globalReference.Global));
						break;
					case GlobalReference.AccessMethod.Set:
						List<NodeBase> operands = new List<NodeBase>();
						operands.Add(new PslGameGlobalReferenceNode(globalReference.Global));
						operands.Add(node.Children[0]);
						node.Replace(new PslOperatorUsageNode(m_engineDefinition.SpecificFunctions[(int)FunctionSpecification.Set], operands));

						operands[1].VisitThis(this);
						break;
				}
			}
			else if (expressionReference is CasterReference)
			{
				node.Replace(node.Children[0]);
				node.Children[0].VisitThis(this);
			}
		}

		public override void ProcessNode(BslGameGlobalReferenceNode node)
		{
			node.Replace(new PslGameGlobalReferenceNode(m_decompilerLookup.GlobalOpCodeLookup[node.Index]));
		}

		#endregion

		#region Psl Nodes [unused]

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

		#region Value Nodes [unmodified]

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
