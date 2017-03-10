using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

namespace Interfaces.Helpers.DNB
{
  public static class Controls
  {
    public static Office2007ColorTable ColorTable
    {
      get
      {
        return ((Office2007Renderer)GlobalManager.Renderer).ColorTable;
      }
    }

    public static void ThemeMenuLabel(LabelItem label)
    {
      if (GlobalManager.Renderer is Office2007Renderer)
      {
        label.BackColor = ColorTable.Gallery.GroupLabelBackground;
        label.ForeColor = ColorTable.Gallery.GroupLabelText;
        label.SingleLineColor = ColorTable.Gallery.GroupLabelBorder;
      }
      else
      {
        label.BackColor = Color.FromArgb(221, 231, 238);
        label.ForeColor = Color.FromArgb(0, 21, 110);
        label.SingleLineColor = Color.FromArgb(197, 197, 197);
      }
    }

    /// <summary>
    /// Iterates through a given SubItemsCollection, switching all controls Enabled properties to the given state.
    /// </summary>
    /// <param name="subItems">The SubItemsCollection to be iterated over and have its controls updated according to the provided state.</param>
    /// <param name="state">The state all Enabled properties should be changed to.</param>
    public static void ToggleContainerItems(SubItemsCollection subItems, bool state)
    {
      foreach (BaseItem item in subItems)
      {
        if (item is ItemContainer)
        {
          if (item.SubItems.Count > 0)
            ToggleContainerItems(item.SubItems, state); // Disable all controls contained in item.
        }
        else
        {
          item.Enabled = state;
        }

        /* //Coded incase the code in else throws errors later.
        else if (item is ButtonItem)
        {
          item.Enabled = state;
        }
        else if (item is LabelItem)
        {
          item.Enabled = state;
        }
        else if (item is TextBoxItem)
        {
          item.Enabled = state;
        }
        else if (item is ComboBoxItem)
        {
          item.Enabled = state;
        }
        else if (item is CheckBoxItem)
        {
          item.Enabled = state;
        }
        else if (item is ProgressBarItem)
        {
          item.Enabled = state;
        }
        else if (item is SliderItem)
        {
          item.Enabled = state;
        }
        else if (item is ColorItem)
        {
          item.Enabled = state;
        } */
      }
    }
  }
}
