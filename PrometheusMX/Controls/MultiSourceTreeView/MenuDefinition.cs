using System;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Prometheus.Controls
{
  public delegate void NodeMenuClickHandler(MultiSourceTreeNode node, NodeInfo info);
  public delegate bool NodeMenuItemTest(MultiSourceTreeNode node, NodeInfo info);

  /// <summary>
  /// Represents a menu item that will be contained within a MultiSourceTreeView's dynamically built popup menu.
  /// </summary>
  public class MenuDefinition
  {
    private Bitmap icon;
    private string text;
    private MultiSourceTreeNode node;
    private bool beginGroup = false;
    private NodeMenuItemTest menuItemTest;
    private ButtonItem menuItem = null;
    private NodeMenuClickHandler clickHandler;
    private string pluralText = "";
    private string toolTipText = "";
    private MenuGroup group;
    private int priority;
    private TooltipGenerator dynamicTooltipCallback;

    /// <summary>
    /// Gets or sets the menu group that this definition belongs to.
    /// </summary>
    public MenuGroup Group
    {
      get { return group; }
      set { group = value; }
    }

    /// <summary>
    /// Gets or sets the text that will be displayed in this MenuDefinition's tooltip.
    /// </summary>
    public string ToolTipText
    {
      get { return toolTipText; }
      set { toolTipText = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating if this item is the beginning of a group.
    /// </summary>
    public bool BeginGroup
    {
      get { return beginGroup; }
      set { beginGroup = value; }
    }

    /// <summary>
    /// Gets or sets the icon that will be used for this menu definition.
    /// </summary>
    public Bitmap Icon
    {
      get { return icon; }
      set { icon = value; }
    }

    /// <summary>
    /// Gets or sets the text that the menu definition will display.
    /// </summary>
    public string Text
    {
      get { return text; }
      set { text = value; }
    }

    /// <summary>
    /// Gets or sets the text that the menu definition will display when multiple nodes containing
    /// this definition have been selected.
    /// </summary>
    public string PluralText
    {
      get
      {
        if (pluralText == "")
          return text;
        else
          return pluralText;
      }
      set
      {
        if (value != null)
          pluralText = value;
        else
          pluralText = "";
      }
    }

    /// <summary>
    /// Gets or sets the sorting priority of this item.
    /// </summary>
    public int Priority
    {
      get { return priority; }
      set { priority = value; }
    }

    /// <summary>
    /// Gets or sets a callback method used to generate this item's tooltip.
    /// </summary>
    public TooltipGenerator DynamicTooltipCallback
    {
      get { return dynamicTooltipCallback; }
      set { dynamicTooltipCallback = value; }
    }

    /// <summary>
    /// Gets or sets the method will will be used to determine if this menu definition
    /// should be displayed for a given node.
    /// </summary>
    public NodeMenuItemTest MenuItemTest
    {
      get { return menuItemTest; }
      set { menuItemTest = value; }
    }

    /// <summary>
    /// Gets or sets the method that will handle clicks on this menu definition.
    /// </summary>
    public NodeMenuClickHandler ClickHandler
    {
      get { return clickHandler; }
      set { clickHandler = value; }
    }

    public event NodeMenuClickHandler MenuClicked;

    public MenuDefinition(MenuGroup group, string text, NodeMenuClickHandler clickHandler)
    {
      this.group = group;
      this.text = text;
      this.clickHandler = clickHandler;
      if (clickHandler != null) MenuClicked += clickHandler;
    }

    public ButtonItem CreateMenuItem(MultiSourceTreeNode node, SuperTooltip tooltip)
    {
      this.node = node;
      menuItem = new ButtonItem();
      menuItem.Text = Text;
      menuItem.BeginGroup = BeginGroup;
      menuItem.Image = Icon;

      // Generate the tooltip text and setup the SuperTooltip link.
      string tooltipText = "";
      if (dynamicTooltipCallback != null)
        tooltipText = dynamicTooltipCallback.Invoke(node, node.InfoEntries[0]);
      else if (toolTipText != "")
        tooltipText = toolTipText;

      if (!String.IsNullOrEmpty(tooltipText))
        tooltip.SetSuperTooltip(menuItem, new SuperTooltipInfo(menuItem.Text.Replace("&", ""), "", tooltipText, null, null, eTooltipColor.System, true, false, new Size(1, 1)));

      menuItem.Click += new EventHandler(MenuClickHandler);
      return menuItem;
    }

    public void OnMenuClicked(MultiSourceTreeNode node, NodeInfo info)
    {
      if (MenuClicked != null)
        MenuClicked(node, info);
    }

    void MenuClickHandler(object sender, EventArgs e)
    {
      OnMenuClicked(node, menuItem.Tag as NodeInfo);
    }
  }

  public delegate string TooltipGenerator(MultiSourceTreeNode node, NodeInfo info);

  public enum MenuItemSnap
  {
    Top,
    Bottom,
    None
  }

  /// <summary>
  /// Adds grouping capabilities to ToolStripItems.
  /// </summary>
  public class EnhancedToolStripMenuItem : ToolStripMenuItem
  {
    private bool beginGroup = false;

    /// <summary>
    /// Specifies whether this item is the beginning of a group.
    /// </summary>
    public bool BeginGroup
    {
      get { return beginGroup; }
      set { beginGroup = value; }
    }

    public EnhancedToolStripMenuItem() { ; }
    public EnhancedToolStripMenuItem(string text, Image image, EventHandler onClick) : base(text, image, onClick) { ; }
    public EnhancedToolStripMenuItem(string text, Image image, EventHandler onClick, string name) : base(text, image, onClick, name) { ; }
  }
}