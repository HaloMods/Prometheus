using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;
using Core;
using DevComponents.DotNetBar;
using Interfaces;
using System.Runtime.InteropServices;

namespace Prometheus.Controls
{
  public class MultiSourceTreeView : BetterTreeView
  {
    #region Private Members
    private List<NodeHierarchy> hierarchies = new List<NodeHierarchy>();
    private List<Bitmap> bitmaps = new List<Bitmap>();
    private bool initialized = false;
    private SortMode sortMode;
    private string treeEmptyText;
    private Color treeEmptyTextColor = Color.Gray;
    private Font treeEmptyTextFont = new Font("Arial", 8.5f);
    private Bitmap treeEmptyIcon = null;
    private int treeEmptyAlpha = 255;
    private bool fadeInMouseOut = true;
    ContextMenuBar cmbPopupMenu;
    SuperTooltip tooltip = new SuperTooltip();
    System.Timers.Timer mouseIdle = new System.Timers.Timer(1000);
    #endregion

    #region public Properties
    public bool FadeOnMouseOut
    {
      get { return fadeInMouseOut; }
      set { fadeInMouseOut = value; }
    }

    /// <summary>
    /// Gets or sets the color of the text that will display when the tree is empty.
    /// </summary>
    public Color TreeEmptyTextColor
    {
      get { return treeEmptyTextColor; }
      set
      {
        treeEmptyTextColor = value;
        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the Font of the text that will display when the tree is empty.
    /// </summary>
    public Font TreeEmptyTextFont
    {
      get { return treeEmptyTextFont; }
      set
      {
        treeEmptyTextFont = value;
        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the text that will display when the tree is empty.
    /// </summary>
    public string TreeEmptyText
    {
      get { return treeEmptyText; }
      set
      {
        treeEmptyText = value;
        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the icon that will display when the tree is empty.
    /// </summary>
    public Bitmap TreeEmptyIcon
    {
      get { return treeEmptyIcon; }
      set
      {
        treeEmptyIcon = value;
        if (treeEmptyIcon == null)
          treeEmptyIcon = new Bitmap(1, 1);
        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the alpha of the text and icon that will display when the tree is empty.
    /// </summary>
    public int TreeEmptyAlpha
    {
      get { return treeEmptyAlpha; }
      set
      {
        treeEmptyAlpha = value;
        Refresh();
      }
    }

    /// <summary>
    /// Gets or sets the SortMode that the TreeView will use for sorting nodes.
    /// </summary>
    public SortMode SortMode
    {
      get { return sortMode; }
      set
      {
        sortMode = value;
        if (sortMode == SortMode.Alphabetical)
        {
          TreeViewNodeSorter = new AlphabeticNodeSorter();
          Sorted = true;
        }
        else
        {
          Sorted = false;
          TreeViewNodeSorter = null;
        }
      }
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new instance of the MultiSourceTreeView.
    /// </summary>
    public MultiSourceTreeView()
    {
      MoveNodesOnDragDrop = false;
      BeforeExpand += MultiSourceTreeView_BeforeExpand;
      AfterSelect += MultiSourceTreeView_AfterSelect;
      MouseDown += MultiSourceTreeView_MouseDown;
      SortMode = SortMode.NodeSource;
      Paint += MultiSourceTreeView_Paint;
      SortMode = SortMode.Alphabetical;
      DragOverNode += MultiSourceTreeView_DragOverNode;
      NodeDropped += MultiSourceTreeView_NodeDropped;
      MouseEnter += MultiSourceTreeView_MouseEnter;
      MouseLeave += MultiSourceTreeView_MouseLeave;
      MouseMove += new MouseEventHandler(MultiSourceTreeView_MouseMove);
      popupMenu = new ButtonItem();
      popupMenu.AutoExpandOnClick = true;
      cmbPopupMenu = new ContextMenuBar();
      cmbPopupMenu.Name = "PopupMenuBar";
      cmbPopupMenu.BeginInit();
      cmbPopupMenu.Items.Add(popupMenu);
      cmbPopupMenu.Style = eDotNetBarStyle.Office2007;
      Controls.Add(cmbPopupMenu);
      cmbPopupMenu.EndInit();
      mouseIdle.SynchronizingObject = this;
      mouseIdle.Elapsed += new System.Timers.ElapsedEventHandler(mouseIdle_Elapsed);
      tooltip.CheckTooltipPosition = false;
      AfterLabelEdit += new NodeLabelEditEventHandler(MultiSourceTreeView_AfterLabelEdit);
      BeforeLabelEdit += new NodeLabelEditEventHandler(MultiSourceTreeView_BeforeLabelEdit);
      NodeMouseClick += new TreeNodeMouseClickEventHandler(MultiSourceTreeView_NodeMouseClick);
      GotFocus += new EventHandler(MultiSourceTreeView_GotFocus);
    }

    void MultiSourceTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      MultiSourceTreeNode node = (MultiSourceTreeNode)e.Node;
      LabelEdit = (node.InfoEntries[0].NodeType.SupportsRenaming);
    }

    // TODO: Move the updates to a seperate method to prepare for external node rename support.
    void MultiSourceTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
      if (String.IsNullOrEmpty(e.Label))
      {
        e.CancelEdit = true;
        return;
      }

      MultiSourceTreeNode node = ((MultiSourceTreeNode)e.Node);
      NodeInfo info = node.InfoEntries[0];
      if (info.NodeType.SupportsRenaming)
      {
        if (info.NodeType.Rename(info, e.Label))
          UpdateChildNodesAfterRename(node);
      }
    }

    /// <summary>
    /// Recursively updates a node's child nodes after it has been renamed.
    /// </summary>
    void UpdateChildNodesAfterRename(MultiSourceTreeNode parentNode)
    {
      if (parentNode.ChildrenAdded)
      {
        foreach (MultiSourceTreeNode node in parentNode.Nodes)
        {
          foreach (NodeInfo info in node.InfoEntries)
          {
            if (info.NodeType.SupportsRenaming)
              info.NodeType.RenameChild(info, parentNode.InfoEntries[0]); // We're only using the first InfoEntry.
          }
          if (node.ChildrenAdded)
            UpdateChildNodesAfterRename(node);
        }
      }
    }

    ~MultiSourceTreeView()
    {
      Dispose(false);
    }
    #endregion

    void mouseIdle_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      if (CustomTooltipDisabled)
        return;

      // Setup the super tooltip.
      tooltip.SetSuperTooltip(this, null);

      if (currentNode == null)
        return;

      if (currentNode.InfoEntries.Length < 1)
        return;

      SuperTooltipInfo info = currentNode.InfoEntries[0].NodeType.GetTooltip(currentNode.InfoEntries[0]);
      if (info != null)
      {
        UseInternalTooltips = false;

        // Set and display the tooltip.
        tooltip.SetSuperTooltip(this, info);
        tooltip.ShowTooltip(this, MousePosition);
      }
    }

    MultiSourceTreeNode currentNode = null;
    Point lastMousePosition;
    bool tooltipsOn = true;
    void MultiSourceTreeView_MouseMove(object sender, MouseEventArgs e)
    {
      if (MousePosition == lastMousePosition)
        return;

      lastMousePosition = MousePosition;

      // Get the node that exists at the mouse position.
      MultiSourceTreeNode node = GetNodeAt(PointToClient(MousePosition)) as MultiSourceTreeNode;

      if (node != currentNode)
      {
        currentNode = node;

        UseInternalTooltips = true;
        tooltip.HideTooltip();

        ResetMouseIdleTimer();
      }
    }

    void ResetMouseIdleTimer()
    {
      mouseIdle.Stop();
      mouseIdle.AutoReset = false;
      mouseIdle.Start();
    }

    bool customTooltipDisabled = false;
    bool CustomTooltipDisabled
    {
      get { return customTooltipDisabled; }
      set
      {
        customTooltipDisabled = value;
        if (!value)
          ResetMouseIdleTimer();
      }
    }
    void MultiSourceTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
    {
      CustomTooltipDisabled = true;
    }

    void MultiSourceTreeView_GotFocus(object sender, EventArgs e)
    {
      CustomTooltipDisabled = false;
    }

    /// <summary>
    /// Gets or sets a value indicating if the treeview's internal tooltips should be used.
    /// </summary>
    protected bool UseInternalTooltips
    {
      get { return tooltipsOn; }
      set
      {
        if (tooltipsOn != value)
        {
          tooltipsOn = value;
          if (tooltipsOn)
            SetWindowLong(Handle, GWL_STYLE, (IntPtr)(GetWindowLong(Handle, GWL_STYLE) & (~TVS_NOTOOLTIPS)));
          else
            SetWindowLong(Handle, GWL_STYLE, (IntPtr)(GetWindowLong(Handle, GWL_STYLE) | TVS_NOTOOLTIPS));
        }
      }
    }

    void MultiSourceTreeView_NodeDropped(object sender, NodeDroppedEventArgs e)
    {
      // We will raise a public event here so that it can be handled externally.
      MultiSourceTreeNode node = e.Node as MultiSourceTreeNode;
      MultiSourceTreeNode targetNode = e.TargetNode as MultiSourceTreeNode;
      if (node == null || targetNode == null)
        return;

      foreach (NodeInfo info in node.InfoEntries)
        foreach (NodeInfo targetInfo in targetNode.InfoEntries)
          info.ParentSource.HandleNodeDrop(info, targetInfo);
    }

    void MultiSourceTreeView_MouseLeave(object sender, EventArgs e)
    {
      CustomTooltipDisabled = true;

      if (fadeInMouseOut)
        foreach (MultiSourceTreeNode node in Nodes)
          UpdateNodeDefaultColor(node, Color.LightGray);
    }

    private void UpdateNodeDefaultColor(MultiSourceTreeNode node, Color foregroundColor)
    {
      //node.SetDefaultColor(foregroundColor);
      //if (node.ChildrenAdded)
      //  foreach (MultiSourceTreeNode childNode in node.Nodes)
      //    UpdateNodeDefaultColor(childNode, foregroundColor);
    }

    void MultiSourceTreeView_MouseEnter(object sender, EventArgs e)
    {
      CustomTooltipDisabled = false;

      if (fadeInMouseOut)
        foreach (MultiSourceTreeNode node in Nodes)
          UpdateNodeDefaultColor(node, SystemColors.ControlText);
    }

    const int DOUBLE_CLICK = 515;
    protected override void WndProc(ref Message m)
    {
      switch (m.Msg)
      {
        case DOUBLE_CLICK:
          HandleDoubleClick();
          return;
      }
      base.WndProc(ref m);
    }

    private void HandleDoubleClick()
    {
      MultiSourceTreeNode node = (MultiSourceTreeNode)GetNodeAt(lastClickX, lastClickY);
      if (node == null) return;

      foreach (NodeInfo info in node.InfoEntries)
        foreach (NodeStateSubscriber subscriber in info.Subscriptions)
          foreach (MenuDefinition def in subscriber.State.MenuDefinitions.Keys)
          {
            bool match = false;
            if (subscriber.State.MenuDefinitions[def]) // Will equal true if this is a default option.
            {
              match = true;
              if (def.MenuItemTest != null)
                match = def.MenuItemTest.Invoke(node, info);
            }
            if (match)
            {
              def.OnMenuClicked(node, info);
              return;
            }
          }
    
      if (node.IsExpanded)
        node.Collapse();
      else
        node.Expand();
    }

    void MultiSourceTreeView_DragOverNode(object sender, DragOverNodeEventArgs e)
    {
      // Verify that the nodes are the correct type for this operation.
      if (!(e.Node is MultiSourceTreeNode) || !(e.TargetNode is MultiSourceTreeNode))
        return;

      MultiSourceTreeNode node = (MultiSourceTreeNode)e.Node;
      MultiSourceTreeNode targetNode = (MultiSourceTreeNode)e.TargetNode;

      // For now, we are only allowing dropping of nodes that have a single info entry.
      if (node.EntryCount != 1)
        e.Cancel = true;
      else if (targetNode.EntryCount != 1)
        e.Cancel = true;
      else
        e.Cancel = !(node.InfoEntries[0].NodeType.ParentSource.CanDropInto(
          targetNode.InfoEntries[0].NodeType, node.InfoEntries[0].NodeType));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this);
        tooltip.SetSuperTooltip(this, null);
      }

      base.Dispose(disposing);
    }

    #region Public Methods
    /// <summary>
    /// Sets up the tree and adds the first level of nodes.
    /// Once this method is called, additional NodeHierarchies cannot be added until the tree is Reset.
    /// This is because ImageList objects are created, and would have to be modified (thus
    /// changing all of the image indices in nodes that are already created).
    /// </summary>
    public void Initialize()
    {
      if (initialized) return;
      ImageList = Helpers.GenerateImageList(bitmaps.ToArray());
      InitializeTree();
      initialized = true;
    }

    /// <summary>
    /// Removes all nodes, images, and NodeHierarchies, and resets the TreeView to a default state.
    /// Once this method is called, new NodeSources and images can be added.
    /// </summary>
    public void Reset()
    {
      foreach (NodeHierarchy hierarchy in hierarchies)
      {
        foreach (NodeSource source in hierarchy.NodeSources)
        {
          source.ItemAdded -= source_ItemAdded;
          source.ItemRemoved -= source_ItemRemoved;
        }
        hierarchy.Dispose();
      }
      hierarchies.Clear();
      bitmaps.Clear();
      Nodes.Clear();
      initialized = false;
    }

    public void AddNodeHierarchy(NodeHierarchy hierarchy)
    {
      if (initialized)
        throw new Exception("Cannot add additional node hierarchies once the tree has been initialized.");

      if (hierarchy.NodeSources.Count < 1) return;
      
      hierarchies.Add(hierarchy);
      foreach (NodeSource source in hierarchy.NodeSources)
      {
        source.ItemAdded += source_ItemAdded;
        source.ItemRemoved += source_ItemRemoved;
        foreach (NodeType nodeType in source.NodeTypes.Values)
        {
          foreach (NodeState state in nodeType.States)
          {
            if (state.CollapsedIcon != null)
            {
              bitmaps.Add(state.CollapsedIcon);
              state.CollapsedIconIndex = bitmaps.Count - 1;
            }
            else
              state.CollapsedIconIndex = -1;

            if (state.CollapsedIcon != null)
            {
              bitmaps.Add(state.ExpandedIcon);
              state.ExpandedIconIndex = bitmaps.Count - 1;
            }
            else
              state.ExpandedIconIndex = -1;
          }
        }
      }
    }

    void source_ItemRemoved(NodeInfo info)
    {
      RemoveNodeInfo(info);
    }

    void source_ItemAdded(NodeInfo info)
    {
      UpdateNode(info);
    }

    private void RemoveNodeInfo(NodeInfo info)
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate { RemoveNodeInfo(info); }));
        return;
      }

      // Retreive the node from the tree (if it exists).
      //Output.Write(OutputTypes.Debug, "Removing Node (" + info.NodeType.GetType() + "): " + info.Identifier);
      string treePath = info.NodeType.GetTreePath(info);
      MultiSourceTreeNode node = (MultiSourceTreeNode)GetNodeFromPath(treePath);
      if (node != null)
      {
        // Store our parent, since this will change once we remove the node from it.
        TreeNode parentNode = node.Parent;

        //Output.Write(OutputTypes.Debug, "Node exists in the tree.");

        // Remove the entry if it exists.
        NodeInfo entry = node.FindInfoEntry(info.NodeType);
        if (entry != null)
        {
          node.RemoveInfoEntry(entry);
          //Output.Write(OutputTypes.Debug, "Removed matching InfoEntry from the node.");
        }
        //else
          //Output.Write(OutputTypes.Debug, "Matching InfoEntry was not found!");


        // Update the node if we still have entries.
        // DESIGN ISSUE:
        // -------------
        // When an entry is removed, child nodes will also need updating.
        // The problem is, there is no way to do this without recreating the child nodes.
        if (node.EntryCount > 0)
        {
          info.ParentSource.UpdateNode(node);
          //Output.Write(OutputTypes.Debug, "Node still contains entries - updating.");
        }
        else
          // Remove the node (if there is a parent to remove it from)
          if (parentNode != null)
          {
            //Output.Write(OutputTypes.Debug, "Node contains no more entries - removing node.");
            parentNode.Nodes.Remove(node);
            if (parentNode.Nodes.Count == 0)
              parentNode.Collapse();
          }

        // Verify the parent node.
        if (parentNode != null)
          if (parentNode is MultiSourceTreeNode)
          {
            //Output.Write(OutputTypes.Debug, "Verifying parent node: " + parentNode.Text);
            VerifyNode(parentNode as MultiSourceTreeNode);
          }
      }
      else
      {
        //Output.Write(OutputTypes.Debug, "Node does not exist in the tree.");
        // The node doesn't exist in the tree, so we don't need to remove it.
        // We do, however, still need to update the node's parent to ensure that
        // it still contains child objects of this type.
        
        // Direct parent may not exist (which was causing issues previously)
        // Because of that, we will need to go all the way up the tree until we
        // either find a node, or hit the root node.
        MultiSourceTreeNode parentNode = GetFirstExistingParentNode(info);
        if (parentNode != null)
        {
          //Output.Write(OutputTypes.Debug, "Located a parent node: " + parentNode.Text + " - Updating.");
          VerifyNode(parentNode);
        }
        //else
          //Output.Write(OutputTypes.Debug, "No parent node was found - no updates required.");
      }
    }

    /// <summary>
    /// Looks through the tree to find the first exist node that is a parent of
    /// the node represented by the specified NodeInfo.
    /// The NodeInfo node does not have to exist in the tree.
    /// </summary>
    private MultiSourceTreeNode GetFirstExistingParentNode(NodeInfo info)
    {
      NodeInfo parentInfo = info.NodeType.GetParentNodeInfo(info);
      if (parentInfo == null)
        return null;

      string parentPath = parentInfo.Identifier;
      if (parentPath == "") // This is the root node, and doesn't count.
        return null;

      string parentTreePath = info.NodeType.GetTreePath(parentInfo);
      MultiSourceTreeNode parentNode = (MultiSourceTreeNode)GetNodeFromPath(parentTreePath);
      if (parentNode != null)
        return parentNode;
      else
        return GetFirstExistingParentNode(parentInfo);
    }

    private void VerifyNode(MultiSourceTreeNode node)
    {
      if (node == null) return;
      List<NodeInfo> unmatchedEntries = new List<NodeInfo>();
      foreach (NodeInfo entry in node.InfoEntries)
        if (!entry.NodeType.HasChildren(entry))
          unmatchedEntries.Add(entry);

      foreach (NodeInfo entry in unmatchedEntries)
      {
        //Output.Write(OutputTypes.Debug, " - Removing entry '" + entry.NodeType.GetType() + "' from node (has no children at this path)");
        RemoveNodeInfo(entry);
      }
    }

    private delegate MultiSourceTreeNode NodeMethodDelegate();
    private MultiSourceTreeNode UpdateNode(NodeInfo info)
    {
      if (InvokeRequired)
        return (MultiSourceTreeNode)(Invoke((NodeMethodDelegate)delegate { return UpdateNode(info); }));

      //Output.Write(OutputTypes.Debug, "Updating Node (" + info.NodeType.GetType() + "): " + info.Identifier);

      string treePath = info.NodeType.GetTreePath(info);
      if (treePath == "") return null;
      MultiSourceTreeNode node = (MultiSourceTreeNode)GetNodeFromPath(treePath);
      if (node != null)
      {
        //Output.Write(OutputTypes.Debug, "Found node in the tree.");
        // Add Node Info to node.
        //Output.Write(OutputTypes.Debug, "Adding info entry.");
        if (!node.ContainsEntry(info))
          node.AddInfoEntry(info);
        //else
          //Output.Write(OutputTypes.Debug, " - (Already contained)");
        info.ParentSource.UpdateNode(node);

        // Recursively update the parent nodes.
        NodeInfo parentInfo = info.NodeType.GetParentNodeInfo(info);
        if (parentInfo != null)
          if (parentInfo.Identifier != "")
          {
            //Output.Write(OutputTypes.Debug, "Updating parent node.");
            UpdateNode(parentInfo);
          }

        return node;
      }
      else
      {
        //Output.Write(OutputTypes.Debug, "The node does not exist in the tree.");
        NodeInfo parentInfo = info.NodeType.GetParentNodeInfo(info);
        MultiSourceTreeNode parentNode;
        if (parentInfo.Identifier != "")
        {
          //Output.Write(OutputTypes.Debug, "Updating parent node.");
          parentNode = UpdateNode(parentInfo);
        }
        else
        {
          // We've reached the root node, and the item does not exist.
          string parentTreePath = parentInfo.NodeType.GetTreePath(parentInfo);
          parentNode = (MultiSourceTreeNode)GetNodeFromPath(parentTreePath);
        }

        if (parentNode != null)
          if (parentNode.ChildrenAdded)
          {
            //Output.Write(OutputTypes.Debug, "Parent node exists and its children have been added.");
            // Create the node.
            string nodeName = info.NodeType.GetNodeName(info.Identifier);
            node = info.ParentSource.CreateNode(nodeName, info, info.NodeType.HasChildren);
            //Output.Write(OutputTypes.Debug, "Manually add the new node (" + node.Text + ") to " + parentNode.Text + ".");
            AddChildNodes(parentNode, new MultiSourceTreeNode[] { node });
            return node;
          }
        return parentNode;
      }
    }

    /// <summary>
    /// Scrolls to the node that corresponds to the specified path.
    /// </summary>
    public void ScrollToNode(string path)
    {
      if (path == null) return;

      TreeNode node;
      if (path == "")
        node = Nodes[0];
      else
        node = GetNodeFromPath(Nodes[0], path);

      if (node != null)
      {
        SelectedNode = node;
        node.EnsureVisible();
      }
    }
    #endregion

    #region Protected Internally-Used Methods
    /// <summary>
    /// Sets up the tree and adds the first level of nodes.
    /// </summary>
    protected void InitializeTree()
    {
      BeginUpdate();
      Nodes.Clear();

      foreach (NodeHierarchy hierarchy in hierarchies)
      {
        MultiSourceTreeNode rootNode = new MultiSourceTreeNode(hierarchy.RootNodeText);
        rootNode.CollapsedImageIndex = hierarchy.RootNodeImageIndex;
        rootNode.ExpandedImageIndex = hierarchy.RootNodeImageIndex;

        foreach (NodeSource source in hierarchy.NodeSources)
        {
          NodeInfo[] rootInfos = source.CreateRootNodeInfo();
          rootNode.AddInfoEntries(rootInfos);
          source.UpdateNode(rootNode);
          foreach (NodeInfo info in rootInfos)
            AddChildNodes(rootNode, info.BuildChildNodes());
        }
        Nodes.Add(rootNode);
        rootNode.Expand();
      }
      SelectedNode = Nodes[0];
      EndUpdate();
    }

    /// <summary>
    /// Updates the context menu to reflect the MenuDefinitions related to all NodeTypes
    /// associated with the specified nodes.
    /// </summary>
    protected void UpdateContextMenu(MultiSourceTreeNode node)
    {
      if (node != null)
        UpdateContextMenu(new MultiSourceTreeNode[] { node });
    }

    private ButtonItem popupMenu;
    protected void UpdateContextMenu(MultiSourceTreeNode[] nodes)
    {
      cmbPopupMenu.BeginInit();
      
      // Clear the existing menu items, killing their tooltip in the process - otherwise
      // there would be a dangling reference and they would never go out of scope.
      foreach (BaseItem item in popupMenu.SubItems)
        tooltip.SetSuperTooltip(item, null);
      popupMenu.SubItems.Clear();

      // We need some nodez biatches!
      if (nodes.Length == 0) return;

      Dictionary<MenuGroup, Dictionary<string, ButtonItem>> items = new Dictionary<MenuGroup, Dictionary<string, ButtonItem>>();

      // Get a sorted list of groups and their child items.
      foreach (MultiSourceTreeNode node in nodes)
        foreach (NodeInfo info in node.InfoEntries)
          foreach (NodeStateSubscriber subscriber in info.Subscriptions)
          {
            if (!subscriber.Active)
              continue;
            // Copy the menu definitions to a temp array so they can be sorted.
            MenuDefinition[] defs = new MenuDefinition[subscriber.State.MenuDefinitions.Count];
            subscriber.State.MenuDefinitions.Keys.CopyTo(defs, 0);
            Array.Sort(defs, new MenuDefinitionComparer());
            
            foreach (MenuDefinition def in defs)
            {
              // If we have a test, run it to see if this item should be added.
              if (def.MenuItemTest != null)
                if (!def.MenuItemTest.Invoke(node, info)) continue; // Nope!

              // Get the group container.
              Dictionary<string, ButtonItem> container;
              if (!items.ContainsKey(def.Group))
                items.Add(def.Group, new Dictionary<string, ButtonItem>());
              container = items[def.Group];

              // Create and add the menu item.
              ButtonItem menuItem = def.CreateMenuItem(node, tooltip);
              menuItem.Tag = info;
              // TODO: This will need to be adjusted to the plural text somehow
              // if more than one node is selected that contains this type.
              if (!container.ContainsKey(def.Text))
                container.Add(def.Text, menuItem);
            }
          }

      // Return if we had no groups to display.
      if (items.Count == 0) return;

      // Now that we have all of our groups, we need to sort them by priority.
      List<ButtonItemGroup> sortedGroups = new List<ButtonItemGroup>();
      while (items.Count > 0)
      {
        MenuGroup priorityGroup = null;
        foreach (MenuGroup group in items.Keys)
        {
          if (priorityGroup == null)
            priorityGroup = group;
          else
            if (group.SortingPriority > priorityGroup.SortingPriority)
            {
              priorityGroup = group;
            }
        }
        ButtonItem[] buttonItems = new ButtonItem[items[priorityGroup].Values.Count];
        items[priorityGroup].Values.CopyTo(buttonItems, 0);

        ButtonItemGroup newGroup = new ButtonItemGroup();
        newGroup.Group = priorityGroup;
        newGroup.Items = buttonItems;
        sortedGroups.Add(newGroup);
        items.Remove(priorityGroup);
      }
      
      // And now we can construct the actual popup menu! YAY!
      foreach (ButtonItemGroup group in sortedGroups)
      {
        LabelItem groupLabel = group.Group.CreateLabelItem();
        popupMenu.SubItems.Add(groupLabel);
        popupMenu.SubItems.AddRange(group.Items);
      }

      // Final pass - remove incorrect grouping.
      for (int x = 0; x < popupMenu.SubItems.Count; x++)
      {
        if (x == 0)
          popupMenu.SubItems[x].BeginGroup = false;
        else
        {
          if (!(popupMenu.SubItems[x-1] is ButtonItem))
            popupMenu.SubItems[x].BeginGroup = false;
        }
      }
      cmbPopupMenu.EndInit();
    }

    internal class ButtonItemGroup
    {
      public MenuGroup Group;
      public ButtonItem[] Items;
    }

    /// <summary>
    /// Creates the child nodes of the specified node.
    /// </summary>
    protected void CreateChildren(MultiSourceTreeNode node)
    {
      CreateChildren(node, false);
    }

    /// <summary>
    /// Creates the child nodes of the specified node.
    /// </summary>
    protected void CreateChildren(MultiSourceTreeNode node, bool updating)
    {
      if (!updating) node.Nodes.Clear();
      foreach (NodeInfo info in node.InfoEntries)
        AddChildNodes(node, info.BuildChildNodes());
    }

    /// <summary>
    /// Searches the TreeView for a node located at the specified path.
    /// </summary>
    protected TreeNode GetNodeFromPath(string path)
    {
      if (path == "")
        return null;
      string[] parts = path.Split('|');
      if (parts.Length < 2)
      {
        if (!path.EndsWith("|"))
          throw new Exception("Source path was in the wrong format: " + path + " (Must match 'source|path')");
        else
          path = "";
      }
      else
        path = parts[1];

      foreach (MultiSourceTreeNode node in Nodes)
        foreach (NodeInfo info in node.InfoEntries)
          if (info.ParentSource.Name == parts[0])
            if (path != "")
              return GetNodeFromPath(node, path);
            else
              return node;

      return null;
    }

    /// <summary>
    /// Searches the TreeView for a node located at the specified path,
    /// starting with the specified node.
    /// </summary>
    protected TreeNode GetNodeFromPath(TreeNode node, string path)
    {
      string[] parts = path.Trim('\\').Split('\\');

      foreach (TreeNode childNode in node.Nodes)
      {
        if (childNode.Text == parts[0])
        {
          if (parts.Length > 1)
            return GetNodeFromPath(childNode, path.Substring(path.IndexOf('\\') + 1));
          return childNode;
        }
      }
      return null;
    }

    /// <summary>
    /// Adds child nodes to a node, merging duplicates as neccessary.
    /// </summary>
    protected void AddChildNodes(MultiSourceTreeNode node, MultiSourceTreeNode[] childNodes)
    {

      foreach (MultiSourceTreeNode childNode in childNodes)
      {
        // Look for a Tree Node that contains the same name.
        MultiSourceTreeNode existingNode = null;
        foreach (MultiSourceTreeNode n in node.Nodes)
        {
          if (n.Text == childNode.Text)
          {
            existingNode = n;
            break;
          }
        }

        // If we found an existing node, just add this node's InfoEntry to it.
        // (if it doesn't already contain it).
        // Otherwise, add the node to the child nodes.
        if (existingNode != null)
        {
          existingNode.Checked = node.Checked;
          foreach (NodeInfo info in childNode.InfoEntries)
          {
            if (!existingNode.ContainsEntry(info))
            {
              existingNode.AddInfoEntry(info);
              // NOTE: We are assuming that the logic in this first NodeSource
              // will suffice when updating the node.
              // If this ever becomes a problem, we will need to take into
              // account the type priorities across multiple sources.
              // This would likely require us to setup an overall source
              // priority when it is added to the tree.
              existingNode.InfoEntries[0].ParentSource.UpdateNode(existingNode);
            }
          }
        }
        else
        {
          childNode.Checked = node.Checked;
          node.Nodes.Add(childNode);
        }
      }
      node.ChildrenAdded = true;
    }
    #endregion

    #region Event Handlers
    private int lastClickX, lastClickY;
    void MultiSourceTreeView_MouseDown(object sender, MouseEventArgs e)
    {
      ResetMouseIdleTimer();

      if (e.Button == MouseButtons.Left)
      {
        lastClickX = e.X;
        lastClickY = e.Y;
      }
      if (e.Button == MouseButtons.Right)
      {
        MultiSourceTreeNode node = GetNodeAt(e.X, e.Y) as MultiSourceTreeNode;
        if (node == null) return;

        if (SelectedNode != node)
        {
          if (SelectedNodes.Length < 2)
            SelectedNode = node;
        }

        MultiSourceTreeNode[] selectedNodes = new MultiSourceTreeNode[SelectedNodes.Length];
        for (int x = 0; x < SelectedNodes.Length; x++)
          selectedNodes[x] = (MultiSourceTreeNode)SelectedNodes[x];

        UpdateContextMenu(selectedNodes);
        if (popupMenu.SubItems.Count > 0)
          popupMenu.Popup(MousePosition);
      }
    }
    void MultiSourceTreeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      //MultiSourceTreeNode node = e.Node as MultiSourceTreeNode;
      //popupMenu = CreatePopupMenu(node, MenuTypes.RightClick);
    }
    private void MultiSourceTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      // If this node's child nodes have not already been created and added, do so now.
      MultiSourceTreeNode node = e.Node as MultiSourceTreeNode;
      if (node != null)
        if (!node.ChildrenAdded)
          CreateChildren(node);
    }
    #endregion

    #region Custom Painting
    void MultiSourceTreeView_Paint(object sender, PaintEventArgs e)
    {
      if (DesignMode) return;
      if (Nodes.Count < 1)
      {
        // If we have text for when the tree is empty, and it is at least 50
        // pixels wide, draw the string onto it.
        if ((treeEmptyText != "") && (Width > 50))
        {
          int pad = 6;
          int imagePad = 15;

          // Draw the text.
          int textWidth = Width - (pad * 2);
          e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
          SizeF s = e.Graphics.MeasureString(treeEmptyText, treeEmptyTextFont, textWidth);
          float x = (Width - s.Width) / 2;
          float y = (((Height - s.Height) + (treeEmptyIcon.Height + imagePad) / 2) / 2);
          using (Brush fontBrush = new SolidBrush(Color.FromArgb(treeEmptyAlpha, treeEmptyTextColor)))
          {
            RectangleF area = new RectangleF(x, y, s.Width, s.Height);
            StringFormat f = new StringFormat();
            f.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(treeEmptyText, treeEmptyTextFont, fontBrush, area, f);
          }

          // Draw the icon, if it present.
          if (treeEmptyIcon != null)
          {
            int imageX = (Width - treeEmptyIcon.Width) / 2;
            int imageY = (int)y - (treeEmptyIcon.Height + imagePad);

            ColorMatrix matrix = new ColorMatrix();
            matrix.Matrix00 = 1.0f;
            matrix.Matrix11 = 1.0f;
            matrix.Matrix22 = 1.0f;
            matrix.Matrix33 = (float)treeEmptyAlpha / 255;
            matrix.Matrix44 = 1.0f;

            ImageAttributes att = new ImageAttributes();
            att.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            e.Graphics.DrawImage(treeEmptyIcon, new Rectangle(imageX - 1, imageY - 1, treeEmptyIcon.Width, treeEmptyIcon.Height),
              0, 0, treeEmptyIcon.Width, treeEmptyIcon.Height, GraphicsUnit.Pixel, att);
          }
        }
      }
    }
    #endregion

    /// <summary>
    /// Gets the very last node in this tree's hierarchy.
    /// </summary>
    public MultiSourceTreeNode GetLastNode()
    {
      return GetLastChild((MultiSourceTreeNode)Nodes[Nodes.Count - 1]);
    }

    protected MultiSourceTreeNode GetLastChild(MultiSourceTreeNode node)
    {
      if ((node.Nodes.Count == 0) || (!node.ChildrenAdded))
        return node;

      MultiSourceTreeNode lastChild = (MultiSourceTreeNode)node.Nodes[node.Nodes.Count - 1];
      return GetLastChild(lastChild);
    }

    [DllImport("user32.dll")]
    static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    static extern int GetWindowLong(IntPtr hWnd, int nIndex);
    
    const int TVS_NOTOOLTIPS = 0x80;
    const int GWL_STYLE = -16;
  }

  /// <summary>
  /// A list of possible sorting modes for a MultiSourceTreeView.
  /// </summary>
  public enum SortMode
  {
    NodeSource,
    Alphabetical
  }

  public class MenuDefinitionComparer : IComparer<MenuDefinition>
  {
    ///<summary>
    ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
    ///</summary>
    public int Compare(MenuDefinition x, MenuDefinition y)
    {
      return (x.Priority - y.Priority);
    }
  }
}