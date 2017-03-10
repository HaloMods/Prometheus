using System.Text;
using System.Text.RegularExpressions;

namespace Interfaces.Pool
{
  /// <summary>
  /// Provides a standard means of representing paths to tags located in various resources.
  /// Can emit and parse strings representing the path, which can contain any/all of the
  /// information that the TagPath is able to represent.
  /// </summary>
  public class TagPath
  {
    private string game = "";
    private string path = "";
    private string extension = "";
    private string locationName = "";
    private string attachmentName = "";
    private TagLocation location;

    /// <summary>
    /// Gets or sets the game identifier that the tag belongs to.
    /// </summary>
    public string Game
    {
      get
      { return game; }
      set
      { game = value; }
    }

    /// <summary>
    /// Gets or sets the hierarchical path to the tag.
    /// </summary>
    public string Path
    {
      get
      { return path.Trim('\\'); }
      set
      { path = value.Trim('\\'); }
    }

    /// <summary>
    /// Gets or sets the tag file extension.
    /// </summary>
    public string Extension
    {
      get
      { return extension; }
      set
      { extension = value; }
    }

    /// <summary>
    /// Gets or sets the name of the prefab or shared library that the tag resides in.
    /// </summary>
    public string LocationName
    {
      get
      { return locationName; }
      set
      { locationName = value; }
    }

    /// <summary>
    /// Gets or sets the name of the the tag attachment represented by this path.
    /// </summary>
    public string AttachmentName
    {
      get
      { return attachmentName; }
      set
      { attachmentName = value; }
    }

    /// <summary>
    /// Gets or sets the location the tag resides in.
    /// </summary>
    public TagLocation Location
    {
      get
      { return location; }
      set
      { location = value; }
    }

    public static bool IsFullyQualifiedPath(string path)
    {
      // TODO: Think about using regex, or at least a more reliable algorithm.
      return path.StartsWith("<");
    }

    /// <summary>
    /// Returns a TagPath object based on the current path with a new location.
    /// </summary>
    /// <param name="newLocation">The new location to be represented by the path.</param>
    public TagPath NewLocation(TagLocation newLocation)
    {
      TagPath path = new TagPath(ToPath());
      path.location = newLocation;
      return path;
    }

    public TagPath(string path, string game, TagLocation location) : this(path, game, location, "") { ; }
    public TagPath(string path, string game, TagLocation location, string locationName)
    {
      //this.extension = System.IO.Path.GetExtension(path).TrimStart('.');
      //this.path = path.Substring(0, path.Length - (extension.Length + 1));
      Parse(path);
      this.game = game;
      this.location = location;
      this.locationName = locationName;
    }

    public TagPath(string fullyQualifiedPath)
    {
      Parse(fullyQualifiedPath);
    }
    
    /// <summary>
    /// Parses a given tag path into its constituent parts.
    /// </summary>
    /// <param name="tagPath">path to be parsed</param>
    public void Parse(string tagPath)
    {
      string regexPattern = @"(\<(?<game>\w*)\>)?((?<source>\w):\\)?(?<path>.*)";
      Match match = Regex.Match(tagPath, regexPattern);
      game = match.Groups["game"].Value;
      switch (match.Groups["source"].Value)
      {
        case "p":
          location = TagLocation.Project;
          break;
        case "g":
          location = TagLocation.Archive;
          break;
        case "":
          location = TagLocation.Auto;
          break;
      }

      string relativePath = match.Groups["path"].Value;
      if (relativePath.Contains("|"))
      {
        // This path point to an attachment.
        string[] parts = relativePath.Split('|');
        relativePath = parts[0];
        attachmentName = parts[1];
      }
      path = System.IO.Path.GetDirectoryName(relativePath);
      string filename = System.IO.Path.GetFileNameWithoutExtension(relativePath);
      extension = System.IO.Path.GetExtension(relativePath).TrimStart('.');
      path = path + "\\" + filename;
      path = path.Trim('\\');
    }

    /// <summary>
    /// Creates the fully qualified path represented by this TagPath.
    /// </summary>
    public string ToPath()
    {
      return ToPath(PathFormat.FullyQualified);
    }

    /// <summary>
    /// Creates a string-based tag path out of the arguments specified in this structure.
    /// </summary>
    /// <returns>a tag path</returns>
    public string ToPath(PathFormat format)
    {
      StringBuilder path = new StringBuilder();
      if (format == PathFormat.FullyQualified)
      {
        path.Append('<');
        path.Append(game);
        path.Append('>');
      }

      if (format == PathFormat.FullyQualified || format == PathFormat.ExplicitLocation)
      {
        switch (location)
        {
          case TagLocation.Archive:
            path.Append("g:\\");
            break;
          case TagLocation.Project:
            path.Append("p:\\");
            break;
          case TagLocation.Prefab:
            path.Append('[');
            path.Append(locationName);
            path.Append("]:\\");
            break;
          case TagLocation.Shared:
            path.Append('{');
            path.Append(locationName);
            path.Append("}:\\");
            break;
        }
      }

      path.Append(this.path);
      if (extension != null)
      {
        path.Append('.');
        path.Append(extension);
      }

      if (attachmentName != "")
      {
        path.Append('|');
        path.Append(attachmentName);
      }
      return path.ToString();
    }

    public override string ToString()
    { return ToPath(); }
  }

  /// <summary>
  /// Specifies how much information to represent when converting a TagPath to a string.
  /// </summary>
  public enum PathFormat
  {
    /// <summary>
    /// Returns all elements of the path, including game id.
    /// </summary>
    FullyQualified,
    /// <summary>
    /// Returns the explicit path, not including the game id.
    /// </summary>
    ExplicitLocation,
    /// <summary>
    /// Returns just the relative path with no explicit source or game id.
    /// </summary>
    Relative
  }
}
