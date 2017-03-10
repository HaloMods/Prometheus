using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Processors;

namespace Interfaces.Scripting.Assembly.Nodes.Psl.ConstructNodes
{
	class RandomizeConstructNode : NodeBase
	{
		private short m_sleepTime;

		public RandomizeConstructNode(List<NodeBase> expressionSets, short sleepTime)
			: base(expressionSets)
		{
			m_sleepTime = sleepTime;
		}

		public override void VisitThis(VisitorProcessorBase visitor)
		{
			visitor.ProcessNode(this);
		}
	}
}
