namespace Core.Project
{
  /// <summary>
  /// A tag inside a project file.
  /// </summary>
  public class ProjectTag
  {
    private string templateElement;
    private string filename;
    private string basePath;

    /// <summary>
    /// Gets the string identifier of the template element that this tag corresponds to.
    /// </summary>
    public string TemplateElement
    {
      get { return templateElement; }
    }

    /// <summary>
    /// Gets or sets the path of the tag.
    /// </summary>
    public string Path
    {
      get { return basePath.Trim('\\') + "\\" + filename; }
      set
      {
        basePath = System.IO.Path.GetDirectoryName(value);
        filename = System.IO.Path.GetFileName(value);
      }
    }

    public ProjectTag(string templateElement, string path)
    {
      this.templateElement = templateElement;
      Path = path;
    }
  }
}
