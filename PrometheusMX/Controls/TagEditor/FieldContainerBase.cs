using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Rendering;

using Interfaces.Factory;
using Interfaces.TagEditor;
using Prometheus.Controls;
using Prometheus.Controls.TagEditor;
//using Prometheus.Controls.TagEditor;

namespace Prometheus.Controls.TagEditor
{
  public enum Corners : int
  { 
    None = 0,
    Left = 1, Top = 2, Right = 4, Bottom = 8, 
    TopLeft = Top | Left, TopRight = Top | Right, BottomLeft = Bottom | Left, BottomRight = Bottom | Right, All = Top | Left | Bottom | Right 
  }
  public abstract class FieldContainerBase : Control, IFieldControlContainer, IBoundPropertyCapable, IDynamicContainer
  {
    private const string ShowMoreURI = "show";
    private const string ShowLessURI = "hide";

    //protected const string ShowMoreInfoString = "<b><a href=\"" + ShowMoreURI + "\">More Info</a></b>";
    //protected const string ShowLessInfoString = "<b><a href=\"" + ShowLessURI + "\">Less Info</a></b>";
    protected const string MoreInfoDisabledString = "<b><font color=\"gray\">More Info</font></b>";

    public event EventHandler OnCollapsing;
    public event EventHandler OnCollapsed;
    public event EventHandler OnExpanding;
    public event EventHandler OnExpanded;
    public event MarkupLinkClickEventHandler MoreInfoClicked;

    #region Members
    #region Appearance
    protected Office2007Renderer renderer;

    private bool showHeader = true;
    private bool showFooter = true;
    //private bool showCollapseButton = true;
    private bool roundBorders = false;

    private int _cornerWidth = 16;
    private int _cornerHeight = 16;

    #region Colors
    private Color borderColor;
    private Color footerBackColorEnd;
    private Color footerBackColorStart;
    private Color headerBackColorEnd;
    private Color headerBackColorStart;
    private Color lightBorderColor;
    private Color backgroundColor;

    private Color warningBorderColor;
    private Color warningBackColor;
    #endregion

    #region Fonts
    //private Font nameFont;
    private Font shortDescFont;
    private Font longDescFont;
    private Font warningFont;
    private Font moreInfoFont;
    private Font footerFont;
    #endregion
    #endregion

    #region Behavior
    private bool doLayout = true;
    private bool showingLongDesc = false;
    private LayoutValues layoutValues = new LayoutValues();
    #endregion

    #region Controls
    protected LabelX lblMoreInfo;
    protected LabelX lblDescription;
    protected LabelX lblWarning;
    protected ToggleButton btnCollapse;
    BlockContainerPanel fieldPanel;
    IBlockControl blockControl;
    IDynamicContainer parent = null;
    #endregion

    #region Strings
    private string name;
    private string shortDesc;
    private string longDesc;
    private string warning;
    private string footerText;

    private string showLessInfoString;
    private string showMoreInfoString;
    #endregion

    ContainerGlobals globals;
    #endregion

    #region Properties
    #region Appearance
    protected bool RoundBorders
    {
      get { return roundBorders; }
      set { if (roundBorders != value) { roundBorders = value; PerformLayout(); } }
    }
    protected bool ShowFooter
    {
      get { return showFooter; }
      set { if (showFooter != value) { showFooter = value; PerformLayout(); } }
    }
    protected int CornerWidth
    {
      get { return _cornerWidth; }
      set { _cornerWidth = value; }
    }
    protected int CornerHeight
    {
      get { return _cornerHeight; }
      set { _cornerHeight = value; }
    }

    #region Colors
    public virtual Color BorderColor
    {
      get { return borderColor; }
      set { borderColor = value; }
    }
    public virtual Color LightBorderColor
    {
      get { return lightBorderColor; }
      set { lightBorderColor = value; }
    }
    public virtual Color FooterBackgroundColorStart
    {
      get { return footerBackColorStart; }
      set { footerBackColorStart = value; }
    }
    public virtual Color FooterBackgroundColorEnd
    {
      get { return footerBackColorEnd; }
      set { footerBackColorEnd = value; }
    }
    public virtual Color HeaderBackgroundColorStart
    {
      get { return headerBackColorStart; }
      set { headerBackColorStart = value; }
    }
    public virtual Color HeaderBackgroundColorEnd
    {
      get { return headerBackColorEnd; }
      set { headerBackColorEnd = value; }
    }
    public virtual Color WarningBorderColor
    {
      get { if (lblWarning != null) return lblWarning.BackColor; else return Color.Transparent; }
      set { if (lblWarning != null) lblWarning.BackColor = value; else throw new Exception("You need to set up the warning label in this FieldContainerBase before trying to change it's colors."); }
    }
    public virtual Color WarningBackColor
    {
      get { if (lblWarning != null) return lblWarning.SingleLineColor; else return Color.Transparent; }
      set { if (lblWarning != null) lblWarning.SingleLineColor = value; else throw new Exception("You need to set up the warning label in this FieldContainerBase before trying to change it's colors."); }
    }
    public virtual Color BackgroundColor
    {
      get { return backgroundColor; }
      set { backgroundColor = value; }
    }
    public Office2007ColorTable ColorTable
    {
      get { if (renderer != null) return renderer.ColorTable; else return null; }
    }
    #endregion

    #region Fonts
    public virtual Font NameFont
    {
      get { return Font; }
      set { Font = value; }
    }
    public virtual Font ShortDescriptionFont
    {
      get { return shortDescFont; }
      set { shortDescFont = value; }
    }
    public virtual Font LongDescriptionFont
    {
      get { return longDescFont; }
      set { longDescFont = value;}
    }
    public virtual Font WarningFont
    {
      get { if (lblWarning != null) return lblWarning.Font; else return null; }
      set { if (lblWarning != null) lblWarning.Font = value; else throw new Exception("You need to initialize the warning label before you try to set its font."); }
    }
    public virtual Font MoreInfoFont
    {
      get { return (lblMoreInfo != null) ? lblMoreInfo.Font : null; }
      set { if (lblMoreInfo != null) lblMoreInfo.Font = value; else throw new Exception("You need to initialize the more info label before you try to set its font."); }
    }
    public virtual Font FooterFont
    {
      get { return footerFont; }
      set { footerFont = value; }
    }
    #endregion
    #endregion

    #region Behavior
    public bool ShowingLongDescription
    {
      get { return showingLongDesc; }
      set { showingLongDesc = value; }
    }
    public bool LayoutSuspended
    {
      get { return !doLayout; }
      set { doLayout = !value; }
    }
    public LayoutValues LayoutValues
    {
      get { return layoutValues; }
      set { layoutValues = value; }
    }
    /// <summary>
    /// Gets or sets a value indicating that this container is collapseable.
    /// </summary>
    public bool Collapseable
    {
      get { if (btnCollapse != null) return btnCollapse.Visible; else return false; }
      set 
      {
        if (btnCollapse != null)
        {
          btnCollapse.Visible = value;
        }
        else
        {
          if (value) // we want it enabled
          {
            btnCollapse = new ToggleButton();
            btnCollapse.Visible = true;
          }
        }
      }
    }
    /// <summary>
    /// Gets or sets the value indicating whether or not this container is collapsed.
    /// </summary>
    public bool Collapsed
    {
      get { if (Collapseable) return btnCollapse.Toggled; else return false; }
      set { if (Collapseable) btnCollapse.Toggled = value; }
    }
    #endregion

    #region Strings
    public virtual string ContainerName
    {
      get { return name; }
      set
      {
        if (name != value)
        {
          name = value; OnContainerNameChanged(this, new EventArgs());
        }
      }
    }
    public virtual string ShortDescription
    {
      get { return shortDesc; }
      set
      {
        if (shortDesc != value)
        { 
          shortDesc = value; OnShortDescriptionChanged(this, new EventArgs()); 
        }
      }
    }
    public virtual string LongDescription
    {
      get { return longDesc; }
      set
      {
        if (longDesc != value)
        {
          longDesc = value;
          OnLongDescriptionChanged(this, new EventArgs());
        }
      }
    }
    public virtual string Warning
    {
      get { if (lblWarning != null) return lblWarning.Text; else return warning; }
      set
      {
        if (lblWarning != null)
        {
          if (lblWarning.Text != value)
          {
            lblWarning.Text = value;
            OnWarningChanged(this, new EventArgs());
          }
        }
        else if (warning != value)
        {
          warning = value;
          OnWarningChanged(this, new EventArgs());
        }
      }
    }
    public virtual string FooterText
    {
      get { return footerText; }
      set { footerText = value; }
    }

    protected string ShowMoreInfoString
    {
      get { return showMoreInfoString; }
      set { showMoreInfoString = value; }
    }
    protected string ShowLessInfoString
    {
      get { return showLessInfoString; }
      set { showLessInfoString = value; }
    }
    #endregion

    public BlockContainerPanel FieldPanel
    {
      get { return fieldPanel; }
      set { SetFieldPanel(value); }
    }
    #endregion

    protected FieldContainerBase()
    {
      SuspendLayout();

      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

      Margin = new System.Windows.Forms.Padding(0);
      Padding = new System.Windows.Forms.Padding(0);

      #region Setup More Info label
      lblMoreInfo = new LabelX();
      lblMoreInfo.Name = "lblMoreInfo";
      lblMoreInfo.AutoSize = true;
      lblMoreInfo.MarkupLinkClick += new MarkupLinkClickEventHandler(OnMoreInfoClicked);
      lblMoreInfo.Text = (String.IsNullOrEmpty(LongDescription)) ? MoreInfoDisabledString : ShowMoreInfoString;
      lblMoreInfo.BackColor = Color.Transparent;
      //Controls.Add(lblMoreInfo);
      lblMoreInfo = null;
      #endregion

      #region Setup Warning label
      lblWarning = new LabelX();
      lblWarning.AutoSize = true;
      lblWarning.MaximumSize = new Size(500, 0);
      lblWarning.MinimumSize = new Size(500, 0);
      lblWarning.Name = "lblWarning";
      lblWarning.PaddingLeft = 2;
      lblWarning.PaddingRight = 2;
      lblWarning.PaddingTop = 1;
      lblWarning.PaddingBottom = 1;
      //lblWarning.Font = WarningFont; // This is taken care of using WarningFont.
      lblWarning.WordWrap = true;
      lblWarning.TextAlignment = StringAlignment.Near;
      //lblWarning.TextLineAlignment = StringAlignment.Near;
      lblWarning.ForeColor = Color.DarkRed;
      lblWarning.SingleLineColor = lblWarning.ForeColor;
      lblWarning.BackColor = System.Drawing.Color.FromArgb(220, 175, 175);
      lblWarning.BorderType = eBorderType.DoubleLine;
      Controls.Add(lblWarning);
      //lblWarning = null;
      #endregion

      #region Setup Description label
      lblDescription = new LabelX();
      lblDescription.Name = "lblDescription";
      lblDescription.AutoSize = true;
      lblDescription.Visible = (!string.IsNullOrEmpty(ShortDescription) || !string.IsNullOrEmpty(LongDescription));
      lblDescription.WordWrap = true;
      lblDescription.TextAlignment = StringAlignment.Near;
      //lblDescription.TextLineAlignment = StringAlignment.Near;
      lblDescription.BackColor = Color.Transparent;
      lblDescription.MarkupLinkClick += new MarkupLinkClickEventHandler(OnMoreInfoClicked);
      //lblDescription.Font = ShortDescriptionFont;

      Controls.Add(lblDescription);
      #endregion

      //lblDescription = new LabelX();
      //Controls.Add(lblDescription);

      #region Setup Collapse button
      btnCollapse = new ToggleButton();
      btnCollapse.Name = "btnCollapse";
      btnCollapse.Toggled = false;
      btnCollapse.Image = Prometheus.Properties.Resources.CollapseTitle;
      btnCollapse.ToggledImage = Prometheus.Properties.Resources.ExpandTitle;
      btnCollapse.Size = new Size(11, 11);
      btnCollapse.BeforeToggle += new EventHandler(OnBeforeToggle);
      btnCollapse.AfterToggle += new EventHandler(OnAfterToggle);
      Controls.Add(btnCollapse);
      #endregion

      #region Setup fonts
      NameFont = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
      FooterFont = new System.Drawing.Font("Segoe UI", 8.25F, FontStyle.Bold);
      if (lblMoreInfo != null)
        MoreInfoFont = new Font(NameFont.FontFamily, NameFont.Size - 1.5f, FontStyle.Regular);
      ShortDescriptionFont = new Font(NameFont.FontFamily, NameFont.Size - 1.5f, FontStyle.Regular);
      LongDescriptionFont = new Font(NameFont.FontFamily, NameFont.Size - 1.5f, FontStyle.Regular);
      //if (lblWarning != null)
      WarningFont = new Font(NameFont.FontFamily, NameFont.Size - 1.5f, FontStyle.Regular);
      if (lblDescription != null)
        lblDescription.Font = ShortDescriptionFont;
      #endregion

      SetupMoreInfoStrings();

      if (DevComponents.DotNetBar.Rendering.GlobalManager.Renderer is Office2007Renderer)
      {
        renderer = GlobalManager.Renderer as Office2007Renderer;

        UpdateTheme();

        renderer.ColorTableChanged += new EventHandler(OnColorTableChanged);
      }

      ResumeLayout(false);
      PerformLayout();
    }

    private void SetupMoreInfoStrings()
    {
      #region More Info Strings
      string spacing = "  ";
      string moreInfoFontInfo = "<i></i><font face=\"" + NameFont.Name + "\" size=\"" + (NameFont.SizeInPoints - 1.5f) + "\">";
      ShowMoreInfoString = spacing + moreInfoFontInfo + "<b><a href=\"" + ShowMoreURI + "\">More Info</a></b></font>";
      ShowLessInfoString = spacing + moreInfoFontInfo + "<b><a href=\"" + ShowLessURI + "\">Less Info</a></b></font>";
      #endregion
    }
    protected FieldContainerBase(ContainerGlobals globals) : this()
    {
      XmlNode node = globals.BlockNode.SelectSingleNode("name");
      if (node != null)
        Name = StringOps.CapitalizeWords(node.InnerText);
      node = globals.BlockNode.SelectSingleNode("shortdesc");
      if (node != null)
        ShortDescription = StringOps.CapitalizeWords(node.InnerText);
      node = globals.BlockNode.SelectSingleNode("longdesc");
      if (node != null)
        LongDescription = StringOps.CapitalizeWords(node.InnerText);
    }

    private void SetFieldPanel(BlockContainerPanel panel)
    {
      SuspendLayout();
      if (panel != fieldPanel)
      {
        if (fieldPanel != null)
          Controls.Remove(fieldPanel);
        fieldPanel = panel;
        Controls.Add(fieldPanel);
        OnFieldPanelChanged(this, new EventArgs());
      }
      ResumeLayout();
    }
    protected void SetBlockControl(IBlockControl block)
    {
      if (block != blockControl)
      {
        if (blockControl is Control)
          Controls.Remove(blockControl as Control);

        blockControl = block;
        Controls.Add(block as Control);

        OnBlockControlChanged(this, new EventArgs());
      }
    }
    protected void DoLayout(Control affectedControl, string affectedProperty)
    {
      if (doLayout)
      {
        if (affectedControl == FieldPanel)
          if (FieldPanel != null)
            FieldPanel.PerformLayout(FieldPanel, affectedProperty);
        PerformLayout(affectedControl, affectedProperty);
      }
    }
    protected void DoLayout(string affectedProperty)
    {
      DoLayout(this, affectedProperty);
    }
    protected virtual void UpdateTheme()
    {
      if (FieldPanel != null)
      {
        /*SuspendLayout();
        if (FieldPanel.Width >= Width)
          FieldPanel.Width = Width - 1;
        ResumeLayout(false);*/
        FieldPanel.BackColor = Color.Transparent;
      }
    }

    #region Events
    /// <summary>
    /// This method is called after the collapse button has been toggled.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnAfterToggle(object sender, EventArgs e)
    {
      SuspendLayout();
      if (Block is Control)
        (Block as Control).Visible = !Collapsed;
      if (FieldPanel is Control)
        FieldPanel.Visible = !Collapsed;
      ResumeLayout(false);
      PerformLayout();
      if ((Collapsed) && (OnCollapsed != null))
        OnCollapsed(this, new EventArgs());
      else if ((!Collapsed) && (OnExpanded != null))
        OnExpanded(this, new EventArgs());
      if (base.Parent != null)
        base.Parent.Invalidate();
      ResumeLayout();
      Invalidate();
    }
    /// <summary>
    /// This method is called before the collapse button has been toggled.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnBeforeToggle(object sender, EventArgs e)
    {
      SuspendLayout();
      if (Collapsed)
      {
        if (OnExpanding != null)
          OnExpanding(this, new EventArgs());
        if (PerformingLoad != null)
          if (!Globals.IsLoaded)
            PerformingLoad(this, Globals);

        //DoLayout("Controls");
        //DoLayout(FieldPanel, "Controls");
      }
      else
        if (OnCollapsing != null)
          OnCollapsing(this, new EventArgs());
      ResumeLayout();
    }
    /// <summary>
    /// This method is performed when the more info link is clicked.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnMoreInfoClicked(object sender, MarkupLinkClickEventArgs e)
    {
      switch (e.HRef.ToLower())
      {
        case ShowMoreURI:
          if (lblMoreInfo != null)
            lblMoreInfo.Text = ShowLessInfoString;
          if (lblDescription != null)
            lblDescription.Font = LongDescriptionFont;
          ShowingLongDescription = true;
          break;
        case ShowLessURI:
          if (lblMoreInfo != null)
            lblMoreInfo.Text = ShowMoreInfoString;
          if (lblDescription != null)
            lblDescription.Font = ShortDescriptionFont;
          ShowingLongDescription = false;
          break;
        default:
          return;
      }
      SetupDescriptionLabels();
    }
    /// <summary>
    /// Ths method is called when the ContainerName property has changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnContainerNameChanged(object sender, EventArgs e)
    {
    }
    /// <summary>
    /// This method is called when the ShortDescription property has changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnShortDescriptionChanged(object sender, EventArgs e)
    {
      SetupDescriptionLabels();
    }
    private void SetupDescriptionLabels()
    {
      if (!ShowingLongDescription)
      {
        if (!String.IsNullOrEmpty(ShortDescription))
        {
          // We are not showing a long description, and we have a short description
          // Setup label for short description.
          lblDescription.Visible = true;
          lblDescription.Text = "<i>" + ShortDescription + "</i>";
          lblDescription.Font = ShortDescriptionFont;
        }
        else if (!String.IsNullOrEmpty(LongDescription))
        {
          // We are not showing a long description, but we do have one even though we don't have a short description.
          // Hide the description label and enable the "More Info" link.
          lblDescription.Text = "";
          Interfaces.Output.Write(Interfaces.OutputTypes.Warning, "The block named \"" + ContainerName + " had no short description, but the long description: " + LongDescription);
        }
      }
      else if (!String.IsNullOrEmpty(LongDescription))
      {
        lblDescription.Visible = true;
        lblDescription.Text = LongDescription;
        lblDescription.Font = LongDescriptionFont;

        ShowingLongDescription = true;
        //lblMoreInfo.Text = ShowLessInfoString;
        //lblDescription.Text += " " + ShowLessInfoString;
      }
      else
      {
        ShowingLongDescription = false;
        SetupDescriptionLabels();
        return;
      }

      /*if ((lblMoreInfo.Text == MoreInfoDisabledString) && !String.IsNullOrEmpty(LongDescription))
      {
          //lblMoreInfo.Text = ShowMoreInfoString;
        lblDescription.Text += " " + ShowMoreInfoString;
      }*/

      // Add the proper string...
      if (lblDescription != null)
      {
        if (ShowingLongDescription)
          lblDescription.Text += " " + ShowLessInfoString;
        else if (!String.IsNullOrEmpty(LongDescription))
          lblDescription.Text += " " + ShowMoreInfoString;
      }

      if (!LayoutSuspended)
        PerformLayout();
    }
    /// <summary>
    /// This method is called when the LongDescription property has changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnLongDescriptionChanged(object sender, EventArgs e)
    {
      SetupDescriptionLabels();
    }
    /// <summary>
    /// This method is called when the Warning property has changed.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnWarningChanged(object sender, EventArgs e)
    {
    }
    protected virtual void OnFieldPanelChanged(object sender, EventArgs e)
    {
      fieldPanel.Location = new Point(0, LayoutValues.fullCaptionHeight + 5);
      //EventHandler temp = new EventHandler(OnPanelSizeChanged);

      fieldPanel.Size = new Size(Width - (fieldPanel.Location.X * 2), fieldPanel.Height);
      // We don't want sizechanged to be called a million times if someone decides to use FieldPanel's set accessor.
      fieldPanel.SizeChanged -= new EventHandler(OnPanelSizeChanged);
      fieldPanel.SizeChanged += new EventHandler(OnPanelSizeChanged);
      fieldPanel.LocationChanged += new EventHandler(OnPanelLocationChanged);

      fieldPanel.BorderColor = BorderColor;
      fieldPanel.LightBorderColor = LightBorderColor;
      fieldPanel.BackgroundColor = BackColor;
      if (Collapseable)
        fieldPanel.Visible = !Collapsed;
      else fieldPanel.Visible = true;
    }

    void OnPanelLocationChanged(object sender, EventArgs e)
    {
      if (fieldPanel != null)
        FieldPanel.Location = new Point(0, FieldPanel.Location.Y);
    }
    protected virtual void OnColorTableChanged(object sender, EventArgs e)
    {
      UpdateTheme();
    }
    protected virtual void OnColorChanged(object sender, EventArgs e)
    {
    }
    protected virtual void OnFontChanged(object sender, EventArgs e)
    {
      SetupMoreInfoStrings();
    }
    protected virtual void OnPanelSizeChanged(object sender, EventArgs e)
    {
      DoLayout("Size");
    }
    protected virtual void OnBlockControlChanged(object sender, EventArgs e)
    {
      if (blockControl is Control)
        (blockControl as Control).Visible = !Collapsed;
    }
    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);

      e.Control.Location = new Point(5, LayoutValues.blockControlHeight + LayoutValues.fullCaptionHeight);
    }
    #endregion

    #region Overrides
    public new void SuspendLayout()
    {
      doLayout = false;
      base.SuspendLayout();
    }
    public new void ResumeLayout()
    {
      doLayout = true;
      base.ResumeLayout();
    }
    public new void ResumeLayout(bool performLayout)
    {
      doLayout = true;
      base.ResumeLayout(performLayout);
    }
    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
    }
    private System.Windows.Forms.Layout.LayoutEngine layoutEngine = null;
    public override System.Windows.Forms.Layout.LayoutEngine LayoutEngine
    {
      get
      {
        if (layoutEngine == null)
          layoutEngine = new FieldContainerLayout();
        return layoutEngine;
      }
    }
    protected override void OnSizeChanged(EventArgs e)
    {
      if (fieldPanel != null)
      {
        //fieldPanel.MaximumSize = new Size(Width - (fieldPanel.Location.X * 2) - 1, 9999999);
        //fieldPanel.Width = fieldPanel.MaximumSize.Width;

        if (blockControl != null)
        {
          (blockControl as Control).Width = Width - (fieldPanel.Location.X * 2);
        }
      }

      if (Width == 0)
        Width = FieldListLayout.BlockWidth + (Globals.DepthDifference * Margin.Left) - 1;

      base.OnSizeChanged(e);
    }
    protected static SizeF MeasureCaptionString(string s, Font f, int maxWidth, Graphics g)
    {
      int maxTextWidth = maxWidth - 10;
      g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
      return g.MeasureString(s, f, maxTextWidth);
    }
    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      base.OnPaintBackground(pevent);
    }
    private Color GetBackColor()
    {
  //    if (BackColor != Color.Transparent)
//        return BackColor;
      //else
      //{
        Control nextControl = base.Parent;
        while (nextControl != null)
        {
          if (nextControl.BackColor != Color.Transparent)
            return nextControl.BackColor;
          nextControl = nextControl.Parent;
        }
        // This should never happen.
        return Color.Transparent;
    //  }
    }
    private RectangleF headerRect;
    public RectangleF HeaderTextRectangle
    {
      get { return headerRect; }
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      if (RoundBorders) BackColor = GetBackColor();
      int cornerWidth = CornerWidth;
      int cornerHeight = CornerHeight;
      if (!RoundBorders)
      {
        cornerWidth = cornerHeight = 0;
      }

      // Make sure that we have something to draw.
      if (Width < 1 || Height < 1) return;

      Graphics g = e.Graphics;
      Rectangle fullArea = new Rectangle(0, 0, Width - 1, Height - 1);

      // Determine the header area.
      int headerHeight = this.LayoutValues.headerBaseHeight;

      Rectangle headerArea = new Rectangle(0, 0, Width - 1, headerHeight);

      // Determine the Block Area.
      Rectangle blockArea = new Rectangle(1, headerHeight + 1, Width - 2, this.LayoutValues.blockControlHeight);

      // Determine the Control area.
      Rectangle controlArea = new Rectangle(1, blockArea.Bottom + 1, Width - 1, this.LayoutValues.controlAreaHeight);

      #region Fill in the block and control areas
      if (!Collapsed)
      {
        if (controlArea.Width > 0 && controlArea.Height > 0)
        {
          using (SolidBrush backgroundBrush = new SolidBrush(BackgroundColor))
            g.FillRectangle(backgroundBrush, controlArea);
        }
        if (blockArea.Width > 0 && blockArea.Height > 0)
          using (SolidBrush blockBackgroundBrush = new SolidBrush(BackgroundColor))
            g.FillRectangle(blockBackgroundBrush, blockArea);
      }
      #endregion

      #region Draw the footer.
      Rectangle footerArea = new Rectangle(1, Height - this.LayoutValues.footerHeight + 1, Width - 1, this.LayoutValues.footerHeight - 1);
      if (RoundBorders)
      {
        footerArea.X -= 1;
        //footerArea.Width += 1;
        footerArea.Y -= 1;
        //footerArea.Height += 1;
        using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(footerArea, FooterBackgroundColorStart, FooterBackgroundColorEnd, LinearGradientMode.Vertical))
          DrawRoundedRectangle(g, new Pen(BorderColor), backgroundBrush, footerArea, Corners.BottomRight | Corners.BottomLeft);
      }
      else
      {
        using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(footerArea, FooterBackgroundColorStart, FooterBackgroundColorEnd, LinearGradientMode.Vertical))
          g.FillRectangle(backgroundBrush, footerArea.X - 1, footerArea.Y, footerArea.Width + 1, footerArea.Height);
      }
      #endregion

      #region Draw the borders and lines
      using (Pen p = new Pen(BorderColor, 1.0f))
      {
        // Border around the header.
        if (!RoundBorders)
        {
          // Draw the header.
          using (LinearGradientBrush b = new LinearGradientBrush(headerArea, HeaderBackgroundColorStart, HeaderBackgroundColorEnd, LinearGradientMode.Vertical))
          {
            g.FillRectangle(b, headerArea);
            g.DrawRectangle(p, headerArea);
          }
        }
        else
        {
          //headerArea.Y -= 1;
          //headerArea.Height -= 1;
          using (LinearGradientBrush b = new LinearGradientBrush(headerArea, HeaderBackgroundColorStart, HeaderBackgroundColorEnd, LinearGradientMode.Vertical))
            DrawRoundedRectangle(g, p, b, headerArea, Corners.TopLeft | Corners.TopRight);
        }
      }
        // Border around the entire control.
        //g.DrawRectangle(p, fullArea);

        //using (Pen newPen = new Pen(Color.Red))
        //{
        if (!Collapsed)
        {
          Pen newPen = new Pen(BorderColor, 1.0f);
          
          // Draw the seperator lines.
          using (Pen lightPen = new Pen(LightBorderColor))
          {
            // Between the block and the control area.
            int blockLineY = this.LayoutValues.blockControlHeight + headerHeight;
            g.DrawLine(newPen, 1, blockLineY, Width - 2, blockLineY);
            g.DrawLine(lightPen, 1, blockLineY + 1, Width - 2, blockLineY + 1);

            // Between the footer and the control area.
            int footerLineY = (Height - this.LayoutValues.footerHeight);
            g.DrawLine(newPen, 1, footerLineY, Width - 2, footerLineY);
            g.DrawLine(lightPen, 1, footerLineY + 1, Width - 2, footerLineY + 1);
          }
          if ((blockArea.Width > 0) && (blockArea.Height > 0))
          {
            g.DrawLine(newPen, fullArea.Left, blockArea.Bottom, fullArea.Left, blockArea.Top);
            g.DrawLine(newPen, fullArea.Right, blockArea.Bottom, fullArea.Right, blockArea.Top);
          }
          if ((controlArea.Width > 0) && (controlArea.Height > 0))
          {
            g.DrawLine(newPen, fullArea.Left, controlArea.Top, fullArea.Left, controlArea.Bottom);
            g.DrawLine(newPen, fullArea.Right, controlArea.Top, fullArea.Right, controlArea.Bottom);
          }
        }
        else if (!RoundBorders)
          g.DrawRectangle(new Pen(BorderColor), new Rectangle(0,0, Width-1, Height-1));
      //}
      #endregion

      #region Draw the header caption text.
      if (!String.IsNullOrEmpty(Name))
      {
        using (Brush fontBrush = new SolidBrush(ForeColor))
        {
          StringFormat f = new StringFormat();
          f.Alignment = StringAlignment.Near;

          // TODO: Adjust width here to allow for buttons.
          SizeF headerSize = MeasureCaptionString(ContainerName, Font, Width, g);
          headerRect = new RectangleF(this.LayoutValues.padding, this.LayoutValues.padding, headerSize.Width, headerSize.Height);
          // e.Graphics.DrawRectangle(Pens.Blue, new Rectangle((int)headerRect.X, (int)headerRect.Y, (int)headerRect.Width, (int)headerRect.Height));
          e.Graphics.DrawString(ContainerName, Font, fontBrush, headerRect, f);
        }
      }
      #endregion

      #region Draw the footer text
      if (!String.IsNullOrEmpty(FooterText))
      {
        if (!Collapsed)
        {
          SizeF footerSize = MeasureCaptionString(FooterText, FooterFont, Width, g);
          // center the rectangle vertically
          RectangleF footerRect = new RectangleF(this.LayoutValues.padding + footerArea.X, footerArea.Y + ((footerArea.Height / 2) - (footerSize.Height / 2)), footerSize.Width, footerSize.Height);
          using (Brush fontBrush = new SolidBrush(ForeColor))
          {
            g.DrawString(FooterText, FooterFont, fontBrush, footerRect);
          }
        }
      }
      #endregion
    }
    private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle toDraw, Corners Rounded)
    {
      DrawRoundedRectangle(g, pen, null, toDraw, Rounded);
    }
    private void DrawRoundedRectangle(Graphics g, Pen pen, Brush brush, Rectangle toDraw, Corners Rounded)
    {
      //pen = new Pen(Color.Red, 1.0f);
      // These are the points where the straight lines end and the round corners begin.
      //pen = new Pen(Color.Red);
      Point topLeft = new Point(toDraw.Left, toDraw.Top);
      Point topRight = new Point(toDraw.Right, toDraw.Top);
      Point bottomLeft = new Point(toDraw.Left, toDraw.Bottom);
      Point bottomRight = new Point(toDraw.Right, toDraw.Bottom);

      int height = toDraw.Height - (CornerHeight / 2);
      height = (height < CornerHeight) ? height : CornerHeight;

      //brush = new SolidBrush(Color.Purple);
      // this was used for testing at one time.
      Brush ellipse = brush;//Brushes.Orange;
      // Figure out the points involved
      if ((Rounded & Corners.TopLeft) == Corners.TopLeft)
      {
        topLeft.X += (CornerWidth / 2);
        topLeft.Y += (CornerHeight / 2);
        if (brush != null)
          g.FillEllipse(ellipse, toDraw.Left, toDraw.Top, CornerWidth, CornerHeight);
        g.DrawArc(pen, toDraw.Left, toDraw.Top, CornerWidth, CornerHeight, 180, 90);
      }
      else
        if (brush != null)
          g.FillRectangle(brush, toDraw.Left, toDraw.Top, CornerWidth, height);
      if ((Rounded & Corners.TopRight) == Corners.TopRight)
      {
        topRight.X -= (CornerWidth / 2);
        if (topRight.X < 0)
          topRight.X = 0;
        topRight.Y += (CornerHeight / 2);
        if (brush != null)
          g.FillEllipse(ellipse, toDraw.Right - CornerWidth, toDraw.Top, CornerWidth, CornerHeight);
        g.DrawArc(pen, toDraw.Right - CornerWidth, toDraw.Top, CornerWidth, CornerHeight, 270, 90);
      }
      else
        if (brush != null)
        {
          g.FillRectangle(brush, toDraw.Right - CornerWidth, toDraw.Top, CornerWidth, height);
        }
      if ((Rounded & Corners.BottomLeft) == Corners.BottomLeft)
      {
        bottomLeft.X += (CornerWidth / 2);
        bottomLeft.Y -= (CornerHeight / 2);
        if (bottomLeft.Y < 0)
          bottomLeft.Y = 0;
        if (brush != null)
          g.FillEllipse(ellipse, toDraw.Left, toDraw.Bottom - CornerHeight, CornerWidth, CornerHeight);
        g.DrawArc(pen, toDraw.Left, toDraw.Bottom - CornerHeight, CornerWidth, CornerHeight, 90, 90);
      }
      else
        if (brush != null)
          g.FillRectangle(brush, toDraw.Left, toDraw.Bottom - CornerHeight, CornerWidth, height);
      if ((Rounded & Corners.BottomRight) == Corners.BottomRight)
      {
        bottomRight.X -= (CornerWidth / 2);
        bottomRight.Y -= (CornerHeight / 2);
        if (bottomRight.Y < 0)
          bottomRight.Y = 0;
        if (bottomRight.X < 0)
          bottomRight.X = 0;
        if (brush != null)
          g.FillEllipse(ellipse, toDraw.Right - CornerWidth, toDraw.Bottom - CornerHeight, CornerWidth, CornerHeight);
        g.DrawArc(pen, (toDraw.Right - CornerWidth), (toDraw.Bottom - CornerHeight), CornerWidth, CornerHeight, 0, 90);
      }
      else
        if (brush != null)
          g.FillRectangle(brush, toDraw.Right - CornerWidth, toDraw.Bottom - CornerHeight, CornerWidth, height);

      if (brush != null)
      {
        //brush = new SolidBrush(Color.Red);
        //g.FillRectangle(brush, toDraw.Left, topLeft.Y, toDraw.Width, bottomRight.Y - topRight.Y);
        //g.FillRectangle(brush, topLeft.X, toDraw.Top, topRight.X - topLeft.X, toDraw.Height);
        g.FillRectangle(brush, toDraw.Left, toDraw.Top + (CornerHeight/ 2), toDraw.Width, toDraw.Height - (CornerHeight));
        g.FillRectangle(brush, toDraw.Left + (CornerWidth / 2), toDraw.Top, toDraw.Width - CornerWidth, toDraw.Height);
        //g.FillRectangle(brush, toDraw.Left + (CornerWidth/2), toDraw.Top, toDraw.Width - (CornerWidth), toDraw.Height);
      }

      //pen = Pens.Red;

      // Draw the boundary lines
      g.DrawLine(pen, toDraw.Left, bottomLeft.Y, toDraw.Left, topLeft.Y);
      g.DrawLine(pen, topLeft.X, toDraw.Y, topRight.X, toDraw.Y);
      g.DrawLine(pen, toDraw.Right, topRight.Y, toDraw.Right, bottomRight.Y);
      g.DrawLine(pen, bottomLeft.X, toDraw.Bottom, bottomRight.X, toDraw.Bottom);
    }
    #endregion

    #region IFieldControlContainer Members

    public IFieldControl[] GetChildFields(int levels)
    {
      if (FieldPanel != null)
      {
        List<IFieldControl> controls = new List<IFieldControl>(FieldPanel.GetChildFields(levels));
        controls.Add(Block as IFieldControl);
        return controls.ToArray();
      }
      else return new IFieldControl[0];
    }

    public IFieldControl[] GetChildFields()
    {
      return GetChildFields(1);
    }

    public void AddField(IFieldControl field)
    {
      if (field is IBlockControl)
        SetBlockControl(field as IBlockControl);
      else if (fieldPanel != null)
        FieldPanel.AddField(field);
    }

    public void AddFieldContainer(IFieldControlContainer controlContainer)
    {
      if (FieldPanel != null)
        FieldPanel.AddFieldContainer(controlContainer);
    }

    #endregion

    #region IBoundPropertyCapable Members

    private string boundPropertyName = "";
    public string BoundPropertyName
    {
      get
      {
        return boundPropertyName;
      }
      set
      {
        boundPropertyName = value;
      }
    }

    #endregion

    #region IDynamicContainer Members

    public ContainerGlobals Globals
    {
      get
      {
        return globals;
      }
      set
      {
        globals = value;
      }
    }

    public event DynamicContainerDelegate PerformingLoad;

    public IBlockControl Block
    {
      get { return blockControl; }
    }

    public IDynamicContainer Parent
    {
      get { return parent; }
      set { parent = value; }
    }    

    #endregion
  }
}
