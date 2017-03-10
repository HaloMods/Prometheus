using System;
using System.ComponentModel;
using System.Windows.Forms;
using Interfaces;

namespace Prometheus.ThirdParty.Controls
{
  /// Supports two blog entries by Daniel Moth:
  /// http://www.danielmoth.com/Blog/2007/01/treeviewvista.html
  ///  AND
  /// http://www.danielmoth.com/Blog/2006/12/tvsexautohscroll.html
  public class VistaTreeView : TreeView, ISupportInitialize
  {
    protected override CreateParams CreateParams
    {
      get
      {
        if (!NativeMethods.IsVistaOrNewer) // It is not a Vista box, abort.
          return base.CreateParams;

        CreateParams cp = base.CreateParams;
        cp.Style |= NativeMethods.TVS_NOHSCROLL; // lose the horizotnal scrollbar

        return cp;
      }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!NativeMethods.IsVistaOrNewer) // It is not a Vista box, abort.
        return;

      // get style
      int dw = NativeMethods.SendMessage(Handle,
                                         NativeMethods.TVM_GETEXTENDEDSTYLE, 0, 0);

      // Update style
      dw |= NativeMethods.TVS_EX_AUTOHSCROLL; // autoscroll horizontaly
      dw |= NativeMethods.TVS_EX_FADEINOUTEXPANDOS; // auto hide the +/- signs

      // set style
      NativeMethods.SendMessage(Handle,
                                NativeMethods.TVM_SETEXTENDEDSTYLE, 0, dw);

      // little black/empty arrows and blue highlight on treenodes
      NativeMethods.SetWindowTheme(Handle, "explorer", null);
    }

    ///<summary>
    ///Signals the object that initialization is starting.
    ///</summary>
    ///
    public void BeginInit()
    {
    }

    ///<summary>
    ///Signals the object that initialization is complete.
    ///</summary>
    ///
    public void EndInit()
    {
      if (!DesignMode)
      {
        if (NativeMethods.IsVistaOrNewer)
        {
          ShowLines = false;
          HotTracking = true;
        }
        else
        {
          ShowLines = true;
          HotTracking = false;
        }
      }
    }
  }

  public class VistaListView : ListView
  {
    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);

      if (!NativeMethods.IsVistaOrNewer) // It is not a Vista box, abort.
        return;

      NativeMethods.SetWindowTheme(Handle, "explorer", null);
    }
  }
}