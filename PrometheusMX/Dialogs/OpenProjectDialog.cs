using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Core;
using Core.Project;
using System.IO;
using Interfaces;

namespace Prometheus.Dialogs
{
  public partial class OpenProjectDialog : Office2007Form
  {
    private string filename = "";

    /// <summary>
    /// The filename of the selected project.
    /// </summary>
    public string Filename
    {
      get { return filename; }
    }

    public OpenProjectDialog()
    {
      InitializeComponent();
      LoadProjectList();
    }

    private void LoadProjectList()
    {
      // TODO: We really need some centralized object that we can get default paths from.
      string basePath = Application.StartupPath + "\\Games";
      string[] projectFiles = Helpers.GetRecursiveFiles(basePath, ".pproj", 4);
      if (!Directory.Exists(basePath))
      {
        // TODO: Placeholder text for future review by Nick
        labelX1.Text = "The directory given for project files does not exist.";
        listProject.Enabled = false;
        btnOpen.Enabled = false;
      }
      else if (projectFiles == null)
      {
        // TODO: Placeholder text for future review by Nick
        labelX1.Text = "There are no project files to open.";
        listProject.Enabled = false;
        btnOpen.Enabled = false;
      }
      else
      {
        listProject.Enabled = true;
        btnOpen.Enabled = true;
        foreach (string projectFile in projectFiles)
        {
          try
          {
            DateTime modified = File.GetLastWriteTime(projectFile);
            TimeSpan elapsed = DateTime.Now.Subtract(modified);
            string modifiedString = elapsed.TotalMinutes.ToString("0.0") + " minutes ago";
            if (elapsed.TotalMinutes >= 60)
            {
              modifiedString = elapsed.TotalHours.ToString("0.0") + " hours ago";
              if (elapsed.TotalHours >= 24)
              {
                modifiedString = elapsed.TotalDays.ToString("0.0") + " days ago";
              }
            }

            StreamReader reader = null;
            string xml = "";
            try
            {
              reader = new StreamReader(new FileStream(projectFile, FileMode.Open));
              xml = reader.ReadToEnd();
            }
            finally
            {
              reader.Close();
            }

            ProjectFile project = new ProjectFile(xml);
            ListViewItem item = new ListViewItem(new string[] { project.MapName, project.Author, modifiedString, project.TemplateName });
            item.Tag = projectFile;
            listProject.Items.Add(item);
          }
          catch (Exception)
          {
            Output.Write(OutputTypes.Error, "Error opening project file '" + projectFile + "'");
          }
        }
      }
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      if (listProject.SelectedItems.Count > 0)
        filename = (string)listProject.SelectedItems[0].Tag;
      DialogResult = DialogResult.OK;
      Close();
    }
  }
}