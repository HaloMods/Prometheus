using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Settings
{
  /// <summary>
  /// Designates that a property should be persisted by the OptionsManager.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class PersistableOption : Attribute
  {
    public string Name;
    public string Category;
    public object DefaultValue;
    public OptionsFile File;
    public bool Encrypted;

    public PersistableOption(string name, string category, object defaultValue, OptionsFile file) :
      this(name, category, defaultValue, file, false) { ; }

    public PersistableOption(string name, string category, object defaultValue, OptionsFile file, bool encrypted)
    {
      Name = name;
      Category = category;
      DefaultValue = defaultValue;
      file = File;
      Encrypted = encrypted;
    }
  }

  /// <summary>
  /// A list of available target files that options can be persisted to.
  /// </summary>
  public enum OptionsFile
  {
    System,
    User
  }

  /// <summary>
  /// Designates an event as an update notifier for a property flagged as a PersistableOption.
  /// </summary>
  [AttributeUsage(AttributeTargets.Event)]
  public class OptionUpdateNotifier : Attribute
  {
    public string LinkedOptionName;
    public OptionUpdateNotifier(string linkedOptionName)
    {
      LinkedOptionName = linkedOptionName;
    }
  }
}
