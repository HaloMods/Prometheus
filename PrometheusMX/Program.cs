using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Prometheus.Dialogs;
using SpecialServices;

namespace Prometheus
{
  /// <summary>
  /// Application initializer.
  /// </summary>
  internal static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      using (SingleProgramInstance spi = new SingleProgramInstance("x5k6yz"))
      {
        if (spi.IsSingleInstance)
        {
          StartApplication();
        }
        else
        {
          // For now, we're just gonna check for one argument.. but eventually we will
          // need to put in a commandline parser (there's on already done on CodeProject).
          bool restarting = false;
          if (args.Length > 0)
            if (args[0] == "-restart")
              restarting = true;

          if (restarting)
          {
            if (spi.IsSingleInstance)
            {
              StartApplication();
            }
            else
            {
              Process[] processes = Process.GetProcessesByName(Assembly.GetExecutingAssembly().GetName().Name);

              foreach (Process process in processes)
              {
                if (!process.Id.Equals(Process.GetCurrentProcess().Id)) // Not this instance?
                  process.Kill(); // Kill it with fire!
              }

              StartApplication();
            }
          }
          else
            spi.RaiseOtherProcess();
        }
      }
    }

    private static void StartApplication()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

#if RELEASE
      // Global unhandled UI thread exceptions handler
      Application.ThreadException += new ThreadExceptionEventHandler(UnhandledUIExceptionHandler);
      Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

      // Global unhandled non-UI thread exceptions handler. 
      AppDomain.CurrentDomain.UnhandledException +=
          new UnhandledExceptionEventHandler(UnhandledThreadExceptionHandler);
#endif

      Application.Run(new PrometheusGUI());
    }

    // TODO: Generate more useful information.
    private static void UnhandledUIExceptionHandler(object sender, ThreadExceptionEventArgs e)
    {
      HandleCrash(e.Exception.Message);
    }

    private static void UnhandledThreadExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
      string exceptionText = String.Empty;
      if (e.ExceptionObject is Exception)
      {
        Exception ex = (Exception)e.ExceptionObject;
        exceptionText += ex.Message + "\r\n" + (ex.StackTrace != null ? ex.StackTrace : "\nNo stack trace was available.");
      }
      else
        exceptionText += e.ExceptionObject.GetType() + " - " + e.ExceptionObject;

      HandleCrash(exceptionText);      
    }

    private static void HandleCrash(string text)
    {
      // TODO: Implement some sort of logging of this error, and optional submission to HaloDev.
      // TODO: Wrap CrashDialog inside of a public class that invokes the GUI.
      if (CrashDialogForm.Display(text) == DialogResult.Retry)
      {
        string s = Process.GetCurrentProcess().MainModule.FileName;

        ProcessStartInfo info = new ProcessStartInfo(s, "-restart");
        info.UseShellExecute = false;
#if DEBUG
        info.ErrorDialog = true;
#endif
        Process.Start(info);
      }
      Application.Exit();
    }
  }
}
