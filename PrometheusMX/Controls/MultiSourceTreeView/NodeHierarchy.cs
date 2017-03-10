using System;
using System.Collections.Generic;
using System.Drawing;

namespace Prometheus.Controls
{
  /// <summary>
  /// Represents a hierchy of NodeSources that will be displayed under
  /// a root node in a MultiSourceTreeView.
  /// </summary>
  public class NodeHierarchy : IDisposable
  {
    List<NodeSource> sources = new List<NodeSource>();
    Bitmap rootNodeIcon;
    string rootNodeText;
    int rootNodeImageIndex = -1;

    /// <summary>
    /// Gets a list of NodeSources in this NodeHierarchy.
    /// </summary>
    public List<NodeSource> NodeSources
    {
      get { return sources; }
    }

    /// <summary>
    /// Gets or sets the Icon that will be used by the root node.
    /// </summary>
    public Bitmap RootNodeIcon
    {
      get { return rootNodeIcon; }
      set { rootNodeIcon = value; }
    }

    /// <summary>
    /// Gets or sets the text that will be displayed by the root node.
    /// </summary>
    public string RootNodeText
    {
      get { return rootNodeText; }
      set { rootNodeText = value; }
    }

    /// <summary>
    /// Gets or sets the image index of the root node's icon within an ImageList.
    /// </summary>
    public int RootNodeImageIndex
    {
      get { return rootNodeImageIndex; }
      set { rootNodeImageIndex = value; }
    }

    /// <summary>
    /// Creates a new instance of the NodeHierarchy class with the specified rootNodeText and rootNodeIcon.
    /// </summary>
    public NodeHierarchy(string rootNodeText, Bitmap rootNodeIcon)
    {
      this.rootNodeText = rootNodeText;
      this.rootNodeIcon = rootNodeIcon;
    }

    ///<summary>
    ///Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    ///</summary>
    public void Dispose()
    {
      foreach (NodeSource source in sources)
        source.Dispose();
    }
  }
}
