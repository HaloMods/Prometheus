using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes
{
	enum VariableScope
	{
		Global,
		Local
	}

	class VariableNode : NodeBase
	{
		private NamespaceNode m_namespace;
		private string m_name;
		private short m_type;
		private bool m_isArray;
		private bool m_isIterator;
		private VariableScope m_scope;
		private List<VariableReferenceValueNode> m_references;

		public NamespaceNode Namespace
		{
			get { return m_namespace; }
		}

		public void AssignToNamespace(NamespaceNode @namespace)
		{
			m_namespace = @namespace;
		}

		public string Name
		{
			get { return m_name; }
		}

		public short Type
		{
			get { return m_type; }
		}

		public bool IsArray
		{
			get { return m_isArray; }
		}

		public bool IsIterator
		{
			get { return m_isIterator; }
		}

		public VariableScope Scope
		{
			get { return m_scope; }
		}

		public NodeBase InitialisationExpression
		{
			get { return m_children[0]; }
		}

		public List<VariableReferenceValueNode> References
		{
			get { return m_references; }
		}

		private VariableNode(string name, short type, bool isArray, bool isIterator, VariableScope scope, NodeBase initialisationExpression)
			: base(new List<NodeBase>(new NodeBase[] { initialisationExpression }))
		{
			m_name = name;
			m_type = type;
			m_isArray = isArray;
			m_isIterator = isIterator;
			m_scope = scope;
			m_references = new List<VariableReferenceValueNode>();
		}

		//public VariableNode(string name, short type, NodeBase initialisationExpression)
		//	: this(name, type, VariableScope.Local, initialisationExpression) { }

		public VariableNode(string name, short type, bool isArray, bool isIterator, NodeBase initialisationExpression)
			: this(name, type, isArray, isIterator, VariableScope.Local, initialisationExpression) { }

		public VariableNode(string name, short type, NodeBase initialisationExpression)
			: this(name, type, false, false, VariableScope.Global, initialisationExpression) { }

		public VariableNode(string name, short type, bool isArray, NamespaceNode @namespace, NodeBase initialisationExpression)
			: this(name, type, isArray, false, VariableScope.Global, initialisationExpression)
		{
			m_namespace = @namespace;
		}

		public void Rename(string name)
		{
			m_name = name;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
