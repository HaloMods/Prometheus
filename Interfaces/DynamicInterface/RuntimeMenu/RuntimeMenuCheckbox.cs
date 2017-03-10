using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public class RuntimeMenuCheckbox : RuntimeMenuObject
  {
    private CheckBoxChangeEventHandler checkedChanged;

    public static implicit operator CheckBoxItem(RuntimeMenuCheckbox description)
    {
      CheckBoxItem checkbox = new CheckBoxItem(description.Name.Replace(" ", ""), description.Name);
      checkbox.Tooltip = description.ToolTip;

      if (description.checkedChanged != null)
        checkbox.CheckedChanged += description.checkedChanged;

      return checkbox;
    }

    public RuntimeMenuCheckbox(string name, string tooltip, bool beginsGroup, CheckBoxChangeEventHandler checkedChanged)
      : base(name, RuntimeMenuType.CheckBox, tooltip, null, beginsGroup)
    {
      this.checkedChanged = checkedChanged;
    }
  }
}
