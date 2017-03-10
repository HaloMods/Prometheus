using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Interfaces
{
  public class NativeMethods
  {
    /// <value>
    /// Returns true on Windows Vista or newer operating systems; otherwise, false.
    /// </value>
    [Browsable(false)]
    public static bool IsVistaOrNewer
    {
      get { return Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6; }
    }

    #region Used by VistaStyledControls.cs Classes

    public const int TV_FIRST = 0x1100;
    public const int TVM_SETEXTENDEDSTYLE = TV_FIRST + 44;
    public const int TVM_GETEXTENDEDSTYLE = TV_FIRST + 45;
    public const int TVM_SETAUTOSCROLLINFO = TV_FIRST + 59;
    public const int TVS_NOHSCROLL = 0x8000;
    public const int TVS_EX_AUTOHSCROLL = 0x0020;
    public const int TVS_EX_FADEINOUTEXPANDOS = 0x0040;
    public const int GWL_STYLE = -16;

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern void SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    public extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

    #endregion
  }
}
