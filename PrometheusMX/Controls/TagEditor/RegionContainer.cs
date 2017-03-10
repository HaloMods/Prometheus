using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using DevComponents.DotNetBar.Rendering;
using Interfaces.TagEditor;

namespace Prometheus.Controls.TagEditor
{
  public class RegionContainer : FieldContainerBase//UserControl, IFieldControlContainer
  {
    #region old region
    /*public bool collapsed = false;
    
    public string Caption
    {
      get { return lblTitle.Text; }
      set { lblTitle.Text = value; }
    }

    public bool Collapsed
    {
      get { return collapsed; }
    }
    
    public RegionContainer()
    {
      InitializeComponent();

    }

    void btnToggleCollapse_Click(object sender, EventArgs e)
    {
      ToggleCollapse();
    }

    private void ToggleCollapse()
    {
      collapsed = !collapsed;
      
      if (collapsed)
      {
        Size s = new Size(titleContainerPanel.Width, titleContainerPanel.Height+2);
        AutoSize = false;
        Size = s;
      }
      else 
        AutoSize = true;

      SetupButtonState();
      Refresh();
    }

    private void SetupButtonState()
    {
      btnToggleCollapse.Text = (collapsed ? "+" : "-");
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      if (!collapsed)
      {
        // Draw a line in the left edge.
        int top = fieldContainerPanel.Top + 1;
        int bottom = fieldContainerPanel.Bottom - 1;
        int left = fieldContainerPanel.Left + (btnToggleCollapse.Width / 2);
        Pen p = new Pen(new SolidBrush(Color.White), 1.0f);
        e.Graphics.DrawLine(p, left, top, left, bottom);
      }
    }

    public IFieldControl[] GetChildFields(int levels)
    {
      if (levels > 0) return new FieldControlBase[0];

      ArrayList fields = new ArrayList();
      foreach (Control c in fieldContainerPanel.Controls)
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
      fieldContainerPanel.Controls.Add(field as Control);
    }

    public void AddFieldContainer(IFieldControlContainer container)
    {
      fieldContainerPanel.Controls.Add(container as Control);
    }*/
    #endregion

    public RegionContainer()
    {
      if (lblMoreInfo != null)
        lblMoreInfo.Visible = false;
      RoundBorders = true;
    }
    protected override void UpdateTheme()
    {
      base.UpdateTheme();
      bool returnLayout = !LayoutSuspended;
      try
      {
        // Cancel layout updates so that we don't redraw an assload of times.
        SuspendLayout();

        BorderColor = ColorTable.RibbonBar.Default.OuterBorder.Start;
        LightBorderColor = ColorTable.RibbonBar.Default.InnerBorder.Start;

        if (renderer.ColorTable.InitialColorScheme == eOffice2007ColorScheme.Black)
        {
          HeaderBackgroundColorStart = ColorTable.TabControl.Default.TopBackground.End; //ColorTable.TabControl.Default.TopBackground.Start;
          HeaderBackgroundColorEnd = ColorTable.TabControl.Default.TopBackground.Start; //ColorTable.TabControl.Default.TopBackground.End;

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
          HeaderBackgroundColorStart = ColorTable.TabControl.Default.BottomBackground.Start;
          HeaderBackgroundColorEnd = ColorTable.TabControl.Default.BottomBackground.End;

          if (FieldPanel != null)
          {
            FieldPanel.BackColor = ColorTable.TabControl.Default.BottomBackground.End;
            FieldPanel.ForeColor = ColorTable.TabControl.Default.BottomBackground.End;
          }

          BackColor = ColorTable.TabControl.Default.BottomBackground.End;
          ForeColor = ColorTable.RibbonBar.Default.TitleText;
        }

        FooterBackgroundColorStart = ColorTable.TabControl.Default.TopBackground.End; //ColorTable.RibbonControl.PanelBottomBackground.Start;
        FooterBackgroundColorEnd = ColorTable.TabControl.Default.TopBackground.End; //ColorTable.RibbonBar.Default.TitleBackground.End;
      }
      finally
      {
        if (returnLayout)
          ResumeLayout();
        base.UpdateTheme();
      }
    }
  }
}
