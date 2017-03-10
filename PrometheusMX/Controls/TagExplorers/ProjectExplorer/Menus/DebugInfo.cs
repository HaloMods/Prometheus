#if DEBUG
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class ProjectExplorer
  {
    private MenuDefinition debugInfo;

    private void SetupDebugInfo()
    {
      debugInfo = new MenuDefinition(debugGroup, "View Debug Info", infoHandler);
      //debugInfo.DynamicTooltipCallback = delegate(MultiSourceTreeNode node, NodeInfo info)
      //{
      //  return GenerateDebugInfo(node, info);
      //};
      debugInfo.ToolTipText = "For developer use only!";
      debugInfo.Icon = Resources.debug_next16;
    }

    private void infoHandler(MultiSourceTreeNode node, NodeInfo info)
    {
      string nodeInfoText = GenerateDebugInfo(node, info);
      MessageBoxEx.Show(nodeInfoText, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private string GenerateDebugInfo(MultiSourceTreeNode node, NodeInfo info)
    {
      string nodeInfoText = "<b>Node Entry Information</b><br />";
      foreach (NodeInfo entry in node.InfoEntries)
      {
        nodeInfoText += entry.NodeType + " - " + entry.Identifier + "<br/><br/>Active States: (<i>";
        string states = "";
        foreach (NodeStateSubscriber subscriber in entry.Subscriptions)
          if (subscriber.Active)
            states += subscriber.State.Name + ", ";
        nodeInfoText += states.Substring(0, states.Length - 2);
        nodeInfoText += "</i>)";
      }
      return nodeInfoText;
    }
  }
}
#endif