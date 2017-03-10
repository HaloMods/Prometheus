using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace SpecialServices
{
  //SingleProgamInstance uses a mutex synchronization 
  //object to ensure that only one copy of process is running 
  //at a particular time.  It also allows for UI identification
  // of the intial process by bringing that window to the foreground.
  public class SingleProgramInstance : IDisposable
  {

    //Win32 API calls necesary to raise an unowned processs main window
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);

    private const int SW_RESTORE = 9;

    //private members 
    private Mutex _processSync;
    private bool _owned = false;


    public SingleProgramInstance()
    {
      //Initialize a named mutex and attempt to
      // get ownership immediately 
      _processSync = new Mutex(
          true, // desire intial ownership
          Assembly.GetExecutingAssembly().GetName().Name,
          out _owned);
    }

    public SingleProgramInstance(string identifier)
    {
      //Initialize a named mutex and attempt to
      // get ownership immediately.
      //Use an addtional identifier to lower
      // our chances of another process creating
      // a mutex with the same name.
      _processSync = new Mutex(
          true, // desire intial ownership
          Assembly.GetExecutingAssembly().GetName().Name + identifier,
          out _owned);
    }

    ~SingleProgramInstance()
    {
      //Release mutex (if necessary) 
      //This should have been accomplished using Dispose() 
      Release();
    }

    public bool IsSingleInstance
    {
      //If we don't own the mutex than
      // we are not the first instance.
      get { return _owned; }
    }

    public void RaiseOtherProcess()
    {
      Process proc = Process.GetCurrentProcess();
      // Using Process.ProcessName does not function properly when
      // the actual name exceeds 15 characters. Using the assembly 
      // name takes care of this quirk and is more accruate than 
      // other work arounds.
      string assemblyName =
          Assembly.GetExecutingAssembly().GetName().Name;
      foreach (Process otherProc in
          Process.GetProcessesByName(assemblyName))
      {
        //ignore "this" process
        if (proc.Id != otherProc.Id)
        {
          // Found a "same named process".
          // Assume it is the one we want brought to the foreground.
          // Use the Win32 API to bring it to the foreground.
          IntPtr hWnd = otherProc.MainWindowHandle;
          if (IsIconic(hWnd))
          {
            ShowWindowAsync(hWnd, SW_RESTORE);
          }
          SetForegroundWindow(hWnd);
          break;
        }
      }
    }

    private void Release()
    {
      if (_owned)
      {
        //If we own the mutex than release it so that
        // other "same" processes can now start.
        _processSync.ReleaseMutex();
        _owned = false;
      }
    }

    #region Implementation of IDisposable
    public void Dispose()
    {
      //release mutex (if necessary) and notify 
      // the garbage collector to ignore the destructor
      Release();
      GC.SuppressFinalize(this);
    }
    #endregion
  }
}