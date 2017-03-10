using System;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public static class RuntimeMenuBuilder
  {
    public static ItemContainer BuildMenu(params RuntimeMenuObject[] description)
    {
      ItemContainer container = new ItemContainer();

      for (int i = description.Length - 1; i >= 0; i--)
      {
        switch (description[i].Type)
        {
          case RuntimeMenuType.Button:
            container.SubItems.Add(description[i] as RuntimeMenuButton, 0);
            break;
          case RuntimeMenuType.CheckBox:
            container.SubItems.Add(description[i] as RuntimeMenuCheckbox, 0);
            break;
          case RuntimeMenuType.ComboBox:
            container.SubItems.Add(description[i] as RuntimeMenuCombobox, 0);
            break;
          case RuntimeMenuType.Label:
            container.SubItems.Add(description[i] as RuntimeMenuLabel, 0);
            break;
          case RuntimeMenuType.TextBox:
            container.SubItems.Add(description[i] as RuntimeMenuTextbox, 0);
            break;
        }
      }

      return container;
    }
  }
}
