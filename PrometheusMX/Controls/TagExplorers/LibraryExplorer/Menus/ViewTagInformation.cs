using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Core.ArchiveFileSystem;
using Core.Libraries;
using DevComponents.DotNetBar;
using Prometheus.Properties;

namespace Prometheus.Controls.TagExplorers
{
  public partial class LibraryExplorer
  {
    private MenuDefinition viewTagInformation;

    private void SetupViewTagInformation()
    {
      viewTagInformation = new MenuDefinition(information, "&View Tag Information", view_map_list);
      viewTagInformation.ToolTipText = "Displays more detailed information about an unextracted tag.";
      viewTagInformation.Icon = Resources.information16;
    }

    private void view_map_list(MultiSourceTreeNode node, NodeInfo info)
    {
      TagArchive archive = (TagArchive)currentGame.GlobalTagLibrary;
      TagArchiveFileTableEntry entry =
        (TagArchiveFileTableEntry)archive.MissingFilesArchive.FileTable.GetEntry(info.Identifier, EntryType.File);

      List<string> maps = new List<string>();
      BitArray bits = new BitArray(BitConverter.GetBytes(entry.MapsBitmask));
      for (int x = 0; x < currentGame.Maps.Length; x++)
        if (bits[x])
          maps.Add(currentGame.Maps[x].Filename);

      string text = "The specified tag <b>" + info.Identifier + "</b> ";
      List<TagSet> sets = archive.BuildTagLocationList(new string[] { info.Identifier }, currentGame);
      if (sets.Count == 0)
        text += "does not exist in any of the available maps.";
      else
      {
        string mapfile = currentGame.Maps[sets[0].MapIndex].Filename;
        string mapListText = "exists in the following maps:<br />";
        foreach (string map in maps)
        {
          mapListText += "- " + map;
          if (map == mapfile)
            mapListText += " <i>*preferred source</i>";
          mapListText += "<br />";
        }
        text += mapListText;
      }
      MessageBoxEx.Show(text, "Unextracted Tag Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
  }
}