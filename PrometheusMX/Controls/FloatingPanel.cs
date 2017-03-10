using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Prometheus.Controls
{
  public partial class FloatingPanel : Form
  {
    public FloatingPanel()
    {
      InitializeComponent();
      this.Controls.Remove(icon); // Exists on the Form only for Designer, belongs in TitlePanel.

      this.FindForm().VisibleChanged += new EventHandler(FloatingPanelHost_VisibleChanged);

      expBody.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(expTitle_MouseMove);
      expBody.TitlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(expTitle_MouseUp);
      expBody.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(expTitle_MouseDown);
      expBody.TitlePanel.TextChanged += new EventHandler(expBody_TextChanged);
    }

    #region Moving Window

    private bool mouseDown = false;
    private Point offset;
    
    private void expTitle_MouseDown(object sender, MouseEventArgs e)
    {
      mouseDown = true;
      offset = this.PointToScreen(e.Location);
    }

    private void expTitle_MouseUp(object sender, MouseEventArgs e)
    {
      mouseDown = false;
    }

    private void expTitle_MouseMove(object sender, MouseEventArgs e)
    {
      if(mouseDown)
      {
        Point loc = this.PointToScreen(e.Location);

        this.Left += (loc.X - offset.X);
        this.Top += (loc.Y - offset.Y);

        offset = loc;
      }
    }

    #endregion

    #region Event Handlers

    #region Form
    private void FloatingPanel_Load(object sender, EventArgs e)
    {
      string temp = this.Text;

      if (this.ShowInTaskbar)
      {
        // Form text cannot have markup, remove it.
        this.Text = Regex.Replace(this.Text, "<[^>]*>", "");
      }

      expBody.TitleText = temp;
    }

    private void FloatingPanel_Shown(object sender, EventArgs e)
    {
      if (!DesignMode)
      {
        expBody.Expanded = true;

        // And setup for the fancy exit ... that currently does not work.
        expBody.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.TopToBottom;
      }
    }

    // Host Form
    void FloatingPanelHost_VisibleChanged(object sender, EventArgs e)
    {
      if (this.FindForm().Visible)
        CreateIcon();
    }
    #endregion

    #region ExpandablePanel
    private void expBody_SizeChanged(object sender, System.EventArgs e)
    {
      System.Drawing.Size size = new Size(this.Width, expBody.Height);

      this.ClientSize = size;
      this.Size = size;
    }

    private void expBody_TextChanged(object sender, System.EventArgs e)
    {
      this.Text = expBody.TitleText;
    }

    private void expBody_ExpandedChanged(object sender, DevComponents.DotNetBar.ExpandedChangeEventArgs e)
    {
      if(!DesignMode)
        if(!expBody.Expanded)
            Close();
    }
    #endregion

    #region Icon
    private void icon_DoubleClick(object sender, EventArgs e)
    {
      if (!DesignMode)
          Close();
    }
    #endregion

    #endregion

    #region Methods

    private void CreateIcon()
    {
      if (Icon != null)
      {
        icon.Image = new Icon(Icon, 16, 16).ToBitmap();

        if (expBody.TitlePanel != null)
        {
          expBody.TitlePanel.Controls.Add(icon);
          expBody.TitleStyle.MarginLeft = 20;
        }
      }
      else
      {
        if (expBody != null)
        {
          expBody.TitlePanel.Controls.Remove(icon);
          expBody.TitleStyle.MarginLeft = 5;
        }
      }
    }

    #endregion
  }
}