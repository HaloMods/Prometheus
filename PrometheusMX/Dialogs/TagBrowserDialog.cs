using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Interfaces.Games;
using Prometheus.Controls;
using Prometheus.Properties;

namespace Prometheus.Dialogs
{
  public partial class TagBrowserDialog : Office2007Form
  {
      private string tagPath = string.Empty;

    public TagBrowserDialog()
    {
      InitializeComponent();
    }

      public string TagPath
      {
          get { return this.tagPath; }
      }

      public DialogResult ShowDialog(GameDefinition game)
      {
          //TODO: Error checking.
          treeView.Reset();
          
          DefaultState defaultState = new DefaultState(Resources.cd16);
          TagArchiveObjectViewNodeSource source = new TagArchiveObjectViewNodeSource("Extracted", game, Core.Prometheus.Instance.DocumentManager, 
              DisplayItems.AllExtractedItems, defaultState);
          source.LoadDependencies = true;
          NodeHierarchy main = new NodeHierarchy(game.Name + "Tag Library", Resources.folder16);
          main.NodeSources.Add(source);

          treeView.AddNodeHierarchy(main);
          treeView.Initialize();
          treeView.SelectedNode = null;

          return base.ShowDialog();
      }

      private void TagBrowserDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
          TreeNode node = treeView.SelectedNode;
          while (node.Parent != null)
          {
              this.tagPath = string.Format("{0}\\{1}", node.Text, this.tagPath);
              node = node.Parent;
          }
      }

    //private void SetupTreeView(GameDefinition game)
    //{
    //  MultiSourceTreeView treeView = new MultiSourceTreeView();

    //  NodeSource source = new LibraryNodeSource("Extracted", game.GlobalTagLibrary, DisplayMode.Folders);
    //  source.BackColor = Color.White;
    //  source.ForeColor = Color.Black;

    //  NodeHierarchy main = new NodeHierarchy("Tag Library - " + game.Name, Resources.folder16);
    //  main.NodeSources.Add(source);

    //  treeView.AddNodeHierarchy(main);
    //  treeView.Initialize();
    //  cboFolder.TreeView = treeView;
    //}
  }
}