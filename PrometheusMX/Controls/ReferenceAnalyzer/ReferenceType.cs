using System;

namespace Prometheus.Controls.ReferenceAnalyzer
{
  /// <summary>
  /// Exposes missing reference types.
  /// </summary>
  public enum ReferenceType : sbyte
  {
    Direct = 0,
    Recursive,
    Invalid = -1
  }
}
