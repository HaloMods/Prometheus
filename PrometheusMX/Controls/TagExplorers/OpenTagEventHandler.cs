using System;
using System.Collections.Generic;
using System.Text;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers
{
  /// <summary>
  /// Represents a method that handles opening a tag.
  /// </summary>
  public delegate void OpenTagHandler(object sender, OpenTagEventArgs e);

  /// <summary>
  /// Provides data for an event that signals the opening of a tag.
  /// </summary>
  public class OpenTagEventArgs : EventArgs
  {
    private TagPath tagPath;

    /// <summary>
    /// The TagPath at which the tag is located.
    /// </summary>
    public TagPath TagPath
    {
      get { return tagPath; }
    }

    public OpenTagEventArgs(TagPath tagPath)
    {
      this.tagPath = tagPath;
    }
  }
}