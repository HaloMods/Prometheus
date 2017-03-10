using System.Drawing;
using Interfaces.Pool;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class ValidReferencedState : NodeState
  {
    private ProjectNodeSource projectSource;

    public ValidReferencedState(ProjectNodeSource projectSource,
      string name, Bitmap expandedIcon, Bitmap collapsedIcon, Color foregroundColor,
      Color backgroundColor)
        : base(name, expandedIcon, collapsedIcon,
                                    foregroundColor, backgroundColor)
    {
      this.projectSource = projectSource;
      projectSource.ProjectReferences.FileAdded += SourceChanged;
      projectSource.ProjectReferences.FileRemoved += SourceChanged;
      projectSource.ProjectFolder.FileAdded += SourceChanged;
      projectSource.ProjectFolder.FileRemoved += SourceChanged;
    }

    private void SourceChanged(object sender, LibraryFileActionArgs e)
    {
      NodeInfo info = new NodeInfo(projectSource.GetNodeType(e.Filename), e.Filename);

      bool state = DetermineState(info);
      UpdateSubscribers(e.Filename, state);
    }

    protected bool FileExists(NodeInfo info)
    {
      return projectSource.ProjectFolder.FileExists(info.Identifier);
    }

    protected bool ReferenceExists(NodeInfo info)
    {
      return projectSource.ProjectReferences.FileExists(info.Identifier);
    }

    /// <summary>
    /// Determines the current state of the specified node.
    /// </summary>
    protected override bool DetermineState(NodeInfo info)
    {
      return FileExists(info) && ReferenceExists(info);
    }
  }

  public class MissingReferencedState : ValidReferencedState
  {
    public MissingReferencedState(ProjectNodeSource projectSource, string name, Bitmap expandedIcon, Bitmap collapsedIcon, Color foregroundColor, Color backgroundColor) 
      : base(projectSource, name, expandedIcon, collapsedIcon, foregroundColor, backgroundColor)
    { ; }

    protected override bool DetermineState(NodeInfo info)
    {
      return !FileExists(info) && ReferenceExists(info);
    }
  }

  public class UnreferencedState : ValidReferencedState
  {
    public UnreferencedState(ProjectNodeSource projectSource, string name, Bitmap expandedIcon, Bitmap collapsedIcon, Color foregroundColor, Color backgroundColor)
      : base(projectSource, name, expandedIcon, collapsedIcon, foregroundColor, backgroundColor)
    { ; }

    protected override bool DetermineState(NodeInfo info)
    {
      return FileExists(info) && !ReferenceExists(info);
    }
  }
}