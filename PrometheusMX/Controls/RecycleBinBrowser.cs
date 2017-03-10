using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Interfaces.Libraries;
using Core;
using System.IO;
using Interfaces;
using Interfaces.Properties;
using Prometheus.Properties;
using Prometheus.ThirdParty.Controls;
using DevComponents.DotNetBar;
using Interfaces.UserInterface;

namespace Prometheus.Controls
{
  public partial class RecycleBinBrowser : UserControl, IDocument
  {
    private RecycleBin recycleBin;

    public RecycleBinBrowser()
    {
      InitializeComponent();
      biDetailsView.Checked = true;
    }

    void recycleBin_BeforeOverwriteFolder(object sender, CancelEventArgs e)
    {
      string text = "The folder that is being restored already exists and will be overwritten.\r\nDo you wish to proceed?";
      if (MessageBoxEx.Show(text, "Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        e.Cancel = true;
    }

    void recycleBin_BeforeOverwriteFile(object sender, CancelEventArgs e)
    {
      string text = "The file that is being restored already exists and will be overwritten.\r\nDo you wish to proceed?";
      if (MessageBoxEx.Show(text, "Recycle Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        e.Cancel = true;
    }

    bool eventsHookedUp = false;
    private void HookupEvents()
    {
      if (eventsHookedUp)
        UnhookEvents();

      recycleBin.BeforeOverwriteFile += recycleBin_BeforeOverwriteFile;
      recycleBin.BeforeOverwriteFolder += recycleBin_BeforeOverwriteFolder;
      recycleBin.EntryTable.ListChanged += EntryTable_ListChanged;
      eventsHookedUp = true;
    }

    void EntryTable_ListChanged(object sender, ListChangedEventArgs e)
    {
      recycleBinList.SetObjects(recycleBin.EntryTable);
    }
    
    private void UnhookEvents()
    {
      if (eventsHookedUp)
      {
        recycleBin.BeforeOverwriteFile -= recycleBin_BeforeOverwriteFile;
        recycleBin.BeforeOverwriteFolder -= recycleBin_BeforeOverwriteFolder;
        recycleBin.EntryTable.ListChanged -= EntryTable_ListChanged;
      }
      eventsHookedUp = false;
    }

    public void Initialize(RecycleBin recycleBin)
    {
      this.recycleBin = recycleBin;
      HookupEvents();

      SetupListView();
      //RecycleBinEntry[] entries = recycleBin.GetEntryList();
      recycleBinList.SetObjects(recycleBin.EntryTable);
      //recycleBinList.DataSource = recycleBin.EntryTable;
    }

    private void SetupListView()
    {
      recycleBinList.LargeImageList = Helpers.GenerateImageList(
        new Bitmap[] { Resources.document_warning32, Resources.folder_closed32 });

      recycleBinList.SmallImageList = Helpers.GenerateImageList(
        new Bitmap[] { Resources.document16, Resources.folder_closed16 });

      recycleBinList.View = View.Details;

      olvFilename.AspectGetter = delegate(object row)
      {
        return Path.GetFileName(((RecycleBinEntry)row).OriginalPath);
      };

      olvFilename.ImageGetter = delegate(object row)
      {
        if (((RecycleBinEntry)row).EntryType == RecycleBinEntryType.File)
          return 0; // Document icon.
        else
          return 1; // Folder icon.
      };

      olvDate.AspectGetter = delegate(object row)
      {
        return Helpers.ElapsedTimeString(((RecycleBinEntry)row).DeletedTimeStamp);
      };

      olvPath.AspectGetter = delegate(object row)
      {
        return Path.GetDirectoryName(((RecycleBinEntry)row).OriginalPath);
      };

      olvType.AspectGetter = delegate(object row)
      {
        return EnumReader.GetText(((RecycleBinEntry)row).EntryType);
      };
    }

    private void biRestoreItem_Click(object sender, EventArgs e)
    {
      foreach (OLVListItem item in recycleBinList.SelectedItems)
      {
        RecycleBinEntry entry = (RecycleBinEntry)item.RowObject;
        bool restored = false;
        if (entry.EntryType == RecycleBinEntryType.File)
          restored = recycleBin.RestoreFile(entry);
        else
          restored = recycleBin.RestoreFolder(entry);

        //if (restored)
        //  recycleBinList.Items.Remove(item);
      }
    }

    private void biDetailsView_CheckedChanged(object sender, EventArgs e)
    {
      if (biDetailsView.Checked)
        recycleBinList.View = View.Details;
    }

    private void biTilesView_CheckedChanged(object sender, EventArgs e)
    {
      if (biTilesView.Checked)
        recycleBinList.View = View.Tile;
    }

    private void recycleBinList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (recycleBinList.SelectedItems.Count > 0)
      {
        lblXStatus.Text = recycleBinList.SelectedItems.Count + (recycleBinList.SelectedItems.Count == 1 ? " item" : " items") + " selected.";
        biRestoreItem.Enabled = true;
        if (recycleBinList.SelectedItems.Count > 1)
          biRestoreItem.Text = "Restore Items";
        else
        {
          OLVListItem item = (OLVListItem)recycleBinList.SelectedItems[0];
          RecycleBinEntry entry = (RecycleBinEntry)item.RowObject;
          if (entry.EntryType == RecycleBinEntryType.File)
            biRestoreItem.Text = "Restore File";
          else
            biRestoreItem.Text = "Restore Folder";
        }
      }
      else
      {
        lblXStatus.Text = "No items selected.";
        biRestoreItem.Text = "<i>No items selected.</i>";
        biRestoreItem.Enabled = false;
      }
      lblXStatus.Refresh();
      biRestoreItem.Refresh();
      itemContainer1.Refresh();
    }

    #region IDocument Members
    private string documentTitle, documentTooltip = "";

    public string DocumentFilename
    {
      get { return DocumentTitle; }
      set { DocumentTitle = value; }
    }

    public string DocumentTitle
    {
      get { return documentTitle; }
      set { documentTitle = value;  }
    }

    public string DocumentTooltip
    {
      get { return documentTooltip; }
      set { documentTooltip = value; }
    }

    public DocumentState DocumentState
    {
      get { return DocumentState.Clean; }
    }

    public IDocumentManager DocumentManager
    {
      get { return Core.Prometheus.Instance.DocumentManager; }
      set { }
    }

    public void LoadDocument()
    {
    }

    public void SaveDocument()
    {
    }

    public void SaveDocumentAs(string path)
    {
    }

    public void CloseDocument()
    {
      UnhookEvents();
    }

    public void Undo()
    {
    }

    public void Redo()
    {
    }

    public event DocumentStateChangedHandler DocumentStateChanged;
    #endregion
  }
}
