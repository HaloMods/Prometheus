using System.Drawing;
using DevComponents.DotNetBar;
using DNBRendering = DevComponents.DotNetBar.Rendering;
using DNBHelper = Interfaces.Helpers.DNB;

namespace Prometheus.Controls
{
  /// <summary>
  /// Represents a group that contains MenuDefinition objects.
  /// </summary>
  public class MenuGroup
  {
    private string text;
    private int sortingPriority;
    private Bitmap image;

    /// <summary>
    /// Gets or sets the text that will be displayed for this group in the popup menu.
    /// </summary>
    public string Text
    {
      get { return text; }
      set { text = value; }
    }

    /// <summary>
    /// Gets or sets a value indicating the priority that this group will receive when determining
    /// group order in the popup menu.
    /// </summary>
    public int SortingPriority
    {
      get { return sortingPriority; }
      set { sortingPriority = value; }
    }

    /// <summary>
    /// Gets or sets the icon image that will be used for this group in the popup menu.
    /// </summary>
    public Bitmap Image
    {
      get { return image; }
      set { image = value; }
    }

    public MenuGroup(string text, int sortingPriority) : this(text, sortingPriority, null) { ; }

    public MenuGroup(string text, int sortingPriority, Bitmap image)
    {
      this.text = text;
      this.sortingPriority = sortingPriority;
      this.image = image;
    }

    /// <summary>
    /// Creates a LabelItem control to represent this group.
    /// </summary>
    public LabelItem CreateLabelItem()
    {
      LabelItem item = new LabelItem();

      item.AutoCollapseOnClick = false;

      DNBHelper.Controls.ThemeMenuLabel(item); // Theme Support for Labels

      item.BorderType = eBorderType.SingleLine;
      item.BorderSide = eBorderSide.Bottom;
      item.PaddingTop = 1;
      item.PaddingLeft = 7;
      item.PaddingBottom = 1;

      item.Text = text;
      if (image != null)
        item.Image = image;

      return item;
    }
  }
}