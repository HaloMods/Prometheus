using System.Collections.Generic;
using Interfaces.Scripting.Assembly.Nodes;
using Interfaces.Scripting.Assembly.Nodes.ValueNodes;

namespace Interfaces.Scripting.Assembly.Processors
{
	class ValueDiscrepancy
	{
		private List<NodeBase> m_nodes;
		private short m_typeIndex;

		public List<NodeBase> Nodes
		{
			get { return m_nodes; }
		}

		public short TypeIndex
		{
			get { return m_typeIndex; }
		}

		public ValueDiscrepancy(List<NodeBase> nodes, short typeIndex)
		{
			m_nodes = nodes;
			m_typeIndex = typeIndex;
		}
	}

	static class SingleValueDiscrepancySearch
	{
		private static ValueDiscrepancy s_valueDiscrepancy;

		public static ValueDiscrepancy Perform(List<NodeBase> nodes)
		{
			ValueDiscrepancy result = null;

			if (PerformRecursive(nodes))
				result = s_valueDiscrepancy;

			s_valueDiscrepancy = null;
			return result;
		}

		private static bool PerformRecursive(List<NodeBase> nodes)
		{
			List<NodeBase> valueNodes = new List<NodeBase>();

			NodeBase firstNode = nodes[0];
			bool isValueNodeLevel = firstNode is ValueNodeBase;

			List<List<NodeBase>> childNodeArrays = new List<List<NodeBase>>();
			int childNodeCount = firstNode.Children.Count;
			for (int i = 0; i < childNodeCount; i++)
			{
				childNodeArrays.Add(new List<NodeBase>());
				childNodeArrays[i].Add(firstNode.Children[i]);
			}

			for (int i = 1; i < nodes.Count; i++)
			{
				NodeBase node = nodes[i];
				NodeComparison result = firstNode.ShallowCompare(node);

				if (result == NodeComparison.Incompatible)
					return false;

				if (isValueNodeLevel)
					valueNodes.Add(node);
				else
				{
					if (result == NodeComparison.Unequal)
						return false;
					
					// Handle children
					for (int j = 0; j < childNodeCount; j++)
						childNodeArrays[j].Add(node.Children[j]);
				}
			}

			if (isValueNodeLevel)
			{
				if (s_valueDiscrepancy != null) // There is already an existing recorded discrepancy (only one allowed)
					return false;

				s_valueDiscrepancy = new ValueDiscrepancy(valueNodes, (firstNode as ValueNodeBase).TypeIndex);
				return true;
			}


			for (int i = 0; i < childNodeCount; i++)
			{
				if (!PerformRecursive(childNodeArrays[i]))
					return false;
			}

			return true;
		}
	}
}
