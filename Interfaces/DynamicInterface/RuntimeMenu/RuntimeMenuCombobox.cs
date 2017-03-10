using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public class RuntimeMenuCombobox : RuntimeMenuObject
  {
    private string[] values;
    private EventHandler valueChanged;

    public static implicit operator ComboBoxItem(RuntimeMenuCombobox description)
    {
      ComboBoxItem combobox = new ComboBoxItem(description.Name.Replace(" ", ""), description.Name);
      combobox.Tooltip = description.ToolTip;
      combobox.Items.AddRange(description.values);

      if (description.valueChanged != null)
        combobox.ComboBoxEx.SelectedValueChanged += description.valueChanged;

      return combobox;
    }

    public RuntimeMenuCombobox(string name, string tooltip, bool beginsGroup, EventHandler valueChanged, params string[] values)
      : base(name, RuntimeMenuType.ComboBox, tooltip, null, beginsGroup)
    {
      this.values = values;
      this.valueChanged = valueChanged;
    }
  }
}
