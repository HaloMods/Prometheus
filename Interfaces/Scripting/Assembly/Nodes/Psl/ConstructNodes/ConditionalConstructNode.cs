using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes
{
	class ConditionalConstructNode : NodeBase
	{
		private GroupingNode m_conditionsNode
		{
			get { return m_children[0] as GroupingNode; }
		}

		/// <summary>
		/// List of single nodes that provide the conditional statements.
		/// </summary>
		public List<NodeBase> Conditions
		{
			get { return m_conditionsNode.Children; }
		}

		private GroupingNode m_expressionSetsNode
		{
			get { return m_children[1] as GroupingNode; }
		}

		/// <summary>
		/// List of grouping nodes that provide the expression sets.
		/// </summary>
		public List<NodeBase> ExpressionSets
		{
			get { return (m_children[1] as GroupingNode).Children; }
		}

		public GroupingNode ElseExpressionNode
		{
			get { if (m_children.Count < 3) return null; return m_children[2] as GroupingNode; }
		}

		public ConditionalConstructNode(List<NodeBase> conditions, List<NodeBase> expressionSets, GroupingNode elseExpressions)
			: base(elseExpressions == null ? new List<NodeBase>(new NodeBase[] { new GroupingNode(conditions), new GroupingNode(expressionSets) }) : new List<NodeBase>(new NodeBase[] { new GroupingNode(conditions), new GroupingNode(expressionSets), elseExpressions }))
		{ }

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}

		public void InsertConditional(NodeBase condition, GroupingNode expressions)
		{
			m_conditionsNode.Insert(0, condition);
			m_expressionSetsNode.Insert(0, expressions);
		}
	}
}
