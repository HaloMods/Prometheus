using System;
using System.IO;

namespace Interfaces.Notes
{
  public class Note
  {
    private bool modified = false;
    private string text = null;
    private string name = null;
    private DateTime date = default(DateTime);

    public const int NoteSize = 32;

    public string Name
    {
      get
      { return name; }
      set
      { name = value; }
    }

    public string Text
    {
      get
      { return text; }
      set
      { text = value; }
    }

    public bool Modified
    {
      get
      { return modified; }
      set
      { modified = value; }
    }

    public DateTime Date
    {
      get
      { return date; }
      set
      { date = value; }
    }

    internal Note(Stream stream)
    {
      Read(stream);
    }

    public Note(string name, string note, DateTime date)
    {
      this.text = note;
      this.name = name;
      this.date = date;
    }

    internal void Write(Stream stream)
    {
      long position = stream.Position;
      BinaryWriter bw = new BinaryWriter(stream);
      bw.Write(name.Length);
      bw.Write((int)stream.Length);
      bw.Write(text.Length);
      bw.Write((int)stream.Length + name.Length + 1);
      bw.Write(date.ToBinary());
      bw.Write(0);
      bw.Write(0);
      stream.Position = stream.Length;
      foreach (char c in name)
        bw.Write(Convert.ToByte(c));
      bw.Write((byte)0);
      foreach (char c in text)
        bw.Write(Convert.ToByte(c));
      stream.Position = position + NoteSize;
    }

    internal void Read(Stream stream)
    {
      long position = stream.Position;
      BinaryReader br = new BinaryReader(stream);
      int nameLength = br.ReadInt32();
      int nameOffset = br.ReadInt32();
      int noteLength = br.ReadInt32();
      int noteOffset = br.ReadInt32();
      date = DateTime.FromBinary(br.ReadInt64());
      stream.Position = nameOffset;
      name = new string(br.ReadChars(nameLength));
      stream.Position = noteOffset;
      text = new string(br.ReadChars(noteLength));
      stream.Position = position + NoteSize;
    }

    public override string ToString()
    { return (modified ? "* " : "") + name; }
  }
}
