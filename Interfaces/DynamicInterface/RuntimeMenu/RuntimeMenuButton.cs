using System;
using System.Drawing;
using DevComponents.DotNetBar;

namespace Interfaces.DynamicInterface.RuntimeMenu
{
  public class RuntimeMenuButton : RuntimeMenuObject
  {
    private EventHandler clicked;

    public static implicit operator ButtonItem(RuntimeMenuButton description)
    {
      ButtonItem button = new ButtonItem(description.Name.Replace(" ", ""), description.Name);
      button.Image = description.Image;
      button.Tooltip = description.ToolTip;

      if (description.clicked != null)
        button.Click += description.clicked;

      for (int i = description.children.Count - 1; i >= 0; i--)
      {
        switch (description.children[i].Type)
        {
          case RuntimeMenuType.Button:
            button.InsertItemAt(description.children[i] as RuntimeMenuButton, 0, true);
            break;
          case RuntimeMenuType.CheckBox:
            button.InsertItemAt(description.children[i] as RuntimeMenuCombobox, 0, true);
            break;
          case RuntimeMenuType.ComboBox:
            button.InsertItemAt(description.children[i] as RuntimeMenuCheckbox, 0, true);
            break;
          case RuntimeMenuType.Label:
            button.InsertItemAt(description.children[i] as RuntimeMenuLabel, 0, true);
            break;
          case RuntimeMenuType.TextBox:
            button.InsertItemAt(description.children[i] as RuntimeMenuTextbox, 0, true);
            break;
        }
      }

      return button;
    }

    public RuntimeMenuButton(string name, string tooltip, Image image, bool beginsGroup, EventHandler clicked)
      : base(name, RuntimeMenuType.Button, tooltip, image, beginsGroup)
    {
      this.clicked = clicked;
    }

    public virtual void AddChild(RuntimeMenuObject child)
    {
      children.Add(child);
    }

    public virtual void RemoveChild(RuntimeMenuObject child)
    {
      children.Remove(child);
    }
  }
}
