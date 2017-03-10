using System;

namespace Interfaces.DebugConsole
{
  /// <summary>
  /// Applied to target fields and methods to make them accessable from the DebugConsole.
  /// </summary>
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
  public class ConsoleAttribute : Attribute
  {
    private string usage;
    private string description;
    private string invocationName;

    /// <summary>
    /// Creates a new instance of the ConsoleAttribute class.
    /// </summary>
    /// <param name="invocationName">this is the string that the user will type in the console to execute this function or modify this value</param>
    public ConsoleAttribute(string invocationName)
    {
      this.invocationName = invocationName;
      this.description = String.Empty;
      this.usage = String.Empty;
    }

    /// <summary>
    /// Creates a new instance of the ConsoleAttribute class.
    /// </summary>
    /// <param name="invocationName">this is the string that the user will type in the console to execute this function or modify this value</param>
    public ConsoleAttribute(string invocationName, string description)
    {
      this.invocationName = invocationName;
      this.description = description;
      this.usage = String.Empty;
    }

    /// <summary>
    /// Creates a new instance of the ConsoleAttribute class.
    /// </summary>
    /// <param name="invocationName">this is the string that the user will type in the console to execute this function or modify this value</param>
    public ConsoleAttribute(string invocationName, string description, string usage)
    {
      this.invocationName = invocationName;
      this.description = description;
      this.usage = usage;
    }

    /// <summary>
    /// Gets the string that the user will type in the console to execute this function or modify this value.
    /// </summary>
    public string InvocationName
    {
      get
      { return invocationName; }
    }

    /// <summary>
    /// Gets a string describing what this method or field does.
    /// </summary>
    public string Description
    {
      get
      { return description; }
    }

    /// <summary>
    /// Gets a string defining the parameters of the represented method.
    /// </summary>
    public string Usage
    {
      get
      { return usage; }
    }
  }
}
