using System;

namespace Interfaces.Options
{
  /// <summary>
  /// Specifies a field as a global option.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field)]
  public class OptionAttribute : Attribute
  {
    private string name;
    private string group;
    private object dValue;

    /// <summary>
    /// Creates a new instance of the OptionAttribute class.
    /// </summary>
    /// <param name="optionName">name of option as it would be found in the options file</param>
    /// <param name="optionGroup">name of the group that the option resides in</param>
    public OptionAttribute(string optionName, string optionGroup, object defaultValue)
    {
      name = optionName;
      group = optionGroup;
      dValue = defaultValue;
    }

    /// <summary>
    /// Gets the name of this option.
    /// </summary>
    public string Name
    {
      get
      { return name; }
    }

    /// <summary>
    /// Gets the group the option resides in.
    /// </summary>
    public string Group
    {
      get
      { return group; }
    }

    /// <summary>
    /// Gets the default value for this option.
    /// </summary>
    public object Default
    {
      get
      { return dValue; }
    }
  }
}
