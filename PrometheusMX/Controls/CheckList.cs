using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DNBRendering = DevComponents.DotNetBar.Rendering;
using DNBHelper = Interfaces.Helpers.DNB;
using Interfaces;

namespace Prometheus.Controls
{
  public partial class CheckList : UserControl
  {
    private DNBRendering.Office2007Renderer renderer = null;

    #region Properties

    private int itemCount = 0;
    [Browsable(false)]
    public int Count
    {
      get { return itemCount; }
    }

    private int maxWidth = 300;
    [DefaultValue(300)]
    public int MaximumWidth
    {
      get { return maxWidth; }
      set { maxWidth = value; }
    }

    private int widestItemWidth = 0;
    [Browsable(false)]
    private int WidestItemWidth
    {
      get { return widestItemWidth; }
      set
      {
        widestItemWidth = value;
        this.Size = new Size(value, this.Size.Height);
      }
    }

    private List<CheckListGroup> checkListGroups;
    [Browsable(false)]
    public List<CheckListGroup> CheckListGroups
    {
      get { return checkListGroups; }
    }

    #endregion

    public CheckList()
    {
      InitializeComponent();
      checkListGroups = new List<CheckListGroup>();

      if (DNBRendering.GlobalManager.Renderer is DNBRendering.Office2007Renderer)
      {
        renderer = DNBRendering.GlobalManager.Renderer as DNBRendering.Office2007Renderer;
        renderer.ColorTableChanged += new EventHandler(OnColorTableChanged);
      }
      
      ipCheckList.Items.Remove(icGroup);
    }

    #region Manipulation

    public void Clear()
    {
      ipCheckList.Items.Clear();
    }

    public int Add(CheckListItem item, string tooltip, string group)
    {
      this.stCheckList.SetSuperTooltip(item, new DevComponents.DotNetBar.SuperTooltipInfo(item.Text, "", tooltip, null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));

      CheckListGroup grp;

      if (!String.IsNullOrEmpty(group))
        grp = GroupReference(group);
      else
        grp = GroupReference("Default");

      /* // This is not needed right now because of 'this.GlobalItem = false' in the CheckListItem class.
       * // However, if we wish to allow syncing between CheckListItems with the same Name property in the future,
       * // this code will have to be used (and updated) to ensure plug-in designers know the consequences.
#if DEBUG // This has to be changed later to check for a "Testing" mode so that users creating plugins will get this information.
      if(!ipCheckList.Items.Contains(grp))
        ipCheckList.Items.Add(grp);

      // Make sure a CheckListItem with the same control name does not already exist; warn if one does.
      foreach (CheckListGroup existingGroup in checkListGroups)
      {
        if (existingGroup == null)
          continue;

        foreach (BaseItem bi in existingGroup.Items)
        {
          if (bi == null)
            continue;

          if (bi is CheckListItem)
          {
            CheckListItem cli = (CheckListItem)bi;

            if (item.Name.Equals(cli.Name))
            {
              Output.Write(OutputTypes.Debug, "CheckList item \"" + item.Text + "\" in group \"" + grp.Text + "\" has the same Name property as \"" + cli.Text
                           + "\" in group \"" + existingGroup.Text + "\".\nThis will cause potentially unwanted check syncing between the two controls. Changing the name is recommended.");
            }
          }
        }
      }
#endif
      */

      int returnValue = grp.Items.Add(item);

      if (returnValue > -1) // Make sure the item was added successfully.
        itemCount++;

      return returnValue;
    }

    public int Add(CheckListItem item)
    {
      return Add(item, String.Empty, String.Empty);
    }

    public int Add(string name, string text, bool isChecked, string tooltip, string group)
    {
      return Add(new CheckListItem(name, text, isChecked), tooltip, group);
    }

    public int Add(string text, bool isChecked, string tooltip, string group)
    {
      return Add(Convert.ToString(Count + 1), text, isChecked, tooltip, group);
    }

    public int Add(string text, string tooltip, string group)
    {
      return Add(text, false, tooltip, group);
    }

    public int Add(string name, string text, bool isChecked)
    {
      return Add(new CheckListItem(name, text, isChecked));
    }

    public int Add(string text, bool isChecked)
    {
      return Add(Convert.ToString(Count + 1), text, isChecked);
    }

    public int Add(string text)
    {
      return Add(text, false);
    }

    public void AddRange(object[] objects)
    {
      foreach (object obj in objects)
      {
        if (obj is CheckListItem)
          Add((obj as CheckListItem));
      }
    }

    private void ManipulateAllChecks(bool change, bool invert)
    {
      imgbCheckAll.Enabled = imgbInvertChecks.Enabled = imgbClearAll.Enabled = false;

      timerUpdate.Start();

      foreach (CheckListGroup group in checkListGroups)
      {
        if (group == null)
          continue;

        foreach (BaseItem item in group.Items)
        {
          if (item == null)
            continue;

          if (item is CheckListItem)
          {
            CheckListItem cli = (CheckListItem)item;

            cli.Checked = (invert ? !cli.Checked : change);
          }
        }
      }

      timerUpdate.Stop();

      panelProgress.Visible = false;
      imgbCheckAll.Enabled = imgbInvertChecks.Enabled = imgbClearAll.Enabled = true;
    }

    #endregion

    #region Information

    private CheckListGroup GroupReference(string group)
    {
      string groupAsLower = group.ToLower();

      foreach (CheckListGroup g in checkListGroups)
      {
        if (g == null)
          continue;

        if (g.Text.ToLower().Equals(groupAsLower))
          return g;
      }

      CheckListGroup grp = new CheckListGroup(group, checkListGroups.Count);
      checkListGroups.Add(grp);

      ipCheckList.Items.Add(grp);

      return grp;
    }

    #endregion

    #region UI Updates

    private void UpdateTheme()
    {
      DNBRendering.Office2007ColorTable ct = ((DNBRendering.Office2007Renderer)DNBRendering.GlobalManager.Renderer).ColorTable;
      ipCheckList.BackgroundStyle.BackColor = ct.Bar.PopupToolbarBackground.Start;

      ipCheckList.BackgroundStyle.BorderColor = ct.CheckBoxItem.Default.CheckBorder;

      if (ct.InitialColorScheme == DNBRendering.eOffice2007ColorScheme.Black)
        BackColor = ct.TabControl.Default.BottomBackground.End;
      else
        BackColor = ct.TabControl.Default.TopBackground.Start;

      foreach (CheckListGroup clg in checkListGroups)
      {
        clg.UpdateTheme();
      }
    }

    private int lastScrollVisibility = -1;
    private void UpdateGroupWidth(bool checkScrollVisibility)
    {
      if (!isLoaded) // If the control has not finished loading, we should not do any resizing.
        return;

      if (checkScrollVisibility)
        if (lastScrollVisibility != -1) // Make sure lastScrollVisibility has been set.
          if (ipCheckList.VerticalScroll.Visible == Convert.ToBoolean(lastScrollVisibility)) // Scrollbar visibility has not been updated.
            return;

      int modifier; // Adjustment value for width.

      if (ipCheckList.VerticalScroll.Visible)
        modifier = 20;
      else
        modifier = 4;

      Size newSize = new Size(ipCheckList.Size.Width - modifier, 0);

      foreach (BaseItem baseItem in ipCheckList.Items)
      {
        if (!(baseItem is ItemContainer))
          continue;

        ItemContainer ic = (baseItem as ItemContainer);

        if (ic.SubItems.Count != 2) // The outer group container will always only have 2 objects in its SubItems collection.
          continue;

        if (!ic.SubItems[0].Name.Equals("lblGroupLabel")) // Ensures that we are in the group container.
          continue;

        ic.MinimumSize = newSize;
        (ic.SubItems[0] as LabelItem).Width = newSize.Width;
      }

      if (checkScrollVisibility)
        lastScrollVisibility = ((ipCheckList.VerticalScroll.Visible) ? 1 : 0);
    }

    #endregion

    #region Events

    private bool isLoaded;
    private void CheckList_Load(object sender, EventArgs e)
    {
      isLoaded = true;

      UpdateGroupWidth(true);

      UpdateTheme();
    }

    protected virtual void OnColorTableChanged(object sender, EventArgs e)
    {
      UpdateTheme();
    }

    private void ipCheckList_ItemAdded(object sender, EventArgs e)
    {
      if (isLoaded)
        ipCheckList.Refresh();

      UpdateGroupWidth(false);
    }

    private void ipCheckList_Resize(object sender, EventArgs e)
    {
      UpdateGroupWidth(false);
    }

    private void imgbCheckAll_Click(object sender, EventArgs e)
    {
      ManipulateAllChecks(true, false);
    }

    private void imgbInvertChecks_Click(object sender, EventArgs e)
    {
      ManipulateAllChecks(false, true);
    }

    private void imgbClearAll_Click(object sender, EventArgs e)
    {
      ManipulateAllChecks(false, false);
    }

    private void timerUpdate_Tick(object sender, EventArgs e)
    {
      panelProgress.Visible = true;
    }

    private void panelProgress_VisibleChanged(object sender, EventArgs e)
    {
      if (panelProgress.Visible)
        busyIndicator.FadeIn();
      else
        busyIndicator.FadeOut();
    }

    #endregion
  }

  public sealed class CheckListItem : DevComponents.DotNetBar.CheckBoxItem
  {
    public CheckListItem(string name, string text, bool isChecked)
    {
      this.Name = name;
      this.Text = text;
      this.Checked = isChecked;
      this.GlobalItem = false; // Prevents syncing of CheckListItems with the same Name property.
    }

    public CheckListItem(string text, bool isChecked) : this(String.Empty, text, isChecked) { }
    public CheckListItem(string text) : this(String.Empty, text, false) { }
    public CheckListItem() : this(String.Empty, String.Empty, false) { }
  }

  public sealed class CheckListGroup : DevComponents.DotNetBar.ItemContainer
  {
    private ItemContainer ic;
    private LabelItem item;

    private int displayOrder = 0;
    public int DisplayOrder
    {
      get { return displayOrder; }
      set { displayOrder = value; }
    }

    public SubItemsCollection Items
    {
      get { return ic.SubItems; }
    }

    public CheckListGroup(string name, string text, int displayOrder)
    {
      Name = name;
      Text = text;
      DisplayOrder = displayOrder;
      LayoutOrientation = eOrientation.Vertical;
      MinimumSize = new Size(94, 0);

      ic = new ItemContainer();
      ic.LayoutOrientation = eOrientation.Vertical;
      CreateGroupLabel();
      SubItems.Add(ic);
      TextChanged += new EventHandler(CheckListGroup_TextChanged);
    }

    public CheckListGroup(string text, int displayOrder) : this(text, text, displayOrder) { }
    public CheckListGroup(string name, string text) : this(name, text, -1) { }
    public CheckListGroup(string text) : this(text, text, -1) { }
    public CheckListGroup() : this(String.Empty, String.Empty, -1) { }

    void CheckListGroup_TextChanged(object sender, EventArgs e)
    {
      item.Text = "<b>" + Text + "</b>";
    }

    private void CreateGroupLabel()
    {
      item = new LabelItem("lblGroupLabel", "<b>" + Text + "</b>");

      DNBHelper.Controls.ThemeMenuLabel(item); // Theme Support for Labels

      item.BorderType = eBorderType.SingleLine;
      item.BorderSide = eBorderSide.Bottom;
      item.PaddingTop = 1;
      item.PaddingLeft = 3;
      item.PaddingBottom = 1;
      item.WordWrap = true;

      SubItems.Add(item);
    }

    public void UpdateTheme()
    {
      foreach (BaseItem bi in SubItems)
        if (bi is LabelItem)
          DNBHelper.Controls.ThemeMenuLabel((LabelItem)bi);
    }

    private class GroupDisplayOrderComparer : IComparer
    {
      int IComparer.Compare(object x, object y)
      {
        if (x is CheckListGroup && y is CheckListGroup)
        {
          return ((CheckListGroup)x).DisplayOrder - ((CheckListGroup)y).DisplayOrder;
        }
        else
          return ((new CaseInsensitiveComparer()).Compare(x, y));
      }
    }
  }
}
