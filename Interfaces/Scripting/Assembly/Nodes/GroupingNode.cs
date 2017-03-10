using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	class GroupingNode : NodeBase
	{
		public GroupingNode(List<NodeBase> children) : base(children) { }

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}

		public static GroupingNode MakeGrouping(NodeBase expression)
		{
			GroupingNode group = expression as GroupingNode;
			if (group != null)
				return group;

			List<NodeBase> expressions = new List<NodeBase>();
			expressions.Add(expression);
			return new GroupingNode(expressions);
		}

		public void Insert(int index, NodeBase child)
		{
			m_children.Insert(index, child);
			AssignChild(child);
		}

		/*public void AddChildren(List<NodeBase> newChildren)
		{
			AssignAdditionalChildren(newChildren);
			m_children.AddRange(newChildren);
		}*/
	}
}
