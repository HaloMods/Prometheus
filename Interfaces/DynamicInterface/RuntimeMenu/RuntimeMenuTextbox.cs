using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public class RuntimeMenuTextbox : RuntimeMenuObject
  {
    private string value;
    private EventHandler valueChanged;

    public static implicit operator TextBoxItem(RuntimeMenuTextbox description)
    {
      TextBoxItem textbox = new TextBoxItem(description.Name.Replace(" ", ""), description.Name);
      textbox.Tooltip = description.ToolTip;
      textbox.TextBox.Text = description.value;

      if (description.valueChanged != null)
        textbox.TextBox.TextChanged += description.valueChanged;

      return textbox;
    }

    public RuntimeMenuTextbox(string name, string tooltip, bool beginsGroup, EventHandler valueChanged, string value)
      : base(name, RuntimeMenuType.TextBox, tooltip, null, beginsGroup)
    {
      this.value = value;
      this.valueChanged = valueChanged;
    }
  }
}
