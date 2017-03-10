using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Interfaces.Notes;

namespace Prometheus.Dialogs
{
  public partial class NoteManager : DevComponents.DotNetBar.Office2007Form
  {
    private bool readOnly = true;
    private NoteCollection notes;

    public NoteManager(NoteCollection noteCollection)
    {
      InitializeComponent();
      notes = noteCollection;

      notes.SelectedChanged += new NoteEvent(notes_SelectedChanged);
      notes.NoteChanged += new NoteEvent(notes_NoteChanged);
      notes.New += new NoteEvent(notes_New);
      notes.Delete += new NoteEvent(notes_Delete);
    }

    public void OpenEdit()
    {
      //grpProperties.Enabled = true;
      bxSaveNotes.Enabled = true;
      readOnly = false;
      liStatus.Text = "Viewing Note '" + notes[notes.SelectedIndex].Name + "' in " + (readOnly ? "read-only" : "editable") + " mode.";
      bxEditNote.Enabled = false;
    }

    public void CloseEdit()
    {
      //grpProperties.Enabled = false;
      bxSaveNotes.Enabled = false;
      readOnly = true;
      try
      {
        notes[notes.SelectedIndex].Modified = false;
      }
      catch
      { }
      bxSaveNotes.Enabled = false;
      bxEditNote.Enabled = true;
      this.Refresh();
    }

    public void DisplayNote(Note n)
    {
      //grpProperties.Text = n.Name + " Contains:";
      txtbNoteName.Text = n.Name;
      txtbNoteContents.Text = n.Text;
      liStatus.Text = "Viewing Note '" + n.Name + "' in " + (readOnly ? "read-only" : "editable") + " mode.";
      try
      {
        notes[notes.SelectedIndex].Modified = false;
      }
      catch
      { }
      bxSaveNotes.Enabled = false;
      this.Refresh();
    }

    public override void Refresh()
    {
      /*lbNotes.Items.Clear();
      for (int x=notes.Count-1; x>=0; x--)
      {
        lbNotes.Items.Add(notes[x]);
      }*/
      lbNotes.Refresh();
    }

    public void ClearProperties()
    {
      readOnly = true;

      this.DisplayNote(new Note("", "", DateTime.Now));
      //grpProperties.Text = "Note Properties";
      liStatus.Text = "No note selected";
    }

    private void btnNew_Click(object sender, System.EventArgs e)
    {
      this.CloseEdit();
      notes.Add(new Note("New Note", "", DateTime.Now));
      this.OpenEdit();
    }

    private void bxEditNote_Click(object sender, System.EventArgs e)
    {
      this.OpenEdit();
    }

    private void btnDelete_Click(object sender, System.EventArgs e)
    {
      notes.Remove();
      bxEditNote.Enabled = (lbNotes.SelectedIndex != -1);
      bxDeleteNote.Enabled = (lbNotes.SelectedIndex != -1);
    }

    private void bxSaveNotes_Click(object sender, System.EventArgs e)
    {
      notes.SaveNote(lblName.Text, txtbNoteContents.Text);
    }

    private void lbNotes_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if (lbNotes.SelectedIndex != notes.SelectedIndex)
      {
        notes.SelectedIndex = lbNotes.SelectedIndex;
      }

      bxEditNote.Enabled = (lbNotes.SelectedIndex != -1);
      bxDeleteNote.Enabled = (lbNotes.SelectedIndex != -1);
    }

    private void NoteEdited(object sender, EventArgs e)
    {
      if (readOnly)
        return;
      if (lblName.Text != notes[notes.SelectedIndex].Name || txtbNoteContents.Text != notes[notes.SelectedIndex].Text)
      {
        notes.SetModified();
        bxSaveNotes.Enabled = true;
      }
      this.Refresh();
    }

    private void notes_SelectedChanged(int index)
    {
      lbNotes.SelectedIndex = index;
      if (index == -1 || index > notes.Count - 1)
      {
        ClearProperties();
      }
      else
      {
        this.CloseEdit();
        this.DisplayNote(notes[notes.SelectedIndex]);
      }

    }

    private void notes_NoteChanged(int index)
    {
      lbNotes.Refresh();
      liStatus.Text = "Viewing Note '" + notes[notes.SelectedIndex].Name + "' in " + (readOnly ? "read-only" : "editable") + " mode.";
    }

    private void notes_New(int index)
    {
      lbNotes.Items.Add(notes[index]);
    }

    private void notes_Delete(int index)
    {
      this.CloseEdit();
      lbNotes.Items.RemoveAt(index);
    }
  }
}