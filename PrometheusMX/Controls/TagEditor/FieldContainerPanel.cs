using System.Collections;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Interfaces.TagEditor;
using DevComponents.DotNetBar.Rendering;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;

namespace Prometheus.Controls.TagEditor
{
  public enum AutoSizeType
  {
    None = 0,
    Width = 1, Height = 2,
    WidthAndHeight = Width | Height,
    Grow = 4, Shrink = 8,
    GrowAndShrink = Grow | Shrink
  }
  public class FieldContainerPanel : Panel, IFieldControlContainer
  {
    private Office2007Renderer renderer = null;
    private LayoutEngine layoutEngine = null;
    int depthDifference = -1;
    Color borderColor = Color.Gray;
    Color lightBorderColor = Color.Transparent;
    Color backgroundColorStart;
    Color backgroundColorEnd;
    public Color BorderColor
    {
      get
      {
        return borderColor;
      }
      set { borderColor = value; Invalidate(); }
    }
    public Color LightBorderColor
    {
      get
      {
        if (lightBorderColor == null)
          return Color.Transparent; return lightBorderColor;
      }
      set { lightBorderColor = value; Invalidate(); }
    }
    public Color BackgroundColor
    {
      get { return (backgroundColorStart != null) ? backgroundColorStart : Color.Transparent;}
      set { backgroundColorStart = value; Invalidate();}
    }
    //public Color BackgroundColorEnd
    /*{
      get {return (backgroundColorEnd != null) ? backgroundColorEnd : Color.Transparent;}
      set { backgroundColorEnd = value; Invalidate();}
    }*/

    /// <summary>
    /// Gets or sets the depth difference of the current control. This is equivalent to the maximum depth subtracted by the current block's depth.
    /// </summary>
    public int DepthDifference
    {
      get { return depthDifference; }
      set { depthDifference = value; LayoutEngine.Layout(this, new LayoutEventArgs(this, "DepthDifference")); }
    }

    AutoSizeType _autoSize = AutoSizeType.None;

    [Description("The type of autosizing to use."), Category("Appearance")]
    public new AutoSizeType AutoSizeMode
    {
      get { return _autoSize; }
      set
      {
        if (_autoSize != value)
        {
          _autoSize = value;
          LayoutEngine.Layout(this, new LayoutEventArgs(this, "AutoSizeMode"));
        }
      }
    }

    public override LayoutEngine LayoutEngine
    {
      get
      {
        if (layoutEngine == null)
          layoutEngine = new FieldListLayout();
        return layoutEngine;
      }
    }
    public FieldContainerPanel()
    {
      Init();

      if (GlobalManager.Renderer is Office2007Renderer)
      {
        renderer = (GlobalManager.Renderer as Office2007Renderer);

        // Hook up to theme changes.
        renderer.ColorTableChanged += renderer_ColorTableChanged;

        // Setup the initial theme colors.
        UpdateTheme();
      }
    }
    protected void Init()
    {
      AutoSize = true;
      AutoSizeMode = AutoSizeType.GrowAndShrink | AutoSizeType.Height;
      BackColor = System.Drawing.Color.Transparent;
      Margin = new Padding(0);
      Padding = new Padding(5, 10, 5, 5);

      SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
      //SetStyle(ControlStyles.ResizeRedraw, false);
    }
    ~FieldContainerPanel()
    {
      Dispose(false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this);

        // Unsubscribe to the theme event.
        if (renderer != null)
          renderer.ColorTableChanged -= renderer_ColorTableChanged;
      }

      base.Dispose(disposing);
    }
    protected override void OnLocationChanged(EventArgs e)
    {
      //if (Location.Y > 50)
        base.OnLocationChanged(e);
    }
    public void ForceAutoSize()
    {
      LayoutEngine.Layout(this, new LayoutEventArgs(this, "AutoSizeMode"));
    }

    /// <summary>
    /// Themes in every block and the root level of the Tag Editor. BackColor should never be set here.
    /// </summary>
    protected virtual void UpdateTheme()
    {
      Office2007ColorTable colorTable = (Office2007ColorTable)renderer.ColorTable;

      BorderColor = colorTable.RibbonBar.Default.OuterBorder.Start;
      LightBorderColor = colorTable.RibbonBar.Default.InnerBorder.Start;
      BackgroundColor = colorTable.TabControl.Default.TopBackground.Start;

      if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        ForeColor = colorTable.TabControl.Default.Text;
      else
        ForeColor = colorTable.RibbonBar.Default.TitleText;
    }

    #region Border junk
    bool drawBorder = false;
    public bool DrawBorder
    {
      get { return drawBorder; }
      set { drawBorder = value; DoLayout("DrawBorder"); }
    }
    public void DoLayout(string affectedProperty)
    {
      LayoutEngine.Layout(this, new LayoutEventArgs(this, affectedProperty));
    }
    protected override void OnPaintBackground(PaintEventArgs e)
    {
      base.OnPaintBackground(e);
    }
    protected override void OnPaint(PaintEventArgs e)
    {
      Graphics g = e.Graphics; // shorthand

      if (DrawBorder)
      {
        if (!(LayoutEngine is FieldListLayout))
          return;
        if ((LayoutEngine as FieldListLayout).Groups != null)
        {
          List<Control[]> groups = (LayoutEngine as FieldListLayout).Groups;
          List<Rectangle> groupRects = GetGroupRects(groups);

          if (groupRects.Count > 0)
          {
            DrawRectangles(g, groupRects, e.ClipRectangle);
          }
        }
      }
    }

    private Color GetBackColor()
    {
      if (BackColor != Color.Transparent)
        return BackColor;
      else
      {
        Control nextControl = Parent;
        while (nextControl != null)
        {
          if (nextControl.BackColor != Color.Transparent)
            return nextControl.BackColor;
          nextControl = nextControl.Parent;
        }
        // This should never happen.
        return Color.Transparent;
      }
    }

    /// <summary>
    /// Receives a list of rectangles which designate the bounding box of groups and draws panels for them.
    /// </summary>
    /// <param name="g">The graphics object to draw with.</param>
    /// <param name="groupRects">A list of rectangles designating the the width/height/position of the panels to draw.</param>
    private void DrawRectangles(Graphics g, List<Rectangle> groupRects, Rectangle clipRect)
    {
      Pen pen = new Pen(BorderColor, 1);
      Pen lightPen = new Pen(LightBorderColor, 1);
      SolidBrush brush = new SolidBrush(BackgroundColor);      

      for (int x = 0; x < groupRects.Count; x++)
      {
        if (!groupRects[x].IntersectsWith(clipRect))
          continue;

        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        int cornerWidth = 16;
        int cornerHeight = 16;
        if (groupRects[x].Height > cornerWidth)
        {
          // top left
          g.FillEllipse(brush, groupRects[x].Left, groupRects[x].Top, cornerWidth, cornerHeight);
          g.DrawArc(pen, groupRects[x].Left, groupRects[x].Top, cornerWidth, cornerHeight, 180, 90);
          g.DrawArc(lightPen, groupRects[x].Left + pen.Width, groupRects[x].Top + pen.Width, cornerWidth, cornerHeight, 180, 90);
          // top right
          g.FillEllipse(brush, groupRects[x].Right - cornerWidth, groupRects[x].Top, cornerWidth, cornerHeight);
          g.DrawArc(pen, groupRects[x].Right - cornerWidth, groupRects[x].Top, cornerWidth, cornerHeight, 270, 90);
          g.DrawArc(lightPen, (groupRects[x].Right - cornerWidth) - pen.Width, groupRects[x].Top + pen.Width, cornerWidth, cornerHeight, 270, 90);
          // bottom right
          g.FillEllipse(brush, groupRects[x].Right - cornerWidth, groupRects[x].Bottom - cornerHeight, cornerWidth, cornerHeight);
          g.DrawArc(pen, groupRects[x].Right - cornerWidth, groupRects[x].Bottom - cornerHeight, cornerWidth, cornerHeight, 0, 90);
          g.DrawArc(lightPen, (groupRects[x].Right - cornerWidth) - pen.Width, (groupRects[x].Bottom - cornerHeight) - pen.Width, cornerWidth, cornerHeight, 0, 90);
          // bottom left
          g.FillEllipse(brush, groupRects[x].Left, groupRects[x].Bottom - cornerHeight, cornerWidth, cornerHeight);
          g.DrawArc(pen, groupRects[x].Left, groupRects[x].Bottom - cornerHeight, cornerWidth, cornerHeight, 90, 90);
          g.DrawArc(lightPen, groupRects[x].Left + pen.Width, (groupRects[x].Bottom - cornerHeight) - pen.Width, cornerWidth, cornerHeight, 90, 90);

          cornerHeight /= 2;
          cornerWidth /= 2;
        }
        else
        {
          cornerWidth = 0;
          cornerHeight = 0;
        }

        g.FillRectangle(brush, groupRects[x].Left, groupRects[x].Top + cornerHeight, groupRects[x].Width, groupRects[x].Height - (cornerHeight * 2));
        g.FillRectangle(brush, groupRects[x].Left + cornerWidth, groupRects[x].Top, groupRects[x].Width - (cornerWidth * 2), groupRects[x].Height);

        // left line
        g.DrawLine(pen, groupRects[x].Left, groupRects[x].Top + cornerHeight, groupRects[x].Left, groupRects[x].Bottom - cornerHeight);
        g.DrawLine(lightPen, groupRects[x].Left + pen.Width, groupRects[x].Top + cornerHeight, groupRects[x].Left + pen.Width, groupRects[x].Bottom - cornerHeight);
        // right line
        g.DrawLine(pen, groupRects[x].Right, groupRects[x].Top + cornerHeight, groupRects[x].Right, groupRects[x].Bottom - cornerHeight);
        g.DrawLine(lightPen, groupRects[x].Right - pen.Width, groupRects[x].Top + cornerHeight, groupRects[x].Right - pen.Width, groupRects[x].Bottom - cornerHeight);
        // bottom line
        g.DrawLine(lightPen, groupRects[x].Left + cornerWidth, groupRects[x].Bottom - pen.Width, groupRects[x].Right - cornerHeight, groupRects[x].Bottom - pen.Width);
        g.DrawLine(pen, groupRects[x].Left + cornerWidth, groupRects[x].Bottom, groupRects[x].Right - cornerHeight, groupRects[x].Bottom);
        // top line
        g.DrawLine(lightPen, groupRects[x].Left + cornerWidth, groupRects[x].Top + pen.Width, groupRects[x].Right - cornerHeight, groupRects[x].Top + pen.Width);
        g.DrawLine(pen, groupRects[x].Left + cornerWidth, groupRects[x].Top, groupRects[x].Right - cornerHeight, groupRects[x].Top);
      }

      pen.Dispose();
      lightPen.Dispose();
      brush.Dispose();
    }

    private List<Rectangle> GetGroupRects(List<Control[]> groups)
    {
      List<Rectangle> groupRects = new List<Rectangle>(groups.Count);

      for (int x = 0; x < groups.Count; x++)
      {
        Rectangle clientRect = GetGroupRect(groups[x]);
        if ((clientRect.Width > 0) && (clientRect.Height > 0))
        {
          clientRect.X -= Padding.Left;
          clientRect.Y -= Padding.Top;
          clientRect.Width = (FieldListLayout.BlockWidth + ((DepthDifference * (Margin.Left * 2))) - 1);
          if (clientRect.X + clientRect.Width > Width) // Fail-safe: It's better for the width to be a little off...
            clientRect.Width = (Width - Margin.Right) - clientRect.X;
          clientRect.Height += Padding.Bottom + Padding.Top;
          groupRects.Add(clientRect);
        }
      }
      return groupRects;
    }
    private Rectangle GetGroupRect(Control[] group)
    {
      if (group == null)
        return new Rectangle(0, 0, 0, 0);
      else if (group.Length < FieldListLayout.MinimumGroupCount)
        return new Rectangle(0, 0, 0, 0);
      Point topLeft = new Point(group[0].Location.X, group[0].Location.Y);
      Point bottomRight = new Point(0,0);

      for (int x = 0; x < group.Length; x++)
      {
        if (group[x].Location.X < topLeft.X)
          topLeft.X = group[x].Location.X;
        if (group[x].Location.Y < topLeft.Y)
          topLeft.Y = group[x].Location.Y;
        if (group[x].Location.X + group[x].Width > bottomRight.X)
          bottomRight.X = group[x].Location.X + group[x].Width;
        if (group[x].Location.Y + group[x].Height > bottomRight.Y)
          bottomRight.Y = group[x].Location.Y + group[x].Height;
      }
      return Rectangle.FromLTRB(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
    }
    #endregion

    void renderer_ColorTableChanged(object sender, EventArgs e)
    {
      UpdateTheme();
    }

    public FieldContainerBase GetParent()
    {
      return (Parent is FieldContainerBase) ? Parent as FieldContainerBase : null;
    }

    public IBlockControl GetParentBlock()
    {
      Control nextParent = Parent;
      // we want to cycle through the tag editor hierarchy
      while (nextParent is IFieldControlContainer)
      {
        if (nextParent is BlockContainer)
          return (nextParent as BlockContainer).Block;
        nextParent = nextParent.Parent;
      }
      return null;
    }

    public IFieldControl[] GetChildFields(int levels)
    {
      ArrayList fields = new ArrayList();
      foreach (Control c in Controls)
      {
        if (c is FieldControlBase)
        {
          fields.Add(c);
        }
        else if (c is IFieldControlContainer)
        {
          fields.AddRange((c as IFieldControlContainer).GetChildFields(levels - 1));
        }
      }
      return (fields.ToArray(typeof(FieldControlBase)) as FieldControlBase[]);
    }

    public IFieldControl[] GetChildFields()
    {
      return GetChildFields(1);
    }

    public void AddField(IFieldControl field)
    {
      Controls.Add(field as Control);
    }

    public void AddFieldContainer(IFieldControlContainer controlContainer)
    {
      Controls.Add(controlContainer as Control);
      if (controlContainer is IDynamicContainer)
        if (GetParent() != null)
          (controlContainer as IDynamicContainer).Parent = GetParent();
    }
  }

  internal class FieldListLayout : LayoutEngine
  {
    public const int BlockWidth = 400;
    public const int MinimumGroupCount = 1;

    List<Control[]> groups = null;
    public List<Control[]> Groups
    {
      get { return groups; }
    }

    public override bool Layout(object container, LayoutEventArgs layoutEventArgs)
    {
      bool dirty = false;
      if (container is FieldContainerPanel)
      {
        FieldContainerPanel panel = container as FieldContainerPanel;
        int minimumWidth = (BlockWidth + (panel.DepthDifference * (panel.Margin.Left * 2))) - 1;

        if (panel.Width < minimumWidth)
        {
          panel.Width = minimumWidth;
          dirty = true;
        }
        //panel.SuspendLayout();

        bool controlFound = (layoutEventArgs.AffectedControl == panel);

        int maxWidth = 0;

        System.Drawing.Point lastLocation = new Point();
        lastLocation = new System.Drawing.Point(panel.Margin.Left, panel.Margin.Top);

        bool inGroup = false;
        int groupCount = 0; // to prevent spacing of groups that don't have enough controls.
        for (int x = 0; x < panel.Controls.Count; x++)
        {
          if (!controlFound)
            if (panel.Controls[x] == layoutEventArgs.AffectedControl)
              controlFound = true;

          Point newLocation = lastLocation;

          // List's go from top to bottom, thus, we don't need to do any layout until we get to the control that's changed.
          if (controlFound)
          {
            if (panel.DrawBorder)
            {
              // if the current control is a field container...
              if (panel.Controls[x] is IFieldControl)
              {
                newLocation = new Point(lastLocation.X + panel.Margin.Left, lastLocation.Y + panel.Padding.Top);
                inGroup = true;
                groupCount++;
              }
              else
              {
                if ((inGroup) && (groupCount >= MinimumGroupCount))
                {
                  // put in some extra padding between groups.
                  newLocation = new System.Drawing.Point(lastLocation.X, lastLocation.Y + 1);
                }
                else
                  newLocation = new System.Drawing.Point(lastLocation.X, lastLocation.Y);
                inGroup = false;
                groupCount = 0;
              }
            }

            if (panel.Controls[x].Location != newLocation)
            {
              panel.Controls[x].Location = newLocation;
              dirty = true;
            }

            if (panel.Controls[x] is FieldContainerBase)
            {
              FieldContainerBase tempContainer = panel.Controls[x] as FieldContainerBase;
              bool isSuspended = tempContainer.LayoutSuspended;
              int newContainerWidth = 0;
              if (tempContainer.FieldPanel != null)
              {
                if (tempContainer.FieldPanel.DepthDifference > -1)
                  newContainerWidth = (BlockWidth + (tempContainer.FieldPanel.DepthDifference * (tempContainer.Location.X * 2))) - 1;
              }
              else
                if (tempContainer.Globals.DepthDifference > -1)
                  newContainerWidth = (BlockWidth + (tempContainer.Globals.DepthDifference * (tempContainer.Location.X * 2))) - 1;
              if (newContainerWidth != 0)
                if (newContainerWidth != tempContainer.Width)
                {
                  tempContainer.Width = newContainerWidth; 
                  dirty = true;
                }
              if (tempContainer.Block != null)
                (tempContainer.Block as Control).Width = tempContainer.Width - 2;
            }
            else if (panel.Controls[x] is IFieldControl)
              // Center the controls for Nick. This may need to be replaced if we ever desire the use of margins.
              panel.Controls[x].Width = panel.Width - (panel.Controls[x].Location.X * 2);
          }


          lastLocation = new System.Drawing.Point(panel.Margin.Left, panel.Controls[x].Location.Y + panel.Controls[x].Height + panel.Padding.Top);

          if (panel.Controls[x] is BlockContainerPanel)
          {
            if (panel.Controls[x].Width > maxWidth)
              maxWidth = panel.Controls[x].Width;
          }
          else 
            if (panel.Controls[x].Location.X + panel.Controls[x].Width + panel.Padding.Right > maxWidth)
              maxWidth = panel.Controls[x].Location.X + panel.Controls[x].Width + panel.Padding.Right;
        }

        #region Autosize the panel.
        if (panel.AutoSize == true)
        {
          AutoSizePanel(ref dirty, panel, ref maxWidth, ref lastLocation);
        }
        #endregion

        if (!(panel.Parent is BlockContainer))
          if (panel.Width < minimumWidth)
          {
            panel.Width = minimumWidth + 1;
            dirty = true;
          }
        // Group controls...
        if (panel.DrawBorder)
          groups = GroupControls(typeof(IFieldControl), panel.Controls);
        else
          groups = null;

        //panel.Location = new Point(0, panel.Location.Y);

        //if (dirty)
//          panel.Invalidate(false);

        return true;
      }
      return false;
    }

    private static void AutoSizePanel(ref bool dirty, FieldContainerPanel panel, ref int maxWidth, ref System.Drawing.Point lastLocation)
    {
      if ((panel.AutoSizeMode & AutoSizeType.Height) == AutoSizeType.Height)
      {
        int newHeight = lastLocation.Y + panel.Margin.Bottom;

        if (newHeight > panel.Height)
        {
          if (FlagIsSet(panel.AutoSizeMode, AutoSizeType.Grow))
          {
            panel.Height = newHeight;
            dirty = true;
          }
        }
        else if (newHeight < panel.Height)
        {
          if (FlagIsSet(panel.AutoSizeMode, AutoSizeType.Shrink))
          {
            panel.Height = newHeight;
            dirty = true;
          }
        }
      }
      if ((panel.AutoSizeMode & AutoSizeType.Width) == AutoSizeType.Width)
      {
        maxWidth += panel.Margin.Right;

        if (maxWidth > panel.Width)
        {
          if (FlagIsSet(panel.AutoSizeMode, AutoSizeType.Grow))
          {
            panel.Width = maxWidth;
            dirty = true;
          }
        }
        else if (maxWidth < panel.Width)
        {
          if (FlagIsSet(panel.AutoSizeMode, AutoSizeType.Shrink))
          {
            panel.Width = maxWidth;
            dirty = true;
          }
        }
      }
      //if (panel.Parent != null)
      //{
        //if (panel.Location.X + panel.Width > panel.Parent.Width)
          //panel.Width = panel.Parent.Width - panel.Location.X - 1;
      //}
    }

    public List<Control[]> GroupControls(Type controlType, Control.ControlCollection controls)
    {
      List<Control[]> groups = new List<Control[]>(1);
      List<Control> currentGroup = new List<Control>(5);
      for (int x = 0; x < controls.Count; x++)
      {
        if (controlType.IsInstanceOfType(controls[x]))
        {
          currentGroup.Add(controls[x]);
        }
        else
        {
          if (currentGroup.Count > 0)
          {
            groups.Add(currentGroup.ToArray());
            currentGroup.Clear();
          }
        }
      }
      if (currentGroup.Count > 0)
          groups.Add(currentGroup.ToArray());
      return groups;
    }

    /// <summary>
    /// Tests a bitflagged enumeration to see if 'isModeSet's flags are set in currentMode.
    /// </summary>
    /// <param name="currentMode">The current value of the enumeration which you desire to test</param>
    /// <param name="isModeSet"></param>
    /// <returns></returns>
    protected static bool FlagIsSet(AutoSizeType currentMode, AutoSizeType isModeSet)
    {
      return ((currentMode & isModeSet) == isModeSet);
    }
  }

  public class ThemedPanel : Panel
  {
    private Office2007Renderer renderer = null;

    public ThemedPanel()
    {
      Margin = new Padding(0);

      this.AutoSize = true;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      AutoScroll = false;

      if (GlobalManager.Renderer is Office2007Renderer)
      {
        renderer = (GlobalManager.Renderer as Office2007Renderer);

        // Hook up to theme changes.
        renderer.ColorTableChanged += renderer_ColorTableChanged;

        // Setup the initial theme colors.
        UpdateTheme();
      }
    }

    ~ThemedPanel()
    {
      Dispose(false);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);
      int height = 0;
      for (int x = 0; x < Controls.Count; x++)
      {
        int newHeight = Controls[x].Height + Controls[x].Location.Y;
        if (newHeight > height)
          height = newHeight;
      }

      Height = height;// +Margin.Bottom;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        GC.SuppressFinalize(this);

        // Unsubscribe to the theme event.
        if (renderer != null)
          renderer.ColorTableChanged -= renderer_ColorTableChanged;
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Themes the main body of the Tag Editor.
    /// </summary>
    protected virtual void UpdateTheme()
    {
      Office2007ColorTable colorTable = (Office2007ColorTable)renderer.ColorTable;

      BackColor = colorTable.ComboBox.Default.Background;

      if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        ForeColor = colorTable.TabControl.Default.Text;
      else
        ForeColor = colorTable.RibbonBar.Default.TitleText;
    }

    void renderer_ColorTableChanged(object sender, EventArgs e)
    {
      UpdateTheme();
    }
  }
}
