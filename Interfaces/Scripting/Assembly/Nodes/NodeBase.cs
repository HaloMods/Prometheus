using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	enum NodeComparison
	{
		Incompatible,
		Equal,
		Unequal
	}

	abstract class NodeBase : IVisitable
	{
		protected NodeBase m_parent;
		protected List<NodeBase> m_children;

		/*public NodeBase Parent
		{
			get { return m_parent; }
		}*/
		
		public List<NodeBase> Children
		{
			get { return m_children; }
		}

		protected NodeBase(List<NodeBase> children)
		{
			if (children != null)
				AssignChildren(children);
		}

		protected void AssignChildren(List<NodeBase> children)
		{
			m_children = children;
			foreach (NodeBase child in m_children)
				child.m_parent = this;
		}

		protected void AssignChild(NodeBase child)
		{
			child.m_parent = this;
		}

		public void Replace(NodeBase replacementNode)
		{
			int index = m_parent.m_children.IndexOf(this);
			m_parent.m_children[index] = replacementNode;
			replacementNode.m_parent = m_parent;
			m_parent = null;
		}

		public virtual NodeComparison ShallowCompare(NodeBase node)
		{
			return m_children.Count == node.m_children.Count ? NodeComparison.Equal : NodeComparison.Incompatible;
		}

		public abstract void VisitThis(VisitorProcessorBase visitor);
	}
}
