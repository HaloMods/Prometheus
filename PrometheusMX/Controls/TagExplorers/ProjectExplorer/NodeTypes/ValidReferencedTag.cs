using System.IO;
using DevComponents.DotNetBar;
using System.Drawing;
using System;
using Core;
using System.Text;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class TagNode : NodeType
  {
    public TagNode() : this("tagnode", 2, 1, false) { ; }

    protected TagNode(string name, int sortingPriority, int typePriority, bool displayCheckbox)
      :base(name, sortingPriority, typePriority, displayCheckbox) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      return new NodeInfo[0]; // No children in this NodeType.
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      string parentPath = Path.GetDirectoryName(info.Identifier).Trim('\\');
      NodeInfo newInfo;
      if (parentPath == "")
        newInfo = new NodeInfo(ParentSource.GetNodeType<RootNodeType>(), parentPath);
      else
        newInfo = new NodeInfo(ParentSource.GetNodeType<FolderNodeType>(), parentPath);
      return newInfo;
    }

    /// <summary>
    /// Returns a value indicating if the specified NodeInfo contains children.
    /// </summary>
    public override bool HasChildren(NodeInfo info)
    {
      return false; // No children in this NodeType.
    }

    /// <summary>
    /// Gets the tree-formatted path to the specified identifier.
    /// ex: 'NodeSourceName|ChildNodeName\ObjectName'
    /// </summary>
    public override string GetTreePath(NodeInfo info)
    {
      return ParentSource.Name + "|" + info.Identifier.Replace("|", "\\");
    }

    /// <summary>
    /// Returns a formatted node name based on the supplied identifier.
    /// </summary>
    public override string GetNodeName(string identifier)
    {
      return Path.GetFileName(identifier);
    }

    /// <summary>
    /// Returns a bool indicating is the NodeType supports renaming.
    /// </summary>
    public override bool SupportsRenaming
    {
      get { return true; }
    }

    /// <summary>
    /// This method will construct a new identifier based on the node name given.
    /// </summary>
    public override bool Rename(NodeInfo info, string newNodeName)
    {
      // Trim off the last item in the path and replace with newNodeName.
      int lastSlash = info.Identifier.LastIndexOf("\\");
      string newIdentifier = info.Identifier.Substring(0, lastSlash + 1) + newNodeName;
      if (info.Identifier == newIdentifier)
        return false;
      else
      {
        string oldIdentifier = info.Identifier;
        info.Identifier = newIdentifier;
        OnNodeRenamed(oldIdentifier, info.Identifier);
        return true;
      }
    }

    /// <summary>
    /// Update the NodeInfo identifier of a child node.
    /// </summary>
    public override void RenameChild(NodeInfo info, NodeInfo newParentInfo)
    {
      int lastSlash = info.Identifier.LastIndexOf("\\");
      string childName = info.Identifier.Substring(lastSlash);
      info.Identifier = newParentInfo.Identifier + childName;
    }

    public override SuperTooltipInfo GetTooltip(NodeInfo info)
    {
      // Get the modified date for the specified file.
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;

      string filename = Path.GetFileName(info.Identifier);
      string baseFilename = Path.GetFileNameWithoutExtension(info.Identifier);
      string fileExtension = Path.GetExtension(info.Identifier).TrimStart('.');
      int noteCount = 0;
      int revisionCount = 0;

      StringBuilder sb = new StringBuilder();
      sb.Append("<b>Name: </b>");
      sb.Append(baseFilename);
      sb.Append("<br/>");

      sb.Append("<b>Type: </b>");
      sb.Append(fileExtension);
      sb.Append("<br/><br/>");
      
      string fileSize = "";
      if (source.ProjectManager.ProjectFolder.FileExists(info.Identifier))
      {
        sb.Append("<b>Notes: </b>");
        sb.Append(noteCount);
        sb.Append("<br/>");

        sb.Append("<b>Revisions: </b>");
        sb.Append(revisionCount);
        sb.Append("<br/>");

        DateTime modified = source.ProjectManager.ProjectFolder.GetModifiedTime(info.Identifier);
        sb.Append("<b>Modified: </b>");
        sb.Append(Helpers.ElapsedTimeString(modified));
        sb.Append("<br/>");

        fileSize = "<b>Size:</b> " + String.Format("{0:0,0}", source.ProjectManager.ProjectFolder.GetFileSize(info.Identifier)) + " bytes.";
      }
      else
        sb.Append("<font color=\"red\">File does not exist.</font>");

      return new SuperTooltipInfo(
        filename, fileSize, sb.ToString(), null, null, eTooltipColor.System, true,
        String.IsNullOrEmpty(fileSize) ? false : true, new Size(0, 0));
    }
  }
}