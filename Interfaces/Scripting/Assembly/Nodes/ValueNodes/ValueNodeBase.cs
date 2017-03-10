
namespace Interfaces.Scripting.Assembly.Nodes.ValueNodes
{
	abstract class ValueNodeBase : NodeBase
	{
		protected ValueNodeBase() : base(null) { }

		public abstract short TypeIndex { get; }
	}
}
