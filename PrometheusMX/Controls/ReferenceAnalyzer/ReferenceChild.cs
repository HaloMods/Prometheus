using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls.ReferenceAnalyzer
{
  public partial class ReferenceChild : UserControl
  {
    protected ReferenceType referenceType = ReferenceType.Invalid;

    public ReferenceChild(string tagName, ReferenceType type)
    {
      InitializeComponent();

      Type = type;
      liReference.Text = tagName;
    }

    public ReferenceType Type
    {
      get
      { return referenceType; }
      protected set
      {
        referenceType = value;
        if (referenceType == ReferenceType.Direct)
        {
          liReference.ForeColor = Color.DarkGray;
          liReference.Click += new EventHandler(ShowDirectMenu);
        }
        else if (referenceType == ReferenceType.Recursive)
        {
          liReference.ForeColor = Color.Gray;
          liReference.Click += new EventHandler(ShowRecursiveMenu);
        }
        else
          throw new InvalidEnumArgumentException("Cannot set the control type to an Invalid reference type.");
      }
    }

    public event EventHandler SeekToRecursiveItem;

    public event EventHandler NullThisReference;

    public event EventHandler SelectPath;

    private void mnuNullRef_Click(object sender, EventArgs e)
    {
      if (NullThisReference != null)
        NullThisReference(this, e);
    }

    private void mnuSelectLocation_Click(object sender, EventArgs e)
    {
      if (SelectPath != null)
        SelectPath(this, e);
    }

    private void mnuGotoRef_Click(object sender, EventArgs e)
    {
      if (SeekToRecursiveItem != null)
        SeekToRecursiveItem(this, e);
    }

    private void addHighlight(object sender, EventArgs e)
    {
      icErrorReference.BackgroundStyle.BackColor = Color.Gold;
      icErrorReference.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorReference.BackgroundStyle.BorderBottomWidth = 1;
      icErrorReference.BackgroundStyle.BorderColor = Color.MediumBlue;
      icErrorReference.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorReference.BackgroundStyle.BorderLeftWidth = 1;
      icErrorReference.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorReference.BackgroundStyle.BorderRightWidth = 1;
      icErrorReference.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      icErrorReference.BackgroundStyle.BorderTopWidth = 1;
    }

    private void removeHighlight(object sender, EventArgs e)
    {
      icErrorReference.BackgroundStyle.BackColor = Color.Transparent;
      icErrorReference.BackgroundStyle.BorderBottomWidth = 0;
      icErrorReference.BackgroundStyle.BorderLeftWidth = 0;
      icErrorReference.BackgroundStyle.BorderRightWidth = 0;
      icErrorReference.BackgroundStyle.BorderTopWidth = 0;
    }

    private void ShowRecursiveMenu(object sender, EventArgs e)
    { cmsRecursive.Show(MousePosition); }

    private void ShowDirectMenu(object sender, EventArgs e)
    { cmsDirect.Show(MousePosition); }
  }
}
