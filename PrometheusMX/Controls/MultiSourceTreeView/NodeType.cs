using System.Collections.Generic;
using DevComponents.DotNetBar;
using System;

namespace Prometheus.Controls
{
  /// <summary>
  /// Sets up the icons and sorting priority to use for specific types of nodes.
  /// </summary>
  public abstract class NodeType
  {
    #region Members
    private NodeSource parentSource = null;
    private string name = "";
    private int sortingPriority = 0;
    private int typePriority = 0;
    private bool displayCheckbox = false;
    private List<NodeState> states = new List<NodeState>();
    #endregion

    public event EventHandler<NodeRenamedEventArgs> NodeRenamed;

    #region Properties
    /// <summary>
    /// The NodeSource the this NodeType belongs to.
    /// </summary>
    public NodeSource ParentSource
    {
      get { return parentSource; }
      set { parentSource = value; }
    }

    /// <summary>
    /// The name that is used to identify the NodeType.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// The priority that Nodes of this type will have in sorting.
    /// The higher the priority, the closer to the top the node will be when grouped with
    /// nodes of other NodeTypes.  Different NodeTypes with the same priority will be
    /// sorted together based on the TreeView's SortMode.
    /// </summary>
    public int SortingPriority
    {
      get { return sortingPriority; }
    }

    /// <summary>
    /// Gets or sets the priority of this NodeType when stacked on the same MultiSourceTreeNode
    /// with other NodeTypes.
    /// </summary>
    public int TypePriority
    {
      get { return typePriority; }
    }

    /// <summary>
    /// Gets or sets a value indicating if a node containing this NodeType will
    /// display a checkbox control.
    /// </summary>    
    public bool DisplayCheckbox
    {
      get { return displayCheckbox; }
      set { displayCheckbox = value; }
    }

    /// <summary>
    /// Gets a list of NodeState that exist for nodes of this type.
    /// </summary>
    public NodeState[] States
    {
      get { return states.ToArray(); }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes the properties of the NodeType.
    /// Can only be invoked from a derived class.
    /// </summary>
    protected NodeType(string name, int sortingPriority, int typePriority, bool displayCheckbox)
    {
      this.name = name;
      this.sortingPriority = sortingPriority;
      this.typePriority = typePriority;
      this.displayCheckbox = displayCheckbox;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Adds the specified NodeState to the node type.
    /// </summary>
    public void AddNodeState(params NodeState[] states)
    {
      foreach (NodeState state in states)
      {
        if (!this.states.Contains(state))
        {
          this.states.Add(state);
          state.ParentType = this;
        }
      }
    }

    /// <summary>
    /// Returns the NodeState matching the specified name.
    /// </summary>
    public NodeState State(string name)
    {
      foreach (NodeState state in states)
        if (state.Name == name)
          return state;
      return null;
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public abstract string GetNodeName(string identifier);

    /// <summary>
    /// Returns the tooltip that will be displayed for this node.
    /// </summary>
    public virtual SuperTooltipInfo GetTooltip(NodeInfo info)
    {
      return null;
    }

    /// <summary>
    /// Returns a bool indicating is the NodeType supports renaming.
    /// </summary>
    public virtual bool SupportsRenaming
    {
      get { return false; }
    }

    /// <summary>
    /// This method will construct a new identifier based on the node name given.
    /// </summary>
    public virtual bool Rename(NodeInfo info, string newNodeName)
    {
      throw new NotImplementedException("This NodeType does not support renaming.");
    }

    /// <summary>
    /// Update the NodeInfo identifier of a child node.
    /// </summary>
    public virtual void RenameChild(NodeInfo info, NodeInfo newParentInfo)
    {
      throw new NotImplementedException("This NodeType does not support child renaming.");
    }

    #endregion

    #region Abstract Methods
    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public abstract NodeInfo[] GetChildNodes(NodeInfo info);

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public abstract NodeInfo GetParentNodeInfo(NodeInfo info);

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public virtual bool HasChildren(NodeInfo info)
    {
      return GetChildNodes(info).Length > 0;
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public abstract string GetTreePath(NodeInfo info);
    #endregion

    /// <summary>
    /// Generates the NodeRenamed event.
    /// </summary>
    protected void OnNodeRenamed(string oldIdentifier, string newIdentifier)
    {
      if (NodeRenamed != null)
        NodeRenamed(this, new NodeRenamedEventArgs(oldIdentifier, newIdentifier));
    }
  }

  /// <summary>
  /// Provides event data for the NodeRenamed event.
  /// </summary>
  public class NodeRenamedEventArgs : EventArgs
  {
    private string oldIdentifier;
    private string newIdentifier;

    /// <summary>
    /// The original identifier of the node that has been renamed.
    /// </summary>
    public string OldIdentifier
    {
      get { return oldIdentifier; }
      set { oldIdentifier = value; }
    }

    /// <summary>
    /// The new value of the node that has been renamed.
    /// </summary>
    public string NewIdentifier
    {
      get { return newIdentifier; }
      set { newIdentifier = value; }
    }

    public NodeRenamedEventArgs(string oldIdentifier, string newIdentifier)
    {
      this.oldIdentifier = oldIdentifier;
      this.newIdentifier = newIdentifier;
    }
  }
}