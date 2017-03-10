using System;
using System.Collections.Generic;
using Core.Project;
using Interfaces.Libraries;
using Interfaces.Pool;
using Interfaces.Project;

namespace Interfaces.Project
{
  /// <summary>
  /// Encapsulates a list of ProjectTag elements that are associated with a project template.
  /// </summary>
  public class TemplateTagList
  {
    private Dictionary<string, ProjectTag> templateTags = new Dictionary<string, ProjectTag>();
    private FileHierarchy templateTagHierarchy = new FileHierarchy();
    private ProjectTemplate baseTemplate;

    public TemplateTagList(ProjectTemplate baseTemplate)
    {
      this.baseTemplate = baseTemplate;
    }

    // TODO: Wrap seveal of these methods so that consumers of this class do not have direct access to the templateTagHierarchy object.
    public FileHierarchy TemplateTagHierarchy
    {
      get { return templateTagHierarchy; }
    }

    public ProjectTag this[string templateElement]
    {
      get
      {
        ProjectTag tag = templateTags[templateElement];
        if (tag.Path.StartsWith("p:\\"))
          return tag;
        else
          return null;
      }
    }

    public bool ContainsTemplateElement(string elementName)
    {
      if (templateTags.ContainsKey(elementName))
        if (templateTags[elementName].Path.StartsWith("p:\\"))
          return true;
      return false;
    }

    public bool ContainsPath(string path)
    {
      if (!path.StartsWith("p:\\"))
        return false;

      foreach (ProjectTag tag in templateTags.Values)
        if (tag.Path == path)
          return true;
      return false;
    }

    /// <summary>
    /// Adds the the specified template element/path combination to the list.
    /// </summary>
    public void Add(string templateElement, TagPath tagPath)
    {
      // Make sure that the template element that is attempting to be added exists in
      // the related Template for this list.
      bool validTemplate = false;
      foreach (TemplateTag templateTag in baseTemplate.TagSet)
        if (templateTag.Name == templateElement)
        {
          validTemplate = true;
          break;
        }

      if (validTemplate)
      {
        // Get the explicit location and add that path to the elements
        // (Or update an existing path if the named element already exists.)
        string path = tagPath.ToPath(PathFormat.ExplicitLocation);
        ProjectTag tag = new ProjectTag(templateElement, path);
        if (!templateTags.ContainsKey(templateElement))
          templateTags.Add(templateElement, tag);
        else
          templateTags[templateElement].Path = path;

        // If the tag is from the project, store the relative path
        // (no "p:\" prefix) to the templateTagHierarchy.
        if (tagPath.Location == TagLocation.Project)
        {
          templateTagHierarchy.Add(tagPath.ToPath(PathFormat.Relative));
          // We added a new file yar!!
          OnFileAdded(path, templateElement);

          TemplateTag templateTag = GetTemplateTag(templateElement);
          if (templateTag != null)
          {
            // Again, haxzorzz!!
            TagPath lePath = new TagPath(templateTag.DefaultFile + "." + templateTag.FileType,
              "", TagLocation.Archive);
            OnFileRemoved(lePath.ToPath(PathFormat.ExplicitLocation), templateTag.Name);
          }
        }
      }
      else
      {
        throw new Exception("The specified element '" + templateElement + "' does not exist in the template '" +
                            baseTemplate.Name + "'");
      }
    }

    /// <summary>
    /// Update the path that corresponds to the specified element.
    /// </summary>
    public void UpdateElementPath(string element, string newPath)
    {
      if (templateTags.ContainsKey(element))
      {
        if (templateTags[element].Path != newPath)
        {
          ProjectTag tag = templateTags[element];
          templateTags.Remove(element);
          OnFileRemoved(tag.Path, element);

          tag.Path = newPath;
          templateTags.Add(element, tag);
          OnFileAdded(newPath, element);
        }
      }
    }

    /// <summary>
    /// Update the path that corresponds to the specified element.
    /// </summary>
    public void UpdateElementPath(string element, TagPath newTagPath)
    {
      string newPath = newTagPath.ToPath(PathFormat.ExplicitLocation);
      UpdateElementPath(element, newPath);
    }

    protected void OnFileAdded(string path, string templateElement)
    {
      if (FileAdded != null)
        FileAdded(this, new TemplateTagActionArgs(path, templateElement));
    }

    protected void OnFileRemoved(string path, string templateElement)
    {
      if (FileRemoved != null)
        FileRemoved(this, new TemplateTagActionArgs(path, templateElement));
    }

    public void RemoveByElementName(string elementName)
    {
      ProjectTag[] values = new ProjectTag[templateTags.Values.Count];
      templateTags.Values.CopyTo(values, 0);
      foreach (ProjectTag tag in values)
        if (tag.TemplateElement == elementName)
        {
          templateTags.Remove(tag.TemplateElement);
          TagPath basePath = new TagPath(tag.Path);
          if (basePath.Location == TagLocation.Project)
          {
            string relativePath = basePath.ToPath(PathFormat.Relative);
            templateTagHierarchy.RemoveFile(relativePath);
          }
          OnFileRemoved(tag.Path, elementName);

          TemplateTag templateTag = GetTemplateTag(elementName);
          if (templateTag != null)
          {
            // Generate the FileAdded event with the default filename - this is so that the
            // ProjectExplorer can update it's Essential Tags list.
            // This is kind of hackish, because the ProjectFile shouldn't be worrying
            // about the PE at all.  A more appropriate place to put this functionality would
            // be in the ProjectNodeSource, but that would complicate some things and would
            // force me to write additional code.  And we all know how lazy I am! :D
            TagPath path = new TagPath(templateTag.DefaultFile + "." + templateTag.FileType,
              "", TagLocation.Archive);
            OnFileAdded(path.ToPath(PathFormat.ExplicitLocation), templateTag.Name);
          }
        }
    }

    public TemplateTag GetTemplateTag(string element)
    {
      foreach (TemplateTag tag in baseTemplate.TagSet)
        if (tag.Name == element)
          return tag;
      return null;
    }

    public string GetTemplateNameBypath(string path)
    {
      foreach (ProjectTag tag in templateTags.Values)
        if (tag.Path == path)
          return tag.TemplateElement;
      return "";
    }

    public void RemoveByTagPath(string path)
    {
      ProjectTag[] values = new ProjectTag[templateTags.Values.Count];
      templateTags.Values.CopyTo(values, 0);
      foreach (ProjectTag tag in values)
        if (tag.Path == path)
          RemoveByElementName(tag.TemplateElement);
    }

    public event EventHandler<TemplateTagActionArgs> FileAdded;

    public event EventHandler<TemplateTagActionArgs> FileRemoved;

    public ProjectTag[] GetTemplateList()
    {
      ProjectTag[] tags = new ProjectTag[templateTags.Values.Count];
      templateTags.Values.CopyTo(tags, 0);
      return tags;
    }
  }

  public class TemplateTagActionArgs : EventArgs
  {
    private string filename;
    private string templateElement;

    public string Filename
    {
      get { return filename; }
    }

    public string TemplateElement
    {
      get { return templateElement; }
    }

    public TemplateTagActionArgs(string filename, string templateElement)
    {
      this.filename = filename;
      this.templateElement = templateElement;
    }
  }
}
