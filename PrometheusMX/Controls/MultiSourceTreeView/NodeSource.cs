using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  /// <summary>
  /// Provides a source for nodes within a MultiSourceTreeView.
  /// </summary>
  public abstract class NodeSource : IDisposable
  {
    #region Private Members
    private string name;
    private Dictionary<Type, NodeType> nodeTypes = new Dictionary<Type, NodeType>();
    #endregion

    #region Public Properties
    /// <summary>
    /// Gets or sets the name that will be used to identify the NodeSource.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// Gets a list of NodeTypes contained within this NodeSource.
    /// </summary>
    public Dictionary<Type, NodeType> NodeTypes
    {
      get { return nodeTypes; }
    }

    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new instance of the NodeSource, applying the specified name.
    /// A 'root' NodeType is automatically created.
    /// </summary>
    public NodeSource(string name)
    {
      this.name = name;
    }
    #endregion

    /// <summary>
    /// Gets a value indicating if the NodeSource contains nodes.
    /// </summary>
    public abstract bool ContainsNodes { get; }

    /// <summary>
    /// Indicates that an item has been added to the NodeSource.
    /// </summary>
    public abstract event ItemHandler ItemAdded;

    /// <summary>
    /// Indicates that an item has been removed from the NodeSource.
    /// </summary>
    public abstract event ItemHandler ItemRemoved;

    /// <summary>
    /// Returns the NodeType from the collection that matches the specified name.
    /// </summary>
    public T GetNodeType<T>() where T : NodeType
    {
      Type nodeType = typeof(T);
      if (nodeTypes.ContainsKey(nodeType))
        return nodeTypes[nodeType] as T;
      else
        throw new Exception("The specified NodeType was not found: " + nodeType);
    }

    /// <summary>
    /// Creates a NodeType object, automatically adding a default NodeState with the
    /// specified icon and the default text colors.
    /// </summary>
    protected T CreateNodeType<T>(Bitmap expandedIcon, Bitmap collapsedIcon) where T : NodeType
    {
      DefaultState state = new DefaultState(expandedIcon, collapsedIcon, Color.Black, Color.White);
      return CreateNodeType<T>(state);
    }

    /// <summary>
    /// Creates a NodeType object, automatically adding a default NodeState with the
    /// specified icon and the default text colors.
    /// </summary>
    protected T CreateNodeType<T>(Bitmap icon) where T : NodeType
    {
      return CreateNodeType<T>(icon, icon);
    }

    /// <summary>
    /// Creates a NodeType object, automatically adding the specified NodeState.
    /// </summary>
    protected T CreateNodeType<T>(NodeState defaultState) where T : NodeType
    {
      T instance = (T)Activator.CreateInstance(typeof(T));
      instance.AddNodeState(defaultState);
      return instance;
    }

    /// <summary>
    /// Adds a node type with the specified properties.
    /// </summary>
    protected void AddNodeType(NodeType nodeType)
    {
      Type key = nodeType.GetType();
      if (!nodeTypes.ContainsKey(key))
      {
        nodeType.ParentSource = this;
        nodeTypes.Add(key, nodeType);
      }
    }

    /// <summary>
    /// Adds the specified MenuDefinition to the default state of all node types.
    /// </summary>
    public void AddGlobalMenuDefinition(MenuDefinition definition)
    {
      foreach (NodeType nodeType in nodeTypes.Values)
        nodeType.States[0].AddMenuDefinitions(definition);
    }

    /// <summary>
    /// Creates all child nodes contained within the specified path.
    /// </summary>
    public MultiSourceTreeNode[] BuildChildNodes(NodeType nodeType, string path)
    {
      List<NodeInfo> children = new List<NodeInfo>();
      NodeInfo info = new NodeInfo(nodeType, path);
      children.AddRange(nodeType.GetChildNodes(info));

      MultiSourceTreeNode[] treeNodes = new MultiSourceTreeNode[children.Count];
      for (int x = 0; x < treeNodes.Length; x++)
        treeNodes[x] = CreateNode(children[x].NodeType.GetNodeName(children[x].Identifier), children[x],
          children[x].NodeType.HasChildren);

      return treeNodes;
    }

    ///// <summary>
    ///// Links the supplied MenuDefinition to all of the specified nodeTypes.
    ///// </summary>
    //public void AddMenuItem(MenuDefinition definition, params string[] nodeTypes)
    //{
    //  foreach (string nodeType in nodeTypes)
    //    AddMenuItem(nodeType, definition);
    //}

    ///// <summary> 
    ///// Links the supplied MenuDefinition to the specified nodeType.
    ///// </summary>
    //public void AddMenuItem(string nodeType, MenuDefinition definition)
    //{
    //  GetNodeType(nodeType).MenuDefinitions.Add(definition);
    //}

    /// <summary>
    /// Represents a method that can determine if the specified NodeInfo contains children.
    /// </summary>
    public delegate bool HasChildrenTest(NodeInfo info);

    /// <summary>
    /// Updates the visual properties of the specified node based on highest
    /// priority NodeEntry that it contains.
    /// </summary>
    public void UpdateNode(MultiSourceTreeNode node)
    {
      if (node == null) return;

      // Invoke if necessary.
      if (node.TreeView != null)
        if (node.TreeView.InvokeRequired)
        {
          node.TreeView.Invoke(new MethodInvoker(delegate { UpdateNode(node); }));
          return;
        }

      // Determine the priority NodeInfo entry.
      if (node.EntryCount > 0)
      {
        NodeInfo priorityEntry = node.InfoEntries[0];
        for (int x = 1; x < node.EntryCount; x++)
        {
          if (node.InfoEntries[x].NodeType.TypePriority
              > priorityEntry.NodeType.TypePriority)
            priorityEntry = node.InfoEntries[x];
        }

        // Update the node with the priority NodeState values.
        NodeState priorityState = priorityEntry.PriorityState;
        if (priorityState.ExpandedIconIndex != -1)
          node.ExpandedImageIndex = priorityState.ExpandedIconIndex;
        if (priorityState.CollapsedIconIndex != -1)
          node.CollapsedImageIndex = priorityState.CollapsedIconIndex;
        
        if (priorityState.ForegroundColor != Color.Empty)
          node.ForeColor = priorityState.ForegroundColor;
        else if (node.DefaultColor != Color.Empty)
          node.ForeColor = node.DefaultColor;
        
        if (priorityState.BackgroundColor != Color.Empty)
          node.BackColor = priorityState.BackgroundColor;
        node.ShowCheckbox = priorityState.ParentType.DisplayCheckbox;
      }
    }

    /// <summary>
    /// Creates a node based on the supplied NodeInfo.
    /// </summary>
    public MultiSourceTreeNode CreateNode(string nodeText, NodeInfo info)
    {
      return CreateNode(nodeText, info, null);
    }


    /// <summary>
    /// Creates a node based on the supplied NodeInfo.
    /// </summary>
    public MultiSourceTreeNode CreateNode(string nodeText, NodeInfo info, HasChildrenTest test)
    {
      MultiSourceTreeNode node = new MultiSourceTreeNode();
      node.AddInfoEntry(info);
      UpdateNode(node);
      node.Text = nodeText;

      if (test != null)
        if (test.Invoke(info))
          AddDummyNode(node);

      return node;
    }

    /// <summary>
    /// Adds a 'dummy node' to the specified MultiSourceTreeNode.
    /// </summary>
    /// <description>
    /// The purpose of a dummy node, is to allow a node to be expandable without
    /// having to actually populate it's child nodes first.  This allows us to
    /// load child nodes on the fly - thus greatly improving performance of the TreeView.
    /// </description>
    protected static void AddDummyNode(MultiSourceTreeNode node)
    {
      node.Nodes.Add("dummy");
    }

    /// <summary>
    /// Creates the NodeInfo objects that will be contained in the root node.
    /// </summary>
    public abstract NodeInfo[] CreateRootNodeInfo();

    /// <summary>
    /// Returns a value indicating of the specified parent NodeType can be dropped
    /// into a node of the specified child NodeType.
    /// </summary>
    public abstract bool CanDropInto(NodeType parentNodeType, NodeType childNodeType);

    ///<summary>
    ///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    ///</summary>
    public virtual void Dispose() { ; }

    public abstract void HandleNodeDrop(NodeInfo info, NodeInfo targetInfo);
  }

  /// <summary>
  /// Defines a method that handles tasks related to nodes.
  /// </summary>
  public delegate void ItemHandler(NodeInfo info);
}