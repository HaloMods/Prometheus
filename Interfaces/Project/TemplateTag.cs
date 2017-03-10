using System;

namespace Interfaces.Project
{
  /// <summary>
  /// A tag entry within a ProjectTemplate.
  /// </summary>
  public class TemplateTag
  {
    private string fileType;
    private string name;
    private string defaultFile;

    public string FileType
    {
      get { return fileType; }
    }

    public string Name
    {
      get { return name; }
    }

    public string DefaultFile
    {
      get { return defaultFile; }
    }

    public TemplateTag(string fileType, string name) : this(fileType, name, null) { ; }

    public TemplateTag(string fileType, string name, string defaultFile)
    {
      this.fileType = fileType;
      this.name = name;
      this.defaultFile = defaultFile;
    }
  }
}
