using System.Collections.Generic;
using System.IO;
using DevComponents.DotNetBar;
using System;
using System.Drawing;

namespace Prometheus.Controls.TagExplorers.Project
{
  public class FolderNodeType : NodeType
  {
    public FolderNodeType() : base("folder", 10, 1, false) { ; }

    protected FolderNodeType(string name, int sortingPriority, int typePriority, bool displayCheckbox)
      : base(name, sortingPriority, typePriority, displayCheckbox) { ; }

    /// <summary>
    /// Returns an array of NodeInfo entries that exist beneath the specified NodeInfo.
    /// </summary>
    public override NodeInfo[] GetChildNodes(NodeInfo info)
    {
      ProjectNodeSource source = (ProjectNodeSource)ParentSource;
      List<NodeInfo> children = new List<NodeInfo>();
      
      // Referenced files/folders
      foreach (string folder in source.ProjectReferences.GetFolderList(info.Identifier))
        children.Add(new NodeInfo(source.GetNodeType<FolderNodeType>(), folder));
      foreach (string file in source.ProjectReferences.GetFileList(info.Identifier))
      {
        NodeType nodeType = source.GetNodeType(file);
        children.Add(new NodeInfo(nodeType, file));
      }

      foreach (string folder in source.ProjectFolder.GetFolderList(info.Identifier))
        children.Add(new NodeInfo(source.GetNodeType<FolderNodeType>(), folder));
      foreach (string file in source.ProjectFolder.GetFileList(info.Identifier))
      {
        NodeType nodeType = source.GetNodeType(file);
        children.Add(new NodeInfo(nodeType, file));
      }
      return children.ToArray();
    }

    /// <summary>
    /// Constructs the parent NodeInfo based on the values in the supplied NodeInfo.
    /// </summary>
    public override NodeInfo GetParentNodeInfo(NodeInfo info)
    {
      string parentPath = Path.GetDirectoryName(info.Identifier);
      NodeInfo newInfo;
      if (parentPath == "")
        newInfo = new NodeInfo(ParentSource.GetNodeType<RootNodeType>(), parentPath);
      else
        newInfo = new NodeInfo(ParentSource.GetNodeType<FolderNodeType>(), parentPath);
      return newInfo;
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
      string newIdentifier = info.Identifier.Substring(0, lastSlash+1) + newNodeName;
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

      string folderName = Path.GetFileNameWithoutExtension(info.Identifier + ".hack");

      // Count the number of files unde the specified path.
      int fileCount = source.ProjectFolder.GetFileList(info.Identifier, null, true).Length;

      return new SuperTooltipInfo(
        folderName, "", "<b>Tag Count:</b> " + String.Format("{0:,0}", fileCount), null, null, eTooltipColor.System, true,
        false, new Size(0, 0));
    }
  }
}