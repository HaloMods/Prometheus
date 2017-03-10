using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Interfaces;
using Interfaces.Factory;
using Interfaces.TagEditor;
using Prometheus.Controls.TagEditor;
using DevComponents.DotNetBar.Rendering;

namespace Prometheus.Controls
{
  public partial class BlockContainer : FieldContainerBase
  {
    protected override void  UpdateTheme()
    {
      bool returnLayout = !LayoutSuspended;
      try
      {
        // Cancel layout updates so that we don't redraw an assload of times.
        SuspendLayout();

        RoundBorders = false;

        BorderColor = ColorTable.RibbonBar.Default.OuterBorder.Start;
        LightBorderColor = ColorTable.RibbonBar.Default.InnerBorder.Start;

        if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        {
          HeaderBackgroundColorStart = ColorTable.TabControl.Default.TopBackground.Start;
          HeaderBackgroundColorEnd = ColorTable.TabControl.Default.TopBackground.End;
          FooterBackgroundColorStart = ColorTable.RibbonControl.PanelBottomBackground.Start;
          FooterBackgroundColorEnd = ColorTable.RibbonBar.Default.TitleBackground.End;

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
          HeaderBackgroundColorStart = ColorTable.TabControl.Default.BottomBackground.End; //ColorTable.RibbonControl.PanelBottomBackground.Start;
          HeaderBackgroundColorEnd = ColorTable.RibbonBar.Default.TitleBackground.End;
          FooterBackgroundColorStart = ColorTable.RibbonControl.PanelBottomBackground.Start; // ColorTable.TabControl.Default.BottomBackground.End;
          FooterBackgroundColorEnd = ColorTable.TabControl.Default.BottomBackground.Start;

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
      }
    }
  }

  /*public class BlockContainerLayout : System.Windows.Forms.Layout.LayoutEngine
  {
    protected string moreInfoLinkText(BlockContainer @this)
    {
      if (@this.ShowingMoreInfo)
        return "Hide Info";
      else
        return "More Info";
      
    }

    protected SizeF MeasureCaptionString(string s, Font f, int maxWidth, Graphics g)
    {
      int maxTextWidth = maxWidth - 10;
      g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
      return g.MeasureString(s, f, maxTextWidth);
    }
    public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
    {
      if (!(container is BlockContainer))
        return true;
      BlockContainer @this = (BlockContainer)container;
      using (Graphics g = @this.CreateGraphics())
      {
        // Calculate the header line height.
        SizeF s = MeasureCaptionString("A", @this.Font, 800, g);
        @this.LayoutValues.headerCaptionLineHeight = (int)s.Height;

        // Calculate the base header height.
        SizeF headerTextSize = MeasureCaptionString(@this.HeaderCaption, @this.Font, @this.Width, g);
        @this.LayoutValues.headerBaseHeight = (int)headerTextSize.Height + (@this.LayoutValues.padding * 2);

        // Calculate the MoreInfo text height.
        if (!String.IsNullOrEmpty(@this.MoreInfoText))
        {
          SizeF moreInfoTextSize = MeasureCaptionString(@this.MoreInfoText, @this.MoreInfoFont, @this.Width - (@this.LayoutValues.padding * 2) - (@this.LayoutValues.moreInfoPadding * 2), g);
          @this.LayoutValues.moreInfoTextHeight = (int)moreInfoTextSize.Height + @this.LayoutValues.moreInfoPadding + @this.LayoutValues.padding * 2;
        }
        else
        {
          @this.LayoutValues.moreInfoTextHeight = 0;
        }

        // Calculate full caption height.
        int fullCaptionHeight = @this.LayoutValues.headerBaseHeight + 1;
        if (@this.ShowingMoreInfo) fullCaptionHeight += @this.LayoutValues.moreInfoTextHeight;

        for (int x = 0; x < @this.Controls.Count; x++)
        {
          if (@this.Controls[x].Name == "moreInfoLink")
          {
            // Calculate MoreInfo link position and text.
            @this.Controls[x].Text = moreInfoLinkText(@this);
            int linkPadding = ((@this.LayoutValues.headerCaptionLineHeight + @this.LayoutValues.padding * 2) - @this.Controls[x].Height) / 2 + 1;
            @this.Controls[x].Location = new Point((int)headerTextSize.Width + @this.LayoutValues.padding, linkPadding);
          }
          else if (@this.Controls[x].Name == "btnCollapse")
          {
            // Calculate the ToggleButton position.
            int toggleButtonPadding = ((@this.LayoutValues.headerCaptionLineHeight + @this.LayoutValues.padding * 2) - @this.Controls[x].Height) / 2;
            @this.Controls[x].Location = new Point((@this.Width - @this.Controls[x].Width) - toggleButtonPadding, toggleButtonPadding);
          }
        }

        if (@this.Block != null)
        {
          (@this.Block as Control).Location = new Point(1, fullCaptionHeight);
          (@this.Block as Control).BringToFront();
          @this.LayoutValues.blockControlHeight = (@this.Block as Control).Height + 2;
        }
        else
          @this.LayoutValues.blockControlHeight = 0;

        // Calculate the size of the control.
        if (@this.Collapsed)
          @this.Height = fullCaptionHeight + @this.LayoutValues.footerHeight;
        else
        {
          int height = fullCaptionHeight + @this.LayoutValues.blockControlHeight + @this.LayoutValues.footerHeight;
          if (@this.FieldPanel != null)
          {
            @this.LayoutValues.controlAreaHeight = @this.FieldPanel.Height + 1;
            @this.FieldPanel.Location = new Point(1, fullCaptionHeight + @this.LayoutValues.blockControlHeight + 2);
          }
          height += @this.LayoutValues.controlAreaHeight + 1;
          @this.Height = height;
        }

        // Redraw the control.
      }
      @this.Invalidate();
      return true;
    }
  }*/
}