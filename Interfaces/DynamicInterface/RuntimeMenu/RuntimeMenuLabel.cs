using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public class RuntimeMenuLabel : RuntimeMenuObject
  {
    public static implicit operator LabelItem(RuntimeMenuLabel description)
    {
      LabelItem label = new LabelItem(description.Name.Replace(" ", ""), description.Name);
      label.Image = description.Image;
      label.Tooltip = description.ToolTip;
      return label;
    }

    public RuntimeMenuLabel(string name, string tooltip, Image image)
      : base(name, RuntimeMenuType.Label, tooltip, image, false)
    {
    }
  }
}
