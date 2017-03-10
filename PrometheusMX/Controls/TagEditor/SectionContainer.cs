using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;
using Interfaces.TagEditor;
using Padding=System.Windows.Forms.Padding;

namespace Prometheus.Controls.TagEditor
{
  class SectionContainer : FieldContainerBase//ExpandablePanel, IFieldControlContainer
  {
    private BlockContainerPanel fieldContainerPanel
    {
      get { return base.FieldPanel; }
      set { base.FieldPanel = value; }
    }
    /*private string description;

    /// <summary>
    /// Gets or sets the title text of the Section panel.
    /// </summary>
    /*public string Title
    {
      get { return TitleText.Trim(' '); }
      set { TitleText = "   " + value.Trim(' '); }
    }

    /// <summary>
    /// Gets or sets the description text.
    /// </summary>
    public string Description
    {
      get { return description; }
      set { description = value; }
    }*/

    public SectionContainer()
    {
      Initialize();
      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
      if (lblMoreInfo != null)
        lblMoreInfo.Visible = false;
    }
    protected override void OnClick(EventArgs e)
    {
      // check to see if the cursor is in the header
      if (Cursor.Current.HotSpot.Y < LayoutValues.headerBaseHeight)
        btnCollapse.Toggled = !btnCollapse.Toggled;
    }
    protected override void UpdateTheme()
    {
      bool returnLayout = !LayoutSuspended;
      try
      {
        // Cancel layout updates so that we don't redraw an assload of times.
        SuspendLayout();

        BorderColor = ColorTable.RibbonBar.Default.OuterBorder.Start;
        LightBorderColor = ColorTable.RibbonBar.Default.InnerBorder.Start;

        if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        {
          HeaderBackgroundColorStart = ColorTable.RibbonBar.Default.TitleBackground.Start; //ColorTable.TabControl.Default.TopBackground.End;
          HeaderBackgroundColorEnd = ColorTable.RibbonBar.MouseOver.TitleBackground.Start; //ColorTable.TabControl.Default.TopBackground.Start;
          FooterBackgroundColorStart = ColorTable.DataGridView.ColumnHeaderMouseOverBackground.End; //ColorTable.TabControl.Default.TopBackground.End; //ColorTable.RibbonControl.PanelBottomBackground.Start;
          FooterBackgroundColorEnd = ColorTable.RibbonBar.MouseOver.TitleBackground.Start;

          if (FieldPanel != null)
          {
            FieldPanel.BackColor = ColorTable.TabControl.Default.TopBackground.Start;
            FieldPanel.ForeColor = ColorTable.TabControl.Default.TopBackground.Start;
          }

          BackColor = ColorTable.TabControl.Default.TopBackground.Start;
          ForeColor = ColorTable.TabControl.Default.Text;
        }
        else
        {
          HeaderBackgroundColorStart = ColorTable.RibbonBar.Default.TitleBackground.End; //ColorTable.TabControl.Default.BottomBackground.Start;
          FooterBackgroundColorStart = ColorTable.TabControl.Default.BottomBackground.End; //ColorTable.RibbonBar.Default.TitleBackground.Start;

          if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Blue)
          {
            HeaderBackgroundColorEnd = ColorTable.TabControl.Default.BottomBackground.Start;
            FooterBackgroundColorEnd = ColorTable.TabControl.Default.BottomBackground.Start;
          }
          else
          {
            HeaderBackgroundColorEnd = ColorTable.RibbonBar.MouseOver.TitleBackground.End; //ColorTable.TabControl.Default.BottomBackground.End;
            FooterBackgroundColorEnd = ColorTable.RibbonBar.Default.TitleBackground.End;
          }

          if (FieldPanel != null)
          {
            FieldPanel.BackColor = ColorTable.TabControl.Default.BottomBackground.End;
            FieldPanel.ForeColor = ColorTable.TabControl.Default.BottomBackground.End;
          }

          BackColor = ColorTable.TabControl.Default.BottomBackground.End;
          ForeColor = ColorTable.RibbonBar.Default.TitleText;
        }
      }
      finally
      {
        if (returnLayout)
          ResumeLayout();

        base.UpdateTheme();

        Invalidate(true);
      }
    }

    private void Initialize()
    {
      
    }
  }
}
