using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Prometheus.Testing
{
  public partial class ProgressDialog : Form
  {
    public string Info1
    {
      get { return lblInfo1.Text; }
      set { lblInfo1.Text = value; }
    }
    public string Info2
    {
      get { return lblInfo2.Text; }
      set { lblInfo2.Text = value; }
    }
    public int Value
    {
      get { return pgbProgress.Value; }
      set { pgbProgress.Value = value; }
    }
    public int Maximum
    {
      get { return pgbProgress.Maximum; }
      set { pgbProgress.Maximum = value; }
    }
    public int Minimum
    {
      get { return pgbProgress.Minimum; }
      set { pgbProgress.Minimum = value; }
    }

    public ProgressDialog()
    {
      InitializeComponent();
    }
  }
}