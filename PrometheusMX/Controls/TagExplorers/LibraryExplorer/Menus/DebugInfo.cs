#if DEBUG
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition debugInfo;

    private void SetupDebugInfo()
    {
      debugInfo = new MenuDefinition(debugGroup, "View Debug Info", infoHandler);
      debugInfo.ToolTipText = "<b>For developer use only!</b>";
      debugInfo.Icon = Resources.debug_next16;
    }

    private void infoHandler(MultiSourceTreeNode node, NodeInfo info)
    {
      string nodeInfoText = "<b>Node Entry Information</b><br />";
      foreach (NodeInfo entry in node.InfoEntries)
      {
        nodeInfoText += entry.NodeType + " - " + entry.Identifier + "<br />";
      }
      nodeInfoText += "<br />Selected type: " + info.NodeType;
      MessageBoxEx.Show(nodeInfoText, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}
#endif