using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using Core;
using Prometheus.Controls;
using TreeViewDragDrop;

namespace Prometheus.Controls
{
  /// <summary>
  /// Extends the TreeView class to to allow for icons from resources with
  /// corrected alpha, and alternate icons for selected nodes, and selective
  /// checkboxes per-node.
  /// </summary>
  [Designer("System.Windows.Forms.Design.TreeViewDesigner, System.Design, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"),
  DefaultPropertyAttribute("Nodes"), DefaultEventAttribute("AfterSelect")]
  public class BetterTreeView : Prometheus.ThirdParty.Controls.VistaTreeView
  {
    protected TreeNode lastNode;
    protected TreeNode firstNode;
    protected Bitmap internalBitmap;
    protected Graphics internalGraphics = null;

    // Drag and Drop members.
    private TreeNode dragNode = null;
    private TreeNode tempDropNode = null;
    private ImageList imageListDrag = new ImageList();
    private bool moveNodesOnDragDrop = true;

    // Multi-Select members.
    private List<TreeNode> selectedNodes = new List<TreeNode>();

    public TreeNode[] SelectedNodes
    {
      get
      {
        List<TreeNode> selectedNodes = new List<TreeNode>(this.selectedNodes);
        if (SelectedNode != null)
          if (!selectedNodes.Contains(SelectedNode))
            selectedNodes.Add(SelectedNode);
        return selectedNodes.ToArray();
      }
    }

    /// <summary>
    /// Indicates that a node has been dropped onto another node in the TreeView.
    /// </summary>
    protected event EventHandler<NodeDroppedEventArgs> NodeDropped;

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int wMsg,
                                      int wParam, int lParam);

    /// <summary>
    /// Gets or sets a value indicating whether nodes should be moved by the control
    /// on the DragDrop event.   If this is set to false, it will be up to the consumer
    /// of the NodeDropped event to handle the node moves.
    /// </summary>
    public bool MoveNodesOnDragDrop
    {
      get { return moveNodesOnDragDrop; }
      set { moveNodesOnDragDrop = value; }
    }

    #region Constructor
    public BetterTreeView()
    {
      // Setup internal event handlers
      AllowDrop = true;
      BeforeExpand += new TreeViewCancelEventHandler(BetterTreeView_BeforeExpand);
      BeforeCollapse += new TreeViewCancelEventHandler(BetterTreeView_BeforeCollapse);
      DrawNode += new DrawTreeNodeEventHandler(BetterTreeView_DrawNode);
      DrawMode = TreeViewDrawMode.OwnerDrawAll;
      CheckBoxes = true;
      AfterCheck += new TreeViewEventHandler(BetterTreeView_AfterCheck);

      ItemDrag += new ItemDragEventHandler(BetterTreeView_ItemDrag);
      DragOver += new DragEventHandler(BetterTreeView_DragOver);
      DragDrop += new DragEventHandler(BetterTreeView_DragDrop);
      DragEnter += new DragEventHandler(BetterTreeView_DragEnter);
      DragLeave += new EventHandler(BetterTreeView_DragLeave);
      GiveFeedback += new GiveFeedbackEventHandler(BetterTreeView_GiveFeedback);
    }

    /// Explictly implement this virtual property.
    public sealed override bool AllowDrop
    {
      get { return base.AllowDrop; }
      set { base.AllowDrop = value; }
    }

    #region Drag and Drop Event Handlers
    private void DragScroll()
    {
      // Set a constant to define the autoscroll region
      const Single scrollRegion = 20;

      // See where the cursor is at
      Point pt = PointToClient(Cursor.Position);

      // See if we need to scroll up or down
      if ((pt.Y + scrollRegion) > Height)
      {
        SendMessage(Handle, 277, 1, 0); // Call the API to scroll down
        Refresh();
      }
      else if (pt.Y < (Top + scrollRegion))
      {
        SendMessage(Handle, 277, 0, 0); // Call thje API to scroll up
        Refresh();
      }
    }

    private void BetterTreeView_ItemDrag(object sender, ItemDragEventArgs e)
    {
      // Get mouse position in client coordinates
      Point p = PointToClient(MousePosition);

      // Get drag node and select it
      dragNode = (BetterTreeNode)e.Item;
      SelectedNode = dragNode;

      // Create the Graphics object from the node being dragged.
      Bitmap bmp = new Bitmap(dragNode.Bounds.Width + Indent, dragNode.Bounds.Height);
      Graphics gfx = Graphics.FromImage(bmp);

      // Draw node icon into the bitmap
      gfx.DrawImage(ImageList.Images[dragNode.ImageIndex], 0, 0);

      // Draw node label into bitmap
      gfx.DrawString(dragNode.Text, Font, new SolidBrush(ForeColor), 18f, 1f);

      int dragImageWidth = dragNode.Bounds.Size.Width + Indent;
      if (dragImageWidth > 256) dragImageWidth = 256;

      imageListDrag = Helpers.GenerateImageList(new Bitmap[] { bmp },
        dragImageWidth, dragNode.Bounds.Height);

      // Compute delta between mouse position and node bounds
      int dx = p.X + Indent - dragNode.Bounds.Left - Location.X;
      int dy = p.Y - dragNode.Bounds.Top - Location.Y;

      // Begin dragging image
      if (DragHelper.ImageList_BeginDrag(imageListDrag.Handle, 0, dx, dy))
      {
        // Begin dragging
        DoDragDrop(bmp, DragDropEffects.Move);
        // End dragging image
        DragHelper.ImageList_EndDrag();
      }
    }

    public event EventHandler<DragOverNodeEventArgs> DragOverNode;

    private void BetterTreeView_DragOver(object sender, DragEventArgs e)
    {
      DragScroll();

      // Compute drag position and move image
      Point formP = PointToClient(new Point(e.X, e.Y));
      DragHelper.ImageList_DragMove(formP.X - Left, formP.Y - Top);

      // Get actual drop node
      TreeNode dropNode = GetNodeAt(PointToClient(new Point(e.X, e.Y)));

      // Make sure we have a node.
      if (dropNode == null)
      {
        e.Effect = DragDropEffects.None;
        return;
      }

      if (tempDropNode != dropNode)
      {
        DragHelper.ImageList_DragShowNolock(false);
        SelectedNode = dropNode;
        DragHelper.ImageList_DragShowNolock(true);
        tempDropNode = dropNode;
      }

      // Make sure that we aren't dropping onto a child node.
      TreeNode tmpNode = dropNode;
      while (tmpNode.Parent != null)
      {
        if (tmpNode.Parent == dragNode)
        {
          e.Effect = DragDropEffects.None;
          return;
        }
        tmpNode = tmpNode.Parent;
      }

      // Allow any event handlers a chance to cancel the drag/drop.
      DragOverNodeEventArgs args = new DragOverNodeEventArgs(dragNode, dropNode);
      if (DragOverNode != null)
        DragOverNode(this, args);
      if (args.Cancel)
      {
        e.Effect = DragDropEffects.None;
        return;
      }

      e.Effect = DragDropEffects.All;
    }
    private void BetterTreeView_DragDrop(object sender, DragEventArgs e)
    {
      // Unlock updates
      DragHelper.ImageList_DragLeave(Handle);

      // Get drop node
      TreeNode dropNode = GetNodeAt(PointToClient(new Point(e.X, e.Y)));

      // Manually move the nodes if we are handling that internally.
      if (MoveNodesOnDragDrop)
      {
        if (dragNode != dropNode)
        {
          // Remove drag node from parent
          if (dragNode.Parent == null)
            Nodes.Remove(dragNode);
          else
            dragNode.Parent.Nodes.Remove(dragNode);

          // Add drag node to drop node
          dropNode.Nodes.Add(dragNode);
          dropNode.ExpandAll();
        }
      }

      if (NodeDropped != null)
        NodeDropped(this, new NodeDroppedEventArgs(dragNode, dropNode));

      dragNode = null;
    }
    private void BetterTreeView_DragEnter(object sender, DragEventArgs e)
    {
      DragHelper.ImageList_DragEnter(Handle, e.X - Left,
        e.Y - Top);
    }
    private void BetterTreeView_DragLeave(object sender, EventArgs e)
    {
      DragHelper.ImageList_DragLeave(Handle);
    }
    private void BetterTreeView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
    {
      if (e.Effect == DragDropEffects.Move)
      {
        // Show pointer cursor while dragging
        e.UseDefaultCursors = false;
        Cursor = Cursors.Default;
      }
      else e.UseDefaultCursors = true;

    }
    #endregion

    private TreeNode firstSelectedNode;
    #region Multi-Select Implementation
    protected override void OnBeforeSelect(TreeViewCancelEventArgs e)
    {
      bool isControlPressed = (ModifierKeys == Keys.Control);
      bool isShiftPressed = (ModifierKeys == Keys.Shift);

      // selecting twice the node while pressing CTRL ?
      if (isControlPressed && selectedNodes.Contains(e.Node))
      {
        // unselect it
        // (let framework know we don't want selection this time)
        e.Cancel = true;

        // update nodes
        UnHighlightNodes();
        selectedNodes.Remove(e.Node);
        HighlightNodes();
        return;
      }

      if (!isShiftPressed) firstSelectedNode = e.Node; // store begin of shift sequence
      base.OnBeforeSelect(e);
    }

    protected override void OnAfterSelect(TreeViewEventArgs e)
    {
      bool isControlPressed = (ModifierKeys == Keys.Control);
      bool isShiftPressed = (ModifierKeys == Keys.Shift);

      if (isControlPressed)
      {
        // Add the selected node (if it is not already contained)
        if (!selectedNodes.Contains(e.Node))
          selectedNodes.Add(e.Node);
        else
        {
          if (e.Node is BetterTreeNode)
            ((BetterTreeNode)e.Node).UnHighlight();
          selectedNodes.Remove(e.Node);
        }
        HighlightNodes();
      }
      else
      {
        if (isShiftPressed)
        {
          Queue<TreeNode> nodeQueue = new Queue<TreeNode>();

          TreeNode uppernode = firstSelectedNode;
          TreeNode bottomnode = e.Node;

          // case 1 : begin and end nodes are parent
          bool bParent = IsParent(firstSelectedNode, e.Node);
          if (!bParent)
          {
            bParent = IsParent(bottomnode, uppernode);
            if (bParent) // swap nodes
            {
              TreeNode t = uppernode;
              uppernode = bottomnode;
              bottomnode = t;
            }
          }
          if (bParent)
          {
            TreeNode n = bottomnode;
            while (n != uppernode.Parent)
            {
              if (!selectedNodes.Contains(n)) // new node ?
                nodeQueue.Enqueue(n);

              n = n.Parent;
            }
          }
          // case 2 : nor the begin nor the
          // end node are descendant one another
          else
          {
            // are they siblings ?                 

            if ((uppernode.Parent == null && bottomnode.Parent == null)
                  || (uppernode.Parent != null &&
                  uppernode.Parent.Nodes.Contains(bottomnode)))
            {
              int nIndexUpper = uppernode.Index;
              int nIndexBottom = bottomnode.Index;
              if (nIndexBottom < nIndexUpper) // reversed?
              {
                TreeNode t = uppernode;
                uppernode = bottomnode;
                bottomnode = t;
                nIndexUpper = uppernode.Index;
                nIndexBottom = bottomnode.Index;
              }

              TreeNode n = uppernode;
              while (nIndexUpper <= nIndexBottom)
              {
                if (!selectedNodes.Contains(n)) // new node ?
                  nodeQueue.Enqueue(n);

                n = n.NextNode;

                nIndexUpper++;
              } // end while

            }
            else
            {
              if (!selectedNodes.Contains(uppernode))
                nodeQueue.Enqueue(uppernode);
              if (!selectedNodes.Contains(bottomnode))
                nodeQueue.Enqueue(bottomnode);
            }

          }

          selectedNodes.AddRange(nodeQueue);

          HighlightNodes();
          // let us chain several SHIFTs if we like it
          firstSelectedNode = e.Node;

        }
        else
        {
          // in the case of a simple click, just add this item
          if (selectedNodes != null && selectedNodes.Count > 0)
          {
            UnHighlightNodes();
            selectedNodes.Clear();
          }
          selectedNodes.Add(e.Node);
        }
      }
      base.OnAfterSelect(e);
    }

    protected void HighlightNodes()
    {
      foreach (TreeNode node in selectedNodes)
        if (node is BetterTreeNode)
          (node as BetterTreeNode).Highlight();
    }

    protected void UnHighlightNodes()
    {
      foreach (TreeNode node in selectedNodes)
        if (node is BetterTreeNode)
          (node as BetterTreeNode).UnHighlight();
    }
    #endregion

    void BetterTreeView_AfterCheck(object sender, TreeViewEventArgs e)
    {
      foreach (TreeNode node in e.Node.Nodes)
      {
        if (node is BetterTreeNode)
        {
          BetterTreeNode childNode = node as BetterTreeNode;
          if (childNode.ShowCheckbox)
            childNode.Checked = e.Node.Checked;
        }
      }
    }

    void BetterTreeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
    {
      e.DrawDefault = true;
      if (e.Node is BetterTreeNode)
      {
        BetterTreeNode node = (BetterTreeNode)e.Node;
        if (node.DirtyState)
        {
          if (!node.ShowCheckbox)
            HideCheckBox(node);
          node.DirtyState = false;
        }
      }
    }

    /// <summary>
    /// Hides the checkbox for the specified node.
    /// Note: The checkbox will return if the node's "Checked" property is set, either
    /// directly in code, or indirectly via the spacebar shortcut key.
    /// </summary>
    private void HideCheckBox(TreeNode node)
    {
      Win32.TVITEM tvItem = new Win32.TVITEM();
      tvItem.hItem = node.Handle;
      tvItem.mask = Win32.TVIF_STATE;
      tvItem.stateMask = Win32.TVIS_STATEIMAGEMASK;
      tvItem.state = 0;
      IntPtr lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvItem));
      Marshal.StructureToPtr(tvItem, lparam, false);
      Win32.SendMessage(Handle, Win32.TVM_SETITEM, IntPtr.Zero, lparam);
      Marshal.FreeHGlobal(lparam);
    }
    #endregion

    [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
    protected override void WndProc(ref Message message)
    {
      const int WM_PAINT = 0x000F;
      const int WM_PRINTCLIENT = 0x0318;
      const int WM_ERASEBKGND = 0x0014;
      const int WM_KEYDOWN = 0x100;

      switch (message.Msg)
      {
        case WM_KEYDOWN:
          if ((int)message.WParam == 32) // Space
          {
            // See if our current node allows checkboxes.
            BetterTreeNode node = SelectedNode as BetterTreeNode;
            if (node != null)
              if (!node.ShowCheckbox)
                return;
          }
          break;

        case WM_ERASEBKGND:
          // Removes flicker.
          return;

        case WM_PAINT:
          // The designer host does not call OnResize().                  
          if (internalGraphics == null)
            OnResize(EventArgs.Empty);

          // Set up 
          Win32.RECT updateRect = new Win32.RECT();
          if (Win32.GetUpdateRect(message.HWnd, ref updateRect, false) == 0)
            break;

          Win32.PAINTSTRUCT paintStruct = new Win32.PAINTSTRUCT();
          IntPtr screenHdc = Win32.BeginPaint(message.HWnd, ref paintStruct);
          using (Graphics screenGraphics = Graphics.FromHdc(screenHdc))
          {

            // Draw Internal Graphics.
            IntPtr hdc = internalGraphics.GetHdc();
            Message printClientMessage = Message.Create(Handle, WM_PRINTCLIENT, hdc, IntPtr.Zero);
            DefWndProc(ref printClientMessage);
            internalGraphics.ReleaseHdc(hdc);

            // Add the missing OnPaint() call.
            OnPaint(new PaintEventArgs(internalGraphics, Rectangle.FromLTRB(
                updateRect.left,
                updateRect.top,
                updateRect.right,
                updateRect.bottom)));

            // Draw Screen Graphics.
            screenGraphics.DrawImage(internalBitmap, 0, 0);
          }
          Win32.EndPaint(message.HWnd, ref paintStruct);
          return;
      }
      base.WndProc(ref message);
    }

    protected override void OnResize(EventArgs e)
    {
      if (internalBitmap == null ||
          internalBitmap.Width != Width || internalBitmap.Height != Height)
      {

        if (Width > 0 && Height > 0)
        {
          DisposeInternal();
          internalBitmap = new Bitmap(Width, Height);
          internalGraphics = Graphics.FromImage(internalBitmap);
        }
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        GC.SuppressFinalize(this);

      // Dispose unmanaged resources.
      DisposeInternal();

      base.Dispose(disposing);
    }

    protected internal void DisposeInternal()
    {
      if (internalGraphics != null)
        internalGraphics.Dispose();
      if (internalBitmap != null)
        internalBitmap.Dispose();
    }

    protected bool IsParent(TreeNode parentNode, TreeNode childNode)
    {
      while (childNode.Parent != null)
      {
        if (childNode.Parent == parentNode) return true;
        childNode = childNode.Parent;
      }
      return false;
    }



    [EditorBrowsableAttribute(EditorBrowsableState.Always), BrowsableAttribute(true)]
    public new event PaintEventHandler Paint
    {
      add { base.Paint += value; }
      remove { base.Paint -= value; }
    }

    #region Event Handlers
    /// <summary>
    /// Updates the Node's icon to reflect the expanded state.
    /// </summary>
    void BetterTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node is BetterTreeNode)
      {
        BetterTreeNode n = (BetterTreeNode)e.Node;
        n.ImageIndex = n.ExpandedImageIndex;
        n.SelectedImageIndex = n.ExpandedImageIndex;
      }
    }

    /// <summary>
    /// Updates the Node's icon to reflect the collapsed state.
    /// </summary>
    private void BetterTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
    {
      if (e.Node is BetterTreeNode)
      {
        BetterTreeNode n = (BetterTreeNode)e.Node;
        n.ImageIndex = n.CollapsedImageIndex;
        n.SelectedImageIndex = n.CollapsedImageIndex;
      }
    }
    #endregion
  }

  /// <summary>
  /// Provides data for an event indicating that a node was dropped onto
  /// another node in a treeview.
  /// </summary>
  public class NodeDroppedEventArgs : EventArgs
  {
    private TreeNode node;
    private TreeNode targetNode;

    public TreeNode Node
    {
      get { return node; }
    }

    public TreeNode TargetNode
    {
      get { return targetNode; }
    }

    public NodeDroppedEventArgs(TreeNode node, TreeNode targetNode)
    {
      this.node = node;
      this.targetNode = targetNode;
    }
  }

  /// <summary>
  /// Provides data for an event indicating that a node has been dragged over another node.
  /// </summary>
  public class DragOverNodeEventArgs : NodeDroppedEventArgs
  {
    private bool cancel = false;

    public bool Cancel
    {
      get { return cancel; }
      set
      {
        // Once this has been set to true, it can't be set back to false.
        // That way, if multiple objects subscribe to the DragOverNode event, then if any
        // of them set to cancel, no other objects can reverse the cancellation.
        if (value)
          cancel = value;
      }
    }

    public DragOverNodeEventArgs(TreeNode node, TreeNode targetNode)
      : base(node, targetNode) { ; }
  }

  #region Interop
  /// <summary>
  /// Win32 PInvoke declarations
  /// </summary>
  internal class Win32
  {
    public const int TVIF_STATE = 0x8;
    public const int TVIS_STATEIMAGEMASK = 0xF000;
    public const int TV_FIRST = 0x1100;
    public const int TVM_SETITEM = TV_FIRST + 63;
    public struct TVITEM
    {
      public int mask;
      public IntPtr hItem;
      public int state;
      public int stateMask;
      [MarshalAs(UnmanagedType.LPTStr)]
      public String lpszText;
      public int cchTextMax;
      public int iImage;
      public int iSelectedImage;
      public int cChildren;
      public IntPtr lParam;
    }

    public const int WM_USER = 0x0400;
    public const int WM_REFLECT = WM_USER + 0x1C00;
    public const int WM_NOTIFY = 0x004E;
    public const int TVM_HITTEST = TV_FIRST + 17;
    public const int NM_DBLCLK = (-3);

    [StructLayout(LayoutKind.Sequential)]
    public struct NMHDR
    {
      public IntPtr hwndFrom;
      public UIntPtr idFrom;
      public int code;
    }

    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    [DllImport("User32.dll")]
    public static extern int GetUpdateRect(IntPtr hwnd, ref RECT rect, bool erase);

    [DllImport("User32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr handle, ref RECT rect);

    [DllImport("User32.dll")]
    public static extern IntPtr BeginPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);

    [DllImport("User32.dll")]
    public static extern bool EndPaint(IntPtr hWnd, ref PAINTSTRUCT paintStruct);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
      public int left;
      public int top;
      public int right;
      public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
      public IntPtr hdc;
      public int fErase;
      public RECT rcPaint;
      public int fRestore;
      public int fIncUpdate;
      public int Reserved1;
      public int Reserved2;
      public int Reserved3;
      public int Reserved4;
      public int Reserved5;
      public int Reserved6;
      public int Reserved7;
      public int Reserved8;
    }
  }
  #endregion
}