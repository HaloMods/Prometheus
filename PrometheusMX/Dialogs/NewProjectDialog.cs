using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core.Project;
using DevComponents.DotNetBar;
using Interfaces;
using Interfaces.Games;
using Interfaces.Project;

namespace Prometheus.Dialogs
{
  public partial class NewProjectDialog : Office2007Form
  {
    private List<string> team = new List<string>();

    public NewProjectDialog()
    {
      InitializeComponent();

      // Add the available platforms.
      foreach (GameDefinition def in Core.Prometheus.Instance.Games)
        if (!cboxxSystemList.Items.Contains(def.Platform))
          cboxxSystemList.Items.Add(def.Platform);
    }

    private void NewProjectDialog_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!creationSucceeded) // Creation has not occurred successfully yet, make sure the user wants to close.
      {
        // If the user didn't do anything, close the form instantly.
        if (!cboxxTemplateList.Enabled // Implies Platform has not been set.
            && !chkxTeamProject.Checked
            && !chkxUseExistingScnr.Checked
            && String.IsNullOrEmpty(txtbxAuxTag.Text)
            && txtbxMapFileName.ReadOnly // Implies Project Name has not been set.
            && String.IsNullOrEmpty(txtbxProjectAuthor.Text)
            && chkxObfuxMap.Checked)
        {
          return; // If return is not here, the code below will be executed.
        }

        // They did do something, so let's ask them if they really want to quit.
        DialogResult result =
          MessageBoxEx.Show("All entered information will be lost.\n\nCancel project creation?",
                            "Verify Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.Yes)
        {
          return; // Redundant right now, but if code is added below this line later, the return is needed.
        }

        // They want to stay, so we'll let them ... for now.
        e.Cancel = true;
      }
    }

    private string projectFile = String.Empty;
    private bool GenerateProject()
    {
      // Handle the creation of the project file.
      try
      {
        Platform platform = (Platform)cboxxSystemList.SelectedItem;
        string gameID = GameDefinition.GetGameID((string) cboxxGameList.SelectedItem, platform);
        projectFile = Core.Prometheus.Instance.ProjectManager.CreateProject(txtbxProjectName.Text,
                                                                            txtbxProjectAuthor.Text,
                                                                            gameID,
                                                                            cboxxTemplateList.SelectedItem as ProjectTemplate,
                                                                            txtbxProjectName.Text);
      }
      catch(CreateProjectFailedException)
      {
        return false;
      }

      return true;
    }

    private void pxCreateProject_VisibleChanged(object sender, EventArgs e)
    {
      if (pxCreateProject.Visible)
        this.Size = new Size(273, 260);
      else
        this.Size = new Size(273, 187);
    }

    private void cboxxSystemList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cboxxSystemList.SelectedIndex < 0)
        return;

      cboxxGameList.Items.Clear();
      cboxxTemplateList.Items.Clear();
      cboxxTemplateList.Enabled = false;
      cboxxTemplateList.Refresh();

      // Add the available games.
      foreach (GameDefinition game in Core.Prometheus.Instance.Games)
        if (game.Platform == (Platform)cboxxSystemList.SelectedIndex)
          cboxxGameList.Items.Add(game.Name);

      cboxxGameList.Enabled = true;
      cboxxGameList.Refresh();

      // If there is only one option, auto-select it.
      if (cboxxGameList.Items.Count == 1)
        cboxxGameList.SelectedIndex = 0;
      else if (cboxxGameList.Items.Count > 0)
        cboxxGameList.DroppedDown = true;
    }

    private void cboxxGameList_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cboxxGameList.SelectedIndex < 0)
        return;

      cboxxTemplateList.Items.Clear();

      // Add the available templates.
      foreach (GameDefinition game in Core.Prometheus.Instance.Games)
        if (game.Name.Equals(cboxxGameList.Items[cboxxGameList.SelectedIndex]))
          if (game.Platform == (Platform)cboxxSystemList.SelectedIndex)
            cboxxTemplateList.Items.AddRange(game.ProjectTemplates);

      cboxxTemplateList.Enabled = true;
      cboxxTemplateList.Refresh();

      // If there is only one option, auto-select it.
      if (cboxxTemplateList.Items.Count == 1)
        cboxxTemplateList.SelectedIndex = 0;
      else if (cboxxTemplateList.Items.Count > 0)
        cboxxTemplateList.DroppedDown = true;
    }

    private void cboxxTemplateList_SelectedIndexChanged(object sender, EventArgs e)
    {
      txtbxProjectName.Focus();
    }

    private void txtbxProjectName_TextChanged(object sender, EventArgs e)
    {
      int caretPos = txtbxProjectName.SelectionStart;

      if (String.IsNullOrEmpty(txtbxProjectName.Text))
      {
        txtbxMapFileName.ReadOnly = true;
        txtbxMapFileName.BackColor = System.Drawing.SystemColors.Control;

        txtbxMapFileName.WatermarkText = "Map File Name";

        return;
      }
      else
      {
        txtbxMapFileName.ReadOnly = false;
        txtbxMapFileName.BackColor = System.Drawing.SystemColors.Window;

        string cleanName = Prometheus.ThirdParty.Helpers.Strings.AlphanumericalOnlyWithSpaces(txtbxProjectName.Text);

        if (!txtbxProjectName.Text.Equals(cleanName)) // If the current text and the "clean" text are not the same. (This code prevents an endless loop)
          txtbxProjectName.Text = cleanName; // Set the current text to the "clean" text.

        txtbxMapFileName.WatermarkText = cleanName.Replace(" ", String.Empty) + ".map"; // Remove spaces from cleanName since we do not allow spaces for the map file name.
      }

      txtbxProjectName.SelectionStart = caretPos; // Reset caret to where it was before we cleaned the text.
    }

    private void txtbxMapFileName_Enter(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(txtbxMapFileName.Text))
        return;

      int periodLocation = txtbxMapFileName.Text.IndexOf('.');

      if (periodLocation != -1) // There is a period
        txtbxMapFileName.Text = txtbxMapFileName.Text.Remove(periodLocation, txtbxMapFileName.Text.Length - periodLocation);
    }

    private void txtbxMapFileName_Leave(object sender, EventArgs e)
    {
      if(String.IsNullOrEmpty(txtbxMapFileName.Text))
        return;

      int periodLocation = txtbxMapFileName.Text.IndexOf('.');

      if (periodLocation == -1)
        txtbxMapFileName.Text = txtbxMapFileName.Text + ".map";
      else // Somehow a period got in and it needs removal.
        txtbxMapFileName.Text = txtbxMapFileName.Text.Remove(periodLocation, txtbxMapFileName.Text.Length - periodLocation) + ".map";
    }

    private void txtbxMapFileName_TextChanged(object sender, EventArgs e)
    {
      int caretPos = txtbxMapFileName.SelectionStart;

      if(!txtbxMapFileName.Focused) // Do not filter changes made when the control does not have focus.
        return;
        
      string cleanName = Prometheus.ThirdParty.Helpers.Strings.AlphanumericalOnly(txtbxMapFileName.Text);

      if (!txtbxMapFileName.Text.Equals(cleanName)) // If the current text and the "clean" text are not the same. (This code prevents an endless loop)
        txtbxMapFileName.Text = cleanName; // Set the current text to the "clean" text.

      txtbxMapFileName.SelectionStart = caretPos; // Reset caret to where it was before we cleaned the text.
    }

    private void chkxUseExistingScnr_CheckedChanged(object sender, EventArgs e)
    {
      if (chkxUseExistingScnr.Checked)
      {
        txtbxAuxTag.WatermarkText = "Scenario Tag";
        this.stNewProject.SetSuperTooltip(this.infoAuxTag, new DevComponents.DotNetBar.SuperTooltipInfo("Scenario Tag", "", "Select a pre-existing scenario tag to be used instead of a clean scenario.<br /><br />If a clean scenario tag is desired, uncheck \"Use Existing Scenario Tag\" and one will be generated when the project is created.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      }
      else
      {
        txtbxAuxTag.WatermarkText = "Scenario Structure BSP Tag";
        this.stNewProject.SetSuperTooltip(this.infoAuxTag, new DevComponents.DotNetBar.SuperTooltipInfo("Scenario Structure BSP Tag", "", "Select a pre-existing scenario structure BSP tag to be used by the project's generated scenario tag.<br /><br />If a scenario structure BSP tag has not already been created for the world mesh, there will be an opportunity to import and process a mesh after the project has been created.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new System.Drawing.Size(0, 0)));
      }
    }

    private void imgbAuxTag_Click(object sender, EventArgs e)
    {
        Platform platform = (Platform)cboxxSystemList.SelectedItem;
        string gameid = GameDefinition.GetGameID((string)cboxxGameList.SelectedItem, platform);
        GameDefinition selectedGame = null;
        foreach (GameDefinition game in Core.Prometheus.Instance.Games)
        {
            if (game.GameID == gameid)
            {
                selectedGame = game;
                break;
            }
        }

        if (selectedGame != null)
        {
            TagBrowserDialog _tagBrowser = new TagBrowserDialog();
            if (_tagBrowser.ShowDialog(selectedGame) == DialogResult.OK)
            {
                txtbxAuxTag.Text = _tagBrowser.TagPath;
                pbAuxTag.Enabled = !String.IsNullOrEmpty(txtbxAuxTag.Text);
            }
        }
    }

    private void chkxTeamProject_CheckedChanged(object sender, EventArgs e)
    {
      bxProjectTeam.Visible = chkxTeamProject.Checked;
      infoProjectTeam.Visible = bxProjectTeam.Visible;
    }

    private void bxProjectTeam_VisibleChanged(object sender, EventArgs e)
    {
      if (bxProjectTeam.Visible)
      {
        txtbxProjectAuthor.WatermarkText = "Team Name";
        this.stNewProject.SetSuperTooltip(this.infoProjectAuthor, new DevComponents.DotNetBar.SuperTooltipInfo("Team Name (Required)", "", "Set the name of the team working on the project. Credit individuals on the team by clicking the \"Team\" button.<br /><br />The Team Name may be changed at any time via the Project Properties pane.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new Size(0, 0)));
      }
      else
      {
        txtbxProjectAuthor.WatermarkText = "Author Name";
        this.stNewProject.SetSuperTooltip(this.infoProjectAuthor, new DevComponents.DotNetBar.SuperTooltipInfo("Author Name (Required)", "", "Set the project author's name.<br /><br />Note that this name will be included in the map credits to cite the author.<br /><br />The Author Name may be updated at any time via the Project Properties pane.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.System, true, false, new Size(0, 0)));
      }
    }

    private void bxProjectTeam_Click(object sender, EventArgs e)
    {
      pxCreateProject.Visible = false;
      pxTeamListEditor.Visible = true;
    }

    private bool creationSucceeded = false;
    private void bxCreateProject_Click(object sender, EventArgs e)
    {
      #region Data Checking
      // If the user failed to provide the Project Platform, inform them.
      if (!cboxxTemplateList.Enabled) // Implies Platform has not been set.
      {
        MessageBoxEx.Show("The <b>Project Platform</b> has not been set; it is a required field.<br /><br />Enter the <b>Project Platform</b> and try again.", "Project Platform Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        if(cboxxSystemList.SelectedIndex == -1)
          cboxxSystemList.DroppedDown = true;
        else
          cboxxGameList.DroppedDown = true;

        return;
      }

      // If the user failed to provide the Project Name, inform them.
      if (String.IsNullOrEmpty(txtbxProjectName.Text))
      {
        MessageBoxEx.Show("The <b>Project Name</b> has not been set; it is a required field.<br /><br />Enter the <b>Project Name</b> and try again.", "Project Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        txtbxProjectName.Focus();
        return;
      }

      // If the user failed to provide the Project Team / Author, inform them.
      if (String.IsNullOrEmpty(txtbxProjectAuthor.Text))
      {
        if (chkxTeamProject.Checked)
          MessageBoxEx.Show("The <b>Project Team Name</b> has not been set; it is a required field.<br /><br />Enter the <b>Project Team Name</b> and try again.", "Project Team Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        else
          MessageBoxEx.Show("The <b>Project Author Name</b> has not been set; it is a required field.<br /><br />Enter the <b>Project Author Name</b> and try again.", "Project Author Name Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        txtbxProjectAuthor.Focus();
        return;
      }

      // If the user specified they wanted to use an existing Scenario tag and have failed to select an existing Scenario tag, inform them.
      if (chkxUseExistingScnr.Checked && String.IsNullOrEmpty(txtbxAuxTag.Text))
      {
        MessageBoxEx.Show("The <b>Scenario Tag</b> has not been set; it must be set when the \"Use Existing Scenario Tag\" option is checked.<br /><br />Choose a <b>Scenario Tag</b> or uncheck the \"Use Existing Scenario Tag\" option and try again.", "Scenario Tag Required", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

        imgbAuxTag_Click(null, EventArgs.Empty);
        return;
      }

      // If the user failed to provide a list of team members for a team project, inform them.
      if (chkxTeamProject.Checked && team.Count == 0)
      {
        DialogResult result = MessageBoxEx.Show("The <b>Team List</b> is empty; only a Team Name has been assigned to the project.<br /><br />No individuals will be credited as part of the team – and thus as part of this project – at this time. This may be modified later via the Project Properties pane.<br /><br />Add individuals to the <b>Team List</b> now?", "Team List Empty", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        if (result == DialogResult.Yes)
        {
          // Allow user to add to team list now.
          bxProjectTeam_Click(null, EventArgs.Empty);
          return;
        }
      }
      #endregion

      DialogResult proceed = MessageBoxEx.Show("Create the project with the specified settings?", "Verify Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

      // The user wants to bail; kick them out.
      if (proceed == DialogResult.No)
        return;

      // The user is happy with their settings, create the prefab.
      creationSucceeded = GenerateProject();

      // If something goes wrong during project creation, end the creation process so the user may attempt to correct the issue and try again.
      // The GenerateProject() function should have notified the user of the error's cause, so nothing to do here but return.
      if (!creationSucceeded)
      {
        return;
      }

      // The project has been created and saved to the hard disk successfully; report to the user.
      pxCreateProject.Visible = false;
      pxSuccess.Visible = true;
    }

    #region Team List Editor

    private void pxTeamListEditor_VisibleChanged(object sender, EventArgs e)
    {
      // User cannot see panel, exit event.
      if (!pxTeamListEditor.Visible)
      {
        this.Text = "Create New Project";
        pxCreateProject.Visible = true;
        return;
      }

      pxCreateProject.Visible = false;
      this.Text = "Team List Editor";
      leTeamListEditor.StringItems = team;
    }

    private void bxTeamListEditorSave_Click(object sender, EventArgs e)
    {
      if (leTeamListEditor.StringItems.Count == 0)
      {
        if (leTeamListEditor.InitialEntryCount > 0) // Only ask about saving an empty list if it wasn't already empty.
        {
          DialogResult result =
            MessageBoxEx.Show("The team list is empty.<br /><br />Save the empty list?", "Team List Empty",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

          if (result == DialogResult.No)
            return;
        }
      }

      team.Clear();
      team = leTeamListEditor.StringItems;

      pxTeamListEditor.Visible = pxCreateProject.Visible;
    }

    private void bxTeamListEditorCancel_Click(object sender, EventArgs e)
    {
      if (leTeamListEditor.Dirty)
      {
        DialogResult result =
          MessageBoxEx.Show("All changes made to the Team List will be lost.\n\nCancel changes to Team List?",
                            "Verify Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2);

        if (result == DialogResult.No)
          return;
      }

      pxTeamListEditor.Visible = pxCreateProject.Visible;
    }

    #endregion

    #region Success

    private void pxSuccess_VisibleChanged(object sender, EventArgs e)
    {
      // User cannot see panel, exit event.
      if (!pxSuccess.Visible || !creationSucceeded)
        return;

      this.Text = "New Project Created";

      #region Top Right Image
      if (chkxObfuxMap.Checked)
      {
        pbSuccessObfuxed.Image = global::Prometheus.Properties.Resources.lock16;
        this.stNewProject.SetSuperTooltip(this.pbSuccessObfuxed, new DevComponents.DotNetBar.SuperTooltipInfo("Obfuscation Enabled", "", "The map will be obfuscated when compiled to help protect it from decompilation.",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Green, true, false, new Size(0, 0)));
      }
      else
      {
        pbSuccessObfuxed.Image = global::Prometheus.Properties.Resources.lock_open16;
        this.stNewProject.SetSuperTooltip(this.pbSuccessObfuxed, new DevComponents.DotNetBar.SuperTooltipInfo("Obfuscation Disabled", "", "The map will not be obfuscated when compiled and will be more susceptible to decompilation by users with the proper tools.<br /><br />Map obfuscation can be turned on in the Project Properties pane",
                    null, null, DevComponents.DotNetBar.eTooltipColor.Red, true, false, new Size(0, 0)));
      }
      #endregion

      // Turn Esc key on.
      this.CancelButton = bxSuccessOpenProject;

      bxSuccessImportSBSP.Focus();
    }

    private void bxSuccessImportSBSP_Click(object sender, EventArgs e)
    {
#if DEBUG
      MessageBox.Show("Not yet implemented.", "OMG YOU SUCK", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
    }

    private void bxSuccessOpenScenario_Click(object sender, EventArgs e)
    {
      Core.Project.ProjectManager.Instance.OpenProject(projectFile, ScenarioAction.Load);
    }

    private void bxSuccessOpenProject_Click(object sender, EventArgs e)
    {
      Core.Project.ProjectManager.Instance.OpenProject(projectFile);
    }

    #endregion
  }
}