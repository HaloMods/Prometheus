using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  /// <summary>
  /// A TreeNode to be used with a MultiSourceTreeView.
  /// </summary>
  public class MultiSourceTreeNode : BetterTreeNode
  {
    private List<NodeInfo> infoEntries = new List<NodeInfo>();
    private Color defaultColor = SystemColors.ControlText;
    private bool childrenAdded = false;

    /// <summary>
    /// Extended information about the node.
    /// </summary>
    public NodeInfo[] InfoEntries
    {
      get { return infoEntries.ToArray(); }
    }

    /// <summary>
    /// The default color to be used when no colors are specified by the priority state.
    /// </summary>
    public Color DefaultColor
    {
      get { return defaultColor; }
      set { defaultColor = value; }
    }

    /// <summary>
    /// Adds the specified array of NodeInfo objects to the node's info entries collection.
    /// </summary>
    public void AddInfoEntries(params NodeInfo[] infos)
    {
      foreach (NodeInfo info in infos)
        AddInfoEntry(info);
    }

    /// <summary>
    /// Adds the specified NodeInfo to the node's info entries collection.
    /// </summary>
    public void AddInfoEntry(NodeInfo info)
    {
      info.Node = this;
      infoEntries.Add(info);
    }

    public void SetDefaultColor(Color foreColor)
    {
      if (infoEntries.Count < 1) return;
      if (infoEntries[infoEntries.Count - 1].PriorityState.ForegroundColor == Color.Empty)
      {
        ForeColor = foreColor;
        defaultColor = foreColor;
      }
    }

    public void UpdateNode()
    {
      if (infoEntries.Count < 1) return;
      infoEntries[infoEntries.Count-1].Update();
    }

    /// <summary>
    /// Gets the number of InfoEntries contained in this Node.
    /// </summary>
    public int EntryCount
    {
      get { return infoEntries.Count; }
    }

    /// <summary>
    /// Removes the specified NodeInfo from the node's info entries collection.
    /// </summary>
    public void RemoveInfoEntry(NodeInfo info)
    {
      infoEntries.Remove(info);
      UpdateNode();
    }

    /// <summary>
    /// Gets or sets a boolean indicating if children have already been added to this node.
    /// </summary>
    public bool ChildrenAdded
    {
      get { return childrenAdded; }
      set { childrenAdded = value; }
    }

    #region BaseClassConstructors
    public MultiSourceTreeNode() : base() { ; }
    public MultiSourceTreeNode(string text) : base(text) { ; }
    public MultiSourceTreeNode(string text, TreeNode[] children) : base(text, children) { ; }
    public MultiSourceTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { ; }
    public MultiSourceTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children) : base(text, imageIndex, selectedImageIndex, children) { ; }
    #endregion

    
    /// <summary>
    /// Locates the NodeInfo whose type matches the specified NodeType.
    /// </summary>
    public NodeInfo FindInfoEntry(NodeType type)
    {
      foreach (NodeInfo info in infoEntries)
        if (info.NodeType == type)
          return info;
      return null;
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo is contained within
    /// this node's InfoEntries collection.
    /// </summary>
    public bool ContainsEntry(NodeInfo info)
    {
      foreach (NodeInfo match in infoEntries)
        if (match.NodeType == info.NodeType)
          if (match.Identifier == info.Identifier)
            return true;
      return false;
    }
  }
}