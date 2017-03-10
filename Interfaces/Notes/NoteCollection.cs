using System;
using System.Collections;

namespace Interfaces.Notes
{
  public class NoteCollection : CollectionBase
  {
    private int selectedIndex = -1;
    private string sectionName = "";

    public event NoteEvent New;
    public event NoteEvent Delete;
    public event NoteEvent NoteChanged;
    public event NoteEvent SelectedChanged;

    public string SectionName
    {
      get
      { return sectionName; }
      set
      { sectionName = value; }
    }

    public int SelectedIndex
    {
      get
      { return selectedIndex; }
      set
      {
        selectedIndex = value;
        if (SelectedChanged != null)
          SelectedChanged(value);
      }
    }

    public void SaveNote(string name, string description)
    {
      this[selectedIndex].Name = name;
      this[selectedIndex].Text = description;
      this[selectedIndex].Date = DateTime.Now;
      this[selectedIndex].Modified = false;
      if (NoteChanged != null)
        NoteChanged(selectedIndex);
    }

    public void SetModified()
    {
      this[selectedIndex].Modified = true;
      if (NoteChanged != null)
        NoteChanged(selectedIndex);
    }

    public void Add(Note n)
    {
      n.Date = DateTime.Now;
      InnerList.Add(n);
      selectedIndex = InnerList.Count - 1;
      if (New != null)
        New(selectedIndex);
      if (SelectedChanged != null)
        SelectedChanged(selectedIndex);
    }

    public void Remove()
    {
      int i = selectedIndex;
      SelectedIndex = -1;
      InnerList.RemoveAt(i);
      if (Delete != null) Delete(i);
    }

    public Note this[int i]
    {
      get
      { return InnerList[i] as Note; }
    }

    public void Remove(Note note)
    {
      for (int i = 0; i < InnerList.Count; i++)
      {
        Note n = InnerList[i] as Note;
        if (n == note)
        {
          RemoveAt(i);
          return;
        }
      }
    }

    public NoteCollection(Note[] notes)
    {
      if (notes != null)
        InnerList.AddRange(notes);
    }
  }
}
