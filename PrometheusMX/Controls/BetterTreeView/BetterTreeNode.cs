using System.Drawing;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  /// <summary>
  /// Extends the TreeNode control to allow different icon indices (within an ImageList)
  /// for the Expanded and Collapsed states of the node, as well as a custom font.
  /// Per-node "ShowCheckbox" state is also supported.
  /// </summary>
  public class BetterTreeNode : TreeNode
  {
    private int expandedImageIndex;
    private int collapsedImageIndex;
    private Font font = new Font("Times New Roman", 8);
    private bool showCheckbox = false;
    private bool dirtyState = true;

    public int ExpandedImageIndex
    {
      get { return expandedImageIndex; }
      set
      {
        expandedImageIndex = value;
        UpdateImageIndex();
      }
    }

    public int CollapsedImageIndex
    {
      get { return collapsedImageIndex; }
      set
      {
        collapsedImageIndex = value;
        UpdateImageIndex();
      }
    }

    private void UpdateImageIndex()
    {
      if (IsExpanded)
      {
        SelectedImageIndex = expandedImageIndex;
        ImageIndex = expandedImageIndex;
      }
      else
      {
        SelectedImageIndex = collapsedImageIndex;
        ImageIndex = collapsedImageIndex;
      }
    }

    public Font Font
    {
      get { return font;}
      set { font = value;}
    }
    
    public bool ShowCheckbox
    {
      get { return showCheckbox; }
      set
      {
        dirtyState = true;
        showCheckbox = value;
      }
    }

    public bool DirtyState
    {
      get { return dirtyState; }
      set { dirtyState = value; }
    }

    #region BaseClassConstructors
    public BetterTreeNode() : base()
    {
       
    }
    public BetterTreeNode(string text) : base(text)
    {

    }
    public BetterTreeNode(string text, TreeNode[] children) : base(text, children)
    {
      ;
    }
    public BetterTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex)
    {
       ;
    }
    public BetterTreeNode(string text, int imageIndex, int selectedImageIndex, TreeNode[] children) : base(text, imageIndex, selectedImageIndex, children)
    {
       ;
    }
    #endregion

    private bool highlighted = false;
    private Color savedBackColor;
    private Color savedForeColor;
    public void Highlight()
    {
      if (highlighted) return;
      savedBackColor = BackColor;
      savedForeColor = ForeColor;
      BackColor = SystemColors.Highlight;
      ForeColor = SystemColors.HighlightText;
      highlighted = true;
    }
    public void UnHighlight()
    {
      if (!highlighted) return;
      BackColor = savedBackColor;
      ForeColor = savedForeColor;
      highlighted = false;
    }
  }
}