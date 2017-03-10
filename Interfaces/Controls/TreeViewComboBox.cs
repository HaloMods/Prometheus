using System;
using System.Collections.Generic;
using System.Text;
using DevComponents.DotNetBar.Controls;
using System.Windows.Forms;

namespace Interfaces.Controls
{
  public class TreeViewComboBox : ComboBoxEx
  {
    ToolStripControlHost treeViewHost;
    ToolStripDropDown dropDown;

    private void SetupTreeView(TreeView treeView)
    {
      treeView.BorderStyle = BorderStyle.None;
      treeView.Dock = DockStyle.Fill;
      treeViewHost = new ToolStripControlHost(treeView);
      treeViewHost.AutoSize = false;

      // create drop down and add it
      dropDown = new ToolStripDropDown();
      dropDown.Items.Add(treeViewHost);
    }

    public TreeViewComboBox() { ; }

    public TreeView TreeView
    {
      get { return treeViewHost.Control as TreeView; }
      set { SetupTreeView(value); }
    }

    private void ShowDropDown()
    {
      treeViewHost.Size = new System.Drawing.Size(Width, DropDownHeight);
      dropDown.Show(this, 0, this.Height);
     }

    private const int WM_USER = 0x0400,
                      WM_REFLECT = WM_USER + 0x1C00,
                      WM_COMMAND = 0x0111,
                      CBN_DROPDOWN = 7;

    public static int HIWORD(int n)
    {
      return (n >> 16) & 0xffff;
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == (WM_REFLECT + WM_COMMAND))
      {
        if (HIWORD((int)m.WParam) == CBN_DROPDOWN)
        {
          ShowDropDown();
          return;

        }
      }
      base.WndProc(ref m);
    }

    // Remember to dispose the dropdown as it's not in the control collection. 
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (dropDown != null)
        {
          dropDown.Dispose();
          dropDown = null;
        }
      }
      base.Dispose(disposing);
    }
  }
}
