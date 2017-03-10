using System.Collections.Generic;
using System.Text;
using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.Bsl;
using Interfaces.Scripting.Assembly.Nodes.Psl;
using Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.EngineDefinition;
using Interfaces.Scripting.EngineDefinition.Types;

namespace Interfaces.Scripting.Assembly.Processors
{
	class PslOutputGenerator : VisitorProcessorBase
	{
		struct PogState
		{
			public NamespaceNode Namespace;
			public int Indent;
		}

		enum PslContext
		{
			Inline,
			Root
		}

		struct PslInspectionTierState
		{
			public PslContext Context;
			public bool ReturnExpected;

			public PslInspectionTierState(PslContext context, bool returnExpected)
			{
				Context = context;
				ReturnExpected = returnExpected;
			}
		}

		// Helper objects
		private StringBuilder m_output;
		private PogState m_state;
		private Stack<PslInspectionTierState> m_tierStateStack;

		public string OutputToString()
		{
			return m_output.ToString();
		}

		public PslOutputGenerator(ScriptingAssembly assembly) : base(assembly)
		{
			m_state.Indent = 0;
			m_output = new StringBuilder();
			m_tierStateStack = new Stack<PslInspectionTierState>();
		}

		#region String output helpers

		private const string NEW_LINE = "\r\n";
		private const char TAB = '\t';
		private const char SPACE = ' ';
		private const char NAMESPACE_DELIMITER = '.';
		private const string PARAMETER_DELIMITER = ", ";
		private const char OPEN_BRACE = '{';
		private const char CLOSE_BRACE = '}';
		private const char OPEN_BRACKET = '(';
		private const char CLOSE_BRACKET = ')';
		private const char OPEN_STRING = '"';
		private const char CLOSE_STRING = '"';
		private const char STATEMENT_TERMINATOR = ';';
		private const string ARRAY_IDENTIFIER = "[]";
		private const char OPEN_ARRAY_INDEXER = '[';
		private const char CLOSE_ARRAY_INDEXER = ']';
		private const string CUSTOM_NAMESPACE_PREFIX = "My.";
		private const string SCENARIO_REFERENCE_PREFIX = "Map.";
		private const string HUD_GLOBALS_REFERENCE_PREFIX = "Hud.";

		private void NewLine()
		{
			NewLine(0, 0);
		}

		private void NewLine(int additionalIndent)
		{
			NewLine(additionalIndent, 0);
		}

		private void NewLine(int additionalIndent, int additionalLines)
		{
			for (int i = 0; i < additionalLines + 1; i++)
				m_output.Append(NEW_LINE);

			int indentCount = m_state.Indent + additionalIndent;
			for (int i = 0; i < indentCount; i++)
				m_output.Append(TAB);
		}

		private void BeginBlock()
		{
			NewLine();
			m_output.Append(OPEN_BRACE);
			m_state.Indent++;
			NewLine();
		}

		private void EndBlock()
		{
			m_state.Indent--;
			NewLine();
			m_output.Append(CLOSE_BRACE);
			NewLine();
		}

		private static string GetScriptTypeString(ScriptType scriptType)
		{
			return scriptType.ToString().ToLower();
		}

		private string GetTypeString(short typeIndex)
		{
			return m_assembly.EngineDefinition.GetTypeName(typeIndex);
		}

		#endregion

		#region Main Nodes

		public override void ProcessNode(NamespaceNode node)
		{
			m_state.Namespace = node;

			m_output.Append("namespace ");
			m_output.Append(node.Name);

			BeginBlock();

			foreach (VariableNode v in node.GlobalsNode.Children)
			{
				v.VisitThis(this);
				NewLine();
			}

			NewLine();

			foreach (ScriptNode s in node.ScriptsNode.Children)
			{
				NewLine(0, 1);
				s.VisitThis(this);
			}

			EndBlock();

			m_state.Namespace = null;
		}

		public override void ProcessNode(ScriptNode node)
		{
			m_output.Append(GetScriptTypeString(node.ScriptType));
			m_output.Append(SPACE);
			m_output.Append(GetTypeString(node.ReturnType));
			m_output.Append(SPACE);
			m_output.Append(node.Name);

			m_output.Append(OPEN_BRACKET);
			List<NodeBase> parameters = node.ParameterNode.Children;
			int lastParameterIndex = parameters.Count - 1;
			for (int i = 0; i <= lastParameterIndex; i++)
			{
				VariableNode parameter = parameters[i] as VariableNode;
				m_output.Append(GetTypeString(parameter.Type));
				m_output.Append(SPACE);
				m_output.Append(parameter.Name);
				if (i != lastParameterIndex)
					m_output.Append(PARAMETER_DELIMITER);
			}
			m_output.Append(CLOSE_BRACKET);
			
			BeginBlock();
			m_tierStateStack.Push(new PslInspectionTierState(PslContext.Root, false));

			bool returnExpected = node.ReturnType != (short)IntegralValueType.Void;
			List<NodeBase> expressions = node.ExpressionNode.Children;
			int lastExpressionIndex = expressions.Count - 1;

			for (int i = 0; i <= lastExpressionIndex; i++)
			{
				if (i != lastExpressionIndex)
				{
					expressions[i].VisitThis(this);
					NewLine();
				}
				else
				{
					if (!returnExpected)
						expressions[i].VisitThis(this);
					else
					{
						NewLine();
						m_output.Append("return ");
						m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));
						expressions[i].VisitThis(this);
						m_tierStateStack.Pop();
						m_output.Append(STATEMENT_TERMINATOR);
					}
				}
			}

			m_tierStateStack.Pop();
			EndBlock();
		}

		public override void ProcessNode(VariableNode node)
		{
			m_output.Append(GetTypeString(node.Type));
			m_output.Append(SPACE);
			m_output.Append(node.Name);
			
			if (node.InitialisationExpression != null)
			{
				m_output.Append(" = ");
				m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));
				node.InitialisationExpression.VisitThis(this);
				m_tierStateStack.Pop();
			}

			m_output.Append(STATEMENT_TERMINATOR);
		}

		public override void ProcessNode(GroupingNode node)
		{
			throw new OnlyForDebuggingException("Grouping nodes apparently do get visited.");
			//foreach (NodeBase child in node.Children)
			//	child.VisitThis(this);
		}

		public override void ProcessNode(ScriptCallNode node)
		{
			ScriptNode callee = node.Script;

			if (m_tierStateStack.Peek().ReturnExpected && callee.ReturnType == (short)IntegralValueType.Void)
				throw new OnlyForDebuggingException("Return value expected from a script returning void.");

			if (callee.Namespace != m_state.Namespace)
			{
				m_output.Append(CUSTOM_NAMESPACE_PREFIX);
				m_output.Append(callee.Namespace.Name);
				m_output.Append(NAMESPACE_DELIMITER);
			}
			m_output.Append(callee.Name);
			m_output.Append(OPEN_BRACKET);
			m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));

			List<NodeBase> arguments = node.Arguments;
			int lastArgumentIndex = arguments.Count - 1;
			for (int i = 0; i <= lastArgumentIndex; i++)
			{
				arguments[i].VisitThis(this);
				
				if (i != lastArgumentIndex)
					m_output.Append(PARAMETER_DELIMITER);
			}

			m_tierStateStack.Pop();
			m_output.Append(CLOSE_BRACKET);

			if (m_tierStateStack.Peek().Context != PslContext.Inline)
				m_output.Append(STATEMENT_TERMINATOR);
		}

		#endregion

		#region Bsl Nodes [unused]

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
			VariableNode callee = node.ArrayVariable;

			if (callee.Namespace != m_state.Namespace)
			{
				m_output.Append(CUSTOM_NAMESPACE_PREFIX);
				m_output.Append(callee.Namespace.Name);
				m_output.Append(NAMESPACE_DELIMITER);
			}
			m_output.Append(callee.Name);

			m_output.Append(OPEN_ARRAY_INDEXER);
			m_output.Append(node.Index);
			m_output.Append(CLOSE_ARRAY_INDEXER);
		}

		public override void ProcessNode(PslArrayNode node)
		{
			m_output.Append("new ");
			m_output.Append(GetTypeString(node.TypeIndex));
			m_output.Append(ARRAY_IDENTIFIER);
			m_output.Append(SPACE);
			m_output.Append(OPEN_BRACE);
			m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));

			List<NodeBase> elements = node.Elements;
			int lastArgumentIndex = elements.Count - 1;
			for (int i = 0; i <= lastArgumentIndex; i++)
			{
				elements[i].VisitThis(this);

				if (i != lastArgumentIndex)
					m_output.Append(PARAMETER_DELIMITER);
			}

			m_tierStateStack.Pop();
			m_output.Append(CLOSE_BRACE);
		}

		public override void ProcessNode(PslFunctionUsageNode node)
		{
			Function callee = node.Function;

			if (m_tierStateStack.Peek().ReturnExpected && callee.ReturnType == (short)IntegralValueType.Void)
				throw new OnlyForDebuggingException("Return value expected from a function returning void.");

			m_output.Append(callee.FullName);
			m_output.Append(OPEN_BRACKET);
			m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));

			List<NodeBase> arguments = node.Arguments;
			int lastArgumentIndex = arguments.Count - 1;
			for (int i = 0; i <= lastArgumentIndex; i++)
			{
				arguments[i].VisitThis(this);

				if (i != lastArgumentIndex)
					m_output.Append(PARAMETER_DELIMITER);
			}

			m_tierStateStack.Pop();
			m_output.Append(CLOSE_BRACKET);

			if (m_tierStateStack.Peek().Context != PslContext.Inline)
				m_output.Append(STATEMENT_TERMINATOR);
		}

		public override void ProcessNode(PslGameGlobalReferenceNode node)
		{
			m_output.Append(node.Global.FullName);
		}

		public override void ProcessNode(PslOperatorUsageNode node)
		{
			string operatorSymbol = null;
			
			m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, true));

			switch (node.Operator.Specification)
			{
				// Mathematical operators
				case FunctionSpecification.Add:
					operatorSymbol = "+";
					break;
				case FunctionSpecification.Subtract:
					operatorSymbol = "-";
					break;
				case FunctionSpecification.Multiply:
					operatorSymbol = "*";
					break;
				case FunctionSpecification.Divide:
					operatorSymbol = "/";
					break;
				// Comparison operators
				case FunctionSpecification.Equals:
					operatorSymbol = "==";
					break;
				case FunctionSpecification.NotEquals:
					operatorSymbol = "!=";
					break;
				case FunctionSpecification.GreaterThan:
					operatorSymbol = ">";
					break;
				case FunctionSpecification.LessThan:
					operatorSymbol = "<";
					break;
				case FunctionSpecification.GreaterThanOrEqualTo:
					operatorSymbol = ">=";
					break;
				case FunctionSpecification.LessThanOrEqualTo:
					operatorSymbol = "<=";
					break;
				// Logical operators
				case FunctionSpecification.And:
					operatorSymbol = "&&";
					break;
				case FunctionSpecification.Or:
					operatorSymbol = "||";
					break;
				case FunctionSpecification.Not:
					m_output.Append('!');
					node.Operands[0].VisitThis(this);
					break;
				// Special operations
				case FunctionSpecification.Set:
					operatorSymbol = "=";
					break;
				case FunctionSpecification.ListGet:
					node.Operands[0].VisitThis(this);
					m_output.Append(OPEN_ARRAY_INDEXER);
					node.Operands[1].VisitThis(this);
					m_output.Append(CLOSE_ARRAY_INDEXER);
					break;
				default:
					throw new OnlyForDebuggingException("Unexpected operator usage.");
			}

			if (operatorSymbol != null)
			{
				List<NodeBase> operands = node.Operands;
				int lastOperandIndex = operands.Count - 1;
				for (int i = 0; i <= lastOperandIndex; i++)
				{
					operands[i].VisitThis(this);

					if (i != lastOperandIndex)
					{
						m_output.Append(SPACE);
						m_output.Append(operatorSymbol);
						m_output.Append(SPACE);
					}
				}
			}

			m_tierStateStack.Pop();

			if (m_tierStateStack.Peek().Context != PslContext.Inline)
				m_output.Append(STATEMENT_TERMINATOR);
		}

		#region Construct Nodes

		enum ConditionalStage
		{
			If,
			ElseIf,
			Else
		}

		private void ProcessConditionalSection(ConditionalStage stage, NodeBase condition, GroupingNode expressionNode)
		{
			switch (stage)
			{
				case ConditionalStage.If:
					m_output.Append("if ");
					break;
				case ConditionalStage.ElseIf:
					m_output.Append("else if ");
					break;
				case ConditionalStage.Else:
					m_output.Append("else");
					condition = null;
					break;
			}
			if (condition != null)
			{
				m_output.Append(OPEN_BRACKET);
				condition.VisitThis(this);
				m_output.Append(CLOSE_BRACKET);
			}

			List<NodeBase> expressions = expressionNode.Children;
			int lastExpressionIndex = expressions.Count - 1;

			if (lastExpressionIndex > 0)
			{
				BeginBlock();
				m_tierStateStack.Push(new PslInspectionTierState(PslContext.Root, false));

				for (int i = 0; i <= lastExpressionIndex; i++)
				{
					expressions[i].VisitThis(this);
					if (i != lastExpressionIndex)
						NewLine();
				}

				m_tierStateStack.Pop();
				EndBlock();
			}
			else
			{
				NewLine(1);
				m_tierStateStack.Push(new PslInspectionTierState(PslContext.Inline, false));
				expressions[0].VisitThis(this);
				NewLine();
				m_tierStateStack.Pop();
			}
		}

		public override void ProcessNode(ConditionalConstructNode node)
		{
			List<NodeBase> conditions = node.Conditions;
			List<NodeBase> expressionSets = node.ExpressionSets;
			GroupingNode elseExpressionNode = node.ElseExpressionNode;

			ProcessConditionalSection(ConditionalStage.If, conditions[0], expressionSets[0] as GroupingNode);
			
			int lastElifIndex = conditions.Count - 2;
			for (int i = 1; i <= lastElifIndex; i++)
				ProcessConditionalSection(ConditionalStage.ElseIf, conditions[i], expressionSets[i] as GroupingNode);
			
			if (elseExpressionNode != null)
				ProcessConditionalSection(ConditionalStage.Else, null, elseExpressionNode);
		}

		public override void ProcessNode(RandomizeConstructNode node)
		{

		}

		#endregion

		#endregion

		#region Value Nodes

		public override void ProcessNode(BoolValueNode node)
		{
			m_output.Append(node.Value.ToString().ToLower());
		}

		public override void ProcessNode(RealValueNode node)
		{
			m_output.Append(node.Value);
		}

		public override void ProcessNode(ShortValueNode node)
		{
			m_output.Append(node.Value);
		}

		public override void ProcessNode(LongValueNode node)
		{
			m_output.Append(node.Value);
		}

		public override void ProcessNode(StringValueNode node)
		{
			m_output.Append(OPEN_STRING);
			m_output.Append(node.Value);
			m_output.Append(CLOSE_STRING);
		}

		public override void ProcessNode(ScriptReferenceValueNode node)
		{
			ScriptNode callee = node.Script;

			if (callee.Namespace != m_state.Namespace)
			{
				m_output.Append(CUSTOM_NAMESPACE_PREFIX);
				m_output.Append(callee.Namespace.Name);
				m_output.Append(NAMESPACE_DELIMITER);
			}
			m_output.Append(callee.Name);
		}

		public override void ProcessNode(VariableReferenceValueNode node)
		{
			VariableNode callee = node.Variable;

			if (callee.Scope == VariableScope.Global && callee.Namespace != m_state.Namespace)
			{
				m_output.Append(CUSTOM_NAMESPACE_PREFIX);
				m_output.Append(callee.Namespace.Name);
				m_output.Append(NAMESPACE_DELIMITER);
			}
			m_output.Append(callee.Name);
		}

		public override void ProcessNode(EnumerationValueNode node)
		{
			m_output.Append(node.Value);
		}

		public override void ProcessNode(TagReferenceValueNode node)
		{
			m_output.Append(OPEN_STRING);
			m_output.Append("auto:\\");
			m_output.Append(node.TagPath);
			m_output.Append(CLOSE_STRING);
		}

		public override void ProcessNode(BlockReferenceValueNode node)
		{
			BlockReferenceType reference = node.Type;

			switch (reference.BlockSource)
			{
				case BlockSourceTag.Scenario:
					m_output.Append(SCENARIO_REFERENCE_PREFIX);
					break;
				case BlockSourceTag.HudGlobals:
					m_output.Append(HUD_GLOBALS_REFERENCE_PREFIX);
					break;
			}

			m_output.Append(reference.FriendlyPluralName);
			m_output.Append(OPEN_ARRAY_INDEXER);
			m_output.Append(OPEN_STRING);
			m_output.Append(node.BlockIdentifier);
			m_output.Append(CLOSE_STRING);
			m_output.Append(CLOSE_ARRAY_INDEXER);
		}

		#endregion
	}
}
