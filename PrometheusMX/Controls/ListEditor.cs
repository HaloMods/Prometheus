using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  public partial class ListEditor : UserControl
  {
    private string itemType = "Item",
                   newItemText = "[New Item]";

    private bool dirty = false,
                 doNotTakeFocus = false;

    private int initialEntryCount = 0;

    #region Properties

    public string ItemType
    {
      get { return itemType; }
      set
      {
        itemType = value;
        newItemText = "[New " + value + "]";
        ProcessTooltips();
      }
    }

    public Image UpdateImage
    {
      get
      { return imgbUpdate.Image; }
      set
      { imgbUpdate.Image = new Bitmap(value); }
    }

    public Image AddItemImage
    {
      get
      { return imgbAdd.Image; }
      set
      { imgbAdd.Image = new Bitmap(value); }
    }

    public Image DeleteItemImage
    {
      get
      { return imgbDelete.Image; }
      set
      { imgbDelete.Image = new Bitmap(value); }
    }

    public Image MoveUpImage
    {
      get
      { return imgbMoveUp.Image; }
      set
      { imgbMoveUp.Image = new Bitmap(value); }
    }

    public Image MoveDownImage
    {
      get
      { return imgbMoveDown.Image; }
      set
      { imgbMoveDown.Image = new Bitmap(value); }
    }

    public bool ShowMoveButtons
    {
      get
      { return (imgbMoveUp.Visible); }
      set
      {
        imgbMoveUp.Visible = value;
        imgbMoveDown.Visible = value;
      }
    }

    [Browsable(false)]
    public ListBox.ObjectCollection Items
    {
      get
      {
        RemoveExcessNewItem(false);

        return lbList.Items;
      }
      set
      {
        dirty = false;
        lbList.Items.Clear();
        txtbxDataEntry.Clear();

        lbList.Items.AddRange(value);
        initialEntryCount = lbList.Items.Count;

        imgbAdd_Click(null, EventArgs.Empty);
      }
    }

    [Browsable(false)]
    public List<string> StringItems
    {
      get
      {
        RemoveExcessNewItem(false);

        List<string> temp = new List<string>();

        foreach (object obj in lbList.Items)
        {
          temp.Add(obj.ToString());
        }

        return temp;
      }
      set
      {
        dirty = false;
        lbList.Items.Clear();
        txtbxDataEntry.Clear();

        foreach (string str in value) { lbList.Items.Add(str); }
        initialEntryCount = lbList.Items.Count;

        imgbAdd_Click(null, EventArgs.Empty);
      }
    }

    [Browsable(false)]
    public bool Dirty
    {
      get { return dirty; }
      set { dirty = value; }
    }

    [Browsable(false)]
    public int InitialEntryCount
    {
      get { return initialEntryCount; }
    }

    #endregion

    public ListEditor()
    {
      InitializeComponent();
      ProcessTooltips();
    }

    private void ProcessTooltips()
    {
      this.stListEditor.SetSuperTooltip(this.imgbUpdate, new DevComponents.DotNetBar.SuperTooltipInfo("Sync " + itemType, "", "Sync changes with selection from the list.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      this.stListEditor.SetSuperTooltip(this.imgbAdd, new DevComponents.DotNetBar.SuperTooltipInfo("Add " + itemType, "", "Add to the list.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      this.stListEditor.SetSuperTooltip(this.imgbDelete, new DevComponents.DotNetBar.SuperTooltipInfo("Delete " + itemType, "", "Remove selection from the list.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      this.stListEditor.SetSuperTooltip(this.imgbMoveUp, new DevComponents.DotNetBar.SuperTooltipInfo("Move " + itemType + " Up", "", "Move selection towards the top of the list.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      this.stListEditor.SetSuperTooltip(this.imgbMoveDown, new DevComponents.DotNetBar.SuperTooltipInfo("Move " + itemType + " Down", "", "Move selection towards the bottom of the list.", null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
    }

    private void RemoveExcessNewItem(bool compareSelectedIndex)
    {
      int newLoc = lbList.Items.IndexOf(newItemText);

      if (compareSelectedIndex)
      {
        if (newLoc > -1 && lbList.SelectedIndex != newLoc) // newItemText exists in the collection and is not currently selected.
          lbList.Items.RemoveAt(newLoc);
      }
      else
      {
        if (newLoc > -1) // newItemText exists in the collection.
          lbList.Items.RemoveAt(newLoc);
      }
    }

    private void txtbxDataEntry_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Return)
      {
        imgbUpdate_Click(null, EventArgs.Empty);
        e.Handled = true;
      }
    }

    private void txtbxDataEntry_TextChanged(object sender, EventArgs e)
    {
      if (!String.IsNullOrEmpty(txtbxDataEntry.Text))
        imgbUpdate.Enabled = true;
      else
        imgbUpdate.Enabled = false;
    }

    private void imgbUpdate_Click(object sender, EventArgs e)
    {
      if(!imgbUpdate.Enabled)
        return;

      if (!lbList.Items.Contains(txtbxDataEntry.Text))
      {
        if (lbList.SelectedIndex > -1)
        {
          int index = lbList.SelectedIndex;

          lbList.Items.Insert(index, txtbxDataEntry.Text);
          lbList.Items.RemoveAt(index + 1);
          lbList.SelectedIndex = index;

          dirty = true;

          imgbAdd_Click(null, EventArgs.Empty);
        }
      }
    }

    private void imgbAdd_Click(object sender, EventArgs e)
    {
      int newLoc = lbList.Items.IndexOf(newItemText);

      if (newLoc == -1) // newItemText does not exist in the collection.
      {
        lbList.Items.Add(newItemText);
        lbList.SelectedIndex = lbList.Items.IndexOf(newItemText);
      }
      else
        imgbUpdate_Click(sender, e);
    }

    private void imgbDelete_Click(object sender, EventArgs e)
    {
      int index = lbList.SelectedIndex;

      if (index > -1)
      {
        lbList.Items.RemoveAt(lbList.SelectedIndex);
        dirty = true;
        doNotTakeFocus = true;

        if (lbList.Items.Count > 0)
        {
          if (index > 0)
            lbList.SelectedIndex = index - 1;
          else
            lbList.SelectedIndex = index;
        }

        txtbxDataEntry.SelectAll();
      }

      if (lbList.Items.Count == 0)
      {
        doNotTakeFocus = false;
        imgbAdd_Click(null, EventArgs.Empty);
      }
    }

    private void imgbMoveUp_Click(object sender, EventArgs e)
    {
      if (lbList.SelectedIndex - 1 > -1)
      {
        object item = lbList.SelectedItem;
        int index = lbList.SelectedIndex;

        lbList.Items.RemoveAt(index);
        doNotTakeFocus = true;
        lbList.Items.Insert(index - 1, item);
        lbList.SelectedIndex = index - 1;
        txtbxDataEntry.SelectAll();

        dirty = true;
      }
    }

    private void imgbMoveDown_Click(object sender, EventArgs e)
    {
      if (lbList.SelectedIndex + 1 < lbList.Items.Count)
      {
        object item = lbList.SelectedItem;
        int index = lbList.SelectedIndex;

        lbList.Items.RemoveAt(index);
        doNotTakeFocus = true;
        lbList.Items.Insert(index + 1, item);
        lbList.SelectedIndex = index + 1;
        txtbxDataEntry.SelectAll();

        dirty = true;
      }
    }

    private void lbList_SelectedIndexChanged(object sender, EventArgs e)
    {
      RemoveExcessNewItem(true);

      if (lbList.SelectedIndex > -1)
      {
        txtbxDataEntry.Text = lbList.SelectedItem.ToString();

        if (!doNotTakeFocus)
        {
          txtbxDataEntry.Focus();
          txtbxDataEntry.SelectAll();
        }
        else
          doNotTakeFocus = false;
      }
      else
        txtbxDataEntry.Clear();
    }
  }
}
