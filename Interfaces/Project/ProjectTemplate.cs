using System;

namespace Interfaces.Project
{
  /// <summary>
  /// Defines the required tags that a project needs in order 
  /// to compile to a specified format.
  /// </summary>
  public class ProjectTemplate
  {
    private string name;
    private TemplateTag[] tagSet;

    public string Name
    {
      get { return name; }
    }

    public TemplateTag[] TagSet
    {
      get { return tagSet; }
    }

    public ProjectTemplate(string name, params TemplateTag[] tagSet)
    {
      this.name = name;
      this.tagSet = tagSet;
    }

    public override string ToString()
    {
      return name;
    }
  }
}
