using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Rendering.Utilties
{
  public class HighResTimer
  {
    private long BeginTime;
    private long EndTime;
    private long Frequency;
    public HighResTimer()
    {
      BeginTime = 0;
      EndTime = 0;
      QueryPerformanceFrequency(ref Frequency);
    }
    public void ResetTimer()
    {
      QueryPerformanceCounter(ref BeginTime);
    }
    public double GetElapsedTime()
    {
      QueryPerformanceCounter(ref EndTime);
      double elapsed_ticks = EndTime - BeginTime;
      double delta_time = elapsed_ticks / (double)Frequency;

      return (delta_time);
    }
    [System.Security.SuppressUnmanagedCodeSecurity]
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    public extern static short QueryPerformanceCounter(ref long x);
    [System.Security.SuppressUnmanagedCodeSecurity]
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    public extern static short QueryPerformanceFrequency(ref long x);
  }
}
