using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	class NamespaceNode : NodeBase
	{
		private string m_name;

		public string Name
		{
			get { return m_name; }
		}

		/*private const char NAMESPACE_DELIMITER = '.';
		private void GetFullyQualifiedName(StringBuilder sb)
		{
			if (m_parent == null)
				return;

			(GetGrandparent() as NamespaceNode).GetFullyQualifiedName(sb);

			if (sb.Length != 0)
				sb.Append(NAMESPACE_DELIMITER);

			sb.Append(m_name);
		}

		public string GetFullyQualifiedName()
		{
			StringBuilder sb = new StringBuilder();
			GetFullyQualifiedName(sb);
			return sb.ToString();
		}*/

		public GroupingNode GlobalsNode
		{
			get { return m_children[0] as GroupingNode; }
		}

		public GroupingNode ScriptsNode
		{
			get { return m_children[1] as GroupingNode; }
		}

		public NamespaceNode(List<NodeBase> globals, List<NodeBase> scripts)
			: this(null, globals, scripts) { }

		public NamespaceNode(string name, List<NodeBase> globals, List<NodeBase> scripts)
			: this(name, new GroupingNode(globals), new GroupingNode(scripts)) { }

		public NamespaceNode(string name, GroupingNode globals, GroupingNode scripts)
			: base(new List<NodeBase>(new NodeBase[] { globals, scripts }))
		{
			m_name = name;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
