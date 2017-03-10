using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Psl
{
	class PslArrayNode : NodeBase
	{
		private string m_name;
		private short m_typeIndex;

		public string Name
		{
			get { return m_name; }
		}

		public short TypeIndex
		{
			get { return m_typeIndex; }
		}

		public List<NodeBase> Elements
		{
			get { return m_children; }
		}

		public PslArrayNode(short typeIndex, List<NodeBase> elements)
			: this(null, typeIndex, elements) { }

		public PslArrayNode(string name, short typeIndex, List<NodeBase> elements) : base(elements)
		{
			m_name = name;
			m_typeIndex = typeIndex;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
