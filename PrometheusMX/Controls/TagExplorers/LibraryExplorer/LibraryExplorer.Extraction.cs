using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Core.Libraries;
using Interfaces;
using Interfaces.Games;
using Interfaces.Pool;
using Prometheus.Controls.TagExplorers.Library;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private ExtractionProgressPanel progressPanel;
    private bool extractionActive = false;
    private Dictionary<string, string> extractionQueue = new Dictionary<string, string>();

    private void InitializeExtractionComponents()
    {
      // Setup the progress panel.
      progressPanel = new ExtractionProgressPanel();
      progressPanel.Visible = false;
      progressPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      progressPanel.Size = new Size(Width, Height);
      progressPanel.Location = new Point(0, 0);
      Controls.Add(progressPanel);
      progressPanel.BringToFront();
      progressPanel.Cancel += progressPanel_Cancel;
    }

    void progressPanel_Cancel(object sender, EventArgs e)
    {
      extractionActive = false;
    }

    delegate void ExtractFilesMethod(TagArchive archive, bool recursive, params string[] files);

    private void Extract(TagArchive archive, bool recusive, params string[] files)
    {
      extractionActive = true;
      int totalFilesExtracted = 0, totalFilesToExtract = 0;

      List<TagSet> sets = archive.BuildTagLocationList(files, currentGame);

      // Setup the counts.
      foreach (TagSet set in sets)
        totalFilesToExtract += set.Tags.Count;

      progressPanel.TotalExtracted = 0;
      progressPanel.TagCount = totalFilesToExtract;

      UniqueStringCollection additionalFiles = new UniqueStringCollection();
      try
      {
        foreach (TagSet set in sets)
        {
          string filename = currentGame.Maps[set.MapIndex].Filename;

          // UI Update
          progressPanel.CurrentMap = Path.GetFileName(filename);

          progressPanel.CurrentMap = filename;
          progressPanel.OpeningMap = true;
          IMapFile map = currentGame.CreateMapFileObject();
          map.Load(currentGame.MapFilePath + "\\" + filename);

          progressPanel.ExtractingTags = true;
          // Sort alphabetically so that folders don't get extracted out of order.
          set.Tags.Sort();

          // Extract the tags one by one.
          foreach (string tag in set.Tags)
          {
            // UI Update
            progressPanel.CurrentTag = tag;
            bool successful = true;
            try
            {
              // Check and see if we have attempted to cancel...
              if (!extractionActive) return;

              if (!archive.FileExists(tag))
              {
                byte[] data = map.GetTag(tag);
                archive.AddFile(tag, data);
              }
            }
            catch (Exception ex)
            {
              successful = false;
              Output.Write(OutputTypes.Error, "Unable to extract tag '" + tag + ex.Message);
            }
            if (successful)
              RemoveFromQueue(tag);
            totalFilesExtracted++;

            // UI Update
            progressPanel.TotalExtracted = totalFilesExtracted;

            if (recusive)
            {
              // Attempt to deserialize the tag, and get its dependencies.
              string tagExtension = Path.GetExtension(tag).Trim('.');
              Type tagType = currentGame.TypeTable.LocateEntryByName(tagExtension).TagType;
              TagPath poolPath = new TagPath(tag, currentGame.GameID, TagLocation.Archive);
              string[] dependencies = Core.Prometheus.Instance.Pool.GetTagReferences(poolPath.ToPath(), tagType);
              foreach (string dependency in dependencies)
                if (!archive.FileExists(dependency))
                  additionalFiles.Add(dependency);
            }
          }
        }
        if (additionalFiles.Count > 0)
        {
          progressPanel.Title = "Extracting dependencies...";
          // Extract the additional files.
          Extract(archive, true, additionalFiles.ToArray());
        }
      }
      finally
      {
        UpdateExtractionButton();
      }
    }

    private void AddToQueue(string filename)
    {
      if (!extractionQueue.ContainsKey(filename))
        extractionQueue.Add(filename, null);
    }
    private void RemoveFromQueue(string filename)
    {
      if (extractionQueue.ContainsKey(filename))
        extractionQueue.Remove(filename);
    }

    private void treeView_AfterCheck(object sender, TreeViewEventArgs e)
    {
      // We are only worried about nodes of types "unextractedfolder" and unextractedfile".
      if (!(e.Node is MultiSourceTreeNode)) return;
      MultiSourceTreeNode node = (MultiSourceTreeNode)e.Node;

      try
      {
        Cursor = Cursors.WaitCursor;
        foreach (NodeInfo entry in node.InfoEntries)
        {
          if (entry.NodeType is UnextractedHLTGroupNodeType)
          {
            string group = entry.Identifier.Trim('[', ']');
            foreach (TypeTableEntry typeEntry in currentGame.TypeTable.GetHighLevelTypes(group))
            {
              string[] files = ((TagArchive)currentGame.GlobalTagLibrary).MissingFilesArchive.GetFileList(
                "", typeEntry.FullName, true);

              foreach (string file in files)
              {
                if (e.Node.Checked)
                  AddToQueue(file);
                else
                  RemoveFromQueue(file);
              }
            }
          }
          else if (entry.NodeType is UnextractedHLTNodeType)
          {
            if (e.Node.Checked)
              AddToQueue(entry.Identifier);
            else
              RemoveFromQueue(entry.Identifier);
          }
          else if (entry.NodeType is UnextractedFolderNodeType)
          {
            TagArchiveNodeSource source = (TagArchiveNodeSource)entry.ParentSource;
            string[] files = source.Library.MissingFilesArchive.GetFileList(entry.Identifier, "*", true);
            foreach (string file in files)
              if (e.Node.Checked)
                AddToQueue(file);
              else
                RemoveFromQueue(file);
          }
          else if (entry.NodeType is UnextractedFileNodeType)
          {
            if (e.Node.Checked)
              AddToQueue(entry.Identifier);
            else
              RemoveFromQueue(entry.Identifier);
          }
        }
        UpdateExtractionButton();
        treeView.GetLastNode().EnsureVisible();
      }
      finally
      {
        Cursor = Cursors.Default;
      }
    }

    private void UpdateExtractionButton()
    {
      if (InvokeRequired)
      {
        Invoke(new MethodInvoker(delegate { UpdateExtractionButton(); }));
        return;
      }

      if (extractionQueue.Count > 0)
      {
        // Construct the button text.
        string itemType = (View == TagView.Tags) ? "Tag" : "Object";
        if (extractionQueue.Count > 1)
          itemType += "s"; // Plural :D
        biDecompile.Text = "<div align=\"center\" width=\"115\">Add <b>" + extractionQueue.Count + "</b> " + itemType + "</div>";
        esplitDecompile.Expanded = true;
      }
      else
        esplitDecompile.Expanded = false;

      biDecompile.Refresh();
      Application.DoEvents();
    }

    private void biDecompile_Click(object sender, EventArgs e)
    {
      TagArchive archive = (TagArchive)currentGame.GlobalTagLibrary;

      // Setup the progress panel.
      progressPanel.Init();
      progressPanel.Title = "Extracting files...";
      progressPanel.TotalExtracted = 0;
      progressPanel.TagCount = extractionQueue.Count;
      SetProgressPanelVisibilty(true);

      string[] files = new string[extractionQueue.Count];
      extractionQueue.Keys.CopyTo(files, 0);
      AsyncExtract(archive, btnObjectView.Checked, files);
    }

    void AsyncExtract(TagArchive archive, bool recursive, params string[] files)
    {
      Core.Rendering.RenderCore.Paused = true;
      ExtractFilesMethod extract = Extract;
      extract.BeginInvoke(archive, recursive, files, ExtractionComplete, null);
    }

    void ExtractionComplete(IAsyncResult result)
    {
      progressPanel.TotalExtracted = progressPanel.TagCount;
      SetProgressPanelVisibilty(false);
      Core.Rendering.RenderCore.Paused = false;
    }

    void SetProgressPanelVisibilty(bool visible)
    {
      if (progressPanel.InvokeRequired)
        progressPanel.Invoke(new SetProgressPanelVisibiltyDelegate(SetProgressPanelVisibilty), visible);
      else
        progressPanel.Visible = visible;
    }

    delegate void SetProgressPanelVisibiltyDelegate(bool visible);
  }
}