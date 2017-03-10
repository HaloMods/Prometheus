using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Controls.ReferenceAnalyzer
{
  public partial class ReferenceContainer : UserControl
  {
    public ReferenceContainer()
    {
      InitializeComponent();
    }

    public void AddItem(ReferenceItem item)
    {
      item.Dock = DockStyle.Top;
      ipContainer.Controls.Add(item);
      if (CountChanged != null)
        CountChanged(this, EventArgs.Empty);
    }

    public void ClearItems()
    {
      ipContainer.Controls.Clear();
      if (CountChanged != null)
        CountChanged(this, EventArgs.Empty);
    }

    public int Count
    {
      get
      { return ipContainer.Controls.Count; }
    }

    public event EventHandler CountChanged;
  }
}
