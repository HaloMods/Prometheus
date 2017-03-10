using System.Drawing;

namespace Prometheus.Controls
{
  public class DefaultState : NodeState
  {
    public DefaultState(Bitmap icon)
      : this(icon, icon) { ; }

    public DefaultState(Bitmap collpasedIcon, Bitmap expandedIcon)
      : this(collpasedIcon, expandedIcon, Color.Empty, Color.Empty) { ; }

    public DefaultState(Bitmap collapsedIcon, Bitmap expandedIcon,
      Color foregroundColor, Color backgroundColor)
      : base("default", collapsedIcon, expandedIcon, foregroundColor, backgroundColor) { ; }

    /// <summary>
    /// Determines the initial state that subscribers of this state will be in.
    /// </summary>
    protected override bool DetermineState(NodeInfo info)
    {
      return true; // This is the default state and will always be active.
    }
  }
}