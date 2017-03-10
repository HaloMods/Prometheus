using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Settings
{
  /// <summary>
  /// Enables a class to interface with the OptionsManager to persist its data.
  /// </summary>
  public interface IPersistable
  {
    string InstanceName { get; }
    void Load();
    void Save();
  }
}
