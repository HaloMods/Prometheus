using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace Prometheus.Controls.TagEditor
{
  public class LayoutValues
  {
    public int headerCaptionLineHeight;
    public int padding = 5;
    public int footerHeight = 19;
    public int linkPadding = 0;
    //public int 

    public int blockControlHeight = 26;
    public int headerBaseHeight;
    public int moreInfoTextHeight;
    public int moreInfoPadding = 5;
    public int controlAreaHeight;

    public int fullCaptionHeight = 0;
  }

  public class FieldContainerLayout : LayoutEngine
  {
    public FieldContainerLayout() : base() { ; }

    protected SizeF MeasureCaptionString(string s, Font f, int maxWidth, Graphics g)
    {
      int maxTextWidth = maxWidth - 10;
      g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
      return g.MeasureString(s, f, maxTextWidth);
    }

    public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
    {
      if (!(container is FieldContainerBase))
        return true;
      FieldContainerBase @this = (FieldContainerBase)container;
      using (Graphics g = @this.CreateGraphics())
      {
        if (@this.Width < FieldListLayout.BlockWidth)
          @this.Width = FieldListLayout.BlockWidth + (@this.Globals.DepthDifference * (@this.Margin.Left * 2)) - 1;

        // Calculate the header line height.
        SizeF s = MeasureCaptionString("A", @this.Font, 800, g);
        @this.LayoutValues.headerCaptionLineHeight = (int)s.Height;

        // Calculate the base header height.
        SizeF headerTextSize = MeasureCaptionString(@this.ContainerName, @this.Font, @this.Width, g);
        @this.LayoutValues.headerBaseHeight = (int)headerTextSize.Height + (@this.LayoutValues.padding * 2);

        //bool noDescription = String.IsNullOrEmpty(@this.LongDescription) && string.IsNullOrEmpty(@this.ShortDescription);
        string descriptionText = "";
        // Calculate the MoreInfo text height.
        if ((!String.IsNullOrEmpty(@this.LongDescription)) && (@this.ShowingLongDescription))
        {
          SizeF moreInfoTextSize = MeasureCaptionString(@this.LongDescription, @this.LongDescriptionFont, @this.Width - (@this.LayoutValues.padding * 2) - (@this.LayoutValues.moreInfoPadding * 2), g);
          @this.LayoutValues.moreInfoTextHeight = (int)moreInfoTextSize.Height; //+ @this.LayoutValues.moreInfoPadding + @this.LayoutValues.padding * 2;
          descriptionText = @this.LongDescription;
          @this.LayoutValues.headerBaseHeight += @this.LayoutValues.moreInfoTextHeight + (@this.LayoutValues.padding);
        }
        else if (!String.IsNullOrEmpty(@this.ShortDescription))
        {
          SizeF moreInfoTextSize = MeasureCaptionString(@this.ShortDescription, @this.ShortDescriptionFont, @this.Width - (@this.LayoutValues.padding * 2) - (@this.LayoutValues.moreInfoPadding * 2), g);
          @this.LayoutValues.moreInfoTextHeight = (int)moreInfoTextSize.Height; //+ //@this.LayoutValues.moreInfoPadding + @this.LayoutValues.padding * 2;
          descriptionText = @this.ShortDescription;
          @this.LayoutValues.headerBaseHeight += @this.LayoutValues.moreInfoTextHeight + (@this.LayoutValues.padding);
        }
        else
        {
          @this.LayoutValues.moreInfoTextHeight = 0;
        }

        // Calculate full caption height.
        int fullCaptionHeight = @this.LayoutValues.headerBaseHeight + 1;
        int descriptionLocation = (int)headerTextSize.Height + 5;
        //fullCaptionHeight += @this.LayoutValues.moreInfoTextHeight;
        Control lblMoreInfo = null;
        DevComponents.DotNetBar.LabelX lblWarning = null;
        DevComponents.DotNetBar.LabelX lblDescription = null;
        Control btnCollapse = null;
        for (int x = 0; x < @this.Controls.Count; x++)
        {
          if (@this.Controls[x].Name == "lblMoreInfo")
          {
            // Calculate MoreInfo link position and text.
//            @this.Controls[x].Text = moreInfoLinkTet(@this);
            int linkPadding = ((@this.LayoutValues.headerCaptionLineHeight + @this.LayoutValues.padding * 2) - @this.Controls[x].Height) / 2 + 1;
            @this.Controls[x].Location = new Point((int)headerTextSize.Width + @this.LayoutValues.padding, linkPadding);
            lblMoreInfo = @this.Controls[x];
            lblMoreInfo.Visible = !String.IsNullOrEmpty(@this.LongDescription);
            lblMoreInfo.Margin = new Padding(0, 0, 0, 0);
          }
          else if (@this.Controls[x].Name == "btnCollapse")
          {
            btnCollapse = @this.Controls[x];
            // Calculate the ToggleButton position.
            int toggleButtonPadding = ((@this.LayoutValues.headerCaptionLineHeight + @this.LayoutValues.padding * 2) - @this.Controls[x].Height) / 2;
            @this.Controls[x].Location = new Point((@this.Width - @this.Controls[x].Width) - toggleButtonPadding, toggleButtonPadding);
            if (btnCollapse.Location.Y + btnCollapse.Height + @this.LayoutValues.padding > descriptionLocation)
              descriptionLocation = btnCollapse.Location.Y + btnCollapse.Height + @this.LayoutValues.padding;
          }
          else if (@this.Controls[x].Name == "lblWarning")
          {
            lblWarning = (DevComponents.DotNetBar.LabelX)@this.Controls[x];
          }
          else if (@this.Controls[x].Name == "lblDescription")
          {
            lblDescription = (DevComponents.DotNetBar.LabelX)@this.Controls[x];
          }
        }

        SizeF warningTextSize = new SizeF(0f, 0f);
        if (!String.IsNullOrEmpty(@this.Warning))
        {
          warningTextSize = MeasureCaptionString(@this.Warning, @this.WarningFont, (@this.Width - lblWarning.Location.X + 1), g);
          @this.LayoutValues.headerBaseHeight += (int)warningTextSize.Height + @this.LayoutValues.padding;
        }

        // Calculate the warning label position, taking into account its size.
        int warningLabelX = (int)headerTextSize.Width + 10;
        if (warningTextSize.Height > @this.LayoutValues.headerCaptionLineHeight) // we'll see how well this goes... :x
        {
          if (lblMoreInfo != null)
          {
            lblMoreInfo.Location = new Point(@this.LayoutValues.padding, (int)headerTextSize.Height + (@this.LayoutValues.padding * 2));
            if (descriptionLocation < lblMoreInfo.Location.Y + lblMoreInfo.Height + 5)
              descriptionLocation = lblMoreInfo.Location.Y + lblMoreInfo.Height + 5;
          }
        }
        else if (lblMoreInfo != null) if (lblMoreInfo.Visible)
          if (warningLabelX < lblMoreInfo.Location.X + lblMoreInfo.Width + 5)
            warningLabelX = lblMoreInfo.Location.X + lblMoreInfo.Width + 5;

        // setup the warning label
        if ((lblWarning != null) && (!String.IsNullOrEmpty(@this.Warning)))
        {
          lblWarning.Location = new Point(warningLabelX, @this.LayoutValues.padding);
          //lblWarning.Width = (btnCollapse.Location.X - lblWarning.Location.X) - 5;
          lblWarning.Height = (int)warningTextSize.Height + 2;
          lblWarning.MinimumSize = new Size((btnCollapse.Location.X - lblWarning.Location.X) - 5, 0);
          lblWarning.MaximumSize = new Size(lblWarning.MinimumSize.Width, 0);
          
          lblWarning.Visible = true;
          if (lblWarning.Location.Y + lblWarning.Height + (@this.LayoutValues.padding) > fullCaptionHeight)
            fullCaptionHeight = lblWarning.Location.Y + lblWarning.Height + (@this.LayoutValues.padding * 2);
          if (lblWarning.Location.Y + lblWarning.Height + 5 > descriptionLocation)
            descriptionLocation = lblWarning.Location.Y + lblWarning.Height + 5;
        }
        // Setup the description label
        if ((lblDescription != null) && (!String.IsNullOrEmpty(descriptionText)))
        {
          int locationY = descriptionLocation;

          lblDescription.Location = new Point(@this.LayoutValues.padding, locationY);
          lblDescription.MaximumSize = new Size(@this.Width - lblDescription.Location.X - @this.LayoutValues.padding, 0);
          lblDescription.Height = @this.LayoutValues.moreInfoTextHeight + 2;
          lblDescription.WordWrap = true;
          lblDescription.Visible = true;
          lblDescription.BringToFront();
          //lblDescription.Text = descriptionText;
        }

        #region figure out the header size
        System.Collections.Generic.List<int> lowestPoints = new System.Collections.Generic.List<int>();
        lowestPoints.Add((int)headerTextSize.Height + (@this.LayoutValues.padding * 2));
        if (lblMoreInfo != null)
          lowestPoints.Add(lblMoreInfo.Location.Y + lblMoreInfo.Height + lblMoreInfo.Location.Y);
        if (!String.IsNullOrEmpty(descriptionText))
          lowestPoints.Add(lblDescription.Location.Y + lblDescription.Height + @this.LayoutValues.padding);
        if (lblWarning != null)
          if (!String.IsNullOrEmpty(@this.Warning))
            lowestPoints.Add(lblWarning.Location.Y + lblWarning.Height + @this.LayoutValues.padding);
        int lowestPoint = lowestPoints[0];
        for (int x = 1; x < lowestPoints.Count; x++)
          if (lowestPoints[x] > lowestPoint)
            lowestPoint = lowestPoints[x];

        @this.LayoutValues.headerBaseHeight = lowestPoint;
        fullCaptionHeight = lowestPoint;
        #endregion

        //fullCaptionHeight += @this.LayoutValues.padding;
        //@this.LayoutValues.headerBaseHeight = fullCaptionHeight - 1;

        @this.Location = new Point(4, @this.Location.Y);

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
            @this.FieldPanel.Location = new Point(0, fullCaptionHeight + @this.LayoutValues.blockControlHeight + 2);
          }
          height += @this.LayoutValues.controlAreaHeight + 1;
          @this.Height = height;
        }

        @this.LayoutValues.fullCaptionHeight = fullCaptionHeight;
        // Redraw the control.
        //lblWarning.PerformLayout();
      }
      @this.Invalidate();
      return true;
    }
  }
}
