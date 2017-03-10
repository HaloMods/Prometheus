using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls.ReferenceAnalyzer
{
  public partial class ReferenceItem : UserControl
  {
    protected int fullHeight = CollapsedHeight;
    protected bool expanded = false;
    protected ReferenceAnalyzerMode mode;
    protected List<ReferenceChild> children = new List<ReferenceChild>();

    protected const int CollapsedHeight = 47;

    public ReferenceItem(ReferenceAnalyzerMode analyzerMode, string tagPath)
    {
      InitializeComponent();

      Mode = analyzerMode;
      liErrorSummary.Text = "<b>" + Path.GetFileNameWithoutExtension(tagPath) + "</b> (<font color=\"navy\">" + Path.GetExtension(tagPath).TrimStart('.') + "</font>)<br/><font color=\"gray\">" + Path.GetDirectoryName(tagPath) + "</font>";
    }

    public void AddItem(string tagName, ReferenceType type)
    {
      int index = children.Count;
      children.Add(new ReferenceChild(tagName, type));
      children[index].Location = new Point(0, fullHeight);
      fullHeight += children[index].Height;
      if (mode == ReferenceAnalyzerMode.Tag)
      {
        if (type == ReferenceType.Recursive)
        {
          liMissingRecursivelyValue.Text = Convert.ToString(Convert.ToInt32(liMissingRecursivelyValue.Text) + 1, 10);
          liMissingRecursivelyValue.ForeColor = Color.Firebrick;
        }
        else if (type == ReferenceType.Direct)
        {
          liMissingDirectlyValue.Text = Convert.ToString(Convert.ToInt32(liMissingDirectlyValue.Text) + 1, 10);
          liMissingDirectlyValue.ForeColor = Color.Firebrick;
        }
      }
      else if (mode == ReferenceAnalyzerMode.Object)
      {
        liMissingDirectlyValue.Text = Convert.ToString(Convert.ToInt32(liMissingDirectlyValue.Text) + 1, 10);
        liMissingDirectlyValue.ForeColor = Color.Firebrick;
      }
      
      this.Controls.Add(children[index]);
      if (expanded)
        Height = fullHeight;
    }

    public ReferenceAnalyzerMode Mode
    {
      get
      { return mode; }
      protected set
      {
        mode = value;
        if (mode == ReferenceAnalyzerMode.Tag)
        {
          liMissingDirectly.Visible = liMissingDirectlyValue.Visible = true;
          liMissingRecursively.Text = "Recursively Missing:";
        }
        else if (mode == ReferenceAnalyzerMode.Object)
        {
          liMissingDirectly.Text = "Missing References:";
          liMissingDirectlyValue.Width = 21;
          liMissingRecursively.Visible = liMissingRecursivelyValue.Visible = false;
        }
        else
          throw new InvalidEnumArgumentException("Cannot set the control type to an unrecognized mode.");
      }
    }

    private void liErrorSummary_Click(object sender, EventArgs e)
    {
      if (expanded = !expanded)
      {
        Height = fullHeight;
      }
      else
      {
        Height = CollapsedHeight;
      }
    }

    public void addHighlight(object sender, EventArgs e)
    {
      icErrorSummary.BackgroundStyle.BackColor = Color.Gold;
      icErrorSummary.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorSummary.BackgroundStyle.BorderBottomWidth = 1;
      icErrorSummary.BackgroundStyle.BorderColor = Color.MediumBlue;
      icErrorSummary.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorSummary.BackgroundStyle.BorderLeftWidth = 1;
      icErrorSummary.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorSummary.BackgroundStyle.BorderRightWidth = 1;
      icErrorSummary.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorSummary.BackgroundStyle.BorderTopWidth = 1;
    }

    public void removeHighlight(object sender, EventArgs e)
    {
      icErrorSummary.BackgroundStyle.BackColor = Color.Transparent;
      icErrorSummary.BackgroundStyle.BorderBottomWidth = 0;
      icErrorSummary.BackgroundStyle.BorderLeftWidth = 0;
      icErrorSummary.BackgroundStyle.BorderRightWidth = 0;
      icErrorSummary.BackgroundStyle.BorderTopWidth = 0;
    }
  }
}
