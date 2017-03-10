
namespace Interfaces.Rendering.Utilties
{
  /// <summary>
  /// Provides high-prevision timing functions, as well as a method
  /// of automatically logging frame times and calculating the
  /// average FPS value.
  /// </summary>
  public class FPSCounter
  {
    private long m_frameStart;
    private long m_frameEnd;
    private long[] times;
    private int m_currentSample;
    private long m_runningTotal;
    private uint m_totalFrames;
    private long m_tickFrequency;
    private long m_lastElapsed;

    public uint TotalFramesCounted
    {
      get { return m_totalFrames; }
    }

    /// <summary>
    /// Gets the average FPS based on a running average.
    /// </summary>
    public float FPS
    {
      get
      {
        if (m_runningTotal < 1) m_runningTotal = times.Length;
        return (m_tickFrequency / (m_runningTotal / times.Length));
      }
    }

    /// <summary>
    /// Gets the FPS value based on the time elapsed since the last frame.
    /// </summary>
    public float ExactFPS
    {
      get
      {
        if (m_lastElapsed < 1) m_lastElapsed = 1;
        return m_tickFrequency / m_lastElapsed;
      }
    }

    public FPSCounter(int totalSamples)
    {
      times = new long[totalSamples];
      for (int x = 0; x < times.Length; x++)
        times[x] = 1;
      m_currentSample = 0;
      m_totalFrames = 0;
      HighResTimer.QueryPerformanceFrequency(ref m_tickFrequency);
    }

    public void BeginFrame()
    {
      HighResTimer.QueryPerformanceCounter(ref m_frameStart);
    }

    public void EndFrame()
    {
      HighResTimer.QueryPerformanceCounter(ref m_frameEnd);
      long elapsed = m_frameEnd - m_frameStart;
      if (elapsed < 1) elapsed = 1; // Ensure we're not negative or DBZ

      // Update our running total.
      m_runningTotal -= times[m_currentSample];
      times[m_currentSample] = elapsed;
      m_runningTotal += times[m_currentSample];

      // Store elapsed value for exact FPS calculations;
      m_lastElapsed = elapsed;

      m_currentSample++;
      m_totalFrames++;
      if (m_currentSample >= times.Length) m_currentSample = 0;
    }
  }
}