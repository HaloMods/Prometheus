namespace Prometheus.Testing
{
  /// <summary>
  /// Provides a base for creating tests within Prometheus.
  /// These tests are automatically instanciated and added to the UI at runtime.
  /// </summary>
  public interface ITest
  {
    /// <summary>
    /// The code to be tested is placed inside this method.
    /// </summary>
    void PerformTest();
  }
}
