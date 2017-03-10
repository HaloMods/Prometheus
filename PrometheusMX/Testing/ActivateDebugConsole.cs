using System;
using CDebug = Core.Radiosity.ConsoleDebug;

namespace Prometheus.Testing
{
  [TestInfo("JamesD", "Activate Debug Console",
  "Display the console window error // debug lines write out to.")]
  public class ActivateDebugConsole : ITest
  {
    public void PerformTest()
    {
      Console.SetError(new CDebug.ConsoleWriter(Console.Error, CDebug.ConsoleColor.White,
        CDebug.ConsoleFlashMode.NoFlashing, false));
      CDebug.WinConsole.Initialize();
    }
  }
}