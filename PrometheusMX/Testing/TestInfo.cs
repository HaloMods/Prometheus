using System;

namespace Prometheus.Testing
{
  /// <summary>
  /// Describes a test class.
  /// </summary>
  public class TestInfoAttribute : Attribute
  {
    private string developerName = "";
    private string name = "";
    private string description = "";

    /// <summary>
    /// The name of the developer who created the test.
    /// </summary>
    public string DeveloperName
    {
      get { return developerName; }
    }

    /// <summary>
    /// The name of the test.
    /// </summary>
    public string Name
    {
      get { return name; }
    }

    /// <summary>
    /// A description of the test.
    /// </summary>
    public string Description
    {
      get { return description; }
    }

    public TestInfoAttribute(string developerName, string name) : 
      this(developerName, name, "") { ; }

    public TestInfoAttribute(string developerName, string name, string description)
    {
      this.developerName = developerName;
      this.name = name;
      this.description = description;
    }
  }
}